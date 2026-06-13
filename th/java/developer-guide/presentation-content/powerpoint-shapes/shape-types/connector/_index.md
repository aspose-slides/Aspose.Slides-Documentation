---
title: จัดการตัวเชื่อมในงานนำเสนอด้วย Java
linktitle: ตัวเชื่อม
type: docs
weight: 10
url: /th/java/connector/
keywords:
- ตัวเชื่อม
- ประเภทตัวเชื่อม
- จุดตัวเชื่อม
- เส้นตัวเชื่อม
- มุมตัวเชื่อม
- เชื่อมรูปร่าง
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ให้แอป Java สามารถวาด, เชื่อมและกำหนดเส้นทางอัตโนมัติในสไลด์ PowerPoint — ควบคุมตัวเชื่อมตรง, ตัวเชื่อมศอก และตัวเชื่อมโค้งได้อย่างเต็มที่"
---
## **บทนำ**

PowerPoint connector คือเส้นพิเศษที่เชื่อมหรือเชื่อมโยงสองรูปร่างเข้าด้วยกันและจะคงอยู่ติดกับรูปร่างแม้เมื่อรูปร่างถูกย้ายหรือปรับตำแหน่งบนสไลด์

Connectors มักเชื่อมต่อกับ *จุดเชื่อมต่อ* (จุดสีเขียว) ซึ่งมีอยู่บนทุกรูปร่างเป็นค่าเริ่มต้น จุดเชื่อมต่อจะปรากฏเมื่อเคอร์เซอร์อยู่ใกล้

*จุดปรับ* (จุดสีส้ม) ซึ่งมีเฉพาะบางตัวเชื่อม ใช้เพื่อแก้ไขตำแหน่งและรูปร่างของตัวเชื่อม

## **ประเภทของตัวเชื่อม**

ใน PowerPoint คุณสามารถใช้ตัวเชื่อมแบบตรง, แบบศอก (มุม), และแบบโค้ง

Aspose.Slides มีตัวเชื่อมเหล่านี้:

| ตัวเชื่อม | รูปภาพ | จำนวนจุดปรับ |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0 |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1 |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2 |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3 |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

## **เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อม**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสอง [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/AutoShape) ไปยังสไลด์โดยใช้เมธอด `addAutoShape` ของอ็อบเจกต์ `Shapes`  
4. เพิ่มตัวเชื่อมโดยใช้เมธอด `addConnector` ของอ็อบเจกต์ `Shapes` โดยกำหนดประเภทของตัวเชื่อม  
5. เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อม  
6. เรียกเมธอด `reroute` เพื่อใช้เส้นเชื่อมที่สั้นที่สุด  
7. บันทึกพรีเซนเทชัน  

โค้ด Java นี้แสดงวิธีการเพิ่มตัวเชื่อม (ตัวเชื่อมแบบบิด) ระหว่างสองรูป (รูปวงรีและสี่เหลี่ยม):

```Java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์ที่ระบุ
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // เพิ่มรูปร่างอัตโนมัติรูปวงรี
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // เพิ่มรูปร่างอัตโนมัติรูปสี่เหลี่ยม
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // เพิ่มรูปร่างตัวเชื่อมไปยังคอลเลกชันรูปร่างของสไลด์
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อม
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // เรียกเมธอด reroute ที่กำหนดเส้นทางสั้นที่สุดอัตโนมัติระหว่างรูปร่าง
    connector.reroute();
    
    // บันทึกพรีเซนเทชัน
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
เมธอด `Connector.reroute` จะทำการกำหนดเส้นทางใหม่ให้กับตัวเชื่อมและบังคับให้มันใช้เส้นทางที่สั้นที่สุดระหว่างรูปร่าง ทั้งนี้เมธอดอาจเปลี่ยนค่า `setStartShapeConnectionSiteIndex` และ `setEndShapeConnectionSiteIndex` ได้  
{{% /alert %}} 

## **ระบุจุดเชื่อมต่อ**

หากต้องการให้ตัวเชื่อมเชื่อมสองรูปร่างโดยใช้จุดเฉพาะบนรูปร่าง คุณต้องระบุตำแหน่งจุดเชื่อมต่อที่ต้องการดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มสอง [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/AutoShape) ไปยังสไลด์โดยใช้เมธอด `addAutoShape` ของอ็อบเจกต์ `Shapes`  
4. เพิ่มตัวเชื่อมโดยใช้เมธอด `addConnector` ของอ็อบเจกต์ `Shapes` โดยกำหนดประเภทของตัวเชื่อม  
5. เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อม  
6. ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปร่าง  
7. บันทึกพรีเซนเทชัน  

โค้ด Java นี้สาธิตการระบุจุดเชื่อมต่อที่ต้องการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงคอลเลกชันของรูปร่างสำหรับสไลด์ที่ระบุ
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // เพิ่มรูปร่างอัตโนมัติรูปวงรี
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // เพิ่มรูปร่างอัตโนมัติรูปสี่เหลี่ยม
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // เพิ่มรูปร่างตัวเชื่อมไปยังคอลเลกชันรูปร่างของสไลด์
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // เชื่อมต่อรูปร่างโดยใช้ตัวเชื่อม
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // ตั้งค่าดัชนีจุดเชื่อมต่อที่ต้องการบนรูปร่างวงรี
    int wantedIndex = 6;

    // ตรวจสอบว่าดัชนีที่ต้องการน้อยกว่าจำนวนดัชนีไซต์สูงสุดหรือไม่
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปร่างอัตโนมัติวงรี
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // บันทึกพรีเซนเทชัน
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ปรับจุดของตัวเชื่อม**

คุณสามารถปรับตัวเชื่อมที่มีอยู่ผ่านจุดปรับได้ เพียงตัวเชื่อมที่มีจุดปรับเท่านั้นที่สามารถแก้ไขในลักษณะนี้ ดูตารางภายใต้ **[ประเภทของตัวเชื่อม](/slides/th/java/connector/#types-of-connectors)**  

### **กรณีง่าย**

พิจารณากรณีที่ตัวเชื่อมระหว่างสองรูปร่าง (A และ B) ผ่านรูปร่างที่สาม (C):

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

เพื่อหลีกเลี่ยงหรือข้ามรูปร่างที่สาม เราสามารถปรับตัวเชื่อมโดยย้ายเส้นแนวตั้งไปทางซ้ายดังนี้:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **กรณีซับซ้อน** 

เมื่อต้องทำการปรับที่ซับซ้อนมากขึ้น คุณต้องคำนึงถึงสิ่งต่อไปนี้:

* จุดปรับของตัวเชื่อมเชื่อมโยงอย่างแน่นหนากับสูตรที่คำนวณและกำหนดตำแหน่งของมัน ดังนั้นการเปลี่ยนตำแหน่งจุดอาจทำให้รูปร่างของตัวเชื่อมเปลี่ยนไป  
* จุดปรับของตัวเชื่อมถูกกำหนดตามลำดับที่เคร่งครัดในอาร์เรย์ โดยจัดลำดับจากจุดเริ่มต้นของตัวเชื่อมไปจนถึงจุดสิ้นสุด  
* ค่าจุดปรับแสดงเป็นเปอร์เซ็นต์ของความกว้าง/ความสูงของรูปร่างตัวเชื่อม  
  * รูปร่างถูกจำกัดโดยจุดเริ่มต้นและสิ้นสุดของตัวเชื่อมคูณด้วย 1000  
  * จุดแรก, จุดที่สอง, และจุดที่สามกำหนดเปอร์เซ็นต์จากความกว้าง, ความสูง, และความกว้าง (อีกครั้ง) ตามลำดับ  
* สำหรับการคำนวณที่กำหนดพิกัดของจุดปรับของตัวเชื่อม คุณต้องคำนึงถึงการหมุนและการสะท้อนของตัวเชื่อม **หมายเหตุ** ว่ามุมการหมุนของตัวเชื่อมทั้งหมดที่แสดงใน **[ประเภทของตัวเชื่อม](/slides/th/java/connector/#types-of-connectors)** คือ 0  

#### **กรณี 1**

พิจารณากรณีที่สองอ็อบเจกต์กรอบข้อความเชื่อมต่อกันผ่านตัวเชื่อม:

![connector-shape-complex](connector-shape-complex.png)

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรกในพรีเซนเทชัน
    ISlide sld = pres.getSlides().get_Item(0);
    // เพิ่มรูปร่างที่จะเชื่อมต่อกันผ่านตัวเชื่อม
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // เพิ่มตัวเชื่อม
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // กำหนดทิศทางของตัวเชื่อม
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // กำหนดสีของตัวเชื่อม
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // กำหนดความหนาของเส้นตัวเชื่อม
    connector.getLineFormat().setWidth(3);
    
    // เชื่อมต่อรูปร่างเข้าด้วยกันโดยใช้ตัวเชื่อม
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // ดึงจุดปรับของตัวเชื่อม
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**การปรับ**

เราสามารถเปลี่ยนค่าจุดปรับของตัวเชื่อมได้โดยเพิ่มเปอร์เซ็นต์ความกว้างและความสูงที่สอดคล้องกันเป็น 20% และ 200% ตามลำดับ:

```java
// เปลี่ยนค่าของจุดปรับ
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-1](connector-adjusted-1.png)

เพื่อกำหนดโมเดลที่ช่วยให้เราหาพิกัดและรูปร่างของส่วนประกอบย่อยของตัวเชื่อม เราจะสร้างรูปร่างที่สอดคล้องกับส่วนประกอบแนวนอนของตัวเชื่อมที่จุด `connector.getAdjustments().get_Item(0)`:

```java
// วาดส่วนประกอบแนวตั้งของตัวเชื่อม
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

ผลลัพธ์:

![connector-adjusted-2](connector-adjusted-2.png)

#### **กรณี 2**

ใน **กรณี 1** เราได้สาธิตการปรับตัวเชื่อมอย่างง่ายโดยใช้หลักการพื้นฐาน ในสถานการณ์ปกติคุณต้องคำนึงถึงการหมุนของตัวเชื่อมและการแสดงผล (ซึ่งตั้งค่าผ่าน `connector.getRotation()`, `connector.getFrame().getFlipH()`, และ `connector.getFrame().getFlipV()`) เราจะสาธิตขั้นตอนต่อไป

ขั้นแรกให้เพิ่มอ็อบเจกต์กรอบข้อความใหม่ (**To 1**) ไปยังสไลด์ (เพื่อการเชื่อมต่อ) แล้วสร้างตัวเชื่อม (สีเขียว) ที่เชื่อมต่อกับอ็อบเจกต์ที่สร้างไว้ก่อนหน้า:

```java
// สร้างอ็อบเจกต์การผูกใหม่
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// สร้างตัวเชื่อมใหม่
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// เชื่อมต่ออ็อบเจกต์โดยใช้ตัวเชื่อมที่สร้างขึ้นใหม่
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// ดึงจุดปรับของตัวเชื่อม
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// เปลี่ยนค่าของจุดปรับ
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-3](connector-adjusted-3.png)

ต่อมาให้สร้างรูปร่างที่สอดคล้องกับส่วนประกอบแนวนอนของตัวเชื่อมที่ผ่านจุดปรับของตัวเชื่อมใหม่ `connector.getAdjustments().get_Item(0)` เราจะใช้ค่าจาก `connector.getRotation()`, `connector.getFrame().getFlipH()`, และ `connector.getFrame().getFlipV()` และนำสูตรแปลงพิกัดสำหรับการหมุนรอบจุด x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;  
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

ในกรณีของเรา มุมการหมุนของอ็อบเจกต์คือ 90 องศาและตัวเชื่อมแสดงเป็นแนวตั้ง ดังนั้นโค้ดที่สอดคล้องคือ:

```java
// บันทึกพิกัดของตัวเชื่อม
x = connector.getX();
y = connector.getY();
// แก้ไขพิกัดของตัวเชื่อมในกรณีที่ปรากฏ
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// นำค่าจุดปรับมาใช้เป็นพิกัด
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  แปลงพิกัดเนื่องจาก Sin(90) = 1 และ Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// กำหนดความกว้างของส่วนประกอบแนวนอนโดยใช้ค่าจุดปรับที่สอง
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

ผลลัพธ์:

![connector-adjusted-4](connector-adjusted-4.png)

เราได้สาธิตการคำนวณที่เกี่ยวข้องกับการปรับอย่างง่ายและการปรับจุดที่ซับซ้อน (จุดปรับที่มีมุมการหมุน) ด้วยความรู้เหล่านี้ คุณสามารถพัฒนาโมเดลของคุณเอง (หรือเขียนโค้ด) เพื่อตั้งค่าอ็อบเจกต์ `GraphicsPath` หรือแม้แต่ตั้งค่าจุดปรับของตัวเชื่อมตามพิกัดสไลด์ที่กำหนด

## **ค้นหามุมของเส้นตัวเชื่อม**

1. สร้างอินสแตนซ์ของคลาส  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงรูปร่างเส้นตัวเชื่อม  
4. ใช้ความกว้าง, ความสูง, ความสูงของเฟรมรูปร่าง, และความกว้างของเฟรมรูปร่างเพื่อคำนวณมุม  

โค้ด Java นี้สาธิตการคำนวณมุมของรูปร่างเส้นตัวเชื่อม:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าตัวเชื่อมสามารถ "ผูกติด" กับรูปร่างเฉพาะได้หรือไม่?**  
ให้ตรวจสอบว่ารูปร่างเปิดเผย [connection sites](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getConnectionSiteCount--) หรือไม่ หากไม่มีหรือจำนวนเป็นศูนย์ การผูกติดไม่สามารถทำได้; ในกรณีนั้นใช้จุดปลายอิสระและกำหนดตำแหน่งด้วยตนเอง ควรตรวจสอบจำนวนไซต์ก่อนทำการแนบ

**จะเกิดอะไรขึ้นกับตัวเชื่อมหากฉันลบหนึ่งในรูปร่างที่เชื่อมต่อ?**  
ปลายทั้งสองจะถูกยกเลิกการเชื่อมต่อ; ตัวเชื่อมจะคงอยู่บนสไลด์เป็นเส้นธรรมดาที่มีจุดเริ่มต้น/สิ้นสุดอิสระ คุณสามารถลบมันหรือกำหนดการเชื่อมต่อใหม่และหากจำเป็นให้ใช้ [reroute](https://reference.aspose.com/slides/th/java/com.aspose.slides/connector/#reroute--)  

**การผูกติดของตัวเชื่อมจะถูกเก็บไว้เมื่อคัดลอกสไลด์ไปยังพรีเซนเทชันอื่นหรือไม่?**  
โดยทั่วไปใช่ แต่อยู่ที่ว่ารูปร่างเป้าหมายถูกคัดลอกด้วยหรือไม่ หากสไลด์ถูกแทรกเข้าไฟล์อื่นโดยไม่มีรูปร่างที่เชื่อมต่อ ปลายจะกลายเป็นอิสระและคุณต้องผูกติดใหม่.