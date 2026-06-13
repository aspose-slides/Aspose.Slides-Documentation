---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย PHP
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

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิใน Aspose.Slides โดยจะแสดงวิธีการรับค่าจริงของแกน, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทของแกนหมวดหมู่, ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่, หมุนชื่อแกน, ตั้งตำแหน่งแกน, และแสดงป้ายหน่วยบนแกนค่าที่.

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

Aspose.Slides for PHP via Java ช่วยให้คุณสามารถรับค่าต่ำสุดและค่าสูงสุดบนแกนแนวตั้งได้ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. เข้าถึงสไลด์แรก.  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น.  
4. รับค่ามากสุดจริงบนแกน.  
5. รับค่าน้อยสุดจริงบนแกน.  
6. รับหน่วยหลักจริงของแกน.  
7. รับหน่วยย่อยจริงของแกน.  
8. รับสเกลหน่วยหลักจริงของแกน.  
9. รับสเกลหน่วยย่อยจริงของแกน.  

ตัวอย่างโค้ดนี้—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีรับค่าที่ต้องการ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 100, 100, 500, 350);
    $chart->validateChartLayout();
    $maxValue = $chart->getAxes()->getVerticalAxis()->getActualMaxValue();
    $minValue = $chart->getAxes()->getVerticalAxis()->getActualMinValue();
    $majorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMajorUnit();
    $minorUnit = $chart->getAxes()->getHorizontalAxis()->getActualMinorUnit();
    # บันทึกงานนำเสนอ
    $pres->save("MaxValuesVerticalAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **สลับข้อมูลระหว่างแกน**

Aspose.Slides ช่วยให้คุณสลับข้อมูลระหว่างแกนได้อย่างรวดเร็ว—ข้อมูลที่แสดงบนแกนแนวตั้ง (y-axis) จะย้ายไปยังแกนแนวนอน (x-axis) และในทางกลับกัน.

โค้ด PHP นี้แสดงวิธีการดำเนินการสลับข้อมูลระหว่างแกนบนแผนภูมิ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    # สลับแถวและคอลัมน์
    $chart->getChartData()->switchRowColumn();
    # บันทึกงานนำเสนอ
    $pres->save("SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

โค้ด PHP นี้แสดงวิธีการซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getVerticalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

โค้ดนี้แสดงวิธีการซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 100, 100, 400, 300);
    $chart->getAxes()->getHorizontalAxis()->setVisible(false);
    $pres->save("chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนแกนหมวดหมู่**

โดยใช้คุณสมบัติ **CategoryAxisType** คุณสามารถระบุประเภทของแกนหมวดหมู่ที่ต้องการ (**date** หรือ **text**) โค้ดนี้แสดงการทำงาน:

```php
  $presentation = new Presentation("ExistingChart.pptx");
  try {
    $chart = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setAutomaticMajorUnit(false);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnit(1);
    $chart->getAxes()->getHorizontalAxis()->setMajorUnitScale(TimeUnitType::Months);
    $presentation->save("ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

Aspose.Slides for PHP via Java ช่วยให้คุณตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่ การดำเนินการนี้แสดงในโค้ด PHP นี้:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Area, 50, 50, 450, 300);
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", convertToOADate(new GregorianCalendar(2015, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", convertToOADate(new GregorianCalendar(2016, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", convertToOADate(new GregorianCalendar(2017, 1, 1))));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", convertToOADate(new GregorianCalendar(2018, 1, 1))));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Line);
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B2", 1));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B3", 2));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B4", 3));
    $series->getDataPoints()->addDataPointForLineSeries($wb->getCell(0, "B5", 4));
    $chart->getAxes()->getHorizontalAxis()->setCategoryAxisType(CategoryAxisType::Date);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormatLinkedToSource(false);
    $chart->getAxes()->getHorizontalAxis()->setNumberFormat("yyyy");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนของแผนภูมิ**

Aspose.Slides for PHP via Java ช่วยให้คุณตั้งค่ามุมการหมุนสำหรับชื่อแกนของแผนภูมิ โค้ด PHP นี้แสดงการดำเนินการ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setTitle(true);
    $chart->getAxes()->getVerticalAxis()->getTitle()->getTextFormat()->getTextBlockFormat()->setRotationAngle(90);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าตำแหน่งแกนบนแกนหมวดหมู่หรือแกนค่า**

Aspose.Slides for PHP via Java ช่วยให้คุณตั้งค่าตำแหน่งของแกนในแกนหมวดหมู่หรือแกนค่า โค้ด PHP นี้แสดงวิธีการทำงาน:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getHorizontalAxis()->setAxisBetweenCategories(true);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปิดการแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ**

Aspose.Slides for PHP via Java ช่วยให้คุณกำหนดค่าแผนภูมิเพื่อแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ โค้ด PHP นี้แสดงการดำเนินการ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
    $chart->getAxes()->getVerticalAxis()->setDisplayUnit(DisplayUnitType::Millions);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าที่ที่แกนหนึ่งข้ามอีกแกน (การข้ามแกน) อย่างไร?**

แกนมีการตั้งค่า [crossing setting](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/setcrosstype/): คุณสามารถเลือกให้ข้ามที่ศูนย์, ที่ค่าหมวดหมู่/ค่าสูงสุด, หรือที่ค่าตัวเลขเฉพาะ นี่มีประโยชน์สำหรับการเลื่อนแกน X ขึ้นหรือลงหรือเพื่อเน้นเส้นฐาน.

**ฉันสามารถตั้งตำแหน่งป้ายลำดับ (tick labels) ที่สัมพันธ์กับแกน (ข้างเคียง, ภายนอก, ภายใน) อย่างไร?**

ตั้งค่า [label position](https://reference.aspose.com/slides/th/php-java/aspose.slides/axis/setmajortickmark/) เป็น "cross", "outside" หรือ "inside" ค่าต่าง ๆ นี้ส่งผลต่อการอ่านและช่วยประหยัดพื้นที่, โดยเฉพาะอย่างยิ่งในแผนภูมิขนาดเล็ก.