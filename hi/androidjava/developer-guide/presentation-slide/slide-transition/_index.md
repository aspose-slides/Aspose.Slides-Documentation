---
title: Android पर प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/androidjava/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मॉर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में स्लाइड ट्रांज़िशन को कैसे अनुकूलित करें, यह खोजें, PowerPoint और OpenDocument प्रस्तुतियों के लिए चरण-दर-चरण मार्गदर्शन के साथ।"
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन को प्रबंधित करने का तरीका बताता है। यह दिखाता है कि स्लाइड्स पर ट्रांज़िशन प्रकार कैसे लागू करें, ट्रांज़िशन व्यवहार को कॉन्फ़िगर करें जैसे क्लिक पर आगे बढ़ना या निर्दिष्ट समय के बाद, स्वचालित अग्रेषण की जाँच और उसे अक्षम करें, Morph ट्रांज़िशन और उसके प्रकारों का उपयोग करें, तथा ट्रांज़िशन प्रभाव विकल्प सेट करें। उदाहरण दर्शाते हैं कि प्रस्तुति को लोड या बनाएं, चयनित स्लाइड्स के लिए ट्रांज़िशन सेटिंग्स संशोधित करें, और परिणाम को PPTX फ़ाइल के रूप में सेव करें। लेख में ट्रांज़िशन गति, ट्रांज़िशन ध्वनियों, कई स्लाइड्स पर समान ट्रांज़िशन लागू करने, और स्लाइड पर वर्तमान में सेट ट्रांज़िशन की जाँच जैसे सामान्य प्रश्नों के उत्तर भी दिए गए हैं।

## **स्लाइड ट्रांज़िशन जोड़ें**
एक सरल स्लाइड ट्रांज़िशन प्रभाव बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. Aspose.Slides for Android via Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके स्लाइड पर TransitionType enum के माध्यम से स्लाइड ट्रांज़िशन प्रकार लागू करें।
3. परिवर्तित प्रस्तुति फ़ाइल लिखें।

```java
// स्रोत प्रस्तुति फ़ाइल लोड करने के लिए Presentation क्लास का उदाहरण बनाएं
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // प्रस्तुति को डिस्क पर लिखें
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**
ऊपर के अनुभाग में हमने केवल स्लाइड पर एक सरल ट्रांज़िशन इफ़ेक्ट लागू किया था। अब, इस सरल ट्रांज़िशन इफ़ेक्ट को और बेहतर तथा नियंत्रित बनाने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. Aspose.Slides for Android via Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके स्लाइड पर स्लाइड ट्रांज़िशन प्रकार लागू करें।
3. आप ट्रांज़िशन को क्लिक पर अग्रसर (Advance On Click), एक विशिष्ट समय अवधि के बाद या दोनों के रूप में सेट कर सकते हैं।
4. यदि स्लाइड ट्रांज़िशन को Advance On Click के लिए सक्षम किया गया है, तो ट्रांज़िशन केवल तब आगे बढ़ेगा जब कोई माउस पर क्लिक करेगा। इसके अलावा, यदि Advance After Time प्रॉपर्टी सेट है, तो ट्रांज़िशन निर्दिष्ट समय बीतने के बाद स्वतः आगे बढ़ेगा।
5. परिवर्तित प्रस्तुति को प्रस्तुति फ़ाइल के रूप में लिखें।

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // ट्रांज़िशन समय को 3 सेकंड सेट करें
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // ट्रांज़िशन समय को 5 सेकंड सेट करें
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // स्लाइड 3 पर ज़ूम प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // ट्रांज़िशन समय को 7 सेकंड सेट करें
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // प्रेजेंटेशन को डिस्क पर लिखें
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **मॉर्फ़ ट्रांज़िशन**
{{% alert color="primary" %}} 
Aspose.Slides for Android via Java अब [Morph Transition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMorphTransition) का समर्थन करता है। यह PowerPoint 2019 में प्रस्तुत किए गए नए मॉर्फ़ ट्रांज़िशन का प्रतिनिधित्व करता है।
{{% /alert %}} 

मॉर्फ़ ट्रांज़िशन आपको एक स्लाइड से अगली स्लाइड तक सुगम गति के साथ एनीमेट करने की अनुमति देता है। यह लेख अवधारणा और मॉर्फ़ ट्रांज़िशन के उपयोग के तरीके को बताता है। मॉर्फ़ ट्रांज़िशन को प्रभावी रूप से उपयोग करने के लिए आपको कम से कम एक सामान्य ऑब्जेक्ट के साथ दो स्लाइड्स चाहिए। सबसे आसान तरीका है स्लाइड को डुप्लिकेट करना और फिर दूसरे स्लाइड पर ऑब्जेक्ट को किसी अन्य स्थान पर ले जाना।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड की एक प्रतिलिपि कुछ टेक्स्ट के साथ प्रस्तुति में जोड़ें और दूसरे स्लाइड पर [morph type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TransitionType) का ट्रांज़िशन सेट करें।

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **मॉर्फ़ ट्रांज़िशन प्रकार**
[TransitionMorphType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TransitionMorphType) enum नया जोड़ा गया है। यह मॉर्फ़ स्लाइड ट्रांज़िशन के विभिन्न प्रकारों का प्रतिनिधित्व करता है।

TransitionMorphType enum में तीन सदस्य हैं:

- ByObject: मॉर्फ़ ट्रांज़िशन को आकृतियों को अमूर्त ऑब्जेक्ट्स के रूप में मानते हुए किया जाएगा।
- ByWord: जहाँ संभव हो, शब्दों में टेक्स्ट को स्थानांतरित करके मॉर्फ़ ट्रांज़िशन किया जाएगा।
- ByChar: जहाँ संभव हो, अक्षरों में टेक्स्ट को स्थानांतरित करके मॉर्फ़ ट्रांज़िशन किया जाएगा।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड पर मॉर्फ़ ट्रांज़िशन सेट करें और मॉर्फ़ प्रकार बदलें:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ट्रांज़िशन प्रभाव सेट करें**
Aspose.Slides for Android via Java ट्रांज़िशन प्रभाव जैसे कि ब्लैक से, बाएँ से, दाएँ से आदि सेट करने का समर्थन करता है। ट्रांज़िशन प्रभाव सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- ट्रांज़िशन प्रभाव सेट करें।
- प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने ट्रांज़िशन प्रभाव सेट किए हैं।

```java
// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // प्रभाव सेट करें
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // प्रस्तुति को डिस्क पर लिखें
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हाँ। ट्रांज़िशन की [speed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) को [TransitionSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionspeed/) सेटिंग का उपयोग करके सेट करें (जैसे, धीमी/मध्यम/तेज़)।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर इसे लूप कर सकता हूँ?**

हाँ। आप ट्रांज़िशन के लिए ध्वनि एम्बेड कर सकते हैं और ध्वनि मोड एवं लूपिंग जैसी सेटिंग्स (उदाहरण के लिए, [setSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), साथ ही मेटाडेटा जैसे [setSoundIsBuiltIn](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) और [setSoundName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)) के माध्यम से व्यवहार को नियंत्रित कर सकते हैं।

**सभी स्लाइड्स पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रत्येक स्लाइड की ट्रांज़िशन सेटिंग्स में वांछित ट्रांज़िशन प्रकार कॉन्फ़िगर करें; ट्रांज़िशन प्रत्येक स्लाइड में संग्रहीत होते हैं, इसलिए सभी स्लाइड्स पर समान प्रकार लागू करने से एक समान परिणाम मिलता है।

**मैं कैसे पता कर सकता हूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड की [transition settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) निरीक्षण करें और उसका [transition type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) पढ़ें; यह मान आपको सही-सही बताएगा कि कौन सा प्रभाव लागू है।