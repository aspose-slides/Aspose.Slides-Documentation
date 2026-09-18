---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از جاوا اسکریپت
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/nodejs-java/shape-animation/
keywords:
- شکل
- انیمیشن
- اثر
- شکل انیمیشن‌دار
- متن انیمیشن‌دار
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن اثر
- دریافت اثر
- استخراج اثر
- صدا اثر
- اعمال انیمیشن
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "با Aspose.Slides برای Node.js از طریق Java بیاموزید چگونه انیمیشن‌های شکل، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن‌های انیمیشن‌شده را اضافه، بررسی و سفارشی‌سازی کنید."
---
## **بررسی کلی**

برای کار با رفتارهای فردی داخل یک اثر یا ویرایش بخش‌های مسیر حرکتی، به [انیمیشن سفارشی](/slides/fa/nodejs-java/custom-animation/) مراجعه کنید.

Aspose.Slides برای Node.js از طریق Java، انیمیشن‌های اسلاید را به صورت اثرها در یک زمان‌سنج اسلاید نمایش می‌دهد. یک اثر شامل شکل هدف، نوع و زیرنوع انیمیشن، یک محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

زمان‌سنج دو نوع توالی دارد:

- **توالی اصلی** هنگام پیشرفت اسلاید اجرا می‌شود.
- **توالی تعاملی** وقتی شکل محرک آن کلیک شود، شروع می‌شود.

از آنجا که جعبه‌های متن، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید به عنوان اشیای [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) هستند، برای بیشتر محتویات اسلاید از همان متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) استفاده می‌کنید. افکت‌های موجود در شمارش‌گر [EffectType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttype/) فهرست شده‌اند.

## **اضافه کردن انیمیشن‌های شکل**

برای افزودن یک انیمیشن، توالی اصلی اسلاید را بگیرید و [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) را با شکل هدف، نوع اثر، زیرنوع و محرک فراخوانی کنید. برای افکتی که هنگام کلیک روی شکل دیگری شروع می‌شود، یک توالی تعاملی ایجاد کنید که محرک آن همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد می‌کند و نتیجه را در `shape-animations.pptx` ذخیره می‌نماید.

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

محرک زمانی که یک اثر شروع می‌شود را کنترل می‌کند:

- [EffectTriggerType.OnClick] منتظر کلیک در توالی اصلی یا کلیک بر شکل محرک در توالی تعاملی می‌ماند.
- [EffectTriggerType.WithPrevious] با اثر قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious] زمانی که اثر قبلی تمام می‌شود، شروع می‌گردد.

برای انیمیشن یک تصویر، نمودار یا نوع دیگری از شکل، به جای `targetShape` آن شیء را به [Sequence.addEffect] ارسال کنید. برای گزینه‌های گروه‌بندی مخصوص نمودار، به [Animated Charts](/slides/fa/nodejs-java/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

وقتی شکل هدف را می‌دانید از [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#getEffectsByShape) استفاده کنید. برای بررسی هر اثر، تمام توالی اصلی و توالی‌های تعاملی را پیمایش کنید. پیمایش از فرض وجود اثر در اندیس `0` جلوگیری می‌کند.

مثال زیر یک شکل با افکت‌های توالی اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار به آن شکل را دریافت می‌کند و سپس تمام توالی‌ها را در اسلاید مرور می‌نماید.

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

اگر فقط به افکت‌های یک شکل نیاز دارید، ابتدا شکل را با نام، نوع نگهدارنده یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [Sequence.getEffectsByShape] را فراخوانی کنید. فرض نکنید که [ShapeCollection.get_Item] در اندیس `0` همیشه شیء موردنظر است.

## **کار با افکت‌های ارث‌بردهٔ نگهدارنده**

یک نگهدارنده در اسلاید عادی می‌تواند رفتار انیمیشنی را از نگهدارنده متناظر در اسلاید طرح‌بندی و اسلاید اصلی به ارث ببرد. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getBasePlaceholder) آن نگهدارندهٔ والد را برمی‌گرداند یا `null` وقتی والد وجود نداشته باشد.

در ارائهٔ نمونه زیر، پابرگ در اسلاید عادی **Random Bars** دارد، در اسلاید طرح‌بندی **Split** و در اسلاید اصلی **Fly In**.

![افکت انیمیشن پابرگ در اسلاید عادی](slide-shape-animation.png)

![افکت انیمیشن نگهدارنده پابرگ در اسلاید طرح‌بندی](layout-shape-animation.png)

![افکت انیمیشن نگهدارنده پابرگ در اسلاید اصلی](master-shape-animation.png)

مثال بعدی از یک سلسله‌مراتب نگهدارنده در یک ارائهٔ جدید استفاده می‌کند. افکت‌ها به یک نگهدارندهٔ اصلی، یک نگهدارندهٔ طرح‌بندی و نگهدارندهٔ مربوطه در اسلاید عادی افزوده می‌شوند. قبل از استفاده از هر شکل، خروجی [Shape.getBasePlaceholder] بررسی می‌شود.

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

## **تغییر زمان‌بندی انیمیشن**

محاوره **Timing** در PowerPoint به ویژگی‌های [Timing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/) نگاشت می‌شود.

![محاوره زمان‌بندی PowerPoint برای یک افکت انیمیشن](shape-animation.png)

- **شروع** به [Timing.getTriggerType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getTriggerType) نگاشت می‌شود.
- **مدت** به [Timing.getDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getDuration) (بر حسب ثانیه) نگاشت می‌شود.
- **تاخیر** به [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) (بر حسب ثانیه) نگاشت می‌شود.
- **تکرار** به [Timing.getRepeatCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatCount)، [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) یا [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) نگاشت می‌شود.
- **بازگرداندن هنگام اتمام پخش** به [Timing.getRewind](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRewind) نگاشت می‌شود.

این مثال مستقل یک اثر اضافه می‌کند، زمان‌بندی آن را از طریق شیء بازگردانده شده توسط [Sequence.addEffect] تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگهداری مرجع [Effect] بازگردانده‌شده از ایجاد یک ایندکس مجموعهٔ غیرضروری جلوگیری می‌کند.

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

یک حالت تکرار را به‌طور عمدی استفاده کنید. ترکیب تعداد تکرار با پرچم «تا» می‌تواند در نمایشگرهای مختلف نتایج مبهمی بدهد. هنگام تغییر حالت‌های تکرار، ابتدا [Timing.setRepeatUntilNextClick] و [Timing.setRepeatUntilEndSlide] را تنظیم کنید و سپس [Timing.setRepeatCount] را فراخوانی کنید، زیرا تنظیم هر یک از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **افزودن و استخراج صداهای انیمیشن**

یک افکت می‌تواند از طریق [Effect.getSound] صدای جاسازی‌شده‌ای را ارجاع دهد. [Effect.setStopPreviousSound] به یک افکت می‌گوید صدای شروع‌شده توسط اثر قبلی را متوقف کند.

### **افزودن صدا به یک افکت**

مثال زیر انتظار دارد فایل صوتی محلی با نام `animation-sound.wav` موجود باشد. دو اثر ایجاد می‌کند، آن فایل را به عنوان صدا برای اثر اول جاسازی می‌کند و اثر دوم را طوری تنظیم می‌کند که صدا را متوقف کند. از اشیائی که توسط [Sequence.addEffect] بازگردانده می‌شوند استفاده می‌کند، بنابراین نیازی به ایندکس توالی نیست.

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

### **استخراج صداهای جاسازی‌شدهٔ افکت**

مثال زیر انتظار دارد ارائهٔ محلی با نام `presentation-with-animation-sounds.pptx` موجود باشد. توالی‌های اصلی و تعاملی را اسکن می‌کند و هر صدای جاسازی‌شدهٔ افکت را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند بر پایهٔ نوع MIME صوتی که توسط [Audio.getContentType] در دسترس است، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [Audio.getStream] استفاده کنید و جریان را به یک فایل کپی کنید به جای این‌که تمام شیء را در آرایهٔ بایت بارگذاری کنید.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از اتمام اثر چه اتفاقی برای شکل می‌افتد.

![محاوره گزینه‌های اثر PowerPoint که تنظیمات پس از انیمیشن را نشان می‌دهد](shape-after-animation.png)

شمارش‌گر [AfterAnimationType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/) امکان ترک شکل به همان حالت، تغییر رنگ، مخفی کردن پس از انیمیشن یا مخفی کردن در کلیک بعدی را فراهم می‌کند. وقتی نوع [AfterAnimationType.Color] باشد، باید [Effect.getAfterAnimationColor] نیز تنظیم شود.

این مثال مستقل یک اثر ایجاد می‌کند، رفتار پس از انیمیشن آن را از طریق شیء اثر بازگردانده تنظیم می‌کند و نتیجه را ذخیره می‌کند.

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

تغییر نوع از [AfterAnimationType.Color] باعث پاک شدن تنظیم رنگ پس از انیمیشن می‌شود.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [TextAnimation.getBuildType] تعیین می‌کند پاراگراف‌ها به‌صورت یکجا یا به‌صورت سطح پاراگراف ظاهر شوند.
- [Effect.getAnimateTextType] تعیین می‌کند متن به‌صورت یکجا، کلمه به کلمه یا حرف به حرف ظاهر شود. [Effect.getDelayBetweenTextParts] تاخیر بین کلمات یا حروف را تنظیم می‌کند. مقدار مثبت درصدی از مدت اثر است؛ مقدار منفی تاخیر بر حسب ثانیه است.

مثال مستقل زیر کلمات داخل یک جعبه متن را انیمیشن می‌دهد. [BuildType.AsOneObject] ساخت پاراگراف به‌صورت پاراگرافی را غیرفعال می‌کند تا تنظیم کلمه برای تمام فریم متن اعمال شود.

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

برای ساخت جعبه متن به‌صورت پاراگراف، [BuildType.ByLevelParagraphs1] (یا سطح پاراگراف دیگری) را تنظیم کنید. برای هدف‌گذاری یک پاراگراف تنها با افکت خاص خود، از overload متد [Sequence.addEffect] که یک [Paragraph] می‌گیرد استفاده کنید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/nodejs-java/animated-text/) مراجعه کنید.

## **نکات صادرات و سازگاری**

- ذخیره به فرمت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط نمایشگر ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را پخش نمی‌کنند. هنگامی که خروجی باید حرکت را نشان دهد، از [صادرات HTML5](/slides/fa/nodejs-java/export-to-html5/)، GIF انیمیشنی یا [تبدیل به ویدیو](/slides/fa/nodejs-java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.setAnimateShapes] را فعال کنید و در صورت نیاز [Html5Options.setAnimateTransitions] را نیز تنظیم کنید.
- رندر ویدیو اکثر افکت‌های ورود، تاکید، خروج و مسیر حرکتی رایج را پشتیبانی می‌کند، اما همهٔ افکت‌های PowerPoint پشتیبانی نمی‌شوند. جدول [انیمیشن‌ها و افکت‌های پشتیبانی‌شده](/slides/fa/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) را بررسی کنید و ارائه‌های مهم را با نسخه هدف Aspose.Slides خود آزمایش کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های واردشده از فرمت‌های دیگر ممکن است در فایل حفظ شوند اما در PowerPoint، HTML5 یا ویدیو به‌صورت متفاوتی رندر شوند. نتیجهٔ صادرات را ارزیابی کنید نه فقط بر پایهٔ نام افکت.

## **سوالات متداول**

**چرا یک انیمیشن در PowerPoint نمایش داده می‌شود اما در PDF نیست؟**

PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید پخش نمی‌شوند. برای حفظ حرکت، به HTML5، GIF انیمیشنی یا ویدیو صادرات کنید.

**چرا یک افکت در ویدیو متفاوت اجرا می‌شود؟**

صادرات ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی PowerPoint را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی نمی‌شوند یا به‌صورت تخمینی اجرا می‌شوند. جدول افکت‌های پشتیبانی‌شده را بررسی کنید و ارائهٔ واقعی را پیش از استفادهٔ تولیدی تست کنید.

**آیا جابه‌جایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

خیر. ترتیب z‑order شکل فقط روی هم‌چسبی آن تأثیر می‌گذارد، در حالی که ترتیب توالی و محرک‌ها پخش انیمیشن را کنترل می‌کنند. اگر به ترتیب پخش متفاوتی نیاز دارید، زمان‌سنج را تغییر دهید.