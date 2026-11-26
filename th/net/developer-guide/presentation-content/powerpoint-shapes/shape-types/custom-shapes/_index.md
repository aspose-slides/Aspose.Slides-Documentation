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
- เรขาคณิตของรูปทรง
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
description: "สร้างและปรับแต่งรูปทรงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET: เส้นทางเรขาคณิต, มุมโค้ง, รูปทรงประกอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปทรงการนำเสนอใน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปทรงผ่านจุดแก้ไขและเส้นทางเรขาคณิต มันแสดงวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) และ [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) เพื่อแก้ไขรูปทรงที่มีอยู่, ทำการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปทรง

นอกจากนี้ยังสาธิตวิธีสร้างรูปทรงแบบกำหนดเองและแบบประกอบ, สร้างรูปทรงที่มีมุมโค้ง, ตรวจสอบว่ารูปทรงเรขาคณิตเป็นแบบปิดหรือไม่, และใช้การแปลงแบบเก่าระหว่าง [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) และ [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) สำหรับสถานการณ์การปรับแต่งเรขาคณิตเพิ่มเติม

## **เปลี่ยนรูปทรงโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยมจัตุรัส:

* ย้ายมุมเข้าหรือออกจากศูนย์กลาง.
* ปรับความโค้งที่จุดหนึ่ง.
* เพิ่มจุดใหม่.

การแก้ไขจุดทำให้คุณสามารถปรับเปลี่ยนโครงร่างของรูปทรงหรือใช้รูปทรงที่มีอยู่เป็นพื้นฐานสำหรับรูปแบบใหม่ได้.

## **เคล็ดลับการแก้ไขรูปทรง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปทรงใน PowerPoint โปรดจำแนวคิดต่อไปนี้ไว้ในใจ:

* รูปทรง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้.
* เส้นทางของรูปทรงประกอบด้วยจุดยึดที่เชื่อมต่อด้วยส่วนต่าง ๆ.
* ส่วนหนึ่งอาจเป็นเส้นตรงหรือโค้ง จุดยึดและตัวควบคุมกำหนดรูปร่างของมัน.
* จุดยึดมีรูปแบบเป็นจุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม, ส่วนที่เชื่อมต่อกันสามารถพบกันเป็นมุม.
  * ที่จุดเรียบ, ตัวควบคุมสองตัวจะอยู่ในแนวเดียวกันและห่างจากจุดยึดเท่ากัน.
  * ที่จุดตรง, ตัวควบคุมสองตัวอยู่ในแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจต่างกัน.
* การย้ายจุดยึดหรือปรับตัวควบคุมของมันจะเปลี่ยนโครงร่างของรูปทรง.

เพื่อแก้ไขรูปทรง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** ให้คลาส [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) และอินเทอร์เฟซ [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) แสดงเส้นทางเรขาคณิตของอ็อบเจ็กต์ [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) คุณสามารถใช้เมธอด [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* เพื่อตั้งค่า [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ให้กับรูปทรง, คุณสามารถใช้เมธอดต่อไปนี้: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) สำหรับรูปทรงที่มีเส้นทางเดียวและ [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) สำหรับรูปทรงที่มีหลายเส้นทาง.
* เพื่อเพิ่มส่วน, คุณสามารถใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* โดยใช้คุณสมบัติ [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) และ [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) คุณสามารถตั้งค่าลักษณะการแสดงผลของเส้นทางเรขาคณิต.
* โดยใช้คุณสมบัติ [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) เป็นอาเรย์ของส่วนของเส้นทาง.
* ในเวอร์ชันเก่าที่สนับสนุนเมธอดการแปลงด้านล่าง, คุณสามารถแปลง [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ไปเป็น [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* ใช้เมธอด [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) และ [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (จากคลาส [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) เพื่อแปลงระหว่าง [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) และ [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต การโอเวอร์โหลดที่รับดัชนีจะใส่ส่วนในตำแหน่งศูนย์ฐานในอาเรย์ส่วนของเส้นทาง.

| การดำเนินการ | เมธอด |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| เพิ่มหรือแทรกเส้นโค้งคิวบิก Bézier พร้อมจุดควบคุมสองจุดและจุดสิ้นสุด. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| เพิ่มหรือแทรกเส้นโค้งควอดราติก Bézier พร้อมจุดควบคุมหนึ่งจุดและจุดสิ้นสุด. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| เพิ่มโค้งวงรีตามมิติและมุมที่ระบุเป็นองศา. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| ปิดรูปภาพปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| ตั้งค่าจุดเริ่มต้นของรูปภาพ. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| ลบส่วนที่ตำแหน่งดัชนีศูนย์ฐาน. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **เพิ่มจุดกำหนดเองให้กับรูปทรง**

ตัวอย่างนี้แทรกสองจุดลงในรูปสี่เหลี่ยมโดยใช้ [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) และใช้เส้นทางที่แก้ไขกับ [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). พิกัดเป็นค่าท้องถิ่นของรูปทรง: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของรูป, ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด. ดัชนีส่วนที่ 1 และ 4 วางจุดเหล่านี้บนขอบบนและขอบล่าง, ดึงขอบเหล่านั้นเข้าหากลาง.

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

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจกโดยการลบส่วนที่ตำแหน่งดัชนีศูนย์ฐาน 2 ด้วย [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). การใช้เส้นทางที่แก้ไขด้วย [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) จะอัปเดตคอนทัวร์ของรูปทรง.

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

ตัวอย่างนี้สร้างดาวห้าแฉกโดยใช้ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดจุดยอดและการเว้นช่อง; การก้าว 72 องศาจัดให้จุดยอดห้าแฉกเท่า ๆ กัน. เส้นทางถูกปิดด้วย [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) và นำไปใช้กับรูปสี่เหลี่ยมโดยใช้ [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), แทนที่โครงร่างเดิม.

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

## **สร้างรูปทรงกำหนดเองแบบประกอบ**

ตัวอย่างนี้กำหนดสองอ็อบเจ็กต์ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ปิดสำหรับส่วนบนและล่างของรูปทรงที่แบ่งเป็นสามส่วน. การใช้ทั้งสองเส้นทางด้วย [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) สร้างรูปทรงประกอบเดียวที่มีช่องว่างตรงส่วนกลางของรูป.

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
bottomPath.MoveTo(shape.Height / 3 * 2, 0);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **สร้างรูปทรงกำหนดเองด้วยมุมโค้ง**

ตัวอย่างนี้รวมส่วนตรงกับ [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) เพื่อสร้างรูปทรงที่มุมโค้งเข้าด้านใน. ขนาดแต่ละมุมกำหนดความกว้างและความสูงของโค้งในหน่วยจุด, และการสวิง -90 องศาวาดรูปสี่เหลี่ยมวงรีทวนเข็มนาฬิกา. เส้นทางที่เสร็จสมบูรณ์ถูกนำไปใช้ด้วย [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), และงานนำเสนอจะถูกบันทึกในรูปแบบ PPTX.

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

## **ตรวจสอบว่ารูปทรงเรขาคณิตปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าจะสิ้นสุดด้วยส่วนปิดหรือไม่. มันอ่าน [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) และเปรียบเทียบคำสั่งของส่วนสุดท้าย [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) กับ [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). จะคืนค่า false หากไม่มีเส้นทางที่ไม่ว่างเปล่า. การตรวจสอบนี้ดูที่คำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบแต่ละรูปย่อยภายในเส้นทาง. ตัวอย่างจะแสดงค่า `True` สำหรับสี่เหลี่ยม.

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

## **ตรวจสอบคำสั่งของเส้นทางเรขาคณิต**

ดาวน์โหลด [contour.pptx](contour.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน. สไลด์แรกมีรูปทรงที่มีขอบบนเป็นเส้นตรง, เส้นโค้งคิวบิก Bézier, และขอบปิดเป็นเส้นตรง. ใช้ [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) เพื่ออ่านเส้นทางของมัน. แต่ละเส้นทางจะแสดงส่วนของมันตามลำดับการวาดใน [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). คำสั่งของแต่ละส่วน [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) กำหนดวิธีการอ่าน [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

รูปทรงอยู่ที่ตำแหน่ง (200, 100) จุดบนสไลด์. จุดที่รายงานเป็นค่าท้องถิ่นของรูปทรง, โดย (0, 0) อยู่ที่มุมซ้ายบน, ค่า x เพิ่มไปทางขวา, และค่า y เพิ่มลงล่าง. ส่วนปิดจะกลับไปที่จุดเริ่มต้นโดยไม่มีพิกัดเพิ่มเติม.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![รูป PowerPoint ที่มีขอบบนเป็นเส้นตรง, ขอบโค้งจากมุมบนขวาไปยังมุมล่างซ้าย, และขอบซ้ายเป็นเส้นตรง](contour.png)

## **สกัดและตรวจสอบส่วนประกอบของรูปทรง**

ใช้ [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) เพื่อตรวจสอบรูปทรงที่มีอยู่เป็นองค์ประกอบที่ประกอบด้วยจุดเส้นทางและประเภทจุด. แปลงแต่ละ [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) ที่คืนค่าเป็น [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) เพื่ออ่านอาเรย์ [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) และ [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์โครงร่างหรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง.

ตัวอย่างนี้เปิดงานนำเสนอ, ค้นหารูปเรขาคณิตแรกบนสไลด์แรกโดยตรง, และพิมพ์ส่วนของเส้นทางของมัน. ใช้งานนำเสนอที่มีรูปทรงที่มีส่วนเส้นตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองประเภท. มันไม่ได้ค้นหาภายในกลุ่ม.

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
        var pointType = types[i] & 0x07; // เก็บประเภทส่วน, ไม่รวมแฟล็ก.
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
                i += 2; // ใช้จุดควบคุมทั้งสองและจุดสิ้นสุด.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

อาเรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของมัน. ประเภท `0` เริ่มรูป, และประเภท `1` วาดเส้นจากจุดก่อนหน้ามายังจุดปัจจุบัน. ส่วนคิวบิก Bézier เริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` ต่อเนื่องสามรายการ: สองจุดควบคุมตามด้วยจุดสิ้นสุดใหม่. ลูปจะใช้สามรายการนี้ร่วมกันและตรวจสอบจุดสิ้นสุดเพื่อปิด.

ประเภทจุดยังมีแฟล็ก. ใช้มาสก์ `0x07` เพื่อระบุประเภทส่วน, และตรวจสอบ `0x80` แยกต่างหากเพื่อค้นพบเส้นทางย่อยที่ปิด. ตัวอย่างเช่น, `129` (`0x81`) หมายถึงจุดสิ้นสุดของเส้นที่ปิดเส้นทางย่อย, และ `131` (`0x83`) หมายถึงจุดสิ้นสุดของ Bézier ที่ปิดเส้นทางย่อย. การเปรียบเทียบค่าดิบแค่กับ `1` หรือ `3` จะพลาดกรณีเหล่านี้. แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทส่วนพื้นฐาน.

**พิกัดและการแปลง**. จุดวัดเป็นหน่วยจุด (1/72 นิ้ว), โดย X เพิ่มไปทางขวาและ Y เพิ่มลงล่าง. สำหรับรูปทรงที่ไม่ได้อยู่ในกลุ่ม, พิกัดที่สกัดออกมาจะรวมตำแหน่ง [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) ของมันแล้วและสะท้อนความกว้างและความสูงปัจจุบัน. ตัวอย่างเช่น, สี่เหลี่ยมที่ไม่ได้หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบโครงร่าง `(100, 200)`–`(220, 280)`. อย่าเพิ่มตำแหน่งของรูปอีกรอบหนึ่ง. ให้ลบค่า X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่หมุน.

จุดที่สกัดออกมาไม่ได้ใช้ [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) หรือการพลิกแนวนอนและแนวตั้งของรูป. เพื่อสร้างโครงร่างที่แสดง, ให้ใช้การแปลงเหล่านั้นรอบศูนย์กลางของรูป. สำหรับรูปที่อยู่ในกลุ่ม, ควรคำนึงถึงการแมพพิกัดของกลุ่มและการแปลง; อย่า Assume ว่าจุดที่สกัดเป็นพิกัดสุดท้ายของสไลด์ที่เรนเดอร์ หรือไม่ให้ทำการแปลหรือสเกลสองครั้งหากมันได้ถูกสะท้อนไว้แล้วในกรอบของลูก.

**การตรวจสอบเทียบกับการแก้ไข**. อาเรย์ที่สกัดอธิบายโครงร่าง; การเปลี่ยนแปลงอาเรย์เหล่านั้นจะไม่อัปเดตรูปต้นฉบับ. เลือกวิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาเรย์จุด/ประเภท. ใช้ [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปหรืออยากแก้ไขเรขาคณิตของมัน. นำเส้นทางที่แก้ไขไปใช้ผ่าน [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) หรือ [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **แปลง GeometryPath เป็น GraphicsPath (System.Drawing.Drawing2D)**

ตัวอย่างต่อไปนี้ต้องการชุดแอสเซมบลี Aspose.Slides for .NET รุ่นเก่าที่สนับสนุน [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), เช่นรุ่น 25.10, และสภาพแวดล้อม Windows ที่มี `System.Drawing.Common`. เมธอดการแปลงถูกลบใน [version 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

ตัวอย่างนี้รวมโครงร่างสี่เหลี่ยมกับข้อความที่แปลงเป็นเรขาคณิต. [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) ของโครงร่างถูกตั้งค่าให้ปิดการเติม. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) เก็บโครงร่างข้อความ, ซึ่ง [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) แปลงเป็นเส้นทางเรขาคณิตที่เติม. การใช้ทั้งสองเส้นทางด้วย [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) สร้างรูปเดียวที่มีสี่เหลี่ยมและข้อความ. สำหรับการแปลงในทิศทางตรงกันข้าม, ใช้ [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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

## **คำถามที่พบบ่อย**

**อะไรจะเกิดขึ้นกับการเติมและโครงร่างหลังจากการเปลี่ยนเรขาคณิต?**

สไตล์ยังคงอยู่กับรูป; เพียงโครงร่างที่เปลี่ยน. การเติมและโครงร่างจะถูกใช้กับเรขาคณิตใหม่โดยอัตโนมัติ.

**ฉันจะทำการหมุนรูปกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**

ใช้คุณสมบัติ [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) ของรูป; เรขาคณิตจะหมุนพร้อมกับรูปเนื่องจากมันถูกผูกกับระบบพิกัดของรูปเอง.

**ฉันสามารถแปลงรูปกำหนดเองเป็นภาพเพื่อ “ล็อก” ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออกพื้นที่ [slide](/slides/th/net/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/net/create-shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; นี้จะทำให้งานกับเรขาคณิตซับซ้อนง่ายขึ้น.