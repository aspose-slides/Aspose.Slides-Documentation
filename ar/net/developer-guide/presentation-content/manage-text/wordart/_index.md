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
- تأثير الانعكاس
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- .NET
- C#
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides لـ .NET. هذا الدليل خطوة بخطوة يساعد المطورين على تحسين العروض التقديمية بنص احترافي باستخدام C#."
---
## **نظرة عامة**

تتيح لك تأثيرات WordArt تنسيق النص باستخدام التعبئات، والحدود، والظلال، والإنعكاسات، والتوهج، والتحويلات، وتنسيق ثلاثي الأبعاد. توضح هذه المقالة كيفية إنشاء هذه التأثيرات وتخصيصها في عروض PowerPoint باستخدام Aspose.Slides for .NET دون الحاجة إلى تثبيت Microsoft Office.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

تُنشئ الأمثلة التالية نمط WordArt بسيط عن طريق ضبط النص، الخط، تعبئة النمط، والحد.

كل مثال ينشئ عرضًا تقديميًا جديدًا ويضيف مستطيلًا إلى الشريحة الأولى؛ لا يلزم أي ملف إدخال. يضبط المثال الأول النص إلى "Aspose.Slides". يُقاس موضع الشكل وأبعاده بالنقاط:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;

var portion = textFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
```

اضبط الخط إلى Arial Black بحجم 36 نقطة لجعل التنسيق أكثر وضوحًا:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;
```

طبق نمط [SmallGrid](https://reference.aspose.com/slides/ar/net/aspose.slides/patternstyle/) بلون أمامي برتقالي داكن وخلفية بيضاء، ثم أضف حدًا نصيًا أسود بعرض نقطة واحدة:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.FillFormat.FillType = FillType.Pattern;
portion.PortionFormat.FillFormat.PatternFormat.ForeColor.Color = Color.DarkOrange;
portion.PortionFormat.FillFormat.PatternFormat.BackColor.Color = Color.White;
portion.PortionFormat.FillFormat.PatternFormat.PatternStyle = PatternStyle.SmallGrid;

portion.PortionFormat.LineFormat.Width = 1;
portion.PortionFormat.LineFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt الأخرى**

تُظهر الأمثلة التالية كيفية تطبيق الظلال، والإنعكاسات، والتوهج، والتحويلات، وتأثيرات ثلاثية الأبعاد على النص.

### **تطبيق تأثيرات الظل الخارجي**

الظل الخارجي يضيف عمقًا عن طريق وضع ظل خلف النص. يمكنك تخصيص لونه، واتجاهه، والمسافة، ونصف قطر الضباب، والقياس، والانحراف.

هذا المثال يستدعي [EnableOuterShadowEffect](https://reference.aspose.com/slides/ar/net/aspose.slides/effectformat/enableoutershadoweffect/) ويضبط ظلًا أسود بنصف قطر ضباب 4 نقاط، واتجاه 230 درجة، ومسافة 30 نقطة. القيم 100 للقياس تحافظ على حجم الظل، بينما يميل الانحراف الأفقي بزاوية 20 درجة. يُحدد التحويل ألفا شفافيته إلى 32%:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" title="ملاحظة" %}}
- عند استخدام الظلال الخارجية والظلال المسبقة معًا، يُطبق الظل الخارجي فقط.
- إذا استُخدمت الظلال الخارجية والداخلية في الوقت نفسه، فإن التأثير الناتج يعتمد على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يتضاعف التأثير، بينما في PowerPoint 2007 يُطبق الظل الخارجي فقط.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

الانعكاس يخلق نسخةً مرآيةً من النص. عدّل موضعه، وحجمه، وضبابه، وشفافيته للتحكم في مظهره.

هذا المثال يستدعي [EnableReflectionEffect](https://reference.aspose.com/slides/ar/net/aspose.slides/effectformat/enablereflectioneffect/) ويقلب الانعكاس عموديًا بمقياس -100٪. يستخدم نصف قطر ضباب 0.5 نقطة ومسافة 4.72 نقطة. تنخفض الشفافية من 60٪ إلى 0.9٪ بين الموضعين 0٪ و60٪ على طول الانعكاس:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
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
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهج**

التوهج يضيف حدًا ملونًا ناعمًا حول النص. عدّل لونه، وشفافيته، ونصف قطره للتحكم في التأثير.

هذا المثال يستدعي [EnableGlowEffect](https://reference.aspose.com/slides/ar/net/aspose.slides/effectformat/enablegloweffect/) ويطبق توهجًا أحمر بشفافية 54٪ ونصف قطر 7 نقاط:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
portion.Text = "Aspose.Slides";
portion.PortionFormat.LatinFont = new FontData("Arial Black");
portion.PortionFormat.FontHeight = 36;

portion.PortionFormat.EffectFormat.EnableGlowEffect();
portion.PortionFormat.EffectFormat.GlowEffect.Color.Color = System.Drawing.Color.Red;
portion.PortionFormat.EffectFormat.GlowEffect.Color.ColorTransform.Add(ColorTransformOperation.SetAlpha, 0.54f);
portion.PortionFormat.EffectFormat.GlowEffect.Radius = 7;
```

النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحولات WordArt**

تحولات WordArt تنحني أو تمدد أو تشوه كتلة النص.

اضبط [Transform](https://reference.aspose.com/slides/ar/net/aspose.slides/textframeformat/transform/) إلى [ArchUpPour](https://reference.aspose.com/slides/ar/net/aspose.slides/textshapetype/) لتقوس إطار النص بالكامل للأعلى:

```cs
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

var textFrame = autoShape.TextFrame;
textFrame.Text = "Aspose.Slides";
textFrame.TextFrameFormat.Transform = TextShapeType.ArchUpPour;
```

النص الناتج:

![تحول WordArt](transform_effect.png)

{{% alert color="info" title="ملاحظة" %}}
توفر Aspose.Slides for .NET مجموعة من [أنواع التحول المسبقة التعريف](https://reference.aspose.com/slides/ar/net/aspose.slides/textshapetype/).
{{% /alert %}}

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

يمكنك تطبيق تأثيرات ثلاثية الأبعاد على الشكل أو على نصه. تتحكم الحواف، والإنبثاق، والإضاءة، وإعدادات الكاميرا في المظهر النهائي.

يستخدم المثال التالي [ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/) لإضافة حواف دائرية، وإنبثاق برتقالي، وتحديد أحمر داكن للمستطيل. تُقاس أبعاد الحواف، وارتفاع الإنבثاق، وعرض التحديد، والعمق بالنقاط. يُعرّف مادة بلاستيكية، وإضاءة متوازنة مدارة بزاوية 40 درجة حول المحور Z، وكاميرا منظور مظهره:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
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
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

يطبق هذا المثال تنسيقًا ثلاثي الأبعاد مشابهًا على النص عبر [TextFrameFormat.ThreeDFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/textframeformat/threedformat/). تُشكل الحواف الصغيرة حواف الحروف، بينما يمنح الإنبثاق والإضاءة النص عمقًا:

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
var textFrame = autoShape.TextFrame;
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
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" title="ملاحظة" %}}
تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكاله—والتفاعل بين هذه التأثيرات—محكوم بقواعد محددة. خذ بعين الاعتبار مشهدًا يحتوي على كل من النص والشكل الذي يضمّه. يشمل التأثير ثلاثي الأبعاد تمثيل الكائن الثلاثي الأبعاد والمشهد الذي يُوضَع فيه.

- إذا تم تعيين مشهد لكل من الشكل والنص، فإن مشهد الشكل يحصل على الأولوية وتُهمل مشهد النص.
- إذا لم يكن لدى الشكل مشهد خاص به لكنه يمتلك تمثيلًا ثلاثيًا الأبعاد، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير ثلاثي الأبعاد، يُعامل كمسطح، ويُطبق التأثير الثلاثي الأبعاد فقط على النص.

هذه السلوكيات تتعلق بخواص [ThreeDFormat.LightRig](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/lightrig/) و[ThreeDFormat.Camera](https://reference.aspose.com/slides/ar/net/aspose.slides/threedformat/camera/).
{{% /alert %}}

للحفاظ على النص مسطحًا ومقروءًا مع الاحتفاظ بتنسيق الشكل ثلاثي الأبعاد، راجع [Keep Text Flat on a 3D Shape](/slides/ar/net/3d-presentation/) للمقارنة بين الإعدادين ومثال كامل بلغة C#.

## **الأسئلة المتكررة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو نصوص مختلفة (مثل العربية أو الصينية)؟**

نعم، يدعم Aspose.Slides for .NET Unicode ويعمل مع جميع الخطوط والنصوص الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، والتعبئة، والحد بغض النظر عن اللغة، رغم أن توفر الخط وعرضه قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر الشريحة الرئيسية (master)؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في الشرائح الرئيسية، بما في ذلك نُسخ العناوين، وتذييلات الصفحات، أو النص الخلفي. ستنعكس التغييرات التي تُجرى على تخطيط الـ master على جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض التقديمي؟**

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، والتوهج، وتعبئات التدرج حجم الملف قليلاً بسبب إضافة بيانات التنسيق، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض؟**

نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG أو JPEG) باستخدام [ISlide.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/getimage/)، أو تصيير الأشكال الفردية باستخدام [IShape.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getimage/). يتيح ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض بالكامل.