---
title: VBA-macro
type: docs
weight: 150
url: /nl/net/examples/elements/vba-macro/
keywords:
- VBA-macro
- VBA-macro toevoegen
- VBA-macro benaderen
- VBA-macro verwijderen
- codevoorbeeld
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Automatiseer presentaties met Aspose.Slides voor .NET: maak, voer uit, importeer en beveilig VBA-macro's in PPT, PPTX en ODP met duidelijke C#-voorbeelden."
---
Dit artikel toont hoe u VBA-macro's kunt toevoegen, benaderen en verwijderen met **Aspose.Slides for .NET**.

## **Voeg een VBA-macro toe**

Maak een presentatie met een VBA-project en een eenvoudige macro-module.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Toegang tot een VBA-macro**

Haal de eerste module op uit het VBA-project.

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

## **Verwijder een VBA-macro**

Verwijder een module uit het VBA-project.

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