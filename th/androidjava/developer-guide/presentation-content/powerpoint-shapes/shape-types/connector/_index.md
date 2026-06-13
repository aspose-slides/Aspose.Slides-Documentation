---
title: จัดการคอนเนคเตอร์ในงานนำเสนอบน Android
linktitle: คอนเนคเตอร์
type: docs
weight: 10
url: /th/androidjava/connector/
keywords:
- คอนเนคเตอร์
- ประเภทคอนเนคเตอร์
- จุดคอนเนคเตอร์
- เส้นคอนเนคเตอร์
- มุมคอนเนคเตอร์
- เชื่อมต่อรูป
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เสริมความสามารถให้แอป Java วาด, เชื่อมต่อและกำหนดเส้นอัตโนมัติในสไลด์ PowerPoint บน Android — ควบคุมคอนเนคเตอร์แบบตรง, แบบโค้งมุมและแบบโค้งได้อย่างเต็มที่"
---
## **บทนำ**

คอนเนคเตอร์ของ PowerPoint คือเส้นพิเศษที่เชื่อมต่อหรือเชื่อมโยงรูปสองรูปเข้าด้วยกันและยังคงติดกับรูปแม้เมื่อรูปถูกย้ายหรือเปลี่ยนตำแหน่งบนสไลด์ที่กำหนด  

คอนเนคเตอร์มักจะเชื่อมต่อกับ *จุดเชื่อมต่อ* (จุดสีเขียว) ซึ่งมีอยู่บนรูปทั้งหมดโดยค่าเริ่มต้น จุดเชื่อมต่อจะปรากฏเมื่อเคอร์เซอร์เข้าใกล้  

*จุดปรับแต่ง* (จุดสีส้ม) ซึ่งมีเฉพาะบนคอนเนคเตอร์บางประเภท ใช้เพื่อปรับตำแหน่งและรูปร่างของคอนเนคเตอร์  

## **ประเภทของคอนเนคเตอร์**

ใน PowerPoint คุณสามารถใช้คอนเนคเตอร์แบบตรง, แบบโคน (มุม) และแบบโค้ง  

Aspose.Slides มีคอนเนคเตอร์เหล่านี้:

| คอนเนคเตอร์ | รูปภาพ | จำนวนจุดปรับแต่ง |
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

## **เชื่อมต่อรูปด้วยคอนเนคเตอร์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AutoShape) สองรูปลงในสไลด์โดยใช้เมธอด `addAutoShape` ของอ็อบเจกต์ `Shapes`
4. เพิ่มคอนเนคเตอร์โดยใช้เมธอด `addConnector` ของอ็อบเจกต์ `Shapes` โดยกำหนดประเภทของคอนเนคเตอร์
5. เชื่อมต่อรูปด้วยคอนเนคเตอร์
6. เรียกเมธอด `reroute` เพื่อใช้เส้นเชื่อมที่สั้นที่สุด
7. บันทึกพรีเซนเทชัน  

โค้ด Java นี้แสดงวิธีการเพิ่มคอนเนคเตอร์ (คอนเนคเตอร์แบบโค้ง) ระหว่างรูปสองรูป (รูปวงรีและสี่เหลี่ยมผืนผ้า):

```Java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงคอลเลกชันรูปทรงสำหรับสไลด์เฉพาะ
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // เพิ่ม autoshape รูปวงรี
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // เพิ่ม autoshape สี่เหลี่ยมผืนผ้า
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // เพิ่มรูปคอนเนคเตอร์ในคอลเลกชันรูปทรงของสไลด์
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // เชื่อมต่อรูปด้วยคอนเนคเตอร์
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // เรียกเมธอด reroute เพื่อตั้งค่าเส้นทางสั้นที่สุดอัตโนมัติระหว่างรูป
    connector.reroute();
    
    // บันทึกงานนำเสนอ
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`เมธอด Connector.reroute` จะทำการกำหนดเส้นทางใหม่ของคอนเนคเตอร์และบังคับให้มันใช้เส้นทางสั้นที่สุดระหว่างรูปต่าง ๆ เพื่อให้บรรลุเป้าหมาย เมธอดอาจเปลี่ยนจุด `setStartShapeConnectionSiteIndex` และ `setEndShapeConnectionSiteIndex` 
{{% /alert %}} 

## **ระบุดจุดเชื่อมต่อ**

หากคุณต้องการให้คอนเนคเตอร์เชื่อมสองรูปโดยใช้จุดเฉพาะบนรูป คุณต้องระบุดจุดเชื่อมต่อที่ต้องการแบบนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/AutoShape) สองรูปลงในสไลด์โดยใช้เมธอด `addAutoShape` ของอ็อบเจกต์ `Shapes`
4. เพิ่มคอนเนคเตอร์โดยใช้เมธอด `addConnector` ของอ็อบเจกต์ `Shapes` โดยกำหนดประเภทของคอนเนคเตอร์
5. เชื่อมต่อรูปด้วยคอนเนคเตอร์
6. ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูป
7. บันทึกพรีเซนเทชัน  

โค้ด Java นี้แสดงการดำเนินการที่ระบุดจุดเชื่อมต่อที่ต้องการ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงคอลเลกชันรูปทรงสำหรับสไลด์เฉพาะ
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // เพิ่ม autoshape รูปวงรี
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // เพิ่ม autoshape สี่เหลี่ยมผืนผ้า
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // เพิ่มรูปคอนเนคเตอร์ในคอลเลกชันรูปทรงของสไลด์
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // เชื่อมต่อรูปด้วยคอนเนคเตอร์
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // กำหนดดัชนีจุดเชื่อมต่อที่ต้องการบนรูปวงรี
    int wantedIndex = 6;

    // ตรวจสอบว่าดัชนีที่ต้องการน้อยกว่า จำนวนดัชนีไซต์สูงสุดหรือไม่
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // กำหนดจุดเชื่อมต่อที่ต้องการบน autoshape รูปวงรี
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // บันทึกงานนำเสนอ
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ปรับจุดคอนเนคเตอร์**

คุณสามารถปรับคอนเนคเตอร์ที่มีอยู่ผ่านจุดปรับแต่งได้ คอนเนคเตอร์ที่มีจุดปรับแต่งเท่านั้นที่สามารถแก้ไขได้ในลักษณะนี้ ดูตารางภายใต้ **[ประเภทของคอนเนคเตอร์](/slides/th/androidjava/connector/#types-of-connectors)**  

### **กรณีง่าย**

พิจารณากรณีที่คอนเนคเตอร์ระหว่างรูปสองรูป (A และ B) ผ่านรูปที่สาม (C):

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

เพื่อหลีกเลี่ยงหรือข้ามรูปที่สาม เราสามารถปรับคอนเนคเตอร์โดยย้ายเส้นแนวตั้งของมันไปทางซ้ายแบบนี้:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **กรณีซับซ้อน**

เพื่อทำการปรับที่ซับซ้อนยิ่งขึ้น คุณต้องคำนึงถึงสิ่งต่อไปนี้:

* จุดปรับของคอนเนคเตอร์เชื่อมโยงอย่างแน่นหนากับสูตรที่คำนวณและกำหนดตำแหน่งของมัน ดังนั้นการเปลี่ยนแปลงตำแหน่งของจุดอาจทำให้รูปร่างของคอนเนคเตอร์เปลี่ยนแปลง  
* จุดปรับของคอนเนคเตอร์ถูกกำหนดเป็นลำดับที่เคร่งครัดในอาเรย์ จุดปรับจะถูกจัดลำดับตั้งแต่จุดเริ่มต้นของคอนเนคเตอร์จนถึงจุดสิ้นสุด  
* ค่าจุดปรับแสดงเป็นเปอร์เซ็นต์ของความกว้าง/ความสูงของรูปร่างคอนเนคเตอร์  
  * รูปร่างถูกกำหนดโดยจุดเริ่มและสิ้นสุดของคอนเนคเตอร์ที่คูณด้วย 1000  
  * จุดแรก, จุดที่สอง, และจุดที่สาม กำหนดเปอร์เซ็นต์จากความกว้าง, ความสูง, และความกว้าง (อีกครั้ง) ตามลำดับ  
* สำหรับการคำนวณที่กำหนดพิกัดของจุดปรับของคอนเนคเตอร์ คุณต้องคำนึงถึงการหมุนและการสะท้อนของคอนเนคเตอร์ด้วย **หมายเหตุ** ว่ามุมการหมุนของคอนเนคเตอร์ทั้งหมดที่แสดงภายใต้ **[ประเภทของคอนเนคเตอร์](/slides/th/androidjava/connector/#types-of-connectors)** เป็น 0  

#### **กรณี 1**

พิจารณากรณีที่วัตถุ text frame สองอันเชื่อมต่อกันผ่านคอนเนคเตอร์:

![connector-shape-complex](connector-shape-complex.png)

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรกในงานนำเสนอ
    ISlide sld = pres.getSlides().get_Item(0);
    // เพิ่มรูปทรงที่จะแนบต่อกันผ่านคอนเนคเตอร์
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // เพิ่มคอนเนคเตอร์
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // กำหนดทิศทางของคอนเนคเตอร์
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // กำหนดสีของคอนเนคเตอร์
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // กำหนดความหนาของเส้นคอนเนคเตอร์
    connector.getLineFormat().setWidth(3);
    
    // เชื่อมต่อรูปทรงเข้าด้วยกันด้วยคอนเนคเตอร์
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // รับจุดปรับของคอนเนคเตอร์
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**การปรับแต่ง**

เราสามารถเปลี่ยนค่าจุดปรับของคอนเนคเตอร์โดยเพิ่มเปอร์เซ็นต์ความกว้างและความสูงที่สอดคล้องกันเพิ่มขึ้น 20% และ 200% ตามลำดับ:

```java
// เปลี่ยนค่าของจุดปรับ
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-1](connector-adjusted-1.png)

เพื่อกำหนดโมเดลที่ให้เราคำนวณพิกัดและรูปร่างของส่วนต่าง ๆ ของคอนเนคเตอร์ เราจะสร้างรูปที่สอดคล้องกับส่วนแนวนอนของคอนเนคเตอร์ที่จุด connector.getAdjustments().get_Item(0):

```java
// วาดส่วนแนวตั้งของคอนเนคเตอร์
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

ผลลัพธ์:

![connector-adjusted-2](connector-adjusted-2.png)

#### **กรณี 2**

ใน **กรณี 1** เราได้สาธิตการปรับคอนเนคเตอร์อย่างง่ายโดยใช้หลักพื้นฐาน ในสถานการณ์ปกติคุณต้องคำนึงถึงการหมุนของคอนเนคเตอร์และการแสดงผลของมัน (ซึ่งตั้งค่าผ่าน connector.getRotation(), connector.getFrame().getFlipH(), และ connector.getFrame().getFlipV()) ตอนนี้เราจะสาธิตกระบวนการ  

ขั้นแรก ให้เพิ่มวัตถุ text frame ใหม่ (**To 1**) ลงในสไลด์ (เพื่อการเชื่อมต่อ) และสร้างคอนเนคเตอร์ (สีเขียว) ใหม่ที่เชื่อมต่อกับวัตถุที่เราสร้างไว้แล้ว

```java
// สร้างอ็อบเจกต์การผูกใหม่
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// สร้างคอนเนคเตอร์ใหม่
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// เชื่อมต่ออ็อบเจกต์โดยใช้คอนเนคเตอร์ที่สร้างใหม่
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// รับจุดปรับของคอนเนคเตอร์
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// เปลี่ยนค่าของจุดปรับ
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

ผลลัพธ์:

![connector-adjusted-3](connector-adjusted-3.png)

ต่อไป ให้สร้างรูปที่สอดคล้องกับส่วนแนวนอนของคอนเนคเตอร์ที่ผ่านจุดปรับของคอนเนคเตอร์ใหม่ connector.getAdjustments().get_Item(0) เราจะใช้ค่าจากข้อมูลคอนเนคเตอร์สำหรับ connector.getRotation(), connector.getFrame().getFlipH(), และ connector.getFrame().getFlipV() แล้วใช้สูตรการแปลงพิกัดที่นิยมสำหรับการหมุนรอบจุด x0:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

ในกรณีของเรา มุมการหมุนของวัตถุคือ 90 องศาและคอนเนคเตอร์แสดงเป็นแนวตั้ง ดังนั้นนี่คือโค้ดที่สอดคล้องกัน:

```java
// บันทึกพิกัดของคอนเนคเตอร์
x = connector.getX();
y = connector.getY();
// แก้ไขพิกัดของคอนเนคเตอร์ในกรณีที่ปรากฏ
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// รับค่าจุดปรับเป็นพิกัด
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  แปลงพิกัดเนื่องจาก Sin(90) = 1 และ Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// กำหนดความก้างของส่วนแนวนอนโดยใช้ค่าจุดปรับที่สอง
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

ผลลัพธ์:

![connector-adjusted-4](connector-adjusted-4.png)

เราได้แสดงการคำนวณที่เกี่ยวข้องกับการปรับอย่างง่ายและจุดปรับที่ซับซ้อน (จุดปรับที่มีมุมการหมุน) ด้วยความรู้ที่ได้คุณสามารถพัฒนาโมเดลของคุณเอง (หรือเขียนโค้ด) เพื่อรับอ็อบเจกต์ `GraphicsPath` หรือแม้กระทั่งตั้งค่าจุดปรับของคอนเนคเตอร์ตามพิกัดสไลด์ที่กำหนด  

## **หามุมของเส้นคอนเนคเตอร์**

1. สร้างอินสแตนซ์ของคลาส
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เข้าถึงรูปร่างเส้นคอนเนคเตอร์
4. ใช้ความกว้างและความสูงของเส้น, ความสูงและความกว้างของเฟรมรูปร่างเพื่อคำนวณมุม  

โค้ด Java นี้แสดงการดำเนินการที่เราคำนวณมุมของรูปร่างเส้นคอนเนคเตอร์:

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

**ฉันจะตรวจสอบได้อย่างไรว่าคอนเนคเตอร์สามารถ 'ติด' กับรูปแบบเฉพาะได้หรือไม่?**

ตรวจสอบว่ารูปร่างเปิดเผย [จุดเชื่อมต่อ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getConnectionSiteCount--) หรือไม่ หากไม่มีหรือจำนวนเป็นศูนย์ การติดจะไม่สามารถทำได้; ในกรณีนั้น ใช้จุดปลายอิสระและกำหนดตำแหน่งด้วยตนเอง ควรตรวจสอบจำนวนไซต์ก่อนทำการแนบ  

**เกิดอะไรขึ้นกับคอนเนคเตอร์หากฉันลบรูปที่เชื่อมต่ออยู่หนึ่งรูป?**

ปลายของคอนเนคเตอร์จะถูกแยกออก; คอนเนคเตอร์จะคงอยู่บนสไลด์เป็นเส้นธรรมดาที่มีจุดเริ่ม/สิ้นสุดอิสระ คุณสามารถลบมันหรือกำหนดการเชื่อมต่อใหม่และหากจำเป็นให้ [reroute](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/connector/#reroute--)  

**การผูกคอนเนคเตอร์จะคงอยู่เมื่อคัดลอกสไลด์ไปยังพรีเซนเทชันอื่นหรือไม่?**

โดยทั่วไปแล้วใช่ หากรูปเป้าหมายถูกคัดลอกพร้อมกัน หากสไลด์ถูกแทรกลงในไฟล์อื่นโดยไม่มีรูปที่เชื่อมต่อ ปลายของคอนเนคเตอร์จะกลายเป็นอิสระและคุณจะต้องเชื่อมต่อใหม่