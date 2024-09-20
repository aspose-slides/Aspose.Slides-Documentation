---
title: Переход слайдов
type: docs
weight: 80
url: /androidjava/slide-transition/
keywords: "Переход слайда PowerPoint, морфинг в Java"
description: "Переход слайда PowerPoint, морфинг слайда PowerPoint в Java"
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides для Android через Java также позволяет разработчикам управлять или настраивать эффекты перехода слайдов. В этой теме мы обсудим, как легко контролировать переходы слайдов с помощью Aspose.Slides для Android через Java.

{{% /alert %}} 

Чтобы облегчить понимание, мы продемонстрировали использование Aspose.Slides для Android через Java для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты перехода слайдов, но и настраивать поведение этих эффектов перехода.

## **Добавить переход слайда**
Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Примените тип перехода слайда из одного из эффектов перехода, предлагаемых Aspose.Slides для Android через Java через перечисление TransitionType.
1. Запишите измененный файл презентации.

```java
// Создайте экземпляр класса Presentation для загрузки исходного файла презентации
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Примените переход типа круг к слайду 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Примените переход типа комбинированный к слайду 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Запишите презентацию на диск
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавить продвинутый переход слайда**
В предыдущем разделе мы просто применили простой эффект перехода к слайду. Теперь, чтобы сделать этот простой эффект перехода еще лучше и более контролируемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Примените тип перехода слайда из одного из эффектов перехода, предлагаемых Aspose.Slides для Android через Java.
1. Вы также можете установить переход на "Продвигаться по клику", через определенный период времени или и то, и другое.
1. Если переход слайда включен для "Продвижения по клику", переход будет продвигаться только при щелчке мыши. Более того, если установлено свойство "Продвижение после времени", переход будет продвигаться автоматически после истечения указанного времени.
1. Запишите измененную презентацию в виде файла презентации.

```java
// Создайте экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Примените переход типа круг к слайду 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Установите время перехода 3 секунды
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Примените переход типа комбинированный к слайду 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Установите время перехода 5 секунд
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Примените переход типа масштабирование к слайду 3
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

## **Морфинг перехода**
{{% alert color="primary" %}} 

Aspose.Slides для Android через Java теперь поддерживает [Морфинг перехода](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Они представляют новый морфинг переход, представленный в PowerPoint 2019.

{{% /alert %}} 

Переход морфинга позволяет вам анимировать плавное движение от одного слайда к другому. В этой статье описывается концепция и то, как использовать переход морфинга. Чтобы эффективно использовать переход морфинга, вам потребуется два слайда с хотя бы одним общим объектом. Самый простой способ - дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с текстом в презентацию и установить переход [типа морфинг](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) для второго слайда.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Переход морфинга в презентациях PowerPoint");

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

## **Типы перехода морфинга**
Новое перечисление [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) было добавлено. Оно представляет различные типы перехода морфинга слайдов.

У перечисления TransitionMorphType три члена:

- По объекту: Переход морфинга будет выполняться с учетом фигур как неделимых объектов.
- По словам: Переход морфинга будет выполняться с передачей текста по словам, где это возможно.
- По символам: Переход морфинга будет выполняться с передачей текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить переход морфинга на слайд и изменить тип морфинга:

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

## **Установка эффектов перехода**
Aspose.Slides для Android через Java поддерживает установку эффектов перехода, таких как "из черного", "слева", "справа" и т.д. Чтобы установить эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию как файл [PPTX ](https://docs.fileformat.com/presentation/pptx/).

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