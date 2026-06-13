---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอโดยใช้ PHP
linktitle: ป้ายข้อมูล
type: docs
url: /th/php-java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งป้าย
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพื่อให้สไลด์น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลบนแผนภูมิแสดงรายละเอียดเกี่ยวกับซีรีส์ข้อมูลของแผนภูมิหรือจุดข้อมูลแต่ละจุด พวกมันช่วยให้ผู้อ่านระบุซีรีส์ข้อมูลได้อย่างรวดเร็วและทำให้แผนภูมิเข้าใจง่ายยิ่งขึ้น

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ**

โค้ด PHP นี้แสดงวิธีตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 50, 50, 450, 300);
    $chart->setDataTable(true);
    $chart->getChartData()->getSeries()->get_Item(0)->setNumberFormatOfValues("#,##0.00");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

Aspose.Slides for PHP via Java ให้คุณตั้งค่าป้ายเปอร์เซ็นต์บนแผนภูมิที่แสดง โค้ด PHP นี้สาธิตการทำงาน:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # ดึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 20, 20, 400, 400);
    $series;
    $total_for_Cat = new double[$chart->getChartData()->getCategories()->size()];
    for($k = 0; $k < java_values($chart->getChartData()->getCategories()->size()) ; $k++) {
      $cat = $chart->getChartData()->getCategories()->get_Item($k);
      for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
        $total_for_Cat[$k] = $total_for_Cat[$k] + $chart->getChartData()->getSeries()->get_Item($i)->getDataPoints()->get_Item($k)->getValue()->getData();
      }
    }
    $dataPontPercent = 0.0;
    for($x = 0; $x < java_values($chart->getChartData()->getSeries()->size()) ; $x++) {
      $series = $chart->getChartData()->getSeries()->get_Item($x);
      $series->getLabels()->getDefaultDataLabelFormat()->setShowLegendKey(false);
      for($j = 0; $j < java_values($series->getDataPoints()->size()) ; $j++) {
        $lbl = $series->getDataPoints()->get_Item($j)->getLabel();
        $dataPontPercent = $series->getDataPoints()->get_Item($j)->getValue()->getData() / $total_for_Cat[$j] * 100;
        $port = new Portion();
        $port->setText(sprintf("{0:F2} %.2f", $dataPontPercent));
        $port->getPortionFormat()->setFontHeight(8.0);
        $lbl->getTextFrameForOverriding()->setText("");
        $para = $lbl->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
        $para->getPortions()->add($port);
        $lbl->getDataLabelFormat()->setShowSeriesName(false);
        $lbl->getDataLabelFormat()->setShowPercentage(false);
        $lbl->getDataLabelFormat()->setShowLegendKey(false);
        $lbl->getDataLabelFormat()->setShowCategoryName(false);
        $lbl->getDataLabelFormat()->setShowBubbleSize(false);
      }
    }
    # บันทึกการนำเสนอที่มีแผนภูมิอยู่
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าสัญลักษณ์เปอร์เซ็นต์ในป้ายข้อมูลแผนภูมิ**

โค้ด PHP นี้แสดงวิธีตั้งค่าสัญลักษณ์เปอร์เซ็นต์สำหรับป้ายข้อมูลแผนภูมิ:

```php
  # สร้างอินสแตนซ์ของคลास Presentation
  $pres = new Presentation();
  try {
    # ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
    $slide = $pres->getSlides()->get_Item(0);
    # สร้างแผนภูมิ PercentsStackedColumn บนสไลด์
    $chart = $slide->getShapes()->addChart(ChartType::PercentsStackedColumn, 20, 20, 500, 400);
    # ตั้งค่า NumberFormatLinkedToSource เป็น false
    $chart->getAxes()->getVerticalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getVerticalAxis()->setNumberFormat("0.00%");
    $chart->getChartData()->getSeries()->clear();
    $defaultWorksheetIndex = 0;
    # ดึงเวิร์กชีตข้อมูลแผนภูมิ
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # เพิ่มซีรีส์ใหม่
    $series = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 1, "Reds"), $chart->getType());
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 1, 0.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 1, 0.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 1, 0.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 1, 0.65));
    # ตั้งค่าสีเติมของซีรีส์
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # ตั้งค่าคุณสมบัติของ LabelFormat
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # เพิ่มซีรีส์ใหม่
    $series2 = $chart->getChartData()->getSeries()->add($workbook->getCell($defaultWorksheetIndex, 0, 2, "Blues"), $chart->getType());
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 1, 2, 0.7));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 2, 2, 0.5));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 3, 2, 0.2));
    $series2->getDataPoints()->addDataPointForBarSeries($workbook->getCell($defaultWorksheetIndex, 4, 2, 0.35));
    # ตั้งค่าประเภทการเติมและสี
    $series2->getFormat()->getFill()->setFillType(FillType::Solid);
    $series2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $series2->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormatLinkedToSource(false);
    $series2->getLabels()->getDefaultDataLabelFormat()->setNumberFormat("0.0%");
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->setFontHeight(10);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $series2->getLabels()->getDefaultDataLabelFormat()->getTextFormat()->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("SetDataLabelsPercentageSign_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าระยะห่างของป้ายจากแกน**

โค้ด PHP นี้แสดงวิธีตั้งค่าระยะห่างของป้ายจากแกนประเภทเมื่อคุณทำงานกับแผนภูมิที่วางจากแกน:

```php
  # สร้างอินสแตนซ์ของคลาส Presentation
  $pres = new Presentation();
  try {
    # ดึงอ้างอิงสไลด์
    $sld = $pres->getSlides()->get_Item(0);
    # สร้างแผนภูมิบนสไลด์
    $ch = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
    # ตั้งค่าระยะห่างของป้ายจากแกน
    $ch->getAxes()->getHorizontalAxis()->setLabelOffset(500);
    # บันทึกการนำเสนอลงดิสก์
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ปรับตำแหน่งป้าย**

เมื่อคุณสร้างแผนภูมิที่ไม่ใช้แกนใด ๆ เช่น แผนภูมิวงกลม ป้ายข้อมูลของแผนภูมิอาจอยู่ใกล้ขอบเกินไป ในกรณีเช่นนี้คุณต้องปรับตำแหน่งของป้ายข้อมูลเพื่อให้เส้นเชื่อมแสดงอย่างชัดเจน

โค้ด PHP นี้แสดงวิธีปรับตำแหน่งป้ายบนแผนภูมิวงกลม:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 200, 200);
    $series = $chart->getChartData()->getSeries();
    $label = $series->get_Item(0)->getLabels()->get_Item(0);
    $label->getDataLabelFormat()->setShowValue(true);
    $label->getDataLabelFormat()->setPosition(LegendDataLabelPosition->OutsideEnd);
    $label->setX(0.71);
    $label->setY(0.04);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนบนแผนภูมิที่หนาแน่นได้อย่างไร?**

ผสานการวางป้ายอัตโนมัติ, เส้นเชื่อม, และการลดขนาดฟอนต์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะจุดสุดขีด/สำคัญเท่านั้น

**ฉันจะปิดใช้งานป้ายเฉพาะสำหรับค่าที่เป็นศูนย์, ลบ, หรือว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าลบ, หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

กำหนดฟอนต์ (ตระกูล, ขนาด) อย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีอยู่บนฝั่งการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง