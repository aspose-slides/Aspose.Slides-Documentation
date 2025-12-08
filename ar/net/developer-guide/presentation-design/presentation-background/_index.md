---
title: إدارة خلفيات العرض التقديمي في C#
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/net/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية الصورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في آن واحد).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

Aspose.Slides يسمح لك بتعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. التغيير يطبق فقط على الشريحة المحددة.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. عيّن الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. عيّن الخاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للخلفية إلى `Solid`.
4. استخدم الخاصية [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) على [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:
```cs
// إنشاء كائن من الفئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // ضبط لون خلفية الشريحة إلى الأزرق.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **تعيين خلفية بلون صلب للشريحة الرئيسية**

Aspose.Slides يسمح لك بتعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية الشريحة الرئيسية، يُطبق على كل الشريحة.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. عيّن الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة الرئيسية (عبر `masters`) إلى `OwnBackground`.
3. عيّن الخاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للخلفية إلى `Solid`.
4. استخدم الخاصية [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون صلب (أخضر غابوي) كخلفية للشريحة الرئيسية:
```cs
// إنشاء كائن من الفئة Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // تعيين لون خلفية الشريحة الرئيسية إلى اللون الأخضر الغابي.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يُنشأ بتغيّر تدريجي في اللون. عند استخدامه كخلفية للشريحة، يمكن للتدرجات أن تجعل العروض تبدو أكثر فنية ومهنية. Aspose.Slides يسمح لك بتعيين لون متدرج كخلفية للشرائح.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. عيّن الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. عيّن الخاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للخلفية إلى `Gradient`.
4. استخدم الخاصية [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) على [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة لديك.
5. احفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون متدرج كخلفية لشريحة:
```cs
// إنشاء كائن من الفئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // تطبيق تأثير تدرج على الخلفية.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **تعيين صورة كخلفية للشريحة**

إلى جانب التعبئات الصلبة والمتدرجة، Aspose.Slides يسمح لك باستخدام الصور كخلفيات للشرائح.

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. عيّن الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. عيّن الخاصية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) للخلفية إلى `Picture`.
4. حمّل الصورة التي ترغب في استخدامها كخلفية للشريحة.
5. أضف الصورة إلى مجموعة الصور في العرض التقديمي.
6. استخدم الخاصية [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) على [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين صورة كخلفية لشريحة:
```c#
// إنشاء كائن من الفئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // تعيين خصائص صورة الخلفية.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // تحميل الصورة.
    IImage image = Images.FromFile("Tulips.jpg");
    // إضافة الصورة إلى مجموعة صور العرض التقديمي.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


العينة البرمجية التالية توضح كيفية تعيين نوع تعبئة الخلفية إلى صورة متكررة وتعديل خصائص التكرار:
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

    // تعيين الصورة المستخدمة لملء الخلفية.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // تعيين وضع ملء الصورة إلى تكرار وضبط خصائص التكرار.
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
اقرأ المزيد: [**صورة مبلطة كنقش**](/slides/ar/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. الكود التالي بلغة C# يوضح كيفية تغيير الشفافية لصورة خلفية الشريحة:
```cs
var transparencyValue = 30; // على سبيل المثال.

// Get the collection of picture transform operations.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **الحصول على قيمة خلفية الشريحة**

Aspose.Slides يوفر الواجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) لاسترجاع قيم الخلفية الفعلية للشريحة. هذه الواجهة تُظهر القيم الفعلية لكل من [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) و[EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

باستخدام خاصية `background` للفئة [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعلية للشريحة.

المثال التالي بلغة C# يوضح كيفية الحصول على قيمة الخلفية الفعلية لشريحة:
```cs
// إنشاء مثيل من الفئة Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // استرداد الخلفية الفعلية مع مراعاة الشريحة الرئيسية، التخطيط، والسمة.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **الأسئلة الشائعة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**

نعم. احذف التعبئة المخصصة للشريحة، وستُسترجع الخلفية مرة أخرى من شريحة [layout](/slides/ar/net/slide-layout/)/[master](/slides/ar/net/slide-master/) المقابلة (أي من [theme background](/slides/ar/net/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت سمة العرض التقديمي لاحقًا؟**

إذا كانت الشريحة تمتلك تعبئتها الخاصة، فستبقى كما هي. إذا كانت الخلفية مُستَورَدَة من [layout](/slides/ar/net/slide-layout/)/[master](/slides/ar/net/slide-master/)، فستُحدَّث لتطابق [السمة الجديدة](/slides/ar/net/presentation-theme/).