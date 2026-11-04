---
title: "จัดรูปแบบรูปร่าง PowerPoint ใน JavaScript"
linktitle: "การจัดรูปแบบรูปร่าง"
type: docs
weight: 20
url: /th/nodejs-java/shape-formatting/
keywords:
- "จัดรูปแบบรูปร่าง"
- "จัดรูปแบบเส้น"
- "เอฟเฟ็กต์สเก็ตช์"
- "เส้นรูปร่างสเก็ตช์"
- "จัดรูปแบบสไตล์การเชื่อมต่อ"
- "การเติมแบบไล่ระดับสี"
- "การเติมแบบลายเส้น"
- "การเติมด้วยรูปภาพ"
- "การเติมพื้นผิว"
- "การเติมสีทึบ"
- "ความโปร่งใสของรูปร่าง"
- "การเรนเดอร์รูปร่างขาว‑ดำ"
- "การเรนเดอร์รูปร่างระดับสีเทา"
- "หมุนรูปร่าง"
- "เอฟเฟ็กต์ bevel 3 มิติ"
- "เอฟเฟ็กต์การหมุน 3 มิติ"
- "รีเซ็ตการจัดรูปแบบ"
- "PowerPoint"
- "การนำเสนอ"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "เรียนรู้วิธีจัดรูปแบบรูปร่าง PowerPoint ใน JavaScript ด้วย Aspose.Slides—ตั้งค่าการเติม, เส้น, และสไตล์เอฟเฟ็กต์สำหรับไฟล์ PPT และ PPTX อย่างแม่นยำและควบคุมเต็มรูปแบบ."
---
## **บทนำ**

จัดรูปแบบรูปร่างใน PowerPoint โดยปรับเส้นขอบ การเติมสี และเอฟเฟ็กต์ต่าง ๆ Aspose.Slides for Node.js ผ่าน Java ช่วยให้คุณควบคุมการตั้งค่าเหล่านี้ด้วยโปรแกรม รวมถึงความโปร่งใส การหมุน และการจัดรูปแบบ 3D

![ตัวเลือกการจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js ผ่าน Java มีคลาสและเมธอดที่ทำให้คุณสามารถจัดรูปแบบรูปร่างได้โดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) เพื่อควบคุมเส้นขอบของรูปร่าง ตัวอย่างนี้สร้างสี่เหลี่ยมผืนผ้าไม่มีการเติมสีที่มีเส้นขอบสีฟ้าประดับเส้นประ [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) เลือกเส้นแบบคอมพาวนด์หนาบาง ในขณะที่ [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) ตั้งความกว้างเป็น 7 จุดและ [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) เลือกรูปแบบจุดประแทน

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

### **กำหนดรูปแบบจุดประแทนของเส้นแบบกำหนดเอง**

ใช้ [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern) เมื่อรูปแบบเส้นที่กำหนดไว้ล่วงหน้าไม่สามารถให้ความยาวของจุดและช่องว่างที่ต้องการได้ เช่น สำหรับเส้นขอบตามแบรนด์หรือแผนผังเชิงเทคนิค การกำหนดรูปแบบอัตโนมัติจะเปลี่ยนสไตล์จุดประแทนของเส้นเป็น [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/)

รายการในอาร์เรย์สลับระหว่างความยาวของจุดและช่องว่าง เริ่มจากจุด แต่ละค่าจะเป็นหลายเท่าของความกว้างของเส้น: `[4, 2]` ที่ความกว้าง 3 จุดจะสร้างจุดยาว 12 จุดตามด้วยช่องว่าง 6 จุด ใช้คู่ค่าที่เป็นจำนวนจริง ไม่เป็นลบ เพื่อกำหนดส่วนจุด‑ช่องว่างที่ครบถ้วน ตัวอย่างใช้ค่าบวกเพื่อให้ทุกจุดและช่องว่างมองเห็นได้

ตัวอย่างนี้สร้างเส้นสีฟ้าห้าเส้นที่มีความยาวเท่ากันและหัวเส้นเรียบ แถวแรกสามเส้นเปรียบเทียบรูปแบบที่ความกว้าง 3 จุด แถวที่สี่ทำซ้ำรูปแบบแรกที่ความกว้างสองเท่า ทำให้จุดและช่องว่างเพิ่มขึ้นเป็นสองเท่า แถวที่ห้าสลับจากรูปแบบกำหนดเองเป็นเส้นทึบ

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

    // เปลี่ยนเส้นสุดท้ายให้เป็นสไตล์ทึบ.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หากต้องการกลับไปใช้สไตล์จุดประแทนที่กำหนดไว้ล่วงหน้า ให้ส่งค่า [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) ไปยัง [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) สไตล์ที่เลือกจะควบคุมลักษณะของเส้น

ผลลัพธ์ใน PowerPoint จากบนลงล่าง: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; และ **Solid, 3 pt**.

![สามรูปแบบจุดประแทนกำหนดเอง เส้นกว้างกว่าด้วยรูปแบบแรก และเส้นทึบใน PowerPoint](custom-dash-patterns.png)

### **ตั้งค่าหัวเส้น**

ใช้ [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) เพื่อตั้งค่าหัวของเส้นเปิด คลาส [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) มีสามสไตล์หัวที่กำหนดอย่างชัดเจน:

- `Flat`: เส้นหยุดที่จุดปลาย
- `Round`: หัวกึ่งวงกลมต่อจากจุดปลายออกไปครึ่งความกว้างของเส้น
- `Square`: หัวสี่เหลี่ยมต่อจากจุดปลายออกไปครึ่งความกว้างของเส้น

คลาสนี้ยังมี `NotDefined` ซึ่งหมายความว่าไม่ได้กำหนดสไตล์หัวโดยชัดเจน

หัวเส้นต่างจากหัวลูกศรที่เพิ่มสัญลักษณ์ที่ปลายเส้นและการเชื่อมต่อที่ควบคุมมุมระหว่างส่วนของเส้น ตัวอย่างนี้ปิดการทำงานของหัวลูกศรด้วย [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) และ [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle) เพื่อให้เปรียบเทียบเฉพาะรูปหัว

ตัวอย่างต่อไปสร้างเส้นแนวนอนสามเส้นที่เหมือนกัน ความกว้าง 20 จุด จากบนลงล่างใช้หัวแบบ `Flat` , `Round` และ `Square` ตามลำดับ จุดปลายของเส้นมีพิกัดแนวนอนเดียวกัน; หัวแบบ `Round` และ `Square` ยืดออกไปอีก 10 จุดจากแต่ละจุดปลาย

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

![หัวเส้นแบบ Flat, Round และ Square บนเส้นหนาแบบเดียวกันใน PowerPoint](line-caps.png)

## **ใช้เอฟเฟ็กต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟ็กต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) เพื่อเลือกค่าจากคลาส [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/)

โค้ด JavaScript ด้านล่างแสดงวิธีใช้เอฟเฟ็กต์ [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยชัดเจน และลบเอฟเฟ็กต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

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

ค่าที่คืนจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม แม่สไลด์ หรือสไลด์เลย์เอาต์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) แล้วเรียก `getSketchFormat` จากอ็อบเจ็กต์ที่ได้ และต่อด้วยเมธอด `getSketchType` ค่าที่ได้จะสะท้อนการจัดรูปแบบที่ใช้จริงหลังจากสืบทอดเสร็จ ตัวอย่างนี้ต้องใช้งานนำเสนอที่มีรูปร่างอย่างน้อยหนึ่งรูปในสไลด์แรกและพิมพ์ค่าทั้งสอง:

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

ตัวเลือกสไตล์การเชื่อมต่อสามแบบคือ:

* Round
* Miter
* Bevel

สไตล์การเชื่อมต่อกำหนดว่าช่วงเส้นขอบสองช่วงมาประชิดที่มุมอย่างไร ใช้ **Round** สำหรับมุมโค้ง, **Miter** สำหรับมุมแหลม, หรือ **Bevel** สำหรับมุมแบน

![สไตล์การเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

ตัวอย่างนี้สร้างสี่เหลี่ยมสีดำสามรูปที่มีเส้นขอบสีฟ้า ความกว้าง 15 จุด ใช้ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) เพื่อกำหนดค่า miter, bevel และ round ของ [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) ตามลำดับ เพื่อเปรียบเทียบการวาดมุม

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

### **จำกัดการเชื่อมต่อ Miter ที่มุมแหลม**

ใช้ [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) ร่วมกับ [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) ตั้งเป็น [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) เพื่อจำกัดระยะที่มุมแหลมสามารถยืดออกได้

ขีดจำกัดคืออัตราส่วนระหว่างระยะห่างของมุมในและนอกของการเชื่อมต่อต่อความกว้างของเส้น ตัวอย่างเช่น ค่า `8` อนุญาตให้ความยาวของ miter สูงสุดถึงแปดเท่าของความกว้างเส้น; ค่านี้ไม่ใช่หน่วยจุด หากมุมเกินขีดจำกัด PowerPoint จะใช้การเชื่อมต่อแบบ bevel ที่มุมนั้น ขีดจำกัดที่ใหญ่ขึ้นทำให้จุดมุมคมยิ่งขึ้น การตั้งค่านี้มีผลต่อการเชื่อมต่อ miter เท่านั้นและไม่มีผลต่อการแสดงผลเมื่อมุมอยู่ภายในขีดจำกัดทั้งสอง

ตัวอย่างนี้สร้างสามเหลี่ยมไร้การเติมสีสองรูปที่มีเส้นขอบความกว้าง 20 จุด สามเหลี่ยมซ้ายใช้ขีดจำกัด `2` และด้านขวาใช้ `8` แต่ละสามเหลี่ยมกว้าง 80 จุด สูง 160 จุด ทำให้มุมบนมีอัตราส่วนความยาว miter ต่อความกว้างเส้นประมาณ `4.12` ดังนั้น PowerPoint จะทำให้ยอดซ้ายเป็น bevel และรักษายอดขวาไว้เป็นจุดแหลม

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

ผลลัพธ์ใน PowerPoint: **Miter limit 2** ทางซ้ายและ **miter limit 8** ทางขวา

![ยอดที่ bevel ด้วย miter limit 2 และยอดแหลมด้วย miter limit 8 ใน PowerPoint](miter-limits.png)

## **การเติมด้วยการไล่ระดับสี (Gradient Fill)**

การเติมไล่ระดับสีผสมสีภายในรูปร่าง ตัวอย่างนี้เติมวงรีด้วยไล่ระดับสีเชิงเส้นที่มุม 45 องศาจากสีแดงไปสีม่วงโดยใช้ [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat) วิธี [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) จะใส่จุดสีที่ตำแหน่ง 0 และ 1 ซึ่งเป็นจุดเริ่มและจบของการไล่สี การลบจุดสีที่มีอยู่ก่อนหน้าเพื่อให้ใช้เพียงสองสีนี้เท่านั้น

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

![วงรีที่เติมด้วยการไล่ระดับสี](gradient-fill.png)

หากการไล่ระดับสีแสดงผลแตกต่างในภาพที่ส่งออกเมื่อเทียบกับ PowerPoint ดูที่ [Choose a Gradient Rendering Style](/slides/th/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) คุณสามารถเลือกสไตล์การเรนเดอร์โดยไม่ต้องเปลี่ยนการไล่ระดับสีที่เก็บไว้ในงานนำเสนอ

### **ตั้งค่ามุมของการไล่ระดับสีเชิงเส้น**

ใช้ [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) เพื่อควบคุมการวางแนวของการเติม [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/) มุมวัดเป็นองศาและเพิ่มตามเข็มนาฬิกา: `0` คือจากซ้ายไปขวา, `90` จากบนลงล่าง, `180` จากขวาไปซ้าย, `270` จากล่างขึ้นบน รองรับมุมเป็นเศษส่วน มุมที่อยู่นอกช่วง `[0, 360)` จะถูกปรับเป็นรอบเดียว เช่น `-45` จะกลายเป็น `315` และ `360` จะเป็น `0`

ตัวอย่างนี้สร้างสี่เหลี่ยมหกรูปที่มีจุดสีแดง เขียว และน้ำเงินที่ตำแหน่ง `0`, `0.5`, `1` เหมือนกัน ปิดการสเกลเพื่อให้เปรียบเทียบมุมโดยไม่คำนึงถึงสัดส่วนของสี่เหลี่ยม มุมจากซ้ายไปขวาในแถวแรกคือ `0`, `45`, `90` และแถวที่สองคือ `135`, `180`, `270`

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

![การไล่ระดับสีเชิงเส้นที่ 0, 45, และ 90 องศาในแถวบน, และ 135, 180, 270 องศาในแถวล่าง](linear-gradient-angles.png)

### **สเกลการไล่ระดับสีเชิงเส้นตามรูปร่าง**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) รับค่า [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/) ตั้งค่าเป็น `False` อย่างชัดเจนเพื่อคงมุมการไล่สีเชิงเรขาคณิตเมื่อรูปร่างเปลี่ยนสัดส่วน หรือตั้งเป็น `True` เพื่อสเกลการไล่สีตามความกว้างและความสูงของรูปร่าง หากเปิดสเกล มุมที่มองเห็นอาจแตกต่างจากมุมที่กำหนดไว้บนรูปร่างที่ไม่เป็นสี่เหลี่ยมจัตุรัส

ตัวอย่างต่อไปใช้มุม `45` องศาและจุดสีเดียวกันกับการเปรียบเทียบมุม คอลัมน์ซ้ายตั้งค่า `False`; คอลัมน์ขวาตั้งค่า `True` แต่ละคอลัมน์มีสี่เหลี่ยมกว้างด้านบนและสี่เหลี่ยมสูงด้านล่าง ทั้งสองเริ่มจากขนาดกว้างเดียวกัน; การเปลี่ยนแปลงความกว้างและความสูงของสี่เหลี่ยมที่สองแสดงว่าการเติมตอบสนองต่อการปรับขนาดอย่างไรโดยไม่ต้องเปลี่ยนการตั้งค่าไล่สี

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

ผลลัพธ์ใน PowerPoint โดยปิดสเกลด้านซ้ายและเปิดสเกลด้านขวา:

![สี่เหลี่ยมกว้างและสี่เหลี่ยมสูงที่มีไล่สี 45 องศา, เปรียบเทียบ LinearGradientScaled False ด้านซ้ายกับ True ด้านขวา](linear-gradient-scaling.png)

เมื่อสเกลปิด, แถบสีแนวทแยงจะคงทิศทางเดียวกันในทั้งสองสี่เหลี่ยม; เมื่อสเกลเปิด, แถบสีจะขยายตามสัดส่วนของรูปร่าง ช่วยให้ทำสำเนาไล่สีของเทมเพลตเมื่อปรับรูปร่างเป็นขนาดอื่น ๆ บนสี่เหลี่ยมจัตุรัส การเปิดสเกลจะไม่เปลี่ยนลักษณะของไล่สี `45` องศานี้

มุมและการสเกลใช้ได้กับการไล่ระดับสีเชิงเส้นเท่านั้น ไม่ได้ควบคุมการเติม [GradientShape.Radial หรือ GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/)

### **ผสานมุมกับทิศทางการไล่ระดับสี**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) เลือกสไตล์การไล่สีจากคลาส [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/) ไม่ใช่การแทนที่มุมเชิงตัวเลข สำหรับการไล่ระดับสีเชิงเส้น ทิศทางของมุมสามารถเปลี่ยนพื้นที่ที่สีกระจายโดยไม่ต้องเปลี่ยนมุมที่กำหนดผ่าน [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) ให้คงทิศทางเดิมเมื่อเปรียบเทียบมุมหรือสเกล

ตัวอย่างนี้ใช้การตั้งค่าเดียวกันแต่สั่งลำดับกันกลับกัน สี่เหลี่ยมสองรูปจะแสดงผลเดียวกัน: การกำหนดทิศทางก่อนหรือหลังมุมจะไม่เปลี่ยนผลลัพธ์

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

## **การเติมแบบลายเส้น (Pattern Fill)**

การเติมแบบลายเส้นใช้การออกแบบสองสี เช่น จุด, ลายแถบ หรือการตรวจสอบ ตัวอย่างนี้ใช้ [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) เลือกลายเส้น trellis. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) กำหนดสีพื้นหลังเทาที่อ่อน, และ [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) กำหนดสีลายเป็นสีเหลือง

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

![สี่เหลี่ยมที่เติมด้วยลายเส้น](pattern-fill.png)

## **การเติมด้วยรูปภาพ (Picture Fill)**

การเติมด้วยรูปภาพใช้ภาพภายในรูปร่าง ตัวอย่างนี้ต้องการภาพในเครื่องและใช้ [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) เพื่อโหลดเข้าคอลเลกชันรูปภาพของงานนำเสนอ ตั้งค่า [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) เป็นโหมดกระเบื้องเพื่อทำซ้ำภาพภายในสี่เหลี่ยม ภาพต้นฉบับที่ใช้แสดงด้านล่าง:

![รูปดอกบัว](lotus.png)

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

![รูปร่างที่เติมด้วยรูปภาพ](picture-fill.png)

### **ตั้งค่ารูปภาพเป็นกระเบื้องเป็นพื้นผิว (Tile Picture As Texture)**

หากต้องการตั้งรูปภาพเป็นกระเบื้องเป็นพื้นผิวและปรับพฤติกรรมการกระเบื้อง สามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): กำหนดโหมดการเติมรูปภาพ—`Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุตำแหน่งการจัดแนวของกระเบื้องภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมการพลิกกระเบื้องแนวนอน แนวตั้ง หรือทั้งสองอย่าง
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): กำหนดระยะชิดซ้าย‑ขวาของกระเบื้อง (หน่วยจุด) จากจุดเริ่มของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): กำหนดระยะชิดบน‑ล่างของกระเบื้อง (หน่วยจุด) จากจุดเริ่มของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

ตัวอย่างนี้ต้องการภาพในเครื่องและกำหนดค่า [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) ให้ทำซ้ำที่ขนาด 50 % ของขนาดเดิม การชิดลบ `−32` จุดทำให้กระเบื้องเลื่อนแนวนอนและแนวตั้ง; การจัดแนวด้านล่าง‑ขวาและการพลิกทิศทั้งสองกำหนดวิธีการจัดเรียงพื้นผิวที่ทำซ้ำ

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

![ตัวเลือกกระเบื้อง](tile-options.png)

## **การเติมสีทึบ (Solid Color Fill)**

การเติมสีทึบทำให้รูปร่างมีสีเดียวที่สม่ำเสมอ ตัวอย่างนี้ใช้ [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) เลือกโหมดการเติมสีทึบและกำหนดสีเหลืองผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) จากนั้นบันทึกสี่เหลี่ยมลงในงานนำเสนอ

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

![รูปร่างที่เติมสีทึบ](solid-color-fill.png)

## **ใช้พื้นหลังของสไลด์เป็นการเติมของรูปร่าง**

ใช้ [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill) เมื่อรูปร่างควรตรงกับพื้นหลังของสไลด์ เช่น ในเทมเพลตงานนำเสนอ ใช้ [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) ตั้งค่าเป็น [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) ก่อนเพื่อเอาการเติมที่กำหนดไว้ลบออก ด้วยการผสมนี้ รูปร่างจะใช้พื้นหลังของสไลด์แทนการเติมสไตล์ของมันเอง การเปิดค่าสถานะนี้อย่างเดียวไม่ทำให้การเติมที่กำหนดอยู่ก่อนหน้าถูกลบ

นี่แตกต่างจาก [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): การเติมพื้นหลังจะครอบออบเจกต์ที่อยู่หลังรูปร่างด้วยพื้นที่พื้นหลังของสไลด์ที่สอดคล้องกัน ส่วนไม่มีการเติมจะทำให้ออบเจกต์เหล่านั้นมองเห็นได้ การไล่ระดับสีจะยังคงสอดคล้องกับสไลด์แทนที่จะเริ่มใหม่ภายในแต่ละรูปร่าง

ตัวอย่างต่อไปสร้างพื้นหลังแม่ที่สืบทอดโดยสไลด์และวางแถบสีชมพูเมเจนต้าอยู่ด้านหลังสี่เหลี่ยมสามรูป สี่เหลี่ยมซ้ายใช้พื้นหลัง, สี่เหลี่ยมกลางไม่มีการเติม, และสี่เหลี่ยมขวาสลับจากการเติมพื้นหลังไปเป็นการเติมสีส้มที่กำหนดเอง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // สืบทอดการไล่ระดับสีจากมาสเตอร์.
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

    // ปิดการเติมพื้นหลังก่อนที่จะใช้การเติมแบบกำหนดเอง.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์จากซ้ายไปขวา: **การเติมพื้นหลัง**, **ไม่มีการเติม**, และ **การเติมแบบกำหนดเอง** แถบสีชมพูเมเจนต้าถูกซ่อนโดยสี่เหลี่ยมซ้ายและขวาแต่ยังมองเห็นได้ผ่านสี่เหลี่ยมกลาง

![การเติมพื้นหลัง, ไม่มีการเติม และการเติมสีส้มแบบกำหนดเองบนแถบสีเมเจนต้า](background-fill.png)

พฤติกรรมเดียวกันใช้กับพื้นหลังที่กำหนดโดยตรงบนสไลด์หรือสืบทอดจากเลย์เอาต์ รูปร่างใช้พื้นหลังที่แก้ไขแล้วของสไลด์; ตัวอย่างนี้ไม่กำหนดพื้นหลังของสไลด์และเลย์เอาต์เพื่อให้แม่เป็นผู้จัดหา

## **กำหนดความโปร่งใส (Set Transparency)**

สำหรับการเติมสีทึบ ค่าตัวส่วน α ของสีกำหนดความทึบ: 0 คือโปร่งใสเต็ม, 255 คือทึบเต็ม ตัวอย่างนี้ใช้ค่าตัวส่วน α 128 สำหรับสี่เหลี่ยมสีเหลือง ทำให้โปร่งใสประมาณ 50 % เพื่อให้สี่เหลี่ยมด้านล่างมองเห็นได้ สีถูกกำหนดผ่าน [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)

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

## **หมุนรูปร่าง (Rotate Shapes)**

ใช้ [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) เพื่อหมุนรูปร่างในระนาบสไลด์ มุมวัดเป็นองศา; ตัวอย่างนี้หมุนสี่เหลี่ยม 5 องศาตามเข็มนาฬิกาและบันทึกงานนำเสนอ

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

![การหมุนของรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟ็กต์ Bevel 3 มิติ (Add 3D Bevel Effects)**

ใช้ [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) เพื่อให้รูปร่างมีความลึกและขอบ bevel ตัวอย่างนี้สร้างวงรีสีเขียวที่มีขอบสีส้ม ใช้ [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) ตั้งความลึกเป็น 4 จุด และใช้ [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop) ทำ bevel ด้านบนเป็นรูปวงกลมที่มีความกว้างและความสูง 6 จุด กล้องแบบออร์โธกราฟิกที่หันหน้าและแสงสามจุดทำให้ bevel มองเห็นได้

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

![เอฟเฟ็กต์ bevel 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟ็กต์การหมุน 3 มิติ (Add 3D Rotation Effects)**

การมองเห็น 3 มิติของรูปร่างควบคุมโดยการตั้งค่ากล้อง ตัวอย่างนี้ใช้ [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) ตั้งค่ามุมละติจูด, ลองจิจูด, และการปั่นที่ 40, 35, และ 20 องศา ตามลำดับ เลือกกล้องไอโซเมทริกผ่าน [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) และแสงสมดุลผ่าน [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType) จากนั้นบันทึกสี่เหลี่ยมที่จัดรูปแบบ

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

![เอฟเฟ็กต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **ควบคุมการเรนเดอร์ขาว‑ดำสำหรับรูปร่าง (Control Black-and-White Rendering for Shapes)**

เมธอด [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) กำหนดว่ารูปร่างแต่ละอันจะเรนเดอร์อย่างไรเมื่อดูหรือประมวลผลงานนำเสนอในโหมดขาว‑ดำ มันไม่ได้เปิดการแสดงผลขาว‑ดำด้วยตัวเองและไม่เปลี่ยนการเติม, เส้น หรือการจัดรูปแบบอื่น ๆ ของรูปร่างในโหมดสีปกติ

ใช้ค่าจากคลาส [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) เพื่อเลือกพฤติกรรมที่ต้องการ ตัวอย่างเช่น `Automatic` ให้แอปพลิเคชันเลือกการแปลง, `Gray` และ `LightGray` ใช้สีเทา, `BlackWhite` ใช้เฉพาะสีดำและสีขาว, `Black` และ `White` บังคับสีเดียว, `Color` รักษาสีปกติ, และ `Hidden` ลบรูปทรงในโหมดขาว‑ดำ `NotDefined` หมายถึงไม่มีการกำหนดโหมดระดับรูปร่าง

ตัวอย่างนี้สร้างสี่เหลี่ยมสีส้มและใช้ [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) เลือกสีเทา รูปร่างที่บันทึกจะคงสีส้มสำหรับการแสดงผลสีปกติและขอให้แอปพลิเคชันที่รองรับการแสดงผลขาว‑ดำใช้สีเทา:

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

ในโหมดสีปกติ สี่เหลี่ยมคงสีส้มไว้ ในกระบวนการแสดงผลขาว‑ดำ มันจะใช้สีเทาเพราะโหมดตั้งเป็น `Gray` ช่วยให้คุณคงสไลด์สีเต็มขณะกำหนดลักษณะเฉพาะสำหรับการพิมพ์, การดูตัวอย่าง หรือกระบวนการอื่น ๆ ที่เคารพการตั้งค่าการแสดงผลขาว‑ดำของงานนำเสนอ

## **รีเซ็ตการจัดรูปแบบ (Reset Formatting)**

ใช้ [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) เพื่อคืนค่าตำแหน่ง, ขนาด, และรูปแบบของตัวแปรตำแหน่งที่วางของสไลด์จากตัวแปรตำแหน่งที่วางของเลย์เอาต์ที่สอดคล้องกัน ตัวอย่างนี้ต้องมีงานนำเสนอที่มีตัวแปรตำแหน่งที่วางเชื่อมโยงกับเลย์เอาต์และรีเซ็ตทุกสไลด์ก่อนบันทึก รูปร่างที่ไม่มีตัวแปรตำแหน่งที่วางที่สอดคล้องกันจะไม่ถูกรีเซ็ต

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

## **คำถามที่พบบ่อย (FAQ)**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์งานนำเสนอสุดท้ายหรือไม่?**

สี, สไตล์เส้น, และการตั้งค่าเอฟเฟ็กต์โดยทั่วไปเพิ่มข้อมูลเพียงเล็กน้อยเมื่อเทียบกับภาพและสื่อที่ฝังไว้ การเติมรูปภาพอาจเพิ่มขนาดไฟล์เนื่องจากภาพถูกเก็บไว้ในงานนำเสนอ

**ฉันจะตรวจจับรูปร่างในสไลด์ที่มีรูปแบบการจัดรูปแบบเดียวกันเพื่อทำการกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติกุญแจของการจัดรูปแบบแต่ละรูปร่าง—การเติม, เส้น, และการตั้งค่าเอฟเฟ็กต์ หากค่าทุกค่าแมตช์กัน ให้ถือว่ารูปร่างมีสไตล์เดียวกันและจัดกลุ่มตรรกะเพื่อจัดการสไตล์ในภายหลังได้ง่ายขึ้น

**ฉันสามารถบันทึกชุดสไตล์รูปร่างกำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ได้. เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์หรือไฟล์เทมเพลต .POTX เมื่อต้องการสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์แล้วและนำไปใช้ใหม่ตามต้องการ.