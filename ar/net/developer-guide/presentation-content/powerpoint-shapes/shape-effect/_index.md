---
title: تطبيق تأثيرات الشكل في PowerPoint باستخدام C#
linktitle: تأثير الشكل
type: docs
weight: 30
url: /ar/net/shape-effect
keywords:
- تأثير الشكل
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تأثير الحواف الناعمة
- تأثير الحافة المائلة
- تنسيق ثلاثي الأبعاد
- دوران ثلاثي الأبعاد
- PowerPoint
- عرض تقديمي
- C#
- .NET
- Aspose.Slides
description: "حسّن عروض PowerPoint التقديمية باستخدام تأثيرات الشكل المذهلة مثل الظلال والانعكاسات والتوهجات عبر Aspose.Slides لـ .NET. قم بأتمتة تحسينات الصورة باستخدام كود سهل الاستخدام وأنشئ شرائح ذات جودة احترافية بسهولة."
---

## **نظرة عامة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [التعبئات](/slides/ar/net/shape-formatting/#gradient-fill) أو الخطوط الخارجية. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، وما إلى ذلك.

<img src="shape-effect.png" alt="تأثير-الشكل" style="zoom:50%;" />

توفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **Preset**. خيارات Preset هي في الأساس تركيبة معروفة المظهر من تأثيرين أو أكثر. بهذه الطريقة، عند اختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة جيدة.

توفر Aspose.Slides خصائص وأساليب ضمن الفئة [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

لتطبيق تأثير الظل على شكل في Aspose.Slides for .NET، يمكنك بسهولة ضبط معلمات مثل اللون، نصف قطر التمويه، والاتجاه. يمنح ذلك أشكالك مظهراً أكثر ديناميكية واحترافية، مع إضافة عمق وتركيز. باستخدام مقاطع شفرة بسيطة، يمكنك تطبيق هذه التأثيرات عبر أشكال متعددة، مما يعزز الجاذبية البصرية العامة لعروضك.

يظهر هذا الكود C# كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) على مستطيل:
```c#
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

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides for .NET، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، مع ضبط معلمات مثل المسافة، الشفافية، والحجم. يعزز هذا التأثير جمالية عروضك من خلال إعطاء الأشكال مظهرًا أكثر صقلاً ورقيًا. من السهل تنفيذه بشفرة بسيطة، مما يتيح تطبيقه بسرعة عبر عناصر متعددة لتصميم متسق.

يظهر هذا الكود C# كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) على شكل:
```c#
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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير في إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا إلى عرضك. من السهل تنفيذه بشفرة قليلة، مما يعزز المظهر العام لشرائحك.

يظهر هذا الكود C# كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) على شكل:
```c#
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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for .NET، يمكنك إنشاء انتقال سلس ومموه حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وأناقة، مثالي للتصاميم التي تحتاج إلى مظهر لطيف وناعم. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك.

يظهر هذا الكود C# كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) على شكل:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![تأثير الحواف الناعمة](soft_edges_effect.png)

## **FAQ**

**هل يمكنني تطبيق عدة تأثيرات على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل، الانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال متنوعة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، والمزيد.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.