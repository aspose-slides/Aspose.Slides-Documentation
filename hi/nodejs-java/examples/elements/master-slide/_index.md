---
title: मास्टर स्लाइड
type: docs
weight: 30
url: /hi/nodejs-java/examples/elements/master-slide/
keywords:
- कोड उदाहरण
- मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के मास्टर स्लाइड उदाहरणों की खोज करें: PPT, PPTX, और ODP में मास्टर, प्लेसेहोल्डर और थीम बनाएं, संपादित करें और स्टाइल करें, स्पष्ट कोड के साथ।"
---
मास्टर स्लाइड्स PowerPoint में स्लाइड विरासत पदानुक्रम के शीर्ष स्तर का निर्माण करती हैं। एक **master slide** पृष्ठभूमि, लोगो और टेक्स्ट फ़ॉर्मेटिंग जैसी सामान्य डिज़ाइन तत्वों को परिभाषित करती है। **Layout slides** मास्टर स्लाइड्स से विरासत में मिलती हैं, और **normal slides** लेआउट स्लाइड्स से विरासत में मिलती हैं।

यह लेख Aspose.Slides for Node.js via Java का उपयोग करके मास्टर स्लाइड्स को बनाने, संशोधित करने और प्रबंधित करने का तरीका दर्शाता है।

## **मास्टर स्लाइड जोड़ें**

यह उदाहरण डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करके नई मास्टर स्लाइड बनाने का तरीका दर्शाता है। इसके बाद यह लेआउट विरासत के माध्यम से सभी स्लाइड्स में कंपनी नाम बैनर जोड़ता है।

```js
function addMasterSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        // डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करें।
        let defaultMasterSlide = presentation.getMasters().get_Item(0);
        let newMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);

        let textBoxFillType = java.newByte(aspose.slides.FillType.NoFill);

        // मास्टर स्लाइड के शीर्ष पर कंपनी नाम के साथ बैनर जोड़ें।
        let textBox = newMasterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 720, 25);
        textBox.getTextFrame().setText("Company Name");
        textBox.getFillFormat().setFillType(textBoxFillType);

        let paragraphFillType = java.newByte(aspose.slides.FillType.Solid);
        let paragraphFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");

        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(paragraphFillType);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(paragraphFillColor);

        // नई मास्टर स्लाइड को लेआउट स्लाइड से असाइन करें।
        let layoutSlide = presentation.getLayoutSlides().get_Item(0);
        layoutSlide.setMasterSlide(newMasterSlide);

        // लेआउट स्लाइड को प्रस्तुति की पहली स्लाइड से असाइन करें.
        presentation.getSlides().get_Item(0).setLayoutSlide(layoutSlide);

        presentation.save("master_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **नोट 1:** मास्टर स्लाइड्स सभी स्लाइड्स में निरंतर ब्रांडिंग या साझा डिज़ाइन तत्वों को लागू करने का तरीका प्रदान करती हैं। मास्टर में किया गया कोई भी परिवर्तन स्वचालित रूप से निर्भर लेआउट और नॉर्मल स्लाइड्स पर परिलक्षित होगा।

> 💡 **नोट 2:** मास्टर स्लाइड में जोड़े गए किसी भी आकार या फ़ॉर्मेटिंग को लेआउट स्लाइड्स विरासत में लेती हैं और बदले में उन लेआउट्स का उपयोग करने वाली सभी नॉर्मल स्लाइड्स भी।  
> नीचे की छवि दर्शाती है कि कैसे मास्टर स्लाइड पर जोड़ा गया टेक्स्ट बॉक्स अंतिम स्लाइड पर स्वतः रेंडर होता है।

![मास्टर विरासत उदाहरण](master-slide-banner.png)

## **मास्टर स्लाइड तक पहुँचें**

आप प्रस्तुति मास्टर संग्रह का उपयोग करके मास्टर स्लाइड्स तक पहुँच सकते हैं। यहाँ बताया गया है कि उन्हें कैसे प्राप्त करें और उनके साथ काम करें:

```js
function accessMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        let firstMasterSlide = presentation.getMasters().get_Item(0);

        // पृष्ठभूमि प्रकार बदलें।
        let backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
        firstMasterSlide.getBackground().setType(backgroundType);
    } finally {
        presentation.dispose();
    }
}
```

## **मास्टर स्लाइड हटाएँ**

मास्टर स्लाइड्स को इंडेक्स या रेफ़रेंस के द्वारा हटाया जा सकता है।

```js
function removeMasterSlide() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // इंडेक्स द्वारा एक मास्टर स्लाइड हटाएँ।
        presentation.getMasters().removeAt(0);

        // रेफ़रेंस द्वारा एक मास्टर स्लाइड हटाएँ।
        let firstMasterSlide = presentation.getMasters().get_Item(0);
        presentation.getMasters().remove(firstMasterSlide);

        presentation.save("master_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कुछ प्रस्तुतियों में ऐसी मास्टर स्लाइड्स होती हैं जो उपयोग में नहीं हैं। इन स्लाइड्स को हटाने से फ़ाइल आकार कम करने में मदद मिल सकती है।

```js
function removeUnusedMasterSlides() {
    let presentation = new aspose.slides.Presentation("master_slide.pptx");
    try {
        // सभी अप्रयुक्त मास्टर स्लाइड्स हटाएँ (भले ही वे Preserve के रूप में चिह्नित हों)।
        presentation.getMasters().removeUnused(true);

        presentation.save("unused_master_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```