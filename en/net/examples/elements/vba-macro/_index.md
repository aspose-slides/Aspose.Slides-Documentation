---
title: VBA Macro
type: docs
weight: 150
url: /net/examples/elements/vbamacro/
keywords:
- code example
- VBA
- macro
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automate presentations with Aspose.Slides for .NET: create, run, import, and secure VBA macros in PPT, PPTX, and ODP using clear C# examples."
---

This article demonstrates how to add, access, and remove VBA macros using **Aspose.Slides for .NET**.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

```csharp
static void AccessVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = presentation.VbaProject.Modules[0];
}
```

## **Remove a VBA Macro**

Delete a module from the VBA project.

```csharp
static void RemoveVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    presentation.VbaProject.Modules.Remove(module);
}
```
