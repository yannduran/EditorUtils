﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Operations;
using Microsoft.VisualStudio.Text.Outlining;
using Microsoft.VisualStudio.Text.Projection;
using Microsoft.VisualStudio.Utilities;

namespace EditorUtils.UnitTest
{
    public abstract class EditorHostTest
    {
        [ThreadStatic]
        private static EditorHost EditorHostCache;

        private readonly EditorHost _editorHost;

        public EditorHost EditorHost
        {
            get { return _editorHost; }
        }

        public ISmartIndentationService SmartIndentationService
        {
            get { return _editorHost.SmartIndentationService; }
        }

        public ITextBufferFactoryService TextBufferFactoryService
        {
            get { return _editorHost.TextBufferFactoryService; }
        }

        public ITextEditorFactoryService TextEditorFactoryService
        {
            get { return _editorHost.TextEditorFactoryService; }
        }

        public IProjectionBufferFactoryService ProjectionBufferFactoryService
        {
            get { return _editorHost.ProjectionBufferFactoryService; }
        }

        public IEditorOperationsFactoryService EditorOperationsFactoryService
        {
            get { return _editorHost.EditorOperationsFactoryService; }
        }

        public IEditorOptionsFactoryService EditorOptionsFactoryService
        {
            get { return _editorHost.EditorOptionsFactoryService; }
        }

        public ITextSearchService TextSearchService
        {
            get { return _editorHost.TextSearchService; }
        }

        public ITextBufferUndoManagerProvider TextBufferUndoManagerProvider
        {
            get { return _editorHost.TextBufferUndoManagerProvider; }
        }

        public IOutliningManagerService OutliningManagerService
        {
            get { return _editorHost.OutliningManagerService; }
        }

        public IContentTypeRegistryService ContentTypeRegistryService
        {
            get { return _editorHost.ContentTypeRegistryService; }
        }

        public IProtectedOperations ProtectedOperations
        {
            get { return _editorHost.ProtectedOperations; }
        }

        public IBasicUndoHistoryRegistry BasicUndoHistoryRegistry
        {
            get { return _editorHost.BasicUndoHistoryRegistry; }
        }

        public EditorHostTest()
        {
            _editorHost = GetOrCreateEditorHost();
        }

        private EditorHost GetOrCreateEditorHost()
        {
            if (EditorHostCache != null)
            {
                return EditorHostCache;
            }

            var editorHostFactory = new EditorHostFactory();
            EditorHostCache = editorHostFactory.CreateEditorHost();
            return EditorHostCache;
        }

        public ITextBuffer CreateTextBuffer(params string[] lines)
        {
            return _editorHost.CreateTextBuffer(lines);
        }

        public ITextBuffer CreateTextBuffer(IContentType contentType, params string[] lines)
        {
            return _editorHost.CreateTextBuffer(contentType, lines);
        }

        public IProjectionBuffer CreateProjectionBuffer(params SnapshotSpan[] spans)
        {
            return _editorHost.CreateProjectionBuffer(spans);
        }

        public IWpfTextView CreateTextView(params string[] lines)
        {
            return _editorHost.CreateTextView(lines);
        }

        public IWpfTextView CreateTextView(IContentType contentType, params string[] lines)
        {
            return _editorHost.CreateTextView(contentType, lines);
        }

        /// <summary>
        /// Get or create a content type of the specified name with the specified base content type
        /// </summary>
        public IContentType GetOrCreateContentType(string type, string baseType)
        {
            return _editorHost.GetOrCreateContentType(type, baseType);
        }
    }
}
