---
title: Folie
type: docs
weight: 10
url: /de/androidjava/examples/elements/slide/
keywords:
- Codebeispiel
- Folie
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Steuern Sie Folien in Aspose.Slides für Android: Erstellen, duplizieren, neu anordnen, skalieren, Hintergründe festlegen und Übergänge mit Java für PPT-, PPTX- und ODP‑Präsentationen anwenden."
---
Dieser Artikel bietet eine Reihe von Beispielen, die zeigen, wie man mit Folien unter Verwendung von **Aspose.Slides for Android via Java** arbeitet. Sie erfahren, wie man Folien hinzufügt, darauf zugreift, dupliziert, neu anordnet und entfernt, indem man die Klasse `Presentation` verwendet.

Jedes Beispiel unten enthält eine kurze Erklärung, gefolgt von einem Code‑Snippet in Java.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, muss zunächst ein Layout ausgewählt werden. In diesem Beispiel verwenden wir das Layout `Blank` und fügen der Präsentation eine leere Folie hinzu.

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

> 💡 **Hinweis:** Jeder Folien‑Layout leitet sich von einer Master‑Folie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das Bild unten zeigt, wie Master‑Folien und ihre zugehörigen Layouts in PowerPoint organisiert sind.

![Master and Layout Relationship](master-layout-slide.png)

## **Zugriff auf Folien nach Index**

Sie können Folien anhand ihres Indexes ansprechen oder den Index einer Folie anhand einer Referenz ermitteln. Dies ist nützlich, um durch Folien zu iterieren oder bestimmte Folien zu ändern.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Füge eine weitere leere Folie hinzu.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Greife auf Folien per Index zu.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Ermittle den Folien-Index aus einer Referenz und greife dann per Index darauf zu.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Folie duplizieren**

Dieses Beispiel zeigt, wie eine vorhandene Folie dupliziert wird. Die duplizierte Folie wird automatisch am Ende der Folien‑Sammlung hinzugefügt.

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

## **Folie entfernen**

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