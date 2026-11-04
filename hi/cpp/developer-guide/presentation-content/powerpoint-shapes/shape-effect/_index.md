---
title: C++ का उपयोग करके प्रस्तुतीकरण में आकार इफ़ेक्ट लागू करें
linktitle: आकार इफ़ेक्ट
type: docs
weight: 30
url: /hi/cpp/shape-effect/
keywords:
- आकार इफ़ेक्ट
- छाया इफ़ेक्ट
- परावर्तन इफ़ेक्ट
- चमक इफ़ेक्ट
- नरम किनारे इफ़ेक्ट
- इफ़ेक्ट फॉर्मेट
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके उन्नत आकार इफ़ेक्ट्स के साथ अपने PPT और PPTX फ़ाइलों को बदलें — कुछ सेकंड में आकर्षक, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

PowerPoint में इफ़ेक्ट्स का उपयोग किसी आकार को उभारा जा सकता है, लेकिन वे [भराव](/slides/hi/cpp/shape-formatting/#gradient-fill) या outlines से अलग होते हैं। PowerPoint इफ़ेक्ट्स का उपयोग करके, आप किसी आकार पर विश्वसनीय परावर्तन बना सकते हैं, आकार की चमक फैला सकते हैं, आदि।

![आकार इफ़ेक्ट](shape-effect.png)

PowerPoint आकारों पर लागू किए जा सकने वाले छह इफ़ेक्ट्स प्रदान करता है। आप किसी आकार पर एक या अधिक इफ़ेक्ट्स लागू कर सकते हैं।

कुछ इफ़ेक्ट संयोजन दूसरों से बेहतर दिखते हैं। इस कारण से, PowerPoint में **Preset** के तहत विकल्प होते हैं। Preset विकल्प मूलतः दो या अधिक इफ़ेक्ट्स के ऐसे संयोजन होते हैं जो एक साथ अच्छी तरह दिखते हैं। इस प्रकार, एक Preset चुनकर, आपको विभिन्न इफ़ेक्ट्स का परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) क्लास के तहत प्रॉपर्टी और मेथड प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकारों पर समान इफ़ेक्ट्स लागू करने की अनुमति देते हैं।

## **छाया इफ़ेक्ट लागू करें**

Aspose.Slides for C++ आकारों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी, और ब्लर त्रिज्या को अपनी प्रस्तुति के डिजाइन के अनुसार अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

स्लाइड बैकग्राउंड के विरुद्ध कार्ड या पैनल को उभारा करने के लिए बाहरी छाया का उपयोग करें। छाया आकार की किनारों से बाहर तक विस्तार करती है, जिससे ऐसा प्रभाव बनता है कि आकार स्लाइड के ऊपर उठाया हुआ है। इसके रंग, दिशा, दूरी, और ब्लर त्रिज्या को अपने टेम्पलेट की प्रकाश व्यवस्था और स्टाइलिंग के अनुसार समायोजित करें।

यह C++ कोड दिखाता है कि कैसे एक आयत पर [बाहरी छाया इफ़ेक्ट](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) लागू किया जाए:

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

![छाया इफ़ेक्ट](shadow_effect.png)

### **आंतरिक छाया लागू करें**

जब टेम्पलेट की दृश्य स्टाइलिंग को पुन: उत्पन्न कर रहे हों, तो कार्ड या पैनल को धँसा हुआ रूप देने के लिए आंतरिक छाया का उपयोग करें। बाहरी छाया आकार के बाहर तक विस्तारित होती है और उसे उठे हुए जैसा दिखाती है, जबकि आंतरिक छाया इसके किनारों के अंदर को शेड करती है।

कॉल करें [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), फिर कॉन्फ़िगर करें [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). बड़ी ब्लर त्रिज्या मान अधिक कोमल किनारे बनाते हैं।

यह C++ उदाहरण हल्के नीले कार्ड को गहरे धूसर आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

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

आंतरिक छाया को हटाने के लिए, shape के effect format पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

## **परावर्तन इफ़ेक्ट लागू करें**

Aspose.Slides for C++ में परावर्तन इफ़ेक्ट लागू करने के लिए, आप आकारों में एक दर्पण-समान परावर्तन जोड़ सकते हैं, तथा दूरी, पारदर्शिता, और आकार जैसे पैरामीटर को समायोजित कर सकते हैं। यह इफ़ेक्ट आपके प्रस्तुतियों की सौंदर्यशास्त्र को उन्नत करता है, आकारों को अधिक परिष्कृत और सज्जित दिखाता है। इसे सरल कोड के साथ लागू करना आसान है, जिससे कई तत्वों पर तेज़ी से समान डिज़ाइन के लिए लागू किया जा सके।

यह C++ कोड दिखाता है कि कैसे एक आकार पर [परावर्तन इफ़ेक्ट](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) लागू किया जाए:

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

![परावर्तन इफ़ेक्ट](reflection_effect.png)

## **चमक इफ़ेक्ट लागू करें**

Aspose.Slides for C++ में आकार पर चमक इफ़ेक्ट लागू करने के लिए, आप आकारों के चारों ओर एक कोमल, प्रकाशमान आभा जोड़ सकते हैं, तथा रंग और आकार जैसी प्रॉपर्टी को समायोजित कर सकते हैं। यह इफ़ेक्ट आकारों को उभारा करता है और आपके प्रस्तुति में आकर्षक, नज़र को पकड़ने वाला दृश्य तत्व जोड़ता है। इसे न्यूनतम कोड के साथ लागू किया जा सकता है, जिससे आपके स्लाइड्स का समग्र लुक बेहतर होता है।

यह C++ कोड दिखाता है कि कैसे एक आकार पर [चमक इफ़ेक्ट](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) लागू किया जाए:

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

![चमक इफ़ेक्ट](glow_effect.png)

## **नरम किनारे इफ़ेक्ट लागू करें**

Aspose.Slides for C++ में नरम किनारे इफ़ेक्ट लागू करने के लिए, आप आकार के किनारों के चारों ओर एक स्मूद, ब्लर ट्रांज़िशन बना सकते हैं। यह इफ़ेक्ट एक अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जो उन डिज़ाइनों के लिए परिपूर्ण है जिन्हें हल्की, नरम उपस्थिति चाहिए। आप अपनी प्रस्तुति में विभिन्न आकारों पर वांछित प्रभाव पाने के लिए त्रिज्या जैसे पैरामीटर को आसानी से समायोजित कर सकते हैं।

यह C++ कोड दिखाता है कि कैसे एक आकार पर [नरम किनारे](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) लागू किया जाए:

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

![नरम किनारे इफ़ेक्ट](soft_edges_effect.png)

## **ब्लर इफ़ेक्ट लागू करें**

आकार ब्लर का उपयोग करके आकार की भराव और रूपरेखा को नरम किया जा सकता है, जबकि आकार संपादन योग्य बना रहता है। shape के effect format पर [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) को कॉल करें। त्रिज्या पॉइंट्स में मापी जाती है (1/72 इंच): एक गैर-नकारात्मक मान उपयोग करें, बड़े मान अधिक मजबूत ब्लर उत्पन्न करते हैं। शून्य त्रिज्या रूप को अपरिवर्तित रखती है।

यह [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) सेटिंग प्रभाव की विज़िबल सीमाओं को नियंत्रित करती है। `false` होने पर, ब्लर मूल पेंटेड सीमाओं तक सीमित रहता है, जिसमें रूपरेखा भी शामिल है। `true` होने पर, ब्लर उन सीमाओं से बाहर तक विस्तारित हो सकता है। इन दोनों सेटिंग्स से आकार की स्थिति या आयाम नहीं बदलते।

नीचे दिया गया तुलना समान भराव, रूपरेखा, और आकार आयामों का उपयोग करती है। शीर्ष पंक्ति `grow = false` का उपयोग करती है; नीचे की पंक्ति `grow = true` का उपयोग करती है।

![5 और 15 पॉइंट ब्लर त्रिज्या के साथ मूल आयत, grow अक्षम व सक्षम](shape_blur_comparison.png)

यह C++ उदाहरण एक नारंगी आयत को गहरे नीले आउटलाइन के साथ बनाता है, 5‑पॉइंट ब्लर लागू करता है, और फिर [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) को फिर से कॉल करके इसे 15‑पॉइंट ब्लर में अपडेट करता है। यह दोनों ब्लर स्थितियों को सहेजता है, फिर [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) को कॉल करता है और ब्लर के बिना आकार को सहेजता है।

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

आकार ब्लर भराव और रूपरेखा दोनों को प्रभावित करता है। नरम किनारे इफ़ेक्ट आकार के किनारों को फेड करता है, जबकि छाया ब्लर केवल छाया को नरम करता है। छवि रूपांतरण इफ़ेक्ट छवि सामग्री पर कार्य करता है; इस उदाहरण में ब्लर को सीधे आकार के effect format पर लागू किया गया है बिना आकार को छवि में परिवर्तित किए।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकार पर कई इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप विभिन्न इफ़ेक्ट्स, जैसे कि छाया, परावर्तन, और चमक, को एक ही आकार पर संयोजित कर सकते हैं ताकि अधिक गतिशील रूप बन सके।

**मैं किन आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

आप विभिन्न आकारों पर इफ़ेक्ट्स लागू कर सकते हैं, जिनमें ऑटोषेप, चार्ट, टेबल, चित्र, SmartArt ऑब्जेक्ट, OLE ऑब्जेक्ट आदि शामिल हैं।

**क्या मैं समूहित आकारों पर इफ़ेक्ट्स लागू कर सकता हूँ?**

हाँ, आप समूहित आकारों पर इफ़ेक्ट्स लागू कर सकते हैं। इफ़ेक्ट पूरे समूह पर लागू होगा।