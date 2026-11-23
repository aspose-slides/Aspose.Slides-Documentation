---
title: ".NET में प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें"
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 90
url: /hi/net/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मोर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड अग्रसरण को कॉन्फ़िगर करें, और Aspose.Slides for .NET के साथ मोर्फ़ और अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइड्स के दिखने के तरीके को नियंत्रित करता है। Aspose.Slides for .NET के साथ, आप प्रत्येक स्लाइड के लिए ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर के द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट विशिष्ट विकल्प समायोजित कर सकते हैं। यह लेख C# उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइड्स के बीच मोर्फ़ ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें और स्लाइड के [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) प्रॉपर्टी तक पहुँचें। इसके [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) एन्स्यूमरेशन में से किसी मान पर सेट करें, फिर प्रस्तुति सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

## **व्हील ट्रांज़िशन**

[IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) की [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) प्रॉपर्टी लक्ष्य स्लाइड को दिखाने वाले रेडियल सेक्टर की संख्या नियंत्रित करती है। स्लाइड के ट्रांज़िशन [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) से Wheel पर सेट करने के बाद [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) को [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान स्लाइड जोड़े बनाता है: एक काली स्लाइड जिसके बाद गोल्ड आयत वाली स्लाइड होती है। लक्ष्य स्लाइड्स 1 और 8 स्पोक काउंट का उपयोग करती हैं, समान [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) और 8,000 मिलीसेकंड की स्पष्ट [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) के साथ, जिससे अंतर को देखना आसान हो जाता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();
var slideWidth = presentation.SlideSize.Size.Width;
var slideHeight = presentation.SlideSize.Size.Height;

var blackSlide = presentation.Slides[0];
blackSlide.Shapes.Clear();
blackSlide.Background.Type = BackgroundType.OwnBackground;
blackSlide.Background.FillFormat.FillType = FillType.Solid;
blackSlide.Background.FillFormat.SolidFillColor.Color = Color.Black;

var destinationSlide = presentation.Slides.AddClone(blackSlide);
var rectangle = destinationSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
rectangle.FillFormat.FillType = FillType.Solid;
rectangle.FillFormat.SolidFillColor.Color = Color.Gold;
rectangle.TextFrame.Text = "Wheel transition";

presentation.Slides.AddClone(blackSlide);
presentation.Slides.AddClone(destinationSlide);

var spokeCounts = new uint[] { 1, 8 };
for (var i = 0; i < spokeCounts.Length; i++)
{
    var transition = presentation.Slides[i * 2 + 1].SlideShowTransition;
    transition.Type = TransitionType.Wheel;
    var wheelTransition = (IWheelTransition)transition.Value;
    wheelTransition.Spokes = spokeCounts[i];
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 8000;
}

presentation.Save("wheel-transitions.pptx", SaveFormat.Pptx);
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2, फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें। PowerPoint प्लेबैक में, सत्यापित स्पोक काउंट 1 बोर्ड को एक घड़ी की दिशा में स्वैप से प्रदर्शित करता है; सत्यापित काउंट 8 इसे एक साथ आठ रेडियल सेक्टरों द्वारा प्रदर्शित करता है। लक्ष्य सामग्री और ट्रांज़िशन टाइमिंग समान हैं, इसलिए अंतर केवल प्रकट होने वाले सेक्टरों की संख्या में है।

## **Reveal ट्रांज़िशन के साथ ब्लैक थ्रू फ़ेड**

लक्ष्य स्लाइड का ट्रांज़िशन टाइप Reveal पर सेट करें, फिर [IRevealTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/) का उपयोग करके [ThroughBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/irevealtransition/throughblack/) सेट करें। यह उदाहरण एक टील स्रोत स्लाइड और एक कोरल लक्ष्य स्लाइड बनाता है, फिर दोनों को क्लोन करता है ताकि आप दो‑सेकंड के वही ट्रांज़िशन को फ़ेड निष्क्रिय और सक्षम दोनों स्थितियों में तुलना कर सकें।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SlideShow;

using var presentation = new Presentation();

var source = presentation.Slides[0];
var destination = presentation.Slides.AddClone(source);
StyleSlide(source, Color.Teal, "Source");
StyleSlide(destination, Color.Coral, "Destination");
presentation.Slides.AddClone(source);
presentation.Slides.AddClone(destination);

foreach (var index in new[] { 1, 3 })
{
    var transition = presentation.Slides[index].SlideShowTransition;
    transition.Type = TransitionType.Reveal;
    transition.Speed = TransitionSpeed.Slow;
    transition.Duration = 2000;

    var reveal = (IRevealTransition)transition.Value;
    reveal.Direction = TransitionLeftRightDirectionType.Left;
    reveal.ThroughBlack = index == 3;
}

presentation.Save("reveal-transitions.pptx", SaveFormat.Pptx);

void StyleSlide(ISlide slide, Color background, string label)
{
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = background;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
    shape.TextFrame.Text = label;
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 44;
}
```

PowerPoint स्लाइड शो में, स्लाइड 1 से स्लाइड 2 पर आगे बढ़ें। टील सीधे कोरल में फ़ेड हो जाता है। फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें। स्क्रीन लगभग ब्लैक तक धुंधला हो जाता है, फिर कोरल स्लाइड दिखाई देती है। दोनों स्लाइड अपने मूल बैकग्राउंड रंग रखती हैं।

नीचे की पंक्तियों में आधे‑सेकंड अंतराल पर PowerPoint के फ्रेम दिखाए गए हैं। प्रत्येक पंक्ति के मध्य फ्रेम की तुलना करें ताकि सेटिंग का प्रभाव देख सकें।

![PowerPoint playback with ThroughBlack disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक से स्लाइड शो आगे बढ़े। निम्न प्रॉपर्टीज इस व्यवहार को नियंत्रित करती हैं:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) दर्शक को माउस क्लिक करके आगे बढ़ने की अनुमति देता है।
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) स्वचालित अग्रसरण सक्षम करता है।
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) स्वचालित अग्रसरण से पहले की देरी को मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों अग्रसरण को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर का उपयोग करने के लिए, [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) को `false` पर सेट करें। देरी निर्धारित करती है कि स्लाइड शो कब आगे बढ़ेगा; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करती।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट देता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वचालित अग्रसरण सक्षम करता है। माउस क्लिक भी इन स्लाइड्स को आगे बढ़ा सकता है। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

पता लगाने के लिए कि टाइम्ड अग्रसरण सक्षम है या नहीं, [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) पढ़ें। केवल संग्रहीत देरी सक्रिय टाइमर का संकेत नहीं देती।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक देरी वाली स्लाइड्स के लिए स्वचालित अग्रसरण को निष्क्रिय करता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स सहेजता है।

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

## **ट्रांज़िशन टाइमिंग को सटीक रूप से नियंत्रित करें**

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करके आप ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई मिलीसेकंड में निर्दिष्ट कर सकते हैं। स्लाइड का [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) प्रॉपर्टी इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/) के माध्यम से उजागर करता है:

| Property | Purpose |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | ट्रांज़िशन इफ़ेक्ट की अवधि को मिलीसेकंड में सेट करता है। |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले की देरी को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) सक्षम करें। |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) एन्स्यूमरेशन से पूर्वनिर्धारित गति वर्ग चुनता है: Slow, Medium, या Fast। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर दृश्यमान रहे। स्वचालित अग्रसरण देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि नहीं दी जाती, Aspose.Slides ट्रांज़िशन टाइप और [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) मान से प्रभाव अवधि निर्धारित करता है।

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, हर स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5,000 मिलीसेकंड के बाद स्वचालित अग्रसरण सक्षम करता है और माउस क्लिक द्वारा अग्रसरण को निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

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

    // प्रभाव अवधि से स्वतंत्र रूप से स्वचालित अग्रसरण को कॉन्फ़िगर करें।
    transition.AdvanceAfter = true;
    transition.AdvanceAfterTime = 5000;
    transition.AdvanceOnClick = false;
}

presentation.Save("precise-transitions.pptx", SaveFormat.Pptx);
```

### **व्यक्तिगत स्लाइड्स के लिए अलग-अलग अवधियों को सेट करें**

विभिन्न स्लाइड्स अलग-अलग इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के लिए, टाइटल स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए बड़ा ट्रांज़िशन। यह उदाहरण पहली स्लाइड के लिए 500 मिलीसेकंड और दूसरी के लिए 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

### **ऐनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब आप [animated GIF](/slides/hi/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/net/export-to-html5/), या [video](/slides/hi/net/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600‑मिलीसेकंड फ़ेड उपयोग करें, और प्रत्येक स्लाइड की अग्रसरण देरी को अलग से समायोजित करें ताकि उसके निरूपण या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 fps पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में ऐनिमेटेड ट्रांज़िशन को सक्षम करें। चुने गए निर्यात फ़ॉर्मेट के समर्थित इफ़ेक्ट और टाइमिंग विकल्पों की जाँच करें, और समकालिकता की पुष्टि करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

संशोधित करने से पहले [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) पढ़ें, ताकि यह पता चल सके कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि निर्धारित नहीं हुई; गैर‑नकारात्मक मान मिलीसेकंड में संग्रहीत अवधि को दर्शाता है। असंगठित मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन टाइप और [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) का उपयोग करके वह अवधि निर्धारित करता है। ट्रांज़िशन टाइप सेट करने से अवधि प्रारंभ हो सकती है, इसलिए मूल सेटिंग्स की पहले जाँच करें।

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

## **मोर्फ़ ट्रांज़िशन**

मोर्फ़ ट्रांज़िशन क्रमिक स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। एक सरल मोर्फ़ इफ़ेक्ट बनाने के लिए, स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर मोर्फ़ ट्रांज़िशन लागू करें। यह ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित अवस्थाओं के बीच एनीमेट करता है।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) एन्स्यूमरेशन से Morph चुनता है। फ़ाइल को ऐसे प्रस्तुति व्यूवर में खोलें जो मोर्फ़ का समर्थन करता हो, ताकि स्लाइड शो में प्रभाव देखा जा सके।

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

## **मोर्फ़ ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) एन्स्यूमरेशन यह नियंत्रित करता है कि मोर्फ़ सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) प्रत्येक आकार को एक सम्पूर्ण वस्तु मानता है।
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो शब्दों के आधार पर टेक्स्ट एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो अक्षरों के आधार पर टेक्स्ट एनीमेट करता है।

[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को Morph पर सेट करें और फिर उसके [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) तक पहुँचें। यह मूल्य [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) इंटरफ़ेस प्रदान करता है, जिसका [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) प्रॉपर्टी मिलान मोड चुनता है।

यह उदाहरण पिछले सेक्शन में बनाई गई प्रस्तुति खोलता है और दूसरे स्लाइड को शब्द-आधारित मोर्फ़ एनीमेशन के लिए कॉन्फ़िगर करता है।

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


<!-- visual-explanation:slide-transition:start -->
[![Morph matching units shown as a whole shape, individual words, and individual characters.](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph जहाँ संभव हो पूरे आकार, शब्द या अक्षर को मिलान कर सकता है। ये बॉक्स मिलान इकाइयों को दर्शाते हैं, न कि देखी गई गति को। उदाहरण दूसरे स्लाइड पर ByWord चुनता है।*
<!-- visual-explanation:slide-transition:end -->

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या प्रभाव काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प चयनित ट्रांज़िशन [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) पर निर्भर करते हैं। पहले टाइप सेट करें, फिर उसके [Value](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) से उपयुक्त इंटरफ़ेस उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) के माध्यम से [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) सेट करता है, ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक स्पीड नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) वर्ग (Slow, Medium, या Fast) पर्याप्त हो और कोई स्पष्ट अवधि नहीं सेट की गई हो, तो [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित अग्रसरण देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन पर ऑडियो जोड़ सकता हूँ और उसे लूप कर सकता हूँ?**

हाँ। एम्बेडेड ऑडियो को [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) पर असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) एन्स्यूमरेशन से StartSound को [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) पर सेट करें, और [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/) को सक्षम करें। ऑडियो अगले साउंड इवेंट तक लूप रहेगा।

**सभी स्लाइड्स पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन की [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) कलेक्शन पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को समान मान पर सेट करें। उसी लूप में टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि सभी स्लाइड्स में व्यवहार समान रहे।

**मैं कैसे जाँचूँ कि किसी स्लाइड पर वर्तमान में कौन‑सा ट्रांज़िशन सेट है?**

स्लाइड के [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) से [Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) प्रॉपर्टी पढ़ें। यह [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) एन्स्यूमरेशन से मान लौटाता है; None का मतलब है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।