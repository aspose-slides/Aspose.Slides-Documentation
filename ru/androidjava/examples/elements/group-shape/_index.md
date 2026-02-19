---
title: Групповая фигура
type: docs
weight: 170
url: /ru/androidjava/examples/elements/group-shape/
keywords:
- пример кода
- групповая фигура
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте сгруппированными фигурами в Aspose.Slides for Android: создавайте, вкладывайте, выравнивайте, переупорядочивайте и оформляйте групповые фигуры с примерами на Java в презентациях PPT, PPTX и ODP."
---
Примеры создания групп фигур, доступа к ним, разгруппировки и удаления с использованием **Aspose.Slides for Android via Java**.

## **Добавление группы фигур**

Создайте группу, содержащую две базовые фигуры.

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к групповой фигуре**

Получите первую групповую фигуру со слайда.

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удаление групповой фигуры**

Удалите групповую фигуру со слайда.

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **Разгруппировка фигур**

Переместите фигуры из группового контейнера.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Переместить фигуру из группы.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```