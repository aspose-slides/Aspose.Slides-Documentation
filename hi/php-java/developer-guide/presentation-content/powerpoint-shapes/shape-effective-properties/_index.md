---
title: PHP में प्रस्तुतियों से शैप के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/php-java/shape-effective-properties/
keywords:
- शैप गुण
- कैमरा गुण
- लाइट रिग
- बिवेल शैप
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेज़ेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java का उपयोग करके PowerPoint प्रस्तुतियों में स्थानीय, विरासत में प्राप्त और प्रभावी शैप फ़ॉर्मेटिंग को कैसे अलग किया जाए, सीखें।"
---
## **स्थानीय, विरासत में प्राप्त, और प्रभावी गुण समझें**

PowerPoint फ़ॉर्मेटिंग कई स्थानों से आ सकती है। ऑब्जेक्ट पर सीधे संग्रहीत मान उसका **स्थानीय मान** है। यदि वह मान निर्धारित नहीं है, तो PowerPoint पैरेंट फ़ॉर्मेटिंग स्रोतों को देखता है, जैसे कि पैराग्राफ डिफ़ॉल्ट, टेक्स्ट स्टाइल, लेआउट या मास्टर स्लाइड, थीम, या प्रस्तुति‑स्तर के डिफ़ॉल्ट। इन मानों को **विरासत मान** कहा जाता है। पूरी पदानुक्रम हल होने के बाद जो मान बचता है, वह **प्रभावी मान** है—वह मान जिसका उपयोग ऑब्जेक्ट को रेंडर करने के लिए किया जाता है।

उदाहरण के लिए, एक टेक्स्ट भाग अपना फ़ॉन्ट ऊँचाई परिभाषित नहीं कर सकता। इसका स्थानीय [getFontHeight](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/) मान तब `NAN` होता है, जिसका अर्थ है "यहाँ सेट नहीं है"। यह भाग अपने पैराग्राफ, प्रस्तुति के डिफ़ॉल्ट टेक्स्ट स्टाइल, या अन्य लागू स्रोत से ऊँचाई विरासत में ले सकता है। भाग फ़ॉर्मेट पर [getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/geteffective/) को कॉल करने से अंतिम निर्धारित ऊँचाई प्राप्त होती है।

भिन्न उद्देश्यों के लिए दो प्रकार के फ़ॉर्मेटिंग डेटा का प्रयोग करें:

- स्थानीय फ़ॉर्मेट ऑब्जेक्ट को पढ़ें या बदलें, जैसे कि [PortionFormat](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/), जब आपको यह नियंत्रित करना हो कि मान कहाँ परिभाषित है।
- प्रभावी डेटा ऑब्जेक्ट को पढ़ें, जैसे कि [data returned by PortionFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/geteffective/), जब आपको अंतिम, रेंडर किया गया परिणाम चाहिए। प्रभावी डेटा केवल‑पढ़ने योग्य है।

उदाहरण चलाने से पहले, [Aspose.Slides for PHP via Java स्थापित करें](/slides/hi/php-java/installation/)।

## **स्थानीय, विरासत में प्राप्त, और प्रभावी मानों की तुलना करें**

निम्नलिखित पूर्ण उदाहरण एक शेप बनाता है और प्रस्तुति, पैराग्राफ, तथा भाग स्तरों पर फ़ॉन्ट ऊँचाई लागू करता है। प्रत्येक चरण उन स्तरों पर परिभाषित मानों को तथा समान टेक्स्ट भाग के परिणामस्वरूप प्रभावी मान को प्रिंट करता है। यह यह भी दर्शाता है कि फ़ॉर्मेटिंग परिवर्तन के बाद प्रभावी डेटा को फिर से पढ़ना क्यों आवश्यक है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // पिछले परिवर्तनों के बाद प्रभावी डेटा पढ़ें।
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // दो विभिन्न स्तरों पर विरासत मान निर्धारित करें।
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // भाग पर स्थानीय मान दोनों विरासत मानों को अधिलिखित करता है।
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // विरासत मान में परिवर्तन मौजूदा स्थानीय मान को अधिलिखित नहीं करता।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // स्थानीय मान को साफ़ करें। अब भाग फिर से पैराग्राफ से विरासत में लेता है।
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // पैराग्राफ मान को साफ़ करें। अब प्रस्तुति का डिफ़ॉल्ट परिणाम प्रदान करता है।
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

इस उदाहरण में प्राथमिकता भाग का स्थानीय फ़ॉर्मेट, फिर पैराग्राफ फ़ॉर्मेट, फिर प्रस्तुति डिफ़ॉल्ट है। अन्य ऑब्जेक्ट्स की विरासत श्रृंखलाएँ अलग हो सकती हैं, लेकिन सिद्धांत समान है: अधिक विशिष्ट स्पष्ट मान जीतता है, और [getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/geteffective/) अंतिम परिणाम लौटाता है।

## **प्रभावी टेक्स्ट गुण प्राप्त करें**

टेक्स्ट फ़ॉर्मेटिंग कई ऑब्जेक्ट्स में विभाजित होती है:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/geteffective/) मार्जिन, एंकरिंग, ऑटोफ़िट, और वर्टिकल टेक्स्ट दिशा जैसे टेक्स्ट‑फ़्रेम गुणों को हल करता है।
- [TextStyle.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textstyle/geteffective/) प्रत्येक टेक्स्ट स्टाइल स्तर के लिए पैराग्राफ फ़ॉर्मेटिंग को हल करता है।
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/geteffective/) पैराग्राफ गुणों जैसे संरेखण, इंडेंटेशन, और बुलेट्स को हल करता है।
- [PortionFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portionformat/geteffective/) अक्षर गुणों जैसे फ़ॉन्ट ऊँचाई, टाइपफ़ेस, रंग, बोल्ड, और इटैलिक को हल करता है।

अगले उदाहरण के लिए, `text-formatting.pptx` में कम से कम एक स्लाइड और एक गैर‑खाली टेक्स्ट फ़्रेम वाला [AutoShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/autoshape/) होना चाहिए। AutoShape किसी भी स्थिति पर शेप कलेक्शन में हो सकता है; कोड उपयुक्त ऑब्जेक्ट को खोजता है और उपयोग से पहले उसकी वैधता जाँचता है।

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **प्रभावी 3D गुण प्राप्त करें**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/) एक प्रभावी डेटा ऑब्जेक्ट लौटाता है जो सभी हल किए गए 3D सेटिंग्स को समूहित करता है। इसके [getCamera](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/), और [getBevelBottom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/threedformat/geteffective/) मेथड्स संबंधित प्रभावी डेटा को उजागर करते हैं। इन संबंधित सेटिंग्स को साथ में पढ़ने से शेप की अंतिम 3D उपस्थिति को समझना आसान हो जाता है।

इस उदाहरण के लिए, `shape-3d.pptx` में पहली स्लाइड पर कम से कम एक शेप होना चाहिए। यदि आप आउटपुट में डिफ़ॉल्ट से अलग मान चाहते हैं, तो उस शेप पर 3D कैमरा, लाइटिंग, या बेवेल सेटिंग्स लागू करें।

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **प्रभावी टेबल फ़ॉर्मेटिंग प्राप्त करें**

टेबल फ़ॉर्मेटिंग टेबल स्टाइल और पूरी टेबल, कॉलम, रो, या व्यक्तिगत सेल पर लागू फ़ॉर्मेट्स दोनों से आ सकती है। स्पष्ट रूप से परिभाषित फ़िल्स में टकराव होने पर प्राथमिकता क्रम सेल, रो, कॉलम, और फिर पूरी टेबल का होता है। सेल का प्रभावी फ़ॉर्मेट वह अंतिम फ़ॉर्मेट है जिसका उपयोग सेल को ड्रॉ करने के लिए किया जाता है।

इस उदाहरण के लिए, `table-formatting.pptx` में पहली स्लाइड पर कम से कम एक टेबल होनी चाहिए। टेबल में कम से कम एक रो और एक कॉलम होना आवश्यक है। कोड यह मानने की बजाय कि `getShapes()->get_Item(0)` टेबल है, एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) को खोजता है।

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

यदि आपको केवल फ़िल टाइप नहीं बल्कि रंग चाहिए, तो पहले प्रभावी [getFillType](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/geteffective/) मान जाँचें, और फिर उस प्रकार के अनुरूप मेथड पढ़ें—उदाहरण के लिए सॉलिड फ़िल के लिए [getSolidFillColor](https://reference.aspose.com/slides/hi/php-java/aspose.slides/fillformat/geteffective/)।

## **परिवर्तनों के बाद प्रभावी डेटा को फिर से पढ़ें**

प्रभावी डेटा उस समय की फ़ॉर्मेटिंग पदानुक्रम को वर्णित करता है जब इसे हल किया जाता है। पदानुक्रम में भाग ले सकने वाली किसी भी चीज़ को बदलने के बाद `getEffective` को फिर से कॉल करें, जिसमें शामिल हैं:

- ऑब्जेक्ट का स्थानीय फ़ॉर्मेट;
- पैराग्राफ या टेक्स्ट‑फ़्रेम के डिफ़ॉल्ट;
- एक टेबल स्टाइल, टेबल, कॉलम, रो, या सेल फ़ॉर्मेट;
- लेआउट या मास्टर स्लाइड फ़ॉर्मेटिंग;
- थीम डेटा या प्रस्तुति‑स्तर के डिफ़ॉल्ट;
- स्लाइड को सौंपा गया लेआउट या मास्टर।

एक प्रभावी डेटा ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में न रखें। Aspose.Slides कुछ प्रभावी डेटा को आंतरिक रूप से कैश कर सकता है, और बाद में `getEffective` कॉल उस डेटा को ताज़ा कर सकता है। यदि आपको परिवर्तन से पहले और बाद के मानों की तुलना करनी है, तो परिवर्तन करने से पहले आवश्यक स्केलर मानों—जैसे फ़ॉन्ट ऊँचाई, रंग, संरेखण, या बेवेल चौड़ाई—को अपनी स्वयं की वेरिएबल्स में कॉपी कर लें।

एक मान बदलने के लिए, उपयुक्त स्थानीय फ़ॉर्मेट ऑब्जेक्ट को अपडेट करें और फिर `getEffective` को कॉल करके परिणाम की पुष्टि करें। प्रभावी डेटा ऑब्जेक्ट स्वयं केवल‑पढ़ने योग्य हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कैसे पता करूँ कि कौन से स्तर ने प्रभावी मान प्रदान किया?**  
प्रभावी डेटा केवल अंतिम मान रखता है, स्रोत नहीं। सबसे विशिष्ट स्तर से बाहर की ओर लागू स्थानीय ऑब्जेक्ट्स का निरीक्षण करें। टेक्स्ट के लिए इसमें भाग, पैराग्राफ, टेक्स्ट फ़्रेम, लेआउट, मास्टर, थीम, और प्रस्तुति डिफ़ॉल्ट शामिल हो सकते हैं। `NAN` या `null` जैसे अपरिभाषित मान संकेत देते हैं कि खोज अगले स्तर तक जारी है।

**जब कोई स्तर गुण को परिभाषित नहीं करता तो क्या होता है?**  
Aspose.Slides उपयुक्त PowerPoint या लाइब्रेरी डिफ़ॉल्ट को हल करता है। वह हल किया गया मान प्रभावी डेटा में दिखाई देता है, भले ही कोई स्थानीय ऑब्जेक्ट इसे स्पष्ट रूप से न परिभाषित करे।

**कभी‑कभी प्रभावी मान स्थानीय मान के बराबर क्यों होता है?**  
स्थानीय मान विरासत गणना में जीत जाता है। यह तब अपेक्षित है जब गुण स्पष्ट रूप से ऑब्जेक्ट पर सेट किया गया हो और कोई अधिक विशिष्ट नियम उसे प्रतिस्थापित न करे।

**कब स्थानीय डेटा का उपयोग करना चाहिए, प्रभावी डेटा के बजाय?**  
स्थानीय डेटा का उपयोग विशिष्ट फ़ॉर्मेटिंग स्तर को जांचने या संपादित करने के लिए करें। प्रभावी डेटा का उपयोग तब करें जब आपको विरासत, थीम नियम, और लागू स्टाइल्स के बाद अंतिम उपस्थिति चाहिए। दोनों को एक ही वर्कफ़्लो में प्रदर्शित करने के लिए [पूरा तुलना उदाहरण](#compare-local-inherited-and-effective-values) देखें।