﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControllerExtensions.cs" company="Marcin Smółka zNET Computer Solutions">
//   Copyright (c) Marcin Smółka zNET Computer Solutions. All rights reserved.
// </copyright>
// <summary>
//   The controller extensions class to allow access resuming results from controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZNetCS.AspNetCore.ResumingFileResults.Extensions
{
    #region Usings

    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using Microsoft.AspNetCore.Mvc;

    #endregion

    /// <summary>
    /// The controller extensions class to allow access resuming results from controller.
    /// </summary>
    public static class ControllerExtensions
    {
        #region Public Methods

        /// <summary>
        /// Returns a file with the specified <paramref name="fileContents"/> as content and the
        /// specified <paramref name="contentType"/> as the Content-Type.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="fileContents">
        /// The file contents.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingFileContentResult"/> for the response.
        /// </returns>
        public static ResumingFileContentResult ResumingFile(this ControllerBase controller, byte[] fileContents, string contentType)
        {
            return ResumingFile(controller, fileContents, contentType, fileDownloadName: null);
        }

        /// <summary>
        /// Returns a file with the specified <paramref name="fileContents"/> as content, the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="fileContents">
        /// The file contents.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingFileContentResult"/> for the response.
        /// </returns>
        public static ResumingFileContentResult ResumingFile(this ControllerBase controller, byte[] fileContents, string contentType, string fileDownloadName)
        {
            return ResumingFile(controller, fileContents, contentType, fileDownloadName, etag: null);
        }

        /// <summary>
        /// Returns a file with the specified <paramref name="fileContents"/> as content, the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name and the
        /// specified <paramref name="etag"/> as ETag header.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="fileContents">
        /// The file contents.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <param name="etag">
        /// The Etag header of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingFileContentResult"/> for the response.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "ETag is proper word here")]
        public static ResumingFileContentResult ResumingFile(
            this ControllerBase controller,
            byte[] fileContents,
            string contentType,
            string fileDownloadName,
            string etag)
        {
            return new ResumingFileContentResult(fileContents, contentType, etag) { FileDownloadName = fileDownloadName };
        }

        /// <summary>
        /// Returns a file in the specified <paramref name="fileStream"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="fileStream">
        /// The <see cref="Stream"/> with the contents of the file.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingFileStreamResult"/> for the response.
        /// </returns>
        public static ResumingFileStreamResult ResumingFile(this ControllerBase controller, Stream fileStream, string contentType)
        {
            return ResumingFile(controller, fileStream, contentType, fileDownloadName: null);
        }

        /// <summary>
        /// Returns a file in the specified <paramref name="fileStream"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="fileStream">
        /// The <see cref="Stream"/> with the contents of the file.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingFileStreamResult"/> for the response.
        /// </returns>
        public static ResumingFileStreamResult ResumingFile(this ControllerBase controller, Stream fileStream, string contentType, string fileDownloadName)
        {
            return ResumingFile(controller, fileStream, contentType, fileDownloadName, etag: null);
        }

        /// <summary>
        /// Returns a file in the specified <paramref name="fileStream"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name and the
        /// specified <paramref name="etag"/> as ETag header.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="fileStream">
        /// The <see cref="Stream"/> with the contents of the file.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <param name="etag">
        /// The Etag header of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingFileStreamResult"/> for the response.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "ETag is proper word here")]
        public static ResumingFileStreamResult ResumingFile(this ControllerBase controller, Stream fileStream, string contentType, string fileDownloadName, string etag)
        {
            return new ResumingFileStreamResult(fileStream, contentType, etag) { FileDownloadName = fileDownloadName };
        }

        /// <summary>
        /// Returns the file specified by <paramref name="virtualPath"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="virtualPath">
        /// The virtual path of the file to be returned.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingVirtualFileResult"/> for the response.
        /// </returns>
        public static ResumingVirtualFileResult ResumingFile(this ControllerBase controller, string virtualPath, string contentType)
        {
            return ResumingFile(controller, virtualPath, contentType, fileDownloadName: null);
        }

        /// <summary>
        /// Returns the file specified by <paramref name="virtualPath"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="virtualPath">
        /// The virtual path of the file to be returned.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingVirtualFileResult"/> for the response.
        /// </returns>
        public static ResumingVirtualFileResult ResumingFile(this ControllerBase controller, string virtualPath, string contentType, string fileDownloadName)
        {
            return ResumingFile(controller, virtualPath, contentType, fileDownloadName, etag: null);
        }

        /// <summary>
        /// Returns the file specified by <paramref name="virtualPath"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name and the
        /// specified <paramref name="etag"/> as ETag header.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="virtualPath">
        /// The virtual path of the file to be returned.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <param name="etag">
        /// The Etag header of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingVirtualFileResult"/> for the response.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "ETag is proper word here")]
        public static ResumingVirtualFileResult ResumingFile(this ControllerBase controller, string virtualPath, string contentType, string fileDownloadName, string etag)
        {
            return new ResumingVirtualFileResult(virtualPath, contentType, etag) { FileDownloadName = fileDownloadName };
        }

        /// <summary>
        /// Returns the file specified by <paramref name="physicalPath"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="physicalPath">
        /// The physical path of the file to be returned.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingPhysicalFileResult"/> for the response.
        /// </returns>
        public static ResumingPhysicalFileResult ResumingPhysicalFile(this ControllerBase controller, string physicalPath, string contentType)
        {
            return ResumingPhysicalFile(controller, physicalPath, contentType, fileDownloadName: null, etag: null);
        }

        /// <summary>
        /// Returns the file specified by <paramref name="physicalPath"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="physicalPath">
        /// The physical path of the file to be returned.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingPhysicalFileResult"/> for the response.
        /// </returns>
        public static ResumingPhysicalFileResult ResumingPhysicalFile(this ControllerBase controller, string physicalPath, string contentType, string fileDownloadName)
        {
            return ResumingPhysicalFile(controller, physicalPath, contentType, fileDownloadName, etag: null);
        }

        /// <summary>
        /// Returns the file specified by <paramref name="physicalPath"/> with the
        /// specified <paramref name="contentType"/> as the Content-Type and the
        /// specified <paramref name="fileDownloadName"/> as the suggested file name and the
        /// specified <paramref name="etag"/> as ETag header.
        /// </summary>
        /// <param name="controller">
        /// The controller to which extension will be applied.
        /// </param>
        /// <param name="physicalPath">
        /// The physical path of the file to be returned.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type of the file.
        /// </param>
        /// <param name="fileDownloadName">
        /// The suggested file name.
        /// </param>
        /// <param name="etag">
        /// The Etag header of the file.
        /// </param>
        /// <returns>
        /// The created <see cref="ResumingPhysicalFileResult"/> for the response.
        /// </returns>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "ETag is proper word here")]
        public static ResumingPhysicalFileResult ResumingPhysicalFile(
            this ControllerBase controller,
            string physicalPath,
            string contentType,
            string fileDownloadName,
            string etag)
        {
            return new ResumingPhysicalFileResult(physicalPath, contentType, etag) { FileDownloadName = fileDownloadName };
        }

        #endregion
    }
}