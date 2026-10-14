---
title: تحويل شرائح PowerPoint إلى PNG في Python
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/python-net/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint إلى PNG
- تحويل العرض التقديمي إلى PNG
- تحويل الشريحة إلى PNG
- تحويل PPT إلى PNG
- تحويل PPTX إلى PNG
- تحويل ODP إلى PNG
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- ODP إلى PNG
- Python
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides for Python عبر .NET، مع ضمان نتائج دقيقة وآلية."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل شرائح العرض التقديمي إلى صور PNG باستخدام Aspose.Slides for Python via .NET. يمكنك تحميل العروض التقديمية بتنسيقات مثل PPT و PPTX و ODP، ثم عرض كل شريحة وحفظها كصورة PNG منفصلة.

توضح الأمثلة أدناه كيفية العرض بالمقياس الافتراضي، وزيادة المقياس، وتحديد أبعاد الإخراج بالبكسل، واختيار نمط عرض التدرج.

## **تحويل PowerPoint إلى PNG**

قم بتحميل عرض تقديمي باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) والوصول إلى شرائحه عبر مجموعة [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). يقوم المثال بعرض كل شريحة باستخدام [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) بدون معلمات لإنشاء صورة مصغرة. ثم يستدعي [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) مع [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) لحفظ كل شريحة مُعروضة كصورة PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
الإصدار بدون معلمات من [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) يعرض بمقياس 0.2. على سبيل المثال، شريحة قياسها 720 × 540 نقطة تنتج صورة مصغرة بحجم 144 × 108 بكسل. للتحكم في أبعاد الإخراج، استخدم الإصدارات مع عوامل المقياس أو حجم صورة صريح كما هو موضح أدناه.
{{% /alert %}}

## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

مرّر عوامل المقياس الأفقية والعمودية إلى [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) للتحكم في أبعاد العرض. في هذا المثال، كلا العاملين يساويان 2، لذا شريحة قياسها 720 × 540 نقطة تنتج صورة بحجم 1440 × 1080 بكسل. الحفاظ على عوامل مقياس متساوية يحافظ على نسبة أبعاد الشريحة. يتم حفظ كل صورة بتنسيق PNG باستخدام [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) بدلاً من عوامل المقياس. هذا المثال يعرض كل شريحة بحجم 960 × 720 بكسل ويحفظ النتيجة باستخدام [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). اختر أبعادًا تتطابق مع نسبة أبعاد الشريحة لتجنب تمدد الصورة.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **اختيار نمط عرض التدرج**

افترض أن شريحة تحتوي على تعبئات متدرجة، لكن الانتقالات في صورة PNG المصدرة تظهر أفتح أو مختلفة عن ما تراه في PowerPoint. يمكنك استخدام خاصية [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) لكائن [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) لاختيار طريقة عرض التدرجات.

قم بتحميل الملف [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل العمل الخاص بالتطبيق. تحتوي شريحته الأولى على تدرجين خطيين: من السيان إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. كل تدرج يحتوي على نقطتي توقف، عند 0% و100%.

المثال التالي يحمل هذا العرض ويعرض الشريحة الأولى نفسها في الوضعين باستخدام [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

الصور أدناه تُظهر ناتج الشريحة نفسها، مع كلا التدرجين في كل صورة:

| Default | PowerPointUI |
| --- | --- |
| ![تدرجات من السيان إلى البرتقالي والأزرق إلى الأصفر تم عرضها باستخدام Default](gradient-Default.png) | ![نفس التدرجات تم عرضها باستخدام PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، ينتج `DEFAULT` ألوانًا وسيطة أفتح، بينما ينتج `POWER_POINT_UI` ألوانًا وسيطة أغمق. يعتمد الاختلاف على الألوان ونقاط التوقف في التدرج.

اختر `DEFAULT` عندما يكون إخراج Aspose.Slides القياسي مناسبًا لاحتياجاتك. جرّب `POWER_POINT_UI` عندما تكون الأولوية لمطابقة المظهر في PowerPoint. قارن كلا الإخراجين مع النتيجة المرجوة؛ لا يُفضل أحد الوضعين عالميًا.

## **الأسئلة المتكررة**

**كيف يمكنني تصدير شكل محدد، مثل رسم بياني أو صورة، بدلاً من الشريحة بالكامل؟**

Aspose.Slides يدعم [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/python-net/create-shape-thumbnails/)، مما يتيح لك عرض شكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم. استخدم نسخة عرض تقديمي مستقلة لكل خيط أو عملية؛ [لا تشارك نسخة واحدة عبر الخيوط](/slides/ar/python-net/multithreading/).

**ما هي قيود التقييم عند التصدير إلى PNG؟**

وضع التقييم يضيف علامة مائية إلى الصور المصدرة ويطبق [قيودًا أخرى](/slides/ar/python-net/licensing/) حتى يتم تطبيق ترخيص.