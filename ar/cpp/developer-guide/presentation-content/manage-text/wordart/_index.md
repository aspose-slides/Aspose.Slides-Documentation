---
title: "إنشاء وتطبيق تأثيرات WordArt في C++"
linktitle: WordArt
type: docs
weight: 110
url: /ar/cpp/wordart/
keywords:
- WordArt
- إنشاء WordArt
- قالب WordArt
- تأثير WordArt
- تأثير الظل
- تأثير الانعكاس
- تأثير التوهج
- تحويل WordArt
- تأثير ثلاثي الأبعاد
- تأثير الظل الخارجي
- تأثير الظل الداخلي
- C++
- Aspose.Slides
description: "إنشاء وتخصيص تأثيرات WordArt في Aspose.Slides للغة C++. يقدّم هذا الدليل خطوة بخطوة لمساعدة المطورين على تحسين العروض التقديمية بنص احترافي باستخدام C++."
---
## **نظرة عامة**

تمكنك تأثيرات WordArt من تنسيق النص باستخدام التعبئات والحدود والظلال والانعكاسات والتوهج والتحويلات وتنسيق ثلاثي الأبعاد. تشرح هذه المقالة كيفية إنشاء وتخصيص هذه التأثيرات في عروض PowerPoint باستخدام Aspose.Slides للـ C++، دون الحاجة إلى تثبيت Microsoft Office.

## **إنشاء قالب WordArt بسيط وتطبيقه على النص**

الأمثلة التالية تنشئ نمط WordArt بسيط عن طريق تعيين النص والخط وتعبئة النمط والحد.

كل مثال ينشئ عرض تقديمي جديد ويضيف مستطيلاً إلى الشريحة الأولى؛ لا يلزم ملف إدخال. المثال الأول يضبط النص على "Aspose.Slides". يتم قياس موضع الشكل وأبعاده بالنقاط:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

قم بتعيين الخط إلى Arial Black بحجم 36 نقطة لجعل التنسيق أكثر وضوحًا:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

طبق نمط [SmallGrid](https://reference.aspose.com/slides/ar/cpp/aspose.slides/patternstyle/) بلون أمامي برتقالي غامق وخلفية بيضاء، ثم أضف حدًا للنص باللون الأسود بعرض نقطة واحدة:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IPatternFormat.h>
#include <DOM/PatternStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

portion->get_PortionFormat()->get_LineFormat()->set_Width(1);
auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

النص الناتج:

![قالب WordArt البسيط](WordArt_template.png)

## **تطبيق تأثيرات WordArt الأخرى**

توضح الأمثلة التالية كيفية تطبيق الظلال والانعكاسات والتوهج والتحويلات والتأثيرات ثلاثية الأبعاد على النص.

### **تطبيق تأثيرات الظل الخارجي**

يضيف الظل الخارجي عمقًا عن طريق وضع ظل خلف النص. يمكنك تخصيص لونه، واتجاهه، والمسافة، ونصف قطر التمويه، والقياس، والانحراف.

تستدعي هذه المثال [EnableOuterShadowEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ieffectformat/enableoutershadoweffect/) وتضبط ظلًا أسود نصف قطر تمويه 4 نقاط، باتجاه 230 درجة، والمسافة 30 نقطة. قيم القياس 100 تحافظ على حجم الظل، بينما الانحراف الأفقي يميل الظل بزاوية 20 درجة. يضبط تحويل ألفا شفافيته إلى 32٪:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(100);
outerShadowEffect->set_BlurRadius(4);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(30);
outerShadowEffect->set_SkewHorizontal(20);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

النص الناتج:

![تأثير الظل الخارجي](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- عندما يتم استخدام الظل الخارجي والظلال المسبقة معًا، يُطبق الظل الخارجي فقط.
- إذا تم استخدام الظل الخارجي والظل الداخلي في آنٍ واحد، يعتمد التأثير الناتج على إصدار PowerPoint. على سبيل المثال، في PowerPoint 2013 يُضاعف التأثير، بينما في PowerPoint 2007 يُطبق الظل الخارجي فقط.
{{% /alert %}}

### **تطبيق تأثيرات الانعكاس**

يُنشئ الانعكاس نسخةً مرآةً من النص. قم بضبط موضعه، ومعاييره، والتمويه، والشفافية للتحكم في مظهره.

تستدعي هذه المثال [EnableReflectionEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ieffectformat/enablereflectioneffect/) وتقلب الانعكاس عموديًا بمقياس -100٪. يستخدم نصف قطر تمويه 0.5 نقطة ومسافة 4.72 نقطة. تنخفض الشفافية من 60٪ إلى 0.9٪ بين الموضعين 0٪ و60٪ على طول الانعكاس:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

النص الناتج:

![تأثير الانعكاس](reflection_effect.png)

### **تطبيق تأثيرات التوهج**

يضيف التوهج حدًا ملونًا ناعمًا حول النص. اضبط لونه، وشفافيته، ونصف قطره للتحكم في التأثير.

تستدعي هذه المثال [EnableGlowEffect](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ieffectformat/enablegloweffect/) وتطبق توهجًا أحمر بشفافية 54٪ ونصف قطر 7 نقاط:

```cpp
#include <drawing/color.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/ColorTransformOperation.h>
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");

auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);

auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Red());
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

النص الناتج:

![تأثير التوهج](glow_effect.png)

### **تطبيق تحويلات WordArt**

تحويلات WordArt تقوم بثني أو تمديد أو تشويه كتلة النص.

قم بتعيين [ITextFrameFormat::set_Transform](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/set_transform/) إلى [ArchUpPour](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textshapetype/) لتقوس إطار النص بالكامل إلى الأعلى:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextShapeType.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

النص الناتج:

![تحويل WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides for C++ يوفر مجموعة من [أنواع التحويل المعرّفة مسبقًا](https://reference.aspose.com/slides/ar/cpp/aspose.slides/textshapetype/).
{{% /alert %}}

### **تطبيق تأثيرات ثلاثية الأبعاد على الأشكال والنص**

يمكنك تطبيق تأثيرات ثلاثية الأبعاد على شكل أو على نصه. تتحكم الحواف المائلة (Bevels)، والاختلاط (extrusion)، والإضاءة، وإعدادات الكاميرا في المظهر الناتج.

تستخدم المثال التالي [IThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/) لإضافة حواف مائلة دائرية، وااختلاط برتقالي، وحدود حمراء داكنة إلى المستطيل. تُقاس أبعاد الحافة، وارتفاع الاختلاط، وعرض الحد، والعمق بالنقاط. مادة بلاستيكية، إضاءة متوازنة تدور 40 درجة حول محور Z، وكاميرا منظور تحدد مظهره:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);
autoShape->get_TextFrame()->set_Text(u"Aspose.Slides");

auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

الشكل الناتج:

![تأثير الشكل ثلاثي الأبعاد](shape_3D_effect.png)

يطبق هذا المثال تنسيقًا ثلاثيًا أبعادًا مماثلاً على النص عبر [ITextFrameFormat::get_ThreeDFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itextframeformat/get_threedformat/). تشكل الحواف الصغيرة حواف الأحرف، بينما يمنح الاختلاط والإضاءة النص عمقًا:

```cpp
#include <DOM/BevelPresetType.h>
#include <DOM/CameraPresetType.h>
#include <DOM/IAutoShape.h>
#include <DOM/ICamera.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILightRig.h>
#include <DOM/IShapeBevel.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/LightRigPresetType.h>
#include <DOM/LightingDirection.h>
#include <DOM/MaterialPresetType.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 400.0f, 200.0f);

auto textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"Aspose.Slides");

auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

النص الناتج:

![تأثير النص ثلاثي الأبعاد](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
تطبيق تأثيرات ثلاثية الأبعاد على النص أو أشكاله — والتفاعل بين هذه التأثيرات — يخضع لقواعد محددة. ضع في الاعتبار مشهدًا يشمل النص والشكل الذي يحتويه. يتضمن التأثير ثلاثي الأبعاد تمثيلًا ثلاثيًا للعنصر والمشهد الذي يُوضع فيه.

- إذا تم تعيين مشهد لكل من الشكل والنص، يكون مشهد الشكل هو الأولوية ويتم تجاهل مشهد النص.
- إذا كان الشكل لا يملك مشهدًا خاصًا ولكنه يمتلك تمثيلًا ثلاثيًا، يُستخدم مشهد النص.
- إذا لم يكن لدى الشكل أي تأثير ثلاثي الأبعاد، يُعامل كمسطح، ويُطبق التأثير ثلاثي الأبعاد فقط على النص.

هذه السلوكيات تتعلق بطرق [IThreeDFormat::get_LightRig](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_lightrig/) و[IThreeDFormat::get_Camera](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ithreedformat/get_camera/).
{{% /alert %}}

للحفاظ على النص مسطحًا وقابلًا للقراءة مع الاحتفاظ بتنسيق الشكل ثلاثي الأبعاد، راجع [Keep Text Flat on a 3D Shape](/slides/ar/cpp/3d-presentation/) للمقارنة بين الإعدادين ومثال C++ كامل.

## **الأسئلة الشائعة**

**هل يمكنني استخدام تأثيرات WordArt مع خطوط أو أنظمة كتابة مختلفة (مثل العربية، الصينية)؟**

نعم، يدعم Aspose.Slides للـ C++ Unicode ويعمل مع جميع الخطوط والأنظمة الكتابية الرئيسية. يمكن تطبيق تأثيرات WordArt مثل الظل، التعبئة، والحد على أي لغة، على الرغم من أن توفر الخطوط وعرضها قد يعتمد على خطوط النظام.

**هل يمكنني تطبيق تأثيرات WordArt على عناصر شريحة الرئيس (master)؟**

نعم، يمكنك تطبيق تأثيرات WordArt على الأشكال في شرائح الرئيس، بما في ذلك عناصر العنونة، التذييل، أو النص الخلفي. ستنعكس التغييرات التي تُجرى على تخطيط الرئيس عبر جميع الشرائح المرتبطة.

**هل تؤثر تأثيرات WordArt على حجم ملف العرض التقديمي؟**

قليلًا. قد تزيد تأثيرات WordArt مثل الظلال، التوهجات، وتعبئات التدرج حجم الملف قليلًا بسبب إضافة بيانات التنسيق الوصفية، لكن الفرق عادةً ما يكون ضئيلًا.

**هل يمكنني معاينة نتيجة تأثيرات WordArt دون حفظ العرض التقديمي؟**

نعم، يمكنك تصيير الشرائح التي تحتوي على WordArt إلى صور (مثل PNG، JPEG) باستخدام [ISlide::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islide/getimage/)، أو تصيير الأشكال الفردية باستخدام [IShape::GetImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/getimage/). يتيح لك ذلك معاينة النتيجة في الذاكرة أو على الشاشة قبل حفظ أو تصدير العرض الكامل.