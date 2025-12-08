---
title: إنشاء وتطبيق تأثيرات WordArt في C#
linktitle: ووردآرت
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
- تأثير 3D
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- C#
- Csharp
- .NET
- Aspose.Slides
description: "تعلم كيفية إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides for .NET. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص أنيق ومهني باستخدام C#."
---

## **نظرة عامة**

تسمح تأثيرات WordArt لك بإضافة نص ذو مظهر جذاب ومُصمم إلى عروض PowerPoint الخاصة بك. باستخدام Aspose.Slides for .NET، يمكن للمطورين إنشاء WordArt وتخصيصه وإدارته برمجيًا كما في Microsoft PowerPoint — دون الحاجة لتثبيت Office. تُقدِّم هذه المقالة نظرة عامة على العمل مع WordArt في .NET، بما في ذلك كيفية تطبيق تحولات النص، أنماط التعبئة، الخطوط الخارجية، الظلال، وغيرها من خيارات التنسيق لجعل محتوى العرض أكثر تعبيرًا وجاذبية. يسمح WordArt لك بمعاملة النص ككائن رسومي. يتكون من تأثيرات أو تعديلات خاصة تُطبق على النص لجعله أكثر جاذبية أو وضوحًا.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

في هذا القسم، سنستكشف كيفية إنشاء قالب WordArt بسيط وتطبيقه على النص باستخدام Aspose.Slides for .NET. يقدم WordArt طريقة سهلة لتعزيز مظهر النص بتأثيرات بصرية ملفتة وأنماط. من خلال تعلم الخطوات الأساسية لإنشاء واستخدام WordArt، يمكنك بسهولة تعديل هذه التقنيات لتناسب أي مشروع، وجعل عروضك أكثر حيوية ولا تُنسى.

أولًا، ننشئ نصًا بسيطًا باستخدام كود C# التالي:
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


الآن، نضبط ارتفاع خط النص إلى قيمة أكبر لجعل التأثير أكثر وضوحًا باستخدام الكود التالي:
```cs
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
```


هنا، نطبق تعبئة نمط SmallGrid على النص ونضيف حدًا نصيًا أسود بعرض 1 باستخدام الكود التالي:
```cs
    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;
                
    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```


النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt أخرى**

بالإضافة إلى التحولات الأساسية، يتيح لك Aspose.Slides for .NET تطبيق مجموعة متنوعة من تأثيرات WordArt المتقدمة لتحسين مظهر نصك. وتشمل هذه الخطوط الخارجية، التعبئات، الظلال، الانعكاسات، وتأثيرات التوهج. من خلال دمج هذه الخصائص، يمكنك إنشاء أنماط نصية لافتة للنظر تتألق في عروضك. يعرض هذا القسم كيفية تطبيق هذه التأثيرات برمجيًا باستخدام أمثلة شفرة بسيطة وواضحة.

### **تطبيق تأثيرات الظل الخارجي**

تساعد تأثيرات الظل الخارجي النص على البروز بإضافة ظل خلف حدوده، مما يخلق إحساسًا بالعمق والبعد عن الخلفية. يتيح لك Aspose.Slides for .NET بسهولة تطبيق وتخصيص الظلال الخارجية على نص WordArt. في هذا القسم، ستتعلم كيفية ضبط لون الظل، الاتجاه، المسافة، نصف قطر الضبابية، وغير ذلك لتحقيق التأثير البصري المطلوب.

المقتطف التالي من كود C# يطبق تأثير ظل على النص الذي تم إنشاؤه أعلاه.
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
- عند استخدام OuterShadow و PresetShadow معًا، يُطبق تأثير OuterShadow فقط.
- إذا تم استخدام OuterShadow و InnerShadow في آنٍ واحد، يعتمد التأثير الناتج على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق فقط تأثير OuterShadow.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

في هذا القسم، نستكشف كيفية تطبيق تأثيرات الانعكاس في شرايحك باستخدام Aspose.Slides for .NET. يمكن أن تكون تأثيرات الانعكاس وسيلة فعّالة لمنح النص أو الأشكال مظهرًا أنيقًا وعصريًا، مما يساعد العناصر الرئيسية على البروز ويضيف عمقًا للعرض. من خلال فهم عملية تطبيق وتخصيص هذه التأثيرات، يمكنك بسهولة تعديلها لتتناسب مع احتياجات التصميم والهوية البصرية الخاصة بك.

أضف تأثير انعكاس إلى النص باستخدام مثال كود C# التالي:
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

في هذا القسم، نستكشف كيفية تطبيق تأثير توهج على النص باستخدام Aspose.Slides for .NET. يمكن لتأثير التوهج جعل نصك يبرز بخط خارجي مضيء، معززًا الجاذبية البصرية للشرائح. من خلال ضبط الإعدادات مثل اللون والشدة، يمكنك بسهولة تخصيص التوهج ليتلاءم مع تصميمك واحتياجات العلامة التجارية، لضمان جذب انتباه الجمهور إلى النقاط الأساسية في عرضك.

طبق تأثير توهج على النص لجعله يلمع أو يبرز باستخدام الكود التالي:
```cs
    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```


النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحولات WordArt**

في هذا القسم، نستكشف كيفية استخدام التحولات في WordArt مع Aspose.Slides for .NET. تتيح لك التحولات ثني أو تمديد أو تشويه النص، مما يخلق تأثيرات فريدة ومبهرة بصريًا. من خلال إتقان هذه التقنيات، يمكنك بسهولة تعديل أشكال النص وأنماطه لتتناسب مع هوية علامتك أو رؤيتك الإبداعية، مما يضمن عرضًا جذابًا ومصقولًا.

استخدم خاصية `Transform` (التي تُطبق على كتلة النص بالكامل) باستخدام الكود التالي:
```cs
    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```


النص الناتج:

![تحول WordArt](transform_effect.png)

{{% alert color="primary" %}} 
توفر Aspose.Slides for .NET مجموعة من [أنواع التحويل](https://reference.aspose.com/slides/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

إن إنشاء مرئيات واقعية وجذابة يمكن أن يعزز بشكل كبير من تأثير عروضك. في هذا القسم، نستكشف كيفية تطبيق تأثيرات ثلاثية الأبعاد (3D) على الأشكال باستخدام Aspose.Slides for .NET. من خلال تعديل معلمات مثل العمق، الزاوية، والإضاءة، يمكنك إنتاج تحولات ثلاثية الأبعاد مثيرة تجذب انتباه الجمهور على الفور. سواء كنت تستهدف إضاءات خفيفة أو أوهام درامية، توفر هذه الميزات طرقًا مرنة للارتقاء بتصميمك وتوصيل الأفكار بطريقة أكثر جاذبية.

استخدم الكود النموذجي التالي لتعيين تأثير ثلاثي الأبعاد على الشكل:
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

استخدم الكود النموذجي التالي لتعيين تأثير ثلاثي الأبعاد على النص:
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
تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكاله—وتفاعل هذه التأثيرات مع بعضها—تحكمها قواعد محددة. اعتبر مشهدًا يتضمن كلًا من النص والشكل الذي يحتويه. يتضمن تأثير ثلاثي الأبعاد تمثيلًا ثلاثيًا للعنصر والمشهد الذي يوضع فيه.

- إذا تم ضبط مشهد لكل من الشكل والنص، يُعطى أولوية مشهد الشكل وتُتجاهل مشهد النص.
- إذا كان الشكل يفتقر إلى مشهد خاص به ولكنه يحتوي على تمثيل ثلاثي الأبعاد، يُستخدم مشهد النص.
- إذا كان الشكل لا يحتوي على أي تأثير ثلاثي الأبعاد، يُعامل كمسطح، ويُطبق التأثير ثلاثي الأبعاد فقط على النص.

هذه السلوكيات تتعلق بخواص [ThreeDFormat.LightRig](https://reference.aspose.com/slides/net/aspose.slides/threedformat/lightrig/) و[ThreeDFormat.Camera](https://reference.aspose.com/slides/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **الأسئلة الشائعة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص بلغات مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides for .NET اليونيكود ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد regardless من اللغة، رغم أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر قالب الشريحة (Master)؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في القوالب الرئيسية، بما في ذلك عناصر النائب للعنوان، التذييل، أو النص الخلفي. سيظهر أي تعديل على القالب عبر جميع الشرائح المرتبطة به.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض؟**

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج من حجم الملف قليلًا بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تحويل الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `GetImage` من واجهات [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.