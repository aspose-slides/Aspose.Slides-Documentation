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
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิต้นไม้
- แผนภูมิหุ้น
- แผนภูมิ Box and Whisker
- แผนภูมิกระบอก
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิมัลติเกรต
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ทำงานได้จริงใน PHP."
---
## **Overview**

บทความนี้ให้คำแนะนำอย่างครอบคลุมเกี่ยวกับวิธีสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides สำหรับ PHP ผ่าน Java คุณจะได้เรียนรู้วิธีเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม, เติมข้อมูลลงในแผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ ให้ตรงกับความต้องการออกแบบของคุณ ในบทความนี้ ตัวอย่างโค้ดย่อยละเอียดยิบจะแสดงแต่ละขั้นตอน ตั้งแต่การเริ่มต้น Presentation และอ็อบเจ็กต์ Chart ไปจนถึงการกำหนดค่าซีรีส์, แกน, และเลเจนด์ โดยการทำตามคำแนะนำนี้ คุณจะเข้าใจอย่างถ่องแท้ถึงการผสมผสานการสร้างแผนภูมิโดนไดนามิกเข้าสู่แอปพลิเคชัน PHP ของคุณ ทำให้กระบวนการสร้างการนำเสนอที่อิงข้อมูลเป็นเรื่องง่ายขึ้น

## **Create a Chart**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อมูลเชิงลึกที่อาจไม่ชัดเจนในตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ใช้แผนภูมิคุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากในสไลด์เดียวของการนำเสนอ;
* แสดงรูปแบบและแนวโน้มของข้อมูล;
* สรุปแนวทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยการวัดเฉพาะ;
* ค้นหาค่าผิดปกติ, ความเบี่ยงเบน, ความคลาดเคลื่อน, ความผิดพลาด, และข้อมูลที่ไม่มีเหตุผล;
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งให้เทมเพลตสำหรับออกแบบแผนภูมิมากมาย โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (อิงจากประเภทแผนภูมิยอดนิยม) และแผนภูกแบบกำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ใน namespace [aspose\slides](https://reference.aspose.com/slides/php-java/aspose.slides/) ค่าที่อยู่ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิที่แตกต่างกัน
{{% /alert %}}

### **Create Clustered Column Charts**

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิคอลัมน์แบบจัดกลุ่มที่เปรียบเทียบสองซีรีส์ในสามหมวดหมู่ ซีรีส์ใช้การเติมสีแดงและสีเขียว และป้ายกำกับแสดงชื่อหมวดหมู่, ชื่อซีรีส์, และค่าต่าง ๆ ดัชนี Worksheet 0 หมายถึงแผ่นแรกในเวิร์กบุ๊กแผนภูมิที่ฝังอยู่

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

![The Clustered Column chart](clustered_column_chart.png)

### **Create Scatter Charts**

แผนภูมิกระจาย (หรือที่เรียกว่ากราฟกระจาย) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิกระจายเมื่อ:

* คุณมีข้อมูลตัวเลขเป็นคู่
* คุณมีสองตัวแปรที่สัมพันธ์กันดี
* คุณต้องการตรวจสอบว่าทั้งสองตัวแปรมีความสัมพันธ์หรือไม่
* คุณมีตัวแปรอิสระที่มีค่าหลายค่าสำหรับตัวแปรตาม

ตัวอย่างนี้พล็อตค่าตำแหน่ง x‑y สองชุด ซีรีส์แรกใช้เส้นตรงกับเครื่องหมายดาว, ส่วนซีรีส์ที่สองใช้เส้นโค้งกับเครื่องหมายวงกลม; ทั้งสองใช้ขนาดเครื่องหมาย 10 ซึ่งกำหนดโดย [setSize](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsize/). วิธี [setSymbol](https://reference.aspose.com/slides/php-java/aspose.slides/marker/setsymbol/) ควบคุมรูปแบบเครื่องหมาย

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

![The Scatter chart](scatter_chart.png)

### **Create Pie Charts**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล, โดยเฉพาะเมื่อข้อมูลมีป้ายประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีส่วนหรือป้ายจำนวนมาก คุณอาจพิจารณาใช้แผนภูมิแท่งแทน

ตัวอย่างนี้สร้างแผนภูมวงกลมที่มีค่าครึ่งปีสามค่า แต่ละส่วนมีการเติมสีและเส้นขอบกำหนดเอง, ป้ายแสดงการผสมค่าต่าง ๆ, ร้อยละ, และข้อมูลซีรีส์ วิธี [setFirstSliceAngle](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/setfirstsliceangle/) กำหนดให้ส่วนแรกเริ่มที่ 180 องศา

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

![The Pie chart](pie_chart.png)

เพื่อปรับปรุงความอ่านง่ายของป้ายนอกวงกลม,ดูตัวอย่าง [Format Leader Lines](/slides/th/php-java/chart-data-label/#format-leader-lines) ที่แสดงวิธีจัดตำแหน่งป้ายและปรับสี, ความกว้าง, ความโปร่งใส, และรูปแบบขีดของเส้น

### **Create Line Charts**

แผนภูมิเส้น (หรือที่เรียกว่ากราฟเส้น) เหมาะกับสถานการณ์ที่ต้องการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ด้วยแผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล, และอื่น ๆ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิเส้นด้วยซีรีส์และหมวดหมู่เริ่มต้น, แล้วบันทึกเป็น PPTX

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

โดยค่าเริ่มต้น จุดในแผนภูมิเส้นจะเชื่อมด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมด้วยเส้นขีดให้เรียก [setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/setdashstyle/) พร้อมค่าจาก [LineDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/):

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

![The Line chart](line_chart.png)

### **Create Tree Map Charts**

แผนภูมิต้นไม้ (Tree Map) เหมาะกับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้สนับสนุนหลักในแต่ละหมวดหมู่

ตัวอย่างนี้สร้าง Tree Map ที่มีใบแปดใบจัดเป็นสี่กิ่งและสองสาขา วิธี [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) กำหนดกิ่งที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ค่าเหล่านี้กำหนดขนาดสี่เหลี่ยมสัมพัทธ์, ป้ายหมวดหมู่และป้ายพาเรนต์ที่ทับซ้อนกันระบุโครงสร้างชั้นลำดับ

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

![The Treemap chart](treemap_chart.png)

### **Create Waterfall Charts**

แผนภูมือน้ำตกแสดงการเปลี่ยนแปลงบวกและลบที่มีผลต่อค่าขั้นสุดท้าย ตัวอย่างเช่น การแยกกำไรอาจเริ่มจากรายได้, ลดด้วยต้นทุน, แล้วเพิ่มด้วยรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงลอยระหว่างค่าก่อนหน้าและค่าปัจจุบัน, ส่วนคอลัมน์รวมขยายจากศูนย์ถึงค่าที่สะสม

ตารางตัวอย่าง:

| Category | Workbook value | Column type |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

เพื่อกำหนดจุดให้เป็นค่าเป็นกลางหรือค่าขั้นสุดท้าย เรียกเมธอด [setSetAsTotal](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/setsetastotal/) ของจุดนั้นด้วย `true` และใส่ค่าที่สะสมจริงลงในเซลล์เวิร์กบุ๊กของจุดนั้น: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`). เมธอดนี้ทำเครื่องหมายคอลัมน์เป็นค่าขั้นสุดท้าย; มันไม่ได้คำนวณหรือเติมค่าในเซลล์ อย่าใช้ศูนย์เป็นตัวแทนหรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดค่าขั้นสุดท้าย คอลัมน์รวมจะแสดงค่าที่สะสมโดยไม่เพิ่มอีกครั้งในค่าเดินหน้า

ตัวอย่าง PHP ทั้งหมดนี้สร้างแผนภูมิโดยใช้สมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), ล้างข้อมูลเริ่มต้น, แล้วเติมเวิร์กบุ๊กฝัง ตัวชี้ดัชนี Worksheet `0` เลือกเวิร์กชีตแรก; คอลัมน์ A มีชื่อหมวดหมู่, คอลัมน์ B มีค่า แต่ละค่าจะเพิ่มด้วย [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapointcollection/adddatapointforwaterfallseries/). ดัชนีจุดเริ่มจากศูนย์ `2` และ `5` ระบุค่าขั้นกลางและค่าขั้นสุดท้าย การเรียก [setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/setshowvalue/) ด้วย `true` ทำให้จำนวนแสดงบนคอลัมน์ ไม่ต้องมีการนำเข้าการนำเสนอหรือเวิร์กบุ๊ก

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

    // จุดที่สามและหกเป็นค่ารวม, ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
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

เรียกเมธอดระดับซีรีส์ [setShowConnectorLines](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setshowconnectorlines/) ด้วย `true` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่อง ทำให้การติดตามค่าเดินหน้าง่ายขึ้น หากต้องการซ่อนเส้นเหล่านี้ให้แทนที่การเรียกเมธอดในตัวอย่างด้วย `$series->setShowConnectorLines(false);` ก่อนบันทึก การเปลี่ยนแปลงนี้มีผลเฉพาะการมองเห็นเส้น ไม่กระทบข้อมูลหรือค่าขั้นสุดท้าย

การบันทึกการนำเสนอแสดงกำไรขั้นต้น 600 และกำไรสุทธิ 450, ทั้งสองค่าถูกวาดจากศูนย์:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **Create Stock Charts**

แผนภูมิหุ้นใช้เพื่อแสดงข้อมูลการเงินเช่น ราคาเปิด, สูง, ต่ำ, และปิด, ช่วยวิเคราะห์แนวโน้มและความผันผวนของตลาด มันให้ข้อมูลสำคัญเกี่ยวกับประสิทธิภาพหุ้นเพื่อช่วยนักลงทุนและนักวิเคราะห์ทำการตัดสินใจ

ตัวอย่างนี้สร้างแผนภูมิ Open‑High‑Low‑Close (OHLC) ที่มีสี่ซีรีส์ตามลำดับและสามหมวดหมู่ เมธอด [setUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/setupdownbars/) เปิดใช้งานแถบขึ้น/ลง, และ [getHiLowLinesFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/gethilowlinesformat/) ควบคุมเส้น high‑low ที่แสดงช่วงราคา, ส่วนเส้นซีรีส์และเส้นกริดแนวนอนย่อยจะถูกซ่อน

ผู้จัดการที่ได้จาก [getUpDownBars](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriesgroup/getupdownbars/) ให้เข้าถึงออบเจ็กต์ฟอร์แมตแยกกันผ่าน [getUpBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/getupbarsformat/) และ [getDownBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/updownbarsmanager/getdownbarsformat/). ใช้เมธอด [getFill](https://reference.aspose.com/slides/php-java/aspose.slides/format/getfill/) และ [getLine](https://reference.aspose.com/slides/php-java/aspose.slides/format/getline/) ของแต่ละออบเจ็กต์เพื่อกำหนดสีเติมและขอบอย่างอิสระ ตัวอย่างนี้ใช้แถบสีเขียวกับขอบสีเขียวเข้มสำหรับช่วงที่ราคาเพิ่ม, และแถบสีส้ม‑แดงกับขอบสีแดงเข้มสำหรับช่วงที่ราคา下降

ใส่ค่าตัวเลขสำหรับทั้งสี่ซีรีส์ในแต่ละหมวดหมู่, โดย High และ Low ครอบคลุม Open และ Close แถบเปรียบเทียบ Close กับ Open **ภายในหมวดหมู่เดียวกัน**, ไม่ได้เปรียบเทียบกับหมวดหมู่ก่อนหน้า: A ลดจาก 72 ไป 25, ขณะที่ B เพิ่มจาก 25 ไป 38 และ C เพิ่มจาก 38 ไป 50. ค่าที่ Open และ Close เท่ากันจะไม่มีช่วงสีเติมใด ๆ แถบ up/down ครอบคลุม Open‑Close; เส้น high‑low ครอบคลุม Low‑High. แถบเหล่านี้เป็นส่วนของกลุ่มซีรีส์และไม่ใช่ซีรีส์แผนภูมิบาร์ธรรมดา

รูปแบบนี้ยังทำงานกับแผนภูมิ [Line and LineWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ที่มีอย่างน้อยสองซีรีส์ในกลุ่มเดียวกันและค่าตัวเลขที่สอดคล้องในแต่ละหมวดหมู่ สำหรับแผนภูมิเส้นที่ไม่เป็น stacked, แถบ up/down เปรียบเทียบซีรีส์แรกและสุดท้าย: ค่าสุดท้ายสูงกว่าจะทำให้แถบขึ้น, ค่าต่ำกว่าจะทำให้แถบลง การสลับซีรีส์จะสลับการจำแนก ตัวอย่างต่อไปใช้ [OpenHighLowClose](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/); อย่าสมมุติว่า stock, stacked‑line, หรือเวอร์ชัน 3D อื่น ๆ ใช้การจัดเรียงข้อมูลหรือการตีความช่วงเดียวกัน

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try
{
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::OpenHighLowClose, 20, 20, 500, 150, false);

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

    $upDownBars = $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars();
    $upDownBars->setUpDownBars(true);

    $upDownBars->getUpBarsFormat()->getFill()->setFillType(FillType::Solid);
    $upDownBars->getUpBarsFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 50, 205, 50));
    $upDownBars->getUpBarsFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $upDownBars->getUpBarsFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 100, 0));
    $upDownBars->getUpBarsFormat()->getLine()->setWidth(2);

    $upDownBars->getDownBarsFormat()->getFill()->setFillType(FillType::Solid);
    $upDownBars->getDownBarsFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 69, 0));
    $upDownBars->getDownBarsFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $upDownBars->getDownBarsFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $upDownBars->getDownBarsFormat()->getLine()->setWidth(2);
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

ผลลัพธ์ที่ส่งออกจาก PowerPoint:

![Stock chart with an orange-red falling interval for A and green rising intervals for B and C](stock_chart.png)

### **Create Box and Whisker Charts**

แผนภูมิ Box and Whisker ใช้เพื่อแสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติสำคัญ เช่น มัธยฐาน, ควอร์ไทล์, และค่าตัวอย่างที่อาจเป็น outlier เหมาะสำหรับการวิเคราะห์ข้อมูลเชิงสำรวจและการศึกษาทางสถิติ เพื่อทำความเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติอย่างรวดเร็ว

ตัวอย่างนี้สร้างแผนภูมิ Box and Whisker จากห้าค่า เมธอด [setQuartileMethod](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setquartilemethod/) เลือกการคำนวณควอร์ไทล์แบบ exclusive ตัวอย่างยังเปิดใช้งานเส้นค่าเฉลี่ย, เครื่องหมายค่าเฉลี่ย, จุดภายใน, และจุด outlier

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

### **Create Funnel Charts**

แผนภูมิ Funnel ใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยปริมาณข้อมูลจะลดลงเมื่อดำเนินการจากขั้นตอนหนึ่งไปอีกขั้นตอนหนึ่ง เหมาะกับการวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อเพิ่มแผนภูมิ Funnel ไปยังสไลด์แรกของการนำเสนอที่มีอยู่ มันแทนที่ข้อมูลเริ่มต้นด้วยห้าหมวดหมู่และค่าตั้งแต่ 50 ถึง 500 แล้วบันทึกการนำเสนอที่อัปเดต การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์

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

![The Funnel chart](funnel_chart.png)

### **Create Sunburst Charts**

แผนภูมิ Sunburst ใช้เพื่อแสดงข้อมูลเชิงลำดับขั้นโดยแสดงระดับเป็นวงแหวนศูนย์กลาง ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะกับการแทนหมวดหมู่และหมวดย่อยที่ซ้อนกันในรูปแบบที่ชัดเจนและกระชับ

ตัวอย่างนี้สร้างแผนภูมิ Sunburst ที่มีใบแปดใบจัดเป็นสี่กิ่งและสองสาขา เมธอด [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) กำหนดกิ่งที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ป้ายหมวดหมู่ระบุส่วนต่าง ๆ, ค่าเป็นตัวกำหนดขนาดสัมพัทธ์

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

![The Sunburst chart](sunburst_chart.png)

### **Create Histogram Charts**

แผนภูมิ Histogram แสดงการกระจายของค่าตัวเลขในช่วง (bins) ต่าง ๆ สำหรับรายงานประจำเดือนเกี่ยวกับเวลาการประมวลผลคำสั่งซื้อ ให้ใช้ความกว้าง bin และค่า threshold เดียวกันเพื่อให้ช่วงสอดคล้องและทำให้การเปรียบเทียบการกระจายง่ายขึ้น

เรียก [setAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaggregationtype/) บนแกนแนวนอนด้วยโหมดจาก [AxisAggregationType](https://reference.aspose.com/slides/php-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setbinwidth/) ใช้ได้เฉพาะกับ `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberofbins/) ใช้ได้เฉพาะกับ `ByNumberOfBins`. ใช้ `Automatic` เพื่อให้แผนภูมิตัดสินใจเลือก bin เอง

#### **Use a Fixed Bin Width**

ตัวอย่างนี้จัดเวลาประมวลผลเป็นช่วง 10 นาที, โดยมี bin แยกสำหรับเวลาที่ ≤10 นาทีและ >40 นาที เปิดใช้งาน bin เหล่านี้ด้วย [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) และ [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/). เมื่อกำหนด threshold อย่างชัดเจนผ่าน [setUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setunderflowbin/) และ [setOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setoverflowbin/), เรียก [setAutomaticUnderflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticunderflowbin/) และ [setAutomaticOverflowBin](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticoverflowbin/) ด้วย `false`

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

การนำเสนอที่แสดงใน PowerPoint มีจำนวนในแต่ละ bin **3, 4, 4, 4, และ 2**. bin underflow มีค่า `5, 10, 10` จึงรวมค่าที่เท่ากับ threshold, bin overflow มีค่า `41, 50` เท่านั้นจึงไม่รวมค่า `40`; ค่าที่เท่ากับ `40` จะอยู่ใน bin ก่อนหน้า bin ภายในมีค่ามากกว่าขอบล่างและน้อยกว่าหรือเท่ากับขอบบน

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **Specify the Number of Bins**

สำหรับระดับรายละเอียดคงที่แทนที่การกำหนดช่วงคงที่ ให้ขอ bin จำนวน 5 สำหรับข้อมูลเดียวกัน ตัวอย่างนี้ปิดการใช้งาน bin underflow และ overflow แผนภูมิคำนวณความกว้างจากช่วงข้อมูล ดังนั้นขอบอาจเปลี่ยนระหว่างรายงาน

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

ห้าบินมีจำนวน **4, 4, 4, 4, และ 1**. เปรียบเทียบการกระจายนี้กับผลลัพธ์ความกว้างคงที่ด้านบน: ค่าข้อมูลเหมือนเดิมแต่ขอบต่างกัน

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **Create Radar Charts**

แผนภูมิ Radar ใช้เพื่อแสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ, ช่วยให้เปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย เหมาะสำหรับการระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิ Radar ด้วยซีรีส์และหมวดหมู่เริ่มต้น, แล้วบันทึกเป็น PPTX

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

![The Radar chart](radar_chart.png)

### **Create Multi-Category Charts**

แผนภูมิหลายหมวดหมู่ใช้เพื่อแสดงข้อมูลที่มีการจัดกลุ่มหลายระดับ, ช่วยให้เปรียบเทียบค่าในหลายมิติพร้อมกัน เหมาะเมื่อคุณต้องการวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลที่ซับซ้อนหลายชั้น

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบจัดกลุ่มที่มีแปดหมวดหมู่จัดเป็นสี่คู่ เมธอด [setGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/setgroupingitem/) ให้แต่ละคู่อีกป้ายร่วมที่ระดับการจัดกลุ่ม 1, ทำให้แกนหมวดหมู่มีทั้งป้ายเดี่ยวและป้ายกลุ่ม

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

![The multi category chart](multi_category_chart.png)

#### **Remove a Quarter Label**

ดาวน์โหลด [quarters.pptx](quarters.pptx) แล้ววางไว้ในไดเรกทอรีเดียวกับสคริปต์ PHP ของคุณ แผนภูมิในไฟล์นี้แสดงเดือนเก้าเดือนและซีรีส์ยอดขายเดียวที่มีค่า 10‑18 บนแกนหมวดหมู่ Q1 ครอบคลุมมกราคม‑มีนาคม, Q2 ครอบคลุมเมษายน‑มิถุนายน, Q3 ครอบคลุมกรกฎาคม‑กันยายน

เมษายนเป็นหมวดที่สี่ (ดัชนี 3) และมีป้าย Q2 ใช้ [getGroupingLevels](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategory/getgroupinglevels/) เพื่อเข้าถึงระดับการจัดกลุ่มของเมษายน, แล้วเรียก [deleteGroupingItem](https://reference.aspose.com/slides/php-java/aspose.slides/chartcategorylevelsmanager/deletegroupingitem/) ด้วยระดับ 1 เพื่อลบป้ายไตรมาส ระดับ 0 คือเดือนเองและไม่สามารถลบได้โดยเมธอดนี้

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/quarters.pptx");
try
{
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $april = $chart->getChartData()->getCategories()->get_Item(3);
    $april->getGroupingLevels()->deleteGroupingItem(1);

    $presentation->save(__DIR__ . "/quarters-updated.pptx", SaveFormat::Pptx);
}
finally
{
    $presentation->dispose();
}

$reopened = new Presentation(__DIR__ . "/quarters-updated.pptx");
try
{
    $updatedChart = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $data = $updatedChart->getChartData();

    $months = [];
    $categories = $data->getCategories();
    
    for ($i = 0; $i < java_values($categories->size()); $i++)
    {
        $months[] = (string)$categories->get_Item($i)->getAsCell()->getValue();
    }

    $sales = [];
    $points = $data->getSeries()->get_Item(0)->getDataPoints();
    for ($i = 0; $i < java_values($points->size()); $i++)
    {
        $sales[] = (string)$points->get_Item($i)->getValue()->getData();
    }

    echo implode(", ", $months), PHP_EOL;
    echo implode(", ", $sales), PHP_EOL;
}
finally
{
    $reopened->dispose();
}
```

หลังจากเปิดแผนภูมิใหม่ ตัวอย่างจะแสดงเดือนต้นฉบับ (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) และค่าขาย (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) ตามลำดับเดียวกัน เปิดไฟล์ `quarters-updated.pptx` ใน PowerPoint เพื่อเปรียบเทียบป้ายแกน ป้าย Q2 และขอบกลุ่มก่อนเมษายนหายไป, ทำให้ Q1 ครอบคลุมมกราคม‑มิถุนายน, Q3 ยังคงเริ่มในเดือนกรกฎาคม

![Quarter labels before and after removal. On the left, Q2 spans April through June. On the right, Q1 spans January through June.](quarter-label-comparison.png)

### **Create Map Charts**

แผนภูมิเพิ่มเติม (Map) ใช้เพื่อแสดงข้อมูลเชิงภูมิศาสตร์โดยแมปข้อมูลกับตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง เหมาะกับการวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิแผนที่ด้วยข้อมูลภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

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

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}
ภาพด้านบนแสดงการเปิดการนำเสนอที่บันทึกใน PowerPoint Aspose.Slides เขียนแผนภูมิแผนที่และข้อมูลของมันอย่างถูกต้อง, แต่ไม่ได้วาดแผนภูมิแผนที่เอง: เมื่อสไลด์ที่มีแผนภูมินี้ถูกรันเดอร์เป็นภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะเป็นสีฟาก. รูปร่างอื่นๆ ในสไลด์เดียวกันไม่ได้รับผลกระทบ
{{% /alert %}}

### **Create Combination Charts**

แผนภูมิแบบผสม (หรือ combo chart) รวมสองประเภทแผนภูมิหรือมากกว่าภายในกราฟเดียว แผนภูมินี้ช่วยให้คุณเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างของชุดข้อมูลหลายชุด, ช่วยระบุความสัมพันธ์ระหว่างข้อมูล

![The combination chart](combination_chart.png)

ตัวอย่างนี้รวมสองซีรีส์คอลัมน์แบบจัดกลุ่มกับซีรีส์เส้นในสี่หมวดหมู่ คอลัมน์ใช้แกนแนวตั้งหลัก, ส่วน [setPlotOnSecondAxis](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/setplotonsecondaxis/) วางเส้นบนแกนแนวตั้งรองด้านขวา ฟังก์ชันช่วยกำหนดหัวเรื่อง, เลเจนด์, ป้ายแกน, และเส้นกริด

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

Aspose.Slides สำหรับ PHP ผ่าน Java ช่วยให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ สิ่งนี้ทำให้การรักษาการนำเสนอให้ทันสมัยด้วยเนื้อหาไดนามิกง่ายขึ้นและรับประกันว่าแผนภูมิจะแสดงข้อมูลปัจจุบันและมาตรฐานภาพที่ถูกต้อง

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ "My chart" บนสไลด์แรกของการนำเข้าที่มีอยู่ ต้องการสองซีรีส์คอลัมน์ที่มีจุดข้อมูลแต่ละจุดสามค่า, ป้ายหมวดหมู่ในคอลัมน์ A และชื่อซีรีส์ในแถวแรกของเวิร์กชีตแรก ตัวอย่างใช้ [getCell](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/getcell/) เพื่อเปลี่ยนเซลล์เวิร์กบุ๊ก, อัปเดตค่าซีรีส์, เพิ่มซีรีส์ที่สาม, และเปลี่ยนแผนภูมิเป็นทรงกระบอกจัดกลุ่มผ่าน [setType](https://reference.aspose.com/slides/php-java/aspose.slides/chart/settype/)

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

เพื่อดูช่วงข้อมูลที่แผนภูมิมีอยู่แล้ว, ดูที่ [Retrieve a Chart's Data Range](/slides/th/php-java/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides สำหรับ PHP ผ่าน Java ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจากเวิร์กชีตเป็นแหล่งข้อมูลสำหรับแผนภูมิของคุณ ซึ่งหมายความว่าคุณสามารถแมปส่วนของเวิร์กชีตโดยตรงกับแผนภูมิ, ควบคุมว่าเซลล์ใดบ้างที่มีส่วนร่วมในซีรีส์และหมวดหมู่ของแผนภูมิได้ ดังนั้นคุณจึงอัปเดตและซิงโครไนซ์แผนภูมิกับการเปลี่ยนแปลงข้อมูลล่าสุดในเวิร์กชีตได้ง่าย, ทำให้การนำเสนอ PowerPoint ของคุณสะท้อนข้อมูลที่เป็นปัจจุบันและถูกต้อง

ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อตั้งแหล่งข้อมูลของแผนภูมิชื่อ "My chart" บนสไลด์แรกของการนำเข้าที่มีอยู่เป็น `Sheet1!A1:B4`. เวิร์กบุ๊กของแผนภูมิต้องมีแผ่นงานนั้นและช่วงที่เป็นข้อมูลที่มีหัวเรื่องซีรีส์ในแถวแรก, ป้ายหมวดหมู่ในคอลัมน์ A, และค่าสามค่าในคอลัมน์ B

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

เมื่อใช้เครื่องหมายเริ่มต้นในแผนภูมิ, แต่ละซีรีส์ของแผนภูมิจะได้รับเครื่องหมายเริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addchart/) เพื่อสร้างแผนภูมิที่มีสองซีรีส์เส้นและเลเจนด์ การตั้งค่าเครื่องหมายที่เข้าถึงผ่าน [getMarker](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getmarker/) คงสาธารณะเครื่องหมายที่กำหนดโดยอัตโนมัติ ซีรีส์แรกมีค่าติดลบและค่าที่หายไป (`null`), ส่วนซีรีส์ที่สองมีค่าทั้งหมดในแต่ละหมวดหมู่

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

**What chart types are supported by Aspose.Slides for PHP via Java?**

Aspose.Slides for PHP via Java รองรับประเภทแผนภูมิหลากหลาย รวมถึงแถบ, เส้น, วงกลม, พื้นที่, กระจาย, histogram, radar, และอื่น ๆ อีกมาก ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณได้

**How do I add a new chart to a slide?**

เพื่อเพิ่มแผนภูมิ, คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ก่อน, ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิ, ระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะผสานแผนภูมิเข้าสู่การนำเสนอของคุณโดยตรง

**How can I update the data displayed in a chart?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)), ลบซีรีส์และหมวดหมู่เริ่มต้น, แล้วเพิ่มข้อมูลแบบกำหนดเองของคุณเอง ซึ่งทำให้คุณรีเฟรชแผนภูมิเพื่อแสดงข้อมูลล่าสุดได้ตามโปรแกรม

**Is it possible to customize the appearance of the chart?**

ใช่, Aspose.Slides for PHP via Java มีตัวเลือกการปรับแต่งที่หลากหลาย คุณสามารถแก้ไขสี, แบบอักษร, ป้าย, เลเจนด์, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงตามความต้องการออกแบบของคุณได้อย่างเต็มที่.