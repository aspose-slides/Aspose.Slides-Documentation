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
description: "إتقان سمات العرض التقديمي في Aspose.Slides لـ C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint مع علامة تجارية متسقة."
---

تعرف سمة العرض التقديمي خصائص عناصر التصميم. عند اختيارك لسمة عرض تقديمي، فإنك في الواقع تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتكون السمة من ألوان، [الخطوط](/slides/ar/cpp/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/cpp/presentation-background/)، وتأثيرات.

![مكونات السمة](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان لعناصر مختلفة على الشريحة. إذا لم تعجبك الألوان، يمكنك تعديلها بتطبيق ألوان جديدة للسمة. للسماح لك باختيار لون سمة جديد، توفر Aspose.Slides قيمًا تحت تعداد [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```


يمكنك تحديد القيمة الفعّالة للون الناتج بهذه الطريقة:
```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (اللون [A=255, R=128, G=100, B=162])
```


لتوضيح عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونُعيّن له لون التميز (من العملية الأولية). ثم نغيّر اللون في السمة:
```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```


يُطبّق اللون الجديد تلقائيًا على كلا العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحولات الإضاءة على لون السمة الرئيسي(1)، يتكوّن ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك تعيين هذه الألوان واستخراجها.

![ألوان لوحة الألوان الإضافية](additional-palette-colors.png)

**1**- ألوان السمة الرئيسية  
**2**- ألوان من لوحة الألوان الإضافية.

يُظهر هذا الكود C++ عملية الحصول على ألوان اللوحة الإضافية من لون السمة الرئيسي ثم استخدامها في الأشكال:
```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// التمييز 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// التمييز 4، أخف 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// التمييز 4، أخف 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// التمييز 4، أخف 40%
auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();

fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

// التمييز 4، أغمق 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// التمييز 4، أغمق 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```


## **تغيير خط السمة**

لسماحك باختيار الخطوط للسمة ولأغراض أخرى، تستخدم Aspose.Slides هذه المعرّفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn-lt** - خط النص الأساسي اللاتيني (خط لاتيني فرعي)
* **+mj-lt** - خط عنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط النص الأساسي للغة شرق آسيا (خط شرق آسيوي فرعي)
* **+mj-ea** - خط النص الأساسي للغة شرق آسيا (خط شرق آسيوي رئيسي)

يُظهر هذا الكود C++ كيفية تعيين الخط اللاتيني لعناصر السمة:
```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```


يُظهر هذا الكود C++ كيفية تغيير خط سمة العرض التقديمي:
```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```


سيتم تحديث الخط في جميع مربعات النص.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية مُعرّفة سلفًا، لكن يتم حفظ 3 منها فقط في عرض تقديمي عادي.

![تصميم العرض](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق PowerPoint، يمكنك تشغيل هذا الكود C++ لمعرفة عدد الخلفيات المُعرّفة مسبقًا في العرض:
```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```


{{% alert color="warning" %}} 
باستخدام الخاصية [BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) من فئة [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}}

يُظهر هذا الكود C++ كيفية تعيين الخلفية للعرض التقديمي:
```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```


**دليل الفهرس**: يُستخدم 0 لعدم وجود تعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج هذه المصفوفات لتكوّن هذه التأثيرات الثلاثة: خفيف، متوسط، وشديد. على سبيل المثال، هذه هي النتيجة عندما تُطبّق التأثيرات على شكل معين:

![تأثير السمة](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) من فئة [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) يمكنك تغيير العناصر في السمة (بمرونة أكبر من الخيارات المتاحة في PowerPoint).

يُظهر هذا الكود C++ كيفية تغيير تأثير سمة عن طريق تعديل أجزاء من العناصر:
```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```


التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![النتيجة](presentation-design_11.png)

## **FAQ**

**هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير القالب الرئيسي؟**  
نعم. يدعم Aspose.Slides تجاوزات السمة على مستوى الشريحة، بحيث يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على السمة الرئيسية دون تعديل (من خلال [SlideThemeManager](https://reference.aspose.com/slides/cpp/aspose.slides.theme/slidethememanager/)).

**ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض تقديمي إلى آخر؟**  
استخدم [Clone slides](/slides/ar/cpp/clone-slides/) مع القالب الخاص بها إلى العرض المستهدف. هذا يحافظ على القالب الأصلي والتخطيطات والسمة المرتبطة بحيث يبقى الشكل متسقًا.

**كيف يمكنني رؤية القيم "الفعّالة" بعد جميع الوراثة والتجاوزات؟**  
استخدم طرق الـ API لـ "العروض الفعّالة" [/slides/cpp/shape-effective-properties/] للثيم/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية التي تم حلها بعد تطبيق القالب وأي تجاوزات محلية.