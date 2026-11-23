---
title: Управление переходами слайдов в презентациях с помощью JavaScript
linktitle: Переход слайда
type: docs
weight: 80
url: /ru/nodejs-java/slide-transition/
keywords:
- переход слайда
- добавление перехода слайда
- применение перехода слайда
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
description: "Применяйте переходы слайдов, настраивайте автоматическое продвижение слайдов и кастомизируйте переход Morph и другие эффекты переходов с помощью Aspose.Slides for Node.js via Java."
---
## **Обзор**

Переходы слайдов управляют тем, как слайды появляются во время показа. С помощью Aspose.Slides for Node.js via Java вы можете выбрать эффект перехода для каждого слайда, настроить переход по клику мыши или таймеру и задать параметры, специфичные для эффекта. Эта статья использует примеры JavaScript для применения переходов, установки точных длительностей переходов, управления временем слайда и создания перехода Morph между двумя слайдами. Примеры также показывают, как сохранить настройки в файл PPTX.

## **Добавить переход слайда**

Чтобы применить переход, загрузите презентацию с помощью класса [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) и получите настройки перехода слайда через [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Используйте [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) со значением из перечисления [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), затем сохраните презентацию.

В следующем примере к первому слайду применяется переход Circle, а ко второму — Comb. Используйте файл `input.pptx` минимум с двумя слайдами.

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

## **Wheel Transition**

Метод [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) класса [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) управляет числом радиальных секторов, раскрывающих целевой слайд. Установите тип перехода слайда в Wheel через [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) с помощью [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) перед получением [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) как [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Этот пример создаёт две одинаковые пары слайдов: чёрный слайд, за которым следует слайд с золотым прямоугольником. У целевых слайдов количество спиц — 1 и 8, скорость задаётся через [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), а продолжительность — 8 000 мс через [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) для наглядного сравнения.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Откройте полученную презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, затем со слайда 3 на слайд 4. При воспроизведении в PowerPoint проверенное значение спиц = 1 раскрывает слайд одним вращением по часовой стрелке; значение = 8 — через восемь радиальных секторов одновременно. Содержимое целевых слайдов и тайминг переходов одинаковы, различается лишь число секторов раскрытия.

## **Fade Through Black с переходом Reveal**

Установите тип перехода целевого слайда в Reveal, затем вызовите [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) у его настроек [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/). Этот пример создаёт бирюзовый исходный слайд и коралловый целевой слайд, затем клонирует оба. Каждая пара использует одинаковый двухсекундный переход Reveal. Только вторая пара переходит через чёрный цвет.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Откройте сохранённую презентацию в PowerPoint и запустите показ слайдов. Перейдите со слайда 1 на слайд 2, чтобы увидеть плавный переход бирюзового в коралловый без чёрного. Затем перейдите со слайда 3 на слайд 4. Экран на мгновение затемняется почти до чёрного, после чего появляется коралловый слайд. Оба слайда сохраняют исходные цвета фона.

Ниже показаны кадры из PowerPoint с полусекундными интервалами. Сравните центральный кадр в каждой строке, чтобы увидеть эффект.

![PowerPoint playback with the fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **Добавить расширенный переход слайда**

Вы можете настроить, как долго слайд остаётся на экране и будет ли переход осуществляться по клику мыши. Следующие методы управляют этим поведением:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) позволяет зрителю перейти по клику мыши.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) включает автоматический переход.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) задаёт задержку перед автоматическим переходом в миллисекундах.

Включите как кликовый, так и таймерный переход, чтобы зритель мог продолжить по нажатию или ждать таймер. Чтобы использовать только таймер, передайте `false` в [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Задержка контролирует момент перехода слайда; она не задаёт длительность визуального эффекта перехода.

Этот пример назначает разные эффекты первым трём слайдам и включает автоматический переход через 3, 5 и 7 секунд соответственно. По клику мыши эти слайды также могут переходить. Используйте файл `input.pptx` минимум с тремя слайдами.

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

Чтобы проверить, включён ли таймерный переход, вызовите [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Хранимая задержка сама по себе не указывает, активен ли таймер.

Следующий пример открывает ранее сохранённый файл, выводит информацию о каждом включённом таймере и отключает автоматический переход для слайдов с задержкой более двух секунд. Для этих слайдов включаются клики мыши, после чего настройки сохраняются.

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

## **Точное управление временем перехода**

Используйте [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) для указания точной длительности эффекта перехода в миллисекундах. Метод [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) слайда раскрывает эти настройки через объект [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| Метод | Назначение |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Устанавливает длительность самого эффекта перехода в миллисекундах. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Устанавливает задержку перед автоматическим переходом слайда в миллисекундах. Передайте `true` в [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter), чтобы активировать таймер. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Выбирает предопределённую категорию скорости из [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium или Fast. Используется, когда точная длительность не задана. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) управляет только эффектом перехода; он не определяет, как долго слайд остаётся видимым. Задержку автоматического перехода настраивайте отдельно. Если явная длительность не задана, Aspose.Slides определяет её на основе типа перехода и значения [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **Применить одинаковую длительность ко всем слайдам**

Чтобы обеспечить одинаковый ритм, примените один и тот же эффект и точную длительность ко всем слайдам. Этот пример загружает `input.pptx`, выбирает Fade из [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) и задаёт каждой переходу длительность 750 мс. Затем отдельно включает автоматический переход через 5 000 мс и отключает переход по клику мыши, после чего сохраняет результат в PPTX.

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

### **Задать разные длительности для отдельных слайдов**

Разные слайды могут иметь разные длительности эффектов. Например, используйте короткий переход для титульного слайда и более длительный — для введения раздела. Этот пример задаёт 500 мс для первого слайда и 1 200 мс для второго. Используйте файл `input.pptx` минимум с двумя слайдами.

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

### **Синхронизация переходов с анимированным выводом**

При подготовке [animated GIF](/slides/ru/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ru/nodejs-java/export-to-html5/) или [video](/slides/ru/nodejs-java/convert-powerpoint-to-video/) задавайте точные длительности переходов перед экспортом, чтобы они соответствовали запланированному ритму. Например, используйте 600‑мс fade между сценами и отдельно настраивайте задержку перехода каждого слайда, чтобы было время для озвучки или содержания.

Для GIF и видео согласуйте частоту кадров вывода с длительностью эффекта: 600 мс соответствует 18 кадрам при 30 fps. В HTML5 включите анимированные переходы в настройках экспорта. Проверьте поддерживаемые эффекты и параметры тайминга выбранного формата и просмотрите результат для подтверждения синхронизации.

### **Чтение существующей длительности перехода**

Вызовите [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) перед изменением перехода, чтобы определить, хранится ли явное значение. Значение `-1` означает, что длительность не задана явно; неотрицательное значение указывает сохранённую длительность в миллисекундах. Неустановленное значение не является рассчитанной длительностью воспроизведения: Aspose.Slides использует тип перехода и значение [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) для её определения. Установка типа перехода может инициализировать длительность, поэтому сначала проверьте исходные настройки.

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

Переход Morph анимирует изменения между объектами на последовательных слайдах. Чтобы создать простой эффект Morph, клонируйте слайд, переместите или измените размер объекта на копии и примените переход Morph ко второму слайду. Это позволяет анимировать соответствующие объекты между их исходным и изменённым состоянием.

В следующем примере создаётся слайд с текстовым прямоугольником, он клонируется, а на копии меняются позиция и размер прямоугольника. Затем для второго слайда выбирается Morph из перечисления [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/). Откройте сохранённый файл в просмотрщике, поддерживающем Morph, чтобы увидеть эффект во время показа слайдов.

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

## **Типы Morph Transition**

Перечисление [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) управляет тем, как Morph сопоставляет и анимирует содержимое:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) рассматривает каждую форму как единый объект.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) анимирует текст, сопоставляя слова, где это возможно.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) анимирует текст, сопоставляя символы, где это возможно.

Используйте [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) для выбора Morph перед получением [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue). Полученное значение предоставляет объект [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/), у которого метод [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) выбирает режим сопоставления.

Этот пример открывает презентацию, созданную в предыдущем разделе, и настраивает второй слайд на анимацию Morph по словам.

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

## **Задать эффекты переходов**

Некоторые переходы предоставляют дополнительные параметры, такие как направление или начало эффекта с чёрного экрана. Доступные параметры зависят от выбранного через [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) перехода. Сначала задайте тип, затем используйте соответствующий объект перехода, полученный через [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

В следующем примере к первому слайду `input.pptx` применяется переход Cut. Через [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) вызывается [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack), чтобы переход начинался с чёрного экрана.

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

**Можно ли контролировать скорость воспроизведения перехода слайда?**

Да. Предпочтительно используйте [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration), когда нужна точная длительность эффекта в миллисекундах. Используйте [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed), когда достаточно предопределённой категории [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) — Slow, Medium или Fast, и явная длительность не задаётся. Эти настройки управляют только эффектом перехода, независимо от задержки автоматического перехода.

**Можно ли прикрепить аудио к переходу и включить его зацикливание?**

Да. Присвойте встроенный звук через [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound), передайте значение StartSound из перечисления [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) в [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) и включите [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) со значением `true`. Звук будет зацикливаться до следующего звукового события в показе.

**Как быстрее всего применить один и тот же переход ко всем слайдам?**

Пройдитесь по коллекции слайдов презентации через [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) и вызовите [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) с одинаковым значением для перехода каждого слайда. В том же цикле задайте любые параметры тайминга и эффекта, чтобы поведение было одинаковым на всех слайдах.

**Как проверить, какой переход сейчас установлен на слайде?**

Вызовите [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) у результата [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) слайда. Он вернёт значение из перечисления [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); None означает отсутствие эффекта перехода.