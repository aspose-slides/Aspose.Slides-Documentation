---
title: ใช้การเคลื่อนไหวของรูปทรงในงานนำเสนอด้วย JavaScript
linktitle: การเคลื่อนไหวของรูปทรง
type: docs
weight: 60
url: /th/nodejs-java/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟกต์
- รูปทรงเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- รับการเคลื่อนไหว
- แยกการเคลื่อนไหว
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- แยกเอฟเฟกต์
- เสียงเอฟเฟกต์
- นำการเคลื่อนไหวไปใช้
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม ตรวจสอบ และปรับแต่งการเคลื่อนไหวของรูปทรง, การตั้งเวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหว, และข้อความที่เคลื่อนไหวด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java แสดงการเคลื่อนไหวของสไลด์เป็น **effect** ใน **timeline** ของสไลด์ **effect** จะมีรูปทรงเป้าหมาย, ประเภทและชนิดย่อยของการเคลื่อนไหว, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่น เสียงหรือพฤติกรรมหลังการเคลื่อนไหว

ไทม์ไลน์มีลำดับสองประเภท:

- **main sequence** เล่นเมื่อสไลด์ก้าวหน้า
- **interactive sequence** เริ่มเมื่อคลิกที่รูปทรงตัวกระตุ้น

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตาราง, และวัตถุสไลด์อื่น ๆ เป็นวัตถุ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) คุณจึงใช้เมธอดเดียวกัน [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) สำหรับเนื้อหาสไลด์ส่วนใหญ่ เอฟเฟกต์ที่ใช้ได้ถูกระบุใน enumeration [EffectType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttype/)

## **เพิ่มการเคลื่อนไหวให้ Shape**

เพื่อเพิ่มการเคลื่อนไหว ให้รับ **main sequence** ของสไลด์และเรียก [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) พร้อมรูปทรงเป้าหมาย, ประเภทเอฟเฟกต์, ชนิดย่อย, และตัวกระตุ้น สำหรับเอฟเฟกต์ที่เริ่มเมื่อคลิกรูปทรงอื่น ให้สร้าง **interactive sequence** ที่ตัวกระตุ้นคือรูปทรงนั้น

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวสองประเภทและบันทึกผลเป็น `shape-animations.pptx`

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

ตัวกระตุ้นกำหนดว่าเอฟเฟกต์จะเริ่มเมื่อใด:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttriggertype/#OnClick) รอคลิกใน **main sequence** หรือคลิกที่รูปทรงตัวกระตุ้นใน **interactive sequence**
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าจบ

เพื่อเคลื่อนไหวรูปภาพ, แผนภูมิ, หรือรูปทรงประเภทอื่น ให้ส่งวัตถุนั้นไปยัง [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) แทน `targetShape` สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ดูที่ [Animated Charts](/slides/th/nodejs-java/animated-charts/)

## **อ่านการเคลื่อนไหวของ Shape**

ใช้ [Sequence.getEffectsByShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#getEffectsByShape) เมื่อคุณรู่วัตถุเป้าหมาย เพื่อสำรวจทุกเอฟเฟกต์ให้วนลูป **main sequence** และทุก **interactive sequence** การวนรอบหลีกเลี่ยงการสันนิษฐานว่าลำดับใดมีเอฟเฟกต์ที่ตำแหน่ง `0`

ตัวอย่างต่อไปนี้สร้าง Shape ที่มีเอฟเฟกต์ **main‑sequence** และ **interactive**, ดึงเอฟเฟกต์ที่เป้าหมายเป็น Shape นี้, แล้ววนลูปทุกลำดับบนสไลด์

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

หากคุณต้องการเอฟเฟกต์สำหรับ Shape เพียงอันเดียว ให้ระบุ Shape ตามชื่อ, ประเภท placeholder, หรือคุณสมบัติคงที่อื่น ๆ ก่อนเรียก [Sequence.getEffectsByShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#getEffectsByShape) อย่าสันนิษฐานว่า [ShapeCollection.get_Item](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#get_Item) ที่ตำแหน่ง `0` เป็นวัตถุที่ต้องการเสมอ

## **ทำงานกับเอฟเฟกต์ Placeholder ที่สืบทอด**

Placeholder บนสไลด์ธรรมดาสามารถสืบทอดพฤติกรรมการเคลื่อนไหวจาก Placeholder ที่สอดคล้องบนสไลด์ Layout และ Master ได้ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getBasePlaceholder) คืนค่า Placeholder พ่อแม่ หรือ `null` หากไม่มีพ่อแม่

ในตัวอย่างการนำเสนอด้านล่าง, ส่วนท้าย (footer) มี **Random Bars** บนสไลด์ธรรมดา, **Split** บน Layout, และ **Fly In** บน Master

![Footer animation effect on the normal slide](slide-shape-animation.png)

![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)

![Footer placeholder animation effect on the master slide](master-shape-animation.png)

ตัวอย่างต่อไปใช้โครงสร้าง Placeholder จากการนำเสนอใหม่ เพิ่มเอฟเฟกต์ให้กับ Placeholder ของ Master, Layout, และ Placeholder ที่สอดคล้องบนสไลด์ธรรมดา ทุกการเรียก [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getBasePlaceholder) จะตรวจสอบค่าที่คืนมาก่อนนำไปใช้

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

## **เปลี่ยนการตั้งค่าเวลาเคลื่อนไหว**

กล่องโต้ตอบ **Timing** ของ PowerPoint แสดงคุณสมบัติของ [Timing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/)

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** แผนที่ไปยัง [Timing.getTriggerType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getTriggerType)
- **Duration** แผนที่ไปยัง [Timing.getDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getDuration) หน่วยเป็นวินาที
- **Delay** แผนที่ไปยัง [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) หน่วยเป็นวินาที
- **Repeat** แผนที่ไปยัง [Timing.getRepeatCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick), หรือ [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide)
- **Rewind when done playing** แผนที่ไปยัง [Timing.getRewind](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRewind)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์, เปลี่ยนเวลาโดยใช้วัตถุที่คืนจาก [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect), แล้วบันทึกผล การเก็บอ้างอิง [Effect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/) ที่คืนมาช่วยหลีกเลี่ยงการอ้างอิงตำแหน่งในคอลเลกชันที่ไม่จำเป็น

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

ใช้โหมดการทำซ้ำแบบใดแบบหนึ่งอย่างตั้งใจ การผสมจำนวนการทำซ้ำกับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในตัวดูต่าง ๆ เมื่อเปลี่ยนโหมดทำซ้ำ ให้ตั้งค่า [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) และ [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) ก่อน [Timing.setRepeatCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#setRepeatCount) เนื่องจากการตั้งค่าใดแฟล็กหนึ่งจะเปลี่ยนโหมดทำซ้ำที่ใช้งานอยู่ด้วย

## **เพิ่มและดึงเสียงจากการเคลื่อนไหว**

เอฟเฟกต์การเคลื่อนไหวสามารถอ้างอิงไฟล์เสียงแบบฝังได้ผ่าน [Effect.getSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getSound)  [Effect.setStopPreviousSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setStopPreviousSound) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มโดยเอฟเฟกต์ก่อนหน้า

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปคาดว่าจะมีไฟล์เสียงในเครื่องชื่อ `animation-sound.wav` สร้างเอฟเฟกต์สองอัน ฝังไฟล์นั้นเป็นเสียงของเอฟเฟกต์แรก และตั้งค่าเอฟเฟกต์ที่สองให้หยุดเสียง ใช้วัตถุที่คืนจาก [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) จึงไม่ต้องระบุดัชนีลำดับ

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

### **ดึงเสียงที่ฝังอยู่จากเอฟเฟกต์**

ตัวอย่างต่อไปคาดว่าจะมีการนำเสนอในเครื่องชื่อ `presentation-with-animation-sounds.pptx` มาสแกนทั้ง **main** และ **interactive sequences** แล้วเขียนไฟล์เสียงที่ฝังทุกไฟล์ลงในโฟลเดอร์ `extracted-animation-sounds` ส่วนขยายไฟล์ถูกเลือกจาก MIME type ของเสียงที่ให้โดย [Audio.getContentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audio/#getContentType)

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

สำหรับอ็อบเจ็กต์เสียงขนาดใหญ่ ให้ใช้ [Audio.getStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audio/#getStream) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดอ็อบเจ็กต์ทั้งหมดเข้าสู่ byte array

## **ตั้งค่าพฤติกรรม After‑Animation**

ตัวเลือก **After animation** กำหนดว่าจะทำอย่างไรกับ Shape หลังจากเอฟเฟกต์เสร็จสิ้น

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

enumeration [AfterAnimationType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/) รองรับการปล่อย Shape ไ้อยู่เดิม, เปลี่ยนสี, ซ่อนหลังการเคลื่อนไหว, หรือซ่อนเมื่อคลิกต่อไป เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#Color) ให้ตั้งค่า [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) ด้วย

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์, ตั้งค่าพฤติกรรม After‑Animation ผ่านอ็อบเจ็กต์เอฟเฟกต์ที่คืนมา, แล้วบันทึกผล

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

เปลี่ยนประเภทจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#Color) จะล้างค่าการตั้งสี After‑Animation

## **เคลื่อนไหวข้อความ**

การเคลื่อนไหวข้อความมีการควบคุมสองอย่างที่เกี่ยวข้อง:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textanimation/#getBuildType) ควบคุมว่าข้อความปรากฏพร้อมกันหรือระดับย่อหน้าทีละบรรทัด
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getAnimateTextType) ควบคุมว่าข้อความปรากฏทั้งหมดพร้อมกัน, ตามคำ, หรือตามตัวอักษร [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) ตั้งค่าความหน่วงระหว่างคำหรืออักษร ค่าบวกเป็นเปอร์เซ็นต์ของระยะเวลาเอฟเฟกต์; ค่าลบเป็นความหน่วงเป็นวินาที

ตัวอย่างอิสระต่อไปนี้เคลื่อนไหวคำในกล่องข้อความ [BuildType.AsOneObject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/buildtype/#AsOneObject) ปิดการสร้างตามย่อหน้าจึงทำให้การตั้งค่าคำใช้กับกรอบข้อความทั้งหมด

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

หากต้องการสร้างกล่องข้อความตามย่อหน้า ให้ตั้งค่า [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (หรือระดับย่อหน้าอื่น) เพื่อให้ย่อหน้าเดียวมีเอฟเฟกต์ของตนเอง ให้ใช้ overload ของ [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) ที่รับ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) ดูที่ [Animated Text](/slides/th/nodejs-java/animated-text/) สำหรับตัวอย่างระดับย่อหน้า

## **การส่งออกและหมายเหตุความเข้ากันได้**

- การบันทึกเป็น PPT หรือ PPTX จะเก็บโมเดลการเคลื่อนไหวไว้ แต่การเล่นสุดท้ายขึ้นอยู่กับโปรแกรมดูไฟล์นำเสนอ
- PDF และรูปภาพคงที่ไม่เล่นการเคลื่อนไหว ใช้ [HTML5 export](/slides/th/nodejs-java/export-to-html5/), GIF เคลื่อนไหว, หรือ [video conversion](/slides/th/nodejs-java/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนไหว
- สำหรับ HTML5 ให้เปิดใช้งาน [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/#setAnimateShapes) และเมื่อจำเป็นให้เปิด [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/#setAnimateTransitions)
- การเรนเดอร์วิดีโอรองรับเอฟเฟกต์เข้ามา, เน้น, ออกจาก, และเส้นทางการเคลื่อนที่หลายแบบ แต่ไม่ใช่ทุกเอฟเฟกต์ของ PowerPoint ตรวจสอบ [supported animations and effects](/slides/th/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) ปัจจุบันและทดสอบการนำเสนอสำคัญกับเวอร์ชัน Aspose.Slides ที่ใช้
- เอฟเฟกต์แบบกำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบไฟล์นำเสนออื่นอาจถูกเก็บไว้ในไฟล์แต่แสดงผลแตกต่างกันใน PowerPoint, HTML5 หรือวิดีโอ ตรวจสอบผลการส่งออกแทนการพึ่งพาแค่ชื่อเอฟเฟกต์

## **คำถามที่พบบ่อย**

**ทำไมการเคลื่อนไหวถึงปรากฏใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบคงที่ จึงไม่มีการเล่นการเคลื่อนไหวหรือการเปลี่ยนสไลด์ ส่งออกเป็น HTML5, GIF เคลื่อนไหว, หรือวิดีโอเมื่อต้องการรักษาการเคลื่อนไหว

**ทำไมเอฟเฟกต์ถึงทำงานต่างกันในวิดีโอ?**

การส่งออกวิดีโอเรนเดอร์การเคลื่อนไหวแทนการเก็บพฤติกรรมดั้งเดิมของ PowerPoint บางเอฟเฟกต์ขั้นสูงอาจไม่รองรับหรือถูกประมาณ ตรวจสอบตารางเอฟเฟกต์ที่สนับสนุนและทดสอบการนำเสนอจริงก่อนการผลิต

**การย้าย Shape ไปข้างหน้าหรือข้างหลังเปลี่ยนลำดับการเคลื่อนไหวหรือไม่?**

ไม่. z‑order ของ Shape ควบคุมการทับกัน ส่วนลำดับลำดับและตัวกระตุ้นควบคุมการเล่นการเคลื่อนไหว ปรับไทม์ไลน์หากต้องการลำดับการเล่นที่ต่างกัน