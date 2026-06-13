---
title: ऑडियो
type: docs
weight: 70
url: /hi/cpp/examples/elements/audio/
keywords:
- कोड उदाहरण
- ऑडियो
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ऑडियो उदाहरणों की खोज करें: PPT, PPTX और ODP प्रस्तुतियों में ध्वनि को डालें, चलाएँ, ट्रिम करें और निकालें, स्पष्ट C++ कोड के साथ।"
---
यह लेख दर्शाता है कि कैसे ऑडियो फ्रेम को एम्बेड किया जाए और **Aspose.Slides for C++** के साथ प्लेबैक को नियंत्रित किया जाए। निम्नलिखित उदाहरण मूलभूत ऑडियो ऑपरेशन्स दर्शाते हैं।

## **ऑडियो फ्रेम जोड़ें**

एक खाली ऑडियो फ्रेम सम्मिलित करें जो बाद में एम्बेडेड ध्वनि डेटा रख सके।

```cpp
static void AddAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // एक खाली ऑडियो फ्रेम बनाएं (ऑडियो बाद में एम्बेड किया जाएगा)।
    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    presentation->Dispose();
}
```

## **ऑडियो फ्रेम तक पहुँचें**

यह कोड स्लाइड पर पहला ऑडियो फ्रेम पुनः प्राप्त करता है।

```cpp
static void AccessAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // स्लाइड पर पहला ऑडियो फ्रेम प्राप्त करें।
    auto firstAudio = SharedPtr<IAudioFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAudioFrame>(shape))
        {
            firstAudio = ExplicitCast<IAudioFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **ऑडियो फ्रेम हटाएँ**

पहले जोड़े गए ऑडियो फ्रेम को हटाएँ।

```cpp
static void RemoveAudio()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // ऑडियो फ्रेम को हटाएँ।
    slide->get_Shapes()->Remove(audioFrame);

    presentation->Dispose();
}
```

## **ऑडियो प्लेबैक सेट करें**

स्लाइड प्रदर्शित होने पर ऑडियो फ्रेम को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```cpp
static void SetAudioPlayback()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, MakeObject<MemoryStream>());

    // स्लाइड दिखाई देने पर स्वचालित रूप से चलाएँ।
    audioFrame->set_PlayMode(AudioPlayModePreset::Auto);

    presentation->Dispose();
}
```