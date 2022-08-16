﻿using CloudStorage.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloudStorage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
            => _fileService = fileService;

        /// <summary>
        /// Upload files to Blob Storage, save info about files, limit size of files in account
        /// </summary>
        /// <param name="files">Uploading files</param>
        /// <param name="currentFolderId">Current directory id</param>
        /// <returns>Status code 201</returns>

        [HttpPost]
        public async Task<IActionResult> AddFiles(List<IFormFile> files, Guid? currentFolderId)
        {
            await _fileService.AddFiles(files, UserId, currentFolderId);
            return CreatedAtAction(nameof(AddFiles), files);
        }

        /// <summary>
        /// Remove files from Blob Storage, info and storage info 
        /// </summary>
        /// <param name="names">Names of files</param>
        /// <param name="currentFolderId">Current directory id</param>
        /// <returns>Status code 204</returns>

        [HttpDelete]
        public async Task<IActionResult> RemoveFiles(List<Guid> ids)
        {
            await _fileService.RemoveFiles(ids, UserId);
            return NoContent();
        }
    }
}
