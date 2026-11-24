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
  - تم خارجی
  - THMX
  - رنگ تم
  - پالت اضافی
  - قلم تم
  - استایل تم
  - اثر تم
  - PowerPoint
  - OpenDocument
  - ارائه
  - .NET
  - C#
  - Aspose.Slides
description: "تم‌های ارائه اصلی را در Aspose.Slides برای .NET مدیریت کنید تا فایل‌های PowerPoint را با برندینگ یکسان ایجاد، سفارشی‌سازی و تبدیل کنید."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، استایل‌های پس‌زمینه، پرکننده‌ها، خطوط و اثرها را تعریف می‌کند. اشیائی که از تم آگاه هستند به این تعاریف مشترک ارجاع می‌دهند به‌جای اینکه هر ویژگی بصری را به‌عنوان مقدار ثابت ذخیره کنند، بنابراین تغییر تم می‌تواند بسیاری از اشیا را به‌طور همزمان به‌روزرسانی کند.

در Aspose.Slides، تم سطح ارائه از طریق ویژگی [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) در دسترس است. یک ارائه می‌تواند همچنین حاوی تغییرات تم در سطوح پایین‌تر باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/masterthememanager/overridetheme/) بر پایه مستر انتخاب‌شده ایجاد کند، یک چیدمان می‌تواند تم وارث خود را از طریق [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) بازنویسی کند و یک اسلاید منفرد می‌تواند همان کار را انجام دهد. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی چیدمان، و بازنویسی اسلاید.

![اجزای تم: رنگ‌ها، قلم‌ها، استایل‌های پس‌زمینه و اثرها](theme-constituents.png)

بخش‌های زیر رایج‌ترین مسیرهای کاری تم را نشان می‌دهند: بررسی یک تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک تم، به‌روزرسانی استایل‌های پس‌زمینه و اثر، و خواندن مقادیر مؤثر پس از حل ارث‌بری و تغییرات.

## **بررسی یک تم**

شیء [MasterTheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/) نمایانگر [ColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/fontscheme/) و [FormatScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/mastertheme/formatscheme/) تم است. بررسی این مجموعه‌ها قبل از تغییرشان به‌ویژه زمانی که یک ارائه از منبع خارجی آمده مفید است زیرا تعداد و محتوی ورودی‌های استایل می‌تواند متفاوت باشد.

مثال زیر خصوصیات اصلی تم را می‌خواند و گزارش می‌دهد که چند استایل پس‌زمینه، پرکننده، خط و اثر در تم ذخیره شده‌اند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و از مسیر کاری تم مؤثر که در ادامهٔ این مقاله نشان داده شده است استفاده کنید وقتی که بازنویسی‌های چیدمان یا اسلاید ممکن است وجود داشته باشند.

## **تغییر رنگ‌های تم**

پرکننده‌ها، خطوط و متن‌های آگاه به تم می‌توانند به یک رنگ منطقی از شمارشگر [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) ارجاع دهند. هنگامی که ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) تم را تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ تم ارجاع می‌دهند بر اساس مقدار جدید حل می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند توسط به‌روزرسانی رنگ تم تغییر نمی‌گیرند.

مثال انتها به انتهای زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، آن را دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

از آنجا که مستطیل به `Accent4` متصل باقی می‌ماند، رنگ قابل مشاهدهٔ آن پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی در `Accent4` دیگر بر آن پرکننده تأثیر نخواهند گذاشت.

### **استفاده از رنگ‌ها از پالت اضافی**

PowerPoint با اعمال تبدیل‌های رنگی، نسخه‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/net/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![رنگ‌های اصلی تم و رنگ‌های روشن و تیره تولید شده از پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم.  
**2** - نسخه‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، به پنج مورد از آن‌ها تبدیل‌های روشنایی اعمال می‌کند و نتیجه را ذخیره می‌کند:

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

این نسخه‌ها همچنان بر پایه رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارشگر [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/net/aspose.slides.theme/icolorscheme/) همان اسلات‌های تم را به عنوان `Dark1`، `Light1`، `Dark2` و `Light2` نشان می‌دهد. نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان اسلات‌های تم هستند؛ آن‌ها مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل مجموعه‌ای اصلی برای عناوین و یک مجموعهٔ فرعی برای متن اصلی است. ویژگی‌های [FontScheme.Major](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/major/) و [FontScheme.Minor](https://reference.aspose.com/slides/net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را نمایش می‌دهند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (قلم لاتین فرعی)
* `+mj-lt` - قلم عنوان لاتین (قلم لاتین اصلی)
* `+mn-ea` - قلم بدنه آسیای شرقی (قلم آسیای شرقی فرعی)
* `+mj-ea` - قلم عنوان آسیای شرقی (قلم آسیای شرقی اصلی)
* `+mn-cs` - قلم بدنه اسکریپت پیچیده (قلم اسکریپت پیچیده فرعی)
* `+mj-cs` - قلم عنوان اسکریپت پیچیده (قلم اسکریپت پیچیده اصلی)

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی پیروی می‌کند. متنی که نام قلم صریح دارد به‌جای شناسه تم، به‌صورت خودکار هنگام تغییر طرح قلم تم جابجا نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند همچنین نگاشت‌های قلم برای سیستم‌های نوشتاری فردی مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا داشته باشند. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به [قلم‌های تم خاص‌به‌اسکریپت](/slides/fa/net/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر دربارهٔ قلم‌های ارائه، به [قلم‌های پاورپوینت](/slides/fa/net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

### **حل ارجاع‌های قلم تم**

هنگام بررسی متن، [IFontData.FontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/fontname/) می‌تواند شامل یک ارجاع تم مانند `+mn-lt` به‌جای نام خانواده قلم باشد. با استفاده از [IFontData.GetFontName](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/getfontname/) همراه با [IThemeEffectiveData](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeeffectivedata/) مناسب، می‌توانید آن ارجاع را حل کنید. پیشوندهای `+mj` و `+mn` مجموعه‌های قلم اصلی و فرعی را انتخاب می‌کنند؛ پسوندهای `-lt`، `-ea` و `-cs` به ترتیب قلم‌های لاتین، آسیای شرقی و اسکریپت پیچیده را انتخاب می نمایند.

تم مؤثر را از طریق [IThemeable.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/ithemeable/createthemeeffective/) بر روی شیئی که تم آن به متن بررسی‌شده اعمال می‌شود به‌دست آورید. برای متن معمولی روی یک اسلاید، از `slide.CreateThemeEffective()` استفاده کنید تا زمینه شامل تم ارث‌بری آن اسلاید و بازنویسی‌های محلی باشد. هنگام بررسی یک چیدمان یا مستر، از تم مؤثر مخصوص خودش استفاده کنید. فرض نکنید که تم اولین مستر برای هر اسلاید اعمال می‌شود.

مثال زیر یک بخش متن ایجاد می‌کند که صریحاً به قلم لاتین فرعی ارجاع می‌دهد. با استفاده از [IOverrideTheme.InitFontSchemeFromInherited](https://reference.aspose.com/slides/net/aspose.slides.theme/ioverridetheme/initfontschemefrominherited/) یک طرح قلم اسلاید را مقداردهی اولیه می‌کند و خانواده‌های لاتین اصلی و فرعی را به ترتیب به `Arial` و `Calibri` تنظیم می‌کند، به‌طوری که نتیجه بدون فایل ورودی تکرارپذیر باشد.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var theme = slide.ThemeManager.OverrideTheme;
theme.InitFontSchemeFromInherited();
theme.FontScheme.Major.LatinFont = new FontData("Arial");
theme.FontScheme.Minor.LatinFont = new FontData("Calibri");

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Text using the minor theme font";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LatinFont = new FontData("+mn-lt");

var font = portion.PortionFormat.LatinFont;
var effectiveTheme = slide.CreateThemeEffective();
Console.WriteLine($"{font.FontName} -> {font.GetFontName(effectiveTheme)}");

var explicitFont = new FontData("Verdana");
Console.WriteLine($"{explicitFont.FontName} -> {explicitFont.GetFontName(effectiveTheme)}");
```

خروجی `+mn-lt -> Calibri` به‌همراه `Verdana -> Verdana` است. ارجاع ذخیره‌شده بدون تغییر می‌ماند، در حالی که یک نام خانوادگی صریح همان‌گونه برگردانده می‌شود. اگر بخش از `+mj-lt` استفاده می‌کرد، در این تم به `Arial` حل می‌شد.

حل کردن یک ارجاع تم، خانوادهٔ قلم مشخص‌شده توسط تم را شناسایی می‌کند. این کار در دسترس بودن قلم را بررسی نمی‌کند یا فایل قلم نهایی پس از جایگزینی یا پیش‌نیاز گلیف را تعیین نمی‌کند. برای این مراحل جداگانه به [دنباله انتخاب قلم](/slides/fa/net/font-selection-sequence/) و [جایگزینی قلم](/slides/fa/net/font-substitution/) مراجعه کنید.

## **کپی یا اعمال یک تم**

مسیرهای کاری زیر مشکلات مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به مستر**

از [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) زمانی که یک فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید تمام اسلایدهایی که به یک مستر خاص وابسته‌اند بازطراحی کنید، استفاده کنید. مستر را از مجموعهٔ [Presentation.Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) که پیاده‌سازی‌کنندهٔ [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/) است انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

این متد عملیات‌های زیر را انجام می‌دهد:
1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده ایجاد می‌کند.
2. تم خارجی را بر مستر جدید اعمال می‌کند.
3. مستر جدید را به تمام اسلایدهایی که پیش‌تر به مستر انتخاب‌شده وابسته بودند اختصاص می‌دهد.
4. [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/) تازه ایجاد شده را برمی‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند، ارائه را ذخیره می‌کند و نتیجه را دوباره باز می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];

var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");
Console.WriteLine($"Created master: {themedMaster.Name}");

presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

یک تم نامعتبر، خراب یا پشتیبانی‌نشده می‌تواند منجر به [PptxException](https://reference.aspose.com/slides/net/aspose.slides/pptxexception/) یا یکی از زیردستگاه‌های مربوط به فرمت آن شود. مسیرهای ارائه‌شده توسط کاربران را اعتبارسنجی کنید، خطاهای دسترسی به سیستم فایل را مدیریت کنید و تنها پس از اعمال موفقیت‌آمیز تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند بازتخصیص می‌شوند. اسلایدهای مرتبط با مسترهای دیگر مستر و تم موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و اثرهای آگاه به تم بر اساس تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و دیگر قالب‌بندی‌های صریحاً اختصاص‌یافته ممکن است بدون تغییر بمانند. بازنویسی‌های سطح چیدمان و سطح اسلاید نیز می‌توانند بر مقادیر ارث‌بری شده از مستر جدید مقدمات داشته باشند.

تم می‌تواند به قلم‌هایی که در محیط زمان اجرا موجود نیستند ارجاع دهد. برای رندرینگ و خروجی سازگار، قلم‌های مورد نیاز را نصب کنید، آن‌ها را از طریق [منابع قلم سفارشی](/slides/fa/net/custom-font/) فراهم کنید یا [جایگزینی قلم](/slides/fa/net/font-substitution/) را پیکربندی کنید.

این یک مسیر کاری مستقیم در سطح مستر است: متد مسیر فایل به یک فایل `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا چیدمان ندارد.

### **اعمال تم‌های خارجی متفاوت در ارائه چندمستری**

زمانی که مستر مرتبط از پیش شناخته نشده باشد، آن را از یک اسلاید نماینده از طریق [ISlide.LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/islide/layoutslide/) و [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/ilayoutslide/masterslide/) به‌دست آورید. پیش از اعمال هر تمی، مراجع مستر اصلی را ذخیره کنید زیرا هر فراخوانی مستر دیگری در ارائه ایجاد می‌کند.

مثال زیر از اسلایدهای دو بخش استفاده می‌کند تا مسترهایشان را پیدا کند و تم خارجی متفاوتی را به هر گروه اعمال می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");

        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

فراخوانی اول فقط بر اسلایدهایی که به `firstGroupMaster` وابسته بودند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `secondGroupMaster` وابسته بودند. اسلایدهای مربوط به هر مستر دیگر بازطراحی نمی‌شوند.

### **حفظ تم منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائه‌ای دیگر منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) به ارائه هدف کلون کنید، سپس اسلاید را با [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) و مستر کلون شده کلون کنید. این کار مستر، چیدمان‌های آن و تم مرتبط را به‌همراه می‌برد.

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

این مسیر کاری ترجیحی است زمانی که اسلاید منبع باید در مقصد همان‌طور که هست ظاهر شود. فقط کلون کردن محتوا بر روی مستر مقصدی نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و اثرهای وابسته به تم را تغییر دهد.

### **اعمال مقادیر تم به اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و چیدمان فعلی خود بماند، یک بازنویسی سطح اسلاید از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initfontschemefrom/)، و [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/initformatschemefrom/) سه مؤلفهٔ اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم استفاده‌شده توسط آن اسلاید را بدون تغییر تم ارث‌بری شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌بری‌شده، متد [OverrideTheme.Clear](https://reference.aspose.com/slides/net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی تم به چیدمان**

یک بازنویسی در سطح چیدمان بر اسلایدهایی که از آن چیدمان استفاده می‌کنند اعمال می‌شود، مگر اینکه یک اسلاید خاص بازنویسی خود را داشته باشد. می‌توان از همان متدهای مقداردهی اولیه از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/layoutslidethememanager/) چیدمان استفاده کرد:

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

زمانی که بسیاری از چیدمان‌ها و اسلایدها باید طرح پایهٔ یکسانی را به‌اشتراک بگذارند، از تم مستر یا سطح ارائه استفاده کنید؛ زمانی که یک خانوادهٔ چیدمان به سبک متفاوتی نیاز دارد، بازنویسی چیدمان؛ و تنها برای موارد استثنایی واقعی از بازنویسی اسلاید استفاده کنید. بازنویسی‌های بیش از حد در سطح اسلاید، پیش‌بینی تغییرات تم سراسری بعدی را دشوار می‌کند.

## **به‌روزرسانی استایل‌های پس‌زمینه تم**

پرکننده‌های پس‌زمینهٔ تم در [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینهٔ بیشتری را در رابط کاربری خود نشان دهد نسبت به تعداد تعریف‌های پرکننده‌ای که به‌صورت فیزیکی در این مجموعه ذخیره شده‌اند، زیرا رابط کاربری می‌تواند پرکننده‌های تم را با رنگ‌های تم و سایر ارجاع‌های استایل ترکیب کند.

![گالری استایل پس‌زمینه PowerPoint برای تم ارائه](presentation-design_8.png)

قبل از استفاده از یک استایل پس‌زمینه، مجموعهٔ ذخیره‌شده و مقدار فعلی [Background.StyleIndex](https://reference.aspose.com/slides/net/aspose.slides/background/styleindex/) را بررسی کنید. `StyleIndex` از `0` برای عدم وجود پرکنندهٔ تم استفاده می‌کند؛ مقادیر مثبت ارجاع‌های استایل پس‌زمینهٔ تم هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ .NET است که در آن `[0]` اولین آیتم ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه همان تعداد استایل‌های پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینهٔ موجود را گزارش می‌دهد، یک ارجاع پس‌زمینهٔ تم را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی تم ارجاع‌دهنده توسط مستر و هر بازنویسی پس‌زمینه در سطح چیدمان یا اسلاید بستگی دارد. اگر یک اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر تنها پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری، از [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`StyleIndex` را به‌عنوان ایندکس صفرپایهٔ یک مجموعه در نظر نگیرید. همچنین از کدنویسی ثابت شمارهٔ استایل از یک فایل و فرض اینکه در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعاریف استایل تم خاص ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به [پس‌زمینهٔ ارائه](/slides/fa/net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی اثرهای تم**

یک طرح فرمت تم شامل مجموعه‌های جداگانهٔ [FillStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/linestyles/)، و [EffectStyles](https://reference.aspose.com/slides/net/aspose.slides.theme/formatscheme/effectstyles/) است. تم‌های معمولی Office اغلب شامل سه ورودی اصلی استایل هستند که به‌صورت بصری با قالب‌بندی‌های ریز، متوسط و شدید مطابقت دارند، اما کد باید هر مجموعه را بررسی کند به‌جای این‌که یک شمارش ثابت فرض کند.

![اثرهای تم ریز، متوسط و شدید که بر همان شکل اعمال شده‌اند](presentation-design_10.png)

هنگامی که این مجموعه‌ها را در C# دسترسی می‌کنید، ایندکس مجموعه صفرپایه است: `[0]` اولین استایل ذخیره‌شده و `[2]` سومین استایل است. ایندکس‌های ارجاع استایل یک شکل یک مفهوم جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/) نشان داده می‌شود. تغییر یک استایل تم بر شکل‌هایی که به آن استایل تم ارجاع دارند تأثیر می‌گذارد؛ شکل‌هایی که دارای قالب‌بندی مستقیم هستند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های استایل لازم وجود دارند، اولین استایل خط را تغییر می‌دهد، سومین استایل پرکننده را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین استایل اثر فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که به این اسلات‌ها ارجاع دارند، اولین استایل خط تم به رنگ قرمز تبدیل می‌شود، سومین استایل پرکننده تم به سبز جنگلی پر می‌شود و سومین استایل اثر یک سایهٔ بیرونی با فاصلهٔ ۱۰ پوینت به‌دست می‌آورد. نتیجهٔ بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام اسلات استایل ارجاع دارد و آیا قالب‌بندی مستقیم بر تم اولویت دارد یا نه.

![استایل‌های اثر تم پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **انتخاب استایل‌های پرکننده و خط تم برای یک شکل**

یک شکل می‌تواند پرکننده و کادر خود را به‌صورت مستقل از طریق [FillStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/fillstyleindex/) و [LineStyleIndex](https://reference.aspose.com/slides/net/aspose.slides/ishapestyle/linestyleindex/) انتخاب کند. برای هر دو ویژگی، ایندکس `1` اولین ورودی در مجموعهٔ تم مربوطه (`FillStyles[0]` یا `LineStyles[0]`) را انتخاب می‌کند و ایندکس `2` دومین ورودی را انتخاب می‌کند.

مثال زیر دو استایل پرکننده (طلایی و آبی آسمانی) و دو استایل خط (آبی تیره با 6 پوینت و قرمز تیره با 12 پوینت) را در تم پیش‌فرض یک ارائهٔ جدید تنظیم می‌کند. اسلاید را در سه مرحله ذخیره می‌کند تا بتوانید نتایج را در PowerPoint مقایسه کنید.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var styles = presentation.MasterTheme.FormatScheme;

var goldFill = styles.FillStyles[0];
goldFill.FillType = FillType.Solid;
goldFill.SolidFillColor.Color = Color.Gold;
var blueFill = styles.FillStyles[1];
blueFill.FillType = FillType.Solid;
blueFill.SolidFillColor.Color = Color.SkyBlue;

var thinLine = styles.LineStyles[0];
thinLine.FillFormat.FillType = FillType.Solid;
thinLine.FillFormat.SolidFillColor.Color = Color.DarkBlue;
thinLine.Width = 6;
var thickLine = styles.LineStyles[1];
thickLine.FillFormat.FillType = FillType.Solid;
thickLine.FillFormat.SolidFillColor.Color = Color.DarkRed;
thickLine.Width = 12;

var shapes = presentation.Slides[0].Shapes;
var left = shapes.AddAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
var right = shapes.AddAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
left.ShapeStyle.FillStyleIndex = 1;
right.ShapeStyle.FillStyleIndex = 2;
left.ShapeStyle.LineStyleIndex = 1;
right.ShapeStyle.LineStyleIndex = 1;
presentation.Save("01-initial.pptx", SaveFormat.Pptx);

right.ShapeStyle.LineStyleIndex = 2;
presentation.Save("02-line-changed.pptx", SaveFormat.Pptx);

goldFill.SolidFillColor.Color = Color.SeaGreen;
presentation.Save("03-theme-changed.pptx", SaveFormat.Pptx);
```

| استایل‌های اولیه | تغییر خطوط سمت راست | ویرایش اولین پرکنندهٔ تم |
|:---:|:---:|:---:|
| ![مستطیل‌های طلایی و آبی آسمانی با خطوط نازک آبی تیرهٔ هم‌خوانی](theme-style-initial.png) | ![مستطیل آبی آسمانی اکنون دارای خط ضخیم قرمز تیره است](theme-style-line-changed.png) | ![مستطیل چپ اکنون سبز است و هر دو خط بدون تغییر باقی می‌مانند](theme-style-fill-changed.png) |

انتخاب یک استایل خط متفاوت فقط خط مستطیل سمت راست را تغییر می‌دهد. ویرایش اولین پرکنندهٔ تم تمام شکل‌هایی که از آن استفاده می‌کنند به‌روز می‌شود. در اینجا، فقط مستطیل سمت چپ سبز می‌شود.

در یک شکل موجود، رنگ پرکنندهٔ محلی، رنگ خط یا ضخامت خط می‌تواند آن بخش از استایل تم را بازنویسی کند. اگر تغییر ایندکس استایل اثر قابل مشاهده‌ای نداشته باشد، قالب‌بندی مستقیم شکل را بررسی کنید [قالب‌بندی مستقیم](/slides/fa/net/shape-formatting/).

## **تشخیص اینکه آیا یک پرکنندهٔ ثابت مؤثر از رنگ تم استفاده می‌کند**

یک پرکننده می‌تواند به‌صورت مستقیم روی یک شیء ذخیره شود یا از یک پاراگراف، چیدمان، مستر، استایل تم یا سطح دیگری از قالب‌بندی ارث‌بری شود. برای حل این سلسله‌مراتب به‌صورت دادهٔ غیرقابل تغییر [IFillFormatEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/) ، متد [IFillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/geteffective/) را فراخوانی کنید. ابتدا [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/filltype/) را بررسی کنید. فقط زمانی که مقدار آن `FillType.Solid` باشد باید خصوصیات پرکنندهٔ ثابت را بخوانید.

برای یک پرکنندهٔ ثابت، [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) مقدار نهایی RGB رندر شده را پس از ارث‌بری، جستجوی تم و اعمال تبدیل‌های رنگی برمی‌گرداند. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) اسلات منطقی [SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/schemecolor/) مرتبط را برمی‌گرداند، مانند `Text1` یا `Accent6`. مقدار `SchemeColor.NotDefined` به این معنی است که پرکنندهٔ ثابت مؤثر بر پایهٔ رنگ طرح نیست. در یک مسیر کاری که پرکننده‌ها یا رنگ‌های تم یا رنگ‌های RGB مستقیم هستند، این مقدار یک پرکنندهٔ RGB مستقیم را شناسایی می‌کند.

از مقدار محلی [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) به‌تنهایی برای دسته‌بندی یک پرکننده استفاده نکنید. به‌عنوان مثال، یک بخش متن ممکن است رنگ طرح محلی تعریف‌شده‌ای نداشته باشد، بنابراین مقدار محلی آن `NotDefined` است، در حالی که پرکنندهٔ مؤثر آن از یک رنگ تم ارث‌بری کرده و به `Text1` یا `Accent6` حل می‌شود. برعکس، `SolidFillSchemeColor` به شما می‌گوید کدام اسلات منطقی تم رنگ مؤثر را تولید کرده است، اما این‌که آن اسلات از شیء، پاراگراف، چیدمان، مستر یا سطح دیگری از سلسله‌مراتب قالب‌بندی آمده است را بیان نمی‌کند.

مثال زیر یک ارائه را بارگذاری می‌کند، پرکننده‌های شکل و پرکننده‌های بخش متنی را بررسی می‌کند، هر مقدار RGB نهایی و رنگ طرح مرتبط را چاپ می‌کند و پرکننده‌های ثابت را که تغییر رنگ تم را دنبال نمی‌کنند پرچم‌گذاری می‌کند:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

var slideCount = presentation.Slides.Count;
for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];

    var shapeCount = slide.Shapes.Count;
    for (var shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        var shape = slide.Shapes[shapeIndex];
        var shapeName = $"Slide {slideIndex + 1}, shape {shapeIndex + 1}";
        AuditFill(shapeName, shape.FillFormat);

        if (shape is IAutoShape autoShape)
        {
            var paragraphCount = autoShape.TextFrame.Paragraphs.Count;
            for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
            {
                var paragraph = autoShape.TextFrame.Paragraphs[paragraphIndex];

                var portionCount = paragraph.Portions.Count;
                for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
                {
                    var portion = paragraph.Portions[portionIndex];
                    var portionName = $"{shapeName}, paragraph {paragraphIndex + 1}, portion {portionIndex + 1}";
                    AuditFill(portionName, portion.PortionFormat.FillFormat);
                }
            }
        }
    }
}

static void AuditFill(string objectName, IFillFormat localFill)
{
    var effectiveFill = localFill.GetEffective();

    if (effectiveFill.FillType != FillType.Solid)
    {
        Console.WriteLine($"{objectName}: fill type = {effectiveFill.FillType}; not a solid fill.");
        return;
    }

    var rgb = effectiveFill.SolidFillColor;
    var effectiveSchemeColor = effectiveFill.SolidFillSchemeColor;
    var localSchemeColor = localFill.SolidFillColor.SchemeColor;

    Console.WriteLine($"{objectName}: RGB = #{rgb.R:X2}{rgb.G:X2}{rgb.B:X2}");
    Console.WriteLine($"{objectName}: local scheme = {localSchemeColor}, effective scheme = {effectiveSchemeColor}");

    if (effectiveSchemeColor == SchemeColor.NotDefined)
    {
        Console.WriteLine($"{objectName}: direct RGB or another non-scheme fill; audit as theme-independent.");
    }
    else
    {
        Console.WriteLine($"{objectName}: theme-dependent through {effectiveSchemeColor}.");
    }
}
```

شاخهٔ `NotDefined` فهرست بررسی پرکننده‌های ثابت را فراهم می‌کند که به تغییرات اسلات‌های رنگ تم واکنش نخواهند داد. هنگامیکه یک ارائه باید از پالت برند جدید پیروی کند، این اشیاء را بررسی کنید. مقدار RGB گزارش‌شده همچنان ظاهر فعلی را نشان می‌دهد، در حالی که مقدار طرح توضیح می‌دهد آیا آن ظاهر به تم متصل است یا نه.

اشیای فرمت مؤثر snapshots هستند. پس از تغییر تم ارائه، بازنویسی تم یا هر قالب‌بندی ارث‌بری‌شده، دوباره `GetEffective` را فراخوانی کنید و قبل از مقایسه یا گزارش رنگ‌ها، یک شیء جدید `IFillFormatEffectiveData` بخوانید.

## **خواندن مقادیر تم مؤثر**

اشیای تم خام به شما می‌گویند در یک سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) را فراخوانی کنید. برای یک پس‌زمینه، از [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) استفاده کنید و برای یک پرکننده، از [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکنندهٔ شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسات استفاده کنید. اگر فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/net/aspose.slides/presentation/mastertheme/) را بررسی کنید، ممکن است یک بازنویسی مستر، چیدمان، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهد، از دست بدهید.

## **سوالات متداول**

**آیا اعمال تم خارجی بر تمام اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) تنها اسلایدهایی را که به مستر انتخاب‌شده وابسته‌اند بازتعریف می‌کند. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند تم موجود خود را حفظ می‌کنند.

**آیا می‌توانم تمی را بر یک اسلاید واحد بدون تغییر مستر اعمال کنم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر فقط برای همان اسلاید محلی می‌ماند؛ سایر اسلایدها به تم‌های موجود خود ارث می‌برند.

**ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگام جابجایی یک اسلاید و حفظ ظاهر منبع آن، مستر منبع را به مقصد کلون کنید و اسلاید را با آن مستر با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) و [ISlideCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، چیدمان‌ها و تم را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر پس از ارث‌بری و بازنویسی‌ها را مشاهده کنم؟**

از [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) برای تم اسلاید یا چیدمان استفاده کنید و برای اشیای فرمت مانند [Background.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/background/geteffective/) و [FillFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/fillformat/geteffective/) از متدهای دادهٔ مؤثر مربوطه استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را بر می‌گردانند.