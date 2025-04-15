// components/Navbar.jsx
import { useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";

export default function Navbar() {
  const navigate = useNavigate();
  const [isAdmin, setIsAdmin] = useState(false);

  useEffect(() => {
    const role = localStorage.getItem("role");
    if (role === "Administrador") {
      setIsAdmin(true);
    }
  }, []);

  return (
    <nav >
      <h1 style={{ cursor: "pointer" }} onClick={() => navigate("/home")}>Autofix</h1>
      <div>
        {isAdmin && (
          <button onClick={() => navigate("/dashboard")}>Dashboard</button>
        )}
      </div>
    </nav>
  );
}
