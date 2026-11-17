---
title: PHP का उपयोग करके प्रस्तुतियों में टेबल सेल्स प्रबंधित करें
linktitle: सेल्स प्रबंधित करें
type: docs
weight: 30
url: /hi/php-java/manage-cells/
keywords:
- टेबल सेल
- सेल्स को मर्ज करें
- बॉर्डर हटाएँ
- सेल को विभाजित करें
- सेल में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में PowerPoint टेबल सेल्स प्रबंधित करें: मर्ज्ड सेल्स की पहचान करें, बॉर्डर हटाएँ, सेल्स को विभाजित करें, और Aspose.Slides for PHP via Java के साथ पृष्ठभूमि रंग और छवियों को सेट करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में टेबल सेल्स तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख बताता है कि मर्ज किए गए टेबल सेल्स की पहचान कैसे करें, सेल बॉर्डर्स को कैसे हटाएँ, मर्ज या स्प्लिट करने के बाद सेल नंबरिंग के साथ कैसे काम करें, सेल की पृष्ठभूमि रंग कैसे बदलें, और टेबल सेल के अंदर एक छवि कैसे जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से टेबल प्राप्त करें, सेल प्रॉपर्टीज़ के माध्यम से सेल फ़ॉर्मेटिंग अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित इंडेक्स का उपयोग करता है ताकि टेबल सेल्स को क्रम `(column, row)` में एक्सेस किया जा सके।

## **मर्ज किए गए टेबल सेल की पहचान**

उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहले स्लाइड पर पहला शेप को टेबल के रूप में एक्सेस करता है। यह मानता है कि स्लाइड और शेप मौजूद हैं और शेप एक टेबल है। फिर यह सभी पंक्तियों और स्तंभों पर इटरेट करता है और [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) का उपयोग करके मर्ज्ड क्षेत्रों में सेल्स की पहचान करता है। प्रत्येक मिलान के लिए यह `row;column` क्रम में सेल कॉर्डिनेट्स, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), तथा क्षेत्र की प्रारम्भिक कॉर्डिनेट्स, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) और [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) को प्रिंट करता है।

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation_with_table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $rowCount = java_values($table->getRows()->size());
    for ($rowIndex = 0; $rowIndex < $rowCount; $rowIndex++)
    {
        $columnCount = java_values($table->getColumns()->size());
        for ($columnIndex = 0; $columnIndex < $columnCount; $columnIndex++)
        {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            if (java_values($cell->isMergedCell()))
            {
                printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.\n", $rowIndex, $columnIndex, java_values($cell->getRowSpan()), java_values($cell->getColSpan()), java_values($cell->getFirstRowIndex()), java_values($cell->getFirstColumnIndex()));
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **टेबल सेल बॉर्डर्स हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाइए और उसकी पहली स्लाइड पर [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) का उपयोग करके एक टेबल जोड़िए। कॉलम चौड़ाई, पंक्ति ऊँचाई, और टेबल स्थिती पॉइंट्स में निर्दिष्ट हैं। उदाहरण सभी चार सेल बॉर्डर्स को [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) सेट करता है, जिससे वे अदृश्य हो जाते हैं।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 50, 50, 50, 50 ];
    $rowHeights = [ 50, 30, 30, 30, 30 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    for ($rowIndex = 0; $rowIndex < java_values($table->getRows()->size()); $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < java_values($table->getColumns()->size()); $columnIndex++) {
            $cell = $table->get_Item($columnIndex, $rowIndex);
            $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
            $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
        }
    }

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **विकर्ण सेल बॉर्डर्स जोड़ें**

[ getBorderDiagonalDown](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonaldown/) का उपयोग करके शीर्ष-बाएँ कोने से नीचे-दाएँ कोने तक एक रेखा खींचें, और [getBorderDiagonalUp](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderdiagonalup/) का उपयोग करके नीचे-बाएँ कोने से ऊपर-दाएँ कोने तक एक रेखा खींचें। एक विकर्ण को कोना हेडर के रूप में चिह्नित किया जा सकता है; दोनों विकर्ण मिलकर एक X बना सकते हैं जिससे सेल को लागू नहीं माना जाता।

प्रत्येक विकर्ण का अपना [LineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) होता है। इसके [getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/getfillformat/) में, [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) का उपयोग करके [FillType::Solid](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) चुनें और [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) के माध्यम से रंग चुनें। [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setwidth/) से लाइन की चौड़ाई पॉइंट्स में सेट करें।

उदाहरण एक पंक्ति में तीन सेल बनाता है: लाल नीचे की ओर विकर्ण, नीला ऊपर की ओर विकर्ण, और दोनों विकर्ण। यह शीर्ष, नीचे, बायाँ और दायाँ सेल बॉर्डर अपरिवर्तित रखता है।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 210, 210, 210 ];
    $rowHeights = [ 160 ];
    $table = $slide->getShapes()->addTable(45, 130, $columnWidths, $rowHeights);

    $downwardBorder = $table->get_Item(0, 0)->getCellFormat()->getBorderDiagonalDown();
    $downwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $downwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $downwardBorder->setWidth(3);

    $upwardBorder = $table->get_Item(1, 0)->getCellFormat()->getBorderDiagonalUp();
    $upwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $upwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $upwardBorder->setWidth(5);

    $crossDownwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalDown();
    $crossDownwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossDownwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $crossDownwardBorder->setWidth(3);

    $crossUpwardBorder = $table->get_Item(2, 0)->getCellFormat()->getBorderDiagonalUp();
    $crossUpwardBorder->getFillFormat()->setFillType(FillType::Solid);
    $crossUpwardBorder->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $crossUpwardBorder->setWidth(5);

    $presentation->save("diagonal_cell_borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

एक विकर्ण केवल सेल फ़ॉर्मेटिंग को बदलता है। प्रत्येक सेल में एक ही टेक्स्ट फ्रेम रहता है, जिसे आप [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/gettextframe/) से एक्सेस कर सकते हैं। विकर्ण के दोनों पक्षों के क्षेत्रों को स्वतंत्र रूप से संपादित नहीं किया जा सकता।

सहेजी गई टेबल, Microsoft PowerPoint में रेंडर की गई:

![तीन टेबल सेल्स जिनमें शीर्ष-बाएँ से नीचे-दाएँ तक लाल विकर्ण, नीचे-बाएँ से ऊपर-दाएँ तक नीला विकर्ण, और दोनों विकर्ण मिलकर X बनाते हैं।](diagonal-cell-borders.png)

*बाएँ से दाएँ: नीचे की ओर विकर्ण (लाल, 3 pt), ऊपर की ओर विकर्ण (नीला, 5 pt), और दोनों विकर्ण।*

## **टेबल सेल्स को मर्ज करें**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) का उपयोग करके टेबल सेल्स की आयताकार रेंज को एक सेल में संयोजित करें। रेंज के शीर्ष-बाएँ और नीचे-दाएँ कोने के सेल निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि मर्ज में निर्दिष्ट रेंज के बाहर के सेल्स शामिल हो सकते हैं या नहीं; `false` मर्ज को उसी रेंज तक सीमित रखता है।

उदाहरण 70‑पॉइंट कॉलम और पंक्तियों के साथ 4‑बाय‑4 टेबल बनाता है, फिर `(1, 1)` से `(2, 2)` तक के चार केंद्रीय सेल्स को मर्ज करता है। परिणामी सेल दो कॉलम और दो पंक्तियों तक फैला होता है, जबकि टेबल की मूल ग्रिड अभी भी चार कॉलम और चार पंक्तियों को रखती है। मर्ज्ड सेल की सामग्री या फ़ॉर्मेटिंग तक पहुँचने के लिए, इस उदाहरण में `$table->get_Item(1, 1)` का उपयोग करें। मर्ज्ड रेंज के बाहर की स्थितियों टेबल ग्रिड का हिस्सा बनी रहती हैं, इसलिए रेंज के बाहर के सेल्स के इंडेक्स नहीं बदलते।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->mergeCells($table->get_Item(1, 1), $table->get_Item(2, 2), false);

    $presentation->save("merged_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टेबल सेल्स को स्प्लिट करें**

पिछले उदाहरण में सेल्स को मर्ज करने से टेबल की ग्रिड बनी रहती है। एक सेल को स्प्लिट करने से नया ग्रिड कॉलम जुड़ सकता है और दायीं ओर के सेल्स के कॉलम इंडेक्स बदल सकते हैं। Aspose.Slides PowerPoint के टेबल ग्रिड मॉडल का पालन करता है।

यह उदाहरण 70‑पॉइंट कॉलम और पंक्तियों के साथ 4‑बाय‑4 टेबल बनाता है और सेल `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) को कॉल करता है। सेल की 70‑पॉइंट चौड़ाई का आधा दो बराबर‑चौड़ाई वाले सेल्स बनाने के लिए पास किया जाता है।

स्प्लिट के बाद, दो आधे हिस्से `$table->get_Item(1, 1)` और `$table->get_Item(2, 1)` के रूप में एक्सेस किए जाते हैं। टेबल ग्रिड अब पाँच कॉलम रखता है: मूल रूप से कॉलम 2 और 3 में थे वे क्रमशः कॉलम 3 और 4 में चले जाते हैं। पंक्ति इंडेक्स अपरिवर्तित रहते हैं। स्प्लिट के बाद सेल्स को एक्सेस करते समय इन अपडेटेड कॉलम इंडेक्सेज़ का प्रयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 70, 70, 70, 70 ];
    $rowHeights = [ 70, 70, 70, 70 ];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(1, 1)->splitByWidth(java_values($table->get_Item(1, 1)->getWidth()) / 2);

    $presentation->save("split_cells.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![एक अनमर्ज्ड 70‑पॉइंट सेल दो 35‑पॉइंट सेल्स में विभाजित होता है, पाँचवाँ ग्रिड कॉलम जोड़ता है और दायीं ओर के इंडेक्स को शिफ्ट करता है।](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*चौड़ाई विभाजन सेल (1, 1) को प्रभावित करता है, शून्य‑आधारित (column, row) इंडेक्स का उपयोग करते हुए। अन्य पंक्तियों में सेल दोनों नए कॉलम पोजीशन को कवर करता रहता है।*
<!-- visual-explanation:manage-cells:end -->

### **पंक्ति या कॉलम स्पैन द्वारा मर्ज्ड सेल्स को स्प्लिट करें**

डेटा पॉप्युलेशन के लिए मर्ज्ड टेम्पलेट सेल्स को तैयार करने हेतु, मौजूदा पंक्ति सीमा के साथ स्प्लिट करने के लिए [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) का उपयोग करें, या कॉलम सीमा के साथ स्प्लिट करने के लिए [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) का उपयोग करें।

`index` आर्ग्यूमेंट स्प्लिट के ऊपरी भाग में पंक्तियों या बाएँ भाग में कॉलम को गिनता है; यह मर्ज्ड रेज़ियन के सापेक्ष होता है:

- पंक्ति स्प्लिट: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/)।
- कॉलम स्प्लिट: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/)।

उदाहरण मानता है कि पहली स्लाइड पर पहला शेप टेबल है, जिसमें `(1, 2)` और `(1, 3)` वर्टिकली मर्ज्ड हैं। नीचे की स्थिति से शुरुआत करके, यह [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) और [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) का उपयोग करके मूल बिंदु ढूँढ़ता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` फिर पंक्तियों 2 और 3 को उत्पाद नामों के लिए अलग करता है। एक क्षैतिज दो‑कॉलम मर्ज के लिए, इसके बजाए `splitByColSpan(1)` प्रयोग करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table_template.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);

    $selectedCell = $table->get_Item(1, 3);
    $firstColumnIndex = java_values($selectedCell->getFirstColumnIndex());
    $firstRowIndex = java_values($selectedCell->getFirstRowIndex());
    $mergedCell = $table->get_Item($firstColumnIndex, $firstRowIndex);

    if (java_values($mergedCell->isMergedCell()) && java_values($mergedCell->getRowSpan()) == 2 && java_values($mergedCell->getColSpan()) == 1)
    {
        $mergedCell->splitByRowSpan(1);

        // स्प्लिट करने के बाद टेबल से प्राप्त हुए सेल्स को प्राप्त करें।
        $upperCell = $table->get_Item($firstColumnIndex, $firstRowIndex);
        $lowerCell = $table->get_Item($firstColumnIndex, $firstRowIndex + 1);
        echo "Upper cell merged: " . (java_values($upperCell->isMergedCell()) ? "true" : "false") . PHP_EOL;
        echo "Lower cell merged: " . (java_values($lowerCell->isMergedCell()) ? "true" : "false") . PHP_EOL;

        $upperCell->getTextFrame()->setText("Product A");
        $lowerCell->getTextFrame()->setText("Product B");

        $presentation->save("split_template.pptx", SaveFormat::Pptx);
    }
    else
    {
        echo "Select a merged region spanning exactly two rows and one column." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

टेबल ग्रिड और आसपास के सेल इंडेक्स अपरिवर्तित रहते हैं। परिणामस्वरूप सेल्स को उनके कॉर्डिनेट्स द्वारा प्राप्त करें; यहाँ, दोनों के स्पैन 1 हैं और [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) `false` प्रिंट करता है। एक स्प्लिट के बाद भी बड़े क्षेत्रों के कुछ हिस्से मर्ज्ड रह सकते हैं।

मूल टेक्स्ट और उसका फ़ॉर्मेटिंग ऊपर (या बाएँ) सेल में रहता है; नया सेल खाली होता है लेकिन फ़िल, बॉर्डर्स, और मार्जिन जैसी सेल फ़ॉर्मेटिंग को विरासत में लेता है। स्प्लिट के बाद सेल्स को पॉप्युलेट करें और आवश्यक टेक्स्ट फ़ॉर्मेटिंग को स्पष्ट रूप से सेट करें।

सहेजा गया प्रेज़ेंटेशन अलग‑अलग "Product A" और "Product B" सेल्स रखता है, जबकि टेम्पलेट की सेल फ़ॉर्मेटिंग बरकरार रहती है। विवरण के लिए देखें [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)।

### **विशिष्ट ऊँचाई पर सेल को स्प्लिट करें**

[splitByHeight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyheight/) ऊँचे भाग की ऊँचाई पॉइंट्स में लेता है। [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) ऊपर वाले भाग में मौजूदा ग्रिड पंक्तियों की संख्या लेता है। दायीं कॉलम में 40‑पॉइंट सेल को केंद्रित करने के लिए, सेल की वास्तविक ऊँचाई से 40 घटाएँ और बची हुई जगह को बराबर ऊपर और नीचे वितरित करें।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 160, 160 ];
    $rowHeights = [ 140 ];
    
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);
    $table->get_Item(0, 0)->getTextFrame()->setText("Left");

    $rightCell = $table->get_Item(1, 0);
    $height = java_values($rightCell->getHeight());
    $margin = ($height - 40) / 2;

    $rightCell->splitByHeight($margin);
    $table->get_Item(1, 1)->splitByHeight(40);
    $table->get_Item(1, 1)->getTextFrame()->setText("Middle");

    $presentation->save("split_by_height.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

पहला स्प्लिट एक ग्रिड पंक्ति जोड़ता है और सेल `(1, 1)` में नीचे की ओर 90 पॉइंट छोड़ता है। दूसरा स्प्लिट उस सेल को 40‑पॉइंट मध्य सेल और 50‑पॉइंट नीचे के सेल में विभाजित करता है। दायीं कॉलम अब तीन सेल्स रखता है जिनकी ऊँचाई क्रमशः 50, 40, और 50 पॉइंट है। बायाँ सेल सभी तीन पंक्तियों को कवर करता है और अपनी मूल 140‑पॉइंट ऊँचाई बरकरार रखता है।

![बायाँ सेल पूरी टेबल की ऊँचाई को कवर करता है, जबकि मध्य में तीन सेल्स हैं।](split-by-height.png)

## **टेबल सेल की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150‑पॉइंट कॉलम और 50‑पॉइंट पंक्तियों के साथ एक टेबल बनाता है। यह [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) का उपयोग करके सॉलिड फ़िल चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) द्वारा लौटाए गए रंग को लाल सेट करता है, सेल `(2, 3)` (तीसरा कॉलम, चौथी पंक्ति) के लिए।

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 50, 50, 50, 50, 50 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **टेबल सेल के अंदर एक छवि जोड़ें**

उदाहरण चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) द्वारा लोड करता है और प्रस्तुति के इमेज कलेक्शन में [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) से जोड़ता है। फिर यह छवि को सेल `(0, 0)` (टेबल का पहला सेल) की पिक्चर फ़िल में असाइन करता है।

[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) छवि को सेल में फिट करने के लिए स्ट्रेच करता है, जिससे उसका एस्पेक्ट रेशियो बदल सकता है। कॉलम चौड़ाई और पंक्ति ऊँचाई पॉइंट्स में हैं। लोड की गई छवि को `finally` ब्लॉक में डिस्पोज़ किया जाता है, जब वह प्रस्तुति में जोड़ दी गई हो।

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [ 150, 150, 150, 150 ];
    $rowHeights = [ 100, 100, 100, 100, 90 ];
    $table = $slide->getShapes()->addTable(50, 50, $columnWidths, $rowHeights);

    $image = Images::fromFile("aspose_logo.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->setFillType(FillType::Picture);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $table->get_Item(0, 0)->getCellFormat()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("table_cell_with_image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**क्या मैं एक ही सेल के विभिन्न पक्षों के लिए अलग‑अलग लाइन मोटाई और शैली निर्धारित कर सकता हूँ?**

हां। [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) बॉर्डर्स के अलग‑अलग प्रॉपर्टी होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली भिन्न हो सकती है।

**सेल की पृष्ठभूमि में एक चित्र सेट करने के बाद यदि मैं कॉलम/पंक्ति आकार बदलता हूँ तो चित्र क्या करता है?**

यह व्यवहार [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग पर, चित्र नए सेल के अनुसार समायोजित हो जाता है; टाइलिंग पर, टाइल्स पुनः गणना की जाती हैं।

**क्या मैं सेल की पूरी सामग्री को एक हाइपरलिंक दे सकता हूँ?**

[Hyperlinks](/slides/hi/php-java/manage-hyperlinks/) को सेल के टेक्स्ट (पोर्टियन) स्तर पर या पूरे टेबल/शेप स्तर पर सेट किया जाता है। व्यवहार में आप लिंक को एक पोर्टियन या सेल के सभी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही सेल के भीतर विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हां। सेल के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (रन) होते हैं जिनकी फ़ॉर्मेटिंग स्वतंत्र होती है—फ़ॉन्ट फ़ैमिली, शैली, आकार, और रंग।