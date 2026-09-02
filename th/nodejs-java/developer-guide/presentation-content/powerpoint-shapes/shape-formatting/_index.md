---
title: จัดรูปแบบรูปร่าง PowerPoint ใน JavaScript
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
- การเติมแบบไล่ระดับสี
- การเติมลวดลาย
- การเติมภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปทรง
- การเรนเดอร์รูปทรงสีขาว‑ดำ
- การเรนเดอร์รูปทรงระดับสีเทา
- หมุนรูปทรง
- เอฟเฟกต์เบเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดรูปแบบรูปร่าง PowerPoint ใน JavaScript ด้วย Aspose.Slides—กำหนดสไตล์การเติม, เส้น, และเอฟเฟกต์สำหรับไฟล์ PPT, PPTX, และ ODP อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปทรงลงในสไลด์ได้ เนื่องจากรูปทรงประกอบด้วยเส้นต่าง ๆ คุณจึงสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับโครงร่างของมัน นอกจากนี้ คุณยังสามารถจัดรูปแบบรูปทรงโดยระบุการตั้งค่าที่ควบคุมการเติมภายในรูปทรงได้อีกด้วย

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java มีคลาสและเมธอดที่ให้คุณจัดรูปแบบรูปทรงได้ด้วยตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ด้วย Aspose.Slides คุณสามารถกำหนดสไตล์เส้นที่กำหนดเองสำหรับรูปทรงได้ ขั้นตอนต่อไปนี้อธิบายขั้นตอนการทำงาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linestyle/) ของรูปทรง  
1. ตั้งค่าความกว้างของเส้น  
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linedashstyle/) ของเส้น  
1. ตั้งค่าสีของเส้นสำหรับรูปทรง  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ดต่อไปนี้แสดงวิธีการจัดรูปแบบ `AutoShape` สี่เหลี่ยม:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปของประเภท Rectangle
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // ลบการเติมสีออกจากรูปทรงสี่เหลี่ยม
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // ใช้การจัดรูปแบบกับเส้นของสี่เหลี่ยม
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยม
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The formatted lines in the presentation](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปทรง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปทรงดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/lineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sketchformat/) เพื่อเลือกค่าจากอาเรย์ [LineSketchType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linesketchtype/)  

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยตรง และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linesketchtype/) :

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // เข้าถึงรูปแบบเส้นของรูปทรงและรูปแบบสเก็ตช์ของมัน.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // ใช้เอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูปทรง.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // ลบเอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

ค่าที่คืนโดย [SketchFormat.getSketchType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sketchformat/) แสดงถึงการตั้งค่าที่กำหนดโดยตรงให้กับรูปทรง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์ หรือเลย์เอาต์สไลด์, ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/lineformat/), เรียก `getSketchFormat` บนวัตถุที่คืน แล้วเรียกเมธอด `getSketchType` ของมัน ค่าที่ได้จะแสดงการจัดรูปแบบที่แท้จริงหลังจากที่การสืบทอดได้รับการแก้ไขแล้ว:

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

ต่อไปนี้คือสามตัวเลือกของประเภทการเชื่อมต่อ:

* Round  
* Miter  
* Bevel  

โดยค่าเริ่มต้น PowerPoint จะใช้การตั้งค่า **Round** เมื่อเชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปทรง) อย่างไรก็ตาม หากคุณกำลังวาดรูปทรรงที่มีมุมคม คุณอาจต้องการตัวเลือก **Miter**  

![The join style in the presentation](join-style-powerpoint.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีการสร้างสี่เหลี่ยมสามอัน (ตามภาพข้างบน) ด้วยการตั้งค่า Join Type เป็น Miter, Bevel, และ Round ตามลำดับ:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปสามรายการประเภท Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปทรงสี่เหลี่ยมแต่ละอัน.
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

    // ตั้งค่าสีสำหรับเส้นของสี่เหลี่ยมแต่ละอัน.
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

    // เพิ่มข้อความลงในสี่เหลี่ยมแต่ละอัน.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมสีไล่ระดับ (Gradient Fill)**

ใน PowerPoint, Gradient Fill คือตัวเลือกการจัดรูปแบบที่ให้คุณใส่การผสมสีต่อเนื่องลงในรูปทรง ตัวอย่างเช่น คุณสามารถใส่สีสองสีหรือหลายสีโดยให้สีหนึ่งค่อย ๆ จางลงสู่สีอื่น  

วิธีการใส่ Gradient Fill ให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปทรงเป็น `Gradient`  
1. ใช้วิธี `add` ของคอลเลกชัน Gradient Stop ที่เปิดเผยโดยคลาส [GradientFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/gradientformat/) เพื่อเพิ่มสีที่ต้องการสองสีพร้อมตำแหน่งที่กำหนด  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใส่เอฟเฟกต์ Gradient Fill ให้กับวงรี:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปประเภท Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบแบบไล่ระดับสีกับ Ellipse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // ตั้งทิศทางของการไล่ระดับสี.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // เพิ่มจุดหยุดไล่ระดับสีสองจุด.
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

## **การเติมลวดลาย (Pattern Fill)**

ใน PowerPoint, Pattern Fill คือตัวเลือกการจัดรูปแบบที่ให้คุณใส่การออกแบบสองสี—เช่น จุด, ลายเส้น, ลายตาข่าย หรือ ลายตาราง—ลงในรูปทรง คุณสามารถเลือกสีพื้นหน้าและพื้นหลังของลวดลายได้ตามต้องการ  

Aspose.Slides มีลายแบบพร้อมใช้งานกว่า 45 แบบที่คุณสามารถใส่ลงในรูปทรงเพื่อเพิ่มความสวยงามให้กับงานนำเสนอของคุณ แม้หลังจากเลือกลายแบบที่กำหนดไว้แล้ว คุณก็ยังสามารถระบุสีที่แน่นอนที่ลายแบบจะใช้ได้  

วิธีการใส่ Pattern Fill ให้กับรูปทรงโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปทรงเป็น `Pattern`  
1. เลือกสไตล์ลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า  
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/patternformat/#getBackColor--) ของลาย  
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/patternformat/#getForeColor--) ของลาย  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใส่ Pattern Fill ให้กับสี่เหลี่ยม:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปประเภท Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // ตั้งค่าสไตล์ลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลาย.
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

## **การเติมรูปภาพ (Picture Fill)**

ใน PowerPoint, Picture Fill เป็นตัวเลือกการจัดรูปแบบที่ให้คุณใส่ภาพไว้ภายในรูปทรง—ทำให้ภาพนั้นทำหน้าที่เป็นพื้นหลังของรูปทรง  

วิธีการใช้ Aspose.Slides เพื่อใส่ Picture Fill ให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปทรงเป็น `Picture`  
1. ตั้งค่าโหมดเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ)  
1. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) จากภาพที่ต้องการใช้  
1. ส่งภาพไปยังเมธอด `ISlidesPicture.setImage`  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

สมมติว่าเรามีไฟล์ "lotus.png" พร้อมรูปภาพต่อไปนี้:

![The lotus picture](lotus.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีเติมรูปทรงด้วยรูปภาพ:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปประเภท Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าชนิดการเติมเป็น Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // ตั้งค่าโหมดการเติมรูปภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่ารูปภาพ.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape with picture fill](picture-fill.png)

### **Tile Picture As Texture**

หากต้องการตั้งภาพที่ทำเป็นลายกระเบื้องเป็นเทกซ์เจอร์และปรับพฤติกรรมการกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งค่าโหมดเติมรูปภาพ—`Tile` หรือ `Stretch`  
- [setTileAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุตำแหน่งการจัดเรียงของกระเบื้องภายในรูปทรง  
- [setTileFlip](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมการพลิกกระเบื้องแนวนอน, แนวตั้ง หรือทั้งสองแบบ  
- [setTileOffsetX](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าการชดเชยในแนวนอนของกระเบื้อง (หน่วย point) จากต้นกำเนิดของรูปทรง  
- [setTileOffsetY](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าการชดเชยในแนวตั้งของกระเบื้อง (หน่วย point) จากต้นกำเนิดของรูปทรง  
- [setTileScaleX](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์  
- [setTileScaleY](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์  

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่มรูปทรงสี่เหลี่ยมที่ใช้ Picture Fill แบบกระเบื้องและกำหนดตัวเลือกกระเบื้อง:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปสี่เหลี่ยม.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปทรงเป็น Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปทรง.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดโหมดเติมรูปภาพและคุณสมบัติการกระเบื้อง.
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

## **การเติมสีทึบ (Solid Color Fill)**

ใน PowerPoint, Solid Color Fill คือการจัดรูปแบบที่เติมสีเดียวอย่างสม่ำเสมอให้กับรูปทรง พื้นหลังสีเดียวนี้จะไม่มีการไล่สี, เทกซ์เจอร์ หรือ ลวดลายใด ๆ  

เพื่อใส่ Solid Color Fill ให้กับรูปทรงโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปทรงเป็น `Solid`  
1. กำหนดสีเติมที่คุณต้องการให้กับรูปทรง  
1. บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX  

โค้ด JavaScript ต่อไปนี้แสดงวิธีใส่ Solid Color Fill ให้กับสี่เหลี่ยมในสไลด์ PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปประเภท Rectangle.
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

## **ตั้งค่าความโปร่งใส (Set Transparency)**

ใน PowerPoint เมื่อคุณใส่สีทึบ, Gradient, Picture หรือ Texture Fill ให้กับรูปทรง คุณยังสามารถกำหนดระดับความโปร่งใสเพื่อควบคุมความทึบของการเติมได้ ค่าความโปร่งใสที่สูงจะทำให้รูปทรงดูโปร่งใสมากขึ้นและทำให้พื้นหลังหรือวัตถุตามหลังมองเห็นได้บางส่วน  

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่าอัลฟาในสีที่ใช้สำหรับการเติม วิธีทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) เป็น `Solid`  
1. ใช้ `Color` เพื่อกำหนดสีพร้อมความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)  
1. บันทึกงานนำเสนอ  

โค้ด JavaScript ต่อไปนี้แสดงวิธีใส่สีเติมที่มีความโปร่งใสให้กับสี่เหลี่ยม:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปสี่เหลี่ยมแบบทึบ.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มออโตชัปสี่เหลี่ยมโปร่งใสเหนือรูปทรงทึบ.
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

## **หมุนรูปทรง (Rotate Shapes)**

Aspose.Slides ให้คุณหมุนรูปทรงในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องการวางตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือความต้องการออกแบบเฉพาะ  

เพื่อหมุนรูปทรงบนสไลด์ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ตั้งค่าคุณสมบัติการหมุนของรูปทรงเป็นมุมที่ต้องการ  
1. บันทึกงานนำเสนอ  

โค้ด JavaScript ต่อไปนี้แสดงวิธีหมุนรูปทรงโดย 5 องศา:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์งานนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มออโตชัปประเภท Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปทรง 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The shape rotation](shape-rotation.png)

## **เพิ่มเอฟเฟกต์ Bevel 3 มิติ (Add 3D Bevel Effects)**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์ Bevel 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/)  

เพื่อเพิ่มเอฟเฟกต์ Bevel 3 มิติให้กับรูปทรง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/) ของรูปทรงเพื่อระบุการตั้งค่า bevel  
1. บันทึกงานนำเสนอ  

โค้ด JavaScript ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ Bevel 3 มิติบนรูปทรง:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปทรงลงในสไลด์.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปทรง.
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

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ (Add 3D Rotation Effects)**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรงโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/)  

เพื่อปรับการหมุน 3 มิติให้กับรูปทรง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)  
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์  
1. ใช้ [setCameraType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3 มิติ  
1. บันทึกงานนำเสนอ  

โค้ด JavaScript ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์การหมุน 3 มิติบนรูปทรง:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation.
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

## **ควบคุมการแสดงผลสีขาว‑ดำสำหรับรูปทรง (Control Black-and-White Rendering for Shapes)**

เมธอด [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) ระบุว่ารูปทรงแต่ละอันจะถูกเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดสีขาว‑ดำ มันไม่ทำให้เปิดใช้งานโหมดสีขาว‑ดำโดยอัตโนมัติ และไม่เปลี่ยนสีเติม, เส้น หรือการจัดรูปแบบอื่น ๆ ของรูปทรงในโหมดสีปกติ  

ใช้ค่าจากอาเรย์ [BlackWhiteMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้สีดำ‑ขาวเท่านั้น, `Black` และ `White` บังคับสีเดียว, `Color` รักษาสีปกติ, `Hidden` ไม่แสดงรูปทรงในโหมดสีขาว‑ดำ, `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปทรง  

โค้ด JavaScript ต่อไปนี้สร้างรูปทรงสีและทำให้มันแสดงเป็นสีเทาในโหมดแสดงผลสีขาว‑ดำ:

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

    // คงการเติมสีส้มในโหมดสี, แต่เรนเดอร์รูปทรงด้วยสีเทาในโหมดขาว‑ดำ.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในโหมดสีปกติ สี่เหลี่ยมจะคงสีส้มไว้ ในกระบวนการทำงานแบบสีขาว‑ดำ มันจะใช้สีเทาเนื่องจากโหมดถูกตั้งเป็น `Gray` ซึ่งช่วยให้คุณเก็บสไลด์สีเต็มไว้ในขณะกำหนดลักษณะที่แตกต่างสำหรับการพิมพ์, การแสดงตัวอย่าง หรือกระบวนการอื่น ๆ ที่เคารพการตั้งค่าแสดงผลสีขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ (Reset Formatting)**

โค้ด JavaScript ต่อไปนี้แสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนตำแหน่ง, ขนาด, และการจัดรูปแบบของรูปทรงทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) ไปยังค่าตั้งต้น:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // รีเซ็ตรูปทรงแต่ละอันบนสไลด์ที่มี placeholder บนเลย์เอาต์.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย (FAQ)**

**การจัดรูปแบบรูปทรงมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบน้อยมาก ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปทรงเช่น สี, เอฟเฟกต์, และการไล่สีถูกเก็บเป็นเมตาดาต้าและแทบไม่มีขนาดเพิ่มขึ้น

**ฉันจะตรวจจับรูปทรงบนสไลด์ที่มีการจัดรูปแบบตรงกันเพื่อที่จะจัดกลุ่มได้อย่างไร?**

ให้เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปทรง—การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ให้ถือว่าสไตล์เหมือนกันและจัดกลุ่มรูปทรงเหล่านั้นในเชิงตรรกะ ซึ่งช่วยให้งานจัดการสไตล์ในภายหลังง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปทรงที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้ ให้เก็บรูปทรงตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์เด็คหรือไฟล์เทมเพลต .POTX เมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปทรงที่สไตล์ต้องการ, แล้วนำการจัดรูปแบบนั้นไปใช้ใหม่ตามต้องการ  