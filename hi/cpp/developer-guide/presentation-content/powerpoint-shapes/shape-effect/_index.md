---
title: C++ का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/cpp/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- ग्लो प्रभाव
- नरम किनारे प्रभाव
- इफ़ेक्ट फ़ॉर्मेट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को परिवर्तित करें — सेकंड में प्रभावशाली, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, वे [भरण](/slides/hi/cpp/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint प्रभावों का उपयोग करके आप किसी आकार पर विश्वसनीय प्रतिबिंब, आकार की चमक आदि बना सकते हैं।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक आकार पर एक या अधिक प्रभाव लागू कर सकते हैं।

कुछ प्रभाव संयोजन दूसरों की तुलना में बेहतर दिखते हैं। इसी कारण से, PowerPoint में **Preset** के तहत विकल्प होते हैं। Preset विकल्प मूलतः दो या अधिक प्रभावों के ऐसे संयोजन होते हैं जो साथ में अच्छे दिखते हैं। इस प्रकार, प्रीसेट चुनकर आपको विभिन्न प्रभावों का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) क्लास के अंतर्गत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देता है।

## **छाया प्रभाव लागू करें**

Aspose.Slides for C++ आकारों के लिए बाहरी और आंतरिक छायाएँ समर्थन करता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड पृष्ठभूमि के खिलाफ कार्ड या पैनल को प्रमुख बनाने के लिए बाहरी छाया का उपयोग करें। छाया आकार के किनारों से बाहर तक विस्तृत होती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड के ऊपर उठाया गया है। अपने टेम्पलेट की प्रकाश व्यवस्था और शैली के अनुसार इसका रंग, दिशा, दूरी और ब्लर त्रिज्या समायोजित करें।

This C++ code shows how to apply the [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) to a rectangle:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![छाया प्रभाव](shadow_effect.png)

#### **जब आकार घुमता है तो छाया की दिशा नियंत्रित करें**

डिफ़ॉल्ट रूप से, बाहरी छाया अपने आकार के साथ घूमती है। विभिन्न घूर्णनों वाले आकारों को समान दिशा से प्रकाशित दिखाने के लिए, [set_RotateShadowWithShape](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_rotateshadowwithshape/) को `false` के साथ कॉल करें और उनकी छायाओं को समान कोण देने के लिए [set_Direction](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ioutershadow/set_direction/) का उपयोग करें।

यह उदाहरण दो तीर बनाता है जिनकी ग्रे छायाएँ दाएं (0°) की ओर ऑफ़सेट होती हैं। फिर यह स्लाइड को डुप्लिकेट करता है और दोनों तीरों को 90° घंटे की दिशा में घुमाता है।

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto before = presentation->get_Slide(0);

auto left = before->get_Shapes()->AddAutoShape(ShapeType::RightArrow, 55, 130, 110, 60);
left->get_FillFormat()->set_FillType(FillType::Solid);
left->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
left->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

left->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = left->get_EffectFormat()->get_OuterShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_Gray());
shadow->set_Direction(0);
shadow->set_Distance(42);
shadow->set_BlurRadius(0);
shadow->set_RotateShadowWithShape(true);

auto right = before->get_Shapes()->AddClone(left);
right->set_X(395);
right->get_EffectFormat()->get_OuterShadowEffect()->set_RotateShadowWithShape(false);

auto after = presentation->get_Slides()->AddClone(before);
for (auto i = 0; i < after->get_Shapes()->get_Count(); ++i)
{
    after->get_Shape(i)->set_Rotation(90);
}

presentation->Save(u"arrow_shadows.pptx", SaveFormat::Pptx);
```

दूसरी स्लाइड पर, बायें तीर की छाया नीचे की ओर गिरती है, जबकि दायें तीर की छाया अभी भी दाएं की ओर गिरती है। दोनों छायाओं के लिए कॉन्फ़िगर की गई दिशा 0° बनी रहती है।

![90° घूर्णन से पहले और बाद में PowerPoint रेंडरिंग। दोनों छायाएँ दाएं से शुरू होती हैं। घूर्णन के बाद, छाया बायें तीर के नीचे चली जाती है और दायें तीर के दाएं बनी रहती है।](arrow-shadow-rotation.png)

### **आंतरिक छाया लागू करें**

जब टेम्पलेट की दृश्य शैली को दोहराते हैं, तो कार्ड या पैनल को अवसादित रूप देने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर विस्तारित होती है और इसे उभरा दिखाती है, जबकि आंतरिक छाया इसके किनारों के अंदर को छाया देती है।

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) को कॉल करें, फिर [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान नरम किनारे उत्पन्न करते हैं।

यह C++ उदाहरण हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![आंतरिक छाया के साथ हल्का नीला आयत](inner_shadow_effect.png)

आंतरिक छाया हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें और हटाएं**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) को कॉल करें और [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) का उपयोग करके [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) चुनें। शैली बदलने के लिए, समान आकार पर प्रीसेट बदलें। छाया को हटाने के लिए जबकि भराव और रूपरेखा बरकरार रहे, [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) को कॉल करें।

यह उदाहरण प्रत्येक चरण में आयत की एक प्रति रखता है। दोनों छायाएँ 10 पॉइंट ऑफ़सेट हैं। 225° की दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, और 45° दूसरी को नीचे और दाएँ रखती है।

```cpp
#include <DOM/Effects/IPresetShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/PresetShadowType.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/enum.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(800, 120, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
auto outline = shape->get_LineFormat()->get_FillFormat();
outline->set_FillType(FillType::Solid);
outline->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
auto textFrame = shape->get_TextFrame();
textFrame->set_Text(u"No shadow");
textFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(14);
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnablePresetShadowEffect();
auto shadow = effectFormat->get_PresetShadowEffect();
shadow->set_Preset(PresetShadowType::TopLeftDropShadow);
shadow->set_Distance(10);
shadow->set_Direction(225);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
shadow->set_Preset(PresetShadowType::BottomRightDropShadow);
shadow->set_Direction(45);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
effectFormat->DisablePresetShadowEffect();
textFrame->set_Text(u"No shadow");

presentation->Save(u"preset_shadows.pptx", SaveFormat::Pptx);
```

| मूल | पहला प्रीसेट | दूसरा प्रीसेट | हटाने के बाद |
| :---: | :---: | :---: | :---: |
| ![कोई छाया नहीं](preset_shadow_original.png) | ![TopLeftDropShadow](preset_shadow_top_left.png) | ![BottomRightDropShadow](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for C++ में प्रतिबिंब प्रभाव लागू करने के लिए, आप आकारों में दर्पण जैसी प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित करके। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बेहतर बनाता है, आकारों को अधिक चमकदार और परिष्कृत रूप देता है। सरल कोड के साथ इसे लागू करना आसान है, जिससे कई तत्वों पर निरंतर डिज़ाइन के लिए शीघ्र लागू किया जा सकता है।

यह C++ कोड दिखाता है कि कैसे [प्रतिबिंब प्रभाव](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) को आकार पर लागू किया जाए:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![प्रतिबिंब प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for C++ में आकार पर ग्लो प्रभाव लागू करने के लिए, आप आकारों के आसपास एक मुलायम, प्रकाशमान आभा जोड़ सकते हैं, रंग और आकार जैसी विशेषताओं को समायोजित करके। यह प्रभाव आकारों को प्रमुख बनाता है और आपके प्रस्तुतिकरण में एक आकर्षक, दृष्टिगोचर दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे आपकी स्लाइड्स की समग्र दृश्यता बढ़ती है।

यह C++ कोड दिखाता है कि कैसे [ग्लो प्रभाव](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) को आकार पर लागू किया जाए:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![ग्लो प्रभाव](glow_effect.png)

## **सॉफ्ट एजेस प्रभाव लागू करें**

Aspose.Slides for C++ में सॉफ्ट एजेस प्रभाव लागू करने के लिए, आप आकार के किनारों के आसपास एक सुगम, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो हल्की, कोमल उपस्थिति की आवश्यकता वाले डिज़ाइन के लिए उपयुक्त है। आप अपनी प्रस्तुति में विभिन्न आकारों पर वांछित प्रभाव प्राप्त करने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह C++ कोड दिखाता है कि कैसे [सॉफ्ट एजेस](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) को आकार पर लागू किया जाए:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![सॉफ्ट एजेस प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

आकार ब्लर का उपयोग करके आकार की भराव और रूपरेखा को कोमल बनाएं जबकि आकार को संपादन योग्य रखें। आकार के इफ़ेक्ट फ़ॉर्मेट पर [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): एक गैर-नकारात्मक मान उपयोग करें, बड़े मान अधिक तीव्र ब्लर उत्पन्न करेंगे। शून्य त्रिज्या दिखावट को जैसा है वैसा ही छोड़ देती है।

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` के साथ, ब्लर मूल पेंटेड सीमा तक सीमित रहता है, जिसमें रूपरेखा शामिल है। `true` के साथ, ब्लर उन सीमाओं से बाहर भी जा सकता है। कोई भी सेटिंग आकार की स्थिति या आयाम नहीं बदलती।

नीचे का तुलना समान भराव, रूपरेखा और आकार आयामों का उपयोग करती है। शीर्ष पंक्ति में `grow = false` है; नीचे की पंक्ति में `grow = true` है।

![ब्लर त्रिज्या 5 और 15 पॉइंट के साथ मूल आयत, grow अक्षम और सक्षम स्थिति में तुलना](shape_blur_comparison.png)

यह C++ उदाहरण नारंगी आयत को गहरे नीले रूपरेखा के साथ बनाता है, 5 पॉइंट ब्लर लागू करता है, और फिर फिर से [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) को कॉल करके 15 पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) को कॉल करके ब्लर के बिना आकार को सहेजता है।

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

आकार ब्लर भराव और रूपरेखा को साथ में प्रभावित करता है। सॉफ्ट एजेस प्रभाव आकार के किनारों को धुंधला करता है, जबकि शैडो ब्लर केवल छाया को कोमल बनाता है। इमेज ट्रांसफ़ॉर्मेशन प्रभाव छवि सामग्री पर कार्य करता है; यह उदाहरण आकार को इमेज में बदलने के बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**

हाँ, आप एक ही आकार पर विभिन्न प्रभावों जैसे छाया, प्रतिबिंब और ग्लो को मिलाकर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जैसे ऑटोशेप्स, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट्स, OLE ऑब्जेक्ट्स, आदि।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरे समूह पर लागू होगा।