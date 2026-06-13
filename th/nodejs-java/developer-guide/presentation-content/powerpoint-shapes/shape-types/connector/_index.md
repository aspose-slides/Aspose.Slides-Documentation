---
title: จัดการตัวเชื่อมในงานนำเสนอด้วย JavaScript
linktitle: ตัวเชื่อม
type: docs
weight: 10
url: /th/nodejs-java/connector/
keywords:
- ตัวเชื่อม
- ประเภทของตัวเชื่อม
- จุดของตัวเชื่อม
- เส้นตัวเชื่อม
- มุมของตัวเชื่อม
- เชื่อมต่อรูปร่าง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เพิ่มศักยภาพให้แอป JavaScript สามารถวาด, เชื่อมต่อและกำหนดเส้นทางอัตโนมัติของเส้นในสไลด์ PowerPoint - ควบคุมตัวเชื่อมแบบตรง, โค้งมุมและโค้งได้อย่างเต็มที่"
---
## **บทนำ**

ตัวเชื่อม PowerPoint คือเส้นพิเศษที่เชื่อมต่อหรือเชื่อมโยงสองรูปร่างเข้าด้วยกันและยังคงติดอยู่กับรูปร่างแม้ว่าจะถูกย้ายหรือปรับตำแหน่งบนสไลด์ที่กำหนด

ตัวเชื่อมมักจะเชื่อมต่อกับ *จุดเชื่อมต่อ* (จุดสีเขียว) ซึ่งมีอยู่บนรูปร่างทั้งหมดโดยค่าเริ่มต้น จุดเชื่อมต่อจะปรากฏเมื่อเคอร์เซอร์เข้ามาใกล้

*จุดปรับค่า* (จุดสีส้ม) ที่มีอยู่เฉพาะบนตัวเชื่อมบางประเภท ใช้เพื่อแก้ไขตำแหน่งและรูปร่างของตัวเชื่อม

## **ประเภทของตัวเชื่อม**

ใน PowerPoint คุณสามารถใช้ตัวเชื่อมแบบตรง, ตัวเชื่อมหัวข้อ (โค้งมุม) และตัวเชื่อมโค้ง

Aspose.Slides ให้บริการตัวเชื่อมเหล่านี้:

| ตัวเชื่อม | รูปภาพ | จำนวนจุดปรับค่า |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **เชื่อมต่อรูปร่างด้วยตัวเชื่อม**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. เพิ่มสอง [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ไปยังสไลด์โดยใช้เมธอด `addAutoShape` ที่เปิดให้ใช้โดยอ็อบเจกต์ `Shapes`
1. เพิ่มตัวเชื่อมโดยใช้เมธอด `addConnector` ที่เปิดให้ใช้โดยอ็อบเจกต์ `Shapes` โดยกำหนดประเภทของตัวเชื่อม
1. เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อม
1. เรียกเมธอด `reroute` เพื่อใช้เส้นเชื่อมที่สั้นที่สุด
1. บันทึกการนำเสนอ

โค้ด JavaScript นี้แสดงวิธีการเพิ่มตัวเชื่อม (ตัวเชื่อมโค้ง) ระหว่างสองรูปร่าง (วงรีและสี่เหลี่ยม):

```javascript
// สร้างอินสแตนซ์ของคลาส presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงคอลเลกชันของรูปทรงสำหรับสไลด์ที่ระบุ
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // เพิ่ม autoshape รูปวงรี
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // เพิ่ม autoshape รูปสี่เหลี่ยม
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // เพิ่มรูปทรงตัวเชื่อมไปยังคอลเลกชันรูปทรงของสไลด์
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // เชื่อมต่อรูปทรงโดยใช้ตัวเชื่อม
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // เรียกเมธอด reroute เพื่อตั้งค่าเส้นทางสั้นที่สุดอัตโนมัติระหว่างรูปทรง
    connector.reroute();
    // บันทึกการนำเสนอ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
เมธอด `Connector.reroute` จะทำการกำหนดเส้นทางใหม่ของตัวเชื่อมและบังคับให้มันใช้เส้นทางที่สั้นที่สุดระหว่างรูปร่าง เพื่อให้บรรลุเป้าหมาย เมธอดอาจเปลี่ยนจุด `setStartShapeConnectionSiteIndex` และ `setEndShapeConnectionSiteIndex` 

{{% /alert %}} 

## **ระบุจุดเชื่อมต่อ**

หากคุณต้องการให้ตัวเชื่อมลิงก์สองรูปร่างโดยใช้จุดเฉพาะบนรูปร่าง คุณต้องระบุจุดเชื่อมต่อที่ต้องการตามวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. เพิ่มสอง [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ไปยังสไลด์โดยใช้เมธอด `addAutoShape` ที่เปิดให้ใช้โดยอ็อบเจกต์ `Shapes`
1. เพิ่มตัวเชื่อมโดยใช้เมธอด `addConnector` ที่เปิดให้ใช้โดยอ็อบเจกต์ `Shapes` โดยกำหนดประเภทของตัวเชื่อม
1. เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อม
1. ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปร่าง
1. บันทึกการนำเสนอ

โค้ด JavaScript นี้แสดงการดำเนินการที่ระบุจุดเชื่อมต่อที่ต้องการ:

```javascript
// สร้างอินสแตนซ์ของคลาส presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงคอลเลกชันของรูปทรงสำหรับสไลด์ที่ระบุ
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // เพิ่ม autoshape รูปวงรี
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // เพิ่ม autoshape รูปสี่เหลี่ยม
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // เพิ่มรูปทรงตัวเชื่อมไปยังคอลเลกชันรูปทรงของสไลด์
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // เชื่อมต่อรูปทรงโดยใช้ตัวเชื่อม
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // ตั้งค่าดัชนีจุดเชื่อมต่อที่ต้องการบนรูปทรง Ellipse
    var wantedIndex = 6;
    // ตรวจสอบว่าดัชนีที่ต้องการน้อยกว่าจำนวนดัชนีไซต์สูงสุดหรือไม่
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // ตั้งค่าจุดเชื่อมต่อที่ต้องการบน autoshape Ellipse
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // บันทึกการนำเสนอ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ปรับจุดของตัวเชื่อม**

คุณสามารถปรับตัวเชื่อมที่มีอยู่ผ่านจุดปรับค่าได้ ตัวเชื่อมที่มีจุดปรับค่าเท่านั้นที่สามารถแก้ไขได้ในลักษณะนี้ ดูตารางใน **[ประเภทของตัวเชื่อม](/slides/th/nodejs-java/connector/#types-of-connectors)**

### **กรณีง่าย**

พิจารณากรณีที่ตัวเชื่อมระหว่างสองรูปร่าง (A และ B) ผ่านรูปร่างที่สาม (C):

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

เพื่อหลีกเลี่ยงหรือข้ามรูปร่างที่สาม เราสามารถปรับตัวเชื่อมโดยย้ายเส้นแนวตั้งไปทางซ้ายดังนี้:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **กรณีซับซ้อน** 

เพื่อทำการปรับค่าที่ซับซ้อนมากขึ้น คุณต้องคำนึงถึงสิ่งต่อไปนี้:

* จุดปรับค่าของตัวเชื่อมเชื่อมโยงอย่างแน่นหนากับสูตรที่คำนวณและกำหนดตำแหน่งของมัน ดังนั้นการเปลี่ยนแปลงตำแหน่งของจุดอาจทำให้รูปร่างของตัวเชื่อมเปลี่ยนไป
* จุดปรับค่าของตัวเชื่อมถูกกำหนดในลำดับที่เคร่งครัดในอาเรย์ โดยลำดับการนับจากจุดเริ่มต้นของตัวเชื่อมไปจนถึงจุดสิ้นสุด
* ค่าจุดปรับค่าสะท้อนเปอร์เซ็นต์ของความกว้าง/ความสูงของรูปร่างตัวเชื่อม
  * รูปร่างถูกจำกัดโดยจุดเริ่มและจุดสิ้นสุดของตัวเชื่อมคูณด้วย 1000
  * จุดแรก, จุดที่สอง, และจุดที่สาม กำหนดเปอร์เซ็นต์จากความกว้าง, เปอร์เซ็นต์จากความสูง, และอีกครั้งจากความกว้างตามลำดับ
* สำหรับการคำนวณที่กำหนดพิกัดของจุดปรับค่าของตัวเชื่อม คุณต้องคำนึงถึงการหมุนและการสะท้อนของตัวเชื่อม **หมายเหตุ** ว่าองศาการหมุนของตัวเชื่อมทั้งหมดที่แสดงใน **[ประเภทของตัวเชื่อม](/slides/th/nodejs-java/connector/#types-of-connectors)** เป็น 0

#### **กรณี 1**

พิจารณากรณีที่วัตถุกรอบข้อความสองอันเชื่อมต่อกันผ่านตัวเชื่อม:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// สร้างอินสแตนซ์ของคลาส presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรกในงานนำเสนอ
    var sld = pres.getSlides().get_Item(0);
    // เพิ่มรูปทรงที่จะเชื่อมต่อกันผ่านตัวเชื่อม
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // เพิ่มตัวเชื่อม
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // ระบุทิศทางของตัวเชื่อม
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // ระบุสีของตัวเชื่อม
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // ระบุความหนาของเส้นตัวเชื่อม
    connector.getLineFormat().setWidth(3);
    // เชื่อมต่อรูปทรงเข้าด้วยกันด้วยตัวเชื่อม
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // ดึงจุดปรับค่าของตัวเชื่อม
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**การปรับค่า**

เราสามารถเปลี่ยนค่าจุดปรับค่าของตัวเชื่อมโดยเพิ่มเปอร์เซ็นต์ความกว้างและความสูงที่เกี่ยวข้องขึ้น 20% และ 200% ตามลำดับ:

```javascript
// เปลี่ยนค่าของจุดปรับค่า
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-1](connector-adjusted-1.png)

เพื่อกำหนดโมเดลที่ช่วยให้เราหาพิกัดและรูปร่างของส่วนต่าง ๆ ของตัวเชื่อม ให้สร้างรูปร่างที่สอดคล้องกับส่วนแนวนอนของตัวเชื่อมที่จุด `connector.getAdjustments().get_Item(0)`:

```javascript
// วาดส่วนแนวตั้งของตัวเชื่อม
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

ผลลัพธ์:

![connector-adjusted-2](connector-adjusted-2.png)

#### **กรณี 2**

ใน **กรณี 1** เราได้สาธิตการปรับตัวเชื่อมอย่างง่ายโดยใช้หลักการพื้นฐาน ในสถานการณ์ปกติคุณต้องคำนึงถึงการหมุนของตัวเชื่อมและการแสดงผลของมัน (ซึ่งตั้งค่าโดย `connector.getRotation()`, `connector.getFrame().getFlipH()`, และ `connector.getFrame().getFlipV()`) เราจะสาธิตขั้นตอนต่อไป

อันดับแรก ให้เพิ่มวัตถุกรอบข้อความใหม่ (**To 1**) ไปยังสไลด์ (เพื่อการเชื่อมต่อ) และสร้างตัวเชื่อม (สีเขียว) ใหม่ที่เชื่อมต่อกับวัตถุที่สร้างไว้ก่อนหน้า

```javascript
// สร้างอ็อบเจกต์การผูกใหม่
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// สร้างตัวเชื่อมใหม่
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// เชื่อมต่ออ็อบเจกต์โดยใช้ตัวเชื่อมที่สร้างใหม่
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// ดึงจุดปรับค่าของตัวเชื่อม
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// เปลี่ยนค่าของจุดปรับค่า
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-3](connector-adjusted-3.png)

ต่อมา ให้สร้างรูปร่างที่จะสอดคล้องกับส่วนแนวนอนของตัวเชื่อมที่ผ่านจุดปรับค่าของตัวเชื่อมใหม่ `connector.getAdjustments().get_Item(0)` เราจะใช้ค่าจากข้อมูลตัวเชื่อมสำหรับ `connector.getRotation()`, `connector.getFrame().getFlipH()`, และ `connector.getFrame().getFlipV()` แล้วนำสูตรการแปลงพิกัดที่นิยมใช้สำหรับการหมุนรอบจุด x0 ไปใช้:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

ในกรณีของเรา มุมการหมุนของวัตถุคือ 90 องศาและตัวเชื่อมแสดงเป็นแนวตั้ง ดังนั้นโค้ดที่สอดคล้องคือ:

```javascript
// บันทึกพิกัดของตัวเชื่อม
x = connector.getX();
y = connector.getY();
// แก้ไขพิกัดของตัวเชื่อมในกรณีที่มันปรากฏ
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// รับค่าจุดปรับค่าเป็นพิกัด
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// แปลงพิกัดเนื่องจาก Sin(90) = 1 และ Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// กำหนดความกว้างของส่วนแนวนอนโดยใช้ค่าจุดปรับค่าที่สอง
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

ผลลัพธ์:

![connector-adjusted-4](connector-adjusted-4.png)

เราได้สาธิตการคำนวณที่รวมการปรับค่าแบบง่ายและการปรับค่าที่ซับซ้อน (จุดปรับค่าพร้อมมุมการหมุน) ด้วยความรู้ที่ได้ คุณสามารถพัฒนาโมเดลของคุณเอง (หรือเขียนโค้ด) เพื่อรับออบเจกต์ `GraphicsPath` หรือแม้แต่ตั้งค่าจุดปรับค่าของตัวเชื่อมตามพิกัดสไลด์ที่ระบุ

## **ค้นหามุมของเส้นตัวเชื่อม**

1. สร้างอินสแตนซ์ของคลาส
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. เข้าถึงรูปร่างเส้นตัวเชื่อม
1. ใช้ความกว้าง, ความสูง, ความสูงของกรอบรูปร่าง, และความกว้างของกรอบรูปร่างเพื่อคำนวณมุม

โค้ด JavaScript นี้สาธิตการคำนวณมุมสำหรับรูปร่างเส้นตัวเชื่อม:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าตัวเชื่อมสามารถ "ติด" กับรูปร่างเฉพาะได้หรือไม่?**

ตรวจสอบว่ารูปร่างเปิดให้ใช้ [connection sites](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/getconnectionsitecount/) หรือไม่ หากไม่มีหรือจำนวนเป็นศูนย์ การติดจะไม่สามารถทำได้; ในกรณีนั้นให้ใช้จุดปลายอิสระและกำหนดตำแหน่งด้วยตนเอง ควรตรวจสอบจำนวนไซต์ก่อนทำการเชื่อมต่อ

**จะเกิดอะไรขึ้นกับตัวเชื่อมหากฉันลบหนึ่งในรูปร่างที่เชื่อมต่ออยู่?**

จุดปลายของตัวเชื่อมจะถูกยกเลิกการเชื่อมต่อ; ตัวเชื่อมยังคงอยู่บนสไลด์ในรูปแบบเส้นปกติที่มีจุดเริ่ม/จบอิสระ คุณสามารถลบมันหรือกำหนดการเชื่อมต่อใหม่และหากจำเป็นให้ใช้ [reroute](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/connector/reroute/)

**การผูกตัวเชื่อมจะคงอยู่หรือไม่เมื่อคัดลอกสไลด์ไปยังการนำเสนออื่น?**

โดยทั่วไปจะคงอยู่ หากรูปร่างเป้าหมายถูกคัดลอกพร้อมกัน หากสไลด์ถูกแทรกเข้าไฟล์อื่นโดยไม่มีรูปร่างที่เชื่อมต่อ จุดปลายจะกลายเป็นอิสระและคุณต้องเชื่อมต่อใหม่**