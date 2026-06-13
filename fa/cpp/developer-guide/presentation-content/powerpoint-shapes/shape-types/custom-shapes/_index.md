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
- عملیات ویرایش
- گوشه منحنی
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای C++: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد چگونه می‌توان اشکال ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کرد. نشان می‌دهد چگونه با `GeometryPath` و `IGeometryPath` کار کنید تا شکل‌های موجود را تغییر دهید، عملیات پایه ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسه به‌روزشده را به شکل اعمال کنید.

## **تغییر شکل با استفاده از نقاط ویرایش**
در نظر بگیرید یک مربع. در PowerPoint، با استفاده از **نقاط ویرایش** می‌توانید  

* گوشهٔ مربع را به داخل یا خارج ببرید  
* انحنا برای یک گوشه یا نقطه را مشخص کنید  
* نقاط جدید به مربع اضافه کنید  
* نقاط روی مربع را دستکاری کنید و غیره  

به‌طور کلی می‌توانید کارهای توصیف‌شده را بر روی هر شکلی انجام دهید. با نقاط ویرایش می‌توانید شکل را تغییر داده یا شکل جدیدی از شکل موجود بسازید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

قبل از شروع به ویرایش اشکال PowerPoint از طریق نقاط ویرایت، بهتر است این نکات را دربارهٔ اشکال در نظر بگیرید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.  
* وقتی یک شکل بسته است، نقطهٔ شروع یا پایان ندارد. وقتی یک شکل باز است، دارای آغاز و پایان است.  
* تمام اشکال حداقل شامل ۲ نقطهٔ لنگر هستند که توسط خطوط به هم متصل می‌شوند.  
* یک خط می‌تواند مستقیم یا منحنی باشد. نقطه‌های لنگر مشخص‌کنندهٔ نوع خط هستند.  
* نقطه‌های لنگر می‌توانند به صورت نقطهٔ گوشه‌ای، مستقیم یا صاف وجود داشته باشند:  
  * نقطهٔ گوشه‌ای نقطه‌ای است که دو خط مستقیم در زاویه‌ای به هم می‌رسند.  
  * نقطهٔ صاف نقطه‌ای است که دو دستگیره در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت منحنی صاف به هم می‌پیوندند. در این حالت تمام دستگیره‌ها فاصلهٔ مساوی از نقطهٔ لنگر دارند.  
  * نقطهٔ مستقیم نقطه‌ای است که دو دستگیره در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت منحنی صاف به هم می‌پیوندند. در این حالت دستگیره‌ها نیازی به فاصلهٔ مساوی از نقطهٔ لنگر ندارند.  
* با جابه‌جایی یا ویرایش نقطه‌های لنگر (که زاویهٔ خطوط را تغییر می‌دهد) می‌توانید ظاهر شکل را تغییر دهید.  

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایت، **Aspose.Slides** کلاس [**GeometryPath**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) و رابط [**IGeometryPath**](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_path) را فراهم می‌کند.

* نمونهٔ کلاس [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_shape) را نشان می‌دهد.  
* برای دریافت `GeometryPath` از نمونهٔ `IGeometryShape` می‌توانید از متد [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1) استفاده کنید.  
* برای تنظیم `GeometryPath` برای یک شکل، می‌توانید این متدها را استفاده کنید: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) برای *اشکال ثابت* و [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) برای *اشکال ترکیبی*.  
* برای اضافه کردن بخش‌ها می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_path) استفاده کنید.  
* با استفاده از متدهای [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) و [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7) می‌توانید ظاهر یک مسیر هندسی را تعیین کنید.  
* با استفاده از متد [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca) می‌توانید مسیر هندسی یک `GeometryShape` را به‌صورت آرایه‌ای از بخش‌های مسیر بازیابی کنید.  
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسه شکل، می‌توانید [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) را به [GraphicsPath](https://reference.aspose.com/slides/fa/cpp/class/system.drawing.drawing2_d.graphics_path) تبدیل کنید.  
* از متدهای [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) و [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (از کلاس [ShapeUtil](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.util.shape_util)) برای تبدیل [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) به [GraphicsPath](https://reference.aspose.com/slides/fa/cpp/class/system.drawing.drawing2_d.graphics_path) و برعکس استفاده کنید.  

## **عملیات ساده ویرایش**

این کد C++ نشان می‌دهد چگونه  

**افزودن خط** به انتهای مسیر

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**افزودن خط** به موقعیت مشخصی در مسیر:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**افزودن منحنی بزیه کروی** در انتهای مسیر:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**افزودن منحنی بزیه کروی** به موقعیت مشخصی در مسیر:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**افزودن منحنی بزیه درجه دوم** در انتهای مسیر:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**افزودن منحنی بزیه درجه دوم** به موقعیت مشخصی در مسیر:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**ضمیمه کردن قوس داده شده** به مسیر:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**بستن شکل فعلی** مسیر:

``` cpp
void CloseFigure();
```
**تنظیم موقعیت نقطهٔ بعدی**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**حذف بخش مسیر** در شاخص مشخص:

``` cpp
void RemoveAt(int32_t index);
```

## **افزودن نقاط سفارشی به یک شکل**
1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_shape) ایجاد کنید و نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) را تنظیم کنید.  
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) را از شکل دریافت کنید.  
3. یک نقطهٔ جدید بین دو نقطهٔ بالایی مسیر اضافه کنید.  
4. یک نقطهٔ جدید بین دو نقطهٔ پایینی مسیر اضافه کنید.  
5. مسیر را به شکل اعمال کنید.  

این کد C++ نشان می‌دهد چگونه نقاط سفارشی به یک شکل اضافه کنید:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **حذف نقاط از یک شکل**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_shape) ایجاد کنید و نوع [ShapeType.Heart](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5) را تنظیم کنید.  
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) را از شکل دریافت کنید.  
3. بخش مسیر را حذف کنید.  
4. مسیر را به شکل اعمال کنید.  

این کد C++ نشان می‌دهد چگونه نقاط را از یک شکل حذف کنید:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```

![example2_image](custom_shape_2.png)

## **ایجاد یک شکل سفارشی**

1. نقاط مورد نیاز برای شکل را محاسبه کنید.  
2. یک نمونه از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) ایجاد کنید.  
3. مسیر را با نقاط پر کنید.  
4. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_shape) ایجاد کنید.  
5. مسیر را به شکل اعمال کنید.  

این کد C++ نشان می‌دهد چگونه یک شکل سفارشی بسازید:

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```

![example3_image](custom_shape_3.png)

## **ایجاد یک شکل ترکیبی سفارشی**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_shape) ایجاد کنید.  
2. یک نمونه اول از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) ایجاد کنید.  
3. یک نمونه دوم از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) ایجاد کنید.  
4. مسیرها را به شکل اعمال کنید.  

این کد C++ نشان می‌دهد چگونه یک شکل ترکیبی سفارشی بسازید:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```

![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این کد C++ نشان می‌دهد چگونه یک شکل سفارشی با گوشه‌های منحنی (به سمت درون) ایجاد کنید:

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

یک شکل بسته به‌عنوان شکلی تعریف می‌شود که تمام لبه‌های آن به‌هم متصل می‌شوند و یک مرز واحد بدون فاصله ایجاد می‌کنند. چنین شکلی می‌تواند یک فرم هندسی ساده یا یک قالب سفارشی پیچیده باشد. مثال کد زیر نشان می‌دهد چگونه بررسی کنید آیا هندسهٔ شکل بسته است یا خیر:

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **تبدیل GeometryPath به GraphicsPath**

1. یک نمونه از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_shape) ایجاد کنید.  
2. یک نمونه از کلاس [GraphicsPath](https://reference.aspose.com/slides/fa/cpp/class/system.drawing.drawing2_d.graphics_path) در فضای نامی [System.Drawing.Drawing2D](https://reference.aspose.com/slides/fa/cpp/namespace/system.drawing.drawing2_d) ایجاد کنید.  
3. نمونهٔ [GraphicsPath](https://reference.aspose.com/slides/fa/cpp/class/system.drawing.drawing2_d.graphics_path) را با استفاده از [ShapeUtil](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.util.shape_util) به نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.geometry_path) تبدیل کنید.  
4. مسیرها را به شکل اعمال کنید.  

این کد C++—پیاده‌سازی مراحل فوق—فرآیند تبدیل **GeometryPath** به **GraphicsPath** را نشان می‌دهد:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```

![example5_image](custom_shape_5.png)

## **سوالات متداول**

**پس از جایگزینی هندسه، پر کننده و خط مرزی چه اتفاقی می‌افتد؟**

استایل همچنان به شکل باقی می‌ماند؛ فقط مرز تغییر می‌کند. پر کننده و خط مرزی به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان یک شکل سفارشی را همراه با هندسه‌اش به‌درستی چرخاند؟**

از ویژگی [rotation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shape/set_rotation/) شکل استفاده کنید؛ زیرا هندسه با شکل می‌چرخد، چراکه به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ [slide](/slides/fa/cpp/convert-powerpoint-to-png/) یا خود [shape](/slides/fa/cpp/create-shape-thumbnails/) را به فرمت رستری صادر کنید؛ این کار کار با هندسه‌های سنگین را ساده‌تر می‌کند.