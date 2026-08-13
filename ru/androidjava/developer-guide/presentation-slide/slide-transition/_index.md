---
title: "Управление переходами слайдов в презентациях на Android"
linktitle: "Переход слайда"
type: docs
weight: 80
url: /ru/androidjava/slide-transition/
keywords:
- "переход слайда"
- "добавить переход слайда"
- "применить переход слайда"
- "расширенный переход слайда"
- "переход Morph"
- "тип перехода"
- "эффект перехода"
- PowerPoint
- OpenDocument
- "презентация"
- Android
- Java
- Aspose.Slides
description: "Узнайте, как настроить переходы слайдов в Aspose.Slides для Android через Java, с пошаговыми инструкциями для презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Эта статья объясняет, как управлять переходами слайдов в презентациях с помощью Aspose.Slides. В ней показано, как применять типы переходов к слайдам, настраивать поведение переходов, например, переключение по щелчку или после указанного времени, использовать переход Morph и его типы, а также задавать параметры эффектов перехода. Примеры демонстрируют, как загрузить или создать презентацию, изменить настройки переходов для выбранных слайдов и сохранить результат в файл PPTX. Статья также отвечает на часто задаваемые вопросы о скорости перехода, звуках перехода, применении одинакового перехода к нескольким слайдам и проверке текущего перехода, установленного на слайде.

## **Добавить переход слайда**
Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Примените тип перехода Slide Transition Type к слайду, выбрав один из эффектов переходов, предлагаемых Aspose.Slides for Android via Java, через перечисление TransitionType.
1. Запишите изменённый файл презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Применить круговой тип перехода к слайду 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Применить тип перехода comb к слайду 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Записать презентацию на диск
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавить расширенный переход слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Теперь, чтобы сделать этот эффект более гибким и управляемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation).
1. Примените тип перехода Slide Transition Type к слайду, выбрав один из эффектов переходов, предлагаемых Aspose.Slides for Android via Java.
1. Вы также можете установить переход на переключение по щелчку, после определённого времени или оба варианта.
1. Если переход слайда включён для переключения по щелчку, переход будет происходить только при щелчке мышью. Кроме того, если свойство Advance After Time установлено, переход будет происходить автоматически после указанного промежутка времени.
1. Запишите изменённую презентацию как файл презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation, который представляет файл презентации
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Применить круговой тип перехода к слайду 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Переключать по щелчку или автоматически через 3 секунды
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Применить тип перехода comb к слайду 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Переключать по щелчку или автоматически через 5 секунд
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Применить переход типа zoom к слайду 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Переключать по щелчку или автоматически через 7 секунд
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Записать презентацию на диск
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Переход Morph**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/IMorphTransition). Это новые переходы Morph, представленные в PowerPoint 2019.

{{% /alert %}} 

Переход Morph позволяет анимировать плавное перемещение от одного слайда к другому. В этой статье описывается концепция и способы использования перехода Morph. Чтобы эффективно использовать переход Morph, вам нужны два слайда с хотя бы одним общим объектом. Самый простой способ — дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить копию слайда с некоторым текстом в презентацию и задать переход [morph type](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/TransitionType) для второго слайда.

```java
import com.aspose.slides.*;

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

## **Типы перехода Morph**
Новый перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/TransitionMorphType) было добавлено. Оно представляет различные типы перехода Morph для слайдов.

Перечисление TransitionMorphType имеет три члена:

- ByObject: Переход Morph будет выполнен с учётом фигур как неделимых объектов.
- ByWord: Переход Morph будет выполнен с переносом текста по словам, где это возможно.
- ByChar: Переход Morph будет выполнен с переносом текста по символам, где это возможно.

Следующий фрагмент кода показывает, как задать переход Morph для слайда и изменить тип Morph:

```java
import com.aspose.slides.*;

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
Aspose.Slides for Android via Java поддерживает установку эффектов переходов, таких как «из‑черного», «слева», «справа» и т.д. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию как файл [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

В примере ниже мы задали эффекты перехода.

```java
import com.aspose.slides.*;

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

### Могу ли я контролировать скорость воспроизведения перехода слайда?

Да. Установите [speed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) перехода с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionspeed/) (например, slow/medium/fast).

### Могу ли я добавить аудио к переходу и сделать его зацикленным?

Да. Вы можете встроить звук для перехода и управлять его поведением через такие параметры, как режим звука и зацикливание (например, [setSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), плюс метаданные, такие как [setSoundIsBuiltIn](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) и [setSoundName](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Какой самый быстрый способ применить один и тот же переход ко всем слайдам?

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам даст одинаковый результат.

### Как проверить, какой переход сейчас установлен на слайде?

Изучите [настройки перехода](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) слайда и прочитайте его [type](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); это значение точно указывает, какой эффект применён.