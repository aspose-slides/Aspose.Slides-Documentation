---
title: تحويل شرائح PowerPoint إلى PNG في .NET
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/net/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- .NET
- C#
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides for .NET، مما يضمن نتائج دقيقة ومُؤتمتة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل شرائح العروض التقديمية إلى صور PNG باستخدام Aspose.Slides for .NET. يمكنك تحميل العروض بصيغ مثل PPT و PPTX و ODP، تصيير كل شريحة، وحفظها كصورة PNG منفصلة.

تُظهر الأمثلة أدناه تصيير الصور المصغرة، ضبط عوامل المقياس، تحديد أبعاد الإخراج بالبكسل، واختيار نمط تصيير التدرج.

## **تحويل PowerPoint إلى PNG**

قم بتحميل عرض تقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) والوصول إلى شرائحه عبر مجموعة [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). يقوم المثال بتصييـر كل شريحة باستخدام [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) بدون معلمات لإنشاء صورة مصغرة. ثم يستدعي [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) مع [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) لحفظ كل شريحة مصيرة كصورة PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
التحميل بدون معلمات لـ[ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) يصيّر بمقياس 0.2. على سبيل المثال، شريحة قياس 720 × 540 نقطة تنتج صورة مصغرة بحجم 144 × 108 بكسل. للتحكم بأبعاد الإخراج، استخدم التحميلات ذات عوامل المقياس أو حجم الصورة الصريح الموضح أدناه.
{{% /alert %}}

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

مرّر عوامل المقياس الأفقية والعمودية إلى [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) للتحكم بأبعاد التصيير. في هذا المثال، كلا العاملين يساويان 2، لذا شريحة قياس 720 × 540 نقطة تنتج صورة بحجم 1440 × 1080 بكسل. الحفاظ على عوامل مقياس متساوية يحافظ على نسبة أبعاد الشريحة. تُحفظ كل صورة بصيغة PNG باستخدام [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) بدلاً من عوامل المقياس. يقوم هذا المثال بتصيير كل شريحة بحجم 960 × 720 بكسل ويحفظ النتيجة باستخدام [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). اختر الأبعاد التي تطابق نسبة أبعاد الشريحة لتجنب تمديد الصورة.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **اختيار نمط تصيير التدرج**

افترض أن شريحة تحتوي على تعبئات تدرجية، لكن الانتقالات في PNG المُصدَّر تظهر أخف أو مختلفة عن ما تراه في PowerPoint. يمكنك استعمال خاصية [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) من [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) لاختيار طريقة تصيير التدرجات.

قم بتحميل [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل عمل التطبيق. تحتوي شريحته الأولى على تدرجين خطيين: من السماوي إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. لكل تدرج نقطتا توقف عند 0٪ و100٪.

المثال التالي يحمل هذا العرض ويصِّر الشريحة الأولى نفسها في الوضعين باستخدام [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

الصور أدناه تُظهر ناتج الشريحة نفسها، مع وجود كلا التدرجين في كل صورة:

| Default | PowerPointUI |
| --- | --- |
| ![التدرجات من السماوي إلى البرتقالي والأزرق إلى الأصفر تم تصييرها باستخدام Default](gradient-Default.png) | ![نفس التدرجات تم تصييرها باستخدام PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، `Default` ينتج ألوانًا وسطية أفتح، بينما `PowerPointUI` ينتج ألوانًا وسطية أغمق. الاختلاف يعتمد على الألوان ونقاط التوقف في التدرج.

اختر `Default` عندما يكون إخراج Aspose.Slides القياسي مناسبًا لاحتياجاتك. جرب `PowerPointUI` عندما يكون أولويتك مطابقة المظهر في PowerPoint. قارن كلا الناتجين مع النتيجة المطلوبة؛ لا يُعتبر أي وضع مفضلًا عالميًا على الآخر.

## **الأسئلة المتكررة**

**كيف يمكنني تصدير شكل معين، مثل مخطط أو صورة، بدلاً من كامل الشريحة؟**

يدعم Aspose.Slides [generating thumbnails for individual shapes](/slides/ar/net/create-shape-thumbnails/)، مما يتيح لك تصيير شكل كصورة PNG.

**هل يُدعم التحويل المتوازي على الخادم؟**

نعم. استخدم نسخة عرض تقديمي منفصلة لكل خيط أو عملية؛ [do not share a single instance across threads](/slides/ar/net/multithreading/).

**ما هي قيود التقييم عند التصدير إلى PNG؟**

وضع التقييم يضيف علامة مائية إلى الصور الناتجة ويطبق [other restrictions](/slides/ar/net/licensing/) حتى يتم تطبيق ترخيص.