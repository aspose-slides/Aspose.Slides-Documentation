---
title: จัดการซีรีส์ข้อมูลแผนภูมิในงานนำเสนอด้วย PHP
linktitle: ซีรีส์ข้อมูล
type: docs
url: /th/php-java/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การทับซ้อนของซีรีส์
- สีของซีรีส์
- ชื่อซีรีส์
- จุดข้อมูล
- เซลล์หนังสือทำงาน
- ช่องว่างของซีรีส์
- ค่าลบ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์แผนภูมิ, จุดข้อมูล, เซลล์หนังสือทำงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าลบในงานนำเสนอด้วย PHP."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่แสดงผลไว้ในหนังสือข้อมูลแผนภูมิ (chart data workbook). [ChartSeries](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/) แทนค่าชุดหนึ่งของค่าที่เกี่ยวข้อง, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/) ในชุดข้อมูลอ้างอิงถึงหนึ่งหรือหลายเซลล์ในหนังสือทำงาน. วัตถุ [ChartCategory](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล. ชื่อชุดข้อมูล, ประเภท, และค่าจุดจึงถูกเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/) แทนที่จะถูกเก็บเป็นข้อความแสดงผลเพียงอย่างเดียว.

สำหรับแผนภูมิประเภททั่วไป, หนังสือทำงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล, คอลัมน์ 0 สำหรับชื่อประเภท, และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล. ดัชนี worksheet, แถว, และคอลัมน์ที่ส่งไปยัง [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/#getCell) มีค่าเริ่มต้นจากศูนย์. รูปแบบนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้. สำหรับการนำเสนอที่โหลดแล้ว, ตรวจสอบเซลล์ที่ชุดข้อมูล, ประเภท, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของหนังสือทำงาน.

การตั้งค่าแผนภูมิมีขอบเขตสามแบบ:

- การตั้งค่าระดับซีรีส์, เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getFormat), ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในซีรีส์หนึ่ง.
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getFormat), จะเขียนทับลักษณะการแสดงผลของซีรีส์สำหรับจุดนั้น.
- การตั้งค่ากลุ่มจะใช้กับซีรีส์ที่เข้ากันได้และอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง.

เมื่อไม่มีการตั้งค่าสีเติมจุดหรือซีรีส์โดยเจาะจง, รูปแบบและธีมของแผนภูมิจะกำหนดลักษณะการแสดงผลอัตโนมัติ. หากมีการตั้งค่าทั้งซีรีส์และจุด, การตั้งค่าของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของซีรีส์แผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการแสดงผลแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มซีรีส์แม่. ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกซีรีส์ที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์ที่จัดกลุ่ม; จะไม่ส่งผลต่อกลุ่มซีรีส์ที่ไม่มีความสัมพันธ์ในแผนภูมิแบบผสม.

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีซีรีส์แรกเป็นสมาชิก:

```php
$firstSlideIndex = 0;
$firstSeriesIndex = 0;
$overlapPercent = 30;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item($firstSlideIndex);

    // แผนภูมิใหม่ประกอบด้วยซีรีส์ตัวอย่าง, ประเภท, และค่า.
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

![การทับซ้อนของซีรีส์](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getFormat) เพื่อกำหนดสีเติมเริ่มต้นสำหรับทั้งซีรีส์. หากจุดหนึ่งมีการกำหนดสีเติมโดยเจาะจงแล้ว, การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getFormat) ของจุดนั้นจะเขียนทับสีเติมของซีรีส์สำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมทึบสีฟ้ากับซีรีส์แรก:

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

![สีของซีรีส์](series_color.png)

## **เปลี่ยนชื่อซีรีส์**

ชื่อซีรีส์ถูกเก็บในหนังสือข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย (legend). ในหนังสือทำงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของซีรีส์แรก. ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getName) ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อของซีรีส์](series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีซีรีส์และรูปแบบแผนภูมิ. นี่คือสีที่ใช้เมื่อสีเติมของซีรีส์ไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดจะอ่านสีที่คำนวณไว้; ไม่ได้กำหนดสีเติมใหม่.

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละซีรีส์เริ่มต้น:

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

สีที่แน่นอนขึ้นอยู่กับรูปแบบและธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับตำแหน่งสำหรับซีรีส์แผนภูมิ**

สำหรับซีรีส์แบบบาร์, คอลัมน์, และบับเบิ้ล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าสีเติมซีรีส์ปกติให้เป็นทึบ, เปิดการกลับตำแหน่ง, แล้วกำหนดสีค่าลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). ตัวเลขลบจะไม่ถูกเปลี่ยนในหนังสือทำงาน; มีเพียงสีการแสดงผลที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยซีรีส์หนึ่งชุด. แถว worksheet 0 มีชื่อซีรีส์, คอลัมน์ 0 มีชื่อประเภท, และคอลัมน์ 1 มีค่าต่างๆ:

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

![สีเติมทึบกลับตำแหน่ง](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับตำแหน่งสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). ในตัวอย่างต่อไปนี้ การกลับตำแหน่งถูกปิดสำหรับซีรีส์และเปิดเฉพาะจุดที่เลือก. จุดนั้นยังถูกกำหนดค่าเป็นค่าลบเพื่อให้เห็นผลลัพธ์:

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

## **ลบค่าของจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์หนังสือทำงานของจุดนั้นเป็น `null`. สำหรับแผนภูมิคอลัมน์, ค่าที่แสดงผลสามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#getValue). จุดข้อมูลจะยังคงอยู่ในตำแหน่งประเภทเดียวกัน, แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในซีรีส์แรก:

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

แผนภูมิกระจาย (scatter) ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิ้ลยังใช้เซลล์ขนาดเพิ่มเติม. ให้ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointcollection/#clear) เมื่อคุณต้องการเก็บจุดอื่นไว้, เพราะเมธอดนี้จะลบทุกจุดจากคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์หนังสือทำงานที่ว่างเปล่าหมายถึงข้อมูลขาดหาย; เซลล์ที่มีค่า `0` หมายถึงค่าตัวเลขที่ทราบ. เรียก [ChartDataCell::setValue](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatacell/#setValue) พร้อม `null` เพื่อทำให้เซลล์เป็นค่าว่าง. ค่าศูนย์ตัวเลขจะคงเป็นศูนย์ regardless of การตั้งค่าค่าว่างของเซลล์.

ใช้ [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/#setDisplayBlanksAs) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีการวาดค่าว่าง, โดยไม่ต้องเติมค่า `0` หรือค่าที่ประมาณในเซลล์ว่าง.

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบอิสระที่สร้างแผนภูมิเส้นหนึ่งซีรีส์, ลบค่าของวัน 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด. ไม่ต้องมีไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายประเภท, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อซีรีส์. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

    // ทำให้วัน 3 เป็นค่าว่างจริง ๆ ในขณะที่ยังคงรักษาประเภทและจุดข้อมูลของมันไว้.
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

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดไว้ก่อนการบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเวอร์ชันเดียว, ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอเพียงครั้งเดียวแทนการวนลูปตามโหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในสามไฟล์. วัน 3 เป็นค่าว่างในหนังสือทำงานทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่วัน 3, Zero ทำให้เส้นตกลงเป็นศูนย์, และ Span เชื่อมวัน 2 ไปวัน 4.](display_blanks_as.png)

ผลลัพธ์ที่เห็นจะขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบโหมดทั้งสามได้ง่าย. แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมต่อข้ามประเภทที่ขาดหาย, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงด้านบน; คอลัมน์ที่ขาดหายและคอลัมน์ศูนย์สูงอาจดูคล้ายกัน. เช่นเดียวกัน, แผนภูมิกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อมต่อ. อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างของช่องว่างระหว่างซีรีส์**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มันเป็นของกลุ่มซีรีส์แม่ ไม่ได้เป็นของหนึ่งซีรีส์. เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setGapWidth) หนึ่งครั้งสำหรับกลุ่ม. ค่าที่มากกว่าจะทำให้มีช่องว่างระหว่างกลุ่มมากขึ้น; ค่าที่น้อยกว่าจะทำให้กลุ่มแน่นขึ้น.

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

## **FAQ**

**ประเภทแผนภูมิใดสนับสนุนซีรีส์ข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ซีรีส์ของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น, แผนภูมิประเภทใช้ประเภทและค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิ้ลเพิ่มขนาดของบับเบิ้ล. ให้ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทซีรีส์. ตัวเลือกเช่นการทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มซีรีส์แผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/) ประกอบด้วยซีรีส์ที่เข้ากันได้และใช้การตั้งค่าการวาดระดับกลุ่มร่วมกัน. แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านซีรีส์หนึ่งไม่ได้หมายความว่าจะเปลี่ยนซีรีส์ทั้งหมดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. ตามค่าเริ่มต้น, [ShapeCollection.addChart](https://reference.aspose.com/slides/th/php-java/aspose.slides/shapecollection/#addChart) สร้างซีรีส์ตัวอย่าง, ประเภท, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันซีรีส์และประเภทก่อนที่จะเพิ่มชุดข้อมูลแบบกำหนดเองเต็มรูปแบบ. มีการ overload ที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้เช่นกัน.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์หนังสือทำงานอย่างไร?**

ชื่อซีรีส์, ป้ายประเภท, และค่าจุดข้อมูลอ้างอิงถึงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมที่สอดคล้องกัน. เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, ให้รักษาแถวประเภทและแถวค่าของซีรีส์ให้สอดคล้องกันเพื่อให้แต่ละจุดถูกวางภายใต้ประเภทที่ต้องการ.

**ฉันจะลบจุดเดียวแทนการลบทั้งซีรีส์ได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อให้จุดนั้นยังคงตำแหน่งประเภทอยู่เป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapointcollection/#clear) เท่านั้นเมื่อคุณตั้งใจจะลบทุกจุดจากซีรีส์นั้น. หากคุณลบประเภทด้วย, ให้อัปเดตทุกซีรีส์ให้ค่าตรงกับคอลเลกชันประเภทที่เหลืออยู่.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/php-java/aspose.slides/chart/#setDisplayBlanksAs). แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, ค่าศูนย์, หรือเชื่อมจุดใกล้เคียงกัน. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ. ดูส่วน **ควบคุมการแสดงผลของเซลล์ว่าง** เพื่อดูตัวอย่างและการเปรียบเทียบภาพครบถ้วน.

**ค่าลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับซีรีส์บาร์, คอลัมน์, และบับเบิ้ลที่รองรับ, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#setInvertIfNegative) และกำหนดสีที่คืนค่าจาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getInvertedSolidFillColor). คุณสามารถเขียนทับพฤติกรรมนี้สำหรับจุดเดี่ยวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdatapoint/#setInvertIfNegative). วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ.

**การจัดรูปแบบใดชนะเมื่อทั้งซีรีส์และจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลโดยเจาะจงจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ จะยังคงใช้การจัดรูปแบบของซีรีส์โดยตรงหรือ, หากไม่มีการกำหนดรูปแบบของซีรีส์, จะใช้รูปแบบและธีมของแผนภูมิอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การเขียนทับระดับจุด.

**มีขีดจำกัดจำนวนซีรีส์ที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนซีรีส์แบบแยกต่างหาก. อย่างไรก็ตาม, ข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่เป็นประโยชน์ในทางปฏิบัติ.

**ฉันควรทำอย่างไรเมื่อคอลัมน์อยู่ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มซีรีส์แม่ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น.