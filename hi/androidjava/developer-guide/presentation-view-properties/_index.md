---
title: Android पर प्रस्तुति व्यू प्रॉपर्टीज़ को प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/androidjava/presentation-view-properties/
keywords:
- व्यू प्रॉपर्टीज़
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकन
- वर्टिकल स्प्लिटर स्नैप
- सिंगल व्यू
- बार स्थिति
- डाइमेंशन आकार
- ऑटो एडजस्ट
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java व्यू प्रॉपर्टीज़ की खोज करें ताकि PPT, PPTX और ODP स्लाइड्स के फॉर्मेट को अनुकूलित किया जा सके—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित किया जा सके।"
---
## **परिचय**

Normal view में तीन कंटेंट क्षेत्रों होते हैं: स्वयं स्लाइड, साइड कंटेंट क्षेत्र, और नीचे का कंटेंट क्षेत्र। विभिन्न कंटेंट क्षेत्रों के स्थितियों से संबंधित प्रॉपर्टीज़। यह जानकारी एप्लिकेशन को उसकी view state को फ़ाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर view उसी स्थिति में हो जैसा कि प्रस्तुति को आखिरी बार सहेजा गया था।

Method[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) को जोड़ा गया है ताकि प्रस्तुति के normal view प्रॉपर्टीज़ तक पहुंच मिल सके।

[INormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties) इंटरफ़ेस और उनके वंशज, [SplitterBarStateType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType) enum को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

Method[getShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) निर्दिष्ट करता है कि normal view मोड में किसी भी कंटेंट क्षेत्र में outline कंटेंट प्रदर्शित करते समय एप्लिकेशन को आइकन दिखाने चाहिए या नहीं।

Method[getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) निर्दिष्ट करता है कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

Property[getPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) निर्दिष्ट करता है कि उपयोगकर्ता तीन कंटेंट क्षेत्रों वाले मानक normal view की बजाय पूर्ण विंडो में एक सिंगल‑कंटेंट क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में किसी एक कंटेंट क्षेत्र को प्रदर्शित कर सकता है।

Method[getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) निर्दिष्ट करता है कि horizontal या vertical splitter बार किस स्थिति में दिखाया जाना चाहिए। एक horizontal splitter बार स्लाइड को नीचे के कंटेंट क्षेत्र से अलग करता है, जबकि vertical splitter बार स्लाइड को साइड कंटेंट क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored)।

Method[getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) निर्दिष्ट करता है कि normal view के शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) मान [getVerticalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) पर लागू होता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब क्षेत्र का आकार बदलता रहता है (न तो न्यूनतम न ही अधिकतम) तो normal view के स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) का चाइल्ड हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का चाइल्ड हो) का आकार निर्दिष्ट करता है।

Method[getDimensionSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र (restoredTop का चाइल्ड होने पर चौड़ाई, restoredLeft का चाइल्ड होने पर ऊँचाई) का आकार निर्धारित करता है।

Method[getAutoAdjust](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) निर्धारित करता है कि विंडो के आकार बदलने पर साइड कंटेंट क्षेत्र का आकार नया आकार समायोजित करने के लिये बदलना चाहिए या नहीं।

नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) प्रॉपर्टीज़ तक कैसे पहुंच सकते हैं।

```java
import com.aspose.slides.*;

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

## **डिफॉल्ट ज़ूम मान सेट करें**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java अब प्रस्तुति के लिए डिफॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि प्रस्तुति खोलते समय ज़ूम पहले से सेट हो। इसे प्रस्तुति की [ViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) तथा [getNotesViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिक रूप से सेट किया जा सकता है। इस टॉपिक में हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) कैसे सेट की जाती हैं।

{{% /alert %}} 

व्यू प्रॉपर्टीज़ सेट करने के लिए नीचे दिए गए चरणों को पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ViewProperties) सेट करें।
1. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फाइल के रूप में लिखें। नीचे दिए गए उदाहरण में हमने स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // प्रस्तुति की व्यू प्रॉपर्टीज़ सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड व्यू के लिये प्रतिशत में ज़ूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स व्यू के लिये प्रतिशत में ज़ूम मान

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) का उपयोग करके प्रस्तुति‑व्यापी व्यू सेटिंग्स तक पहुंचें। [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) और [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) मेथड्स मूल संपादन ग्रिड की अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग को पॉइंट में निर्धारित किया जाता है, जहाँ 72 पॉइंट एक इंच के बराबर होते हैं। API दस्तावेज़ में आवश्यकतानुसार सकारात्मक मान का प्रयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई‑इंच अंतराल सेट करता है, और परिणाम सहेजता है।

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

ग्रिड [drawing guides](/slides/hi/androidjava/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्राइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या वर्टिकल संरेखण रेखाएँ होती हैं। ड्राइंग गाइड्स को जोड़ने, हटाने या साफ़ करने से ग्रिड स्पेसिंग नहीं बदलती।

ग्रिड और ड्राइंग गाइड्स दोनों ही संपादन सहायता हैं। वे PDF, इमेज, SVG या स्लाइड शो में स्लाइड कंटेंट के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को संग्रहीत करना यह गारंटी नहीं देता कि कोई एडिटर ग्रिड दिखाएगा: इसकी दृश्यता व्यूअर या एडिटर की प्राथमिकताओं पर भी निर्भर करती है।

## **प्रेजेंटेशन खोलते समय टिप्पणी दिखाएँ या छुपाएँ**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) का उपयोग करके प्रस्तुति‑व्यापी व्यू सेटिंग्स तक पहुंचें। [IViewProperties.getShowComments](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) और [IViewProperties.setShowComments](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) का उपयोग करके यह पढ़ें या बदलें कि प्रस्तुति PowerPoint या अन्य संगत एडिटर में खुलते समय टिप्पणियाँ दिखानी चाहिए या नहीं।

यह सेटिंग केवल संग्रहीत व्यू प्राथमिकता को नियंत्रित करती है। यह टिप्पणियों को जोड़ती, हटाती, संपादित या हल नहीं करती। टिप्पणियों को छुपाने से उनका कंटेंट, लेखक, स्थान, उत्तर और स्थिति संरक्षित रहती है। टिप्पणियों में परिवर्तन के लिए देखें [Presentation Comments](/slides/hi/androidjava/presentation-comments/)।

निम्न उदाहरण के लिये एक मौजूदा `comments.pptx` चाहिए जिसमें टिप्पणियाँ हों। यह वर्तमान दृश्यता सेटिंग प्रिंट करता है, टिप्पणियों को छुपाने का अनुरोध करता है, और कोई टिप्पणी हटाए बिना नया PPTX सहेजता है। यह [IViewProperties.setLastView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) को [ViewType.SlideView](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewtype/#SlideView) के साथ उपयोग करता है ताकि प्रारंभिक एडिटिंग व्यू को टिप्पणी दृश्यता के साथ कॉन्फ़िगर किया जा सके।

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणियाँ PDF, HTML, इमेज, नोट्स या हैंडआउट निर्यात में शामिल होंगी या नहीं। निर्यात‑विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**ग्रिड को पुनः खोलने के बाद क्यों नहीं दिख रहा है?**  
फ़ाइल ग्रिड स्पेसिंग संग्रहीत करती है, लेकिन एडिटर नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। एडिटर की ग्रिड दृश्यता सेटिंग को जाँचें।

**ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है क्या?**  
नहीं। ड्राइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न अनुभागों के लिए अलग‑अलग व्यू सेटिंग्स निर्धारित कर सकता हूँ?**  
[View settings](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), न कि प्रति‑सेक्शन। इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब वह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिये अलग‑अलग व्यू स्थितियाँ पूर्वनिर्धारित कर सकता हूँ?**  
नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और सभी उपयोगकर्ताओं के लिये समान होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को सम्मानित कर सकते हैं, पर फ़ाइल स्वयं केवल एक सेट व्यू प्रॉपर्टीज़ रखती है।

**क्या मैं ऐसे टेम्प्लेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों, ताकि नई प्रस्तुतियाँ समान ढंग से खुलें?**  
हाँ। चूँकि [view properties](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्प्लेट में एम्बेड कर सकते हैं और नई दस्तावेज़ उसी प्रारम्भिक व्यू कॉन्फ़िगरेशन के साथ बना सकते हैं।