---
title: VBA-Makro
type: docs
weight: 150
url: /de/net/examples/elements/vba-macro/
keywords:
- VBA-Makro
- VBA-Makro hinzufügen
- Zugriff auf VBA-Makro
- VBA-Makro entfernen
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Automatisieren Sie Präsentationen mit Aspose.Slides für .NET: Erstellen, ausführen, importieren und sichern Sie VBA-Makros in PPT, PPTX und ODP anhand klarer C#-Beispiele."
---
Dieser Artikel demonstriert, wie man VBA-Makros mit **Aspose.Slides for .NET** hinzufügt, darauf zugreift und entfernt.

## **VBA-Makro hinzufügen**

Erstellen Sie eine Präsentation mit einem VBA-Projekt und einem einfachen Makro-Modul.

```csharp
static void AddVbaMacro()
{
    using var presentation = new Presentation();
    presentation.VbaProject = new VbaProject();

    var module = presentation.VbaProject.Modules.AddEmptyModule("Module");
    module.SourceCode = "Sub Test()\n MsgBox \"Hi\" \nEnd Sub";
}
```

## **Zugriff auf ein VBA-Makro**

Rufen Sie das erste Modul aus dem VBA-Projekt ab.

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

## **VBA-Makro entfernen**

Löschen Sie ein Modul aus dem VBA-Projekt.

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