---
title: PHP में प्रस्तुति चार्ट फ़ॉर्मेट करें
linktitle: चार्ट फ़ॉर्मेटिंग
type: docs
weight: 60
url: /hi/php-java/chart-formatting/
keywords:
- चार्ट फ़ॉर्मेट करें
- चार्ट फ़ॉर्मेटिंग
- चार्ट एंटिटी
- चार्ट प्रॉपर्टीज़
- चार्ट सेटिंग्स
- चार्ट विकल्प
- फ़ॉन्ट प्रॉपर्टीज़
- गोल बॉर्डर
- PowerPoint
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java में चार्ट फ़ॉर्मेटिंग सीखें और कस्टम अक्ष, फ़ॉन्ट, नंबर फ़ॉर्मेट तथा गोल चार्ट बॉर्डर के साथ अपनी PowerPoint प्रस्तुति को उन्नत बनाएं।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में चार्ट को फ़ॉर्मेट करने का तरीका समझाता है। यह अक्ष, ग्रिड रेखाएँ, शीर्षक, लीजेंड, प्लॉट एरिया और वॉल फ़िल्स जैसे महत्वपूर्ण चार्ट घटकों को अनुकूलित करके चार्ट डेटा की उपस्थिति और पठनीयता में सुधार करने का प्रदर्शन करता है।

यह भी दर्शाता है कि चार्ट टेक्स्ट के लिए फ़ॉन्ट गुण कैसे सेट करें, चार्ट डेटा पर प्रीसेट संख्यात्मक स्वरूप लागू करें, और चार्ट एरिया के लिए गोल कोने सक्षम करें। साथ मिलकर, ये उदाहरण दिखाते हैं कि प्रस्तुति में चार्ट की दृश्य शैली और डेटा प्रस्तुतिकरण दोनों को कैसे नियंत्रित किया जाए।

उपर चढ़ते और गिरते अंतराल पर अलग-अलग फ़िल और outlines के लिए, देखें [स्टॉक चार्ट उदाहरण](/slides/hi/php-java/create-chart/#create-stock-charts)।

## **चार्ट इकाइयों को फ़ॉर्मेट करें**

चार्ट शीर्षक, अक्ष, ग्रिड रेखाएँ, लीजेंड और प्लॉट एरिया को फ़ॉर्मेट करने के लिए [Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/) का उपयोग करें। यह उदाहरण मार्करों और डिफ़ॉल्ट डेटा के साथ एक लाइन चार्ट बनाता है, फिर उसके मान और श्रेणी अक्षों पर अलग-अलग टेक्स्ट और लाइन शैलियों को लागू करता है। फ़ॉन्ट आकार और लाइन चौड़ाई पॉइंट में निर्दिष्ट हैं; श्रेणी लेबल 45 डिग्री घुमा होते हैं।

वैल्यू एक्सिस [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat) का उपयोग स्रोत सेल्स से स्वतंत्र रूप से करता है। इसका स्केल -2 से 15 तक चलता है, बड़े अंतराल 2 और छोटे अंतराल 0.5 हैं। उदाहरण प्रतिशत फ़ॉर्मेटिंग को [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit) को हज़ार पर सेट के साथ भी जोड़ता है, इसलिए इन सेटिंग्स को अपने डेटा के अर्थ और मात्रा के अनुसार अनुकूलित करें। लीजेंड प्लॉट एरिया के बाहर रहता है क्योंकि [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay) को `false` के साथ बुलाया जाता है। बैक-वॉल और फर्श के फ़िल्स [getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall) और [getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor) के माध्यम से कॉन्फ़िगर किए जाते हैं, लेकिन ये सतहें केवल 3D चार्ट में ही दिखाई देती हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **चार्ट के लिए फ़ॉन्ट गुण सेट करें**

चार्ट टेक्स्ट के लिए डिफ़ॉल्ट फ़ॉन्ट आकार को [Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat) के माध्यम से सेट करें। यह उदाहरण 20 पॉइंट फ़ॉन्ट के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और पहले सीरीज़ के लिए मान लेबल को [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) के माध्यम से सक्षम करता है। अपने स्वयं के स्पष्ट फ़ॉन्ट सेटिंग वाले टेक्स्ट तत्व चार्ट के डिफ़ॉल्ट को ओवरराइड कर सकते हैं।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **चार्ट लीजेंड के लिए टेक्स्ट फ्रेम फ़ॉर्मेटिंग को पुन: उपयोग करें**

लीजेंड को स्लाइड शीर्षक से मिलाने के लिए, पहले पैराग्राफ में [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से शीर्षक का फ़ॉन्ट सेट करें। लीजेंड के [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat) द्वारा लौटाए गए फ़ॉर्मेट पर [copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom) को कॉल करें। यह टेक्स्ट फ्रेम सेटिंग्स, पहले पैराग्राफ का फ़ॉर्मेट, और उस पैराग्राफ के डिफ़ॉल्ट फ़ॉन्ट गुणों को कॉपी करता है। व्यक्तिगत हिस्सों या बाद के पैराग्राफ़ पर सीधे लागू किया गया फ़ॉर्मेट स्रोत के स्थानीय रहता है।

उदाहरण में नेवी रंग में बोल्ड, 26 पॉइंट कैलिब्री शीर्षक को टेम्पलेट के रूप में उपयोग किया गया है। लीजेंड को शैलीबद्ध करने के बाद, यह [copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo) को कॉल करता है ताकि वही फ़ॉर्मेटिंग एक अलग कैप्शन पर लागू हो सके।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

सेव किए गए प्रस्तुतीकरण में, लीजेंड और कैप्शन आकार, वजन और रंग में शीर्षक से मेल खाते हैं। लीजेंड अभी भी सीरीज़ नाम दिखाता है, और कैप्शन अपना स्वयं का टेक्स्ट रखता है। यदि कैप्शन में कोई भाग पहले से स्पष्ट फ़ॉन्ट आकार रखता है, तो वह आकार कॉपी किए गए पैराग्राफ डिफ़ॉल्ट पर प्राथमिकता लेता है।

| कॉपी करने से पहले | कॉपी करने के बाद |
| --- | --- |
| ![त्रैमासिक बिक्री चार्ट जिसमें नियमित काले लीजेंड लेबल और काली कैप्शन है](legend-formatting-before.png) | ![एक ही चार्ट जिसमें बड़े, बोल्ड नेवी लीजेंड लेबल और मिलती-जुलती कैप्शन है](legend-formatting.png) |

## **संख्यात्मक स्वरूप सेट करें**

चार्ट वर्कबुक सेल्स पर बिल्ट‑इन नंबर फ़ॉर्मेट लागू करने के लिए [ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat) का उपयोग करें। यह उदाहरण डिफ़ॉल्ट, सेल‑बैक्ड डेटा के साथ एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रत्येक सीरीज़ वैल्यू सेल पर फ़ॉर्मेट इंडेक्स 10 (`0.00%`) लागू करता है। यह वर्कबुक में मानों को दर्शाने के तरीके को बदलता है बिना मूल संख्याओं को बदले; उदाहरण के लिए, 0.25 को 25.00% के रूप में दिखाया जाता है। अक्ष और डेटा‑लेबल फ़ॉर्मेट को अलग‑अलग कॉन्फ़िगर किया जा सकता है।

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

निम्न तालिका में अंग्रेज़ी (संयुक्त राज्य) लोकेल के लिए प्रतिनिधिक Excel फ़ॉर्मेट्स के साथ बिल्ट‑इन नंबर फ़ॉर्मेट इंडेसेज़ listed हैं। सटीक फ़ॉर्मेट स्ट्रिंग्स और उनका प्रदर्शन एप्लिकेशन और लोकेल के अनुसार बदल सकता है, विशेष रूप से मुद्रा और तिथियों के लिए। कुछ Excel फ़ॉर्मेट्स OOXML मानक में डिफ़ॉल्ट से भी अलग होते हैं, जैसा कि [Microsoft के नंबर फ़ॉर्मेट इम्प्लीमेंटेशन नोट्स](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) में वर्णित है।

| सूचकांक | फ़ॉर्मेट |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **चार्ट एरिया के गोल किनारे सेट करें**

[Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners) को `true` के साथ कॉल करके चार्ट एरिया के कोनों को गोल करें। यह उदाहरण एक क्लस्टर्ड कॉलम चार्ट बनाता है और प्रस्तुति सहेजने से पहले उसकी आउटलाइन को ठोस ग्रे रंग और सिंगल‑लाइन शैली देने के लिए [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) का उपयोग करता है।

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **मौजूदा चार्ट एनोटेशन संपादित करें**

एक चार्ट में कस्टम शेप्स हो सकते हैं, जैसे रिपोर्ट की स्थिति बताने वाला टेक्स्ट एनोटेशन। इन शेप्स तक पहुंचने के लिए आप [Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes) का उपयोग कर सकते हैं। [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) द्वारा लौटाए गए संग्रह में चार्ट‑स्वामित्व वाले शेप्स होते हैं।

एक सामान्य टेक्स्ट बॉक्स जो चार्ट के ऊपर रखा जाता है, स्लाइड का हिस्सा होता है, भले ही वह चार्ट का भाग जैसा दिखे। [Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) पर इटररेट करने से चार्ट और सामान्य स्लाइड शेप्स मिलते हैं, लेकिन चार्ट के भीतर के व्यक्तिगत शेप्स को नहीं गिना जाता। चार्ट शीर्षक और डेटा लेबल अलग-अलग चार्ट तत्व हैं, इस संग्रह में कस्टम एनोटेशन नहीं हैं।

डाउनलोड करें [chart-annotations.pptx](chart-annotations.pptx) और इसे एप्लिकेशन की कार्य निर्देशिका में रखें। इसकी पहली स्लाइड में एक चार्ट है जिसमें अनग्रुप्ड एनोटेशन "Preliminary results" (प्रारंभिक परिणाम) पढ़ता है, एक चार्ट‑स्वामित्व वाली लाइन, और एक सामान्य स्लाइड टेक्स्ट बॉक्स "Slide overlay" (स्लाइड ओवरले) पढ़ता है। उदाहरण उस स्लाइड पर पहला चार्ट खोजता है और रिपोर्ट प्रकाशित करने के लिए तैयार होने पर एनोटेशन को "Final results" (अंतिम परिणाम) में बदलता है। यह खाली संग्रह की जाँच करता है और केवल उन [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) को संपादित करता है जिनके पास नॉन‑नल टेक्स्ट फ्रेम है, जो [getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame) द्वारा लौटाया गया है और अपेक्षित टेक्स्ट रखता है।

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

लाइन और स्लाइड टेक्स्ट बॉक्स अपरिवर्तित रहता है। नीचे दी गई छवियां इनपुट और सेव किए गए, पुनः खुले परिणाम को दिखाती हैं:

| संपादन से पहले | संपादन के बाद |
| --- | --- |
| ![चार्ट एनोटेशन जिसमें प्रारंभिक परिणाम पढ़ा गया है](chart-annotations-before.png) | ![चार्ट एनोटेशन जिसमें अंतिम परिणाम पढ़ा गया है](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
उदाहरण केवल शीर्ष‑स्तर के चार्ट‑स्वामित्व वाले शेप्स की जांच करता है। यदि कोई एनोटेशन [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) के भीतर है, तो उस समूह के [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) संग्रह की भी जाँच करें। नेस्टेड समूहों के लिए इसे पुनरावर्ती रूप से दोहराएँ, उनके चाइल्ड शेप्स पर वही टेक्स्ट जाँच लागू करें। स्वयं एक समूह एक कंटेनर है; इसे टेक्स्ट बॉक्स के रूप में न मानें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं कॉलम/एरिया के लिए अर्ध‑पारदर्शी फ़िल सेट कर सकता हूँ जबकि बॉर्डर को अपारदर्शी रखूँ?**

हाँ। फ़िल की पारदर्शिता और आउटलाइन अलग‑अलग कॉन्फ़िगर की जाती है। यह घनी विज़ुअलाइज़ेशन में ग्रिड और डेटा की पठनीयता बेहतर बनाने में उपयोगी है।

**डेटा लेबल ओवरलैप होने पर मैं कैसे निपटूँ?**

फ़ॉन्ट आकार घटाएँ, गैर‑आवश्यक लेबल घटकों (उदाहरण के लिए, श्रेणियों) को निष्क्रिय करें, लेबल की स्थिति समायोजित करें, आवश्यक होने पर केवल चयनित बिंदुओं के लिए लेबल दिखाएँ, या फ़ॉर्मेट को "value + legend" में बदलें।

**क्या मैं सीरीज़ पर ग्रेडिएंट या पैटर्न फ़िल लागू कर सकता हूँ?**

हाँ। सीरीज़ में सॉलिड, ग्रेडिएंट और पैटर्न फ़िल्स का समर्थन है। व्यावहारिक रूप से, ग्रेडिएंट को सीमित रूप से उपयोग करें और ऐसी संयोजनों से बचें जो ग्रिड और टेक्स्ट के साथ कंट्रास्ट को कम करते हैं।