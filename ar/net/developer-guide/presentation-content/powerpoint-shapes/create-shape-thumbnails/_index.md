---
title: إنشاء صور مصغرة لأشكال العروض التقديمية في .NET
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/net/create-shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- رسم الشكل
- عرض الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة للأشكال من شرائح PowerPoint باستخدام Aspose.Slides for .NET – قم بإنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---
## **المقدمة**

يتم استخدام Aspose.Slides for .NET لإنشاء ملفات عروض تقديمية حيث كل صفحة هي شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات يساعدك Aspose.Slides for .NET في إنشاء صور مصغرة لأشكال الشرائح. يتم شرح كيفية استخدام هذه الميزة في هذه المقالة.
تشرح هذه المقالة كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة للـ shape داخل شريحة.
- إنشاء صورة مصغرة للـ shape في شريحة بأبعاد يحددها المستخدم.
- إنشاء صورة مصغرة للـ shape ضمن حدود مظهر الـ shape.

## **إنشاء صورة مصغرة للـ Shape من شريحة**
لإنشاء صورة مصغرة للـ shape من أي شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. الحصول على صورة مصغرة للـ shape للشرحة المشار إليها بالمقياس الافتراضي.
1. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.

المثال أدناه يولد صورة مصغرة للـ shape.

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


## **إنشاء صورة مصغرة بمعامل مقياس محدد من قبل المستخدم**
لإنشاء صورة مصغرة للـ shape لأي شكل شريحة باستخدام Aspose.Slides for .NET:

1. إنشاء كائن من الفئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. الحصول على صورة مصغرة للشرحة المشار إليها بحدود الـ shape.
1. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.

المثال أدناه يولد صورة مصغرة باستخدام معامل مقياس يحدده المستخدم.

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


## **إنشاء صورة مصغرة لمظهر الـ Shape بناءً على الحدود**
هذه الطريقة لإنشاء صور مصغرة للأشكال تتيح للمطورين إنشاء صورة مصغرة ضمن حدود مظهر الـ shape. وهي تأخذ في الاعتبار جميع تأثيرات الـ shape. الصورة المصغرة التي تم إنشاؤها مقيدة بحدود الشريحة. لإنشاء صورة مصغرة لأي شكل شريحة ضمن حدود مظهره، استخدم الشيفرة النموذجية التالية:

1. إنشاء كائن من الفئة `Presentation`.
1. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
1. الحصول على صورة مصغرة للشرحة المشار إليها بحدود الـ shape كالمظهر.
1. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.

المثال أدناه ينشئ صورة مصغرة باستخدام معامل مقياس يحدده المستخدم.

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

## **الحصول على الحدود البصرية الفعلية للـ Shape**

خصائص الإطار لـ[IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/) — خصائص `X` و `Y` و `Width` و `Height` — تصف المستطيل المخزن في نموذج العرض. قد يمتد المحتوى الذي يتم عرضه فعليًا خارج هذا الإطار أو يشغل مستطيلًا محاذيًا مختلفًا. يمكن أن تغير التدوير، الخطوط الخارجية، رؤوس الأسهم، تخطيط النص وتدفقه، هندسة SmartArt المولدة، وغيرها من تأثيرات العرض المنطقة المشغولة.

استخدم [GetVisualBounds](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getvisualbounds/) لحساب تلك المنطقة المشغولة دون إنشاء صورة. تُعيد الطريقة كائن [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) بإحداثيات الشريحة. المستطيل المعاد ليس مقطوعًا إلى الشريحة، لذا قد تكون إحداثياته سلبية عندما يمتد المحتوى خارج أصل الشريحة.

حاليًا، لا يُعلن عن [GetVisualBounds](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getvisualbounds/) في واجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/). لذلك، احتفظ بالـ shape المستخرج من مجموعة أشكال الشريحة كقيمة واجهة وقم بتحويله فقط عند استدعاء الطريقة.

المثال التالي يحصل على الإطار والحدود البصرية ويقارنهما:

```csharp
using var presentation = new Presentation("example.pptx");

var slide = presentation.Slides[0];
IShape shape = slide.Shapes[0];

var visualBounds = ((Shape)shape).GetVisualBounds();
var frameBounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);

Console.WriteLine($"Frame bounds: {frameBounds}");
Console.WriteLine($"Visual bounds: {visualBounds}");
```

يمكن استخدام نفس [RectangleF](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.rectanglef) لمحاذاة الأشكال المجاورة إلى حافته `Left` أو `Right` أو `Top` أو `Bottom`؛ أو لحجز مساحة كافية في تخطيط مولد؛ أو لاكتشاف المحتوى خارج منطقة مسموح بها. الحدود البصرية مفيدة بشكل خاص للـ SmartArt، صناديق النص، الأسهم، الصور، الأشكال المدورة، ومجموعات الأشكال، حيث قد لا يمثل الإطار المخزن النتيجة المعروضة بالكامل.

استخدم [GetVisualBounds](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getvisualbounds/) عندما تحتاج إلى إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [IShape.GetImage](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/getimage/) عندما تحتاج إلى عرض الـ shape. مع [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/net/aspose.slides/shapethumbnailbounds/)، `ShapeThumbnailBounds.Shape` يحدد حجم الصورة من حدود الـ shape، بما في ذلك إعدادات الخط الخارجي، بينما `ShapeThumbnailBounds.Appearance` يحدد الحجم من مظهر الـ shape ويقيد النتيجة بحدود الشريحة. بالمقابل، تُعيد [GetVisualBounds](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/getvisualbounds/) فقط المستطيل المحتسب ولا تقصه إلى الشريحة.

## **الأسئلة المتكررة**

**ما تنسيقات الصور التي يمكن استخدامها عند حفظ صور مصغرة للـ shape؟**

يمكنك استخدام [PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ar/net/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا تصدير الأشكال كملفات SVG متجهة عبر حفظ محتوى الـ shape كملف SVG.

**ما الفرق بين حدود الـ Shape وAppearance عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الـ shape؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/net/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة إخفاء على الـ shape؟ هل سيظل يتم إنشاء صورة مصغرة له؟**

يبقى الـ shape المخفي جزءًا من النموذج ويمكن عرضه؛ علامة الإخفاء تؤثر على عرض الشريحة في العرض التقديمي ولكنها لا تمنع إنشاء صورة الـ shape.

**هل يتم دعم مجموعات الأشكال، الرسوم البيانية، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/net/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/net/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/ar/net/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كملف SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/net/custom-font/) (أو [تكوين استبدال الخطوط](/slides/ar/net/font-substitution/)) لتجنب الإرجاع غير المرغوب فيه وإعادة تدفق النص.