---
title: تطبيق حركات الشكل في العروض التقديمية باستخدام JavaScript
linktitle: حركة الشكل
type: docs
weight: 60
url: /ar/nodejs-java/shape-animation/
keywords:
- شكل
- حركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة حركة
- الحصول على حركة
- استخراج حركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق حركة
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إضافة، وفحص، وتخصيص حركات الأشكال، وتوقيتها، وأصواتها، وسلوك ما بعد الحركة، والنص المتحرك باستخدام Aspose.Slides for Node.js عبر Java."
---
## **نظرة عامة**

تمثل Aspose.Slides for Node.js عبر Java حركات الشرائح كـ **effects** في جدول زمني للشريحة. يحتوي الـ effect على الشكل الهدف، ونوع الحركة والفرع الفرعي، ومشغل، وإعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الحركة.

يحتوي الجدول الزمني على نوعين من السلاسل:

- **السلسلة الرئيسية** تُشغل عندما تتقدم الشريحة.
- **السلسلة التفاعلية** تبدأ عندما يُنقر على الشكل المشغل.

نظرًا لأن صناديق النصوص، والصور، والمخططات، والجداول، وغيرها من كائنات الشريحة هي كائنات [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/) ، فإنك تستخدم نفس طريقة [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) لمعظم محتوى الشريحة. تُدرج التأثيرات المتاحة في تعداد [EffectType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttype/).

## **إضافة حركات الشكل**

لإضافة حركة، احصل على السلسلة الرئيسية للشرائح واستدعِ [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) مع الشكل الهدف، ونوع الـ effect، والفرع الفرعي، والمشغل. لتأثير يبدأ عندما يُنقر على شكل آخر، أنشئ سلسلة تفاعلية يكون مشغلها ذلك الشكل الآخر.

المثال التالي ينشئ كلا النوعين من الحركات ويحفظ النتيجة في الملف `shape-animations.pptx`.

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

المشغل يتحكم متى يبدأ الـ effect:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttriggertype/#OnClick) ينتظر النقر في السلسلة الرئيسية، أو النقر على الشكل المشغل في سلسلة تفاعلية.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) يبدأ مع الـ effect السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) يبدأ عندما ينتهي الـ effect السابق.

لتحريك صورة أو مخطط أو أي نوع آخر من الأشكال، مرّر ذلك الكائن إلى [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) بدلاً من `targetShape`. للحصول على خيارات تجميع خاصة بالمخططات، راجع [Animated Charts](/slides/ar/nodejs-java/animated-charts/).

## **قراءة حركات الشكل**

استخدم [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#getEffectsByShape) عندما تعرف الشكل الهدف. لتفقد كل تأثير، عدّ السلسلة الرئيسية وكل سلسلة تفاعلية. العدّ يمنع الافتراض بأن السلسلة تحتوي على تأثير في الفهرس `0`.

المثال التالي ينشئ شكلاً به تأثيرات في السلسلة الرئيسية وتفاعلية، يحصل على التأثيرات التي تستهدف الشكل، ثم يعدّ كل سلسلة على الشريحة.

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

إذا كنت بحاجة فقط إلى التأثيرات لشكل واحد، حدّد الشكل أولًا بالاسم أو نوع العنصر النائب أو أي خاصية ثابتة أخرى؛ ثم استدعِ [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#getEffectsByShape). لا تفترض أن [ShapeCollection.get_Item](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#get_Item) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العنصر النائب الموروثة**

يمكن لعنصر نائب في شريحة عادية أن يرث سلوك الحركة من العنصر النائب المقابل في شريحة التخطيط وشريحة القالب. تُعيد الدالة [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getBasePlaceholder) ذلك العنصر النائب الأصلي، أو `null` عندما لا يوجد عنصر أب.

في عرض الشرائح التالي، يحتوي التذييل على **Random Bars** في الشريحة العادية، و**Split** في شريحة التخطيط، و**Fly In** في شريحة القالب.

![تأثير حركة التذييل على الشريحة العادية](slide-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة التخطيط](layout-shape-animation.png)

![تأثير حركة عنصر نائب التذييل على شريحة القالب](master-shape-animation.png)

المثال التالي يستخدم تسلسلًا هرميًا للعنصر النائب من عرض تقديم جديد. يضيف تأثيرات إلى عنصر نائب في القالب، وعنصر نائب في التخطيط، والعنصر النائب المقابل على شريحة عادية. يتم فحص كل استدعاء لـ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getBasePlaceholder) قبل استخدام الشكل المرتجع.

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

## **تغيير توقيت الحركة**

حوار **Timing** في PowerPoint يطابق خصائص [Timing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/).

![حوار توقيت PowerPoint لتأثير الحركة](shape-animation.png)

- **Start** يطابق [Timing.getTriggerType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** يطابق [Timing.getDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getDuration) بالثواني.
- **Delay** يطابق [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) بالثواني.
- **Repeat** يطابق [Timing.getRepeatCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatCount)، أو [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick)، أو [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** يطابق [Timing.getRewind](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRewind).

هذا المثال المستقل يضيف تأثيرًا، يغيّر توقيته عبر الكائن المرتجع من [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect)، ويحفظ النتيجة. حفظ مرجع الـ [Effect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/) المرتجع يجنّب فهرس مجموعة غير ضروري.

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

استخدم وضع تكرار واحد فقط. الجمع بين عدّ التكرار وعلم "حتى" قد ينتج عنه نتائج مربكة في مشغلات مختلفة. عند تغيير أوضاع التكرار، اضبط [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) و[Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) قبل [Timing.setRepeatCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#setRepeatCount)، لأن ضبط أي علم يغيّر أيضًا وضع التكرار النشط.

## **إضافة واستخراج أصوات الحركة**

يمكن لتأثير الحركة أن يشير إلى صوت مدمج عبر [Effect.getSound](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getSound). تُخبر الدالة [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#setStopPreviousSound) التأثير بإيقاف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع وجود ملف صوت محلي باسم `animation-sound.wav`. ينشئ تأثيرين، يدمج ذلك الملف كصوت للتأثير الأول، ويضبط التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المرتجعة من [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect)، لذا لا يلزم فهرس السلسلة.

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

### **استخراج أصوات التأثير المدمجة**

المثال التالي يتوقع وجود عرض تقديمي محلي باسم `presentation-with-animation-sounds.pptx`. يفحص كل من السلاسل الرئيسية والتفاعلية ويكتب كل صوت تأثير مدمج إلى مجلد `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME للصوت الذي تُعيده الدالة [Audio.getContentType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audio/#getContentType).

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

للكائنات الصوتية الكبيرة، استخدم [Audio.getStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audio/#getStream) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تعيين سلوك ما بعد الحركة**

خيار **After animation** يتحكم في ما يحدث للشكل بعد انتهاء تأثيره.

![حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

يُدعم تعداد [AfterAnimationType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/afteranimationtype/) ترك الشكل دون تغيير، أو تغيير لونه، أو إخفائه بعد الحركة، أو إخفائه عند النقر التالي. عندما يكون النوع هو [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/afteranimationtype/#Color)، اضبط أيضًا [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

هذا المثال المستقل يخلق تأثيرًا، يضبط سلوك ما بعد الحركة عبر كائن الـ effect المرتجع، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType.Color](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/afteranimationtype/#Color) يمسح إعداد لون ما بعد الحركة.

## **تحريك النص**

لتحريك النص توجد تحكمان مرتبطان:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textanimation/#getBuildType) يتحكم ما إذا كانت الفقرات تظهر معًا أو بمستوى الفقرة.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getAnimateTextType) يتحكم ما إذا كان النص يظهر دفعة واحدة، أو كلمة بكلمة، أو حرف بحرف. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) يحدد التأخير بين الكلمات أو الأحرف. القيمة الموجبة هي نسبة مئوية من مدة الـ effect؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل صندوق نص. يوقف [BuildType.AsOneObject](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/buildtype/#AsOneObject) بناء الفقرة‑بفقرة بحيث يُطبق إعداد الكلمة على الإطار النصي بأكمله.

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

لبناء صندوق نص حسب الفقرة، اضبط [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثير خاص، استخدم نسخة [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) التي تقبل كائنًا من نوع [Paragraph](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/paragraph/). راجع [Animated Text](/slides/ar/nodejs-java/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- الحفظ إلى PPT أو PPTX يحافظ على نموذج الحركة، لكن تشغيله النهائي يتحكم به عارض العرض.
- PDF والصور الثابتة لا تشغل الحركات. استخدم [HTML5 export](/slides/ar/nodejs-java/export-to-html5/)، GIF متحرك، أو [تحويل الفيديو](/slides/ar/nodejs-java/convert-powerpoint-to-video/) عندما يجب إظهار الحركة.
- لتصدير HTML5، فعِّل [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/html5options/#setAnimateShapes) وعند الحاجة [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- يدعم تصيّر الفيديو العديد من تأثيرات الدخول، والتأكيد، والخروج، ومسار الحركة الشائعة، لكن ليس كل تأثير PowerPoint مدعوم. تحقق من جدول [التحركات والتأثيرات المدعومة](/slides/ar/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) واختبر العروض الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحفظ التأثيرات المخصّصة المتقدّمة أو المستوردة من صيغ عروض تقديمية أخرى في الملف ولكن تُظهر بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدّرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة المتكررة**

**لماذا تظهر الحركة في PowerPoint ولكن ليس في PDF؟**

PDF هو تنسيق ثابت، لذا لا تُشغل الحركات ولا انتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يعمل تأثير بشكل مختلف في الفيديو؟**

تصدير الفيديو يُعيد رسم الحركات بدلًا من تخزين سلوك PowerPoint الأصلي. بعض التأثيرات المتقدّمة غير مدعومة أو تُقرب من الأصل. راجع جدول التأثيرات المدعومة واختبر العرض الفعلي قبل الاستخدام الإنتاجي.

**هل تغيير موضع الشكل إلى أمام أو خلف يغيّر ترتيب حركته؟**

لا. يتحكم ترتيب الـ z للshape في التراكب، بينما يتحكم ترتيب السلسلة والمشغلات في تشغيل الحركات. غير الخط الزمني إذا كنت بحاجة إلى ترتيب تشغيل مختلف.