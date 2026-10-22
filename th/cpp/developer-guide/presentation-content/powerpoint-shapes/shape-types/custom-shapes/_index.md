---
title: ปรับแต่งรูปร่างการนำเสนอใน C++
linktitle: รูปร่างกำหนดเอง
type: docs
weight: 20
url: /th/cpp/custom-shape/
keywords:
- รูปร่างกำหนดเอง
- เพิ่มรูปร่าง
- สร้างรูปร่าง
- เปลี่ยนรูปร่าง
- เรขาคณิตของรูปร่าง
- เส้นทางเรขาคณิต
- จุดของเส้นทาง
- จุดแก้ไข
- เพิ่มจุด
- ลบจุด
- การดำเนินการแก้ไข
- มุมโค้ง
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "สร้างและปรับแต่งรูปร่างในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++: เส้นทางเรขาคณิต, มุมโค้ง, รูปร่างคอมโพสิต."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งรูปร่างในการนำเสนอบน Aspose.Slides โดยการแก้ไขเรขาคณิตของรูปร่างผ่านจุดแก้ไขและเส้นทางเรขาคณิต มันแสดงวิธีการใช้ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) และ [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) เพื่อแก้ไขรูปร่างที่มีอยู่, ทำการดำเนินการแก้ไขเส้นทางพื้นฐาน, เพิ่มหรือ ลบ จุด, และนำเรขาคณิตที่อัปเดตกลับไปยังรูปร่าง  
นอกจากนี้ยังแสดงวิธีการสร้างรูปร่างที่กำหนดเองและแบบคอมโพสิต, สร้างรูปร่างที่มีมุมโค้ง, และตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่

## **เปลี่ยนรูปร่างโดยใช้จุดแก้ไข**

ใน PowerPoint คุณสามารถใช้ **Edit Points** เพื่อแก้ไขสี่เหลี่ยมได้:

* ย้ายมุมเข้าหรือออกจากศูนย์กลาง
* ปรับความโค้งที่จุดหนึ่ง
* เพิ่มจุดใหม่

การแก้ไขจุดทำให้คุณสามารถปรับเปลี่ยนโครงร่างของรูปร่างหรือใช้รูปร่างที่มีอยู่เป็นฐานสำหรับสร้างรูปร่างใหม่ได้

## **เคล็ดลับการแก้ไขรูปร่าง**

![overview_image](custom_shape_0.png)

เมื่อแก้ไขรูปร่างใน PowerPoint ให้นึกถึงแนวคิดต่อไปนี้:

* รูปร่าง (หรือเส้นทางของมัน) สามารถเป็นแบบปิดหรือเปิดได้
* เส้นทางของรูปร่างประกอบด้วยจุดยึดที่เชื่อมต่อด้วยเซกเมนต์
* เซกเมนต์อาจเป็นเส้นตรงหรือโค้ง จุดยึดและตัวจัดการควบคุมกำหนดรูปร่างของมัน
* จุดยึดมีอยู่ในรูปแบบจุดมุม, จุดตรง, หรือจุดเรียบ:
  - ที่จุดมุม เซกเมนต์ที่ต่อกันสามารถพบกันเป็นมุม
  - ที่จุดเรียบ ตัวจัดการควบคุมสองตัวจะอยู่ในแนวเดียวกันและห่างจากจุดยึดเท่ากัน
  - ที่จุดตรง ตัวจัดการควบคุมสองตัวจะอยู่ในแนวเดียวกันแต่ระยะห่างจากจุดยึดอาจต่างกัน
* การย้ายจุดยึดหรือการปรับตัวจัดการของพวกมันจะทำให้โครงร่างของรูปร่างเปลี่ยนแปลง

เพื่อแก้ไขรูปร่าง PowerPoint ผ่านจุดแก้ไข, **Aspose.Slides** มีคลาส [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) และอินเทอร์เฟซ [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) ให้ใช้

* อินสแตนซ์ของ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) แทนเส้นทางเรขาคณิตของอ็อบเจกต์ [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/)
* เพื่อดึง [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) จากอินสแตนซ์ของ [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), คุณสามารถใช้เมธอด [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/)
* เพื่อกำหนด [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ให้กับรูปร่าง, คุณสามารถใช้เมธอดต่อไปนี้: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) สำหรับรูปร่างที่มีเส้นทางเดียวและ [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) สำหรับรูปร่างที่มีหลายเส้นทาง
* เพื่อเพิ่มเซกเมนต์, คุณสามารถใช้เมธอดภายใต้ [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/)
* โดยใช้เมธอด [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) และ [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) คุณสามารถกำหนดลักษณะการแสดงผลของเส้นทางเรขาคณิต
* โดยใช้เมธอด [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) คุณสามารถดึงเส้นทางเรขาคณิตของ [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) เป็นอาเรย์ของเซกเมนต์

## **การดำเนินการแก้ไขอย่างง่าย**

ใช้เมธอดต่อไปนี้เพื่อแก้ไขเส้นทางเรขาคณิต. การโอเวอร์โหลดที่รับดัชนีจะใส่เซกเมนต์ที่ตำแหน่งศูนย์ฐานในอาเรย์เซกเมนต์ของเส้นทาง

| Operation | Method |
| --- | --- |
| เพิ่มหรือแทรกเส้นตรง. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบคิวบิกด้วยจุดควบคุมสองจุดและจุดปลาย. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| เพิ่มหรือแทรกเส้นโค้ง Bézier แบบกำลังสองด้วยจุดควบคุมหนึ่งจุดและจุดปลาย. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| เพิ่มส่วนโค้งวงรีตามขนาดและมุมที่ระบุเป็นองศา. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| ปิดรูปภาพปัจจุบันโดยเชื่อมจุดปลายกับจุดเริ่มต้น. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| กำหนดจุดเริ่มต้นของรูปภาพ. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| ลบเซกเมนต์ที่ตำแหน่งดัชนีศูนย์ฐาน. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **เพิ่มจุดกำหนดเองไปยังรูปร่าง**

ตัวอย่างนี้แทรกจุดสองจุดลงในรูปร่างสี่เหลี่ยมโดยใช้ [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) และนำเส้นทางที่แก้ไขไปใช้ด้วย [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). พิกัดเป็นตำแหน่งภายในรูป: ทั้งสองจุดใหม่อยู่ที่ศูนย์กลางของรูป, ห่างจากด้านซ้าย 100 พิกเซลและจากด้านบน 50 พิกเซล. ดัชนีเซกเมนต์ 1 และ 4 จะวางจุดบนขอบบนและขอบล่าง, ดึงขอบเหล่านั้นเข้าหากัน.

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

## **ลบจุดจากรูปร่าง**

ตัวอย่างนี้เปลี่ยนโครงร่างรูปหัวใจโดยการลบเซกเมนต์ที่ตำแหน่งดัชนีศูนย์ฐาน 2 ด้วย [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). การนำเส้นทางที่แก้ไขไปใช้ด้วย [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) จะอัปเดตคอนทัวร์ของรูปร่าง.

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

## **สร้างรูปร่างกำหนดเอง**

ตัวอย่างนี้สร้างดาวห้าแฉกโดยใช้ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). รัศมีนอกและในที่สลับกัน 100 และ 50 พิกเซลกำหนดปลายและร่อง, ขั้นที่ 72 องศาแบ่งดาวห้าจุดให้เท่าเทียมกัน. เส้นทางถูกปิดด้วย [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) และนำไปใช้กับรูปร่างสี่เหลี่ยมโดยใช้ [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), แทนที่โครงร่างเดิม.

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

## **สร้างรูปร่างกำหนดเองแบบคอมโพสิต**

ตัวอย่างนี้กำหนดอ็อบเจกต์ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) ปิดสองอันสำหรับส่วนบนและส่วนล่างของรูปแบบสามส่วน. การนำเส้นทางทั้งสองไปใช้ด้วย [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) จะสร้างรูปร่างคอมโพสิตเดียวที่มีช่องว่างตรงส่วนกลางของรูป.

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

## **สร้างรูปร่างกำหนดเองพร้อมมุมโค้ง**

ตัวอย่างนี้ผสานเซกเมนต์ตรงกับ [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) เพื่อสร้างรูปร่างที่มีมุมโค้งเข้าด้านใน. ขนาดของแต่ละมุมกำหนดความกว้างและความสูงของส่วนโค้งเป็นพิกเซล, และการสวิง -90 องศาจะวาดส่วนโค้งสี่เหลี่ยมครึ่งวงรีตามเข็มนาฬิกา. เส้นทางที่เสร็จสมบูรณ์จะนำไปใช้ด้วย [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), และการนำเสนอจะถูกบันทึกในรูปแบบ PPTX.

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

## **ตรวจสอบว่ารูปร่างเรขาคณิตเป็นแบบปิดหรือไม่**

ตัวช่วยต่อไปนี้ตรวจสอบว่าทุกเส้นทางเรขาคณิตที่ไม่ว่างเปล่ามีเซกเมนต์ปิดเป็นท้ายหรือไม่. มันอ่าน [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) และเปรียบเทียบคำสั่งของเซกเมนต์สุดท้าย [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) กับ [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). จะคืนค่า false เมื่อไม่มีเส้นทางที่ไม่ว่างเปล่า. การตรวจสอบนี้ดูคำสั่งสุดท้ายของแต่ละเส้นทาง; ไม่ได้ตรวจสอบทุกรูปย่อยภายในเส้นทาง. ตัวอย่างพิมพ์ `True` สำหรับสี่เหลี่ยม.

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

## **สกัดและตรวจสอบองค์ประกอบของรูปร่าง**

ใช้ [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) เพื่อสังเกตรูปร่างที่มีอยู่เป็นองค์ประกอบที่ประกอบด้วยจุดเส้นทางและประเภทจุด. แคสท์แต่ละ [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) ที่ส่งกลับเป็น [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) เพื่ออ่านอาเรย์ที่ส่งกลับโดย [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) และ [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). การแสดงผลนี้มีประโยชน์สำหรับการวิเคราะห์คอนทัวร์หรือการส่งเรขาคณิตไปยังเครื่องมือวาดแบบกำหนดเอง  

ตัวอย่างนี้เปิดไฟล์การนำเสนอ, ค้นหารูปร่างเรขาคณิตแรกบนสไลด์แรก, และพิมพ์เซกเมนต์ของเส้นทาง. ใช้การนำเสนอที่มีรูปร่างที่มีเซกเมนต์ตรงและโค้งเพื่อดูผลลัพธ์ทั้งสองแบบ. มันไม่ค้นหาในกลุ่ม.

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
        auto pointType = types[i] & 0x07; // เก็บประเภทของเซกเมนต์โดยไม่รวมแฟล็ก
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
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

อาเรย์สอดคล้องกันตามดัชนี: `points[i]` คือจุดและ `types[i]` บรรยายบทบาทของมัน. ประเภท `0` เริ่มรูป, และประเภท `1` วาดเส้นจากจุดก่อนหน้าไปยังจุดปัจจุบัน. เซกเมนต์ Bézier แบบคิวบิกเริ่มที่จุดปลายของเซกเมนต์ก่อนหน้าและใช้รายการประเภท `3` ต่อเนื่องสามรายการ: จุดควบคุมสองจุดตามด้วยจุดปลายใหม่. ลูปจะรับสามรายการนี้พร้อมกันและตรวจสอบจุดปลายเพื่อความปิด.  

ประเภทจุดยังมีแฟล็ก. ใช้มาสก์ `0x07` เพื่อตรวจสอบประเภทเซกเมนต์, และทดสอบ `0x80` แยกต่างหากเพื่อค้นหาซับพาธที่ปิด. ตัวอย่างเช่น, `129` (`0x81`) หมายถึงจุดปลายของเส้นที่ปิดซับพาธ, และ `131` (`0x83`) หมายถึงจุดปลายของ Bézier ที่ปิดซับพาธ. การเปรียบเทียบค่าดิบเพียง `1` หรือ `3` จะทำให้พลาดกรณีเหล่านี้. แฟล็กอื่น ๆ เช่น dash (`0x10`) และ marker (`0x20`) ไม่เปลี่ยนประเภทฐานของเซกเมนต์.  

**พิกัดและการแปลง.** จุดวัดเป็นพอยต์ (1/72 นิ้ว), โดย X เพิ่มไปทางขวาและ Y เพิ่มลงล่าง. สำหรับรูปร่างที่ไม่ได้อยู่ในกลุ่ม, พิกัดที่สกัดแล้วรวมตำแหน่งที่ได้จาก [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) และ [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) แล้วสะท้อนความกว้างและความสูงปัจจุบันของมัน. ตัวอย่างเช่น, สี่เหลี่ยมที่ไม่ได้หมุนที่ตำแหน่ง `(100, 200)` ขนาด `120 × 80` มีขอบคอนทัวร์เป็น `(100, 200)`–`(220, 280)`. อย่าเพิ่มตำแหน่งของรูปร่างอีกครั้ง. ให้ลบค่า X และ Y ของมันเพื่อให้ได้พิกัดสัมพัทธ์กับกรอบที่ไม่ได้หมุน.  

จุดที่สกัดจะไม่รวมการหมุนที่ตั้งผ่าน [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) หรือการพลิกแนวนอนและแนวตั้ง. เพื่อสร้างคอนทัวร์ที่แสดง, ให้ใช้การแปลงเหล่านั้นรอบศูนย์กลางของรูปร่าง. สำหรับรูปร่างที่อยู่ในกลุ่ม, ควรคำนึงถึงการแม็พพิกัดของกลุ่มและการแปลง; อย่าสันนิษฐานว่าจุดที่สกัดเป็นพิกัดสไลด์ที่แสดงสุดท้ายหรือทำการแปลงการย้ายหรือสเกลสองครั้งหากมันได้รวมอยู่ในกรอบของลูกแล้ว.  

**การตรวจสอบเทียบกับการแก้ไข.** อาเรย์ที่สกัดอธิบายคอนทัวร์; การเปลี่ยนแปลงพวกมันจะไม่อัปเดตรูปร่างต้นฉบับ. เลือกวิธีนี้เมื่อการวิเคราะห์หรือโค้ดวาดของคุณต้องการอาเรย์จุด/ประเภท. ใช้ [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) เมื่อคุณต้องการคำสั่งเรขาคณิตในระบบพิกัดภายในของรูปร่างหรือต้องการแก้ไขเรขาคณิตของมัน. นำเส้นทางที่แก้ไขไปใช้ผ่าน [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) หรือ [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **แปลง GeometryPath เป็น GraphicsPath**

API สาธารณะของ Aspose.Slides for C++ ปัจจุบันไม่เปิดเผยการแปลงระหว่างเส้นทางเรขาคณิตและเส้นทางกราฟิก. เพื่อสังเกตคอนทัวร์, ใช้องค์ประกอบของรูปร่างตามที่อธิบายข้างบน. เพื่อแก้ไขรูปร่าง, ใช้เส้นทางเรขาคณิตและนำเส้นทางที่อัปเดตไปใช้กับรูปร่าง.

## **คำถามที่พบบ่อย**

**รูปแบบการเติมและโครงร่างจะเป็นอย่างไรหลังจากเปลี่ยนเรขาคณิต?**  
รูปแบบยังคงอยู่กับรูปร่าง; มีเพียงคอนทัวร์ที่เปลี่ยนไป. การเติมและโครงร่างจะถูกนำไปใช้โดยอัตโนมัติกับเรขาคณิตใหม่.

**ฉันจะหมุนรูปร่างกำหนดเองพร้อมกับเรขาคณิตอย่างถูกต้องได้อย่างไร?**  
ใช้เมธอด [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) ของรูปร่าง; เรขาคณิตจะหมุนพร้อมกับรูปร่างเนื่องจากถูกผูกกับระบบพิกัดของรูปร่างเอง.

**ฉันสามารถแปลงรูปร่างกำหนดเองเป็นภาพเพื่อ "ล็อก" ผลลัพธ์ได้หรือไม่?**  
ได้. ส่งออกส่วน [slide](/slides/th/cpp/convert-powerpoint-to-png/) ที่ต้องการหรือ [shape](/slides/th/cpp/shape-thumbnails/) เองเป็นรูปแบบราสเตอร์; นี้ทำให้การทำงานต่อกับเรขาคณิตซับซ้อนง่ายขึ้น.