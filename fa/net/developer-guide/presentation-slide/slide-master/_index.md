---
title: مدیریت اسلاید مسترهای ارائه در .NET
linktitle: اسلاید مستر
type: docs
weight: 80
url: /fa/net/slide-master/
keywords:
- اسلاید مستر
- اسلاید مستر
- اسلاید مستر PPT
- اسلایدهای مستر متعدد
- مقایسه اسلایدهای مستر
- پس‌زمینه
- نگهدارنده
- کلون اسلاید مستر
- کپی اسلاید مستر
- تکثیر اسلاید مستر
- اسلاید مستر استفاده‌نشده
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "مدیریت اسلاید مسترها در Aspose.Slides برای .NET: دسترسی، ویرایش، کلون، مقایسه و حذف اسلایدهای مستر در ارائه‌های PowerPoint و OpenDocument."
---
## **نمای کلی**

**اسلاید مستر** یک مجموعه تنظیمات طراحی مشترک برای گروهی از اسلایدها را تعریف می‌کند. می‌تواند شامل شکل‌های مشترک، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات تم و تنظیمات فوتر باشد. در PowerPoint، ویرایش یک اسلاید مستر روش معمول برای حفظ یکپارچگی ارائه بدون تکرار همان قالب‌بندی در هر اسلاید است.

Aspose.Slides for .NET مدل مشابهی را پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید مستر داشته باشد و هر اسلاید مستر می‌تواند شامل چندین اسلاید چیدمان باشد. اسلایدهای معمولاً به‌طور مستقیم به اسلاید مستر ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک اسلاید چیدمان استفاده می‌کند و آن اسلاید چیدمان به یک اسلاید مستر تعلق دارد.

سلسله‌مراتبی به شرح زیر است:

1. **اسلاید مستر** – طراحی و تم مشترک را تعریف می‌کند.  
1. **اسلاید چیدمان** – چیدمان خاصی از نگهدارنده‌ها و قالب‌بندی سطح چیدمان را تعریف می‌کند.  
1. **اسلاید معمولی** – محتویات واقعی ارائه را شامل می‌شود و از یک اسلاید چیدمان استفاده می‌کند.

![سلسله‌مراتبی اسلایدهای مستر، اسلایدهای چیدمان و اسلایدهای معمولی](slide-master_2.jpg)

در Aspose.Slides، یک اسلاید مستر توسط اینترفیس [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) نمایان می‌شود. تمام اسلایدهای مستر در یک ارائه از طریق مجموعه‌ی [Presentation.Masters](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/masters/) در دسترس هستند که پیاده‌سازی [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/) را فراهم می‌کند.

{{% alert color="info" title="Inheritance" %}}
هنگامی که یک خصوصیت در بیش از یک سطح تعریف شود، سطح خاص‌تر برتری دارد. برای مثال، اگر یک اسلاید مستر و یک اسلاید چیدمان هر دو پس‌زمینه‌ای را تعریف کنند، اسلایدهای مبتنی بر آن چیدمان پس‌زمینه‌ی چیدمان را استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای چیدمان، به [اعمال یا تغییر چیدمان اسلاید](/slides/fa/net/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به اسلایدهای مستر**

در PowerPoint، می‌توانید نمای اسلاید مستر را از **View** > **Slide Master** باز کنید.

![دستوری اسلاید مستر در برگه View برنامه PowerPoint](slide-master_3.jpg)

در Aspose.Slides، از مجموعه `Masters` برای دسترسی به اسلایدهای مستر استفاده کنید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

همچنین می‌توانید اسلاید مستری که یک اسلاید معمولی از آن استفاده می‌کند را از طریق چیدمان آن دریافت کنید:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **محتویات یک اسلاید مستر**

اسلاید مستر یک شیء شبیه اسلاید است. این شیء اینترفیس [IBaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/) را پیاده‌سازی می‌کند، بنابراین بسیاری از خصوصیات اسلایدی که توسط اسلایدهای معمولی و چیدمان استفاده می‌شود را در اختیار می‌گذارد. اعضای خاص مستر در صفحه API [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) فهرست شده‌اند.

اعضای معمولاً مورد استفاده‌ی اسلاید مستر شامل موارد زیر هستند:

| عضو | هدف |
| --- | --- |
| `Background` | پس‌زمینه سطح مستر را تنظیم می‌کند. |
| `Shapes` | شکل‌های قرارگرفته بر روی مستر را ذخیره می‌کند، مانند لوگوها، قاب‌های تصویر و متن‌های مشترک. |
| `LayoutSlides` | اسلایدهای چیدمان متعلق به مستر را نگهداری می‌کند. |
| `ThemeManager` | دسترسی به API‌های تم مستر را فراهم می‌آورد. |
| `HeaderFooterManager` | سرصفحه‌ها، پاورقی‌ها، تاریخ‌ها و شماره اسلایدها را برای مستر و چیدمان‌های فرزند کنترل می‌کند. |
| `GetDependingSlides` | اسلایدهای معمولی که از طریق چیدمان‌ها به مستر وابسته‌اند را برمی‌گرداند. |

## **افزودن تصویر به اسلاید مستر**

هنگامی که تصویری را به یک اسلاید مستر اضافه می‌کنید، در اسلایدهایی که از چیدمان‌های آن مستر استفاده می‌کنند ظاهر می‌شود. این امر برای لوگوها، علامت‌های آب‌نمایی، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین اسلاید مستر اضافه می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

برای اطلاعات بیشتر درباره قاب‌های تصویر، به [قاب تصویر](/slides/fa/net/picture-frame/) مراجعه کنید.

## **کنترل نمایش گرافیک‌های مستر**

از متد [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/showmastershapes/) برای پنهان کردن گرافیک‌های وراثتی مستر، مانند لوگوها یا شکل‌های تزئینی، بدون حذف آن‌ها از مستر استفاده کنید. مقدار `false` را برای [Slide.ShowMasterShapes](https://reference.aspose.com/slides/fa/net/aspose.slides/slide/showmastershapes/) روی اسلایدی که باید این گرافیک‌ها را حذف کند تنظیم کنید و برای اسلایدهایی که باید نمایش داده شوند مقدار `true` را نگه دارید.

مثال زیر یک نوار تزئینی آبی را بر روی یک مستر و دو اسلایدی که همان چیدمان خالی را استفاده می‌کنند، ایجاد می‌کند. این نوار در اسلاید اول قابل مشاهده و در اسلاید دوم مخفی است. هیچ ارائه یا تصویری به عنوان ورودی لازم نیست.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

این مثال از چیدمان **Blank** که همراه با یک ارائه جدید فراهم می‌شود استفاده می‌کند و نگهدارنده‌های اسلاید اولیه را حذف می‌کند.

### **انتخاب دامنه تنظیم**

یک اسلاید معمولی از مستر خود از طریق [ISlide.LayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/islide/layoutslide/) و [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/masterslide/) استفاده می‌کند. تنظیم این خصوصیت بر روی یک اسلاید منفرد فقط بر همان اسلاید اثر می‌گذارد. تنظیم [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/fa/net/aspose.slides/layoutslide/showmastershapes/) به `false` گرافیک‌های مستر را برای تمام اسلایدهایی که از آن چیدمان مشترک استفاده می‌کنند مخفی می‌کند، حتی اگر تنظیم خود اسلاید `true` باشد. برای مخفی کردن گرافیک‌ها فقط در یک اسلاید، خصوصیت اسلاید را تغییر دهید و چیدمان مشترک را دست نخورده باقی بگذارید.

این تنظیم به‌عنوان کنترل نمایش بر روی خود اسلاید مستر پشتیبانی نمی‌شود. در مستر همیشه مقدار `false` برگردانده می‌شود و اختصاص مقدار `true` منجر به بروز `NotSupportedException` می‌شود. بهتر است این خصوصیت را بر روی یک اسلاید معمولی یا یک چیدمان اعمال کنید.

### **تشخیص گرافیک‌ها از پس‌زمینه**

| عملیات | اثر |
| --- | --- |
| پنهان کردن گرافیک‌های مستر | نمایش گرافیک‌های وراثتی مستر را بدون حذف آن‌ها یا تغییر شکل‌های اسلاید خود کنترل می‌کند. |
| تغییر پر کردن پس‌زمینه اسلاید | رنگ، گرادیان یا تصویر پس‌زمینه را تغییر می‌دهد. گرافیک‌های مستر شکل‌های جداگانه‌ای هستند و می‌توانند بر روی آن پس‌زمینه قابل مشاهده بمانند. برای جزئیات بیشتر به [پس‌زمینه ارائه](/slides/fa/net/presentation-background/) مراجعه کنید. |
| حذف یک شکل از مستر | شکل منبع مشترک را حذف می‌کند، بنابراین برای هیچ اسلایدی که از آن مستر استفاده می‌کند در دسترس نیست. |

## **کار با نگهدارنده‌ها**

نگهدارنده‌ها به‌صورت معمول در اسلایدهای چیدمان تعریف می‌شوند. اسلاید مستر سبک و تم مشترکی را فراهم می‌کند که این چیدمان‌ها از آن ارث می‌برند، در حالی که هر چیدمان تصمیم می‌گیرد کدام نگهدارنده‌ها در دسترس هستند و در کجا قرار گیرند.

در PowerPoint، دستورات نگهدارنده در نمای اسلاید مستر موجود است.

![دستور Insert Placeholder در نمای اسلاید مستر PowerPoint](slide-master_5.png)

برای افزودن نگهدارنده‌های جدید با Aspose.Slides، بر روی اسلاید چیدمان که به مستر تعلق دارد کار کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

همچنین می‌توانید شکل‌های نگهدارنده‌ای که از قبل روی یک اسلاید مستر وجود دارند را قالب‌بندی کنید. مثال زیر نگهدارنده عنوان را پیدا کرده و پر کردن گرادیان خطی به آن اعمال می‌کند:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![نگهدارنده عنوان قالب‌بندی شده که توسط اسلایدهای معمولی به ارث می‌رسد](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی نگهدارنده و متن، به [تنظیم متن پیش‌فرض در نگهدارنده](/slides/fa/net/manage-placeholder/) و [قالب‌بندی متن](/slides/fa/net/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینه اسلاید مستر**

پس‌زمینه مستر توسط چیدمان‌ها و اسلایدهایی که آن را بازنویسی نمی‌کنند، وراثت می‌یابد. مثال زیر رنگ پس‌زمینه‌ی ثابت را برای اولین اسلاید مستر تنظیم می‌کند:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

برای موضوعات مرتبط، به [پس‌زمینه ارائه](/slides/fa/net/presentation-background/) و [تم ارائه](/slides/fa/net/presentation-theme/) نگاه کنید.

## **کلون کردن اسلاید مستر به ارائه‌ای دیگر**

از متد [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) برای کپی کردن یک اسلاید مستر به یک ارائه دیگر استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط چیدمان‌ها و اسلایدهای موجود در ارائه مقصد استفاده شود.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

اگر نیاز به کلون کردن اسلایدهای معمولی همراه با مسترهایشان دارید، به [کلون کردن اسلایدها](/slides/fa/net/clone-slides/) مراجعه کنید.

## **افزودن چندین اسلاید مستر**

یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. این ویژگی برای بخش‌هایی که نیاز به برندینگ، ساختار صفحه یا تنظیمات تم متفاوت دارند مفید است.

![دستورات PowerPoint برای درج و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، پس‌زمینه‌ای متفاوت به کلون می‌دهد، یک چیدمان تحت آن مستر کلون شده ایجاد می‌کند و اسلاید جدیدی بر پایه آن چیدمان اضافه می‌نماید:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **مقایسه اسلایدهای مستر**

اسلایدهای مستر می‌توانند با متد `Equals` که از [IBaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/) به ارث برده شده است مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند شکل‌ها، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های یکتای اسلاید مانند شناسه‌های اسلاید یا مقادیر دینامیک نگهدارنده‌ها مثل تاریخ جاری در مقایسه در نظر گرفته نمی‌شوند.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

برای اطلاعات بیشتر به [مقایسه اسلایدهای ارائه](/slides/fa/net/compare-slides/) مراجعه کنید.

## **تنظیم نمای اسلاید مستر به‌عنوان نمای پیش‌فرض**

از خصوصیت `LastView` در [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/) برای کنترل نمایی که PowerPoint ابتدا باز می‌کند استفاده کنید. مثال زیر ارائه را در نمای اسلاید مستر باز می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

برای تنظیمات بیشتر نمایی، به [ذخیره ارائه](/slides/fa/net/save-presentation/) نگاه کنید.

## **حذف اسلایدهای مستر استفاده‌نشده**

گاهی اوقات ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف مسترهای استفاده‌نشده می‌تواند حجم فایل را کاهش داده و نگهداری الگوها را ساده‌تر کند.

از متد [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/fa/net/aspose.slides/masterslidecollection/removeunused/) برای حذف مسترهای استفاده‌نشده از مجموعه `Masters` استفاده کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

همچنین می‌توانید از متد کم‌کد [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) استفاده کنید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **سوالات متداول**

**تفاوت اسلاید مستر و اسلاید چیدمان چیست؟**

اسلاید مستر تنظیمات طراحی مشترک مثل تم، پس‌زمینه، شکل‌های عمومی و سبک‌های متنی را تعریف می‌کند. اسلاید چیدمان به یک اسلاید مستر تعلق دارد و چیدمان خاصی از نگهدارنده‌ها را تعریف می‌کند. اسلاید معمولی یک اسلاید چیدمان را استفاده می‌کند، بنابراین از هر دو چیدمان و مستر وراثت می‌گیرد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. از مسترهای متعدد زمانی استفاده کنید که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوت داشته باشند.

**آیا باید نگهدارنده‌ها را به اسلاید مستر اضافه کنم یا به اسلاید چیدمان؟**

در اکثر موارد، نگهدارنده‌ها را به اسلایدهای چیدمان اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های مشترک را روی اسلاید مستر بگذارید، سپس نگهدارنده‌های محتوا را روی چیدمان‌هایی که اسلایدهای معمولی از آنها استفاده می‌کنند، قرار دهید.

**آیا می‌توانم یک اسلاید مستر را که هنوز استفاده می‌شود حذف کنم؟**

نه. اسلاید مستری که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم و ایمن حذف شود. ابتدا آن اسلایدها را به چیدمان‌های تحت مستر دیگری منتقل کنید یا از روش پاک‌سازی مسترهای استفاده‌نشده که فقط مسترهای بدون استفاده را حذف می‌کند، استفاده کنید.