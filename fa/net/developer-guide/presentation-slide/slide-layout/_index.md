---
title: اعمال یا تغییر طرح‌های اسلاید در .NET
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/net/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- placeholder
- طراحی ارائه
- طراحی اسلاید
- طرح بلااستفاده
- قابلیت نمایش فوتر
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوایی
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با کپشن
- عکس با کپشن
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- C#
- .NET
- Aspose.Slides
description: "اعمال، ایجاد و ویرایش طرح‌های اسلاید در Aspose.Slides برای .NET، افزودن placeholderها، حذف طرح‌های بلااستفاده و کنترل نمایش فوتر."
---
## **مروری کلی**

طرح اسلاید موقعیت‌ها و قالب‌بندی placeholderهایی مانند عناوین، متن، تصاویر، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح به اسلایدها ساختار ثابتی می‌بخشد در حالی که به هر اسلاید اجازه می‌دهد محتوای خود را داشته باشد.

متداول‌ترین طرح‌ها شامل:

- **Title Slide**: شامل placeholderهای عنوان و زیرعنوان است.
- **Title and Content**: شامل یک placeholder عنوان و یک placeholder محتوا با کاربرد عمومی است.
- **Blank**: بدون placeholderهای محتوا است و زمانی مفید است که هر شکل به‌صورت دستی موقعیت‌یابی شود.

## **درک وراثت طرح**

یک ارائه سه سطح مرتبط دارد:

1. A [master slide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیاء عمومی را تعریف می‌کند.
2. A [layout slide](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/) متعلق به یک master است و یک چینش خاص از placeholderها را تعریف می‌کند.
3. A [normal slide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/) از یک layout استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌سازد.

یک اسلاید عادی تم و قالب‌بندی را از layout خود به ارث می‌برد و layout از master خود به ارث می‌برد. مقداری که مستقیماً روی اسلاید عادی تنظیم شود، مقدار ارث‌بری در همان سطح را بازنویسی می‌کند. وقتی یک اسلاید عادی ایجاد می‌شود، شکل‌های placeholder آن از layout انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده در آن placeholderها متعلق به اسلاید عادی است.

قبل از ایجاد اسلایدها، placeholderهای مورد نیاز را به یک layout اضافه کنید. افزودن placeholder دیگر به یک layout بعداً به‌صورت خودکار شکل placeholder متناظر را به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌بری یا هندسه placeholderهای موجود در یک layout می‌تواند هر اسلایدی را که به آن وابسته است به‌روز کند. قبل از ویرایش یک layout که در حال استفاده است، اسلایدهای وابسته را بررسی کنید و ارائه نهایی را مرور کنید.
- یک layout که هنوز توسط اسلایدی استفاده می‌شود نمی‌تواند حذف شود. پیش از حذف، اسلایدهای وابسته را به layout دیگری اختصاص دهید یا فقط layoutهای بلااستفاده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالایی این سلسله‌ مراتب، ببینید [Slide Master](/slides/fa/net/slide-master/).

## **انتخاب و اعمال یک طرح اسلاید**

هنگامی که ارائه از تعاریف استاندارد layoutهای PowerPoint پیروی می‌کند، از یک نوع layout استفاده کنید. نام‌های layout قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر اساس نام کمتر قابل اعتماد است مگر آنکه الگوی منبع را کنترل کنید.

مثال زیر به دنبال **Title and Content** در اولین master می‌گردد. اگر آن layout در دسترس نباشد، عمداً به **Blank** بازمی‌گردد. بررسی null دوم ضروری است زیرا یک ارائه می‌تواند فقط layoutهای سفارشی داشته باشد. سپس layout انتخاب‑شده از طریق ویژگی [ISlide.LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/layoutslide/) به اولین اسلاید عادی اعمال می‌شود.

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

تغییر layout یک اسلاید placeholderهای عادی افزودنی مستقیماً به اسلاید را حذف نمی‌کند. با این حال، موقعیت placeholderها، قالب‌بندی ارث‌بری و مطابقت بین placeholderهای موجود و layout جدید می‌تواند تغییر کند، بنابراین هنگام جابجایی بین layoutهای به‌طور قابل توجه متفاوت، خروجی را بررسی کنید.

## **افزودن یک طرح اسلاید**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک layout موجود را انتخاب می‌کرد؛ آن را ایجاد نمی‌کرد. برای ساخت یک layout، متد [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/fa/net/aspose.slides/masterlayoutslidecollection/add/) را بر روی مجموعه layoutهای master هدف صدا بزنید.

مثال زیر همیشه یک layout جدید **Title and Content** با نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید عادی بر پایه آن می‌سازد. نام‌های layout باید درون مجموعه یکتا باشند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

فقط زمانی layout اضافه کنید که الگو واقعاً به ساختار قابل‌استفادهٔ دیگری نیاز داشته باشد. اگر layout مناسبی از پیش وجود دارد، به‌جای ایجاد یک تکراری، آن را انتخاب و مجدداً استفاده کنید.

## **افزودن Placeholderها به یک طرح اسلاید**

ویژگی [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/placeholdermanager/) یک [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutplaceholdermanager/) را برای افزودن شکل‌های placeholder به یک layout فراهم می‌کند.

| PowerPoint Placeholder | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
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

مثال زیر وجود layout **Blank** را تأیید می‌کند، چهار placeholder به آن اضافه می‌کند و سپس یک اسلاید عادی که از layout اصلاح‌شده استفاده می‌کند ایجاد می‌نماید. ترتیب عمدی است: قبل از ایجاد اسلاید عادی placeholderها افزوده می‌شوند تا Aspose.Slides بتواند شکل‌های placeholder متناظر را روی آن اسلاید تولید کند.

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

![Placeholderها بر روی اسلاید طرح](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی ارث‌بری یا هندسهٔ placeholderهای موجود در یک layout می‌تواند بر اسلایدهای وابسته اثر بگذارد. یک placeholder جدید به layout به‌صورت خودکار به اسلایدهای عادی موجود افزوده نمی‌شود. تغییرات layout را روی یک کپی از ارائه تست کنید و هر اسلاید وابسته را بررسی کنید.
{{% /alert %}}

## **حذف طرح‌های اسلایدی که استفاده نشده‌اند**

از متد [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) برای حذف layoutهایی که هیچ اسلاید عادی آن‌ها را ارجاع نمی‌دهد استفاده کنید. این متد layoutهای همچنان در استفاده را دست‌نخورده می‌گذارد.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

برای حذف یک layout خاص، ابتدا ویژگی [HasDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/hasdependingslides/) یا متد [GetDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/getdependingslides/) آن را بررسی کنید. قبل از صدا زدن [ILayoutSlide.Remove](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/remove/) هر اسلاید وابسته‌ای را به layout دیگری اختصاص دهید. تلاش برای حذف یک layout که در حال استفاده است، یک [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception/) ایجاد می‌کند.

## **کنترل نمایش زیرنویس در یک طرح اسلاید**

یک layout دارای placeholderهای خود برای فوتر، شماره اسلاید و تاریخ‑زمان است. برای کنترل این placeholderها برای یک layout از ویژگی [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/headerfootermanager/) استفاده کنید. این موارد زمانی مفید است که مثلاً layoutهای محتوا باید فوتر داشته باشند ولی layoutهای عنوان نباید.

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

## **کنترل نمایش زیرنویس در یک Master و طرح‌های فرزند آن**

برای اعمال تنظیمات فوتر یکسان در سراسر سلسله‌مراتب master، از ویژگی [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/headerfootermanager/) استفاده کنید. متدهای انتشار [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslideheaderfootermanager/) بر روی master و layoutهای وابسته و اسلایدهای عادی آن عمل می‌کنند؛ فقط یک اسلاید عادی هدف‌گیری نمی‌شوند.

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

## **سوالات متداول**

**تفاوت بین Master Slide و Layout Slide چیست؟**

Master Slide تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. Layout Slide به یک master تعلق دارد و یک چینش قابل‌استفادهٔ مجدد از placeholderها را تعریف می‌کند. اسلایدهای عادی از آن layoutها استفاده می‌کنند و محتواهای خاص خود را ذخیره می‌سازند.

**آیا می‌توانم یک Layout Slide را از یک ارائه به ارائه دیگر کپی کنم؟**

بله. با متد [AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/globallayoutslidecollection/addclone/) یک کپی به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصاویر و سایر منابعی که layout منبع استفاده می‌کند را نیز بررسی کنید.

**چه اتفاقی می‌افتد وقتی طرحی را که در حال استفاده است تغییر می‌دهم؟**

اسلدهای وابسته تغییرات layout را به‌ارث می‌برند مگر اینکه قالب‌بندی یا اشیاء مورد اثر را به‌صورت محلی بازنویسی کرده باشند. بنابراین هندسه placeholderها و استایل‌های ارث‌بری می‌توانند به‌طور همزمان روی بسیاری از اسلایدها تغییر کنند. قبل از ویرایش layout، با استفاده از [GetDependingSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/getdependingslides/) اسلدهای تحت تأثیر را شناسایی کنید.

**چه اتفاقی می‌افتد اگر layoutی را که هنوز استفاده می‌شود حذف کنم؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلدهای وابسته را به layout دیگری اختصاص دهید یا از [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) برای حذف فقط layoutهای بلااستفاده استفاده کنید.