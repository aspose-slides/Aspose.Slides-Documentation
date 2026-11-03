---
title: مدیریت جای‌دارهای ارائه در جاوا
linktitle: مدیریت جای‌دارها
type: docs
weight: 10
url: /fa/java/manage-placeholder/
keywords:
- جای‌دار
- جای‌دار متن
- جای‌دار تصویر
- جای‌دار نمودار
- جای‌دار محتوا
- متن راهنما
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یادگیری نحوه بررسی و ویرایش جای‌دارهای متن، تصویر، نمودار و محتوا و درک ارث‌بری جای‌دارها با Aspose.Slides برای جاوا."
---
## **مروری کلی**

یک جای‌دار (placeholder) شکلی است که موقعیتی را برای نوع خاصی از محتوا در الگوی ارائه رزرو می‌کند. مثال‌های رایج عبارتند از عنوان، بدنه، تصویر، نمودار و جای‌دارهای محتوای عمومی. برخلاف یک شکل معمولی، یک جای‌دار می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از اسلاید چیدمان یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات جای‌دار را از طریق متد [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) فراهم می‌کند. این متد یک شیء [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) یا `null` برای یک شکل عادی برمی‌گرداند. برای تعیین محتوای مورد انتظار جای‌دار، از [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) استفاده کنید.

رابط شکل حتی پس از دانستن نوع جای‌دار نیز مهم است:

- یک جای‌دار متن، تصویر، نمودار یا محتوا خالی معمولاً توسط یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) نشان داده می‌شود.
- یک جای‌دار تصویر پر شده می‌تواند توسط یک [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) نشان داده شود.
- یک جای‌دار نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) نشان داده شود.
- یک جای‌دار محتوا می‌تواند چندین نوع محتوا را در بر بگیرد. به جای فرض اینکه هر جای‌دار یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) است، هم [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) و هم رابط شکل زمان اجرا را بررسی کنید.

{{% alert color="warning" title="هشدار" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) نقش یک جای‌دار را توصیف می‌کند؛ اما نوع زمان اجرا‌ی شکل را تضمین نمی‌کند. همیشه قبل از دسترسی به اعضای متن، تصویر، نمودار، جدول یا رسانه، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک ارث‌بری جای‌دار**

جای‌دارها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد و در برخی موارد جای‌دارهای سطح اصلی را تعریف می‌کند.
2. یک اسلاید چیدمان (layout) ترتیب استفاده‌شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از اصلی ارث‌بری کند.
3. یک اسلاید عادی شامل جای‌دارهای خود است و می‌تواند از چیدمان خود ارث‌بری کند.

برای حرکت یک سطح بالاتر در این سلسله‌مراتب، متد [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) را فراخوانی کنید. یک جای‌دار اسلاید معمولاً جای‌دار چیدمان خود را برمی‌گرداند؛ یک جای‌دار چیدمان می‌تواند جای‌دار اصلی خود را برگرداند. این متد زمانی که شکل هیچ جای‌دار پایه‌ای نداشته باشد، `null` برمی‌گرداند.

مثال زیر جای‌دارهای اسلاید اول را فهرست می‌کند و جای‌دارهای پایهٔ آن‌ها را گزارش می‌دهد:

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

ویرایش یک جای‌دار در یک اسلاید عادی یک لغو محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش چیدمان یا اصلی مرتبط می‌تواند بر تمام اسلایدهایی که هنوز آن تنظیم را ارث می‌برند تأثیر بگذارد. یک شکل عادی محلی هیچ جای‌دار پایه‌ای ندارد و صرفاً به دلیل قرارگیری در همان مختصات، شروع به ارث‌بری نمی‌کند.

## **حذف وضعیت جای‌دار**

هنگام تطبیق یک الگو، از متد [IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) برای نگه داشتن یک شیء موجود به‌عنوان یک شکل عادی استفاده کنید. متد [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) آن `null` برمی‌گرداند، اما شکل در مجموعه اسلاید باقی می‌ماند. در مقابل، متد [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) شکل را از آن مجموعه حذف می‌کند.

مثال زیر به `template.pptx` که حداقل یک اسلاید و یک جای‌دار متن غیرخالی در اسلاید اول دارد، نیاز دارد. برای دیدن اثر حذف این رابطه، از یک جای‌دار با قالب‌بندی ارث‌بری‌شده از چیدمان یا اصلی استفاده کنید. مثال بررسی می‌کند که همان شکل باقی می‌ماند، دوباره متد را روی شکل اکنون عادی صدا می‌زند و نتیجه را ذخیره می‌کند.

{{% alert color="warning" title="هشدار" %}}
حذف وضعیت جای‌دار به‌طور خودکار تنظیمات ظاهر ارث‌بری‌شده را حفظ نمی‌کند. مثال زیر عمداً این تنظیمات را دست نخورده می‌گذارد، بنابراین خروجی ممکن است متفاوت به‌نظر برسد. یک شکل که موقعیت و اندازه‌اش کاملاً ارث‌بری شده باشد، پس از فراخوانی می‌تواند مختصات و ابعاد صفر داشته باشد و حتی اگر در مجموعه باقی بماند، نامرئی شود.
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

        // فراخوانی متد روی یک شکل عادی هیچ تأثیری ندارد.
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

برای یک جای‌دار منطبق، هر سه بررسی `true` چاپ می‌شود. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، فونت، تراز پاراگراف، حاشیه‌های فریم متن، لنگر عمودی، پرکردن و تنظیمات خط می‌توانند هنگام حذف رابطهٔ جای‌دار تغییر کنند. به‌عنوان مثال، قالب‌بندی ارث‌بری عنوان ممکن است به قالب‌بندی متن عادی بازگردد. برای اطلاعات بیشتر دربارهٔ چیدمان‌ها، به صفحه [Slide Layout](/slides/fa/java/slide-layout/) مراجعه کنید.

برای حفظ ظاهر موردنظر، موقعیت، اندازه و چرخش نهایی را پیش از فراخوانی ضبط کنید و مقادیر قالب‌بندی مؤثر موردنیاز را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--)، [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--)، [ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--)، [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--) و [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) بازیابی کنید. به تنها اکتساب اشیای قالب‌بندی مؤثر اکتفا نکنید، زیرا مقادیر قالب‌بندی متن آن‌ها می‌تواند پس از حذف رابطه تغییر کند. مقادیر ضبط‌شده را پس از آن به شکل عادی اعمال کنید، شامل خانواده فونت، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات فریم متن، پرکردن و خط استفاده‌شده توسط الگوی شما.

شکل‌ریزی ارث‌بری‌شده ممکن است نیاز به اختصاص صریح از طریق [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-) داشته باشد. برای یک جای‌دار متن مستطیلی، این به معنای اختصاص [ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle) است؛ بازگرداندن فقط پرکردن و خط ممکن است مستطیل قابل رؤیت را بازنمی‌گرداند. قالب‌هایی که افکت‌های اضافی یا قالب‌بندی پیچیده‌تری دارند، نیاز به مدیریت این تنظیمات نیز دارند.

## **تغییر متن در یک جای‌دار**

جای‌دارهای عنوان، عنوان‌وسط‌چین، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) آن، اطمینان حاصل کنید که شکل یک [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) است.

این مثال عنوان اولین جای‌دار در اسلاید اول را به‌روز می‌کند و نتیجه را ذخیره می‌کند:

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

این الگو از تبدیل جای‌دارهای تصویر، نمودار، جدول یا رسانه به [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) جلوگیری می‌کند. همچنین جای‌دار را بر اساس هدفش شناسایی می‌کند به‌جای تکیه بر یک شاخص شکل ناپایدار.

## **تنظیم متن راهنما در یک چیدمان**

متن راهنما (prompt text) آموزش‑زمان‌طراحی است که در یک جای‌دار خالی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. برای تنظیم متن راهنمای سفارشی، آن را در جای‌دار چیدمان تنظیم کنید نه این‌که سعی کنید از طریق مجموعهٔ شکل‌های اسلاید عادی به آن دسترسی پیدا کنید. چیدمان را از طریق [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) دریافت کنید و بر روی مجموعه‌ای که [ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/) برمی‌گرداند، تکرار کنید.

مثال زیر نکات راهنمای عنوان و زیرعنوان را در چیدمان استفاده‌شده توسط اسلاید اول تغییر می‌دهد:

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

متن راهنما محتوی معمولی اسلاید نیست. این متن برای جای‌دارهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. هنگامی که کاربر یا برنامه محتوی واقعی فراهم می‌کند، متن راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما همچنین متن موجود در اسلایدهایی که از این چیدمان استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک جای‌دار تصویر**

دو حالت برای مدیریت وجود دارد:

- اگر جای‌دار تصویر قبلاً پر شده باشد و توسط یک [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) نشان داده شود، تصویر را از طریق [IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) و [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) جایگزین کنید.
- اگر هنوز یک جای‌دار خالی است، یک فریم تصویر را در مختصات جای‌دار با [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) اضافه کنید و جای‌دار خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌کند:

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

جای‌گذاری ایجاد شده برای یک جای‌دار خالی یک فریم تصویر محلی است، نه یک جای‌دار جدید، زیرا [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) تنظیم‌گری (setter) ندارد. موقعیت رزروشده را حفظ می‌کند اما دیگر رفتار خاص جای‌دار را به ارث نمی‌برد. اگر حفظ رابطهٔ جای‌دار ضروری است، ابتدا جای‌دار را در PowerPoint آماده و پر کنید، سپس [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر افکت‌های خاص تصویر، به صفحه [Manage Picture Frames](/slides/fa/java/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پرکن تصویر تعلق دارند، نه به فرادادهٔ جای‌دار.

## **کار با جای‌دارهای نمودار و محتوا**

یک جای‌دار نمودار پر شده می‌تواند توسط یک [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) نشان داده شود. این مثال چنین نموداری را هم بر پایهٔ نوع جای‌دار و هم بر پایهٔ رابط زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک جای‌دار محتوا عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) است. در PowerPoint به‌عنوان راه‌انداز برای چندین نوع محتوا، از جمله نمودارها، جداول، دیاگرام‌ها، تصاویر و رسانه‌ها عمل می‌کند. پس از پر شدن، برای شناخت محتوا باید رابط شکل واقعی را بررسی کنید. چیدمان‌های تخصصی می‌توانند [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)، [PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)، [PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)، [PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)، یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) را نمایان کنند.

Aspose.Slides یک جای‌دار خالی [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) را فقط با تغییر [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) به [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) تبدیل نمی‌کند؛ نوع از طریق این رابط قابل تغییر نیست. برای پر کردن برنامه‌ای یک نمودار یا ناحیهٔ محتوا خالی، شیء موردنظر را در مختصات جای‌دار اضافه کنید و سپس جای‌دار خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نمودار اضافه‌شده یک نمودار محلی عادی است. این نمودار ناحیهٔ جای‌دار را اشغال می‌کند اما از جای‌دار چیدمان ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های کتاب‌کار، از مقالات اختصاصی [chart management articles](/slides/fa/java/powerpoint-charts/) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها‑به‑انتها زیر یک الگو را باز می‌کند، اسلاید اول را برای یافتن یک جای‌دار عنوان یا تصویر جستجو می‌کند، نوع جای‌دار و شکل را بررسی می‌کند، محتوای مناسب را به‌روز می‌کند و خروجی را ذخیره می‌نماید. این مثال عمدتاً از فرض وجود شاخص شکل یا تبدیل هر جای‌دار به یک رابط واحد خودداری می‌کند:

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

## **سوالات متداول**

**جای‌دار پایه چیست؟**

یک جای‌دار پایه، شکل متناظر در چیدمان یا اصلی است که از آن یک جای‌دار دیگر ارث می‌برد. برای دریافت آن از [IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) استفاده کنید. یک شکل محلی عادی `null` برمی‌گرداند زیرا بخشی از سلسله‌مراتب جای‌دارها نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک جای‌دار چیدمان تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنمای ارث‌بری‌شده را از طریق چیدمان تغییر دهید، اما محتوی عنوان موجود در اسلایدهای عادی ذخیره می‌شود. برای جایگزینی متن واقعی عنوان در تمام ارائه، بر اسلایدها تکرار کنید و هر جای‌دار عنوان را به‌روز کنید.

**چگونه می‌توانم جای‌دارهای تاریخ، شمارهٔ اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیران سرصفحه و پاورقی در سطح اسلاید، چیدمان، اصلی، یادداشت یا توزیع‌نامه مناسب استفاده کنید. برای مثال‌های کامل به صفحه [Manage Presentation Header and Footer](/slides/fa/java/presentation-header-and-footer/) مراجعه کنید.