---
title: قالب‌بندی اشکال PowerPoint در .NET
linktitle: قالب‌بندی شکل
type: docs
weight: 20
url: /fa/net/shape-formatting/
keywords:
- قالب‌بندی شکل
- قالب‌بندی خط
- اثر اسکچ
- خط شکل اسکچ
- قالب‌بندی سبک اتصال
- پرکردن گرادیان
- پرکردن الگو
- پرکردن تصویر
- پرکردن بافت
- پرکردن رنگ ثابت
- شفافیت شکل
- رندر سیاه‑سفید شکل
- رندر خاکستری شکل
- چرخاندن شکل
- افکت برش 3D
- افکت چرخش 3D
- بازنشانی قالب‌بندی
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه اشکال PowerPoint را در C# با استفاده از Aspose.Slides—پرکردن، خط و سبک‌های افکت را برای فایل‌های PPT و PPTX با دقت و کنترل کامل تنظیم کنید."
---
## **معرفی**

شکل‌ها را در PowerPoint با تنظیم خطوط مرزی، پرکردن‌ها و افکت‌ها قالب‌بندی کنید. Aspose.Slides for .NET به شما امکان می‌دهد این تنظیمات را به‌صورت برنامه‌نویسی کنترل کنید، از جمله شفافیت، چرخش و فرمت‌بندی 3D.

![گزینه‌های فرمت‌بندی شکل در PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for .NET رابط‌ها و ویژگی‌هایی را فراهم می‌کند که به شما اجازه می‌دهد شکل‌ها را با همان گزینه‌های موجود در PowerPoint قالب‌بندی کنید.

## **قالب‌بندی خطوط**

از [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) برای کنترل خطوط مرزی یک شکل استفاده کنید. این مثال یک مستطیل بدون پرکردن با یک خط مرزی آبی و نقطه‌خط تولید می‌کند. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) یک خط ترکیبی ضخیم-باریک را انتخاب می‌کند، در حالی که [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) عرض آن را به ۷ پوینت تنظیم می‌کند و [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) الگوی نقطه‌خط را انتخاب می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

نتیجه:

![خطوط قالب‌بندی‌شده در ارائه](formatted-lines.png)

### **تنظیم الگوهای نقطه‌خط سفارشی برای خط**

از [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) وقتی سبک‌های پیش‌تعریف‌شده نقطه‌خط طول‌ها و فواصل مورد نیاز شما را فراهم نمی‌کنند، برای مثال برای خطوط برند یا نمودارهای فنی، استفاده کنید. اختصاص یک الگو به‌صورت خودکار [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) را به [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) تنظیم می‌کند.

ورودی‌های آرایه به‌صورت متناوب بین طول‌های نقطه و فاصله جابجا می‌شوند و با یک نقطه شروع می‌شوند. هر مقدار چند برابر عرض خط است: `{ 4, 2 }` با عرض ۳ پوینت یک نقطه ۱۲‑پویینتی سپس یک فاصله ۶‑پویینتی تولید می‌کند. برای تعریف بخش‌های کامل نقطه‑و‑فاصله از جفت مقادیر متناهی و غیرمنفی استفاده کنید. در این مثال برای قابل مشاهده بودن تمام نقاط و فواصل از مقادیر مثبت استفاده شده است.

این مثال پنج خط آبی با همان طول و سرهای مسطح ایجاد می‌کند. سه خط اول الگوها را با عرض ۳ پوینت مقایسه می‌کنند. خط چهارم همان الگو را با دو برابر عرض تکرار می‌کند و هر دو طول نقطه و فاصله را دو برابر می‌کند. خط پنجم از الگوی سفارشی به خط یک‌دست تغییر می‌یابد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// خط آخر را به سبک یکدست برگردانید.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

برای بازگشت به یک سبک نقطه‌خط پیش‌تعریف‌شده به جای آن، [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) را به [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) اختصاص دهید. سبک انتخاب‌شده ظاهر خط را کنترل می‌کند.

نتیجه در PowerPoint، از بالا به پایین: **{4, 2}, 3 pt**؛ **{1, 2}, 3 pt**؛ **{6, 2, 1, 2}, 3 pt**؛ **{4, 2}, 6 pt**؛ و **Solid, 3 pt**.

![سه الگوی نقطه‌خط سفارشی، یک خط پهن‌تر با استفاده از الگوی اول، و یک خط یک‌دست در PowerPoint](custom-dash-patterns.png)


### **تنظیم شکل انتهای خطوط**

از [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) برای تنظیم انتهای یک خط باز استفاده کنید. شمارنده [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) سه سبک صریح انتها را ارائه می‌دهد:

- `Flat`: خط در نقطه انتهایی متوقف می‌شود.
- `Round`: یک سر نیم‌دایره‌ای بالاتر از نقطه انتهایی به اندازه نصف عرض خط گسترش می‌یابد.
- `Square`: یک سر مربع‌وار بالاتر از نقطه انتهایی به اندازه نصف عرض خط گسترش می‌یابد.

همچنین شمارنده شامل `NotDefined` است که به معنای عدم تعیین صریح سبک انتها می‌باشد.

سرها با پیکان‌ها متفاوت هستند؛ پیکان‌ها نمادهایی به انتهای خطوط اضافه می‌کنند و اتصالات گوشه‌های بین بخش‌های خط را کنترل می‌کنند. این مثال پیکان‌ها را از طریق [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) و [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) غیرفعال می‌کند تا تنها شکل انتهای سرها مقایسه شود.

مثال زیر سه خط افقی تقریباً یکسان با عرض ۲۰ پوینت ایجاد می‌کند. از بالا به پایین، سرهای مسطح، گرد و مربع استفاده می‌شوند. نقاط انتهایی هر سه خط دارای مختصات افقی یکسان هستند؛ سرهای گرد و مربع ۱۰ پوینت بالاتر از هر نقطه انتهایی گسترش می‌یابند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

نتیجه در PowerPoint، از بالا به پایین: **Flat**, **Round**, و **Square**.

![سرهای مسطح، گرد و مربع بر روی خطوط ضخیم یکسان در PowerPoint](line-caps.png)

## **اعمال افکت‌های اسکچ به خطوط شکل**

یک افکت اسکچ باعث می‌شود خط شکل به‌نظر دست‌کشیده بیاید. از [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) برای دسترسی به تنظیمات خط، [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) برای دسترسی به تنظیمات اسکچ و [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) برای انتخاب مقداری از شمارنده [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) استفاده کنید.

کد C# زیر نشان می‌دهد چطور یک اثر [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) اعمال کنید، مقدار اختصاص داده‌شده را بخوانید و با [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) افکت را حذف کنید:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

مقداری که توسط [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) برگردانده می‌شود، تنظیمی است که مستقیماً به شکل اختصاص یافته است. اگر فرمت‌بندی خط می‌تواند از یک تم، اسلاید اصلی یا اسلاید طرح‌بندی به ارث برسد، از [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) استفاده کنید، به [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) دسترسی پیدا کنید و [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) را بخوانید. مقدار مؤثر، فرمت‌بندی واقعی پس از حل ارث‌بری را نشان می‌دهد. این مثال نیاز به یک ارائه موجود دارد که حداقل یک شکل در اولین اسلاید داشته باشد و هر دو مقدار را چاپ می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **قالب‌بندی سبک‌های اتصال**

سه گزینه نوع اتصال وجود دارد:

* Round
* Miter
* Bevel

سبک اتصال تعیین می‌کند که دو بخش مرزی در یک گوشه چگونه به‌هم می‌پیوندند. برای گوشه‌های گرد از **Round**، برای گوشه‌های تیز از **Miter** و برای گوشه‌های صاف از **Bevel** استفاده کنید.

![سبک اتصال در ارائه](join-style-powerpoint.png)

این مثال سه مستطیل سیاه با خطوط مرزی آبی به عرض ۱۵ پوینت ایجاد می‌کند. برای مقایسه نحوه رسم گوشه‌ها، [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) را به ترتیب به مقادیر miter، bevel و round از شمارنده [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) تنظیم می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **محدود کردن اتصال میتر در گوشه‌های تیز**

از [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) همراه با [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) که به [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) تنظیم شده است، برای محدود کردن طول حداکثر گوشه تیز استفاده کنید.

محدودیت یک نسبت بین فاصله بین گوشه داخلی و خارجی اتصال به عرض خط است. برای مثال، مقدار `8` اجازه می‌دهد طول میتر تا هشت برابر عرض خط باشد؛ این مقدار براساس نقاط نیست. اگر گوشه از این حد فراتر رود، PowerPoint به‌جای آن از اتصال bevel استفاده می‌کند. حد بزرگ‌تر نقاط تیزتر را امکان‌پذیر می‌سازد. این تنظیم فقط بر اتصالات میتر تأثیر دارد و در صورتی که گوشه در محدوده هر دو حد باقی بماند، هیچ تغییری قابل مشاهده نیست.

این مثال دو مثلث بدون پرکردن یکسان با خطوط مرزی به عرض ۲۰ پوینت ایجاد می‌کند. مثلث سمت چپ از حد `2` و سمت راست از حد `8` استفاده می‌کند. هر مثلث عرض ۸۰ پوینت و ارتفاع ۱۶۰ پوینت دارد که نسبت طول میتر به عرض خط در گوشه بالایی تقریباً `4.12` است. در نتیجه PowerPoint گوشه چپ را bevel می‌کند و گوشه راست را به شکل نوک‌دار حفظ می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

نتیجه در PowerPoint: **Miter limit 2** در سمت چپ و **miter limit 8** در سمت راست.

![یک نوک bevel شده با محدودیت میتر ۲ و یک نوک تیز با محدودیت میتر ۸ در PowerPoint](miter-limits.png)

## **پرکردن گرادیان**

پرکردن گرادیان رنگ‌ها را در یک شکل ترکیب می‌کند. این مثال یک بیضاوی را با یک گرادیان خطی به زاویه ۴۵ درجه از قرمز به بنفش پر می‌کند با استفاده از [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). متد [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) نقاط رنگ را در ۰ و ۱ (آغاز و پایان گرادیان) قرار می‌دهد. پاک‌سازی نقاط توقف موجود تضمین می‌کند که فقط این دو رنگ استفاده شوند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

نتیجه:

![بیضاوی با پرکردن گرادیان](gradient-fill.png)

اگر یک گرادیان در تصویر خروجی متفاوت از ظاهر آن در PowerPoint باشد، به بخش [Choose a Gradient Rendering Style](/slides/fa/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) مراجعه کنید. می‌توانید سبک رندر را بدون تغییر در پرکردن گرادیان ذخیره‌شده در ارائه انتخاب کنید.

### **تنظیم زاویه گرادیان خطی**

از [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) برای کنترل جهت یک پرکردن [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود و ساعتگرد افزایش می‌یابد: `0` از چپ به راست، `90` از بالا به پایین، `180` از راست به چپ و `270` از پایین به بالا. زوایای کسری نیز پشتیبانی می‌شوند. زوایای متناهی خارج از محدوده `[0, 360)` به یک دور کامل نرمال می‌شوند؛ برای مثال، `-45` به `315` و `360` به `0` تبدیل می‌شود.

این مثال شش مستطیل با نقاط توقف رنگ قرمز، سبز و آبی یکسان در موقعیت‌های `0`، `0.5` و `1` ایجاد می‌کند. مقیاس‌گذاری غیرفعال است تا زاویه مستقل از نسبت ابعاد مستطیل‌ها مقایسه شود. زوایا، از چپ به راست، در ردیف اول `0`، `45` و `90` و در ردیف دوم `135`، `180` و `270` هستند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

نتیجه در PowerPoint:

![گرادیان‌های خطی با زوایای 0، 45 و 90 درجه در ردیف بالا، و 135، 180 و 270 درجه در ردیف پایین](linear-gradient-angles.png)

### **مقیاس‌گذاری یک گرادیان خطی با شکل**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) یک مقدار [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) می‌گیرد. به‌صراحت آن را به `False` تنظیم کنید تا زاویه هندسی گرادیان هنگام تغییر نسبت‌های شکل ثابت بماند، یا به `True` تا گرادیان با عرض و ارتفاع شکل مقیاس‌گذاری شود. با فعال بودن مقیاس‌گذاری، زاویه قابل مشاهده می‌تواند در شکل‌های غیر مربع با زاویه تعیین‌شده متفاوت باشد.

مثال زیر از زاویه `45` درجه و همان نقاط رنگی که در مقایسه زاویه استفاده شد، بهره می‌گیرد. ستون چپ `False` و ستون راست `True` تنظیم شده‌اند. هر ستون شامل یک مستطیل پهن در بالا و یک مستطیل بلند در پایین است. هر دو با ابعاد اولیه یکسان شروع می‌شوند؛ تغییر عرض و ارتفاع مستطیل دوم نشان می‌دهد پرکردن چگونه بدون تغییر تنظیمات گرادیان به تغییر اندازه واکنش می‌دهد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

نتیجه در PowerPoint، با مقیاس‌گذاری غیرفعال در سمت چپ و فعال در سمت راست:

![مستطیل‌های پهن و بلند با گرادیان 45 درجه، مقایسه LinearGradientScaled=False در چپ و True در راست](linear-gradient-scaling.png)

با غیرفعال بودن مقیاس‌گذاری، نوارهای رنگی قطره‌ای در هر دو مستطیل همان جهت را حفظ می‌کنند. با فعال بودن مقیاس‌گذاری، نوارها با نسبت‌های شکل کشیده می‌شوند. این به بازتولید گرادیان یک الگو هنگام تطبیق شکل با اندازهٔ متفاوت کمک می‌کند. در یک مربع، فعال‌سازی مقیاس‌گذاری ظاهر این گرادیان 45 درجه را تغییر نمی‌دهد.

هر دو تنظیم زاویه و مقیاس برای گرادیان‌های خطی اعمال می‌شوند. آنها بر پرکردن‌های [GradientShape.Radial یا GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) تأثیری ندارند.

### **ترکیب زاویه با جهت گرادیان**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) یک سبک گرادیان را از شمارنده [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) انتخاب می‌کند؛ این جایگزینی برای زاویه عددی نیست. برای یک گرادیان خطی، سبک‌های گوشه می‌توانند مساحتی که رنگ‌ها در آن توزیع می‌شوند را بدون تغییر [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) تغییر دهند. هنگام مقایسه زوایا یا مقیاس‌گذاری، جهت را ثابت بگذارید.

مثال زیر همان تنظیمات را به‌صورت ترتیب مخالف اعمال می‌کند. دو مستطیل همان ظاهر را دارند: اختصاص جهت قبل یا بعد از زاویه نتیجه را تغییر نمی‌دهد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **پرکردن الگو**

پرکردن الگو یک طراحی دو‌رنگ مانند نقاط، نوارها یا شطرنجی‌ها را اعمال می‌کند. این مثال از [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) برای انتخاب الگوی trellis استفاده می‌کند. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) پس‌زمینهٔ خاکستری روشن را فراهم می‌کند و [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) رنگ زرد الگو را تامین می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

نتیجه:

![مستطیل با پرکردن الگو](pattern-fill.png)

## **پرکردن تصویر**

پرکردن تصویر از یک تصویر داخل یک شکل استفاده می‌کند. این مثال به یک تصویر محلی نیاز دارد و از [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) برای بارگذاری آن در مجموعهٔ تصاویر ارائه استفاده می‌کند. تنظیم [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) به حالت کاشی‌ای، تصویر را در داخل مستطیل تکرار می‌کند. تصویر منبع استفاده‌شده در ادامه نشان داده شده است:

![تصویر لوتوس](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

نتیجه:

![شکل با پرکردن تصویر](picture-fill.png)

### **کاشی کردن تصویر به‌عنوان بافت**

اگر می‌خواهید یک تصویر کاشی‌شده را به‌عنوان بافت تنظیم کنید و رفتار کاشی را سفارشی کنید، می‌توانید از ویژگی‌های زیر رابط [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) و کلاس [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) استفاده کنید:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): حالت پرکردن تصویر را تنظیم می‌کند — یا `Tile` یا `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): تراز کاشی‌ها داخل شکل را مشخص می‌کند.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): تعیین می‌کند که کاشی به صورت افقی، عمودی یا هر دو وارونه شود.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): افست افقی کاشی (به پوینت) از مبداء شکل را تنظیم می‌کند.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): افست عمودی کاشی (به پوینت) از مبداء شکل را تنظیم می‌کند.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): مقیاس افقی کاشی را به‌صورت درصد تعریف می‌کند.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): مقیاس عمودی کاشی را به‌صورت درصد تعریف می‌کند.

این مثال به یک تصویر محلی نیاز دارد و [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) را طوری تنظیم می‌کند که آن را با ۵۰٪ اندازهٔ اصلی تکرار کند. افست‌های ‑32 پوینت کاشی‌ها را افقی و عمودی جابجا می‌کند؛ تراز پایین‑راست و وارون شدن در هر دو جهت تعیین می‌کند که بافت تکراری چگونه چینش شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

نتیجه:

![گزینه‌های کاشی](tile-options.png)

## **پرکردن رنگ ثابت**

یک پرکردن ثابت به شکل یک رنگ یکنواخت می‌دهد. این مثال [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) را به حالت پرکردن ثابت تنظیم می‌کند و رنگ زرد را از طریق [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) اختصاص می‌دهد، سپس مستطیل را در یک ارائه ذخیره می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

نتیجه:

![شکل با پرکردن رنگ ثابت](solid-color-fill.png)

## **استفاده از پس‌زمینه اسلاید به‌عنوان پرکردن شکل**

از [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) زمانی استفاده کنید که یک شکل باید با پس‌زمینه اسلاید مطابقت داشته باشد، مثلا در یک قالب ارائه. ابتدا [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) را به [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) تنظیم کنید تا هر پرکردن صریح حذف شود. با این ترکیب، شکل به‌جای سبک پرکردن خود، از پس‌زمینه اسلاید استفاده می‌کند. فعال کردن این پرچم به‌تنهایی پرکردن صریح موجود را حذف نمی‌کند.

این رفتار با [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/) متفاوت است: پرکردن پس‌زمینه اشیای پشت شکل را با ناحیهٔ متناظر پس‌زمینه اسلاید می‌پوشاند، در حالی که بدون پرکردن آن اشیاء قابل مشاهده می‌مانند. یک گرادیان همچنان با اسلاید هم‌راستا می‌ماند و درون هر شکل دوباره شروع نمی‌شود.

مثال زیر یک پس‌زمینهٔ اصلی که توسط اسلاید ارث‌بری می‌شود ایجاد می‌کند و یک نوار سرمه‌ای را پشت سه مستطیل قرار می‌دهد. مستطیل سمت چپ از پس‌زمینه استفاده می‌کند، مستطیل میانی بدون پرکردن است و مستطیل راست از پرکردن پس‌زمینه به یک پرکردن نارنجی صریح تغییر می‌یابد.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// ارث‌بری گرادیان از مستر.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// ابتدا این شی را اضافه کنید تا پشت مستطیل‌ها ظاهر شود.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// قبل از اعمال پرکردن صریح، پرکردن پس‌زمینه را غیرفعال کنید.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

نتیجه، از چپ به راست: **پرکردن پس‌زمینه**، **بدون پرکردن** و **پرکردن صریح**. نوار سرمه‌ای توسط مستطیل‌های چپ و راست پنهان می‌شود اما از طریق مستطیل میانی قابل مشاهده است.

![پرکردن پس‌زمینه، بدون پرکردن و پرکردن نارنجی صریح بر روی یک نوار سرمه‌ای](background-fill.png)

رفتار مشابه برای پس‌زمینه‌ای که به‌صورت مستقیم بر روی اسلاید تعریف شده یا از یک طرح‌بندی ارث‌بری می‌شود نیز صدق می‌کند. شکل از پس‌زمینهٔ حل‌شدهٔ اسلاید استفاده می‌کند؛ مثال هر دو پس‌زمینهٔ اسلاید و طرح‌بندی را تعریف نشده می‌گذارد تا مستر آن را فراهم کند.

## **تنظیم شفافیت**

برای یک پرکردن ثابت، مؤلفهٔ آلفای رنگ، اپاسیتی را کنترل می‌کند: ۰ به‌صورت کاملاً شفاف و ۲۵۵ کاملاً مات است. این مثال از مقدار آلفای ۱۲۸ برای یک مستطیل زرد استفاده می‌کند تا تقریباً ۵۰٪ شفاف باشد و مستطیل زیرین قابل مشاهده بماند. رنگ از طریق [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) اختصاص داده می‌شود.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

نتیجه:

![شکل شفاف](shape-transparency.png)

## **چرخاندن اشکال**

از [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) برای چرخاندن یک شکل در صفحهٔ اسلاید استفاده کنید. زاویه بر حسب درجه اندازه‌گیری می‌شود؛ این مثال یک مستطیل را ۵ درجه ساعتگرد می‌چرخاند و ارائه را ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

نتیجه:

![چرخش شکل](shape-rotation.png)

## **افزودن افکت‌های برش 3D**

از [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) برای افزودن عمق و لبه‌های برش‌دار به یک شکل استفاده کنید. این مثال یک بیضاوی سبز با خط مرزی نارنجی ایجاد می‌کند، [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) را به ۴ پوینت تنظیم می‌کند و یک برش بالایی دایره‌ای با عرض و ارتفاع ۶ پوینت از طریق [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) اعمال می‌کند. یک دوربین ارتروشیک جلو به صورت ارتوپرافیک و نوردهی سه‌نقطه‌ای برش را قابل مشاهده می‌کند.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

نتیجه:

![افکت برش 3D](3D-bevel-effect.png)

## **افزودن افکت‌های چرخش 3D**

نمایش 3D یک شکل توسط تنظیمات دوربین آن کنترل می‌شود. این مثال از [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) با زوایای عرض، طول و دورانی ۴۰، ۳۵ و ۲۰ درجه به ترتیب استفاده می‌کند. یک دوربین ایزومتریک از طریق [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) و نورپردازی متوازن از طریق [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) انتخاب می‌شود و سپس مستطیل قالب‌بندی‌شده ذخیره می‌گردد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

نتیجه:

![افکت چرخش 3D](3D-rotation-effect.png)

## **کنترل رندر سیاه‌سفید برای اشکال**

ویژگی [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) مشخص می‌کند یک شکل منفرد هنگام مشاهده یا پردازش ارائه در حالت سیاه‌سفید چگونه رندر شود. این ویژگی به‌تنهایی نمایش سیاه‌سفید را فعال نمی‌کند و فرمت‌بندی پر، خط یا سایر قالب‌بندی‌های شکل را در حالت رنگ عادی تغییر نمی‌دهد.

از مقداری از شمارنده [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) برای انتخاب رفتار دلخواه استفاده کنید. برای مثال، `Automatic` اجازه می‌دهد برنامه رندر انتخاب کند، `Gray` و `LightGray` از رنگ‌سفید استفاده می‌کنند، `BlackWhite` فقط سیاه و سفید، `Black` و `White` یک رنگ ثابت اعمال می‌کنند، `Color` رنگ عادی را حفظ می‌کند و `Hidden` شکل را در حالت سیاه‌سفید حذف می‌کند. `NotDefined` به معنای عدم تخصیص حالت در سطح شکل است.

این مثال یک مستطیل نارنجی ایجاد می‌کند و [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) را روی `Gray` تنظیم می‌کند. شکل ذخیره‌شده پرکردن نارنجی خود را برای نمایش رنگ عادی حفظ می‌کند و در برنامه‌هایی که حالت سیاه‌سفید را رعایت می‌کنند، درخواست رنگ خاکستری می‌کند:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

در حالت رنگی عادی، مستطیل پرکردن نارنجی خود را نگه می‌دارد. در یک جریان کاری نمایش سیاه‌سفید، به دلیل تنظیم حالت به `Gray` از رنگ خاکستری استفاده می‌کند. این امکان به شما اجازه می‌دهد اسلاید رنگی کامل را حفظ کنید در حالی که ظاهر متمایزی برای چاپ، پیش‌نمایش یا سایر جریان‌های کاری که تنظیمات نمایش سیاه‌سفید ارائه را رعایت می‌کنند، تعریف کنید.

## **بازنشانی قالب‌بندی**

از [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) برای بازگرداندن موقعیت، اندازه و قالب‌بندی جای‌گیرهای اسلاید از جای‌گیرهای متناظر طرح‌بندی استفاده کنید. این مثال به یک ارائه موجود با جای‌گیرهای مرتبط با طرح‌بندی نیاز دارد و قبل از ذخیره‌سازی تمام اسلایدها را بازنشانی می‌کند. اشکالی که جای‌گیر متناظر در طرح‌بندی ندارند بازنشانی نمی‌شوند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **سوالات متداول**

**آیا قالب‌بندی شکل بر اندازهٔ نهایی فایل ارائه تأثیر می‌گذارد؟**

رنگ‌ها، سبک‌های خط و تنظیمات افکت معمولاً داده کمی اضافه می‌کنند در مقایسه با تصاویر و رسانه‌های جاسازی‌شده. پرکردن‌های تصویری می‌توانند حجم فایل را افزایش دهند زیرا تصاویر آن‌ها در ارائه ذخیره می‌شوند.

**چگونه می‌توانم شکل‌هایی را در یک اسلاید که قالب‌بندی یکسان دارند شناسایی کنم تا بتوانم آن‌ها را گروه‌بندی کنم؟**

ویژگی‌های کلیدی قالب‌بندی هر شکل — پرکردن، خط و تنظیمات افکت — را مقایسه کنید. اگر تمام مقادیر متناظر هم‌خوانی داشته باشند، سبک آن‌ها را یکسان در نظر بگیرید و منطقی آن شکل‌ها را گروه‌بندی کنید، که مدیریت بعدی سبک‌ها را ساده می‌کند.

**آیا می‌توانم مجموعه‌ای از سبک‌های سفارشی شکل را در یک فایل جداگانه ذخیره کنم تا در ارائه‌های دیگر استفاده مجدد کنم؟**

بله. اشکال نمونه با سبک‌های دلخواه را در یک اسلاید قالب یا فایل قالب .POTX ذخیره کنید. هنگام ایجاد یک ارائه جدید، قالب را باز کنید، اشکال سبک‌دار مورد نیاز را کلون کنید و قالب‌بندی آن‌ها را در هر جایی که لازم است اعمال کنید.