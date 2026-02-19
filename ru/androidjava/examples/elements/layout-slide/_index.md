---
title: Макетный слайд
type: docs
weight: 20
url: /ru/androidjava/examples/elements/layout-slide/
keywords:
- пример кода
- макетный слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте макетными слайдами в Aspose.Slides для Android: выбирайте, применяйте и настраивайте макеты слайдов, заполнительные элементы и шаблоны с примерами на Java для презентаций PPT, PPTX и ODP."
---
Эта статья демонстрирует, как работать с **Layout Slides** в Aspose.Slides for Android через Java. Макетный слайд определяет дизайн и форматирование, наследуемые обычными слайдами. Вы можете добавлять, получать доступ, клонировать и удалять макетные слайды, а также очищать неиспользуемые, чтобы уменьшить размер презентации.

## **Добавить макетный слайд**

Вы можете создать пользовательский макетный слайд, чтобы определить повторно используемое форматирование. Например, можно добавить текстовое поле, которое будет отображаться на всех слайдах, использующих этот макет.

```java
static void addLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

        // Создайте макетный слайд с типом пустого макета и пользовательским именем.
        ILayoutSlide layoutSlide = presentation.getLayoutSlides().add(masterSlide, SlideLayoutType.Blank, "Main layout");

        // Добавьте текстовое поле к макетному слайду.
        IAutoShape layoutTextBox = layoutSlide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150);
        layoutTextBox.getTextFrame().setText("Layout Slide Text");

        // Добавьте два слайда, используя этот макет; оба унаследуют текст из макета.
        presentation.getSlides().addEmptySlide(layoutSlide);
        presentation.getSlides().addEmptySlide(layoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Примечание 1:** Макетные слайды выступают в качестве шаблонов для отдельных слайдов. Вы можете определить общие элементы один раз и переиспользовать их на множестве слайдов.

> 💡 **Примечание 2:** Когда вы добавляете фигуры или текст в макетный слайд, все слайды, основанные на этом макете, автоматически отображают этот общий контент.  
> Ниже показан скриншот двух слайдов, каждый из которых наследует текстовое поле из одного и того же макетного слайда.

![Slides Inheriting Layout Content](layout-slide-result.png)

## **Получить доступ к макетному слайду**

Макетные слайды можно получить по индексу или по типу макета (например, `Blank`, `Title`, `SectionHeader` и т.д.).

```java
static void accessLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Получите макетный слайд по индексу.
        ILayoutSlide firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Получите макетный слайд по типу.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить макетный слайд**

Вы можете удалить конкретный макетный слайд, если он больше не нужен.

```java
static void removeLayoutSlide() {
    Presentation presentation = new Presentation();
    try {
        // Получите макетный слайд по типу и удалите его.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Custom);
        presentation.getLayoutSlides().remove(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить неиспользуемые макетные слайды**

Чтобы уменьшить размер презентации, можно удалить макетные слайды, которые не используются ни одним обычным слайдом.

```java
static void removeUnusedLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Автоматически удаляет все макетные слайды, не связанные ни с одним слайдом.
        presentation.getLayoutSlides().removeUnused();
    } finally {
        presentation.dispose();
    }
}
```

## **Клонировать макетный слайд**

Вы можете дублировать макетный слайд с помощью метода `addClone`.

```java
static void cloneLayoutSlides() {
    Presentation presentation = new Presentation();
    try {
        // Получите существующий макетный слайд по типу.
        ILayoutSlide blankLayoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        // Клонируйте макетный слайд в конец коллекции макетных слайдов.
        ILayoutSlide clonedLayoutSlide = presentation.getLayoutSlides().addClone(blankLayoutSlide);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Итог:** Макетные слайды — мощный инструмент для управления согласованным форматированием на всех слайдах. Aspose.Slides предоставляет полный контроль над созданием, управлением и оптимизацией макетных слайдов.