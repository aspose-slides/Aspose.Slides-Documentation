---
title: مدیریت فریم‌های تصویر در ارائه‌ها با استفاده از JavaScript
linktitle: فریم تصویر
type: docs
weight: 10
url: /fa/nodejs-java/picture-frame/
keywords:
- فریم تصویر
- افزودن فریم تصویر
- ایجاد فریم تصویر
- تصویر جاسازی‌شده
- تصویر پیوندی
- استخراج تصویر
- تصویر رستر
- تصویر SVG
- برش تصویر
- حذف نواحی برش‌شده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی فریم تصویر
- مقیاس نسبی
- اثر تصویر
- نسبت عرض/ارتفاع
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی فریم‌های تصویر در ارائه‌ها با Aspose.Slides برای Node.js از طریق Java."
---
## **نمای کلی**

یک فریم تصویر یک شکل اسلاید است که تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیای جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) خود مالکیت می‌کند، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، کُرپ، اثرات تصویر و سایر تنظیمات سطح فریم را کنترل می‌کند.

این جداسازی زمانی مفید است که یک تصویر بیش از یک بار نمایش داده شود. تصویر را یک‌بار به ارائه اضافه کنید، شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) برگشتی را نگه دارید و هنگام ایجاد فریم‌های تصویر از همان منبع تصویر استفاده کنید.

فریم‌های تصویر می‌توانند تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG را شامل شوند. همچنین می‌توانند به تصاویر پیوندی اشاره کنند به جای ذخیره بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، حجم فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی، تصمیم‌گیری درباره نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک فریم تصویر با [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ایجاد نمایید. تصویر بخشی از بسته ارائه می‌شود، بنابراین وقتی ارائه به رایانه دیگری منتقل شود، خودمختار باقی می‌ماند.

مثال زیر یک تصویر PNG اضافه می‌کند، فریمی با ابعاد بومی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌نماید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

فریم تصویر هندسه نمایش داده شده را کنترل می‌کند؛ تغییر اندازه فریم ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تمایز زمانی مهم می‌شود که بعداً تصویر را کُرپ یا فشرده کنید.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی فریم را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) افشا می‌کند. مقدار `1.0` متناظر با ۱۰۰٪ اندازه اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز به حفظ رابطه‌ای نسبت به اندازه تصویر منبع داشته باشد به جای محاسبه ابعاد نهایی به صورت دستی.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مقیاس نسبی تنظیمات مقیاس فریم را تغییر می‌دهد؛ اما تصویر جاسازی‌شده را بازنمونه‌برداری یا فشرده نمی‌کند.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین ایمن‌ترین گزینه برای قابلیت حمل و رندر پیش‌بینی‌شده است. یک تصویر پیوندی مسیر خارجی را از طریق روش [Picture.setLinkPathLong](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به جای جاسازی داده‌های تصویر به همان روش.

تصاویر پیوندی می‌توانند مقدار داده تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند در دسترس بماند. اگر مسیر تغییر کند، فایل جا به جا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل‌اعتمادتر هستند.

### **افزودن یک تصویر پیوندی**

مثال زیر یک فریم تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدئو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از پیوندها هنگامی که مدیریت فایل‌های خارجی عمدی است استفاده کنید. آنها را صرفاً به‌عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های شکسته تصویر معمولاً کمتر مفید است نسبت به یک ارائه بزرگ‌تر خودمختار.

## **استخراج تصاویر از فریم‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، اطمینان حاصل کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) است و شامل تصویر جاسازی‌شده می‌شود. فریم‌های تصویر پیوندی ممکن است بایت‌های تصویری نداشته باشند که به همان شکل استخراج شوند.

### **استخراج یک تصویر رستر**

API مدرن تصویر از [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) به‌صورت مستقیم استفاده می‌کند. مثال زیر اولین تصویر رستر جاسازی‌شده روی یک اسلاید را پیدا می‌کند و به‌عنوان PNG ذخیره می‌نماید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

ذخیره از طریق [IImage.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) تصویر استخراج‌شده را به فرمت خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده‌ای که در ارائه ذخیره شده‌اند به‌جای فایل رستر تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج یک تصویر SVG**

برای یک تصویر SVG، [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) را افشا می‌کند. این امکان را می‌دهد تا داده‌های SVG را به‌صورت مستقیم بازیابی کنید به‌جای رستر کردن تصویر ابتدا.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

حفظ محتوا به‌صورت SVG، منبع برداری را داخل ارائه نگه می‌دارد. خروجی‌های رستر مانند PNG یا JPEG مجبورند آن محتوا را به پیکسل‌ها تبدیل کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان کپی بایت‌به‌بایت از SVG جاسازی‌شده اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از داده‌های [SvgImage.getSvgData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/#getSvgData--) استفاده کنید.

## **کُرپ یک تصویر**

کُرپ بخش قابل‌مشاهده تصویر داخل فریم را تغییر می‌دهد. مقادیر کُرپ در [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) درصدی از ابعاد تصویر منبع هستند. کُرپ به‌طور اولیه پیکسل‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ فقط ناحیه قابل‌مشاهده را تغییر می‌دهد.

مثال زیر یک فریم تصویر را به‌صورت ایمن پیدا کرده و مقادیر کُرپ را اعمال می‌کند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

از آنجا که داده تصویر مخفی همچنان موجود است، می‌توان کُرپ را بعداً بدون از دست دادن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از بازگشت‌پذیری باشد، نواحی کُرپ شده می‌توانند همان‌طور که در بخش بعدی توضیح داده شد، به‌صورت فیزیکی حذف شوند.

## **حذف داده‌های تصویر کُرپ‌شده**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل کُرپ فعلی را حذف کرده و منبع تصویر حاصل را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات بازکُرپ در دسترس نیستند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

این روش ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط فریم‌های تصویر دیگر نیز استفاده شود، آن فریم‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی کُرپ‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. کُرپ محتواهای WMF یا EMF با این روش، نتیجه کُرپ شده را به PNG رستر می‌کند.

## **فشرده‌سازی تصاویر رستر**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی کُرپ‌شده را در همان عملیات حذف کند. این روش وقتی تصویر تغییر اندازه یا کُرپ شد `true` و در غیر این صورت `false` برمی‌گرداند.

از یک مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturescompression/) وقتی یک وضوح هدف استاندارد کافی است، استفاده کنید:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

به‌جای مقدار پیش‌تعریف‌شده می‌توان یک مقدار DPI مثبت سفارشی را هنگام نیاز به هدف خاص پاس داد.

فشرده‌سازی برای تصاویر رستر منظور شده است. محتوای SVG و متافایل توسط این جریان کاری فشرده‌سازی رستر کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح پایین‌تر و نواحی کُرپ‌شده حذف‌شده از ارائه بهینه‌شده قابل بازیابی نیستند. هدف وضوح را بر پایه بزرگ‌ترین اندازه‌ای که تصویر واقعاً مشاهده یا خروجی می‌شود، نه بر پایه کمترین DPI جهانی، انتخاب کنید.

## **بازرسی اثرات تصویر**

اثرهای تصویر بر روی تصویری که فریم از آن استفاده می‌کند ذخیره می‌شوند. مجموعه تبدیل تصویر می‌تواند شامل اثراتی مانند مدولاسیون آلفای ثابت برای شفافیت و لومینانس برای روشنایی و کنتراست باشد. مثال زیر به‌صورت ایمن هر دو نوع اثر را از اولین فریم تصویر روی یک اسلاید می‌خواند:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (let i = 0; i < imageTransform.size(); i++) {
            const effect = imageTransform.get_Item(i);
            if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
                const transparency = 100 - effect.getAmount();
                console.log("Transparency: " + transparency);
            }

            if (java.instanceOf(effect, "com.aspose.slides.ILuminance")) {
                const luminance = effect.getEffective();
                console.log("Brightness: " + luminance.getBrightness());
                console.log("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

این اثرها نحوه رندر تصویر در فریم را تغییر می‌دهند؛ آنها بایت‌های تصویر جاسازی‌شده اصلی را بازنویسی نمی‌کنند.

## **قفل کردن هندسه فریم تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/) کنترل می‌کنند که کدام عملیات ویرایشی برای فریم تصویر غیرفعال باشند. برای مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) نسبت عرض/ارتفاع شکل را هنگام تغییر اندازه حفظ می‌کند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

قفل بر روی شکل فریم تصویر اعمال می‌شود. این باعث نمی‌شود که تصویر منبع بازنمونه‌برداری یا به‌طور دائم به همان نسبت عرض/ارتفاع تغییر کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پر کردن تصویر به‌صورت stretch باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) مستطیل پر کردن را نسبت به جعبه مرزی فریم تصویر تعریف می‌کند. درصدهای مثبت یک تورفتگی از لبه ایجاد می‌کند، در حالی که درصدهای منفی یک بیرون‌زدگی ایجاد می‌کند.

این متفاوت از کُرپ است. مقادیر کُرپ تعیین می‌کنند کدام بخش از تصویر منبع قابل مشاهده است؛ offsetهای stretch مستطیلی را که پر کردن تصویر قابل مشاهده در آن کشیده می‌شود، تغییر می‌دهند.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

از offsetهای stretch برای قرار دادن پر کردن استفاده کنید. هنگام هدف‌گذاری مخفی‌سازی لبه‌های تصویر منبع، از ویژگی‌های کُرپ استفاده کنید.

## **ذخیره‌سازی، حجم فایل و ملاحظات خروجی**

معامله‌های اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی فریم‑تصویر جداگانه در نظر گرفته شوند:

- **تصاویر جاسازی‌شده** ارائه را خودمختار می‌سازند و برای به‌اشتراک‌گذاری و رندر سمت سرور قابل‌اعتمادترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و استفاده حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچک‌تر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **کُرپ** در ابتدا غیر مخرب است. پیکسل‌های مخفی تا زمانی که نواحی کُرپ‌شده به‌صورت صریح حذف یا در طول فشرده‌سازی پاک شوند، همچنان جاسازی می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بزرگ به‌طرزی چشمگیر کاهش دهد، اما وضوح منبع را قربانی می‌کند. باید پس از شناخت اندازه نهایی تصویر روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌صورت SVG باقی بمانند وقتی که حفظ وکتور مهم است. SVG جاسازی‌شده را مستقیماً استخراج کنید وقتی به خود منبع وکتور نیاز دارید. خروجی‌های اسلاید رستر همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از منبع موجود [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) استفاده کنند تا بارگذاری مکرر یک فایل یکسان در جریان کاری ارائه جلوگیری شود.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثرتر است که به‌صورت انتخابی انجام شود: لوگوها و دیاگرام‌ها را به‌عنوان محتواهای وکتور نگه دارید، عکس‌ها را بر اساس اندازه واقعی نمایش فشرده کنید، پیکسل‌های کُرپ‌شده را فقط زمانی حذف کنید که ویرایش بعدی لازم نیست و از پیوندهای خارجی مگر این‌که مدیریت وابستگی بخشی از طراحی استقرار باشد، خودداری کنید.

## **پرسش‌های متداول**

**تفاوت بین فریم تصویر و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) منبع تصویر مرتبط با ارائه را نمایندگی می‌کند. یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) شکلی روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح فریم نظیر اندازه، چرخش, مقادیر کُرپ, اثرات و قفل‌ها را ذخیره می‌کند.

**کدامیک را باید جاسازی یا پیوند دهم؟**

وقتی ارائه باید قابل‌حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، تصاویر را جاسازی کنید. فقط در زمانی که نگه داشتن فایل‌های تصویر خارج از PPTX عمدی است و می‌توانید مکان‌های خارجی را به‌صورت قابل‌اعتمادی مدیریت کنید، از پیوند استفاده کنید.

**آیا کُرپ باعث کاهش حجم فایل PPTX می‌شود؟**

خود کُرپ این کار را نمی‌کند. تنظیمات کُرپ معمولی بخشی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم باید از [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر همراه با حذف نواحی کُرپ‌شده استفاده کنید زمانی که می‌توان پیکسل‌ها را به‌صورت دائم حذف کرد.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازگرداند؟**

نه. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی کُرپ‌شده داده‌های تصویر را از بین می‌برد. اگر بعداً نیاز به ویرایش با وضوح بالا دارید، تصویر منبع اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG رفتار کرد؟**

وقتی که صحت وکتور مهم است، محتوا را به‌صورت SVG نگه دارید. می‌توانید [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) جاسازی‌شده را مستقیماً استخراج کنید. رندر اسلاید به فرمت رستر مانند PNG یا JPEG، SVG را به پیکسل‌ها تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای مخصوص فریم تصویر، نوع شکل را بررسی کنید. یک بررسی `java.instanceOf` در برابر [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) از تبدیل‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی را که فریم تصویر ندارند به‌صورت ایمن مدیریت کند.