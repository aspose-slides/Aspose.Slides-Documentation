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
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در .NET با استفاده از Aspose.Slides، با نمونه‌های سریع کد C# و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C# مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه‌تان. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را گنجانید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بدهید و سپس ارائه را با استفاده از متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides برای .NET اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** اینکه نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* تمام ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDF‌های تولید شده به شدت با ارائه‌های اصلی مطابقت دارند. عناصر و ویژگی‌ها به‌دقت در تبدیل رندر می‌شوند، شامل:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پانویس‌ها
* نقطه‌گذاری‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

این کد C# نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شی از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.ppt");

// ارائه را به عنوان PDF ذخیره می‌کند.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose یک [**تبدیل‌کننده PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) رایگان آنلاین ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست زنده از روش توصیف‌شده در اینجا اجرا کنید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیاتی تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF نهایی را شخصی‌سازی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشبرد فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستر، روش پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تعریف کنید.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را با چندین گزینه سفارشی به PDF تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شی از کلاس PdfOptions ایجاد می‌کند.
var pdfOptions = new PdfOptions
{
    // کیفیت تصاویر JPG را تنظیم می‌کند.
    JpegQuality = 90,

    // DPI تصاویر را تنظیم می‌کند.
    SufficientResolution = 300,

    // رفتار متافایل‌ها را تنظیم می‌کند.
    SaveMetafilesAsPng = true,

    // سطح فشرده‌سازی متن برای محتوای متنی را تنظیم می‌کند.
    TextCompression = PdfTextCompression.Flate,

    // حالت انطباق PDF را تعریف می‌کند.
    Compliance = PdfCompliance.Pdf15
};

// یک شی از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است، ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.pptx");

// ارائه را به عنوان یک سند PDF ذخیره می‌کند.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید از ویژگی [ShowHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به‌عنوان صفحه در PDF نهایی گنجانده شوند.

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را با گنجاندن اسلایدهای مخفی به PDF تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شی از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.pptx");

// یک شی از کلاس PdfOptions ایجاد می‌کند.
var pdfOptions = new PdfOptions();

// اسلایدهای مخفی را اضافه می‌کند.
pdfOptions.ShowHiddenSlides = true;

// ارائه را به عنوان PDF ذخیره می‌کند.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF با رمز عبور**

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را با استفاده از پارامترهای محافظت موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) به PDF با رمز عبور تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شی از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.pptx");

// یک شی از کلاس PdfOptions ایجاد می‌کند.
var pdfOptions = new PdfOptions();

// یک رمز عبور PDF و مجوزهای دسترسی را تنظیم می‌کند.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// ارائه را به عنوان PDF ذخیره می‌کند.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تشخیص جایگزینی فونت**

Aspose.Slides ویژگی [WarningCallback](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) فراهم می‌کند تا بتوانید در طول فرآیند تبدیل ارائه به PDF، جایگزینی فونت‌ها را شناسایی کنید.

این کد C# نشان می‌دهد چگونه جایگزینی فونت‌ها را تشخیص دهید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // یک شی از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است ایجاد می‌کند. 
    using var presentation = new Presentation("sample.pptx");

    // Callback هشدار را در گزینه‌های PDF تنظیم می‌کند.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // ارائه را به عنوان PDF ذخیره می‌کند.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// پیاده‌سازی Callback هشدار.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="info"  %}} 

برای اطلاعات بیشتر درباره دریافت Callback‌های هشدار برای جایگزینی فونت‌ها در فرآیند رندر، به [دریافت Callback‌های هشدار برای جایگزینی فونت‌ها](/slides/fa/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر درباره جایگزینی فونت، به مقاله [جایگزینی فونت](/slides/fa/net/font-substitution/) نگاه کنید.

{{% /alert %}} 

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

این کد C# نشان می‌دهد چگونه فقط اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک شی از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.pptx");

// آرایه‌ای از شماره اسلایدها را تنظیم می‌کند.
int[] slides = { 1, 3 };

// ارائه را به عنوان PDF ذخیره می‌کند.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را با اندازه اسلاید مشخص به PDF تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);

// Save the resized presentation as a PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF که شامل یادداشت‌هاست تبدیل کنید:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک ارائه PowerPoint را بارگذاری می‌کند.
using var presentation = new Presentation("NotesFile.pptx");

// گزینه‌های PDF را با چیدمان یادداشت‌ها پیکربندی می‌کند.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// ارائه را به یک PDF با یادداشت‌ها ذخیره می‌کند.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **استانداردهای دسترسی و سازگاری برای PDF**

Aspose.Slides به شما امکان می‌دهد از یک روش تبدیل که با [راهنمای دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار است استفاده کنید. می‌توانید یک سند PowerPoint را به PDF صادر کنید با هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C# یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف انطباق چندین PDF تولید می‌کند:

```c#
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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/net/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/net/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/net/conversion/pdf-to-xml/)—هم پشتیبانی می‌شوند.

{{% /alert %}}

> **Note:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر به‌صورت محتواهای جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سوالات متداول**

### آیا می‌توانم چندین فایل PowerPoint را به صورت انبوه به PDF تبدیل کنم؟

بله، Aspose.Slides از تبدیل دسته‌جمعی چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال کنید.

### آیا امکان قفل کردن PDF تبدیل‌شده با رمز عبور وجود دارد؟

کاملاً امکان‌پذیر است. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

### چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟

ویژگی `ShowHiddenSlides` را در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) به مقدار `true` تنظیم کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

### آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟

بله، می‌توانید با تنظیم ویژگی‌هایی مانند `JpegQuality` و `SufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) کیفیت تصویر را در PDF خود کنترل کنید.

### آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با استانداردهای مختلفی از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترسی و بایگانی را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای .NET](/slides/fa/net/)
- [مرجع API Aspose.Slides برای .NET](https://reference.aspose.com/slides/fa/net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)