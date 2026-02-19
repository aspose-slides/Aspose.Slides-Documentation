---
title: Переход слайда
type: docs
weight: 110
url: /ru/androidjava/examples/elements/slide-transition/
keywords:
- пример кода
- переход слайда
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Освойте переходы слайдов в Aspose.Slides for Android: добавляйте, настраивайте и упорядочивайте эффекты и длительности с примерами на Java для презентаций PPT, PPTX и ODP."
---
В этой статье продемонстрировано применение эффектов переходов слайдов и их длительности с помощью **Aspose.Slides for Android via Java**.

## **Добавить переход слайда**

Примените эффект плавного перехода к первому слайду.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Применить эффект плавного перехода.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Получить доступ к переходу слайда**

Прочитайте тип перехода, текущий для слайда.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Получить тип перехода.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Удалить переход слайда**

Очистите любой эффект перехода, установив тип в `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Удалить переход, установив значение None.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Установить длительность перехода**

Укажите, как долго слайд отображается перед автоматическим переходом.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // в миллисекундах.
    } finally {
        presentation.dispose();
    }
}
```