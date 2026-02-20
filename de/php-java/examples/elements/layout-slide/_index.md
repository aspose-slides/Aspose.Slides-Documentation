---
title: Layoutfolie
type: docs
weight: 20
url: /de/php-java/examples/elements/layout-slide/
keywords:
- Layoutfolie
- Layoutfolie hinzufügen
- Zugriff auf Layoutfolie
- Layoutfolie entfernen
- Unbenutzte Layoutfolie
- Layoutfolie duplizieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwenden Sie PHP, um Layoutfolien mit Aspose.Slides zu verwalten: Erstellen, Anwenden, Duplizieren, Umbenennen und Anpassen von Platzhaltern und Designs in Präsentationen für PPT, PPTX und ODP."
---
Dieser Artikel zeigt, wie man **Layoutfolien** in Aspose.Slides für PHP über Java verwendet. Eine Layoutfolie definiert das Design und die Formatierung, die von normalen Folien geerbt werden. Sie können Layoutfolien hinzufügen, darauf zugreifen, klonen und entfernen sowie nicht verwendete entfernen, um die Präsentationsgröße zu reduzieren.

## **Eine Layoutfolie hinzufügen**

Sie können eine benutzerdefinierte Layoutfolie erstellen, um wiederverwendbare Formatierungen zu definieren. Zum Beispiel könnten Sie ein Textfeld hinzufügen, das auf allen Folien dieses Layouts angezeigt wird.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Erstelle eine Layoutfolie mit einem leeren Layouttyp und einem benutzerdefinierten Namen.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tipp 1:** Layoutfolien fungieren als Vorlagen für einzelne Folien. Sie können gemeinsame Elemente einmal definieren und sie in vielen Folien wiederverwenden.

> 💡 **Tipp 2:** Wenn Sie Formen oder Text zu einer Layoutfolie hinzufügen, wird dieser gemeinsame Inhalt automatisch in allen darauf basierenden Folien angezeigt.
> Der Screenshot unten zeigt zwei Folien, die jeweils ein Textfeld von derselben Layoutfolie erben.

![Folien erben Layoutinhalt](layout-slide-result.png)


## **Auf eine Layoutfolie zugreifen**

Layoutfolien können nach Index oder nach Layouttyp (z.B. `Blank`, `Title`, `SectionHeader` usw.) abgerufen werden.

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Zugriff per Index.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Zugriff per Layouttyp.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Eine Layoutfolie entfernen**

Sie können eine bestimmte Layoutfolie entfernen, wenn sie nicht mehr benötigt wird.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Hole eine Layoutfolie nach Typ und entferne sie.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Nicht verwendete Layoutfolien entfernen**

Um die Präsentationsgröße zu reduzieren, können Sie Layoutfolien entfernen, die von keinen normalen Folien verwendet werden.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Entfernt automatisch alle Layoutfolien, die von keiner Folie referenziert werden.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Eine Layoutfolie klonen**

Sie können eine Layoutfolie mit der Methode `addClone` duplizieren.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Hole eine vorhandene Layoutfolie nach Typ.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Klone die Layoutfolie an das Ende der Layoutfoliensammlung.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Zusammenfassung:** Layoutfolien sind leistungsstarke Werkzeuge zur Verwaltung einheitlicher Formatierungen über Folien hinweg. Aspose.Slides bietet volle Kontrolle über das Erstellen, Verwalten und Optimieren von Layoutfolien.