---
title: تشخیص قالب اصلی ارائه در C++
linktitle: قالب منبع
type: docs
weight: 35
url: /fa/cpp/detect-presentation-source-format/
keywords:
- قالب منبع
- تشخیص قالب ارائه
- PowerPoint
- OpenDocument
- ارائه
- PPT
- PPTX
- C++
- Aspose.Slides
description: "قالب اصلی یک ارائه‌ بارگذاری‌شده را در C++ با Aspose.Slides برای C++ بخوانید، APIهای تشخیص را مقایسه کنید و با فایل‌ها، جریان‌ها و قالب‌های قدیمی کار کنید."
---
## **بررسی کلی**

پس از بارگذاری یک ارائه، برای تعیین قالب اصلی آن، متد [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sourceformat/) را فراخوانی کنید. این متد همچنین از طریق [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentation/get_sourceformat/) در دسترس است. از آن زمانی استفاده کنید که پردازش‌های بعدی به قالبی که نمونهٔ فعلی از آن بارگذاری شده، وابسته باشد.

قالب منبع با [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) انتخاب‌شده برای فایل خروجی متفاوت است. ذخیره‌سازی در قالب دیگری، قالب منبع نمونهٔ موجود را تغییر نمی‌دهد.

## **خواندن قالب منبع یک فایل**

این مثال به یک فایل `sample.pptx` موجود نیاز دارد. فایل را بارگذاری می‌کند و به جای نام فایل، با استفاده از [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sourceformat/) یک سیاست پردازشی برنامه را انتخاب می‌کند. مسیر ورودی را تغییر دهید تا قالب‌های دیگر را امتحان کنید. مثال سیاست انتخاب‌شده را چاپ می‌کند؛ پیام‌ها را با منطق برنامهٔ خود جایگزین کنید.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **شناسایی مقادیر پشتیبانی‌شده**

شمارهٔ [SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sourceformat/) قالب‌های مختلف ارائه را متمایز می‌کند. پسوندهای زیر پسوندهای رایج هستند و بازسازی نام فایل اصلی نیستند.

| مقدار SourceFormat | پسوند | قالب |
| --- | --- | --- |
| `Ppt` | `.ppt` | ارائهٔ PowerPoint 97–2003 |
| `Pptx` | `.pptx` | ارائهٔ Office Open XML |
| `Pptm` | `.pptm` | ارائهٔ Office Open XML با ماکرو |
| `Pps` | `.pps` | نمایش اسلاید PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | نمایش اسلاید Office Open XML |
| `Ppsm` | `.ppsm` | نمایش اسلاید Office Open XML با ماکرو |
| `Pot` | `.pot` | قالب PowerPoint 97–2003 |
| `Potx` | `.potx` | قالب Office Open XML |
| `Potm` | `.potm` | قالب Office Open XML با ماکرو |
| `Odp` | `.odp` | ارائهٔ OpenDocument |
| `Otp` | `.otp` | قالب ارائهٔ OpenDocument |
| `Fodp` | `.fodp` | ارائهٔ Flat XML ODF |
| `Xml` | `.xml` | ارائهٔ PowerPoint XML |

## **خواندن قالب منبع یک جریان**

این مثال به یک فایل `sample.pps` موجود نیاز دارد. خواندن بایت‌های آن به یک جریان حافظه، ورودی بدون نام فایل مانند مقدار پایگاه‌داده یا آرایه بایتی آپلودشده را شبیه‌سازی می‌کند. سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) فقط جریان را دریافت می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

فرمت‌های PPT، PPS و POT از همان قالب باینری زیرساختی استفاده می‌کنند. هنگام بارگذاری با مسیر فایل، پسوند می‌تواند به تمایز نمایش اسلاید یا قالب کمک کند. بدون نام فایل، محتویات قدیمی PPS و POT ممکن است به عنوان `SourceFormat::Ppt` گزارش شوند؛ مثال PPS بالا `Ppt` را گزارش می‌دهد.

اگر برنامهٔ شما باید این تمایز را حفظ کند، نام فایل اصلی یا متادیتای زیرنوع را به‌صورت جداگانه نگه دارید. پسوند یک اشاره‌گر مفید برای این زیرنوع‌های قدیمی است، اما نباید تنها معیار شناسایی محتوای ارائهٔ دلخواه باشد.

## **مقایسهٔ تشخیص قبل و بعد از بارگذاری**

زمانی که نیاز به بازرسی یک فایل قبل از بارگذاری کامل مدل شیء ارائه دارید، از [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/getpresentationinfo/) و [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_loadformat/) استفاده کنید. هنگامی که نمونه قبلاً موجود است، از [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sourceformat/) استفاده کنید.

این مثال به `sample.pptx` نیاز دارد و برای هر دو بررسی `Pptx` را چاپ می‌کند. در محیط تولید، API مناسب به مرحلهٔ پردازش خود انتخاب کنید؛ یک ارائهٔ قبلاً بارگذاری‌شده نیازی به بازرسی دوم فقط برای دریافت قالب منبع خود ندارد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

نتایج دارای انواع enumerations متفاوتی هستند: [LoadFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/loadformat/) و [SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sourceformat/). آنها را با تبدیل مقادیر عددی مقایسه نکنید و فرض نکنید که هر قالب نتایج تشخیص یکسانی دارد. PowerPoint XML می‌تواند قبل از بارگذاری به عنوان `LoadFormat::Unknown` و پس از بارگذاری به عنوان `SourceFormat::Xml` گزارش شود.

## **حفظ جداسازی قالب منبع و خروجی**

این مثال به `sample.pptx` نیاز دارد و `converted.odp` را می‌نویسد. قبل و بعد از ذخیرهٔ نمونهٔ اصلی، `Pptx` را چاپ می‌کند. فقط نمونهٔ جدیدی که از خروجی ODP بارگذاری می‌شود، `Odp` را گزارش می‌دهد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

یک ارائه که از ابتدا با `MakeObject<Presentation>()` ساخته می‌شود، `SourceFormat::Pptx` را گزارش می‌دهد. این نمونه فاقد فایل ورودی است: این مقدار پیش‌فرض برای یک نمونهٔ تازه ایجاد شده است و نشانهٔ بارگذاری فایل PPTX نیست. اگر این تمایز مهم است، به‌طور جداگانه پیگیری کنید که برنامهٔ شما نمونه را ایجاد کرده یا بارگذاری کرده است.

## **نقشه‌برداری قالب منبع به پسوند**

مثال زیر به `sample.pptx` نیاز دارد. هر مقدار [SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/sourceformat/) که در حال حاضر پشتیبانی می‌شود را به یک پسوند متعارف نگاشت می‌کند، بدون تجزیهٔ نام فایل ورودی. مکانیزم پیش‌فرض از اختصاص بی‌صدا یک پسوند به مقدار ناشناخته جلوگیری می‌کند.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

این نگاشت فایلی را تبدیل نمی‌کند و زیرنوع قدیمی PPS/POT که در حین بارگذاری جریان از دست رفته بود را بازیابی نمی‌کند. برای ذخیره‌سازی واقعی، به‌طور صریح یک [SaveFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides.export/saveformat/) انتخاب کنید، یا از تبدیل نشان‌داده‌شده در [Save Presentations in Their Original Format](/slides/fa/cpp/save-presentation/#save-presentations-in-their-original-format) استفاده کنید.

## **تأیید قالب‌ها با ذخیره و بازگشایی**

این مثال خودکفا یک ارائه ایجاد می‌کند و سه فایل را در پوشهٔ کاری می‌نویسد، فایل‌های با نام‌های مشابه را بازنویسی می‌کند. هر خروجی را هم از مسیر و هم از طریق یک جریان حافظه باز می‌کند. برای PPTX و ODP، هر دو مسیر قالب ذخیره‌شده را گزارش می‌دهند. برای PPS، بارگذاری از مسیر `Pps` را گزارش می‌کند، در حالی که بارگذاری همان بایت‌ها بدون نام فایل `Ppt` را گزارش می‌دهد.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

جدول زیر شناسایی قالب منبع برای ارائه‌هایی با پسوندهای مشابه را خلاصه می‌کند:

| قالب ذخیره شده | SourceFormat از مسیر فایل | SourceFormat از جریان بدون نام |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` به ترتیب | همانند مسیر فایل |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` به ترتیب | همانند مسیر فایل |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` به ترتیب | همانند مسیر فایل |
| ODP, OTP | `Odp`, `Otp` به ترتیب | همانند مسیر فایل |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

محتوای قدیمی PPS/POT برای جریان‌های بدون نام به `Ppt` نرمال‌سازی می‌شود. جدول شناسایی قالب را توصیف می‌کند، نه حفظ تمام ویژگی‌های ارائه هنگام تبدیل.

## **سوالات متداول**

**آیا ذخیره‌سازی به ODP قالب منبع ارائه‌ای که از PPTX بارگذاری شده را تغییر می‌دهد؟**

خیر. نمونهٔ موجود همچنان `Pptx` را گزارش می‌دهد. نمونه‌ای که از فایل ODP ذخیره‌شده بارگذاری می‌شود، `Odp` را گزارش می‌کند.

**آیا یک جریان همیشه می‌تواند بین ارائهٔ قدیمی، نمایش اسلاید و قالب تفاوت قائل شود؟**

خیر. قالب‌های PPT، PPS و POT از یک فرمت باینری مشترک استفاده می‌کنند. وقتی این تمایز ضروری است، نام فایل یا متادیتای زیرنوع را به‌صورت جداگانه نگه دارید.

**کدام API را باید استفاده کنم اگر ارائه‌ قبلاً بارگذاری شده باشد؟**

متد [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_sourceformat/) را بخوانید. برای بازرسی قبل از بارگذاری، از [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/getpresentationinfo/) استفاده کنید.