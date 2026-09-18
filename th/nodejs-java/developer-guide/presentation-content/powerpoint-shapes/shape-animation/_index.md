---
title: ใช้งานการเคลื่อนไหวรูปทรงในงานนำเสนอด้วย JavaScript
linktitle: การเคลื่อนไหวรูปทรง
type: docs
weight: 60
url: /th/nodejs-java/shape-animation/
keywords:
- รูปทรง
- การเคลื่อนไหว
- เอฟเฟ็กต์
- รูปทรงเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนไหว
- ดึงการเคลื่อนไหว
- แยกการเคลื่อนไหว
- เพิ่มเอฟเฟ็กต์
- ดึงเอฟเฟ็กต์
- แยกเอฟเฟ็กต์
- เสียงเอฟเฟ็กต์
- นำการเคลื่อนไหวไปใช้
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, ตรวจสอบและปรับแต่งการเคลื่อนไหวของรูปทรง, การกำหนดเวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหว, และข้อความเคลื่อนไหวด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **Overview**

เพื่อทำงานกับพฤติกรรมแต่ละอย่างภายในเอฟเฟ็กต์หรือแก้ไขส่วนของ motion‑path ให้ดูที่ [การเคลื่อนไหวแบบกำหนดเอง](/slides/th/nodejs-java/custom-animation/)।

Aspose.Slides for Node.js via Java แสดงการเคลื่อนไหวของสไลด์เป็นเอฟเฟ็กต์ในไทม์ไลน์ของสไลด์ เอฟเฟ็กต์หนึ่งมีรูปทรงเป้าหมาย, ประเภทและชนิดย่อยของการเคลื่อนไหว, ตัวกระตุ้น, การตั้งค่าการกำหนดเวลา, และคุณสมบัติเสริมเช่นเสียงหรือพฤติกรรมหลังการเคลื่อนไหว

ไทม์ไลน์มีสองประเภทของลำดับ:

- **main sequence** จะเล่นเมื่อสไลด์ก้าวหน้า
- **interactive sequence** จะเริ่มเมื่อคลิกที่รูปทรงที่เป็นตัวกระตุ้น

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตารางและวัตถุสไลด์อื่น ๆ เป็นวัตถุ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) คุณจะใช้เมธอด [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) เดียวกันสำหรับเนื้อหาในสไลด์ส่วนใหญ่ เอฟเฟ็กต์ที่ใช้ได้จะถูกระบุใน enumeration [EffectType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttype/)

## **Add Shape Animations**

เพื่อเพิ่มการเคลื่อนไหว ให้ดึง main sequence ของสไลด์และเรียก [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) พร้อมรูปทรงเป้าหมาย, ประเภทเอฟเฟ็กต์, ชนิดย่อยและตัวกระตุ้น สำหรับเอฟเฟ็กต์ที่เริ่มเมื่อคลิกรูปทรงอื่น ให้สร้าง interactive sequence ที่ตัวกระตุ้นคือรูปทรงนั้น

ตัวอย่างต่อไปนี้สร้างการเคลื่อนไหวทั้งสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`

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

ตัวกระตุ้นกำหนดว่าเอฟเฟ็กต์จะเริ่มเมื่อใด:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttriggertype/#OnClick) รอการคลิกใน main sequence หรือคลิกที่รูปทรงตัวกระตุ้นใน interactive sequence
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) เริ่มพร้อมกับเอฟเฟ็กต์ก่อนหน้า
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) เริ่มเมื่อเอฟเฟ็กต์ก่อนหน้าสิ้นสุด

หากต้องการเคลื่อนไหวรูปภาพ, แผนภูมิ หรือรูปทรงชนิดอื่น ให้ส่งออบเจ็กต์นั้นไปยัง [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) แทน `targetShape` สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ ดูที่ [Animated Charts](/slides/th/nodejs-java/animated-charts/)

## **Read Shape Animations**

ใช้ [Sequence.getEffectsByShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#getEffectsByShape) เมื่อคุณรู้รูปทรงเป้าหมาย เพื่อตรวจสอบเอฟเฟ็กต์ทุกตัว ให้วนลูปผ่าน main sequence และทุก interactive sequence การวนลูปช่วยหลีกเลี่ยงการสมมติว่ามีเอฟเฟ็กต์ที่ดัชนี `0`

ตัวอย่างต่อไปนี้สร้างรูปทรงที่มีเอฟเฟ็กต์ใน main‑sequence และ interactive, ดึงเอฟเฟ็กต์ที่เป้าหมายเป็นรูปทรงนั้น, แล้ววนลูปผ่านทุกลำดับในสไลด์

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

หากคุณต้องการเอฟเฟ็กต์เฉพาะรูปทรงหนึ่ง ให้ระบุตัวรูปโดยชื่อ, ประเภท placeholder, หรือคุณสมบัติลักษณะคงที่อื่น ๆ ก่อน แล้วเรียก [Sequence.getEffectsByShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#getEffectsByShape) อย่าสมมติว่า [ShapeCollection.get_Item](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#get_Item) ที่ดัชนี `0` เป็นออบเจ็กต์ที่ต้องการเสมอ

## **Work with Inherited Placeholder Effects**

Placeholder บนสไลด์ปกติสามารถสืบทอดพฤติกรรมการเคลื่อนไหวจาก placeholder ที่สอดคล้องกันบนสไลด์เลเอาต์และมาสเตอร์ได้ [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getBasePlaceholder) จะคืนค่า placeholder พาเรนต์นั้น, หรือ `null` หากไม่มีพาเรนต์

ในตัวอย่างการนำเสนอด้านล่าง, ฟุตเตอร์มี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลเอาต์, และ **Fly In** บนสไลด์มาสเตอร์

![Footer animation effect on the normal slide](slide-shape-animation.png)
![Footer placeholder animation effect on the layout slide](layout-shape-animation.png)
![Footer placeholder animation effect on the master slide](master-shape-animation.png)

ตัวอย่างต่อไปใช้โครงสร้าง hierarchy ของ placeholder จากการนำเสนอใหม่ เพิ่มเอฟเฟ็กต์ให้กับ placeholder ของมาสเตอร์, placeholder ของเลเอาต์, และ placeholder ที่สอดคล้องกันบนสไลด์ปกติ ทุกการเรียก [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getBasePlaceholder) จะตรวจสอบก่อนนำรูปที่คืนค่ามาใช้

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

## **Change Animation Timing**

กล่องโต้ตอบ **Timing** ของ PowerPoint แผนที่กับคุณสมบัติของ [Timing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/)

![PowerPoint Timing dialog for an animation effect](shape-animation.png)

- **Start** แผนที่กับ [Timing.getTriggerType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getTriggerType)
- **Duration** แผนที่กับ [Timing.getDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getDuration) หน่วยเป็นวินาที
- **Delay** แผนที่กับ [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) หน่วยเป็นวินาที
- **Repeat** แผนที่กับ [Timing.getRepeatCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) หรือ [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide)
- **Rewind when done playing** แผนที่กับ [Timing.getRewind](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRewind)

ตัวอย่างอิสระนี้เพิ่มเอฟเฟ็กต์, แก้ไขการกำหนดเวลาผ่านออบเจ็กต์ที่คืนจาก [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect), แล้วบันทึกผลลัพธ์ การเก็บอ้างอิง [Effect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/) ที่คืนมาช่วยหลีกเลี่ยงการอ้างอิงดัชนีคอลเลกชันที่ไม่จำเป็น

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

ใช้โหมดการทำซ้ำเดียวอย่างตั้งใจ การผสมจำนวนการทำซ้ำกับแฟล็ก “until” อาจทำให้ผลลัพธ์สับสนในผู้ชมที่ต่างกัน เมื่อเปลี่ยนโหมดการทำซ้ำ ให้ตั้งค่า [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) และ [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) ก่อน [Timing.setRepeatCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#setRepeatCount) เนื่องจากการตั้งค่าแฟล็กใดแฟล็กหนึ่งจะเปลี่ยนโหมดการทำซ้ำที่ใช้งานอยู่

## **Add and Extract Animation Sounds**

เอฟเฟ็กต์การเคลื่อนไหวสามารถอ้างอิงเสียงที่ฝังอยู่ผ่าน [Effect.getSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getSound) [Effect.setStopPreviousSound](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#setStopPreviousSound) บอกเอฟเฟ็กต์ให้หยุดเสียงที่เริ่มโดยเอฟเฟ็กต์ก่อนหน้า

### **Add a Sound to an Effect**

ตัวอย่างต่อไปนี้คาดว่ามีไฟล์เสียงในเครื่องชื่อ `animation-sound.wav` สร้างเอฟเฟ็กต์สองตัว, ฝังไฟล์นั้นเป็นเสียงของเอฟเฟ็กต์แรก, และกำหนดให้เอฟเฟ็กต์ที่สองหยุดเสียง ใช้วัตถุที่คืนจาก [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) ดังนั้นไม่ต้องระบุดัชนีของซีเควนซ์

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

### **Extract Embedded Effect Sounds**

ตัวอย่างต่อไปนี้คาดว่ามีการนำเสนอในเครื่องชื่อ `presentation-with-animation-sounds.pptx` มาสแกนทั้ง main และ interactive sequences และเขียนเสียงเอฟเฟ็กต์ที่ฝังอยู่ทั้งหมดไปยังโฟลเดอร์ `extracted-animation-sounds` ส่วนขยายไฟล์จะเลือกจาก MIME type ของเสียงที่ให้โดย [Audio.getContentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audio/#getContentType)

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

สำหรับออบเจ็กต์เสียงขนาดใหญ่ ให้ใช้ [Audio.getStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/audio/#getStream) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดออบเจ็กต์ทั้งหมดเป็นอาร์เรย์ไบต์

## **Set After-Animation Behavior**

ตัวเลือก **After animation** ควบคุมว่าจะเกิดอะไรกับรูปทรงหลังจากเอฟเฟ็กต์เสร็จสิ้น

![PowerPoint Effect Options dialog showing After animation settings](shape-after-animation.png)

enumeration [AfterAnimationType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/) รองรับการปล่อยให้รูปทรงคงที่, เปลี่ยนสี, ซ่อนหลังการเคลื่อนไหว, หรือซ่อนเมื่อคลิกครั้งต่อไป เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#Color) ให้ตั้งค่า [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getAfterAnimationColor) ด้วย

ตัวอย่างอิสระนี้สร้างเอฟเฟ็กต์, ตั้งพฤติกรรมหลังการเคลื่อนไหวผ่านออบเจ็กต์เอฟเฟ็กต์ที่คืนมา, แล้วบันทึกผลลัพธ์

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

การเปลี่ยนประเภทออกจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/afteranimationtype/#Color) จะลบการตั้งค่าสีหลังการเคลื่อนไหว

## **Animate Text**

การเคลื่อนไหวของข้อความมีการควบคุมสองส่วนที่เกี่ยวข้อง:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textanimation/#getBuildType) ควบคุมว่าข้อความย่อยปรากฏพร้อมกันหรือเป็นระดับย่อหน้า
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getAnimateTextType) ควบคุมว่าข้อความปรากฏทั้งหมดพร้อมกัน, ทีละคำ, หรือทีละอักษร [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) ตั้งค่าการหน่วงเวลาระหว่างคำหรืออักษร ค่าเป็นบวกหมายถึงเปอร์เซ็นต์ของระยะเวลาดีเอฟเฟ็กต์; ค่าเป็นลบหมายถึงหน่วงเวลาเป็นวินาที

ตัวอย่างอิสระต่อไปนี้เคลื่อนไหวคำในกล่องข้อความ [BuildType.AsOneObject](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/buildtype/#AsOneObject) ปิดการสร้างทีละย่อหน้าเพื่อให้การตั้งค่าคำใช้กับเฟรมข้อความทั้งหมด

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

หากต้องการสร้างกล่องข้อความตามย่อหน้า ให้ตั้งค่า [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (หรือระดับย่อหน้าอื่น) เพื่อกำหนดเอฟเฟ็กต์ให้กับย่อหน้าเดียวโดยใช้ overload ของ [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) ที่รับ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) ดูที่ [Animated Text](/slides/th/nodejs-java/animated-text/) สำหรับตัวอย่างระดับย่อหน้า

## **Export and Compatibility Notes**

- การบันทึกเป็น PPT หรือ PPTX จะรักษาโมเดลการเคลื่อนไหวไว้, แต่การเล่นจริงถูกควบคุมโดยโปรแกรมอ่านไฟล์นำเสนอ
- PDF และภาพนิ่งจะไม่เล่นการเคลื่อนไหว ใช้ [HTML5 export](/slides/th/nodejs-java/export-to-html5/), GIF เคลื่อนไหว, หรือ [video conversion](/slides/th/nodejs-java/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนที่
- สำหรับ HTML5 ให้เปิดใช้งาน [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/#setAnimateShapes) และเมื่อจำเป็นให้เปิด [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/html5options/#setAnimateTransitions)
- การเรนเดอร์วิดีโอรองรับเอฟเฟ็กต์ entrance, emphasis, exit, และ motion‑path ที่พบบ่อยหลายอย่าง, แต่ไม่รองรับเอฟเฟ็กต์ PowerPoint ทุกอย่าง ตรวจสอบรายการ [supported animations and effects](/slides/th/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) ปัจจุบันและทดสอบการนำเสนอสำคัญกับเวอร์ชัน Aspose.Slides ที่คุณใช้
- เอฟเฟ็กต์ที่กำหนดเองขั้นสูงและเอฟเฟ็กต์ที่นำเข้าจากรูปแบบการนำเสนออื่น ๆ อาจถูกเก็บไว้ในไฟล์แต่แสดงผลแตกต่างกันใน PowerPoint, HTML5 หรือวิดีโอ ตรวจสอบผลลัพธ์ที่ส่งออกแทนการพึ่งพาชื่อเอฟเฟ็กต์เท่านั้น

## **FAQ**

**Why does an animation appear in PowerPoint but not in a PDF?**

PDF เป็นรูปแบบสถิต, จึงไม่มีการเล่นการเคลื่อนไหวและการเปลี่ยนสไลด์ ให้ส่งออกเป็น HTML5, GIF เคลื่อนไหว หรือวิดีโอเมื่อจำเป็นต้องรักษาการเคลื่อนที่

**Why does an effect play differently in a video?**

การส่งออกวิดีโอทำการเรนเดอร์การเคลื่อนไหวแทนการเก็บพฤติกรรมเดิมของ PowerPoint บางเอฟเฟ็กต์ขั้นสูงอาจไม่รองรับหรือถูกประมาณค่า ตรวจสอบตารางเอฟเฟ็กต์ที่รองรับและทดสอบการนำเสนอจริงก่อนใช้งานจริง

**Does moving a shape forward or backward change its animation order?**

ไม่ การจัดลำดับ z‑order ของรูปทรงควบคุมการซ้อนทับ, ส่วนลำดับของซีเควนซ์และตัวกระตุ้นควบคุมการ播放การเคลื่อนไหว ปรับไทม์ไลน์หากต้องการเปลี่ยนลำดับการเล่นอย่างอื่น