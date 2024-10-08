---
title: موضوع العرض
type: docs
weight: 10
url: /ar/cpp/presentation-theme/
keywords: "موضوع, موضوع باوربوينت, عرض باوربوينت, CPP, C++, Aspose.Slides for C++"
description: "موضوع عرض باوربوينت في C++"
---

يحدد موضوع العرض خصائص عناصر التصميم. عند اختيارك لموضوع العرض، فإنك تختار أساساً مجموعة محددة من العناصر المرئية وخصائصها.

في باوربوينت، يتكون الموضوع من الألوان، [الخطوط](/slides/ar/cpp/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/cpp/presentation-background/)، والتأثيرات.

![مكونات الموضوع](theme-constituents.png)

## **تغيير لون الموضوع**

يستخدم موضوع باوربوينت مجموعة محددة من الألوان لعناصر مختلفة في الشريحة. إذا كنت لا تحب الألوان، يمكنك تغييرها من خلال تطبيق ألوان جديدة على الموضوع. للسماح لك باختيار لون جديد للموضوع، توفر Aspose.Slides قيمًا تحت التعداد [SchemeColor](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

يوضح هذا الكود في C++ كيفية تغيير لون التمييز لموضوع:

```c++
auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

يمكنك تحديد القيمة الفعالة للون الناتج بهذه الطريقة:

```c++
auto fillEffective = shape->get_FillFormat()->GetEffective();
    
Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (Color [A=255, R=128, G=100, B=162])
```

لإثبات عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر وتعيين لون التمييز (من العملية الأولية) له. ثم نغير اللون في الموضوع:

```c++
auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);
    
otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

يتم تطبيق اللون الجديد تلقائياً على كلا العنصرين.

### **تعيين لون الموضوع من لوحة إضافية**

عند تطبيق تحويلات اللمعان على اللون الرئيسي للموضوع(1)، يتم تشكيل ألوان من اللوحة الإضافية(2). يمكنك بعد ذلك تعيين واسترداد تلك الألوان للموضوع.

![ألوان اللوحة الإضافية](additional-palette-colors.png)

**1**- ألوان الموضوع الرئيسية

**2** - الألوان من اللوحة الإضافية.

يوضح هذا الكود في C++ عملية حيث يتم الحصول على ألوان اللوحة الإضافية من اللون الرئيسي للموضوع ثم استخدامها في الأشكال:

```c++
auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shapes = slide->get_Shapes();

// تمييز 4
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();

fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

// تمييز 4، أفتح 80%
auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();

fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

// تمييز 4، أفتح 60%
auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();

fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

// تمييز 4، أغمق 25%
auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();

fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

// تمييز 4، أغمق 50%
auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();

fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"example.pptx", Export::SaveFormat::Pptx);
```

## **تغيير خط الموضوع**

للسماح لك باختيار الخطوط للمواضيع وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (المماثلة لتلك المستخدمة في باوربوينت):

* **+mn-lt** - خط الجسم اللاتيني (خط لاتيني ثانوي)
* **+mj-lt** - خط العنوان اللاتيني (خط لاتيني رئيسي)
* **+mn-ea** - خط الجسم شرق آسيوي (خط شرق آسيوي ثانوي)
* **+mj-ea** - خط الجسم شرق آسيوي (خط شرق آسيوي رئيسي)

يوضح هذا الكود في C++ كيفية تعيين الخط اللاتيني لعنصر الموضوع:

```c++
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"تنسيق نص الموضوع");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

يوضح هذا الكود في C++ كيفية تغيير خط موضوع العرض:

```c++
pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

سيتم تحديث الخط في جميع صناديق النص.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خطوط باوربوينت](/slides/ar/cpp/powerpoint-fonts/).

{{% /alert %}}

## **تغيير نمط خلفية الموضوع**

افتراضيًا، يوفر تطبيق باوربوينت 12 خلفية مسبقة التعريف لكن فقط 3 من تلك الخلفيات الـ 12 تُحفظ في عرض تقديمي عادي.

![todo:text_alt_image](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض تقديمي في تطبيق باوربوينت، يمكنك تشغيل هذا الكود في C++ لمعرفة عدد الخلفيات المسبقة التعريف في العرض التقديمي:

```c++
auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"عدد أنماط تعبئة الخلفية للموضوع هو {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 

من خلال استخدام الخاصية [BackgroundFillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) من فئة [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/)، يمكنك إضافة أو الوصول إلى نمط الخلفية في موضوع باوربوينت. 

{{% /alert %}}

يوضح هذا الكود في C++ كيفية تعيين الخلفية لعرض تقديمي:

```c++
pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="primary" title="نصيحة" %}} 

قد ترغب في رؤية [خلفية باوربوينت](/slides/ar/cpp/presentation-background/).

{{% /alert %}}

## **تغيير تأثير الموضوع**

يتضمن موضوع باوربوينت عادةً 3 قيم لكل مصفوفة نمط. تجمع تلك المصفوفات في هذه التأثيرات الثلاثة: خفيف، معتدل، وشديد. على سبيل المثال، هذه هي النتيجة عند تطبيق التأثيرات على شكل معين:

![todo:text_alt_image](presentation-design_10.png)

من خلال استخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563), [LineStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd), [EffectStyles](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) من فئة [FormatScheme](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_format_scheme/) يمكنك تغيير العناصر في الموضوع (بمرونة أكثر من الخيارات في باوربوينت).

يوضح هذا الكود في C++ كيفية تغيير تأثير الموضوع من خلال تغيير أجزاء من العناصر:

```c++
auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
        
pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![todo:text_alt_image](presentation-design_11.png)