---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 110
url: /hi/net/examples/elements/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन तक पहुंचें
- स्लाइड ट्रांज़िशन हटाएँ
- ट्रांज़िशन अवधि
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड ट्रांज़िशन की महारत: PPT, PPTX, और ODP प्रस्तुतियों के लिए C# उदाहरणों के साथ इफ़ेक्ट्स और अवधियों को जोड़ें, अनुकूलित करें, और क्रमबद्ध करें।"
---
यह लेख **Aspose.Slides for .NET** के साथ स्लाइड ट्रांज़िशन इफ़ेक्ट्स और टाइमिंग लागू करने का प्रदर्शन करता है।

## **स्लाइड ट्रांज़िशन जोड़ें**
पहली स्लाइड पर फ़ेड ट्रांज़िशन इफ़ेक्ट लागू करें।

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // फ़ेड ट्रांज़िशन लागू करें।
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **स्लाइड ट्रांज़िशन तक पहुंचें**
स्लाइड को वर्तमान में असाइन किए गए ट्रांज़िशन प्रकार को पढ़ें।

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // ट्रांज़िशन प्रकार तक पहुंचें।
    var type = slide.SlideShowTransition.Type;
}
```

## **स्लाइड ट्रांज़िशन हटाएँ**
`None` प्रकार सेट करके किसी भी ट्रांज़िशन इफ़ेक्ट को साफ़ करें।

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // ट्रांज़िशन को हटाएँ, none सेट करके।
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **ट्रांज़िशन अवधि सेट करें**
स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले कितनी देर तक प्रदर्शित होगा, यह निर्दिष्ट करें।

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // मिलीसेकंड में
}
```