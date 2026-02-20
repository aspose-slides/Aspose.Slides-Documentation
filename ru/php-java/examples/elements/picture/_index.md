---
title: Изображение
type: docs
weight: 50
url: /ru/php-java/examples/elements/picture/
keywords:
- изображение
- рамка изображения
- добавить изображение
- доступ к изображению
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Работа с изображениями в PHP с помощью Aspose.Slides: вставка, замена, обрезка, сжатие, настройка прозрачности и эффектов, заливка фигур и экспорт в PPT, PPTX и ODP."
---
Показано, как вставлять и получать доступ к изображениям с помощью **Aspose.Slides for PHP via Java**. Ниже приведённые примеры помещают изображение на слайд, а затем извлекают его.

## **Добавить изображение**

Этот код вставляет изображение в виде рамки изображения на первый слайд.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Добавить изображение в ресурсы презентации.
        $ppImage = $presentation->getImages()->addImage($image);

        // Вставить рамку изображения, отображающую изображение на первом слайде.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Доступ к изображению**

Этот пример гарантирует, что слайд содержит рамку изображения, и затем получает доступ к первой найденной.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить первый PictureFrame на слайде.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```