---
title: Python के माध्यम से Java में प्रस्तुति दृश्य गुणों को प्राप्त करना और अपडेट करना
linktitle: दृश्य गुण
type: docs
weight: 80
url: /hi/python-java/presentation-view-properties/
keywords:
- दृश्य गुण
- सामान्य दृश्य
- रूपरेखा सामग्री
- रूपरेखा आइकन
- वर्टिकल स्प्लिटर स्नैप
- एकल दृश्य
- बार स्थिति
- परिमाण आकार
- ऑटो समायोजन
- डिफ़ॉल्ट ज़ूम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के दृश्य गुणों को खोजें ताकि आप PPT, PPTX और ODP स्लाइड्स को अनुकूलित कर सकें—लेआउट, ज़ूम स्तर और प्रदर्शन सेटिंग्स को समायोजित करें।"
---
## **परिचय**

सामान्य दृश्य में तीन सामग्री क्षेत्र होते हैं: स्लाइड स्वयं, एक साइड सामग्री क्षेत्र, और नीचे का सामग्री क्षेत्र। सामान्य दृश्य गुण इन सामग्री क्षेत्रों की स्थिति का वर्णन करते हैं। यह जानकारी एप्लिकेशन को उसके दृश्य अवस्था को फ़ाइल में सहेजने की अनुमति देती है, ताकि पुनः खोलने पर दृश्य वही अवस्था में हो जैसा कि प्रस्तुति को आखिरी बार सहेजा गया था।

प्रस्तुति के सामान्य दृश्य गुणों तक पहुंच प्रदान करने के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) मेथड जोड़ा गया है।

[NormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/) और [NormalViewRestoredProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/) क्लासेस तथा [SplitterBarStateType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/) एन्यूमरेशन जोड़े गए हैं।

## **NormalViewProperties के बारे में**

सामान्य दृश्य गुणों का प्रतिनिधित्व करता है।

मेथड्स [getShowOutlineIcons](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) और [setShowOutlineIcons](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) यह निर्धारित करते हैं कि क्या एप्लिकेशन को सामान्य दृश्य मोड के किसी भी सामग्री क्षेत्र में रूपरेखा सामग्री प्रदर्शित करते समय आइकन दिखाने चाहिए।

मेथड्स [getSnapVerticalSplitter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) और [setSnapVerticalSplitter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) यह निर्धारित करते हैं कि साइड क्षेत्र पर्याप्त रूप से छोटा होने पर वर्टिकल स्प्लिटर को न्यूनतम स्थिति में स्नैप करना चाहिए या नहीं।

मेथड्स [getPreferSingleView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) और [setPreferSingleView](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) यह निर्धारित करते हैं कि उपयोगकर्ता मानक सामान्य दृश्य (तीन सामग्री क्षेत्रों के साथ) की बजाय पूर्ण-विंडो एकल-सामग्री क्षेत्र देखना पसंद करता है या नहीं। यदि सक्षम किया गया है, तो एप्लिकेशन पूरे विंडो में किसी एक सामग्री क्षेत्र को प्रदर्शित करने का चयन कर सकता है।

मेथड्स [getVerticalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) यह निर्धारित करते हैं कि क्षैतिज या लंबवत स्प्लिटर बार किस स्थिति में दिखाया जाना चाहिए। एक क्षैतिज स्प्लिटर बार स्लाइड को नीचे के सामग्री क्षेत्र से अलग करता है; एक लंबवत स्प्लिटर बार स्लाइड को साइड सामग्री क्षेत्र से अलग करता है। संभावित मान हैं: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Maximized) और [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Restored)।

मेथड्स [getRestoredLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) और [getRestoredTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) यह निर्दिष्ट करते हैं कि सामान्य दृश्य में शीर्ष या साइड स्लाइड क्षेत्र का आकार क्या होगा, जब [SplitterBarStateType.Restored](https://reference.aspose.com/slides/hi/python-java/aspose.slides/splitterbarstatetype/#Restored) मान को क्रमशः [getVerticalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) और [getHorizontalBarState](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) पर लागू किया जाता है।

## **Restoring NormalViewProperties के बारे में**

सामान्य दृश्य में स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) का बच्चा हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) का बच्चा हो) के आकार को निर्दिष्ट करता है, जब क्षेत्र का आकार परिवर्तनीय पुनर्स्थापित आकार (न तो न्यूनतम और न ही अधिकतम) हो।

मेथड [getDimensionSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) स्लाइड क्षेत्र (चौड़ाई जब यह [getRestoredTop](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredTop) का बच्चा हो, ऊँचाई जब यह [getRestoredLeft](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) का बच्चा हो) के आकार को निर्दिष्ट करता है।

मेथड [getAutoAdjust](https://reference.aspose.com/slides/hi/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) यह निर्धारित करता है कि जब एप्लिकेशन में दृश्य वाले विंडो का आकार बदलते हैं तो साइड सामग्री क्षेत्र का आकार नई स्थिति के लिए समायोजित होना चाहिए या नहीं।

निचे दिया गया उदाहरण दिखाता है कि प्रस्तुति के लिए [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties) तक कैसे पहुंचा जाए।

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

    # प्रस्तुति के दृश्य गुणों को पुनर्स्थापित करें।
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट ज़ूम मान सेट करें**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java डिफ़ॉल्ट ज़ूम मान सेट करने का समर्थन करता है जिससे प्रस्तुति खोलते समय यह पहले से लागू हो जाएगा। यह कार्य प्रस्तुति के [ViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) को सेट करके किया जा सकता है। [getSlideViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getSlideViewProperties) और [getNotesViewProperties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNotesViewProperties) को प्रोग्रामेटिक रूप से कॉन्फ़िगर किया जा सकता है। इस विषय में, हम एक उदाहरण के साथ देखेंगे कि कैसे [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के [View Properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) को सेट किया जाता है।
{{% /alert %}}

दृश्य गुण सेट करने के लिए, निम्न चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) के [View Properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/) सेट करें।
3. प्रस्तुति को एक [PPTX](https://docs.fileformat.com/presentation/pptx/) फ़ाइल के रूप में लिखें।

निचे के उदाहरण में, हम स्लाइड दृश्य और नोट्स दृश्य दोनों के लिए ज़ूम मान सेट करते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # प्रस्तुति के दृश्य गुण सेट करें।
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # स्लाइड दृश्य के लिए ज़ूम प्रतिशत।
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # नोट्स दृश्य के लिए ज़ूम प्रतिशत.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं प्रस्तुतिकरण के विभिन्न सेक्शन के लिए अलग-अलग दृश्य सेटिंग्स सेट कर सकता हूँ?**

[View settings](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) प्रस्तुति स्तर पर परिभाषित होते हैं ([Normal View](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Slide View](https://reference.aspose.com/slides/hi/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), न कि सेक्शन प्रति, इसलिए जब फ़ाइल खुलती है तो पूरे दस्तावेज़ पर एक ही सेट पैरामीटर लागू होते हैं।

**क्या मैं विभिन्न उपयोगकर्ताओं के लिए अलग-अलग दृश्य अवस्थाएँ पूर्वनिर्धारित कर सकता हूँ?**

नहीं। सेटिंग्स फ़ाइल में संग्रहीत होती हैं और साझा की जाती हैं। व्यूअर एप्लिकेशन उपयोगकर्ता प्राथमिकताओं को सम्मानित कर सकते हैं, लेकिन फ़ाइल स्वयं केवल एक सेट दृश्य गुणों को रखती है।

**क्या मैं एक टेम्पलेट तैयार कर सकता हूँ जिसमें पूर्वनिर्धारित View Properties हों ताकि नई प्रस्तुतियों का खुलना समान हो?**

हाँ। क्योंकि [view properties](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getViewProperties) प्रस्तुति स्तर पर संग्रहीत होते हैं, आप उन्हें एक टेम्पलेट में एम्बेड कर सकते हैं और उसी प्रारम्भिक दृश्य कॉन्फ़िगरेशन के साथ नई दस्तावेज़ बना सकते हैं।