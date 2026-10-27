---
title: Work with modern comments
description: Read and write modern threaded comments.
type: docs
url: /features/modern-comments/
weight: 1450
feature_id: modern-comments
feature_group: metadata
translationKey: slides-feature-modern-comments
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-comments/
---

## **Overview**

Work with modern presentation comments, including replies, status and anchors to shapes or text selections. This gives an application more review context than a standalone text note. Use the modern comment model consistently when building a new review thread.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create a thread using only modern comments for this author. Save and reopen the deck to retain the parent relationship. A null anchor associates this example with the slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var author = presentation.CommentAuthors.AddAuthor("Demo modern reviewer", "DM");
var comment = author.Comments.AddModernComment("Modern review", presentation.Slides[0], null, new PointF(100, 100), new DateTime(2026, 1, 15));
var reply = author.Comments.AddModernComment("Modern reply", presentation.Slides[0], null, new PointF(100, 120), new DateTime(2026, 1, 16));
reply.ParentComment = comment;
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Can a reply keep its parent relationship?**

Yes. The modern comment structure can retain the parent comment so the thread remains connected after saving.

### **How are modern comments different from legacy comments?**

Modern comments provide a richer review model with threading, status and shape or text anchors. Use the modern model consistently for a new thread.

### **How should I handle authors when a deck contains different comment kinds?**

Use separate authors for different comment kinds. Mixing legacy and modern comments under the same author can prevent the saved deck from reopening.

## **Guides**

- [Manage Presentation Comments in .NET](/slides/net/presentation-comments/)

Related feature: [Add slide comments and replies](/slides/features/add-comments/).
