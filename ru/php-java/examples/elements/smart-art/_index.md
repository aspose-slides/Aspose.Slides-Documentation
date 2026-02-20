---
title: SmartArt
type: docs
weight: 140
url: /ru/php-java/examples/elements/smartart/
keywords:
- SmartArt
- добавить SmartArt
- доступ к SmartArt
- удалить SmartArt
- Макет SmartArt
- Примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Создавайте и редактируйте SmartArt в PHP с помощью Aspose.Slides: добавляйте узлы, меняйте макеты и стили, точно преобразуйте в фигуры и экспортируйте в PPT, PPTX и ODP."
---
Показывает, как добавлять графику SmartArt, получать к ней доступ, удалять её и менять макеты с помощью **Aspose.Slides for PHP via Java**.

## **Добавить SmartArt**

Вставьте графику SmartArt, используя один из встроенных макетов.

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

## **Доступ к SmartArt**

Получите первый объект SmartArt на слайде.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Получить доступ к первому SmartArt на слайде.
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

## **Удалить SmartArt**

Удалите объект SmartArt со слайда.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагается, что первая фигура на слайде — SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Изменить макет SmartArt**

Обновите тип макета существующей графики SmartArt.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагается, что первая фигура на слайде — SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Изменить макет SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```