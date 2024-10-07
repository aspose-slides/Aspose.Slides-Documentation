---
title: خلفية العرض
type: docs
weight: 20
url: /net/presentation-background/
keywords:
- خلفية PowerPoint
- تعيين خلفية
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "تعيين خلفية في عرض PowerPoint باستخدام C# أو .NET"
---

الألوان الصلبة، والألوان المتدرجة، والصور غالبًا ما تستخدم كصور خلفية للشرائح. يمكنك تعيين الخلفية إما ل **شريحة عادية** (شريحة واحدة) أو **شريحة رئيسية** (عدة شرائح دفعة واحدة).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **تعيين لون صلب كخلفية لشريحة عادية**

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية لشريحة معينة في عرض تقديمي (حتى إذا كان يحتوي على شريحة رئيسية). يؤثر تغيير الخلفية فقط على الشريحة المحددة.

1. أنشئ نسخة من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. عيّن [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) enum للشريحة إلى `OwnBackground`.
3. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) enum لخلفية الشريحة إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض المعدل.

يوضح لك هذا الكود C# كيفية تعيين لون صلب (أزرق) كخلفية لشريحة عادية:

```c#
// Creates an instance of the Presentation class
using (Presentation pres = new Presentation())
{

    // Sets the background color for the first ISlide to Blue
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
    
    // Writes the presentation to disk
    pres.Save("ContentBG_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين لون صلب كخلفية لشريحة رئيسية**

تسمح لك Aspose.Slides بتعيين لون صلب كخلفية للشريحة الرئيسية في عرض تقديمي. تعمل الشريحة الرئيسية كقالب يحتوي على إعدادات التنسيق لجميع الشرائح. لذلك، عند اختيار لون صلب كخلفية للشريحة الرئيسية، سيتم استخدام هذه الخلفية الجديدة لجميع الشرائح.

1. أنشئ نسخة من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. عيّن [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) enum للشريحة الرئيسية (`Masters`) إلى `OwnBackground`.
3. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) enum لخلفية الشريحة الرئيسية إلى `Solid`.
4. استخدم خاصية [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتحديد لون صلب للخلفية.
5. احفظ العرض المعدل.

يوضح لك هذا الكود C# كيفية تعيين لون صلب (أخضر غابة) كخلفية لشريحة رئيسية في عرض تقديمي:

```c#
// Creates an instance of the Presentation class
using (Presentation pres = new Presentation())
{

    // Sets the background color for the Master ISlide to Forest Green
    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
    pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Writes the presentation to disk
    pres.Save("SetSlideBackgroundMaster_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين لون متدرج كخلفية لشريحة**

التدرج هو تأثير رسومي يعتمد على تغيير تدريجي في اللون. تجعل الألوان المتدرجة، عند استخدامها كخلفيات للشرائح، العروض التقديمية تبدو فنية ومحترفة. تسمح لك Aspose.Slides بتعيين لون متدرج كخلفية للشرائح في العروض التقديمية.

1. أنشئ نسخة من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. عيّن [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) enum للشريحة إلى `OwnBackground`.
3. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) enum لخلفية الشريحة الرئيسية إلى `Gradient`.
4. استخدم خاصية [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتحديد إعداد التدرج المفضل لديك.
5. احفظ العرض المعدل.

يوضح لك هذا الكود C# كيفية تعيين لون متدرج كخلفية لشريحة:

```c#
// Creates an instance of the Presentation class
using (Presentation pres = new Presentation("SetBackgroundToGradient.pptx"))
{

    // Apply Gradient effect to the Background
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
    pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Writes the presentation to disk
    pres.Save("ContentBG_Grad_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين صورة كخلفية لشريحة**

بجانب الألوان الصلبة والألوان المتدرجة، تسمح لك Aspose.Slides أيضًا بتعيين الصور كخلفية للشرائح في العروض التقديمية.

1. أنشئ نسخة من [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) class.
2. عيّن [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) enum للشريحة إلى `OwnBackground`.
3. عيّن [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) enum لخلفية الشريحة الرئيسية إلى `Picture`.
4. قم بتحميل الصورة التي تريد استخدامها كخلفية للشريحة.
5. أضف الصورة إلى مجموعة الصور الخاصة بالعرض التقديمي.
6. استخدم خاصية [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) المعروضة بواسطة [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) لتعيين الصورة كخلفية.
7. احفظ العرض المعدل.

يوضح لك هذا الكود C# كيفية تعيين صورة كخلفية لشريحة:

```c#
// Creates an instance of the Presentation class
using (Presentation pres = new Presentation("SetImageAsBackground.pptx"))
{
    // Sets conditions for background image
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
    pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Loads an image and adds it to the presentation's image collection
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Writes the presentation to disk
    pres.Save("ContentBG_Img_out.pptx", SaveFormat.Pptx);
}
```

### **تغيير شفافية صورة الخلفية**

قد ترغب في ضبط شفافية صورة خلفية الشريحة لجعل محتويات الشريحة تبرز. يوضح لك هذا الكود C# كيفية تغيير الشفافية لصورة خلفية الشريحة:

```c#
var transparencyValue = 30; // على سبيل المثال

// Gets a collection of picture transform operations
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Finds a transparency effect with fixed percentage.
var transparencyOperation = null as AlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is AlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Sets the new transparency value.
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

توفر Aspose.Slides واجهة [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) للسماح لك بالحصول على القيم الفعالة لخلفيات الشرائح. تحتوي هذه الواجهة على معلومات حول [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat) الفعالة و [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

باستخدام خاصية [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/background/) من فئة [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/)، يمكنك الحصول على القيمة الفعالة لخلفية الشريحة.

يوضح لك هذا الكود C# كيفية الحصول على القيمة الفعالة لخلفية شريحة:

```c#
// Creates an instance of the Presentation class
Presentation pres = new Presentation("SamplePresentation.pptx");

IBackgroundEffectiveData effBackground = pres.Slides[0].Background.GetEffective();

if (effBackground.FillFormat.FillType == FillType.Solid)
    Console.WriteLine("لون التعبئة: " + effBackground.FillFormat.SolidFillColor);
else
    Console.WriteLine("نوع التعبئة: " + effBackground.FillFormat.FillType);
```