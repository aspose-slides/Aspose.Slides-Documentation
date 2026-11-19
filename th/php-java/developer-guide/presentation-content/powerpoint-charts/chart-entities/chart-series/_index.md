---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย PHP
linktitle: ชุดข้อมูล
type: docs
url: /th/php-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย PHP."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่พล็อตไว้ได้ในเซลล์ของเวิร์กบุ๊กหรือโดยตรงเป็นค่าลิเทรัลเชิงตัวเลข  [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) แทนจุดหนึ่งในชุดนั้น  [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลค่าเริ่มต้น ชื่อชุด, หมวดหมู่, และค่าจุดใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) จากเวิร์กบุ๊กของแผนภูมิ

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป เวิร์กบุ๊กค่าเริ่มต้นใช้แถว 0 สำหรับชื่อชุด, คอลลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด  ดัชนีแผ่นงาน, แถว, และคอลลัมน์ที่ส่งให้ [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) มีค่าเริ่มต้นจากศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลค่าเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับงานนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวดหมู่, และจุดข้อมูลก่อนที่จะเปลี่ยนค่าในเวิร์กบุ๊ก

การตั้งค่าแผนภูมิมีขอบเขตสามแบบ:

- การตั้งค่าระดับชุด เช่น [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) ให้ลักษณะการแสดงผลเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าระดับจุด เช่น [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) ครอบคลุมลักษณะของชุดสำหรับจุดเดียว
- การตั้งค่ากลุ่มนำไปใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) เดียวกัน เข้าไปที่กลุ่มผ่าน [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) เมื่อคุณต้องการกำหนดตัวเลือกเช่น การทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมจุดหรือชุดอย่างชัดเจน สไตล์และธีมของแผนภูมิกำหนดลักษณะอัตโนมัติ  หากมีการฟอร์แมตทั้งชุดและจุดอยู่พร้อมกัน การฟอร์แมตของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

สำหรับแผนภูมิทรงกระบอกแบบจัดกลุ่ม ดูว่า [changing the 3D series type or bar shape](/slides/th/php-java/3d-chart/#change-the-3d-series-type-and-bar-shape) มีผลต่อชุดแรกอย่างไร

## **กำหนดค่าชุดโดยใช้ค่าลิเทรัลเชิงตัวเลข**

ใช้ค่าลิเทรัลเชิงตัวเลขเมื่อค่าชุดมาจากข้อมูลหรือการคำนวนของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ในแผ่นงาน เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) ด้วย [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) ก่อนกำหนดผลลัพธ์ของ [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) ของแต่ละจุดผ่าน [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/)

การตั้งค่าระดับคอลเลกชันควบคุมประเภทแหล่งที่มาของค่าจุดทั้งหมดในชุดนั้น แต่ละค่าจุดจะรายงานประเภทที่เลือกผ่านเมธอด [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) ; เปลี่ยนได้โดยการตั้งค่าที่คอลเลกชัน  หากใช้ `Worksheet` ให้ใช้ [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) เพื่อเข้าถึงเซลล์ที่อ้างอิง  หากใช้ `DoubleLiterals` ให้ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและหมวดหมู่ค่าเริ่มต้น แล้วกำหนดค่าที่คำนวณได้ 10, 20, … ให้กับจุดที่มีอยู่ของชุดแรก  บันทึกงานนำเสนอ เปิดใหม่อีกครั้ง และพิมพ์ค่าที่จัดเก็บ

```php
use aspose\slides\ChartType;
use aspose\slides\DataSourceType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $series->getDataPoints()->setDataSourceTypeForValues(DataSourceType::DoubleLiterals);
    $pointCount = java_values($series->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $series->getDataPoints()->get_Item($i)->getValue()->setAsLiteralDouble(($i + 1) * 10);
    }

    $presentation->save("numeric_literals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    $reopenedSlide = $reopenedPresentation->getSlides()->get_Item(0);
    $reopenedChart = $reopenedSlide->getShapes()->get_Item(0);
    $reopenedSeries = $reopenedChart->getChartData()->getSeries()->get_Item(0);
    $pointCount = java_values($reopenedSeries->getDataPoints()->size());
    for ($i = 0; $i < $pointCount; $i++) {
        $point = $reopenedSeries->getDataPoints()->get_Item($i);
        echo java_values($point->getValue()->getAsLiteralDouble()), PHP_EOL;
    }
} finally {
    $reopenedPresentation->dispose();
}
```

ประเภทแหล่งที่มาของค่าจุดแยกจาก [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) ซึ่งบ่งบอกการกำหนดค่าเวิร์กบุ๊กภายในหรือภายนอกของแผนภูมิ  การใช้ค่าลิเทรัลเชิงตัวเลขไม่ทำให้เวิร์กบุ๊กฝังอยู่หายไป ในตัวอย่างนี้ เวิร์กบุ๊กยังคงใช้สำหรับป้ายกำกับหมวดหมู่, ชื่อชุด, และชุดอื่น ๆ  ดู [Chart Workbook](/slides/th/php-java/chart-workbook/) สำหรับการจัดการเวิร์กบุ๊ก

สำหรับแผนภูมิแบบกระจายและฟอง ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) เพื่อเลือกแหล่งที่มาสำหรับ [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) และ [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/)  แผนภูมิฟองยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/)  ตั้งค่าแหล่งที่มาที่เกี่ยวข้องเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่ากล่านั้น

## **กำหนดค่าการทับซ้อนของชุดแผนภูมิ**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2D ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์  เป็นการฉายอย่างอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่  ใช้ [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น  ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่กระทบต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้กำหนดค่าการทับซ้อนให้กับกลุ่มที่มีชุดแรกอยู่

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

![The series overlap](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) เพื่อกำหนดการเติมเริ่มต้นสำหรับชุดทั้งหมด  หากจุดมีการกำหนดการเติมอย่างชัดเจนแล้ว การตั้งค่า [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) จะครอบคลุมการเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีน้ำเงินทึบให้กับชุดแรก

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

ชื่อชุดถูกจัดเก็บในเวิร์กบุ๊กของแผนภูมิและมักจะแสดงในคำอธิบาย  ในเวิร์กบุ๊กค่าเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบจัดกลุ่ม เซลล์ B1 (แถว 0, คอลลัมน์ 1) จะมีชื่อของชุดแรก  ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) ได้ วิธีนี้ช่วยหลีกเลี่ยงการสันนิษฐานแถวและคอลลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

### **สร้างชุดที่ชื่อมาจากหลายเซลล์**

ชื่อชุดรวมเป็นประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกจัดเก็บในเซลล์เวิร์กบุ๊กแยกกัน  ตัวอย่างเช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวโดยยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นฉบับ

ใช้ [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นให้กับ [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/)  พารามิเตอร์ `skipHiddenCells` ควบคุมว่าความลับของเซลล์ที่ซ่อนไว้จะถูกนับรวมหรือไม่: `true` จะละเว้น, `false` จะรวม  ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีชุดเดียวและจุดข้อมูลสองจุด  เซลล์ B1:C1 ให้เฉพาะชื่อชุด; A2:A3 ให้ป้ายกำกับหมวดหมู่; B2:B3 ให้ค่าตัวเลข

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

    // เซลล์สองเซลล์นี้จัดหาชื่อชุด.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // เซลล์แยกต่างหากจัดหาหมวดหมู่และจุดข้อมูลเชิงตัวเลข.
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

ผลลัพธ์ชื่อชุดคือ `Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์  คำอธิบายจะแสดงเป็นรายการเดียวสำหรับสองคอลลัมน์  ภาพด้านล่างแสดงผลลัพธ์

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ  นี่คือสีที่ใช้เมื่อการเติมของชุดไม่ได้กำหนดอย่างชัดเจน  การเรียกเมธอดนี้เพียงอ่านสีที่คำนวณ ไม่ได้กำหนดการเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดค่าเริ่มต้น

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิค่าเริ่มต้น

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้อาจแตกต่างตามสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับทิศสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และฟอง  [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) สามารถแสดงค่าติดลบด้วยสีเติมที่แตกต่างกัน  ตั้งค่าการเติมของชุดเป็นแบบทึบ, เปิดใช้งานการกลับทิศ, แล้วกำหนดสีค่าติดลบผ่าน [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)  ตัวเลขติดลบยังคงอยู่ในเวิร์กบุ๊ก; มีเพียงสีที่แสดงเปลี่ยนไป

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิค่าเริ่มต้นด้วยชุดเดียว  แถว 0 ของแผ่นงานมีชื่อชุด, คอลลัมน์ 0 มีชื่อหมวดหมู่, คอลลัมน์ 1 มีค่า

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

คุณสามารถเปิดใช้งานการกลับทิศสำหรับจุดเดียวผ่าน [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/)  ในตัวอย่างต่อไปนี้ การกลับทิศถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก  จุดนั้นยังถูกกำหนดค่าติดลบเพื่อให้เห็นผล

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

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ให้กำหนดค่าเซลล์เวิร์กบุ๊กของจุดนั้นเป็น `null`  สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/)  จุดข้อมูลยังคงอยู่ที่ตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบค่าเฉพาะจุดที่สองของชุดแรก

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, แผนภูมิบับก็ใช้เซลล์ขนาดเพิ่มเติม  ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่นไว้ เพราะเมธอดนั้นจะลบจุดทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่แต่มีค่าเป็นกรณีที่แยกจากเซลล์ว่าง  เพื่อรวมหรือแยกข้อมูลจากแถวและคอลลัมน์ที่ซ่อนอยู่ ดู [Include Data from Hidden Rows and Columns](/slides/th/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์เวิร์กบุ๊กที่ว่างเปล่าหมายถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` หมายถึงค่าตัวเลขที่เป็นที่รู้จัก  เรียก [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) ด้วย `null` เพื่อทำให้เซลล์ว่าง  ศูนย์เชิงตัวเลขยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง  การตั้งค่านี้ใช้กับแผนภูมิเพื่อรวมถึงทั้งหมด  มันเปลี่ยนวิธีที่ช่องว่างถูกพล็อตโดยไม่ต้องเติมเซลล์เวิร์กบุ๊กที่ว่างด้วยศูนย์หรือค่าประมาณ

ตัวอย่างอิสระต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดเดียว, ลบค่าของวัน 3, และบันทึกแผนภูมิเดียวกันโดยแต่ละโหมด  ไม่ต้องใช้ไฟล์อินพุต  [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) ใช้แผ่นงาน 0, คอลลัมน์ 0 สำหรับป้ายหมวดหมู่, คอลลัมน์ 1 สำหรับค่า; แถว 0 มีชื่อชุด  ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ทำให้วัน 3 ว่างจริง ๆ ขณะคงหมวดหมู่และจุดข้อมูลไว้.
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

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่ตั้งค่าก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`  หากต้องการบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม  วัน 3 จะเป็นค่าว่างในเวิร์กบุ๊กทุกกรณี

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ  แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย  แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดหมู่ที่หายไป จึง `Span` ไม่สามารถสร้างส่วนเชื่อมได้; คอลัมน์ที่หายไปและคอลัมน์ศูนย์อาจดูคล้ายกัน  เช่นเดียวกัน แผนภูมิกระจายที่มีเพียงตัวชี้ตำแหน่งก็ไม่มีเส้นเชื่อมต่อ  อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **กำหนดค่าความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์  เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดแม่ ไม่ได้เป็นของชุดเดียว  เรียก [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) ครั้งเดียวสำหรับกลุ่ม  ค่าใหญ่จะสร้างช่องว่างระหว่างกลุ่มมากขึ้น, ค่าเล็กจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกงานนำเสนอสุดท้ายเท่านั้น

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

## **แสดงหรือซ่อนเส้นเชื่อมชุด**

เส้นเชื่อมชุดเชื่อมส่วนที่เกี่ยวข้องของแผนภูมิด้วยกัน  ใช้ [ChartSeriesGroup::setSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setserieslines/) เพื่อแสดงหรือซ่อนเส้นเหล่านี้ในแผนภูมิแท่งซ้อนและ OfPie ที่รองรับ  ในแผนภูมิเส้นแท่งและคอลัมน์ซ้อนสองมิติ เส้นเชื่อมจะต่อขอบสแตกที่สอดคล้องกันข้ามหมวดหมู่  ในแผนภูมิ Pie of Pie และ Bar of Pie เส้นเชื่อมจะต่อพล็อตหลักกับพล็อตรอง  การตั้งค่านี้ไม่ได้เป็นตัวเชื่อมทั่วไปสำหรับประเภทแผนภูมิอื่น

เข้าถึงกลุ่มผ่าน [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/)  การตั้งค่านี้ใช้กับทุกชุดในกลุ่มนั้น  [ChartSeries::hasSeriesLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/hasserieslines/) เป็นการอ่านอย่างเดียวและสะท้อนการตั้งค่าของกลุ่มแม่; เรียก setter ของกลุ่มเพื่ออัปเดต

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [ChartType::PieOfPie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) หนึ่งอันด้วยข้อมูลค่าเริ่มต้น  บันทึกแผนภูมิเดียวกันโดยเปิดและปิดเส้นเชื่อมชุด เพื่อเปรียบเทียบสองงานนำเสนอ

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $seriesGroup = $series->getParentSeriesGroup();

    $seriesGroup->setSeriesLines(true);
    $presentation->save("series_lines_enabled.pptx", SaveFormat::Pptx);

    $seriesGroup->setSeriesLines(false);
    $presentation->save("series_lines_disabled.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| เส้นเชื่อมเปิด | เส้นเชื่อมปิด |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| เส้นสองเส้นเชื่อมพายหลักกับพายรอง | พายทั้งสองยังคงมองเห็นได้ แต่เส้นเชื่อมถูกซ่อน |

เส้นเชื่อมชุดแตกต่างจากเส้นนำของป้ายข้อมูลที่เชื่อมป้ายกับจุดข้อมูล; เส้นกริดที่ทำเครื่องหมายช่วงบนแกนแผนภูมิ; และเส้นในแผนภูมิเส้นที่แสดงค่าข้อมูล การตั้งค่านี้ไม่ได้ควบคุมองค์ประกอบเหล่านั้น

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดของแต่ละประเภทไม่ได้มีโครงสร้างหรือการตั้งค่าเดียวกัน  ตัวอย่างเช่น แผนภูมิมากประเภทใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิบับเพิ่มขนาดฟอง  ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด  ตัวเลือกเช่น การทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มแท่งหรือคอลัมน์ที่เข้ากัน

**กลุ่มชุดแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม  แผนภูมิกลุ่มสามารถมีหลายกลุ่มได้ ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดหนึ่งจึงไม่จำเป็นต้องเปลี่ยนแปลงทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลค่าเริ่มต้นหรือไม่?**

มี  โดยค่าเริ่มต้น [ShapeCollection::addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่  อีกหนึ่ง overload สามารถสร้างแผนภูมิโดยไม่มีข้อมูลค่าเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์เวิร์กบุ๊กอย่างไร?**

ชื่อชุด, ป้ายกำกับหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)  การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมที่สอดคล้องกัน  เมื่อคุณสร้างข้อมูลแบบกำหนดเอง ให้จัดแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ใต้หมวดหมู่ที่ต้องการ

**ฉันจะลบจุดเดียวแทนการลบชุดทั้งหมดได้อย่างไร?**

กำหนดค่าเซลล์ที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง  ใช้ [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย ให้ปรับทุกชุดเพื่อให้ค่าของพวกเขายังสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/)  แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมจุดใกล้เคียง  เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ  ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างและเปรียบเทียบภาพเต็มรูป

**ค่าติดลบถูกฟอร์แมตอย่างไร?**

สำหรับชุดแท่ง, คอลัมน์, และฟองที่รองรับ ให้เรียก [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) และกำหนดสีที่ได้จาก [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/)  คุณสามารถครอบคลุมพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/)  วิธีเหล่านี้มีผลต่อการฟอร์แมต ไม่ใช่ค่าตัวเลขที่จัดเก็บ

**การฟอร์แมตใดชนะเมื่อทั้งชุดและจุดได้รับการฟอร์แมต?**

การฟอร์แมตจุดโดยชัดเจนมีลำดับความสำคัญสำหรับจุดนั้น  จุดอื่น ๆ จะใช้ฟอร์แมตชุดที่กำหนดหรือถ้าชุดไม่มีการฟอร์แมต ระบบจะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ  การตั้งค่ากลุ่มเช่น การทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การฟอร์แมตระดับจุด

**มีขีดจำกัดจำนวนชุดที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดอย่างแยกจากกัน  อย่างไรก็ตาม ข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่เป็นประโยชน์ในทางปฏิบัติ

**ฉันควรเปลี่ยนอะไรเมื่อคอลลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) บนกลุ่มชุดแม่ที่เหมาะสม  เพิ่มค่าจะเพิ่มช่องว่างระหว่างกลุ่ม, ลดค่าจะทำให้กลุ่มอยู่ใกล้กันมากขึ้น