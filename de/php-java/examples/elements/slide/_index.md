---
title: Folie
type: docs
weight: 10
url: /de/php-java/examples/elements/slide/
keywords:
- Folie
- Folie hinzufügen
- Folie abrufen
- Folienindex
- Folie klonen
- Folien neu anordnen
- Folie entfernen
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Verwalten Sie Folien in PHP mit Aspose.Slides: erstellen, klonen, neu anordnen, ausblenden, Hintergründe und Größe festlegen, Übergänge anwenden und für PowerPoint und OpenDocument exportieren."
---
Dieser Artikel liefert eine Reihe von Beispielen, die zeigen, wie man mit Folien unter Verwendung von **Aspose.Slides for PHP via Java** arbeitet. Sie lernen, wie man Folien hinzufügt, darauf zugreift, sie klont, neu anordnet und entfernt, indem man die Klasse `Presentation` verwendet.

Jedes untenstehende Beispiel enthält eine kurze Erklärung, gefolgt von einem PHP-Code‑Snippet.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, müssen Sie zuerst ein Layout auswählen. In diesem Beispiel verwenden wir das Layout `Blank` und fügen der Präsentation eine leere Folie hinzu.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Jede Folie basiert auf einem Layout, das wiederum auf einer Masterfolie basiert.
        // Verwenden Sie das Blank-Layout, um eine neue Folie zu erstellen.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Fügen Sie mit dem ausgewählten Layout eine neue leere Folie hinzu.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tipp:** Jeder Folienlayout stammt von einer Masterfolie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das Bild unten veranschaulicht, wie Masterfolien und ihre zugehörigen Layouts in PowerPoint organisiert sind.

![Beziehung zwischen Master und Layout](master-layout-slide.png)

## **Zugriff auf Folien nach Index**

Sie können Folien über ihren Index ansprechen.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Greifen Sie auf eine Folie per Index zu.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Folie klonen**

Dieses Beispiel zeigt, wie man eine vorhandene Folie klont. Die geklonte Folie wird automatisch am Ende der Folien‑Sammlung hinzugefügt.

```php
function cloneSlide() {
    // Standardmäßig enthält die Präsentation eine leere Folie.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Kopieren Sie die erste Folie; sie wird am Ende der Präsentation hinzugefügt.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Der Index der geklonten Folie ist 1 (zweite Folie in der Präsentation).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Folien neu anordnen**

Sie können die Reihenfolge der Folien ändern, indem Sie eine Folie an einen neuen Index verschieben. In diesem Fall verschieben wir eine Folie an die erste Position.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Verschieben Sie die Folie in die erste Position (andere rücken nach unten).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Folie entfernen**

Um eine Folie zu entfernen, referenzieren Sie sie einfach und rufen `remove` auf. Dieses Beispiel entfernt Folien nach Index und nach Referenz.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Entfernen Sie eine Folie nach Index.
        $presentation->getSlides()->removeAt(0);

        // Entfernen Sie eine Folie nach Referenz.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```