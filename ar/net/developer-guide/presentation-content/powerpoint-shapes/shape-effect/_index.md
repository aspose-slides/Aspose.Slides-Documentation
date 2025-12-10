---
title: تطبيق تأثيرات الشكل في العروض التقديمية في .NET
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
- تنسيق التأثير
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "حوّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الشكل المتقدمة عبر Aspose.Slides for .NET—أنشئ شرائح جذابة ومهنية في ثوانٍ."
---

## **نظرة عامة**

بينما يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فهي تختلف عن [الملء](/slides/ar/net/shape-formatting/#gradient-fill) أو المخططات. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، أو نشر توهج الشكل، إلخ.

<img src="shape-effect.png" alt="shape-effect" style="zoom:50%;" />

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **Preset**. تمثل خيارات Preset تركيبة معروفة المظهر من تأثيرين أو أكثر. بهذه الطريقة، باختيار إعداد مسبق، لن تضطر إلى إضاعة الوقت في اختبار أو جمع تأثيرات مختلفة للعثور على تركيبة جيدة.

توفر Aspose.Slides خصائص وأساليب تحت فئة [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) التي تتيح لك تطبيق نفس التأثيرات على الأشكال في عروض PowerPoint.

## **تطبيق تأثير الظل**

لتطبيق تأثير الظل على شكل في Aspose.Slides for .NET، يمكنك بسهولة ضبط معلمات مثل اللون، نصف قطر الضبابية، والاتجاه. يمنح ذلك الأشكال مظهرًا أكثر ديناميكية ومهنية، مع إضافة عمق وتركيز. باستخدام مقتطفات شيفرة بسيطة، يمكنك تطبيق هذه التأثيرات عبر أشكال متعددة، مما يعزز الجاذبية البصرية العامة لعروضك.

هذا الكود C# يوضح كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) على مستطيل:
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

لتطبيق تأثير الانعكاس في Aspose.Slides for .NET، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، مع ضبط معلمات مثل المسافة، الشفافية، والحجم. يحسن هذا التأثير من جمالية عروضك بإضفاء مظهر أكثر صقلًا وتطورًا على الأشكال. من السهل تنفيذه بشفرة بسيطة، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة للحصول على تصميم متسق.

هذا الكود C# يوضح كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) على شكل:
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

لتطبيق تأثير التوهج على شكل في Aspose.Slides for .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، مع ضبط خصائص مثل اللون والحجم. يساعد هذا التأثير في إبراز الأشكال وإضافة عنصر بصري جذاب إلى عرضك. من السهل تنفيذه بشيفرة قليلة، مما يعزز المظهر العام للشرائح.

هذا الكود C# يوضح كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) على شكل:
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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides for .NET، يمكنك إنشاء انتقال ناعم ومموه حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر هدوءًا وأناقة، وهو مثالي للتصاميم التي تحتاج إلى مظهر لطيف وأقل حدة. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك.

هذا الكود C# يوضح كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) على شكل:
```c#
using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);

shape.EffectFormat.EnableSoftEdgeEffect();
shape.EffectFormat.SoftEdgeEffect.Radius = 8;

presentation.Save("soft_edges_effect.pptx", SaveFormat.Pptx);
```


![تأثير الحواف الناعمة](soft_edges_effect.png)

## **الأسئلة الشائعة**

**هل يمكنني تطبيق تأثيرات متعددة على الشكل نفسه؟**

نعم، يمكنك الجمع بين تأثيرات مختلفة، مثل الظل، والانعكاس، والتوهج، على شكل واحد لإنشاء مظهر أكثر حيوية.

**ما الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على مجموعة متنوعة من الأشكال، بما في ذلك الأشكال التلقائية، والرسوم البيانية، والجداول، والصور، وكائنات SmartArt، وكائنات OLE، وأكثر.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.