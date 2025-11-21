---
title: VbaMakro
type: docs
weight: 150
url: /de/net/examples/elements/vba-macro/
keywords:
- vba-Makro-Beispiel
- vba-Makro hinzufügen
- vba-Makro abrufen
- vba-Makro entfernen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit VBA-Makros in C# mit Aspose.Slides: Projekte und Module hinzufügen oder bearbeiten, Makros signieren oder entfernen und Präsentationen in PPT, PPTX und ODP speichern."
---

Zeigt, wie VBA-Makros mit **Aspose.Slides for .NET** hinzugefügt, abgerufen und entfernt werden.

## VBA-Makro hinzufügen

Erstellen Sie eine Präsentation mit einem VBA-Projekt und einem einfachen Makro-Modul.
```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```


## Zugriff auf ein VBA-Makro

Rufen Sie das erste Modul aus dem VBA-Projekt ab.
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


## VBA-Makro entfernen

Löschen Sie ein Modul aus dem VBA-Projekt.
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
