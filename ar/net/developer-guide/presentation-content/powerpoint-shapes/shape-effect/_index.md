---
title: تطبيق تأثيرات الأشكال في العروض التقديمية باستخدام .NET
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/net/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تنسيق التأثير
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الأشكال المتقدمة عبر Aspose.Slides for .NET—أنشئ شرائح جذابة واحترافية في ثوانٍ."
---
## **المقدمة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [التعبئات](/slides/ar/net/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، وتوسيع توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **Preset**. خيارات Preset هي في الأساس تركيبة معروفة مظهرًا جيدًا من تأثيرين أو أكثر. بهذه الطريقة، عند اختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب تحت الفئة [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides for .NET الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص اللون والاتجاه والمسافة ونصف قطر التشويش لتتناسب مع تصميم عرضك.

### **تطبيق ظل خارجي**

استخدم الظل الخارجي لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حدود الشكل، مما يخلق الانطباع بأن الشكل مرتفع فوق الشريحة. اضبط لونه واتجاهه ومسافته ونصف قطر التشويش ليتناسب مع الإضاءة وتنسيق القالب.

يعرض هذا الكود C# كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) على مستطيل:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableOuterShadowEffect();
shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.DarkGray;
shape.EffectFormat.OuterShadowEffect.Distance = 10;
shape.EffectFormat.OuterShadowEffect.Direction = 45;

presentation.Save("shadow_effect.pptx", SaveFormat.Pptx);
```

![تأثير الظل](shadow_effect.png)

#### **التحكم في اتجاه الظل عند تدوير الشكل**

بشكل افتراضي، تكون القيمة [RotateShadowWithShape](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/rotateshadowwithshape/) `true`، لذا يدور الظل مع الشكل. لجعل الأشكال ذات الدورات المختلفة تبدو مضاءة من نفس الاتجاه، قم بتعيين هذه الخاصية إلى `false` ومنح ظلالها نفس [Direction](https://reference.aspose.com/slides/net/aspose.slides.effects/ioutershadow/direction/).

ينشئ المثال سهمين بظلال رمادية مائلة إلى اليمين (`Direction = 0`). ثم يكرّر الشريحة ويدور السهمين 90° باتجاه عقارب الساعة.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var before = presentation.Slides[0];

var left = before.Shapes.AddAutoShape(ShapeType.RightArrow, 55, 130, 110, 60);
left.FillFormat.FillType = FillType.Solid;
left.FillFormat.SolidFillColor.Color = Color.SteelBlue;
left.LineFormat.FillFormat.FillType = FillType.NoFill;

left.EffectFormat.EnableOuterShadowEffect();
var shadow = left.EffectFormat.OuterShadowEffect;
shadow.ShadowColor.Color = Color.Gray;
shadow.Direction = 0;
shadow.Distance = 42;
shadow.BlurRadius = 0;
shadow.RotateShadowWithShape = true;

var right = before.Shapes.AddClone(left);
right.X = 395;
right.EffectFormat.OuterShadowEffect.RotateShadowWithShape = false;

var after = presentation.Slides.AddClone(before);
foreach (var arrow in after.Shapes)
    arrow.Rotation = 90;

presentation.Save("arrow_shadows.pptx", SaveFormat.Pptx);
```

في الشريحة الثانية، يُسقّط السهم الأيسر ظله إلى الأسفل، بينما لا يزال السهم الأيمن يُسقّط ظله إلى اليمين. يبقى الاتجاه المكوّن 0° لكلا الظلين.

![عرض PowerPoint قبل وبعد دوران 90°. يبدأ الظلان على اليمين. بعد الدوران، يتحرك الظل أسفل السهم الأيسر ويبقى على يمين السهم الأيمن.](arrow-shadow-rotation.png)

### **تطبيق ظل داخلي**

عند استنساخ النمط البصري للقالب، استخدم الظل الداخلي لإعطاء البطاقة أو اللوحة مظهرًا متجورًا. الظل الخارجي يمتد خارج الشكل ويجعله يبدو مرتفعًا، بينما الظل الداخلي يظلل داخل حواف الشكل.

استدعِ [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)، ثم اضبط [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). القيم الأكبر تنتج حوافًا أكثر نعومة.

ينشئ هذا المثال C# بطاقة زرقاء فاتحة بظل داخلي رمادي داكن ويحفظها كملف PPTX:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.LightBlue;
shape.LineFormat.FillFormat.FillType = FillType.NoFill;

shape.EffectFormat.EnableInnerShadowEffect();
var shadow = shape.EffectFormat.InnerShadowEffect;
shadow.ShadowColor.Color = Color.DimGray;
shadow.Direction = 225;
shadow.Distance = 7;
shadow.BlurRadius = 6;

presentation.Save("inner_shadow_effect.pptx", SaveFormat.Pptx);
```

![مستطيل أزرق فاتح بظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) على تنسيق تأثير الشكل.

### **تطبيق وتغيير وإزالة ظل مُحدد مسبقًا**

استدعِ [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) واضبط [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) إلى نوع [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) مسمى. لتبديل الأنماط، غيّر الإعداد المسبق على الشكل نفسه. استدعِ [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) لإزالة الظل مع الحفاظ على التعبئة والحد.

يحافظ هذا المثال على نسخة من المستطيل في كل مرحلة. الظلان مزيّنان بمقدار 10 نقاط. اتجاه 225° يضع الظل الأول فوق وإلى يسار المستطيل، و45° يضع الظل الثاني أسفل وإلى يمين المستطيل.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(800, 120, SlideSizeScaleType.DoNotScale);
var shapes = presentation.Slides[0].Shapes;

var shape = shapes.AddAutoShape(ShapeType.Rectangle, 15, 30, 170, 60);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.SteelBlue;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.TextFrame.Text = "No shadow";
shape.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FontHeight = 14;
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.EnablePresetShadowEffect();
var shadow = shape.EffectFormat.PresetShadowEffect;
shadow.Preset = PresetShadowType.TopLeftDropShadow;
shadow.Distance = 10;
shadow.Direction = 225;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shadow.Preset = PresetShadowType.BottomRightDropShadow;
shadow.Direction = 45;
shape.TextFrame.Text = shadow.Preset.ToString();
shapes.AddClone(shape);

shape.X += 200;
shape.EffectFormat.DisablePresetShadowEffect();
shape.TextFrame.Text = "No shadow";

presentation.Save("preset_shadows.pptx", SaveFormat.Pptx);
```

| الأصل | الإعداد المسبق الأول | الإعداد المسبق الثاني | بعد الإزالة |
| :---: | :---: | :---: | :---: |
| ![بدون ظل](preset_shadow_original.png) | ![ظل من أعلى اليسار](preset_shadow_top_left.png) | ![ظل من أسفل اليمين](preset_shadow_bottom_right.png) | ![بدون ظل بعد الإزالة](preset_shadow_removed.png) |

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for .NET، يمكنك إضافة انعكاس مشابه للمرآة إلى الأشكال، مع تعديل معايير مثل المسافة والشفافية والحجم. يعزز هذا التأثير جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلاً وتطورًا. من السهل تنفيذه بكود بسيط، مما يتيح تطبيقًا سريعًا عبر عدة عناصر لتصميم متسق.

يعرض هذا الكود C# كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) على شكل:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableReflectionEffect();
shape.EffectFormat.ReflectionEffect.RectangleAlign = RectangleAlignment.Bottom;
shape.EffectFormat.ReflectionEffect.Direction = 90;
shape.EffectFormat.ReflectionEffect.Distance = 40;
shape.EffectFormat.ReflectionEffect.BlurRadius = 2;

presentation.Save("reflection_effect.pptx", SaveFormat.Pptx);
```

![تأثير الانعكاس](reflection_effect.png)

## **تطبيق تأثير التوهج**

لتطبيق تأثير التوهج على شكل في Aspose.Slides for .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع تعديل خصائص مثل اللون والحجم. يساعد هذا التأثير في إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا ولافتًا للانتباه إلى عرضك. من السهل تنفيذه بأقل قدر من الكود، مما يعزز المظهر العام لشرائحك.

يعرض هذا الكود C# كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) على شكل:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
shape.EffectFormat.EnableGlowEffect();
shape.EffectFormat.GlowEffect.Color.Color = Color.Magenta;
shape.EffectFormat.GlowEffect.Radius = 15;

presentation.Save("glow_effect.pptx", SaveFormat.Pptx);
```

![تأثير التوهج](glow_effect.png)

## **تطبيق تأثير الحواف الناعمة**

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for .NET، يمكنك إنشاء انتقال سلس ومطميت حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، وهو مثالي للتصاميم التي تحتاج إلى ظهور هادئ وأقل حدة. يمكنك بسهولة تعديل معايير مثل نصف القطر لتحقيق التأثير المطلوب عبر الأشكال المختلفة في عرضك.

يعرض هذا الكود C# كيفية تطبيق [تأثير الحواف الناعمة](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) على شكل:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```

![تأثير الحواف الناعمة](soft_edges_effect.png)

## **تطبيق تأثير الضبابية**

استخدم ضبابية الشكل لتنعيم تعبئة الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، فالقيم الأكبر تنتج ضبابية أقوى. نصف قطر صفر يترك المظهر دون تغيير.

تتحكم إعدادات [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) في الحدود المرئية للتأثير. عند `false`، يتم قص الضبابية إلى الحدود المرسومة الأصلية، بما في ذلك الحدود. عند `true`، يمكن للضبابية أن تمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موقع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس التعبئة والحدود وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مقارنة بين المستطيل الأصلي مع أقطار ضبابية 5 و15 نقطة، مع تعطيل وتمكين Grow](shape_blur_comparison.png)

ينشئ هذا المثال C# مستطيلًا برتقاليًا بحدود زرقاء داكنة، يطبق ضبابية 5 نقاط، ثم يحدّثه إلى ضبابية 15 نقطة باستدعاء [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) مرة أخرى. يحفظ كلا الحالةين المضبابتين، ثم يستدعي [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) ويحفظ الشكل بدون ضبابية.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
shape.LineFormat.Width = 8;

shape.EffectFormat.SetBlurEffect(5, false);
presentation.Save("shape_blur_5.pptx", SaveFormat.Pptx);

shape.EffectFormat.SetBlurEffect(15, true);
presentation.Save("shape_blur_15.pptx", SaveFormat.Pptx);

shape.EffectFormat.DisableBlurEffect();
presentation.Save("shape_blur_removed.pptx", SaveFormat.Pptx);
```

تؤثر ضبابية الشكل على التعبئة والحدود معًا. يخفّف تأثير الحواف الناعمة حواف الشكل، بينما ينعّم ضباب الظل الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ يطبق هذا المثال الضبابية مباشرةً على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **FAQ**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**  
نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**  
يمكنك تطبيق التأثيرات على مجموعة متنوعة من الأشكال، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمّعة؟**  
نعم، يمكنك تطبيق التأثيرات على الأشكال المجمّعة. سيُطبق التأثير على المجموعة بأكملها.