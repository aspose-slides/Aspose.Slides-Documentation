---
title: "اعمال یا تغییر طرح اسلایدها در جاوااسکریپت"
linktitle: "طرح اسلاید"
type: docs
weight: 60
url: /fa/nodejs-java/slide-layout/
keywords:
- "طرح اسلاید"
- "طرح محتوا"
- "جای‌دار"
- "طراحی ارائه"
- "طراحی اسلاید"
- "طرح استفاده‌نشده"
- "قابلیت نمایش پاورقی"
- "اسلاید عنوان"
- "عنوان و محتوا"
- "سرصفحه بخش"
- "دو محتوا"
- "مقایسه"
- "فقط عنوان"
- "طرح خالی"
- "محتوا با توضیح"
- "عکس با توضیح"
- "عنوان و متن عمودی"
- "عنوان عمودی و متن"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "طرح اسلایدها را در Aspose.Slides برای Node.js مدیریت و سفارشی‌سازی کنید. انواع طرح‌ها، کنترل جای‌دارها و قابلیت نمایش پاورقی را با مثال‌های کد بررسی کنید."
---
## **مقدمه**

یک طرح اسلاید چیدمان جعبه‌های جای‌دار و قالب‌بندی محتوای یک اسلاید را تعریف می‌کند. این کنترل می‌کند که کدام جای‌دارها در دسترس هستند و در کجا ظاهر می‌شوند. طرح‌های اسلاید به شما کمک می‌کند تا ارائه‌ها را به‑سرعت و به‌صورت یکسان طراحی کنید—چه در حال ساخت چیزی ساده باشید و چه پیچیده‌تر. برخی از رایج‌ترین طرح‌های اسلاید در PowerPoint شامل:

**Title Slide layout** – شامل دو جای‌دار متن است: یکی برای عنوان و دیگری برای زیرعنوان.

**Title and Content layout** – یک جای‌دار عنوان کوچکتر در بالا و یک جای‌دار بزرگ‌تر در زیر برای محتوای اصلی (مانند متن، نکات گلوله‌ای، نمودارها، تصاویر و موارد دیگر) دارد.

**Blank layout** – هیچ جای‌داری ندارد و به شما کنترل کامل برای طراحی اسلاید از ابتدا می‌دهد.

طرح‌های اسلاید بخشی از اسلاید اصلی (slide master) هستند که اسلاید سطح بالایی است که استایل‌های طرح را برای ارائه تعریف می‌کند. می‌توانید طرح‌های اسلاید را از طریق اسلاید اصلی دسترسی و ویرایش کنید—چه بر اساس نوع، نام یا شناسه‌ی یکتا. به‌علاوه، می‌توانید یک طرح اسلاید خاص را مستقیماً در داخل ارائه ویرایش کنید.

برای کار با طرح‌های اسلاید در Aspose.Slides برای Node.js می‌توانید از موارد زیر استفاده کنید:
- متدهایی مانند [getLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getLayoutSlides) و [getMasters](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getMasters) تحت کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) 
- نوع‌هایی مانند [LayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutplaceholdermanager/), و [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
برای یادگیری بیشتر درباره کار با اسلایدهای اصلی، مقالهٔ [Slide Master](/slides/fa/nodejs-java/slide-master/) را بررسی کنید.
{{% /alert %}}

## **افزودن طرح‌های اسلاید به ارائه‌ها**

برای سفارشی‌سازی ظاهر و ساختار اسلایدهای خود، ممکن است نیاز به افزودن طرح‌های جدید به یک ارائه داشته باشید. Aspose.Slides برای Node.js به شما اجازه می‌دهد بررسی کنید آیا یک طرح خاص از قبل وجود دارد، در صورت نیاز یک طرح جدید اضافه کنید، و از آن برای درج اسلیدها بر اساس آن طرح استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. به [MasterLayoutSlideCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterlayoutslidecollection/) دسترسی پیدا کنید.
3. بررسی کنید آیا طرح اسلاید موردنظر در مجموعه موجود است یا خیر. اگر نه، طرح اسلاید موردنیاز را اضافه کنید.
4. یک اسلاید خالی بر پایهٔ طرح اسلاید جدید اضافه کنید.
5. ارائه را ذخیره کنید.

کد JavaScript زیر نحوه افزودن یک طرح اسلاید به یک ارائه PowerPoint را نشان می‌دهد:

```js
// یک نمونه از کلاس Presentation ایجاد می‌کند که نمایانگر یک فایل PowerPoint است.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // مرور انواع اسلاید‌های طرح برای انتخاب یک اسلاید طرح.
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // موقعیتی که ارائه همه انواع طرح‌ها را شامل نمی‌شود.
        // فایل ارائه فقط شامل انواع طرح Blank و Custom است.
        // با این حال، اسلایدهای طرح با انواع سفارشی ممکن است نام‌های قابل شناسایی داشته باشند،
        // مانند \"Title\"، \"Title and Content\" و غیره که می‌توانند برای انتخاب اسلاید طرح استفاده شوند.
        // همچنین می‌توانید به مجموعه‌ای از انواع شکل‌های جای‌دار تکیه کنید.
        // برای مثال، یک اسلاید Title فقط باید نوع جای‌دار Title را داشته باشد و به همین ترتیب.
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // افزودن یک اسلاید خالی با استفاده از اسلاید طرح اضافه‌شده.
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // ذخیرهٔ ارائه در دیسک.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حذف طرح‌های اسلاید استفاده‑نشده**

Aspose.Slides متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) را از کلاس [Compress](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/) فراهم می‌کند تا به شما امکان حذف طرح‌های اسلاید ناخواسته و استفاده‑نشده را بدهد.

کد JavaScript زیر نشان می‌دهد چگونه یک طرح اسلاید را از یک ارائه PowerPoint حذف کنید:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن جای‌دارها به طرح‌های اسلاید**

Aspose.Slides متد [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) را ارائه می‌دهد که امکان افزودن جای‌دارهای جدید به یک طرح اسلاید را فراهم می‌کند.

این مدیر شامل متدهایی برای انواع زیر جای‌دارها است:

| جای‌دار PowerPoint | متد [LayoutPlaceholderManager] |
| ------------------ | ------------------------------ |
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

کد JavaScript زیر نشان می‌دهد چگونه اشکال جای‌دار جدید به طرح اسلاید Blank اضافه شود:

```js
let presentation = new aspose.slides.Presentation();
try {
    // دریافت اسلاید طرح Blank.
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // دریافت مدیر جای‌دار اسلاید طرح.
    let placeholderManager = layout.getPlaceholderManager();

    // افزودن جای‌دارهای مختلف به اسلاید طرح Blank.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // افزودن یک اسلاید جدید با طرح Blank.
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The placeholders on the layout slide](add_placeholders.png)

## **تنظیم نمایش پاورقی برای یک طرح اسلاید**

در ارائه‌های PowerPoint، عناصر پاورقی مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند بسته به طرح اسلاید نشان داده یا مخفی شوند. Aspose.Slides برای Node.js به شما امکان کنترل نمایش این جای‌دارهای پاورقی را می‌دهد. این موضوع زمانی مفید است که بخواهید برخی از طرح‌ها اطلاعات پاورقی را نشان دهند در حالی که دیگران تمیز و کمینه باقی بمانند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. یک مرجع به طرح اسلاید را بر حسب اندیس آن دریافت کنید.
3. جای‌دار پاورقی اسلاید را به حالت نمایش تنظیم کنید.
4. جای‌دار شماره اسلاید را به حالت نمایش تنظیم کنید.
5. جای‌دار تاریخ‑زمان را به حالت نمایش تنظیم کنید.
6. ارائه را ذخیره کنید.

کد JavaScript زیر نشان می‌دهد چگونه نمایش پاورقی اسلاید را تنظیم کنید و کارهای مرتبط را انجام دهید:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **تنظیم نمایش پاورقی فرزند برای یک اسلاید**

در ارائه‌های PowerPoint، عناصر پاورقی مانند تاریخ، شماره اسلاید و متن سفارشی می‌توانند در سطح اسلاید اصلی کنترل شوند تا تمامیت در تمام طرح‌های فرزند حفظ شود. Aspose.Slides برای Node.js به شما امکان می‌دهد نمایش و محتوی این جای‌دارهای پاورقی را در اسلاید اصلی تنظیم کنید و این تنظیمات را به تمام طرح‌های فرزند منتقل کنید. این رویکرد اطلاعات پاورقی یکپارچه‌ای را در سراسر ارائه شما تضمین می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. یک مرجع به اسلاید اصلی را بر حسب اندیس آن دریافت کنید.
3. جای‌دارهای پاورقی اسلاید اصلی و تمام فرزندان آن را به حالت نمایش تنظیم کنید.
4. جای‌دارهای شماره اسلاید اسلاید اصلی و تمام فرزندان آن را به حالت نمایش تنظیم کنید.
5. جای‌دارهای تاریخ‑زمان اسلاید اصلی و تمام فرزندان آن را به حالت نمایش تنظیم کنید.
6. ارائه را ذخیره کنید.

کد JavaScript زیر این عملیات را نشان می‌دهد:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**تفاوت اسلاید اصلی و اسلاید طرح چیست؟**

اسلاید اصلی تم کلی و قالب‌بندی پیش‌فرض را تعریف می‌کند، در حالی که اسلایدهای طرح چینش‌های خاصی از جای‌دارها برای انواع مختلف محتوا را تعیین می‌کنند.

**آیا می‌توانم یک اسلاید طرح را از یک ارائه به ارائهٔ دیگر کپی کنم؟**

بله، می‌توانید یک اسلاید طرح را از مجموعهٔ اسلایدهای طرح یک ارائه (از طریق متد [getLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#getLayoutSlides)) کلون کنید و با استفاده از متد `addClone` آن را در ارائهٔ دیگر وارد کنید.

**چه اتفاقی می‌افتد اگر اسلاید طرحی را حذف کنم که هنوز توسط یک اسلاید استفاده می‌شود؟**

اگر سعی کنید اسلاید طرحی را حذف کنید که هنوز توسط حداقل یک اسلاید در ارائه مرجع شده است، Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pptxeditexception/) پرتاب می‌کند. برای جلوگیری از این مشکل، از [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) استفاده کنید که به‌صورت ایمن تنها طرح‌های اسلایدی که استفاده نمی‌شوند را حذف می‌نماید.