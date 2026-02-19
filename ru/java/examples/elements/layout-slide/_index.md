---
title: Макет слайда
type: docs
weight: 20
url: /ru/java/examples/elements/layout-slide/
keywords:
- пример кода
- макет слайда
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Мастер-работа с макетами слайдов в Aspose.Slides for Java: выбирайте, применяйте и настраивайте макеты слайдов, заполнители и шаблоны с помощью примеров на Java для презентаций PPT, PPTX и ODP."
---
В этой статье демонстрируется, как работать с **Layout Slides** в Aspose.Slides for Java. Слайд макета определяет дизайн и форматирование, унаследованные обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять слайды макетов, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

## **Добавить макет слайда**

Вы можете создать пользовательский макет слайда, чтобы определить повторно используемое форматирование. Например, можно добавить текстовое поле, которое будет отображаться на всех слайдах, использующих этот макет.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Создать макет слайда с типом пустого макета и пользовательским именем.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Добавить текстовое поле в макет слайда.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Добавить два слайда, используя этот макет; оба унаследуют текст из макета.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Примечание 1:** Макеты слайдов выступают в качестве шаблонов для отдельных слайдов. Вы можете определить общие элементы один раз и повторно использовать их на множестве слайдов.

> 💡 **Примечание 2:** Когда вы добавляете фигуры или текст в макет слайда, все слайды, основанные на этом макете, автоматически отображают этот общий контент.

> Ниже показан скриншот двух слайдов, каждый из которых наследует текстовое поле из одного и того же макета слайда.

![Слайды, наследующие контент макета](layout-slide-result.png)

## **Доступ к макету слайда**

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Доступ к макету слайда по индексу.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Доступ к макету слайда по типу.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить макет слайда**

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Получить макет слайда по типу и удалить его.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить неиспользуемые макеты слайдов**

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Автоматически удаляет все макеты слайдов, не используемые ни одним слайдом.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Клонировать макет слайда**

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Получить существующий макет слайда по типу.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Клонировать макет слайда в конец коллекции макетов слайдов.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Итог:** Макеты слайдов — мощный инструмент для управления единообразным форматированием на всех слайдах. Aspose.Slides предоставляет полный контроль над созданием, управлением и оптимизацией макетов слайдов.