---
title: จัดการชุดข้อมูลแผนภูมิในการนำเสนอด้วย PHP
linktitle: ชุดข้อมูล
type: docs
url: /th/php-java/chart-series/
keywords:
- ชุดแผนภูมิ
- การทับของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์ workbook
- ช่องว่างของชุด
- ค่าลบ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดแผนภูมิ จุดข้อมูล เซลล์ workbook การจัดรูปแบบ การทับ ความกว้างของช่องว่าง และค่าลบในการนำเสนอด้วย PHP."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่แปลงรูปใน workbook ของข้อมูลแผนภูมิ. A [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ของ workbook. วัตถุ [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) ให้ป้ายหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล. ชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) แทนที่จะถูกเก็บเป็นข้อความแสดงผลเท่านั้น.

สำหรับแผนภูมิกลุ่มประเภททั่วไป, workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนีของ worksheet, แถว, และคอลัมน์ที่ส่งไปยัง [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCell) มีค่าเริ่มต้นจากศูนย์. การจัดเรียงนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้แบบนี้. สำหรับการนำเสนอที่โหลดมา, ตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของ workbook.

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat), ให้รูปลักษณ์เริ่มต้นสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าระดับจุดข้อมูล, เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat), จะทำให้การจัดรูปแบบของชุดถูกแทนที่สำหรับจุดหนึ่ง.
- การตั้งค่าระดับกลุ่มใช้กับชุดที่เข้ากันซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับหรือความกว้างของช่องว่าง.

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดอย่างชัดเจน, รูปแบบแผนภูมิและธีมจะกำหนดลักษณะอัตโนมัติ. เมื่อมีการจัดรูปแบบทั้งชุดและจุด, การจัดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับของชุดแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ทับกันเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่. ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดที่เข้ากันในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์แบบจัดกลุ่ม; มันจะไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม.

ตัวอย่างต่อไปนี้ตั้งค่าการทับสำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า.
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

![The series overlap](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getFormat) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับชุดทั้งหมด. หากจุดมีการเติมสีที่ชัดเจนแล้ว, การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getFormat) ของจุดนั้นจะทับการเติมสีของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าตรงให้กับชุดแรก:

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

![The color of the series](series_color.png)

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกจัดเก็บใน workbook ของข้อมูลแผนภูมิและปกติจะแสดงในคำอธิบาย. ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบจัดกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก. ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getName) ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![The series name](series_name.png)

### **สร้างชุดที่มีชื่อจากหลายเซลล์**

ชื่อชุดแบบคอมโพสิตมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลาการรายงานถูกเก็บในเซลล์ workbook แยกกัน. ตัวอย่างเช่น, คุณสามารถผสาน `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวขณะยังคงเชื่อมโยงส่วนทั้งสองกับเซลล์ต้นทางของพวกมัน.

ใช้ [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/#getCellCollection) เพื่อดึงช่วงชื่อ, แล้วส่งคอลเลกชันนั้นไปยัง [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/#add). พารามิเตอร์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนอยู่หรือไม่: `true` จะยกเว้น, `false` จะรวม. ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ.

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีชุดเดียวและสองจุดข้อมูล. เซลล์ B1:C1 จัดหาเฉพาะชื่อชุด; A2:A3 จัดหารหัสหมวดหมู่, และ B2:B3 จัดหาราคาตัวเลข.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 620, 180);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $chart->setLegend(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // เซลล์สองเซลล์นี้ให้ชื่อชุด.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // เซลล์แยกต่างหากให้หมวดหมู่และจุดข้อมูลเชิงตัวเลข.
    $northCategory = $workbook->getCell(0, 1, 0, "North");
    $southCategory = $workbook->getCell(0, 2, 0, "South");
    $chart->getChartData()->getCategories()->add($northCategory);
    $chart->getChartData()->getCategories()->add($southCategory);
    $northValue = $workbook->getCell(0, 1, 1, 120);
    $southValue = $workbook->getCell(0, 2, 1, 150);
    $series->getDataPoints()->addDataPointForBarSeries($northValue);
    $series->getDataPoints()->addDataPointForBarSeries($southValue);

    $presentation->save("composite_series_name.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ชื่อชุดที่ได้คือ `Product A 2026`, มีช่องว่างระหว่างค่าจากสองเซลล์. คำอธิบายจะแสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์. ภาพด้านล่างแสดงผลลัพธ์:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีชุดและรูปแบบแผนภูมิ. นี่คือสีที่ใช้เมื่อการเติมสีของชุดไม่ได้ถูกกำหนดอย่างชัดเจน. การเรียกเมธอดนี้อ่านค่าสีที่คำนวณ; ไม่ได้กำหนดการเติมสีใหม่.

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

ผลลัพธ์ตัวอย่างสำหรับรูปแบบแผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้จะขึ้นอยู่กับรูปแบบและธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับทิศสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าลบด้วยสีเติมที่แตกต่าง. ตั้งค่าการเติมสีของชุดเป็นสีทึบ, เปิดการย้อนกลับ, และกำหนดสีค่าลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). ตัวเลขลบยังคงไม่เปลี่ยนใน workbook; มีเพียงสีที่แสดงเปลี่ยนเท่านั้น.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว. แถว worksheet 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

คุณสามารถเปิดการย้อนกลับสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). ในตัวอย่างต่อไปนี้ การย้อนกลับถูกปิดการทำงานสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก. จุดนั้นยังถูกกำหนดค่าลบเพื่อให้เห็นผล:

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

## **ลบค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าระหว่างที่ไม่ลบจุดอื่น, ตั้งค่าเซลล์ workbook ที่สนับสนุนเป็น `null`. สำหรับแผนภูมิคอลัมน์, ค่าที่แสดงอยู่ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#getValue). จุดข้อมูลจะคงตำแหน่งหมวดหมู่เดิม, แต่วิธีแสดงค่าจะถือว่าเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาด. ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) เมื่อคุณต้องการคงจุดอื่นไว้, เพราะเมธอดนั้นจะลบทุกจุดจากคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนซึ่งมีค่าเป็นกรณีที่แตกต่างจากเซลล์ว่าง. เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อน, ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์ workbook ว่างหมายถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` หมายถึงค่าตัวเลขที่ทราบ. เรียก [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setValue) ด้วย `null` เพื่อทำให้เซลล์ว่าง. ศูนย์ตัวเลขยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร.

ใช้ [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีการวาดช่องว่างโดยไม่ต้องเติมค่า `0` หรือค่าที่ประมาณในเซลล์ workbook ที่ว่าง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดเดียว, ลบค่าของวันที่ 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่าต่าง ๆ; แถว 0 มีชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

    // ปล่อยให้วัน 3 เป็นค่าว่างจริง ๆ ขณะที่คงหมวดหมู่และจุดข้อมูลของมันไว้.
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

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอเพียงครั้งเดียวแทนการวนลูปโหมดทั้งหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์. วันที่ 3 จะว่างใน workbook ทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบโหมดทั้งสามได้ง่าย. แผนภูมิแถบและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดหมู่ที่หายไป, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมต่อได้; คอลัมน์ที่หายไปและคอลัมน์ความสูงศูนย์อาจดูคล้ายกัน. เช่นเดียวกับแผนภูมิกระจายที่มีเครื่องหมายเท่านั้นก็ไม่มีเส้นเชื่อมต่อ. อย่าคาดหวังผลลัพธ์สามแบบที่แตกต่างสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับ, มันเป็นของกลุ่มชุดแม่ไม่ใช่ของชุดเดียว. เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) ครั้งเดียวสำหรับกลุ่ม. ค่ามากทำให้มีช่องว่างมากขึ้นระหว่างกลุ่ม; ค่าน้อยทำให้กลุ่มใกล้กันมากขึ้น.

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

![The gap width](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่ระบุด้วย [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกเขาไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น, แผนภูมิประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่สอดคล้องกับประเภทชุด. ตัวเลือกเช่นการทับและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากัน.

**กลุ่มชุดแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) จะเก็บชุดที่เข้ากันซึ่งใช้การตั้งค่าการวาดระดับกลุ่มร่วมกัน. แผนภูมิแบบผสมอาจมีหลายกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งไม่ได้หมายความว่าจะเปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addChart) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. มีการโหลดที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้.

**แผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/). การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้อง. เมื่อคุณสร้างข้อมูลกำหนดเอง, ให้จัดแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดแสดงภายใต้หมวดหมู่ที่ต้องการ.

**จะลบจุดเดียวแทนที่จะลบชุดทั้งหมดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อคงตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น. หากคุณลบหมวดหมู่ด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setDisplayBlanksAs). แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยเชื่อมจุดใกล้เคียงกัน. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ. ดูที่ [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ.

**ค่าลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#setInvertIfNegative) และตั้งค่าสีที่ได้จาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). คุณสามารถบิดเบือนพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้.

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลที่ชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ จะใช้การจัดรูปแบบชุดที่ชัดเจนหรือ, หากไม่มีการกำหนดรูปแบบชุด, จะใช้รูปแบบและธีมแผนภูมิโดยอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การแทนที่การจัดรูปแบบระดับจุด.

**แผนภูมิสามารถมีชุดได้มากที่สุดกี่ชุด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดเป็นค่าคงที่. ในทางปฏิบัติ, ข้อจำกัดของไฟล์การนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่มีประโยชน์.

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าถ้าต้องการขยายช่องว่างระหว่างกลุ่ม, หรือ ลดค่าเพื่อทำให้กลุ่มใกล้กันมากขึ้น.