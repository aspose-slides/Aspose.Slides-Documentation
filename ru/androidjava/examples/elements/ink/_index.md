---
title: Чернила
type: docs
weight: 180
url: /ru/androidjava/examples/elements/ink/
keywords:
- пример кода
- чернила
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Работайте с чернилами в Aspose.Slides for Android: рисуйте, импортируйте и редактируйте штрихи, регулируйте цвет и толщину, и экспортируйте в PPT, PPTX и ODP с примерами на Java."
---
В этой статье приведены примеры доступа к существующим чернильным фигурам и их удаления с использованием **Aspose.Slides for Android via Java**.

> ❗ **Примечание:** Чернильные фигуры представляют ввод пользователя с специализированных устройств. Aspose.Slides не может программно создавать новые чернильные штрихи, но вы можете читать и изменять существующие чернила.

## **Доступ к чернилам**

Прочитайте теги первой чернильной фигуры на слайде.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Используйте tagName по мере необходимости.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить чернила**

Удалите чернильную фигуру со слайда, если она существует.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```