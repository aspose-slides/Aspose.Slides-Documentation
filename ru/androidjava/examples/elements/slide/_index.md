---
title: Слайд
type: docs
weight: 10
url: /ru/androidjava/examples/elements/slide/
keywords:
- пример кода
- слайд
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте слайдами в Aspose.Slides for Android: создавайте, клонируйте, переупорядочивайте, изменяйте размер, задавайте фон и применяйте переходы с помощью Java для презентаций PPT, PPTX и ODP."
---
Эта статья содержит серию примеров, демонстрирующих работу со слайдами с помощью **Aspose.Slides for Android via Java**. Вы узнаете, как добавлять, получать доступ, клонировать, переупорядочивать и удалять слайды, используя класс `Presentation`.

Каждый пример ниже включает краткое описание и последующий фрагмент кода на Java.

## **Добавить слайд**

Чтобы добавить новый слайд, сначала необходимо выбрать макет. В этом примере мы используем макет `Blank` и добавляем пустой слайд в презентацию.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Примечание:** Каждый макет слайда основан на мастер‑слайде, который определяет общий дизайн и структуру заполнителей. На изображении ниже показано, как мастеры слайдов и их связанные макеты организованы в PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Доступ к слайдам по индексу**

Вы можете получить доступ к слайдам по их индексу или найти индекс слайда по ссылке. Это полезно для перебора или изменения конкретных слайдов.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Добавьте еще один пустой слайд.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Получите доступ к слайдам по индексу.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Получите индекс слайда из ссылки, а затем получите его по индексу.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Клонировать слайд**

В этом примере показано, как клонировать существующий слайд. Клонированный слайд автоматически добавляется в конец коллекции слайдов.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Переупорядочить слайды**

Можно изменить порядок слайдов, переместив один из них на новый индекс. В данном случае мы перемещаем клонированный слайд в первую позицию.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить слайд**

Чтобы удалить слайд, просто укажите его и вызовите `remove`. В этом примере добавляется второй слайд, после чего оригинальный удаляется, оставляя только новый.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```