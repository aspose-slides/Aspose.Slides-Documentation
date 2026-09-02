---
title: دریافت و به‌روزرسانی اطلاعات ارائه در C++
linktitle: اطلاعات ارائه
type: docs
weight: 30
url: /fa/cpp/examine-presentation/
keywords:
- قالب ارائه
- خصوصیات ارائه
- خصوصیات سند
- دریافت خصوصیات
- خواندن خصوصیات
- تغییر خصوصیات
- ویرایش خصوصیات
- به‌روزرسانی خصوصیات
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
## **مرور کلی**

Aspose.Slides می‌تواند قالب یک ارائه را شناسایی کرده و متادیتای سند را بدون ایجاد یک مدل شیء کامل خوانده و بررسی کند. این کار زمانی مفید است که نیاز به طبقه‌بندی فایل‌ها، ساخت فهرست موجودی یا بررسی خصوصیات پیش از تصمیم‌گیری برای بارگذاری و پردازش محتوای ارائه داشته باشید.

این مقاله با استفاده از [PresentationFactory](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentationfactory/) و [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/) بازرسی سبک وزن را نشان می‌دهد و همچنین به‌روزرسانی‌های هدفمند را از طریق [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/) نشان می‌دهد.

## **بررسی قالب یک ارائه**

از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) برای بازرسی یک فایل بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) استفاده کنید. متد [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/get_loadformat/) قالب شناسایی‌شده را گزارش می‌دهد، مانند PPTX، PPT یا ODP.

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

## **ساخت فهرست موجودی سبک وزن برای ارائه‌ها**

زمانی که تعداد زیادی فایل ارائه را پردازش می‌کنید، ممکن است به یک فهرست موجودی فشرده برای اعتبارسنجی، ایندکس‌گذاری یا سیستم مدیریت اسناد نیاز داشته باشید. در این حالت، از [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) برای به‌دست‌آوردن یک شیء [IPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/) استفاده کنید و سپس متد [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) را برای خواندن متادیتای سند فراخوانی کنید. این روش هیچ نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) ایجاد نمی‌کند و نیازی به مرور کامل مدل شیء ارائه نیست.

خصوصیات گسترده‌ای که توسط [IDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/) ارائه می‌شود، مقادیر زیر را برای موجودی فراهم می‌کند:

| متد | مقدار موجودی |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_slides/) | تعداد کل اسلایدها. |
| [get_HiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | تعداد اسلایدهای مخفی. |
| [get_Notes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_notes/) | تعداد اسلایدهایی که حاوی یادداشت هستند. |
| [get_Paragraphs](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | تعداد کل پاراگراف‌ها، در صورت موجود بودن. |
| [get_Words](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_words/) | تعداد کل کلمات. |
| [get_MultimediaClips](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | تعداد کل کلیپ‌های صوتی و تصویری. |

مثال زیر این مقادیر را بدون ایجاد یک شیء [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) می‌خواند و یک موجودی فشرده را چاپ می‌کند. همچنین [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_headingpairs/) را با [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) ترکیب می‌کند تا گروه‌های محتوا مانند قلم‌ها، تم‌ها و عناوین اسلایدها را نمایش دهد.

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

هر [IHeadingPair](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iheadingpair/) نام گروه را از طریق [IHeadingPair::get_Name](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iheadingpair/get_name/) و تعداد موارد در آن گروه را از طریق [IHeadingPair::get_Count](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iheadingpair/get_count/) فراهم می‌کند. [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) یک آرایهٔ صاف و مرتب بر می‌گرداند، بنابراین باید تعداد عناوین متوالی تعیین‌شده توسط هر جفت عنوان را مصرف کنید.

### **متادیتای ذخیره‌شده و محدودیت‌های قالب**

خصوصیات موجودی که توسط [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) برگردانده می‌شود، متادیتای موجود در سند منبع را منعکس می‌کند. Aspose.Slides برای این فراخوانی مدل شیء ارائه را بارگذاری و مرور نمی‌کند تا این مقادیر را مجدداً محاسبه کند. خصوصیات غایب با مقادیر پیش‌فرض نمایش داده می‌شوند و مقادیر ذخیره‌شده ممکن است در صورتی که برنامه‌ای که آخرین بار فایل را ذخیره کرده باشد، خصوصیات سند را به‌روز نکرده باشد، منقضی باشند.

- **PPTX:** این قالب خصوصیات سند گسترده برای شمارش اسلاید، یادداشت، اسلاید مخفی، پاراگراف، کلمه و موارد چندرسانه‌ای، همچنین جفت‌های عنوان و عناوین بخش‌ها را فراهم می‌کند. در دسترس بودن آن‌ها بستگی به این دارد که کدام خصوصیات توسط تولیدکنندهٔ سند نوشته شده‌اند.
- **PPT:** قالب باینری می‌تواند خصوصیات خلاصهٔ سند متناظر را ذخیره کند. اگر یک خصوصیت غایب باشد یا توسط تولیدکنندهٔ سند تازه‌سازی نشود، Aspose.Slides مقدار ذخیره‌شده یا پیش‌فرض آن را بر می‌گرداند به جای این‌که از اسلایدها محاسبه شود.
- **ODP:** متادیتای OpenDocument آمار کلی سند مانند شمارش صفحه، پاراگراف و کلمه را فراهم می‌کند، اما این مقادیر به هر خصوصیت گستردهٔ خاص PowerPoint نگاشت نمی‌شوند. متادیتای اسلاید مخفی، اسلاید یادداشت، چندرسانه‌ای، جفت عنوان و عناوین بخش ممکن است در دسترس نباشند و خصوصیات موجودی ممکن است مقادیر پیش‌فرض برگردانند. صفر یا آرایهٔ خالی را به‌عنوان اثبات قطعی عدم وجود محتوا در نظر نگیرید.

از رویکرد متادیتای سبک وزن برای موجودی‌ها و بررسی‌های اولیه استفاده کنید. برای زمانی که نتیجه باید تغییرات در حافظه را منعکس کند یا نیاز به تأیید محتوای واقعی ارائه دارید، ارائه را بارگذاری و مدل شیء زندهٔ آن را بازرسی کنید.

## **به‌روزرسانی خصوصیات ارائه**

خصوصیات برگردانده‌شده توسط [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) را می‌توان بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/) نیز تغییر داد. تغییرات را با [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/) اعمال کنید و سپس ارائهٔ بایند‌شده را با [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/) بنویسید.

تصویر زیر خصوصیات سند اصلی ارائهٔ PowerPoint را نشان می‌دهد.

![Original document properties of the PowerPoint presentation](input_properties.png)

مثال زیر عنوان و زمان آخرین ذخیره‌سازی را تغییر می‌دهد و نتیجه را در یک فایل جدید می‌نویسد:

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

تصویر زیر خصوصیات سند به‌روز شده را نشان می‌دهد.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **پیوندهای مفید**

برای بررسی‌های امنیتی مرتبط و تنظیمات حفاظت، به مقالات زیر مراجعه کنید:

- [Password-Protect Presentations](/slides/fa/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fa/cpp/write-protected-presentation/)

## **سوالات متداول**

**چگونه می‌توانم بررسی کنم آیا قلم‌ها جاسازی شده‌اند و کدام‌ها؟**

ارائه را بارگذاری کنید و از [Presentation::get_FontsManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_fontsmanager/) استفاده کنید. متد [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getembeddedfonts/) قلم‌های جاسازی‌شده را بر می‌گرداند و [FontsManager::GetFonts](https://reference.aspose.com/slides/fa/cpp/aspose.slides/fontsmanager/getfonts/) قلم‌های استفاده‌شده در ارائه را بر می‌گرداند. دو نتیجه را مقایسه کنید تا قلم‌هایی که برای رندر لازم‌اند اما جاسازی نشده‌اند، شناسایی کنید.

**چگونه می‌توانم به‌سرعت بفهمم آیا فایل اسلایدهای مخفی دارد و چند تا؟**

زمانی که متادیتای ذخیره‌شدهٔ سند کافی باشد، [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) را از طریق [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) و [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) بخوانید. این روش برای یک موجودی سبک وزن مناسب است. اگر ارائه در حافظه تغییر کرده باشد، متادیتای ذخیره‌شده ممکن است غایب یا منقضی باشد یا نیاز به تأیید مقادیر زنده داشته باشید؛ در این صورت از طریق [Presentation::get_Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slides/) حلقه بزنید و متد [Slide::get_Hidden](https://reference.aspose.com/slides/fa/cpp/aspose.slides/slide/get_hidden/) هر اسلاید را بررسی کنید.

**آیا می‌توانم تشخیص دهم آیا اندازه و جهت سفارشی اسلاید استفاده شده و آیا با پیش‌فرض‌ها متفاوت است؟**

بله. ارائه را بارگذاری کنید و [Presentation::get_SlideSize](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slidesize/) را بخوانید. با بررسی [ISlideSize::get_Type](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/get_type/)، [ISlideSize::get_Size](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/get_size/) و [ISlideSize::get_Orientation](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islidesize/get_orientation/) تنظیمات فعلی را با پیش‌فرض‌ها و ابعاد مورد انتظار مقایسه کنید.

**آیا راهی سریع برای دیدن این است که آیا نمودارها به منابع دادهٔ خارجی ارجاع می‌دهند؟**

بله. هر [Chart](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chart/) را پیدا کنید و [ChartData::get_DataSourceType](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) را بررسی کنید. برای یک کارپنامهٔ خارجی، [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/fa/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) را بخوانید. نوع منبع داده و مسیر نشانگر ارجاع به یک منبع خارجی هستند، اما تأیید موجودیت هدف نیاز به بررسی منابع جداگانه دارد.

**چگونه می‌توانم «اسلایدهای سنگین» که ممکن است رندر یا خروجی PDF را کند کنند، ارزیابی کنم؟**

خاصیت پیچیدگی واحدی وجود ندارد. [Presentation::get_Slides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/presentation/get_slides/) و مجموعهٔ [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ibaseslide/get_shapes/) هر اسلاید را مرور کنید. از شمارش اشکال و وجود تصاویر بزرگ، افکت‌ها، انیمیشن‌ها یا چندرسانه‌ای‌ها به‌عنوان سیگنال‌های فیلترینگ استفاده کنید و یک رندر یا خروجی نمایانگر را اندازه‌گیری کنید قبل از این که اسلاید را به‌عنوان گلوگاه عملکردی تأیید کنید.