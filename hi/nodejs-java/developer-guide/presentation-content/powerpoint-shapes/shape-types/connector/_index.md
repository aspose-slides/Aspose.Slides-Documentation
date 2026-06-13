---
title: JavaScript का उपयोग करके प्रस्तुतियों में कनेक्टर प्रबंधित करें
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/nodejs-java/connector/
keywords:
- कनेक्टर
- कनेक्टर प्रकार
- कनेक्टर बिंदु
- कनेक्टर रेखा
- कनेक्टर कोण
- आकार जोड़ें
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ऐप्स को PowerPoint स्लाइड्स में रेखाएँ बनाना, जोड़ना और स्वतः‑रूट करने में सक्षम बनाएँ—सीधे, एलबो और घुमावदार कनेक्टरों पर पूरी नियंत्रण प्राप्त करें।"
---
## **परिचय**

PowerPoint कनेक्टर एक विशेष रेखा है जो दो आकारों को साथ जोड़ती या लिंक करती है और जब भी उन्हें किसी स्लाइड पर स्थानांतरित या पुनः स्थित किया जाता है, तब भी आकारों से जुड़ी रहती है।  

कनेक्टर सामान्यतः *कनेक्शन डॉट्स* (हरा बिंदु) से जुड़े होते हैं, जो डिफ़ॉल्ट रूप से सभी आकारों पर मौजूद होते हैं। कनेक्शन डॉट्स तभी दिखाई देते हैं जब कर्सर उनके पास आता है।  

*समायोजन बिंदु* (नारंगी बिंदु), जो केवल कुछ कनेक्टरों पर मौजूद होते हैं, कनेक्टरों की स्थिति और आकार को संशोधित करने के लिए उपयोग किए जाते हैं।  

## **कनेक्टर प्रकार**

PowerPoint में, आप सीधे, एलबो (कोणीय) और घुमावदार कनेक्टरों का उपयोग कर सकते हैं।  

Aspose.Slides इन कनेक्टरों को प्रदान करता है:

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

## **कनेक्टरों का उपयोग करके आकार जोड़ें**

1. एक [प्रस्तुति](https://apireference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. स्लाइड पर दो [ऑटोशेप](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) जोड़ें, `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `addAutoShape` मेथड का उपयोग करके।  
1. `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `addConnector` मेथड का उपयोग करके कनेक्टर प्रकार को परिभाषित करके एक कनेक्टर जोड़ें।  
1. कनेक्टर का उपयोग करके आकारों को जोड़ें।  
1. सबसे छोटा कनेक्शन पथ लागू करने के लिए `reroute` मेथड को कॉल करें।  
1. प्रस्तुति को सहेजें।  

यह JavaScript कोड आपको दिखाता है कि दो आकारों (एक अंडाकार और एक आयत) के बीच एक कनेक्टर (एक बेंट कनेक्टर) कैसे जोड़ें:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // एक विशिष्ट स्लाइड के लिए आकार संग्रह तक पहुँचता है
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // एक अंडाकार ऑटोशेप जोड़ता है
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // एक आयत ऑटोशेप जोड़ता है
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // स्लाइड आकार संग्रह में एक कनेक्टर आकार जोड़ता है
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // कनेक्टर का उपयोग करके आकारों को जोड़ता है
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // reroute को कॉल करता है जो आकारों के बीच स्वचालित सबसे छोटा पथ निर्धारित करता है
    connector.reroute();
    // प्रस्तुति सहेजता है
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
`Connector.reroute` मेथड एक कनेक्टर को पुनः मार्गित करता है और उसे आकारों के बीच सबसे छोटा संभव पथ लेने के लिए बाध्य करता है। इस लक्ष्य को प्राप्त करने के लिए, मेथड `setStartShapeConnectionSiteIndex` और `setEndShapeConnectionSiteIndex` बिंदुओं को बदल सकता है।  
{{% /alert %}} 

## **कनेक्शन डॉट निर्दिष्ट करें**

यदि आप चाहते हैं कि कनेक्टर आकारों पर विशिष्ट डॉट्स का उपयोग करके दो आकारों को जोड़ै, तो आपको अपने पसंदीदा कनेक्शन डॉट्स इस प्रकार निर्दिष्ट करने होंगे:

1. एक [प्रस्तुति](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का उदाहरण बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. स्लाइड पर दो [ऑटोशेप](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/AutoShape) जोड़ें, `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `addAutoShape` मेथड का उपयोग करके।  
1. `Shapes` ऑब्जेक्ट द्वारा प्रदर्शित `addConnector` मेथड का उपयोग करके कनेक्टर प्रकार को परिभाषित करके एक कनेक्टर जोड़ें।  
1. कनेक्टर का उपयोग करके आकारों को जोड़ें।  
1. आकारों पर अपने पसंदीदा कनेक्शन डॉट्स सेट करें।  
1. प्रस्तुति को सहेजें।  

यह JavaScript कोड एक ऑपरेशन दर्शाता है जहाँ एक पसंदीदा कनेक्शन डॉट निर्दिष्ट किया गया है:

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // एक विशिष्ट स्लाइड के लिए आकार संग्रह तक पहुँचता है
    var shapes = pres.getSlides().get_Item(0).getShapes();
    // एक अंडाकार ऑटोशेप जोड़ता है
    var ellipse = shapes.addAutoShape(aspose.slides.ShapeType.Ellipse, 0, 100, 100, 100);
    // एक आयत ऑटोशेप जोड़ता है
    var rectangle = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 300, 100, 100);
    // स्लाइड के आकार संग्रह में एक कनेक्टर आकार जोड़ता है
    var connector = shapes.addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);
    // कनेक्टर का उपयोग करके आकारों को जोड़ता है
    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    // अंडाकार आकार पर पसंदीदा कनेक्शन डॉट इंडेक्स सेट करता है
    var wantedIndex = 6;
    // जांचता है कि क्या पसंदीदा इंडेक्स अधिकतम साइट इंडेक्स गणना से कम है
    if (ellipse.getConnectionSiteCount() > wantedIndex) {
        // अंडाकार ऑटोशेप पर पसंदीदा कनेक्शन डॉट सेट करता है
        connector.setStartShapeConnectionSiteIndex(wantedIndex);
    }
    // प्रस्तुति सहेजता है
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **कनेक्टर बिंदु समायोजित करें**

आप किसी मौजूदा कनेक्टर को उसके समायोजन बिंदुओं के माध्यम से समायोजित कर सकते हैं। केवल समायोजन बिंदुओं वाले कनेक्टरों को इस तरह बदला जा सकता है। **[कनेक्टर प्रकार.](/slides/hi/nodejs-java/connector/#types-of-connectors)** के तहत तालिका देखें।  

### **सरल मामला**

एक केस पर विचार करें जहाँ दो आकारों (A और B) के बीच का कनेक्टर तीसरे आकार (C) के माध्यम से गुजरता है:

![connector-obstruction](connector-obstruction.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setStartShapeConnectionSiteIndex(2);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

तीसरे आकार से बचने या उसे बायपास करने के लिए, हम कनेक्टर को इस तरह उसकी लंबवत रेखा को बाएँ ले जाकर समायोजित कर सकते हैं:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

```javascript
var adj2 = connector.getAdjustments().get_Item(1);
adj2.setRawValue(adj2.getRawValue() + 10000);
```

### **जटिल मामलों**

अधिक जटिल समायोजन करने के लिए, आपको इन बातों को ध्यान में रखना होगा:

* कनेक्टर का समायोज्य बिंदु उस सूत्र से दृढ़ता से जुड़ा होता है जो उसकी स्थिति की गणना और निर्धारण करता है। इसलिए बिंदु के स्थान में परिवर्तन कनेक्टर के आकार को बदल सकता है।  
* कनेक्टर के समायोजन बिंदुओं को एक एरे में कड़ी क्रम में परिभाषित किया गया है। समायोजन बिंदुओं को कनेक्टर के प्रारंभ बिंदु से अंत तक क्रमांकित किया गया है।  
* समायोजन बिंदु मान कनेक्टर आकार की चौड़ाई/ऊँचाई के प्रतिशत को दर्शाते हैं।  
  * आकार को कनेक्टर के प्रारंभ और अंत बिंदुओं को 1000 से गुणा करके सीमित किया गया है।  
  * पहला बिंदु, दूसरा बिंदु, और तीसरा बिंदु क्रमशः चौड़ाई से प्रतिशत, ऊँचाई से प्रतिशत, और फिर से चौड़ाई से प्रतिशत को निर्धारित करता है।  
* एक कनेक्टर के समायोजन बिंदुओं के निर्देशांक निर्धारित करने वाली गणनाओं के लिए, आपको कनेक्टर के घूर्णन और उसके प्रतिबिंब को ध्यान में करना होगा। **ध्यान दें** कि **[कनेक्टर प्रकार](/slides/hi/nodejs-java/connector/#types-of-connectors)** के तहत दिखाए गए सभी कनेक्टरों का घूर्णन कोण 0 है।  

#### **मामला 1**

एक केस पर विचार करें जहाँ दो टेक्स्ट फ्रेम ऑब्जेक्ट कनेक्टर के माध्यम से जुड़े हुए हैं:

![connector-shape-complex](connector-shape-complex.png)

```javascript
// PPTX फ़ाइल का प्रतिनिधित्व करने वाली प्रस्तुति क्लास का उदाहरण बनाता है
var pres = new aspose.slides.Presentation();
try {
    // प्रस्तुति में पहली स्लाइड प्राप्त करता है
    var sld = pres.getSlides().get_Item(0);
    // आकार जोड़ता है जो कनेक्टर के माध्यम से जुड़े होंगे
    var shapeFrom = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    shapeFrom.getTextFrame().setText("From");
    var shapeTo = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    shapeTo.getTextFrame().setText("To");
    // कनेक्टर जोड़ता है
    var connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    // कनेक्टर की दिशा निर्दिष्ट करता है
    connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
    // कनेक्टर का रंग निर्दिष्ट करता है
    connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // कनेक्टर की रेखा की मोटाई निर्दिष्ट करता है
    connector.getLineFormat().setWidth(3);
    // कनेक्टर के साथ आकारों को जोड़ता है
    connector.setStartShapeConnectedTo(shapeFrom);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(shapeTo);
    connector.setEndShapeConnectionSiteIndex(2);
    // कनेक्टर के समायोजन बिंदु प्राप्त करता है
    var adjValue_0 = connector.getAdjustments().get_Item(0);
    var adjValue_1 = connector.getAdjustments().get_Item(1);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

**समायोजन**

हम कनेक्टर के समायोजन बिंदु मानों को क्रमशः संबंधित चौड़ाई और ऊँचाई के प्रतिशत को 20% और 200% बढ़ाकर बदल सकते हैं:

```javascript
// समायोजन बिंदुओं के मान बदलता है
adjValue_0.setRawValue(adjValue_0.getRawValue() + 20000);
adjValue_1.setRawValue(adjValue_1.getRawValue() + 200000);
```

परिणाम:

![connector-adjusted-1](connector-adjusted-1.png)

एक मॉडल परिभाषित करने के लिए जो हमें कनेक्टर के व्यक्तिगत भागों के निर्देशांक और आकार निर्धारित करने में सक्षम बनाता है, चलिए एक आकार बनाते हैं जो कनेक्टर के क्षैतिज घटक से मेल खाता है, जो connector.getAdjustments().get_Item(0) बिंदु पर है:

```javascript
// कनेक्टर का लंबवत घटक बनाता है
var x = connector.getX() + ((connector.getWidth() * adjValue_0.getRawValue()) / 100000);
var y = connector.getY();
var height = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 0, height);
```

परिणाम:

![connector-adjusted-2](connector-adjusted-2.png)

#### **मामला 2**

**मामला 1** में, हमने बुनियादी सिद्धांतों का उपयोग करके एक सरल कनेक्टर समायोजन ऑपरेशन दिखाया। सामान्य स्थितियों में, आपको कनेक्टर के घूर्णन और उसकी डिस्प्ले (जो connector.getRotation(), connector.getFrame().getFlipH(), और connector.getFrame().getFlipV() द्वारा सेट होते हैं) को ध्यान में रखना होगा। अब हम प्रक्रिया दर्शाएंगे।

पहले, स्लाइड में एक नया टेक्स्ट फ्रेम ऑब्जेक्ट (**To 1**) जोड़ें (कनेक्शन के उद्देश्य से) और एक नया (हरा) कनेक्टर बनाएं जो इसे पहले से बनाए गए ऑब्जेक्ट्स से जोड़ता है।

```javascript
// एक नया बाइंडिंग ऑब्जेक्ट बनाता है
var shapeTo_1 = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
shapeTo_1.getTextFrame().setText("To 1");
// एक नया कनेक्टर बनाता है
connector = sld.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
connector.getLineFormat().setEndArrowheadStyle(aspose.slides.LineArrowheadStyle.Triangle);
connector.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
connector.getLineFormat().setWidth(3);
// नए बनाये गये कनेक्टर का उपयोग करके वस्तुओं को जोड़ता है
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

दूसरे, चलिए एक आकार बनाते हैं जो कनेक्टर के क्षैतिज घटक से मेल खाएगा जो नए कनेक्टर के समायोजन बिंदु connector.getAdjustments().get_Item(0) से गुजरता है। हम कनेक्टर डेटा से connector.getRotation(), connector.getFrame().getFlipH(), और connector.getFrame().getFlipV() के मान उपयोग करेंगे और दिए गए बिंदु x0 के चारों ओर घूर्णन के लिए लोकप्रिय निर्देशांक परिवर्तन सूत्र लागू करेंगे:

X = (x — x0) * cos(alpha) — (y — y0) * sin(alpha) + x0;
Y = (x — x0) * sin(alpha) + (y — y0) * cos(alpha) + y0;

हमारे मामले में, ऑब्जेक्ट का घूर्णन कोण 90 डिग्री है और कनेक्टर वर्टिकली प्रदर्शित होता है, इसलिए यह संबंधित कोड है:

```javascript
// कनेक्टर के निर्देशांक सहेजता है
x = connector.getX();
y = connector.getY();
// यदि आवश्यक हो तो कनेक्टर के निर्देशांक सुधारता है
if (connector.getFrame().getFlipH() == aspose.slides.NullableBool.True) {
    x += connector.getWidth();
}
if (connector.getFrame().getFlipV() == aspose.slides.NullableBool.True) {
    y += connector.getHeight();
}
// समायोजन बिंदु मान को निर्देशांक के रूप में लेता है
x += (connector.getWidth() * adjValue_0.getRawValue()) / 100000;
// निर्देशांक परिवर्तित करता है क्योंकि Sin(90) = 1 और Cos(90) = 0
var xx = (connector.getFrame().getCenterX() - y) + connector.getFrame().getCenterY();
var yy = (x - connector.getFrame().getCenterX()) + connector.getFrame().getCenterY();
// दूसरे समायोजन बिंदु मान का उपयोग करके क्षैतिज घटक की चौड़ाई निर्धारित करता है
var width = (connector.getHeight() * adjValue_1.getRawValue()) / 100000;
var shape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, xx, yy, width, 0);
shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
```

परिणाम:

![connector-adjusted-4](connector-adjusted-4.png)

हमने सरल समायोजन और जटिल समायोजन बिंदुओं (घूर्णन कोण वाले समायोजन बिंदु) से संबंधित गणनाओं को दर्शाया। प्राप्त ज्ञान का उपयोग करके, आप अपना स्वयं का मॉडल विकसित कर सकते हैं (या कोड लिख सकते हैं) ताकि `GraphicsPath` ऑब्जेक्ट प्राप्त किया जा सके या विशिष्ट स्लाइड निर्देशांक के आधार पर कनेक्टर के समायोजन बिंदु मान सेट किए जा सकें।  

## **कनेक्टर लाइनों का कोण खोजें**

1. क्लास का एक उदाहरण बनाएं।  
1. इंडेक्स के माध्यम से स्लाइड का संदर्भ प्राप्त करें।  
1. कनेक्टर लाइन आकार तक पहुंचें।  
1. लाइन की चौड़ाई, ऊँचाई, आकार फ्रेम की ऊँचाई और फ्रेम की चौड़ाई का उपयोग करके कोण की गणना करें।  

यह JavaScript कोड एक ऑपरेशन दर्शाता है जिसमें हमने कनेक्टर लाइन आकार के लिए कोण की गणना की:

```javascript
var pres = new aspose.slides.Presentation("ConnectorLineAngle.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (var i = 0; i < slide.getShapes().size(); i++) {
        var dir = 0.0;
        var shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            var ashp = shape;
            if (ashp.getShapeType() == aspose.slides.ShapeType.Line) {
                dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
            }
        } else if (java.instanceOf(shape, "com.aspose.slides.Connector")) {
            var ashp = shape;
            dir = getDirection(ashp.getWidth(), ashp.getHeight(), ashp.getFrame().getFlipH() > 0, ashp.getFrame().getFlipV() > 0);
        }
        console.log(dir);
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function getDirection(w, h, flipH, flipV) {
    let endLineX = w * (flipH ? -1 : 1);
    let endLineY = h * (flipV ? -1 : 1);
    
    let endYAxisX = 0;
    let endYAxisY = h;

    let angle = Math.atan2(endYAxisY, endYAxisX) - Math.atan2(endLineY, endLineX);

    if (angle < 0) {
        angle += 2 * Math.PI;
    }

    return angle * 180.0 / Math.PI;
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जान सकता हूँ कि कोई कनेक्टर किसी विशेष आकार से "चिपका" जा सकता है या नहीं?**  
जांचें कि क्या आकार [कनेक्शन साइट्स](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getconnectionsitecount/) को उजागर करता है। यदि कोई नहीं है या गणना शून्य है, तो चिपकाना उपलब्ध नहीं है; ऐसे में, मुक्त अंत बिंदुओं का उपयोग करें और उन्हें मैन्युअली स्थित करें। संलग्न करने से पहले साइट गणना को जांचना समझदारी है।  

**यदि मैं जुड़े हुए आकारों में से एक को हटाता हूँ तो कनेक्टर के साथ क्या होता है?**  
उसके अंत अलग हो जाएंगे; कनेक्टर स्लाइड पर एक सामान्य रेखा के रूप में रह जाएगा जिसमें मुक्त शुरू/अंत हो। आप इसे हटा सकते हैं या कनेक्शन को पुनः असाइन कर सकते हैं और यदि आवश्यक हो तो [reroute](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/reroute/) करें।  

**क्या एक स्लाइड को दूसरी प्रस्तुति में कॉपी करने पर कनेक्टर बाइंडिंग्स बरकरार रहती हैं?**  
आमतौर पर हाँ, बशर्ते लक्ष्य आकार भी कॉपी किए जाएँ। यदि स्लाइड को दूसरी फ़ाइल में जोड़े जाने पर जुड़े हुए आकार नहीं होते हैं, तो अंत मुक्त हो जाते हैं और आपको उन्हें पुनः संलग्न करना पड़ेगा।