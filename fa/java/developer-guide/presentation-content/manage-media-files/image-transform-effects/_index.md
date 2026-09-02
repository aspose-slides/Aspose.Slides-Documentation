---  
title: مدیریت افکت‌های تبدیل تصویر در ارائه‌ها با جاوا  
linktitle: افکت‌های تبدیل تصویر  
type: docs  
weight: 11  
url: /fa/java/image-transform-effects/  
keywords:  
- تبدیل تصویر  
- افکت تصویر  
- روشنایی  
- کنتراست  
- سایه‌خاکستری  
- دو رنگی  
- رنگ‌سایه  
- HSL  
- جایگزینی رنگ  
- تاری  
- شفافیت  
- افکت آلفا  
- زنجیره افکت  
- PowerPoint  
- ارائه  
- جاوا  
- Aspose.Slides  
description: "اعمال، زنجیره‌سازی، بررسی، حذف و تأیید افکت‌های تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای جاوا."  
---
## **نمای کلی**

Aspose.Slides تنظیمات تصویر را به‌صورت مجموعه‌ای ترتیبی از عملیات تبدیل تصویر نمایش می‌دهد. برای یک فریم تصویر، با [ISlidesPicture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/) فریم شروع کنید و به [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/#getImageTransform--) دسترسی پیدا کنید. مجموعه‌ی بازگشتی [IImageTransformOperationCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/) به شما اجازه می‌دهد تا بدون بازنویسی بایت‌های اصلی تصویر، اثرها را اضافه، بررسی، حذف و پاک‌سازی کنید.

این مقاله یک جریان کاری کامل برای تنظیم روشنایی و کنتراست، تبدیل رنگ‌ها، تاری، شفافیت، زنجیره‌های اثر ترتیبی، مقدارهای مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و بازاستفاده تصویر**

یک منبع تصویر و تصویر نمایش‌دهنده آن دو شیء متفاوت هستند:

- [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) داده‌های تصویر منبع را که متعلق به ارائه است، ذخیره یا ارجاع می‌دهد.
- [ISlidesPicture](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidespicture/) به یک پر کردن تصویر تعلق دارد و به منبع تصویر ارجاع می‌کند در حالی که مجموعه‌ی تبدیل تصویر را ذخیره می‌کند.
- [IPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipictureframe/) شکل اسلاید است که پر کردن تصویر، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را دارا است.

به‌این‌ترتیب، عملیات‌های تبدیل تصویر بایت‌های [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) را تغییر نمی‌دهند. وقتی همان `IPPImage` بیش از یک بار به [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) پاس داده شود، هر فریم تصویر جدید `ISlidesPicture` و مجموعه‌ی تبدیل خود را دریافت می‌کند. اعمال مقیاس خاکستری به یک فریم، فریم‌های دیگر را خاکستری نمی‌کند، حتی اگر همه‌ی آن‌ها از همان منبع تصویر تعبیه‌شده استفاده کنند.

مدل `ISlidesPicture.getImageTransform` در پر کردن‌های تصویر دیگر نیز به کار می‌رود، مانند پر کردن یک شکل یا پس‌زمینه اسلاید. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

روش‌های نشان‌داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخه‌ی خاصی از کتابخانه هر مقدار نامعتبر را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب هدف ممکن است داده‌های نامعتبر را هنگام ذخیره یا باز کردن فایل توسط PowerPoint نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه و واحد معتبر |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | بدون پارامتر عددی. آلفا بدون تغییر می‌ماند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر کانال‌های RGB و آلفا در `java.awt.Color` از `0` تا `255` هستند. |
| [addTintEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | `hue` از `0` به صورت شامل تا `360` به صورت منع شامل (درجه); `amount` از `-100` تا `100` درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | `hue` از `0` شامل تا `360` منع شامل (درجه); `saturation` و `luminance` از `-100` تا `100` درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | رنگ جایگزین مقادیر کانال از `0` تا `255` را استفاده می‌کند. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [addBlurEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | `radius` غیرمنفی و بر حسب نقطه است؛ `grow` یک Boolean است که تعیین می‌کند محتوای تاری می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | درصد غیرمنفی. برای مقیاس‌گذاری شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` تا `100` درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` تا `100` درصد آلفای آستانه. مقادیر زیر آن شفاف می‌شوند؛ مقادیر برابر یا بالای آن، مات می‌شوند. |

برای مدوله‌سازی ثابت آلفا، شفافیت و مات‌بودن مکمل یکدیگرند. به‌عنوان مثال، 35٪ شفافیت معادل مقدار مدوله‌سازی آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) یک عملیات [IBrightnessContrast](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibrightnesscontrast/) برمی‌گرداند. تنظیمات اسکالر آن هنگام ایجاد عملیات ارائه می‌شود. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) مقادیر محاسبه‌شده‌ی فقط‑خواندنی را که می‌توانند بررسی یا ثبت شوند، برمی‌گرداند.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد و سپس پیش‌نمایشی رندر می‌کند بدون اینکه تصویر تعبیه‌شده را تغییر دهد:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/fa/java/com.aspose.slides/brightnesscontrast/) یک افزونه‌ی افکت تصویر Office 2010 است و نسبت به افکت روشنایی استاندارد DrawingML قابلیت‌پرتابلی کمتری دارد. هنگامی که روشنایی و کنتراست باید پس از یک دورانی PPTX ویرایش‌پذیر بمانند، از [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) استفاده کنید و نتیجه را پس از بازکردن مجدد فایل تأیید کنید. بخش محدودیت‌های قالب این تفاوت را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

افکت‌های رنگی می‌توانند به‌صورت مستقل بر فریم‌های تصویر مختلفی که یک منبع تصویر را بازاستفاده می‌کنند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب خاکستری، دو‑رنگی، رنگ‌سایه، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[IDuotone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iduotone/) دو پارامتر رنگی مستقل و قابل ویرایش دارد: `color1` برای پیکسل‌های تاریک و `color2` برای پیکسل‌های روشن. این موضوع مثالی مفید از افکتی است که تنظیمات آن پیچیده‌تر از یک مقدار اسکالر واحد است.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) تمام رنگ پیکسل‌ها را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا حفظ می‌شود. این متفاوت از [addColorChangeEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--) است که یک رنگ منبع را به رنگ هدفی دیگر نگاشت می‌کند و هر دو قالب رنگ منبع و هدف را در دسترس قرار می‌دهد.

## **اضافه کردن تاری، شفافیت و افکت‌های آلفا**

[addBlurEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) تمام کانال‌های رنگی شامل آلفا را تحت تأثیر قرار می‌دهد. وقتی لبهٔ تاری می‌تواند خارج از مرزهای اصلی تصویر گسترش یابد، `grow` را `true` تنظیم کنید.

برای شفافیت یکنواخت، از [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) استفاده کنید. این اثر همه مقدارهای آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‑شفاف به نسبت متفاوت می‌مانند. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) به‌جای آن یک مقدار آلفا را به همه پیکسل‌ها اختصاص می‌دهد. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) آلفا را بر پایه آستانه‌ای به دو سطح تبدیل می‌کند.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

سایر عملیات آلفای بدون پارامتر شامل [addAlphaCeilingEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) است که هر آلفای غیرصفری را کاملاً مات می‌کند؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) که هر آلفا زیر 100٪ را کاملاً شفاف می‌کند؛ و [addAlphaInverseEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثر ترتیبی**

هر متد `add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرکننده مجموعه را به‌عنوان یک خط لولهٔ ترتیبی استفاده می‌کند: خروجی عملیات 0 تبدیل به ورودی عملیات 1 می‌شود و به همین ترتیب. بنابراین، اجرای همان عملیات‌ها به ترتیب متفاوت می‌تواند تصویر متفاوتی تولید کند.

به‌عنوان مثال، خاکستری کردن سپس رنگ‌سایه ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را دوباره رنگ‌آمیزی می‌کند. رنگ‌سایه سپس خاکستری کردن، رنگ‌سایه را دوباره از بین می‌برد. به‌ طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را بازنویسی کند، در حالی که مدوله‌سازی آلفا نسبت‌های نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار‑عملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را باز می‌کند، هر دو نوع عملیات و ترتیب آن‌ها را بررسی می‌کند و نتیجه باز‑بازکرده را رندر می‌کند:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

مجموعه محدودیتی در ماتریس سازگاری اعمال نمی‌کند که عملیات‌های رنگ، آلفا و تاری را به زنجیره‌های جداگانه محدود کند. آن‌ها می‌توانند ترکیب شوند، هرچند همیشه ترکیب‌های مفیدی نیستند. جایگزینی رنگ ثابت تغییرات RGB تولیدشده توسط افکت‌های رنگی قبلی را حذف می‌کند؛ خاکستری پس از دو‑رنگی دو رنگ انتخاب‌شده را از بین می‌برد؛ و افکت‌های سقف، کف، جایگزینی یا دو‑سطحی آلفا می‌توانند جزئیات آلفای ایجادشده پیشتر را از بین ببرند. زنجیره را بر اساس توالی پردازش پیکسل موردنظر بسازید نه به‌عنوان پرچم‌های قالب‌بندی نامرتب.

## **مشاهده مقدارهای قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش همان شیئ ذخیره‌شده در `ISlidesPicture.getImageTransform` است. بسته به اثر، ممکن است اعضای قابل‌نوشتن را مستقیماً نشان دهد. به عنوان مثال، [IBlur](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iblur/) `radius` و `grow` قابل‌نوشتن را افشا می‌کند، [IAlphaModulateFixed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ialphamodulatefixed/) `amount` قابل‌نوشتن را نشان می‌دهد، و [IAlphaBiLevel](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ialphabilevel/) `threshold` قابل‌نوشتن را افشا می‌کند. افکت‌های رنگی مانند [IDuotone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iduotone/) شیء قابل‌نوشتن [IColorFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorformat/) را نمایان می‌کنند.

برخی رابط‌های عملیات، شامل [IBrightnessContrast](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihsl/)، [ITint](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itint/)، و [IAlphaReplace](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ialphareplace/)، اسکالرهای ایجاد خود را به‌عنوان ویژگی‌های قابل‌نوشتن افشا نمی‌کنند. برای تغییر این تنظیمات، عملیات را حذف کنید و یک جایگزین در موقعیت موردنظر اضافه کنید.

داده‌های مؤثر که توسط `getEffective()` برگردانده می‌شود محاسبه‌شده و فقط‑خواندنی هستند. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرکننده استفاده می‌کند مفید هستند، اما سطح ویرایش دیگری نیستند. مثال زیر زنجیره را پیمایش می‌کند و مقدارهای مؤثر را در جایی که API مربوطه آن‌ها را فراهم می‌کند، بررسی می‌نماید:

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

افکت‌های بدون پارامتر مانند خاکستری، سقف آلفا و معکوس آلفا همچنان یک شیء داده مؤثر دارند، اما اسکالر برای چاپ وجود ندارد. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) برای حذف یک عملیات بر پایه شاخص استفاده کنید. چون شاخص‌ها پس از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و پس از پیمایش آن را حذف کنید. برای حذف کل زنجیره از [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imagetransformoperationcollection/#clear--) استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [IPPImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ippimage/) استفاده‌شده را حذف، فشرده‌سازی یا به‌هر شکل دیگری تغییر نمی‌دهد.

## **در نظر گرفتن قالب‌های ارائه و مقصدهای خروجی**

تبدیل‌های تصویر از DrawingML منشأ می‌گیرند، بنابراین PPTX قالب ویرایش‌پذیر ترجیحی برای زنجیره‌های اثر است. حتی با PPTX، همه‌ی عملیات‌ها قابلیت‌پرتابلی یکسانی ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، grayscale، duotone، tint، HSL، blur و عملیات‌های رایج آلفا بهترین شانس برای بقا پس از یک دورانی PPTX را دارند. همیشه فایل تولیدشده را باز کنید و مجموعه را بررسی کنید وقتی حفظ آن ضروری است.
- [BrightnessContrast](https://reference.aspose.com/slides/fa/java/com.aspose.slides/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد luminance DrawingML. می‌تواند برای رندر در حافظه استفاده شود، اما پس از ذخیره و بازکردن PPTX به‌عنوان یک [IBrightnessContrast](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibrightnesscontrast/) ویرایش‌پذیر باقی نماند. برای تنظیمات پایدار روشنایی و کنتراست، از [addLuminanceEffect](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) استفاده کنید.
- قالب باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. برای تأیید یک زنجیرهٔ ویرایش‌پذیر پیچیده از PPT به‌عنوان قالب استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های تصویری دیگر زنجیره پشتیبانی‌شده را بر ظاهر رندر اعمال می‌کند. این خروجی‌ها یک `IImageTransformOperationCollection` ویرایش‌پذیر ندارند؛ قالب‌های رستری نتیجه را به پیکسل‌ها مسflatten می‌کند و صادرات‌های سند/بردار نمایشی خود را ذخیره می‌کنند.
- افکت‌ها یک تصویر پیوندی را خودکفا نمی‌سازند. رندر یک تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌صورت متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگی ترکیب می‌شوند. برای خروجی بحرانی، هر دو دورانی ویرایش‌پذیر و قالب خروجی نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **سؤالات متداول**

**آیا افکت‌های تبدیل تصویر داده‌های تصویر تعبیه‌شده را تغییر می‌دهند؟**

نه. عملیات‌ها به `ISlidesPicture` متعلق هستند که توسط پر کردن تصویر استفاده می‌شود. بایت‌های زیرین `IPPImage` بدون تغییر می‌مانند.

**آیا دو فریم تصویر که از همان تصویر استفاده می‌کنند، افکت‌های یکسانی دارند؟**

نه. استفاده مجدد از یک `IPPImage` از تکرار داده‌های تصویر جلوگیری می‌کند، اما هر فریم تصویر معمولاً `ISlidesPicture` و مجموعه تبدیل تصویر جداگانه‌ای دارد.

**آیا می‌توان افکت‌های رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ ترتیبی می‌پذیرد. توجه کنید هر عملیات چه تاثیری بر خروجی عملیات قبلی دارد چون عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقدارهای مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید وقتی ویژگی‌های قابل‌نوشتنی وجود دارد؛ در غیر این‌صورت آن را حذف کنید و با پارامترهای جدید جایگزین کنید.

**کدام قالب برای حفظ زنجیرهٔ تبدیل توصیه می‌شود؟**

از PPTX استفاده کنید و فایل را پس از ذخیره باز کنید تا تأیید شود. PPT کلاسیک نمی‌تواند مدل کامل افکت DrawingML را نشان دهد و قالب‌های خروجی رندر فقط ظاهر را حفظ می‌کنند، نه عملیات‌های تبدیل ویرایش‌پذیر.