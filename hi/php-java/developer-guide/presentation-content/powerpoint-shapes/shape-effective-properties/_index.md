---
title: PHP में प्रस्तुतियों से शेप की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करें
linktitle: इफ़ेक्टिव प्रॉपर्टीज़
type: docs
weight: 50
url: /hi/php-java/shape-effective-properties/
keywords:
- आकार प्रॉपर्टीज़
- कैमरा प्रॉपर्टीज़
- लाइट रिग
- बेवल शेप
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट हाईट
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "जाने कैसे Aspose.Slides for PHP via Java सटीक PowerPoint रेंडरिंग के लिए इफ़ेक्टिव शेप प्रॉपर्टीज़ की गणना और लागू करता है।"
---
## **अवलोकन**

यह विषय **लोकल** और **इफ़ेक्टिव** प्रॉपर्टीज़ के बीच अंतर को समझाता है। लोकल मान वे मान हैं जो सीधे किसी विशिष्ट फॉर्मेटिंग स्तर पर सेट किए जाते हैं, जैसे कि:

1. स्लाइड पर पोर्शन प्रॉपर्टीज़।
2. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप शेप टेक्स्ट स्टाइल्स, जब पोर्शन के टेक्स्ट फ्रेम शेप में एक हो।
3. प्रेजेंटेशन में ग्लोबल टेक्स्ट सेटिंग्स।

लोकल मान किसी भी स्तर पर परिभाषित या छोड़े जा सकते हैं। जब Aspose.Slides को अंतिम “जैसे रेंडर्ड” फॉर्मेटिंग चाहिए होती है, तो वह इनहेरिटेंस चेन को हल करता है और **इफ़ेक्टिव** मान लौटाता है। आप उन्हें स्थानीय फ़ॉर्मेट ऑब्जेक्ट पर `getEffective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि इफ़ेक्टिव मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) है जिसमें टेक्स्ट फ्रेम और कम से कम एक पोर्शन है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
इफ़ेक्टिव फॉर्मेटिंग डेटा वह वर्तमान गणना किया हुआ फॉर्मेटिंग दर्शाता है जो इनहेरिटेंस लागू होने के बाद होता है। वर्तमान इम्प्लिमेंटेशन में, कुछ इफ़ेक्टिव डेटा ऑब्जेक्ट्स जो मेथड्स जैसे कि [PortionFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/geteffective/) द्वारा लौटाए जाते हैं, आंतरिक रूप से कैश किए जा सकते हैं। पैरेंट या इनहेरिटेड फॉर्मेटिंग को बदलने के बाद `getEffective` को फिर से कॉल करने से कैश किया गया डेटा रीफ़्रेश हो सकता है, और पहले प्राप्त ऑब्जेक्ट अब पिछले स्थिति को दर्शा नहीं सकता। यदि आपको इफ़ेक्टिव मानों को बाद में पुनः उपयोग के लिए संरक्षित रखना है, तो आवश्यक प्रॉपर्टीज़ जैसे फ़ॉन्ट हाईट, फ़िल कलर, फ़ॉन्ट स्टाइल, या अलाइनमेंट को अपने स्वयं के डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरा की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको कैमरे की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करने की अनुमति देता है। [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/) द्वारा लौटाया गया इफ़ेक्टिव डेटा एक [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) के लिए अंतिम कैमरा प्रॉपर्टीज़ शामिल करता है।

निम्न कोड नमूना दिखाता है कि कैमरे के लिए इफ़ेक्टिव प्रॉपर्टीज़ कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप 3D फॉर्मेटिंग रखता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **लाइट रिग की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको लाइट रिग की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करने की अनुमति देता है। [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/) द्वारा लौटाया गया इफ़ेक्टिव डेटा एक [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) के लिए अंतिम लाइट रिग प्रॉपर्टीज़ शामिल करता है।

निम्न कोड नमूना दिखाता है कि लाइट रिग के लिए इफ़ेक्टिव प्रॉपर्टीज़ कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप 3D फॉर्मेटिंग रखता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **बेवल शेप की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको शेप बेवल की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करने की अनुमति देता है। [ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/) द्वारा लौटाया गया इफ़ेक्टिव डेटा एक [ThreeDFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/) के लिए अंतिम फेस-रिलीफ़ प्रॉपर्टीज़ शामिल करता है।

निम्न कोड नमूना दिखाता है कि शेप के टॉप बेवल के लिए इफ़ेक्टिव प्रॉपर्टीज़ कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप 3D फॉर्मेटिंग रखता है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **टेक्स्ट फ्रेम की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त कर सकते हैं। [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/geteffective/) द्वारा लौटाया गया इफ़ेक्टिव डेटा टेक्स्ट फ्रेम फॉर्मेटिंग प्रॉपर्टीज़ शामिल करता है।

निम्न कोड नमूना दिखाता है कि इफ़ेक्टिव टेक्स्ट फ्रेम फॉर्मेटिंग प्रॉपर्टीज़ कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) है जिसमें टेक्स्ट फ्रेम है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **टेक्स्ट स्टाइल की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट स्टाइल की इफ़ेक्टिव प्रॉपर्टीज़ प्राप्त कर सकते हैं। [TextStyle.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textstyle/geteffective/) द्वारा लौटाया गया इफ़ेक्टिव डेटा टेक्स्ट स्टाइल प्रॉपर्टीज़ शामिल करता है।

निम्न कोड नमूना दिखाता है कि इफ़ेक्टिव टेक्स्ट स्टाइल प्रॉपर्टीज़ कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप एक [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) है जिसमें टेक्स्ट फ्रेम है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **इफ़ेक्टिव फ़ॉन्ट हाईट वैल्यू प्राप्त करें**

Aspose.Slides का उपयोग करके आप इफ़ेक्टिव फ़ॉन्ट हाईट प्राप्त कर सकते हैं। निम्न कोड दर्शाता है कि विभिन्न प्रेजेंटेशन संरचना स्तरों पर लोकल फ़ॉन्ट हाईट मान सेट करने के बाद पोर्शन की इफ़ेक्टिव फ़ॉन्ट हाईट कैसे बदलती है।

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टेबल के लिए इफ़ेक्टिव फ़िल फ़ॉर्मेट प्राप्त करें**

Aspose.Slides का उपयोग करके आप विभिन्न टेबल भागों के लिए इफ़ेक्टिव फ़िल फॉर्मेटिंग प्राप्त कर सकते हैं। फ़ॉर्मेट ऑब्जेक्ट्स द्वारा लौटाया गया इफ़ेक्टिव डेटा [FillFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/) प्रॉपर्टीज़ शामिल करता है। सेल फॉर्मेटिंग की प्राथमिकता रो फॉर्मेटिंग से अधिक है, रो फॉर्मेटिंग की प्राथमिकता कॉलम फॉर्मेटिंग से अधिक है, और कॉलम फॉर्मेटिंग की प्राथमिकता संपूर्ण‑टेबल फॉर्मेटिंग से अधिक है।

परिणामस्वरूप, इफ़ेक्टिव [CellFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellformat/) प्रॉपर्टीज़ टेबल सेल को ड्रॉ करने के लिए उपयोग की जाती हैं। निम्न कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए इफ़ेक्टिव फ़िल फॉर्मेटिंग कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शेप एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) है।

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `getEffective` एक स्नैपशॉट लौटाता है?**

हमी नहीं। इफ़ेक्टिव डेटा वह गणना किया गया फॉर्मेटिंग दर्शाता है जो इनहेरिटेंस लागू होने के बाद होता है, लेकिन कुछ इफ़ेक्टिव डेटा ऑब्जेक्ट्स आंतरिक रूप से कैश किए जा सकते हैं। अगली `getEffective` कॉल फॉर्मेटिंग को पुनर्गणना कर सकती है और कैश्ड डेटा को रीफ़्रेश कर सकती है, इसलिए पहले प्राप्त ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

**इफ़ेक्टिव प्रॉपर्टीज़ को फिर से कब पढ़ना चाहिए?**

लोकल फॉर्मेटिंग, पैरेंट स्टाइल्स, लेआउट फॉर्मेटिंग, मास्टर फॉर्मेटिंग या प्रेजेंटेशन‑लेवल डिफॉल्ट्स को बदलने के बाद `getEffective` को फिर से कॉल करें। अगली कॉल फॉर्मेटिंग पदानुक्रम को पुनः मूल्यांकन करेगी और वर्तमान इफ़ेक्टिव परिणाम लौटाएगी।

**क्या लेआउट/मास्टर स्लाइड को बदलने या हटाने से पहले प्राप्त इफ़ेक्टिव प्रॉपर्टीज़ प्रभावित होती हैं?**

हां, लेकिन यह परिवर्तन अगले `getEffective` कॉल पर प्रतिबिंबित होगा। यदि पैरेंट फॉर्मेटिंग सोर्स बदल या हटाया जाता है, तो पहले प्राप्त इफ़ेक्टिव डेटा पुराना रह सकता है। एक बार फिर `getEffective` कॉल करने पर Aspose.Slides फॉर्मेटिंग ट्री को पुनः मूल्यांकन करेगा और फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

**क्या मैं इफ़ेक्टिव डेटा ऑब्जेक्ट्स के माध्यम से मानों को संशोधित कर सकता हूँ?**

नहीं। इफ़ेक्टिव डेटा ऑब्जेक्ट्स केवल गणना किए गए मान प्रदान करते हैं। स्थानीय फॉर्मेटिंग ऑब्जेक्ट्स में बदलाव करें, फिर इफ़ेक्टिव मानों को फिर से प्राप्त करें।

**यदि कोई प्रॉपर्टी शेप स्तर पर, न ही लेआउट/मास्टर में, न ही ग्लोबल सेटिंग्स में सेट नहीं है तो क्या होता है?**

इफ़ेक्टिव मान डिफ़ॉल्ट मैकेनिज़्म द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल हैं। वह निर्धारित मान वर्तमान इफ़ेक्टिव डेटा का हिस्सा बन जाता है।

**इफ़ेक्टिव फ़ॉन्ट मान से क्या मैं पता लगा सकता हूँ कि कौन से स्तर ने आकार या टाइपफ़ेस दिया?**

सीधे नहीं। इफ़ेक्टिव डेटा अंतिम मान लौटाता है। स्रोत जानने के लिए पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम, लेआउट, मास्टर और प्रेजेंटेशन स्तरों पर स्थानीय मानों की जाँच करें ताकि पहला स्पष्ट परिभाषित मान कहाँ है पता चल सके।

**क्यों कभी‑कभी इफ़ेक्टिव मान लोकल मानों जैसा दिखते हैं?**

क्योंकि लोकल मान अंततः अंतिम बन गया (उच्च‑स्तर की इनहेरिटेंस की आवश्यकता नहीं रही)। ऐसे मामलों में इफ़ेक्टिव मान लोकल मान के समान होता है।

**इफ़ेक्टिव प्रॉपर्टीज़ कब उपयोग करनी चाहिए, और कब केवल लोकल प्रॉपर्टीज़ पर काम करना चाहिए?**

इफ़ेक्टिव डेटा का उपयोग तब करें जब आपको सभी इनहेरिटेंस लागू होने के बाद “जैसे रेंडर्ड” परिणाम चाहिए, जैसे रंग, इंडेंट या आकार संरेखण के लिए। यदि आपको ये मान बाद के फॉर्मेटिंग परिवर्तन के बावजूद सुरक्षित रखना है, तो आवश्यक प्रॉपर्टीज़ को अपने स्वयं के ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशिष्ट स्तर पर फॉर्मेटिंग बदलनी है, तो स्थानीय प्रॉपर्टीज़ संशोधित करें और फिर, यदि आवश्यक हो, इफ़ेक्टिव डेटा को फिर से पढ़ें ताकि परिणाम की पुष्टि हो सके।