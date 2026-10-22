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
- نقاط ویرایشی
- افزودن نقطه
- حذف نقطه
- عملیات ویرایشی
- گوشهٔ منحنی
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "ایجاد و سفارشی‌سازی اشکال در ارائه‌های پاورپوینت با Aspose.Slides برای .NET: مسیرهای هندسی، گوشه‌های منحنی، اشکال ترکیبی."
---
## **مروری کلی**

این مقاله توضیح می‌دهد چگونه می‌توان اشکال ارائه در Aspose.Slides را با ویرایش هندسهٔ شکل از طریق نقاط ویرایشی و مسیرهای هندسی سفارشی کرد. این مقاله نشان می‌دهد چگونه با [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) کار کنید تا اشکال موجود را اصلاح کنید، عملیات پایهٔ ویرایش مسیر را انجام دهید، نقاط را اضافه یا حذف کنید، و هندسهٔ به‌روزرسانی‌شده را به یک شکل اعمال کنید.

همچنین نشان می‌دهد چگونه اشکال سفارشی و ترکیبی بسازید، اشکالی با گوشه‌های منحنی ایجاد کنید، تعیین کنید آیا هندسهٔ یک شکل بسته است یا نه، و از تبدیل قدیمی بین [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) برای سناریوهای سفارشی‌سازی هندسی اضافی استفاده کنید.

## **تغییر یک شکل با استفاده از نقاط ویرایشی**

در PowerPoint می‌توانید از **نقاط ویرایشی** برای اصلاح یک مربع استفاده کنید:

* جابه‌جا کردن یک گوشه به سمت داخل یا خارج.
* تنظیم انحنای یک نقطه.
* افزودن نقاط جدید.

ویرایش نقاط به شما امکان می‌دهد محدودهٔ یک شکل را تغییر دهید یا از یک شکل موجود به‌عنوان پایهٔ یک شکل جدید استفاده کنید.

## **نکات ویرایش شکل**

![overview_image](custom_shape_0.png)

هنگام ویرایش اشکال PowerPoint، این مفاهیم را در نظر بگیرید:

* یک شکل (یا مسیر آن) می‌تواند بسته یا باز باشد.
* مسیر یک شکل شامل نقاط لنگر است که توسط بخش‌ها به هم وصل می‌شوند.
* یک بخش می‌تواند مستقیم یا منحنی باشد. نقاط لنگر و دسته‌های کنترل شکل آن را تعیین می‌کنند.
* نقاط لنگر می‌توانند به صورت نقاط گوشه‌ای، نقاط مستقیم یا نقاط صاف باشند:
  * در یک نقطهٔ گوشه‌ای، بخش‌های مجاور می‌توانند در یک زاویه به هم بپیوندند.
  * در یک نقطهٔ صاف، دو دستهٔ کنترل هم‌راستا هستند و از نقطهٔ لنگر به‌صورت مساوی فاصله دارند.
  * در یک نقطهٔ مستقیم، دو دستهٔ کنترل هم‌راستا هستند اما می‌توانند فاصله‌های متفاوتی از نقطهٔ لنگر داشته باشند.
* جابه‌جایی نقاط لنگر یا تنظیم دسته‌هایشان، شکل کلی شکل را تغییر می‌دهد.

برای ویرایش اشکال PowerPoint از طریق نقاط ویرایشی، **Aspose.Slides** کلاس [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و اینترفیس [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) را فراهم می‌کند.

* یک نمونهٔ [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) مسیر هندسی شیء [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) را نشان می‌دهد.
* برای دریافت [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) از یک نمونهٔ [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) می‌توانید از متد [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید.
* برای تنظیم [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) برای یک شکل، می‌توانید از این متدها استفاده کنید: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) برای اشکال با مسیر واحد و [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) برای اشکال با مسیرهای متعدد.
* برای افزودن بخش‌ها، می‌توانید از متدهای موجود در [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) استفاده کنید.
* با استفاده از خصوصیات [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) و [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) می‌توانید ظاهر یک مسیر هندسی را تنظیم کنید.
* با استفاده از خصوصیت [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) می‌توانید مسیر هندسی یک [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) را به‌صورت آرایه‌ای از بخش‌های مسیر دریافت کنید.
* در نسخه‌های قدیمی که متدهای تبدیل زیر را پشتیبانی می‌کنند، می‌توانید [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) را به [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) تبدیل کنید.
* از متدهای [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) و [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (از کلاس [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) برای تبدیل بین [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) و [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) استفاده کنید.

## **عملیات سادهٔ ویرایشی**

از متدهای زیر برای ویرایش یک مسیر هندسی استفاده کنید. بارگذاری‌های پذیرندهٔ یک اندیس، بخش را در آن موقعیت صفر‑پایه در آرایهٔ بخش‌های مسیر درج می‌کند.

| عملیات | متد |
| --- | --- |
| افزودن یا درج یک خط مستقیم. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| افزودن یا درج یک منحنی بزیهٔ کاوبیک با دو نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| افزودن یا درج یک منحنی بزیهٔ درجهٔ دوم با یک نقطهٔ کنترل و یک نقطهٔ انتهایی. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| افزودن یک قوس بیضوی با ابعاد و زوایای مشخص به درجه. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| بستن شکل جاری با وصل نقطهٔ انتهایی به نقطهٔ شروع. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| تنظیم نقطهٔ شروع یک شکل. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| حذف یک بخش در اندیسی صفر‑پایه. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **افزودن نقاط سفارشی به یک شکل**

این مثال دو نقطه را به یک شکل مستطیلی با استفاده از [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) وارد می‌کند و مسیر ویرایش‌شده را با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌نماید. مختصات‌ها نسبت به شکل هستند: هر دو نقطهٔ جدید در مرکز آن، ۱۰۰ نقطه از سمت چپ و ۵۰ نقطه از سمت بالا قرار دارند. اندیس‌های بخش ۱ و ۴ آن‌ها را بر لبهٔ بالا و پایین قرار می‌دهد و این لبه‌ها را به سمت داخل می‌کشد.

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

این مثال محدودهٔ یک شکل قلبی را با حذف بخش در اندیس صفر‑پایهٔ ۲ با [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) تغییر می‌دهد. اعمال مسیر اصلاح‌شده با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) مرز شکل را به‌روزرسانی می‌کند.

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

این مثال یک ستارهٔ پنج‌ضلعی را با [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) می‌سازد. شعاع‌های خارجی و داخلی به ترتیب ۱۰۰ و ۵۰ نقطه، نوک‌ها و توهم‌ها را تعریف می‌کنند؛ گام ۷۲ درجه نوک‌های پنج‌تایی را به‌صورت مساوی پخش می‌کند. مسیر با [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) بسته می‌شود و با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) به یک شکل مستطیلی اعمال می‌گردد و مرز قبلی آن را جایگزین می‌کند.

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

این مثال دو شیء [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) بسته برای سوم‌های بالایی و پایینی یک شکل تعریف می‌کند. اعمال هر دو مسیر با [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) یک شکل ترکیبی واحد با یک فضای خالی در سوم میانی آن ایجاد می‌کند.

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

این مثال بخش‌های مستقیم را با [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) ترکیب می‌کند تا شکلی با گوشه‌های داخلی منحنی ایجاد شود. هر اندازهٔ گوشه عرض و ارتفاع قوس را بر حسب نقطه تنظیم می‌کند و طی -۹۰ درجه یک کمان بیضوی‌سرافاز ساعت‌گرد می‌کشد. مسیر کامل با [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) اعمال می‌شود و ارائه در قالب PPTX ذخیره می‌گردد.

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

## **تشخیص اینکه آیا هندسهٔ یک شکل بسته است**

کمکی زیر بررسی می‌کند که آیا هر مسیر هندسی غیر خالی با یک بخش بستن پایان می‌یابد یا خیر. این کمک [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) را می‌خواند و دستور نهایی بخش [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) را با [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/) مقایسه می‌کند. وقتی مسیرهای غیر خالی وجود نداشته باشد، مقدار false برمی‌گرداند. این بررسی تنها دستور نهایی هر مسیر را می‌سنجد؛ زیرشکل‌های داخلی مسیر را بررسی نمی‌کند. مثال برای یک مستطیل مقدار `True` را چاپ می‌کند.

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

## **استخراج و بررسی عناصر شکل**

از متد [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) برای بررسی یک شکل موجود به‌عنوان عناصری حاوی نقاط مسیر و انواع نقطه استفاده کنید. هر [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) بازگردانده‌شده را به [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) تبدیل کنید تا آرایه‌های [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) و [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/) را بخوانید. این نمایش برای تحلیل مرز یا انتقال هندسه به ابزارهای رسم سفارشی مفید است.

مثال یک ارائه را باز می‌کند، اولین شکل هندسی را مستقیماً در اولین اسلاید پیدا می‌کند و بخش‌های مسیر آن را چاپ می‌کند. از یک ارائه‌ای که شامل یک شکل با بخش‌های مستقیم و منحنی است استفاده کنید تا هر دو نوع خروجی را ببینید. این روش درون گروه‌ها جستجو نمی‌کند.

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
        var pointType = types[i] & 0x07; // نوع بخش را نگه‌دارید، پرچم‌ها را مستثنی کنید.
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
                i += 2; // هر دو نقطه کنترل و نقطه انتهایی را مصرف کنید.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

آرایه‌ها با اندیس متناظرند: `points[i]` یک نقطه است و `types[i]` نقش آن را توصیف می‌کند. نوع `0` شروع یک شکل را نشان می‌دهد و نوع `1` خطی از نقطهٔ قبلی به نقطهٔ فعلی می‌کشد. یک بخش بزیهٔ کاوبیک از نقطهٔ انتهایی قبلی شروع می‌شود و از سه ورودی متوالی نوع‑`3` استفاده می‌کند: دو نقطهٔ کنترل سپس نقطهٔ انتهایی جدید. حلقه این سه ورودی را همراه‑هم مصرف کرده و نقطهٔ انتهایی را برای بستن بررسی می‌کند.

انواع نقطه همچنین پرچم‌هایی دارند. با ماسک `0x07` می‌توانید نوع بخش را تشخیص دهید و با تست `0x80` به‌طور جداگانه یک زیرمسیر بسته را شناسایی کنید. برای مثال `129` (`0x81`) به معنای نقطهٔ انتهایی خط است که یک زیرمسیر را می‌بندد و `131` (`0x83`) نقطهٔ انتهایی بزیهٔ که یک زیرمسیر را می‌بندد. مقایسهٔ مقدار خام فقط با `1` یا `3` این موارد را نادیده می‌گیرد. پرچم‌های دیگر مانند خط تیره (`0x10`) و نشانگر (`0x20`) نوع پایهٔ بخش را تغییر نمی‌دهند.

**مختصات و تبدیل‌ها.** نقاط بر حسب نقطه (۱/۷۲ اینچ) اندازه‌گیری می‌شوند؛ X به سمت راست و Y به سمت پایین افزایش می‌یابد. برای یک شکل تکی، مختصات استخراج‌شده شامل موقعیت [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) و [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) آن و ابعاد فعلی است. به‌عنوان مثال، یک مستطیل بدون چرخش در `(100, 200)` با اندازهٔ `120 × 80` حدود مرزی `(100, 200)`–`(220, 280)` دارد. موقعیت شکل را دوباره اضافه نکنید؛ برای به‌دست آوردن مختصات نسبی به چارچوب بدون چرخش، X و Y را کم کنید.

نقاط استخراج‌شده اعمال [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) یا وارونگی افقی و عمودی شکل را ندارند. برای بازتولید مرز نمایش داده‌شده، این تبدیلات را حول مرکز شکل اعمال کنید. برای اشکال گروهی، تبدیل مختصات گروه و تبدیلات آن را نیز در نظر بگیرید؛ فرض نکنید که نقاط استخراج‌شده مختصات نهایی اسلاید هستند یا ترجمه/مقیاس را دو بار اعمال کنید اگر قبلاً در چارچوب فرزند منعکس شده‌اند.

**بازرسی در مقایسه با ویرایش.** آرایه‌های استخراج‌شده مرز را توصیف می‌کنند؛ تغییر آن‌ها شکل اصلی را بروز نمی‌دهد. این روش را زمانی انتخاب کنید که نیاز به آرایهٔ نقاط/انواع برای تجزیه و تحلیل یا ابزار رسم خود داشته باشید. برای دریافت دستورات هندسی در سیستم مختصات محلی شکل یا برای ویرایش هندسه، از [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) استفاده کنید. مسیرهای ویرایش‌شده را از طریق [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) یا [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) اعمال کنید.

## **تبدیل GeometryPath به GraphicsPath (System.Drawing.Drawing2D)**

مثال زیر نیاز به یک اسمبلی قدیمی Aspose.Slides for .NET دارد که متد [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) را پشتیبانی کند، مانند نسخهٔ ۲۵.۱۰، و یک محیط Windows با `System.Drawing.Common`. این متدها در [نسخهٔ ۲۵.۱۱](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/) حذف شدند.

این مثال مرز مستطیلی را با متن تبدیل‌شده به هندسه ترکیب می‌کند. [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) مرز را برای غیر فعال کردن پر شدن تنظیم می‌کند. یک [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) مرز متن را ذخیره می‌کند که توسط [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) به یک مسیر هندسی پرشده تبدیل می‌شود. اعمال هر دو مسیر با [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) یک شکل واحد حاوی مستطیل و متن ایجاد می‌کند. برای تبدیل در جهت مخالف، از [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) استفاده کنید.

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

## **سؤال‌های متداول**

**پس از جایگزینی هندسه، پرکننده و مرز چه می‌شود؟**

قالب با شکل باقی می‌ماند؛ فقط مرز تغییر می‌کند. پرکننده و مرز به‌صورت خودکار به هندسهٔ جدید اعمال می‌شوند.

**چگونه شکل سفارشی را به‌درستی همراه با هندسه‌اش بچرخانم؟**

از خصوصیت [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) شکل استفاده کنید؛ هندسه همراه با شکل می‌چرخد زیرا به سیستم مختصات خود شکل متصل است.

**آیا می‌توانم یک شکل سفارشی را به تصویر تبدیل کنم تا «قفل» شود؟**

بله. اسلاید موردنظر ([slide](/slides/fa/net/convert-powerpoint-to-png/)) یا خود شکل ([shape](/slides/fa/net/create-shape-thumbnails/)) را به فرمت رستر صادر کنید؛ این کار کار با هندسه‌های پیچیده را ساده‌تر می‌سازد.