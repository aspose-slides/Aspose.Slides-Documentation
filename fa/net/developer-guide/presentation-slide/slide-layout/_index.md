---
title: "اعمال یا تغییر طرح اسلایدها در .NET"
linktitle: "طرح اسلاید"
type: docs
weight: 60
url: /fa/net/slide-layout/
keywords:
  - "طرح اسلاید"
  - "طرح محتوا"
  - "جای‌دار"
  - "طراحی ارائه"
  - "طراحی اسلاید"
  - "طرح استفاده نشده"
  - "نمایش پابرگ"
  - "اسلاید عنوان"
  - "عنوان و محتوا"
  - "سرصفحه بخش"
  - "دو محتوا"
  - "مقایسه"
  - "فقط عنوان"
  - "طرح خالی"
  - "محتوا با برچسب"
  - "تصویر با برچسب"
  - "عنوان و متن عمودی"
  - "عنوان عمودی و متن"
  - "PowerPoint"
  - "OpenDocument"
  - "ارائه"
  - "C#"
  - ".NET"
  - "Aspose.Slides"
description: "طرح‌های اسلاید را در Aspose.Slides برای .NET مدیریت و سفارشی کنید. انواع طرح‌ها، کنترل جای‌دارها و نمایش پابرگ را با مثال‌های کد C# بررسی کنید."
---
## **معرفی**

یک طرح اسلاید ترتیب جعبه‌های جای‌دار و قالب‌بندی محتوا را بر روی اسلاید تعریف می‌کند. این طرح تعیین می‌کند کدام جای‌دارها در دسترس هستند و در کجا ظاهر می‌شوند. طرح‌های اسلاید به شما کمک می‌کنند تا ارائه‌ها را به سرعت و به‌صورت یکدست طراحی کنید—چه در حال ایجاد چیزی ساده باشید و چه پیچیده‌تر. برخی از رایج‌ترین طرح‌های اسلاید در PowerPoint شامل:

**طرح اسلاید عنوان** – شامل دو جای‌دار متن است: یکی برای عنوان و دیگری برای زیرعنوان.

**طرح اسلاید عنوان و محتوا** – شامل یک جای‌دار عنوان کوچک در بالا و یک جای‌دار بزرگ‌تر در زیر برای محتوای اصلی (مانند متن، نکات بولتی، نمودارها، تصاویر و دیگر موارد).

**طرح خالی** – هیچ جای‌داری ندارد و به شما کنترل کامل برای طراحی اسلاید از صفر می‌دهد.

طرح‌های اسلاید بخشی از اسلاید مستر هستند که اسلاید سطح بالایی است و سبک‌های طرح را برای ارائه تعریف می‌کند. می‌توانید طرح‌های اسلاید را از طریق اسلاید مستر دسترسی و ویرایش کنید—چه بر اساس نوع، نام یا شناسهٔ یکتا. به‌جای آن، می‌توانید یک اسلاید طرح خاص را مستقیماً داخل ارائه ویرایش کنید.

برای کار با طرح‌های اسلاید در Aspose.Slides برای .NET، می‌توانید از موارد زیر استفاده کنید:
- خصوصیات مانند [LayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/layoutslides/) و [Masters](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/masters/) در زیر کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) 
- انواع مانند [ILayoutSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/)، [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterlayoutslidecollection/)، [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutplaceholdermanager/)، و [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
برای آشنایی بیشتر با کار با اسلایدهای مستر، مقالهٔ [اسلاید مستر](/slides/fa/net/slide-master/) را ببینید.
{{% /alert %}}

## **افزودن طرح‌های اسلاید به ارائه‌ها**

برای سفارشی‌سازی ظاهر و ساختار اسلایدهای خود، ممکن است نیاز داشته باشید طرح‌های اسلاید جدیدی به یک ارائه اضافه کنید. Aspose.Slides برای .NET به شما این امکان را می‌دهد که بررسی کنید آیا یک طرح خاص قبلاً وجود دارد یا نه، در صورت نیاز یک طرح جدید اضافه کنید و از آن برای درج اسلایدهایی با آن طرح استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. به [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/net/aspose.slides/imasterlayoutslidecollection/) دسترسی پیدا کنید.
3. بررسی کنید آیا اسلاید طرح موردنظر در مجموعه موجود است یا خیر. اگر نیست، اسلاید طرح موردنیاز را اضافه کنید.
4. یک اسلاید خالی بر پایهٔ اسلاید طرح جدید اضافه کنید.
5. ارائه را ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه یک طرح اسلاید به یک ارائه PowerPoint اضافه شود:

```cs
// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر یک فایل PowerPoint است.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // از انواع اسلایدهای طرح عبور کنید تا یک اسلاید طرح انتخاب شود.
    IMasterLayoutSlideCollection layoutSlides = presentation.Masters[0].LayoutSlides;
    ILayoutSlide layoutSlide = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)
    {
        // موقعیتی که ارائه تمام انواع طرح‌ها را شامل نمی‌شود.
        // فایل ارائه فقط انواع طرح Blank و Custom را دارد.
        // با این حال، اسلایدهای طرح با انواع سفارشی ممکن است نام‌های قابل تشخیصی داشته باشند،
        // مانند "Title"، "Title and Content"، و غیره که می‌توانند برای انتخاب اسلاید طرح استفاده شوند.
        // همچنین می‌توانید به مجموعه‌ای از انواع شکل‌های جای‌دار متکی باشید.
        // به عنوان مثال، یک اسلاید Title باید فقط نوع جای‌دار Title را داشته باشد، و به همین ترتیب.
        foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
        {
            if (titleAndObjectLayoutSlide.Name == "Title and Object")
            {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null)
        {
            foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
            {
                if (titleLayoutSlide.Name == "Title")
                {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null)
            {
                layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
                if (layoutSlide == null)
                {
                    layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // یک اسلاید خالی با استفاده از اسلاید طرح اضافه‌شده اضافه کنید.
    presentation.Slides.InsertEmptySlide(0, layoutSlide);

    // ارائه را بر روی دیسک ذخیره کنید.  
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **حذف اسلایدهای طرح استفاده نشده**

Aspose.Slides متد [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) را از کلاس [Compress](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/) ارائه می‌دهد تا بتوانید اسلایدهای طرح ناخواسته و استفاده نشده را حذف کنید.

کد C# زیر نحوه حذف یک اسلاید طرح از یک ارائه PowerPoint را نشان می‌دهد:

```cs
using (Presentation presentation = new Presentation("Presentation.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(presentation);
    
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **افزودن جای‌دارها به طرح‌های اسلاید**

Aspose.Slides ویژگی [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutslide/placeholdermanager/) را ارائه می‌دهد که به شما امکان می‌دهد جای‌دارهای جدیدی به یک اسلاید طرح اضافه کنید.

این مدیر شامل متدهایی برای انواع جای‌دارهای زیر است:

| جای‌دار PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/net/aspose.slides/ilayoutplaceholdermanager/) متد |
| ------------------- | ------------------------------------------------------------ |
| ![محتوا](content.png) | AddContentPlaceholder(float x, float y, float width, float height) |
| ![محتوا (عمودی)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![متن](text.png) | AddTextPlaceholder(float x, float y, float width, float height) |
| ![متن (عمودی)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![تصویر](picture.png) | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![نمودار](chart.png) | AddChartPlaceholder(float x, float y, float width, float height) |
| ![جدول](table.png) | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![رسانه](media.png) | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![تصویر آنلاین](onlineimage.png) | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

کد C# زیر نشان می‌دهد چگونه اشکال جای‌دار جدید به اسلاید طرح Blank اضافه شود:

```cs
using (var presentation = new Presentation())
{
    // دریافت اسلاید طرح Blank.
    ILayoutSlide layout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

    // دریافت مدیر جای‌دار اسلاید طرح.
    ILayoutPlaceholderManager placeholderManager = layout.PlaceholderManager;

    // افزودن جای‌دارهای مختلف به اسلاید طرح Blank.
    placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
    placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
    placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

    // افزودن اسلاید جدید با طرح Blank.
    ISlide newSlide = presentation.Slides.AddEmptySlide(layout);

    presentation.Save("Placeholders.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![جای‌دارهای روی اسلاید طرح](add_placeholders.png)

## **تنظیم نمایش پابرگ برای یک اسلاید طرح**

در ارائه‌های PowerPoint، عناصر پابرگ مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند بر حسب طرح اسلاید نمایش یا مخفی شوند. Aspose.Slides برای .NET به شما امکان می‌دهد وضوح این جای‌دارهای پابرگ را کنترل کنید. این برای مواردی مفید است که می‌خواهید برخی طرح‌ها اطلاعات پابرگ را نشان دهند در حالی که دیگران تمیز و حداقل باقی بمانند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. یک ارجاع به اسلاید طرح را بر اساس اندیس آن دریافت کنید.
3. جای‌دار پابرگ اسلاید را به حالت قابل نمایش تنظیم کنید.
4. جای‌دار شماره اسلاید را به حالت قابل نمایش تنظیم کنید.
5. جای‌دار تاریخ‑زمان را به حالت قابل نمایش تنظیم کنید.
6. ارائه را ذخیره کنید.

کد C# زیر نشان می‌دهد چگونه وضوح پابرگ اسلاید را تنظیم کرده و کارهای مرتبط را انجام دهید:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.LayoutSlides[0].HeaderFooterManager;

    if (!headerFooterManager.IsFooterVisible)
    {
        headerFooterManager.SetFooterVisibility(true);
    }

    if (!headerFooterManager.IsSlideNumberVisible)
    {
        headerFooterManager.SetSlideNumberVisibility(true);
    }

    if (!headerFooterManager.IsDateTimeVisible)
    {
        headerFooterManager.SetDateTimeVisibility(true);
    }

    headerFooterManager.SetFooterText("Footer text");
    headerFooterManager.SetDateTimeText("Date and time text");

    presentation.Save("Presentation.ppt", SaveFormat.Ppt);
}
```

## **تنظیم نمایش پابرگ فرزند برای اسلاید**

در ارائه‌های PowerPoint، عناصر پابرگ مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند در سطح اسلاید مستر کنترل شوند تا تکرار یکسانی در تمامی اسلایدهای طرح داشته باشند. Aspose.Slides برای .NET به شما امکان می‌دهد وضوح و محتوای این جای‌دارهای پابرگ را در اسلاید مستر تنظیم کنید و این تنظیمات را به تمام اسلایدهای طرح فرزند اعمال کنید. این رویکرد اطلاعات پابرگ یکسانی را در تمام ارائه شما تضمین می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. یک ارجاع به اسلاید مستر را بر اساس اندیس آن دریافت کنید.
3. جای‌دارهای پابرگ مستر و تمام اسلایدهای طرح فرزند را به حالت قابل نمایش تنظیم کنید.
4. جای‌دارهای شماره اسلاید مستر و تمام اسلایدهای طرح فرزند را به حالت قابل نمایش تنظیم کنید.
5. جای‌دارهای تاریخ‑زمان مستر و تمام اسلایدهای طرح فرزند را به حالت قابل نمایش تنظیم کنید.
6. ارائه را ذخیره کنید.

کد C# زیر این عملیات را نشان می‌دهد:

```cs
using (Presentation presentation = new Presentation("Presentation.ppt"))
{
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;

    headerFooterManager.SetFooterAndChildFootersVisibility(true);
    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Footer text");
    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **سوالات متداول**

**تفاوت اسلاید مستر و اسلاید طرح چیست؟**

اسلاید مستر تم کلی و قالب‌بندی پیش‌فرض را تعریف می‌کند، در حالی که اسلایدهای طرح چینش‌های خاصی از جای‌دارها برای انواع مختلف محتوا را تعیین می‌کنند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله، می‌توانید یک اسلاید طرح را از مجموعهٔ [LayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/layoutslides/) یک ارائه گرفته و با استفاده از متد `AddClone` در ارائهٔ دیگر وارد کنید.

**اگر اسلاید طرحی که هنوز توسط اسلایدی استفاده می‌شود را حذف کنم چه می‌شود؟**

اگر سعی کنید یک اسلاید طرح را حذف کنید که هنوز توسط حداقل یک اسلاید در ارائه ارجاع شده است، Aspose.Slides یک استثنای [PptxEditException](https://reference.aspose.com/slides/fa/net/aspose.slides/pptxeditexception/) پرتاب می‌کند. برای جلوگیری از این، از [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/fa/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) استفاده کنید که به‌صورت ایمن تنها اسلایدهای طرح غیر استفاده‌شده را حذف می‌کند.