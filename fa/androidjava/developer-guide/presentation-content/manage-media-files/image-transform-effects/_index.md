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
- خاکستری
- دو‑رنگ
- رنگ‌پراهمی
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بررسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای اندروید از طریق جاوا."
---
## **مروری کلی**

Aspose.Slides تنظیمات تصویر را به عنوان یک مجموعه مرتب از عملیات تبدیل تصویر نمایش می‌دهد. برای یک فریم تصویر، از [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) شروع کنید و به [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--) دسترسی پیدا کنید. مجموعه بازگردانده شدهٔ [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) به شما امکان افزودن، شمارش، بازرسی، حذف و پاک‌سازی اثرها را بدون بازنویسی بایت‌های تصویر اصلی می‌دهد.

این مقاله یک گردش کار کامل برای روشنایی و کنتراست، تبدیل‌های رنگی، تاری، شفافیت، زنجیرهٔ اثرهای مرتب، مقادیر مؤثر، حذف و تأیید دورگرد PPTX را نشان می‌دهد.

## **درک مالکیت اثر و بازاستفادهٔ تصویر**

یک منبع تصویر و تصویر نمایانگر آن اشیاء متفاوتی هستند:

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) داده‌های تصویر منبع را که تحت مالکیت ارائه هستند ذخیره یا ارجاع می‌دهد.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) متعلق به پرکنندهٔ تصویر است و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) شکل اسلاید است که پرکنندهٔ تصویر، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را در اختیار دارد.

بنابراین عملیات تبدیل تصویر بایت‌های [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) را تغییر نمی‌دهد. وقتی همان `IPPImage` بیش از یک‌بار به [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) پاس داده شود، هر فریم تصویر جدید `ISlidesPicture` و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال حالت خاکستری به یک فریم، فریم‌های دیگر را به حالت خاکستری درنمی‌آورد، حتی اگر همه آن‌ها از همان منبع تصویر نهفته استفاده کنند.

مدل `ISlidesPicture.getImageTransform` همچنین توسط پرکننده‌های تصویری دیگر مانند شکل یا پس‌زمینهٔ اسلاید استفاده می‌شود. مثال‌های زیر برای فریم‌های تصویر تمرکز دارند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

روش‌های نشان داده شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه مقدار خارج از بازه را فوراً رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب هدف ممکن است داده‌های نامعتبر را هنگام ذخیره یا باز شدن فایل توسط PowerPoint نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه و واحد معتبر |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را تغییر نمی‌دهد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | بدون پارامتر عددی. آلفا تغییر نمی‌کند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر کانال RGB و آلفا توسط `android.graphics.Color` از `0` تا `255` هستند. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | `hue` از `0` به صورت شامل تا `360` به صورت غیرشامل، بر حسب درجه؛ `amount` از `-100` تا `100`، درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | `hue` از `0` شامل تا `360` به‌جز، بر حسب درجه؛ `saturation` و `luminance` از `-100` تا `100`، درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | رنگ جایگزین مقادیر کانال از `0` تا `255` دارد. مقادیر آلفای موجود تغییری نمی‌کند. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | `radius` غیر منفی و بر حسب پوینت اندازه‌گیری می‌شود؛ `grow` یک Boolean است که تعیین می‌کند محتوای محو‌شده ممکن است خارج از حاشیهٔ اصلی گسترش یابد. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | درصد غیر منفی. برای مقیاس‌گذاری معمولی شفافیت از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` تا `100`، درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` تا `100`، درصد آلفا. مقدارهای زیر این آستانه شفاف، مقدارهای برابر یا بالاتر مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگرند. به عنوان مثال، 35٪ شفافیت برابر است با مقدار مدولاسیون آلفا 65٪.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) یک عملیات [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) را برمی‌گرداند. تنظیمات اسکالر آن در زمان ایجاد عملیات تامین می‌شود. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را برمی‌گرداند که می‌توان آن‌ها را بررسی یا ثبت کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد، سپس پیش‌نمایشی بدون تغییر تصویر نهفته رندر می‌کند:

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

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) یک افزونهٔ اثر تصویر Office 2010 است و نسبت به اثر نوردهی استاندارد DrawingML قابلیت حمل کمتری دارد. هنگامی که روشنایی و کنتراست باید پس از یک دورگرد PPTX قابل ویرایش باقی بمانند، از [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) استفاده کنید و نتایج را پس از بازگشایی فایل تأیید کنید. بخش محدودیت‌های فرمت این تفاوت را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

اثرات رنگی می‌توانند به‌صورت مستقل روی فریم‌های تصویری مختلفی که یک منبع تصویر مشترک دارند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب اثرهای خاکستری، دو‑رنگ، رنگ‌پراهمی، تنظیم HSL و جایگزینی رنگ را اعمال می‌نماید.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) دو پارامتر رنگی مستقل و قابل ویرایش دارد: `color1` پیکسل‌های تاریک و `color2` پیکسل‌های روشن را نگاشت می‌کند. این باعث می‌شود مثال مفیدی برای اثری باشد که تنظیمات پیچیده‌تری نسبت به یک مقدار اسکالر دارد.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) است که یک رنگ مبدأ را به رنگ هدفی نگاشت می‌کند و هر دو قالب رنگ مبدأ و هدف را در اختیار می‌گذارد.

### **اعمال آستانهٔ نوردهی**

یک آستانهٔ نوردهی می‌تواند علامت‌های ضعیف روی صفحهٔ اسکن‌شده را از پس‌زمینه متمایز کند. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) سایه‌های میانی خاکستری را حفظ می‌کند. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) نوردهی را به سیاه یا سفید نگاشت می‌کند، در حالی که [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) آستانه‌ای بر شفافیت اعمال می‌نماید.

آستانهٔ نوردهی از 0٪ تا 100٪، شامل است. پیکسل‌های زیر آستانه سیاه می‌شوند. پیکسل‌های برابر یا بالای آستانه سفید می‌شوند. افزایش آستانه باعث سیاه شدن سایه‌های بیشتر می‌شود زیرا تعداد بیشتری از آن‌ها زیر حد قطع می‌افتند.

فایل [grayscale-swatches.png](grayscale-swatches.png) را در پوشهٔ کاری دانلود کنید. هر برچسب سطح خاکستری اصلی را بر مقیاس 0 تا 255 نشان می‌دهد. مثال اصلی را در کنار دو نسخهٔ کپی قرار می‌دهد و آستانهٔ هر کپی را در ارائه ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ارائه خروجی را در PowerPoint باز کنید تا سه فریم را مقایسه کنید. نمونهٔ 96 تقریباً 38٪ نوردهی (96 از 255) دارد. در آستانهٔ 20٪ سفید می‌شود و در آستانهٔ 60٪ سیاه.

![نمونهٔ خاکستری اصلی در کنار نتایج سیاه‑سفید در آستانه‌های نوردهی 20٪ و 60٪](luminance-threshold.png)

## **افزودن تاری، شفافیت و اثرهای آلفا**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) همهٔ کانال‌های رنگ را شامل می‌شود، از جمله آلفا. وقتی لبهٔ محو ممکن است فراتر از مرزهای تصویر اصلی گسترش یابد، `grow` را روی `true` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) استفاده کنید. این مقدار هر آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف نسبتاً متفاوت باقی می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) به‌جای آن یک مقدار آلفا واحد را به همهٔ پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) آلفا را بر اساس یک آستانه به دو سطح تبدیل می‌کند.

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

سایر عملیات آلفای بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) است که هر آلفای غیر صفر را کاملاً مات می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) که هر آلفای زیر 100٪ را کاملاً شفاف می‌سازد؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثرهای مرتب**

هر متد `add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرر مجموعه را به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 به عنوان ورودی عملیات 1 و به همین ترتیب. بنابراین، همان عملیات‌ها با ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به عنوان مثال، خاکستری‑کردن سپس رنگ‌پراهمی ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ نوردهی را رنگ‌گذاری می‌کند. رنگ‌پراهمی سپس خاکستری‑کردن رنگ‌پراهمی را دوباره حذف می‌کند. به همان ترتیب، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات قبلی را بازنویسی کند، در حالی که مدولاسیون آلفا تفاوت‌های نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار‑عملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را باز می‌گرداند، انواع عملیات و ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ بازگشایی‌شده را رندر می‌کند:

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

مجموعه محدودیتی بر ماتریس سازگاری که عملیات رنگ، آلفا و تاری را به زنجیره‌های جداگانه محدود می‌کند، اعمال نمی‌کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تغییرات RGB تولید شده توسط اثرهای رنگی قبلی را حذف می‌کند؛ خاکستری‑کردن پس از دو‑رنگ، دو رنگ انتخابی را از بین می‌برد؛ و عملیات‌های آلفا ceiling، floor، replacement یا bi‑level می‌توانند جزئیات آلفا ایجادشدهٔ قبلی را پاک کنند. زنجیره را بر اساس ترتیب پردازش پیکسل مورد نیاز بسازید نه به‌عنوان پرچم‌های قالب‌بندی بدون ترتیب.

<!-- visual-explanation:image-transform-effects:start -->
[![همان تصویر ابتدا از طریق خاکستری‑کردن سپس رنگ‌پراهمی، و سپس رنگ‌پراهمی ابتدا از طریق خاکستری‑کردن، دو تصویر نهایی خاکستری دارای رنگ‌های متفاوت هستند.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*در این رندر توضیحی Aspose.Slides for .NET 26.11، یک رنگ‌پراهمی 220° با 25٪ خاکستری‑کردن تصویر را تغییر نمی‌دهد. اعمال همان رنگ‌پراهمی قبل از خاکستری‑کردن رنگ‌های متفاوتی تولید می‌کند.*
<!-- visual-explanation:image-transform-effects:end -->

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش شیئی است که در `ISlidesPicture.getImageTransform` ذخیره می‌شود. بسته به اثر، ممکن است اعضای قابل نوشتن را مستقیماً نشان دهد. برای مثال، [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) مقادیر `radius` و `grow` قابل نوشتن را افشا می‌کند، [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) مقدار `amount` را نشان می‌دهد، و [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) مقدار `threshold` را افشا می‌کند. اثرهای رنگی مانند [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) اشیاء [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) قابل تغییر را ارائه می‌دهند.

برخی از رابط‌های عملیات، از جمله [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), و [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/)، مقادیر اسکالر ساخت خود را به‌عنوان ویژگی‌های قابل نوشتن نشان نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کرده و جایگزینی در موقعیت موردنظر اضافه کنید.

دادهٔ مؤثری که توسط `getEffective()` برگردانده می‌شود محاسبه‌شده و فقط‑خواندنی است. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرر استفاده می‌کند مفید است، اما یک سطح ویرایشی دیگر نیست. مثال زیر زنجیره را شمارش می‌کند و مقادیر مؤثر را در جایی که API موردنظر آن‌ها را فراهم می‌کند، بررسی می‌کند:

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

اثرهای بدون پارامتر مانند خاکستری‑کردن، آلفا ceiling و آلفا inverse همچنان دارای شیء دادهٔ مؤثر هستند، اما تنظیمات اسکالر برای چاپ ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم است.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) برای حذف یک عملیات برحسب اندیس استفاده کنید. چون اندیس‌ها پس از حذف تغییر می‌کنند، ابتدا هدف را جستجو کنید و سپس پس از شمارش حذف کنید. برای حذف کل زنجیره از [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. منبع تصویر [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) که بازاستفاده می‌شود را حذف، فشرده‌سازی یا تغییر دیگری نمی‌کند.

## **در نظر گرفتن قالب‌های ارائه و مقصدهای خروجی**

تبدیل‌های تصویر از DrawingML منشأ می‌گیرند، بنابراین PPTX قالب ویرایشی ترجیحی برای زنجیره‌های اثر است. حتی در PPTX، همهٔ عملیات‌ها قابل حملیت یکسانی ندارند:

- عملیات‌های استاندارد DrawingML مانند نوردهی، خاکستری‑کردن، دو‑رنگ، رنگ‌پراهمی، HSL، تاری و عملیات‌های رایج آلفا بیشترین شانس بقا در یک دورگرد PPTX را دارند. همیشه فایل تولیدشده را باز کنید و مجموعه را بررسی کنید وقتی حفظ اثر الزامی باشد.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عمل نوردهی استاندارد DrawingML. می‌توان از آن برای رندر در حافظه استفاده کرد، اما پس از ذخیره و بازگشایی PPTX تضمین نمی‌شود که به عنوان یک [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) قابل ویرایش باقی بماند. برای تنظیمات ثابت روشنایی و کنتراست، [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) را برگزینید.
- قالب باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT ممکن است عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به بخشی پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. از PPT به‌عنوان قالب تأیید برای زنجیرهٔ ویرایشی پیچیده استفاده نکنید.
- خروجی به PNG، JPEG، TIFF، PDF، SVG، HTML یا سایر فرمت‌های تصویری، زنجیرهٔ پشتیبانی‌شده را بر ظاهر رندر شده اعمال می‌کند. این خروجی‌ها شامل یک `IImageTransformOperationCollection` ویرایشی نیستند؛ فرمت‌های رستر نتیجه را به پیکسل‌ها تبدیل می‌کنند و صادرات اسناد/برداری نمایشی خود را ذخیره می‌کنند.
- اثرها تصویر پیوندی را به‌صورت خودکفا نمی‌سازند. رندر یک تصویر پیوندی همچنان به موجود بودن منبع پیوندی هنگام بارگذاری ارائه بستگی دارد.

مصرف‌کنندگان مختلف ارائه ممکن است پرونده‌های لبه‌ای را به‌صورت متفاوت رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کوانتایزینگ ترکیب شوند. برای خروجی حیاتی، هر دو دورگرد ویرایشی و قالب خروجی نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، آزمایش کنید.

## **سئوالات متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر نهفته را تغییر می‌دهند؟**

نه. عملیات‌ها به `ISlidesPicture` متعلق به پرکنندهٔ تصویر تعلق دارند. بایت‌های زیرین `IPPImage` دست نخورده می‌مانند.

**آیا دو فریم تصویر که همان تصویر را بازاستفاده می‌کنند، اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. بازاستفاده از یک `IPPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر فریم تصویر معمولاً `ISlidesPicture` و مجموعهٔ تبدیل تصویر جداگانه‌ای دارد.

**آیا می‌توان اثرهای رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. به اثر هر عملیات بر خروجی قبلی توجه کنید زیرا عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

دادهٔ مؤثر مقادیر محاسبه‌شده‌ای است که برای رندر استفاده می‌شود، از جمله رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را جایی که اعضای قابل نوشتن وجود دارد، ویرایش کنید؛ در غیر اینصورت آن را حذف کرده و با پارامترهای ساخت جدید جایگزین کنید.

**کدام قالب را برای حفظ زنجیرهٔ تبدیل استفاده کنم؟**

از PPTX استفاده کنید و فایل را با بازگشایی مجدد تأیید کنید. قالب PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و فرمت‌های خروجی رندر فقط ظاهر را حفظ می‌کنند، نه عملیات تبدیل ویرایشی.