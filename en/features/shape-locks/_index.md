---
title: Lock shapes against editing
description: Set editing locks for shapes and groups.
type: docs
url: /features/shape-locks/
weight: 1400
feature_id: shape-locks
feature_group: security
translationKey: slides-feature-shape-locks
feature_catalogue_version: 3
feature_guides:
- /slides/net/applying-protection-to-presentation/
---

## **Overview**

Apply shape locks for actions such as moving, resizing, rotating or editing text. Groups can also carry a lock against ungrouping. Use these settings to communicate editing restrictions for templates or presentation elements that should stay in place.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Keep a rectangle in place by setting separate movement and resizing locks. The slide text remains editable because no text-editing lock is set.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
shape.AutoShapeLock.PositionLocked = true;
shape.AutoShapeLock.SizeLocked = true;
presentation.Save("source.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Do shape locks encrypt the document?**

No. They are editing settings stored with the shapes. Use presentation-level protection when the file needs password-based access control.

### **Are movement, resizing and rotation locks configured independently?**

Yes. Movement, resizing and rotation have separate lock flags.

### **Can I restrict movement while allowing text editing?**

Yes. Set the position lock without setting the text-editing lock. The consuming editor determines how it presents these restrictions.

## **Guides**

- [Restrict Presentation Edits with Shape Locks in .NET](/slides/net/applying-protection-to-presentation/)

Related feature: [Protect a presentation with a password](/slides/features/presentation-password/).
