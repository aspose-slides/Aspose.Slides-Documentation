---
title: إنشاء صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/net/create-shape-thumbnails/
keywords:
- مصغرات الشكل
- صورة الشكل
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "استخراج مصغرات الأشكال من عروض PowerPoint التقديمية باستخدام C# أو .NET"
---

Aspose.Slides for .NET تُستخدم لإنشاء ملفات عرض حيث تكون كل صفحة شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان قد يحتاج المطورون إلى مشاهدة صور الأشكال بشكل منفصل في عارض صور. في هذه الحالات تساعدك Aspose.Slides for .NET على إنشاء صور مصغرة لأشكال الشرائح. يشرح هذا المقال كيفية استخدام هذه الميزة.

يشرح هذا المقال كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل بشريحة بأبعاد معرفة من قبل المستخدم.
- إنشاء صورة مصغرة في حدود مظهر الشكل.
- إنشاء صورة مصغرة لعقدة فرعية في SmartArt.


## **Generate Shape Thumbnail from Slide**
لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغرة للشكل من الشريحة المرجعية بالمقياس الافتراضي.
1. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.

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



## **Generate User Defined Scaling Factor Thumbnail**
لإنشاء صورة مصغرة لشكل من أي شكل شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء مثيل من الفئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغرة للشريحة المرجعية مع حدود الشكل.
1. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.

المثال أدناه يُنشئ صورة مصغرة باستخدام عامل تحجيم معرف من قبل المستخدم.
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



## **Create Bounds Shape's Appearance Thumbnail**
تسمح هذه الطريقة بإنشاء صور مصغرة للأشكال في حدود مظهر الشكل، مع مراعاة جميع تأثيرات الشكل. تكون الصورة المصغرة المحدودة بحدود الشريحة. لإنشاء صورة مصغرة لأي شكل شريحة في حدود مظهره، استخدم الشفرة النموذجية التالية:

1. إنشاء مثيل من الفئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.

المثال أدناه ينشئ صورة مصغرة باستخدام عامل تحجيم معرف من قبل المستخدم.
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


## **FAQ**

**ما تنسيقات الصور التي يمكن استخدامها عند حفظ الصور المصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجهي](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) بحفظ محتوى الشكل كملف SVG.

**ما الفرق بين حدود Shape و Appearance عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/net/shape-effect/) (الظلال، الوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كمخفي؟ هل سيظل يُنشأ له صورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن إنشاء صورة له؛ علامة الإخفاء تؤثر فقط على عرض الشرائح ولا تمنع إنشاء صورة الشكل.

**هل تُدعم الأشكال الجماعية، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثل كــ [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة في النظام على جودة الصور المصغرة للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/net/custom-font/) (أو [تكوين استبدال الخطوط](/slides/ar/net/font-substitution/)) لتجنب الاستبدالات غير المرغوبة وإعادة تدفق النص.