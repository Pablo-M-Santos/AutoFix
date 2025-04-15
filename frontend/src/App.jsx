import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./pages/Login/Login";
import Register from "./pages/Cadastro/Register";
import Home from "./pages/Home";
import Dashboard from "./pages/Dashboard/Dashboard";
import Categoria from "./pages/Categoria/Categoria";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/cadastro" element={<Register />} />
        <Route path="/home" element={<Home />} />
        <Route path="/dashboard" element={<Dashboard />}>
          <Route path="categoria" element={<Categoria />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
