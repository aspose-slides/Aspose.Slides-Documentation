---
title: Remove VBA macros
description: Remove the VBA project from a presentation.
type: docs
url: /features/remove-vba/
weight: 1390
feature_id: remove-vba
feature_group: security
translationKey: slides-feature-remove-vba
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-via-vba/
---

## **Overview**

Remove stored VBA content when preparing a presentation that should no longer contain its macro project. Save the result as a new file to keep the original available if needed. The slide content can remain in the output while the VBA project is removed.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Build a benign macro-enabled input, remove its stored VBA project and save a new macro-free PPTX. Its slide is retained and no macro is executed.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
presentation.VbaProject = new VbaProject();
var module = presentation.VbaProject.Modules.AddEmptyModule("DemoModule");
module.SourceCode = "Sub Demo()\n' Harmless source marker\nEnd Sub";
presentation.Save("input.pptm", SaveFormat.Pptm);
using var opened = new Presentation("input.pptm");
opened.VbaProject = null;
opened.Save("clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

### **Must I delete the slides to remove the macros?**

No. The VBA project is separate from the slide collection, so it can be removed while keeping the presentation content.

### **Can I save a macro-free PPTX copy of a macro-enabled input?**

Yes. Remove the VBA project and save to a new PPTX path, keeping the original macro-enabled file if needed.

### **How can I check that no VBA project remains after saving?**

Reopen the output and check that its VBA project is absent.

## **Guides**

- [Manage VBA Projects in Presentations in .NET](/slides/net/presentation-via-vba/)

Related feature: [Read VBA macros](/slides/features/read-vba/).
