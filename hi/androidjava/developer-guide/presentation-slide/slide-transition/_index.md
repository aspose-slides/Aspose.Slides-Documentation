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
- मॉर्फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ना कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन इफ़ेक्ट को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन यह नियंत्रित करता है कि स्लाइड शो के दौरान स्लाइड्स कैसे दिखाई देती हैं। Aspose.Slides for Android via Java के साथ, आप प्रत्येक स्लाइड के लिए ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, तथा इफ़ेक्ट‑विशिष्ट विकल्प समायोजित कर सकते हैं। यह लेख Java उदाहरणों का उपयोग करके ट्रांज़िशन लागू करना, सटीक ट्रांज़िशन अवधि सेट करना, स्लाइड टाइमिंग प्रबंधित करना, और दो स्लाइड्स के बीच Morph ट्रांज़िशन बनाना दर्शाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, प्रस्तुति को [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास से लोड करें और स्लाइड की ट्रांज़िशन सेटिंग्स को [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) के माध्यम से एक्सेस करें। [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) को [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) एनीमरेशन से मान देकर उपयोग करें, फिर प्रस्तुति को सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाले `input.pptx` फ़ाइल का उपयोग करें।

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

## **व्हील ट्रांज़िशन**

[IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) की [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) विधि उस रेडियल सेक्टर की संख्या को नियंत्रित करती है जिससे लक्ष्य स्लाइड प्रकट होती है। ट्रांज़िशन प्रकार को [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) से Wheel पर सेट करके [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) को कॉल करें, फिर [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) को [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान स्लाइड जोड़े बनाता है: एक काली स्लाइड उसके बाद सोने के आयत वाला स्लाइड। लक्ष्य स्लाइड्स के लिए स्पोक काउंट क्रमशः 1 और 8 दिया गया है, और दोनों में समान गति [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) तथा स्पष्ट अवधि 8,000 ms को [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) द्वारा सेट किया गया है, जिससे अंतर स्पष्ट दिखे।

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    int gold = Color.rgb(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आउटपुट प्रस्तुति को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2, फिर स्लाइड 3 से स्लाइड 4 तक आगे बढ़ें। PowerPoint में प्लेबैक के दौरान, पुष्टि किया गया स्पोक काउंट 1 स्लाइड को एक घड़ी की दिशा वाले स्वीप से दिखाता है; काउंट 8 स्लाइड को एक साथ आठ रेडियल सेक्टर से दिखाता है। लक्ष्य सामग्री और ट्रांज़िशन टाइमिंग समान हैं, इसलिए अंतर केवल दिखावे वाले सेक्टरों की संख्या में है।

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाता है। निम्न विधियाँ इस व्यवहार को नियंत्रित करती हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) दर्शक को माउस क्लिक करके स्लाइड शो आगे बढ़ाने की अनुमति देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) स्वचालित आगे बढ़ने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) स्वचालित आगे बढ़ने से पहले देरी (मिलीसेकंड में) निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ने को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर के समाप्त होने पर आगे बढ़े। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) को `false` पास करें। देरी यह निर्धारित करती है कि स्लाइड शो कब आगे बढ़े; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करती।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट्स सौंपता है और क्रमशः 3, 5 और 7 सेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है। माउस क्लिक भी इन स्लाइड्स को आगे बढ़ा सकते हैं। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

टाइम्ड आगे बढ़ना सक्षम है या नहीं, यह जांचने के लिए [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) को कॉल करें। केवल संग्रहीत देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक देरी वाले स्लाइड्स के लिए स्वचालित आगे बढ़ना निष्क्रिय करता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई मिलीसेकंड में निर्दिष्ट करने के लिए [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) का उपयोग करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) विधि इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/) के माध्यम से उजागर करती है:

| विधि | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | ट्रांज़िशन इफ़ेक्ट की अवधि को मिलिसेकंड में सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | स्लाइड के स्वचालित आगे बढ़ने से पहले की देरी को मिलिसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) से पूर्वनिर्धारित गति श्रेणी (Slow, Medium, Fast) चुनता है। जब सटीक अवधि निर्दिष्ट न हो तो यह उपयोग होता है। |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह इस बात को निर्धारित नहीं करता कि स्लाइड कितनी देर दिखाई दे। स्वचालित आगे बढ़ने की देरी को अलग से कॉन्फ़िगर करें। जब स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) मान से अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![विभाजित बार 750‑ms ट्रांज़िशन अवधि और 5,000‑ms स्वचालित आगे बढ़ने की सेटिंग को दर्शाते हैं।](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*साझा उदाहरण प्रत्येक स्लाइड को 750‑ms Fade ट्रांज़िशन देता है और अलग से 5,000 ms पर स्वचालित आगे बढ़ना सक्षम करता है। ट्रांज़िशन अवधि इफ़ेक्ट को नियंत्रित करती है; आगे बढ़ना निर्धारित करता है कि स्लाइड कब छोड़ी जाए। ये बार स्कीमैटिक सेटिंग्स हैं, न कि मापी गई संयुक्त टाइमलाइन।*
<!-- visual-explanation:slide-transition:end -->

### **प्रत्येक स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिये, सभी स्लाइड्स पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 ms की अवधि देता है। यह अलग से 5,000 ms के बाद स्वचालित आगे बढ़ना सक्षम करता है तथा माउस क्लिक द्वारा आगे बढ़ना निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

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

### **व्यक्तिगत स्लाइड्स के लिए अलग-अलग अवधि निर्धारित करें**

विभिन्न स्लाइड्स अलग‑अलग इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के लिये, शीर्षक स्लाइड के लिये छोटा ट्रांज़िशन और विभाजन परिचय के लिये लंबा ट्रांज़िशन। यह उदाहरण पहली स्लाइड को 500 ms और दूसरी स्लाइड को 1,200 ms की अवधि देता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

जब आप [animated GIF](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/androidjava/export-to-html5/) या [video](/slides/hi/androidjava/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिये, दृश्यों के बीच 600‑ms फ़ेड उपयोग करें, तथा प्रत्येक स्लाइड की आगे बढ़ने की देरी को अलग से समायोजित करें ताकि उसकी व्याख्या या सामग्री के लिये पर्याप्त समय हो।

GIF और वीडियो के लिये, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 ms का मतलब 30 fps पर 18 फ्रेम है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने गये निर्यात फ़ॉर्मेट द्वारा समर्थित इफ़ेक्ट और टाइमिंग विकल्प जाँचें, तथा सिंक्रनाइज़ेशन की पुष्टि के लिये आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) को कॉल करके देखें कि क्या स्पष्ट मान संग्रहीत है। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; शून्य या अधिक मान मिलीसेकंड में संग्रहीत अवधि को दर्शाता है। यह अनसेट मान गणना किया गया प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) मान से वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि इनिशियलाइज़ हो सकती है, इसलिए मूल सेटिंग्स को पहले निरीक्षण करें।

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

Morph ट्रांज़िशन क्रमिक स्लाइड्स पर वस्तुओं के बीच बदलावों को एनिमेट करता है। सरल Morph इफ़ेक्ट बनाने के लिये, एक स्लाइड को क्लोन करें, क्लोन पर वस्तु को ले जाएँ या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे संबंधित वस्तुएँ अपनी मूल एवं संशोधित स्थिति के बीच एनिमेट होती हैं।

निम्न उदाहरण एक टेक्स्ट आयत वाला स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर दूसरे स्लाइड के लिये [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) एनीमरेशन से Morph चुनता है। Morph को सपोर्ट करने वाले प्रस्तुति व्यूअर में सहेजी फ़ाइल खोलें ताकि स्लाइड शो में इफ़ेक्ट देखा जा सके।

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

[TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) एनीमरेशन यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनिमेट करता है:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को पूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) संभव होने पर शब्दों को मिलाकर टेक्स्ट को एनिमेट करता है।
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) संभव होने पर अक्षरों को मिलाकर टेक्स्ट को एनिमेट करता है।

[setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) से Morph चुनें, फिर [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) को एक्सेस करें। यह मान आपको [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) इंटरफ़ेस देता है, जिसके [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) विधि से मिलान मोड चुना जाता है।

यह उदाहरण पिछले खंड में निर्मित प्रस्तुति को खोलता है और दूसरे स्लाइड को शब्द‑आधारित Morph एनिमेशन उपयोग करने के लिये कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या प्रभाव का काली स्क्रीन से आरम्भ होना। उपलब्ध विकल्प उन ट्रांज़िशन पर निर्भर करते हैं जिन्हें आप [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) से चुनते हैं। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) से उपयुक्त इंटरफ़ेस उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हां। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए हो तो [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) श्रेणी—Slow, Medium, या Fast—पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने की देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो जोड़ सकता हूँ और उसे लूप कर सकता हूँ?**

हां। [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) से एम्बेडेड ऑडियो असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) से StartSound को [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) को पास करें, और [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) को `true` करके लूप सक्षम करें। ऑडियो अगले साउंड इवेंट तक लूप करता रहेगा।

**सभी स्लाइड्स पर एक ही ट्रांज़िशन लगाने का तेज़ तरीका क्या है?**

प्रेज़ेंटेशन के [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) संग्रह पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन पर समान मान के साथ [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) को कॉल करें। उसी लूप में टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि सभी स्लाइड्स में व्यवहार समान बना रहे।

**मैं कैसे जांचूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) परिणाम पर [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) एनीमरेशन से मान लौटाता है; None का अर्थ है कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।