﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResumingFileContentResult.cs" company="Marcin Smółka zNET Computer Solutions">
//   Copyright (c) Marcin Smółka zNET Computer Solutions. All rights reserved.
// </copyright>
// <summary>
//   The resuming file stream result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ZNetCS.AspNetCore.ResumingFileResults
{
    #region Usings

    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Net.Http.Headers;

    using ZNetCS.AspNetCore.ResumingFileResults.Infrastructure;

    #endregion

    /// <summary>
    /// The resuming file stream result.
    /// </summary>
    public class ResumingFileContentResult : ResumingFileResult
    {
        #region Fields

        /// <summary>
        /// The file contents.
        /// </summary>
        private byte[] fileContents;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResumingFileContentResult"/> class.
        /// </summary>
        /// <param name="fileContents">
        /// The bytes that represent the file contents.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type header of the response.
        /// </param>
        /// <param name="etag">
        /// The Etag header of the response.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "OK")]
        public ResumingFileContentResult(byte[] fileContents, string contentType, string etag = null)
            : this(fileContents, MediaTypeHeaderValue.Parse(contentType), !string.IsNullOrEmpty(etag) ? EntityTagHeaderValue.Parse(etag) : null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResumingFileContentResult"/> class.
        /// </summary>
        /// <param name="fileContents">
        /// The bytes that represent the file contents.
        /// </param>
        /// <param name="contentType">
        /// The Content-Type header of the response.
        /// </param>
        /// <param name="etag">
        /// The Etag header of the response.
        /// </param>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "OK")]
        public ResumingFileContentResult(byte[] fileContents, MediaTypeHeaderValue contentType, EntityTagHeaderValue etag = null) : base(contentType?.ToString(), etag)
        {
            if (fileContents == null)
            {
                throw new ArgumentNullException(nameof(fileContents));
            }

            this.FileContents = fileContents;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the file contents.
        /// </summary>
        public byte[] FileContents
        {
            get
            {
                return this.fileContents;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                this.fileContents = value;
            }
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override Task ExecuteResultAsync(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var executor = context.HttpContext.RequestServices.GetRequiredService<ResumingFileContentResultExecutor>();
            return executor.ExecuteAsync(context, this);
        }

        #endregion
    }
}