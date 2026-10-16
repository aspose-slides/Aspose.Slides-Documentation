---
title: เพิ่มเส้นเทรนด์ไลน์ในแผนภูมิการนำเสนอด้วย PHP
linktitle: เส้นเทรนด์ไลน์
type: docs
url: /th/php-java/trend-line/
keywords:
- แผนภูมิ
- เส้นเทรนด์ไลน์
- เส้นเทรนด์ไลน์เอ็กซ์โพเนนเชียล
- เส้นเทรนด์ไลน์เชิงเส้น
- เส้นเทรนด์ไลน์ลอการิทึม
- เส้นเทรนด์ไลน์ค่าเฉลี่ยเคลื่อนที่
- เส้นเทรนด์ไลน์พหุนาม
- เส้นเทรนด์ไลน์พาวเวอร์
- เส้นเทรนด์ไลน์กำหนดเอง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เพิ่มและปรับแต่งเส้นเทรนด์ไลน์ในแผนภูมิ PowerPoint อย่างรวดเร็วด้วย Aspose.Slides สำหรับ PHP ผ่าน Java — คู่มือการใช้งานเพื่อดึงดูดผู้ชมของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการเพิ่มเส้นเทรนด์ไลน์ลงในแผนภูมิการนำเสนอโดยใช้ Aspose.Slides โดยแสดงวิธีสร้างแผนภูมิ, เพิ่มเส้นเทรนด์ไลน์ให้กับซีรีส์ของแผนภูมิ, และทำงานกับประเภทของเส้นเทรนด์ไลน์หลายประเภท รวมถึง exponential, linear, logarithmic, moving average, polynomial, และ power.

นอกจากนี้ยังอธิบายวิธีการเพิ่มเส้นกำหนดเองลงในแผนภูมิโดยการแทรกรูปร่างเส้น และรวมคำถามที่พบบ่อยสั้น ๆ เกี่ยวกับค่าการฉายเส้นเทรนด์ไลน์ไปข้างหน้าและถอยหลัง และว่ามีการคงรักษาเส้นเทรนด์ไลน์ไว้หรือไม่ระหว่างการส่งออกเป็น PDF หรือ SVG และเมื่อแสดงผลแผนภูมิเป็นภาพ.

## **เพิ่มเส้นเทรนด์ไลน์**

Use [TrendlineCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinecollection/add/) to add a trend line to a chart series, selecting its type with [TrendlineType](https://reference.aspose.com/slides/php-java/aspose.slides/trendlinetype/). ตัวอย่างสร้างแผนภูมิคอลัมน์แบบ clustered ด้วยข้อมูลเริ่มต้นและเพิ่มเส้นเทรนด์ไลน์สองเส้นให้กับแต่ละของสามซีรีส์

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

## **ตั้งการตัดของเส้นเทรนด์ไลน์**

Use [setIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/setintercept/) to fix a trend line's Y value at X = 0. This setting is supported for linear, exponential, and polynomial trend lines.

For example, a production cost model may need to start at known fixed costs of 100, even when measurements at nonzero production volumes suggest a different baseline. For a linear trend line, fixing the intercept constrains the equation `y = ax + b` to `b = 100`; the slope is fitted to the data under that constraint. It does not simply move an already fitted line. Axis crossing settings control where the chart axes meet, not the coefficients of the fitted trend line.

The following example creates a scatter (XY) chart with production volumes from 1 to 4 and costs of 170, 200, 230, and 260. It saves the chart with the default automatic intercept, sets the intercept to 100, and saves a second PPTX. The two files differ only in the intercept setting. The trend line displays its equation and extends back to X = 0.

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

With automatic calculation, these data produce `y = 30x + 140`. Setting the intercept to 100 instead produces approximately `y = 43.33x + 100`: the fitted value at zero matches the known baseline, while the line no longer passes through every data point.

| การคำนวณอัตโนมัติ | การตั้งค่าการตัดที่ 100 |
| --- | --- |
| ![เส้นเทรนด์ไลน์เส้นตรงที่คำนวณการตัดอัตโนมัติ 140](intercept-automatic.png) | ![เส้นเทรนด์ไลน์เส้นตรงที่ตั้งค่าการตัดเป็น 100](intercept-fixed.png) |

Both images use the same data and axis scales. The trend lines are extended back to X = 0 to show their intercepts.

By default, [getIntercept](https://reference.aspose.com/slides/php-java/aspose.slides/trendline/getintercept/) returns `NaN`, which represents an unspecified intercept rather than zero. The intercept is then calculated automatically from the data.

## **เพิ่มเส้นกำหนดเอง**

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

## **คำถามที่พบบ่อย**

**What do 'forward' and 'backward' mean for a trend line?**

They are the lengths of the trend line projected forward/backward: for scatter (XY) charts — in axis units; for non-scatter charts — in number of categories. Only non-negative values are allowed.

**Will the trend line be preserved when exporting the presentation to PDF or SVG, or when rendering a slide to an image?**

Yes. Aspose.Slides converts presentations to [PDF](/slides/th/php-java/convert-powerpoint-to-pdf/) or [SVG](/slides/th/php-java/render-a-slide-as-an-svg-image/) and renders charts to images; trend lines, as part of the chart, are preserved during these operations. A method is also available to [export an image of the chart](/slides/th/php-java/create-shape-thumbnails/) itself.