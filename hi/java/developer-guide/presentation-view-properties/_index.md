---
title: "Java में प्रस्तुति व्यू प्रॉपर्टीज़ प्राप्त करें और अपडेट करें"
linktitle: "व्यू प्रॉपर्टीज़"
type: docs
weight: 80
url: /hi/java/presentation-view-properties/
keywords:
  - "व्यू प्रॉपर्टीज़"
  - "सामान्य दृश्य"
  - "आउटलाइन सामग्री"
  - "आउटलाइन आइकन"
  - "स्नैप वर्टिकल स्प्लिटर"
  - "सिंगल व्यू"
  - "बार स्थिति"
  - "आयाम आकार"
  - "ऑटो एडजस्ट"
  - "डिफ़ॉल्ट ज़ूम"
  - "PowerPoint"
  - "OpenDocument"
  - "प्रस्तुति"
  - "Java"
  - "Aspose.Slides"
description: "Aspose.Slides for Java की व्यू प्रॉपर्टीज़ को खोजें ताकि आप PPT, PPTX और ODP स्लाइड्स के फ़ॉर्मेट को कस्टमाइज़ कर सकें—लेआउट, ज़ूम लेवल और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और एक नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि जब फिर से खोला जाए तो दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) को जोड़ा गया है ताकि प्रस्तुति के सामान्य दृश्य गुणों तक पहुंच प्रदान की जा सके।  

[INormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties) इंटरफ़ेस और उनके उतराधिकारी, [SplitterBarStateType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType) enum को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) यह निर्दिष्ट करते हैं कि क्या एप्लिकेशन को किसी भी सामान्य दृश्य मोड के सामग्री क्षेत्रों में रूपरेखा सामग्री प्रदर्शित करते समय आइकन दिखाने चाहिए।  

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्धारित करता है कि साइड क्षेत्र पर्याप्त छोटा होने पर vertical splitter को न्यूनतम अवस्था में स्नैप करना चाहिए या नहीं।  

Property [getPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) यह निर्धारित करता है कि क्या उपयोगकर्ता मानक त्रि‑क्षेत्रीय दृश्य के बजाय पूर्ण‑विंडो एक‑क्षेत्रीय दृश्य देखना पसंद करता है। यदि सक्षम किया जाता है, तो एप्लिकेशन पूरे विंडो में एक सामग्री क्षेत्र प्रदर्शित कर सकता है।  

Methods [getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) यह निर्दिष्ट करते हैं कि क्षैतिज या लंबवत splitter bar को किस अवस्था में दिखाया जाना चाहिए। क्षैतिज splitter bar स्लाइड को नीचे के सामग्री क्षेत्र से अलग करता है, जबकि लंबवत splitter bar स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored)।  

Methods [getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) यह निर्धारित करते हैं कि सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होगा, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored) मान को क्रमशः [getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) पर लागू किया जाता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब क्षेत्र का आकार परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम न ही अधिकतम) हो, तब सामान्य दृश्य के स्लाइड क्षेत्र (यदि यह [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) का बच्चा है तो चौड़ाई, और यदि यह [getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का बच्चा है तो ऊँचाई) के आकार को निर्दिष्ट करता है।  

Method [getDimensionSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र के आकार (restoredTop का बच्चा होने पर चौड़ाई, restoredLeft का बच्चा होने पर ऊँचाई) को निर्दिष्ट करता है।  

Method [getAutoAdjust](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) यह निर्धारित करता है कि विंडो को पुनः आकार देने पर साइड सामग्री क्षेत्र का आकार नई विंडो आकार के अनुसार स्वयं समायोजित होना चाहिए या नहीं।  

नीचे दिया गया उदाहरण दिखाता है कि आप एक प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुंच सकते हैं।

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // प्रस्तुति की व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="primary" %}} 

Aspose.Slides for Java अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि जब प्रस्तुति खोली जाए, ज़ूम पहले से ही सेट हो। इसे प्रस्तुति की [व्यू प्रॉपर्टीज़](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि कैसे [व्यू प्रॉपर्टीज़](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) में [Aspose.Slides](/slides/hi/) के साथ सेट किया जाए।

{{% /alert %}} 

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक उदाहरण बनाएं।  
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) की [व्यू प्रॉपर्टीज़](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) सेट करें।  
1. प्रेजेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  
   नीचे दिए गए उदाहरण में हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```java
Presentation presentation = new Presentation();
try {
    // प्रस्तुति की व्यू प्रॉपर्टीज़ सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुति के विभिन्न भागों के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**  

[व्यू सेटिंग्स](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर परिभाषित होती हैं ([Normal View](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), न कि प्रत्येक भाग पर, इसलिए जब फ़ाइल खोली जाती है तो सभी दस्तावेज़ पर एक ही पैरामीटर सेट लागू होता है।  

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य अवस्थाएँ पूर्वनिर्धारित कर सकता हूँ?**  

नहीं। सेटिंग्स फ़ाइल में संग्रहीत रहती हैं और सभी उपयोगकर्ताओं के बीच साझा होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को मान सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट दृश्य गुण रखती है।  

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुतियों का प्रारम्भिक दृश्य समान हो?**  

हाँ। क्योंकि [व्यू प्रॉपर्टीज़](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर संग्रहीत होती हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और उसी प्रारम्भिक दृश्य कॉन्फ़िगरेशन के साथ नए दस्तावेज़ बना सकते हैं।