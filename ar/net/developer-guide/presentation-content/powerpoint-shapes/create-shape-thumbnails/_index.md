---
title: إنشاء مصغرات الأشكال
type: docs
weight: 70
url: /ar/net/create-shape-thumbnails/
keywords: 
- مصغر شكل
- صورة شكل
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "استخراج مصغرات الأشكال من العروض التقديمية في PowerPoint باستخدام C# أو .NET"
---

تُستخدم Aspose.Slides لـ .NET لإنشاء ملفات العروض التقديمية حيث تكون كل صفحة عبارة عن شريحة. يمكن عرض هذه الشرائح عن طريق فتح ملفات العروض التقديمية باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان، قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض الصور. في مثل هذه الحالات، تساعدك Aspose.Slides لـ .NET في توليد الصور المصغرة لأشكال الشرائح. كيفية استخدام هذه الميزة موضحة في هذه المقالة.
تشرح هذه المقالة كيفية توليد مصغرات الشرائح بطرق مختلفة:

- توليد مصغر شكل داخل شريحة.
- توليد مصغر شكل لشكل شريحة بأبعاد محددة من قبل المستخدم.
- توليد مصغر شكل ضمن حدود مظهر الشكل.
- توليد مصغر لعقدة فرعية من SmartArt.


## **توليد مصغر شكل من شريحة**
لتوليد مصغر شكل من أي شريحة باستخدام Aspose.Slides لـ .NET:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة مصغر الشكل من الشريحة المرجعية بالمقياس الافتراضي.
1. حفظ صورة المصغر في أي صيغة صورة مرغوبة.

المثال أدناه يولد مصغر شكل.

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


## **توليد مصغر بعامل قياس محدد من قبل المستخدم**
لتوليد مصغر الشكل لأي شكل شريحة باستخدام Aspose.Slides لـ .NET:

1. إنشاء مثيل من فئة `Presentation`.
1. الحصول على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغر من الشريحة المرجعية مع حدود الشكل.
1. حفظ صورة المصغر في أي صيغة صورة مرغوبة.

المثال أدناه يولد مصغرًا مع توليد مصغر مع عامل قياس محدد من قبل المستخدم.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Shape;
float scale = 1; // القياس على محوري X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Scaling Factor Thumbnail_out.png", ImageFormat.Png);
    }
}
```


## **إنشاء مصغر لحدود مظهر الشكل**
تسمح هذه الطريقة بإنشاء مصغرات للأشكال للمطورين بتوليد مصغر ضمن حدود مظهر الشكل. تأخذ في الاعتبار جميع تأثيرات الشكل. يكون مصغر الشكل الناتج مقيدًا بحدود الشريحة. لتوليد مصغر لأي شكل شريحة ضمن حدوده المظهر، استخدم كود العينة التالي:

1. إنشاء مثيل من فئة `Presentation`.
1. الحصول على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. الحصول على صورة المصغر من الشريحة المرجعية مع حدود الشكل كمظهر.
1. حفظ صورة المصغر في أي صيغة صورة مرغوبة.

المثال أدناه يخلق مصغرًا مع توليد مصغر مع عامل قياس محدد من قبل المستخدم.

```c#
ShapeThumbnailBounds bounds = ShapeThumbnailBounds.Appearance;
float scale = 1; // القياس على محوري X و Y.

using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];
    using (IImage image = shape.GetImage(bounds, scale, scale))
    {
        image.Save("Shape_thumbnail_Bound_Shape_out.png", ImageFormat.Png);
    }
}
```