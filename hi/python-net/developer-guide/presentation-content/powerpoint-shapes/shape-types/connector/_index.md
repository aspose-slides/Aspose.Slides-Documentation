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
- आकार जोड़ें
- PowerPoint
- प्रस्तुति
- Python
- Aspose.Slides
description: "Python अनुप्रयोगों को PowerPoint और OpenDocument स्लाइड्स में रेखाएँ बनाना, जोड़ना और स्वतः-मार्गित करने की शक्ति दें - सीधे, कोहनी और घुमावदार कनेक्टरों पर पूर्ण नियंत्रण प्राप्त करें।"
---
## **परिचय**

PowerPoint कनेक्टर एक विशेष रेखा है जो दो आकारों को जोड़ती है और स्लाइड पर आकारों को स्थानांतरित या पुनः स्थित करने पर भी जुड़ी रहती है। कनेक्टर **कनेक्शन पॉइंट्स** (हरे बिंदु) पर आकारों से जुड़ते हैं। कनेक्शन पॉइंट्स तब दिखाई देते हैं जब पॉइंटर उनके पास आता है। कुछ कनेक्टरों पर उपलब्ध **समायोजन हैंडल** (पीले बिंदु) आपको कनेक्टर की स्थिति और आकार को बदलने की अनुमति देता है।

## **कनेक्टर प्रकार**

PowerPoint में आप तीन प्रकार के कनेक्टरों का उपयोग कर सकते हैं: सीधा, कोहनी (कोणीय), और घुमावदार।

Aspose.Slides निम्नलिखित कनेक्टर प्रकारों को समर्थन देता है:

| कनेक्टर प्रकार | छवि | समायोजन बिंदुओं की संख्या |
| ------------------------------- | --------------------------------------------------------- | --------------------------- |
| `ShapeType.LINE`                | ![लाइन कनेक्टर](shapetype-lineconnector.png)            | 0                           |
| `ShapeType.STRAIGHT_CONNECTOR1` | ![सीधा कनेक्टर 1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BENT_CONNECTOR2`     | ![टेढ़ा कनेक्टर 2](shapetype-bent-connector2.png)        | 0                           |
| `ShapeType.BENT_CONNECTOR3`     | ![टेढ़ा कनेक्टर 3](shapetype-bentconnector3.png)         | 1                           |
| `ShapeType.BENT_CONNECTOR4`     | ![टेढ़ा कनेक्टर 4](shapetype-bentconnector4.png)         | 2                           |
| `ShapeType.BENT_CONNECTOR5`     | ![टेढ़ा कनेक्टर 5](shapetype-bentconnector5.png)         | 3                           |
| `ShapeType.CURVED_CONNECTOR2`   | ![घुमावदार कनेक्टर 2](shapetype-curvedconnector2.png)     | 0                           |
| `ShapeType.CURVED_CONNECTOR3`   | ![घुमावदार कनेक्टर 3](shapetype-curvedconnector3.png)     | 1                           |
| `ShapeType.CURVED_CONNECTOR4`   | ![घुमावदार कनेक्टर 4](shapetype-curvedconnector4.png)     | 2                           |
| `ShapeType.CURVED_CONNECTOR5`   | ![घुमावदार कनेक्टर 5](shapetype.curvedconnector5.png)     | 3                           |

## **आकारों को कनेक्टरों से जोड़ें**

यह अनुभाग Aspose.Slides में आकारों को कनेक्टरों से जोड़ने का प्रदर्शन करता है। आप स्लाइड में एक कनेक्टर जोड़ेंगे, उसके प्रारम्भ और अंत को लक्ष्य आकारों से जोड़ेंगे। कनेक्शन साइटों का उपयोग करने से कनेक्टर आकारों से 'जुड़ा' रहता है भले ही वे स्थानांतरित या पुनः आकारित हों।

1. एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में दो [ऑटोशेप](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) वस्तुएँ जोड़ें, `add_auto_shape` मेथड का उपयोग करके जो [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) वस्तु द्वारा उपलब्ध कराई गई है।
1. [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) वस्तु द्वारा उपलब्ध `add_connector` मेथड का उपयोग करके कनेक्टर जोड़ें और कनेक्टर प्रकार निर्दिष्ट करें।
1. आकारों को कनेक्टर के साथ जोड़ें।
1. सबसे छोटा कनेक्शन पथ लागू करने के लिए `reroute` मेथड को कॉल करें।
1. प्रस्तुति को सहेजें।

निम्नलिखित Python कोड दिखाता है कि दो आकारों (एक दीर्घवृत्त और एक आयत) के बीच एक टेढ़ा कनेक्टर कैसे जोड़ें:

```python
import aspose.slides as slides

# PPTX फ़ाइल बनाने के लिए Presentation क्लास का इंस्टेंस बनाएँ।
with slides.Presentation() as presentation:

    # पहली स्लाइड के लिए शैप्स संग्रह तक पहुँचें।
    shapes = presentation.slides[0].shapes

    # एक एलिप्स ऑटोशेप जोड़ें।
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # एक आयत ऑटोशेप जोड़ें।
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # स्लाइड में एक कनेक्टर जोड़ें।
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 10, 10)

    # कनेक्टर के साथ आकारों को जोड़ें।
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # सबसे छोटा मार्ग निर्धारित करने के लिए reroute कॉल करें।
    connector.reroute()

    # प्रस्तुति सहेजें।
    presentation.save("connected_shapes.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="NOTE" color="warning" %}}
`connector.reroute` मेथड कनेक्टर को पुनः मार्गित करता है, जिससे वह आकारों के बीच सबसे छोटा संभावित पथ लेता है। यह करने के लिए, मेथड `start_shape_connection_site_index` और `end_shape_connection_site_index` मानों को बदल सकता है।
{{% /alert %}}

## **कनेक्शन पॉइंट्स निर्दिष्ट करें**

यह अनुभाग Aspose.Slides में किसी आकार पर विशिष्ट कनेक्शन पॉइंट से कनेक्टर को जोड़ने की प्रक्रिया समझाता है। सटीक कनेक्शन साइटों को लक्षित करके, आप कनेक्टर रूटिंग और लेआउट को नियंत्रित कर सकते हैं, जिससे आपके प्रस्तुतियों में साफ और पूर्वानुमेय आरेख बनते हैं।

1. एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. स्लाइड में दो [ऑटोशेप](https://reference.aspose.com/slides/hi/python-net/aspose.slides/autoshape/) वस्तुएँ जोड़ें, `add_auto_shape` मेथड का उपयोग करके जो [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) वस्तु द्वारा उपलब्ध कराई गई है।
1. [ShapeCollection](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shapecollection/) वस्तु द्वारा उपलब्ध `add_connector` मेथड का उपयोग करके कनेक्टर जोड़ें और कनेक्टर प्रकार निर्दिष्ट करें।
1. आकारों को कनेक्टर के साथ जोड़ें।
1. आकारों पर अपने पसंदीदा कनेक्शन पॉइंट सेट करें।
1. प्रस्तुति को सहेजें।

```python
import aspose.slides as slides

# PPTX फ़ाइल बनाने के लिए Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड के लिए शैप्स संग्रह तक पहुँचें।
    shapes = presentation.slides[0].shapes

    # एक एलिप्स ऑटोशेप जोड़ें।
    ellipse = shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 50, 50, 100, 100)

    # एक आयत ऑटोशेप जोड़ें।
    rectangle = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 200, 100, 100)

    # स्लाइड के शैप्स संग्रह में एक कनेक्टर जोड़ें।
    connector = shapes.add_connector(slides.ShapeType.BENT_CONNECTOR3, 0, 0, 10, 10)

    # कनेक्टर से आकारों को जोड़ें।
    connector.start_shape_connected_to = ellipse
    connector.end_shape_connected_to = rectangle

    # एलिप्स पर वांछित कनेक्शन साइट इंडेक्स सेट करें।
    site_index = 6

    # जाँचें कि वांछित इंडेक्स उपलब्ध साइट गिनती के भीतर है।
    if  ellipse.connection_site_count > site_index:
        # एलिप्स ऑटोशेप पर वांछित कनेक्शन साइट असाइन करें।
        connector.start_shape_connection_site_index = site_index

    # प्रस्तुति सहेजें।
    presentation.save("connection_points.pptx", slides.export.SaveFormat.PPTX)
```

## **कनेक्टर बिंदुओं को समायोजित करें**

आप कनेक्टरों को उनके समायोजन बिंदुओं का उपयोग करके संशोधित कर सकते हैं। केवल वही कनेक्टर जो समायोजन बिंदु प्रदान करते हैं, इस प्रकार संपादित किए जा सकते हैं। यह जानने के लिए कि कौन से कनेक्टर समायोजन का समर्थन करते हैं, [Connector Types](/slides/hi/python-net/connector/#connector-types) के तहत तालिका देखें।

### **सरल केस**

एक ऐसी स्थिति पर विचार करें जहाँ दो आकार (A और B) के बीच का कनेक्टर एक तीसरे आकार (C) को काटता है:

![कनेक्टर बाधा](connector-obstruction.png)

कोड उदाहरण:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 300, 150, 150, 75)
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 400, 100, 50)
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 70, 30)
    
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR5, 20, 20, 400, 300)
    
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.black
    
    connector.start_shape_connected_to = shape_from
    connector.end_shape_connected_to = shape_to
    connector.start_shape_connection_site_index = 2
```

तीसरे आकार से बचने के लिए, कनेक्टर को उसकी ऊर्ध्वाधर खंड को बाएँ की ओर ले जाकर समायोजित करें:

![समायोजित कनेक्टर बाधा](connector-obstruction-fixed.png)

```python
    adjustment2 = connector.adjustments[1]
    adjustment2.raw_value += 10000
```

### **जटिल मामलों**

अधिक उन्नत समायोजनों के लिए, निम्नलिखित पर विचार करें:

- कनेक्टर का समायोज्य बिंदु एक सूत्र द्वारा निर्धारित होता है जो उसकी स्थिति को निर्धारित करता है। इस बिंदु को बदलने से कनेक्टर का कुल आकार बदल सकता है।
- कनेक्टर के समायोजन बिंदु एक सख्त क्रमबद्ध एरे में संग्रहीत होते हैं, जो कनेक्टर की शुरुआत से अंत तक क्रमांकित होते हैं।
- समायोजन बिंदु मान कनेक्टर आकार की चौड़ाई/ऊँचाई के प्रतिशत का प्रतिनिधित्व करते हैं।
  - आकार कनेक्टर के प्रारम्भ और अंत बिंदुओं द्वारा सीमित होता है और 1000 द्वारा स्केल किया जाता है।
  - पहला, दूसरा, और तीसरा समायोजन बिंदु क्रमशः: चौड़ाई का प्रतिशत, ऊँचाई का प्रतिशत, और फिर से चौड़ाई का प्रतिशत दर्शाते हैं।
- जब समायोजन बिंदुओं के निर्देशांक की गणना की जाती है, तो कनेक्टर के घुमाव और परावर्तन को ध्यान में रखा जाता है। **नोट:** सभी कनेक्टरों के लिए जो [Connector Types](/slides/hi/python-net/connector/#connector-types) में सूचीबद्ध हैं, घुमाव कोण 0 है।

#### **मामला 1**

दो टेक्स्ट फ्रेम ऑब्जेक्ट को कनेक्टर से जोड़ने की स्थिति पर विचार करें:

![जुड़े आकार](connector-shape-complex.png)

कोड उदाहरण:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX फ़ाइल बनाने के लिए Presentation क्लास को इंस्टैंसिएट करें।
with slides.Presentation() as presentation:

    # पहली स्लाइड प्राप्त करें।
    slide = presentation.slides[0]

    # पहली स्लाइड प्राप्त करें।
    shape_from = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 60, 25)
    shape_from.text_frame.text = "From"
    shape_to = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 500, 100, 60, 25)
    shape_to.text_frame.text = "To"

    # एक कनेक्टर जोड़ें।
    connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    # कनेक्टर की दिशा सेट करें।
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    # कनेक्टर का रंग सेट करें।
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.crimson
    # कनेक्टर की रेखा की मोटाई सेट करें।
    connector.line_format.width = 3

    # कनेक्टर के साथ आकारों को लिंक करें।
    connector.start_shape_connected_to = shape_from
    connector.start_shape_connection_site_index = 3
    connector.end_shape_connected_to = shape_to
    connector.end_shape_connection_site_index = 2

    # कनेक्टर के समायोजन बिंदु प्राप्त करें।
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
```

**समायोजन**

कनेक्टर के समायोजन बिंदु मानों को क्रमशः चौड़ाई प्रतिशत को 20 % और ऊँचाई प्रतिशत को 200 % बढ़ाकर बदलें:

```python
    # समायोजन बिंदुओं के मान बदलें।
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

परिणाम:

![कनेक्टर समायोजन 1](connector-adjusted-1.png)

कनेक्टर के खंडों के निर्देशांक और आकार निर्धारित करने वाला मॉडल बनाने के लिए, `connector.adjustments[0]` पर कनेक्टर के ऊर्ध्वाधर घटक के अनुरूप एक आकार बनाएं:

```python
    # कनेक्टर का लंबवत घटक बनाएँ।
    x = connector.x + connector.width * adjustment_0.raw_value / 100000
    y = connector.y
    height = connector.height * adjustment_1.raw_value / 100000

    slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, y, 0, height)
```

परिणाम:

![कनेक्टर समायोजन 2](connector-adjusted-2.png)

#### **मामला 2**

**Case 1** में, हमने बुनियादी सिद्धांतों का उपयोग करके एक सरल कनेक्टर समायोजन दिखाया। सामान्य परिदृश्यों में, आपको कनेक्टर के घुमाव और उसकी प्रदर्शनी सेटिंग्स (जो `connector.rotation`, `connector.frame.flip_h`, और `connector.frame.flip_v` द्वारा नियंत्रित होते हैं) को ध्यान में रखना चाहिए। प्रक्रिया इस प्रकार है।

पहले, स्लाइड में एक नया टेक्स्ट फ्रेम ऑब्जेक्ट (**To 1**) जोड़ें (कनेक्शन के लिए), और एक नया हरा कनेक्टर बनाएं जो इसे मौजूदा वस्तुओं से जोड़ता है।

```python
    # एक नया लक्ष्य ऑब्जेक्ट बनाएं।
    shape_to_1 = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 400, 60, 25)
    shape_to_1.text_frame.text = "To 1"

    # एक नया कनेक्टर बनाएं।
    connector = sld.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR4, 20, 20, 400, 300)
    connector.line_format.end_arrowhead_style = slides.LineArrowheadStyle.TRIANGLE
    connector.line_format.fill_format.fill_type = slides.FillType.SOLID
    connector.line_format.fill_format.solid_fill_color.color = draw.Color.medium_aquamarine
    connector.line_format.width = 3

    # नए बनाए गए कनेक्टर का उपयोग करके ऑब्जेक्ट्स को जोड़ें।
    connector.start_shape_connected_to = shapeFrom
    connector.start_shape_connection_site_index = 2
    connector.end_shape_connected_to = shape_to_1
    connector.end_shape_connection_site_index = 3

    # कनेक्टर के समायोजन बिंदु प्राप्त करें।
    adjustment_0 = connector.adjustments[0]
    adjustment_1 = connector.adjustments[1]
    
    # समायोजन बिंदुओं के मान बदलें।
    adjustment_0.raw_value += 20000
    adjustment_1.raw_value += 200000
```

परिणाम:

![कनेक्टर समायोजन 3](connector-adjusted-3.png)

दूसरा, एक ऐसा आकार बनाएं जो कनेक्टर के **क्षैतिज** खंड के अनुरूप हो जो नए कनेक्टर के समायोजन बिंदु `connector.adjustments[0]` से गुजरता है। `connector.rotation`, `connector.frame.flip_h`, और `connector.frame.flip_v` के मानों का उपयोग करें, और दिए गए बिंदु `x0` के चारों ओर घुमाव के लिए मानक निर्देशांक परिवर्तन सूत्र लागू करें:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;

Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

हमारे मामले में, वस्तु का घुमाव कोण 90 डिग्री है और कनेक्टर को ऊर्ध्वाधर रूप में प्रदर्शित किया गया है, इसलिए संबंधित कोड है:

```python
    # कनेक्टर निर्देशांक सहेजें।
    x = connector.x
    y = connector.y
    
    # यदि कनेक्टर फ़्लिप किया गया है तो निर्देशांक सुधारें।
    if connector.frame.flip_h == 1:
        x += connector.width
    if connector.frame.flip_v == 1:
        y += connector.height

    # समायोजन बिंदु मान को निर्देशांक के रूप में उपयोग करें।
    x += connector.width * adjValue_0.raw_value / 100000
    
    # निर्देशांक परिवर्तित करें क्योंकि sin(90°) = 1 और cos(90°) = 0।
    xx = connector.frame.center_x - y + connector.frame.center_y
    yy = x - connector.frame.center_x + connector.frame.center_y

    # दूसरे समायोजन बिंदु मान का उपयोग करके क्षैतिज खंड की चौड़ाई निर्धारित करें।
    width = connector.height * adjValue_1.raw_value / 100000
    shape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, xx, yy, width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
```

परिणाम:

![कनेक्टर समायोजन 4](connector-adjusted-4.png)

हमने सरल समायोजन और अधिक जटिल समायोजन बिंदुओं (जो घुमाव को ध्यान में रखते हैं) से जुड़ी गणनाएँ प्रदर्शित कीं। इस ज्ञान का उपयोग करके, आप अपना मॉडल विकसित कर सकते हैं—या कोड लिख सकते हैं— ताकि `GraphicsPath` ऑब्जेक्ट प्राप्त किया जा सके या विशिष्ट स्लाइड निर्देशांक के आधार पर कनेक्टर के समायोजन बिंदु मान सेट किए जा सकें।

## **कनेक्टर लाइन कोण खोजें**

नीचे दिया गया उदाहरण Aspose.Slides के साथ स्लाइड पर कनेक्टर लाइनों के कोण निर्धारित करने में मदद करता है। आप सीखेंगे कि कनेक्टर के अंत बिंदुओं को कैसे पढ़ें और उसकी अभिविन्यास की गणना करें ताकि आप तीर, लेबल और अन्य आकारों को सटीक रूप से संरेखित कर सकें।

1. एक [प्रस्तुति](https://reference.aspose.com/slides/hi/python-net/aspose.slides/presentation/) वर्ग का एक उदाहरण बनाएं।
1. इंडेक्स द्वारा स्लाइड का संदर्भ प्राप्त करें।
1. कनेक्टर लाइन आकार तक पहुंचें।
1. लाइन की चौड़ाई और ऊँचाई, तथा आकार के फ्रेम की चौड़ाई और ऊँचाई का उपयोग करके कोण की गणना करें।

```python
import aspose.slides as slides
import math

def get_direction(w, h, flip_h, flip_v):
    end_line_x = w * (-1 if flip_h else 1)
    end_line_y = h * (-1 if flip_v else 1)
    end_y_axis_x = 0
    end_y_axis_y = h
    angle = math.atan2(end_y_axis_y, end_y_axis_x) - math.atan2(end_line_y, end_line_x)
    if (angle < 0):
         angle += 2 * math.pi
    return angle * 180.0 / math.pi

with slides.Presentation("connector_line_angle.pptx") as presentation:
    slide = presentation.slides[0]
    for shape_index in range(len(slide.shapes)):
        direction = 0.0
        shape = slide.shapes[shape_index]
        if type(shape) is slides.AutoShape and shape.shape_type == slides.ShapeType.LINE:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        elif type(shape) is slides.Connector:
            direction = get_direction(shape.width, shape.height, shape.frame.flip_h, shape.frame.flip_v)
        print(direction)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि कनेक्टर किसी विशिष्ट आकार से "जुड़ा" हो सकता है या नहीं?**

जाँचें कि आकार [connection sites](https://reference.aspose.com/slides/hi/python-net/aspose.slides/shape/connection_site_count/) प्रदान करता है या नहीं। यदि कोई नहीं है या गिनती शून्य है, तो जुड़ना उपलब्ध नहीं है; ऐसे में, मुक्त अंत बिंदुओं का उपयोग करके उन्हें मैन्युअल रूप से स्थित करें। जुड़ने से पहले साइट गिनती जाँचना उचित है।

**यदि मैं जुड़े हुए आकारों में से एक को हटाता हूँ तो कनेक्टर के साथ क्या होता है?**

इसके सिरों को अलग कर दिया जाएगा; कनेक्टर स्लाइड पर सामान्य रेखा के रूप में रह जाता है जिसमें मुक्त प्रारम्भ/अंत बिंदु होते हैं। आप इसे हटा सकते हैं या कनेक्शन पुनः नियोजित कर सकते हैं और आवश्यकता पड़ने पर [reroute](https://reference.aspose.com/slides/hi/python-net/aspose.slides/connector/reroute/) कर सकते हैं।

**क्या स्लाइड को किसी अन्य प्रस्तुति में कॉपी करने पर कनेक्टर बाइंडिंग्स संरक्षित रहती हैं?**

आम तौर पर हाँ, बशर्ते लक्ष्य आकार भी कॉपी किए जाएँ। यदि स्लाइड को किसी अन्य फ़ाइल में जोड़ते समय जुड़े हुए आकार नहीं होते हैं, तो सिरे मुक्त हो जाते हैं और आपको उन्हें फिर से जोड़ना होगा।