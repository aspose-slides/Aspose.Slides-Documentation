---
title: اعمال یا تغییر چیدمان اسلایدها در C++
linktitle: چیدمان اسلاید
type: docs
weight: 60
url: /fa/cpp/slide-layout/
keywords:
- چیدمان اسلاید
- چیدمان محتوا
- نگهدارنده
- طراحی ارائه
- طراحی اسلاید
- چیدمان استفاده نشده
- قابلیت نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سربرگ بخش
- دو محتوا
- مقایسه
- فقط عنوان
- چیدمان خالی
- محتوا با توضیح
- تصویر با توضیح
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- C++
- Aspose.Slides
description: "اعمال، ایجاد و تغییر چیدمان‌های اسلاید در Aspose.Slides برای C++، افزودن نگهدارنده‌ها، حذف چیدمان‌های استفاده نشده و کنترل قابلیت نمایش پاورقی."
---
## **بررسی کلی**

یک چیدمان اسلاید موقعیت‌ها و قالب‌بندی نگهدارنده‌هایی مانند عنوان، متن، تصویر، نمودار و جدول را تعریف می‌کند. اعمال یک چیدمان به اسلایدها ساختاری یکسان می‌بخشد در حالی که هر اسلاید می‌تواند محتوای خود را داشته باشد.

متداول‌ترین چیدمان‌ها عبارتند از:

- **اسلاید عنوان**: شامل نگهدارنده‌های عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک نگهدارنده عنوان و یک نگهدارنده محتوا عمومی می‌باشد.
- **خالی**: هیچ نگهدارنده محتوایی ندارد و زمانی مفید است که تمام اشکال به صورت دستی موقعیت‌یابی شوند.

## **درک ارث‌بری چیدمان**

یک ارائه سه سطح مرتبط دارد:

1. یک [اسلاید مستر](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/) تم، قالب‌بندی مشترک، پس‌زمینه و اشیای عمومی را تعریف می‌کند.
1. یک [اسلاید چیدمان](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/) متعلق به یک مستر بوده و چینش خاصی از نگهدارنده‌ها را مشخص می‌کند.
1. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) از یک چیدمان استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی تم و قالب‌بندی را از چیدمان خود به ارث می‌برد و چیدمان نیز از مستر خود به ارث می‌برد. مقداری که مستقیماً بر روی اسلاید عادی تنظیم شود، مقدار ارث‌برده در همان سطح را بازنویسی می‌کند. هنگام ایجاد یک اسلاید عادی، اشکال نگهدارنده آن از چیدمان انتخاب شده تولید می‌شوند، در حالی که محتوای وارد شده به این نگهدارنده‌ها متعلق به اسلاید عادی است.

قبل از ایجاد اسلایدها، نگهدارنده‌های لازم را به یک چیدمان اضافه کنید. افزودن یک نگهدارنده جدید به چیدمان پس از ایجاد اسلایدهای عادی، به‌صورت خودکار به آن اسلایدهای موجود اضافه نمی‌شود.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌برده یا شکل هندسی نگهدارنده‌های موجود در یک چیدمان می‌تواند تمام اسلایدهای وابسته را به‌روز کند. پیش از ویرایش یک چیدمان که در حال استفاده است، اسلایدهای وابسته آن را بررسی کنید و ارائه نهایی را مرور کنید.
- چیدمانی که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته را به چیدمان دیگری اختصاص دهید یا فقط چیدمان‌های استفاده‌نشده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالایی این سلسله‌مراتب، به [اسلاید مستر](/slides/fa/cpp/slide-master/) مراجعه کنید.

برای مخفی کردن لوگوهای ارث‌برده یا اشکال تزئینی مستر در یک اسلاید یا از طریق یک چیدمان مشترک، به [کنترل نمایش گرافیک‌های مستر](/slides/fa/cpp/slide-master/) نگاه کنید. مثال دو اسلاید استفاده‌کننده از همان مستر را مقایسه می‌کند.

## **انتخاب و اعمال یک چیدمان اسلاید**

هنگامی که ارائه از تعاریف استاندارد چیدمان‌های PowerPoint پیروی می‌کند، از نوع چیدمان استفاده کنید. نام‌های چیدمان قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر اساس نام کم‌قابلیت اطمینان است مگر این که قالب منبع را کنترل کنید.

مثال زیر به دنبال **عنوان و محتوا** در اولین مستر می‌گردد. اگر آن چیدمان موجود نباشد، به‌صورت عمدی به **خالی** بازمی‌گردد. بررسی دوم `null` ضروری است زیرا یک ارائه می‌تواند فقط شامل چیدمان‌های سفارشی باشد. سپس چیدمان انتخاب‌شده از طریق متد [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/set_layoutslide/) بر روی اولین اسلاید عادی اعمال می‌شود.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
auto targetLayout = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);

if (targetLayout == nullptr)
{
    targetLayout = layoutSlides->GetByType(SlideLayoutType::Blank);
}

if (targetLayout == nullptr)
{
    throw InvalidOperationException(u"The first master does not contain a suitable layout slide.");
}

presentation->get_Slide(0)->set_LayoutSlide(targetLayout);
presentation->Save(u"output-with-new-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

تغییر چیدمان یک اسلاید اشکال عادی اضافه‌شده مستقیم به اسلاید را حذف نمی‌کند. با این حال، موقعیت نگهدارنده‌ها، قالب‌بندی ارث‌برده و تطابق بین نگهدارنده‌های موجود و چیدمان جدید می‌تواند تغییر کند، بنابراین هنگام جابه‌جایی بین چیدمان‌های متفاوت، خروجی را بررسی کنید.

## **اضافه کردن یک اسلاید چیدمان**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک چیدمان موجود را انتخاب کرد؛ اما آن را ایجاد نکرد. برای ایجاد یک چیدمان، متد [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterlayoutslidecollection/add/) را روی مجموعهٔ چیدمان‌های مستر هدف فراخوانی کنید.

مثال زیر همیشه یک چیدمان جدید **عنوان و محتوا** به نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید عادی بر پایهٔ آن ایجاد می‌سازد. نام چیدمان‌ها باید درون مجموعه یکتا باشند.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto masterSlide = presentation->get_Master(0);
auto reportLayout = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::TitleAndObject, u"Report Title and Content");
presentation->get_Slides()->AddEmptySlide(reportLayout);

presentation->Save(u"output-with-report-layout.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

چیدمان را فقط زمانی اضافه کنید که قالب واقعاً به ساختار قابل استفاده دیگری نیاز داشته باشد. اگر چیدمان مناسبی از پیش موجود باشد، آن را انتخاب و دوباره استفاده کنید به جای ایجاد یک نمونهٔ تکراری.

## **اضافه کردن نگهدارنده‌ها به یک اسلاید چیدمان**

متد [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) یک [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/) برای اضافه کردن اشکال نگهدارنده به چیدمان فراهم می‌کند.

| نگهدارنده PowerPoint | `ILayoutPlaceholderManager` Method |
| ---------------------- | ---------------------------------- |
| ![محتوا](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![محتوا (عمودی)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![متن](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![متن (عمودی)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![تصویر](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![نمودار](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![جدول](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![رسانه](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![تصویر آنلاین](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

مثال زیر بررسی می‌کند که چیدمان **خالی** وجود دارد، چهار نگهدارنده به آن اضافه می‌کند و سپس یک اسلاید عادی که از این چیدمان اصلاح‌شده استفاده می‌کند، ایجاد می‌نماید. ترتیب کار عمدی است: نگهدارنده‌ها قبل از ایجاد اسلاید عادی اضافه می‌شوند تا Aspose.Slides بتواند اشکال نگهدارنده متناظر را در آن اسلاید تولید کند.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayout == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a Blank layout slide.");
}

auto placeholderManager = blankLayout->get_PlaceholderManager();
placeholderManager->AddContentPlaceholder(20.0f, 20.0f, 310.0f, 270.0f);
placeholderManager->AddVerticalTextPlaceholder(350.0f, 20.0f, 350.0f, 270.0f);
placeholderManager->AddChartPlaceholder(20.0f, 310.0f, 310.0f, 180.0f);
placeholderManager->AddTablePlaceholder(350.0f, 310.0f, 350.0f, 180.0f);

presentation->get_Slides()->AddEmptySlide(blankLayout);
presentation->Save(u"output-with-placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![نگهدارنده‌ها در اسلاید چیدمان](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی ارث‌برده یا شکل هندسی نگهدارنده‌های موجود در یک چیدمان می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک نگهدارندهٔ چیدمان که به‌تازگی اضافه شده به اسلایدهای عادی موجود بازپر کندن نمی‌شود. تغییرات چیدمان را روی یک کپی از ارائه آزمایش کنید و هر اسلاید وابسته را بررسی نمایید.
{{% /alert %}}

## **حذف اسلایدهای چیدمان استفاده نشده**

از متد [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) برای حذف چیدمان‌هایی که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد، استفاده کنید. این متد چیدمان‌های هنوز در حال استفاده را دست‌نخورده می‌گذارد.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
presentation->Save(u"output-without-unused-layouts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

برای حذف یک چیدمان خاص، ابتدا از متد [get_HasDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) یا [GetDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/getdependingslides/) آن استفاده کنید. قبل از فراخوانی [ILayoutSlide::Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/remove/) اسلایدهای وابسته را به چیدمان دیگری اختصاص دهید. تلاش برای حذف یک چیدمان مورد استفاده، یک [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxeditexception/) را برمی‌انگیزد.

## **کنترل نمایش پاورقی در یک اسلاید چیدمان**

هر چیدمان پاورقی، شماره اسلاید و نگهدارندهٔ تاریخ‑زمان خود را دارد. برای کنترل این نگهدارنده‌ها برای یک چیدمان از متد [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) استفاده کنید. این کار برای مواقعی مفید است که به عنوان مثال چیدمان‌های محتوا باید پاورقی نشان دهند اما چیدمان‌های عنوان نه.

مثال زیر یک چیدمان را به‌صورت ایمن انتخاب کرده و عناصر پاورقی آن را قابل مشاهده می‌سازد:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/exceptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::TitleAndObject);

if (layoutSlide == nullptr)
{
    layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
}

if (layoutSlide == nullptr)
{
    throw InvalidOperationException(u"The presentation does not contain a suitable layout slide.");
}

auto headerFooterManager = layoutSlide->get_HeaderFooterManager();
headerFooterManager->SetFooterVisibility(true);
headerFooterManager->SetSlideNumberVisibility(true);
headerFooterManager->SetDateTimeVisibility(true);
headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"output-with-layout-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **کنترل نمایش پاورقی در یک مستر و چیدمان‌های فرزند آن**

برای اعمال تنظیمات پاورقی یکسان در سراسر سلسله‌مراتب مستر، از متد [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/get_headerfootermanager/) استفاده کنید. متدهای انتشار [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslideheaderfootermanager/) بر روی مستر و چیدمان‌های وابسته و اسلایدهای عادی آن اعمال می‌شوند؛ نه فقط بر یک اسلاید عادی.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideHeaderFooterManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"output-with-master-footers.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **سؤالات متداول**

**تفاوت بین اسلاید مستر و اسلاید چیدمان چیست؟**

اسلاید مستر تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید چیدمان متعلق به یک مستر بوده و یک تنظیم قابل استفاده‌ی مجدد از نگهدارنده‌ها را مشخص می‌کند. اسلایدهای عادی از این چیدمان‌ها استفاده می‌کنند و محتوای خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید چیدمان را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با متد [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igloballayoutslidecollection/addclone/) یک کپی به مجموعهٔ مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابع استفاده‌شده توسط چیدمان منبع را نیز بررسی کنید.

**اگر یک چیدمان که هم‌اکنون در استفاده است را تغییر دهم، چه می‌شود؟**

اسلایدهای وابسته تغییرات چیدمان را به‌ارث می‌برند مگر این که قالب‌بندی یا اشیای مورد تأثیر را به‌صورت محلی بازنویسی کرده باشند. شکل هندسی نگهدارنده‌ها و استایل ارث‌برده می‌تواند به‌صورت همزمان بر بسیاری از اسلایدها تغییر کند. قبل از ویرایش چیدمان از [GetDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/getdependingslides/) برای شناسایی اسلایدهای تحت تأثیر استفاده کنید.

**اگر یک چیدمان که هنوز استفاده می‌شود را حذف کنم، چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را به چیدمان دیگری اختصاص دهید یا از [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) برای حذف فقط چیدمان‌های بدون ارجاع استفاده کنید.