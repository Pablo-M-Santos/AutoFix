import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import Navbar from "../components/Navbar";

export default function Home() {
  const navigate = useNavigate();
  const [isAdmin, setIsAdmin] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem("token");
    const role = localStorage.getItem("role");

    if (!token) {
      navigate("/");
    }

    if (role === "admin") {
      setIsAdmin(true);
    }
  }, []);

  return (
    <div>
      <Navbar />
      <h2>Bem-vindo ao sistema!</h2>
      {isAdmin && (
        <button onClick={() => navigate("/dashboard")}>
          Ir para o Dashboard
        </button>
      )}
      <button
        onClick={() => {
          localStorage.removeItem("token");
          localStorage.removeItem("role");
          navigate("/");
        }}
      >
        Sair
      </button>
    </div>
  );
}
