// using FluentValidation;
// using Produtos.DTOs;

// namespace Produtos.Validations
// {
//     public class ProdutoDTOValidator : AbstractValidator<ProdutoDTO>
//     {
//         public ProdutoDTOValidator()
//         {
//             RuleFor(p => p.Nome).NotEmpty().WithMessage("Nome é obrigatório");
//             RuleFor(p => p.Preco).GreaterThan(0).WithMessage("Preço deve ser maior que 0");
//             RuleFor(p => p.Quantidade).GreaterThanOrEqualTo(0).WithMessage("Quantidade não pode ser negativa");
//         }
//     }
// }
