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
- تصویر توکار
- تصویر پیوست شده
- استخراج تصویر
- تصویر رستر
- تصویر SVG
- برش تصویر
- حذف نواحی برش خورده
- فشرده‌سازی تصویر
- StretchOffset
- قالب‌بندی فریم تصویر
- مقیاس نسبی
- افکت تصویر
- نسبت ابعاد
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ایجاد، قالب‌بندی، لینک‌کردن، برش، استخراج و فشرده‌سازی فریم‌های تصویر در ارائه‌ها با Aspose.Slides برای Node.js با استفاده از Java."
---
## **نمای کلی**

یک فریم تصویر یک شکل اسلاید است که یک تصویر را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نشان می‌دهد، اشیای جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) منابع تصویر توکار را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) خود مالک می‌شود، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) موقعیت، اندازه، قالب‌بندی خط، چرخش، برش، افکت‌های تصویری و سایر تنظیمات سطح فریم را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) بازگشتی را نگه دارید و هنگام ایجاد فریم‌های تصویر از آن منبع تصویر استفاده کنید.

فریم‌های تصویر می‌توانند تصاویر رستر مانند PNG یا JPEG و همچنین تصاویر برداری SVG را شامل شوند. آن‌ها همچنین می‌توانند به تصاویر پیوست شده به‌جای ذخیره بایت‌های تصویر در ارائه ارجاع دهند. انتخاب این گزینه بر قابلیت حمل، اندازه فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی، تعیین نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی تصویر توکار**

برای یک تصویر توکار، داده‌های تصویر را به ارائه اضافه کنید و یک فریم تصویر با [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ایجاد کنید. تصویر جزئی از بسته ارائه می‌شود، بنابراین هنگام انتقال ارائه به رایانه دیگر، خود ارائه همچنان خودکفا می‌ماند.

مثال زیر یک تصویر PNG اضافه می‌کند، فریمی با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خط و چرخش را اعمال می‌کند:

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

فریم تصویر هندسه نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازه فریم ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر توکار را تغییر نمی‌دهد. این تمایز زمانی مهم می‌شود که بعداً بخواهید تصویر را برش یا فشرده کنید.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی فریم را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) ارائه می‌دهد. مقدار `1.0` معادل 100٪ اندازه اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک گردش کار نیاز به حفظ نسبت به اندازه تصویر منبع داشته باشد به‌جای محاسبه دستی ابعاد نهایی.

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

مقیاس نسبی تنظیمات مقیاس فریم را تغییر می‌دهد؛ اما تصویر توکار را بازنمونه‌گیری یا فشرده نمی‌کند.

## **تصاویر توکار و پیوست شده**

یک تصویر توکار داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت حمل و رندر پیش‌بینی‌شدنی ایمن‌ترین گزینه است. یک تصویر پیوست شده مکان خارجی را از طریق متد [Picture.setLinkPathLong](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به‌جای این‌که داده‌های تصویر را به همان شکل توکار کند.

تصاویر پیوست شده می‌توانند مقدار داده‌های تصویر ذخیره‌شده در PPTX را کاهش دهند، اما یک وابستگی خارجی ایجاد می‌کنند. فایل پیوست شده باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند، در دسترس بماند. اگر مسیر تغییر کند، فایل جابه‌جا شود یا منبع در دسترس نباشد، تصویر پیوست شده ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید ایمیل شوند، بایگانی شوند یا در محیط‌های ایزوله رندر شوند، تصاویر توکار معمولاً قابل اعتمادتر هستند.

### **افزودن تصویر پیوست شده**

مثال زیر یک فریم تصویر ایجاد می‌کند و آن را به فایل تصویری محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدیو یک گردش کار رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

از پیوندها زمانی استفاده کنید که مدیریت فایل‌های خارجی هدفمند باشد. از آن‌ها صرفاً به عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های تصویر شکسته معمولاً کمتر مفید است نسبت به یک ارائه خودکفا بزرگ‌تر.

## **استخراج تصاویر از فریم‌های تصویر**

پیش از استخراج تصویر از یک ارائه موجود، اطمینان حاصل کنید که یک شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) باشد و شامل یک تصویر توکار باشد. فریم‌های تصویر پیوست شده ممکن است بایت‌های تصویری نداشته باشند که بتوان آن‌ها را به همان شکل استخراج کرد.

### **استخراج تصویر رستر**

API تصویر مدرن از [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) به‌صورت مستقیم استفاده می‌کند. مثال زیر اولین تصویر رستر توکار موجود در یک اسلاید را یافته و به‌صورت PNG ذخیره می‌کند:

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

ذخیره‌سازی از طریق [IImage.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) تصویر استخراج‌شده را به فرمت خروجی موردنظر تبدیل می‌کند. اگر به بایت‌های کدگذاری‌شده ذخیره‌شده در ارائه به‌جای فایل رستری تبدیل‌شده نیاز دارید، به‌جای آن از داده‌های باینری منبع تصویر استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) را افشا می‌کند. این امکان را می‌دهد که داده‌های SVG را به‌صورت مستقیم دریافت کنید به‌جای رستر کردن تصویر ابتدا.

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

نگه داشتن محتوای SVG به‌عنوان SVG، منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG ناگزیر این محتوای برداری را به پیکسل تبدیل می‌کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان کپی بایت‌به‌بایت از SVG توکار اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از داده‌های [SvgImage.getSvgData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/#getSvgData--) استفاده کنید.

## **برش تصویر**

برش تعیین می‌کند کدام بخش از تصویر داخل فریم قابل مشاهده باشد. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش اولیه بایت‌های مخفی تصویر توکار را حذف نمی‌کند؛ فقط ناحیه قابل مشاهده را تغییر می‌دهد.

مثال زیر یک فریم تصویر را به‌صورت ایمن پیدا می‌کند و مقادیر برش را اعمال می‌کند:

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

از آنجا که داده‌های تصویر مخفی هنوز وجود دارند، می‌توان برش را بعدها تغییر داد بدون از دست دادن پیکسل‌های اصلی. اگر اندازه فایل بیشتر از قابلیت بازگشت مهم باشد، نواحی برش خورده می‌توانند همان‌طور که در بخش بعدی توضیح داده شد، حذف شوند.

## **حذف داده‌های تصویر برش خورده**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل برش فعلی را حذف کرده و منبع تصویر حاصل را برمی‌گرداند. این کار می‌تواند اندازه فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات برش معکوس در دسترس نیستند.

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

این متد ممکن است منبع تصویر جدیدی به ارائه اضافه کند. اگر تصویر اصلی توسط فریم‌های تصویر دیگر هم استفاده شود، آن فریم‌ها همچنان به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این متد نتیجه برش خورده را به PNG رستری می‌کند.

## **فشرده‌سازی تصاویر رستر**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش خورده را در همان عملیات حذف کند. این متد زمانی `true` برمی‌گرداند که تصویر تغییر اندازه یا برش یافته باشد و زمانی `false` که تغییر لازم نبوده است.

از یک مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturescompression/) هنگامی که وضوح هدف استاندارد کافی است، استفاده کنید:

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

به‌جای مقدار پیش‌تعریف‌شده می‌توان یک مقدار DPI مثبت سفارشی را در صورت نیاز به هدف خاص ارسال کرد.

فشرده‌سازی برای تصاویر رستر در نظر گرفته شده است. محتویات SVG و متافایل توسط این فرآیند فشرده‌سازی رستری کاهش نمی‌یابد. همچنین به‌خاطر داشته باشید که وضوح پایین‌تر و نواحی برش حذف‌شده از ارائه بهینه‌شده قابل بازیابی نیستند. یک وضوح هدف را بر پایه بزرگ‌ترین اندازه‌ای که تصویر در آن واقعاً مشاهده یا خروجی می‌شود انتخاب کنید، نه این‌که کم‌ترین DPI را به‌صورت سراسری اعمال کنید.

## **مدیریت افکت‌های تغییر شکل تصویر**

برای یک گردش کار کامل شامل روشنایی، کنتراست، تبدیل رنگ، تاری، افکت‌های آلفا، زنجیره‌های مرتب شده، بازرسی، حذف و تأیید دورانی، به [Image Transform Effects](/nodejs-java/image-transform-effects/) مراجعه کنید.

## **قفل کردن هندسه فریم تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/) تعیین می‌کند کدام عملیات ویرایشی برای فریم تصویر غیرفعال باشد. به‌عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) نسبت ابعاد شکل را در حین تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل فریم تصویر اعمال می‌شود. این قفل تصویر منبع را مجبور به بازنمونه‌گیری یا تغییر دائم به همان نسبت ابعاد نمی‌کند.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پر کردن تصویر به‌صورت کشش باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) مستطیل پر کردن را نسبت به جعبه محدوده فریم تصویر تعریف می‌کنند. درصدهای مثبت یک تورفتگی داخلی از لبه ایجاد می‌کند، در حالی که درصدهای منفی یک برآمدگی خارجی ایجاد می‌کند.

این متفاوت از برش است. مقادیر برش تعیین می‌کند کدام بخش از تصویر منبع قابل مشاهده است؛ در حالی که stretch‑offset مستطیلی را تغییر می‌دهد که پر کردن تصویر قابل مشاهده در آن کشیده می‌شود.

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

از stretch‑offset برای قرار دادن پر کردن استفاده کنید. وقتی هدف پنهان کردن لبه‌های تصویر منبع است، از خصوصیات برش استفاده کنید.

## **نگهداری، اندازه فایل و ملاحظات خروجی**

معامله‌های اصلی زمانی ساده‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی فریم تصویر جداگانه در نظر گرفته شوند:

- **تصاویر توکار** ارائه را خودکفا می‌کنند و برای اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستر بزرگ اندازه PPTX و استفاده از حافظه را افزایش می‌دهند.
- **تصاویر پیوست شده** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته است.
- **برش** در ابتدا غیر مخرب است. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده به‌صورت صریح حذف یا در طول فشرده‌سازی حذف نشوند، توکار می‌مانند.
- **فشرده‌سازی** می‌تواند برای تصاویر رستر بزرگ‌حجم به‌طور قابل‌توجهی اندازه فایل را کاهش دهد، اما وضوح منبع را قربانی می‌کند. این کار باید پس از تعیین اندازه نهایی روی اسلاید انجام شود.
- **تصاویر SVG** باید به صورت SVG باقی بمانند وقتی حفظ وکتور مهم است. هنگام نیاز به خود منبع وکتور، SVG توکار را به‌صورت مستقیم استخراج کنید. خروجی‌های اسلاید رستری همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان به جای بارگذاری مکرر همان فایل، از یک منبع [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) موجود استفاده کنند.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً هنگامی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و نمودارها را به‌عنوان محتوا وکتور نگه دارید، عکس‌ها را بر اساس اندازه نمایش واقعی فشرده کنید، پیکسل‌های برش خورده را فقط زمانی حذف کنید که ویرایش‌های بعدی لازم نیست و از پیوندهای خارجی تا زمانی که مدیریت وابستگی بخشی از طرح استقرار باشد، پرهیز کنید.

## **سوالات متداول**

**تفاوت فریم تصویر و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) منبع تصویری است که با ارائه مرتبط است. یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح فریم مانند اندازه، چرخش, مقادیر برش, افکت‌ها و قفل‌ها را ذخیره می‌کند.

**آیا باید تصاویر را توکار یا پیوست کنم؟**

وقتی ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، تصاویر را توکار کنید. فقط وقتی نگهداری فایل‌های تصویر خارج از PPTX هدفمند باشد و مسیرهای خارجی به‌صورت قابل‌اعتماد نگهداری شوند، تصاویر را پیوست کنید.

**آیا برش اندازه فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را انجام نمی‌دهد. تنظیمات برش معمولی بخش‌هایی از تصویر منبع را مخفی می‌کند اما پیکسل‌های زیرین را حفظ می‌کند. برای حذف دائم پیکسل‌ها از [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر با حذف نواحی برش‌شده استفاده کنید.

**آیا پس از فشرده‌سازی می‌توان کیفیت تصویر را بازگرداند؟**

خیر. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده داده‌های تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا در آینده ممکن باشد، تصویر اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG برخورد کرد؟**

وقتی وفاداری وکتور مهم است، محتوای SVG را به‌عنوان SVG نگه دارید. می‌توانید [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) توکار را به‌صورت مستقیم استخراج کنید. رندر اسلاید به فرمت رستری مانند PNG یا JPEG، SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناایمن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای خاص فریم تصویر، نوع شکل را بررسی کنید. یک بررسی `java.instanceOf` نسبت به [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) از تبدیل نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی را که فریم تصویر ندارند به‌درستی مدیریت کند.