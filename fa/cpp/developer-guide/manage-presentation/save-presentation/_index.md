---
title: ذخیرهٔ ارائه‌ها در C++
linktitle: ذخیرهٔ ارائه
type: docs
weight: 80
url: /fa/cpp/save-presentation/
keywords:
- ذخیره PowerPoint
- ذخیره OpenDocument
- ذخیره ارائه
- ذخیره اسلاید
- ذخیره PPT
- ذخیره PPTX
- ذخیره ODP
- ارائه به فایل
- ارائه به جریان
- نوع نمای از پیش تعریف‌شده
- فرمت Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر کوچک
- پیشرفت ذخیره
- C++
- Aspose.Slides
description: "ذخیرهٔ ارائه‌های PowerPoint و OpenDocument به‌صورت فایل یا جریان در C++ با Aspose.Slides و پیکربندی خروجی PPTX و گزارش پیشرفت."
---
## **Overview**

پس از ایجاد یک ارائه یا [باز کردن یک ارائه موجود](/slides/fa/cpp/open-presentation/)، از متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) برای نوشتن نتیجه استفاده کنید. Aspose.Slides برای C++ می‌تواند یک ارائه را به صورت فایل یا جریان در فرمت‌های PowerPoint، OpenDocument، PDF و سایر فرمت‌ها ذخیره کند. بخش‌های زیر عملیات ذخیره استاندارد و گزینه‌های موجود برای خروجی PPTX را پوشش می‌دهند.

## **Save Presentations to Files**

برای ذخیره یک ارائه در فایل، مسیر خروجی و مقدار یک [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) را به متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) پاس دهید. مقدار فرمت تعیین‌کننده نوع فایل‌ای است که Aspose.Slides ایجاد می‌کند.

مثال زیر یک ارائه ایجاد می‌کند و آن را به صورت فایل PPTX ذخیره می‌نماید:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// محتوای ارائه را اینجا اضافه یا تغییر دهید.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Save Presentations in Their Original Format**

برای مثال‌های تشخیص فایل و جریان، رفتار ارائه‌های تازه‌ساخته‌شده و تمایز بین فرمت منبع و خروجی، به صفحه [Determine the Original Presentation Format](/slides/fa/cpp/detect-presentation-source-format/) مراجعه کنید.

در یک برنامه‌ی پردازش دسته‌ای، ممکن است فرمت ورودی از پیش شناخته‌شده نباشد. پس از بارگذاری یک فایل، فرمت اصلی آن را با [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sourceformat/) بخوانید. مقدار [SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sourceformat/) به‌دست‌آمده را به [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/tosaveformat/) پاس دهید تا مقدار متناظر [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) را دریافت کنید، سپس با [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) ارائه‌ی اصلاح‌شده را بنویسید.

مثال کامل زیر هر فایل در یک پوشه ورودی را پردازش می‌کند، عنوان آن را به‌روزرسانی می‌کند و در فرمت بارگذاری‌شده به پوشه خروجی ذخیره می‌نماید:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.util/slideutil/tosaveformat/) فرمت‌های PPT، PPTX، ODP، PPTM، PPSX، PPSM، POTX، POTM، PPS، POT، OTP، FODP و PowerPoint XML را به فرمت‌های ذخیره‌سازی متناظرشان نگاشت می‌کند. این متد فقط فرمت‌های منبع ارائه را نگاشت می‌کند؛ برای انتخاب فرمت‌های خروجی مانند PDF، HTML، TIFF یا تصاویر در نظر گرفته نشده است. پاس کردن یک مقدار [SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sourceformat/) پشتیبانی‑نشده یا نامعتبر منجر به بروز یک [ArgumentException](https://reference.aspose.com/slides/fa/cpp/system/argumentexception/) می‌شود.

فایل‌های legacy PPT، PPS و POT از یک مخزن باینری یکسان استفاده می‌کنند. وقتی چنین ارائه‌ای از یک جریان بدون پسوند فایل بارگذاری شود، ممکن است یک فایل PPS یا POT به‌عنوان PPT شناسایی شود. اگر نیاز به حفظ این زیرنوع‌های legacy باشد، نام فایل یا فرادادهٔ فرمت اصلی را به‌صورت جداگانه نگه داشته و هنگام انتخاب نام و فرمت فایل خروجی از آن استفاده کنید.

## **Save Presentations to Streams**

برای نوشتن یک ارائه بدون وابستگی به مسیر فایل نهایی، یک [Stream](https://reference.aspose.com/slides/fa/cpp/system.io/stream/) قابل نوشتن و یک مقدار [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) را به متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) پاس دهید. این روش زمانی مفید است که خروجی باید از یک سرویس وب بازگردانده شود، در پایگاه داده ذخیره گردد یا در حافظه پردازش شود.

مثال زیر یک ارائهٔ جدید را در یک جریان فایل ذخیره می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Save Presentations with a Predefined View Type**

می‌توانید نمایی که PowerPoint هنگام باز کردن اولیهٔ یک ارائه ذخیره‌شده استفاده می‌کند، مشخص کنید. قبل از ذخیره، با متد [ViewProperties::set_LastView](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/set_lastview/) مقدار یک [ViewType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewtype/) را تنظیم کنید.

مثال زیر نمای Slide Master را به‌عنوان نمای اولیه تنظیم می‌کند:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Save Presentations in the Strict Office Open XML Format**

برای ایجاد یک فایل PPTX که با نمایهٔ Strict از Office Open XML سازگار باشد، یک نمونه از [PptxOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/) ایجاد کنید و با متد [PptxOptions::set_Conformance](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/set_conformance/) مقدار `Conformance::Iso29500_2008_Strict` را تنظیم کنید. سپس این گزینه‌ها را به متد [Presentation::Save](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/save/) پاس دهید.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Save Presentations in Office Open XML Format in Zip64 Mode**

یک آرچیو ZIP استاندارد اندازه فشرده‌شده و غیر فشرده هر ورودی، اندازه کلی آرچیو و تعداد ورودی‌ها را محدود می‌کند. از آنجایی که یک فایل PPTX یک آرچیو ZIP است، یک ارائهٔ بسیار بزرگ می‌تواند این محدودیت‌ها را نقض کند. افزونه‌های Zip64 این محدودیت‌ها را افزایش می‌دهند.

از [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) برای کنترل نوشتن افزونه‌های Zip64 استفاده کنید:

- `IfNecessary` فقط زمانی Zip64 را به کار می‌گیرد که ارائه از محدودیت‌های ZIP استاندارد فراتر رود. این حالت پیش‌فرض است.
- `Never` افزونه‌های Zip64 را غیرفعال می‌کند.
- `Always` همیشه افزونه‌های Zip64 را می‌نویسد.

مثال زیر همیشه برای ارائهٔ خروجی افزونه‌های Zip64 را فعال می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
اگر `Zip64Mode` روی `Never` تنظیم شود و ارائه نتواند در محدودیت‌های ZIP استاندارد جای بگیرد، عملیات ذخیره یک [PptxException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxexception/) را پرتاب می‌کند.
{{% /alert %}}

## **Save Presentations in Office Open XML Format with Compression Levels**

برای خروجی PPTX می‌توانید با فراخوانی [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) سرعت ذخیره را در مقابل اندازهٔ فایل متعادل کنید. شمارش‌گر [CompressionLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/compressionlevel/) این مقادیر را ارائه می‌دهد:

- `None` داده‌ها را بدون فشرده‌سازی ذخیره می‌کند.
- `Level1` سریع‌ترین فشرده‌سازی را ارائه می‌دهد و بزرگ‌ترین خروجی فشرده را تولید می‌کند.
- `Level2` تا `Level5` به‌تدریج خروجی کوچکتر را با سرعت ذخیره‌ی کمتر ترجیح می‌دهند.
- `Level6` تعادل بین سرعت ذخیره و اندازهٔ فایل را برقرار می‌کند. این سطح پیش‌فرض است.
- `Level7` و `Level8` بیشتر خروجی کوچک‌تر را نسبت به سرعت ذخیره ترجیح می‌دهند.
- `Level9` قوی‌ترین فشرده‌سازی را ارائه می‌دهد و بیش‌ترین زمان پردازش را می‌طلبد.

مثال زیر یک ارائه را بدون فشرده‌سازی ذخیره می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

مثال زیر از حداکثر سطح فشرده‌سازی استفاده می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Save Presentations without Refreshing the Thumbnail**

زمانی که یک ارائه به صورت PPTX ذخیره می‌شود، متد [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) نمای تصویر کوچک (thumbnail) سند را کنترل می‌کند:

- `true` در هنگام ذخیره تصویر کوچک را بازسازی می‌کند. این مقدار پیش‌فرض است.
- `false` تصویر کوچک موجود را حفظ می‌کند. اگر ارائه تصویر کوچک نداشته باشد، Aspose.Slides هیچ تصویر کوچکی تولید نمی‌کند.

مثال زیر یک ارائه را بدون به‌روزرسانی تصویر کوچک ذخیره می‌کند:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
غیرفعال‌سازی به‌روزرسانی تصویر کوچک می‌تواند زمان مورد نیاز برای ذخیرهٔ یک فایل PPTX را کاهش دهد.
{{% /alert %}}

## **Save Progress Updates in Percentage**

برای مانیتورینگ عملیات ذخیره، واسط [IProgressCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprogresscallback/) را پیاده‌سازی کنید و پیاده‌سازی را به [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isaveoptions/set_progresscallback/) پاس دهید. سپس Aspose.Slides در طول خروجی‌گیری، متد [IProgressCallback::Reporting](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprogresscallback/reporting/) را با مقادیر پیشرفت فراخوانی می‌کند.

مثال زیر پیشرفت خروجی PDF را در کنسول گزارش می‌دهد:

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose یک برنامهٔ رایگان [PowerPoint Splitter](https://products.aspose.app/slides/fa/splitter) که با API Aspose.Slides ساخته شده است، ارائه می‌دهد. این برنامه اسلایدهای انتخاب‌شده را از یک ارائه به‌صورت فایل‌های جداگانهٔ PPT یا PPTX ذخیره می‌کند.
{{% /alert %}}

## **FAQ**

**آیا Aspose.Slides از ذخیره‌سازی افزایشی یا «ذخیره سریع» پشتیبانی می‌کند؟**

خیر. هر عملیات ذخیره یک فایل خروجی کامل می‌نویسد و فقط بخش‌های تغییر یافته را به‌روزرسانی نمی‌کند.

**آیا چندین رشته می‌توانند همزمان همان نمونهٔ Presentation را ذخیره کنند؟**

خیر. یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) [thread‑safe نیست](/slides/fa/cpp/multithreading/). هر نمونه باید تنها از یک رشته در یک زمان دسترسی و ذخیره شود.

**هنگام ذخیرهٔ یک ارائه، چه اتفاقی برای Hyperlink‌ها و فایل‌های لینک شده خارجی می‌افتد؟**

[Hyperlink‌ها](/slides/fa/cpp/manage-hyperlinks/) در ارائه باقی می‌مانند. Aspose.Slides فایل‌های لینک‌شده خارجی را کپی نمی‌کند، بنابراین ارائهٔ ذخیره‌شده باید همچنان بتواند به مکان‌های آن‌ها دسترسی داشته باشد.

**آیا می‌توانم متادیتاهای سند مانند نویسنده، عنوان، شرکت و تاریخ ایجاد را ذخیره کنم؟**

بله. قبل از ذخیره، ویژگی‌های مناسب [document properties](/slides/fa/cpp/presentation-properties/) را تنظیم کنید و Aspose.Slides آن‌ها را در فایل خروجی می‌نویسد.