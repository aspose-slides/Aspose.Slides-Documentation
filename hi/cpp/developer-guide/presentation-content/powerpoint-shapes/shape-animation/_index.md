---
title: "C++ का उपयोग करके प्रस्तुतियों में आकार एनीमेशन लागू करें"
linktitle: "आकार एनीमेशन"
type: docs
weight: 60
url: /hi/cpp/shape-animation/
keywords:
- "आकार"
- "एनीमेशन"
- "प्रभाव"
- "एनिमेटेड आकार"
- "एनिमेटेड टेक्स्ट"
- "एनीमेशन जोड़ें"
- "एनीमेशन प्राप्त करें"
- "एनीमेशन निकालें"
- "प्रभाव जोड़ें"
- "प्रभाव प्राप्त करें"
- "प्रभाव निकालें"
- "प्रभाव ध्वनि"
- "एनीमेशन लागू करें"
- "PowerPoint"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ आकार एनीमेशन, टाइमिंग, ध्वनियां, एनीमेशन के बाद व्यवहार, और एनिमेटेड टेक्स्ट को जोड़ना, निरीक्षण करना और अनुकूलित करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for C++ स्लाइड एनीमेशन को स्लाइड टाइमलाइन में इफ़ेक्ट्स के रूप में दर्शाता है। एक इफ़ेक्ट में लक्ष्य आकार, एनीमेशन प्रकार और उपप्रकार, ट्रिगर, टाइमिंग सेटिंग्स, तथा वैकल्पिक गुण जैसे ध्वनि या एनीमेशन के बाद का व्यवहार होते हैं।

टाइमलाइन में दो प्रकार के सिक्वेंस होते हैं:

- **मुख्य सिक्वेंस** स्लाइड आगे बढ़ने के साथ चलता है।
- **इंटरैक्टिव सिक्वेंस** तब शुरू होता है जब उसका ट्रिगर शेप क्लिक किया जाता है।

क्योंकि टेक्स्ट बॉक्स, चित्र, चार्ट, टेबल, और अन्य स्लाइड ऑब्जेक्ट्स [IShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/) को लागू करते हैं, आप अधिकांश स्लाइड कंटेंट के लिए वही [ISequence::AddEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/addeffect/) मेथड उपयोग करते हैं। उपलब्ध इफ़ेक्ट्स [EffectType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/effecttype/) एन्यूमरेशन में सूचीबद्ध हैं।

## **आकार एनीमेशन जोड़ें**

एक एनीमेशन जोड़ने के लिए, स्लाइड के मुख्य सिक्वेंस को प्राप्त करें और लक्ष्य आकार, इफ़ेक्ट प्रकार, उपप्रकार, तथा ट्रिगर के साथ [ISequence::AddEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/addeffect/) को कॉल करें। अन्य शेप पर क्लिक करने पर शुरू होने वाले इफ़ेक्ट के लिए, एक इंटरैक्टिव सिक्वेंस बनाएं जिसका ट्रिगर वह दूसरा शेप हो।

निम्नलिखित उदाहरण दोनों प्रकार के एनीमेशन बनाता है और परिणाम को `shape-animations.pptx` में सहेजता है।

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Click to animate this shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
auto entranceEffect = mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
entranceEffect->get_Timing()->set_Duration(1.5f);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

presentation->Save(u"shape-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ट्रिगर नियंत्रित करता है कि इफ़ेक्ट कब शुरू होता है:

- [EffectTriggerType::OnClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/effecttriggertype/) मुख्य अनुक्रम में क्लिक की प्रतीक्षा करता है, या इंटरैक्टिव अनुक्रम में ट्रिगर शेप पर क्लिक की।
- [EffectTriggerType::WithPrevious](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/effecttriggertype/) पिछले इफ़ेक्ट के साथ शुरू होता है।
- [EffectTriggerType::AfterPrevious](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/effecttriggertype/) पिछले इफ़ेक्ट के समाप्त होने पर शुरू होता है।

चित्र, चार्ट, या किसी अन्य शेप प्रकार को एनीमेट करने के लिए, `targetShape` के स्थान पर उस ऑब्जेक्ट को [ISequence::AddEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/addeffect/) में पास करें। चार्ट-विशिष्ट ग्रुपिंग विकल्पों के लिए देखें [Animated Charts](/slides/hi/cpp/animated-charts/)।

## **आकार एनीमेशन पढ़ें**

जब आपको लक्ष्य शेप पता हो तो [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) का उपयोग करें। प्रत्येक इफ़ेक्ट का निरीक्षण करने के लिए, मुख्य सिक्वेंस और सभी इंटरैक्टिव सिक्वेंस को एनीमेट करें। एनीमेट करने से यह अनुमान लगाना बचता है कि अनुक्रम में इंडेक्स `0` पर कोई इफ़ेक्ट मौजूद है।

निम्नलिखित उदाहरण मुख्य‑सिक्वेंस और इंटरैक्टिव इफ़ेक्ट्स के साथ एक शेप बनाता है, शेप को लक्षित करने वाले इफ़ेक्ट्स प्राप्त करता है, और फिर स्लाइड पर सभी सिक्वेंस को एनीमेट करता है।

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto printSequence = [](const String& label, const SharedPtr<ISequence>& sequence)
{
    Console::WriteLine(String::Format(u"  {0}: {1} effect(s)", label, sequence->get_Count()));

    for (const auto& effect : sequence)
    {
        auto targetName = effect->get_TargetShape() == nullptr ? u"unknown" : effect->get_TargetShape()->get_Name();
        auto effectDescription = String::Format(u"{0} {1}; target: {2}; trigger: {3}", effect->get_Type(), effect->get_Subtype(), targetName, effect->get_Timing()->get_TriggerType());
        Console::WriteLine(u"    " + effectDescription);
    }
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto targetShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
targetShape->get_TextFrame()->set_Text(u"Animated shape");

auto mainSequence = slide->get_Timeline()->get_MainSequence();
mainSequence->AddEffect(targetShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto triggerShape = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 20.0f, 20.0f, 100.0f, 40.0f);
triggerShape->get_TextFrame()->set_Text(u"Move");

auto interactiveSequence = slide->get_Timeline()->get_InteractiveSequences()->Add(triggerShape);
interactiveSequence->AddEffect(targetShape, EffectType::PathFootball, EffectSubtype::None, EffectTriggerType::OnClick);

auto targetEffects = mainSequence->GetEffectsByShape(targetShape);
Console::WriteLine(String::Format(u"The main sequence contains {0} effect(s) for {1}.", targetEffects->get_Length(), targetShape->get_Name()));

printSequence(u"Main sequence", mainSequence);

int32_t interactiveIndex = 1;
for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
{
    auto triggerName = sequence->get_TriggerShape() == nullptr ? u"unknown" : sequence->get_TriggerShape()->get_Name();
    auto sequenceLabel = String::Format(u"Interactive sequence {0}, trigger: {1}", interactiveIndex, triggerName);
    printSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

presentation->Dispose();
```

यदि आपको केवल एक शेप के लिए इफ़ेक्ट्स चाहिए, तो पहले शेप को नाम, प्लेसहोल्डर प्रकार, या अन्य स्थिर प्रॉपर्टी के आधार पर पहचानें; फिर [ISequence::GetEffectsByShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/geteffectsbyshape/) को कॉल करें। यह मान न लगाएँ कि [IShapeCollection::idx_get](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/idx_get/) इंडेक्स `0` पर हमेशा इच्छित ऑब्जेक्ट है।

## **विरासत प्राप्त प्लेसहोल्डर इफ़ेक्ट्स के साथ काम करें**

सामान्य स्लाइड पर एक प्लेसहोल्डर अपने लेआउट स्लाइड और मास्टर स्लाइड पर संबंधित प्लेसहोल्डर से एनीमेशन व्यवहार विरासत में ले सकता है। [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/getbaseplaceholder/) वह पैरेंट प्लेसहोल्डर लौटाता है, या जब कोई पैरेंट न हो तो `nullptr`।

निम्नलिखित उदाहरण प्रस्तुति में फुटर के पास सामान्य स्लाइड पर **Random Bars**, लेआउट स्लाइड पर **Split**, और मास्टर स्लाइड पर **Fly In** हैं।

![सामान्य स्लाइड पर फुटर एनीमेशन इफ़ेक्ट](slide-shape-animation.png)

![लेआउट स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](layout-shape-animation.png)

![मास्टर स्लाइड पर फुटर प्लेसहोल्डर एनीमेशन इफ़ेक्ट](master-shape-animation.png)

अगला उदाहरण स्वयं प्लेसहोल्डर पदानुक्रम बनाता है। यह मास्टर प्लेसहोल्डर, लेआउट प्लेसहोल्डर, और सामान्य स्लाइड पर संबंधित प्लेसहोल्डर में इफ़ेक्ट्स जोड़ता है। प्रत्येक कॉल को [IShape::GetBasePlaceholder](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/getbaseplaceholder/) का उपयोग करने से पहले जांचा जाता है।

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto findPlaceholderWithBase = [](const SharedPtr<ISlide>& slide) -> SharedPtr<IShape>
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (shape->GetBasePlaceholder() != nullptr)
            return shape;
    }

    return nullptr;
};

auto printEffects = [](const String& source, const ArrayPtr<SharedPtr<IEffect>>& effects)
{
    Console::WriteLine(String::Format(u"{0}: {1} effect(s)", source, effects->get_Length()));

    for (const auto& effect : effects)
        Console::WriteLine(String::Format(u"  {0} {1}", effect->get_Type(), effect->get_Subtype()));
};

auto presentation = MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto layoutPlaceholder = layoutSlide->get_PlaceholderManager()->AddTextPlaceholder(100.0f, 100.0f, 400.0f, 80.0f);
layoutSlide->get_Timeline()->get_MainSequence()->AddEffect(layoutPlaceholder, EffectType::Split, EffectSubtype::VerticalIn, EffectTriggerType::OnClick);

auto masterPlaceholder = layoutPlaceholder->GetBasePlaceholder();
if (masterPlaceholder != nullptr)
{
    auto masterSequence = layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence();
    masterSequence->AddEffect(masterPlaceholder, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
}

auto slide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto slidePlaceholder = findPlaceholderWithBase(slide);

if (slidePlaceholder == nullptr)
    throw InvalidOperationException(u"The slide does not contain a placeholder linked to its layout slide.");

slide->get_Timeline()->get_MainSequence()->AddEffect(slidePlaceholder, EffectType::RandomBars, EffectSubtype::Horizontal, EffectTriggerType::OnClick);
printEffects(u"Normal slide", slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(slidePlaceholder));

auto baseLayoutPlaceholder = slidePlaceholder->GetBasePlaceholder();
if (baseLayoutPlaceholder != nullptr)
{
    printEffects(u"Layout slide", layoutSlide->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseLayoutPlaceholder));

    auto baseMasterPlaceholder = baseLayoutPlaceholder->GetBasePlaceholder();
    if (baseMasterPlaceholder != nullptr)
        printEffects(u"Master slide", layoutSlide->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(baseMasterPlaceholder));
}

presentation->Save(u"placeholder-animations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **एनीमेशन टाइमिंग बदलें**

PowerPoint **Timing** संवाद को [ITiming](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/) की मेथड्स से मैप किया जाता है।

![एनीमेशन इफ़ेक्ट के लिए PowerPoint टाइमिंग डायलॉग](shape-animation.png)

- **Start** को [ITiming::set_TriggerType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_triggertype/) से मैप किया जाता है।
- **Duration** को [ITiming::set_Duration](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_duration/) से मैप किया जाता है, सेकंड में।
- **Delay** को [ITiming::set_TriggerDelayTime](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_triggerdelaytime/) से मैप किया जाता है, सेकंड में।
- **Repeat** को [ITiming::set_RepeatCount](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_repeatcount/), [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/), या [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) से मैप किया जाता है।
- **Rewind when done playing** को [ITiming::set_Rewind](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_rewind/) से मैप किया जाता है।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट जोड़ता है, [ISequence::AddEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट के माध्यम से उसका टाइमिंग बदलता है, और परिणाम को सहेजता है। लौटाए गए [IEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/) रेफ़रेंस को बनाए रखने से अनावश्यक कलेक्शन इंडेक्स से बचा जाता है।

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Timed animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_Timing()->set_TriggerType(EffectTriggerType::OnClick);
effect->get_Timing()->set_Duration(2.0f);
effect->get_Timing()->set_TriggerDelayTime(0.5f);
effect->get_Timing()->set_RepeatUntilNextClick(false);
effect->get_Timing()->set_RepeatUntilEndSlide(false);
effect->get_Timing()->set_RepeatCount(2.0f);
effect->get_Timing()->set_Rewind(true);

presentation->Save(u"shape-animation-timing.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

एक ही रिपीट मोड का जानबूझकर उपयोग करें। रिपीट काउंट को "until" फ़्लैग के साथ मिलाने से विभिन्न व्यूअर्स में भ्रमित परिणाम मिल सकते हैं। रिपीट मोड बदलते समय, पहले [ITiming::set_RepeatUntilNextClick](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_repeatuntilnextclick/) और [ITiming::set_RepeatUntilEndSlide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_repeatuntilendslide/) को कॉल करें, फिर [ITiming::set_RepeatCount](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itiming/set_repeatcount/) को, क्योंकि किसी भी फ़्लैग को सेट करने से सक्रिय रिपीट मोड बदल जाता है।

## **एनीमेशन साउंड जोड़ें और निकालें**

एक एनीमेशन इफ़ेक्ट एम्बेडेड ऑडियो को [IEffect::set_Sound](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_sound/) द्वारा संदर्भित कर सकता है। [IEffect::set_StopPreviousSound](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_stopprevioussound/) एक इफ़ेक्ट को बताता है कि वह पहले शुरू हुए ऑडियो को रोक दे।

### **एक इफ़ेक्ट में साउंड जोड़ें**

निम्नलिखित उदाहरण एक स्थानीय ऑडियो फ़ाइल `animation-sound.wav` की अपेक्षा करता है। यह दो इफ़ेक्ट बनाता है, पहली इफ़ेक्ट के लिए उस फ़ाइल को साउंड के रूप में एम्बेड करता है, और दूसरे इफ़ेक्ट को साउंड को रोकने के लिए कॉन्फ़िगर करता है। यह [ISequence::AddEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/addeffect/) द्वारा लौटाए गए ऑब्जेक्ट्स का उपयोग करता है, इसलिए सिक्वेंस इंडेक्स की ज़रूरत नहीं है।

```cpp
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 100.0f, 240.0f, 80.0f);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 400.0f, 100.0f, 240.0f, 80.0f);
firstShape->get_TextFrame()->set_Text(u"Starts sound");
secondShape->get_TextFrame()->set_Text(u"Stops sound");

auto sequence = slide->get_Timeline()->get_MainSequence();
auto firstEffect = sequence->AddEffect(firstShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
auto secondEffect = sequence->AddEffect(secondShape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

auto audioData = File::ReadAllBytes(u"animation-sound.wav");
auto effectSound = presentation->get_Audios()->AddAudio(audioData);
firstEffect->set_Sound(effectSound);
secondEffect->set_StopPreviousSound(true);

presentation->Save(u"shape-animation-sound.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **एम्बेडेड इफ़ेक्ट साउंड निकालें**

निम्नलिखित उदाहरण एक स्थानीय प्रस्तुति `presentation-with-animation-sounds.pptx` की अपेक्षा करता है। यह मुख्य और इंटरैक्टिव दोनों सिक्वेंस को स्कैन करता है और प्रत्येक एम्बेडेड इफ़ेक्ट साउंड को `extracted-animation-sounds` डायरेक्टरी में लिखता है। एक्सटेंशन ऑडियो MIME टाइप से चुना जाता है जो [IAudio::get_ContentType](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iaudio/get_contenttype/) द्वारा प्रदान किया जाता है।

```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;
using namespace System::IO;

auto getAudioExtension = [](const String& contentType)
{
    auto normalizedType = String::IsNullOrEmpty(contentType) ? String::Empty : contentType.ToLowerInvariant();

    if (normalizedType == u"audio/mpeg")
        return String(u".mp3");

    if (normalizedType == u"audio/mp4")
        return String(u".m4a");

    if (normalizedType == u"audio/ogg")
        return String(u".ogg");

    if (normalizedType == u"audio/wav" || normalizedType == u"audio/x-wav")
        return String(u".wav");

    return String(u".bin");
};

auto saveSounds = [&getAudioExtension](const SharedPtr<ISequence>& sequence, const String& outputDirectory, int32_t& soundIndex)
{
    for (const auto& effect : sequence)
    {
        if (effect->get_Sound() == nullptr)
            continue;

        auto extension = getAudioExtension(effect->get_Sound()->get_ContentType());
        auto outputPath = Path::Combine(outputDirectory, String::Format(u"effect-sound-{0}{1}", soundIndex, extension));
        File::WriteAllBytes(outputPath, effect->get_Sound()->get_BinaryData());
        soundIndex++;
    }
};

auto inputPath = String(u"presentation-with-animation-sounds.pptx");
auto outputDirectory = String(u"extracted-animation-sounds");

Directory::CreateDirectory_(outputDirectory);

auto presentation = MakeObject<Presentation>(inputPath);
int32_t soundIndex = 1;

for (const auto& slide : presentation->get_Slides())
{
    saveSounds(slide->get_Timeline()->get_MainSequence(), outputDirectory, soundIndex);

    for (const auto& sequence : slide->get_Timeline()->get_InteractiveSequences())
        saveSounds(sequence, outputDirectory, soundIndex);
}

Console::WriteLine(String::Format(u"Extracted {0} sound file(s) to {1}.", soundIndex - 1, Path::GetFullPath(outputDirectory)));
presentation->Dispose();
```

बड़ी ऑडियो ऑब्जेक्ट्स के लिए, [IAudio::GetStream](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iaudio/getstream/) का उपयोग करें और स्ट्रीम को फ़ाइल में कॉपी करें बजाय पूरी ऑब्जेक्ट को बाइट एरे में लोड किए।

## **एनीमेशन के बाद व्यवहार सेट करें**

**After animation** विकल्प नियंत्रित करता है कि इफ़ेक्ट समाप्त होने के बाद शेप के साथ क्या होता है।

![After animation सेटिंग्स दिखाते हुए PowerPoint इफ़ेक्ट ऑप्शन डायलॉग](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) एन्यूमरेशन शेप को unchanged छोड़ने, उसका रंग बदलने, एनीमेशन के बाद उसे छिपाने, या अगली क्लिक पर छिपाने का समर्थन करता है। जब प्रकार [AfterAnimationType::Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) हो, तो रंग सेट करने के लिए [IEffect::get_AfterAnimationColor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/get_afteranimationcolor/) को कॉल करें।

यह स्वतंत्र उदाहरण एक इफ़ेक्ट बनाता है, लौटाए गए इफ़ेक्ट ऑब्जेक्ट के माध्यम से उसके एनीमेशन‑के‑बाद व्यवहार को सेट करता है, और परिणाम को सहेजता है।

```cpp
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
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
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 120.0f, 100.0f, 320.0f, 80.0f);
shape->get_TextFrame()->set_Text(u"Dim after animation");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->set_AfterAnimationType(AfterAnimationType::Color);
effect->get_AfterAnimationColor()->set_Color(Color::get_LightGray());

presentation->Save(u"shape-animation-after-effect.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AfterAnimationType::Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/afteranimationtype/) से प्रकार बदलने पर एनीमेशन‑के‑बाद रंग सेटिंग साफ़ हो जाती है।

## **टेक्स्ट एनीमेट करें**

टेक्स्ट एनीमेशन में दो संबंधित कंट्रोल होते हैं:

- [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itextanimation/set_buildtype/) नियंत्रित करता है कि पैराग्राफ एक साथ दिखें या पैराग्राफ‑लेवल पर।
- [IEffect::set_AnimateTextType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) नियंत्रित करता है कि टेक्स्ट एक बार में, शब्द‑दर‑शब्द, या अक्षर‑दर‑अक्षर दिखे। [IEffect::set_DelayBetweenTextParts](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) शब्दों या अक्षरों के बीच देरी सेट करता है। सकारात्मक मान इफ़ेक्ट अवधि का प्रतिशत है; नकारात्मक मान सेकंड में देरी है।

निम्नलिखित स्वतंत्र उदाहरण टेक्स्ट बॉक्स में शब्दों को एनीमेट करता है। [BuildType::AsOneObject](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/buildtype/) पैराग्राफ‑दर‑पैराग्राफ निर्माण को निष्क्रिय करता है ताकि शब्द सेटिंग पूरे टेक्स्ट फ्रेम पर लागू हो।

```cpp
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 80.0f, 80.0f, 560.0f, 100.0f);
textBox->get_TextFrame()->set_Text(u"Aspose.Slides animates this sentence word by word.");

auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(textBox, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);
effect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);
effect->set_AnimateTextType(AnimateTextType::ByWord);
effect->set_DelayBetweenTextParts(20.0f);

presentation->Save(u"animated-text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

पैराग्राफ‑दर‑पैराग्राफ बॉक्स बनाने के लिए, [ITextAnimation::set_BuildType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/itextanimation/set_buildtype/) को [BuildType::ByLevelParagraphs1](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/buildtype/) या किसी अन्य पैराग्राफ लेवल के साथ उपयोग करें। एकल पैराग्राफ को अपने स्वयं के इफ़ेक्ट के साथ लक्षित करने के लिए, वह [ISequence::AddEffect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.animation/isequence/addeffect/) ओवरलोड उपयोग करें जो [IParagraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iparagraph/) को स्वीकार करता है। पैराग्राफ‑लेवल उदाहरणों के लिए देखें [Animated Text](/slides/hi/cpp/animated-text/)।

## **एक्सपोर्ट और संगतता नोट्स**

- PPT या PPTX में सहेजने से एनीमेशन मॉडल संरक्षित रहता है, लेकिन अंतिम प्लेबैक प्रस्तुति व्यूअर द्वारा नियंत्रित होता है।
- PDF और स्थिर छवियां एनीमेशन नहीं चलातीं। जब आउटपुट को मोशन दिखाना हो तो [HTML5 export](/slides/hi/cpp/export-to-html5/), एनीमेटेड GIF, या [video conversion](/slides/hi/cpp/convert-powerpoint-to-video/) का प्रयोग करें।
- HTML5 के लिए, [Html5Options::set_AnimateShapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animateshapes/) को सक्षम करें और आवश्यकता पड़ने पर [Html5Options::set_AnimateTransitions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/html5options/set_animatetransitions/) को भी।
- वीडियो रेंडरिंग कई सामान्य इंट्री, एम्फ़ेसिस, एक्सिट, और मोशन‑पाथ इफ़ेक्ट्स को सपोर्ट करता है, लेकिन सभी PowerPoint इफ़ेक्ट सपोर्टेड नहीं हैं। वर्तमान [supported animations and effects](/slides/hi/cpp/convert-powerpoint-to-video/#supported-animations-and-effects) देखें और अपने लक्षित Aspose.Slides संस्करण के साथ महत्वपूर्ण प्रस्तुतियों का परीक्षण करें।
- उन्नत कस्टम इफ़ेक्ट्स और अन्य फ़ॉर्मेट से आयातित इफ़ेक्ट्स फ़ाइल में संरक्षित रह सकते हैं लेकिन PowerPoint, HTML5, या वीडियो में अलग ढंग से रेंडर हो सकते हैं। केवल इफ़ेक्ट नाम पर भरोसा करने के बजाय एक्सपोर्टेड परिणाम को वैलिडेट करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**PowerPoint में एनीमेशन दिखाई देता है लेकिन PDF में नहीं, क्यों?**

PDF एक स्थिर फ़ॉर्मेट है, इसलिए एनीमेशन और स्लाइड ट्रांजिशन नहीं चलते। जब मोशन को बनाए रखना आवश्यक हो तो HTML5, एनीमेटेड GIF, या वीडियो में एक्सपोर्ट करें।

**वीडियो में इफ़ेक्ट अलग तरीके से क्यों चलता है?**

वीडियो एक्सपोर्ट एनीमेशन को रेंडर करता है न कि मूल PowerPoint व्यवहार को स्टोर करता है। कुछ उन्नत इफ़ेक्ट्स असमर्थित या अनुमानित होते हैं। समर्थित‑इफ़ेक्ट्स तालिका देखें और उत्पादन उपयोग से पहले वास्तविक प्रस्तुति का परीक्षण करें।

**क्या शेप को आगे या पीछे ले जाने से उसकी एनीमेशन क्रम बदलता है?**

नहीं। शेप का z‑order ओवरलैप नियंत्रित करता है, जबकि सिक्वेंस क्रम और ट्रिगर एनीमेशन प्लेबैक नियंत्रित करते हैं। यदि अलग प्लेबैक क्रम चाहिए तो टाइमलाइन बदलें।