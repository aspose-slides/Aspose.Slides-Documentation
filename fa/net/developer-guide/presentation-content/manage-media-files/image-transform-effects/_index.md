---
title: مدیریت اثرهای تبدیل تصویر در ارائه‌ها با .NET
linktitle: اثرهای تبدیل تصویر
type: docs
weight: 11
url: /fa/net/image-transform-effects/
keywords:
- تبدیل تصویر
- اثر تصویر
- روشنایی
- کنتراست
- سیاه‌سفید
- دو‑رنگ
- رنگ‌زاد
- HSL
- جایگزینی رنگ
- محو
- شفافیت
- اثر آلفا
- زنجیرهٔ اثر
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "اعمال، زنجیره‌سازی، بررسی، حذف و تأیید اثرهای تبدیل تصویر برای قاب‌های تصویر با Aspose.Slides برای .NET."
---
## **مرور کلی**

Aspose.Slides تنظیمات تصویر را به صورت یک مجموعهٔ ترتیبی از عملیات تبدیل تصویر (image transform) نمایش می‌دهد. برای یک قاب تصویر، ابتدا با [ISlidesPicture](https://reference.aspose.com/slides/fa/net/aspose.slides/islidespicture/) قاب کار کنید و به [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/fa/net/aspose.slides/islidespicture/imagetransform/) دسترسی پیدا کنید. شیٔ [IImageTransformOperationCollection](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/) برگردانده‌شده به شما اجازه می‌دهد تا عملیات‌ها را اضافه، مرور، بررسی، حذف و پاک سازی کنید بدون این‌که بایت‌های تصویر اصلی بازنویسی شوند.

این مقاله یک جریان کاری کامل برای روشنایی و کنتراست، تبدیل رنگ‌ها، محو (blur)، شفافیت، زنجیرهٔ اثرات ترتیبی، مقادیر مؤثر، حذف و اعتبارسنجی دورانی PPTX را نشان می‌دهد.

## **درک مالکیت اثر و بازاستفادهٔ تصویر**

یک منبع تصویر و تصویری که آن را نمایش می‌دهد، اشیاء متفاوتی هستند:

- [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) دادهٔ تصویر منبع را که متعلق به ارائه است، نگهداری یا به آن ارجاع می‌دهد.
- [ISlidesPicture](https://reference.aspose.com/slides/fa/net/aspose.slides/islidespicture/) متعلق به پرکردن تصویر است و به منبع تصویر اشاره می‌کند در حالی که مجموعهٔ تبدیل تصویر را ذخیره می‌کند.
- [IPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ipictureframe/) شکل اسلاید است که پرکردن تصویر، هندسه، تنظیمات برش و دیگر قالب‌بندی‌های سطح قاب را داراست.

به همین دلیل، عملیات‌های تبدیل تصویر بایت‌های موجود در [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را تغییر نمی‌دهند. وقتی همان `IPPImage` بیش از یک بار به [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishapecollection/addpictureframe/) پاس داده شود، هر قاب جدید تصویر `ISlidesPicture` و مجموعهٔ تبدیل خود را دریافت می‌کند. اعمال حالت‌سفید (grayscale) به یک قاب، باعث نمی‌شود قاب‌های دیگر نیز حالت‌سفید شوند، حتی اگر همهٔ آن‌ها از همان منبع تصویر توکار استفاده کنند.

مدل `ISlidesPicture.ImageTransform` همان‌طور که در سایر پرکننده‌های تصویر مثل شکل یا پس‌زمینهٔ اسلاید استفاده می‌شود، در این مثال‌ها بر روی قاب‌های تصویر متمرکز است.

## **استفاده از بازه‌ها و واحدهای معتبر پارامترها**

روش‌های نشان داده‌شده از بازه‌ها و واحدهای معنایی زیر استفاده می‌کنند. حتی اگر نسخهٔ خاصی از کتابخانه مقدار خارج از بازه را بلافاصله رد نکند، مقادیر را در این بازه‌ها نگه دارید؛ چون فرمت هدف ممکن است در زمان ذخیره یا هنگام باز شدن فایل توسط PowerPoint داده نامعتبر را نرمال‌سازی، حذف یا رد کند.

| عمل | پارامترها | بازه و واحد معتبر |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` تا `100`، درصد؛ `0` مؤلفه را تغییر نمی‌دهد. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | بدون | پارامتر عددی ندارد. آلفا تغییر نمی‌کند. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | دو رنگ برای پیکسل‌های تاریک و روشن. مقادیر کانال‌های RGB و آلفا در `System.Drawing.Color` از `0` تا `255` هستند. |
| [AddTintEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | `hue` شامل `0` تا قبل از `360`، به درجه؛ `amount` از `-100` تا `100` درصد. |
| [AddHSLEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | `hue` شامل `0` تا قبل از `360` درجه؛ `saturation` و `luminance` از `-100` تا `100` درصد. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | رنگ جایگزین مقادیر کانال از `0` تا `255` را دارد. مقادیر آلفای موجود تغییری نمی‌کند. |
| [AddBlurEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | `radius` مقدار غیرمنفی است و بر حسب پوینت اندازه‌گیری می‌شود؛ `grow` یک Boolean است که کنترل می‌کند آیا محتوای محوشده می‌تواند خارج از مرزهای اصلی گسترش یابد یا نه. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | درصد غیرمنفی. برای مقیاس‌گذاری شفافیت معمولی از `0` تا `100` استفاده کنید: `0` کاملاً شفاف و `100` آلفای موجود را حفظ می‌کند. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` تا `100` درصد شفافیت. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` تا `100` درصد آلفا آستانه. مقادیر زیر آن شفاف می‌شوند؛ مقادیر برابر یا بالاتر آن نامرئی می‌شوند. |

برای مدولات آلفای ثابت، شفافیت و مات‌پذیری مکمل یکدیگرند. برای مثال، 35٪ شفافیت معادل مقدار مدولات آلفای 65٪ است.

## **اعمال روشنایی و کنتراست**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) یک عملیات [IBrightnessContrast](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/ibrightnesscontrast/) برمی‌گرداند. تنظیمات اسکالر آن هنگام ایجاد عملیات تعیین می‌شود. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/brightnesscontrast/geteffective/) مقادیر محاسبه‌شدهٔ فقط‑خواندنی را که می‌توانند بررسی یا ثبت شوند، برمی‌گرداند.

مثال زیر روشنایی را 15٪ و کنتراست را 20٪ افزایش می‌دهد، سپس پیش‌نمایشی بدون تغییر تصویر توکار تولید می‌کند:

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

[BrightnessContrast](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/brightnesscontrast/) یک افزونهٔ اثر تصویر Office 2010 است و نسبت به اثر luminance استاندارد DrawingML قابلیت‌پذیری کمتری دارد. وقتی باید روشنایی و کنتراست پس از یک دور PPTX قابل ویرایش بمانند، از [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) استفاده کنید و پس از باز کردن مجدد فایل، نتیجه را تأیید کنید. بخش محدودیت‌های فرمت این تمایز را با جزئیات بیشتری توضیح می‌دهد.

## **اعمال تبدیل‌های رنگی**

اثرات رنگی می‌توانند به‌صورت مستقل بر روی قاب‌های تصویری مختلف که یک منبع تصویر را بازاستفاده می‌کنند، اعمال شوند. مثال زیر پنج قاب ایجاد می‌کند و حالت‌سفید، دو‑رنگ (duotone)، رنگ‌زاد (tint)، تنظیم HSL و جایگزینی رنگ را اعمال می‌نماید.

[IDuotone](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iduotone/) دو پارامتر رنگی مستقل دارد: `Color1` پیکسل‌های تاریک و `Color2` پیکسل‌های روشن را نقشه‌برداری می‌کند. این یک مثال مفید از اثر است که تنظیمات پیچیده‌تری نسبت به یک مقدار اسکالر دارد.

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

[AddColorReplaceEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) هر پیکسل را با یک رنگ ثابت جایگزین می‌کند در حالی که آلفا را حفظ می‌کند. این متفاوت از [AddColorChangeEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/) است که یک رنگ منبع را به رنگ هدف دیگری نگاشت می‌کند و هر دو قالب رنگ منبع و هدف را در اختیار می‌گذارد.

## **افزودن محو، شفافیت و اثرات آلفا**

[AddBlurEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) تمام کانال‌های رنگی، شامل آلفا، را تحت تأثیر قرار می‌دهد. وقتی لبهٔ محوشده ممکن است بیرون از مرزهای تصویر اصلی گسترش یابد، `grow` را به `true` تنظیم کنید.

برای شفافیت یکنواخت، از [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) استفاده کنید. این اثر مقدار آلفای موجود را در هر پیکسل ضرب می‌کند، بنابراین پیکسل‌های نیمه‌شفاف به‌صورت نسبی متفاوت باقی می‌مانند. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) به‌جای این کار، یک مقدار آلفا واحد را به همهٔ پیکسل‌ها اختصاص می‌دهد. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) آلفا را بر اساس یک آستانه به دو سطح تبدیل می‌کند.

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

سایر عملیات آلفای بدون پارامتر شامل [AddAlphaCeilingEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/) است که هر آلفای غیرصفر را کاملاً نامرئی می‌کند؛ [AddAlphaFloorEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/) که هر آلفای زیر 100٪ را کاملاً شفاف می‌کند؛ و [AddAlphaInverseEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/) که آلفا را به `100% - alpha` تغییر می‌دهد.

## **ساخت زنجیرهٔ اثر ترتیبی**

هر روش `Add...Effect` یک عملیات جدید را به انتهای مجموعه اضافه می‌کند. رندرر مجموعه را به‌عنوان یک خط لولهٔ ترتیبی استفاده می‌کند: خروجی عملیات 0 تبدیل به ورودی عملیات 1 می‌شود و به همین ترتیب. بنابراین، همان عملیات‌ها در ترتیب متفاوت می‌توانند تصویر متفاوتی تولید کنند.

به عنوان مثال، حالت‌سفید پس از رنگ‌زاد ابتدا اطلاعات رنگی را حذف می‌کند و سپس نتیجهٔ روشنایی را رنگ‌زده (recolor) می‌کند. رنگ‌زاد پس از حالت‌سفید رنگ‌زاد را دوباره حذف می‌کند. به طور مشابه، جایگزینی آلفا می‌تواند مقادیر آلفایی که توسط عملیات‌های قبلی محاسبه شده‌اند را بازنویسی کند، در حالی که مدولات آلفا اختلافات نسبی آن‌ها را حفظ می‌کند.

مثال زیر یک زنجیرهٔ چهار‑عملیاتی می‌سازد، آن را به‌صورت PPTX ذخیره می‌کند، ارائه را باز می‌کند، هر دو نوع عملیات و ترتیب آن‌ها را بررسی می‌کند و نتیجهٔ باز کرده را رندر می‌کند:

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

مجموعه محدودیتی در زمینهٔ سازگاری اعمال نمی‌کند که رنگ، آلفا و عملیات محو را به زنجیره‌های جداگانه محدود کند. آن‌ها می‌توانند ترکیب شوند، هرچند ترکیب‌ها همیشه مفید نیستند. یک جایگزینی رنگ ثابت، تنوع RGB تولیدشده توسط اثرهای رنگی قبلی را حذف می‌کند؛ حالت‌سفید پس از دو‑رنگ، دو رنگ انتخاب‌شده را حذف می‌کند؛ و عملیات‌های آلفا ceiling، floor، replacement یا bi‑level می‌توانند جزئیات آلفایی ایجادشدهٔ قبلی را از بین ببرند. زنجیره را بر اساس دنبالهٔ پردازش پیکسل موردنظر ساختاردهید نه به‌عنوان پرچم‌های قالب‌بندی بی‌نظم.

## **بازرسی مقادیر ویرایش‌پذیر و مؤثر**

یک عملیات ویرایش‌پذیر شیٔی است که در `ISlidesPicture.ImageTransform` ذخیره می‌شود. بسته به اثر، ممکن است اعضای قابل نوشتن را مستقیماً در اختیار بگذارد. به عنوان مثال، [IBlur](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iblur/) `Radius` و `Grow` را قابل نوشتن می‌کند، [IAlphaModulateFixed](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/ialphamodulatefixed/) `Amount` را قابل نوشتن می‌کند، و [IAlphaBiLevel](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/ialphabilevel/) `Threshold` را قابل نوشتن می‌کند. اثرات رنگی مانند [IDuotone](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iduotone/) اشیاء [IColorFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/icolorformat/) قابل تغییر را در اختیار می‌گذارند.

برخی از واسط‌های عملیات، از جمله [IBrightnessContrast](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/ibrightnesscontrast/)، [IHSL](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/ihsl/)، [ITint](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/itint/) و [IAlphaReplace](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/ialphareplace/) اسکالرهای ساخت خود را به‌عنوان ویژگی‌های نوشتنی نمایان نمی‌سازند. برای تغییر این تنظیمات، عملیات را حذف کنید و در موقعیت موردنظر جایگزین جدیدی اضافه کنید.

دادهٔ مؤثری که توسط `GetEffective()` برگردانده می‌شود محاسبه شده و فقط‑خواندنی است. این داده برای حل رنگ‌های وابسته به تم و خواندن مقادیر نرمال‌سازی‌شده‌ای که رندرر استفاده می‌کند مفید است، اما سطح ویرایش دیگری نیست. مثال زیر زنجیره را مرور می‌کند و مقادیر مؤثر را در جایی که API مربوطه آن‌ها را فراهم می‌کند، بررسی می‌نماید:

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

اثرات بدون پارامتر مانند حالت‌سفید، آلفا ceiling و آلفا inverse نیز یک شیٔ دادهٔ مؤثر دارند، اما مقدار اسکالر برای چاپ ندارند. وجود و موقعیت آن‌ها در مجموعه اطلاعات مهم هستند.

## **حذف یا پاک‌سازی تبدیل‌های تصویر**

از [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) برای حذف یک عملیات بر اساس ایندکس استفاده کنید. چون ایندکس‌ها بعد از حذف جابجا می‌شوند، ابتدا هدف را جستجو کنید و سپس پس از مرور آن را حذف کنید. برای حذف کل زنجیره از `Clear()` استفاده کنید.

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

حذف یا پاک‌سازی تبدیل‌ها فقط قالب‌بندی تصویر را تغییر می‌دهد. این عمل منبع [IPPImage](https://reference.aspose.com/slides/fa/net/aspose.slides/ippimage/) را حذف، فشرده‌سازی مجدد یا به‌هره‌برداری دیگری نمی‌کند.

## **در نظر گرفتن فرمت‌های ارائه و مقصدهای خروجی**

تبدیل‌های تصویر در DrawingML منشأ می‌گیرند، بنابراین PPTX فرمت ویرایش‌پذیر ترجیحی برای زنجیره‌های اثر است. حتی با PPTX نیز تمام عملیات‌ها قابلیت‌پذیری یکسانی ندارند:

- عملیات‌های استاندارد DrawingML مانند luminance، حالت‌سفید، دو‑رنگ، رنگ‌زاد، HSL، محو و عملیات‌های رایج آلفا بیشترین شانس باقی‌ماندن پس از دورهای PPTX را دارند. همیشه فایل تولید‌شده را باز کنید و مجموعه را بازبینی کنید وقتی حفظ‌پذیری الزامی است.
- [BrightnessContrast](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/brightnesscontrast/) افزونهٔ Office 2010 است نه عملیات استاندارد luminance DrawingML. می‌تواند برای رندرینگ در حافظه استفاده شود، اما پس از ذخیره و باز کردن PPTX تضمین نمی‌شود که به‌عنوان یک [IBrightnessContrast](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/ibrightnesscontrast/) قابل ویرایش باقی بماند. برای تنظیمات پایدار روشنایی و کنتراست، از [AddLuminanceEffect](https://reference.aspose.com/slides/fa/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) استفاده کنید.
- فرمت باینری PPT پیش از مدل کامل اثر DrawingML وجود داشت. ذخیره به PPT می‌تواند عملیات‌های پشتیبانی‌نشده را حذف کند، زنجیره را به زیرمجموعه‌ای قابل حمایت کاهش دهد یا ظاهر را تقریب بزند. برای تأیید زنجیرهٔ قابل ویرایش پیچیده، از PPT به‌عنوان فرمت هدف استفاده نکنید.
- رندر به PNG، JPEG، TIFF، PDF، SVG، HTML یا خروجی‌های بصری دیگر زنجیرهٔ پشتیبانی‌شده را بر ظاهر رندری اعمال می‌کند. این خروجی‌ها `IImageTransformOperationCollection` قابل ویرایش را شامل نمی‌شوند؛ فرمت‌های رستری نتیجه را به پیکسل تبدیل می‌کنند و صادرات اسناد/برداری نمایهٔ رندری خودشان را ذخیره می‌کنند.
- اثرها تصویر لینک‌شده را خودکفا نمی‌سازند. رندر یک تصویر لینک‌شده همچنان به موجود بودن منبع لینک‌شده هنگام بارگذاری ارائه وابسته است.

مصرف‌کنندگان مختلف ارائه ممکن است موارد لبه‌ای را متفاوت رندر کنند، به‌ویژه وقتی چندین عملیات آلفا یا کمی‌سازی رنگ ترکیب شوند. برای خروجی حیاتی، هر دو دور ویرایش‌پذیر و فرمت نهایی صادرات را با همان نسخهٔ Aspose.Slides که در تولید استفاده می‌شود، آزمایش کنید.

## **سؤالات متداول**

**آیا اثرهای تبدیل تصویر دادهٔ تصویر توکار را تغییر می‌دهند؟**

نه. این عملیات‌ها به `ISlidesPicture` که توسط پرکنندهٔ تصویر استفاده می‌شود تعلق دارند. بایت‌های زیرین `IPPImage` دست نخورده می‌مانند.

**آیا دو قاب تصویر که از یک تصویر استفاده می‌کنند اثرهای خود را به‌اشتراک می‌گذارند؟**

نه. استفاده مجدد از یک `IPPImage` باعث جلوگیری از تکرار دادهٔ تصویر می‌شود، اما هر قاب تصویر به‌طور معمول یک `ISlidesPicture` و مجموعهٔ تبدیل تصویر جداگانه دارد.

**آیا می‌توان اثرهای رنگ، محو و آلفا را ترکیب کرد؟**

بله. مجموعه آن‌ها را در یک زنجیرهٔ ترتیبی می‌پذیرد. به این فکر کنید که هر عملیات چه تأثیری بر خروجی عملیات قبلی دارد، زیرا عملیات‌های جایگزینی و آستانه می‌توانند جزئیات رنگ یا آلفای قبلی را از بین ببرند.

**چرا مقادیر مؤثر فقط‑خواندنی هستند؟**

دادهٔ مؤثر مقادیر محاسبه‌شده‌ای است که برای رندر استفاده می‌شود، از جمله رنگ‌های حل‌شده. عملیات ذخیره‌شده در مجموعهٔ تبدیل را ویرایش کنید که اعضای قابل نوشتن دارد؛ در غیر این صورت آن را حذف کنید و با پارامترهای ساخت جدید جایگزین کنید.

**کدام فرمت برای حفظ زنجیرهٔ تبدیل توصیه می‌شود؟**

از PPTX استفاده کنید و با باز کردن مجدد فایل آن را تأیید نمایید. PPT نسخهٔ قدیمی نمی‌تواند مدل کامل اثر DrawingML را نشان دهد و فرمت‌های صادرات رندری فقط ظاهر را حفظ می‌کنند، نه عملیات تبدیل قابل ویرایش.