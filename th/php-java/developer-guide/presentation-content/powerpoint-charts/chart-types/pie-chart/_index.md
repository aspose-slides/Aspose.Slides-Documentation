---
title: ปรับแต่งแผนภูมิวงกลมในการนำเสนอด้วย PHP
linktitle: แผนภูมิวงกลม
type: docs
url: /th/php-java/pie-chart/
keywords:
- แผนภูมิวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีส่วนแผนภูมิ
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิวงกลมใน PHP ด้วย Aspose.Slides กำหนดค่าพล็อตรอง แสดงป้ายข้อมูล และใช้สีส่วนอัตโนมัติใน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลมใน Aspose.Slides โดยแสดงวิธีการกำหนดค่าตัวเลือกการพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีเปิดใช้งานการกำหนดสีอัตโนมัติให้กับส่วนของแผนภูมิวงกลมปกติ.

ตัวอย่างจะเน้นที่งานปรับแต่งแผนภูมิเช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับค่า series และการตั้งค่าป้ายกำกับ การเปลี่ยนข้อมูลแผนภูมิเริ่มต้นเป็นหมวดหมู่และค่าที่กำหนดเอง และการบันทึกการนำเสนอที่อัปเดต.

## **ตัวเลือกการพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for PHP via Java รองรับตัวเลือกการพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie ตัวเลือกเหล่านี้ควบคุมขนาดของพล็อตรองและวิธีการแยกจุดข้อมูลระหว่างพล็อตทั้งสอง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ Pie of Pie ในการนำเสนอใหม่และแสดงค่าจุดข้อมูลเป็นป้ายกำกับ. เมธอด [setSecondPieSize](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setSecondPieSize) กำหนดขนาดพล็อตรองเป็น 149% ของพล็อตหลัก. [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) เลือกการแยกรูปแบบตามเปอร์เซ็นต์ และ [setPieSplitPosition](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) กำหนดค่าขีดจำกัดเป็น 53%.

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries()->get_Item(0);

    // แสดงค่าและกำหนดค่าพล็อตรอง
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setSecondPieSize(149);
    $seriesGroup->setPieSplitBy(PieSplitType::ByPercentage);
    $seriesGroup->setPieSplitPosition(53);

    $presentation->save("pie_of_pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **เลือกหมวดหมู่สำหรับพล็อตรอง**

ใช้การแยกแบบกำหนดเองเมื่อคุณต้องการจัดกลุ่มหมวดหมู่เฉพาะในพล็อตรองโดยไม่คำนึงถึงค่าเปอร์เซ็นต์ของพวกมัน. ตัวอย่างเช่น รายงานการขายอาจแสดง Online และ Events ร่วมกันเพื่อให้ผู้อ่านสามารถเปรียบเทียบช่องทางทั้งสอง แม้ว่าพวกมันจะเป็น 35% และ 10% ของยอดขายรวม.

เรียกใช้ [setPieSplitBy](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setPieSplitBy) พร้อมกับ [PieSplitType::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/piesplittype/) และเลือกจุดผ่าน [getPieSplitCustomPoints](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). วิธีการ [add](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#add) ของคอลเลกชันรับดัชนีเริ่มจากศูนย์ใน series; ใช้ [addItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#addItem) เพื่อเพิ่มวัตถุข้อมูลจุด ในตัวอย่างนี้ ดัชนี 1 เลือก Online และจุดที่ดัชนี 3 เลือก Events Partners ถูกเพิ่มชั่วคราวแล้วจึงถูกตัดออกโดยใช้ [removeItem](https://reference.aspose.com/slides/php-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```php
use aspose\slides\ChartType;
use aspose\slides\PieSplitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 600, 200);

    // แทนที่ข้อมูลเริ่มต้นด้วยยอดขายตามช่องทาง.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    $values = [ 40, 35, 15, 10 ];
    $seriesNameCell = $workbook->getCell(0, 0, 1, "Sales");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $seriesGroup = $series->getParentSeriesGroup();
    $seriesGroup->setPieSplitBy(PieSplitType::Custom);
    $seriesGroup->setColorVaried(true);

    // เลือก Online ตามดัชนีเริ่มจากศูนย์และ Events ตามอ็อบเจกต์จุดข้อมูล.
    $seriesGroup->getPieSplitCustomPoints()->add(1);
    $seriesGroup->getPieSplitCustomPoints()->addItem($series->getDataPoints()->get_Item(3));

    // ลบ Partners ออกจากการเลือกโดยไม่ลบข้อมูลต้นทาง.
    $seriesGroup->getPieSplitCustomPoints()->add(2);
    $seriesGroup->getPieSplitCustomPoints()->removeItem($series->getDataPoints()->get_Item(2));

    $presentation->save("pie_of_pie_custom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Online (35) และ Events (10) ปรากฏเป็นส่วนแยกในพล็อตรอง ในพล็อตหลัก พวกมันจะรวมเป็นส่วนเดียวที่มีค่า 45 พร้อมกับ Retail (40) และ Partners (15) การลบ Partners จากการเลือกแบบกำหนดเองทำให้มันยังคงอยู่ในพล็อตหลัก; ไม่ได้ลบหมวดหมู่หรือค่าของมันจากข้อมูลต้นฉบับของแผนภูมิ.

ภาพต่อไปนี้แสดงการบันทึกการนำเสนอใน PowerPoint:

![แผนภูมิ Pie of Pie ที่มี Online และ Events ในพล็อตรองและค่ารวมของพวกมันคือ 45 ในพล็อตหลัก](pie_of_pie_custom.png)

## **ตั้งค่าสีส่วนของแผนภูมิวงกลมอัตโนมัติ**

Aspose.Slides for PHP via Java สามารถกำหนดสีที่แตกต่างให้กับส่วนของแผนภูมิวงกลมโดยอัตโนมัติ ตัวอย่างต่อไปนี้สร้างแผนภูมิวงกลมที่มีหัวข้ออยู่กึ่งกลางและแทนที่ข้อมูลเริ่มต้นด้วยสามหมวดไตรมาสและค่าของพวกมัน เมธอด [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) จะแสดงค่าที่ 20, 50, และ 30 เป็นป้ายกำกับ ในขณะที่ [setColorVaried](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/#setColorVaried) เปิดใช้งานสีที่แตกต่างสำหรับแต่ละส่วน.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);

    // เพิ่มหัวเรื่องแผนภูมิที่อยู่กึ่งกลาง.
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    // แทนที่ข้อมูลเริ่มต้นโดยใช้แผ่นงานแรก.
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    $values = [ 20, 50, 30 ];
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    for ($i = 0; $i < count($categoryNames); $i++) {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categoryNames[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    }

    // แสดงค่าและกำหนดสีที่แตกต่างให้กับส่วนต่าง ๆ ของแผนภูมิ.
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getParentSeriesGroup()->setColorVaried(true);

    $presentation->save("pie.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **คำถามที่พบบ่อย**

**รองรับรูปแบบ Pie of Pie และ Bar of Pie หรือไม่?**

ใช่, ไลบรารี [รองรับ](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) พล็อตรองสำหรับแผนภูมิวงกลมรวมถึงประเภท Pie of Pie และ Bar of Pie.

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ได้, คุณสามารถ [ส่งออกแผนภูมิเป็นภาพ](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) (เช่น PNG) โดยไม่ต้องส่งออกการนำเสนอทั้งหมด.