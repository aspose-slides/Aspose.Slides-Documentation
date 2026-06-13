---
title: ऑडियो
type: docs
weight: 70
url: /hi/net/examples/elements/audio/
keywords:
- ऑडियो
- ऑडियो फ्रेम
- ऑडियो जोड़ें
- ऑडियो तक पहुँचें
- ऑडियो हटाएँ
- ऑडियो प्लेबैक
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ऑडियो उदाहरणों की खोज करें: PPT, PPTX और ODP प्रस्तुतियों में ध्वनि को सम्मिलित, चलाएँ, ट्रिम करें और निकालें, स्पष्ट C# कोड के साथ।"
---
यह लेख दर्शाता है कि **Aspose.Slides for .NET** के साथ ऑडियो फ्रेम कैसे एम्बेड करें और प्लेबैक को नियंत्रित करें। निम्नलिखित उदाहरण बुनियादी ऑडियो संचालन दिखाते हैं।

## **ऑडियो फ्रेम जोड़ें**

एक खाली ऑडियो फ्रेम डालें जिसे बाद में एम्बेडेड ध्वनि डेटा रखने के लिए उपयोग किया जा सकता है।

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // एक खाली ऑडियो फ्रेम बनाएं (ऑडियो बाद में एम्बेड किया जाएगा).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **ऑडियो फ्रेम तक पहुँचें**

यह कोड स्लाइड पर पहला ऑडियो फ्रेम प्राप्त करता है।

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // स्लाइड पर पहला ऑडियो फ्रेम एक्सेस करें।
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **ऑडियो फ्रेम हटाएँ**

पहले जोड़े गए ऑडियो फ्रेम को हटाएँ।

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // ऑडियो फ्रेम हटाएँ।
    slide.Shapes.Remove(audioFrame);
}
```

## **ऑडियो प्लेबैक सेट करें**

स्लाइड दिखने पर ऑडियो फ्रेम को स्वचालित रूप से चलाने के लिए कॉन्फ़िगर करें।

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // स्लाइड प्रदर्शित होने पर स्वचालित रूप से चलाएँ।
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```