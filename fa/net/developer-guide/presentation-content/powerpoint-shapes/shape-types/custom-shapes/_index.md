---
title: سفارشی‌سازی اشکال ارائه در .NET
linktitle: شکل سفارشی
type: docs
weight: 20
url: /fa/net/custom-shape/
keywords:
- شکل سفارشی
- افزودن شکل
- ایجاد شکل
- تغییر شکل
- هندسهٔ شکل
- مسیر هندسی
- نقاط مسیر
- نقاط ویرایش
- افزودن نقطه
- حذف نقطه
- عملیات ویرایش
- گوشهٔ خمیده
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های PowerPoint با Aspose.Slides برای .NET: مسیرهای هندسی، گوشه‌های خمیده، اشکال ترکیبی."
---
## **بررسی کلی**

این مقاله نحوهٔ سفارشی‌سازی اشکال ارائه در Aspose.Slides را از طریق ویرایش هندسهٔ شکل با استفاده از نقاط و مسیرهای هندسی توضیح می‌دهد. نشان می‌دهد چگونه با `GeometryPath` و `IGeometryPath` می‌توان اشکال موجود را تغییر داد، عملیات پایهٔ ویرایش مسیر را انجام داد، نقاط را اضافه یا حذف کرد و هندسهٔ به‌روز شده را به شکل اعمال کرد.

همچنین نشان می‌دهد چگونه اشکال سفارشی و ترکیبی ایجاد شود، اشکال با گوشه‌های خمیده ساخته شود، تشخیص داده شود که آیا هندسهٔ یک شکل بسته است یا خیر، و بین `GeometryPath` و `GraphicsPath` برای سناریوهای سفارشی‌سازی هندسهٔ بیشتر تبدیل انجام شود.

## **تغییر شکل با استفاده از نقاط ویرایش**

یک مربع را در نظر بگیرید. در PowerPoint، با استفاده از **نقاط ویرایش** می‌توانید  

* گوشهٔ مربع را به سمت داخل یا خارج حرکت دهید  
* انحنای یک گوشه یا نقطه را مشخص کنید  
* نقاط جدیدی به مربع اضافه کنید  
* نقاط روی مربع را دست‌کاری کنید و ...

به‌طور کلی می‌توانید این کارها را بر روی هر شکلی انجام دهید. با استفاده از نقاط ویرایش می‌توانید یک شکل را تغییر داده یا شکل جدیدی از شکل موجود بسازید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

قبل از شروع به ویرایش اشکال PowerPoint از طریق نقاط ویرایش، ممکن است بخواهید به نکات زیر دربارهٔ اشکال توجه کنید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.  
* تمام اشکال حداقل از ۲ نقطهٔ لنگر تشکیل شده‌اند که توسط خطوط به یکدیگر متصل می‌شوند.  
* یک خط می‌تواند مستقیم یا منحنی باشد. نقاط لنگر ماهیت خط را تعیین می‌کنند.  
* نقاط لنگر به صورت نقاط گوشه‌ای، مستقیم یا صاف وجود دارند:  
  * نقطهٔ گوشه‌ای نقطه‌ای است که در آن دو خط مستقیم با یک زاویه به هم می‌رسند.  
  * نقطهٔ صاف نقطه‌ای است که در آن دو دسته‌دار (handle) در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت منحنی نرم به هم می‌پیوندند. در این حالت تمام دسته‌ها فاصلهٔ مساوی از نقطهٔ لنگر دارند.  
  * نقطهٔ مستقیم نقطه‌ای است که در آن دو دسته‌دار در یک خط مستقیم قرار دارند و بخش‌های خط به‌صورت منحنی به هم می‌پیوندند. در این حالت دسته‌ها نیاز به داشتن فاصلهٔ مساوی از نقطهٔ لنگر ندارند.  
* با جابه‌جایی یا ویرایش نقاط لنگر (که زاویهٔ خطوط را تغییر می‌دهد) می‌توانید ظاهر شکل را تغییر دهید.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [**GeometryPath**](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) و رابط [**IGeometryPath**](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometrypath) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape) را نشان می‌دهد.  
* برای دریافت `GeometryPath` از نمونهٔ `IGeometryShape` می‌توانید از متد [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/methods/getgeometrypaths) استفاده کنید.  
* برای تنظیم `GeometryPath` برای یک شکل می‌توانید این متدها را به کار ببرید: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/methods/setgeometrypath) برای *اشکال جامد* و [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/methods/setgeometrypaths) برای *اشکال ترکیبی*.  
* برای افزودن بخش‌ها می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometrypath) استفاده کنید.  
* با استفاده از ویژگی‌های [IGeometryPath.Stroke](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometrypath/properties/stroke) و [IGeometryPath.FillMode](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometrypath/properties/fillmode) می‌توانید ظاهر مسیر هندسی را تنظیم کنید.  
* با استفاده از ویژگی [IGeometryPath.PathData](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometrypath/properties/pathdata) می‌توانید مسیر هندسی یک `GeometryShape` را به‌صورت آرایه‌ای از بخش‌های مسیر بازیابی کنید.  
* برای دسترسی به گزینه‌های سفارشی‌سازی بیشتر هندسهٔ شکل می‌توانید [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) را به [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) تبدیل کنید.  
* از متدهای [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/fa/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) و [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (در کلاس [ShapeUtil](https://reference.aspose.com/slides/fa/net/aspose.slides.util/shapeutil)) برای تبدیل دوباره و جلو به‌یاد داشته باشید.

## **عملیات سادهٔ ویرایش**

این کد C# نشان می‌دهد چگونه  

**یک خط به انتهای مسیر اضافه کنید**

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**یک خط به موقعیتی مشخص در مسیر اضافه کنید:**  

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**یک منحنی Bezier مکعبی به انتهای مسیر اضافه کنید:**  

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**یک منحنی Bezier مکعبی به موقعیت مشخصی در مسیر اضافه کنید:**  

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**یک منحنی Bezier درجهٔ دو به انتهای مسیر اضافه کنید:**  

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**یک منحنی Bezier درجهٔ دو به موقعیت مشخصی در مسیر اضافه کنید:**  

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**یک قوس داده‌شده را به مسیر اضافه کنید:**  

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**شکل جاری مسیر را ببندید:**  

``` csharp
void CloseFigure();
```
**موقعیت نقطهٔ بعدی را تعیین کنید:**  

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**بخش مسیر را در ایندکس مشخص حذف کنید:**  

``` csharp
void RemoveAt(int index);
```

## **افزودن نقاط سفارشی به یک شکل**

1. نمونه‌ای از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/net/aspose.slides/geometryshape) بسازید و نوع [ShapeType.Rectangle](https://reference.aspose.com/slides/fa/net/aspose.slides/shapetype) را تنظیم کنید.  
2. نمونه‌ای از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) را از شکل دریافت کنید.  
3. نقطهٔ جدیدی بین دو نقطهٔ بالایی مسیر اضافه کنید.  
4. نقطهٔ جدیدی بین دو نقطهٔ پایینی مسیر اضافه کنید.  
5. مسیر را به شکل اعمال کنید.

این کد C# نشان می‌دهد چگونه نقاط سفارشی را به یک شکل اضافه کنید:

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

##  **حذف نقاط از یک شکل**

1. نمونه‌ای از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/net/aspose.slides/geometryshape) بسازید و نوع [ShapeType.Heart](https://reference.aspose.com/slides/fa/net/aspose.slides/shapetype) را تنظیم کنید.  
2. نمونه‌ای از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) را از شکل دریافت کنید.  
3. بخش مسیر را حذف کنید.  
4. مسیر را به شکل اعمال کنید.

این کد C# نشان می‌دهد چگونه نقاط را از یک شکل حذف کنید:

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

##  **ایجاد یک شکل سفارشی**

1. نقاط شکل را محاسبه کنید.  
2. نمونه‌ای از کلاس [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) بسازید.  
3. مسیر را با نقاط پر کنید.  
4. نمونه‌ای از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/net/aspose.slides/geometryshape) بسازید.  
5. مسیر را به شکل اعمال کنید.

این کد C# نشان می‌دهد چگونه یک شکل سفارشی ایجاد کنید:

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

## **ایجاد یک شکل سفارشی ترکیبی**

1. نمونه‌ای از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/net/aspose.slides/geometryshape) بسازید.  
2. اولین نمونهٔ کلاس [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) را ایجاد کنید.  
3. دومین نمونهٔ کلاس [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) را ایجاد کنید.  
4. مسیرها را به شکل اعمال کنید.

این کد C# نشان می‌دهد چگونه یک شکل سفارشی ترکیبی ایجاد کنید:

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

## **ایجاد یک شکل سفارشی با گوشه‌های خمیده**

این کد C# نشان می‌دهد چگونه یک شکل سفارشی با گوشه‌های خمیده (به سمت داخل) ایجاد کنید:

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

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

یک شکل بسته به‌عنوان شکلی تعریف می‌شود که تمام اضلاع آن به‌هم متصل باشند و یک مرز واحد بدون شکاف داشته باشد. چنین شکلی می‌تواند یک فرم هندسی ساده یا یک طرح سفارشی پیچیده باشد. مثال کد زیر نشان می‌دهد چگونه بررسی شود که آیا هندسهٔ یک شکل بسته است یا خیر:

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

## **تبدیل GeometryPath به GraphicsPath (System.Drawing.Drawing2D)**

1. نمونه‌ای از کلاس [GeometryShape](https://reference.aspose.com/slides/fa/net/aspose.slides/geometryshape) بسازید.  
2. نمونه‌ای از کلاس [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) در فضای نام [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) ایجاد کنید.  
3. نمونهٔ [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) را به نمونهٔ [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath) با استفاده از [ShapeUtil](https://reference.aspose.com/slides/fa/net/aspose.slides.util/shapeutil) تبدیل کنید.  
4. مسیرها را به شکل اعمال کنید.

این کد C#—یک پیاده‌سازی از مراحل فوق—فرآیند تبدیل **GeometryPath** به **GraphicsPath** را نشان می‌دهد:

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

## **سؤالات متداول**

**بعد از جایگزینی هندسه، پر رنگ و حاشیه چه می‌شوند؟**

استایل همراه با شکل می‌ماند؛ فقط کانتور تغییر می‌کند. پر رنگ و حاشیه به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توان شکل سفارشی را به‌درستی همراه با هندسه‌اش چرخاند؟**

از ویژگی [rotation](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/rotation/) شکل استفاده کنید؛ هندسه به‌دلیل ارتباط با سامانهٔ مختصات شکل، با آن می‌چرخد.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. ناحیهٔ مورد نیاز [اسلاید](/slides/fa/net/convert-powerpoint-to-png/) یا خود [شکل](/slides/fa/net/create-shape-thumbnails/) را به فرمت رستری صادر کنید؛ این کار کار با هندسه‌های سنگین را ساده می‌کند.