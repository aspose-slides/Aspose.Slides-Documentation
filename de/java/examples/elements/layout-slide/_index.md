---
title: Layout-Folie
type: docs
weight: 20
url: /de/java/examples/elements/layout-slide/
keywords:
- Code-Beispiel
- Layout-Folie
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Master-Layout-Folien in Aspose.Slides für Java: Auswählen, Anwenden und Anpassen von Folienlayouts, Platzhaltern und Master-Folien mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel zeigt, wie man mit **Layout-Folien** in Aspose.Slides für Java arbeitet. Eine Layout-Folie definiert das Design und die Formatierung, die von normalen Folien geerbt werden. Sie können Layout-Folien hinzufügen, darauf zugreifen, klonen und entfernen sowie ungenutzte Folien bereinigen, um die Präsentationsgröße zu reduzieren.

## **Hinzufügen einer Layout-Folie**

Sie können eine benutzerdefinierte Layout-Folie erstellen, um wiederverwendbare Formatierungen zu definieren. Beispielsweise können Sie ein Textfeld hinzufügen, das auf allen Folien, die dieses Layout verwenden, erscheint.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Erstelle eine Layout-Folie mit einem leeren Layouttyp und einem benutzerdefinierten Namen.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Füge ein Textfeld zur Layout-Folie hinzu.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Füge zwei Folien mit diesem Layout hinzu; beide erben den Text aus dem Layout.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Hinweis 1:** Layout-Folien fungieren als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und über viele Folien hinweg wiederverwenden.

> 💡 **Hinweis 2:** Wenn Sie Formen oder Text zu einer Layout-Folie hinzufügen, zeigen alle auf diesem Layout basierenden Folien diesen gemeinsamen Inhalt automatisch an. > Der Screenshot unten zeigt zwei Folien, die jeweils ein Textfeld aus derselben Layout-Folie erben.

![Folien, die Layout-Inhalte erben](layout-slide-result.png)

## **Zugriff auf eine Layout-Folie**

Layout-Folien können über den Index oder den Layout-Typ (z. B. `Blank`, `Title`, `SectionHeader` usw.) zugegriffen werden.

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Greife auf eine Layout-Folie nach Index zu.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Greife auf eine Layout-Folie nach Typ zu.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Entfernen einer Layout-Folie**

Sie können eine bestimmte Layout-Folie entfernen, wenn sie nicht mehr benötigt wird.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Hole eine Layout-Folie nach Typ und entferne sie.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Entfernen nicht verwendeter Layout-Folien**

Um die Präsentationsgröße zu reduzieren, können Sie Layout-Folien entfernen, die von keiner normalen Folie verwendet werden.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Entfernt automatisch alle Layout-Folien, die von keiner Folie referenziert werden.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Klonen einer Layout-Folie**

Sie können eine Layout-Folie mit der Methode `addClone` duplizieren.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Hole eine vorhandene Layout-Folie nach Typ.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Kloniere die Layout-Folie an das Ende der Layout-Folien-Sammlung.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Zusammenfassung:** Layout-Folien sind leistungsstarke Werkzeuge zur Verwaltung konsistenter Formatierung über Folien hinweg. Aspose.Slides bietet volle Kontrolle über das Erstellen, Verwalten und Optimieren von Layout-Folien.