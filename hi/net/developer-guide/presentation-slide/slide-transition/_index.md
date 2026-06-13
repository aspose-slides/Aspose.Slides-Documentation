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
- मॉर्फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड ट्रांज़िशन को अनुकूलित करने का तरीका जानें, PowerPoint और OpenDocument प्रस्तुतियों के लिए चरण-दर-चरण मार्गदर्शन के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन को प्रबंधित करने का तरीका समझाता है। यह स्लाइड्स पर ट्रांज़िशन प्रकार लागू करने, ट्रांज़िशन व्यवहार कॉन्फ़िगर करने जैसे क्लिक पर आगे बढ़ना या निर्दिष्ट समय के बाद आगे बढ़ना, स्वत: आगे बढ़ना जाँचने और निष्क्रिय करने, Morph ट्रांज़िशन और उसके प्रकारों का उपयोग करने, तथा ट्रांज़िशन इफ़ेक्ट विकल्प सेट करने को दिखाता है। उदाहरण दर्शाते हैं कि प्रस्तुति को कैसे लोड या बनाया जाए, चयनित स्लाइड्स के लिए ट्रांज़िशन सेटिंग्स को संशोधित किया जाए, और परिणाम को PPTX फ़ाइल के रूप में सहेजा जाए। लेख सामान्य प्रश्नों के उत्तर भी देता है जैसे ट्रांज़िशन की गति, ट्रांज़िशन ध्वनियाँ, कई स्लाइड्स पर समान ट्रांज़िशन लागू करना, और स्लाइड पर वर्तमान में सेट ट्रांज़िशन को जाँचना।

## **स्लाइड ट्रांज़िशन जोड़ें**
समझने में आसानी के लिए हमने Aspose.Slides for .NET का उपयोग करके सरल स्लाइड ट्रांज़िशन प्रबंधन का प्रदर्शन किया है। डेवलपर्स न केवल विभिन्न स्लाइड ट्रांज़िशन इफ़ेक्ट्स को स्लाइड्स पर लागू कर सकते हैं बल्कि इन इफ़ेक्ट्स के व्यवहार को भी अनुकूलित कर सकते हैं। सरल स्लाइड ट्रांज़िशन इफ़ेक्ट बनाना चाहते हैं तो नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
1. Aspose.Slides for .NET द्वारा प्रदत्त ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके TransitionType enum के माध्यम से स्लाइड पर Slide Transition Type लागू करें।
1. संशोधित प्रस्तुति फ़ाइल लिखें।

```c#
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का इंस्टेंस बनाएं
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    // स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    // स्लाइड 2 पर कंब प्रकार का ट्रांज़िशन लागू करें
    presentation.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    // प्रस्तुति को डिस्क पर लिखें
    presentation.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**
ऊपर के अनुभाग में हमने स्लाइड पर एक साधारण ट्रांज़िशन इफ़ेक्ट लागू किया था। अब इस साधारण इफ़ेक्ट को और बेहतर और नियंत्रित बनाने के लिए नीचे दिए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
1. Aspose.Slides for .NET द्वारा प्रदत्त ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके स्लाइड पर Slide Transition Type लागू करें।
1. आप ट्रांज़िशन को Advance On Click, एक विशिष्ट समय अवधि के बाद या दोनों में सेट कर सकते हैं।
1. यदि स्लाइड ट्रांज़िशन Advance On Click के लिए सक्षम है, तो ट्रांज़िशन केवल तभी आगे बढ़ेगा जब माउस क्लिक किया जाएगा। इसके अतिरिक्त, यदि Advance After Time प्रॉपर्टी सेट है, तो ट्रांज़िशन निर्धारित समय के बाद स्वतः आगे बढ़ेगा।
1. संशोधित प्रस्तुति को प्रस्तुति फ़ाइल के रूप में लिखें।

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
using (Presentation pres = new Presentation("BetterSlideTransitions.pptx"))
{

    // स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;


    // ट्रांज़िशन समय 3 सेकंड सेट करें
    pres.Slides[0].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[0].SlideShowTransition.AdvanceAfterTime = 3000;

    // स्लाइड 2 पर कंब प्रकार का ट्रांज़िशन लागू करें
    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;


    // ट्रांज़िशन समय 5 सेकंड सेट करें
    pres.Slides[1].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[1].SlideShowTransition.AdvanceAfterTime = 5000;

    // स्लाइड 3 पर ज़ूम प्रकार का ट्रांज़िशन लागू करें
    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;


    // ट्रांज़िशन समय 7 सेकंड सेट करें
    pres.Slides[2].SlideShowTransition.AdvanceOnClick = true;
    pres.Slides[2].SlideShowTransition.AdvanceAfterTime = 7000;

    // प्रस्तुति को डिस्क पर लिखें
    pres.Save("SampleTransition_out.pptx", SaveFormat.Pptx);
}
```

अतिरिक्त रूप से, आप [AdvanceAfter](https://reference.aspose.com/slides/hi/net/aspose.slides/islideshowtransition/advanceafter/) प्रॉपर्टी का उपयोग करके जाँच सकते हैं कि स्लाइड ट्रांज़िशन अगले स्लाइड पर जाने के लिए कॉन्फ़िगर किया गया है या सेटिंग निष्क्रिय है।

यह C# कोड संचालन दर्शाता है:

```c#
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाता है
using (Presentation pres = new Presentation("SampleTransition_out.pptx"))
{
    foreach (ISlide slide in pres.Slides)
    {
        // स्लाइड ट्रांज़िशन प्राप्त करता है
        ISlideShowTransition slideTransition = slide.SlideShowTransition;

        // जाँचता है कि Advance After Time सेटिंग सक्षम है या नहीं
        if (slideTransition.AdvanceAfter)
        {
            // Advance After Time मान को प्रिंट करता है
            Console.WriteLine("The slide #" + slide.SlideNumber + " AdvancedAfterTime: " + slideTransition.AdvanceAfterTime);
        }

        // यदि AdvanceAfterTime मान 2 सेकंड से अधिक है तो विशिष्ट समय के बाद ट्रांज़िशन को निष्क्रिय करता है
        if (slideTransition.AdvanceAfterTime > 2000)
        {
            slideTransition.AdvanceAfter = false;
        }
    }
}
```

## **Morph ट्रांज़िशन**
Aspose.Slides for .NET अब [Morph Transition](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/imorphtransition) को समर्थन करता है। यह PowerPoint 2019 में प्रस्तुत नया Morph ट्रांज़िशन दर्शाता है। Morph ट्रांज़िशन आपको एक स्लाइड से अगले स्लाइड तक सुगम गति एनीमेट करने की अनुमति देता है। यह लेख अवधारणा और Morph ट्रांज़िशन के उपयोग को वर्णित करता है। Morph ट्रांज़िशन को प्रभावी रूप से उपयोग करने के लिए आपको कम से कम एक सामान्य ऑब्जेक्ट वाले दो स्लाइड्स की आवश्यकता होगी। सबसे आसान तरीका है स्लाइड को डुप्लिकेट करना और फिर दूसरे स्लाइड पर ऑब्जेक्ट को किसी भिन्न स्थान पर ले जाना।

निम्नलिखित कोड स्निपेट आपको दिखाता है कि कैसे स्लाइड की एक क्लोन जिसमें कुछ टेक्स्ट हो, प्रस्तुति में जोड़ें और दूसरे स्लाइड पर [morph type](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/imorphtransition/properties/morphtype) ट्रांज़िशन सेट करें।

```c#
using (Presentation presentation = new Presentation())
{
    AutoShape autoshape = (AutoShape)presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.TextFrame.Text = "Morph Transition in PowerPoint Presentations";

    presentation.Slides.AddClone(presentation.Slides[0]);

    presentation.Slides[1].Shapes[0].X += 100;
    presentation.Slides[1].Shapes[0].Y += 50;
    presentation.Slides[1].Shapes[0].Width -= 200;
    presentation.Slides[1].Shapes[0].Height -= 10;

    presentation.Slides[1].SlideShowTransition.Type = Aspose.Slides.SlideShow.TransitionType.Morph;

    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Morph ट्रांज़िशन प्रकार**
नया [Aspose.Slides.SlideShow.TransitionMorphType](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionmorphtype) enum जोड़ा गया है। यह विभिन्न Morph स्लाइड ट्रांज़िशन प्रकारों का प्रतिनिधित्व करता है।

TransitionMorphType enum में तीन सदस्य हैं:

- ByObject: Morph ट्रांज़िशन को आकारों को अभाज्य ऑब्जेक्ट्स मानते हुए किया जाएगा।
- ByWord: Morph ट्रांज़िशन को शब्दों द्वारा पाठ स्थानांतरित करते हुए किया जाएगा जहाँ संभव हो।
- ByChar: Morph ट्रांज़िशन को अक्षरों द्वारा पाठ स्थानांतरित करते हुए किया जाएगा जहाँ संभव हो।

निम्नलिखित कोड स्निपेट आपको दिखाता है कि कैसे स्लाइड पर morph ट्रांज़िशन सेट करें और morph प्रकार बदलें:

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
    presentation.Slides[0].SlideShowTransition.Type = TransitionType.Morph;
    ((IMorphTransition)presentation.Slides[0].SlideShowTransition.Value).MorphType = TransitionMorphType.ByWord;
    presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**
Aspose.Slides for .NET ब्लैक से, बाएँ से, दाएँ से आदि जैसे ट्रांज़िशन इफ़ेक्ट सेट करने को समर्थन देता है। ट्रांज़िशन इफ़ेक्ट सेट करने के लिए कृपया नीचे दिए चरणों का पालन करें:

- एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation) क्लास का इंस्टेंस बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- ट्रांज़िशन इफ़ेक्ट सेट करें।
- प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

निचे दिए उदाहरण में हमने ट्रांज़िशन इफ़ेक्ट सेट किए हैं।

```c#
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation presentation = new Presentation("AccessSlides.pptx");

// इफ़ेक्ट सेट करें
presentation.Slides[0].SlideShowTransition.Type = TransitionType.Cut;
((OptionalBlackTransition)presentation.Slides[0].SlideShowTransition.Value).FromBlack = true;

// प्रस्तुति को डिस्क पर लिखें
presentation.Save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**  
हाँ। ट्रांज़िशन की [Speed](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/speed/) को [TransitionSpeed](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/transitionspeed/) सेटिंग के माध्यम से सेट करें (उदाहरण: slow/medium/fast)।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर उसे लूप कर सकता हूँ?**  
हाँ। आप ट्रांज़िशन के लिए ध्वनि एम्बेड कर सकते हैं और ध्वनि मोड एवं लूपिंग जैसे सेटिंग्स (जैसे, [Sound](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/sound/), [SoundMode](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/soundmode/), [SoundLoop](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/soundloop/)) के माध्यम से व्यवहार नियंत्रित कर सकते हैं, साथ ही [SoundIsBuiltIn](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/soundisbuiltin/) और [SoundName](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/soundname/) जैसी मेटाडेटा का उपयोग कर सकते हैं।

**सभी स्लाइड्स पर एक समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**  
प्रत्येक स्लाइड की ट्रांज़िशन सेटिंग्स में वांछित ट्रांज़िशन प्रकार कॉन्फ़िगर करें; ट्रांज़िशन प्रत्येक स्लाइड के लिए अलग‑अलग संग्रहीत होते हैं, इसलिए सभी स्लाइड्स पर समान प्रकार लागू करने से समान परिणाम प्राप्त होगा।

**मैं कैसे जाँच सकता हूँ कि वर्तमान में स्लाइड पर कौन सा ट्रांज़िशन सेट है?**  
स्लाइड की [transition settings](https://reference.aspose.com/slides/hi/net/aspose.slides/baseslide/slideshowtransition/) को निरीक्षण करें और उसके [transition type](https://reference.aspose.com/slides/hi/net/aspose.slides.slideshow/slideshowtransition/type/) को पढ़ें; यह मान ठीक‑ठीक बताता है कि कौन सा इफ़ेक्ट लागू किया गया है।