---
title: ปรับแต่ง Legend ของแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: Legend แผนภูมิ
type: docs
url: /th/php-java/chart-legend/
keywords:
- legend แผนภูมิ
- ตำแหน่ง legend
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "ปรับแต่ง legend ของแผนภูมิด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบ legend ที่กำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides สำหรับ PHP ผ่าน Java มีตัวเลือกสำหรับการปรับแต่ง legend ของแผนภูมิในงานนำเสนอ PowerPoint. บทความนี้แสดงวิธีการกำหนดตำแหน่งและขนาดของ legend, ตั้งค่าขนาดฟอนต์สำหรับ legend ทั้งหมด, จัดรูปแบบรายการ legend รายการเดียว, และซ่อนหรือกู้คืนรายการที่เลือก.

FAQ ครอบคลุมพฤติกรรมที่เกี่ยวข้อง รวมถึงการจองพื้นที่สำหรับ legend, การแสดงป้ายกำกับหลายบรรทัด, และการสืบทอดการจัดรูปแบบจากธีมของการนำเสนอ.

## **การจัดตำแหน่ง Legend**

ใช้เมธอด [setX](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/php-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setwidth/), และ [setHeight](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setheight/) ของ legend เพื่อกำหนดตำแหน่งและขนาดเป็นส่วนของมิติของแผนภูมิ.

ตัวอย่างนี้สร้างงานนำเสนอและเพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้นลงในสไลด์แรก. การแบ่งค่า offset และขนาดของ legend ที่ต้องการด้วยความกว้างและความสูงของแผนภูมิจะทำให้ได้ค่าเชิงสัมพัทธ์: legend ถูกย้ายตำแหน่ง 50 จุดจากมุมบน‑ซ้ายของแผนภูมิและมีขนาด 100 × 100 จุด. ตัวอย่างนี้ใช้ java_values เพื่อแปลงมิติของแผนภูมิที่ PHP/Java Bridge ส่งคืนเป็นตัวเลข PHP ก่อนทำการหาร.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

    $chartWidth = java_values($chart->getWidth());
    $chartHeight = java_values($chart->getHeight());

    // ระบุตำแหน่งและขนาดของ legend ที่สัมพันธ์กับแผนภูมิ.
    $chart->getLegend()->setX(50 / $chartWidth);
    $chart->getLegend()->setY(50 / $chartHeight);
    $chart->getLegend()->setWidth(100 / $chartWidth);
    $chart->getLegend()->setHeight(100 / $chartHeight);

    $presentation->save("legend_position.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของ Legend**

ใช้ [getTextFormat](https://reference.aspose.com/slides/php-java/aspose.slides/legend/gettextformat/) ของ legend เพื่อเข้าถึงการจัดรูปแบบข้อความและใช้ [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) เพื่อตั้งค่าขนาดฟอนต์เป็นจุด.

ตัวอย่างนี้สร้างแผนภูมิพร้อมข้อมูลเริ่มต้นและตั้งค่าข้อความ legend เป็น 20 จุด. นอกจากนี้ยังปิดการกำหนดขอบอัตโนมัติสำหรับแกนแนวตั้งและตั้งค่าช่วงเป็น -5 ถึง 10.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);

    $presentation->save("legend_font_size.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ตั้งค่าขนาดฟอนต์ของรายการ Legend รายการเดียว**

ใช้คอลเลกชันที่คืนค่าจากเมธอด [getEntries](https://reference.aspose.com/slides/php-java/aspose.slides/legend/getentries/) ของ legend เพื่อเข้าถึงการจัดรูปแบบของรายการเฉพาะ. ดัชนีของรายการเริ่มจากศูนย์ ดังนั้นดัชนี `1` หมายถึงรายการที่สอง.

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่ข้อมูลเริ่มต้นมีอย่างน้อยสอง series. มันจัดรูปแบบรายการ legend ที่สองด้วยตัวหนา, ตัวเอียง, และข้อความสีน้ำเงินขนาด 20 จุด.

```php
use aspose\slides\ChartType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $textFormat = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();

    $textFormat->getPortionFormat()->setFontBold(NullableBool::True);
    $textFormat->getPortionFormat()->setFontHeight(20);
    $textFormat->getPortionFormat()->setFontItalic(NullableBool::True);
    $textFormat->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $textFormat->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("legend_entry_format.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ซ่อนรายการ Legend รายการเดียว**

เพื่อไม่แสดง series เสริมใน legend ในขณะที่ข้อมูลของมันยังมองเห็นได้ ให้เรียก [LegendEntryProperties::setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) ด้วยค่า `true` ผ่าน [ChartSeries::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartseries/getrelatedlegendentry/). วิธีนี้จะซ่อนเฉพาะรายการ legend ที่เลือก; ไม่ได้ลบ series หรือจุดข้อมูลของมัน. การเรียก [Chart::setLegend](https://reference.aspose.com/slides/php-java/aspose.slides/chart/setlegend/) ด้วยค่า `false` ในทางตรงข้ามจะซ่อน legend ทั้งหมด.

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีหลาย series โดยใช้ข้อมูลเริ่มต้น. มันซ่อนรายการ legend ของ series ที่สอง (ดัชนี `1`) และบันทึกงานนำเสนอ. จากนั้นกู้คืนรายการโดยเรียก [setHide](https://reference.aspose.com/slides/php-java/aspose.slides/legendentryproperties/sethide/) ด้วยค่า `false` และบันทึกสำเนาที่สอง. คอลัมน์ยังคงมองเห็นได้ในทั้งสองไฟล์.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setLegend(true);

    $legendEntry = $chart->getChartData()->getSeries()->get_Item(1)->getRelatedLegendEntry();

    $legendEntry->setHide(true);
    $presentation->save("hidden_legend_entry.pptx", SaveFormat::Pptx);

    // คืนค่ารายการเดียวกันโดยไม่เปลี่ยนข้อมูลแผนภูมิ.
    $legendEntry->setHide(false);
    $presentation->save("restored_legend_entry.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

การเปรียบเทียบด้านล่างแสดงแผนภูมิเดียวกันที่มีทุกรายการที่มองเห็นและรายการที่สองที่ซ่อนอยู่. คอลัมน์ของ series ที่สองยังคงไม่เปลี่ยนแปลง.

![การเปรียบเทียบแผนภูมิที่มีรายการ legend ทั้งหมดมองเห็นและ Series 2 ถูกซ่อนจาก legend; คอลัมน์ทั้งหมดยังคงมองเห็นได้.](hide-legend-entry.png)

ในแผนภูมิคอลัมน์, แถบ, และเส้น, รายการ legend ระบุ series. สำหรับแผนภูมิวัตถุกรอบ, รายการเหล่านี้ระบุจุดข้อมูล (ส่วน) แต่ละส่วน, ดังนั้นใช้ [ChartDataPoint::getRelatedLegendEntry](https://reference.aspose.com/slides/php-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) กับส่วนที่เลือกแทน. API เอกสารเมธอดจุดข้อมูลนี้สำหรับประเภทแผนภูมิ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, และ `BarOfPie`. อย่าสันนิษฐานว่ามันใช้กับแผนภูมิดองนัท, ซึ่งไม่ได้รวมอยู่ในรายการนั้น.

## **FAQ**

**ฉันสามารถทำให้แผนภูมิจัดสรรพื้นที่สำหรับ legend แทนการซ้อนทับได้หรือไม่?**  
ใช่. เรียก [setOverlay](https://reference.aspose.com/slides/php-java/aspose.slides/legend/setoverlay/) ด้วยค่า `false` เพื่อจองพื้นที่สำหรับ legend แทนการให้มันซ้อนทับพื้นที่พล็อต.

**ฉันสามารถทำให้ป้าย legend มีหลายบรรทัดได้หรือไม่?**  
ใช่. ป้ายกำกับที่ยาวสามารถตัดบรรทัดเมื่อความกว้างที่ใช้ได้ไม่เพียงพอ. คุณยังสามารถใช้ตัวอักขระขึ้นบรรทัดใหม่ในชื่อ series เพื่อขอให้มีการตัดบรรทัด.

**ฉันจะทำให้ legend ปรับตามโทนสีของธีมการนำเสนออย่างไร?**  
ปล่อยให้สี, การเติม, และฟอนต์ของ legend ไม่ถูกกำหนดเพื่อให้สามารถสืบทอดการจัดรูปแบบจากธีมได้. การกำหนดรูปแบบโดยตรงจะเขียนทับการตั้งค่าธีมที่สอดคล้อง.