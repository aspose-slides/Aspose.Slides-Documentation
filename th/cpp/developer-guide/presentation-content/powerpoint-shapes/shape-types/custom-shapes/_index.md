---
title: ปรับแต่งรูปทรงการนำเสนอใน C++
linktitle: รูปทรงกำหนดเอง
type: docs
weight: 20
url: /th/cpp/custom-shape/
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
- C++
- Aspose.Slides
description: "สร้างและปรับแต่งรูปทรงในพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides สำหรับ C++: เส้นทางเรขาคณิต, มุมโค้ง, รูปทรงคอมโพสิต."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปทรงการนำเสนอใน Aspose.Slides ด้วยการแก้ไขรูปทรงเรขาคณิตผ่านจุดแก้ไขและเส้นทางเรขาคณิต โดยแสดงวิธีการทำงานกับ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) และ [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) เพื่อแก้ไขรูปทรงที่มีอยู่, ทำการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือเอาจุดออก, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปทรง

มันยังแสดงวิธีการสร้างรูปทรงแบบกำหนดเองและแบบคอมโพซิต, สร้างรูปทรงที่มีมุมโค้ง, และตรวจสอบว่ารูปทรงเรขาคณิตเป็นแบบปิดหรือไม่

## **เปลี่ยนรูปทรงโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยมจัตุรัสได้:

* ย้ายมุมเข้าหรือออกจากศูนย์กลาง.
* ปรับความโค้งที่จุดหนึ่ง.
* เพิ่มจุดใหม่.

การแก้ไขจุดทำให้คุณสามารถปรับเปลี่ยนอ outline ของรูปทรงหรือใช้รูปทรงที่มีอยู่เป็นฐานสำหรับรูปทรงใหม่ได้.

## **เคล็ดลับการแก้ไขรูปทรง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปทรง PowerPoint ให้คำนึงถึงแนวคิดต่อไปนี้:

* รูปทรง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้.
* เส้นทางของรูปทรงประกอบด้วยจุดยึดที่เชื่อมต่อด้วยเซกเมนต์.
* เซกเมนต์อาจเป็นเส้นตรงหรือโค้ง เซกเมนต์อาจเป็นเส้นตรงหรือโค้ง จุดยึดและมือควบคุมกำหนดรูปร่างของมัน.
* จุดยึดมีอยู่ในรูปแบบจุดมุม, จุดตรง, หรือจุดเรียบ:
  * ที่จุดมุม, เซกเมนต์ที่เชื่อมต่ออาจมาบรรจบกันเป็นมุม.
  * ที่จุดเรียบ, มือควบคุมสองตัวจะอยู่ในแนวเดียวกันและห่างจากจุดยึดเท่ากัน.
  * ที่จุดตรง, มือควบคุมสองตัวอยู่ในแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจต่างกัน.
* การย้ายจุดยึดหรือปรับมือควบคุมของมันจะเปลี่ยน outline ของรูปทรง.

เพื่อแก้ไขรูปทรง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) และอินเทอร์เฟซ [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) ให้ใช้.

* ตัวอย่างของ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) แสดงเส้นทางเรขาคณิตของอ็อบเจ็กต์ [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) คุณสามารถใช้เมธอด [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ให้กับรูปทรง, คุณสามารถใช้เมธอดเหล่านี้: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) สำหรับรูปทรงที่มีเส้นทางเดียวและ [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) สำหรับรูปทรงที่มีหลายเส้นทาง.
* เพื่อเพิ่มเซกเมนต์, คุณสามารถใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* ด้วยเมธอด [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) และ [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) คุณสามารถกำหนดรูปลักษณ์ของเส้นทางเรขาคณิตได้.
* ด้วยเมธอด [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) เป็นอาร์เรย์ของเซกเมนต์ได้.

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต. การเรียกที่รับดัชนีจะใส่เซกเมนต์ในตำแหน่งที่เริ่มจากศูนย์ในอาร์เรย์ของเซกเมนต์ของเส้นทาง.

| การดำเนินการ | เมธอด |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| เพิ่มหรือแทรกโค้ง Bézier แบบคิวบิกที่มีจุดควบคุมสองจุดและจุดสิ้นสุด. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| เพิ่มหรือแทรกโค้ง Bézier แบบกำลังสองที่มีจุดควบคุมหนึ่งจุดและจุดสิ้นสุด. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| เพิ่มส่วนโค้งวงรีด้วยมิติและมุมที่กำหนดเป็นระดับ. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| ปิดรูปปัจจุบันโดยเชื่อมจุดสิ้นสุดกับจุดเริ่มต้น. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| ตั้งค่าจุดเริ่มต้นของรูป. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| ลบเซกเมนต์ที่ตำแหน่งดัชนีเริ่มจากศูนย์. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **เพิ่มจุดกำหนดเองให้กับรูปทรง**

ตัวอย่างนี้แทรกจุดสองจุดลงในรูปสี่เหลี่ยมโดยใช้ [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) และนำเส้นทางที่แก้ไขไปใช้กับ [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). พิกัดเป็นพิกัดภายในรูป: จุดใหม่ทั้งสองอยู่ที่ศูนย์กลางของรูป, ห่างจากด้านซ้าย 100 จุดและจากด้านบน 50 จุด. ดัชนีเซกเมนต์ 1 และ 4 จะวางจุดเหล่านี้บนขอบบนและขอบล่าง, ดึงขอบเหล่านั้นเข้ามา.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **ลบจุดจากรูปทรง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยลบเซกเมนต์ที่ตำแหน่งดัชนีเริ่มจากศูนย์ที่ 2 ด้วย [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). การนำเส้นทางที่แก้ไขไปใช้ด้วย [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) จะอัปเดตเส้นขอบของรูป.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **สร้างรูปทรงกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกด้วย [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). รัศมีภายนอกและภายในสลับกันที่ 100 และ 50 จุดกำหนดปลายและการเว้นระยะ; การก้าว 72 องศาจะเว้นระยะห้าปลายให้เท่าเทียม. เส้นทางถูกปิดด้วย [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) และใช้กับรูปสี่เหลี่ยมโดยใช้ [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), แทนที่โครงร่างเดิม.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)

## **สร้างรูปทรงกำหนดเองแบบคอมโพสิต**

ตัวอย่างนี้กำหนดอ็อบเจ็กต์สองชุดของ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ที่ปิดสำหรับส่วนบนและล่างของรูป. การใช้ทั้งสองเส้นทางด้วย [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) จะสร้างรูปคอมโพสิตเดียวที่มีช่องว่างตรงส่วนกลางของรูป.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(shape->get_Height() / 3 * 2, 0.0f);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```

![example4_image](custom_shape_4.png)

## **สร้างรูปทรงกำหนดเองด้วยมุมโค้ง**

ตัวอย่างนี้ผสมเซกเมนต์ตรงกับ [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) เพื่อสร้างรูปที่มุมโค้งเข้าด้านใน. ขนาดของแต่ละมุมกำหนดความกว้างและความสูงของส่วนโค้งในหน่วยจุด, และการสวิง -90 องศาจะวาดส่วนโค้งจัตุรัสเป็นครึ่งวงรีทวนเข็มนาฬิกา. เส้นทางที่เสร็จสมบูรณ์ถูกนำไปใช้ด้วย [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), และการนำเสนอถูกบันทึกในรูปแบบ PPTX.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **ตรวจสอบว่ารูปทรงเรขาคณิตเป็นแบบปิดหรือไม่**

ส่วนช่วยเหลือด้านล่างนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่าจะสิ้นสุดด้วยเซกเมนต์ปิดหรือไม่. มันอ่านค่า [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) และเปรียบเทียบ [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) ของเซกเมนต์สุดท้ายกับ [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). จะคืนค่า false หากไม่มีเส้นทางที่ไม่ว่างเปล่า. การตรวจสอบนี้ดูที่คำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ตรวจสอบทุกสับฟิกเกอร์ภายในเส้นทาง. ตัวอย่างพิมพ์ `True` สำหรับสี่เหลี่ยม.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **ตรวจสอบคำสั่งของเส้นทางเรขาคณิต**

ดาวน์โหลด [contour.pptx](contour.pptx) แล้ววางไว้ในไดเรคทอรีทำงานของแอปพลิเคชัน. รูปแรกบนสไลด์แรกมีขอบบนตรง, โค้ง Bézier แบบคิวบิก, และขอบปิดตรง. ใช้ [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) เพื่ออ่านเส้นทางของมัน. สำหรับแต่ละเส้นทาง, [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) คืนค่าเซกเมนต์ตามลำดับการวาด. คำสั่งที่คืนค่าจาก [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) กำหนดวิธีการตีความค่าที่คืนจาก [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

รูปอยู่ที่ตำแหน่ง (200, 100) จุดบนสไลด์. จุดที่รายงานเป็นจุดภายในรูป, โดย (0, 0) อยู่ที่มุมบนซ้าย, x เพิ่มไปทางขวา, y เพิ่มลงด้านล่าง. เซกเมนต์ปิดจะกลับไปยังจุดเริ่มต้นโดยไม่มีพิกัดเพิ่มเติม.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![รูป PowerPoint ที่มีขอบบนตรง, ขอบโค้งจากมุมขวาบนไปมุมซ้ายล่าง, และขอบซ้ายตรง](contour.png)

## **สกัดและตรวจสอบองค์ประกอบของรูปทรง**

ใช้ [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) เพื่อตรวจสอบรูปที่มีอยู่เป็นองค์ประกอบที่มีจุดเส้นทางและประเภทของจุด. แคสท์แต่ละ [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) ที่คืนเป็น [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) เพื่ออ่านอาร์เรย์ที่คืนจาก [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) และ [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). การแสดงผลนี้เป็นประโยชน์สำหรับการวิเคราะห์คอนทัวร์หรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง.

ตัวอย่างนี้เปิดไฟล์พรีเซนเทชัน, ค้นหารูปเรขาคณิตแรกตรงบนสไลด์แรก, และพิมพ์เซกเมนต์ของเส้นทาง. ใช้พรีเซนเทชันที่มีรูปที่มีเซกเมนต์ตรงและโค้งเพื่อดูผลลัพธ์ของทั้งสองแบบ. ไม่ค้นหาภายในกลุ่ม.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // เก็บประเภทเซกเมนต์, ไม่รวมแฟล็ก.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // ใช้ทั้งจุดควบคุมสองจุดและจุดสิ้นสุด.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

อาร์เรย์สอดคล้องตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของมัน. ประเภท `0` เริ่มรูป, และประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน. เซกเมนต์ Bézier แบบคิวบิกเริ่มจากจุดสิ้นสุดก่อนหน้าและใช้รายการประเภท `3` สามรายการต่อกัน: จุดควบคุมสองจุดตามด้วยจุดสิ้นสุดใหม่. ลูปจะใช้สามรายการนี้ร่วมกันและตรวจสอบจุดสิ้นสุดสำหรับการปิด.

ประเภทจุดยังมีแฟล็ก. ใช้มาสก์ `0x07` เพื่อระบุประเภทของเซกเมนต์, และตรวจสอบ `0x80` แยกต่างหากเพื่อค้นพบซับพาธที่ปิด. ตัวอย่างเช่น `129` (`0x81`) หมายถึงจุดปลายของเส้นที่ปิดซับพาธ, และ `131` (`0x83`) หมายถึงจุดปลายของ Bézier ที่ปิด. การเปรียบเทียบค่าดิบเฉพาะกับ `1` หรือ `3` จะพลาดกรณีเหล่านี้. แฟล็กอื่นๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทฐานของเซกเมนต์.

**พิกัดและการแปลง** จุดวัดเป็นหน่วยจุด (1/72 นิ้ว), โดย X เพิ่มไปทางขวาและ Y เพิ่มลงด้านล่าง. สำหรับรูปที่ไม่ได้อยู่ในกลุ่ม, พิกัดที่สกัดมามีตำแหน่งที่ได้จาก [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) และ [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) อยู่แล้วและสะท้อนความกว้างและความสูงปัจจุบันของรูป. ตัวอย่างเช่น สี่เหลี่ยมที่ไม่ได้หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบคอนทัวร์ `(100, 200)`–`(220, 280)`. อย่าเพิ่มตำแหน่งของรูปอีกครั้ง. หักค่า X และ Y เพื่อให้ได้พิกัดสัมพันธ์กับกรอบที่ไม่ได้หมุน.

จุดที่สกัดจะไม่รวมการหมุนที่ตั้งผ่าน [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) หรือการพลิกแนวนอนและแนวตั้ง. เพื่อทำให้คอนทัวร์ที่แสดงออกมาถูกต้อง, ให้ใช้การแปลงเหล่านั้นรอบศูนย์กลางของรูป. สำหรับรูปที่อยู่ในกลุ่ม, ต้องคำนึงถึงการแมพพิกัดของกลุ่มและการแปลง; อย่าสันนิษฐานว่าจุดที่สกัดเป็นพิกัดสุดท้ายที่แสดงบนสไลด์หรือทำการแปลหรือสเกลสองครั้งหากมันได้ถูกสะท้อนแล้วในเฟรมของลูก.

**การตรวจสอบกับการแก้ไข** อาร์เรย์ที่สกัดอธิบายคอนทัวร์; การเปลี่ยนแปลงมันจะไม่อัปเดตรูปเดิม. เลือกวิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาร์เรย์จุด/ประเภท. ใช้ [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดท้องถิ่นของรูปหรือต้องการแก้ไขเรขาคณิตของมัน. ใช้เส้นทางที่แก้ไขผ่าน [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) หรือ [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **แปลง GeometryPath เป็น GraphicsPath**

API สาธารณะของ Aspose.Slides สำหรับ C++ ปัจจุบันไม่มีการเปิดเผยการแปลงระหว่างเส้นทางเรขาคณิตและเส้นทางกราฟิก. เพื่อตรวจสอบคอนทัวร์, ใช้ส่วนประกอบของรูปตามที่อธิบายข้างต้น. เพื่อแก้ไขรูป, ใช้เส้นทางเรขาคณิตและนำเส้นทางที่อัปเดตไปใช้กับรูป.

## **FAQ**

**อะไรจะเกิดขึ้นกับการเติมและขอบหลังจากเปลี่ยนเรขาคณิต?**

สไตล์จะคงอยู่กับรูป; เพียงคอนทัวร์เปลี่ยน. การเติมและขอบจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่.

**ฉันจะหมุนรูปกำหนดเองพร้อมกับเรขาคณิตได้อย่างถูกต้องอย่างไร?**

ใช้เมธอด [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ของรูป; เรขาคณิตจะหมุนพร้อมกับรูปเนื่องจากผูกกับระบบพิกัดของรูปเอง.

**ฉันสามารถแปลงรูปกำหนดเองเป็นภาพเพื่อ "ล็อค" ผลลัพธ์ได้หรือไม่?**

ได้. ส่งออกพื้นที่ [slide](/slides/th/cpp/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/cpp/shape-thumbnails/) เองเป็นรูปแบบแรสเตอร์; นี้ทำให้การทำงานต่อกับเรขาคณิตซับซ้อนง่ายขึ้น.