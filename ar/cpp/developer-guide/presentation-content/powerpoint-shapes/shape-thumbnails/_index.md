---
title: صور مصغرة للأشكال
type: docs
weight: 70
url: /ar/cpp/shape-thumbnails/
keywords: 
- صورة مصغرة لشكل
- صورة شكل
- PowerPoint
- تقديم
- C++
- Aspose.Slides لـ С++
description: "استخراج صور مصغرة للأشكال من عروض PowerPoint باستخدام C++"
---


## **إنشاء صورة مصغرة لشكل**
تستخدم Aspose.Slides لـ C++ لإنشاء ملفات تقديم حيث تكون كل صفحة هي شريحة. يمكن عرض هذه الشرائح بفتح ملفات التقديم باستخدام Microsoft PowerPoint. ولكن أحيانًا، قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، تساعدك Aspose.Slides لـ C++ في توليد صور مصغرة لأشكال الشرائح. كيفية استخدام هذه الميزة موصوفة في هذه المقالة.
تشرح هذه المقالة كيفية توليد صور مصغرة للشرائح بطرق مختلفة:

- توليد صورة مصغرة لشكل داخل شريحة.
- توليد صورة مصغرة لشكل شريحة بأبعاد محددة من قبل المستخدم.
- توليد صورة مصغرة داخل حدود مظهر الشكل.
- توليد صورة مصغرة لعقدة SmartArt فرعية.

## **توليد صورة مصغرة لشكل من الشريحة**
لتوليد صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides لـ C++:

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. احصل على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشكل من الشريحة المرجعية بمقياس افتراضي.
1. احفظ الصورة المصغرة في أي تنسيق صورة مرغوب.

المثال أدناه يولِّد صورة مصغرة لشكل.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```


## **توليد صورة مصغرة بعامل مقياس محدد من قبل المستخدم**
لتوليد صورة مصغرة لشكل أي شريحة باستخدام Aspose.Slides لـ C++:

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. احصل على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة من الشريحة المرجعية مع حدود الشكل.
1. احفظ الصورة المصغرة في أي تنسيق صورة مرغوب.

المثال أدناه يولِّد صورة مصغرة مع عامل مقياس محدد من قبل المستخدم.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // المقياس على المحاور X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **إنشاء صورة مصغرة داخل حدود مظهر الشكل**
تسمح هذه الطريقة بإنشاء صور مصغرة للأشكال للمطورين بتوليد صورة مصغرة داخل حدود مظهر الشكل. تأخذ في اعتبارها جميع تأثيرات الشكل. الصورة المصغرة المولدة مقيدة بحواف الشريحة. لتوليد صورة مصغرة لأي شكل شريحة ضمن حدوده، استخدم الكود النموذجي التالي:

1. أنشئ مثيل من [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) class.
1. احصل على مرجع لأي شريحة باستخدام معرفها أو فهرسها.
1. احصل على صورة مصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
1. احفظ الصورة المصغرة في أي تنسيق صورة مرغوب.

المثال أدناه ينشئ صورة مصغرة مع توليد صورة مصغرة مع عامل مقياس محدد من قبل المستخدم.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // المقياس على المحاور X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```