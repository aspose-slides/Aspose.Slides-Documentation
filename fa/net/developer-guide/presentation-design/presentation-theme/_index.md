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
- قالب خارجی
- THMX
- رنگ قالب
- پالت تکمیلی
- قلم قالب
- سبک قالب
- افکت قالب
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "قالب‌های ارائه اصلی در Aspose.Slides برای .NET برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های PowerPoint با برندینگ یکسان."
---
## **مقدمه**

یک قالب ارائه مجموعه‌ای هماهنگ از رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه، پرکننده‌ها، خطوط و افکت‌ها را تعریف می‌کند. اشیای آگاه از قالب به این تعاریف مشترک ارجاع می‌دهند به جای اینکه هر ویژگی بصری را به عنوان مقدار ثابت ذخیره کنند، بنابراین تغییر قالب می‌تواند بسیاری از اشیا را به‌طور هم‌زمان به‌روزرسانی کند.

در Aspose.Slides، قالب در سطح ارائه از طریق ویژگی [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) در دسترس است. یک ارائه همچنین می‌تواند بازنویسی‌های قالب را در سطوح پایین‌تر داشته باشد. یک مستر می‌تواند قالب ارائه را از طریق [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/masterthememanager/overridetheme/) بازنویسی کند، یک لِی‌آوت می‌تواند قالب ارث‌برده خود را از طریق [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/overridetheme/) بازنویسی کند و یک اسلاید جداگانه می‌تواند همین کار را انجام دهد. در عمل، قالب مؤثر برای یک اسلاید از طریق این زنجیره ارث‌بری حل می‌شود: قالب ارائه، بازنویسی مستر، بازنویسی لِی‌آوت و بازنویسی اسلاید.

![اجزای قالب: رنگ‌ها، قلم‌ها، سبک‌های پس‌زمینه و افکت‌ها](theme-constituents.png)

بخش‌های زیر رایج‌ترین جریان‌های کاری مربوط به قالب را نشان می‌دهند: بررسی یک قالب، تغییر رنگ‌ها و قلم‌ها، کپی یا اعمال یک قالب، به‌روزرسانی سبک‌های پس‌زمینه و افکت‌ها، و خواندن مقادیر مؤثر پس از حل ارث‌بری و بازنویسی‌ها.

## **بررسی یک قالب**

شیء [MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/) طرح‌واره‌های [ColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/colorscheme/)، [FontScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/fontscheme/) و [FormatScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/mastertheme/formatscheme/) را در اختیار می‌گذارد. بررسی این مجموعه‌ها قبل از تغییرشان به‌ویژه زمانی مفید است که یک ارائه از منبع خارجی آمده باشد، زیرا تعداد و محتوای ورودی‌های سبک می‌تواند متفاوت باشد.

مثال زیر خصوصیات اصلی قالب را می‌خواند و گزارش می‌دهد که چند سبک پس‌زمینه، پرکننده، خط و افکت در قالب ذخیره شده‌اند:

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

اگر فایلی چند مستر داشته باشد، فرض نکنید که هر اسلاید همان قالب مؤثر را دارد. مستری که به اسلاید مرتبط است را بررسی کنید و هنگام وجود بازنویسی‌های لِی‌آوت یا اسلاید از جریان کاری «قالب مؤثر» نشان داده شده در ادامه این مقاله استفاده کنید.

## **تغییر رنگ‌های قالب**

پرکننده‌ها، خطوط و متن‌های آگاه از قالب می‌توانند به یک رنگ منطقی از enumeration [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) ارجاع دهند. هنگامی که ورودی متناظر را در [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) قالب تغییر می‌دهید، تمام اشیائی که هنوز به آن رنگ قالب ارجاع می‌دهند، بر اساس مقدار جدید محاسبه می‌شوند. اشیائی که از یک رنگ RGB مستقیم استفاده می‌کنند، توسط به‌روزرسانی رنگ قالب تغییر نمی‌کنند.

مثال زیر به‌صورت انتها‑به‑انتها یک شکل را ایجاد می‌کند که از `Accent4` استفاده می‌کند، رنگ `Accent4` قالب را به قرمز تغییر می‌دهد، ارائه را ذخیره می‌کند، دوباره باز می‌کند و رنگ پرکننده مؤثر را چاپ می‌کند:

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

چون مستطیل همچنان به `Accent4` لینک شده است، رنگ قابل‌مشاهده آن پس از تغییر قالب به قرمز می‌شود. اگر رنگ طرح در شکل را با یک رنگ مستقیم جایگزین کنید، تغییرات بعدی `Accent4` دیگر روی آن پرکننده تأثیر نخواهد داشت.

### **استفاده از رنگ‌ها از پالت تکمیلی**

PowerPoint با اعمال تبدیل‌های رنگی، گونه‌های روشن‌تر و تیره‌تر را از یک رنگ قالب استخراج می‌کند. Aspose.Slides این تبدیل‌ها را از طریق [ColorTransformOperation](https://reference.aspose.com/slides/fa/net/aspose.slides/colortransformoperation/) در اختیار می‌گذارد.

![رنگ‌های اصلی قالب و رنگ‌های روشن‌تر و تیره‌تر تولید شده از پالت تکمیلی](additional-palette-colors.png)

**1** - رنگ‌های اصلی قالب.  
**2** - گونه‌های روشن‌تر و تیره‌تر تولید شده از رنگ‌های اصلی قالب.

مثال زیر شش مستطیل بر پایه `Accent4` ایجاد می‌کند، برای پنج مورد از آن‌ها تبدیل روشنایی اعمال می‌کند و نتیجه را ذخیره می‌نماید:

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

این گونه‌ها همچنان مبتنی بر رنگ قالب هستند. اگر `Accent4` بعداً تغییر کند، رنگ‌های تبدیل‌شده بر اساس مقدار جدید `Accent4` بازمحاسبه می‌شوند.

### **نقشه‌برداری مقادیر `SchemeColor` به موقعیت‌های `IColorScheme`**

enumeration [SchemeColor](https://reference.aspose.com/slides/fa/net/aspose.slides/schemecolor/) از مقادیر `Text1`، `Background1`، `Text2` و `Background2` استفاده می‌کند، در حالی که [IColorScheme](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/icolorscheme/) همان موقعیت‌های قالب را به صورت `Dark1`، `Light1`، `Dark2` و `Light2` نمایش می‌دهد. نقشه‌برداری ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

این‌ها نام‌های جایگزین برای همان موقعیت‌های قالب هستند؛ مقادیری نیستند که به‌صورت پویا از یک فرم به فرم دیگر تبدیل شوند.

## **تغییر قلم‌های قالب**

یک طرح‌واره قلم قالب شامل مجموعه‌ای اصلی برای سرفصل‌ها و مجموعه‌ای فرعی برای متن بدنه است. ویژگی‌های [FontScheme.Major](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/major/) و [FontScheme.Minor](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/fontscheme/minor/) این مجموعه‌ها را افشا می‌کنند.

شناسه‌های قلم قالب سازگار با PowerPoint می‌توانند در قالب‌بندی متن استفاده شوند:

* `+mn-lt` - قلم بدنه لاتین (Minor Latin Font)
* `+mj-lt` - قلم سرفصل لاتین (Major Latin Font)
* `+mn-ea` - قلم بدنه آسیای شرقی (Minor East Asian Font)
* `+mj-ea` - قلم سرفصل آسیای شرقی (Major East Asian Font)

مثال زیر یک سرفصل که از قلم لاتین اصلی قالب استفاده می‌کند و یک خط بدنه که از قلم لاتین فرعی قالب استفاده می‌کند، ایجاد می‌کند. سپس قلم‌های قالب را تغییر داده و نتیجه را ذخیره می‌کند:

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

سرفصل از قلم اصلی پیروی می‌کند و متن بدنه از قلم فرعی. متنی که یک نام قلم صریح به جای شناسه قالب داشته باشد، به‌طور خودکار هنگام تغییر طرح‌واره قلم قالب تغییر نمی‌کند.

مجموعه‌های قلم اصلی و فرعی می‌توانند شامل نگاشت‌های قلم برای سیستم‌های نوشتاری خاص باشند، مانند سیریلیک، عربی، ژاپنی، گرجی و ثانا. برای بررسی، افزودن، جایگزینی یا حذف این نگاشت‌ها، به بخش [Script-Specific Theme Fonts](/slides/fa/net/script-specific-font-mappings/) مراجعه کنید.

{{% alert color="info" title="Tip" %}}
برای اطلاعات بیشتر درباره قلم‌های ارائه، به [PowerPoint Fonts](/slides/fa/net/powerpoint-fonts/) مراجعه کنید.
{{% /alert %}}

## **کپی یا اعمال یک قالب**

جریان‌های کاری زیر مشکلات مختلف مرتبط با قالب را حل می‌کنند.

### **اعمال یک قالب خارجی به اسلایدهای وابسته به مستر**

از [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) زمانی استفاده کنید که یک فایل قالب PowerPoint (`.thmx`) داشته باشید و بخواهید همه اسلایدهای وابسته به یک مستر خاص را دوباره سبک‌بندی کنید. مستر موردنظر را از مجموعه [Presentation.Masters](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/masters/) که پیاده‌ساز [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/) است، انتخاب کنید و مسیر فایل قالب را به متد پاس دهید.

متد عملیات زیر را انجام می‌دهد:

1. یک مستر اسلاید جدید بر پایه مستر منتخب ایجاد می‌کند.  
1. قالب خارجی را به مستر جدید اعمال می‌کند.  
1. مستر جدید را به همه اسلایدهایی که قبلاً به مستر منتخب وابسته بودند، اختصاص می‌دهد.  
1. جدیداً ایجاد شدهٔ [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) را برمی‌گرداند.

مثال زیر یک قالب خارجی را بر اسلایدهای وابسته به اولین مستر اعمال می‌کند، ارائه را ذخیره می‌کند و نتیجه را دوباره باز می‌خواند:

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

یک قالب نامعتبر، خراب یا نامپشتیبانی‌شده می‌تواند منجر به [PptxException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxexception/) یا یکی از زیرکلاس‌های مربوط به فرمت شود. مسیرهای ورودی کاربر را اعتبارسنجی کنید، شکست‌های دسترسی به سیستم‌فایل را مدیریت کنید و فقط پس از اعمال موفقیت‌آمیز قالب، ارائه را ذخیره نمایید.

فقط اسلایدهایی که به مستر منتخب وابسته بودند، بازتخصیص می‌یابند. اسلایدهای مرتبط با مسترهای دیگر مستر و قالب موجود خود را حفظ می‌کنند. رنگ‌ها، قلم‌ها، پرکننده‌ها، خطوط، پس‌زمینه‌ها و افکت‌های آگاه از قالب در برابر قالب خارجی حل می‌شوند. رنگ‌ها، قلم‌ها، پرکننده‌ها و دیگر قالب‌بندی‌های صریحی که به‌صورت مستقیم اختصاص داده شده‌اند ممکن است بدون تغییر بمانند. بازنویسی‌های سطح لِی‌آوت و اسلاید نیز می‌توانند بر مقادیر ارث‌برده از مستر جدید اولویت داشته باشند.

قالب می‌تواند به قلم‌هایی اشاره کند که در محیط زمان اجرا موجود نیستند. برای رندرینگ و صادرات یکدست، قلم‌های مورد نیاز را نصب کنید، از [منابع قلم سفارشی](/slides/fa/net/custom-font/) ارائه دهید یا [جایگزینی قلم](/slides/fa/net/font-substitution/) را پیکربندی کنید.

این یک جریان کاری مستقیم در سطح مستر است: متد فقط مسیر فایل `.thmx` را می‌پذیرد و نیازی به ایجاد بازنویسی‌های سطح اسلاید یا لِی‌آوت به‌صورت دستی نیست.

### **اعمال قالب‌های خارجی مختلف در یک ارائهٔ چندمستر**

زمانی که مستر موردنظر از پیش شناخته نشده باشد، آن را از یک اسلاید نماینده از طریق [ISlide.LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/layoutslide/) و [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/masterslide/) به‌دست آورید. پیش از اعمال هر قالب، مراجع مستر اصلی را ذخیره کنید، زیرا هر فراخوانی یک مستر دیگر در ارائه ایجاد می‌کند.

مثال زیر اسلایدهای دو بخش را برای یافتن مسترهایشان استفاده می‌کند و برای هر گروه یک قالب خارجی متفاوت اعمال می‌نماید:

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

فراخوانی اول فقط بر اسلایدهایی که به `firstGroupMaster` وابسته بودند تأثیر می‌گذارد و فراخوانی دوم فقط بر اسلایدهایی که به `secondGroupMaster` وابسته بودند. اسلایدهایی که به هر مستر دیگری تعلق دارند، دوباره‌سبک‌بندی نمی‌شوند.

### **حفظ قالب منبع هنگام جابجایی اسلایدها**

اگر می‌خواهید یک اسلاید را به ارائهٔ دیگری منتقل کنید و طراحی اصلی آن را حفظ کنید، مستر منبع را با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) به ارائهٔ هدف کلون کنید، سپس اسلاید را با استفاده از [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) و مستر کلون‌شده کلون کنید. این کار مستر، لِی‌آوت‌ها و قالب مرتبط را همراه خود حمل می‌کند.

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

این جریان کاری ترجیحی است وقتی اسلاید منبع باید در مقصد ظاهر یکسانی داشته باشد. صرفاً کلون کردن محتوا بر روی مستر مقصدی نامرتبط می‌تواند رنگ‌ها، قلم‌ها، پس‌زمینه‌ها و افکت‌های مبتنی بر قالب را تغییر دهد.

### **اعمال مقادیر قالب به یک اسلاید موجود**

اگر اسلاید هدف باید روی مستر و لِی‌آوت فعلی خود بماند، یک بازنویسی سطح اسلاید را از قالب منبع مقداردهی اولیه کنید. متدهای [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initcolorschemefrom/)، [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initfontschemefrom/) و [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/initformatschemefrom/) سه مؤلفهٔ اصلی قالب را به بازنویسی کپی می‌کنند.

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

این کار قالب مورد استفادهٔ آن اسلاید را بدون تغییر قالب ارث‌بردهٔ اسلایدهای دیگر تغییر می‌دهد. برای حذف بازنویسی محلی و بازگشت به مقادیر ارث‌برده، متد [OverrideTheme.Clear](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/overridetheme/clear/) را فراخوانی کنید.

### **اعمال بازنویسی قالب به یک لِی‌آوت**

یک بازنویسی سطح لِی‌آوت بر اسلایدهایی که از آن لِی‌آوت استفاده می‌کنند اعمال می‌شود، مگر این که اسلاید خاص خود بازنویسی داشته باشد. همان متدهای مقداردهی اولیه می‌توانند از طریق [LayoutSlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/layoutslidethememanager/) لِی‌آوت استفاده شوند:

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

هنگامی که بسیاری از لِی‌آوت‌ها و اسلایدها باید همان طراحی پایه را به‌اشتراک بگذارند، از قالب در سطح مستر یا ارائه استفاده کنید؛ برای یک خانواده لِی‌آوت که به سبک متفاوتی نیاز دارد، یک بازنویسی لِی‌آوت کافی است؛ و برای موارد استثنایی واقعی، فقط یک بازنویسی اسلاید کافی است. استفاده بی‌رویه از بازنویسی‌های سطح اسلاید تغییرات کلی قالب را در آینده پیش‌بینی‌پذیرتر می‌کند.

## **به‌روزرسانی سبک‌های پس‌زمینهٔ قالب**

پرکننده‌های پس‌زمینهٔ قالب در [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/backgroundfillstyles/) ذخیره می‌شوند. PowerPoint می‌تواند گزینه‌های پس‌زمینهٔ بیشتری را در رابط کاربری خود نسبت به تعداد تعریف‌های فیزیکی موجود در این مجموعه ارائه دهد، زیرا UI می‌تواند پرکننده‌های قالب را با رنگ‌های قالب و دیگر مراجع سبک ترکیب کند.

![گالری سبک پس‌زمینهٔ PowerPoint برای یک قالب ارائه](presentation-design_8.png)

قبل از استفاده از یک سبک پس‌زمینه، مجموعه ذخیره‌شده و [Background.StyleIndex](https://reference.aspose.com/slides/fa/net/aspose.slides/background/styleindex/) جاری را بررسی کنید. `StyleIndex` برای عدم وجود پرکنندهٔ قالب مقدار `0` را دارد؛ مقادیر مثبت مرجع به سبک‌های پس‌زمینهٔ قالب هستند. این متفاوت از ایندکس‌گذاری مستقیم مجموعهٔ .NET است، جایی که `[0]` به اولین مورد ذخیره‌شده اشاره دارد. فرض نکنید که هر ارائه همان تعداد سبک پرکنندهٔ پس‌زمینه را دارد.

مثال زیر تعداد پرکننده‌های پس‌زمینهٔ موجود را گزارش می‌کند، یک مرجع پس‌زمینهٔ قالبی را به اولین مستر اختصاص می‌دهد و ارائه را ذخیره می‌کند:

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

نتیجهٔ قابل مشاهده به ورودی قالبی که مستر به آن ارجاع می‌دهد و به هر بازنویسی پس‌زمینهٔ لِی‌آوت یا اسلاید بستگی دارد. اگر اسلاید پس‌زمینهٔ خود را داشته باشد، تغییر فقط پس‌زمینهٔ مستر ممکن است آن اسلاید را تغییر ندهد. برای دانستن پس‌زمینهٔ نهایی پس از اعمال ارث‌بری، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) استفاده کنید.

{{% alert color="warning" title="Warning" %}}
`StyleIndex` را به‌عنوان ایندکس صفر‑پایه مجموعه در نظر نگیرید. همچنین از کدنویسی سخت‌افزاری که شمارهٔ یک سبک را از یک فایل می‌گیرد و فرض می‌کند در فایل دیگر همان ظاهر را دارد، خودداری کنید؛ تعاریف سبک قالب به‌صورت خاص به هر ارائه هستند.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
برای قالب‌بندی مستقیم پس‌زمینه و ارث‌بری پس‌زمینه، به بخش [Presentation Background](/slides/fa/net/presentation-background/) مراجعه کنید.
{{% /alert %}}

## **به‌روزرسانی افکت‌های قالب**

یک طرح‌واره قالب شامل مجموعه‌های جداگانهٔ [FillStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/fillstyles/)، [LineStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/linestyles/)، و [EffectStyles](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/formatscheme/effectstyles/) است. قالب‌های Office معمولاً سه ورودی اصلی سبک دارند که به‌صورت بصری با قالب‌بندی‌های «ملایم»، «متوسط» و «قوی» متناظرند، اما کد باید هر مجموعه را بررسی کند و از فرض تعداد ثابت خودداری کند.

![افکت‌های قالب ملایم، متوسط و قوی که بر روی یک شکل اعمال شده‌اند](presentation-design_10.png)

در C# ایندکس مجموعه پایه‌صفر است: `[0]` اولین سبک ذخیره‌شده و `[2]` سومین. ایندکس‌های مرجع سبک یک شکل مفهومی جداگانه است که از طریق [IShapeStyle](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapestyle/) در دسترس است. تغییر یک سبک قالب بر اشکالی که به آن سبک ارجاع می‌دهند تأثیر می‌گذارد؛ اشکالی که قالب‌بندی مستقیم دارند ممکن است بدون تغییر بمانند.

مثال زیر بررسی می‌کند که ورودی‌های سبک موردنیاز وجود دارند، اولین سبک خط را تغییر می‌دهد، سومین سبک پرکننده را تغییر می‌دهد، یک سایهٔ خارجی را در سومین سبک افکت فعال می‌کند و نتیجه را ذخیره می‌کند:

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

برای اشکالی که به این موقعیت‌ها ارجاع می‌دهند، اولین سبک خط قالب به قرمز تغییر می‌یابد، سومین سبک پرکننده قالب به سبز جنگلی جامد تبدیل می‌شود و سومین سبک افکت یک سایهٔ خارجی با فاصلهٔ ۱۰ پوینت می‌گیرد. نتیجهٔ بصری دقیق همچنان به این بستگی دارد که هر شکل به کدام موقعیت‌های سبک ارجاع می‌دهد و آیا قالب‌بندی مستقیم بر قالب اولویت دارد یا نه.

![سبک‌های افکت قالب پس از تغییر تنظیمات خط، پرکننده و سایه](presentation-design_11.png)

## **خواندن مقادیر مؤثر قالب**

شیءهای خام قالب به شما می‌گویند که در سطح خاص چه چیزی تعریف شده است. مقادیر مؤثر به شما می‌گویند که یک اسلاید یا شکل پس از حل ارث‌بری و بازنویسی‌های محلی واقعاً چه چیزی استفاده می‌کند. برای یک اسلاید، متد [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) را فراخوانی کنید. برای پس‌زمینه، از [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) و برای پرکننده، از [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) استفاده کنید.

مثال زیر قالب مؤثر، پس‌زمینه و پرکنندهٔ اولین شکل را از یک اسلاید می‌خواند:

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

از داده‌های مؤثر برای تشخیص رندر، اعتبارسنجی و مقایسه استفاده کنید. اگر فقط [Presentation.MasterTheme](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/mastertheme/) را بررسی کنید، ممکن است یک بازنویسی مستر، لِی‌آوت، اسلاید یا شکل که ظاهر نهایی را تغییر می‌دهد، از دست برود.

## **سوالات متداول**

**آیا اعمال یک قالب خارجی بر تمام اسلایدهای ارائه تأثیر می‌گذارد؟**

خیر. متد [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) فقط اسلایدهایی را که به مستر منتخب وابسته هستند، بازتخصیص می‌دهد. اسلایدهایی که از مسترهای دیگر استفاده می‌کنند، قالب‌های موجود خود را حفظ می‌کنند.

**آیا می‌توانم یک قالب را فقط بر یک اسلاید بدون تغییر مستر اعمال کنم؟**

بله. از [SlideThemeManager](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/slidethememanager/) اسلاید استفاده کنید و بازنویسی قالب آن را مقداردهی اولیه کنید. تغییر فقط به‌صورت محلی روی آن اسلاید اعمال می‌شود؛ سایر اسلایدها به قالب‌های موجود خود ادامه می‌دهند.

**ایمن‌ترین روش برای انتقال یک قالب از یک ارائه به ارائه دیگر چیست؟**

هنگامی که اسلایدی را جابجا می‌کنید و می‌خواهید ظاهر منبع را حفظ کنید، مستر منبع را به مقصد کلون کنید و سپس اسلاید را با آن مستر با استفاده از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) و [ISlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/islidecollection/addclone/) کلون کنید. این کار مستر، لِی‌آوت‌ها و قالب را با هم نگه می‌دارد.

**چگونه می‌توانم مقادیر مؤثر را پس از ارث‌بری و بازنویسی‌ها ببینم؟**

برای یک اسلاید یا قالب لِی‌آوت از [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) و برای اشیای فرمت مانند [Background.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/background/geteffective/) و [FillFormat.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/geteffective/) استفاده کنید. این APIها مقادیر حل‌شده پس از اعمال ارث‌بری و بازنویسی‌ها را برمی‌گردانند.