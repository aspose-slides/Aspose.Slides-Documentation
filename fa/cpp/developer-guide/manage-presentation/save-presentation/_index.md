---
title: ذخیره ارائه‌ها در C++
linktitle: ذخیره ارائه
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
- ارائه به استریم
- نوع نمای پیش‌فرض
- قالب Strict Office Open XML
- حالت Zip64
- به‌روزرسانی تصویر بندانگشتی
- پیشرفت ذخیره‌سازی
- C++
- Aspose.Slides
description: "کشف کنید چگونه می‌توانید ارائه‌ها را در C++ با استفاده از Aspose.Slides—به‌صورت PowerPoint یا OpenDocument صادر کنید و طرح‌بندی‌ها، قلم‌ها و افکت‌ها را حفظ کنید."
---
## **بررسی کلی**

[باز کردن ارائه‌ها در C++](/slides/fa/cpp/open-presentation/) توضیح می‌دهد چگونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) برای باز کردن یک ارائه استفاده کنید. این مقاله نحوهٔ ایجاد و ذخیرهٔ ارائه‌ها را شرح می‌دهد. کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) شامل محتوای یک ارائه است. چه از ابتدا ارائه‌ای بسازید و چه یک ارائه موجود را اصلاح کنید، پس از اتمام می‌خواهید آن را ذخیره کنید. با Aspose.Slides برای C++ می‌توانید به **file** یا **stream** ذخیره کنید. این مقاله روش‌های مختلف ذخیره‌سازی یک ارائه را توضیح می‌دهد.

## **ذخیره ارائه‌ها در فایل‌ها**

برای ذخیره یک ارائه در فایل، متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) را فراخوانی کنید. نام فایل و فرمت ذخیره را به متد پاس دهید. مثال زیر نشان می‌دهد چگونه یک ارائه را با Aspose.Slides ذخیره کنید.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// اینجا کاری انجام دهید...

// ذخیرهٔ ارائه در یک فایل.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **ذخیره ارائه‌ها در Stream‌ها**

می‌توانید یک ارائه را در Stream ذخیره کنید با پاس کردن یک خروجی Stream به متد `Save` کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/). یک ارائه می‌تواند به انواع مختلف Stream‌ها نوشته شود. در مثال زیر، یک ارائه جدید ایجاد می‌کنیم و آن را در یک File Stream ذخیره می‌کنیم.

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

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// ذخیرهٔ ارائه در استریم.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **ذخیره ارائه‌ها با یک نوع نما از پیش تعریف شده**

Aspose.Slides به شما امکان می‌دهد نمای اولیه‌ای را که PowerPoint هنگام باز شدن ارائهٔ تولید شده استفاده می‌کند، از طریق کلاس [ViewProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/) تنظیم کنید. از متد [set_LastView](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewproperties/set_lastview/) با مقداری از enum [ViewType](https://reference.aspose.com/slides/fa/cpp/aspose.slides/viewtype/) استفاده کنید.

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

## **ذخیره ارائه‌ها در فرمت Strict Office Open XML**

Aspose.Slides به شما امکان می‌دهد یک ارائه را در فرمت Strict Office Open XML ذخیره کنید. از کلاس [PptxOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/) استفاده کنید و هنگام ذخیره ویژگی conformance آن را تنظیم کنید. اگر `Conformance.Iso29500_2008_Strict` را تنظیم کنید، فایل خروجی در فرمت Strict Office Open XML ذخیره می‌شود.

مثال زیر یک ارائه ایجاد می‌کند و آن را در فرمت Strict Office Open XML ذخیره می‌سازد.

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

// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل ارائه است.
auto presentation = MakeObject<Presentation>();

// ذخیرهٔ ارائه در قالب Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **ذخیره ارائه‌ها در فرمت Office Open XML در حالت Zip64**

یک فایل Office Open XML یک آرشیو ZIP است که محدودیت ۴ GB (۲^۳۲ بایت) برای اندازهٔ فشرده‌نشدهٔ هر فایل، اندازهٔ فشردهٔ هر فایل و کل حجم آرشیو اعمال می‌کند و همچنین تعداد فایل‌ها را به ۶۵ ۵۳۵ (۲^۱۶‑۱) محدود می‌کند. افزونه‌های فرمت ZIP64 این محدودیت‌ها را به ۲^۶۴ ارتقا می‌دهند.

متد [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) به شما اجازه می‌دهد هنگام ذخیرهٔ یک فایل Office Open XML چه زمانی از افزونه‌های فرمت ZIP64 استفاده کنید.

این متد می‌تواند با حالت‌های زیر استفاده شود:

- `IfNecessary` فقط در صورتی که ارائه از محدودیت‌های فوق فراتر رود از افزونه‌های ZIP64 استفاده می‌کند. این حالت پیش‌فرض است.
- `Never` هرگز از افزونه‌های ZIP64 استفاده نمی‌کند.
- `Always` همیشه از افزونه‌های ZIP64 استفاده می‌کند.

کد زیر نشان می‌دهد چگونه یک ارائه را به صورت فایل PPTX با فعال‌سازی افزونه‌های فرمت ZIP64 ذخیره کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
هنگامی که با `Zip64Mode.Never` ذخیره می‌کنید، اگر ارائه نتواند در فرمت ZIP32 ذخیره شود، یک [PptxException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxexception/) پرتاب می‌شود.
{{% /alert %}}

## **ذخیره ارائه‌ها در فرمت Office Open XML با سطوح فشرده‌سازی**

هنگام کار با ارائه‌های بزرگ، می‌توانید سطح فشرده‌سازی را تنظیم کنید تا بین حجم فایل و زمان پردازش تعادل برقرار شود. بسته به نیازهای شما ممکن است پردازش سریع‌تر یا فایل‌های خروجی کوچکتر ترجیح داده شود.

Aspose.Slides متد [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) را فراهم می‌کند که به شما اجازه می‌دهد سطح فشرده‌سازی مورد استفاده هنگام ذخیرهٔ یک ارائه در فرمت Office Open XML را مشخص کنید.

سطوح فشرده‌سازی موجود عبارتند از:

- **None**: هیچ فشرده‌سازی‌ای اعمال نمی‌شود. فایل‌ها به همان شکل ذخیره می‌شوند.
- **Level1**: سریع‌ترین فشرده‌سازی با کمترین نسبت فشرده‌سازی.
- **Level2**: فشرده‌سازی سریع‌تر با نسبت فشرده‌سازی کمی بهتر نسبت به **Level1**.
- **Level3**: فشرده‌سازی بهتر نسبت به **Level2** با تأثیر متوسط بر زمان پردازش.
- **Level4**: فشرده‌سازی بهتر نسبت به **Level3**.
- **Level5**: فشرده‌سازی بهبود یافته نسبت به **Level4** با زمان پردازش اضافی.
- **Level6**: فشرده‌سازی استاندارد که تعادل خوبی بین سرعت پردازش و حجم فایل ارائه می‌دهد. این *سطح فشرده‌سازی پیش‌فرض* است.
- **Level7**: فشرده‌سازی بهتر نسبت به **Level6** با پردازش کندتر.
- **Level8**: فشرده‌سازی بهتر نسبت به **Level7**.
- **Level9**: حداکثر فشرده‌سازی. کوچک‌ترین حجم فایل را تولید می‌کند ولی زمان پردازش طولانی‌ترین است.

مثال زیر نشان می‌دهد چگونه یک ارائه را به صورت یک فایل PPTX *بدون فشرده‌سازی* ذخیره کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

این مثال نشان می‌دهد چگونه یک ارائه را به صورت یک فایل PPTX با *حداکثر فشرده‌سازی* ذخیره کنید:

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **ذخیره ارائه‌ها بدون به‌روزرسانی تصویر بندانگشتی**

متد [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) کنترل می‌کند که هنگام ذخیرهٔ یک ارائه به PPTX تصویر بندانگشتی تولید شود یا نه:

- اگر به `true` تنظیم شود، تصویر بندانگشتی در حین ذخیره به‌روزرسانی می‌شود. این حالت پیش‌فرض است.
- اگر به `false` تنظیم شود، تصویر بندانگشتی فعلی حفظ می‌شود. اگر ارائه تصویر بندانگشتی نداشته باشد، هیچ‌کدام تولید نخواهد شد.

در کد زیر، ارائه بدون به‌روزرسانی تصویر بندانگشتی به PPTX ذخیره می‌شود.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
این گزینه به کاهش زمان مورد نیاز برای ذخیرهٔ یک ارائه در فرمت PPTX کمک می‌کند.
{{% /alert %}}

## **به‌روزرسانی پیشرفت ذخیره به درصد**

اینترفیس [IProgressCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprogresscallback/) از طریق متد `set_ProgressCallback` که توسط اینترفیس [ISaveOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/isaveoptions/) و کلاس انتزاعی [SaveOptions](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveoptions/) افشا می‌شود، استفاده می‌شود. یک پیاده‌سازی از [IProgressCallback](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iprogresscallback/) را با `set_ProgressCallback` اختصاص دهید تا به‌روزرسانی‌های پیشرفت ذخیره به صورت درصد دریافت کنید.

کدهای زیر نشان می‌دهد چگونه از `IProgressCallback` استفاده شود.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // در اینجا از مقدار درصد پیشرفت استفاده کنید.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
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

// کلاس callback پیشرفت که در بالا تعریف شد.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose یک [برنامه رایگان تقسیم‌کننده PowerPoint](https://products.aspose.app/slides/fa/splitter) با استفاده از API خود توسعه داده است. این برنامه به شما امکان می‌دهد یک ارائه را به چندین فایل تقسیم کنید با ذخیره اسلایدهای انتخابی به‌عنوان فایل‌های جدید PPTX یا PPT.
{{% /alert %}}

## **سوالات متداول**

**آیا ذخیره سریع (ذخیره افزایشی) پشتیبانی می‌شود تا فقط تغییرات نوشته شوند؟**

خیر. هر بار ذخیره، یک فایل هدف کامل ایجاد می‌شود؛ ذخیره سریع (افزایشی) پشتیبانی نمی‌شود.

**آیا ذخیرهٔ همزمان یک شیٔ Presentation از چندین رشته (thread) ایمن است؟**

خیر. یک شیٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) [ایمن برای استفاده همزمان نیست](/slides/fa/cpp/multithreading/); آن را فقط از یک رشته ذخیره کنید.

**چه اتفاقی برای پیوندهای هیپرلینک و فایل‌های پیوند داده شده در خارج هنگام ذخیره می‌افتد؟**

[Hyperlinks](/slides/fa/cpp/manage-hyperlinks/) حفظ می‌شوند. فایل‌های پیوند داده شدهٔ خارجی (مانند ویدئوها با مسیرهای نسبی) به‌صورت خودکار کپی نمی‌شوند—مطمئن شوید مسیرهای مرجع در دسترس باقی بمانند.

**آیا می‌توانم متادیتای سند (نویسنده، عنوان، شرکت، تاریخ) را تنظیم/ذیره کنم؟**

بله. [ویژگی‌های سند](/slides/fa/cpp/presentation-properties/) استاندارد پشتیبانی می‌شوند و هنگام ذخیره در فایل نوشته می‌شوند.