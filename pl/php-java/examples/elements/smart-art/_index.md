---
title: SmartArt
type: docs
weight: 140
url: /pl/php-java/examples/elements/smartart/
keywords:
- SmartArt
- dodaj SmartArt
- dostęp do SmartArt
- usuń SmartArt
- układ SmartArt
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Twórz i edytuj SmartArt w PHP przy użyciu Aspose.Slides: dodawaj węzły, zmieniaj układy i style, precyzyjnie konwertuj na kształty oraz eksportuj do PPT, PPTX i ODP."
---
Pokazuje, jak dodać grafiki SmartArt, uzyskać do nich dostęp, usunąć je i zmienić układy przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj SmartArt**

Wstaw grafikę SmartArt, używając jednego z wbudowanych układów.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Dostęp do SmartArt**

Pobierz pierwszy obiekt SmartArt na slajdzie.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszego SmartArt na slajdzie.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń SmartArt**

Usuń kształt SmartArt ze slajdu.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt na slajdzie jest SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zmień układ SmartArt**

Zaktualizuj typ układu istniejącej grafiki SmartArt.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszy kształt na slajdzie jest SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Zmień układ SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```