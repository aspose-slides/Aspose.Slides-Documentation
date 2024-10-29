---
title: وورد آرت
type: docs
weight: 110
url: /ar/net/wordart/
keywords: "وورد آرت، فن الكتابة، إنشاء وورد آرت، قالب وورد آرت، تأثيرات وورد آرت، تأثيرات الظل، تأثيرات العرض، تأثيرات الوهج، تحولات وورد آرت، تأثيرات ثلاثية الأبعاد، تأثيرات الظل الخارجي، تأثيرات الظل الداخلي، C#، Csharp، Aspose.Slides لـ .NET"
description: "إضافة وتعديل وإدارة وورد آرت وتأثيراته في عروض PowerPoint باستخدام C# أو Aspose.Slides لـ .NET"
---

## **ما هو وورد آرت؟**
وورد آرت هو ميزة تسمح لك بتطبيق تأثيرات على النصوص لجعلها تبرز. مع وورد آرت، على سبيل المثال، يمكنك تحديد نص أو ملؤه بلون (أو تدرج)، أو إضافة تأثيرات ثلاثية الأبعاد، إلخ. يمكنك أيضًا تشويه أو ثني أو تمديد شكل النص. 

{{% alert color="primary" %}} 

يتيح لك وورد آرت التعامل مع النص كما لو كان كائنًا رسوميًا. تتكون وورد آرت من تأثيرات أو تعديلات خاصة يتم تطبيقها على النصوص لجعلها أكثر جذبًا أو ملحوظية. 

{{% /alert %}} 

**وورد آرت في Microsoft PowerPoint**

لاستخدام وورد آرت في Microsoft PowerPoint، يجب عليك اختيار أحد قوالب وورد آرت المحددة مسبقًا. قالب وورد آرت هو مجموعة من التأثيرات التي تُطبق على نص أو شكله. 

**وورد آرت في Aspose.Slides**

في Aspose.Slides لـ .NET 20.10، قمنا بتنفيذ دعم لوورد آرت وأدخلنا تحسينات على الميزة في الإصدارات التالية من Aspose.Slides لـ .NET. 

مع Aspose.Slides لـ .NET، يمكنك بسهولة إنشاء قالب وورد آرت الخاص بك (تأثير واحد أو مجموعة من التأثيرات) في C# وتطبيقه على النصوص. 

## إنشاء قالب وورد آرت بسيط وتطبيقه على نص

**باستخدام Aspose.Slides** 

أولاً، نقوم بإنشاء نص بسيط باستخدام هذا الكود C#: 

``` csharp 
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    Portion portion = (Portion)textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```
الآن، نقوم بتعيين ارتفاع خط النص لقيمة أكبر لجعل التأثير أكثر وضوحًا من خلال هذا الكود:

``` csharp 
FontData fontData = new FontData("Arial Black");
portion.PortionFormat.LatinFont = fontData;
portion.PortionFormat.FontHeight = 36;
```

**باستخدام Microsoft PowerPoint**

اذهب إلى قائمة تأثيرات وورد آرت في Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

من القائمة على اليمين، يمكنك اختيار تأثير وورد آرت محدد مسبقًا. من القائمة على اليسار، يمكنك تحديد إعدادات لوورد آرت جديد. 

هذه بعض المعلمات أو الخيارات المتاحة:

![todo:image_alt_text](image-20200930114015-3.png)

**باستخدام Aspose.Slides**

هنا، نقوم بتطبيق لون نمط SmallGrid على النص ونضيف حد نص أسود بعرض 1 باستخدام هذا الكود:

``` csharp 
portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
            
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

النص الناتج:

![todo:image_alt_text](image-20200930114108-4.png)

## تطبيق تأثيرات وورد آرت الأخرى

**باستخدام Microsoft PowerPoint**

من واجهة البرنامج، يمكنك تطبيق هذه التأثيرات على نص أو كتلة نص أو شكل أو عنصر مشابه:

![todo:image_alt_text](image-20200930114129-5.png)

على سبيل المثال، يمكن تطبيق تأثيرات الظل والانعكاس والوهج على نص؛ يمكن تطبيق تأثيرات التنسيق ثلاثي الأبعاد والدوران ثلاثي الأبعاد على كتلة نص؛ يمكن تطبيق خاصية الحواف الناعمة على كائن الشكل (لا يزال لها تأثير عند عدم تعيين خاصية التنسيق ثلاثي الأبعاد). 

### تطبيق تأثيرات الظل

هنا، نهدف إلى تعيين الخصائص المتعلقة بالنص فقط. نقوم بتطبيق تأثير الظل على نص باستخدام هذا الكود في C#:

``` csharp 
portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 65;
portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4.73;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 2;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 30;
portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```

يدعم واجهة برمجة التطبيقات Aspose.Slides ثلاثة أنواع من الظلال: الظل الخارجي، الظل الداخلي، والظل المحدد مسبقًا. 

 مع الظل المحدد مسبقًا، يمكنك تطبيق ظل على نص (باستخدام القيم المحددة مسبقًا). 

**باستخدام Microsoft PowerPoint**

في PowerPoint، يمكنك استخدام نوع واحد من الظل. إليك مثال:

![todo:image_alt_text](image-20200930114225-6.png)

**باستخدام Aspose.Slides**

يسمح Aspose.Slides بالفعل بتطبيق نوعين من الظلال في وقت واحد: الظل الداخلي والظل المحدد مسبقًا.

**ملاحظات:**

- عند استخدام الظل الخارجي والظل المحدد مسبقًا معًا، يتم تطبيق تأثير الظل الخارجي فقط. 
- إذا تم استخدام الظل الخارجي والظل الداخلي في نفس الوقت، فإن التأثير الناتج أو المطبق يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013، يتضاعف التأثير. ولكن في PowerPoint 2007، يتم تطبيق تأثير الظل الخارجي. 

### تطبيق العرض على النصوص

نضيف العرض إلى النص من خلال هذا العينة من الكود في C#:

``` csharp 
portion.PortionFormat.EffectFormat.EnableReflectionEffect();
portion.PortionFormat.EffectFormat.ReflectionEffect.BlurRadius = 0.5; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Distance = 4.72; 
portion.PortionFormat.EffectFormat.ReflectionEffect.StartPosAlpha = 0f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.EndPosAlpha = 60f; 
portion.PortionFormat.EffectFormat.ReflectionEffect.Direction = 90; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleHorizontal = 100; 
portion.PortionFormat.EffectFormat.ReflectionEffect.ScaleVertical = -100;
portion.PortionFormat.EffectFormat.ReflectionEffect.StartReflectionOpacity = 60f;
portion.PortionFormat.EffectFormat.ReflectionEffect.EndReflectionOpacity = 0.9f;
portion.PortionFormat.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.BottomLeft;   
```

### تطبيق تأثير الوهج على النصوص

نقوم بتطبيق تأثير الوهج على النص لجعله يتألق أو يبرز باستخدام هذا الكود:

``` csharp 
portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

نتيجة العملية:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

يمكنك تغيير المعلمات الخاصة بالظل والعرض والوهج. يتم تعيين خصائص التأثيرات على كل جزء من النص بشكل منفصل. 

{{% /alert %}} 

### استخدام التحولات في وورد آرت

نستخدم خاصية Transform (الموروثة في الكتلة الكاملة من النص) من خلال هذا الكود:
``` csharp 
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

النتيجة:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

كل من Microsoft PowerPoint وAspose.Slides لـ .NET يوفران عددًا معينًا من أنواع التحولات المحددة مسبقًا. 

{{% /alert %}} 

**باستخدام PowerPoint**

للوصول إلى أنواع التحولات المحددة مسبقًا، اذهب إلى: **التنسيق** -> **تأثير النص** -> **تحول**

**باستخدام Aspose.Slides**

لاختيار نوع تحول، استخدم enum TextShapeType. 

### تطبيق تأثيرات ثلاثية الأبعاد على النصوص والأشكال

نقوم بتعيين تأثير ثلاثي الأبعاد على شكل نص باستخدام هذه العينة من الكود:

``` csharp 
autoShape.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelBottom.Height = 10.5;
autoShape.ThreeDFormat.BevelBottom.Width = 10.5;

autoShape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
autoShape.ThreeDFormat.BevelTop.Height = 12.5;
autoShape.ThreeDFormat.BevelTop.Width = 11;

autoShape.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
autoShape.ThreeDFormat.ExtrusionHeight = 6;

autoShape.ThreeDFormat.ContourColor.Color = Color.DarkRed;
autoShape.ThreeDFormat.ContourWidth = 1.5;

autoShape.ThreeDFormat.Depth = 3;

autoShape.ThreeDFormat.Material = MaterialPresetType.Plastic;

autoShape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
autoShape.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

النص الناتج وشكله:

![todo:image_alt_text](image-20200930114816-9.png)

نقوم بتطبيق تأثير ثلاثي الأبعاد على النص باستخدام هذا الكود C#:

``` csharp 
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight= 6;

textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

textFrame.TextFrameFormat.ThreeDFormat.Depth= 3;

textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
```

نتيجة العملية:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

يستند تطبيق تأثيرات ثلاثية الأبعاد على النصوص أو أشكالها والتفاعلات بين التأثيرات إلى قواعد معينة. 

اعتبر مشهدًا لنص والشكل الذي يحتوي على هذا النص. يحتوي التأثير ثلاثي الأبعاد على تمثيل كائن ثلاثي الأبعاد والمشهد الذي وُضِع فيه الكائن. 

- عندما يتم تعيين المشهد لكل من الشكل والنص، يحصل مشهد الشكل على الأولوية العليا - يتم تجاهل مشهد النص. 
- عندما يفتقر الشكل إلى مشهده الخاص ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يتم استخدام مشهد النص. 
- بخلاف ذلك - عندما يكون الشكل أصلاً بلا تأثير ثلاثي الأبعاد - يكون الشكل مسطحًا ويتم تطبيق التأثير ثلاثي الأبعاد فقط على النص. 

تتصل الأوصاف بـ [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/lightrig) و [ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/properties/camera) الخصائص.

{{% /alert %}} 

## **تطبيق تأثيرات الظل الخارجي على النصوص**
توفر Aspose.Slides لـ .NET [**IOuterShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow) و[**IInnerShadow**](https://reference.aspose.com/slides/net/aspose.slides.effects/iinnershadow) الفئات التي تتيح لك تطبيق تأثيرات الظل على النص الموجود في TextFrame. اتبع هذه الخطوات:

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع لشريحة باستخدام فهرسها.
3. أضف AutoShape من نوع مستطيل إلى الشريحة.
4. الوصول إلى TextFrame المرتبط بـ AutoShape.
5. قم بتعيين FillType لـ AutoShape إلى NoFill.
6. مثّل صف الظل الخارجي
7. قم بتعيين BlurRadius للظل.
8. قم بتعيين Direction للظل
9. قم بتعيين Distance للظل.
10. قم بتعيين RectangleAlign إلى TopLeft.
11. قم بتعيين اللون المحدد مسبقًا للظل إلى الأسود.
12. اكتب العرض كملف PPTX.

هذا الكود التجريبي في C# - تنفيذ الخطوات أعلاه - يوضح لك كيفية تطبيق تأثير الظل الخارجي على نص:

```c#
using (Presentation pres = new Presentation())
{

    // احصل على مرجع الشريحة
    ISlide sld = pres.Slides[0];

    // أضف AutoShape من نوع مستطيل
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // أضف TextFrame إلى المستطيل
    ashp.AddTextFrame("Aspose TextBox");

    // تعطيل ملء الشكل في حالة رغبتنا في الحصول على ظل للنص
    ashp.FillFormat.FillType = FillType.NoFill;

    // أضف الظل الخارجي وقم بتعيين جميع المعلمات اللازمة
    ashp.EffectFormat.EnableOuterShadowEffect();
    IOuterShadow shadow = ashp.EffectFormat.OuterShadowEffect;
    shadow.BlurRadius = 4.0;
    shadow.Direction = 45;
    shadow.Distance = 3;
    shadow.RectangleAlign = RectangleAlignment.TopLeft;
    shadow.ShadowColor.PresetColor = PresetColor.Black;

    // اكتب العرض إلى القرص
    pres.Save("pres_out.pptx", SaveFormat.Pptx);
}
```


## **تطبيق تأثير الظل الداخلي على الأشكال**
اتبع هذه الخطوات:

1. أنشئ مثيلًا لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. احصل على مرجع للشريحة.
3. أضف AutoShape من النوع المستطيل.
4. قم بتمكين InnerShadowEffect.
5. قم بتعيين جميع المعلمات اللازمة.
6. قم بتعيين ColorType كخطة.
7. قم بتعيين لون الخطة.
8. احفظ العرض كملف [PPTX](https://docs.fileformat.com/presentation/pptx/)  .

هذا الكود التجريبي (الذي يستند إلى الخطوات أعلاه) يوضح لك كيفية إضافة موصل بين شكلين في C#:

```c#
using(Presentation presentation = new Presentation())
{
    // احصل على مرجع للشريحة
    ISlide slide = presentation.Slides[0];

    // أضف AutoShape من نوع مستطيل
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.FillFormat.FillType = FillType.NoFill;

    // أضف TextFrame إلى المستطيل
    ashp.AddTextFrame("Aspose TextBox");
    IPortion port = ashp.TextFrame.Paragraphs[0].Portions[0];
    IPortionFormat pf = port.PortionFormat;
    pf.FontHeight = 50;

    // تمكّن InnerShadowEffect    
    IEffectFormat ef = pf.EffectFormat;
    ef.EnableInnerShadowEffect();

    // قم بتعيين جميع المعلمات اللازمة
    ef.InnerShadowEffect.BlurRadius = 8.0;
    ef.InnerShadowEffect.Direction = 90.0F;
    ef.InnerShadowEffect.Distance = 6.0;
    ef.InnerShadowEffect.ShadowColor.B = 189;

    // قم بتعيين ColorType كخطة
    ef.InnerShadowEffect.ShadowColor.ColorType = ColorType.Scheme;

    // قم بتعيين لون الخطة
    ef.InnerShadowEffect.ShadowColor.SchemeColor = SchemeColor.Accent1;

    // احفظ العرض
    presentation.Save("WordArt_out.pptx", SaveFormat.Pptx);
}
```