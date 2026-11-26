---
title: سفارشی‌سازی اشکال ارائه در C++
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/cpp/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ایجاد شکل
- تغییر شکل
- هندسه شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایش
- افزودن نقطه
- حذف نقطه
- عملیات ویرایشی
- گوشه منحنی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای C++: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که چگونه می‌توانید شکل‌های ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کنید. این مقاله نشان می‌دهد که چگونه با [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) کار کنید تا شکل‌های موجود را تغییر دهید، عملیات پایه‌ای ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسه به‌روز شده را به شکل اعمال کنید.

همچنین نحوهٔ ایجاد شکل‌های سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی و تعیین اینکه آیا هندسهٔ یک شکل بسته است یا نه را نشان می‌دهد.

## **تغییر یک شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید با **Edit Points** یک مربع را اصلاح کنید:

* یک گوشه را به سمت داخل یا خارج حرکت دهید.
* انحنای یک نقطه را تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما اجازه می‌دهد مرز شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایه برای شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![تصویر نمای کلی](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل به هم توسط قطعه‌ها تشکیل شده است.
* یک قطعه می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر می‌توانند به عنوان نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود داشته باشند:
  * در یک نقطه گوشه‌ای، قطعات مجاور می‌توانند با زاویه‌ای به هم بپیوندند.
  * در یک نقطه صاف، دو دسته کنترل هم‌راستا و به‌صورت مساوی از نقطه لنگر فاصله دارند.
  * در یک نقطه مستقیم، دو دسته کنترل هم‌راستا هستند اما ممکن است فاصله‌های متفاوتی نسبت به نقطه لنگر داشته باشند.
* جابجایی نقاط لنگر یا تنظیم دسته‌های آن‌ها مرز شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) و رابط [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) مسیر هندسی [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) از نمونهٔ [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) می‌توانید از متد [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) برای یک شکل، می‌توانید این متدها را استفاده کنید: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) برای اشکالی که مسیر تک دارند و [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) برای اشکالی که مسیرهای چندگانه دارند.
* برای افزودن قطعه‌ها می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از متدهای [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) و [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/) می‌توانید ظاهر مسیر هندسی را تنظیم کنید.
* با استفاده از متد [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) را به صورت آرایه‌ای از قطعه‌های مسیر دریافت کنید.

## **عملیات ساده ویرایش**

از متدهای زیر برای ویرایش مسیر هندسی استفاده کنید. بارگذاری‌هایی که یک شاخص می‌پذیرند، قطعه‌ای را در آن موقعیت صفر‑مبنا در آرایهٔ قطعه‌های مسیر درج می‌کنند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| افزودن یا درج یک منحنی Bézier مکعب با دو نقطهٔ کنترل و نقطهٔ پایان. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| افزودن یا درج یک منحنی Bézier درجه دو با یک نقطهٔ کنترل و نقطهٔ پایان. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| افزودن کمان بیضوی با ابعاد و زاویه‌های مشخص به درجه. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| بستن شکل جاری با اتصال نقطهٔ انتها به نقطهٔ شروع. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| حذف یک قطعه در شاخص صفر‑مبنا. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) وارد می‌کند و مسیر ویرایش‌ شده را با [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌نماید. مختصات‌ها نسبت به شکل محلی هستند: هر دو نقطهٔ جدید در مرکز آن قرار دارند، ۱۰۰ point از سمت چپ و ۵۰ point از بالا فاصله دارند. شاخص‌های قطعهٔ 1 و 4 آن‌ها را بر روی لبه‌های بالا و پایین قرار می‌دهند و این لبه‌ها را به سمت داخل می‌کشند.

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

![تصویر مثال 1](custom_shape_1.png)

## **حذف نقاط از یک شکل**

این مثال مرز شکل قلبی را با حذف قطعه در شاخص صفر‑مبنا ۲ با استفاده از [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) مرز شکل را به‌روز می‌کند.

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
![تصویر مثال 2](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

این مثال یک ستارهٔ پنج‌پر با استفاده از [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ point نقاط نوک و فرورفتگی را تعیین می‌کنند؛ گام ۷۲ درجه فاصلهٔ مساوی بین پنج نوک ایجاد می‌کند. مسیر با [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) بسته می‌شود و با استفاده از [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) به شکل مستطیلی اعمال می‌شود و مرز آن را جایگزین می‌کند.

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
![تصویر مثال 3](custom_shape_3.png)

## **ایجاد یک شکل سفارشی ترکیبی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) بسته برای یک‑سیمهٔ بالایی و یک‑سیمهٔ پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) یک شکل ترکیبی واحد با یک فاصله در یک‑سومِ میانی ایجاد می‌کند.

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
![تصویر مثال 4](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال قطعه‌های مستقیم را با [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) ترکیب می‌کند تا شکلی با گوشه‌های داخلی منحنی ایجاد شود. اندازهٔ هر گوشه، عرض و ارتفاع کمان را بر حسب point تنظیم می‌کند و Sweep ‑۹۰ درجه یک ربع بیضی ساعت‌گرد معکوس رسم می‌کند. مسیر کامل با [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌شود.

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

## **یافتن اینکه آیا هندسهٔ یک شکل بسته است یا نه**

کمک‌فنکشن زیر بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک قطعهٔ بسته پایان می‌یابد یا نه. این تابع [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) را می‌خواند و [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) نهایی را با [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیرهای غیرخالی وجود نداشته باشند، مقدار false برمی‌گرداند. این بررسی فقط فرمان نهایی هر مسیر را چک می‌کند؛ زیرشکل‌های داخلی مسیر بررسی نمی‌شوند. مثال برای یک مستطیل مقدار `True` را چاپ می‌کند.

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

## **بازرسی دستورات مسیر هندسی**

فایل [contour.pptx](contour.pptx) را دانلود کنید و در پوشهٔ کاری برنامه قرار دهید. اولین شکل در اسلاید اول دارای لبهٔ بالایی مستقیم، یک منحنی Bézier مکعب و لبهٔ بستهٔ مستقیم است. با استفاده از [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) مسیرهای آن را بخوانید. برای هر مسیر، متد [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) قطعه‌ها را به ترتیب رسم برمی‌گرداند. فرمان بازگردانده شده توسط [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) نحوهٔ تفسیر مقادیر برگشتی توسط [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/) را تعیین می‌کند.

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

شکل در مختصات (200, 100) point روی اسلاید قرار دارد. نقاط گزارش‌شده به صورت محلی نسبت به شکل هستند؛ (0, 0) در گوشهٔ بالا‑چپ آن قرار دارد، x به سمت راست و y به سمت پایین افزایش می‌یابد. قطعهٔ بسته بدون مختصات اضافی به نقطهٔ شروع باز می‌گردد.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![شکل PowerPoint با لبهٔ بالایی مستقیم، لبهٔ منحنی از راست بالا به چپ پایین، و لبهٔ چپ مستقیم](contour.png)

## **استخراج و بررسی عناصر شکل**

از متد [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) برای بررسی یک شکل موجود به صورت عناصری شامل نقاط مسیر و انواع نقطه‌ها استفاده کنید. هر [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) بازگردانده‌شده را به [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) تبدیل کنید تا آرایه‌های بازگردانده‌شده توسط [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) و [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) را بخوانید. این نمایش برای تحلیل مرز یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال یک ارائه را باز می‌کند، اولین شکل هندسی را مستقیماً روی اسلاید اول پیدا می‌کند و قطعه‌های مسیر آن را چاپ می‌کند. برای مشاهدهٔ هر دو نوع خروجی، از ارائه‌ای استفاده کنید که شامل یک شکل با قطعه‌های مستقیم و منحنی باشد. این روش به‌صورت بازگشتی درون گروه‌ها جستجو نمی‌کند.

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
        auto pointType = types[i] & 0x07; // نوع قطعه را حفظ کنید، پرچم‌ها را مستثنی کنید.
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

آرایه‌ها بر اساس شاخص هم‌پوشانی دارند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را آغاز می‌کند و نوع `1` خطی از نقطهٔ قبلی به نقطهٔ جاری می‌کشد. یک قطعه Bézier مکعب از نقطهٔ انتهایی قبلی آغاز می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌همراه هم مصرف می‌کند و نقطهٔ انتهایی را برای بستن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها می‌شوند. برای شناسایی نوع قطعه، ماسک `0x07` را اعمال کنید و برای تشخیص زیرمسیر بسته، پرچم `0x80` را جداگانه بررسی کنید. برای مثال، `129` (`0x81`) نشان دهندهٔ نقطهٔ انتهایی خطی است که زیرمسیر را می‌بندد و `131` (`0x83`) نشان دهندهٔ نقطهٔ انتهایی Bézier است که یک زیرمسیر را می‌بندد. مقایسهٔ مقدار خام تنها با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند خط تیره (`0x10`) و علامت (`0x20`) نوع پایهٔ قطعه را تغییر نمی‌دهند.

**مختصات و تبدیلات.** نقاط بر حسب point (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل غیرگروه‌شده، مختصات استخراج‌شده قبلاً موقعیت بازگردانده‌شده توسط [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) و [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) را شامل می‌شود و عرض و ارتفاع فعلی آن را منعکس می‌کند. برای مثال، یک مستطیل بدون چرخش در موقعیت `(100, 200)` با اندازهٔ `120 × 80` حدود مرز `(100, 200)`–`(220, 280)` دارد. موقعیت شکل را دوباره اضافه نکنید؛ برای به‌دست آوردن مختصات نسبی به چارچوب غیرچرخان آن، X و Y آن را تفریق کنید.

نقاط استخراج‌شده چرخش تنظیم‌شده توسط [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) یا وارونه‌های افقی و عمودی را اعمال نمی‌کنند. برای بازآفرینی مرز نمایش داده‌شده، این تبدیلات را دور مرکز شکل اعمال کنید. برای شکل‌های گروهی، همچنین تبدیل مختصات گروه و تبدیلات را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا ترجمه/مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند بازتاب داده شده باشد.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده مرز را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روز نمی‌کند. وقتی تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد، این روش را انتخاب کنید. برای دریافت دستورات هندسی در سیستم مختصات محلی شکل یا برای ویرایش هندسه از [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) یا [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) اعمال کنید.

## **تبدیل GeometryPath به GraphicsPath**

API عمومی فعلی Aspose.Slides برای C++ تبدیل‌های بین مسیرهای هندسی و مسیرهای گرافیکی را منتشر نمی‌کند. برای بررسی یک مرز، از عناصر شکل همان‌طور که در بالا شرح شد استفاده کنید. برای ویرایش یک شکل، از مسیرهای هندسی استفاده کنید و مسیرهای به‌روز شده را به شکل اعمال کنید.

## **سوالات متداول**

**بعد از جایگزینی هندسه، پرکردن و خطوط مرزی چه اتفاقی می‌افتد؟**

استایل با شکل باقی می‌ماند؛ فقط مرز تغییر می‌کند. پرکردن و خط مرزی به‌صورت خودکار بر روی هندسهٔ جدید اعمال می‌شوند.

**چگونه یک شکل سفارشی را به‌درستی همراه با هندسهٔ آن بچرخانم؟**

از متد [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا نتیجه «قفل» شود؟**

بله. ناحیهٔ مورد نیاز را از طریق [slide](/slides/fa/cpp/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/cpp/shape-thumbnails/) به فرمت رستری صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده می‌کند.