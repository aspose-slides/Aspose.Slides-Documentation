---
title: PHP का उपयोग करके PowerPoint तालिकाओं में पंक्तियों और स्तंभों का प्रबंधन
linktitle: पंक्तियाँ और स्तंभ
type: docs
weight: 20
url: /hi/php-java/manage-rows-and-columns/
keywords:
- तालिका पंक्ति
- तालिका स्तंभ
- पहली पंक्ति
- तालिका हेडर
- पंक्ति क्लोन
- स्तंभ क्लोन
- पंक्ति कॉपी
- स्तंभ कॉपी
- पंक्ति हटाएँ
- स्तंभ हटाएँ
- पंक्ति टेक्स्ट फ़ॉर्मेटिंग
- स्तंभ टेक्स्ट फ़ॉर्मेटिंग
- तालिका शैली
- PowerPoint
- प्रस्तुतीकरण
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP के माध्यम से Java के साथ PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुतीकरण संपादन व डेटा अपडेट को तेज़ बनाएं।"
---
## **परिचय**

PowerPoint प्रस्तुति में तालिका की पंक्तियों और स्तंभों को प्रबंधित करने के लिए, Aspose.Slides [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/table/) क्लास और कई अन्य प्रकार प्रदान करता है।

## **पहली पंक्ति को हेडर के रूप में सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं और प्रस्तुति लोड करें।  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट बनाएं और इसे null सेट करें।  
4. सभी [Shape](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shape/) ऑब्जेक्ट्स में इटरेट करके संबंधित तालिका खोजें।  
5. तालिका की पहली पंक्ति को उसके हेडर के रूप में सेट करें।  

यह PHP कोड दिखाता है कि तालिका की पहली पंक्ति को हेडर कैसे सेट करें:

```php
  # Presentation क्लास का इंस्टैंस बनाता है
    # पहले स्लाइड तक पहुँचता है
    # null TableEx को प्रारंभ करता है
    # शेप्स के माध्यम से इटरेट करता है और तालिका का रेफ़रेंस सेट करता है
        # तालिका की पहली पंक्ति को हेडर के रूप में सेट करता है
    # प्रस्तुति को डिस्क में सहेजता है
    $pres = new Presentation("table.pptx");
    try {
      $sld = $pres->getSlides()->get_Item(0);
      $tbl = null;
      foreach($sld->getShapes() as $shp) {
        if (java_instanceof($shp, new JavaClass("com.aspose.slides.Table"))) {
          $tbl = $shp;
          $tbl->setFirstRow(true);
        }
      }
      $pres->save("pres.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
```

## **तालिका की पंक्ति या कॉलम को क्लोन करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `columnWidth` की एरे परिभाषित करें।  
4. `rowHeight` की एरे परिभाषित करें।  
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addtable/) मेथड के माध्यम से एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।  
6. तालिका की पंक्ति को क्लोन करें।  
7. तालिका के कॉलम को क्लोन करें।  
8. संशोधित प्रस्तुति को सहेजें।  

यह PHP कोड दिखाता है कि PowerPoint तालिका की पंक्ति या कॉलम को क्लोन कैसे करें:

```php
  # Presentation क्लास का इंस्टैंस बनाता है
  $pres = new Presentation("Test.pptx");
  try {
    # पहले स्लाइड तक पहुंचता है
    $sld = $pres->getSlides()->get_Item(0);
    # स्तंभों को चौड़ाई और पंक्तियों को ऊँचाई के साथ परिभाषित करता है
    $dblCols = array(50, 50, 50 );
    $dblRows = array(50, 30, 30, 30, 30 );
    # स्लाइड में टेबल आकार जोड़ता है
    $table = $sld->getShapes()->addTable(100, 50, $dblCols, $dblRows);
    # पंक्ति 1 के सेल 1 में कुछ टेक्स्ट जोड़ता है
    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    # पंक्ति 1 के सेल 2 में कुछ टेक्स्ट जोड़ता है
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    # टेबल के अंत में पंक्ति 1 को क्लोन करता है
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);
    # पंक्ति 2 के सेल 1 में कुछ टेक्स्ट जोड़ता है
    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    # पंक्ति 2 के सेल 2 में कुछ टेक्स्ट जोड़ता है
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    # टेबल की 4थी पंक्ति के रूप में पंक्ति 2 को क्लोन करता है
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);
    # अंत में पहले कॉलम को क्लोन करता है
    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    # 4थी कॉलम इंडेक्स पर दूसरा कॉलम क्लोन करता है
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("table_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका से पंक्ति या कॉलम हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. `columnWidth` की एरे परिभाषित करें।  
4. `rowHeight` की एरे परिभाषित करें।  
5. स्लाइड में [addTable](https://reference.aspose.com/slides/hi/php-java/aspose.slides/shapecollection/addtable/) मेथड के माध्यम से एक [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट जोड़ें।  
6. तालिका की पंक्ति को हटाएँ।  
7. तालिका के कॉलम को हटाएँ।  
8. संशोधित प्रस्तुति को सहेजें।  

यह PHP कोड दिखाता है कि तालिका से पंक्ति या कॉलम कैसे हटाएँ:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $colWidth = array(100, 50, 30 );
    $rowHeight = array(30, 50, 30 );
    $table = $slide->getShapes()->addTable(100, 100, $colWidth, $rowHeight);
    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);
    $pres->save("TestTable_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका पंक्ति स्तर पर टेक्स्ट फॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड से संबंधित [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट तक पहुंचें।  
4. पहली पंक्ति की कोशिकाओं का [setFontHeight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight) सेट करें।  
5. पहली पंक्ति की कोशिकाओं का [setAlignment(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setalignment/) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setmarginright/) सेट करें।  
6. दूसरी पंक्ति की कोशिकाओं का [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/settextverticaltype/) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह PHP कोड कार्रवाई को दर्शाता है।

```php
  # Presentation क्लास का एक इंस्टैंस बनाता है
  $pres = new Presentation();
  try {
    # मान लेते हैं कि पहली स्लाइड पर पहला आकार एक तालिका है
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # पहली पंक्ति की कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getRows()->get_Item(0)->setTextFormat($portionFormat);
    # पहली पंक्ति की कोशिकाओं का टेक्स्ट अलाइनमेंट और दायां मार्जिन सेट करता है
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getRows()->get_Item(0)->setTextFormat($paragraphFormat);
    # दूसरी पंक्ति की कोशिकाओं का टेक्स्ट वर्टिकल टाइप सेट करता है
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getRows()->get_Item(1)->setTextFormat($textFrameFormat);
    # प्रस्तुति को डिस्क पर सहेजता है
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका कॉलम स्तर पर टेक्स्ट फॉर्मेटिंग सेट करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/php-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं और प्रस्तुति लोड करें,  
2. इंडेक्स के माध्यम से स्लाइड का रेफ़रेंस प्राप्त करें।  
3. स्लाइड से संबंधित [Table](https://reference.aspose.com/slides/hi/php-java/aspose.slides/Table) ऑब्जेक्ट तक पहुंचें।  
4. पहले कॉलम की कोशिकाओं का [setFontHeight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/baseportionformat/#setFontHeight) सेट करें।  
5. पहले कॉलम की कोशिकाओं का [setAlignment(int value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setalignment/) और [setMarginRight(float value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/paragraphformat/setmarginright/) सेट करें।  
6. दूसरे कॉलम की कोशिकाओं का [setTextVerticalType(byte value)](https://reference.aspose.com/slides/hi/php-java/aspose.slides/textframeformat/settextverticaltype/) सेट करें।  
7. संशोधित प्रस्तुति को सहेजें।  

यह PHP कोड कार्रवाई को दर्शाता है:

```php
  # Presentation क्लास का एक इंस्टैंस बनाता है
  $pres = new Presentation();
  try {
    # मान लें कि पहली स्लाइड पर पहला आकार एक तालिका है
    $someTable = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    # पहले कॉलम की कोशिकाओं की फ़ॉन्ट ऊँचाई सेट करता है
    $portionFormat = new PortionFormat();
    $portionFormat::setFontHeight(25);
    $someTable->getColumns()->get_Item(0)->setTextFormat($portionFormat);
    # पहले कॉलम की कोशिकाओं का टेक्स्ट अलाइनमेंट और दायाँ मार्जिन एक ही कॉल में सेट करता है
    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat::setAlignment(TextAlignment->Right);
    $paragraphFormat::setMarginRight(20);
    $someTable->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);
    # दूसरे कॉलम की कोशिकाओं का टेक्स्ट वर्टिकल टाइप सेट करता है
    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat::setTextVerticalType(TextVerticalType::Vertical);
    $someTable->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);
    $pres->save("result.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **तालिका शैली गुण प्राप्त करें**

Aspose.Slides आपको तालिका की शैली गुणों को प्राप्त करने देता है ताकि आप उन विवरणों को किसी अन्य तालिका या कहीं और उपयोग कर सकें। यह PHP कोड दिखाता है कि तालिका प्रीसेट स्टाइल से शैली गुण कैसे प्राप्त करें:

```php
  $pres = new Presentation();
  try {
    $table = $pres->getSlides()->get_Item(0)->getShapes()->addTable(10, 10, array(100, 150 ), array(5, 5, 5 ));
    $table->setStylePreset(TableStylePreset->DarkStyle1);// डिफ़ॉल्ट स्टाइल प्रीसेट थीम को बदलें

    $pres->save("table.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनाई गई तालिका पर PowerPoint थीम/स्टाइल लागू कर सकता हूँ?**

हां। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप अभी भी उस थीम के ऊपर फ़िल, बॉर्डर और टेक्स्ट रंगों को ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका की पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में बिल्ट‑इन सॉर्टिंग या फ़िल्टर नहीं होते। पहले डेटा को मेमोरी में सॉर्ट करें, फिर उस क्रम में तालिका की पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (पट्टियों वाले) कॉलम रख सकते हुए विशिष्ट कोशिकाओं में कस्टम रंग रख सकता हूँ?**

हां। बैंडेड कॉलम सक्रिय करें, फिर विशिष्ट कोशिकाओं को स्थानीय फॉर्मेटिंग से ओवरराइड करें; कोशिका‑स्तर की फॉर्मेटिंग तालिका शैली पर प्राथमिकता लेती है।