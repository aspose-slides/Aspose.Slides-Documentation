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
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های پاورپوینت با Aspose.Slides برای .NET: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد که چگونه می‌توانید اشکال ارائه در Aspose.Slides را با ویرایش هندسه شکل از طریق نقاط ویرایش و مسیرهای هندسی سفارشی کنید. این مقاله نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) کار کنید تا شکل‌های موجود را اصلاح کنید، عملیات پایه ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید و هندسه به‌روزشده را به یک شکل اعمال کنید.

همچنین نحوه ایجاد اشکال سفارشی و ترکیبی، ساخت اشکال با گوشه‌های منحنی، تعیین اینکه آیا هندسه یک شکل بسته است و استفاده از تبدیل قدیمی بین [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) برای سناریوهای سفارشی‌سازی هندسه اضافی را نشان می‌دهد.

## **تغییر شکل با استفاده از نقاط ویرایش**

* یک گوشه را به سمت داخل یا خارج حرکت دهید.
* انحنا را در یک نقطه تنظیم کنید.
* نقاط جدید اضافه کنید.

ویرایش نقاط به شما امکان می‌دهد خطوط یک شکل را تغییر داده یا از یک شکل موجود به‌عنوان پایه‌ای برای شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در نظر داشته باشید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل از نقاط لنگر که توسط قسمت‌ها به هم متصل هستند، تشکیل شده است.
* یک قسمت می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر می‌توانند به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف وجود داشته باشند:
  * در یک نقطه گوشه‌ای، قسمت‌های مجاور می‌توانند با یک زاویه به هم برسند.
  * در یک نقطه صاف، دو دسته کنترل هم‌محور هستند و فاصله مساوی از نقطه لنگر دارند.
  * در یک نقطه مستقیم، دو دسته کنترل هم‌محور هستند اما می‌توانند فاصله‌های متفاوتی از نقطه لنگر داشته باشند.
* جابجایی نقاط لنگر یا تنظیم دسته‌های آن‌ها، خطوط شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایش، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و رابط [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) را فراهم می‌کند.

* یک نمونه [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) از نمونه [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) می‌توانید از روش [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این روش‌ها استفاده کنید: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) برای شکل‌هایی با مسیر تک و [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) برای شکل‌هایی با مسیرهای متعدد.
* برای افزودن قسمت‌ها، می‌توانید از روش‌های موجود در [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از ویژگی‌های [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) و [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از ویژگی [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از قسمت‌های مسیر دریافت کنید.
* در نسخه‌های قدیمی که روش‌های تبدیل زیر را پشتیبانی می‌کنند، می‌توانید [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) را به [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) تبدیل کنید.
* از روش‌های [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) و [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (از کلاس [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) برای تبدیل بین [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) استفاده کنید.

## **عملیات ویرایش ساده**

از روش‌های زیر برای ویرایش یک مسیر هندسی استفاده کنید. برچسب‌های overload که یک شاخص می‌پذیرند، یک قسمت را در آن موقعیت صفر مبنا در آرایه قسمت‌های مسیر درج می‌کنند.

| عملیات | Method |
| --- | --- |
| اضافه یا درج یک خط مستقیم. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| اضافه یا درج یک منحنی Bézier مکعبی با دو نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| اضافه یا درج یک منحنی Bézier درجه دو با یک نقطه کنترل و یک نقطه انتهایی. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| اضافه یک قوس بیضوی با ابعاد و زوایای مشخص به درجه. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| بستن شکل جاری با اتصال نقطه انتهایی به نقطه شروع. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| تنظیم نقطه شروع یک شکل. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| حذف یک قسمت در شاخص صفر مبنا. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) وارد می‌کند و مسیر ویرایش‌شده را با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌نماید. مختصات‌ها محلی نسبت به شکل هستند: هر دو نقطه جدید در مرکز آن، ۱۰۰ نقطه از چپ و ۵۰ نقطه از بالا قرار دارند. شاخص‌های قسمت ۱ و ۴ آن‌ها را بر لبه‌های بالا و پایین قرار می‌دهند و آن لبه‌ها را به سمت درون کشیده می‌کند.

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

## **حذف نقاط از یک شکل**

این مثال با حذف قسمت ایندکس صفر مبنا ۲ با استفاده از [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) شکل هفتگی را تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) کانتور شکل را به‌روز می‌کند.

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

## **ایجاد یک شکل سفارشی**

این مثال یک ستاره پنج‌پر را با استفاده از [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) می‌سازد. شعاع‌های بیرونی و داخلی به ترتیب ۱۰۰ و ۵۰ نقطه، نوک‌ها و برآمدگی‌ها را تعریف می‌کنند؛ گام ۷۲ درجه نقاط پنج‌گانه را به‌صورت مساوی فاصله می‌گذارد. مسیر با استفاده از [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) بسته می‌شود و با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) به یک شکل مستطیلی اعمال می‌شود و کانتور آن را جایگزین می‌کند.

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

## **ایجاد یک شکل ترکیبی سفارشی**

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) بسته برای ثلث‌های بالایی و پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) یک شکل ترکیبی واحد با یک شکاف در ثلث میانی آن ایجاد می‌کند.

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
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **ایجاد یک شکل سفارشی با گوشه‌های منحنی**

این مثال قسمت‌های مستقیم را با [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) ترکیب می‌کند تا شکل با گوشه‌های داخلی منحنی ایجاد شود. هر اندازه گوشه عرض و ارتفاع قوس را به‌پویش نقطه‌ها تعیین می‌کند و سوئیپ ‑۹۰ درجه یک کمان چهارم‌بیضی ضد‌ساعت را می‌کشد. مسیر کامل با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

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

## **تشخیص اینکه آیا هندسه یک شکل بسته است**

کمک‌کننده زیر بررسی می‌کند که آیا هر مسیر هندسی غیر خالی با یک قسمت بسته پایان می‌یابد یا نه. این کمک‌کننده [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) را می‌خواند و فرمان نهایی [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) را با [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) مقایسه می‌کند. اگر مسیرهای غیر خالی وجود نداشته باشد، مقدار false باز می‌گرداند. این بررسی فقط فرمان نهایی هر مسیر را چک می‌کند؛ تمام زیرشکل‌های داخل مسیر بررسی نمی‌شود. مثال مقدار `True` را برای یک مستطیل چاپ می‌کند.

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

## **بازرسی دستورات مسیر هندسی**

فایل [contour.pptx](contour.pptx) را دانلود کنید و در پوشه کاری برنامه قرار دهید. اسلاید اول شامل شکلی با لبه بالایی مستقیم، یک منحنی Bézier مکعبی و لبه بسته مستقیم است. از [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) برای خواندن مسیرهای آن استفاده کنید. هر مسیر، قسمت‌های خود را به ترتیب رسم در [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) فهرست می‌کند. هر [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) هر قسمت، نحوه خواندن [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/) آن را تعیین می‌کند.

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

شکل در مختصات (200, 100) نقطه بر اسلاید قرار دارد. نقاط گزارش‌شده محلی نسبت به شکل هستند، به‌طوری که (0, 0) در گوشهٔ بالایی‑چپ آن است، محور X به سمت راست و محور Y به سمت پایین افزایشی دارد. قسمت بسته به نقطهٔ شروع باز می‌گردد بدون اینکه مختصات اضافی داشته باشد.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![شکل PowerPoint با یک لبه بالایی مستقیم، یک لبه منحنی از بالا-راست به پایین-چپ، و یک لبه چپ مستقیم](contour.png)

## **استخراج و بازرسی عناصر شکل**

از [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) برای بازرسی یک شکل موجود به‌عنوان عنصرهایی که شامل نقاط مسیر و انواع نقاط هستند، استفاده کنید. هر [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) بازگردانده‌شده را به [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) تبدیل کنید تا [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) و [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) آن را بخوانید. این بازنمایی برای تجزیه و تحلیل کانتور یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال یک ارائه را باز می‌کند، اولین شکل هندسی را مستقیماً در اسلاید اول پیدا می‌کند و قسمت‌های مسیر آن را چاپ می‌کند. برای دیدن خروجی‌های هر دو نوع، از ارائه‌ای استفاده کنید که شامل شکل با قسمت‌های مستقیم و منحنی باشد. این روش داخل گروه‌ها جستجو نمی‌کند.

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
        var pointType = types[i] & 0x07; // نوع بخش را نگه می‌دارد، به‌جز پرچم‌ها.
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
                i += 2; // هر دو نقطه کنترل و نقطه انتهایی را مصرف می‌کند.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

آرایه‌ها بر حسب ایندکس مطابقت دارند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` یک شکل را شروع می‌کند و نوع `1` خطی را از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک بخش Bézier مکعبی از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطه کنترل سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را به‌صورت گروهی مصرف می‌کند و نقطهٔ انتهایی را برای بستن بررسی می‌کند.

انواع نقطه همچنین شامل پرچم‌ها هستند. برای شناسایی نوع قسمت، با ماسک `0x07` عمل کنید و برای تشخیص زیرمسیر بسته، پرچم `0x80` را جداگانه بررسی کنید. برای مثال، `129` (`0x81`) به معنای نقطهٔ انتهایی خطی است که زیرمسیر را می‌بندد و `131` (`0x83`) به معنای نقطهٔ انتهایی Bézier است که بسته می‌شود. مقایسهٔ مقدار خام تنها با `1` یا `3` این موارد را از دست می‌دهد. پرچم‌های دیگر مانند خط‌چین (`0x10`) و نشانگر (`0x20`) نوع پایهٔ قسمت را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب نقطه (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایشی دارد. برای یک شکل بدون گروه، مختصات استخراج‌شده قبلاً موقعیت `[X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/)` و `[Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/)` آن را شامل می‌شود و عرض و ارتفاع فعلی آن را بازتاب می‌دهد. به‌عنوان مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازه `120 × 80` دارای مرزهای کانتور `(100, 200)`–`(220, 280)` است. موقعیت شکل را دوباره اضافه نکنید. برای به‌دست آوردن مختصات نسبی به چارچوب بدون چرخش، X و Y را کسر کنید.

نقاط استخراج‌شده اعمال چرخش `[Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)` یا واژهای افقی/عمودی را ندارند. برای بازتولید کانتور نمایش داده‌شده، این تبدیل‌ها را حول مرکز شکل اعمال کنید. برای اشکال گروهی، همچنین نگاشت مختصات گروه و تبدیل‌های آن را در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا ترجمه/مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده است.

**بازرسی در مقابل ویرایش.** آرایه‌های استخراج‌شده کانتور را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را به‌روزرسانی نمی‌کند. این رویکرد را زمانی انتخاب کنید که تحلیل یا کد رسم شما به آرایه‌های نقطه/نوع نیاز دارد. هنگامی که به دستورات هندسی در سیستم مختصات محلی شکل نیاز دارید یا می‌خواهید هندسهٔ آن را ویرایش کنید، از [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) یا [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) اعمال کنید.

## **تبدیل GeometryPath به GraphicsPath (System.Drawing.Drawing2D)**

مثال زیر به یک اسمبلی قدیمی Aspose.Slides for .NET که روش‌های [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) را پشتیبانی می‌کند (مثلاً نسخه ۲۵.۱۰) و یک محیط ویندوزی با `System.Drawing.Common` نیاز دارد. این روش‌های تبدیل در [نسخه ۲۵.۱۱](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) حذف شده‌اند.

این مثال یک کانتور مستطیلی را با متنی که به هندسه تبدیل شده ترکیب می‌کند. حالت پر کردن [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) برای غیرفعال کردن پر کردن تنظیم می‌شود. یک [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) متقن متن را ذخیره می‌کند که با [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) به یک مسیر هندسی پرشده تبدیل می‌گردد. اعمال هر دو مسیر با [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) یک شکل واحد شامل مستطیل و متن تولید می‌کند. برای تبدیل در جهت مخالف، از [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) استفاده کنید.

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

## **سوالات متداول**

**بعد از جایگزینی هندسه، پرکننده و خط مرزی چه تغییری می‌کنند؟**

سبک همچنان به شکل باقی می‌ماند؛ تنها کانتور تغییر می‌کند. پرکننده و خط مرزی به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه می‌توانم یک شکل سفارشی را به‌درستی همراه با هندسهٔ آن بچرخانم؟**

از ویژگی [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) شکل استفاده کنید؛ هندسه به‌همراه شکل می‌چرخد زیرا به سامانهٔ مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا نتیجه «قفل» شود؟**

بله. ناحیهٔ مورد نیاز را به‌صورت [اسلاید](/slides/fa/net/convert-powerpoint-to-png/) یا خود [شکل](/slides/fa/net/create-shape-thumbnails/) به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌سازد.