---
title: Чернила
type: docs
weight: 180
url: /ru/java/examples/elements/ink/
keywords:
- пример кода
- чернила
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Работайте с чернилами в Aspose.Slides for Java: рисуйте, импортируйте и редактируйте штрихи, регулируйте цвет и ширину, а также экспортируйте в PPT, PPTX и ODP, используя примеры на Java."
---
В этой статье приводятся примеры доступа к существующим фигурам чернил и их удаления с помощью **Aspose.Slides for Java**.

> ❗ **Примечание:** Фигуры чернил представляют ввод пользователя со специализированных устройств. Aspose.Slides не может создавать новые штрихи чернил программно, но вы можете читать и изменять существующие чернила.

## **Доступ к чернилам**

Прочитайте теги первой фигуры чернил на слайде.

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

Удалите фигуру чернил со слайда, если она существует.

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