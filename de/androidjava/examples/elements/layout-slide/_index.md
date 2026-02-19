---
title: Layout-Folie
type: docs
weight: 20
url: /de/androidjava/examples/elements/layout-slide/
keywords:
- Codebeispiel
- Layout-Folie
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Master-Layout-Slides in Aspose.Slides für Android: Auswählen, Anwenden und Anpassen von Folien-Layouts, Platzhaltern und Master-Folien mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie man mit **Layout Slides** in Aspose.Slides für Android über Java arbeitet. Ein Layout‑Slide definiert das Design und die Formatierung, die von normalen Folien geerbt werden. Sie können Layout‑Slides hinzufügen, darauf zugreifen, klonen und entfernen sowie ungenutzte Slides bereinigen, um die Präsentationsgröße zu reduzieren.

## **Layout‑Slide hinzufügen**

Sie können ein benutzerdefiniertes Layout‑Slide erstellen, um wiederverwendbare Formatierungen zu definieren. Zum Beispiel könnten Sie ein Textfeld hinzufügen, das auf allen Folien erscheint, die dieses Layout verwenden.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Erstelle ein Layout‑Slide mit einem leeren Layouttyp und einem benutzerdefinierten Namen.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Füge dem Layout‑Slide ein Textfeld hinzu.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Füge zwei Folien hinzu, die dieses Layout verwenden; beide erben den Text vom Layout.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis 1:** Layout‑Slides fungieren als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und über viele Folien hinweg wiederverwenden.
> 💡 **Hinweis 2:** Wenn Sie Formen oder Text zu einem Layout‑Slide hinzufügen, wird dieser geteilte Inhalt automatisch auf allen Folien angezeigt, die auf diesem Layout basieren.
> Der Screenshot unten zeigt zwei Folien, die jeweils ein Textfeld vom selben Layout‑Slide erben.

![Folien, die Layout‑Inhalt erben](layout-slide-result.png)

## **Zugriff auf ein Layout‑Slide**

Layout‑Slides können über ihren Index oder nach Layout‑Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) zugegriffen werden.

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Greife auf ein Layout‑Slide über den Index zu.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Greife auf ein Layout‑Slide über den Typ zu.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Layout‑Slide entfernen**

Sie können ein bestimmtes Layout‑Slide entfernen, wenn es nicht mehr benötigt wird.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Hole ein Layout-Slide nach Typ und entferne es.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Unbenutzte Layout‑Slides entfernen**

Um die Präsentationsgröße zu reduzieren, möchten Sie möglicherweise Layout‑Slides entfernen, die von keinen normalen Folien verwendet werden.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Entfernt automatisch alle Layout-Slides, die von keiner Folie referenziert werden.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Layout‑Slide duplizieren**

Sie können ein Layout‑Slide mit der Methode `addClone` duplizieren.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Hole ein vorhandenes Layout-Slide nach Typ.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Klone das Layout-Slide an das Ende der Layout-Slide-Sammlung.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Zusammenfassung:** Layout‑Slides sind leistungsstarke Werkzeuge zur Verwaltung einheitlicher Formatierung über Folien hinweg. Aspose.Slides ermöglicht vollständige Kontrolle über das Erstellen, Verwalten und Optimieren von Layout‑Slides.