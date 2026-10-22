---
title: จัดการ Series ข้อมูลแผนภูมิในงานนำเสนอด้วย PHP
linktitle: Series ข้อมูล
type: docs
url: /th/php-java/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การทับซ้อนของซีรีส์
- สีของซีรีส์
- ชื่อซีรีส์
- จุดข้อมูล
- เซลล์เวิร์กบุ๊ค
- ช่องว่างของซีรีส์
- ค่าลบ
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการ series แผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ค, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าลบในงานนำเสนอด้วย PHP."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่แสดงผลไว้ในเซลล์ของ workbook หรือโดยตรงเป็นค่าตัวเลขลิเตอร์ได้ อ็อบเจกต์ [ChartSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/) แสดงถึงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/) แสดงถึงจุดหนึ่งในชุดนั้น อ็อบเจกต์ [ChartCategory](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/) ให้ป้ายกำกับหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุดข้อมูล, ประเภท, และค่าจุดจะใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/) จาก workbook ของแผนภูมิ

สำหรับแผนภูมิประเภทหมวดทั่วไป workbook เริ่มต้นใช้แถว 0 สำหรับชื่อชุดข้อมูล, คอลัมน์ 0 สำหรับชื่อหมวด, และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนี worksheet, แถว, และคอลัมน์ที่ส่งให้ [ChartDataWorkbook::getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) เป็นดัชนีเริ่มจากศูนย์ การจัดวางนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทั้งหมดใช้วิธีนี้ สำหรับงานนำเสนอที่โหลดมาแล้ว ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุดข้อมูล, หมวด, และจุดข้อมูลก่อนที่จะเปลี่ยนค่าใน workbook

การตั้งค่าแผนภูมิมีสามระดับที่ต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในชุดเดียว
- การตั้งค่าระดับจุดข้อมูล เช่น [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) จะเขียนทับลักษณะของชุดสำหรับจุดเดียว
- การตั้งค่ากลุ่มจะใช้กับชุดข้อมูลที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries::getParentSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getparentseriesgroup/) เมื่อคุณต้องการตั้งค่าเช่นการทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดข้อมูลอย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีการกำหนดทั้งลักษณะของชุดและจุด การกำหนดลักษณะของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **กำหนดค่า Series ด้วยค่าตัวเลขลิเตอร์**

ใช้ค่าตัวเลขลิเตอร์เมื่อค่าชุดข้อมูลมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ worksheet เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) ด้วย [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/php-java/aspose.slides/datasourcetype/) ก่อนกำหนดผลลัพธ์ของแต่ละจุดด้วย [getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) ผ่าน [setAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/setasliteraldouble/)

การตั้งค่าคอลเลกชันควบคุมชนิดของแหล่งค่าของทุกจุดในชุดนั้น วิธี [getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/basechartvalue/) ของแต่ละจุดจะรายงานชนิดที่เลือก; เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน ในกรณี `Worksheet` ใช้ [getAsCell](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getascell/) เพื่อเข้าถึงเซลล์ที่อ้างอิง ในกรณี `DoubleLiterals` ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/php-java/aspose.slides/doublechartvalue/getasliteraldouble/) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและหมวดเริ่มต้น แล้วกำหนดค่าที่คำนวณได้ 10, 20, ฯลฯ ให้กับจุดที่มีอยู่ของชุดแรก มันทำการบันทึกรายการงาน, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่เก็บไว้

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

ชนิดแหล่งค่าของจุดแยกจาก [ChartData::getDataSourceType](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/) ซึ่งบ่งบอกการกำหนดค่า workbook ภายในหรือภายนอกของแผนภูมิ การใช้ค่าตัวเลขลิเตอร์ไม่ทำให้ workbook ที่ฝังอยู่หายไป ในตัวอย่างนี้ workbook ยังคงใช้ได้สำหรับป้ายกำกับหมวด, ชื่อชุดข้อมูล, และชุดอื่น ๆ ดูที่ [Workbook ของแผนภูมิ](/slides/th/php-java/chart-workbook/) เพื่อการจัดการ workbook

สำหรับแผนภูมิกระจายและฟองอากาศ ให้ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) เพื่อเลือกแหล่งสำหรับ [getXValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getxvalue/) และ [getYValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getyvalue/) แผนภูมิฟองอากาศยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getbubblesize/) ตั้งค่าแหล่งที่ใช้เป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่านั้น

## **กำหนดการทับซ้อนของ Series**

[ChartSeries::getOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getoverlap/) รายงานว่าคอลัมน์หรือแท่งบาร์ทับซ้อนกันเท่าใดในแผนภูมิ 2 มิติ จาก -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มชุดแม่ ใช้ [ChartSeriesGroup::setOverlap](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setoverlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงคอลัมน์หรือแท่งเป็นกลุ่ม; ไม่กระทบต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิกล่องรวม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดแรกอยู่

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

## **เปลี่ยนสีเติมของ Series**

ใช้ [ChartSeries::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getformat/) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับทั้งชุด หากจุดมีการเติมสีเฉพาะแล้ว การตั้งค่า [ChartDataPoint::getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getformat/) จะเขียนทับการเติมสีของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีฟ้าโซลิดเติมให้กับชุดแรก

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

## **เปลี่ยนชื่อ Series**

ชื่อชุดถูกเก็บใน workbook ของแผนภูมิและโดยปกติจะแสดงใน legend ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries::getName](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getname/) วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

### **สร้าง Series ด้วยชื่อจากหลายเซลล์**

ชื่อชุดแบบผสมเป็นประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานเก็บในเซลล์ workbook แยกกัน ตัวอย่างเช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวขณะยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทาง

ใช้ [ChartDataWorkbook::getCellCollection](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcellcollection/) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นให้กับ [ChartSeriesCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/add/) พารามิเตอร์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ซ่อนหรือไม่: `true` ไม่รวม, `false` รวม ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีชุดหนึ่งและจุดข้อมูลสองจุด เซลล์ B1:C1 มีเพียงชื่อชุด; A2:A3 มีป้ายหมวด, B2:B3 มีค่าตัวเลข

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

    // เซลล์สองนี้ให้ชื่อซีรีส์.
    $workbook->getCell(0, 0, 1, "Product A");
    $workbook->getCell(0, 0, 2, "2026");
    $nameCells = $workbook->getCellCollection('Sheet1!$B$1:$C$1', false);
    $series = $chart->getChartData()->getSeries()->add($nameCells, ChartType::ClusteredColumn);

    // เซลล์แยกต่างหากให้หมวดและจุดข้อมูลเชิงตัวเลข.
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

ชื่อชุดที่ได้คือ `Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์ legend แสดงเป็นรายการเดียวสำหรับคอลัมน์ทั้งสอง รูปด้านล่างแสดงผลลัพธ์

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของ Series**

[ChartSeries::getAutomaticSeriesColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมสีของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดจะอ่านสีที่คำนวณ ไม่ได้กำหนดการเติมสีใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้อาจแตกต่างกันตามสไตล์และธีมของแผนภูมิ

## **กำหนดสีเติมกลับสำหรับ Series**

สำหรับชุดแบบแท่ง, คอลัมน์, และฟองอากาศ, [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) สามารถแสดงค่าลบด้วยสีเติมที่แตกต่าง ตั้งการเติมสีปกติเป็นโซลิด, เปิดการกลับสี, และกำหนดสีค่าลบผ่าน [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) ตัวเลขลบจะคงอยู่ใน workbook; เพียงสีแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิกับชุดเดียว Worksheet แถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวด, คอลัมน์ 1 มีค่า

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

คุณสามารถเปิดการกลับสีสำหรับจุดเดียวผ่าน [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) ตัวอย่างต่อไปนี้ปิดการกลับสีสำหรับชุดและเปิดเฉพาะจุดที่เลือก จุดนั้นยังได้รับค่าลบเพื่อให้เห็นผล

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

## **ลบค่า Data Point เฉพาะ**

เพื่อให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ workbook ที่อยู่หลังจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่ถูกพล็อตได้จาก [ChartDataPoint::getValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getvalue/) จุดข้อมูลจะคงตำแหน่งหมวดเดิม แต่แผนภูมิจะแบ่งค่าเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองของชุดแรก

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, แผนภูมิฟองอากาศยังใช้เซลล์ขนาดด้วย ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) เมื่อคุณต้องการคงจุดอื่นไว้ เพราะเมธอดนั้นจะลบทุกจุดในคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนแต่มีค่าเป็นกรณีแยกจากเซลล์ว่าง เพื่อรวมหรือไม่รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน ให้ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/php-java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ว่างแสดงว่าข้อมูลหายไป; เซลล์ที่มีค่า `0` แสดงว่ามีค่าตัวเลขที่รู้จัก เรียก [ChartDataCell::setValue](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/setvalue/) ด้วย `null` เพื่อทำให้เซลล์เป็นค่าว่าง ศูนย์ตัวเลขยังคงเป็นศูนย์ไม่ว่าการตั้งค่าความว่างของเซลล์จะเป็นอย่างไร

ใช้ [Chart::setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด จะเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่เติมค่าใน workbook ด้วยศูนย์หรือค่าที่ประมาณ

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดหนึ่ง, ลบค่าของ Day 3, แล้วบันทึกแผนภูมิเดียวกันด้วยแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวด, คอลัมน์ 1 สำหรับค่า; แถว 0 มีชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ปล่อยให้วัน 3 เป็นค่าว่างจริง ๆ แต่ยังคงหมวดและจุดข้อมูลไว้
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

ไฟล์ผลลัพธ์แต่ละไฟล์จะเก็บโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปหลายโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์ Day 3 เป็นค่าว่างใน workbook ในทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทของแผนภูมิ แผนภูมิเส้นทำให้สามโหมดง่ายต่อการเปรียบเทียบ แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดที่หายไป จึงทำให้ `Span` ไม่สามารถสร้างส่วนเชื่อมต่อได้; คอลัมน์ที่หายไปและคอลัมน์ศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์ไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **กำหนดความกว้างของช่องว่างระหว่าง Series**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดแม่ไม่ใช่ของชุดเดี่ยว เรียก [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) หนึ่งครั้งสำหรับกลุ่ม ค่าเพิ่มจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น; ค่าเล็กจะทำให้กลุ่มหนาแน่นขึ้น

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

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุน Series?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ Series ของพวกมันไม่ทั้งหมดมีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิหมวดใช้หมวดและค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิฟองอากาศเพิ่มขนาดฟอง ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทของ Series ตัวเลือกเช่นการทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มแท่งหรือคอลัมน์ที่เข้ากันได้

**Series Group คืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/) ประกอบด้วย Series ที่เข้ากันได้และแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิกล่องรวมสามารถมีหลายกลุ่มได้ ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านหนึ่ง Series ไม่ได้จำเป็นต้องเปลี่ยนทุก Series ในแผนภูมิ

**แผนภูมิใหม่ที่สร้างขึ้นมีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยปกติ [ShapeCollection.addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) จะสร้าง Series, Category, และค่าอย่างตัวอย่าง คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งคอลเลกชัน Series และ Category ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่ overload บางตัวยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้

**แผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อ Series, ป้ายหมวด, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลกำหนดเอง ให้รักษาแถวหมวดและแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดที่ต้องการ

**จะลบจุดเดียวแทนการลบทั้ง Series อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดของจุดให้อยู่เป็นจุดว่าง ใช้ [ChartDataPointCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบทุกจุดจาก Series นั้น หากคุณลบหมวดด้วย ควรอัปเดตทุก Series เพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวด

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setdisplayblanksas/) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มรูปแบบและการเปรียบเทียบภาพ

**ค่าลบถูกจัดรูปแบบอย่างไร?**

สำหรับ Series แบบแท่ง, คอลัมน์, และฟองอากาศ ให้เรียก [ChartSeries::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setinvertifnegative/) แล้วตั้งค่าสีที่ได้จาก [ChartSeries::getInvertedSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getinvertedsolidfillcolor/) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint::setInvertIfNegative](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setinvertifnegative/) วิธีเหล่านี้มีผลต่อการจัดรูปแบบ ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้

**เมื่อทั้ง Series และ Point มีการจัดรูปแบบ ใครชนะ?**

การจัดรูปแบบจุดข้อมูลโดยเฉพาะจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ จะใช้การจัดรูปแบบของ Series หากกำหนดไว้, หรือหากไม่ได้กำหนดจะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การเขียนทับระดับจุด

**มีขีดจำกัดจำนวน Series ที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวน Series แบบแยก อย่างไรก็ตามขีดจำกัดจริงจะขึ้นกับข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรทำอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup::setGapWidth](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setgapwidth/) บนกลุ่ม Series แม่ที่เหมาะสม เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น