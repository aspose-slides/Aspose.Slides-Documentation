---
title: Python के माध्यम से Java में प्रस्तुतियों में कनेक्टर प्रबंधित करें
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/python-java/connector/
keywords:
- कनेक्टर
- कनेक्टर प्रकार
- कनेक्टर बिंदु
- कनेक्टर रेखा
- कनेक्टर कोण
- कनेक्शन साइट
- समायोजन बिंदु
- आकारों को जोड़ें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python के लिए Aspose.Slides (Java के माध्यम से) के साथ सीधी, मुड़ी और घुमावदार PowerPoint कनेक्टर को जोड़ना, संलग्न करना, पुनःमार्गित करना, समायोजित करना और निरीक्षण करना सीखें।"
---
## **अवलोकन**

एक कनेक्टर एक रेखा होती है जो किसी भी आकार के 움직ने पर दो आकारों से जुड़ी रह सकती है। इसके सिरें कनेक्शन साइट्स से जुड़ी होती हैं, जिन्हें PowerPoint में हरे बिंदुओं द्वारा दर्शाया जाता है। कुछ मोड़े और घुमावदार कनेक्टर भी समायोजन बिंदु दिखाते हैं, जिन्हें नारंगी बिंदुओं द्वारा दर्शाया जाता है, जो व्यक्तिगत कनेक्टर खंडों की स्थिति को नियंत्रित करते हैं।

Aspose.Slides कनेक्टर को [कनेक्टर](https://reference.aspose.com/slides/hi/python-java/aspose.slides/connector/) क्लास के माध्यम से दर्शाता है। आप उन्हें बना सकते हैं, उनके सिरों को आकारों से जोड़ सकते हैं, कनेक्शन साइट्स चुन सकते हैं, उन्हें पुनःमार्गित कर सकते हैं, और उन कनेक्टरों की ज्यामिति बदल सकते हैं जिनमें समायोजन बिंदु होते हैं।

## **कनेक्टर प्रकार**

ShapeType क्लास में सीधी, मुड़ी, और घुमावदार कनेक्टर प्रीसेट शामिल हैं। निम्न तालिका उपलब्ध कनेक्टर ज्यामिति और प्रत्येक प्रीसेट द्वारा परिभाषित समायोजन बिंदुओं की संख्या दिखाती है।

| कनेक्टर | छवि | समायोजन बिंदुओं की संख्या |
|---|---|---|
| [ShapeType.Line](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#Line) | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| [ShapeType.StraightConnector1](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#StraightConnector1) | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| [ShapeType.BentConnector2](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#BentConnector2) | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| [ShapeType.BentConnector3](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#BentConnector3) | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| [ShapeType.BentConnector4](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#BentConnector4) | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| [ShapeType.BentConnector5](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#BentConnector5) | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| [ShapeType.CurvedConnector2](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#CurvedConnector2) | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| [ShapeType.CurvedConnector3](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#CurvedConnector3) | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| [ShapeType.CurvedConnector4](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#CurvedConnector4) | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| [ShapeType.CurvedConnector5](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapetype/#CurvedConnector5) | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

समायोजन बिंदुओं की संख्या और अर्थ चयनित कनेक्टर प्रीसेट का हिस्सा होते हैं। यह न मानें कि दो विभिन्न कनेक्टर प्रकार समान संग्रह लेआउट प्रदर्शित करते हैं।

## **दो आकारों को जोड़ें**

एक कनेक्टर जोड़ने के लिए [ShapeCollection.addConnector](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapecollection/#addConnector) का उपयोग करें, और उसके सिरों को जोड़ने के लिए [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/connector/#setStartShapeConnectedTo) तथा [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/hi/python-java/aspose.slides/connector/#setEndShapeConnectedTo) का उपयोग करें। दोनों सिर जुड़े होने के बाद, [Connector.reroute](https://reference.aspose.com/slides/hi/python-java/aspose.slides/connector/#reroute) आकारों के बीच एक छोटा मार्ग चुनता है।

निम्न उदाहरण एक दीर्घवृत्त और एक आयत को मुड़े कनेक्टर से जोड़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)
    connector.reroute()

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
reroute को कॉल करने से [setStartShapeConnectionSiteIndex] और [setEndShapeConnectionSiteIndex] मान बदल सकते हैं। यदि उन साइटों को स्थिर रखना है तो पुनःमार्गित करने के बाद विशिष्ट कनेक्शन साइट्स असाइन करें।
{{% /alert %}}

## **एक कनेक्शन साइट चुनें**

प्रत्येक कनेक्ट करने योग्य आकार अपने साइटों की संख्या [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shape/#getConnectionSiteCount) के माध्यम से रिपोर्ट करता है। कनेक्टर के सिर को असाइन करने से पहले पसंदीदा शून्य-आधारित साइट इंडेक्स को मान्य करें; साइट गिनती आकार ज्यामिति के अनुसार बदलती है।

यह उदाहरण दीर्घवृत्त पर किसी विशेष साइट को कनेक्टर से जोड़ता है जब वह साइट मौजूद होती है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80)
    rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10)

    connector.setStartShapeConnectedTo(ellipse)
    connector.setEndShapeConnectedTo(rectangle)

    preferred_site_index = 2
    if preferred_site_index < ellipse.getConnectionSiteCount():
        connector.setStartShapeConnectionSiteIndex(preferred_site_index)
    else:
        print(f"The ellipse has only {ellipse.getConnectionSiteCount()} connection sites.")

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **कनेक्टर बिंदु समायोजित करें**

समायोजन बिंदुओं वाले कनेक्टर [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/python-java/aspose.slides/geometryshape/#getAdjustments) के माध्यम से उन्हें उजागर करते हैं। प्रत्येक [AdjustValue] की जांच करें और उसे [setRawValue] से बदलने से पहले उसके [getType] मान को देखें। प्रीसेट आकार समायोजनों की पहचान करने के सामान्य नियम [Shape Manipulation](/slides/hi/python-java/shape-manipulations/) में वर्णित हैं।

कनेक्टर समायोजनों की संख्या, क्रम, अर्थ और वैध मान सीमा कनेक्टर प्रीसेट पर निर्भर करती है। समायोजन प्रकार केवल-पठन योग्य है, जबकि समायोजन मान लिखने योग्य है। जब कनेक्टर में समान अर्थ प्रकार के एक से अधिक समायोजन होते हैं तो केवल-पठन योग्य [getName] मेथड अतिरिक्त पहचान प्रदान करता है।

### **एक बाधा के आसपास मार्ग बनाना**

निम्न लेआउट में, दो आकारों के बीच एक [BentConnector5] कनेक्टर तीसरे आकार के माध्यम से गुजरता है:

![connector-obstruction](connector-obstruction.png)

यह कोड बाधित कनेक्टर बनाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

वर्टिकल बेंड को स्थानांतरित करने से मार्ग बदल जाता है ताकि कनेक्टर बाधा को पार कर सके:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

संग्रह इंडेक्स `1` हमेशा वर्टिकल बेंड को दर्शाता है, यह मानने के बजाय, यह उदाहरण [ConnectorBendPositionY] को खोजता है और केवल तब बदलता है जब अपेक्षित अर्थ प्रकार मौजूद हो:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75)
    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setStartShapeConnectionSiteIndex(2)

    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.setRawValue(60000)
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

एक [BentConnector5] में दो [ConnectorBendPositionX] समायोजन और एक [ConnectorBendPositionY] समायोजन होता है। यदि आपको आवश्यक प्रकार एक से अधिक बार मिलता है, तो चयन करने से पहले [getName] और उस प्रीसेट की ज्ञात ज्यामिति की जाँच करें। यदि कोई समायोजन [ShapeAdjustmentType.Custom] रिपोर्ट करता है, तो उसके अर्थ और सीमा को प्रीसेट-विशिष्ट मानें और तब तक न बदलें जब तक वह अनुबंध ज्ञात न हो।

## **समायोजन मानों को कनेक्टर ज्यामिति से संबंधित करें**

मुड़े कनेक्टरों के लिए, समायोजन मानों का उपयोग व्यक्तिगत खंडों की स्थितियों का अनुमान लगाने के लिए किया जा सकता है। ये गणनाएँ कनेक्टर प्रीसेट के लिए विशिष्ट हैं:

- [BentConnector4] आमतौर पर एक [ConnectorBendPositionX] और एक [ConnectorBendPositionY] समायोजन उजागर करता है।
- इन बेंड स्थितियों के लिए, [getRawValue] द्वारा लौटाए गए मान को `100000.0` से विभाजित करने से कनेक्टर फ्रेम की चौड़ाई या ऊँचाई का वह अंश मिलता है जिसका उपयोग नीचे के उदाहरण करते हैं।
- एक कनेक्टर फ्रेम को घुमाया या फ़्लिप किया जा सकता है, इसलिए फ्रेम निर्देशांक को स्लाइड निर्देशांक से तुलना करने से पहले परिवर्तित करना आवश्यक है।

निम्न उदाहरण पहले [getType] का उपयोग करके समायोजन की पहचान करते हैं। वे संग्रह इंडेक्स को पोर्टेबल पहचानकर्ता नहीं मानते।

### **नॉन-रोटेटेड कनेक्टर**

प्रारंभिक लेआउट में दो टेक्स्ट आकार होते हैं जो एक [BentConnector4] द्वारा जुड़े होते हैं:

![connector-shape-complex](connector-shape-complex.png)

यह उदाहरण कनेक्टर की जांच करता है और उसके क्षैतिज तथा लंबवत बेंड समायोजन प्राप्त करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, LineArrowheadStyle, FillType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    target_shape.getTextFrame().setText("To")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        print(f"{adjustment.getName()}: {adjustment.getType()}, raw value = {adjustment.getRawValue()}")
finally:
    presentation.dispose()
```

दोनों बेंड बदलने के लिए, प्रत्येक अपेक्षित प्रकार को locate करें और दोनों मिलने के बाद ही मान बदलें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणामस्वरूप एक कनेक्टर बनता है जिसका क्षैतिज और लंबवत खंड स्थानांतरित हो गया है:

![connector-adjusted-1](connector-adjusted-1.png)

एक बार अर्थपूर्ण प्रकार ज्ञात हो जाने पर, उनके मानों को कनेक्टर-फ़्रेम निर्देशांक में बदल सकते हैं। यह उदाहरण दो बेंड समायोजन द्वारा नियंत्रित लंबवत खंड के ऊपर एक पतला आयत खींचता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, ShapeAdjustmentType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(3)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(2)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.getX() + connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        y = connector.getY()
        height = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

गाइड आकार गणना किए गए खंड को चिह्नित करता है:

![connector-adjusted-2](connector-adjusted-2.png)

### **घुमा या फ़्लिप किया गया कनेक्टर**

जब समान कनेक्टर ज्यामिति को वर्टिकली अभिविन्यस्त किया जाता है, तो उसके [Shape.getFrame], [ShapeFrame.getFlipH] और [ShapeFrame.getFlipV] मान कनेक्टर-फ़्रेम निर्देशांक से स्लाइड निर्देशांक में परिवर्तन को प्रभावित करते हैं।

यह उदाहरण वर्टिकल रूप से अभिविन्यस्त कनेक्टर बनाता और समायोजित करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, LineArrowheadStyle, FillType, ShapeAdjustmentType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    source_shape.getTextFrame().setText("From")
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    target_shape.getTextFrame().setText("To 1")
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle)
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    connector_color = Color(102, 205, 170)
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connector_color)
    connector.getLineFormat().setWidth(3)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            adjustment.setRawValue(adjustment.getRawValue() + 20000)
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            adjustment.setRawValue(adjustment.getRawValue() + 200000)

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

समायोजित कनेक्टर आकारों के बीच वर्टिकली दिखाई देता है:

![connector-adjusted-3](connector-adjusted-3.png)

एक मनमाने घुमाव कोण `alpha` के लिए, फ्रेम केंद्र `(x0, y0)` के चारों ओर कनेक्टर-फ़्रेम बिंदु `(x, y)` को घुमाएं:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

निम्न कोड इस उदाहरण में उपयोग किए गए 90-डिग्री अभिविन्यास को संभालता है और संबंधित कनेक्टर खंड के ऊपर एक लाल गाइड खींचता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat, FillType, ShapeAdjustmentType, NullableBool

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25)
    connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300)
    connector.setStartShapeConnectedTo(source_shape)
    connector.setStartShapeConnectionSiteIndex(2)
    connector.setEndShapeConnectedTo(target_shape)
    connector.setEndShapeConnectionSiteIndex(3)

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(connector.getAdjustments().size()):
        adjustment = connector.getAdjustments().get_Item(adjustment_index)
        if adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX:
            horizontal_bend = adjustment
        elif adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.setRawValue(horizontal_bend.getRawValue() + 20000)
        vertical_bend.setRawValue(vertical_bend.getRawValue() + 200000)

        x = connector.getX()
        y = connector.getY()
        if connector.getFrame().getFlipH() == NullableBool.True_:
            x += connector.getWidth()
        if connector.getFrame().getFlipV() == NullableBool.True_:
            y += connector.getHeight()

        x += connector.getWidth() * horizontal_bend.getRawValue() / 100000.0
        rotated_x = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY()
        rotated_y = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY()
        segment_width = connector.getHeight() * vertical_bend.getRawValue() / 100000.0
        guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotated_x, rotated_y, segment_width, 1)
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid)
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

समन्वय परिवर्तन के बाद लाल गाइड गणना किए गए खंड को चिह्नित करता है:

![connector-adjusted-4](connector-adjusted-4.png)

ये सूत्र उदाहरणों में उपयोग किए गए प्रीसेट को वर्णित करते हैं, न कि एक सार्वभौमिक कनेक्टर मॉडल को। अलग प्रीसेट पर वही गणना लागू करने से पहले समायोजन प्रकार, फ्रेम अभिविन्यास, और मान सीमा को मान्य करें।

## **कनेक्टर दिशा कोण खोजें**

एक सीधा कनेक्टर की दिशा उसकी चौड़ाई और ऊँचाई से गणना की जा सकती है, जिसमें क्षैतिज और लंबवत फ़्लिप लागू होते हैं। निम्न उदाहरण स्लाइड निर्देशांक में सकारात्मक क्षैतिज अक्ष से घड़ी की दिशा में कोण रिपोर्ट करता है:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, NullableBool

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100)

    flip_h = connector.getFrame().getFlipH() == NullableBool.True_
    flip_v = connector.getFrame().getFlipV() == NullableBool.True_
    delta_x = connector.getWidth() * (-1 if flip_h else 1)
    delta_y = connector.getHeight() * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
finally:
    presentation.dispose()
```

## **FAQ**

**मैं कैसे पता करूँ कि कनेक्टर किसी आकार से जुड़ सकता है या नहीं?**  
आकार के [getConnectionSiteCount] मान की जाँच करें। सकारात्मक गणना का अर्थ है कि आकार कनेक्शन साइट्स उजागर करता है। किसी भी कनेक्टर सिर को असाइन करने से पहले चयनित साइट इंडेक्स को मान्य करें।

**क्या मैं कनेक्टर समायोजन को उसके संग्रह इंडेक्स से पहचान सकता हूँ?**  
इंडेक्स केवल ज्ञात कनेक्टर प्रीसेट और संग्रह लेआउट के लिए ही अर्थपूर्ण है। मान बदलने से पहले [AdjustValue.getType] की जाँच करें, और जब समान अर्थ प्रकार एक से अधिक बार हो तो अतिरिक्त जानकारी के लिए [AdjustValue.getName] का प्रयोग करें।

**जब जुड़ा हुआ आकार हटाया जाता है तो क्या होता है?**  
संबंधित कनेक्टर का सिर अलग हो जाता है। कनेक्टर स्लाइड पर बना रहता है और इसे हटाया जा सकता है, स्वतंत्र रेखा के रूप में स्थित किया जा सकता है, या किसी अन्य आकार से जोड़ा जा सकता है।

**क्या स्लाइड कॉपी करने पर कनेक्टर बाइंडिंग्स संरक्षित रहती हैं?**  
जब जुड़े हुए आकार स्लाइड के साथ कॉपी किए जाते हैं तो बाइंडिंग्स सामान्यतः संरक्षित रहती हैं। यदि कनेक्टर को उसके लक्ष्य आकारों में से किसी एक के बिना कॉपी किया जाता है, तो प्रभावित सिर को फिर से जोड़ना होगा।