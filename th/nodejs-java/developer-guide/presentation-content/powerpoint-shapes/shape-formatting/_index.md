---
title: จัดรูปแบบรูปร่าง PowerPoint ด้วย JavaScript
linktitle: การจัดรูปแบบรูปร่าง
type: docs
weight: 20
url: /th/nodejs-java/shape-formatting/
keywords:
- จัดรูปแบบรูปร่าง
- จัดรูปแบบเส้น
- จัดรูปแบบสไตล์การเชื่อมต่อ
- การเติมสีไล่เฉด
- การเติมลายแบบ
- การเติมรูปภาพ
- การเติมพื้นผิว
- การเติมสีทึบ
- ความโปร่งใสของรูปร่าง
- หมุนรูปร่าง
- เอฟเฟกต์บีเวล 3 มิติ
- เอฟเฟกต์การหมุน 3 มิติ
- รีเซ็ตการจัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดรูปแบบรูปร่าง PowerPoint ด้วย JavaScript ผ่าน Aspose.Slides—ตั้งค่าการเติม, เส้นและสไตล์เอฟเฟกต์สำหรับไฟล์ PPT, PPTX และ ODP ด้วยความแม่นยำและการควบคุมเต็มรูปแบบ"
---
## **บทนำ**

ใน PowerPoint คุณสามารถเพิ่มรูปร่างลงในสไลด์ได้ เนื่องจากรูปร่างประกอบด้วยเส้น คุณสามารถจัดรูปแบบได้โดยการแก้ไขหรือใช้เอฟเฟกต์กับเส้นขอบของมัน นอกจากนี้คุณยังสามารถจัดรูปแบบรูปร่างโดยกำหนดการตั้งค่าที่ควบคุมวิธีการเติมภายในของรูปร่าง

![การจัดรูปแบบรูปร่างใน PowerPoint](format-shape-powerpoint.png)

Aspose.Slides สำหรับ Node.js ผ่าน Java ให้คลาสและเมธอดที่ช่วยให้คุณสามารถจัดรูปแบบรูปร่างโดยใช้ตัวเลือกเดียวกับที่มีใน PowerPoint

## **จัดรูปแบบเส้น**

โดยใช้ Aspose.Slides คุณสามารถกำหนดรูปแบบเส้นแบบกำหนดเองสำหรับรูปร่าง ขั้นตอนต่อไปนี้อธิบายกระบวนการ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่า [line style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linestyle/) ของรูปร่าง .
1. ตั้งค่าความกว้างของเส้น .
1. ตั้งค่า [dash style](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/linedashstyle/) ของเส้น .
1. ตั้งค่าสีของเส้นสำหรับรูปร่าง .
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX .

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการจัดรูปแบบ [AutoShape] สี่เหลี่ยม:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิด Rectangle
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

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เส้นที่จัดรูปแบบในงานนำเสนอ](formatted-lines.png)

## **จัดรูปแบบการเชื่อมต่อของเส้น**

นี่คือสามตัวเลือกประเภทการเชื่อมต่อ:

* โค้ง
* มิตเตอร์
* บีเวล

โดยค่าเริ่มต้นเมื่อ PowerPoint เชื่อมสองเส้นที่มุม (เช่นที่มุมของรูปร่าง) จะใช้การตั้งค่า **โค้ง** อย่างไรก็ตาม หากคุณกำลังวาดรูปร่างที่มีมุมคม คุณอาจต้องการตัวเลือก **มิตเตอร์** 

![รูปแบบการเชื่อมต่อในงานนำเสนอ](join-style-powerpoint.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีการสร้างสี่เหลี่ยมสามรูป (ตามภาพด้านบน) โดยใช้การตั้งค่าการเชื่อมต่อแบบมิตเตอร์, บีเวลและโค้ง:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสามรูปแบบ Rectangle
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

    // เพิ่มข้อความในแต่ละสี่เหลี่ยม
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การเติมสีไล่เฉด**

ใน PowerPoint การเติมสีไล่เฉดเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณสามารถใช้การผสมสีต่อเนื่องกับรูปร่างได้ ตัวอย่างเช่น คุณสามารถใช้สองสีหรือมากกว่านั้นโดยสีหนึ่งค่อยๆ จางไปสู่สีอีกสีหนึ่ง

วิธีการใช้การเติมสีไล่เฉดกับรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Gradient` .
1. ใช้วิธี `add` ของคอลเล็กชัน gradient stop ที่เปิดเผยโดยคลาส [GradientFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/gradientformat/) เพื่อเพิ่มสองสีที่คุณต้องการพร้อมตำแหน่งที่กำหนด .
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX .

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใช้เอฟเฟกต์การเติมสีไล่เฉดกับวงรี:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Ellipse
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // ใช้การจัดรูปแบบแบบไล่สีกับวงรี
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // ตั้งค่าทิศทางของการไล่สี
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // เพิ่มจุดหยุดไล่สีสองจุด
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![วงรีที่มีการเติมสีไล่เฉด](gradient-fill.png)

## **การเติมลายแบบ**

ใน PowerPoint การเติมลายแบบเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณสามารถใช้การออกแบบสองสี เช่น จุด, 줄무늬, 교차선 หรือ 체크, ไปกับรูปร่าง คุณสามารถเลือกสีพื้นหน้าและพื้นหลังของลายได้ตามต้องการ

Aspose.Slides มีรูปแบบลายที่กำหนดไว้ล่วงหน้ากว่า 45 แบบที่คุณสามารถใช้กับรูปร่างเพื่อเพิ่มความสวยงามให้กับงานนำเสนอของคุณ แม้จะเลือกลายที่กำหนดไว้แล้ว คุณก็ยังสามารถระบุสีที่แน่นอนที่ต้องการให้ใช้ได้

วิธีการใช้การเติมลายกับรูปร่างโดยใช้ Aspose.Slides:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Pattern` .
1. เลือกรูปแบบลายจากตัวเลือกที่กำหนดไว้ล่วงหน้า .
1. ตั้งค่า [Background Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/patternformat/#getBackColor--) ของลาย .
1. ตั้งค่า [Foreground Color](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/patternformat/#getForeColor--) ของลาย .
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX .

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใช้การเติมลายกับสี่เหลี่ยม:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Pattern
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // ตั้งค่าสไตล์ลายแบบ
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // ตั้งค่าสีพื้นหลังและสีพื้นหน้าของลายแบบ
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สี่เหลี่ยมที่มีการเติมลาย](pattern-fill.png)

## **การเติมรูปภาพ**

ใน PowerPoint การเติมรูปภาพเป็นตัวเลือกการจัดรูปแบบที่ทำให้คุณสามารถแทรกรูปภาพเข้าไปในรูปร่างได้—โดยใช้รูปภาพนั้นเป็นพื้นหลังของรูปร่าง

วิธีการใช้ Aspose.Slides เพื่อเติมรูปภาพในรูปร่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Picture` .
1. ตั้งค่าโหมดการเติมรูปภาพเป็น `Tile` (หรือโหมดอื่นที่ต้องการ) .
1. สร้างอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) จากรูปภาพที่ต้องการใช้ .
1. ส่งรูปภาพไปยังเมธอด `ISlidesPicture.setImage` .
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX .

สมมติว่ามีไฟล์ "lotus.png" พร้อมรูปภาพต่อไปนี้:

![รูปภาพลอตัส](lotus.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีการเติมรูปร่างด้วยรูปภาพ:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // ตั้งค่าชนิดการเติมเป็น Picture
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // ตั้งค่าโหมดการเติมรูปภาพ
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // ตั้งค่ารูปภาพ
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่มีการเติมรูปภาพ](picture-fill.png)

### **ใช้รูปภาพต่อเป็นพื้นผิว**

หากคุณต้องการตั้งค่ารูปภาพต่อเป็นพื้นผิวและปรับแต่งพฤติกรรมการต่อ คุณสามารถใช้เมธอดต่อไปนี้ของคลาส [PictureFillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): กำหนดโหมดการเติมรูปภาพ — `Tile` หรือ `Stretch` .
- [setTileAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): ระบุตำแหน่งการจัดเรียงของแผ่นต่อภายในรูปร่าง .
- [setTileFlip](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): ควบคุมว่าภาพต่อจะถูกพลิกแนวนอน, แนวตั้ง หรือทั้งสองอย่าง .
- [setTileOffsetX](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): กำหนดค่าการเยื้องแนวนอนของภาพต่อ (หน่วยเป็น points) จากตำแหน่งต้นกำเนิดของรูปร่าง .
- [setTileOffsetY](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): กำหนดค่าการเยื้องแนวตั้งของภาพต่อ (หน่วยเป็น points) จากตำแหน่งต้นกำเนิดของรูปร่าง .
- [setTileScaleX](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): กำหนดสเกลแนวนอนของภาพต่อเป็นเปอร์เซ็นต์ .
- [setTileScaleY](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): กำหนดสเกลแนวตั้งของภาพต่อเป็นเปอร์เซ็นต์ .

โค้ดตัวอย่างต่อไปนี้แสดงวิธีการเพิ่มรูปร่างสี่เหลี่ยมกับการเติมรูปภาพต่อและกำหนดค่าตัวเลือกการต่อ:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let firstSlide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยม
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // ตั้งค่าชนิดการเติมของรูปร่างเป็น Picture
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // โหลดภาพและเพิ่มลงในทรัพยากรของงานนำเสนอ
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // กำหนดภาพให้กับรูปร่าง
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // กำหนดค่าโหมดการเติมรูปภาพและคุณสมบัติการต่อภาพ
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ตัวเลือกการต่อ](tile-options.png)

## **การเติมสีทึบ**

ใน PowerPoint การเติมสีทึบเป็นตัวเลือกการจัดรูปแบบที่เติมสีเดียวอย่างสม่ำเสมอให้กับรูปร่าง สีพื้นหลังเรียบนี้จะถูกนำไปใช้โดยไม่มีการไล่สี, พื้นผิว หรือ ลายใดๆ

เพื่อใช้การเติมสีทึบกับรูปร่างโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปร่างเป็น `Solid` .
1. กำหนดสีเติมที่คุณต้องการให้กับรูปร่าง .
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX .

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใช้การเติมสีทึบกับสี่เหลี่ยมในสไลด์ PowerPoint:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // ตั้งค่าชนิดการเติมเป็น Solid
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // ตั้งค่าสีเติม
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่มีการเติมสีทึบ](solid-color-fill.png)

## **ตั้งค่าความโปร่งใส**

ใน PowerPoint เมื่อคุณใช้การเติมสีทึบ, ไล่เฉด, รูปภาพ หรือพื้นผิวกับรูปร่าง คุณสามารถตั้งค่าระดับความโปร่งใสเพื่อควบคุมความทึบของการเติม ค่าความโปร่งใสที่สูงทำให้รูปร่างดูโปร่งแสงมากขึ้น ทำให้พื้นหลังหรือวัตถุที่อยู่ด้านล่างมองเห็นได้บางส่วน

Aspose.Slides ให้คุณตั้งค่าความโปร่งใสโดยปรับค่าอัลฟ่าในสีที่ใช้สำหรับการเติม วิธีทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่า [FillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) เป็น `Solid` .
1. ใช้ `Color` เพื่อกำหนดสีที่มีความโปร่งใส (ส่วน `alpha` ควบคุมความโปร่งใส) .
1. บันทึกงานนำเสนอ .

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใช้สีเติมที่โปร่งใสกับสี่เหลี่ยม:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมทึบ
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // เพิ่มรูปร่างอัตโนมัติสี่เหลี่ยมโปร่งใสเหนือรูปร่างทึบ
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รูปร่างที่โปร่งใส](shape-transparency.png)

## **การหมุนรูปร่าง**

Aspose.Slides ให้คุณหมุนรูปร่างในงานนำเสนอ PowerPoint ซึ่งอาจเป็นประโยชน์เมื่อต้องจัดตำแหน่งองค์ประกอบภาพตามการจัดแนวหรือความต้องการด้านการออกแบบเฉพาะ

เพื่อหมุนรูปร่างบนสไลด์ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่าคุณสมบัติการหมุนของรูปร่างเป็นมุมที่ต้องการ .
1. บันทึกงานนำเสนอ .

โค้ด JavaScript ต่อไปนี้แสดงวิธีการหมุนรูปร่างด้วยมุม 5 องศา:

```js
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ
let presentation = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างอัตโนมัติชนิด Rectangle
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // หมุนรูปร่างโดย 5 องศา
    shape.setRotation(5);

    // บันทึกไฟล์ PPTX ไปยังดิสก์
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การหมุนรูปร่าง](shape-rotation.png)

## **เพิ่มเอฟเฟกต์บีเวล 3 มิติ**

Aspose.Slides ให้คุณใช้เอฟเฟกต์บีเวล 3 มิติบนรูปร่างโดยกำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/) ของรูปร่าง

เพื่อเพิ่มเอฟเฟกต์บีเวล 3 มิติบนรูปร่างทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ตั้งค่า [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/) ของรูปร่างเพื่อกำหนดค่าบีเวล .
1. บันทึกงานนำเสนอ .

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใช้เอฟเฟกต์บีเวล 3 มิติบนรูปร่าง:

```js
// สร้างอินสแตนซ์ของคลาส Presentation
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // เพิ่มรูปร่างไปยังสไลด์
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // ตั้งค่าคุณสมบัติ ThreeDFormat ของรูปร่าง
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์บีเวล 3 มิติ](3D-bevel-effect.png)

## **เพิ่มเอฟเฟกต์การหมุน 3 มิติ**

Aspose.Slides ให้คุณใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่างโดยกำหนดค่า [ThreeDFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/) ของรูปร่าง

เพื่อใช้การหมุน 3 มิติบนรูปร่างทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
1. รับการอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ .
1. ใช้เมธอด [setCameraType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/camera/#setCameraType) และ [setLightType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/lightrig/#setLightType) เพื่อกำหนดการหมุน 3 มิติ .
1. บันทึกงานนำเสนอ .

โค้ด JavaScript ต่อไปนี้แสดงวิธีการใช้เอฟเฟกต์การหมุน 3 มิติบนรูปร่าง:

```js
// สร้างอินสแตนซ์ของคลาส Presentation
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เอฟเฟกต์การหมุน 3 มิติ](3D-rotation-effect.png)

## **รีเซ็ตการจัดรูปแบบ**

โค้ด Java ต่อไปนี้แสดงวิธีการรีเซ็ตการจัดรูปแบบของสไลด์และคืนค่าตำแหน่ง, ขนาดและการจัดรูปแบบของรูปร่างทั้งหมดที่มี placeholder บน [LayoutSlide](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/layoutslide/) ให้กลับเป็นค่าตั้งต้น:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // รีเซ็ตแต่ละรูปร่างบนสไลด์ที่มี placeholder บน layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**การจัดรูปแบบรูปร่างมีผลต่อขนาดไฟล์ของงานนำเสนอสุดท้ายหรือไม่?**

ผลกระทบค่อนข้างเล็ก ภาพและสื่อที่ฝังอยู่ใช้พื้นที่ส่วนใหญ่ของไฟล์ ส่วนพารามิเตอร์ของรูปร่างเช่นสี, เอฟเฟกต์และการไล่สีจะถูกเก็บเป็นเมตาดาต้าและเพิ่มขนาดไฟล์อย่างน้อยมาก

**ฉันจะตรวจจับรูปร่างบนสไลด์ที่มีการจัดรูปแบบเหมือนกันเพื่อให้สามารถจัดกลุ่มได้อย่างไร?**

เปรียบเทียบคุณสมบัติการจัดรูปแบบหลักของแต่ละรูปร่าง—เช่นการเติม, เส้นและการตั้งค่าเอฟเฟกต์ หากค่าทั้งหมดตรงกันให้ถือว่าสไตล์เหมือนกันและจัดกลุ่มตรรกะของรูปร่างเหล่านั้น ซึ่งช่วยให้ง่ายต่อการจัดการสไตล์ในภายหลัง

**ฉันสามารถบันทึกชุดสไตล์รูปร่างแบบกำหนดเองเป็นไฟล์แยกเพื่อใช้ใหม่ในงานนำเสนออื่นได้หรือไม่?**

สามารถทำได้ ให้เก็บรูปร่างตัวอย่างที่มีสไตล์ที่ต้องการในสไลด์เทมเพลตหรือไฟล์เทมเพลต .POTX เมื่อต้องสร้างงานนำเสนอใหม่ ให้เปิดเทมเพลตและคัดลอกรูปร่างที่ต้องการจากเทมเพลต แล้วนำการจัดรูปแบบของมันไปใช้ใหม่ตามต้องการ