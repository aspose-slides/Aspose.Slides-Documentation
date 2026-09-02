---
title: مدیریت جای‌نگهدارهای ارائه در جاوااسکریپت
linktitle: مدیریت جای‌نگهدارها
type: docs
weight: 10
url: /fa/nodejs-java/manage-placeholder/
keywords:
- جای‌نگهدار
- جای‌نگهدار متن
- جای‌نگهدار تصویر
- جای‌نگهدار نمودار
- جای‌نگهدار محتوا
- متن راهنما
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه جای‌نگهدارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت جای‌نگهدارها را با Aspose.Slides برای Node.js از طریق جاوا بفهمید."
---
## **بررسی کلی**

یک placeholder شکل است که موقعیتی را برای یک نوع خاص محتوا در قالب ارائه رزرو می‌کند. مثال‌های رایج شامل عنوان، متن اصلی، تصویر، نمودار و placeholderهای محتوای عمومی هستند. برخلاف یک شکل معمولی، یک placeholder می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید layout یا master به ارث ببرد.

Aspose.Slides اطلاعات placeholder را از طریق متد [Shape.getPlaceholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getPlaceholder) افشا می‌کند. این متد یک شیء [Placeholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholder/) یا `null` برای یک شکل عادی بر می‌گرداند. برای تعیین اینکه placeholder برای چه چیزی در نظر گرفته شده است، از [Placeholder.getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholder/#getType) استفاده کنید.

کلاس shape هنوز پس از دانستن نوع placeholder اهمیت دارد:

- یک placeholder خالی متنی، تصویری، نموداری یا محتوایی معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) نمایش داده می‌شود.
- یک placeholder تصویری پر شده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) نمایان شود.
- یک placeholder نموداری پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/) نمایان شود.
- یک placeholder محتوا می‌تواند چندین نوع محتوا را در خود داشته باشد. هم [Placeholder.getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholder/#getType) و هم کلاس shape در زمان اجرا را بررسی کنید به جای این‌که فرض کنید هر placeholder یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) است.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType] نقش یک placeholder را توصیف می‌کند؛ تضمین نمی‌کند که نوع زمان اجرا shape چه باشد. همیشه قبل از دسترسی به اعضای مربوط به متن، تصویر، نمودار، جدول یا رسانه، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک وراثت placeholder‌ها**

placeholder‌ها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید master سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد placeholderهای سطح master را نیز شامل می‌شود.
2. یک اسلاید layout چیدمانی را تعریف می‌کند که توسط یک یا چند اسلاید عادی استفاده می‌شود و می‌تواند از master ارث‌بری کند.
3. یک اسلاید عادی placeholderهای آن اسلاید را داراست و می‌تواند از layout آن ارث‌بری کند.

برای رفتن یک سطح بالاتر در این سلسله‌مراتب، متد [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getBasePlaceholder) را صدا بزنید. یک placeholder اسلاید معمولاً placeholder layout خود را بر می‌گرداند؛ یک placeholder layout می‌تواند placeholder master خود را برگرداند. این متد هنگام عدم وجود base placeholder مقدار `null` بر می‌گرداند.

مثال زیر placeholderهای اسلاید اول را فهرست کرده و base placeholderهای آنها را گزارش می‌دهد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

ویرایش یک placeholder در اسلاید عادی یک بازنویسی محلی برای آن اسلاید ایجاد یا تغییر می‌دهد. ویرایش layout یا master مرتبط می‌تواند بر همه اسلایدهایی که هنوز آن تنظیم را ارث می‌برند، اثر بگذارد. یک shape محلی عادی base placeholder ندارد و صرف‌نظر از این‌که در همان مختصات قرار داشته باشد، وراثت را شروع نمی‌کند.

## **تغییر متن در یک placeholder**

placeholderهای title، centered-title، subtitle، body و متن معمولاً از متن پشتیبانی می‌کنند. پیش از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/#getTextFrame) اطمینان حاصل کنید که shape مورد نظر یک [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) است.

این مثال اولین placeholder عنوان در اسلاید اول را به‌روزرسانی کرده و نتیجه را ذخیره می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این الگو از برخورد placeholderهای تصویر، نمودار، جدول یا رسانه به‌عنوان اشیاء [AutoShape] جلوگیری می‌کند. همچنین placeholder را بر اساس هدفش شناسایی می‌کند به جای تکیه بر یک ایندکس shape شکننده.

## **تنظیم متن راهنما در یک layout**

متن راهنما (prompt text) دستورالعمل زمان طراحی است که در یک placeholder خالی نمایش داده می‌شود، مانند *Click to add title*. متن راهنمای سفارشی را روی placeholder layout تنظیم کنید نه این‌که سعی کنید از طریق مجموعه shapes اسلاید عادی به آن دسترسی پیدا کنید. با استفاده از [Slide.getLayoutSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/#getLayoutSlide) به layout دسترسی پیدا کنید و روی مجموعه‌ای که توسط [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/#getShapes) برگردانده می‌شود، تکرار کنید.

مثال زیر متن راهنمای عنوان و زیرعنوان را در layout استفاده‌شده توسط اسلاید اول تغییر می‌دهد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متن راهنما محتوی عادی اسلاید نیست. این متن برای placeholderهای خالی در برنامه‌های ویرایشی مانند PowerPoint در نظر گرفته شده است. به محض این‌که کاربر یا برنامه محتوی واقعی را اضافه کرد، این راهنما دیگر نشان داده نمی‌شود. تغییر یک راهنما همچنین متن موجود بر روی اسلایدهایی که از همان layout استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی یک placeholder تصویر**

دو مورد برای مدیریت وجود دارد:

- اگر placeholder تصویر هم‌اکنون پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) نمایش داده شود، تصویر را از طریق [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)، [PictureFillFormat.getPicture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#getPicture) و [Picture.setImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/#setImage) جایگزین کنید.
- اگر هنوز یک placeholder خالی باشد، یک picture frame در مختصات placeholder با متد [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) اضافه کنید و placeholder خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه (presentation) را ذخیره می‌نماید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

جایگزینی که برای یک placeholder خالی ایجاد می‌شود یک picture frame محلی است، نه یک placeholder جدید، زیرا [Shape.getPlaceholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getPlaceholder) setterی ارائه نمی‌دهد. این کار موقعیت رزرو شده را حفظ می‌کند اما دیگر رفتار خاص placeholder را به ارث نمی‌برد. اگر حفظ رابطه placeholder حیاتی است، ابتدا placeholder را در PowerPoint آماده و پر کنید، سپس [PictureFrame] حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، بریدن و دیگر اثرات خاص تصویر، به [Manage Picture Frames](/slides/fa/nodejs-java/picture-frame/) مراجعه کنید. این عملیات‌ها به picture frame یا picture fill تعلق دارند، نه به متادیتای placeholder.

## **کار با placeholder‌های نمودار و محتوا**

یک placeholder نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/chart/) نمایش داده شود. این مثال چنین نموداری را هم بر اساس نوع placeholder و هم بر اساس کلاس زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

یک placeholder محتوای عمومی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholdertype/#Object) است. در PowerPoint این placeholder به عنوان یک launcher برای انواع مختلف محتوا از جمله نمودارها، جداول، نمودارهای دیاگرام، تصاویر و رسانه عمل می‌کند. پس از پر شدن، کلاس واقعی shape را بررسی کنید تا بفهمید چه چیزی درون آن قرار دارد. layoutهای تخصصی می‌توانند همچنین [PlaceholderType.Chart](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholdertype/#Media) یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholdertype/#Diagram) را نشان دهند.

Aspose.Slides یک placeholder خالی [AutoShape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) را تنها با تغییر [Placeholder.getType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/placeholder/#getType) به [Chart] تبدیل نمی‌کند؛ نوع آن را نمی‌توان از طریق شیء تغییر داد. برای پر کردن یک نمودار یا ناحیه محتوای خالی به‌صورت برنامه‌ای، شیء مورد نیاز را در مختصات placeholder اضافه کنید و سپس placeholder خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمودار اضافه‌شده یک نمودار محلی عادی است. این نمودار ناحیه placeholder را اشغال می‌کند اما از layout placeholder ارث‌بری نمی‌کند. هنگامی که نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های workbook دارید، از مقالات اختصاصی مدیریت نمودارها ([chart management articles](/slides/fa/nodejs-java/powerpoint-charts/)) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال انتها به انتهای زیر یک قالب را باز می‌کند، اسلاید اول را برای یافتن یک placeholder عنوان یا تصویر جستجو می‌کند، نوع placeholder و shape را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌نماید و خروجی را ذخیره می‌کند. این مثال عمداً از فرض کردن ایندکس shape یا رفتار همه placeholderها به عنوان یک کلاس یکسان خودداری می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**جایگزین پایه چیست؟**

یک base placeholder شکل متناظر روی layout یا master است که از آن یک placeholder دیگر وراثت می‌برد. برای دریافت آن از [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shape/#getBasePlaceholder) استفاده کنید. یک shape محلی عادی `null` برمی‌گرداند چون بخشی از سلسله‌مراتب placeholder نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک placeholder layout تغییر دهم؟**

می‌توانید قالب‌بندی ارث‌بری یا متن راهنما را از طریق layout تغییر دهید، اما محتوی واقعی عنوان‌ها بر روی اسلایدهای عادی ذخیره شده است. برای جایگزینی متن عنوان در تمام ارائه، باید روی اسلایدها پیمایش کنید و هر placeholder عنوان را به‌روزرسانی کنید.

**چگونه placeholderهای تاریخ، شماره اسلاید، سرصفحه و پاورقی را مدیریت کنم؟**

از مدیران سرصفحه و پاورقی در سطح اسلاید، layout، master، notes یا handout استفاده کنید. برای مثال‌های کامل به [Manage Presentation Header and Footer](/slides/fa/nodejs-java/presentation-header-and-footer/) مراجعه کنید.