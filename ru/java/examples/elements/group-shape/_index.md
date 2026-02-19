---
title: Групповая фигура
type: docs
weight: 170
url: /ru/java/examples/elements/group-shape/
keywords:
- пример кода
- групповая фигура
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Управляйте групповыми фигурами в Aspose.Slides for Java: создавайте, вкладывайте, выравнивайте, переупорядочивайте и оформляйте групповые фигуры с примерами Java в презентациях PPT, PPTX и ODP."
---
Примеры создания групп фигур, доступа к ним, разгруппировки и удаления с использованием **Aspose.Slides for Java**.

## **Add a Group Shape**
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

## **Access a Group Shape**
Получите первую группу фигур со слайда.

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

## **Remove a Group Shape**
Удалите группу фигур со слайда.

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

## **Ungroup Shapes**
Переместите фигуры из группового контейнера.

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // Переместить форму из группы.
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```