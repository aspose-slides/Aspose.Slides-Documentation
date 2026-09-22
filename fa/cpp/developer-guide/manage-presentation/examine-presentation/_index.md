---
title: دریافت و به روز رسانی اطلاعات ارائه در C++
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/cpp/examine-presentation/
keywords:
- فرمت ارائه
- خصوصیات ارائه
- خصوصیات سند
- دریافت خصوصیات
- خواندن خصوصیات
- تغییر خصوصیات
- اصلاح خصوصیات
- به روز رسانی خصوصیات
- بررسی PPTX
- بررسی PPT
- بررسی ODP
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اسلایدها، ساختار و متادیتا را در ارائه‌های PowerPoint و OpenDocument با استفاده از C++ بررسی کنید تا بینش‌های سریع‌تر و ارزیابی‌های هوشمندانه‌تری از محتوا به دست آورید."
---
## **نمای کلی**

Aspose.Slides می‌تواند فرمت یک ارائه را شناسایی کرده و فراداده‌های سند آن را بدون ایجاد یک مدل شیء کامل ارائه بخواند. این برای زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت موجودی یا بررسی ویژگی‌ها قبل از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله بازرسی سبک وزن را از طریق [PresentationFactory](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/)، و همچنین به‌روزرسانی‌های هدفمند را از طریق [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/) نشان می‌دهد.

## **بررسی فرمت ارائه**

اگر قبلاً یک ارائه بارگذاری شده دارید، برای تشخیص پس از بارگذاری و محدودیت‌های جریان‌های قدیمی PPT، PPS و POT، مقاله [Determine the Original Presentation Format](/slides/fa/cpp/detect-presentation-source-format/) را ببینید.

از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) برای بازرسی یک فایل بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) استفاده کنید. متد [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_loadformat/) فرمت شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **ساخت یک موجودی سبک وزن برای ارائه**

زمانی که بسیاری از فایل‌های ارائه را پردازش می‌کنید، ممکن است به یک موجودی فشرده برای اعتبارسنجی، ایندکس‌گذاری یا سیستم مدیریت اسناد نیاز داشته باشید. در این حالت، از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) برای به‌دست آوردن یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/) استفاده کنید و سپس [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) را برای خواندن فراداده‌های سند فراخوانی کنید. این رویکرد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به پیمایش کامل مدل شیء ارائه نیست.

خصوصیات گسترده‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/) ارائه می‌شوند، مقادیر موجودی زیر را فراهم می‌کنند:

| متد | مقدار موجودی |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_slides/) | تعداد کل اسلایدها. |
| [get_HiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | تعداد اسلایدهای مخفی. |
| [get_Notes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_notes/) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [get_Paragraphs](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | تعداد کل پاراگراف‌ها، در صورت موجود بودن. |
| [get_Words](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_words/) | تعداد کل کلمات. |
| [get_MultimediaClips](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | تعداد کل کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌خواند و یک موجودی فشرده را چاپ می‌کند. همچنین [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_headingpairs/) را با [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، قالب‌ها و عناوین اسلاید را نمایش دهد.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

هر [IHeadingPair](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iheadingpair/) یک نام گروه را از طریق [IHeadingPair::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iheadingpair/get_name/) و تعداد موارد در آن گروه را از طریق [IHeadingPair::get_Count](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iheadingpair/get_count/) فراهم می‌کند. [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) یک آرایه تخت و مرتب بر می‌گرداند، بنابراین تعداد عناوین متوالی مشخص‌شده توسط هر جفت سرعنوان را مصرف کنید.

### **متاداده‌های ذخیره‌شده و محدودیت‌های فرمت**

خصوصیات موجودی که توسط [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) بازگردانده می‌شوند، متاداده‌های موجود در سند منبع را بازتاب می‌دهند. Aspose.Slides برای این فراخوانی، مدل شیء ارائه را بارگذاری و پیمایش نمی‌کند تا این مقادیر را دوباره محاسبه کند. خصوصیات گمشده با مقادیر پیش‌فرض نمایش داده می‌شوند و مقادیر ذخیره‌شده ممکن است منسوخ باشند اگر برنامه‌ای که آخرین بار فایل را ذخیره کرده است، خصوصیات سند خود را به‌روز نشده باشد.

- **PPTX:** این فرمت خصوصیات سند گسترده برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و چندرسانه‌ای، همچنین جفت‌های سرعنوان و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن بستگی به این دارد که کدام خصوصیات توسط تولیدکننده سند نوشته شده‌اند.
- **PPT:** این فرمت باینری می‌تواند خصوصیات خلاصه سند متناظر را ذخیره کند. اگر یک خصوصیت غیرفعال باشد یا توسط تولیدکننده سند به‌روز نشده باشد، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را باز می‌گرداند به جای محاسبه آن از اسلایدها.
- **ODP:** متاداده‌های OpenDocument آمار کلی سند را فراهم می‌کنند، مانند تعداد صفحه، پاراگراف و کلمه، اما این مقادیر به هر خصوصیت گسترده خاص PowerPoint نگاشت نمی‌شوند. متاداده‌های اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت سرعنوان و عناوین بخش ممکن است در دسترس نباشند و خصوصیات موجودی ممکن است مقادیر پیش‌فرض بازگردانند. مقدار صفر یا آرایه خالی را به‌عنوان اثبات قطعی عدم وجود محتوای مربوطه در نظر نگیرید.

برای موجودی‌ها و بررسی‌های اولیه، از رویکرد متاداده سبک وزن استفاده کنید. در زمانی که نتیجه باید تغییرات حافظه‌داخلی را بازتاب دهد یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری کرده و مدل شیء زنده آن را بررسی کنید.

## **به‌روزرسانی خصوصیات ارائه**

خصوصیات بازگردانده‌شده توسط [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) همچنین می‌توانند بدون ایجاد یک نمونه [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) تغییر داده شوند. تغییرات را با [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) اعمال کنید و سپس ارائه متصل را با [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) بنویسید.

تصویر زیر خصوصیات سند اصلی ارائه PowerPoint را نشان می‌دهد.

![خصوصیات سند اصلی ارائه PowerPoint](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره را تغییر می‌دهد و نتیجه را در فایلی جدید می‌نویسد:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

تصویر زیر خصوصیات سند به‌روزشده ارائه PowerPoint را نشان می‌دهد.

![خصوصیات سند به‌روزشده ارائه PowerPoint](output_properties.png)

## **لینک‌های مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات محافظت، به مقالات زیر مراجعه کنید:

- [Password-Protect Presentations](/slides/fa/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/cpp/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم که آیا قلم‌ها جاسازی شده‌اند و کدام‌ها هستند؟**

ارائه را بارگذاری کنید و از [Presentation::get_FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_fontsmanager/) استفاده کنید. با فراخوانی [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getembeddedfonts/) قلم‌های جاسازی‌شده را به‌دست آورید و با [FontsManager::GetFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getfonts/) قلم‌های استفاده‌شده در ارائه را بدست آورید. دو نتیجه را مقایسه کنید تا قلم‌هایی که برای رندرینگ لازم هستند اما جاسازی نشده‌اند را پیدا کنید.

**چگونه می‌توانم به‌سرعت تشخیص دهم آیا فایل دارای اسلایدهای مخفی است و تعداد آنها چقدر است؟**

هنگامی که متاداده‌های ذخیره‌شده سند کافی باشند، [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) را از طریق [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) و [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) بخوانید. این برای موجودی سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، متاداده‌های ذخیره‌شده ممکن است مفقود یا منسوخ باشند، یا برای تأیید مقادیر زنده، به جای آن به [Presentation::get_Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slides/) پیمایش کنید و متد [Slide::get_Hidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/get_hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت‌گیری سفارشی اسلاید استفاده می‌شود و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و [Presentation::get_SlideSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slidesize/) را بخوانید. [ISlideSize::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/get_type/)، [ISlideSize::get_Size](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/get_size/) و [ISlideSize::get_Orientation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/get_orientation/) را بررسی کنید تا تنظیمات فعلی را با پیش‌تنظیمات و ابعاد مورد انتظار مقایسه کنید.

**آیا راه سریع برای دیدن اینکه آیا نمودارها به منابع داده خارجی ارجاع می‌دهند وجود دارد؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/) را پیدا کنید و [ChartData::get_DataSourceType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) را بررسی کنید. برای یک کتاب‌کار خارجی، [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) را بخوانید. نوع منبع داده و مسیر، ارجاع خارجی را شناسایی می‌کند، اما تأیید دسترس بودن هدف نیاز به بررسی منابع جداگانه دارد.

**چگونه می‌توانم اسلایدهای 'سنگین' که ممکن است رندرینگ یا خروجی PDF را کند کنند ارزیابی کنم؟**

هیچ ویژگی تک‌تک پیچیدگی وجود ندارد. [Presentation::get_Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slides/) و مجموعه [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_shapes/) هر اسلاید را پیمایش کنید. از تعداد اشکال و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای به‌عنوان سیگنال‌های فیلتر استفاده کنید و یک رندر یا خروجی نماینده را اندازه‌گیری کنید قبل از اینکه اسلاید را به‌عنوان گلوگاه عملکردی تأیید کنید.