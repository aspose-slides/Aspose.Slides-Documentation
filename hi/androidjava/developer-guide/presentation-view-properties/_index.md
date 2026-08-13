---
title: Android पर प्रस्तुति दृश्य गुणों को प्राप्त करें और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/androidjava/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकॉन्स
- वर्टिकल स्प्लिटर को स्नैप करें
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- स्वतः समायोजित
- डिफ़ॉल्ट जूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के दृश्य गुणों को खोजें ताकि आप PPT, PPTX, और ODP स्लाइड फ़ॉर्मेट को अनुकूलित कर सकें—लेआउट, जूम स्तर, और प्रदर्शन सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और एक नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थितियों से संबंधित गुण। यह जानकारी एप्लिकेशन को दृश्य की स्थिति फाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

पद्धति [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) को प्रस्तुति के सामान्य दृश्य गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है।

[INormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties) इंटरफ़ेस और उनके उत्तराधिकारियों, [SplitterBarStateType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType) एनम जोड़े गए हैं।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

पद्धति [getShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) निर्धारित करती हैं कि क्या एप्लिकेशन को सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय आइकॉन्स दिखाने चाहिए।

पद्धति [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) निर्धारित करती हैं कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

गुण [getPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) निर्धारित करता है कि उपयोगकर्ता तीन सामग्री क्षेत्रों वाले मानक सामान्य दृश्य की तुलना में पूर्ण-खिड़की एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया जाता है, तो एप्लिकेशन पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित करने का चयन कर सकता है।

पद्धति [getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) यह निर्दिष्ट करती हैं कि क्षैतिज या वर्टिकल स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे के सामग्री क्षेत्र से अलग करता है, वर्टिकल स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

पद्धति [getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र के आकार को निर्दिष्ट करती हैं, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) मान [getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) पर लागू किया जाता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) का चाइल्ड हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का चाइल्ड हो) के आकार को निर्दिष्ट करता है, जब क्षेत्र का आकार परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम न ही अधिकतम) हो।

पद्धति [getDimensionSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र के आकार (चौड़ाई जब यह restoredTop का चाइल्ड हो, ऊँचाई जब यह restoredLeft का चाइल्ड हो) को निर्दिष्ट करती है।

पद्धति [getAutoAdjust](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) यह निर्धारित करती है कि एप्लिकेशन के भीतर दृश्य वाली विंडो को रिसाइज़ करने पर साइड सामग्री क्षेत्र का आकार नई आकार के लिए समायोजित होना चाहिए या नहीं।

नीचे एक उदाहरण दिया गया है जो दर्शाता है कि आप प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुँच सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // प्रस्तुति के दृश्य गुणों को पुनर्स्थापित करें
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```
## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java अब प्रस्तुतियों के लिए डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है, जिससे प्रस्तुति खोलते समय ज़ूम पहले से सेट हो जाता है। इसे प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) तथा [getNotesViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिकली सेट किया जा सकता है। इस विषय में, हम उदाहरण के साथ दिखाएंगे कि कैसे [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) को [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) के लिए [Aspose.Slides](/slides/hi/) में सेट किया जाए।

{{% /alert %}} 

दृश्य गुण सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग की इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें। नीचे दिए गए उदाहरण में, हमने स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट किया है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // प्रस्तुति के दृश्य गुण सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड दृश्य के लिए प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स दृश्य के लिए प्रतिशत में ज़ूम मान 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **बार-बार पूछे जाने वाले प्रश्न**

### क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?

दृश्य सेटिंग्स प्रस्तुति स्तर पर परिभाषित की जाती हैं ([Normal View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), न कि प्रत्येक सेक्शन में, इसलिए जब दस्तावेज़ खुलता है तो पूरे दस्तावेज़ पर एक ही पैरामीटर सेट लागू होता है।

### क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य स्थितियों को पूर्वनिर्धारित कर सकता हूँ?

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता की प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट दृश्य गुण रखती है।

### क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्प्लेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियां समान तरीके से खुलें?

हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्प्लेट में एम्बेड कर सकते हैं और उसी प्रारम्भिक दृश्य कॉन्फ़िगरेशन के साथ उससे नई दस्तावेज़ बना सकते हैं।