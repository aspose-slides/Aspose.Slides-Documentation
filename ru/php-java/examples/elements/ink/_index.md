---
title: Чернила
type: docs
weight: 180
url: /ru/php-java/examples/elements/ink/
keywords:
- чернила
- доступ к чернилам
- удаление чернил
- пример кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Работайте с цифровыми чернилами на слайдах в PHP с помощью Aspose.Slides: добавляйте штрихи пера, редактируйте пути, задавайте цвет и толщину, а также экспортируйте результаты в PowerPoint и OpenDocument."
---
Provides examples of accessing existing ink shapes and removing them using **Aspose.Slides for PHP via Java**.

> ❗ **Note:** Ink shapes represent user input from specialized devices. Aspose.Slides cannot create new ink strokes programmatically, but you can read and modify existing ink.

## **Access Ink**
Get the first ink shape on a slide.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Доступ к первой фигуре чернил на слайде.
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

## **Remove Ink**
Delete an ink shape from the slide.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде является фигурой чернил.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```