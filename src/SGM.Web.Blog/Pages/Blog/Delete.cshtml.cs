﻿using Microsoft.AspNetCore.Authorization;
using SGM.BlogApp.Utils;

namespace SGM.BlogApp.Pages;

[Authorize(Roles = "SuperAdmin,Admin")]
public class DeleteBlogModel : PageModel
{
    private readonly ImageHelper _imageHelper;
    private readonly IBlogRepository _blogRepository;

    public DeleteBlogModel(ImageHelper imageHelper, IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
        _imageHelper = imageHelper;
    }

    [BindProperty]
    public Domain.Entities.BlogEntities.Blog Blog { get; set; }

    public string Tags { get; set; }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Blog = await _blogRepository.GetByIdAsync(id);
        Tags = Tag.ConvertTagsToString(Blog.Tags);

        if (Blog == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Blog = await _blogRepository.GetByIdAsync(id);

        if (Blog != null)
        {
            await _blogRepository.DeleteBlogAsync(Blog);
            _imageHelper.RemoveImage(Blog.CoverPhotoPath);
        }

        return RedirectToPage("/Blog/List");
    }
}
