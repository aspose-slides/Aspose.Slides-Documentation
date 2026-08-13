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
description: "PowerPoint PPT/PPTX را به PDFهای با کیفیت بالا و قابل جستجو در C++ با استفاده از Aspose.Slides تبدیل کنید، با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C++ مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر روی اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از متد `Save` به PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) متد `Save` را فراهم می‌کند که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. به‌عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را از اسناد خروجی حذف یا تغییر دهد.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و تضمین می‌کند PDFهای تولید شده به‌دقت مشابه ارائه‌های اصلی باشند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندهای هیپرلینک
* سرآیند و پابرگ
* گلوله‌ها
* جدول‌ها

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در حداکثر سطوح کیفیت به PDF تبدیل کند.

این کد C++ نشان می‌دهد چگونه یک ارائه (PPT، PPTX، ODP و غیره) را به PDF تبدیل کنید:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 

Aspose یک **مبدل آنلاین رایگان PowerPoint به PDF**[**here**](https://products.aspose.app/slides/fa/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست انجام دهید و اجرای زندهٔ روشی که در اینجا توضیح داده شده را ببینید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌هایی تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF تولید شده را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی می‌توانید تنظیم کیفیت دلخواه برای تصاویر نقطه‌ای، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر را تعریف کنید.

مثال کد زیر نشان می‌دهد چگونه یک ارائه PowerPoint را با چندین گزینه سفارشی به PDF تبدیل کنید.

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ایجاد شیء از کلاس PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تنظیم کیفیت برای تصاویر JPG.
pdfOptions->set_JpegQuality(90);

// تنظیم DPI برای تصاویر.
pdfOptions->set_SufficientResolution(300);

// تنظیم رفتار برای متافایل‌ها.
pdfOptions->set_SaveMetafilesAsPng(true);

// تنظیم سطح فشرده‌سازی متن برای محتوای متنی.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// تعریف حالت انطباق PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// ایجاد شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// ذخیرهٔ ارائه به‌صورت سند PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی به عنوان صفحات در PDF نهایی گنجانده شوند.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را با اسلایدهای مخفی به PDF تبدیل کنید:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ایجاد شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// ایجاد شیء از کلاس PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// افزودن اسلایدهای مخفی.
pdfOptions->set_ShowHiddenSlides(true);

// ذخیرهٔ ارائه به‌صورت PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تبدیل PowerPoint به PDF با رمز عبور**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را با استفاده از پارامترهای حفاظت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) به PDF دارای رمز عبور تبدیل کنید:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ایجاد شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// ایجاد شیء از کلاس PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// تنظیم رمز عبور PDF و مجوزهای دسترسی.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// ذخیرهٔ ارائه به‌صورت PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [set_WarningCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/set_warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد در طول فرآیند تبدیل ارائه به PDF، جایگزینی فونت‌ها را شناسایی کنید.

این کد C++ نشان می‌دهد چگونه جایگزینی فونت‌ها را تشخیص دهید:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

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
    // ایجاد شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // تنظیم فراخوانی هشدار در گزینه‌های PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // ذخیرهٔ ارائه به‌صورت PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 

برای اطلاعات بیشتر درباره دریافت Callback برای جایگزینی فونت‌ها در حین رندر، به مقاله [Getting Warning Callbacks for Fonts Substitution](/slides/fa/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) مراجعه کنید.

برای اطلاعات بیشتر درباره جایگزینی فونت، مقاله [Font Substitution](/slides/fa/cpp/font-substitution/) را ببینید.

{{% /alert %}} 

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

این کد C++ نشان می‌دهد چگونه فقط اسلایدهای خاصی از یک ارائه PowerPoint را به PDF تبدیل کنید:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ایجاد شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// تنظیم آرایه‌ای از شماره اسلایدها.
auto slides = MakeArray<int32_t>({ 1, 3 });

// ذخیرهٔ ارائه به‌صورت PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را با اندازهٔ اسلاید مشخص به PDF تبدیل کنید:

```C++
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

// ایجاد شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// ایجاد یک ارائه جدید با اندازه اسلاید تنظیم‌شده.
auto resizedPresentation = MakeObject<Presentation>();

// تنظیم اندازه سفارشی اسلاید.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// کلون (کپی) اولین اسلاید از ارائه اصلی.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// ذخیرهٔ ارائهٔ تغییر اندازه‌داده‌شده به‌صورت PDF همراه با یادداشت‌ها.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PDF که شامل یادداشت‌ها است تبدیل کنید:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// ایجاد شیء از کلاس Presentation که یک فایل PowerPoint یا OpenDocument را نشان می‌دهد.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// پیکربندی گزینه‌های PDF با چیدمان یادداشت‌ها.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// ذخیرهٔ ارائه به‌صورت PDF همراه با یادداشت‌ها.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما امکان می‌دهد از یک فرآیند تبدیل استفاده کنید که با [دستورالعمل‌های دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید یک سند PowerPoint را به PDF با هر یک از این استانداردهای انطباق صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C++ یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای مختلف انطباق، چندین PDF تولید می‌کند:

```C++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Aspose.Slides عملیات تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-png/) را انجام دهید. سایر عملیات تبدیل PDF به فرمت‌های خاص—[PDF به SVG](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/fa/cpp/conversion/pdf-to-xml/)—هم پشتیبانی می‌شوند.

{{% /alert %}}

> **توجه:** هنگام استخراج به PDF/UA، Aspose.Slides گرافیک‌های پیچیده‌ای مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوا نگهداری نمی‌شوند و ممکن است به‌عنوان Artefact علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل ارائه می‌شود.

## **سوالات متداول**

### آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌ای به PDF تبدیل کنم؟

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌هایتان تکرار کنید و فرآیند تبدیل را اعمال کنید.

### آیا امکان گذاشتن رمز عبور برای PDF تبدیل‌شده وجود دارد؟

کاملاً امکان‌پذیر است. از کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف دسترسی‌ها در طول فرآیند تبدیل استفاده کنید.

### چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟

از متد `set_ShowHiddenSlides` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

### آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟

بله، می‌توانید با استفاده از متدهایی مانند `set_JpegQuality` و `set_SufficientResolution` در کلاس [PdfOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pdfoptions/) کیفیت تصویر را در PDF حفظ کنید.

### آیا Aspose.Slides استانداردهای انطباق PDF/A را پشتیبانی می‌کند؟

بله، Aspose.Slides به شما اجازه می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و تضمین می‌کند اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده کنند.

## **منابع تکمیلی**

- [مستندات Aspose.Slides for C++](/slides/fa/cpp/)
- [مرجع API Aspose.Slides for C++](https://reference.aspose.com/slides/fa/cpp/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/fa/conversion)