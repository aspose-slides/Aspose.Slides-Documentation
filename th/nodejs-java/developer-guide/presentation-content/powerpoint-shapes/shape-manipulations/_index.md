---
title: จัดการรูปร่างพรีเซนเทชันใน JavaScript
linktitle: การจัดการรูปร่าง
type: docs
weight: 40
url: /th/nodejs-java/shape-manipulations/
keywords:
- รูปร่าง PowerPoint
- รูปร่างพรีเซนเทชัน
- รูปร่างบนสไลด์
- ค้นหารูปร่าง
- คัดลอกรูปร่าง
- ลบรูปร่าง
- ซ่อนรูปร่าง
- เปลี่ยนลำดับรูปร่าง
- รับ Interop Shape ID
- ข้อความแทนของรูปร่าง
- รูปแบบการจัดวางรูปร่าง
- รูปร่างเป็น SVG
- แปลงรูปร่างเป็น SVG
- จัดแนวรูปร่าง
- พลิกรูปร่าง
- PowerPoint
- พรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, คัดลอก, ลบ, ซ่อน, จัดลำดับใหม่, ส่งออก, จัดแนว, และพลิกรูปร่างพรีเซนเทชันด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **Overview**

Aspose.Slides for Node.js via Java แสดงรูปร่างบนสไลด์เป็น [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) ที่จัดลำดับไว้แล้ว คอลเลกชันนี้เป็นทั้งที่คุณค้นหาและแก้ไขรูปร่าง รวมถึงเป็นแหล่งที่มาของลำดับการซ้อนกัน: ดัชนี `0` คือรูปร่างที่อยู่ลึกสุดด้านหลัง ส่วนดัชนีสุดท้ายคือรูปร่างที่อยู่ด้านหน้า

บทความนี้ตามโมเดลนั้น โดยอธิบายวิธีระบุรูปร่างอย่างแม่นยำก่อน แล้วแสดงวิธีคัดลอก, ลบ, ซ่อน, และจัดลำดับใหม่ของรูปร่าง ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออกเป็น SVG, การจัดแนว, และการตั้งค่าการพลิก รูปแบบแต่ละตัวเป็นอิสระกัน คุณจึงสามารถใช้เฉพาะการดำเนินการที่จำเป็นต่อเวิร์กโฟลว์ของคุณได้

## **Identify and Find Shapes**

ดัชนีในคอลเลกชันสะดวกเมื่อประมวลผลไฟล์ที่ทราบล่วงหน้า แต่ไม่ได้เป็นตัวระบุที่คงที่ การเพิ่ม, ลบ, หรือจัดลำดับใหม่ของรูปร่างอาจทำให้ดัชนีเปลี่ยน เลือกตัวระบุตามวิธีการสร้างและการดูแลพรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getname/) มีประโยชน์สำหรับเทมเพลตที่นักพัฒนาควบคุมและง่ายต่อการตรวจสอบใน **Selection Pane** ของ PowerPoint สามารถแก้ไขได้และไม่ได้รับประกันว่าจะเป็นค่าที่ไม่ซ้ำกัน ดังนั้นจึงควรกำหนดแนวทางการตั้งชื่อหากโค้ดต้องพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getalternativetext/) มีประโยชน์เมื่อมีคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วเพื่อระบุรูปร่าง มันจะแสดงให้ผู้ใช้เห็น, สามารถแปลหรือแก้ไขเพื่อการเข้าถึงได้, แต่ไม่ได้รับประกันว่าจะเป็นค่าที่ไม่ซ้ำกัน อย่าแปลงข้อความการเข้าถึงที่มีความหมายให้เป็นคีย์ฐานข้อมูลโดยไม่มีการแจ้งเตือน
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) เป็นตัวระบุแบบอ่านอย่างเดียวที่ไม่ซ้ำกันภายในสไลด์หนึ่งและสอดคล้องกับ Shape ID ที่ใช้โดย PowerPoint interop ใช้เมื่อต้องผสานกับ PowerPoint หรือเมื่อต้องการอ้างอิงที่ชัดเจนตลอดช่วงชีพของรูปร่าง รูปร่างที่คัดลอกหรือสร้างใหม่จะได้รับ ID ของตนเอง

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getuniqueid/) ที่เกี่ยวข้องคืนค่าตัวระบุระดับพรีเซนเทชัน แต่ตัวระบุดังกล่าวออกแบบมาสำหรับแอดอินและอาจถูกกำหนดใหม่ ไม่ควรถือเป็นคีย์ภายนอกถาวร หากต้องการเอกลักษณ์ระยะยาว ควรเก็บแมปปิ้งไว้ในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปร่างที่คาดหวังยังคงมีอยู่

ตัวอย่างต่อไปนี้ค้นหาโดยชื่อด้วยการเปรียบเทียบแบบตรงและรายงาน interop ID ระดับสไลด์ เมื่อเทมเพลตไม่มีรูปร่างที่คาดไว้ โค้ดจะแจ้งผลนั้นแทนที่จะดำเนินการต่อกับอ็อบเจ็กต์ที่ผิดพลาด

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var targetShape = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "RevenueChart") {
            targetShape = shape;
            break;
        }
    }

    if (targetShape === null) {
        console.log("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        console.log("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

เมื่อการดำเนินการเฉพาะกับประเภทรูปร่าง ตรวจสอบคลาสรันไทม์ก่อนใช้สมาชิกแบบเฉพาะประเภท ตัวอย่างนี้อัปเดตข้อความและข้อความแทนเมื่ออ็อบเจ็กต์ที่มีชื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    var candidate = null;
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "StatusLabel") {
            candidate = shape;
            break;
        }
    }

    if (candidate !== null && java.instanceOf(candidate, "com.aspose.slides.AutoShape")) {
        candidate.getTextFrame().setText("Approved");
        candidate.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", asposeSlides.SaveFormat.Pptx);
    } else {
        console.log("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **Modify the Shape Collection**

เมธอดเพิ่ม, คัดลอก, ลบ, และจัดลำดับใหม่ทำงานกับคอลเลกชันโดยทันที หากการดำเนินการทำให้จำนวนหรือลำดับของรูปร่างเปลี่ยน อย่าอ้างอิงดัชนีที่จับไว้ก่อนการดำเนินการนั้นต่อไป

### **Clone a Shape**

[addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/addclone/) สร้างสำเนาอิสระและต่อท้ายลงในคอลเลกชันเป้าหมาย [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่วางที่ดัชนี z-order ที่กำหนด ตัวโอเวอร์โหลดที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; ตัวโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างนี้สร้างสไลด์ปลายทาง, คัดลอกสี่เหลี่ยมที่มีป้ายกำกับไปด้านหน้า, และแทรกสำเนาที่สองลงที่ด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาแต่ละอันจะไม่กระทบกับรูปร่างต้นฉบับ

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var sourceSlide = presentation.getSlides().get_Item(0);
    var sourceShape = sourceSlide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    var blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(java.newByte(asposeSlides.SlideLayoutType.Blank));
    var destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    var frontClone = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontClone.setName("FrontClone");
    if (java.instanceOf(frontClone, "com.aspose.slides.AutoShape")) {
        frontClone.getTextFrame().setText("Front clone");
    } else {
        console.log("The front clone is not an AutoShape; its text was not changed.");
    }

    var backClone = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backClone.setName("BackClone");
    if (java.instanceOf(backClone, "com.aspose.slides.AutoShape")) {
        backClone.getTextFrame().setText("Back clone");
    } else {
        console.log("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปร่างรวมถึงชื่อและข้อความแทนด้วย ให้กำหนดตัวระบุตรรกะใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์ การใช้ทรัพยากรของรูปร่างที่ซับซ้อนจะถูกจัดการโดยพรีเซนเทชัน แต่สำเนายังคงเป็นรายการคอลเลกชันใหม่ที่มีอัตลักษณ์รูปร่างใหม่

### **Remove Shapes**

[remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/remove/) ลบอ็อบเจ็กต์รูปร่างเฉพาะออกจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการในระหว่างการทำซ้ำตามดัชนี ให้วนจากท้ายไปข้างหน้าเพื่อให้ดัชนีที่เหลือทั้งหมดยังคงถูกต้อง

ตัวอย่างนี้ลบทุกรูปร่างที่มีชื่อที่กำหนดไว้ มันอ่านรูปร่างที่ดัชนีปัจจุบันและไม่มีการสมมติว่ารูปร่างเป็นประเภทใดประเภทหนึ่ง

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var keepShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    var firstTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    var secondTemporaryShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (var i = slide.getShapes().size() - 1; i >= 0; i--) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "Temporary") {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

หลังการลบ จำนวนรูปร่างและดัชนีของรูปร่างที่ตามมาจะเปลี่ยน การอ้างอิงถึงรูปร่างที่ไม่ได้รับผลกระทบจึงค่อนข้างเชื่อถือได้กว่าเมื่ออ้างอิงดัชนีที่บันทึกไว้ นอกจากนี้ยังต้องพิจารณา connector, animation, และคุณสมบัติพรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงถึงอ็อบเจ็กต์ที่ถูกลบ; การลบรูปร่างที่มองเห็นได้อาจทำให้เปลี่ยนแปลงมากกว่าลักษณะการแสดงผลของสไลด์

### **Hide a Shape**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/sethidden/) เป็น `true` จะทำให้รูปร่างยังคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในการแสดงสไลด์ปกติ ดัชนี, การจัดรูปแบบ, และเนื้อหายังคงพร้อมให้โค้ดใช้งาน ดังนั้นการซ่อนจึงเหมาะกับองค์ประกอบที่เป็นตัวเลือกและอาจถูกเรียกคืนในภายหลัง

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var visibleShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    var optionalShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (var i = 0; i < slide.getShapes().size(); i++) {
        var shape = slide.getShapes().get_Item(i);
        if (shape.getName() === "OptionalDecoration") {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การซ่อนไม่ใช่การลบหรือการรักษาความปลอดภัย อ็อบเจ็กต์ยังคงถูกค้นพบและสามารถทำให้แสดงใหม่ได้โดยผู้ใช้หรือโค้ด และยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **Change the Z-Order**

รูปร่างที่ทับซ้อนกันจะถูกวาดตามลำดับในคอลเลกชัน [reorder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/reorder/) ย้ายรูปร่างที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ต้องคัดลอก ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var blueRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    blueRectangle.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    var orangeEllipse = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(java.newByte(asposeSlides.FillType.Solid));
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

สี่เหลี่ยมถูกสร้างก่อนและเริ่มต้นอยู่เบื้องหลังวงรี การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า ควรสรุปลำดับ z-order หลังจากเพิ่มหรือคัดลอกรูปร่างที่เกี่ยวข้องทั้งหมด เพราะการดำเนินการเหล่านั้นจะต่อหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนลำดับที่ตั้งใจไว้

## **Inspect Shapes on Layout Slides**

สไลด์ปกติ, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์มีคอลเลกชันรูปร่างแยกกัน รูปร่างในคอลเลกชันเลย์เอาต์ไม่ใช่วัตถุเดียวกับรูปร่างที่อยู่ในตำแหน่งเดียวกันบนสไลด์ปกติ ตรวจสอบรูปร่างในเลย์เอาต์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนแปลงการจัดรูปแบบที่มาจากเลย์เอาต์

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getfillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getlineformat/) ของแต่ละรูปร่างในเลย์เอาต์โดยไม่สมมติว่าทุกรูปร่างเป็น `AutoShape`

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    for (var i = 0; i < presentation.getLayoutSlides().size(); i++) {
        var layoutSlide = presentation.getLayoutSlides().get_Item(i);
        for (var j = 0; j < layoutSlide.getShapes().size(); j++) {
            var shape = layoutSlide.getShapes().get_Item(j);
            var fillType = shape.getFillFormat().getFillType();
            var lineWidth = shape.getLineFormat().getWidth();
            console.log(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

การแก้ไขเลย์เอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้เลย์เอาต้นนั้น ก่อนเปลี่ยนรูปร่างในเลย์เอาต์ ให้ตรวจสอบว่าสไลด์ปกติสืบทอดอ็อบเจ็กต์นั้นหรือมีการกำหนดทับในระดับท้องถิ่น และทดสอบทุกสไลด์ที่ใช้เลย์เอาต์นั้นด้วย

## **Export a Shape to SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) จะเขียนเนื้อหาที่เรนเดอร์ของรูปร่างหนึ่งไปยังสตรีม ผลลัพธ์จะมีเฉพาะรูปร่างนั้น ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปร่างใกล้เคียง

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() === 0) {
        console.log("Slide 1 does not contain a shape to export.");
    } else {
        var shape = slide.getShapes().get_Item(0);
        var svgStream = null;
        try {
            svgStream = java.newInstanceSync("java.io.FileOutputStream", "shape.svg");
            shape.writeAsSvg(svgStream);
        } catch (error) {
            console.log("The SVG file could not be written: " + error.message);
        } finally {
            if (svgStream !== null) {
                svgStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ควรเปิดพรีเซนเทชันอยู่ขณะทำการเรนเดอร์ ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปร่างและทรัพยากรเช่นฟอนต์และภาพ หากต้องการองค์ประกอบทั้งหมด ให้ส่งออกสไลด์แทนการส่งออกรูปร่างเดี่ยว ผู้เรียกใช้ต้องเป็นเจ้าของสตรีมและต้องปิดสตรีมนั้นเอง

## **Align Shapes**

เมธอด [SlideUtil.alignShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/alignshapes/) มีหลายแบบที่จัดแนวทั้งทั้งหมดหรือดัชนีที่เลือกจากคอลเลกชัน [ShapesAlignmentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลาง, หรือโหมดการกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปร่างที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปร่างให้กับขอบด้านบนของสไลด์ การอ้างอิงรูปร่างที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนทำการจัดแนว

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var firstShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 60, 80, 120, 50);
    var secondShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Ellipse, 240, 160, 120, 50);
    var thirdShape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    var shapeIndexes = java.newArray("int", [slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)]);

    asposeSlides.SlideUtil.alignShapes(asposeSlides.ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การจัดแนวเปลี่ยนตำแหน่ง ไม่ใช่ลำดับ z-order การจัดแนวเชิงสัมพันธ์มักต้องใช้รูปร่างอย่างน้อยสองรูป ส่วนการกระจายแนวนอนหรือแนวดิ่งต้องมีจำนวนรูปร่างเพียงพอเพื่อกำหนดระยะห่าง หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด ควรคำนวณดัชนีใหม่

## **Flip a Shape**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การตั้งค่าการพลิกแนวนอนและแนวตั้ง, และการหมุน ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิดการพลิก, และ `NotDefined` รักษาสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น

พรีเซนเทชันตัวอย่างด้านล่างมีรูปร่างหนึ่งรูปที่ไม่ได้พลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่นทั้งหมดไว้และแทนที่เฉพาะการตั้งค่าการพลิกสองค่า นี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/setframe/) ใหม่จะทับกรอบทั้งหมด

```javascript
const asposeSlides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new asposeSlides.Presentation("input.pptx");
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    var frame = shape.getFrame();

    console.log("Horizontal flip before change: " + frame.getFlipH());
    console.log("Vertical flip before change: " + frame.getFlipV());

    var changedFrame = new asposeSlides.ShapeFrame(java.newFloat(frame.getX()), java.newFloat(frame.getY()), java.newFloat(frame.getWidth()), java.newFloat(frame.getHeight()), java.newByte(asposeSlides.NullableBool.True), java.newByte(asposeSlides.NullableBool.True), java.newFloat(frame.getRotation()));
    shape.setFrame(changedFrame);

    presentation.save("flipped-shape.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปร่างที่บันทึกจะถูกสะท้อนแนวนอนและแนวตั้งโดยคงตำแหน่ง, ขนาด, และการหมุนไว้

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

ใช้ดัชนีคอลเลกชันได้เฉพาะเมื่อการประมวลผลสั้น ๆ และคอลเลกชันจะไม่เปลี่ยนก่อนใช้ดัชนีนั้น แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ตรวจสอบแล้วสำหรับเทมเพลตที่สร้างขึ้น, หรือ `OfficeInteropShapeId` สำหรับงาน interop ระดับสไลด์

**Does hiding a shape remove it from the z-order?**

ไม่ การซ่อนรูปร่างยังคงอยู่ในคอลเลกชันที่ดัชนีเดิม สามารถค้นหา, จัดลำดับใหม่, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง

**Why did a cloned shape appear in front of another shape?**

`addClone` ใส่สำเนาไว้ที่ท้ายคอลเลกชัน ซึ่งเป็นด้านหน้าของ z-order ใช้ `insertClone` เพื่อกำหนดดัชนีเริ่มต้น หรือใช้ `reorder` หลังจากเพิ่มรูปร่างทั้งหมดแล้ว