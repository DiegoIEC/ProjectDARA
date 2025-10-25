import React, { useState } from "react";
import axios from "axios";

function FloatingButton() {
    const [isOpen, setIsOpen] = useState(false);
    const [activeForm, setActiveForm] = useState(null);

    const [categoryName, setCategoryName] = useState("");
    const [transaction, setTransaction] = useState({ description: "", amount: "" });
    const [budget, setBudget] = useState({ name: "", limit: "" });

    const toggleMenu = () => {
        setIsOpen(!isOpen);
        setActiveForm(null);
    };

    const handleClick = (formName) => {
        setActiveForm(formName);
    };

    const postWithToken = async (url, data) => {
        const token = localStorage.getItem("token");
        return axios.post(url, data, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
    };

    const handleCategorySubmit = async (e) => {
        e.preventDefault();
        try {
            await postWithToken("https://localhost:7092/api/Categories", { name: categoryName });
            alert("Category created!");
            setActiveForm(null);
        } catch (err) {
            alert("Error creating category.");
        }
    };

    const handleTransactionSubmit = async (e) => {
        e.preventDefault();
        try {
            await postWithToken("https://localhost:7092/api/Transactions", transaction);
            alert("Transaction added!");
            setActiveForm(null);
        } catch (err) {
            alert("Error adding transaction.");
        }
    };

    const handleBudgetSubmit = async (e) => {
        e.preventDefault();
        try {
            await postWithToken("https://localhost:7092/api/Budgets", budget);
            alert("Budget created!");
            setActiveForm(null);
        } catch (err) {
            alert("Error creating budget.");
        }
    };

    return (
        <>
            {/* Floating Button */}
            <button
                onClick={toggleMenu}
                style={{
                    position: "fixed",
                    bottom: "20px",
                    right: "20px",
                    borderRadius: "50%",
                    width: "60px",
                    height: "60px",
                    backgroundColor: "#007bff",
                    color: "white",
                    fontSize: "32px",
                    border: "none",
                    boxShadow: "0 4px 8px rgba(0,0,0,0.2)",
                    cursor: "pointer",
                    zIndex: 1000
                }}
            >
                +
            </button>

            {/* Menu */}
            {isOpen && (
                <div style={{
                    position: "fixed",
                    bottom: "90px",
                    right: "20px",
                    background: "white",
                    border: "1px solid #ccc",
                    borderRadius: "8px",
                    padding: "10px",
                    boxShadow: "0 4px 8px rgba(0,0,0,0.2)",
                    zIndex: 999
                }}>
                    <p onClick={() => handleClick("category")} style={menuItem}>New Category</p>
                    <p onClick={() => handleClick("transaction")} style={menuItem}>Add Transaction</p>
                    <p onClick={() => handleClick("budget")} style={menuItem}>Create Budget</p>
                </div>
            )}

            {/* FORMS in Center */}
            {activeForm === "category" && (
                <div style={centeredForm}>
                    <h3>Create Category</h3>
                    <form onSubmit={handleCategorySubmit}>
                        <input
                            type="text"
                            placeholder="Category Name"
                            value={categoryName}
                            onChange={(e) => setCategoryName(e.target.value)}
                            required
                        /><br />
                        <button type="submit">Save</button>
                    </form>
                </div>
            )}

            {activeForm === "transaction" && (
                <div style={centeredForm}>
                    <h3>Add Transaction</h3>
                    <form onSubmit={handleTransactionSubmit}>
                        <input
                            type="text"
                            placeholder="Description"
                            value={transaction.description}
                            onChange={(e) => setTransaction({ ...transaction, description: e.target.value })}
                            required
                        /><br />
                        <input
                            type="number"
                            placeholder="Amount"
                            value={transaction.amount}
                            onChange={(e) => setTransaction({ ...transaction, amount: e.target.value })}
                            required
                        /><br />
                        <button type="submit">Save</button>
                    </form>
                </div>
            )}

            {activeForm === "budget" && (
                <div style={centeredForm}>
                    <h3>Create Budget</h3>
                    <form onSubmit={handleBudgetSubmit}>
                        <input
                            type="text"
                            placeholder="Budget Name"
                            value={budget.name}
                            onChange={(e) => setBudget({ ...budget, name: e.target.value })}
                            required
                        /><br />
                        <input
                            type="number"
                            placeholder="Limit"
                            value={budget.limit}
                            onChange={(e) => setBudget({ ...budget, limit: e.target.value })}
                            required
                        /><br />
                        <button type="submit">Save</button>
                    </form>
                </div>
            )}
        </>
    );
}

const menuItem = {
    cursor: "pointer",
    padding: "5px 10px",
    fontSize: "16px",
    color: "#333"
};

const centeredForm = {
    position: "fixed",
    top: "50%",
    left: "50%",
    transform: "translate(-50%, -50%)",
    background: "#fff",
    border: "1px solid #ccc",
    borderRadius: "8px",
    padding: "20px",
    boxShadow: "0 4px 12px rgba(0,0,0,0.3)",
    zIndex: 998
};

export default FloatingButton;