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
description: "تبدیل PowerPoint PPT/PPTX به PDFهای با کیفیت بالا و قابل جستجو در C++ با استفاده از Aspose.Slides، همراه با مثال‌های کد سریع و گزینه‌های پیشرفته تبدیل."
---
## **نمای کلی**

تبدیل ارائه‌های PowerPoint (PPT، PPTX، ODP و غیره) به فرمت PDF در C++ مزایای متعددی دارد، از جمله سازگاری با دستگاه‌های مختلف و حفظ چیدمان و قالب‌بندی ارائه شما. این راهنما نشان می‌دهد چگونه ارائه‌ها را به اسناد PDF تبدیل کنید، از گزینه‌های مختلف برای کنترل کیفیت تصویر استفاده کنید، اسلایدهای پنهان را شامل کنید، فایل‌های PDF را با رمز عبور محافظت کنید، جایگزینی فونت‌ها را شناسایی کنید، اسلایدهای خاصی را برای تبدیل انتخاب کنید و استانداردهای انطباق را بر اسناد خروجی اعمال کنید.

## **تبدیل PowerPoint به PDF**

با استفاده از Aspose.Slides، می‌توانید ارائه‌ها را در فرمت‌های زیر به PDF تبدیل کنید:

* **PPT**
* **PPTX**
* **ODP**

برای تبدیل یک ارائه به PDF، نام فایل را به عنوان آرگومان به کلاس [ارائه](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ارسال کنید و سپس با استفاده از متد [ذخیره](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) ارائه را به PDF ذخیره کنید. کلاس [ارائه](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) متد [ذخیره](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) را که معمولاً برای تبدیل یک ارائه به PDF استفاده می‌شود، افشا می‌کند.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای C++ اطلاعات API و شماره نسخه خود را به اسناد خروجی وارد می‌کند. به عنوان مثال، هنگام تبدیل یک ارائه به PDF، Aspose.Slides فیلد Application را با "*Aspose.Slides*" و فیلد PDF Producer را با مقداری به شکل "*Aspose.Slides v XX.XX*" پر می‌کند. **توجه** داشته باشید که نمی‌توانید Aspose.Slides را مجبور کنید این اطلاعات را در اسناد خروجی تغییر یا حذف کند.
{{% /alert %}}

Aspose.Slides به شما امکان تبدیل را می‌دهد:

* کل ارائه‌ها به PDF
* اسلایدهای خاص از یک ارائه به PDF

Aspose.Slides ارائه‌ها را به PDF صادر می‌کند و اطمینان می‌دهد PDFهای ایجاد شده به‌دقت با ارائه‌های اصلی مطابقت داشته باشند. عناصر و ویژگی‌ها به‌درستی در تبدیل رندر می‌شوند، از جمله:

* تصاویر
* جعبه‌های متن و شکل‌ها
* قالب‌بندی متن
* قالب‌بندی پاراگراف
* پیوندها
* سرصفحه‌ها و پاورقی‌ها
* نقاط
* جداول

## **تبدیل PowerPoint به PDF**

فرآیند استاندارد تبدیل PowerPoint به PDF از گزینه‌های پیش‌فرض استفاده می‌کند. در این حالت، Aspose.Slides سعی می‌کند ارائه ارائه‌شده را به PDF تبدیل کند با تنظیمات بهینه و با حداکثر سطوح کیفیت.

مثال زیر یک ارائه را بارگذاری می‌کند و تمام اسلایدهای قابل مشاهده را با استفاده از تنظیمات پیش‌فرض صادرات به PDF ذخیره می‌کند.

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
Aspose یک مبدل آنلاین رایگان [**مبدل PowerPoint به PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) ارائه می‌دهد که فرآیند تبدیل ارائه به PDF را نشان می‌دهد. می‌توانید با این مبدل یک تست برای اجرای زنده‌ی روش شرح داده‌شده انجام دهید.
{{% /alert %}}

## **تبدیل PowerPoint به PDF با گزینه‌ها**

Aspose.Slides گزینه‌های سفارشی—ویژگی‌های تحت کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—را فراهم می‌کند که به شما امکان سفارشی‌سازی PDF حاصل، قفل کردن PDF با رمز عبور، یا تعیین نحوه پیشرفت فرآیند تبدیل را می‌دهند.

### **تبدیل PowerPoint به PDF با گزینه‌های سفارشی**

با استفاده از گزینه‌های تبدیل سفارشی، می‌توانید تنظیم کیفیت مورد نظر خود برای تصاویر رستر، نحوه مدیریت متافایل‌ها، سطح فشرده‌سازی متن، پیکسل‌درگیری (DPI) تصویر و موارد دیگر را تعریف کنید.

مثال زیر یک ارائه را به PDF 1.5 صادر می‌کند با کیفیت JPEG برابر 90، وضوح تصویر 300 DPI، متافایل‌ها به صورت PNG ذخیره می‌شوند و فشرده‌سازی متن Flate اعمال می‌شود.

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

### **انتخاب خودکار فشرده‌سازی تصویر**

وقتی یک ارائه شامل تعداد زیادی عکس یا اسکرین‌شات باشد، کاهش اندازه PDF صادر شده می‌تواند ارسال ایمیل یا دانلود را آسان‌تر کند. برای انتخاب خودکار مناسب‌ترین الگوریتم فشرده‌سازی برای هر تصویر در حین صادرات PDF، متد [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) را با مقدار `true` فراخوانی کنید.

مثال زیر یک ارائه موجود را بارگذاری می‌کند، انتخاب خودکار فشرده‌سازی تصویر را فعال می‌سازد و آن را به عنوان سند PDF ذخیره می‌کند. تمام تنظیمات دیگر صادرات PDF مقدار پیش‌فرض خود را حفظ می‌کنند.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

این گزینه برای هر تصویر الگوریتم فشرده‌سازی را انتخاب می‌کند. کاهش کیفیت JPEG با استفاده از [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) به‌جای آن کیفیت تصویر JPEG را کاهش می‌دهد، در حالی که کاهش وضوح با [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) اجازه می‌دهد تصاویر به رزولوشن پایین‌تری پایین‌نمونه‌گیری شوند که می‌تواند جزئیات را کاهش دهد. فعال‌سازی انتخاب خودکار فشرده‌سازی خود به خود هیچ‌یک از این تنظیمات را کاهش نمی‌دهد.

انتخاب الگوریتم‌های فشرده‌سازی تصویر نیاز به زمان پردازش و حافظه بیشتری دارد. میزان کاهش اندازه به تصاویر ارائه و تنظیمات صادرات بستگی دارد؛ کاهش ثابت برای هر ارائه تضمین نمی‌شود.

### **حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست‌های PDF**

اگر یک ارائه شامل یک کاربرگ Excel جاسازی‌شده باشد، ممکن است بخواهید گیرندگان PDF به داده‌های کاربرگ دسترسی داشته باشند و همچنین اسلایدها را مشاهده کنند. برای حفظ فایل‌های OLE جاسازی‌شده به‌عنوان پیوست در PDF حاصل، متد [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) را با مقدار `true` فراخوانی کنید.

مقدار پیش‌فرض `false` است: تصویر یا آیکون پیش‌نمایش شی OLE بر روی صفحه PDF رندر می‌شود، اما فایل جاسازی‌شده به‌عنوان پیوست شامل نمی‌شود. تنظیم گزینه به `true` علاوه بر این داده‌های فایل را نیز شامل می‌شود. پیش‌نمایش همچنان نمای بصری باقی می‌ماند؛ پیوست به گیرندگان اجازه می‌دهد فایل جاسازی‌شده را به‌صورت جداگانه باز یا ذخیره کنند. شی OLE تبدیل به یک کاربرگ Excel تعاملی در صفحه PDF نمی‌شود.

مثال زیر یک ارائه که قبلاً شامل یک کاربرگ Excel جاسازی‌شده است را بارگذاری می‌کند و آن را به PDF با پیوست کردن کاربرگ صادر می‌کند:

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

1. PDF صادر شده را در یک نمایشگر که از پیوست‌های فایل پشتیبانی می‌کند، مانند Adobe Acrobat Reader باز کنید.
2. پنل **پیوست‌ها** نمایشگر را باز کنید و کاربرگ جاسازی‌شده را پیدا کنید.
3. پیوست را ذخیره کنید و در Excel باز کنید تا داده‌های آن را بررسی کنید، یا اگر نمایشگر اجازه دهد مستقیم باز کنید. پیش‌نمایش روی صفحه PDF جدا از پیوست است.

{{% alert color="info" title="Note" %}}
استانداردهای PDF/A محدودیت‌هایی بر پیوست‌ها اعمال می‌کنند: PDF/A-1 بارگذاری فایل‌های جاسازی‌شده را ممنوع می‌کند، PDF/A-2 فقط اجازه پیوست‌های PDF/A را می‌دهد، و PDF/A-3 انواع دیگر فایل‌ها از جمله کاربرگ‌های Excel را اجازه می‌دهد. اینها الزامات استانداردها هستند، نه محدودیت‌های خاص Aspose.Slides. این مثال از تنظیم پیش‌فرض انطباق PDF استفاده می‌کند و صادرات PDF/A را نشان نمی‌دهد.
{{% /alert %}}

### **تبدیل PowerPoint به PDF با اسلایدهای پنهان**

اگر یک ارائه شامل اسلایدهای پنهان باشد، می‌توانید از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای پنهان را به‌عنوان صفحات در PDF حاصل شامل کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هر اسلاید پنهانی را شامل می‌شود.

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

### **تبدیل PowerPoint به PDF دارای رمز عبور**

مثال زیر یک ارائه را به PDF صادر می‌کند که برای باز کردن نیاز به رمز عبور `password` دارد. مجوزهای دسترسی چاپ را، از جمله چاپ با کیفیت بالا، اجازه می‌دهند.

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

### **تشخیص جایگزینی فونت‌ها**

Aspose.Slides متد [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) را در زیر کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) فراهم می‌کند تا بتوانید جایگزینی فونت‌ها را در طول فرآیند تبدیل ارائه به PDF شناسایی کنید.

مثال زیر یک ارائه را به PDF صادر می‌کند و هشدارهای جایگزینی فونت را در کنسول چاپ می‌کند. هشدار فقط زمانی چاپ می‌شود که فونتی در دسترس نباشد و در طول صادرات جایگزین شود.

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
برای اطلاعات بیشتر درباره جایگزینی فونت، مقالهٔ [جایگزینی فونت](/slides/fa/cpp/font-substitution/) را ببینید.
{{% /alert %}} 

### **مدیریت فونت‌های بدون نوع Bold اختصاصی**

یک ارائه می‌تواند قالب‌بندی Bold را بر متن اعمال کند حتی اگر فونت آن نوع Bold اختصاصی نداشته باشد. متن همچنان می‌تواند به‌صورت Bold مصنوعی ظاهر شود که به‌صورت مصنوعی گلیف‌های عادی را ضخیم می‌کند. وقتی این متن بیش از حد سنگین به‌نظر برسد یا از ظاهر موردنظر در PDF متفاوت باشد، سعی کنید با فراخوانی [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) مقدار `true` را تنظیم کنید. این گزینه متن تاثیر‌دیده را به‌صورت bitmap در طول صادرات PDF رندر می‌کند و می‌تواند ظاهر آن را برای برخی فونت‌ها بهبود بخشد. مقدار پیش‌فرض آن `false` است.

ارائه نمونه شامل دو جعبه متن است: یکی با متن عادی و دیگری با قالب‌بندی Bold اعمال شده بر همان فونت که نوع Bold اختصاصی ندارند. مثال زیر ارائه را بارگذاری می‌کند، rasterization سبک‌های فونت پشتیبانی‌نشده را فعال می‌سازد و آن را به PDF صادر می‌کند:

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

پیشنمایش‌های زیر خروجی غیرفعال و فعال گزینه را نشان می‌دهند. در این مثال، متن Bold با گزینه غیرفعال دارای خطوط ضخیم‌تری است. با فعال شدن گزینه، خطوط آن سبک‌تر می‌شوند؛ متن عادی تغییر نمی‌کند. نتایج را قبل از انتخاب تنظیم برای ارائه خود مقایسه کنید.

| گزینه غیرفعال (`false`، پیش‌فرض) | گزینه فعال (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

در این مثال، فعال‌سازی گزینه فقط متن Bold را به bitmap تبدیل می‌کند: نمی‌توان آن را بدون OCR انتخاب، کپی یا جستجو کرد و لبه‌های آن در بزرگ‌نمایی 800٪ نرم‌تر به‌نظر می‌رسند. متن عادی قابل جستجو باقی می‌ماند. با گزینه غیرفعال، هر دو رشته به‌عنوان متن باقی می‌مانند.

این گزینه متن قالب‌بندی شده به صورت bold را rasterize می‌کند وقتی فونت آن نوع Bold اختصاصی ندارد. [جایگزینی فونت](/slides/fa/cpp/font-substitution/) به‌جای آن یک فونت دیگر را زمانی که فونت اصلی در دسترس نیست انتخاب می‌کند.

## **تبدیل اسلایدهای انتخابی از PowerPoint به PDF**

مثال زیر اسلایدهای 1 و 3 را از یک ارائه به PDF صادر می‌کند. شماره‌های اسلاید در این آرایه از یک شروع می‌شود و ارائه ورودی باید حداقل سه اسلاید داشته باشد.

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

مثال زیر اولین اسلاید را از یک ارائه به یک ارائه جدید کپی می‌کند با اندازه اسلاید 612 × 792 پوینت (8.5 × 11 اینچ). محتویات اسلاید را به‌منظور سازگاری مقیاس می‌دهد و اسلاید تک را به PDF صادر می‌کند.

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

// اسلاید خالی را که ارائه جدید با آن ایجاد شده بود حذف کنید.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **تبدیل PowerPoint به PDF در نمای اسلایدهای یادداشت**

مثال زیر یک ارائه را به PDF صادر می‌کند و یادداشت‌های سخنران هر اسلاید را زیر اسلاید قرار می‌دهد. برای دیدن نتیجه، از یک ارائه حاوی یادداشت‌های سخنران استفاده کنید.

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

## **دسترس‌پذیری و استانداردهای انطباق برای PDF**

Aspose.Slides به شما اجازه می‌دهد از یک روش تبدیل که با [راهنمای دسترس‌پذیری محتوای وب (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) سازگار باشد استفاده کنید. می‌توانید یک سند PowerPoint را به PDF صادر کنید با استفاده از هر یک از این استانداردهای انطباق: **PDF/A1a**، **PDF/A1b** و **PDF/UA**.

این کد C++ یک فرآیند تبدیل PowerPoint به PDF را نشان می‌دهد که بر اساس استانداردهای انطباق مختلف، چندین PDF تولید می‌کند:

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
Aspose.Slides عملیات‌های تبدیل PDF را پشتیبانی می‌کند و به شما امکان می‌دهد فایل‌های PDF را به فرمت‌های محبوب تبدیل کنید. می‌توانید تبدیلات [PDF به HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/)، [PDF به تصویر](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/)، [PDF به JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/)، و [PDF به PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) را انجام دهید. عملیات‌های تبدیل PDF به فرمت‌های تخصصی—[PDF به SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/)، [PDF به TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/)، و [PDF به XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)— نیز پشتیبانی می‌شوند.
{{% /alert %}}

> **توجه:** هنگام صادرات به PDF/UA، Aspose.Slides گرافیک‌های پیچیده مانند SmartArt، نمودارها و فرمول‌ها را به‌عنوان یک شکل واحد در نظر می‌گیرد. المان‌های مسیر جداگانه به‌عنوان محتوای مستقل حفظ نمی‌شوند و ممکن است به‌عنوان artifacts علامت‌گذاری شوند؛ متن جایگزین فقط برای کل شکل ارائه می‌شود.

## **پرسش‌های متداول**

**آیا می‌توانم چندین فایل PowerPoint را به صورت دسته‌جمعی به PDF تبدیل کنم؟**

بله، Aspose.Slides از تبدیل دسته‌ای چندین فایل PPT یا PPTX به PDF پشتیبانی می‌کند. می‌توانید با استفاده از حلقه، فایل‌های خود را پردازش کرده و فرآیند تبدیل را برنامه‌نویسی کنید.

**آیا امکان محافظت از PDF تبدیل‌شده با رمز عبور وجود دارد؟**

بله. از کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) برای تنظیم رمز عبور و تعریف مجوزهای دسترسی در طول فرآیند تبدیل استفاده کنید.

**چگونه می‌توانم اسلایدهای مخفی را در PDF گنجانده کنم؟**

از متد [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) استفاده کنید تا اسلایدهای مخفی را در PDF حاصل گنجانده شود.

**آیا Aspose.Slides می‌تواند کیفیت بالای تصویر را در PDF حفظ کند؟**

بله، می‌توانید با استفاده از متدهایی مانند [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) و [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) در کلاس [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) کیفیت تصویر را کنترل کنید تا تصاویر با کیفیت بالا در PDF شما تضمین شوند.

**آیا Aspose.Slides از استانداردهای انطباق PDF/A پشتیبانی می‌کند؟**

بله، Aspose.Slides به شما امکان می‌دهد PDFهایی صادر کنید که با استانداردهای مختلف از جمله PDF/A1a، PDF/A1b و PDF/UA سازگار باشند و اطمینان حاصل کنید اسناد شما الزامات دسترس‌پذیری و بایگانی را برآورده می‌کنند.

## **منابع بیشتر**

- [مستندات Aspose.Slides for C++](/slides/fa/cpp/)
- [مرجع API Aspose.Slides for C++](https://reference.aspose.com/slides/cpp/)
- [مبدل‌های آنلاین رایگان Aspose](https://products.aspose.app/slides/conversion)