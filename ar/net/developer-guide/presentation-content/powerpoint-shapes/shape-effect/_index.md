---
title: تطبيق تأثيرات الأشكال في العروض التقديمية في .NET
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
description: "حوِّل ملفات PPT و PPTX الخاصة بك باستخدام تأثيرات الأشكال المتقدمة عبر Aspose.Slides لـ .NET—أنشئ شرائح ذات مظهر جذاب واحترافي في ثوانٍ."
---
## **المقدمة**

في حين يمكن استخدام التأثيرات في PowerPoint لجعل الشكل يبرز، فإنها تختلف عن [التعبئات](/slides/ar/net/shape-formatting/#gradient-fill) أو الحدود. باستخدام تأثيرات PowerPoint، يمكنك إنشاء انعكاسات مقنعة على الشكل، ونشر توهج الشكل، وما إلى ذلك.

![تأثير الشكل](shape-effect.png)

يوفر PowerPoint ستة تأثيرات يمكن تطبيقها على الأشكال. يمكنك تطبيق تأثير واحد أو أكثر على الشكل.

بعض تركيبات التأثيرات تبدو أفضل من غيرها. لهذا السبب، يحتوي PowerPoint على خيارات تحت **الإعداد المسبق**. خيارات الإعداد المسبق هي أساسًا تركيبة معروفة ذات مظهر جيد من تأثيرين أو أكثر. بهذه الطريقة، باختيار إعداد مسبق، لن تحتاج إلى إضاعة الوقت في اختبار أو دمج تأثيرات مختلفة للعثور على تركيبة مناسبة.

توفر Aspose.Slides الخصائص والطرق ضمن فئة [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/effectformat/) التي تسمح لك بتطبيق نفس التأثيرات على الأشكال في عروض PowerPoint التقديمية.

## **تطبيق تأثير الظل**

يدعم Aspose.Slides لـ .NET الظلال الخارجية والداخلية للأشكال. يمكنك تخصيص اللون والاتجاه والمسافة ونصف قطر التمويه لتتناسب مع تصميم عرضك التقديمي.

### **تطبيق ظل خارجي**

استخدم ظلًا خارجيًا لجعل بطاقة أو لوحة تبرز أمام خلفية الشريحة. يمتد الظل إلى ما وراء حواف الشكل، مما يخلق انطباعًا بأن الشكل مرتفع فوق الشريحة. اضبط لونه واتجاهه ومسافته ونصف قطر التمويه ليتوافق مع الإضاءة وتصميم القالب الخاص بك.

يوضح هذا الكود C# كيفية تطبيق [تأثير الظل الخارجي](https://reference.aspose.com/slides/net/aspose.slides/effectformat/outershadoweffect/) على مستطيل:

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

عند إعادة إنتاج النمط البصري للقالب، استخدم ظلًا داخليًا لإضفاء مظهر متراجع على بطاقة أو لوحة. يمتد الظل الخارجي خارج الشكل ويجعلها تبدو مرتفعة، بينما يظلّل الظل الداخلي داخل حوافها.

استدعِ [EnableInnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/enableinnershadoweffect/)، ثم قم بتهيئة [InnerShadowEffect](https://reference.aspose.com/slides/net/aspose.slides/effectformat/innershadoweffect/). القيم الأكبر تنتج حوافًا ناعمة.

هذا المثال C# ينشئ بطاقة زرقاء فاتحة بظل داخلي رمادي داكن ويحفظها كملف PPTX:

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

## **تطبيق تأثير الانعكاس**

لتطبيق تأثير الانعكاس في Aspose.Slides لـ .NET، يمكنك إضافة انعكاس شبيه بالمرآة إلى الأشكال، وضبط معلمات مثل المسافة والشفافية والحجم. يعزز هذا التأثير جمالية عروضك التقديمية بمنح الأشكال مظهرًا أكثر صقلًا وتطورًا. من السهل تنفيذه باستخدام كود بسيط، مما يتيح تطبيقًا سريعًا عبر عناصر متعددة لتصميم متسق.

يوضح هذا الكود C# كيفية تطبيق [تأثير الانعكاس](https://reference.aspose.com/slides/net/aspose.slides/effectformat/reflectioneffect/) على شكل:

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

لتطبيق تأثير التوهج على شكل في Aspose.Slides لـ .NET، يمكنك إضافة هالة ناعمة ومضيئة حول الأشكال، وضبط خصائص مثل اللون والحجم. يساعد هذا التأثير على إبراز الأشكال ويضيف عنصرًا بصريًا جذابًا ولافتًا لانتباه إلى عرضك التقديمي. إنه سهل التنفيذ باستخدام كود بسيط، مما يحسن المظهر العام لشرائحك.

يوضح هذا الكود C# كيفية تطبيق [تأثير التوهج](https://reference.aspose.com/slides/net/aspose.slides/effectformat/gloweffect/) على شكل:

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

لتطبيق تأثير الحواف الناعمة في Aspose.Slides لـ .NET، يمكنك إنشاء انتقال ناعم ومموه حول حواف الشكل. يضيف هذا التأثير مظهرًا أكثر رقة وتأنقًا، وهو مثالي للتصاميم التي تحتاج إلى مظهر ناعم ولطيف. يمكنك بسهولة ضبط معلمات مثل نصف القطر لتحقيق التأثير المطلوب عبر أشكال مختلفة في عرضك التقديمي.

يوضح هذا الكود C# كيفية تطبيق [الحواف الناعمة](https://reference.aspose.com/slides/net/aspose.slides/effectformat/softedgeeffect/) على شكل:

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

## **تطبيق تأثير التمويه**

استخدم تمويه الشكل لتنعيم ملء الشكل وحدوده مع الحفاظ على إمكانية تحرير الشكل. استدعِ [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) على تنسيق تأثير الشكل. يتم قياس نصف القطر بالنقاط (1/72 بوصة): استخدم قيمة غير سالبة، مع قيم أكبر تنتج تمويهًا أقوى. نصف قطر صفر يترك المظهر دون تغيير.

تتحكم إعداد [Grow](https://reference.aspose.com/slides/net/aspose.slides.effects/iblur/grow/) في الحدود المرئية للتأثير. عند `false`، يُقَصّ التمويه إلى الحدود المرسومة الأصلية، بما في ذلك الحدود. عند `true`، يمكن للتمويه أن يمتد خارج تلك الحدود. لا يغيّر أي من الإعدادين موضع الشكل أو أبعاده.

المقارنة أدناه تستخدم نفس الملء والحدود وأبعاد الشكل طوال الوقت. الصف العلوي يستخدم `grow = false`؛ الصف السفلي يستخدم `grow = true`.

![مستطيل أصلي مقارنةً بنصف قطر تمويه 5 و15 نقطة، مع تعطيل وتمكين Grow](shape_blur_comparison.png)

هذا المثال C# ينشئ مستطيلًا برتقاليًا بحدود زرقاء داكنة، يطبق تمويهًا ب5 نقاط، ثم يحدّثه إلى تمويه ب15 نقطة عن طريق استدعاء [SetBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/setblureffect/) مرة أخرى. يحفظ كلا الحالتين المموهتين، ثم يستدعي [DisableBlurEffect](https://reference.aspose.com/slides/net/aspose.slides/ieffectformat/disableblureffect/) ويحفظ الشكل دون تمويه.

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

تمويه الشكل يؤثر على الملء والحدود معًا. تأثير الحواف الناعمة يبهت حواف الشكل، بينما تمويه الظل ينعّم الظل فقط. تأثيرات تحويل الصورة تعمل على محتوى الصورة؛ هذا المثال يطبق التمويه مباشرةً على تنسيق تأثير الشكل دون تحويل الشكل إلى صورة.

## **الأسئلة المتكررة**

**هل يمكنني تطبيق تأثيرات متعددة على نفس الشكل؟**

نعم، يمكنك دمج تأثيرات مختلفة، مثل الظل والانعكاس والتوهج، على شكل واحد لإنشاء مظهر أكثر ديناميكية.

**ما هي الأشكال التي يمكنني تطبيق التأثيرات عليها؟**

يمكنك تطبيق التأثيرات على أشكال مختلفة، بما في ذلك الأشكال التلقائية، المخططات، الجداول، الصور، كائنات SmartArt، كائنات OLE، وغيرها.

**هل يمكنني تطبيق التأثيرات على الأشكال المجمعة؟**

نعم، يمكنك تطبيق التأثيرات على الأشكال المجمعة. سيُطبق التأثير على المجموعة بأكملها.