---
title: PHP का उपयोग करके प्रस्तुतियों में टेबल सेल प्रबंधित करें
linktitle: सेल प्रबंधित करें
type: docs
weight: 30
url: /hi/php-java/manage-cells/
keywords:
- टेबल सेल
- सेल मर्ज
- बॉर्डर हटाएँ
- सेल विभाजित करें
- सेल में छवि
- पृष्ठभूमि रंग
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP के साथ PowerPoint में टेबल सेल्स को सहजता से प्रबंधित करें। शीघ्रता से सेल्स तक पहुँच, संशोधन और स्टाइलिंग में प्रमुख बनें ताकि स्लाइड ऑटोमेशन सुगम हो सके।"
---
## **समीक्षा**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में टेबल सेल्स तक पहुँचने और उन्हें संशोधित करने की अनुमति देता है। यह लेख दर्शाता है कि मर्ज्ड टेबल सेल्स की पहचान कैसे करें, सेल बॉर्डर को हटाएँ, सेल को मर्ज या स्प्लिट करने के बाद नंबरिंग के साथ कैसे काम करें, सेल की पृष्ठभूमि का रंग कैसे बदलें, और टेबल सेल के भीतर एक छवि कैसे जोड़ें। उदाहरण दर्शाते हैं कि प्रस्तुति कैसे बनाएं या खोलें, स्लाइड से टेबल प्राप्त करें, सेल प्रॉपर्टीज़ के माध्यम से सेल फॉर्मेटिंग अपडेट करें, और संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

## **मर्ज्ड टेबल सेल की पहचान करें**
1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. पहले स्लाइड से टेबल प्राप्त करें।
3. टेबल की पंक्तियों और स्तंभों में इटररेट करें ताकि मर्ज्ड सेल्स मिल सकें।
4. जब मर्ज्ड सेल्स मिलें तो संदेश प्रिंट करें।

यह PHP कोड आपको प्रस्तुति में मर्ज्ड टेबल सेल्स की पहचान करने का तरीका दिखाता है:

```php
  $pres = new Presentation("SomePresentationWithTable.pptx");
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);// मान लेते हैं कि Slide#0.Shape#0 एक टेबल है

    for($i = 0; $i < java_values($table->getRows()->size()) ; $i++) {
      for($j = 0; $j < java_values($table->getColumns()->size()) ; $j++) {
        $currentCell = $table->getRows()->get_Item($i)->get_Item($j);
        if ($currentCell->isMergedCell()) {
          echo(sprintf("Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", $i, $j, $currentCell->getRowSpan(), $currentCell->getColSpan(), $currentCell->getFirstRowIndex(), $currentCell->getFirstColumnIndex()));
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेबल सेल बॉर्डर हटाएँ**
1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. चौड़ाई के साथ कॉलम्स की एक एरे परिभाषित करें।
4. ऊँचाई के साथ रो की एक एरे परिभाषित करें।
5. स्लाइड में टेबल को [addTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addTable) मेथड के द्वारा जोड़ें।
6. हर सेल को इटररेट करके शीर्ष, नीचे, दायें और बायें बॉर्डर साफ करें।
7. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड आपको टेबल सेल्स से बॉर्डर हटाने का तरीका दिखाता है:

```php
  # एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # चौड़ाई वाले कॉलम और ऊँचाई वाली पंक्तियों को परिभाषित करता है
    $dblCols = array(50, 50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # स्लाइड में टेबल शेप जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक सेल के लिए बॉर्डर फॉर्मेट सेट करता है
    foreach($tbl->getRows() as $row) {
      foreach($row as $cell) {
        $cell->getCellFormat()->getBorderTop()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderBottom()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderLeft()->getFillFormat()->setFillType(FillType::NoFill);
        $cell->getCellFormat()->getBorderRight()->getFillFormat()->setFillType(FillType::NoFill);
      }
    }
    # PPTX को डिस्क पर लिखता है
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **मर्ज्ड सेल्स में क्रमांकन**
यदि हम दो जोड़े सेल्स (1, 1) x (2, 1) और (1, 2) x (2, 2) को मर्ज करें, तो परिणामी टेबल में क्रमांक होंगे। यह PHP कोड प्रक्रिया को दर्शाता है:

```php
  # एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # चौड़ाई वाले कॉलम और ऊँचाई वाली पंक्तियों को परिभाषित करता है
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # स्लाइड में टेबल शेप जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक सेल के लिए बॉर्डर फॉर्मेट सेट करता है
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
    # सेल (1, 1) x (2, 1) को मर्ज करता है
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # सेल (1, 2) x (2, 2) को मर्ज करता है
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

हम फिर (1, 1) और (1, 2) को मर्ज करके सेल्स को आगे मर्ज करते हैं। परिणामस्वरूप टेबल के केंद्र में एक बड़ा मर्ज्ड सेल वाला टेबल बनता है:

```php
  # एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # चौड़ाई वाले कॉलम और ऊँचाई वाली पंक्तियों को परिभाषित करता है
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # स्लाइड में एक टेबल शेप जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक सेल के लिए बॉर्डर फॉर्मेट सेट करता है
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
    # सेल (1, 1) x (2, 1) को मर्ज करता है
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # सेल (1, 2) x (2, 2) को मर्ज करता है
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # सेल (1, 1) x (1, 2) को मर्ज करता है
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(1, 2), true);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("MergeCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **स्प्लिटेड सेल में क्रमांकन**
पिछले उदाहरणों में, जब टेबल सेल्स को मर्ज किया गया, तो अन्य सेल्स की क्रमांक प्रणाली नहीं बदली।

इस बार, हम एक सामान्य टेबल (बिना मर्ज्ड सेल्स वाला टेबल) लेते हैं और फिर सेल (1,1) को स्प्लिट करने की कोशिश करते हैं ताकि एक विशेष टेबल बन सके। आप इस टेबल की क्रमांकन पर ध्यान दे सकते हैं, जो शायद अजीब लग सकती है। हालांकि, यह वही तरीका है जिससे Microsoft PowerPoint टेबल सेल्स को क्रमांकित करता है और Aspose.Slides भी यही करता है।

यह PHP कोड प्रक्रिया को दर्शाता है:

```php
  # PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $sld = $pres->getSlides()->get_Item(0);
    # चौड़ाई वाले कॉलम और ऊँचाई वाली पंक्तियों को परिभाषित करता है
    $dblCols = array(70, 70, 70, 70 );
    $dblRows = array(70, 70, 70, 70 );
    # स्लाइड में टेबल शेप जोड़ता है
    $tbl = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # प्रत्येक सेल के लिए बॉर्डर फॉर्मेट सेट करता है
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
    # सेल (1, 1) x (2, 1) को मर्ज करता है
    $tbl->mergeCells($tbl->get_Item(1, 1), $tbl->get_Item(2, 1), false);
    # सेल (1, 2) x (2, 2) को मर्ज करता है
    $tbl->mergeCells($tbl->get_Item(1, 2), $tbl->get_Item(2, 2), false);
    # सेल (1, 1) को विभाजित करता है
    $tbl->get_Item(1, 1)->splitByWidth($tbl->get_Item(2, 1)->getWidth() / 2);
    # PPTX फ़ाइल को डिस्क पर लिखता है
    $pres->save("SplitCells_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **टेबल सेल की पृष्ठभूमि का रंग बदलें**

यह PHP कोड दिखाता है कि टेबल सेल की पृष्ठभूमि का रंग कैसे बदलें:

```php
  $presentation = new Presentation();
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(50, 50, 50, 50, 50 );
    # एक नई टेबल बनाता है
    $table = $slide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # एक सेल के लिए पृष्ठभूमि रंग सेट करता है
    $cell = $table->get_Item(2, 3);
    $cell->getCellFormat()->getFillFormat()->setFillType(FillType::Solid);
    $cell->getCellFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $presentation->save("cell_background_color.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **टेबल सेल के भीतर एक छवि जोड़ें**

1. [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएं।
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।
3. चौड़ाई के साथ कॉलम्स की एक एरे परिभाषित करें।
4. ऊँचाई के साथ रो की एक एरे परिभाषित करें।
5. स्लाइड में टेबल को [AddTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/#addTable) मेथड के द्वारा जोड़ें।
6. छवि फ़ाइल को रखने के लिए `Images` ऑब्जेक्ट बनाएं।
7. `IImage` इमेज को `IPPImage` ऑब्जेक्ट में जोड़ें।
8. टेबल सेल के लिए `FillFormat` को `Picture` पर सेट करें।
9. छवि को टेबल की पहली सेल में जोड़ें।
10. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

यह PHP कोड दिखाता है कि टेबल बनाते समय टेबल सेल के भीतर छवि कैसे रखें:

```php
  # एक PPTX फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करता है
  $pres = new Presentation();
  try {
    # पहली स्लाइड तक पहुँचता है
    $islide = $pres->getSlides()->get_Item(0);
    # चौड़ाई वाले कॉलम और ऊँचाई वाली पंक्तियों को परिभाषित करता है
    $dblCols = array(150, 150, 150, 150 );
    $dblRows = array(100, 100, 100, 100, 90 );
    # स्लाइड में टेबल शेप जोड़ता है
    $tbl = $islide->getShapes()->addTable(50, 50, $dblCols, $dblRows);
    # इमेज फ़ाइल का उपयोग करके एक IPPImage ऑब्जेक्ट बनाता है
    $picture;
    $image = Images->fromFile("image.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # इमेज को पहले टेबल सेल में जोड़ता है
    $cellFormat = $tbl->get_Item(0, 0)->getCellFormat();
    $cellFormat::getFillFormat()->setFillType(FillType::Picture);
    $cellFormat::getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    $cellFormat::getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # PPTX फ़ाइल को डिस्क पर सहेजता है
    $pres->save("Image_In_TableCell_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही सेल की अलग-अलग पक्षों के लिए अलग-अलग रेखा मोटाई और शैलियां सेट कर सकता हूँ?**

हाँ। [top](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/hi/php-java/aspose.slides/cellformat/getborderright/) बॉर्डर्स के अलग-अलग प्रॉपर्टी हैं, इसलिए प्रत्येक पक्ष की मोटाई और शैली अलग हो सकती है। यह लेख में दर्शाए गए सेल के प्रति-पक्ष बॉर्डर नियंत्रण से तर्कसंगत रूप से मेल खाता है।

**यदि मैं सेल के पृष्ठभूमि के रूप में एक चित्र सेट करने के बाद कॉलम/रो का आकार बदलूँ तो छवि के साथ क्या होता है?**

यह व्यवहार [fill mode](https://reference.aspose.com/slides/hi/php-java/aspose.slides/picturefillmode/) (stretch/tile) पर निर्भर करता है। स्ट्रेचिंग के साथ, छवि नए सेल के अनुसार समायोजित होती है; टाइलिंग के साथ, टाइलों की पुनर्गणना होती है। लेख में सेल में छवि डिस्प्ले मोड्स का उल्लेख किया गया है।

**क्या मैं सेल की सभी सामग्री को एक हाइपरलिंक असाइन कर सकता हूँ?**

[Hyperlinks](/slides/hi/php-java/manage-hyperlinks/) को सेल के टेक्स्ट फ्रेम के भीतर टेक्स्ट (portion) स्तर पर या पूरी टेबल/shape स्तर पर सेट किया जाता है। व्यवहार में, आप लिंक को किसी हिस्से या सेल की पूरी टेक्स्ट पर असाइन करते हैं।

**क्या मैं एक ही सेल के भीतर विभिन्न फ़ॉन्ट सेट कर सकता हूँ?**

हाँ। एक सेल के टेक्स्ट फ्रेम में [portions](https://reference.aspose.com/slides/hi/php-java/aspose.slides/portion/) (रन) समर्थन करता है जिसमें स्वतंत्र फ़ॉर्मेटिंग—फ़ॉन्ट फ़ैमिली, शैली, आकार और रंग होते हैं।