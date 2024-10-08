---
title: تنسيق الأشكال
type: docs
weight: 20
url: /ar/cpp/shape-formatting/
keywords: "تنسيق الشكل، تنسيق الخطوط، تنسيق أنماط الانضمام، ملء تدرج، ملء نمط، ملء صورة، ملء لون صلب، تدوير الأشكال، تأثيرات الحافة الثلاثية الأبعاد، تأثير الدوران الثلاثي الأبعاد، عرض PowerPoint، C++، Aspose.Slides لـ C++"
description: "تنسيق الشكل في عرض PowerPoint بلغة C++"
---

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. حيث أن الأشكال تتكون من خطوط، يمكنك تنسيق الأشكال عن طريق تعديل أو تطبيق تأثيرات معينة على الخطوط المكونة لها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تحدد كيفية ملء المناطق داخلها.

![تنسيق الشكل باوربوينت](format-shape-powerpoint.png)

**Aspose.Slides لـ C++** يوفر واجهات وخصائص تتيح لك تنسيق الأشكال بناءً على الخيارات المعروفة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط الخط المفضل لديك لشكل معين. خطوات العمل كالتالي:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تعيين لون لخطوط الشكل.
5. تعيين العرض لخطوط الشكل.
6. تعيين [نمط الخط](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a837c78839bf6ebb16979455cd1de59e4) لخط شكل معين.
7. تعيين [نمط التموج](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a7eaad354a35a3b567a7327d625be3c6e) لخط الشكل.
8. كتابة العرض المعدل على شكل ملف PPTX.

يوضح هذا الكود بلغة C++ عملية قمنا فيها بتنسيق مستطيل `AutoShape`:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل تلقائي من نوع مستطيل
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// تعيين لون الملء لشكل المستطيل
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_White());

// تطبيق بعض التنسيقات على خطوط المستطيل
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// تعيين اللون لخط المستطيل
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// كتابة ملف PPTX على القرص
pres->Save(u"RectShpLn_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **تنسيق أنماط الانضمام**
هذه هي 3 خيارات لنوع الانضمام:

* دائري
* مائل
* حافة

بشكل افتراضي، عندما يجمع PowerPoint بين خطين بزاوية (أو عند زاوية شكل)، فإنه يستخدم إعداد **دائري**. ومع ذلك، إذا كنت ترغب في رسم شكل بزاويا حادة جداً، فقد ترغب في اختيار **مائل**.

![نمط الانضمام باوربوينت](join-style-powerpoint.png)

يوضح هذا الكود بلغة C++ عملية تم فيها إنشاء 3 مستطيلات (كما هو موضح في الصورة أعلاه) مع إعدادات نوع الانضمام المائل، الحافة، والدائري:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة 3 أشكال تلقائية من نوع مستطيل
SharedPtr<IAutoShape> shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
SharedPtr<IAutoShape> shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
SharedPtr<IAutoShape> shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);

// تعيين لون الملء لشكل المستطيل
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// تعيين عرض الخط
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// تعيين اللون لخط المستطيل
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// تعيين نمط الانضمام
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// إضافة نص إلى كل مستطيل
shape1->get_TextFrame()->set_Text(u"نمط الانضمام المائل");
shape2->get_TextFrame()->set_Text(u"نمط الانضمام الحافة");
shape3->get_TextFrame()->set_Text(u"نمط الانضمام الدائري");

// كتابة ملف PPTX على القرص
pres->Save(u"RectShpLnJoin_out.pptx", Export::SaveFormat::Pptx);
```

## **ملء تدرج**
في PowerPoint، ملء التدرج هو خيار تنسيق يسمح لك بتطبيق مزيج مستمر من الألوان على شكل معين. على سبيل المثال، يمكنك تطبيق لونين أو أكثر في إعداد حيث يتلاشى لون واحد تدريجياً ويتحول إلى لون آخر.

هذا هو كيفية استخدام Aspose.Slides لتطبيق ملء تدرج على شكل معين:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) للشكل إلى "تدرج".
5. إضافة لونين مفضلين لك مع المواقع المحددة باستخدام طرق `Add` المعروضة من مجموعة `GradientStops` المرتبطة بفئة `GradientFormat`.
6. كتابة العرض المعدل على شكل ملف PPTX.

يوضح كود C++ التالي عملية استخدم فيها تأثير الملء بالتدرج على شكل بيضاوي:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل بيضاوي تلقائي
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);

// تطبيق التنسيق بالتدرج على الشكل البيضاوي
autoShape->get_FillFormat()->set_FillType(FillType::Gradient);
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// تعيين اتجاه التدرج
autoShape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// إضافة 2 من نقاط التدرج
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
autoShape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// كتابة ملف PPTX على القرص
pres->Save(u"FillShapesGradient_out.pptx", Export::SaveFormat::Pptx);
```

## **ملء نمط**
في PowerPoint، ملء النمط هو خيار تنسيق يسمح لك بتطبيق تصميم ثنائي اللون يتكون من نقاط أو خطوط متقاطعة أو علامات على شكل معين. بالإضافة إلى ذلك، يمكنك اختيار الألوان المفضلة لديك لواجهة نمط الألوان والخلفية.

يوفر Aspose.Slides أكثر من 45 نمطاً محدداً مسبقاً يمكن استخدامها لتنسيق الأشكال وإثراء العروض التقديمية. حتى بعد اختيار نمط محدد مسبقاً، يمكنك تحديد الألوان التي يجب أن يحتوي عليها النمط.

هذا هو كيفية استخدام Aspose.Slides لتطبيق ملء نمط على شكل معين:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) للشكل إلى "نمط".
5. تعيين نمط النمط المفضل لديك للشكل.
6. تعيين [لون الخلفية](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#af55b6343b7bd80d0ad95070e96b8766e) لـ [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
7. تعيين [لون الواجهة](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_pattern_format#a4121d8c2233df4b90cbfd6ea4c312cbe) لـ [PatternFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.pattern_format).
8. كتابة العرض المعدل على شكل ملف PPTX.

يوضح كود C++ التالي عملية تم فيها استخدام ملء النمط لتجميل مستطيل:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل مستطيل تلقائي
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// تعيين نوع الملء إلى نمط
autoShape->get_FillFormat()->set_FillType(FillType::Pattern);

// تعيين نمط النمط
autoShape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تعيين ألوان النمط الخلفية والواجهة
autoShape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color ( Color::get_LightGray());
autoShape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// كتابة ملف PPTX على القرص
pres->Save(u"RectShpPatt_out.pptx", Export::SaveFormat::Pptx);
```

## **ملء الصورة**
في PowerPoint، ملء الصورة هو خيار تنسيق يسمح لك بوضع صورة داخل شكل. بشكل أساسي، يمكنك استخدام صورة كخلفية للشكل.

هذا هو كيفية استخدام Aspose.Slides لملء شكل بصورة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) للشكل إلى "صورة".
5. تعيين وضع ملء الصورة إلى بلاط.
6. إنشاء كائن `IPPImage` باستخدام الصورة التي سيتم استخدامها لملء الشكل.
7. تعيين خاصية `Picture.Image` لكائن `PictureFillFormat` إلى `IPPImage` الذي تم إنشاؤه حديثاً.
8. كتابة العرض المعدل على شكل ملف PPTX.

يوضح كود C++ التالي كيفية ملء شكل بصورة:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل مستطيل تلقائي
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// تعيين نوع الملء إلى صورة
autoShape->get_FillFormat()->set_FillType(FillType::Picture);

// تعيين وضع ملء الصورة
autoShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// تعيين الصورة
auto img = Images::FromFile(u"Tulips.jpg");
auto imgx = pres->get_Images()->AddImage(img);
autoShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(imgx);

// كتابة ملف PPTX على القرص
pres->Save(u"RectShpPic_out.pptx", Export::SaveFormat::Pptx);
```

## **ملء لون صلب**
في PowerPoint، ملء اللون الصلب هو خيار تنسيق يسمح لك بملء شكل بلون واحد. اللون المختار غالباً ما يكون لوناً عادياً. يُطبق اللون على خلفية الشكل مع أي تأثيرات أو تعديلات خاصة.

هذا هو كيفية استخدام Aspose.Slides لتطبيق ملء لون صلب على شكل معين:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#a73f3a585b379b3df191d07931378e40a) للشكل إلى "صلب".
5. تعيين لونك المفضل للشكل.
6. كتابة العرض المعدل على شكل ملف PPTX.

توضح الخطوات المذكورة أعلاه في المثال أدناه.

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل مستطيل تلقائي
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// تعيين نوع الملء إلى صلب
autoShape->get_FillFormat()->set_FillType(FillType::Solid);

// تعيين اللون للمستطيل
autoShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// كتابة ملف PPTX على القرص
pres->Save(u"RectShpSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **تعيين الشفافية**

في PowerPoint، عندما تقوم بملء الأشكال بألوان صلبة، تدرجات، صور، أو نقوش، يمكنك تحديد مستوى الشفافية الذي يحدد مدى عدم احتماء الملء. بهذه الطريقة، على سبيل المثال، إذا قمت بتعيين مستوى شفافية منخفض، ستظهر الكائن الخلفية خلف الشكل.

يسمح لك Aspose.Slides بتعيين مستوى الشفافية لشكل بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. استخدام `Color.FromArgb` مع مكون ألفا مضبوط.
5. حفظ الكائن كملف PowerPoint.

يوضح هذا الكود بلغة C++ العملية:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل صلب
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);

// إضافة شكل شفاف فوق الشكل الصلب
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(128, 204, 102, 0));
   
// كتابة ملف PPTX على القرص
pres->Save(u"ShapeTransparentOverSolid_out.pptx", Export::SaveFormat::Pptx);
```

## **تدوير الأشكال**
يسمح لك Aspose.Slides بتدوير شكل مضاف إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تدوير الشكل بالدرجات المطلوبة.
5. كتابة العرض المعدل كملف PPTX.

يوضح هذا الكود بلغة C++ كيفية تدوير شكل بزاوية 90 درجة:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل مستطيل تلقائي
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);

// تدوير الشكل بزاوية 90 درجة
autoShape->set_Rotation(90.f);

// كتابة ملف PPTX على القرص
pres->Save(u"RectShpRot_out.pptx", Export::SaveFormat::Pptx);
```

## **إضافة تأثيرات حافة ثلاثية الأبعاد**
يسمح لك Aspose.Slides بإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل من خلال تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تعيين القيم المفضلة لديك على خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) للشكل.
5. كتابة العرض على القرص.

يوضح هذا الكود بلغة C++ كيفية إضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);

// إضافة شكل إلى الشريحة
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
auto format = shape->get_LineFormat()->get_FillFormat();
format->set_FillType(FillType::Solid);
format->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// تعيين خصائص ThreeDFormat للشكل
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// كتابة العرض كملف PPTX
pres->Save(u"Bavel_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **إضافة تأثير دوران ثلاثي الأبعاد**
يسمح لك Aspose.Slides بتطبيق تأثيرات الدوران ثلاثي الأبعاد على شكل من خلال تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/class/aspose.slides.three_d_format) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_shape) إلى الشريحة.
4. تحديد الأشكال المفضلة لديك لـ [CameraType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_camera#aea0717e8ef5f3199df99ed2cb2ea2dcb) و [LightType](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_light_rig#a2cd12029664967d0e2f93eee25a4963f).
5. كتابة العرض على القرص.

يوضح هذا الكود بلغة C++ كيفية تطبيق تأثيرات الدوران ثلاثية الأبعاد على شكل:

```cpp
// إنشاء مثيل لفئة العرض يمثل ملف عرض
auto pres = MakeObject<Presentation>();

// الحصول على الشريحة الأولى
auto slide = pres->get_Slides()->idx_get(0);
    
// إضافة شكل إلى الشريحة
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);

// تعيين خصائص ThreeDFormat للشكل
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// إضافة شكل إلى الشريحة
shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30, 300, 200, 200);

// تعيين خصائص ThreeDFormat للشكل
shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(0, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// كتابة العرض كملف PPTX
pres->Save(u"Rotation_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **إعادة تعيين التنسيق**

يوضح هذا الكود بلغة C++ كيفية إعادة تعيين التنسيق في شريحة وإرجاع الموضع والحجم وتنسيق كل شكل لديه عنصر نائبบน [LayoutSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.layout_slide) إلى قيمهم الافتراضية:

```c++
auto pres = System::MakeObject<Presentation>();

for (auto slide : pres->get_Slides())
{
    // سيتم إرجاع كل شكل على الشريحة الذي لديه عنصر نائب على التخطيط إلى قيمه الافتراضية
    slide->Reset();
}
```