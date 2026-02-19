---
title: Layout-Folie
type: docs
weight: 20
url: /de/net/examples/elements/layout-slide/
keywords:
- Layout-Folie
- Layout-Folie hinzufügen
- Zugriff auf Layout-Folie
- Layout-Folie entfernen
- unbenutzte Layout-Folie
- Layout-Folie duplizieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Master-Layout-Folien in Aspose.Slides für .NET: Auswählen, Anwenden und Anpassen von Folien-Layouts, Platzhaltern und Master-Folien mit C#-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man mit **Layout Slides** in Aspose.Slides für .NET arbeitet. Ein Layout‑Slide definiert das Design und die Formatierung, die von normalen Slides übernommen werden. Sie können Layout‑Slides hinzufügen, darauf zugreifen, klonen und entfernen sowie ungenutzte Slides bereinigen, um die Präsentationsgröße zu reduzieren.

## **Layout‑Slide hinzufügen**

Sie können einen benutzerdefinierten Layout‑Slide erstellen, um wiederverwendbare Formatierung zu definieren. Beispielsweise könnten Sie ein Textfeld hinzufügen, das auf allen Slides, die dieses Layout verwenden, angezeigt wird.

```csharp
static void AddLayoutSlide()
{
    using var presentation = new Presentation();
    
    var masterSlide = presentation.Masters[0];

    // Erstelle einen Layout‑Slide mit einem leeren Layouttyp und einem benutzerdefinierten Namen.
    var layoutSlide = presentation.LayoutSlides.Add(masterSlide, SlideLayoutType.Blank, "Main layout");

    // Füge dem Layout‑Slide ein Textfeld hinzu.
    var layoutTextBox = layoutSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 75, y: 75, width: 150, height: 150);
    layoutTextBox.TextFrame.Text = "Layout Slide Text";

    // Füge zwei Folien mit diesem Layout hinzu; beide erben den Text vom Layout.
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
}
```

> 💡 **Hinweis 1:** Layout‑Slides fungieren als Vorlagen für einzelne Slides. Sie können gemeinsame Elemente einmal definieren und sie in vielen Slides wiederverwenden.
> 
> 💡 **Hinweis 2:** Wenn Sie Formen oder Text zu einem Layout‑Slide hinzufügen, wird dieser gemeinsame Inhalt automatisch auf allen Slides angezeigt, die auf diesem Layout basieren.
> Der Screenshot unten zeigt zwei Slides, die jeweils ein Textfeld aus demselben Layout‑Slide übernehmen.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Zugriff auf einen Layout‑Slide**

Layout‑Slides können über den Index oder nach Layout‑Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) zugegriffen werden.

```csharp
static void AccessLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Greife auf einen Layout‑Slide nach Index zu.
    var firstLayoutSlide = presentation.LayoutSlides[0];
    
    // Greife auf einen Layout‑Slide nach Typ zu.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
}
```

## **Layout‑Slide entfernen**

Sie können einen bestimmten Layout‑Slide entfernen, wenn er nicht mehr benötigt wird.

```csharp
static void RemoveLayoutSlide()
{
    using var presentation = new Presentation();
    
    // Hole einen Layout‑Slide nach Typ und entferne ihn.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Custom);
    presentation.LayoutSlides.Remove(blankLayoutSlide);
}
```

## **Unbenutzte Layout‑Slides entfernen**

Um die Präsentationsgröße zu reduzieren, können Sie Layout‑Slides entfernen, die von keinen normalen Slides verwendet werden.

```csharp
static void RemoveUnusedLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Entfernt automatisch alle Layout‑Slides, die von keiner Folie referenziert werden.
    presentation.LayoutSlides.RemoveUnused();
}
```

## **Layout‑Slide duplizieren**

Sie können einen Layout‑Slide mit der Methode `AddClone` duplizieren.

```csharp
static void CloneLayoutSlides()
{
    using var presentation = new Presentation();
    
    // Hole einen vorhandenen Layout-Slide nach Typ.
    var blankLayoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    
    // Klone den Layout-Slide an das Ende der Layout-Slide-Sammlung.
    var clonedLayoutSlide = presentation.LayoutSlides.AddClone(blankLayoutSlide);
}
```

> ✅ **Zusammenfassung:** Layout‑Slides sind leistungsstarke Werkzeuge zur Verwaltung einer konsistenten Formatierung über Slides hinweg. Aspose.Slides bietet vollständige Kontrolle über das Erstellen, Verwalten und Optimieren von Layout‑Slides.