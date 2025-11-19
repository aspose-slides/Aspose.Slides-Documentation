---
title: إنشاء عارض عروض تقديمية في بايثون
linktitle: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/python-net/presentation-viewer/
keywords:
- عرض العرض التقديمي
- عارض العروض
- إنشاء عارض عروض تقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "تعلم كيفية إنشاء عارض عروض تقديمية مخصص في بايثون باستخدام Aspose.Slides. اعرض ملفات PowerPoint (PPTX، PPT) وOpenDocument (ODP) بسهولة دون الحاجة إلى Microsoft PowerPoint أو أي برنامج مكتبي آخر."
---

## **نظرة عامة**

Aspose.Slides for Python تُستخدم لإنشاء ملفات عرض تحتوي على شرائح. يمكن مشاهدة هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو استخدامها في عارض عروض مخصص. في مثل هذه الحالات، يتيح لك Aspose.Slides تصدير الشرائح الفردية كصور. يشرح هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة حسب فهرستها.
1. فتح تدفق ملف.
1. حفظ الشريحة كصورة SVG إلى تدفق الملف.
```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```


## **إنشاء صورة مصغرة لشريحة**

Aspose.Slides تساعدك على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة حسب فهرستها.
1. إنشاء صورة مصغرة للشريحة المرجعية بالمقياس المطلوب.
1. حفظ الصورة المصغرة بالتنسيق المفضل لديك.
```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```


## **إنشاء صورة مصغرة لشريحة بأبعاد مخصصة**

لإنشاء صورة مصغرة لشريحة بأبعاد يحددها المستخدم، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة حسب فهرستها.
1. إنشاء صورة مصغرة للشريحة المرجعية بالأبعاد المحددة.
1. حفظ الصورة المصغرة بالتنسيق المفضل لديك.
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```


## **إنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث**

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) .
1. استخدام خاصية `RenderingOptions.slides_layout_options` لتعيين موضع ملاحظات المتحدث.
1. إنشاء نسخة من الفئة [العرض التقديمي](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. الحصول على مرجع إلى الشريحة حسب فهرستها.
1. إنشاء صورة مصغرة للشريحة المرجعية باستخدام خيارات العرض.
1. حفظ الصورة المصغرة بالتنسيق المفضل لديك.
```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```


## **مثال مباشر**

جرّب تطبيق [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) المجاني لترى ما يمكنك تطبيقه باستخدام Aspose.Slides API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **الأسئلة الشائعة**

**هل يمكنني تضمين عارض عروض في تطبيق ويب ASP.NET؟**

نعم. يمكنك استخدام Aspose.Slides على جانب الخادم لتصوير الشرائح ك[الصور](/slides/ar/python-net/convert-powerpoint-to-png/) أو ك[HTML](/slides/ar/python-net/convert-powerpoint-to-html/) وعرضها في المتصفح. يمكن تنفيذ ميزات النقل والتكبير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض .NET مخصص؟**

النهج الموصى به هو تصوير كل شريحة ك[صورة](/slides/ar/python-net/convert-powerpoint-to-png/) (مثل PNG أو SVG) أو تحويلها إلى [HTML](/slides/ar/python-net/convert-powerpoint-to-html/) باستخدام Aspose.Slides، ثم عرض الناتج داخل عنصر صورة (للتطبيقات المكتبية) أو حاوية HTML (للويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

لعروض كبيرة، فكر في التحميل التدريجي أو التصوير حسب الطلب للشرائح. هذا يعني توليد محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.