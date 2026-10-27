---
title: Add and edit VBA macros
description: Add VBA projects or update macro source in a presentation.
type: docs
url: /features/edit-vba/
weight: 1380
feature_id: edit-vba
feature_group: security
translationKey: slides-feature-edit-vba
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-via-vba/
---

## **Overview**

Create a VBA project, add modules and set their source, or edit a project already stored in a presentation. Save using an appropriate macro-enabled format to keep that content. The application that later opens the file controls whether its macros may run.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create a benign module, reopen its macro-enabled container and replace a comment in its source. Save as PPTM to retain the project; this does not execute the procedure.

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
if (opened.VbaProject != null)
{
    var storedModule = opened.VbaProject.Modules[0];
    storedModule.SourceCode = storedModule.SourceCode.Replace("Harmless source marker", "Revised source marker");
    opened.Save("edited.pptm", SaveFormat.Pptm);
}
```

## **FAQ**

### **Does this feature execute the VBA code?**

No. It writes and edits the stored VBA project. Execution and macro security belong to the presentation application that opens it.

### **Which output format should retain the VBA project?**

Use a macro-enabled format such as PPTM when saving a deck that should retain its VBA project.

### **Can I add a new module instead of replacing an existing module?**

Yes. Add an empty module to the project, assign its name and source text, then save a macro-enabled output.

## **Guides**

- [Manage VBA Projects in Presentations in .NET](/slides/net/presentation-via-vba/)

Related feature: [Read VBA macros](/slides/features/read-vba/).
