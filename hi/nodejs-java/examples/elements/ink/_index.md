---
title: इंक
type: docs
weight: 180
url: /hi/nodejs-java/examples/elements/ink/
keywords:
- कोड उदाहरण
- इंक
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js में इंक के साथ काम करें: स्ट्रोक बनाएं, आयात करें और संपादित करें, रंग और चौड़ाई समायोजित करें, और उदाहरणों का प्रयोग करके PPT, PPTX, और ODP में निर्यात करें।"
---
यह लेख मौजूदा इंक शैलियों तक पहुंचने और उन्हें **Aspose.Slides for Node.js via Java** का उपयोग करके हटाने के उदाहरण प्रदान करता है।

> ❗ **ध्यान दें:** इंक शैलियां विशेष उपकरणों से उपयोगकर्ता इनपुट का प्रतिनिधित्व करती हैं। Aspose.Slides प्रोग्रामेटिक रूप से नई इंक स्ट्रोक नहीं बना सकता, लेकिन आप मौजूदा इंक को पढ़ और संशोधित कर सकते हैं।

## **इंक तक पहुंचें**

स्लाइड पर पहली इंक आकृति प्राप्त करें।

```js
function accessInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let inkShape = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IInk")) {
                inkShape = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **इंक हटाएँ**

स्लाइड से एक इंक आकृति हटाएँ।

```js
function removeInk() {
    let presentation = new aspose.slides.Presentation("ink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि इंक आकृति स्लाइड पर पहली आकृति है।
        slide.getShapes().removeAt(0);

        presentation.save("ink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```