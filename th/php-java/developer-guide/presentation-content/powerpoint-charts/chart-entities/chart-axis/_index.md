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
- ค่ามากสุด
- ค่าน้อยสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผล"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. มันครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การมองเห็นของแกน, ช่วงเวลาของป้ายหมวดหมู่และเครื่องหมาย Tick, หมวดวันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การวางตำแหน่งแกน, หน่วยแสดงผล, และการสเกลแบบลอการิทึม.

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่ด้วยข้อมูลค่าเริ่มต้น. เรียก [validateChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/chart/validatechartlayout/) ก่อนที่จะอ่านค่าที่คำนวณของแกนเพื่อให้เลเอาต์ของแผนภูมิเป็นปัจจุบัน.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmaxvalue/) และ [getActualMinValue](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminvalue/) เพื่อรับขีดจำกัดของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunit/) และ [getActualMinorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunit/) เพื่อรับช่วงของเครื่องหมาย Tick. [getActualMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualmajorunitscale/) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/getactualminorunitscale/) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างนี้เก็บค่าต่าง ๆ ไว้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ.

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/switchrowcolumn/) เพื่อสลับบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ. หมวดหมู่เดิมแต่ละรายการจะกลายเป็นซีรีส์, และซีรีส์เดิมแต่ละรายการจะกลายเป็นหมวดหมู่. สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/setrange/) เพื่อผูกข้อมูลค่าเริ่มต้นกับ `Sheet1!A1:D5`, รวมทั้งแถวหัวข้อและคอลัมน์หมวดหมู่, ก่อนสลับแถวและคอลัมน์. ตัวอย่างบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่.

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

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน.

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

## **ปิดการแสดงแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setvisible/) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน.

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

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) เพื่อเลือกเป็นแกนหมวดหมู่แบบวันที่หรือข้อความ. ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx`, ซึ่งมีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์หมวดหมู่มีค่าตัวเลขของวันที่ Excel. ตัวอย่างเปลี่ยนแกนแนวนอนเป็นแกนวันที่. เรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticmajorunit/) ด้วยค่า `false`, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) ด้วยค่า `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunitscale/) ด้วยค่า `TimeUnitType::Months` เพื่อกำหนดเครื่องหมายหลักให้มีช่วงหนึ่งเดือน.

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

## **ควบคุมช่วงเวลาของป้ายแกนหมวดหมู่**

เมื่อแผนภูมิมีหมวดหมู่จำนวนมาก, สามารถลดจำนวนป้ายแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหมู่หรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomaticticklabelspacing/) ด้วยค่า `false`, จากนั้นส่งค่าช่วงหมวดหมู่ที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelspacing/). สำหรับหมวดหมู่ข้อความตามลำดับปกติ, การนับจะเริ่มที่หมวดหมู่แรก:

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | หมวดหมู่ 1, หมวดหมู่ 2, หมวดหมู่ 3, ... หมวดหมู่ 24 |
| `2` | หมวดหมู่ 1, หมวดหมู่ 3, หมวดหมู่ 5, ... หมวดหมู่ 23 |
| `3` | หมวดหมู่ 1, หมวดหมู่ 4, หมวดหมู่ 7, ... หมวดหมู่ 22 |

ช่วง `3` จะแสดงป้ายทุกสามตำแหน่ง, ทำให้มีสองป้ายที่ซ่อนอยู่ระหว่างป้ายที่แสดง. มันไม่ได้ลบคอลัมน์ที่สอดคล้องกัน. การเว้นระยะอัตโนมัติจะเลือกช่วงตามพื้นที่ที่มี; ไม่ได้จำเป็นต้องแสดงทุกป้าย.

เครื่องหมาย Tick มีการควบคุมแยกต่างหาก. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setautomatictickmarksspacing/) ด้วยค่า `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settickmarksspacing/) เพื่อกำหนดช่วงของมัน. ตัวอย่างเช่น, ค่า `1` จะวางเครื่องหมาย Tick ที่ทุกช่วงหมวดหมู่ในขณะที่ป้ายปรากฏเพียงทุกหมวดหมู่ที่สาม. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) พร้อมสไตล์ที่มองเห็นได้เพื่อให้เห็นผลลัพธ์. การตั้งค่าอัตโนมัติใด ๆ ด้วยค่า `true` อีกครั้งจะทำให้แผนภูมิเลือกช่วงนั้นใหม่อีกครั้ง.

ตัวอย่างที่เป็นอิสระต่อไปนี้สร้างหมวดหมู่ 24 รายการและซีรีส์หนึ่งรายการ, จากนั้นบันทึกสามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การเว้นระยะอัตโนมัติ, การเว้นระยะป้ายแบบกำหนดเองพร้อมเครื่องหมาย Tick แยกกัน, และการคืนค่าเว้นระยะอัตโนมัติ. ทั้งสองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม. ไม่จำเป็นต้องมีไฟล์นำเข้ารายการนำเสนอ. ข้อความป้ายแนวนอนทำให้ความหนาแน่นของคอลัมน์เห็นได้ง่าย.

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

    // สไลด์ 2: แสดงป้ายทุกสามตำแหน่ง แต่คงเครื่องหมาย Tick สำหรับทุกหมวดหมู่.
    $manualSlide = $presentation->getSlides()->addClone($slide);
    $manualChart = $manualSlide->getShapes()->get_Item(0);
    $manualAxis = $manualChart->getAxes()->getHorizontalAxis();
    $manualAxis->setAutomaticTickLabelSpacing(false);
    $manualAxis->setTickLabelSpacing(3);
    $manualAxis->setAutomaticTickMarksSpacing(false);
    $manualAxis->setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเลือกช่วงทั้งสองอีกครั้ง.
    $restoredSlide = $presentation->getSlides()->addClone($manualSlide);
    $restoredChart = $restoredSlide->getShapes()->get_Item(0);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickLabelSpacing(true);
    $restoredChart->getAxes()->getHorizontalAxis()->setAutomaticTickMarksSpacing(true);

    $presentation->save("CategoryAxisIntervals.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

**การเว้นระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้, ป้ายหมวดหมู่ทุกสองตำแหน่งจะแสดงและห่อขึ้นสองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างขึ้นอยู่กับขนาดแผนภูมิ, ฟอนต์, และเครื่องเรนเดอร์.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**การเว้นระยะแบบกำหนดเอง (สไลด์ 2):** ป้ายทุกสามตำแหน่งจะแสดงในบรรทัดเดียว, ในขณะที่เครื่องหมาย Tick ยังคงอยู่ที่ทุกช่วงหมวดหมู่. คอลัมน์ทั้งหมด 24 คอลัมน์, รวมถึงที่ไม่มีป้าย, ยังคงมองเห็นได้พร้อมค่าที่เหมือนกัน. สไลด์ 3 คืนค่าเว้นระยะอัตโนมัติที่แสดงด้านบน.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนหมวดหมู่นี้สำหรับแกนหมวดหมู่แบบข้อความ, เช่นแกนหมวดหมู่ของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแถบ. ในแผนภูมิคอลัมน์, มันคือแกนแนวนอน. ในแผนภูมิแถวนอน, แกนหมวดหมู่อยู่แนวตั้ง, ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). การเว้นระยะเครื่องหมาย Tick ยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์.

ห้ามใช้การเว้นระยะป้ายหมวดหมู่เพื่อกำหนดสเกลเชิงตัวเลขของแกนค่. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajorunit/) ระบุความแตกต่างของค่า: ตัวอย่างเช่น, หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20, ฯลฯ เมื่อแกนเริ่มที่ศูนย์. ช่วงป้ายหมวดหมู่ `3` จะนับตำแหน่งหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล. แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดหมู่แบบข้อความ. สำหรับแกนวันที่, ให้ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis).

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิปริยายด้วยค่าปีสี่ค่า. วันที่ถูกเก็บเป็นหมายเลขซีเรียล OLE Automation ในชีตแรก (ดัชนี `0`), คำนวนเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcategoryaxistype/) ด้วย `CategoryAxisType::Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformatlinkedtosource/) ด้วย `false`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setnumberformat/) เพื่อให้ป้ายหมวดหมู่แสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบของเซลล์.

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

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/axis/settitle/) ด้วยค่า `true` บนแกนแนวตั้ง, ระบุข้อความชื่อ, และใช้ [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนชื่อ. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่ชื่อแกนค่าถูกหมุน 90 องศา.

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

## **ตั้งค่าตำแหน่งของแกนบนแกนหมวดหมู่หรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setaxisbetweencategories/) เพื่อควบคุมว่แกนค่าแยกกับแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่เครื่องหมาย Tick ของหมวดหมู่. การตั้งค่านี้ใช้กับแกนหมวดหมู่. ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์.

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

## **ตั้งค่าหน่วยแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setdisplayunit/) เพื่อสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/php-java/aspose.slides/displayunittype/) ตั้งเป็น `Millions`, ค่า 60,000,000 จะแสดงเป็น 60. ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง.

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

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายลำดับของขนาด. ตัวอย่างเช่น, เซิร์ฟเวอร์อาจได้รับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าช่วงเวลา. บนสเกลเชิงเส้น, ค่าที่เล็กกว่าจะอยู่ใกล้ศูนย์กัน. สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพัทธ์ง่ายขึ้น: ระยะห่างที่เท่ากันแทนสัดส่วนที่เท่ากัน ไม่ได้แทนความแตกต่างเดียวกัน.

เรียก [setLogarithmic](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogarithmic/) ด้วยค่า `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setlogbase/) เพื่อเลือกฐาน. การตั้งค่านี้เปลี่ยนวิธีการแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหากที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล.

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าถูกคืนจาก [getVerticalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/getverticalaxis/). สำหรับแผนภูมิเสท็อดแนวนอน, แกนค่าถูกคืนจาก [getHorizontalAxis](https://reference.aspose.com/slides/php-java/aspose.slides/axesmanager/gethorizontalaxis/). แผนภูมิกระจายและฟองมีแกนค่าสองแกน, ดังนั้นให้เลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสองแกน. ห้ามใช้การสเกลลอการิทึมกับแกนหมวดหมู่.

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX, สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานทศนิยมเช่น `2.5`. ด้วยฐาน `10`, พลังที่ต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะมีระยะห่างเท่ากัน.

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าครั้งบนสไลด์แรก, จากนั้นทำสำเนาสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง. ทั้งสองสไลด์รักษาข้อมูลเดิมไว้.

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

    // รักษาสไลด์แรกเป็นเชิงเส้นและเปลี่ยนเฉพาะสเกลแกนค่าของสำเนา
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

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งที่เท่ากันแทนความแตกต่างของจำนวนคำขอที่เท่า ๆ กัน. ค่าที่ใหญ่ที่สุดครอบคลุมแผนภูมิ, ทำให้ค่าที่เล็กกว่ากลายเป็นยากต่อการมองเห็น.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งที่เท่ากันแทนอัตราส่วนที่เท่า ๆ กัน. แต่ละช่วงมีจำนวนคำขอมากกว่าช่วงก่อนหน้าเท่ากับสิบเท่า, ดังนั้นจุดข้อมูลจะแสดงเป็นเส้นตรงขึ้นบนสเกลฐาน 10. ป้ายแกนยังคงแสดงจำนวนคำขอตามเดิม.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงค่าบวกเท่านั้น. ตรวจสอบข้อมูลก่อนเปิดใช้งาน. หากค่าศูนย์หรือค่าติดลบมีความหมาย, ควรใช้สเกลเชิงเส้นหรือแสดงแยกต่างหาก. หากการละเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์, ควรอธิบายเหตุผล. ห้ามแทนที่ค่าดังกล่าวด้วยค่าบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล. ค่าต่ำสุดหรือค่าสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกเช่นกัน.

## **FAQ**

**How do I set the value at which one axis crosses the other (axis crossing)?**

ใช้ [setCrossType](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrosstype/) เพื่อเลือกพฤติกรรมการตัดกันของแกน. หากต้องการระบุค่าตัดกันเชิงตัวเลข, ใช้ [setCrossAt](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setcrossat/). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายจุดตัดแกนไปยังฐานที่เหมาะสม.

**How can I position tick labels relative to the axis?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setticklabelposition/) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/php-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมาย Tick เอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setmajortickmark/) หรือ [setMinorTickMark](https://reference.aspose.com/slides/php-java/aspose.slides/axis/setminortickmark/); สิ่งเหล่านี้แยกจากการวางตำแหน่งป้าย.