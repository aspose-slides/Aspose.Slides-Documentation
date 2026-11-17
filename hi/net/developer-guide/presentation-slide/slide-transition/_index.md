---
title: .NET में प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
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
- ट्रांज़िशन प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन प्रभावों को अनुकूलित करें।"
---
## **परिचय**

स्लाइड ट्रांज़िशन नियंत्रित करता है कि स्लाइड शो के दौरान स्लाइड्स कैसे प्रदर्शित होती हैं। Aspose.Slides for .NET के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख C# उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइड्स के बीच एक Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, प्रस्तुतिकरण को [प्रस्तुति](https://reference.aspose.com/slides/net/aspose.slides/presentation/) क्लास से लोड करें और स्लाइड की [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) प्रॉपर्टी तक पहुँचें। उसकी [प्रकार](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) एनेमरेशन के मान में सेट करें, फिर प्रस्तुतिकरण को सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरी स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

[IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) की [Spokes](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/spokes/) प्रॉपर्टी उस रेडियल सेक्टरों की संख्या को नियंत्रित करती है जो गंतव्य स्लाइड को प्रकट करती है। स्लाइड के ट्रांज़िशन की [प्रकार](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) से Wheel पर सेट करें, फिर [मान](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) को [IWheelTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/iwheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान जोड़े की स्लाइड्स बनाता है: एक काली स्लाइड जिसके बाद एक सोने के आयत वाला स्लाइड आता है। गंतव्य स्लाइड्स 1 और 8 स्पोक काउंट के साथ उपयोग करती हैं, उसी [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) और स्पष्ट [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) 8,000 मिलीसेकंड के साथ ताकि अंतर आसानी से देखा जा सके।

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

आउटपुट प्रस्तुति को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2 तक, फिर स्लाइड 3 से स्लाइड 4 तक आगे बढ़ें। PowerPoint प्लेबैक में, सत्यापित स्पोक काउंट 1 स्लाइड को एक घड़ी की दिशा में स्वाइप से प्रकट करता है; सत्यापित काउंट 8 इसे एक साथ आठ रेडियल सेक्टरों में प्रकट करता है। गंतव्य सामग्री और ट्रांज़िशन टाइमिंग समान हैं, इसलिए अंतर केवल प्रकट करने वाले सेक्टरों की संख्या है।

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप कॉन्फ़िगर कर सकते हैं कि कोई स्लाइड स्क्रीन पर कितनी देर रहेगी और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाएगा। निम्न प्रॉपर्टी इस व्यवहार को नियंत्रित करती हैं:

- [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) दर्शक को माउस क्लिक द्वारा आगे बढ़ने की अनुमति देता है।
- [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) स्वचालित आगे बढ़ने को सक्षम करता है।
- [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceaftertime/) स्वचालित आगे बढ़ने से पहले का विलंब मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ाने को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर की प्रतीक्षा कर सके। केवल टाइमर का उपयोग करने के लिए, [AdvanceOnClick](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceonclick/) को `false` सेट करें। विलंब यह नियंत्रित करता है कि स्लाइड शो कब आगे बढ़ेगा; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करता।

यह उदाहरण पहली तीन स्लाइड्स में विभिन्न इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वचालित आगे बढ़ाने को सक्षम करता है। माउस क्लिक भी इन स्लाइड्स को आगे बढ़ा सकते हैं। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

यह जाँचने के लिए कि टाइम्ड आगे बढ़ाना सक्षम है या नहीं, [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) पढ़ें। केवल संग्रहीत विलंब यह संकेत नहीं देता कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइड्स के लिए स्वचालित आगे बढ़ाने को निष्क्रिय करता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) का उपयोग करके ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई मिलीसेकंड में निर्दिष्ट करें। स्लाइड की [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) प्रॉपर्टी इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/) के माध्यम से एक्सपोज़ करती है:

| प्रॉपर्टी | उद्देश्य |
| --- | --- |
| [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) | ट्रांज़िशन इफ़ेक्ट की स्वयं की अवधि को मिलीसेकंड में सेट करता है। |
| [AdvanceAfterTime](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/advanceaftertime/) | स्लाइड के स्वचालित आगे बढ़ने से पहले का विलंब मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [AdvanceAfter](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/advanceafter/) सक्षम करें। |
| [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) | [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) के पूर्वनिर्धारित श्रेणी (Slow, Medium, Fast) में से एक का चयन करता है। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दिखाई देगी। स्वचालित आगे बढ़ने के विलंब को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) मान के आधार पर प्रभाव अवधि निर्धारित करता है।

### **सभी स्लाइड्स पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` को लोड करता है, [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से स्वचालित आगे बढ़ाने को 5,000 मिलीसेकंड के बाद सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ाने को निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

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

### **व्यक्तिगत स्लाइड्स के लिए अलग-अलग अवधि सेट करें**

विभिन्न स्लाइड्स अलग-अलग इफ़ेक्ट अवधि का उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए संक्षिप्त ट्रांज़िशन और अनुभाग परिचय के लिए अधिक लंबी ट्रांज़िशन उपयोग करें। यह उदाहरण पहली स्लाइड के लिए 500 मिलीसेकंड और दूसरी स्लाइड के लिए 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

जब आप [animated GIF](/slides/hi/net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/net/export-to-html5/), या [video](/slides/hi/net/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि वांछित गति से मेल खा सके। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का फेड उपयोग करें, और प्रत्येक स्लाइड के आगे बढ़ाने के विलंब को अलग से समायोजित करें ताकि उसकी वाणी या सामग्री का समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 फ़्रेम प्रति सेकंड पर 18 फ़्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनीमेटेड ट्रांज़िशन को सक्षम करें। चुने गए निर्यात फ़ॉर्मेट के समर्थित इफ़ेक्ट्स और टाइमिंग विकल्पों की जाँच करें, और समन्वय की पुष्टि के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) पढ़ें ताकि पता चल सके कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; गैर-नकारात्मक मान मिलीसेकंड में संग्रहीत अवधि को दर्शाता है। अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) के आधार पर वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि प्रारम्भ हो सकती है, इसलिए मूल सेटिंग्स को पहले निरीक्षण करें।

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

## **मॉर्फ़ ट्रांज़िशन**

Morph ट्रांज़िशन क्रमिक स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। एक सरल Morph इफ़ेक्ट बनाने के लिए, किसी स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। यह ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनीमेट करने देता है।

निम्न उदाहरण एक पाठ आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) एनेमरेशन से Morph चुनता है। Morph को समर्थन देने वाले प्रस्तुति दर्शक में सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान इफ़ेक्ट देखा जा सके।

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

## **मॉर्फ़ ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) एनेमरेशन यह नियंत्रित करता है कि Morph सामग्री से कैसे मिलान करता है और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) प्रत्येक आकार को एक संपूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो शब्दों को मिलाकर पाठ को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionmorphtype/) जहाँ संभव हो अक्षरों को मिलाकर पाठ को एनीमेट करता है।

[Type](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को Morph पर सेट करें, फिर उसके [मान](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) तक पहुँचें। यह मान [IMorphTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/) इंटरफ़ेस प्रदान करता है, जिसकी [MorphType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/imorphtransition/morphtype/) प्रॉपर्टी मिलान मोड चुनती है।

यह उदाहरण पिछले अनुभाग में बनी प्रस्तुति को खोलता है और दूसरे स्लाइड को शब्द-आधारित Morph एनीमेशन के लिए कॉन्फ़िगर करता है।

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
[![Morph मिलान इकाइयाँ एक संपूर्ण आकार, व्यक्तिगत शब्द, और व्यक्तिगत अक्षर के रूप में दिखायी गईं।](visual-slide-transition-76bdbee41cb7.svg)](visual-slide-transition-76bdbee41cb7.svg)

*Morph जहाँ संभव हो पूरे आकार, शब्द या अक्षर को मिलान कर सकता है। यह उदाहरण दूसरे स्लाइड पर ByWord चुनता है।*
<!-- visual-explanation:slide-transition:end -->

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या इफ़ेक्ट का काले स्क्रीन से शुरू होना। उपलब्ध विकल्प चयनित ट्रांज़िशन [प्रकार](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर उसके [मान](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/value/) से उपयुक्त इंटरफ़ेस उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [FromBlack](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/fromblack/) को [IOptionalBlackTransition](https://reference.aspose.com/slides/net/aspose.slides.slideshow/ioptionalblacktransition/) के माध्यम से सेट करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता/सकती हूँ?**

हां। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [Duration](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/duration/) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionspeed/) श्रेणी (Slow, Medium, या Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [Speed](https://reference.aspose.com/slides/net/aspose.slides.slideshow/slideshowtransition/speed/) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ाने के विलंब से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो संलग्न कर सकता/सकती हूँ और उसे लूप कर सकता/सकती हूँ?**

हां। एम्बेडेड ऑडियो को [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) में असाइन करें, [SoundMode](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundmode/) को [TransitionSoundMode](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitionsoundmode/) एनेमरेशन से StartSound पर सेट करें, और [SoundLoop](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/soundloop/) को सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप होता रहेगा।

**हर स्लाइड पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रस्तुति की [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) संग्रह पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन [प्रकार](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) को समान मान पर सेट करें। उसी लूप में किसी भी टाइमिंग और इफ़ेक्ट विकल्प को सेट करें ताकि सभी स्लाइड्स पर व्यवहार समान रहे।

**मैं कैसे जाँच सकता/सकती हूँ कि स्लाइड पर कौन सा ट्रांज़िशन वर्तमान में सेट है?**

स्लाइड की [SlideShowTransition](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideshowtransition/) से [प्रकार](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/type/) प्रॉपर्टी पढ़ें। यह [TransitionType](https://reference.aspose.com/slides/net/aspose.slides.slideshow/transitiontype/) एनेमरेशन का मान लौटाता है; None का अर्थ है कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।