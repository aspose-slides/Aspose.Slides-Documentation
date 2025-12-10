---
title: Folie
type: docs
weight: 10
url: /de/net/examples/elements/slide/
keywords:
- Folienbeispiel
- Folie hinzufügen
- Folie zugreifen
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

Dieser Artikel liefert eine Reihe von Beispielen, die zeigen, wie man mit Folien unter Verwendung von **Aspose.Slides for .NET** arbeitet. Sie erfahren, wie Sie Folien mithilfe der Klasse `Presentation` hinzufügen, darauf zugreifen, duplizieren, neu anordnen und entfernen.

Jedes nachfolgende Beispiel enthält eine kurze Erklärung, gefolgt von einem Code‑Snippet in C#.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, müssen Sie zunächst ein Layout auswählen. In diesem Beispiel verwenden wir das Layout `Blank` und fügen eine leere Folie zur Präsentation hinzu.
```csharp
static void Add_Slide()
{
    using var pres = new Presentation();

    // Jede Folie basiert auf einem Layout, das wiederum auf einer Masterfolie basiert.
    // Verwenden Sie das Layout Blank, um eine neue Folie zu erstellen.
    var blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Fügen Sie eine neue leere Folie mit dem ausgewählten Layout hinzu.
    pres.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Tip:** Each slide layout is derived from a master slide, which defines the overall design and placeholder structure. The image below illustrates how master slides and their associated layouts are organized in PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

```csharp
static void Access_Slide()
{
    // Standardmäßig wird eine Präsentation mit einer leeren Folie erstellt.
    using var pres = new Presentation();

    // Fügen Sie eine weitere leere Folie hinzu.
    pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Zugriff auf Folien über den Index
    var firstSlide = pres.Slides[0];
    var secondSlide = pres.Slides[1];

    // Ermitteln Sie den Folienindex aus einer Referenz und greifen dann über den Index darauf zu.
    var secondSlideIndex = pres.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = pres.Slides[secondSlideIndex];
}
```

## **Clone a Slide**

```csharp
static void Clone_Slide()
{
    // Standardmäßig enthält die Präsentation eine leere Folie.
    using var pres = new Presentation();

    // Klonen Sie die erste Folie; sie wird am Ende der Präsentation hinzugefügt.
    var clonedSlide = pres.Slides.AddClone(sourceSlide: pres.Slides[0]);

    // Der Index der geklonten Folie ist 1 (zweite Folie in der Präsentation).
    var clonedSlideIndex = pres.Slides.IndexOf(clonedSlide);
}
```

## **Reorder Slides**

```csharp
static void ReOrder_Slide()
{
    using var pres = new Presentation();

    // Fügen Sie einen Klon der ersten Folie hinzu (standardmäßig erstellt).
    var clonedSlide = pres.Slides.AddClone(pres.Slides[0]);

    // Verschieben Sie die geklonte Folie in die erste Position (andere rücken nach unten).
    pres.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Remove a Slide**

```csharp
static void Remove_Slide()
{
    using var pres = new Presentation();

    // Fügen Sie eine neue leere Folie zusätzlich zur standardmäßigen ersten Folie hinzu.
    var secondSlide = pres.Slides.AddEmptySlide(layout: pres.LayoutSlides.GetByType(SlideLayoutType.Blank));

    // Entfernen Sie die erste Folie; nur die neu hinzugefügte Folie bleibt erhalten.
    var firstSlide = pres.Slides[0];
    pres.Slides.Remove(firstSlide);
}
```
