---
title: "Python के माध्यम से Java में प्रस्तुति दृश्य गुणधर्म प्राप्त करें और अपडेट करें"
linktitle: "दृश्य गुणधर्म"
type: docs
weight: 80
url: /hi/python-java/presentation-view-properties/
keywords:
- "दृश्य गुणधर्म"
- "सामान्य दृश्य"
- "आउटलाइन सामग्री"
- "आउटलाइन आइकन"
- "वर्टिकल स्प्लिटर स्नैप"
- "एकल दृश्य"
- "बार स्थिति"
- "आयाम आकार"
- "स्वत: समायोजन"
- "डिफ़ॉल्ट ज़ूम"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java के दृश्य गुणधर्मों की खोज करके PPT, PPTX और ODP स्लाइड्स को अनुकूलित करें—लेआउट, ज़ूम स्तर और प्रदर्शन सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और एक नीचे का सामग्री क्षेत्र। सामान्य दृश्य की गुणधर्म इन सामग्री क्षेत्रों की स्थिति का वर्णन करते हैं। यह जानकारी एप्लिकेशन को दृश्य स्थिति फ़ाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर दृश्य वही स्थिति में हो जैसा कि प्रस्तुति अंतिम बार सहेजी गई थी।

प्रस्तुति की सामान्य दृश्य गुणधर्मों तक पहुँच प्रदान करने के लिए मेथड [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/) और [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/) क्लासों तथा [SplitterBarStateType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/) एन्यूमरेशन को जोड़ा गया है।

## **NormalViewProperties के बारे में**

सामान्य दृश्य गुणधर्मों का प्रतिनिधित्व करता है।

[getShowOutlineIcons](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) मेथड दर्शाते हैं कि क्या एप्लिकेशन को सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय आइकन दिखाने चाहिए।

[getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) मेथड दर्शाते हैं कि जब साइड क्षेत्र पर्याप्त रूप से छोटा हो तो वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

[getPreferSingleView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) और [setPreferSingleView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) मेथड दर्शाते हैं कि उपयोगकर्ता तीन सामग्री क्षेत्रों वाले मानक सामान्य दृश्य के बजाय पूर्ण‑विंडो एक‑सामग्री क्षेत्र देखना चाहता है या नहीं। यदि सक्षम किया गया, तो एप्लिकेशन पूरे विंडो में एक सामग्री क्षेत्र प्रदर्शित कर सकता है।

[getVerticalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) मेथड दर्शाते हैं कि क्षैतिज या वर्टिकल स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को स्लाइड के नीचे के सामग्री क्षेत्र से अलग करता है; एक वर्टिकल स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Restored)।

[getRestoredLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) और [getRestoredTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) मेथड निर्दिष्ट करते हैं कि जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Restored) मान को क्रमशः [getVerticalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) पर लागू किया जाता है, तो सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होना चाहिए।

## **Restoring NormalViewProperties के बारे में**

सामान्य दृश्य के स्लाइड क्षेत्र (चाइल्ड होने पर चौड़ाई या ऊँचाई) का आकार निर्दिष्ट करता है, जब क्षेत्र एक परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम न ही अधिकतम) में हो।

[getDimensionSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) मेथड स्लाइड क्षेत्र (चाइल्ड होने पर चौड़ाई या ऊँचाई) का आकार निर्दिष्ट करता है।

[getAutoAdjust](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) मेथड दर्शाता है कि जब विंडो का आकार बदलते हैं तो साइड सामग्री क्षेत्र का आकार नई विंडो आकार के अनुसार स्वतः समायोजित होना चाहिए या नहीं।

निम्न उदाहरण दिखाता है कि प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) तक कैसे पहुँचें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # प्रस्तुति के दृश्य गुणधर्म को पुनर्स्थापित करें।
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि प्रस्तुति खोलते समय वह पहले से लागू हो। यह किसी प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getSlideViewProperties) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNotesViewProperties) को प्रोग्रामेटिक रूप से कॉन्फ़िगर किया जा सकता है। इस विषय में, हम इस बात का उदाहरण देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) की [View Properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) को कैसे सेट किया जाता है।
{{% /alert %}}

View Properties सेट करने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएँ।  
2. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) की [View Properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) सेट करें।  
3. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

नीचे के उदाहरण में हम स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट करते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # प्रस्तुति की दृश्य गुणधर्म सेट करें।
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # स्लाइड दृश्य के लिए ज़ूम प्रतिशत।
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # नोट्स दृश्य के लिए ज़ूम प्रतिशत।

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ग्रिड स्पेसिंग सेट करें**

प्रेज़ेंटेशन‑वाइड दृश्य सेटिंग्स तक पहुँचने के लिए [Presentation.getViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) का उपयोग करें। [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getGridSpacing) और [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setGridSpacing) मेथड मूल संपादन ग्रिड अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरे प्रेज़ेंटेशन पर लागू होती है, न कि व्यक्तिगत स्लाइड पर। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। API दस्तावेज़ के अनुसार एक धनात्मक मान का उपयोग करें।

निम्न उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई‑इंच अंतराल सेट करता है, और परिणाम सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ग्रिड [drawing guides](/slides/hi/python-java/drawing-guides/) से अलग होता है। ग्रिड स्पेसिंग नियमित अंतराल को नियंत्रित करती है, जबकि ड्राइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या वर्टिकल संरेखण लाइनों के रूप में होती हैं। गाइड्स को जोड़ने, स्थानांतरित करने या साफ़ करने से ग्रिड स्पेसिंग नहीं बदलती।

ग्रिड और ड्राइंग गाइड दोनों संपादन सहायक हैं। वे PDF, इमेज, SVG या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को संग्रहीत करना यह गारंटी नहीं देता कि कोई एडिटर ग्रिड दिखाएगा: इसकी दृश्यमानता दर्शक या एडिटर की प्राथमिकताओं पर भी निर्भर करती है।

## **प्रेज़ेंटेशन खोलते समय टिप्पणियों को दिखाएँ या छिपाएँ**

प्रेज़ेंटेशन‑वाइड दृश्य सेटिंग्स तक पहुँचने के लिए [Presentation.getViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) का उपयोग करें। जब प्रेज़ेंटेशन PowerPoint या किसी अन्य संगत संपादक में खोलता है, तो टिप्पणियों को दिखाना है या नहीं, इस संग्रहीत प्राथमिकता को पढ़ने या बदलने के लिए [ViewProperties.getShowComments](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getShowComments) और [ViewProperties.setShowComments](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setShowComments) का उपयोग करें।

यह सेटिंग केवल संग्रहीत दृश्य प्राथमिकता को नियंत्रित करती है। यह टिप्पणी को जोड़ती, हटाती, संपादित करती या हल नहीं करती। टिप्पणियों को छिपाने से उनकी सामग्री, लेखक, स्थितियाँ, उत्तर और स्थितियाँ संरक्षित रहती हैं। उन कार्यों के लिए देखें [Presentation Comments](/slides/hi/python-java/presentation-comments/) जो स्वयं टिप्पणियों को बदलते हैं।

निम्न उदाहरण को एक मौजूदा `comments.pptx` की आवश्यकता होती है जिसमें टिप्पणियाँ हों। यह वर्तमान दृश्यता सेटिंग प्रिंट करता है, टिप्पणियों को छिपाने का अनुरोध करता है, और बिना किसी टिप्पणी को हटाए नया PPTX सहेजता है। यह [ViewProperties.setLastView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setLastView) को [ViewType.SlideView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewtype/#SlideView) के साथ उपयोग करके टिप्पणी दृश्यता के साथ प्रारंभिक संपादन दृश्य को कॉन्फ़िगर भी करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

यह सेटिंग यह निर्धारित नहीं करती कि टिप्पणियाँ PDF, HTML, इमेज, नोट्स या हैंडआउट निर्यात में शामिल हैं या नहीं। संबंधित निर्यात‑विशिष्ट विकल्पों को अलग से कॉन्फ़िगर करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**प्रस्तुति को पुनः खोलने के बाद ग्रिड क्यों दिखाई नहीं देता?**  
फ़ाइल ग्रिड स्पेसिंग को संग्रहीत करती है, लेकिन संपादक नियंत्रण करता है कि ग्रिड प्रदर्शित हो या नहीं। संपादक की ग्रिड दृश्यता सेटिंग्स की जाँच करें।

**ड्राइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**  
नहीं। ड्राइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न अनुभागों के लिए अलग-अलग दृश्य सेटिंग्स निर्धारित कर सकता हूँ?**  
[View settings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), सेक्शन‑दर‑सेक्शन नहीं, इसलिए एक ही पैरामीटर सेट पूरे दस्तावेज़ पर लागू होता है जब यह खुलता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए विभिन्न दृश्य स्थितियां पूर्वनिर्धारित कर सकता हूँ?**  
नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। दर्शक एप्लिकेशन उपयोगकर्ता प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल में एक ही दृश्य गुणधर्म सेट होता है।

**क्या मैं पूर्वनिर्धारित View Properties के साथ एक टेम्पलेट तैयार कर सकता हूँ जिससे नई प्रस्तुतियाँ उसी तरह खुलें?**  
हाँ। क्योंकि [view properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें एक टेम्पलेट में एंबेड कर सकते हैं और उसी प्रारंभिक दृश्य कॉन्फ़िगरेशन के साथ नए दस्तावेज़ बना सकते हैं।