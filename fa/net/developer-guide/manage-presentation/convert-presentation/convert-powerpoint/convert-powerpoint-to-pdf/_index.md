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
- ذخیره PowerPoint به عنوان PDF
- ذخیره PPT به عنوان PDF
- ذخیره PPTX به عنوان PDF
- صادرات PPT به PDF
- صادرات PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در .NET با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد C# و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT, PPTX, ODP و غیره) به فرمت PDF در C# چندین مزیت دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) پاس می‌دهید و سپس ارائه را با استفاده از متد [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) به PDF ذخیره می‌کنید. کلاس [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) متد [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) را ارائه می‌دهد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای .NET اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **Note** اینکه نمی‌توانید Aspose.Slides را به تغییر یا حذف این اطلاعات از اسناد خروجی راهنمایی کنید.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد تبدیل کنید:

* تمام ارائه‌ها به PDF
* اسلایدهای خاص از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای حاصل به‌دقت مشابه ارائه‌های اصلی باشند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای فراگیر
* سربرگ و پاورقی
* نقطه‌های گلوله‌ای
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را به PDF تبدیل کند با استفاده از تنظیمات بهینه در بالاترین سطوح کیفیت.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با استفاده از تنظیمات پیش‌فرض صادرات به PDF ذخیره می‌نماید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمون برای اجرای زنده روش‌ توضیح داده شده انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های زیر کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF حاصل را سفارشی کنید، PDF را با رمز عبور قفل کنید، یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت مورد نظر برای تصاویر رستر را تعریف کنید، نحوهٔ پردازش متافایل‌ها را مشخص کنید، سطح فشرده‌سازی متن را تنظیم کنید، DPI تصاویر را پیکربندی کنید و موارد دیگر.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند با کیفیت JPEG تنظیم‌شده به 90، وضوح تصویر تنظیم‌شده به 300 DPI، متافایل‌ها ذخیره‌شده به شکل PNG و فشرده‌سازی متن Flate.

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

**Note:** می‌توانید کیفیت رندر کردن سایه متن و اثرات انعکاس را هنگام تبدیل به PDF با تنظیم `PdfOptions.SufficientResolution` به مقدار بالاتر (مثلاً `300`) بهبود دهید. این کار خروجی PDF را که بیشتر با ظاهر در Microsoft PowerPoint مطابقت دارد، تولید می‌کند.

### **انتخاب خودکار فشرده‌سازی تصویر**

هنگامی که یک ارائه شامل تعداد زیادی عکس یا اسکرین‌شات باشد، کاهش حجم PDF صادرشده می‌تواند ارسال ایمیل یا دانلود را آسان‌تر کند. برای انتخاب خودکار مناسب‌ترین الگوریتم فشرده‌سازی برای هر تصویر در طول صادرات PDF، [PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) را به `true` تنظیم کنید.

مثال زیر یک ارائه موجود را بارگذاری می‌کند، انتخاب خودکار فشرده‌سازی تصویر را فعال می‌سازد و آن را به یک سند PDF ذخیره می‌کند. تمام تنظیمات دیگر صادرات PDF مقادیر پیش‌فرض خود را حفظ می‌کنند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

این گزینه برای هر تصویر یک الگوریتم فشرده‌سازی انتخاب می‌کند. کاهش [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) به جای آن کیفیت تصویر JPEG را کاهش می‌دهد، در حالی که کاهش [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) اجازه می‌دهد تصاویر به وضوح کمتری پایین‌نمونه‌گیری شوند که می‌تواند جزئیات را کاهش دهد. فعال کردن انتخاب خودکار فشرده‌سازی خود به خود هیچ‌یک از این تنظیمات را کاهش نمی‌دهد.

انتخاب الگوریتم‌های فشرده‌سازی تصویر زمان پردازش و حافظه بیشتری می‌طلبد. کاهش حجم بستگی به تصاویر ارائه و تنظیمات صادرات دارد؛ کاهش ثابت برای هر ارائه تضمین نمی‌شود.

### **حفظ فایل‌های OLE توکار به عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک ورکبوک Excel توکار باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های ورکبوک دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. برای حفظ فایل‌های OLE توکار به عنوان پیوست‌ها در PDF حاصل، [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) را به `true` تنظیم کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE روی صفحه PDF رندر می‌شود، اما فایل توکار آن به عنوان پیوست گنجانده نمی‌شود. تنظیم گزینه به `true` علاوه بر این داده‌های فایل را شامل می‌شود. پیش‌نمایش به عنوان یک نمایش بصری باقی می‌ماند؛ پیوست به دریافت‌کنندگان امکان می‌دهد فایل توکار را جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک کاربرگ تعاملی Excel در صفحه PDF نمی‌شود.

مثال زیر یک ارائه را که قبلاً شامل یک ورکبوک Excel توکار است بارگذاری می‌کند و آن را به PDF با پیوست ورکبوک صادر می‌نماید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

برای بررسی نتیجه:

1. PDF صادرشده را در یک نمایشگر که پشتیبانی از پیوست‌های فایل را دارد، مانند Adobe Acrobat Reader باز کنید.
2. پنل **Attachments** نمایشگر را باز کنید و ورکبوک توکار را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر نمایشگر اجازه دهد مستقیماً باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی بر پیوست‌ها اعمال می‌کنند: PDF/A-1 فایل‌های توکار را ممنوع می‌کند، PDF/A-2 فقط اجازه پیوست‌های PDF/A را می‌دهد، و PDF/A-3 انواع دیگر فایل‌ها از جمله ورکبوک‌های Excel را مجاز می‌شمارد. این‌ها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و صادرات PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه اسلایدهای مخفی داشته باشد، می‌توانید از ویژگی [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحات در PDF حاصل گنجانده شود.

مثال زیر یک ارائه را به PDF صادر می‌کند و هر اسلاید مخفی را شامل می‌شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **تبدیل PowerPoint به PDF با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

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

Aspose.Slides ویژگی [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. یک هشدار فقط زمانی چاپ می‌شود که یک فونت ناموجود در طول صادرات جایگزین شود.

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
برای اطلاعات بیشتر درباره جایگزینی فونت، مقالهٔ [Font Substitution](/slides/fa/net/font-substitution/) را ببینید.
{{% /alert %}}

### **مدیریت فونت‌ها بدون نوع قلم بولد اختصاصی**

یک ارائه می‌تواند قالب‌بندی بولد را بر متن اعمال کند حتی اگر فونت آن نوع قلم بولد اختصاصی نداشته باشد. متن می‌تواند از طریق بولد مصنوعی که به‌طور مصنوعی گلیف‌های معمولی را ضخیم می‌کند، همچنان بولد به نظر برسد. وقتی این متن بیش از حد سنگین یا متفاوت از ظاهر مورد نظر در PDF باشد، سعی کنید [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) را به `true` تنظیم کنید. این گزینه متن تحت‌تاثیر را به‌عنوان بیت‌مپ در طول صادرات PDF رندر می‌کند و می‌تواند ظاهر آن را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائه نمونه شامل دو جعبه متن است: یکی با متن معمولی و دیگری با قالب‌بندی بولد اعمال‌شده روی همان فونت که نوع قلم بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، rasterization سبک‌های فونت پشتیبانی‌نشده را فعال می‌کند و آن را به PDF صادر می‌نماید:

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

پیشنمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال شدن گزینه، خطوط آن سبک‌تر هستند؛ متن معمولی بدون تغییر می‌ماند. نتایج را قبل از انتخاب تنظیم برای ارائه خود مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: آن را نمی‌توان بدون OCR انتخاب، کپی یا به‌عنوان متن جستجو کرد و لبه‌های آن در بزرگنمایی 800٪ نرم‌تر به نظر می‌رسند. متن معمولی همچنان جستجوپذیر می‌ماند. با غیرفعال بودن گزینه، هر دو رشته به‌صورت متن باقی می‌مانند.

این گزینه متن قالب‌بندی شده به‌عنوان بولد را وقتی فونت آن نوع قلم بولد اختصاصی ندارد، به بیت‌مپ تبدیل می‌کند. [Font substitution](/slides/fa/net/font-substitution/) به‌جای آن فونتی دیگر را وقتی فونت اصلی در دسترس نیست، انتخاب می‌کند.

## **تبدیل اسلایدهای منتخب از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه به‌صورت یک‌پایه هستند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **تبدیل PowerPoint به PDF با اندازه سفارشی اسلاید**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائه جدید با اندازه اسلاید 612 × 792 پوینت (8.5 × 11 اینچ) کپی می‌کند. محتوای اسلاید را مقیاس می‌دهد تا متناسب باشد و اسلاید تک را به PDF صادر می‌کند.

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

## **تبدیل PowerPoint به PDF در حالت نمایش اسلایدهای یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های سخنران هر اسلاید را زیر اسلاید قرار می‌دهد. برای مشاهده نتیجه، از یک ارائه شامل یادداشت‌های سخنران استفاده کنید.

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

Aspose.Slides به شما امکان می‌دهد از یک روش تبدیل که با [راهنمای دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار است استفاده کنید. می‌توانید یک سند PowerPoint را به PDF صادر کنید با استفاده از هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C# فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که PDFهای متعدد را بر اساس استانداردهای انطباق مختلف تولید می‌کند:

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
می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/net/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/) و [PDF به PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/) و [PDF به XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—همچنین پشتیبانی می‌شوند.
{{% /alert %}}

**Note:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان آثار (artifacts) علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **سؤالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال نمایید.

**آیا امکان قفل‌گذاری با رمز عبور بر روی PDF تبدیل‌شده وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) استفاده کنید تا رمز عبور تنظیم کنید و مجوزهای دسترسی را در طول فرآیند تبدیل تعریف نمایید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF وارد کنم؟**

ویژگی [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) را در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) به `true` تنظیم کنید تا اسلایدهای مخفی در PDF حاصل گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با تنظیم ویژگی‌هایی مانند [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) و [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما داشته باشید.

**آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار هستند و اطمینان می‌دهد اسناد شما الزامات دسترسی و بایگانی را برآورده کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای .NET](/slides/fa/net/)
- [مستندات API Aspose.Slides برای .NET](https://reference.aspose.com/slides/net/)
- [مبدل‌های رایگان آنلاین Aspose](https://products.aspose.app/slides/conversion)

Related feature: [صادر کردن ارائه‌ها به PDF](/slides/fa/features/pdf-export/).