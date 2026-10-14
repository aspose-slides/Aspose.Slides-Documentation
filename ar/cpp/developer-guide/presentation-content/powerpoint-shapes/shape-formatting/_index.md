---
title: "تنسيق أشكال PowerPoint في C++"
linktitle: "تنسيق الشكل"
type: docs
weight: 20
url: /ar/cpp/shape-formatting/
keywords:
- "تنسيق الشكل"
- "تنسيق الخط"
- "تأثير التخطيط"
- "خط الشكل المخطط"
- "تنسيق نمط الوصل"
- "ملء التدرج اللوني"
- "ملء النمط"
- "ملء الصورة"
- "ملء الملمس"
- "ملء اللون الصلب"
- "شفافية الشكل"
- "عرض الشكل بالأبيض والأسود"
- "عرض الشكل بدرجة الرمادي"
- "تدوير الشكل"
- "تأثير الحافة ثلاثية الأبعاد"
- "تأثير التدوير ثلاثي الأبعاد"
- "إعادة تعيين التنسيق"
- "PowerPoint"
- "العرض التقديمي"
- "C++"
- "Aspose.Slides"
description: "تعرف على كيفية تنسيق أشكال PowerPoint في C++ باستخدام Aspose.Slides—ضبط أنماط التعبئة والخط والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **المقدمة**

في PowerPoint، يمكنك إضافة الأشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق تأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد إعدادات تتحكم في كيفية تعبئة داخلها.

![تنسيق-شكل-PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides للـ C++ واجهات وطرق تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. توضح الخطوات التالية الإجراء:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/cpp/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/cpp/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تنسيق `AutoShape` على شكل مستطيل:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LineDashStyle.h>
#include <DOM/LineStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// تعيين لون التعبئة لشكل المستطيل.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// تطبيق تنسيق على خطوط المستطيل.
shape->get_LineFormat()->set_Style(LineStyle::ThickThin);
shape->get_LineFormat()->set_Width(7);
shape->get_LineFormat()->set_DashStyle(LineDashStyle::Dash);

// تعيين اللون لخط المستطيل.
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"formatted_lines.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الخطوط المنسقة في العرض](formatted-lines.png)

## **تطبيق تأثيرات الرسم على خطوط الشكل**

يُضفي تأثير الرسم مظهر الخط وكأنه مرسوم يدوياً. استخدم [IShape::get_LineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_lineformat/) للوصول إلى إعدادات الخط، [ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_sketchformat/) للوصول إلى إعدادات الرسم، و[ISketchFormat::set_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/set_sketchtype/) لاختيار قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/).

الكود التالي بلغة C++ يوضح كيفية تطبيق تأثير [LineSketchType::Curved](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/) ، قراءة القيمة المحددة صراحةً، وإزالة التأثير باستخدام [LineSketchType::None](https://reference.aspose.com/slides/cpp/aspose.slides/linesketchtype/):

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

القيمة التي تُرجعها الدالة [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformat/get_sketchtype/) تمثل الإعداد المعين مباشرةً للشكل. إذا كان يمكن وراثة تنسيق الخط من سمة أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat::GetEffective](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/geteffective/)، وصول إلى [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/)، وقراءة [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). القيمة الفعّالة تعكس التنسيق الذي يتم تطبيقه فعلياً بعد حل الوراثة:

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

## **تنسيق أنماط الوصل**

فيما يلي خيارات ثلاثة لأنواع الوصل:

* مستدير
* حاد
* مقعر

بشكل افتراضي، عندما يقوم PowerPoint بضم خطين بزاوية (مثل زاوية شكل)، يستخدم إعداد **مستدير**. ومع ذلك، إذا كنت ترسم شكلاً بزوايا حادة، قد تفضل خيار **حاد**.

![نمط الوصل في العرض](join-style-powerpoint.png)

الكود التالي بلغة C++ يوضح كيفية إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصل Miter وBevel وRound:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LineJoinStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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

// تعيين اللون لخط كل مستطيل.
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

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"join_styles.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ملء تدرج اللون**

في PowerPoint، يُعد ملء التدرج خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بطريقة يتلاشى أحدهما تدريجياً إلى الآخر.

إليك طريقة تطبيق ملء تدرج على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Gradient`.
1. إضافة اللونين المفضلين لديك مع تحديد المواضع باستخدام طرق `Add` لمجموعة نقاط التدرج التي يقدمها واجهة [IGradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/igradientformat/) .
1. حفظ العرض المعدل كملف PPTX.

الكود التالي بلغة C++ يوضح كيفية تطبيق تأثير ملء تدرج على إهليلج:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientDirection.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/PresetColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// تطبيق تنسيق التدرج على الشكل الإهليلجي.
shape->get_FillFormat()->set_FillType(FillType::Gradient);
shape->get_FillFormat()->get_GradientFormat()->set_GradientShape(GradientShape::Linear);

// تعيين اتجاه التدرج.
shape->get_FillFormat()->get_GradientFormat()->set_GradientDirection(GradientDirection::FromCorner2);

// إضافة نقطتي تدرج.
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(1.0f, PresetColor::Purple);
shape->get_FillFormat()->get_GradientFormat()->get_GradientStops()->Add(0.0f, PresetColor::Red);

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"gradient_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الإهليلج بملء التدرج](gradient-fill.png)

إذا كان التدرج يظهَر بشكل مختلف في صورة مُصدَّرة مقارنةً بما هو عليه في PowerPoint، راجع [Choose a Gradient Rendering Style](/slides/ar/cpp/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). يمكنك اختيار نمط العرض دون تغيير ملء التدرج المخزن في العرض.

## **ملء النمط**

في PowerPoint، يُعد ملء النمط خيار تنسيق يتيح لك تطبيق تصميم ثنائي اللون—مثل النقاط أو الخطوط أو التعرجات المتقاطعة أو المربعات—على الشكل. يمكنك اختيار ألوان مخصصة للواجهة الخلفية والواجهة الأمامية للنمط.

توفر Aspose.Slides أكثر من 45 نمط نمط مُعرَّف مسبقاً يمكنك تطبيقه على الأشكال لتحسين المظهر البصري للعروض التقديمية. حتى بعد اختيار نمط مُعرَّف مسبقاً، يمكنك تحديد الألوان الدقيقة التي يجب استخدامها.

إليك طريقة تطبيق ملء النمط على شكل باستخدام Aspose.Slides:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Pattern`.
1. اختر نمط النمط من الخيارات المُعرَّفة مسبقاً.
1. عيّن [Background Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_backcolor/) للنمط.
1. عيّن [Foreground Color](https://reference.aspose.com/slides/cpp/aspose.slides/ipatternformat/get_forecolor/) للنمط.
1. حفظ العرض المعدل كملف PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPatternFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تعيين نوع التعبئة إلى Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// تعيين نمط النقش.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تعيين ألوان الخلفية والواجهة الأمامية للنقش.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![المستطيل بملء النمط](pattern-fill.png)

## **ملء الصورة**

في PowerPoint، يُعد ملء الصورة خيار تنسيق يسمح لك بإدراج صورة داخل الشكل—بالتالي تستخدم الصورة كخلفية للشكل.

إليك طريقة استخدام Aspose.Slides لتطبيق ملء صورة على شكل:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Picture`.
1. تعيين وضع ملء الصورة إلى `Tile` (أو أي وضع مفضل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.set_Image`.
1. حفظ العرض المعدل كملف PPTX.

![صورة اللوتس](lotus.png)

الكود التالي بلغة C++ يوضح كيفية تعبئة شكل بالصورة:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
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

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"picture_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الشكل بملء الصورة](picture-fill.png)

### **استخدام صورة مكررة كملمس**

إذا كنت تريد تعيين صورة مكررة كملس وتخصيص سلوك التكرار، يمكنك استخدام الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/) والصف [PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) :

- [set_PictureFillMode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): يحدد وضع ملء الصورة — إما `Tile` أو `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): يحدد محاذاة البلاط داخل الشكل.
- [set_TileFlip](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileflip/): يتحكم في ما إذا كان البلاط يُقَلَّب أفقيًا أو عموديًا أو كليهما.
- [set_TileOffsetX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): يحدد الإزاحة الأفقية للبلاط (بنقاط) من أصل الشكل.
- [set_TileOffsetY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): يحدد الإزاحة العمودية للبلاط (بنقاط) من أصل الشكل.
- [set_TileScaleX](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): يعّرف مقياس البلاط الأفقي كنسبة مئوية.
- [set_TileScaleY](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): يعّرف مقياس البلاط العمودي كنسبة مئوية.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <DOM/TileFlip.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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

// تعيين الصورة إلى الشكل.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// تهيئة وضع تعبئة الصورة وخصائص التبليط.
pictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
pictureFillFormat->set_TileOffsetX(-32);
pictureFillFormat->set_TileOffsetY(-32);
pictureFillFormat->set_TileScaleX(50);
pictureFillFormat->set_TileScaleY(50);
pictureFillFormat->set_TileAlignment(RectangleAlignment::BottomRight);
pictureFillFormat->set_TileFlip(TileFlip::FlipBoth);

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"tile.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![خيارات التكرار](tile-options.png)

## **ملء بلون صلب**

في PowerPoint، يُعد ملء اللون الصلب خيارًا تنسيقيًا يملأ الشكل بلون موحد واحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو ملمس أو نمط.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Solid`.
1. تعيين اللون المملوء المفضل للشكل.
1. حفظ العرض المعدل كملف PPTX.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تعيين نوع التعبئة إلى Solid.
shape->get_FillFormat()->set_FillType(FillType::Solid);

// تعيين لون التعبئة.
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"solid_color_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الشكل بملء لون صلب](solid-color-fill.png)

## **ضبط الشفافية**

في PowerPoint، عند تطبيق ملء بلون صلب أو تدرج أو صورة أو ملمس على الأشكال، يمكنك أيضًا ضبط مستوى الشفافية للتحكم في شفافية الملء. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح برؤية الخلفية أو الكائنات السفلية جزئياً.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) إلى `Solid`.
1. استخدم `Color` لتحديد لون مع شفافية (مكون `alpha` يتحكم في الشفافية).
1. حفظ العرض.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

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

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"shape_transparency.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![الشكل الشفاف](shape-transparency.png)

## **تدوير الأشكال**

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية بمواضع محددة أو لتلبية احتياجات التصميم.

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية تدوير الشكل إلى الزاوية المطلوبة.
1. حفظ العرض.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تدوير الشكل بزاوية 5 درجات.
shape->set_Rotation(5);

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تدوير الشكل](shape-rotation.png)

## **إضافة تأثيرات الحواف ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات الحواف ثلاثية الأبعاد على الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/) لتحديد إعدادات الحافة.
1. حفظ العرض.

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

// إنشاء مثيل من فئة Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// إضافة شكل إلى الشريحة.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Green());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->set_Width(2.0);

// تعيين خصائص ThreeDFormat للشكل.
shape->get_ThreeDFormat()->set_Depth(4.0);
shape->get_ThreeDFormat()->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
shape->get_ThreeDFormat()->get_BevelTop()->set_Height(6);
shape->get_ThreeDFormat()->get_BevelTop()->set_Width(6);
shape->get_ThreeDFormat()->get_Camera()->set_CameraType(CameraPresetType::OrthographicFront);
shape->get_ThreeDFormat()->get_LightRig()->set_LightType(LightRigPresetType::ThreePt);
shape->get_ThreeDFormat()->get_LightRig()->set_Direction(LightingDirection::Top);

// حفظ العرض التقديمي كملف PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تأثير الحافة ثلاثي الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات تدوير ثلاثية الأبعاد**

تتيح لك Aspose.Slides تطبيق تأثيرات تدوير ثلاثية الأبعاد على الأشكال من خلال تكوين خصائص [ThreeDFormat](https://reference.aspose.com/slides/cpp/aspose.slides/threedformat/).

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة حسب الفهرس الخاص بها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. استخدم [set_CameraType](https://reference.aspose.com/slides/cpp/aspose.slides/icamera/set_cameratype/) و[set_LightType](https://reference.aspose.com/slides/cpp/aspose.slides/ilightrig/set_lighttype/) لتحديد التدوير ثلاثي الأبعاد.
1. حفظ العرض.

```cpp
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء مثيل من فئة Presentation.
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

## **التحكم في العرض بالأبيض والأسود للأشكال**

طريقة [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_blackwhitemode/) تحدد كيفية عرض شكل منفرد عندما يتم عرض أو معالجة العرض بالأبيض والأسود. لا تقوم هذه الطريقة بتمكين العرض بالأبيض والأسود بحد ذاته، ولا تغير ملء الشكل أو خطه أو تنسيقه في وضع الألوان العادية.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/cpp/aspose.slides/blackwhitemode/) لتحديد السلوك المطلوب. على سبيل المثال، `Automatic` يترك التطبيق يختار التحويل، `Gray` و `LightGray` يستخدمان اللون الرمادي، `BlackWhite` يستخدم الأسود والأبيض فقط، `Black` و `White` يجبران على لون واحد، `Color` يحافظ على الألوان الطبيعية، و `Hidden` يخفي الشكل في وضع الأبيض والأسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

الكود التالي بلغة C++ ينشئ شكلاً ملونًا ويجعله يظهر باللون الرمادي في وضع العرض بالأبيض والأسود:

```cpp
#include <DOM/BlackWhiteMode.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

// احتفظ بملء البرتقالي في وضع اللون، ولكن اعرض الشكل بتلوين رمادي في وضع الأسود والأبيض.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

في وضع الألوان العادية، يحتفظ المستطيل بملئه البرتقالي. في سير عمل العرض بالأبيض والأسود، يستخدم اللون الرمادي لأن وضعه مضبوط على `Gray`. يتيح لك هذا الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو أي سير عمل يراعي إعدادات العرض بالأبيض والأسود.

## **إعادة تعيين التنسيق**

الكود التالي بلغة C++ يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع الموقع والحجم وتنسيق جميع الأشكال ذات المواضع النائبة على [LayoutSlide](https://reference.aspose.com/slides/cpp/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    // إعادة تعيين كل شكل على الشريحة الذي يحتوي على عنصر نائب في التخطيط.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة المتكررة**

**هل يؤثر تنسيق الشكل على حجم الملف النهائي للعرض التقديمي؟**

فقط بشكل طفيف. تحتل الصور والوسائط المضمّنة معظم مساحة الملف، بينما تُخزن معلمات الشكل مثل الألوان والتأثيرات والتدرجات كبيانات وصفية ولا تضيف أي حجم إضافي تقريبًا.

**كيف يمكنني اكتشاف الأشكال على شريحة التي تشترك في تنسيق متماثل حتى أتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — إعدادات التعبئة، الخط، والتأثيرات. إذا كانت جميع القيم المطابقة متساوية، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقيًا، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة إلى ملف منفصل لإعادة استخدامها في عروض تقديمية أخرى؟**

نعم. احفظ أشكالًا نموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف قالب .POTX. عند إنشاء عرض تقديمي جديد، افتح القالب، استنسخ الأشكال المصممة التي تحتاجها، وأعد تطبيق تنسيقها حيثما دُعيت.