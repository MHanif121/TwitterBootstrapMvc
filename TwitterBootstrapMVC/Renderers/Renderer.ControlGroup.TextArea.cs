﻿using System.Web.Mvc;
using TwitterBootstrapMVC.ControlModels;
using TwitterBootstrapMVC.Controls;
using TwitterBootstrapMVC.TypeExtensions;

namespace TwitterBootstrapMVC.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderControlGroupTextArea(HtmlHelper html, BootstrapTextAreaModel inputModel, BootstrapLabelModel labelModel)
        {
            var input = Renderer.RenderTextArea(html, inputModel);

            string label = Renderer.RenderLabel(html, labelModel ?? new BootstrapLabelModel
            {
                htmlFieldName = inputModel.htmlFieldName,
                metadata = inputModel.metadata,
                htmlAttributes = new { @class = "control-label" }.ToDictionary()
            });

            bool fieldIsValid = true;
            if(inputModel != null) fieldIsValid = html.ViewData.ModelState.IsValidField(inputModel.htmlFieldName);
            return new BootstrapControlGroup(input, label, ControlGroupType.textboxLike, fieldIsValid).ToHtmlString();
        }
    }
}
