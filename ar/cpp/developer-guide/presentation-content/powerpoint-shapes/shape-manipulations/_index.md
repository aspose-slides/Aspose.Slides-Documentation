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
- العثور على الشكل
- استنساخ الشكل
- إزالة الشكل
- إخفاء الشكل
- تغيير ترتيب الشكل
- الحصول على معرف الشكل Interop
- نص الشكل البديل
- نقطة ضبط الشكل
- ضبط الشكل المسبق
- هندسة الشكل
- تنسيقات تخطيط الشكل
- شكل كـ SVG
- تحويل الشكل إلى SVG
- محاذاة الشكل
- عكس الشكل
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية تحديد، ضبط، استنساخ، إزالة، إخفاء، إعادة ترتيب، تصدير، محاذاة، وعكس أشكال العروض التقديمية باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

Aspose.Slides for C++ يمثل الأشكال على الشريحة كـ[IShapeCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/) مرتب. المجموعة هي المكان الذي تجد فيه الأشكال وتعدلها ومصدر ترتيب تكدسها: الفهرس `0` هو الشكل الأبعد في الخلفية، بينما الفهرس الأخير هو الشكل الأقرب إلى المقدمة.

يتبع هذا المقال هذا النموذج. يشرح أولاً كيفية تحديد الشكل موثوقًا وتعديل نقاط الضبط المسبقة، ثم يظهر كيفية استنساخ، إزالة، إخفاء، وإعادة ترتيب الأشكال. تغطي الأقسام النهائية تنسيق مستوى التخطيط، تصدير SVG، المحاذاة، وإعدادات الانعكاس. كل مثال مستقل، لذلك يمكنك استخدام العمليات التي يحتاجها سير عملك فقط.

## **تحديد وإيجاد الأشكال**

فهارس المجموعة مريحة أثناء معالجة ملف معروف، لكنها ليست معرفات ثابتة. إضافة أو إزالة أو إعادة ترتيب شكل يمكن أن يغيّر فهرسه. اختر معرفًا وفقًا لكيفية إنشاء وتحصين العرض التقديمي:

- [Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_name/) مفيدة للقوالب التي يتحكم فيها المطورون ويسهل فحصها في لوحة التحديد في PowerPoint. يمكن تحرير الأسماء ولا يُضمن أنها فريدة، لذا ضع اتفاقية تسمية إذا كان الكود يعتمد عليها.
- [AlternativeText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_alternativetext/) مفيدة عندما تكون الوصيفة التكيفية أو علامة يضيفها المؤلف قد عرّفت الشكل بالفعل. هي مرئية للمستخدمين، قد تُمحَوَّل أو تُعاد صياغتها لإمكانية الوصول، ولا يُضمن أنها فريدة. لا تُعيد توجيه نص إمكانية الوصول ذو المعنى كمفتاح قاعدة بيانات بصمت.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_officeinteropshapeid/) هو معرف للقراءة فقط فريد داخل الشريحة ويتطابق مع معرف الشكل المستخدم في تفاعل PowerPoint. استخدمه عند التكامل مع PowerPoint أو عندما تحتاج إلى مرجع لا لبس فيه طوال عمر الشكل. الشكل المستنسخ أو المُعاد إنشائه هو شكل مختلف ويحصل على معرف خاص به.

خاصية [UniqueId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/get_uniqueid/) ذات نطاق عرض تقديمي، لكنها مخصصة للإضافات ويمكن إعادة تعيينها. لا ينبغي اعتبارها مفتاحًا خارجيًا دائمًا. إذا كانت الهوية طويلة الأمد ضرورية، احتفظ بالتطابق في بيانات التطبيق وتحقق من أن الشكل المتوقع ما زال موجودًا.

المثال التالي يبحث بالـ`Name` ويبلغ عن معرف Interop بمستوى الشريحة. عندما لا يحتوي القالب على الشكل المتوقع، يُبلِغ الكود عن ذلك بدلاً من المتابعة مع الكائن الخطأ.

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

عند كون العملية خاصة بنوع شكل ما، تحقق من الواجهة قبل استخدام الأعضاء الخاصة بالنوع. هذا المثال يُحدِّث النص والنص البديل فقط إذا كان الكائن المُسمى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/).

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

## **تحديد وتعديل ضبط الأشكال المسبقة**

الأشكال الهندسية المسبقة يمكن أن تعرض نقاط ضبط تتحكم في ميزات مثل حجم الزاوية، نسب السهم، أو زوايا القوس. وصول إليها يكون عبر مجموعة القراءة فقط [IGeometryShape::get_Adjustments](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igeometryshape/get_adjustments/). المجموعة نفسها تُوفرها الشكل، لكن كل [IAdjustValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/) يحتوي قيمة يمكن تغييرها.

لا تعتمد فقط على فهرس ثابت للمجموعة. مرّ عبر الضبط وتفحص خاصية القراءة فقط [IAdjustValue::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/get_type/) التي يُصفِّفها قيمة [ShapeAdjustmentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapeadjustmenttype/) ما يتحكم به الضبط. خاصية القراءة فقط [IAdjustValue::get_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/get_name/) تُوفر معلومات تعريف إضافية وتكون مفيدة خصوصًا عندما يحتوي قالب على أكثر من ضبط من نفس النوع الدلالي.

استخدم خاصية القيمة التي تتوافق مع معنى الضبط:

| نوع الضبط | الغرض | القيمة التي تُغيّر |
|---|---|---|
| `CornerSize` | حجم الزوايا المستديرة | [RawValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/set_rawvalue/) |
| `ArrowTailThickness` | سمك ذيل السهم | `RawValue` |
| `ArrowheadLength` | طول رأس السهم | `RawValue` |
| `ArrowheadWidth` | عرض رأس السهم | `RawValue` |
| `StartAngle` | زاوية البداية لفطيرة أو قوس | [AngleValue](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iadjustvalue/set_anglevalue/) |
| `EndAngle` | زاوية النهاية لفطيرة أو قوس | `AngleValue` |

`Type` و`Name` لا يمكن تعيينهما. `RawValue` هو عدد صحيح قابل للقراءة والكتابة بوحدات الهندسة الأصلية للقالب، بينما `AngleValue` هو زاوية قابلة للقراءة والكتابة بالدرجات. عدد، ترتيب، معنى، والنطاق الصالح للضبط يعتمد على قالب [ShapeType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/igeometryshape/get_shapetype/). القيمة الصالحة لقالب قد تكون غير صالحة أو ذات تأثير مختلف لقالب آخر.

عند كون `Type` هو `ShapeAdjustmentType::Custom`، لا يتعرف API على معنى دلالي قياسي. افحص `Name`، نوع القالب، والقيمة الحالية، واترك الضبط دون تغيير ما لم تعرف المعنى والنطاق المتوقع. حتى للأنواع المعروفة، تحقق مما إذا كان النوع نفسه يظهر أكثر من مرة قبل اختيار قيمة. مقالة [Connector](/slides/ar/cpp/connector/) تُظهر هذا الوضع مع ضبط انحناءات الوصلات.

المثال الكامل التالي يُنشئ نسخًا افتراضية ومُعدَّلة من ثلاثة أشكال مسبقة. يمر عبر كل ضبط، يُبلغ عن `Name` و`Type`، يُغيّر القيم المتعلقة بالحجم عبر `RawValue`، ويغيّر الزوايا عبر `AngleValue`، ثم يُحفظ النتيجة. العمود الأيسر يُظهر الهندسة الافتراضية؛ العمود الأيمن يُظهر المستطيل المستدير المُعدَّل، السهم رباعي الاتجاهات، والفطيرة.

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

// يضيف رؤوسًا لأعمدة الشكل الافتراضي والعمود المعدل.
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

التحقق من النوع الدلالي قبل تغيير قيمة يجعل الكود صريحًا بشأن نواياه ويتجنب الافتراض بأن فهرس مجموعة معين له نفس المعنى عبر أشكال مسبقة مختلفة.

## **تعديل مجموعة الأشكال**

طرق الإضافة، النسخ، الإزالة، وإعادة الترتيب تعمل على المجموعة فورًا. إذا غيرت عملية ما عدد أو ترتيب الأشكال، لا تستمر في الاعتماد على الفهارس التي تم التقاطها قبل تلك العملية.

### **استنساخ شكل**

[AddClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/addclone/) يُنشئ نسخة مستقلة ويضيفها إلى نهاية المجموعة الهدف. [InsertClone](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/insertclone/) أيضًا يُنشئ نسخة لكنه يضعها في فهرس ترتيب z محدد. التحميلات التي تقبل إحداثيات تنقل النسخة دون تغيير حجمها؛ التحميلات ذات العرض والارتفاع يمكن أن تعيد تحجيمها أيضًا.

المثال يُنشئ شريحة هدف، يستنسخ مستطيلًا مُعنونًا إلى المقدمة، ويُدرج نسخة ثانية في الخلف. التغييرات على أي نسخة لا تُعدِّل الشكل الأصلي.

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

الاستنساخ ينسخ محتوى الشكل وتنسيقه، بما في ذلك اسمه والنص البديل. عيّن معرفات منطقية جديدة للنسخة عندما يجب أن تكون هذه القيم فريدة. الموارد التي تستخدمها الأشكال المعقدة تُدار بواسطة العرض التقديمي، لكن النسخة تظل عنصرًا جديدًا في المجموعة له هوية شكل جديدة.

### **إزالة الأشكال**

[Remove](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/remove/) يحذف كائن شكل محدد من مجموعته. عند إزالة مطابقات متعددة خلال تكرار بفهارس، تجول من النهاية حتى يبقى كل فهرس متبقي صالحًا.

هذا المثال يزيل كل شكل يحمل اسمًا معينًا. يقرأ الشكل المفهرس الحالي، وليس عنصر مجموعة ثابت، ولا يُحوِّل الشكل دون حاجة.

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

بعد الإزالة، يتغيّر عدد الأشكال وفهارس الأشكال اللاحقة. المراجع للأشكال غير المتأثرة تظل أكثر موثوقية من الفهارس المحفوظة. ضع في اعتبارك الوصلات، الرسوم المتحركة، وميزات العرض الأخرى التي قد تشير إلى الكائن المُزال؛ إزالة شكل ظاهر يمكن أن تغيّر أكثر من مظهر الشريحة.

### **إخفاء شكل**

ضبط [Hidden](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_hidden/) إلى `true` يبقي الشكل في المجموعة لكنه يمنعه من الظهور في عرض الشرائح العادي. يبقى فهرسه، تنسيقه، ومحتواه متاحًا للكود، لذا الإخفاء مناسب للعناصر الاختيارية التي قد تُستعاد لاحقًا.

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

الإخفاء ليس حذفًا ولا أمانًا. لا يزال بالإمكان اكتشاف الكائن وإظهاره مرة أخرى من قبل المستخدم أو الكود، ويظل جزءًا من ملف العرض التقديمي.

### **تغيير ترتيب Z**

الأشكال المتداخلة تُرسم بترتيب المجموعة. [Reorder](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapecollection/reorder/) ينقل شكلًا موجودًا إلى فهرس هدف دون استنساخه. الفهرس `0` هو الخلف؛ `Count - 1` هو المقدمة.

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

المستطيل يُنشأ أولًا ويقع في البداية خلف الشكل البيضاوي. نقله إلى الفهرس النهائي يجعله في المقدمة. أكمل ترتيب z بعد إضافة أو استنساخ جميع الأشكال ذات الصلة، لأن تلك العمليات تُضيف أو تُدرج عناصر مجموعة جديدة ويمكن أن تغيّر التكدس المقصود.

## **فحص الأشكال على شرائح التخطيط**

الشرائح العادية، شرائح التخطيط، وشرائح القالب لها مجموعات أشكال منفصلة. الشكل في مجموعة التخطيط ليس نفس الكائن كما هو في شريحة عادية بنفس الموضع. افحص أشكال التخطيط عندما تحتاج إلى فهم أو تغيير التنسيق المزوّد بواسطة التخطيط.

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

تحرير تخطيط يمكن أن يؤثر على عدة شرائح تستخدمه. قبل تغيير شكل تخطيط، حدّد ما إذا كانت شريحة عادية ترث الكائن أو تحتوي على تعديل محلي، واختبر كل شريحة تستخدم ذلك التخطيط.

## **تصدير شكل إلى SVG**

[WriteAsSvg](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/writeassvg/) يكتب المحتوى المُرسوم لشكل واحد إلى دفق. النتيجة تحتوي على الشكل فقط، لا خلفية الشريحة بالكامل أو الأشكال المجاورة.

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

احتفظ بالعرض التقديمي مفتوحًا أثناء الإخراج. النتيجة تعتمد على تنسيق الشكل وعلى الموارد مثل الخطوط والصور. إذا كنت بحاجة إلى التكوين الكامل، صدّر الشريحة بدلًا من الشكل الفردي. المتصل يمتلك الدفق ويجب أن يغلقه أو يحرره.

## **محاذاة الأشكال**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/alignshapes/) يوفّر إصدارات تُحاذي إما جميع الأشكال أو فهارس مجموعة مختارة. [ShapesAlignmentType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapesalignmenttype/) يحدد الحافة، خط الوسط، أو وضع التوزيع. اضبط `alignToSlide` إلى `true` لاستخدام حواف الشريحة؛ اضبطه إلى `false` لمحاذاة الأشكال المختارة بالنسبة إلى بعضها البعض.

هذا المثال يحاذي ثلاثة أشكال إلى الحافة العليا للشريحة. مراجع الأشكال المُُرجَعة تُحوَّل إلى فهارسها الحالية مباشرة قبل المحاذاة.

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

المحاذاة تُغيّر المواقع، لا ترتيب Z. المحاذاة النسبية عادةً تحتاج إلى شكلين على الأقل، بينما التوزيع الأفقي أو العمودي يحتاج إلى عدد كافٍ من الأشكال لتحديد الفواصل. أعد حساب الفهارس إذا عدّلت المجموعة قبل استدعاء الطريقة.

## **انعكاس الشكل**

فئة [ShapeFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shapeframe/) تخزن الموقع، الحجم، إعدادات الانعكاس الأفقي والعمودي، والدوران. قيمتي `FlipH` و`FlipV` تستخدمان [NullableBool](https://reference.aspose.com/slides/ar/cpp/aspose.slides/nullablebool/): `True` تُفعِّل الانعكاس، `False` تُعطّله، و`NotDefined` تُبقي الحالة غير محددة/الافتراضية.

العرض التقديمي المُدخل أدناه يحتوي على شكل غير مُنعكس.

![The shape before flipping](shape_to_be_flipped.png)

المثال يحافظ على كل قيمة إطار أخرى ويستبدل إعدادات الانعكاس فقط. هذا مهم لأن تعيين [Frame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_frame/) جديد يستبدل الإطار بالكامل.

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

الشكل المحفوظ مُعكَّس أفقياً وعمودياً مع الحفاظ على موقعه، حجمه، ودورانه.

![The shape after flipping](flipped_shape.png)

## **الأسئلة المتكررة**

**هل يجب أن أستخدم فهرس مجموعة كمعرف للشكل؟**

فقط للمعالجة القصيرة الأمد عندما لن تتغير المجموعة قبل استخدام الفهرس. يفضَّل اعتماد convention `Name` أو `AlternativeText` للقوالب المُنشأة، أو `OfficeInteropShapeId` للعمل التفاعلي على مستوى الشريحة.

**هل إخفاء الشكل يزيله من ترتيب Z؟**

لا. الشكل المخفي يبقى في المجموعة عند نفس الفهرس. يمكن العثور عليه، إعادة ترتيبه، تحريره، أو إظهاره مرة أخرى.

**لماذا ظهر شكل مُستنسخ أمام شكل آخر؟**

`AddClone` يُضيف النسخة إلى نهاية المجموعة، وهي مقدمة ترتيب Z. استخدم `InsertClone` لاختيار الفهرس الابتدائي أو `Reorder` بعد إضافة جميع الأشكال.

**هل يمكنني استخدام فهرس ثابت لتحديد ضبط شكل مسبق؟**

فقط بعد التحقق من القالب الدقيق وتخطيط المجموعة. يفضَّل التكرار خلال `IGeometryShape::get_Adjustments` والتحقق من `IAdjustValue::get_Type`؛ استخدم `IAdjustValue::get_Name` كمعلومات إضافية عندما يظهر نفس النوع الدلالي أكثر من مرة.