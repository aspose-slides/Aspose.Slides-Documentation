---
title: تنسيق أشكال PowerPoint في C++
linktitle: تنسيق الشكل
type: docs
weight: 20
url: /ar/cpp/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخط
- تأثير الرسم التخطيطي
- خط الشكل التخطيطي
- تنسيق نمط الوصل
- تعبئة تدرجية
- تعبئة بنمط
- تعبئة صورة
- تعبئة نسيج
- تعبئة لون صلب
- شفافية الشكل
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تنسيق أشكال PowerPoint في C++ باستخدام Aspose.Slides—حدد أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. نظرًا لأن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في كيفية ملء داخلها.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides لـ C++ واجهات وطرق تتيح لك تنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الشفرة التالية توضح كيفية تنسيق `AutoShape` مستطيل:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من نوع المستطيل.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// تحديد لون التعبئة لشكل المستطيل.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// تطبيق تنسيق على خطوط المستطيل.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// تحديد لون خط المستطيل.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// حفظ ملف PPTX على القرص.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الناتج:

![الخطوط المنسقة في العرض التقديمي](formatted-lines.png)

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضفي تأثير الرسم التخطيطي مظهرًا يدويًا على خط الشكل. استخدم [IShape::get_LineFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_lineformat/) للوصول إلى إعدادات الخط، و[ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilineformat/get_sketchformat/) للوصول إلى إعدادات الرسم التخطيطي، و[ISketchFormat::set_SketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isketchformat/set_sketchtype/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linesketchtype/) .

الشفرة التالية في C++ توضح كيفية تطبيق تأثير [LineSketchType::Curved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linesketchtype/) ، قراءة القيمة المعينة صراحةً، وإزالة التأثير باستخدام [LineSketchType::None](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linesketchtype/) :

```cpp
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
auto sketchFormat = shape->get_LineFormat()->get_SketchFormat();

// Apply a sketch effect.
sketchFormat->set_SketchType(LineSketchType::Curved);

// Read the sketch effect assigned directly to the shape.
auto explicitSketchType = sketchFormat->get_SketchType();
Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);

// Remove the sketch effect.
sketchFormat->set_SketchType(LineSketchType::None);

presentation->Dispose();
```

القيمة التي يرجعها [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isketchformat/get_sketchtype/) تمثل الإعداد المعيّن مباشرةً على الشكل. إذا كان يمكن أن يُورَّث تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilineformat/geteffective/)، وادخل إلى [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/)، واقرأ [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). القيمة الفعّالة تعكس التنسيق المطبق فعليًا بعد حل الورث:

```cpp
auto presentation = MakeObject<Presentation>(u"presentation.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto lineFormat = shape->get_LineFormat();

auto explicitSketchType = lineFormat->get_SketchFormat()->get_SketchType();
auto effectiveLineFormat = lineFormat->GetEffective();
auto effectiveSketchType = effectiveLineFormat->get_SketchFormat()->get_SketchType();

Console::WriteLine(u"Explicit sketch type: {0}", explicitSketchType);
Console::WriteLine(u"Effective sketch type: {0}", effectiveSketchType);

presentation->Dispose();
```

## **تنسيق أنماط الوصلات**

إليك خيارات أنواع الوصلات الثلاثة:

* Round
* Miter
* Bevel

بشكل افتراضي، عندما يقوم PowerPoint بدمج خطين بزاوية (مثل زاوية شكل)، يستخدم الإعداد **Round**. ومع ذلك، إذا كنت ترسم شكلاً بزاوٍ حادة، قد تفضّل خيار **Miter**.

![نمط الوصلة في العرض التقديمي](join-style-powerpoint.png)

الشفرة التالية في C++ توضح كيفية إنشاء ثلاثة مستطيلات (كما في الصورة أعلاه) باستخدام إعدادات نوع الوصلات Miter و Bevel و Round:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة ثلاثة أشكال تلقائية من نوع المستطيل.
auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

// تحديد لون التعبئة لكل شكل مستطيل.
shape1->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape2->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
shape3->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// تحديد عرض الخط.
shape1->get_LineFormat()->set_Width(15);
shape2->get_LineFormat()->set_Width(15);
shape3->get_LineFormat()->set_Width(15);

// تحديد لون خط كل مستطيل.
shape1->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape1->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
shape3->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape3->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// تحديد نمط الوصلة.
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

## **تعبئة تدرجية**

في PowerPoint، تعبئة التدرج هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك طريقة تطبيق تعبئة تدرجية على شكل باستخدام Aspose.Slides:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) للشكل إلى `Gradient`.
1. إضافة اللونين المفضلين مع تحديد المواقع باستخدام طُرُق `Add` لمجموعة نقاط التدرج التي يوفّرها الواجهة [IGradientFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igradientformat/) .
1. حفظ العرض التقديمي المعدل كملف PPTX.

الشفرة التالية في C++ توضح كيفية تطبيق تأثير تعبئة تدرجية على شكل بيضوي:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من نوع Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// تطبيق تنسيق التدرج على الشكل البيضاوي.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// تحديد اتجاه التدرج.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// إضافة نقطتي تدرج.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// حفظ ملف PPTX على القرص.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الناتج:

![البيضوي بتعبئة تدرجية](gradient-fill.png)

## **تعبئة بنمط**

في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على شكل. يمكنك اختيار ألوان مخصصة للمظهر الأمامي والخلفي للنمط.

توفر Aspose.Slides أكثر من 45 نمطًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز جاذبيتها البصرية. حتى بعد اختيار نمط مسبق، يمكنك تحديد الألوان الدقيقة التي سيستخدمها.

إليك طريقة تطبيق تعبئة بنمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) للشكل إلى `Pattern`.
1. اختيار نمط نمط من الخيارات المسبقة.
1. تعيين [Background Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipatternformat/get_backcolor/) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipatternformat/get_forecolor/) للنمط.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الشفرة التالية في C++ توضح كيفية تطبيق تعبئة بنمط على مستطيل:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من نوع المستطيل.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تعيين نوع التعبئة إلى Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// تعيين نمط النمط.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تعيين ألوان الخلفية والواجهة للنمط.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// حفظ ملف PPTX على القرص.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الناتج:

![المستطيل بنمط تعبئة](pattern-fill.png)

## **تعبئة صورة**

في PowerPoint، تعبئة الصورة هي خيار تنسيق يتيح لك إدراج صورة داخل شكل—وبذلك تُستخدم الصورة كخلفية للشكل.

إليك طريقة استخدام Aspose.Slides لتطبيق تعبئة صورة على شكل:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) للشكل إلى `Picture`.
1. تعيين وضع تعبئة الصورة إلى `Tile` (أو وضع آخر مفضّل).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.set_Image` .
1. حفظ العرض التقديمي المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

الشفرة التالية في C++ توضح كيفية تعبئة شكل بالصورة:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من نوع المستطيل.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

// تعيين نوع التعبئة إلى Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// تعيين وضع تعبئة الصورة.
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

الناتج:

![الشكل بتعبئة صورة](picture-fill.png)

### **استخدام الصورة المتكررة كملمس**

إذا أردت تعيين صورة مكررة كملمس وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من الواجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): يحدد وضع تعبئة الصورة—إما `Tile` أو `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): يحدد محاذاة البُرق داخل الشكل.
- [set_TileFlip](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tileflip/): يتحكم فيما إذا كان البُرق يُقلب أفقيًا أو عموديًا أو كلاهما.
- [set_TileOffsetX](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): يحدد الإزاحة الأفقية للبُرق (بنقطة) من أصل الشكل.
- [set_TileOffsetY](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): يحدد الإزاحة العمودية للبُرق (بنقطة) من أصل الشكل.
- [set_TileScaleX](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): يعرّف مقياس البُرق الأفقي كنسبة مئوية.
- [set_TileScaleY](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): يعرّف مقياس البُرق العمودي كنسبة مئوية.

الشفرة التالية توضح كيفية إضافة شكل مستطيل بتعبئة صورة متكررة وتكوين خيارات البُرق:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto firstSlide = presentation->get_Slide(0);

// إضافة شكل تلقائي من نوع المستطيل.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// تعيين نوع التعبئة للشكل إلى Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// تحميل الصورة وإضافتها إلى موارد العرض التقديمي.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// تعيين الصورة إلى الشكل.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// تكوين وضع تعبئة الصورة وخصائص التكرار.
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

الناتج:

![خيارات البُرق](tile-options.png)

## **تعبئة بلون صلب**

في PowerPoint، تعبئة اللون الصلب هي خيار تنسيق يملأ الشكل بلون موحد واحد. يطبق هذا اللون الخلفي البسيط دون أي تدرجات أو قوام أو أنماط.

لتطبيق تعبئة بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) للشكل إلى `Solid`.
1. تعيين اللون الصلب المفضل للشكل.
1. حفظ العرض التقديمي المعدل كملف PPTX.

الشفرة التالية في C++ توضح كيفية تطبيق تعبئة بلون صلب على مستطيل في شريحة PowerPoint:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من نوع المستطيل.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تعيين نوع التعبئة إلى Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// تعيين لون التعبئة.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// حفظ ملف PPTX على القرص.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الناتج:

![الشكل بتعبئة لون صلب](solid-color-fill.png)

## **تعيين الشفافية**

في PowerPoint، عند تطبيق لون صلب أو تدرج أو صورة أو تعبئة قوام على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في عدم وضوح التعبئة. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات الأسفل جزئيًا.

تسمح لك Aspose.Slides بتعيين مستوى الشفافية عن طريق ضبط قيمة ألفا في اللون المستخدم للتعبئة. إليك الطريقة:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتحديد لون مع شفافية (المكوّن `alpha` يتحكم في الشفافية).
1. حفظ العرض التقديمي.

الشفرة التالية في C++ توضح كيفية تطبيق لون تعبئة شفاف على مستطيل:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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

الناتج:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بموضع أو تصميم معين.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية دوران الشكل إلى الزاوية المطلوبة.
1. حفظ العرض التقديمي.

الشفرة التالية في C++ توضح كيفية تدوير شكل بزاوية 5 درجات:

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من نوع المستطيل.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تدوير الشكل بزاوية 5 درجات.
shape->set_Rotation(5);

// حفظ ملف PPTX على القرص.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الناتج:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات أسنان ثلاثية الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات أسنان ثلاثية الأبعاد على الأشكال عبر تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/threedformat/) الخاصة بها.

لإضافة تأثيرات أسنان ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/threedformat/) للشكل لتحديد إعدادات الأسنان.
1. حفظ العرض التقديمي.

الشفرة التالية في C++ توضح كيفية تطبيق تأثيرات أسنان ثلاثية الأبعاد على شكل:

```cpp
// إنشاء مثال من الفئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// إضافة شكل إلى الشريحة.
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

الناتج:

![تأثير الأسنان ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات دوران ثلاثي الأبعاد**

يتيح لك Aspose.Slides تطبيق تأثيرات دوران ثلاثية الأبعاد على الأشكال عبر تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/threedformat/) الخاصة بها.

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. استخدام [set_CameraType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icamera/set_cameratype/) و[set_LightType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrig/set_lighttype/) لتحديد دوران ثلاثي الأبعاد.
1. حفظ العرض التقديمي.

الشفرة التالية في C++ توضح كيفية تطبيق تأثيرات دوران ثلاثية الأبعاد على شكل:

```cpp
// إنشاء مثال من الفئة Presentation.
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

الناتج:

![تأثير دوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **إعادة تعيين التنسيق**

الشفرة التالية في C++ توضح كيفية إعادة تعيين تنسيق شريحة وإعادة موضع وحجم وتنسيق جميع الأشكال ذات العناصر النائبة على [LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **التعليمات المتكررة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

قليلًا فقط. الصور والوسائط المدمجة تشغل معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف حجمًا كبيرًا.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في نفس التنسيق حتى أتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل—الإعدادات الخاصة بالملء، الخط، والتأثيرات. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقياً، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المنسقة التي تحتاجها، وأعد تطبيق تنسيقها حسب الحاجة.