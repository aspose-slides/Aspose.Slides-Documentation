---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 110
url: /hi/cpp/examples/elements/slide-transition/
keywords:
- कोड उदाहरण
- स्लाइड ट्रांज़िशन
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ में स्लाइड ट्रांज़िशन को मास्टर करें: PPT, PPTX और ODP प्रस्तुतियों के लिए C++ उदाहरणों के साथ प्रभाव और अवधि को जोड़ें, कस्टमाइज़ करें और क्रमबद्ध करें।"
---
यह लेख स्लाइड ट्रांज़िशन प्रभाव और टाइमिंग को **Aspose.Slides for C++** के साथ लागू करने का प्रदर्शन करता है।

## **स्लाइड ट्रांज़िशन जोड़ें**

पहली स्लाइड पर फेड ट्रांज़िशन प्रभाव लागू करें।

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // एक फेड ट्रांज़िशन लागू करें।
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **स्लाइड ट्रांज़िशन तक पहुँचें**

किसी स्लाइड को वर्तमान में असाइन किए गए ट्रांज़िशन प्रकार को पढ़ें।

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // ट्रांज़िशन प्रकार तक पहुँचें।
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **स्लाइड ट्रांज़िशन हटाएँ**

ट्रांज़िशन प्रकार को `None` सेट करके किसी भी ट्रांज़िशन प्रभाव को साफ़ करें।

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // none सेट करके ट्रांज़िशन हटाएँ।
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **ट्रांज़िशन अवधि सेट करें**

स्वचालित रूप से आगे बढ़ने से पहले स्लाइड कितनी देर तक प्रदर्शित होगी, यह निर्दिष्ट करें।

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // मिलीसेकंड में।

    presentation->Dispose();
}
```