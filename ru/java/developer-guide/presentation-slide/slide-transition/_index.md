---
title: Управление переходами слайдов в презентациях с использованием Java
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/java/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- морф переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как настроить переходы слайдов в Aspose.Slides for Java, с пошаговыми инструкциями для презентаций PowerPoint и OpenDocument."
---

## **Обзор**
{{% alert color="primary" %}} 

Aspose.Slides for Java также позволяет разработчикам управлять или настраивать эффекты переходов слайдов. В этой статье мы расскажем о простом управлении переходами слайдов с помощью Aspose.Slides for Java.

{{% /alert %}} 

Для лучшего понимания мы продемонстрировали использование Aspose.Slides for Java для управления простыми переходами слайдов. Разработчики могут не только применять различные эффекты переходов к слайдам, но и настраивать их поведение.

## **Добавить переход слайда**
Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Примените тип перехода Slide Transition к слайду, выбрав один из эффектов перехода, предлагаемых Aspose.Slides for Java, через перечисление TransitionType.
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


## **Добавить расширенный переход слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Теперь, чтобы улучшить и более точно контролировать этот простой переход, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Примените тип перехода Slide Transition к слайду, выбрав один из эффектов перехода, предлагаемых Aspose.Slides for Java.
1. Вы также можете установить переход «Продвинуть по клику», после определённого времени или оба варианта одновременно.
1. Если переход слайда включён для «Продвинуть по клику», он будет осуществлён только после щелчка мышью. Кроме того, если задано свойство Advance After Time, переход произойдёт автоматически после указанного времени.
1. Запишите изменённую презентацию в файл презентации.
```java
// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Применить переход типа circle к слайду 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Установить время перехода в 3 секунды
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Применить переход типа comb к слайду 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Установить время перехода в 5 секунд
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Применить переход типа zoom к слайду 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Установить время перехода в 7 секунд
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Сохранить презентацию на диск
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Морф‑переход**
{{% alert color="primary" %}} 

Aspose.Slides for Java теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/java/com.aspose.slides/IMorphTransition). Это новый тип перехода, представленный в PowerPoint 2019.

{{% /alert %}} 

Морф‑переход позволяет анимировать плавное перемещение от одного слайда к другому. В этой статье рассматривается концепция и способы использования морф‑перехода. Для эффективного применения морф‑перехода вам понадобится две страницы с хотя бы одним общим объектом. Проще всего продублировать слайд и затем переместить объект на втором слайде в другое место.

Ниже приведён фрагмент кода, показывающий, как добавить клон слайда с некоторым текстом в презентацию и задать переход типа [morph](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionType) для второго слайда.
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


## **Типы морф‑переходов**
Новый перечисляемый тип [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/TransitionMorphType) был добавлен. Он представляет различные типы морф‑переходов слайдов.

Перечисление TransitionMorphType имеет три члена:

- ByObject: морф‑переход будет выполнен с учётом фигур как неделимых объектов.
- ByWord: морф‑переход будет выполнен с переносом текста по словам, где это возможно.
- ByChar: морф‑переход будет выполнен с переносом текста по символам, где это возможно.

Ниже приведён фрагмент кода, показывающий, как установить морф‑переход для слайда и изменить тип морфа:
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
Aspose.Slides for Java поддерживает установку эффектов перехода, таких как «из чёрного», «слева», «справа» и т.д. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию в файл [PPTX](https://docs.fileformat.com/presentation/pptx/).

В примере ниже мы задали эффекты перехода.
```java
// Создать экземпляр класса Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Установить эффект
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Сохранить презентацию на диск
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **FAQ**

**Можно ли контролировать скорость воспроизведения перехода слайда?**

Да. Установите [speed](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) перехода с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) (например, slow/medium/fast).

**Можно ли привязать аудио к переходу и зациклить его?**

Да. Вы можете встроить звук для перехода и управлять его поведением через параметры, такие как режим звука и зацикливание (например, [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), а также метаданные, такие как [setSoundIsBuiltIn](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) и [setSoundName](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Настройте нужный тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам даст одинаковый результат.

**Как проверить, какой переход сейчас установлен на слайде?**

Изучите [параметры перехода](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getSlideShowTransition--) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/java/com.aspose.slides/slideshowtransition/#setType-int-); это значение точно указывает, какой эффект применён.