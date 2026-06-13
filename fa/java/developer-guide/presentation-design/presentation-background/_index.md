---
title: "مدیریت پس‌زمینه‌های ارائه در جاوا"
linktitle: "پس‌زمینه اسلاید"
type: docs
weight: 20
url: /fa/java/presentation-background/
keywords:
- "پس‌زمینه ارائه"
- "پس‌زمینه اسلاید"
- "رنگ ثابت"
- "رنگ گرادیان"
- "پس‌زمینه تصویر"
- "شفافیت پس‌زمینه"
- "ویژگی‌های پس‌زمینه"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Java"
- "Aspose.Slides"
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای جاوا، پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument تنظیم کنید و با نکات کد، ارائه‌های خود را تقویت کنید."
---
## **معرفی**

رنگ‌های ثابت، گرادیان‌ها و تصاویر به طور معمول برای پس‌زمینهٔ اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید عادی** (یک اسلاید منفرد) یا یک **اسلاید اصلی** (که برای چندین اسلاید به‌صورت هم‌زمان اعمال می‌شود) تنظیم کنید.

![PowerPoint background](powerpoint-background.png)

## **تنظیم پس‌زمینهٔ رنگ ثابت برای یک اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد رنگ ثابت را به عنوان پس‌زمینهٔ اسلایدی خاص در ارائه تنظیم کنید— حتی اگر ارائه از اسلاید اصلی استفاده کند. این تغییر فقط بر روی اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) پس‌زمینه اسلاید را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getSolidFillColor--) در [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) برای مشخص کردن رنگ پس‌زمینهٔ ثابت استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک رنگ ثابت آبی را به عنوان پس‌زمینهٔ یک اسلاید عادی تنظیم کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // رنگ پس‌زمینهٔ اسلاید را به آبی تنظیم کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینهٔ رنگ ثابت برای یک اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد رنگ ثابت را به عنوان پس‌زمینهٔ اسلاید اصلی در یک ارائه تنظیم کنید. اسلاید اصلی به عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی یک رنگ ثابت را برای پس‌زمینهٔ اسلاید اصلی انتخاب می‌کنید، برای هر اسلاید اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید اصلی (از طریق `getMasters`) را به `OwnBackground` تنظیم کنید.
3. مقدار [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) پس‌زمینه اسلاید اصلی را به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getSolidFillColor--) برای مشخص کردن رنگ پس‌زمینهٔ ثابت استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک رنگ ثابت سبز را به عنوان پس‌زمینهٔ یک اسلاید اصلی تنظیم کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // رنگ پس‌زمینهٔ اسلاید Master را به سبز جنگلی تنظیم کنید.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینهٔ گرادیان برای یک اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. هنگام استفاده به عنوان پس‌زمینهٔ اسلاید، گرادیان‌ها می‌توانند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر نشان دهند. Aspose.Slides به شما امکان می‌دهد رنگ گرادیان را به عنوان پس‌زمینهٔ اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) پس‌زمینه اسلاید را به `Gradient` تنظیم کنید.
4. از متد [getGradientFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getGradientFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) برای پیکربندی تنظیمات گرادیان دلخواه استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک رنگ گرادیان را به عنوان پس‌زمینهٔ یک اسلاید تنظیم کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // یک اثر گرادیان به پس‌زمینه اعمال کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم یک تصویر به‌عنوان پس‌زمینهٔ اسلاید**

علاوه بر پرکننده‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینهٔ اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. مقدار [FillType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/filltype/) پس‌زمینه اسلاید را به `Picture` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینه اسلاید استفاده کنید، بارگذاری کنید.
5. تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
6. از متد [getPictureFillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/#getPictureFillFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

مثال زیر به زبان Java نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینهٔ یک اسلاید تنظیم کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // تنظیم ویژگی‌های تصویر پس‌زمینه.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // بارگذاری تصویر.
    IImage image = Images.fromFile("Tulips.jpg");
    // افزودن تصویر به مجموعهٔ تصاویر ارائه.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // ذخیرهٔ ارائه روی دیسک.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نمونه کد زیر نشان می‌دهد چگونه نوع پرکنندهٔ پس‌زمینه را به تصویر کاشی‌شده تنظیم کرده و ویژگی‌های کاشی را تغییر دهید:

```java
Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // تصویر استفاده‌شده برای پرکنندهٔ پس‌زمینه را تنظیم کنید.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // حالت پرکنندهٔ تصویر را به کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}

بیشتر بخوانید: [**Tile Picture As Texture**](/slides/fa/java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید بیشتر مشهود شود. کد Java زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```java
int transparencyValue = 30; // برای مثال.

// دریافت مجموعهٔ عملیات تبدیل تصویر.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// یافتن اثر شفافیت ثابت‑درصد موجود.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// تنظیم مقدار جدید شفافیت.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **دریافت مقدار پس‌زمینهٔ اسلاید**

Aspose.Slides رابط [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibackgroundeffectivedata/) را برای بازیابی مقادیر مؤثر پس‌زمینهٔ اسلاید فراهم می‌کند. این رابط [FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و [EffectFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) مؤثر را نمایان می‌کند.

با استفاده از متد `getBackground` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslide/) می‌توانید پس‌زمینهٔ مؤثر یک اسلاید را به‌دست آورید.

مثال زیر به زبان Java نشان می‌دهد چگونه مقدار پس‌زمینهٔ مؤثر یک اسلاید را دریافت کنید:

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // پس‌زمینه مؤثر را بازیابی کنید، به‌حساب مستر، طرح‌بندی و تم.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا می‌توانم پس‌زمینهٔ سفارشی را بازنشانی کرده و پس‌زمینهٔ تم/چیدمان را بازیابم؟**

بله. پرکنندهٔ سفارشی اسلاید را حذف کنید و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/java/slide-layout/)/[master](/slides/fa/java/slide-master/) مربوطه (یعنی [theme background](/slides/fa/java/presentation-theme/)) به ارث برده می‌شود.

**اگر بعداً تم ارائه را تغییر دهم، چه اتفاقی برای پس‌زمینه می‌افتد؟**

اگر اسلاید پرکنندهٔ خود را داشته باشد، بدون تغییر می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/java/slide-layout/)/[master](/slides/fa/java/slide-master/) به ارث برده شده باشد، با تم جدید به‌روز می‌شود.