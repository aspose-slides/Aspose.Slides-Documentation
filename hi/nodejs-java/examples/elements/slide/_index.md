---
title: स्लाइड
type: docs
weight: 10
url: /hi/nodejs-java/examples/elements/slide/
keywords:
- कोड उदाहरण
- स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में स्लाइडों को नियंत्रित करें: बनाएं, क्लोन करें, पुनः क्रमबद्ध करें, आकार बदलें, पृष्ठभूमि सेट करें, और PPT, PPTX और ODP प्रस्तुतियों के लिए ट्रांज़िशन लागू करें।"
---
यह लेख कई उदाहरण प्रदान करता है जो दिखाते हैं कि **Aspose.Slides for Node.js via Java** का उपयोग करके स्लाइड्स के साथ कैसे काम किया जाए। आप `Presentation` क्लास का उपयोग करके स्लाइड्स को जोड़ना, एक्सेस करना, क्लोन करना, पुन: क्रमबद्ध करना और हटाना सीखेंगे।

नीचे प्रत्येक उदाहरण में संक्षिप्त व्याख्या के बाद JavaScript में कोड स्निपेट शामिल है।

## **स्लाइड जोड़ें**

नई स्लाइड जोड़ने के लिए आपको पहले लेआउट चुनना होगा। इस उदाहरण में, हम `Blank` लेआउट का उपयोग करते हैं और प्रस्तुति में एक खाली स्लाइड जोड़ते हैं।

```js
function addSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getSlides().addEmptySlide(layoutSlide);

        presentation.save("slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **नोट:** प्रत्येक स्लाइड लेआउट मास्टर स्लाइड से व्युत्पन्न होता है, जो समग्र डिज़ाइन और प्लेसहोल्डर संरचना को परिभाषित करता है। नीचे की छवि दिखाती है कि PowerPoint में मास्टर स्लाइड्स और उनके सम्बंधित लेआउट कैसे व्यवस्थित होते हैं।

![Master and Layout Relationship](master-layout-slide.png)

## **इंडेक्स द्वारा स्लाइड्स तक पहुँचें**

आप स्लाइड्स को उनके इंडेक्स का उपयोग करके एक्सेस कर सकते हैं। यह विशिष्ट स्लाइड्स के माध्यम से इटरेट करने या उन्हें संशोधित करने में उपयोगी है।

```js
function accessSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // इंडेक्स द्वारा एक स्लाइड तक पहुँचें।
        let firstSlide = presentation.getSlides().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड को क्लोन करें**

यह उदाहरण दिखाता है कि मौजूदा स्लाइड को कैसे क्लोन किया जाए। क्लोन की गई स्लाइड स्वचालित रूप से स्लाइड संग्रह के अंत में जोड़ दी जाती है।

```js
function cloneSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        let clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.save("slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड्स को पुन: क्रमबद्ध करें**

आप एक स्लाइड को नए इंडेक्स पर ले जाकर स्लाइड्स का क्रम बदल सकते हैं। इस मामले में, हम एक स्लाइड को पहली स्थिति में ले जाते हैं।

```js
function reorderSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        // दूसरी स्लाइड को पहली स्थिति में ले जाकर स्लाइड्स को पुन: क्रमबद्ध करें।
        let secondSlide = presentation.getSlides().get_Item(1);
        presentation.getSlides().reorder(0, secondSlide);

        presentation.save("slide_reordered.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **स्लाइड हटाएँ**

स्लाइड हटाने के लिए, बस उसका संदर्भ दें और `remove` को कॉल करें। यह उदाहरण एक दूसरा स्लाइड जोड़ता है और फिर मूल स्लाइड को हटा देता है, जिससे केवल नई स्लाइड बचती है।

```js
function removeSlide() {
    let presentation = new aspose.slides.Presentation("slide.pptx");
    try {
        let firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);

        presentation.save("slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```