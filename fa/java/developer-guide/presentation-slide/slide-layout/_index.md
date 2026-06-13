---
title: اعمال یا تغییر طرح اسلاید در جاوا
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/java/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- متغیر جایگزین
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- قابلیت نمایش پابرگ
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
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
- Java
- Aspose.Slides
description: "مدیریت و سفارشی‌سازی طرح‌های اسلاید در Aspose.Slides برای جاوا. انواع طرح‌ها، کنترل متغیرهای جایگزین، و قابلیت نمایش پابرگ را از طریق مثال‌های کد جاوا بررسی کنید."
---
## **مقدمه**

یک طرح اسلاید چیدمان جعبه‌های متغیر جایگزین و قالب‌بندی محتوا را بر روی یک اسلاید تعریف می‌کند. این کنترل می‌کند که کدام متغیرهای جایگزین در دسترس هستند و کجا ظاهر می‌شوند. طرح‌های اسلاید به شما کمک می‌کند تا ارائه‌ها را به‌سرعت و به‌صورت سازگار طراحی کنید—چه در حال ایجاد چیزی ساده باشید و چه پیچیده‌تر. برخی از رایج‌ترین طرح‌های اسلاید در PowerPoint عبارتند از:

**طرح اسلاید عنوان** – دو متغیر متنی شامل یک برای عنوان و یک برای زیرعنوان دارد.

**طرح عنوان و محتوا** – شامل یک متغیر عنوان کوچکتر در بالای اسلاید و یک متغیر بزرگتر در زیر برای محتوای اصلی (مانند متن، نکات بولت‌دار، نمودارها، تصاویر و موارد دیگر) است.

**طرح خالی** – هیچ متغیر جایگزینی ندارد و به شما کنترل کامل برای طراحی اسلاید از ابتدا می‌دهد.

طرح‌های اسلاید جزئی از یک اسلاید اصلی (slide master) هستند که اسلاید سطح بالایی است که سبک‌های طرح را برای ارائه تعریف می‌کند. می‌توانید از طریق اسلاید اصلی به طرح‌های اسلاید دسترسی پیدا کنید و آنها را اصلاح کنید—چه بر اساس نوع، نام یا شناسه منحصر به فردشان. یا می‌توانید یک طرح اسلاید خاص را مستقیماً درون ارائه ویرایش کنید.

برای کار با طرح‌های اسلاید در Aspose.Slides for Java، می‌توانید از:

- روش‌هایی مانند [getLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getLayoutSlides--) و [getMasters](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getMasters--) تحت کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/)
- انواع مانند [ILayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/), و [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
برای اطلاعات بیشتر درباره کار با اسلایدهای اصلی، مقاله [Slide Master](/slides/fa/java/slide-master/) را بررسی کنید.
{{% /alert %}}

## **افزودن طرح‌های اسلاید به ارائه‌ها**

برای سفارشی‌سازی ظاهر و ساختار اسلایدهای خود، ممکن است نیاز داشته باشید طرح‌های اسلاید جدیدی به یک ارائه اضافه کنید. Aspose.Slides for Java به شما اجازه می‌دهد تا بررسی کنید آیا یک طرح خاص از قبل موجود است یا نه، در صورت نیاز یک طرح جدید اضافه کنید و از آن برای درج اسلایدهایی بر اساس همان طرح استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. به [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterlayoutslidecollection/) دسترسی پیدا کنید.
1. بررسی کنید آیا طرح اسلاید مورد نظر در مجموعه وجود دارد. اگر نه، طرح اسلاید مورد نیاز را اضافه کنید.
1. یک اسلاید خالی بر اساس طرح اسلاید جدید اضافه کنید.
1. ارائه را ذخیره کنید.

کد Java زیر نحوه افزودن یک طرح اسلاید به یک ارائه PowerPoint را نشان می‌دهد:

```java
// نمونه‌سازی کلاس Presentation که نمایانگر یک فایل PowerPoint است.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // از انواع اسلایدهای طرح عبور کنید تا یک اسلاید طرح را انتخاب کنید.
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // وضعیتی که در آن ارائه تمام انواع طرح‌ها را شامل نمی‌شود.
        // فایل ارائه تنها شامل انواع طرح Blank و Custom است.
        // با این حال، اسلایدهای طرح با انواع سفارشی ممکن است نام‌های قابل تشخیص داشته باشند،
        // مانند "Title"، "Title and Content"، و غیره که می‌توان برای انتخاب اسلاید طرح استفاده کرد.
        // همچنین می‌توانید به مجموعه‌ای از انواع شکل‌های متغیر جایگزین وابسته باشید.
        // به عنوان مثال، یک اسلاید Title باید فقط نوع متغیر جایگزین Title را داشته باشد و به همین ترتیب.
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // یک اسلاید خالی با استفاده از اسلاید طرح اضافه شده اضافه کنید.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حذف طرح‌های اسلاید استفاده‌نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) را از کلاس [Compress](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/) فراهم می‌کند تا به شما امکان حذف طرح‌های اسلاید ناخواسته و استفاده‌نشده را بدهد.

کد Java زیر نشان می‌دهد چگونه یک طرح اسلاید را از یک ارائه PowerPoint حذف کنید:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن متغیرهای جایگزین به طرح‌های اسلاید**

Aspose.Slides متد [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) را فراهم می‌کند که امکان افزودن متغیرهای جایگزین جدید به یک طرح اسلاید را می‌دهد.

این مدیر شامل متدهایی برای انواع متغیرهای جایگزین زیر است:

| متغیر جایگزین PowerPoint | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/) متد |
| ------------------------ | ------------------------------------------------------------ |
| ![محتوا](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![محتوا (عمودی)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![متن](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![متن (عمودی)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![عکس](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![نمودار](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![جدول](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![رسانه](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![تصویر آنلاین](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

کد Java زیر نحوه افزودن شکل‌های متغیر جایگزین جدید به طرح اسلاید خالی را نشان می‌دهد:

```java
Presentation presentation = new Presentation();
try {
    // دریافت اسلاید طرح Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // دریافت مدیر متغیرهای جایگزین اسلاید طرح.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // افزودن متغیرهای جایگزین مختلف به اسلاید طرح Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // افزودن اسلاید جدید با طرح Blank.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![متغیرهای جایگزین بر روی اسلاید طرح](add_placeholders.png)

## **تنظیم نمایش پابرگ برای یک طرح اسلاید**

در ارائه‌های PowerPoint، عناصر پابرگ مانند تاریخ، شماره اسلاید و متن دلخواه می‌توانند بسته به طرح اسلاید نشان داده یا مخفی شوند. Aspose.Slides for Java به شما اجازه می‌دهد تا نمایش این متغیرهای پابرگ را کنترل کنید. این کار زمانی مفید است که بخواهید برخی طرح‌ها اطلاعات پابرگ را نشان دهند در حالی که دیگران تمیز و کم‌تعداد باقی بمانند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. یک مرجع به طرح اسلاید را با استفاده از ایندکس آن دریافت کنید.
1. متغیر پابرگ اسلاید را به حالت قابل مشاهده تنظیم کنید.
1. متغیر شماره اسلاید را به حالت قابل مشاهده تنظیم کنید.
1. متغیر تاریخ‑زمان را به حالت قابل مشاهده تنظیم کنید.
1. ارائه را ذخیره کنید.

کد Java زیر نشان می‌دهد چگونه نمایش پابرگ اسلاید را تنظیم کنید و کارهای مرتبط را انجام دهید:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **تنظیم نمایش پابرگ فرزند برای یک اسلاید**

در ارائه‌های PowerPoint، عناصر پابرگ مانند تاریخ، شماره اسلاید و متن دلخواه می‌توانند در سطح اسلاید اصلی کنترل شوند تا سازگاری در تمام طرح‌های اسلاید حفظ شود. Aspose.Slides for Java امکان تنظیم نمایش و محتوی این متغیرهای پابرگ بر روی اسلاید اصلی و انتشار این تنظیمات به تمام طرح‌های اسلاید فرزند را می‌دهد. این روش اطمینان می‌دهد که اطلاعات پابرگ به طور یکنواخت در سراسر ارائه شما گسترش یابد.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
1. مرجع به اسلاید اصلی را با استفاده از ایندکس آن دریافت کنید.
1. تمام متغیرهای پابرگ اصلی و فرزند را به حالت قابل مشاهده تنظیم کنید.
1. تمام متغیرهای شماره اسلاید اصلی و فرزند را به حالت قابل مشاهده تنظیم کنید.
1. تمام متغیرهای تاریخ‑زمان اصلی و فرزند را به حالت قابل مشاهده تنظیم کنید.
1. ارائه را ذخیره کنید.

کد Java زیر این عملیات را نشان می‌دهد:

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**تفاوت بین اسلاید اصلی و اسلاید طرح چیست؟**

اسلاید اصلی تم کلی و قالب‌بندی پیش‌فرض را تعریف می‌کند، در حالی که اسلایدهای طرح چیدمان‌های خاص متغیرهای جایگزین برای انواع مختلف محتوا را تعیین می‌ورزند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائه دیگر کپی کنم؟**

بله، می‌توانید یک اسلاید طرح را از مجموعه اسلایدهای طرح یک ارائه، که از طریق متد [getLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getLayoutSlides--) قابل دسترسی است، کلون کنید و با استفاده از متد `addClone` آن را در ارائه دیگر وارد کنید.

**اگر یک اسلاید طرح که هنوز توسط اسلایدی استفاده می‌شود را حذف کنم چه اتفاقی می‌افتد؟**

اگر سعی کنید یک اسلاید طرح را حذف کنید که هنوز توسط حداقل یک اسلاید در ارائه مورد ارجاع قرار گرفته است، Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) را پرتاب می‌کند. برای جلوگیری از این مسئله، از متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) استفاده کنید که به‌صورت ایمن تنها طرح‌های اسلایدی که استفاده نمی‌شوند را حذف می‌نماید.