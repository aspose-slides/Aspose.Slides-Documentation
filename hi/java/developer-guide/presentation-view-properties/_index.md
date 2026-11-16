---
title: जावा में प्रस्तुति दृश्य गुण प्राप्त करें और अपडेट करें
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
- आयाम आकार
- स्वचालित समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में सामान्य दृश्य लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड अंतराल, और टिप्पणी दृश्यता को कॉन्फ़िगर करने के लिए Aspose.Slides for Java का उपयोग करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड नीचे नोट्स पैन और थंबनेल या रूपरेखा के लिए एक साइड पेन के बीच दिखाई देती है। Aspose.Slides for Java, [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) के माध्यम से प्रस्तुति की सहेजी गई संपादन प्राथमिकताएँ उपलब्ध कराता है। इनमें पेन लेआउट, ज़ूम स्तर, ग्रिड अंतराल, और टिप्पणी दृश्यता शामिल हैं।

## **INormalViewProperties के बारे में**

[ getNormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNormalViewProperties--) का उपयोग करके आप [INormalViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/) इंटरफ़ेस तक पहुँच सकते हैं। [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) निर्धारित करता है कि रूपरेखा में स्लाइड शीर्षकों के बगल में आइकन दिखाए जाएँ या नहीं। [setSnapVerticalSplitter](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) उपयोगकर्ता द्वारा साइड पेन को संकुचित करने पर उसे न्यूनतम स्थिति में स्नैप करने देता है। [setPreferSingleView](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) पूरे विंडो में केवल एक पेन प्रदर्शित करने की प्राथमिकता को दर्शाता है।

[setVerticalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) साइड पेन और स्लाइड के बीच विभाजक को नियंत्रित करता है। [setHorizontalBarState](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) नोट्स पेन के ऊपर विभाजक को नियंत्रित करता है। दोनों [SplitterBarStateType](https://reference.aspose.com/slides/java/com.aspose.slides/splitterbarstatetype/) के `Minimized`, `Maximized` या `Restored` मान स्वीकार करते हैं।

## **INormalViewProperties को पुनर्स्थापित करने के बारे में**

जब विभाजक पुनर्स्थापित किया जाता है, तो [getRestoredLeft](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) साइड पेन के सहेजे गए आकार को प्रदान करता है और [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) ऊपर की स्लाइड क्षेत्र के सहेजे गए आकार को। दोनों [INormalViewRestoredProperties](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/) को उजागर करते हैं। इसकी [setDimensionSize](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) विधि 0 से 100 तक प्रतिशत स्वीकार करती है, और [setAutoAdjust](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) निर्धारित करता है कि विंडो के आकार बदलने पर संपादक स्वचालित रूप से आकार समायोजित करे या नहीं।

यह उदाहरण मौजूदा प्रस्तुति को अपडेट करता है। यह क्षैतिज विभाजक को पुनर्स्थापित करता है, [getRestoredTop](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#getRestoredTop--) द्वारा लौटाए गए आकार को 80 % सेट करता है तथा स्वचालित समायोजन सक्षम करता है, और लंबवत विभाजक को अधिकतम करता है। यह रूपरेखा दृश्य में आइकन दिखाने के लिए [setShowOutlineIcons](https://reference.aspose.com/slides/java/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) को भी कॉल करता है।

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

[getSlideViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getSlideViewProperties--) और [getNotesViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#getNotesViewProperties--) संपादक के लिए स्वतंत्र ज़ूम सेटिंग्स संग्रहीत करते हैं। ये सेटिंग्स स्लाइड के आयाम, स्लाइड‑शो प्लेबैक, या छवि निर्यात रेज़ॉल्यूशन को प्रभावित नहीं करतीं।

यह उदाहरण मौजूदा प्रस्तुति को खोलता है और स्लाइड को संपादन विंडो में फिट करने के लिए [setVariableScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) को कॉल करता है। नोट्स पेज के लिए यह स्वचालित स्केलिंग को अक्षम करता है और स्थिर 80 % ज़ूम सेट करने के लिए [setScale](https://reference.aspose.com/slides/java/com.aspose.slides/icommonslideviewproperties/#setScale-int-) को कॉल करता है।

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

## **ग्रिड अंतराल सेट करें**

[setGridSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) प्रस्तुति के पूरे भाग में संपादन ग्रिड रेखाओं के बीच दूरी निर्धारित करता है। यह पॉइंट में एक सकारात्मक मान लेता है, जहाँ 1 इंच में 72 पॉइंट होते हैं। यह उदाहरण मौजूदा प्रस्तुति में वर्तमान अंतराल को प्रिंट करता है और 18 पॉइंट का अंतराल सेट करके एक चौथाइ‑इंच ग्रिड सहेजता है।

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

ग्रिड एक निश्चित अंतराल पर दोहराता है। [Drawing guides](/slides/hi/java/drawing-guides/) व्यक्तिगत क्षैतिज या लंबवत स्थितियों को चिह्नित करते हैं। दोनों ही संपादन सहायक हैं और केवल उन संपादकों में दिखते हैं जो उन्हें प्रदर्शित करते हैं। स्लाइड‑शो और PDF, छवियों या SVG निर्यात में इन्हें छोड़ दिया जाता है।

## **प्रस्तुति खोलते समय टिप्पणी दिखाएँ या छुपाएँ**

[setShowComments](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) एक प्राथमिकता संग्रहीत करता है जिसे संगत संपादक प्रस्तुति खोलते समय उपयोग करते हैं। टिप्पणी वाले मौजूदा प्रस्तुति के लिए यह उदाहरण वर्तमान सेटिंग को प्रिंट करता है और टिप्पणी छिपी हुई कॉपी सहेजता है। यह कॉपी को स्लाइड दृश्य में खोलने के लिए [setLastView](https://reference.aspose.com/slides/java/com.aspose.slides/iviewproperties/#setLastView-int-) को [ViewType.SlideView](https://reference.aspose.com/slides/java/com.aspose.slides/viewtype/#SlideView) के साथ भी कॉल करता है।

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

टिप्पणियों को छिपाने से उनका टेक्स्ट, लेखक, स्थितियाँ, उत्तर, और स्थिति संरक्षित रहती हैं। टिप्पणी स्वयं को बदलने के लिए, देखें [Presentation Comments](/slides/hi/java/presentation-comments/)। निर्यात सेटिंग्स यह नियंत्रित करती हैं कि टिप्पणी PDF, HTML, छवियों, नोट्स या हैंडआउट में दिखाई दें या न दें।

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मैं प्रस्तुति फिर से खोलता हूँ तो ग्रिड क्यों छिपा रहता है?**

प्रस्तुति ग्रिड अंतराल को संग्रहीत करती है। ग्रिड देखने के लिए संपादक में ग्रिड दृश्यता को सक्षम करें।

**क्या ड्राइंग गाइड्स को साफ़ करने से ग्रिड अंतराल बदलता है?**

नहीं। गाइड जोड़ने, हटाने या स्थान बदलने से ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या प्रस्तुति के विभिन्न भागों के लिए अलग‑अलग दृश्य सेटिंग्स हो सकती हैं?**

नहीं। [Presentation.getViewProperties](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getViewProperties--) सम्पूर्ण प्रस्तुति पर लागू होती है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग दृश्य सेटिंग्स सहेज सकता हूँ?**

फ़ाइल सभी उपयोगकर्ताओं के लिए एक ही सेट दृश्य गुण संग्रहीत करती है। कोई संपादक उपयोगकर्ता की स्थानीय प्राथमिकताओं को भी लागू कर सकता है।

**क्या मैं टेम्पलेट में दृश्य सेटिंग्स सहेज सकता हूँ?**

हाँ। टेम्पलेट से निर्मित प्रस्तुतियों में उसके सहेजे गए दृश्य सेटिंग्स विरासत में मिलते हैं।