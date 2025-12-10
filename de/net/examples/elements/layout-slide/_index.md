---
title: Layout-Folie
type: docs
weight: 20
url: /de/net/examples/elements/layout-slide/
keywords:
- Beispiel für Layout-Folie
- Layout-Folie hinzufügen
- Layout-Folie zugreifen
- Layout-Folie entfernen
- Unbenutzte Layout-Folie
- Layout-Folie duplizieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwenden Sie C#, um Layout-Folien mit Aspose.Slides zu verwalten: Erstellen, Anwenden, Duplizieren, Umbenennen und Anpassen von Platzhaltern und Designs in Präsentationen für PPT, PPTX und ODP."
---

Dieser Artikel zeigt, wie man mit **Layout‑Folien** in Aspose.Slides für .NET arbeitet. Eine Layout‑Folie definiert das Design und die Formatierung, die von normalen Folien übernommen werden. Sie können Layout‑Folien hinzufügen, darauf zugreifen, duplizieren und entfernen sowie ungenutzte Folien bereinigen, um die Präsentationsgröße zu reduzieren.

## **Eine Layout‑Folie hinzufügen**

Sie können eine benutzerdefinierte Layout‑Folie erstellen, um wiederverwendbare Formatierungen zu definieren. Zum Beispiel können Sie ein Textfeld hinzufügen, das auf allen Folien mit diesem Layout erscheint.

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
````

> 💡 **Tipp 1:** Layout‑Folien fungieren als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und sie auf vielen Folien wiederverwenden.

> 💡 **Tipp 2:** Wenn Sie Formen oder Text zu einer Layout‑Folie hinzufügen, wird dieser gemeinsame Inhalt automatisch auf allen darauf basierenden Folien angezeigt.  
> Das untenstehende Bildschirmfoto zeigt zwei Folien, die jeweils ein Textfeld von derselben Layout‑Folie erben.

![Slides Inheriting Layout Content](layout-slide-result.png)


## **Auf eine Layout‑Folie zugreifen**

Layout‑Folien können über den Index oder den Layout‑Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) abgerufen werden.

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

## **Eine Layout‑Folie entfernen**

Sie können eine bestimmte Layout‑Folie entfernen, wenn sie nicht mehr benötigt wird.

```csharp
static void Remove_Layout_Slide()
{
    using var pres = new Presentation();
    
    // Get a layout slide by type and remove it
    var blankLayoutSlide = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);
    pres.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Unbenutzte Layout‑Folien entfernen**

Um die Präsentationsgröße zu reduzieren, sollten Sie Layout‑Folien entfernen, die von keiner normalen Folie verwendet werden.

```csharp
static void RemoveUnused_Layout_Slides()
{
    using var pres = new Presentation();
    
    // Automatically removes all layout slides not referenced by any slide
    pres.LayoutSlides.RemoveUnused();
}
```

## **Eine Layout‑Folie duplizieren**

Sie können eine Layout‑Folie mit der Methode `AddClone` duplizieren.

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

> ✅ **Zusammenfassung:** Layout‑Folien sind leistungsstarke Werkzeuge zur Verwaltung konsistenter Formatierungen über alle Folien hinweg. Aspose.Slides bietet vollständige Kontrolle über das Erstellen, Verwalten und Optimieren von Layout‑Folien.