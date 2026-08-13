---
title: إدارة سمات العروض التقديمية في C++
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
- العرض التقديمي
- C++
- Aspose.Slides
description: "إدارة سمات العروض التقديمية في Aspose.Slides للغة C++ لإنشاء وتخصيص وتحويل ملفات PowerPoint مع الحفاظ على هوية العلامة التجارية المتسقة."
---
## **مقدمة**

يُعرّف سمة العرض خصائص عناصر التصميم. عندما تختار سمة عرض، فأنت ببساطة تختار مجموعة محددة من العناصر البصرية وخصائصها.

في PowerPoint، تتألف السمة من الألوان، [الخطوط](/slides/ar/cpp/powerpoint-fonts/)، [أنماط الخلفية](/slides/ar/cpp/presentation-background/)، والتأثيرات.

![مكوّنات السمة](theme-constituents.png)

## **تغيير لون السمة**

تستخدم سمة PowerPoint مجموعة محددة من الألوان للعناصر المختلفة في الشريحة. إذا لم تعجبك الألوان، يمكنك تغييرها عن طريق تطبيق ألوان جديدة على السمة. لتتمكن من اختيار لون سمة جديد، توفر Aspose.Slides قيمًا تحت تعداد [SchemeColor](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_color_format#aad82c1d2daf9d92e4d44a5a9b3bbcf28).

يعرض لك هذا الشيفرة بلغة C++ كيفية تغيير لون التمييز للسمة:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
```

يمكنك تحديد القيمة الفعالة للون الناتج بهذه الطريقة:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto fillEffective = shape->get_FillFormat()->GetEffective();

Console::WriteLine(u"{0} ({1})", fillEffective->get_SolidFillColor().get_Name(), fillEffective->get_SolidFillColor());
// ff8064a2 (لون [A=255, R=128, G=100, B=162])
```

لتوضيح عملية تغيير اللون بشكل أكبر، نقوم بإنشاء عنصر آخر ونعيّن له لون التمييز (من العملية الأولية). ثم نغيّر اللون في السمة:

```c++
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>();

auto otherShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 120.0f, 100.0f, 100.0f);

otherShape->get_FillFormat()->set_FillType(FillType::Solid);
otherShape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

pres->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
```

يتم تطبيق اللون الجديد تلقائيًا على العنصرين.

### **تعيين لون السمة من لوحة ألوان إضافية**

عند تطبيق تحويلات الإضاءة على لون السمة الرئيسي(1)، تتشكل ألوان من لوحة الألوان الإضافية(2). يمكنك بعد ذلك ضبط تلك الألوان واسترجاعها.

![ألوان لوحة الألوان الإضافية](additional-palette-colors.png)

**1**- ألوان السمة الأساسية  
**2**- ألوان من لوحة الألوان الإضافية.

يعرض لك هذا الشيفرة بلغة C++ عملية الحصول على ألوان لوحة الألوان الإضافية من لون السمة الرئيسي ثم استخدامها في الأشكال:

```c++
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

عند العمل مع [SchemeColor](https://reference.aspose.com/slides/ar/cpp/aspose.slides/schemecolor/)، قد تلاحظ أنه يحتوي على القيم التالية لألوان السمة:

`Background1`، `Background2`، `Text1`، و`Text2`.

مع ذلك، تُعيد `Presentation::get_MasterTheme()::get_ColorScheme()` [IColorScheme](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/icolorscheme/)، الذي يكشف عن الألوان المقابلة كـ:

`Dark1`، `Dark2`، `Light1`، و`Light2`.

هذا الاختلاف فقط في التسمية. هذه القيم تشير إلى نفس خانات ألوان السمة والربط ثابت:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

لا توجد تحويلات ديناميكية بين `Text`/`Background` و`Dark`/`Light`. إنها مجرد أسماء بديلة لنفس ألوان السمة.

هذا الاختلاف في التسمية يأتي من مصطلحات Microsoft Office. الإصدارات القديمة من Office استخدمت `Dark 1`، `Light 1`، `Dark 2`، و`Light 2`، بينما إصدارات الواجهة الحديثة تعرض نفس الخانات كـ `Text 1`، `Background 1`، `Text 2`، و`Background 2`.

## **تغيير خط السمة**

للسماح لك باختيار الخطوط للسّمات وأغراض أخرى، تستخدم Aspose.Slides هذه المعرفات الخاصة (مشابهة لتلك المستخدمة في PowerPoint):

* **+mn‑lt** – خط النص الأساسي اللاتيني (خط لاتيني صغرى)
* **+mj‑lt** – خط العنوان اللاتيني (خط لاتيني كبرى)
* **+mn‑ea** – خط النص الأساسي شرق آسيوي (خط شرق آسيوي صغرى)
* **+mj‑ea** – خط النص الأساسي شرق آسيوي (خط شرق آسيوي كبرى)

يعرض لك هذا الشيفرة بلغة C++ كيفية تعيين الخط اللاتيني لعنصر سمة:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>();

auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);

auto paragraph = System::MakeObject<Paragraph>();
auto portion = System::MakeObject<Portion>(u"Theme text format");

paragraph->get_Portions()->Add(portion);
shape->get_TextFrame()->get_Paragraphs()->Add(paragraph);

portion->get_PortionFormat()->set_LatinFont(System::MakeObject<FontData>(u"+mn-lt"));
```

يعرض لك هذا الشيفرة بلغة C++ كيفية تغيير خط سمة العرض:

```c++
#include <DOM/Fonts/FontData.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
```

سيتم تحديث الخط في جميع صناديق النص.

{{% alert color="info" title="TIP" %}} 
قد ترغب في الاطلاع على [خطوط PowerPoint](/slides/ar/cpp/powerpoint-fonts/).
{{% /alert %}}

## **تغيير نمط خلفية السمة**

بشكل افتراضي، يوفر تطبيق PowerPoint 12 خلفية محددة مسبقًا لكن يتم حفظ 3 منها فقط في العرض النموذجي.

![todo:image_alt_text](presentation-design_8.png)

على سبيل المثال، بعد حفظ عرض في تطبيق PowerPoint، يمكنك تشغيل هذه الشيفرة بلغة C++ لمعرفة عدد الخلفيات المحددة مسبقًا في العرض:

```c++
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Theme;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");
        
int32_t numberOfBackgroundFills = pres->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles()->get_Count();

Console::WriteLine(u"Number of background fill styles for theme is {0}", numberOfBackgroundFills);
```

{{% alert color="warning" %}} 
باستخدام خاصية [BackgroundFillStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.format_scheme#aec29b94bc65619519a86a8d4607f5f7d) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme/)، يمكنك إضافة أو الوصول إلى نمط الخلفية في سمة PowerPoint. 
{{% /alert %}}

يعرض لك هذا الشيفرة بلغة C++ كيفية تعيين الخلفية لعرض:

```c++
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace System;

auto pres = MakeObject<Presentation>(u"pres.pptx");

pres->get_Masters()->idx_get(0)->get_Background()->set_StyleIndex(2);
```

**دليل الفهرس**: 0 يُستخدم لعدم التعبئة. يبدأ الفهرس من 1.

{{% alert color="info" title="TIP" %}} 
قد ترغب في الاطلاع على [خلفية PowerPoint](/slides/ar/cpp/presentation-background/).
{{% /alert %}}

## **تغيير تأثير السمة**

عادةً ما تحتوي سمة PowerPoint على 3 قيم لكل مصفوفة نمط. تُدمج تلك المصفوفات إلى هذه 3 تأثيرات: خفيف، متوسط، وشديد. على سبيل المثال، هذا هو الناتج عند تطبيق التأثيرات على شكل محدد:

![todo:image_alt_text](presentation-design_10.png)

باستخدام 3 خصائص ([FillStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme#ab80b867174104e26e4824dc8585a1563)، ([LineStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme#ae68a6d0a27dd2ada86a857ebde695ecd))، ([EffectStyles](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme#aba41300412c5c755fe82cf735bcf0f58)) من فئة [FormatScheme](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.theme.i_format_scheme/) يمكنك تغيير العناصر في سمة (بمرونة أكبر من الخيارات المتاحة في PowerPoint).

يعرض لك هذا الشيفرة بلغة C++ كيفية تغيير تأثير سمة عن طريق تعديل أجزاء من العناصر:

```c++
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto pres = System::MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");

pres->get_MasterTheme()->get_FormatScheme()->get_LineStyles()->idx_get(0)->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->set_FillType(FillType::Solid);

pres->get_MasterTheme()->get_FormatScheme()->get_FillStyles()->idx_get(2)->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

pres->get_MasterTheme()->get_FormatScheme()->get_EffectStyles()->idx_get(2)->get_EffectFormat()->get_OuterShadowEffect()->set_Distance(10.f);

pres->Save(u"Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat::Pptx);
```

التغييرات الناتجة في لون التعبئة، نوع التعبئة، تأثير الظل، إلخ:

![todo:image_alt_text](presentation-design_11.png)

## **الأسئلة الشائعة**

### هل يمكنني تطبيق سمة على شريحة واحدة دون تغيير السمة الرئيسية؟

نعم. تدعم Aspose.Slides تجاوزات سمة على مستوى الشريحة، بحيث يمكنك تطبيق سمة محلية على تلك الشريحة فقط مع الحفاظ على السمة الرئيسية دون تغيير (عبر [SlideThemeManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides.theme/slidethememanager/)).

### ما هي الطريقة الأكثر أمانًا لنقل سمة من عرض إلى آخر؟

[استنساخ الشرائح](/slides/ar/cpp/clone-slides/) مع السمة الرئيسية إلى العرض الهدف. يحافظ ذلك على السمة الأساسية، التخطيطات، والسمة المرتبطة بحيث يبقى المظهر متسقًا.

### كيف يمكنني رؤية القيم "الفعالية" بعد كل الوراثة والتجاوزات؟

استخدم العرض ["الفعالية"](/slides/ar/cpp/shape-effective-properties/) للـ سمة/اللون/الخط/التأثير. تُعيد هذه القيم الخصائص النهائية بعد تطبيق السمة الرئيسية وأي تجاوزات محلية.