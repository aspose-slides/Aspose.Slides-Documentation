---
title: الحصول على الخصائص الفعّالة للشكل من العروض التقديمية في C++
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/cpp/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز الإضاءة
- شكل التقويس
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- العرض التقديمي
- C++
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides لـ C++ بحساب وتطبيق الخصائص الفعّالة للأشكال لتحقيق عرض PowerPoint بدقة."
---
## **نظرة عامة**

توضح هذه المقالة الفرق بين الخصائص **المحلية** و **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً في مستوى تنسيق محدد، مثل:

1. خصائص الجزء في الشريحة.
1. أنماط نص الشكل النموذجي في تخطيط أو شريحة رئيسية، عندما يكون للشكل إطار نص للجزء.
1. إعدادات النص العالمية في العرض التقديمي.

يمكن تعريف القيم المحلية أو حذفها في أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يتم عرضه"، فإنها تحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها باستدعاء طريقة `GetEffective` على كائن التنسيق المحلي.

يوضح المثال التالي كيفية الحصول على القيم الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص وعلى الأقل جزء واحد.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
تمثل بيانات التنسيق الفعّالية التنسيق المحسوب الحالي بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالية، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformateffectivedata/)، داخليًا. يمكن أن يؤدي استدعاء `GetEffective` مرة أخرى بعد تغيير التنسيق الوالدي أو الموروث إلى تحديث البيانات المخزنة مؤقتًا، وقد لا يعكس الكائن الذي تم الحصول عليه مسبقًا الحالة السابقة. إذا كنت بحاجة إلى الحفاظ على القيم الفعّالية لإعادة استخدامها لاحقًا، فانسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن البيانات الخاص بك.
{{% /alert %}}

## **الحصول على الخصائص الفعّالية للكاميرا**

تمكنك Aspose.Slides من الحصول على الخصائص الفعّالية للكاميرا. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتعديل يحتوي على خصائص الكاميرا الفعّالية. يتم الكشف عن مثيل [ICameraEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icameraeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالية لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يوضح مثال الشيفرة التالي كيفية الحصول على الخصائص الفعّالية للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```cpp
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

## **الحصول على الخصائص الفعّالية لجهاز الإضاءة**

تمكنك Aspose.Slides من الحصول على الخصائص الفعّالية لجهاز الإضاءة. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتعديل يحتوي على خصائص جهاز الإضاءة الفعّالية. يتم الكشف عن مثيل [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrigeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالية لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يوضح مثال الشيفرة التالي كيفية الحصول على الخصائص الفعّالية لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```cpp
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

## **الحصول على الخصائص الفعّالية لتقويس الشكل**

تمكنك Aspose.Slides من الحصول على الخصائص الفعّالية لتقويس الشكل. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتعديل يحتوي على خصائص تقويس الوجه لشكل ما. يتم الكشف عن مثيل [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، التي توفر القيم الفعّالية لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يوضح مثال الشيفرة التالي كيفية الحصول على الخصائص الفعّالية لتقويس الجزء العلوي من الشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

```cpp
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

## **الحصول على الخصائص الفعّالية لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالية لإطار النص. تحتوي واجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعّالية.

يوضح مثال الشيفرة التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالية. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص.

```cpp
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

## **الحصول على الخصائص الفعّالية لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالية لنمط النص. تحتوي واجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعّالية.

يوضح مثال الشيفرة التالي كيفية الحصول على خصائص نمط النص الفعّالية. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص.

```cpp
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

## **الحصول على قيمة ارتفاع الخط الفعّالية**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّالي. يوضح الشيفرة التالية كيف يتغير ارتفاع الخط الفعّالي لجزء بعد تعيين قيم ارتفاع الخط المحلية على مستويات مختلفة من بنية العرض التقديمي.

```cpp
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

## **الحصول على تنسيق التعبئة الفعّالي للجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق تعبئة فعّالي لأجزاء مختلفة من الجدول. تحتوي واجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعّالية. تنسيق الخلية له أولوية أعلى من تنسيق الصف، وتن Format
تنسيق الصف له أولوية أعلى من تنسيق العمود، وتن
تنسيق العمود له أولوية أعلى من تنسيق الجدول بالكامل.

نتيجةً لذلك، يتم استخدام خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يوضح مثال الشيفرة التالي كيفية الحصول على تنسيق تعبئة فعّالي لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/).

```cpp
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

**هل تُعيد `GetEffective` لقطة؟**

ليس دائمًا. تمثل البيانات الفعّالية التنسيق المحسوب بعد تطبيق الوراثة، ولكن قد يتم تخزين بعض كائنات البيانات الفعّالية داخليًا. قد يؤدي استدعاء `GetEffective` لاحقًا إلى إعادة حساب التنسيق وتحديث البيانات المخزنة مؤقتًا، لذا لا ينبغي اعتبار الكائن الذي تم الحصول عليه مسبقًا كقطة ثابتة.

**متى يجب أن أقرأ الخصائص الفعّالية مرة أخرى؟**

استدعِ `GetEffective` مرة أخرى بعد تغيير التنسيق المحلي أو أنماط الوالد أو تنسيق التخطيط أو تنسيق الرئيس أو القيم الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويعيد النتيجة الفعّالية الحالية.

**هل يؤثر تعديل أو إزالة شريحة تخطيط/رئيسية على الخصائص الفعّالية التي تم استرجاعها مسبقًا؟**

نعم، ولكن التغيير ينعكس في الاستدعاء التالي لـ `GetEffective`. إذا تم تعديل أو إزالة مصدر تنسيق الوالد، قد تصبح البيانات الفعّالية التي تم الحصول عليها سابقًا قديمة. بمجرد استدعاء `GetEffective` مرة أخرى، تقوم Aspose.Slides بإعادة تقييم شجرة التنسيق وقد تتغير الخطوط أو الألوان أو الأحجام أو القيم الأخرى الناتجة.

**هل يمكنني تعديل القيم عبر كائنات البيانات الفعّالية؟**

لا. كائنات البيانات الفعّالية تعرض القيم المحسوبة فقط. قم بإجراء التعديلات في كائنات التنسيق المحلي، ثم احصل مرة أخرى على القيم الفعّالية.

**ماذا يحدث إذا لم يتم تعيين الخاصية على مستوى الشكل، ولا في التخطيط/الرئيسية، ولا في الإعدادات العالمية؟**

يتم تحديد القيمة الفعّالية عبر آلية القيم الافتراضية، والتي تشمل القيم الافتراضية في PowerPoint و Aspose.Slides. تصبح تلك القيمة المحسومة جزءًا من البيانات الفعّالية الحالية.

**من قيمة الخط الفعّالية، هل يمكنني معرفة أي مستوى قدم الحجم أو نوع الخط؟**

ليس مباشرة. تعيد البيانات الفعّالية القيمة النهائية. لتحديد المصدر، تحقق من القيم المحلية في الجزء، الفقرة، إطار النص، وأنماط النص على مستوى التخطيط، والرئيسية، والعرض التقديمي لتحديد المكان الذي ظهر فيه التعريف الأول الصريح.

**لماذا تبدو القيم الفعّالية أحيانًا مطابقة للقيم المحلية؟**

لأن القيمة المحلية أصبحت نهائية (لم تتطلب وراثة من مستوى أعلى). في هذه الحالات، تتطابق القيمة الفعّالية مع القيمة المحلية.

**متى يجب استخدام الخصائص الفعّالية، ومتى يكتفي بالعمل مع الخصائص المحلية؟**

استخدم البيانات الفعّالية عندما تحتاج إلى النتيجة "كما يتم عرضها" بعد تطبيق جميع الوراثات، مثل مطابقة الألوان أو الهوامش أو الأحجام. إذا رغبت في الحفاظ على تلك القيم بغض النظر عن التغييرات المستقبلية في التنسيق، انسخ الخصائص المطلوبة إلى كائنك الخاص. إذا كنت بحاجة إلى تغيير التنسيق في مستوى محدد، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالية مرة أخرى للتحقق من النتيجة.