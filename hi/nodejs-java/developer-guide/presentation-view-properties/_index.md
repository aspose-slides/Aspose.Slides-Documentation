---
title: जावास्क्रिप्ट में प्रस्तुति दृश्य गुणों को प्राप्त करें और अद्यतन करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/nodejs-java/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकन
- ऊर्ध्वाधर विभाजक स्नैप
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वतः समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js के लिए Aspose.Slides को Java के माध्यम से उपयोग करके PowerPoint प्रस्तुतियों में सामान्य दृश्य लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड अंतराल, तथा टिप्पणी दृश्यता को कॉन्फ़िगर करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड थंबनेल या आउटलाइन के साइड पैन और नीचे नोट्स पैन के बीच दिखाई देती है। Aspose.Slides for Node.js via Java प्रस्तुति की सहेजी गई संपादन प्राथमिकताओं को [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) के माध्यम से प्रकट करता है। इनमें पैन लेआउट, ज़ूम स्तर, ग्रिड अंतराल, और टिप्पणी दृश्यता शामिल हैं।

## **NormalViewProperties के बारे में**

[getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) का उपयोग करके [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/) क्लास तक पहुँचें। [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) नियंत्रित करता है कि आउटलाइन में स्लाइड शीर्षक के बगल में आइकन दिखाए जाएँ या नहीं। [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) उपयोगकर्ता द्वारा साइड पैन को संकरी करने पर उसे न्यूनतम स्थिति में स्नैप करने देता है। [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) पूर्ण विंडो में केवल एक पैन प्रदर्शित करने की प्राथमिकता दर्शाता है।

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) साइड पैन और स्लाइड के बीच विभाजक को नियंत्रित करता है। [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) नोट्स पैन के ऊपर विभाजक को नियंत्रित करता है। दोनों [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) के `Minimized`, `Maximized`, या `Restored` मान स्वीकार करते हैं।

## **NormalViewProperties को पुनर्स्थापित करने के बारे में**

जब विभाजक पुनर्स्थापित किया जाता है, तो [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) साइड पैन के सहेजे गए आकार को प्रदान करता है और [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) ऊपर वाले स्लाइड क्षेत्र के सहेजे गए आकार को प्रदान करता है। दोनों ही [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/) को उजागर करते हैं। इसका [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) मेथड 0 से 100 के बीच प्रतिशत स्वीकार करता है, और [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) नियंत्रित करता है कि विंडो आकार बदलने पर संपादक आकार को स्वचालित रूप से समायोजित करे या नहीं।

यह उदाहरण मौजूदा प्रस्तुति को अपडेट करता है। यह क्षैतिज विभाजक को पुनर्स्थापित करता है, [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) द्वारा लौटाए गए आकार को 80 % पर सेट करता है और स्वचालित समायोजन सक्षम करता है, तथा लंबवत विभाजक को अधिकतम करता है। यह आउटलाइन दृश्य में आइकन दिखाने के लिए [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) को भी कॉल करता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) और [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) संपादक के लिए स्वतंत्र ज़ूम सेटिंग्स संग्रहीत करते हैं। ये सेटिंग्स स्लाइड आयाम, स्लाइड‑शो प्लेबैक, या छवि निर्यात रिज़ॉल्यूशन को प्रभावित नहीं करतीं।

यह उदाहरण मौजूदा प्रस्तुति खोलता है और स्लाइड को संपादन विंडो में फिट करने के लिए [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) को कॉल करता है। नोट्स पेज के लिए यह स्वचालित स्केलिंग को अक्षम करता है और स्थिर 80 % ज़ूम सेट करने के लिए [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) को कॉल करता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड अंतराल सेट करें**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) प्रस्तुति भर में संपादन ग्रिड रेखाओं के बीच की दूरी निर्धारित करता है। यह बिंदुओं में सकारात्मक मान लेता है, जहाँ 1 इंच में 72 बिंदु होते हैं। यह उदाहरण मौजूदा प्रस्तुति में वर्तमान अंतराल प्रिंट करता है और अंतराल को 18 बिंदु (¼ इंच) सेट करके एक चौथाई‑इंच ग्रिड सहेजता है।

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ग्रिड एक निश्चित अंतराल पर दोहराता है। [Drawing guides](/slides/hi/nodejs-java/drawing-guides/) व्यक्तिगत क्षैतिज या लंबवत स्थितियों को चिह्नित करती हैं। दोनों ही संपादन सहायता हैं और केवल उन संपादकों में दिखाई देती हैं जो इन्हें प्रदर्शित करते हैं। स्लाइड‑शो और PDF, छवि, या SVG निर्यात में ये नहीं दिखतीं।

## **प्रस्तुति खोलते समय टिप्पणियाँ दिखाएँ या छिपाएँ**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) एक प्राथमिकता संग्रहीत करता है जिसे संगत संपादक प्रस्तुति खोलते समय उपयोग करते हैं। टिप्पणी‑सम्पन्न मौजूदा प्रस्तुति के लिए यह उदाहरण वर्तमान सेटिंग प्रिंट करता है और टिप्पणी छिपाकर एक कॉपी सहेजता है। यह कॉपी को स्लाइड व्यू में खोलने के लिए [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) को [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) के साथ भी कॉल करता है।

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

टिप्पणियों को छिपाने से उनका पाठ, लेखक, स्थितियां, उत्तर, और स्थितियां संरक्षित रहती हैं। टिप्पणी स्वयं को बदलने के लिए देखें [Presentation Comments](/slides/hi/nodejs-java/presentation-comments/)। निर्यात सेटिंग्स नियंत्रित करती हैं कि टिप्पणी PDF, HTML, छवियों, नोट्स, या हैंडआउट्स में दिखें या नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मैं प्रस्तुति फिर से खोलता हूँ तो ग्रिड क्यों छुपा रहता है?**

प्रस्तुति ग्रिड अंतराल संग्रहीत करती है। ग्रिड देखने के लिए संपादक में ग्रिड दृश्यता सक्षम करें।

**क्या ड्राइंग गाइड्स हटाने से ग्रिड अंतराल बदलता है?**

नहीं। गाइड जोड़ने, स्थानांतरित करने या हटाने से ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या प्रस्तुति के विभिन्न सेक्शन के लिये अलग‑अलग दृश्य सेटिंग्स हो सकती हैं?**

नहीं। [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) पूरी प्रस्तुति पर लागू होती है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिये अलग‑अलग दृश्य सेटिंग्स सहेज सकता हूँ?**

फ़ाइल सभी उपयोगकर्ताओं के लिये एक सेट दृश्य गुण संग्रहीत करती है। एक संपादक उपयोगकर्ता की स्थानीय प्राथमिकताओं को भी लागू कर सकता है।

**क्या मैं टेम्पलेट में दृश्य सेटिंग्स सहेज सकता हूँ?**

हां। टेम्पलेट से बनाई गई प्रस्तुतियों में उसके सहेजे हुए दृश्य सेटिंग्स विरासत में मिलते हैं。