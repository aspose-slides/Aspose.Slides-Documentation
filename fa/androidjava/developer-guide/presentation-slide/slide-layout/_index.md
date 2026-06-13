---
title: اعمال یا تغییر طرح‌های اسلاید در Android
linktitle: طرح اسلاید
type: docs
weight: 60
url: /fa/androidjava/slide-layout/
keywords:
- طرح اسلاید
- طرح محتوا
- جای‌گیر
- طراحی ارائه
- طراحی اسلاید
- طرح استفاده‌نشده
- قابلیت نمایش پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح خالی
- محتوا با توضیح
- عکس با توضیح
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت و سفارشی‌سازی طرح‌های اسلاید در Aspose.Slides برای Android. انواع طرح‌ها، کنترل جای‌گیرها و قابلیت نمایش پاورقی را از طریق مثال‌های کد Java بررسی کنید."
---
## **معرفی**

طرح اسلاید نحوهٔ چیدمان جعبه‌های جای‌گیر و قالب‌بندی محتوای یک اسلاید را تعریف می‌کند. این طرح تعیین می‌کند که کدام جای‌گیرها در دسترس هستند و در کجا ظاهر می‌شوند. طرح‌های اسلاید به شما کمک می‌کنند تا ارائه‌ها را به‌سرعت و به‌صورت یکنواخت طراحی کنید — چه در حال ساخت چیزی ساده باشید و چه پیچیده. برخی از رایج‌ترین طرح‌های اسلاید در PowerPoint عبارتند از:

**Title Slide layout** – شامل دو جای‌گیر متنی است: یکی برای عنوان و دیگری برای زیرعنوان.

**Title and Content layout** – یک جای‌گیر عنوان کوچکتر در بالا و یک جای‌گیر بزرگتر در زیر برای محتوای اصلی (متن، نکات بولت‌دار، نمودارها، تصاویر و غیره) دارد.

**Blank layout** – هیچ جای‌گیری ندارد و به شما امکان می‌دهد اسلاید را از ابتدا طراحی کنید.

طرح‌های اسلاید بخشی از یک اسلاید مستر هستند، که اسلاید سطح بالایی است و سبک‌های طرح را برای کل ارائه تعریف می‌کند. می‌توانید به طرح‌های اسلاید از طریق اسلاید مستر دسترسی پیدا کنید و آن‌ها را تغییر دهید — چه بر اساس نوع، نام یا شناسهٔ یکتا. یا می‌توانید یک طرح اسلاید خاص را مستقیماً در داخل ارائه ویرایش کنید.

برای کار با طرح‌های اسلاید در Aspose.Slides برای Android می‌توانید از موارد زیر استفاده کنید:

- متدهایی مانند [getLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) و [getMasters](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getMasters--) در زیر کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/)  
- انواعی مانند [ILayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/)، [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterlayoutslidecollection/)، [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/)، و [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
برای یادگیری بیشتر درباره کار با اسلایدهای مستر، مقاله [Slide Master](/slides/fa/androidjava/slide-master/) را بررسی کنید.
{{% /alert %}}

## **افزودن طرح‌های اسلاید به ارائه‌ها**

برای سفارشی‌سازی ظاهر و ساختار اسلایدهای خود، ممکن است نیاز داشته باشید طرح‌های اسلاید جدیدی به یک ارائه اضافه کنید. Aspose.Slides برای Android به شما امکان می‌دهد بررسی کنید آیا یک طرح خاص از قبل وجود دارد یا نه، در صورت نیاز یک طرح جدید اضافه کنید و از آن برای درج اسلایدهایی بر پایهٔ آن طرح استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.  
2. به [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterlayoutslidecollection/) دسترسی پیدا کنید.  
3. بررسی کنید آیا طرح اسلاید موردنظر در مجموعه موجود است یا خیر. اگر نیست، طرح اسلاید موردنیاز را اضافه کنید.  
4. یک اسلاید خالی بر پایهٔ طرح اسلاید جدید اضافه کنید.  
5. ارائه را ذخیره کنید.

کد جاوای زیر نحوهٔ افزودن یک طرح اسلاید به یک ارائه PowerPoint را نشان می‌دهد:

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
        // یک وضعیت که در آن ارائه همهٔ انواع طرح را شامل نمی‌شود.
        // فایل ارائه فقط شامل انواع طرح Blank و Custom است.
        // اما اسلایدهای طرح با انواع سفارشی ممکن است نام‌های قابل شناسایی داشته باشند،
        // مانند "Title"، "Title and Content" و غیره که می‌توانند برای انتخاب اسلاید طرح استفاده شوند.
        // همچنین می‌توانید به مجموعه‌ای از انواع شکل‌های جای‌گیر تکیه کنید.
        // به‌ عنوان مثال، یک اسلاید Title باید فقط نوع جای‌گیر Title را داشته باشد و به همین ترتیب.
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

    // یک اسلاید خالی با استفاده از اسلاید طرح اضافه‌شده اضافه کنید.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حذف طرح‌های اسلاید استفاده‌نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) را از کلاس [Compress](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/) فراهم می‌کند تا بتوانید طرح‌های اسلاید ناخواسته و استفاده‌نشده را حذف کنید.

کد جاوای زیر نشان می‌دهد چگونه یک طرح اسلاید را از یک ارائه PowerPoint حذف کنید:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن جای‌گیرها به طرح‌های اسلاید**

Aspose.Slides متد [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) را فراهم می‌کند که به شما امکان می‌دهد جای‌گیرهای جدیدی به یک طرح اسلاید اضافه کنید.

این مدیر شامل متدهایی برای انواع جای‌گیرهای زیر است:

| جای‌گیر PowerPoint | متد [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) |
| ----------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

کد جاوای زیر نحوهٔ افزودن اشکال جای‌گیر جدید به طرح اسلاید Blank را نشان می‌دهد:

```java
Presentation presentation = new Presentation();
try {
    // دریافت اسلاید طرح Blank.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // دریافت مدیر جای‌گیرهای اسلاید طرح.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // افزودن جای‌گیرهای مختلف به اسلاید طرح Blank.
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

![The placeholders on the layout slide](add_placeholders.png)

## **تنظیم نمایش پاورقی برای یک طرح اسلاید**

در ارائه‌های PowerPoint، عناصر پاورقی مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند بسته به طرح اسلاید نمایش داده شوند یا مخفی شوند. Aspose.Slides برای Android به شما امکان می‌دهد نمایش این جای‌گیرهای پاورقی را کنترل کنید. این امر زمانی مفید است که بخواهید برخی از طرح‌ها اطلاعات پاورقی را نشان دهند در حالی که دیگران تمیز و کمینه باقی بمانند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.  
2. یک اشاره‌گر به طرح اسلاید موردنظر براساس ایندکس آن دریافت کنید.  
3. جای‌گیر پاورقی اسلاید را قابل مشاهده کنید.  
4. جای‌گیر شماره اسلاید را قابل مشاهده کنید.  
5. جای‌گیر تاریخ‑زمان را قابل مشاهده کنید.  
6. ارائه را ذخیره کنید.

کد جاوای زیر نحوهٔ تنظیم نمایش پاورقی اسلاید و انجام کارهای مرتبط را نشان می‌دهد:

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

## **تنظیم نمایش پاورقی فرزند برای یک اسلاید**

در ارائه‌های PowerPoint، عناصر پاورقی مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند در سطح اسلاید مستر کنترل شوند تا سازگاری در تمام طرح‌های اسلاید حفظ شود. Aspose.Slides برای Android به شما امکان می‌دهد نمایش و محتوای این جای‌گیرهای پاورقی را در اسلاید مستر تنظیم کنید و این تنظیمات را به تمام طرح‌های اسلاید فرزند اعمال کنید. این روش اطلاعات پاورقی یکنواختی را در سراسر ارائه تضمین می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.  
2. به اسلاید مستر براساس ایندکس آن دسترسی پیدا کنید.  
3. تمام جای‌گیرهای پاورقی مستر و فرزندها را قابل مشاهده کنید.  
4. تمام جای‌گیرهای شماره اسلاید مستر و فرزندها را قابل مشاهده کنید.  
5. تمام جای‌گیرهای تاریخ‑زمان مستر و فرزندها را قابل مشاهده کنید.  
6. ارائه را ذخیره کنید.

کد جاوای زیر این عملیات را نشان می‌دهد:

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

## **پرسش‌های متداول**

**تفاوت بین اسلاید مستر و اسلاید طرح چیست؟**

اسلاید مستر تم کلی و قالب‌بندی پیش‌فرض را تعریف می‌کند، در حالی که اسلایدهای طرح چیدمان‌های خاصی از جای‌گیرها را برای انواع مختلف محتوا تعیین می‌کنند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله، می‌توانید یک اسلاید طرح را از مجموعهٔ اسلایدهای طرح یک ارائه (دسترس‌پذیر از طریق متد [getLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#getLayoutSlides--)) کلون کنید و با استفاده از متد `addClone` آن را به ارائهٔ دیگر اضافه کنید.

**اگر یک اسلاید طرح که هنوز توسط اسلایدی استفاده می‌شود را حذف کنم چه اتفاقی می‌افتد؟**

اگر سعی کنید یک اسلاید طرح را حذف کنید که هنوز توسط حداقل یک اسلاید در ارائه ارجاع داده شده است، Aspose.Slides یک استثنای [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxeditexception/) را پرتاب می‌کند. برای جلوگیری از این مشکل، از متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) استفاده کنید که به‌صورت ایمن فقط طرح‌های اسلایدی که استفاده نشده‌اند را حذف می‌کند.