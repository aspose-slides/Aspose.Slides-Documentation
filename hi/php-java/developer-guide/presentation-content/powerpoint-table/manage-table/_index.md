---
title: PHP में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/php-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका पहुँचें
- अनुपात
- टेक्स्ट संरेखित करें
- टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल कोड उदाहरण देखें।"
---
## **परिचय**

PowerPoint में तालिकाएँ जानकारी को पंक्तियों और स्तंभों में व्यवस्थित करती हैं, जिससे मान पढ़ना और तुलना करना आसान हो जाता है।

Aspose.Slides [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) क्लास, [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) क्लास, और अन्य प्रकार प्रदान करता है जिससे आप प्रस्तुतियों में तालिकाएँ बनाना, अपडेट करना और प्रबंधित करना सकते हैं।

## **शुरू से एक तालिका बनाएं**

स्थिति, स्तंभ चौड़ाइयों और पंक्ति ऊँचाइयों को निर्दिष्ट करके एक तालिका बनाएं। स्लाइड में जोड़ने के बाद, आप सेल सीमा रेखाओं को फॉर्मेट कर सकते हैं, कोशिकाओं को मिलान कर सकते हैं, और टेक्स्ट सम्मिलित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. पॉइंट्स में स्तंभ चौड़ाइयों की एक एरे परिभाषित करें।
4. पॉइंट्स में पंक्ति ऊँचाइयों की एक एरे परिभाषित करें।
5. स्लाइड में [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ऑब्जेक्ट को [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) मेथड के माध्यम से जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) पर इटररेट करके शीर्ष, नीचे, दाएँ और बाएँ सीमा रेखाओं पर फ़ॉर्मेट लागू करें।
7. तालिका की पहली पंक्ति की पहली दो कोशिकाओं को मिलाएं।
8. संयुक्त सेल को उसके [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) मेथड से एक्सेस करें।
9. संयुक्त सेल में टेक्स्ट सेट करें।
10. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण 100, 50 पॉइंट्स पर तीन स्तंभ और पाँच पंक्तियों वाली तालिका बनाता है। यह 5 पॉइंट्स की चौड़ाई वाले लाल सीमाएँ लागू करता है, पहली पंक्ति की पहली दो कोशिकाओं को मिलाता है, और परिणाम को `table.pptx` के रूप में सहेजता है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 0), false);
    $table->get_Item(0, 0)->getTextFrame()->setText("Merged Cells");

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में, सेल सूचकांक शून्य-आधारित होते हैं और क्रम (स्तंभ, पंक्ति) का उपयोग करते हैं। पहली सेल का सूचकांक (0, 0) होता है।

उदाहरण के लिए, 4 स्तंभों और 4 पंक्तियों वाली तालिका में कोशिकाओं को इस प्रकार क्रमांकित किया जाता है:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह उदाहरण ऊपर दर्शाई गई 4 × 4 तालिका बनाता है, जिसमें स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ 70 पॉइंट्स हैं और लाल सेल सीमाएँ 5 पॉइंट्स की चौड़ाई वाली हैं। निर्देशांक सेल सूचकांक दर्शाते हैं; उदाहरण सेल को खाली छोड़ता है और तालिका को `StandardTables_out.pptx` के रूप में सहेजता है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $red = java("java.awt.Color")->RED;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        $row = $table->getRows()->get_Item($rowIndex);
        for ($columnIndex = 0; $columnIndex < java_values($row->size()); $columnIndex++) {
            $cell = $row->get_Item($columnIndex);
            $cellFormat = $cell->getCellFormat();
            $cellFormat->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderTop()->setWidth(5);

            $cellFormat->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderBottom()->setWidth(5);

            $cellFormat->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderLeft()->setWidth(5);

            $cellFormat->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
            $cellFormat->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor($red);
            $cellFormat->getBorderRight()->setWidth(5);
        }
    }

    $presentation->save("StandardTables_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एक मौजूदा तालिका तक पहुँचें**

तालिकाएँ स्लाइड के शेप संग्रह में संग्रहित होती हैं। शेप्स में इटररेट करके तालिका खोजें, फिर [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) क्लास का उपयोग करके उसकी कोशिकाओं को पढ़ें या अपडेट करें।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा उस स्लाइड का रेफ़रेंस प्राप्त करें जिसमें तालिका स्थित है।
3. [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटररेट करें और तालिका मिलने पर रुकें। यदि स्लाइड में कई तालिकाएँ हैं, तो आवश्यक तालिका पहचानने के लिए [getAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getalternativetext/) का उपयोग करें।
4. लक्षित सेल में टेक्स्ट अपडेट करें।
5. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `UpdateExistingTable.pptx` खोलता है और पहले स्लाइड पर पहली तालिका खोजता है। यह स्तंभ 0, पंक्ति 1 की सेल को `New` सेट करता है और परिणाम को `table1_out.pptx` के रूप में सहेजता है। इनपुट में कम से कम एक स्लाइड होना चाहिए, और उस स्लाइड की पहली तालिका में कम से कम एक स्तंभ और दो पंक्तियाँ होनी चाहिए।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("UpdateExistingTable.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = null;
    $tableClass = new JavaClass("com.aspose.slides.Table");

    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            $table = $shape;
            break;
        }
    }

    if ($table !== null) {
        $table->get_Item(0, 1)->getTextFrame()->setText("New");
        $presentation->save("table1_out.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

एक मौजूदा तालिका में पंक्ति का आकार बदलने और यह समझने के लिए कि उसकी वास्तविक ऊँचाई अनुरोधित न्यूनतम से अधिक क्यों हो सकती है, देखें [Control Row Height](/slides/hi/php-java/manage-rows-and-columns/#control-row-height)।

## **पाठ फ्रेम का मालिक सेल खोजें**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से कोई [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) प्राप्त होता है, तो मालिक [Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) को प्राप्त करने के लिए [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) मेथड का उपयोग करें। तालिका-सेल टेक्स्ट फ्रेम के लिए, [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) मालिक लौटाता है और [TextFrame::getParentShape](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentShape) `null` लौटाता है, जबकि तालिका स्वयं एक शेप है।

सेल निर्देशांक रीड-ऑनली [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) और [Cell::getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) मेथड्स द्वारा उपलब्ध हैं। [TextFrame::getParentCell](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/#getParentCell) रीड-ऑनली नेविगेशन भी प्रदान करता है: यह मालिक लौटाता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा लौटाए गए सेल को `java_is_null` के साथ जांचें।

टेबल-सेल और शेप मालिकों की पहचान करने वाले पूर्ण उदाहरण के लिए, जिसमें SmartArt नोड्स से जुड़े शेप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/php-java/search-and-replace-text/)।

## **तालिका में टेक्स्ट को संरेखित करें**

आप व्यक्तिगत तालिका कोशिकाओं के लंबवत एंकरिंग और टेक्स्ट दिशा को नियंत्रित कर सकते हैं। इस अनुभाग के उदाहरण में पहली सेल के भीतर टेक्स्ट को केंद्रित किया गया है और उसे 270 डिग्री घुमाया गया है।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड में [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ऑब्जेक्ट जोड़ें।
4. तालिका से [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) ऑब्जेक्ट एक्सेस करें।
5. पहले [Paragraph](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/) को एक्सेस करें और उसका टेक्स्ट व रंग सेट करें।
6. [setTextAnchorType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextanchortype/) और [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/cell/settextverticaltype/) का उपयोग करके सेल की लंबवत एंकरिंग और टेक्स्ट दिशा सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

यह उदाहरण 120 पॉइंट्स की स्तंभ चौड़ाइयों और 100 पॉइंट्स की पंक्ति ऊँचाइयों के साथ 4 × 4 तालिका बनाता है। यह सेल (0, 0) में टेक्स्ट को फॉर्मेट करता है, पहली पंक्ति के शेष कोशिकाओं में मान जोडता है, और परिणाम को `Vertical_Align_Text_out.pptx` के रूप में सहेजता है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $black = java("java.awt.Color")->BLACK;
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 120, 120, 120, 120 ];
    $rowHeights = [ 100, 100, 100, 100 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 0)->getTextFrame()->setText("10");
    $table->get_Item(2, 0)->getTextFrame()->setText("20");
    $table->get_Item(3, 0)->getTextFrame()->setText("30");

    $textFrame = $table->get_Item(0, 0)->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);

    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

    $cell = $table->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका स्तर पर टेक्स्ट फॉर्मेटिंग सेट करें**

[setTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/table/settextformat/) का उपयोग करके तालिका की सभी कोशिकाओं पर टेक्स्ट फॉर्मेटिंग लागू करें। इसके ओवरलोड्स भाग, पैराग्राफ और टेक्स्ट फ्रेम फॉर्मेटिंग स्वीकार करते हैं, इसलिए आप इन गुणों को बिना व्यक्तिगत कोशिकाओं पर इटररेट किए सेट कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास का उपयोग करके प्रस्तुति लोड करें।
2. इंडेक्स द्वारा स्लाइड का रेफ़रेंस प्राप्त करें।
3. स्लाइड से [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) ऑब्जेक्ट एक्सेस करें।
4. टेक्स्ट के लिए [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) का उपयोग करके फ़ॉन्ट आकार सेट करें।
5. [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) और [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) का उपयोग करके पैराग्राफ संरेखण और दाएँ मार्जिन सेट करें।
6. [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) का उपयोग करके टेक्स्ट दिशा सेट करें।
7. संशोधित प्रस्तुति को सहेजें।

नीचे दिया गया उदाहरण `table.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहला शेप एक तालिका हो। यह फ़ॉन्ट आकार को 25 पॉइंट्स सेट करता है, पैराग्राफ को दाएँ संरेखित करता है जिसमें दाएँ मार्जिन 20 पॉइंट्स है, और टेक्स्ट को लंबवत बनाता है। स्वरूपित प्रस्तुति `result.pptx` के रूप में सहेजी जाती है।

```php
use aspose\slides\ParagraphFormat;
use aspose\slides\PortionFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->setTextFormat($textFrameFormat);

    $presentation->save("result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका शैली गुण प्राप्त करें**

[getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) का उपयोग करके तालिका की प्रीसेट शैली पढ़ें और [setStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/setstylepreset/) से इसे असाइन करें। यह उदाहरण एक तालिका पर [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/) लागू करता है, प्रीसेट मान प्रिंट करता है, और समान प्रीसेट को दूसरी तालिका को असाइन करता है। दोनों तालिकाएँ `table-style.pptx` में सहेजी जाती हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 100, 150 ];
    $rowHeights = [ 5, 5, 5 ];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = java_values($table->getStylePreset());
    echo "Table style preset: " . $stylePreset . PHP_EOL;

    $anotherTable = $slide->getShapes()->addTable(10, 100, $columnWidths, $rowHeights);
    $anotherTable->setStylePreset($stylePreset);

    $presentation->save("table-style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका का अनुपात लॉक करें**

तालिका का अनुपात उसकी चौड़ाई और ऊँचाई के अनुपात को कहा जाता है। तालिका के लिए इस अनुपात को लॉक करने के लिए [setAspectRatioLocked](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) का उपयोग करें।

नीचे दिया गया उदाहरण `pres.pptx` खोलता है, जिसमें कम से कम एक स्लाइड होनी चाहिए जिसमें पहला शेप एक तालिका हो। यह वर्तमान लॉक स्थिति प्रिंट करता है, अनुपात लॉक को सक्षम करता है, अपडेटेड स्थिति (`true`) प्रिंट करता है, और परिणाम को `pres-out.pptx` के रूप में सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $table->getGraphicalObjectLock()->setAspectRatioLocked(true);
    echo "Lock aspect ratio set: " . (java_values($table->getGraphicalObjectLock()->getAspectRatioLocked()) ? "true" : "false") . PHP_EOL;

    $presentation->save("pres-out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं में टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हाँ। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/table/setrighttoleft/) मेथड प्रदान करती है, और पैराग्राफ में [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setrighttoleft/) मौजूद है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं अंतिम फ़ाइल में उपयोगकर्ताओं को तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

[shape locks](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) का उपयोग करके स्थानांतरित करने, आकार बदलने, चयन आदि को अक्षम करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या सेल के अंदर एक छवि को पृष्ठभूमि के रूप में सम्मिलित करना समर्थित है?**

हाँ। आप एक सेल के लिए [picture fill](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) सेट कर सकते हैं; छवि चुने गए मोड (स्ट्रेच या टाइल) के अनुसार सेल क्षेत्र को कवर कर देगी।