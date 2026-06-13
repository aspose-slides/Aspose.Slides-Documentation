---
title: एनीमेशन
type: docs
weight: 100
url: /hi/net/examples/elements/animation/
keywords:
  - एनीमेशन
  - एनीमेशन जोड़ें
  - एनीमेशन तक पहुंचें
  - एनीमेशन हटाएँ
  - एनीमेशन क्रम
  - कोड उदाहरण
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET के एनीमेशन उदाहरणों का अन्वेषण करें: C# का उपयोग करके PPT, PPTX और ODP प्रस्तुतियों के लिए इफ़ेक्ट और ट्रांज़िशन को जोड़ें, क्रमबद्ध करें और अनुकूलित करें।"
---
यह लेख दर्शाता है कि कैसे सरल एनीमेशन बनाएं और उनकी क्रमबद्धता को प्रबंधित करें **Aspose.Slides for .NET** का उपयोग करके।

## **एनीमेशन जोड़ें**
एक आयताकार आकार बनाएं और क्लिक पर ट्रिगर होने वाला फेड इफ़ेक्ट लागू करें।

```csharp
static void AddAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);

    // फ़ेड इफ़ेक्ट।
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
}
```

## **एनीमेशन तक पहुंचें**
स्लाइड टाइमलाइन से पहला एनीमेशन इफ़ेक्ट प्राप्त करें।

```csharp
static void AccessAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // पहले एनीमेशन इफ़ेक्ट तक पहुंचें।
    var effect = slide.Timeline.MainSequence[0];
}
```

## **एनीमेशन हटाएँ**
क्रम से एक एनीमेशन इफ़ेक्ट हटाएँ।

```csharp
static void RemoveAnimation()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // इफ़ेक्ट हटाएँ।
    slide.Timeline.MainSequence.Remove(effect);
}
```

## **एनीमेशन क्रमबद्ध करें**
कई इफ़ेक्ट जोड़ें और दिखाएँ कि एनीमेशन किस क्रम में होते हैं।

```csharp
static void SequenceAnimations()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 100, 100);
    var shape2 = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 200, 50, 100, 100);

    var sequence = slide.Timeline.MainSequence;
    sequence.AddEffect(shape1, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
    sequence.AddEffect(shape2, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}
```