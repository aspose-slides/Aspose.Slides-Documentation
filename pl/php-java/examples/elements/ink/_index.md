---
title: Atrament
type: docs
weight: 180
url: /pl/php-java/examples/elements/ink/
keywords:
- atrament
- dostęp do atramentu
- usuwanie atramentu
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Obsługuj cyfrowy atrament na slajdach w PHP przy użyciu Aspose.Slides: dodawaj pociągnięcia pióra, edytuj ścieżki, ustawiaj kolor i szerokość oraz eksportuj wyniki do PowerPoint i OpenDocument."
---
Provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for PHP via Java**.

> ❗ **Uwaga:** Kształty atramentu reprezentują dane wprowadzane przez użytkownika z urządzeń specjalistycznych. Aspose.Slides nie może programowo tworzyć nowych pociągnięć atramentu, ale można odczytać i zmodyfikować istniejący atrament.

## **Dostęp do atramentu**

Pobierz pierwszy kształt atramentu na slajdzie.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do pierwszego kształtu atramentu na slajdzie.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń atrament**

Usuń kształt atramentu ze slajdu.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest kształt atramentu.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```