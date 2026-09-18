---
title: تطبيق رسومات الأشكال المتحركة في العروض التقديمية باستخدام JavaScript
linktitle: تحريك الشكل
type: docs
weight: 60
url: /ar/nodejs-java/shape-animation/
keywords:
- شكل
- رسوم متحركة
- تأثير
- شكل متحرك
- نص متحرك
- إضافة رسوم متحركة
- الحصول على رسوم متحركة
- استخراج رسوم متحركة
- إضافة تأثير
- الحصول على تأثير
- استخراج تأثير
- صوت التأثير
- تطبيق رسوم متحركة
- PowerPoint
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية إضافة، وفحص، وتخصيص رسومات الأشكال المتحركة، والتوقيت، والأصوات، وسلوك ما بعد الرسوم المتحركة، والنص المتحرك باستخدام Aspose.Slides للـ Node.js عبر Java."
---
## **نظرة عامة**

للعمل مع السلوكيات الفردية داخل تأثير أو تحرير أقسام مسار الحركة، انظر [رسوم متحركة مخصصة](/slides/ar/nodejs-java/custom-animation/).

Aspose.Slides for Node.js via Java يمثل الرسوم المتحركة للشرائح كـ تأثيرات في جدول زمني للشرائح. يحتوي التأثير على شكل الهدف، نوع الرسوم المتحركة والفرع الفرعي، مشغل، إعدادات التوقيت، وخصائص اختيارية مثل الصوت أو سلوك ما بعد الرسوم المتحركة.

الجدول الزمني يحتوي على نوعين من التسلسلات:

- **التسلسل الرئيسي** يُشغَل عندما تتقدم الشريحة.
- **التسلسل التفاعلي** يبدأ عندما يتم النقر على الشكل المشغل.

نظرًا لأن مربعات النص، والصور، والرسوم البيانية، والجداول، وغيرها من عناصر الشريحة هي كائنات [Shape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/)، فإنك تستخدم نفس طريقة [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) لمعظم محتوى الشريحة. تُدرج التأثيرات المتاحة في تعداد [EffectType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttype/).

## **إضافة رسوم متحركة للشكل**

لإضافة رسوم متحركة، احصل على التسلسل الرئيسي للشرائح واستدعِ [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) مع شكل الهدف، نوع التأثير، النوع الفرعي، والمشغل. لتأثير يبدأ عندما يتم النقر على شكل آخر، أنشئ تسلسلًا تفاعليًا يكون مشغله ذلك الشكل الآخر.

المثال التالي ينشئ كلا نوعي الرسوم المتحركة ويحفظ النتيجة إلى `shape-animations.pptx`.

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

المشغل يتحكم متى يبدأ التأثير:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttriggertype/#OnClick) ينتظر نقرة في التسلسل الرئيسي، أو نقرة على الشكل المشغل في تسلسل تفاعلي.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) يبدأ مع التأثير السابق.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) يبدأ عندما ينتهي التأثير السابق.

لتحريك صورة أو رسم بياني أو أي نوع آخر من الأشكال، قم بتمرير ذلك الكائن إلى [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect) بدلاً من `targetShape`. للحصول على خيارات تجميع خاصة بالرسوم البيانية، انظر [الرسوم البيانية المتحركة](/slides/ar/nodejs-java/animated-charts/).

## **قراءة الرسوم المتحركة للأشكال**

استخدم [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#getEffectsByShape) عندما تعرف شكل الهدف. لتفقد كل تأثير، قم بتعداد التسلسل الرئيسي وكل تسلسل تفاعلي. التعداد يمنع الافتراض بأن التسلسل يحتوي على تأثير في الفهرس `0`.

المثال التالي ينشئ شكلاً يحتوي على تأثيرات في التسلسل الرئيسي وتفاعلية، يحصل على التأثيرات التي تستهدف الشكل، ثم يعدد كل تسلسل على الشريحة.

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

إذا كنت تحتاج فقط إلى التأثيرات لشكل واحد، حدد الشكل أولاً بالاسم أو نوع العنصر النائب أو أي خاصية مستقرة أخرى؛ ثم استدعِ [Sequence.getEffectsByShape](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#getEffectsByShape). لا تفترض أن [ShapeCollection.get_Item](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shapecollection/#get_Item) في الفهرس `0` هو دائمًا الكائن المقصود.

## **العمل مع تأثيرات العنصر النائب الموروثة**

يمكن للعنصر النائب في شريحة عادية أن يرث سلوك الرسوم المتحركة من العنصر النائب المقابل في شريحة التخطيط والشريحة الرئيسية. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getBasePlaceholder) يُعيد ذلك العنصر النائب الأب، أو `null` إذا لم يكن هناك أب.

في عرض الشرائح التالي، يحتوي التذييل على **Random Bars** في الشريحة العادية، و**Split** في شريحة التخطيط، و**Fly In** في الشريحة الرئيسية.

![تأثير حركة التذييل في الشريحة العادية](slide-shape-animation.png)
![تأثير حركة العنصر النائب للتذييل في شريحة التخطيط](layout-shape-animation.png)
![تأثير حركة العنصر النائب للتذييل في الشريحة الرئيسية](master-shape-animation.png)

المثال التالي يستخدم هيكلية عناصر نائبة من عرض تقديمي جديد. يضيف تأثيرات إلى عنصر نائب رئيسي، وعنصر نائب تخطيط، والعنصر النائب المقابل في شريحة عادية. يتم التحقق من كل استدعاء لـ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getBasePlaceholder) قبل استخدام الشكل المعاد.

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

## **تغيير توقيت الرسوم المتحركة**

حوار PowerPoint **Timing** يتطابق مع خصائص [Timing](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/).

![حوار توقيت PowerPoint لتأثير الرسوم المتحركة](shape-animation.png)

- **Start** يتطابق مع [Timing.getTriggerType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** يتطابق مع [Timing.getDuration](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getDuration)، بالثواني.
- **Delay** يتطابق مع [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)، بالثواني.
- **Repeat** يتطابق مع [Timing.getRepeatCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatCount)، [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick)، أو [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** يتطابق مع [Timing.getRewind](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#getRewind).

هذا المثال المستقل يضيف تأثيرًا، يغير توقيته عبر الكائن المعاد من [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect)، ويحفظ النتيجة. الحفاظ على مرجع [Effect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/) المعاد يتجنب فهرس جمع غير ضروري.

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

استخدم وضعية تكرار واحدة عن قصد. الجمع بين عدد التكرار وعلامة "until" قد ينتج عنه نتائج مربكة في عارضات مختلفة. عند تغيير أوضاع التكرار، اضبط [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) و[Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) قبل [Timing.setRepeatCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/timing/#setRepeatCount)، لأن تعيين أيٍ من العلامتين يغيّر أيضًا وضعية التكرار النشطة.

## **إضافة واستخراج أصوات الرسوم المتحركة**

يمكن لتأثير الرسوم المتحركة الإشارة إلى صوت مضمّن عبر [Effect.getSound](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#setStopPreviousSound) يخبر التأثير بوقف الصوت الذي بدأه تأثير سابق.

### **إضافة صوت إلى تأثير**

المثال التالي يتوقع ملف صوتي محلي باسم `animation-sound.wav`. ينشئ تأثيرين، يضمّن هذا الملف كصوت للتأثير الأول، ويكوّن التأثير الثاني لإيقاف الصوت. يستخدم الكائنات المعادة من [Sequence.addEffect](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/sequence/#addEffect)، لذا لا يلزم فهرس للتسلسل.

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

### **استخراج الأصوات المضمنة للتأثير**

المثال التالي يتوقع عرض تقديمي محلي باسم `presentation-with-animation-sounds.pptx`. يفحص كل من التسلسل الرئيسي والتسلسلات التفاعلية ويكتب كل صوت مدمج لتأثير في دليل `extracted-animation-sounds`. يتم اختيار الامتداد من نوع MIME الصوتي المعرّف عبر [Audio.getContentType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audio/#getContentType).

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

بالنسبة لكائنات الصوت الكبيرة، استخدم [Audio.getStream](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/audio/#getStream) وانسخ الدفق إلى ملف بدلاً من تحميل الكائن بالكامل إلى مصفوفة بايت.

## **تحديد سلوك ما بعد الرسوم المتحركة**

خيار **After animation** يتحكم فيما يحدث للشكل بعد انتهاء التأثير.

![حوار خيارات تأثير PowerPoint يظهر إعدادات After animation](shape-after-animation.png)

- تعداد [AfterAnimationType] يدعم ترك الشكل دون تغيير، تغيير لونه، إخفائه بعد الرسوم المتحركة، أو إخفائه عند النقر التالي. عندما يكون النوع هو [AfterAnimationType.Color]، اضبط أيضًا [Effect.getAfterAnimationColor].

هذا المثال المستقل ينشئ تأثيرًا، يضبط سلوك ما بعد الرسوم المتحركة عبر كائن التأثير المعاد، ويحفظ النتيجة.

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

تغيير النوع بعيدًا عن [AfterAnimationType.Color] يمسح إعداد لون ما بعد الرسوم المتحركة.

## **تحريك النص**

تحريك النص يحتوي على تحكمين مرتبطين:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/textanimation/#getBuildType) يتحكم ما إذا كانت الفقرات تظهر معًا أو على مستوى الفقرة.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getAnimateTextType) يتحكم ما إذا ظهر النص كله مرة واحدة، أو كلمةً بكلمة، أو حرفًا بحرف. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) يحدد التأخير بين الكلمات أو الأحرف. القيمة الإيجابية هي نسبة مئوية من مدة التأثير؛ القيمة السالبة هي تأخير بالثواني.

المثال المستقل التالي يحرك الكلمات داخل مربع نص. [BuildType.AsOneObject] يعطل بناء الفقرة بفقرة بحيث يطبق إعداد الكلمة على كامل إطار النص.

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

لبناء مربع نص وفقًا للفقرة، اضبط [BuildType.ByLevelParagraphs1] (أو مستوى فقرة آخر). لاستهداف فقرة واحدة بتأثير خاص بها، استخدم نسخة [Sequence.addEffect] التي تقبل كائنًا من نوع [Paragraph]. راجع [Animated Text](/slides/ar/nodejs-java/animated-text/) لأمثلة على مستوى الفقرة.

## **ملاحظات التصدير والتوافق**

- الحفظ إلى PPT أو PPTX يحتفظ بنموذج الرسوم المتحركة، لكن التشغيل النهائي يتحكم فيه عارض العرض التقديمي.
- PDF والصور الثابتة لا تشغل الرسوم المتحركة. استخدم [HTML5 export](/slides/ar/nodejs-java/export-to-html5/)، GIF متحرك، أو [video conversion](/slides/ar/nodejs-java/convert-powerpoint-to-video/) عندما يجب أن يظهر المخرج حركة.
- بالنسبة لـ HTML5، فعّل [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/html5options/#setAnimateShapes)، وعند الحاجة، [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- يدعم تصيير الفيديو العديد من تأثيرات الدخول، والتأكيد، والخروج، ومسارات الحركة الشائعة، لكن ليس كل تأثير في PowerPoint مدعوم. تحقق من [supported animations and effects](/slides/ar/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) الحالي واختبر العروض التقديمية الحرجة مع نسخة Aspose.Slides المستهدفة.
- قد تُحافظ التأثيرات المخصصة المتقدمة والتأثيرات المستوردة من صيغ عروض تقديمية أخرى في الملف ولكنها تُظهر بشكل مختلف في PowerPoint أو HTML5 أو الفيديو. تحقق من النتيجة المصدرة بدلاً من الاعتماد فقط على اسم التأثير.

## **الأسئلة المتكررة**

**لماذا يظهر تأثير في PowerPoint لكن لا يظهر في PDF؟**

PDF هو تنسيق ثابت، لذا لا تُشغل الرسوم المتحركة وانتقالات الشرائح. صدّر إلى HTML5 أو GIF متحرك أو فيديو عندما يجب الحفاظ على الحركة.

**لماذا يُشغل تأثير بشكل مختلف في الفيديو؟**

تصدير الفيديو يُعيد رسم الرسوم المتحركة بدلاً من حفظ سلوك PowerPoint الأصلي. بعض التأثيرات المتقدمة غير مدعومة أو مُقربة. راجع جدول التأثيرات المدعومة واختبر العرض التقديمي الفعلي قبل الاستخدام الإنتاجي.

**هل تغيير موضع الشكل للأمام أو الخلف يغيّر ترتيب رسوماته المتحركة؟**

لا. ترتيب Z للشكل يتحكم في التداخل، بينما يتحكم ترتيب التسلسل والمشغلات في تشغيل الرسوم المتحركة. عدّل الجدول الزمني إذا كنت تحتاج ترتيب تشغيل مختلف.