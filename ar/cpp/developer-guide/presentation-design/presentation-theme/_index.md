---
title: إدارة سمات العرض التقديمي في C++
linktitle: سمة العرض التقديمي
type: docs
weight: 10
url: /ar/cpp/presentation-theme/
keywords:
- سمة PowerPoint
- سمة العرض التقديمي
- سمة الشريحة
- تعيين سمة
- تغيير سمة
- إدارة سمة
- لون السمة
- لوحة ألوان إضافية
- خط السمة
- نمط السمة
- تأثير السمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides للغة C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint بعلامة تجارية متسقة."
---
يُعرّف سمة العرض خصائص عناصر التصميم. عند اختيارك لسمة عرض، فإنك في الواقع تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكوّن السمة من ألوان، [الخطوط](/slides/ar/cpp/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/cpp/presentation-background/)، وتأثيرات.

![theme-constituents](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها بتطبيق ألوان جديدة على السمة. لتتمكن من اختيار لون سمة جديد، توفر Aspose.Slides القيم ضمن تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

يعرض هذا الكود C++ طريقة تغيير لون التمييز لسمة معينة:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

يمكنك تحديد القيمة الفعلية للون الناتج بهذه الطريقة:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (اللون [A=255, R=128, G=100, B=162])
```

للتوضيح الإضافي لعملية تغيير اللون، نقوم بإنشاء عنصر آخر ونعيّن له لون التمييز (من العملية الأولى). ثم نغيّر اللون في السمة:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

يُطبّق اللون الجديد تلقائيًا على كلا العنصرين.

### **تحديد لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي(1)، تتكوّن ألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين هذه الألوان السمية والحصول عليها.

![additional-palette-colors](additional-palette-colors.png)

**1**- ألوان السمة الرئيسية

**2**- ألوان من اللوحة الإضافية.

يعرض هذا الكود C++ عملية استخراج ألوان اللوحة الإضافية من لون السمة الرئيسي ثم استخدامها في الأشكال:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// Accent 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// Accent 4, Lighter 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// Accent 4, Lighter 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// Accent 4, Lighter 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// Accent 4, Darker 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// Accent 4, Darker 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

### **ربط `SchemeColor` بألوان `IColorScheme`**

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على قيم ألوان السمة التالية:

`Background1`، `Background2`، `Text1`، و`Text2`.

مع ذلك، `Presentation::get_MasterTheme()::get_ColorScheme()` تُعيد [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/)، التي تُظهر الألوان المقابلة كالتالي:

`Dark1`، `Dark2`، `Light1`، و`Light2`.

الاختلاف هنا في التسميات فقط. هذه القيم تشير إلى نفس خانات ألوان السمة والتطابق ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا يوجد تحويل ديناميكي بين `Text`/`Background` و`Dark`/`Light`. هي مجرد أسماء بديلة لنفس ألوان السمة.

يأتي هذا الاختلاف في التسميات من مصطلحات Microsoft Office. الإصدارات القديمة من Office استخدمت `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما الإصدارات الحديثة من الواجهة تُظهر نفس الخانات كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **تغيير خط السمة**

لتتمكن من اختيار الخطوط للسومات وغيرها من الأغراض، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط الجسم اللاتيني (خط لاتيني صغير)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني كبير)
* **+mn-ea** - خط الجسم الآسيوي الشرقي (خط آسيوي شرقي صغير)
* **+mj-ea** - خط الجسم الآسيوي الشرقي (خط آسيوي شرقي كبير)

يعرض هذا الكود C++ طريقة تعيين الخط اللاتيني لعنصر سمة:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

يعرض هذا الكود C++ طريقة تغيير خط سمة العرض:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مُعرّفة مسبقًا، ولكن يتم حفظ 3 فقط من تلك الخلفيات في عرض تقديمي نموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود C++ لمعرفة عدد الخلفيات المُعرّفة مسبقًا في العرض:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme/)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}}

يعرض هذا الكود C++ طريقة تعيين الخلفية لعرض تقديمي:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم لعدم وجود تعبئة. الفهرس يبدأ من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفيات PowerPoint](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مجموعة أنماط. تُدمج تلك المجموعات في ثلاثة تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذا هو الناتج عند تطبيق التأثيرات على شكل معين:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)، ([LineStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd))، و([EffectStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme/) يمكنك تغيير عناصر السمة (بمرونة أكبر من الخيارات المتاحة في PowerPoint).

يعرض هذا الكود C++ طريقة تغيير تأثير سمة عن طريق تعديل أجزاء من العناصر:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، وغيرها:

![todo:image_alt_text](presentation-design_11.png)

## **الأسئلة الشائعة**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير السمة الرئيسية؟**

نعم. تدعم Aspose.Slides تجاوز السمة على مستوى الشريحة، لذا يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على السمة الرئيسية دون تعديل (عبر [SlideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**

استخدام [نسخ الشرائح](/slides/ar/cpp/clone-slides/) مع الماستر الخاص بها إلى العرض الهدف. هذا يحافظ على الماستر الأصلي، التخطيطات، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد كل الوراثة والتجاوزات؟**

استخدم واجهات برمجة التطبيقات للعرض ["الفعّال"](/slides/ar/cpp/shape-effective-properties/) للسمة/اللون/الخط/التأثير. هذه تُعيد الخصائص النهائية المحسوبة بعد تطبيق الماستر وأي تجاوزات محلية.