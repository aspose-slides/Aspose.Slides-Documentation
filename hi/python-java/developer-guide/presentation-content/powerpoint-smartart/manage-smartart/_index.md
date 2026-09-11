---
title: PowerPoint प्रस्तुतियों में Python का उपयोग करके SmartArt प्रबंधित करें
linktitle: SmartArt प्रबंधित करें
type: docs
weight: 10
url: /hi/python-java/manage-smartart/
keywords:
- SmartArt
- SmartArt पाठ
- लेआउट प्रकार
- छिपी प्रॉपर्टी
- संगठन चार्ट
- चित्र संगठन चार्ट
- PowerPoint
- प्रस्तुतीकरण
- Python
- Aspose.Slides
description: "स्पष्ट कोड उदाहरणों का उपयोग करके, जो स्लाइड डिज़ाइन और ऑटोमेशन को तेज़ बनाते हैं, Python के माध्यम से Java में Aspose.Slides के साथ PowerPoint SmartArt बनाना और संपादित करना सीखें।"
---
## **अवलोकन**

SmartArt एक PowerPoint आरेख है जो नोड्स, नोड आकारों और लेआउट से बना होता है। Aspose.Slides for Python via Java के साथ, आप SmartArt बना सकते हैं, उसके नोड्स से पाठ पढ़ सकते हैं, उसका लेआउट बदल सकते हैं, छिपे हुए नोड्स का निरीक्षण कर सकते हैं, संगठन चार्ट लेआउट को कॉन्फ़िगर कर सकते हैं, और पिक्चर संगठन चार्ट बना सकते हैं।

## **SmartArt ऑब्जेक्ट से पाठ प्राप्त करें**

एक SmartArt नोड में एक या अधिक आकार हो सकते हैं। दृश्यमान पाठ पढ़ने के लिए, [SmartArt.getAllNodes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/#getAllNodes) के माध्यम से पुनरावृति करें, फिर [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartshape/#getTextFrame) द्वारा लौटाए गए [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) को पढ़ें।

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

SmartArt लेआउट नियंत्रित करता है कि नोड्स कैसे व्यवस्थित और जुड़ते हैं। नीचे दिया गया उदाहरण [SmartArtLayoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` मान के साथ एक SmartArt ऑब्जेक्ट बनाता है, उसे `BasicProcess` मान में बदलता है, और प्रस्तुति को सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **जाँचें कि SmartArt नोड छिपा है या नहीं**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#isHidden) यह दर्शाता है कि नोड SmartArt डेटा मॉडल में छिपा है या नहीं। चयनित लेआउट द्वारा उन्हें दृश्यमान आरेख तत्वों के रूप में नहीं दिखाया जाने पर भी संरचना में छिपे हुए नोड्स मौजूद हो सकते हैं।

निम्न उदाहरण एक नोड को उस SmartArt ऑब्जेक्ट में जोड़ता है जो [SmartArtLayoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` मान का प्रयोग करता है और नोड की छिपी हुई स्थिति की जाँच करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **संगठन चार्ट लेआउट प्राप्त करें या सेट करें**

संगठन चार्ट लेआउट का उपयोग करने वाले SmartArt आरेखों के लिए, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) और [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) निर्धारित करते हैं कि चाइल्ड नोड्स पैरेंट नोड के नीचे कैसे व्यवस्थित होते हैं। उदाहरण के लिए, आप चाइल्ड नोड्स को बाएँ, दाएँ, या दोनों ओर लटकाने के लिए सेट कर सकते हैं, यह चयनित [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/organizationchartlayouttype/) पर निर्भर करता है।

निम्न उदाहरण एक संगठन चार्ट बनाता है और पहले नोड के लेआउट को [OrganizationChartLayoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` मान पर सेट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **पिक्चर संगठन चार्ट बनाएं**

पिक्चर संगठन चार्ट एक SmartArt लेआउट है जो उन पदानुक्रमिक आरेखों के लिए डिज़ाइन किया गया है जिनमें छवि प्लेसहोल्डर होते हैं। स्लाइड में SmartArt ऑब्जेक्ट जोड़ते समय [SmartArtLayoutType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` मान का प्रयोग करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या SmartArt RTL भाषाओं के लिए मिररिंग या रिवर्सिंग का समर्थन करता है?**

हां। [SmartArt.setReversed](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/#setReversed) मेथड चयनित SmartArt लेआउट द्वारा रिवर्सल समर्थित होने पर आरेख की दिशा को बाएँ‑से‑दाएँ से दाएँ‑से‑बाएँ, या वापस, बदलता है।

**मैं फ़ॉर्मेटिंग को बरकरार रखते हुए SmartArt को उसी स्लाइड या किसी अन्य प्रस्तुति में कैसे कॉपी कर सकता हूँ?**

आप SmartArt आकार को [clone the SmartArt shape](/slides/hi/python-java/shape-manipulations/) के साथ [ShapeCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addClone) का उपयोग करके या SmartArt वाली पूरी स्लाइड को [clone the whole slide](/slides/hi/python-java/clone-slides/) करके क्लोन कर सकते हैं। दोनों तरीकों से आकार, स्थिति और फ़ॉर्मेटिंग बरकरार रहती है।

**मैं SmartArt को पूर्वावलोकन या वेब निर्यात के लिए रास्टर छवि में कैसे रेंडर करूँ?**

[Render the slide](/slides/hi/python-java/convert-powerpoint-to-png/) या पूरी प्रस्तुति को PNG या JPEG में बदलें। SmartArt स्लाइड का हिस्सा होने के कारण रेंडर होता है।

**यदि स्लाइड पर कई SmartArt ऑब्जेक्ट हैं तो मैं एक विशिष्ट SmartArt ऑब्जेक्ट कैसे खोज सकता हूँ?**

SmartArt आकार पर एक विशिष्ट [Shape.getAlternativeText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getAlternativeText) या [Shape.getName](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getName) मान सेट करें, फिर उस मान को [BaseSlide.getShapes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseslide/#getShapes) में खोजें, और यह सुनिश्चित करें कि मेल खाने वाला आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) है।