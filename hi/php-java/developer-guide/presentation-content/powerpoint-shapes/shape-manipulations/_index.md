---
title: PHP में प्रस्तुति आकृतियों का प्रबंधन
linktitle: आकृति हेरफेर
type: docs
weight: 40
url: /hi/php-java/shape-manipulations/
keywords:
- PowerPoint आकृति
- प्रस्तुति आकृति
- स्लाइड पर आकृति
- आकृति खोजें
- आकृति क्लोन करें
- आकृति हटाएँ
- आकृति छिपाएँ
- आकृति क्रम बदलें
- interop आकृति ID प्राप्त करें
- आकृति वैकल्पिक पाठ
- आकृति समायोजन बिंदु
- प्रीसेट आकृति समायोजन
- आकृति ज्यामिति
- आकृति लेआउट फ़ॉर्मेट
- आकृति SVG के रूप में
- आकृति को SVG में
- आकृति संरेखित करें
- आकृति फ़्लिप करें
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ प्रस्तुति आकृतियों को पहचानना, समायोजित करना, क्लोन करना, हटाना, छिपाना, पुनः क्रमबद्ध करना, निर्यात करना, संरेखित करना और फ़्लिप करना सीखें।"
---
## **समीक्षा**

Aspose.Slides for PHP via Java स्लाइड पर आकृतियों को क्रमबद्ध [ShapeCollection](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/) के रूप में दर्शाता है। यह संग्रह वह स्थान है जहाँ आप आकृतियों को खोजते और संशोधित करते हैं और उनका स्टैकिंग क्रम निर्धारित करता है: इंडेक्स `0` सबसे पीछे की आकृति है, जबकि अंतिम इंडेक्स सबसे आगे की आकृति को दर्शाता है।

यह लेख उसी मॉडल का अनुसरण करता है। यह पहले यह बताता है कि किसी आकृति को भरोसेमंद तरीके से कैसे पहचानें और पूर्वनिर्धारित आकृति समायोजन बिंदुओं को कैसे बदलें, फिर दिखाता है कि कैसे आकृति को क्लोन, हटाएँ, छिपाएँ, और पुनः क्रमबद्ध करें। अंतिम भाग लेआउट‑स्तर के फ़ॉर्मेटिंग, SVG निर्यात, संरेखण, और फ़्लिप सेटिंग्स को कवर करता है। प्रत्येक उदाहरण स्वतंत्र है, इसलिए आप केवल उन ऑपरेशनों का उपयोग कर सकते हैं जो आपके वर्कफ़्लो के लिए आवश्यक हैं।

## **आकृतियों को पहचानें और खोजें**

संग्रह इंडेक्स ज्ञात फ़ाइल को प्रोसेस करते समय सुविधाजनक होते हैं, लेकिन वे स्थिर पहचानकर्ता नहीं हैं। आकृति जोड़ने, हटाने या पुनः क्रमबद्ध करने से उनका इंडेक्स बदल सकता है। प्रस्तुति के लेखन और रखरखाव के अनुसार एक पहचानकर्ता चुनें:

- [Name](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getname/) डेवलपर‑नियंत्रित टेम्प्लेट्स के लिए उपयोगी है और PowerPoint के Selection Pane में आसानी से देखा जा सकता है। नाम संपादन योग्य होते हैं और अनिवार्य रूप से अद्वितीय नहीं होते, इसलिए यदि कोड उन पर निर्भर करता है तो नामकरण नियम स्थापित करें।
- [AlternativeText](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getalternativetext/) तब उपयोगी है जब कोई एक्सेसिबिलिटी विवरण या लेखक‑द्वारा दिया गया टैग पहले से ही आकृति की पहचान करता हो। यह उपयोगकर्ताओं को दिखता है, स्थानीयकृत या एक्सेसिबिलिटी के लिए पुनः लिखा जा सकता है, और अद्वितीय नहीं होता। अर्थपूर्ण एक्सेसिबिलिटी टेक्स्ट को चुपचाप डेटाबेस कुंजी के रूप में उपयोग न करें।
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getofficeinteropshapeid/) एक केवल‑पढ़ने योग्य पहचानकर्ता है जो स्लाइड के भीतर अद्वितीय होता है और PowerPoint इंटरऑप द्वारा उपयोग किए जाने वाले Shape ID से मेल खाता है। PowerPoint के साथ एकीकरण या आकृति के जीवनकाल के दौरान अस्पष्ट संदर्भ की आवश्यकता होने पर इसे उपयोग करें। क्लोन या पुनः निर्मित आकृति एक अलग आकृति होती है और उसका अपना ID प्राप्त करती है।

संबंधित [Shape::getUniqueId](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getuniqueid/) विधि प्रस्तुति‑स्कोप वाला पहचानकर्ता लौटाती है, लेकिन यह पहचानकर्ता ऐड‑इन्स के लिए लक्षित है और पुनः सौंपा जा सकता है। इसे स्थायी बाहरी कुंजी के रूप में नहीं लेना चाहिए। यदि दीर्घकालिक पहचान आवश्यक है, तो अनुप्रयोग डेटा में मैपिंग रखें और सत्यापित करें कि अपेक्षित आकृति अभी भी मौजूद है।

निम्न उदाहरण नाम से सटीक तुलना करके खोज करता है और स्लाइड‑स्कोप्ड इंटरऑप ID को रिपोर्ट करता है। जब टेम्प्लेट में अपेक्षित आकृति नहीं होती, तो कोड उस परिणाम को रिपोर्ट करता है न कि गलत ऑब्जेक्ट के साथ आगे बढ़ता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $targetShape = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "RevenueChart") {
            $targetShape = $shape;
            break;
        }
    }

    if ($targetShape === null) {
        echo "The shape 'RevenueChart' was not found on slide 1." . PHP_EOL;
    } else {
        $shapeName = java_values($targetShape->getName());
        $interopId = java_values($targetShape->getOfficeInteropShapeId());
        echo "Found " . $shapeName . "; interop ID: " . $interopId . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

जब कोई ऑपरेशन विशिष्ट आकृति प्रकार से जुड़ा हो, तो प्रकार‑विशिष्ट सदस्यों का उपयोग करने से पहले रन‑टाइम क्लास जांचें। यह उदाहरण तभी टेक्स्ट और वैकल्पिक टेक्स्ट को अपडेट करता है जब नामित ऑब्जेक्ट एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) हो।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $candidate = null;

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "StatusLabel") {
            $candidate = $shape;
            break;
        }
    }

    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if ($candidate !== null && java_instanceof($candidate, $autoShapeClass)) {
        $candidate->getTextFrame()->setText("Approved");
        $candidate->setAlternativeText("Approval status: approved");
        $presentation->save("identified-shape.pptx", SaveFormat::Pptx);
    } else {
        echo "'StatusLabel' is missing or is not an AutoShape." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **प्रीसेट आकृति समायोजन को पहचानें और संशोधित करें**

प्रीसेट ज्योमेट्री आकृतियों में समायोजन बिंदु हो सकते हैं जो कोने का आकार, तीर अनुपात, या चाप कोण जैसी विशेषताओं को नियंत्रित करते हैं। इन्हें पढ़ने‑के‑लिए केवल‑पढ़ने योग्य [GeometryShape::getAdjustments](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometryshape/#getAdjustments) संग्रह के माध्यम से एक्सेस करें। संग्रह स्वयं आकृति द्वारा प्रदान किया जाता है, लेकिन प्रत्येक [AdjustValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/) में वह मान होता है जिसे बदला जा सकता है।

केवल स्थिर संग्रह इंडेक्स पर निर्भर न रहें। समायोजनों के माध्यम से इटररेट करें और पढ़ने‑के‑लिए केवल‑पढ़ने योग्य [AdjustValue::getType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/#getType) विधि को देखें, जिसका [ShapeAdjustmentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeadjustmenttype/) मान बताता है कि समायोजन क्या नियंत्रित करता है। पढ़ने‑के‑लिए केवल‑पढ़ने योग्य [AdjustValue::getName](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/getname/) विधि अतिरिक्त पहचान जानकारी देती है और तब विशेष रूप से उपयोगी होती है जब किसी प्रीसेट में समान अर्थ वाले कई समायोजन होते हैं।

समायोजन के अर्थ से मेल खाने वाली विधि का उपयोग करें:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | गोल कोनों का आकार | [setRawValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/setrawvalue/) |
| `ArrowTailThickness` | तीर की पूँछ की मोटाई | `setRawValue` |
| `ArrowheadLength` | तीर सिर का आयाम | `setRawValue` |
| `ArrowheadWidth` | तीर सिर की चौड़ाई | `setRawValue` |
| `StartAngle` | पाई या चाप का प्रारंभिक कोण | [setAngleValue](https://reference.aspose.com/slides/hi/php-java/aspose.slides/adjustvalue/setanglevalue/) |
| `EndAngle` | पाई या चाप का समाप्ति कोण | `setAngleValue` |

`getType` और `getName` केवल‑पढ़ने योग्य जानकारी लौटाते हैं। `getRawValue` और `setRawValue` प्रीसेट की मूल ज्योमेट्री इकाइयों में पूर्णांक के साथ काम करते हैं, जबकि `getAngleValue` और `setAngleValue` डिग्री में कोण के साथ। समायोजनों की संख्या, क्रम, अर्थ, और वैध रेंज प्रीसेट के [GeometryShape::getShapeType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/geometryshape/#getShapeType) पर निर्भर करती है। एक प्रीसेट के लिए मान्य मान दूसरे के लिए अमान्य या अलग प्रभाव वाला हो सकता है।

जब `getType` `ShapeAdjustmentType::Custom` लौटाता है, तो API मानक सेमांटिक अर्थ नहीं पहचानती। `getName`, प्रीसेट प्रकार, और मौजूदा मान को जाँचें, और जब तक अपेक्षित अर्थ और रेंज ज्ञात न हो तब तक समायोजन को अपरिवर्तित रखें। मान्य प्रकारों के लिए भी, एक ही प्रकार कई बार आने पर पहले मान चुनने से बचें। कनेक्टर बेंड समायोजन के बारे में उदाहरण के लिए [Connector](/slides/hi/php-java/connector/) लेख देखें।

निम्न पूर्ण उदाहरण तीन प्रीसेट आकृतियों के डिफ़ॉल्ट और संशोधित संस्करण बनाता है। यह हर समायोजन पर इटररेट करता है, उसका नाम और प्रकार रिपोर्ट करता है, आकार‑संबंधी मानों को `setRawValue` से बदलता है, कोणों को `setAngleValue` से बदलता है, और परिणाम सहेजता है। बाईं कॉलम डिफ़ॉल्ट ज्योमेट्री रखती है; दाईं कॉलम समायोजित गोल आयत, चार‑मार्ग तीर, और पाई दिखाती है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeAdjustmentType;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // डिफ़ॉल्ट और समायोजित आकृति कॉलम के लिए हेडर जोड़ें।
    $defaultColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 20, 250, 30);
    $defaultColumnLabel->getTextFrame()->setText("Default preset geometry");
    $adjustedColumnLabel = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 390, 20, 250, 30);
    $adjustedColumnLabel->getTextFrame()->setText("Modified adjustment values");

    $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 80, 70, 160, 70);
    $modifiedRoundedRectangle = $slide->getShapes()->addAutoShape(ShapeType::RoundCornerRectangle, 430, 70, 160, 70);
    $modifiedRoundedRectangle->setName("ModifiedRoundedRectangle");

    $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 80, 180, 160, 110);
    $modifiedArrow = $slide->getShapes()->addAutoShape(ShapeType::QuadArrow, 430, 180, 160, 110);
    $modifiedArrow->setName("ModifiedQuadArrow");

    $slide->getShapes()->addAutoShape(ShapeType::Pie, 95, 330, 130, 130);
    $modifiedPie = $slide->getShapes()->addAutoShape(ShapeType::Pie, 445, 330, 130, 130);
    $modifiedPie->setName("ModifiedPie");

    $shapesToAdjust = [
        $modifiedRoundedRectangle,
        $modifiedArrow,
        $modifiedPie
    ];

    foreach ($shapesToAdjust as $shape) {
        $adjustmentCount = java_values($shape->getAdjustments()->size());
        for ($adjustmentIndex = 0; $adjustmentIndex < $adjustmentCount; $adjustmentIndex++) {
            $adjustment = $shape->getAdjustments()->get_Item($adjustmentIndex);
            $shapeName = java_values($shape->getName());
            $adjustmentName = java_values($adjustment->getName());
            $adjustmentType = java_values($adjustment->getType());
            echo $shapeName . " / " . $adjustmentName . ": " . $adjustmentType . PHP_EOL;

            switch ($adjustmentType) {
                case ShapeAdjustmentType::CornerSize:
                    $adjustment->setRawValue(5000);
                    break;
                case ShapeAdjustmentType::ArrowTailThickness:
                    $adjustment->setRawValue(25000);
                    break;
                case ShapeAdjustmentType::ArrowheadLength:
                    $adjustment->setRawValue(30000);
                    break;
                case ShapeAdjustmentType::ArrowheadWidth:
                    $adjustment->setRawValue(40000);
                    break;
                case ShapeAdjustmentType::StartAngle:
                    $adjustment->setAngleValue(30);
                    break;
                case ShapeAdjustmentType::EndAngle:
                    $adjustment->setAngleValue(300);
                    break;
                case ShapeAdjustmentType::Custom:
                    echo "Custom adjustment '" . $adjustmentName . "' was not changed." . PHP_EOL;
                    break;
            }
        }
    }

    $presentation->save("preset-shape-adjustments.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

समायोजन के सेमांटिक प्रकार को बदलने से पहले जांचने से कोड का इरादा स्पष्ट रहता है और यह मानते हुए त्रुटि से बचता है कि किसी विशिष्ट संग्रह इंडेक्स का अर्थ विभिन्न प्रीसेट आकृतियों में समान हो।

## **आकृति संग्रह को संशोधित करें**

जोड़ना, क्लोन करना, हटाना, और पुनः क्रमबद्ध करने की विधियाँ संग्रह पर तुरंत कार्य करती हैं। यदि कोई ऑपरेशन आकृतियों की संख्या या क्रम बदलता है, तो उस ऑपरेशन से पहले प्राप्त किए गए इंडेक्स पर निर्भर नहीं रहना चाहिए।

### **आकृति को क्लोन करें**

[ShapeCollection::addClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addclone/) एक स्वतंत्र प्रतिलिपि बनाता है और उसे लक्ष्य संग्रह के अंत में जोड़ता है। [ShapeCollection::insertClone](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/insertclone/) भी प्रतिलिपि बनाता है लेकिन निर्देशित z‑order इंडेक्स पर रखता है। वे ओवरलोड जो निर्देशांक स्वीकार करते हैं क्लोन का आकार बदले बिना स्थानांतरित करते हैं; चौड़ाई‑ऊँचाई वाले ओवरलोड इसे पुनः आकारित भी कर सकते हैं।

यह उदाहरण एक लक्ष्य स्लाइड बनाता है, लेबल वाले आयत को आगे की ओर क्लोन करता है, और दूसरा क्लोन पीछे जोड़ता है। किसी भी क्लोन में परिवर्तन स्रोत आकृति को नहीं बदलते।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideLayoutType;

$presentation = new Presentation();
try {
    $sourceSlide = $presentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
    $sourceShape->setName("SourceLabel");
    $sourceShape->getTextFrame()->setText("Source");

    $blankLayout = $presentation->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destinationSlide = $presentation->getSlides()->addEmptySlide($blankLayout);

    $frontCloneShape = $destinationSlide->getShapes()->addClone($sourceShape, 80, 80);
    $frontCloneShape->setName("FrontClone");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    if (java_instanceof($frontCloneShape, $autoShapeClass)) {
        $frontCloneShape->getTextFrame()->setText("Front clone");
    } else {
        echo "The front clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $backCloneShape = $destinationSlide->getShapes()->insertClone(0, $sourceShape, 80, 180);
    $backCloneShape->setName("BackClone");
    if (java_instanceof($backCloneShape, $autoShapeClass)) {
        $backCloneShape->getTextFrame()->setText("Back clone");
    } else {
        echo "The back clone is not an AutoShape; its text was not changed." . PHP_EOL;
    }

    $presentation->save("cloned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

क्लोनिंग आकृति की सामग्री और फ़ॉर्मेटिंग, जिसमें उसका नाम और वैकल्पिक टेक्स्ट शामिल है, को कॉपी करती है। जब इन मानों का अद्वितीय होना आवश्यक हो, तो क्लोन को नए तार्किक पहचानकर्ता सौंपें। जटिल आकृतियों द्वारा उपयोग किए गए संसाधन प्रस्तुति द्वारा संभाले जाते हैं, लेकिन क्लोन एक नया संग्रह आइटम होता है जिसका अपना आकृति पहचानकर्ता होता है।

### **आकृतियों को हटाएँ**

[ShapeCollection::remove](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/remove/) किसी विशिष्ट आकृति ऑब्जेक्ट को उसके संग्रह से हटाता है। इंडेक्स्ड इटरशन के दौरान कई मिलानों को हटाते समय अंत से शुरू होकर ट्रैवर्स करें ताकि शेष प्रत्येक इंडेक्स वैध बना रहे।

यह उदाहरण एक नियत नाम वाली हर आकृति को हटाता है। यह वर्तमान इंडेक्स पर आकृति पढ़ता है, न कि किसी स्थिर संग्रह आइटम को, और अनावश्यक कास्ट नहीं करता।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $keepShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
    $keepShape->setName("Keep");

    $firstTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
    $firstTemporaryShape->setName("Temporary");

    $secondTemporaryShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
    $secondTemporaryShape->setName("Temporary");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = $shapeCount - 1; $shapeIndex >= 0; $shapeIndex--) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "Temporary") {
            $slide->getShapes()->remove($shape);
        }
    }

    $presentation->save("removed-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

हटाने के बाद आकृति गिनती और बाद की आकृतियों के इंडेक्स बदल जाते हैं। अप्रभावित आकृतियों के संदर्भ सहेजे गए इंडेक्स की तुलना में अधिक विश्वसनीय रहते हैं। कनेक्टर, एनीमेशन, और अन्य प्रस्तुति विशेषताओं को भी ध्यान में रखें जो हटाए गए ऑब्जेक्ट को संदर्भित कर सकते हैं; दृश्य रूप से आकृति हटाने से स्लाइड की उपस्थिति से अधिक चीज़ें बदल सकती हैं।

### **आकृति को छिपाएँ**

[Shape::setHidden](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/sethidden/) को `true` पर सेट करने से आकृति संग्रह में बनी रहती है लेकिन सामान्य स्लाइड शो में नहीं दिखती। इसका इंडेक्स, फ़ॉर्मेट और सामग्री कोड के लिए उपलब्ध रहती है, इसलिए वैकल्पिक तत्व जिन्हें बाद में पुनः सक्रिय किया जा सकता है, उन्हें छिपाना उपयुक्त है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $visibleShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
    $visibleShape->setName("VisibleLabel");

    $optionalShape = $slide->getShapes()->addAutoShape(ShapeType::Moon, 240, 40, 100, 100);
    $optionalShape->setName("OptionalDecoration");

    $shapes = $slide->getShapes();
    $shapeCount = java_values($shapes->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $shapes->get_Item($shapeIndex);
        $shapeName = java_values($shape->getName());
        if ($shapeName === "OptionalDecoration") {
            $shape->setHidden(true);
        }
    }

    $presentation->save("hidden-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

छिपाना विलोपन या सुरक्षा नहीं है। ऑब्जेक्ट अभी भी उपयोगकर्ता या कोड द्वारा खोजा और अनहाइड किया जा सकता है, और यह प्रस्तुति फ़ाइल का हिस्सा बना रहता है।

### **Z‑Order बदलें**

ओवरलैपिंग आकृतियों को संग्रह क्रम में पेंट किया जाता है। [ShapeCollection::reorder](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/reorder/) मौजूदा आकृति को लक्ष्य इंडेक्स पर ले जाता है बिना क्लोन किए। इंडेक्स `0` पीछे है; `size() - 1` आगे है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $blueRectangle = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
    $blueRectangle->setName("BlueRectangle");
    $blueRectangle->getFillFormat()->setFillType(FillType::Solid);
    $blueRectangle->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 255));

    $orangeEllipse = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
    $orangeEllipse->setName("OrangeEllipse");
    $orangeEllipse->getFillFormat()->setFillType(FillType::Solid);
    $orangeEllipse->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $frontIndex = java_values($slide->getShapes()->size()) - 1;
    $slide->getShapes()->reorder($frontIndex, $blueRectangle);
    $presentation->save("reordered-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

आयत पहले बनाई जाती है और प्रारंभ में दीर्घवृत्त के पीछे रहती है। इसे अंतिम इंडेक्स पर ले जाने से वह आगे आ जाती है। सभी संबंधित आकृतियों को जोड़ने या क्लोन करने के बाद z‑order को अंतिम रूप दें, क्योंकि ये ऑपरेशन नए संग्रह आइटम जोड़ते या सम्मिलित करते हैं और इच्छित स्टैक को बदल सकते हैं।

## **लेआउट स्लाइड्स पर आकृतियों की जांच करें**

सामान्य स्लाइड, लेआउट स्लाइड, और मास्टर स्लाइड के अलग‑अलग आकृति संग्रह होते हैं। लेआउट संग्रह में एक आकृति साधारण स्लाइड पर समान स्थिति वाली आकृति से अलग ऑब्जेक्ट होती है। लेआउट फ़ॉर्मेटिंग को समझने या बदलने की आवश्यकता होने पर लेआउट आकृतियों की जांच करें।

निम्न उदाहरण प्रत्येक लेआउट आकृति के [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getfillformat/) और [LineFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/getlineformat/) को पढ़ता है, बिना यह मानते हुए कि हर आकृति `AutoShape` है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $layoutSlides = $presentation->getLayoutSlides();
    $layoutSlideCount = java_values($layoutSlides->size());
    for ($layoutIndex = 0; $layoutIndex < $layoutSlideCount; $layoutIndex++) {
        $layoutSlide = $layoutSlides->get_Item($layoutIndex);
        $layoutShapes = $layoutSlide->getShapes();
        $layoutShapeCount = java_values($layoutShapes->size());
        for ($shapeIndex = 0; $shapeIndex < $layoutShapeCount; $shapeIndex++) {
            $shape = $layoutShapes->get_Item($shapeIndex);
            $fillType = java_values($shape->getFillFormat()->getFillType());
            $lineWidth = java_values($shape->getLineFormat()->getWidth());
            $layoutName = java_values($layoutSlide->getName());
            $shapeName = java_values($shape->getName());
            echo $layoutName . " / " . $shapeName . ": fill=" . $fillType . ", line width=" . $lineWidth . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

लेआउट को संपादित करने से कई स्लाइडों पर असर पड़ सकता है जो इसे उपयोग करती हैं। लेआउट आकृति बदलने से पहले तय करें कि क्या कोई सामान्य स्लाइड वह ऑब्जेक्ट विरासत में लेती है या स्थानीय ओवरराइड रखती है, और उस लेआउट को उपयोग करने वाली हर स्लाइड का परीक्षण करें।

## **आकृति को SVG में निर्यात करें**

[Shape::writeAsSvg](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/writeassvg/) एक आकृति की रेंडर की गई सामग्री को स्ट्रीम में लिखता है। परिणाम में केवल आकृति होती है, पूरी स्लाइड पृष्ठभूमि या पड़ोसी आकृतियों नहीं।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shapeCount = java_values($slide->getShapes()->size());

    if ($shapeCount === 0) {
        echo "Slide 1 does not contain a shape to export." . PHP_EOL;
    } else {
        $shape = $slide->getShapes()->get_Item(0);
        $svgStream = null;
        try {
            $svgStream = new Java("java.io.FileOutputStream", "shape.svg");
            $shape->writeAsSvg($svgStream);
        } catch (JavaException $exception) {
            echo "The SVG file could not be written: " . $exception->getMessage() . PHP_EOL;
        } finally {
            if ($svgStream !== null && !java_is_null($svgStream)) {
                $svgStream->close();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

रेंडरिंग के दौरान प्रस्तुति को खुला रखें। आउटपुट आकृति के फ़ॉर्मेटिंग और फ़ॉन्ट व छवियों जैसे संसाधनों पर निर्भर करता है। यदि आपको पूरी रचना चाहिए तो स्लाइड को निर्यात करें, न कि व्यक्तिगत आकृति को। कॉलर स्ट्रीम का स्वामी होता है और उसे बंद करना चाहिए।

## **आकृतियों को संरेखित करें**

[SlideUtil::alignShapes](https://reference.aspose.com/slides/hi/php-java/aspose.slides/slideutil/alignshapes/) ओवरलोड सभी आकृतियों या चयनित संग्रह इंडेक्स को संरेखित कर सकते हैं। [ShapesAlignmentType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapesalignmenttype/) किनारा, केंद्र रेखा, या वितरण मोड निर्दिष्ट करता है। `alignToSlide` को `true` करने से स्लाइड के किनारों के सापेक्ष संरेखण होगा; `false` करने से चयनित आकृतियों के आपस में सापेक्ष संरेखण होगा।

यह उदाहरण तीन आकृतियों को स्लाइड के शीर्ष किनारे के साथ संरेखित करता है। संरेखण से पहले प्रतिपादित आकृति संदर्भों को उनके वर्तमान इंडेक्स में तुरंत बदल दिया जाता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\ShapesAlignmentType;
use aspose\slides\SlideUtil;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $firstShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
    $secondShape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
    $thirdShape = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
    $firstShape->setName("FirstAlignedShape");
    $secondShape->setName("SecondAlignedShape");
    $thirdShape->setName("ThirdAlignedShape");

    $shapeIndexes = [
        java_values($slide->getShapes()->indexOf($firstShape)),
        java_values($slide->getShapes()->indexOf($secondShape)),
        java_values($slide->getShapes()->indexOf($thirdShape))
    ];

    SlideUtil::alignShapes(ShapesAlignmentType::AlignTop, true, $slide, $shapeIndexes);
    $presentation->save("aligned-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

संरेखण स्थिति बदलता है, न कि z‑order। सापेक्ष संरेखण के लिए आमतौर पर कम से कम दो आकृतियों की आवश्यकता होती है, जबकि क्षैतिज या ऊर्ध्वाधर वितरण के लिए स्पेसिंग निर्धारित करने हेतु पर्याप्त आकृतियों की जरूरत होती है। संग्रह को संशोधित करने के बाद इंडेक्स को पुनः गणना करें उसके बाद विधि को कॉल करें।

## **आकृति को फ़्लिप करें**

[ShapeFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapeframe/) क्लास स्थिति, आकार, क्षैतिज और लंबवत फ़्लिप सेटिंग्स, तथा घुमाव को संग्रहीत करता है। इसके `getFlipH` और `getFlipV` मान [NullableBool](https://reference.aspose.com/slides/hi/php-java/aspose.slides/nullablebool/) का उपयोग करते हैं: `True` फ़्लिप को सक्षम करता है, `False` इसे अक्षम करता है, और `NotDefined` अनिर्दिष्ट/डिफ़ॉल्ट स्थिति को बरकरार रखता है।

नीचे दिया गया इनपुट प्रस्तुति एक अनफ़्लिप्ड आकृति शामिल करती है।

![फ़्लिप करने से पहले का आकृति](shape_to_be_flipped.png)

उदाहरण सभी अन्य फ्रेम मानों को बरकरार रखता है और केवल दो फ़्लिप सेटिंग्स को बदलता है। यह महत्वपूर्ण है क्योंकि नया [Frame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/setframe/) असाइन करने से पूरा फ्रेम प्रतिस्थापित हो जाता है।

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeFrame;

$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $frame = $shape->getFrame();

    $horizontalFlip = java_values($frame->getFlipH());
    $verticalFlip = java_values($frame->getFlipV());
    echo "Horizontal flip before change: " . $horizontalFlip . PHP_EOL;
    echo "Vertical flip before change: " . $verticalFlip . PHP_EOL;

    $shape->setFrame(new ShapeFrame($frame->getX(), $frame->getY(), $frame->getWidth(), $frame->getHeight(), NullableBool::True, NullableBool::True, $frame->getRotation()));

    $presentation->save("flipped-shape.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सहेजा गया आकृति क्षैतिज और लंबवत दोनों दिशा में प्रतिबिंबित हो जाता है, जबकि उसकी स्थिति, आकार, और घुमाव वही रहता है।

![फ़्लिप करने के बाद का आकृति](flipped_shape.png)

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मुझे आकृति पहचानकर्ता के रूप में संग्रह इंडेक्स का उपयोग करना चाहिए?**

केवल短 अवधि के प्रोसेसिंग के लिए जब संग्रह ऑपरेशन से पहले नहीं बदलता। लेखित टेम्प्लेट्स के लिए मान्य `Name` या `AlternativeText` नियम को प्राथमिकता दें, या स्लाइड‑स्कोप्ड इंटरऑप कार्य के लिए `OfficeInteropShapeId` उपयोग करें।

**क्या आकृति को छिपाने से वह z‑order से हट जाता है?**

नहीं। छिपी हुई आकृति वही इंडेक्स पर संग्रह में रहती है। इसे खोजा, पुनः क्रमबद्ध, संपादित या फिर से दृश्यमान किया जा सकता है।

**क्लोन की गई आकृति दूसरे आकृति के सामने क्यों दिखी?**

`addClone` क्लोन को संग्रह के अंत में जोड़ता है, जो z‑order का अग्रभाग है। निर्दिष्ट इंडेक्स चुनने के लिए `insertClone` उपयोग करें या सभी आकृतियों को जोड़ने के बाद `reorder` करें।

**क्या मैं प्रीसेट आकृति समायोजन को पहचानने के लिए स्थिर इंडेक्स का उपयोग कर सकता हूँ?**

केवल तब जब आप सटीक प्रीसेट और संग्रह लेआउट को मान्य कर चुके हों। `GeometryShape::getAdjustments` के माध्यम से इटररेट करके `AdjustValue::getType` की जाँच करें; जब समान सेमांटिक प्रकार कई बार प्रकट हो तो अतिरिक्त जानकारी के लिए `AdjustValue::getName` का उपयोग करें।