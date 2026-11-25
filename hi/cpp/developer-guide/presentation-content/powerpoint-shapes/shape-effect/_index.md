---
title: C++ का उपयोग करके प्रस्तुतियों में आकार प्रभाव लागू करें
linktitle: आकार प्रभाव
type: docs
weight: 30
url: /hi/cpp/shape-effect/
keywords:
- आकार प्रभाव
- छाया प्रभाव
- परावर्तन प्रभाव
- ग्लो प्रभाव
- नरम किनारों का प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके उन्नत आकार प्रभावों के साथ अपने PPT और PPTX फ़ाइलों को बदलें — सेकंडों में प्रभावशाली, पेशेवर स्लाइड्स बनाएं।"
---
## **परिचय**

PowerPoint में प्रभावों का उपयोग किसी आकार को प्रमुख बनाने के लिए किया जा सकता है, ये [फ़िल्स](/slides/hi/cpp/shape-formatting/#gradient-fill) या रूपरेखाओं से अलग होते हैं। PowerPoint प्रभावों के उपयोग से आप आकार पर विश्वसनीय परावर्तन बना सकते हैं, आकार की चमक फैलाना आदि कर सकते हैं।

![आकार प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकारों पर लागू किया जा सकता है। आप एक या अधिक प्रभाव किसी आकार पर लागू कर सकते हैं।

कुछ प्रभावों के संयोजन अन्य की तुलना में बेहतर दिखते हैं। इसलिए PowerPoint में **Preset** विकल्प होते हैं। प्रीसेट विकल्प मूलतः दो या अधिक प्रभावों का ऐसा संयोजन होते हैं जिनका मिलकर अच्छा परिणाम होता है। इस तरह, प्रीसेट चुनकर आपको विभिन्न प्रभावों को आज़माने या संयोजित करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) क्लास के तहत गुण और विधियाँ प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for C++ आकारों के लिए बाहरी और आंतरिक छायाओं को समर्थन देता है। आप उनके रंग, दिशा, दूरी और ब्लर त्रिज्या को अपनी प्रस्तुति के डिज़ाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

एक बाहरी छाया का उपयोग करके कार्ड या पैनल को स्लाइड पृष्ठभूमि के विरुद्ध प्रमुख बनाएँ। छाया आकार की किनारों से बाहर तक विस्तारित होती है, जिससे ऐसा प्रभाव मिलता है कि आकार स्लाइड के ऊपर उठाया गया है। रंग, दिशा, दूरी और ब्लर त्रिज्या को अपने टेम्पलेट की प्रकाश और शैली से मिलाने के लिए समायोजित करें।

यह C++ कोड दिखाता है कि कैसे एक आयत पर [बाहरी छाया प्रभाव](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) लागू किया जाए:

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

### **आंतरिक छाया लागू करें**

जब आप टेम्पलेट की दृश्य शैली को दोहराते हैं, तो कार्ड या पैनल को अंदर की ओर गड़ाए हुए दिखाने के लिए आंतरिक छाया का उपयोग करें। एक बाहरी छाया आकार के बाहर विस्तारित होती है और इसे उठी हुई दिखाती है, जबकि आंतरिक छाया किनारों के अंदर हिस्से को शेड करती है।

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) को कॉल करें, फिर [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) को कॉन्फ़िगर करें। बड़ी ब्लर त्रिज्या मान धीरे‑धीरे किनारों को नरम बनाते हैं।

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

आंतरिक छाया को हटाने के लिए, आकार के इफ़ेक्ट फ़ॉर्मेट पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

### **प्रीसेट छाया लागू करें, बदलें और हटाएँ**

[EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) को कॉल करें और [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/) का उपयोग करके एक [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/) चुनें। शैलियों को बदलने के लिए, उसी आकार पर प्रीसेट को बदलें। छाया को हटाने के लिए लेकिन फ़िल और रूपरेखा को बरकरार रखने हेतु, [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/) को कॉल करें।

यह उदाहरण प्रत्येक चरण पर आयत की एक प्रति रखता है। दोनों छायाएँ 10 पॉइंट से ऑफ़सेट हैं। 225° की दिशा पहली छाया को आयत के ऊपर और बाएँ रखती है, जबकि 45° की दिशा दूसरी छाया को नीचे और दाएँ रखती है।

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
| ![कोई छाया नहीं](preset_shadow_original.png) | ![ऊपरी बायाँ ड्रॉप शैडो](preset_shadow_top_left.png) | ![निचला दायाँ ड्रॉप शैडो](preset_shadow_bottom_right.png) | ![हटाने के बाद कोई छाया नहीं](preset_shadow_removed.png) |

## **परावर्तन प्रभाव लागू करें**

Aspose.Slides for C++ में परावर्तन प्रभाव लागू करने के लिए आप आकारों पर दर्पण जैसी परावर्तन जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपकी प्रस्तुतियों की सुंदरता को बढ़ाता है, आकारों को अधिक परिष्कृत और आकर्षक बनाता है। यह सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर सुसंगत डिज़ाइन के लिए शीघ्रता से लागू किया जा सके।

यह C++ कोड दिखाता है कि कैसे एक आकार पर [परावर्तन प्रभाव](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) लागू किया जाए:

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

![परावर्तन प्रभाव](reflection_effect.png)

## **ग्लो प्रभाव लागू करें**

Aspose.Slides for C++ में आकार पर ग्लो प्रभाव लागू करने के लिए आप आकारों के चारों ओर एक मुलायम, चमकीला आभा जोड़ सकते हैं, रंग और आकार जैसी गुणों को समायोजित कर सकते हैं। यह प्रभाव आकारों को प्रमुख बनाता है और आपकी प्रस्तुति में आकर्षक, आंखें पकड़ने वाला दृश्य तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे आपके स्लाइड्स का समग्र रूप सुधरता है।

यह C++ कोड दिखाता है कि कैसे एक आकार पर [ग्लो प्रभाव](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) लागू किया जाए:

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

## **सॉफ्ट एजेज़ प्रभाव लागू करें**

Aspose.Slides for C++ में सॉफ्ट एजेज़ प्रभाव लागू करने के लिए आप आकार के किनारों के आसपास एक स्मूद, ब्लर ट्रांज़िशन बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, वह जैसे डिज़ाइन को हल्का और नरम दिखाना चाहते हैं। आप विभिन्न आकारों में वांछित प्रभाव प्राप्त करने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह C++ कोड दिखाता है कि कैसे एक आकार पर [सॉफ्ट एजेज़](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) लागू किया जाए:

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

![सॉफ्ट एजेज़ प्रभाव](soft_edges_effect.png)

## **ब्लर प्रभाव लागू करें**

Shape blur का उपयोग करके आप आकार की फ़िल और रूपरेखा को मुलायम बना सकते हैं जबकि आकार संपादन योग्य बना रहता है। आकार के इफ़ेक्ट फ़ॉर्मेट पर [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) को कॉल करें। त्रिज्या पॉइंट में मापी जाती है (1/72 इंच): एक गैर‑नकारात्मक मान उपयोग करें, बड़ी मान अधिक तीव्र ब्लर उत्पन्न करेंगे। शून्य त्रिज्या होने पर रूप बदलता नहीं है।

[Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) सेटिंग प्रभाव की दृश्यमान सीमा को नियंत्रित करती है। `false` होने पर ब्लर मूल पेंटेड सीमा तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `true` होने पर ब्लर इन सीमाओं से बाहर तक फैल सकता है। दोनों ही स्थितियों में आकार की स्थिति या आयाम नहीं बदलते।

नीचे का तुलना समान फ़िल, रूपरेखा और आकार आयामों के साथ किया गया है। शीर्ष पंक्ति में `grow = false`; निचली पंक्ति में `grow = true` है।

![मूल आयत बनाम 5 और 15 पॉइंट ब्लर रेडियस, ग्रो अक्षम और सक्षम](shape_blur_comparison.png)

यह C++ उदाहरण नारंगी आयत को गहरी नीली रूपरेखा के साथ बनाता है, 5‑पॉइंट ब्लर लागू करता है, फिर फिर से [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) को कॉल करके 15‑पॉइंट ब्लर पर अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) को कॉल करके बिना ब्लर के आकार को सहेजता है।

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

Shape blur फ़िल और रूपरेखा को साथ‑साथ प्रभावित करता है। सॉफ्ट एजेज़ प्रभाव आकार के किनारों को फीका करता है, जबकि शैडो ब्लर केवल छाया को नरम करता है। इमेज ट्रांसफ़ॉर्मेशन प्रभाव इमेज कंटेंट पर कार्य करते हैं; यह उदाहरण आकार को इमेज में बदलें बिना सीधे आकार के इफ़ेक्ट फ़ॉर्मेट पर ब्लर लागू करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई प्रभाव लागू कर सकता हूँ?**  
हाँ, आप एक ही आकार पर विभिन्न प्रभाव जैसे छाया, परावर्तन और ग्लो को मिलाकर अधिक गतिशील दिखावट बना सकते हैं।

**मैं किन आकारों पर प्रभाव लागू कर सकता हूँ?**  
आप विभिन्न आकारों पर प्रभाव लागू कर सकते हैं, जिनमें ऑटोशेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट और अधिक शामिल हैं।

**क्या मैं समूहित आकारों पर प्रभाव लागू कर सकता हूँ?**  
हाँ, आप समूहित आकारों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।