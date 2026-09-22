---
title: Android पर प्रस्तुति दृश्य गुण पुनः प्राप्त और अपडेट करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/androidjava/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- वर्टिकल स्प्लिटर स्नैप
- एकल दृश्य
- बार स्थिति
- आकार आयाम
- स्वतः समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java दृश्य गुणों को खोजें ताकि PPT, PPTX, और ODP स्लाइडों के प्रारूप को अनुकूलित किया जा सके—लेआउट, ज़ूम स्तर, और प्रदर्शन सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और एक नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों की स्थिति से संबंधित गुण। यह जानकारी एप्लिकेशन को अपने दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, जिससे पुनः खोलने पर दृश्य उसी स्थिति में रहता है जैसा कि प्रस्तुति को अंतिम बार सहेजा गया था।

विधि [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) ने प्रस्तुति के सामान्य दृश्य गुणों तक पहुँच प्रदान करने के लिए जोड़ा गया है।

[INormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties) इंटरफ़ेस और उनके विनिर्देश, [SplitterBarStateType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType) enum को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

विधि [getShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) निर्धारित करता है कि सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री दिखाते समय एप्लिकेशन को आइकन दिखाने चाहिए या नहीं।

विधि [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्दिष्ट करता है कि जब साइड क्षेत्र पर्याप्त छोटा हो तो लंबवत स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

प्रॉपर्टी [getPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) यह निर्धारित करती है कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य की बजाए पूरी विंडो में एक ही सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरी विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित कर सकता है।

विधि [getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) यह बताती हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे की सामग्री क्षेत्र से अलग करता है, जबकि लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभव मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored)।

विधि [getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) यह निर्दिष्ट करती हैं कि सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या हो, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) मान को [getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) पर लागू किया जाता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य में स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) का चाइल्ड हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का चाइल्ड हो) का आकार निर्धारित करता है, जब क्षेत्र का आकार परिवर्तनशील पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) हो।

विधि [getDimensionSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) यह निर्दिष्ट करती है कि स्लाइड क्षेत्र (चौड़ाई जब restoredTop का चाइल्ड हो, ऊँचाई जब restoredLeft का चाइल्ड हो) का आकार क्या है।

विधि [getAutoAdjust](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) यह निर्दिष्ट करती है कि साइड सामग्री क्षेत्र का आकार नई विंडो आकार के अनुसार समायोजित होना चाहिए या नहीं, जब एप्लिकेशन के भीतर दृश्य वाली विंडो का आकार बदलता है।

नीचे दिया गया उदाहरण दिखाता है कि आप कैसे प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक पहुँच सकते हैं।

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

Aspose.Slides for Android via Java अब प्रस्तुति के डिफ़ॉल्ट ज़ूम मान को सेट करने का समर्थन करता है, ताकि प्रस्तुति खोलते समय ज़ूम पहले से सेट हो। यह [ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) कैसे सेट करें।

{{% /alert %}} 

व्यू गुण सेट करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें। नीचे दिए गए उदाहरण में हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // प्रस्तुति के दृश्य गुण सेट कर रहे हैं
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड व्यू के लिए प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स व्यू के लिए प्रतिशत में ज़ूम मान 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

प्रस्तुति‑व्यापी दृश्य सेटिंग्स तक पहुँचने के लिए [Presentation.getViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) का उपयोग करें। [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) और [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) विधियां आधारभूत संपादन ग्रिड की अंतराल को पढ़ती या बदलती हैं। यह सेटिंग संपूर्ण प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ में अनुरोधित अनुसार सकारात्मक मान उपयोग करें।

निम्न उदाहरण मौजूदा `demo.pptx` को खोलता है, वर्तमान ग्रिड स्पेसिंग को प्रिंट करता है, चौथाई‑इंच का अंतराल सेट करता है, और परिणाम सहेजता है।

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ग्रिड [ड्रॉइंग गाइड्स](/slides/hi/androidjava/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्रॉइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। गाइड्स जोड़ने, हटाने या स्थानांतरित करने से ग्रिड स्पेसिंग नहीं बदलती।

ग्रिड और ड्रॉइंग गाइड दोनों ही संपादन के सहायक होते हैं। वे PDF, इमेज, SVG या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को संग्रहीत करने से यह गारंटी नहीं मिलती कि एडिटर ग्रिड दिखाएगा: इसकी दृश्यता दर्शक या एडिटर की प्राथमिकताओं पर भी निर्भर करती है।

## **FAQ**

**प्रस्तुति पुनः खोलने के बाद ग्रिड क्यों नहीं दिख रहा है?**

फ़ाइल ग्रिड स्पेसिंग संग्रहीत करती है, लेकिन एडिटर यह नियंत्रित करता है कि ग्रिड प्रदर्शित किया जाए या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग्स जांचें।

**ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है क्या?**

नहीं। ड्रॉइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न अनुभागों के लिए अलग‑अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर परिभाषित होती हैं ([Normal View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), न कि प्रत्येक सेक्शन के लिए, इसलिए जब दस्तावेज़ खुलता है तो एक ही पैरामीटर सेट सम्पूर्ण दस्तावेज़ पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग दृश्य स्थिति पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और सभी के साथ साझा की जाती हैं। दर्शक अनुप्रयोग उपयोगकर्ता प्राथमिकताओं को सम्मानित कर सकते हैं, लेकिन फ़ाइल में केवल एक ही सेट दृश्य गुण होते हैं।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुतियां उसी तरह खुलें?**

हां। क्योंकि [view properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और नई दस्तावेज़ उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ बना सकते हैं।