---
title: إدارة أشكال العرض التقديمي في C++
linktitle: معالجة الأشكال
type: docs
weight: 40
url: /ar/cpp/shape-manipulations/
keywords:
- شكل PowerPoint
- شكل العرض التقديمي
- شكل على الشريحة
- البحث عن شكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل للـ interop
- النص البديل للشكل
- تنسيقات تخطيط الشكل
- الشكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- قلب الشكل
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية التعرف على أشكال العرض التقديمي، استنساخها، إزالتها، إخفائها، إعادة ترتيبها، تصديرها، محاذاةها، وقلبها باستخدام Aspose.Slides لـ C++."
---
## **نظرة عامة**

تمثل Aspose.Slides للـ C++ الأشكال على الشريحة كمجموعة مرتبة من النوع [IShapeCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/). تُعد المجموعة هي المكان الذي تجد فيه وتُعدل الأشكال ومصدر ترتيب تراكبها: الفهرس `0` هو الشكل الخلفي، بينما الفهرس الأخير هو الشكل الأمامي.

يتبع هذا المقال ذلك النموذج. يشرح أولاً كيفية التعرف على الشكل بشكل موثوق، ثم يُظهر كيفية نسخ الشكل، إزالته، إخفائه، وإعادة ترتيبه. تغطي الأقسام النهائية تنسيق مستوى التخطيط، تصدير SVG، المحاذاة، وإعدادات القلب. كل مثال مستقل، لذا يمكنك استخدام العمليات التي تحتاجها فقط في سير عملك.

## **تحديد وإيجاد الأشكال**

مؤشرات المجموعة مريحة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. إضافة، إزالة أو إعادة ترتيب شكل يمكن أن تغير فهرسه. اختر معرفًا وفقًا لكيفية إنشاء العرض التقديمي وصيانته:

- [Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_name/) مفيد للقوالب التي يتحكم فيها المطور ويسهل فحصه في لوحة التحديد في PowerPoint. يمكن تعديل الأسماء ولا تضمن كونها فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_alternativetext/) مفيد عندما يكون وصف الوصول أو العلامة التي أضافها المؤلف قد حددت الشكل بالفعل. هو مرئي للمستخدمين، قد يُترجم أو يُعيد صياغته لتلبية متطلبات الوصول، ولا يضمن كونه فريدًا. لا تُعيد استعمال نص وصول ذو معنى كمفتاح قاعدة بيانات بشكل صامت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_officeinteropshapeid/) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل الذي يستخدمه PowerPoint interop. استخدمه عند الدمج مع PowerPoint أو عندما تحتاج إلى إشارة لا لبس فيها طوال عمر الشكل. الشكل المستنسخ أو المعاد إنشاؤه يُعامل كشكل مختلف ويحصل على معرف خاص به.

الخاصية المرتبطة [UniqueId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_uniqueid/) لها نطاق العرض التقديمي، لكنها مخصصة للإضافات ويمكن إعادة تعيينها. لا ينبغي الاعتبار بها كمفتاح خارجي دائم. إذا كان تعريف الشكل على المدى الطويل ضروريًا، احتفظ بعملية الربط في بيانات التطبيق وتحقق من أن الشكل المتوقع لا يزال موجودًا.

المثال التالي يبحث عن الشكل باستخدام `Name` ويُبلغ عن معرف الـ interop على مستوى الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن تلك النتيجة بدلاً من المتابعة مع الكائن الخطأ.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

عند أن تكون العملية خاصة بنوع معين من الأشكال، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يُحدّث النص والنص البديل فقط إذا كان الكائن المُسمّى من النوع [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **تعديل مجموعة الأشكال**

طريقة الإضافة، الاستنساخ، الإزالة وإعادة الترتيب تعمل على المجموعة مباشرة. إذا غيّرت عملية ما عدد أو ترتيب الأشكال، لا تواصل الاعتماد على المؤشرات التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addclone/) يُنشئ نسخة مستقلة ويُلحقها بالمجموعة الهدف. [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/insertclone/) ينشئ نسخة أيضًا ولكنه يضعها عند فهرس z‑order محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تتضمن العرض والارتفاع يمكنها تغيير الحجم كذلك.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا موسومًا إلى المقدمة، ويُدخل نسخة ثانية في الخلف. التغييرات على أي نسخة لا تُعدل الشكل الأصلي.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نسخ الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون هذه القيم فريدة. الموارد المستخدمة من قبل الأشكال المعقّدة تُدار بواسطة العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة له هوية شكل جديدة.

### **إزالة الأشكال**

[Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة عدة تطابقات أثناء تكرار بالفهرس، تجول من النهاية بحيث يظل كل فهرس متبقٍ صالحًا.

هذا المثال يزيل كل شكل له اسم محدد. يقرأ الشكل المفهرس الحالي، وليس عنصر مجموعة ثابت، ولا يُحول الشكل دون حاجة.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

بعد الإزالة، يتغير عدد الأشكال وفهارس الأشكال اللاحقة. المراجع إلى الأشكال غير المتأثرة تبقى أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل مرئي قد تغير أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_hidden/) إلى `true` يبقي الشكل في المجموعة لكنه يمنع ظهوره في عرض الشرائح العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا فإن الإخفاء ملائم للعناصر الاختيارية التي قد تُستعاد لاحقًا.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهاره مرة أخرى، وهو يبقى جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتراكبة تُرسم بترتيب المجموعة. [Reorder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/reorder/) يحرك شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `Count - 1` هو الأمام.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

يتم إنشاء المستطيل أولاً ويقع في البداية خلف الشكل البيضاوي. نقله إلى الفهرس الأخير يجعله في المقدمة. اكمل ترتيب z‑order بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدخل عناصر مجموعة جديدة وقد تغير المكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، وشرائح التخطيط، والشرائح الرئيسة لها مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس نفس الكائن الموجود على شريحة عادية في نفس الموضع. فحص أشكال التخطيط ضروري عندما تحتاج إلى فهم أو تعديل التنسيق المزوّد من قبل التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_fillformat/) و[LineFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_lineformat/) لشكل التخطيط دون افتراض أن كل شكل هو `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

تحرير التخطيط قد يؤثر على عدة شرائح تستخدمه. قبل تعديل شكل تخطيط، حدّد ما إذا كانت الشريحة العادية ترث الكائن أو تحتوي على تجاوز محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/writeassvg/) يكتب محتوى شكل واحد مُرَسَّم إلى تدفق. النتيجة تحتوي على الشكل فقط، ليس خلفية الشريحة بالكامل أو الأشكال المجاورة.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت بحاجة إلى التكوين الكامل، صدّر الشريحة بدلاً من شكل فردي. المتصل يملك التدفق ويجب أن يغلقه أو يتخلص منه.

## **محاذاة الأشكال**

طريقة [SlideUtil::AlignShapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/alignshapes/) لديها تحميلات تُحاذى إما جميع الأشكال أو الفهارس المحددة في المجموعة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapesalignmenttype/) يحدد الحافة، أو الخط المركزي، أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ واضبطها إلى `false` لمحاذاة الأشكال المختارة بالنسبة إلى بعضها البعض.

هذا المثال يُحاذى ثلاثة أشكال إلى الحافة العلوية للشريحة. مراجع الأشكال المعادة تُحوَّل إلى فهارسها الحالية مباشرة قبل المحاذاة.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

المحاذاة تغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادةً تحتاج على الأقل إلى شكلين، بينما التوزيع الأفقي أو العمودي يحتاج إلى عدد كافٍ من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **قلب شكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapeframe/) تخزن الموقع، الحجم، إعدادات القلب الأفقية والرأسية، والدوران. قيمتي `FlipH` و`FlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/cpp/aspose.slides/nullablebool/): `True` يُفعّل القلب، `False` يُعطّله، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غير مقلوب.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحافظ على جميع قيم الإطار الأخرى ويستبدل فقط إعدادات القلب الثنائية. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_frame/) جديد يستبدل الإطار بالكامل.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الشكل المحفوظ مقلوب أفقيًا وعموديًا مع الحفاظ على موقعه وحجمه ودورانه.

![The shape after flipping](flipped_shape.png)

## **الأسئلة المتكررة**

**هل ينبغي استخدام فهرس المجموعة كمعرف للشكل؟**

فقط للمعالجة قصيرة الأجل عندما لا تتغير المجموعة قبل استخدام الفهرس. يُفضَّل الاعتماد على `Name` أو `AlternativeText` المعتمدة للقوالب المصمَّمة، أو `OfficeInteropShapeId` للعمل مع الـ interop على مستوى الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهارّه مرة أخرى.

**لماذا ظهر الشكل المستنسخ أمام شكل آخر؟**

`AddClone` يضيف النسخة إلى نهاية المجموعة، وهي مقدمة ترتيب Z. استخدم `InsertClone` لتحديد الفهرس الأولي أو `Reorder` بعد إضافة جميع الأشكال.