---
title: مدیریت Placeholderهای ارائه در اندروید
linktitle: مدیریت Placeholderها
type: docs
weight: 10
url: /fa/androidjava/manage-placeholder/
keywords:
- جای‌گیر
- جای‌گیر متن
- جای‌گیر تصویر
- جای‌گیر نمودار
- جای‌گیر محتوا
- متن راهنما
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "بیاموزید چگونه Placeholderهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت Placeholderها را با Aspose.Slides برای اندروید از طریق جاوا درک کنید."
---
## **بررسی کلی**

یک placeholder یک شکل است که برای نوع خاصی از محتوا در یک قالب ارائه موقعیت رزرو می‌کند. مثال‌های رایج شامل placeholderهای عنوان، بدنه، تصویر، نمودار و placeholderهای محتوای عمومی هستند. برخلاف یک شکل معمولی، یک placeholder می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از اسلاید طرح‌بندی یا اسلاید مستر به ارث ببرد.

Aspose.Slides اطلاعات placeholder را از طریق متد [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) در دسترس می‌گذارد. این متد یک شیء [IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) یا `null` برای یک شکل معمولی برمی‌گرداند. برای تعیین محتوایی که placeholder قرار است دربرگیرد، از [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) استفاده کنید.

رابط shape پس از شناخت نوع placeholder همچنان مهم است:

- یک placeholder خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) نمایان می‌شود.
- یک placeholder تصویر پرشده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) نمایش داده شود.
- یک placeholder نمودار پرشده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) نمایش داده شود.
- یک placeholder محتوا می‌تواند انواع مختلفی از محتوا را دربرگیرد. به جای اینکه فرض کنید هر placeholder یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) است، هم [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) و هم رابط shape زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) نقش یک placeholder را توصیف می‌کند؛ اما نوع زمان اجرای shape را تضمین نمی‌کند. قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه‌ای، همیشه بررسی نوع را انجام دهید.
{{% /alert %}}

## **درک وراثت Placeholder**

Placeholderها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید مستر سبک‌های قابل استفاده مجدد و در برخی موارد placeholderهای سطح مستر را تعریف می‌کند.
2. یک اسلاید طرح‌بندی چیدمان مورد استفاده توسط یک یا چند اسلاید معمولی را تعریف می‌کند و می‌تواند از مستر ارث ببرد.
3. یک اسلاید معمولی placeholderهای مربوط به آن اسلاید را شامل می‌شود و می‌تواند از طرح‌بندی خود ارث برد.

برای جابجایی یک سطح بالاتر در این سلسله‌مراتب، متد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) را فراخوانی کنید. یک placeholder اسلاید معمولاً placeholder طرح‌بندی خود را برمی‌گرداند؛ یک placeholder طرح‌بندی می‌تواند placeholder مستر خود را برگرداند. این متد زمانی که shape پایه‌ای نداشته باشد `null` برمی‌گرداند.

مثال زیر placeholderهای اسلاید اول را فهرست کرده و پایهٔ آن‌ها را گزارش می‌دهد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ویرایش یک placeholder در یک اسلاید معمولی، یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش طرح‌بندی یا مستر مربوطه می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند تأثیر بگذارد. یک shape معمولی محلی هیچ placeholder پایه‌ای ندارد و فقط به دلیل قرارگیری در همان مختصات شروع به ارث‌بری نمی‌کند.

## **حذف وضعیت Placeholder**

هنگام تطبیق یک قالب، از متد [IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--) برای نگه داشتن یک شیء موجود به عنوان یک shape عادی استفاده کنید. متد [getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--) آن `null` برمی‌گرداند، اما shape در مجموعه اسلاید باقی می‌ماند. در مقابل، متد [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) shape را از آن مجموعه حذف می‌کند.

مثال زیر به یک فایل `template.pptx` که حداقل یک اسلاید و یک placeholder متنی غیرخالی در اسلاید اول دارد، نیاز دارد. برای مشاهدهٔ تأثیر حذف رابطهٔ placeholder، از یک placeholder با قالب‌بندی به ارث‌برده از طرح‌بندی یا مستر استفاده کنید. مثال بررسی می‌کند که همان shape باقی می‌ماند، دوباره متد را بر روی shape عادی صدا می‌زند و نتیجه را ذخیره می‌کند.

{{% alert color="warning" title="Warning" %}}
حذف وضعیت placeholder به‌طور خودکار تنظیمات ظاهر ارث‌برده را حفظ نمی‌کند. مثال زیر به‌صراحت این تنظیمات را دست‌نخورده می‌گذارد، بنابراین خروجی ممکن است متفاوت به‌نظر برسد. یک shape که موقعیت و اندازه‌اش کاملاً ارث‌برده است، پس از فراخوانی ممکن است مختصات و ابعاد صفر داشته باشد و نامرئی شود، هرچند در مجموعه باقی می‌ماند.
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null ||
            textFrame == null ||
            textFrame.getText() == null ||
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // فراخوانی این متد بر روی یک shape عادی هیچ اثری ندارد.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

برای یک placeholder منطبق، هر سه بررسی `true` چاپ می‌کنند. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، قلم، تنظیمات پاراگراف، حاشیه‌های فریم متن، لنگر عمودی، پرشدن و تنظیمات خط می‌توانند وقتی رابطهٔ placeholder حذف می‌شود تغییر کنند. برای مثال، قالب‌بندی ارث‌بردهٔ عنوان می‌تواند به قالب‌بندی متن عادی بازگردد. برای اطلاعات بیشتر در مورد طرح‌بندی‌ها به [Slide Layout](/slides/fa/androidjava/slide-layout/) مراجعه کنید.

برای حفظ ظاهر موردنظر، قبل از فراخوانی موقعیت، اندازه و چرخش حل‌شده را ضبط کنید و مقادیر قالب‌بندی مؤثر موردنیاز را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--)، [IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--)، [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--)، [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--) و [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--) بازیابی کنید. فقط به شیء‌های قالب‌بندی مؤثر تکیه نکنید، چون مقادیر قالب‌بندی متن آن‌ها می‌تواند پس از حذف رابطه تغییر کند. پس از آن، مقادیر ضبط‌شده را به طور صریح بر روی shape عادی اعمال کنید، از جمله خانواده قلم، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات فریم متن، پرشدن و خط مورد استفاده در قالب شما.

ژئومتری shape ارث‌برده ممکن است نیاز به اختصاص صریح از طریق [IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-) داشته باشد. برای یک placeholder متنی مستطیلی، این به معنای اختصاص [ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle) است؛ تنها بازگرداندن پرشدن و خط ممکن است مستطیل قابل مشاهده را بازنشانی نکند. قالب‌هایی با اثرات اضافی یا قالب‌بندی پیچیده‌تر نیازمند مدیریت همان تنظیمات نیز هستند.

## **تغییر متن در یک Placeholder**

Placeholderهای عنوان، عنوان‑مرکزی، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) آن، وجود یک [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) را بررسی کنید.

این مثال اولین placeholder عنوان در اسلاید اول را به‌روز کرده و نتیجه را ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این الگو از تبدیل placeholderهای تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین placeholder را بر اساس هدفش شناسایی می‌کند به‌جای اتکا به یک ایندکس شکنندهٔ shape.

## **تنظیم متن راهنما در یک Layout**

متن راهنما دستور طراحی‌ای است که در یک placeholder خالی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. متن راهنما را بر روی placeholder طرح‌بندی تنظیم کنید نه این‌که سعی کنید از طریق مجموعهٔ shapeهای اسلاید عادی به آن دسترسی پیدا کنید. با استفاده از [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) به layout دسترسی پیدا کنید و بر روی مجموعه‌ای که [ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/) برمی‌گرداند، تکرار کنید.

مثال زیر متن راهنمای عنوان و زیرعنوان را در layout استفاده‌شده توسط اسلاید اول تغییر می‌دهد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متن راهنما محتوی اسلاید عادی نیست. این متن برای placeholderهای خالی در برنامه‌های ویرایشی مانند PowerPoint درنظر گرفته شده است. هنگامی که کاربر یا برنامه محتوای واقعی را وارد می‌کند، راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما همچنین متن موجود در اسلایدهای استفاده‌کننده از layout را جایگزین نمی‌کند.

## **به‌روزرسانی یک Placeholder تصویر**

دو حالت برای پردازش وجود دارد:

- اگر placeholder تصویر قبلاً پرشده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) نشان داده شود، تصویر را از طریق [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) و [ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) جایگزین کنید.
- اگر هنوز یک placeholder خالی باشد، یک picture frame در مختصات placeholder با استفاده از [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/) اضافه کنید و placeholder خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

جایگزینی ایجاد شده برای یک placeholder خالی یک picture frame محلی است، نه یک placeholder جدید، چون [IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) setter ارائه نمی‌دهد. این جایگزینی موقعیت رزرو شده را حفظ می‌کند اما دیگر رفتار خاص placeholder را به ارث نمی‌برد. اگر حفظ رابطهٔ placeholder حیاتی باشد، ابتدا placeholder را در PowerPoint آماده کنید، سپس [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) حاصل را با Aspose.Slides بروز کنید.

برای شفافیت تصویر، برش و سایر اثرات خاص تصویر، به مقالهٔ [Manage Picture Frames](/slides/fa/androidjava/picture-frame/) مراجعه کنید. این عملیات‌ها به picture frame یا picture fill تعلق دارند، نه به متادادهٔ placeholder.

## **کار با Placeholderهای نمودار و محتوا**

یک placeholder نمودار پرشده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) نشان داده شود. این مثال یک نمودار را هم بر اساس نوع placeholder و هم بر اساس رابط زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یک placeholder محتوای عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) است. در PowerPoint این placeholder به‌عنوان یک راه‌انداز برای چندین نوع محتوا عمل می‌کند، از جمله نمودارها، جدول‌ها، دیاگرام‌ها، تصاویر و رسانه‌ها. پس از پر شدن، رابط shape واقعی را بررسی کنید تا متوجه شوید چه چیزی درون آن است. طرح‌بندی‌های تخصصی می‌توانند [PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/) را نمایش دهند.

Aspose.Slides یک placeholder خالی [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) را صرفاً با تغییر [IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/) به یک [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) تبدیل نمی‌کند؛ نوع از طریق این رابط قابل تغییر نیست. برای برنامه‌نویسی یک نمودار یا ناحیهٔ محتوا خالی، شیء مورد نیاز را در مختصات placeholder اضافه کنید و سپس placeholder خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمودار اضافه‌شده یک نمودار محلی عادی است. این نمودار ناحیهٔ placeholder را اشغال می‌کند اما از layout placeholder ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتاب‌کار، از مقالات مدیریت نمودارهای اختصاصی ([chart management articles](/slides/fa/androidjava/powerpoint-charts/)) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها‑به‑انتها زیر یک قالب را باز می‌کند، در اسلاید اول به دنبال یک placeholder عنوان یا تصویر می‌گردد، نوع placeholder و shape را بررسی می‌کند، محتوای مناسب را به‌روز می‌کند و خروجی را ذخیره می‌گیرد. این مثال عمدیاً از فرض ایندکس shape یا تبدیل هر placeholder به یک رابط یکسان جلوگیری می‌کند.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**Placeholder پایه چیست؟**

Placeholder پایه، شکل متناظر روی layout یا مستری است که از آن placeholder دیگری ارث می‌برد. برای بازیابی آن از [IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) استفاده کنید. یک shape محلی عادی `null` برمی‌گرداند زیرا بخشی از سلسله‌مراتب placeholder نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک placeholder طرح‌بندی تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمای ارث‌برده را از طریق layout تغییر دهید، اما محتوای عنوان موجود در اسلایدهای عادی ذخیره شده است. برای جایگزینی واقعی متن عنوان در سراسر ارائه، بر روی اسلایدها تکرار کنید و هر placeholder عنوان را به‌روزرسانی کنید.

**چگونه placeholderهای تاریخ، شماره اسلاید، سرصفحه و پانویس را مدیریت کنم؟**

از مدیرهای سرصفحه و پانویس در سطح اسلاید، layout، مستر، یادداشت یا توزیع‌کننده استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/androidjava/presentation-header-and-footer/) مراجعه کنید.