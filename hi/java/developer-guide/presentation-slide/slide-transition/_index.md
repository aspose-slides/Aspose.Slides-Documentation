---
title: "जावा का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें"
linktitle: "स्लाइड ट्रांज़िशन"
type: docs
weight: 80
url: /hi/java/slide-transition/
keywords:
- "स्लाइड ट्रांज़िशन"
- "स्लाइड ट्रांज़िशन जोड़ें"
- "स्लाइड ट्रांज़िशन लागू करें"
- "उन्नत स्लाइड ट्रांज़िशन"
- "मॉर्फ ट्रांज़िशन"
- "ट्रांज़िशन प्रकार"
- "ट्रांज़िशन इफ़ेक्ट"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **परिचय**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइडों के दिखाई देने के तरीके को नियंत्रित करती हैं। Aspose.Slides for Java के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट के विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख जावा उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधन करता है, और दो स्लाइडों के बीच Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का उपयोग करके एक प्रस्तुति लोड करें और [getSlideShowTransition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुँचें। [TransitionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitiontype/) एन्यूमरेशन से मान के साथ [setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setType-int-) का उपयोग करें, फिर प्रस्तुति सहेजें।

निम्नलिखित उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

आप स्क्रीन पर स्लाइड कितनी देर तक रहती है और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाता है, इसे कॉन्फ़िगर कर सकते हैं। निम्नलिखित मेथड्स इस व्यवहार को नियंत्रित करते हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) दर्शक को माउस क्लिक करके आगे बढ़ने देती है।
- [setAdvanceAfter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) स्वचालित आगे बढ़ने को सक्षम करती है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) स्वचालित आगे बढ़ने से पहले की देरी को मिलीसेकंड में निर्दिष्ट करती है।

क्लिक और टाइम्ड दोनों आगे बढ़ने को सक्षम करें ताकि दर्शक क्लिक करके आगे बढ़ सके या टाइमर की प्रतीक्षा करे। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) को `false` पास करें। देरी तय करती है कि स्लाइड शो कब आगे बढ़ेगा; यह विज़ुअल ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करती।

यह उदाहरण पहले तीन स्लाइडों को अलग-अलग इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5 और 7 सेकंड के बाद स्वचालित आगे बढ़ने को सक्षम करता है। माउस क्लिक से भी इन स्लाइडों को आगे बढ़ाया जा सकता है। कम से कम तीन स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

यह जांचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter-boolean-) को कॉल करें। केवल संग्रहीत देरी इस बात का संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल खोलता है, प्रत्येक सक्षम टाइमर को रिपोर्ट करता है, और दो सेकंड से अधिक देरी वाली स्लाइडों के लिए स्वचालित आगे बढ़ने को निष्क्रिय करता है। उन स्लाइडों के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

[setDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setDuration-int-) का उपयोग करके ट्रांज़िशन इफ़ेक्ट की सटीक अवधि मिलीसेकंड में निर्दिष्ट करें। स्लाइड का [getSlideShowTransition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) मेथड इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/) के माध्यम से उजागर करता है:

| विधि | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | ट्रांज़िशन इफ़ेक्ट की अवधि स्वयं को मिलीसेकंड में सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | स्लाइड के स्वचालित आगे बढ़ने से पहले की देरी को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | पूर्वनिर्धारित गति वर्ग को [TransitionSpeed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionspeed/) से चुनता है: Slow, Medium, या Fast। यह तब उपयोग किया जाता है जब सटीक अवधि निर्दिष्ट नहीं होती। |

[setDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setDuration-int-) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दिखाई देती रहे। स्वचालित आगे बढ़ने की देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन टाइप और [getSpeed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#getSpeed--) मान से इफ़ेक्ट की अवधि निर्धारित करता है।

### **प्रत्येक स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर एक ही इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5,000 मिलीसेकंड के बाद स्वचालित आगे बढ़ने को सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ने को निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ने को कॉन्फ़िगर करें।
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **व्यक्तिगत स्लाइडों के लिए विभिन्न अवधि सेट करें**

विभिन्न स्लाइडें विभिन्न इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए एक संक्षिप्त ट्रांज़िशन और सेक्शन परिचय के लिए एक लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहले स्लाइड के लिए 500 मिलीसेकंड और दूसरे के लिए 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब आप एक [animated GIF](/slides/hi/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/java/export-to-html5/), या [video](/slides/hi/java/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि वांछित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का Fade उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देरी को अलग से समायोजित करें ताकि उसके वॉयसओवर या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 फ़्रेम प्रति सेकंड पर 18 फ़्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने गए निर्यात फ़ॉर्मेट के समर्थित इफ़ेक्ट्स और टाइमिंग विकल्पों की जाँच करें, और सिंक्रनाइज़ेशन की पुष्टि करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

[getDuration](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#getDuration--) को ट्रांज़िशन में बदलाव करने से पहले कॉल करें ताकि यह पता चले कि कोई स्पष्ट मान संग्रहीत है या नहीं। मान `-1` का अर्थ है कोई स्पष्ट अवधि सेट नहीं है; एक गैर-नकारात्मक मान संग्रहीत अवधि को मिलीसेकंड में निर्दिष्ट करता है। अनसेट मान गणना किए गए प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन टाइप और [getSpeed](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#getSpeed--) मान का उपयोग करके वह अवधि निर्धारित करता है। ट्रांज़िशन टाइप सेट करने से अवधि प्रारंभ हो सकती है, इसलिए पहले मूल सेटिंग्स की जाँच करें।

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

Morph ट्रांज़िशन क्रमागत स्लाइडों पर वस्तुओं के बीच बदलावों को एनीमेट करती है। एक सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरे स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनीमेट करता है।

निम्नलिखित उदाहरण एक टेक्स्ट आयत के साथ स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर यह दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitiontype/) एन्यूमरेशन से Morph चुनता है। सहेजी गई फ़ाइल को Morph समर्थित प्रस्तुतिकरण व्यूअर में खोलें ताकि स्लाइड शो के दौरान इफ़ेक्ट देख सकें।

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

[TransitionMorphType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionmorphtype/) एन्यूमरेशन नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकृति को एक समग्र वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionmorphtype/#ByWord) जहाँ संभव हो शब्दों के मिलान से टेक्स्ट को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionmorphtype/#ByChar) जहाँ संभव हो अक्षरों के मिलान से टेक्स्ट को एनीमेट करता है।

Morph को चुनने के लिए [setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setType-int-) का उपयोग करें, फिर [getValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#getValue--) तक पहुँचें। यह मान [IMorphTransition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imorphtransition/) इंटरफ़ेस प्रदान करता है, जिसका [setMorphType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imorphtransition/#setMorphType-int-) मेथड मिलान मोड चुनता है।

यह उदाहरण पिछले अनुभाग में बनाई गई प्रस्तुति खोलता है और दूसरे स्लाइड को शब्द-आधारित Morph एनीमेशन उपयोग करने के लिए कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प प्रदान करती हैं, जैसे दिशा या इफ़ेक्ट का ब्लैक स्क्रीन से शुरू होना। उपलब्ध विकल्प [setType] द्वारा चयनित ट्रांज़िशन पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर [getValue] से उपयुक्त इंटरफ़ेस का उपयोग करें।

निम्नलिखित उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [IOptionalBlackTransition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioptionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) को कॉल करता है ताकि ट्रांज़िशन ब्लैक स्क्रीन से शुरू हो।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूं?**

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [setDuration] को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed] श्रेणी—Slow, Medium, या Fast—पर्याप्त हो और कोई स्पष्ट अवधि सेट न की गई हो, तो [setSpeed] का उपयोग करें। ये सेटिंग्स स्वचालित आगे बढ़ने की देरी से स्वतंत्र रूप से ट्रांज़िशन इफ़ेक्ट को नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूं और उसे लूप कर सकता हूं?**

हाँ। एम्बेडेड ऑडियो को [setSound](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) के साथ असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitionsoundmode/) एन्यूमरेशन से StartSound को [setSoundMode](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) को पास करें, और [setSoundLoop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) को `true` के साथ सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप करता रहता है।

**हर स्लाइड पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रस्तुति की [getSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSlides--) कलेक्शन पर लूप करें और प्रत्येक स्लाइड के ट्रांज़िशन के लिए एक ही मान के साथ [setType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#setType-int-) को कॉल करें। एक ही लूप में कोई भी टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि स्लाइडों में व्यवहार समान रहे।

**मैं कैसे जांच सकता हूं कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

[ getSlideShowTransition](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) परिणाम पर [getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islideshowtransition/#getType--) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/transitiontype/) एन्यूमरेशन से एक मान लौटाता है; None का अर्थ है कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।