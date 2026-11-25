---
title: تطبيق تأثيرات الشكل في العروض التقديمية في .NET
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/net/shape-effect/
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعسة
- تنسيق التأثير
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides for .NET—أنشئ شرائح جذابة واحترافية خلال ثوانٍ."
---
## **مقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [ملء](/slides/ar/net/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، وغيرها.

![تأثير الشكل](shape-effect.png)

PowerPoint يوفر ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على شكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات ضمن **Preset**. خيارات Preset هي في الأساس تركيبة معروفة المظهر من تأثيرين أو أكثر. بهذه الطريقة، عند اختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جيدة.

توفر Aspose.Slides خصائص وأساليب ضمن فئة [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

Aspose.Slides for .NET يدعم الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، اتجاهها، مسافتها، ونصف قطر الضبابية لتتناسب مع تصميم العرض التقديمي.

### **تطبيق ظل خارجي**

استخدم الظل الخارجي لجعل بطاقة أو لوحة تبرز مقابل خلفية الشريحة. يمتد الظل إلى ما وراء حواف الشكل، مما يعطي الانطباع بأن الشكل مرتفع فوق الشريحة. اضبط لونه، اتجاهه، مسافته، ونصف قطر الضبابية لتتناسب مع الإضاءة وتنسيق القالب الخاص بك.

هذا الكود C# يوضح كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) على مستطيل:

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

### **تطبيق ظل داخلي**

عند إعادة إنتاج النمط البصري للقالب، استخدم الظل الداخلي لمنح بطاقة أو لوحة مظهرًا غائرًا. الظل الخارجي يمتد خارج الشكل ويجعله يبدو مرتفعًا، بينما الظل الداخلي يظلل داخل حواف الشكل.

استدعِ [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)، ثم اضبط [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). القيم الأكبر تنتج حوافًا أكثر نعومة.

هذا المثال C# ينشئ بطاقة زرقاء فاتحة مع ظل داخلي رمادي داكن ويحفظها كملف PPTX:

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

![مستطيل أزرق فاتح مع ظل داخلي](inner_shadow_effect.png)

لإزالة الظل الداخلي، استدعِ [DisableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/disableinnershadoweffect/) على تنسيق تأثير الشكل.

### **تطبيق، تغيير، وإزالة ظل مسبق**

استدعِ [EnablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/enablepresetshadoweffect/) وحدد [Preset](https://reference.aspose.com/slides/net/aspose.slides.effects/ipresetshadow/preset/) إلى نوع [PresetShadowType](https://reference.aspose.com/slides/net/aspose.slides/presetshadowtype/) مسمى. لتبديل الأنماط، غيّر الإعداد المسبق على نفس الشكل. استدعِ [DisablePresetShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disablepresetshadoweffect/) لإزالة الظل مع الحفاظ على الملء والحدود.

هذا المثال يحتفظ بنسخة من المستطيل في كل مرحلة. كلا الظلين مُزاحان بمقدار 10 نقاط. اتجاه 225° يضع الظل الأول فوق ويسار المستطيل، و45° يضع الظل الثاني أسفل ويمين المستطيل.

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

| الأصلي | الإعداد المسبق الأول | الإعداد المسبق الثاني | بعد الإزالة |
| :---: | :---: | :---: | :---: |
| ![بدون ظل](preset_shadow_original.png) | ![ظل أعلى يسار](preset_shadow_top_left.png) | ![ظل أسفل يمين](preset_shadow_bottom_right.png) | ![بدون ظل بعد الإزالة](preset_shadow_removed.png) |

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير انعكاس في Aspose.Slides for .NET، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، مع ضبط معلمات مثل المسافة والشفافية والحجم. يعزز هذا التأثير جمالية عروضك بتوفير مظهر أكثر صقلًا وتطورًا للأشكال. من السهل تنفيذه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة لتصميم متسق.

هذا الكود C# يوضح كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) على شكل:

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

لتطبيق تأثير توهج على شكل في Aspose.Slides for .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال وإضافة عنصر بصري جذاب إلى عرضك. من السهل تنفيذه بكود بسيط، مما يعزز المظهر العام لشرائحك.

هذا الكود C# يوضح كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) على شكل:

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for .NET، يمكنك إنشاء انتقال ناعم ومهبل حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتفصيلًا، وهو مثالي للتصاميم التي تحتاج إلى مظهر لطيف وناعم. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك.

هذا الكود C# يوضح كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) على شكل:

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

استخدم ضبابية الشكل لتنعيم ملء الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) على تنسيق تأثير الشكل. يُقاس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، حيث القيم الأكبر تنتج ضبابية أقوى. نصف قطر صفر يترك المظهر دون تغيير.

إعداد [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) يتحكم في حدود التأثير المرئية. مع `false`، تُقص الضبابية إلى الحدود المرسومة الأصلية بما في ذلك الحدود. مع `true`، يمكن للضبابية أن تمد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع أو أبعاد الشكل.

المقارنة أدناه تستخدم نفس الملء، الحدود، وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنة مع نصف قطر الضبابية 5 و15 نقطة، مع Grow معطل ومفعل](shape_blur_comparison.png)

هذا المثال C# ينشئ مستطيلًا برتقاليًا مع حدود زرقاء داكنة، يطبق ضبابية بارتفاع 5 نقاط، ثم يحدّثها إلى 15 نقطة باستدعاء [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) مرة أخرى. يحفظ كلا الحالتين المضبابيتين، ثم يستدعي [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) ويحفظ الشكل دون ضبابية.

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

تؤثر ضبابية الشكل على الملء والحدود معًا. تأثير الحواف الناعمة يخفّف حواف الشكل، بينما ضبابية الظل تُنعّم الظل فقط. تعمل تأثيرات تحويل الصورة على محتوى الصورة؛ هذا المثال يطبق الضبابية مباشرة على تنسيق تأثير الشكل دون تحويله إلى صورة.

## **FAQ**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال متعددة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.