---
title: SmartArt
type: docs
weight: 140
url: /hi/nodejs-java/examples/elements/smart-art/
keywords:
- कोड उदाहरण
- SmartArt
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides में SmartArt के साथ काम करें: PowerPoint और OpenDocument प्रस्तुतियों के लिए JavaScript के साथ आरेख बनाएं, संपादित करें, रूपांतरित करें और शैली दें।"
---
यह लेख प्रदर्शित करता है कि कैसे SmartArt ग्राफिक्स जोड़ें, उन्हें एक्सेस करें, हटाएँ, और लेआउट बदलें **Aspose.Slides for Node.js via Java** का उपयोग करके।

## **SmartArt जोड़ें**

निर्मित लेआउट में से एक का उपयोग करके SmartArt ग्राफ़िक सम्मिलित करें।

```js
function addSmartArt() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);

        presentation.save("smartart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt तक पहुँचें**

स्लाइड पर पहला SmartArt ऑब्जेक्ट प्राप्त करें।

```js
function accessSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstSmartArt = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
                firstSmartArt = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt हटाएँ**

स्लाइड से SmartArt आकृति हटाएँ।

```js
function removeSmartArt() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहला आकार SmartArt है।
        let smartArt = slide.getShapes().get_Item(0);

        slide.getShapes().remove(smartArt);

        presentation.save("smartart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt लेआउट बदलें**

मौजूदा SmartArt ग्राफ़िक का लेआउट प्रकार अपडेट करें।

```js
function changeSmartArtLayout() {
    let presentation = new aspose.slides.Presentation("smartart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहला आकार SmartArt है।
        let smartArt = slide.getShapes().get_Item(0);

        smartArt.setLayout(aspose.slides.SmartArtLayoutType.VerticalPictureList);

        presentation.save("smartart_layout_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```