---
title: إنشاء عارض عروض تقديمية في بايثون
linktitle: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/python-net/developer-guide/presentation-viewer/
keywords: 
- عرض العرض التقديمي
- عارض العروض التقديمية
- إنشاء عارض عروض تقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "تعرف على كيفية إنشاء عارض عروض تقديمية مخصص في بايثون باستخدام Aspose.Slides. اعرض ملفات PowerPoint (PPTX, PPT) وOpenDocument (ODP) بسهولة دون الحاجة إلى Microsoft PowerPoint أو أي برنامج مكتبي آخر."
---

## **نظرة عامة**

يتم استخدام Aspose.Slides للبايثون لإنشاء ملفات عروض تقديمية تتضمن شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو استخدامها في عارض عروض تقديمية مخصص. في هذه الحالات، يتيح لك Aspose.Slides تصدير الشرائح الفردية كصور. يشرح هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض تقديمي باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بواسطة مؤشرها.
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

## **إنشاء صورة مصغرة للشريحة**

يساعدك Aspose.Slides في إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بواسطة مؤشرها.
3. إنشاء صورة مصغرة للشريحة المرجعية بالمقياس المطلوب.
4. حفظ الصورة المصغرة بالتنسيق الذي تفضله.

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

## **إنشاء صورة مصغرة للشريحة بأبعاد محددة من قبل المستخدم**

لإنشاء صورة مصغرة لشريحة بأبعاد يحددها المستخدم، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. الحصول على مرجع إلى الشريحة بواسطة مؤشرها.
3. إنشاء صورة مصغرة للشريحة المرجعية بالأبعاد المحددة.
4. حفظ الصورة المصغرة بالتنسيق الذي تفضله.

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

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/).
2. استخدم خاصية `RenderingOptions.slides_layout_options` لتحديد موضع ملاحظات المتحدث.
3. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
4. الحصول على مرجع إلى الشريحة بواسطة مؤشرها.
5. إنشاء صورة مصغرة للشريحة المرجعية باستخدام خيارات العرض.
6. حفظ الصورة المصغرة بالتنسيق الذي تفضله.

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

جرّب التطبيق المجاني [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) لترى ما يمكنك تنفيذه باستخدام Aspose.Slides API:

[![Online PowerPoint Viewer](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/viewer/)

## **الأسئلة المتكررة**

**هل يمكنني تضمين عارض عروض تقديمية في تطبيق ويب ASP.NET؟**

نعم. يمكنك استخدام Aspose.Slides على جانب الخادم لعرض الشرائح كـ [images](/slides/ar/python-net/convert-powerpoint-to-png/) أو [HTML](/slides/ar/python-net/convert-powerpoint-to-html/) وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير باستخدام جافاسكريبت لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض .NET مخصص؟**

النهج الموصى به هو عرض كل شريحة كـ [image](/slides/ar/python-net/convert-powerpoint-to-png/) (مثل PNG أو SVG) أو تحويلها إلى [HTML](/slides/ar/python-net/convert-powerpoint-to-html/) باستخدام Aspose.Slides، ثم عرض الناتج داخل صندوق صورة (للتطبيقات المكتبية) أو حاوية HTML (للتطبيقات الويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

لعروض تقديمية كبيرة، ضع في الاعتبار التحميل المتأخر أو العرض حسب الطلب للشرائح. هذا يعني إنشاء محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.