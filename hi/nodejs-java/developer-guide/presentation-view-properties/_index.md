---
title: JavaScript में प्रेज़ेंटेशन व्यू प्रॉपर्टीज़ को प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/nodejs-java/presentation-view-properties/
keywords:
- व्यू प्रॉपर्टीज़
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकन
- वर्टिकल स्प्लिटर स्नैप
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वचालित समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java view properties के माध्यम से PPT, PPTX, और ODP स्लाइड फ़ॉर्मैट को कस्टमाइज़ करें—लेआउट, ज़ूम स्तर, और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को उसके दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि जब पुनः खोलें तो दृश्य उस स्थिति में हो जैसा कि प्रस्तुतीकरण को अंतिम बार सहेजा गया था।

विधि [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) को प्रस्तुतीकरण की सामान्य दृश्य गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है।  

[NormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties) क्लास और इसके वंशज, [SplitterBarStateType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType) एन्‍युम को जोड़ा गया है।

## **NormalViewProperties के बारे में**

सामान्य दृश्य गुणों को दर्शाता है।

विधियाँ [getShowOutlineIcons](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) निर्धारित करती हैं कि क्या एप्लिकेशन को सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करने पर आइकन दिखाने चाहिए।

विधियाँ [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्धारित करती हैं कि जब साइड क्षेत्र पर्याप्त रूप से छोटा हो तो वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

गुण [getPreferSingleView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) यह निर्धारित करता है कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य की तुलना में पूर्ण-खिड़की एकल-सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे खिड़की में किसी एक सामग्री क्षेत्र को प्रदर्शित करना चुन सकता है।

विधियाँ [getVerticalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) यह निर्दिष्ट करती हैं कि आडंबर या वर्टिकल स्प्लिटर बार को किस स्थिति में दिखाया जाना चाहिए। एक आडंबर स्प्लिटर बार स्लाइड को स्लाइड के नीचे के सामग्री क्षेत्र से अलग करता है, वर्टिकल स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभव मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Restored)।

विधियाँ [getRestoredLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार निर्धारित करती हैं, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Restored) मान को [getVerticalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) पर लागू किया जाता है।

## **NormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य में स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) का बच्चा हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) का बच्चा हो) का आकार निर्दिष्ट करता है, जब क्षेत्र एक परिवर्तनीय पुनर्स्थापित आकार (न्यूनतम नहीं और अधिकतम नहीं) का हो।

विधि [getDimensionSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र का आकार निर्दिष्ट करती है (चौड़ाई जब यह restoredTop का बच्चा हो, ऊँचाई जब यह restoredLeft का बच्चा हो)।

विधि [getAutoAdjust](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) यह निर्दिष्ट करती है कि जब एप्लिकेशन के भीतर दृश्य वाली विंडो का आकार बदलते हैं तो साइड सामग्री क्षेत्र का आकार नए आकार के लिए समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुतीकरण के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुँच सकते हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // प्रस्तुतीकरण की व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
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
Aspose.Slides for Node.js via Java अब प्रस्तुतीकरण के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि जब प्रस्तुतीकरण खुलता है तो ज़ूम पहले से सेट हो। इसे प्रस्तुतीकरण के [ViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) तथा [getNotesViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामmatically सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) कैसे सेट करें।
{{% /alert %}} 

दृष्टि गुण सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का उदाहरण बनाएँ।  
2. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) सेट करें।  
3. प्रस्तुतीकरण को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें। नीचे दिए गए उदाहरण में, हमने स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट किया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // प्रस्तुतीकरण की व्यू प्रॉपर्टीज़ सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

प्रस्तुतीकरण-व्यापी दृश्य सेटिंग्स तक पहुँचने के लिए [Presentation.getViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getViewProperties--) का उपयोग करें। [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) और [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) मेथड्स अंतर्निहित संपादन ग्रिड की अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरे प्रस्तुतीकरण पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ के अनुसार एक सकारात्मक मान का उपयोग करें।

निम्नलिखित उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग को प्रिंट करता है, एक क्वार्टर-इंच अंतराल सेट करता है, और परिणाम को सहेजता है।

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

ग्रिड [drawing guides](/slides/hi/nodejs-java/drawing-guides/) से अलग है। ग्रिड स्पेसिंग एक नियमित अंतराल को नियंत्रित करती है, जबकि ड्रॉइंग गाइड्स को व्यक्तिगत रूप से क्षैतिज या लंबवत संरेखण रेखाओं के रूप में स्थित किया जाता है। ड्रॉइंग गाइड्स को जोड़ने, स्थानांतरित करने या साफ़ करने से ग्रिड स्पेसिंग नहीं बदलती।

ग्रिड और ड्रॉइंग गाइड दोनों ही संपादन सहायक हैं। उन्हें PDF, इमेज, SVG, या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं किया जाता। ग्रिड स्पेसिंग को सहेजना यह गारंटी नहीं देता कि कोई एडिटर ग्रिड दिखाएगा: इसकी दृश्यता दर्शक या एडिटर की प्राथमिकताओं पर भी निर्भर करती है।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रस्तुतीकरण पुनः खोलने के बाद ग्रिड क्यों नहीं दिख रहा है?**  
फ़ाइल ग्रिड स्पेसिंग को सहेजती है, लेकिन एडिटर यह नियंत्रित करता है कि ग्रिड दिखाया जाए या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग्स की जाँच करें।

**ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है क्या?**  
नहीं। ड्रॉइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से सहेजा गया ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुतीकरण के विभिन्न अनुभागों के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**  
[View settings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getviewproperties/) प्रस्तुतीकरण स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), न कि अनुभाग के अनुसार, इसलिए जब दस्तावेज़ खुलेगा तो पूरे दस्तावेज़ पर एक ही सेट पैरामीटर लागू होते हैं।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य स्थितियों को पहले से परिभाषित कर सकता हूँ?**  
नहीं। सेटिंग्स फ़ाइल में सहेजी जाती हैं और साझा होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल स्वयं एक ही सेट दृश्य गुण रखती है।

**क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियाँ उसी तरह खुलें?**  
हाँ। क्योंकि [view properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getviewproperties/) प्रस्तुतीकरण स्तर पर सहेजे जाते हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और उसी प्रारंभिक दृश्य विन्यास के साथ नई दस्तावेज़ बना सकते हैं।