---
title: Folie
type: docs
weight: 10
url: /de/net/examples/elements/slide/
keywords:
- Folienbeispiel
- Folie hinzufügen
- Zugriff auf Folie
- Folienindex
- Folie duplizieren
- Folien neu anordnen
- Folie entfernen
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Folien in C# mit Aspose.Slides: Erstellen, duplizieren, neu anordnen, ausblenden, Hintergründe und Größe festlegen, Übergänge anwenden und für PowerPoint sowie OpenDocument exportieren."
---

Dieser Artikel liefert eine Reihe von Beispielen, die zeigen, wie man mit Folien unter Verwendung von **Aspose.Slides for .NET** arbeitet. Sie lernen, wie man Folien mit der Klasse `Presentation` hinzufügt, darauf zugreift, sie klont, neu anordnet und entfernt.

Jedes Beispiel unten enthält eine kurze Erklärung, gefolgt von einem C#‑Code‑Snippet.

## Folie hinzufügen

Um eine neue Folie hinzuzufügen, müssen Sie zunächst ein Layout auswählen. In diesem Beispiel verwenden wir das Layout `Blank` und fügen der Präsentation eine leere Folie hinzu.
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // Jede Folie basiert auf einem Layout, das wiederum auf einer Masterfolie basiert.
    // Verwenden Sie das Blank-Layout, um eine neue Folie zu erstellen.
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Fügen Sie eine neue leere Folie mit dem ausgewählten Layout hinzu
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
````

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## Access Slides by Index

You can access slides using their index, or find a slide’s index based on a reference. This is useful for iterating through or modifying specific slides.

```csharp
static void Access_Slide()
{
    // Standardmäßig wird eine Präsentation mit einer leeren Folie erstellt
    using var pres = new Presentation();

    // Fügen Sie eine weitere leere Folie hinzu
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Zugriff auf Folien über den Index
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // Ermitteln Sie den Folienindex aus einer Referenz und greifen dann über den Index darauf zu
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

## Clone a Slide

This example demonstrates how to clone an existing slide. The cloned slide is automatically added to the end of the slide collection.

```csharp
static void Clone_Slide()
{
    // Standardmäßig enthält die Präsentation eine leere Folie
    using var pres = new Presentation();

    // Klonen Sie die erste Folie; sie wird am Ende der Präsentation hinzugefügt
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // Der Index der geklonten Folie ist 1 (zweite Folie in der Präsentation)
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

## Reorder Slides

You can change the order of slides by moving one to a new index. In this case, we move a cloned slide to the first position.

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // Fügen Sie eine Kopie der ersten Folie hinzu (standardmäßig erstellt)
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // Verschieben Sie die geklonte Folie an die erste Position (andere rücken nach unten)
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

## Remove a Slide

To remove a slide, simply reference it and call `Remove`. This example adds a second slide and then removes the original, leaving only the new one.

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // Fügen Sie eine neue leere Folie zusätzlich zur standardmäßigen ersten Folie hinzu
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Entfernen Sie die erste Folie; nur die neu hinzugefügte Folie bleibt erhalten
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
