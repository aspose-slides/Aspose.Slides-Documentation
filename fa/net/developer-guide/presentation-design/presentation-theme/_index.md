---
title: مدیریت تم‌های ارائه در .NET
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/net/presentation-theme/
keywords:
- تم PowerPoint
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- قلم تم
- سبک تم
- جلوه تم
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای .NET برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و جلوه‌ها را تعریف می‌کند. اشیای آگاه از تم به جای ذخیره هر ویژگی بصری به‌عنوان مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، بنابراین تغییر تم می‌تواند همزمان بسیاری از اشیا را به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق ویژگی [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) در دسترس است. یک ارائه می‌تواند بازنویسی‌های تم در سطوح پایین‌تر نیز داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/masterthememanager/overridetheme/) بازنویسی کند، یک چیدمان می‌تواند تم وارث خود را از طریق [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) بازنویسی کند و یک اسلاید منفرد می‌تواند همین کار را انجام دهد. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره وراثت حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی چیدمان و بازنویسی اسلاید.

![اجزاء تم: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و جلوه‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری با تم را نشان می‌دهند: بازرسی تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و جلوه، و خواندن مقادیر مؤثر پس از حل وراثت و بازنویسی‌ها.

## **بازرسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/) تم را از طریق [ColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/fontscheme/) و [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/formatscheme/) ارائه می‌دهد. بازرسی این مجموعه‌ها پیش از تغییر آن‌ها به‌ویژه زمانی که یک ارائه از منبع خارجی می‌آید مفید است، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر خصوصیات اصلی تم را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و جلوه در تم ذخیره شده‌اند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و وقتی احتمال بازنویسی چیدمان یا اسلاید وجود دارد، از جریان کاری تم مؤثر که در ادامه این مقاله نشان داده شده استفاده کنید.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از مجموعه‌Enumeration [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی مربوطه در [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) تم را تغییر می‌دهید، همه اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند، نسبت به مقدار جدید حل می‌شوند. اشیایی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییری نمی‌پذیرند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

از آنجا که مستطیل به `Accent4` متصل می‌ماند، رنگ قابل مشاهده‌اش پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم بر روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکننده تأثیر نمی‌گذارد.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیلات رنگ، نسخه‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیلات را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/fa/net/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - انواع روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، روی پنج مورد از آن‌ها تبدیلات روشنایی اعمال می‌کند و نتیجه را ذخیره می‌کند:

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

این گونه‌ها همچنان مبتنی بر رنگ تم هستند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` دوباره محاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به سلول‌های `IColorScheme`**

Enumeration [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) همان سلول‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` نشان می‌دهد. نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان سلول‌های تم هستند؛ مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل یک مجموعه قلم اصلی برای عناوین و یک مجموعه قلم فرعی برای متن بدنه است. ویژگی‌های [FontScheme.Major](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/major/) و [FontScheme.Minor](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را نشان می‌دهند.

شناساگرهای قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (قلم لاتین فرعی)
* `+mj-lt` - قلم عنوان لاتین (قلم لاتین اصلی)
* `+mn-ea` - قلم بدنه آسیای شرقی (قلم آسیای شرقی فرعی)
* `+mj-ea` - قلم عنوان آسیای شرقی (قلم آسیای شرقی اصلی)

مثال زیر یک عنوان ایجاد می‌کند که از قلم لاتین اصلی تم استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی تم استفاده می‌کند. سپس قلم‌های تم را تغییر می‌دهد و نتیجه را ذخیره می‌کند:

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که دارای نام قلم صریح به‌جای شناساگر تم باشد، هنگام تغییر طرح قلم تم به‌صورت خودکار سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری جداگانه مانند سیریلیک، عربی، ژاپنی، گرجی و ثاناز نیز باشند. برای بازرسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [قلم‌های تم مخصوص اسکریپت](/slides/fa/net/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [قلم‌های PowerPoint](/slides/fa/net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک تم**

دو جریان کاری رایج وجود دارد و هر یک مشکل متفاوتی را حل می‌کند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه‌ای دیگر منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) به ارائه هدف کلون کنید، سپس اسلاید را با استفاده از [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) و مستر کلون شده کلون کنید. این کار مستر، چیدمان‌های آن و تم مرتبط را همراه خود می‌برد.

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

این جریان کاری زمانی که اسلاید منبع باید در مقصد همان ظاهر را داشته باشد، ترجیح داده می‌شود. به‌سادگی محتوای یک مستر نامرتبط در مقصد را کلون کردن می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و جلوه‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به یک اسلاید موجود**

اگر اسلاید هدف باید روی مستر و چیدمان فعلی خود باقی بماند، یک بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initfontschemefrom/) و [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initformatschemefrom/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم وراثت‌شده توسط اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وراثتی، متد [OverrideTheme.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال یک بازنویسی تم به یک چیدمان**

یک بازنویسی سطح چیدمان برای اسلایدهایی که از آن چیدمان استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خود را داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/layoutslidethememanager/) چیدمان استفاده شوند:

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

از تم سطح مستر یا ارائه استفاده کنید زمانی که بسیاری از چیدمان‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، از بازنویسی چیدمان استفاده کنید زمانی که یک خانواده چیدمان به سبک متفاوتی نیاز دارد، و فقط برای استثناهای واقعی از بازنویسی اسلاید استفاده کنید. بازنویسی‌های سطح اسلاید بیش از حد، تغییرات جهانی تم را در آینده پیش‌بینی‌پذیرتر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینه تم در [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را در رابط کاربری خود نشان دهد نسبت به تعداد تعریف‌های پرکننده‌ای که به‌صورت فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط کاربری می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر مراجع سبک ترکیب کند.

![گالری سبک پس‌زمینه PowerPoint برای تم ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و [Background.StyleIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/background/styleindex/) فعلی را بازرسی کنید. `StyleIndex` برای عدم وجود پرکننده تم از `0` استفاده می‌کند؛ مقادیر مثبت مرجع سبک پس‌زمینه تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعه .NET است که در آن `[0]` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید هر ارائه‌ای همان تعداد سبک پرکننده پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینه موجود را گزارش می‌دهد، یک مرجع پس‌زمینه تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجه قابل مشاهده بسته به ورودی تمی که توسط مستر مرجع‌گیری می‌شود و هر بازنویسی پس‌زمینه در سطح چیدمان یا اسلاید متفاوت است. اگر اسلاید پس‌زمینه خود را داشته باشد، تغییر فقط پس‌زمینه مستر ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینه نهایی پس از اعمال وراثت، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`StyleIndex` را به‌عنوان ایندکس‌گذاری صفر‑محور مجموعه در نظر نگیرید. همچنین از کدگذاری ثابت یک شماره سبک از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعاریف سبک تم خاص ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [پس‌زمینه ارائه](/slides/fa/net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی جلوه‌های تم**

یک طرح فرمت تم حاوی مجموعه‌های جداگانه‌ای برای [FillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/linestyles/) و [EffectStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/effectstyles/) است. تم‌های اداری معمولاً سه ورودی اصلی سبک دارند که به‌صورت بصری به فرمت‌های ملایم، متوسط و شدید مطابقت می‌کنند، اما کد باید هر مجموعه‌ای را بازرسی کند نه این‌که تعداد ثابت را فرض کند.

![جلوه‌های تم ملایم، متوسط و شدید بر روی یک شکل](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در C# می‌خوانید، ایندکس مجموعه صفر‑محور است: `[0]` اولین سبک ذخیره‌شده و `[2]` سومین است. ایندکس‌های مرجع‑سبک یک شکل یک مفهوم جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر اشکالی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک موردنیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک جلوه فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این سلول‌ها ارجاع می‌دهند، اولین سبک خط تم به قرمز تبدیل می‌شود، سومین سبک پرکننده تم به سبز جنگلی ثابت تغییر می‌کند و سومین سبک جلوه یک سایهٔ خارجی با فاصلهٔ ۱۰ پوینت اضافه می‌کند. نتیجهٔ بصری دقیق هنوز به این که هر شکل به کدام سلول سبک ارجاع می‌دهد و آیا قالب‌بندی مستقیم تم را بازنویسی می‌کند بستگی دارد.

![سبک‌های جلوه تم پس از تغییر تنظیمات خط، پر و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر تم**

اشیای تم خام به شما می‌گویند که در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل وراثت و بازنویسی‌های محلی در واقع چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) را صدا بزنید. برای یک پس‌زمینه، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) استفاده کنید و برای یک پرکننده، از [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکننده شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) را بررسی کنید، ممکن است یک بازنویسی مستر، چیدمان، اسلاید یا شکل را که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **پرسش‌های متداول**

**آیا می‌توانم تم را فقط به یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و تم بازنویسی‌شده آن را مقداردهی اولیه کنید. این تغییر به‌صورت محلی به همان اسلاید می‌ماند؛ اسلایدهای دیگر همچنان تم‌های موجود خود را وراثت می‌گیرند.

**به‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟**

زمانی که اسلایدی را منتقل می‌کنید و می‌خواهید ظاهر منبع آن حفظ شود، مستر منبع را به مقصد کلون کنید و اسلاید را با آن مستر با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) و [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، چیدمان‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از وراثت و بازنویسی‌ها مشاهده کنم؟**

برای یک اسلاید یا تم چیدمان از متد [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) استفاده کنید و برای اشیای فرمت مانند [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) و [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) از متدهای داده‑مؤثر مربوطه استفاده کنید. این APIها مقادیر حل‑شده پس از اعمال وراثت و بازنویسی را برمی‌گردانند.