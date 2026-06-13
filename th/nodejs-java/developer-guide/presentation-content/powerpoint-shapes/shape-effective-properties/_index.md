---
title: รับคุณสมบัติรูปร่างที่มีผลจากงานพรีเซนเทชั่นใน JavaScript
linktitle: คุณสมบัติที่มีผล
type: docs
weight: 50
url: /th/nodejs-java/shape-effective-properties/
keywords:
- คุณสมบัติรูปร่าง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปร่างบีเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงฟอนต์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบว่า Aspose.Slides สำหรับ Node.js ผ่าน Java คำนวณและใช้คุณสมบัติรูปร่างที่มีผลเพื่อการเรนเดอร์ PowerPoint อย่างแม่นยำ"
---
## **ภาพรวม**

หัวข้อนี้อธิบายความแตกต่างระหว่างคุณสมบัติ **local** และ **effective** ค่าท้องถิ่นคือค่าที่ตั้งโดยตรงที่ระดับการจัดรูปแบบเฉพาะ เช่น:

1. คุณสมบัติส่วน (portion) บนสไลด์.  
1. สไตล์ข้อความของรูปร่างต้นแบบบนเลย์เอาต์หรือสไลด์มาสเตอร์, เมื่อรูปแบบกรอบข้อความของส่วนมีสไตล์หนึ่ง.  
1. การตั้งค่าข้อความระดับทั่วโลกในงานพรีเซนเทชั่น.  

ค่าท้องถิ่นสามารถกำหนดหรือไม่กำหนดได้ที่ทุกระดับ เมื่อ Aspose.Slides ต้องการการจัดรูปแบบขั้นสุดท้าย “as rendered” มันจะแก้ไขห่วงโซ่การสืบทอดและส่งคืนค่ **effective** คุณสามารถรับค่าเหล่านี้ได้โดยเรียกเมธอด `getEffective` บนวัตถุรูปแบบท้องถิ่น

ตัวอย่างต่อไปนี้แสดงวิธีการรับค่าที่ **effective** โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่มีกรอบข้อความและมีอย่างน้อยหนึ่งส่วน.

```javascript

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    let localPortionFormat = paragraph.getPortions().get_Item(0).getPortionFormat();
    let effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
ข้อมูลการจัดรูปแบบที่ **effective** แสดงถึงการจัดรูปแบบที่คำนวณแล้วในปัจจุบันหลังจากที่มีการใช้การสืบทอด ในการทำงานปัจจุบันบางวัตถุข้อมูล **effective** อาจถูกเก็บไว้ในแคชภายใน การเรียก `getEffective` อีกครั้งหลังจากเปลี่ยนการจัดรูปแบบของพาเรนต์หรือการสืบทอดสามารถรีเฟรชข้อมูลที่แคชไว้ได้ และวัตถุที่ได้รับมาก่อนหน้านี้อาจไม่แสดงสถานะเดิมอีกต่อไป หากคุณต้องการเก็บค่าที่ **effective** เพื่อใช้ในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการ เช่น ความสูงของฟอนต์, สีเติม, สไตล์ฟอนต์ หรือการจัดแนว ไปยังออบเจกต์ข้อมูลของคุณเอง.
{{% /alert %}}

## **รับคุณสมบัติ Effective ของกล้อง**

Aspose.Slides ให้คุณรับคุณสมบัติที่ **effective** ของกล้อง วัตถุข้อมูลกล้องที่ **effective** จะมีคุณสมบัติของกล้องที่ไม่สามารถเปลี่ยนแปลงได้และจะถูกเปิดเผยผ่านค่าที่ **effective** ที่ส่งคืนสำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/).

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติที่ **effective** สำหรับกล้อง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let camera = threeDEffectiveData.getCamera();
    let cameraType = camera.getCameraType();
    let fieldOfViewAngle = camera.getFieldOfViewAngle();
    let zoom = camera.getZoom();

    console.log("= Effective camera properties =");
    console.log("Type: " + cameraType);
    console.log("Field of view: " + fieldOfViewAngle);
    console.log("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Light Rig**

Aspose.Slides ให้คุณรับคุณสมบัติที่ **effective** ของ Light Rig วัตถุข้อมูล Light Rig ที่ **effective** จะมีคุณสมบัติของ Light Rig ที่ไม่สามารถเปลี่ยนแปลงได้และจะถูกเปิดเผยผ่านค่าที่ **effective** ที่ส่งคืนสำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/).

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติที่ **effective** สำหรับ Light Rig โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let lightRig = threeDEffectiveData.getLightRig();
    let lightType = lightRig.getLightType();
    let direction = lightRig.getDirection();

    console.log("= Effective light rig properties =");
    console.log("Type: " + lightType);
    console.log("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Bevel Shape**

Aspose.Slides ให้คุณรับคุณสมบัติที่ **effective** ของ bevel รูปร่าง วัตถุข้อมูล bevel ที่ **effective** จะมีคุณสมบัติการยกหน้า (face‑relief) ที่ไม่สามารถเปลี่ยนแปลงได้สำหรับรูปร่างและจะถูกเปิดเผยผ่านค่าที่ **effective** ที่ส่งคืนสำหรับ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/).

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติที่ **effective** สำหรับ bevel บนสุดของรูปร่าง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกมีการจัดรูปแบบ 3D.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let threeDEffectiveData = shape.getThreeDFormat().getEffective();
    let bevelTop = threeDEffectiveData.getBevelTop();
    let bevelType = bevelTop.getBevelType();
    let bevelWidth = bevelTop.getWidth();
    let bevelHeight = bevelTop.getHeight();

    console.log("= Effective shape's top face relief properties =");
    console.log("Type: " + bevelType);
    console.log("Width: " + bevelWidth);
    console.log("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Text Frame**

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติที่ **effective** ของกรอบข้อความ วัตถุข้อมูลที่ส่งคืนจะประกอบด้วยคุณสมบัติการจัดรูปแบบของ Text Frame

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติการจัดรูปแบบของ Text Frame ที่ **effective** โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่มีกรอบข้อความ.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    let textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    let effectiveTextFrameFormat = textFrameFormat.getEffective();
    let anchoringType = effectiveTextFrameFormat.getAnchoringType();
    let autofitType = effectiveTextFrameFormat.getAutofitType();
    let textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    let marginLeft = effectiveTextFrameFormat.getMarginLeft();
    let marginTop = effectiveTextFrameFormat.getMarginTop();
    let marginRight = effectiveTextFrameFormat.getMarginRight();
    let marginBottom = effectiveTextFrameFormat.getMarginBottom();

    console.log("Anchoring type: " + anchoringType);
    console.log("Autofit type: " + autofitType);
    console.log("Text vertical type: " + textVerticalType);
    console.log("Margins");
    console.log("   Left: " + marginLeft);
    console.log("   Top: " + marginTop);
    console.log("   Right: " + marginRight);
    console.log("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ Effective ของ Text Style**

โดยใช้ Aspose.Slides คุณสามารถรับคุณสมบัติที่ **effective** ของสไตล์ข้อความ วัตถุข้อมูลที่ส่งคืนจะประกอบด้วยคุณสมบัติของ Text Style

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับคุณสมบัติของ Text Style ที่ **effective** โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่มีกรอบข้อความ.

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);
    let effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    let levelCount = 9;

    for (let levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        let effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        let depth = effectiveStyleLevel.getDepth();
        let indent = effectiveStyleLevel.getIndent();
        let alignment = effectiveStyleLevel.getAlignment();
        let fontAlignment = effectiveStyleLevel.getFontAlignment();

        console.log("= Effective paragraph formatting for style level #" + levelIndex + " =");

        console.log("Depth: " + depth);
        console.log("Indent: " + indent);
        console.log("Alignment: " + alignment);
        console.log("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **รับค่าความสูงฟอนต์ Effective**

โดยใช้ Aspose.Slides คุณสามารถรับความสูงฟอนต์ที่ **effective** ตัวอย่างโค้ดต่อไปนี้แสดงการเปลี่ยนแปลงความสูงฟอนต์ที่ **effective** ของส่วนหลังจากที่ตั้งค่าความสูงฟอนต์ท้องถิ่นในระดับโครงสร้างพรีเซนเทชั่นต่าง ๆ

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shapeType = aspose.slides.ShapeType.Rectangle;
    let autoShape = slide.getShapes().addAutoShape(shapeType, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    let firstPortion = new aspose.slides.Portion("Sample text with first portion");
    let secondPortion = new aspose.slides.Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    let firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    let secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    let firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    let secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height just after creation:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting the presentation default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting paragraph default font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #0 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    console.log("Effective font height after setting portion #1 font height:");
    console.log("Portion #0: " + firstPortionFontHeight);
    console.log("Portion #1: " + secondPortionFontHeight);

    let saveFormat = aspose.slides.SaveFormat.Pptx;
    presentation.save("SetLocalFontHeightValues.pptx", saveFormat);
} finally {
    presentation.dispose();
}
```

## **รับรูปแบบการเติม Effective สำหรับตาราง**

โดยใช้ Aspose.Slides คุณสามารถรับการจัดรูปแบบการเติมที่ **effective** สำหรับส่วนต่าง ๆ ของตาราง วัตถุข้อมูลที่ส่งคืนจะประกอบด้วยคุณสมบัติการเติม การจัดรูปแบบของเซลล์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบของแถว การจัดรูปแบบของแถวมีลำดับความสำคัญสูงกว่าการจัดรูปแบบของคอลัมน์ และการจัดรูปแบบของคอลัมน์มีลำดับความสำคัญสูงกว่าการจัดรูปแบบของตารางทั้งหมด

ผลลัพธ์คือคุณสมบัติการเติมของเซลล์ที่ **effective** จะถูกใช้ในการวาดเซลล์ตาราง ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการรับการเติมที่ **effective** สำหรับส่วนต่าง ๆ ของตาราง โดยสมมติว่ารูปร่างแรกบนสไลด์แรกเป็น [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/).

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let table = slide.getShapes().get_Item(0);

    let tableFormatEffective = table.getTableFormat().getEffective();
    let rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    let columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    let cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    let tableFillFormatEffective = tableFormatEffective.getFillFormat();
    let rowFillFormatEffective = rowFormatEffective.getFillFormat();
    let columnFillFormatEffective = columnFormatEffective.getFillFormat();
    let cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **FAQ**

**`getEffective` คืนสแนปช็อตหรือไม่?**

ไม่เสมอไป ข้อมูล **effective** แสดงถึงการจัดรูปแบบที่คำนวณแล้วหลังจากการสืบทอด แต่บางวัตถุข้อมูล **effective** อาจถูกแคชภายใน การเรียก `getEffective` อีกครั้งอาจทำให้คำนวณใหม่และรีเฟรชแคช ดังนั้นวัตถุที่ได้รับก่อนหน้านี้ไม่ควรถือเป็นสแนปช็อตคงที่

**ควรอ่านคุณสมบัติที่ **effective** อีกครั้งเมื่อใด?**

ให้เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนการจัดรูปแบบท้องถิ่น, สไตล์ของพาเรนต์, การจัดรูปแบบของเลย์เอาต์, การจัดรูปแบบของมาสเตอร์ หรือค่าดีฟอลต์ระดับพรีเซนเทชั่น การเรียกครั้งถัดไปจะประเมินลำดับการจัดรูปแบบใหม่และคืนผลลัพธ์ **effective** ปัจจุบัน

**การเปลี่ยนหรือเอาเลย์เอาต์/มาสเตอร์ออกจะมีผลต่อคุณสมบัติที่ **effective** ที่เคยดึงแล้วหรือไม่?**

มีผล แต่จะปรากฏในการเรียก `getEffective` ครั้งต่อไป หากแหล่งข้อมูลการจัดรูปแบบของพาเรนต์ถูกเปลี่ยนหรือเอาออก ข้อมูล **effective** ที่เคยได้อาจล้าสมัย เมื่อเรียก `getEffective` ใหม่ Aspose.Slides จะประเมินต้นไม้การจัดรูปแบบใหม่และค่าฟอนต์, สี, ขนาด หรือค่าอื่น ๆ อาจเปลี่ยนแปลง

**สามารถแก้ไขค่าได้ผ่านวัตถุข้อมูล **effective** หรือไม่?**

ไม่ได้ วัตถุข้อมูล **effective** เปิดเผยค่าเฉพาะที่คำนวณแล้ว ให้ทำการเปลี่ยนแปลงในวัตถุการจัดรูปแบบท้องถิ่น แล้วดึงค่าที่ **effective** อีกครั้ง

**ถ้าคุณสมบัติไม่ได้ตั้งค่าที่ระดับรูปร่าง, เลย์เอาต์/มาสเตอร์ หรือการตั้งค่าทั่วโลก จะเกิดอะไรขึ้น?**

ค่าที่ **effective** จะถูกกำหนดโดยกลไกค่าเริ่มต้น ซึ่งรวมถึงค่าเริ่มต้นของ PowerPoint และ Aspose.Slides ค่าที่ได้จะเป็นส่วนหนึ่งของข้อมูล **effective** ปัจจุบัน

**จากค่าฟอนต์ที่ **effective** ฉันจะทราบได้หรือไม่ว่ามาจากระดับใด?**

ไม่ได้โดยตรง ข้อมูล **effective** ให้ค่าป Finale เพื่อหาที่มาคุณต้องตรวจสอบค่าท้องถิ่นที่ portion, paragraph, text frame, แล้วตรวจสอบสไตล์ข้อความที่เลย์เอาต์, มาสเตอร์, และระดับพรีเซนเทชั่น เพื่อดูว่าการกำหนดแรกที่พบอยู่ที่ระดับใด

**ทำไมค่าที่ **effective** บางครั้งดูเหมือนกับค่าท้องถิ่น?**

เพราะค่าท้องถิ่นนั้นกลายเป็นค่าต่องสุดท้าย (ไม่มีการสืบทอดจากระดับที่สูงกว่า) ในกรณีนั้นค่าที่ **effective** จะแมทช์ค่าท้องถิ่น

**ควรใช้คุณสมบัติที่ **effective** เมื่อไหร่ และควรใช้ค่าท้องถิ่นเมื่อไหร่?**

ใช้ข้อมูล **effective** เมื่อคุณต้องการผลลัพธ์ “as rendered” หลังจากการสืบทอดทั้งหมด เช่น การจับคู่สี, ระยะเยื้อง, หรือขนาด หากต้องการเก็บค่าดังกล่าวไว้แม้จะมีการเปลี่ยนแปลงการจัดรูปแบบในภายหลัง ให้คัดลอกคุณสมบัติที่ต้องการไปยังออบเจกต์ของคุณเอง หากต้องการเปลี่ยนการจัดรูปแบบที่ระดับใดระดับหนึ่ง ให้แก้ไขค่าท้องถิ่นและจากนั้น (หากต้องการ) อ่านข้อมูล **effective** อีกครั้งเพื่อยืนยันผลลัพธ์.