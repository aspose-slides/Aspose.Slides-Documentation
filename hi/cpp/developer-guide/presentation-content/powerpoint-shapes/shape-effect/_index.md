---
title: प्रस्तुतियों में C++ का उपयोग करके आकृति प्रभाव लागू करें
linktitle: आकृति प्रभाव
type: docs
weight: 30
url: /hi/cpp/shape-effect/
keywords:
- आकृति प्रभाव
- छाया प्रभाव
- प्रतिबिंब प्रभाव
- चमक प्रभाव
- नरम किनारे प्रभाव
- प्रभाव स्वरूप
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ उन्नत आकृति प्रभावों का उपयोग करके अपनी PPT और PPTX फ़ाइलों को बदलें — केवल कुछ सेकंड में आकर्षक, पेशेवर स्लाइड बनाएं।"
---
## **परिचय**

जबकि PowerPoint में प्रभावों का उपयोग किसी आकृति को प्रमुख बनाने के लिए किया जा सकता है, वे [भराव](/slides/hi/cpp/shape-formatting/#gradient-fill) या आउटलाइन से भिन्न होते हैं। PowerPoint प्रभावों का उपयोग करके आप आकृति पर विश्वसनीय प्रतिबिंब बना सकते हैं, आकृति की चमक को फैला सकते हैं, आदि।

![आकृति प्रभाव](shape-effect.png)

PowerPoint छह प्रभाव प्रदान करता है जिन्हें आकृतियों पर लागू किया जा सकता है। आप एक या अधिक प्रभाव किसी आकृति पर लागू कर सकते हैं।

कुछ प्रभाव संयोजन अन्य की तुलना में अधिक आकर्षक होते हैं। इसी कारण से, PowerPoint में **Preset** के अंतर्गत विकल्प होते हैं। Preset विकल्प मूलतः दो या अधिक प्रभावों का ऐसा संयोजन होते हैं जो अच्छा दिखता है। इस प्रकार, एक प्रीसेट चुनकर आपको विभिन्न प्रभावों को परीक्षण या संयोजन करने में समय बर्बाद नहीं करना पड़ेगा।

Aspose.Slides [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/) वर्ग के तहत गुण और विधियाँ प्रदान करता है जो आपको PowerPoint प्रस्तुतियों में आकृतियों पर समान प्रभाव लागू करने की अनुमति देती हैं।

## **छाया प्रभाव लागू करें**

Aspose.Slides for C++ आकृतियों के लिए बाहरी और आंतरिक छायाओं का समर्थन करता है। आप उनके रंग, दिशा, दूरी और धुंधला त्रिज्या को अपनी प्रस्तुति के डिज़ाइन से मेल खाने के लिए अनुकूलित कर सकते हैं।

### **बाहरी छाया लागू करें**

एक कार्ड या पैनल को स्लाइड पृष्ठभूमि के विरुद्ध प्रमुख बनाने के लिए बाहरी छाया का उपयोग करें। छाया आकृति के किनारों के बाहर तक फैली होती है, जिससे ऐसा प्रभाव बनता है कि आकृति स्लाइड से उठी हुई है। अपने टेम्पलेट की प्रकाश व्यवस्था और शैली से मेल खाने के लिए उसके रंग, दिशा, दूरी और धुंधला त्रिज्या समायोजित करें।

यह C++ कोड दिखाता है कि कैसे किसी आयत में [outer shadow effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) लागू किया जाता है:

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

टेम्पलेट की दृश्य शैली को दोहराते समय, कार्ड या पैनल को डुबोने का प्रभाव देने के लिए आंतरिक छाया का उपयोग करें। एक बाहरी छाया आकृति के बाहर तक विस्तारित होती है और इसे उठी हुई दिखाती है, जबकि आंतरिक छाया किनारों के भीतर छाया देती है।

[EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/) को कॉल करें, फिर [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/) को कॉन्फ़िगर करें। बड़ी धुंधला त्रिज्या मान नरम किनारे उत्पन्न करते हैं।

यह C++ उदाहरण एक हल्के नीले कार्ड को गहरे ग्रे आंतरिक छाया के साथ बनाता है और इसे PPTX फ़ाइल के रूप में सहेजता है:

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

आंतरिक छाया को हटाने के लिए, आकृति के प्रभाव फ़ॉर्मेट पर [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) को कॉल करें।

## **प्रतिबिंब प्रभाव लागू करें**

Aspose.Slides for C++ में प्रतिबिंब प्रभाव लागू करने के लिए आप आकृतियों में आरसे जैसे प्रतिबिंब जोड़ सकते हैं, दूरी, पारदर्शिता और आकार जैसे पैरामीटर समायोजित कर सकते हैं। यह प्रभाव आपके प्रस्तुतियों की सौंदर्यशास्त्र को बढ़ाता है, आकृतियों को अधिक परिष्कृत और सुरुचिपूर्ण दिखाता है। यह सरल कोड के साथ आसानी से लागू किया जा सकता है, जिससे कई तत्वों पर निरंतर डिज़ाइन लागू करना तेज़ हो जाता है।

यह C++ कोड दिखाता है कि कैसे किसी आकृति में [reflection effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) लागू किया जाता है:

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

## **चमक प्रभाव लागू करें**

Aspose.Slides for C++ में आकृति पर चमक प्रभाव लागू करने के लिए आप आकृतियों के चारों ओर एक नरम, प्रकाशमान आभा जोड़ सकते हैं, रंग और आकार जैसी गुणों को समायोजित कर सकते हैं। यह प्रभाव आकृतियों को उभारा जाता है और आपके प्रस्तुति में आकर्षक दृश्यमान तत्व जोड़ता है। न्यूनतम कोड के साथ इसे लागू करना आसान है, जिससे स्लाइड्स की कुल रूपरेखा सुधरती है।

यह C++ कोड दिखाता है कि कैसे किसी आकृति में [glow effect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) लागू किया जाता है:

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

![चमक प्रभाव](glow_effect.png)

## **नरम किनारों का प्रभाव लागू करें**

Aspose.Slides for C++ में नरम किनारों का प्रभाव लागू करने के लिए आप आकृति के किनारों के आसपास एक सुचारु, धुंधला संक्रमण बना सकते हैं। यह प्रभाव अधिक सूक्ष्म और परिष्कृत लुक जोड़ता है, जिससे डिज़ाइन को एक हल्का, नरम स्वर मिलता है। आप विभिन्न आकृतियों में वांछित प्रभाव प्राप्त करने के लिए त्रिज्या जैसे पैरामीटर्स को आसानी से समायोजित कर सकते हैं।

यह C++ कोड दिखाता है कि कैसे किसी आकृति में [soft edges](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) लागू किया जाता है:

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

![नरम किनारों का प्रभाव](soft_edges_effect.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही आकृति पर एक से अधिक प्रभाव लागू कर सकता हूँ?**

हां, आप एक ही आकृति पर विभिन्न प्रभावों—जैसे छाया, प्रतिबिंब और चमक—को मिलाकर अधिक गतिशील रूप बना सकते हैं।

**मैं किन आकृतियों पर प्रभाव लागू कर सकता हूँ?**

आप विभिन्न प्रकार की आकृतियों पर प्रभाव लागू कर सकते हैं, जिसमें ऑटोषेप्स, चार्ट, टेबल, चित्र, स्मार्टआर्ट ऑब्जेक्ट, OLE ऑब्जेक्ट और अन्य शामिल हैं।

**क्या मैं समूहित आकृतियों पर प्रभाव लागू कर सकता हूँ?**

हां, आप समूहित आकृतियों पर प्रभाव लागू कर सकते हैं। प्रभाव पूरी समूह पर लागू होगा।