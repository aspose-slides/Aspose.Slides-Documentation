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
- نسخ شكل
- إزالة شكل
- إخفاء شكل
- تغيير ترتيب الشكل
- الحصول على معرف شكل Interop
- النص البديل للشكل
- نقطة ضبط الشكل
- ضبط الشكل المحدد مسبقًا
- هندسة الشكل
- تنسيقات تخطيط الشكل
- شكل بصيغة SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- عكس الشكل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تحديد، تعديل، نسخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وعكس أشكال العرض التقديمي باستخدام Aspose.Slides للغة C++."
---
## **نظرة عامة**

يمثل Aspose.Slides for C++ الأشكال في الشريحة كمجموعة [IShapeCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/) مرتبة. تشكل المجموعة كلًا من المكان الذي تجد فيه وتعدِّل الأشكال ومصدر ترتيب تكدسها: الفهرس `0` هو الشكل الأبعد إلى الخلف، بينما الفهرس الأخير هو الشكل الأقرب إلى الأمام.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية تحديد شكل موثوق وتعديل نقاط الضبط المحددة مسبقًا، ثم يُظهر كيفية نسخ، حذف، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام الأخيرة تنسيق المستوى التخطيطي، تصدير SVG، المحاذاة، وإعدادات الانعكاس. كل مثال مستقل، لذا يمكنك استخدام العمليات التي يتطلبها سير عملك فقط.

## **تحديد وإيجاد الأشكال**

تعد فهارس المجموعة مريحة عند معالجة ملف معروف، لكنها ليست معرفات ثابتة. يمكن أن يغيّر إضافة أو حذف أو إعادة ترتيب شكل فهرسه. اختر معرفًا وفقًا للطريقة التي يُكتب ويُصان بها العرض التقديمي:

- [Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_name/) مفيد للقوالب التي يتحكم فيها المطور وسهل فحصه في لوحة التحديد في PowerPoint. يمكن تعديل الأسماء ولا يضمن أنها فريدة، لذا ضع convention تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_alternativetext/) مفيد عندما تكون وصفية إمكانية الوصول أو علامة يضيفها المؤلف قد عَرَفت الشكل بالفعل. هو مرئي للمستخدمين، قد يُترجم أو يُعاد صياغته لتلبية إمكانية الوصول، ولا يضمن تفرده. لا تُعيد استخدام نص إمكانية الوصول المفيد كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_officeinteropshapeid/) هو معرف للقراءة فقط فريد ضمن الشريحة ويتطابق مع معرف الشكل المستخدم في تكامل PowerPoint. استخدمه عند الدمج مع PowerPoint أو عندما تحتاج إلى مرجع لا لبس فيه طوال عمر الشكل. الشكل المنسوخ أو المعاد إنشاؤه يكون شكلًا مختلفًا ويحصل على معرف خاص به.

الخاصية المرتبطة [UniqueId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_uniqueid/) لها نطاق عرض تقديمي، لكنها مخصصة للإضافات ويمكن إعادة تعيينها. لا ينبغي اعتبارها مفتاحًا خارجيًا دائمًا. إذا كان الهوية طويلة الأمد أمرًا أساسيًا، احتفظ بالربط في بيانات التطبيق وتأكد من أن الشكل المتوقَّع لا يزال موجودًا.

لمثال عملي على قراءة وتحديث كل من عنوان النص البديل والوصف، انظر إلى [Manage Alternative Text Titles and Descriptions](/slides/ar/cpp/presentation-accessibility/). استخدم النص البديل لشرح معنى الشكل للقراء، واحتفظ به منفصلًا عن أسماء الأشكال التي يستخدمها الكود للعثور على الأشكال.

المثال التالي يبحث عن طريق `Name` ويُبلغ عن معرف الـ interop المتعلق بالشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلغ الكود عن ذلك بدلًا من الاستمرار مع الكائن الخاطئ.

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

عند كون العملية خاصة بنوع شكل معين، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. يُحدَّث هذا المثال النص والنص البديل فقط إذا كان الكائن المسمي هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/).

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

## **تحديد وتعديل ضبط الأشكال المحددة مسبقًا**

يمكن للأشكال ذات الهندسة المحددة مسبقًا أن تكشف عن نقاط ضبط تتحكم في ميزات مثل حجم الزوايا، نسب السهام، أو زوايا القطع. يمكن الوصول إليها عبر مجموعة القراءة فقط [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igeometryshape/get_adjustments/). تُزوَّد المجموعة نفسها من قبل الشكل، لكن كل [IAdjustValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/) يحتوي على قيمة يمكن تغيّرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. كرّر عبر الضبط وتفحَّص خاصية القراءة فقط [IAdjustValue::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/get_type/) التي تُحدد [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapeadjustmenttype/) قيمة ما يتحكم فيه الضبط. خاصية القراءة فقط [IAdjustValue::get_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/get_name/) توفر معلومات تعريف إضافية وتكون مفيدة خاصةً عندما يحتوي القالب على أكثر من ضبط بنفس النوع الدلالي.

استخدم خاصية القيمة التي تتطابق مع معنى الضبط:

| نوع الضبط | الغرض | القيمة التي يُغيّرها |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [RawValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | سماكة ذيل السهم | `RawValue` |
| `ArrowheadLength` | طول رأس السهم | `RawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `RawValue` |
| `StartAngle` | زاوية البدء لفطيرة أو قوس | [AngleValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | زاوية النهاية لفطيرة أو قوس | `AngleValue` |

لا يمكن تعيين `Type` ولا `Name`. `RawValue` هو عدد صحيح قابل للقراءة والكتابة بوحدات الهندسة الأصلية للقالب، بينما `AngleValue` هو زاوية قابلة للقراءة والكتابة بالدرجات. عدد، ترتيب، معنى، والنطاق الصحيح للضبط يعتمد على قالب [ShapeType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igeometryshape/get_shapetype/). قد تكون قيمة صالحة لقالب ما غير صالحة أو لها تأثير مختلف في قالب آخر.

عند تكون `Type` هي `ShapeAdjustmentType::Custom`، لا يتعرف الـ API على معنى دلالي قياسي. افحص `Name`، نوع القالب، والقيمة الحالية، واترك الضبط كما هو ما لم يكن المعنى والنطاق معروفين. حتى للأنواع المعروفة، تحقّق ما إذا كان نفس النوع يظهر أكثر من مرة قبل اختيار قيمة. يُظهر مقال [Connector](/slides/ar/cpp/connector/) هذا الوضع مع ضبط انحناءات الموصل.

المثال الكامل التالي يُنشئ إصدارات افتراضية ومُعدّلة لثلاثة أشكال محددة مسبقًا. يكرّر عبر كل ضبط، يُبلغ عن `Name` و`Type` الخاص به، يغيّر القيم المرتبطة بالحجم عبر `RawValue`، يغيّر الزوايا عبر `AngleValue`، ويحفظ النتيجة. العمود الأيسر يحتفظ بالهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المعدّل، السهم رباعي الاتجاهات، والفطيرة.

```cpp
#include <DOM/IAdjustValue.h>
#include <DOM/IAdjustValueCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeAdjustmentType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// يضيف رؤوسًا لأعمدة الشكل الافتراضي والمعدل.
auto defaultColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
defaultColumnLabel->get_TextFrame()->set_Text(u"Default preset geometry");
auto adjustedColumnLabel = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
adjustedColumnLabel->get_TextFrame()->set_Text(u"Modified adjustment values");

slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
auto modifiedRoundedRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle->set_Name(u"ModifiedRoundedRectangle");

slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
auto modifiedArrow = slide->get_Shapes()->AddAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
modifiedArrow->set_Name(u"ModifiedQuadArrow");

slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 95, 330, 130, 130);
auto modifiedPie = slide->get_Shapes()->AddAutoShape(ShapeType::Pie, 445, 330, 130, 130);
modifiedPie->set_Name(u"ModifiedPie");

auto shapesToAdjust = MakeArray<SharedPtr<IGeometryShape>>({modifiedRoundedRectangle, modifiedArrow, modifiedPie});

for (auto shape : shapesToAdjust)
{
    auto adjustments = shape->get_Adjustments();
    for (int32_t adjustmentIndex = 0; adjustmentIndex < adjustments->get_Count(); ++adjustmentIndex)
    {
        auto adjustment = adjustments->idx_get(adjustmentIndex);
        Console::WriteLine(shape->get_Name() + u" / " + adjustment->get_Name() + u": " + ObjectExt::ToString(adjustment->get_Type()));

        switch (adjustment->get_Type())
        {
            case ShapeAdjustmentType::CornerSize:
                adjustment->set_RawValue(5000);
                break;
            case ShapeAdjustmentType::ArrowTailThickness:
                adjustment->set_RawValue(25000);
                break;
            case ShapeAdjustmentType::ArrowheadLength:
                adjustment->set_RawValue(30000);
                break;
            case ShapeAdjustmentType::ArrowheadWidth:
                adjustment->set_RawValue(40000);
                break;
            case ShapeAdjustmentType::StartAngle:
                adjustment->set_AngleValue(30);
                break;
            case ShapeAdjustmentType::EndAngle:
                adjustment->set_AngleValue(300);
                break;
            case ShapeAdjustmentType::Custom:
                Console::WriteLine(u"Custom adjustment '" + adjustment->get_Name() + u"' was not changed.");
                break;
        }
    }
}

presentation->Save(u"preset-shape-adjustments.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

التفحص الدلالي للنوع قبل تغيير قيمة يجعل الكود واضحًا بشأن نواياه ويتجنّب الافتراض أن فهرس مجموعة معين له نفس المعنى عبر قوالب مختلفة.

## **تعديل مجموعة الأشكال**

تعمل طرق الإضافة، النسخ، الحذف، وإعادة الترتيب على المجموعة فورًا. إذا غيرت عملية ما عدد أو ترتيب الأشكال، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **نسخ شكل**

[AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addclone/) يُنشئ نسخة مستقلة ويُلحقها بالمجموعة الهدف. [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/insertclone/) ينشئ نسخة أيضًا لكنه يضعها في فهرس z‑order محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات التي تقبل العرض والارتفاع يمكنها تغيير حجمه أيضًا.

المثال يُنشئ شريحة هدف، ينسخ مستطيلًا مُسمى إلى الأمام، ويُدرج نسخة ثانية إلى الخلف. لا تُغيّر التعديلات على أي من النسختين الشكل الأصلي.

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

النسخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون تلك القيم فريدة. الموارد المستخدمة بواسطة الأشكال المعقّدة تُدار بواسطة العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة له هوية شكل جديدة.

### **إزالة الأشكال**

[Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة عدة تطابقات أثناء تكرار فهرسي، تجول من النهاية بحيث يبقى كل فهرس متبقٍ صالحًا.

المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل المندَّد حسب الفهرس الحالي، ليس عنصر مجموعة ثابت، ولا يقوم بالتحويل غير الضروري للشكل.

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

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. تبقى المراجع إلى الأشكال غير المتأثرة أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك أيضًا الموصلات، الرسوم المتحركة، وميزات العرض التقديمي الأخرى التي قد تشير إلى الكائن المُزال؛ قد يغيّر حذف شكل مرئي أكثر من مجرد مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_hidden/) إلى `true` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يظل فهرسه وتنسيقه ومحتواه متاحًا للكود، لذا فإن الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بإمكان المستخدم أو الكود اكتشاف الكائن وإظهاره مرة أخرى، ويبقى جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتراكبة تُرسم بترتيب المجموعة. [Reorder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون نسخه. الفهرس `0` هو الخلف؛ `Count - 1` هو الأمام.

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

يُنشأ المستطيل أولًا ويقع في البداية خلف الشكل البيضاوي. نقله إلى الفهرس النهائي يضعه أمام الشكل. أكمل ترتيب الـ z‑order بعد إضافة أو نسخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدرج عناصر مجموعة جديدة ويمكن أن تغيّر التكدس المقصود.

## **فحص الأشكال في شرائح التخطيط**

تحتوي الشرائح العادية، وشرائح التخطيط، والشرائح الرئيسية على مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس نفس الكائن مثل الشكل المماثل في شريحة عادية. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير تنسيق يُقدَّم بواسطة التخطيط.

المثال التالي يقرأ كل [FillFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_fillformat/) و[LineFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_lineformat/) للشكل في التخطيط دون افتراض أن كل شكل هو `AutoShape`.

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

[WriteAsSvg](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/writeassvg/) يكتب محتوى شكل مُصَرَّف إلى تدفق. النتيجة تحتوي على الشكل فقط، وليس خلفية الشريحة بأكملها أو الأشكال المجاورة.

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

احتفظ بالعرض التقديمي مفتوحًا أثناء التصدير. يعتمد الإخراج على تنسيق الشكل وعلى موارد مثل الخطوط والصور. إذا كنت تحتاج إلى التركيبة الكاملة، صدّر الشريحة بدلاً من شكل فردي. المتصل يملك التدفق ويجب أن يغلقه أو يتخلص منه.

## **محاذاة الأشكال**

تُحاذى الدوال [SlideUtil::AlignShapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/alignshapes/) إما جميع الأشكال أو فهارس مجموعة محددة. تحدد [ShapesAlignmentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapesalignmenttype/) الحافة أو الخط المركزي أو وضع التوزيع. عيّن `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ عيّنها إلى `false` لمحاذاة الأشكال المحددة بالنسبة لبعضها البعض.

المثال يَحاذِ ثلاث أشكال إلى الحافة العليا للشريحة. تُحوَّل مراجع الأشكال المرجعية إلى فهارسها الحالية مباشرةً قبل المحاذاة.

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

المحاذاة تغيّر المواضع، لا ترتيب الـ z‑order. عادةً ما تحتاج المحاذاة النسبية إلى شكلين على الأقل، بينما يتطلب التوزيع الأفقي أو العمودي عددًا كافيًا من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدَّلت المجموعة قبل استدعاء الدالة.

## **انعكاس شكل**

تخزن فئة [ShapeFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapeframe/) الموضع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيم `FlipH` و`FlipV` تستخدم [NullableBool](https://reference.aspose.com/slides/ar/cpp/aspose.slides/nullablebool/): `True` يفعّل الانعكاس، `False` يلغيه، و`NotDefined` يحافظ على الحالة غير المحددة/الافتراضية.

العرض التقديمي المدخل أدناه يحتوي على شكل غيرمقلوب.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل إعدادات الانعكاس فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_frame/) جديد يستبدل الإطار الكامل.

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

الشكل المحفوظ يُعكس أفقيًا وعموديًا مع الحفاظ على موضعه، حجمه، ودورانه.

![The shape after flipping](flipped_shape.png)

## **الأسئلة المتداولة**

**هل يجب أن أستخدم فهرس المجموعة كمعرّف للشكل؟**

فقط للمعالجة قصيرة الأمد عندما لن تتغيّر المجموعة قبل استخدام الفهرس. يُفضَّل اعتماد convention معتمد على `Name` أو `AlternativeText` للقوالب المكتوبة، أو `OfficeInteropShapeId` للعمل مع الـ interop على مستوى الشريحة.

**هل إخفاء الشكل يزيله من ترتيب الـ z؟**

لا. يبقى الشكل المخفي في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر شكل منسوخ أمام شكل آخر؟**

`AddClone` يلصق النسخة في نهاية المجموعة، وهي أمام ترتيب الـ z. استخدم `InsertClone` لتحديد الفهرس الأولي أو `Reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل محدد مسبقًا؟**

فقط بعد التحقق من القالب الدقيق وتخطيط المجموعة. يُفضَّل تكرار عبر `IGeometryShape::get_Adjustments` وفحص `IAdjustValue::get_Type`؛ استخدم `IAdjustValue::get_Name` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.