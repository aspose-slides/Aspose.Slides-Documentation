---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با .NET
linktitle: اثرات تبدیل تصویر
type: docs
weight: 11
url: /fa/net/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- مقیاس‌سودگی خاکستری
- دو‑رنگی
- رنگ‌پرتو
- HSL
- جایگزینی رنگ
- تاری
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اعمال، زنجیره‌سازی، بازرسی، حذف و تأیید اثرهای تبدیل تصویر برای فریم‌های تصویر با Aspose.Slides برای .NET."
---
## **بررسی کلی**

Aspose.Slides تنظیمات تصویر را به‌عنوان یک مجموعهٔ مرتب از عملیات تبدیل تصویر ارائه می‌دهد. برای یک فریم تصویر، با فریمٔ [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) شروع کنید و به [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/imagetransform/) دسترسی پیدا کنید. مجموعهٔ بازگردانده‌شدهٔ [IImageTransformOperationCollection](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/) به شما اجازه می‌دهد تا اثرها را بدون بازنویسی بایت‌های تصویر اصلی، اضافه، مرور، بررسی، حذف و پاک کنید.

این مقاله یک جریان کار کامل برای تنظیم روشنایی و کنتراست، تبدیل رنگ‌ها، تار کردن، شفافیت، زنجیرهٔ اثرهای مرتب، مقادیر مؤثر، حذف و تأیید دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و استفادهٔ مجدد از تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد، اشیای متفاوتی هستند:

- [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) دادهٔ تصویر منبع را که متعلق به ارائه است، ذخیره یا به آن ارجاع می‌دهد.
- [ISlidesPicture](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/) به پرکنندهٔ تصویر تعلق دارد و به منبع تصویر اشاره می‌کند در حالی‌که مجموعهٔ تبدیل تصویر را نگه می‌دارد.
- [IPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ipictureframe/) شکل اسلاید است که پرکنندهٔ تصویر، هندسه، تنظیمات برش و سایر قالب‌بندی‌های سطح فریم را در اختیار دارد.

بنابراین، عملیات تبدیل تصویر بایت‌های موجود در [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) را تغییر نمی‌دهند. وقتی همان `IPPImage` بیش از یک بار به [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addpictureframe/) پاس داده می‌شود، هر فریم تصویری جدید یک `ISlidesPicture` و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال مقیاس‌سودگی خاکستری به یک فریم، فریم‌های دیگر را مقیاس‌سودگی نمی‌کند، حتی اگر همهٔ آن‌ها از همان منبع تصویر جاسازی‌شده استفاده کنند.

مدل `ISlidesPicture.ImageTransform` مشابه همچنین توسط پرکننده‌های تصویر دیگر، مانند شکل یا پس‌زمینه اسلاید، استفاده می‌شود. مثال‌های زیر بر فریم‌های تصویر تمرکز دارند.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

روش‌های نشان داده‌شده بازه‌ها و واحدهای معنایی زیر را استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه هر مقدار خارج از بازه را فوراً رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ قالب هدف ممکن است هنگام ذخیره یا باز کردن فایل توسط PowerPoint داده‌های نامعتبر را نرمال‌سازی، حذف یا رد کند.

| عملیات | پارامترها | بازه معتبر و واحد |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` تا `100` درصد؛ `0` مؤلفه را بدون تغییر می‌گذارد. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | هیچ | پارامتر عددی ندارند. آلفا بدون تغییر می‌ماند. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | دو رنگ برای پیکسل‌های تیره و روشن. مقادیر کانال‌های RGB و آلفا در `System.Drawing.Color` از `0` تا `255` هستند. |
| [AddTintEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | رنگ‌پرتو (`hue`) از `0` شامل تا `360` به‌جز، بر حسب درجه؛ مقدار (`amount`) از `-100` تا `100` درصد. |
| [AddHSLEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` از `0` شامل تا `360` به‌جز، بر حسب درجه؛ اشباع (`saturation`) و روشنایی (`luminance`) از `-100` تا `100` درصد. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | رنگ جایگزین مقادیر کانال‌هایش را از `0` تا `255` می‌گیرد. مقادیر آلفای موجود بدون تغییر می‌مانند. |
| [AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | شعاع مقدار غیرمنفی است و بر حسب نقطه اندازه‌گیری می‌شود؛ `grow` یک Boolean است که تعیین می‌کند آیا محتوای تاری می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | درصد غیرمنفی. برای مقیاس‌گذاری شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` تا `100` درصد شفافیت. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` تا `100` درصد آستانهٔ آلفا. مقادیر زیر آن شفاف می‌شوند؛ مقادیر برابر یا بالاتر آن مات می‌شوند. |

برای مدولاسیون ثابت آلفا، شفافیت و مات بودن مکمل یکدیگر هستند. به‌عنوان مثال، شفافیت 35٪ معادل مقدار مدولاسیون آلفای 65٪ است.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) یک عمل [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) برمی‌گرداند. تنظیمات اسکالر هنگام ایجاد عملیات فراهم می‌شوند. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/geteffective/) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را برمی‌گرداند که می‌توان آنها را بررسی یا ثبت کرد.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد، سپس پیش‌نمایشی را بدون تغییر تصویر جاسازی‌شده رندر می‌کند:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) افزونهٔ اثر تصویری Office 2010 است و نسبت به اثر روشنایی استاندارد DrawingML کمتر قابل حمل است. وقتی نیاز باشد روشنایی و کنتراست پس از یک دورانی PPTX قابل ویرایش بمانند، از [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) استفاده کنید و پس از باز کردن مجدد فایل نتیجه را تأیید کنید. بخش محدودیت‌های قالب این تمایز را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

تأثیرات رنگی می‌توانند به‌صورت مستقل بر فریم‌های تصویری مختلف که یک منبع تصویر را به‌کار می‌برند، اعمال شوند. مثال زیر پنج فریم ایجاد می‌کند و به ترتیب مقیاس‌سودگی خاکستری، دو‑رنگی، رنگ‌پرتو، تنظیم HSL و جایگزینی رنگ را اعمال می‌کند.

[IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) دو پارامتر رنگی مستقل‑قابل‑ویرایش دارد: `Color1` رنگ پیکسل‌های تاریک و `Color2` رنگ پیکسل‌های روشن را تعیین می‌کند. این باعث می‌شود یک مثال مفید از اثر باشد که تنظیماتش پیچیده‌تر از یک مقدار اسکالر منفرد است.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی‌که آلفا را حفظ می‌کند. این متفاوت از [AddColorChangeEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) است که یک رنگ منبع را به رنگ هدف نگاشت می‌کند و هر دو قالب رنگ منبع و هدف را نمایان می‌سازد.

### **اعمال آستانهٔ روشنایی**

یک آستانهٔ روشنایی می‌تواند علائم ضعیف روی یک صفحهٔ اسکن‌شده را از پس‌زمینه متمایز کند. [AddGrayScaleEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) سایه‌های میانی خاکستری را حفظ می‌کند. [AddBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addbileveleffect/) روشنایی را به سیاه یا سفید نگاشت می‌کند، در حالی‌که [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) آستانه‌ای را بر شفافیت اعمال می‌کند.

آستانهٔ روشنایی از 0٪ تا 100٪، گنجانده می‌شود. پیکسل‌های زیر آستانه سیاه می‌شوند. پیکسل‌های برابر یا بالاتر سفید می‌شوند. افزایش آستانه باعث می‌شود سایه‌های بیشتری سیاه شوند زیرا بیشتر آنها زیر حد برش می‌افتند.

Download [grayscale-swatches.png](grayscale-swatches.png) to the working directory. Each label gives the original gray level on a scale from 0 to 255. The example places the original beside two copies and saves each copy's threshold in the presentation.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 150, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var imageData = File.ReadAllBytes("grayscale-swatches.png");
var image = presentation.Images.AddImage(imageData);

IPictureFrame AddFrame(float x, string caption)
{
    shapes.AddAutoShape(ShapeType.Rectangle, x, 12, 216, 36).TextFrame.Text = caption;
    return shapes.AddPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
}

AddFrame(12, "Original");

var lowThreshold = AddFrame(252, "Threshold 20%");
lowThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(20f);

var highThreshold = AddFrame(492, "Threshold 60%");
highThreshold.PictureFormat.Picture.ImageTransform.AddBiLevelEffect(60f);

presentation.Save("luminance-threshold.pptx", SaveFormat.Pptx);
```

Open the output presentation in PowerPoint to compare the three frames. The swatch labeled 96 has about 38% luminance (96 out of 255). It turns white at the 20% threshold and black at the 60% threshold.

![نمونه‌های اصلی خاکستری کنار نتایج سیاه‑سفید در آستانه‌های روشنایی 20٪ و 60٪](luminance-threshold.png)

## **افزودن تاری، شفافیت و اثرهای آلفا**

[AddBlurEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) بر تمام کانال‌های رنگ، از جمله آلفا، تأثیر می‌گذارد. وقتی لبهٔ تاری ممکن است خارج از مرزهای تصویر اصلی گسترش یابد، `grow` را به `true` تنظیم کنید.

برای شفافیت یکنواخت، از [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) استفاده کنید. این اثر هر مقدار آلفای موجود را ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف به‌صورت نسبی متفاوت باقی می‌مانند. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) به‌جای آن یک مقدار آلفا واحد را به همهٔ پیکسل‌ها اختصاص می‌دهد. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) آلفا را به دو سطح بر پایهٔ آستانه تبدیل می‌کند.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

سایر عملیات آلفای بدون پارامتر شامل [AddAlphaCeilingEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/)، که هر آلفای غیرصفر را کاملاً مات می‌کند؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/)، که هر آلفای زیر 100٪ را کاملاً شفاف می‌کند؛ و [AddAlphaInverseEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/)، که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثر مرتب**

هر متد `Add...Effect` عملی را به انتهای مجموعه اضافه می‌کند. رندرکننده از مجموعه به‌عنوان یک خط لولهٔ مرتب استفاده می‌کند: خروجی عملیات 0 به ورودی عملیات 1 می‌شود و الی آخر. در نتیجه، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به‌عنوان مثال، ابتدا اعمال مقیاس‌سودگی خاکستری سپس رنگ‌پرتو، ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را رنگ می‌دهد. رنگ‌پرتو سپس مقیاس‌سودگی خاکستری، همان رنگ‌پرتو را دوباره حذف می‌کند. به‌طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفایی که توسط عملیات‌های قبلی محاسبه شده‌اند را بازنویسی کند، در حالی‌که مدولاسیون آلفا تفاوت‌های نسبی آنها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار‑عملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را باز می‌کند، هر دو نوع عملیات و ترتیبشان را بررسی می‌کند و نتیجهٔ بازگشایی‌شده را رندر می‌کند:

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

مجموعه محدودیتی سازگاری اعمال نمی‌کند که عملیات‌های رنگ، آلفا و تاری را به زنجیره‌های جداگانه محدود کند. آنها می‌توانند ترکیب شوند، اما ترکیب‌ها همیشه مفید نیستند. جایگزینی ثابت رنگ، تغییرات RGB تولید شده توسط اثرهای رنگی قبلی را حذف می‌کند؛ مقیاس‌سودگی خاکستری پس از دو‑رنگی، دو رنگ انتخاب‌شده را حذف می‌کند؛ و عملیات‌های سقف، کف، جایگزینی یا دو‑سطحی آلفا می‌توانند جزئیات آلفایی ایجاد شده قبلی را دور بیندازند. زنجیره را بر اساس ترتیب پردازش پیکسل موردنظر ساخته و نه به‌عنوان پرچم‌های قالب‌بندی نامرتب.

<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*در این رندر Aspose.Slides for .NET 26.11، رنگ‌پرتوی 220° با 25% تصویر مقیاس‌سودگی خاکستری را تغییری نمی‌دهد. اعمال همان رنگ‌پرتو پیش از مقیاس‌سودگی خاکستری نتایج متفاوتی به‌دست می‌دهد.*
<!-- visual-explanation:image-transform-effects:end -->

## **بازرسی مقادیر قابل ویرایش و مؤثر**

یک عملیات قابل ویرایش همان شیء ذخیره‌شده در `ISlidesPicture.ImageTransform` است. بسته به اثر، ممکن است اعضای نوشتنی را مستقیماً نشان دهد. برای مثال، [IBlur](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/) ویژگی‌های نوشتنی `Radius` و `Grow` را افشا می‌کند، [IAlphaModulateFixed](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphamodulatefixed/) ویژگی نوشتنی `Amount` را نشان می‌دهد، و [IAlphaBiLevel](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphabilevel/) ویژگی نوشتنی `Threshold` را آشکار می‌کند. اثرهای رنگی نظیر [IDuotone](https://reference.aspose.com/slides/net/aspose.slides.effects/iduotone/) اشیاء قابل تغییر [IColorFormat](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/) را فراهم می‌کنند.

برخی از رابط‌های عملیات، شامل [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/net/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/net/aspose.slides.effects/itint/) و [IAlphaReplace](https://reference.aspose.com/slides/net/aspose.slides.effects/ialphareplace/)، مقیاس‌های ساخت خود را به‌صورت ویژگی‌های نوشتنی نشان نمی‌دهند. برای تغییر این تنظیمات، عملیات را حذف کنید و یک جایگزین در موقعیت موردنیاز اضافه کنید.

داده‌های مؤثر برگردانده‌شده توسط `GetEffective()` محاسبه‌شده و فقط‑خواندنی هستند. این داده‌ها برای حل رنگ‌های وابسته به قالب و خواندن مقادیر نرمال‌شده‌ای که رندرکننده استفاده می‌کند، مفید هستند، اما سطح ویرایشی دیگری نیستند. مثال زیر زنجیره را مرور می‌کند و مقادیر مؤثر را درجایی که API مربوطه آنها را فراهم می‌کند، بررسی می‌کند:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

اثرهای بدون پارامتر نظیر مقیاس‌سودگی خاکستری، سقف آلفا و وارون آلفا هنوز شیء دادهٔ مؤثری دارند، اما پارامترهای اسکالر برای چاپ ندارند. حضور و موقعیت آنها در مجموعه، اطلاعات مهم هستند.

## **حذف یا پاک‌کردن تبدیل‌های تصویر**

از [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) برای حذف یک عملیات بر اساس اندیس استفاده کنید. چون اندیس‌ها پس از حذف جابه‌جا می‌شوند، ابتدا هدف را جستجو کنید و پس از مرور آن را حذف کنید. برای حذف کل زنجیره از `Clear()` استفاده کنید.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

حذف یا پاک‌کردن تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این کار منبع [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) استفاده‌شده را حذف، فشرده‌سازی یا به‌طور دیگری تغییر نمی‌دهد.

## **در نظر گرفتن قالب‌های ارائه و مقاصد خروجی**

تبدیل‌های تصویر از DrawingML نشأت می‌گیرند، بنابراین PPTX قالب قابل ویرایش ترجیحی برای زنجیره‌های اثر است. حتی با PPTX، همهٔ عملیات‌ها قابل‌حملیت یکسانی ندارند:

- عملیات‌های استاندارد DrawingML مانند روشنایی، مقیاس‌سودگی خاکستری، دو‑رنگی، رنگ‌پرتو، HSL، تاری و عملیات‌های متداول آلفا بهترین شانس را برای بقا در دورانی PPTX دارند. همیشه فایل تولیدشده را دوباره باز کنید و مجموعه را بازبینی کنید زمانی که حفظ اثرها الزامی است.
- [BrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ Office 2010 است نه عملیات استاندارد روشنایی DrawingML. می‌توان از آن برای رندر در حافظه استفاده کرد، اما پس از ذخیره و بازگشایی PPTX تضمین نمی‌شود که به‌عنوان یک [IBrightnessContrast](https://reference.aspose.com/slides/net/aspose.slides.effects/ibrightnesscontrast/) قابل ویرایش باقی بماند. برای تنظیمات ثابت روشنایی و کنتراست، از [AddLuminanceEffect](https://reference.aspose.com/slides/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) استفاده کنید.
- قالب باینری PPT پیش از مدل کامل اثرهای DrawingML وجود داشت. ذخیره به PPT می‌تواند عملیات‌های نامپشتیبانی‌شده را حذف کند، زنجیره را به زیرمجموعهٔ پشتیبانی‌شده کاهش دهد یا ظاهر را تقریب بزند. برای تأیید زنجیرهٔ پیچیدهٔ قابل ویرایش، از PPT به‌عنوان قالب تأیید استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا سایر خروجی‌های تصویری، زنجیرهٔ پشتیبانی‌شده را بر روی ظاهر رندر شده اعمال می‌کند. این خروجی‌ها مجموعهٔ `IImageTransformOperationCollection` ویرایشی را ندارند؛ قالب‌های رستری نتیجه را به پیکسل‌ها مسطح می‌کنند و خروجی‌های سند/خطی نمای رندر خود را ذخیره می‌کنند.
- اثرها تصویر پیوندی را خود‑محافظ نمی‌کنند. رندر یک تصویر پیوندی همچنان به در دسترس بودن منبع پیوندی هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را به‌طرق مختلف رندر کنند، به‌ویژه زمانی که چندین عملیات آلفا یا رنگ‑کوانتایزینگ ترکیب می‌شوند. برای خروجی‌های بحرانی، هر دو دورانی ویرایشی و قالب خروجی نهایی را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، تست کنید.

## **سؤال‌های متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر جاسازی‌شده را تغییر می‌دهند؟**

نه. عملیات‌ها به `ISlidesPicture` که توسط پرکنندهٔ تصویر استفاده می‌شود تعلق دارند. بایت‌های زیرین `IPPImage` بدون تغییر می‌مانند.

**آیا دو فریم تصویری که از یک تصویر استفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. استفادهٔ مجدد از یک `IPPImage` از تکرار دادهٔ تصویر جلوگیری می‌کند، اما هر فریم تصویر معمولاً یک `ISlidesPicture` و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، تاری و آلفا را ترکیب کرد؟**

بله. مجموعه این اثرها را در یک زنجیرهٔ مرتب می‌پذیرد. به این فکر کنید که هر عملیات چه‌گونه بر خروجی عملیات قبلی تأثیر می‌گذارد، زیرا عملیات‌های جایگزینی و آستانه ممکن است جزئیات رنگ یا آلفای قبلی را حذف کنند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

داده‌های مؤثر مقادیر محاسبه‌شده‌ای هستند که برای رندر استفاده می‌شوند، از جمله رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید جایی که اعضای نوشتنی موجودند؛ در غیر این صورت آن را حذف کنید و با پارامترهای ساخت جدید جایگزین کنید.

**کدام قالب را باید برای حفظ زنجیرهٔ تبدیل استفاده کنم؟**

از PPTX استفاده کنید و فایل را با بازگشایی مجدد تأیید کنید. PPT قدیمی نمی‌تواند مدل کامل اثرهای DrawingML را نشان دهد و قالب‌های خروجی رندر شده فقط ظاهر را حفظ می‌کنند، نه عملیات تبدیل‌های قابل ویرایش.