---
title: مدیریت جای‌نگهدارهای ارائه در جاوا
linktitle: مدیریت جای‌نگهدارها
type: docs
weight: 10
url: /fa/java/manage-placeholder/
keywords:
- جای‌نگهدار
- جای‌نگهدار متن
- جای‌نگهدار تصویر
- جای‌نگهدار نمودار
- جای‌نگهدار محتوا
- متن راهنما
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه جای‌نگهدارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و ارث‌بری جای‌نگهدارها را با Aspose.Slides برای جاوا درک کنید."
---
## **مرور کلی**

یک جای‌نگهدار شکلی است که برای یک نوع خاص از محتوا در قالب ارائه یک موقعیت را رزرو می‌کند. مثال‌های رایج شامل عنوان، بدنه، تصویر، نمودار و جای‌نگهدارهای محتوا با کاربرد عمومی است. بر خلاف یک شکل عادی، جای‌نگهدار می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید چیدمان یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات جای‌نگهدار را از طریق متد [IShape.getPlaceholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) در دسترس می‌گذارد. این متد یک شیء [IPlaceholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholder/) یا `null` برای یک شکل عادی بر می‌گرداند. برای تعیین محتوایی که جای‌نگهدار قرار است شامل شود، از [IPlaceholder.getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholder/) استفاده کنید.

رابط شکل همچنان پس از دانستن نوع جای‌نگهدار مهم است:

- یک جای‌نگهدار خالی متن، تصویر، نمودار یا محتوا معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) نمایش داده می‌شود.
- یک جای‌نگهدار تصویر پرشده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) نمایان شود.
- یک جای‌نگهدار نمودار پرشده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/) نمایان شود.
- یک جای‌نگهدار محتوا می‌تواند شامل چندین نوع محتوا باشد. هم [IPlaceholder.getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholder/) و رابط شکل زمان اجرا را بررسی کنید نه این تصور که هر جای‌نگهدار یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) است.

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholder/) نقش یک جای‌نگهدار را توصیف می‌کند؛ تضمین نمی‌کند که نوع زمان اجرا (runtime) شکل همان باشد. همیشه قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه‌ای، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بوری جای‌نگهدار**

جای‌نگهدارها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد جای‌نگهدارهای سطح اصلی را نیز شامل می‌شود.
2. یک اسلاید چیدمان (layout) ترتیب استفاده شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اسلاید اصلی ارث‌بری کند.
3. یک اسلاید عادی شامل جای‌نگهدارهای آن اسلاید است و می‌تواند از چیدمان خود ارث‌بری کند.

برای حرکت یک سطح بالاتر در این سلسله‌مراتب، متد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را فراخوانی کنید. یک جای‌نگهدار اسلاید معمولاً جای‌نگهدار چیدمان خود را برمی‌گرداند؛ یک جای‌نگهدار چیدمان می‌تواند جای‌نگهدار اصلی (master) خود را برگرداند. این متد زمانی که شکل پایه (base) جای‌نگهداری نداشته باشد، `null` بر می‌گرداند.

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

ویرایش یک جای‌نگهدار در یک اسلاید عادی یک تغییر محلی برای آن اسلاید ایجاد یا اصلاح می‌کند. ویرایش چیدمان یا اسلاید اصلی مربوطه می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را به ارث می‌برند، تأثیر بگذارد. یک شکل عادی محلی پایه (base) جای‌نگهداری ندارد و صرفاً به این دلیل که در همان مختصات قرار دارد، شروع به ارث‌بری نمی‌کند.

## **تغییر متن در یک جای‌نگهدار**

جای‌نگهدارهای عنوان، عنوان‌متمرکز، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را بررسی کنید.

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

این الگو از تبدیل (cast) جای‌نگهدارهای تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین جای‌نگهدار را بر اساس هدف شناسایی می‌کند نه این که به یک شاخص شکل ناپایدار تکیه کند.

## **تنظیم متن راهنما در یک طرح‌بندی**

متن راهنما (Prompt text) دستور طراحی است که در یک جای‌نگهدار خالی نمایش داده می‌شود، مانند *Click to add title*. متن راهنمای سفارشی را بر روی جای‌نگهدار طرح‌بندی تنظیم کنید نه این‌که سعی کنید از طریق مجموعه شکل‌های اسلاید عادی به آن دسترسی پیدا کنید. با استفاده از [ISlide.getLayoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islide/) به طرح‌بندی دسترسی پیدا کنید و بر روی مجموعه‌ای که توسط [ILayoutSlide.getShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/) بر می‌گردد، پیمایش کنید.

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

متن راهنما محتوی عادی اسلاید نیست. این متن برای جای‌نگهدارهای خالی در برنامه‌های ویرایشی مانند PowerPoint طراحی شده است. هنگامی که کاربر یا برنامه محتوای واقعی را فراهم می‌کند، این راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما همچنین متن موجود در اسلایدهایی که از این طرح‌بندی استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک جای‌نگهدار تصویر**

دو حالت برای مدیریت وجود دارد:

- اگر جای‌نگهدار تصویر قبلاً پر شده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) نمایش داده می‌شود، تصویر را از طریق [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipicturefillformat/) و [ISlidesPicture.setImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/) جایگزین کنید.
- اگر هنوز یک جای‌نگهدار خالی باشد، یک فریم تصویر را در مختصات جای‌نگهدار با استفاده از [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/) اضافه کنید و جای‌نگهدار خالی را حذف کنید.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

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

جایگذاری ایجاد شده برای یک جای‌نگهدار خالی یک فریم تصویر محلی است، نه یک جای‌نگهدار جدید، زیرا [IShape.getPlaceholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) تنظیم‌کننده (setter) ای ارائه نمی‌دهد. موقعیت رزرو شده حفظ می‌شود اما دیگر رفتار خاص جای‌نگهدار را به ارث نمی‌برد. اگر حفظ ارتباط جای‌نگهدار حیاتی است، ابتدا در PowerPoint جای‌نگهدار را آماده و پر کنید، سپس فریم تصویر حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر اثرات خاص تصویر، به [Manage Picture Frames](/slides/fa/java/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پرکننده تصویر تعلق دارند نه به فراداده‌های جای‌نگهدار.

## **کار با جای‌نگهدارهای نمودار و محتوا**

یک جای‌نگهدار نمودار پرشده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/) نمایش داده شود. این مثال یک نمودار را هم بر اساس نوع جای‌نگهدار و هم رابط زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک جای‌نگهدار محتوای عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholdertype/) است. در PowerPoint این جای‌نگهدار به‌عنوان راه‌انداز چندین نوع محتوا عمل می‌کند، از جمله نمودارها، جداول، دیاگرام‌ها، تصاویر و رسانه‌ها. پس از اینکه پر شد، رابط شکل واقعی را بررسی کنید تا بفهمید چه چیزی در آن وجود دارد. طرح‌بندی‌های تخصصی می‌توانند همچنین [PlaceholderType.Chart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholdertype/)، [PlaceholderType.Picture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholdertype/)، [PlaceholderType.Media](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholdertype/)، یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholdertype/) را باز کنند.

Aspose.Slides یک جای‌نگهدار خالی [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را فقط با تغییر [IPlaceholder.getType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/placeholder/) به یک [IChart](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ichart/) تبدیل نمی‌کند؛ نوع نمی‌تواند از طریق این رابط تغییر یابد. برای پر کردن برنامه‌نویسی یک ناحیه خالی نمودار یا محتوا، شیء مورد نیاز را در مختصات جای‌نگهدار اضافه کنید و سپس جای‌نگهدار خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نمودار اضافه شده یک نمودار محلی عادی است. این نمودار ناحیهٔ جای‌نگهدار را اشغال می‌کند اما از جای‌نگهدار طرح‌بندی ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتابخانهٔ کار، از مقالات تخصصی [chart management articles](/slides/fa/java/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها به انتهای زیر یک قالب را باز می‌کند، اسلاید نخست را برای یافتن یک جای‌نگهدار عنوان یا تصویر جستجو می‌کند، نوع جای‌نگهدار و شکل را بررسی می‌کند، محتوای مناسب را به‌روز می‌کند و خروجی را ذخیره می‌نماید. این مثال عمداً از فرض وجود شاخص شکل یا تبدیل همهٔ جای‌نگهدارها به همان رابط خودداری می‌کند:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

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

**پایه‌ٔ جای‌نگهدار چیست؟**

یک پایه‌ٔ جای‌نگهدار شکل متناظر روی چیدمان یا اسلاید اصلی است که یک جای‌نگهدار دیگر از آن ارث می‌برد. برای به‌دست آوردن آن از [IShape.getBasePlaceholder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) استفاده کنید. یک شکل محلی عادی `null` بر می‌گرداند زیرا بخشی از سلسله‌مراتب جای‌نگهدار نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک جای‌نگهدار طرح‌بندی تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنما را از طریق یک طرح‌بندی تغییر دهید، اما محتوای واقعی عنوان در اسلایدهای عادی ذخیره شده است. برای جایگزینی متن عنوان در کل ارائه، بر اسلایدها پیمایش کنید و هر جای‌نگهدار عنوان را به‌روز نمایید.

**چگونه می‌توانم جای‌نگهدارهای تاریخ، شماره اسلاید، سرصفحه و پاورنوت را مدیریت کنم؟**

از مدیرهای سرصفحه و پاورنوت در سطح اسلاید مناسب، طرح‌بندی، اسلاید اصلی، یادداشت‌ها یا برگه‌های توزیع استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/java/presentation-header-and-footer/) مراجعه کنید.