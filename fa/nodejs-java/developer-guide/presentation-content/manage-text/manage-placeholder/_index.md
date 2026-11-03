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
- جاوااسکریپت
- Aspose.Slides
description: "یاد بگیرید چگونه جای‌نگهدارهای متن، تصویر، نمودار و محتوا را بررسی و ویرایش کنید و وراثت جای‌نگهدارها را با Aspose.Slides برای Node.js از طریق جاوا درک کنید."
---
## **بررسی کلی**

یک placeholder شکلی است که موقعیتی را برای یک نوع خاص از محتوا در قالب ارائه رزرو می‌کند. مثال‌های رایج شامل عنوان، متن اصلی، تصویر، نمودار و placeholderهای محتوای عمومی هستند. بر خلاف یک شکل عادی، placeholder می‌تواند موقعیت، اندازه، قالب‌بندی و سایر تنظیمات خود را از یک اسلاید طرح‌بندی یا اسلاید اصلی به ارث ببرد.

Aspose.Slides اطلاعات placeholder را از طریق متد [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) فراهم می‌کند. این متد یک شیء [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) یا `null` برای یک شکل عادی برمی‌گرداند. برای تعیین محتوای مورد انتظار placeholder از [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) استفاده کنید.

کلاس شکل همچنان پس از دانستن نوع placeholder مهم است:

- یک placeholder متنی، تصویری، نموداری یا محتوایی خالی معمولاً توسط یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) نشان داده می‌شود.
- یک placeholder تصویر پر شده می‌تواند توسط یک [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) نشان داده شود.
- یک placeholder نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) نشان داده شود.
- یک placeholder محتوا می‌تواند چندین نوع محتوا را در بر بگیرد. به جای این‌که فرض کنید هر placeholder یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) است، هم [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) و هم کلاس شکل زمان اجرا را بررسی کنید.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) نقش placeholder را توصیف می‌کند؛ اما نوع زمان اجرا شکل را تضمین نمی‌کند. همیشه قبل از دسترسی به متن، تصویر، نمودار، جدول یا اعضای خاص رسانه‌ای، یک بررسی نوع انجام دهید.
{{% /alert %}}

## **درک وراثت Placeholder**

Placeholderها یک سلسله‌مراتب تشکیل می‌دهند:

1. یک اسلاید اصلی (master) سبک‌های قابل استفاده مجدد را تعریف می‌کند و در برخی موارد placeholderهای سطح master را داراست.
2. یک اسلاید طرح‌بندی (layout) چیدمان استفاده‌شده توسط یک یا چند اسلاید عادی را تعریف می‌کند و می‌تواند از master ارث‌بری کند.
3. یک اسلاید عادی placeholderهای مربوط به آن اسلاید را شامل می‌شود و می‌تواند از layout خود ارث‌بری کند.

برای رفتن یک سطح بالاتر در این سلسله‌مراتب، متد [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) را فراخوانی کنید. یک placeholder اسلاید معمولاً placeholder طرح‌بندی خود را برمی‌گرداند؛ یک placeholder طرح‌بندی می‌تواند placeholder اصلی را برگرداند. این متد وقتی که شکل پایه placeholder نداشته باشد `null` برمی‌گرداند.

مثال زیر placeholderهای موجود در اولین اسلاید را فهرست می‌کند و placeholderهای پایه آنها را گزارش می‌دهد:

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

ویرایش یک placeholder در اسلاید عادی یک تغییر محلی (override) برای همان اسلاید ایجاد یا تغییر می‌دهد. ویرایش layout یا master مرتبط می‌تواند تمام اسلایدهایی را که هنوز از آن تنظیم ارث می‌برند تحت تأثیر قرار دهد. یک شکل عادی محلی پایه placeholder ندارد و صرفاً به دلیل قرارگیری در همان مختصات‌ها شروع به ارث‌برداری نمی‌کند.

## **حذف وضعیت Placeholder**

هنگام تطبیق یک قالب، از متد [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) استفاده کنید تا شیء موجود به‌عنوان یک شکل عادی باقی بماند. متد [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) آن `null` برمی‌گرداند، اما شکل در مجموعه اسلاید باقی می‌ماند. در مقابل، متد [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) شکل را از آن مجموعه حذف می‌کند.

مثال زیر به فایلی به نام `template.pptx` نیاز دارد که حداقل یک اسلاید و یک placeholder متنی غیرخالی در اولین اسلاید داشته باشد. برای دیدن اثر حذف رابطه، از یک placeholder با قالب‌بندی ارث‌برداری‌شده از layout یا master استفاده کنید. مثال بررسی می‌کند که همان شکل باقی می‌ماند، دوباره متد را بر روی شکل حالا عادی فراخوانی می‌کند و نتیجه را ذخیره می‌نماید.

{{% alert color="warning" title="Warning" %}}
حذف وضعیت placeholder به‌صورت خودکار تنظیمات ظاهر ارث‌بری را حفظ نمی‌کند. مثال زیر به عمد این تنظیمات را دست‌نخورده می‌گذارد، بنابراین خروجی ممکن است متفاوت به‌نظر برسد. یک شکل که موقعیت و اندازه‌اش به‌طور کامل ارث‌بری شده باشد می‌تواند پس از فراخوانی مختصات و ابعاد صفر داشته باشد و به‌نظر نامرئی برسد، حتی اگر در مجموعه باقی بماند.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // صدا زدن متد روی یک شکل عادی تأثیری ندارد.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

برای یک placeholder منطبق، هر سه بررسی `true` چاپ می‌شود. متن باقی می‌ماند، اما موقعیت، اندازه، چرخش، فونت، تراز پاراگراف، حاشیه‌های فریم متن، لنگر عمودی، پرکردن و تنظیمات خط می‌توانند هنگام حذف رابطه placeholder تغییر کنند. برای مثال، قالب‌بندی عنوان ارث‌بری می‌تواند به قالب‌بندی متن عادی بازگردد. برای اطلاعات بیشتر درباره layoutها، به [طرح اسلاید](/slides/fa/nodejs-java/slide-layout/) مراجعه کنید.

برای حفظ ظاهر مورد نظر، قبل از فراخوانی موقعیت، اندازه و چرخش حل‌شده را ذخیره کنید و مقادیر قالب‌بندی مؤثر مورد نیاز را در متغیرهای جداگانه کپی کنید. این مقادیر را از طریق [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective)، [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective)، [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective)، [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) و [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective) بازیابی کنید. فقط به اشیای مؤثر‑format وابسته نمانید، زیرا مقادیر قالب‌بندی متن آن‌ها می‌تواند پس از حذف رابطه تغییر کند. مقادیر ذخیره‌شده را به‌صورت صریح بر روی شکل عادی پس از آن اعمال کنید، از جمله خانواده فونت، اندازه، سبک، رنگ، تنظیمات پاراگراف، تنظیمات فریم متن، پرکردن و خط مورد استفاده در قالب شما.

شکل هندسی ارث‌برداری‌شده ممکن است نیاز به اختصاص صریح از طریق [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType) داشته باشد. برای یک placeholder متنی مستطیلی، این به معنای اختصاص [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle) است؛ بازگرداندن فقط پرکردن و خط ممکن است مستطیل قابل مشاهده را بازنشانی نکند. قالب‌هایی که اثرات اضافی یا قالب‌بندی پیچیده‌تری دارند، باید همان تنظیمات نیز به‌درستی پردازش شوند.

## **تغییر متن در Placeholder**

Placeholderهای عنوان، عنوان‑مركزی، زیرعنوان، بدنه و متن معمولاً از متن پشتیبانی می‌کنند. قبل از استفاده از متد [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) برای یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) بررسی کنید.

این مثال اولین placeholder عنوان در اولین اسلاید را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌نماید:

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

این الگو از شناسایی placeholderهای تصویر، نمودار، جدول یا رسانه‌ای به‌عنوان اشیای [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) جلوگیری می‌کند. همچنین placeholder را بر اساس هدف آن شناسایی می‌کند نه بر پایه یک شاخص شکننده شکل.

## **تنظیم متن راهنما در Layout**

متن راهنما راهنمایی است که در یک placeholder خالی هنگام طراحی نمایش داده می‌شود، مانند *برای افزودن عنوان کلیک کنید*. برای تنظیم متن راهنما، روی placeholder layout تنظیم کنید نه از طریق مجموعه شکل‌های اسلاید عادی. به layout از طریق متد [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) دسترسی پیدا کنید و بر روی مجموعه‌ای که توسط [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) بازگردانده می‌شود، تکرار کنید.

مثال زیر متن‌های راهنمای عنوان و زیرعنوان را در layout استفاده‌شده توسط اولین اسلاید تغییر می‌دهد:

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

متن راهنما محتوای عادی اسلاید نیست. این متن برای placeholderهای خالی در برنامه‌های ویرایش مانند PowerPoint در نظر گرفته شده است. وقتی کاربر یا برنامه محتوا واقعی را فراهم کند، متن راهنما دیگر نمایش داده نمی‌شود. تغییر یک راهنما نیز متن موجود بر روی اسلایدهایی که از این layout استفاده می‌کنند را جایگزین نمی‌کند.

## **به‌روزرسانی Placeholder تصویر**

دو حالت برای مدیریت وجود دارد:

- اگر placeholder تصویر قبلاً پر شده باشد و توسط یک [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) نمایان شود، تصویر را از طریق [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat)، [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) و [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage) جایگزین کنید.
- اگر هنوز یک placeholder خالی باشد، یک فریم تصویر را در مختصات placeholder با استفاده از [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) اضافه کنید و placeholder خالی را حذف کنید.

مثال بعدی هر دو حالت را پشتیبانی می‌کند و ارائه را ذخیره می‌نماید:

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

جایگزینی ایجاد شده برای یک placeholder خالی یک فریم تصویر محلی است، نه یک placeholder جدید، زیرا [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) تنظیم‌کننده‌ای ارائه نمی‌دهد. این فریم موقعیت رزرو شده را نگه می‌دارد اما دیگر رفتار خاص placeholder را به ارث نمی‌برد. اگر حفظ رابطه placeholder ضروری است، ابتدا placeholder را در PowerPoint آماده و پر کنید، سپس [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) حاصل را با Aspose.Slides به‌روزرسانی کنید.

برای شفافیت تصویر، برش و سایر اثرات خاص تصویر، به مقاله [Manage Picture Frames](/slides/fa/nodejs-java/picture-frame/) مراجعه کنید. این عملیات‌ها به فریم تصویر یا پرکننده تصویر تعلق دارند، نه به متادیتای placeholder.

## **کار با Placeholderهای نمودار و محتوا**

یک placeholder نمودار پر شده می‌تواند توسط یک [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) نشان داده شود. این مثال چنین نموداری را بر اساس نوع placeholder و کلاس زمان اجرا پیدا می‌کند، عنوان آن را تغییر می‌دهد و فایل را ذخیره می‌کند:

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

یک placeholder محتوای کلی معمولاً دارای [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object) است. در PowerPoint این placeholder به عنوان یک راه‌انداز برای چندین نوع محتوا عمل می‌کند، از جمله نمودارها، جداول، نمودارهای ارتباطی، تصاویر و رسانه‌ها. پس از پر شدن، کلاس شکل واقعی را بررسی کنید تا متوجه شوید چه چیزی درون آن است. layoutهای تخصصی می‌توانند همچنین [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart)، [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table)، [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture)، [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) یا [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram) را نمایش دهند.

Aspose.Slides یک [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) placeholder خالی را تنها با تغییر [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) به یک [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) تبدیل نمی‌کند؛ نوع از طریق شیء قابل تغییر نیست. برای پر کردن برنامه‌نویسی یک ناحیه خالی نمودار یا محتوا، شیء مورد نیاز را در مختصات placeholder اضافه کنید و سپس placeholder خالی را حذف کنید. مثال زیر این کار را برای یک نمودار انجام می‌دهد:

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

نمودار اضافه شده یک نمودار محلی عادی است. این نمودار فضای placeholder را اشغال می‌کند اما از layout placeholder ارث نمی‌برد. هنگام نیاز به جایگزینی دسته‌ها، سری‌ها یا داده‌های Workbook، از مقالات مخصوص مدیریت نمودارها ([chart management articles](/slides/fa/nodejs-java/powerpoint-charts/)) استفاده کنید.

## **مثال کامل: به‌روزرسانی متن یا محتوای تصویر**

مثال سرتاسری زیر یک قالب را باز می‌کند، اسلاید اول را برای پیدا کردن یک placeholder عنوان یا تصویر جستجو می‌کند، نوع placeholder و شکل را بررسی می‌کند، محتوای مناسب را به‌روزرسانی می‌کند و خروجی را ذخیره می‌کند. این مثال عمداً از فرض وجود شاخص شکل یا رفتار یکسان تمام placeholderها دوری می‌کند.

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

## **سؤالات متداول**

**Placeholder پایه چیست؟**

Placeholder پایه، شکل متناظر بر روی layout یا master است که از آن placeholder دیگر ارث می‌برد. برای بازیابی آن از [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) استفاده کنید. یک شکل محلی عادی `null` برمی‌گرداند زیرا بخشی از سلسله‌مراتب placeholder نیست.

**آیا می‌توانم تمام عناوین اسلایدها را با ویرایش یک placeholder Layout تغییر دهم؟**

می‌توانید قالب‌بندی یا متن راهنما را از طریق layout تغییر دهید، اما محتوای واقعی عنوان در اسلایدهای عادی ذخیره می‌شود. برای جایگزینی متن عناوین در یک ارائه، بر روی اسلایدها تکرار کنید و هر placeholder عنوان را به‌روزرسانی کنید.

**چگونه Placeholderهای تاریخ، شماره اسلاید، سرصفحه و پاصفحه را مدیریت کنم؟**

از مدیرهای سرصفحه و پاصفحه در سطح اسلاید مناسب، layout، master، notes یا handout استفاده کنید. برای مثال‌های کامل به [مدیریت سرصفحه و پاصفحه ارائه](/slides/fa/nodejs-java/presentation-header-and-footer/) مراجعه کنید.