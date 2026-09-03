---
title: ".NET में प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें"
linktitle: "स्लाइड ट्रांज़िशन"
type: docs
weight: 90
url: /hi/net/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मोर्फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- पॉवरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ना कॉन्फ़िगर करें, और मोर्फ तथा अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **परिचय**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइडों के प्रकट होने के तरीके को नियंत्रित करते हैं। Aspose.Slides for .NET के साथ, आप प्रत्येक स्लाइड के लिए ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने की व्यवस्था कर सकते हैं, और इफ़ेक्ट विशेष विकल्पों को समायोजित कर सकते हैं। यह लेख C# उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड समय प्रबंधन करता है, और दो स्लाइडों के बीच Morph ट्रांज़िशन बनाता है। उदाहरण दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) क्लास का उपयोग करके प्रेजेंटेशन लोड करें और स्लाइड की [SlideShowTransition](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/slideshowtransition/) प्रॉपर्टी तक पहुंचें। उसकी [Type](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitiontype/) एनेमरेशन में से किसी मान पर सेट करें, फिर प्रेजेंटेशन सहेजें।

निम्नलिखित उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    presentation.Save("slide-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप निर्धारित कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाएगा। निम्नलिखित प्रॉपर्टी इस व्यवहार को नियंत्रित करती हैं:

- [AdvanceOnClick](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/advanceonclick/) दर्शक को माउस क्लिक करके आगे बढ़ाने की अनुमति देता है।
- [AdvanceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/advanceafter/) स्वचालित आगे बढ़ाने को सक्रिय करता है।
- [AdvanceAfterTime](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/advanceaftertime/) स्वचालित आगे बढ़ाने से पहले देरी (मिलीसेकंड में) निर्धारित करता है।

क्लिक और टाइम्ड दोनों संक्रमण को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर का उपयोग करने के लिए, [AdvanceOnClick] को `false` सेट करें। देरी यह निर्धारित करती है कि स्लाइड शो कब आगे बढ़ेगा; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि नहीं तय करती।

यह उदाहरण पहले तीन स्लाइडों को विभिन्न इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5 और 7 सेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है। माउस क्लिक द्वारा भी इन स्लाइडों को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 3)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Circle;
    firstTransition.AdvanceOnClick = true;
    firstTransition.AdvanceAfter = true;
    firstTransition.AdvanceAfterTime = 3000;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Comb;
    secondTransition.AdvanceOnClick = true;
    secondTransition.AdvanceAfter = true;
    secondTransition.AdvanceAfterTime = 5000;

    var thirdTransition = presentation.Slides[2].SlideShowTransition;
    thirdTransition.Type = TransitionType.Zoom;
    thirdTransition.AdvanceOnClick = true;
    thirdTransition.AdvanceAfter = true;
    thirdTransition.AdvanceAfterTime = 7000;

    presentation.Save("advanced-transitions.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least three slides.");
}
```

यह जांचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [AdvanceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/advanceafter/) पढ़ें। केवल संग्रहीत देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट देता है, और दो सेकंड से अधिक देरी वाली स्लाइडों के लिए स्वचालित आगे बढ़ना अक्षम करता है। उन स्लाइडों के लिए माउस क्लिक सक्षम करता है और अद्यतन सेटिंग्स को सहेजता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("advanced-transitions.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;

    if (transition.AdvanceAfter)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: advance after {transition.AdvanceAfterTime} ms.");

        if (transition.AdvanceAfterTime > 2000)
        {
            transition.AdvanceAfter = false;
            transition.AdvanceOnClick = true;
        }
    }
}

presentation.Save("adjusted-transitions.pptx", SaveFormat.Pptx);
```

## **ट्रांज़िशन समय को सटीक रूप से नियंत्रित करें**

[Duration](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करके आप ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई (मिलीसेकंड में) निर्धारित कर सकते हैं। स्लाइड की [SlideShowTransition](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/slideshowtransition/) प्रॉपर्टी इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/) के माध्यम से उजागर करती है:

| प्रॉपर्टी | उद्देश्य |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/duration/) | ट्रांज़िशन इफ़ेक्ट की स्वयं की अवधि (मिलीसेकंड में) सेट करता है। |
| [AdvanceAfterTime](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | स्लाइड के स्वचालित आगे बढ़ने से पहले के देरी (मिलीसेकंड में) को सेट करता है। इस टाइमर को सक्रिय करने के लिए [AdvanceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/advanceafter/) को सक्षम करें। |
| [Speed](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionspeed/) से पूर्वनिर्धारित गति श्रेणी चुनता है: Slow, Medium, या Fast। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[Duration] केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दिखाई दे। स्वचालित आगे बढ़ने की देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [Speed] मान से इफ़ेक्ट अवधि निर्धारित करता है।

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` को लोड करता है, [TransitionType](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5,000 मिलीसेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    transition.Type = TransitionType.Fade;
    transition.Duration = 750;

    // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ने को कॉन्फ़िगर करें।
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **व्यक्तिगत स्लाइडों के लिए अलग-अलग अवधि सेट करें**

विभिन्न स्लाइडें अलग-अलग इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहले स्लाइड के लिए 500 मिलीसेकंड और दूसरे के लिए 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");

if (presentation.Slides.Count >= 2)
{
    var firstTransition = presentation.Slides[0].SlideShowTransition;
    firstTransition.Type = TransitionType.Fade;
    firstTransition.Duration = 500;

    var secondTransition = presentation.Slides[1].SlideShowTransition;
    secondTransition.Type = TransitionType.Push;
    secondTransition.Duration = 1200;

    presentation.Save("individual-transition-durations.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब आप [animated GIF](/slides/hi/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/net/export-to-html5/) या [video](/slides/hi/net/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड फ़ेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देरी को अलग से समायोजित करें ताकि उसकी आवाज़ या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 फ्रेम प्रति सेकंड पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने हुए निर्यात फ़ॉर्मेट के समर्थित इफ़ेक्ट और समय विकल्पों की जाँच करें, और सिंक्रनाइज़ेशन की पुष्टि के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूद ट्रांज़िशन अवधि पढ़ें**

[Duration] को ट्रांज़िशन संशोधित करने से पहले पढ़ें ताकि यह पता चले कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` मान का मतलब है कोई स्पष्ट अवधि सेट नहीं है; शून्य या उससे अधिक मान संग्रहीत अवधि (मिलीसेकंड में) दर्शाता है। अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [Speed] का उपयोग करके वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि प्रारंभ हो सकती है, इसलिए पहले मूल सेटिंग्स का निरीक्षण करें।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var slide in presentation.Slides)
{
    var transition = slide.SlideShowTransition;
    var duration = transition.Duration;

    if (duration >= 0)
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: stored transition duration is {duration} ms.");
    }
    else
    {
        Console.WriteLine($"Slide {slide.SlideNumber}: no explicit duration; timing depends on {transition.Type} and {transition.Speed}.");
    }
}
```

## **Morph ट्रांज़िशन**

Morph ट्रांज़िशन क्रमिक स्लाइडों पर वस्तुओं के बीच परिवर्तन को एनिमेट करता है। एक सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरे स्लाइड पर Morph ट्रांज़िशन लागू करें। यह ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और बदलें स्थितियों के बीच एनिमेट करने देता है।

निम्नलिखित उदाहरण एक टेक्स्ट आयत के साथ स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर यह दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitiontype/) एनेमरेशन से Morph चुनता है। सहेजी गई फ़ाइल को Morph का समर्थन करने वाले प्रेजेंटेशन व्यूअर में खोलें ताकि स्लाइड शो के दौरान इफ़ेक्ट देख सकें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var rectangle = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
rectangle.TextFrame.Text = "Morph transition";

var secondSlide = presentation.Slides.AddClone(firstSlide);
var movedRectangle = secondSlide.Shapes[0];
movedRectangle.X += 100;
movedRectangle.Y += 50;
movedRectangle.Width -= 200;
movedRectangle.Height -= 10;

secondSlide.SlideShowTransition.Type = TransitionType.Morph;

presentation.Save("morph-transition.pptx", SaveFormat.Pptx);
```

## **Morph ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionmorphtype/) एनेमरेशन नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनिमेट करता है:

- [ByObject](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionmorphtype/) प्रत्येक आकार को एक पूर्ण वस्तु के रूप में लेता है।
- [ByWord](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो शब्दों को मिलाकर टेक्स्ट को एनिमेट करता है।
- [ByChar](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो अक्षरों को मिलाकर टेक्स्ट को एनिमेट करता है।

ट्रांज़िशन की [Type](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/type/) को Morph पर सेट करें, फिर उसकी [Value](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/value/) तक पहुंचें। यह वैल्यू फिर [IMorphTransition](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/imorphtransition/) इंटरफ़ेस प्रदान करती है, जिसका [MorphType](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/imorphtransition/morphtype/) प्रॉपर्टी मिलान मोड चुनता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("morph-transition.pptx");

if (presentation.Slides.Count >= 2)
{
    var transition = presentation.Slides[1].SlideShowTransition;
    transition.Type = TransitionType.Morph;

    if (transition.Value is IMorphTransition morphTransition)
    {
        morphTransition.MorphType = TransitionMorphType.ByWord;
        presentation.Save("morph-by-word.pptx", SaveFormat.Pptx);
    }
    else
    {
        Console.WriteLine("Morph transition options are unavailable.");
    }
}
else
{
    Console.WriteLine("The input presentation must contain at least two slides.");
}
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प दिखाते हैं, जैसे दिशा या इफ़ेक्ट काली स्क्रीन से शुरू होता है या नहीं। उपलब्ध विकल्प चयनित ट्रांज़िशन [Type](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/type/) पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर उसकी [Value](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/value/) से उपयुक्त इंटरफ़ेस का उपयोग करें।

निम्नलिखित उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [FromBlack](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) को [IOptionalBlackTransition](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/ioptionalblacktransition/) के माध्यम से सेट करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation("input.pptx");
var transition = presentation.Slides[0].SlideShowTransition;
transition.Type = TransitionType.Cut;

if (transition.Value is IOptionalBlackTransition cutTransition)
{
    cutTransition.FromBlack = true;
    presentation.Save("cut-from-black.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Cut transition options are unavailable.");
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति को नियंत्रित कर सकता हूँ?**

हां। जब आपको मिलिसेंकड़ में सटीक इफ़ेक्ट अवधि चाहिए तो [Duration] को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed] श्रेणी—Slow, Medium, या Fast—पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [Speed] का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने की देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर उसे लूप कर सकता हूँ?**

हां। एम्बेडेड ऑडियो को [Sound](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/sound/) में असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionsoundmode/) एनेमरेशन से [SoundMode](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/soundmode/) को StartSound पर सेट करें, और [SoundLoop](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/soundloop/) को सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप करता रहेगा।

**सभी स्लाइडों पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन की [Slides](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slides/hi/) संग्रह पर लूप करें और प्रत्येक स्लाइड की ट्रांज़िशन [Type](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/type/) को समान मान पर सेट करें। उसी लूप में किसी भी टाइमिंग और इफ़ेक्ट विकल्प को सेट करें ताकि सभी स्लाइडों पर व्यवहार सुसंगत रहे।

**मैं कैसे जांच सकता हूँ कि स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [SlideShowTransition](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/slideshowtransition/) से [Type](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/type/) प्रॉपर्टी पढ़ें। यह [TransitionType](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitiontype/) एनेमरेशन से मान लौटाता है; None का अर्थ है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।