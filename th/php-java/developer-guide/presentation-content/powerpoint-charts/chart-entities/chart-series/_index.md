---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย PHP
linktitle: ชุดข้อมูล
type: docs
url: /th/php-java/chart-series/
keywords:
- ชุดแผนภูมิ
- การซ้อนทับของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์สมุดงาน
- ช่องว่างของชุด
- ค่าลบ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การซ้อนทับ, ความกว้างของช่องว่าง, และค่าลบในการนำเสนอด้วย PHP."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่พล็อตไว้ในสมุดงานข้อมูลแผนภูมิ (chart data workbook). [ChartSeries](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/) ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ของสมุดงาน. วัตถุ [ChartCategory](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุด. ดังนั้นชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/) แทนที่จะเก็บเป็นข้อความแสดงผลเท่านั้น.

สำหรับแผนภูมิประเภทแผนภูมหมวดหมู่โดยทั่วไป, สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนีเวิร์กชีต, แถว, และคอลัมน์ที่ส่งให้กับ [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getCell) เริ่มนับจากศูนย์. การจัดเรียงนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสมมติว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้. สำหรับการนำเสนอที่โหลดแล้ว, ควรตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าในสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getFormat), ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าระดับจุดข้อมูล, เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getFormat), จะเขียนทับลักษณะของชุดสำหรับจุดหนึ่งจุด.
- การตั้งค่ากลุ่มจะใช้กับชุดที่เข้ากันได้และอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการกำหนดตัวเลือกเช่นการซ้อนทับหรือความกว้างของช่องว่าง.

เมื่อไม่มีการกำหนดการเติมสีของจุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. เมื่อมีการกำหนดรูปแบบทั้งชุดและจุด, การกำหนดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![แผนภูมิซีรีส์พาวเวอร์พอยท์](chart-series-powerpoint.png)

## **ตั้งค่าการซ้อนทับของชุดแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ซ้อนทับกันมากเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. นี้เป็นการฉายภาพอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่. ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม.

ตัวอย่างต่อไปนี้ตั้งค่าการซ้อนทับสำหรับกลุ่มที่มีชุดแรก:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่, และค่า.
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setOverlap($overlapPercent);

    $presentation->save("series_overlap.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

ผลลัพธ์:

![การซ้อนทับของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getFormat) เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดทั้งหมด. หากจุดมีการกำหนดสีเติมอย่างชัดเจน, การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getFormat) จะเขียนทับสีเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมเป็นสีน้ำเงินทึบสำหรับชุดแรก:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$blueColor = java("java.awt.Color")->BLUE;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($blueColor);

    $presentation->save("series_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

ผลลัพธ์:

![สีของชุด](series_color.png)

## **เปลี่ยนชื่อชุด**

ชื่อชุดจะเก็บไว้ในสมุดงานข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย (legend). ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก. ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$seriesNameRowIndex = 0;
$firstSeriesColumnIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $seriesNameCell = $workbook->getCell($worksheetIndex, $seriesNameRowIndex, $firstSeriesColumnIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

คุณสามารถอัปเดตเซลล์ที่ [ChartSeries.getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getName) อ้างอิงอยู่ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$firstNameCellIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $seriesNameCell = $series->getName()->getAsCells()->get_Item($firstNameCellIndex);
    $seriesNameCell->setValue("Revenue");

    $presentation->save("series_name.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

ผลลัพธ์:

![ชื่อชุด](series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ. นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้ถูกกำหนดอย่างชัดเจน. การเรียกเมธอดนี้เพียงอ่านสีที่คำนวณได้; ไม่ได้กำหนดสีเติมใหม่.

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

```php
$firstSlideIndex = 0;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $seriesCount = java_values($chart->getChartData()->getSeries()->size());
    for ($seriesIndex = 0; $seriesIndex < $seriesCount; $seriesIndex++) {
        $series = $chart->getChartData()->getSeries()->get_Item($seriesIndex);
        $automaticColor = $series->getAutomaticSeriesColor();
        $red = java_values($automaticColor->getRed());
        $green = java_values($automaticColor->getGreen());
        $blue = java_values($automaticColor->getBlue());
        echo "Series " . $seriesIndex . ": java.awt.Color[r=" . $red . ",g=" . $green . ",b=" . $blue . "]" . PHP_EOL;
    }
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

ตัวอย่างผลลัพธ์สำหรับสไตล์แผนภูมิเบื้องต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าสีเติมของชุดปกติเป็นสีทึบ, เปิดการกลับด้าน, และกำหนดสีค่าลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). ตัวเลขลบจะคงอยู่ในสมุดงาน; เพียงสีที่แสดงเท่านั้นที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยชุดเดียว. แถว 0 ของเวิร์กชีตมีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

```php
$firstSlideIndex = 0;
$worksheetIndex = 0;
$headerRowIndex = 0;
$categoryColumnIndex = 0;
$firstSeriesColumnIndex = 1;
$firstDataRowIndex = 1;

$categoryNames = ["Category 1", "Category 2", "Category 3"];
$seriesValues = [-20, 50, -30];
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, $headerRowIndex, $firstSeriesColumnIndex, "Series 1");
    $chartType = $chart->getType();
    $series = $chartData->getSeries()->add($seriesNameCell, $chartType);

    $categoryCount = count($categoryNames);
    for ($categoryIndex = 0; $categoryIndex < $categoryCount; $categoryIndex++) {
        $dataRowIndex = $firstDataRowIndex + $categoryIndex;
        $categoryName = $categoryNames[$categoryIndex];
        $seriesValue = $seriesValues[$categoryIndex];

        $categoryCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $categoryColumnIndex, $categoryName);
        $chartData->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $dataRowIndex, $firstSeriesColumnIndex, $seriesValue);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->setInvertIfNegative(true);
    $series->getInvertedSolidFillColor()->setColor($redColor);

    $presentation->save("inverted_solid_fill_color.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

ผลลัพธ์:

![สีเติมทึบกลับด้าน](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับด้านสำหรับจุดหนึ่งโดยใช้ [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก. จุดนั้นยังถูกกำหนดค่าเป็นค่าลบเพื่อให้เห็นผล:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 2;
$negativeValue = -30;
$redColor = java("java.awt.Color")->RED;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $automaticSeriesColor = $series->getAutomaticSeriesColor();
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($automaticSeriesColor);
    $series->getInvertedSolidFillColor()->setColor($redColor);
    $series->setInvertIfNegative(false);

    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue($negativeValue);
    $dataPoint->setInvertIfNegative(true);

    $presentation->save("data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์สมุดงานที่เป็นพื้นหลังของจุดนั้นเป็น `null`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getValue). จุดข้อมูลจะคงอยู่ที่ตำแหน่งหมวดหมู่เดิม, แต่แผนภูมิจะแสดงค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$targetDataPointIndex = 1;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $dataPoint = $series->getDataPoints()->get_Item($targetDataPointIndex);
    $dataPoint->getValue()->getAsCell()->setValue(null);

    $presentation->save("clear_data_point_value.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

แผนภูมิกระจาย (scatter) ใช้เซลล์ X และ Y แยกกัน, ส่วนแผนภูมิบับเบิลยังใช้เซลล์ขนาด. จึงล้างเฉพาะเซลล์ที่เป็นค่าที่ต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointcollection/#clear) หากคุณต้องการคงจุดอื่นไว้, เพราะเมธอดนี้จะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่ซึ่งมีค่าเป็นกรณีที่แตกต่างจากเซลล์ว่าง. หากต้องการรวมหรือเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อน, ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์สมุดงานว่างแสดงถึงข้อมูลที่ขาดหาย; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่ทราบ. เรียก [ChartDataCell::setValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setValue) พร้อม `null` เพื่อทำให้เซลล์ว่าง. จำนวนศูนย์ยังคงเป็นศูนย์โดยไม่คำนึงถึงการตั้งค่าเซลล์ว่าง.

ใช้ [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/#setDisplayBlanksAs) เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ว่าง. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีที่ช่องว่างถูกพล็อตโดยไม่ต้องเติมค่าในเซลล์สมุดงานด้วยศูนย์หรือค่าประมาณ.

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าของวัน 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด. ไม่ต้องการไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/) ใช้เวิร์กชีต 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayBlanksAsType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 40, 40, 640, 400);
    $chartData = $chart->getChartData();
    $workbook = $chartData->getChartDataWorkbook();

    $chartData->getSeries()->clear();
    $chartData->getCategories()->clear();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Measurements");
    $series = $chartData->getSeries()->add($seriesNameCell, $chart->getType());
    $values = [10, 20, 25, 30, 40];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Day " . ($i + 1));
        $chartData->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // ปล่อยให้วัน 3 ว่างจริง ๆ ขณะที่ยังคงรักษาหมวดหมู่และจุดข้อมูลไว้.
    $workbook->getCell(0, 3, 1)->setValue(null);

    $modes = [DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span];
    $modeNames = ["Gap", "Zero", "Span"];
    for ($i = 0; $i < count($modes); $i++) {
        $chart->setDisplayBlanksAs($modes[$i]);
        $presentation->save("empty_cells_" . $modeNames[$i] . ".pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, ตั้งค่าโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนลูปตามโหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์. วัน 3 เป็นเซลล์ว่างในสมุดงานทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่วัน 3, Zero ทำให้เส้นลงไปที่ศูนย์, และ Span เชื่อมวัน 2 ไปวัน 4.](display_blanks_as.png)

ผลที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบทั้งสามโหมดได้ง่าย. แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมระหว่างช่องที่หายไป, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมที่แสดงในภาพ; คอลัมน์ที่หายไปและคอลัมน์สูงศูนย์อาจดูคล้ายกัน. เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อม. อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่ใกล้เคียงกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการซ้อนทับ, มันเป็นของกลุ่มชุดแม่ไม่ใช่ของชุดเดียว. เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setGapWidth) หนึ่งครั้งสำหรับกลุ่ม. ค่าที่ใหญ่กว่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น; ค่าที่เล็กกว่าจะทำให้กลุ่มอัดใกล้กันมากขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกการนำเสนอสุดท้ายเท่านั้น:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$gapWidthPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 500, 200);

    $series = $chart->getChartData()->getSeries()->get_Item($firstSeriesIndex);
    $series->getParentSeriesGroup()->setGapWidth($gapWidthPercent);

    $presentation->save("gap_width_30.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

ผลลัพธ์:

![ความกว้างของช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดรองรับชุดข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น แผนภูมิประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มเติมขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด. ตัวเลือกเช่นการซ้อนทับและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มชุดแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดหนึ่งอาจไม่ได้เปลี่ยนแปลงทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี. โดยค่าเริ่มต้น, [ShapeCollection.addChart](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addChart) สร้างชุดตัวอย่าง, หมวดหมู่, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. อีกทางเลือกคือใช้ overload เพื่อสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น.

**แผนภูมิติดตั้งกับเซลล์สมุดงานอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิค่านั้น. เมื่อตั้งค่าข้อมูลกำหนดเอง, ให้รักษาแถวหมวดหมู่และแถวค่าของชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ใต้หมวดหมู่ที่ต้องการ.

**จะลบจุดเดียวโดยไม่ลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น. หากคุณลบหมวดหมู่ด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่ายังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและค่าที่ตั้งไว้ใน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/#setDisplayBlanksAs). แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, ค่าเป็นศูนย์, หรือเชื่อมจุดใกล้เคียงกัน. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ. ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ.

**ค่าลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setInvertIfNegative) และกำหนดสีที่ได้จาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดียวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ.

**การจัดรูปแบบใดชนะเมื่อตั้งค่าทั้งชุดและจุด?**

การจัดรูปแบบจุดข้อมูลอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ จะใช้การจัดรูปแบบชุดที่กำหนดไว้หรือ, หากไม่มีการกำหนดรูปแบบชุด, จะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ. การตั้งค่ากลุ่มเช่นการซ้อนทับและความกว้างของช่องว่างควบคุมการจัดวางและไม่ถือเป็นการลบล้างการจัดรูปแบบระดับจุด.

**มีขีดจำกัดจำนวนชุดต่อแผนภูมิหรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแบบคงที่. อย่างไรก็ตาม ข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิมักเป็นปัจจัยที่กำหนดขีดจำกัดที่ใช้ได้จริง.

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างคลัสเตอร์กว้างขึ้น, ลดค่าจะทำให้คลัสเตอร์เรียบแคบลง.