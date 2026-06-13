---
title: स्लाइड ट्रांज़िशन
type: docs
weight: 110
url: /hi/nodejs-java/examples/elements/slide-transition/
keywords:
- कोड उदाहरण
- स्लाइड ट्रांज़िशन
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js में स्लाइड ट्रांज़िशन को मास्टर करें: प्रभावों और अवधि को जोड़ें, अनुकूलित करें और क्रमबद्ध करें, PPT, PPTX और ODP प्रस्तुतियों के उदाहरणों के साथ।"
---
यह लेख **Aspose.Slides for Node.js via Java** के साथ स्लाइड ट्रांज़िशन प्रभाव और टाइमिंग लागू करने का प्रदर्शन करता है।

## **स्लाइड ट्रांज़िशन जोड़ें**

पहली स्लाइड पर फेड ट्रांज़िशन प्रभाव लागू करें।

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // फ़ेड ट्रांज़िशन लागू करें।
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड ट्रांज़िशन तक पहुँचें**

स्लाइड को वर्तमान में असाइन किए गए ट्रांज़िशन प्रकार को पढ़ें।

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // ट्रांज़िशन प्रकार तक पहुँचें।
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड ट्रांज़िशन हटाएँ**

`None` प्रकार सेट करके किसी भी ट्रांज़िशन प्रभाव को साफ़ करें।

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // कोई ट्रांज़िशन नहीं सेट करके हटाएँ।
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **ट्रांज़िशन अवधि सेट करें**

स्वचालित रूप से आगे बढ़ने से पहले स्लाइड कितनी देर तक प्रदर्शित होगी, निर्धारित करें।

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // मिलीसेकंड में।

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```