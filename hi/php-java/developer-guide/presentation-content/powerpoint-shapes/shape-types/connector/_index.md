---
title: PHP का उपयोग करके प्रस्तुतियों में कनेक्टर प्रबंधित करें
linktitle: कनेक्टर
type: docs
weight: 10
url: /hi/php-java/connector/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ सीधे, बेंडेड और कर्व्ड PowerPoint कनेक्टर को जोड़ना, संलग्न करना, रीरूट करना, समायोजित करना और निरीक्षण करना सीखें।"
---
## **परिचय**

एक कनेक्टर एक लाइन है जो किसी एक आकार के हिलने पर भी दोनों आकारों से जुड़ा रहता है। इसके अंत कनेक्शन साइट से जुड़े हैं, जो PowerPoint में हरे बिंदुओं से दिखाए जाते हैं। कुछ बेंडेड और कर्व्ड कनेक्टर ओरेंज डॉट्स से दिखाए गए समायोजन बिंदु भी प्रकट करते हैं, जो व्यक्तिगत कनेक्टर सेगमेंट की स्थिति को नियंत्रित करते हैं।

Aspose.Slides कनेक्टर्स को [Connector](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/) क्लास के जरीए दिखाता है। आप उन्हें बना सकते हैं, उनके अंत को आकार से जुड़ा सकते हैं, कनेक्शन साइट चुने सकते हैं, रूट बदल सकते हैं, और समायोजन बिंदु वाले कनेक्टर की ज्यामिति को बदल सकते हैं।

## **कनेक्टर प्रकार**

[ShapeType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapetype/) क्लास में सीधे, बेंडेड और कर्व्ड कनेक्टर के प्रीसेट शामिल हैं। नीचे टेबल में उपलब्ध कनेक्टर ज्यामिति और प्रत्येक प्रीसेट द्वारा परिभाषित समायोजन बिंदुओं की संख्या दिखायी गई है।

| कनेक्टर | Image | समायोजन बिंदुओं की संख्या |
|---|---|---|
| `ShapeType::Line` | ![shapetype-lineconnector](shapetype-lineconnector.png) | 0 |
| `ShapeType::StraightConnector1` | ![shapetype-straightconnector1](shapetype-straightconnector1.png) | 0 |
| `ShapeType::BentConnector2` | ![shapetype-bent-connector2](shapetype-bent-connector2.png) | 0 |
| `ShapeType::BentConnector3` | ![shapetype-bentconnector3](shapetype-bentconnector3.png) | 1 |
| `ShapeType::BentConnector4` | ![shapetype-bentconnector4](shapetype-bentconnector4.png) | 2 |
| `ShapeType::BentConnector5` | ![shapetype-bentconnector5](shapetype-bentconnector5.png) | 3 |
| `ShapeType::CurvedConnector2` | ![shapetype-curvedconnector2](shapetype-curvedconnector2.png) | 0 |
| `ShapeType::CurvedConnector3` | ![shapetype-curvedconnector3](shapetype-curvedconnector3.png) | 1 |
| `ShapeType::CurvedConnector4` | ![shapetype-curvedconnector4](shapetype-curvedconnector4.png) | 2 |
| `ShapeType::CurvedConnector5` | ![shapetype.curvedconnector5](shapetype.curvedconnector5.png) | 3 |

समायोजन बिंदुओं की संख्या और अर्थ चयनित कनेक्टर प्रीसेट का हिस्सा हैं। यह मान नहीं लें कि दो विभिन्न कनेक्टर प्रकार एक ही कलेक्शन लेआउट को प्रकट करते हैं।

## **दो आकारों को जोड़ें**

कनेक्टर जोड़ने के लिए [ShapeCollection::addConnector](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addconnector/) का उपयोग करें, और उसके अंत को जोड़ने के लिए [Connector::setStartShapeConnectedTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/setstartshapeconnectedto/) और [Connector::setEndShapeConnectedTo](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/setendshapeconnectedto/) का उपयोग करें। दोनों अंत जुड़ने के बाद, [Connector::reroute](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/reroute/) शेप्स के बीच एक छोटी रूट का चयन करता है।

नीचे उदाहरण एक ellipse और एक rectangle को bent कनेक्टर से जोड़ता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);
    $connector->reroute();

    $presentation->save("connected-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="warning" title="Warning" %}}
`reroute` को कॉल करने से [Connector::setStartShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/setstartshapeconnectionsiteindex/) और [Connector::setEndShapeConnectionSiteIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/connector/setendshapeconnectionsiteindex/) के मान बदल सकते हैं। राउटिंग के बाद विशिष्ट कनेक्शन साइट को फिर से असाइन करें यदि उन साइट्स को स्थिर रहना है।
{{% /alert %}}

## **एक कनेक्शन साइट चुनें**

प्रत्येक कनेक्ट होने योग्य आकार [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getconnectionsitecount/) के जरीए अपनी साइट संख्या बताता है। कनेक्टर के अंत को असाइन करने से पहले एक जिरो‑बेस्ड साइट इंडेक्स को वैध करें; साइट की संख्या आकार ज्यामिति पर निर्भर करती है।

यह उदाहरण ellipse पर किसी विशिष्ट साइट पर कनेक्टर को जोड़ता है यदि वह साइट मौजूद हो:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $ellipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 40, 80, 120, 80);
    $rectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 320, 240, 140, 80);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector3, 0, 0, 10, 10);

    $connector->setStartShapeConnectedTo($ellipse);
    $connector->setEndShapeConnectedTo($rectangle);

    $preferredSiteIndex = 2;
    $connectionSiteCount = java_values($ellipse->getConnectionSiteCount());
    if ($preferredSiteIndex < $connectionSiteCount) {
        $connector->setStartShapeConnectionSiteIndex($preferredSiteIndex);
    } else {
        echo "The ellipse has only " . $connectionSiteCount . " connection sites." . PHP_EOL;
    }

    $presentation->save("specific-connection-site.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **कनेक्टर बिंदु को समायोजित करें**

समायोजन बिंदु वाले कनेक्टर [GeometryShape::getAdjustments](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometryshape/#getadjustments) के जरीए इनके तक पहुँच प्रदान करते हैं। किसी भी [AdjustValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/) को बदलने से पहले उसके [AdjustValue::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/#gettype) मान को जांचें और [AdjustValue::setRawValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/setrawvalue/) से बदलें। प्रीसेट शेप समायोजनों की सामान्य नियम [Shape Manipulation](/slides/hi/php-java/shape-manipulations/) में वर्णित हैं।

कनेक्टर समायोजन की संख्या, क्रम, अर्थ और वैध मान सेट प्रीसेट पर निर्भर करते हैं। समायोजन का टाइप केवल‑पढ़ने योग्य है, जबकि समायोजन का मान लिखा जा सकता है। [AdjustValue::getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/getname/) विधि उन प्रकरणों में अतिरिक्त पहचान प्रदान करती है जब कनेक्टर में एक से अधिक एक‑जैसे सेमांटिक टाइप के समायोजन होते हैं।

### **रुकावट के चारों ओर मार्ग**

निम्न लेआउट में `BentConnector5` कनेक्टर दो आकारों के बीच तीसरे आकार से गुज़रता है:

![connector-obstruction](connector-obstruction.png)

यह कोड रुकावट वाले कनेक्टर को बनाता है:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $presentation->save("connector-obstruction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

वर्टिकल बेंड को हिलाने से रूट बदल जाता है और कनेक्टर रुकावट को बायपास करता है:

![connector-obstruction-fixed](connector-obstruction-fixed.png)

इंडेक्स `1` हमेशा वर्टिकल बेंड को दर्शाता यह मान नही लें; यह उदाहरण `ConnectorBendPositionY` को ढूंढकर केवल उस सेमांटिक टाइप के मौजूद होने पर बदलता है:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 150, 150, 75);
    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 400, 100, 50);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 70, 30);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector5, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(0, 0, 0));
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setStartShapeConnectionSiteIndex(2);

    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentName = java_values($adjustment->getName());
        $adjustmentType = java_values($adjustment->getType());
        $rawValue = java_values($adjustment->getRawValue());
        echo $adjustmentName . ": " . $adjustmentType . ", raw value = " . $rawValue . PHP_EOL;
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
            break;
        }
    }

    if ($verticalBend === null) {
        echo "The connector does not expose a vertical bend adjustment." . PHP_EOL;
    } else {
        $verticalBend->setRawValue(60000);
        $presentation->save("connector-obstruction-fixed.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

`BentConnector5` में दो `ConnectorBendPositionX` और एक `ConnectorBendPositionY` समायोजन हैं। यदि आपको ज़रूरी टाइप एक से अधिक बार मिलता है, तो `getName` और उस प्रीसेट की जानी‑पहचानी ज्यामिति को जांचें पहले। यदि कोई समायोजन `ShapeAdjustmentType::Custom` बताता है, तो उसका अर्थ और रेंज प्रीसेट‑विशिष्ट है और सहमति ज्ञात होने तक न बदलें।

## **समायोजन मानों को कनेक्टर ज्यामिति से जोड़ें**

बेंडेड कनेक्टर में समायोजन मानों से व्यक्तिगत सेगमेंट की स्थिति अनुमानित की जा सकती है। ये गणना कनेक्टर प्रीसेट पर निर्भर करती है:

- `BentConnector4` आमतौर पर एक `ConnectorBendPositionX` और एक `ConnectorBendPositionY` समायोजन प्रकट करता है।
- इन बेंड पोज़िशन के लिए, `getRawValue` से प्राप्त मान को `100000` से भागने पर फ़्रैक्शन मिलता है, जैसा कि नीचे उदाहरण में दिया गया है।
- कनेक्टर फ़्रेम को घुमाया या उलटा भी जाया सकता है, इसलिए फ़्रेम कोऑर्डिनेट को स्लाइड कोऑर्डिनेट से तुलना से पहले परिवर्तित करना पड़ेगा।

नीचे उदाहरण पहले समायोजन के टाइप की पहचान करते हुए समायोजन को पाते हैं। इनमें कलेक्शन इंडेक्स को पोर्टेबल आईडेंटिफ़ायर के रूप में नहीं गिना जाता।

### **अविकृत कनेक्टर**

प्रारंभिक लेआउट में दो टेक्स्ट शेप `BentConnector4` से जुड़े हैं:

![connector-shape-complex](connector-shape-complex.png)

यह उदाहरण कनेक्टर को इंस्पेक्ट करता है और उसके हॉरिज़ॉन्टल और वर्टिकल बेंड समायोजन को प्राप्त करता है:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $targetShape->getTextFrame()->setText("To");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        echo $adjustment->getName() . ": " . $adjustment->getType() . ", raw value = " . $adjustment->getRawValue() . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

दोनों बेंड को बदलने के लिए, प्रत्येक अपेक्षित टाइप को डूँढ़ें और दोनों मिलने के बाद मानों को बदलें:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);
        $presentation->save("connector-adjusted.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

परिणाम स्वरूप एक ऐसा कनेक्टर मिलता है जिसके हॉरिज़ॉन्टल और वर्टिकल सेगमेंट हिल गए हैं:

![connector-adjusted-1](connector-adjusted-1.png)

सेमांटिक टाइप पहचान लेने के बाद, इन मानों को कनेक्टर‑फ़्रेम कोऑर्डिनेट में बदल सकते हैं। यह उदाहरण दो बेंड समायोजन से नियंत्रित वर्टिकल सेगमेंट पर एक पतली आयत ड्रॉ करता है:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(3);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(2);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $x = $connectorX + $connectorWidth * $horizontalBendValue / 100000;
        $y = $connectorY;
        $height = $connectorHeight * $verticalBendValue / 100000;
        $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 1, $height);
        $presentation->save("connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

गाइड शेप गणित सेगमेंट को दर्शाता है:

![connector-adjusted-2](connector-adjusted-2.png)

### **घूर्णित या उलटा कनेक्टर**

जब उसी ज्यामिति का कनेक्टर वर्टिकली ओरिएंटेड होता है, तो [Shape::getFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getframe/), [ShapeFrame::getFlipH](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeframe/getfliph/), और [ShapeFrame::getFlipV](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeframe/getflipv/) मान कनेक्टर‑फ़्रेम कोऑर्डिनेट को स्लाइड कोऑर्डिनेट से बदलने पर प्रभाव डालते हैं।

यह उदाहरण वर्टिकली ओरिएंटेड कनेक्टर को बनाता और समायोजित करता है:

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $sourceShape->getTextFrame()->setText("From");
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $targetShape->getTextFrame()->setText("To 1");
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);

    $connector->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::Triangle);
    $connector->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $connector->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(102, 205, 170));
    $connector->getLineFormat()->setWidth(3);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 20000);
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $rawValue = java_values($adjustment->getRawValue());
            $adjustment->setRawValue($rawValue + 200000);
        }
    }

    $presentation->save("vertical-connector-adjusted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

समायोजित कनेक्टर आकारों के बीच वर्टिकली दिखाई देता है:

![connector-adjusted-3](connector-adjusted-3.png)

किसी मनचाहे रोटेशन कोण `alpha` के लिए, कनेक्टर‑फ़्रेम पॉइंट `(x, y)` को फ़्रेम सेंटर `(x0, y0)` के आसपास घुमाएँ:

`X = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0`

`Y = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0`

नीचे कोड 90‑डिग्री ओरिएंटेशन को हैंडल करता है और संबंधित कनेक्टर सेगमेंट पर एक लाल गाइड ड्रॉ करता है:

```php
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;
use java\awt\Color;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 60, 25);
    $targetShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 400, 60, 25);
    $connector = $slide->getShapes()->addConnector(ShapeType::BentConnector4, 20, 20, 400, 300);
    $connector->setStartShapeConnectedTo($sourceShape);
    $connector->setStartShapeConnectionSiteIndex(2);
    $connector->setEndShapeConnectedTo($targetShape);
    $connector->setEndShapeConnectionSiteIndex(3);

    $horizontalBend = null;
    $verticalBend = null;
    $adjustmentCount = java_values($connector->getAdjustments()->size());
    for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
        $adjustment = $connector->getAdjustments()->get_Item($adjustmentIndex);
        $adjustmentType = java_values($adjustment->getType());
        if ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionX) {
            $horizontalBend = $adjustment;
        } elseif ($adjustmentType == ShapeAdjustmentType::ConnectorBendPositionY) {
            $verticalBend = $adjustment;
        }
    }

    if ($horizontalBend === null || $verticalBend === null) {
        echo "The connector does not expose the expected bend adjustments." . PHP_EOL;
    } else {
        $horizontalBendValue = java_values($horizontalBend->getRawValue());
        $verticalBendValue = java_values($verticalBend->getRawValue());
        $horizontalBendValue += 20000;
        $verticalBendValue += 200000;
        $horizontalBend->setRawValue($horizontalBendValue);
        $verticalBend->setRawValue($verticalBendValue);

        $frame = $connector->getFrame();
        $connectorX = java_values($connector->getX());
        $connectorY = java_values($connector->getY());
        $connectorWidth = java_values($connector->getWidth());
        $connectorHeight = java_values($connector->getHeight());
        $flipH = java_values($frame->getFlipH()) == NullableBool::True;
        $flipV = java_values($frame->getFlipV()) == NullableBool::True;
        $centerX = java_values($frame->getCenterX());
        $centerY = java_values($frame->getCenterY());

        $x = $connectorX;
        $y = $connectorY;
        if ($flipH) {
            $x += $connectorWidth;
        }
        if ($flipV) {
            $y += $connectorHeight;
        }

        $x += $connectorWidth * $horizontalBendValue / 100000;
        $rotatedX = $centerX - $y + $centerY;
        $rotatedY = $x - $centerX + $centerY;
        $segmentWidth = $connectorHeight * $verticalBendValue / 100000;
        $guide = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $rotatedX, $rotatedY, $segmentWidth, 1);
        $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new Color(255, 0, 0));

        $presentation->save("rotated-connector-segment-guide.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

लाल गाइड कोऑर्डिनेट परिवर्तन के बाद गणित सेगमेंट को दर्शाता है:

![connector-adjusted-4](connector-adjusted-4.png)

ये फ़ॉर्मूले उदाहरण में उपयोग की गई प्रीसेट ज्यामिति के लिए हैं, सभी कनेक्टर मॉडलों के लिए सर्वत्र नहीं। समायोजन टाइप, फ़्रेम ओरिएंटेशन और मान रेंज को पहले साथ लेकर समान गणना को दूसरे प्रीसेट पर लगाने से पहले पुष्टिकरण करें।

## **कनेक्टर दिशा कोण खोजें**

सीधे कनेक्टर की दिशा को उसकी चौड़ाई और ऊँचाई से गणना की जा सकती है, हॉरिज़ॉन्टल और वर्टिकल फ़्लिप को ध्यान में रखते हुए। नीचे उदाहरण स्लाइड कोऑर्डिनेट में पॉज़िटिव हॉरिज़ॉन्टल एक्सिस से घड़ी दिशा कोण को रिपोर्ट करता है:

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $connector = $slide->getShapes()->addConnector(ShapeType::StraightConnector1, 100, 100, 200, 100);

    $frame = $connector->getFrame();
    $flipH = java_values($frame->getFlipH()) == NullableBool::True;
    $flipV = java_values($frame->getFlipV()) == NullableBool::True;
    $width = java_values($connector->getWidth());
    $height = java_values($connector->getHeight());
    $deltaX = $width * ($flipH ? -1 : 1);
    $deltaY = $height * ($flipV ? -1 : 1);
    $angle = atan2($deltaY, $deltaX) * 180.0 / pi();

    if ($angle < 0) {
        $angle += 360;
    }

    printf("Connector direction: %.2f degrees%s", $angle, PHP_EOL);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहचान सकता हूँ कि कोई कनेक्टर आकार से जुड़ सकता है?**

आकार की [Shape::getConnectionSiteCount](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getconnectionsitecount/) मान को जांचें। एक सकारात्मक गणना बताती है कि आकार कनेक्शन साइट प्रकट करता है। किसी भी कनेक्टर अंत को असाइन करने से पहले साइट इंडेक्स को मान्य करें।

**क्या मैं कलेक्शन इंडेक्स से कनेक्टर समायोजन की पहचान कर सकता हूँ?**

इंडेक्स सिर्फ़ एक ज्ञात कनेक्टर प्रीसेट और कलेक्शन लेआउट के लिए अर्थ रखा है। मान बदलने से पहले [AdjustValue::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/#gettype) को जांचें, और यदि एक से अधिक एक‑जैसे सेमांटिक टाइप हैं तो अतिरिक्त जानकारी के लिए [AdjustValue::getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/getname/) का उपयोग करें।

**जब जुड़ा हुआ आकार हटा दिया जाता है तो क्या होता है?**

संबंधित कनेक्टर अंत डिटैच हो जाता है। कनेक्टर स्लाइड पर रहता है और इसे हटा सकते हैं, फ़्री लाइन के रूप में पोज़िशन कर सकते हैं, या दूसरे आकार से जुड़ा सकते हैं।

**क्या स्लाइड कॉपी करने पर कनेक्टर बाइंडिंग संरक्षित रहती है?**

आमतौर पर बाइंडिंग संरक्षित रहती है जब कनेक्टेड आकारों को स्लाइड के साथ कॉपी किया जाता है। यदि कनेक्टर को उसके लक्ष्य आकार बिना कॉपी किया जा ता है, तो प्रभावित अंत को फिर से जोड़ना पड़ेगा।