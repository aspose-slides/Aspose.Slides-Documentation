---
title: تبدیل PPT و PPTX به PDF در C++ [ویژگی‌های پیشرفته گنجانده شده]
linktitle: PowerPoint به PDF
type: docs
weight: 40
url: /fa/cpp/convert-powerpoint-to-pdf/
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
- صدور PPT به PDF
- صدور PPTX به PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در C++ با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد و گزینه‌های پیشرفتهٔ تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C++ مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ طرح‌بندی و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر اسناد خروجی اعمال کنید.

## **تبدیل‌های PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از متد `Save` به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) متد `Save` را فراهم می‌کند که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides برای C++ اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، فیلد Application با "*Aspose.Slides*" و فیلد PDF Producer با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌شود. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی تغییر یا حذف کنید.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* تبدیل کل ارائه‌ها به PDF
* تبدیل اسلایدهای خاص از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد که PDFهای تولید شده به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها در تبدیل به‌درستی رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاورقی‌ها
* نقطه‌گذاری‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

این کد C++ به شما نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```c++
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// ذخیرهٔ ارائه به عنوان PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 
Aspose یک [مبدل آنلاین رایگان PowerPoint به PDF](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست زنده از روشی که در اینجا توضیح داده شده اجرا کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خواص تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF خروجی را شخصی‌سازی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشروی فرآیند تبدیل را تعیین کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیمات کیفیت مورد نظر خود برای تصاویر raster را تعریف کنید، نحوه‌ٔ پردازش متافایل‌ها را مشخص کنید، سطح فشرده‌سازی متون را تنظیم کنید، DPI تصاویر را پیکربندی کنید و موارد دیگر.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را با چند گزینه سفارشی به PDF تبدیل کنید.

```c++
// نمونه‌سازی کلاس PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تنظیم کیفیت برای تصاویر JPG.
pdfOptions->set_JpegQuality(90);

// تنظیم DPI برای تصاویر.
pdfOptions->set_SufficientResolution(300);

// تنظیم رفتار برای متافایل‌ها.
pdfOptions->set_SaveMetafilesAsPng(true);

// تنظیم سطح فشرده‌سازی متن برای محتوای متنی.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تعریف حالت سازگاری PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// ذخیرهٔ ارائه به عنوان یک سند PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به عنوان صفحات در PDF نهایی گنجانده شوند.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را با اسلایدهای مخفی به PDF تبدیل کنید:

```c++
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// نمونه‌سازی کلاس PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// افزودن اسلایدهای مخفی.
pdfOptions->set_ShowHiddenSlides(true);

// ذخیرهٔ ارائه به عنوان PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تبدیل PowerPoint به PDF با رمز عبور**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF محافظت‌شده با رمز عبور تبدیل کنید با استفاده از پارامترهای حفاظت در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/):

```c++
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// نمونه‌سازی کلاس PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تنظیم رمز عبور PDF و مجوزهای دسترسی.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// ذخیرهٔ ارائه به عنوان PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [set_WarningCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

این کد C++ نشان می‌دهد چگونه جایگزینی فونت‌ها را تشخیص دهید:

```c++
// پیاده‌سازی فراخوانی هشدار.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تنظیم فراخوانی هشدار در گزینه‌های PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // ذخیرهٔ ارائه به عنوان PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 
برای دریافت اطلاعات بیشتر دربارهٔ فراخوانی‌های هشدار برای جایگزینی فونت‌ها در طول رندر، به ‎[دریافت هشدارهای کال‌بک برای جایگزینی فونت‌ها](/slides/fa/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر دربارهٔ جایگزینی فونت، مقاله ‎[جایگزینی فونت](/slides/fa/cpp/font-substitution/) را ببینید.
{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

این کد C++ نشان می‌دهد چگونه فقط اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```C++
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// تنظیم آرایه‌ای از شماره‌های اسلاید.
auto slides = MakeArray<int32_t>({ 1, 3 });

// ذخیرهٔ ارائه به عنوان PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را با اندازهٔ اسلاید مشخص به PDF تبدیل کنید:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF تبدیل کنید که شامل یادداشت‌ها باشد:

```C++
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint یا OpenDocument است.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// پیکربندی گزینه‌های PDF با طرح‌بندی یادداشت‌ها.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیرهٔ ارائه به PDF با یادداشت‌ها.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **استانداردهای دسترس‌پذیری و سازگاری برای PDF**

Aspose.Slides به شما امکان می‌دهد از روشی استفاده کنید که با ‎[راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF صادر کنید و یکی از این استانداردهای سازگاری را اعمال کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C++ یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف سازگاری، چندین PDF متفاوت تولید می‌کند:

```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```

{{% alert title="Note" color="warning" %}} 
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به قالب‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های ‎[PDF به HTML](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-html/)‎، ‎[PDF به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-image/)‎، ‎[PDF به JPG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-jpg/)‎ و ‎[PDF به PNG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-png/)‎ را انجام دهید. سایر عملیات‌های تبدیل PDF به قالب‌های تخصصی—‎[PDF به SVG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-svg/)‎، ‎[PDF به TIFF](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-tiff/)‎ و ‎[PDF به XML](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-xml/)‎—نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **نکته:** هنگام خروجی به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای همچون SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artefact علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌ها پیمایش کنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

قطعا. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی هنگام فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

از متد `set_ShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت تصویر بالا در PDF را حفظ کند؟**

بله، می‌توانید کیفیت تصویر را با استفاده از متدهایی مانند `set_JpegQuality` و `set_SufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) کنترل کنید تا تصاویر با کیفیت بالا در PDF شما داشته باشید.

**آیا Aspose.Slides از استانداردهای سازگاری PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع اضافی**

- [مستندات Aspose.Slides برای C++](/slides/fa/cpp/)
- [مرجع API Aspose.Slides برای C++](https://reference.aspose.com/slides/fa/cpp/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)