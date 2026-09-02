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
- افکت تصویر
- نسبت عرض به طول
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "فریم‌های تصویر را در ارائه‌ها ایجاد، قالب‌بندی، پیوند، برش، استخراج و فشرده‌سازی کنید با Aspose.Slides برای Node.js از طریق Java."
---
## **مروری کلی**

یک فریم تصویر یک شکل اسلاید است که تصویری را نمایش می‌دهد. در Aspose.Slides، منبع تصویر و شکلی که آن را نمایش می‌دهد اشیاء جداگانه‌ای هستند: یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) منابع تصویر جاسازی‌شده را از طریق [ImageCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagecollection/) مالک می‌شود، در حالی که یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) موقعیت، اندازه، قالب‌بندی خطوط، چرخش، برش، افکت‌های تصویر و سایر تنظیمات سطح فریم را کنترل می‌کند.

این جداسازی زمانی مفید است که همان تصویر بیش از یک بار نمایش داده شود. تصویر را یک بار به ارائه اضافه کنید، شیء [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) بازگردانده‌شده را نگه دارید، و هنگام ایجاد فریم‌های تصویر از آن منبع تصویر استفاده کنید.

فریم‌های تصویر می‌توانند شامل تصاویر رستر مانند PNG یا JPEG و تصاویر برداری SVG باشند. همچنین می‌توانند به تصاویر پیوندی ارجاع دهند به جای ذخیره بایت‌های تصویر در ارائه. این انتخاب بر قابلیت حمل، اندازه فایل، استخراج و رفتار خروجی تأثیر می‌گذارد، بنابراین پیش از اعمال قالب‌بندی یا بهینه‌سازی، تعیین نحوه ذخیره‌سازی تصویر مفید است.

## **افزودن و قالب‌بندی یک تصویر جاسازی‌شده**

برای یک تصویر جاسازی‌شده، داده‌های تصویر را به ارائه اضافه کنید و یک فریم تصویر با [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) ایجاد کنید. تصویر بخشی از بسته ارائه می‌شود، بنابراین ارائه هنگام انتقال به کامپیوتر دیگر به‌صورت خودکفا می‌ماند.

مثال زیر یک تصویر PNG اضافه می‌کند، فریمی با ابعاد اصلی تصویر ایجاد می‌کند و قالب‌بندی خطوط و چرخش را اعمال می‌نماید:

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

فریم تصویر هندسه نمایش داده‌شده را کنترل می‌کند؛ تغییر اندازه فریم ابعاد پیکسل اصلی ذخیره‌شده در منبع تصویر جاسازی‌شده را تغییر نمی‌دهد. این تمایز هنگام برش یا فشرده‌سازی تصویر در مراحل بعدی مهم می‌شود.

## **استفاده از مقیاس نسبی**

[PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) مقیاس عرض و ارتفاع نسبی فریم را از طریق [setRelativeScaleWidth](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) و [setRelativeScaleHeight](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-) در دسترس قرار می‌دهد. مقدار `1.0` معادل 100٪ اندازه اصلی تصویر است. مقیاس نسبی زمانی مفید است که یک جریان کاری نیاز به حفظ نسبت به اندازه منبع تصویر داشته باشد به جای محاسبه ابعاد نهایی به‌صورت دستی.

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

مقیاس نسبی تنظیمات مقیاس فریم را تغییر می‌دهد؛ تصویر جاسازی‌شده را دوباره‌نمونه‌برداری یا فشرده‌سازی نمی‌کند.

## **تصاویر جاسازی‌شده و پیوندی**

یک تصویر جاسازی‌شده داده‌های تصویر را داخل ارائه ذخیره می‌کند و بنابراین برای قابلیت حمل و رندر پیش‌بینی‌شدنی ایمن‌ترین انتخاب است. یک تصویر پیوندی مکان خارجی را از طریق متد [Picture.setLinkPathLong](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) ذخیره می‌کند به‌جای جاسازی داده‌های تصویر به همان شیوه.

تصاویر پیوندی می‌توانند مقدار داده تصویر ذخیره‌شده در PPTX را کاهش دهند، اما وابستگی خارجی ایجاد می‌کنند. فایل پیوندی باید برای برنامه‌ای که ارائه را باز یا رندر می‌کند، در دسترس بماند. اگر مسیر تغییر کند، فایل جابجا شود یا منبع در دسترس نباشد، تصویر پیوندی ممکن است همان‌طور که انتظار می‌رود نمایش داده نشود. برای ارائه‌هایی که باید از طریق ایمیل ارسال، آرشیو یا در محیط‌های ایزوله رندر شوند، تصاویر جاسازی‌شده معمولاً قابل اطمینان‌تر هستند.

### **افزودن تصویر پیوندی**

مثال زیر یک فریم تصویر ایجاد می‌کند و آن را به یک فایل تصویر محلی اشاره می‌دهد. این مثال فقط به پیوند تصویر می‌پردازد؛ پیوند ویدیو یک جریان کاری رسانه‌ای جداگانه است و عمداً در این مثال ترکیب نشده است.

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

از پیوندها زمانی استفاده کنید که مدیریت فایل خارجی به‌صورت عمدی باشد. از آن‌ها صرفاً به عنوان جایگزینی برای فشرده‌سازی استفاده نکنید: یک PPTX کوچک با وابستگی‌های شکسته معمولاً کمتر مفید است نسبت به یک ارائه بزرگتر که خودکفا باشد.

## **استخراج تصاویر از فریم‌های تصویر**

قبل از استخراج تصویر از یک ارائه موجود، بررسی کنید که شکل واقعاً یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) باشد و شامل تصویر جاسازی‌شده باشد. فریم‌های تصویر پیوندی ممکن است بایت‌های تصویری که می‌توان به همان شیوه استخراج کرد را نداشته باشند.

### **استخراج تصویر رستر**

API تصویر مدرن مستقیماً از [IImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/) استفاده می‌کند. مثال زیر اولین تصویر رستر جاسازی‌شده روی یک اسلاید را پیدا می‌کند و به عنوان PNG ذخیره می‌نماید:

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

ذخیره از طریق [IImage.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/iimage/#save) تصویر استخراج‌شده را به فرمت خروجی درخواست‌شده تبدیل می‌کند. اگر به بایت‌های رمزنگاری‌شده ذخیره‌شده در ارائه به‌جای فایل رستر تبدیل‌شده نیاز دارید، به جای آن از داده‌های دودویی منبع تصویر استفاده کنید.

### **استخراج تصویر SVG**

برای یک تصویر SVG، [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) یک شیء [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) را در اختیار می‌گذارد. این امکان را می‌دهد که داده‌های SVG را مستقیماً بازیابی کنید به‌جای رستری کردن تصویر ابتدا.

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

نگه داشتن محتوای SVG به عنوان SVG، منبع برداری را داخل ارائه حفظ می‌کند. خروجی‌های رستری مانند PNG یا JPEG صرفاً محتوای برداری را به پیکسل تبدیل می‌کنند. خروجی اسلاید به PDF یا SVG نیز یک عملیات رندر است، بنابراین گرافیک‌های خروجی نباید به‌عنوان یک نسخه بایت‌به‌بایت از SVG اصلی در نظر گرفته شوند؛ هنگام نیاز به منبع برداری اصلی، از داده‌های [SvgImage.getSvgData](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/#getSvgData--) استفاده کنید.

## **برش تصویر**

برش تعیین می‌کند که کدام بخش از تصویر داخل فریم قابل مشاهده باشد. مقادیر برش در [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) درصدی از ابعاد تصویر منبع هستند. برش اولیه پیکسل‌های مخفی را از تصویر جاسازی‌شده حذف نمی‌کند؛ تنها ناحیه قابل مشاهده را تغییر می‌دهد.

مثال زیر به‌صورت ایمن یک فریم تصویر پیدا می‌کند و مقادیر برش را اعمال می‌نماید:

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

از آنجا که داده تصویر مخفی هنوز موجود است، می‌توان برش را بعداً بدون از دست رفتن پیکسل‌های اصلی تغییر داد. اگر حجم فایل مهم‌تر از قابلیت بازگردانی باشد، نواحی برش‌شده می‌توانند همان‌طور که در بخش بعدی توضیح داده شد، به‌صورت فیزیکی حذف شوند.

## **حذف داده‌های تصویر برش‌خورده**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) داده‌های تصویری خارج از مستطیل برش فعلی را حذف می‌کند و منبع تصویر نتیجه‌گیری‌شده را برمی‌گرداند. این می‌تواند حجم فایل را کاهش دهد، اما یک بهینه‌سازی مخرب است: پس از ذخیره ارائه، پیکسل‌های حذف‌شده دیگر برای عملیات «برداشتن برش» در دسترس نیستند.

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

این متد ممکن است یک منبع تصویر جدید به ارائه اضافه کند. اگر تصویر اصلی توسط فریم‌های تصویر دیگر نیز استفاده شود، آن فریم‌ها هنوز به منبع موجود خود نیاز دارند، بنابراین حذف نواحی برش‌شده لزوماً تعداد کل تصاویر را کاهش نمی‌دهد. برش محتوای WMF یا EMF با این متد نتیجه برش‌شده را به PNG رستری می‌کند.

## **فشرده‌سازی تصاویر رستر**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) وضوح تصویر رستر را نسبت به اندازه‌ای که تصویر نمایش داده می‌شود کاهش می‌دهد. همچنین می‌تواند نواحی برش‌شده را در همان عملیات حذف کند. این متد زمانی `true` برمی‌گرداند که تصویر تغییر اندازه یا برش داده شده باشد و زمانی `false` که نیازی به تغییر نبوده باشد.

از یک مقدار پیش‌تعریف‌شده [PicturesCompression](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturescompression/) هنگامیکه وضوح هدف استاندارد کافی است، استفاده کنید:

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

فشرده‌سازی برای تصاویر رستر منظور شده است. محتویات SVG و متافایل توسط این جریان کاری فشرده‌سازی رستر کاهش نمی‌یابد. همچنین به یاد داشته باشید که وضوح پایین‌تر و نواحی برش‌شده حذف‌شده نمی‌توانند از ارائه بهینه‌شده بازگردانده شوند. یک وضوح هدف را بر پایه بزرگ‌ترین اندازه‌ای که تصویر در آن واقعاً مشاهده یا خروجی می‌شود انتخاب کنید، نه اینکه کمترین DPI را به‌صورت سراسری اعمال کنید.

## **مدیریت افکت‌های تبدیل تصویر**

برای یک جریان کاری کامل شامل روشنایی، کنتراست، تبدیل‌های رنگی، تاری، افکت‌های آلفا، زنجیره‌های مرتب‌شده، بازرسی، حذف و تأیید دورانه، به [Image Transform Effects](/slides/fa/nodejs-java/image-transform-effects/) مراجعه کنید.

## **قفل کردن هندسه فریم تصویر**

تنظیمات [PictureFrameLock](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/) تعیین می‌کند که کدام عملیات‌های ویرایشی برای فریم تصویر غیرفعال هستند. به‌عنوان مثال، [setAspectRatioLocked](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) نسبت ابعاد شکل را در حین تغییر اندازه حفظ می‌کند.

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

قفل بر روی شکل فریم تصویر اعمال می‌شود. این باعث نمی‌شود تصویر منبع دوباره‌نمونه‌برداری یا به‌صورت دائمی به همان نسبت ابعاد تبدیل شود.

## **تنظیم مقادیر StretchOffset**

زمانی که حالت پر کردن تصویر «stretch» باشد، مقادیر stretch‑offset در [PictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/) مستطیل پر را نسبت به جعبه مرزی فریم تصویر تعریف می‌کنند. درصدهای مثبت یک تو رفتگی از لبه ایجاد می‌کنند، در حالی که درصدهای منفی یک بیرون‌زدگی ایجاد می‌کنند.

این متفاوت از برش است. مقادیر برش تعیین می‌کنند که کدام بخش از تصویر منبع قابل مشاهده باشد؛ در حالی که stretch offsets مستطیلی را که پر شدن تصویر قابل مشاهده در آن کشیده می‌شود تغییر می‌دهند.

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

از stretch offsets برای قرار دادن پر کردن استفاده کنید. برای مخفی کردن لبه‌های تصویر منبع از ویژگی‌های برش استفاده کنید.

## **ذخیره‌سازی، حجم فایل و ملاحظات خروجی**

معاملات اصلی زمانی آسان‌تر مدیریت می‌شوند که ذخیره‌سازی تصویر و قالب‌بندی فریم تصویر جداگانه در نظر گرفته شوند:

- **تصاویر جاسازی‌شده** ارائه را خودکفا می‌سازند و برای به اشتراک‌گذاری و رندر سمت سرور قابل اطمینان‌ترین گزینه هستند، اما تصاویر رستر بزرگ حجم PPTX و مصرف حافظه را افزایش می‌دهند.
- **تصاویر پیوندی** می‌توانند بسته را کوچکتر نگه دارند، اما ارائه به فایل‌های خارجی موجود در مسیرهای ذخیره‌شده وابسته می‌شود.
- **برش** در ابتدا غیر مخرب است. پیکسل‌های مخفی تا زمانی که نواحی برش‌شده صراحتاً حذف یا در زمان فشرده‌سازی حذف نشوند، درجا می‌مانند.
- **فشرده‌سازی** می‌تواند حجم فایل را برای تصاویر رستر بزرگ به‌طور قابل توجهی کاهش دهد، اما وضوح منبع را از دست می‌دهد. باید پس از تعیین اندازه نهایی روی اسلاید اعمال شود.
- **تصاویر SVG** باید به‌عنوان SVG باقی بمانند هنگامی که حفظ بردار مهم است. زمانی که به خود منبع برداری نیاز دارید، SVG جاسازی‌شده را مستقیماً استخراج کنید. خروجی‌های اسلاید رستری همیشه اسلاید رندرشده را به پیکسل تبدیل می‌کنند.
- **تصاویر تکراری** باید در صورت امکان از یک منبع [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) موجود استفاده کنند به‌جای بارگذاری مکرر همان فایل در جریان کاری ارائه.

برای ارائه‌های بزرگ، بهینه‌سازی تصویر معمولاً زمانی مؤثر است که به‌صورت انتخابی انجام شود: لوگوها و دیاگرام‌ها را به‌عنوان محتوای برداری نگه دارید، عکس‌ها را بر اساس اندازه واقعی نمایش فشرده کنید، پیکسل‌های برش‌خورده را تنها زمانی حذف کنید که ویرایش بعدی لازم نباشد و از پیوندهای خارجی تا زمانی که مدیریت وابستگی بخشی از طراحی استقرار باشد، خودداری کنید.

## **پرسش‌های متداول**

**تفاوت فریم تصویر و منبع تصویر چیست؟**

یک [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) نمایانگر یک منبع تصویر مرتبط با ارائه است. یک [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) یک شکل روی اسلاید است که تصویر را نمایش می‌دهد و هندسه و قالب‌بندی سطح فریم مانند اندازه، چرخش, مقادیر برش, افکت‌ها و قفل‌ها را ذخیره می‌کند.

**باید تصاویر را جاسازی کنم یا پیوند دهم؟**

تصاویر را زمانی که ارائه باید قابل حمل، بایگانی یا بدون دسترسی به منابع خارجی رندر شود، جاسازی کنید. فقط وقتی نگهداری فایل‌های تصویر خارج از PPTX قصدی باشد و مکان‌های خارجی به‌صورت قابل اطمینان مدیریت شوند، تصاویر را پیوند دهید.

**آیا برش حجم فایل PPTX را کاهش می‌دهد؟**

خود برش این کار را نمی‌کند. تنظیمات عادی برش بخش‌هایی از تصویر منبع را مخفی می‌کند ولی پیکسل‌های زیرین را نگه می‌دارد. برای کاهش حجم می‌توانید از [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) یا فشرده‌سازی تصویر همراه با حذف نواحی برش‌شده استفاده کنید.

**آیا می‌توان پس از فشرده‌سازی کیفیت تصویر را بازیابی کرد؟**

نه. فشرده‌سازی می‌تواند وضوح رستر ذخیره‌شده را کاهش دهد و حذف نواحی برش‌شده داده‌های تصویر را از بین می‌برد. اگر ویرایش با وضوح بالا در آینده ممکن است لازم باشد، تصویر منبع اصلی را خارج از ارائه نگه دارید.

**چگونه باید با تصاویر SVG رفتار کرد؟**

محافظت از محتویات SVG به‌عنوان SVG زمانی که حفظ دقت برداری مهم است، انجام شود. می‌توان [SvgImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/svgimage/) جاسازی‌شده را مستقیماً استخراج کرد. رندر اسلاید به فرمت رستری مانند PNG یا JPEG SVG را به پیکسل تبدیل می‌کند.

**چگونه می‌توان از تبدیل‌های ناامن هنگام خواندن اسلایدهای موجود جلوگیری کرد؟**

قبل از استفاده از اعضای مخصوص فریم تصویر، نوع شکل را بررسی کنید. یک بررسی `java.instanceOf` در برابر [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) از تبدیل‌های نامعتبر جلوگیری می‌کند و به کد اجازه می‌دهد اسلایدهایی که فریم تصویر ندارند را به‌صورت صحیح مدیریت کند.