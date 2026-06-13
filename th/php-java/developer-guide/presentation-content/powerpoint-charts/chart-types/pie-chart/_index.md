---
title: ปรับแต่งแผนภูมิวงกลมในงานนำเสนอด้วย PHP
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
- สีสไลซ์
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิวงกลมด้วย Aspose.Slides สำหรับ PHP ผ่าน Java ที่สามารถส่งออกเป็น PowerPoint ช่วยให้การเล่าเรื่องข้อมูลของคุณเร็วขึ้นในไม่กี่วินาที"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลมใน Aspose.Slides จะอธิบายวิธีการกำหนดค่าตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie และวิธีเปิดใช้งานการกำหนดสีสไลซ์อัตโนมัติสำหรับแผนภูมิวงกลมมาตรฐาน

ตัวอย่างเน้นขั้นตอนการปรับแต่งแผนภูมิอย่างเป็นรูปธรรม เช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับการตั้งค่าชุดข้อมูลและป้ายชื่อ การแทนที่ข้อมูลแผนภูมิมาตรฐานด้วยหมวดหมู่และค่าแบบกำหนดเอง และการบันทึกการนำเสนอที่อัปเดต

## **ตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for PHP via Java ตอนนี้สนับสนุนตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie หรือ Bar of Pie ในหัวข้อนี้ เราจะแสดงวิธีกำหนดตัวเลือกเหล่านั้นโดยใช้ Aspose.Slides เพื่อกำหนดคุณสมบัติ ทำตามขั้นตอนดังนี้:

1. สร้างอ็อบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
2. เพิ่มแผนภูมิลงในสไลด์
3. กำหนดตัวเลือกพล็อตรองของแผนภูมิ
4. บันทึกการนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าคุณสมบัติต่าง ๆ ของแผนภูมิ Pie of Pie

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # เพิ่มแผนภูมิบนสไลด์
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # ตั้งค่าคุณสมบัติต่าง ๆ
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # เขียนการนำเสนอไปยังดิสก์
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าสีสไลซ์อัตโนมัติของแผนภูมิวงกลม**

Aspose.Slides for PHP via Java มี API ง่ายสำหรับการตั้งค่าสีสไลซ์อัตโนมัติของแผนภูมิวงกลม ตัวอย่างโค้ดนี้ใช้การตั้งค่าที่กล่าวถึงข้างต้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
4. ตั้งชื่อแผนภูมิ
5. ตั้งค่าชุดข้อมูลแรกให้แสดงค่า
6. ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
7. ดึงแผ่นงานข้อมูลแผนภูมิ
8. ลบชุดข้อมูลและหมวดหมู่ที่สร้างโดยอัตโนมัติ
9. เพิ่มหมวดหมู่ใหม่
10. เพิ่มชุดข้อมูลใหม่

บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # ตั้งค่าชื่อแผนภูมิ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # ตั้งค่าชุดข้อมูลแรกให้แสดงค่า
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบชุดข้อมูลและหมวดหมู่ที่สร้างโดยอัตโนมัติ
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # เพิ่มหมวดหมู่ใหม่
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # เพิ่มชุดข้อมูลใหม่
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # กำลังเติมข้อมูลให้ชุดข้อมูล
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**รูปแบบ 'Pie of Pie' และ 'Bar of Pie' รองรับหรือไม่?**

ใช่ ไลบรารีนี้ [สนับสนุน](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) พล็อตรองสำหรับแผนภูมิวงกลม รวมถึงประเภท 'Pie of Pie' และ 'Bar of Pie'

**ฉันสามารถส่งออกแค่แผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ใช่ คุณสามารถ [ส่งออกแผนภูมิเสียเองเป็นภาพ](https://reference.aspose.com/slides/th/php-java/aspose.slides/shape/#getImage) (เช่น PNG) ได้โดยไม่ต้องรวมการนำเสนอทั้งหมด