---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في .NET
linktitle: مصغرات الأشكال
type: docs
weight: 70
url: /ar/net/create-shape-thumbnails/
keywords:
- مصغرة الشكل
- صورة الشكل
- رسم الشكل
- تصيير الشكل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "توليد صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides for .NET - إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---

Aspose.Slides for .NET تُستخدم لإنشاء ملفات عرض حيث كل صفحة هي شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. لكن في بعض الأحيان قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات تساعدك Aspose.Slides for .NET على إنشاء صور مصغرة لأشكال الشريحة. يوضح هذا المقال كيفية استخدام هذه الميزة.

يشرح هذا المقال كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل بشريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة ضمن حدود مظهر الشكل.
- إنشاء صورة مصغرة لعقدة فرعية في SmartArt.


## **إنشاء صورة مصغرة للشكل من شريحة**
لإنشاء صورة مصغرة للشكل من أي شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. الحصول على صورة المصغرة للشكل للشرحة المشار إليها بالمقياس الافتراضي.
1. حفظ صورة المصغرة بأي تنسيق صورة ترغب به.

المثال أدناه يُولّد صورة مصغرة للشكل.
```c#
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage())
    {
        image.Save("Shape_thumbnail_out.png", ImageFormat.Png);
    }
}
```



## **إنشاء صورة مصغرة بمعامل تحجيم يحدده المستخدم**
لإنشاء صورة مصغرة لشكل أي شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من الفئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. الحصول على صورة المصغرة للشرحة المشار إليها مع حدود الشكل.
1. حفظ صورة المصغرة بأي تنسيق صورة ترغب به.

المثال أدناه يُولّد صورة مصغرة بمعامل تحجيم يحدده المستخدم.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // التحجيم على المحور X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```



## **إنشاء صورة مصغرة لمظهر الشكل بناءً على الحدود**
تتيح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين توليد صورة مصغرة ضمن حدود مظهر الشكل، مع أخذ جميع تأثيرات الشكل في الاعتبار. تُقيد الصورة المصغرة الناتجة بحدود الشريحة. لتوليد صورة مصغرة لأي شكل شريحة في حدود مظهره، استخدم عينة الشيفرة التالية:

1. إنشاء مثيل من الفئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. الحصول على صورة المصغرة للشرحة المشار إليها مع حدود الشكل كالمظهر.
1. حفظ صورة المصغرة بأي تنسيق صورة ترغب به.

المثال أدناه يُنشئ صورة مصغرة بمعامل تحجيم يحدده المستخدم.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // التحجيم على المحور X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```


## **FAQ**

**ما تنسيقات الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجه](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) بحفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود الشكل (Shape) وحدود المظهر (Appearance) عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/net/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم تعليم الشكل بأنه مخفي؟ هل سيظل يُنشأ له صورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن توليده؛ علم الإخفاء يؤثر على عرض الشرائح فقط ولا يمنع إنشاء صورة المصغرة للشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/net/custom-font/) (أو [تكوين استبدالات الخط](/slides/ar/net/font-substitution/)) لتجنب الاعتماد على الخطوط الافتراضية غير المرغوبة وإعادة تدفق النص.