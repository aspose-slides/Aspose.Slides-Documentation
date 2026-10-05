---
title: تبدیل PPT و PPTX به PDF در .NET [ویژگی‌های پیشرفته گنجانده شده]
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
- صدور PPT به PDF
- صدور PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در .NET با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد C# و گزینه‌های پیشرفتهٔ تبدیل."
---
## **مرور کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C# چندین مزیت دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [کلاس Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) ارسال کنید و سپس ارائه را با استفاده از متد [متد Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) به PDF ذخیره کنید. کلاس [کلاس Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) متد [متد Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) را که معمولاً برای تبدیل ارائه به PDF استفاده می‌شود، در اختیار می‌گذارد.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای .NET اطلاعات API و شماره نسخه خود را در اسناد خروجی وارد می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقدار به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید تا این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* تمام ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای حاصل به‌دقت با ارائه‌های اصلی مطابقت دارند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پاورقی
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با استفاده از تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با استفاده از تنظیمات پیش‌فرض خروجی به PDF ذخیره می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمون اجرا کنید تا پیاده‌سازی زندهٔ روشی که در اینجا توصیف شده است، را ببینید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خصوصیاتی تحت کلاس [کلاس PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF حاصل را شخصی‌سازی کنید، PDF را با رمز عبور قفل کنید، یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت مطلوب خود برای تصاویر رستری را تعریف کنید، نحوهٔ مدیریت متافایل‌ها را مشخص کنید، سطح فشرده‌سازی متن را تنظیم کنید، DPI تصاویر را پیکربندی کنید و موارد دیگر.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند که کیفیت JPEG به 90 تنظیم شده، وضوح تصویر به 300 DPI، متافایل‌ها به‌صورت PNG ذخیره شده‌اند و فشرده‌سازی متن به‌صورت Flate اعمال شده است.

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

اگر یک ارائه شامل یک کاربرگ Excel توکار باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کاربرگ دسترسی داشته باشند و همزمان اسلایدها را ببینند. برای حفظ فایل‌های OLE توکار به‌عنوان پیوست‌ها در PDF حاصل، خاصیت [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) را روی `true` تنظیم کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE بر روی صفحه PDF رندر می‌شود، اما فایل توکار آن به‌عنوان پیوست گنجانده نمی‌شود. تنظیم گزینه به `true` علاوه بر این داده‌های فایل را شامل می‌شود. پیش‌نمایش به‌عنوان نمایش بصری باقی می‌ماند؛ پیوست به دریافت‌کنندگان اجازه می‌دهد تا فایل توکار را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک کاربرگ Excel تعاملی بر روی صفحه PDF نمی‌شود.

مثال زیر یک ارائه را بارگذاری می‌کند که قبلاً یک کاربرگ Excel توکار دارد و آن را به PDF با پیوست کاربرگ صادر می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

1. PDF صادر شده را در یک مشاهده‌گر که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader، باز کنید.  
2. پنل **پیوست‌ها** مشاهده‌گر را باز کنید و کاربرگ توکار را پیدا کنید.  
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر مشاهده‌گر اجازه می‌دهد به‌طور مستقیم باز کنید. پیش‌نمایش بر روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 فایل‌های توکار را ممنوع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد، و PDF/A-3 انواع دیگر فایل‌ها از جمله کاربرگ‌های Excel را اجازه می‌دهد. این‌ها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از خاصیت [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحات در PDF حاصل شامل کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هر اسلاید مخفی را شامل می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF با محافظت توسط رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. سطوح دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **شناسایی جایگزینی‌های فونت**

Aspose.Slides خاصیت [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) ارائه می‌دهد که به شما امکان شناسایی جایگزینی‌های فونت در طول فرآیند تبدیل ارائه به PDF را می‌دهد.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را به کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که یک فونت در دسترس نباشد و در هنگام خروجی جایگزین شود.

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
برای اطلاعات بیشتر درباره جایگزینی فونت، مقالهٔ [جایگزینی فونت](/slides/fa/net/font-substitution/) را ببینید.
{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلایدها در این آرایه از یک شروع می‌شوند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائه جدید با اندازهٔ اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای پر شدن مقیاس می‌کند و اسلاید تک را به PDF صادر می‌نماید.

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

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های گویندهٔ هر اسلاید را زیر اسلاید قرار می‌دهد. برای مشاهده نتیجه، از یک ارائه حاوی یادداشت‌های گوینده استفاده کنید.

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

## **استانداردهای دسترس‌پذیری و انطباق برای PDF**

Aspose.Slides به شما امکان می‌دهد یک فرآیند تبدیل که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) هم‌خوانی داشته باشد استفاده کنید. می‌توانید یک سند PowerPoint را به PDF صادر کنید با استفاده از هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C# فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف انطباق، چندین PDF تولید می‌کند:

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
Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) و [PDF به PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) و [PDF به XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان اشیای زائد علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **سؤالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**  
بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید از طریق فایل‌های خود پیمایش کنید و فرآیند تبدیل را به‌صورت برنامه‌نویسی اعمال کنید.

**آیا امکان محافظت با رمز عبور برای PDF تبدیل‌شده وجود دارد؟**  
بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف سطوح دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF شامل کنم؟**  
خاصیت [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) را در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) روی `true` تنظیم کنید تا اسلایدهای مخفی در PDF حاصل شامل شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**  
بله، می‌توانید با تنظیم خصوصیت‌هایی مانند [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما حفظ شوند.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**  
بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با استانداردهای مختلفی از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای .NET](/slides/fa/net/)
- [مرجع API Aspose.Slides برای .NET](https://reference.aspose.com/slides/net/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)