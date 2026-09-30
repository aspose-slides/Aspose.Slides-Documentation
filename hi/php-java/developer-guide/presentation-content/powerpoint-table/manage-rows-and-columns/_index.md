---
title: PowerPoint तालिकाओं में PHP का उपयोग करके पंक्तियों और स्तंभों का प्रबंधन
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
- पंक्ति टेक्स्ट स्वरूपण
- स्तंभ टेक्स्ट स्वरूपण
- तालिका शैली
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint में तालिका पंक्तियों और स्तंभों का प्रबंधन करें और प्रस्तुति संपादन व डेटा अपडेट को तेज़ करें।"
---
## **परिचय**

Aspose.Slides for PHP via Java आपको PowerPoint प्रस्तुतियों में तालिका की संरचना और स्वरूपण को [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/) क्लास के माध्यम से प्रबंधित करने देता है। आप हेडर पंक्ति निर्धारित कर सकते हैं, पंक्तियों और स्तंभों को क्लोन या हटा सकते हैं, और पूरी पंक्ति या स्तंभ पर टेक्स्ट फ़ॉर्मेटिंग लागू कर सकते हैं।

यह लेख इन ऑपरेशनों को PHP उदाहरणों के साथ समझाता है। यह दिखाता है कि तालिका की शैली प्रीसेट को कैसे प्राप्त करें ताकि आप उसे पुनः उपयोग कर सकें। तालिका की पंक्ति और स्तंभ अनुक्रमण शून्य‑आधारित होते हैं।

## **पंक्ति की ऊँचाई नियंत्रित करें**

[Row::setMinimalHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/setminimalheight/) का उपयोग करके पंक्ति की न्यूनतम ऊँचाई को पॉइंट में सेट करें। यह एक निचली सीमा है, स्थिर ऊँचाई नहीं। [Row::getHeight](https://reference.aspose.com/slides/php-java/aspose.slides/row/getheight/) वास्तविक ऊँचाई लौटाता है। पंक्ति तक पहुँचने के लिए [Table::getRows](https://reference.aspose.com/slides/php-java/aspose.slides/table/getrows/) का प्रयोग करें।

यह उदाहरण [row-height-input.pptx](row-height-input.pptx) लोड करता है, जिसमें पहली स्लाइड की पहली आकृति एक तालिका है। उसकी पहली पंक्ति 70 पॉइंट से शुरू होती है। कोशिकाएँ 18‑पॉइंट Arial टेक्स्ट, रैपिंग, और 6‑पॉइंट ऊपर‑नीचे मार्जिन का उपयोग करती हैं; दूसरे स्तंभ में लंबा टेक्स्ट कई लाइनों में रैप होता है। उदाहरण न्यूनतम को 100 पॉइंट तक बढ़ाता है, फिर 20 पॉइंट तक घटाता है, प्रत्येक परिवर्तन के बाद वास्तविक ऊँचाई प्रिंट करता है, और दोनों परिणाम सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("row-height-input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $row = $table->getRows()->get_Item(0);

    $row->setMinimalHeight(100);
    printf("Increased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-increased.pptx", SaveFormat::Pptx);

    $row->setMinimalHeight(20);
    printf("Decreased: minimum = %.1f, actual = %.1f pt\n", java_values($row->getMinimalHeight()), java_values($row->getHeight()));
    $presentation->save("row-height-decreased.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

प्रदान की गई प्रस्तुति के साथ, न्यूनतम बढ़ाने से पंक्ति में जगह जोड़ती है। उसे घटाने से अतिरिक्त जगह हटती है, लेकिन वास्तविक ऊँचाई 20 पॉइंट से अधिक बनी रहती है क्योंकि टेक्स्ट और कोशिका मार्जिन को अधिक जगह चाहिए। केवल न्यूनतम को घटाने से पंक्ति को उसकी सामग्री द्वारा आवश्यक जगह से नीचे नहीं धकेला जा सकता।

वास्तविक ऊँचाई को प्रभावित करने वाले कई कारक हैं:

- **टेक्स्ट और फ़ॉन्ट आकार:** लंबा टेक्स्ट, स्पष्ट लाइन ब्रेक, या बड़ा फ़ॉन्ट अधिक ऊर्ध्वाधर जगह ले सकता है।
- **रैपिंग और स्तंभ चौड़ाई:** रैपिंग सक्षम होने पर, [Column::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/column/setwidth/) से स्तंभ की चौड़ाई घटाने से अधिक लाइने बन सकती हैं। चौड़ी स्तंभ ऊर्ध्वाधर जगह को कम कर सकती है।
- **कोशिका मार्जिन:** [Cell::setMarginTop](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmargintop/) और [Cell::setMarginBottom](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginbottom/) ऊर्ध्वाधर जगह जोड़ते हैं। [Cell::setMarginLeft](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginleft/) और [Cell::setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/cell/setmarginright/) टेक्स्ट के लिए उपलब्ध चौड़ाई घटाते हैं और अतिरिक्त रैपिंग का कारण बन सकते हैं।

इस तालिका में बिना मर्ज किए हुए कोशिकाओं के लिए, वह कोशिका जो सबसे अधिक ऊर्ध्वाधर जगह लेती है, पूरी पंक्ति की सामग्री‑आधारित निचली सीमा निर्धारित करती है। पंक्ति को छोटा करने के लिए आपको टेक्स्ट को छोटा करना, फ़ॉन्ट आकार या मार्जिन घटाना, या स्तंभ को चौड़ा करना पड़ सकता है।

नीचे की छवियाँ समान तालिका को समान स्केल पर दिखाती हैं। चित्रित परिणामों में वास्तविक ऊँचाइयाँ 70, 100, और 55.2 पॉइंट थीं: अंतिम पंक्ति अपने 20‑पॉइंट न्यूनतम से अधिक ऊँची रही। सटीक टेक्स्ट माप आपके पर्यावरण में उपलब्ध फ़ॉन्ट पर निर्भर कर सकते हैं। सहेजी गई परिणाम डाउनलोड करें: [increased minimum](row-height-increased.pptx) और [decreased minimum](row-height-decreased.pptx).

| मूल: न्यूनतम 70 pt, वास्तविक 70 pt | बढ़ाया: न्यूनतम 100 pt, वास्तविक 100 pt | घटाया: न्यूनतम 20 pt, वास्तविक 55.2 pt |
| --- | --- | --- |
| ![मूल तालिका जिसमें पहली पंक्ति 70‑पॉइंट है।](row-height-before.png) | ![पहली पंक्ति का न्यूनतम 100 पॉइंट करने के बाद तालिका।](row-height-increased.png) | ![पहली पंक्ति का न्यूनतम 20 पॉइंट करने के बाद तालिका; रैप्ड टेक्स्ट पंक्ति को न्यूनतम से अधिक ऊँचा रखता है।](row-height-decreased.png) |

## **पहली पंक्ति को हेडर के रूप में सेट करें**

[setFirstRow](https://reference.aspose.com/slides/php-java/aspose.slides/table/setfirstrow/) मेथड का उपयोग करके पहली पंक्ति को हेडर फ़ॉर्मेटिंग के लिए चिह्नित करें। इसका स्वरूप तालिका पर लागू शैली पर निर्भर करता है।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्लाइड पर पहली आकृति के रूप में संग्रहीत तालिका तक पहुँचें।
4. उसकी पहली पंक्ति के लिए हेडर फ़ॉर्मेटिंग सक्षम करें।
5. संशोधित प्रस्तुति सहेजें।

उदाहरण को `table.pptx` चाहिए जिसमें पहली स्लाइड की पहली आकृति एक तालिका है। यह पहली पंक्ति के लिए हेडर फ़ॉर्मेटिंग सक्षम करता है और `First_row_header.pptx` सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $table->setFirstRow(true);

    $presentation->save("First_row_header.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका की पंक्ति या स्तंभ को क्लोन करें**

पंक्तियों या स्तंभों को क्लोन करके उनकी सामग्री और स्वरूपण को पुनः उपयोग करें। आप एक प्रति को तालिका के अंत में जोड़ सकते हैं या विशिष्ट स्थिति में सम्मिलित कर सकते हैं।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) मेथड से तालिका जोड़ें।
5. आवश्यक पंक्तियों को क्लोन करें।
6. आवश्यक स्तंभों को क्लोन करें।
7. संशोधित प्रस्तुति सहेजें।

उदाहरण को `Test.pptx` चाहिए जिसमें कम से कम एक स्लाइड हो। यह तीन स्तंभ और पाँच पंक्तियों वाली तालिका बनाता है, आकार पॉइंट में निर्दिष्ट होते हैं। यह पहली पंक्ति और स्तंभ की प्रतियां जोड़ता है, फिर दो‑तीसरी पंक्ति और स्तंभ की प्रतियां निर्देशांक 3 (चौथा स्थान) पर सम्मिलित करता है। परिणामस्वरूप तालिका में सात पंक्तियाँ और पाँच स्तंभ होते हैं। `false` तर्क निकटवर्ती मर्ज किए गए पंक्तियों या स्तंभों में क्लोनिंग को निष्क्रिय करता है; इस तालिका में कोई मर्ज किए गए कोशिकाएँ नहीं हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [50, 50, 50];
    $rowHeights = [50, 30, 30, 30, 30];
    $table = $slide->getShapes()->addTable(100, 50, $columnWidths, $rowHeights);

    $table->get_Item(0, 0)->getTextFrame()->setText("Row 1 Cell 1");
    $table->get_Item(1, 0)->getTextFrame()->setText("Row 1 Cell 2");
    $table->getRows()->addClone($table->getRows()->get_Item(0), false);

    $table->get_Item(0, 1)->getTextFrame()->setText("Row 2 Cell 1");
    $table->get_Item(1, 1)->getTextFrame()->setText("Row 2 Cell 2");
    $table->getRows()->insertClone(3, $table->getRows()->get_Item(1), false);

    $table->getColumns()->addClone($table->getColumns()->get_Item(0), false);
    $table->getColumns()->insertClone(3, $table->getColumns()->get_Item(1), false);

    $presentation->save("table_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका से पंक्ति या स्तंभ हटाएँ**

तालिका में अब आवश्यक नहीं रहने वाली पंक्तियों या स्तंभों को हटाएँ। एक आइटम हटाने से उसके बाद आने वाली पंक्तियों या स्तंभों के अनुक्रमण शिफ्ट हो जाते हैं।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास से नई प्रस्तुति बनाएं।
2. पहली स्लाइड तक पहुँचें।
3. स्तंभ चौड़ाइयाँ और पंक्ति ऊँचाइयाँ निर्धारित करें।
4. [addTable](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addtable/) मेथड से तालिका जोड़ें।
5. दूसरी पंक्ति और दूसरा स्तंभ हटाएँ।
6. संशोधित प्रस्तुति सहेजें।

यह उदाहरण तीन‑बाय‑तीन तालिका बनाता है और अनुक्रमण 1 पर पंक्ति और स्तंभ हटाता है, जिससे `TestTable_out.pptx` में दो‑बाय‑दो तालिका बचती है। आकार पॉइंट में हैं। `false` तर्क निकटवर्ती मर्ज किए गए पंक्तियों या स्तंभों की हटाने को निष्क्रिय करता है; इस तालिका में कोई मर्ज किए गए कोशिकाएँ नहीं हैं।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 50, 30];
    $rowHeights = [30, 50, 30];
    $table = $slide->getShapes()->addTable(100, 100, $columnWidths, $rowHeights);

    $table->getRows()->removeAt(1, false);
    $table->getColumns()->removeAt(1, false);

    $presentation->save("TestTable_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका पंक्ति स्तर पर टेक्स्ट स्वरूपण सेट करें**

पूरी पंक्ति पर टेक्स्ट स्वरूपण लागू करें ताकि उसकी सभी कोशिकाएँ समान रहें। आप फ़ॉन्ट गुण, पैराग्राफ स्वरूपण, और टेक्स्ट दिशा सेट कर सकते हैं बिना प्रत्येक कोशिका को अलग‑अलग फ़ॉर्मेट किए।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहली पंक्ति के लिए [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) का उपयोग करें।
4. पहली पंक्ति के लिए [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) और [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) का उपयोग करें।
5. दूसरी पंक्ति के लिए [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) का प्रयोग करें।
6. संशोधित प्रस्तुति सहेजें।

उदाहरण को `table.pptx` चाहिए जिसमें पहली स्लाइड की पहली आकृति एक तालिका हो और कम से कम दो पंक्तियाँ हों। यह पहली पंक्ति पर 25‑पॉइंट टेक्स्ट, दाएँ संरेखण, और 20‑पॉइंट दाईं पैराग्राफ मार्जिन लागू करता है, फिर दूसरी पंक्ति में वर्टिकल टेक्स्ट सेट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getRows()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getRows()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getRows()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("row_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका स्तंभ स्तर पर टेक्स्ट स्वरूपण सेट करें**

पूरे स्तंभ पर टेक्स्ट स्वरूपण लागू करें ताकि उसकी सभी कोशिकाएँ समान रहें। आप फ़ॉन्ट गुण, पैराग्राफ स्वरूपण, और टेक्स्ट दिशा सेट कर सकते हैं बिना प्रत्येक कोशिका को अलग‑अलग फ़ॉर्मेट किए।

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें।
2. पहली स्लाइड पर तालिका तक पहुँचें।
3. पहले स्तंभ के लिए [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) का उपयोग करें।
4. पहले स्तंभ के लिए [setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setalignment/) और [setMarginRight](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/setmarginright/) का उपयोग करें।
5. दूसरे स्तंभ के लिए [setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/settextverticaltype/) का प्रयोग करें।
6. संशोधित प्रस्तुति सहेजें।

उदाहरण को `table.pptx` चाहिए जिसमें पहली स्लाइड की पहली आकृति एक तालिका हो और कम से कम दो स्तंभ हों। यह पहले स्तंभ पर 25‑पॉइंट टेक्स्ट, दाएँ संरेखण, और 20‑पॉइंट दाईं पैराग्राफ मार्जिन लागू करता है, फिर दूसरे स्तंभ में वर्टिकल टेक्स्ट सेट करता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\PortionFormat;
use aspose\slides\ParagraphFormat;
use aspose\slides\TextFrameFormat;
use aspose\slides\TextAlignment;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("table.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);

    $portionFormat = new PortionFormat();
    $portionFormat->setFontHeight(25);
    $table->getColumns()->get_Item(0)->setTextFormat($portionFormat);

    $paragraphFormat = new ParagraphFormat();
    $paragraphFormat->setAlignment(TextAlignment::Right);
    $paragraphFormat->setMarginRight(20);
    $table->getColumns()->get_Item(0)->setTextFormat($paragraphFormat);

    $textFrameFormat = new TextFrameFormat();
    $textFrameFormat->setTextVerticalType(TextVerticalType::Vertical);
    $table->getColumns()->get_Item(1)->setTextFormat($textFrameFormat);

    $presentation->save("column_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **तालिका शैली गुण प्राप्त करें**

[getStylePreset](https://reference.aspose.com/slides/php-java/aspose.slides/table/getstylepreset/) मेथड का उपयोग करके तालिका पर लागू प्रीसेट प्राप्त करें और उसे दूसरी तालिका पर पुनः उपयोग करें। यह व्यक्तिगत कोशिका फ़ॉर्मेट ओवरराइड की बजाय प्रीसेट को पहचानता है।

उदाहरण एक तालिका बनाता है, [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/php-java/aspose.slides/tablestylepreset/#DarkStyle1) लागू करता है, और प्रीसेट को वापस पढ़ता है। यह `DarkStyle1` के अनुरूप पूर्णांक मान प्रिंट करता है और तालिका को `table.pptx` में सहेजता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TableStylePreset;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $columnWidths = [100, 150];
    $rowHeights = [5, 5, 5];
    $table = $slide->getShapes()->addTable(10, 10, $columnWidths, $rowHeights);
    $table->setStylePreset(TableStylePreset::DarkStyle1);

    $stylePreset = $table->getStylePreset();
    echo java_values($stylePreset) . PHP_EOL;

    $presentation->save("table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पहले से बनी तालिका पर PowerPoint थीम/शैलियाँ लागू कर सकता हूँ?**

हां। तालिका स्लाइड/लेआउट/मास्टर थीम को विरासत में प्राप्त करती है, और आप फिर भी फील, बॉर्डर और टेक्स्ट रंग को उस थीम के ऊपर ओवरराइड कर सकते हैं।

**क्या मैं Excel की तरह तालिका पंक्तियों को सॉर्ट कर सकता हूँ?**

नहीं, Aspose.Slides तालिकाओं में अंतर्निहित सॉर्टिंग या फ़िल्टर नहीं होते। पहले डेटा को मेमोरी में सॉर्ट करें, फिर उसी क्रम में तालिका पंक्तियों को पुनः भरें।

**क्या मैं बैंडेड (धारीदार) स्तंभ रख सकते हैं और साथ ही विशिष्ट कोशिकाओं के लिए कस्टम रंग रख सकते हैं?**

हां। बैंडेड स्तंभ सक्षम करें, फिर विशिष्ट कोशिकाओं को स्थानीय फ़ॉर्मेटिंग से ओवरराइड करें; कोशिका‑स्तर का फ़ॉर्मेटिंग तालिका शैली पर प्राथमिकता लेता है।