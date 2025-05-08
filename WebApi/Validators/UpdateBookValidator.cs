using System;
using FluentValidation;
using WebApi.Models.Book;

public class UpdateBookValidator : AbstractValidator<UpdateBookModel>
{
    public UpdateBookValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MinimumLength(2);
        RuleFor(x => x.GenreId).GreaterThan(0);
        RuleFor(x => x.PageCount).GreaterThan(0);
        RuleFor(x => x.PublishDate).LessThan(DateTime.Now);
    }
}
