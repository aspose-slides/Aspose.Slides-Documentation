---
title: Python के माध्यम से Java में प्रस्तुति व्यू प्रॉपर्टीज़ को प्राप्त करें और अपडेट करें
linktitle: व्यू प्रॉपर्टीज़
type: docs
weight: 80
url: /hi/python-java/presentation-view-properties/
keywords:
- व्यू प्रॉपर्टीज़
- सामान्य दृश्य
- आउटलाइन सामग्री
- आउटलाइन आइकन
- वर्टिकल स्प्लिटर स्नैप
- एकल दृश्य
- बार स्थिति
- आयाम आकार
- ऑटो एडजस्ट
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के व्यू प्रॉपर्टीज़ की खोज करके PPT, PPTX और ODP स्लाइड्स को व्यक्तिगत बनाएँ—लेआउट, ज़ूम स्तर और डिस्प्ले सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्रों शामिल होते हैं: स्वयं स्लाइड, एक साइड कंटेंट रीजन, और एक नीचे का कंटेंट रीजन। सामान्य दृश्य गुण इन सामग्री क्षेत्रों की स्थिति का वर्णन करते हैं। यह जानकारी एप्लिकेशन को दृश्य स्थिति फ़ाइल में सहेजने की अनुमति देती है, ताकि जब फिर से खोला जाए तो दृश्य उसी स्थिति में हो जैसा कि प्रस्तुति आखिरी बार सहेजी गई थी।

मethode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) को प्रस्तुतिकरण की सामान्य दृश्य गुणों तक पहुंच प्रदान करने के लिए जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/) और [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/) वर्ग और [SplitterBarStateType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/) enumeration को जोड़ा गया है।

## **NormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

मेथड्स [getShowOutlineIcons](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) निर्धारित करते हैं कि सामान्य दृश्य मोड में किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय एप्लिकेशन को आइकन दिखाने चाहिए या नहीं।

मेथड्स [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) निर्धारित करते हैं कि साइड क्षेत्र पर्याप्त छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप किया जाना चाहिए या नहीं।

मेथड्स [getPreferSingleView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) और [setPreferSingleView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) निर्धारित करते हैं कि उपयोगकर्ता मानक तीन सामग्री क्षेत्रों वाले सामान्य दृश्य की बजाय पूरी विंडो में एकल‑सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया जाता है, तो एप्लिकेशन पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित कर सकता है।

मेथड्स [getVerticalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) निर्धारित करते हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को उसके नीचे के सामग्री क्षेत्र से अलग करता है; एक लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Restored)।

मेथड्स [getRestoredLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) और [getRestoredTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) सामान्य दृश्य के शीर्ष या साइड स्लाइड क्षेत्र का आकार निर्दिष्ट करते हैं, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Restored) मान को क्रमशः [getVerticalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) पर लागू किया जाता है।

## **NormalViewProperties को पुनर्स्थापित करने के बारे में**

स्लाइड क्षेत्र (चौड़ाई जब वह [getRestoredTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) का चाइल्ड हो, ऊँचाई जब वह [getRestoredLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) का चाइल्ड हो) का आकार निर्दिष्ट करता है, जब वह क्षेत्र परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) में हो।

मेथड [getDimensionSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) स्लाइड क्षेत्र (चौड़ाई जब वह [getRestoredTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) का चाइल्ड हो, ऊँचाई जब वह [getRestoredLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) का चाइल्ड हो) का आकार निर्दिष्ट करता है।

मेथड [getAutoAdjust](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) निर्दिष्ट करता है कि जब एप्लिकेशन में दृश्य वाली विंडो का आकार बदलता है तो साइड कंटेंट रीजन का आकार नई स्थिति को समायोजित करना चाहिए या नहीं।

नीचे दिया गया उदाहरण दिखाता है कि किसी प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) तक कैसे पहुंचा जाए।

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

    # प्रस्तुति के व्यू प्रॉपर्टीज़ को पुनर्स्थापित करें।
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है ताकि यह प्रस्तुति खोलते समय पहले से लागू हो। यह किसी प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getSlideViewProperties) तथा [getNotesViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNotesViewProperties) को प्रोग्रामmatically कॉन्फ़िगर किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि Aspose.Slides में [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के [View Properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) को कैसे सेट किया जाए।
{{% /alert %}}

व्यू गुण सेट करने के लिए निम्न चरणों का अनुसरण करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टैंस बनाएं।
1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के [View Properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) सेट करें।
1. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

निचे के उदाहरण में हम स्लाइड व्यू और नोट्स व्यू दोनों के लिए ज़ूम मान सेट करते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # प्रस्तुति की व्यू प्रॉपर्टीज़ सेट करें।
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # स्लाइड व्यू के लिए ज़ूम प्रतिशत।
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # नोट्स व्यू के लिए ज़ूम प्रतिशत।

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ग्रिड स्पेसिंग सेट करें**

[Presentation.getViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) का उपयोग करके प्रस्तुतिकरण‑व्यापी दृश्य सेटिंग्स तक पहुंचें। मेथड्स [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getGridSpacing) और [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#setGridSpacing) अंतर्निहित संपादन ग्रिड के अंतराल को पढ़ते या बदलते हैं। यह सेटिंग पूरी प्रस्तुति पर लागू होती है, व्यक्तिगत स्लाइड पर नहीं। ग्रिड स्पेसिंग पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। API दस्तावेज़ में निर्दिष्ट अनुसार एक सकारात्मक मान उपयोग करें।

निचे का उदाहरण एक मौजूदा `demo.pptx` खोलता है, उसकी वर्तमान ग्रिड स्पेसिंग प्रिंट करता है, एक चौथाई‑इंच अंतराल सेट करता है, और परिणाम को सेव करता है।

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

ग्रिड [ड्रॉइंग गाइड्स](/slides/hi/python-java/drawing-guides/) से अलग है। ग्रिड स्पेसिंग एक नियमित अंतराल को नियंत्रित करती है, जबकि ड्रॉइंग गाइड्स व्यक्तिगत रूप से स्थित क्षैतिज या लंबवत संरेखण रेखाएँ होती हैं। गाइड्स को जोड़ने, स्थानांतरित करने या साफ़ करने से ग्रिड स्पेसिंग नहीं बदलती।

ग्रिड और ड्रॉइंग गाइड दोनों ही संपादन सहयोगी हैं। वे PDF, इमेज, SVG या स्लाइड शो में स्लाइड सामग्री के रूप में रेंडर नहीं होते। ग्रिड स्पेसिंग को सहेजना यह गारंटी नहीं देता कि कोई संपादक ग्रिड दर्शाएगा: उसकी दृश्यता दर्शक या संपादक की प्राथमिकताओं पर निर्भर करती है।

## **FAQ**

**प्रस्तुति फिर से खोलने के बाद ग्रिड दिखाई नहीं देता, क्यों?**

फ़ाइल ग्रिड स्पेसिंग को सहेजती है, लेकिन संपादक यह नियंत्रित करता है कि ग्रिड प्रदर्शित हो या नहीं। संपादक की ग्रिड दृश्यता सेटिंग्स की जाँच करें।

**क्या ड्रॉइंग गाइड्स को साफ़ करने से ग्रिड स्पेसिंग बदलती है?**

नहीं। ड्रॉइंग गाइड्स और ग्रिड स्पेसिंग स्वतंत्र सेटिंग्स हैं। गाइड्स को साफ़ करने से संग्रहीत ग्रिड अंतराल अपरिवर्तित रहता है।

**क्या मैं प्रस्तुति के विभिन्न सेक्शन के लिए अलग‑अलग दृश्य सेटिंग्स निर्धारित कर सकता हूँ?**

[व्यू सेटिंग्स](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) प्रस्तुति स्तर पर निर्धारित होती हैं (Normal View/Slide View), सेक्शन‑विशिष्ट नहीं, इसलिए एक ही सेट पैरामीटर पूरे दस्तावेज़ के लिए खुलते समय लागू होते हैं।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग‑अलग व्यू स्थितियों को पूर्वपरिभाषित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में सहेजी जाती हैं और सभी उपयोगकर्ताओं में साझा होती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं का सम्मान कर सकते हैं, लेकिन फ़ाइल में केवल एक ही सेट व्यू गुण होते हैं।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित व्यू प्रॉपर्टीज़ हों, ताकि नई प्रस्तुति समान तरीके से खुले?**

हां। चूँकि [व्यू प्रॉपर्टीज़](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) प्रस्तुति स्तर पर सहेजी जाती हैं, आप उन्हें टेम्पलेट में एम्बेड कर सकते हैं और नई दस्तावेज़ उसी प्रारंभिक व्यू कॉन्फ़िगरेशन के साथ बना सकते हैं।