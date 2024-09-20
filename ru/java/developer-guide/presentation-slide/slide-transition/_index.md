---
title: Смена слайдов
type: docs
weight: 80
url: /java/slide-transition/
keywords: "Смена слайдов PowerPoint, морфинг в Java"
description: "Смена слайдов PowerPoint, морфинг PowerPoint в Java"
---


## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides для Java также позволяет разработчикам управлять или настраивать эффекты смены слайдов. В этой теме мы обсудим, как легко контролировать смены слайдов с помощью Aspose.Slides для Java.

{{% /alert %}} 

Чтобы облегчить понимание, мы продемонстрируем использование Aspose.Slides для Java для управления простыми сменами слайдов. Разработчики могут не только применять различные эффекты смены слайдов, но также настраивать поведение этих эффектов.

## **Добавить смену слайдов**
Чтобы создать простой эффект смены слайдов, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Примените тип смены слайда из одного из эффектов смены, предлагаемых Aspose.Slides для Java, через перечисление TransitionType.
1. Запишите измененный файл презентации.

```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Примените переход типа круг на слайде 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Примените переход типа комбо на слайде 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Запишите презентацию на диск
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавить сложную смену слайдов**
В предыдущем разделе мы просто применили простой эффект смены на слайде. Теперь, чтобы сделать этот простой эффект смены еще лучше и управляемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Примените тип смены слайда из одного из эффектов смены, предлагаемых Aspose.Slides для Java.
1. Вы также можете установить переход на «Следующий по клику», через определенный промежуток времени или оба варианта.
1. Если смена слайдов включена для перехода «Следующий по клику», переход будет осуществляться только при щелчке мыши. Кроме того, если установлено свойство «Следующий через время», переход будет происходить автоматически после истечения указанного времени.
1. Запишите измененную презентацию в файл.

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Примените переход типа круг на слайде 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Установите время перехода 3 секунды
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Примените переход типа комбо на слайде 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Установите время перехода 5 секунд
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Примените переход типа зум на слайде 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Установите время перехода 7 секунд
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Запишите презентацию на диск
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Морфинг**
{{% alert color="primary" %}} 

Aspose.Slides для Java теперь поддерживает [Морфинг](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition). Это новый морфный переход, представленный в PowerPoint 2019.

{{% /alert %}} 

Морфинг позволяет анимировать плавное движение от одного слайда к следующему. Эта статья описывает концепцию и как использовать морфинг. Чтобы эффективно использовать морфинг, вам нужно иметь два слайда с хотя бы одним общим объектом. Самый простой способ — дублировать слайд и переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить к презентации клон слайда с текстом и установить переход типа [морф](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) на второй слайд.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Морфинг в презентациях PowerPoint");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Типы морфинга**
Добавлено новое перечисление [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType). Оно представляет различные типы морфного перехода слайда.

Перечисление TransitionMorphType имеет три члена:

- ByObject: Морфный переход будет осуществляться с учетом форм как неделимых объектов.
- ByWord: Морфный переход будет осуществляться с переносом текста по словам, где это возможно.
- ByChar: Морфный переход будет осуществляться с переносом текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить морфный переход для слайда и изменить тип морфинга:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Установить эффекты перехода**
Aspose.Slides для Java поддерживает установку эффектов перехода, таких как «из черного», «слева», «справа» и т.д. Чтобы установить эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию в файл [PPTX ](https://docs.fileformat.com/presentation/pptx/).

В приведенном ниже примере мы установили эффекты перехода.

```java
// Создайте экземпляр класса Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Установите эффект
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Запишите презентацию на диск
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```