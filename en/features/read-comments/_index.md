---
title: Read slide comments
description: Read slide comments, replies and author information.
type: docs
url: /features/read-comments/
weight: 1430
feature_id: read-comments
feature_group: metadata
translationKey: slides-feature-read-comments
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-comments/
---

## **Overview**

Inspect comments stored in a presentation to collect review feedback or display it in another application. The library can read legacy and modern comment structures, including replies. Keep the comment's slide and author context when presenting its text elsewhere.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Generate one legacy comment and reopen the deck. Enumerate comments through their author and retain the slide association when displaying the text.

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
presentation.Save("source.pptx", SaveFormat.Pptx);
using var opened = new Presentation("source.pptx");
foreach (var storedAuthor in opened.CommentAuthors)
{
    foreach (var storedComment in storedAuthor.Comments)
        Console.WriteLine(storedAuthor.Name + ": slide " + storedComment.Slide.SlideNumber + ": " + storedComment.Text);
}
```

## **FAQ**

### **Can I include comments in rendered review output?**

Yes. Use the comments-layout options when exporting the presentation so readers can see the feedback with the slides.

### **How do I locate the slide belonging to a comment?**

Read its slide reference and preserve that context alongside the author and comment text.

### **Can I read replies as part of a comment thread?**

Yes. Read the parent relationship when presenting replies; flattening only the text loses the thread.

## **Guides**

- [Manage Presentation Comments in .NET](/slides/net/presentation-comments/)

Related feature: [Render slide comments](/slides/features/export-comments/).
