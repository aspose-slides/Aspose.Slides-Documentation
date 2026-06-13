---
title: "تبدیل PPT و PPTX به PDF در .NET [ویژگی‌های پیشرفته گنجانده شده]"
linktitle: "PowerPoint به PDF"
type: docs
weight: 40
url: /fa/net/convert-powerpoint-to-pdf/
keywords:
  - "تبدیل PowerPoint"
  - "تبدیل ارائه"
  - "PowerPoint به PDF"
  - "ارائه به PDF"
  - "PPT به PDF"
  - "تبدیل PPT به PDF"
  - "PPTX به PDF"
  - "تبدیل PPTX به PDF"
  - "ذخیره PowerPoint به عنوان PDF"
  - "ذخیره PPT به عنوان PDF"
  - "ذخیره PPTX به عنوان PDF"
  - "صادر کردن PPT به PDF"
  - "صادر کردن PPTX به PDF"
  - PDF/A1a
  - PDF/A1b
  - PDF/UA
  - .NET
  - C#
  - Aspose.Slides
description: "PowerPoint PPT/PPTX را به PDFهای با کیفیت بالا و قابل جستجو در .NET تبدیل کنید با استفاده از Aspose.Slides، همراه با مثال‌های سریع C# و گزینه‌های پیشرفته تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C# مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را گنجانده، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر روی اسناد خروجی اعمال کنید.

## **تبدیل‌های PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) بدهید و سپس ارائه را با استفاده از متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) متد [Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) را در اختیار می‌گذارد که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for .NET اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با «*Aspose.Slides*» و فیلد PDF Producer را با مقداری به شکل «*Aspose.Slides v XX.XX*» پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.
{{% /alert %}}

Aspose.Slides به شما اجازه می‌دهد تبدیل کنید:

* کل ارائه‌ها به PDF
* اسلایدهای خاصی از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFs تولید شده به‌دقت با ارائه‌های اصلی مطابق باشند. عناصر و ویژگی‌ها در حین تبدیل به‌صورت دقیق رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* لینک‌های پیوندی
* سرصفحه‌ها و پاورقی‌ها
* نشانه‌گذاری‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و بالاترین سطح کیفیت به PDF تبدیل کند.

این کد C# نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```c#
// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.ppt");

// ذخیره ارائه به عنوان PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 
Aspose یک [**مبدل آنلاین PowerPoint به PDF**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) رایگان ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمایش زنده انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خواص تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF خروجی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشبرد فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر رستری، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را با چند گزینه سفارشی به PDF تبدیل کنید:

```c#
// نمونه‌سازی کلاس PdfOptions.
var pdfOptions = new PdfOptions
{
    // تنظیم کیفیت برای تصاویر JPG.
    JpegQuality = 90,

    // تنظیم DPI برای تصاویر.
    SufficientResolution = 300,

    // تنظیم رفتار برای متافایل‌ها.
    SaveMetafilesAsPng = true,

    // تنظیم سطح فشرده‌سازی متن برای محتویات متنی.
    TextCompression = PdfTextCompression.Flate,

    // تعریف حالت سازگاری PDF.
    Compliance = PdfCompliance.Pdf15
};

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
using var presentation = new Presentation("PowerPoint.pptx");

// ذخیرهٔ ارائه به‌صورت سند PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF با اسلایدهای پنهان**

اگر ارائه شامل اسلایدهای پنهان باشد، می‌توانید از خاصیت [ShowHiddenSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای پنهان به‌عنوان صفحات در PDF نهایی گنجانده شوند.

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را با اسلایدهای پنهان به PDF تبدیل کنید:

```c#
// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.pptx");

// نمونه‌سازی کلاس PdfOptions.
var pdfOptions = new PdfOptions();

// افزودن اسلایدهای پنهان.
pdfOptions.ShowHiddenSlides = true;

// ذخیرهٔ ارائه به‌صورت PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF محافظت‌شده با رمز عبور**

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را با استفاده از پارامترهای حفاظت در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) به PDF محافظت‌شده با رمز عبور تبدیل کنید:

```c#
// یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را ایجاد می‌کند.
using var presentation = new Presentation("PowerPoint.pptx");

// نمونه‌سازی کلاس PdfOptions.
var pdfOptions = new PdfOptions();

// تنظیم رمز عبور PDF و مجوزهای دسترسی.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// ذخیرهٔ ارائه به‌صورت PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تشخیص جایگزینی قلم‌ها**

Aspose.Slides خاصیت [WarningCallback](https://reference.aspose.com/slides/fa/net/aspose.slides.export/saveoptions/warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد در حین فرآیند تبدیل ارائه به PDF، جایگزینی‌های قلم را تشخیص دهید.

این کد C# نشان می‌دهد چگونه جایگزینی قلم‌ها را تشخیص دهید:

```c#
public static void Main()
{
    // یک شیء از کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است را ایجاد می‌کند.
    using var presentation = new Presentation("sample.pptx");

    // تنظیم فراخوانی هشدار در گزینه‌های PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // ذخیرهٔ ارائه به‌صورت PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// پیاده‌سازی فراخوانی هشدار.
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

{{%  alert color="primary"  %}} 
برای اطلاعات بیشتر درباره دریافت بازخورد برای جایگزینی قلم‌ها در حین رندر، مراجعه کنید به [دریافت هشدارهای بازخورد برای جایگزینی قلم‌ها](/slides/fa/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

برای اطلاعات بیشتر درباره جایگزینی قلم‌ها، مقاله [Font Substitution](/slides/fa/net/font-substitution/) را ببینید.
{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

این کد C# نشان می‌دهد چگونه فقط اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```c#
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
using var presentation = new Presentation("PowerPoint.pptx");

// تنظیم آرایه‌ای از شماره‌های اسلاید.
int[] slides = { 1, 3 };

// ذخیرهٔ ارائه به‌صورت PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را با اندازه اسلاید مشخص به PDF تبدیل کنید:

```c#
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

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد C# نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF تبدیل کنید که شامل یادداشت‌ها باشد:

```c#
// بارگذاری یک ارائه PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configure the PDF options with Notes Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Save the presentation to a PDF with notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک فرآیند تبدیل استفاده کنید که با [دستورالعمل‌های دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید و هر یک از استانداردهای سازگاری زیر را اعمال کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C# یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که PDFs متعددی بر پایه استانداردهای مختلف سازگاری تولید می‌کند:

```c#
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
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و امکان تبدیل فایل‌های PDF به فرمت‌های محبوب را فراهم می‌آورد. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/net/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/fa/net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/net/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/net/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **نکته:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌صورت یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت انبوه به PDF تبدیل کنم؟**  
بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان محافظت از PDF تبدیل‌شده با رمز عبور وجود دارد؟**  
کاملاً امکان‌پذیر است. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی هنگام تبدیل استفاده کنید.

**چگونه اسلایدهای پنهان را در PDF گنجانده کنم؟**  
خاصیت `ShowHiddenSlides` را در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) روی `true` تنظیم کنید تا اسلایدهای پنهان در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا را در PDF حفظ کند؟**  
بله، می‌توانید با تنظیم ویژگی‌هایی مانند `JpegQuality` و `SufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/net/aspose.slides.export/pdfoptions/) کیفیت بالای تصاویر را در PDF خود تضمین کنید.

**آیا Aspose.Slides استانداردهای سازگاری PDF/A را پشتیبانی می‌کند؟**  
بله، Aspose.Slides به شما اجازه می‌دهد PDFs صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترس‌پذیری و آرشیوی را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides for .NET](/slides/fa/net/)
- [مرجع API Aspose.Slides for .NET](https://reference.aspose.com/slides/fa/net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)