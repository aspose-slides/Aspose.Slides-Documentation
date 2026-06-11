---
title: VBA-makro
type: docs
weight: 150
url: /sv/net/examples/elements/vba-macro/
keywords:
- VBA-makro
- lägga till VBA-makro
- komma åt VBA-makro
- ta bort VBA-makro
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Automatisera presentationer med Aspose.Slides för .NET: skapa, köra, importera och skydda VBA-makron i PPT, PPTX och ODP med tydliga C#-exempel."
---
Den här artikeln visar hur man lägger till, får åtkomst till och tar bort VBA-makron med **Aspose.Slides for .NET**.

## **Lägg till ett VBA-makro**

Skapa en presentation med ett VBA-projekt och en enkel makromodul.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Få åtkomst till ett VBA-makro**

Hämta den första modulen från VBA-projektet.

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

## **Ta bort ett VBA-makro**

Ta bort en modul från VBA-projektet.

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