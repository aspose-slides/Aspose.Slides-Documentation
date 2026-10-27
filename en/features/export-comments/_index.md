---
title: Render slide comments
description: Show slide comments in the rendered output.
type: docs
url: /features/export-comments/
weight: 1210
feature_id: export-comments
feature_group: rendering
translationKey: slides-feature-export-comments
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-comments/
---

## **Overview**

Include comments when exporting or rendering a presentation for review. Set their position and the size or appearance of the comments area, and combine them with notes when appropriate. The output can show the comment text together with its author information.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create a legacy review comment and export it in a 220-point comments area to the right of the slide. The comment becomes part of the rendered page.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var author = presentation.CommentAuthors.AddAuthor("Demo reviewer", "DR");
var comment = author.Comments.AddComment("Review this slide", presentation.Slides[0], new PointF(100, 100), new DateTime(2026, 1, 15));
var layout = new NotesCommentsLayoutingOptions { CommentsPosition = CommentsPositions.Right, CommentsAreaWidth = 220 };
var options = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("output.pdf", SaveFormat.Pdf, options);
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can comments be placed beside the slide?**

Yes. Use the comments-layout options to choose an arrangement such as a comments area on the right.

### **Can comments be omitted from the export?**

Yes. Select no comments in the comments-layout settings when the review text should not be rendered.

### **Do rendered comment visuals become editable PDF review comments?**

No. This renders the presentation comments as page content; it does not convert them into editable PDF review annotations.

## **Guides**

- [Manage Presentation Comments in .NET](/slides/net/presentation-comments/)

Related feature: [Read slide comments](/slides/features/read-comments/).
