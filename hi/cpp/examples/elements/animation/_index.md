---
title: एनिमेशन
type: docs
weight: 100
url: /hi/cpp/examples/elements/animation/
keywords:
- कोड उदाहरण
- एनिमेशन
- पावरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ एनीमेशन उदाहरणों का अन्वेषण करें: C++ के साथ PPT, PPTX, और ODP प्रस्तुतियों के लिए प्रभाव और ट्रांज़िशन जोड़ें, क्रमबद्ध करें और अनुकूलित करें।"
---
यह लेख दिखाता है कि **Aspose.Slides for C++** का उपयोग करके सरल एनिमेशन कैसे बनाएं और उनकी क्रमबद्धता को कैसे प्रबंधित करें।

## **एनिमेशन जोड़ें**

एक आयताकार आकार बनाएं और क्लिक करने पर ट्रिगर होने वाला फ़ेड-इन इफ़ेक्ट लागू करें।

```cpp
static void AddAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    // फ़ेड प्रभाव।
    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```

## **एक एनिमेशन तक पहुँचें**

स्लाइड टाइमलाइन से पहला एनिमेशन इफ़ेक्ट प्राप्त करें।

```cpp
static void AccessAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // पहले एनीमेशन इफ़ेक्ट तक पहुँचें।
    auto effect = slide->get_Timeline()->get_MainSequenceEffect(0);

    presentation->Dispose();
}
```

## **एक एनिमेशन हटाएँ**

क्रम से एक एनिमेशन इफ़ेक्ट हटाएँ।

```cpp
static void RemoveAnimation()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);

    auto effect = slide->get_Timeline()->get_MainSequence()->AddEffect(
        shape, EffectType::Fade, EffectSubtype::None, EffectTriggerType::OnClick);

    // इफ़ेक्ट हटाएँ।
    slide->get_Timeline()->get_MainSequence()->Remove(effect);

    presentation->Dispose();
}
```

## **एनिमेशन अनुक्रम**

एकाधिक इफ़ेक्ट जोड़ें और दिखाएँ कि एनिमेशन किस क्रम में होते हैं।

```cpp
static void SequenceAnimations()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 100, 100);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 200, 50, 100, 100);

    auto sequence = slide->get_Timeline()->get_MainSequence();
    sequence->AddEffect(shape1, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);
    sequence->AddEffect(shape2, EffectType::Fly, EffectSubtype::Bottom, EffectTriggerType::OnClick);

    presentation->Dispose();
}
```