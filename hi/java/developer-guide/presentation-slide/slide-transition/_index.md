---
title: जावा का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/java/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मोर्फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड ट्रांज़िशन को अनुकूलित करने के तरीके खोजें, PowerPoint और OpenDocument प्रस्तुतियों के लिए चरणबद्ध मार्गदर्शन के साथ।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन को प्रबंधित करने के तरीके को समझाता है। यह दर्शाता है कि स्लाइड पर ट्रांज़िशन प्रकार कैसे लागू करें, क्लिक पर या निर्दिष्ट समय के बाद आगे बढ़ने जैसी ट्रांज़िशन व्यवहार को कॉन्फ़िगर करें, स्वचालित आगे बढ़ने को जाँचें और अक्षम करें, Morph ट्रांज़िशन और उसके प्रकारों का उपयोग करें, तथा ट्रांज़िशन इफ़ेक्ट विकल्प सेट करें। उदाहरण दिखाते हैं कि प्रस्तुति को लोड या बनाएं, चयनित स्लाइड्स के लिए ट्रांज़िशन सेटिंग्स संशोधित करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। लेख में ट्रांज़िशन गति, ट्रांज़िशन ध्वनि, कई स्लाइड्स पर समान ट्रांज़िशन लागू करने और स्लाइड पर वर्तमान में सेट ट्रांज़िशन को जाँचने के सामान्य प्रश्नों के उत्तर भी शामिल हैं।

## **स्लाइड ट्रांज़िशन जोड़ें**
एक सरल स्लाइड ट्रांज़िशन इफ़ेक्ट बनाने के लिए, नीचे दिए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. Aspose.Slides for Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से किसी एक का उपयोग करके स्लाइड पर Slide Transition Type लागू करें, जो TransitionType enum के माध्यम से उपलब्ध है।
3. संशोधित प्रस्तुति फ़ाइल लिखें।

```java
import com.aspose.slides.*;

// सोर्स प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास का उदाहरण बनाएं
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
ऊपर वाले भाग में हमने केवल एक सरल ट्रांज़िशन इफ़ेक्ट लागू किया था। अब, इस सरल ट्रांज़िशन इफ़ेक्ट को और बेहतर और नियंत्रित बनाने के लिए, नीचे दिए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. Aspose.Slides for Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से किसी एक का उपयोग करके स्लाइड पर Slide Transition Type लागू करें।
3. आप ट्रांज़िशन को Advance On Click, किसी विशिष्ट समय अवधि के बाद या दोनों पर सेट कर सकते हैं।
4. यदि स्लाइड ट्रांज़िशन को Advance On Click के लिए सक्षम किया गया है, तो ट्रांज़िशन केवल तब आगे बढ़ेगा जब कोई माउस क्लिक करेगा। इसके अलावा, यदि Advance After Time प्रॉपर्टी सेट है, तो निर्दिष्ट समय बीतने के बाद ट्रांज़िशन स्वतः आगे बढ़ेगा।
5. संशोधित प्रस्तुति को एक प्रस्तुति फ़ाइल के रूप में लिखें।

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // स्लाइड 1 पर सर्कल प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 3 सेकंड का ट्रांज़िशन समय सेट करें
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 5 सेकंड का ट्रांज़िशन समय सेट करें
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // स्लाइड 3 पर ज़ूम प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 7 सेकंड का ट्रांज़िशन समय सेट करें
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // प्रस्तुति को डिस्क पर लिखें
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **मोर्फ ट्रांज़िशन**
{{% alert color="info" %}} 

Aspose.Slides for Java अब [Morph Transition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMorphTransition) का समर्थन करता है। यह PowerPoint 2019 में प्रस्तुत नया मोर्फ ट्रांज़िशन है।

{{% /alert %}} 

Morph ट्रांज़िशन आपको एक स्लाइड से अगली स्लाइड तक सुगम गति के साथ एनीमेट करने की अनुमति देता है। यह लेख अवधारणा और Morph ट्रांज़िशन के उपयोग को वर्णित करता है। प्रभावी रूप से Morph ट्रांज़िशन का उपयोग करने के लिए, आपके पास कम से कम एक सामान्य वस्तु वाले दो स्लाइड्स होने चाहिए। सबसे आसान तरीका है स्लाइड को डुप्लिकेट करना और फिर दूसरी स्लाइड पर वस्तु को किसी अलग स्थान पर ले जाना।

निम्नलिखित कोड स्निपेट दिखाता है कि प्रस्तुति में कुछ टेक्स्ट वाली स्लाइड की एक क्लोन कैसे जोड़ें और दूसरी स्लाइड पर [morph type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TransitionType) का ट्रांज़िशन सेट करें।

```java
import com.aspose.slides.*;

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

## **मोर्फ ट्रांज़िशन प्रकार**
नया [TransitionMorphType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/TransitionMorphType) enum जोड़ा गया है। यह विभिन्न प्रकार के मोर्फ स्लाइड ट्रांज़िशन को दर्शाता है।

TransitionMorphType enum में तीन सदस्य हैं:

- ByObject: Morph ट्रांज़िशन को आकारों को अविभाज्य वस्तुओं के रूप में मानते हुए किया जाएगा।
- ByWord: Morph ट्रांज़िशन को जहाँ संभव हो शब्दों द्वारा टेक्स्ट स्थानांतरित करके किया जाएगा।
- ByChar: Morph ट्रांज़िशन को जहाँ संभव हो अक्षरों द्वारा टेक्स्ट स्थानांतरित करके किया जाएगा।

```java
import com.aspose.slides.*;

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
Aspose.Slides for Java काली, बायीं, दायीं आदि जैसे ट्रांज़िशन इफ़ेक्ट सेट करने का समर्थन करता है। ट्रांज़िशन इफ़ेक्ट सेट करने के लिए, नीचे दिए चरणों का पालन करें:

- [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- ट्रांज़िशन इफ़ेक्ट सेट करें।
- प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

निम्न उदाहरण में हमने ट्रांज़िशन इफ़ेक्ट सेट किए हैं।

```java
import com.aspose.slides.*;

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

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति को नियंत्रित कर सकता हूँ?

हां। ट्रांज़िशन की [speed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) को [TransitionSpeed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionspeed/) सेटिंग का उपयोग करके सेट करें (जैसे, धीमी/मध्यम/तेज़)।

### क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?

हां। आप ट्रांज़िशन के लिए ध्वनि एम्बेड कर सकते हैं और ध्वनि मोड व लूपिंग जैसे सेटिंग्स (जैसे, [setSound](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), साथ ही मेटाडेटा जैसे [setSoundIsBuiltIn](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) और [setSoundName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)) के माध्यम से नियंत्रित कर सकते हैं।

### सभी स्लाइड्स पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?

प्रत्येक स्लाइड की ट्रांज़िशन सेटिंग्स में वांछित ट्रांज़िशन प्रकार को कॉन्फ़िगर करें; ट्रांज़िशन प्रत्येक स्लाइड पर अलग से संग्रहीत होते हैं, इसलिए सभी स्लाइड्स पर वही प्रकार लागू करने से एकसमान परिणाम मिलेगा।

### मैं कैसे जाँच सकता हूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?

स्लाइड की [transition settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseslide/#getSlideShowTransition--) को निरीक्षण करें और उसके [transition type](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slideshowtransition/#setType-int-) को पढ़ें; यह मान बताता है कि कौन सा इफ़ेक्ट लागू किया गया है।