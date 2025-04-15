// src/pages/Register.jsx
import { useState } from "react";
import api from "../../services/api";
import { useNavigate, Link } from "react-router-dom";
import "./Register.css";

export default function Register() {
  const [nome, setNome] = useState("");
  const [email, setEmail] = useState("");
  const [senha, setSenha] = useState("");
  const navigate = useNavigate();

  const handleRegister = async () => {
    try {
      await api.post("/auth/register", {
        nome,
        email,
        senha,
      });
      alert("Cadastro realizado!");
      navigate("/");
    } catch (error) {
      alert("Erro ao cadastrar");
    }
  };

  return (
    <div className="cadastro-container">
      <form className="cadastro-box" onSubmit={handleRegister}>
        <h1 className="cadastro-title">Cadastro</h1>
        <input
          type="text"
          placeholder="Nome"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
          className="cadastro-input"
          required
        />
        <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="cadastro-input"
          required
        />
        <input
          type="password"
          placeholder="Senha"
          value={senha}
          onChange={(e) => setSenha(e.target.value)}
          className="cadastro-input"
          required
        />
        <button type="submit" className="cadastro-button">
          Entrar
        </button>
        <p className="cadastro-register">
          Já possui uma conta?{" "}
          <Link to="/">
            <span>Login</span>
          </Link>
        </p>
      </form>
    </div>
  );
}
