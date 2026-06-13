---
title: จัดการคอนเนคเตอร์ในพรีเซนเทชันด้วย .NET
linktitle: คอนเนคเตอร์
type: docs
weight: 10
url: /th/net/connector/
keywords:
- คอนเนคเตอร์
- ประเภทคอนเนคเตอร์
- จุดคอนเนคเตอร์
- เส้นคอนเนคเตอร์
- มุมคอนเนคเตอร์
- เชื่อมต่อรูปทรง
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "ช่วยให้แอป .NET สามารถวาด, เชื่อมต่อและกำหนดเส้นทางอัตโนมัติของเส้นในสไลด์ PowerPoint — ควบคุมคอนเนคเตอร์แบบตรง, แบบหัวศอก และแบบโค้งได้อย่างเต็มที่"
---
## **บทนำ**

คอนเนคเตอร์ใน PowerPoint คือเส้นพิเศษที่เชื่อมต่อหรือเชื่อมโยงรูปทรงสองรูปเข้าด้วยกันและยังคงติดกับรูปทรงแม้เมื่อรูปทรงเหล่านั้นถูกย้ายหรือเปลี่ยนตำแหน่งบนสไลด์ที่กำหนด  

คอนเนคเตอร์โดยทั่วไปจะเชื่อมต่อกับ *จุดเชื่อมต่อ* (จุดสีเขียว) ซึ่งมีอยู่บนรูปทรงทั้งหมดโดยค่าเริ่มต้น จุดเชื่อมต่อจะปรากฏเมื่อเคอร์เซอร์เข้าใกล้  

* จุดปรับแต่ง* (จุดสีส้ม) ซึ่งมีเฉพาะบนคอนเนคเตอร์บางประเภท ใช้เพื่อปรับตำแหน่งและรูปร่างของคอนเนคเตอร์  

## **ประเภทของคอนเนคเตอร์**

ใน PowerPoint คุณสามารถใช้คอนเนคเตอร์สายตรง, คอนเนคเตอร์แบบหัวศอก (มุม), และคอนเนคเตอร์โค้ง  

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

## **เชื่อมต่อรูปทรงด้วยคอนเนคเตอร์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่มสองรูปแบบ [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) ลงในสไลด์โดยใช้เมธอด `AddAutoShape` ที่เปิดให้บริการโดยอ็อบเจ็กต์ `Shapes`  
1. เพิ่มคอนเนคเตอร์โดยใช้เมธอด `AddConnector` ที่เปิดให้บริการโดยอ็อบเจ็กต์ `Shapes` โดยกำหนดประเภทของคอนเนคเตอร์  
1. เชื่อมต่อรูปทรงด้วยคอนเนคเตอร์  
1. เรียกเมธอด `Reroute` เพื่อใช้เส้นทางการเชื่อมที่สั้นที่สุด  
1. บันทึกพรีเซนเทชัน  

โค้ด C# นี้แสดงวิธีเพิ่มคอนเนคเตอร์ (คอนเนคเตอร์แบบงอ) ระหว่างรูปทรงสองรูป (วงรีและสี่เหลี่ยม):

```c#
// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่เป็นไฟล์ PPTX
using (Presentation input = new Presentation())
{                
    // เข้าถึงคอลเลกชันของรูปทรงสำหรับสไลด์ที่ระบุ
    IShapeCollection shapes = input.Slides[0].Shapes;

    // เพิ่มออโตชิพรูปวงรี
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // เพิ่มออโตชิพรูปสี่เหลี่ยม
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // เพิ่มรูปคอนเนคเตอร์ไปยังคอลเลกชันรูปทรงของสไลด์
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // เชื่อมต่อรูปทรงโดยใช้คอนเนคเตอร์
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // เรียกเมธอด reroute เพื่อกำหนดเส้นทางอัตโนมัติที่สั้นที่สุดระหว่างรูปทรง
    connector.Reroute();

    // บันทึกพรีเซนเทชัน
    input.Save("Shapes-connector.pptx", SaveFormat.Pptx);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`เมธอด Connector.Reroute` จะทำการเปลี่ยนเส้นทางของคอนเนคเตอร์และบังคับให้มันเดินตามเส้นทางที่สั้นที่สุดระหว่างรูปทรง เพื่อให้บรรลุเป้าหมาย เมธอดอาจเปลี่ยนค่าจุด `StartShapeConnectionSiteIndex` และ `EndShapeConnectionSiteIndex` 
{{% /alert %}} 

## **ระบุจุดเชื่อมต่อ**

หากคุณต้องการให้คอนเนคเตอร์เชื่อมสองรูปทรงโดยใช้จุดเฉพาะบนรูปทรง คุณต้องระบุจุดเชื่อมต่อที่ต้องการดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เพิ่มสองรูปแบบ [AutoShape](https://reference.aspose.com/slides/th/net/aspose.slides/autoshape/) ลงในสไลด์โดยใช้เมธอด `AddAutoShape` ที่เปิดให้บริการโดยอ็อบเจ็กต์ `Shapes`  
1. เพิ่มคอนเนคเตอร์โดยใช้เมธอด `AddConnector` ที่เปิดให้บริการโดยอ็อบเจ็กต์ `Shapes` โดยกำหนดประเภทของคอนเนคเตอร์  
1. เชื่อมต่อรูปทรงด้วยคอนเนคเตอร์  
1. ตั้งค่าจุดเชื่อมต่อที่ต้องการบนรูปทรง  
1. บันทึกพรีเซนเทชัน  

โค้ด C# นี้สาธิตการระบุจุดเชื่อมต่อที่ต้องการ:

```c#
// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่เป็นไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
    // เข้าถึงคอลเลกชันของรูปทรงสำหรับสไลด์ที่ระบุ
    IShapeCollection shapes = presentation.Slides[0].Shapes;

    // เพิ่มรูปคอนเนคเตอร์ไปยังคอลเลกชันรูปทรงของสไลด์
    IConnector connector = shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    // เพิ่มออโตชิพรูปวงรี
    IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // เพิ่มออโตชิพรูปสี่เหลี่ยม
    IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

    // เชื่อมต่อรูปทรงโดยใช้คอนเนคเตอร์
    connector.StartShapeConnectedTo = ellipse;
    connector.EndShapeConnectedTo = rectangle;

    // ตั้งค่าดัชนีจุดเชื่อมต่อที่ต้องการบนรูปวงรี
    uint wantedIndex = 6;

    // ตรวจสอบว่าดัชนีที่ต้องการน้อยกว่าจำนวนจุดเชื่อมต่อสูงสุดหรือไม่
    if (ellipse.ConnectionSiteCount > wantedIndex)
    {
        // ตั้งค่าจุดเชื่อมต่อที่ต้องการบนออโตชิพรูปวงรี
        connector.StartShapeConnectionSiteIndex = wantedIndex;
    }

    // บันทึกพรีเซนเทชัน
    presentation.Save("Connecting_Shape_on_desired_connection_site_out.pptx", SaveFormat.Pptx);
}
```

## **ปรับจุดคอนเนคเตอร์**

คุณสามารถปรับคอนเนคเตอร์ที่มีอยู่ได้ผ่านจุดปรับแต่งของมัน คอนเนคเตอร์ที่มีจุดปรับแต่งเท่านั้นที่สามารถแก้ไขได้ในลักษณะนี้ ดูตารางภายใต้ **[ประเภทของคอนเนคเตอร์.](/slides/th/net/connector/#types-of-connectors)**  

### **กรณีง่าย**

พิจารณากรณีที่คอนเนคเตอร์ระหว่างรูปทรงสองรูป (A และ B) ผ่านรูปทรงที่สาม (C):

![connector-obstruction](connector-obstruction.png)

```c#
Presentation pres = new Presentation();
ISlide sld = pres.Slides[0];
IShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
IShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
IShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
 
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);
 
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
 
connector.StartShapeConnectedTo = shapeFrom;
connector.EndShapeConnectedTo = shapeTo;
connector.StartShapeConnectionSiteIndex = 2;
```

เพื่อหลีกเลี่ยงหรือข้ามรูปทรงที่สาม เราสามารถปรับคอนเนคเตอร์โดยย้ายเส้นแนวตั้งไปด้านซ้ายดังนี้:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```c#
IAdjustValue adj2 = connector.Adjustments[1];
adj2.RawValue += 10000;
```

### **กรณีซับซ้อน** 

เพื่อทำการปรับที่ซับซ้อนมากขึ้น คุณต้องคำนึงถึงสิ่งต่อไปนี้:

* จุดปรับของคอนเนคเตอร์เชื่อมโยงอย่างใกล้ชิดกับสูตรที่คำนวณและกำหนดตำแหน่งของมัน ดังนั้นการเปลี่ยนแปลงตำแหน่งของจุดอาจทำให้รูปร่างของคอนเนคเตอร์เปลี่ยนแปลง  
* จุดปรับแต่งของคอนเนคเตอร์ถูกกำหนดในลำดับที่เคร่งครัดในอาร์เรย์ จุดปรับแต่งจะถูกลำดับเลขตั้งแต่จุดเริ่มต้นของคอนเนคเตอร์ไปจนถึงจุดสิ้นสุด  
* ค่าของจุดปรับแต่งสะท้อนเปอร์เซ็นต์ของความกว้าง/ความสูงของรูปทรงคอนเนคเตอร์  
  * รูปทรงถูกกำหนดโดยจุดเริ่มต้นและสิ้นสุดของคอนเนคเตอร์ที่คูณด้วย 1000  
  * จุดแรก, จุดที่สอง, และจุดที่สามกำหนดเปอร์เซ็นต์จากความกว้าง, จากความสูง, และจากความกว้าง (อีกครั้ง) ตามลำดับ  
* สำหรับการคำนวณที่กำหนดพิกัดของจุดปรับแต่งของคอนเนคเตอร์ คุณต้องคำนึงถึงการหมุนของคอนเนคเตอร์และการสะท้อนของมัน **หมายเหตุ** ว่ามุมการหมุนของคอนเนคเตอร์ทั้งหมดที่แสดงภายใต้ **[ประเภทของคอนเนคเตอร์](/slides/th/net/connector/#types-of-connectors)** คือ 0  

#### **กรณีที่ 1**

พิจารณากรณีที่ออบเจ็กต์กรอบข้อความสองออบเจ็กต์เชื่อมต่อกันผ่านคอนเนคเตอร์:

![connector-shape-complex](connector-shape-complex.png)

```c#
// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
// ดึงสไลด์แรกในพรีเซนเทชัน
ISlide sld = pres.Slides[0];
// เพิ่มรูปทรงที่จะเชื่อมต่อกันผ่านคอนเนคเตอร์
IAutoShape shapeFrom = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
shapeFrom.TextFrame.Text = "From";
IAutoShape shapeTo = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
shapeTo.TextFrame.Text = "To";
// เพิ่มคอนเนคเตอร์
IConnector connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
// ระบุทิศทางของคอนเนคเตอร์
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
// ระบุสีของคอนเนคเตอร์
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
// ระบุความหนาของเส้นคอนเนคเตอร์
connector.LineFormat.Width = 3;

// เชื่อมรูปทรงเข้าด้วยกันด้วยคอนเนคเตอร์
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = shapeTo;
connector.EndShapeConnectionSiteIndex = 2;

// ดึงจุดปรับแต่งของคอนเนคเตอร์
IAdjustValue adjValue_0 = connector.Adjustments[0];
IAdjustValue adjValue_1 = connector.Adjustments[1];
```

**การปรับ**  

เราสามารถเปลี่ยนค่าจุดปรับของคอนเนคเตอร์โดยเพิ่มเปอร์เซ็นต์ความกว้างและความสูงที่สอดคล้องกันโดยเพิ่มขึ้น 20% และ 200% ตามลำดับ:

```c#
// เปลี่ยนค่าของจุดปรับแต่ง
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

ผลลัพธ์:

![connector-adjusted-1](connector-adjusted-1.png)

เพื่อกำหนดโมเดลที่ให้เราคำนวณพิกัดและรูปร่างของส่วนต่าง ๆ ของคอนเนคเตอร์ ลองสร้างรูปทรงที่สอดคล้องกับส่วนแนวนอนของคอนเนคเตอร์ที่จุด connector.Adjustments[0]:

```c#
// วาดส่วนประกอบแนวตั้งของคอนเนคเตอร์

float x = connector.X + connector.Width * adjValue_0.RawValue / 100000;
float y = connector.Y;
float height = connector.Height * adjValue_1.RawValue / 100000;
sld.Shapes.AddAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

ผลลัพธ์:

![connector-adjusted-2](connector-adjusted-2.png)

#### **กรณีที่ 2**

ใน **กรณีที่ 1** เราได้สาธิตการปรับคอนเนคเตอร์แบบง่ายโดยใช้หลักพื้นฐาน ในสถานการณ์ปกติคุณต้องคำนึงถึงการหมุนของคอนเนคเตอร์และการแสดงผลของมัน (ซึ่งถูกตั้งค่าโดย connector.Rotation, connector.Frame.FlipH, และ connector.Frame.FlipV) เราจะสาธิตกระบวนการต่อไป  

ขั้นแรก ให้เพิ่มออบเจ็กต์กรอบข้อความใหม่ (**To 1**) ลงในสไลด์ (เพื่อการเชื่อมต่อ) และสร้างคอนเนคเตอร์ (สีเขียว) ใหม่ที่เชื่อมต่อกับออบเจ็กต์ที่เราสร้างไว้ก่อนหน้า:

```c#
// สร้างอ็อบเจ็กต์ binding ใหม่
IAutoShape shapeTo_1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.TextFrame.Text = "To 1";
// สร้างคอนเนคเตอร์ใหม่
connector = sld.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
// เชื่อมต่ออ็อบเจ็กต์โดยใช้คอนเนคเตอร์ที่สร้างใหม่
connector.StartShapeConnectedTo = shapeFrom;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = shapeTo_1;
connector.EndShapeConnectionSiteIndex = 3;
// ดึงจุดปรับแต่งของคอนเนคเตอร์
adjValue_0 = connector.Adjustments[0];
adjValue_1 = connector.Adjustments[1];
// เปลี่ยนค่าของจุดปรับแต่ง 
adjValue_0.RawValue += 20000;
adjValue_1.RawValue += 200000;
```

ผลลัพธ์:

![connector-adjusted-3](connector-adjusted-3.png)

ต่อมา ให้สร้างรูปทรงที่สอดคล้องกับส่วนแนวนอนของคอนเนคเตอร์ที่ผ่านจุดปรับของคอนเนคเตอร์ใหม่ connector.Adjustments[0] เราจะใช้ค่าจากข้อมูลคอนเนคเตอร์สำหรับ connector.Rotation, connector.Frame.FlipH, และ connector.Frame.FlipV แล้วนำสูตรการแปลงพิกัดสำหรับการหมุนรอบจุด x0 ที่นิยมใช้มาใช้:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

ในกรณีของเรา มุมการหมุนของออบเจ็กต์คือ 90 องศาและคอนเนคเตอร์แสดงในแนวตั้ง ดังนั้นโค้ดที่สอดคล้องคือ:

```c#
// บันทึกพิกัดของคอนเนคเตอร์
x = connector.X;
y = connector.Y;
// ปรับแก้พิกัดของคอนเนคเตอร์ในกรณีที่มันแสดง
if (connector.Frame.FlipH == NullableBool.True)
{
    x += connector.Width;
}
if (connector.Frame.FlipV == NullableBool.True)
{
    y += connector.Height;
}
// นำค่าจุดปรับแต่งเป็นพิกัด
x += connector.Width * adjValue_0.RawValue / 100000;
// แปลงพิกัดเนื่องจาก Sin(90) = 1 และ Cos(90) = 0
float xx = connector.Frame.CenterX - y + connector.Frame.CenterY;
float yy = x - connector.Frame.CenterX + connector.Frame.CenterY;
// กำหนดความกว้างของส่วนแนวนอนโดยใช้ค่าจุดปรับแต่งที่สอง
float width = connector.Height * adjValue_1.RawValue / 100000;
IAutoShape shape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

```

ผลลัพธ์:

![connector-adjusted-4](connector-adjusted-4.png)

เราได้สาธิตการคำนวณที่เกี่ยวกับการปรับอย่างง่ายและจุดปรับที่ซับซ้อน (จุดปรับที่มีมุมการหมุน) ด้วยความรู้ที่ได้คุณสามารถพัฒนาโมเดลของคุณเอง (หรือเขียนโค้ด) เพื่อรับอ็อบเจ็กต์ `GraphicsPath` หรือแม้แต่ตั้งค่าค่าจุดปรับของคอนเนคเตอร์ตามพิกัดสไลด์เฉพาะ  

## **ค้นหามุมของเส้นคอนเนคเตอร์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. เข้าถึงรูปทรงเส้นคอนเนคเตอร์  
1. ใช้ความกว้าง, ความสูง, ความสูงของเฟรมรูปทรง, และความกว้างของเฟรมรูปทรงเพื่อคำนวณมุม  

โค้ด C# นี้สาธิตการคำนวณมุมสำหรับรูปทรงเส้นคอนเนคเตอร์:

```c#
public static void Run()
{
    Presentation pres = new Presentation("ConnectorLineAngle.pptx");
    Slide slide = (Slide)pres.Slides[0];
    Shape shape;
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        double dir = 0.0;
        shape = (Shape)slide.Shapes[i];
        if (shape is AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.ShapeType == ShapeType.Line)
            {
                dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
            }
        }
        else if (shape is Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.Width, ashp.Height, Convert.ToBoolean(ashp.Frame.FlipH), Convert.ToBoolean(ashp.Frame.FlipV));
        }

        Console.WriteLine(dir);
    }

}
public static double getDirection(float w, float h, bool flipH, bool flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.Atan2(endYAxisY, endYAxisX) - Math.Atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **FAQ**

**ฉันจะทราบได้อย่างไรว่าคอนเนคเตอร์สามารถ 'ติด' กับรูปทรงเฉพาะได้หรือไม่?**  
ตรวจสอบว่ารูปทรงเปิดให้ใช้ [จุดเชื่อมต่อ](https://reference.aspose.com/slides/th/net/aspose.slides/shape/connectionsitecount/) หรือไม่ หากไม่มีหรือจำนวนเป็นศูนย์ การติดไม่สามารถทำได้; ในกรณีนั้นให้ใช้จุดสิ้นสุดอิสระและกำหนดตำแหน่งด้วยตนเอง การตรวจสอบจำนวนจุดเชื่อมต่อก่อนทำการเชื่อมถือเป็นสิ่งสมเหตุสมผล  

**จะเกิดอะไรขึ้นกับคอนเนคเตอร์หากฉันลบหนึ่งในรูปทรงที่เชื่อมต่อ?**  
หัวปลายของคอนเนคเตอร์จะถูกแยกออก; คอนเนคเตอร์จะคงอยู่บนสไลด์เป็นเส้นธรรมดาที่มีจุดเริ่มต้น/จบอิสระ คุณสามารถลบมันหรือกำหนดการเชื่อมต่อใหม่และหากต้องการก็สามารถ [เปลี่ยนเส้นทาง](https://reference.aspose.com/slides/th/net/aspose.slides/connector/reroute/) ได้  

**การเชื่อมต่อของคอนเนคเตอร์จะถูกเก็บรักษาไว้เมื่อคัดลอกสไลด์ไปยังพรีเซนเทชันอื่นหรือไม่?**  
โดยทั่วไปแล้วใช่ หากรูปทรงเป้าหมายถูกคัดลอกไปด้วย หากสไลด์ถูกแทรกเข้าไฟล์อื่นโดยไม่มีรูปทรงที่เชื่อมต่ออยู่ หัวปลายจะกลายเป็นอิสระและคุณจะต้องเชื่อมต่อใหม่  