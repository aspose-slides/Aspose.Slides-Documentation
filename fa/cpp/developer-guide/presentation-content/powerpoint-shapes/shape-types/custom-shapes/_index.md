---
title: سفارشی‌سازی شکل‌های ارائه در C++
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
- پاورپوینت
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های پاورپوینت با Aspose.Slides برای C++: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **بررسی کلی**

این مقاله نحوهٔ سفارشی‌سازی شکل‌های ارائه در Aspose.Slides را از طریق ویرایش هندسه شکل با استفاده از نقاط و مسیرهای هندسی توضیح می‌دهد. نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) به‌منظور تغییر شکل‌های موجود، انجام عملیات پایهٔ ویرایش مسیر، اضافه یا حذف نقاط و اعمال هندسهٔ به‌روز شده به یک شکل کار کنید.

همچنین نحوهٔ ایجاد شکل‌های سفارشی و ترکیبی، ساخت شکل‌ها با گوشه‌های منحنی، و تعیین اینکه آیا هندسهٔ یک شکل بسته است را نیز نشان می‌دهد.

## **تغییر شکل با استفاده از نقاط ویرایش**

در PowerPoint می‌توانید با **نقاط ویرایش** یک مربع را اصلاح کنید:

* حرکت یک گوشه به سمت داخل یا خارج.
* تنظیم انحنا در یک نقطه.
* افزودن نقاط جدید.

ویرایش نقاط به شما امکان می‌دهد مرز یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایهٔ یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش شکل‌های PowerPoint، این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر متصل‌شده توسط بخش‌ها تشکیل می‌شود.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دستگیره‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر به‌عنوان نقاط گوشه‌ای، مستقیم یا صاف وجود دارند:
  * در یک نقطهٔ گوشه‌ای، بخش‌های مجاور می‌توانند با زاویه‌ای به‌یکدیگر ملحق شوند.
  * در یک نقطهٔ صاف، دو دستگیرهٔ کنترل هم‌محور هستند و فاصلهٔ مساوی از نقطهٔ لنگر دارند.
  * در یک نقطهٔ مستقیم، دو دستگیرهٔ کنترل هم‌محور هستند اما می‌توانند فاصله‌های متفاوتی از نقطهٔ لنگر داشته باشند.
* جابه‌جایی نقاط لنگر یا تنظیم دستگیره‌هایشان مرز شکل را تغییر می‌دهد.

برای ویرایش شکل‌های PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) و رابط [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) از نمونهٔ [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/)، می‌توانید از متد [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) برای یک شکل، می‌توانید این متدها را استفاده کنید: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) برای شکل‌های با مسیر واحد و [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) برای شکل‌های با مسیرهای متعدد.
* برای افزودن بخش‌ها، می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از متدهای [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) و [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/)، می‌توانید ظاهر یک مسیر هندسی را تعیین کنید.
* با استفاده از متد [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/)، می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.

## **عملیات ساده ویرایش**

از روش‌های زیر برای ویرایش یک مسیر هندسی استفاده کنید. نسخه‌های بارگذاری‌شده که یک ایندکس می‌پذیرند، بخشی را در آن موقعیت صفر‑پایه در آرایهٔ بخش‌های مسیر درج می‌کنند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| افزودن یا درج یک منحنی Bézier مکعبی با دو نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| افزودن یا درج یک منحنی Bézier درجهٔ دو با یک نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| افزودن یک قوس بیضوی با ابعاد و زاویه‌های مشخص به‌درجه. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| بستن شکل جاری با وصل نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| حذف یک بخش در ایندکس صفر‑پایه. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) وارد می‌کند و مسیر ویرایش‌شده را با [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌کند. مختصات‌ها به‌صورت محلی نسبت به شکل هستند: هر دو نقطه جدید در مرکز آن قرار دارند، ۱۰۰ نقطه از سمت چپ و ۵۰ نقطه از بالای شکل. ایندکس‌های بخش ۱ و ۴ آن‌ها را بر لبهٔ بالا و پایین قرار می‌دهند و این لبه‌ها را به‌سوی داخل می‌کشند.

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

## **حذف نقاط از یک شکل**

این مثال با حذف بخش در ایندکس صفر‑پایهٔ ۲ با استفاده از [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) قالب قلبی شکل را تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) مرز شکل را به‌روزرسانی می‌کند.

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

## **ایجاد یک شکل سفارشی**

این مثال یک ستارهٔ پنج‌پره با استفاده از [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی متناوب به ترتیب ۱۰۰ و ۵۰ نقطه نکات و برآمدگی‌ها را تعریف می‌کنند؛ گامی به‌اندازهٔ ۷۲ درجه پنج نکته را به‌طور مساوی فاصله می‌دهد. مسیر با [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) بسته می‌شود و با استفاده از [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) به یک شکل مستطیلی اعمال می‌گردد و قالب آن جایگزین می‌شود.

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

## **ایجاد یک شکل سفارشی ترکیبی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) بسته برای یک‌سوم بالایی و پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) یک شکل ترکیبی واحد با یک فاصله در یک‌سوم میانی آن ایجاد می‌کند.

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
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال بخش‌های مستقیم را با [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) ترکیب می‌کند تا شکلی با گوشه‌های داخلی منحنی ایجاد شود. اندازهٔ هر گوشه عرض و ارتفاع قوس را بر حسب نقاط تنظیم می‌کند و بازهٔ -90 درجه یک ربع بیضی پاد ساعت جهت می‌کشاند. مسیر نهایی با [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌شود.

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

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

کمک‌کنندهٔ زیر بررسی می‌کند که آیا هر مسیر هندسی غیرخالی با یک بخش بسته به پایان می‌رسد یا نه. این تابع [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) را می‌خواند و دستور نهایی [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) را با [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیرهای غیرخالی وجود نداشته باشد، مقدار false برمی‌گرداند. این بررسی تنها دستور نهایی هر مسیر را می‌سنجد؛ تمام زیرشکل‌های داخل مسیر را بررسی نمی‌کند. مثال برای یک مستطیل مقدار `True` چاپ می‌کند.

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

## **استخراج و بررسی عناصر شکل**

از [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) برای بررسی یک شکل موجود به‌عنوان عناصری حاوی نقاط مسیر و انواع نقاط استفاده کنید. هر [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) بازگشتی را به [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) تبدیل کنید تا آرایه‌های بازگشتی توسط [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) و [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/) را بخوانید. این نمایش برای تحلیل مرز یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال یک ارائه را باز می‌کند، اولین شکل هندسی را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. برای مشاهده خروجی‌های هر دو نوع بخش مستقیم و منحنی، از یک ارائه حاوی شکل با این دو نوع بخش استفاده کنید. این روش درون گروه‌ها را جستجو نمی‌کند.

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
        auto pointType = types[i] & 0x07; // نوع بخش را نگه می‌دارد و پرچم‌ها را مستثنی می‌کند.
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
                i += 2; // هر دو نقطهٔ کنترل و نقطهٔ انتهایی را مصرف می‌کند.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

آرایه‌ها بر اساس ایندکس مطابقت دارند: `points[i]` یک نقطه و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را شروع می‌کند و نوع `1` خطی را از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک بخش Bézier مکعبی از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل و سپس نقطهٔ انتهای جدید. حلقه این سه ورودی را به‌هم‌راه مصرف می‌کند و نقطهٔ انتهای آن را برای بسته بودن بررسی می‌کند.

انواع نقاط همچنین حاوی پرچم‌ها هستند. با ماسک `0x07` نوع بخش را شناسایی کنید و با تست `0x80` به‌طور جداگانه برای تشخیص زیرمسیر بسته استفاده کنید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که زیرمسیر را می‌بندد و `131` (`0x83`) نقطهٔ انتهایی Bézier است که بسته می‌شود. مقایسهٔ مقدار خام تنها با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند خط‌چین (`0x10`) و نشانگر (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط با واحد نقطه (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل غیرگروه‌شده، مختصات استخراج‌شده قبلاً موقعیت بازگردانده‌شده توسط [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) و [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) و عرض و ارتفاع فعلی آن را شامل می‌شود. برای مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` دارای محدودهٔ مرزی `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوباره اضافه نکنید. برای به‌دست آوردن مختصات نسبت به چارچوب بدون چرخش، X و Y آن را کم کنید.

نقاط استخراج‌شده چرخشی که از طریق [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) تعیین شده یا انقلابات افقی/عمودی را اعمال نمی‌کنند. برای بازتولید مرزی نمایش داده‌شده، این تبدیل‌ها را حول مرکز شکل اعمال کنید. برای شکل‌های گروهی، همچنین باید نگاشت مختصات گروه و تبدیل‌ها را درنظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده نهایی‌ترین مختصات اسلاید رندر شده‌اند یا ترجمه یا مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده است.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده مرز را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. وقتی تحلیل یا کد رسم شما به آرایهٔ نقطه/نوع نیاز دارد، از این روش استفاده کنید. برای دریافت دستورات هندسی در سیستم مختصات محلی شکل یا برای ویرایش هندسه، از [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) یا [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) اعمال کنید.

## **تبدیل GeometryPath به GraphicsPath**

API عمومی فعلی Aspose.Slides برای C++ تبدیل‌های بین مسیرهای هندسی و مسیرهای گرافیکی را افشا نمی‌کند. برای بررسی یک مرز، از عناصر شکل همان‌گونه که در بالا توضیح داده شد استفاده کنید. برای ویرایش یک شکل، از مسیرهای هندسی استفاده کنید و مسیرهای بروز‌رسانی‌شده را به شکل اعمال کنید.

## **پرسش‌های متداول**

**بعد از جایگزینی هندسه، پرکننده و خطوط پیرامونی چگونه رفتار می‌کنند؟**

استایل همراه با شکل باقی می‌ماند؛ فقط مرز تغییر می‌کند. پرکننده و خطوط پیرامونی به‌طور خودکار بر هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را همراه با هندسه‌اش به‌درستی چرخانده کنم؟**

از متد [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «نتیجه» را قفل کنم؟**

بله. ناحیهٔ [slide](/slides/fa/cpp/convert-powerpoint-to-png/) مورد نیاز یا خودش [shape](/slides/fa/cpp/shape-thumbnails/) را به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌کند.