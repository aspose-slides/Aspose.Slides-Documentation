---
title: مدیریت قالب‌های ارائه در .NET
linktitle: قالب ارائه
type: docs
weight: 10
url: /fa/net/presentation-theme/
keywords:
- قالب PowerPoint
- قالب ارائه
- قالب اسلاید
- تنظیم قالب
- تغییر قالب
- مدیریت قالب
- رنگ قالب
- پالت اضافی
- قلم قالب
- سبک قالب
- افکت قالب
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قالب‌های اصلی ارائه در Aspose.Slides برای .NET جهت ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندسازی یکسان."
---
## **مقدمه**

یک قالب ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از قالب به جای ذخیره هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر قالب می‌تواند بسیاری از اشیاء را به‌صورت یکباره به‌روزرسانی کند.

در Aspose.Slides، قالب سطح ارائه از طریق ویژگی [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) در دسترس است. یک ارائه همچنین می‌تواند بازنویسی‌های قالب را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند قالب ارائه را از طریق [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/masterthememanager/overridetheme/) بازنویسی کند، یک لایه می‌تواند قالب ارث‌بری شده خود را از طریق [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) بازنویسی کند، و یک اسلاید منفرد نیز می‌تواند همین کار را انجام دهد. به‌صورت عملی، قالب مؤثر برای یک اسلاید از طریق این زنجیرهٔ ارث‌بری حل می‌شود: قالب ارائه، بازنویسی مستر، بازنویسی لایه، و بازنویسی اسلاید.

![اجزاء قالب: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین گردش‌های کار قالب را نشان می‌دهند: بررسی یک قالب، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک قالب، به‌روزرسانی سبک‌های پس‌زمینه و افکت، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بررسی یک قالب**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/) مجموعهٔ [ColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/fontscheme/) و [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/formatscheme/) قالب را نشان می‌دهد. بررسی این مجموعه‌ها قبل از تغییر آنها بویژه زمانی که یک ارائه از منبع خارجی می‌آید، مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی قالب را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در قالب ذخیره شده‌اند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

اگر فایلی چند مستر داشته باشد، فرض نکنید که هر اسلاید همان قالب مؤثر را دارد. مستر مرتبط با اسلاید را بررسی کنید و از گردش کار قالب مؤثر که بعداً در این مقاله نشان داده می‌شود، استفاده کنید زمانی که بازنویسی‌های لایه یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های قالب**

پرکننده‌ها، خطوط و متن‌های آگاه از قالب می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) قالب تغییر می‌کند، تمام اشیائی که همچنان به آن رنگ قالب ارجاع می‌دهند، در برابر مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ قالب تغییر نمی‌کنند.

مثال انتها به انتهای زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` قالب را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

چون مستطیل همچنان به `Accent4` لینک شده است، رنگ قابل مشاهدهٔ آن پس از تغییر قالب به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم بر روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نخواهند گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، گونه‌های روشن‌تر و تاریک‌تری از یک رنگ قالب تولید می‌کند. Aspose.Slides این تبدیلات را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/fa/net/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی قالب و رنگ‌های روشن‌تر و تاریک‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی قالب.

**2** - گونه‌های روشن‌تر و تاریک‌تر تولید شده از رنگ‌های اصلی قالب.

مثال زیر شش مستطیل بر پایهٔ `Accent4` ایجاد می‌کند، به پنج‌تا از آنها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

این گونه‌ها بر پایهٔ رنگ قالب باقی می‌مانند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) همان اسلات‌های قالب را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` نشان می‌دهد. نقشه‌برداری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های قالب هستند؛ مقادیری که به‌صورت پویا از یک فرم به فرم دیگر تبدیل می‌شوند، نیستند.

## **تغییر قلم‌های قالب**

یک طرح‌الگوی قلم قالب شامل یک مجموعهٔ قلم اصلی برای سرعنوان‌ها و یک مجموعهٔ قلم فرعی برای متن بدنه است. ویژگی‌های [FontScheme.Major](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/major/) و [FontScheme.Minor](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را نشان می‌دهند.

شناسه‌های قلم قالب سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - Body Font Latin (قلم بدنه لاتین)
* `+mj-lt` - Heading Font Latin (قلم سرعنوان لاتین)
* `+mn-ea` - Body Font East Asian (قلم بدنه آسیای شرقی)
* `+mj-ea` - Heading Font East Asian (قلم سرعنوان آسیای شرقی)

مثال زیر یک سرعنوان ایجاد می‌کند که از قلم لاتین اصلی قالب استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی قالب استفاده می‌کند. سپس قلم‌های قالب را تغییر داده و نتیجه را ذخیره می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

سرعنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی پیروی می‌کند. متنی که نام قلم صریحی به جای شناسهٔ قالب دارد، به‌صورت خودکار هنگام تغییر طرح‌الگوی قلم قالب جابه‌جا نمی‌شود.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک قالب**

دو گردش کار رایج وجود دارد و هر کدام مشکل متفاوتی را حل می‌کنند.

### **حفظ قالب منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) به ارائهٔ هدف کلون کنید، سپس اسلاید را با استفاده از [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) و مستر کلون‌شده کلون کنید. این کار مستر، لایه‌های آن و قالب مرتبط را همراه می‌برد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

این گردش کار زمانی ترجیح داده می‌شود که اسلاید منبع باید همان شکل را در مقصد داشته باشد. صرفاً کلون کردن محتوا بر روی مستر مقصد که ارتباطی ندارد، می‌تواند رنگ‌های مبتنی بر قالب، قلم‌ها، پس‌زمینه‌ها و افکت‌ها را تغییر دهد.

### **اعمال مقادیر قالب به یک اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لایهٔ جاری خود بماند، یک بازنویسی سطح اسلایدی از قالب منبع مقداردهی اولیه کنید. روش‌های [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initfontschemefrom/) و [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initformatschemefrom/) سه مؤلفهٔ اصلی قالب را به بازنویسی کپی می‌کنند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

این کار قالب مورد استفادهٔ آن اسلاید را تغییر می‌دهد بدون اینکه قالب ارث‌بری شده توسط اسلایدهای دیگر تغییر کند. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری شده، [OverrideTheme.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی قالب به یک لایه**

یک بازنویسی سطح لایه بر روی اسلایدهایی که از آن لایه استفاده می‌کنند اعمال می‌شود، مگر اینکه اسلاید خاصی بازنویسی خودش را داشته باشد. همان روش‌های مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/layoutslidethememanager/) لایه استفاده شوند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

از یک قالب سطح مستر یا ارائه استفاده کنید وقتی که بسیاری از لایه‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، یک بازنویسی لایه وقتی که یک خانوادهٔ لایه نیاز به استایل متفاوت دارد، و یک بازنویسی اسلاید تنها برای استثناهای واقعی. بازنویسی‌های بیش از حد در سطح اسلاید باعث می‌شود تغییرات جهانی قالب پیش‌بینی‌شده سخت‌تر شوند.

## **به‌روزرسانی سبک‌های پس‌زمینهٔ قالب**

پرکننده‌های پس‌زمینهٔ قالب در [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینهٔ بیشتری در رابط کاربری خود نشان دهد نسبت به تعداد تعریف‌های پرکننده‌ای که فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط کاربری می‌تواند پرکننده‌های قالب را با رنگ‌های قالب و سایر ارجاع‌های سبک ترکیب کند.

![گالری سبک‌های پس‌زمینهٔ PowerPoint برای یک قالب ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعهٔ ذخیره‌شده و مقدار فعلی [Background.StyleIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/background/styleindex/) را بررسی کنید. `StyleIndex` از `0` برای عدم وجود پرکنندهٔ قالب استفاده می‌کند؛ مقادیر مثبت ارجاع‌های سبک پس‌زمینهٔ قالب هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ .NET است، جایی که `[0]` به اولین مورد ذخیره‌شده اشاره دارد. فرض نکنید هر ارائه‌ای همان تعداد سبک پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکنندهٔ پس‌زمینهٔ موجود را گزارش می‌دهد، یک ارجاع پس‌زمینهٔ قالبی به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

نتیجهٔ قابل مشاهده به ورودی قالبی که مستر به آن ارجاع می‌دهد و هر بازنویسی پس‌زمینه‌ای در سطح لایه یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خاص خود را داشته باشد، تغییر تنها پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. هنگام نیاز به دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`StyleIndex` را به‌عنوان یک ایندکس صفر‑پایهٔ مجموعه در نظر نگیرید. همچنین از کدگذاری یک شمارهٔ سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعریف‌های سبک قالب مخصوص هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [Presentation Background](/slides/fa/net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های قالب**

یک طرح‌الگوی قالب شامل مجموعه‌های جداگانهٔ [FillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/linestyles/) و [EffectStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/effectstyles/) است. قالب‌های معمولی Office اغلب شامل سه ورودی سبک اصلی هستند که به‌صورت بصری به ترتیب نمایان‌کنندهٔ قالب‌بندی‌های ملایم، متوسط و شدید هستند، اما کد باید هر مجموعه را بررسی کند به‌جای اینکه تعداد ثابت فرض کند.

![افکت‌های ملایم، متوسط و شدید قالب که بر روی همان شکل اعمال شده‌اند](presentation-design_10.png)

زمانی که این مجموعه‌ها را در C# دسترسی می‌کنید، ایندکس مجموعه صفر‑پایه است: `[0]` اولین سبک ذخیره‌شده و `[2]` سومین است. ایندکس‌های ارجاع سبک یک شکل مفهوم جداگانه‌ای است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک قالب بر اشکالی که به آن استایل ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که فرمت‌دهی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک مورد نیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

برای اشکالی که به این اسلات‌ها ارجاع می‌دهند، اولین سبک خط قالب به قرمز تبدیل می‌شود، سومین سبک پرکننده قالب به سبز جنگلی ثابت می‌شود و سومین سبک افکت یک سایهٔ خارجی با فاصلهٔ 10 پوینت اضافه می‌کند. نتیجهٔ بصری دقیق همچنان به این بستگی دارد که هر شکل به چه اسلات‌های سبک ارجاع می‌دهد و آیا فرمت‌دهی مستقیم بر قالب ارجاع دارد یا خیر.

![سبک‌های افکت قالب پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر قالب**

اشیای خام قالب به شما می‌گویند که در سطح خاصی چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) را فراخوانی کنید. برای پس‌زمینه، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) استفاده کنید و برای پرکننده، از [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) بهره ببرید.

مثال زیر قالب مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

از داده‌های مؤثر برای تشخیص، اعتبارسنجی و مقایسه‌های رندر استفاده کنید. اگر فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) را بررسی کنید، ممکن است یک بازنویسی در مستر، لایه، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **پرسش‌های متداول**

**آیا می‌توانم یک قالب را فقط برای یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و بازنویسی قالب آن را مقداردهی اولیه کنید. تغییر فقط به‌صورت محلی بر همان اسلاید باقی می‌ماند؛ سایر اسلایدها قالب‌های موجود خود را به ارث می‌برند.

**ایمن‌ترین روش برای انتقال یک قالب از یک ارائه به ارائهٔ دیگر چیست؟**

هنگام جابجایی یک اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و سپس اسلاید را با آن مستر با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) و [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، لایه‌ها و قالب را همراه نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) برای یک اسلاید یا قالب لایه و روش‌های داده‑مؤثر مربوطه برای اشیای فرمت مانند [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) و [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.