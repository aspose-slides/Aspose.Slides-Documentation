---
title: إنشاء صور مصغرة لأشكال العرض التقديمي في C++
linktitle: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/cpp/shape-thumbnails/
keywords:
- صورة مصغرة للشكل
- صورة الشكل
- عرض الشكل
- تصيير الشكل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء صور مصغرة عالية الجودة لأشكال PowerPoint باستخدام Aspose.Slides for C++ – إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---

## **إنشاء صورة مصغرة للشكل**
يُستخدم Aspose.Slides for C++ لإنشاء ملفات عرض شرائح حيث تكون كل صفحة شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. لكن في بعض الأحيان قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات يساعدك Aspose.Slides for C++ على إنشاء صور مصغرة لأشكال الشرائح. يتم شرح كيفية استخدام هذه الميزة في هذه المقالة.
تشرح هذه المقالة كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة للشكل داخل شريحة.
- إنشاء صورة مصغرة للشكل لشريحة مع أبعاد معرفّة من قبل المستخدم.
- إنشاء صورة مصغرة للشكل ضمن حدود مظهر الشكل.
- إنشاء صورة مصغرة لعقدة SmartArt الطفل.

## **إنشاء صورة مصغرة للشكل من شريحة**
لإنشاء صورة مصغرة للشكل من أي شريحة باستخدام Aspose.Slides for C++:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع أي شريحة باستخدام معرفها أو رقم الفهرس الخاص بها.
1. الحصول على صورة مصغرة للشكل من الشريحة المشار إليها بالمقياس الافتراضي.
1. حفظ صورة المصغرة بأي صيغة صورة مرغوبة.

المثال أدناه يولد صورة مصغرة للشكل.
```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **إنشاء صورة مصغرة بمعامل قياس مخصص**
لإنشاء صورة مصغرة للشكل لأي شكل شريحة باستخدام Aspose.Slides for C++:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع أي شريحة باستخدام معرفها أو رقم الفهرس الخاص بها.
1. الحصول على صورة مصغرة للشريحة المشار إليها بحدود الشكل.
1. حفظ صورة المصغرة بأي صيغة صورة مرغوبة.

المثال أدناه يولد صورة مصغرة بمعامل مقياس معرف من قبل المستخدم.
```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // التحجيم على المحورين X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **إنشاء صورة مصغرة لمظهر الشكل بناءً على الحدود**
تسمح هذه الطريقة لإنشاء صور مصغرة للأشكال للمطورين بتوليد صورة مصغرة ضمن حدود مظهر الشكل. تأخذ جميع تأثيرات الشكل في الاعتبار. يتم تقييد صورة الشكل المصغرة بحدود الشريحة. لتوليد صورة مصغرة لأي شكل شريحة ضمن حدود مظهره، استخدم كود العينة التالي:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع أي شريحة باستخدام معرفها أو رقم الفهرس الخاص بها.
1. الحصول على صورة مصغرة للشريحة المشار إليها بحدود الشكل كمظهر.
1. حفظ صورة المصغرة بأي صيغة صورة مرغوبة.

المثال أدناه ينشئ صورة مصغرة بمعامل مقياس معرف من قبل المستخدم.
```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // التحجيم على المحورين X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **الأسئلة الشائعة**

**ما هي صيغ الصور التي يمكن استخدامها عند حفظ الصور المصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير الأشكال كـ SVG متجه](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) عن طريق حفظ محتوى الشكل كـ SVG.

**ما الفرق بين حدود الشكل (Shape) وحدود المظهر (Appearance) عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/cpp/shape-effect/) (الظلال، التوهج، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كـ مخفي؟ هل سيظل يتم إنشاء صورة مصغرة له؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن توليده؛ علم التخفي يؤثر على عرض الشرائح لكنه لا يمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال المجمعة، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثَّل كـ [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/cpp/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/cpp/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة نظاميًا على جودة الصور المصغرة للأشكال النصية؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/cpp/custom-font/) (أو [تهيئة استبدال الخطوط](/slides/ar/cpp/font-substitution/)) لتجنب السقوط غير المرغوب فيه وإعادة تدفق النص.