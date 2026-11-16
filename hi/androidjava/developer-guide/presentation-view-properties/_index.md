---
title: एंड्रॉइड पर प्रस्तुति दृश्य गुणों को प्राप्त करें और अद्यतन करें
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
- परिमाण आकार
- स्वयं समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में सामान्य दृश्य लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड स्पेसिंग, और टिप्पणी दृश्यता को कॉन्फ़िगर करने के लिए जावा के माध्यम से Android के लिए Aspose.Slides का उपयोग करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड थंबनेल या रूपरेखा के लिए एक साइड पेन और नीचे नोट्स पेन के बीच प्रदर्शित होती है। Aspose.Slides for Android via Java प्रस्तुति की सहेजी गई संपादन प्राथमिकताओं को [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) के माध्यम से उजागर करता है। इनमें पेन लेआउट, ज़ूम स्तर, ग्रिड स्पेसिंग और टिप्पणी दृश्यता शामिल हैं।

## **INormalViewProperties के बारे में**

इसे एक्सेस करने के लिए [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) का उपयोग करके [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/) इंटरफ़ेस प्राप्त करें। [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) यह नियंत्रित करता है कि रूपरेखा में स्लाइड शीर्षकों के बगल में आइकन दिखें या नहीं। [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) उपयोगकर्ता द्वारा साइड पेन को संकीर्ण करने पर इसे न्यूनतम स्थिति में स्नैप करने देता है। [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) पूर्ण विंडो में एक पेन प्रदर्शित करने की प्राथमिकता दर्शाता है।

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) साइड पेन और स्लाइड के बीच विभाजक को नियंत्रित करता है। [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) नोट्स पेन के ऊपर विभाजक को नियंत्रित करता है। दोनों [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) के मान `Minimized`, `Maximized` या `Restored` स्वीकार करते हैं।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब कोई विभाजक पुनर्स्थापित किया जाता है, तो [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) साइड पेन का सहेचा आकार प्रदान करता है और [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) ऊपर के स्लाइड क्षेत्र का सहेचा आकार प्रदान करता है। दोनों [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/) को उजागर करते हैं। इसका [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) मेथड 0 से 100 प्रतिशत तक का मान स्वीकार करता है, और [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) नियंत्रित करता है कि विंडो आकार बदलने पर संपादक आकार को समायोजित करे या नहीं।

यह उदाहरण एक मौजूदा प्रस्तुति को अपडेट करता है। यह क्षैतिज विभाजक को पुनर्स्थापित करता है, [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) द्वारा प्राप्त आकार को 80% पर सेट करता है और स्वतः समायोजन सक्षम करता है, तथा लंबवत विभाजक को अधिकतम करता है। यह [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) को भी कॉल करता है ताकि रूपरेखा दृश्य में आइकन दिखाई दें।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) और [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) संपादक के लिए स्वतंत्र ज़ूम सेटिंग्स संग्रहीत करते हैं। ये सेटिंग्स स्लाइड आयाम, स्लाइड‑शो प्लेबैक या छवि निर्यात रिज़ॉल्यूशन को प्रभावित नहीं करतीं।

यह उदाहरण एक मौजूदा प्रस्तुति खोलता है और स्लाइड को संपादन विंडो में फिट करने के लिए [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) को कॉल करता है। नोट्स पेज के लिए, यह स्वतः स्केलिंग को अक्षम करता है और निश्चित 80% ज़ूम सेट करने के लिए [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) को कॉल करता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ग्रिड स्पेसिंग सेट करें**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) प्रस्तुति में सभी संपादन ग्रिड लाइनों के बीच की दूरी को सेट करता है। यह पॉइंट्स में एक सकारात्मक मान लेता है, जहाँ 1 इंच में 72 पॉइंट होते हैं। यह उदाहरण मौजूदा प्रस्तुति में वर्तमान स्पेसिंग को प्रदर्शित करता है और अंतराल को 18 पॉइंट सेट करके एक चौथाई‑इंच ग्रिड सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ग्रिड एक निश्चित अंतराल पर दोहराता है। [Drawing guides](/slides/hi/androidjava/drawing-guides/) व्यक्तिगत क्षैतिज या लंबवत स्थितियों को चिह्नित करते हैं। दोनों संपादन सहायता हैं और केवल उन संपादकों में दिखाई देते हैं जो इन्हें प्रदर्शित करते हैं। स्लाइडशो और PDF, छवियों या SVG निर्यात में इन्हें छोड़ दिया जाता है।

## **प्रेजेंटेशन खोलते समय टिप्पणियों को दिखाएँ या छिपाएँ**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) एक ऐसी प्राथमिकता सहेजता है जिसका उपयोग संगत संपादक प्रस्तुति खोलते समय करते हैं। टिप्पणियों वाली मौजूदा प्रस्तुति के लिए, यह उदाहरण वर्तमान सेटिंग को प्रदर्शित करता है और टिप्पणियों को छिपा कर एक प्रति सहेजता है। यह [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) को [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) के साथ भी कॉल करता है ताकि प्रतिलिपि स्लाइड व्यू में खुले।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

टिप्पणियों को छिपाने से उनका पाठ, लेखक, स्थितियां, उत्तर और स्थितियां संरक्षित रहती हैं। टिप्पणियों को स्वयं बदलने के लिए, देखें [Presentation Comments](/slides/hi/androidjava/presentation-comments/)। निर्यात सेटिंग्स नियंत्रित करती हैं कि टिप्पणियां PDF, HTML, छवियों, नोट्स या हैंडआउट में दिखें या नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मैं प्रस्तुति को फिर खोलता हूँ तो ग्रिड क्यों छिपा रहा है?**  
प्रस्तुति ग्रिड अंतराल को संग्रहीत करती है। ग्रिड देखने के लिए, संपादक में ग्रिड दृश्यता सक्षम करें।

**क्या ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**  
नहीं। गाइड जोड़ने, स्थानांतरित करने या हटाने से ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या प्रस्तुति के विभिन्न भागों में अलग-अलग दृश्य सेटिंग्स हो सकती हैं?**  
नहीं। [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) पूरी प्रस्तुति पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य सेटिंग्स सहेज सकता हूँ?**  
फ़ाइल सभी उपयोगकर्ताओं के लिए एक ही सेट दृश्य गुण संग्रहीत करती है। एक संपादक उपयोगकर्ता की स्थानीय प्राथमिकताएँ भी लागू कर सकता है।

**क्या मैं टेम्प्लेट में दृश्य सेटिंग्स सहेज सकता हूँ?**  
हां। टेम्प्लेट से बनाई गई प्रस्तुतियों में उसके सहेजे गए दृश्य सेटिंग्स विरासत में मिलती हैं।