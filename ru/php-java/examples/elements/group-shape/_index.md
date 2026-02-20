---
title: Групповая форма
type: docs
weight: 170
url: /ru/php-java/examples/elements/group-shape/
keywords:
- группа
- добавить групповую форму
- доступ к групповой форме
- удалить групповую форму
- разгруппировать фигуры
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- PHP
- Aspose.Slides
description: "Работа с групповыми формами в PHP с использованием Aspose.Slides: создание и разгруппировка, переупорядочивание дочерних форм, установка преобразований и границ для PowerPoint и OpenDocument."
---
Примеры создания групп фигур, их доступа, разгруппировки и удаления с использованием **Aspose.Slides for PHP via Java**.

## **Добавить групповую форму**

Создать группу, содержащую две базовые фигуры.

```php
function addGroupShape() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $group = $slide->getShapes()->addGroupShape();
        $group->getShapes()->addAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
        $group->getShapes()->addAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

        $presentation->save("group_shape.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Получить доступ к групповой форме**

Получить первую групповую форму со слайда.

```php
function accessGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Доступ к первой групповой форме на слайде.
        $firstGroup = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $firstGroup = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Удалить групповую форму**

Удалить групповую форму со слайда.

```php
function removeGroupShape() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        
        // Предполагая, что первая фигура на слайде является групповой формой.
        $group = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($group);

        $presentation->save("group_shape_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Разгруппировать фигуры**

Переместить фигуры из контейнера группы.

```php
function ungroupShapes() {
    $presentation = new Presentation("group_shape.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Предполагая, что первая фигура на слайде является групповой формой.
        $group = $slide->getShapes()->get_Item(0);

        // Клонировать каждую фигуру из группы и добавить её на слайд.
        $shapeCount = java_values($group->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $group->getShapes()->get_Item($index);
            $slide->getShapes()->addClone($shape);
        }

        $slide->getShapes()->remove($group);

        $presentation->save("ungrouped_shapes.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```