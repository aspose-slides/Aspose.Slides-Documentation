---
title: Применение анимации фигур в презентациях с помощью JavaScript
linktitle: Анимация фигур
type: docs
weight: 60
url: /ru/nodejs-java/shape-animation/
keywords:
- фигура
- анимация
- эффект
- анимированная фигура
- анимированный текст
- добавить анимацию
- получить анимацию
- извлечь анимацию
- добавить эффект
- получить эффект
- извлечь эффект
- звук эффекта
- применить анимацию
- PowerPoint
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Узнайте, как добавлять, просматривать и настраивать анимацию фигур, тайминг, звуки, поведение после анимации и анимированный текст с помощью Aspose.Slides для Node.js через Java."
---
## **Обзор**

Чтобы работать с отдельными поведениями внутри эффекта или редактировать сегменты траектории движения, см. [Пользовательская анимация](/slides/ru/nodejs-java/custom-animation/).

Aspose.Slides for Node.js via Java представляет анимацию слайдов как эффекты в таймлайне слайда. Эффект имеет целевую форму, тип и подтип анимации, триггер, настройки тайминга и необязательные свойства, такие как звук или поведение после анимации.

Таймлайн содержит два типа последовательностей:

- **main sequence** воспроизводится по мере продвижения слайда.
- **interactive sequence** начинается, когда по форме‑триггеру происходит клик.

Поскольку текстовые блоки, изображения, диаграммы, таблицы и другие объекты слайда являются объектами [Shape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/), вы используете тот же метод [Sequence.addEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#addEffect) для большинства содержимого слайда. Доступные эффекты перечислены в перечислении [EffectType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effecttype/).

## **Добавление анимации фигур**

Чтобы добавить анимацию, получите основную последовательность слайда и вызовите [Sequence.addEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#addEffect), передав целевую форму, тип эффекта, подтип и триггер. Для эффекта, который начинается при клике по другой форме, создайте интерактивную последовательность, триггером которой будет эта другая форма.

Следующий пример создает оба типа анимации и сохраняет результат в файл `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Триггер определяет, когда начинается эффект:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effecttriggertype/#OnClick) ожидает клик в основной последовательности или клик по форме‑триггеру в интерактивной последовательности.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) начинается одновременно с предыдущим эффектом.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) начинается после завершения предыдущего эффекта.

Чтобы анимировать изображение, диаграмму или другой тип формы, передайте этот объект в [Sequence.addEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#addEffect) вместо `targetShape`. Для параметров группировки, специфичных для диаграмм, см. [Animated Charts](/slides/ru/nodejs-java/animated-charts/).

## **Чтение анимации фигур**

Используйте [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#getEffectsByShape), когда известна целевая форма. Чтобы просмотреть каждый эффект, перечислите основные и все интерактивные последовательности. Перебор исключает предположение, что в последовательности есть эффект с индексом `0`.

Следующий пример создает форму с эффектами основной и интерактивной последовательностей, получает эффекты, нацеленные на форму, и затем перебирает каждую последовательность на слайде.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Если нужны эффекты только для одной формы, сначала определите форму по имени, типу заполнителя или другому стабильному свойству; затем вызовите [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Не полагайтесь на то, что [ShapeCollection.get_Item](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shapecollection/#get_Item) с индексом `0` всегда возвращает нужный объект.

## **Работа с унаследованными эффектами заполнителей**

Заполнитель на обычном слайде может наследовать поведение анимации от соответствующего заполнителя на слайде‑макете и слайде‑шаблоне. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getBasePlaceholder) возвращает родительский заполнитель или `null`, если родитель отсутствует.

В показанном примере презентации нижний колонтитул имеет **Random Bars** на обычном слайде, **Split** на слайде‑макете и **Fly In** на слайде‑шаблоне.

![Эффект анимации нижнего колонтитула на обычном слайде](slide-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑макете](layout-shape-animation.png)

![Эффект анимации заполнителя нижнего колонтитула на слайде‑шаблоне](master-shape-animation.png)

Следующий пример использует иерархию заполнителей из новой презентации. Он добавляет эффекты к заполняющему элементу мастера, заполняющему элементу макета и соответствующему заполнителю на обычном слайде. Каждый вызов [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/shape/#getBasePlaceholder) проверяется до использования возвращённой формы.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Изменение тайминга анимации**

Диалог PowerPoint **Timing** соответствует свойствам [Timing](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/).

![Диалог PowerPoint Timing для анимационного эффекта](shape-animation.png)

- **Start** соответствует [Timing.getTriggerType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** соответствует [Timing.getDuration](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getDuration) и измеряется в секундах.
- **Delay** соответствует [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) и измеряется в секундах.
- **Repeat** соответствует [Timing.getRepeatCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) или [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** соответствует [Timing.getRewind](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#getRewind).

Этот независимый пример добавляет эффект, меняет его тайминг через объект, возвращённый [Sequence.addEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#addEffect), и сохраняет результат. Сохранение ссылки на возвращённый [Effect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/) избавляет от необходимости использовать индекс коллекции.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Используйте один режим повторения намеренно. Сочетание количества повторений с флагом «until» может давать непредсказуемый результат в разных просмотрщиках. При изменении режимов повторения сначала вызывайте [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) и [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide), а затем [Timing.setRepeatCount](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/timing/#setRepeatCount), потому что установка любого из флагов также меняет активный режим повторения.

## **Добавление и извлечение звуков анимации**

Эффект анимации может ссылаться на встроенный звук через [Effect.getSound](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#setStopPreviousSound) указывает эффекту остановить звук, запущенный предыдущим эффектом.

### **Добавление звука к эффекту**

Следующий пример ожидает локальный аудиофайл `animation-sound.wav`. Он создаёт два эффекта, встраивает файл как звук для первого эффекта и настраивает второй эффект на остановку звука. Используются объекты, возвращённые [Sequence.addEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#addEffect), поэтому индекс последовательности не требуется.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Извлечение встроенных звуков эффектов**

Следующий пример ожидает локальную презентацию `presentation-with-animation-sounds.pptx`. Он сканирует основные и интерактивные последовательности и записывает каждый встроенный звук эффекта в каталог `extracted-animation-sounds`. Расширение выбирается из MIME‑типа аудио, предоставляемого [Audio.getContentType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Для больших аудио‑объектов используйте [Audio.getStream](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/audio/#getStream) и копируйте поток в файл, вместо загрузки всего объекта в массив байт.

## **Настройка поведения после анимации**

Опция **After animation** определяет, что происходит с формой после завершения её эффекта.

![Диалог параметров эффекта PowerPoint, показывающий настройки After animation](shape-after-animation.png)

Перечисление [AfterAnimationType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/afteranimationtype/) поддерживает оставлять форму без изменений, менять её цвет, скрывать её после анимации или скрывать при следующем клике. Когда тип — [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/afteranimationtype/#Color), также задайте [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Этот независимый пример создаёт эффект, устанавливает его поведение после анимации через возвращённый объект эффекта и сохраняет результат.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Изменение типа с [AfterAnimationType.Color](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/afteranimationtype/#Color) очищает настройку цвета после анимации.

## **Анимация текста**

У анимации текста есть два связанных параметра:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/textanimation/#getBuildType) определяет, появляются ли абзацы вместе или по уровням абзацев.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getAnimateTextType) определяет, отображается ли текст сразу, по словам или по буквам. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) задаёт задержку между словами или буквами. Положительное значение — это процент от длительности эффекта; отрицательное значение — задержка в секундах.

Следующий независимый пример анимирует слова в текстовом поле. [BuildType.AsOneObject](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/buildtype/#AsOneObject) отключает построение по абзацам, так что настройка по словам применяется ко всему текстовому фрейму.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Чтобы строить текстовое поле по абзацам, задайте [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (или другой уровень абзаца). Чтобы применить отдельный эффект к одному абзацу, используйте перегрузку [Sequence.addEffect](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/sequence/#addEffect), принимающую [Paragraph](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/paragraph/). См. [Animated Text](/slides/ru/nodejs-java/animated-text/) для примеров уровня абзаца.

## **Экспорт и примечания о совместимости**

- Сохранение в PPT или PPTX сохраняет модель анимации, но окончательное воспроизведение контролируется программой‑просмотром презентаций.
- PDF и статические изображения не воспроизводят анимацию. Используйте [HTML5 export](/slides/ru/nodejs-java/export-to-html5/), анимированный GIF или [конвертацию в видео](/slides/ru/nodejs-java/convert-powerpoint-to-video/), когда вывод должен показывать движение.
- Для HTML5 включите [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/html5options/#setAnimateShapes) и при необходимости [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Видеорендеринг поддерживает многие распространённые эффекты входа, акцентирования, выхода и траекторий движения, но не каждый эффект PowerPoint поддерживается. Проверьте текущий список [поддерживаемых анимаций и эффектов](/slides/ru/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) и протестируйте критические презентации с используемой версией Aspose.Slides.
- Пользовательские эффекты и эффекты, импортированные из других форматов презентаций, могут сохраняться в файле, но отображаться иначе в PowerPoint, HTML5 или видео. Валидируйте экспортированный результат, а не полагайтесь только на название эффекта.

## **FAQ**

**Почему анимация отображается в PowerPoint, но не в PDF?**

PDF — статический формат, поэтому анимация и переходы слайдов не воспроизводятся. Экспортируйте в HTML5, анимированный GIF или видео, когда необходимо сохранить движение.

**Почему эффект воспроизводится иначе в видео?**

Экспорт в видео рендерит анимацию, а не сохраняет оригинальное поведение PowerPoint. Некоторые продвинутые эффекты не поддерживаются или реализованы приближённо. Ознакомьтесь с таблицей поддерживаемых эффектов и протестируйте презентацию перед производственным использованием.

**Изменяет ли перемещение формы вперёд или назад порядок её анимации?**

Нет. Z‑порядок формы управляет наложением, а порядок последовательности и триггеры управляют воспроизведением анимации. Измените таймлайн, если нужен иной порядок воспроизведения.