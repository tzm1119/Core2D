﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using Core2D.Containers;

namespace Core2D.Renderer.Presenters
{
    /// <summary>
    /// Template container presenter.
    /// </summary>
    public class TemplatePresenter : IContainerPresenter
    {
        /// <inheritdoc/>
        public void Render(object dc, IShapeRenderer renderer, IPageContainer container, double dx, double dy)
        {
            renderer.Fill(dc, dx, dy, container.Width, container.Height, container.Background);

            if (container.Template != null)
            {
                renderer.Draw(dc, container.Template, dx, dy);
            }
        }
    }
}
