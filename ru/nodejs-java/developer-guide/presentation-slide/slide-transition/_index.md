---
title: Управление переходами слайдов в презентациях с использованием JavaScript
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/nodejs-java/slide-transition/
keywords:
  - переход слайда
  - добавить переход слайда
  - применить переход слайда
  - расширенный переход слайда
  - переход Morph
  - тип перехода
  - эффект перехода
  - PowerPoint
  - OpenDocument
  - презентация
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте Morph и другие эффекты переходов с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время показа слайдов. С помощью Aspose.Slides for Node.js via Java вы можете выбрать эффект перехода для каждого слайда, настроить переход по щелчку мыши или таймеру и задать параметры, специфичные для эффекта. В этой статье используются примеры на JavaScript для применения переходов, установки точных длительностей переходов, управления временем слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/) и получите настройки перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте [setType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере применяется переход Circle к первому слайду и переход Comb ко второму. Используйте файл `input.pptx` с как минимум двумя слайдами.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Добавить расширенный переход слайда**

Вы можете настроить, как долго слайд остаётся на экране и будет ли щелчок мыши переводить показ слайдов вперёд. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет зрителю переходить вперёд по щелчку мыши.  
- [setAdvanceAfter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматический переход.  
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите одновременно переход по щелчку и по таймеру, чтобы зритель мог перейти по щелчку или дождаться таймера. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка управляет моментом перехода показа слайдов; она не задаёт длительность визуального эффекта перехода.

В этом примере различным первым трём слайдам задаются разные эффекты и включается автоматический переход через 3, 5 и 7 секунд соответственно. По щелчку мыши эти слайды также могут продвигаться. Используйте файл `input.pptx` с как минимум тремя слайдами.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Чтобы проверить, включён ли автоматический переход по таймеру, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Хранёная задержка сама по себе не указывает, что таймер активен.

Следующий пример открывает файл, сохранённый выше, выводит информацию о каждом включённом таймере и отключает автоматический переход для слайдов, у которых задержка превышает две секунды. Для этих слайдов включается переход по щелчку, после чего настройки сохраняются.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Точно контролировать время перехода**

Используйте [setDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setDuration), чтобы задать точную длительность эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) у слайда раскрывает эти настройки через объект [SlideShowTransition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/):

| Метод | Описание |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Задаёт длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Задаёт задержку перед автоматическим переходом слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать этот таймер. |
| [setSpeed](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда конкретная длительность не указана. |

[setDuration] управляет только эффектом перехода; она не определяет, как долго слайд остаётся видимым. Задержку автоматического перехода необходимо настраивать отдельно. Если явная длительность не задана, Aspose.Slides определяет длительность эффекта по типу перехода и значению [getSpeed].

### **Применить одинаковую длительность к каждому слайду**

Для согласованного темпа применяйте один и тот же эффект и точную длительность ко всем слайдам. В этом примере загружается `input.pptx`, выбирается Fade из [TransitionType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitiontype/), и каждой переходу задаётся длительность 750 миллисекунд. Автоматический переход включается через 5 000 миллисекунд, а переход по щелчку отключается, после чего результат сохраняется в PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Настройте автоматическое продвижение независимо от длительности эффекта.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Установить различные длительности для отдельных слайдов**

Разные слайды могут использовать разные длительности эффектов. Например, можно задать короткий переход для титульного слайда и более длительный для введения раздела. В примере задаются 500 миллисекунд для первого слайда и 1 200 миллисекунд для второго. Используйте файл `input.pptx` с как минимум двумя слайдами.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Координировать переходы с анимированным выводом**

При подготовке [animated GIF](/slides/ru/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/nodejs-java/export-to-html5/) или [video](/slides/ru/nodejs-java/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы они соответствовали задуманному темпу. Например, используйте плавное исчезновение (fade) длительностью 600 мс между сценами и отдельно регулируйте задержку продвижения каждого слайда, чтобы оставить время для озвучивания или контента.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 кадрах в секунду. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры тайминга выбранного формата и просмотрите результат, чтобы убедиться в синхронности.

### **Прочитать существующую длительность перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#getDuration) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что явная длительность не задана; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed] для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала изучите оригинальные настройки.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph Transition**

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта в клоне и примените переход Morph ко второму слайду. Это даёт переходу соответствующие объекты для анимации между их исходным и изменённым состояниями.

В следующем примере создаётся слайд с текстовым прямоугольником, клонируется слайд и меняются позиция и размер прямоугольника в клоне. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике презентаций, поддерживающем Morph, чтобы увидеть эффект во время показа слайдов.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Типы перехода Morph**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitionmorphtype/) определяет, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как единый объект.  
- [ByWord](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.  
- [ByChar](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя отдельные символы, где это возможно.

Сначала используйте [setType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setType) для выбора Morph, а затем получайте значение через [getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#getValue). Полученный объект представляет собой [MorphTransition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/morphtransition/), у которого метод [setMorphType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/morphtransition/#setMorphType) выбирает режим сопоставления.

В этом примере открывается презентация, созданная в предыдущем разделе, и для второго слайда настраивается анимация Morph на основе слов.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Установить эффекты перехода**

Некоторые переходы раскрывают дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от перехода, выбранного с помощью [setType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setType). Сначала задайте тип, затем используйте соответствующий объект перехода, полученный через [getValue](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#getValue).

В следующем примере применяется переход Cut к первому слайду `input.pptx`. Через [OptionalBlackTransition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/optionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack), чтобы переход начинался с чёрного экрана.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Могу ли я контролировать скорость воспроизведения перехода слайда?**

Да. Предпочитайте [setDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setDuration), когда нужна точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast — и явная длительность не задаётся. Эти настройки управляют эффектом перехода независимо от задержки автоматического продвижения.

**Можно ли прикрепить звук к переходу и включить его зацикливание?**

Да. Присвойте встроенный звук через [setSound](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setSound), передайте `StartSound` из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) и включите [setSoundLoop](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) значением `true`. Звук будет повторяться до следующего звукового события в показе слайдов.

**Как самый быстрый способ применить один и тот же переход ко всем слайдам?**

Пройдитесь в цикле по коллекции [getSlides](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/presentation/#getSlides) презентации и вызовите [setType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#setType) с тем же значением для перехода каждого слайда. В том же цикле задайте любые параметры времени и эффекта, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход сейчас установлен у слайда?**

Вызовите [getType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/slideshowtransition/#getType) у результата [getSlideShowTransition](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Он возвращает значение из перечисления [TransitionType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/transitiontype/); `None` означает, что никакой эффект перехода не применён.