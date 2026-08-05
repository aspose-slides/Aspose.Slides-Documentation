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
- تجسيد الشكل
- الحدود البصرية
- حدود الشكل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "إنشاء صور مصغرة ذات جودة عالية لأشكال PowerPoint باستخدام Aspose.Slides for C++ – إنشاء وتصدير صور مصغرة للعرض التقديمي بسهولة."
---
## **المقدمة**

يتم استخدام Aspose.Slides لإنشاء ملفات عرض تقديمي حيث كل صفحة هي شريحة. يمكن عرض هذه الشرائح بفتح ملفات العرض باستخدام Microsoft PowerPoint. ولكن في بعض الأحيان قد يحتاج المطورون إلى عرض صور الأشكال بشكل منفصل في عارض صور. في مثل هذه الحالات، يساعدك Aspose.Slides على إنشاء صور مصغرة لأشكال الشريحة. يتم وصف طريقة استخدام هذه الميزة في هذه المقالة.

تشرح هذه المقالة كيفية إنشاء صور مصغرة للشرائح بطرق مختلفة:

- إنشاء صورة مصغرة لشكل داخل شريحة.
- إنشاء صورة مصغرة لشكل لشريحة مع أبعاد معرفة من قبل المستخدم.
- إنشاء صورة مصغرة داخل حدود مظهر الشكل.

## **إنشاء صورة مصغرة لشكل من شريحة**

لإنشاء صورة مصغرة لشكل من أي شريحة باستخدام Aspose.Slides for C++:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. الحصول على صورة مصغرة للشكل من الشريحة المرجعية بالمقياس الافتراضي.
4. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

المثال أدناه يولد صورة مصغرة للشكل.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **إنشاء صورة مصغرة بمعامل قياس محدد من قبل المستخدم**

لإنشاء صورة مصغرة للشكل لأي شكل شريحة باستخدام Aspose.Slides for C++:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. الحصول على صورة المصغرة للشريحة المرجعية مع حدود الشكل.
4. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

المثال أدناه يولد صورة مصغرة باستخدام معامل قياس معرف من قبل المستخدم.

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

هذه الطريقة لإنشاء صور مصغرة للأشكال تسمح للمطورين بإنشاء صورة مصغرة داخل حدود مظهر الشكل. تأخذ في الاعتبار جميع تأثيرات الشكل. يتم تقييد الصورة المصغرة الناتجة بحدود الشريحة. لإنشاء صورة مصغرة لأي شكل شريحة ضمن حدود مظهره، استخدم عينة الشيفرة التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
2. الحصول على مرجع أي شريحة باستخدام معرّفها أو فهرسها.
3. الحصول على صورة المصغرة للشريحة المرجعية مع حدود الشكل كمظهر.
4. حفظ صورة المصغرة بأي تنسيق صورة مرغوب.

المثال أدناه ينشئ صورة مصغرة باستخدام معامل قياس معرف من قبل المستخدم.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // التحجيم على محوري X و Y.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **الحصول على الحدود البصرية الفعلية للشكل**

خصائص الإطار لـ[IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/) — `IShape::get_X()`، `IShape::get_Y()`، `IShape::get_Width()`، و`IShape::get_Height()` — تصف المستطيل المخزن في نموذج العرض التقديمي. المحتوى الذي يتم عرضه فعليًا يمكن أن يمتد خارج هذا الإطار أو يشغل مستطيلًا محاذيًا للمحاور مختلفًا. يمكن للدوران، والحدود، ورؤوس الأسهم، وتخطيط النص وتدفقه، والهندسة المتولدة للـSmartArt، وغيرها من تأثيرات العرض أن تغيّر المنطقة المحتلة.

استخدم [Shape::GetVisualBounds](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/getvisualbounds/) لحساب تلك المنطقة المحتلة دون إنشاء صورة. تُعيد الطريقة كائنًا من النوع [RectangleF](https://reference.aspose.com/slides/ar/cpp/system.drawing/rectanglef/) بإحداثيات الشريحة. المستطيل المُعاد ليس مقصوصًا إلى حدود الشريحة، لذا يمكن أن تكون إحداثياته سلبية عندما يمتد المحتوى خارج أصل الشريحة.

حاليًا لا يتم إعلان [Shape::GetVisualBounds] في واجهة [IShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/). لذلك، احفظ الشكل المستخرج من مجموعة أشكال الشريحة كقيمة واجهة وقم بتحويله فقط عند استدعاء الطريقة.

المثال التالي يحصل على حدود الإطار والحدود البصرية ويقارن بينها:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

يمكن استخدام نفس [RectangleF](https://reference.aspose.com/slides/ar/cpp/system.drawing/rectanglef/) لمحاذاة الأشكال القريبة إلى حافة `RectangleF::get_Left()` أو `RectangleF::get_Right()` أو `RectangleF::get_Top()` أو `RectangleF::get_Bottom()`؛ لحجز مساحة كافية في تخطيط مُولَّد؛ أو لاكتشاف محتوى خارج منطقة مسموح بها. تكون الحدود البصرية مفيدة بشكل خاص للـSmartArt، مربعات النص، الأسهم، الصور، الأشكال المدارة، ومجموعات الأشكال، حيث قد لا يمثل الإطار المخزن النتيجة الكاملة المعروضة.

استخدم [Shape::GetVisualBounds](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/getvisualbounds/) عندما تحتاج إلى إحداثيات للتخطيط أو التحقق ولا تحتاج إلى صورة نقطية. استخدم [IShape::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/getimage/) عندما تحتاج إلى عرض الشكل. مع [ShapeThumbnailBounds](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapethumbnailbounds/)، يقوم `ShapeThumbnailBounds::Shape` بتحديد حجم الصورة بناءً على حدود الشكل، بما في ذلك إعدادات الحدود، بينما يقوم `ShapeThumbnailBounds::Appearance` بتحديد حجمها بناءً على مظهر الشكل ويقيد النتيجة بحدود الشريحة. على النقيض من ذلك، يُعيد [Shape::GetVisualBounds](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/getvisualbounds/) فقط المستطيل المحسوب ولا يقطعه إلى حدود الشريحة.

## **الأسئلة الشائعة**

**ما هي صيغ الصور التي يمكن استخدامها عند حفظ صور مصغرة للأشكال؟**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imageformat/)، وغيرها. يمكن أيضًا [تصدير كـ SVG متجه](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/writeassvg/) عن طريق حفظ محتوى الشكل كملف SVG.

**ما هو الفرق بين حدود Shape و Appearance عند إنشاء صورة مصغرة؟**

`Shape` يستخدم هندسة الشكل؛ `Appearance` يأخذ [التأثيرات البصرية](/slides/ar/cpp/shape-effect/) (الظلال، التوهجات، إلخ) في الاعتبار.

**ماذا يحدث إذا تم وضع علامة على الشكل كـ مخفي؟ هل سيستمر في العرض كصورة مصغرة؟**

يبقى الشكل المخفي جزءًا من النموذج ويمكن عرضه؛ علم الإخفاء يؤثر على عرض الشريحة في العرض التقديمي لكنه لا يمنع إنشاء صورة الشكل.

**هل يتم دعم الأشكال المجموعة، المخططات، SmartArt، وغيرها من الكائنات المعقدة؟**

نعم. أي كائن يُمثل كـ[Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/) (بما في ذلك [GroupShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/groupshape/)، [Chart](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chart/)، و[SmartArt](https://reference.aspose.com/slides/ar/cpp/aspose.slides.smartart/smartart/)) يمكن حفظه كصورة مصغرة أو كـ SVG.

**هل تؤثر الخطوط المثبتة على النظام على جودة الصور المصغرة لأشكال النص؟**

نعم. يجب عليك [توفير الخطوط المطلوبة](/slides/ar/cpp/custom-font/) (أو [تكوين استبدال الخطوط](/slides/ar/cpp/font-substitution/)) لتجنب الاستبدالات غير المرغوبة وإعادة تدفق النص.