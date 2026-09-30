---
title: PHP का उपयोग करके प्रस्तुतियों में चार्ट लेजेंड को कस्टमाइज़ करें
linktitle: चार्ट लेजेंड
type: docs
url: /hi/php-java/chart-legend/
keywords:
- चार्ट लेजेंड
- लेजेंड स्थिति
- फ़ॉन्ट आकार
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ चार्ट लेजेंड को कस्टमाइज़ करके PowerPoint प्रस्तुतियों को अनुकूलित करें, विशेष लेजेंड फ़ॉर्मेटिंग के साथ।"
---
## **सारांश**

Aspose.Slides for PHP via Java PowerPoint प्रस्तुतियों में चार्ट लेजेंड को अनुकूलित करने के विकल्प प्रदान करता है। यह लेख लेजेंड को कैसे स्थित और आकार दिया जाए, पूरे लेजेंड के फ़ॉन्ट आकार को कैसे सेट किया जाए, एकल लेजेंड एंट्री को कैसे फ़ॉर्मेट किया जाए, और चयनित एंट्रीज़ को कैसे छिपाया या पुनर्स्थापित किया जाए, यह दर्शाता है।

FAQ संबंधित व्यवहारों को कवर करता है, जिसमें लेजेंड के लिए स्थान आरक्षित करना, मल्टीलाइन लेबल प्रदर्शित करना, और प्रस्तुति थीम से फ़ॉर्मेटिंग को विरासत में लेना शामिल है।

## **लेजेंड की स्थिति निर्धारित करना**

लेजेंड की स्थिति और आकार को चार्ट के आयामों के अंश के रूप में निर्दिष्ट करने के लिए लेजेंड के [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), और [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) मेथड्स का उपयोग करें।

यह उदाहरण एक प्रेजेंटेशन बनाता है और पहली स्लाइड में डिफ़ॉल्ट डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट जोड़ता है। वांछित लेजेंड ऑफ़सेट और आयामों को चार्ट की चौड़ाई और ऊँचाई से विभाजित करने पर वे सापेक्ष मानों में बदल जाते हैं: लेजेंड चार्ट के शीर्ष-बाएँ कोने से 50 पॉइंट्स की दूरी पर स्थित है और इसका आकार 100 बाय 100 पॉइंट्स है। यह उदाहरण java_values का उपयोग करके PHP/Java ब्रिज द्वारा लौटाए गए चार्ट आयामों को विभाजन से पहले PHP संख्याओं में परिवर्तित करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // चार्ट के सापेक्ष लेजेंड की स्थिति और आकार को व्यक्त करें।
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **लेजेंड का फ़ॉन्ट आकार सेट करना**

लेजेंड के टेक्स्ट फ़ॉर्मेट तक पहुँचने के लिए लेजेंड का [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) प्रयोग करें और पॉइंट्स में फ़ॉन्ट आकार सेट करने के लिए [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) का उपयोग करें।

यह उदाहरण डिफ़ॉल्ट डेटा के साथ एक चार्ट बनाता है और लेजेंड टेक्स्ट को 20 पॉइंट्स पर सेट करता है। यह वर्टिकल एक्सिस के लिए ऑटोमैटिक बाउंड्स को भी बंद करता है और इसकी रेंज -5 से 10 तक सेट करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एकल लेजेंड एंट्री का फ़ॉन्ट आकार सेट करना**

लेजेंड के [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) मेथड द्वारा लौटाई गई कलेक्शन का उपयोग करके आप किसी विशिष्ट एंट्री के फ़ॉर्मेटिंग तक पहुँच सकते हैं। एंट्री इंडेक्स शून्य-आधारित होते हैं, इसलिए इंडेक्स `1` दूसरी एंट्री को दर्शाता है।

यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है जिसमें डिफ़ॉल्ट डेटा में कम से कम दो सीरीज शामिल हैं। यह दूसरी लेजेंड एंट्री को बोल्ड, इटैलिक और 20 पॉइंट्स नीले टेक्स्ट के साथ फ़ॉर्मेट करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **एकल लेजेंड एंट्री को छिपाएँ**

एक सहायक सीरीज़ को लेजेंड से बाहर करने के लिए, जबकि उसका डेटा दिखाई देता रहे, [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) को `true` के साथ, [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/) के माध्यम से कॉल करें। यह केवल चयनित लेजेंड एंट्री को छिपाता है; यह सीरीज़ या उसके डेटा पॉइंट्स को नहीं हटाता। इसके विपरीत, [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) को `false` के साथ कॉल करने से पूरे लेजेंड को छिपा दिया जाता है।

नीचे का उदाहरण डिफ़ॉल्ट डेटा के साथ कई सीरीज़ वाला एक क्लस्टर्ड कॉलम चार्ट बनाता है। यह दूसरी सीरीज़ की लेजेंड एंट्री (इंडेक्स `1`) को छिपाता है और प्रेजेंटेशन को सहेजता है। फिर [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) को `false` के साथ कॉल करके एंट्री को पुनर्स्थापित करता है और दूसरी कॉपी सहेजता है। दोनों फ़ाइलों में कॉलम दृश्यमान रहते हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // चार्ट डेटा को बदले बिना उसी एंट्री को पुनर्स्थापित करें।
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

नीचे का तुलनात्मक चित्र समान चार्ट को सभी एंट्रीज़ दृश्यमान तथा दूसरी एंट्री छिपी हुई दिखाता है। दूसरी सीरीज़ के कॉलम अपरिवर्तित रहते हैं।

![सभी लेजेंड एंट्रीज़ दृश्यमान और लेजेंड से सीरीज़ 2 छिपी हुई चार्ट की तुलना; सभी कॉलम दृश्यमान रहते हैं.](hide-legend-entry.png)

कॉलम, बार और लाइन चार्ट में, लेजेंड एंट्रीज़ सीरीज़ की पहचान करती हैं। पाई चार्ट में, वे व्यक्तिगत डेटा पॉइंट्स (स्लाइस) की पहचान करती हैं, इसलिए चयनित स्लाइस पर [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) का उपयोग करें। API इस डेटा-पॉइंट मेथड को `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, और `BarOfPie` चार्ट प्रकारों के लिए दस्तावेज़ित करता है। यह मानना नहीं चाहिए कि यह डोनट चार्ट पर लागू होता है, जो इस सूची में शामिल नहीं हैं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं चार्ट को लेजेंड के लिए जगह अलग से आरक्षित करने (ओवरले करने के बजाय) सकता हूँ?**  
हाँ। लेजेंड को प्लॉट एरिया के ऊपर ओवरले करने के बजाय जगह आरक्षित करने के लिए [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) को `false` के साथ कॉल करें।

**क्या मैं मल्टीलाइन लेजेंड लेबल बना सकता हूँ?**  
हाँ। जब उपलब्ध चौड़ाई पर्याप्त नहीं होती है तो लंबी लेबल्स रैप हो सकती हैं। आप लाइन ब्रेक के लिए सीरीज़ नामों में न्यूलाइन कैरेक्टर का भी उपयोग कर सकते हैं।

**मैं लेजेंड को प्रस्तुति थीम की रंग योजना के अनुसार कैसे बना सकता हूँ?**  
लेजेंड के रंग, भराव और फ़ॉन्ट को अनसेट रखें ताकि वह थीम फ़ॉर्मेटिंग को इनहेरिट कर सके। स्पष्ट फ़ॉर्मेटिंग थीम सेटिंग्स को ओवरराइड कर देती है।