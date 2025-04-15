import { useState } from "react";
import api from "../../services/api";
import { useNavigate, Link } from "react-router-dom";
import "./Login.css";

export default function Login() {
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await api.post("/auth/login", {
        email,
        senha,
      });
      localStorage.setItem("token", response.data.token);
      navigate("/home");
    } catch (error) {
      alert("Login inválido");
    }
  };

  return (
    <div className="login-container">
      <form className="login-box" onSubmit={handleLogin}>
        <h1 className="login-title">Login</h1>
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="login-input"
          required
        />
        <input
          type="password"
          placeholder="Senha"
          value={senha}
          onChange={(e) => setSenha(e.target.value)}
          className="login-input"
          required
        />
        <button type="submit" className="login-button">
          Entrar
        </button>
        <p className="login-register">
          Não possui uma conta?{" "}
          <Link to="/cadastro">
            <span>Cadastre-se</span>
          </Link>
        </p>
      </form>
    </div>
  );
}
