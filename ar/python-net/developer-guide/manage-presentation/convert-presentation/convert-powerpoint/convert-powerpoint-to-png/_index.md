---
title: تحويل شرائح PowerPoint إلى PNG في Python
linktitle: شريحة إلى PNG
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
description: "تحويل عروض PowerPoint و OpenDocument إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للـ Python عبر .NET، لضمان نتائج دقيقة ومؤتمتة."
---

## **نظرة عامة**

يُسّهل Aspose.Slides للـ Python عبر .NET تحويل عروض PowerPoint إلى PNG. تقوم بتحميل عرض تقديمي، وتكرار شرائحه، وتصيير كل شريحة إلى صورة نقطية، ثم حفظ النتيجة كملفات PNG. هذا مثالي لإنشاء معاينات للشرائح، أو تضمين الشرائح في صفحات الويب، أو إنتاج أصول ثابتة للمعالجة اللاحقة.

## **تحويل الشرائح إلى PNG**

هذا القسم يوضح أبسط مثال ممكن لتحويل عرض PowerPoint إلى صور PNG باستخدام Aspose.Slides للـ Python عبر .NET.

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. احصل على شريحة من مجموعة `Presentation.slides` (انظر الفئة [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) ).
1. استخدم الطريقة `Slide.get_image` لإنشاء صورة مصغرة للشريحة.
1. استخدم الطريقة `Presentation.save` لحفظ الصورة المصغرة للشريحة بتنسيق PNG.

هذا الكود Python يوضح كيفية تحويل عرض PowerPoint إلى PNG:
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **تحويل الشرائح إلى PNG بأبعاد مخصصة**

لتصدير الشرائح إلى PNG بمقياس مخصص، استدعِ `Slide.get_image` مع عوامل المقياس الأفقي والرأسي. تُعيد هذه المضاعفات تحجيم الناتج نسبةً إلى أبعاد الشريحة الأصلية—على سبيل المثال، `2.0` يضاعف كل من العرض والارتفاع. استخدم قيمًا متساوية لـ `scale_x` و `scale_y` للحفاظ على نسبة الأبعاد.

هذا الكود Python يوضح العملية الموصوفة:
```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


## **تحويل الشرائح إلى PNG بحجم مخصص**

إذا أردت إنشاء ملفات PNG بحجم محدد، مرّر قيم `width` و `height` المطلوبة. يُظهر الكود أدناه كيفية تحويل عرض PowerPoint إلى PNG مع تحديد حجم الصورة:
```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```


{{% alert title="Tip" color="primary" %}}
قد ترغب في تجربة محولات **PowerPoint-to-PNG** المجانية من Aspose — [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). توفر هذه أدوات تنفيذًا مباشرًا للعملية الموضحة في هذه الصفحة.
{{% /alert %}}

## **الأسئلة الشائعة**

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة بالكامل؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/python-net/create-shape-thumbnails/); يمكنك تصيير الشكل إلى صورة PNG.

**هل يتم دعم التحويل المتوازي على الخادم؟**

نعم، ولكن [لا تشارك](/slides/ar/python-net/multithreading/) نسخة عرض تقديمي واحدة عبر خيوط التنفيذ. استخدم نسخة منفصلة لكل خيط أو عملية.

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية على الصور المُخرجة ويفرض [قيودًا أخرى](/slides/ar/python-net/licensing/) حتى يتم تطبيق ترخيص.