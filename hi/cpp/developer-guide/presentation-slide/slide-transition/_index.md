---
title: C++ का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/cpp/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मॉरफ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड अग्रसरता को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **परिचय**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइडों के प्रदर्शित होने के तरीके को नियंत्रित करती हैं। Aspose.Slides for C++ के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट‑विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख C++ उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइडों के बीच एक Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें और [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) के माध्यम से किसी स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुँचें। [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) को [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enumeration से किसी मान के साथ बुलाएँ, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरी स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइडों वाला `input.pptx` फ़ाइल उपयोग करें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    presentation->get_Slide(0)->get_SlideShowTransition()->set_Type(TransitionType::Circle);
    presentation->get_Slide(1)->get_SlideShowTransition()->set_Type(TransitionType::Comb);

    presentation->Save(u"slide-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **व्हील ट्रांज़िशन**

[IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) का [set_Spokes](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/set_spokes/) मेथड यह नियंत्रित करता है कि लक्ष्य स्लाइड को दर्शाने वाले रेडियल सेक्टरों की संख्या कितनी है। [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) से Wheel को चुनने के बाद [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) बुलाएँ, फिर [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) को [IWheelTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/iwheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान स्लाइड जोड़े बनाता है: एक काली स्लाइड और उसके बाद एक सुनहरी आयत वाली स्लाइड। लक्ष्य स्लाइडों में स्पोक काउंट क्रमशः 1 और 8 है, सभी में समान गति [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) द्वारा सेट है और स्पष्ट अवधि 8 000 मिलीसेकंड [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) के माध्यम से सेट है ताकि अंतर आसानी से देखा जा सके।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/IWheelTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
#include <cstdint>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();
auto slideWidth = presentation->get_SlideSize()->get_Size().get_Width();
auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();

auto blackSlide = presentation->get_Slide(0);
blackSlide->get_Shapes()->Clear();
blackSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
blackSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
blackSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

auto destinationSlide = presentation->get_Slides()->AddClone(blackSlide);
auto rectangle = destinationSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, slideWidth, slideHeight);
rectangle->get_FillFormat()->set_FillType(FillType::Solid);
rectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gold());
rectangle->get_TextFrame()->set_Text(u"Wheel transition");

presentation->get_Slides()->AddClone(blackSlide);
presentation->get_Slides()->AddClone(destinationSlide);

const uint32_t spokeCounts[] = { 1, 8 };
for (auto i = 0; i < 2; i++)
{
    auto transition = presentation->get_Slide(i * 2 + 1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Wheel);
    auto wheelTransition = ExplicitCast<IWheelTransition>(transition->get_Value());
    wheelTransition->set_Spokes(spokeCounts[i]);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(8000);
}

presentation->Save(u"wheel-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2, फिर स्लाइड 3 से स्लाइड 4 तक आगे बढ़ें। PowerPoint प्लेबैक में, सत्यापित स्पोक काउंट 1 स्लाइड को एक घड़ी‑दिशा स्विप से दिखाता है; सत्यापित काउंट 8 स्लाइड को एक साथ आठ रेडियल सेक्टरों से दिखाता है। लक्ष्य सामग्री और ट्रांज़िशन टाइमिंग समान है, इसलिए अंतर केवल प्रदर्शित सेक्टरों की संख्या है।

## **Fade Through Black with the Reveal Transition**

लक्ष्य स्लाइड का ट्रांज़िशन प्रकार Reveal सेट करें, फिर [IRevealTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/) इंटरफ़ेस पर [set_ThroughBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/irevealtransition/set_throughblack/) को बुलाएँ। यह उदाहरण एक टील स्रोत स्लाइड और एक कोरल लक्ष्य स्लाइड बनाता है, फिर दोनों को क्लोन करता है ताकि आप दो‑सेकंड ट्रांज़िशन को ThroughBlack निष्क्रिय और सक्रिय दोनों स्थितियों में तुलना कर सकें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IBackground.h>
#include <DOM/BackgroundType.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/SlideShowTransition/IRevealTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionLeftRightDirectionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>

using namespace System;
using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto styleSlide = [](SharedPtr<ISlide> slide, Color background, const String& label)
{
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
    auto fill = slide->get_Background()->get_FillFormat();
    fill->set_FillType(FillType::Solid);
    fill->get_SolidFillColor()->set_Color(background);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 160, 180, 400, 130);
    auto textFrame = shape->get_TextFrame();
    textFrame->set_Text(label);
    textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_FontHeight(44);
};

auto presentation = MakeObject<Presentation>();

auto source = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddClone(source);
styleSlide(source, Color::get_Teal(), u"Source");
styleSlide(destination, Color::get_Coral(), u"Destination");
presentation->get_Slides()->AddClone(source);
presentation->get_Slides()->AddClone(destination);

for (auto index : {1, 3})
{
    auto transition = presentation->get_Slide(index)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Reveal);
    transition->set_Speed(TransitionSpeed::Slow);
    transition->set_Duration(2000);

    auto reveal = ExplicitCast<IRevealTransition>(transition->get_Value());
    reveal->set_Direction(TransitionLeftRightDirectionType::Left);
    reveal->set_ThroughBlack(index == 3);
}

presentation->Save(u"reveal-transitions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

PowerPoint स्लाइड शो में, स्लाइड 1 से स्लाइड 2 तक आगे बढ़ें। टील सीधे कोरल में फेड होता है। फिर स्लाइड 3 से स्लाइड 4 तक आगे बढ़ें। स्क्रीन थोड़ी देर के लिए काली जैसी हो जाती है, फिर कोरल स्लाइड दिखाई देती है। दोनों स्लाइड अपनी मूल पृष्ठभूमि रंग बनाए रखती हैं।

नीचे की पंक्तियों में आधे‑सेकंड अंतराल पर PowerPoint के फ्रेम दिखाए गए हैं। प्रत्येक पंक्ति का मध्य फ्रेम देखें ताकि सेटिंग का प्रभाव समझ सकें।

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाता है। निम्न मेथड्स इस व्यवहार को नियंत्रित करते हैं:

- [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) दर्शक को माउस क्लिक से आगे बढ़ने की अनुमति देता है।
- [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) स्वतः आगे बढ़ने को सक्षम करता है।
- [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) स्वतः आगे बढ़ने से पहले विलंब को मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों अग्रसरता को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर उपयोग करने के लिए, `false` के साथ [set_AdvanceOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceonclick/) बुलाएँ। विलंब नियंत्रित करता है कि स्लाइड शो कब आगे बढ़े; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करता।

यह उदाहरण पहले तीन स्लाइडों को विभिन्न इफ़ेक्ट देता है और क्रमशः 3, 5, 7 सेकंड बाद स्वतः आगे बढ़ना सक्षम करता है। माउस क्लिक से भी इन स्लाइडों को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइडों वाली `input.pptx` फ़ाइल उपयोग करें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 3)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Circle);
    firstTransition->set_AdvanceOnClick(true);
    firstTransition->set_AdvanceAfter(true);
    firstTransition->set_AdvanceAfterTime(3000);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Comb);
    secondTransition->set_AdvanceOnClick(true);
    secondTransition->set_AdvanceAfter(true);
    secondTransition->set_AdvanceAfterTime(5000);

    auto thirdTransition = presentation->get_Slide(2)->get_SlideShowTransition();
    thirdTransition->set_Type(TransitionType::Zoom);
    thirdTransition->set_AdvanceOnClick(true);
    thirdTransition->set_AdvanceAfter(true);
    thirdTransition->set_AdvanceAfterTime(7000);

    presentation->Save(u"advanced-transitions.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least three slides.");
}

presentation->Dispose();
```

टाइम्ड अग्रसरता सक्षम है या नहीं, यह जांचने के लिए [get_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_advanceafter/) बुलाएँ। केवल संग्रहीत विलंब यह संकेत नहीं देता कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइडों के लिए स्वतः अग्रसरता को निष्क्रिय करता है। उन स्लाइडों के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"advanced-transitions.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();

    if (transition->get_AdvanceAfter())
    {
        Console::WriteLine(u"Slide {0}: advance after {1} ms.", slide->get_SlideNumber(), transition->get_AdvanceAfterTime());

        if (transition->get_AdvanceAfterTime() > 2000)
        {
            transition->set_AdvanceAfter(false);
            transition->set_AdvanceOnClick(true);
        }
    }
}

presentation->Save(u"adjusted-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **ट्रांज़िशन टाइमिंग को सटीक रूप से नियंत्रित करें**

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) का प्रयोग करके आप ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई मिलिसेकंड में निर्दिष्ट कर सकते हैं। स्लाइड की [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) मेथड इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/) के माध्यम से उजागर करती है:

| विधि | उद्देश्य |
| --- | --- |
| [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) | ट्रांज़िशन इफ़ेक्ट की अवधि को मिलिसेकंड में सेट करता है। |
| [set_AdvanceAfterTime](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/) | स्लाइड के स्वतः आगे बढ़ने से पहले का विलंब मिलिसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए `true` के साथ [set_AdvanceAfter](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_advanceafter/) बुलाएँ। |
| [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) | [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) enumeration से पूर्वनिर्धारित गति श्रेणी (Slow, Medium, Fast) चुनता है। जब सटीक अवधि निर्दिष्ट नहीं होती, तब इसका प्रयोग होता है। |

[set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह नहीं तय करता कि स्लाइड कितनी देर दिखाई दे। स्वतः अग्रसरता विलंब को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि नहीं सेट होती, Aspose.Slides ट्रांज़िशन प्रकार और [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) द्वारा लौटाए गए मान से इफ़ेक्ट अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750‑ms transition duration and 5,000‑ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*साझा उदाहरण प्रत्येक स्लाइड को 750 ms Fade ट्रांज़िशन देता है और अलग से 5 000 ms पर स्वतः अग्रसरता सक्रिय करता है। ट्रांज़िशन अवधि इफ़ेक्ट को नियंत्रित करती है; अग्रसरता इस बात को नियंत्रित करती है कि कब स्लाइड छोड़ी जाए। ये बार स्कीमैटिक सेटिंग्स हैं, न कि मापी गई संयुक्त टाइमलाइन।*
<!-- visual-explanation:slide-transition:end -->

### **सभी स्लाइडों के लिए समान अवधि लागू करें**

सुसंगत गति के लिए, सभी स्लाइडों पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 ms की अवधि देता है। यह अलग से 5 000 ms पर स्वतः अग्रसरता सक्षम करता है और माउस क्लिक द्वारा अग्रसरता को निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    transition->set_Type(TransitionType::Fade);
    transition->set_Duration(750);

    // प्रभाव की अवधि से स्वतंत्र रूप से स्वचालित अग्रसरता को कॉन्फ़िगर करें।
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **विकल्‍पिक स्लाइडों के लिए अलग‑अलग अवधि सेट करें**

विभिन्न स्लाइडें अलग‑अलग इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए छोटी अवधि और अनुभाग परिचय के लिए लंबी अवधि सेट करें। यह उदाहरण पहली स्लाइड को 500 ms और दूसरी स्लाइड को 1 200 ms की अवधि देता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल उपयोग करें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto firstTransition = presentation->get_Slide(0)->get_SlideShowTransition();
    firstTransition->set_Type(TransitionType::Fade);
    firstTransition->set_Duration(500);

    auto secondTransition = presentation->get_Slide(1)->get_SlideShowTransition();
    secondTransition->set_Type(TransitionType::Push);
    secondTransition->set_Duration(1200);

    presentation->Save(u"individual-transition-durations.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब आप [animated GIF](/slides/hi/cpp/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/cpp/export-to-html5/), या [video](/slides/hi/cpp/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि मनचाही गति बनी रहे। उदाहरण के लिए, दृश्यों के बीच 600 ms फेड उपयोग करें, और प्रत्येक स्लाइड की अग्रसरता विलंब को अलग‑अलग समायोजित करें ताकि उसकी कथा या सामग्री के लिए पर्याप्त समय मिले।

GIF और वीडियो के लिए, आउटपुट फ्रेम‑रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 ms 30 fps पर 18 फ़्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने गये निर्यात फ़ॉर्मेट के समर्थन किए गये इफ़ेक्ट और टाइमिंग विकल्पों की जाँच करें, और सिंक्रनाइज़ेशन की पुष्टि के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूद ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले, मौजूदा अवधि निर्धारित करने के लिये [get_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_duration/) बुलाएँ। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; एक गैर‑नकारात्मक मान मिलिसेकंड में संग्रहीत अवधि को दर्शाता है। इस न सेट मान को प्लेबैक की गणना‑की‑गई अवधि नहीं माना जाना चाहिए: Aspose.Slides ट्रांज़िशन प्रकार और [get_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_speed/) द्वारा लौटाए गए मान से वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से एक अवधि प्रारंभ हो सकती है, इसलिए पहले मूल सेटिंग्स की जांच करें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <DOM/SlideShowTransition/TransitionSpeed.h>
#include <system/console.h>

using namespace System;
using namespace Aspose::Slides;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto&& slide : presentation->get_Slides())
{
    auto transition = slide->get_SlideShowTransition();
    auto duration = transition->get_Duration();

    if (duration >= 0)
    {
        Console::WriteLine(u"Slide {0}: stored transition duration is {1} ms.", slide->get_SlideNumber(), duration);
    }
    else
    {
        Console::WriteLine(u"Slide {0}: no explicit duration; timing depends on {1} and {2}.", slide->get_SlideNumber(), transition->get_Type(), transition->get_Speed());
    }
}

presentation->Dispose();
```

## **Morph ट्रांज़िशन**

Morph ट्रांज़िशन क्रमिक स्लाइडों पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। सरल Morph इफ़ेक्ट बनाने के लिये, एक स्लाइड को क्लोन करें, क्लोन पर वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे संबंधित वस्तुओं को उनके मूल और संशोधित अवस्था के बीच एनीमेट किया जाता है।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, उसे क्लोन करता है, और क्लोन पर आयत की स्थिति व आकार बदलता है। फिर दो‑री स्लाइड के लिये [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enumeration से Morph चुनता है। फ़ाइल को ऐसे प्रस्तुति व्युअर में खोलें जो Morph को समर्थन देता हो, ताकि स्लाइड शो के दौरान प्रभाव देख सकें।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto rectangle = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
rectangle->get_TextFrame()->set_Text(u"Morph transition");

auto secondSlide = presentation->get_Slides()->AddClone(firstSlide);
auto movedRectangle = secondSlide->get_Shape(0);
movedRectangle->set_X(movedRectangle->get_X() + 100);
movedRectangle->set_Y(movedRectangle->get_Y() + 50);
movedRectangle->set_Width(movedRectangle->get_Width() - 200);
movedRectangle->set_Height(movedRectangle->get_Height() - 10);

secondSlide->get_SlideShowTransition()->set_Type(TransitionType::Morph);

presentation->Save(u"morph-transition.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Morph ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) enumeration यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) प्रत्येक आकार को एक पूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो, शब्दों के मेल से टेक्स्ट को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो, वर्णों के मेल से टेक्स्ट को एनीमेट करता है।

Morph को चुनने के लिये, दूसरे स्लाइड पर [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) को Morph के साथ बुलाएँ, फिर [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) एक्सेस करें। यह मान [IMorphTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/) इंटरफ़ेस प्रदान करता है, जिसका [set_MorphType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/imorphtransition/set_morphtype/) मेथड मिलान मोड चुनता है।

यह उदाहरण पिछले भाग में बनाई गई प्रस्तुति खोलता है और दूसरे स्लाइड को शब्द‑आधारित Morph एनीमेशन के लिये कॉन्फ़िगर करता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IMorphTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionMorphType.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"morph-transition.pptx");

if (presentation->get_Slides()->get_Count() >= 2)
{
    auto transition = presentation->get_Slide(1)->get_SlideShowTransition();
    transition->set_Type(TransitionType::Morph);

    auto morphTransition = AsCast<IMorphTransition>(transition->get_Value());
    if (morphTransition != nullptr)
    {
        morphTransition->set_MorphType(TransitionMorphType::ByWord);
        presentation->Save(u"morph-by-word.pptx", SaveFormat::Pptx);
    }
    else
    {
        Console::WriteLine(u"Morph transition options are unavailable.");
    }
}
else
{
    Console::WriteLine(u"The input presentation must contain at least two slides.");
}

presentation->Dispose();
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करती हैं, जैसे दिशा या क्या इफ़ेक्ट काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प चयनित ट्रांज़िशन प्रकार पर निर्भर होते हैं। पहले प्रकार सेट करें, फिर [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_value/) द्वारा लौटाए गये उपयुक्त इंटरफ़ेस का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [IOptionalBlackTransition](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/) के माध्यम से `true` के साथ [set_FromBlack](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/ioptionalblacktransition/set_fromblack/) बुलाता है, जिससे ट्रांज़िशन काली स्क्रीन से शुरू होता है।

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideShowTransition.h>
#include <DOM/SlideShowTransition/IOptionalBlackTransition.h>
#include <DOM/SlideShowTransition/ITransitionValueBase.h>
#include <DOM/SlideShowTransition/TransitionType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::SlideShow;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto transition = presentation->get_Slide(0)->get_SlideShowTransition();
transition->set_Type(TransitionType::Cut);

auto cutTransition = AsCast<IOptionalBlackTransition>(transition->get_Value());
if (cutTransition != nullptr)
{
    cutTransition->set_FromBlack(true);
    presentation->Save(u"cut-from-black.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Cut transition options are unavailable.");
}

presentation->Dispose();
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलिसेकंड में सटीक इफ़ेक्ट अवधि चाहिए, तो [set_Duration](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_duration/) उपयोग करें। यदि पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionspeed/) (Slow, Medium, Fast) पर्याप्त है और स्पष्ट अवधि सेट नहीं है, तो [set_Speed](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_speed/) प्रयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वतः अग्रसरता विलंब से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन पर ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?**

हाँ। एम्बेडेड ऑडियो को [set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_sound/) से असाइन करें, फिर [set_SoundMode](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundmode/) को [TransitionSoundMode](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitionsoundmode/) enumeration से StartSound के साथ बुलाएँ, और [set_SoundLoop](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_soundloop/) के द्वारा लूप सक्षम करें। ऑडियो अगली ध्वनि घटना तक लूप करता रहेगा।

**सभी स्लाइडों पर एक ही ट्रांज़िशन लागू करने का तेज़ तरीका क्या है?**

प्रस्तुति के [get_Slides](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_slides/) मेथड द्वारा लौटाए गए संग्रह को लूप करें और प्रत्येक स्लाइड के ट्रांज़िशन पर समान मान के साथ [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/set_type/) बुलाएँ। समान लूप में आवश्यक सभी टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि व्यवहार सभी स्लाइडों में सुसंगत रहे।

**मैं कैसे जांचूँ कि वर्तमान में किसी स्लाइड पर कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [get_SlideShowTransition](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideshowtransition/) मेथड द्वारा लौटाए गए ट्रांज़िशन पर [get_Type](https://reference.aspose.com/slides/cpp/aspose.slides/islideshowtransition/get_type/) बुलाएँ। यह [TransitionType](https://reference.aspose.com/slides/cpp/aspose.slides.slideshow/transitiontype/) enumeration से एक मान लौटाता है; None का अर्थ है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।