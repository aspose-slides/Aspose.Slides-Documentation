---
title: Hyperlink
type: docs
weight: 130
url: /net/examples/elements/hyperlink/
keywords:
- hyperlink example
- add hyperlink
- access hyperlink
- remove hyperlink
- update hyperlink
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Add, edit, and remove hyperlinks in C# with Aspose.Slides: link text, shapes, slides, URLs and email; set targets and actions for PPT, PPTX and ODP."
---

Demonstrates adding, accessing, removing, and updating hyperlinks on shapes using **Aspose.Slides for .NET**.

## Add a Hyperlink

Create a rectangle shape with a hyperlink pointing to an external website.

```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## Access a Hyperlink

Read hyperlink information from a shape's text portion.

```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## Remove a Hyperlink

Clear the hyperlink from a shape's text.

```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```

## Update a Hyperlink

Change the target of an existing hyperlink. Use `HyperlinkManager` to modify text that already contains a hyperlink, which mimics how PowerPoint updates hyperlinks safely.

```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Changing a hyperlink inside existing text should be done via
    // HyperlinkManager rather than setting the property directly.
    // This mimics how PowerPoint safely updates hyperlinks.
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
