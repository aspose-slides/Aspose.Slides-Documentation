---
title: VbaMakro
type: docs
weight: 150
url: /de/net/examples/elements/vba-macro/
keywords:
- vba-makro-beispiel
- vba-makro hinzufügen
- vba-makro zugreifen
- vba-makro entfernen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Arbeiten Sie mit VBA-Makros in C# unter Verwendung von Aspose.Slides: Fügen Sie Projekte und Module hinzu oder bearbeiten Sie sie, signieren oder entfernen Sie Makros und speichern Sie Präsentationen in PPT, PPTX und ODP."
---

Veranschaulicht, wie man VBA-Makros mit **Aspose.Slides for .NET** hinzufügt, darauf zugreift und sie entfernt.

## **Ein VBA-Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA-Projekt und einem einfachen Makromodul.
```csharp
static void Add_Vba_Macro()
{
    using var pres = new Presentation();
    pres.VbaProject = new VbaProject();

    var module = pres.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```


## **Zugriff auf ein VBA-Makro**

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


## **Ein VBA-Makro entfernen**

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
