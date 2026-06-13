---
title: PHP में प्रस्तुति तालिकाओं का प्रबंधन
linktitle: तालिका प्रबंधन
type: docs
weight: 10
url: /hi/php-java/manage-table/
keywords:
- तालिका जोड़ें
- तालिका बनाएं
- तालिका तक पहुंचें
- आस्पेक्ट अनुपात
- पाठ संरेखित करें
- पाठ स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint स्लाइड्स में तालिकाओं को बनाएं और संपादित करें। अपने तालिका कार्यप्रवाह को सुव्यवस्थित करने के लिए सरल कोड उदाहरण खोजें।"
---
## **परिचय**

PowerPoint में एक तालिका जानकारी को प्रदर्शित और चित्रित करने का एक कुशल तरीका है। कोशिकाओं के ग्रिड (पंक्तियों और स्तंभों में व्यवस्थित) में जानकारी सरल और आसानी से समझने योग्य होती है।

Aspose.Slides [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) क्लास, [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) क्लास, और अन्य प्रकार प्रदान करता है जिससे आप विभिन्न प्रकार की प्रस्तुतियों में तालिकाएँ बना, अपडेट और प्रबंधित कर सकते हैं।

## **शुरू से तालिका बनाएं**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `columnWidth` की एक एरे परिभाषित करें।  
4. `rowHeight` की एक एरे परिभाषित करें।  
5. [addTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addtable/) मेथड के माध्यम से स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) ऑब्जेक्ट जोड़ें।  
6. प्रत्येक [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/) को इटररेट करके शीर्ष, नीचे, दायें और बायें सीमा पर फॉर्मेटिंग लागू करें।  
7. तालिका की पहली पंक्ति के पहले दो कोशिकाओं को मर्ज करें।  
8. [Cell](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) तक पहुंचें।  
9. [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।  
10. परिवर्तित प्रस्तुति को सहेजें।

यह PHP कोड दर्शाता है कि प्रस्तुति में तालिका कैसे बनाएं:

```php
  # एक Presentation क्लास को इंस्टैंसिएट करता है जो PPTX फ़ाइल को दर्शाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # स्तंभों को चौड़ाइयों के साथ और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # स्लाइड में एक टेबल आकार जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
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
    # मर्ज की गई सेल में कुछ टेक्स्ट जोड़ता है
    $tbl->getRows()->get_Item(0)->get_Item(0)->getTextFrame()->setText("Merged Cells");
    # प्रेज़ेंटेशन को डिस्क पर सहेजता है
    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **मानक तालिका में क्रमांकन**

मानक तालिका में, कोशिकाओं की क्रमांकिंग सरल और शून्य-आधारित होती है। तालिका की पहली कोशिका का इंडेक्स 0,0 (स्तंभ 0, पंक्ति 0) होता है।

उदाहरण के लिए, 4 स्तंभ और 4 पंक्तियों वाली तालिका में कोशिकाएँ इस प्रकार क्रमांकित होती हैं:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

यह PHP कोड दर्शाता है कि तालिका में कोशिकाओं के लिये क्रमांकन कैसे निर्दिष्ट करें:

```php
  # एक Presentation क्लास को इंस्टैंसिएट करता है जो PPTX फ़ाइल का प्रतिनिधित्व करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # स्तंभों को चौड़ाइयों के साथ और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # स्लाइड में एक टेबल आकार जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक सेल के लिए बॉर्डर फ़ॉर्मेट सेट करता है
    foreach($tbl->getRows() as $row) {
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

## **मौजूदा तालिका तक पहुंचें**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से तालिका वाले स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट बनाएं और उसे null सेट करें।  
4. सभी [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट्स को इटररेट करें जब तक तालिका न मिल जाए।  

यदि आपको संदेह है कि जिस स्लाइड को आप संभाल रहे हैं उसमें केवल एक तालिका है, तो आप बस उस स्लाइड में सभी शैप्स को जांच सकते हैं। जब किसी शैप को तालिका के रूप में पहचाना जाता है, तो आप इसे [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट में टाइपकास्ट कर सकते हैं। लेकिन यदि स्लाइड में कई तालिकाएँ हैं, तो आपको आवश्यक तालिका को उसके [setAlternativeText(String value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/setalternativetext/) के माध्यम से खोजना बेहतर रहेगा।  

5. [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट का उपयोग करके तालिका पर कार्य करें। नीचे के उदाहरण में, हमने तालिका में एक नई पंक्ति जोड़ी।  
6. परिवर्तित प्रस्तुति को सहेजें।

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करता है
  $pres = new Presentation("UpdateExistingTable.pptx");
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # null TableEx को आरम्भ करता है
    $tbl = null;
    # शैप्स के माध्यम से इटरेट करता है और पाए गए टेबल का रेफ़रेंस सेट करता है
    foreach($sld->getShapes() as $shp) {
      if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
        $tbl = $shp;
        # दूसरे पंक्ति के पहले कॉलम के लिए टेक्स्ट सेट करता है
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

## **तालिका में टेक्स्ट को संरेखित करें**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड में एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।  
4. तालिका से एक [TextFrame](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframe/) ऑब्जेक्ट तक पहुंचें।  
5. [Paragraph](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraph/) तक पहुंचें।  
6. टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करें।  
7. परिवर्तित प्रस्तुति को सहेजें।

```php
  # Presentation क्लास का एक इंस्टेंस बनाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड प्राप्त करता है
    $slide = $pres->getSlides()->get_Item(0);
    # स्तंभों को चौड़ाइयों और पंक्तियों को ऊँचाइयों के साथ परिभाषित करता है
    $dblCols = array(120, 120, 120, 120 );
    $dblRows = array(100, 100, 100, 100 );
    # स्लाइड में टेबल आकार जोड़ता है
    $tbl = $slide->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    $tbl->get_Item(1, 0)->getTextFrame()->setText("10");
    $tbl->get_Item(2, 0)->getTextFrame()->setText("20");
    $tbl->get_Item(3, 0)->getTextFrame()->setText("30");
    # टेक्स्ट फ्रेम तक पहुँचता है
    $txtFrame = $tbl->get_Item(0, 0)->getTextFrame();
    # टेक्स्ट फ्रेम के लिए पैराग्राफ ऑब्जेक्ट बनाता है
    $paragraph = $txtFrame->getParagraphs()->get_Item(0);
    # पैराग्राफ के लिए पोर्शन ऑब्जेक्ट बनाता है
    $portion = $paragraph->getPortions()->get_Item(0);
    $portion->setText("Text here");
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # टेक्स्ट को ऊर्ध्वाधर रूप से संरेखित करता है
    $cell = $tbl->get_Item(0, 0);
    $cell->setTextAnchorType(TextAnchorType::Center);
    $cell->setTextVerticalType(TextVerticalType::Vertical270);
    # प्रेज़ेंटेशन को डिस्क पर सहेजता है
    $pres->save("Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका स्तर पर टेक्स्ट फॉर्मेटिंग सेट करें**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड से एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट तक पहुंचें।  
4. टेक्स्ट के लिए [setFontHeight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight) सेट करें।  
5. [setAlignment(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setalignment/) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setmarginright/) सेट करें।  
6. [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/settextverticaltype/) सेट करें।  
7. परिवर्तित प्रस्तुति को सहेजें।  

यह PHP कोड दर्शाता है कि तालिका के टेक्स्ट पर अपनी पसंदीदा फ़ॉर्मेटिंग विकल्प कैसे लागू करें:

```php
  # Presentation क्लास का एक इंस्टेंस बनाता है
  $pres = new Presentation("simpletable.pptx");
  try {
    # मान लेते हैं कि पहली स्लाइड पर पहला शैप एक टेबल है
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # टेबल सेल्स के फ़ॉन्ट हाइट को सेट करता है
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->setTextFormat($portionFormat);
    # एक कॉल में टेबल सेल्स के टेक्स्ट अलाइनमेंट और दाएँ मार्जिन को सेट करता है
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->setTextFormat($paragraphFormat);
    # टेबल सेल्स के टेक्स्ट वर्टिकल टाइप को सेट करता है
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

Aspose.Slides आपको तालिका के शैली गुण प्राप्त करने की अनुमति देता है ताकि आप इन विवरणों का उपयोग अन्य तालिका या कहीं और कर सकें। यह PHP कोड दर्शाता है कि तालिका के प्रीसेट शैली से शैली गुण कैसे प्राप्त करें:

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

## **तालिका का अनुपात लॉक करें**

ज्यामितीय आकार का अनुपात विभिन्न आयामों में उसके आकार का अनुपात होता है। Aspose.Slides ने [setAspectRatioLocked](https://reference.aspose.com/slides/hi/php-java/aspose.slides/graphicalobjectlock/setaspectratiolocked/) मेथड प्रदान किया है जिससे आप तालिकाओं और अन्य आकारों के लिए अनुपात लॉक सेटिंग को लॉक कर सकते हैं।

यह PHP कोड दर्शाता है कि तालिका के लिए अनुपात कैसे लॉक करें:

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

**क्या मैं पूरी तालिका और उसकी कोशिकाओं में टेक्स्ट के लिए दाएं से बाएं (RTL) पढ़ने की दिशा सक्षम कर सकता/सकती हूँ?**

हां। तालिका एक [setRightToLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/setrighttoleft/) मेथड प्रदान करती है, और पैराग्राफ के पास [ParagraphFormat::setRightToLeft](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setrighttoleft/) मेथड है। दोनों का उपयोग करने से कोशिकाओं के अंदर सही RTL क्रम और रेंडरिंग सुनिश्चित होती है।

**मैं उपयोगकर्ताओं को अंतिम फ़ाइल में तालिका को हिलाने या आकार बदलने से कैसे रोक सकता/सकती हूँ?**

आकार लॉक का उपयोग करके मूविंग, रिसाइज़िंग, चयन आदि को अक्षम करें। ये लॉक तालिकाओं पर भी लागू होते हैं।

**क्या एक सेल के भीतर बैकग्राउंड के रूप में छवि सम्मिलित करना समर्थित है?**

हां। आप किसी सेल के लिए [picture fill](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillformat/) सेट कर सकते हैं; चयनित मोड (स्ट्रैच या टाइल) के अनुसार छवि सेल क्षेत्र को कवर करेगी।