---
title: लेआउट स्लाइड
type: docs
weight: 20
url: /hi/nodejs-java/examples/elements/layout-slide/
keywords:
- कोड उदाहरण
- लेआउट स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में मास्टर लेआउट स्लाइड्स: स्लाइड लेआउट, प्लेसहोल्डर, और मास्टर को चुनें, लागू करें, और अनुकूलित करें, PPT, PPTX, और ODP प्रस्तुतियों के उदाहरणों के साथ।"
---
यह लेख Aspose.Slides for Node.js via Java में **Layout Slides** के साथ काम करने का प्रदर्शन करता है। एक लेआउट स्लाइड सामान्य स्लाइडों द्वारा विरासत में लिए गए डिज़ाइन और फ़ॉर्मेटिंग को परिभाषित करती है। आप लेआउट स्लाइड को जोड़ सकते हैं, एक्सेस कर सकते हैं, क्लोन कर सकते हैं और हटा सकते हैं, साथ ही अनउपयोगी स्लाइडों को साफ करके प्रस्तुति का आकार कम कर सकते हैं।

## **लेआउट स्लाइड जोड़ें**

आप पुन: उपयोग योग्य फ़ॉर्मेटिंग को परिभाषित करने के लिए एक कस्टम लेआउट स्लाइड बना सकते हैं।

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // एक ब्लैंक लेआउट प्रकार और एक कस्टम नाम के साथ लेआउट स्लाइड बनाएं।
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **नोट 1:** लेआउट स्लाइड व्यक्तिगत स्लाइडों के लिए टेम्पलेट के रूप में कार्य करती हैं। आप सामान्य तत्वों को एक बार परिभाषित कर कई स्लाइडों में पुन: उपयोग कर सकते हैं।

> 💡 **नोट 2:** जब आप लेआउट स्लाइड में आकार या पाठ जोड़ते हैं, तो उस लेआउट पर आधारित सभी स्लाइडें यह साझा सामग्री स्वचालित रूप से प्रदर्शित करती हैं।  
> नीचे का स्क्रीनशॉट दो स्लाइडें दिखाता है, प्रत्येक समान लेआउट स्लाइड से एक टेक्स्ट बॉक्स विरासत में प्राप्त कर रहा है।

![लेआउट सामग्री विरासत में लेती स्लाइड्स](layout-slide-result.png)

## **लेआउट स्लाइड तक पहुँचें**

लेआउट स्लाइड को इंडेक्स या लेआउट प्रकार (जैसे `Blank`, `Title`, `SectionHeader`, आदि) द्वारा एक्सेस किया जा सकता है।

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // इंडेक्स द्वारा लेआउट स्लाइड तक पहुँचें।
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // प्रकार द्वारा लेआउट स्लाइड तक पहुँचें।
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **लेआउट स्लाइड हटाएँ**

यदि किसी विशेष लेआउट स्लाइड की अब आवश्यकता नहीं है, तो आप उसे हटा सकते हैं।

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // प्रकार द्वारा लेआउट स्लाइड प्राप्त करें और उसे हटाएँ।
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **अनुपयोगी लेआउट स्लाइड हटाएँ**

प्रस्तुति का आकार कम करने के लिए, आप उन लेआउट स्लाइडों को हटाना चाह सकते हैं जो किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं की गई हैं।

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // स्वचालित रूप से सभी लेआउट स्लाइडों को हटाता है जो किसी भी स्लाइड द्वारा संदर्भित नहीं हैं।
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **लेआउट स्लाइड क्लोन करें**

आप `addClone` मेथड का उपयोग करके लेआउट स्लाइड को दोहरा सकते हैं।

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // प्रकार द्वारा मौजूदा लेआउट स्लाइड प्राप्त करें।
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // लेआउट स्लाइड को लेआउट स्लाइड संग्रह के अंत में क्लोन करें।
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **सारांश:** लेआउट स्लाइड स्लाइडों में सुसंगत फ़ॉर्मेटिंग को प्रबंधित करने के लिए शक्तिशाली उपकरण हैं। Aspose.Slides लेआउट स्लाइडों को बनाने, प्रबंधित करने और ऑप्टिमाइज़ करने पर पूर्ण नियंत्रण प्रदान करता है।