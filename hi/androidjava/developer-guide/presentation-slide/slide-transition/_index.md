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
- मोर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java में स्लाइड ट्रांज़िशन को कस्टमाइज़ करने के लिए चरण-दर-चरण मार्गदर्शन के साथ PowerPoint और OpenDocument प्रस्तुतियों के लिए खोजें।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करने के तरीके को समझाता है। यह दिखाता है कि स्लाइड पर ट्रांज़िशन प्रकार कैसे लागू करें, ट्रांज़िशन व्यवहार को कॉन्फ़िगर करें जैसे कि क्लिक पर या निर्धारित समय के बाद आगे बढ़ना, Morph ट्रांज़िशन और उसके प्रकार का उपयोग करना, और ट्रांज़िशन इफ़ेक्ट विकल्प सेट करना। उदाहरण दिखाते हैं कि प्रस्तुति को लोड या बनाएं, चयनित स्लाइडों के लिए ट्रांज़िशन सेटिंग्स संशोधित करें, और परिणाम को PPTX फ़ाइल के रूप में सहेजें। लेख सामान्य प्रश्नों के उत्तर भी देता है जैसे ट्रांज़िशन गति, ट्रांज़िशन ध्वनियां, कई स्लाइडों पर समान ट्रांज़िशन लागू करना, और स्लाइड पर वर्तमान में सेट किए गए ट्रांज़िशन की जांच करना।

## **स्लाइड ट्रांज़िशन जोड़ें**
एक सरल स्लाइड ट्रांज़िशन इफ़ेक्ट बनाने के लिए, नीचे दिए गए चरणों का पालन करें:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं।
2. Aspose.Slides for Android via Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके स्लाइड पर TransitionType एनोम के माध्यम से एक स्लाइड ट्रांज़िशन प्रकार लागू करें।
3. संशोधित प्रस्तुति फ़ाइल लिखें।

```java
import com.aspose.slides.*;

// स्रोत प्रस्तुति फ़ाइल लोड करने के लिए Presentation क्लास को इंस्टैंशिएट करें
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
ऊपर के अनुभाग में हमने केवल एक सरल ट्रांज़िशन इफ़ेक्ट लागू किया था। अब, इस सरल ट्रांज़िशन इफ़ेक्ट को और बेहतर और नियंत्रित बनाने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का उदाहरण बनाएं।
2. Aspose.Slides for Android via Java द्वारा प्रदान किए गए ट्रांज़िशन इफ़ेक्ट्स में से एक का उपयोग करके स्लाइड पर TransitionType एनोम के माध्यम से एक स्लाइड ट्रांज़िशन प्रकार लागू करें।
3. आप ट्रांज़िशन को Advance On Click, एक विशिष्ट समय अवधि के बाद या दोनों के रूप में भी सेट कर सकते हैं।
4. यदि स्लाइड ट्रांज़िशन Advance On Click पर सक्षम है, तो ट्रांज़िशन केवल तब आगे बढ़ेगा जब कोई माउस क्लिक करेगा। इसके अलावा, यदि Advance After Time गुणधर्म सेट किया गया है, तो ट्रांज़िशन निर्दिष्ट समय समाप्त होने पर स्वचालित रूप से आगे बढ़ेगा।
5. संशोधित प्रस्तुति को एक प्रस्तुति फ़ाइल के रूप में लिखें।

```java
import com.aspose.slides.*;

// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // स्लाइड 1 पर सर्किल प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // क्लिक पर या 3 सेकंड के बाद स्वचालित रूप से आगे बढ़ें
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // स्लाइड 2 पर कॉम्ब प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // क्लिक पर या 5 सेकंड के बाद स्वचालित रूप से आगे बढ़ें
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // स्लाइड 3 पर ज़ूम प्रकार का ट्रांज़िशन लागू करें
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // क्लिक पर या 7 सेकंड के बाद स्वचालित रूप से आगे बढ़ें
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // प्रस्तुति को डिस्क पर लिखें
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph ट्रांज़िशन**
{{% alert color="info" %}} 

Aspose.Slides for Android via Java अब [Morph ट्रांज़िशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMorphTransition) का समर्थन करता है। ये PowerPoint 2019 में पेश किए गए नए मोर्फ़ ट्रांज़िशन का प्रतिनिधित्व करते हैं।

{{% /alert %}} 

Morph ट्रांज़िशन आपको एक स्लाइड से अगली स्लाइड तक सुगम आंदोलन को एनीमेट करने की अनुमति देता है। यह लेख अवधारणा और Morph ट्रांज़िशन के उपयोग को वर्णित करता है। प्रभावी रूप से Morph ट्रांज़िशन का उपयोग करने के लिए, आपके पास कम से कम एक साझा ऑब्जेक्ट वाले दो स्लाइड होने चाहिए। सबसे आसान तरीका है स्लाइड को डुप्लिकेट करना और फिर दूसरी स्लाइड पर ऑब्जेक्ट को किसी अन्य स्थान पर ले जाना।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड की एक क्लोन को कुछ टेक्स्ट के साथ प्रस्तुति में जोड़ें और दूसरी स्लाइड पर [morph प्रकार](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TransitionType) का ट्रांज़िशन सेट करें।

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

## **Morph ट्रांज़िशन प्रकार**
नया [TransitionMorphType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/TransitionMorphType) एनोम जोड़ दिया गया है। यह विभिन्न प्रकार के Morph स्लाइड ट्रांज़िशन को दर्शाता है।

TransitionMorphType एनोम के तीन सदस्य हैं:

- ByObject: Morph ट्रांज़िशन आकारों को अविभाज्य ऑब्जेक्ट के रूप में मानते हुए किया जाएगा।
- ByWord: Morph ट्रांज़िशन जहाँ संभव हो वहाँ शब्दों के द्वारा टेक्स्ट स्थानांतरण के साथ किया जाएगा।
- ByChar: Morph ट्रांज़िशन जहाँ संभव हो वहाँ अक्षरों के द्वारा टेक्स्ट स्थानांतरण के साथ किया जाएगा।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड पर मोर्फ़ ट्रांज़िशन सेट करें और मोर्फ़ प्रकार बदलें:

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
Aspose.Slides for Android via Java ब्लैक से, बाएँ से, दाएँ से आदि जैसे ट्रांज़िशन इफ़ेक्ट सेट करने का समर्थन करता है। ट्रांज़िशन इफ़ेक्ट सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

- एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का उदाहरण बनाएं।
- स्लाइड का रेफ़रेंस प्राप्त करें।
- ट्रांज़िशन इफ़ेक्ट सेट करें।
- प्रस्तुति को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने ट्रांज़िशन इफ़ेक्ट सेट किए हैं।

```java
import com.aspose.slides.*;

// Presentation क्लास का एक इंस्टेंस बनाएं
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // इफ़ेक्ट सेट करें
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // प्रेजेंटेशन को डिस्क पर लिखें
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?
हाँ। ट्रांज़िशन की [speed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) को [TransitionSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionspeed/) सेटिंग (जैसे slow/medium/fast) का उपयोग करके सेट करें।

### क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूँ और इसे लूप कर सकता हूँ?
हाँ। आप ट्रांज़िशन के लिए साउंड एम्बेड कर सकते हैं और साउंड मोड एवं लूपिंग जैसी सेटिंग्स (जैसे [setSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), साथ ही [setSoundIsBuiltIn](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) और [setSoundName](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)) से नियंत्रित कर सकते हैं।

### सभी स्लाइडों पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?
प्रत्येक स्लाइड की ट्रांज़िशन सेटिंग्स में वांछित ट्रांज़िशन प्रकार कॉन्फ़िगर करें; ट्रांज़िशन प्रत्येक स्लाइड पर अलग-अलग संग्रहीत होते हैं, इसलिए सभी स्लाइडों पर वही प्रकार लागू करने से एकसमान परिणाम मिलता है।

### मैं किसी स्लाइड पर वर्तमान में सेट किए गए ट्रांज़िशन की जाँच कैसे कर सकता हूँ?
स्लाइड की [transition settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) को निरीक्षण करें और उसकी [transition type](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) को पढ़ें; यह मान आपको ठीक वही प्रभाव बताता है जो लागू किया गया है।