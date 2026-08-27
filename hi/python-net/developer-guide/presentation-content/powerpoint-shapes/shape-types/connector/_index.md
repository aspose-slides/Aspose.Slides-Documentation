---
title: Python के साथ प्रस्तुतियों में कनेक्टरों का प्रबंधन
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/python-net/connector/
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
description: "Aspose.Slides for Python के साथ .NET के माध्यम से सीधी, मुड़ी और घुमावदार PowerPoint कनेक्टरों को जोड़ना, संलग्न करना, पुनः मार्गित करना, समायोजित करना और निरीक्षण करना सीखें।"
---
## **अवलोकन**

कनेक्टर एक रेखा है जो किसी भी आकार के 움직ने पर भी दो आकारों से जुड़ी रह सकती है। इसके अंत कनेक्शन साइटों से जुड़ते हैं, जो PowerPoint में हरे बिंदुओं द्वारा दर्शाए जाते हैं। कुछ मुड़े और घुमावदार कनेक्टर भी समायोजन बिंदु प्रकट करते हैं, जो नारंगी बिंदुओं द्वारा दर्शाए जाते हैं, और व्यक्तिगत कनेक्टर भागों की स्थिति को नियंत्रित करते हैं।

Aspose.Slides कनेक्टरों को [IConnector](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iconnector/) इंटरफ़ेस के माध्यम से प्रदर्शित करता है। आप इन्हें बना सकते हैं, उनके अंत को आकारों से जोड़ सकते हैं, कनेक्शन साइट चुन सकते हैं, उन्हें पुनः मार्गित कर सकते हैं, और उन कनेक्टरों की ज्यामिति संशोधित कर सकते हैं जिनमें समायोजन बिंदु होते हैं।

## **कनेक्टर प्रकार**

[ShapeType](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapetype/) enumeration में सीधा, मुड़वाँ, और घुमावदार कनेक्टर प्रीसेट शामिल हैं। नीचे दी गई तालिका में उपलब्ध कनेक्टर ज्यामिति और प्रत्येक प्रीसेट द्वारा परिभाषित समायोजन बिंदुओं की संख्या दर्शाई गई है।

| कनेक्टर | छवि | समायोजन बिंदुओं की संख्या |
|---|---|---|
| `ShapeType.LINE` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BENT_CONNECTOR2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BENT_CONNECTOR3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BENT_CONNECTOR4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BENT_CONNECTOR5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CURVED_CONNECTOR2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CURVED_CONNECTOR3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CURVED_CONNECTOR4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CURVED_CONNECTOR5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

समायोजन बिंदुओं की संख्या और अर्थ चयनित कनेक्टर प्रीसेट का हिस्सा होते हैं। यह मानना उचित नहीं है कि दो अलग-अलग कनेक्टर प्रकार समान संग्रह लेआउट दिखाते हैं।

## **दो आकारों को जोड़ें**

[IShapeCollection.add_connector](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapecollection/add_connector/) का उपयोग करके एक कनेक्टर जोड़ें, और उसके [start_shape_connected_to](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iconnector/start_shape_connected_to/) और [end_shape_connected_to](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iconnector/end_shape_connected_to/) गुण नियत करें। दोनों अंत जुड़ जाने के बाद, [IConnector.reroute](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iconnector/reroute/) आकारों के बीच एक छोटा मार्ग चुनता है।

निम्नलिखित उदाहरण मुड़े कनेक्टर के साथ एक अंडाकार और एक आयत को जोड़ता है:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle
    connector.reroute()

    presentation.save("connected-shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="warning" title="Warning" %}}
`reroute` को कॉल करने से [start_shape_connection_site_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iconnector/start_shape_connection_site_index/) और [end_shape_connection_site_index](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iconnector/end_shape_connection_site_index/) मान बदल सकते हैं। यदि इन साइटों को स्थिर रखना आवश्यक है तो पुनः मार्गित करने के बाद विशिष्ट कनेक्शन साइटें नियत करें।
{{% /alert %}}

## **कनेक्शन साइट चुनें**

प्रत्येक कनेक्टेबल आकार अपने साइटों की संख्या [connection_site_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides/igeometryshape/connection_site_count/) के माध्यम से रिपोर्ट करता है। कनेक्टर के अंत को साइट नियत करने से पहले वांछित शून्य-आधारित साइट सूचकांक को सत्यापित करें; साइटों की संख्या आकार की ज्यामिति के अनुसार भिन्न होती है।

यह उदाहरण तब अंडाकार पर किसी विशिष्ट साइट से कनेक्टर को जोड़ता है जब वह साइट मौजूद हो:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    ellipse = slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 40, 80, 120, 80)
    rectangle = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 320, 240, 140, 80)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    preferred_site_index = 2
    if preferred_site_index < ellipse.connection_site_count:
        connector.start_shape_connection_site_index = preferred_site_index
    else:
        print(f"The ellipse has only {ellipse.connection_site_count} connection sites.")

    presentation.save("specific-connection-site.pptx", slides.export.SaveFormat.PPTX)
```

## **कनेक्टर बिंदु समायोजित करें**

समायोजन बिंदुओं वाले कनेक्टर [IGeometryShape.adjustments](https://reference.aspose.com/slides/hi/python-net/aspose.slides/igeometryshape/adjustments/) के माध्यम से इन्हें उजागर करते हैं। प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iadjustvalue/) को निरीक्षण करें और उसके [type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iadjustvalue/type/) को बदलने से पहले जांचें, तथा उसके [raw_value](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iadjustvalue/raw_value/) को बदलें। सामान्य आकार हेर-फेर के लिए, देखें [Shape Manipulation](/slides/hi/python-net/shape-manipulations/)।

कनेक्टर समायोजन की संख्या, क्रम, अर्थ और वैध मान सीमा कनेक्टर प्रीसेट पर निर्भर करती है। `type` गुण केवल पढ़ने के लिए है, जबकि समायोजन मान लिखने योग्य है। केवल पढ़ने योग्य [name](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iadjustvalue/name/) गुण अतिरिक्त पहचान प्रदान करता है जब कनेक्टर में समान अर्थ के कई समायोजन होते हैं।

### **रुकाव के चारों ओर मार्ग**

निम्न लेआउट में, दो आकारों के बीच `ShapeType.BENT_CONNECTOR5` कनेक्टर तीसरे आकार के माध्यम से जाता है:
![connector-obstruction](connector-obstruction.png)

यह कोड बाधित कनेक्टर बनाता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    presentation.save("connector-obstruction.pptx", slides.export.SaveFormat.PPTX)
```

ऊर्ध्वाधर मोड़ को ले जाने से मार्ग बदल जाता है जिससे कनेक्टर बाधा को बायपास करता है:
![connector-obstruction-fixed](connector-obstruction-fixed.png)

संग्रह सूचकांक `1` हमेशा ऊर्ध्वाधर मोड़ को दर्शाता है, यह मानने के बजाय, यह उदाहरण `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` को खोजता है और केवल तब बदलता है जब अपेक्षित अर्थ प्रकार मौजूद हो:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    connector.start_shape_connected_to = source_shape
    connector.end_shape_connected_to = target_shape
    connector.start_shape_connection_site_index = 2

    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment
            break

    if vertical_bend is None:
        print("The connector does not expose a vertical bend adjustment.")
    else:
        vertical_bend.raw_value = 60000
        presentation.save("connector-obstruction-fixed.pptx", slides.export.SaveFormat.PPTX)
```

`ShapeType.BENT_CONNECTOR5` में दो `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` समायोजन और एक `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` समायोजन होता है। यदि आवश्यक प्रकार कई बार आता है, तो चयन करने से पहले `name` और उस प्रीसेट की ज्ञात ज्यामिति देखें। यदि कोई समायोजन [ShapeAdjustmentType.CUSTOM](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapeadjustmenttype/) रिपोर्ट करता है, तो उसके अर्थ और सीमा को प्रीसेट-विशिष्ट मानें और तब तक न बदलें जब तक वह अनुबंध ज्ञात न हो।

## **समायोजन मानों को कनेक्टर ज्यामिति से संबंधित करें**

मुड़े कनेक्टरों के लिए, समायोजन मानों का उपयोग व्यक्तिगत खंडों की स्थितियों का अनुमान लगाने के लिए किया जा सकता है। ये गणनाएँ कनेक्टर प्रीसेट के विशिष्ट हैं:

- `ShapeType.BENT_CONNECTOR4` आमतौर पर एक `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X` और एक `ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y` समायोजन उजागर करता है।
- इन मोड़ स्थितियों के लिए, `raw_value / 100000` कनेक्टर फ्रेम की चौड़ाई या ऊँचाई के भाग को उत्पन्न करता है जैसा कि नीचे के उदाहरणों में उपयोग किया गया है।
- कनेक्टर फ्रेम को घुमाया या फ्लिप किया जा सकता है, इसलिए फ्रेम निर्देशांक को स्लाइड निर्देशांक से तुलना करने से पहले रूपांतरित करना आवश्यक है।

निम्नलिखित उदाहरण पहले `type` का उपयोग करके समायोजन की पहचान करते हैं। वे संग्रह सूचकांकों को पोर्टेबल पहचानकर्ता नहीं मानते।

### **अनरोटेटेड कनेक्टर**

प्रारम्भिक लेआउट में दो टेक्स्ट आकार `ShapeType.BENT_CONNECTOR4` द्वारा जुड़े हुए हैं:
![connector-shape-complex](connector-shape-complex.png)

यह उदाहरण कनेक्टर का निरीक्षण करता है और उसके क्षैतिज एवं ऊर्ध्वाधर मोड़ समायोजन प्राप्त करता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    target_shape.text_frame.text = "To"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        print(f"{adjustment.name}: {adjustment.type}, raw value = {adjustment.raw_value}")
```

दोनों मोड़ों को बदलने के लिए, प्रत्येक अपेक्षित प्रकार को खोजें और दोनों मिलने के बाद ही मान बदलें:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000
        presentation.save("connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

परिणामस्वरूप कनेक्टर के क्षैतिज और ऊर्ध्वाधर खंड स्थानांतरित हो जाते हैं:
![connector-adjusted-1](connector-adjusted-1.png)

एक बार अर्थात्मक प्रकार ज्ञात हो जाने पर, उनके मानों को कनेक्टर-फ़्रेम निर्देशांकों में बदला जा सकता है। यह उदाहरण दो मोड़ समायोजन द्वारा नियंत्रित ऊर्ध्वाधर खंड के ऊपर एक पतला आयत बनाता है:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 2

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        x = connector.x + connector.width * horizontal_bend.raw_value / 100000
        y = connector.y
        height = connector.height * vertical_bend.raw_value / 100000
        slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 1, height)
        presentation.save("connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

गाइड आकार गणना किए गए खंड को चिन्हित करता है:
![connector-adjusted-2](connector-adjusted-2.png)

### **घुमाया या फ्लिप किया गया कनेक्टर**

जब वही कनेक्टर ज्यामिति ऊर्ध्वाधर रूप में oriented होती है, तो इसके [frame](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iconnector/frame/), [flip_h](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapeframe/flip_h/), और [flip_v](https://reference.aspose.com/slides/hi/python-net/aspose.slides/ishapeframe/flip_v/) मान कनेक्टर-फ़्रेम निर्देशांक से स्लाइड निर्देशांक में रूपांतरण को प्रभावित करते हैं।

यह उदाहरण ऊर्ध्वाधर दिशा में कनेक्टर बनाता और समायोजित करता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    source_shape.text_frame.text = "From"
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    target_shape.text_frame.text = "To 1"
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)

    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            adjustment.raw_value += 20000
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            adjustment.raw_value += 200000

    presentation.save("vertical-connector-adjusted.pptx", slides.export.SaveFormat.PPTX)
```

समायोजित कनेक्टर आकारों के बीच ऊर्ध्वाधर रूप से दिखाई देता है:
![connector-adjusted-3](connector-adjusted-3.png)

किसी भी घूर्णन कोण `alpha` के लिए, कनेक्टर-फ़्रेम बिंदु `(x, y)` को फ्रेम के केंद्र `(x0, y0)` के चारों ओर घुमाएँ:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

निम्न कोड इस उदाहरण में उपयोग किए गए 90-डिग्री अभिविन्यास को संभालता है और संबंधित कनेक्टर खंड के ऊपर लाल गाइड बनाता है:
```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    source_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.start_shape_connected_to = source_shape
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = target_shape
    connector.end_shape_connection_site_index = 3

    horizontal_bend = None
    vertical_bend = None
    for adjustment_index in range(len(connector.adjustments)):
        adjustment = connector.adjustments[adjustment_index]
        if adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_X:
            horizontal_bend = adjustment
        elif adjustment.type == slides.ShapeAdjustmentType.CONNECTOR_BEND_POSITION_Y:
            vertical_bend = adjustment

    if horizontal_bend is None or vertical_bend is None:
        print("The connector does not expose the expected bend adjustments.")
    else:
        horizontal_bend.raw_value += 20000
        vertical_bend.raw_value += 200000

        x = connector.x
        y = connector.y
        if connector.frame.flip_h == slides.NullableBool.TRUE:
            x += connector.width
        if connector.frame.flip_v == slides.NullableBool.TRUE:
            y += connector.height

        x += connector.width * horizontal_bend.raw_value / 100000
        rotated_x = connector.frame.center_x - y + connector.frame.center_y
        rotated_y = x - connector.frame.center_x + connector.frame.center_y
        segment_width = connector.height * vertical_bend.raw_value / 100000
        guide = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, rotated_x, rotated_y, segment_width, 1)
        guide.line_format.fill_format.fill_type = slides.FillType.SOLID
        guide.line_format.fill_format.solid_fill_color.color = draw.Color.red

        presentation.save("rotated-connector-segment-guide.pptx", slides.export.SaveFormat.PPTX)
```

निर्देशांक रूपांतरण के बाद लाल गाइड गणना किए गए खंड को चिन्हित करता है:
![connector-adjusted-4](connector-adjusted-4.png)

इन सूत्रों में उदाहरणों में उपयोग किए गए प्रीसेट दर्शाए गए हैं, न कि एक सार्वभौमिक कनेक्टर मॉडल। किसी अन्य प्रीसेट पर वही गणना लागू करने से पहले समायोजन प्रकार, फ़्रेम अभिविन्यास और मान रेंज की सत्यापन करें।

## **कनेक्टर दिशा कोण खोजें**

सीधे कनेक्टर की दिशा उसकी चौड़ाई और ऊँचाई से, क्षैतिज और ऊर्ध्वाधर फ्लिप लागू करके, गणना की जा सकती है। नीचे का उदाहरण स्लाइड निर्देशांकों में सकारात्मक क्षैतिज धुरी से घड़ी की दिशा में कोण रिपोर्ट करता है:
```python
import math
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    connector = slide.shapes.add_connector(slides.ShapeType.STRAIGHT_CONNECTOR1, 100, 100, 200, 100)

    flip_h = connector.frame.flip_h == slides.NullableBool.TRUE
    flip_v = connector.frame.flip_v == slides.NullableBool.TRUE
    delta_x = connector.width * (-1 if flip_h else 1)
    delta_y = connector.height * (-1 if flip_v else 1)
    angle = math.atan2(delta_y, delta_x) * 180.0 / math.pi

    if angle < 0:
        angle += 360

    print(f"Connector direction: {angle:.2f} degrees")
```

## **FAQ**

**मैं कैसे पहचानूँ कि कनेक्टर किसी आकार से जुड़ सकता है?**

आकार के [connection_site_count](https://reference.aspose.com/slides/hi/python-net/aspose.slides/igeometryshape/connection_site_count/) को जांचें। सकारात्मक गणना का अर्थ है कि आकार कनेक्शन साइटें उजागर करता है। कनेक्टर के अंत को नियत करने से पहले चयनित साइट सूचकांक को सत्यापित करें।

**क्या मैं संग्रह सूचकांक से कनेक्टर समायोजन की पहचान कर सकता हूँ?**

सूचकांक केवल ज्ञात कनेक्टर प्रीसेट और संग्रह लेआउट के लिए अर्थपूर्ण है। मान बदलने से पहले [IAdjustValue.type](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iadjustvalue/type/) को जांचें, और जब समान अर्थ प्रकार कई बार हो तो अतिरिक्त जानकारी के लिए [IAdjustValue.name](https://reference.aspose.com/slides/hi/python-net/aspose.slides/iadjustvalue/name/) का प्रयोग करें।

**जब जुड़ा हुआ आकार हटाया जाता है तो क्या होता है?**

संबंधित कनेक्टर अंत डिस्कनेक्ट हो जाता है। कनेक्टर स्लाइड पर बना रहता है और उसे हटाया, स्वतंत्र रेखा के रूप में स्थित, या किसी अन्य आकार से जोड़ा जा सकता है।

**क्या स्लाइड कॉपी होने पर कनेक्टर बाइंडिंग्स बनी रहती हैं?**

आमतौर पर बाइंडिंग्स बनी रहती हैं जब जुड़े हुए आकार स्लाइड के साथ कॉपी होते हैं। यदि कोई कनेक्टर उसके लक्ष्य आकारों में से एक के बिना कॉपी किया जाता है, तो प्रभावित अंत को फिर से जोड़ना आवश्यक होता है।