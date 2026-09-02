---
title: Java में प्रस्तुतियों में कनेक्टर प्रबंधित करें
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
- कनेक्शन साइट
- समायोजन बिंदु
- आकारों को जोड़ें
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ सीधे, मोड़े हुए और वक्र PowerPoint कनेक्टर को जोड़ना, संलग्न करना, रीरूट करना, समायोजित करना और निरीक्षण करना सीखें।"
---
## **अवलोकन**

एक कनेक्टर वह रेखा है जो किसी भी आकार के 움직ने पर दो Shapes से जुड़ी रह सकती है। इसके सिरों को कनेक्शन साइटों से जोड़ा जाता है, जिन्हें PowerPoint में हरे बिंदुओं द्वारा दर्शाया जाता है। कुछ मोड़े हुए और वक्र कनेक्टर भी समायोजन बिंदु दिखाते हैं, जिन्हें नारंगी बिंदुओं द्वारा दर्शाया जाता है, जो व्यक्तिगत कनेक्टर खंडों की स्थिति को नियंत्रित करते हैं।

Aspose.Slides कनेक्टर को [IConnector](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iconnector/) इंटरफ़ेस के माध्यम से दर्शाता है। आप उन्हें बना सकते हैं, उनके सिरों को Shapes से जोड़ सकते हैं, कनेक्शन साइट चुन सकते हैं, उन्हें reroute कर सकते हैं, और समायोजन बिंदुओं वाले कनेक्टर की ज्यामिति को संशोधित कर सकते हैं।

## **कनेक्टर प्रकार**

[ShapeType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapetype/) क्लास में सीधे (straight), मोड़े हुए (bent), और वक्र (curved) कनेक्टर प्रीसेट शामिल हैं। नीचे की तालिका उपलब्ध कनेक्टर ज्यामिति और प्रत्येक प्रीसेट द्वारा परिभाषित समायोजन बिंदुओं की संख्या दर्शाती है।

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

समायोजन बिंदुओं की संख्या और अर्थ चयनित कनेक्टर प्रीसेट का हिस्सा होते हैं। यह न मानें कि दो विभिन्न कनेक्टर प्रकार समान संग्रह लेआउट दिखाते हैं।

## **दो Shapes को जोड़ें**

[IShapeCollection.addConnector](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapecollection/#addConnector-int-float-float-float-float-) का उपयोग करके एक कनेक्टर जोड़ें, और [IConnector.setStartShapeConnectedTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iconnector/#setStartShapeConnectedTo-com.aspose.slides.IShape-) तथा [IConnector.setEndShapeConnectedTo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iconnector/#setEndShapeConnectedTo-com.aspose.slides.IShape-) का उपयोग करके उसके सिरों को संलग्न करें। दोनों सिरों के जुड़ने के बाद, [IConnector.reroute](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iconnector/#reroute--) आकारों के बीच सबसे छोटा मार्ग चुनता है।

निम्न उदाहरण एक दीर्घवृत्त और एक आयत को एक मोड़े हुए कनेक्टर से जोड़ता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);
    connector.reroute();

    presentation.save("connected-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
`reroute` को कॉल करने से [setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iconnector/#setStartShapeConnectionSiteIndex-long-) और [setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iconnector/#setEndShapeConnectionSiteIndex-long-) मान बदल सकते हैं। यदि इन साइटों को स्थिर रखना है, तो reroute करने के बाद विशिष्ट कनेक्शन साइट असाइन करें।
{{% /alert %}}

## **कनेक्शन साइट चुनें**

प्रत्येक कनेक्टेबल Shape अपने साइटों की संख्या को [IShape.getConnectionSiteCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getConnectionSiteCount--) के माध्यम से रिपोर्ट करता है। कनेक्टर के सिर को असाइन करने से पहले वांछित शून्य-आधारित साइट इंडेक्स को वैध करें; साइट की गणना Shape की ज्यामिति पर निर्भर करती है।

यह उदाहरण कनेक्टर को दीर्घवृत्त पर एक विशिष्ट साइट से जोड़ता है जब वह साइट मौजूद हो:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 40, 80, 120, 80);
    IAutoShape rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 320, 240, 140, 80);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector3, 0, 0, 10, 10);

    connector.setStartShapeConnectedTo(ellipse);
    connector.setEndShapeConnectedTo(rectangle);

    long preferredSiteIndex = 2;
    if (preferredSiteIndex < ellipse.getConnectionSiteCount()) {
        connector.setStartShapeConnectionSiteIndex(preferredSiteIndex);
    } else {
        System.out.println("The ellipse has only " + ellipse.getConnectionSiteCount() + " connection sites.");
    }

    presentation.save("specific-connection-site.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **कनेक्टर बिंदु समायोजित करें**

समायोजन बिंदुओं वाले कनेक्टर इन्हें [IGeometryShape.getAdjustments](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igeometryshape/#getAdjustments--) के माध्यम से उजागर करते हैं। प्रत्येक [IAdjustValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/) को जाँचें और [setRawValue](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#setRawValue-long-) से बदलने से पहले उसके [getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getType--) मान की जांच करें। प्रीसेट Shape समायोजनों की पहचान के सामान्य नियम [Shape Manipulation](/slides/hi/java/shape-manipulations/) में वर्णित हैं।

कनेक्टर समायोजन की संख्या, क्रम, अर्थ और मान्य मान सीमा कनेक्टर प्रीसेट पर निर्भर करती है। समायोजन प्रकार केवल पढ़ने योग्य (read‑only) है, जबकि समायोजन मान लिखने योग्य (writable) है। केवल‑पढ़ने योग्य [getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getName--) मेथड अतिरिक्त पहचान प्रदान करता है जब एक कनेक्टर में समान अर्थ वाले कई समायोजन होते हैं।

### **बाधा के आसपास मार्ग**

निम्न लेआउट में, दो Shapes के बीच का `BentConnector5` कनेक्टर तीसरे Shape के माध्यम से गुजरता है:

![connector-obstruction](connector-obstruction.png)

यह कोड बाधित कनेक्टर बनाता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    presentation.save("connector-obstruction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ऊर्ध्वाधर मोड़ को स्थानांतरित करने से मार्ग बदल जाता है जिससे कनेक्टर बाधा को बायपास करता है:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

संग्रह इंडेक्स `1` हमेशा ऊर्ध्वाधर मोड़ दर्शाता है, यह मानने के बजाय, यह उदाहरण `ConnectorBendPositionY` को खोजता है और केवल तब बदलता है जब अपेक्षित अर्थ प्रकार मौजूद हो:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addAutoShape(ShapeType.Rectangle, 300, 150, 150, 75);
    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 400, 100, 50);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 70, 30);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector5, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setStartShapeConnectionSiteIndex(2);

    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
            break;
        }
    }

    if (verticalBend == null) {
        System.out.println("The connector does not expose a vertical bend adjustment.");
    } else {
        verticalBend.setRawValue(60000);
        presentation.save("connector-obstruction-fixed.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

`BentConnector5` में दो `ConnectorBendPositionX` समायोजन और एक `ConnectorBendPositionY` समायोजन होता है। यदि आवश्यक प्रकार एक से अधिक बार आता है, तो चयन करने से पहले `getName` और उस प्रीसेट की ज्ञात ज्यामिति जांचें। यदि किसी समायोजन ने `ShapeAdjustmentType.Custom` लौटाया है, तो उसके अर्थ और सीमा को प्रीसेट‑विशिष्ट मानें और तब तक न बदलें जब तक वह अनुबंध ज्ञात न हो।

## **समायोजन मानों को कनेक्टर ज्यामिति से संबंधित करें**

बोड़े (bent) कनेक्टरों के लिए, समायोजन मानों का उपयोग व्यक्तिगत खंडों की स्थितियों का अनुमान लगाने में किया जा सकता है। ये गणनाएँ कनेक्टर प्रीसेट के विशेष हैं:

- `BentConnector4` सामान्यतः एक `ConnectorBendPositionX` और एक `ConnectorBendPositionY` समायोजन उजागर करता है।
- इन मोड़ स्थितियों के लिए, `getRawValue` द्वारा लौटाए मान को `100000f` से विभाजित करने से नीचे दिए उदाहरणों में उपयोग किए गए कनेक्टर फ्रेम की चौड़ाई या ऊँचाई का अंश प्राप्त होता है।
- कनेक्टर फ्रेम को घुमाया या उलटा (flip) किया जा सकता है, इसलिए फ्रेम निर्देशांक को स्लाइड निर्देशांक से तुलना करने से पहले परिवर्तित करना आवश्यक है।

निम्न उदाहरण पहले `getType` का उपयोग करके समायोजन की पहचान करते हैं। वे संग्रह इंडेक्स को पोर्टेबल पहचानकर्ता नहीं मानते।

### **अनरोटेटेड कनेक्टर**

प्रारंभिक लेआउट में दो टेक्स्ट Shapes हैं जो `BentConnector4` द्वारा जुड़े हुए हैं:

![connector-shape-complex](connector-shape-complex.png)

यह उदाहरण कनेक्टर की जांच करता है और उसके क्षैतिज एवं ऊर्ध्वाधर मोड़ समायोजन प्राप्त करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    targetShape.getTextFrame().setText("To");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        System.out.println(adjustment.getName() + ": " + adjustment.getType() + ", raw value = " + adjustment.getRawValue());
    }
} finally {
    presentation.dispose();
}
```

दोनों मोड़ों को बदलने के लिए, प्रत्येक अपेक्षित प्रकार को खोजें और दोनों मिलने के बाद ही मान बदलें:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);
        presentation.save("connector-adjusted.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

परिणामस्वरूप वह कनेक्टर प्राप्त होता है जिसके क्षैतिज और ऊर्ध्वाधर खंड स्थानांतरित हो गए हैं:

![connector-adjusted-1](connector-adjusted-1.png)

एक बार अर्थपूर्ण प्रकार ज्ञात हो जाएँ, उनके मान को कनेक्टर‑फ़्रेम निर्देशांक में बदला जा सकता है। यह उदाहरण दो मोड़ समायोजनों द्वारा नियंत्रित ऊर्ध्वाधर खंड के ऊपर एक पतली आयत खींचता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(3);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(2);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        float x = connector.getX() + connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float y = connector.getY();
        float height = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 1, height);
        presentation.save("connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

गाइड Shape गणना किए गए खंड को चिह्नित करता है:

![connector-adjusted-2](connector-adjusted-2.png)

### **घुमाया या उलटा कनेक्टर**

जब वही कनेक्टर ज्यामिति ऊर्ध्वाधर रूप में अभिविन्यासित होती है, तो उसके [IShape.getFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getFrame--), [ShapeFrame.getFlipH](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeframe/#getFlipH--), और [ShapeFrame.getFlipV](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapeframe/#getFlipV--) मान कनेक्टर‑फ़्रेम निर्देशांक से स्लाइड निर्देशांक में परिवर्तन को प्रभावित करते हैं।

यह उदाहरण ऊर्ध्वाधर अभिविन्यासित कनेक्टर बनाता और समायोजित करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    sourceShape.getTextFrame().setText("From");
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    targetShape.getTextFrame().setText("To 1");
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);

    connector.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.Triangle);
    connector.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    connector.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(102, 205, 170));
    connector.getLineFormat().setWidth(3);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            adjustment.setRawValue(adjustment.getRawValue() + 20000);
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            adjustment.setRawValue(adjustment.getRawValue() + 200000);
        }
    }

    presentation.save("vertical-connector-adjusted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

समायोजित कनेक्टर आकारों के बीच ऊर्ध्वाधर रूप से दिखाई देता है:

![connector-adjusted-3](connector-adjusted-3.png)

किसी भी घूर्णन कोण `alpha` के लिए, कनेक्टर‑फ़्रेम बिंदु `(x, y)` को फ्रेम केंद्र `(x0, y0)` के चारों ओर घुमाएँ:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

निम्न कोड इस उदाहरण में उपयोग किए गए 90‑डिग्री अभिविन्यास को संभालता है और संबंधित कनेक्टर खंड के ऊपर एक लाल गाइड खींचता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape sourceShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 60, 25);
    IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 400, 60, 25);
    IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector4, 20, 20, 400, 300);
    connector.setStartShapeConnectedTo(sourceShape);
    connector.setStartShapeConnectionSiteIndex(2);
    connector.setEndShapeConnectedTo(targetShape);
    connector.setEndShapeConnectionSiteIndex(3);

    IAdjustValue horizontalBend = null;
    IAdjustValue verticalBend = null;
    for (int adjustmentIndex = 0; adjustmentIndex < connector.getAdjustments().size(); adjustmentIndex++) {
        IAdjustValue adjustment = connector.getAdjustments().get_Item(adjustmentIndex);
        if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionX) {
            horizontalBend = adjustment;
        } else if (adjustment.getType() == ShapeAdjustmentType.ConnectorBendPositionY) {
            verticalBend = adjustment;
        }
    }

    if (horizontalBend == null || verticalBend == null) {
        System.out.println("The connector does not expose the expected bend adjustments.");
    } else {
        horizontalBend.setRawValue(horizontalBend.getRawValue() + 20000);
        verticalBend.setRawValue(verticalBend.getRawValue() + 200000);

        float x = connector.getX();
        float y = connector.getY();
        if (connector.getFrame().getFlipH() == NullableBool.True) {
            x += connector.getWidth();
        }
        if (connector.getFrame().getFlipV() == NullableBool.True) {
            y += connector.getHeight();
        }

        x += connector.getWidth() * horizontalBend.getRawValue() / 100000f;
        float rotatedX = connector.getFrame().getCenterX() - y + connector.getFrame().getCenterY();
        float rotatedY = x - connector.getFrame().getCenterX() + connector.getFrame().getCenterY();
        float segmentWidth = connector.getHeight() * verticalBend.getRawValue() / 100000f;
        IAutoShape guide = slide.getShapes().addAutoShape(ShapeType.Rectangle, rotatedX, rotatedY, segmentWidth, 1);
        guide.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        guide.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

        presentation.save("rotated-connector-segment-guide.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

समन्वय रूपांतरण के बाद लाल गाइड गणना किए गए खंड को चिह्नित करता है:

![connector-adjusted-4](connector-adjusted-4.png)

ये सूत्र उदाहरणों में उपयोग किए गए प्रीसेट को वर्णित करते हैं, किसी सार्वभौमिक कनेक्टर मॉडल को नहीं। किसी अन्य प्रीसेट पर समान गणना लागू करने से पहले समायोजन प्रकार, फ्रेम अभिविन्यास, और मान रेंज की जाँच करें।

## **कनेक्टर दिशा कोण खोजें**

एक सीधे कनेक्टर की दिशा उसकी चौड़ाई और ऊँचाई से, क्षैतिज एवं ऊर्ध्वाधर फ्लिप लागू करके, गणना की जा सकती है। निम्न उदाहरण स्लाइड निर्देशांक में सकारात्मक क्षैतिज अक्ष से घड़ी की दिशा में कोण रिपोर्ट करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IConnector connector = slide.getShapes().addConnector(ShapeType.StraightConnector1, 100, 100, 200, 100);

    boolean flipH = connector.getFrame().getFlipH() == NullableBool.True;
    boolean flipV = connector.getFrame().getFlipV() == NullableBool.True;
    float deltaX = connector.getWidth() * (flipH ? -1 : 1);
    float deltaY = connector.getHeight() * (flipV ? -1 : 1);
    double angle = Math.atan2(deltaY, deltaX) * 180.0 / Math.PI;

    if (angle < 0) {
        angle += 360;
    }

    System.out.printf("Connector direction: %.2f degrees%n", angle);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे जानूँ कि कोई कनेक्टर Shape से जुड़ सकता है या नहीं?**

Shape के [getConnectionSiteCount](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getConnectionSiteCount--) मान की जाँच करें। सकारात्मक मान का अर्थ है कि Shape कनेक्शन साइट प्रदान करता है। कनेक्टर के सिर को असाइन करने से पहले चयनित साइट इंडेक्स को वैध करें, क्योंकि साइट गणना Shape की ज्यामिति पर निर्भर करती है।

**क्या मैं कनेक्टर समायोजन को उसके संग्रह इंडेक्स से पहचान सकता हूँ?**

इंडेक्स केवल ज्ञात कनेक्टर प्रीसेट और संग्रह लेआउट के लिए अर्थपूर्ण होता है। मान बदलने से पहले [IAdjustValue.getType](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getType--) की जाँच करें, और जब समान अर्थ प्रकार कई बार उपस्थित हो तो अतिरिक्त जानकारी के लिए [IAdjustValue.getName](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iadjustvalue/#getName--) का उपयोग करें।

**जब जुड़े हुए Shape को हटाया जाता है तो क्या होता है?**

संबंधित कनेक्टर का सिर अलग हो जाता है। कनेक्टर स्लाइड पर बना रहता है और उसे हटाया, एक स्वतंत्र रेखा के रूप में स्थित, या किसी अन्य Shape से जोड़ा जा सकता है।

**क्या स्लाइड कॉपी होने पर कनेक्टर बाइंडिंग्स संरक्षित रहती हैं?**

आमतौर पर बाइंडिंग्स संरक्षित रहती हैं जब जुड़े हुए Shapes को स्लाइड के साथ कॉपी किया जाता है। यदि कनेक्टर को उसके लक्ष्य Shapes में से किसी एक के बिना कॉपी किया जाता है, तो प्रभावित सिर को पुनः जोड़ना आवश्यक होगा।