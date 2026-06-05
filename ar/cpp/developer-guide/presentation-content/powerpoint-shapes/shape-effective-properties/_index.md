---
title: الحصول على خصائص الشكل الفعّالة من العروض التقديمية بلغة C++
linktitle: الخصائص الفعّالة
type: docs
weight: 50
url: /ar/cpp/shape-effective-properties/
keywords:
- خصائص الشكل
- خصائص الكاميرا
- جهاز إضاءة
- تقويس الشكل
- إطار النص
- نمط النص
- ارتفاع الخط
- تنسيق التعبئة
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "اكتشف كيف تقوم Aspose.Slides للغة C++ بحساب وتطبيق الخصائص الفعّالة للشكل للحصول على عرض PowerPoint دقيق."
---
## **نظرة عامة**

توضح هذه المقالة الفرق بين الخصائص **المحلية** والخصائص **الفعّالة**. القيم المحلية هي القيم التي يتم تعيينها مباشرةً على مستوى تنسيق معين، مثل:

1. خصائص الجزء على الشريحة.
1. أنماط نص الشكل النموذجي على تخطيط أو شريحة رئيسية، عندما يكون لشكل إطار النص للجزء واحد.
1. إعدادات النص العامة في العرض التقديمي.

يمكن تعريف القيم المحلية أو إهمالها في أي مستوى. عندما تحتاج Aspose.Slides إلى التنسيق النهائي "كما يتم عرضه"، تقوم بحل سلسلة الوراثة وتعيد القيم **الفعّالة**. يمكنك الحصول عليها عن طريق استدعاء طريقة `GetEffective` على كائن التنسيق المحلي.

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

تمثل بيانات التنسيق الفعّالة التنسيق الحالي المحسوب بعد تطبيق الوراثة. في التنفيذ الحالي، قد يتم تخزين بعض كائنات البيانات الفعّالة، مثل [IPortionFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iportionformateffectivedata/)، في الذاكرة مؤقتاً. يمكن لاستدعاء `GetEffective` مرة أخرى بعد تغيير تنسيق الأصل أو التنسيقات الموروثة تحديث البيانات المخزنة مؤقتاً، وقد لا يمثل الكائن الذي تم الحصول عليه مسبقاً الحالة السابقة. إذا كنت بحاجة إلى الحفاظ على القيم الفعّالة لإعادة استخدامها لاحقاً، قم بنسخ الخصائص المطلوبة، مثل ارتفاع الخط، لون التعبئة، نمط الخط، أو المحاذاة، إلى كائن بيانات خاص بك.

{{% /alert %}}

## **الحصول على الخصائص الفعّالة للكاميرا**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة للكاميرا. تمثل واجهة [ICameraEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icameraeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص الكاميرا الفعّالة. يتم عرض مثال [ICameraEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icameraeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، والذي يوفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يعرض مقتطف الشيفرة التالي كيفية الحصول على الخصائص الفعّالة للكاميرا. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لجهاز إضاءة**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لجهاز الإضاءة. تمثل واجهة [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrigeffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص جهاز الإضاءة الفعّالة. يتم عرض مثال [ILightRigEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ilightrigeffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، والذي يوفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يعرض مقتطف الشيفرة التالي كيفية الحصول على الخصائص الفعّالة لجهاز الإضاءة. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لتقويس الشكل**

تتيح لك Aspose.Slides الحصول على الخصائص الفعّالة لتقويس الشكل. تمثل واجهة [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) كائنًا غير قابل للتغيير يحتوي على خصائص التقويس الفعّالة للوجه على الشكل. يتم عرض مثال [IShapeBevelEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishapebeveleffectivedata/) عبر [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformateffectivedata/)، والذي يوفر القيم الفعّالة لـ [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/).

يعرض مقتطف الشيفرة التالي كيفية الحصول على الخصائص الفعّالة لتقويس الجزء العلوي من الشكل. يفترض أن الشكل الأول في الشريحة الأولى يحتوي على تنسيق ثلاثي الأبعاد.

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

## **الحصول على الخصائص الفعّالة لإطار النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لإطار النص. تحتوي واجهة [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformateffectivedata/) على خصائص تنسيق إطار النص الفعّالة.

يعرض مقتطف الشيفرة التالي كيفية الحصول على خصائص تنسيق إطار النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص.

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

## **الحصول على الخصائص الفعّالة لنمط النص**

باستخدام Aspose.Slides، يمكنك الحصول على الخصائص الفعّالة لنمط النص. تحتوي واجهة [ITextStyleEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextstyleeffectivedata/) على خصائص نمط النص الفعّالة.

يعرض مقتطف الشيفرة التالي كيفية الحصول على خصائص نمط النص الفعّالة. يفترض أن الشكل الأول في الشريحة الأولى هو [IAutoShape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iautoshape/) يحتوي على إطار نص.

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

## **الحصول على قيمة ارتفاع الخط الفعّال**

باستخدام Aspose.Slides، يمكنك الحصول على ارتفاع الخط الفعّال. يوضح الشيفرة التالية كيف يتغيّر ارتفاع الخط الفعّال للجزء بعد ضبط قيم ارتفاع الخط المحلية على مستويات بنية العرض المختلفة.

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

## **الحصول على تنسيق التعبئة الفعّال لجدول**

باستخدام Aspose.Slides، يمكنك الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. تحتوي واجهة [IFillFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ifillformateffectivedata/) على خصائص تنسيق التعبئة الفعّالة. يكون تنسيق الخلية ذا أولوية أعلى من تنسيق الصف، وتنسيق الصف أعلى من تنسيق العمود، وتنسيق العمود أعلى من تنسيق الجدول بأكمله.

وبالتالي، تُستخدم خصائص [ICellFormatEffectiveData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icellformateffectivedata/) لرسم خلية الجدول. يعرض مقتطف الشيفرة التالي كيفية الحصول على تنسيق التعبئة الفعّال لأجزاء مختلفة من الجدول. يفترض أن الشكل الأول في الشريحة الأولى هو [ITable](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itable/).

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

## **الأسئلة المتداولة**

**هل تُعيد `GetEffective` لقطة ثابتة؟**

ليس دائماً. تمثل البيانات الفعّالة التنسيق المحسوب بعد تطبيق الوراثة، إلا أن بعض كائنات البيانات الفعّالة قد يتم تخزينها مؤقتاً داخلياً. قد يقوم استدعاء `GetEffective` لاحقاً بإعادة حساب التنسيق وتحديث البيانات المخزنة، لذلك لا ينبغي اعتبار الكائن المسترجع مسبقاً كلقطة ثابتة.

**متى ينبغي قراءة الخصائص الفعّالة مرة أخرى؟**

استدعِ `GetEffective` مرة أخرى بعد تغيير التنسيق المحلي، أو أنماط الأصل، أو تنسيق التخطيط، أو تنسيق القالب الرئيسي، أو الإعدادات الافتراضية على مستوى العرض التقديمي. سيعيد الاستدعاء التالي تقييم شجرة التنسيق ويعيد النتيجة الفعّالة الحالية.

**هل يؤثر تغيير أو إزالة شريحة تخطيط/قالب رئيسي على الخصائص الفعّالة التي تم استرجاعها مسبقاً؟**

نعم، لكن التغيير ينعكس في الاستدعاء التالي لـ `GetEffective`. إذا تم تعديل أو إزالة مصدر تنسيق أب، قد تصبح البيانات الفعّالة المستلمة مسبقاً قديمة. بمجرد استدعاء `GetEffective` مرة أخرى، تعيد Aspose.Slides تقييم شجرة التنسيق وقد تتغيّر الخطوط، الألوان، الأحجام أو القيم الأخرى.

**هل يمكن تعديل القيم عبر كائنات البيانات الفعّالة؟**

لا. تُظهر كائنات البيانات الفعّالة القيم المحسوبة فقط. قم بإجراء التغييرات في كائنات التنسيق المحلي، ثم احصل على القيم الفعّالة مرة أخرى.

**ماذا يحدث إذا لم يتم تعيين خاصية على مستوى الشكل، ولا في التخطيط/القالب، ولا في الإعدادات العامة؟**

يُحدَّد القيمة الفعّالة من خلال الآلية الافتراضية التي تشمل الإعدادات الافتراضية لبرنامج PowerPoint وAspose.Slides. تصبح القيمة التي تم حلها جزءاً من البيانات الفعّالية الحالية.

**من خلال قيمة الخط الفعّال، هل يمكنني معرفة المستوى الذي قدم الحجم أو الخط؟**

ليس مباشرة. تُعيد البيانات الفعّالة القيمة النهائية فقط. لتحديد المصدر، تحقق من القيم المحلية على مستوى الجزء، الفقرة، إطار النص، وأنماط النص على مستويات التخطيط، القالب، والعرض لتحديد أول تعريف صريح.

**لماذا تبدو القيم الفعّالة أحياناً مطابقة للقيم المحلية؟**

لأن القيمة المحلية انتهت بها المطاف لتكون النهائية (لم يُستدعى مستوى أعلى للوراثة). في هذه الحالة تكون القيمة الفعّالية مطابقة للقيمة المحلية.

**متى يجب استخدام الخصائص الفعّالة، ومتى أكتفي بالخصائص المحلية؟**

استخدم البيانات الفعّالية عندما تحتاج إلى النتيجة "كما يتم عرضها" بعد تطبيق كل الوراثات، مثل محاذاة الألوان أو الهوامش أو الأحجام. إذا أردت الاحتفاظ بهذه القيم بغض النظر عن تغييرات التنسيق المستقبلية، انسخ الخصائص المطلوبة إلى كائن خاص بك. إذا كنت بحاجة إلى تعديل التنسيق على مستوى معين، عدّل الخصائص المحلية ثم، إذا لزم الأمر، اقرأ البيانات الفعّالية مرة أخرى للتحقق من النتيجة.