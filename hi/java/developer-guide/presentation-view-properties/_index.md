---
title: Java में प्रस्तुति व्यू गुण प्राप्त करें और अपडेट करें
linktitle: व्यू गुण
type: docs
weight: 80
url: /hi/java/presentation-view-properties/
keywords:
- व्यू गुण
- सामान्य व्यू
- रूपरेखा सामग्री
- रूपरेखा आइकन
- स्नैप वर्टिकल स्प्लिटर
- सिंगल व्यू
- बार स्थिति
- आयाम आकार
- ऑटो एडजस्ट
- डिफॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के व्यू गुणों को खोजें ताकि आप PPT, PPTX और ODP स्लाइड्स के स्वरूप को अनुकूलित कर सकें—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य तीन सामग्री क्षेत्रों से बना होता है: स्वयं स्लाइड, एक साइड सामग्री क्षेत्र, और एक नीचे का सामग्री क्षेत्र। विभिन्न सामग्री क्षेत्रों के स्थिति निर्धारण से संबंधित गुण। यह जानकारी एप्लिकेशन को दृश्य स्थिति को फ़ाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर दृश्य वही स्थिति में हो जैसा कि प्रस्तुति अंतिम बार सहेजी गई थी।

विधि[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) को सामान्य दृश्य गुणों तक पहुंच प्रदान करने के लिए जोड़ा गया है।

[INormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties) इंटरफ़ेस और उनके वंशज, [SplitterBarStateType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType) Enum को जोड़ा गया है।

## **INormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

विधि[getShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) यह निर्दिष्ट करते हैं कि सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय एप्लिकेशन को आइकन दिखाने चाहिए या नहीं।

विधि[getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) यह निर्दिष्ट करते हैं कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

गुण[getPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) और [setPreferSingleView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) यह निर्दिष्ट करते हैं कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य के बजाय पूर्ण-विंडो एकल-समग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित कर सकता है।

विधि[getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) यह निर्धारित करते हैं कि क्षैतिज या वर्टिकल स्प्लिटर बार किस स्थिति में प्रदर्शित होना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे की सामग्री क्षेत्र से अलग करती है, वर्टिकल स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करती है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored)।

विधि[getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) और [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) सामान्य दृश्य के टॉप या साइड स्लाइड क्षेत्र के आकार को निर्दिष्ट करते हैं, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SplitterBarStateType#Restored) मान को [getVerticalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) के लिए लागू किया जाता है।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

सामान्य दृश्य के स्लाइड क्षेत्र (चौड़ाई जब [getRestoredTop](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) का बच्चा हो, ऊँचाई जब [getRestoredLeft](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) का बच्चा हो) के आकार को निर्दिष्ट करता है, जब क्षेत्र का आकार परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम न ही अधिकतम) हो।

विधि[getDimensionSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) स्लाइड क्षेत्र के आकार (पुनर्स्थापित टॉप का बच्चा होने पर चौड़ाई, पुनर्स्थापित लेफ़्ट का बच्चा होने पर ऊँचाई) को निर्दिष्ट करता है।

विधि[getAutoAdjust](https://reference.aspose.com/slides/hi/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) यह निर्दिष्ट करता है कि साइड सामग्री क्षेत्र का आकार नई विंडो आकार के अनुसार समायोजित होना चाहिए या नहीं, जब एप्लिकेशन के भीतर दृश्य को रखने वाली विंडो को पुनः आकार दिया जाता है।

नीचे दिया गया उदाहरण दिखाता है कि आप प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) गुणों तक कैसे पहुँच सकते हैं।

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // प्रस्तुति के व्यू गुणों को पुनर्स्थापित करें
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

Aspose.Slides for Java अब प्रस्तुति के लिए डिफॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि प्रस्तुति खोलते समय ज़ूम पहले से ही सेट हो। यह [ViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) तथा [getNotesViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) को प्रोग्रामेटिकली सेट किया जा सकता है। इस विषय में हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) कैसे सेट करें।

{{% /alert %}} 

दृश्य गुण सेट करने के लिए नीचे दी गई चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का इंस्टेंसेस बनाएं।  
2. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) की [View Properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ViewProperties) सेट करें।  
3. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।  
   नीचे दिए गए उदाहरण में हमने स्लाइड व्यू तथा नोट्स व्यू दोनों के लिए ज़ूम मान सेट किया है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // प्रस्तुति के दृश्य गुण सेट करना
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // स्लाइड दृश्य के लिए प्रतिशत में जूम मान
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // नोट्स दृश्य के लिए प्रतिशत में जूम मान 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) का उपयोग करके प्रस्तुति-व्यापी दृश्य सेटिंग्स तक पहुंच प्राप्त करें। [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iviewproperties/#getGridSpacing--) और [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) मेथड्स मूल संपादन ग्रिड के अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, व्यक्तिगत स्लाइड पर नहीं। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट होती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। API दस्तावेज़ के अनुसार एक सकारात्मक मान उपयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी मौजूदा ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई इंच अंतराल सेट करता है, और परिणाम सहेजता है।

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

ग्रिड [ड्रॉइंग गाइड्स](/slides/hi/java/drawing-guides/) से अलग है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्रॉइंग गाइड्स स्वतंत्र रूप से स्थित क्षैतिज या वर्टिकल संरेखण रेखाएँ हैं। गाइड्स को जोड़ना, हटाना या साफ़ करना ग्रिड स्पेसिंग को नहीं बदलता।

ग्रिड और ड्रॉइंग गाइड्स दोनों संपादन सहायता हैं। इन्हें PDF, इमेज, SVG, या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं किया जाता। ग्रिड स्पेसिंग को संग्रहीत करना यह गारंटी नहीं देता कि संपादक ग्रिड दिखाएगा: इसकी दृश्यता दर्शक या संपादक की प्राथमिकताओं पर भी निर्भर करती है।

## **प्रस्तुति खोलते समय टिप्पणी दिखाएं या छिपाएं**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) का उपयोग करके प्रस्तुति-व्यापी दृश्य सेटिंग्स तक पहुंच प्राप्त करें। [IViewProperties.getShowComments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iviewproperties/#getShowComments--) और [IViewProperties.setShowComments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) का उपयोग करके यह पढ़ें या बदलें कि प्रस्तुति PowerPoint या किसी अन्य संगत संपादक में खोलते समय टिप्पणियां दिखानी हैं या नहीं।

यह सेटिंग केवल संग्रहीत दृश्य प्राथमिकता को नियंत्रित करती है। यह टिप्पणियों को जोड़ती, हटाती, संपादित करती या हल नहीं करती। टिप्पणियों को छिपाने से उनकी सामग्री, लेखक, स्थितियों, उत्तरों और स्थितियों का संरक्षण रहता है। टिप्पणियों में परिवर्तन करने वाले कार्यों के लिए देखें [Presentation Comments](/slides/hi/java/presentation-comments/)।

निम्न उदाहरण के लिए एक मौजूदा `comments.pptx` की आवश्यकता है जिसमें टिप्पणियां हों। यह वर्तमान दृश्यता सेटिंग प्रिंट करता है, टिप्पणियों को छिपाने का अनुरोध करता है, और बिना किसी टिप्पणी को हटाए नया PPTX सहेजता है। यह [IViewProperties.setLastView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iviewproperties/#setLastView-int-) को [ViewType.SlideView](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewtype/#SlideView) के साथ उपयोग करके प्रारंभिक संपादन दृश्य को टिप्पणी दृश्यता के साथ कॉन्फ़िगर करता है।

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

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणियां PDF, HTML, इमेज, नोट्स या हैंडआउट निर्यात में शामिल हैं या नहीं। निर्यात‑विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **FAQ**

**प्रस्तुति को पुनः खोलने के बाद ग्रिड क्यों नहीं दिखता?**

फ़ाइल ग्रिड स्पेसिंग संग्रहीत करती है, लेकिन संपादक नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। संपादक की ग्रिड दृश्यता सेटिंग्स जांचें।

**ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है क्या?**

नहीं। ड्रॉइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शनों के लिए अलग‑अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/hi/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), सेक्शन‑वार नहीं, इसलिए जब दस्तावेज़ खुलता है तो सभी भागों पर एक ही पैरामीटर सेट लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग पूर्वनिर्धारित दृश्य अवस्थाएँ रख सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। दर्शक एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को सम्मानित कर सकते हैं, पर फ़ाइल में केवल एक सेट दृश्य गुण होते हैं।

**क्या मैं एक टेम्प्लेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुतियों का खुलना समान हो?**

हाँ। क्योंकि [view properties](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getViewProperties--) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें टेम्प्लेट में एम्बेड कर सकते हैं और उससे नई दस्तावेज़ बनाते समय समान प्रारंभिक दृश्य कॉन्फ़िगरेशन प्राप्त कर सकते हैं।