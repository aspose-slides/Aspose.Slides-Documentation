---
title: एंड्रॉइड पर प्रस्तुतियों में स्लाइड ट्रांज़िशन का प्रबंधन
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/androidjava/slide-transition/
keywords:
- स्लाइड ट्रांज़िशन
- स्लाइड ट्रांज़िशन जोड़ें
- स्लाइड ट्रांज़िशन लागू करें
- उन्नत स्लाइड ट्रांज़िशन
- मोर्फ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ना कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन प्रभावों को कस्टमाइज़ करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन स्लाइड शो के दौरान स्लाइड्स के दिखाई देने के तरीके को नियंत्रित करती हैं। Aspose.Slides for Android via Java के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट के विशेष विकल्पों को समायोजित कर सकते हैं। यह लेख जावा उदाहरणों का उपयोग करके ट्रांज़िशन लागू करना, सटीक ट्रांज़िशन अवधि सेट करना, स्लाइड टाइमिंग प्रबंधित करना, और दो स्लाइड्स के बीच एक Morph ट्रांज़िशन बनाना दर्शाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास का उपयोग करके प्रेजेंटेशन लोड करें और [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुँचें। [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) को [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) एनेमरेशन के मान के साथ उपयोग करें, फिर प्रेजेंटेशन को सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरी स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

[IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) की [setSpokes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/#setSpokes-long-) विधि गंतव्य स्लाइड को उजागर करने वाले रेडियल सेक्टर की संख्या को नियंत्रित करती है। ट्रांज़िशन प्रकार को [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) से Wheel सेट करने के बाद [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) का प्रयोग करें, फिर [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) को [IWheelTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iwheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान जोड़े स्लाइड बनाता है: एक काली स्लाइड जिसके बाद सोने के आयत वाला स्लाइड होता है। गंतव्य स्लाइड्स के स्पोक काउंट क्रमशः 1 और 8 हैं, दोनों की गति [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) द्वारा सेट की गई है और स्पष्ट रूप से [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) से 8,000 मिलीसेकंड की अवधि निर्धारित की गई है ताकि अंतर स्पष्ट रूप से देखा जा सके।

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

आउटपुट प्रेजेंटेशन को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2, फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें। PowerPoint प्लेबैक में, 1 का सत्यापित स्पोक काउंट स्लाइड को एक घड़ी की दिशा में स्विप के साथ उजागर करता है; 8 का काउंट स्लाइड को एक साथ आठ रेडियल सेक्टर में उजागर करता है। गंतव्य सामग्री और ट्रांज़िशन टाइमिंग समान है, इसलिए अंतर केवल उजागर सेक्टर की संख्या है।

## **Reveal ट्रांज़िशन के साथ काले रंग में फ़ेड**

गंतव्य स्लाइड का ट्रांज़िशन प्रकार Reveal सेट करें, फिर उसकी [IRevealTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/) सेटिंग्स पर [setThroughBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-) को कॉल करें। यह उदाहरण एक टील स्रोत स्लाइड और एक कोरल गंतव्य स्लाइड बनाता है, फिर दोनों को क्लोन करता है। प्रत्येक जोड़े में दो‑सेकंड का Reveal ट्रांज़िशन है। केवल दूसरे जोड़े में काले रंग में फ़ेड होता है।

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    int[] backgrounds = { Color.rgb(0, 128, 128), Color.rgb(255, 127, 80) };
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

सहेजी गई प्रेजेंटेशन को PowerPoint में खोलें और स्लाइड शो शुरू करें। स्लाइड 1 से स्लाइड 2 पर आगे बढ़ें ताकि टील सीधे कोरल में फ़ेड हो। फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें। स्क्रीन अस्थायी रूप से काले के करीब डिम हो जाती है, उसके बाद कोरल स्लाइड दिखाई देती है। दोनों स्लाइड्स अपनी मूल बैकग्राउंड रंग बरकरार रखती हैं।

नीचे की पंक्तियाँ आधे‑सेकंड अंतराल पर PowerPoint के फ्रेम दिखाती हैं। प्रत्येक पंक्ति के मध्य फ्रेम की तुलना करके प्रभाव देखें।

![PowerPoint playback with the fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप तय कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहेगी और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाएगा। निम्न विधियाँ इस व्यवहार को नियंत्रित करती हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) दर्शक को माउस क्लिक करके आगे बढ़ने की अनुमति देती है।
- [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) स्वचालित आगे बढ़ने को सक्षम करती है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) स्वचालित आगे बढ़ने से पहले का विलंब (मिलीसेकंड में) निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ने को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) को `false` पास करें। विलंब यह निर्धारित करता है कि स्लाइड शो कब आगे बढ़ेगा; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि नहीं निर्धारित करता।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट्स असाइन करता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है। माउस क्लिक भी इन स्लाइड्स को आगे बढ़ा सकता है। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

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

जांचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--) को कॉल करें। केवल संग्रहित विलंब सक्रिय टाइमर दर्शाता नहीं है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल खोलता है, प्रत्येक सक्रिय टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइड्स के लिए स्वचालित आगे बढ़ना अक्षम करता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स सहेजता है।

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

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) का उपयोग ट्रांज़िशन इफ़ेक्ट की सटीक अवधि (मिलीसेकंड में) निर्धारित करने के लिए करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) विधि इन सेटिंग्स को [ISlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/) के माध्यम से उजागर करती है:

| विधि | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | ट्रांज़िशन इफ़ेक्ट की स्वयं की अवधि (मिलीसेकंड) सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले का विलंब (मिलीसेकंड) सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) एनेमरेशन से पूर्वनिर्धारित गति श्रेणी (Slow, Medium, Fast) चुनता है। यह तब उपयोग किया जाता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह निर्धारित नहीं करता कि स्लाइड कितनी देर तक दिखाई देगी। स्वचालित आगे बढ़ने के विलंब को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि निर्धारित नहीं की जाती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) मान के आधार पर इफ़ेक्ट अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **हर स्लाइड पर समान अवधि लागू करें**

संगत गति के लिए, हर स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह स्वचालित आगे बढ़ना 5,000 मिलीसेकंड पर अलग से सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ना कॉन्फ़िगर करें।
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5_000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **व्यक्तिगत स्लाइड्स के लिए विभिन्न अवधि सेट करें**

विभिन्न स्लाइड्स अलग‑अलग इफ़ेक्ट अवधि उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए एक संक्षिप्त ट्रांज़िशन और खंड परिचय के लिए लंबी ट्रांज़िशन उपयोग करें। यह उदाहरण पहली स्लाइड के लिए 500 मिलीसेकंड और दूसरी स्लाइड के लिए 1,200 मिलीसेकंड की अवधि सेट करता है। कम से कम दो स्लाइड वाली `input.pptx` फ़ाइल उपयोग करें।

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

जब आप [animated GIF](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/androidjava/export-to-html5/), या [video](/slides/hi/androidjava/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600‑मिलीसेकंड फ़ेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देरी को अलग से समायोजित करें ताकि उसके वर्णन या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिये, फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 fps पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्रिय करें। चयनित निर्यात प्रारूप के समर्थित इफ़ेक्ट और टाइमिंग विकल्प जांचें, और सिंक्रोनाइज़ेशन की पुष्टि के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [getDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) को कॉल करें ताकि यह पता चल सके कि कोई स्पष्ट मान संग्रहित है या नहीं। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; शून्य या अधिक का मान मिलीसेकंड में संग्रहित अवधि दर्शाता है। यह अनसेट मान गणना किए गए प्लेबैक अवधि के बराबर नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) मान के आधार पर वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से कभी‑कभी एक अवधि प्रारंभ हो सकती है, इसलिए मूल सेटिंग्स को पहले निरीक्षण करें।

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

Morph ट्रांज़िशन क्रमिक स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करती है। सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे संबंधित वस्तुएँ मूल और संशोधित स्थितियों के बीच एनीमेट होती हैं।

निम्न उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर दूसरी स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) एनेमरेशन से Morph चुनता है। Morph का समर्थन करने वाले प्रेजेंटेशन व्यूअर में सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान प्रभाव देखें।

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

[TransitionMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/) एनेमरेशन यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक समग्र वस्तु के रूप में लेता है।
- [ByWord](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) संभव हो तो शब्दों के आधार पर टेक्स्ट को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) संभव हो तो अक्षरों के आधार पर टेक्स्ट को एनीमेट करता है।

[Morph को चयन करने के लिए [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) का उपयोग करें, फिर [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) को एक्सेस करें। यह मान [IMorphTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/) इंटरफ़ेस प्रदान करता है, जिसकी [setMorphType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) विधि मिलान मोड चुनती है।

यह उदाहरण पिछले भाग में बनाई गई प्रेजेंटेशन खोलता है और दूसरी स्लाइड को शब्द‑आधारित Morph एनीमेशन के लिए कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या प्रभाव काले स्क्रीन से शुरू होता है। उपलब्ध विकल्प उस ट्रांज़िशन पर निर्भर करते हैं जिसे आप [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) से चुनते हैं। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getValue--) से उपयुक्त इंटरफ़ेस का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [IOptionalBlackTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) को कॉल करता है ताकि ट्रांज़िशन काले स्क्रीन से शुरू हो।

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

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए, तो [setDuration](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionspeed/) (Slow, Medium, Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट न की गई हो, तो [setSpeed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने के विलंब से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो जोड़ सकता हूँ और उसे लूप कर सकता हूँ?**

हाँ। [setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-) के साथ एंबेडेड ऑडियो असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitionsoundmode/) एनेमरेशन से `StartSound` को [setSoundMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-) में पास करें, और [setSoundLoop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) को `true` पर सेट करें। ऑडियो तब तक लूप करेगा जब तक स्लाइड शो में अगला साउंड इवेंट नहीं आता।

**हर स्लाइड पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन की [getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) संग्रह पर लूप चलाएँ और प्रत्येक स्लाइड की ट्रांज़िशन के लिए समान मान के साथ [setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) को कॉल करें। एक ही लूप में किसी भी टाइमिंग और इफ़ेक्ट विकल्प को सेट करें ताकि सभी स्लाइड्स में व्यवहार समान रहे।

**मैं कैसे जांच सकता हूँ कि वर्तमान में किसी स्लाइड पर कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) परिणाम पर [getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islideshowtransition/#getType--) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/transitiontype/) एनेमरेशन से एक मान लौटाता है; None का अर्थ है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।