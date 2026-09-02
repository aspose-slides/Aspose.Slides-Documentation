---
title: "اعمال یا تغییر طرح‌بندی اسلایدها در C++"
linktitle: "طرح‌بندی اسلاید"
type: docs
weight: 60
url: /fa/cpp/slide-layout/
keywords:
- "طرح‌بندی اسلاید"
- "طرح‌بندی محتوا"
- "محل‌دار"
- "طراحی ارائه"
- "طراحی اسلاید"
- "طرح‌بندی استفاده‌نشده"
- "قابلیت مشاهده پاورقی"
- "اسلاید عنوان"
- "عنوان و محتوا"
- "سرآیند بخش"
- "دو محتوا"
- "مقایسه"
- "فقط عنوان"
- "طرح‌بندی خالی"
- "محتوا با عنوان فرعی"
- "تصویر با عنوان فرعی"
- "عنوان و متن عمودی"
- "عنوان عمودی و متن"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "C++"
- "Aspose.Slides"
description: "اعمال، ایجاد و تغییر طرح‌بندی‌های اسلاید در Aspose.Slides برای C++, افزودن محل‌دارها، حذف طرح‌بندی‌های استفاده‌نشده و کنترل قابلیت مشاهده پاورقی."
---
## **بررسی کلی**

یک طرح‌بندی اسلاید موقعیت‌ها و قالب‌بندی‌های جای‌دارهای مختلف مانند عنوان‌ها، متن، تصویرها، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح‌بندی به اسلایدها ساختاری یکدست می‌بخشد در حالی که به هر اسلاید اجازه می‌دهد محتوای خود را داشته باشد.

متداول‌ترین طرح‌بندی‌ها عبارتند از:

- **Title Slide**: شامل جای‌دارهای عنوان و زیرعنوان است.
- **Title and Content**: شامل یک جای‌دار عنوان و یک جای‌دار محتوای عمومی است.
- **Blank**: هیچ جای‌دار محتوایی ندارد و زمانی مفید است که تمام اشکال به‌صورت دستی موقعیت‌یابی شوند.

## **درک ارث‌بری طرح‌بندی**

یک ارائه سه سطح مرتبط دارد:

1. یک [master slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
1. یک [layout slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/) به یک master تعلق دارد و یک چیدمان خاص از جای‌دارها را تعریف می‌کند.
1. یک [normal slide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/) از یک layout استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌نماید.

یک اسلاید معمولی قالب و تم را از layout خود به ارث می‌برد و layout نیز از master خود. مقدار تنظیم‌شده مستقیم بر روی اسلاید معمولی، مقدار ارث‌گیری شده را در همان سطح بازنویسی می‌کند. وقتی یک اسلاید معمولی ایجاد می‌شود، اشکال جای‌دارهای آن از layout انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده در آن جای‌دارها متعلق به اسلاید معمولی است.

قبل از ایجاد اسلایدها، جای‌دارهای موردنیاز را به layout اضافه کنید. افزودن جای‌دار دیگر به layout بعداً، به‌صورت خودکار یک شکل جای‌دار متناظر را به اسلایدهای معمولی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌برده یا هندسهٔ جای‌دارهای موجود در یک layout می‌تواند تمام اسلایدهایی را که به آن وابسته‌اند به‌روز کند. پیش از ویرایش یک layout که در حال استفاده است، اسلایدهای وابستهٔ آن را بررسی و ارائهٔ حاصل را مرور کنید.
- یک layout که هنوز توسط اسلایدی استفاده می‌شود قابل حذف نیست. ابتدا اسلایدهای وابستهٔ آن را به layout دیگری اختصاص دهید یا فقط layoutهای بدون استفاده را حذف کنید.

برای اطلاعات بیشتر دربارهٔ سطح بالایی این سلسله‌مراتب، به [Slide Master](/slides/fa/cpp/slide-master/) مراجعه کنید.

## **انتخاب و اعمال یک طرح‌بندی اسلاید**

زمانی که ارائه مطابق با تعاریف استاندارد PowerPoint است، از نوع layout استفاده کنید. نام‌های layout قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر مبنای نام تا زمانی که قالب منبع را کنترل کنید، کمتر قابل اطمینان است.

مثال زیر به دنبال **Title and Content** در اولین master می‌گردد. اگر آن layout در دسترس نباشد، به‌صراحت به **Blank** باز می‌گردد. بررسی null دوم ضروری است چون یک ارائه می‌توانند تنها layoutهای سفارشی داشته باشند. سپس layout انتخاب‌شده از طریق متد [ISlide::set_LayoutSlide](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/set_layoutslide/) بر روی اولین اسلاید معمولی اعمال می‌شود.

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

تغییر layout یک اسلاید، اشکال عادی اضافه‌شده مستقیم به اسلاید را حذف نمی‌کند. با این حال، موقعیت‌های جای‌دار، قالب‌بندی ارث‌برده و تطبیق بین جای‌دارهای موجود و layout جدید می‌توانند تغییر کنند، بنابراین هنگام جابجایی بین layoutهای کاملاً متفاوت، خروجی را بررسی کنید.

## **افزودن یک Layout Slide**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک layout موجود را انتخاب می‌کرد؛ آن را نمی‌ساخت. برای ایجاد یک layout، متد [IMasterLayoutSlideCollection::Add](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterlayoutslidecollection/add/) را بر روی مجموعهٔ layoutهای master هدف صدا بزنید.

مثال زیر همیشه یک layout جدید **Title and Content** به نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید معمولی بر پایهٔ آن می‌سازد. نام‌های layout باید درون مجموعه یکتا باشند.

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

فقط وقتی قالب واقعاً نیاز به یک ساختار قابل استفاده مجدد دیگر دارد، یک layout اضافه کنید. اگر یک layout مناسب موجود باشد، آن را انتخاب و مجدداً استفاده کنید نه این‌که یک کپی بسازید.

## **افزودن جای‌دارها به یک Layout Slide**

متد [ILayoutSlide::get_PlaceholderManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) یک شئ [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/) برای افزودن اشکال جای‌دار به یک layout فراهم می‌کند.

| Placeholder پاورپوینت               | متد `ILayoutPlaceholderManager` |
| ----------------------------------- | -------------------------------- |
| ![متن](content.png)                 | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addcontentplaceholder/) |
| ![متن (عمودی)](contentV.png)        | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![متن](text.png)                    | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addtextplaceholder/) |
| ![متن (عمودی)](textV.png)           | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addverticaltextplaceholder/) |
| ![تصویر](picture.png)               | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addpictureplaceholder/) |
| ![نمودار](chart.png)                | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addchartplaceholder/) |
| ![جدول](table.png)                  | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addsmartartplaceholder/) |
| ![رسانه](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addmediaplaceholder/) |
| ![تصویر آنلاین](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutplaceholdermanager/addonlineimageplaceholder/) |

مثال زیر بررسی می‌کند که layout **Blank** وجود دارد، چهار جای‌دار به آن اضافه می‌کند و سپس یک اسلاید معمولی که از layout اصلاح‌شده استفاده می‌کند، می‌سازد. ترتیب این کار عمدی است: جای‌دارها قبل از ایجاد اسلاید معمولی اضافه می‌شوند تا Aspose.Slides بتواند اشکال جای‌دار مربوطه را روی آن اسلاید تولید کند.

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

![جای‌دارهای موجود بر روی layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی ارث‌برده یا هندسهٔ جای‌دارهای موجود در layout می‌تواند بر اسلایدهای وابسته تأثیر بگذارد. یک جای‌دار جدید به‌صورت خودکار در اسلایدهای معمولی موجود پر نمی‌شود. تغییرات layout را روی یک کپی از ارائه امتحان کنید و هر اسلاید وابسته را بررسی نمایید.
{{% /alert %}}

## **حذف Layout Slideهای بدون استفاده**

از متد [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) برای حذف layoutهایی که هیچ اسلاید معمولی به آن‌ها ارجاع نمی‌دهد، استفاده کنید. این متد layoutهای هنوز در حال استفاده را دست نخورده می‌گذارد.

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

برای حذف یک layout خاص، ابتدا با استفاده از متد [get_HasDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_hasdependingslides/) یا [GetDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/getdependingslides/) بررسی کنید. قبل از فراخوانی [ILayoutSlide::Remove](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/remove/) اسلایدهای وابسته را به layout دیگری اختصاص دهید. تلاش برای حذف یک layout استفاده‌شده منجر به پرتاب [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی در یک Layout Slide**

یک layout دارای پاورقی، شماره اسلاید و جای‌دارهای تاریخ‑زمان مخصوص به خود است. از متد [ILayoutSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/get_headerfootermanager/) برای کنترل این جای‌دارها برای یک layout استفاده کنید. این کار زمانی مفید است که به عنوان مثال layoutهای محتوا باید پاورقی نشان دهند ولی layoutهای عنوان نه.

مثال زیر یک layout را به‌صورت ایمن انتخاب می‌کند و عناصر پاورقی آن را قابل مشاهده می‌سازد:

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

## **کنترل نمایش پاورقی در یک Master و Layoutهای فرزند آن**

برای اعمال تنظیمات پاورقی یکسان در سراسر سلسله‌مراتب master، از متد [IMasterSlide::get_HeaderFooterManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslide/get_headerfootermanager/) استفاده کنید. متدهای انتشار [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/cpp/aspose.slides/imasterslideheaderfootermanager/) بر روی master و layoutهای وابسته و اسلایدهای معمولی آن عمل می‌کنند؛ نه فقط یک اسلاید معمولی خاص.

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

**تفاوت بین Master Slide و Layout Slide چیست؟**

یک master slide تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. یک layout slide به یک master تعلق دارد و یک چیدمان قابل استفاده مجدد از جای‌دارها را توصیف می‌کند. اسلایدهای معمولی از این layoutها استفاده می‌کنند و محتوای خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک Layout Slide را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با استفاده از متد [IGlobalLayoutSlideCollection::AddClone](https://reference.aspose.com/slides/fa/cpp/aspose.slides/igloballayoutslidecollection/addclone/) یک کپی به مجموعهٔ مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابع مورد استفادهٔ layout منبع را نیز بررسی کنید.

**وقتی یک Layout که در حال استفاده است را تغییر می‌دهم چه اتفاقی می‌افتد؟**

اسلایدهای وابسته تغییرات layout را به ارث می‌برند مگر اینکه قالب‌بندی یا اشیای تحت تأثیر را به‌صورت محلی بازنویسی کرده باشند. بنابراین هندسهٔ جای‌دارها و سبک‌های ارث‌برده می‌تواند به‌صورت همزمان در بسیاری از اسلایدها تغییر کند. قبل از ویرایش layout، با استفاده از [GetDependingSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ilayoutslide/getdependingslides/) اسلایدهای تحت تأثیر را شناسایی کنید.

**اگر یک Layout که هنوز استفاده می‌شود را حذف کنم چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/cpp/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را به layout دیگری اختصاص دهید یا از [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) برای حذف فقط layoutهای بدون ارجاع استفاده کنید.