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
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لـ .NET. يساعد هذا الدليل خطوة بخطوة المطورين على تحسين العروض التقديمية بنص احترافي باستخدام C#."
---
## **نظرة عامة**

تتيح تأثيرات WordArt لك إضافة نص مصمم وجذاب بصريًا إلى عروض PowerPoint التقديمية. مع Aspose.Slides for .NET، يمكن للمطورين إنشاء WordArt وتخصيصه وإدارته برمجيًا تمامًا كما في Microsoft PowerPoint—دون الحاجة لتثبيت Office. توفر هذه المقالة نظرة عامة على التعامل مع WordArt في .NET، بما في ذلك كيفية تطبيق تحويلات النص، أنماط التعبئة، الحدود، الظلال، وخيارات تنسيق أخرى لجعل محتوى العرض أكثر تعبيرًا وإشراكًا. يتيح WordArt لك معاملة النص ككائن رسومي. وهو يتكون من تأثيرات أو تعديل خاص يُطبق على النص لجعله أكثر جاذبية أو بروزًا.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

في هذا القسم، نستكشف كيفية إنشاء قالب WordArt بسيط وتطبيقه على النص باستخدام Aspose.Slides for .NET. يقدم WordArt طريقة سهلة لتعزيز مظهر النص بتأثيرات بصرية ونمطية لافتة. من خلال تعلم الخطوات الأساسية لإنشاء واستخدام WordArt، يمكنك تعديل هذه التقنيات بسهولة لتناسب أي مشروع، مما يجعل عروضك أكثر حيوية ولا تُنسى.

أولاً، ننشئ نصًا بسيطًا باستخدام كود C# التالي:

```cs
using Aspose.Slides;

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
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";

    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;
}
```

هنا، نطبق تعبئة بنمط SmallGrid على النص ونضيف حدًا نصيًا أسود بسمك 1 باستخدام الكود التالي:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
    portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
    portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
    portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

    portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
    portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
}
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt أخرى**

بالإضافة إلى التحويلات الأساسية، يتيح لك Aspose.Slides for .NET تطبيق مجموعة متنوعة من تأثيرات WordArt المتقدمة لتعزيز مظهر النص. تشمل هذه التأثيرات الحدود، التعبئات، الظلال، الانعكاسات، وتأثيرات التوهج. من خلال دمج هذه الميزات، يمكنك إنشاء أنماط نصية ملفتة للانتباه تبرز في عروضك. يوضح هذا القسم كيفية تطبيق هذه التأثيرات برمجيًا باستخدام أمثلة شفرة بسيطة ونظيفة.

### **تطبيق تأثيرات الظل الخارجي**

تساعد تأثيرات الظل الخارجي النص على البروز عبر إضافة ظل خلف حدوده، مما يخلق إحساسًا بالعمق والفصل عن الخلفية. يتيح لك Aspose.Slides for .NET تطبيق وتخصيص الظلال الخارجية على نص WordArt بسهولة. في هذا القسم، ستتعلم كيفية تعيين لون الظل، الاتجاه، المسافة، نصف قطر الضبابية، وغيرها لتحقيق التأثير البصري المطلوب.

يطبق مقطع كود C# التالي تأثير الظل على النص الذي تم إنشاؤه أعلاه.

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

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
}
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" %}} 
- عند استخدام OuterShadow و PresetShadow معًا، يتم تطبيق تأثير OuterShadow فقط.
- إذا تم استخدام OuterShadow و InnerShadow في آنٍ واحد، يعتمد التأثير الناتج على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يتم تطبيق تأثير OuterShadow فقط.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

في هذا القسم، نستكشف كيفية تطبيق تأثيرات الانعكاس في شرائحك باستخدام Aspose.Slides for .NET. يمكن أن تكون تأثيرات الانعكاس وسيلة فعالة لمنح النص أو الأشكال مظهرًا أنيقًا وعصريًا، مما يساعد العناصر الأساسية على البروز وإضافة عمق للعرض. من خلال فهم عملية تطبيق وتخصيص هذه التأثيرات، يمكنك تعديلها بسهولة لتتناسب مع احتياجات التصميم والعلامة التجارية.

أضف تأثير انعكاس إلى النص باستخدام مثال كود C# التالي:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

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
}
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهج**

في هذا القسم، نستكشف كيفية تطبيق تأثير توهج على النص باستخدام Aspose.Slides for .NET. يمكن لتأثير التوهج أن يجعل نصك يبرز بحدود مضيئة، مما يعزز الجاذبية البصرية لشرائحك. من خلال ضبط الإعدادات مثل اللون والشدة، يمكنك تعديل التوهج ليتناسب مع التصميم والهوية البصرية، وضمان جذب انتباه الجمهور للنقاط الرئيسية في عرضك.

طبق تأثير توهج على النص لجعله يلمع أو يبرز باستخدام الكود التالي:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
    portion.Text = "Aspose.Slides";
    portion.PortionFormat.LatinFont = new FontData("Arial Black");
    portion.PortionFormat.FontHeight = 36;

    portion.PortionFormat.EffectFormat.EnableGlowEffect();
    portion.PortionFormat.EffectFormat.GlowEffect.Color.R = 255;
    portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
}
```

النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق التحويلات على WordArt**

في هذا القسم، نستكشف كيفية استخدام التحويلات في WordArt مع Aspose.Slides for .NET. تسمح لك التحويلات بإنحناء أو تمديد أو تشويه النص، مما يخلق تأثيرات فريدة ومرئية جذابة. من خلال إتقان هذه التقنيات، يمكنك تعديل أشكال النص وأنماطه لتتناسب مع العلامة التجارية أو الرؤية الإبداعية، مما يضمن عرضًا محترفًا ومقنعًا.

استخدم الخاصية `Transform` (التي تُطبق على كتلة النص بالكامل) باستخدام الكود التالي:

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
}
```

النص الناتج:

![تحويل WordArt](transform_effect.png)

{{% alert color="info" %}} 
توفر Aspose.Slides for .NET مجموعة من [أنواع التحويل](https://reference.aspose.com/slides/ar/net/aspose.slides/textshapetype/).
{{% /alert %}} 

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

يمكن أن يؤدي إنشاء رسومات واقعية وجذابة إلى تعزيز كبير لتأثير عروضك. في هذا القسم، نستكشف كيفية تطبيق تأثيرات ثلاثية الأبعاد (3D) على الأشكال باستخدام Aspose.Slides for .NET. من خلال تعديل معلمات مثل العمق، الزاوية، والإضاءة، يمكنك إنتاج تحويلات ثلاثية الأبعاد مبهرة تجذب انتباه الجمهور فورًا. سواء كنت تستهدف تظليلًا خفيفًا أو أوهامًا دراماتيكية، توفر هذه الميزات طرقًا مرنة لرفع تصميمك وتوصيل الأفكار بطريقة أكثر جذبًا.

استخدم عيّنات الكود التالية لتعيين تأثير ثلاثي الأبعاد على الشكل:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.TextFrame.Text = "Aspose.Slides";

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
}
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

استخدم عيّنات الكود التالية لتعيين تأثير ثلاثي الأبعاد على النص:

```cs
using System.Drawing;
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    IAutoShape autoShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "Aspose.Slides";

    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Height = 3.5;
    textFrame.TextFrameFormat.ThreeDFormat.BevelBottom.Width = 3.5;

    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Height = 4;
    textFrame.TextFrameFormat.ThreeDFormat.BevelTop.Width = 4;

    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionColor.Color = Color.Orange;
    textFrame.TextFrameFormat.ThreeDFormat.ExtrusionHeight = 6;

    textFrame.TextFrameFormat.ThreeDFormat.ContourColor.Color = Color.DarkRed;
    textFrame.TextFrameFormat.ThreeDFormat.ContourWidth = 1.5;

    textFrame.TextFrameFormat.ThreeDFormat.Depth = 3;

    textFrame.TextFrameFormat.ThreeDFormat.Material = MaterialPresetType.Plastic;

    textFrame.TextFrameFormat.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    textFrame.TextFrameFormat.ThreeDFormat.LightRig.SetRotation(0, 0, 40);

    textFrame.TextFrameFormat.ThreeDFormat.Camera.CameraType = CameraPresetType.PerspectiveContrastingRightFacing;
}
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" %}} 
تحكم قواعد محددة في تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكالها—وتفاعل هذه التأثيرات معًا. اعتبر مشهدًا يحتوي على نص والشكل الذي يضم ذلك النص. يتضمن تأثير ثلاثي الأبعاد تمثيلًا ثلاثيًا للعنصر والمشهد الذي يُوضع عليه.

- إذا تم تعيين مشهد لكل من الشكل والنص، يكون مشهد الشكل هو الأولوية وتُهمل مشهد النص.
- إذا كان الشكل لا يمتلك مشهدًا خاصًا لكنه يمتلك تمثيلًا ثلاثيًا، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير ثلاثي أبدًا، يُعامل كمسطح، ويُطبق التأثير الثلاثي فقط على النص.

هذه السلوكيات تتعلق بخصائص [ThreeDFormat.LightRig](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/lightrig/) و[ThreeDFormat.Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/camera/).
{{% /alert %}} 

## **الأسئلة المتكررة**

### هل يمكنني استخدام تأثيرات WordArt مع خطوط أو سكريبتات مختلفة (مثل العربية أو الصينية)؟

نعم، يدعم Aspose.Slides for .NET Unicode ويعمل مع جميع الخطوط والسكريبتات الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد بغض النظر عن اللغة، على الرغم من أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

### هل يمكنني تطبيق تأثيرات WordArt على عناصر ماستر الشرائح؟

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في ماستر الشرائح، بما في ذلك عناصر العنواوين، التذييلات، أو النص الخلفي. سينعكس أي تعديل على تخطيط ماستر عبر جميع الشرائح المرتبطة.

### هل تؤثر تأثيرات WordArt على حجم ملف العرض؟

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهج، وتعبئات التدرج من حجم الملف قليلًا بسبب إضافة بيانات تنسيق، لكن الفرق عادةً ما يكون ضئيلًا.

### هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟

نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام طريقة `GetImage` من واجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) أو [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.