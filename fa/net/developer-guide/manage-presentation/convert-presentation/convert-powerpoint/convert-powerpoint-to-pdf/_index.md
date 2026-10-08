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
- ذخیره PowerPoint به‌صورت PDF
- ذخیره PPT به‌صورت PDF
- ذخیره PPTX به‌صورت PDF
- صادر کردن PPT به PDF
- صادر کردن PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در .NET با استفاده از Aspose.Slides، با مثال‌های کد سریع C# و گزینه‌های پیشرفتهٔ تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT, PPTX, ODP و غیره) به فرمت PDF در C# مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، تعویض فونت‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل‌های PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌های زیر را به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) بدهید و سپس با استفاده از متد [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) ارائه را به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) متد [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) را در اختیار می‌گذارد که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقدار به فرم "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای تولید شده به‌دقت به ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای فراخوانی
* سرصفحه و پانویس
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائهٔ داده‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری کرده و تمام اسلایدهای قابل مشاهده را با تنظیمات پیش‌فرض خروجی به PDF ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose یک **مبدل PowerPoint به PDF** آنلاین رایگان در [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمایش زنده از روش توضیح‌داده‌شده انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌هایی تحت کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF خروجی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوهٔ پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستری، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، تنظیم DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند که کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، متافایل‌ها به صورت PNG ذخیره می‌شوند و فشرده‌سازی متن با Flate اعمال می‌شود.

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

### **حفظ فایل‌های OLE توکار به‌عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک کتاب‌کار Excel توکار باشد، ممکن است بخواهید گیرندگان PDF بتوانند به داده‌های کتاب‌کار دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. برای حفظ فایل‌های OLE توکار به‌عنوان پیوست در PDF خروجی، ویژگی [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) را به `true` تنظیم کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE روی صفحه PDF رندر می‌شود، اما فایل توکار به‌عنوان پیوست گنجانده نمی‌شود. تنظیم این گزینه به `true` علاوه بر پیش‌نمایش، دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری باقی می‌ماند؛ پیوست به گیرندگان اجازه می‌دهد فایل توکار را به‌طور جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک صفحهٔ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که از قبل شامل یک کتاب‌کار Excel توکار است، بارگذاری کرده و آن را به PDF با کتاب‌کار پیوست شده صادر می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

برای بررسی نتیجه:

1. PDF صادرشده را در یک مرورگری باز کنید که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader.
2. پانل **Attachments** مرورگر را باز کنید و کتاب‌کار توکار را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا اگر مرورگر اجازه دهد مستقیماً آن را باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 بارگذاری فایل‌های توکار را ممنوع می‌کند، PDF/A-2 تنها پیوست‌های PDF/A را می‌پذیرد و PDF/A-3 انواع فایل‌های دیگر از جمله کتاب‌کارهای Excel را مجاز می‌داند. این موارد الزامات خود استانداردهاست و نه محدودیت خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از ویژگی [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحات در PDF خروجی گنجانده شوند.

مثال زیر یک ارائه را به PDF صادر می‌کند که اسلایدهای مخفی نیز در آن گنجانده شده‌اند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF با رمز عبور محافظت‌شده**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن آن باید رمز عبور `password` وارد شود. مجوزهای دسترسی چاپ را شامل می‌شود، از جمله چاپ با کیفیت بالا.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides ویژگی [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد در فرآیند تبدیل ارائه به PDF، جایگزینی فونت‌ها را تشخیص دهید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که فونت در دسترس نباشد و در طول خروجی جایگزین شود.

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

{{% alert color="info" title="Note" %}}
برای اطلاعات بیشتر درباره جایگزینی فونت، به مقاله [Font Substitution](/slides/fa/net/font-substitution/) مراجعه کنید.
{{% /alert %}}

### **مدیریت فونت‌ها بدون نوع Bold اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر متن اعمال کند حتی اگر فونت مورد استفاده نوع Bold اختصاصی نداشته باشد. متن می‌تواند از طریق Bold مصنوعی که گلیف‌های عادی را ضخیم می‌کند، برجسته شود. هنگامی که این متن در PDF بسیار سنگین یا متفاوت از ظاهر مطلوب به نظر می‌رسد، سعی کنید ویژگی [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) را به `true` تنظیم کنید. این گزینه متن‌های تحت تأثیر را به‌عنوان بیت‌مپ هنگام خروجی PDF رستر می‌کند و می‌تواند ظاهر آن‌ها را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض `false` است.

ارائه نمونه دو جعبه متن دارد: یکی با متن عادی و دیگری با قالب‌بندی بولد بر همان فونت که نوع Bold اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رستریز کردن سبک‌های پشتیبانی‌نشدهٔ فونت را فعال می‌کند و به PDF صادر می‌نماید:

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

پیش‌نمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال‌سازی گزینه، خطوط آن سبک‌تر می‌شود؛ متن عادی تغییری نمی‌کند. قبل از انتخاب تنظیم برای ارائهٔ خود، نتایج را مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: متن قابل انتخاب، کپی یا جستجو بدون OCR نیست و لبه‌های آن در زوم 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی همچنان قابل جستجو می‌ماند. وقتی گزینه غیرفعال باشد، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متون قالب‌بندی‌شده به‌صورت بولد را وقتی فونت نوع Bold اختصاصی نداشته باشد، رستر می‌کند. در عوض، [Font substitution](/slides/fa/net/font-substitution/) فونت دیگری را هنگام عدم دسترس بودن اصلی انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره اسلایدها در این آرایه بر پایهٔ یک‌نهمی (یک‌پایه) هستند و ارائهٔ ورودی باید حداقل شامل سه اسلاید باشد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF با اندازهٔ سفارشی اسلاید**

مثال زیر اسلاید اول یک ارائه را به ارائه‌ای جدید با اندازهٔ اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید به‌منظور پر شدن مقیاس می‌شود و اسلاید تک‌تایی به PDF صادر می‌گردد.

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

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های سخنران هر اسلاید را زیر اسلاید قرار می‌دهد. برای مشاهده نتیجه، از ارائه‌ای حاوی یادداشت‌های سخنران استفاده کنید.

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

## **استانداردهای دسترسی و انطباق برای PDF**

Aspose.Slides به شما امکان می‌دهد از یک روش تبدیل استفاده کنید که با [راهنمای دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF با هر یک از استانداردهای انطباق زیر صادر کنید: **PDF/A1a**, **PDF/A1b**, و **PDF/UA**.

این کد C# یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که چندین PDF بر پایهٔ استانداردهای انطباق مختلف تولید می‌کند:

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

{{% alert color="info" title="Note" %}}
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های اختصاصی—[PDF به SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—هم نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان Artefacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی به‌سراغ فایل‌ها رفته و فرآیند تبدیل را اجرا کنید.

**آیا امکان حماية PDF خروجی با كلمه‌عبور وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) برای تنظیم کلمه‌عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

ویژگی [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) را در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) به `true` تنظیم کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**

بله، می‌توانید کیفیت تصویر را با تنظیم ویژگی‌هایی مانند [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) کنترل کنید تا تصاویر با کیفیت بالا در PDF شما ذخیره شوند.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و تضمین می‌کند اسناد شما الزامات دسترسی و بایگانی را برآورده کنند.

## **منابع اضافی**

- [Aspose.Slides for .NET Documentation](/slides/fa/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)