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
- मॉर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ स्लाइड ट्रां्जिशन लागू करें, स्वचालित स्लाइड आगे बढ़ाने को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन प्रभावों को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन नियंत्रित करता है कि स्लाइड शो के दौरान स्लाइड कैसे दिखाई देती हैं। Aspose.Slides for Java के साथ, आप प्रत्येक स्लाइड के लिए ट्रांज़िशन प्रभाव चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ाना कॉन्फ़िगर कर सकते हैं, और प्रभाव के विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख Java उदाहरणों का उपयोग करके ट्रांज़िशन लागू करने, सटीक ट्रांज़िशन अवधि सेट करने, स्लाइड टाइमिंग प्रबंधित करने, और दो स्लाइड के बीच Morph ट्रांज़िशन बनाने को दर्शाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से प्रेजेंटेशन लोड करें और स्लाइड की ट्रांज़िशन सेटिंग्स को [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) के माध्यम से प्राप्त करें। [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) को एक मान के साथ प्रयोग करें जो [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) एन्यूमरेशन से लिया गया हो, फिर प्रेजेंटेशन सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड वाली `input.pptx` फ़ाइल का उपयोग करें।

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

[IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) का [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) मेथड उन रेडियल सेक्टरों की संख्या नियंत्रित करता है जो लक्ष्य स्लाइड को प्रकट करते हैं। स्लाइड की ट्रांज़िशन टाइप को [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) से Wheel पर सेट करने के बाद [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) को कॉल करें, फिर [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) के रूप में [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) का उपयोग करें।

यह उदाहरण दो समान स्लाइड जोड़े बनाता है: एक काली स्लाइड जिसके बाद सोने के आयत वाली स्लाइड आती है। लक्ष्य स्लाइडों में 1 और 8 स्पोक काउंट प्रयोग किए गए हैं, दोनों की गति को [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) द्वारा सेट किया गया है और स्पष्ट अवधि को [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) द्वारा 8,000 मिलीसेकंड पर निर्धारित किया गया है ताकि अंतर को आसानी से देखा जा सके।

```java
import java.awt.Color;
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
    Color gold = new Color(255, 215, 0);
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

आउटपुट प्रेजेंटेशन को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2 पर जाएँ, फिर स्लाइड 3 से स्लाइड 4 पर। PowerPoint प्लेबैक में, 1 का सत्यापित स्पोक काउंट एक घड़ी की दिशा में स्वेप के साथ स्लाइड को प्रकट करता है; 8 का काउंट एक साथ आठ रेडियल सेक्टरों से प्रकट करता है। लक्ष्य सामग्री और ट्रांज़िशन टाइमिंग समान हैं, इसलिए अंतर केवल प्रकट सेक्टरों की संख्या में है।

## **रिवील ट्रांज़िशन के साथ ब्लैक के माध्यम से फ़ेड**

लक्ष्य स्लाइड की ट्रांज़िशन टाइप को Reveal पर सेट करें, फिर उसकी [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) सेटिंग्स पर [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) को कॉल करें। उदाहरण एक टिल स्रोत स्लाइड और एक कोरल लक्ष्य स्लाइड बनाता है, फिर दोनों को क्लोन करता है। प्रत्येक जोड़ी दो‑सेकंड Reveal ट्रांज़िशन उपयोग करती है। केवल दूसरी जोड़ी ब्लैक के माध्यम से फ़ेड होती है।

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजे गए प्रेजेंटेशन को PowerPoint में खोलें और स्लाइड शो शुरू करें। स्लाइड 1 से स्लाइड 2 पर जाएँ तो टिल सीधे कोरल में फ़ेड होता दिखेगा। फिर स्लाइड 3 से स्लाइड 4 पर जाएँ। स्क्रीन कोरिल स्लाइड दिखाई देने से पहले अल्पकालिक रूप से काले के निकट डार्क हो जाता है। दोनों स्लाइड अपनी मूल पृष्ठभूमि रंग रखती हैं।

नीचे की पंक्तियों में आधा‑सेकंड अंतराल पर PowerPoint के फ्रेम दिखाए गए हैं। प्रत्येक पंक्ति के मध्य फ्रेम की तुलना करके प्रभाव देखें।

![PowerPoint प्लेबैक जिसमें ब्लैक के माध्यम से फ़ेड निष्क्रिय (ऊपर) और सक्रिय (नीचे) है। केवल नीचे की पंक्ति लगभग काले के माध्यम से गुजरती है।](reveal-through-black.png)

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप निर्धारित कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहे और क्या माउस क्लिक से स्लाइड शो को आगे बढ़ाया जाए। निम्न मेथड इस व्यवहार को नियंत्रित करते हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) दर्शक को माउस क्लिक करके आगे बढ़ने देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) स्वचालित आगे बढ़ाना सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) स्वचालित आगे बढ़ाने से पहले देरी (मिलीसेकंड में) निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ाने को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) को `false` पास करें। देरी नियंत्रित करती है कि स्लाइड शो कब आगे बढ़े; यह दृश्य ट्रांज़िशन प्रभाव की अवधि सेट नहीं करती।

यह उदाहरण पहले तीन स्लाइड पर विभिन्न प्रभाव असाइन करता है और क्रमशः 3, 5 और 7 सेकंड बाद स्वचालित आगे बढ़ाना सक्षम करता है। माउस क्लिक भी इन स्लाइडों को आगे बढ़ा सकते हैं। कम से कम तीन स्लाइड वाली `input.pptx` फ़ाइल का उपयोग करें।

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

यह जांचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) को कॉल करें। केवल सहेजी गई देरी सक्रिय टाइमर दर्शाती नहीं है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट देता है, और दो सेकंड से अधिक देरी वाली स्लाइडों के लिए स्वचालित आगे बढ़ाना निष्क्रिय करता है। उन स्लाइडों के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स सहेजता है।

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

ट्रांज़िशन प्रभाव की सटीक अवधि (मिलीसेकंड में) निर्दिष्ट करने के लिए [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) का उपयोग करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) मेथड इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) के माध्यम से उजागर करता है:

| मेथड | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | ट्रांज़िशन प्रभाव की अवधि (मिलीसेकंड) सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | स्लाइड के स्वचालित आगे बढ़ने से पहले की देरी (मिलीसेकंड) सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) से पूर्वनिर्धारित गति वर्ग (Slow, Medium, Fast) चुनता है। जब सटीक अवधि निर्दिष्ट नहीं की जाती, तब उपयोग होता है। |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) केवल ट्रांज़िशन प्रभाव को नियंत्रित करता है; यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दृश्य रहे। स्वचालित आगे बढ़ाने की देरी को अलग से कॉन्फ़िगर करें। जब स्पष्ट अवधि नहीं दी गई होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) मान के आधार पर प्रभाव की अवधि तय करता है।

<!-- visual-explanation:slide-transition:start -->
[![अलग-अलग बार 750 ms ट्रांज़िशन अवधि और 5,000 ms स्वचालित आगे बढ़ाने की सेटिंग को दर्शाते हैं।](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*साझा उदाहरण प्रत्येक स्लाइड को 750 ms Fade ट्रांज़िशन देता है और अलग से 5,000 ms पर स्वचालित आगे बढ़ाना सक्षम करता है। ट्रांज़िशन अवधि प्रभाव को नियंत्रित करती है; आगे बढ़ाना स्लाइड छोड़ने के समय को नियंत्रित करता है। ये बार स्कीमैटिक सेटिंग्स हैं, न कि मापी गई संयुक्त टाइमलाइन।*
<!-- visual-explanation:slide-transition:end -->

### **प्रत्येक स्लाइड पर समान अवधि लागू करें**

समान गति के लिए, समान प्रभाव और सटीक अवधि सभी स्लाइड पर लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन की अवधि 750 ms निर्धारित करता है। यह अलग से 5,000 ms पर स्वचालित आगे बढ़ाना सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ाना निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ाने को कॉन्फ़िगर करें।
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **व्यक्तिगत स्लाइड के लिए विभिन्न अवधि निर्धारित करें**

विभिन्न स्लाइड अलग-अलग अवधि का उपयोग कर सकती हैं। उदाहरण के लिए, टाइटल स्लाइड के लिए एक संक्षिप्त ट्रांज़िशन और सेक्शन इंट्रोडक्शन के लिए लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहली स्लाइड की अवधि 500 ms और दूसरी स्लाइड की 1,200 ms सेट करता है। कम से कम दो स्लाइड वाली `input.pptx` फ़ाइल का उपयोग करें।

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

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन को समन्वयित करें**

जब आप [animated GIF](/slides/hi/java/convert-powerpoint-to-animated-gif/), [HTML5 प्रस्तुति](/slides/hi/java/export-to-html5/), या [वीडियो](/slides/hi/java/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि निर्धारित करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 ms फ़ेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ाने की देरी को अलग से समायोजित करें ताकि उसके नैरेशन या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, फ्रेम रेट को प्रभाव अवधि के साथ समन्वयित करें: 600 ms 30 fps पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन को सक्षम करें। चुने गए निर्यात फ़ॉर्मेट के समर्थित प्रभाव और टाइमिंग विकल्प देखें, और सिंक्रोनाइज़ेशन की पुष्टि के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) को कॉल करके देखें कि क्या स्पष्ट मान संग्रहीत है। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; गैर‑नकारात्मक मान मिलिसेकंड में संग्रहीत अवधि को दर्शाता है। अनसेट मान गणना किए गए प्लेबैक अवधि के बराबर नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) मान के आधार पर वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि इनिशियलाइज़ हो सकती है, इसलिए मूल सेटिंग्स को पहले निरीक्षण करें।

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

Morph ट्रांज़िशन क्रमिक स्लाइडों में वस्तुओं के बीच परिवर्तनों को एनिमेट करता है। सरल Morph प्रभाव बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को ले जाएँ या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। यह ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनीमेट करता है।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति व आकार बदलता है। फिर दूसरा स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) एन्यूमरेशन से Morph चुनता है। Morph को सपोर्ट करने वाले प्रेजेंटेशन व्यूअर में सहेजी गई फ़ाइल खोलें और स्लाइड शो के दौरान प्रभाव देखें।

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

[TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) एन्यूमरेशन निर्धारित करता है कि Morph सामग्री को कैसे मिलाता और एनिमेट करता है:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को संपूर्ण वस्तु के रूप में लेता है।
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) जहाँ संभव हो शब्दों द्वारा टेक्स्ट को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) जहाँ संभव हो अक्षरों द्वारा टेक्स्ट को एनीमेट करता है।

[setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) से Morph चुनें, फिर [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) को एक्सेस करें। प्राप्त मान [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) इंटरफ़ेस देता है, जिसका [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) मेथड मिलान मोड चुनता है।

यह उदाहरण पिछले सेक्शन में बनाई गई प्रेजेंटेशन खोलता है और दूसरी स्लाइड को शब्द‑आधारित Morph एनीमेशन के लिए कॉन्फ़िगर करता है।

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

## **ट्रांज़िशन प्रभाव सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या प्रभाव काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प उस ट्रांज़िशन पर निर्भर करते हैं जिसे आप [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) से चुनते हैं। पहले टाइप सेट करें, फिर [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) से उपयुक्त इंटरफ़ेस के माध्यम से विकल्प सेट करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हाँ। जब आपको मिलिसेकंड में सटीक प्रभाव अवधि चाहिए तो [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) उपयोग करें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) वर्ग (Slow, Medium, या Fast) पर्याप्त हो और स्पष्ट अवधि सेट न की गई हो, तो [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) उपयोग करें। ये सेटिंग्स ट्रांज़िशन प्रभाव को स्वचालित आगे बढ़ाने की देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो जोड़ कर उसे लूप कर सकता हूँ?**

हाँ। [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) के साथ एम्बेडेड ऑडियो असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) से `StartSound` को [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-) में पास करें, और [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) को `true` पर सेट करें। ऑडियो स्लाइड शो में अगले ध्वनि इवेंट तक लूप रहेगा।

**हर स्लाइड पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन के [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) संग्रह पर लूप चलाएँ और प्रत्येक स्लाइड की ट्रांज़िशन के लिए समान मान के साथ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) कॉल करें। उसी लूप में टाइमिंग और प्रभाव विकल्प सेट करें ताकि सभी स्लाइड में व्यवहार समान रहे।

**मैं किसी स्लाइड पर वर्तमान में सेट किया गया ट्रांज़िशन कैसे जांचूँ?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) परिणाम पर [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) एन्यूमरेशन से एक मान लौटाता है; `None` का मतलब है कोई ट्रांज़िशन प्रभाव लागू नहीं है।