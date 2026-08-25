---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با JavaScript
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/nodejs-java/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- تبدیل به خاکستری
- دو‑تن
- رنگ‌نگاری
- HSL
- جایگزینی رنگ
- محوشدن
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "اعمال، زنجیره‌سازی، بازبینی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای Node.js از طریق Java."
---
## **بررسی کلی**

Aspose.Slides تنظیمات تصویر را به صورت یک مجموعهٔ مرتب از عملیات تبدیل تصویر نشان می‌دهد. برای یک فریم تصویر، ابتدا با [Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) فریم کار کنید و سپس به [Picture.getImageTransform](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) دسترسی پیدا کنید. [ImageTransformOperationCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) که برگردانده می‌شود، به شما امکان افزودن، شمارش، بازبینی، حذف و پاک‌سازی اثرها را بدون بازنویسی بایت‌های اصلی تصویر می‌دهد.

این مقاله یک جریان کار کامل برای روشنایی و کنتراست، تبدیل‌های رنگی، تار شدن، شفافیت، زنجیره‌های اثر مرتب، مقادیر مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و بازاستفادهٔ تصویر**

یک منبع تصویر و تصویر نمایشی آن اشیاء متفاوتی هستند:

- [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) داده‌های تصویر منبع را که توسط ارائه مالکیت می‌شود، ذخیره یا به آنها ارجاع می‌دهد.
- [Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) متعلق به پرکنندهٔ تصویر است و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [PictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/pictureframe/) شکل اسلاید است که پرکنندهٔ تصویر مرتبط، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را داراست.

بنابراین، عملیات تبدیل تصویر بایت‌های [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) را تغییر نمی‌دهند. وقتی همان [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) بیش از یک‌بار به [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/shapecollection/) ارسال شود، هر فریم تصویر جدید یک [Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) و مجموعه تبدیل خود را دریافت می‌کند. اعمال تبدیل خاکستری به یک فریم، فریم‌های دیگر را خاکستری نمی‌کند، حتی اگر همهٔ آن‌ها از یک منبع تصویر توکار استفاده کنند.

مدل [Picture.getImageTransform](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) همچنین توسط پرکننده‌های تصویری دیگر مانند شکل یا پس‌زمینهٔ اسلاید استفاده می‌شود. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر برای پارامترها**

روش‌های نشان داده شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه در ابتدا هر مقدار خارج از بازه را رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب مقصد ممکن است هنگام ذخیره‌سازی یا باز کردن فایل توسط PowerPoint این داده‌های نامعتبر را نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه معتبر و واحد |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` تا `100` درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | None | پارامتر عددی ندارد. آلفا بدون تغییر می‌ماند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر کانال‌های RGB و آلفا در `java.awt.Color` از `0` تا `255` هستند. |
| [addTintEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | `hue` از `0` (شامل) تا `360` (به‌جز) درجه؛ `amount` از `-100` تا `100` درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | `hue` از `0` تا `360` درجه؛ `saturation` و `luminance` از `-100` تا `100` درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | رنگ جایگزین مقادیر کانال‌های آن را از `0` تا `255` می‌گیرد. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [addBlurEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | `radius` مقدار غیرمنفی است و به نقطه (point) اندازه‌گیری می‌شود؛ `grow` یک Boolean است که تعیین می‌کند محتوای محو‌شده می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | درصد غیرمنفی. برای مقیاس‌بندی شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` تا `100` درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` تا `100` درصد آستانهٔ آلفا. مقادیر زیر آستانه شفاف می‌شوند؛ مقادیر برابر یا بالاتر مات می‌شوند. |

برای تعدیل ثابت آلفا، شفافیت و مات بودن مکمل یکدیگر هستند. به عنوان مثال، 35٪ شفافیت معادل مقدار 65٪ برای تعدیل آلفا است.

## **اعمال روشنایی و کنتراست**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) یک عملیات [BrightnessContrast](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/brightnesscontrast/) بر می‌گرداند. تنظیمات اسکالر آن هنگام ایجاد عملیات تعیین می‌شود. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/brightnesscontrast/) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را برمی‌گرداند که می‌توان آنها را بازبینی یا ثبت کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد و سپس پیش‌نمایشی رندر می‌کند بدون اینکه تصویر توکار را تغییر دهد:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/brightnesscontrast/) افزونهٔ اثر تصویر Office 2010 است و نسبت به اثر روشنایی استاندارد DrawingML کمتر قابل حمل است. زمانی که روشنایی و کنتراست پس از یک دورانی PPTX باید قابل ویرایش بمانند، از [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) استفاده کنید و پس از بازکردن مجدد فایل نتیجه را تأیید کنید. بخش محدودیت‌های قالب این تفاوت را با جزئیات بیشتر توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

اثرهای رنگی می‌توانند به‌صورت مستقل بر فریم‌های تصویری مختلف که یک منبع تصویر را دوباره استفاده می‌کنند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب خاکستری، دو‑تن، تنیک، تنظیم HSL و جایگزینی رنگ را اعمال می‌نماید.

[Duotone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/duotone/) دو پارامتر رنگی قابل ویرایش دارد: `color1` پیکسل‌های تاریک و `color2` پیکسل‌های روشن را نگاشت می‌کند. این یک مثال مفید برای اثری است که تنظیماتش پیچیده‌تر از یک مقدار اسکالر單 است.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) تمام رنگ هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا حفظ می‌شود. این متفاوت از [addColorChangeEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) است که یک رنگ منبع را به رنگ هدفی映射 می‌کند و هر دو قالب رنگ منبع و هدف را در اختیار می‌گذارد.

## **افزودن تار شدن، شفافیت و اثرهای آلفا**

[addBlurEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) همهٔ کانال‌های رنگی از جمله آلفا را تحت تأثیر قرار می‌دهد. وقتی لبهٔ محو‌شده ممکن است خارج از مرزهای تصویر اصلی بگیرد، `grow` را `true` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) استفاده کنید. این مقدار هر آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‑شفاف به نسبت متفاوت باقی می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) به‌جای آن یک مقدار آلفای واحد را برای همهٔ پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) آلفا را بر اساس یک آستانه به دو سطح تبدیل می‌کند.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سایر عملیات آلفای بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) است که هر آلفای غیرصفر را کاملاً مات می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) که هر آلفای زیر 100٪ را کاملاً شفاف می‌کند؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) که آلفا را به `100% - alpha` تبدیل می‌کند.

## **ساخت یک زنجیرهٔ اثر مرتب**

هر روش `add...Effect` یک عملیات جدید را در انتهای مجموعه اضافه می‌کند. رندرگر مجموعه را به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 به عنوان ورودی عملیات 1 می‌شود و الی آخر. بنابراین، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به عنوان مثال، خاکستری سپس تنیک ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را رنگ‌آمزی می‌کند. تنیک سپس خاکستری رنگ‌آمزی را از نو حذف می‌کند. به همان ترتیب، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را بازنویسی کند، در حالی که تعدیل آلفا تفاوت‌های نسبی آنها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار عملیات می‌سازد، به صورت PPTX ذخیره می‌کند، ارائه را دوباره باز می‌کند، هم نوع عملیات‌ها و هم ترتیب آنها را بررسی می‌کند و نتیجهٔ باز شده را رندر می‌کند:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

مجموعه اعمال ماتریس سازگاری‌ای اعمال نمی‌کند که عملیات رنگ، آلفا و تار شدن را به زنجیره‌های جداگانه محدود کند. می‌توان آنها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تنوع RGB تولید‌شده توسط اثرهای رنگی قبلی را حذف می‌کند؛ خاکستری پس از دو‑تن دو رنگ انتخابی را حذف می‌کند؛ و عملیات‌های سقف، کف، جایگزینی یا دو‑سطحی آلفا می‌توانند جزئیات آلفای ایجاد‑شده قبلی را نادیده بگیرند. زنجیره را مطابق توالی پردازش پیکسل موردنظر بسازید نه به‌عنوان پرچم‌های قالب‌بندی نامرتب.

## **بازبینی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش همان شیء‌ای است که در [Picture.getImageTransform](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) ذخیره می‌شود. بسته به اثر، ممکن است اعضای قابل نوشتن را مستقیماً در دسترس قرار دهد. به عنوان مثال، [Blur](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/blur/) مقادیر نوشتنی `radius` و `grow` را افشا می‌کند، [AlphaModulateFixed](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/alphamodulatefixed/) یک `amount` قابل نوشتن دارد، و [AlphaBiLevel](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/alphabilevel/) یک `threshold` قابل نوشتن ارائه می‌دهد. اثرهای رنگی مانند [Duotone](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/duotone/) اشیاء [ColorFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/colorformat/) قابل تغییر را افشا می‌کنند.

برخی عملیات‌ها، از جمله [BrightnessContrast](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tint/) و [AlphaReplace](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/alphareplace/)، اسکالرهای ایجادشان را به عنوان ویژگی‌های قابل نوشتن ارائه نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و یک جایگزین در موقعیت موردنظر اضافه کنید.

داده‌های مؤثر که توسط `getEffective()` بازگردانده می‌شود، محاسبه‌شده و فقط‑خواندنی هستند. این داده‌ها برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌سازی‌شده‌ای که رندرگر استفاده می‌کند، مفیدند، اما سطح ویرایشی دیگری نیستند. مثال زیر زنجیره را شمارش می‌کند و مقادیر مؤثر را در جایی که API متناظر آنها را فراهم می‌کند، بازبینی می‌نماید:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

اثرهای بدون پارامتر مانند خاکستری، سقف آلفا و وارون آلفا هنوز شیء دادهٔ مؤثر دارند، اما هیچ تنظیم اسکالر برای چاپ وجود ندارد. حضور و موقعیت آنها در مجموعه اطلاعات مهم است.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) برای حذف یک عملیات بر اساس اندیس استفاده کنید. چون اندیس‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و پس از شمارش آن را حذف کنید. برای حذف کل زنجیره از [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) استفاده کنید.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) استفاده‑شده را حذف، فشرده‌سازی یا به‌صورت دیگری تغییر نمی‌دهد.

## **در نظر گرفتن قالب‌های ارائه و هدف‌های خروجی**

تبدیل‌های تصویر در DrawingML منشأ می‌گیرند، بنابراین PPTX قالب ویرایش‌پذیر ترجیحی برای زنجیره‌های اثر است. حتی در PPTX، همهٔ عملیات‌ها یک‌نظیر قابل حمل نیستند:

- عملیات‌های استاندارد DrawingML مانند روشنایی، خاکستری، دو‑تن، تنیک، HSL، تار شدن و عمل‌های آلفای رایج بیشترین شانس بقا در یک دورانی PPTX را دارند. همیشه فایل تولیدشده را باز کنید و مجموعه را بازبینی کنید وقتی حفظ اثرها الزامی است.
- [BrightnessContrast](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد روشنایی DrawingML. می‌تواند برای رندر در حافظه استفاده شود، اما پس از ذخیره و باز کردن PPTX تضمین نمی‌شود که به‌عنوان یک عملیات [BrightnessContrast](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/brightnesscontrast/) ویرایشی باقی بماند. برای تنظیمات روشنایی و کنتراست پایدار، از [addLuminanceEffect](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) استفاده کنید.
- قالب باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT ممکن است عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعهٔ پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. برای تأیید زنجیرهٔ ویرایشی پیچیده از PPT به‌عنوان قالب استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های تصویری دیگر زنجیرهٔ پشتیبانی‌شده را بر ظاهر رندر شده اعمال می‌کند. این خروجی‌ها مجموعهٔ [ImageTransformOperationCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/imagetransformoperationcollection/) ویرایشی را ندارند؛ قالب‌های رستر نتیجه را به پیکسل‌ها مسطح می‌کنند و صادرات سند/بردار نمایش رندر خود را ذخیره می‌کنند.
- اثرها تصویر پیوندی را خود‑کامل نمی‌کنند. رندر تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصارف مختلف ارائه ممکن است موارد حاشیه‌ای را به‌طور متفاوت رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کوانتایزینگ ترکیب می‌شوند. برای خروجی‌های بحرانی، هم دورانی ویرایشی و هم قالب نهایی خروجی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **پرسش‌های متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر توکار را تغییر می‌دهند؟**

نه. این عملیات‌ها به [Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) متعلق هستند که توسط پرکنندهٔ تصویر استفاده می‌شود. بایت‌های زیرین [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) بدون تغییر می‌مانند.

**آیا دو فریم تصویر که از یک تصویر استفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. استفاده مجدد از یک [PPImage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ppimage/) از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر فریم تصویر معمولاً یک [Picture](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/picture/) و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، تار شدن و آلفا را ترکیب کرد؟**

بله. مجموعه این اثرها را در یک زنجیرهٔ مرتب می‌پذیرد. توجه کنید هر عملیات چه تأثیری بر خروجی عملیات قبلی دارد، زیرا عملیات جایگزینی و آستانه‑یابی ممکن است جزئیات رنگ یا آلفای پیشین را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‑شده. عملیات ذخیره‑شده در مجموعهٔ تبدیل را جایی ویرایش کنید که اعضای قابل نوشتن دارد؛ در غیر این صورت آن را حذف کنید و با پارامترهای ایجاد جدید جایگزین کنید.

**کدام قالب را برای حفظ زنجیرهٔ تبدیل استفاده کنم؟**

از PPTX استفاده کنید و فایل را با باز کردن مجدد تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و قالب‌های خروجی رندر فقط ظاهر را حفظ می‌کنند نه عملیات تبدیل ویرایشی.