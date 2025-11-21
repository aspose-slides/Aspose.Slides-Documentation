---
title: إنشاء وتطبيق تأثيرات WordArt في .NET
linktitle: WordArt
type: docs
weight: 110
url: /ar/net/wordart/
keywords:
- WordArt
- إنشاء WordArt
- قالب WordArt
- تأثير WordArt
- تأثير الظل
- تأثير العرض
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لـ .NET. يوضح هذا الدليل خطوة بخطوة كيفية مساعدة المطورين على تحسين العروض التقديمية بنص احترافي باستخدام C#."
---

## **نظرة عامة**

تسمح تأثيرات WordArt لك بإضافة نص مصمم بصريًا وجذاب إلى عروض PowerPoint الخاصة بك. باستخدام Aspose.Slides for .NET، يمكن للمطورين إنشاء WordArt وتخصيصه وإدارته برمجيًا كما في Microsoft PowerPoint—دون الحاجة إلى تثبيت Office. تُقدم هذه المقالة نظرة عامة على العمل مع WordArt في .NET، بما في ذلك كيفية تطبيق تحولات النص، أنماط التعبئة، الحدود، الظلال، وغيرها من خيارات التنسيق لجعل محتوى العرض أكثر تعبيرًا وجاذبية. يتيح WordArtTreat النص ككائن رسومي. ويتكون من تأثيرات أو تعديلات خاصة تُطبق على النص لجعله أكثر جاذبية أو بروزًا.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

في هذا القسم، سنستكشف كيفية إنشاء قالب WordArt بسيط وتطبيقه على النص باستخدام Aspose.Slides for .NET. يوفر WordArt طريقة سهلة لتعزيز مظهر النص بتأثيرات بصرية وأنماط ملفتة. من خلال تعلم الخطوات الأساسية لإنشاء واستخدام WordArt، يمكنك تكييف هذه التقنيات بسهولة لأي مشروع، مما يجعل عروضك أكثر حيوية ولا تُنسى.

أولاً، نُنشئ نصًا بسيطًا باستخدام شفرة C# التالية:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;

    IPortion portion = textFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
}
```


الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا باستخدام الشفرة التالية:
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


هنا، نُطبق تعبئة نمط SmallGrid على النص ونضيف حدًا نصيًا أسود بعرض 1 باستخدام الشفرة التالية:
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


النص الناتج:

![القالب البسيط لـ WordArt](WordArt_template.png)

## **تطبيق تأثيرات WordArt أخرى**

بالإضافة إلى التحولات الأساسية، يتيح لك Aspose.Slides for .NET تطبيق مجموعة متنوعة من تأثيرات WordArt المتقدمة لتعزيز مظهر النص. تشمل هذه الحدود، التعبئات، الظلال، الانعكاسات، وتأثيرات التوهج. من خلال دمج هذه الميزات، يمكنك إنشاء أنماط نصية جذابة تبرز في عروضك. يوضح هذا القسم كيفية تطبيق هذه التأثيرات برمجيًا باستخدام أمثلة شفرة بسيطة ونظيفة.

### **تطبيق تأثيرات الظل الخارجي**

تساعد تأثيرات الظل الخارجي النص على البروز عن طريق إضافة ظل خلف حدوده، مما يخلق إحساسًا بالعمق والانعزال عن الخلفية. يتيح لك Aspose.Slides for .NET تطبيق وضبط الظلال الخارجية على نص WordArt بسهولة. في هذا القسم، ستتعلم كيفية ضبط لون الظل، الاتجاه، المسافة، نصف قطر الضبابية، وغير ذلك لتحقيق التأثير البصري المطلوب.

المقتطف التالي من شفرة C# يطبق تأثير ظل على النص الذي تم إنشاؤه أعلاه.
```cs
    portion.PortionFormat.EffectFormat.EnableOuterShadowEffect();
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Black;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleHorizontal = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ScaleVertical = 100;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.BlurRadius = 4;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Direction = 230;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.Distance = 30;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewHorizontal = 20;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.SkewVertical = 0;
    portion.PortionFormat.EffectFormat.OuterShadowEffect.ShadowColor.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.32f);
```


النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="primary" %}} 
- عندما يُستخدم OuterShadow و PresetShadow معًا، يُطبق فقط تأثير OuterShadow.
- إذا استُخدم OuterShadow و InnerShadow في آنٍ واحد، يعتمد التأثير الناتج على نسخة PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق فقط تأثير OuterShadow.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

في هذا القسم، سنستكشف كيفية تطبيق تأثيرات الانعكاس في الشرائح باستخدام Aspose.Slides for .NET. يمكن أن تكون تأثيرات الانعكاس وسيلة فعّالة لمنح النص أو الأشكال مظهرًا أنيقًا وعصريًا، مما يساعد العناصر الرئيسية على البروز وإضافة عمق إلى العرض. من خلال فهم عملية تطبيق وتخصيص هذه التأثيرات، يمكنك تعديلها بسهولة لتتناسب مع احتياجات التصميم والعلامة التجارية.

أضف تأثير انعكاس إلى النص باستخدام مثال شفرة C# التالي:
```cs
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


النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهج**

في هذا القسم، سنستكشف كيفية تطبيق تأثير توهج على النص باستخدام Aspose.Slides for .NET. يمكن لتأثير التوهج أن يجعل نصك يبرز بخط خارجي لامع، مما يعزز الجاذبية البصرية للشرائح. من خلال ضبط إعدادات مثل اللون والشدة، يمكنك تعديل التوهج ليناسب تصميمك واحتياجات علامتك التجارية، ensuring that key points in your presentation capture the audience’s attention.

طبق تأثير توهج على النص لجعله يلمع أو يبرز باستخدام الشفرة التالية:
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحولات WordArt**

في هذا القسم، سنستكشف كيفية استخدام التحولات في WordArt مع Aspose.Slides for .NET. تسمح التحولات بإنحناء أو تمدد أو تشويه النص، ما يخلق تأثيرات فريدة وجذابة بصريًا. من خلال إتقان هذه التقنيات، يمكنك تعديل أشكال النص وأنماطه لتلائم علامتك التجارية أو رؤيتك الإبداعية، مما يضمن عرضًا مقنعًا ومصقولًا.

استخدم خاصية `Transform` (التي تُطبق على كتلة النص بالكامل) باستخدام الشفرة التالية:
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


النص الناتج:

![تحول WordArt](transform_effect.png)

{{% alert color="primary" %}} 
يوفر Aspose.Slides for .NET مجموعة من [أنواع التحول المحددة مسبقًا](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

إنشاء مرئيات واقعية وجذابة يمكن أن يعزز بشكل كبير من تأثير عروضك. في هذا القسم، سنستكشف كيفية تطبيق تأثيرات ثلاثية الأبعاد (3D) على الأشكال باستخدام Aspose.Slides for .NET. من خلال تعديل معلمات مثل العمق، الزاوية، والإضاءة، يمكنك إنتاج تحولات ثلاثية الأبعاد مذهلة تجذب انتباه جمهورك فورًا. سواء كنت تستهدف تظليلًا خفيفًا أو أوهامًا دراماتيكية، توفر هذه الميزات طرقًا مرنة لرفع مستوى التصميم وإيصال الأفكار بطريقة أكثر تشويقًا.

استخدم الشفرة النموذجية التالية لتعيين تأثير ثلاثي الأبعاد على الشكل:
```cs
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


الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

استخدم الشفرة النموذجية التالية لتعيين تأثير ثلاثي الأبعاد على النص:
```cs
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


النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="primary" %}} 
يخضع تطبيق تأثيرات 3D على النص أو أشكاله—والتفاعل بين هذه التأثيرات—لعدة قواعد محددة. ضع في اعتبارك سيناريوً يشمل كلًا من النص والشكل الذي يحتوي على ذلك النص. يتضمن تأثير 3D تمثيل الكائن ثلاثي الأبعاد والمشهد الذي يُوضع فيه.

- إذا تم تعيين مشهد لكلٍ من الشكل والنص، يُعطى أولوية لمشهد الشكل ويُتجاهل مشهد النص.
- إذا كان الشكل يفتقر إلى مشهد خاص به ولكن له تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص.
- إذا كان الشكل لا يحتوي على أي تأثير ثلاثي الأبعاد، يُعامل كمسطح، ويُطبق تأثير 3D فقط على النص.

هذه السلوكيات تتعلق بخصائص [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) و[ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **FAQ**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides for .NET Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر ماستر الشريحة؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في ماستر الشرائح، بما في ذلك عناصر النائب للعنوان، التذييلات، أو النص الخلفي. ستنعكس التغييرات التي تُجرى على تخطيط الماستر على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

تأثيرًا طفيفًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج من حجم الملف قليلًا بسبب إضافة بيانات تنسيق، لكن الفارق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.