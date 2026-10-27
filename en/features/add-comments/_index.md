---
title: Add slide comments and replies
description: Add comments and replies to presentation slides.
type: docs
url: /features/add-comments/
weight: 1440
feature_id: add-comments
feature_group: metadata
translationKey: slides-feature-add-comments
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-comments/
---

## **Overview**

Write review comments into a presentation and associate them with an author and slide. Use replies to keep related feedback together. The comment content stays in the presentation so it can be read again or included in suitable review output.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Add a legacy comment and a reply under a legacy-only author. Positions are measured in slide points; the parent reference keeps the reply connected.

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
var reply = author.Comments.AddComment("Updated", presentation.Slides[0], new PointF(100, 120), new DateTime(2026, 1, 16));
reply.ParentComment = comment;
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can one author hold both legacy and modern comments?**

Keep the two comment kinds separate for a given author. Mixing them under one author can make the saved presentation fail to reopen.

### **How do I position a comment on a slide?**

Supply its position in slide points when adding it. Adjust the coordinates to the relevant slide area.

### **How can I add a reply to an existing comment?**

Create another comment and set its parent to the existing comment, keeping author comment kinds consistent.

## **Guides**

- [Manage Presentation Comments in .NET](/slides/net/presentation-comments/)

Related feature: [Work with modern comments](/slides/features/modern-comments/).
