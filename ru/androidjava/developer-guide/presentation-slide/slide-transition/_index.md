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
- переход morph
- тип перехода
- эффект перехода
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Применяйте переходы слайдов, настройте автоматический переход между слайдами и настраивайте Morph и другие эффекты переходов с помощью Aspose.Slides for Android via Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время показа. С помощью Aspose.Slides for Android via Java вы можете выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или таймеру и задать параметры, специфичные для эффекта. В этой статье используются примеры на Java для применения переходов, установки точных длительностей переходов, управления временем показа слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавление перехода слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Презентация](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/) и получите доступ к настройкам перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Используйте [setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере к первому слайду применяется переход Circle, а ко второму — Comb. Используйте файл `input.pptx` с как минимум двумя слайдами.

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

## **Добавление расширенного перехода слайда**

Можно настроить, как долго слайд остаётся на экране и будет ли щелчок мыши продвигать показ. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) позволяет зрителю переходить по щелчку мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) включает автоматический переход.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите оба способа — по щелчку и по таймеру, чтобы зритель мог перейти щелчком либо подождать таймер. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Задержка управляет моментом перехода; она не задаёт длительность визуального эффекта перехода.

В этом примере разным эффектам присваиваются первые три слайда, а автоматический переход включён через 3, 5 и 7 секунд соответственно. Щелчками мыши также можно переходить между этими слайдами. Используйте файл `input.pptx` с как минимум тремя слайдами.

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

Чтобы проверить, включён ли автоматический переход, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Хранение задержки само по себе не указывает, активен ли таймер.

В следующем примере открывается файл, сохранённый выше, выводятся все включённые таймеры и отключается автоматический переход для слайдов с задержкой более двух секунд. Для этих слайдов включаются щелчки мышью, после чего сохраняются обновлённые настройки.

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

Используйте [setDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) для указания точной длительности эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) слайда раскрывает эти настройки через [ISlideShowTransition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Задаёт задержку перед автоматическим переходом слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) для активации таймера. |
| [setSpeed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не указана. |

[setDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического перехода настраивайте отдельно. Если явная длительность не задана, Aspose.Slides определяет её из типа перехода и значения [getSpeed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) .

### **Применить одинаковую длительность ко всем слайдам**

Для равномерного темпа применяйте один и тот же эффект и точную длительность ко всем слайдам. В этом примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitiontype/), и каждой переходу задаётся длительность 750 мс. Автоматический переход включён через 5 000 мс, а переход по щелчку мыши отключён; результат сохраняется в PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Настройте автоматический переход независимо от длительности эффекта.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Установка разных длительностей для отдельных слайдов**

Разные слайды могут иметь разные длительности эффектов. Например, короткий переход для титульного слайда и более длительный — для введения раздела. В примере первой слайд получает 500 мс, второй — 1 200 мс. Используйте файл `input.pptx` с минимум двумя слайдами.

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

При подготовке [animated GIF](/slides/ru/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/androidjava/export-to-html5/) или [video](/slides/ru/androidjava/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы соответствовать задуманному темпу. Например, используйте 600‑миллисекундный fade между сценами и отдельно регулируйте задержку перехода каждого слайда, чтобы было время для озвучки или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс ≈ 18 кадров при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры времени выбранного формата и просмотрите результат, чтобы убедиться в синхронности.

### **Чтение существующей длительности перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что длительность не задана явно; неотрицательное значение указывает хранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) для её вычисления. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте оригинальные настройки.

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

В следующем примере создаётся слайд с текстовым прямоугольником, он клонируется, а позиция и размер прямоугольника изменяются в копии. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа.

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

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionmorphtype/) задаёт, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как целый объект.
- [ByWord](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя отдельные символы.

Используйте [setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) для выбора Morph перед обращением к [getValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Полученное значение предоставляет интерфейс [IMorphTransition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imorphtransition/), у которого метод [setMorphType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и настраивается второй слайд для анимации Morph по словам.

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

## **Установка эффектов перехода**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от перехода, выбранного через [setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Сначала задайте тип, затем используйте соответствующий интерфейс, полученный через [getValue](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

В следующем примере к первому слайду `input.pptx` применяется переход Cut. Через [IOptionalBlackTransition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioptionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-), чтобы переход начинался с чёрного экрана.

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

Да. Предпочитайте [setDuration](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-), когда требуется точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-), если достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки контролируют только эффект перехода, независимо от задержки автоматического перехода.

**Можно ли привязать звук к переходу и зациклить его?**

Да. Назначьте встроенный звук с помощью [setSound](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), и включите [setSoundLoop](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) со значением `true`. Звук будет повторяться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь по коллекции [getSlides](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/presentation/#getSlides--) презентации и вызовите [setType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) с тем же значением для перехода каждого слайда. Установите любые параметры времени и эффекта в том же цикле, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход сейчас установлен на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/islideshowtransition/#getType--) у результата [getSlideShowTransition](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) слайда. Метод вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/androidjava/com.aspose.slides/transitiontype/); `None` означает, что переход не установлен.