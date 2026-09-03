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
- मोरफ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Aspose.Slides for C++ के साथ मोरफ़ और अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन नियंत्रित करता है कि स्लाइड शो के दौरान स्लाइड्स कैसे प्रदर्शित हों। Aspose.Slides for C++ के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट‑विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख C++ उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग को प्रबंधित करता है, और दो स्लाइड्स के बीच एक Morph ट्रांज़िशन बनाता है। उदाहरण दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, [प्रेजेंटेशन]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/]) क्लास का उपयोग करके प्रस्तुति लोड करें और [get_SlideShowTransition]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_slideshowtransition/]) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुंचें। [TransitionType]([https://reference.aspose.com/slides/hi/cpp/aspose.slides.slideshow/transitiontype/]) ए़न्यूमरेशन में से किसी मान के साथ [set_Type]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_type/]) को कॉल करें, फिर प्रस्तुति को सहेजें।

निम्नलिखित उदाहरण पहले स्लाइड पर **Circle** ट्रांज़िशन और दूसरे स्लाइड पर **Comb** ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

- [set_AdvanceOnClick]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_advanceonclick/]) दर्शक को माउस क्लिक करके आगे बढ़ने की अनुमति देता है।  
- [set_AdvanceAfter]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_advanceafter/]) स्वचालित आगे बढ़ने को सक्षम करता है।  
- [set_AdvanceAfterTime]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/]) स्वचालित आगे बढ़ने से पहले की देरी को मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों को सक्षम करें ताकि दर्शक क्लिक करके आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर उपयोग करने के लिए, [set_AdvanceOnClick] को `false` के साथ कॉल करें। विलंब स्लाइड शो के आगे बढ़ने के समय को नियंत्रित करता है; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि निर्धारित नहीं करता।

यह उदाहरण पहले तीन स्लाइडों को विभिन्न इफ़ेक्ट्स देता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वचालित आगे बढ़ने को सक्षम करता है। माउस क्लिक से भी इन स्लाइडों को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

यह जांचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [get_AdvanceAfter]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/get_advanceafter/]) को कॉल करें। केवल संग्रहीत देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, दो सेकंड से अधिक देरी वाली स्लाइड्स के लिए स्वचालित आगे बढ़ना अकार्यान्वित करता है, उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है, और अपडेटेड सेटिंग्स को सहेजता है।

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

ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई को मिलीसेकंड में निर्दिष्ट करने के लिए [set_Duration]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_duration/]) का उपयोग करें। स्लाइड की [get_SlideShowTransition]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/ibaseslide/get_slideshowtransition/]) मेथड इन सेटिंग्स को [ISlideShowTransition]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/]) के माध्यम से प्रकट करता है:

| मेथड | उद्देश्य |
| --- | --- |
| [set_Duration]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_duration/]) | ट्रांज़िशन इफ़ेक्ट की स्वयं की अवधि को मिलीसेकंड में सेट करता है। |
| [set_AdvanceAfterTime]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_advanceaftertime/]) | स्लाइड के स्वचालित आगे बढ़ने से पहले की देरी को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [set_AdvanceAfter] को `true` के साथ कॉल करें। |
| [set_Speed]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/set_speed/]) | [TransitionSpeed]([https://reference.aspose.com/slides/hi/cpp/aspose.slides.slideshow/transitionspeed/]) से पूर्वनिर्धारित गति श्रेणी (Slow, Medium, Fast) चुनता है। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[set_Duration] केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दिखाई दे। स्वचालित आगे बढ़ने की देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं की गई हो, तो Aspose.Slides ट्रांज़िशन प्रकार और [get_Speed] द्वारा लौटाए गए मान के आधार पर इफ़ेक्ट अवधि निर्धारित करता है।

### **हर स्लाइड पर समान अवधि लागू करें**

संगत गति के लिए, हर स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType] से **Fade** चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5,000 मिलीसेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

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

    // प्रभाव अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ना कॉन्फ़िगर करें।
    transition->set_AdvanceAfter(true);
    transition->set_AdvanceAfterTime(5000);
    transition->set_AdvanceOnClick(false);
}

presentation->Save(u"precise-transitions.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

### **व्यक्तिगत स्लाइड्स के लिए अलग-अलग अवधियां सेट करें**

विभिन्न स्लाइड्स विभिन्न इफ़ेक्ट अवधियों का उपयोग कर सकती हैं। उदाहरण के तौर पर, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहले स्लाइड को 500 मिलीसेकंड और दूसरे स्लाइड को 1,200 मिलीसेकंड की अवधि देता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन को समन्वयित करें**

जब आप [एनिमेटेड GIF](/slides/hi/cpp/convert-powerpoint-to-animated-gif/), [HTML5 प्रस्तुति](/slides/hi/cpp/export-to-html5/), या [वीडियो](/slides/hi/cpp/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि वांछित गति के साथ मेल बैठे। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का फ़ेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देरी को अलग से समायोजित करें ताकि उसका वर्णन या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 फ़्रेम प्रति सेकंड पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनीमेटेड ट्रांज़िशन को सक्षम करें। चयनित निर्यात फ़ॉर्मेट की समर्थित इफ़ेक्ट्स और टाइमिंग विकल्पों की जाँच करें, और सिंक्रनाइज़ेशन की पुष्टि करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [get_Duration]([https://reference.aspose.com/slides/hi/cpp/aspose.slides/islideshowtransition/get_duration/]) को कॉल करके देखें कि क्या स्पष्ट मान संग्रहीत है। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; गैर‑नकारात्मक मान मिलीसेकंड में संग्रहीत अवधि दर्शाता है। यह अपरिभाषित मान गणना किए गए प्लेबैक अवधि के बराबर नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [get_Speed] द्वारा लौटाए गए मान के आधार पर अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि इनिशियलाइज़ हो सकती है, इसलिए मूल सेटिंग्स की पहले जाँच करें।

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

Morph ट्रांज़िशन क्रमिक स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनीमेट करता है।

निम्नलिखित उदाहरण एक टेक्स्ट आयत के साथ स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति व आकार बदलता है। फिर दूसरी स्लाइड के लिए [TransitionType] से **Morph** चुनता है। Morph सपोर्ट करने वाले प्रस्तुति व्यूअर में सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान प्रभाव देखा जा सके।

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

[TransitionMorphType]([https://reference.aspose.com/slides/hi/cpp/aspose.slides.slideshow/transitionmorphtype/]) ए़न्यूमरेशन निर्धारित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject]([https://reference.aspose.com/slides/hi/cpp/aspose.slides.slideshow/transitionmorphtype/]) प्रत्येक आकार को एक पूर्ण वस्तु के रूप में मानता है।  
- [ByWord]([https://reference.aspose.com/slides/hi/cpp/aspose.slides.slideshow/transitionmorphtype/]) जहाँ संभव हो शब्दों के मिलान द्वारा पाठ का एनीमेशन करता है।  
- [ByChar]([https://reference.aspose.com/slides/hi/cpp/aspose.slides.slideshow/transitionmorphtype/]) जहाँ संभव हो अक्षरों के मिलान द्वारा पाठ का एनीमेशन करता है।

[Morph] के साथ [set_Type] को कॉल करें, फिर [get_Value] से प्राप्त [IMorphTransition] इंटरफ़ेस का उपयोग करके [set_MorphType] मेथड के माध्यम से मिलान मोड चुनें।

यह उदाहरण पिछले अनुभाग में बनाई गई प्रस्तुति को खोलता है और दूसरी स्लाइड को शब्द‑आधारित Morph एनीमेशन उपयोग करने के लिए कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या इफ़ेक्ट का काली स्क्रीन से शुरू होना। उपलब्ध विकल्प चयनित ट्रांज़िशन प्रकार पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर [get_Value] द्वारा लौटाए गए उपयुक्त इंटरफ़ेस का उपयोग करें।

निम्नलिखित उदाहरण `input.pptx` की पहली स्लाइड पर **Cut** ट्रांज़िशन लागू करता है। यह [IOptionalBlackTransition] के माध्यम से [set_FromBlack] को `true` सेट करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

## **FAQ**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [set_Duration] को प्राथमिकता दें। जब पूर्वनिर्धारित गति श्रेणी (Slow, Medium, Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट नहीं है, तो [set_Speed] का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने की देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूँ और उसे लूप करा सकता हूँ?**

हाँ। आप एम्बेडेड ऑडियो को [set_Sound] से असाइन कर सकते हैं, [TransitionSoundMode] से **StartSound** का उपयोग करके [set_SoundMode] को सेट करें, और [set_SoundLoop] से लूप को सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप होता रहेगा।

**हर स्लाइड पर समान ट्रांज़िशन लागू करने का तेज़तम तरीका क्या है?**

प्रेजेंटेशन के [get_Slides] मेथड द्वारा लौटाए गए संग्रह पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन पर समान मान के साथ [set_Type] को कॉल करें। वही लूप में टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि सभी स्लाइड्स में व्यवहार समान रहे।

**मैं कैसे जांचूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [get_SlideShowTransition] द्वारा लौटाए गए ट्रांज़िशन पर [get_Type] को कॉल करें। यह [TransitionType] ए़न्यूमरेशन से एक मान लौटाता है; **None** का अर्थ है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।