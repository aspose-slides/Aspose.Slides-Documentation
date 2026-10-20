---
title: تبدیل PPT و PPTX به PDF در .NET [شامل ویژگی‌های پیشرفته]
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/net/convert-powerpoint-to-pdf/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- PowerPoint به PDF
- ارائه به PDF
- PPT به PDF
- تبدیل PPT به PDF
- PPTX به PDF
- تبدیل PPTX به PDF
- ذخیره PowerPoint به صورت PDF
- ذخیره PPT به صورت PDF
- ذخیره PPTX به صورت PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به PDFهای با کیفیت بالا و قابل جستجو در .NET با استفاده از Aspose.Slides تبدیل کنید، با مثال‌های سریع کد C# و گزینه‌های پیشرفتهٔ تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به قالب PDF در C# مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، با استفاده از گزینه‌های مختلف کیفیت تصویر را کنترل کنید، اسلایدهای پنهان را شامل کنید، فایل‌های PDF را با پسورد محافظت کنید، جایگزینی قلم‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از روش [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) متد [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="توجه" %}}
Aspose.Slides for .NET اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، فیلد Application با "*Aspose.Slides*" و فیلد PDF Producer با مقدار به شکل "*Aspose.Slides v XX.XX*" پر می‌شود. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تا:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDF‌های تولید شده به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پاصفحه
* گلوله‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل نمایش را با تنظیمات پیش‌فرض صادرات به PDF ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="توجه" %}}
Aspose یک [**مبدل آنلاین رایگان PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست زنده از رویهٔ شرح‌داده‌شده در اینجا انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)— را فراهم می‌کند که به شما اجازه می‌دهد PDF خروجی را شخصی‌سازی کنید، PDF را با پسورد قفل کنید یا نحوهٔ پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستر، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، پیکسل‌درصد (DPI) برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند که کیفیت JPEG روی 90 تنظیم شده، وضوح تصویر بر 300 DPI تنظیم شده، متافایل‌ها به صورت PNG ذخیره می‌شوند و فشرده‌سازی متن به صورت Flate انجام می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **انتخاب خودکار فشرده‌سازی تصویر**

وقتی یک ارائه شامل تعداد زیادی عکس یا اسکرین‌شات باشد، کاهش حجم PDF خروجی می‌تواند ارسال ایمیل یا دانلود را آسان‌تر سازد. مقدار `true` را به [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) اختصاص دهید تا به‌صورت خودکار مناسب‌ترین الگوریتم فشرده‌سازی برای هر تصویر در زمان صادرات PDF انتخاب شود.

مثال زیر یک ارائهٔ موجود را بارگذاری می‌کند، انتخاب خودکار فشرده‌سازی تصویر را فعال می‌سازد و آن را به یک سند PDF ذخیره می‌کند. سایر تنظیمات صادرات PDF مقادیر پیش‌فرض خود را حفظ می‌کنند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

این گزینه برای هر تصویر یک الگوریتم فشرده‌سازی انتخاب می‌کند. کاهش [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) کیفیت تصویر JPEG را کاهش می‌دهد، در حالی که کاهش [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) اجازه می‌دهد تصاویر به وضوح پایین‌تری پایین‌نمونه‌گیری شوند که می‌تواند جزئیات را کم‌کند. فعال‌سازی انتخاب خودکار فشرده‌سازی به‌تنهایی هیچ‌یک از این تنظیمات را پایین نمی‌آورد.

انتخاب الگوریتم‌های فشرده‌سازی تصویر زمان پردازش و حافظه بیشتری می‌طلبد. کاهش حجم به تصاویر ارائه و تنظیمات صادرات بستگی دارد؛ کاهش ثابت برای هر ارائه تضمین نمی‌شود.

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک کتاب‌کار Excel جاسازی‌شده باشد، ممکن است بخواهید گیرندگان PDF هم به داده‌های کتاب‌کار دسترسی داشته باشند و هم اسلایدها را ببینند. مقدار `true` را به [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) اختصاص دهید تا فایل‌های OLE جاسازی‌شده به‌عنوان پیوست در PDF نهایی حفظ شوند.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE بر روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست گنجانده نمی‌شود. تنظیم گزینه به `true` علاوه بر پیش‌نمایش، دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک تصویر بصری است؛ پیوست به گیرندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک کاربرگ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه که قبلاً شامل یک کتاب‌کار Excel جاسازی‌شده است بارگذاری می‌کند و آن را با کتاب‌کار پیوست‌شده به PDF صادر می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

برای بررسی نتیجه:

1. PDF صادرشده را در مرورگری که از پیوست‌های فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. پنل **Attachments** مرورگر را باز کنید و کتاب‌کار جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا اگر مرورگر اجازه دهد مستقیماً باز کنید. پیش‌نمایش بر صفحه PDF جدا از پیوست است.

{{% alert color="info" title="توجه" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 پیوست‌های جاسازی‌شده را ممنوع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را مجاز می‌داند و PDF/A-3 انواع دیگر فایل‌ها از جمله کتاب‌کارهای Excel را اجازه می‌دهد. این موارد الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای پنهان**

اگر یک ارائه شامل اسلایدهای پنهان باشد، می‌توانید از ویژگی [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای پنهان به عنوان صفحات در PDF نهایی گنجانده شوند.

مثال زیر یک ارائه را به PDF صادر می‌کند و هر اسلاید پنهانی را شامل می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF با پسورد**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به پسورد `password` دارد. سطوح دسترسی امکان چاپ، از جمله چاپ با کیفیت بالا، را می‌دهد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تشخیص جایگزینی قلم‌ها**

Aspose.Slides ویژگی [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد در طول فرآیند تبدیل ارائه به PDF، جایگزینی قلم‌ها را تشخیص دهید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. هشدار تنها زمانی چاپ می‌شود که یک قلم ناموجود در زمان صادرات جایگزین شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="توجه" %}}
برای اطلاعات بیشتر درباره جایگزینی قلم، به مقالهٔ [Font Substitution](/slides/fa/net/font-substitution/) مراجعه کنید.
{{% /alert %}} 

### **بررسی قلم‌های بدون نوع‌قلم بولد اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر روی متن اعمال کند حتی زمانی که قلم آن دارای نوع‌قلم بولد اختصاصی نیست. متن می‌تواند از طریق بولد مصنوعی که گلیف‌های عادی را ضخیم می‌کند، بولد نشان داده شود. وقتی این متن در PDF بیش از حد سنگین یا متفاوت از ظاهر مورد نظر به نظر می‌رسد، سعی کنید مقدار [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) را به `true` تنظیم کنید. این گزینه متن تحت تأثیر را به‌صورت بیت‌مپ در زمان صادرات PDF رستر می‌کند و می‌تواند ظاهر آن را برای برخی قلم‌ها بهبود بخشد. مقدار پیش‌فرض `false` است.

ارائه نمونه شامل دو جعبهٔ متن است: یکی با متن عادی و دیگری با قالب‌بندی بولد بر همان قلم که نوع‌قلم بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رستر کردن سبک‌های قلم پشتیبانی‌نشده را فعال می‌سازد و آن را به PDF صادر می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

پیش‌نمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال‌سازی گزینه، خطوط آن نازک‌تر هستند؛ متن عادی بدون تغییر می‌ماند. نتایج را قبل از انتخاب تنظیم برای ارائهٔ خود مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: بدون OCR نمی‌توان آن را انتخاب، کپی یا جستجو کرد و لبه‌های آن در بزرگنمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی همچنان قابل جستجو است. با غیرفعال بودن گزینه، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متن قالب‌بندی‌شده به‌صورت بولد را رستر می‌کند وقتی قلم آن نوع‌قلم بولد اختصاصی ندارد. [Font substitution](/slides/fa/net/font-substitution/) به‌جای آن یک قلم دیگر را وقتی قلم اصلی در دسترس نیست انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره اسلایدها در این آرایه از عدد یک شروع می‌شود و ارائهٔ ورودی باید حداقل شامل سه اسلاید باشد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF با اندازه سفارشی اسلاید**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائهٔ جدید با اندازهٔ اسلاید 612 × 792 پوینت (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید برای جا شدن مقیاس می‌شود و اسلاید تک به PDF صادر می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند به‌طوری که یادداشت‌های سخنران هر اسلاید در زیر اسلاید قرار می‌گیرد. برای دیدن نتیجه، از یک ارائه حاوی یادداشت‌های سخنران استفاده کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما امکان می‌دهد از رویهٔ تبدیل استفاده کنید که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را با هر یک از این استانداردهای انطباق صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C# یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که PDFهای متعدد بر اساس استانداردهای انطباق مختلف تولید می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

{{% alert color="info" title="توجه" %}}
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) و [PDF به PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) و [PDF به XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)— نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر به‌صورت محتوی جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان آثار (artifacts) نشانه‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی شده روی فایل‌هایتان حلقه بزنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان قفل‌گذاری با پسورد بر روی PDF تبدیل‌شده وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) استفاده کنید تا یک پسورد تنظیم کنید و سطوح دسترسی را در طول فرآیند تبدیل تعیین کنید.

**چگونه اسلایدهای پنهان را در PDF شامل کنم؟**

ویژگی [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) را در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) به `true` تنظیم کنید تا اسلایدهای پنهان در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید کیفیت تصویر را با تنظیم ویژگی‌هایی مانند [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشد.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع بیشتر**

- [مستندات Aspose.Slides برای .NET](/slides/fa/net/)
- [مرجع API Aspose.Slides برای .NET](https://reference.aspose.com/slides/net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)