---
title: जावा का उपयोग करके प्रस्तुतियों में कनेक्टर प्रबंधित करें
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/java/connector/
keywords:
- कनेक्टर
- कनेक्टर प्रकार
- कनेक्टर बिंदु
- कनेक्टर रेखा
- कनेक्टर कोण
- आकृतियों को जोड़ें
- PowerPoint
- प्रस्तुति
- जावा
- Aspose.Slides
description: "जावा एप्लिकेशन को PowerPoint स्लाइड्स में रेखाएँ बनाने, जोड़ने और स्वतः‑रूट करने की क्षमता दें—सीधी, कुहनी और वक्र कनेक्टरों पर पूर्ण नियंत्रण प्राप्त करें।"
---
## **परिचय**

PowerPoint कनेक्टर एक विशेष रेखा है जो दो आकृतियों को जोड़ता या लिंक करता है और स्लाइड पर उन्हें स्थानांतरित या पुनःस्थापित करने पर भी आकृतियों से जुड़ी रहती है।

कनेक्टर सामान्यतः *कनेक्शन डॉट्स* (हरा बिंदु) से जुड़ते हैं, जो डिफ़ॉल्ट रूप से सभी आकृतियों पर मौजूद होते हैं। कनेक्शन डॉट्स तब दिखते हैं जब कर्सर उनके पास आता है।

*एडजस्टमेंट पॉइंट्स* (नारंगी बिंदु), जो केवल कुछ कनेक्टरों पर मौजूद होते हैं, का उपयोग कनेक्टरों की स्थिति और आकृति को बदलने के लिए किया जाता है।

## **कनेक्टर के प्रकार**

PowerPoint में आप सीधी, कुहनी (कोणीय) और वक्र कनेक्टरों का उपयोग कर सकते हैं।

Aspose.Slides ये कनेक्टर प्रदान करता है:

| कनेक्टर | छवि | समायोजन बिंदुओं की संख्या |
| ------------------------------ | ------------------------------------------------------------ | --------------------------- |
| `ShapeType.Line`               | ![shapetype-lineconnector](shapetype-lineconnector.png)      | 0                           |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0                           |
| `ShapeType.BentConnector2`     | ![shapetype-bent-connector2](shapetype-bent-connector2.png)  | 0                           |
| `ShapeType.BentConnector3`     | ![shapetype-bentconnector3](shapetype-bentconnector3.png)    | 1                           |
| `ShapeType.BentConnector4`     | ![shapetype-bentconnector4](shapetype-bentconnector4.png)    | 2                           |
| `ShapeType.BentConnector5`     | ![shapetype-bentconnector5](shapetype-bentconnector5.png)    | 3                           |
| `ShapeType.CurvedConnector2`   | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0                           |
| `ShapeType.CurvedConnector3`   | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1                           |
| `ShapeType.CurvedConnector4`   | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2                           |
| `ShapeType.CurvedConnector5`   | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3                           |

## **कनेक्टरों का उपयोग करके आकृतियों को जोड़ें**

1. Presentation वर्ग की एक इंस्टेंस बनाएं。[Presentation](https://apireference.aspose.com/slides/hi/java/com.aspose.slides/Presentation)
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।
3. स्लाइड में दो [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/AutoShape) जोड़ें, जो `Shapes` ऑब्जेक्ट द्वारा प्रदान किए गए `addAutoShape` मेथड से किया जाता है।
4. `Shapes` ऑब्जेक्ट द्वारा प्रदान किए गए `addConnector` मेथड का उपयोग करके कनेक्टर जोड़ें और कनेक्टर प्रकार निर्धारित करें।
5. कनेक्टर का उपयोग करके आकृतियों को जोड़ें।
6. `reroute` मेथड को कॉल करें ताकि सबसे छोटा कनेक्शन पथ लागू हो।
7. प्रेजेंटेशन को सहेजें।

यह Java कोड आपको दिखाता है कि कैसे दो आकृतियों (एक दीर्घवृत्त और आयत) के बीच एक कनेक्टर (बेंट कनेक्टर) जोड़ा जाए:

```Java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // एक विशिष्ट स्लाइड के लिए शेप्स कलेक्शन तक पहुँचता है
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();
    
    // एक एलिप्स ऑटोशेप जोड़ता है
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);
    
    // एक आयत ऑटोशेप जोड़ता है
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);
    
    // स्लाइड शेप्स कलेक्शन में कनेक्टर शेप जोड़ता है
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);
    
    // कनेक्टर का उपयोग करके शेप्स को जोड़ता है
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    
    // reroute को कॉल करता है जो शेप्स के बीच स्वचालित सबसे छोटा पथ सेट करता है
    connector.reroute();
    
    // प्रेजेंटेशन को सहेजता है
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` मेथड कनेक्टर को पुन:रूट करता है और इसे आकृतियों के बीच सबसे छोटा संभव पथ लेने पर मजबूर करता है। इसका लक्ष्य प्राप्त करने के लिए, मेथड `setStartShapeConnectionSiteIndex` और `setEndShapeConnectionSiteIndex` बिंदुओं को बदल सकता है। 
{{% /alert %}} 

## **कनेक्शन डॉट निर्दिष्ट करें**

यदि आप चाहते हैं कि एक कनेक्टर दो आकृतियों को उनके विशिष्ट डॉट्स के माध्यम से लिंक करे, तो आपको अपनी पसंदीदा कनेक्शन डॉट्स इस प्रकार निर्दिष्ट करने होंगे:

1. Presentation वर्ग की एक इंस्टेंस बनाएं。[Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation)
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।
3. स्लाइड में दो [AutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/AutoShape) जोड़ें, जो `Shapes` ऑब्जेक्ट द्वारा प्रदान किए गए `addAutoShape` मेथड से किया जाता है।
4. `Shapes` ऑब्जेक्ट द्वारा प्रदान किए गए `addConnector` मेथड का उपयोग करके कनेक्टर जोड़ें और कनेक्टर प्रकार निर्धारित करें।
5. कनेक्टर का उपयोग करके आकृतियों को जोड़ें।
6. आकृतियों पर अपने पसंदीदा कनेक्शन डॉट्स सेट करें।
7. प्रेजेंटेशन को सहेजें।

यह Java कोड एक ऐसी ऑपरेशन को दर्शाता है जहाँ एक पसंदीदा कनेक्शन डॉट निर्दिष्ट किया गया है:

```java
// एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // एक विशिष्ट स्लाइड के लिए शेप्स कलेक्शन तक पहुँचता है
    IShapeCollection shapes = pres.getSlides().get_Item(0).getShapes();

    // एक एलिप्स ऑटोशेप जोड़ता है
    IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

    // एक आयत ऑटोशेप जोड़ता है
    IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

    // स्लाइड के शेप कलेक्शन में एक कनेक्टर शेप जोड़ता है
    IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    // कनेक्टर का उपयोग करके शेप्स को जोड़ता है
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    // एलिप्स शेप पर पसंदीदा कनेक्शन डॉट इंडेक्स सेट करता है
    int wantedIndex = 6;

    // जाँचता है कि क्या पसंदीदा इंडेक्स अधिकतम साइट इंडेक्स काउंट से कम है
    if (ellipse.getConnectionSiteCount() > wantedIndex) 
    {
        // एलिप्स ऑटोशेप पर पसंदीदा कनेक्शन डॉट सेट करता है
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }

    // प्रस्तुति को सहेजता है
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **कनेक्टर बिंदु समायोजित करें**

आप किसी मौजूदा कनेक्टर को उसके समायोजन बिंदुओं के माध्यम से समायोजित कर सकते हैं। केवल उन कनेक्टरों को, जिनमें समायोजन बिंदु होते हैं, इस प्रकार बदला जा सकता है। **[कनेक्टर के प्रकार.](/slides/hi/java/connector/#types-of-connectors)** के अंतर्गत तालिका देखें।

### **साधारण मामला**

ऐसे मामले पर विचार करें जहाँ दो आकृतियों (A और B) के बीच का कनेक्टर तीसरी आकृति (C) के माध्यम से जाता है:

![connector-obstruction](connector-obstruction.png)

```java
Presentation pres = new Presentation();
try {

    ISlide sld = pres.getSlides().get_Item(0);
    IShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);

    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

तीसरी आकृति से बचने या उसे बायपास करने के लिए, हम कनेक्टर को इस प्रकार बाएँ की ओर उसकी लंबवत रेखा को ले जाकर समायोजित कर सकते हैं:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```java
IAdjustValue adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **जटिल मामले** 

और अधिक जटिल समायोजन करने के लिए, आपको निम्नलिखित बातों पर ध्यान देना होगा:

* कनेक्टर का समायोज्य बिंदु एक सूत्र से दृढ़ता से जुड़ा होता है जो उसकी स्थिति की गणना और निर्धारण करता है। इसलिए बिंदु के स्थान में परिवर्तन कनेक्टर की आकृति को बदल सकता है।
* कनेक्टर के समायोजन बिंदुओं को एक सरणी में निश्चित क्रम में परिभाषित किया जाता है। समायोजन बिंदुओं को कनेक्टर के प्रारंभ बिंदु से अंत बिंदु तक क्रमांकित किया जाता है।
* समायोजन बिंदु मान कनेक्टर आकृति की चौड़ाई/ऊँचाई के प्रतिशत को दर्शाते हैं। 
  * आकृति को कनेक्टर के प्रारंभ और अंत बिंदुओं को 1000 से गुणा करके सीमित किया जाता है। 
  * पहला बिंदु, दूसरा बिंदु और तीसरा बिंदु क्रमशः चौड़ाई के प्रतिशत, ऊँचाई के प्रतिशत और फिर से चौड़ाई के प्रतिशत को परिभाषित करता है। 
* कनेक्टर के समायोजन बिंदुओं के निर्देशांक निर्धारित करने वाली गणनाओं के लिए, आपको कनेक्टर के घूर्णन और उसके प्रतिबिंब को ध्यान में रखना होगा। **ध्यान दें** कि **[कनेक्टर के प्रकार](/slides/hi/java/connector/#types-of-connectors)** के अंतर्गत दिखाए गए सभी कनेक्टरों का घूर्णन कोण 0 है।

#### **मामला 1**

ऐसे मामले पर विचार करें जहाँ दो टेक्स्ट फ्रेम ऑब्जेक्ट कनेक्टर के माध्यम से जुड़े होते हैं:

![connector-shape-complex](connector-shape-complex.png)

```java
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
Presentation pres = new Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    ISlide sld = pres.getSlides().get_Item(0);
    // ऐसे शैप्स जोड़ता है जिन्हें कनेक्टर के माध्यम से जोड़ा जाएगा
    IAutoShape shapeFrom = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    IAutoShape shapeTo = sld.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // एक कनेक्टर जोड़ता है
    IConnector connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    // कनेक्टर की दिशा निर्दिष्ट करता है
    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    // कनेक्टर का रंग निर्दिष्ट करता है
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    // कनेक्टर की लाइन की मोटाई निर्दिष्ट करता है
    connector.getLineFormat().setWidth(3);
    
    // कनेक्टर के साथ शैप्स को आपस में जोड़ता है
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    
    // कनेक्टर के समायोजन बिंदु प्राप्त करता है
    IAdjustValue adjValue_0 = connector.getAdjustments().get_Item(0);
    IAdjustValue adjValue_1 = connector.getAdjustments().get_Item(1);

} finally {
    if (pres != null) pres.dispose();
}
```

**समायोजन**

हम कनेक्टर के समायोजन बिंदु मान को क्रमशः संबंधित चौड़ाई और ऊँचाई प्रतिशत को 20% और 200% बढ़ाकर बदल सकते हैं:

```java
// समायोजन बिंदुओं के मान बदलता है
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

परिणाम:

![connector-adjusted-1](connector-adjusted-1.png)

एक मॉडल परिभाषित करने के लिए जो हमें कनेक्टर के व्यक्तिगत भागों के निर्देशांक और आकृति निर्धारित करने की अनुमति देता है, चलिए एक ऐसी आकृति बनाते हैं जो कनेक्टर के क्षैतिज घटक से मेल खाती हो, जहाँ बिंदु connector.getAdjustments().get_Item(0) है:

```java
// कनेक्टर का लम्बवत घटक बनाता है
float x = connector.getX() + connector.getWidth() * adjValue_0.getRawValue() / 100000;
float y = connector.getY();
float height = connector.getHeight() * adjValue_1.getRawValue() / 100000;
sld.getShapes().addAutoShape( ShapeType .Rectangle, x, y, 0, height);
```

परिणाम:

![connector-adjusted-2](connector-adjusted-2.png)

#### **मामला 2**

**मामला 1** में हमने मूल सिद्धांतों का उपयोग करके एक साधारण कनेक्टर समायोजन ऑपरेशन प्रदर्शित किया। सामान्य स्थितियों में, आपको कनेक्टर के घूर्णन और उसके प्रदर्शन (जो connector.getRotation(), connector.getFrame().getFlipH(), और connector.getFrame().getFlipV() द्वारा निर्धारित होते हैं) को ध्यान में रखना होगा। अब हम प्रक्रिया दर्शाएंगे।

पहले, स्लाइड में एक नया टेक्स्ट फ्रेम ऑब्जेक्ट (**To 1**) जोड़ें (कनेक्शन हेतु) और एक नया (हरा) कनेक्टर बनाएं जो इसे पहले से निर्मित ऑब्जेक्ट्स से जोड़ता है।

```java
// एक नया बाइंडिंग ऑब्जेक्ट बनाता है
IAutoShape shapeTo_1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// एक नया कनेक्टर बनाता है
connector = sld.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.CYAN);
connector.getLineFormat().setWidth(3);
// नए बनाए गए कनेक्टर का उपयोग करके ऑब्जेक्ट्स को जोड़ता है
connector.setStartShapeConnectedTo(shapeFrom);
connector.setStartShapeConnectionSiteIndex(2);
connector.setEndShapeConnectedTo(shapeTo_1);
connector.setEndShapeConnectionSiteIndex(3);
// कनेक्टर के समायोजन बिंदु प्राप्त करता है
adjValue_0 = connector.getAdjustments().get_Item(0);
adjValue_1 = connector.getAdjustments().get_Item(1);
// समायोजन बिंदुओं के मान बदलता है
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

परिणाम:

![connector-adjusted-3](connector-adjusted-3.png)

दूसरा, चलिए एक ऐसी आकृति बनाते हैं जो कनेक्टर के क्षैतिज घटक से मेल खाती हो, जो नए कनेक्टर के समायोजन बिंदु connector.getAdjustments().get_Item(0) से गुजरती है। हम कनेक्टर डेटा से मानों को उपयोग करेंगे जो connector.getRotation(), connector.getFrame().getFlipH(), और connector.getFrame().getFlipV() के लिए हैं और दिए गए बिंदु x0 के चारों ओर घूर्णन के लिए लोकप्रिय निर्देशांक परिवर्तन सूत्र लागू करेंगे:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

हमारे मामले में, ऑब्जेक्ट का घूर्णन कोण 90 डिग्री है और कनेक्टर लंबवत प्रदर्शित होता है, इसलिए यह संबंधित कोड है:

```java
// कनेक्टर के निर्देशांक को सहेजता है
x = connector.getX();
y = connector.getY();
// यदि यह दिखाई देता है तो कनेक्टर के निर्देशांक को सही करता है
if (connector.getFrame().getFlipH() == NullableBool.True)
{
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == NullableBool.True)
{
    y += connector.getHeight();
}
// समायोजन बिंदु मान को निर्देशांक के रूप में लेता है
x += connector.getWidth() * adjValue_0.getRawValue() / 100000;
//  निर्देशांकों को परिवर्तित करता है क्योंकि Sin(90) = 1 और Cos(90) = 0
float xx = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
float yy = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
// दूसरे समायोजन बिंदु मान का उपयोग करके क्षैतिज घटक की चौड़ाई निर्धारित करता है
float width = connector.getHeight() * adjValue_1.getRawValue() / 100000;
IAutoShape shape = sld.getShapes().addAutoShape(ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
```

परिणाम:

![connector-adjusted-4](connector-adjusted-4.png)

हमने साधारण समायोजनों और जटिल समायोजन बिंदुओं (घूर्णन कोण वाले समायोजन बिंदु) से संबंधित गणनाओं को दर्शाया। प्राप्त ज्ञान का उपयोग करके, आप अपना मॉडल बना सकते हैं (या कोड लिख सकते हैं) ताकि `GraphicsPath` ऑब्जेक्ट प्राप्त किया जा सके या विशिष्ट स्लाइड निर्देशांकों के आधार पर कनेक्टर के समायोजन बिंदु मान सेट किए जा सकें।

## **कनेक्टर लाइनों का कोण खोजें**

1. क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स द्वारा प्राप्त करें।
3. कनेक्टर लाइन आकृति तक पहुँचें।
4. लाइन की चौड़ाई, ऊँचाई, आकृति फ्रेम की ऊँचाई और चौड़ाई का उपयोग करके कोण की गणना करें।

यह Java कोड एक ऐसी प्रक्रिया दर्शाता है जिसमें हमने कनेक्टर लाइन आकृति के लिए कोण की गणना की:

```java
Presentation pres = new Presentation("ConnectorLineAngle.pptx");
try {
    Slide slide = (Slide)pres.getSlides().get_Item(0);
    
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        double dir = 0.0;
        Shape shape = (Shape)slide.getShapes().get_Item(i);
        if (shape instanceof AutoShape)
        {
            AutoShape ashp = (AutoShape)shape;
            if (ashp.getShapeType() == ShapeType.Line)
            {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                        ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        }
        else if (shape instanceof Connector)
        {
            Connector ashp = (Connector)shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(),
                    ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }

        System.out.println(dir);
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
public static double getDirection(float w, float h, boolean flipH, boolean flipV)
{
    float endLineX = w * (flipH ? -1 : 1);
    float endLineY = h * (flipV ? -1 : 1);
    float endYAxisX = 0;
    float endYAxisY = h;
    double angle = (Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX));
    if (angle < 0) angle += 2 * Math.PI;
    return angle * 180.0 / Math.PI;
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता कर सकता हूँ कि कोई कनेक्टर किसी विशिष्ट आकृति से "ग्लू" किया जा सकता है या नहीं?**

जाँचें कि आकृति [connection sites](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getConnectionSiteCount--) प्रदान करती है या नहीं। यदि कोई नहीं हैं या गिनती शून्य है, तो ग्लू करने की सुविधा उपलब्ध नहीं है; ऐसे में, मुक्त अंत बिंदुओं का उपयोग करें और उन्हें मैन्युअल रूप से स्थिति दें। संलग्न करने से पहले साइट गिनती की जाँच करना समझदारी है।

**यदि मैं जुड़े हुए आकृतियों में से एक को हटाता हूँ तो कनेक्टर के साथ क्या होता है?**

इसके सिरों को डिटैच कर दिया जाएगा; कनेक्टर स्लाइड पर एक सामान्य रेखा के रूप में रहता है जिसमें मुक्त प्रारम्भ/अंत होते हैं। आप इसे हटा सकते हैं या कनेक्शनों को पुनः असाइन कर सकते हैं और आवश्यक होने पर, [reroute](https://reference.aspose.com/slides/hi/java/com.aspose.slides/connector/#reroute--) कर सकते हैं।

**क्या स्लाइड को किसी अन्य प्रेजेंटेशन में कॉपी करने पर कनेक्टर बाइंडिंग्स संरक्षित रहती हैं?**

आम तौर पर हाँ, बशर्ते लक्ष्य आकृतियां भी कॉपी की गई हों। यदि स्लाइड को किसी अन्य फ़ाइल में बिना जुड़े हुए आकृतियों के सम्मिलित किया जाता है, तो अंत बिंदु मुक्त हो जाते हैं और आपको उन्हें पुनः संलग्न करना पड़ेगा।