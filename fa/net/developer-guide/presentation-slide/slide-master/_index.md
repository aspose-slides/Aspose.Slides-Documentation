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
- چندین اسلاید مستر
- مقایسه اسلایدهای مستر
- پس‌زمینه
- جای‌گیر
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
## **مروری کلی**

یک **اسلاید مستر** تنظیمات طراحی مشترک برای گروهی از اسلایدها را تعریف می‌کند. می‌تواند شامل اشکال مشترک، لوگوها، پس‌زمینه‌ها، سبک‌های متن، تنظیمات قالب و تنظیمات فوتر باشد. در PowerPoint، ویرایش اسلاید مستر راه معمول برای حفظ یکپارچگی ارائه بدون تکرار همان قالب‌بندی روی هر اسلاید است.

Aspose.Slides for .NET مدل مشابهی را پشتیبانی می‌کند. یک ارائه می‌تواند یک یا چند اسلاید مستر داشته باشد و هر اسلاید مستر می‌تواند چندین اسلاید لِی‌آوت داشته باشد. اسلایدهای معمولاً به‌صورت مستقیم به اسلاید مستر ارجاع نمی‌دهند. در عوض، یک اسلاید معمولی از یک اسلاید لِی‌آوت استفاده می‌کند و آن لِی‌آوت متعلق به یک اسلاید مستر است.

سلسله‌مراتب به این صورت است:

1. **اسلاید مستر** – تنظیمات طراحی و قالب مشترک را تعریف می‌کند.  
1. **اسلاید لِی‌آوت** – ترتیب خاصی از جای‌گیرها و قالب‌بندی سطح لِی‌آوت را تعریف می‌کند.  
1. **اسلاید معمولی** – محتوای واقعی ارائه را دربر می‌گیرد و از یک اسلاید لِی‌آوت استفاده می‌کند.

![سلسله‌مراتب اسلایدهای مستر، اسلایدهای لِی‌آوت و اسلایدهای معمولی](slide-master_2.jpg)

در Aspose.Slides، یک اسلاید مستر توسط رابط [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) نمایان می‌شود. تمام اسلایدهای مستر در یک ارائه از طریق مجموعه [Presentation.Masters](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/masters/) در دسترس هستند که رابط [IMasterSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/) را پیاده‌سازی می‌کند.

{{% alert color="info" title="Inheritance" %}}
هنگامی که یک ویژگی در بیش از یک سطح تعریف شود، سطح خاص‌تر برنده است. به عنوان مثال، اگر یک اسلاید مستر و یک اسلاید لِی‌آوت هر دو پس‌زمینه‌ای تعریف کنند، اسلایدهای مبتنی بر آن لِی‌آوت از پس‌زمینه لِی‌آوت استفاده می‌کنند. برای اطلاعات بیشتر درباره اسلایدهای لِی‌آوت، به [Apply or Change Slide Layouts](/slides/fa/net/slide-layout/) مراجعه کنید.
{{% /alert %}}

## **دسترسی به اسلایدهای مستر**

در PowerPoint می‌توانید نمای اسلاید مستر را از **View** > **Slide Master** باز کنید.

![دکمه Slide Master در برگه View نرم‌افزار PowerPoint](slide-master_3.jpg)

در Aspose.Slides، برای دسترسی به اسلایدهای مستر از مجموعه `Masters` استفاده کنید:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

همچنین می‌توانید اسلاید مستری که توسط یک اسلاید معمولی استفاده می‌شود را از طریق لِی‌آوت آن به‌دست آورید:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **محتوای یک اسلاید مستر**

یک اسلاید مستر یک شیء شبیه اسلاید است. این شیء رابط [IBaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/) را پیاده‌سازی می‌کند، بنابراین بسیاری از ویژگی‌های اسلاید که در اسلایدهای معمولی و لِی‌آوت استفاده می‌شوند، در دسترس است. اعضای خاص مستر در صفحه API [IMasterSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslide/) فهرست شده‌اند.

عضوهای پرکاربرد اسلاید مستر عبارتند از:

| Member | Purpose |
| --- | --- |
| `Background` | پس‌زمینه سطح مستر را تنظیم می‌کند. |
| `Shapes` | اشکالی که روی مستر قرار گرفته‌اند (مانند لوگوها، فریم‌های تصویری و متن‌های مشترک) را ذخیره می‌کند. |
| `LayoutSlides` | اسلایدهای لِی‌آوت متعلق به مستر را نگه می‌دارد. |
| `ThemeManager` | دسترسی به APIهای قالب مستر را فراهم می‌آورد. |
| `HeaderFooterManager` | سرصفحه‌ها، فوترها، تاریخ‌ها و شماره اسلایدها را برای مستر و لِی‌آوت‌های فرزندش کنترل می‌کند. |
| `GetDependingSlides` | اسلایدهای معمولی که از طریق لِی‌آوت به این مستر وابسته‌اند را برمی‌گرداند. |

## **افزودن تصویر به اسلاید مستر**

هنگامی که تصویری را به یک اسلاید مستر اضافه می‌کنید، در اسلایدهایی که از لِی‌آوت‌های آن مستر استفاده می‌کنند ظاهر می‌شود. این کار برای لوگوها، واترمارک‌ها، نوارهای تزئینی و سایر عناصر بصری تکراری مفید است.

مثال زیر یک لوگو را به اولین اسلاید مستر اضافه می‌کند:

```csharp
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

برای اطلاعات بیشتر درباره فریم‌های تصویری، به [Picture Frame](/slides/fa/net/picture-frame/) مراجعه کنید.

## **کار با جای‌گیرها**

جای‌گیرها معمولاً در اسلایدهای لِی‌آوت تعریف می‌شوند. اسلاید مستر سبک و قالب مشترکی را که این لِی‌آوت‌ها به ارث می‌برند، فراهم می‌کند؛ هر لِی‌آوت تصمیم می‌گیرد کدام جای‌گیرها موجود هستند و در کجا قرار می‌گیرند.

در PowerPoint، دستورات جای‌گیر در نمای اسلاید مستر در دسترس هستند.

![دستور Insert Placeholder در نمای Slide Master نرم‌افزار PowerPoint](slide-master_5.png)

برای افزودن جای‌گیرهای جدید با Aspose.Slides، با اسلاید لِی‌آوت متعلق به مستر کار کنید:

```csharp
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

همچنین می‌توانید اشکال جای‌گیر موجود در یک اسلاید مستر را قالب‌بندی کنید. مثال زیر جای‌گیر عنوان را پیدا کرده و پر شدگی گرادیان خطی اعمال می‌کند:

```csharp
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

![جای‌گیر عنوان قالب‌بندی‌شده که توسط اسلایدهای معمولی به ارث می‌رسد](slide-master_8.png)

برای گزینه‌های بیشتر قالب‌بندی جای‌گیر و متن، به [Set Prompt Text in Placeholder](/slides/fa/net/manage-placeholder/) و [Text Formatting](/slides/fa/net/text-formatting/) مراجعه کنید.

## **تغییر پس‌زمینه اسلاید مستر**

یک پس‌زمینه مستر توسط لِی‌آوت‌ها و اسلایدهایی که آن را بازنویسی نکنند، ارث‌بری می‌شود. مثال زیر رنگ پس‌زمینه‌ی ثابت را برای اولین اسلاید مستر تنظیم می‌کند:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

برای موضوعات مرتبط، به [Presentation Background](/slides/fa/net/presentation-background/) و [Presentation Theme](/slides/fa/net/presentation-theme/) نگاه کنید.

## **کلون کردن اسلاید مستر به ارائه دیگر**

از [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterslidecollection/addclone/) برای کپی یک اسلاید مستر به ارائه دیگری استفاده کنید. مستر کپی‌شده سپس می‌تواند توسط لِی‌آوت‌ها و اسلایدهای مقصد استفاده شود.

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

اگر نیاز به کلون کردن اسلایدهای معمولی همراه با مسترشان دارید، به [Clone Slides](/slides/fa/net/clone-slides/) مراجعه کنید.

## **افزودن چندین اسلاید مستر**

یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. این ویژگی وقتی مفید است که بخش‌های مختلف نیاز به برندینگ، ساختار صفحه یا تنظیمات قالب متفاوت داشته باشند.

![دستورات PowerPoint برای افزودن و مدیریت اسلایدهای مستر](slide-master_9.jpg)

مثال زیر مستر پیش‌فرض را کلون می‌کند، پس‌زمینه‌ی متفاوتی به کلون می‌دهد، یک لِی‌آوت زیر آن مستر کلون‌شده ایجاد می‌کند و اسلاید جدیدی بر پایه آن لِی‌آوت اضافه می‌نماید:

```csharp
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

اسلایدهای مستر می‌توانند با متد `Equals` که از [IBaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseslide/) به ارث می‌برد، مقایسه شوند. این مقایسه ساختار و محتوای ثابت مانند اشکال، متن، قالب‌بندی، انیمیشن‌ها و سایر تنظیمات اسلاید را بررسی می‌کند. شناسه‌های منحصربه‌فرد مانند شناسه اسلاید یا مقادیر جای‌گیرهای پویا (مثلاً تاریخ جاری) در این مقایسه در نظر گرفته نمی‌شوند.

```csharp
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

برای اطلاعات بیشتر، به [Compare Presentation Slides](/slides/fa/net/compare-slides/) مراجعه کنید.

## **تنظیم نمای اسلاید مستر به عنوان نمای پیش‌فرض**

از ویژگی `LastView` در [ViewProperties](https://reference.aspose.com/slides/fa/net/aspose.slides/viewproperties/) برای تعیین نمایی که PowerPoint ابتدا باز می‌کند، استفاده کنید. مثال زیر ارائه را در نمای اسلاید مستر باز می‌کند:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

برای تنظیمات نمای بیشتر، به [Save Presentation](/slides/fa/net/save-presentation/) نگاه کنید.

## **حذف اسلایدهای مستر استفاده‌نشده**

گاهی اوقات ارائه‌ها شامل اسلایدهای مستری می‌شوند که دیگر توسط هیچ اسلاید معمولی استفاده نمی‌شوند. حذف مسترهای استفاده‌نشده می‌تواند اندازه فایل را کاهش داده و نگهداری قالب را ساده‌تر کند.

از [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/fa/net/aspose.slides/masterslidecollection/removeunused/) برای حذف مسترهای استفاده‌نشده از مجموعه `Masters` استفاده کنید:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

همچنین می‌توانید از متد کم‌کد [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) بهره بگیرید:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **سؤالات متداول**

**تفاوت اسلاید مستر و اسلاید لِی‌آوت چیست؟**

اسلاید مستر تنظیمات طراحی مشترکی مانند قالب، پس‌زمینه، اشکال عمومی و سبک‌های متن را تعریف می‌کند. اسلاید لِی‌آوت متعلق به یک اسلاید مستر است و ترتیب خاصی از جای‌گیرها را مشخص می‌کند. یک اسلاید معمولی از یک اسلاید لِی‌آوت استفاده می‌کند، بنابراین هم از لِی‌آوت و هم از مستر ارث می‌برد.

**آیا یک ارائه می‌تواند چندین اسلاید مستر داشته باشد؟**

بله. یک ارائه می‌تواند شامل چندین اسلاید مستر باشد. زمانی که بخش‌های مختلف نیاز به سیستم‌های بصری یا برندینگ متفاوتی دارند، از چندین مستر استفاده کنید.

**آیا باید جای‌گیرها را به اسلاید مستر اضافه کنم یا به اسلاید لِی‌آوت؟**

در اکثر موارد، جای‌گیرها را به اسلایدهای لِی‌آوت اضافه کنید. عناصر بصری مشترک و قالب‌بندی‌های عمومی را روی مستر قرار دهید، سپس جای‌گیرهای محتوایی را روی لِی‌آوت‌هایی که اسلایدهای معمولی از آن‌ها استفاده می‌کنند، بگذارید.

**آیا می‌توانم اسلاید مستری را که هنوز استفاده می‌شود حذف کنم؟**

خیر. اسلاید مستری که اسلایدهای وابسته دارد، نمی‌تواند به‌صورت مستقیم حذف شود. ابتدا آن اسلایدها را به لِی‌آوت‌های تحت مستر دیگری منتقل کنید یا از روش پاک‌سازی مسترهای استفاده‌نشده استفاده کنید که تنها مسترهای بدون استفاده را حذف می‌کند.