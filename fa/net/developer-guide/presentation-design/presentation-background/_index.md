---
title: مدیریت پس‌زمینه‌های ارائه در .NET
linktitle: پس‌زمینه اسلاید
type: docs
weight: 20
url: /fa/net/presentation-background/
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
- .NET
- C#
- Aspose.Slides
description: "بیاموزید چگونه پس‌زمینه‌های دینامیک را در فایل‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای .NET تنظیم کنید، همراه با نکات کد برای ارتقاء ارائه‌های خود."
---
## **مقدمه**

رنگ‌های ثابت، گرادیان‌ها و تصاویر به‌طور معمول برای پس‌زمینه اسلایدها استفاده می‌شوند. می‌توانید پس‌زمینه را برای یک **اسلاید عادی** (یک اسلاید تک) یا یک **اسلاید اصلی** (در یک بار برای چندین اسلاید اعمال می‌شود) تنظیم کنید.

![پس‌زمینه پاورپوینت](powerpoint-background.png)

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید عادی**

Aspose.Slides به شما امکان می‌دهد رنگ ثابت را به‌عنوان پس‌زمینه یک اسلاید خاص در یک ارائه تنظیم کنید — حتی اگر ارائه از یک اسلاید اصلی استفاده کند. این تغییر فقط برای اسلاید انتخاب‌شده اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید را با استفاده از [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از ویژگی [SolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/solidfillcolor/) در [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/) برای تعیین رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائه تغییر یافته را ذخیره کنید.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // رنگ پس‌زمینه اسلاید را به آبی تنظیم کنید.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // ارائه را بر روی دیسک ذخیره کنید.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **تنظیم پس‌زمینه رنگ ثابت برای اسلاید اصلی**

Aspose.Slides به شما امکان می‌دهد رنگ ثابت را به‌عنوان پس‌زمینه اسلاید اصلی در یک ارائه تنظیم کنید. اسلاید اصلی به‌عنوان قالبی عمل می‌کند که قالب‌بندی تمام اسلایدها را کنترل می‌کند، بنابراین وقتی رنگ ثابت را برای پس‌زمینه اسلاید اصلی انتخاب می‌کنید، بر تمام اسلایدها اعمال می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید اصلی (از طریق `masters`) را به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید اصلی را با [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) به `Solid` تنظیم کنید.
4. از [SolidFillColor](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/solidfillcolor/) برای تعیین رنگ ثابت پس‌زمینه استفاده کنید.
5. ارائه تغییر یافته را ذخیره کنید.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // رنگ پس‌زمینه اسلاید اصلی را به سبز جنگل تنظیم کنید.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // ارائه را بر روی دیسک ذخیره کنید.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **تنظیم پس‌زمینه گرادیان برای اسلاید**

یک گرادیان یک اثر گرافیکی است که توسط تغییر تدریجی رنگ ایجاد می‌شود. وقتی به‌عنوان پس‌زمینه اسلاید استفاده می‌شود، گرادیان‌ها می‌توانند ارائه‌ها را هنری‌تر و حرفه‌ای‌تر نشان دهند. Aspose.Slides به شما امکان می‌دهد رنگ گرادیان را به‌عنوان پس‌زمینه اسلایدها تنظیم کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید را با [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) به `Gradient` تنظیم کنید.
4. از ویژگی [GradientFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/gradientformat/) در [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/) برای پیکربندی تنظیمات گرادیان مورد نظر خود استفاده کنید.
5. ارائه تغییر یافته را ذخیره کنید.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // اعمال یک افکت گرادیان به پس‌زمینه.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // ارائه را بر روی دیسک ذخیره کنید.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **تنظیم تصویر به‌عنوان پس‌زمینه اسلاید**

علاوه بر پر کردن‌های ثابت و گرادیان، Aspose.Slides به شما امکان می‌دهد از تصاویر به‌عنوان پس‌زمینه اسلایدها استفاده کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) ایجاد کنید.
2. خاصیت [BackgroundType](https://reference.aspose.com/slides/fa/net/aspose.slides/backgroundtype/) اسلاید را به `OwnBackground` تنظیم کنید.
3. پس‌زمینه اسلاید را با [FillType](https://reference.aspose.com/slides/fa/net/aspose.slides/filltype/) به `Picture` تنظیم کنید.
4. تصویری که می‌خواهید به‌عنوان پس‌زمینه اسلاید استفاده کنید، بارگذاری کنید.
5. تصویر را به مجموعه تصاویر ارائه اضافه کنید.
6. از ویژگی [PictureFillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/picturefillformat/) در [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/fillformat/) برای اختصاص تصویر به‌عنوان پس‌زمینه استفاده کنید.
7. ارائه تغییر یافته را ذخیره کنید.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // ویژگی‌های تصویر پس‌زمینه را تنظیم کنید.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // تصویر را بارگذاری کنید.
    IImage image = Images.FromFile("Tulips.jpg");
    // تصویر را به مجموعه تصاویر ارائه اضافه کنید.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // ارائه را بر روی دیسک ذخیره کنید.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

نمونه کد زیر نشان می‌دهد چگونه نوع پر کردن پس‌زمینه را به تصویر کاشی‌شده تنظیم کرده و ویژگی‌های کاشی‌گذاری را تغییر دهید:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // تصویری که برای پر کردن پس‌زمینه استفاده می‌شود را تنظیم کنید.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // حالت پر کردن تصویر را به Tile تنظیم کنید و ویژگی‌های کاشی را تنظیم کنید.
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

{{% alert color="info" %}}
بیشتر بخوانید: [**کاهش تصویر به‌عنوان بافت**](/slides/fa/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغییر شفافیت تصویر پس‌زمینه**

ممکن است بخواهید شفافیت تصویر پس‌زمینه یک اسلاید را تنظیم کنید تا محتوای اسلاید بیشتر برجسته شود. کد C# زیر نشان می‌دهد چگونه شفافیت تصویر پس‌زمینه اسلاید را تغییر دهید:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // به عنوان مثال.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // دریافت مجموعه‌ای از عملیات تبدیل تصویر.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // یافتن یک اثر شفافیت ثابت درصد موجود.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // تنظیم مقدار جدید شفافیت.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **دریافت مقدار پس‌زمینه اسلاید**

Aspose.Slides رابط‌ [IBackgroundEffectiveData](https://reference.aspose.com/slides/fa/net/aspose.slides/ibackgroundeffectivedata/) را برای دریافت مقادیر مؤثر پس‌زمینه اسلاید فراهم می‌کند. این رابط، [FillFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibackgroundeffectivedata/fillformat/) و [EffectFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibackgroundeffectivedata/effectformat/) مؤثر را در دسترس قرار می‌دهد.

با استفاده از ویژگی `background` کلاس [BaseSlide](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslide/)، می‌توانید پس‌زمینه مؤثر یک اسلاید را به دست آورید.

```cs
using Aspose.Slides;

// یک نمونه از کلاس Presentation ایجاد کنید.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // پس‌زمینه مؤثر را دریافت کنید، به‌همراه در نظر گرفتن اسلاید اصلی، طرح‌بندی و تم.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **سوالات متداول**

### آیا می‌توانم پس‌زمینه سفارشی را بازنشانی کرده و پس‌زمینه تم/چیدمان را بازیابی کنم؟

بله. پر کردن سفارشی اسلاید را حذف کنید، و پس‌زمینه دوباره از اسلاید [layout](/slides/fa/net/slide-layout/)/[master](/slides/fa/net/slide-master/) مربوطه به ارث گرفته می‌شود (یعنی [پس‌زمینه تم](/slides/fa/net/presentation-theme/)).

### اگر بعداً تم ارائه را تغییر دهم، چه اتفاقی برای پس‌زمینه می‌افتد؟

اگر یک اسلاید پر کردن خود را داشته باشد، بدون تغییر باقی می‌ماند. اگر پس‌زمینه از [layout](/slides/fa/net/slide-layout/)/[master](/slides/fa/net/slide-master/) به ارث برده شده باشد، برای همخوانی با [تم جدید](/slides/fa/net/presentation-theme/) به‌روزرسانی می‌شود.