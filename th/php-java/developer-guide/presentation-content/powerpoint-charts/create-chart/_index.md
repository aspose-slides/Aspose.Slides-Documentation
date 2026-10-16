---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ใน PHP
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/php-java/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิเวงกลม
- แผนภูมิเส้น
- แผนภูมิเพาต์แมพ
- แผนภูมิตลาดหุ้น
- แผนภูมิกล่องและวิสเกอร์
- แผนภูมิกรวย
- แผนภูมิรังสี
- แผนภูมิฮิสโตแกรม
- แผนภูมิเรดาร์
- แผนภูมิหลายหมวด
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดเชิงปฏิบัติใน PHP."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for PHP via Java คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์แบบโปรแกรม, เติมข้อมูลเข้าไป, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ ให้ตรงกับความต้องการออกแบบของคุณ ตลอดบทความจะมีตัวอย่างโค้ดละเอียดที่แสดงขั้นตอนแต่ละขั้นตอน ตั้งแต่การสร้าง Presentation และออบเจ็กต์แผนภูมิ ไปจนถึงการกำหนดซีรีส์, แกน, และคีย์ลิเคิล โดยการทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีการรวมการสร้างแผนภูมิแบบไดนามิกเข้าไปในแอปพลิเคชัน PHP ของคุณ ได้อย่างราบรื่นและประหยัดเวลาในการสร้างงานนำเสนอที่ใช้ข้อมูลเป็นฐาน

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้คนมองเห็นข้อมูลได้อย่างรวดเร็วและค้นพบข้อสรุปที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

โดยใช้แผนภูมิ คุณสามารถ:

* รวม, ย่อลง, หรือสรุปข้อมูลปริมาณมากในสไลด์เดียวของงานนำเสนอ;
* เปิดเผยรูปแบบและแนวโน้มในข้อมูล;
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดที่กำหนด;
* ตรวจจับค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่สมเหตุสมผล;
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งให้เทมเพลตสำหรับออกแบบแผนภูมิต่าง ๆ ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิสแตนดาร์ด (อิงตามประเภทแผนภูมิที่นิยม) และแผนภูมิที่กำหนดเองได้ทั้งสองแบบ

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ในเนมสเปซ [aspose\slides](https://reference.aspose.com/slides/php-java/aspose.slides/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิที่แตกต่างกัน
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิคอลัมน์แบบกลุ่มที่เปรียบเทียบสองซีรีส์ในสามหมวดหมู่ ซีรีส์ใช้สีเติมแดงและสีเขียวและป้ายกำกับแต่ละรายการแสดงชื่อหมวดหมู่, ชื่อซีรีส์, และค่า ดัชนี Worksheet 0 หมายถึงแผ่นแรกในเวิร์กบุ๊กแผนภูมิที่ฝังอยู่

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 128, 0);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $label = $series->getDataPoints()->get_Item(0)->getLabel();
    $label->getDataLabelFormat()->setShowCategoryName(true);

    $label = $series->getDataPoints()->get_Item(1)->getLabel();
    $label->getDataLabelFormat()->setShowSeriesName(true);

    $label = $series->getDataPoints()->get_Item(2)->getLabel();
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setShowSeriesName(true);
    $label->getDataLabelFormat()->setSeparator("/");

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิคอลัมน์แบบกลุ่ม](clustered_column_chart.png)

### **สร้างแผนภูมิกระจาย (Scatter)**

แผนภูมิกระจาย (หรือที่เรียกว่ากราฟสแคตเทอร์หรือกราฟ x‑y) มักใช้เพื่อค้นหารูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิกระจายเมื่อ:

* คุณมีข้อมูลเชิงตัวเลขเป็นคู่;
* มีสองตัวแปรที่สัมพันธ์กันอย่างดี;
* คุณต้องการตรวจสอบว่าตัวแปรทั้งสองมีความสัมพันธ์หรือไม่;
* มีตัวแปรอิสระที่มีค่าหลายค่าเพื่อกำหนดค่าตัวแปรตาม

ตัวอย่างนี้พล็อตค่าชุด x‑y สองชุด ชุดแรกใช้เส้นตรงกับเครื่องหมายดาว และชุดที่สองใช้เส้นโค้งกับเครื่องหมายวงกลม; ทั้งสองใช้ขนาดเครื่องหมาย 10 โดยกำหนดผ่าน [setSize](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsize/) วิธี [setSymbol](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsymbol/) ควบคุมรูปทรงเครื่องหมาย

```php
use aspose\slides\ChartType;
use aspose\slides\MarkerStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 20, 20, 500, 300);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();

    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 1, "Series 1");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());
    $seriesNameCell = $workbook->getCell($worksheetIndex, 1, 3, "Series 2");
    $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series = $chart->getChartData()->getSeries()->get_Item(0);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 1, 1);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 2, 3);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 1, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 2, 10);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);

    $series = $chart->getChartData()->getSeries()->get_Item(1);

    $xValueCell = $workbook->getCell($worksheetIndex, 2, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 2, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 3, 3, 3);
    $yValueCell = $workbook->getCell($worksheetIndex, 3, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 4, 3, 2);
    $yValueCell = $workbook->getCell($worksheetIndex, 4, 4, 2);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $xValueCell = $workbook->getCell($worksheetIndex, 5, 3, 5);
    $yValueCell = $workbook->getCell($worksheetIndex, 5, 4, 1);
    $series->getDataPoints()->addDataPointForScatterSeries($xValueCell, $yValueCell);

    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิกระจาย](scatter_chart.png)

### **สร้างแผนภูมิวงกลม (Pie)**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายกำกับเชิงหมวดหมู่พร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือป้ายกำกับจำนวนมาก คุณอาจพิจารณาใช้แผนภูมิแท่งแทน

ตัวอย่างนี้สร้างแผนภูมิวงกลมที่มีค่าครึ่งปีสามค่า แต่ละชิ้นมีการเติมสีและขอบที่กำหนดเองและป้ายกำกับแสดงการรวมค่าต่าง ๆ, เปอร์เซ็นต์, และข้อมูลซีรีส์ วิธี [setFirstSliceAngle](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) กำหนดให้ชิ้นแรกเริ่มที่ 180 องศา

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Pie, 20, 20, 500, 300);

    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);

    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $categoryCell = $workbook->getCell(0, 1, 0, "1st Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "2nd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "3rd Qtr");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 20);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 50);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 30);
    $series->getDataPoints()->addDataPointForPieSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);

    $firstSlice = $series->getDataPoints()->get_Item(0);
    $firstSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 255, 255);
    $firstSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $firstSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 128, 128, 128);
    $firstSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $firstSlice->getFormat()->getLine()->setWidth(3.0);
    $firstSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThick);
    $firstSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDash);

    $secondSlice = $series->getDataPoints()->get_Item(1);
    $secondSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 165, 42, 42);
    $secondSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $secondSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 0, 0, 255);
    $secondSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $secondSlice->getFormat()->getLine()->setWidth(3.0);
    $secondSlice->getFormat()->getLine()->setStyle(LineStyle::Single);
    $secondSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDot);

    $thirdSlice = $series->getDataPoints()->get_Item(2);
    $thirdSlice->getFormat()->getFill()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 127, 80);
    $thirdSlice->getFormat()->getFill()->getSolidFillColor()->setColor($color);

    $thirdSlice->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 255, 0, 0);
    $thirdSlice->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor($color);
    $thirdSlice->getFormat()->getLine()->setWidth(2.0);
    $thirdSlice->getFormat()->getLine()->setStyle(LineStyle::ThinThin);
    $thirdSlice->getFormat()->getLine()->setDashStyle(LineDashStyle::LargeDashDotDot);

    $firstLabel = $series->getDataPoints()->get_Item(0)->getLabel();
    $firstLabel->getDataLabelFormat()->setShowValue(true);

    $secondLabel = $series->getDataPoints()->get_Item(1)->getLabel();
    $secondLabel->getDataLabelFormat()->setShowValue(true);
    $secondLabel->getDataLabelFormat()->setShowLegendKey(true);
    $secondLabel->getDataLabelFormat()->setShowPercentage(true);

    $thirdLabel = $series->getDataPoints()->get_Item(2)->getLabel();
    $thirdLabel->getDataLabelFormat()->setShowSeriesName(true);
    $thirdLabel->getDataLabelFormat()->setShowPercentage(true);

    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);

    $presentation->save("PieChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิวงกลม](pie_chart.png)

เพื่อปรับปรุงความชัดเจนของป้ายกำกับที่อยู่นอกวงกลม ดูตัวอย่าง [Format Leader Lines](/slides/th/php-java/chart-data-label/#format-leader-lines) เพื่อจัดตำแหน่งป้ายกำกับและกำหนดสี, ความกว้าง, ความโปร่งแสง, และรูปแบบเส้นของเส้นนำ

### **สร้างแผนภูมิเส้น (Line)**

แผนภูมิเส้น (หรือกราฟเส้น) เหมาะกับสถานการณ์ที่ต้องการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ด้วยแผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นค่านอกมาตรฐานในซีรีส์ข้อมูล, ฯลฯ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิเส้นด้วยซีรีส์และหมวดหมู่เริ่มต้น แล้วบันทึกเป็น PPTX

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    $presentation->save("lineChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

โดยปกติ จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นประ ให้เรียกใช้ [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) พร้อมค่าจาก [LineDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/):

```php
use aspose\slides\ChartType;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $lineChart = $slide->getShapes()->addChart(ChartType::Line, 20, 20, 500, 300);

    for ($i = 0; $i < java_values($lineChart->getChartData()->getSeries()->size()); $i++)
    {
        $series = $lineChart->getChartData()->getSeries()->get_Item($i);
        $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิเส้น](line_chart.png)

### **สร้างแผนภูมิแผนที่ต้นไม้ (Tree Map)**

แผนภูมิแผนที่ต้นไม้เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่มีส่วนร่วมมากในแต่ละหมวดหมู่

ตัวอย่างนี้สร้างแผนภูมิต้นไม้ที่มีใบแปดใบจัดกลุ่มเป็นสเต็มสี่และสาขาสองโดยใช้วิธี [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) เพื่อกำหนดสเต็มที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ค่าต่าง ๆ กำหนดขนาดสี่เหลี่ยมสัมพัทธ์ ในขณะที่ป้ายกำกับหมวดและป้ายกำกับพาเรนท์ที่ซ้อนกันบ่งบอกลำดับชั้น

```php
use aspose\slides\ChartType;
use aspose\slides\ParentLabelLayoutType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Treemap, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // สาขา 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // สาขา 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);

    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);

    $presentation->save("Treemap.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิแผนที่ต้นไม้](treemap_chart.png)

### **สร้างแผนภูมิไดอาโมด์ (Waterfall)**

แผนภูมิโดดเด่น (Waterfall) แสดงว่าการเปลี่ยนแปลงบวกและลบส่งผลต่อค่าท้ายสุดอย่างไร ตัวอย่างเช่น การสรุปกำไรสามารถเริ่มด้วยรายได้, ลบต้นทุน, แล้วบวกรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงลอยระหว่างค่าก่อนหน้าและค่าปัจจุบัน ในขณะที่คอลัมน์รวมขยายจากศูนย์ถึงค่าที่สะสม

ตัวอย่างต่อไปนี้ใช้จำนวนเป็นพันดอลลาร์สหรัฐ:

| หมวด | ค่าในเวิร์กบุ๊ก | ชนิดคอลัมน์ |
| --- | ---: | --- |
| รายได้ | 1000 | เพิ่ม |
| ต้นทุนขาย | -400 | ลด |
| กำไรขั้นต้น | 600 | รวมระหว่าง |
| ค่าใช้จ่ายในการดำเนินงาน | -200 | ลด |
| รายได้อื่น | 50 | เพิ่ม |
| กำไรสุทธิ | 450 | รวมสุดท้าย |

เพื่อกำหนดจุดเป็นรวมระหว่างหรือรวมสุดท้าย ให้เรียกวิธี [setSetAsTotal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setsetastotal/) ของจุดนั้นด้วย `true` และใส่ค่าที่สะสมจริงในเซลล์เวิร์กบุ๊กของจุดนั้น: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`) วิธีนี้ทำเครื่องหมายคอลัมน์ว่าเป็นรวม; มันไม่ได้คำนวณหรือเติมค่าเซลล์ อย่าใช้ศูนย์เป็นเพลสโฮลเดอร์ หรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดรวม คอลัมน์รวมจะแสดงค่าที่สะสมโดยไม่เพิ่มอีกครั้งต่อค่าไหล

ตัวอย่าง PHP ครบชุดนี้สร้างแผนภูมิด้วยสมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), ลบข้อมูลเริ่มต้น, แล้วเติมข้อมูลในเวิร์กบุ๊กที่ฝังอยู่ ดัชนี Worksheet `0` เลือกเวิร์กชีตแรก; คอลัมน์ A มีชื่อหมวด, คอลัมน์ B มีค่า แต่ละเซลล์ค่าถูกเพิ่มด้วย [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/) ดัชนีจุดที่เริ่มจากศูนย์ `2` และ `5` ระบุรวมระหว่างและรวมสุดท้าย การเรียก [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) ด้วย `true` แสดงจำนวนบนคอลัมน์ ไม่จำเป็นต้องมี Presentation หรือเวิร์กบุ๊กเข้า

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Waterfall, 20, 20, 680, 200);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Profit breakdown (USD thousands)");
    $chart->getChartTitle()->setOverlay(false);
    $chart->setLegend(false);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $workbook->clear($worksheetIndex);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Profit");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Waterfall);
    $categories = [ "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" ];
    $values = [ 1000, -400, 600, -200, 50, 450 ];

    for ($i = 0; $i < count($categories); $i++)
    {
        $categoryCell = $workbook->getCell($worksheetIndex, $i + 1, 0, $categories[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell($worksheetIndex, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForWaterfallSeries($valueCell);
    }

    // จุดที่สามและหกเป็นค่ารวม ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
    $series->getDataPoints()->get_Item(2)->setSetAsTotal(true);
    $series->getDataPoints()->get_Item(5)->setSetAsTotal(true);
    $series->setShowConnectorLines(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("WaterfallChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

เรียกวิธีระดับซีรีส์ [setShowConnectorLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setshowconnectorlines/) ด้วย `true` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่องและทำให้ค่าที่ไหลตามง่ายต่อการติดตาม หากต้องการซ่อนเส้นเหล่านี้ ให้แทนที่การเรียกเมธอดในตัวอย่างด้วย `$series->setShowConnectorLines(false);` ก่อนบันทึก วิธีนี้เปลี่ยนเฉพาะการมองเห็นเส้น ไม่กระทบกับข้อมูลหรือค่ารวม

Presentation ที่บันทึกแสดงกำไรขั้นต้นที่ 600 และกำไรสุทธิที่ 450 โดยทั้งสองค่าถูกวาดจากศูนย์:

![แผนภูมิโดดเด่นแสดงรายได้, ต้นทุน, กำไรขั้นต้น 600, และกำไรสุทธิ 450 พร้อมป้ายค่าและเส้นเชื่อม](waterfall_chart.png)

### **สร้างแผนภูมิเส้นหุ้น (Stock)**

แผนภูมิเส้นหุ้นใช้เพื่อแสดงข้อมูลการเงินเช่น ราคาเปิด, สูง, ต่ำ, และ ปิด ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลสำคัญเกี่ยวกับผลการดำเนินงานของหุ้น ช่วยให้นักลงทุนและนักวิเคราะห์ตัดสินใจอย่างมีข้อมูล

ตัวอย่างนี้สร้างแผนภูมิ OHLC (เปิด‑สูง‑ต่ำ‑ปิด) ด้วยสี่ซีรีส์ตามลำดับและสามหมวด วิธี [setUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/setupdownbars/) เปิดใช้งานแถบขึ้น‑ลง และ [getHiLowLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) ควบคุมเส้นสูง‑ต่ำที่แสดงช่วงราคา ส่วนเส้นของแต่ละซีรีส์และเส้นแนวนอนย่อยจะถูกซ่อน

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::OpenHighLowClose, 20, 20, 500, 300, false);

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $categoryCell = $workbook->getCell(0, 1, 0, "A");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 2, 0, "B");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, 3, 0, "C");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Open");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 2, "High");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 3, "Low");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);
    $seriesNameCell = $workbook->getCell(0, 0, 4, "Close");
    $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::OpenHighLowClose);

    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $valueCell = $workbook->getCell(0, 1, 1, 72);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 1, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 1, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $valueCell = $workbook->getCell(0, 1, 2, 172);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 57);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $valueCell = $workbook->getCell(0, 1, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 3, 12);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 3, 13);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $valueCell = $workbook->getCell(0, 1, 4, 25);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 4, 38);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 4, 50);
    $series->getDataPoints()->addDataPointForStockSeries($valueCell);

    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);

    for ($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()); $i++)
    {
        $stockSeries = $chart->getChartData()->getSeries()->get_Item($i);
        $stockSeries->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $presentation->save("Stock-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิเส้นหุ้น](stock_chart.png)

### **สร้างแผนภูมิกล่องและวิสเกอร์ (Box and Whisker)**

แผนภูมิกล่องและวิสเกอร์ใช้เพื่อแสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติสำคัญ เช่น มัธยฐาน, ควอร์ไทล์, และค่าผิดปกติ มักใช้ในงานวิเคราะห์ข้อมูลเชิงสำรวจและการศึกษาเชิงสถิติเพื่อทำความเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติอย่างรวดเร็ว

ตัวอย่างนี้สร้างแผนภูมิกล่องและวิสเกอร์จากห้าค่า วิธี [setQuartileMethod](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setquartilemethod/) เลือกการคำนวณควอร์ไทล์แบบ exclusive ตัวอย่างยังเปิดใช้งานเส้นค่าเฉลี่ย, เครื่องหมายค่าเฉลี่ย, จุดภายใน, และจุดผิดปกติ

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\QuartileMethodType;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::BoxAndWhisker, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);

    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);

    $valueCell = $workbook->getCell(0, "B1", 15);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 41);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 10);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 23);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 16);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($valueCell);

    $presentation->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

### **สร้างแผนภูมิกรวย (Funnel)**

แผนภูมิกรวยใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยปริมาณข้อมูลจะลดลงเมื่อดำเนินการจากขั้นตอนหนึ่งไปอีกขั้นตอนหนึ่ง เหมาะสำหรับวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อเพิ่มแผนภูมิกรวยลงในสไลด์แรกของ Presentation ที่มีอยู่ แล้วแทนที่ข้อมูลเริ่มต้นด้วยห้าหมวดและค่าตั้งแต่ 50 ถึง 500 จากนั้นบันทึก Presentation ที่อัปเดต Presentation ต้องมีอย่างน้อยหนึ่งสไลด์

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $categoryCell = $workbook->getCell(0, "A1", "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A2", "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A3", "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A4", "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A5", "Category 5");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell(0, "A6", "Category 6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);

    $valueCell = $workbook->getCell(0, "B1", 50);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B2", 100);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B3", 200);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B4", 300);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B5", 400);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);
    $valueCell = $workbook->getCell(0, "B6", 500);
    $series->getDataPoints()->addDataPointForFunnelSeries($valueCell);

    $presentation->save("Funnel.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิกรวย](funnel_chart.png)

### **สร้างแผนภูมิรังสี (Sunburst)**

แผนภูมิกระจายรังสีใช้เพื่อแสดงข้อมูลเชิงลำดับขั้นโดยแสดงระดับเป็นวงกลมรอบศูนย์ ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะสำหรับแสดงหมวดหมู่และหมวดย่อยที่ซ้อนกันในรูปแบบที่กระชับและชัดเจน

ตัวอย่างนี้สร้างแผนภูมิรังสีที่มีใบแปดใบจัดกลุ่มเป็นสเต็มสี่และสาขาสองโดยใช้วิธี [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) เพื่อกำหนดสเต็มที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ป้ายกำกับหมวดระบุส่วนต่าง ๆ และค่าตัดสินขนาดสัมพัทธ์

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Sunburst, 20, 20, 500, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    // สาขา 1
    $categoryCell = $workbook->getCell(0, "C1", "Leaf1");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");

    $categoryCell = $workbook->getCell(0, "C2", "Leaf2");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C3", "Leaf3");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");

    $categoryCell = $workbook->getCell(0, "C4", "Leaf4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    // สาขา 2
    $categoryCell = $workbook->getCell(0, "C5", "Leaf5");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");

    $categoryCell = $workbook->getCell(0, "C6", "Leaf6");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "C7", "Leaf7");
    $leaf = $chart->getChartData()->getCategories()->add($categoryCell);
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");

    $categoryCell = $workbook->getCell(0, "C8", "Leaf8");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $valueCell = $workbook->getCell(0, "D1", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D2", 5);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D3", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D4", 6);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D5", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D6", 9);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D7", 4);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
    $valueCell = $workbook->getCell(0, "D8", 3);
    $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);

    $presentation->save("Sunburst.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิรังสี](sunburst_chart.png)

### **สร้างแผนภูมิฮิสโตแกรม (Histogram)**

แผนภูมิเฮิสโตแกรมแสดงว่าค่าตัวเลขกระจายตามช่วง (bins) อย่างไร สำหรับรายงานรายเดือนเกี่ยวกับเวลาประมวลผลคำสั่งซื้อ ให้ใช้ความกว้างของ bin และขีดจำกัดเดียวกันเพื่อให้ช่วงสม่ำเสมอและทำให้การเปรียบเทียบการกระจายง่ายขึ้น

เรียก [setAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaggregationtype/) บนแกนแนวนอนพร้อมโหมดจาก [AxisAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axisaggregationtype/) [setBinWidth](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setbinwidth/) ใช้เฉพาะเมื่อเลือก `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberofbins/) ใช้เฉพาะเมื่อเลือก `ByNumberOfBins` ใช้ `Automatic` เพื่อให้แผนภูมิเลือก bin อัตโนมัติ

#### **ใช้ความกว้างของ Bin คงที่**

ตัวอย่างนี้จัดกลุ่มเวลาประมวลผลเป็นช่วง 10 นาที พร้อม bin แยกสำหรับเวลาน้อยกว่าหรือเท่ากับ 10 นาทีและเวลามากกว่า 40 นาที เปิดใช้งาน bin เหล่านี้ด้วย [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) และ [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/) เมื่อระบุขีดจำกัดชัดเจนผ่าน [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) และ [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/) ให้เรียก [setAutomaticUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticunderflowbin/) และ [setAutomaticOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticoverflowbin/) ด้วย `false`

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByBinWidth);
    $axis->setBinWidth(10);
    $axis->setUnderflowBin(true);
    $axis->setAutomaticUnderflowBin(false);
    $axis->setUnderflowBin(10);
    $axis->setOverflowBin(true);
    $axis->setAutomaticOverflowBin(false);
    $axis->setOverflowBin(40);

    $presentation->save("Histogram-bin-width.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

Presentation ที่แสดงใน PowerPoint มีจำนวน bin **3, 4, 4, 4, และ 2** Bin ต่ำสุดรวม `5, 10, 10` ดังนั้นขีดจำกัดเป็น inclusive Bin สูงสุดรวมเฉพาะ `41, 50` ดังนั้นขีดจำกัดเป็น exclusive; ค่า `40` ยังคงอยู่ในช่วงก่อนหน้า Bin ภายในรวมค่าที่มากกว่าขอบล่างและน้อยกว่าหรือเท่ากับขอบบน

![ฮิสโตแกรมช่วง 10 นาทีพร้อมขีดจำกัด underflow และ overflow ชัดเจน](histogram_bin_width.png)

#### **ระบุจำนวน Bin**

หากต้องการระดับความละเอียดคงที่แทนการกำหนดช่วง ให้ขอ 5 bin สำหรับข้อมูลเดียวกัน ตัวอย่างนี้ปิดใช้งาน bin underflow และ overflow แผนภูมิกำหนดความกว้างจากช่วงข้อมูล ดังนั้นขอบเขตอาจเปลี่ยนระหว่างรายงาน

```php
use aspose\slides\AxisAggregationType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Histogram, 20, 20, 680, 200);

    $chart->setLegend(false);
    $chart->setTitle(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
    $values = [ 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 ];
    for ($i = 0; $i < count($values); $i++)
    {
        $valueCell = $workbook->getCell(0, $i, 0, $values[$i]);
        $series->getDataPoints()->addDataPointForHistogramSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setAggregationType(AxisAggregationType::ByNumberOfBins);
    $axis->setNumberOfBins(5);

    $presentation->save("Histogram-bin-count.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ห้าบินมีจำนวน **4, 4, 4, 4, และ 1** เปรียบเทียบการกระจายนี้กับผลลัพธ์ความกว้างคงที่ด้านบน: ค่าที่ใส่เดียวกัน แต่ขอบเขตต่างกัน

![ฮิสโตแกรม 5 bin คำนวณจากข้อมูลเดียวกัน](histogram_bin_count.png)

### **สร้างแผนภูมิเสา (Radar)**

แผนภูมิเสาใช้เพื่อแสดงข้อมูลหลายมิติในรูปแบบสองมิติ ช่วยให้เปรียบเทียบตัวแปรหลายตัวพร้อมกันได้ง่าย เหมาะสำหรับระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิเสาที่มีซีรีส์และหมวดหมู่เริ่มต้นแล้วบันทึกเป็น PPTX

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getShapes()->addChart(ChartType::Radar, 20, 20, 500, 300);

    $presentation->save("Radar-chart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิเสา](radar_chart.png)

### **สร้างแผนภูมิหลายหมวด (Multi-Category)**

แผนภูมิหลายหมวดใช้เพื่อแสดงข้อมูลที่มีการจัดกลุ่มเชิงหมวดหลายระดับพร้อมกัน ช่วยให้คุณเปรียบเทียบค่าผ่านหลายมิติได้พร้อมกัน เหมาะสำหรับวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลที่ซับซ้อนหลายชั้น

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีแปดหมวดจัดเป็นสี่คู่ วิธี [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) ให้แต่ละคู่มีป้ายกำกับร่วมที่ระดับการจัดกลุ่ม 1 ทำให้แกนหมวดมีป้ายกำกับส่วนบุคคลและกลุ่มรวมกัน

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell(0, "c2", "A");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $categoryCell = $workbook->getCell(0, "c3", "B");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c4", "C");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $categoryCell = $workbook->getCell(0, "c5", "D");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c6", "E");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $categoryCell = $workbook->getCell(0, "c7", "F");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $categoryCell = $workbook->getCell(0, "c8", "G");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $categoryCell = $workbook->getCell(0, "c9", "H");
    $category = $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell(0, "D1", "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $valueCell = $workbook->getCell($worksheetIndex, "D2", 10);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D3", 20);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D4", 30);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D5", 40);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D6", 50);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D7", 60);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D8", 70);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, "D9", 80);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    $presentation->save("AsposeChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิหลายหมวด](multi_category_chart.png)

### **สร้างแผนภูมิแผนที่ (Map)**

แผนภูมิแผนที่ใช้เพื่อแสดงข้อมูลเชิงภูมิศาสตร์โดยแมพข้อมูลไปยังตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง เหมาะสำหรับวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิแผนที่พร้อมข้อมูลทางภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Map, 20, 20, 500, 300);

    $presentation->save("mapChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

ผลลัพธ์:

![แผนภูมิแผนที่](map_chart.png)

{{% alert color="info" title="Note" %}}
รูปภาพข้างต้นแสดง Presentation ที่บันทึกแล้วเปิดใน PowerPoint Aspose.Slides เขียนแผนภูมิแผนที่และข้อมูลของมันได้อย่างถูกต้อง แต่ไม่ได้วาดแผนภูมิแผนที่เอง: เมื่อสไลด์ที่มีแผนภูมินี้ถูกแปลงเป็นภาพหรือแปลงเป็น PDF หรือ SVG พื้นที่แผนภูมิจะแม่นเลย รูปทรงอื่นบนสไลด์เดียวกันไม่มีผลกระทบ
{{% /alert %}}

### **สร้างแผนภูมิผสม (Combination)**

แผนภูมิผสม (หรือ combo chart) ผสานสองประเภทแผนภูมิหรือมากกว่าบนกราฟเดียว แผนภูมินี้ช่วยให้คุณเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลสองชุดหรือมากกว่า ช่วยระบุความสัมพันธ์ระหว่างข้อมูลเหล่านั้น

![แผนภูมิผสม](combination_chart.png)

ตัวอย่างนี้ผสานสองซีรีส์คอลัมน์แบบกลุ่มกับซีรีส์เส้นในสี่หมวด คอลัมน์ใช้แกนตั้งแนวตั้งหลัก ในขณะที่ [setPlotOnSecondAxis](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setplotonsecondaxis/) วางเส้นบนแกนตั้งแนวตั้งรองด้านขวา ฟังก์ชันช่วยตั้งค่าชื่อเรื่อง, คีย์ลิเคิล, ป้ายแกน, และเส้นตาราง

```php
use aspose\slides\AxisPositionType;
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\FillType;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function createComboChart()
{
    $presentation = new Presentation();
    try
    {
        $chart = createChartWithFirstSeries($presentation->getSlides()->get_Item(0));

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    }
    finally
    {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide)
{
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $portionFormat = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $portionFormat->setFontBold(NullableBool::False);
    $portionFormat->setFontHeight(18);

    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $categoryCell = $workbook->getCell($worksheetIndex, 1, 0, "Category 1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 2, 0, "Category 2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 3, 0, "Category 3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $categoryCell = $workbook->getCell($worksheetIndex, 4, 0, "Category 4");
    $chart->getChartData()->getCategories()->add($categoryCell);

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 1, 4.3);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 1, 2.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 1, 3.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 1, 4.5);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);

    return $chart;
}

function addSecondSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 2, 2.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 2, 4.4);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 2, 1.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 2, 2.8);
    $series->getDataPoints()->addDataPointForBarSeries($valueCell);
}

function addThirdSeriesToChart($chart)
{
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 2.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 3.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell($worksheetIndex, 4, 3, 5.0);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart)
{
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $color = new Java("java.awt.Color", 217, 217, 217);
    $majorGridLinesFormat->getSolidFillColor()->setColor($color);
}

function setSecondaryAxesFormat($chart)
{
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle)
{
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titlePortionFormat = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $titlePortionFormat->setFontBold(NullableBool::False);
    $titlePortionFormat->setFontHeight(12);
}

createComboChart();
```

## **Update Charts**

Aspose.Slides for PHP via Java ช่วยให้คุณอัปเดตแผนภูมิ PowerPoint โดยการแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ สิ่งนี้ทำให้การรักษา Presentation ให้ทันสมัยด้วยเนื้อหาไดนามิกง่ายขึ้นและทำให้แผนภูมิตรงกับข้อมูลปัจจุบันและมาตรฐานการแสดงผล

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ "My chart" บนสไลด์แรกของ Presentation ที่มีอยู่ ต้องการสองซีรีส์คอลัมน์ที่มีแต่ละ 3 จุดข้อมูล, ป้ายหมวดในคอลัมน์ A และชื่อซีรีส์ในแถวแรกของเวิร์กชีตแรก ตัวอย่างใช้ [getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) เพื่อเปลี่ยนเซลล์เวิร์กบุ๊ก, อัปเดตค่าของซีรีส์, เพิ่มซีรีส์ที่สาม, และเปลี่ยนแผนภูมิเป็นรูปทรงกระบอกแบบกลุ่มผ่าน [setType](https://reference.aspose.com/slides/php-java/aspose.slides/chart/settype/)

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $worksheetIndex = 0;

            $workbook = $chart->getChartData()->getChartDataWorkbook();

            $workbook->getCell($worksheetIndex, 1, 0, "Modified Category 1");
            $workbook->getCell($worksheetIndex, 2, 0, "Modified Category 2");

            $series = $chart->getChartData()->getSeries()->get_Item(0);

            $workbook->getCell($worksheetIndex, 0, 1, "New_Series 1");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(44);

            $series = $chart->getChartData()->getSeries()->get_Item(1);

            $workbook->getCell($worksheetIndex, 0, 2, "New_Series 2");
            $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
            $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
            $series->getDataPoints()->get_Item(2)->getValue()->setData(99);

            $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
            $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

            $valueCell = $workbook->getCell($worksheetIndex, 1, 3, 20);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 2, 3, 50);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);
            $valueCell = $workbook->getCell($worksheetIndex, 3, 3, 30);
            $series->getDataPoints()->addDataPointForBarSeries($valueCell);

            $chart->setType(ChartType::ClusteredCylinder);
        }
    }

    $presentation->save("AsposeChartModified.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **Set Data Range for a Chart**

เพื่อดูช่วงที่แผนภูมิใช้งานอยู่แล้วให้ดูที่ [Retrieve a Chart's Data Range](/slides/th/php-java/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides for PHP via Java ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจากเวิร์กชีตเป็นแหล่งข้อมูลของแผนภูมิของคุณ นั่นหมายความว่าคุณสามารถแมปส่วนของเวิร์กชีตตรงกับแผนภูมิได้โดยตรง ควบคุมเซลล์ใดบ้างที่มีส่วนร่วมในซีรีส์และหมวดของแผนภูมิ ผลลัพธ์คือคุณสามารถอัปเดตและซิงโครไนซ์แผนภูมิของคุณกับการเปลี่ยนแปลงข้อมูลล่าสุดในเวิร์กชีตได้อย่างง่ายดาย ทำให้ Presentation ของคุณสะท้อนข้อมูลที่เป็นปัจจุบันและแม่นยำ

ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อตั้งแหล่งข้อมูลของแผนภูมิชื่อ "My chart" บนสไลด์แรกของ Presentation ที่มีอยู่เป็น `Sheet1!A1:B4` เวิร์กบุ๊กของแผนภูมิต้องมีเวิร์กชีตนั้นและช่วงข้อมูลที่เต็มด้วยหัวเรื่องซีรีส์ในแถวแรก, ป้ายหมวดในคอลัมน์ A, และค่าสามค่าในคอลัมน์ B

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$chartName = "My chart";
$chartClass = new JavaClass("com.aspose.slides.IChart");

$presentation = new Presentation("ExistingChart.pptx");
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++)
    {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartClass) && $chartName === java_values($shape->getName()))
        {
            $chart = $shape;
            $chart->getChartData()->setRange("Sheet1!A1:B4");
        }
    }

    $presentation->save("SetDataRange.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **Use Default Markers in Charts**

เมื่อคุณใช้เครื่องหมายเริ่มต้นในแผนภูมิแต่ละซีรีส์จะได้รับสัญลักษณ์เครื่องหมายเริ่มต้นที่ต่างกันโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิที่มีสองซีรีส์เส้นและคีย์ลิเคิล การตั้งค่าตัวทำเครื่องหมายที่เข้าถึงผ่าน [getMarker](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getmarker/) รักษาสัญลักษณ์เครื่องหมายที่ระบบกำหนดให้โดยอัตโนมัติ ซีรีส์แรกมีค่าติดลบและค่าที่หายไป (null) ส่วนซีรีส์ที่สองมีค่าทุกหมวด

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $seriesNameCell = $workbook->getCell(0, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $categoryCell = $workbook->getCell(0, 1, 0, "C1");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 1, 1, 24);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 2, 0, "C2");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 2, 1, 23);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 3, 0, "C3");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 3, 1, -10);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $categoryCell = $workbook->getCell(0, 4, 0, "C4");
    $chart->getChartData()->getCategories()->add($categoryCell);
    $valueCell = $workbook->getCell(0, 4, 1, null);
    $series->getDataPoints()->addDataPointForLineSeries($valueCell);

    $seriesNameCell = $workbook->getCell(0, 0, 2, "Series 2");
    $secondSeries = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $valueCell = $workbook->getCell(0, 1, 2, 30);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 2, 2, 10);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 3, 2, 60);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);
    $valueCell = $workbook->getCell(0, 4, 2, 40);
    $secondSeries->getDataPoints()->addDataPointForLineSeries($valueCell);

    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);

    $presentation->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}
```

## **FAQ**

**Aspose.Slides for PHP via Java รองรับประเภทแผนภูมิใดบ้าง?**

Aspose.Slides for PHP via Java รองรับแผนภูมิมากมาย รวมถึงแผนภูมิบาร์, เส้น, วงกลม, พื้นที่, กระจาย, ฮิสโตแกรม, รังสี, และอื่น ๆ อีกหลายประเภท ความยืดหยุ่นนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะกับการแสดงผลข้อมูลของคุณได้

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ดึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิ โดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น ขั้นตอนนี้จะผสานแผนภูมิเข้าไปใน Presentation ของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)) เคลียร์ซีรีส์และหมวดเริ่มต้น แล้วเพิ่มข้อมูลของคุณเอง วิธีนี้ทำให้คุณรีเฟรชแผนภูมิโดยอัตโนมัติเพื่อสะท้อนข้อมูลล่าสุด

**สามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for PHP via Java มีตัวเลือกการปรับแต่งหลากหลาย คุณสามารถแก้ไขสี, ฟอนต์, ป้าย, คีย์ลิเคิล, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงตามความต้องการออกแบบของคุณอย่างแม่นยำ