---
title: مدیریت اتصال‌دهنده‌ها در ارائه‌های .NET
linktitle: اتصال‌دهنده
type: docs
weight: 10
url: /fa/net/connector/
keywords:
- اتصال‌دهنده
- نوع اتصال‌دهنده
- نقطه اتصال‌دهنده
- خط اتصال‌دهنده
- زاویه اتصال‌دهنده
- محل اتصال
- نقطه تنظیم
- اتصال شکل‌ها
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه با Aspose.Slides برای .NET، اتصال‌دهنده‌های مستقیم، خمیده و منحنی PowerPoint را اضافه، وصل، مسیردهی مجدد، تنظیم و بررسی کنید."
---
## **نمای کلی**

یک اتصال‌دهنده خطی است که می‌تواند به دو شکل متصل بماند حتی زمانی که یکی از شکل‌ها حرکت می‌کند. انتهای آن به مکان‌های اتصال (connection sites) که در PowerPoint با نقاط سبز نشان داده می‌شوند، متصل می‌شود. برخی از اتصال‌دهنده‌های خمیده و منحنی نیز نقاط تنظیم (adjustment points) دارند که با نقاط نارنجی نشان داده می‌شوند و موقعیت بخش‌های مختلف اتصال‌دهنده را کنترل می‌کنند.

Aspose.Slides اتصال‌دهنده‌ها را از طریق رابط [IConnector](https://reference.aspose.com/slides/fa/net/aspose.slides/iconnector/) ارائه می‌کند. می‌توانید آن‌ها را ایجاد کنید، انتهاهایشان را به شکل‌ها وصل کنید، مکان‌های اتصال را انتخاب کنید، مسیر آن‌ها را تغییر دهید و هندسهٔ اتصال‌دهنده‌هایی که نقاط تنظیم دارند را اصلاح کنید.

## **انواع اتصال‌دهنده**

در شمارش [ShapeType](https://reference.aspose.com/slides/fa/net/aspose.slides/shapetype/) پیش‌فرض‌های اتصال‌دهندهٔ مستقیم، خمیده و منحنی موجود است. جدول زیر هندسهٔ اتصال‌دهنده‌های موجود و تعداد نقاط تنظیم تعریف‌شده برای هر پیش‌فرض را نشان می‌دهد.

| اتصال‌دهنده | تصویر | تعداد نقاط تنظیم |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

تعداد و معنای نقاط تنظیم جزئی از پیش‌فرض انتخاب شدهٔ اتصال‌دهنده هستند. فرض نکنید که دو نوع اتصال‌دهندهٔ متفاوت، همان چیدمان مجموعه را ارائه می‌دهند.

## **اتصال دو شکل**

از متد [IShapeCollection.AddConnector](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addconnector/) برای افزودن یک اتصال‌دهنده استفاده کنید و ویژگی‌های [StartShapeConnectedTo](https://reference.aspose.com/slides/fa/net/aspose.slides/connector/startshapeconnectedto/) و [EndShapeConnectedTo](https://reference.aspose.com/slides/fa/net/aspose.slides/connector/endshapeconnectedto/) را تعیین کنید. پس از اتصال هر دو انتها، متد [IConnector.Reroute](https://reference.aspose.com/slides/fa/net/aspose.slides/iconnector/reroute/) مسیر کوتاه‌تری بین شکل‌ها انتخاب می‌کند.

مثال زیر یک بیضی و یک مستطیل را با یک اتصال‌دهندهٔ خمیده متصل می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;
connector.Reroute();

presentation.Save("connected-shapes.pptx", SaveFormat.Pptx);
```

{{% alert color="warning" title="Warning" %}}
فراخوانی `Reroute` می‌تواند مقادیر [StartShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/connector/startshapeconnectionsiteindex/) و [EndShapeConnectionSiteIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/connector/endshapeconnectionsiteindex/) را تغییر دهد. پس از تغییر مسیر، در صورت نیاز به ثابت ماندن این سایت‌ها، آن‌ها را به‌صورت explícit تعیین کنید.
{{% /alert %}}

## **انتخاب مکان اتصال**

هر شکلی که قابلیت اتصال دارد، تعداد سایت‌های خود را از طریق [ConnectionSiteCount](https://reference.aspose.com/slides/fa/net/aspose.slides/shape/connectionsitecount/) گزارش می‌کند. قبل از اختصاص یک شاخص سایت صفر‌محور به انتهای اتصال‌دهنده، این مقدار را اعتبارسنجی کنید؛ تعداد سایت‌ها بسته به هندسهٔ شکل متفاوت است.

این مثال اتصال‌دهنده را به یک سایت خاص در بیضی متصل می‌کند در صورتی که آن سایت موجود باشد:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
var rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

connector.StartShapeConnectedTo = ellipse;
connector.EndShapeConnectedTo = rectangle;

uint preferredSiteIndex = 2;
if (preferredSiteIndex < ellipse.ConnectionSiteCount)
{
    connector.StartShapeConnectionSiteIndex = preferredSiteIndex;
}
else
{
    Console.WriteLine($"The ellipse has only {ellipse.ConnectionSiteCount} connection sites.");
}

presentation.Save("specific-connection-site.pptx", SaveFormat.Pptx);
```

## **تنظیم یک نقطهٔ اتصال‌دهنده**

اتصال‌دهنده‌های دارای نقاط تنظیم، این نقاط را از طریق [IGeometryShape.Adjustments](https://reference.aspose.com/slides/fa/net/aspose.slides/igeometryshape/adjustments/) در دسترس می‌گذارند. پیش از تغییر [RawValue](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/rawvalue/) هر [IAdjustValue](https://reference.aspose.com/slides/fa/net/aspose.slides/iadjustvalue/)، نوع آن را از طریق ویژگی [Type](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/type/) بررسی کنید. قوانین کلی شناسایی تنظیمات پیش‌فرض در بخش [Shape Manipulation](/slides/fa/net/shape-manipulations/) توضیح داده شده است.

تعداد، ترتیب، معنا و بازهٔ مقادیر معتبر تنظیمات اتصال‌دهنده به پیش‌فرض آن وابسته است. ویژگی `Type` فقط خواندنی است، در حالی که مقدار تنظیم قابل نوشتن است. ویژگی فقط خواندنی [Name](https://reference.aspose.com/slides/fa/net/aspose.slides/adjustvalue/name/) برای تشخیص بیشتر زمانی که یک اتصال‌دهنده بیش از یک تنظیم از نوع معنایی یکسان دارد، مفید است.

### **مسیر دور یک مانع**

در طرح زیر، یک اتصال‌دهندهٔ `BentConnector5` بین دو شکل از طریق یک شکل سوم عبور می‌کند:

![connector-obstruction](connector-obstruction.png)

این کد اتصال‌دهندهٔ مسدود شده را می‌سازد:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

presentation.Save("connector-obstruction.pptx", SaveFormat.Pptx);
```

جابه‌جا کردن خم عمودی مسیر را تغییر می‌دهد تا اتصال‌دهنده از مانع دور بگیرد:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

به‌جای این‌که فرض کنید شاخص مجموعهٔ `1` همیشه نمایانگر خم عمودی است، این مثال به دنبال `ConnectorBendPositionY` می‌گردد و فقط در صورت وجود نوع معنایی مورد انتظار آن را تغییر می‌دهد:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
connector.StartShapeConnectedTo = sourceShape;
connector.EndShapeConnectedTo = targetShape;
connector.StartShapeConnectionSiteIndex = 2;

IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
        break;
    }
}

if (verticalBend is null)
{
    Console.WriteLine("The connector does not expose a vertical bend adjustment.");
}
else
{
    verticalBend.RawValue = 60000;
    presentation.Save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
}
```

یک `BentConnector5` دو تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` دارد. اگر نوع مورد نیاز بیش از یک بار وجود داشته باشد، قبل از انتخاب یکی، ویژگی `Name` و هندسهٔ شناخته‌شدهٔ آن پیش‌فرض را بررسی کنید. اگر یک تنظیم مقدار `ShapeAdjustmentType.Custom` برگرداند، معنای آن و بازهٔ مقادیر را به‌عنوان تنظیمات خاص پیش‌فرض در نظر بگیرید و تا زمان آگاهی از قرارداد آن، آن را تغییر ندهید.

## **رابطهٔ مقادیر تنظیم با هندسهٔ اتصال‌دهنده**

برای اتصال‌دهنده‌های خمیده، مقادیر تنظیم می‌توانند برای تخمین موقعیت بخش‌های جداگانه استفاده شوند. این محاسبات به پیش‌فرض اتصال‌دهنده وابسته‌اند:

- `BentConnector4` به‌طور معمول یک تنظیم `ConnectorBendPositionX` و یک تنظیم `ConnectorBendPositionY` را ارائه می‌دهد.
- برای این موقعیت‌های خم، عبارت `RawValue / 100000f` کسر عرض یا ارتفاع چارچوب اتصال‌دهنده را که در مثال‌های زیر استفاده می‌شود، تولید می‌کند.
- چارچوب اتصال‌دهنده ممکن است چرخش یا وارونگی داشته باشد، بنابراین مختصات چارچوب باید قبل از مقایسه با مختصات اسلاید تبدیل شوند.

مثال‌های زیر ابتدا با استفاده از `Type` تنظیمات را شناسایی می‌کنند و به‌جای استفاده از شاخص‌های مجموعه به‌عنوان شناسه‌های قابل حمل رفتار می‌کنند.

#### **اتصال‌دهنده بدون چرخش**

طرح اولیه شامل دو شکل متنی است که توسط یک `BentConnector4` به هم متصل هستند:

![connector-shape-complex](connector-shape-complex.png)

این مثال اتصال‌دهنده را بررسی کرده و تنظیمات خم افقی و عمودی آن را دریافت می‌کند:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
targetShape.TextFrame.Text = "To";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.Crimson;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    Console.WriteLine($"{adjustment.Name}: {adjustment.Type}, raw value = {adjustment.RawValue}");
}
```

برای تغییر هر دو خم، هر نوع مورد انتظار را پیدا کنید و مقدارها را فقط پس از یافتن هر دو تغییر دهید:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;
    presentation.Save("connector-adjusted.pptx", SaveFormat.Pptx);
}
```

نتیجه یک اتصال‌دهنده است که بخش‌های افقی و عمودی آن جابه‌جا شده‌اند:

![connector-adjusted-1](connector-adjusted-1.png)

پس از شناسایی انواع معنایی، مقادیر می‌توانند به مختصات چارچوب اتصال‌دهنده تبدیل شوند. این مثال یک مستطیل نازک بر روی بخش عمودی که توسط دو تنظیم خم کنترل می‌شود می‌کشد:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 3;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 2;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    var x = connector.X + connector.Width * horizontalBend.RawValue / 100000f;
    var y = connector.Y;
    var height = connector.Height * verticalBend.RawValue / 100000f;
    slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 1, height);
    presentation.Save("connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

شکل راهنما بخش محاسبه‌شده را نشان می‌دهد:

![connector-adjusted-2](connector-adjusted-2.png)

#### **اتصال‌دهنده چرخیده یا وارونه**

زمانی که همان هندسهٔ اتصال‌دهنده به‌صورت عمودی جهت‌دار می‌شود، مقادیر [Frame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/frame/)، [FlipH](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeframe/fliph/)، و [FlipV](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeframe/flipv/) بر تبدیل مختصات چارچوب به مختصات اسلاید تأثیر می‌گذارند.

این مثال اتصال‌دهندهٔ عمودی را می‌سازد و تنظیم می‌کند:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
sourceShape.TextFrame.Text = "From";
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
targetShape.TextFrame.Text = "To 1";
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

connector.LineFormat.EndArrowheadStyle = LineArrowheadStyle.Triangle;
connector.LineFormat.FillFormat.FillType = FillType.Solid;
connector.LineFormat.FillFormat.SolidFillColor.Color = Color.MediumAquamarine;
connector.LineFormat.Width = 3;
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        adjustment.RawValue += 20000;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        adjustment.RawValue += 200000;
    }
}

presentation.Save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
```

اتصال‌دهندهٔ تنظیم‌شده به‌صورت عمودی بین شکل‌ها ظاهر می‌شود:

![connector-adjusted-3](connector-adjusted-3.png)

برای زاویهٔ چرخش دلخواه `alpha`، نقطهٔ چارچوب اتصال‌دهنده `(x, y)` را حول مرکز چارچوب `(x0, y0)` می‌چرخانیم:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

کد زیر چرخش 90 درجه مورد استفاده در این مثال را مدیریت کرده و یک راهنمای قرمز بر روی بخش متناظر از اتصال‌دهنده می‌کشد:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var sourceShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
var connector = slide.Shapes.AddConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.StartShapeConnectedTo = sourceShape;
connector.StartShapeConnectionSiteIndex = 2;
connector.EndShapeConnectedTo = targetShape;
connector.EndShapeConnectionSiteIndex = 3;

IAdjustValue? horizontalBend = null;
IAdjustValue? verticalBend = null;
for (var adjustmentIndex = 0; adjustmentIndex < connector.Adjustments.Count; adjustmentIndex++)
{
    var adjustment = connector.Adjustments[adjustmentIndex];
    if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionX)
    {
        horizontalBend = adjustment;
    }
    else if (adjustment.Type == ShapeAdjustmentType.ConnectorBendPositionY)
    {
        verticalBend = adjustment;
    }
}

if (horizontalBend is null || verticalBend is null)
{
    Console.WriteLine("The connector does not expose the expected bend adjustments.");
}
else
{
    horizontalBend.RawValue += 20000;
    verticalBend.RawValue += 200000;

    var x = connector.X;
    var y = connector.Y;
    if (connector.Frame.FlipH == NullableBool.True)
    {
        x += connector.Width;
    }
    if (connector.Frame.FlipV == NullableBool.True)
    {
        y += connector.Height;
    }

    x += connector.Width * horizontalBend.RawValue / 100000f;
    var rotatedX = connector.Frame.CenterX - y + connector.Frame.CenterY;
    var rotatedY = x - connector.Frame.CenterX + connector.Frame.CenterY;
    var segmentWidth = connector.Height * verticalBend.RawValue / 100000f;
    var guide = slide.Shapes.AddAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
    guide.LineFormat.FillFormat.FillType = FillType.Solid;
    guide.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

    presentation.Save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
}
```

راهنمای قرمز پس از تبدیل مختصات، بخش محاسبه‌شده را نشان می‌دهد:

![connector-adjusted-4](connector-adjusted-4.png)

این فرمول‌ها تنها پیش‌فرض‌های استفاده‌شده در مثال‌ها را توصیف می‌کنند، نه یک مدل عمومی برای تمام انواع اتصال‌دهنده. قبل از اعمال محاسبه مشابه به پیش‌فرض دیگر، انواع تنظیمات، جهت‌گیری چارچوب و بازهٔ مقادیر را اعتبارسنجی کنید.

## **یافتن زاویهٔ جهت اتصال‌دهنده**

جهت یک اتصال‌دهندهٔ مستقیم می‌تواند از عرض و ارتفاع آن محاسبه شود، به‌علاوه‌ی چرخش افقی و عمودی اعمال‌شده. مثال زیر زاویهٔ ساعتگرد را نسبت به محور افقی مثبت در مختصات اسلاید گزارش می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var connector = slide.Shapes.AddConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

var flipH = connector.Frame.FlipH == NullableBool.True;
var flipV = connector.Frame.FlipV == NullableBool.True;
var deltaX = connector.Width * (flipH ? -1 : 1);
var deltaY = connector.Height * (flipV ? -1 : 1);
var angle = Math.Atan2(deltaY, deltaX) * 180.0 / Math.PI;

if (angle < 0)
{
    angle += 360;
}

Console.WriteLine($"Connector direction: {angle:F2} degrees");
```

## **پرسش‌های متداول**

**چگونه می‌توانم بفهمم یک اتصال‌دهنده می‌تواند به شکل متصل شود؟**

تعداد `ConnectionSiteCount` شکل را بررسی کنید. مقدار مثبت یعنی شکل دارای سایت‌های اتصال است. قبل از اختصاص شاخص سایت به هر انتهای اتصال‌دهنده، آن را اعتبارسنجی کنید.

**آیا می‌توانم یک تنظیم اتصال‌دهنده را با شاخص مجموعه شناسایی کنم؟**

یک شاخص تنها برای پیش‌فرض شناخته‌شدهٔ اتصال‌دهنده و چیدمان مجموعه معنا دارد. قبل از تغییر مقدار، `IAdjustValue.Type` را بررسی کنید و در صورتی که همان نوع معنایی چندبار ظاهر شود، از `IAdjustValue.Name` برای اطلاعات اضافی استفاده کنید.

**وقتی شکلی که به آن متصل است حذف شود چه اتفاقی می‌افتد؟**

پایان مربوط به اتصال‌دهنده جدا می‌شود. اتصال‌دهنده در اسلاید باقی می‌ماند و می‌تواند حذف شود، به‌عنوان خط آزاد قرار گیرد یا به شکل دیگری متصل شود.

**آیا پیوندهای اتصال‌دهنده هنگام کپی کردن اسلاید حفظ می‌شوند؟**

معمولاً پیوندها هنگام کپی کردن شکل‌های متصل همراه با اسلاید حفظ می‌شوند. اگر یک اتصال‌دهنده بدون یکی از شکل‌های هدفش کپی شود، باید انتهای تحت‌تأثیر دوباره متصل گردد.