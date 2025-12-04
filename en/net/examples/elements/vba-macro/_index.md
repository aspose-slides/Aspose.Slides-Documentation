---
title: VbaMacro
type: docs
weight: 150
url: /net/examples/elements/vba-macro/
keywords:
- vba macro example
- add vba macro
- access vba macro
- remove vba macro
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Work with VBA macros in C# using Aspose.Slides: add or edit projects and modules, sign or remove macros, and save presentations in PPT, PPTX and ODP."
---

Illustrates how to add, access, and remove VBA macros using **Aspose.Slides for .NET**.

## **Add a VBA Macro**

Create a presentation with a VBA project and a simple macro module.

```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Access a VBA Macro**

Retrieve the first module from the VBA project.

```csharp
static void Access_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    var firstModule = pres.VbaProject.Modules[0];
}
```

## **Remove a VBA Macro**

Delete a module from the VBA project.

```csharp
static void Remove_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";

    pres.VbaProject.Modules.Remove(module);
}
```
