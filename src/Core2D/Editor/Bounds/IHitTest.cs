﻿// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
using System;
using System.Collections.Generic;
using Core2D.Shapes;
using Spatial;

namespace Core2D.Editor.Bounds
{
    public interface IHitTest
    {
        IDictionary<Type, IBounds> Registered { get; set; }
        void Register(IBounds hitTest);
        void Register(IEnumerable<IBounds> hitTests);
        IPointShape TryToGetPoint(IBaseShape shape, Point2 target, double radius);
        IPointShape TryToGetPoint(IEnumerable<IBaseShape> shapes, Point2 target, double radius);
        bool Contains(IBaseShape shape, Point2 target, double radius);
        bool Overlaps(IBaseShape shape, Rect2 target, double radius);
        IBaseShape TryToGetShape(IEnumerable<IBaseShape> shapes, Point2 target, double radius);
        HashSet<IBaseShape> TryToGetShapes(IEnumerable<IBaseShape> shapes, Rect2 target, double radius);
    }
}
