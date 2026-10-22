---
title: ปรับแต่งรูปทรงการนำเสนอใน .NET
linktitle: รูปทรงกำหนดเอง
type: docs
weight: 20
url: /th/net/custom-shape/
keywords:
- รูปทรงกำหนดเอง
- เพิ่มรูปทรง
- สร้างรูปทรง
- เปลี่ยนรูปทรง
- เรขาคณิตรูปทรง
- เส้นทางเรขาคณิต
- จุดเส้นทาง
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
description: "สร้างและปรับแต่งรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET: เส้นทางเรขาคณิต, มุมโค้ง, รูปทรงผสม."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปทรงของงานนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปทรงผ่านจุดแก้ไขและเส้นทางเรขาคณิต มันแสดงให้เห็นวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) และ [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) เพื่อแก้ไขรูปทรงที่มีอยู่, ทำการดำเนินการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปทรง

นอกจากนี้ยังสาธิตวิธีสร้างรูปทรงกำหนดเองและรูปทรงผสม, สร้างรูปทรงที่มีมุมโค้ง, ตรวจสอบว่ารูปทรงเรขาคณิตเป็นแบบปิดหรือไม่, และใช้การแปลงแบบเก่าระหว่าง [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) กับ [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) สำหรับกรณีการปรับแต่งเรขาคณิตเพิ่มเติม

## **เปลี่ยนรูปทรงโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยม:

* ย้ายมุมเข้าไปหรือออกไป
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดช่วยให้คุณปรับเส้นรอบรูปของรูปทรงหรือใช้รูปทรงที่มีอยู่เป็นพื้นฐานสำหรับรูปใหม่ได้

## **เคล็ดลับการแก้ไขรูปทรง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปทรงใน PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปทรง (หรือเส้นทางของมัน) อาจเป็นแบบปิดหรือเปิด
* เส้นทางของรูปทรงประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนเส้น
* ส่วนเส้นสามารถเป็นเส้นตรงหรือเส้นโค้ง จุดยึดและจุดควบคุมกำหนดรูปร่างของมัน
* จุดยึดมีอยู่ในรูปแบบมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม ส่วนเส้นที่เชื่อมต่อสามารถมาบรรจบกันเป็นมุม
  * ที่จุดเรียบ จุดควบคุมสองจุดจะอยู่ในแนวเดียวกันและห่างจากจุดยึดเท่ากัน
  * ที่จุดตรง จุดควบคุมสองจุดจะอยู่ในแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจแตกต่างกัน
* การย้ายจุดยึดหรือปรับจุดควบคุมจะเปลี่ยนเส้นรอบรูปของรูปทรง

เพื่อแก้ไขรูปทรง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** ให้คลาส [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) และอินเทอร์เฟซ [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/)

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) แสดงถึงเส้นทางเรขาคณิตของอ็อบเจ็กต์ [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/)
* เพื่อนำ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) มาใช้จากอินสแตนซ์ของ [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), คุณสามารถใช้เมธอด [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/)
* เพื่อตั้งค่า [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ให้กับรูปทรง, คุณสามารถใช้เมธอดเหล่านี้: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) สำหรับรูปที่มีเส้นทางเดียวและ [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) สำหรับรูปที่มีหลายเส้นทาง
* เพื่อเพิ่มส่วนเส้น, คุณสามารถใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/)
* ด้วยคุณสมบัติ [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) และ [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต
* ด้วยคุณสมบัติ [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) เป็นอาร์เรย์ของส่วนเส้น
* ในเวอร์ชันเก่าที่สนับสนุนเมธอดแปลงด้านล่าง, คุณสามารถแปลง [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ไปเป็น [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)
* ใช้เมธอด [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) และ [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (จากคลาส [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) เพื่อแปลงระหว่าง [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) กับ [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath)

## **การดำเนินการแก้ไขแบบง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การโอเวอร์โหลดที่รับดัชนีจะใส่ส่วนเส้นที่ตำแหน่งศูนย์ฐานในอาเรย์ของส่วนเส้น

| การดำเนินการ | เมธอด |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบลูกบาศก์ที่มีจุดควบคุมสองจุดและจุดสิ้นสุด | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบกำลังสองที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| เพิ่มส่วนโค้งวงรีโดยระบุขนาดและมุมเป็นองศา | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| ปิดรูปแบบปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| ตั้งค่าจุดเริ่มต้นของรูปแบบ | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| ลบส่วนเส้นที่ตำแหน่งดัชนีศูนย์ฐาน | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **เพิ่มจุดกำหนดเองลงในรูปทรง**

ตัวอย่างนี้ใส่จุดสองจุดลงในรูปสี่เหลี่ยมโดยใช้ [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) และนำเส้นทางที่แก้ไขไปใช้ด้วย [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) พิกัดเป็นค่าท้องถิ่นของรูปทรง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของรูป, ห่างจากด้านซ้าย 100 จุดและด้านบน 50 จุด ดัชนีส่วนเส้น 1 และ 4 จะวางจุดบนขอบบนและล่าง, ดึงขอบเหล่านั้นเข้าไป

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **ลบจุดออกจากรูปทรง**

ตัวอย่างนี้เปลี่ยนโครงร่างหัวใจโดยลบส่วนเส้นที่ตำแหน่งดัชนีศูนย์ฐาน 2 ด้วย [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) การนำเส้นทางที่แก้ไขไปใช้ด้วย [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) จะอัปเดตโครงร่างของรูปทรง

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **สร้างรูปทรงกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้ารูปด้วย [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดปลายและส่วนโค้ง; ขั้นตอน 72 องศาจะเว้นระยะห่างดาวห้ารูปเท่า ๆ กัน เส้นทางถูกปิดด้วย [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) แล้วนำไปใช้กับรูปสี่เหลี่ยมโดยใช้ [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) แทนโครงร่างเดิม

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **สร้างรูปทรงกำหนดเองแบบผสม**

ตัวอย่างนี้กำหนดสองอ็อบเจ็กต์ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ที่ปิดสำหรับส่วนบนและล่างของรูปทรง การนำสองเส้นทางไปใช้ด้วย [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) จะสร้างรูปทรงผสมเดียวที่มีช่องว่างตัดผ่านช่วงกลางของรูป

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **สร้างรูปทรงกำหนดเองพร้อมมุมโค้ง**

ตัวอย่างนี้ผสมส่วนเส้นตรงกับ [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) เพื่อสร้างรูปทรงที่มุมโค้งเข้าแต่ละมุม กำหนดขนาดมุมแต่ละมุมเป็นความกว้างและความสูงของเส้นโค้งเป็นจุด, และการสวิง -90 องศาจะวาดส่วนโค้งไตรมาสของวงรีทวนเข็มนาฬิกา เส้นทางที่เสร็จสมบูรณ์จะนำไปใช้ด้วย [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) แล้วบันทึกการนำเสนอเป็นรูปแบบ PPTX

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าจะจบด้วยส่วนเส้นปิดหรือไม่ มันอ่าน [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) และเปรียบเทียบคำสั่งส่วนเส้นสุดท้ายของ [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) กับ [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่างเปล่า ตัวตรวจสอบจะดูคำสั่งสุดท้ายของแต่ละเส้นทาง; มันไม่ได้ตรวจสอบทุกรูปย่อยภายในเส้นทาง ตัวอย่างพิมพ์ `True` สำหรับสี่เหลี่ยม

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **สกัดและตรวจสอบส่วนประกอบของรูปทรง**

ใช้เมธอด [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) เพื่อสแกนรูปทรงที่มีอยู่เป็นส่วนประกอบที่บรรจุจุดเส้นทางและประเภทจุด แปลงแต่ละ [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) ที่ได้เป็น [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) เพื่ออ่านอาร์เรย์ [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) และ [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์โครงร่างหรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง

ตัวอย่างเปิดงานนำเสนอ, ค้นหารูปเรขาคณิตแรกโดยตรงบนสไลด์แรก, และพิมพ์ส่วนเส้นของมัน ใช้งานนำเสนอที่มีรูปที่มีส่วนเส้นตรงและส่วนโค้งเพื่อดูผลลัพธ์ของทั้งสองประเภท ไม่ได้ค้นหาในกลุ่มย่อย

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // เก็บประเภทส่วนเส้นไว้, ไม่รวมแฟล็ก.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // ใช้จุดควบคุมทั้งสองจุดและจุดสิ้นสุด.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

อาร์เรย์สอดคล้องตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของจุดนั้น ประเภท `0` เริ่มรูป, ประเภท `1` วาดเส้นจากจุดก่อนหน้ามาถึงจุดปัจจุบัน ส่วนเส้น Bézier แบบลูกบาศก์เริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` สามรายการต่อเนื่อง: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่ ลูปจะอ่านสามรายการนี้พร้อมกันและตรวจสอบจุดสิ้นสุดเพื่อดูว่าปิดหรือไม่

ประเภทจุดยังมีค่าสถานะด้วย ให้ทำ Mask ด้วย `0x07` เพื่อตรวจจับประเภทส่วนเส้น, และทดสอบ `0x80` แยกต่างหากเพื่อค้นหาเส้นทางย่อยที่ปิด ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดสิ้นสุดเส้นที่ปิดเส้นทางย่อย, `131` (`0x83`) หมายถึงจุดสิ้นสุด Bézier ที่ปิดเส้นทาง ยกเว้นการเปรียบเทียบค่าดิบกับ `1` หรือ `3` จะทำให้พลาดกรณีเหล่านี้ ค่าสถานะอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่ส่งผลต่อประเภทส่วนเส้นพื้นฐาน

**พิกัดและการแปลง** จุดวัดเป็นจุด (1/72 นิ้ว) โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง สำหรับรูปที่ไม่ได้จัดกลุ่ม, พิกัดที่สกัดมาแล้วรวมตำแหน่ง [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) ของรูปและสะท้อนความกว้างและความสูงปัจจุบัน ตัวอย่างสี่เหลี่ยมที่ไม่มีการหมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบโครงร่าง `(100, 200)`–`(220, 280)` อย่าเพิ่มตำแหน่งของรูปอีกครั้ง ให้ลบค่า X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน

จุดที่สกัดไม่รวมการหมุนของรูป ([Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)) หรือการพลิกแนวนอนและแนวตั้ง เพื่อให้ได้โครงร่างที่แสดงผลตามจริง ต้องนำการแปลงเหล่านี้ไปใช้รอบศูนย์กลางของรูป สำหรับรูปที่อยู่ในกลุ่ม ต้องคำนึงถึงการแม็พพิกัดและการแปลงของกลุ่ม; อย่าสมมติว่าจุดที่สกัดเป็นพิกัดสุดท้ายบนสไลด์หรือทำการแปลหรือสเกลซ้ำหากมันได้ถูกสะท้อนไว้แล้วในกรอบของลูก

**การตรวจสอบเทียบกับการแก้ไข** อาร์เรย์ที่สกัดอธิบายโครงร่าง; การเปลี่ยนแปลงอาร์เรย์เหล่านี้จะไม่อัปเดตรูปต้นฉบับ ใช้วิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาร์เรย์จุด/ประเภท ใช้เมธอด [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปหรือเมื่อคุณต้องการแก้ไขเรขาคณิตของรูป ใช้เมธอด [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) หรือ [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) เพื่อใช้เส้นทางที่แก้ไข

## **แปลง GeometryPath ไปเป็น GraphicsPath (System.Drawing.Drawing2D)**

ตัวอย่างต่อไปนี้ต้องใช้แอสเซมบลี Aspose.Slides for .NET รุ่นเก่าที่สนับสนุน [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), เช่น เวอร์ชัน 25.10, และสภาพแวดล้อม Windows ที่มี `System.Drawing.Common` เมธอดแปลงถูกลบออกใน [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/)

ตัวอย่างนี้รวมโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต โครงร่างของ [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) ถูกตั้งค่าให้ปิดการเติมสี [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) เก็บโครงร่างข้อความซึ่ง [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) แปลงเป็นเส้นทางเรขาคณิตที่เต็ม การใช้ทั้งสองเส้นทางกับ [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) จะสร้างรูปเดียวที่ประกอบด้วยสี่เหลี่ยมและข้อความ สำหรับการแปลงในทิศทางตรงกันข้าม ให้ใช้ [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/)

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **FAQ**

**การเติมสีและโครงร่างจะเปลี่ยนแปลงอย่างไรหลังจากแทนที่เรขาคณิต?**

สไตล์จะคงอยู่กับรูปทรง; เพียงแต่โครงร่างจะเปลี่ยนแปลง การเติมสีและโครงร่างจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่

**ฉันจะหมุนรูปทรงกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้คุณสมบัติ [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) ของรูป; เรขาคณิตจะหมุนพร้อมกับรูปเพราะผูกกับระบบพิกัดของรูปเอง

**ฉันสามารถแปลงรูปทรงกำหนดเองเป็นภาพเพื่อ “ล็อก” ผลลัพธ์ได้หรือไม่?**

ได้. ให้ส่งออก [slide](/slides/th/net/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/net/create-shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; วิธีนี้ทำให้งานกับเรขาคณิตที่ซับซ้อนต่อไปง่ายขึ้น