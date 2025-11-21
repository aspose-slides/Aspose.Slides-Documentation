---
title: Layout-Folie
type: docs
weight: 20
url: /de/net/examples/elements/layout-slide/
keywords:
- Beispiel für Layout-Folien
- Layout-Folie hinzufügen
- Zugriff auf Layout-Folie
- Layout-Folie entfernen
- Unbenutzte Layout-Folie
- Layout-Folie duplizieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie C# zur Verwaltung von Layout-Folien mit Aspose.Slides: Erstellen, Anwenden, Duplizieren, Umbenennen und Anpassen von Platzhaltern und Designs in Präsentationen für PPT, PPTX und ODP."
---

Dieser Artikel demonstriert, wie man mit **Layout Slides** in Aspose.Slides für .NET arbeitet. Ein Layout‑Slide definiert das Design und die Formatierung, die von normalen Folien geerbt werden. Sie können Layout‑Slides hinzufügen, darauf zugreifen, sie klonen und entfernen sowie ungenutzte Slides bereinigen, um die Präsentationsgröße zu reduzieren.

## Layout‑Slide hinzufügen

Sie können ein benutzerdefiniertes Layout‑Slide erstellen, um wiederverwendbare Formatierungen zu definieren. Beispielsweise können Sie ein Textfeld hinzufügen, das auf allen Folien, die dieses Layout verwenden, angezeigt wird.

```csharp
static void Add_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Create a layout slide with a blank layout type and a custom name
    var layoutSlide = pres.LayoutSlides.Add(pres.Masters[0], SlideLayoutType.Blank, "Main layout");

    // Add a text box to the layout slide
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Add two slides using this layout; both will inherit the text from the layout
    pres.Slides.AddEmptySlide(layoutSlide);
    pres.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Tipp 1:** Layout‑Slides fungieren als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und sie über viele Folien hinweg wiederverwenden.

> 💡 **Tipp 2:** Wenn Sie Formen oder Text zu einem Layout‑Slide hinzufügen, zeigen alle darauf basierenden Folien diesen gemeinsamen Inhalt automatisch an.

> Das untenstehende Bildschirmfoto zeigt zwei Folien, die jeweils ein Textfeld vom gleichen Layout‑Slide erben.

![Slides Inheriting Layout Content](layout-slide-result.png)

## Zugriff auf ein Layout‑Slide

Layout‑Slides können über den Index oder über den Layout‑Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) zugegriffen werden.

```csharp
static void Access_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Access by index
    var firstLayoutSlide = pres.LayoutSlides[0];
    
    // Access by layout type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## Layout‑Slide entfernen

Sie können ein bestimmtes Layout‑Slide entfernen, wenn es nicht mehr benötigt wird.

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Get a layout slide by type and remove it
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## Unbenutzte Layout‑Slides entfernen

Um die Präsentationsgröße zu reduzieren, möchten Sie möglicherweise Layout‑Slides entfernen, die von keiner normalen Folie verwendet werden.

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide
    pres.LayoutSlides.RemoveUnused();
}
```

## Layout‑Slide duplizieren

Sie können ein Layout‑Slide mithilfe der Methode `AddClone` duplizieren.

```csharp
static void Clone_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Get an existing layout slide by type
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Clone the layout slide to the end of the layout slide collection
    var clonedLayoutSlide = pres.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Zusammenfassung:** Layout‑Slides sind leistungsstarke Werkzeuge zur Verwaltung konsistenter Formatierungen über Folien hinweg. Aspose.Slides bietet vollständige Kontrolle über das Erstellen, Verwalten und Optimieren von Layout‑Slides.