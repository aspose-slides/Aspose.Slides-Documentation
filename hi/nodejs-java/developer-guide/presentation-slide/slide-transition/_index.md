---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में स्लाइड ट्रांज़िशन प्रबंधन
linktitle: स्लाइड ट्रांज़िशन
type: docs
weight: 80
url: /hi/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ स्लाइड ट्रांज़िशन लागू करें, स्वचालित स्लाइड आगे बढ़ने को कॉन्फ़िगर करें, और Morph एवं अन्य ट्रांज़िशन इफ़ेक्ट को कस्टमाइज़ करें।"
---
## **परिचय**

स्लाइड ट्रांज़िशन स्लाइड शॉ सेशन के दौरान स्लाइडों के प्रदर्शित होने के तरीके को नियंत्रित करती हैं। Aspose.Slides for Node.js via Java के साथ, आप प्रत्येक स्लाइड के लिए ट्रांज़िशन इफ़ेक्ट चुन सकते हैं, माउस क्लिक या टाइमर द्वारा आगे बढ़ने को कॉन्फ़िगर कर सकते हैं, और इफ़ेक्ट‑विशिष्ट विकल्पों को समायोजित कर सकते हैं। यह लेख JavaScript उदाहरणों का उपयोग करके ट्रांज़िशन लागू करता है, सटीक ट्रांज़िशन अवधि सेट करता है, स्लाइड टाइमिंग को प्रबंधित करता है, और दो स्लाइडों के बीच एक Morph ट्रांज़िशन बनाता है। उदाहरण यह भी दर्शाते हैं कि सेटिंग्स को PPTX फ़ाइल में कैसे सहेजा जाए।

## **स्लाइड ट्रांज़िशन जोड़ें**

ट्रांज़िशन लागू करने के लिए, [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें और [getSlideShowTransition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) के माध्यम से स्लाइड की ट्रांज़िशन सेटिंग्स तक पहुँचें। [setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setType) को [TransitionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitiontype/) enumeration से मान देकर उपयोग करें, फिर प्रस्तुति सहेजें।

निम्न उदाहरण पहले स्लाइड पर Circle ट्रांज़िशन और दूसरे स्लाइड पर Comb ट्रांज़िशन लागू करता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

## **उन्नत स्लाइड ट्रांज़िशन जोड़ें**

आप यह निर्धारित कर सकते हैं कि स्लाइड स्क्रीन पर कितनी देर तक रहती है और क्या माउस क्लिक से स्लाइड शो आगे बढ़ता है। निम्न विधियाँ इस व्यवहार को नियंत्रित करती हैं:

- [setAdvanceOnClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) दर्शक को माउस क्लिक कर आगे बढ़ने देता है।
- [setAdvanceAfter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) स्वचालित आगे बढ़ने को सक्षम करता है।
- [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) स्वचालित आगे बढ़ने से पहले देरी को मिलीसेकंड में निर्दिष्ट करता है।

क्लिक और टाइम‑आधारित दोनों आगे बढ़ने को सक्षम करें ताकि दर्शक क्लिक से आगे बढ़ सके या टाइमर का इंतजार कर सके। केवल टाइमर का उपयोग करने के लिए, [setAdvanceOnClick](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) को `false` पास करें। यह देरी यह निर्धारित करती है कि स्लाइड शो कब आगे बढ़ता है; यह दृश्य ट्रांज़िशन इफ़ेक्ट की अवधि सेट नहीं करती।

यह उदाहरण पहले तीन स्लाइडों को अलग‑अलग इफ़ेक्ट असाइन करता है और क्रमशः 3, 5 और 7 सेकंड के बाद स्वचालित आगे बढ़ना सक्षम करता है। माउस क्लिक से भी ये स्लाइडें आगे बढ़ सकती हैं। कम से कम तीन स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

यह जांचने के लिए कि टाइम‑आधारित आगे बढ़ना सक्षम है या नहीं, [getAdvanceAfter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter) को कॉल करें। केवल संग्रहीत देरी यह संकेत नहीं देती कि टाइमर सक्रिय है।

अगला उदाहरण ऊपर सहेजी गई फ़ाइल खोलता है, प्रत्येक सक्षम टाइमर की रिपोर्ट करता है, और दो सेकंड से अधिक देरी वाली स्लाइडों के लिए स्वचालित आगे बढ़ना निष्क्रिय करता है। उन स्लाइडों के लिए माउस क्लिक सक्षम करता है और अपडेटेड सेटिंग्स सहेजता है।

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

ट्रांज़िशन इफ़ेक्ट की सटीक लंबाई मिलीसेकंड में निर्दिष्ट करने के लिए [setDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) का प्रयोग करें। स्लाइड की [getSlideShowTransition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) विधि इन सेटिंग्स को [SlideShowTransition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/) के माध्यम से उजागर करती है:

| विधि | उद्देश्य |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | ट्रांज़िशन इफ़ेक्ट की अवधि को मिलीसेकंड में सेट करता है। |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | स्लाइड के स्वचालित रूप से आगे बढ़ने से पहले की देरी को मिलीसेकंड में सेट करता है। इस टाइमर को सक्रिय करने के लिए [setAdvanceAfter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) को `true` पास करें। |
| [setSpeed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | [TransitionSpeed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionspeed/) से एक पूर्वनिर्धारित गति श्रेणी (Slow, Medium, Fast) चुनता है। यह तब उपयोग होता है जब सटीक अवधि निर्दिष्ट नहीं की गई हो। |

[setDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) केवल ट्रांज़िशन इफ़ेक्ट को नियंत्रित करता है; यह यह निर्धारित नहीं करता कि स्लाइड कितनी देर दिखाई दे। स्वचालित आगे बढ़ने की देरी को अलग से कॉन्फ़िगर करें। जब कोई स्पष्ट अवधि निर्धारित नहीं की जाती, तो Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) मान के आधार पर इफ़ेक्ट अवधि तय करता है।

### **हर स्लाइड पर समान अवधि लागू करें**

समान गति बनाए रखने के लिए, प्रत्येक स्लाइड पर एक ही इफ़ेक्ट और सटीक अवधि लागू करें। यह उदाहरण `input.pptx` लोड करता है, [TransitionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitiontype/) से Fade चुनता है, और प्रत्येक ट्रांज़िशन को 750 मिलीसेकंड की अवधि देता है। यह स्वचालित आगे बढ़ना 5,000 मिलीसेकंड के बाद सक्षम करता है और माउस क्लिक द्वारा आगे बढ़ना निष्क्रिय करता है, फिर परिणाम को PPTX के रूप में सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // इफ़ेक्ट अवधि से स्वतंत्र रूप से स्वचालित आगे बढ़ने को कॉन्फ़िगर करें।
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **व्यक्तिगत स्लाइडों के लिए अलग‑अलग अवधि रखें**

विभिन्न स्लाइड विभिन्न इफ़ेक्ट अवधियों का उपयोग कर सकती हैं। उदाहरण के लिए, शीर्षक स्लाइड के लिए छोटा ट्रांज़िशन और अनुभाग परिचय के लिए लंबा ट्रांज़िशन। यह उदाहरण पहले स्लाइड को 500 मिलीसेकंड और दूसरे को 1,200 मिलीसेकंड देता है। कम से कम दो स्लाइडों वाली `input.pptx` फ़ाइल का उपयोग करें।

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

### **एनीमेटेड आउटपुट के साथ ट्रांज़िशन समन्वयित करें**

जब आप एक [animated GIF](/slides/hi/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/hi/nodejs-java/export-to-html5/), या [video](/slides/hi/nodejs-java/convert-powerpoint-to-video/) तैयार कर रहे हों, तो निर्यात से पहले सटीक ट्रांज़िशन अवधि सेट करें ताकि इच्छित गति से मेल खाए। उदाहरण के लिए, दृश्यों के बीच 600 मिलीसेकंड का फेड उपयोग करें, और प्रत्येक स्लाइड की आगे बढ़ने की देरी अलग‑अलग समायोजित करें ताकि उसकी आवाज़ या सामग्री के लिए समय मिल सके।

GIF और वीडियो के लिये, आउटपुट फ़्रेमरेट को इफ़ेक्ट अवधि के साथ समन्वयित करें: 600 मिलीसेकंड 30 फ़्रेम / सेकंड पर 18 फ़्रेम के बराबर है। HTML5 में, निर्यात सेटिंग्स में एनीमेटेड ट्रांज़िशन सक्षम करें। चुने गए निर्यात फॉर्मेट द्वारा समर्थित इफ़ेक्ट और टाइमिंग विकल्प देखें, और सिंक्रनाइज़ेशन सत्यापित करने के लिए आउटपुट का पूर्वावलोकन करें।

### **मौजूदा ट्रांज़िशन अवधि पढ़ें**

ट्रांज़िशन को संशोधित करने से पहले [getDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#getDuration) को कॉल करें ताकि पता चल सके कि कोई स्पष्ट मान संग्रहीत है या नहीं। `-1` का मतलब है कि कोई स्पष्ट अवधि सेट नहीं है; गैर‑नégative मान मिलीसेकंड में संग्रहीत अवधि दर्शाता है। अनसेट मान गणना की गई प्लेबैक अवधि नहीं है: Aspose.Slides ट्रांज़िशन प्रकार और [getSpeed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) मान का उपयोग करके वह अवधि निर्धारित करता है। ट्रांज़िशन प्रकार सेट करने से एक अवधि इनिशियलाइज़ हो सकती है, इसलिए मूल सेटिंग्स को पहले जांचें।

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

Morph ट्रांज़िशन लगातार स्लाइडों पर ऑब्जेक्ट्स के बीच बदलावों को एनीमेट करता है। साधारण Morph इफ़ेक्ट बनाने के लिए, एक स्लाइड को क्लोन करें, क्लोन पर किसी ऑब्जेक्ट को स्थानांतरित या आकार बदलें, और दूसरे स्लाइड पर Morph ट्रांज़िशन लागू करें। इससे संबंधित ऑब्जेक्ट्स अपने मूल और संशोधित अवस्था के बीच एनीमेट होते हैं।

निम्न उदाहरण एक टेक्स्ट आयत वाला स्लाइड बनाता है, स्लाइड को क्लोन करता है, और क्लोन पर आयत की स्थिति और आकार बदलता है। फिर दूसरे स्लाइड के लिए [TransitionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitiontype/) enumeration से Morph चुनता है। Morph को सपोर्ट करने वाले प्रस्तुति व्यूअर में सहेजी गई फ़ाइल खोलें ताकि स्लाइड शो के दौरान प्रभाव देख सकें।

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

[TransitionMorphType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionmorphtype/) enumeration यह नियंत्रित करती है कि Morph सामग्री को कैसे मिलाता और एनीमेट करता है:

- [ByObject](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) प्रत्येक आकार को एक संपूर्ण ऑब्जेक्ट के रूप में लेता है।
- [ByWord](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) संभव होने पर शब्दों को मिलाकर टेक्स्ट एनीमेट करता है।
- [ByChar](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) संभव होने पर अक्षरों को मिलाकर टेक्स्ट एनीमेट करता है।

[Morph] चुनने के लिए [setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setType) का उपयोग करें, फिर [getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#getValue) तक पहुँचें। यह एक [MorphTransition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/morphtransition/) ऑब्जेक्ट देता है, जिसका [setMorphType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/morphtransition/#setMorphType) विधि मिलान मोड चुनती है।

यह उदाहरण पिछले भाग में बनाई गई प्रस्तुति को खोलता है और दूसरे स्लाइड को शब्द‑आधारित Morph एनीमेशन उपयोग करने के लिए कॉन्फ़िगर करता है।

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

कुछ ट्रांज़िशन अतिरिक्त विकल्प उजागर करते हैं, जैसे दिशा या इफ़ेक्ट का काली स्क्रीन से शुरू होना। उपलब्ध विकल्प उस ट्रांज़िशन पर निर्भर करते हैं जिसे आप [setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setType) से चुनते हैं। पहले प्रकार सेट करें, फिर [getValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#getValue) से उचित ट्रांज़िशन ऑब्जेक्ट का उपयोग करें।

निम्न उदाहरण `input.pptx` की पहली स्लाइड पर Cut ट्रांज़िशन लागू करता है। यह [OptionalBlackTransition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/optionalblacktransition/) के माध्यम से [setFromBlack](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) को कॉल करता है ताकि ट्रांज़िशन काली स्क्रीन से शुरू हो।

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

**क्या मैं स्लाइड ट्रांज़िशन की प्लेबैक गति नियंत्रित कर सकता हूँ?**

हां। जब आपको मिलीसेकंड में सटीक इफ़ेक्ट अवधि चाहिए, तो [setDuration](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) का उपयोग करें। जब एक पूर्वनिर्धारित [TransitionSpeed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionspeed/) श्रेणी (Slow, Medium, Fast) पर्याप्त हो और कोई स्पष्ट अवधि सेट न हो, तो [setSpeed](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) का उपयोग करें। ये सेटिंग्स ट्रांज़िशन इफ़ेक्ट को स्वचालित आगे बढ़ने की देरी से स्वतंत्र रूप से नियंत्रित करती हैं।

**क्या मैं ट्रांज़िशन के साथ ऑडियो संलग्न कर उसे लूप कर सकता हूँ?**

हां। आप एम्बेडेड ऑडियो को [setSound](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setSound) से असाइन कर सकते हैं, [TransitionSoundMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitionsoundmode/) से StartSound को [setSoundMode](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode) को पास करें, और [setSoundLoop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) को true से सक्षम करें। ऑडियो अगले साउंड इवेंट तक लूप होता रहेगा।

**सभी स्लाइडों पर एक ही ट्रांज़िशन लागू करने का तेज़ तरीका क्या है?**

प्रेज़ेंटेशन की [getSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSlides) कलेक्शन पर लूप चलाएँ और प्रत्येक स्लाइड के ट्रांज़िशन पर वही मान के साथ [setType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#setType) को कॉल करें। समान लूप में किसी भी टाइमिंग और इफ़ेक्ट विकल्प को सेट करें ताकि व्यवहार सभी स्लाइडों में सुसंगत रहे।

**मैं कैसे जांचूँ कि किसी स्लाइड पर वर्तमान में कौन सा ट्रांज़िशन सेट है?**

स्लाइड के [getSlideShowTransition](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) परिणाम पर [getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slideshowtransition/#getType) को कॉल करें। यह [TransitionType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/transitiontype/) enumeration से एक मान लौटाता है; None का अर्थ है कि कोई ट्रांज़िशन इफ़ेक्ट लागू नहीं है।