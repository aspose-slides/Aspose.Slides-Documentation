---
title: JavaScript में प्रस्तुति व्यू प्रॉपर्टीज़ को प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/nodejs-java/presentation-view-properties/
keywords: 
- व्यू प्रॉपर्टीज़
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकन
- वर्टिकल स्प्लिटर को स्नैप करना
- सिंगल व्यू
- बार स्थिति
- डायमेंशन आकार
- ऑटो एडजस्ट
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js for Java के व्यू प्रॉपर्टीज़ का उपयोग करके PPT, PPTX और ODP स्लाइड फॉर्मैट को कस्टमाइज़ करें—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और एक नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को उसके दृश्य स्थिति को फ़ाइल में सहेजने में सक्षम बनाती है, ताकि पुनः खोलने पर दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति को आखिरी बार सहेजा गया था।

[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) मेथड को प्रस्तुति की सामान्य दृश्य गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties) क्लास और इसकी व्युत्पन्न, [SplitterBarStateType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType) एनीम जोड़ा गया है।

## **NormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

मेथड [getShowOutlineIcons](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) और मेथड [setShowOutlineIcons](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) यह निर्दिष्ट करता है कि क्या एप्लिकेशन को सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय आइकन दिखाने चाहिए।

मेथड [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) और मेथड [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्दिष्ट करता है कि साइड क्षेत्र पर्याप्त रूप से छोटा होने पर लंबवत विभाजक को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

प्रॉपर्टी [getPreferSingleView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) यह निर्दिष्ट करता है कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य के बजाय पूर्ण-खिड़की एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया जाता है, तो एप्लिकेशन एक सामग्री क्षेत्र को पूरी खिड़की में प्रदर्शित करने का चयन कर सकता है।

मेथड [getVerticalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) और मेथड [getHorizontalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) यह निर्धारित करते हैं कि क्षैतिज या लंबवत विभाजक पट्टी किस स्थिति में दिखाई देनी चाहिए। एक क्षैतिज विभाजक पट्टी स्लाइड को नीचे के सामग्री क्षेत्र से अलग करती है, जबकि लंबवत विभाजक पट्टी स्लाइड को साइड सामग्री क्षेत्र से अलग करती है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Restored)।

मेथड [getRestoredLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) और मेथड [getRestoredTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) यह निर्धारित करते हैं कि सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Restored) मान को क्रमशः [getVerticalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) पर लागू किया जाता है।

## **NormalViewProperties को पुनर्स्थापित करने के बारे में** 

जब क्षेत्र बदलते आकार (न तो न्यूनतम और न ही अधिकतम) के साथ पुनर्स्थापित हो, तो सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब [getRestoredTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) का बच्चा हो, और ऊँचाई जब [getRestoredLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) का बच्चा हो) का आकार निर्धारित करता है।

मेथड [getDimensionSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र का आकार (पुनर्स्थापित शीर्ष का बच्चा होने पर चौड़ाई, पुनर्स्थापित बाएँ का बच्चा होने पर ऊँचाई) निर्दिष्ट करता है।

मेथड [getAutoAdjust](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) यह निर्दिष्ट करता है कि विंडो के आकार बदलने पर साइड सामग्री क्षेत्र का आकार नई स्थिति के अनुरूप समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दर्शाता है कि आप प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुँच सकते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // प्रेजेंटेशन के व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java अब प्रस्तुति के लिए डिफ़ॉल्ट जूम मान सेट करने का समर्थन करता है ताकि प्रस्तुति खोलते ही जूम पहले से सेट हो। यह [ViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) तथा [getNotesViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामmatically सेट किया जा सकता है। इस विषय में हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) को कैसे सेट करें।

{{% /alert %}} 

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) वर्ग का इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें। नीचे दिए गए उदाहरण में हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // प्रेजेंटेशन के व्यू प्रॉपर्टीज़ सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getViewProperties--) का प्रयोग करके प्रस्तुति-व्यापी व्यू सेटिंग्स तक पहुँचें। [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) और [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) मेथड आधारभूत संपादन ग्रिड के अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि किसी व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ में निर्दिष्ट अनुसार सकारात्मक मान उपयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई‑इंच का अंतराल सेट करता है, और परिणाम सहेजता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ग्रिड [drawing guides](/slides/hi/nodejs-java/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्रॉइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। गाइड्स को जोड़ना, ले जाना या साफ़ करना ग्रिड स्पेसिंग को नहीं बदलता।

ग्रिड और ड्रॉइंग गाइड दोनों ही संपादन सहायता हैं। वे PDF, छवियों, SVG, या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को संग्रहीत करना यह गारंटी नहीं देता कि कोई संपादक ग्रिड दिखाएगा: इसकी दृश्यमानता दर्शक या संपादक की प्राथमिकताओं पर भी निर्भर करती है।

## **प्रेजेंटेशन खोलते समय टिप्पणियां दिखाएँ या छिपाएँ**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getViewProperties--) का प्रयोग करके प्रस्तुति‑व्यापी व्यू सेटिंग्स तक पहुँचें। [ViewProperties.getShowComments](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#getShowComments--) और [ViewProperties.setShowComments](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) का उपयोग करके यह पढ़ें या बदलें कि टिप्पणीें प्रस्तुति PowerPoint या अन्य संगत संपादक में खुले तो दिखानी चाहिए या नहीं।

यह सेटिंग केवल संग्रहीत व्यू प्राथमिकता को नियंत्रित करती है। यह टिप्पणीें जोड़ती, हटाती, संपादित नहीं करती या हल नहीं करती। टिप्पणीें छिपाने से उनका सामग्री, लेखक, स्थिति, उत्तर और स्थिति संरक्षित रहती है। टिप्पणीें स्वयं को बदलने वाले संचालन के लिए देखें [Presentation Comments](/slides/hi/nodejs-java/presentation-comments/)।

निम्न उदाहरण के लिए एक मौजूदा `comments.pptx` आवश्यक है जिसमें टिप्पणीें हों। यह वर्तमान दृश्यता सेटिंग प्रिंट करता है, टिप्पणीें छिपाने का अनुरोध करता है, और बिना किसी टिप्पणी को हटाए नया PPTX सहेजता है। यह [ViewProperties.setLastView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) को [ViewType.SlideView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewtype/#SlideView) के साथ उपयोग करके टिप्पणी दृश्यता के साथ प्रारंभिक संपादन दृश्य को कॉन्फ़िगर करता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणीें PDF, HTML, इमेज, नोट्स या हैंडआउट निर्यात में शामिल होंगी या नहीं। संबंधित निर्यात‑विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **FAQ**

**प्रेज़ेंटेशन पुनः खोलने पर ग्रिड क्यों नहीं दिख रहा है?**

फ़ाइल ग्रिड स्पेसिंग संग्रहीत करती है, लेकिन संपादक तय करता है कि ग्रिड प्रदर्शित हो या नहीं। संपादक की ग्रिड दृश्यमानता सेटिंग्स जाँचें।

**ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है क्या?**

नहीं। ड्रॉइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग‑अलग व्यू सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), सेक्शन‑वार नहीं, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब यह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग व्यू स्टेट्स पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को सम्मानित कर सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट व्यू प्रॉपर्टीज़ रखती है।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुति समान तरीके से खुले?**

हां। चूँकि [view properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर संग्रहीत होती हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और नया दस्तावेज़ उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ बना सकते हैं।