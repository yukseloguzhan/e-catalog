using Catalog.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Business.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            //RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori id'si 0'dan büyük olmalı!");
            RuleFor(x => x.Name).Length(2,30).WithMessage("Kategori adı 2-30 karakter olmalı!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez!!!");
        }
    }
}
