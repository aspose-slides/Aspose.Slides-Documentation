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
- морф‑переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как настраивать переходы слайдов в Aspose.Slides для Java, с пошаговым руководством для презентаций PowerPoint и OpenDocument."
---
## **Обзор**

Эта статья объясняет, как управлять переходами слайдов в презентациях с помощью Aspose.Slides. В ней показано, как применять типы переходов к слайдам, настраивать поведение перехода, например, переход по щелчку или после указанного времени, проверять и отключать автоматический переход, использовать морф‑переход и его типы, а также задавать параметры эффекта перехода. Примеры демонстрируют, как загрузить или создать презентацию, изменить настройки переходов для выбранных слайдов и сохранить результат в файл PPTX. Статья также отвечает на часто задаваемые вопросы о скорости переходов, звуках переходов, применении одного и того же перехода к нескольким слайдам и проверке текущего перехода на слайде.

## **Добавить переход слайда**
Чтобы создать простой эффект перехода слайда, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
2. Примените тип перехода Slide Transition Type к слайду, используя один из переходов, предлагаемых Aspose.Slides for Java через перечисление TransitionType.
3. Запишите изменённый файл презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation для загрузки исходного файла презентации
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Применить круговой тип перехода на слайде 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Применить тип перехода comb на слайде 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Записать презентацию на диск
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Добавить расширенный переход слайда**
В предыдущем разделе мы применили простой эффект перехода к слайду. Теперь, чтобы сделать этот простой переход более гибким и управляемым, выполните следующие шаги:

1. Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation).
2. Примените тип перехода Slide Transition Type к слайду, используя один из переходов, предлагаемых Aspose.Slides for Java.
3. Вы также можете установить переход на «Продвинуть по щелчку», после определённого промежутка времени или оба параметра одновременно.
4. Если переход слайда включён для «Продвинуть по щелчку», переход будет осуществлён только после щелчка мышью. Кроме того, если установлен параметр Advance After Time, переход произойдёт автоматически после истечения указанного времени.
5. Запишите изменённую презентацию в файл презентации.

```java
import com.aspose.slides.*;

// Создать экземпляр класса Presentation, представляющего файл презентации
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Применить круговой тип перехода на слайде 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Установить время перехода 3 секунды
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Применить тип перехода comb на слайде 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Установить время перехода 5 секунд
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Применить тип перехода зум на слайде 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Установить время перехода 7 секунд
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Записать презентацию на диск
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph Transition**
{{% alert color="info" %}} 

Aspose.Slides for Java теперь поддерживает [Morph Transition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/IMorphTransition). Это новый морф‑переход, представленный в PowerPoint 2019.

{{% /alert %}} 

Морф‑переход позволяет анимировать плавное перемещение от одного слайда к другому. В этой статье описывается концепция и способы использования морф‑перехода. Чтобы эффективно использовать морф‑переход, вам нужны два слайда с хотя бы одним общим объектом. Самый простой способ — дублировать слайд, а затем переместить объект на втором слайде в другое место.

Следующий фрагмент кода показывает, как добавить клон слайда с некоторым текстом в презентацию и задать переход типа [morph type](https://reference.aspose.com/slides/ru/java/com.aspose.slides/TransitionType) для второго слайда.

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

## **Типы морф‑переходов**
Новый перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/TransitionMorphType) был добавлен. Оно представляет различные типы морф‑переходов слайда.

Перечисление TransitionMorphType содержит три члена:

- ByObject: морф‑переход будет выполнен с учётом фигур как неделимых объектов.
- ByWord: морф‑переход будет выполнен с переносом текста по словам, где это возможно.
- ByChar: морф‑переход будет выполнен с переносом текста по символам, где это возможно.

Следующий фрагмент кода показывает, как задать морф‑переход для слайда и изменить тип морфа:

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
Aspose.Slides for Java поддерживает настройку эффектов перехода, таких как «из чёрного», «слева», «справа» и др. Чтобы задать эффект перехода, выполните следующие шаги:

- Создайте экземпляр класса [Presentation](https://reference.aspose.com/slides/ru/java/com.aspose.slides/Presentation).
- Получите ссылку на слайд.
- Установите эффект перехода.
- Запишите презентацию как [PPTX](https://docs.fileformat.com/presentation/pptx/) файл.

В приведённом ниже примере мы задали эффекты перехода.

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

### Можно ли контролировать скорость воспроизведения перехода слайда?

Да. Установите [speed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) перехода с помощью настройки [TransitionSpeed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionspeed/) (например, slow/medium/fast).

### Можно ли прикрепить аудио к переходу и сделать его зацикленным?

Да. Вы можете встроить звук для перехода и управлять поведением через настройки, такие как режим звука и зацикливание (например, [setSound](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), а также метаданные, такие как [setSoundIsBuiltIn](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) и [setSoundName](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Как быстрее всего применить один и тот же переход ко всем слайдам?

Настройте желаемый тип перехода в параметрах перехода каждого слайда; переходы хранятся отдельно для каждого слайда, поэтому применение одного и того же типа ко всем слайдам даст одинаковый результат.

### Как проверить, какой переход в данный момент установлен на слайде?

Изучите [transition settings](https://reference.aspose.com/slides/ru/java/com.aspose.slides/baseslide/#getSlideShowTransition--) слайда и прочитайте его [transition type](https://reference.aspose.com/slides/ru/java/com.aspose.slides/slideshowtransition/#setType-int-); это значение точно указывает, какой эффект применён.