---
title: مدیریت Placeholderهای ارائه در اندروید
linktitle: مدیریت Placeholderها
type: docs
weight: 10
url: /fa/androidjava/manage-placeholder/
keywords:
- placeholder
- placeholder متن
- placeholder تصویر
- placeholder نمودار
- placeholder محتوا
- متن راهنما
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه placeholderهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و ارث‌بری placeholderها را با Aspose.Slides برای اندروید از طریق Java درک کنید."
---
## **نمای کلی**

یک placeholder یک شکل است که موقعیتی را برای نوع خاصی از محتوا در قالب ارائه رزرو می‌کند. مثال‌های رایج شامل عنوان، بدنه، تصویر، نمودار و placeholderهای محتوا با کاربرد عمومی هستند. بر خلاف یک شکل معمولی، یک placeholder می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید طرح‌بندی یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات placeholder را از طریق متد [IShape.getPlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) در معرض نمایش می‌گذارد. این متد یک شیء [IPlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholder/) یا `null` برای یک شکل معمولی برمی‌گرداند. برای تعیین محتوای مورد انتظار placeholder از [IPlaceholder.getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholder/) استفاده کنید.

پس از شناخت نوع placeholder، رابط شکل همچنان مهم است:

- یک placeholder خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) نشان داده می‌شود.
- یک placeholder تصویر پر شده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) نمایش داده شود.
- یک placeholder نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/) نمایش داده شود.
- یک placeholder محتوا می‌تواند انواع مختلفی از محتوا را داشته باشد. به جای این که فرض کنید هر placeholder یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) است، هم [IPlaceholder.getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholder/) و هم رابط شکل زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholder/) نقش یک placeholder را توصیف می‌کند؛ اما نوع زمان اجراهای شکل را تضمین نمی‌کند. قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه‌ای، همیشه یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بری Placeholderها**

Placeholderها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد و در برخی موارد placeholderهای سطح اصلی را تعریف می‌کند.
2. یک اسلاید طرح‌بندی (layout) ترتیب استفاده‌شده توسط یک یا چند اسلاید عادی را تعیین می‌کند و می‌تواند از اسلاید اصلی ارث‌بری کند.
3. یک اسلاید عادی placeholderهای آن اسلاید را شامل می‌شود و می‌تواند از طرح‌بندی خود ارث‌بری کند.

برای حرکت یک سطح بالا در این سلسله‌مراتب از [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) فراخوانی کنید. یک placeholder اسلاید معمولاً placeholder طرح‌بندی خود را برمی‌گرداند؛ یک placeholder طرح‌بندی می‌تواند placeholder اصلی خود را برگرداند. این متد `null` برمی‌گرداند زمانی که شکل پایه‌ای placeholder ندارد.

مثال زیر placeholderهای اسلاید اول را فهرست می‌کند و placeholderهای پایه آن‌ها را گزارش می‌دهد:

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

ویرایش یک placeholder در اسلاید عادی باعث ایجاد یا تغییر یک لغو محلی برای آن اسلاید می‌شود. ویرایش طرح‌بندی یا اسلاید اصلی می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند، تأثیر بگذارد. یک شکل عادی محلی پایه‌ای placeholder ندارد و صرفاً به دلیل داشتن همان مختصات شروع به ارث‌بری نمی‌کند.

## **تغییر متن در یک Placeholder**

placeholderهای عنوان، عنوان میانی‑مرکز، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) بر روی یک شکل، وجود [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) را بررسی کنید.

این مثال اولین placeholder عنوان را در اسلاید اول به‌روز می‌کند و نتیجه را ذخیره می‌نماید:

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

این الگو از تبدیل placeholderهای تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین placeholder را بر اساس هدف شناسایی می‌کند نه بر پایه یک ایندکس شکنندهٔ شکل.

## **تنظیم متن راهنما بر روی یک Layout**

متن راهنما (Prompt text) دستورالعملی در زمان طراحی است که در یک placeholder خالی نمایش داده می‌شود، مانند *Click to add title*. متن راهنما را بر روی placeholder طرح‌بندی تنظیم کنید نه این‌که سعی کنید از طریق مجموعهٔ شکل‌های اسلاید عادی به آن دسترسی پیدا کنید. برای این کار layout را از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islide/) دریافت کنید و بر روی مجموعه‌ای که [ILayoutSlide.getShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/) برمی‌گرداند پیمایش کنید.

مثال زیر متن راهنمای عنوان و زیرعنوان را در layout استفاده‌شده توسط اسلاید اول تغییر می‌کند:

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

متن راهنما محتویات اسلاید عادی نیست. این متن برای placeholderهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. هنگامی که کاربر یا برنامه محتواهای واقعی را فراهم کند، متن راهنما نمایش داده نمی‌شود. تغییر یک راهنما همچنین متن موجود در اسلایدهایی که از این layout استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک Picture Placeholder**

دو حالت وجود دارد:

- اگر placeholder تصویر قبلاً پر شده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) نمایش داده می‌شود، تصویر را از طریق [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipicturefillformat/) و [ISlidesPicture.setImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/) جایگزین کنید.
- اگر هنوز یک placeholder خالی باشد، یک picture frame را در مختصات placeholder با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) اضافه کنید و placeholder خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه (presentation) را ذخیره می‌نماید:

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

جایی که برای یک placeholder خالی جایگزینی ایجاد می‌شود، یک picture frame محلی است، نه یک placeholder جدید، زیرا [IShape.getPlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) setter‌ای ارائه نمی‌دهد. این کار موقعیت رزرو شده را حفظ می‌کند اما دیگر رفتارهای خاص placeholder را به ارث نمی‌برد. اگر حفظ رابطهٔ placeholder ضروری است، ابتدا placeholder را در PowerPoint آماده و پر کنید، سپس [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر اثرات مخصوص تصویر، به [Manage Picture Frames](/slides/fa/androidjava/picture-frame/) مراجعه کنید. این عملیات به picture frame یا picture fill مربوط می‌شود، نه به متادیتای placeholder.

## **کار با Chart و Content Placeholderها**

یک placeholder نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/) نمایش داده شود. این مثال نمودار را هم بر اساس نوع placeholder و هم بر اساس رابط زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک placeholder محتوای عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholdertype/) است. در PowerPoint به‌عنوان یک نقطهٔ شروع برای انواع محتواهای مختلف از جمله نمودارها، جدول‌ها، دیاگرام‌ها، تصاویر و رسانه‌ها عمل می‌کند. پس از پر شدن، برای شناخت دقیق محتوای آن رابط شکل واقعی را بررسی کنید. طرح‌بندی‌های تخصصی می‌توانند همچنین [PlaceholderType.Chart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Picture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholdertype/)، [PlaceholderType.Media](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholdertype/)، یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholdertype/) را نمایش دهند.

Aspose.Slides یک placeholder خالی [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) را صرف تغییر [IPlaceholder.getType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/placeholder/) به یک [IChart](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ichart/) تبدیل نمی‌کند؛ نوع از طریق این رابط قابل تغییر نیست. برای پر کردن برنامه‌نویسی یک ناحیهٔ خالی نمودار یا محتوا، شیء مورد نیاز را در مختصات placeholder اضافه کنید و سپس placeholder خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نموداری که اضافه می‌شود یک نمودار محلی عادی است. این نمودار در ناحیهٔ placeholder قرار می‌گیرد اما از placeholder طرح‌بندی ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های workbook، مقالات مخصوص مدیریت نمودارها را در [chart management articles](/slides/fa/androidjava/powerpoint-charts/) مطالعه کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها‑به‑انتها زیر یک قالب را باز می‌کند، اسلاید اول را برای پیدا کردن یک placeholder عنوان یا تصویر جستجو می‌کند، نوع placeholder و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌نماید. این مثال به‌طور عمدی از فرض ایندکس شکل یا تبدیل همه placeholderها به یک رابط یکسان خودداری می‌کند.

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

## **سؤالات متداول**

**Placeholder پایه چیست؟**

یک placeholder پایه شکل مربوطه در layout یا master است که از آن placeholder دیگری ارث می‌برد. برای دریافت آن از [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) استفاده کنید. یک شکل محلی عادی `null` برمی‌گرداند زیرا بخشی از سلسله‌مراتب placeholder نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک placeholder در layout تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمای ارث‌بری‌شده را از طریق یک layout تغییر دهید، اما محتوای واقعی عنوان در اسلایدهای عادی ذخیره می‌شود. برای جایگزینی متن عنوان در سراسر ارائه، بر روی اسلایدها پیمایش کنید و هر placeholder عنوان را به‌روز کنید.

**چگونه placeholderهای تاریخ، شماره اسلاید، هدر و فوتر را مدیریت کنم؟**

از مدیران هدر و فوتر در سطح اسلاید، layout، master، notes یا handout مناسب استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/androidjava/presentation-header-and-footer/) مراجعه کنید.