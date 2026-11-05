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
- การเติมลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- การเรนเดอร์รูปร่างสีขาวดำ
- การเรนเดอร์รูปร่างระดับสีเทา
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ด้วย JavaScript โดยใช้ Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟกต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยการปรับเส้นขอบ, การเติมสี, และเอฟเฟกต์ต่าง ๆ Aspose.Slides for Node.js via Java ให้คุณควบคุมการตั้งค่าเหล่านี้โดยโปรแกรม, รวมถึงความโปร่งใส, การหมุน, และการจัดรูปแบบ 3 มิติ

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java มีคลาสและเมธอดที่ช่วยให้คุณจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าไม่มีการเติมสีโดยมีเส้นขอบสีฟ้าลายประ [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) เลือกเส้นแบบคอมพาวน์หนา-บาง ในขณะที่ [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) ตั้งค่าความกว้างเป็น 7 จุด และ [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) เลือกรูปแบบเส้นประ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

### **ตั้งค่ารูปแบบเส้นประแบบกำหนดเอง**

ใช้ [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) เมื่อสไตล์เส้นที่กำหนดไว้ล่วงหน้าไม่ให้ความยาวและช่องว่างที่ต้องการ, เช่นสำหรับเส้นขอบแบรนด์หรือแผนผังทางเทคนิค การกำหนดรูปแบบจะเปลี่ยนสไตล์เส้นประโดยอัตโนมัติเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/)

รายการในอาร์เรย์สลับระหว่างความยาวของเส้นประและช่องว่าง เริ่มด้วยเส้นประ แต่ละค่าเป็นผลคูณของความกว้างเส้น: `[4, 2]` ที่ความกว้าง 3 จุดจะให้เส้นประ 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ของค่าจำนวนเต็มที่ไม่เป็นลบเพื่อกำหนดส่วนเส้นประ‑ช่องว่างครบถ้วน ตัวอย่างใช้ค่าบวกเพื่อให้เส้นประและช่องว่างทั้งหมดมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีน้ำเงิน 5 เส้นที่มีความยาวและปลายเส้นระดับเดียวกัน เส้นสามแรกเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด เส้นที่สี่ทำซ้ำรูปแบบแรกที่ความกว้างสองเท่า ทำให้ทั้งเส้นประและช่องว่างยาวสองเท่า เส้นที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // คืนค่าเส้นสุดท้ายเป็นสไตล์ทึบ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

เพื่อกลับไปใช้สไตล์เส้นประที่กำหนดไว้ล่วงหน้า ให้ส่ง [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) ไปยัง [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**.

![สามรูปแบบเส้นประแบบกำหนดเอง, เส้นที่กว้างขึ้นใช้รูปแบบแรก, และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **ตั้งค่าปลายเส้น**

ใช้ [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) เพื่อกำหนดจุดสิ้นสุดของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) มีสไตล์ปลายเส้นที่ระบุสามแบบ:

- `Flat`: สตrokes จะหยุดที่จุดสิ้นสุด
- `Round`: ปลายแบบกึ่งวงกลมยืดออกไปเหนือจุดสิ้นสุดโดยครึ่งความกว้างของเส้น
- `Square`: ปลายแบบสี่เหลี่ยมจัตุรัสยืดออกไปเหนือจุดสิ้นสุดโดยครึ่งความกว้างของเส้น

คลาสยังมี `NotDefined` ซึ่งหมายความว่าไม่มีการกำหนดสไตล์ปลายเส้นอย่างชัดเจน

ปลายเส้นต่างจากหัวลูกศรที่เพิ่มสัญลักษณ์ที่จุดสิ้นสุดของเส้น และจุดเชื่อมที่ควบคุมมุมระหว่างส่วนเส้น ตัวอย่างนี้ปิดการทำงานของหัวลูกศรด้วย [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) และ [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) เพื่อให้เปรียบเทียบเฉพาะรูปแบบปลายเส้น

ตัวอย่างต่อไปนี้สร้างเส้นแนวนอนสามเส้นที่เหมือนกันโดยมีความกว้าง 20 จุด จากบนลงล่าง ใช้ปลายเส้น Flat, Round, และ Square ตามลำดับ จุดสิ้นสุดของเส้นทั้งหมดมีพิกัดแนวนอนเดียวกัน; ปลาย Round และ Square ยืดออกไป 10 จุดเหนือจุดสิ้นสุด

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **Flat**, **Round**, และ **Square**.

![ปลายเส้นแบบ Flat, Round, และ Square บนเส้นหนาแบบเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนถูกวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/)

โค้ด JavaScript ด้านล่างแสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/), อ่านค่าที่กำหนดโดยชัดเจน, และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

ค่าที่คืนจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, สไลด์แม่, หรือสไลด์เลย์เอาต์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective), เรียก `getSketchFormat` บนวัตถุที่คืนค่า, แล้วเรียกเมธอด `getSketchType` ของมัน ค่าที่มีประสิทธิผลจะสะท้อนการจัดรูปแบบที่ถูกใช้จริงหลังจากสืบทอดเสร็จ ตัวอย่างนี้ต้องการงานนำเสนอที่มีรูปร่างอย่างน้อยหนึ่งรูปบนสไลด์แรกและพิมพ์ค่าทั้งสอง:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

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

นี่คือสามตัวเลือกประเภทการเชื่อมต่อ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อควบคุมวิธีที่สองส่วนขอบมาบรรจบกันที่มุม ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมแบน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำสามอันที่มีเส้นขอบสีน้ำเงินความกว้าง 15 จุด ใช้ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) เพื่อกำหนดค่า miter, bevel, และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) ตามลำดับ เพื่อเปรียบเทียบว่ามุมถูกวาดอย่างไร

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **จำกัดการเชื่อมต่อมิตเทอร์ที่มุมแหลม**

ใช้ [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) ร่วมกับ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) ตั้งเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมแหลมสามารถยืดออกไปได้

ขีดจำกัดเป็นอัตราส่วนระหว่างระยะห่างระหว่างมุมในและมุมนอกของการเชื่อมต่อกับความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวมิตเทอร์สูงสุดถึงแปดเท่าของความกว้างเส้น; ไม่ได้เป็นการวัดเป็นจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบบีเวลที่มุมนั้น ขีดจำกัดที่ใหญ่กว่าจะให้จุดแหลมขึ้น การตั้งค่านี้มีผลเฉพาะการเชื่อมต่อแบบมิตเทอร์เท่านั้นและการเปลี่ยนแปลงจะไม่มีผลเห็นได้เมื่อมุมยังอยู่ในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไม่มีการเติมสีสองรูปที่เส้นขอบความกว้าง 20 จุด รูปซ้ายใช้ขีดจำกัด `2` ส่วนรูปขวาใช้ `8` แต่ละรูปกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาวมิตเทอร์ต่อความกว้างเส้นประมาณ `4.12` ดังนั้น PowerPoint จะบีเวลจุดยอดซ้ายและคงจุดยอดขวาไว้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ด้านซ้ายและ **miter limit 8** ด้านขวา

![ยอดมุมที่บีเวลด้วยมิตเทอร์ลิมิต 2 และยอดที่แหลมด้วยมิตเทอร์ลิมิต 8 ใน PowerPoint](miter-limits.png)

## **การเติมแบบไล่สี**

การเติมแบบไล่สีผสมสีต่าง ๆ ไว้บนรูปร่าง ตัวอย่างนี้เติมวงรีด้วยไล่สีเชิงเส้นมุม 45° จากสีแดงไปสีม่วงโดยใช้ [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) เมธอด [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) วางจุดหยุดสีที่ตำแหน่ง 0 และ 1 (จุดเริ่มต้นและจุดสิ้นสุดของไล่สี) การลบจุดหยุดเดิมทำให้ใช้เฉพาะสองสีนี้เท่านั้น

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![วงรีที่มีการเติมแบบไล่สี](gradient-fill.png)

หากไล่สีแสดงผลแตกต่างในภาพที่ส่งออกเมื่อเทียบกับใน PowerPoint ให้ดูที่ [Choose a Gradient Rendering Style](/slides/th/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการเติมไล่สีที่จัดเก็บในงานนำเสนอ

### **ตั้งค่ามุมไล่สีเชิงเส้น**

ใช้ [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) เพื่อควบคุมทิศทางของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) มุมวัดเป็นอากาศและเพิ่มตามเข็มนาฬิกา: `0` คือจากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน มุมทศนิยมก็รองรับ มุมที่ไม่อยู่ในช่วง `[0, 360)` จะถูกทำให้เป็นรอบเดียว เช่น `-45` จะเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกอันที่มีจุดหยุดสีแดง, เขียว, น้ำเงินที่ตำแหน่ง `0`, `0.5`, และ `1` เหมือนกัน การสเกลถูกปิดเพื่อให้เปรียบเทียมมุมโดยไม่ขึ้นกับสัดส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และในแถวที่สองคือ `135`, `180`, `270`

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint:

![ไล่สีเชิงเส้นที่ 0°, 45°, และ 90° ในแถวบน, และ 135°, 180°, และ 270° ในแถวล่าง](linear-gradient-angles.png)

### **สเกลไล่สีเชิงเส้นตามรูปร่าง**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) รับค่า [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) ตั้งเป็น `False` เพื่อให้มุมไล่สีเรขาคณิตคงที่เมื่อสัดส่วนของรูปร่างเปลี่ยน, หรือตั้งเป็น `True` เพื่อสเกลไล่สีตามความกว้างและความสูงของรูปร่าง เมื่อเปิดสเกล, มุมที่มองเห็นอาจต่างจากมุมที่กำหนดในรูปทรงที่ไม่เป็นสี่เหลี่ยมจตุรัส

ตัวอย่างต่อไปใช้มุม `45`° และจุดหยุดสีเดียวกับการเปรียบเทียบมุม คอลัมน์ซ้ายใช้ `False`; คอลัมน์ขวาใช้ `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างด้านบนและสี่เหลี่ยมสูงด้านล่าง ทั้งสองเริ่มจากขนาดกว้างเดียวกัน; การเปลี่ยนความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงให้เห็นว่าการเติมตอบสนองต่อการปรับขนาดอย่างไรโดยไม่เปลี่ยนการตั้งค่าไล่สี

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ใน PowerPoint, โดยปิดสเกลทางซ้ายและเปิดสเกลทางขวา:

![สี่เหลี่ยมกว้างและสูงที่มีไล่สี 45°, เปรียบเทียบ LinearGradientScaled False ด้านซ้ายกับ True ด้านขวา](linear-gradient-scaling.png)

เมื่อปิดสเกล, แถบสีแนวทแยงคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม เมื่อเปิดสเกล, แถบสีจะยืดตามสัดส่วนของรูปร่าง นี้ช่วยทำสำเนาไล่สีของเทมเพลตเมื่อปรับขนาดรูปร่างให้ต่างกัน บนสี่เหลี่ยมจตุรัส การเปิดสเกลจะไม่เปลี่ยนลักษณะของไล่สี `45`° นี้

การตั้งค่ามุมและสเกลใช้ได้กับไล่สีเชิงเส้นเท่านั้น ไม่ควบคุมการเติม [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/)

### **รวมมุมกับทิศทางไล่สี**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) เลือกสไตล์ไล่สีจากคลาส [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/) ซึ่งไม่ใช่การแทนที่มุมเชิงตัวเลข สำหรับไล่สีเชิงเส้น, สไตล์มุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) ให้คงทิศทางเดิมเมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างต่อไปใช้การตั้งค่าเดียวกันแต่สลับลำดับ สี่เหลี่ยมสองอันจะแสดงผลเหมือนกัน: การกำหนดทิศทางก่อนหรือหลังมุมไม่ทำให้ผลลัพธ์เปลี่ยน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมรูปแบบลาย**

การเติมรูปแบบลายใช้การออกแบบสองสีเช่นจุด, ลายเส้น, หรือเช็คบอร์ด ตัวอย่างนี้ใช้ [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) เพื่อเลือกลาย Trellis [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) ให้พื้นหลังสีเทาอ่อน, และ [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) ให้สีเหลืองของลาย

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลาย](pattern-fill.png)

## **การเติมรูปภาพ**

การเติมรูปภาพใช้รูปภายในรูปร่าง ตัวอย่างนี้ต้องการไฟล์รูปภายในเครื่องและใช้ [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) เพื่อโหลดเข้าสู่คอลเลกชันรูปภาพของงานนำเสนอ การตั้งค่า [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) เป็นโหมดกระเบื้องทำให้รูปภาพถูกทำซ้ำภายในสี่เหลี่ยม รูปภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปภาพบัว](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่มีการเติมรูปภาพ](picture-fill.png)

### **การทำรูปภาพเป็นเท็กซ์เจอร์แบบเรียงต่อกัน**

หากต้องการตั้งค่ารูปภาพเป็นเท็กซ์เจอร์แบบกระเบื้องและปรับพฤติกรรมการกระเบื้อง สามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): กำหนดโหมดการเติมรูปภาพ—หรือ `Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): กำหนดการจัดแนวของไทล์ภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่าไทล์จะถูกพลิกแนวนอน, แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): กำหนดการเยื้องแนวนอนของไทล์ (หน่วยจุด) จากจุดต้นของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): กำหนดการเยื้องแนวตั้งของไทล์ (หน่วยจุด) จากจุดต้นของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของไทล์เป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของไทล์เป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการรูปภาพภายในเครื่องและกำหนดค่า [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) ให้ทำซ้ำที่ 50% ของขนาดต้น ฉากย้าย `−32` จุดทำให้ไทล์ย้ายแนวนอนและแนวตั้ง; การจัดตำแหน่งด้านล่าง‑ขวาและการพลิกในสองทิศทางกำหนดวิธีการจัดเรียงเท็กซ์เจอร์ที่ทำซ้ำ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ตัวเลือกไทล์](tile-options.png)

## **การเติมสีทึบ**

การเติมสีทึบให้รูปร่างสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ใช้ [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) เพื่อเลือกโหมดเติมสีทึบและกำหนดสีเหลืองผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) จากนั้นบันทึกสี่เหลี่ยมในงานนำเสนอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่มีการเติมสีทึบ](solid-color-fill.png)

### **คัดลอกสีพร้อมคงการอ้างอิงธีม**

ใช้ [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) เพื่อคัดลอกคำนิยามสีรวมประเภทสี, การอ้างอิงธีม, และการแปลงค่า ซึ่งมีประโยชน์เมื่อต้องถ่ายโอนสีเติมระหว่างรูปร่างที่ควรยังคงตามธีมงานนำเสนอ เมธอดจะคัดลอกเฉพาะสี ไม่ได้คัดลอกประเภทการเติม, เส้นขอบ, หรือการจัดรูปแบบอื่น ๆ ของรูปร่าง ตั้งประเภทการเติมของปลายทางโดยชัดเจนด้วย [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType)

ตัวอย่างนี้สร้างสี่เหลี่ยมสามอันจากซ้ายไปขวา: แหล่งที่มา, คัดลอกที่รับรู้ธีม, และคัดลอกที่เป็น RGB คงที่ แหล่งที่มาใช้ [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) เพื่ออ้างอิงสีเน้นแรกและเพิ่มสีสว่างผ่าน [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add) คัดลอก RGB ใช้สีเติมที่มีประสิทธิผลของแหล่งที่มาเพื่อให้สามรูปแรกดูเหมือนกัน การเรียก [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) ตั้งค่า RGB คงที่และลบการแปลงสีใด ๆ ที่มีอยู่

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // การอ้างอิงธีมจะตามสีเน้นใหม่; ค่ารหัส RGB คงที่จะไม่ตาม.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ก่อนเปลี่ยนธีม, การเติมสามรูปนี้เหมือนกัน:

![แหล่งที่มา, ปลายทาง copyFrom, และปลายทาง RGB คงที่ที่มีการเติมสีน้ำเงินแบบเดิม](color-copy-before.png)

หลังเปลี่ยนธีม, แหล่งที่มาและคัดลอกที่รับรู้ธีมจะตามสีเน้นใหม่และคงสีสว่างไว้ คัดลอก RGB คงที่ยังคงเป็นสีน้ำเงิน:

![แหล่งที่มาและปลายทาง copyFrom ที่เติมสีส้ม, ในขณะที่ปลายทาง RGB คงที่ยังคงเป็นสีน้ำเงิน](color-copy-after.png)

คำนิยามที่คัดลอกนั้นเป็นอิสระจากแหล่งที่มา การเปลี่ยนการอ้างอิงธีมของแหล่งที่มา, กำหนดสีอื่น, หรือเพิ่ม/ลบการแปลงจะไม่กระทบต่อปลายทาง การเปลี่ยนธีมยังคงส่งผลต่อรูปร่างทั้งสองเนื่องจากแต่ละรูปอ้างอิงสีธีมเดียวกัน

การบันทึกและเปิดไฟล์ PPTX ใหม่จะคงประเภทสีที่คัดลอกจาก [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType), การอ้างอิงธีม, และคอลเลกชันการแปลงจาก [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform); ไม่ได้แปลงคำนิยามเป็น RGB

เมื่อคัดลอกระหว่างบริบทธีมที่แตกต่างกัน เช่นงานนำเสนอที่มีพาเล็ตสีเน้นต่างกัน การอ้างอิงที่คัดลอกจะถูกแก้ไขตามธีมของปลายทาง การอ้างอิงและการแปลงเดียวกันอาจทำให้สีที่มองเห็นแตกต่าง ดูที่ [Presentation Theme](/slides/th/nodejs-java/presentation-theme/) เพื่อเรียนรู้การกำหนดสีธีมเพิ่มเติม

## **ใช้พื้นหลังสไลด์เป็นการเติมของรูปร่าง**

ใช้ [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) เมื่อรูปร่างต้องการให้ตรงกับพื้นหลังสไลด์ เช่นในเทมเพลตงานนำเสนอ ตั้งประเภทการเติมด้วย [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) เป็น [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) ก่อนเพื่อเอาการเติมที่กำหนดไว้แล้วออก การผสานนี้ทำให้รูปร่างใช้พื้นหลังสไลด์แทนการเติมตามสไตล์ของมัน การเปิดใช้งานฟlags เพียงอย่างเดียวไม่ทำให้การเติมที่กำหนดไว้ลบออก

สิ่งนี้แตกต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) : การเติมพื้นหลังจะครอบวัตถุที่อยู่ด้านหลังรูปร่างด้วยพื้นที่ของพื้นหลังสไลด์ที่สอดคล้องกัน ส่วน NoFill จะทำให้วัตถุเหล่านั้นมองเห็นได้ ไล่สีจะยังคงจัดแนวกับสไลด์แทนที่จะเริ่มใหม่ในแต่ละรูปร่าง

ตัวอย่างต่อไปนี้สร้างพื้นหลังมาสเตอร์ที่สไลด์สืบทอดและวางแถบสีชมพูเมจานต์ไว้ด้านหลังสี่เหลี่ยมสามอัน สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, สี่เหลี่ยมขวาสลับจากการเติมพื้นหลังเป็นการเติมสีส้มอย่างชัดเจน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // สืบทอดไล่สีจากมาสเตอร์.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // เพิ่มวัตถุนี้ก่อนเพื่อให้ปรากฏอยู่ด้านหลังสี่เหลี่ยม.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // ปิดการเติมพื้นหลังก่อนที่จะกำหนดการเติมแบบชัดเจน.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **background fill**, **no fill**, และ **explicit fill** แถบสีชมพูเมจานต์ถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นได้ผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม, และการเติมสีส้มอย่างชัดเจนเหนือแถบสีชมพูเมจานต์](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปร่างจะใช้พื้นหลังที่ถูกแก้ไขของสไลด์; ตัวอย่างนี้ไม่ได้กำหนดพื้นหลังของสไลด์และเลย์เอาต์เพื่อให้มาสเตอร์เป็นผู้จัดหา

## **ตั้งค่าความโปร่งใส**

สำหรับการเติมสีทึบ, ค่าส่วน alpha ของสีควบคุมความทึบ: 0 คือโปร่งใสเต็ม, 255 คือทึบเต็ม ตัวอย่างนี้ใช้ค่าฝาน `128` สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50% เพื่อให้สี่เหลี่ยมด้านล่างมองเห็นได้ สีถูกกำหนดผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

ใช้ [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) เพื่อหมุนรูปร่างในระนาบสไลด์ มุมวัดเป็นอากาศ; ตัวอย่างนี้หมุนสี่เหลี่ยม 5° ตามเข็มนาฬิกาและบันทึกงานนำเสนอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) เพื่อให้รูปร่างมีความลึกและขอบบีเวล ตัวอย่างนี้สร้างวงรีสีเขียวพร้อมเส้นขอบสีส้ม, ใช้ [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) ตั้งความลึกเป็น 4 จุด, และใช้ [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) เพื่อทำบีเวลด้านบนแบบวงกลมที่ความกว้างและความสูง 6 จุด กล้องแบบออร์โธกราฟิกที่มองหน้าและแสงสามจุดทำให้บีเวลมองเห็นได้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

มุมมอง 3 มิติของรูปร่างควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) ด้วยมุมละติจูด, ลองจิจูด, และมุมการหมุน 40°, 35°, และ 20° ตามลำดับ เลือกกล้องอิซอมอร์ฟิกผ่าน [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) และแสงแบบสมดุลผ่าน [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) จากนั้นบันทึกสี่เหลี่ยมที่จัดรูปแบบ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการแสดงผลขาวดำสำหรับรูปร่าง**

เมธอด [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) กำหนดวิธีที่รูปร่างเดียวกันจะถูกเรนเดอร์เมื่อดูหรือประมวลผลในโหมดขาว‑ดำ ไม่ได้เปิดใช้งานการแสดงผลขาว‑ดำโดยอัตโนมัติและไม่เปลี่ยนการเติม, เส้น, หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเรนเดอร์เลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดําและสีขาว, `Black` และ `White` บังคับสีเดียว, `Color` คงสีปกติ, `Hidden` ไม่แสดงรูปร่างในโหมดขาว‑ดำ, `NotDefined` หมายความว่าไม่ได้กำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) เพื่อเลือกสีเทา งานที่บันทึกจะคงการเติมสีส้มสำหรับการแสดงผลสีปกติและเรียกร้องสีเทาจากแอปพลิเคชันที่เคารพการตั้งค่าการแสดงผลขาว‑ดำ:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ในโหมดสีปกติ, สี่เหลี่ยมคงการเติมสีส้มไว้ ในเวิร์กโฟลว์การแสดงผลขาว‑ดำ, มันใช้สีเทาเนื่องจากโหมดถูกตั้งเป็น `Gray` สิ่งนี้ช่วยให้คุณคงสไลด์สีเต็มในขณะที่กำหนดลักษณะเฉพาะสำหรับการพิมพ์, ดูตัวอย่าง, หรือเวิร์กโฟลว์อื่น ๆ ที่เคารพการตั้งค่าการแสดงผลขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ**

ใช้ [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) เพื่อคืนค่าตำแหน่ง, ขนาด, และการจัดรูปแบบของตารางตำแหน่งบนสไลด์จากตารางตำแหน่งที่สอดคล้องบนเลย์เอาต์ ตัวอย่างนี้ต้องการงานนำเสนอที่มีตารางตำแหน่งเชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตารางตำแหน่งบนเลย์เอาต์จะไม่ถูกรีเซ็ต

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างส่งผลต่อขนาดไฟล์งานนำเสนอขั้นสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟกต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังอยู่ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพถูกเก็บในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างในสไลด์ที่มีการจัดรูปแบบเดียวกันเพื่อทำเป็นกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง – การเติม, เส้น, และการตั้งค่าเอฟเฟกต์ หากค่าที่สอดคล้องกันทั้งหมดตรงกัน ถือว่ารูปลักษณ์เหมือนกันและสามารถจัดกลุ่มนั้นได้ ซึ่งช่วยลดความซับซ้อนของการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์เดกหรือไฟล์ .POTX จากนั้นเมื่อสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์ต้องการ, และนำการจัดรูปแบบไปใช้ตามที่ต้องการ