---
title: "مدیریت پس‌زمینه‌های ارائه در .NET"
linktitle: "پس‌زمینه اسلاید"
type: docs
weight: 20
url: /fa/net/presentation-background/
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
- ".NET"
- "C#"
- "Aspose.Slides"
description: "یاد بگیرید چگونه با استفاده از Aspose.Slides برای .NET، پس‌زمینه‌های پویا را در فایل‌های PowerPoint و OpenDocument تنظیم کنید، همراه با نکات کد برای ارتقای ارائه‌های خود."
---
## **معرفی**

رنگ‌های ثابت، گرادیان‌ها و تصاویر معمولاً برای پس‌زمینهٔ اسلاید استفاده می‌شوند. می‌توانید پس‌زمینهٔ یک **اسلاید عادی** (یک اسلاید تک) یا یک **اسلاید اصلی** (به چند اسلاید به‌صورت همزمان اعمال می‌شود) را تنظیم کنید.

![PowerPoint background](powerpoint-background.png)

## **تنظیم پس‌زمینهٔ رنگ ثابت برای اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد تا یک رنگ ثابت را به‌عنوان پس‌زمینهٔ اسلاید خاصی در یک ارائه تنظیم کنید — حتی اگر ارائه از اسلاید اصلی استفاده کند. این تغییر فقط به اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید را روی `OwnBackground` تنظیم کنید.
3. پس‌زمینهٔ اسلاید را با [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) روی `Solid` تنظیم کنید.
4. از ویژگی [SolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/solidfillcolor/) در [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/) برای مشخص کردن رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد نمونهٔ زیر به زبان C# نشان می‌دهد چگونه یک رنگ ثابت آبی را به‌عنوان پس‌زمینهٔ اسلاید عادی تنظیم کنید:

```cs
// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // ارائه را روی دیسک ذخیره کنید.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **تنظیم پس‌زمینهٔ رنگ ثابت برای اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد تا یک رنگ ثابت را به‌عنوان پس‌زمینهٔ اسلاید اصلی در یک ارائه تنظیم کنید. اسلاید اصلی به‌عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی رنگ ثابت را برای پس‌زمینهٔ اسلاید اصلی انتخاب می‌کنید، بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید اصلی (از طریق `masters`) را روی `OwnBackground` تنظیم کنید.
3. پس‌زمینهٔ اسلاید اصلی را با [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) روی `Solid` تنظیم کنید.
4. از [SolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/solidfillcolor/) برای مشخص کردن رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد نمونهٔ زیر به زبان C# نشان می‌دهد چگونه یک رنگ ثابت (سبز جنگلی) را به‌عنوان پس‌زمینهٔ اسلاید اصلی تنظیم کنید:

```cs
// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // رنگ پس‌زمینه اسلاید Master را به سبز جنگل تنظیم کنید.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // ارائه را روی دیسک ذخیره کنید.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **تنظیم پس‌زمینهٔ گرادیان برای اسلاید**

گرادیان یک اثر گرافیکی است که با تغییر تدریجی رنگ ایجاد می‌شود. وقتی به‌عنوان پس‌زمینهٔ اسلاید استفاده شود، گرادیان‌ها می‌توانند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر نشان دهند. Aspose.Slides به شما امکان می‌دهد تا یک رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید را روی `OwnBackground` تنظیم کنید.
3. پس‌زمینهٔ اسلاید را با [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) روی `Gradient` تنظیم کنید.
4. از ویژگی [GradientFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/gradientformat/) در [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/) برای پیکربندی تنظیمات دلخواه گرادیان استفاده کنید.
5. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد نمونهٔ زیر به زبان C# نشان می‌دهد چگونه یک رنگ گرادیان را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```cs
// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // یک اثر گرادیان را به پس‌زمینه اعمال کنید.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // ارائه را روی دیسک ذخیره کنید.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **تنظیم تصویر به‌عنوان پس‌زمینهٔ اسلاید**

علاوه بر پرکننده‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد تا از تصاویر به‌عنوان پس‌زمینهٔ اسلاید استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. مقدار [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید را روی `OwnBackground` تنظیم کنید.
3. پس‌زمینهٔ اسلاید را با [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) روی `Picture` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینهٔ اسلاید استفاده کنید را بارگذاری کنید.
5. تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
6. از ویژگی [PictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/picturefillformat/) در [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائهٔ اصلاح‌شده را ذخیره کنید.

کد نمونهٔ زیر به زبان C# نشان می‌دهد چگونه یک تصویر را به‌عنوان پس‌زمینهٔ اسلاید تنظیم کنید:

```c#
// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // تنظیم ویژگی‌های تصویر پس‌زمینه.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // تصویر را بارگذاری کنید.
    IImage image = Images.FromFile("Tulips.jpg");
    // تصویر را به مجموعهٔ تصاویر ارائه اضافه کنید.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // ارائه را روی دیسک ذخیره کنید.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

کد نمونهٔ زیر نشان می‌دهد چگونه نوع پرکنندهٔ پس‌زمینه را به تصویر کاشی‌شده تنظیم کنید و ویژگی‌های کاشی‌گذاری را تغییر دهید:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // تصویر مورد استفاده برای پرکنندهٔ پس‌زمینه را تنظیم کنید.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // حالت پرکنندهٔ تصویر را روی کاشی تنظیم کنید و ویژگی‌های کاشی را تنظیم نمایید.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}}
بیشتر بخوانید: [**کاشی تصویر به عنوان بافت**](/slides/fa/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینهٔ اسلاید را تنظیم کنید تا محتوای اسلاید برجسته‌تر شود. کد C# زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینهٔ اسلاید را تغییر دهید:

```cs
var transparencyValue = 30; // برای مثال.

// دریافت مجموعهٔ عملیات تبدیل تصویر.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// یافتن یک اثر شفافیت ثابت‑درصد موجود.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// تنظیم مقدار شفافیت جدید.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **دریافت مقدار پس‌زمینهٔ اسلاید**

Aspose.Slides رابط [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ibackgroundeffectivedata/) را برای بازیابی مقادیر مؤثر پس‌زمینهٔ یک اسلاید فراهم می‌کند. این رابط [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibackgroundeffectivedata/fillformat/) و [EffectFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibackgroundeffectivedata/effectformat/) مؤثر را در دسترس قرار می‌دهد.

با استفاده از ویژگی `background` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslide/)، می‌توانید پس‌زمینهٔ مؤثر یک اسلاید را به‌دست آورید.

کد نمونهٔ زیر به زبان C# نشان می‌دهد چگونه مقدار پس‌زمینهٔ مؤثر یک اسلاید را دریافت کنید:

```cs
// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // پس‌زمینهٔ مؤثر را دریافت کنید، به‌همراه درنظر گرفتن اسلاید اصلی، طرح‌بندی و تم.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **سوالات متداول**

**آیا می‌توانم پس‌زمینهٔ سفارشی را بازنشانی کنم و پس‌زمینهٔ تم/طرح بندی را بازگردانم؟**  
بله. پرکنندهٔ سفارشی اسلاید را حذف کنید و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/net/slide-layout/)/[master](/slides/fa/net/slide-master/) مرتبط به ارث می‌رسد (یعنی [پس‌زمینهٔ تم](/slides/fa/net/presentation-theme/)).

**چه اتفاقی برای پس‌زمینه می‌افتد اگر بعداً تم ارائه را تغییر دهم؟**  
اگر یک اسلاید پرکنندهٔ خود را داشته باشد، بدون تغییر باقی می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/net/slide-layout/)/[master](/slides/fa/net/slide-master/) ارث‌بری شود، به‌روز خواهد شد تا با [تم جدید](/slides/fa/net/presentation-theme/) مطابقت داشته باشد.