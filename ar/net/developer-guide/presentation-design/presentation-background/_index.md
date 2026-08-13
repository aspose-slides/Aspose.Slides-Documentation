---
title: إدارة خلفيات العروض التقديمية في .NET
linktitle: خلفية الشريحة
type: docs
weight: 20
url: /ar/net/presentation-background/
keywords:
- خلفية العرض التقديمي
- خلفية الشريحة
- لون صلب
- لون متدرج
- خلفية صورة
- شفافية الخلفية
- خصائص الخلفية
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides لـ .NET، مع نصائح برمجية لتحسين عروضك التقديمية."
---
## **مقدمة**

الألوان الصلبة، والتدرجات، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تطبق على عدة شرائح في آن واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. ينطبق التغيير فقط على الشريحة المحددة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. قم بتعيين [BackgroundType](https://reference.aspose.com/slides/ar/net/aspose.slides/backgroundtype/) إلى `OwnBackground` .
3. قم بتعيين خلفية الشريحة [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) إلى `Solid` .
4. استخدم الخاصية [SolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/solidfillcolor/) على [FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب .
5. احفظ العرض المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء مثيل من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // ضبط لون خلفية الشريحة إلى اللون الأزرق.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // حفظ العرض التقديمي على القرص.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **تعيين خلفية بلون صلب لشريحة رئيسية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. تعمل الشريحة الرئيسية كقالب يتحكم في تنسيق جميع الشرائح، لذا عندما تختار لونًا صلبًا لخلفية الشريحة الرئيسية، يتم تطبيقه على كل شريحة.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. قم بتعيين [BackgroundType](https://reference.aspose.com/slides/ar/net/aspose.slides/backgroundtype/) لشريحة الرئيس (من خلال `masters`) إلى `OwnBackground` .
3. قم بتعيين خلفية الشريحة الرئيسية [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) إلى `Solid` .
4. استخدم [SolidFillColor](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/solidfillcolor/) لتحديد لون الخلفية الصلب .
5. احفظ العرض المعدل.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء مثيل من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // تعيين لون خلفية الشريحة الرئيسية إلى أخضر غابي.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // حفظ العرض التقديمي على القرص.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يُنشأ بتغير تدريجي في اللون. عند استخدامه كخلفية للشفرة، يمكن للتدرجات أن تجعل العروض تبدو أكثر فنًا واحترافية. يتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. قم بتعيين [BackgroundType](https://reference.aspose.com/slides/ar/net/aspose.slides/backgroundtype/) إلى `OwnBackground` .
3. قم بتعيين خلفية الشريحة [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) إلى `Gradient` .
4. استخدم الخاصية [GradientFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/gradientformat/) على [FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/) لتكوين الإعدادات المتدرجة المفضلة لديك .
5. احفظ العرض المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون متدرج كخلفية لشريحة:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء مثيل من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // تطبيق تأثير تدرج على الخلفية.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // حفظ العرض التقديمي على القرص.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **تعيين صورة كخلفية للشفرة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، يتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) .
2. قم بتعيين [BackgroundType](https://reference.aspose.com/slides/ar/net/aspose.slides/backgroundtype/) إلى `OwnBackground` .
3. قم بتعيين خلفية الشريحة [FillType](https://reference.aspose.com/slides/ar/net/aspose.slides/filltype/) إلى `Picture` .
4. حمل الصورة التي تريد استخدامها كخلفية للشفرة .
5. أضف الصورة إلى مجموعة صور العرض .
6. استخدم الخاصية [PictureFillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/picturefillformat/) على [FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/fillformat/) لتعيين الصورة كخلفية .
7. احفظ العرض المعدل .

المثال التالي بلغة C# يوضح كيفية تعيين صورة كخلفية لشريحة:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء مثيل من فئة Presentation.
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

    // حفظ العرض التقديمي على القرص.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

المثال التالي يوضح كيفية تعيين نوع تعبئة الخلفية إلى صورة مكررة وتعديل خصائص التكرار:

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

    // تعيين الصورة المستخدمة لتعبئة الخلفية.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // تعيين وضع تعبئة الصورة إلى تجانب وضبط خصائص التبليط.
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

اقرأ المزيد: [**صورة مبلّطة كنقشة**](/slides/ar/net/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتويات الشريحة تبرز. الكود التالي بلغة C# يوضح لك كيفية تغيير الشفافية لصورة خلفية الشريحة:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // على سبيل المثال.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // الحصول على مجموعة عمليات تحويل الصورة.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // العثور على تأثير شفافية ثابت النسبة المئوية موجود.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // تعيين قيمة الشفافية الجديدة.
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

## **الحصول على قيمة خلفية الشريحة**

يوفر Aspose.Slides الواجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/ar/net/aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعلية لخلفية الشريحة. تُظهر هذه الواجهة الـ [FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibackgroundeffectivedata/fillformat/) والـ [EffectFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/ibackgroundeffectivedata/effectformat/) الفعليين.

باستخدام الخاصية `background` للصف `BaseSlide`، يمكنك الحصول على الخلفية الفعلية لشريحة.

المثال التالي بلغة C# يوضح كيفية الحصول على قيمة الخلفية الفعلية لشريحة:

```cs
using Aspose.Slides;

// إنشاء مثيل من فئة Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // استرجاع الخلفية الفعلية مع الأخذ في الاعتبار الرئيس، التخطيط، والسمة.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **الأسئلة المتكررة**

### هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟

نعم. أزل التعبئة المخصصة للشفرة، وستُستَرجع الخلفية مرة أخرى من شريحة [التخطيط](/slides/ar/net/slide-layout/)/[الرئيسية](/slides/ar/net/slide-master/) المقابلة (أي [خلفية السمة](/slides/ar/net/presentation-theme/)).

### ماذا يحدث للخلفية إذا غيرت سمة العرض لاحقًا؟

إذا كانت الشريحة تحتوي على تعبئة خاصة بها، فستظل دون تغيير. إذا كانت الخلفية مُستَمدة من [التخطيط](/slides/ar/net/slide-layout/)/[الرئيسية](/slides/ar/net/slide-master/)، فستُحدّث لتطابق [السمة الجديدة](/slides/ar/net/presentation-theme/).