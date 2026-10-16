---
title: PHP में प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ें
linktitle: ट्रेंड लाइन
type: docs
url: /hi/php-java/trend-line/
keywords:
- चार्ट
- ट्रेंड लाइन
- एक्सपोनेन्शियल ट्रेंड लाइन
- लीनियर ट्रेंड लाइन
- लॉगरिदमिक ट्रेंड लाइन
- मूविंग औसत ट्रेंड लाइन
- पॉलीनॉमियल ट्रेंड लाइन
- पावर ट्रेंड लाइन
- कस्टम ट्रेंड लाइन
- PowerPoint
- प्रेजेंटेशन
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java के साथ PowerPoint चार्ट में ट्रेंड लाइन्स को तेज़ी से जोड़ें और अनुकूलित करें — दर्शकों को सम्मोहित करने के लिए एक व्यावहारिक गाइड।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके प्रस्तुति चार्ट में ट्रेंड लाइन्स जोड़ने के तरीके को समझाता है। यह दिखाता है कि चार्ट कैसे बनाएं, चार्ट सीरीज़ में ट्रेंड लाइन्स जोड़ें, और कई ट्रेंड लाइन प्रकारों के साथ काम करें, जिसमें एक्सपोनेन्शियल, लीनियर, लॉगरिदमिक, मूविंग औसत, पॉलीनॉमियल और पावर शामिल हैं।

यह भी वर्णन करता है कि लाइन आकार डालकर चार्ट में एक कस्टम लाइन कैसे जोड़ें, और फ़ॉरवर्ड तथा बैकवर्ड ट्रेंड लाइन प्रोजेक्शन वैल्यूज़ और क्या ट्रेंड लाइन्स को PDF या SVG में निर्यात करते समय या चार्ट को इमेज के रूप में रेंडर करते समय संरक्षित रखा जाता है, इस पर एक छोटा FAQ शामिल है।

## **ट्रेंड लाइन जोड़ें**

Use [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) to add a trend line to a chart series, selecting its type with [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). The example creates a clustered column chart with default data and adds two trend lines to each of its three series.

The exponential trend line hides its equation and R-squared value through [setDisplayEquation](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayequation/) and [setDisplayRSquaredValue](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setdisplayrsquaredvalue/), while the linear trend line is red. The logarithmic trend line uses [addTextFrameForOverriding](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/addtextframeforoverriding/) for a custom label. The moving average uses a [setPeriod](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setperiod/) of three data points and a custom [setTrendlineName](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/settrendlinename/).

The polynomial trend line has an order of three, set through [setOrder](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setorder/), and extends one category forward through [setForward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setforward/). The power trend line extends one category backward through [setBackward](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setbackward/).

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\FillType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 400);

    $firstSeries = $chart->getChartData()->getSeries()->get_Item(0);

    $exponentialTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Exponential);
    $exponentialTrendline->setDisplayEquation(false);
    $exponentialTrendline->setDisplayRSquaredValue(false);

    $linearTrendline = $firstSeries->getTrendLines()->add(TrendlineType::Linear);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $linearTrendline->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $secondSeries = $chart->getChartData()->getSeries()->get_Item(1);

    $logarithmicTrendline = $secondSeries->getTrendLines()->add(TrendlineType::Logarithmic);
    $logarithmicTrendline->addTextFrameForOverriding("New log trend line");

    $movingAverageTrendline = $secondSeries->getTrendLines()->add(TrendlineType::MovingAverage);
    $movingAverageTrendline->setPeriod(3);
    $movingAverageTrendline->setTrendlineName("New TrendLine Name");

    $thirdSeries = $chart->getChartData()->getSeries()->get_Item(2);

    $polynomialTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Polynomial);
    $polynomialTrendline->setForward(1);
    $polynomialTrendline->setOrder(3);

    $powerTrendline = $thirdSeries->getTrendLines()->add(TrendlineType::Power);
    $powerTrendline->setBackward(1);

    $presentation->save("ChartTrendLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ट्रेंड लाइन इंटरसेप्ट सेट करें**

Use [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) to fix a trend line's Y value at X = 0. This setting is supported for linear, exponential, and polynomial trend lines.

उदाहरण के लिए, एक उत्पादन लागत मॉडल को ज्ञात निश्चित लागत 100 से शुरू होने की आवश्यकता हो सकती है, भले ही शून्य से अलग उत्पादन मात्रा पर माप अलग आधार रेखा सुझाते हों। एक लीनियर ट्रेंड लाइन के लिए, इंटरसेप्ट को फिक्स करने से समीकरण `y = ax + b` को `b = 100` तक सीमित किया जाता है; इस बाधा के तहत ढाल को डेटा के अनुसार फिट किया जाता है। यह केवल पहले से फिट की गई रेखा को नहीं हटाता। एक्सिस क्रॉसिंग सेटिंग्स चार्ट की एक्सिस कहाँ मिलती हैं, इसे नियंत्रित करती हैं, न कि फिट की गई ट्रेंड लाइन के गुणांक को।

निम्नलिखित उदाहरण 1 से 4 तक के उत्पादन वॉल्यूम और 170, 200, 230, तथा 260 की लागतों के साथ एक स्कैटर (XY) चार्ट बनाता है। यह चार्ट को डिफ़ॉल्ट ऑटोमैटिक इंटरसेप्ट के साथ सेव करता है, इंटरसेप्ट को 100 पर सेट करता है, और दूसरा PPTX सेव करता है। दोनों फ़ाइलें केवल इंटरसेप्ट सेटिंग में भिन्न हैं। ट्रेंड लाइन अपना समीकरण दिखाता है और X = 0 तक पीछे की ओर विस्तारित होती है।

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\TrendlineType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithMarkers, 20, 20, 480, 210);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $nameCell = $workbook->getCell(0, 0, 1, "Production cost");
    $series = $chart->getChartData()->getSeries()->add($nameCell, ChartType::ScatterWithMarkers);
    $costs = [170, 200, 230, 260];

    for ($i = 0; $i < count($costs); $i++) {
        $xCell = $workbook->getCell(0, $i + 1, 0, $i + 1);
        $yCell = $workbook->getCell(0, $i + 1, 1, $costs[$i]);
        $series->getDataPoints()->addDataPointForScatterSeries($xCell, $yCell);
    }

    $trendline = $series->getTrendLines()->add(TrendlineType::Linear);
    $trendline->setDisplayEquation(true);
    $trendline->setBackward(1);

    $presentation->save("AutomaticIntercept.pptx", SaveFormat::Pptx);

    $trendline->setIntercept(100);
    $presentation->save("FixedIntercept.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ऑटोमैटिक कैलकुलेशन के साथ, ये डेटा `y = 30x + 140` बनाते हैं। इंटरसेप्ट को 100 पर सेट करने से लगभग `y = 43.33x + 100` बनता है: शून्य पर फिट किया गया मान ज्ञात बेसलाइन से मेल खाता है, जबकि रेखा अब हर डेटा पॉइंट से नहीं गुजरती।

| ऑटोमैटिक इंटरसेप्ट | 100 का फिक्स्ड इंटरसेप्ट |
| --- | --- |
| ![140 के ऑटोमैटिकली कैलकुलेटेड इंटरसेप्ट के साथ लीनियर ट्रेंड लाइन](intercept-automatic.png) | ![100 के फिक्स्ड इंटरसेप्ट के साथ लीनियर ट्रेंड लाइन](intercept-fixed.png) |

दोनों इमेज समान डेटा और एक्सिस स्केल का उपयोग करती हैं। ट्रेंड लाइन्स X = 0 तक पीछे की ओर विस्तारित की गई हैं ताकि उनका इंटरसेप्ट दिखाया जा सके।

डिफ़ॉल्ट रूप से, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) `NaN` लौटाता है, जिसका अर्थ है एक अनिर्दिष्ट इंटरसेप्ट, शून्य नहीं। इंटरसेप्ट तब डेटा से ऑटोमैटिक रूप से गणना किया जाता है।

## **कस्टम लाइन जोड़ें**

A custom line is a shape drawn over the chart rather than a trend line calculated from series data. This example uses [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) to add a horizontal line to the slide over the chart. The line's position is specified in slide coordinates, measured in points, so it starts at the chart's left edge and sits halfway down the chart. Its width matches the chart's width. The [getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getlineformat/) gives the line a solid red color.

```php
use aspose\slides\Presentation;
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\ShapeType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);

    $lineY = java_values($chart->getY()) + java_values($chart->getHeight()) / 2;
    $line = $slide->getShapes()->addAutoShape(ShapeType::Line, $chart->getX(), $lineY, $chart->getWidth(), 0);
    $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $presentation->save("AddCustomLines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**ट्रेंड लाइन के लिए 'फ़ॉरवर्ड' और 'बैकवर्ड' का क्या अर्थ है?**

वे ट्रेंड लाइन की लंबाइयाँ हैं जो आगे/पीछे प्रोजेक्ट की जाती हैं: स्कैटर (XY) चार्ट्स के लिए — अक्ष इकाइयों में; नॉन‑स्कैटर चार्ट्स के लिए — श्रेणियों की संख्या में। केवल गैर‑नकारात्मक मानों की अनुमति है।

**क्या प्रस्तुति को PDF या SVG में निर्यात करने या स्लाइड को इमेज में रेंडर करने पर ट्रेंड लाइन संरक्षित रहती है?**

Yes. Aspose.Slides प्रस्तुतियों को [PDF](/slides/hi/php-java/convert-powerpoint-to-pdf/) या [SVG](/slides/hi/php-java/render-a-slide-as-an-svg-image/) में बदलता है और चार्ट को इमेज में रेंडर करता है; ट्रेंड लाइन्स, जो चार्ट का हिस्सा हैं, इन ऑपरेशनों के दौरान संरक्षित रहती हैं। एक मेथड भी उपलब्ध है जो [चार्ट की इमेज निर्यात](/slides/hi/php-java/create-shape-thumbnails/) करता है।