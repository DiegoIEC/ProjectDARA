import { Link, useNavigate } from "react-router-dom";

export default function Navbar() {
    const token = localStorage.getItem("token");
    const navigate = useNavigate();

    const handleLogout = () => {
        localStorage.removeItem("token");
        navigate("/login");
    };

    return (
        <nav style={{ display: "flex", justifyContent: "space-between", padding: "1rem", background: "#eee" }}>
            <div>
                <Link to="/dashboard">Dashboard</Link>
            </div>
            <div>
                {!token ? (
                    <Link to="/login">Login</Link>
                ) : (
                    <button onClick={handleLogout}>Logout</button>
                )}
            </div>
        </nav>
    );
}