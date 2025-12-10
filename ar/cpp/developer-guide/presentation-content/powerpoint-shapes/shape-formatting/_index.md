---
title: تنسيق أشكال PowerPoint في C++
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/cpp/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تنسيق نمط الوصل
- ملء تدرج
- ملء نمط
- ملء صورة
- ملء نقش
- ملء لون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير بيفيل ثلاثي الأبعاد
- تأثير تدوير ثلاثي الأبعاد
- إعادة ضبط التنسيق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرف على كيفية تنسيق أشكال PowerPoint في C++ باستخدام Aspose.Slides—حدد أنماط الملء والحد والتأثير للملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---

## **نظرة عامة**

في PowerPoint، يمكنك إضافة الأشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق التأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for C++ يوفر واجهات وطرق تسمح لك بتنسيق الأشكال باستخدام الخيارات نفسها المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تنسيق `AutoShape` مستطيل:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// تعيين لون التعبئة للشكل المستطيل.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// تطبيق تنسيق على خطوط المستطيل.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// تعيين اللون لخط المستطيل.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// حفظ ملف PPTX على القرص.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

## **تنسيق أسلوب الوصل**

إليك خيارات ثلاثة لأنواع الوصل:

* مستدير
* مائل
* مقوّس

بشكل افتراضي، عندما يقوم PowerPoint بربط خطين بزاوية (مثل زاوية الشكل)، يستخدم الإعداد **مستدير**. ومع ذلك، إذا كنت ترسم شكلاً بزاويا حادة، قد تفضّل خيار **مائل**.

![أسلوب الوصل في العرض التقديمي](join-style-powerpoint.png)

الكود التالي بلغة C++ يوضح كيف تم إنشاء ثلاثة مستطيلات (كما في الصورة أعلاه) باستخدام إعدادات أسلوب الوصل مائل، مقوّس، ومستدير:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة ثلاثة أشكال تلقائية من النوع Rectangle.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// تعيين لون التعبئة لكل شكل مستطيل.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// تعيين عرض الخط.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// تعيين لون خط كل مستطيل.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// تعيين نمط الوصل.
shape1->get_LineFormat()->set_JoinStyle(LineJoinStyle::Miter);
shape2->get_LineFormat()->set_JoinStyle(LineJoinStyle::Bevel);
shape3->get_LineFormat()->set_JoinStyle(LineJoinStyle::Round);

// إضافة نص إلى كل مستطيل.
shape1->get_TextFrame()->set_Text(u"Miter Join Style");
shape2->get_TextFrame()->set_Text(u"Bevel Join Style");
shape3->get_TextFrame()->set_Text(u"Round Join Style");

// حفظ ملف PPTX على القرص.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **ملء تدرج**

في PowerPoint، ملء التدرج هو خيار تنسيق يسمح لك بتطبيق تدرج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجياً إلى الآخر.

إليك كيفية تطبيق ملء تدرج على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع المواقع المحددة باستخدام طرق `Add` لمجموعة نقاط التدرج التي يوفّرها واجهة [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/).
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C++ يوضح كيفية تطبيق تأثير ملء تدرج على قطع إهليلجية:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// تطبيق تنسيق تدرج على الشكل البيضاوي.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// تعيين اتجاه التدرج.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// إضافة نقطتي تدرج.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// حفظ ملف PPTX على القرص.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![القطع الإهليلجية مع ملء تدرج](gradient-fill.png)

## **ملء نمط**

في PowerPoint، ملء النمط هو خيار تنسيق يسمح لك بتطبيق تصميم من لونين—مثل النقاط أو الخطوط المتوازة أو التعرجات أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة لخلفية النمط ومقدمته.

Aspose.Slides يوفر أكثر من 45 نمطًا مسبقًا يمكنك تطبيقه على الأشكال لتعزيز المظهر البصري لعروضك. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك كيفية تطبيق ملء نمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) للنمط.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C++ يوضح كيفية تطبيق ملء نمط على مستطيل:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تعيين نوع الملء إلى Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// تعيين نمط النقش.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تعيين ألوان الخلفية والواجهة للنقش.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// حفظ ملف PPTX على القرص.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![المستطيل مع ملء نمط](pattern-fill.png)

## **ملء صورة**

في PowerPoint، ملء الصورة هو خيار تنسيق يسمح لك بإدراج صورة داخل شكل—وبالتالي استخدام الصورة كخلفية للشكل.

إليك كيفية استخدام Aspose.Slides لتطبيق ملء صورة على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع ملء الصورة إلى `Tile` (أو أي وضع مفضّل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. مرر الصورة إلى طريقة `ISlidesPicture.set_Image`.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" يحتوي على الصورة التالية:

![صورة اللوتس](lotus.png)

الكود التالي بلغة C++ يوضح كيفية ملء شكل بالصورة:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// تعيين نوع الملء إلى Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// تعيين وضع ملء الصورة.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// تحميل صورة وإضافتها إلى موارد العرض التقديمي.
auto image = Images::FromFile(u"lotus.png");
auto picture = presentation->get_Images()->AddImage(image);
image->Dispose();

// تعيين الصورة.
shape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(picture);

// حفظ ملف PPTX على القرص.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![الشكل مع ملء صورة](picture-fill.png)

### **استخدام صورة مكررة كنقش**

إذا رغبت في تعيين صورة مكررة كنقش وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): يحدد وضع ملء الصورة — إما `Tile` أو `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): يحدد محاذاة المربعات داخل الشكل.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): يتحكم ما إذا كانت المربعات تقلب أفقياً أو عمودياً أو كلياً.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): يحدد الإزاحة الأفقية للمربع (بالنقاط) من أصل الشكل.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): يحدد الإزاحة العمودية للمربع (بالنقاط) من أصل الشكل.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): يعرّف مقياس المربع الأفقي كنسبة مئوية.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): يعرّف مقياس المربع العمودي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة مستطيل مع ملء صورة مكررة وتكوين خيارات التكرار:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto firstSlide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// تعيين نوع التعبئة للشكل إلى Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// تعيين الصورة للشكل.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// تكوين وضع ملء الصورة وخصائص التبليط.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// حفظ ملف PPTX على القرص.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![خيارات التكرار](tile-options.png)

## **ملء لون صلب**

في PowerPoint، ملء اللون الصلب هو خيار تنسيق يملأ الشكل بلون موحد واحد. يُطبق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق ملء لون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون المملوء المفضّل للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C++ يوضح كيفية تطبيق ملء لون صلب على مستطيل في شريحة PowerPoint:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تعيين نوع التعبئة إلى Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// تعيين لون التعبئة.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// حفظ ملف PPTX على القرص.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![الشكل مع ملء لون صلب](solid-color-fill.png)

## **تحديد الشفافية**

في PowerPoint، عند تطبيق لون صلب أو تدرج أو صورة أو ملء نقش على الأشكال، يمكنك أيضاً تحديد مستوى الشفافية للتحكم في درجة وضوح الملء. كلما ارتفعت قيمة الشفافية، يصبح الشكل أكثر شفافية، مما يسمح للخلية الخلفية أو الكائنات تحتها بأن تكون مرئية جزئياً.

Aspose.Slides يتيح لك تحديد مستوى الشفافية عن طريق تعديل قيمة ألفا في اللون المستخدم للملء. إليك الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color` لتحديد لون مع شفافية (مكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض.

الكود التالي بلغة C++ يوضح كيفية تطبيق لون ملء شفاف على مستطيل:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي مستطيل صلب.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// إضافة شكل تلقائي مستطيل شفاف فوق الشكل الصلب.
auto transparentShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
transparentShape->get_FillFormat()->set_FillType(FillType::Solid);
transparentShape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::FromArgb(204, 255, 255, 0));

// حفظ ملف PPTX على القرص.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

Aspose.Slides يتيح لك تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع أو محاذاة معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية دوران الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

الكود التالي بلغة C++ يوضح كيفية تدوير شكل بـ 5 درجات:
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تدوير الشكل بزاوية 5 درجات.
shape->set_Rotation(5);

// حفظ ملف PPTX على القرص.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات بيفيل ثلاثية الأبعاد**

Aspose.Slides يسمح لك بتطبيق تأثيرات بيفيل ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

لإضافة تأثيرات بيفيل ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) لتحديد إعدادات البيفيل.
1. حفظ العرض.

الكود التالي يوضح كيفية تطبيق تأثيرات بيفيل ثلاثية الأبعاد على شكل:
```cpp
// إنشاء كائن من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Add a shape to the slide.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// Set the shape's ThreeDFormat properties.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// Save the presentation as a PPTX file.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![تأثير بيفيل ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثية الأبعاد**

Aspose.Slides يسمح لك بتطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال عن طريق ضبط خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

لتطبيق تدوير ثلاثي الأبعاد على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة حسب فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. استخدم [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) و[set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) لتحديد تدوير ثلاثي الأبعاد.
1. حفظ العرض.

الكود التالي يوضح كيفية تطبيق تأثيرات تدوير ثلاثية الأبعاد على شكل:
```cpp
// إنشاء كائن من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
shape->get_TextFrame()->set_Text(u"Hello, Aspose!");

shape->get_ThreeDFormat()->set_Depth(6);
shape->get_ThreeDFormat()->get_Camera()->SetRotation(40, 35, 20);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::IsometricLeftUp);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::Balanced);

// حفظ العرض التقديمي كملف PPTX.
presentation->Save(u"3D_rotation_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


النتيجة:

![تأثير التدوير ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة ضبط التنسيق**

الكود التالي بلغة C++ يوضح كيفية إعادة ضبط تنسيق شريحة وإرجاع الموضع والحجم وتنسيق جميع الأشكال ذات العناصر النائبية على [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // إعادة تعيين كل شكل على الشريحة التي لديها عنصر نائب على التخطيط.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

يتأثر بشكل طفيف فقط. الصور والوسائط المضمّنة تشغل معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تُضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال على شريحة ذات تنسيق متطابق لأتمكن من تجميعها؟**

قارن خصائص التنسيق الأساسية لكل شكل—الإعدادات الخاصة بالملء، الخط، والتأثير. إذا تطابقت جميع القيم المقابلة، فاعتبر أن أسلوبها متطابقًا وقم بتجميع تلك الأشكال منطقيًا، مما يُسهّل إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الأشكال المخصّصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات التنسيق المطلوب، وأعد تطبيق تنسيقها حيثما دعت الحاجة.