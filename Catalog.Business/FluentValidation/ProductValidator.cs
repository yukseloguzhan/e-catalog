using Catalog.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Business.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            //RuleFor(x => x.Id).GreaterThan(0).WithMessage("Ürün id'si 0'dan büyük olmalı!");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Ürün id'si 0'dan büyük olmalı!");
            RuleFor(x => x.Title).Length(2, 30).WithMessage("Ürün adı 2-30 karakter olmalı!");
            RuleFor(x => x.Installment).GreaterThan(1).WithMessage("Taksit sayısı 1'den büyük olmalı!");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün fiyatı 0 TL den büyük olmalı!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!");
            RuleFor(x => x.Code).NotEmpty().WithMessage("Ürün kodu boş geçilemez!");
            RuleFor(x => x.CreateDate).GreaterThanOrEqualTo(DateTime.Now).WithMessage("Trih alanı bugünün tarihinden büyük olamaz!");
        }
    }
}
