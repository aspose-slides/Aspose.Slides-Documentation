---
title: إنشاء عارض عروض تقديمية بلغة بايثون
linktitle: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/python-net/presentation-viewer/
keywords: 
- عرض عرض تقديمي
- عارض عرض تقديمي
- إنشاء عارض عرض تقديمي
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "تعرف على كيفية إنشاء عارض عروض تقديمية مخصص بلغة بايثون باستخدام Aspose.Slides. عرض ملفات PowerPoint (PPTX, PPT) وOpenDocument (ODP) بسهولة دون الحاجة إلى Microsoft PowerPoint أو أي برنامج مكتبي آخر."
---

## **نظرة عامة**

يُستخدم Aspose.Slides للبايثون لإنشاء ملفات عرض تقديمي تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو استخدامها في عارض عرض تقديمي مخصص. في مثل هذه الحالات، يسمح Aspose.Slides بتصدير الشرائح الفردية كصور. توضح هذه المقالة كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض تقديمي باستخدام Aspose.Slides، اتبع الخطوات أدناه:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة بواسطة فهرسها.
1. افتح تدفق ملف.
1. احفظ الشريحة كصورة SVG إلى تدفق الملف.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **إنشاء صورة مصغرة للشريحة**

يساعدك Aspose.Slides على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، اتبع الخطوات أدناه:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة بواسطة فهرسها.
1. أنشئ صورة مصغرة للشريحة المرجعية بالمقياس المطلوب.
1. احفظ الصورة المصغرة بصيغة الصورة التي تفضلها.

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

## **إنشاء صورة مصغرة للشريحة بأبعاد معرفة من قبل المستخدم**

لإنشاء صورة مصغرة للشريحة بأبعاد محددة من قبل المستخدم، اتبع الخطوات أدناه:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة بواسطة فهرسها.
1. أنشئ صورة مصغرة للشريحة المرجعية بالأبعاد المحددة.
1. احفظ الصورة المصغرة بصيغة الصورة التي تفضلها.

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

لإنشاء صورة مصغرة لشريحة تتضمن ملاحظات المتحدث باستخدام Aspose.Slides، اتبع الخطوات أدناه:

1. أنشئ نسخة من الفئة [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/).
1. استخدم الخاصية `RenderingOptions.slides_layout_options` لتحديد موضع ملاحظات المتحدث.
1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة بواسطة فهرسها.
1. أنشئ صورة مصغرة للشريحة المرجعية باستخدام خيارات العرض.
1. احفظ الصورة المصغرة بصيغة الصورة التي تفضلها.

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

جرب تطبيق [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) المجاني لترى ما يمكنك تنفيذه باستخدام Aspose.Slides API:

[![عارض PowerPoint عبر الإنترنت](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **الأسئلة الشائعة**

**هل يمكنني تضمين عارض عرض تقديمي في تطبيق ويب ASP.NET؟**

نعم. يمكنك استخدام Aspose.Slides على جانب الخادم لتصوير الشرائح كـ[صور](/slides/ar/python-net/convert-powerpoint-to-png/) أو [HTML](/slides/ar/python-net/convert-powerpoint-to-html/) وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير والتصغير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض .NET مخصص؟**

الطريقة الموصى بها هي تحويل كل شريحة إلى [صورة](/slides/ar/python-net/convert-powerpoint-to-png/) (مثل PNG أو SVG) أو تحويلها إلى [HTML](/slides/ar/python-net/convert-powerpoint-to-html/) باستخدام Aspose.Slides، ثم عرض الناتج داخل مربع صورة (للتطبيقات المكتبية) أو داخل وعاء HTML (للتطبيقات الويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

في حالة العروض الكبيرة، يُنصح باستخدام التحميل المؤجل أو التصوير حسب الطلب للشرائح. يعني ذلك إنشاء محتوى الشريحة فقط عند تنقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.