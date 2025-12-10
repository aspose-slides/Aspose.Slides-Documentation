---
title: إدارة خلفيات العرض التقديمي في .NET
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
description: "تعلم كيفية تعيين خلفيات ديناميكية في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET، مع نصائح برمجية لتعزيز عروضك التقديمية."
---

## **نظرة عامة**

الألوان الصلبة، التدريجية، والصور تُستخدم عادةً كخلفيات للشرائح. يمكنك تعيين الخلفية لشريحة **عادية** (شريحة واحدة) أو شريحة **رئيسية** (تنطبق على عدة شرائح في آن واحد).

![PowerPoint background](powerpoint-background.png)

## **تعيين خلفية بلون صلب لشريحة عادية**

Aspose.Slides يتيح لك تعيين لون صلب كخلفية لشريحة محددة في عرض تقديمي — حتى إذا كان العرض يستخدم شريحة رئيسية. التغيير يطبق فقط على الشريحة المختارة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) لخلفية الشريحة إلى `Solid`.
4. استخدام الخاصية [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) على [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

```cs
// إنشاء نسخة من فئة Presentation.
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


## **تعيين خلفية بلون صلب لشريحة رئيسية**

Aspose.Slides يسمح لك بتعيين لون صلب كخلفية لشريحة رئيسية في عرض تقديمي. الشريحة الرئيسية تعمل كقالب يتحكم في تنسيق جميع الشرائح، لذا عند اختيار لون صلب لخلفية الشريحة الرئيسية، يطبق على كل شريحة.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشريحة الرئيسية (عبر `masters`) إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) لخلفية الشريحة إلى `Solid`.
4. استخدام الخاصية [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) لتحديد لون الخلفية الصلب.
5. احفظ العرض التقديمي المعدل.

```cs
// إنشاء نسخة من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // تعيين لون خلفية الشريحة الرئيسية إلى الأخضر الغابي.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **تعيين خلفية متدرجة لشريحة**

التدرج هو تأثير رسومي يتم إنشاؤه بتغيير اللون تدريجيًا. عند استخدامه كخلفية للشريحة، يمكن أن تجعل العروض تبدو أكثر إبداعًا واحترافية. Aspose.Slides يتيح لك تعيين لون متدرج كخلفية للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) لخلفية الشريحة إلى `Gradient`.
4. استخدام الخاصية [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) على [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتكوين إعدادات التدرج المفضلة.
5. احفظ العرض التقديمي المعدل.

```cs
// إنشاء نسخة من فئة Presentation.
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

بالإضافة إلى التعبئات الصلبة والمتدرجة، يتيح لك Aspose.Slides استخدام الصور كخلفيات للشرائح.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. تعيين [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) للشفرة إلى `OwnBackground`.
3. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) لخلفية الشريحة إلى `Picture`.
4. تحميل الصورة التي تريد استخدامها كخلفية للشفرة.
5. إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
6. استخدام الخاصية [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) على [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض التقديمي المعدل.

```c#
// إنشاء نسخة من فئة Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // تعيين خصائص صورة الخلفية.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // تحميل الصورة.
    IImage image = Images.FromFile("Tulips.jpg");
    // إضافة الصورة إلى مجموعة الصور في العرض التقديمي.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // حفظ العرض التقديمي إلى القرص.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


العينة البرمجية التالية توضح كيفية تعيين نوع ملء الخلفية إلى صورة متكررة وتعديل خصائص التكرار:
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
اقرأ المزيد: [**Tile Picture As Texture**](/slides/ar/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **تغيير شفافية صورة الخلفية**

قد ترغب في تعديل شفافية صورة خلفية الشريحة لتبرز محتويات الشريحة. الكود التالي بـ C# يوضح كيفية تغيير شفافية صورة خلفية الشريحة:
```cs
var transparencyValue = 30; // على سبيل المثال.

// احصل على مجموعة عمليات تحويل الصورة.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// ابحث عن تأثير شفافية ثابت النسبة مئوي موجود.
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
```


## **الحصول على قيمة خلفية الشريحة**

Aspose.Slides يوفر الواجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) لاسترجاع القيم الفعلية لخلفية الشريحة. هذه الواجهة تكشف عن [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) و [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) الفعليين.

باستخدام خاصية `background` في فئة [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) ، يمكنك الحصول على الخلفية الفعلية لشريحة.

```cs
// إنشاء نسخة من فئة Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // استرجاع الخلفية الفعلية مع مراعاة الشريحة الرئيسية، التخطيط، والموضوع.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **الأسئلة المتكررة**

**هل يمكنني إعادة تعيين خلفية مخصصة واستعادة خلفية القالب/التخطيط؟**

نعم. قم بإزالة التعبئة المخصصة للشفرة، وسيتم وراثة الخلفية مرة أخرى من شريحة [layout](/slides/ar/net/slide-layout/)/[master](/slides/ar/net/slide-master/) المقابلة (أي، [theme background](/slides/ar/net/presentation-theme/)).

**ماذا يحدث للخلفية إذا غيرت قالب العرض التقديمي لاحقًا؟**

إذا كانت الشريحة تحتوي على تعبئتها الخاصة، ستبقى دون تغيير. إذا كانت الخلفية مستوردة من [layout](/slides/ar/net/slide-layout/)/[master](/slides/ar/net/slide-master/)، فستُحدَّث لتتماشى مع [new theme](/slides/ar/net/presentation-theme/).