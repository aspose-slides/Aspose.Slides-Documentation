---
title: PowerPoint प्रस्तुतियों में Python का उपयोग करके SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt टेक्स्ट
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- ऑर्गनाइज़ेशन चार्ट
- पिक्चर ऑर्गनाइज़ेशन चार्ट
- PowerPoint
- प्रेजेंटेशन
- Python
- Aspose.Slides
description: "स्पष्ट कोड उदाहरणों का उपयोग करके, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ करते हैं, Aspose.Slides for Python via Java के साथ PowerPoint SmartArt को बनाने और संपादित करना सीखें।"
---
## **अवलोकन**

SmartArt PowerPoint आरेख है जो नोड्स, नोड शेप्स और लेआउट से बनाया गया है। Aspose.Slides for Python via Java के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से टेक्स्ट पढ़ सकते हैं, उसके लेआउट को बदल सकते हैं, छिपे हुए नोड्स की जाँच कर सकते हैं, ऑर्गनाइज़ेशन चार्ट लेआउट कॉन्फ़िगर कर सकते हैं, और पिक्चर ऑर्गनाइज़ेशन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से टेक्स्ट प्राप्त करें**

एक SmartArt नोड में एक या अधिक शेप्स हो सकते हैं। नोड शेप्स से टेक्स्ट पढ़ने के लिए, [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes) पर इटररेट करें, फिर [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame) द्वारा लौटाया गया [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) पढ़ें।

उदाहरण में कम से कम एक स्लाइड वाला प्रेज़ेंटेशन और उस स्लाइड पर पहला शेप रूप में SmartArt ऑब्जेक्ट होना आवश्यक है। यह प्रत्येक उपलब्ध टेक्स्ट फ्रेम को कंसोल पर प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape
        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```
## **SmartArt ऑब्जेक्ट का लेआउट प्रकार बदलें**

SmartArt लेआउट निर्धारित करता है कि नोड्स कैसे व्यवस्थित और जुड़ते हैं। निम्नलिखित उदाहरण एक SmartArt ऑब्जेक्ट बनाता है जिसमें [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` मान उपयोग किया गया है, इसे `BasicProcess` मान में बदलता है, और प्रेज़ेंटेशन को सहेजता है। [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) को पास किया गया पोजीशन और साइज पॉइंट्स में मापा जाता है। लेआउट बदलने के लिए [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) का उपयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **SmartArt नोड छुपा है या नहीं जांचें**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) दर्शाता है कि नोड SmartArt डेटा मॉडल में छुपा है या नहीं। छिपे हुए नोड्स संरचना में मौजूद हो सकते हैं, भले ही चयनित लेआउट उन्हें दृश्यमान डायग्राम तत्वों के रूप में न दिखाए।

निम्नलिखित उदाहरण एक नोड को SmartArt ऑब्जेक्ट में जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` मान का उपयोग करता है और जोड़े गए नोड की छुपी स्थिति की जाँच करता है। यदि नोड छुपा है तो यह एक संदेश प्रिंट करता है और डायग्राम को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **ऑर्गनाइज़ेशन चार्ट लेआउट प्राप्त करें या सेट करें**

ऑर्गनाइज़ेशन चार्ट लेआउट का उपयोग करने वाले SmartArt डायग्राम के लिए, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) और [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) परिभाषित करते हैं कि पैरेंट नोड के तहत चाइल्ड नोड्स कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) के आधार पर चाइल्ड नोड्स को बाएँ, दाएँ या दोनों तरफ लटकाने के लिए सेट कर सकते हैं।

निम्नलिखित उदाहरण एक ऑर्गनाइज़ेशन चार्ट बनाता है और पहले नोड के लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है। शून्य-आधारित सूचकांक `0` पहला टॉप-लेवल नोड चुनता है; उसके चाइल्ड नोड्स चयनित व्यवस्था का उपयोग करते हैं। फिर संशोधित प्रेज़ेंटेशन सहेजा जाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **पिक्चर ऑर्गनाइज़ेशन चार्ट बनाएं**

पिक्चर ऑर्गनाइज़ेशन चार्ट एक SmartArt लेआउट है जो इमेज प्लेसहोल्डर्स वाले हायरार्की डायग्राम के लिए डिज़ाइन किया गया है। जब स्लाइड में SmartArt ऑब्जेक्ट जोड़ते हैं तो [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` मान का उपयोग करें। यह उदाहरण इमेज प्लेसहोल्डर्स के साथ एक डायग्राम सहेजता है; यह प्लेसहोल्डर्स को इमेज से भरता नहीं है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
## **लेगसी डायग्राम को शेप्स के समूह में परिवर्तित करें**

मौजूदा प्रेज़ेंटेशन को आधुनिक बनाने के दौरान, आपको PowerPoint 97–2003 में मूल रूप से बनाई गई ऑर्गनाइज़ेशन चार्ट को अपडेट करना पड़ सकता है। Aspose.Slides इन लेगसी डायग्राम को [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) ऑब्जेक्ट्स के रूप में दर्शाता है। डायग्राम को शेप्स के समूह में बदलने के लिए [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) का उपयोग करें ताकि आप व्यक्तिगत विज़ुअल एलिमेंट्स को एडिट कर सकें। विवरण के लिए देखें [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/)।

परिवर्तन शेप कलेक्शन में नया समूह जोड़ता है बिना मूल डायग्राम को हटाए। सफल परिवर्तन के बाद, डुप्लिकेट कंटेंट से बचने के लिए मूल को [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) से हटाएँ। परिवर्तन से पहले लेगसी डायग्राम को एक सूची में एकत्र करें ताकि शेप्स को जोड़ना या हटाना इटररेशन को बाधित न करे।

निम्नलिखित उदाहरण एक प्रेज़ेंटेशन खोलता है, हर स्लाइड को सर्च करता है, डायग्राम को शेप्स के समूह में बदलता है, और अपडेटेड प्रेज़ेंटेशन को PPTX के रूप में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
सहेजा गया प्रेज़ेंटेशन परिवर्तित लेगसी डायग्राम की जगह एडिटेबल शेप्स के समूह शामिल करता है, साथ में कोई मूल डायग्राम नहीं रहता। प्रत्येक समूह के भीतर व्यक्तिगत एलिमेंट्स जैसे टेक्स्ट, फ़िल या पोजीशन को एडिट करने के लिए PPTX को PowerPoint में खोलें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हाँ। [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) मेथड चयनित SmartArt लेआउट के रिवर्सल को सपोर्ट करने पर डायग्राम दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ, या वापस, बदल देता है।

**मैं SmartArt को उसी स्लाइड पर या किसी अन्य प्रेज़ेंटेशन में फ़ॉर्मेटिंग बनाए रखते हुए कैसे कॉपी कर सकता हूँ?**

आप [SmartArt शेप को क्लोन करें](/slides/hi/python-java/shape-manipulations/) को [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) के साथ या उस SmartArt को शामिल करने वाली पूरी स्लाइड को [पूरी स्लाइड को क्लोन करें](/slides/hi/python-java/clone-slides/) कर सकते हैं। दोनों उपाय आकार, पोजीशन और फ़ॉर्मेटिंग को संरक्षित रखते हैं।

**मैं SmartArt को प्रीव्यू या वेब एक्सपोर्ट के लिए रास्टर इमेज में कैसे रेंडर करूँ?**

[स्लाइड को रेंडर करें](/slides/hi/python-java/convert-powerpoint-to-png/) या पूरी प्रेज़ेंटेशन को PNG या JPEG में। SmartArt स्लाइड का हिस्सा होने के नाते रेंडर किया जाता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हैं तो मैं एक विशिष्ट SmartArt ऑब्जेक्ट कैसे खोज सकता हूँ?**

[Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) या [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) का उपयोग करके SmartArt शेप को एक विशिष्ट अल्टरनेटिव टेक्स्ट या नाम दें, उस मान को [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) में खोजें, और फिर जांचें कि मिलती‑जुलती शेप एक [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/) है।