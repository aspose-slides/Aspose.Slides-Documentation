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
- การเติมสีไล่เฉด
- การเติมลาย
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดรูปแบบรูปร่าง PowerPoint ด้วย JavaScript ผ่าน Aspose.Slides—กำหนดสไตล์การเติม, เส้นและเอฟเฟกต์สำหรับไฟล์ PPT, PPTX และ ODP อย่างแม่นยำและควบคุมเต็มที่"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณสามารถจัดรูปแบบโดยการแก้ไขหรือใช้เอฟเฟกต์กับเส้นขอบของมัน นอกจากนี้ คุณยังสามารถจัดรูปแบบรูปร่างโดยระบุการตั้งค่าที่ควบคุมวิธีการเติมสีภายในของมัน

![รูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides สำหรับ Node.js ผ่าน Java มีคลาสและเมธอดที่ช่วยให้คุณสามารถจัดรูปแบบรูปร่างได้โดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถกำหนดสไตล์เส้นแบบกำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้สรุปกระบวนการ:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linestyle/) ของรูปร่าง
1. ตั้งค่าความกว้างของเส้น
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linedashstyle/) ของเส้น
1. ตั้งค่าสีเส้นสำหรับรูปร่าง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ดต่อไปนี้แสดงวิธีจัดรูปแบบ `AutoShape` รูปสี่เหลี่ยม:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิดสี่เหลี่ยมผืนผ้า
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // ตั้งค่าสีเติมสำหรับรูปร่างสี่เหลี่ยม
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
![เส้นที่จัดรูปแบบในการนำเสนอ](formatted-lines.png)

## **ใช้เอฟเฟกต์สเก็ตช์กับเส้นของรูปร่าง**

เอฟเฟกต์สเก็ตช์ทำให้เส้นของรูปร่างดูเหมือนวาดด้วยมือ ใช้ [Shape.getLineFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) เพื่อเข้าถึงการตั้งค่าเส้น, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/lineformat/) เพื่อเข้าถึงการตั้งค่าสเก็ตช์, และ [SketchFormat.setSketchType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sketchformat/) เพื่อเลือกค่าจาก enumeration ของ [LineSketchType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linesketchtype/)

โค้ด JavaScript ต่อไปนี้แสดงวิธีใช้เอฟเฟกต์ [LineSketchType.Curved](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linesketchtype/) อ่านค่าที่กำหนดโดยตรง และลบเอฟเฟกต์ด้วย [LineSketchType.None](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linesketchtype/):

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // เข้าถึงรูปแบบเส้นของรูปและรูปแบบสเก็ตช์ของมัน.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // ใช้เอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // อ่านเอฟเฟกต์สเก็ตช์ที่กำหนดโดยตรงให้กับรูป.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // ลบเอฟเฟกต์สเก็ตช์.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

ค่าที่คืนจาก [SketchFormat.getSketchType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/sketchformat/) แสดงการตั้งค่าที่กำหนดโดยตรงให้กับรูปร่าง หากการจัดรูปแบบเส้นสามารถสืบทอดจากธีม, มาสเตอร์สไลด์หรือเลย์เอาต์สไลด์ ให้ใช้ [LineFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/lineformat/), เรียก `getSketchFormat` บนวัตถุที่คืนค่า แล้วเรียกเมธอด `getSketchType` ของมัน ค่าที่มีผลจะแสดงการจัดรูปแบบที่นำไปใช้จริงหลังจากการสืบทอดได้รับการแก้ไข:

```js
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

ต่อไปนี้คือสามตัวเลือกประเภทการเชื่อมต่อ:
* Round
* Miter
* Bevel

โดยค่าเริ่มต้น เมื่อ PowerPoint เชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) มันจะใช้การตั้งค่า **Round** อย่างไรก็ตาม หากคุณกำลังวาดรูปร่างที่มีมุมคม คุณอาจต้องการใช้ตัวเลือก **Miter**

![สไตล์การเชื่อมต่อในการนำเสนอ](join-style-powerpoint.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีที่สามสี่เหลี่ยม (ตามที่แสดงในภาพด้านบน) ถูกสร้างโดยใช้การตั้งค่า Miter, Bevel, และ Round:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติ 3 รูปชนิดสี่เหลี่ยมผืนผ้า
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // ตั้งค่าสีเติมสำหรับแต่ละรูปร่างสี่เหลี่ยม
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // ตั้งค่าความกว้างของเส้น
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // ตั้งค่าสีสำหรับเส้นของแต่ละสี่เหลี่ยม
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // ตั้งค่าสไตล์การเชื่อมต่อ
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // เพิ่มข้อความให้แต่ละสี่เหลี่ยม
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมสีไล่เฉด**

ใน PowerPoint การเติมสีไล่เฉดเป็นตัวเลือกการจัดรูปแบบที่ช่วยให้คุณสามารถใช้การผสมสีอย่างต่อเนื่องกับรูปร่าง ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่าซึ่งสีหนึ่งค่อยๆ ฟีดไปยังอีกสีหนึ่ง

ต่อไปนี้คือวิธีการใช้การเติมสีไล่เฉดกับรูปร่างโดยใช้ Aspose.Slides:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient`
1. เพิ่มสีที่คุณต้องการสองสีพร้อมตำแหน่งที่กำหนดโดยใช้เมธอด `add` ของคอลเลกชัน gradient stop ที่เปิดเผยโดยคลาส [GradientFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/gradientformat/)
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิดวงรี
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบไล่เฉดกับวงรี
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // ตั้งค่าทิศทางของไล่เฉด
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // เพิ่มจุดไล่เฉดสองจุด
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // บันทึกไฟล์ PPTX ลงดิสก์
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:
![วงรีที่มีการเติมสีไล่เฉด](gradient-fill.png)

## **การเติมลาย**

ใน PowerPoint การเติมลายเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณสามารถใช้การออกแบบสองสี—เช่น จุด, ลายเส้น, ลายตัดไขว้ หรือการตรวจสอบ—กับรูปร่าง คุณสามารถเลือกสีกำหนดเองสำหรับพื้นหน้าและพื้นหลังของลาย

Aspose.Slides มีลายแบบกำหนดล่วงหน้าเกิน 45 แบบที่คุณสามารถใช้กับรูปร่างเพื่อเพิ่มความสวยงามของการนำเสนอ แม้จะเลือกลายแบบกำหนดล่วงหน้าแล้ว คุณยังสามารถระบุสีที่แน่นอนที่ควรใช้ได้

ต่อไปนี้คือวิธีการใช้การเติมลายกับรูปร่างโดยใช้ Aspose.Slides:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern`
1. เลือกลายแบบจากตัวเลือกกำหนดล่วงหน้า
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/patternformat/#getBackColor--) ของลาย
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/patternformat/#getForeColor--) ของลาย
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิดสี่เหลี่ยมผืนผ้า.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // ตั้งค่าสไตล์ลาย.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้า ของลาย.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:
![สี่เหลี่ยมที่มีการเติมลาย](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ช่วยให้คุณสามารถแทรกรูปภาพภายในรูปร่าง—ทำให้รูปภาพเป็นพื้นหลังของรูปร่าง

ต่อไปนี้คือวิธีใช้ Aspose.Slides เพื่อใช้การเติมรูปภาพกับรูปร่าง:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Picture`
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ)
1. สร้างอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) จากรูปภาพที่ต้องการใช้
1. ส่งรูปภาพไปยังเมธอด `ISlidesPicture.setImage`
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

สมมติว่าเรามีไฟล์ "lotus.png" ที่มีรูปภาพต่อไปนี้:

![รูปภาพบัว](lotus.png)

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิดสี่เหลี่ยมผืนผ้า.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าชนิดการเติมเป็น Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // ตั้งค่าโหมดการเติมรูปภาพ.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรของการนำเสนอ.
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
![รูปร่างที่มีการเติมรูปภาพ](picture-fill.png)

### **ใช้รูปภาพเป็นพื้นผิวแบบกระเบื้อง**

หากต้องการตั้งค่ารูปภาพเป็นพื้นผิวแบบกระเบื้องและปรับพฤติกรรมการกระเบื้อง คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/):
- [setPictureFillMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): ตั้งค่าโหมดการเติมรูปภาพ — `Tile` หรือ `Stretch`
- [setTileAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): กำหนดการจัดแนวของกระเบื้องภายในรูปร่าง
- [setTileFlip](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่ากระเบื้องจะกลับด้านแนวนอน แนวตั้ง หรือทั้งสองด้าน
- [setTileOffsetX](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): ตั้งค่าการเยื้องแนวนอนของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง
- [setTileOffsetY](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): ตั้งค่าการเยื้องแนวตั้งของกระเบื้อง (หน่วย points) จากจุดกำเนิดของรูปร่าง
- [setTileScaleX](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของกระเบื้องเป็นเปอร์เซ็นต์
- [setTileScaleY](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของกระเบื้องเป็นเปอร์เซ็นต์

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก.
    let firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมผืนผ้า.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปร่างเป็น Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // โหลดภาพและเพิ่มลงในทรัพยากรของการนำเสนอ.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปร่าง.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการกระเบื้อง.
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
![ตัวเลือกการกระเบื้อง](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมรูปร่างด้วยสีเดียวที่สม่ำเสมอ พื้นหลังสีเดียวนี้ถูกนำไปใช้โดยไม่มีการไล่สี, พื้นผิวหรือลายใดๆ

เพื่อใช้การเติมสีทึบกับรูปร่างโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Solid`
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิดสี่เหลี่ยมผืนผ้า.
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
![รูปร่างที่มีการเติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีทึบ, ไล่เฉด, รูปภาพหรือพื้นผิวกับรูปร่าง คุณยังสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม ค่าความโปร่งใสที่สูงทำให้รูปร่างดูโปร่งมากขึ้นและทำให้พื้นหลังหรือวัตถุตามหลังมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าระดับความโปร่งใสโดยปรับค่า alpha ในสีที่ใช้สำหรับการเติม วิธีทำ:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) เป็น `Solid`
1. ใช้ `Color` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส)
1. บันทึกการนำเสนอ

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมผืนผ้าแบบทึบ.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งใสเหนือรูปร่างทึบ.
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
![รูปร่างที่โปร่งใส](shape-transparency.png)

## **หมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งเป็นประโยชน์เมื่อต้องการจัดตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือการออกแบบที่เฉพาะเจาะจง

เพื่อหมุนรูปร่างบนสไลด์ทำตามขั้นตอนต่อไปนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ตั้งค่าคุณสมบัติการหมุนของรูปร่างเป็นมุมที่ต้องการ
1. บันทึกการนำเสนอ

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์การนำเสนอ.
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก.
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิดสี่เหลี่ยมผืนผ้า.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่างโดย 5 องศา.
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:
![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์บีเวล 3 มิติกับรูปร่างโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/)

เพื่อเพิ่มเอฟเฟกต์บีเวล 3 มิติให้กับรูปร่างทำตามขั้นตอนต่อไปนี้:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. กำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/) ของรูปร่างเพื่อกำหนดการตั้งค่าบีเวล
1. บันทึกการนำเสนอ

```js
// สร้างอินสแตนซ์ของคลาส Presentation.
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

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:
![เอฟเฟกต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides อนุญาตให้คุณใช้เอฟเฟกต์การหมุน 3 มิติกับรูปร่างโดยกำหนดคุณสมบัติของ [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/)

เพื่อใช้การหมุน 3 มิติกับรูปร่าง:
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
1. ใช้ [setCameraType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3 มิติ
1. บันทึกการนำเสนอ

```js
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

    // บันทึกการนำเสนอเป็นไฟล์ PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:
![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ด้านล่างแสดงวิธีรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาดและการจัดรูปแบบของทุกรูปร่างที่มีตัวยึดบน [LayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) ไปยังการตั้งค่าเริ่มต้น:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // รีเซ็ตแต่ละรูปร่างบนสไลด์ที่มีตัวยึดในเลย์เอาต์.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างทำให้ขนาดไฟล์การนำเสนอสุดท้ายเปลี่ยนแปลงหรือไม่?**

ผลกระทบเพียงเล็กน้อย ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ขณะที่พารามิเตอร์ของรูปร่างเช่นสี, เอฟเฟกต์และไล่เฉดถูกเก็บเป็นเมทาดาต้าและเพิ่มขนาดไฟล์เกือบไม่มี

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—การเติม, เส้นและการตั้งค่าเอฟเฟกต์ หากค่าตรงกันทั้งหมด ให้ถือว่าแบบของมันเหมือนกันและจัดกลุ่มรูปร่างเหล่านั้นแบบตรรกะ ซึ่งทำให้ง่ายต่อการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างที่กำหนดเองเป็นไฟล์แยกเพื่อใช้ซ้ำในงานนำเสนออื่นได้หรือไม่?**

ทำได้ ให้เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในเทมเพลตสไลด์เด็คหรือไฟล์เทมเพลต .POTX เมื่อต้องการสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลต, คัดลอกรูปร่างที่สไตล์พร้อมใช้ และนำการจัดรูปแบบกลับมาใช้ตามต้องการ