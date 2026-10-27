---
title: Read VBA macros
description: Read VBA project details and macro source stored in a presentation.
type: docs
url: /features/read-vba/
weight: 1370
feature_id: read-vba
feature_group: security
translationKey: slides-feature-read-vba
feature_catalogue_version: 3
feature_guides:
- /slides/net/presentation-via-vba/
---

## **Overview**

Inspect the VBA project in a macro-enabled presentation. Read module source, project information and references for tasks such as inventorying or reviewing a document's macros. This accesses the stored project; it does not run the macro code.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Create a macro-enabled fixture containing only an empty procedure and a comment, then read its stored source. No Office application or macro is executed.

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
    foreach (var storedModule in opened.VbaProject.Modules)
        Console.WriteLine(storedModule.Name + ": " + storedModule.SourceCode);
}
```

## **FAQ**

### **Do macros execute when I read their source?**

Reading VBA data through this workflow does not execute it. The library exposes the project and module content for your application to inspect.

### **How can I distinguish module names from their VBA source text?**

Each module has a name and separate source text. Enumerate modules to read both.

### **How do I identify a presentation with no VBA project?**

Check whether the loaded deck has a VBA project before accessing its modules.

## **Guides**

- [Manage VBA Projects in Presentations in .NET](/slides/net/presentation-via-vba/)

Related feature: [Remove VBA macros](/slides/features/remove-vba/).
