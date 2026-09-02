---
title: จัดการชุดข้อมูลแผนภูมิในพรีเซนเทชันด้วย PHP
linktitle: ชุดข้อมูล
type: docs
url: /th/php-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์ workbook
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- พรีเซนเทชัน
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในพรีเซนเทชันด้วย PHP."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่แสดงบนกราฟไว้ใน workbook ของข้อมูลแผนภูมิ หนึ่ง [ChartSeries](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/) ในชุดนั้นอ้างอิงถึงเซลล์ workbook หนึ่งหรือหลายเซลล์ [ChartCategory](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartcategory/) ให้ป้ายกำกับหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุดเหล่านั้น ชื่อชุด, ประเภท, และค่าจุดจึงเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/) แทนที่จะเก็บเป็นข้อความที่แสดงเท่านั้น

สำหรับแผนภูมิประเภทหมวดประเภททั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อประเภท, และเซลล์ที่เหลือสำหรับค่าชุด ดัชนี worksheet, แถว และคอลัมน์ที่ส่งไปยัง [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getCell) เป็นศูนย์‑ฐาน การจัดวางนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับพรีเซนเทชั่นที่โหลดมาให้ตรวจสอบเซลล์ที่ชุด, ประเภท, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของ workbook

การตั้งค่าของแผนภูมิมีสามระดับ:

- การตั้งค่าระดับชุด เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getFormat) ให้ลักษณะการแสดงผลเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าจุดข้อมูล เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getFormat) จะเขียนทับลักษณะของชุดสำหรับจุดหนึ่ง
- การตั้งค่ากลุ่มใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการกำหนดตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดอย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีการฟอร์แมตทั้งชุดและจุด การฟอร์แมตจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![แผนภูมิซีรีส์ PowerPoint](chart-series-powerpoint.png)

## **กำหนดการทับซ้อนของซีรีส์แผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2 มิติ ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการอ่านค่าแบบอ่าน‑อย่างจากการตั้งค่าในกลุ่มชุดแม่ ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; จะไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิผสม

ตัวอย่างต่อไปนี้กำหนดการทับซ้อนสำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, ประเภท, และค่า.
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

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getFormat) เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดมีการเติมสีอย่างชัดเจนแล้ว การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getFormat) จะเขียนทับสีเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใส่สีเติมเป็นสีน้ำเงินทึบให้กับชุดแรก:

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

ชื่อชุดจะถูกเก็บใน workbook ของข้อมูลแผนภูมิและปกติจะแสดงในคำอธิบาย ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบคลัสเตอร์ เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และบรรจุชื่อของชุดแรก ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่ถูกอ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getName) วิธีนี้หลีกเลี่ยงการสมมติว่าแผนภูมิที่มีอยู่มีแถวและคอลัมน์ที่กำหนดไว้ล่วงหน้า:

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

![ชื่อของชุด](series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดจะอ่านค่าสีที่คำนวณแล้ว; ไม่ได้กำหนดสีเติมใหม่

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้จะขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **กำหนดสีเติมกลับด้านสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมของชุดปกติให้เป็นสีทึบ, เปิดการกลับด้าน, และกำหนดสีค่าติดลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ตัวเลขติดลบจะคงเดิมใน workbook; เพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยชุดเดียว Worksheet แถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อประเภท, และคอลัมน์ 1 มีค่า:

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

![สีเติมทศนิยมกลับด้าน](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ตัวอย่างต่อไปนี้ปิดการกลับด้านสำหรับชุดและเปิดให้เฉพาะจุดที่เลือกเท่านั้น จุดนั้นยังถูกกำหนดให้มีค่าติดลบเพื่อให้ผลลัพธ์เห็นได้ชัด:

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

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ให้ตั้งค่าเซลล์ workbook ที่เป็นฐานของจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่แสดงจะสามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getValue) จุดข้อมูลจะคงอยู่ที่ตำแหน่งประเภทเดิม แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

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

แผนภูมิสแคตเทอร์ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointcollection/#clear) หากต้องการคงจุดอื่นไว้ เพราะเมธอดนั้นจะลบทุกจุดออกจากคอลเล็กชัน

## **กำหนดความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดแม่ ไม่ใช่ของชุดเดียว เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setGapWidth) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่จะสร้างช่องว่างระหว่างกลุ่มมากขึ้น, ค่าเล็กจะทำให้กลุ่มใกล้กันมากขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกพรีเซนเทชั่นขั้นสุดท้ายเท่านั้น:

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

**ประเภทแผนภูมิใดบ้างที่รองรับชุดข้อมูล?**

ทุกประเภทแผนภูมิที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิประเภทหมวดใช้ประเภทและค่า, แผนภูมิสแคตเทอร์ใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด ค่าตัวเลือกเช่นการทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**กลุ่มชุดแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้และแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งไม่จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ

**ชาร์ตที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, [ShapeCollection.addChart](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addChart) สร้างชุดตัวอย่าง, ประเภท, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งคอลเลคชันชุดและประเภทก่อนเพิ่มชุดข้อมูลแบบกำหนดเองทั้งหมด overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมโยงกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายกำกับประเภท, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิกับกัน เมื่อคุณสร้างข้อมูลกำหนดเองให้รักษาแถวประเภทและแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดแสดงภายใต้ประเภทที่ตั้งใจ

**ฉันจะลบจุดหนึ่งแทนที่จะลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งประเภทของจุดไว้เป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น หากคุณลบทั้งประเภทด้วย ต้องอัปเดตทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลคชันประเภท

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/#setDisplayBlanksAs) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่ขาดหายในพรีเซนเทชันของคุณ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setInvertIfNegative) และตั้งค่าสีที่คืนจาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative) วิธีเหล่านี้ส่งผลต่อการฟอร์แมต, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้

**การฟอร์แมตใดชนะเมื่อตั้งค่าทั้งชุดและจุด?**

การฟอร์แมตจุดข้อมูลอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ จะยังคงใช้ฟอร์แมตชุดที่กำหนดไว้ หรือเมื่อไม่มีการกำหนดชุดจะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การเขียนทับระดับจุด

**แผนภูมิมีขีดจำกัดจำนวนชุดหรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแยกออกไป ในทางปฏิบัติข้อจำกัดจะขึ้นกับข้อจำกัดของไฟล์พรีเซนเทชั่น, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรปรับอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่าที่กำหนดเพื่อทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าเพื่อทำให้กลุ่มใกล้กันมากขึ้น