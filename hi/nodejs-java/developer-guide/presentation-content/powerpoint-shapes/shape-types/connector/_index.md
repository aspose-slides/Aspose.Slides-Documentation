---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में कनेक्टर्स का प्रबंधन
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
- कनेक्शन साइट
- समायोजन बिंदु
- आकृतियों को जोड़ें
- PowerPoint
- प्रस्तुति
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ जावास्क्रिप्ट में सीधे, मुड़े और घुमावदार PowerPoint कनेक्टर को जोड़ना, संलग्न करना, पुनः‑रूट करना, समायोजित करना और निरीक्षण करना सीखें।"
---
## **अवलोकन**

कनेक्टर एक रेखा है जो दो आकृतियों से जुड़ी रह सकती है जब भी किसी भी आकृति को स्थानांतरित किया जाए। इसके सिरे कनेक्शन साइट्स पर जुड़ते हैं, जिन्हें PowerPoint में हरे बिंदुओं द्वारा दर्शाया गया है। कुछ मुड़े और घुमावदार कनेक्टर भी समायोजन बिंदु प्रदर्शित करते हैं, जिन्हें नारंगी बिंदुओं द्वारा दर्शाया जाता है, जो व्यक्तिगत कनेक्टर सेगमेंट की स्थिति को नियंत्रित करते हैं।

Aspose.Slides कनेक्टर्स को [Connector](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/) क्लास के माध्यम से प्रस्तुत करता है। आप इन्हें बना सकते हैं, उनके सिरों को आकृतियों से जोड़ सकते हैं, कनेक्शन साइट चुन सकते हैं, उन्हें पुनः‑रूट कर सकते हैं, और उन कनेक्टर्स की ज्योमेट्री को संशोधित कर सकते हैं जिनमें समायोजन बिंदु होते हैं।

## **कनेक्टर प्रकार**

[ShapeType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapetype/) क्लास में सीधा, मुड़ा और घुमावदार कनेक्टर प्रीसेट शामिल हैं। निम्न तालिका उपलब्ध कनेक्टर ज्योमेट्री और प्रत्येक प्रीसेट द्वारा परिभाषित समायोजन बिंदुओं की संख्या को दर्शाती है।

| कनेक्टर | छवि | समायोजन बिंदुओं की संख्या |
|---|---|---|
| `ShapeType.Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType.StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType.BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType.BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType.BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType.BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType.CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType.CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType.CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType.CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

समायोजन बिंदुओं की संख्या और उनका अर्थ चयनित कनेक्टर प्रीसेट का हिस्सा होता है। यह मानकर न चलें कि दो अलग-अलग कनेक्टर प्रकार समान संग्रह लेआउट प्रदान करते हैं।

## **दो आकृतियों को जोड़ें**

[ShapeCollection.addConnector](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapecollection/addconnector/) का उपयोग करके एक कनेक्टर जोड़ें, और [Connector.setStartShapeConnectedTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/setstartshapeconnectedto/) तथा [Connector.setEndShapeConnectedTo](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/setendshapeconnectedto/) का उपयोग करके उसके सिरों को संलग्न करें। दोनों सिरों के जुड़ जाने के बाद, [Connector.reroute](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/reroute/) आकृतियों के बीच छोटा मार्ग चुनता है।

निम्न उदाहरण एक दीर्घवृत्त और एक आयत को मुड़े हुए कनेक्टर से जोड़ता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="चेतावनी" %}}
`reroute` कॉल करने से [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) और [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/connector/setendshapeconnectionsiteindex/) मान बदल सकते हैं। यदि उन साइटों को स्थिर रहने की आवश्यकता है तो पुनः‑रूट करने के बाद विशिष्ट कनेक्शन साइटें असाइन करें।
{{% /alert %}}

## **कनेक्शन साइट चुनें**

प्रत्येक कनेक्टेबल आकृति अपने साइटों की संख्या [Shape.getConnectionSiteCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getconnectionsitecount/) के माध्यम से रिपोर्ट करती है। कनेक्टर के अंत को असाइन करने से पहले zero‑based साइट इंडेक्स को वैधता जाँचें; साइट गिनती आकृति ज्योमेट्री के अनुसार बदलती है।

यह उदाहरण दीर्घवृत्त पर किसी विशेष साइट पर कनेक्टर को संलग्न करता है, बशर्ते वह साइट मौजूद हो:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const ellipse = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 40, 80, 120, 80);
    const rectangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 320, 240, 140, 80);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    const preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        console.log(`The ellipse has only ${ellipse.getConnectionSiteCount()} connection sites.`);
    }

    presentation.save("specific-connection-site.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **कनेक्टर बिंदु को समायोजित करें**

समायोजन बिंदु वाले कनेक्टर [GeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/geometryshape/) के माध्यम से उन्हें उजागर करते हैं। प्रत्येक [AdjustValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/) का निरीक्षण करें और उसके [getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/) मान को देखें, फिर [setRawValue](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/setrawvalue/) से बदलें। प्रीसेट आकार समायोजनों की पहचान के सामान्य नियम [Shape Manipulation](/slides/hi/nodejs-java/shape-manipulations/) में वर्णित हैं।

समायोजन की संख्या, क्रम, अर्थ और मान मान्य रेंज कनेक्टर प्रीसेट पर निर्भर करती है। समायोजन प्रकार केवल‑पढ़ने योग्य होता है, जबकि समायोजन मान लिखने योग्य होता है। यदि कनेक्टर में समान अर्थ वाले एक से अधिक समायोजन होते हैं तो पढ़ने‑के‑लिए केवल‑पढ़ने योग्य [getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/getname/) अतिरिक्त पहचान जानकारी देता है।

### **एक बाधा के चारों ओर रास्ता बनाएं**

निम्न लेआउट में, दो आकृतियों के बीच का `BentConnector5` तीसरी आकृति से होकर गुजरता है:

![connector-obstruction](connector-obstruction.png)

यह कोड बाधित कनेक्टर बनाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ऊर्ध्वाधर मोड़ को बदलने से मार्ग बदलता है और कनेक्टर बाधा को बायपास करता है:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

यह उदाहरण `ConnectorBendPositionY` को खोजता है और केवल तभी बदलता है जब अपेक्षित अर्थ वाला प्रकार मौजूद हो:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 300, 150, 150, 75);
    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 400, 100, 50);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 70, 30);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector5, 20, 20, 400, 300);

    const black = java.getStaticFieldValue("java.awt.Color", "BLACK");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(black);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend === null) {
        console.log("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

`BentConnector5` में दो `ConnectorBendPositionX` समायोजन और एक `ConnectorBendPositionY` समायोजन होते हैं। यदि आवश्यक प्रकार एक से अधिक बार आता है, तो चयन करने से पहले `getName` और प्रीसेट की ज्ञात ज्योमेट्री को निरीक्षण करें। यदि कोई समायोजन `ShapeAdjustmentType.Custom` रिपोर्ट करता है, तो उसके अर्थ और रेंज को प्रीसेट‑विशिष्ट मानें और जब तक अनुबंध ज्ञात न हो तब तक परिवर्तन न करें।

## **समायोजन मानों को कनेक्टर ज्योमेट्री से जोड़ें**

मुड़े हुए कनेक्टर के लिए, समायोजन मानों का उपयोग व्यक्तिगत सेगमेंट की स्थितियों के अनुमान में किया जा सकता है। ये गणनाएँ कनेक्टर प्रीसेट के अनुसार विशिष्ट हैं:

- `BentConnector4` सामान्यतः एक `ConnectorBendPositionX` और एक `ConnectorBendPositionY` समायोजन उजागर करता है।
- इन मोड़ स्थितियों के लिए, `getRawValue` द्वारा लौटाए गए मान को `100000` से विभाजित करने पर नीचे दिए गए उदाहरणों में उपयोग किए गए कनेक्टर फ्रेम की चौड़ाई या ऊँचाई का अंश प्राप्त होता है।
- कनेक्टर फ्रेम को घुमा या उल्टा किया जा सकता है, इसलिए फ्रेम निर्देशांक को स्लाइड निर्देशांक के साथ तुलना करने से पहले परिवर्तित करना आवश्यक है।

निम्न उदाहरण पहले `getType` से समायोजन की पहचान करते हैं। वे संग्रह सूचकांकों को पोर्टेबल पहचानकर्ता के रूप में नहीं मानते।

### **बिना घुमाए कनेक्टर**

प्रारम्भिक लेआउट में दो टेक्स्ट आकृतियों को `BentConnector4` द्वारा जोड़ा गया है:

![connector-shape-complex](connector-shape-complex.png)

यह उदाहरण कनेक्टर का निरीक्षण करता है और उसकी क्षैतिज तथा लम्बवत मोड़ समायोजन प्राप्त करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        console.log(`${adjustment.getName()}: ${adjustment.getType()}, raw value = ${adjustment.getRawValue()}`);
    }
} finally {
    presentation.dispose();
}
```

दोनों मोड़ों को बदलने के लिए, प्रत्येक अपेक्षित प्रकार को खोजें और दोनों मिलने के बाद ही मान बदलें:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप कनेक्टर के क्षैतिज और लम्बवत सेगमेंट स्थानांतरित हो जाते हैं:

![connector-adjusted-1](connector-adjusted-1.png)

एक बार अर्थपूर्ण प्रकार ज्ञात हो जाएँ, तो उनके मानों को कनेक्टर‑फ़्रेम निर्देशांक में परिवर्तित किया जा सकता है। यह उदाहरण दो मोड़ समायोजन द्वारा नियंत्रित लम्बवत सेगमेंट के ऊपर एक पतली आयत बनाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 500, 100, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        const x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const y = connector.getY();
        const height = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(x);
        const guideY = java.newFloat(y);
        const guideWidth = java.newFloat(1);
        const guideHeight = java.newFloat(height);
        slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        presentation.save("connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

मार्गदर्शक आकृति गणना किए गए सेगमेंट को चिह्नित करती है:

![connector-adjusted-2](connector-adjusted-2.png)

### **घुमाया या उलटा कनेक्टर**

जब समान कनेक्टर ज्योमेट्री लंबवत अभिविन्यास में होती है, तो उसके [Shape.getFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getframe/), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapeframe/getfliph/), और [ShapeFrame.getFlipV](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapeframe/getflipv/) मान कनेक्टर‑फ़्रेम निर्देशांक को स्लाइड निर्देशांक में बदलने को प्रभावित करते हैं।

यह उदाहरण लंबवत अभिविन्यास वाला कनेक्टर बनाता और समायोजित करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);

    const connectorColor = java.newInstanceSync("java.awt.Color", 102, 205, 170);
    const solidFillType = java.newByte(aspose.slides.FillType.Solid);
    const triangleArrowheadStyle = java.newByte(aspose.slides.LineArrowheadStyle.Triangle);
    connector.getLineFormat().setEndArrowheadStyle(triangleArrowheadStyle);
    connector.getLineFormat().getFillFormat().setFillType(solidFillType);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(connectorColor);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

समायोजित कनेक्टर आकृतियों के बीच लंबवत दिखता है:

![connector-adjusted-3](connector-adjusted-3.png)

किसी भी घूर्णन कोण `alpha` के लिए, फ्रेम के केंद्र `(x0, y0)` के चारों ओर बिंदु `(x, y)` को इस प्रकार घुमाएँ:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

निम्न कोड इस उदाहरण में प्रयुक्त 90‑डिग्री अभिविन्यास को संभालता है और संबंधित कनेक्टर सेगमेंट के ऊपर लाल मार्गदर्शक रेखा बनाता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 60, 25);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 400, 60, 25);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    let horizontalBend = null;
    let verticalBend = null;
    for (let adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        const adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() === aspose.slides.ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend === null || verticalBend === null) {
        console.log("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        let x = connector.getX();
        let y = connector.getY();
        if (connector.getFrame().getFlipH() === aspose.slides.NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() === aspose.slides.NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000;
        const rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        const rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        const segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000;
        const guideX = java.newFloat(rotatedX);
        const guideY = java.newFloat(rotatedY);
        const guideWidth = java.newFloat(segmentWidth);
        const guideHeight = java.newFloat(1);
        const guide = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, guideX, guideY, guideWidth, guideHeight);
        const red = java.getStaticFieldValue("java.awt.Color", "RED");
        const solidFillType = java.newByte(aspose.slides.FillType.Solid);
        guide.getLineFormat().getFillFormat().setFillType(solidFillType);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(red);

        presentation.save("rotated-connector-segment-guide.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

समन्वय परिवर्तन के बाद लाल मार्गदर्शक गणना किए गए सेगमेंट को चिह्नित करता है:

![connector-adjusted-4](connector-adjusted-4.png)

ये सूत्र उदाहरणों में प्रयुक्त प्रीसेट का वर्णन करते हैं, सार्वभौमिक कनेक्टर मॉडल नहीं। समान गणना को किसी अन्य प्रीसेट पर लागू करने से पहले समायोजन प्रकार, फ्रेम अभिविन्यास और मान रेंज की जाँच करें।

## **कनेक्टर दिशा कोण खोजें**

सीधे कनेक्टर की दिशा उसकी चौड़ाई और ऊँचाई से गणना की जा सकती है, जिसमें क्षैतिज और लम्बवत फ्लिप लागू होते हैं। निम्न उदाहरण स्लाइड निर्देशांक में सकारात्मक क्षैतिज अक्ष से घड़ी की दिशा में कोण रिपोर्ट करता है:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const connector = slide.getShapes().addConnector(aspose.slides.ShapeType.StraightConnector1, 100, 100, 200, 100);

    const flipH = connector.getFrame().getFlipH() === aspose.slides.NullableBool.True;
    const flipV = connector.getFrame().getFlipV() === aspose.slides.NullableBool.True;
    const deltaX = connector.getWidth() * (flipH ? -1 : 1);
    const deltaY = connector.getHeight() * (flipV ? -1 : 1);
    let angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    console.log(`Connector direction: ${angle.toFixed(2)} degrees`);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि कनेक्टर किसी आकृति से जुड़ सकता है या नहीं?**

आकृति के [getConnectionSiteCount](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/getconnectionsitecount/) मान को जाँचें। सकारात्मक मान का अर्थ है कि आकृति कनेक्शन साइट्स उजागर करती है। कनेक्टर के किसी भी सिरे को असाइन करने से पहले चयनित साइट इंडेक्स को वैधता जाँचें।

**क्या मैं कनेक्टर समायोजन को उसके संग्रह सूचकांक से पहचान सकता हूँ?**

एक सूचकांक केवल ज्ञात कनेक्टर प्रीसेट और संग्रह लेआउट के लिए ही अर्थपूर्ण होता है। मान बदलने से पहले [AdjustValue.getType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/) जाँचें, और जब समान अर्थ वाले कई समायोजन हों तो अतिरिक्त जानकारी के लिए [AdjustValue.getName](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/adjustvalue/getname/) का उपयोग करें।

**जब जुड़ी हुई आकृति हटाई जाती है तो क्या होता है?**

संबंधित कनेक्टर का सिरा अलग हो जाता है। कनेक्टर स्लाइड पर बना रहता है और उसे हटाया, स्वतंत्र रेखा के रूप में स्थित या किसी अन्य आकृति से फिर से जोड़ा जा सकता है।

**क्या स्लाइड कॉपी करने पर कनेक्टर बाइंडिंग्स बनी रहती हैं?**

आमतौर पर बाइंडिंग्स बनी रहती हैं जब जुड़ी आकृतियों को स्लाइड के साथ कॉपी किया जाता है। यदि कनेक्टर को उसके लक्ष्य आकृतियों में से किसी एक के बिना कॉपी किया जाता है, तो प्रभावित सिरे को पुनः‑असाइन करना पड़ता है।