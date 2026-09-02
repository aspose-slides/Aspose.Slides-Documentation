---
title: จัดการรูปทรงพรีเซนเทชันใน JavaScript
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/nodejs-java/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงพรีเซนเทชัน
- รูปทรงบนสไลด์
- ค้นหารูปทรง
- ทำสำเนารูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ ID รูปทรง Interop
- ข้อความแทนที่ของรูปทรง
- จุดปรับรูปทรง
- การปรับรูปทรงแบบ preset
- เรขาคณิตรูปทรง
- รูปแบบการจัดวางรูปทรง
- รูปทรงเป็น SVG
- แปลงรูปทรงเป็น SVG
- จัดแนวรูปทรง
- พลิกรูปทรง
- PowerPoint
- พรีเซนเทชัน
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีระบุ ปรับ ปรับแต่งทำสำเนา ลบ ซ่อน จัดลำดับใหม่ ส่งออก จัดแนว และพลิกรูปทรงพรีเซนเทชันด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **Overview**

Aspose.Slides for Node.js via Java แสดงรูปทรงบนสไลด์เป็น [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/) ที่จัดลำดับไว้แล้ว คอลเลกชันนี้เป็นทั้งที่ที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งของลำดับการซ้อนกัน: ดัชนี `0` คือรูปทรงที่อยู่ด้านหลังที่สุด ส่วนดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าที่สุด

บทความนี้ทำตามโมเดลนั้น โดยอธิบายวิธีระบุรูปทรงอย่างเชื่อถือได้และแก้ไขจุดปรับรูปทรงที่ตั้งไว้ก่อน แล้วแสดงวิธีทำสำเนา ลบ ซ่อน และจัดเรียงลำดับรูปทรงใหม่ ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาท์ การส่งออกเป็น SVG การจัดแนว และการตั้งค่าการพลิก ทั้งหลายเป็นตัวอย่างอิสระ คุณจึงใช้เฉพาะการกระทำที่จำเป็นในการทำงานของคุณได้

## **Identify and Find Shapes**

ดัชนีของคอลเลกชันสะดวกเมื่อประมวลผลไฟล์ที่รู้ล่วงหน้า แต่ไม่ใช่ตัวระบุที่มั่นคง การเพิ่ม ลบ หรือจัดเรียงลำดับรูปทรงใหม่สามารถเปลี่ยนดัชนีของมันได้ เลือกตัวระบุตามวิธีการสร้างและการบำรุงรักษาไฟล์พรีเซนเทชัน:

- [Name](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getname/) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและง่ายต่อการตรวจสอบใน **Selection Pane** ของ PowerPoint ชื่อสามารถแก้ไขได้และไม่รับประกันว่าจะเป็นเอกลักษณ์ จึงควรกำหนดกฎการตั้งชื่อหากโค้ดพึ่งพา
- [AlternativeText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getalternativetext/) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้ได้ระบุรูปทรงแล้ว มันมองเห็นได้โดยผู้ใช้ อาจแปลเป็นภาษาต่าง ๆ หรือเขียนใหม่เพื่อการเข้าถึงได้และไม่รับประกันว่าจะเป็นเอกลักษณ์ อย่าใช้ข้อความการเข้าถึงที่มีความหมายเป็นคีย์ฐานข้อมูลโดยไม่เจตนา
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getofficeinteropshapeid/) เป็นตัวระบุแบบอ่าน‑อย่างเดียวที่มีเอกลักษณ์ภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint interop ใช้ ใช้เมื่อต้องทำงานร่วมกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ชัดเจนตลอดอายุของรูปทรง รูปทรงที่ทำสำเนาหรือสร้างใหม่จะมี ID ของตนเอง

เมธอดที่เกี่ยวข้อง [getUniqueId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getuniqueid/) คืนค่าตัวระบุที่มีขอบเขตระดับพรีเซนเทชัน แต่ตัวระบุดังกล่าวออกแบบมาสำหรับแอด‑อินและอาจถูกกำหนดใหม่ ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร หากต้องการระบุตัวตนระยะยาวกรุณาเก็บแมปปิ้งในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงอยู่

ตัวอย่างต่อไปค้นหาโดยชื่อด้วยการเปรียบเทียบแบบแม่นยำและรายงาน interop ID ที่มีขอบเขตสไลด์ เมื่อเทมเพลตไม่มีรูปทรงที่คาดไว้ โค้ดจะรายงานผลลัพธ์นั้นแทนที่จะดำเนินการต่อด้วยออบเจกต์ผิด

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

เมื่อการดำเนินการเฉพาะประเภทรูปทรง ให้ตรวจสอบคลาสขณะทำงานก่อนใช้สมาชิกที่เฉพาะเจาะจง ตัวอย่างนี้อัปเดตข้อความและข้อความแทนที่เฉพาะเมื่ออ็อบเจกต์ที่ตั้งชื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)

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

## **Identify and Modify Preset Shape Adjustments**

รูปทรงเรขาคณิตแบบ preset สามารถเปิดเผยจุดปรับที่ควบคุมคุณสมบัติต่าง ๆ เช่น ขนาดมุม ลูกศร หรือมุมของโค้ง เข้าถึงได้ผ่านคอลเลกชันอ่าน‑อย่างเดียว [GeometryShape.getAdjustments](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/geometryshape/) คอลเลกชันนี้จัดหาโดยรูปทรงเอง แต่ละ [AdjustValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/) มีค่า ที่สามารถเปลี่ยนได้

ห้ามพึ่งพาดัชนีคอลเลกชันคงที่เท่านั้น ให้วนลูปผ่านการปรับทั้งหมดและตรวจสอบเมธอดอ่าน‑อย่างเดียว [getType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/) ซึ่งค่าประเภท [ShapeAdjustmentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapeadjustmenttype/) บอกรายละเอียดว่าการปรับควบคุมอะไร เมธอดอ่าน‑อย่างเดียว [getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/getname/) ให้ข้อมูลระบุตัวเพิ่มเติมและมีประโยชน์อย่างยิ่งเมื่อ preset มีการปรับหลายรายการที่มีประเภทเชิงความหมายเดียวกัน

ใช้เมธอดค่าที่สอดคล้องกับความหมายของการปรับ:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | ขนาดของมุมโค้ง | [setRawValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | ความหนาของหัวลูกศร | `setRawValue` |
| `ArrowheadLength` | ความยาวของหัวลูกศร | `setRawValue` |
| `ArrowheadWidth` | ความกว้างของหัวลูกศร | `setRawValue` |
| `StartAngle` | มุมเริ่มต้นของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | มุมสิ้นสุดของพายหรือโค้ง | `setAngleValue` |

`getType` และ `getName` คืนข้อมูลแบบอ่าน‑อย่างเดียว `getRawValue` และ `setRawValue` ทำงานกับจำนวนเต็มในหน่วยเรขาคณิตของ preset ส่วน `getAngleValue` และ `setAngleValue` ทำงานกับมุมเป็นองศา จำนวน ลำดับ ความหมายและช่วงค่าที่ถูกต้องของการปรับขึ้นอยู่กับ preset ที่ได้จาก [GeometryShape.getShapeType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/geometryshape/) ค่าเดียวที่ใช้ได้กับ preset หนึ่งอาจไม่ถูกต้องหรือมีผลต่างกับ preset อื่น

เมื่อ `getType` คืนค่า `ShapeAdjustmentType.Custom` API จะไม่รู้จักความหมายมาตรฐาน ให้ตรวจสอบ `getName` ประเภท preset และค่าที่มีอยู่ และปล่อยให้การปรับคงเดิมไว้ เว้นแต่คุณจะรู้ความหมายและช่วงที่คาดหวัง แม้สำหรับประเภทที่รู้จักแล้วก็ตาม ให้ตรวจสอบว่าประเภทเดียวกันปรากฏหลายครั้งหรือไม่ ก่อนเลือกค่า บทความ [Connector](/slides/th/nodejs-java/connector/) แสดงสถานการณ์นี้กับการปรับโค้งของคอนเนคเตอร์

ตัวอย่างเต็มต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของรูปทรง preset สามรูป แสดงการวนลูปผ่านทุกการปรับ รายงานชื่อและประเภทของแต่ละรายการ เปลี่ยนค่าที่เกี่ยวกับขนาดโดย `setRawValue` เปลี่ยนมุมโดย `setAngleValue` และบันทึกผล คอลัมน์ซ้ายแสดงเรขาคณิตเดิม คอลัมน์ขวามีสี่เหลี่ยมมุมโค้ง ปุ่มลูกศรสี่ทาง และพายที่ปรับแล้ว

```javascript
const asposeSlides = require("aspose.slides.via.java");

var presentation = new asposeSlides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    // เพิ่มส่วนหัวสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่า.
    var defaultColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 40, 20, 250, 30);
    defaultColumnLabel.getTextFrame().setText("Default preset geometry");
    var adjustedColumnLabel = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 390, 20, 250, 30);
    adjustedColumnLabel.getTextFrame().setText("Modified adjustment values");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
    var modifiedRoundedRectangle = slide.getShapes().addAutoShape(asposeSlides.ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
    modifiedRoundedRectangle.setName("ModifiedRoundedRectangle");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 80, 180, 160, 110);
    var modifiedArrow = slide.getShapes().addAutoShape(asposeSlides.ShapeType.QuadArrow, 430, 180, 160, 110);
    modifiedArrow.setName("ModifiedQuadArrow");

    slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 95, 330, 130, 130);
    var modifiedPie = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Pie, 445, 330, 130, 130);
    modifiedPie.setName("ModifiedPie");

    var shapesToAdjust = [modifiedRoundedRectangle, modifiedArrow, modifiedPie];

    for (var shapeIndex = 0; shapeIndex < shapesToAdjust.length; shapeIndex++) {
        var shape = shapesToAdjust[shapeIndex];
        for (var adjustmentIndex = 0; adjustmentIndex < shape.getAdjustments().size(); adjustmentIndex++) {
            var adjustment = shape.getAdjustments().get_Item(adjustmentIndex);
            console.log(shape.getName() + " / " + adjustment.getName() + ": " + adjustment.getType());

            switch (adjustment.getType()) {
                case asposeSlides.ShapeAdjustmentType.CornerSize:
                    adjustment.setRawValue(5000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowTailThickness:
                    adjustment.setRawValue(25000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadLength:
                    adjustment.setRawValue(30000);
                    break;
                case asposeSlides.ShapeAdjustmentType.ArrowheadWidth:
                    adjustment.setRawValue(40000);
                    break;
                case asposeSlides.ShapeAdjustmentType.StartAngle:
                    adjustment.setAngleValue(30);
                    break;
                case asposeSlides.ShapeAdjustmentType.EndAngle:
                    adjustment.setAngleValue(300);
                    break;
                case asposeSlides.ShapeAdjustmentType.Custom:
                    console.log("Custom adjustment '" + adjustment.getName() + "' was not changed.");
                    break;
            }
        }
    }

    presentation.save("preset-shape-adjustments.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าช่วยให้โค้ดมีเจตนาชัดเจนและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวกันมีความหมายเท่ากันใน preset ที่ต่างกัน

## **Modify the Shape Collection**

เมธอด add, clone, remove และ reorder ทำงานกับคอลเลกชันโดยตรง หากการดำเนินการใดทำให้จำนวนหรือลำดับของรูปทรงเปลี่ยนแปลง อย่าอ้างอิงดัชนีที่จับไว้ก่อนหน้าต่อไป

### **Clone a Shape**

[addClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/addclone/) สร้างสำเนาอิสระและเพิ่มเข้าไปที่ท้ายคอลเลกชัน [insertClone](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/insertclone/) ก็สร้างสำเนาเช่นกันแต่ใส่ที่ดัชนี z‑order ที่ระบุ ตัว overload ที่รับพิกัดจะย้ายสำเนาโดยไม่เปลี่ยนขนาด; overload ที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย

ตัวอย่างสร้างสไลด์ปลายทาง ทำสำเนาสี่เหลี่ยมที่มีป้ายกำกับไปด้านหน้า แล้วแทรกสำเนาที่สองไว้ด้านหลัง การเปลี่ยนแปลงใด ๆ กับสำเนาใดสำเนาหนึ่งจะไม่กระทบรูปต้นฉบับ

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

การทำสำเนาจะคัดลอกเนื้อหาและการจัดรูปแบบของรูปทรงรวมถึงชื่อและข้อความแทนที่ด้วย ให้กำหนดตัวระบุลอจิกใหม่ให้กับสำเนาเมื่อค่าดังกล่าวต้องเป็นเอกลักษณ์ ทรัพยากรที่รูปทรงซับซ้อนใช้จะถูกจัดการโดยพรีเซนเทชัน แต่สำเนายังคงเป็นรายการคอลเลกชันใหม่ที่มีอัตลักษณ์รูปทรงใหม่

### **Remove Shapes**

[remove](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/remove/) ลบออบเจกต์รูปทรงเฉพาะออกจากคอลเลกชันของมัน เมื่อทำการลบหลายรายการขณะวนลูปตามดัชนี ให้เริ่มจากปลายท้ายเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง

ตัวอย่างนี้ลบทุกรูปทรงที่มีชื่อที่กำหนดไว้ อ่านรูปทรงที่ดัชนีปัจจุบันและไม่สันนิษฐานว่ามีประเภทรูปทรงเฉพาะ

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

หลังการลบ จำนวนรูปทรงและดัชนีของรูปทรงที่เหลือจะเปลี่ยน แนะนำให้อ้างอิงรูปทรงที่ไม่ได้รับผลกระทบแทนดัชนีที่บันทึกไว้ นอกจากนี้ยังต้องพิจารณาคอนเนคเตอร์ แอนิเมชัน และฟีเจอร์พรีเซนเทชันอื่น ๆ ที่อาจอ้างอิงออบเจกต์ที่ถูกลบ; การลบรูปทรงที่มองเห็นได้อาจเปลี่ยนมากกว่าลักษณะของสไลด์เท่านั้น

### **Hide a Shape**

ตั้งค่า [Hidden](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/sethidden/) เป็น `true` จะทำให้รูปทรงยังคงอยู่ในคอลเลกชันแต่ไม่ปรากฏในโหมดสไลด์โชว์ปกติ ดัชนี การจัดรูปแบบ และเนื้อหายังคงสามารถเข้าถึงได้โดยโค้ด ดังนั้นการซ่อนไว้จึงเหมาะกับองค์ประกอบที่อาจเปิดใช้ใหม่ได้ในภายหลัง

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

การซ่อนไม่ใช่การลบหรือการรักษาความปลอดภัย ออบเจกต์ยังสามารถค้นพบและยกเลิกการซ่อนได้โดยผู้ใช้หรือโดยโค้ด และมันยังคงเป็นส่วนหนึ่งของไฟล์พรีเซนเทชัน

### **Change the Z-Order**

รูปทรงที่ทับซ้อนกันจะถูกวาดตามลำดับของคอลเลกชัน [reorder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/reorder/) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่ทำสำเนา ดัชนี `0` คือด้านหลัง; `size() - 1` คือด้านหน้า

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

สี่เหลี่ยมถูกสร้างก่อนและอยู่หลังวงรีในตอนแรก การย้ายไปดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า ควรจัดลำดับ z‑order สุดท้ายหลังจากเพิ่มหรือทำสำเนารูปทรงทั้งหมดแล้ว เพราะการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการคอลเลกชันใหม่และอาจเปลี่ยนสแตกที่ต้องการ

## **Inspect Shapes on Layout Slides**

สไลด์ปกติ สไลด์เลย์เอาท์ และมาสเตอร์สไลด์มีคอลเลกชันรูปทรงแยกกัน รูปทรงในคอลเลกชันเลย์เอาท์ไม่ใช่ออบเจกต์เดียวกับรูปทรงที่จัดตำแหน่งเดียวกันบนสไลด์ปกติ ตรวจสอบรูปทรงในเลย์เอาท์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปแบบที่เลย์เอาท์จัดหาไว้

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getfillformat/) และ [LineFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getlineformat/) ของแต่ละรูปทรงในเลย์เอาท์โดยไม่สันนิษฐานว่าทุกรูปทรงเป็น `AutoShape`

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

การแก้ไขเลย์เอาท์อาจกระทบหลายสไลด์ที่ใช้งานมัน ก่อนเปลี่ยนรูปทรงเลย์เอาท์ให้ตรวจสอบว่าสไลด์ปกติสืบทอดออบเจกต์นั้นหรือมีการเขียนทับในท้องถิ่น และทดสอบทุกสไลด์ที่ใช้เลย์เอาท์นั้น

## **Export a Shape to SVG**

[writeAsSvg](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) เขียนเนื้อหาที่เรนเดอร์ของรูปทรงเดียวไปยังสตรีม ผลลัพธ์จะประกอบด้วยรูปทรงเท่านั้น ไม่รวมพื้นหลังของสไลด์หรือรูปทรงใกล้เคียง

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

ให้เปิดพรีเซนเทชันอยู่ขณะเรนเดอร์ ผลลัพธ์ขึ้นอยู่กับการจัดรูปแบบของรูปทรงและทรัพยากรเช่น ฟอนท์และรูปภาพ หากต้องการส่งออกทั้งหมดให้ส่งออกรายสไลด์แทนการส่งออกรูปทรงเดี่ยว ตัวเรียกต้องเป็นผู้ดูแลสตรีมและต้องปิดสตรีมเอง

## **Align Shapes**

เมธอด [SlideUtil.alignShapes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/slideutil/alignshapes/) มี overload ที่จัดแนวทั้งชุดหรือดัชนีที่เลือกในคอลเลกชัน [ShapesAlignmentType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapesalignmenttype/) ระบุขอบ ศูนย์กลาง หรือโหมดกระจาย ตั้งค่า `alignToSlide` เป็น `true` เพื่อใช้ขอบสไลด์; ตั้งเป็น `false` เพื่อจัดแนวรูปทรงที่เลือกสัมพันธ์กัน

ตัวอย่างนี้จัดแนวสามรูปทรงให้ชิดขอบบนของสไลด์ การอ้างอิงรูปทรงที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนจัดแนว

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

การจัดแนวเปลี่ยนตำแหน่ง ไม่เปลี่ยนลำดับ z‑order การจัดแนวสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปทรง ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีรูปทรงหลายรูปเพื่อกำหนดช่องว่าง หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอดให้คำนวณดัชนีใหม่

## **Flip a Shape**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapeframe/) เก็บตำแหน่ง ขนาด การพลิกแนวนอนและแนวตั้ง และการหมุน ค่า `getFlipH` และ `getFlipV` ใช้ [NullableBool](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/nullablebool/) : `True` เปิดการพลิก, `False` ปิด, `NotDefined` รักษาสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น

พรีเซนเทชันอินพุตด้านล่างมีรูปทรงหนึ่งที่ไม่ได้พลิก

![The shape before flipping](shape_to_be_flipped.png)

ตัวอย่างนี้เก็บค่ากรอบอื่น ๆ ไว้ทั้งหมดและเปลี่ยนเฉพาะการตั้งค่าพลิกสองค่าเท่านั้น ซึ่งสำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/setframe/) ใหม่จะทับกรอบทั้งหมด

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

รูปทรงที่บันทึกแล้วจะถูกสะท้อนทั้งแนวนอนและแนวตั้งในขณะที่ตำแหน่ง ขนาด และการหมุนคงเดิม

![The shape after flipping](flipped_shape.png)

## **FAQ**

**Should I use a collection index as a shape identifier?**

ใช้ได้เฉพาะการประมวลผลระยะสั้นเมื่อคอลเลกชันจะไม่เปลี่ยนแปลงก่อนใช้ดัชนี แนะนำให้ใช้ `Name` หรือ `AlternativeText` ที่ผ่านการตรวจสอบในเทมเพลตที่สร้างขึ้น หรือ `OfficeInteropShapeId` สำหรับงาน interop ระดับสไลด์

**Does hiding a shape remove it from the z-order?**

ไม่ รูปทรงที่ซ่อนยังคงอยู่ในคอลเลกชันที่ดัชนีเดียวกัน สามารถค้นพบ เรียงใหม่ แก้ไข หรือทำให้มองเห็นได้อีกครั้ง

**Why did a cloned shape appear in front of another shape?**

`addClone` เพิ่มสำเนาที่ท้ายคอลเลกชัน ซึ่งเป็นด้านหน้าของ z‑order ใช้ `insertClone` เพื่อเลือกดัชนีเริ่มต้นหรือใช้ `reorder` หลังจากเพิ่มรูปทั้งหมดแล้ว

**Can I use a fixed index to identify a preset shape adjustment?**

ได้เฉพาะหลังจากตรวจสอบ preset และการจัดวางคอลเลกชันอย่างแม่นยำ แนะนำให้วนลูปผ่าน `GeometryShape.getAdjustments` และตรวจสอบ `AdjustValue.getType`; หากประเภทเชิงความหมายเดียวกันปรากฏหลายครั้งให้ใช้ `AdjustValue.getName` เป็นข้อมูลเสริม