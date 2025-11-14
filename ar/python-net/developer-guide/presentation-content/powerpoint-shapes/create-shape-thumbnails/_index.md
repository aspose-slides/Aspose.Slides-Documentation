---
title: إنشاء مصغرات الأشكال
type: docs
weight: 70
url: /ar/python-net/create-shape-thumbnails/
keywords: "مصغرات الأشكال. عرض تقديمي PowerPoint، بايثون، Aspose.Slides لـ بايثون عبر .NET"
description: "مصغرات الأشكال في عرض PowerPoint باستخدام بايثون"
---

تُستخدم Aspose.Slides لـ بايثون عبر .NET لإنشاء ملفات العرض التقديمي حيث تكون كل صفحة عبارة عن شريحة. يمكن عرض هذه الشرائح من خلال فتح ملفات العرض التقديمي باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان، قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض الصور. في مثل هذه الحالات، تساعدك Aspose.Slides لـ بايثون عبر .NET في توليد صور مصغرة لأشكال الشرائح. كيفية استخدام هذه الميزة موصوفة في هذه المقالة.
تشرح هذه المقالة كيفية توليد مصغرات الشرائح بطرق مختلفة:

- توليد مصغر شكل داخل شريحة.
- توليد مصغر شكل لشكل الشريحة بأبعاد محددة بواسطة المستخدم.
- توليد مصغر شكل في حدود مظهر الشكل.
- توليد مصغر للعقدة الفرعية في SmartArt.
## **توليد مصغر شكل من الشريحة**
لتوليد مصغر شكل من أي شريحة باستخدام Aspose.Slides لـ بايثون عبر .NET:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغر شكل الشريحة المرجعية على المقياس الافتراضي.
1. حفظ صورة المصغر في أي تنسيق صورة مرغوب فيه.

المثال أدناه يُولد مصغر شكل.

```py
import aspose.slides as slides

# إنشاء فئة Presentation تمثل ملف العرض التقديمي
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # إنشاء صورة بمقياس كامل
    with presentation.slides[0].shapes[0].get_image() as bitmap:
        # حفظ الصورة على القرص بتنسيق PNG
        bitmap.save("Shape_thumbnail_out.png", slides.ImageFormat.PNG)
```

## **توليد مصغر بمعامل تغيير الحجم محدد بواسطة المستخدم**
لتوليد مصغر الشكل لأي شكل شريحة باستخدام Aspose.Slides لـ بايثون عبر .NET:

1. إنشاء مثيل من فئة `Presentation`.
1. الحصول على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغر للشريحة المرجعية مع حدود الشكل.
1. حفظ صورة المصغر في أي تنسيق صورة مرغوب فيه.

المثال أدناه يُولد مصغرًا مع توليد مصغر بمعامل تغيير الحجم محدد بواسطة المستخدم.

```py
import aspose.slides as slides

# إنشاء فئة Presentation تمثل ملف العرض التقديمي
with slides.Presentation(path + "HelloWorld.pptx") as p:
    # إنشاء صورة بمقياس كامل
    with p.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.SHAPE, 1, 1) as bitmap:
        # حفظ الصورة على القرص بتنسيق PNG
        bitmap.save("Scaling Factor Thumbnail_out.png", slides.ImageFormat.PNG)
```

## **إنشاء مصغر لمظهر الشكل**
تسمح هذه الطريقة بإنشاء مصغرات للأشكال للمطورين بتوليد مصغر في حدود مظهر الشكل. تأخذ هذه الطريقة بعين الاعتبار جميع تأثيرات الشكل. يُقيد المصغر المُولد من حيث حدود الشريحة. لتوليد مصغر لأي شكل شريحة في حدود مظهره، استخدم كود المثال أدناه:

1. إنشاء مثيل من فئة `Presentation`.
1. الحصول على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغر للشريحة المرجعية مع حدود الشكل كمظهر.
1. حفظ صورة المصغر في أي تنسيق صورة مرغوب فيه.

المثال أدناه يُنشئ مصغرًا عند توليد مصغر بمعامل تغيير الحجم محدد بواسطة المستخدم.

```py
import aspose.slides as slides

# إنشاء فئة Presentation تمثل ملف العرض التقديمي
with slides.Presentation(path + "HelloWorld.pptx") as presentation:
    # إنشاء صورة بمظهر محدد
    with presentation.slides[0].shapes[0].get_image(slides.ShapeThumbnailBounds.APPEARANCE, 1, 1) as bitmap:
        # حفظ الصورة على القرص بتنسيق PNG
        bitmap.save("Shape_thumbnail_Bound_Shape_out.png", slides.ImageFormat.PNG)
```