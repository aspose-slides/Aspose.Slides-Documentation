---
title: مدیریت پس‌زمینه‌های ارائه در JavaScript
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/nodejs-java/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ ثابت
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- خصوصیات پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای Node.js پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument تنظیم کنید و با نکات کد ارائه‌های خود را ارتقا دهید."
---
## **معرفی**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید عادی** (یک اسلاید تک) یا یک **اسلاید مستر** (که بر چندین اسلاید به‌صورت همزمان اعمال می‌شود) تنظیم کنید.

![PowerPoint background](powerpoint-background.png)

## **تنظیم پس‌زمینه با رنگ ثابت برای اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه برای یک اسلاید خاص در یک ارائه تنظیم کنید — حتی اگر ارائه از اسلاید مستر استفاده کند. این تغییر فقط بر روی اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید را با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. نوع پرکردن پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) در [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) استفاده کنید تا رنگ پس‌زمینه ثابت را تعیین کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان JavaScript نشان می‌دهد چگونه یک رنگ ثابت آبی را به‌عنوان پس‌زمینه برای اسلاید عادی تنظیم کنید:

```js
// یک نمونه از کلاس Presentation ایجاد کنید.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // رنگ پس‌زمینهٔ اسلاید را به آبی تنظیم کنید.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // ارائه را در دیسک ذخیره کنید.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه با رنگ ثابت برای اسلاید مستر**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه برای اسلاید مستر در یک ارائه تنظیم کنید. اسلاید مستر به‌عنوان قالبی عمل می‌کند که قالب‌بندی همه اسلایدها را کنترل می‌کند، بنابراین وقتی یک رنگ ثابت برای پس‌زمینهٔ اسلاید مستر انتخاب می‌کنید، این رنگ بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید مستر را (از طریق `getMasters`) با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. نوع پرکردن پس‌زمینه اسلاید مستر را با استفاده از [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) برای تعیین رنگ پس‌زمینه ثابت استفاده کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان JavaScript نشان می‌دهد چگونه یک رنگ ثابت (سبز) را به‌عنوان پس‌زمینه برای اسلاید مستر تنظیم کنید:

```js
// یک نمونه از کلاس Presentation ایجاد کنید.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // رنگ پس‌زمینهٔ اسلاید مستر را به سبز جنگلی تنظیم کنید.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // ارائه را در دیسک ذخیره کنید.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. هنگامی که به‌عنوان پس‌زمینهٔ اسلاید استفاده می‌شود، می‌تواند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر جلوه دهد. Aspose.Slides به شما امکان می‌دهد یک رنگ گرادیان را به‌عنوان پس‌زمینه برای اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید را با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. نوع پرکردن پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) به `Gradient` تنظیم کنید.
4. از متد [getGradientFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#getGradientFormat) در [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) استفاده کنید تا تنظیمات گرادیان دلخواه خود را پیکربندی کنید.
5. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان JavaScript نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینه برای اسلاید تنظیم کنید:

```js
// یک نمونه از کلاس Presentation ایجاد کنید.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // یک اثر گرادیان به پس‌زمینه اعمال کنید.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // ارائه را در دیسک ذخیره کنید.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تصویر به‌عنوان پس‌زمینه اسلاید**

علاوه بر پر کردن‌های ثابت و گرادیان، Aspose.Slides به شما اجازه می‌دهد از تصاویر به‌عنوان پس‌زمینهٔ اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید را با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. نوع پرکردن پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/filltype/) به `Picture` تنظیم کنید.
4. تصویر مورد نظر برای استفاده به‌عنوان پس‌زمینهٔ اسلاید را بارگذاری کنید.
5. تصویر را بهٔ مجموعهٔ تصاویر ارائه اضافه کنید.
6. از متد [getPictureFillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) در [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) استفاده کنید تا تصویر را به‌عنوان پس‌زمینه اختصاص دهید.
7. ارائهٔ تغییر یافته را ذخیره کنید.

مثال زیر به زبان JavaScript نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```js
// یک نمونه از کلاس Presentation ایجاد کنید.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // خصوصیات تصویر پس‌زمینه را تنظیم کنید.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // بارگذاری تصویر.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // ارائه را در دیسک ذخیره کنید.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمونهٔ کد زیر نشان می‌دهد چگونه نوع پرکردن پس‌زمینه را به یک تصویر کاشی‌شده تنظیم کرده و ویژگی‌های کاشی را تغییر دهید:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // تصویری که برای پرکردن پس‌زمینه استفاده می‌شود را تنظیم کنید.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // حالت پرکردن تصویر را به کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
ادامه مطلب: [**Tile Picture As Texture**](/slides/fa/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید برجستگی بیشتری پیدا کند. کد JavaScript زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```js
var transparencyValue = 30; // به عنوان مثال.

// دریافت مجموعهٔ عملیات تبدیل تصویر.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **دریافت مقدار پس‌زمینه اسلاید**

Aspose.Slides کلاس `BackgroundEffectiveData` را برای بازیابی مقادیر مؤثر پس‌زمینهٔ اسلاید فراهم می‌کند. این کلاس نمایانگر [FillFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/fillformat/) و [EffectFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/effectformat/) مؤثر است.

با استفاده از متد `getBackground` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseslide/) می‌توانید پس‌زمینهٔ مؤثر یک اسلاید را به‌دست آورید.

مثال زیر به زبان JavaScript نشان می‌دهد چگونه مقدار پس‌زمینهٔ مؤثر یک اسلاید را دریافت کنید:

```js
// یک نمونه از کلاس Presentation ایجاد کنید.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // دریافت پس‌زمینهٔ مؤثر، با در نظر گرفتن مستر، چیدمان و تم.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا می‌توانم پس‌زمینهٔ سفارشی را بازنشانی کنم و پس‌زمینهٔ تم/چیدمان را بازگردانم؟**

بله. پرکردن سفارشی اسلاید را حذف کنید و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/nodejs-java/slide-layout/)/[master](/slides/fa/nodejs-java/slide-master/) مربوطه (یعنی [theme background](/slides/fa/nodejs-java/presentation-theme/)) به ارث برده می‌شود.

**اگر بعداً تم ارائه را تغییر دهم، چه اتفاقی برای پس‌زمینه می‌افتد؟**

اگر اسلاید پرکردن خاص خود را داشته باشد، بدون تغییر باقی خواهد ماند. اگر پس‌زمینه از [layout](/slides/fa/nodejs-java/slide-layout/)/[master](/slides/fa/nodejs-java/slide-master/) به ارث برده شده باشد، با تم جدید به‌روز می‌شود.