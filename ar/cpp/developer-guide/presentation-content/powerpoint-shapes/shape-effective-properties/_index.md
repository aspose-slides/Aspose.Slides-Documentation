---
title: الحصول على الخصائص الفعّالة للأشكال من العروض التقديمية في C++
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/cpp/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز إضاءة
- شكل الحافة
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides للغة C++ بحساب وتطبيق الخصائص الفعّالة للأشكال للحصول على عرض تقديمي دقيق في PowerPoint."
---
## **نظرة عامة**

تشرح هذه المقالة الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق محدد، مثل:

1. خصائص الجزء في الشريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة رئيسية، عندما يحتوي شكل إطار نص الجزء على واحدة.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها على أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يُعرض"، فإنها تحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها عن طريق استدعاء طريقة `GetEffective` على كائن التنسيق المحلي.

المثال التالي يوضح كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
تمثل بيانات التنسيق الفعّالة التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformateffectivedata/)، داخليًا. استدعاء `GetEffective` مرة أخرى بعد تغيير التنسيق الأصلي أو الموروث يمكنه تحديث البيانات المخزنة مؤقتًا، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى حفظ القيم الفعّالة لإعادة استخدامها لاحقًا، انسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة للكاميرا. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص كاميرا فعّالة. يتم الكشف عن مثال [ICameraEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icameraeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يعرض المثال البرمجي التالي كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **الحصول على الخصائص الفعّالة لجهاز الإضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لجهاز الإضاءة. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز إضاءة فعّالة. يتم الكشف عن مثال [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrigeffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يعرض المثال البرمجي التاليكيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **الحصول على الخصائص الفعّالة لحافة الشكل**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لحافة الشكل. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الإزاحة الوجهية الفعّالة لشكل. يتم الكشف عن مثال [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) من خلال [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، الذي يوفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يعرض المثال البرمجي التاليكيفية الحصول على الخصائص الفعّالة للحافة العليا لشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. تحتوي واجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعّالة.

يعرض المثال البرمجي التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. تحتوي واجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعّالة.

يعرض المثال البرمجي التاليكيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **الحصول على قيمة ارتفاع الخط الفعّال**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الكود التالي كيف يتغير ارتفاع الخط الفعّالي للجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الحصول على تنسيق التعبئة الفعّال لجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق تعبئة فعّال لأجزاء مختلفة من الجدول. تحتوي واجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعّالية. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتنسيق الصف له أولوية أعلى من تنسيق العمود، وتنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

وبالتالي، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يعرض المثال البرمجي التاليكيفية الحصول على تنسيق تعبئة فعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/).

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **الأسئلة المتكررة**

### هل تُعيد `GetEffective` لقطة؟

ليس دائمًا. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، لكن بعض كائنات البيانات الفعّالية قد تُخزن مؤقتًا داخليًا. قد يُعيد استدعاء `GetEffective` لاحقًا حساب التنسيق وتحديث البيانات المخزنة، لذلك لا ينبغي اعتبار الكائن الذي تم الحصول عليه مسبقًا لقطة دائمة.

### متى يجب عليّ قراءة الخصائص الفعّالة مرة أخرى؟

استدعِ `GetEffective` مرة أخرى بعد تغيير التنسيق المحلي أو الأنماط الأصلية أو تنسيق التخطيط أو تنسيق الرئيس أو الإعدادات الافتراضية على مستوى العرض التقديمي. الاستدعاء التالي يعيد تقييم شجرة التنسيق ويعيد النتيجة الفعّالة الحالية.

### هل يؤدي تغيير أو إزالة شريحة تخطيط/رئيس إلى تأثير الخصائص الفعّالة التي تم استرجاعها مسبقًا؟

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `GetEffective`. إذا تم تغيير مصدر تنسيق الأصل أو إزالته، قد تصبح البيانات الفعّالة المستلمة سابقًا قديمة. بمجرد استدعاء `GetEffective` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى الناتجة.

### هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالة؟

لا. تُظهر كائنات البيانات الفعّالة القيم المحسوبة فقط. أجرِ التغييرات في كائنات التنسيق المحلي، ثم احصل على القيم الفعّالة مرة أخرى.

### ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، أو في التخطيط/الرئيس، أو في الإعدادات العامة؟

تُحدد القيمة الفعّالة عبر آلية القيم الافتراضية، التي تشمل القيم الافتراضية لـ PowerPoint و Aspose.Slides. تصبح تلك القيمة المُحددة جزءًا من البيانات الفعّالة الحالية.

### من قيمة الخط الفعّالة، هل يمكنني معرفة أي مستوى قدم الحجم أو نوع الخط؟

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء، الفقرة، إطار النص، وأنماط النص في التخطيط، الرئيس، ومستوى العرض التقديمي لمعرفة أين تظهر أول تعريف صريح.

### لماذا تبدو القيم الفعّالة أحيانًا متطابقة مع القيم المحلية؟

لأن القيمة المحلية أصبحت نهائية (لم يتطلب الأمر وراثة من مستوى أعلى). في مثل هذه الحالات، تتطابق القيمة الفعّالة مع القيمة المحلية.

### متى يجب عليّ استخدام الخصائص الفعّالة، ومتى أعمل فقط مع الخصائص المحلية؟

استخدم البيانات الفعّالة عندما تحتاج إلى النتيجة "كما تُعرض" بعد تطبيق جميع الوراثات، مثل مطابقة الألوان أو الهوامش أو الأحجام. إذا كنت بحاجة إلى الحفاظ على هذه القيم بغض النظر عن التغييرات اللاحقة في التنسيق، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت تحتاج إلى تعديل التنسيق في مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالة مرة أخرى للتحقق من النتيجة.