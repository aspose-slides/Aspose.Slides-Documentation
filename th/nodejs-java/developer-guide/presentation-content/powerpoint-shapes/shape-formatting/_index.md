---
title: จัดรูปแบบรูปร่าง PowerPoint ด้วย JavaScript
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/nodejs-java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- เอฟเฟกต์สเก็ตช์
- เส้นรูปร่างสเก็ตช์
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมไล่สี
- การเติมลวดลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างขาว-ดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์ Bevel 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดรูปแบบรูปร่าง PowerPoint ด้วย JavaScript โดยใช้ Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ."
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับขอบของมัน นอกจากนี้ คุณยังสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมวิธีการเติมส่วนภายในของรูปร่าง

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java ให้คลาสและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกันกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ด้วย Aspose.Slides คุณสามารถระบุสไตล์เส้นแบบกำหนดเองสำหรับรูปร่างได้ ขั้นตอนต่อไปนี้สรุปกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linestyle/) ของรูปร่าง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีเส้นสำหรับรูปร่าง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` แบบสี่เหลี่ยม:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // ลบการเติมสีจากรูปร่างสี่เหลี่ยม.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The formatted lines in the presentation](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) เพื่อเลือกค่าจาก enumeration [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/)

โค้ด JavaScript ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดอย่างชัดเจน, และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // เข้าถึงรูปแบบเส้นของรูปร่างและรูปแบบสเก็ตช์ของมัน.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // ใช้เอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปร่าง.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // ลบเอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

ค่าที่คืนโดย [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์, หรือเลย์เอาต์สไลด์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/), เรียก `getSketchFormat` บนวัตถุที่คืนมา, จากนั้นเรียกเมธอด `getSketchType` ของมัน ค่าที่มีประสิทธิภาพจะแสดงการจัดรูปแบบที่ใช้งานจริงหลังจากการสืบทอดถูกแก้ไข:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **จัดรูปแบบสไตล์การเชื่อมต่อ**

นี่คือสามตัวเลือกของประเภทการเชื่อมต่อ:

* กลม
* มิตเตอร์
* บีเวล

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) จะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณวาดรูปร่างที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีที่สี่เหลี่ยมสามรูป (ตามที่แสดงในรูปด้านบน) ถูกสร้างโดยใช้การตั้งค่าประเภทการเชื่อมต่อ Miter, Bevel, และ Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสามรูปแบบ Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละรูปร่างสี่เหลี่ยม.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // ตั้งค่าความกว้างของเส้น.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // ตั้งค่าสไตล์การเชื่อมต่อ.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // เพิ่มข้อความให้แต่ละสี่เหลี่ยม.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมแบบไล่สี**

ใน PowerPoint การเติมแบบไล่สีเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การผสมสีต่อเนื่องกับรูปร่าง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่านั้นโดยที่สีหนึ่งค่อยๆ กลางเข้าสู่สีอีกสีหนึ่ง

ต่อไปนี้คือวิธีใช้ Aspose.Slides เพื่อเติมแบบไล่สีให้กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient`
1. เพิ่มสีสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดเผยโดยคลาส [GradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/)
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่สีกับรูปวงรี.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // ตั้งค่าทิศทางของไล่สี.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // เพิ่มสองจุดไล่สี.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The ellipse with gradient fill](gradient-fill.png)

หากไล่สีดูแตกต่างในภาพที่ส่งออกเมื่อเทียบกับใน PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). คุณสามารถเลือกสไตล์การเรนเดอร์ได้โดยไม่ต้องเปลี่ยนการเติมไล่สีที่เก็บไว้ในงานนำเสนอ

## **การเติมลวดลาย**

ใน PowerPoint การเติมลวดลายเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใช้การออกแบบสองสี—เช่น จุด, แนวนอน, ลายเส้นตัดกัน หรือ เช็กบอร์ด—กับรูปร่าง คุณสามารถเลือกสีที่กำหนดเองสำหรับพื้นหน้าและพื้นหลังของลวดลายได้

Aspose.Slides มีลักษณะลวดลายที่กำหนดล่วงหน้ากว่า 45 แบบที่คุณสามารถนำไปใช้กับรูปร่างเพื่อเพิ่มความน่าสนใจของงานนำเสนอของคุณ แม้หลังจากเลือกลวดลายที่กำหนดล่วงหน้าแล้ว คุณยังสามารถระบุสีที่ต้องการให้ใช้ได้อย่างแม่นยำ

ต่อไปนี้เป็นวิธีใช้ Aspose.Slides เพื่อเติมลวดลายให้กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern`
1. เลือกสไตล์ลวดลายจากตัวเลือกที่กำหนดล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor--) ของลวดลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor--) ของลวดลาย
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // ตั้งค่าสไตล์ลวดลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลวดลาย.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The rectangle with pattern fill](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ให้คุณใส่ภาพภายในรูปร่าง—โดยใช้ภาพเป็นพื้นหลังของรูปร่าง

ต่อไปนี้เป็นวิธีใช้ Aspose.Slides เพื่อเติมรูปภาพให้กับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Picture`
1. ตั้งค่าโหมดการเติมภาพเป็น `Tile` (หรือโหมดที่ต้องการอื่น)
1. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) จากภาพที่คุณต้องการใช้
1. ส่งภาพไปยังเมธอด `ISlidesPicture.setImage`
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติว่ามีไฟล์ "lotus.png" ที่มีรูปต่อไปนี้:

![The lotus picture](lotus.png)

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าชนิดการเติมเป็น Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // ตั้งค่าโหมดการเติมรูปภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่าภาพ.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape with picture fill](picture-fill.png)

### **ใช้ภาพเป็นพื้นผิวแบบต่อกระเบื้อง**

หากคุณต้องการตั้งค่าภาพเป็นพื้นผิวแบบต่อกระเบื้องและปรับแต่งพฤติกรรมการต่อกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งค่าโหมดการเติมรูปภาพ — `Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุการจัดแนวของกระเบื้องภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่ากระเบื้องจะพลิกแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าการเยื้องแนวนอนของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าการเยื้องแนวตั้งของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยม.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปร่างเป็น Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปร่าง.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการต่อกระเบื้อง.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The tile options](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมรูปร่างด้วยสีเดียวที่สม่ำเสมอ สีพื้นหลังเรียบนี้จะถูกนำไปใช้โดยไม่มีไล่สี, พื้นผิว, หรือลวดลายใดๆ

เพื่อใช้การเติมสีทึบกับรูปร่างโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // ตั้งค่าสีเติม.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape with solid color fill](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีทึบ, ไล่สี, รูปภาพ, หรือพื้นผิวกับรูปร่าง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าโปร่งใสที่สูงทำให้รูปร่างดูโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่าอัลฟ่าในสีที่ใช้สำหรับการเติม ดำเนินการตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกการนำเสนอ

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมทึบ.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งแสงเหนือรูปร่างทึบ.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The transparent shape](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพตามการจัดวางหรือความต้องการออกแบบเฉพาะ

เพื่อหมุนรูปร่างบนสไลด์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ตั้งค่าคุณสมบัติการหมุนของรูปร่างเป็นมุมที่ต้องการ
1. บันทึกการนำเสนอ

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่าง 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape rotation](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์ Bevel 3 มิติกับรูปร่างโดยการกำหนดค่าคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) ของมัน

เพื่อเพิ่มเอฟเฟกต์ Bevel 3 มิติให้กับรูปร่าง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. กำหนดค่าคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) ของรูปร่างเพื่อกำหนดการตั้งค่า bevel
1. บันทึกการนำเสนอ

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างลงในสไลด์.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The 3D bevel effect](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติกับรูปร่างโดยการกำหนดค่าคุณสมบัติ [ThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/) ของมัน

เพื่อใช้การหมุน 3 มิติกับรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
1. ใช้ [setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3 มิติ
1. บันทึกการนำเสนอ

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The 3D rotation effect](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์ขาวดำสำหรับรูปร่าง**

เมธอด [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) ระบุวิธีที่รูปร่างแต่ละชิ้นจะถูกเรนเดอร์เมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว‑ดำ ซึ่งเมธอดนี้ไม่ได้เปิดใช้งานการแสดงผลขาว‑ดำโดยอัตโนมัติและไม่ได้เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่นในโหมดสีทั่วไป

ใช้ค่าจาก enumeration [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและขาว, `Black` และ `White` บังคับสีเดียว, `Color` รักษาสีปกติ, `Hidden` ไม่แสดงรูปร่างในโหมดขาว‑ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

โค้ด JavaScript ต่อไปนี้สร้างรูปร่างสีและทำให้แสดงเป็นสีเทาในโหมดแสดงผลขาว‑ดำ:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // เก็บสีการเติมสีส้มในโหมดสี, แต่เรนเดอร์รูปร่างด้วยสีเทาในโหมดขาว-ดำ.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในโหมดสีปกติ สี่เหลี่ยมจะคงสีส้มของการเติมไว้ ส่วนในกระบวนการแสดงผลขาว‑ดำ จะใช้สีเทาเนื่องจากโหมดตั้งเป็น `Gray` สิ่งนี้ทำให้คุณสามารถรักษาสไลด์สีเต็มได้ในขณะที่กำหนดลักษณะการแสดงเฉพาะสำหรับการพิมพ์, การพรีวิว หรือกระบวนการอื่นที่เคารพการตั้งค่าการแสดงผลขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

โค้ด JavaScript ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปร่างทั้งหมดที่มีตัวแสดงบน [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/) ให้กลับไปเป็นค่าตั้งต้น:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // รีเซ็ตรูปร่างแต่ละชิ้นบนสไลด์ที่มีตัวอิงบนเลย์เอาต์.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์ของงานนำเสนอสุดท้ายหรือไม่?**

เพียงเล็กน้อย ภาพและสื่อที่ฝังอยู่เป็นส่วนใหญ่ของขนาดไฟล์ ส่วนพารามิเตอร์ของรูปร่างเช่นสี, เอฟเฟกต์และไล่สีจะถูกจัดเก็บเป็นเมทาดาต้าและเพิ่มขนาดเกือบไม่มี

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ถือว่ารูปร่างเหล่านั้นมีสไตล์เดียวกันและสามารถจัดกลุ่มตรรกะได้ ซึ่งช่วยลดความซับซ้อนในการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ ให้เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์แม่แบบหรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์ต้องการ, และนำการจัดรูปแบบของมันไปใช้ใหม่ตามที่ต้องการ