---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با جاوا
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/java/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- خاکستری
- دو-تن
- رنگ‌پرتو
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "اعمال، زنجیره‌بندی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای جاوا."
---
## **نمای کلی**

Aspose.Slides تنظیمات تصویر را به عنوان یک مجموعهٔ مرتب از عملیات تبدیل تصویر ارائه می‌دهد. برای یک فریم تصویر، با فریم ‎[ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/)‎ شروع کنید و به ‎[ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/#getImageTransform--)‎ دسترسی پیدا کنید. ‎[IImageTransformOperationCollection](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/)‎ برگردانده‌شده به شما امکان اضافه‌کردن، پیمایش، بازرسی، حذف و پاک‌سازی اثرها را بدون بازنویسی بایت‌های تصویر اصلی می‌دهد.

این مقاله یک جریان کاری کامل برای روشنایی و کنتراست، تبدیل‌های رنگ، تار شدن، شفافیت، زنجیرهٔ اثرات مرتب، مقادیر مؤثر، حذف و تأیید دور‌گردی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفاده مجدد تصویر**

یک منبع تصویر و تصویر نمایش داده‌شده آن اشیاء متفاوتی هستند:

- ‎[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‎ داده‌های منبع تصویر را که متعلق به ارائه است ذخیره یا مرجع می‌کند.
- ‎[ISlidesPicture](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/)‎ متعلق به پرکنندهٔ تصویر است و به منبع تصویر ارجاع می‌دهد در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- ‎[IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/)‎ شکل اسلاید است که پرکنندهٔ تصویر مرتبط، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را در اختیار دارد.

بنابراین، عملیات تبدیل تصویر بایت‌های ‎[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‎ را تغییر نمی‌دهند. وقتی همان ‎`IPPImage`‎ بیش از یک بار به ‎[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-)‎ داده شود، هر فریم تصویر جدید ‎`ISlidesPicture`‎ خود و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال رنگ‌خاکستری به یک فریم، فریم‌های دیگر را خاکستری نمی‌کند، حتی اگر همهٔ آن‌ها از همان منبع تصویر جاسازی‌شده استفاده کنند.

مدل ‎`ISlidesPicture.getImageTransform`‎ مشابه در پرکننده‌های تصویری دیگر مانند شکل یا پس‌زمینهٔ اسلاید نیز استفاده می‌شود. مثال‌های زیر بر فریم‌های تصویر متمرکز هستند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامتر**

روش‌های نشان داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگهدارید؛ فرمت هدف ارائه ممکن است داده‌های نامعتبر را هنگام ذخیره یا باز کردن در PowerPoint نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازهٔ معتبر و واحد |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` تا `100` درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | None | پارامتر عددی ندارد. آلفا بدون تغییر می‌ماند. |
| [addDuotoneEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | دو رنگ برای پیکسل‌های تیره و روشن. مقادیر کانال‌های RGB و آلفا در ‎`java.awt.Color`‎ از `0` تا `255`. |
| [addTintEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | `hue` از `0` شامل تا `360` غیردار، بر حسب درجه؛ `amount` از `-100` تا `100` درصد. |
| [addHSLEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | `hue` از `0` شامل تا `360` غیردار، بر حسب درجه؛ `saturation` و `luminance` از `-100` تا `100` درصد. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | رنگ جایگزین مقادیر کانال از `0` تا `255` استفاده می‌کند. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | شعاع غیر منفی و بر حسب پوینت؛ `grow` یک Boolean است که تعیین می‌کند آیا محتوی تار شده می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | درصد غیر منفی. برای مقیاس‌گذاری شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` تا `100` درصد شفافیت. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` تا `100` درصد آستانهٔ آلفا. مقادیر زیر آن شفاف می‌شوند؛ مقادیر برابر یا بالای آن مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگرند. برای مثال، 35٪ شفافیت متناظر با مقدار مدولاسیون آلفا 65٪ است.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) یک عملیات ‎[IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)‎ برمی‌گرداند. تنظیمات اسکالار آن هنگام ایجاد عملیات فراهم می‌شود. ‎[BrightnessContrast.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/#getEffective--)‎ مقادیر فقط‑خواندنی محاسبه‌شده را برمی‌گرداند که می‌توان آن‌ها را بازرسی یا ثبت کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد و سپس پیش‌نمایشی بدون تغییر تصویر جاسازی‌شده رندر می‌کند:

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

[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/) یک افزونهٔ اثر تصویر Office 2010 است و نسبت به اثر نورپذیری استاندارد DrawingML کم‌قابل‌حمل است. وقتی که روشنایی و کنتراست باید پس از یک دور‌گردی PPTX قابل ویرایش باقی بمانند، از ‎[IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)‎ استفاده کنید و پس از باز کردن مجدد فایل نتیجه را تأیید کنید. بخش محدودیت‌های فرمت این تفاوت را با جزئیات بیشتر توضیح می‌دهد.

## **اعمال تبدیل‌های رنگ**

اثرهای رنگ می‌توانند به طور مستقل بر فریم‌های تصویری مختلفی که یک منبع تصویر را استفاده می‌کنند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب رنگ‌خاکستری، دو‑تن، رنگ‌پرتو، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/) دو پارامتر رنگی مستقل قابل ویرایش دارد: `color1` پیکسل‌های تاریک و `color2` پیکسل‌های روشن را نگاشت می‌کند. این باعث می‌شود که مثال مفیدی برای اثر با تنظیمات پیچیده‌تر از یک مقدار اسکالار باشد.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) تمام پیکسل‌های تصویر را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از ‎[addColorChangeEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--)‎ است که یک رنگ منبع را به رنگ دیگر نگاشت می‌کند و فرمت‌های رنگ منبع و هدف را در دسترس می‌گذارد.

### **اعمال آستانهٔ نورپذیری**

یک آستانهٔ نورپذیری می‌تواند علامت‌های کم‌رنگ روی صفحهٔ اسکن‌شده را از پس‌زمینه متمایزتر کند. ‎[addGrayScaleEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--)‎ درجات میانی خاکستری را حفظ می‌کند. ‎[addBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-)‎ نورپذیری را به سیاه یا سفید نگاشت می‌کند، در حالی که ‎[addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-)‎ آستانه‌ای بر شفافیت اعمال می‌کند.

آستانهٔ نورپذیری از 0٪ تا 100٪، شامل هر دو انتها، متغیر است. پیکسل‌های زیر آستانه سیاه می‌شوند. پیکسل‌های برابر یا بالای آستانه سفید می‌شوند. افزایش آستانه باعث می‌شود که درجات بیشتری به سیاه تبدیل شوند چون بیشتر آن‌ها زیر حد قطع قرار می‌گیرند.

فایل ‎[grayscale-swatches.png](grayscale-swatches.png)‎ را در پوشهٔ کاری دانلود کنید. هر برچسب سطح خاکستری اصلی را روی مقیاس 0 تا 255 نشان می‌دهد. مثال اصلی را کنار دو نسخهٔ کپی قرار می‌دهد و آستانه هر کپی را در ارائه ذخیره می‌کند.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] imageData = Files.readAllBytes(Paths.get("grayscale-swatches.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

ارائهٔ خروجی را در PowerPoint باز کنید تا سه فریم را با هم مقایسه کنید. سواچ علامت‌دار 96 حدود 38٪ نورپذیری (96 از 255) دارد. در آستانهٔ 20٪ سفید می‌شود و در آستانهٔ 60٪ سیاه.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **افزودن تاری، شفافیت و اثرات آلفا**

[addBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-)‎ تمام کانال‌های رنگی شامل آلفا را تحت تاثیر قرار می‌دهد. وقتی لبهٔ تاری ممکن است خارج از مرزهای تصویر اصلی گسترش یابد، ‎`grow`‎ را به ‎`true`‎ تنظیم کنید.

برای شفافیت یکنواخت، از ‎[addAlphaModulateFixedEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-)‎ استفاده کنید. این اثر مقدار آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های جزئی‌شفاف به نسبت متفاوت می‌مانند. ‎[addAlphaReplaceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-)‎ به‌جای آن یک مقدار آلفا واحد را به تمام پیکسل‌ها اختصاص می‌دهد. ‎[addAlphaBiLevelEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-)‎ آلفا را به دو سطح بر اساس آستانه تبدیل می‌کند.

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

سایر عملیات آلفای بدون پارامتر شامل ‎[addAlphaCeilingEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--)‎ است که هر آلفای غیر صفر را کاملاً مات می‌کند؛ ‎[addAlphaFloorEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--)‎ که هر آلفای زیر 100٪ را کاملاً شفاف می‌کند؛ و ‎[addAlphaInverseEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--)‎ که آلفا را به ‎`100% - alpha`‎ تغییر می‌دهد.

## **ساخت زنجیرهٔ اثرات مرتب**

هر متد ‎`add...Effect`‎ یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرکننده مجموعه را به عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 ورودی عملیات 1 می‌شود و به همین ترتیب. بنابراین، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به عنوان مثال، اعمال رنگ‌خاکستری سپس رنگ‌پرتو ابتدا اطلاعات رنگی را حذف می‌کند و سپس روشنایی نتیجه را رنگ‌گذاری می‌کند. برعکس، رنگ‌پرتو سپس رنگ‌خاکستری رنگ‌پرتو را دوباره حذف می‌کند. به همان ترتیب، جایگزینی آلفا می‌تواند مقادیر آلفای محاسبه‌شده توسط عملیات‌های قبلی را بازنویسی کند، در حالی که مدولاسیون آلفا اختلافات نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار‑عملیاتی می‌سازد، آن را به صورت PPTX ذخیره می‌کند، ارائه را دوباره باز می‌کند، هر دو نوع عملیات و ترتیبشان را بررسی می‌کند و نتیجهٔ باز شده را رندر می‌کند:

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

مجموعه زنجیرهٔ سازگاری ماتریسی اعمال نمی‌کند که عملیات رنگ، آلفا و تاری را به زنجیره‌های جداگانه محدود کند. می‌توان آن‌ها را ترکیب کرد، اما ترکیب‌ها همیشه مفید نیستند. جایگزینی رنگ ثابت تغییرات RGB تولید‌شده توسط اثرات رنگ قبلی را از بین می‌برد؛ رنگ‌خاکستری پس از دو‑تن دو رنگ انتخاب‌شده را حذف می‌کند؛ و عملیات‌های سقف، کف، جایگزینی یا دو‑سطحی آلفا می‌توانند جزئیات آلفایی ایجاد‌شده قبلی را حذف کنند. زنجیره را بر اساس توالی پردازش پیکسل دلخواه بسازید نه به عنوان پرچم‌های قالب‌بندی نامرتب.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*در این رندر Aspose.Slides for .NET 26.11، یک رنگ‌پرتو 220° با 25٪ تصویر خاکستری را تغییری نمی‌دهد. اعمال همان رنگ‌پرتو قبل از رنگ‌خاکستری نتایج با تن‌های متفاوتی می‌دهد.*
<!-- visual-explanation:image-transform-effects:end -->

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش شیء ذخیره‌شده در ‎`ISlidesPicture.getImageTransform`‎ است. بسته به اثر، ممکن است اعضای قابل نوشتن را مستقیماً افشا کند. برای مثال، ‎[IBlur](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/)‎ مقادیر ‎`radius`‎ و ‎`grow`‎ قابل نوشتن را در اختیار می‌گذارد، ‎[IAlphaModulateFixed](https://reference.aspose.com/slides/java/com.aspose.slides/ialphamodulatefixed/)‎ مقدار ‎`amount`‎ را افشا می‌کند، و ‎[IAlphaBiLevel](https://reference.aspose.com/slides/java/com.aspose.slides/ialphabilevel/)‎ مقدار ‎`threshold`‎ را. اثرهای رنگی مانند ‎[IDuotone](https://reference.aspose.com/slides/java/com.aspose.slides/iduotone/)‎ شیء ‎[IColorFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/)‎ قابل تغییر را نشان می‌دهند.

برخی از رابط‌های عملیات، از جمله ‎[IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)‎، ‎[IHSL](https://reference.aspose.com/slides/java/com.aspose.slides/ihsl/)‎، ‎[ITint](https://reference.aspose.com/slides/java/com.aspose.slides/itint/)‎ و ‎[IAlphaReplace](https://reference.aspose.com/slides/java/com.aspose.slides/ialphareplace/)‎، اسکالارهای ایجادشان را به عنوان ویژگی‌های قابل نوشتن افشا نمی‌کنند. برای تغییر این تنظیمات، عملیات را حذف کنید و جایگزینی در موقعیت مورد نیاز اضافه کنید.

داده‌های مؤثر برگشت‌خورده توسط ‎`getEffective()`‎ محاسبه‌شده و فقط‑خواندنی هستند. برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌شده‌ای که رندرکننده استفاده می‌کند مفید است، اما سطح ویرایش دیگری نیست. مثال زیر زنجیره را پیمایش می‌کند و مقادیر مؤثر را در جایی که API مربوطه آن‌ها را فراهم می‌کند، بازرسی می‌کند:

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

اثرهای بدون پارامتر مانند رنگ‌خاکستری، سقف آلفا و معکوس آلفا همچنان یک شیء دادهٔ مؤثر دارند، اما تنظیمات اسکالاری برای چاپ وجود ندارند. حضور و موقعیت آن‌ها در مجموعه اطلاعات مهم است.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از ‎[IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-)‎ برای حذف یک عملیات به حسب شاخص استفاده کنید. چون شاخص‌ها پس از حذف تغییر می‌کنند، ابتدا هدف را جستجو کنید و پس از پیمایش آن را حذف کنید. برای حذف کل زنجیره از ‎[ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/imagetransformoperationcollection/#clear--)‎ استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع ‎[IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/)‎ استفاده‑شده را حذف، فشرده‌سازی یا به‌طور دیگری تغییر نمی‌دهد.

## **در نظر گرفتن فرمت‌های ارائه و مقاصد خروجی**

تبدیل‌های تصویر از DrawingML منشأ می‌گیرند، بنابراین PPTX فرمت قابل ویرایش ترجیحی برای زنجیره‌های اثر است. حتی در PPTX نیز همهٔ عملیات‌ها قابلیت‌پذیری یکسانی ندارند:

- عملیات‌های استاندارد DrawingML مانند نورپذیری، رنگ‌خاکستری، دو‑تن، رنگ‌پرتو، HSL، تاری و عملیات‌های عمومی آلفا بهترین شانس برای بقا پس از یک دور‌گردی PPTX را دارند. همیشه فایل تولیدشده را باز کنید و مجموعه را هنگام نیاز به حفظ، بررسی کنید.
- ‎[BrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/brightnesscontrast/)‎ یک افزونهٔ Office 2010 است نه عملیات استاندارد نورپذیری DrawingML. می‌تواند برای رندر در حافظه استفاده شود، اما پس از ذخیره و باز کردن PPTX تضمین نمی‌شود که هنوز به عنوان ‎[IBrightnessContrast](https://reference.aspose.com/slides/java/com.aspose.slides/ibrightnesscontrast/)‎ قابل ویرایش باقی بماند. برای تنظیمات پایدار روشنایی و کنتراست، ‎[addLuminanceEffect](https://reference.aspose.com/slides/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-)‎ را ترجیح دهید.
- فرمت باینری PPT پیش از مدل کامل اثر DrawingML وجود داشته است. ذخیره به PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعهٔ پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. از PPT به عنوان فرمت تأیید برای زنجیرهٔ پیچیده قابل ویرایش استفاده نکنید.
- خروجی‌های تصویری مانند PNG، JPEG، TIFF، PDF، SVG، HTML یا دیگر خروجی‌های بصری زنجیرهٔ پشتیبانی‌شده را بر ظاهر رندره‌شده اعمال می‌کنند. این خروجی‌ها مجموعهٔ ‎`IImageTransformOperationCollection`‎ قابل ویرایشی را شامل نمی‌شوند؛ فرمت‌های رستری نتیجه را به پیکسل‌ها مس flatten می‌کنند و صادرات اسناد/برداری نمایهٔ رندر خودشان را ذخیره می‌کنند.
- اثرها یک تصویر پیوندی را خودکفا نمی‌کنند. رندر یک تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد مرزی را به‌صورت متفاوتی رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا رنگ‑کوانتایزینگ ترکیب می‌شوند. برای خروجی‌های بحرانی، هر دو دور‌گردی قابل ویرایش و فرمت صادرات نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، آزمایش کنید.

## **سوالات متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویری جاسازی‌شده را تغییر می‌دهند؟**

نه. این عملیات‌ها متعلق به ‎`ISlidesPicture`‎ استفاده‌شده توسط پرکنندهٔ تصویر هستند. بایت‌های زیرین ‎`IPPImage`‎ بدون تغییر می‌مانند.

**آیا دو فریم تصویری که از یک تصویر استفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. استفادهٔ مجدد یک ‎`IPPImage`‎ داده‌های تصویر تکراری را جلوگیری می‌کند، اما هر فریم تصویر معمولاً یک ‎`ISlidesPicture`‎ و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ مرتب می‌پذیرد. به این توجه داشته باشید که هر عملیات بر خروجی عملیات قبلی چه می‌کند، چون عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، شامل رنگ‌های حل‑شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید جایی که اعضای قابل نوشتن وجود دارد؛ در غیر این‌صورت آن را حذف کنید و با پارامترهای ایجاد جدید جایگزین کنید.

**کدام فرمت را باید برای حفظ زنجیرهٔ تبدیل استفاده کنم؟**

از PPTX استفاده کنید و فایل را با باز کردن مجدد تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و فرمت‌های صادراتی رندر شده فقط ظاهر را حفظ می‌کنند، نه عملیات‌های تبدیل قابل ویرایش.