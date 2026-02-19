---
title: Соединитель
type: docs
weight: 190
url: /ru/java/examples/elements/connector/
keywords:
- пример кода
- Соединитель
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как добавлять, прокладывать и стилизовать соединители между фигурами с помощью Aspose.Slides for Java, с примерами Java для презентаций PPT, PPTX и ODP."
---
В этой статье показано, как соединять фигуры с помощью соединителей и изменять их цели, используя **Aspose.Slides for Java**.

## **Добавить соединитель**

Вставьте форму‑соединитель между двумя точками на слайде.

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **Получить соединитель**

Получите первую форму‑соединитель, добавленную на слайд.

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // Получить первый соединитель на слайде.
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить соединитель**

Удалите соединитель со слайда.

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **Переподключить фигуры**

Привяжите соединитель к двум фигурам, указав начальную и конечную цели.

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```