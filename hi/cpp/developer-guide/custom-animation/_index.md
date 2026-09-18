---
title: C++ में कस्टम एनीमेशन व्यवहार बनाएं और संशोधित करें
linktitle: कस्टम एनीमेशन
type: docs
weight: 151
url: /hi/cpp/custom-animation/
keywords:
- कस्टम एनीमेशन
- एनीमेशन व्यवहार
- गति पथ
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint प्रस्तुतियों में कस्टम एनीमेशन व्यवहार और संपादन योग्य गति पथ बनाएं, निरीक्षण करें और संशोधित करें।"
---
## **परिचय**

कस्टम एनीमेशन व्यवहार आपको एनीमेशन इफ़ेक्ट के भीतर व्यक्तिगत संचालन को नियंत्रित करने देते हैं, जैसे रंग बदलना, आकार घुमाना, या संपादन योग्य मोशन पाथ का अनुसरण करना। यह गाइड दिखाता है कि कैसे व्यवहार बनाएं और संयोजित करें, उनके समय को कॉन्फ़िगर करें, मौजूदा एनीमेशन को निरीक्षण और संशोधित करें, और यह सत्यापित करें कि उनके गुण प्रस्तुति को सहेजने और पुनः खोलने के बाद भी बने रहें।

प्रीडिफ़ाइंड इफ़ेक्ट्स और क्लिक ट्रिगर्स के लिए, देखें [Shape Animation](/slides/hi/cpp/shape-animation/)।

## **एनीमेशन मॉडल को समझें**

एक एनीमेशन इस प्रकार व्यवस्थित होता है **Timeline → Sequence → Effect → Behaviors**:

- स्लाइड का [get_Timeline](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_timeline/) इसमें मुख्य अनुक्रम और इंटरैक्टिव अनुक्रम होते हैं।
- एक [ISequence](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/) में इफ़ेक्ट्स होते हैं, जो संभावित रूप से अलग-अलग आकारों को लक्ष्य बनाते हैं।
- एक [IEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/) लक्ष्य आकार, प्रीसेट, उपप्रकार, और इफ़ेक्ट टाइमिंग को पहचानता है।
- [IEffect::get_Behaviors](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/get_behaviors/) उन संचालन को रखता है जो इफ़ेक्ट को लागू करते हैं: रंग बदलना, स्थानांतरित करना, घुमाना, गुण सेट करना, आदि।

## **व्यक्तिगत व्यवहार बनाएं**

इफ़ेक्ट बनाने और उसकी [get_Behaviors](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/get_behaviors/) संग्रह तक पहुंचने के लिए [ISequence::AddEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/addeffect/) को कॉल करें। एक प्रीसेट इस संग्रह को स्वचालित रूप से भर सकता है। प्रीसेट का विस्तार करते समय इसकी क्रियाओं को रखें, या जानबूझकर बदलने पर [Clear](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorcollection/clear/) का उपयोग करें।

[IBehaviorFactory](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/) नीचे दर्शाए गए आठ व्यवहार प्रकार बनाता है। मोशन को [Build a Motion Path](#build-a-motion-path) में कवर किया गया है। प्रत्येक निर्माण उदाहरण स्वयं समाहित कोड है जो एक फ़ंक्शन के भीतर चलाया जाता है; बाद के संपादन उदाहरण बताते हैं कि वे किस आउटपुट फ़ाइल का उपयोग करते हैं।

### **रोटेशन**

रोटेशन बनाने के लिए [CreateRotationEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) का प्रयोग करें। [get_By](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/irotationeffect/get_by/) डिग्री में सापेक्ष कोण निर्दिष्ट करता है; [get_From](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/irotationeffect/get_from/) और [get_To](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/irotationeffect/get_to/) अंत बिंदु निर्दिष्ट करते हैं।

उदाहरण एक Spin इफ़ेक्ट से शुरू होता है, उसके प्रीसेट संचालन को एक रोटेशन व्यवहार से बदलता है, और उस संचालन को दो‑सेकंड की अवधि देता है। 90 डिग्री का सापेक्ष कोण आकार की प्रारंभिक अभिविन्यास से एक चौथाई मोड़ दर्शाता है, इसलिए स्पष्ट प्रारंभिक कोण की आवश्यकता नहीं होती।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Spin, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto rotation = factory->CreateRotationEffect();
rotation->set_By(90.0f);
rotation->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(rotation);

presentation->Save(u"rotation.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`rotation.pptx` में एक आकार और एक रोटेशन व्यवहार होता है। नीचे दी गई संग्रह, टाइमिंग, और रोटेशन‑संपादन उदाहरण इसी फ़ाइल का प्रयोग करते हैं।

### **स्केल**

[X/Y प्रतिशतों के साथ] [CreateScaleEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) का प्रयोग करें: [get_From](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/iscaleeffect/get_from/) और [get_To](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/iscaleeffect/get_to/) शुरूआती और समाप्ति आकार का वर्णन करते हैं, जबकि [get_By](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/iscaleeffect/get_by/) सापेक्ष परिवर्तन बताता है। यहाँ, 100 मूल आकार को दर्शाता है।

उदाहरण दो सेकंड में दोनों आयामों को 100 % से 125 % तक बढ़ाता है। समान क्षैतिज और ऊर्धवाधर प्रतिशतों का प्रयोग आकार के अनुपात को बनाए रखता है; अलग-अलग प्रतिशत आयाम में असमान विस्तार करेंगे।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::GrowShrink, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_From(PointF(100, 100));
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(scale);

presentation->Save(u"scale.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **कलर**

[CreateColorEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) का प्रयोग करके भराव को नीले से नारंगी में बदलें। [get_From](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/icoloreffect/get_from/) और [get_To](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/icoloreffect/get_to/) रंग हैं; [get_By](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/icoloreffect/get_by/) रंग ऑफ़सेट है। [IBehavior::get_Properties](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehavior/get_properties/) वह गुण पहचानता है जिसे एनीमेट किया जा रहा है।

आकार का ठोस भराव नीला से प्रारंभ किया गया है, जो एनीमेशन के प्रारंभिक रंग से मेल खाता है। भराव‑रंग गुण का चयन करने से व्यवहार को पता चलता है कि आकार के किस भाग को बदलना है; केवल रंग अंत बिंदु उस गुण को नहीं पहचानते। सहेजा गया इफ़ेक्ट दो‑सेकंड के परिवर्तन को दर्शाता है।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IColorEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/FillType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::ChangeFillColor, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto color = factory->CreateColorEffect();
color->get_Properties()->Add(BehaviorProperty::get_FillColor()->get_Value());
color->get_From()->set_Color(Color::get_Blue());
color->get_To()->set_Color(Color::get_Orange());
color->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(color);

presentation->Save(u"color.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **फ़िल्टर**

[CreateFilterEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) का प्रयोग करके एक वाइप चुनें। [get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ifiltereffect/get_type/), [get_Subtype](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ifiltereffect/get_subtype/), और [get_Reveal](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ifiltereffect/get_reveal/) क्रमशः फ़िल्टर, दिशा, और आकार को प्रकट या छुपाने को निर्दिष्ट करते हैं।

यह उदाहरण दो‑सेकंड की वाइप कॉन्फ़िगर करता है जो दाएँ‑दिशा उपप्रकार का उपयोग करके आकार को प्रकट करती है। फ़िल्टर सेटिंग्स इफ़ेक्ट के भीतर व्यवहार का हिस्सा हैं, इसलिए वे प्रीसेट के मूल संचालन को हटाने के बाद कॉन्फ़िगर की जाती हैं।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/FilterEffectRevealType.h>
#include <DOM/Animation/FilterEffectSubtype.h>
#include <DOM/Animation/FilterEffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IFilterEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Wipe, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto filter = factory->CreateFilterEffect();
filter->set_Type(FilterEffectType::Wipe);
filter->set_Subtype(FilterEffectSubtype::Right);
filter->set_Reveal(FilterEffectRevealType::In);
filter->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(filter);

presentation->Save(u"filter.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **प्रॉपर्टी**

[CreatePropertyEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) का प्रयोग करके अपारदर्शिता (opacity) को एनीमेट करें। [get_From](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ipropertyeffect/get_from/), [get_To](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ipropertyeffect/get_to/), और [get_By](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ipropertyeffect/get_by/) स्ट्रिंग्स हैं जिन्हें [get_ValueType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ipropertyeffect/get_valuetype/) और [get_CalcMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ipropertyeffect/get_calcmode/) द्वारा व्याख्यायित किया जाता है। सभी तीन को बिना चयन के सेट करने के बजाय केवल अंत बिंदु या सापेक्ष ऑफ़सेट चुनें।

यहाँ चयनित गुण अपारदर्शिता है, और संख्यात्मक स्ट्रिंग्स 25 % अपारदर्शिता से पूर्ण अपारदर्शिता तक परिवर्तन दर्शाती हैं। रैखिक अंतरोपण इन मानों के बीच क्रमिक परिवर्तन को दर्शाता है। जब इस उदाहरण को किसी अन्य गुण के लिए अनुकूलित करते हैं, तो उस गुण के अनुरूप मान प्रकार और अंत बिंदु मान चुनें।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IPropertyEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/PropertyCalcModeType.h>
#include <DOM/Animation/PropertyValueType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto property = factory->CreatePropertyEffect();
property->get_Properties()->Add(BehaviorProperty::get_StyleOpacity()->get_Value());
property->set_ValueType(PropertyValueType::Number);
property->set_CalcMode(PropertyCalcModeType::Linear);
property->set_From(u"0.25");
property->set_To(u"1");
property->get_Timing()->set_Duration(2.0f);

effect->get_Behaviors()->Add(property);

presentation->Save(u"property.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **सेट**

[CreateSetEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createseteffect/) का प्रयोग करके दृश्यता को [get_To](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/iseteffect/get_to/) द्वारा असाइन करें। सेट व्यवहार अंत बिंदुओं के बीच इंटरपोलेशन नहीं करता।

उदाहरण दृश्यता गुण को चुनता है और व्यवहार चलने पर स्ट्रिंग `visible` असाइन करता है। C++ में स्ट्रिंग को ऑब्जेक्ट के रूप में बॉक्स करें फिर सेट व्यवहार को असाइन करें। आयत पहले से ही इस न्यूनतम प्रस्तुति में दृश्यमान है, इसलिए यह असाइनमेंट स्वयं में स्पष्ट दृश्य परिवर्तन नहीं दिखा सकता। ऐसी क्रिया बड़े इफ़ेक्ट के हिस्से के रूप में उपयोगी होती है जो आकार को छुपाने या दिखाने के समय को भी नियंत्रित करता है।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/BehaviorProperty.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IBehaviorPropertyCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISetEffect.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Appear, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto set = factory->CreateSetEffect();
set->get_Properties()->Add(BehaviorProperty::get_StyleVisibility()->get_Value());
auto visibility = ObjectExt::Box<String>(u"visible");
set->set_To(visibility);

effect->get_Behaviors()->Add(set);

presentation->Save(u"set.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **कमांड**

[CreateCommandEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) का प्रयोग करें और [get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/icommandeffect/get_type/), [get_CommandString](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/icommandeffect/get_commandstring/), तथा [get_ShapeTarget](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/icommandeffect/get_shapetarget/) को कॉन्फ़िगर करें। कार्य निर्देशिका में `sample.wav` नामक WAV रिकॉर्डिंग रखें। यह उदाहरण इसे [AddAudioFrameEmbedded](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/addaudioframeembedded/) के साथ एम्बेड करता है और ऑडियो फ़्रेम को प्ले कमांड से जोड़ता है।

ऑडियो फ़्रेम इफ़ेक्ट का लक्ष्य और कमांड का लक्ष्य दोनों है। यह प्ले अनुरोध को एम्बेडेड रिकॉर्डिंग से जोड़ता है; केवल कमांड स्ट्रिंग यह नहीं बताती कि किस मीडिया ऑब्जेक्ट को नियंत्रित करना है। इफ़ेक्ट को स्लाइडशो के दौरान क्लिक पर शुरू होने के लिए कॉन्फ़िगर किया गया है।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/CommandEffectType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/ICommandEffect.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudioFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto audioStream = IO::File::OpenRead(u"sample.wav");
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(audioFrame, EffectType::MediaPlay, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto command = factory->CreateCommandEffect();
command->set_Type(CommandEffectType::Call);
command->set_CommandString(u"play");
command->set_ShapeTarget(audioFrame);

effect->get_Behaviors()->Add(command);

presentation->Save(u"command.pptx", SaveFormat::Pptx);

audioStream->Close();

presentation->Dispose();
```

सहेजने से कमांड `command.pptx` में संग्रहीत होता है; यह रिकॉर्डिंग नहीं चलाता। प्लेबैक के लिए ऐसा स्लाइडशो प्लेयर्स चाहिए जो कमांड और उसके मीडिया लक्ष्य को सपोर्ट करता हो।

## **बिहेवियर संग्रह का प्रबंधन**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorcollection/) में [Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorcollection/remove/), और [RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorcollection/removeat/) समर्थित हैं। यह उदाहरण `rotation.pptx` खोलता है, स्केल जोड़ता है, इसे रोटेशन से पहले रखता है, और रोटेशन को हटाता है। समान वस्तु को हटाकर फिर डालने से उसकी संग्रहीत स्थिति बदलती है बिना प्रतिलिपि बनाए।

संपादन की क्रमबद्धता संग्रह को rotation–scale से scale–rotation, फिर केवल scale में बदल देती है। इंडेक्स वर्तमान संग्रह को संदर्भित करते हैं, इसलिए हटाना पुनरावृत्ति के बाद रोटेशन के नए इंडेक्स को उपयोग करता है। अंतिम गणना पुष्टि करती है कि कौन सा व्यवहार सहेजा जाएगा।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IScaleEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto behaviors = effect->get_Behaviors();

auto factory = MakeObject<BehaviorFactory>();
auto scale = factory->CreateScaleEffect();
scale->set_To(PointF(125, 125));
scale->get_Timing()->set_Duration(2.0f);

behaviors->Add(scale);

behaviors->Remove(scale);
behaviors->Insert(0, scale);
behaviors->RemoveAt(1);

for (auto behavior : behaviors)
    Console::WriteLine(behavior->GetType().get_Name());

presentation->Save(u"collection-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

आउटपुट `ScaleEffect` है: केवल स्केलिंग शेष रहती है। संग्रह क्रम स्वयं व्यवहारों को क्रमशः चलाने का शेड्यूल नहीं बनाता। सभी संचालन को बदलने पर ही संग्रह को साफ़ करें।

## **व्यवहार टाइमिंग का कॉन्फ़िगरेशन**

[IBehavior::get_Timing](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehavior/get_timing/) [ITiming](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/) को उजागर करता है, जो [IEffect::get_Timing](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/get_timing/) से स्वतंत्र है। इफ़ेक्ट टाइमिंग संलग्न इफ़ेक्ट को शेड्यूल करता है; व्यवहार टाइमिंग उसके भीतर की ऑपरेशन को वर्णित करता है।

### **अवधि, देरी, दोहराव, और तेज़ी सेट करें**

`rotation.pptx` खोलें और सेकंड में [get_Duration](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_duration/) तथा [get_TriggerDelayTime](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_triggerdelaytime/) सेट करें, फिर [get_RepeatCount](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_repeatcount/) कॉन्फ़िगर करें। [get_Accelerate](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_accelerate/) और [get_Decelerate](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_decelerate/) अवधि के अंश हैं; उनका योग अधिकतम 1 रखें।

इनपुट फ़ाइल वह है जो रोटेशन उदाहरण में बनाई गई थी, जहाँ पहला व्यवहार ज्ञात रूप से रोटेशन है। यह उदाहरण केवल उसी व्यवहार की टाइमिंग बदलता है; उसका 90‑डिग्री कोण ठीक रहता है। कोण और टाइमिंग को अलग रखना गति को पुनः निर्माण किए बिना समायोजित करना आसान बनाता है।

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto rotation = ExplicitCast<IRotationEffect>(effect->get_Behaviors()->idx_get(0));
rotation->get_Timing()->set_Duration(2.0f);
rotation->get_Timing()->set_TriggerDelayTime(0.5f);
rotation->get_Timing()->set_RepeatCount(3.0f);
rotation->get_Timing()->set_Accelerate(0.2f);
rotation->get_Timing()->set_Decelerate(0.2f);

presentation->Save(u"timing.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

व्यवहार दो‑सेकंड की अवधि, आधा‑सेकंड देरी, और दोहराव गिनती 3 का उपयोग करता है। उसकी अवधि का पहला और अंतिम 20 % तेज़ी और मंदी के लिए उपयोग किया जाता है।

अन्य दोहराव नीतियों में [get_RepeatDuration](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_repeatduration/), [get_RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_repeatuntilendslide/), और [get_RepeatUntilNextClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_repeatuntilnextclick/) शामिल हैं; सभी को एक साथ सक्षम करने के बजाय एक नीति चुनें। [get_AutoReverse](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/get_autoreverse/) आगे के पास के बाद एनीमेशन को पीछे की ओर चलाता है। तेज़ी और मंदी सतत परिवर्तन पर लागू होती हैं, न कि असतत असाइनमेंट या कमांड पर।

## **मOTION पाथ बनाएं**

[CreateMotionEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) का प्रयोग करके मोशन बनाएं। इसके [get_From](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioneffect/get_from/), [get_To](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioneffect/get_to/), और [get_By](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioneffect/get_by/) प्रतिशत‑आधारित निर्देशांक या ऑफ़सेट का वर्णन करते हैं। एक संपादन योग्य मार्ग के लिए, एक [MotionPath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/motionpath/) बनाएं और उसे [IMotionEffect::get_Path](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioneffect/get_path/) में असाइन करें। [IMotionPath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotionpath/) पाथ कमांड को संग्रहीत करता है।

[MotionCommandPathType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/motioncommandpathtype/) संचालन का चयन करता है:

| कमांड | बिंदु | अर्थ |
| --- | --- | --- |
| MoveTo | One | प्रारंभिक स्थिति निर्धारित करे। |
| LineTo | One | सीधे खण्ड के साथ उसके अंत बिंदु तक जाएँ। |
| CurveTo | Three | दो नियंत्रण बिंदुओं और एक अंत बिंदु द्वारा परिभाषित क्यूबिक कर्व को अनुसरण करें। |
| CloseLoop | None | आरम्भिक स्थिति पर लौटें। |
| End | None | पथ समाप्त करें। |

[MotionPathPointsType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/motionpathpointstype/) बिंदु‑संपादन गुणों को वर्णित करता है, जैसे किनारा या स्मूथ बिंदु। यह कमांड प्रकार को प्रतिस्थापित नहीं करता। नीचे के कर्व उदाहरण में कर्व बिंदु प्रकार उपयोग करें, और सीधे खण्डों के लिए कोना बिंदु प्रकार।

पाथ निर्देशांक स्लाइड आयामों के सापेक्ष सामान्यीकृत होते हैं: X विस्थापन 0.25 का अर्थ स्लाइड की चौड़ाई का एक चौथाई है, न कि 0.25 पॉइंट्स। सकारात्मक Y नीचे की दिशा में चलता है। निरपेक्ष कमांड पाथ निर्देशांक प्रणाली में स्थितियों को निर्दिष्ट करता है; सापेक्ष कमांड वर्तमान स्थिति से ऑफ़सेट दर्शाते हैं। यह [get_Origin](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioneffect/get_origin/) से अलग है, जो पाथ के संदर्भ फ्रेम को चुनता है, और [get_PathEditMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioneffect/get_patheditmode/) से, जो आकार के स्थानांतरित होने पर पाथ के चलने को नियंत्रित करता है।

### **सीधा पाथ बनाएं**

एक मोशन व्यवहार बनाएं जिसमें प्रारंभिक बिंदु, एक सीधा खण्ड, और एक अंत कमांड हो। [IMotionPath::Add](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotionpath/add/) कमांड प्रकार, उसके बिंदु, बिंदु प्रकार, और सापेक्ष‑निर्देशांक फ़्लैग लेता है।

प्रारंभिक कमांड (0, 0) स्थापित करता है, और रेखा (0.25, 0) पर समाप्त होती है, जिससे पाथ स्लाइड की चौड़ाई का एक चौथाई क्षैतिज विस्थापन प्राप्त करता है। अंत कमांड में कोई बिंदु नहीं होते। पाथ असाइन करने के बाद, मोशन व्यवहार को इफ़ेक्ट में जोड़ने से वह रेक्टैंगल से जुड़ जाता है।

```cpp
#include <DOM/Animation/BehaviorFactory.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionOriginType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 160, 80);

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::PathRight, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Behaviors()->Clear();

auto factory = MakeObject<BehaviorFactory>();
auto motion = factory->CreateMotionEffect();
motion->set_Origin(MotionOriginType::Layout);
motion->get_Timing()->set_Duration(2.0f);

auto path = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0, 0) });
path->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto linePoints = MakeArray<PointF>({ PointF(0.25f, 0) });
path->Add(MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
auto endPoints = MakeArray<PointF>(0);
path->Add(MotionCommandPathType::End, endPoints, MotionPathPointsType::None, false);

motion->set_Path(path);
effect->get_Behaviors()->Add(motion);

presentation->Save(u"motion.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion.pptx` में एक मोशन व्यवहार तीन पाथ कमांड के साथ होता है। नीचे के फ़ाइल‑संपादन उदाहरण इस ज्ञात संरचना का प्रयोग करते हैं।

### **निर्पेक्ष और सापेक्ष निर्देशांक की तुलना**

ये दो पाथ वस्तुएँ समान मार्ग को वर्णित करती हैं। निरपेक्ष कमांड (0.3, 0.1) पर समाप्त होता है; सापेक्ष कमांड वर्तमान स्थिति (0.2, 0) में (0.1, 0.1) जोड़ता है।

दोनों पाथ एक ही स्थिति से शुरू होते हैं। सापेक्ष रेखा के लिए, अंतिम बिंदु प्राप्त करने हेतु X और Y ऑफ़सेट को वर्तमान स्थिति में जोड़ें; निरपेक्ष रेखा के लिए, अंत बिंदु सीधे पढ़ें। फ़्लैग को परिवर्तित किए बिना निर्देशांक को नहीं बदलने से अलग मार्ग बन जाएगा।

```cpp
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPath.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <drawing/point_f.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::Drawing;

auto absolutePath = MakeObject<MotionPath>();
auto startPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
absolutePath->Add(MotionCommandPathType::MoveTo, startPoints, MotionPathPointsType::Auto, false);
auto absoluteEndPoints = MakeArray<PointF>({ PointF(0.3f, 0.1f) });
absolutePath->Add(MotionCommandPathType::LineTo, absoluteEndPoints, MotionPathPointsType::Corner, false);

auto relativePath = MakeObject<MotionPath>();
auto relativeStartPoints = MakeArray<PointF>({ PointF(0.2f, 0) });
relativePath->Add(MotionCommandPathType::MoveTo, relativeStartPoints, MotionPathPointsType::Auto, false);
auto relativeOffsets = MakeArray<PointF>({ PointF(0.1f, 0.1f) });
relativePath->Add(MotionCommandPathType::LineTo, relativeOffsets, MotionPathPointsType::Corner, true);
```

किसी भी पाथ को मोशन व्यवहार में असाइन करके प्रस्तुति में उपयोग करें। अंतिम बूलियन तर्क उस कमांड के लिए सापेक्ष निर्देशांक चुनता है।

### **रेखा को कर्व से बदलें**

`motion.pptx` खोलें और उसकी रेखा कमांड को क्यूबिक कर्व से बदलें। पहले दो नियंत्रण बिंदु दें, फिर अंत बिंदु।

प्रारंभिक स्थिति पूर्ववर्ती कमांड द्वारा प्रदान की जाती है। पहले दो बिंदु कर्व को आकार देते हैं, तीसरा उसका लक्ष्य बिंदु है; ये तीन क्रमिक गंतव्य नहीं हैं। कमांड प्रकार, बिंदु‑संपादन प्रकार, और बिंदु सरणी को एक साथ बदलने से सेगमेंट नई ज्यामिति के साथ सुसंगत रहता है।

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
path->idx_get(1)->set_CommandType(MotionCommandPathType::CurveTo);
path->idx_get(1)->set_PointsType(MotionPathPointsType::CurveSmooth);
auto curvePoints = MakeArray<PointF>({ PointF(0.1f, 0), PointF(0.2f, 0.1f), PointF(0.3f, 0.1f) });
path->idx_get(1)->set_Points(curvePoints);

presentation->Save(u"curve.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`curve.pptx` में पाथ अभी भी तीन कमांड रखता है; उसका मध्य कमांड अब कर्व परिभाषित करता है।

## **सहेजे गए पाथ का निरीक्षण और संपादन**

प्रत्येक [IMotionCmdPath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioncmdpath/) [get_Points](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioncmdpath/get_points/), [get_CommandType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioncmdpath/get_commandtype/), [get_PointsType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioncmdpath/get_pointstype/), और [get_IsRelative](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotioncmdpath/get_isrelative/) को उजागर करता है। नीचे के उदाहरण `motion.pptx` के ज्ञात तीन‑कमांड पाथ का प्रयोग करते हैं। स्वैच्छिक इनपुट के लिए, लक्ष्य इफ़ेक्ट खोजें और संपादन से पहले कमांड प्रकार और बिंदु गिनती जाँचें।

### **कमांड और निर्देशांक पढ़ें**

पाथ को बिना बदले पढ़ें। अंत और क्लोज‑लूप कमांड को बिंदु की आवश्यकता नहीं होती, इसलिए नल बिंदु सरणी की अनुमति दें।

आउटपुट प्रत्येक कमांड को उसके सापेक्ष‑निर्देशांक फ़्लैग के साथ सूचीबद्ध करता है, उसके बाद बिंदु दिखाता है। यह आपको अंत बिंदु और ऑफ़सेट को संशोधित करने से पहले अलग करने में मदद करता है। कर्व के पास तीन बिंदु होते हैं, जबकि इस फ़ाइल की सीधी रेखा के पास केवल एक बिंदु होता है।

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
for (auto segment : path)
{
    Console::WriteLine(u"{0}, relative: {1}", segment->get_CommandType(), segment->get_IsRelative());
    if (segment->get_Points() != nullptr)
        for (auto point : segment->get_Points())
            Console::WriteLine(u"X={0}, Y={1}", point.get_X(), point.get_Y());
}

presentation->Dispose();
```

लिस्टिंग में एक प्रारंभिक बिंदु, (0.25, 0) पर समाप्त निरपेक्ष रेखा, और अंत कमांड शामिल है।

### **अंत बिंदु बदलें**

`motion.pptx` खोलें और रेखा के बिंदु सरणी को बदलकर उसका अंत बिंदु स्थानांतरित करें।

इनपुट फ़ाइल में, इंडेक्स 0 प्रारंभिक कमांड है और इंडेक्स 1 रेखा है। रेखा के एकल बिंदु को बदलने से उसका गंतव्य बदलता है, बिना कमांड प्रकार, टाइमिंग, या संग्रह में उसकी स्थिति बदले। क्योंकि कमांड निरपेक्ष निर्देशांक उपयोग करता है, नया युग्म एक स्थिति निर्दिष्ट करता है न कि अतिरिक्त ऑफ़सेट।

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));
auto endpointPoints = MakeArray<PointF>({ PointF(0.4f, 0.1f) });
motion->get_Path()->idx_get(1)->set_Points(endpointPoints);

presentation->Save(u"motion-endpoint.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

`motion-endpoint.pptx` में रेखा (0.4, 0.1) पर समाप्त होती है; मूल फ़ाइल अपरिवर्तित रहती है।

### **सेगमेंट बदलें**

[Insert](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotionpath/insert/) और [RemoveAt](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/imotionpath/removeat/) का प्रयोग करके `motion.pptx` में रेखा को बदलें। सम्मिलन पुरानी रेखा को इंडेक्स 2 पर ले जाता है।

यह कमांड ऑब्जेक्ट को बदलने को दर्शाता है, न कि उसके मौजूदा निर्देशांक को संपादित करना। सम्मिलन के बाद, संग्रह अस्थायी रूप से प्रारंभिक कमांड, नई रेखा, पुरानी रेखा, और अंत कमांड रखता है। इंडेक्स 2 को हटाने से पुरानी रेखा हट जाती है और नई मार्ग जगह पर रहती है।

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionCmdPath.h>
#include <DOM/Animation/IMotionEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/array.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"motion.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);
auto motion = ExplicitCast<IMotionEffect>(effect->get_Behaviors()->idx_get(0));

auto path = motion->get_Path();
auto linePoints = MakeArray<PointF>({ PointF(0.2f, 0.1f) });
path->Insert(1, MotionCommandPathType::LineTo, linePoints, MotionPathPointsType::Corner, false);
path->RemoveAt(2);

presentation->Save(u"motion-edited.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

सहेजा गया पाथ अभी भी तीन कमांड रखता है, नई रेखा (0.2, 0.1) पर समाप्त होती है और अंत कमांड अंतिम रहता है।

## **मौजूदा व्यवहार को संशोधित और सत्यापित करें**

जब व्यवहार का इंडेक्स अज्ञात हो, तो प्रकार के आधार पर उसे चुनें। यह उदाहरण `rotation.pptx` खोलता है, उसका [IRotationEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/irotationeffect/) खोजता है, कोण बदलता है, और फिर खोलने के बाद सहेजा गया मान जाँचता है।

प्रकार जांच लूप को उन व्यवहारों को छोड़ने देती है जो रोटेशन नहीं हैं। दूसरा लोड फ़ाइल को अलग प्रस्तुति ऑब्जेक्ट में पढ़ता है, इसलिए तुलना संग्रहीत डेटा को जाँचती है न कि मेमोरी में अभी धरे हुए मान को। यह उदाहरण अभी भी मानता है कि ज्ञात इफ़ेक्ट मुख्य अनुक्रम में पहले है; प्रकार के आधार पर व्यवहार चुनना एक मनमानी प्रस्तुति में सही इफ़ेक्ट को नहीं ढूँढ़ता।

```cpp
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IRotationEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <cmath>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"rotation.pptx");
auto effect = presentation->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : effect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        rotation->set_By(180.0f);
}

presentation->Save(u"rotation-edited.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"rotation-edited.pptx");
auto savedEffect = reopened->get_Slide(0)->get_Timeline()->get_MainSequence()->idx_get(0);

for (auto behavior : savedEffect->get_Behaviors())
{
    auto rotation = DynamicCast<IRotationEffect>(behavior);
    if (rotation != nullptr)
        Console::WriteLine(u"Rotation preserved: {0}", std::abs(rotation->get_By() - 180.0f) < 0.001f);
}

presentation->Dispose();
reopened->Dispose();
```

आउटपुट `Rotation preserved: True` है। समान प्रकार‑जाँच पैटर्न को अन्य व्यवहारों पर लागू करें। पूर्ण संरक्षण जाँच के लिए लक्ष्य आकार, इफ़ेक्ट, व्यवहार प्रकार और क्रम, टाइमिंग, तथा पाथ कमांड की तुलना करें। फ्लोटिंग‑पॉइंट मानों के लिए संख्यात्मक सहनशीलता उपयोग करें। अज्ञात एनीमेशन लेआउट वाली प्रस्तुति के लिए, प्रमुख और इंटरैक्टिव अनुक्रमों की यात्रा हेतु देखें [Read Shape Animations](/slides/hi/cpp/shape-animation/#read-shape-animations)।

## **व्यवहार क्रम, प्रीसेट, और प्लेबैक**

[IBehaviorCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehaviorcollection/) में क्रम इफ़ेक्ट के संचालन का संग्रहीत क्रम है। यह एक प्लेलिस्ट नहीं है जहाँ प्रत्येक व्यवहार स्वचालित रूप से पूर्ववर्ती का इंतज़ार करता है। टाइमिंग और संलग्न इफ़ेक्ट शेड्यूलिंग तय करते हैं। व्यवहार ओवरलैप कर सकते हैं, और समान गुण पर संचालन [get_Additive](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehavior/get_additive/) और [get_Accumulate](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ibehavior/get_accumulate/) के माध्यम से इंटरैक्ट कर सकते हैं। केवल संग्रह क्रम बदलने से “मूव, फिर रोटेट” शेड्यूल नहीं होता; स्पष्ट टाइमिंग या अलग‑अलग इफ़ेक्ट का प्रयोग करें जैसा कि [Shape Animation](/slides/hi/cpp/shape-animation/) में बताया गया है।

इफ़ेक्ट का [get_Type](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/get_type/) और [get_Subtype](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/get_subtype/) उसका प्रीसेट वर्णित करते हैं। ये संपादित व्यवहार वृक्ष का पूर्ण विवरण नहीं हैं। व्यवहारों को अनुकूलित करने से पहले प्रीसेट और उपप्रकार चुनें: प्रीसेट बदलने से संग्रह पुनर्निर्मित हो सकता है और आपकी कस्टम संचालन हट सकती हैं। उदाहरण के तौर पर, कस्टम Spin इफ़ेक्ट को Fade में बदलने से रोटेशन व्यवहार को सेट और फ़िल्टर व्यवहारों से बदला जा सकता है। प्रीसेट या उपप्रकार बदलने के बाद संग्रह को फिर से निरीक्षण करें। प्रीसेट व्यवहारों को साफ़ करने से दृश्यता या आरम्भिक संचालन भी हट सकते हैं जो प्रीसेट को आवश्यक होते हैं। उदाहरण स्पष्ट रूप से दृश्यमान आकारों का उपयोग करते हैं और व्यवहारों को बदलते हैं; वे हर प्रीसेट के कार्यान्वयन को पुनः नहीं बनाते।

## **फ़ॉर्मेट संगतता**

संरक्षित व्यवहार वृक्ष हर व्यूअर या निर्यात रेंडरर में समान प्लेबैक की गारंटी नहीं देता। सहेजे गए डेटा और रेंडर आउटपुट को अलग‑अलग जांचें।

| फ़ॉर्मेट या आउटपुट | क्या सत्यापित करें |
| --- | --- |
| PPTX | इन उदाहरणों के लिए प्राथमिक फ़ॉर्मेट के रूप में उपयोग करें। इसे पुनः खोलें और संपादन योग्य व्यवहार वृक्ष सत्यापित करें, फिर इच्छित PowerPoint संस्करण में प्लेबैक जाँचें। |
| PPT | पुराना बाइनरी प्रतिनिधित्व PPTX से अलग हो सकता है। अलग सहेज‑और‑पुनः‑खोल चक्र और प्लेबैक परीक्षण करें; सफल PPTX आउटपुट से हर कस्टम संयोजन के समर्थन का निष्कर्ष न निकालें। |
| PDF, PNG, JPEG, और अन्य स्थिर स्लाइड छवियां | एक स्थिर स्लाइड प्रतिनिधित्व रखती हैं, न कि चलने योग्य व्यवहार टाइमलाइन या अंतिम एनीमेशन फ़्रेम की गारंटी। |
| [HTML5](/slides/hi/cpp/export-to-html5/) | निर्यात विकल्पों में shape animation सक्षम होने पर समर्थित एनीमेशन चलाए जा सकते हैं। ब्राउज़र में कस्टम संयोजनों का परीक्षण करें। |
| [Animated GIF](/slides/hi/cpp/convert-powerpoint-to-animated-gif/) | रेंडर किए गए फ़्रेम संग्रहीत करता है, न कि संपादन योग्य व्यवहार या क्लिक‑ट्रिगर्ड इंटरैक्शन। वास्तविक रेंडर की गई गति की जाँच करें। |
| [Video](/slides/hi/cpp/convert-powerpoint-to-video/) | एनीमेशन फ़्रेम रेंडर करता है और उन्हें वीडियो में एन्कोड करता है। समर्थन सीमित है रेंडरर के [supported animations and effects](/slides/hi/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) तक; कमांड और इंटरैक्टिव इवेंट संपादन योग्य टाइमलाइन नहीं बनते। |

## **FAQ**

**मेरे इफ़ेक्ट में मेरे द्वारा कोई व्यवहार जोड़ने से पहले ही व्यवहार क्यों होते हैं?**

प्रीडिफ़ाइंड इफ़ेक्ट बनाते समय उसके आधारभूत संचालन बन सकते हैं। उन्हें विस्तारित करने या उनके व्यवहार बदलने से पहले निरीक्षण करें।

**क्या व्यवहार को शुरुआत में ले जाने से वह पहले चलाता है?**

ज़रूरी नहीं। संग्रह क्रम टाइमिंग का विकल्प नहीं है। देरी, अवधि, और समान गुण पर संचालन के इंटरैक्शन को जाँचें।

**एक End कमांड के पास बिंदु क्यों नहीं होते?**

यह पाथ के अंत को दर्शाता है और कोई निर्देशांक की आवश्यकता नहीं होती। फ़ाइल से पाथ पढ़ते समय नल बिंदु सरणी की जाँच करें।

**क्या सफल राउंड ट्रिप प्लेबैक की पुष्टि के लिए पर्याप्त है?**

नहीं। पुनः खोलना उस गुणों के संरक्षित होने की पुष्टि करता है जिन्हें आपने जाँच किया। दृश्य व्यवहार की पुष्टि के लिए स्लाइडशो प्लेयर या एनीमेटेड निर्यात को अलग‑अलग परीक्षण करें।