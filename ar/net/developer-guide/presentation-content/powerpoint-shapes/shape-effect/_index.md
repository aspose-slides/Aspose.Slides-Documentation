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
## **مقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [الملء](/slides/ar/net/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على شكل، وإضافة توهج للشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

PowerPoint يوفر ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يوفر PowerPoint خيارات ضمن **الإعداد المسبق**. خيارات الإعداد المسبق هي في الأساس تركيبة معروفة مظهرًا جيدًا مكوّنة من اثنين أو أكثر من التأثيرات. بهذه الطريقة، باختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides خصائص وأساليب ضمن الفئة [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

Aspose.Slides for .NET يدعم الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص لونها، اتجاهها، مسافتها، ونصف قطر الضبابية لتتناسب مع تصميم العرض التقديمي الخاص بك.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز ضد خلفية الشريحة. يمتد الظل خارج حدود الشكل، مما يخلق انطباعًا بأن الشكل مرتفع فوق الشريحة. اضبط لونه، اتجاهه، مسافته، ونصف قطر الضبابية لتتناسب مع الإضاءة وتنسيق القالب الخاص بك.

هذا الكود C# يوضح كيفية تطبيق [outer shadow effect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) على مستطيل:

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

عند إعادة إنتاج تنسيق القالب البصري، استخدم ظلًا داخليًا لإضفاء مظهر مخفي على البطاقة أو اللوحة. الظل الخارجي يمتد خارج الشكل ويجعله يبدو مرتفعًا، بينما الظل الداخلي يُظلل داخل حواف الشكل.

استدعِ [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)، ثم قم بتهيئة [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). القيم الأكبر تنتج حوافًا أكثر نعومة.

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

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for .NET، يمكنك إضافة انعكاس يشبه المرآة إلى الأشكال، مع تعديل معلمات مثل المسافة، الشفافية، والحجم. يعزز هذا التأثير جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه باستخدام شفرة بسيطة، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة لتصميم متسق.

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع تعديل خصائص مثل اللون والحجم. يساعد هذا التأثير في إبراز الأشكال وإضافة عنصر بصري جذاب إلى العرض التقديمي. إنه سهل التنفيذ بشفرة قليلة، مما يعزز المظهر العام للشرائح.

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for .NET، يمكنك إنشاء انتقال سلس ومموه حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة ودقة، مثاليًا للتصميمات التي تحتاج إلى مظهر ناعم ولطيف. يمكنك بسهولة تعديل معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر مختلف الأشكال في العرض التقديمي.

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

## **FAQ**

**هل يمكنني تطبيق تأثيرات متعددة على الشكل نفسه؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، الانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على مجموعة متنوعة من الأشكال، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وأكثر من ذلك.

**هل يمكنني تطبيق التأثيرات على الأشكال المجموعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.