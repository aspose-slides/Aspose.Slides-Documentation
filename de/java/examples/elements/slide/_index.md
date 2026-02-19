---
title: Folie
type: docs
weight: 10
url: /de/java/examples/elements/slide/
keywords:
- Codebeispiel
- Folie
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Steuern Sie Folien in Aspose.Slides for Java: Erstellen, duplizieren, neu anordnen, Größe ändern, Hintergründe festlegen und Übergänge anwenden mit Java für PPT-, PPTX- und ODP‑Präsentationen."
---
Dieser Artikel enthält eine Reihe von Beispielen, die zeigen, wie man mit Folien mit **Aspose.Slides for Java** arbeitet. Sie lernen, wie man Folien mit der `Presentation`‑Klasse hinzufügt, darauf zugreift, dupliziert, neu anordnet und entfernt.

Jedes untenstehende Beispiel enthält eine kurze Erklärung, gefolgt von einem Code‑Snippet in Java.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, müssen Sie zunächst ein Layout auswählen. In diesem Beispiel verwenden wir das `Blank`‑Layout und fügen der Präsentation eine leere Folie hinzu.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis:** Jedes Folienlayout leitet sich von einer Masterfolie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das Bild unten veranschaulicht, wie Masterfolien und ihre zugehörigen Layouts in PowerPoint organisiert sind.

![Master and Layout Relationship](master-layout-slide.png)

## **Folien nach Index zugreifen**

Sie können Folien über ihren Index zugreifen oder den Index einer Folie anhand einer Referenz ermitteln. Das ist nützlich, um durch Folien zu iterieren oder bestimmte Folien zu modifizieren.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Füge eine weitere leere Folie hinzu.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Greife auf Folien nach Index zu.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Erhalte den Folienindex aus einer Referenz und greife danach über den Index zu.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Eine Folie duplizieren**

Dieses Beispiel zeigt, wie man eine vorhandene Folie dupliziert. Die duplizierte Folie wird automatisch am Ende der Foliensammlung eingefügt.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Folien neu anordnen**

Sie können die Reihenfolge der Folien ändern, indem Sie eine Folie an einen neuen Index verschieben. In diesem Fall verschieben wir eine duplizierte Folie an die erste Position.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Eine Folie entfernen**

Um eine Folie zu entfernen, referenzieren Sie sie einfach und rufen `remove` auf. Dieses Beispiel fügt eine zweite Folie hinzu und entfernt dann die ursprüngliche, sodass nur die neue übrig bleibt.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```