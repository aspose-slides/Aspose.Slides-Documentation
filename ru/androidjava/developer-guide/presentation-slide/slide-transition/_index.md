---
title: Управление переходами слайдов в презентациях на Android
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/androidjava/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- морф-переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Узнайте, как настраивать переходы слайдов в Aspose.Slides для Android через Java, с пошаговыми инструкциями для презентаций PowerPoint и OpenDocument."
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java также позволяет разработчикам управлять или настраивать эффекты переходов слайдов. В этой теме мы обсудим управление переходами слайдов с большой легкостью, используя Aspose.Slides for Android via Java.

{{% /alert %}} 

Чтобы было проще понять, мы продемонстрировали использование Aspose.Slides for Android via Java для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты переходов к слайдам, но и настраивать поведение этих эффектов переходов.

## **Добавление перехода слайда**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Примените тип перехода слайда к слайду, выбрав один из эффектов перехода, предлагаемых Aspose.Slides for Android via Java через перечисление TransitionType.
1. Запишите изменённый файл презентации.
```java
// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Применить переход типа circle к слайду 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Применить переход типа comb к слайду 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Сохранить презентацию на диск
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **Добавление расширенного перехода слайда**
1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).
1. Примените тип перехода слайда к слайду, выбрав один из эффектов перехода, предлагаемых Aspose.Slides for Android via Java.
1. Вы также можете установить переход на «Продвижение по щелчку», через определённый промежуток времени или оба варианта.
1. Если переход слайда настроен на «Продвижение по щелчку», он будет продвигаться только при щелчке мышью. Кроме того, если установлен параметр «Advance After Time», переход будет происходить автоматически после истечения указанного времени.
1. Запишите изменённую презентацию в файл презентации.
```java
// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Применить переход типа circle к слайду 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Установить время перехода 3 секунды
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Применить переход типа comb к слайду 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Установить время перехода 5 секунд
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Применить переход типа zoom к слайду 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Установить время перехода 7 секунд
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Сохранить презентацию на диск
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Morph‑переход**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMorphTransition). Они представляют новый Morph‑переход, введённый в PowerPoint 2019.

{{% /alert %}} 

Morph‑переход позволяет анимировать плавное перемещение от одного слайда к другому. Эта статья описывает концепцию и способы использования Morph‑перехода. Для эффективного использования Morph‑перехода вам понадобится два слайда, имеющие минимум один общий объект. Самый простой способ – продублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и установить переход [morph type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionType) для второго слайда.
```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

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


## **Типы Morph‑переходов**
Новый перечисление [TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TransitionMorphType) добавлен. Оно представляет различные типы Morph‑переходов слайда.

TransitionMorphType enum имеет три члена:
- ByObject: Morph‑переход будет выполнен с учётом фигур как неделимых объектов.
- ByWord: Morph‑переход будет выполнен с передачей текста по словам, где это возможно.
- ByChar: Morph‑переход будет выполнен с передачей текста по символам, где это возможно.

Следующий фрагмент кода показывает, как установить Morph‑переход для слайда и изменить тип Morph:
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
Aspose.Slides for Android via Java поддерживает установку эффектов перехода, таких как «из чёрного», «слева», «справа» и т.д. Чтобы установить эффект перехода, выполните следующие шаги:
- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию в файл [PPTX ](https://docs.fileformat.com/presentation/pptx/).

В приведённом ниже примере мы установили эффекты перехода.
```java
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Установить эффект
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Записать презентацию на диск
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) перехода с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (например, slow/medium/fast).

**Можно ли прикрепить аудио к переходу и установить его зациклить?**

Да. Вы можете внедрить звук для перехода и управлять его поведением с помощью настроек, таких как режим звука и зацикливание (например, [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), а также метаданные, такие как [setSoundIsBuiltIn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) и [setSoundName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Какой самый быстрый способ применить один и тот же переход ко всем слайдам?**

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам дает единый результат.

**Как проверить, какой переход сейчас установлен на слайде?**

Посмотрите параметры [transition settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); это значение точно указывает, какой эффект применён.