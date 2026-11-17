---
title: Управление переходами слайдов в презентациях с помощью Java
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/java/slide-transition/
keywords:
- переход слайда
- добавить переход слайда
- применить переход слайда
- расширенный переход слайда
- Morph переход
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое переключение слайдов и настраивайте Morph и другие эффекты переходов с помощью Aspose.Slides для Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время показа. С помощью Aspose.Slides for Java вы можете выбирать эффект перехода для каждого слайда, настраивать переключение по щелчку мыши или таймеру и задавать параметры, характерные для конкретного эффекта. В этой статье используются примеры на Java для применения переходов, установки точных длительностей переходов, управления временем показа слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавление перехода слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Используйте [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` с минимум двумя слайдами.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Переход «Колесо»**

Метод [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) интерфейса [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) управляет числом радиальных секторов, открывающих целевой слайд. Установите тип перехода слайда в Wheel с помощью [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) из [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), затем получите значение через [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) как [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

Этот пример создает две одинаковые пары слайдов: черный слайд, за которым следует слайд с золотым прямоугольником. В целевых слайдах количество спиц — 1 и 8, одинаковая скорость задается через [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-), а явная длительность — 8 000 мс, установленная через [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-), чтобы разницу было легко заметить.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Откройте полученную презентацию в PowerPoint и запустите показ. Перейдите со слайда 1 на слайд 2, затем со слайда 3 на слайд 4. При воспроизведении в PowerPoint проверенное значение спиц 1 открывает слайд одним вращением по часовой стрелке; значение 8 открывает его через восемь радиальных секторов одновременно. Содержимое назначения и время перехода одинаковы, различие только в числе секторов раскрытия.

## **Продвинутый переход слайда**

Вы можете задать, как долго слайд остаётся на экране и будет ли переход осуществляться щелчком мыши. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) позволяет зрителю перейти по щелчку мыши.  
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) включает автоматическое переключение.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) задаёт задержку перед автоматическим переключением в миллисекундах.

Включите одновременно переключение по щелчку и по таймеру, чтобы зритель мог перейти кликом или дождаться таймера. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Задержка определяет, когда показы переключаются; она не задаёт длительность визуального эффекта перехода.

В этом примере разным первым трём слайдам назначаются разные эффекты и включается автоматическое переключение через 3, 5 и 7 секунд соответственно. По щелчку мыши эти слайды также могут переключаться. Используйте файл `input.pptx` с минимум тремя слайдами.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Чтобы проверить, включено ли автоматическое переключение по таймеру, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Хранимая задержка сама по себе не указывает, активен ли таймер.

Следующий пример открывает сохранённый выше файл, сообщает о каждом включённом таймере и отключает автоматическое переключение для слайдов с задержкой более двух секунд. Для этих слайдов включается переключение по щелчку, после чего настройки сохраняются.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Точное управление временем перехода**

Используйте [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) для задания точной длительности эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) слайда раскрывает эти настройки через интерфейс [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Задаёт задержку перед автоматическим переключением слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) для активации таймера. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического переключения необходимо настраивать отдельно. Когда явная длительность не указана, Aspose.Slides вычисляет её из типа перехода и значения [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Отдельные полосы указывают длительность перехода 750 мс и настройку автоматического переключения 5 000 мс.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*В примере каждому слайду задаётся 750‑мс переход Fade, а автоматическое переключение включено через 5 000 мс. Длительность перехода контролирует эффект; переключение определяет, когда покидать слайд. Эти полосы являются схематичными настройками, а не измеренной комбинированной шкалой времени.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Для единообразного темпа примените одинаковый эффект и точную длительность ко всем слайдам. В этом примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), каждому переходу задаётся длительность 750 мс, автоматически включается переключение через 5 000 мс и отключается переключение по щелчку, после чего результат сохраняется как PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Настройте автоматическое переключение независимо от длительности эффекта.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Установить разные длительности для отдельных слайдов**

Разные слайды могут иметь разные длительности эффектов. Например, использовать короткий переход для титульного слайда и более длительный для введения раздела. В этом примере первой слайд получает 500 мс, а второй — 1 200 мс. Используйте файл `input.pptx` с минимум двумя слайдами.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Координация переходов с анимированным выводом**

При подготовке [animated GIF](/slides/ru/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/java/export-to-html5/) или [video](/slides/ru/java/convert-powerpoint-to-video/) задайте точные длительности переходов перед экспортом, чтобы соответствовать задуманному темпу. Например, используйте 600‑мс плавный переход между сценами и отдельно настраивайте задержку переключения каждого слайда, чтобы обеспечить время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс ≈ 18 кадров при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и предварительно просмотрите результат для подтверждения синхронизации.

### **Чтение существующей длительности перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение — это не рассчитанная длительность воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала изучите исходные настройки.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Переход Morph**

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в клоне и примените переход Morph ко второму слайду. Это даёт анимацию соответствующих объектов между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, клонируется, а в клоне меняются позиция и размер прямоугольника. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Типы перехода Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как целый объект.  
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.  
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя отдельные символы.

Используйте [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-), чтобы выбрать Morph, затем обратитесь к [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) для получения интерфейса [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/), чей метод [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) задаёт режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для использования анимации Morph по словам.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Установить эффекты перехода**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного через [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) типа. Сначала задайте тип, затем используйте соответствующий интерфейс, полученный через [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

В следующем примере к первому слайду `input.pptx` применяется переход Cut. Через [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-), чтобы переход начинался с чёрного экрана.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Можно ли управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно использовать [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-), когда требуется точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-), если достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического переключения.

**Можно ли прикрепить звук к переходу и сделать его зацикленным?**

Да. Назначьте встроенный звук через [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), и включите [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) со значением `true`. Звук будет повторяться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь циклом по коллекции [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) презентации и вызовите [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) с тем же значением для перехода каждого слайда. В том же цикле задайте любые параметры времени и эффекта, чтобы поведение оставалось одинаковым на всех слайдах.

**Как проверить, какой переход установлен на текущем слайде?**

Вызовите [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) у результата [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) слайда. Метод вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); `None` означает, что переход не установлен.