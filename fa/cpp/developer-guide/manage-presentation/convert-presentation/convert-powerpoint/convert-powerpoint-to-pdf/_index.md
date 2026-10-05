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
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در C++ با استفاده از Aspose.Slides، همراه با مثال‌های سریع کد و گزینه‌های پیشرفته تبدیل.
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C++ مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چینش و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، با گزینه‌های مختلف کیفیت تصویر را کنترل کنید، اسلایدهای مخفی را گنجانده، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را تشخیص دهید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل‌های PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در قالب‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [ارائه](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) پاس بدهید و سپس ارائه را با استفاده از متد [ذخیره](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) به PDF ذخیره کنید. کلاس [ارائه](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) متد [ذخیره](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) را فراهم می‌کند که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای C++ اطلاعات API و شماره نسخه خود را به اسناد خروجی اضافه می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقدار به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **نکته** این است که نمی‌توانید Aspose.Slides را وادار کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF
* اسلایدهای خاصی از یک ارائه را به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و مطمئن می‌شود PDFهای تولید شده به‌طور دقیق با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاصفحه‌ها
* نقطه‌گذاری‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و همه اسلایدهای قابل مشاهده را با تنظیمات پیش‌فرض خروجی به PDF ذخیره می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose یک [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) رایگان آنلاین ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید برای اجرای زنده این فرآیند، این مبدل را تست کنید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌هایی تحت کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما اجازه می‌دهد PDF نهایی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا نحوه پیشرفت فرآیند تبدیل را مشخص کنید.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های تبدیل سفارشی می‌توانید تنظیم کیفیت دلخواه خود برای تصاویر رستر، نحوه پردازش متافایل‌ها، سطح فشرده‌سازی متن، تنظیم DPI برای تصاویر و موارد دیگر را تعریف کنید.

مثال زیر ارائه‌ای را با کیفیت JPEG 90، وضوح تصویر 300 DPI، متافایل‌ها را به PNG ذخیره کرده و فشرده‌سازی متن Flate به PDF 1.5 صادر می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست‌های PDF**

اگر ارائه شامل یک ورک‌بوک Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های آن دسترسی داشته باشند و همزمان اسلایدها را ببینند. با فراخوانی [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) با مقدار `true` می‌توانید فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF نهایی حفظ کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شیء OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم این گزینه به `true` علاوه بر پیش‌نمایش، دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش صرفاً یک نمایش بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شیء OLE تبدیل به یک ورک‌شیٹ تعاملی Excel در صفحه PDF نمی‌شود.

مثال زیر ارائه‌ای را که از پیش شامل یک ورک‌بوک Excel جاسازی‌شده است بارگذاری می‌کند و آن را با پیوست ورک‌بوک صادر می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

برای بررسی نتیجه:

1. PDF صادر شده را در یک مرورگری که از پیوست‌های فایل پشتیبانی می‌کند (مانند Adobe Acrobat Reader) باز کنید.
2. پانل **Attachments** مرورگر را باز کنید و ورک‌بوک جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌ها را بررسی کنید، یا در صورتی که مرورگر اجازه دهد مستقیماً باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 فایل‌های جاسازی‌شده را ممنوع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد و PDF/A-3 انواع دیگر فایل‌ها از جمله ورک‌بوک‌های Excel را مجاز می‌کند. این الزام‌های استاندارد هستند و محدودیتی خاص برای Aspose.Slides نیستند. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و خروجی PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را به‌عنوان صفحه در PDF نهایی گنجانید.

مثال زیر ارائه‌ای را با شامل کردن تمام اسلایدهای مخفی به PDF صادر می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **تبدیل PowerPoint به PDF محافظت‌شده با رمز عبور**

مثال زیر ارائه‌ای را به PDF صادر می‌کند که برای باز کردن به رمز عبور `password` نیاز دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **تشخیص جایگزینی قلم‌ها**

Aspose.Slides متد [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) ارائه می‌کند که به شما امکان می‌دهد در طول فرآیند تبدیل ارائه به PDF، جایگزینی قلم‌ها را تشخیص دهید.

مثال زیر ارائه‌ای را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. هشدار تنها زمانی چاپ می‌شود که قلمی در دسترس نباشد و در زمان خروجی جایگزین شود.

```cpp
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

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
برای اطلاعات بیشتر در مورد جایگزینی قلم، مقاله [جایگزینی قلم](/slides/fa/cpp/font-substitution/) را ببینید.
{{% /alert %}} 

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 یک ارائه را به PDF صادر می‌کند. شماره اسلایدها در این آرایه یک‌پایه هستند و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **تبدیل PowerPoint به PDF با اندازه اسلاید سفارشی**

مثال زیر اولین اسلاید را از یک ارائه به ارائه‌ای جدید با اندازه اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای قرارگیری مقیاس می‌کند و اسلاید تک را به PDF صادر می‌نماید.

```cpp
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

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تبدیل PowerPoint به PDF در نمای اسلاید یادداشت‌ها**

مثال زیر ارائه‌ای را به PDF صادر می‌کند به‌طوری که یادداشت‌های گوینده هر اسلاید در زیر اسلاید قرار می‌گیرد. برای مشاهده نتیجه، از یک ارائه شامل یادداشت گوینده استفاده کنید.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **استانداردهای دسترس‌پذیری و انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک فرآیند تبدیل استفاده کنید که با [راهنمای دسترسی به محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید سند PowerPoint را با هر یک از این استانداردهای انطباق به PDF صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C++ فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای انطباق مختلف PDFهای متعددی تولید می‌کند:

```cpp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به قالب‌های محبوب دیگر تبدیل کنید. می‌توانید تبدیل‌های [PDF به HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF به image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) را انجام دهید. سایر تبدیل‌های PDF به قالب‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—نیز پشتیبانی می‌شود.
{{% /alert %}}

> **نکته:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین تنها برای کل شکل فراهم می‌شود.

## **سؤالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت گروهی به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌ای بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال کنید.

**آیا می‌توان PDF تبدیل‌شده را با رمز عبور محافظت کرد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟**

از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی در PDF نهایی گنجانده شوند.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) و [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما قرار گیرند.

**آیا Aspose.Slides از استانداردهای انطباق PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با استانداردهای مختلفی از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده می‌سازند.

## **منابع افزودنی**

- [مستندات Aspose.Slides for C++](/slides/fa/cpp/)
- [مرجع API Aspose.Slides for C++](https://reference.aspose.com/slides/cpp/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)