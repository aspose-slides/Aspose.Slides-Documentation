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
- خط الشكل الرسومي
- تنسيق نمط الوصل
- ملء متدرج
- ملء نمطي
- ملء صورة
- ملء نقش
- ملء لون صلب
- شفافية الشكل
- عرض الشكل بالأبيض والأسود
- عرض الشكل بالرمادي
- تدوير الشكل
- تأثير حافة ثلاثية الأبعاد
- تأثير دوران ثلاثي الأبعاد
- إعادة تعيين التنسيق
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعرّف على كيفية تنسيق أشكال PowerPoint في C++ باستخدام Aspose.Slides—حدد أنماط الملء، الخط، والتأثير لملفات PPT و PPTX و ODP بدقة وتحكم كامل."
---
## **مقدمة**

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. بما أن الأشكال تتكون من خطوط، يمكنك تنسيقها عن طريق تعديل أو تطبيق التأثيرات على حدودها. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد الإعدادات التي تتحكم في طريقة ملئها الداخلي.

![تنسيق الشكل في PowerPoint](format-shape-powerpoint.png)

توفر Aspose.Slides للغة C++ واجهات وطرق تسمح لك بتنسيق الأشكال باستخدام نفس الخيارات المتاحة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط خط مخصص لشكل. الخطوات التالية توضح الإجراء:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [line style](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linestyle/) للشكل.
1. تعيين عرض الخط.
1. تعيين [dash style](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linedashstyle/) للخط.
1. تعيين لون الخط للشكل.
1. حفظ العرض المعدل كملف PPTX.

الكود التالي يوضح كيفية تنسيق مستطيل `AutoShape`:

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

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

// تعيين لون التعبئة لشكل المستطيل.
shape->get_FillFormat()->set_FillType(FillType::NoFill);

// تطبيق التنسيق على خطوط المستطيل.
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

## **تطبيق تأثيرات الرسم التخطيطي على خطوط الشكل**

يُضفي تأثير الرسم التخطيطي مظهرًا يدويًا على خط الشكل. استخدم [IShape::get_LineFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_lineformat/) للوصول إلى إعدادات الخط، و[ILineFormat::get_SketchFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilineformat/get_sketchformat/) للوصول إلى إعدادات التخطيط، و[ISketchFormat::set_SketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isketchformat/set_sketchtype/) لتحديد قيمة من تعداد [LineSketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linesketchtype/).

الكود التالي بلغة C++ يوضح كيفية تطبيق تأثير [LineSketchType::Curved](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linesketchtype/) ، وقراءة القيمة المُعيَّنة صراحةً، وإزالة التأثير باستخدام [LineSketchType::None](https://reference.aspose.com/slides/ar/cpp/aspose.slides/linesketchtype/):

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

القيمة التي تُرجعها الدالة [ISketchFormat::get_SketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isketchformat/get_sketchtype/) تمثل الإعداد المعين مباشرةً للشكل. إذا كان تنسيق الخط يمكن وراثته من موضوع أو شريحة رئيسية أو شريحة تخطيط، استخدم [ILineFormat::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilineformat/geteffective/)، وصول إلى [ILineFormatEffectiveData::get_SketchFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilineformateffectivedata/get_sketchformat/)، وقراءة [ISketchFormatEffectiveData::get_SketchType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/isketchformateffectivedata/get_sketchtype/). القيمة الفعلية تعكس التنسيق الذي يتم تطبيقه فعليًا بعد حل الوراثة:

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

فيما يلي ثلاثة خيارات لأنواع الوصل:

* دوري
* قاطع
* مشطوف

بشكل افتراضي، عندما يقوم PowerPoint بدمج خطين بزاوية (مثلًا عند زاوية الشكل)، يستخدم إعداد **دوري**. ومع ذلك، إذا كنت ترسم شكلًا بزاويات حادة، قد تفضّل خيار **قاطع**.

![نمط الوصل في العرض](join-style-powerpoint.png)

الكود التالي بلغة C++ يوضح كيف تم إنشاء ثلاثة مستطيلات (كما هو موضح في الصورة أعلاه) باستخدام إعدادات نوع الوصل Miter وBevel وRound:

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

## **ملء متدرج**

في PowerPoint، تُعد خاصية الملء المتدرج خيارًا تنسيقيًا يتيح لك تطبيق تدرج مستمر من الألوان على الشكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر بحيث يتلاشى أحدهما تدريجيًا إلى الآخر.

إليك طريقة تطبيق ملء متدرج على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Gradient`.
1. إضافة اللونين المفضّلين لديك مع تحديد المواقع باستخدام طرق `Add` لمجموعة نقاط التدرج التي تُعرض عبر الواجهة [IGradientFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igradientformat/).
1. حفظ العرض المعدل كملف PPTX.

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

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Ellipse.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

// تطبيق تنسيق تدرج لبيضاوي.
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

![الإهليلج بملء متدرج](gradient-fill.png)

## **ملء نمطي**

في PowerPoint، يتيح لك ملء النمط خيار تنسيق يسمح بتطبيق تصميم ذو لونين—مثل النقاط أو الخطوط المتوازية أو التظليل المتقاطع أو المربعات—على الشكل. يمكنك اختيار ألوان مخصصة لخلفية ونص النمط.

توفر Aspose.Slides أكثر من 45 نمطًا مُعرّفًا مسبقًا يمكنك تطبيقها على الأشكال لتعزيز الجاذبية البصرية لعروضك التقديمية. حتى بعد اختيار نمط مُعرّف مسبقًا، لا يزال بإمكانك تحديد الألوان الدقيقة التي سيستخدمها.

لتطبيق ملء نمط على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Pattern`.
1. اختيار نمط نمطي من الخيارات المعرّفة مسبقًا.
1. تعيين [Background Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipatternformat/get_backcolor/) للنمط.
1. تعيين [Foreground Color](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipatternformat/get_forecolor/) للنمط.
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

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل تلقائي من النوع Rectangle.
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// تعيين نوع التعبئة إلى Pattern.
shape->get_FillFormat()->set_FillType(FillType::Pattern);

// تعيين نمط النمط.
shape->get_FillFormat()->get_PatternFormat()->set_PatternStyle(PatternStyle::Trellis);

// تعيين لون الخلفية ولون المقدمة للنمط.
shape->get_FillFormat()->get_PatternFormat()->get_BackColor()->set_Color(Color::get_LightGray());
shape->get_FillFormat()->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_Yellow());

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"pattern_fill.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![المستطيل بملء نمطي](pattern-fill.png)

## **ملء صورة**

في PowerPoint، يُعد ملء الصورة خيارًا تنسيقيًا يتيح لك إدراج صورة داخل الشكل—مستخدمًا الصورة كخلفية للشكل.

إليك طريقة تطبيق ملء صورة على شكل باستخدام Aspose.Slides:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Picture`.
1. تعيين وضع ملء الصورة إلى `Tile` (أو أي وضع مفضَّل آخر).
1. إنشاء كائن [IPPImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ippimage/) من الصورة التي تريد استخدامها.
1. تمرير الصورة إلى طريقة `ISlidesPicture.set_Image`.
1. حفظ العرض المعدل كملف PPTX.

لنفترض أن لدينا ملف "lotus.png" بالصورة التالية:

![صورة اللوتس](lotus.png)

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

// تعيين وضع ملء الصورة.
shape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Tile);

// تحميل صورة وإضافتها إلى موارد العرض.
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

![الشكل بملء صورة](picture-fill.png)

### **بلاط الصورة كنقش**

إذا كنت ترغب في ضبط صورة مبلطة كنقش وتخصيص سلوك البلاط، يمكنك استخدام الطرق التالية من واجهة [IPictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/) والفئة [PictureFillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/picturefillformat/):

- [set_PictureFillMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/): تُحدد وضع ملء الصورة — إما `Tile` أو `Stretch`.
- [set_TileAlignment](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tilealignment/): تحدد محاذاة البلاطات داخل الشكل.
- [set_TileFlip](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tileflip/): تتحكم فيما إذا كان البلاط يُقلب أفقياً أو عمودياً أو كليهما.
- [set_TileOffsetX](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tileoffsetx/): تحدد الإزاحة الأفقية للبلاط (بالنقطة) من أصل الشكل.
- [set_TileOffsetY](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tileoffsety/): تحدد الإزاحة العمودية للبلاط (بالنقطة) من أصل الشكل.
- [set_TileScaleX](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tilescalex/): تعرّف مقياس البلاط الأفقي كنسبة مئوية.
- [set_TileScaleY](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipicturefillformat/set_tilescaley/): تعرّف مقياس البلاط العمودي كنسبة مئوية.

الكود التالي يوضح كيفية إضافة شكل مستطيل بملء صورة مبلّط وتكوين خيارات البلاط:

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

// إضافة شكل تلقائي من نوع المستطيل.
auto shape = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

// تعيين نوع التعبئة للشكل إلى Picture.
shape->get_FillFormat()->set_FillType(FillType::Picture);

// تحميل الصورة وإضافتها إلى موارد العرض.
auto sourceImage = Images::FromFile(u"lotus.png");
auto presentationImage = presentation->get_Images()->AddImage(sourceImage);
sourceImage->Dispose();

// إسناد الصورة إلى الشكل.
auto pictureFillFormat = shape->get_FillFormat()->get_PictureFillFormat();
pictureFillFormat->get_Picture()->set_Image(presentationImage);

// تكوين وضع ملء الصورة وخصائص التجانب.
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

![خيارات البلاط](tile-options.png)

## **ملء بلون صلب**

في PowerPoint، يُعد ملء اللون الصلب خيارًا تنسيقيًا يملأ الشكل بلون موحد واحد. يتم تطبيق هذا اللون الخلفي البسيط دون أي تدرجات أو نقوش أو أنماط.

لتطبيق ملء بلون صلب على شكل باستخدام Aspose.Slides، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) الخاص بالشكل إلى `Solid`.
1. تعيين اللون المفضّل للملء للشكل.
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

## **تعيين الشفافية**

في PowerPoint، عند تطبيق ملء بلون صلب أو تدرج أو صورة أو نقش على الأشكال، يمكنك أيضًا تعيين مستوى الشفافية للتحكم في شفافية الملء. قيمة شفافية أعلى تجعل الشكل أكثر شفافية، مما يسمح لل背景 أو الكائنات التحتية أن تكون مرئية جزئيًا.

تتيح لك Aspose.Slides تعيين مستوى الشفافية عن طريق تعديل قيمة الـ alpha في اللون المستخدم للملء. إليك الطريقة:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/filltype/) إلى `Solid`.
1. استخدام `Color` لتحديد لون مع شفافية (مكوّن `alpha` يتحكم في الشفافية).
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

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// الحصول على الشريحة الأولى.
auto slide = presentation->get_Slide(0);

// إضافة شكل مستطيل صلب تلقائي.
auto solidShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

// إضافة شكل مستطيل شفاف تلقائي فوق الشكل الصلب.
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

تتيح لك Aspose.Slides تدوير الأشكال في عروض PowerPoint. يمكن أن يكون ذلك مفيدًا عند وضع العناصر البصرية مع احتياجات محاذاة أو تصميم معينة.

لتدوير شكل على شريحة، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تعيين خاصية دوران الشكل إلى الزاوية المطلوبة.
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

// تدوير الشكل بمقدار 5 درجات.
shape->set_Rotation(5);

// حفظ ملف PPTX إلى القرص.
presentation->Save(u"shape_rotation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![دوران الشكل](shape-rotation.png)

## **إضافة تأثيرات الحافة ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات حافة ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائصها [ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/threedformat/).

لإضافة تأثيرات حافة ثلاثية الأبعاد إلى شكل، اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. تكوين [ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/threedformat/) الخاص بالشكل لتحديد إعدادات الحافة.
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

// إنشاء كائن من فئة Presentation.
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

// حفظ العرض التقديمي كملف PPTX.
presentation->Save(u"3D_bevel_effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

النتيجة:

![تأثير الحافة ثلاثية الأبعاد](3D-bevel-effect.png)

## **إضافة تأثيرات الدوران ثلاثية الأبعاد**

تسمح لك Aspose.Slides بتطبيق تأثيرات الدوران ثلاثية الأبعاد على الأشكال عن طريق تكوين خصائصها [ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/threedformat/).

لتطبيق دوران ثلاثي الأبعاد على شكل:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/).
1. الحصول على مرجع إلى شريحة بواسطة فهرستها.
1. إضافة [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) إلى الشريحة.
1. استخدام [set_CameraType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icamera/set_cameratype/) و[set_LightType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrig/set_lighttype/) لتحديد دوران ثلاثي الأبعاد.
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

// إنشاء كائن من الفئة Presentation.
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

![تأثير الدوران ثلاثي الأبعاد](3D-rotation-effect.png)

## **التحكم في عرض أبيض-أسود للأشكال**

طريقة [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_blackwhitemode/) تحدد كيفية عرض شكل فردي عندما يُعرض أو يُعالج العرض في وضع أبيض-أسود. لا تُفعّل العرض بالأبيض-الأسود بحد ذاتها، ولا تغير ملء الشكل أو خطه أو تنسيقه الآخر في وضع اللون العادي.

استخدم قيمة من تعداد [BlackWhiteMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/blackwhitemode/) لاختيار السلوك المطلوب. على سبيل المثال، `Automatic` يترك تطبيق العرض يختار التحويل، و`Gray` و`LightGray` يستخدمان اللون الرمادي، و`BlackWhite` يستخدم فقط الأسود والأبيض، و`Black` و`White` يفرضان لونًا واحدًا، و`Color` يحافظ على اللون الطبيعي، و`Hidden` يُخفِي الشكل في وضع أبيض-أسود. `NotDefined` يعني عدم تعيين وضع على مستوى الشكل.

الكود التالي يخلق شكلًا ملونًا ويظهره رماديًا في وضع العرض بالأبيض-أسود:

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

// الحفاظ على التعبئة البرتقالية في وضع الألوان، ولكن عرض الشكل بتلوين رمادي في وضع أبيض-أسود.
shape->set_BlackWhiteMode(BlackWhiteMode::Gray);

presentation->Save(u"shape_black_white_mode.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

في وضع اللون العادي، يحتفظ المستطيل بملء برتقالي. في سير عمل عرض أبيض-أسود، يستخدم اللون الرمادي لأن وضعه تم تعيينه إلى `Gray`. يتيح لك ذلك الحفاظ على شريحة ملونة بالكامل مع تحديد مظهر مميز للطباعة أو المعاينة أو غيرها من سير العمل التي تحترم إعدادات العرض بالأبيض-أسود.

## **إعادة تعيين التنسيق**

الكود التالي بلغة C++ يوضح كيفية إعادة تعيين تنسيق شريحة وإرجاع موقع وحجم وتنسيق جميع الأشكال ذات العنصر النائب على [LayoutSlide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/layoutslide/) إلى إعداداتها الافتراضية:

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
    // إعادة ضبط كل شكل على الشريحة التي تحتوي على عنصر نائب في التخطيط.
    slide->Reset();
}

presentation->Save(u"reset_formatting.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الأسئلة الشائعة**

**هل يؤثر تنسيق الشكل على حجم ملف العرض النهائي؟**

بشكل طفيف فقط. الصور والوسائط المضمنة تشغل معظم مساحة الملف، بينما معلمات الشكل مثل الألوان والتأثيرات والتدرجات تُخزن كبيانات وصفية وتضيف تقريبًا لا شيء إلى الحجم.

**كيف يمكنني اكتشاف الأشكال في شريحة التي تشترك في تنسيق متطابق حتى أتمكن من تجميعها؟**

قارن خصائص التنسيق الرئيسية لكل شكل — إعدادات الملء، الخط، والتأثيرات. إذا تطابقت جميع القيم المقابلة، اعتبر أن أنماطها متطابقة وقم بتجميع تلك الأشكال منطقياً، مما يبسط إدارة الأنماط لاحقًا.

**هل يمكنني حفظ مجموعة من أنماط الشكل المخصصة في ملف منفصل لإعادة استخدامها في عروض أخرى؟**

نعم. احفظ الأشكال النموذجية ذات الأنماط المطلوبة في شريحة قالب أو ملف .POTX. عند إنشاء عرض جديد، افتح القالب، استنسخ الأشكال ذات الأنماط التي تحتاجها، وأعد تطبيق تنسيقها حسب الحاجة.