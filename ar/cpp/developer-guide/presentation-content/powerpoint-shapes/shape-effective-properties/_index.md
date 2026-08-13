---
title: الحصول على خصائص الشكل الفعالة من العروض التقديمية في C++
linktitle: خصائص فعالة
type: docs
weight: 50
url: /ar/cpp/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- نظام الإضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية استخدام Aspose.Slides للـ C++ للتمييز بين تنسيق الشكل المحلي والوارث والفعّال في عروض PowerPoint التقديمية."
---
## **فهم الخصائص المحلية والوارثة والفعالة**

يمكن أن يأتي تنسيق PowerPoint من عدة أماكن. القيمة المخزنة مباشرة على كائن هي **القيمة المحلية**. إذا لم يتم تعيين تلك القيمة، يبحث PowerPoint عن مصادر تنسيق الأب، مثل الإعداد الافتراضي للفقرة، نمط النص، تخطيط الشريحة أو الشريحة الرئيسية، السمة، أو الإعدادات الافتراضية على مستوى العرض التقديمي. تلك القيم هي **القيم الموروثة**. القيمة التي تبقى بعد حل كامل التسلسل الهرمي هي **القيمة الفعالة**—القيمة المستخدمة لعرض الكائن.

على سبيل المثال، قد لا تُعرّف جزء النص ارتفاع الخط الخاص به. ارتفاع الخط [font height](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseportionformat/) يكون حينها `std::numeric_limits<float>::quiet_NaN()`, مما يعني "ليس مُحددًا هنا". يمكن للجزء أن يرث ارتفاعًا من الفقرة، أو نمط النص الافتراضي للعرض التقديمي، أو مصدر آخر قابل للتطبيق. استدعاء [GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/) على تنسيق الجزء يُعيد الارتفاع المُحل النهائي.

استخدم نوعي بيانات التنسيق لأغراض مختلفة:

- قراءة أو تعديل كائن تنسيق محلي، مثل [IPortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/)، عندما تحتاج إلى التحكم في المكان الذي تم تعريف القيمة فيه.
- قراءة كائن البيانات الفعالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformateffectivedata/)، عندما تحتاج إلى النتيجة النهائية المُرسومة. البيانات الفعالة للقراءة فقط.

## **قارن القيم المحلية والوارثة والفعالة**

المثال الكامل التالي ينشئ شكلًا ويطبق ارتفاعات الخط على مستويات العرض التقديمي والفقرة والجزء. كل خطوة تطبع القيم المحددة على تلك المستويات والقيمة الفعالة الناتجة لنفس جزء النص. كما يوضح لماذا يجب قراءة البيانات الفعالة مرة أخرى بعد تغييرات التنسيق.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// تحديد القيم الموروثة على مستويين مختلفين.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // قراءة البيانات الفعالة بعد التغييرات السابقة.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// قيمة محلية على الجزء تتجاوز كلا القيمتين الموروثتين.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// تغيير قيمة موروثة لا يتجاوز قيمة محلية موجودة.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// مسح القيمة المحلية. الآن يرث الجزء من الفقرة مرة أخرى.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// مسح قيمة الفقرة. الآن يوفر الإعداد الافتراضي للعرض التقديمي النتيجة.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

الأولوية في هذا المثال هي تنسيق الجزء المحلي، ثم تنسيق الفقرة، ثم الإعداد الافتراضي للعرض التقديمي. يمكن لكائنات أخرى أن تكون لها سلاسل وراثة مختلفة، لكن المبدأ هو نفسه: القيمة الصريحة الأكثر تحديدًا هي الفائزة، و[GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/) يُعيد النتيجة النهائية.

## **احصل على خصائص النص الفعالة**

تنسيق النص مقسَّم عبر عدة كائنات:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/) يحل خصائص إطار النص مثل الهوامش، التثبيت، الضبط التلقائي، واتجاه النص العمودي.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextstyle/) يحل تنسيق الفقرات لكل مستوى من مستويات نمط النص.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iparagraphformat/) يحل خصائص الفقرة مثل المحاذاة، المسافة البادئة، والقوائم.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformat/) يحل خصائص الأحرف مثل ارتفاع الخط، نوع الخط، اللون، السُمك، والمائلة.

للمثال التالي، يجب أن يحتوي `text-formatting.pptx` على شريحة واحدة على الأقل وعلى [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) واحد بإطار نص غير فارغ. يمكن أن يظهر IAutoShape في أي موضع داخل مجموعة الأشكال؛ يبحث الكود عن كائن مناسب ويُصادق عليه قبل الاستخدام.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **احصل على الخصائص الثلاثية الأبعاد الفعالة**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/) يُعيد كائنًا واحدًا من نوع [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/) يجمع جميع إعدادات 3D المُحلَّة. بيانات [camera](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icameraeffectivedata/)، [light rig](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrigeffectivedata/)، [top bevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) و[bottom bevel](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) تكشف الإعدادات الفعالة المقابلة. قراءة هذه الإعدادات المرتبطة معًا تُسهِّل فهم المظهر الثلاثي الأبعاد النهائي للشكل.

لهذا المثال، يجب أن يحتوي `shape-3d.pptx` على شكل واحد على الأقل في الشريحة الأولى. طبّق إعدادات كاميرا 3D أو إضاءة أو تشطيب على ذلك الشكل إذا أردت أن يحتوي الناتج على قيم غير القيم الافتراضية.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **احصل على تنسيق الجدول الفعال**

يمكن أن يأتي تنسيق الجدول من نمط الجدول ومن التنسيقات المطبقة على الجدول بأكمله، أو عمود، أو صف، أو خلية فردية. في حالة حدوث تعارض بين ملء (fill) معرف صراحةً، تكون الأولوية للخلية، ثم الصف، ثم العمود، ثم الجدول بأكمله. التنسيق الفعلي للخلية هو التنسيق النهائي المستخدم لرسم تلك الخلية.

لهذا المثال، يجب أن يحتوي `table-formatting.pptx` على جدول واحد على الأقل في الشريحة الأولى. يجب أن يحتوي الجدول على صف واحد على الأقل وعمود واحد على الأقل. يبحث الكود عن [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/) بدلاً من افتراض أن الشكل الأول هو جدول.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

إذا كنت بحاجة إلى اللون بدلاً من نوع الملء فقط، افحص أولاً الـ [FillType](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/) الفعلي، ثم اقرأ الخاصية التي تنطبق على ذلك النوع—على سبيل المثال، [SolidFillColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/) للملء الصلب.

## **إعادة قراءة البيانات الفعالة بعد التغييرات**

البيانات الفعالة تصف تسلسل تنسيقات الهرم في لحظة حلها. استدعِ `GetEffective` مرة أخرى بعد تغيير أي شيء يمكن أن يشارك في هذا الهرم، بما في ذلك:

- تنسيق الكائن المحلي؛
- إعدادات الفقرة أو إطار النص الافتراضية؛
- نمط جدول، جدول، عمود، صف، أو تنسيق خلية؛
- تنسيق تخطيط أو شريحة رئيسية؛
- بيانات السمة أو الإعدادات الافتراضية على مستوى العرض التقديمي؛
- التخطيط أو الشريحة الرئيسية المعينة للشريحة.

لا تحتفظ بكائن بيانات فعالة كلقطة ثابتة. قد يخزن Aspose.Slides بعض البيانات الفعالة مؤقتًا داخليًا، ويمكن لاستدعاء `GetEffective` لاحقًا تحديث تلك البيانات. إذا كنت بحاجة إلى مقارنة القيم قبل وبعد التغيير، انسخ القيم المتقلبة التي تحتاجها—مثل ارتفاع الخط، اللون، المحاذاة، أو عرض التشطيب—إلى متغيراتك الخاصة قبل إجراء التغيير.

لتغيير قيمة، حدّث كائن التنسيق المحلي المناسب ثم استدعِ `GetEffective` للتحقق من النتيجة. كائنات البيانات الفعالة نفسها للقراءة فقط.

## **FAQ**

**كيف يمكنني معرفة أي مستوى زوَّد بالقيمة الفعالة؟**

البيانات الفعالة تحتوي على القيمة النهائية، وليس مصدرها. افحص الكائنات المحلية القابلة للتطبيق من المستوى الأكثر تحديدًا إلى الخارج. بالنسبة للنص، قد يشمل ذلك الجزء، الفقرة، إطار النص، التخطيط، الشريحة الرئيسية، السمة، وإعدادات العرض التقديمي الافتراضية. القيم غير المعرفة مثل `std::numeric_limits<float>::quiet_NaN()` أو `nullptr` تشير إلى أن البحث يستمر إلى مستوى آخر.

**ماذا يحدث إذا لم يعرّف أي مستوى خاصية؟**

يقوم Aspose.Slides بحل الإعداد الافتراضي المناسب لـ PowerPoint أو للمكتبة. تظهر تلك القيمة المحلَّلة في البيانات الفعالة رغم عدم تعريف أي كائن محلي لها صراحةً.

**لماذا قد تكون القيمة الفعالة أحيانًا مساوية للقيمة المحلية؟**

القيمة المحلية فازت في حساب الوراثة. وهذا متوقع عندما يتم تعيين الخاصية صراحةً على الكائن ولا تتجاوزها قاعدة أكثر تحديدًا.

**متى يجب أن أستخدم البيانات المحلية بدلًا من البيانات الفعالة؟**

استخدم البيانات المحلية لتفقد أو تعديل مستوى تنسيق معين. استخدم البيانات الفعالة عندما تحتاج إلى المظهر النهائي بعد حساب الوراثة وقواعد السمة والأنماط المطبقة. مثال [complete comparison example](#compare-local-inherited-and-effective-values) يُظهر كلاهما في نفس سير العمل.