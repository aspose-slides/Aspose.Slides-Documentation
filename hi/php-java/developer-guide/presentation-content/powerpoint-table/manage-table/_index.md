---
title: PHP में प्रस्तुति तालिकाओं को प्रबंधित करें
linktitle: तालिका प्रबंधित करें
type: docs
weight: 10
url: /hi/php-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुँचें
- आस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint स्लाइड्स में तालिकाएँ बनाएँ और संपादित करें। अपने तालिका कार्यप्रवाह को सरल बनाने के लिए सरल कोड उदाहरणों की खोज करें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी को प्रभावी तरीके से प्रदर्शित करने और दर्शाने का साधन है। कोशिकाओं की ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी स्पष्ट और समझने में आसान होती है।

Aspose.Slides प्रदान करता है [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) क्लास, [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) क्लास, और अन्य प्रकार ताकि आप विभिन्न प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकें।

## **शुरुआत से एक तालिका बनाएं**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें। 
3. `columnWidth` की एक सरणी परिभाषित करें।
4. `rowHeight` की एक सरणी परिभाषित करें।
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addtable/) मेथड के ज़रिए एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) ऑब्जेक्ट जोड़ें।
6. प्रत्येक [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) पर इटररेट करके शीर्ष, नीचे, दाएँ और बाएँ सीमा पर फ़ॉर्मेटिंग लागू करें।
7. तालिका की पहली पंक्ति के पहले दो कोशिकाओं को मर्ज करें। 
8. एक [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) का [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुँचें।
9. [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
10. संशोधित प्रस्तुति को सहेजें।

यह PHP कोड दिखाता है कि प्रस्तुति में तालिका कैसे बनाते हैं:

```php
  # एक Presentation क्लास को इंस्टैंटिएट करता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुंचता है
    $sld = $pres->getSlides()->get_Item(0);
    # स्तंभों को चौड़ाई के साथ और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # स्लाइड में एक तालिका आकार जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
    for($row = 0; $row < java_values($tbl->getRows()->size()) ; $row++) {
      for($cell = 0; $cell < java_values($tbl->getRows()->get_Item($row)->size()) ; $cell++) {
        $cellFormat = $tbl->getRows()->get_Item($row)->get_Item($cell)->getCellFormat();
        $cellFormat::getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderTop()->setWidth(5);
        $cellFormat::getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderBottom()->setWidth(5);
        $cellFormat::getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderLeft()->setWidth(5);
        $cellFormat::getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cellFormat::getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cellFormat::getBorderRight()->setWidth(5);
      }
    }
    # पंक्ति 1 की कोशिकाएँ 1 और 2 को मर्ज करता है
    $tbl->mergeCells($tbl->getRows()->get_Item(0)->get_Item(0), $tbl->getRows()->get_Item(1)->get_Item(1), false);
    # मर्ज की गई कोशिका में कुछ टेक्स्ट जोड़ता है
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **मानक तालिका में क्रमांकन**

एक मानक तालिका में कोशिकाओं का क्रमांकन सरल और शून्य-आधारित होता है। तालिका की पहली कोशिका को 0,0 (स्तंभ 0, पंक्ति 0) के रूप में अनुक्रमित किया जाता है। 

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका की कोशिकाएँ इस प्रकार क्रमांकित होती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह PHP कोड दिखाता है कि तालिका में कोशिकाओं के क्रमांकन को कैसे निर्दिष्ट करें:

```php
  # एक Presentation क्लास को इंस्टैंटिएट करता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुंचता है
    $sld = $pres->getSlides()->get_Item(0);
    # स्तंभों को चौड़ाई के साथ और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # स्लाइड में एक तालिका आकार जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक कोशिका के लिए सीमा स्वरूप सेट करता है
    $rows = $tbl->getRows();
    foreach($rows as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderTop()->setWidth(5);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderBottom()->setWidth(5);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderLeft()->setWidth(5);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::Solid);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
        $cell->getCellFormat()->getBorderRight()->setWidth(5);
      }
    }
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("StandardTables_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **मौजूदा तालिका तक पहुँचें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।

2. इंडेक्स के माध्यम से तालिका वाली स्लाइड का संदर्भ प्राप्त करें। 

3. एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट बनाएं और उसे null सेट करें।

4. सभी [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट्स पर इटररेट करें जब तक तालिका न मिल जाए।

   यदि आपको संदेह है कि आप जिस स्लाइड को संभाल रहे हैं उसमें केवल एक तालिका है, तो आप बस उसकी सभी शैप्स की जाँच कर सकते हैं। जब कोई शैप तालिका के रूप में पहचाना जाता है, तो आप उसे एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट के रूप में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आपको उसकी [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/setalternativetext/) के माध्यम से आवश्यक तालिका को खोज लेना बेहतर रहेगा।

5. तालिका के साथ काम करने के लिए [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट का उपयोग करें। नीचे के उदाहरण में, हमने तालिका में एक नई पंक्ति जोड़ी है।

6. संशोधित प्रस्तुति को सहेजें।

यह PHP कोड दिखाता है कि मौजूदा तालिका तक कैसे पहुँचें और उसके साथ कार्य करें:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करता है
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # पहली स्लाइड तक पहुंचता है
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx को इनिशियलाइज़ करता है
    $tbl = null;
    # शैप्स के माध्यम से इटरेट करता है और मिली तालिका का संदर्भ सेट करता है
    $shapes = $sld->getShapes();
    foreach($shapes as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # दूसरी पंक्ति के पहले स्तम्भ के लिए टेक्स्ट सेट करता है
        $tbl->get_Item(0, 1)->getTextFrame()->setText("New");
      }
    }
    # संशोधित प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("table1_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ऐसे TextFrame को खोजें जो किसी कोशिका का स्वामित्व रखता है**

जब सामान्य टेक्स्ट-प्रोसेसिंग कोड को तालिका से कोई [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) प्राप्त होता है, तो स्वामित्व वाली [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) को प्राप्त करने के लिए [TextFrame::getParentCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentCell) मेथड का उपयोग करें। तालिका-कोशिका टेक्स्ट फ्रेम के लिए, [TextFrame::getParentCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentCell) स्वामी को लौटाता है और [TextFrame::getParentShape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentShape) `null` लौटाता है, भले ही तालिका स्वयं एक शैप हो।

कोशिका के निर्देशांक पढ़ने-केवल [Cell::getFirstColumnIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/#getFirstColumnIndex) और [Cell::getFirstRowIndex](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/#getFirstRowIndex) मेथड्स के माध्यम से उपलब्ध होते हैं। [TextFrame::getParentCell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/#getParentCell) भी पढ़ने-केवल नेविगेशन प्रदान करता है: यह स्वामी को लौटाता है लेकिन स्वामित्व नहीं बदलता। उपयोग करने से पहले हमेशा `java_is_null` के साथ लौटाए गए कोशिका की जाँच करें।

तालिका-कोशिका और शैप स्वामियों को पहचानने वाले पूर्ण उदाहरण के लिए, जिसमें SmartArt नोड्स से संबंधित शैप्स भी शामिल हैं, देखें [Search and Replace Text](/slides/hi/php-java/search-and-replace-text/)।

## **तालिका में टेक्स्ट को संरेखित करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें। 
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।
4. तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) ऑब्जेक्ट तक पहुँचें।
5. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) तक पहुँचें।
6. टेक्स्ट को लंबवत रूप से संरेखित करें।
7. संशोधित प्रस्तुति को सहेजें।

यह PHP कोड दिखाता है कि तालिका में टेक्स्ट को कैसे संरेखित करें:

```php
  # Presentation क्लास की एक इंस्टैंस बनाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # स्लाइड में तालिका आकार जोड़ता है
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # टेक्स्ट फ्रेम तक पहुंचता है
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # पैराग्राफ के लिए पोर्शन ऑब्जेक्ट बनाता है
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # टेक्स्ट को लंबवत रूप से संरेखित करता है
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका स्तर पर टेक्स्ट फ़ॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास की एक इंस्टेंस बनाएं।
2. स्लाइड का संदर्भ उसके इंडेक्स के माध्यम से प्राप्त करें। 
3. स्लाइड से एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट तक पहुँचें।
4. टेक्स्ट के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight) सेट करें।
5. [setAlignment(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setalignment/) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setmarginright/) सेट करें।
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/settextverticaltype/) सेट करें।
7. संशोधित प्रस्तुति को सहेजें। 

यह PHP कोड दिखाता है कि तालिका में टेक्स्ट पर अपनी पसंदीदा फ़ॉर्मेटिंग विकल्प कैसे लागू करें:

```php
  # Presentation क्लास की एक इंस्टैंस बनाता है
  $pres = new Presentation("simpletable.pptx");
  try {
    # मान लेते हैं कि पहली स्लाइड पर पहला शैप एक तालिका है
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # तालिका कोशिकाओं का फ़ॉन्ट ऊँचाई सेट करता है
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # एक कॉल में तालिका कोशिकाओं का टेक्स्ट एलाइन्मेंट और दाएं मार्जिन सेट करता है
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # तालिका कोशिकाओं का टेक्स्ट वर्टिकल टाइप सेट करता है
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका के लिए शैली गुण प्राप्त करने की अनुमति देता है ताकि आप उन विवरणों को किसी दूसरी तालिका या किसी अन्य स्थान पर उपयोग कर सकें। यह PHP कोड दिखाता है कि तालिका प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// डिफ़ॉल्ट शैली प्रीसेट थीम बदलें

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका का पहलू अनुपात लॉक करें**

भौगोलिक आकार का पहलू अनुपात विभिन्न आयामों में उसके आकार का अनुपात होता है। Aspose.Slides ने तालिकाओं और अन्य शैप्स के लिए पहलू अनुपात लॉक करने की सेटिंग प्रदान करने हेतु [setAspectRatioLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) मेथड प्रदान किया है।

यह PHP कोड दिखाता है कि तालिका के लिए पहलू अनुपात कैसे लॉक करें:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $table->getGraphicalObjectLock()->setAspectRatioLocked(!$table->getGraphicalObjectLock()->getAspectRatioLocked());// invert

    echo("Lock aspect ratio set: " . $table->getGraphicalObjectLock()->getAspectRatioLocked());
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरी तालिका और उसकी कोशिकाओं के टेक्स्ट के लिए दाएँ‑से‑बाएँ (RTL) पढ़ने की दिशा सक्षम कर सकता हूँ?**

हां। तालिका में एक [setRightToLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/setrighttoleft/) मेथड उपलब्ध है, और पैराग्राफ में [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setrighttoleft/) है। दोनों का उपयोग करने से कोशिकाओं के भीतर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को स्थानांतरित या आकार बदलने से कैसे रोक सकता हूँ?**

शैप लॉक का उपयोग करके मूविंग, रिसाइज़िंग, चयन आदि को अक्षम करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या कोई कोशिका के भीतर पृष्ठभूमि के रूप में एक चित्र डालना समर्थित है?**

हां। आप किसी कोशिका के लिए एक [picture fill](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) सेट कर सकते हैं; चित्र चुनी गई मोड (स्ट्रैच या टाइल) के अनुसार कोशिका क्षेत्र को कवर करेगा।