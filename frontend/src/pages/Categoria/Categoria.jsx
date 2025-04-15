import React from 'react';
import { Box, Typography } from '@mui/material';

function Categoria() {
  return (
    <Box sx={{ py: 4, display: 'flex', flexDirection: 'column', alignItems: 'center', textAlign: 'center', backgroundColor: 'red' }}>
      <Typography variant="h4">Página de Categorias</Typography>
      <Typography>Bem-vindo à página de categorias!</Typography>
    </Box>
  );
}

export default Categoria;
