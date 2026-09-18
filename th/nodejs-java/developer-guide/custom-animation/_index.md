---
title: สร้างและแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองใน JavaScript
linktitle: แอนิเมชันแบบกำหนดเอง
type: docs
weight: 151
url: /th/nodejs-java/custom-animation/
keywords:
- แอนิเมชันกำหนดเอง
- พฤติกรรมแอนิเมชัน
- เส้นทางการเคลื่อนที่
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองและเส้นทางการเคลื่อนที่ที่สามารถแก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

พฤติกรรมแอนิเมชันแบบกำหนดเองช่วยให้คุณควบคุมการดำเนินการแต่ละอย่างภายในเอฟเฟ็กต์แอนิเมชันได้ เช่น การเปลี่ยนสี การหมุนรูปทรง หรือการตามเส้นทางการเคลื่อนที่ที่สามารถแก้ไขได้ คู่มือนี้จะแสดงวิธีสร้างและรวมพฤติกรรมต่าง ๆ การกำหนดค่าการจับเวลา การตรวจสอบและแก้ไขแอนิเมชันที่มีอยู่ และการตรวจสอบว่าคุณลักษณะของพฤติกรรมยังคงอยู่หลังจากบันทึกและเปิดงานนำเสนอใหม่

สำหรับเอฟเฟ็กต์ที่กำหนดไว้ล่วงหน้าและทริกเกอร์คลิก ดูที่ [แอนิเมชันรูปร่าง](/slides/th/nodejs-java/shape-animation/)

## **ทำความเข้าใจโมเดลแอนิเมชัน**

แอนิเมชันจะถูกจัดระเบียบเป็น **Timeline → Sequence → Effect → Behaviors**:

- เมธอด [getTimeline](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseslide/#getTimeline) จะคืนค่าไทม์ไลน์ของสไลด์ ซึ่งประกอบด้วยซีเควนซ์หลักและซีเควนซ์เชิงโต้ตอบ
- [Sequence](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/) จะมีเอฟเฟ็กต์ต่าง ๆ ที่อาจเป้าหมายไปยังรูปทรงที่แตกต่างกัน
- [Effect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/) ระบุรูปทรงเป้าหมาย พรีเซ็ต ชนิดย่อย และการจับเวลาเอฟเฟ็กต์
- คอลเลกชันที่ได้จาก [Effect.getBehaviors](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getBehaviors) จะบรรจุปฏิบัติการที่ทำให้เอฟเฟ็กต์ทำงาน: การเปลี่ยนสี การย้าย การหมุน การตั้งค่าคุณลักษณะ เป็นต้น

## **สร้างพฤติกรรมเดี่ยว**

เรียก [Sequence.addEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sequence/#addEffect) เพื่อสร้างเอฟเฟ็กต์และเข้าถึงคอลเลกชัน [getBehaviors](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getBehaviors) พรีเซ็ตสามารถเติมคอลเลกชันนี้ให้โดยอัตโนมัติ เก็บปฏิบัติการไว้เมื่อต้องขยายพรีเซ็ต หรือใช้ [clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorcollection/#clear) หากต้องการแทนที่โดยเจตนา

[BehaviorFactory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/) สร้างพฤติกรรมทั้งแปดประเภทที่แสดงด้านล่าง พฤติกรรมการเคลื่อนที่จะอธิบายไว้ใน [Build a Motion Path](#build-a-motion-path) ตัวอย่างโค้ดแต่ละส่วนรวมการนำเข้ามอดูลและสามารถรันเป็นสคริปต์ Node.js ด้วยแพคเกจ `aspose.slides.via.java` และ `java` ที่ติดตั้งไว้ ให้รันทดลองสร้างไฟล์ก่อนตัวอย่างที่อ่านผลลัพธ์ ตัวอย่างการแก้ไขต่อมาจะระบุว่าใช้ไฟล์ผลลัพธ์ใด

### **การหมุน**

ใช้ [createRotationEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) เพื่อสร้างการหมุน [getBy](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/rotationeffect/#getBy) กำหนดมุมสัมพัทธ์เป็นองศา; [getFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/rotationeffect/#getFrom) และ [getTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/rotationeffect/#getTo) กำหนดจุดเริ่มต้นและจุดสิ้นสุด

ตัวอย่างเริ่มด้วยเอฟเฟ็กต์ Spin แล้วแทนที่ปฏิบัติการพรีเซ็ตด้วยพฤติกรรมการหมุนหนึ่งตัว และกำหนดระยะเวลาเป็นสองวินาที มุมสัมพัทธ์ 90 องศาแสดงการหมุนไตรมาสหนึ่งจากการวางแนวเริ่มต้นของรูปทรง ดังนั้นจึงไม่ต้องกำหนดมุมเริ่มต้นอย่างชัดเจน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ไฟล์ `rotation.pptx` มีรูปทรงหนึ่งรูปและพฤติกรรมการหมุนหนึ่งตัว คอลเลกชัน การจับเวลา และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **การย่อ/ขยาย**

ใช้ [createScaleEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) พร้อมเปอร์เซ็นต์ X/Y: [getFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/scaleeffect/#getFrom) และ [getTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/scaleeffect/#getTo) ระบุขนาดเริ่มต้นและขนาดสุดท้าย ส่วน [getBy](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/scaleeffect/#getBy) ระบการเปลี่ยนแปลงสัมพัทธ์ ที่นี่ 100 หมายถึงขนาดเดิม

ตัวอย่างขยายทั้งสองมิติจาก 100 % เป็น 125 % ภายในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันจะรักษาสัดส่วนของรูปทรง; การใช้เปอร์เซ็นต์ที่ต่างกันจะแสดงการยืดแนวใดแนวหนึ่งมากกว่ากัน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **สี**

ใช้ [createColorEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) เพื่อเปลี่ยนสีเติมจากสีฟ้าเป็นสีส้ม [getFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/coloreffect/#getFrom) และ [getTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/coloreffect/#getTo) เป็นสี; [getBy](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/coloreffect/#getBy) คือการออฟเซ็ตสี [Behavior.getProperties](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behavior/#getProperties) ระบุแอตทริบิวต์ที่กำลังทำแอนิเมชัน

การเติมสีแบบทึบของรูปทรงถูกกำหนดให้เป็นสีฟ้า ตรงกับสีเริ่มต้นของแอนิเมชัน การเลือกแอตทริบิวต์สีเติมบอกพฤติกรรมว่าต้องเปลี่ยนส่วนใดของรูป; จุดสีเริ่มและสิ้นสุดเพียงอย่างเดียวไม่บ่งบอกแอตทริบิวต์เลย เอฟเฟ็กต์ที่บันทึกไว้ระบุการเปลี่ยนสีเป็นสีส้มในระยะสองวินาที

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ฟิลเตอร์**

ใช้ [createFilterEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) เพื่อเลือกวิธีการทำวายพ์ [getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filtereffect/#getSubtype) และ [getReveal](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filtereffect/#getReveal) ระบุฟิลเตอร์, ทิศทาง, และว่าจะเปิดเผยหรือซ่อนรูป

ตัวอย่างนี้ตั้งค่าการวายพ์สองวินาทีที่เปิดเผยรูปโดยใช้ชนิดย่อยทิศทางด้านขวา การตั้งค่าฟิลเตอร์เป็นของพฤติกรรมภายในเอฟเฟ็กต์จึงทำหลังจากลบปฏิบัติการเดิมของพรีเซ็ตออกแล้ว

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **คุณลักษณะ**

ใช้ [createPropertyEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) เพื่อแอนิเมชันความทึบแสง [getFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/propertyeffect/#getTo) และ [getBy](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/propertyeffect/#getBy) เป็นสตริงที่ตีความด้วย [getValueType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/propertyeffect/#getValueType) และ [getCalcMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/propertyeffect/#getCalcMode) ควรเลือกใช้จุดสิ้นสุดหรือออฟเซ็ตสัมพัทธ์แทนการตั้งค่าทั้งสามพร้อมกันโดยไม่มีเงื่อนไข

ในตัวอย่างนี้ แอตทริบิวต์ที่เลือกคือ opacity และสตริงตัวเลขระบุการเปลี่ยนจากความทึบ 25 % ไปเป็นความทึบเต็มที่ การอินเทอร์โพลีชันเชิงเส้นอธิบายการเปลี่ยนแปลงอย่างค่อยเป็นค่อยไประหว่างค่าทั้งสอง เมื่อปรับตัวอย่างนี้ไปใช้กับแอตทริบิวต์อื่น ให้เลือกประเภทค่าและค่าจุดสิ้นสุดที่เหมาะสมกับแอตทริบิวต์นั้น

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ตั้งค่า**

ใช้ [createSetEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) เพื่อกำหนดการมองเห็นผ่าน [getTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/seteffect/#getTo) พฤติกรรมประเภท set ไม่ทำการอินเทอร์โพลีเทียระหว่างจุดสิ้นสุด

ตัวอย่างเลือกแอตทริบิวต์ visibility แล้วกำหนดสตริง `visible` เมื่อพฤติกรรมทำงานรูปสี่เหลี่ยมมีการมองเห็นอยู่แล้วในงานนำเสนอขนาดเล็กนี้ ดังนั้นการกำหนดอาจไม่แสดงการเปลี่ยนแปลงที่ชัดเจน การดำเนินการเช่นนี้มีประโยชน์เมื่อเป็นส่วนหนึ่งของเอฟเฟ็กต์ที่ควบคุมการซ่อนหรือแสดงรูปในช่วงต่อไป

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **คำสั่ง**

ใช้ [createCommandEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) และกำหนด [getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commandeffect/#getCommandString) และ [getShapeTarget](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/commandeffect/#getShapeTarget) วางไฟล์บันทึกเสียง WAV ชื่อ `sample.wav` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์ด้วย [addAudioFrameEmbedded](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) และแนบคำสั่งเล่นไปยังเฟรมเสียง

เฟรมเสียงเป็นทั้งเป้าหมายของเอฟเฟ็กต์และของคำสั่ง การเชื่อมคำสั่งเล่นกับบันทึกที่ฝังอยู่; สตริงคำสั่งเดี่ยวไม่ระบุว่าอ็อบเจกต์สื่อใดจะถูกควบคุม เอฟเฟ็กต์ถูกตั้งให้เริ่มเมื่อคลิกระหว่างการนำเสนอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

การบันทึกเก็บคำสั่งใน `command.pptx`; ไม่ได้เล่นบันทึก การเล่นต้องใช้โปรแกรมสไลด์โชว์ที่รองรับคำสั่งและสื่อเป้าหมาย

## **จัดการคอลเลกชันพฤติกรรม**

[BehaviorCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorcollection/) รองรับ [add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorcollection/#remove) และ [removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorcollection/#removeAt) ตัวอย่างนี้เปิด `rotation.pptx` เพิ่มการย่อ/ขยาย ย้ายมันก่อนการหมุน แล้วลบการหมุน การลบและเพิ่มเข้ามาใหม่ของอ็อบเจกต์เดียวกันจะเปลี่ยนตำแหน่งที่เก็บโดยไม่มีการคัดลอก

ลำดับการแก้ไขเปลี่ยนคอลเลกชันจาก rotation–scale ไปเป็น scale–rotation แล้วเป็น scale เพียว ดัชนีอ้างอิงถึงคอลเลกชันปัจจุบัน ดังนั้นการลบใช้ดัชนีใหม่ของการหมุนหลังจากจัดลำดับใหม่ การนับครั้งสุดท้ายแสดงว่าอะไรจะถูกบันทึก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์คือ `ScaleEffect`: เหลือแค่การย่อ/ขยาย คอลเลกชันไม่ได้กำหนดให้พฤติกรรมทำงานต่อเนื่องโดยอัตโนมัติ ให้ล้างคอลเลกชันเฉพาะเมื่อแทนที่ปฏิบัติการทั้งหมด

## **กำหนดค่าการจับเวลาพฤติกรรม**

[Behavior.getTiming](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behavior/#getTiming) เปิดเผย [Timing](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/) แยกจาก [Effect.getTiming](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getTiming) การจับเวลาเอฟเฟ็กต์กำหนดเวลาของเอฟเฟ็กต์โดยรวม; การจับเวลาพฤติกรรมอธิบายการดำเนินการภายในเอฟเฟ็กต์

### **ตั้งค่า ระยะเวลา, การหน่วง, การทำซ้ำ, และการเร่งความเร็ว**

เปิด `rotation.pptx` และตั้งค่าระยะเวลา ([getDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getDuration)) และหน่วงเวลาทริกเกอร์ ([getTriggerDelayTime](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) เป็นวินาที จากนั้นกำหนดจำนวนครั้งทำซ้ำผ่าน [setRepeatCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#setRepeatCount) [getAccelerate](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getAccelerate) และ [getDecelerate](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getDecelerate) เป็นส่วนของระยะเวลา; รักษาผลรวมไม่เกิน 1

ไฟล์อินพุตคือไฟล์ที่สร้างในตัวอย่างการหมุน ซึ่งพฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนเฉพาะการจับเวลาของพฤติกรรมนั้น; มุม 90 ° ยังคงอยู่ การแยกมุมและการจับเวลาช่วยให้ปรับจังหวะได้โดยไม่ต้องสร้างแอนิเมชันใหม่

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

พฤติกรรมใช้ระยะเวลาสองวินาที หน่วงเวลา half‑second และทำซ้ำ 3 ครั้ง 20 % แรกและสุดของระยะเวลาถูกใช้สำหรับการเร่งและการหน่วง

นโยบายทำซ้ำอื่น ๆ รวมถึง [getRepeatDuration](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) และ [getRepeatUntilNextClick](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); เลือกนโยบายหนึ่งแทนการเปิดทั้งหมดพร้อมกัน [getAutoReverse](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/timing/#getAutoReverse) จะเล่นแอนิเมชันย้อนกลับหลังจากผ่านไปข้างหน้า การเร่งและการหน่วงใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าต่างหากหรือคำสั่ง

## **สร้างเส้นทางการเคลื่อนที่**

ใช้ [createMotionEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) เพื่อสร้างการเคลื่อนที่ [getFrom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioneffect/#getTo) และ [getBy](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioneffect/#getBy) ระบุพิกัดหรือออฟเซ็ตเป็นเปอร์เซ็นต์ สำหรับเส้นทางแก้ไขได้ ให้สร้าง [MotionPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motionpath/) แล้วกำหนดด้วย [MotionEffect.setPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioneffect/#setPath) [MotionPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motionpath/) จะเก็บคำสั่งเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioncommandpathtype/) กำหนดประเภทการดำเนินการ:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MoveTo | หนึ่ง | กำหนดตำแหน่งเริ่มต้น |
| LineTo | หนึ่ง | เคลื่อนที่ตามส่วนตรงไปยังจุดสิ้นสุด |
| CurveTo | สาม | ตามเส้นโค้งลูกบาศก์ที่กำหนดด้วยสองจุดควบคุมและจุดสิ้นสุด |
| CloseLoop | ไม่มี | กลับไปยังตำแหน่งเริ่มต้น |
| End | ไม่มี | สิ้นสุดเส้นทาง |

[MotionPathPointsType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motionpathpointstype/) บ่งบอกลักษณะการแก้ไขจุด เช่น จุดหักหรือจุดเรียบ ไม่ได้แทนที่ประเภทคำสั่ง ใช้ประเภทจุดโค้งสำหรับตัวอย่างโค้งด้านล่าง และประเภทจุดหักสำหรับส่วนตรง

พิกัดเส้นทางทำให้เป็นอัตราส่วนต่อขนาดสไลด์: การเคลื่อนที่ X 0.25 แสดงถึงหนึ่งในสี่ของความกว้างสไลด์ ไม่ใช่ 0.25 จุด Y บวกลงด้านล่าง คำสั่ง Absolute ระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่ง Relative ระบุออฟเซ็ตจากตำแหน่งปัจจุบัน สิ่งนี้แยกจาก [getOrigin](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioneffect/#getOrigin) ที่เลือกกรอบอ้างอิงของเส้นทางและ [getPathEditMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioneffect/#getPathEditMode) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อย้ายรูป

### **สร้างเส้นทางตรง**

สร้างพฤติกรรมการเคลื่อนที่โดยมีจุดเริ่มต้น ส่วนเส้นตรงหนึ่งส่วนและคำสั่ง End [MotionPath.add](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motionpath/#add) รับประเภทคำสั่ง จุด, ประเภทจุด และแฟล็กพิกัดสัมพัทธ์

คำสั่งเริ่มต้นตั้ง (0, 0) และเส้นตรงสิ้นสุดที่ (0.25, 0) ให้เส้นทางเคลื่อนที่แนวนอนหนึ่งในสี่ของความกว้างสไลด์ คำสั่ง End ไม่มีจุดพิกัด เมื่อกำหนดเส้นทางแล้ว การเพิ่มพฤติกรรมการเคลื่อนที่ลงในเอฟเฟ็กต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยม

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ไฟล์ `motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งตัวพร้อมสามคำสั่งเส้นทาง ตัวอย่างการแก้ไขไฟล์ต่อไปนี้ใช้โครงสร้างที่ทราบนี้

### **เปรียบเทียบพิกัด Absolute และ Relative**

สองอ็อบเจกต์เส้นทางนี้อธิบายเส้นทางเดียวกัน คำสั่ง Absolute สิ้นสุดที่ (0.3, 0.1); คำสั่ง Relative เพิ่ม (0.1, 0.1) ไปยังตำแหน่งปัจจุบัน (0.2, 0)

ทั้งสองเส้นทางเริ่มจากตำแหน่งเดียวกัน สำหรับเส้น Relative ให้เพิ่มออฟเซ็ต X และ Y ไปยังตำแหน่งปัจจุบันเพื่อหา endpoint; สำหรับเส้น Absolute ให้อ่าน endpoint โดยตรง การสลับแฟล็กโดยไม่แปลงพิกัดจะทำให้เส้นทางต่างกัน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

กำหนดเส้นทางใดเส้นทางหนึ่งให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในงานนำเสนอ พารามิเตอร์ Boolean สุดท้ายเลือกพิกัดสัมพัทธ์สำหรับคำสั่งนั้น

### **แทนที่เส้นตรงด้วยโค้ง**

เปิด `motion.pptx` แล้วแทนที่คำสั่งเส้นตรงด้วยโค้งลูกบาศก์ ให้ใส่จุดควบคุมสองจุดก่อนตามด้วยจุดสิ้นสุด

ตำแหน่งเริ่มต้นมาจากคำสั่งก่อนหน้า จุดแรกสองจุดกำหนดรูปโค้ง ส่วนจุดที่สามเป็นตำแหน่งปลาย; ไม่ได้เป็นจุดปลายต่อเนื่องสามจุด การอัปเดตประเภทคำสั่ง ประเภทการแก้ไขจุด และอาเรย์จุดพร้อมกันทำให้ส่วนเส้นสอดคล้องกับเรขาคณิตใหม่

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ไฟล์ `curve.pptx` ยังมีสามคำสั่ง; คำสั่งกลางตอนนี้กำหนดเป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [MotionCmdPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioncmdpath/) เปิดเผย [getPoints](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) และ [isRelative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motioncmdpath/#isRelative) ตัวอย่างต่อไปนี้ใช้เส้นทางสามคำสั่งที่ทราบใน `motion.pptx` สำหรับอินพุตใด ๆ ให้ค้นหาเอฟเฟ็กต์ที่ตั้งใจและตรวจสอบประเภทคำสั่งและจำนวนจุดก่อนแก้ไขตามดัชนี

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง End และ CloseLoop ไม่ต้องการจุด ดังนั้นต้องรองรับอาเรย์จุดเป็น null

ผลลัพธ์จะแสดงคู่ของประเภทคำสั่งเชิงตัวเลขกับแฟล็กพิกัดสัมพัทธ์ก่อนรายการจุด ทำให้คุณแยก endpoint จากออฟเซ็ตก่อนแก้ไขเส้นทาง โค้งจะแสดงสามจุด ส่วนเส้นตรงในไฟล์นี้แสดงเพียงหนึ่งจุด

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

รายการประกอบด้วยจุดเริ่มต้น เส้นตรง Absolute สิ้นสุดที่ (0.25, 0) และคำสั่ง End

### **เปลี่ยน Endpoint**

เปิด `motion.pptx` แล้วแทนที่อาเรย์จุดของเส้นเพื่อย้าย endpoint

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้น ดัชนี 1 คือเส้น การแทนที่จุดเดียวของเส้นจะเปลี่ยนตำแหน่งปลายโดยไม่เปลี่ยนประเภทคำสั่ง เวลา หรือตำแหน่งในคอลเลกชัน เนื่องจากคำสั่งใช้พิกัด Absolute คู่ใหม่จึงระบุตำแหน่งแทนการเพิ่มออฟเซ็ต

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นใน `motion-endpoint.pptx` สิ้นสุดที่ (0.4, 0.1); ไฟล์เดิมไม่เปลี่ยน

### **แทนที่ส่วนประกอบ**

ใช้ [insert](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motionpath/#insert) และ [removeAt](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/motionpath/#removeAt) เพื่อแทนที่เส้นใน `motion.pptx` การแทรกจะย้ายเส้นเก่าไปที่ดัชนี 2

นี่เป็นการแทนที่อ็อบเจกต์คำสั่งแทนการแก้ไขพิกัดที่มีอยู่ หลังการแทรก คอลเลกชันชั่วคราวจะมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเก่า, และคำสั่ง End การลบดัชนี 2 จะลบเส้นเก่าและเหลือเส้นใหม่เป็นเส้นทางสุดท้าย

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เส้นที่บันทึกยังคงมีสามคำสั่ง โดยเส้นใหม่สิ้นสุดที่ (0.2, 0.1) และคำสั่ง End อยู่สุดท้าย

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีพฤติกรรม ให้เลือกตามประเภท ตัวอย่างนี้เปิด `rotation.pptx` หา [RotationEffect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/rotationeffect/) เปลี่ยนมุม และตรวจสอบค่าที่บันทึกหลังจากเปิดใหม่

การตรวจสอบประเภททำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน การโหลดครั้งที่สองอ่านไฟล์ที่บันทึกไว้ลงในอ็อบเจกต์การนำเสนอแยกต่างหาก เพื่อให้การเปรียบเทียบตรวจสอบข้อมูลที่คงอยู่ แทนค่าที่ยังคงอยู่ในหน่วยความจำ ตัวอย่างนี้ยังสมมติว่าเอฟเฟ็กต์ที่รู้จักเป็นอันแรกในซีเควนซ์หลัก; การเลือกพฤติกรรมตามประเภทไม่ได้บ่งชี้เอฟเฟ็กต์ที่ถูกต้องในงานนำเสนอใด ๆ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์คือ `Rotation preserved: true` ใช้แบบตรวจสอบประเภทเดียวกันกับพฤติกรรมอื่น ๆ เพื่อเช็กการคงสภาพอย่างครบถ้วน ให้เปรียบเทียบรูปเป้าหมาย เอฟเฟ็กต์ ประเภทและลำดับพฤติกรรม เวลาและคำสั่งเส้นทาง ใช้ความคลาดเคลื่อนเชิงตัวเลขสำหรับค่าจุดทศนิยม สำหรับงานนำเสนอที่ไม่ได้รู้โครงสร้างแอนิเมชัน ให้ดูที่ [Read Shape Animations](/slides/th/nodejs-java/shape-animation/#read-shape-animations) เพื่อท่องซีเควนซ์หลักและเชิงโต้ตอบ

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [BehaviorCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behaviorcollection/) คือการจัดเก็บลำดับของปฏิบัติการเอฟเฟ็กต์ ไม่ใช่เพลย์ลิสต์ที่พฤติกรรมแต่ละตัวจะรอให้ก่อนหน้าเสร็จ การจับเวลาและเอฟเฟ็กต์ที่ห่อหุ้มกำหนดการจัดตาราง เวลา พฤติกรรมอาจทับซ้อนกัน และการดำเนินการบนแอตทริบิวต์เดียวกันอาจโต้ตอบผ่าน [getAdditive](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behavior/#getAdditive) และ [getAccumulate](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/behavior/#getAccumulate) อย่าใช้การจัดลำดับคอลเลกชันเพียงอย่างเดียวเพื่อกำหนด “ย้ายแล้วหมุน” ให้ใช้การกำหนดเวลาอย่างชัดเจนหรือเอฟเฟ็กต์แยกตามที่อธิบายใน [แอนิเมชันรูปร่าง](/slides/th/nodejs-java/shape-animation/)

[Effect.getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getType) และ [getSubtype](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/effect/#getSubtype) บรรยายพรีเซ็ตของเอฟเฟ็กต์ ไม่ใช่คำอธิบายที่ครบถ้วนของต้นไม้พฤติกรรมที่แก้ไขแล้ว เลือกพรีเซ็ตและชนิดย่อยก่อนปรับพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และลบปฏิบัติการที่กำหนดเองของคุณ ตัวอย่างเช่น การเปลี่ยนเอฟเฟ็กต์ Spin ที่ปรับแต่งเป็น Fade อาจแทนที่พฤติกรรมการหมุนด้วยพฤติกรรม set และ filter ตรวจสอบคอลเลกชันอีกครั้งหลังจากเปลี่ยนพรีเซ็ตหรือชนิดย่อย การล้างพฤติกรรมพรีเซ็ตอาจลบการดำเนินการที่พรีเซ็ตต้องการเช่นการมองเห็นหรือการเริ่มต้น ตัวอย่างใช้รูปที่มองเห็นและแทนที่พฤติกรรม ไม่ได้สร้างต้นแบบพรีเซ็ตใหม่ทั้งหมด

## **ความเข้ากันได้ของฟอร์แมต**

ต้นไม้พฤติกรรมที่คงอยู่ไม่รับประกันการเล่นที่เหมือนกันในทุกโปรแกรมหรือเรนเดอร์เอาต์พุต ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| ฟอร์แมตหรือเอาต์พุต | สิ่งที่ต้องตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นฟอร์แมตหลักสำหรับตัวอย่างเหล่านี้ เปิดใหม่เพื่อยืนยันต้นไม้พฤติกรรมที่แก้ไขได้ แล้วตรวจสอบการเล่นในรุ่น PowerPoint ที่ต้องการ |
| PPT | การแทนที่แบบไบนารีเก่าอาจแตกต่างจาก PPTX ทดสอบวงจรบันทึก‑เปิด‑ใหม่และการเล่น; อย่าสรุปว่าทุกการผสมผสานกำหนดเองทำงานจากผลลัพธ์ PPTX เพียงอย่างเดียว |
| PDF, PNG, JPEG, และรูปภาพสไลด์คงที่อื่น ๆ | มีเพียงการแสดงสไลด์คงที่ ไม่ได้เป็นไทม์ไลน์พฤติกรรมที่เล่นได้หรือเฟรมแอนิเมชันสุดท้ายที่รับประกัน |
| [HTML5](/slides/th/nodejs-java/export-to-html5/) | สามารถเล่นแอนิเมชันที่รองรับได้เมื่อเปิดใช้งานการแอนิเมชันรูปร่างในตัวเลือกการส่งออก ทดสอบการผสมผสานกำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/nodejs-java/convert-powerpoint-to-animated-gif/) | เก็บเฟรมที่เรนเดอร์ ไม่ได้เป็นพฤติกรรมแก้ไขได้หรือการโต้ตอบคลิก‑ทริกเกอร์ ตรวจสอบการเคลื่อนที่ที่เรนเดอร์จริง |
| [Video](/slides/th/nodejs-java/convert-powerpoint-to-video/) | เรนเดอร์เฟรมแอนิเมชันและเข้ารหัสเป็นวิดีโอ การสนับสนุนจำกัดอยู่ที่ [แอนิเมชันและเอฟเฟ็กต์ที่รองรับ](/slides/th/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects); คำสั่งและเหตุการณ์เชิงโต้ตอบจะไม่กลายเป็นไทม์ไลน์ที่แก้ไขได้ |

## **คำถามที่พบบ่อย**

**ทำไมเอฟเฟ็กต์ของฉันถึงมีพฤติกรรมก่อนที่ฉันจะเพิ่มอะไรเลย?**

การสร้างเอฟเฟ็กต์พรีเซ็ตอาจสร้างปฏิบัติการพื้นฐานไว้ ตรวจสอบก่อนตัดสินใจขยายพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปไว้ตอนต้นทำให้มันเล่นก่อนหรือไม่?**

ไม่จำเป็น คอลเลกชันไม่ได้เป็นการทดแทนการกำหนดเวลา ตรวจสอบการหน่วง เวลา และการโต้ตอบระหว่างปฏิบัติการบนแอตทริบิวต์เดียวกัน

**ทำไมคำสั่ง End ถึงไม่มีจุด?**

มันเป็นเครื่องหมายสิ้นสุดเส้นทาง ไม่ต้องการพิกัด ตรวจสอบอาเรย์จุดเป็น null เมื่ออ่านเส้นทางจากไฟล์

**การทำรอบครบหนึ่งครั้งถือพอเพื่อยืนยันการเล่นหรือไม่?**

ไม่ การเปิดใหม่ยืนยันการคงรักษาคุณลักษณะที่ตรวจสอบเท่านั้น ต้องทดสอบโปรแกรมสไลด์โชว์หรือการส่งออกแอนิเมชันแยกต่างหากเพื่อยืนยันพฤติกรรมภาพจริง