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
- صادرات PPT به PDF
- صادرات PPTX به PDF
- پیوست
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX را به PDFهای با کیفیت بالا و قابل جستجو در C++ با استفاده از Aspose.Slides تبدیل کنید، همراه با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **بررسی کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C++ مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای مخفی را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی قلم‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای سازگاری را بر روی اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) پاس دهید و سپس ارائه را با استفاده از متد [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) به صورت PDF ذخیره کنید. کلاس [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) متد [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) را در اختیار می‌گذارد که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود.

{{% alert color="info" title="Note" %}}

Aspose.Slides برای C++ اطلاعات API و شماره نسخه خود را در اسناد خروجی درج می‌کند. برای مثال، هنگام تبدیل یک ارائه به PDF، فیلد Application با "*Aspose.Slides*" و فیلد PDF Producer با مقدار به شکل "*Aspose.Slides v XX.XX*" پر می‌شود. **Note** اینکه نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.

{{% /alert %}}

Aspose.Slides به شما امکان می‌دهد:

* کل ارائه‌ها را به PDF تبدیل کنید
* اسلایدهای خاصی از یک ارائه را به PDF تبدیل کنید

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای تولید شده به‌دقت با ارائه‌های اصلی مطابقت دارند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و اشکال
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه و پاورقی
* گلوله‌ها
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را با تنظیمات بهینه و در بالاترین سطوح کیفیت به PDF تبدیل کند.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با تنظیمات پیش‌فرض خروجی به PDF ذخیره می‌کند.

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

Aspose یک مبدل آنلاین رایگان [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک آزمایش برای پیاده‌سازی زندهٔ فرآیند توضیح داده شده در اینجا انجام دهید.

{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—خواص موجود در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما امکان می‌دهد PDF نهایی را سفارشی کنید، PDF را با رمز عبور قفل کنید یا مشخص کنید فرآیند تبدیل چگونه پیش برود.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های سفارشی تبدیل، می‌توانید تنظیم کیفیت مطلوب خود را برای تصاویر رستر، نحوهٔ پردازش متافایل‌ها، سطح فشرده‌سازی متن، DPI تصاویر و موارد دیگر تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند به‌طوری که کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، متافایل‌ها به صورت PNG ذخیره شده و فشرده‌سازی متن Flate اعمال می‌شود.

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

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست PDF**

اگر یک ارائه شامل یک کاربرگ Excel جاسازی‌شده باشد، ممکن است بخواهید دریافت‌کنندگان PDF به داده‌های کاربرگ دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. با فراخوانی متد [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) با مقدار `true` می‌توانید فایل‌های OLE جاسازی‌شده را به‌عنوان پیوست در PDF نتیجه حفظ کنید.

مقدار پیش‌فرض `false` است: تصویر پیش‌نمایش یا آیکون شی OLE روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست گنجانده نمی‌شود. تنظیم این گزینه به `true` علاوه بر آن دادهٔ فایل را نیز شامل می‌شود. پیش‌نمایش همچنان یک نمایش بصری است؛ پیوست به دریافت‌کنندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شی OLE تبدیل به یک کاربرگ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه که قبلاً شامل یک کاربرگ Excel جاسازی‌شده است بارگذاری می‌کند و آن را با کاربرگ به‌عنوان پیوست به PDF صادر می‌کند.

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

1. PDF صادرشده را در یک مشاهده‌گری که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader، باز کنید.
2. پنل **Attachments** (پیوست‌ها) را در مشاهده‌گر باز کنید و کاربرگ جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کرده و در Excel باز کنید تا داده‌ها را بررسی کنید، یا مستقیماً اگر مشاهده‌گر اجازه دهد باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}

استانداردهای PDF/A محدودیت‌هایی برای پیوست‌ها اعمال می‌کنند: PDF/A-1 از فایل‌های جاسازی‌شده منع می‌کند، PDF/A-2 فقط پیوست‌های PDF/A را اجازه می‌دهد و PDF/A-3 انواع دیگر فایل‌ها از جمله کاربرگ‌های Excel را مجاز می‌کند. این‌ها نیازهای استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض سازگاری PDF استفاده می‌کند و صادرات PDF/A را نشان نمی‌دهد.

{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای مخفی**

اگر یک ارائه شامل اسلایدهای مخفی باشد، می‌توانید از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) از کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) برای گنجاندن اسلایدهای مخفی به‌عنوان صفحات در PDF خروجی استفاده کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند که شامل تمام اسلایدهای مخفی نیز می‌شود.

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

### **تبدیل PowerPoint به PDF با حفاظت با رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن به رمز عبور `password` نیاز دارد. مجوزهای دسترسی اجازه چاپ، از جمله چاپ با کیفیت بالا، را می‌دهند.

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

### **شناسایی جایگزینی قلم‌ها**

Aspose.Slides متد [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) را تحت کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) فراهم می‌کند که به شما امکان می‌دهد جایگزینی قلم‌ها را در طی فرآیند تبدیل ارائه به PDF شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی قلم را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که قلمی در دسترس نباشد و در حین صادرات جایگزین شود.

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

برای اطلاعات بیشتر درباره جایگزینی قلم، مقالهٔ [Font Substitution](/slides/fa/cpp/font-substitution/) را ببینید.

{{% /alert %}} 

### **دست‌کاری قلم‌هایی بدون قالب بولد اختصاصی**

یک ارائه می‌تواند فرمت بولد را بر روی متن اعمال کند حتی اگر قلم آن قالب بولد اختصاصی نداشته باشد. متن می‌تواند همچنان به‌صورت بولد ظاهر شود از طریق بولد مصنوعی که گلیف‌های معمولی را به‌طور مصنوعی ضخیم می‌کند. وقتی این متن بیش از حد سنگین به‌نظر می‌رسد یا از ظاهر موردنظر در PDF متفاوت است، سعی کنید با فراخوانی [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) مقدار `true` را تنظیم کنید. این گزینه متن تحت تأثیر را به‌عنوان بیت‌مپ در هنگام صادرات PDF رندر می‌کند و می‌تواند ظاهر آن را برای برخی قلم‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائه نمونه شامل دو جعبه متن است: یکی با متن عادی و دیگری با فرمت بولد اعمال شده بر همان قلم که قالب بولد اختصاصی ندارد. مثال زیر ارائه را بارگذاری می‌کند، رستر کردن سبک‌های قلم پشتیبانی‌نشده را فعال می‌سازد و آن را به PDF صادر می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

پیش‌نمایش‌های زیر خروجی غیرفعال و فعال را نشان می‌دهند. در این مثال، متن بولد با گزینه غیرفعال خطوط سنگین‌تری دارد. با فعال کردن گزینه، خطوط آن سبک‌تر می‌شود؛ متن عادی بدون تغییر می‌ماند. نتایج را قبل از انتخاب تنظیم برای ارائهٔ خود مقایسه کنید.

| گزینه غیرفعال (`false`, پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن بولد را به بیت‌مپ تبدیل می‌کند: بدون OCR نمی‌توان آن را انتخاب، کپی یا جستجو کرد و لبه‌های آن در بزرگ‌نمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی قابل جستجو می‌ماند. با گزینه غیرفعال، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متن‌های قالب بولد را رستر می‌کند زمانی که قلم آن قالب بولد اختصاصی ندارد. جایگزینی قلم ([Font substitution](/slides/fa/cpp/font-substitution/)) به‌جای آن قلم دیگری را وقتی قلم اصلی موجود نیست، انتخاب می‌کند.

## **تبدیل اسلایدهای انتخاب‌شده از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شناسه‌های اسلاید در این آرایه از یک شروع می‌شوند و ارائهٔ ورودی باید حداقل سه اسلاید داشته باشد.

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

## **تبدیل PowerPoint به PDF با اندازهٔ اسلاید سفارشی**

مثال زیر اولین اسلاید را از یک ارائه به یک ارائهٔ جدید با اندازهٔ اسلاید 612 × 792 نقطه (8.5 × 11 اینچ) کپی می‌کند. محتویات اسلاید را برای تناسب مقیاس می‌دهد و اسلاید منفرد را به PDF صادر می‌کند.

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

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت‌ها**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های گوینده هر اسلاید را زیر اسلاید قرار می‌دهد. برای مشاهده نتیجه، از ارائه‌ای حاوی یادداشت‌های گوینده استفاده کنید.

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

## **دسترس‌پذیری و استانداردهای سازگاری برای PDF**

Aspose.Slides به شما اجازه می‌دهد از فرآیند تبدیل استفاده کنید که با [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد. می‌توانید سند PowerPoint را به PDF با هر یک از این استانداردهای سازگاری صادر کنید: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C++ یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که PDFهای متعدد بر اساس استانداردهای مختلف سازگاری تولید می‌کند:

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

Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما اجازه می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیل‌های [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) را انجام دهید. سایر عملیات‌های تبدیل PDF به قالب‌های تخصصی—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)— نیز پشتیبانی می‌شوند.

{{% /alert %}}

> **Note:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. عناصر مسیر به‌صورت محتواهای جداگانه حفظ نمی‌شوند و ممکن است به‌عنوان Artefacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل فراهم می‌شود.

## **سوالات متداول**

**آیا می‌توانم چندین فایل PowerPoint را به‌صورت دسته‌ای به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید به‌صورت برنامه‌نویسی بر روی فایل‌های خود تکرار کنید و فرآیند تبدیل را اعمال کنید.

**آیا امکان دارد PDF تبدیل‌شده را با رمز عبور محافظت کنم؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی هنگام فرآیند تبدیل استفاده کنید.

**چگونه اسلایدهای مخفی را در PDF گنجانده کنم؟**

از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) برای گنجاندن اسلایدهای مخفی در PDF خروجی استفاده کنید.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید کیفیت تصویر را با استفاده از متدهایی مانند [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) و [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) کنترل کنید تا تصاویر با کیفیت بالا در PDF شما باشند.

**آیا Aspose.Slides استانداردهای سازگاری PDF/A را پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی را صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما نیازهای دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع بیشتر**

- [Aspose.Slides for C++ Documentation](/slides/fa/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)