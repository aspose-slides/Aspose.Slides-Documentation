---
title: Python के माध्यम से Java में प्रस्तुति दृश्य गुणों को प्राप्त करें और अद्यतन करें
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/python-java/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- लंबवत विभाजक स्नैप
- एकल दृश्य
- बार स्थिति
- परिमाण आकार
- स्वतः समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों में सामान्य दृश्य लेआउट, स्लाइड और नोट्स ज़ूम, ग्रिड स्पेसिंग, और टिप्पणी दृश्यता को कॉन्फ़िगर करने के लिए Java के माध्यम से Python के लिए Aspose.Slides का उपयोग करें।"
---
## **परिचय**

PowerPoint के सामान्य दृश्य में, स्लाइड एक साइड पेन के बीच दिखाई देती है जिसमें थंबनेल या रूपरेखा होती है और नीचे नोट्स पेन होता है। Aspose.Slides for Python via Java प्रेजेंटेशन की सहेजी गई एडिटिंग प्राथमिकताओं को [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) के माध्यम से उजागर करता है। इनमें पेन लेआउट, ज़ूम स्तर, ग्रिड स्पेसिंग और टिप्पणी दृश्यता शामिल है।

## **NormalViewProperties के बारे में**

उपयोग करें [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) को [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/) क्लास तक पहुँचने के लिए। [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) नियंत्रित करता है कि रूपरेखा में स्लाइड शीर्षकों के बगल में आइकन दिखें या नहीं। [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) साइड पेन को न्यूनतम स्थिति में स्नैप करने देता है जब उपयोगकर्ता इसे संकरी करता है। [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) पूर्ण विंडो में एक पेन प्रदर्शित करने की प्राथमिकता दर्शाता है।

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) साइड पेन और स्लाइड के बीच विभाजक को नियंत्रित करता है। [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) नोट्स पेन के ऊपर विभाजक को नियंत्रित करता है। दोनों [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) के `Minimized`, `Maximized` या `Restored` मान स्वीकार करते हैं।

## **Restoring NormalViewProperties के बारे में**

जब विभाजक पुनर्स्थापित किया जाता है, तो [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) साइड पेन का सहेजा गया आकार प्रदान करता है और [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) ऊपर की स्लाइड क्षेत्र का सहेजा गया आकार प्रदान करता है। दोनों [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/) की एक इंस्टेंस लौटाते हैं। इसका [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) मेथड 0 से 100 तक प्रतिशत स्वीकार करता है, और [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) नियंत्रित करता है कि विंडो के आकार बदलने पर एडिटर आकार को समायोजित करे या नहीं।

यह उदाहरण मौजूदा प्रेजेंटेशन को अपडेट करता है। यह क्षैतिज विभाजक को पुनर्स्थापित करता है, [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) द्वारा लौटाए गए आकार को 80% सेट करता है जिसमें स्वतः समायोजन सक्षम है, और लंबवत विभाजक को अधिकतम करता है। यह [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) को भी कॉल करता है ताकि रूपरेखा दृश्य में आइकन दिखाए जाएँ।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) और [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) एडिटर के लिए स्वतंत्र ज़ूम सेटिंग्स संग्रहीत करते हैं। ये सेटिंग्स स्लाइड आयामों, स्लाइड‑शो प्लेबैक या इमेज एक्सपोर्ट रिज़ॉल्यूशन को प्रभावित नहीं करती हैं।

यह उदाहरण मौजूदा प्रेजेंटेशन को खोलता है और स्लाइड को एडिटिंग विंडो में फिट करने के लिए [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) को कॉल करता है। नोट्स पेज के लिए यह स्वतः स्केलेशन को निष्क्रिय करता है और एक स्थिर 80% ज़ूम सेट करने के लिए [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) को कॉल करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ग्रिड स्पेसिंग सेट करें**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) पूर्ण प्रेजेंटेशन में एडिटिंग ग्रिड लाइनों के बीच की दूरी सेट करता है। यह पॉइंट्स में एक सकारात्मक मान लेता है, जहाँ 1 इंच में 72 पॉइंट्स होते हैं। यह उदाहरण मौजूदा प्रेजेंटेशन में वर्तमान स्पेसिंग को प्रिंट करता है और अंतराल को 18 पॉइंट्स सेट करके एक क्वार्टर‑इंच ग्रिड सहेजता है।

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

ग्रिड एक निश्चित अंतराल पर दोहराता है। [ड्रॉइंग गाइड्स](/slides/hi/python-java/drawing-guides/) व्यक्तिगत क्षैतिज या लंबवत स्थितियों को चिह्नित करते हैं। दोनों एडिटिंग सहायक हैं और केवल उन एडिटर्स में दिखाई देते हैं जो इन्हें प्रदर्शित करते हैं। स्लाइड‑शो और PDF, इमेज या SVG में एक्सपोर्ट करने पर इन्हें बाहर रखा जाता है।

## **प्रेजेंटेशन खोलते समय टिप्पणियों को दिखाएँ या छुपाएँ**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) एक प्राथमिकता संग्रहीत करता है जिसे संगत एडिटर्स प्रेजेंटेशन खोलते समय उपयोग करते हैं। टिप्पणियों वाले मौजूदा प्रेजेंटेशन के लिए, यह उदाहरण वर्तमान सेटिंग को प्रिंट करता है और टिप्पणियों को छुपाकर एक कॉपी सहेजता है। यह [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) को [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) के साथ भी कॉल करता है ताकि कॉपी स्लाइड व्यू में खुले।

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

टिप्पणियों को छुपाने से उनका टेक्स्ट, लेखक, स्थिति, जवाब और स्थिति संरक्षित रहती है। टिप्पणियों को स्वयं बदलने के लिए देखें [प्रेजेंटेशन टिप्पणियाँ](/slides/hi/python-java/presentation-comments/)। एक्सपोर्ट सेटिंग्स नियंत्रित करती हैं कि PDF, HTML, इमेज, नोट्स या हैंडआउट्स में टिप्पणियाँ दिखें या नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**ग्रिड को प्रेजेंटेशन पुनः खोलने पर क्यों छुपाया जाता है?**

प्रेजेंटेशन ग्रिड अंतराल को संग्रहीत करता है। ग्रिड देखने के लिए एडिटर में ग्रिड दृश्यता को सक्षम करें।

**क्या ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**

नहीं। गाइड जोड़ने, स्थानांतरित करने या साफ़ करने से ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या प्रेजेंटेशन के विभिन्न सेक्शन अलग‑अलग व्यू सेटिंग्स रख सकते हैं?**

नहीं। [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) सम्पूर्ण प्रेजेंटेशन पर लागू होता है।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग व्यू सेटिंग्स सहेज सकता हूँ?**

फ़ाइल सभी उपयोगकर्ताओं के लिए एक ही सेट व्यू प्रॉपर्टी संग्रहीत करती है। एक एडिटर उपयोगकर्ता की स्थानीय प्राथमिकताओं को भी लागू कर सकता है।

**क्या मैं टेम्पलेट में व्यू सेटिंग्स सहेज सकता हूँ?**

हाँ। टेम्पलेट से बनाई गई प्रेजेंटेशन उस टेम्पलेट की सहेजी गई व्यू सेटिंग्स को विरासत में लेती हैं।