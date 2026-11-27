---
title: จัดรูปแบบแผนภูมิการนำเสนอใน PHP
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/php-java/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- องค์ประกอบแผนภูมิ
- คุณสมบัติแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติฟอนต์
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ PHP ผ่าน Java และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิที่โค้งมน."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides โดยแสดงวิธีปรับแต่งส่วนประกอบหลักของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมผนัง เพื่อปรับปรุงลักษณะและความอ่านง่ายของข้อมูลแผนภูมิ

บทความยังสาธิตวิธีตั้งค่าคุณสมบัติกแบบอักษรสำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขสำเร็จรูปกับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งของพื้นที่แผนภูมิ ตัวอย่างเหล่านี้ร่วมกันแสดงวิธีควบคุมทั้งสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

สำหรับการเติมและเส้นขอบแยกต่างหากบนช่วงที่เพิ่มขึ้นและลดลง ดู[ตัวอย่างแผนภูมิหุ้น](/slides/th/php-java/create-chart/#create-stock-charts)

## **จัดรูปแบบองค์ประกอบแผนภูมิ**

ใช้[Chart](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)เพื่อจัดรูปแบบชื่อเรื่องแผนภูมิ, แกน, เส้นกริด, คำอธิบาย, และพื้นที่พล็อต ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมตัวบ่งชี้และข้อมูลเริ่มต้น แล้วใช้สไตล์ข้อความและเส้นแยกต่างหากกับแกนค่และแกนประเภทของมัน ขนาดแบบอักษรและความกว้างของเส้นกำหนดเป็นจุด; ป้ายกำกับประเภทจะหมุน 45 องศา

แกนค่าใช้[setNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setNumberFormat)โดยอิสระจากเซลล์ต้นฉบับ ช่วงสเกลเริ่มตั้งแต่ -2 ถึง 15, มีช่วงหลักที่ 2 และช่วงย่อยที่ 0.5 ตัวอย่างนี้ยังผสานการจัดรูปแบบเปอร์เซ็นต์กับ[setDisplayUnit](https://reference.aspose.com/slides/php-java/aspose.slides/axis/#setDisplayUnit)ตั้งเป็นพัน ดังนั้นให้ปรับค่าตามความหมายและขนาดของข้อมูลของคุณ คำอธิบายอยู่ด้านนอกพื้นที่พล็อตเพราะ[setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#setOverlay)ถูกเรียกด้วย `false` การเติมผนังหลังและพื้นผ่าน[getBackWall](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getBackWall)และ[getFloor](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getFloor) แต่พื้นผิวเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3 มิติ

```php
use aspose\slides\ChartType;
use aspose\slides\DisplayUnitType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LineDashStyle;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\TickLabelPositionType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 50, 50, 500, 400);

    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("");
    $chartTitle = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $chartTitle->setText("Sample Chart");
    $chartTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chartTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chartTitle->getPortionFormat()->setFontHeight(20);
    $chartTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $chartTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);
    $chart->getAxes()->getVerticalAxis()->getMajorGridLinesFormat()->getLine()->setDashStyle(LineDashStyle::DashDot);

    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $chart->getAxes()->getVerticalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Thousands);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.0%");

    $chart->getAxes()->getVerticalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinorUnit(false);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);

    $chart->getAxes()->getVerticalAxis()->setMaxValue(15);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-2);
    $chart->getAxes()->getVerticalAxis()->setMinorUnit(0.5);
    $chart->getAxes()->getVerticalAxis()->setMajorUnit(2.0);

    $valueAxisText = $chart->getAxes()->getVerticalAxis()->getTextFormat()->getPortionFormat();
    $valueAxisText->setFontBold(NullableBool::True);
    $valueAxisText->setFontHeight(16);
    $valueAxisText->setFontItalic(NullableBool::True);
    $valueAxisText->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkGreen);
    $valueAxisText->setLatinFont(new FontData("Times New Roman"));

    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->addTextFrameForOverriding("");
    $valueAxisTitle = $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $valueAxisTitle->setText("Primary Axis");
    $valueAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $valueAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $valueAxisTitle->getPortionFormat()->setFontHeight(20);
    $valueAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $valueAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 128, 0));
    $chart->getAxes()->getHorizontalAxis()->getMajorGridLinesFormat()->getLine()->setWidth(5);

    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    $chart->getAxes()->getHorizontalAxis()->getMinorGridLinesFormat()->getLine()->setWidth(3);

    $categoryAxisText = $chart->getAxes()->getHorizontalAxis()->getTextFormat()->getPortionFormat();
    $categoryAxisText->setFontBold(NullableBool::True);
    $categoryAxisText->setFontHeight(16);
    $categoryAxisText->setFontItalic(NullableBool::True);
    $categoryAxisText->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisText->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $categoryAxisText->setLatinFont(new FontData("Arial"));

    $chart->getAxes()->getHorizontalAxis()->setTitle(true);
    $chart->getAxes()->getHorizontalAxis()->getTitle()->addTextFrameForOverriding("");

    $categoryAxisTitle = $chart->getAxes()->getHorizontalAxis()->getTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $categoryAxisTitle->setText("Sample Category");
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $categoryAxisTitle->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $categoryAxisTitle->getPortionFormat()->setFontHeight(20);
    $categoryAxisTitle->getPortionFormat()->setFontBold(NullableBool::True);
    $categoryAxisTitle->getPortionFormat()->setFontItalic(NullableBool::True);

    $chart->getAxes()->getHorizontalAxis()->setTickLabelPosition(TickLabelPositionType::Low);
    $chart->getAxes()->getHorizontalAxis()->setTickLabelRotationAngle(45);

    $legendText = $chart->getLegend()->getTextFormat()->getPortionFormat();
    $legendText->setFontBold(NullableBool::True);
    $legendText->setFontHeight(16);
    $legendText->setFontItalic(NullableBool::True);
    $legendText->getFillFormat()->setFillType(FillType::Solid);
    $legendText->getFillFormat()->getSolidFillColor()->setPresetColor(PresetColor::DarkRed);

    $chart->getLegend()->setOverlay(false);

    $chart->getBackWall()->setThickness(1);
    $chart->getBackWall()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getBackWall()->getFormat()->getFill()->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 165, 0));

    $chart->getFloor()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getFloor()->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);

    $chart->getPlotArea()->getFormat()->getFill()->setFillType(FillType::Solid);
    $chart->getPlotArea()->getFormat()->getFill()->getSolidFillColor()->setPresetColor(PresetColor::LightCyan);

    $presentation->save("FormattedChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับแผนภูมิ**

ตั้งขนาดฟอนต์เริ่มต้นสำหรับข้อความแผนภูมิผ่าน[Chart::getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getTextFormat) ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมฟอนต์ขนาด 20 จุดและเปิดใช้งานป้ายค่าของชุดแรกผ่าน[setShowValue](https://reference.aspose.com/slides/php-java/aspose.slides/datalabelformat/#setShowValue) องค์ประกอบข้อความที่มีการตั้งค่าฟอนต์แบบชัดเจนของตนเองสามารถแทนที่ค่าเริ่มต้นของแผนภูมิได้

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 500, 400);
    $chart->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("FontPropertiesForChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ใช้การจัดรูปแบบกรอบข้อความซ้ำสำหรับคำอธิบายแผนภูมิ**

เพื่อให้คำอธิบายตรงกับหัวข้อสไลด์ ให้ตั้งค่าฟอนต์ของหัวข้อผ่าน[getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat)บนย่อหน้าที่หนึ่ง เรียก[copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyFrom)บนรูปแบบที่ได้จาก[getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/#getTextFormat)ของคำอธิบาย มันจะคัดลอกการตั้งค่ากรอบข้อความ, การจัดรูปแบบของย่อหน้าแรก, และคุณสมบัติตัวอักษรเริ่มต้นของย่อมนั้น การจัดรูปแบบที่ใช้งานโดยตรงกับส่วนย่อยแต่ละส่วนหรือกับย่อหน้าถัดไปจะคงอยู่เฉพาะที่แหล่งข้อมูล

ตัวอย่างใช้หัวข้อ Calibri ขนาด 26 จุดหนา สีกรมท่าเป็นแม่แบบ หลังจากสไตล์คำอธิบายแล้ว จะเรียก[copyTo](https://reference.aspose.com/slides/php-java/aspose.slides/charttextformat/#copyTo)เพื่อใช้รูปแบบเดียวกันกับคำบรรยายแยกต่างหาก

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\LegendPositionType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\StyleType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $heading = $shapes->addAutoShape(ShapeType::Rectangle, 40, 20, 640, 40, false);
    $sourceTextFrame = $heading->addTextFrame("Quarterly sales");
    $font = $sourceTextFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
    $font->setLatinFont(new FontData("Calibri"));
    $font->setFontHeight(26);
    $font->setFontBold(NullableBool::True);
    $font->getFillFormat()->setFillType(FillType::Solid);
    $font->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 32, 64, 96));

    $chart = $shapes->addChart(ChartType::ClusteredColumn, 40, 75, 640, 360);
    $chart->setStyle(StyleType::Style3);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $workbook->getCell(0, 0, 1)->setValue("Retail");
    $workbook->getCell(0, 0, 2)->setValue("Online");
    $workbook->getCell(0, 0, 3)->setValue("Wholesale");
    for ($quarter = 1; $quarter <= 4; $quarter++) {
        $workbook->getCell(0, $quarter, 0)->setValue("Q" . $quarter);
    }

    $chart->setLegend(true);
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $legendFormat = $chart->getLegend()->getTextFormat();
    $legendFormat->copyFrom($sourceTextFrame);

    $caption = $shapes->addAutoShape(ShapeType::Rectangle, 40, 460, 640, 40, false);
    $captionTextFrame = $caption->addTextFrame("Sales in millions of dollars");
    $legendFormat->copyTo($captionTextFrame);

    $presentation->save("legend-formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ในการนำเสนอที่บันทึกไว้ คำอธิบายและคำบรรยายจะตรงกับหัวข้อในด้านขนาด, น้ำหนัก, และสี คำอธิบายยังคงแสดงชื่อชุดข้อมูล, ส่วนคำบรรยายยังคงข้อความของตนเอง หากส่วนในคำบรรยายมีการตั้งค่าขนาดฟอนต์อย่างชัดเจน ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าตั้งต้นของย่อหน้าที่คัดลอก

| ก่อนคัดลอก | หลังคัดลอก |
| --- | --- |
| ![แผนภูมิยอดขายไตรมาสที่มีคำอธิบายสีดำและคำบรรยายสีดำ](legend-formatting-before.png) | ![แผนภูมิเดียวกันที่มีคำอธิบายสีกรมท่าสีขาวหนาและคำบรรยายที่ตรงกัน](legend-formatting.png) |

## **ตั้งค่ารูปแบบตัวเลข**

ใช้[ChartDataCell::setPresetNumberFormat](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatacell/#setPresetNumberFormat)เพื่อใช้รูปแบบตัวเลขที่ฝังในเซลล์งานของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลค่าตั้งต้นที่รับจากเซลล์และตั้งค่ารหัสรูปแบบ 10 (`0.00%`) ให้กับเซลค่าของแต่ละชุด ค่าจะถูกแสดงในเวิร์กบุ๊กโดยไม่เปลี่ยนแปลงตัวเลขเดิม; ตัวอย่างเช่น 0.25 จะถูกแสดงเป็น 25.00% รูปแบบแกนและป้ายข้อมูลสามารถกำหนดแยกต่างหากได้

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 400);
    $series = $chart->getChartData()->getSeries();

    for ($i = 0; $i < java_values($series->size()); $i++) {
        $chartSeries = $series->get_Item($i);
        $dataPoints = $chartSeries->getDataPoints();
        for ($j = 0; $j < java_values($dataPoints->size()); $j++) {
            $dataPoint = $dataPoints->get_Item($j);
            $dataPoint->getValue()->getAsCell()->setPresetNumberFormat(10); // 0.00%
        }
    }

    $presentation->save("PresetNumberFormat_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่ฝังไว้พร้อมรูปแบบ Excel ตัวอย่างสำหรับภาษาอังกฤษ (สหรัฐอเมริกา) สตริงรูปแบบที่แท้จริงและการแสดงผลอาจแตกต่างตามแอปพลิเคชันและภาษา โดยเฉพาะสำหรับสกุลเงินและวันที่ รูปแบบ Excel บางรายการยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายไว้ใน[Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)

| ดัชนี | รูปแบบ |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **ตั้งค่าขอบโค้งมนของพื้นที่แผนภูมิ**

เรียก[Chart::setRoundedCorners](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#setRoundedCorners)ด้วย `true` เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นโค้ง ตัวอย่างสร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้[getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat)เพื่อกำหนดเส้นขอบเป็นสีเทาแบบทึบและสไตล์เส้นเดียวก่อนบันทึกงานนำเสนอ

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 20, 100, 600, 400);
    $chart->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $chart->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $chart->getLineFormat()->setStyle(LineStyle::Single);
    $chart->setRoundedCorners(true);

    $presentation->save("out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **แก้ไขคำอธิบายแผนภูมิที่มีอยู่**

แผนภูมิสามารถมีรูปร่างแบบกำหนดเองได้ เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน เข้าถึงรูปร่างเหล่านี้ผ่าน[Chart::getUserShapes](https://reference.aspose.com/slides/php-java/aspose.slides/chart/#getUserShapes) คอลเลกชันที่ได้จาก[getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes)ประกอบด้วยรูปร่างที่เป็นของแผนภูมิ

กล่องข้อความธรรมดาที่วางเหนือแผนภูมิเป็นของสไลด์ แม้ว่าจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ การวนลูปผ่าน[Slide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/slide/)จะพบแผนภูมิและรูปร่างสไลด์ปกติ แต่จะไม่แสดงรูปร่างที่อยู่ภายในแผนภูมิ คำอธิบายแผนภูมิและป้ายข้อมูลเป็นส่วนแยกของแผนภูมิ ไม่ใช่คำอธิบายแบบกำหนดเองในคอลเลกชันนี้

ดาวน์โหลด[chart-annotations.pptx](chart-annotations.pptx)และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีแผนภูมิพร้อมคำอธิบายที่ไม่ได้รวมกลุ่มโดยอ่านว่า "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาที่อ่านว่า "Slide overlay" ตัวอย่างค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น "Final results" เมื่อต้องการเผยแพร่รายงาน ตรวจสอบว่าคอลเลกชันว่างหรือไม่และแก้ไขเฉพาะ[AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/)ที่มีกรอบข้อความไม่เป็นค่า null จาก[getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#getTextFrame)และข้อความที่คาดหวัง

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("chart-annotations.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chartType = new JavaClass("com.aspose.slides.IChart");
    $autoShapeType = new JavaClass("com.aspose.slides.IAutoShape");
    $chart = null;
    for ($i = 0; $i < java_values($slide->getShapes()->size()); $i++) {
        $shape = $slide->getShapes()->get_Item($i);
        if (java_instanceof($shape, $chartType)) {
            $chart = $shape;
            break;
        }
    }

    if ($chart === null || java_values($chart->getUserShapes()->getShapes()->size()) == 0) {
        echo "No chart or chart-owned shapes found." . PHP_EOL;
        return;
    }

    $updated = false;
    $userShapes = $chart->getUserShapes()->getShapes();
    for ($i = 0; $i < java_values($userShapes->size()); $i++) {
        $shape = $userShapes->get_Item($i);
        if (java_instanceof($shape, $autoShapeType)) {
            $annotation = $shape;
            if (!java_is_null($annotation->getTextFrame()) && java_values($annotation->getTextFrame()->getText()) === "Preliminary results") {
                $annotation->getTextFrame()->setText("Final results");
                $updated = true;
                break;
            }
        }
    }

    if ($updated) {
        $presentation->save("chart-annotations-updated.pptx", SaveFormat::Pptx);
    } else {
        echo "No matching text annotation found." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

เส้นและกล่องข้อความสไลด์ยังคงไม่เปลี่ยนแปลง รูปภาพต่อไปนี้แสดงอินพุตและผลลัพธ์ที่บันทึกแล้วและเปิดใหม่อีกครั้ง:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![คำอธิบายแผนภูมิแสดงข้อความ Preliminary results](chart-annotations-before.png) | ![คำอธิบายแผนภูมิแสดงข้อความ Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปร่างระดับบนสุดที่เป็นของแผนภูมิ หากคำอธิบายอยู่ภายใน[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/), ให้ตรวจสอบคอลเลกชัน[getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes)ของกลุ่มนั้นด้วย แล้วทำซ้ำแบบเรียกซ้ำสำหรับกลุ่มซ้อนกัน, ใช้การตรวจสอบข้อความเดียวกันกับรูปร่างลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าปฏิบัติกลุ่มเป็นกล่องข้อความ
{{% /alert %}}

## **FAQ**

**ฉันสามารถตั้งค่าสีเติมครึ่งโปร่งแสงสำหรับคอลัมน์/พื้นที่ในขณะที่คงเส้นขอบให้ทึบได้หรือไม่?**  
ได้ การโปร่งใสของการเติมและเส้นขอบถูกกำหนดแยกกัน ซึ่งเป็นประโยชน์ในการทำให้กริดและข้อมูลอ่านง่ายขึ้นในภาพที่มีความหนาแน่นสูง

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับกันอย่างไร?**  
ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น ประเภท), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือเปลี่ยนรูปแบบเป็น "ค่า + คำอธิบาย"

**ฉันสามารถใช้การเติมแบบไล่โทนสีหรือรูปแบบบนชุดข้อมูลได้หรือไม่?**  
ได้ ชุดข้อมูลรองรับการเติมแบบทึบ, ไล่โทนสี, และรูปแบบ ในการใช้งานจริงควรใช้ไล่โทนสีอย่างระมัดระวังและหลีกเลี่ยงการผสมที่ทำให้ความคมชัดของกริดและข้อความลดลง