---
title: Java में प्रस्तुति दृश्य गुणों को प्राप्त और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/java/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- वर्टिकल स्प्लिटर को स्नैप करें
- एकल दृश्य
- बार स्थिति
- आकार आयाम
- स्वयंचालित समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के दृश्य गुणों की खोज करें ताकि आप PPT, PPTX और ODP स्लाइड्स के स्वरूप को अनुकूलित कर सकें—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और एक निचला सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को उसकी दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि जब पुनः खोलें तो दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

विधि [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) को जोड़ा गया है ताकि प्रस्तुति के सामान्य दृश्य गुणों तक पहुँच प्रदान की जा सके।

इंटरफ़ेस [INormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties) और उनके उत्पन्न, [SplitterBarStateType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType) एन्‍युम को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

विधियाँ [getShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) यह निर्दिष्ट करती हैं कि क्या एप्लिकेशन को रूपरेखा सामग्री को सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में प्रदर्शित करते समय आइकन दिखाने चाहिए।

विधियाँ [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्दिष्ट करती हैं कि जब साइड क्षेत्र पर्याप्त छोटा हो तो लंबवत स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

गुण [getPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) यह निर्धारित करता है कि उपयोगकर्ता तीन सामग्री क्षेत्रों वाले मानक सामान्य दृश्य की बजाय पूरे विंडो में एकल‑सामग्री क्षेत्र देखना चाहتا है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन विंडो में किसी एक सामग्री क्षेत्र को पूरे विंडो में प्रदर्शित करने का चयन कर सकता है।

विधियाँ [getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) यह निर्दिष्ट करती हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे की सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लитер बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored).

विधियाँ [getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार निर्धारित करती हैं, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored) मान को [getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) पर लागू किया जाता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) का उप‑तत्व हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का उप‑तत्व हो) का आकार निर्दिष्ट करता है, जब क्षेत्र का आकार बदलता हुआ पुनर्स्थापित आकार हो (न तो न्यूनतम और न ही अधिकतम)।

विधि [getDimensionSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र का आकार निर्दिष्ट करती है (चौड़ाई जब restoredTop का उप‑तत्व हो, ऊँचाई जब restoredLeft का उप‑तत्व हो)।

विधि [getAutoAdjust](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) यह निर्धारित करती है कि जब एप्लिकेशन में दृश्य समाहित करने वाले विंडो को पुनः आकार दिया जाता है तो साइड सामग्री क्षेत्र का आकार नए आकार की भरपाई करे या नहीं।

नीचे एक उदाहरण दिया गया है जो दर्शाता है कि आप प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुँच सकते हैं।

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

## **डिफ़ॉल्ट जूम मान सेट करें**

{{% alert color="info" %}} 

Aspose.Slides for Java अब प्रस्तुति के लिए डिफ़ॉल्ट जूम मान सेट करने का समर्थन करता है ताकि जब प्रस्तुति खोली जाए, जूम पहले से ही सेट हो। यह प्रस्तुति की [ViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि कैसे [View Properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) में [Aspose.Slides](/slides/hi/) के साथ सेट किया जाता है।

{{% /alert %}} 

दृश्य गुणों को सेट करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) का [View Properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) सेट करें।
1. प्रेज़ेंटेशन को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।
   नीचे दिए गए उदाहरण में, हमने स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए जूम मान सेट किया है।

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

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं प्रस्तुति के विभिन्न अनुभागों के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?

[View settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), न कि प्रत्येक अनुभाग के लिए, इसलिए एकल पैरामीटर सेट जब दस्तावेज़ खुलता है तो पूरे दस्तावेज़ पर लागू होता है।

### क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य अवस्थाएँ पूर्वनिर्धारित कर सकता हूँ?

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल स्वयं एक सेट दृश्य गुणों को रखती है।

### क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ ताकि नई प्रस्तुतियों को उसी तरह खोला जा सके?

हाँ। क्योंकि [view properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और उसके माध्यम से नई दस्तावेज़ बना सकते हैं, जिसमें समान प्रारंभिक दृश्य कॉन्फ़िगरेशन होगा।