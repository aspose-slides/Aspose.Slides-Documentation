---
title: जावास्क्रिप्ट में प्रस्तुति व्यू गुण प्राप्त करें और अद्यतन करें
linktitle: व्यू गुण
type: docs
weight: 80
url: /hi/nodejs-java/presentation-view-properties/
keywords:
- व्यू गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- वर्टिकल स्प्लिटर को स्नैप करें
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- ऑटो समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के जावा व्यू गुणों के माध्यम से PPT, PPTX और ODP स्लाइड्स के फॉर्मेट को अनुकूलित करें — लेआउट, ज़ूम स्तर और प्रदर्शित सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और नीचे वाला सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण इस जानकारी को एप्लिकेशन को अपनी दृश्य स्थिति फ़ाइल में सहेजने की अनुमति देती है, ताकि जब पुनः खोला जाए तो दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

विधि[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) को प्रस्तुति के सामान्य दृश्य गुणों तक पहुंच प्रदान करने के लिए जोड़ा गया है।  

[NormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties) क्लास और उसकी वंशज, [SplitterBarStateType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType) एन्यू जोड़े गए हैं।

## **NormalViewProperties के बारे में**

सामान्य दृश्य गुणों को दर्शाता है।

विधियाँ[getShowOutlineIcons](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) और[setShowOutlineIcons](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) यह निर्दिष्ट करती हैं कि क्या सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय एप्लिकेशन को आइकन दिखाने चाहिए।  

विधियाँ[getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) और[setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्दिष्ट करती हैं कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।  

गुण[getPreferSingleView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) और[setPreferSingleView](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) यह निर्दिष्ट करता है कि क्या उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य की बजाय पूर्ण-खिड़की एकल-समग्री क्षेत्र देखना पसंद करता है। यदि सक्षम किया गया है, तो एप्लिकेशन एक सामग्री क्षेत्र को पूरी खिड़की में दिखाने का चयन कर सकता है।  

विधियाँ[getVerticalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) और[getHorizontalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) यह निर्दिष्ट करती हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे वाले सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं:[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Minimized),[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Maximized)और[SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Restored)।  

विधियाँ[getRestoredLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) और[getRestoredTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) सामान्य दृश्य के ऊपर या साइड स्लाइड क्षेत्र के आकार को निर्दिष्ट करती हैं, जब[SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SplitterBarStateType#Restored) मान को[getVerticalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--)और[getHorizontalBarState](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) पर क्रमशः लागू किया जाता है।

## **NormalViewProperties की पुनर्स्थापना के बारे में**

सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब यह[getRestoredTop](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) का चाइल्ड हो, ऊँचाई जब यह[getRestoredLeft](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) का चाइल्ड हो) के आकार को निर्दिष्ट करता है, जब क्षेत्र का आकार परिवर्ती पुनर्स्थापित आकार हो (न तो न्यूनतम और न ही अधिकतम)।  

विधि[getDimensionSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र का आकार निर्दिष्ट करती है (चौड़ाई जब यह restoredTop का चाइल्ड हो, ऊँचाई जब यह restoredLeft का चाइल्ड हो)।  

विधि[getAutoAdjust](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) यह निर्दिष्ट करती है कि जब एप्लिकेशन के भीतर दृश्य वाली विंडो के आकार में परिवर्तन किया जाता है तो साइड सामग्री क्षेत्र का आकार नई आकार की भरपाई करे या नहीं।  

नीचे दिया गया उदाहरण दर्शाता है कि आप प्रस्तुति के लिए[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुँच सकते हैं।

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // प्रस्तुति के व्यू गुण को पुनर्स्थापित करें
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="primary" %}} 

Aspose.Slides for Node.js via Java अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है, जिससे प्रस्तुति खोलने पर ज़ूम पहले से ही सेट हो जाता है। इसे[ViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) को सेट करके किया जा सकता है।[getSlideViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) तथा[getNotesViewProperties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामmatically सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि कैसे[View Properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) को[Presentation](/slides/hi/) में सेट किया जाता है।

{{% /alert %}} 

व्यू गुण सेट करने के लिए। कृपया नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) की[View Properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को एक[PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  
नीचे दिए गए उदाहरण में, हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // प्रस्तुति के व्यू गुण सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग-अलग व्यू सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), सेक्शन के अनुसार नहीं, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब यह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग व्यू स्थितियों को पहले से परिभाषित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और सभी के साथ साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता की प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट व्यू गुण रखती है।

**क्या मैं पूर्व-परिभाषित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियाँ उसी तरह खुलें?**

हाँ। क्योंकि[view properties](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/getviewproperties/) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें एक टेम्पलेट में एम्बेड कर सकते हैं और उसी प्रारंभिक व्यू कॉन्फ़िगरेशन के साथ नई डॉक्यूमेंट बना सकते हैं।