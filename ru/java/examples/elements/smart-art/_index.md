---
title: SmartArt
type: docs
weight: 140
url: /ru/java/examples/elements/smart-art/
keywords:
- пример кода
- SmartArt
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Работайте с SmartArt в Aspose.Slides for Java: создавайте, редактируйте, конвертируйте и оформляйте диаграммы с помощью Java для презентаций PowerPoint и OpenDocument."
---
В этой статье демонстрируется, как добавлять графику SmartArt, получать к ней доступ, удалять её и изменять макеты с использованием **Aspose.Slides for Java**.

## **Добавить SmartArt**
Вставьте графику SmartArt, используя один из встроенных макетов.

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **Доступ к SmartArt**
Получите первый объект SmartArt на слайде.

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить SmartArt**
Удалите форму SmartArt со слайда.

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **Изменить макет SmartArt**
Обновите тип макета существующей графики SmartArt.

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```