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
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइड्स के प्रकट होने को नियंत्रित करती हैं। Aspose.Slides for Android via Java के साथ, आप प्रत्येक स्लाइड के लिए ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट‑विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख जावा उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधन करता है, और दो स्लाइड्स के बीच Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रेज़ेंटेशन लोड करें और स्लाइड की ट्रांज़िशन सेटिंग्स तक [getSlideShowTransition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) द्वारा पहुँचें। [TransitionType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitiontype/) एनीमरेशन से मान के साथ [setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) का उपयोग करें, फिर प्रेज़ेंटेशन को सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर रहती है और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाता है। निम्नलिखित मेथड्स इस व्यवहार को नियंत्रित करते हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) व्यूअर को माउस क्लिक करके आगे बढ़ने की अनुमति देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) स्वचालित आगे बढ़ने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) स्वचालित आगे बढ़ने से पहले विलंब को मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ने को सक्षम करें ताकि व्यूअर क्लिक करके आगे बढ़ सके या टाइमर की प्रतीक्षा कर सके। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) को `false` पास करें। विलंब निर्धारित करता है कि स्लाइड शो कब आगे बढ़ता है; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करता।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5 और 7 सेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है। माउस क्लिक से भी इन स्लाइड्स को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

सदस्यता जांचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) को कॉल करें। केवल संग्रहीत विलंब यह संकेत नहीं देता कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइड्स के लिए स्वचालित आगे बढ़ना अक्षम करता है। उन स्लाइड्स के लिए माउस क्लिक सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ट्रांज़िशन टाइमिंग को सटीक रूप से नियंत्रित करें**

ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई मिलीसेकंड में निर्दिष्ट करने के लिए [setDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) का उपयोग करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) मेथड इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/) के माध्यम से उजागर करती है:

| विधि | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | ट्रांज़िशन इफ़ेक्ट की अवधि को स्वयं, मिलीसेकंड में सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले विलंब को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | पूर्वनिर्धारित गति श्रेणी को [TransitionSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionspeed/) से चुनता है: Slow, Medium, या Fast। यह तब उपयोग किया जाता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[setDuration] केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह नहीं निर्धारित करता कि स्लाइड कितनी देर तक दिखाई देती है। स्वचालित आगे बढ़ने के विलंब को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि नहीं दी गई हो, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) मान के आधार पर इफ़ेक्ट अवधि निर्धारित करता है।

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType] से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5,000 मिलीसेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // प्रभाव अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ने को कॉन्फ़िगर करें.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **विभिन्न स्लाइड्स के लिए अलग-अलग अवधि सेट करें**

विभिन्न स्लाइड्स अलग-अलग इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के तौर पर, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए लंबा ट्रांज़िशन। यह उदाहरण पहले स्लाइड के लिए 500 मिलीसेकंड और दूसरे के लिए 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन को समन्वित करें**

जब आप [animated GIF](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/androidjava/export-to-html5/), या [video](/slides/hi/androidjava/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खा सके। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का फ़ेड उपयोग करें, और प्रत्येक स्लाइड के एडवांसमेंट विलंब को अलग से समायोजित करें ताकि उसकी व्याख्या या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम दर को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 फ़्रेम प्रति सेकंड पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने गए निर्यात प्रारूप के समर्थित इफ़ेक्ट और टाइमिंग विकल्पों की जाँच करें, और आउटपुट का पूर्वावलोकन करके समकालिकता की पुष्टि करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

[getDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) को ट्रांज़िशन को संशोधित करने से पहले कॉल करें ताकि पता चल सके कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; गैर-नकारात्मक मान मिलीसेकंड में संग्रहीत अवधि को दर्शाता है। यह अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) मान से वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि आरम्भ हो सकती है, इसलिए पहले मूल सेटिंग्स की जाँच करें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph ट्रांज़िशन**

Morph ट्रांज़िशन लगातार स्लाइडों के बीच वस्तुओं में बदलाव को एनीमेट करता है। एक सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरे स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थिति के बीच एनीमेट करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionmorphtype/) एनीमरेशन यह निर्धारित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक सम्पूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) टेक्स्ट को शब्दों के आधार पर एनीमेट करता है जहाँ संभव हो।
- [ByChar](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) टेक्स्ट को अक्षरों के आधार पर एनीमेट करता है जहाँ संभव हो।

[setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) का उपयोग करके Morph चुनें, फिर [getValue](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#getValue--) को कॉल करें। यह मान [IMorphTransition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imorphtransition/) इंटरफ़ेस प्रदान करता है, जिसका [setMorphType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) मेथड मिलान मोड को चुनता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प प्रदान करते हैं, जैसे दिशा या क्या इफ़ेक्ट काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प उस ट्रांज़िशन पर निर्भर करते हैं जो आप [setType] से चुनते हैं। पहले प्रकार सेट करें, फिर [getValue] से उपयुक्त इंटरफ़ेस का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [setFromBlack](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) को [IOptionalBlackTransition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ioptionalblacktransition/) के माध्यम से कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति को नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [setDuration](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) पसंद करें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionspeed/) श्रेणी—Slow, Medium, या Fast—पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [setSpeed](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने के विलंब से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूँ और इसे लूप कर सकता हूँ?**

हाँ। आप [setSound](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) के साथ एम्बेडेड ऑडियो असाइन कर सकते हैं, [TransitionSoundMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitionsoundmode/) से StartSound को [setSoundMode](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) में पास करें, और [setSoundLoop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) को `true` करके लूप सक्षम करें। ऑडियो तब अगले साउंड इवेंट तक लूप करता रहेगा।

**हर स्लाइड पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेज़ेंटेशन के [getSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) संग्रह के माध्यम से लूप करें और प्रत्येक स्लाइड के ट्रांज़िशन पर समान मान के साथ [setType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) को कॉल करें। उसी लूप में टाइमिंग और इफ़ेक्ट विकल्प भी सेट करें ताकि सभी स्लाइड्स पर व्यवहार समान रहे।

**मैं कैसे जांच सकता हूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) परिणाम पर [getType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islideshowtransition/#getType--) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/transitiontype/) एनीमरेशन से मान लौटाता है; None का अर्थ है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।