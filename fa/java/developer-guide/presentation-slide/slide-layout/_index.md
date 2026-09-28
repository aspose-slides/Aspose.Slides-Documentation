---
title: اعمال یا تغییر طرح‌بندی اسلایدها در Java
linktitle: طرح‌بندی اسلاید
type: docs
weight: 60
url: /fa/java/slide-layout/
keywords:
- طرح‌بندی اسلاید
- طرح‌بندی محتوا
- مکان‌دار
- طراحی ارائه
- طراحی اسلاید
- طرح‌بندی بلااستفاده
- قابلیت نمایش فوتر
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوا
- مقایسه
- فقط عنوان
- طرح‌بندی خالی
- محتوا با توضیح
- تصویر با توضیح
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "اعمال، ایجاد و اصلاح طرح‌بندی اسلایدها در Aspose.Slides برای Java، افزودن مکان‌دارها، حذف طرح‌بندی‌های بلااستفاده و کنترل نمایش فوتر."
---
## **نمای کلی**

طرح‌بندی اسلاید موقعیت‌ها و قالب‌بندی مکان‌دارهایی مانند عناوین، متن، تصویرها، نمودارها و جدول‌ها را تعیین می‌کند. اعمال یک طرح‌بندی به اسلایدها ساختاری یکسان می‌بخشد در حالی که به هر اسلاید امکان داشتن محتوای خاص خود را می‌دهد.

رایج‌ترین طرح‌بندی‌ها شامل:

- **اسلاید عنوان**: شامل مکان‌دارهای عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک مکان‌دار عنوان و یک مکان‌دار محتوا عمومی است.
- **خالی**: هیچ مکان‌دار محتوایی ندارد و زمانی مفید است که همه اشکال به‌صورت دستی موقعیت‌گذاری شوند.

## **درک ارث‌بری طرح‌بندی**

یک ارائه دارای سه سطح مرتبط است:

1. یک [اسلاید اصلی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
1. یک [اسلاید طرح‌بندی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/) به یک اسلاید اصلی تعلق دارد و یک چیدمان خاص از مکان‌دارها را تعریف می‌کند.
1. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) از یک طرح‌بندی استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی تم و قالب‌بندی را از طرح‌بندی خود ارث می‌برد و طرح‌بندی از اسلاید اصلی ارث می‌برد. مقدار تنظیم‌شده مستقیم بر روی اسلاید عادی، مقدار ارث‌بری در همان سطح را بازنویسی می‌کند. هنگامی که یک اسلاید عادی ساخته می‌شود، اشکال مکان‌دار آن از طرح‌بندی انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده در آن مکان‌دارها متعلق به اسلاید عادی است.

پیش از ایجاد اسلایدها، مکان‌دارهای موردنیاز را به یک طرح‌بندی اضافه کنید. افزودن یک مکان‌دار دیگر به طرح‌بندی بعداً به‌طور خودکار یک شکل مکان‌دار متناظر به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی ارث‌بری یا هندسه مکان‌دارهای موجود در یک طرح‌بندی می‌تواند هر اسلایدی را که به آن وابسته است به‌روز کند. پیش از ویرایش طرح‌بندی که قبلاً استفاده شده، اسلایدهای وابسته را بررسی کنید و ارائه نهایی را مرور کنید.
- یک طرح‌بندی که هنوز توسط اسلایدی استفاده می‌شود، نمی‌تواند حذف شود. ابتدا اسلایدهای وابسته آن را به طرح‌بندی دیگری اختصاص دهید یا فقط طرح‌بندی‌های بلااستفاده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالایی این سلسله‌مراتب، به [اسلاید اصلی](/slides/fa/java/slide-master/) مراجعه کنید.

برای مخفی کردن لوگوهای ارث‌بری یا اشکال تزئینی اسلاید اصلی در یک اسلاید یا از طریق یک طرح‌بندی مشترک، به [کنترل نمایش گرافیک‌های اسلاید اصلی](/slides/fa/java/slide-master/) مراجعه کنید. مثال دو اسلاید استفاده‌کننده از همان اسلاید اصلی را مقایسه می‌کند.

## **انتخاب و اعمال یک طرح‌بندی اسلاید**

هنگامی که ارائه از تعاریف استاندارد طرح‌بندی PowerPoint پیروی می‌کند، از نوع طرح‌بندی استفاده کنید. نام‌های طرح‌بندی قابل ویرایش توسط کاربر هستند و می‌توانند بومی‌سازی شوند، بنابراین انتخاب بر اساس نام کمتر قابل اعتماد است مگر این‌که قالب منبع را کنترل کنید.

مثال زیر به دنبال **عنوان و محتوا** در اولین اسلاید اصلی می‌گردد. اگر آن طرح‌بندی موجود نباشد، عمداً به **خالی** بازمی‌گردد. بررسی دوم برای مقدار null لازم است زیرا یک ارائه می‌تواند فقط طرح‌بندی‌های سفارشی داشته باشد. سپس طرح‌بندی انتخاب‌شده از طریق متد [ISlide.setLayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILLayoutSlide-) بر روی اولین اسلاید عادی اعمال می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تغییر طرح‌بندی اسلاید اشکال عادی افزودنی مستقیم به اسلاید را حذف نمی‌کند. با این حال، موقعیت مکان‌دارها، قالب‌بندی ارث‌بری و تطبیق بین مکان‌دارهای موجود و طرح‌بندی جدید می‌تواند تغییر کند، بنابراین هنگام جابجایی بین طرح‌بندی‌های به‌طور قابل‌توجه متفاوت خروجی را بررسی کنید.

## **افزودن یک اسلاید طرح‌بندی**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح‌بندی موجود را انتخاب می‌کرد؛ آن را نمی‌ساخت. برای ساخت یک طرح‌بندی، متد [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) را بر روی مجموعه‌ی طرح‌بندی‌های اسلاید اصلی هدف فراخوانی کنید.

مثال زیر همیشه یک طرح‌بندی **عنوان و محتوا** جدید به نام `Report Title and Content` اضافه می‌کند، سپس یک اسلاید عادی بر اساس آن می‌سازد. نام‌های طرح‌بندی باید درون مجموعه منحصربه‌فرد باشند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

فقط زمانی که قالب واقعاً به یک ساختار قابل‌استفاده دیگر نیاز دارد، یک طرح‌بندی اضافه کنید. اگر یک طرح‌بندی مناسب از پیش وجود داشته باشد، به‌جای ایجاد کپی، آن را انتخاب و دوباره استفاده کنید.

## **افزودن مکان‌دارها به یک اسلاید طرح‌بندی**

متد [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) یک شیء [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/) برای افزودن اشکال مکان‌دار به طرح‌بندی فراهم می‌کند.

| مکان‌دار PowerPoint                | متد `ILayoutPlaceholderManager` |
| ---------------------------------- | -------------------------------- |
| ![Content](content.png)            | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png)                  | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png)      | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png)            | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png)                | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png)                | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)          | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png)                | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png)   | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

مثال زیر بررسی می‌کند که طرح‌بندی **خالی** وجود دارد، چهار مکان‌دار به آن اضافه می‌کند و سپس یک اسلاید عادی که از طرح‌بندی تغییر یافته استفاده می‌کند ایجاد می‌کند. ترتیب به‌صورت عمدی است: ابتدا مکان‌دارها اضافه می‌شوند سپس اسلاید عادی ساخته می‌شود تا Aspose.Slides بتواند اشکال مکان‌دار متناظر را بر روی آن اسلاید تولید کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی ارث‌بری یا هندسه مکان‌دارهای موجود در طرح‌بندی می‌تواند اسلایدهای وابسته را تحت تأثیر قرار دهد. یک مکان‌دار جدید در طرح‌بندی به‌صورت خودکار در اسلایدهای عادی موجود پر نمی‌شود. تغییرات طرح‌بندی را روی یک نسخه کپی از ارائه تست کنید و هر اسلاید وابسته را بررسی کنید.
{{% /alert %}}

## **حذف اسلایدهای طرح‌بندی بلااستفاده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) برای حذف طرح‌بندی‌هایی که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد استفاده کنید. این متد طرح‌بندی‌های همچنان در حال استفاده را دست نخورده می‌گذارد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

برای حذف یک طرح‌بندی خاص، ابتدا از متد [hasDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) یا [getDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) آن استفاده کنید. قبل از فراخوانی [ILayoutSlide.remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#remove--) اسلایدهای وابسته را دوباره اختصاص دهید. تلاش برای حذف یک طرح‌بندی استفاده‌شده منجر به پرتاب [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش فوتر در یک اسلاید طرح‌بندی**

یک طرح‌بندی فوتر، شماره اسلاید و مکان‌دارهای تاریخ‑زمان مختص خود را دارد. از متد [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) برای کنترل این مکان‌دارها برای یک طرح‌بندی استفاده کنید. این مورد زمانی مفید است که مثلاً طرح‌بندی‌های محتوا فوتر نشان دهند ولی طرح‌بندی‌های عنوان نشان ندهند.

مثال زیر یک طرح‌بندی را به‌صورت ایمن انتخاب می‌کند و عناصر فوتر آن را قابل مشاهده می‌سازد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **کنترل نمایش فوتر در اسلاید اصلی و طرح‌بندی‌های فرزند آن**

برای اعمال تنظیمات فوتر یکسان در سراسر سلسله‌مراتب اسلاید اصلی، از متد [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) استفاده کنید. متدهای انتشار [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslideheaderfootermanager/) بر روی اسلاید اصلی و اسلایدهای طرح‌بندی وابسته و اسلایدهای عادی اعمال می‌شود؛ آن‌ها فقط یک اسلاید عادی را هدف نمی‌گیرند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**تفاوت اسلاید اصلی و اسلاید طرح‌بندی چیست؟**

اسلاید اصلی تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح‌بندی به اسلاید اصلی تعلق دارد و یک چیدمان قابل‌استفاده مجدد از مکان‌دارها را تعریف می‌کند. اسلایدهای عادی از این طرح‌بندی‌ها استفاده می‌کنند و محتوای خاص خود را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح‌بندی را از یک ارائه به ارائه دیگر کپی کنم؟**

بله. با استفاده از متد [addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) یک کپی به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصویرها و سایر منابع استفاده‌شده توسط طرح‌بندی منبع را نیز بررسی کنید.

**اگر یک طرح‌بندی که قبلاً استفاده می‌شود را تغییر دهم چه می‌شود؟**

اسلایدهای وابسته تغییرات طرح‌بندی را به‌صورت خودکار ارث می‌بخشند مگر اینکه قالب‌بندی یا اشیای موردنظر را به صورت محلی بازنویسی کرده باشند. هندسه مکان‌دارها و استایل‌های ارث‌بری می‌تواند به‌طور همزمان در بسیاری از اسلایدها تغییر کند. پیش از ویرایش طرح‌بندی، از متد [getDependingSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) برای شناسایی اسلایدهای تحت تأثیر استفاده کنید.

**اگر یک طرح‌بندی هنوز در استفاده باشد را حذف کنم چه اتفاقی می‌افتد؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/java/com.aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را دوباره اختصاص دهید یا از متد [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) برای حذف تنها طرح‌بندی‌های بلاارجاع استفاده کنید.