---
title: مدیریت پس‌زمینه‌های ارائه در اندروید
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/androidjava/presentation-background/
keywords:
- پس‌زمینه ارائه
- پس‌زمینه اسلاید
- رنگ ثابت
- رنگ گرادیان
- پس‌زمینه تصویر
- شفافیت پس‌زمینه
- ویژگی‌های پس‌زمینه
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه پس‌زمینه‌های داینامیک را در فایل‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای اندروید از طریق Java تنظیم کنید و با نکات کد ارائه‌های خود را ارتقا دهید."
---
## **مقدمه**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید عادی** (یک اسلاید منفرد) یا یک **اسلاید اصلی** (که به چندین اسلاید به‌صورت همزمان اعمال می‌شود) تنظیم کنید.

![پس‌زمینه پاورپوینت](powerpoint-background.png)

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه یک اسلاید خاص در یک ارائه تنظیم کنید — حتی اگر ارائه از اسلاید اصلی استفاده کند. این تغییر تنها بر روی اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید را با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) در [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) استفاده کنید تا رنگ پس‌زمینه ثابت را مشخص کنید.
5. ارائه تغییر یافته را ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد یک رنگ ثابت را به‌عنوان پس‌زمینه اسلاید اصلی در یک ارائه تنظیم کنید. اسلاید اصلی به‌عنوان الگو عمل می‌کند و قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین هنگامی که یک رنگ ثابت برای پس‌زمینه اسلاید اصلی انتخاب می‌کنید، بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید اصلی را (از طریق `getMasters`) با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید اصلی را با استفاده از [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از متد [getSolidFillColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) استفاده کنید تا رنگ پس‌زمینه ثابت را مشخص کنید.
5. ارائه تغییر یافته را ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // رنگ پس‌زمینه اسلاید اصلی را به سبز جنگلی تنظیم کنید.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

یک گرادیان اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. هنگام استفاده به‌عنوان پس‌زمینه اسلاید، گرادیان‌ها می‌توانند نمایش ارائه را هنری‌تر و حرفه‌ای‌تر کنند. Aspose.Slides به شما امکان می‌دهد رنگ گرادیان را به‌عنوان پس‌زمینه اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید را با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) به `Gradient` تنظیم کنید.
4. از متد [getGradientFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) استفاده کنید تا تنظیمات دلخواه گرادیان را پیکربندی کنید.
5. ارائه تغییر یافته را ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // یک اثر گرادیان را به پس‌زمینه اعمال کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);

    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم تصویر به‌عنوان پس‌زمینه اسلاید**

علاوه بر پرکننده‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینه اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) ایجاد کنید.
2. نوع پس‌زمینه اسلاید را با استفاده از [BackgroundType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/backgroundtype/) به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/filltype/) به `Picture` تنظیم کنید.
4. تصویری را که می‌خواهید به‌عنوان پس‌زمینه اسلاید استفاده کنید بارگذاری کنید.
5. تصویر را به مجموعه تصاویر ارائه اضافه کنید.
6. از متد [getPictureFillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) در [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/fillformat/) استفاده کنید تا تصویر را به‌عنوان پس‌زمینه اختصاص دهید.
7. ارائه تغییر یافته را ذخیره کنید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // ویژگی‌های تصویر پس‌زمینه را تنظیم کنید.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // بارگذاری تصویر.
    IImage image = Images.fromFile("Tulips.jpg");
    // تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // ارائه را روی دیسک ذخیره کنید.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

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

    // تصویر استفاده‌شده برای پرکردن پس‌زمینه را تنظیم کنید.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // حالت پرکردن تصویر را به کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
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
ادامه مطلب: [**کاشی تصویر به عنوان بافت**](/slides/fa/androidjava/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینه اسلاید را تنظیم کنید تا محتویات اسلاید برجسته‌تر شوند. کد Java زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینه اسلاید را تغییر دهید:

```java
int transparencyValue = 30; // به عنوان مثال.

// دستهٔ عملیات تبدیل تصویر را دریافت کنید.
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// یک افکت شفافیت با درصد ثابت موجود را پیدا کنید.
IAlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform) {
    if (operation instanceof IAlphaModulateFixed) {
        transparencyOperation = (IAlphaModulateFixed)operation;
        break;
    }
}

// مقدار شفافیت جدید را تنظیم کنید.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **دریافت مقدار پس‌زمینه اسلاید**

Aspose.Slides رابط [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibackgroundeffectivedata/) را برای بازیابی مقادیر موثر پس‌زمینه اسلاید فراهم می‌کند. این رابط [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) و [EffectFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) موثر را در اختیار می‌گذارد.

با استفاده از متد `getBackground` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslide/)، می‌توانید پس‌زمینه موثر یک اسلاید را بدست آورید.

```java
// یک نمونه از کلاس Presentation ایجاد کنید.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // پس‌زمینه مؤثر را بازیابی کنید، به‌همراه در نظر گرفتن اسلاید اصلی، طرح‌بندی و تم.
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

**آیا می‌توانم پس‌زمینه سفارشی را بازنشانی کرده و پس‌زمینه تم/چیدمان را بازیابی کنم؟**

بله. پر کردن سفارشی اسلاید را حذف کنید و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/androidjava/slide-layout/)/[master](/slides/fa/androidjava/slide-master/) مربوطه (یعنی [theme background](/slides/fa/androidjava/presentation-theme/)) به ارث می‌رسد.

**اگر بعداً تم ارائه را تغییر دهم، چه اتفاقی برای پس‌زمینه می‌افتد؟**

اگر اسلاید پر کردن خود را داشته باشد، بدون تغییر می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/androidjava/slide-layout/)/[master](/slides/fa/androidjava/slide-master/) به ارث برده شده باشد، با تم جدید به‌روزرسانی می‌شود.