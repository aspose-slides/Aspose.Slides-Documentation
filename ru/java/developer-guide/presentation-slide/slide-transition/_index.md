---
title: Управление переходами между слайдами в презентациях с помощью Java
linktitle: Переход между слайдами
type: docs
weight: 80
url: /ru/java/slide-transition/
keywords:
- переход между слайдами
- добавить переход между слайдами
- применить переход между слайдами
- расширенный переход между слайдами
- переход Morph
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Применяйте переходы между слайдами, настраивайте автоматическое переключение слайдов и кастомизируйте переход Morph и другие эффекты переходов с помощью Aspose.Slides for Java."
---
## **Обзор**

Переходы между слайдами управляют тем, как слайды отображаются во время показа. С помощью Aspose.Slides for Java вы можете выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или таймеру, а также скорректировать параметры, специфичные для эффекта. В этой статье используются примеры на Java для применения переходов, установки точных длительностей переходов, управления временем показа слайдов и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавление перехода между слайдами**

Чтобы применить переход, загрузите презентацию с помощью класса [Презентация](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Используйте [setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setType-int-) с значением из перечисления [TransitionType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

## **Добавление расширенного перехода между слайдами**

Вы можете настроить, как долго слайд остаётся на экране и будет ли переключение презентации происходить по щелчку мыши. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) позволяет зрителю перейти к следующему слайду при щелчке мышью.
- [setAdvanceAfter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) включает автоматическое переключение.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) устанавливает задержку перед автоматическим переключением в миллисекундах.

Включите как переход по щелчку, так и по таймеру, чтобы зритель мог перейти к следующему слайду щелчком или ждать окончания таймера. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick]. Задержка определяет, когда происходит переключение презентации; она не задаёт длительность визуального эффекта перехода.

В этом примере различным эффектам назначаются первые три слайда, а автоматическое переключение включено через 3, 5 и 7 секунд соответственно. Щелчки мышью также могут переключать эти слайды. Используйте файл `input.pptx` с минимум тремя слайдами.

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

Чтобы проверить, включено ли автоматическое переключение по таймеру, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Хранящаяся задержка сама по себе не означает, что таймер активен.

В следующем примере открывается ранее сохранённый файл, выводятся сведения о каждом включённом таймере, а автоматическое переключение отключается для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, и обновлённые настройки сохраняются.

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

Используйте [setDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setDuration-int-) для указания точной продолжительности эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) слайда предоставляет эти настройки через [ISlideShowTransition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Устанавливает задержку перед автоматическим переключением слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-), чтобы активировать этот таймер. |
| [setSpeed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration] управляет только эффектом перехода; она не определяет, как долго слайд остаётся видимым. Задержку автоматического переключения настраивают отдельно. Если явная длительность не задана, Aspose.Slides определяет длительность эффекта исходя из типа перехода и значения [getSpeed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#getSpeed--).

### **Применить одинаковую длительность ко всем слайдам**

Для равномерного темпа примените один и тот же эффект и точную длительность ко всем слайдам. В этом примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitiontype/), и каждой переходу задаётся длительность 750 миллисекунд. Затем отдельно включается автоматическое переключение через 5 000 миллисекунд и отключается переключение по щелчку мышью, после чего результат сохраняется в виде PPTX.

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

Разные слайды могут иметь разные длительности эффектов. Например, использовать короткий переход для титульного слайда и более длительный переход для введения раздела. В этом примере задаются 500 миллисекунд для первого слайда и 1 200 миллисекунд для второго. Используйте файл `input.pptx` с минимум двумя слайдами.

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

При подготовке [animated GIF](/slides/ru/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/java/export-to-html5/) или [video](/slides/ru/java/convert-powerpoint-to-video/) задайте точные длительности переходов перед экспортом, чтобы соответствовать желаемому темпу. Например, используйте затухание в 600 миллисекунд между сценами и отдельно настройте задержку переключения каждого слайда, чтобы обеспечить время для озвучки или содержимого.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 кадрах в секунду. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте, какие эффекты и параметры времени поддерживаются выбранным форматом экспорта, и предварительно просмотрите результат, чтобы убедиться в синхронизации.

### **Чтение существующей длительности перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#getDuration--) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#getSpeed--) для определения этой длительности. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

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

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в клоне и примените переход Morph ко второму слайду. Это позволяет анимировать соответствующие объекты между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, этот слайд клонируется, а позиция и размер прямоугольника изменяются в клоне. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя по словам, где это возможно.
- [ByChar](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя по символам, где это возможно.

Используйте [setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setType-int-) для выбора Morph перед вызовом [getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#getValue--). Полученное значение предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imorphtransition/), метод [setMorphType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/imorphtransition/#setMorphType-int-) которого выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для использования анимации Morph на уровне слов.

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

## **Установка эффектов переходов**

Некоторые переходы предоставляют дополнительные параметры, такие как направление или начало эффекта с черного экрана. Доступные параметры зависят от перехода, выбранного с помощью [setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setType-int-). Сначала задайте тип, затем используйте соответствующий интерфейс из [getValue](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#getValue--).

В следующем примере к первому слайду `input.pptx` применяется переход Cut. Через [IOptionalBlackTransition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ioptionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-), чтобы переход начинался с черного экрана.

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

**Могу ли я управлять скоростью воспроизведения перехода слайда?**

Да. Предпочтительно используйте [setDuration](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setDuration-int-), когда требуется точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setSpeed-int-), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки управляют эффектом перехода независимо от задержки автоматического переключения.

**Могу ли я прикрепить звук к переходу и заставить его зацикливаться?**

Да. Назначьте встроенный звук с помощью [setSound](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), передайте значение StartSound из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), и включите [setSoundLoop](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) со значением `true`. Звук будет зацикливаться до следующего звукового события в показе.

**Как наиболее быстро применить один и тот же переход ко всем слайдам?**

Пройдитесь в цикле по коллекции [getSlides](https://reference.aspose.com/slides/ru/java/com.aspose.slides/presentation/#getSlides--) презентации и вызовите [setType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#setType-int-) с одинаковым значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы обеспечить одинаковое поведение на всех слайдах.

**Как проверить, какой переход установлен на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/islideshowtransition/#getType--) у результата [getSlideShowTransition](https://reference.aspose.com/slides/ru/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) слайда. Он возвращает значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/java/com.aspose.slides/transitiontype/); None означает, что переход не применён.