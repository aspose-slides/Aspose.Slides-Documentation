---
title: اعمال انیمیشن‌های شکل در ارائه‌ها با استفاده از جاوااسکریپت
linktitle: انیمیشن شکل
type: docs
weight: 60
url: /fa/nodejs-java/shape-animation/
keywords:
- شکل
- انیمیشن
- افکت
- شکل متحرک
- متن متحرک
- افزودن انیمیشن
- دریافت انیمیشن
- استخراج انیمیشن
- افزودن افکت
- دریافت افکت
- استخراج افکت
- صدا افکت
- اعمال انیمیشن
- پاورپوینت
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه انیمیشن‌های شکل را اضافه، بررسی و سفارشی‌سازی کنید، زمان‌بندی، صداها، رفتار پس از انیمیشن و متن متحرک را با Aspose.Slides برای Node.js از طریق Java مدیریت نمایید."
---
## **بررسی کلی**

Aspose.Slides for Node.js via Java انیمیشن‌های اسلاید را به صورت افکت‌ها در یک جدول زمانی اسلاید نمایش می‌دهد. یک افکت شامل شکل هدف، نوع و زیرنوع انیمیشن، محرک، تنظیمات زمان‌بندی و ویژگی‌های اختیاری مانند صدا یا رفتار پس از انیمیشن است.

جدول زمانی دو نوع دنباله دارد:

- **دنباله اصلی** که هنگام پیشرفت اسلاید اجرا می‌شود.
- **دنباله تعاملی** که با کلیک روی شکل محرک آن شروع می‌شود.

از آنجا که جعبه‌های متنی، تصاویر، نمودارها، جدول‌ها و سایر اشیای اسلاید از نوع [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/) هستند، برای اکثر محتویات اسلاید از همان روش [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) استفاده می‌کنید. افکت‌های موجود در شمارش [EffectType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttype/) فهرست شده‌اند.

## **اضافه کردن انیمیشن به شکل‌ها**

برای اضافه کردن انیمیشن، دنباله اصلی اسلاید را دریافت کنید و با فراخوانی [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) شکل هدف، نوع افکت، زیرنوع و محرک را مشخص کنید. برای افکتی که با کلیک روی شکل دیگری شروع می‌شود، یک دنباله تعاملی ایجاد کنید که محرکش همان شکل دیگر باشد.

مثال زیر هر دو نوع انیمیشن را ایجاد کرده و نتیجه را در فایل `shape-animations.pptx` ذخیره می‌کند.

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

محرک تعیین می‌کند افکت چه زمانی شروع شود:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttriggertype/#OnClick) برای کلیک در دنباله اصلی یا برای کلیک روی شکل محرک در یک دنباله تعاملی صبر می‌کند.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) همراه با افکت قبلی شروع می‌شود.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) پس از پایان افکت قبلی آغاز می‌شود.

برای انیمیشن تصویر، نمودار یا هر نوع شکل دیگری، به جای `targetShape` همان شی را به [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) پاس دهید. برای گزینه‌های گروه‌بندی مخصوص نمودار، به [Animated Charts](/slides/fa/nodejs-java/animated-charts/) مراجعه کنید.

## **خواندن انیمیشن‌های شکل**

هنگامی که شکل هدف را می‌دانید، از [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#getEffectsByShape) استفاده کنید. برای بررسی هر افکت، دنباله اصلی و تمام دنباله‌های تعاملی را مرور کنید. این enumeration از فرض داشتن افکتی در اندیس `0` جلوگیری می‌کند.

مثال زیر یک شکل با افکت‌های دنباله اصلی و تعاملی ایجاد می‌کند، افکت‌های هدف‌دار به آن شکل را دریافت می‌کند و سپس تمام دنباله‌های اسلاید را مرور می‌کند.

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

اگر تنها به افکت‌های یک شکل نیاز دارید، ابتدا شکل را با نام، نوع نگهدارنده یا ویژگی ثابت دیگری شناسایی کنید؛ سپس [Sequence.getEffectsByShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#getEffectsByShape) را فراخوانی کنید. فرض نکنید که [ShapeCollection.get_Item](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#get_Item) در اندیس `0` همیشه شی مورد نظر است.

## **کار با افکت‌های نگهدارنده ارث‌برده**

یک نگهدارنده در اسلاید عادی می‌تواند رفتار انیمیشن را از نگهدارنده متناظر در اسلاید طرح‌بندی و اسلاید مستر به ارث ببرد. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getBasePlaceholder) آن نگهدارنده والد را برمی‌گرداند یا `null` وقتی والد موجود نیست.

در ارائهٔ نمونهٔ زیر، فوتر در اسلاید عادی دارای **Random Bars**، در اسلاید طرح‌بندی **Split** و در اسلاید مستر **Fly In** دارد.

![انیمیشن افکت فوتر در اسلاید عادی](slide-shape-animation.png)

![انیمیشن افکت نگهدارنده فوتر در اسلاید طرح‌بندی](layout-shape-animation.png)

![انیمیشن افکت نگهدارنده فوتر در اسلاید مستر](master-shape-animation.png)

مثال بعدی از یک سلسله مراتب نگهدارنده در یک ارائهٔ جدید استفاده می‌کند. افکت‌ها را به یک نگهدارندهٔ مستر، یک نگهدارندهٔ طرح‌بندی و نگهدارندهٔ متناظر در اسلاید عادی اضافه می‌کند. هر بار قبل از استفاده از شکل بازگردانده‌شده، فراخوانی به [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getBasePlaceholder) بررسی می‌شود.

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

دیالوگ **Timing** در پاورپوینت به ویژگی‌های [Timing](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/) نگاشت می‌شود.

![دیالوگ Timing در پاورپوینت برای یک افکت انیمیشن](shape-animation.png)

- **Start** به [Timing.getTriggerType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getTriggerType) نگاشت می‌شود.
- **Duration** به [Timing.getDuration](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getDuration) (برحسب ثانیه) نگاشت می‌شود.
- **Delay** به [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) (برحسب ثانیه) نگاشت می‌شود.
- **Repeat** به [Timing.getRepeatCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatCount)، [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) یا [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) نگاشت می‌شود.
- **Rewind when done playing** به [Timing.getRewind](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#getRewind) نگاشت می‌شود.

این مثال مستقل یک افکت اضافه می‌کند، زمان‌بندی آن را از طریق شی بازگشتی [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) تغییر می‌دهد و نتیجه را ذخیره می‌کند. نگه‌داشتن مرجع بازگشتی [Effect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/) از ایندکس‌گذاری غیرضروری جلوگیری می‌کند.

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

از یک حالت تکرار به‌طور عمدی استفاده کنید. ترکیب شمارش تکرار با پرچم «until» می‌تواند نتایج گیجی در نماگرهای مختلف ایجاد کند. هنگام تغییر حالت‌های تکرار، ابتدا [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) و [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) را تنظیم کنید و سپس [Timing.setRepeatCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/timing/#setRepeatCount) را صدا بزنید؛ زیرا تنظیم هرکدام از پرچم‌ها حالت تکرار فعال را نیز تغییر می‌دهد.

## **اضافه کردن و استخراج صداهای انیمیشن**

یک افکت انیمیشن می‌تواند صوتی جاسازی‌شده را از طریق [Effect.getSound](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getSound) ارجاع دهد. [Effect.setStopPreviousSound](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#setStopPreviousSound) به افکت می‌گوید صداهای شروع‌شده توسط افکت قبلی را متوقف کند.

### **اضافه کردن صدا به یک افکت**

مثال زیر انتظار دارد فایلی صوتی محلی به نام `animation-sound.wav` موجود باشد. دو افکت ایجاد می‌کند، همان فایل را به عنوان صدا برای اولین افکت جاسازی می‌کند و افکت دوم را پیکربندی می‌سازد تا صدا را متوقف کند. از اشیای بازگشتی [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) استفاده می‌کند، بنابراین نیازی به اندیس دنباله نیست.

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

### **استخراج صداهای افکت جاسازی‌شده**

مثال زیر انتظار دارد یک ارائهٔ محلی به نام `presentation-with-animation-sounds.pptx` وجود داشته باشد. هر دو دنباله اصلی و تعاملی را اسکن می‌کند و تمام صداهای افکت جاسازی‌شده را در پوشه `extracted-animation-sounds` می‌نویسد. پسوند بر اساس نوع MIME صوتی که توسط [Audio.getContentType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audio/#getContentType) برگردانده می‌شود، انتخاب می‌شود.

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

برای اشیای صوتی بزرگ، از [Audio.getStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/audio/#getStream) استفاده کنید و جریان را به یک فایل کپی کنید به‌جای بارگذاری کل شی در آرایه بایت.

## **تنظیم رفتار پس از انیمیشن**

گزینه **After animation** تعیین می‌کند پس از اتمام افکت، چه اتفاقی برای شکل بیفتد.

![دیالوگ گزینه‌های افکت در پاورپوینت که تنظیمات After animation را نشان می‌دهد](shape-after-animation.png)

شمارش [AfterAnimationType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/) از باقی‌مانده‌مانند شکل، تغییر رنگ، مخفی‌سازی پس از انیمیشن یا مخفی‌سازی در کلیک بعدی پشتیبانی می‌کند. وقتی نوع [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/#Color) باشد، همچنین [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) را تنظیم کنید.

این مثال مستقل یک افکت ایجاد می‌کند، رفتار پس‑انیمیشن آن را از طریق شی افکت بازگشتی تنظیم می‌کند و نتیجه را ذخیره می‌نماید.

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

تغییر نوع از [AfterAnimationType.Color](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/afteranimationtype/#Color) باعث پاک شدن تنظیم رنگ پس‑انیمیشن می‌شود.

## **انیمیشن متن**

انیمیشن متن دو کنترل مرتبط دارد:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/textanimation/#getBuildType) تعیین می‌کند پاراگراف‌ها به‌صورت یکجا یا به‌صورت پاراگرافی ظاهر شوند.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getAnimateTextType) تعیین می‌کند متن به‌صورت یکجا، واژه به واژه یا حرف به حرف ظاهر شود. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) تاخیر بین واژه‌ها یا حروف را تعیین می‌کند. مقدار مثبت درصدی از مدت افکت است؛ مقدار منفی تاخیر برحسب ثانیه است.

مثال مستقل زیر واژه‌های یک جعبهٔ متنی را انیمیشن می‌دهد. [BuildType.AsOneObject](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/buildtype/#AsOneObject) ساخت پاراگراف به‌پارگراف را غیرفعال می‌کند تا تنظیم واژه برای تمام فریم متنی اعمال شود.

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

برای ساخت یک جعبهٔ متنی بر اساس پاراگراف، [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (یا سطح پاراگراف دیگر) را تنظیم کنید. برای هدف‌گذاری یک پاراگراف واحد با افکت خود، از overload متد [Sequence.addEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/sequence/#addEffect) که یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) می‌گیرد، استفاده کنید. برای مثال‌های سطح پاراگراف به [Animated Text](/slides/fa/nodejs-java/animated-text/) مراجعه کنید.

## **صادرات و نکات سازگاری**

- ذخیره به فرمت PPT یا PPTX مدل انیمیشن را حفظ می‌کند، اما پخش نهایی توسط برنامهٔ نمایش ارائه کنترل می‌شود.
- PDF و تصاویر ثابت انیمیشن را پخش نمی‌کنند. هنگامی که خروجی باید حرکت را نشان دهد، از [HTML5 export](/slides/fa/nodejs-java/export-to-html5/)، GIF متحرک یا [video conversion](/slides/fa/nodejs-java/convert-powerpoint-to-video/) استفاده کنید.
- برای HTML5، [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/#setAnimateShapes) را فعال کنید و در صورت نیاز [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/html5options/#setAnimateTransitions) را تنظیم کنید.
- رندر ویدیو از بسیاری از افکت‌های ورودی، تأکید، خروج و مسیر حرکتی پشتیبانی می‌کند، اما هر افکت پاورپوینت پشتیبانی نمی‌شود. جدول [supported animations and effects](/slides/fa/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) فعلی را بررسی کنید و ارائه‌های بحرانی را با نسخهٔ هدف Aspose.Slides خود تست کنید.
- افکت‌های سفارشی پیشرفته و افکت‌های واردشده از قالب‌های دیگر ممکن است در فایل حفظ شوند اما در پاورپوینت، HTML5 یا ویدیو به‌صورت متفاوتی رندر شوند. به‌جای اعتماد صرف به نام افکت، نتیجهٔ صادرات را اعتبارسنجی کنید.

## **پرسش‌های متداول**

**چرا یک انیمیشن در پاورپوینت نمایش داده می‌شود اما در PDF نیست؟**

PDF یک فرمت ثابت است، بنابراین انیمیشن‌ها و انتقال‌های اسلاید اجرا نمی‌شوند. برای حفظ حرکت، به HTML5، GIF متحرک یا ویدیو خروجی دهید.

**چرا یک افکت در ویدیو متفاوت اجرا می‌شود؟**

خروجی ویدیو انیمیشن‌ها را رندر می‌کند نه اینکه رفتار اصلی پاورپوینت را ذخیره کند. برخی افکت‌های پیشرفته پشتیبانی یا تقریباً شبیه‌سازی نمی‌شوند. جدول افکت‌های پشتیبانی‌شده را بررسی کنید و قبل از استفاده در تولید، ارائهٔ واقعی را تست کنید.

**آیا جابجایی یک شکل به جلو یا عقب ترتیب انیمیشن آن را تغییر می‌دهد؟**

نه. ترتیب z-order شکل فقط بر هم‌پوشانی تأثیر می‌گذارد، در حالی که ترتیب دنباله و محرکان بر پخش انیمیشن کنترل دارند. اگر نیاز به ترتیب پخش متفاوت دارید، جدول زمانی را تغییر دهید.