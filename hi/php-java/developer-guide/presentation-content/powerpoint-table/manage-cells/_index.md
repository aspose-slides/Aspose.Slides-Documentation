---
title: PHP का उपयोग करके प्रस्तुतियों में तालिका कोशिकाओं का प्रबंधन
linktitle: कोशिकाओं का प्रबंधन
type: docs
weight: 30
url: /hi/php-java/manage-cells/
keywords:
- तालिका कोशिका
- कोशिकाओं को मिलाएँ
- सीमा हटाएँ
- कोशिका विभाजित करें
- कोशिका में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में PowerPoint तालिका कोशिकाओं का प्रबंधन: मर्ज की गई कोशिकाओं की पहचान, सीमाओं को हटाना, कोशिकाओं को विभाजित करना, और Aspose.Slides for PHP via Java के साथ पृष्ठभूमि रंग और छवियों को सेट करना।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में तालिका कोशिकाओं तक पहुँचने और संशोधित करने की अनुमति देता है। यह लेख समझाता है कि मर्ज की गई तालिका कोशिकाओं की पहचान कैसे करें, कोशिका सीमाओं को हटाएँ, मर्ज या स्प्लिट करने के बाद कोशिका क्रमांक के साथ कैसे काम करें, कोशिका की पृष्ठभूमि रंग बदलें, और तालिका कोशिका के भीतर एक छवि जोड़ें। उदाहरण दिखाते हैं कि प्रस्तुति कैसे बनाएँ या खोलें, स्लाइड से एक तालिका प्राप्त करें, कोशिका गुणों के माध्यम से कोशिका स्वरूपण अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

Aspose.Slides शून्य-आधारित सूचकांकों का उपयोग करता है तालिका कोशिकाओं तक `(column, row)` क्रम में पहुँचने के लिए।

## **मर्ज की गई तालिका कोशिका की पहचान**

उदाहरण एक मौजूदा प्रस्तुति खोलता है और पहले स्लाइड पर पहले आकार (shape) तक तालिका के रूप में पहुँचता है। यह मानता है कि स्लाइड और आकार मौजूद हैं और आकार एक तालिका है। फिर वह सभी पंक्तियों और स्तंभों पर पुनरावृति करता है और मर्ज किए गए क्षेत्रों में कोशिकाओं की पहचान करने के लिए [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) का उपयोग करता है। प्रत्येक मिलान के लिए, वह कोशिका निर्देशांक `row;column` क्रम में, [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/), और क्षेत्र के प्रारंभिक निर्देशांक, [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) और [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) प्रिंट करता है।

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

## **तालिका कोशिका की सीमाओं को हटाएँ**

एक [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) बनाएँ और उसके पहले स्लाइड में [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) के साथ एक तालिका जोड़ें। स्तंभ चौड़ाइयाँ, पंक्ति ऊँचाइयाँ, और तालिका की स्थिति पॉइंट्स में निर्दिष्ट हैं। उदाहरण सभी चार कोशिका सीमाओं को [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) पर सेट करता है, जिससे वे अदृश्य हो जाती हैं।

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

## **तालिका कोशिकाओं को मर्ज करें**

[mergeCells](https://reference.aspose.com/slides/php-java/aspose.slides/table/mergecells/) का उपयोग करके तालिका कोशिकाओं की एक आयताकार सीमा को एक ही कोशिका में मिलाएँ। सीमा के ऊपर-बाएँ और नीचे-दाएँ कोनों पर स्थित कोशिकाओं को निर्दिष्ट करें। अंतिम तर्क नियंत्रित करता है कि मर्ज निर्दिष्ट सीमा के बाहर की कोशिकाओं को शामिल कर सकता है या नहीं; `false` मर्ज को उसी सीमा में रखता है।

उदाहरण 70- पॉइंट स्तंभों और पंक्तियों के साथ 4×4 तालिका बनाता है, फिर `(1, 1)` से लेकर `(2, 2)` तक के चार केन्द्रीकृत कोशिकाओं को मर्ज करता है। परिणामस्वरूप कोशिका दो स्तंभों और दो पंक्तियों को कवर करती है, जबकि तालिका की मूल ग्रिड चार स्तंभ और चार पंक्तियाँ रखती है। मर्ज की गई कोशिका की सामग्री या स्वरूपण तक पहुँचने के लिए, उसके ऊपर-बाएँ स्थिति का उपयोग करें: इस उदाहरण में `$table->get_Item(1, 1)`। मर्ज सीमा के अन्य स्थितियाँ तालिका ग्रिड का हिस्सा बनी रहती हैं, इसलिए सीमा से बाहर की कोशिकाओं के सूचकांक नहीं बदलते।

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

## **तालिका कोशिकाओं को विभाजित करें**

पिछले उदाहरण में कोशिकाओं को मर्ज करने से तालिका की ग्रिड संरक्षित रहती है। किसी कोशिका को विभाजित करने से नया ग्रिड स्तंभ जोड़ सकता है और दाईं ओर की कोशिकाओं के स्तंभ सूचकांकों को बदल सकता है। Aspose.Slides PowerPoint की तालिका ग्रिड मॉडल का अनुसरण करता है।

यह उदाहरण 70- पॉइंट स्तंभों और पंक्तियों के साथ 4×4 तालिका बनाता है और कोशिका `(1, 1)` पर [splitByWidth](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbywidth/) को कॉल करता है। कोशिका की 70- पॉइंट चौड़ाई का आधा भाग दो समान-चौड़ाई कोशिकाओं को बनाने के लिए पास किया जाता है।

इस विभाजन के बाद, दो भागों तक `$table->get_Item(1, 1)` और `$table->get_Item(2, 1)` द्वारा पहुँचा जाता है। तालिका ग्रिड अब पाँच स्तंभ रखती है: मूल रूप से स्तंभ 2 और 3 में स्थित कोशिकाएँ क्रमशः स्तंभ 3 और 4 में चली जाती हैं। पंक्ति सूचकांक अपरिवर्तित रहते हैं। विभाजन के बाद कोशिकाओं तक पहुँचते समय इन अपडेट किए गए स्तंभ सूचकांकों का उपयोग करें।

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

### **पंक्ति या स्तंभ स्पैन द्वारा मर्ज की गई कोशिकाओं को विभाजित करें**

डेटा भरने के लिए मर्ज किए गए टेम्प्लेट कोशिकाओं की तैयारी हेतु, मौजूदा पंक्ति सीमा के साथ विभाजन के लिए [splitByRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbyrowspan/) का उपयोग करें, या स्तंभ सीमा के साथ विभाजन के लिए [splitByColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/splitbycolspan/) का उपयोग करें।  
`index` तर्क विभाजन के ऊपरी भाग में पंक्तियों या बाएँ भाग में स्तंभों की गिनती करता है; यह मर्ज किए गए क्षेत्र के सापेक्ष है:

- पंक्ति विभाजन: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getrowspan/).
- स्तंभ विभाजन: `0 < index <` [getColSpan](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getcolspan/).

उदाहरण अपेक्षा करता है कि प्रस्तुति पहली स्लाइड पर पहले आकार के रूप में एक तालिका रखती हो, जिसमें `(1, 2)` और `(1, 3)` लंबवत मर्ज किए गए हों। नीचे की स्थिति से शुरू करके, वह मूल को खोजने के लिए [getFirstColumnIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstcolumnindex/) और [getFirstRowIndex](https://reference.aspose.com/slides/php-java/aspose.slides/cell/getfirstrowindex/) का उपयोग करता है और दोनों स्पैन की जाँच करता है। `splitByRowSpan(1)` फिर उत्पाद नामों के लिए पंक्तियों 2 और 3 को अलग करता है। क्षैतिज दो-स्तंभ मर्ज के लिए, `splitByColSpan(1)` का उपयोग करें।

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

        // विभाजन के बाद तालिका से प्राप्त हुई कोशिकाओं को प्राप्त करें।
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

तालिका ग्रिड और आस-पास की कोशिका सूचकांक अपरिवर्तित रहते हैं। परिणामी कोशिकाओं को उनके निर्देशांक से प्राप्त करें; यहाँ, दोनों का स्पैन 1 है और [isMergedCell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/ismergedcell/) `false` प्रिंट करता है। बड़े क्षेत्रों को एक विभाजन के बाद भी भागिक रूप से मर्ज रखा जा सकता है।

मूल पाठ और उसका स्वरूपण ऊपर (या बाएँ) कोशिका में बना रहता है; नई कोशिका खाली है लेकिन भराव, सीमाओं और मार्जिन जैसी कोशिका स्वरूपण को विरासत में लेती है। विभाजन के बाद कोशिकाओं को भरें और आवश्यक पाठ स्वरूपण स्पष्ट रूप से सेट करें।

सेव की गई प्रस्तुति में अलग-अलग "Product A" और "Product B" कोशिकाएँ होती हैं जिनमें टेम्प्लेट की कोशिका स्वरूपण बरकरार रहता है। विवरण के लिए [Cell API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/cell/) देखें।

## **तालिका कोशिका की पृष्ठभूमि रंग बदलें**

यह उदाहरण 150- पॉइंट स्तंभों और 50- पॉइंट पंक्तियों वाली तालिका बनाता है। यह [setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/setfilltype/) का उपयोग करके ठोस भराव चुनता है और [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/getsolidfillcolor/) द्वारा लौटाए गए रंग को लाल सेट करता है कोशिका `(2, 3)` के लिए, जो तीसरे स्तंभ और चौथी पंक्ति में स्थित है।

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

## **तालिका कोशिका के अंदर छवि जोड़ें**

इस उदाहरण को चलाने से पहले इनपुट छवि को कार्य निर्देशिका में रखें। यह छवि को [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) से लोड करता है और प्रस्तुति की छवि संग्रह में [addImage](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/addimage/) के साथ जोड़ता है। फिर यह छवि को कोशिका `(0, 0)` के चित्र भराव को असाइन करता है, जो तालिका की पहली कोशिका है।  
[PictureFillMode::Stretch](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) छवि को खींचकर कोशिका में भरता है, जिससे इसका अनुपात बदल सकता है। स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ पॉइंट्स में हैं। लोड किए गए चित्र को प्रस्तुति में जोड़ने के बाद `finally` ब्लॉक में नष्ट कर दिया जाता है।

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

**क्या मैं एक ही कोशिका के विभिन्न पक्षों के लिए अलग‑अलग लाइन मोटाई और शैली सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/php-java/aspose.slides/cellformat/getborderright/) सीमाओं के अलग‑अलग गुण होते हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली भिन्न हो सकती है।

**यदि मैं चित्र को कोशिका की पृष्ठभूमि के रूप में सेट करने के बाद स्तंभ/पंक्ति का आकार बदलूँ तो छवि पर क्या असर पड़ेगा?**

यह व्यवहार [fill mode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेच करने पर छवि नए कोशिका के अनुसार समायोजित होती है; टाइल करने पर टाइलें पुनः गणना की जाती हैं।

**क्या मैं कोशिका की पूरी सामग्री को एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/php-java/manage-hyperlinks/) को कोशिका के टेक्स्ट फ्रेम के अंदर टेक्स्ट (portion) स्तर पर या पूरी तालिका/shape स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को एक portion या पूरी कोशिका के टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही कोशिका के भीतर विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। कोशिका के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/php-java/aspose.slides/portion/) (runs) समर्थन है जिनके स्वतंत्र स्वरूपण—फ़ॉन्ट परिवार, शैली, आकार और रंग—होते हैं।