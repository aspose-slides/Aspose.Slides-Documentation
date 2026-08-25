---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها بر روی اندروید
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/androidjava/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- سطوح خاکستری
- دو-تن
- رنگ-پراست
- HSL
- جایگزینی رنگ
- تارشدگی
- شفافیت
- اثر آلفا
- زنجیره اثر
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویری با Aspose.Slides برای اندروید از طریق جاوا."
---
## **مروری کلی**

Aspose.Slides تنظیمات تصویر را به‌عنوان یک مجموعهٔ مرتب از عملیات تبدیل تصویر نمایش می‌دهد. برای یک فریم تصویر، با فریم‌ِ [ISlidesPicture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/) شروع کنید و به [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) دسترسی پیدا کنید. مجموعهٔ برگردانده‌شدهٔ [IImageTransformOperationCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/) به شما امکان اضافه‌کردن، مرور، بازرسی، حذف و پاک‌سازی اثرها را بدون بازنویسی بایت‌های تصویر اصلی می‌دهد.

این مقاله یک جریان کار کامل برای تنظیم روشنایی و کنتراست، تبدیل‌های رنگی، تارشدگی، شفافیت، زنجیرهٔ اثرات مرتب، مقادیر مؤثر، حذف و تأیید دور‌دوم پیمانهٔ PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفاده مجدد از تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد اشیای متفاوتی هستند:

- [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) داده‌های تصویر منبع را که توسط ارائه مالکیت می‌شود، ذخیره یا به آن ارجاع می‌دهد.
- [ISlidesPicture](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidespicture/) به پر کردن تصویر تعلق دارد و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [IPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipictureframe/) شکل اسلایدی است که پر کردن تصویر، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را در اختیار دارد.

بنابراین، عملیات‌های تبدیل تصویر بایت‌های موجود در [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) را تغییر نمی‌دهند. وقتی همان `IPPImage` بیش از یک بار به [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) پاس داده می‌شود، هر فریم تصویر جدید `ISlidesPicture` و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال خاکستری برای یک فریم، فریم‌های دیگر را خاکستری نمی‌کند، حتی اگر همه آن‌ها از همان منبع تصویر توکار استفاده کنند.

مدل `ISlidesPicture.getImageTransform` همچنین توسط پرکن‌های تصویر دیگر، مانند شکل یا پس‌زمینهٔ اسلاید استفاده می‌شود. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر برای پارامترها**

روش‌های نشان‌داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ فرمت هدف ممکن است هنگام ذخیره یا باز کردن فایل توسط PowerPoint داده‌های نامعتیر را نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه و واحد معتبر |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | هیچ پارامتر عددی ندارند. آلفا بدون تغییر می‌ماند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر RGB و کانال آلفا که توسط `android.graphics.Color` استفاده می‌شوند، از `0` تا `255` هستند. |
| [addTintEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | رنگ‌پراست (`hue`) از `0` شامل تا `360` مغایر، بر حسب درجه؛ مقدار (`amount`) از `-100` تا `100`، درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | رنگ‌پراست از `0` شامل تا `360` مغایر، بر حسب درجه؛ اشباع و روشنایی از `-100` تا `100`، درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | رنگ جایگزین مقادیر کانال از `0` تا `255` دارد. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [addBlurEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | شعاع باید غیرمنفی باشد و بر حسب پوینت اندازه‌گیری می‌شود؛ `grow` یک Boolean است که تعیین می‌کند آیا محتویات تار شده می‌توانند خارج از مرزهای اصلی گسترش یابند یا نه. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | درصد غیرمنفی. برای مقیاس‌بندی معمول شفافیت از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` تا `100`، درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` تا `100`، درصد آستانهٔ آلفا. مقادیر زیر آن شفاف می‌شوند؛ مقادیر برابر یا بالاتر آن نامشخص می‌شوند. |

برای تعدیل ثابت آلفا، شفافیت و مات بودن مکمل یکدیگرند. به‌عنوان مثال، 35٪ شفافیت معادل مقدار تعدیل آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) یک عملیات [IBrightnessContrast](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibrightnesscontrast/) بر می‌گرداند. تنظیمات اسکالر آن هنگام ایجاد عملیات ارائه می‌شود. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibrightnesscontrast/#getEffective--) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را بازمی‌گرداند که می‌توانید آن‌ها را بررسی یا ثبت کنید.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد و سپس پیش‌نمایشی رندر می‌کند بدون اینکه تصویر توکار تغییر کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/brightnesscontrast/) یک افزونهٔ اثر تصویر برای Office 2010 است و نسبت به اثر استاندارد DrawingML کم قابل حمل‌تر است. هنگامی که روشنایی و کنتراست باید پس از یک دور‑دوم PPTX قابل ویرایش بمانند، از [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) استفاده کنید و پس از بازکردن مجدد فایل نتیجه را تأیید کنید. بخش محدودیت‌های قالب این تمایز را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

اثرهای رنگی می‌توانند به‌صورت مستقل بر فریم‌های تصویری مختلفی که از یک منبع تصویر استفاده می‌کنند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب اثرهای خاکستری، دو‑تن، رنگ‌پراست، تنظیم HSL و جایگزینی رنگ را اعمال می‌نماید.

[IDuotone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iduotone/) دارای دو پارامتر رنگی مستقل و قابل ویرایش است: `color1` رنگ پیکسل‌های تاریک و `color2` رنگ پیکسل‌های روشن را تعیین می‌کند. این مثال نشان‌دهندهٔ یک اثر با تنظیمات پیچیده‌تر از یک مقدار اسکالر منفرد است.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از [addColorChangeEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) است که یک رنگ مبدأ را به رنگ مقصد دیگری نگاشت می‌کند و هر دو قالب رنگ مبدأ و مقصد را در دسترس می‌گذارد.

## **اضافه‌کردن تارشدگی، شفافیت و اثرهای آلفا**

[addBlurEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) تمام کانال‌های رنگی از جمله آلفا را تحت تأثیر قرار می‌دهد. وقتی لبهٔ تار شده ممکن است خارج از مرزهای اصلی تصویر گسترش یابد، `grow` را روی `true` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) استفاده کنید. این اثر مقدار آلفای موجود هر پیکسل را ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف نسبتاً متفاوت می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) به‌جای آن یک مقدار آلفا واحد را به همه پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) آلفا را بر پایهٔ یک آستانه به دو سطح تبدیل می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سایر عملیات آلفای بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) است که هر آلفای غیرصفر را کاملاً نامشخص می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) که هر آلفا زیر 100٪ را کاملاً شفاف می‌سازد؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) که آلفا را به `100% - alpha` تبدیل می‌کند.

## **ساخت زنجیرهٔ اثرات مرتب**

هر متد `add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرکننده مجموعه را به‌عنوان یک خط لولهٔ مرتبی استفاده می‌کند: خروجی عملیات 0 به‌عنوان ورودی عملیات 1 و به همین ترتیب. بنابراین، یکسان بودن عملیات‌ها اما ترتیب متفاوت می‌تواند تصویر متفاوتی تولید کند.

به‌عنوان مثال، ابتدا خاکستری و سپس رنگ‌پراست باعث حذف اطلاعات رنگی و سپس رنگ‌آمیزی مجدد نتیجهٔ روشنایی می‌شود. اگر ابتدا رنگ‌پراست و سپس خاکستری اعمال شود، رنگ‌پراست دوباره حذف می‌شود. به‌طور مشابه، جایگزینی آلفا می‌تواند مقدارهای آلفای محاسبه‌شده توسط عملیات‌های قبلی را نادیده بگیرد، در حالی که تعدیل آلفا اختلافات نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار‑عملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را باز می‌کند، هم نوع عملیات‌ها و هم ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ باز شده را رندر می‌نماید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

مجموعه محدودیتی اعمال نمی‌کند که عملیات‌های رنگ، آلفا و تارشدگی را فقط به زنجیره‌های جداگانه محدود کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. جایگزینی رنگ ثابت، تنوع RGB تولیدشده توسط اثرهای رنگی قبلی را حذف می‌کند؛ خاکستری پس از دو‑تن، دو رنگ انتخاب‌شده را حذف می‌کند؛ و عملیات‌های آلفا سقف، کف، جایگزینی یا دو‑سطح می‌توانند جزئیات آلفا ایجادشده‌ی پیشین را از بین ببرند. زنجیره را بر پایهٔ توالی پردازش موردنظر پیکسل‌ها بسازید نه به‌عنوان پرچم‌های قالب‌بندی نامرتب.

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش شیء‌ایست که در `ISlidesPicture.getImageTransform` ذخیره می‌شود. بسته به اثر، ممکن است اعضای قابل نوشتن را مستقیماً نمایش دهد. به‌عنوان مثال، [IBlur](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iblur/) مقادیر نوشتنی `radius` و `grow` را در اختیار می‌گذارد، [IAlphaModulateFixed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ialphamodulatefixed/) مقدار نوشتنی `amount` را نشان می‌دهد و [IAlphaBiLevel](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ialphabilevel/) مقدار نوشتنی `threshold` را در دسترس می‌گذارد. اثرهای رنگی مانند [IDuotone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iduotone/) اشیای [IColorFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorformat/) قابل تغییر را ارائه می‌دهند.

برخی رابط‌های عملیات، شامل [IBrightnessContrast](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihsl/)، [ITint](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itint/) و [IAlphaReplace](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ialphareplace/)، اسکالرهای سازنده خود را به‌عنوان ویژگی‌های نوشتنی نمایش نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و جایگزینی در موقعیت موردنظر اضافه کنید.

داده‌های مؤثر بازگردانده‌شده توسط `getEffective()` محاسبه‌شده و فقط‑خواندنی هستند. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرکننده استفاده می‌کند مفید هستند، اما سطح ویرایش دیگری نیستند. مثال زیر زنجیره را مرور می‌کند و مقادیر مؤثر را در جایی که API متناظر آن‌ها را فراهم می‌کند، بازرسی می‌نماید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

اثرهای بدون پارامتر مانند خاکستری، آلفا سقف و آلفا معکوس نیز یک شیء دادهٔ مؤثر دارند، اما مقادیر اسکالر برای چاپ وجود ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) برای حذف یک عملیات بر اساس شاخص استفاده کنید. چون شاخص‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و پس از مرور حذف کنید. برای حذف کل زنجیره از [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [IPPImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ippimage/) استفاده‌شده را حذف، فشرده‌سازی یا به‌طور دیگری تغییر نمی‌دهد.

## **در نظر گرفتن فرمت‌های ارائه و مقصدهای خروجی**

تبدیل‌های تصویر در DrawingML ریشه دارند، بنابراین PPTX قالب ویرایشی ترجیحی برای زنجیره‌های اثر است. حتی در PPTX نیز همهٔ عملیات‌ها قابل حمل یکسان نیستند:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های رایج آلفا بهترین شانس بقا در یک دور‑دوم PPTX را دارند. همیشه فایل تولیدشده را باز کنید و مجموعه را هنگام نیاز به حفظ بررسی کنید.
- [BrightnessContrast](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد luminance DrawingML. می‌تواند برای رندر در حافظه استفاده شود، اما پس از ذخیره و باز کردن PPTX تضمین نمی‌شود که به‌صورت [IBrightnessContrast](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibrightnesscontrast/) قابل ویرایش بماند. برای تنظیمات دائمی روشنایی و کنتراست، از [addLuminanceEffect](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) استفاده کنید.
- فرمت باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT ممکن است عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. برای یک زنجیرهٔ پیچیدهٔ قابل ویرایش از PPT به‌عنوان قالب تأیید استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های بصری دیگر، زنجیرهٔ پشتیبانی‌شده را روی ظاهر رندر شده اعمال می‌کند. این خروجی‌ها شامل یک [IImageTransformOperationCollection] قابل ویرایش نیستند؛ فرمت‌های رستر نتیجه را به پیکسل‌ها تبدیل می‌کنند و خروجی‌های سند/وکتور نمایش رندر خود را ذخیره می‌کنند.
- اثرها تصویر پیوست شده را خودکار تجزیه‌پذیر نمی‌سازند. رندر یک تصویر پیوست‌شده هنوز به در دسترس بودن منبع پیوست‌شده هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌صورت متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کوانت‌سازی ترکیب شده باشند. برای خروجی‌های بحرانی، دور‑دوم ویرایشی و فرمت نهایی صادرات را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **FAQ**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر توکار را تغییر می‌دهند؟**

خیر. این عملیات‌ها به `ISlidesPicture` متعلق هستند که توسط پر کردن تصویر استفاده می‌شود. بایت‌های زمینه‌ای `IPPImage` دست‌نخورده می‌مانند.

**آیا دو فریم تصویری که از یک تصویر استفاده می‌کنند اثرهای یکدیگر را به‌اشتراک می‌گذارند؟**

خیر. استفاده مجدد از یک `IPPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر فریم تصویری معمولاً یک `ISlidesPicture` و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، تارشدگی و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. عملکرد هر عملیات بر خروجی قبلی تأثیر می‌گذارد؛ به‌خصوص عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای پیشین را از بین ببرند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را در جایی که اعضای نوشتنی وجود دارند ویرایش کنید؛ در غیر این‌صورت آن را حذف کنید و با پارامترهای جدید جایگزین کنید.

**برای حفظ یک زنجیرهٔ تبدیل، کدام قالب را باید استفاده کنم؟**

از PPTX استفاده کنید و فایل را با باز کردن مجدد تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و فرمت‌های خروجی رندری ظاهر را حفظ می‌کنند نه عملیات‌های تبدیل قابل ویرایش.