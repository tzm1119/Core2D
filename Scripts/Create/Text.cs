
var e = Context.Editor;
var p = Context.Editor.Project;
var c = p.CurrentContainer;
var s = p.CurrentStyleLibrary.CurrentStyle;
var text = XText.Create(30, 30, 90, 60, s, p.Options.PointShape, "Text");

e.AddWithHistory(text);
c.CurrentLayer.Invalidate();
