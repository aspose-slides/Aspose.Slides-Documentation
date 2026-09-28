---
title: اعمال یا تغییر طرح اسلایدها در .NET
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/net/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- محل نگهدارنده
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با عنوان فرعی
- عکس با عنوان فرعی
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- C#
- .NET
- Aspose.Slides
description: "اعمال، ایجاد و اصلاح طرح‌های اسلاید در Aspose.Slides برای .NET، افزودن محل‌های نگهدارنده، حذف طرح‌های استفاده‌نشده و کنترل نمایش پاورقی."
---
## **بررسی کلی**

یک طرح اسلاید موقعیت‌ها و قالب‌بندی فضاهای نگهدارنده مانند عنوان‌ها، متن، تصویرها، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح به اسلایدها ساختار ثابتی می‌بخشد در حالی که به هر اسلاید اجازه می‌دهد محتوای خاص خود را داشته باشد.

رایج‌ترین طرح‌ها شامل موارد زیر هستند:

- **اسلاید عنوان**: شامل فضاهای نگهدارنده عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک فضا نگهدارنده عنوان و یک فضا نگهدارنده محتوا با کاربرد عمومی است.
- **خالی**: هیچ فضا نگهدارنده محتوایی ندارد و زمانی مفید است که همه اشکال به صورت دستی موقعیت‌یابی شوند.

## **درک وراثت طرح‌ها**

یک ارائه دارای سه سطح مرتبط است:

1. یک [اسلاید اصلی](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) تم، قالب‌بندی به‌اشتراک‌گذاری‌شده، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
1. یک [اسلاید طرح](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/) به یک اسلاید اصلی تعلق دارد و آرایش خاصی از فضاهای نگهدارنده را تعریف می‌کند.
1. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) از یک طرح استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌نماید.

یک اسلاید عادی تم و قالب‌بندی را از طرح خود به ارث می‌برد و طرح نیز از اسلاید اصلی به ارث می‌برد. مقداری که به‌صورت مستقیم بر روی اسلاید عادی تنظیم شود، مقدار به‌ارث‌برده را در همان سطح بازنویسی می‌کند. هنگامی که یک اسلاید عادی ایجاد می‌شود، اشکال فضاهای نگهدارنده آن از طرح انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده به آن فضاهای نگهدارنده متعلق به اسلاید عادی است.

پیش از ایجاد اسلایدها از یک طرح، فضاهای نگهدارنده موردنیاز را به آن اضافه کنید. افزودن فضا نگهدارندهٔ دیگر به یک طرح بعداً به‌صورت خودکار فضاهای نگهدارندهٔ متناظر را به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی به‌ارث‌برده یا هندسهٔ فضاهای نگهدارندهٔ موجود در یک طرح می‌تواند تمام اسلایدهایی را که به آن وابسته‌اند به‌روز کند. پیش از ویرایش طرحی که در حال استفاده است، اسلایدهای وابسته را بررسی کنید و ارائهٔ حاصل را بازبینی کنید.
- طرحی که هنوز توسط یک اسلاید استفاده می‌شود قابل حذف نیست. ابتدا اسلایدهای وابسته را به طرح دیگری اختصاص دهید یا فقط طرح‌های استفاده‌نشده را حذف کنید.

برای اطلاعات بیشتر دربارهٔ سطوح بالایی این سلسله‌مراتب، به [Slide Master](/slides/fa/net/slide-master/) مراجعه کنید.

برای مخفی کردن لوگوهای به‌ارث‌برده یا اشکال تزئینی اصلی بر روی یک اسلاید یا از طریق یک طرح مشترک، به [Control the Visibility of Master Graphics](/slides/fa/net/slide-master/) نگاه کنید. مثال دو اسلاید با یک اسلاید اصلی را مقایسه می‌کند.

## **انتخاب و اعمال یک طرح اسلاید**

زمانی که ارائه براساس تعریف‌های استاندارد طرح پاورپوینت پیش می‌رود، از نوع طرح استفاده کنید. نام‌های طرح قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر اساس نام تا زمانی که الگوی منبع را کنترل کنید، کمتر قابل اطمینان است.

مثال زیر به‌دنبال **Title and Content** در اولین اسلاید اصلی می‌گردد. اگر آن طرح در دسترس نباشد، عمدتاً به **Blank** باز می‌گردد. بررسی دوم برای مقدار null ضروری است زیرا یک ارائه می‌تواند فقط شامل طرح‌های سفارشی باشد. سپس طرح انتخاب‌شده از طریق ویژگی [ISlide.LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/layoutslide/) به اولین اسلاید عادی اعمال می‌شود.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

تغییر طرح اسلاید فضاهای نگهدارندهٔ معمولی که مستقیماً به اسلاید اضافه شده‌اند را حذف نمی‌کند. با این حال، موقعیت فضاهای نگهدارنده، قالب‌بندی به‌ارث‌برده و تطابق بین فضاهای نگهدارندهٔ موجود و طرح جدید می‌تواند تغییر کند، بنابراین خروجی را هنگام جابجا شدن بین طرح‌های به‌سختی متفاوت بررسی کنید.

## **افزودن یک اسلاید طرح**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح موجود را انتخاب کرد؛ آن را ایجاد نکرد. برای ایجاد یک طرح، متد [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/masterlayoutslidecollection/add/) را بر روی مجموعهٔ طرح‌های اسلاید اصلی هدف فراخوانی کنید.

مثال زیر همیشه یک طرح **Title and Content** جدید به نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید عادی بر پایهٔ آن می‌سازد. نام‌های طرح باید در مجموعه یکتا باشند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

فقط زمانی که الگوی قالب به‌طور واقعی به ساختار قابل استفادهٔ دیگری نیاز دارد، یک طرح اضافه کنید. اگر یک طرح مناسب پیشاپیش وجود داشته باشد، به‌جای ایجاد یک نسخهٔ تکراری، آن را انتخاب و مجدداً استفاده کنید.

## **افزودن فضاهای نگهدارنده به یک اسلاید طرح**

خصوصیت [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/placeholdermanager/) یک [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutplaceholdermanager/) را برای افزودن اشکال فضاهای نگهدارنده به یک طرح فراهم می‌کند.

| قاب نگهدارنده PowerPoint | متد `ILayoutPlaceholderManager` |
| -------------------------- | -------------------------------- |
| ![محتوا](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![محتوا (عمودی)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![متن](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![متن (عمودی)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![عکس](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![نمودار](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![جدول](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![رسانه](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![تصویر آنلاین](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

مثال زیر بررسی می‌کند که آیا طرح **Blank** وجود دارد، چهار فضا نگهدارنده به آن اضافه می‌کند و سپس یک اسلاید عادی ایجاد می‌کند که از طرح اصلاح‌شده استفاده می‌کند. ترتیب این کار عمدی است: فضاهای نگهدارنده پیش از ایجاد اسلاید عادی اضافه می‌شوند تا Aspose.Slides بتواند اشکال فضاهای نگهدارندهٔ متناظر را بر روی آن اسلاید تولید کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

نتیجه:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی به‌ارث‌برده یا هندسهٔ فضاهای نگهدارندهٔ طرح موجود می‌تواند بر اسلایدهای وابسته تأثیر بگذارد. فضا نگهدارندهٔ تازه اضافه‌شده به‌صورت خودکار به اسلایدهای عادی موجود اضافه نمی‌شود. تغییرات طرح را روی یک نسخهٔ کپی از ارائه تست کنید و هر اسلاید وابسته را بررسی کنید.
{{% /alert %}}

## **حذف اسلایدهای طرح استفاده‌نشده**

از متد [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) برای حذف طرح‌هایی که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد استفاده کنید. این متد طرح‌های هنوز در حال استفاده را دست‌نخورده می‌گذارد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

برای حذف یک طرح خاص، ابتدا از ویژگی [HasDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/hasdependingslides/) یا متد [GetDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/getdependingslides/) آن استفاده کنید. قبل از فراخوانی [ILayoutSlide.Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/remove/) اسلایدهای وابسته را به طرح دیگری اختصاص دهید. تلاش برای حذف یک طرح استفاده‌شده منجر به پرتاب [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی بر روی یک اسلاید طرح**

یک طرح پاورقی، شماره اسلاید و فضاهای نگهدارندهٔ تاریخ‑زمان خود را دارد. برای کنترل این فضاها برای یک طرح، از خصوصیت [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/headerfootermanager/) استفاده کنید. این قابلیت زمانی مفید است که به‌عنوان مثال، طرح‌های محتوا باید پاورقی نشان دهند ولی طرح‌های عنوان نه.

مثال زیر یک طرح را به‌صورت ایمن انتخاب می‌کند و عناصر پاورقی آن را قابل مشاهده می‌سازد:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **کنترل نمایش پاورقی بر روی یک اسلاید اصلی و طرح‌های فرزند آن**

برای اعمال تنظیمات یکسان پاورقی در سراسر سلسله‌مراتب یک اسلاید اصلی، از خصوصیت [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/headerfootermanager/) استفاده کنید. متدهای انتشار [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslideheaderfootermanager/) بر روی اسلاید اصلی، اسلایدهای طرح وابسته و اسلایدهای عادی آن اعمال می‌شوند؛ نه فقط یک اسلاید عادی.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **سؤالات متداول**

**تفاوت اسلاید اصلی و اسلاید طرح چیست؟**

اسلاید اصلی تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح به یک اسلاید اصلی تعلق دارد و یک آرایش قابل استفادهٔ فضاهای نگهدارنده را تعیین می‌کند. اسلایدهای عادی از این طرح‌ها استفاده می‌کنند و محتوای مختص اسلاید را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله. با متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/globallayoutslidecollection/addclone/) یک کپی به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، قلم‌ها، تم‌ها، تصویرها و دیگر منابع مورد استفادهٔ طرح منبع را نیز بررسی کنید.

**هنگام اصلاح یک طرح که هم‌اکنون در حال استفاده است چه اتفاقی می‌افتد؟**

اسلایدهای وابسته تغییرات طرح را به‌ارث می‌برند مگر این‌که قالب‌بندی یا اشیای تحت‌نظر را به‌صورت محلی بازنویسی کرده باشند. بنابراین هندسهٔ فضاهای نگهدارنده و سبک‌های به‌ارث‌برده می‌تواند به‌یکباره بر بسیاری از اسلایدها تغییر کند. پیش از ویرایش طرح، با استفاده از [GetDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/getdependingslides/) اسلایدهای تحت‌تأثیر را شناسایی کنید.

**اگر یک طرح که هنوز استفاده می‌شود را حذف کنم چه می‌شود؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را به طرح دیگری اختصاص دهید یا با استفاده از [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) فقط طرح‌های بدون ارجاع را حذف کنید.