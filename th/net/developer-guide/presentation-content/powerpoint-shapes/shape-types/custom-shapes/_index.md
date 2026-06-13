---
title: ปรับแต่งรูปร่างการนำเสนอใน .NET
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/net/custom-shape/
keywords:
- รูปร่างกำหนดเอง
- เพิ่มรูปร่าง
- สร้างรูปร่าง
- เปลี่ยนรูปร่าง
- เรขาคณิตรูปร่าง
- เส้นทางเรขาคณิต
- จุดของเส้นทาง
- จุดแก้ไข
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างประกอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งรูปร่างในการพรีเซนเทชันของ Aspose.Slides ด้วยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต แสดงวิธีทำงานกับ `GeometryPath` และ `IGeometryPath` เพื่อแก้ไขรูปร่างที่มีอยู่, ดำเนินการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปร่าง

นอกจากนี้ยังสาธิตวิธีสร้างรูปร่างแบบกำหนดเองและแบบประกอบ, สร้างรูปร่างที่มีมุมโค้ง, ตรวจสอบว่ารูปร่างเรขาคณิตเป็นปิดหรือไม่, และแปลงระหว่าง `GeometryPath` กับ `GraphicsPath` สำหรับสถานการณ์การปรับแต่งเรขาคณิตเพิ่มเติม

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

พิจารณาสี่เหลี่ยมจัตุรัส ใน PowerPoint หากใช้ **edit points** คุณสามารถ

* ย้ายมุมของสี่เหลี่ยมเข้าไปหรือออกมา
* ระบุความโค้งของมุมหรือจุด
* เพิ่มจุดใหม่ให้กับสี่เหลี่ยม
* จัดการจุดบนสี่เหลี่ยม เป็นต้น

โดยพื้นฐาน คุณสามารถทำงานที่อธิบายไว้กับรูปร่างใดก็ได้ การใช้ edit points ทำให้คุณสามารถเปลี่ยนรูปร่างหรือสร้างรูปร่างใหม่จากรูปร่างที่มีอยู่ได้

## **คำแนะนำการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

ก่อนที่คุณจะเริ่มแก้ไขรูปร่างใน PowerPoint ผ่าน edit points คุณอาจต้องพิจารณาข้อควรระวังต่อไปนี้เกี่ยวกับรูปร่าง:

* รูปร่าง (หรือเส้นทางของมัน) อาจเป็นแบบปิดหรือเปิด
* รูปร่างทั้งหมดประกอบด้วยจุดยึดอย่างน้อย 2 จุดที่เชื่อมต่อกันด้วยเส้น
* เส้นสามารถเป็นเส้นตรงหรือเส้นโค้ง จุดยึดกำหนดลักษณะของเส้น
* จุดยึดมีอยู่ในรูปแบบจุดมุม, จุดตรง, หรือจุดเรียบ:
  * จุดมุมคือจุดที่เส้นตรงสองเส้นมาบรรจบกันเป็นมุม
  * จุดเรียบคือจุดที่มีมือจับสองอันอยู่บนเส้นตรงและส่วนของเส้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้มือจับทั้งหมดถูกแยกจากจุดยึดด้วยระยะทางเท่ากัน
  * จุดตรงคือจุดที่มีมือจับสองอันอยู่บนเส้นตรงและส่วนของเส้นเชื่อมต่อกันเป็นโค้งเรียบ ในกรณีนี้มือจับไม่จำเป็นต้องแยกจากจุดยึดด้วยระยะทางเท่ากัน
* โดยการย้ายหรือแก้ไขจุดยึด (ซึ่งเปลี่ยนมุมของเส้น) คุณสามารถเปลี่ยนรูปลักษณ์ของรูปร่างได้

เพื่อแก้ไขรูปร่างใน PowerPoint ผ่าน edit points, **Aspose.Slides** มีคลาส [**GeometryPath**](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath) และอินเทอร์เฟซ [**IGeometryPath**](https://reference.aspose.com/slides/th/net/aspose.slides/igeometrypath) ให้ใช้

* A [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath) ตัวอย่างแสดงเส้นทางเรขาคณิตของอ็อบเจ็กต์ [IGeometryShape](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape)
* เพื่อดึง `GeometryPath` จากอินสแตนซ์ `IGeometryShape` คุณสามารถใช้เมธอด [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/methods/getgeometrypaths)
* เพื่อกำหนด `GeometryPath` ให้กับรูปร่าง คุณสามารถใช้เมธอดเหล่านี้: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/methods/setgeometrypath) สำหรับ *solid shapes* และ [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/th/net/aspose.slides/igeometryshape/methods/setgeometrypaths) สำหรับ *composite shapes*
* เพื่อเพิ่มเซกเมนต์ คุณสามารถใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/igeometrypath)
* โดยใช้คุณสมบัติ [IGeometryPath.Stroke](https://reference.aspose.com/slides/th/net/aspose.slides/igeometrypath/properties/stroke) และ [IGeometryPath.FillMode](https://reference.aspose.com/slides/th/net/aspose.slides/igeometrypath/properties/fillmode) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต
* โดยใช้คุณสมบัติ [IGeometryPath.PathData](https://reference.aspose.com/slides/th/net/aspose.slides/igeometrypath/properties/pathdata) คุณสามารถดึงเส้นทางเรขาคณิตของ `GeometryShape` เป็นอาเรย์ของเซกเมนต์
* เพื่อเข้าถึงตัวเลือกการปรับแต่งเรขาคณิตของรูปร่างเพิ่มเติม คุณสามารถแปลง [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath) ไปเป็น [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
* ใช้เมธอด [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/th/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) และ [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (จากคลาส [ShapeUtil](https://reference.aspose.com/slides/th/net/aspose.slides.util/shapeutil)) เพื่อแปลง [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath) เป็น [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) และกลับกัน

## **การดำเนินการแก้ไขอย่างง่าย**

โค้ด C# นี้แสดงวิธี

**เพิ่มเส้น**ไปที่ส่วนท้ายของเส้นทาง
``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**เพิ่มเส้น**ไปยังตำแหน่งที่ระบุบนเส้นทาง:
``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**เพิ่มเส้นโค้ง Bezier แบบคิวบิก**ที่ส่วนท้ายของเส้นทาง:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**เพิ่มเส้นโค้ง Bezier แบบคิวบิก**ไปยังตำแหน่งที่ระบุบนเส้นทาง:
``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**เพิ่มเส้นโค้ง Bezier แบบควอดราติก**ที่ส่วนท้ายของเส้นทาง:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**เพิ่มเส้นโค้ง Bezier แบบควอดราติก**ไปยังตำแหน่งที่ระบุบนเส้นทาง:
``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**ต่อเติมส่วนโค้งที่กำหนด**ไปยังเส้นทาง:
``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**ปิดรูปภาพปัจจุบัน**ของเส้นทาง:
``` csharp
void CloseFigure();
```
**กำหนดตำแหน่งสำหรับจุดถัดไป**:
``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**ลบเซกเมนต์ของเส้นทาง**ที่ดัชนีที่ระบุ:
``` csharp
void RemoveAt(int index);
```

## **เพิ่มจุดกำหนดเองให้กับรูปร่าง**

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/net/aspose.slides/geometryshape) และตั้งค่าเป็นประเภท [ShapeType.Rectangle](https://reference.aspose.com/slides/th/net/aspose.slides/shapetype)
2. รับอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath) จากรูปร่าง
3. เพิ่มจุดใหม่ระหว่างสองจุดบนสุดของเส้นทาง
4. เพิ่มจุดใหม่ระหว่างสองจุดล่างสุดของเส้นทาง
5. นำเส้นทางไปใช้กับรูปร่าง

โค้ด C# นี้แสดงวิธีเพิ่มจุดกำหนดเองให้กับรูปร่าง:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

## **ลบจุดจากรูปร่าง**

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/net/aspose.slides/geometryshape) และตั้งค่าเป็นประเภท [ShapeType.Heart](https://reference.aspose.com/slides/th/net/aspose.slides/shapetype)
2. รับอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath) จากรูปร่าง
3. ลบเซกเมนต์ของเส้นทาง
4. นำเส้นทางไปใช้กับรูปร่าง

โค้ด C# นี้แสดงวิธีลบจุดจากรูปร่าง:
``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

## **สร้างรูปร่างกำหนดเอง**

1. คำนวณจุดต่าง ๆ สำหรับรูปร่าง
2. สร้างอินสแตนซ์ของคลาส [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath)
3. เติมจุดลงในเส้นทาง
4. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/net/aspose.slides/geometryshape)
5. นำเส้นทางไปใช้กับรูปร่าง

โค้ด C# นี้แสดงวิธีสร้างรูปร่างกำหนดเอง:
``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **สร้างรูปร่างกำหนดเองแบบประกอบ**

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/net/aspose.slides/geometryshape)
2. สร้างอินสแตนซ์แรกของคลาส [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath)
3. สร้างอินสแตนซ์ที่สองของคลาส [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath)
4. นำเส้นทางเหล่านั้นไปใช้กับรูปร่าง

โค้ด C# นี้แสดงวิธีสร้างรูปร่างกำหนดเองแบบประกอบ:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **สร้างรูปร่างกำหนดเองที่มุมโค้ง**

โค้ด C# นี้แสดงวิธีสร้างรูปร่างกำหนดเองที่มุมโค้ง (ด้านใน);
```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

รูปร่างแบบปิดหมายถึงรูปร่างที่ด้านทั้งหมดเชื่อมต่อกันเป็นเส้นขอบเดียวโดยไม่มีช่องว่าง รูปร่างเช่นนี้อาจเป็นรูปทรงเรขาคณิตง่าย ๆ หรือโครงร่างกำหนดเองที่ซับซ้อน ตัวอย่างโค้ดต่อไปนี้แสดงวิธีตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่:
```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **แปลง GeometryPath เป็น GraphicsPath (System.Drawing.Drawing2D)**

1. สร้างอินสแตนซ์ของคลาส [GeometryShape](https://reference.aspose.com/slides/th/net/aspose.slides/geometryshape)
2. สร้างอินสแตนซ์ของคลาส [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) ของเนมสเปซ [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0)
3. แปลงอินสแตนซ์ของ [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) เป็นอินสแทนซ์ของ [GeometryPath](https://reference.aspose.com/slides/th/net/aspose.slides/geometrypath) โดยใช้ [ShapeUtil](https://reference.aspose.com/slides/th/net/aspose.slides.util/shapeutil)
4. นำเส้นทางไปใช้กับรูปร่าง

โค้ด C# นี้—การนำขั้นตอนข้างต้นไปใช้—แสดงกระบวนการแปลงจาก **GeometryPath** ไปเป็น **GraphicsPath**:
``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**จะเกิดอะไรขึ้นกับการเติมสีและเส้นขอบหลังจากแทนที่เรขาคณิต?**

สไตล์จะคงอยู่กับรูปทรง; มีเพียงเส้นรอบรูปที่เปลี่ยน แต่อัตโนมัติการเติมสีและเส้นขอบจะถูกนำไปใช้กับเรขาคณิตใหม่

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้คุณสมบัติ [rotation](https://reference.aspose.com/slides/th/net/aspose.slides/shape/rotation/) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเนื่องจากผูกติดกับระบบพิกัดของรูปเอง

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ "ล็อก" ผลลัพธ์ได้หรือไม่?**

ได้เลย. ส่งออกส่วน [slide](/slides/th/net/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/net/create-shape-thumbnails/) เองเป็นรูปแบบรัสเตอร์; การทำเช่นนี้ทำให้การทำงานต่อกับเรขาคณิตที่ซับซ้อนง่ายขึ้น