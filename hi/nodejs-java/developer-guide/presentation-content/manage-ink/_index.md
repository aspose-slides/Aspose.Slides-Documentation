---
title: जावास्क्रिप्ट में प्रेज़ेंटेशन इंक ऑब्जेक्ट्स का प्रबंधन
linktitle: इंक प्रबंधन
type: docs
weight: 95
url: /hi/nodejs-java/manage-ink/
keywords:
- इंक
- इंक वस्तु
- इंक ट्रेस
- इंक प्रबंधन
- इंक ड्रॉ
- ड्राइंग
- इंक निर्यात
- इंक रेंडरिंग
- इंक छुपाएँ
- InkOptions
- PowerPoint
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ PDF, HTML, SVG, TIFF और इमेज निर्यात के दौरान PowerPoint इंक ऑब्जेक्ट्स को प्रबंधित करें, ट्रेसेस और ब्रश प्रॉपर्टीज़ को संपादित करें, और इंक की उपस्थिति को नियंत्रित करें।"
---
## **परिचय**

PowerPoint एक इंक फीचर प्रदान करता है जो आपको फ्रीफ़ॉर्म स्ट्रोक्स ड्रॉ करने देता है। इंक का उपयोग अन्य वस्तुओं को हाईलाइट करने, कनेक्शन और प्रक्रियाओं को दिखाने, तथा स्लाइड पर विशिष्ट आइटम्स पर ध्यान आकर्षित करने के लिए किया जा सकता है।

Aspose.Slides इंक ऑब्जेक्ट्स के साथ काम करने के लिए आवश्यक टाइप्स प्रदान करता है। उदाहरण के लिए, [Ink](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ink/) क्लास स्लाइड पर एक इंक ऑब्जेक्ट का प्रतिनिधित्व करती है।

## **सामान्य ऑब्जेक्ट्स और इंक ऑब्जेक्ट्स के अंतर**

PowerPoint स्लाइड पर ऑब्जेक्ट्स आमतौर पर शेप ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं। सबसे सरल रूप में, शेप एक कंटेनर होता है जो ऑब्जेक्ट के स्वयं के क्षेत्र (उसका फ्रेम) को परिभाषित करता है, साथ ही कंटेनर का आकार, आकार और पृष्ठभूमि जैसी प्रॉपर्टीज़ को भी देता है। अधिक जानकारी के लिए देखें [Shape Layout Format](https://docs.aspose.com/slides/hi/nodejs-java/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint इंक ऑब्जेक्ट को संभालता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी प्रॉपर्टीज़ को छोड़ देता है, सिवाय उसके आकार के। कंटेनर क्षेत्र का आकार मानक [Shape.getWidth](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getWidth--) और [Shape.getHeight](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getHeight--) मेथड्स द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंक ट्रेसेस**

इंक ट्रेस एक बुनियादी तत्व है जो उपयोगकर्ता द्वारा डिजिटल इंक लिखते समय पेन की मार्ग को रिकॉर्ड करने के लिए उपयोग होता है। एक ट्रेस कनेक्टेड पॉइंट्स की श्रृंखला को संग्रहीत करता है।

सबसे सरल एन्कोडिंग प्रत्येक सैंपल पॉइंट के X और Y निर्देशांक को निर्दिष्ट करती है। जब सभी कनेक्टेड पॉइंट्स को रेंडर किया जाता है, तो वे इस प्रकार की इमेज बनाते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिए ब्रश प्रॉपर्टीज़**

ब्रश का उपयोग इंक ट्रेस के पॉइंट्स को जोड़ने वाली लाइनों को ड्रॉ करने के लिए किया जाता है। ब्रश का अपना रंग और आकार होता है, जो [InkBrush.getColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkbrush/#getColor--) और [InkBrush.getSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkbrush/#getSize--) मेथड्स द्वारा प्रदर्शित होते हैं।

### **इंक ब्रश का रंग सेट करें**

यह JavaScript कोड इंक ब्रश का रंग सेट करने का तरीका दिखाता है:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **इंक ब्रश का आकार सेट करें**

यह JavaScript कोड इंक ब्रश का आकार सेट करने का तरीका दिखाता है:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

आमतौर पर, ब्रश की चौड़ाई और ऊँचाई मेल नहीं खाती, इसलिए PowerPoint ब्रश के आकार को प्रदर्शित नहीं करता (संबंधित डेटा सेक्शन ग्रे आउट हो जाता है)। जब ब्रश की चौड़ाई और ऊँचाई मेल खाती है, तो PowerPoint इसका आकार इस तरह दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टीकरण के लिए, आइए इंक ऑब्जेक्ट की ऊँचाई बढ़ाएँ और महत्वपूर्ण आयामों की समीक्षा करें:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ्रेम) ब्रश के आकार को ध्यान में नहीं रखता—यह हमेशा मानता है कि लाइन की मोटाई शून्य है (पिछली इमेज देखें)।

इसलिए, पूरे इंक ऑब्जेक्ट के दृश्य क्षेत्र को निर्धारित करने के लिए, उसके ट्रेसेस के ब्रश आकार को ध्यान में रखना आवश्यक है। यहाँ लक्ष्य ऑब्जेक्ट (हस्तलेख टेक्स्ट ट्रेस) को कंटेनर (फ्रेम) के आकार के अनुसार स्केल किया गया है। जब कंटेनर का आकार बदलता है, तो ब्रश का आकार स्थिर रहता है, और इसके विपरीत भी।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट ऑब्जेक्ट्स के लिए समान व्यवहार का उपयोग करता है:

![ink_powerpoint6](ink_powerpoint6.png)

## **एक्सपोर्ट और रेंडरिंग दौरान इंक उपस्थिति को नियंत्रित करें**

Aspose.Slides इंक ऑब्जेक्ट्स की निर्यात या रेंडर किए गए आउटपुट में उपस्थिति को नियंत्रित करने के लिए [InkOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/) क्लास प्रदान करता है। आप इसकी प्रॉपर्टीज़ का उपयोग करके इंक को पूरी तरह छुपा सकते हैं या इंक ब्रश मास्क ऑपरेशन्स की व्याख्या बदल सकते हैं।

इंक ऑप्शन विभिन्न आउटपुट प्रकारों के लिए निर्यात या रेंडरिंग ऑप्शन्स के माध्यम से उपलब्ध हैं:

| आउटपुट | इंक विकल्प प्रॉपर्टी |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| स्लाइड इमेज | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

निम्नलिखित [InkOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/) मेथड्स वही दो सेटिंग्स उजागर करते हैं:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#getHideInk--) निर्धारित करता है कि इंक ऑब्जेक्ट्स आउटपुट में शामिल हों या नहीं। इसका डिफ़ॉल्ट मान `false` है।
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) निर्धारित करता है कि रेंडरिंग के समय इंक ब्रश के लिए मास्क ऑपरेशन को अपारदर्शिता के रूप में व्याख्या किया जाए या नहीं। इसका डिफ़ॉल्ट मान `true` है; `false` के साथ [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) को कॉल करके ROP ऑपरेशन का उपयोग करें।

### **PDF आउटपुट में इंक ऑब्जेक्ट्स को छुपाएँ**

डिफ़ॉल्ट रूप से, निर्यात के दौरान इंक ऑब्जेक्ट्स दिखाई देते हैं। हस्तलेख टिप्पणियों या अन्य इंक सामग्री के बिना एक साफ आउटपुट बनाने के लिए, `true` के साथ [InkOptions.setHideInk](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) को कॉल करें।

निम्न JavaScript उदाहरण सभी इंक ऑब्जेक्ट्स को छुपाते हुए प्रस्तुति को PDF में निर्यात करता है:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **स्लाइड को इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छुपाएँ**

स्लाइड को बिटमैप इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छुपाने के लिए, [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) को कॉन्फ़िगर करें और रेंडरिंग ऑप्शन्स को [Slide.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-) को पास करें।

निम्न JavaScript उदाहरण पहला स्लाइड PNG इमेज के रूप में बिना इंक ऑब्जेक्ट्स के रेंडर करता है:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **इंक मास्क रेंडरिंग को नियंत्रित करें**

[InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) सेटिंग रेंडरिंग के समय इंक ब्रश के लिए मास्क ऑपरेशन्स की व्याख्या को नियंत्रित करती है। डिफ़ॉल्ट मान `true` है, जो अपारदर्शिता का उपयोग करता है। ROP ऑपरेशन का उपयोग करने के लिए, `false` के साथ [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) को कॉल करें।

निम्न JavaScript उदाहरण स्लाइड को SVG में निर्यात करता है और इंक मास्क ऑपरेशन्स के लिए ROP‑आधारित रेंडरिंग का उपयोग करता है:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

इसी सेटिंग को [TiffOptions.getInkOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) के माध्यम से भी लागू किया जा सकता है जब प्रस्तुति को निर्यात किया जाए या स्लाइड को TIFF में रेंडर किया जाए।

### **इंक को छुपाएँ या संरक्षित रखें, चुनें**

जब आपको समीक्षा चिह्नों के बिना वितरित करने के लिए एनोटेटेड प्रस्तुति का एक साफ़ संस्करण चाहिए, तो निर्यात के दौरान `true` के साथ [InkOptions.setHideInk](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) को कॉल करें।

जब इंक एनोटेशन इच्छित सामग्री का हिस्सा हैं—जैसे समीक्षा टिप्पणी, हस्तलेख नोट्स, हाईलाइट या ड्रॉइंग्स—तो निर्यात परिणाम में उन्हें दिखाने के लिए [InkOptions.getHideInk](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#getHideInk--) को डिफ़ॉल्ट `false` पर रखें। इससे अनुप्रयोग समान प्रस्तुति से स्रोत इंक ऑब्जेक्ट्स को बदले बिना अलग-अलग समीक्षा और अंतिम आउटपुट बना सकते हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा इंक स्ट्रोक का रंग या आकार बदल सकता हूँ?**

हाँ। [Ink.getTraces](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ink/#getTraces--) से ट्रेस प्राप्त करें और फिर उसके [InkTrace.getBrush](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inktrace/#getBrush--) को बदलें। ब्रश का रंग बदलने के लिए [InkBrush.setColor](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) या आकार बदलने के लिए [InkBrush.setSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) को कॉल करें।

**क्या इंक को छुपाने से स्रोत प्रस्तुति बदलती है?**

नहीं। [InkOptions.setHideInk](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) को कॉल करने से केवल रेंडर या निर्यात परिणाम प्रभावित होता है; यह स्रोत प्रस्तुति में इंक ऑब्जेक्ट्स को हटाता या संशोधित नहीं करता।

**कौन से एक्सपोर्ट फ़ॉर्मेट इंक ऑप्शन्स का समर्थन करते हैं?**

आप ऊपर दिखाए गए संबंधित निर्यात या रेंडरिंग ऑप्शन्स के माध्यम से PDF, HTML, SVG, TIFF और बिटमैप स्लाइड इमेजेज़ के लिए इंक ऑप्शन्स कॉन्फ़िगर कर सकते हैं।

**अतिरिक्त पढ़ाई**

* सामान्य रूप से शेप्स के बारे में पढ़ने के लिए, देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/nodejs-java/powerpoint-shapes/) सेक्शन।
* प्रभावी मानों के बारे में अधिक जानकारी के लिए, देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/nodejs-java/shape-effective-properties/#get-effective-font-height-value)।
* PDF निर्यात के विवरण के लिए, देखें [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hi/nodejs-java/convert-powerpoint-to-pdf/)।
* HTML निर्यात के विवरण के लिए, देखें [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hi/nodejs-java/convert-powerpoint-to-html/)।
* SVG निर्यात के विवरण के लिए, देखें [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/)।
* TIFF निर्यात के विवरण के लिए, देखें [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hi/nodejs-java/convert-powerpoint-to-tiff/)।
* स्लाइड‑टू‑इमेज रेंडरिंग के विवरण के लिए, देखें [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hi/nodejs-java/convert-slide/).