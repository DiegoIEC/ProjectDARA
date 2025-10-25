import { FaMoneyBill, FaShoppingCart, FaUtensils } from 'react-icons/fa';
import { useState, useEffect } from "react";
import axios from "axios";
import FloatingButton from '../components/FloatingButton';
function Dashboard() {
    const [categories, setCategories] = useState([]);
    const [name, setName] = useState("");
    const [selectedId, setSelectedId] = useState(null);

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                const token = localStorage.getItem("token");
                const response = await axios.get("https://localhost:7092/api/Categories", {
                    headers: {
                        Authorization: `Bearer ${token}`
                    }
                });

                setCategories(response.data);
            } catch (error) {
                console.error("Error loading categories:", error);
            }
        };

        fetchCategories();
    }, []);

    const handleCreateCategory = async (e) => {
        e.preventDefault();

        try {
            const token = localStorage.getItem("token");

            const response = await axios.post("https://localhost:7092/api/Categories", {
                name
            }, {
                headers: {
                    Authorization: `Bearer ${token}` 
                }
            });

            // Handle success (e.g., update category list)
        } catch (error) {
            alert("Failed to create category");
            console.error(error);
        }
    };

    return (
        <div>
            <form onSubmit={handleCreateCategory}>
                <h2>Create a category</h2>
                <input type="name" value={name} onChange={(e) => setName(e.target.value)} placeholder="Name" required />
                <button type="submit">Create</button>
            </form>

            <h1>Budget</h1>
            <div style={{ width: '200px', border: '1px solid #ccc', borderRadius: '6px' }}>
                {categories.map(item => (
                    <div
                        key={item.id}
                        onClick={() => setSelectedId(item.id)}
                        style={{
                            display: 'flex',
                            alignItems: 'center',
                            padding: '10px',
                            background: selectedId === item.id ? '#e0f7fa' : 'white',
                            cursor: 'pointer',
                            borderBottom: '1px solid #eee'
                        }}
                    >
                        <span style={{ marginRight: '10px' }}>{item.icon}</span>
                        <span>{item.name}</span>
                    </div>
                ))}
            </div>
            <FloatingButton />
        </div>
    );
}

export default Dashboard;