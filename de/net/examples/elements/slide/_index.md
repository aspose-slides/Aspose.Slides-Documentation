---
title: Folie
type: docs
weight: 10
url: /de/net/examples/elements/slide/
keywords:
- Folie
- Folie hinzufügen
- Folie zugreifen
- Folienindex
- Folie klonen
- Folien neu anordnen
- Folie entfernen
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Steuern Sie Folien in Aspose.Slides für .NET: Erstellen, klonen, neu anordnen, Größe ändern, Hintergründe festlegen und Übergänge mit C# für PPT-, PPTX- und ODP-Präsentationen anwenden."
---
Dieser Artikel enthält eine Reihe von Beispielen, die zeigen, wie man mit Folien unter Verwendung von **Aspose.Slides for .NET** arbeitet. Sie lernen, wie man Folien mit der `Presentation`-Klasse hinzufügt, darauf zugreift, sie klont, neu anordnet und entfernt.

Jedes nachfolgende Beispiel enthält eine kurze Erklärung, gefolgt von einem Code‑Snippet in C#.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, müssen Sie zunächst ein Layout auswählen. In diesem Beispiel verwenden wir das Layout `Blank` und fügen der Präsentation eine leere Folie hinzu.

```csharp
static void AddSlide()
{
    using var presentation = new Presentation();

    // Jede Folie basiert auf einem Layout, das wiederum auf einer Masterfolie basiert.
    // Verwenden Sie das Blank-Layout, um eine neue Folie zu erstellen.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // Fügen Sie eine neue leere Folie mit dem ausgewählten Layout hinzu.
    presentation.Slides.AddEmptySlide(layout: blankLayout);
}
```

> 💡 **Hinweis:** Jedes Folienlayout leitet sich von einer Masterfolie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das Bild unten zeigt, wie Masterfolien und ihre zugehörigen Layouts in PowerPoint organisiert sind.

![Master and Layout Relationship](master-layout-slide.png)

## **Zugriff auf Folien nach Index**

Sie können Folien über ihren Index zugreifen oder den Index einer Folie anhand einer Referenz ermitteln. Das ist nützlich, um durch Folien zu iterieren oder bestimmte Folien zu ändern.

```csharp
static void AccessSlide()
{
    // Standardmäßig wird eine Präsentation mit einer leeren Folie erstellt.
    using var presentation = new Presentation();

    // Fügen Sie eine weitere leere Folie hinzu.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Zugriff auf Folien nach Index.
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides[1];

    // Ermitteln Sie den Folienindex aus einer Referenz und greifen dann per Index darauf zu.
    var secondSlideIndex = presentation.Slides.IndexOf(secondSlide);
    var secondSlideByIndex = presentation.Slides[secondSlideIndex];
}
```

## **Folie klonen**

Dieses Beispiel zeigt, wie man eine vorhandene Folie klont. Die geklonte Folie wird automatisch am Ende der Folienkollektion hinzugefügt.

```csharp
static void CloneSlide()
{
    // Standardmäßig enthält die Präsentation eine leere Folie.
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Klonen Sie die erste Folie; sie wird am Ende der Präsentation hinzugefügt.
    var clonedSlide = presentation.Slides.AddClone(sourceSlide: firstSlide);

    // Der Index der geklonten Folie ist 1 (zweite Folie in der Präsentation).
    var clonedSlideIndex = presentation.Slides.IndexOf(clonedSlide);
}
```

## **Folien neu anordnen**

Sie können die Reihenfolge der Folien ändern, indem Sie eine Folie an einen neuen Index verschieben. In diesem Fall verschieben wir eine geklonte Folie an die erste Position.

```csharp
static void ReorderSlide()
{
    using var presentation = new Presentation();
    var firstSlide = presentation.Slides[0];

    // Fügen Sie einen Klon der ersten Folie hinzu (standardmäßig erstellt).
    var clonedSlide = presentation.Slides.AddClone(firstSlide);

    // Verschieben Sie die geklonte Folie in die erste Position (andere verschieben sich nach unten).
    presentation.Slides.Reorder(index: 0, clonedSlide);
}
```

## **Folie entfernen**

Um eine Folie zu entfernen, referenzieren Sie sie einfach und rufen `Remove` auf. Dieses Beispiel fügt eine zweite Folie hinzu und entfernt dann die ursprüngliche, sodass nur die neue übrig bleibt.

```csharp
static void RemoveSlide()
{
    using var presentation = new Presentation();

    // Fügen Sie eine neue leere Folie zusätzlich zur standardmäßigen ersten Folie hinzu.
    var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    var secondSlide = presentation.Slides.AddEmptySlide(layout: blankLayout);

    // Entfernen Sie die erste Folie; nur die neu hinzugefügte Folie bleibt erhalten.
    var firstSlide = presentation.Slides[0];
    presentation.Slides.Remove(firstSlide);
}
```