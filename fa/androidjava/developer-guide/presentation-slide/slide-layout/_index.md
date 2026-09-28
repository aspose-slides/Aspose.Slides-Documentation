---
title: اعمال یا تغییر طرح‌بندی اسلایدها در اندروید
linktitle: طرح‌بندی اسلاید
type: docs
weight: 60
url: /fa/androidjava/slide-layout/
keywords:
- طرح‌بندی اسلاید
- طرح‌بندی محتوا
- نگهدارنده
- طراحی ارائه
- طراحی اسلاید
- طرح‌بندی بلااستفاده
- قابلیت دیده شدن پاورقی
- اسلاید عنوان
- عنوان و محتوا
- سرصفحه بخش
- دو محتوایی
- مقایسه
- فقط عنوان
- طرح‌بندی خالی
- محتوا با عنوان فرعی
- تصویر با عنوان فرعی
- عنوان و متن عمودی
- عنوان عمودی و متن
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "در Aspose.Slides برای اندروید از طریق Java، طرح‌بندی اسلایدها را اعمال، ایجاد و اصلاح کنید، نگهدارنده‌ها را اضافه کنید، طرح‌بندی‌های بلااستفاده را حذف کنید و قابلیت دیده شدن پاورقی را کنترل کنید."
---
## **بررسی کلی**

یک طرح‌بندی اسلاید موقعیت‌ها و قالب‌بندی نگهدارنده‌ها مانند عناوین، متن، تصویرها، نمودارها و جدول‌ها را تعریف می‌کند. اعمال یک طرح‌بندی به اسلایدها ساختاری یکدست می‌دهد در حالی که به هر اسلاید امکان داشتن محتوای خود را می‌دهد.

پر استفاده‌ترین طرح‌بندی‌ها شامل:

- **اسلاید عنوان**: شامل نگهدارنده‌های عنوان و زیرعنوان است.
- **عنوان و محتوا**: شامل یک نگهدارنده عنوان و یک نگهدارنده محتوای عمومی است.
- **خالی**: هیچ نگهدارنده محتوایی ندارد و زمانی مفید است که هر شکل به صورت دستی موقعیت‌یابی شود.

## **درک وراثت طرح‌بندی**

یک ارائه دارای سه سطح مرتبط است:

1. یک [اسلاید اصلی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/) تم، قالب‌بندی مشترک، پس‌زمینه‌ها و اشیای عمومی را تعریف می‌کند.
2. یک [اسلاید طرح‌بندی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/) متعلق به یک اسلاید اصلی است و ترتیب خاصی از نگهدارنده‌ها را تعریف می‌کند.
3. یک [اسلاید عادی](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) از یک طرح‌بندی استفاده می‌کند و محتوای وارد شده برای آن اسلاید را ذخیره می‌کند.

یک اسلاید عادی تم و قالب‌بندی را از طرح‌بندی خود به ارث می‌برد و طرح‌بندی از اسلاید اصلی به ارث می‌گیرد. مقداری که مستقیماً بر روی اسلاید عادی تنظیم می‌شود مقدار به ارث‌برده‌شده را در همان سطح بازنویسی می‌کند. هنگام ایجاد یک اسلاید عادی، اشکال نگهدارنده آن از طرح‌بندی انتخاب‌شده تولید می‌شوند، در حالی که محتوای وارد شده در آن نگهدارنده‌ها به اسلاید عادی تعلق دارد.

نگهدارنده‌های لازم را قبل از ایجاد اسلایدها به یک طرح‌بندی اضافه کنید. افزودن نگهدارنده دیگر به یک طرح‌بندی بعداً به‌صورت خودکار یک شکل نگهدارندهٔ متناظر به اسلایدهای عادی موجود اضافه نمی‌کند.

این رابطه دو پیامد مهم دارد:

- تغییر قالب‌بندی به ارث‌برده یا هندسهٔ نگهدارنده‌های موجود در یک طرح‌بندی می‌تواند همه اسلایدهایی که به آن وابسته‌اند را به‌روزرسانی کند. قبل از ویرایش طرح‌بندی که قبلاً استفاده می‌شود، اسلایدهای وابسته را بررسی و ارائهٔ حاصل را مرور کنید.
- طرح‌بندی‌ای که هنوز توسط اسلایدی استفاده می‌شود قابل حذف نیست. ابتدا اسلایدهای وابستهٔ آن را به طرح‌بندی دیگری منتقل کنید یا فقط طرح‌بندی‌های بدون استفاده را حذف کنید.

برای اطلاعات بیشتر درباره سطح بالای این سلسله‌مراتب، به [اسلاید اصلی](/slides/fa/androidjava/slide-master/) مراجعه کنید.

برای مخفی کردن لوگوهای به‌ارث‌برده یا اشکال تزئینی اسلاید اصلی در یک اسلاید یا از طریق یک طرح‌بندی مشترک، به [کنترل نمایش گرافیک‌های اسلاید اصلی](/slides/fa/androidjava/slide-master/) نگاه کنید. این مثال دو اسلاید استفاده‌کننده از همان اسلاید اصلی را مقایسه می‌کند.

## **انتخاب و اعمال یک طرح‌بندی اسلاید**

از یک نوع طرح‌بندی زمانی استفاده کنید که ارائه از تعاریف استاندارد طرح‌بندی PowerPoint پیروی می‌کند. نام‌های طرح‌بندی توسط کاربر قابل ویرایش و قابل بومی‌سازی هستند، بنابراین انتخاب بر پایهٔ نام کمتر قابل اعتماد است مگر اینکه قالب منبع را تحت کنترل داشته باشید.

مثال زیر به دنبال **عنوان و محتوا** در اولین اسلاید اصلی می‌گردد. اگر آن طرح‌بندی موجود نباشد، عمداً به **خالی** باز می‌گردد. بررسی نال دوم ضروری است زیرا یک ارائه می‌تواند فقط شامل طرح‌بندی‌های سفارشی باشد. سپس طرح‌بندی انتخاب‌شده از طریق متد [ISlide.setLayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) به اولین اسلاید عادی اعمال می‌شود.

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

تغییر طرح‌بندی یک اسلاید، اشکال معمولی اضافه‌شده مستقیم به اسلاید را حذف نمی‌کند. اما موقعیت نگهدارنده‌ها، قالب‌بندی به ارث‌برده و ارتباط بین نگهدارنده‌های موجود و طرح‌بندی جدید می‌تواند تغییر کند، بنابراین هنگام جابجایی بین طرح‌بندی‌های به‌طور قابل‌توجه متفاوت، خروجی را بررسی کنید.

## **افزودن اسلاید طرح‌بندی**

انتخاب و ایجاد عملیات‌های جداگانه‌ای هستند. مثال قبلی یک طرح‌بندی موجود را انتخاب می‌کند؛ آن را ایجاد نمی‌کند. برای ایجاد یک طرح‌بندی، متد [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) را بر روی مجموعهٔ طرح‌بندی‌های اسلاید اصلی هدف فراخوانی کنید.

مثال زیر همیشه یک طرح‌بندی جدید **عنوان و محتوا** به نام `Report Title and Content` اضافه می‌کند، سپس اسلاید عادی مبتنی بر آن را اضافه می‌نماید. نام‌های طرح‌بندی باید در مجموعه یکتا باشند.

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

فقط زمانی که الگو واقعاً به ساختار قابل‌استفادهٔ دیگری نیاز دارد، یک طرح‌بندی اضافه کنید. اگر یک طرح‌بندی مناسب از قبل وجود دارد، به‌جای ایجاد نسخهٔ تکراری، آن را انتخاب و بازاستفاده کنید.

## **افزودن نگهدارنده‌ها به اسلاید طرح‌بندی**

متد [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) یک [ILayoutPlaceholderManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) برای افزودن اشکال نگهدارنده به یک طرح‌بندی فراهم می‌کند.

| نگهدارنده PowerPoint | متد `ILayoutPlaceholderManager` |
| --------------------- | -------------------------------- |
| ![محتوا](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![محتوا (عمودی)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![متن](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![متن (عمودی)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![تصویر](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![نمودار](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![جدول](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![رسانه](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![تصویر آنلاین](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

مثال زیر وجود طرح‌بندی **خالی** را بررسی می‌کند، چهار نگهدارنده به آن اضافه می‌نماید و سپس اسلاید عادی استفاده‌کننده از طرح‌بندی اصلاح‌شده را می‌سازد. ترتیب این کار عمدی است: نگهدارنده‌ها قبل از ایجاد اسلاید عادی اضافه می‌شوند، بنابراین Aspose.Slides می‌تواند اشکال نگهدارندهٔ مربوطه را در آن اسلاید تولید کند.

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

![نگهدارنده‌ها در اسلاید طرح‌بندی](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
تغییر قالب‌بندی به ارث‌برده یا هندسهٔ نگهدارنده‌های موجود در طرح‌بندی می‌تواند بر اسلایدهای وابسته تأثیر بگذارد. یک نگهدارندهٔ جدید به طرح‌بندی به‌صورت خودکار در اسلایدهای عادی موجود پر نمی‌شود. تغییرات طرح‌بندی را روی یک کپی از ارائه آزمایش کنید و هر اسلاید وابسته را بررسی کنید.
{{% /alert %}}

## **حذف اسلایدهای طرح‌بندی بدون استفاده**

از متد [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) برای حذف طرح‌بندی‌هایی که هیچ اسلاید عادی به آن‌ها ارجاع نمی‌دهد استفاده کنید. این متد طرح‌بندی‌های هنوز در استفاده را دست‌نخورده می‌گذارد.

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

برای حذف یک طرح‌بندی خاص، ابتدا متد [hasDependingSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) یا [getDependingSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) آن را فراخوانی کنید. پیش از فراخوانی [ILayoutSlide.remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#remove--)، هر اسلاید وابسته‌ای را منتقل کنید. تلاش برای حذف یک طرح‌بندی استفاده‌شده منجر به پرتاب [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxeditexception/) می‌شود.

## **کنترل نمایش پاورقی در اسلاید طرح‌بندی**

یک طرح‌بندی دارای پاورقی، شماره اسلاید و نگهدارنده‌های تاریخ‑زمان مخصوص به خود است. برای کنترل این نگهدارنده‌ها در یک طرح‌بندی می‌توانید از متد [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) استفاده کنید. این کار زمانی مفید است که مثلاً طرح‌بندی‌های محتوا باید پاورقی نمایش دهند ولی طرح‌بندی‌های عنوان نه.

مثال زیر یک طرح‌بندی را به‌صورت ایمن انتخاب می‌کند و عناصر پاورقی آن را قابل مشاهده می‌سازد:

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

## **کنترل نمایش پاورقی در اسلاید اصلی و طرح‌بندی‌های فرزند آن**

برای اعمال تنظیمات پاورقی یکسان در سطح سلسله‌مراتب اسلاید اصلی، از متد [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) استفاده کنید. متدهای انتشار [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) بر اسلاید اصلی و اسلایدهای طرح‌بندی وابسته و اسلایدهای عادی عمل می‌کنند؛ آن‌ها فقط یک اسلاید عادی را هدف نمی‌گیرند.

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

## **پرسش‌های متداول**

**تفاوت اسلاید اصلی و اسلاید طرح‌بندی چیست؟**

اسلاید اصلی تم و قالب‌بندی مشترک ارائه را تعریف می‌کند. اسلاید طرح‌بندی به یک اسلاید اصلی تعلق دارد و یک ترتیب قابل‌استفادهٔ نگهدارنده‌ها را تعریف می‌کند. اسلایدهای عادی از این طرح‌بندی‌ها استفاده می‌کنند و محتوای مخصوص به هر اسلاید را ذخیره می‌نمایند.

**آیا می‌توانم یک اسلاید طرح‌بندی را از یک ارائه به ارائه دیگری کپی کنم؟**

بله. با استفاده از متد [addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) یک کپی به مجموعه مقصد اضافه کنید. هنگام کپی بین ارائه‌ها، فونت‌ها، تم‌ها، تصویرها و سایر منابع استفاده‌شده توسط طرح‌بندی منبع را نیز بررسی کنید.

**چه اتفاقی می‌افتد وقتی یک طرح‌بندی که در حال حاضر استفاده می‌شود را تغییر می‌دهم؟**

اسلایدهای وابسته تغییرات طرح‌بندی را به ارث می‌برند مگر این‌که قالب‌بندی یا اشیای موردنظر را به‌صورت محلی بازنویسی کرده باشند. بنابراین هندسهٔ نگهدارنده‌ها و استایل‌های به‌ارث‌برده می‌تواند همزمان در بسیاری از اسلایدها تغییر کند. پیش از ویرایش طرح‌بندی، با استفاده از [getDependingSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) اسلایدهای تحت تأثیر را شناسایی کنید.

**چه اتفاقی می‌افتد اگر یک طرح‌بندی که هنوز استفاده می‌شود را حذف کنم؟**

Aspose.Slides یک [PptxEditException](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/pptxeditexception/) پرتاب می‌کند. ابتدا اسلایدهای وابسته را منتقل کنید یا از [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) برای حذف فقط طرح‌بندی‌های بدون ارجاع استفاده کنید.