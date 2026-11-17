---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधित करें
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड अग्रगमन को कॉन्फ़िगर करें, और Morph तथा अन्य ट्रांज़िशन इफ़ेक्ट्स को अनुकूलित करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन यह नियंत्रित करते हैं कि स्लाइड शो के दौरान स्लाइड्स कैसे दिखाई देती हैं। Aspose.Slides for Node.js via Java के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट विशेष विकल्पों को समायोजित कर सकते हैं। यह लेख JavaScript उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइड्स के बीच एक Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास से प्रेजेंटेशन लोड करें और स्लाइड की ट्रांज़िशन सेटिंग्स तक [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) के माध्यम से पहुँचें। [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) को [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) एन्उमरेशन के किसी मान के साथ उपयोग करें, फिर प्रेजेंटेशन सहेजें।

निम्नलिखित उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल का उपयोग करें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **व्हील ट्रांज़िशन**

[setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) मेथड [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) के द्वारा लक्ष्य स्लाइड को दिखाने वाले रेडियल सेक्टरों की संख्या को नियंत्रित करता है। [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) से Wheel को ट्रांज़िशन प्रकार के रूप में सेट करें, इसके लिए पहले [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) का उपयोग करें, फिर [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) को [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान स्लाइड जोड़े बनाता है: एक काली स्लाइड और उसके बाद एक सुनहरे आयत वाली स्लाइड। लक्ष्य स्लाइड्स में स्पोक काउंट 1 और 8 उपयोग किया गया है, समान गति को [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) से सेट किया गया है और अंतर को स्पष्ट रूप से देखने के लिए 8,000 मिलीसेकंड की स्पष्ट अवधि [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) द्वारा निर्धारित की गई है।

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

आउटपुट प्रेजेंटेशन को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2 तक, फिर स्लाइड 3 से स्लाइड 4 तक आगे बढ़ें। PowerPoint प्लेबैक में, 1 के सत्यापित स्पोक काउंट से स्लाइड एक घड़ी की दिशा में एक स्विप से दिखाई देती है; 8 के सत्यापित काउंट से यह आठ रेडियल सेक्टरों द्वारा एक साथ दिखाई देती है। लक्ष्य सामग्री और ट्रांज़िशन टाइमिंग समान है, इसलिए अंतर दिखाने वाले सेक्टरों की संख्या में है।

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितने समय तक रहे और क्या माउस क्लिक से स्लाइड शो आगे बढ़े। निम्नलिखित मेथड इस व्यवहार को नियंत्रित करते हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) दर्शक को माउस क्लिक द्वारा आगे बढ़ने की अनुमति देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) स्वचालित आगे बढ़ने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) स्वचालित आगे बढ़ने से पहले देरी को मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों अग्रगमन को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर प्रयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) को `false` पास करें। देरी निर्धारित करती है कि स्लाइड शो कब आगे बढ़ेगा; यह विज़ुअल ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करता।

यह उदाहरण पहले तीन स्लाइड्स को विभिन्न इफ़ेक्ट असाइन करता है और क्रमशः 3, 5, और 7 सेकंड के बाद स्वचालित आगे बढ़ने को सक्षम करता है। माउस क्लिक भी इन स्लाइड्स को आगे बढ़ा सकते हैं। कम से कम तीन स्लाइड्स वाली `input.pptx` फ़ाइल उपयोग करें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

यह जांचने के लिए कि टाइम्ड अग्रगमन सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) को कॉल करें। केवल संग्रहित देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक देरी वाली स्लाइड्स के लिए स्वचालित अग्रगमन को अक्षम करता है। उन स्लाइड्स के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ट्रांज़िशन टाइमिंग को सटीक रूप से नियंत्रित करें**

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करके ट्रांज़िशन इफ़ेक्ट की सटीक अवधि मिलीसेकंड में निर्दिष्ट करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) मेथड ये सेटिंग्स [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) के माध्यम से पेश करती है:

| मेथड | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | ट्रांज़िशन इफ़ेक्ट की अवधि को स्वयं, मिलीसेकंड में सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | स्लाइड के स्वचालित अग्रगमन से पहले देरी को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) से पूर्वनिर्धारित गति श्रेणी चुनता है: Slow, Medium, या Fast। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं होती। |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर दिखाई दे। स्वचालित अग्रगमन देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) मान से इफ़ेक्ट अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![अलग-अलग बार 750‑ms ट्रांज़िशन अवधि और 5,000‑ms स्वचालित अग्रगमन सेटिंग की पहचान करते हैं।](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*साझा उदाहरण प्रत्येक स्लाइड को 750‑ms Fade ट्रांज़िशन देता है और अलग से स्वचालित अग्रगमन को 5,000 ms पर सक्षम करता है। ट्रांज़िशन अवधि इफ़ेक्ट को नियंत्रित करती है; अग्रगमन इस बात को नियंत्रित करता है कि स्लाइड कब छोड़ी जाए। ये बार स्कीमैटिक सेटिंग्स हैं, न कि मापी गई सम्मिलित टाइमलाइन।*
<!-- visual-explanation:slide-transition:end -->

### **हर स्लाइड पर समान अवधि लागू करें**

संतत गति के लिए, प्रत्येक स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5,000 मिलीसेकंड के बाद स्वचालित अग्रगमन को सक्षम करता है और माउस क्लिक द्वारा अग्रगमन को अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित अग्रगमन को कॉन्फ़िगर करें।
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **व्यक्तिगत स्लाइड्स के लिए विभिन्न अवधियों को सेट करें**

विभिन्न स्लाइड्स विभिन्न इफ़ेक्ट अवधि का उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए संक्षिप्त ट्रांज़िशन और सेक्शन परिचय के लिए लंबी ट्रांज़िशन उपयोग करें। यह उदाहरण पहली स्लाइड को 500 मिलीसेकंड और दूसरी स्लाइड को 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइड्स वाली `input.pptx` फ़ाइल उपयोग करें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब एक [animated GIF](/slides/hi/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/nodejs-java/export-to-html5/) या [video](/slides/hi/nodejs-java/convert-powerpoint-to-video/) तैयार कर रहे हों, निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600‑ms फेड उपयोग करें, और प्रत्येक स्लाइड के अग्रगमन देरी को अलग से समायोजित करें ताकि उसकी आवाज़ या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 ms का मतलब 30 fps पर 18 फ्रेम है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने गए निर्यात फ़ॉर्मेट के समर्थित इफ़ेक्ट और टाइमिंग विकल्पों की जांच करें, और सिंक्रनाइज़ेशन की पुष्टि करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) को कॉल करें ताकि यह पता लगे कि कोई स्पष्ट मान संग्रहीत है या नहीं। मान `-1` का अर्थ है कोई स्पष्ट अवधि सेट नहीं है; गैर-नकारात्मक मान संग्रहीत अवधि को मिलीसेकंड में दर्शाता है। अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) मान का उपयोग करके वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से अवधि प्रारंभ हो सकती है, इसलिए पहले मूल सेटिंग्स की जाँच करें।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph ट्रांज़िशन**

Morph ट्रांज़िशन क्रमिक स्लाइड्स पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड क्लोन करें, क्लोन पर एक वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे ट्रांज़िशन संबंधित वस्तुओं को उनकी मूल और संशोधित अवस्थाओं के बीच एनीमेट करता है।

निम्नलिखित उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर यह दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) एन्उमरेशन से Morph चुनता है। जो प्रस्तुति दर्शक Morph का समर्थन करता है, उसमें सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान इफ़ेक्ट देखा जा सके।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph ट्रांज़िशन प्रकार**

[TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) एन्उमरेशन नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक संपूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) जहाँ संभव हो शब्दों को मिलाकर टेक्स्ट को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) जहाँ संभव हो अक्षरों को मिलाकर टेक्स्ट को एनीमेट करता है।

उपयुक्त [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) का उपयोग करके Morph चुनें, फिर [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) तक पहुँचें। यह मान एक [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) ऑब्जेक्ट देता है, जिसका [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) मेथड मिलान मोड चुनता है।

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **ट्रांज़िशन इफ़ेक्ट सेट करें**

कुछ ट्रांज़िशन अतिरिक्त विकल्प प्रदान करते हैं, जैसे दिशा या क्या इफ़ेक्ट काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) से चुने गए ट्रांज़िशन पर निर्भर करते हैं। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) से उपयुक्त ट्रांज़िशन ऑब्जेक्ट उपयोग करें।

निम्नलिखित उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक स्पीड को नियंत्रित कर सकता हूं?**

हाँ। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) श्रेणी—Slow, Medium, या Fast—पर्याप्त हो और कोई स्पष्ट अवधि सेट नहीं हो, तो [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) का उपयोग करें। ये सेटिंग्स स्वचालित अग्रगमन देरी से स्वतंत्र रूप से ट्रांज़िशन इफ़ेक्ट को नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर उसे लूप करा सकता हूं?**

हाँ। एम्बेडेड ऑडियो को [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) से असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) एन्उमरेशन से StartSound को [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) में पास करें, और `true` के साथ [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) को सक्षम करें। ऑडियो स्लाइड शो में अगले साउंड इवेंट तक लूप करता रहेगा।

**हर स्लाइड पर समान ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेजेंटेशन की [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) कलेक्शन पर लूप करें और प्रत्येक स्लाइड के ट्रांज़िशन के लिए समान मान के साथ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) को कॉल करें। टाइमिंग और इफ़ेक्ट विकल्पों को भी उसी लूप में सेट करें ताकि व्यवहार सभी स्लाइड्स में सुसंगत रहे।

**मैं कैसे जांच सकता हूं कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

[getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) परिणाम पर [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) एन्उमरेशन से मान लौटाता है; None का अर्थ है कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।