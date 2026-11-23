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
- मॉर्फ़ ट्रांज़िशन
- ट्रांज़िशन प्रकार
- ट्रांज़िशन इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph व अन्य ट्रांज़िशन इफ़ेक्ट्स को कस्टमाइज़ करें।"
---
## **अवलोकन**

स्लाइड ट्रांज़िशन यह नियंत्रित करती हैं कि स्लाइड शो के दौरान स्लाइडें कैसे प्रदर्शित होती हैं। Aspose.Slides for Node.js via Java के साथ, आप प्रत्येक स्लाइड के लिए एक ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट के विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह आलेख जावास्क्रिप्ट उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग प्रबंधित करता है, और दो स्लाइडों के बीच Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दिखाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

एक ट्रांज़िशन लागू करने के लिए, एक प्रस्तुति को [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) क्लास से लोड करें और स्लाइड की ट्रांज़िशन सेटिंग्स को [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) के माध्यम से एक्सेस करें। [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) एन्यूमेरेशन से एक मान के साथ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) का उपयोग करें, फिर प्रस्तुति को सहेजें।

निम्नलिखित उदाहरण पहला स्लाइड पर Circle ट्रांज़िशन और दूसरा स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

[setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) मेथड, जो [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) का हिस्सा है, लक्ष्य स्लाइड को प्रकट करने वाले रेडियल सेक्टरों की संख्या को नियंत्रित करता है। स्लाइड की ट्रांज़िशन प्रकार को [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) से Wheel पर सेट करें, इसके बाद [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) का उपयोग करके, और फिर [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) को [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) के रूप में एक्सेस करें।

यह उदाहरण दो समान स्लाइड जोड़े बनाता है: एक काली स्लाइड जिसके बाद सोने के आयत के साथ एक स्लाइड आती है। लक्ष्य स्लाइडों में स्पोक गिनती क्रमशः 1 और 8 रखी गई है, समान गति को [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) के द्वारा सेट किया गया है और 8,000 मिलीसेकंड की स्पष्ट अवधि को [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) के द्वारा निर्धारित किया गया है ताकि अंतर को आसानी से देखा जा सके।

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

आउटपुट प्रस्तुति को PowerPoint में खोलें और स्लाइड शो चलाएँ। स्लाइड 1 से स्लाइड 2, फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें। PowerPoint प्लेबैक में, 1 की सत्यापित स्पोक गिनती एक घड़ी की दिशा में एक स्वीप से स्लाइड को प्रकट करती है; 8 की सत्यापित गिनती आठ रेडियल सेक्टरों के साथ एक साथ प्रकट करती है। लक्ष्य सामग्री और ट्रांज़िशन टाइमिंग समान हैं, इसलिए अंतर प्रकट सेक्टरों की संख्या में है।

## **Reveal ट्रांज़िशन के साथ ब्लैक के माध्यम से फ़ेड**

लक्ष्य स्लाइड की ट्रांज़िशन प्रकार को Reveal सेट करें, फिर उसके [RevealTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/) सेटिंग्स पर [setThroughBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/revealtransition/#setThroughBlack) को कॉल करें। यह उदाहरण एक टील स्रोत स्लाइड और एक कोरल लक्ष्य स्लाइड बनाता है, फिर दोनों को क्लोन करता है। प्रत्येक जोड़ी समान दो-सेकंड Reveal ट्रांज़िशन का उपयोग करती है। केवल दूसरी जोड़ी ब्लैक के माध्यम से फ़ेड करती है।

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const source = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addClone(source);
    const teal = java.newInstanceSync("java.awt.Color", 0, 128, 128);
    const coral = java.newInstanceSync("java.awt.Color", 255, 127, 80);

    for (const [slide, color, label] of [[source, teal, "Source"], [destination, coral, "Destination"]]) {
        slide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
        const fill = slide.getBackground().getFillFormat();
        fill.setFillType(java.newByte(slides.FillType.Solid));
        fill.getSolidFillColor().setColor(color);

        const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 160, 180, 400, 130);
        const textFrame = shape.getTextFrame();
        textFrame.setText(label);
        textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    const clonedDestination = presentation.getSlides().addClone(destination);
    for (const slide of [destination, clonedDestination]) {
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Reveal);
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(2000);

        const reveal = transition.getValue();
        reveal.setDirection(slides.TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide === clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

सहेजी गई प्रस्तुति को PowerPoint में खोलें और स्लाइड शो शुरू करें। स्लाइड 1 से स्लाइड 2 पर आगे बढ़ें ताकि टील सीधे कोरल में फ़ेड हो दिखे। फिर स्लाइड 3 से स्लाइड 4 पर आगे बढ़ें। स्क्रीन संक्षिप्त रूप से लगभग काले रंग में धुंधला हो जाता है, फिर कोरल स्लाइड सामने आती है। दोनों स्लाइड अपने मूल पृष्ठभूमि रंग बरकरार रखते हैं।

नीचे की पंक्तियों में आधे सेकंड अंतराल पर PowerPoint के फ्रेम दिखाए गए हैं। प्रत्येक पंक्ति में मध्य फ्रेम की तुलना करके प्रभाव देखें।

![PowerPoint प्लेबैक जिसमें ब्लैक के माध्यम से फ़ेड डिसेबल (ऊपर) और एनेबल (नीचे) किया गया है। केवल नीचे की पंक्ति लगभग काले रंग से गुजरती है।](reveal-through-black.png)

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह कॉन्फ़िगर कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर बनी रहती है और क्या माउस क्लिक स्लाइड शो को आगे बढ़ाता है। निम्नलिखित मेथड्स इस व्यवहार को नियंत्रित करते हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) दर्शक को माउस क्लिक करके आगे बढ़ने की अनुमति देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) स्वचालित आगे बढ़ने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) स्वचालित आगे बढ़ने से पहले का विलंब(milliseconds में) निर्दिष्ट करता है।

क्लिक और टाइम्ड दोनों आगे बढ़ने को सक्षम करें ताकि दर्शक क्लिक करके या टाइमर की प्रतीक्षा करके आगे बढ़ सके। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) को `false` पास करें। विलंब यह नियंत्रित करता है कि स्लाइड शो कब आगे बढ़ता है; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करता।

इस उदाहरण में पहले तीन स्लाइडों को विभिन्न इफ़ेक्ट्स असाइन किए गए हैं और क्रमशः 3, 5 और 7 सेकंड के बाद स्वचालित आगे बढ़ना सक्षम किया गया है। माउस क्लिक भी इन स्लाइडों को आगे बढ़ा सकता है। कम से कम तीन स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

जाँचने के लिए कि टाइम्ड आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) को कॉल करें। केवल संग्रहीत विलंब यह संकेत नहीं देता कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल को खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक विलंब वाली स्लाइडों के लिए स्वचालित आगे बढ़ना अक्षम करता है। उन स्लाइडों के लिए माउस क्लिक को सक्षम करता है और अपडेटेड सेटिंग्स को सहेजता है।

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

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करके ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई (मिलीसेकंड में) निर्धारित करें। स्लाइड का [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) मेथड इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/) के माध्यम से प्रदर्शित करता है:

| विधि | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | ट्रांज़िशन इफ़ेक्ट की अवधि (मिलीसेकंड में) सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | स्लाइड के स्वचालित आगे बढ़ने से पहले के विलंब (मिलीसेकंड में) को सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) से एक पूर्वनिर्धारित गति वर्ग (Slow, Medium, Fast) चुनता है। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह नहीं तय करता कि स्लाइड कितनी देर दिखाई देती रहे। स्वचालित आगे बढ़ने के विलंब को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि सेट नहीं होती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) मान के आधार पर इफ़ेक्ट अवधि निर्धारित करता है।

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*The shared example gives each slide a 750-ms Fade transition and separately enables automatic advancement at 5,000 ms. Transition duration controls the effect; advancement controls when to leave the slide. These bars are schematic settings, not a measured combined timeline.*
<!-- visual-explanation:slide-transition:end -->

### **प्रत्येक स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर समान इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` को लोड करता है, [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह अलग से 5,000 मिलीसेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ने को अक्षम करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ना कॉन्फ़िगर करें।
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **व्यक्तिगत स्लाइडों के लिए विभिन्न अवधि सेट करें**

विभिन्न स्लाइडें अलग-अलग इफ़ेक्ट अवधियों का उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और सेक्शन परिचय के लिए लंबा ट्रांज़िशन उपयोग करें। यह उदाहरण पहले स्लाइड के लिए 500 मिलीसेकंड और दूसरे के लिए 1,200 मिलीसेकंड सेट करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

### **एनिमेटेड आउटपुट के साथ ट्रांज़िशन को समन्वयित करें**

[animated GIF](/slides/hi/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 प्रस्तुति](/slides/hi/nodejs-java/export-to-html5/), या [वीडियो](/slides/hi/nodejs-java/convert-powerpoint-to-video/) तैयार करते समय, निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि वांछित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का फ़ेड उपयोग करें, और प्रत्येक स्लाइड के आगे बढ़ने के विलंब को अलग से समायोजित करें ताकि उसकी आवाज़ या सामग्री के लिए समय मिले।

GIF और वीडियो के लिए, आउटपुट फ्रेम रेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 फ़्रेम प्रति सेकंड पर 18 फ्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनिमेटेड ट्रांज़िशन सक्षम करें। चुने गए निर्यात स्वरूप की समर्थित इफ़ेक्ट्स और टाइमिंग विकल्पों की जांच करें, और सिंक्रनाइज़ेशन की पुष्टि के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को बदलने से पहले [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) को कॉल करें ताकि यह पता चल सके कि कोई स्पष्ट मान संग्रहित है या नहीं। `-1` का मान दर्शाता है कि कोई स्पष्ट अवधि सेट नहीं है; एक गैर-नकारात्मक मान संग्रहित अवधि (मिलीसेकंड में) निर्दिष्ट करता है। अनसेट मान गणना किए गए प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) मान का उपयोग करके वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से एक अवधि प्रारंभ हो सकती है, इसलिए पहले मूल सेटिंग्स की जाँच करें।

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

Morph ट्रांज़िशन लगातार स्लाइडों पर वस्तुओं के बीच परिवर्तन को एनीमेट करता है। एक सरल Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी वस्तु को स्थानांतरित या आकार बदलें, और दूसरी स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे ट्रांज़िशन संबंधित वस्तुओं को उनके मूल और संशोधित स्थितियों के बीच एनीमेट करता है।

निम्नलिखित उदाहरण एक टेक्स्ट आयत वाली स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर वह दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) एन्यूमेरेशन से Morph चुनता है। सहेजी गई फ़ाइल को Morph का समर्थन करने वाले प्रस्तुति व्यूअर में खोलें ताकि स्लाइड शो के दौरान प्रभाव देखा जा सके।

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

[TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) एन्यूमेरेशन यह नियंत्रित करता है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक सम्पूर्ण वस्तु के रूप में मानता है।
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) शब्दों को मिलाकर जहां संभव हो टेक्स्ट को एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) अक्षरों को मिलाकर जहां संभव हो टेक्स्ट को एनीमेट करता है।

Morph को चुनने के लिए [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) का उपयोग करें, फिर [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) तक पहुँचें। यह मान एक [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/) ऑब्जेक्ट प्रदान करता है, जिसका [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) मेथड मिलान मोड चुनता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या क्या इफ़ेक्ट काली स्क्रीन से शुरू होता है। उपलब्ध विकल्प इस पर निर्भर करते हैं कि कौन सा ट्रांज़िशन [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) से चुना गया है। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) से उपयुक्त ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

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

## **FAQ**

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति को नियंत्रित कर सकता हूँ?**

हां। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए तो [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) को प्राथमिकता दें। जब पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) वर्ग—Slow, Medium, या Fast—पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) का उपयोग करें। ये सेटिंग्स स्वचालित आगे बढ़ने के विलंब से स्वतंत्र रूप से ट्रांज़िशन इफ़ेक्ट को नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन में ऑडियो संलग्न कर सकता हूँ और उसे लूप कर सकता हूँ?**

हां। एम्बेडेड ऑडियो को [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound) से असाइन करें, [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) एन्यूमेरेशन से StartSound को [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) में पास करें, और `true` के साथ [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) को सक्षम करें। ऑडियो स्लाइड शो में अगली साउंड इवेंट तक लूप करता रहेगा।

**हर स्लाइड पर एक ही ट्रांज़िशन लागू करने का सबसे तेज़ तरीका क्या है?**

प्रेज़ेंटेशन की [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) कलेक्शन पर लूप चलाएँ और प्रत्येक स्लाइड की ट्रांज़िशन के लिए समान मान के साथ [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) को कॉल करें। उसी लूप में कोई भी टाइमिंग और इफ़ेक्ट विकल्प सेट करें ताकि स्लाइडों में व्यवहार समान रहे।

**मैं कैसे जांचूँ कि वर्तमान में किसी स्लाइड पर कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) परिणाम पर [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) एन्यूमेरेशन से एक मान लौटाता है; None का अर्थ है कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।