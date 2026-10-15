---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: แกนแผนภูมิ
type: docs
url: /th/php-java/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. ครอบคลุมค่าแกนที่คำนวณ, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ช่วงเวลาที่แสดงป้ายชื่อและเครื่องหมายติกของหมวดหมู่, หมวดหมู่วันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การกำหนดตำแหน่งแกน, หน่วยการแสดงผล, และการสเกลแบบลอการิทึม.

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [งานนำเสนอ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่พร้อมข้อมูลเริ่มต้น. เรียก [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) และ [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) เพื่อรับขอบเขตของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) และ [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) เพื่อรับช่วงของเครื่องหมายติก. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างนี้เก็บค่าต่าง ๆ เหล่านี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();

    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();

    $majorUnit = $chart->getAxes()->getVerticalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getVerticalAxis()->getActualMinorUnit();

    $majorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMajorUnitScale();
    $minorUnitScale = $chart->getAxes()->getVerticalAxis()->getActualMinorUnitScale();

    $presentation->save("AxisValues_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) เพื่อสลับบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ. หมวดหมู่เดิมแต่ละอันจะเปลี่ยนเป็นซีรีส์, และซีรีส์เดิมแต่ละอันจะเปลี่ยนเป็นหมวดหมู่. สิ่งนี้เปลี่ยนการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5`, รวมถึงแถวหัวเรื่องและคอลัมน์หมวดหมู่, ก่อนสลับแถวและคอลัมน์. มันบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $chart->getChartData()->setRange("Sheet1!A1:D5");
    $chart->getChartData()->switchRowColumn();

    $presentation->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กลับลำดับการพล็อตของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setplotorderreversed/) เพื่อกลับลำดับของแกนหมวดหมู่หรือค่า. ตัวอย่างเช่น แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับแผ่นงาน: Planning, Development, Testing. การกลับแกนจะเปลี่ยนทิศทางการพล็อต; ไม่ได้เรียงลำดับหรือจัดเรียงข้อมูลในเวิร์กบุ๊ก. เทียบกับ [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/), ซึ่งสลับบทบาทของซีรีส์และหมวดหมู่.

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์. มันบันทึกงานนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดหมู่กลับ, และค่ากลับ. แต่ละสำเนาใช้ชุดข้อมูลเดียวกัน, และมีเพียงแกนเดียวที่ถูกกลับในแต่ละสำเนา.

```php
use aspose\slides\ChartType;
use aspose\slides\CrossesType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredBar, 50, 40, 620, 320);
    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredBar);
    $stages = ["Planning", "Development", "Testing"];
    $values = [10, 30, 20];
    for ($i = 0; $i < count($stages); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $stages[$i]);
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    // สไลด์ 2: แสดงหมวดหมู่แรกที่ด้านบน.
    $categorySlide = $presentation->getSlides()->addClone($slide);
    $categoryChart = $categorySlide->getShapes()->get_Item(0);
    $categoryChart->getAxes()->getVerticalAxis()->setPlotOrderReversed(true);
    // คงแกนค่าที่แนวนอนไว้ที่ด้านล่าง.
    $categoryChart->getAxes()->getVerticalAxis()->setCrossType(CrossesType::Maximum);

    // สไลด์ 3: กลับลำดับเฉพาะสเกลเชิงตัวเลขแนวนอน.
    $valueSlide = $presentation->getSlides()->addClone($slide);
    $valueChart = $valueSlide->getShapes()->get_Item(0);
    $valueChart->getAxes()->getHorizontalAxis()->setPlotOrderReversed(true);

    $presentation->save("ReversedAxes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การกลับแกนอาจทำให้แกนตั้งฉากย้ายไปยังด้านตรงข้ามของพล็อต. [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) ควบคุมว่าตำแหน่งที่แกนอื่นตัดกับแกนที่กำหนด. ในสไลด์ที่ 2, การเรียกด้วย `CrossesType::Maximum` บนแกนหมวดหมู่ที่กลับจะทำให้แกนค่าที่แนวนอนอยู่ที่ด้านล่าง. หากต้องการจุดตัดที่เจาะจง, ใช้ [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). ตรวจสอบการตั้งค่าการตัดเมื่อเปลี่ยนทิศทาง, โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดที่กำหนดเองแล้ว. เรียก `setPlotOrderReversed` ด้วย `false` เพื่อคืนทิศทางการพล็อตปกติ; การตั้งค่าการตัดเป็นสิ่งแยกกัน.

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่กลับ (สไลด์ 2) | ค่ากลับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับหมวดหมู่และแกนค่าปกติ](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงหมวดหมู่จากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่ากลับและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| หมวดหมู่วิ่งจากล่างขึ้นบน; ค่ามีการเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing วิ่งจากบนลงล่าง. ค่และลำดับแถวของเวิร์กบุ๊กไม่มีการเปลี่ยนแปลง. | หมวดหมู่ยังคงลำดับปกติ; ค่ามีการเพิ่มจากขวาไปซ้าย. แกนหมวดหมู่ตัดที่ศูนย์ด้านขวา. |

## **ปิดการแสดงผลแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน. ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกไว้โดยมีแกนแนวตั้งถูกซ่อน.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);

    $presentation->save("HiddenVerticalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ปิดการแสดงผลแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน. ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกไว้โดยมีแกนแนวนอนถูกซ่อน.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);

    $presentation->save("HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ. ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx`, โดยมีแผนภูมิเป็นรูปแบบแรกบนสไลด์แรกและเซลล์หมวดหมู่อยู่ในรูปแบบวันที่แบบเลขของ Excel. มันเปลี่ยนแกนแนวนอนเป็นแกนวันที่. การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) ด้วยค่า `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) ด้วยค่า `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) ด้วยค่า `TimeUnitType::Months` จะวางเครื่องหมายหลักที่ช่วงหนึ่งเดือน.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TimeUnitType;

$presentation = new Presentation("ExistingChart.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);

    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ควบคุมช่วงเวลาของป้ายชื่อแกนหมวดหมู่**

เมื่อแผนภูมิมีหลายหมวดหมู่, ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหมู่หรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) ด้วยค่า `false`, จากนั้นส่งช่วงหมวดหมู่ที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). สำหรับหมวดหมู่ข้อความในลำดับปกติ, การนับเริ่มจากหมวดหมู่แรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

ช่วง `3` จะแสดงทุกป้ายที่สาม, ทำให้สองป้ายอยู่ระหว่างที่ซ่อน. มันไม่ได้ลบคอลัมน์ที่เกี่ยวข้อง. การจัดช่องอัตโนมัติจะเลือกช่วงตามพื้นที่ที่มี; ไม่จำเป็นต้องแสดงทุกป้าย.

เครื่องหมายติกมีการควบคุมแยกกัน. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) ด้วยค่า `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) เพื่อกำหนดช่วงของมัน. ตัวอย่างเช่น, ค่า `1` จะทำให้มีเครื่องหมายติกที่ทุกช่วงของหมวดหมู่ในขณะที่ป้ายชื่อปรากฏเฉพาะทุกหมวดที่สาม. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) ด้วยสไตล์ที่มองเห็นได้เพื่อดูผล. การเรียกตั้งค่าอัตโนมัติใด ๆ ด้วยค่า `true` อีกครั้งจะให้แผนภูมิเ�เลือกช่วงนั้นใหม่.

ตัวอย่างอิสระต่อไปนี้สร้าง 24 หมวดหมู่และหนึ่งซีรีส์, จากนั้นบันทึกสามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การจัดช่องอัตโนมัติ, การจัดช่องป้ายชื่อด้วยติกอิสระ, และการคืนค่าการจัดช่องอัตโนมัติ. สองสำเนาเก็บข้อมูลแผนภูดิดั้งเดิม. ไม่จำเป็นต้องมีงานนำเข้าก่อน. ข้อความป้ายชื่อแนวนอนทำให้เห็นความแตกต่างของความหนาแน่นได้ง่าย.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TickMarkType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

    $chart->setLegend(false);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::ClusteredColumn);
    for ($i = 0; $i < 24; $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Category " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);
        $valueCell = $workbook->getCell(0, $i + 1, 1, 10 + $i % 6 * 5);
        $series->getDataPoints()->addDataPointForBarSeries($valueCell);
    }

    $axis = $chart->getAxes()->getHorizontalAxis();
    $axis->setCategoryAxisType(CategoryAxisType::Text);
    $axis->getTextFormat()->getTextBlockFormat()->setRotationAngle(0);
    $axis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $axis->setMajorTickMark(TickMarkType::Outside);
    $axis->setAutomaticTickLabelSpacing(true);
    $axis->setAutomaticTickMarksSpacing(true);

    // สไลด์ 2: แสดงป้ายชื่อทุกสามรายการ, แต่คงเครื่องหมายติกสำหรับทุกหมวดหมู่.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมเลือกระยะห่างทั้งสองอีกครั้ง.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**การจัดช่องอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้, ป้ายชื่อของทุกหมวดที่สองจะแสดงและต่อเนื่องเป็นสองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และตัวเรนเดอร์.

![การจัดช่องป้ายชื่อหมวดหมู่อัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็น](category-axis-automatic.png)

**การจัดช่องด้วยตนเอง (สไลด์ 2):** ป้ายชื่อที่สามจะแสดงในบรรทัดเดียว, ในขณะที่เครื่องหมายติกยังคงอยู่ที่ทุกช่วงของหมวดหมู่. คอลัมน์ทั้งหมด 24 คอลัมน์, รวมถึงที่ไม่มีป้ายชื่อ, ยังคงมองเห็นด้วยค่าที่เหมือนกัน. สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงด้านบน.

![การจัดช่องป้ายชื่อหมวดหมู่ด้วยตนเองที่สามกับคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็น](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวณหมวดหมู่นี้สำหรับแกนหมวดหมู่แบบข้อความ, เช่น แกนหมวดหมู่ของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง. ในแผนภูมิคอลัมน์, มันคือแกนแนวนอน. ในแผนภูมิแท่งแนวนอน, แกนหมวดหมู่เป็นแนวตั้ง, ดังนั้นให้ใช้การตั้งค่านี้กับแกนที่คืนค่าจาก [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). การจัดช่องเครื่องหมายติกยังใช้กับแกนซีรีส์ในแผนภูมิที่มี.

อย่าใช้การจัดช่องป้ายชื่อหมวดหมู่เพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) ระบุความแตกต่างของค่า: ตัวอย่างเช่น หน่วยหลัก `10` จะสร้างติกที่ 0, 10, 20, ฯลฯ เมื่อแกนเริ่มจากศูนย์. ช่วงป้ายชื่อหมวดหมู่ `3` จะนับตำแหน่งของหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล. แผนภูมิกระจายและบับเบิลใช้แกนค่าแทนแกนหมวดหมู่แบบข้อความ. สำหรับแกนวันที่, ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis).

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าปีสี่ค่า. วันที่ถูกเก็บเป็นหมายเลขอนุกรม OLE Automation ในเวิร์กชีทแรก (ดัชนี `0`), คำนวณเป็นจำนวนวันตั้งแต่วันที่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) ด้วยค่า `CategoryAxisType::Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) ด้วยค่า `false`, และส่งค่า `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) เพื่อให้ป้ายชื่อหมวดหมู่แสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบของเซลล์.

```php
use aspose\slides\CategoryAxisType;
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $baseDate = gmmktime(0, 0, 0, 12, 30, 1899);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    for ($i = 0; $i < 4; $i++) {
        $date = gmmktime(0, 0, 0, 1, 1, 2015 + $i);
        $serialDate = ($date - $baseDate) / 86400;
        $categoryCell = $workbook->getCell(0, $i + 1, 0, $serialDate);
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $i + 1);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");

    $presentation->save("DateAxisFormat.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนของแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) ด้วยค่า `true` บนแกนแนวตั้ง, ให้ข้อความหัวเรื่อง, และใช้ [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนหัวเรื่อง. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวเรื่องแกนค่าถูกหมุน 90 องศา.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("Value");
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);

    $presentation->save("RotatedAxisTitle.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าตำแหน่งแกนบนแกนหมวดหมู่หรือแกนค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) เพื่อควบคุมว่าแกนค่าตัดกับแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่เครื่องหมายติกของหมวดหมู่. การตั้งค่านี้ใช้กับแกนหมวดหมู่. ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);

    $presentation->save("AxisBetweenCategories.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) เพื่อปรับขนาดป้ายชื่อบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) ตั้งค่าเป็น `Millions`, ค่า 60,000,000 จะแสดงเป็น 60. ตัวอย่างนี้สร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้งของมัน.

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);

    $presentation->save("Result.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **กำหนดค่าแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายระดับขนาด. ตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าช่วงเวลา. บนสเกลเชิงเส้น, ค่าที่เล็กจะอยู่ใกล้กันใกล้ศูนย์. สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพัทธ์ง่ายขึ้น: ระยะทางเท่ากันแสดงอัตราส่วนที่เท่ากันไม่ใช่ความแตกต่างเท่ากัน.

เรียก [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) ด้วยค่า `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) เพื่อเลือกฐาน. สิ่งนี้เปลี่ยนวิธีการแสดงค่าที่มีอยู่; ไม่ได้เปลียนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มแสดงความสัมพันธ์ที่ฟิตกับข้อมูลและเป็นคุณลักษณะแยกต่างหาก.

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าถูกคืนค่าจาก [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). สำหรับแผนภูแท่งแนวนอน, แกนคือตรงจาก [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). แผนภูมิกระจายและบับเบิลมีสองแกนค่า, ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง. อย่าใช้การสเกลลอการิทึมกับแกนหมวดหมู่.

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX, ใช้ฐานจาก `2` ถึง `1000` รวมถึง; ฐานเศษส่วนเช่น `2.5` ก็สนับสนุน. ด้วยฐาน `10`, พลังที่ต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะห่างกันเท่ากัน.

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างอิสระต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าครั้งบนสไลด์แรก, จากนั้นคลอนสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง. ทั้งสองสไลด์เก็บข้อมูลเดียวกัน.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::Line, 30, 40, 660, 200);

    $chart->setLegend(false);

    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();

    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->clear(0);

    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $values = [10, 100, 1000, 10000, 100000];

    for ($i = 0; $i < count($values); $i++) {
        $categoryCell = $workbook->getCell(0, $i + 1, 0, "Period " . ($i + 1));
        $chart->getChartData()->getCategories()->add($categoryCell);

        $valueCell = $workbook->getCell(0, $i + 1, 1, $values[$i]);
        $series->getDataPoints()->addDataPointForLineSeries($valueCell);
    }

    // คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
    $logarithmicSlide = $presentation->getSlides()->addClone($slide);
    $logarithmicChart = $logarithmicSlide->getShapes()->get_Item(0);
    $valueAxis = $logarithmicChart->getAxes()->getVerticalAxis();
    $valueAxis->setLogarithmic(true);
    $valueAxis->setLogBase(10);

    $presentation->save("LogarithmicAxis.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะทางแนวตั้งที่เท่ากันแสดงความแตกต่างที่เท่ากันของจำนวนคำขอ. ค่าที่ใหญ่ที่สุดครองชั้นแผนภูมิ, ทำให้ค่าที่เล็กยากต่อการแยกแยะ.

![แผนภูมิเส้นใน PowerPoint แสดงจำนวนคำขอห้าครั้งบนแกนค่เชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะทางแนวตั้งที่เท่ากันแสดงอัตราส่วนที่เท่ากัน. แต่ละช่วงมีจำนวนคำขอมากกว่าช่วงก่อนหน้าถึงสิบเท่า, ดังนั้นจุดจะสร้างเส้นตรงที่ขึ้นบนสเกลฐาน 10. ป้ายกำกับแกนยังคงแสดงจำนวนคำขอเดิม.

![จำนวนคำขอห้าเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าลบ**

สเกลลอการิทึมสามารถแสดงค่าเป็นบวกเท่านั้น. ตรวจสอบข้อมูลก่อนเปิดใช้งาน. หากค่าศูนย์หรือค่าลบมีความหมาย, ควรใช้สเกลเชิงเส้นหรือแสดงแยกออก. หากการยกเว้นค่านั้นเหมาะกับการวิเคราะห์, ควรอธิบายการละเลย. อย่าเปลี่ยนค่าดังกล่าวเป็นค่าบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล. ค่าต่ำสุดหรือสูงสุดใด ๆ ที่กำหนดด้วยมือสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน.

## **คำถามที่พบบ่อย**

**ฉันตั้งค่าค่าที่แกนหนึ่งตัดแกนอีกอย่างไร (การตัดแกน)?**

ใช้ [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) เพื่อเลือกพฤติกรรมการตัด. หากต้องการระบุค่าตัดเป็นตัวเลข, ใช้ [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายจุดตัดของแกนไปยังระดับฐานที่เหมาะสม.

**ฉันสามารถกำหนดตำแหน่งป้ายติกสัมพันธ์กับแกนได้อย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) ด้วย [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายติกเอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) หรือ [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); สิ่งเหล่านี้แยกจากการจัดตำแหน่งป้าย.