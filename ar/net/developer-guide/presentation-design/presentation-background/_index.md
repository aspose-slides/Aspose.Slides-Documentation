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
description: "تعلم كيفية ضبط خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للـ .NET، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

تُستخدم الألوان الصلبة، والتدرجات، والصور عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لـ **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (تنطبق على عدة شرائح في وقت واحد).

![خلفية PowerPoint](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. يتم تطبيق التغيير فقط على الشريحة المحددة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين خلفية الشريحة [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) إلى `Solid`.
4. استخدام الخاصية [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) في [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون أزرق صلب كخلفية لشريحة عادية:
```cs
// إنشاء نسخة من الفئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // تعيين لون خلفية الشريحة إلى الأزرق.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **تعيين خلفية بلون صلب للشريحة الرئيسية**

يتيح لك Aspose.Slides تعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عند اختيار لون صلب لخلفية الشريحة الرئيسية، يتم تطبيقه على كل شريحة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة الرئيسية (via `masters`) إلى `OwnBackground`.
3. تعيين خلفية الشريحة الرئيسية [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) إلى `Solid`.
4. استخدام [SolidFillColor] لتحديد لون الخلفية الصلب.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون صلب (أخضر غامق) كخلفية للشريحة الرئيسية:
```cs
// إنشاء نسخة من الفئة Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // تعيين لون خلفية الشريحة الرئيسية إلى أخضر الغابة.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يتم إنشاؤه بتغيير تدريجي في اللون. عند استخدامه كخلفية لشريحة، يمكن للتدرجات أن تجعل العروض تبدو أكثر فنية واحترافية. يتيح لك Aspose.Slides تعيين لون متدرج كخلفية للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين خلفية الشريحة [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) إلى `Gradient`.
4. استخدام الخاصية [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) في [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة.
5. حفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين لون متدرج كخلفية لشريحة:
```cs
// إنشاء نسخة من الفئة Presentation.
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


## **تعيين صورة كخلفية لشريحة**

بالإضافة إلى التعبئات الصلبة والمتدرجة، يتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين الخاصية [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة إلى `OwnBackground`.
3. تعيين خلفية الشريحة [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. إضافة الصورة إلى مجموعة صور العرض التقديمي.
6. استخدام الخاصية [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) في [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. حفظ العرض التقديمي المعدل.

المثال التالي بلغة C# يوضح كيفية تعيين صورة كخلفية لشريحة:
```c#
// إنشاء نسخة من الفئة Presentation.
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

    // تعيين وضع ملء الصورة إلى تجانب وضبط خصائص البلاط.
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
اقرأ المزيد: [**صورة مبلطة كقوام**](/slides/ar/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لجعل محتوى الشريحة يبرز. يُظهر الكود التالي بلغة C# كيفية تغيير الشفافية لصورة خلفية الشريحة:
```cs
var transparencyValue = 30; // على سبيل المثال.

// احصل على مجموعة عمليات تحويل الصورة.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// ابحث عن تأثير شفافية ثابت النسبة مئوية موجود.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// قم بتعيين قيمة الشفافية الجديدة.
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

يقدم Aspose.Slides الواجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) لاسترداد القيم الفعّالة لخلفية الشريحة. تُظهر هذه الواجهة الـ [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) والـ [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) الفعّالين.

باستخدام خاصية `background` في فئة [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/)، يمكنك الحصول على الخلفية الفعّالة لشريحة.

المثال التالي بلغة C# يوضح كيفية الحصول على قيمة خلفية شريحة فعّالة:
```cs
// إنشاء نسخة من الفئة Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // استرجاع الخلفية الفعّالة مع مراعاة الشريحة الرئيسية، التخطيط، والسمة.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية السمة/التخطيط؟**

نعم. احذف التعبئة المخصصة للشفريحة، وستُورِث الخلفية مرة أخرى من [تخطيط](/slides/ar/net/slide-layout/)/[رئيسي](/slides/ar/net/slide-master/) المناسب (أي [خلفية السمة](/slides/ar/net/presentation-theme/)).

**ماذا يحدث للخلفية إذا قمت بتغيير سمة العرض لاحقًا؟**

إذا كانت الشريحة تمتلك تعبئتها الخاصة، فستظل دون تغيير. إذا كان الخلفية مُورَّثة من [تخطيط](/slides/ar/net/slide-layout/)/[رئيسي](/slides/ar/net/slide-master/)، فستُحدَّث لتطابق [السمة الجديدة](/slides/ar/net/presentation-theme/).