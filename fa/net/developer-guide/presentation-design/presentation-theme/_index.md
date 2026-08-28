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
- پالت افزایشی
- قلم تم
- سبک تم
- افکت تم
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای .NET برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک تم ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکردن‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاهِ تم به‌جای ذخیره کردن هر ویژگی بصری به‌صورت مقدار ثابت، به این تعاریف مشترک ارجاع می‌دهند، به‌طوری که تغییر تم می‌تواند بسیاری از اشیا را به‌طور همزمان به‌روز کند.

در Aspose.Slides، تم سطح ارائه از طریق ویژگی [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) در دسترس است. یک ارائه می‌تواند نیز بازنویسی‌های تم در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند تم ارائه را از طریق [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/masterthememanager/overridetheme/) بازنویسی کند، یک لایه می‌تواند تم ارث‌برده‌شده خود را از طریق [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) بازنویسی کند، و یک اسلاید منفرد نیز می‌تواند همین کار را انجام دهد. در عمل، تم مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: تم ارائه، بازنویسی مستر، بازنویسی لایه، و بازنویسی اسلاید.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری تم را نشان می‌دهند: بررسی تم، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال تم، به‌روزرسانی سبک‌های پس‌زمینه و افکت‌ها، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بررسی یک تم**

شی [MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/) مجموعه‌های [ColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/fontscheme/)، و [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/formatscheme/) تم را در اختیار می‌گذارد. بررسی این مجموعه‌ها پیش از تغییر آن‌ها زمانی مفید است که ارائه‌ای از منبع خارجی می‌آید، زیرا تعداد و محتوی ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر ویژگی‌های اصلی تم را می‌خواند و تعداد سبک‌های پس‌زمینه، پرکردن، خط و افکت ذخیره‌شده در تم را گزارش می‌کند:

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

اگر فایلی از چند مستر استفاده کند، فرض نکنید که هر اسلاید همان تم مؤثر را دارد. مستر مرتبط با اسلاید را بررسی کنید و در صورتی که بازنویسی‌های لایه یا اسلاید ممکن است وجود داشته باشد، از جریان کاری تم مؤثر که در ادامه این مقاله آورده شده است استفاده کنید.

## **تغییر رنگ‌های تم**

پرکردن‌ها، خطوط و متن‌های آگاه از تم می‌توانند به یک رنگ منطقی از شمارش [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) ارجاع دهند. وقتی ورودی متناظر در [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) تم را تغییر می‌دهید، تمام اشیایی که هنوز به آن رنگ تم ارجاع می‌دهند، با مقدار جدید حل می‌شوند. اشیایی که رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ تم تغییر نمی‌کنند.

مثال انتها‑به‑انتها زیر یک شکل ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` تم را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکردن مؤثر را چاپ می‌کند:

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

چون مستطیل به `Accent4` مرتبط باقی می‌ماند، رنگ قابل‌مشاهده‌اش پس از تغییر تم به قرمز تبدیل می‌شود. اگر رنگ طرح را با یک رنگ مستقیم روی شکل جایگزین کنید، تغییرات بعدی `Accent4` دیگر بر آن پرکردن تأثیر نخواهد گذاشت.

### **استفاده از رنگ‌ها از پالت افزایشی**

PowerPoint با اعمال تبدیل‌های رنگ، گونه‌های روشن‌تر و تیره‌تر را از یک رنگ تم استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/fa/net/aspose.slides/colortransformoperation/) در دسترس می‌گذارد.

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – رنگ‌های اصلی تم.  
**2** – گونه‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی تم.

مثال زیر شش مستطیل بر پایه `Accent4` می‌سازد، بر پنج مورد از آن‌ها تبدیل روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این گونه‌ها مبتنی بر رنگ تم باقی می‌مانند. اگر `Accent4` بعدها تغییر کند، رنگ‌های تبدیل‌شده از مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به اسلات‌های `IColorScheme`**

شمارش [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) از `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) همان اسلات‌های تم را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` در اختیار می‌گذارد. نقشه‌برداری ثابت است:

* `Text1` = `Dark1`  
* `Background1` = `Light1`  
* `Text2` = `Dark2`  
* `Background2` = `Light2`

اینها نام‌های دیگر برای همان اسلات‌های تم هستند؛ مقادیر به‌صورت پویا از یک شکل به شکل دیگر تبدیل نمی‌شوند.

## **تغییر قلم‌های تم**

یک طرح قلم تم شامل مجموعه‌ای اصلی برای عناوین و مجموعه‌ای فرعی برای متن بدنه است. ویژگی‌های [FontScheme.Major](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/major/) و [FontScheme.Minor](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را در اختیار می‌گذارند.

شناسه‌های قلم تم سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn‑lt` – قلم بدنه لاتین (Minor Latin Font)  
* `+mj‑lt` – قلم عنوان لاتین (Major Latin Font)  
* `+mn‑ea` – قلم بدنه آسیای شرقی (Minor East Asian Font)  
* `+mj‑ea` – قلم عنوان آسیای شرقی (Major East Asian Font)

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

عنوان از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که به‌صورت صریح نام قلم را داشته باشد، به‌طور خودکار هنگام تغییر طرح قلم تم سوئیچ نمی‌شود.

مجموعه‌های قلم اصلی و فرعی می‌توانند همچنین نگاشت‌های قلم برای سیستم‌های نوشتاری خاص مانند سیریلیک، عربی، ژاپنی، گرجی و ثان داشته باشند. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به بخش [فونت‌های تم خاص اسکریپت](/slides/fa/net/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="نکته" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [فونت‌های PowerPoint](/slides/fa/net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال تم**

جریان‌های کاری زیر مشکلات مختلف مرتبط با تم را حل می‌کنند.

### **اعمال تم خارجی به اسلایدهای وابسته به یک مستر**

از [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) استفاده کنید وقتی که یک فایل تم PowerPoint (`.thmx`) دارید و می‌خواهید تمام اسلایدهایی که به مستر خاصی وابسته‌اند را بازطراحی کنید. مستر مورد نظر را از مجموعه [Presentation.Masters](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/masters/) که پیاده‌سازی‌کننده [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/) است، انتخاب کنید و مسیر فایل تم را به متد پاس دهید.

این متد عملیات زیر را انجام می‌دهد:

1. یک اسلاید مستر جدید بر پایه مستر انتخاب‌شده ایجاد می‌کند.  
1. تم خارجی را بر مستر جدید اعمال می‌کند.  
1. مستر جدید را به تمام اسلایدهایی که قبلاً به مستر انتخاب‌شده وابسته بودند، اختصاص می‌دهد.  
1. شیء جدید [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) را باز می‌گرداند.

مثال زیر تم خارجی را بر اسلایدهایی که به اولین مستر وابسته‌اند اعمال می‌کند، ارائه را ذخیره می‌کند و نتیجه را دوباره باز می‌خواند:

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

یک تم نامعتبر، خراب یا غیرقابل پشتیبانی می‌تواند باعث بروز [PptxException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxexception/) یا یکی از زیرکلاس‌های مرتبط با فرمت شود. مسیرهای ارائه‌شده توسط کاربر را اعتبارسنجی کنید، خطاهای دسترسی به فایل سیستم را مدیریت کنید و تنها پس از اعمال موفق تم، ارائه را ذخیره کنید.

فقط اسلایدهایی که به مستر انتخاب‌شده وابسته بودند، بازتخصیص می‌یابند. اسلایدهای مرتبط با مسترهای دیگر مسترها و تم‌های موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکردن‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از تم بر اساس تم خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکردن‌ها و سایر قالب‌بندی‌های صریح ممکن است بدون تغییر بمانند. بازنویسی‌های سطح لایه و اسلاید نیز می‌توانند بر مقادیر وارث‌شده از مستر جدید ارجحیت داشته باشند.

تم ممکن است به قلم‌هایی که در محیط زمان اجرا موجود نیستند ارجاع دهد. برای رندرینگ و خروجی یکنواخت، قلم‌های مورد نیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/net/custom-font/) تأمین کنید یا [جایگزینی قلم](/slides/fa/net/font-substitution/) را پیکربندی کنید.

این یک جریان کاری مستقیم در سطح مستر است: متد مسیر فایل `.thmx` را می‌پذیرد و نیازی به ایجاد دستی بازنویسی‌های تم در سطح اسلاید یا لایه نیست.

### **اعمال تم‌های خارجی متفاوت در ارائه چند‑مستری**

زمانی که مستر مورد نظر از پیش مشخص نیست، آن را از یک اسلاید نماینده از طریق [ISlide.LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/layoutslide/) و [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/masterslide/) به‌دست آورید. قبل از اعمال هر تمی، مراجع مسترهای اصلی را ذخیره کنید، زیرا هر فراخوانی یک مستر دیگر در ارائه ایجاد می‌کند.

مثال زیر اسلایدهایی از دو بخش را برای یافتن مسترهایشان استفاده می‌کند و تم خارجی متفاوتی را بر هر گروه اعمال می‌کند:

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

فراخوانی اول تنها بر اسلایدهایی که به `firstGroupMaster` وابسته بودند تأثیر می‌گذارد و فراخوانی دوم تنها بر اسلایدهایی که به `secondGroupMaster` وابسته بودند. اسلایدهای متعلق به هر مستر دیگری بازطراحی نمی‌شوند.

### **حفظ تم منبع هنگام جابه‌جائی اسلایدها**

اگر می‌خواهید اسلایدی را به ارائه دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را به ارائه مقصد با [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) کلون کنید، سپس اسلاید را با [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) و مستر کلون‌شده کلون کنید. این کار مستر، لایه‌ها و تم مرتبط را به‌صورت یکجا منتقل می‌کند.

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

این جریان کاری ترجیحی زمانی است که اسلاید منبع باید در مقصد همان شکل ظاهر شود. فقط کلون کردن محتوا روی مستر مقصد نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر تم را تغییر دهد.

### **اعمال مقادیر تم به اسلاید موجود**

اگر اسلاید هدف باید بر روی مستر و لایه فعلی خود بماند، بازنویسی سطح اسلاید را از تم منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initfontschemefrom/) و [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initformatschemefrom/) سه مؤلفه اصلی تم را به بازنویسی کپی می‌کنند.

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

این کار تم مورد استفاده آن اسلاید را بدون تغییر تم وارث‌شده توسط سایر اسلایدها تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر وارث‌شده، [OverrideTheme.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی تم به یک لایه**

بازنویسی سطح لایه بر اسلایدهایی که از آن لایه استفاده می‌کنند اعمال می‌شود، مگر این‌که اسلاید خاصی بازنویسی خود را داشته باشد. می‌توان از همان متدهای مقداردهی اولیه از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/layoutslidethememanager/) لایه استفاده کرد:

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

از تم مستر یا سطح ارائه استفاده کنید وقتی که بسیاری از لایه‌ها و اسلایدها باید طراحی پایه یکسانی داشته باشند؛ از بازنویسی لایه وقتی که یک خانواده لایه به سبک متفاوتی نیاز دارد؛ و از بازنویسی اسلاید فقط برای استثناهای واقعی. بازنویسی‌های بیش از حد در سطح اسلاید، اعمال تغییرات سراسری تم را دشوارتر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینه تم**

پرکردن‌های پس‌زمینه تم در [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینه بیشتری را نسبت به تعداد تعریف‌های پرکردن موجود در این مجموعه نشان دهد، زیرا UI می‌تواند پرکردن‌های تم را با رنگ‌های تم و مراجع سبک دیگر ترکیب کند.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و [Background.StyleIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/background/styleindex/) فعلی را بررسی کنید. `StyleIndex` مقدار `0` را برای عدم وجود پرکردن تم استفاده می‌کند؛ مقادیر مثبت ارجاع به سبک‌های پس‌زمینه تم هستند. این متفاوت از اندیس‌گذاری مستقیم مجموعه .NET است که در آن `[0]` اولین مورد ذخیره‌شده را نشان می‌دهد. فرض نکنید که هر ارائه تعداد یکسانی از سبک‌های پرکردن پس‌زمینه دارد.

مثال زیر تعداد پرکردن‌های پس‌زمینه موجود را گزارش می‌دهد، یک ارجاع پس‌زمینه تم به اولین مستر تخصیص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل‌مشاهده به ورودی تم ارجاع‌داده‌شده توسط مستر و هر بازنویسی پس‌زمینه در سطح لایه یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خاص خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستר ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="هشدار" %}}
`StyleIndex` را به‌عنوان یک اندیس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدنویسی ثابت یک شماره سبک از یک فایل و فرض بر این‌که در فایل دیگر همان ظاهر را دارد خودداری کنید؛ تعریف‌های سبک تم خاص هر ارائه‌اند.
{{% /alert %}}

{{% alert color="info" title="نکته" %}}
برای قالب‌بندی مستقیم پس‌زمینه و وراثت پس‌زمینه، به [پس‌زمینهٔ ارائه](/slides/fa/net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های تم**

یک طرح قالب تم شامل مجموعه‌های جداگانهٔ [FillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/linestyles/)، و [EffectStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/effectstyles/) است. تم‌های معمولی Office اغلب سه ورودی سبک اصلی دارند که به‌صورت بصری متناظر با قالب‌بندی‌های Subtle، Moderate و Intense هستند، اما کد باید هر مجموعه را بررسی کند و به‌جای فرض تعداد ثابت، از مقدار واقعی استفاده کند.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

در C# دسترسی به این مجموعه‌ها صفر‑پایه است: `[0]` اولین سبک ذخیره‌شده و `[2]` سومین مورد است. اندیس‌های مرجع‑سبک یک شکل مفهومی جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک تم بر شکل‌هایی که آن سبک را ارجاع می‌دهند تأثیر می‌گذارد؛ شکل‌های دارای قالب‌بندی مستقیم ممکن است بدون تغییر بمانند.

مثال زیر وجود ورودی‌های سبک موردنیاز را بررسی می‌کند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکردن را تغییر می‌دهد، یک سایهٔ بیرونی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای شکل‌هایی که این اسلات‌ها را ارجاع می‌دهند، اولین سبک خط تم قرمز می‌شود، سومین سبک پرکردن تم به رنگ سبز جنگلی جامد تغییر می‌کند و سومین سبک افکت یک سایهٔ بیرونی با فاصلهٔ ۱۰ پوینت به‌دست می‌آورد. نتیجهٔ بصری دقیق همچنان به این بستگی دارد که هر شکل کدام اسلات سبک را ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر تم اولویت دارد یا خیر.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **تشخیص اینکه آیا یک پرکردن جامد مؤثر از رنگ تم استفاده می‌کند**

یک پرکردن می‌تواند به‌صورت مستقیم روی شیء ذخیره شود یا از یک پاراگراف، لایه، مستر، سبک تم یا سطح قالب‌بندی دیگری وارث شود. برای حل این سلسله‌مراتب به یک شیء نا‌قابل تغییر [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/) می‌توانید از [IFillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformat/geteffective/) استفاده کنید. ابتدا [IFillFormatEffectiveData.FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/filltype/) را بررسی کنید. فقط وقتی مقدار `FillType.Solid` باشد باید ویژگی‌های پرکردن جامد را بخوانید.

برای یک پرکردن جامد، [IFillFormatEffectiveData.SolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) مقدار نهایی RGB پس از وراثت، جست‌وجوی تم و اعمال تبدیل‌های رنگی را برمی‌گرداند. [IFillFormatEffectiveData.SolidFillSchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/ifillformateffectivedata/solidfillschemecolor/) اسلات منطقی [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) مربوطه مانند `Text1` یا `Accent6` را برمی‌گرداند. مقدار `SchemeColor.NotDefined` به این معنی است که پرکردن جامد مؤثر بر پایه یک رنگ طرح نیست. در یک جریان کاری که پرکردن‌ها فقط رنگ‌های تم یا رنگ‌های RGB مستقیم هستند، این مقدار یک پرکردن RGB مستقیم را شناسایی می‌کند.

از مقدار محلی [IColorFormat.SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/icolorformat/schemecolor/) به‌تنهایی برای طبقه‌بندی پرکردن استفاده نکنید. برای مثال، بخشی از متن ممکن است رنگ طرح محلی نداشته باشد، بنابراین مقدار محلی آن `NotDefined` است، در حالی که پرکردن مؤثر آن یک رنگ تم را وارث می‌شود و به `Text1` یا `Accent6` حل می‌شود. برعکس، `SolidFillSchemeColor` به شما می‌گوید که کدام اسلات منطقی تم رنگ مؤثر را تولید کرده است، اما نمی‌گوید این اسلات از شیء، پاراگراف، لایه، مستر یا سطح دیگر سلسله مراتب آمده است.

مثال زیر ارائه‌ای را بارگذاری می‌کند، پرکردن‌های شکل‌ها و پرکردن‌های بخش‌های متن را حسابرسی می‌کند، هر مقدار RGB نهایی و رنگ طرح مربوطه را چاپ می‌کند و پرکردن‌های جامدی که تغییر رنگ تم را دنبال نمی‌کنند فلگ می‌کند:

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

شاخهٔ `NotDefined` فهرستی از پرکردن‌های جامد ارائه می‌دهد که به تغییرات در اسلات‌های رنگ تم واکنش نشان نمی‌دهند. این اشیا را زمانی بررسی کنید که ارائه باید با پالت برندی جدید هم‌خوانی داشته باشد. مقدار RGB گزارش‌شده هنوز ظاهر فعلی را نشان می‌دهد، در حالی که مقدار طرح توضیح می‌دهد آیا این ظاهر به تم مرتبط است یا نه.

اشیای مؤثر‑فرمت اسنپ‌شات هستند. پس از تغییر تم ارائه، یک بازنویسی تم یا هر قالب‌بندی وارث‌شده، دوباره `GetEffective` را فراخوانی کنید و پیش از مقایسه یا گزارش رنگ‌ها، شیء جدید `IFillFormatEffectiveData` را بخوانید.

## **خواندن مقادیر مؤثر تم**

اشیای خام تم به شما می‌گویند در سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر می‌گویند یک اسلاید یا شکل پس از ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) را فراخوانی کنید. برای پس‌زمینه، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) و برای پرکردن، از [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) استفاده کنید.

مثال زیر تم مؤثر، پس‌زمینه و اولین پرکردن شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه‌ها استفاده کنید. اگر فقط به [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) نگاه کنید، ممکن است بازنویسی‌های مستر، لایه، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهند، از دست بدهید.

## **پرسش‌های متداول**

**آیا اعمال تم خارجی بر همه اسلایدهای ارائه تأثیر می‌گذارد؟**

نه. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) تنها اسلایدهایی را که به مستر انتخاب‌شده وابسته‌اند، بازتخصیص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند، تم‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم تم را فقط بر یک اسلاید اعمال کنم بدون تغییر مستر؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و بازنویسی تم آن را مقداردهی اولیه کنید. تغییر تنها به‌صورت محلی بر آن اسلاید اعمال می‌شود؛ سایر اسلایدها تم‌های موجود خود را ادامه می‌دهند.

**امن‌ترین راه برای انتقال تم از یک ارائه به ارائهٔ دیگر چیست؟**

هنگام جابه‌جایی اسلاید و حفظ ظاهر منبع، مستر منبع را به مقصد کلون کنید و سپس اسلاید را با همان مستر با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) و [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، لایه‌ها و تم را همراه هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

از [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) برای یک اسلاید یا تم لایه استفاده کنید و برای اشیای فرمت مربوطه، متدهای مؤثر‑دیتا مانند [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) و [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) را فراخوانی کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.