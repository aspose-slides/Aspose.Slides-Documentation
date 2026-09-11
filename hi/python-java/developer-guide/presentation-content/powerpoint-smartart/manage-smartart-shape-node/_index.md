---
title: Python का उपयोग करके प्रस्तुतियों में SmartArt आकार नोड्स का प्रबंधन
linktitle: SmartArt आकार नोड
type: docs
weight: 30
url: /hi/python-java/manage-smartart-shape-node/
keywords:
- SmartArt नोड
- चाइल्ड नोड
- नोड जोड़ें
- नोड स्थिति
- नोड तक पहुंचें
- नोड हटाएँ
- कस्टम स्थिति
- सहायक नोड
- भरन स्वरूप
- नोड रेंडर करें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ PPT और PPTX में SmartArt आकार नोड्स को प्रबंधित करें। स्पष्ट कोड नमूने और टिप्स प्राप्त करें ताकि आपकी प्रस्तुतियां सहज हो सकें।"
---
## **अवलोकन**

PowerPoint प्रस्तुति में SmartArt ग्राफिक्स को उन नोड्स के माध्यम से व्यवस्थित किया जाता है जो पाठ को शामिल करते हैं और आरेख की संरचना को परिभाषित करते हैं। Aspose.Slides आपको इन SmartArt नोड्स के साथ प्रोग्रामेटिक रूप से काम करने की सुविधा देता है: नए नोड और चाइल्ड नोड जोड़ना, किसी निर्दिष्ट स्थिति पर चाइल्ड नोड डालना, मौजूदा नोड्स तक पहुंचना, और उनके पाठ, स्तर और स्थिति को पढ़ना।

यह लेख SmartArt आकार नोड्स का प्रबंधन कैसे किया जाए समझाता है। यह दिखाता है कि नोड्स को कैसे हटाया जाए, इंडेक्स या स्थिति द्वारा चाइल्ड नोड्स के साथ कैसे कार्य किया जाए, सहायक नोड को सामान्य नोड में कैसे बदला जाए, SmartArt नोड आकारों की स्थिति, आकार और घूर्णन को कैसे समायोजित किया जाए, नोड भराव स्वरूप को कैसे सेट किया जाए, और SmartArt चाइल्ड नोड की थंबनेल छवि कैसे उत्पन्न की जाए।

## **SmartArt नोड जोड़ें**
Aspose.Slides for Python via Java SmartArt आकारों को प्रबंधित करने के लिए एक API प्रदान करता है। निम्न उदाहरण एक SmartArt आकार में एक नोड और एक चाइल्ड नोड जोड़ता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं और जिसमें SmartArt आकार हो वह प्रस्तुति लोड करें।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर मौजूद प्रत्येक आकार में क्रमबद्ध रूप से जाएँ।
4. जांचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. SmartArt आकार की [node collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/#getAllNodes) में एक नया नोड [Add a new node](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnodecollection/#addNode) जोड़ें और उसके पाठ को [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) के माध्यम से सेट करें।
6. नए नोड में एक [child node](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#getChildNodes) [Add](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnodecollection/#addNode) करके जोड़ें और उसके पाठ को [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) के माध्यम से सेट करें।
7. प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **विशिष्ट स्थिति पर SmartArt नोड जोड़ें**
निम्न उदाहरण एक SmartArt नोड में विशिष्ट स्थिति पर एक चाइल्ड नोड जोड़ता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. स्लाइड पर [StackedList](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartlayouttype/#StackedList) लेआउट के साथ एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) आकार जोड़ें।
4. जोड़े गए SmartArt आकार के पहले नोड तक पहुंचें।
5. चयनित नोड में स्थिति 2 पर एक चाइल्ड नोड [addNodeByPosition](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) का उपयोग करके जोड़ें और उसके पाठ को सेट करें।
6. प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt नोड तक पहुंचें**
निम्न उदाहरण एक SmartArt आकार में नोड्स तक पहुंचता है। [getLayout](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/#getLayout) द्वारा लौटाए गए लेआउट को केवल पढ़ा जा सकता है और SmartArt आकार जोड़े जाने पर सेट होता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं और जिसमें SmartArt आकार हो वह प्रस्तुति लोड करें।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर मौजूद प्रत्येक आकार में क्रमबद्ध रूप से जाएँ।
4. जांचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. SmartArt आकार में सभी [nodes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/#getAllNodes) को क्रमबद्ध रूप से पढ़ें।
6. प्रत्येक SmartArt नोड की स्थिति, स्तर और पाठ को पढ़ें और प्रदर्शित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```


## **SmartArt चाइल्ड नोड तक पहुंचें**
निम्न उदाहरण एक SmartArt आकार में प्रत्येक नोड के चाइल्ड नोड्स तक पहुंचता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं और जिसमें SmartArt आकार हो वह प्रस्तुति लोड करें।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर मौजूद प्रत्येक आकार में क्रमबद्ध रूप से जाएँ।
4. जांचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. SmartArt आकार में सभी [nodes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/#getAllNodes) को क्रमबद्ध रूप से पढ़ें।
6. प्रत्येक नोड के लिए उसके [child nodes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#getChildNodes) को क्रमबद्ध रूप से पढ़ें।
7. प्रत्येक [child node](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#getChildNodes) की स्थिति, स्तर और पाठ को पढ़ें और प्रदर्शित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **विशिष्ट स्थिति पर SmartArt चाइल्ड नोड तक पहुंचें**
निम्न उदाहरण एक पैरेंट नोड के संग्रह में विशिष्ट सूचकांक पर स्थित चाइल्ड नोड तक पहुंचता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. [StackedList](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartlayouttype/#StackedList) लेआउट के साथ एक SmartArt आकार जोड़ें।
4. जोड़े गए SmartArt आकार तक पहुंचें।
5. SmartArt आकार में सूचकांक 0 पर नोड तक पहुंचें।
6. [get_Item](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnodecollection/#get_Item) का उपयोग करके सूचकांक 1 पर चाइल्ड नोड तक पहुंचें।
7. उस [child node](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#getChildNodes) की स्थिति, स्तर और पाठ को पढ़ें और प्रदर्शित करें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **SmartArt नोड हटाएँ**
निम्न उदाहरण एक SmartArt आकार से नोड हटाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं और जिसमें SmartArt आकार हो वह प्रस्तुति लोड करें।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर मौजूद प्रत्येक आकार में क्रमबद्ध रूप से जाएँ।
4. जांचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. पुष्टि करें कि [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) आकार में कम से कम एक नोड हो।
6. हटाने के लिए SmartArt नोड का चयन करें।
7. चुने गए नोड को [removeNode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnodecollection/#removeNode) का उपयोग करके हटाएँ।
8. प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **विशिष्ट स्थिति से SmartArt नोड हटाएँ**
निम्न उदाहरण एक SmartArt नोड के संग्रह में विशिष्ट सूचकांक पर स्थित चाइल्ड नोड हटाता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं और जिसमें SmartArt आकार हो वह प्रस्तुति लोड करें।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर मौजूद प्रत्येक आकार में क्रमबद्ध रूप से जाएँ।
4. जांचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. यदि मौजूद हो तो सूचकांक 0 पर SmartArt नोड तक पहुंचें।
6. पुष्टि करें कि चयनित SmartArt नोड में कम से कम दो चाइल्ड नोड हों।
7. सूचकांक 1 पर चाइल्ड नोड को [removeNode](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnodecollection/#removeNode) का उपयोग करके हटाएँ।
8. प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt ऑब्जेक्ट में चाइल्ड नोड के लिए कस्टम स्थिति सेट करें**
Aspose.Slides for Python via Java [SmartArtShape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartshape/) की स्थिति को [setX](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setX) और [setY](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#setY) के द्वारा सेट करने का समर्थन करता है। निम्न उदाहरण SmartArt नोड आकारों के लिए कस्टम स्थिति, आकार और घूर्णन सेट करता है। नए नोड जोड़ने से सभी नोड्स की स्थितियों और आकारों की पुनर्गणना होती है। कस्टम पोजिशनिंग से आप आवश्यकता अनुसार नोड्स को व्यवस्थित कर सकते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **सहायक नोड की जाँच करें**
{{% alert color="info" title="Note" %}} 

यह अनुभाग Aspose.Slides for Python via Java का उपयोग करके प्रोग्रामेटिक रूप से प्रस्तुति स्लाइड्स में जोड़ें गए SmartArt आकारों का अन्वेषण करता है।

{{% /alert %}} 

निम्न स्रोत SmartArt आकार इस उदाहरण में उपयोग किया गया है।

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**चित्र: स्लाइड पर स्रोत SmartArt आकार**|

निम्न उदाहरण SmartArt नोड संग्रह में सहायक नोड्स की पहचान करता है और उन्हें सामान्य नोड में बदलता है।

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं और जिसमें SmartArt आकार हो वह प्रस्तुति लोड करें।
2. उसके सूचकांक द्वारा पहली स्लाइड प्राप्त करें।
3. पहली स्लाइड पर मौजूद प्रत्येक आकार में क्रमबद्ध रूप से जाएँ।
4. जांचें कि क्या आकार एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) इंस्टेंस है।
5. SmartArt आकार में सभी नोड्स को क्रमबद्ध रूप से पढ़ें और जांचें कि क्या वे [Assistant Nodes](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartnode/#isAssistant) हैं।
6. प्रत्येक सहायक नोड को सामान्य नोड में बदलें।
7. प्रस्तुति को सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**चित्र: स्लाइड पर SmartArt आकार में बदलें गए सहायक नोड**|

## **नोड के Fill Format को सेट करें**
Aspose.Slides for Python via Java कस्टम SmartArt आकार जोड़ने और उनके Fill Format को सेट करने की सुविधा प्रदान करता है। यह लेख बताता है कि कैसे SmartArt आकार बनाएँ, पहुँचें और उनके Fill Format को Aspose.Slides for Python via Java का उपयोग करके सेट करें।

कृपया नीचे दिए गए चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं।
2. किसी स्लाइड को उसके सूचकांक द्वारा प्राप्त करें।
3. [ClosedChevronProcess](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess) लेआउट के साथ एक [SmartArt](https://reference.aspose.com/slides/hi/python-java/aspose.slides/smartart/) आकार जोड़ें।
4. SmartArt आकार नोड्स के लिए [FillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getFillFormat) सेट करें।
5. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **SmartArt चाइल्ड नोड की थंबनेल उत्पन्न करें**
SmartArt चाइल्ड नोड की थंबनेल उत्पन्न करने के लिए निम्न चरणों का पालन करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) वर्ग का उदाहरण बनाएं।
2. एक SmartArt आकार [Add a SmartArt shape](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addSmartArt) जोड़ें।
3. किसी नोड को उसके सूचकांक द्वारा प्राप्त करें।
4. थंबनेल छवि प्राप्त करें।
5. थंबनेल छवि को किसी भी इच्छित इमेज फ़ॉर्मेट में सहेजें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**क्या SmartArt एनीमेशन समर्थित है?**

हाँ। SmartArt को एक सामान्य आकार के रूप में माना जाता है, इसलिए आप [मानक एनीमेशन लागू करें](/slides/hi/python-java/shape-animation/) (प्रवेश, निकास, ज़ोर, मोशन पाथ) कर सकते हैं और समय‑समायोजन कर सकते हैं। आवश्यकता पड़ने पर आप SmartArt नोड्स के भीतर आकारों को भी एनिमेट कर सकते हैं।

**यदि किसी स्लाइड पर SmartArt का आंतरिक ID अज्ञात हो तो उसे विश्वसनीय रूप से कैसे खोजें?**

[alternative text](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getAlternativeText) द्वारा असाइन और खोजें। SmartArt पर विशिष्ट alternative text सेट करने से आप इसे प्रोग्रामेटिक रूप से खोज सकते हैं बिना आंतरिक पहचानकर्ता पर निर्भर किए।

**जब प्रस्तुति को PDF में बदलते हैं तो क्या SmartArt का रूप बरकरार रहेगा?**

हाँ। Aspose.Slides [PDF export](/slides/hi/python-java/convert-powerpoint-to-pdf/) के दौरान SmartArt को उच्च दृश्य साम्य के साथ रेंडर करता है, जिससे लेआउट, रंग और प्रभाव संरक्षित रहते हैं।

**क्या मैं पूरे SmartArt की छवि (पूर्वावलोकन या रिपोर्ट के लिए) निकाल सकता हूँ?**

हाँ। आप SmartArt आकार को [रास्टर फ़ॉर्मेट्स]https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getImage) या [SVG]https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#writeAsSvgToBytes) में रेंडर कर सकते हैं, जिससे थंबनेल, रिपोर्ट या वेब उपयोग के लिए स्केलेबल वेक्टर आउटपुट प्राप्त होता है।