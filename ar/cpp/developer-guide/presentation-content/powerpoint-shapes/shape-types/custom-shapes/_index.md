---
title: تخصيص أشكال العرض التقديمي في C++
linktitle: شكل مخصص
type: docs
weight: 20
url: /ar/cpp/custom-shape/
keywords:
- شكل مخصص
- إضافة شكل
- إنشاء شكل
- تغيير شكل
- هندسة الشكل
- مسار الهندسة
- نقاط المسار
- نقاط تحرير
- إضافة نقطة
- إزالة نقطة
- عملية تحرير
- زاوية منحنية
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص الأشكال في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة C++: مسارات الهندسة، زوايا منحنية، أشكال مركبة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تخصيص أشكال العروض التقديمية في Aspose.Slides عن طريق تحرير هندسة الشكل من خلال نقاط التحرير ومسارات الهندسة. توضح كيفية العمل مع [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) و[IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) لتعديل الأشكال الموجودة، وإجراء عمليات تحرير أساسية للمسار، إضافة أو إزالة النقاط، وتطبيق الهندسة المحدثة على الشكل.

كما تُظهر كيفية إنشاء أشكال مخصصة ومركبة، بناء أشكال بزوايا منحنية، وتحديد ما إذا كانت هندسة الشكل مغلقة أم لا.

## **تغيير شكل باستخدام نقاط التحرير**

في PowerPoint، يمكنك استخدام **نقاط التحرير** لتعديل مربع:

* تحريك الزاوية إلى الداخل أو الخارج.
* تعديل الانحناء عند نقطة.
* إضافة نقاط جديدة.

تسمح لك تحرير النقاط بتعديل حدود الشكل أو استخدام شكل موجود كأساس لشكل جديد.

## **نصائح تحرير الشكل**

![صورة_نظرة_عام](custom_shape_0.png)

عند تحرير أشكال PowerPoint، احرص على مراعاة المفاهيم التالية:

* يمكن أن يكون الشكل (أو مساره) إما مغلقًا أو مفتوحًا.
* يتكون مسار الشكل من نقاط ربط متصلة بشرائط.
* يمكن أن تكون الشريحة مستقيمة أو منحنية. تحدد نقاط الربط ومقابض التحكم شكلها.
* توجد نقاط الربط كالنقاط الزاوية، النقاط المستقيمة، أو النقاط السلسة:
  * في نقطة زاوية، يمكن أن تلتقي الشرائح المتجاورة بزاوية.
  * في نقطة سلسة، تكون مقبضا التحكم محاذيين وعلى مسافة متساوية من نقطة الربط.
  * في نقطة مستقيمة، يكون مقبضا التحكم محاذيين لكن يمكن أن تكون مسافتهما مختلفة عن نقطة الربط.
* تحريك نقاط الربط أو ضبط مقابضها يغير حدود الشكل.

لتحرير أشكال PowerPoint عبر نقاط التحرير، توفر **Aspose.Slides** الفئة [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) والواجهة [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* تمثل نسخة [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) مسار هندسة كائن [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* لاسترجاع [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) من نسخة [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/)، يمكنك استخدام طريقة [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* لتعيين [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) لشكل، يمكنك استخدام هذه الطرق: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) للأشكال ذات مسار واحد و[IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) للأشكال ذات مسارات متعددة.
* لإضافة شرائط، يمكنك استخدام الطرق تحت [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* باستخدام طريقتي [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) و[IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/)، يمكنك تعيين المظهر لمسار الهندسة.
* باستخدام طريقة [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/)، يمكنك استرجاع مسار الهندسة لـ[GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) كمصفوفة من شرائط المسار.

## **عمليات تحرير بسيطة**

استخدم الطرق التالية لتحرير مسار الهندسة. الإفراطات التي تقبل فهرس تُدرج شريحة في ذلك الموضع الصفري‑القاعدة داخل مصفوفة شرائط المسار.

| العملية | الطريقة |
| --- | --- |
| إلحاق أو إدراج خط مستقيم. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| إلحاق أو إدراج منحنى بيزيه مكعّب مع نقطتي تحكم ونقطة نهاية. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| إلحاق أو إدراج منحنى بيزيه تربيعي مع نقطة تحكم واحدة ونقطة نهاية. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| إلحاق قوس إهليجي بالأبعاد والزوايا المحددة بالدرجات. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| إغلاق الشكل الحالي بربط نقطة النهاية بنقطة البداية. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| تعيين نقطة البداية لشكل. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| إزالة شريحة عند فهرس صفري‑القاعدة. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **إضافة نقاط مخصصة إلى شكل**

يُدرج هذا المثال نقطتين في شكل مستطيل باستخدام [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) ويطبق المسار المُحرّر عبر [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). الإحداثيات محلية إلى الشكل: كلتا النقطتين الجديدتين تقعان في مركزه، 100 نقطة من اليسار و50 نقطة من الأعلى. تُوضِّع فهارس الشرائط 1 و4 النقاط على الحافتين العلوية والسفلية، مما يسحب هاتين الحافتين إلى الداخل.

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

![صورة_مثال1](custom_shape_1.png)

## **إزالة نقاط من شكل**

يغيّر هذا المثال مظهر قلب بإزالة الشريحة عند الفهرس الصفري‑القاعدة 2 باستخدام [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). تطبيق المسار المعدل عبر [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) يُحدّث مُنحدر الشكل.

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
![صورة_مثال2](custom_shape_2.png)

## **إنشاء شكل مخصص**

يبني هذا المثال نجمة بخمس رؤوس باستخدام [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). تُعرّف نصف القطرين الخارجي والداخلي المتناوبين بـ100 و50 نقطة لتحديد الطرفيات والفراغات؛ خطوة 72 درجة تُوزِّع الرؤوس الخمسة بالتساوي. يُغلق المسار بـ[GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) ويُطبق على شكل مستطيل عبر [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)، مُستبدلاً حدوده.

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
![صورة_مثال3](custom_shape_3.png)

## **إنشاء شكل مخصص مركب**

يعرّف هذا المثال مسارين مغلقين من نوع [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) للثلث العلوي والسفلي من الشكل. يخلق تطبيق كلا المسارين عبر [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) شكلاً مركبًا واحدًا به فجوة عبر الثلث الأوسط.

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
bottomPath->MoveTo(0.0f, shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![صورة_مثال4](custom_shape_4.png)

## **إنشاء شكل مخصص بزوايا منحنية**

يجمع هذا المثال شرائح مستقيمة مع [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) لإنشاء شكل بزوايا منحنية إلى الداخل. كل حجم زاوية يحدد عرض القوس وارتفاعه بالنقاط، والمسح ب‑‑90 درجة يرسم ربع إهليج عكس اتجاه عقارب الساعة. يُطبق المسار المكتمل عبر [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/)، وتُحفظ العرض التقديمي بصيغة PPTX.

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

## **التحقق مما إذا كانت هندسة الشكل مغلقة**

يتحقق المساعد التالي مما إذا كان كل مسار هندسة غير فارغ يُنهي بشرريحة إغلاق. يقرأ [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) ويقارن أمر الشريحة النهائي لـ[IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) مع [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). تُعيد false عندما لا توجد مسارات غير فارغة. يَفحص هذا الأمر النهائي لكل مسار؛ لا يفتش كل شكل فرعي داخل المسار. يطبع المثال `True` لمستطيل.

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

## **فحص أوامر مسار الهندسة**

حمِّل [contour.pptx](contour.pptx) وضعه في دليل العمل للتطبيق. يحتوي الشكل الأول في الشريحة الأولى على حافة علوية مستقيمة، ومنحنى بيزيه مكعّب، وحافة إغلاق مستقيمة. استخدم [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) لقراءة مساراته. لكل مسار، تُعيد [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) الشرائط بترتيب الرسم. يحدد الأمر المرجع بواسطة [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) كيفية تفسير القيم المسترجعة من [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

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

يقع الشكل عند النقاط (200, 100) على الشريحة. النقاط المُبلغ عنها محلية إلى الشكل، مع (0, 0) في الزاوية العليا‑اليسرى، x يزداد إلى اليمين، وy يزداد إلى الأسفل. تُعيد الشريحة المغلقة إلى نقطة البداية دون إحداثيات إضافية.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![شكل PowerPoint بحافة علوية مستقيمة، وحافة منحنية من أعلى اليمين إلى أسفل اليسار، وحافة يسرى مستقيمة](contour.png)

## **استخراج وفحص عناصر الشكل**

استخدم [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) لفحص شكل موجود كعناصر تحتوي على نقاط مسار وأنواع النقاط. حوّل كل [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) مُرجَع إلى [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) لقراءة المصفوفات المُرجَعة من [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) و[get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). هذا التمثيل مفيد لتحليل الحدود أو تمرير الهندسة إلى أدوات رسم مخصصة.

يفتح المثال عرضًا تقديميًا، يجد أول شكل هندسي مباشرة على الشريحة الأولى، ويطبع شرائحه. استخدم عرضًا يحتوي على شكل بشرائح مستقيمة ومنحنية لرؤية كلا النوعين من الإخراج. لا يبحث داخل المجموعات.

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
        auto pointType = types[i] & 0x07; // احتفظ بنوع الشريحة، مستثنياً العلامات.
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
                i += 2; // استهلك كل من نقطتي التحكم ونقطة النهاية.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

المصفوفات مرتبطة حسب الفهرس: `points[i]` هي نقطة و`types[i]` تصف دورها. النوع `0` يبدأ شكلاً، والنوع `1` يرسم خطًا من النقطة السابقة إلى الحالية. يبدأ شريحة بيزيه مكعّب من النقطة النهائية السابقة ويستخدم ثلاث إدخالات متتالية من النوع `3`: نقطتا تحكم ثم نقطة النهاية الجديدة. يستهلك الحلقة هذه الثلاث إدخالات معًا ويفحص نقطة النهاية للإغلاق.

تحتوي أنواع النقاط أيضًا على أعلام. استخدم القناع `0x07` لتحديد نوع الشريحة، واختبر `0x80` بشكل منفصل لاكتشاف مسار فرعي مغلق. على سبيل المثال، `129` (`0x81`) يعني نقطة نهاية خط تُغلق مسارًا فرعيًا، و`131` (`0x83`) يعني نقطة نهاية بيزيه تُغلق واحدًا. مقارنة القيمة الخام فقط مع `1` أو `3` سيفوت هذه الحالات. الأعلام الأخرى مثل الشرط (`0x10`) والعلامة (`0x20`) لا تغير نوع الشريحة الأساسي.

**الإحداثيات والتحويلات.** تُقاس النقاط بوحدات النقطة (1/72 بوصة)، مع زيادة X إلى اليمين وY إلى الأسفل. بالنسبة لشكل غير مجموعة، تشمل الإحداثيات المستخرجة بالفعل الموضع المُرجَع من [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) و[get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) وتعكس عرضه وارتفاعه الحالي. على سبيل المثال، مستطيل غير مُدوَّر عند `(100, 200)` بحجم `120 × 80` له حدود محيط `(100, 200)`–`(220, 280)`. لا تُضِف موضع الشكل مرة أخرى. اطرح X وY للحصول على إحداثيات نسبية لإطار الشكل غير المُدوَّر.

النقاط المستخرجة لا تُطبق دورانًا تم تعيينه عبر [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) أو انعكاسات أفقية/عمودية. لإعادة إنتاج الحدود المعروضة، طبّق تلك التحويلات حول مركز الشكل. بالنسبة للأشكال المجمعة، احسِب أيضًا تحويلات إحداثيات المجموعة؛ لا تفترض أن النقاط المستخرجة هي إحداثيات الشرائح النهائية أو أن الترجمة أو المقياس تُطبق مرتين إذا كان مُعكسًا بالفعل في إطار الطفل.

**الفحص مقابل التحرير.** تصف المصفوفات المستخرجة الحدود؛ تعديلها لا يحدّث الشكل الأصلي. استخدم هذا النهج عندما تتطلب تحليلاتك أو رمز الرسم مصفوفات نقاط/أنواع. استخدم [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) عندما تحتاج إلى أوامر هندسة في نظام إحداثيات الشكل المحلي أو تريد تحرير هندسته. طبّق المسارات المعدلة عبر [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) أو [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **تحويل GeometryPath إلى GraphicsPath**

لا تُظهر واجهة برمجة التطبيقات العامة الحالية لـ Aspose.Slides للغة C++ تحويلات بين مسارات الهندسة ومسارات الرسومات. لفحص حد، استخدم عناصر الشكل كما هو موضح أعلاه. لتحرير شكل، استخدم مسارات الهندسة وطبق المسارات المحدثة على الشكل.

## **الأسئلة المتداولة**

**ماذا يحدث للملء والحد بعد استبدال الهندسة؟**

تظل الأنماط مع الشكل؛ يتغير الحد فقط. يُطبق الملء والحد تلقائيًا على الهندسة الجديدة.

**كيف أدير الشكل المخصص مع هندسته بشكل صحيح؟**

استخدم طريقة الشكل [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/); تدور الهندسة مع الشكل لأنها مرتبطة بنظام إحداثيات الشكل نفسه.

**هل يمكنني تحويل الشكل المخصص إلى صورة لتثبيت النتيجة؟**

نعم. صدّر المنطقة المطلوبة من [slide](/slides/ar/cpp/convert-powerpoint-to-png/) أو [shape](/slides/ar/cpp/shape-thumbnails/) إلى تنسيق نقطي؛ يبسط ذلك العمل الإضافي مع الهندسات المعقّدة.