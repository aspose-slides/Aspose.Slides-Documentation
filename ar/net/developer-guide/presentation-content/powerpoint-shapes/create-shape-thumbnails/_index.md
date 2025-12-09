---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في .NET
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/net/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- تصيير الشكل
- تصيير الشكل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides for .NET – بسهولة إنشاء وتصدير صور مصغرة للعروض التقديمية."
---

يتم استخدام Aspose.Slides for .NET لإنشاء ملفات عروض تقديمية حيث تكون كل صفحة شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. لكن في بعض الأحيان قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعدك Aspose.Slides for .NET على إنشاء صور مصغرة لأشكال الشرائح. يتم شرح كيفية استخدام هذه الميزة في هذه المقالة.

تشرح هذه المقالة كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة للشكل داخل شريحة.
- إنشاء صورة مصغرة للشكل لشرائح بأبعاد محددة من قبل المستخدم.
- إنشاء صورة مصغرة للشكل ضمن حدود مظهر الشكل.
- إنشاء صورة مصغرة لعقدة SmartArt الفرعية.


## **إنشاء صورة مصغرة للشكل من الشريحة**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغرة للشكل للشفرة المرجعية على المقياس الافتراضي.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

المثال أدناه يُنشئ صورة مصغرة للشكل.
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



## **إنشاء صورة مصغرة بمعامل ضبط مقياس مخصص**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من فئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغرة للشفرة المرجعية مع حدود الشكل.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

المثال أدناه يُنشئ صورة مصغرة بمعامل ضبط مقياس مخصص.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // التحجيم على محوري X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```



## **إنشاء صورة مصغرة لمظهر الشكل ضمن الحدود**
تتيح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين إنشاء صورة مصغرة ضمن حدود مظهر الشكل. تأخذ جميع تأثيرات الشكل في الاعتبار. تكون صورة الشكل المصغرة المحدودة بحدود الشريحة. لإنشاء صورة مصغرة لأي شكل شريحة ضمن حدود مظهره، استخدم الشيفرة النموذجية التالية:

1. إنشاء مثيل من فئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغرة للشفرة المرجعية مع حدود الشكل كمظهر.
1. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

المثال أدناه يُنشئ صورة مصغرة بمعامل ضبط مقياس مخصص.
```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // التحجيم على محوري X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```


## **الأسئلة المتكررة**

**ما تنسيقات الصور التي يمكن استخدامها عند حفظ صور المصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كملفات SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) بحفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود Shape و Appearance عند تصيير صورة مصغرة؟**

`Shape` يستخدم الهندسة الخاصة بالشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/net/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على شكل كـ مخفي؟ هل سيظل يُصدّر كصورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن تصييره؛ علم الإخفاء يؤثر على عرض الشريحة في العرض التقديمي لكنه لا يمنع إنشاء صورة الشكل.

**هل تدعم الأشكال الجماعية، المخططات، SmartArt، والكائنات المعقدة الأخرى؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة في النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/net/custom-font/) (أو [تكوين بدائل الخطوط](/slides/ar/net/font-substitution/)) لتجنب الاستعاضة غير المرغوب فيها وإعادة تدفق النص.