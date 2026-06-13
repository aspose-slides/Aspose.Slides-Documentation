---
title: Android पर प्रस्तुति व्यू प्रॉपर्टीज़ को पुनः प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/androidjava/presentation-view-properties/
keywords:
- व्यू प्रॉपर्टीज़
- सामान्य दृश्य
- आउटलाइन कंटेंट
- आउटलाइन आइकन
- स्नैप वर्टिकल स्प्लिटर
- सिंगल व्यू
- बार स्टेट
- डायमेंशन साइज
- ऑटो एडजस्ट
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java व्यू प्रॉपर्टीज़ को खोजें ताकि PPT, PPTX, और ODP स्लाइड फ़ॉर्मैट्स को कस्टमाइज़ किया जा सके—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

Normal view में तीन कंटेंट क्षेत्र होते हैं: स्वयं स्लाइड, एक साइड कंटेंट रीजन, और एक बॉटम कंटेंट रीजन। विभिन्न कंटेंट क्षेत्रों की पोजिशनिंग से संबंधित प्रॉपर्टीज़। यह जानकारी एप्लिकेशन को उसका view state फ़ाइल में सहेजने की अनुमति देती है, जिससे पुनः खोलने पर view उसी स्थिति में होता है जैसा कि प्रस्तुति को आखिरी बार सहेजा गया था।

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) को normal view प्रॉपर्टीज़ तक पहुँच प्रदान करने के लिए जोड़ा गया है।

[INormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfaces और उनके उत्पन्न, [SplitterBarStateType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType) enum को जोड़ा गया है।

## **INormalViewProperties के बारे में**

Normal view प्रॉपर्टीज़ का प्रतिनिधित्व करता है।

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) यह निर्दिष्ट करता है कि क्या एप्लिकेशन को आइकन दिखाने चाहिए जब सामान्य दृश्य मोड के किसी भी कंटेंट रीजन में आउटलाइन कंटेंट प्रदर्शित किया जा रहा हो।

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्धारित करता है कि साइड रीजन पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर न्यूनतम स्थिति में स्नैप होना चाहिए या नहीं।

Property [getPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) यह निर्दिष्ट करता है कि उपयोगकर्ता मानक normal view के तीन कंटेंट क्षेत्रों की बजाय पूर्ण-खिड़की एकल‑कंटेंट रीजन देखना पसंद करता है या नहीं। यदि सक्षम किया गया है, तो एप्लिकेशन पूरे विंडो में इन क्षेत्रों में से किसी एक को प्रदर्शित कर सकता है।

Methods [getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) यह निर्धारित करता है कि Horizontal या Vertical स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक Horizontal स्प्लिटर बार स्लाइड को नीचे की कंटेंट रीजन से अलग करता है, जबकि Vertical स्प्लिटर बार स्लाइड को साइड कंटेंट रीजन से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored)।

Methods [getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) यह दर्शाते हैं कि Normal view में टॉप या साइड स्लाइड रीजन का आकार क्या होगा, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) मान [getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) पर लागू हो।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

यह निर्दिष्ट करता है कि Normal view में स्लाइड रीजन (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) का चाइल्ड हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का चाइल्ड हो) का आकार क्या होगा, जब रीजन का आकार वैरिएबल (न तो न्यूनतम और न ही अधिकतम) हो।

Method [getDimensionSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) स्लाइड रीजन (restoredTop का चाइल्ड होने पर चौड़ाई, restoredLeft का चाइल्ड होने पर ऊँचाई) का आकार निर्धारित करता है।

Method [getAutoAdjust](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) यह निर्धारित करता है कि साइड कंटेंट रीजन का आकार नई विंडो आकार के अनुसार बदलते समय समायोजित होना चाहिए या नहीं।

नीचे दिया गया उदाहरण दर्शाता है कि आप प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) प्रॉपर्टीज़ तक कैसे पहुँच सकते हैं।

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

Aspose.Slides for Android via Java अब प्रस्तुति के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है, ताकि जब प्रस्तुति खोली जाए, ज़ूम पहले से ही सेट हो। यह [ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस टॉपिक में, हम एक उदाहरण के साथ देखेंगे कि कैसे [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) के [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) को सेट किया जाता है।

{{% /alert %}} 

View properties सेट करने के लिए नीचे दिए गए कदमों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास की एक इंस्टेंस बनाएँ।
1. उस [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  
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

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग-अलग view सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), न कि सेक्शन‑वार, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब यह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग view स्थिति पहले से परिभाषित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और सभी के साथ साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता की प्राथमिकताओं को मान सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट view प्रॉपर्टीज़ रखती है।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों, ताकि नई प्रस्तुतियों को समान तरीके से खोला जा सके?**

हाँ। चूँकि [view properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एंबेड कर सकते हैं और नई दस्तावेज़ उसी प्रारम्भिक view कॉन्फ़िगरेशन के साथ बना सकते हैं।