---
title: إنشاء عارض عروض تقديمية في بايثون
linktitle: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/python-net/presentation-viewer/
keywords:
- عرض العرض التقديمي
- عارض العرض التقديمي
- إنشاء عارض عرض تقديمي
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "تعلّم كيفية إنشاء عارض عروض تقديمية مخصص في بايثون باستخدام Aspose.Slides. اعرض ملفات PowerPoint (PPTX، PPT) وOpenDocument (ODP) بسهولة دون الحاجة إلى Microsoft PowerPoint أو أي برنامج مكتبي آخر."
---

## **نظرة عامة**

يُستخدم Aspose.Slides for Python لإنشاء ملفات عرض تقديمي تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو استخدامها في عارض عروض تقديمية مخصص. في مثل هذه الحالات، يتيح لك Aspose.Slides تصدير الشرائح الفردية كصور. يشرح هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض تقديمي باستخدام Aspose.Slides، اتبع الخطوات أدناه:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. فتح تدفق ملف.
4. حفظ الشريحة كصورة SVG إلى تدفق الملف.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **إنشاء صورة مصغرة لشريحة**

يساعدك Aspose.Slides على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، اتبع الخطوات أدناه:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. إنشاء صورة مصغرة للشريحة المرجعية بالمقياس المطلوب.
4. حفظ الصورة المصغرة بصيغة الصورة المفضلة لديك.

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

## **إنشاء صورة مصغرة للشريحة بأبعاد معرفّة من قبل المستخدم**

لإنشاء صورة مصغرة للشريحة بأبعاد معرفّة من قبل المستخدم، اتبع الخطوات أدناه:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة حسب فهرستها.
3. إنشاء صورة مصغرة للشريحة المرجعية بالأبعاد المحددة.
4. حفظ الصورة المصغرة بصيغة الصورة المفضلة لديك.

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

## **إنشاء صورة مصغرة للشريحة مع ملاحظات المتحدث**

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، اتبع الخطوات أدناه:

1. إنشاء مثال من الفئة [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) .
2. استخدم خاصية `RenderingOptions.slides_layout_options` لتحديد موضع ملاحظات المتحدث.
3. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
4. الحصول على مرجع إلى الشريحة حسب فهرستها.
5. إنشاء صورة مصغرة للشريحة المرجعية باستخدام خيارات العرض.
6. حفظ الصورة المصغرة بصيغة الصورة المفضلة لديك.

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

## **مثال حي**

جرّب تطبيق [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) المجاني لترى ما يمكنك تنفيذه باستخدام واجهة برمجة تطبيقات Aspose.Slides:

[![عارض PowerPoint عبر الإنترنت](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **الأسئلة المتكررة**

**هل يمكنني تضمين عارض عروض تقديمية في تطبيق ويب ASP.NET؟**

نعم. يمكنك استخدام Aspose.Slides على جانب الخادم لتصوير الشرائح كـ[الصور](/slides/ar/python-net/convert-powerpoint-to-png/) أو كـ[HTML](/slides/ar/python-net/convert-powerpoint-to-html/) وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض .NET مخصص؟**

الطريقة الموصى بها هي تصوير كل شريحة كـ[صورة](/slides/ar/python-net/convert-powerpoint-to-png/) (مثل PNG أو SVG) أو تحويلها إلى [HTML](/slides/ar/python-net/convert-powerpoint-to-html/) باستخدام Aspose.Slides، ثم عرض الناتج داخل عنصر صورة (للتطبيقات المكتبية) أو داخل حاوية HTML (للتطبيقات الويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

بالنسبة للمجموعات الكبيرة، فكر في التحميل الكسول أو التصوير عند الطلب للشرائح. هذا يعني إنشاء محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.