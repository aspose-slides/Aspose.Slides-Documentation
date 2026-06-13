---
title: Java का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/java/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मोर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड ट्रांज़िशन को अनुकूलित करने के तरीकों को जानें, जिसमें PowerPoint और OpenDocument प्रस्तुतियों के लिए चरण-दर-चरण मार्गदर्शन शामिल है।"
---
## **परिचय**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन को प्रबंधित करने का तरीका बताता है। यह दिखाता है कि कैसे स्लाइड्स पर ट्रांज़िशन प्रकार लागू करें, क्लिक करने पर या निर्दिष्ट समय के बाद आगे बढ़ने जैसी ट्रांज़िशन व्यवहार को कॉन्फ़िगर करें, स्वचालित अग्रसरता को जांचें और अक्षम करें, Morph ट्रांज़िशन और उसके प्रकारों का उपयोग करें, और ट्रांज़िशन इफ़ेक्ट विकल्प सेट करें। उदाहरण दर्शाते हैं कि कैसे प्रस्तुतियों को लोड या बनाएं, चयनित स्लाइड्स के लिए ट्रांज़िशन सेटिंग्स को संशोधित करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। लेख सामान्य प्रश्नों के उत्तर भी देता है जैसे ट्रांज़िशन गति, ट्रांज़िशन ध्वनियां, कई स्लाइड्स पर एक ही ट्रांज़िशन लागू करना, और किसी स्लाइड पर वर्तमान में सेट ट्रांज़िशन की जाँच करना।

## **स्लाइड ट्रांज़िशन जोड़ें**
एक सरल स्लाइड ट्रांज़िशन प्रभाव बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. Aspose.Slides for Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से किसी एक से TransitionType enum के माध्यम से स्लाइड पर Slide Transition Type लागू करें।
3. संशोधित प्रस्तुति फ़ाइल लिखें।

```java
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का उदाहरण बनाएं
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
ऊपर वाले भाग में, हमने केवल स्लाइड पर एक सरल ट्रांज़िशन प्रभाव लागू किया था। अब, इस सरल ट्रांज़िशन प्रभाव को और बेहतर और नियंत्रित बनाने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।
2. Aspose.Slides for Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से किसी एक से स्लाइड पर Slide Transition Type लागू करें।
3. आप ट्रांज़िशन को Advance On Click, किसी विशेष समय अवधि के बाद या दोनों पर सेट कर सकते हैं।
4. यदि स्लाइड ट्रांज़िशन Advance On Click के लिए सक्षम है, तो ट्रांज़िशन केवल तब आगे बढ़ेगा जब कोई माउस पर क्लिक करेगा। इसके अलावा, यदि Advance After Time प्रॉपर्टी सेट है, तो निर्दिष्ट समय बीतने के बाद ट्रांज़िशन स्वचालित रूप से आगे बढ़ेगा।
5. संशोधित प्रस्तुति को एक प्रस्तुति फ़ाइल के रूप में लिखें।

```java
// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
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

    // प्रस्तुति को डिस्क पर लिखें
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph ट्रांज़िशन**
{{% alert color="primary" %}} 

Aspose.Slides for Java अब [Morph Transition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMorphTransition) को समर्थन देता है। वे PowerPoint 2019 में प्रस्तुत नई मॉर्फ़ ट्रांज़िशन का प्रतिनिधित्व करते हैं।

{{% /alert %}} 

Morph ट्रांज़िशन आपको एक स्लाइड से अगले स्लाइड तक सुगम गति को एनीमेट करने की अनुमति देता है। यह लेख इस अवधारणा और Morph ट्रांज़िशन का उपयोग कैसे करें, इसे वर्णन करता है। Morph ट्रांज़िशन को प्रभावी रूप से उपयोग करने के लिए, आपके पास कम से कम एक सामान्य वस्तु के साथ दो स्लाइड्स होनी चाहिए। सबसे आसान तरीका है स्लाइड को डुप्लिकेट करना और फिर दूसरे स्लाइड पर वस्तु को किसी अलग स्थान पर ले जाना।

निम्नलिखित कोड स्निपेट दिखाता है कि कैसे प्रस्तुति में कुछ टेक्स्ट के साथ स्लाइड की क्लोन जोड़ें और दूसरे स्लाइड पर [morph type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TransitionType) का ट्रांज़िशन सेट करें।

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
नया [TransitionMorphType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TransitionMorphType) enum जोड़ा गया है। यह Morph स्लाइड ट्रांज़िशन के विभिन्न प्रकारों का प्रतिनिधित्व करता है।

TransitionMorphType enum में तीन सदस्य हैं:

- ByObject: Morph ट्रांज़िशन आकारों को अविभाज्य वस्तुओं के रूप में मानते हुए किया जाएगा।
- ByWord: जहाँ संभव हो, टेक्स्ट को शब्दों में विभाजित करके Morph ट्रांज़िशन किया जाएगा।
- ByChar: जहाँ संभव हो, टेक्स्ट को वर्णों में विभाजित करके Morph ट्रांज़िशन किया जाएगा।

निम्नलिखित कोड स्निपेट दिखाता है कि कैसे स्लाइड पर morph ट्रांज़िशन सेट करें और morph प्रकार बदलें:

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

## **ट्रांज़िशन इफ़ेक्ट सेट करें**
Aspose.Slides for Java काले से, बाएँ से, दाएँ से आदि जैसे ट्रांज़िशन इफ़ेक्ट सेट करने का समर्थन करता है। ट्रांज़िशन इफ़ेक्ट सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- ट्रांज़िशन इफ़ेक्ट सेट करना।
- प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने ट्रांज़िशन इफ़ेक्ट्स सेट किए हैं।

```java
// Presentation क्लास का एक उदाहरण बनाएं
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // इफ़ेक्ट सेट करें
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // प्रस्तुति को डिस्क पर लिखें
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हाँ। ट्रांज़िशन की [speed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) को [TransitionSpeed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionspeed/) सेटिंग का उपयोग करके सेट करें (जैसे, slow/medium/fast)।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर उसे लूप कर सकता हूँ?**

हाँ। आप ट्रांज़िशन के लिए ध्वनि एम्बेड कर सकते हैं और ध्वनि मोड तथा लूपिंग जैसी सेटिंग्स के माध्यम से व्यवहार नियंत्रित कर सकते हैं (जैसे, [setSound](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), साथ ही मेटा डेटा जैसे [setSoundIsBuiltIn](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) और [setSoundName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-))।

**हर स्लाइड पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रत्येक स्लाइड की ट्रांज़िशन सेटिंग्स में वांछित ट्रांज़िशन प्रकार कॉन्फ़िगर करें; ट्रांज़िशन प्रत्येक स्लाइड पर संग्रहीत होते हैं, इसलिए सभी स्लाइड्स पर एक ही प्रकार लागू करने से एक समान परिणाम मिलता है।

**मैं कैसे जांच सकता हूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [transition settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslide/#getSlideShowTransition--) को जांचें और उसके [transition type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setType-int-) को पढ़ें; यह मान आपको ठीक-ठीक बताता है कि कौन सा प्रभाव लागू किया गया है।