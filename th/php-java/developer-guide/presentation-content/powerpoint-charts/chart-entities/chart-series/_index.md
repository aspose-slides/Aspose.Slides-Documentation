---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย PHP
linktitle: ชุดข้อมูล
type: docs
url: /th/php-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีชุดข้อมูล
- สีประเภท
- ชื่อชุดข้อมูล
- จุดข้อมูล
- ช่องว่างของชุดข้อมูล
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิใน PHP สำหรับ PowerPoint (PPT/PPTX) พร้อมตัวอย่างโค้ดที่ใช้งานได้จริงและแนวทางปฏิบัติที่ดีที่สุดเพื่อยกระดับการนำเสนอข้อมูลของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายบทบาทของ [ChartSeries](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/) ใน Aspose.Slides โดยมุ่งเน้นที่วิธีการจัดโครงสร้างและการแสดงผลข้อมูลภายในงานนำเสนอ วัตถุเหล่านี้ให้ส่วนประกอบพื้นฐานที่กำหนดชุดข้อมูลจุด, ประเภท, และพารามิเตอร์การแสดงผลในแผนภูมิ โดยการทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/) นักพัฒนาสามารถผสานแหล่งข้อมูลพื้นฐานได้อย่างราบรื่นและควบคุมการแสดงผลข้อมูลอย่างเต็มที่ ทำให้ได้งานนำเสนอที่ขับเคลื่อนด้วยข้อมูลแบบไดนามิกซึ่งสื่อสารข้อมูลเชิงลึกและการวิเคราะห์ได้อย่างชัดเจน  

ชุดข้อมูลคือแถวหรือคอลัมน์ของตัวเลขที่ถูกวาดลงบนแผนภูมิ  

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

ด้วยเมธอด [getParentSeriesGroup](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartseries/#getParentSeriesGroup) คุณสามารถระบุว่าคอลัมน์และแถบควรทับซ้อนกันเท่าไหร่ในแผนภูมิ 2 มิติ (ช่วง: -100 ถึง 100) คุณสมบัตินี้ใช้กับชุดข้อมูลทั้งหมดของกลุ่มชุดข้อมูลหลัก: เป็นการสืบทอดคุณสมบัติของกลุ่มที่เหมาะสม ดังนั้นคุณสมบัตินี้เป็นแบบอ่านอย่างเดียว  

ใช้เมธอด `ChartSeriesGroup::setOverlap` เพื่อกำหนดค่าที่คุณต้องการสำหรับ `Overlap`  

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. เพิ่มแผนภูมิคอลัมน์แบบคลัสเตอร์บนสไลด์  
1. เข้าถึงชุดข้อมูลแผนภูมิแรก  
1. เข้าถึง `ParentSeriesGroup` ของชุดข้อมูลแผนภูมิและกำหนดค่าการทับซ้อนที่ต้องการสำหรับชุดข้อมูลนั้น  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีตั้งค่าการทับซ้อนสำหรับชุดข้อมูลแผนภูมิ:

```php
  $pres = new Presentation();
  try {
    # เพิ่มแผนภูมิ
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # ตั้งค่าการทับซ้อนของชุดข้อมูล
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # เขียนไฟล์งานนำเสนอลงดิสก์
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนสีชุดข้อมูล**

Aspose.Slides for PHP via Java ให้คุณเปลี่ยนสีของชุดข้อมูลได้ดังนี้  

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. เพิ่มแผนภูมิบนสไลด์  
1. เข้าถึงชุดข้อมูลที่ต้องการเปลี่ยนสี  
1. กำหนดประเภทการเติมและสีที่ต้องการ  
1. บันทึกงานนำเสนอที่แก้ไข  

โค้ด PHP นี้แสดงวิธีเปลี่ยนสีของชุดข้อมูล:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนสีประเภทของชุดข้อมูล**

Aspose.Slides for PHP via Java ให้คุณเปลี่ยนสีของประเภทในชุดข้อมูลได้ดังนี้  

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. เพิ่มแผนภูมิบนสไลด์  
1. เข้าถึงประเภทของชุดข้อมูลที่ต้องการเปลี่ยนสี  
1. กำหนดประเภทการเติมและสีที่ต้องการ  
1. บันทึกงานนำเสนอที่แก้ไข  

โค้ดนี้แสดงวิธีเปลี่ยนสีของประเภทในชุดข้อมูล:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **เปลี่ยนชื่อชุดข้อมูล** 

โดยค่าเริ่มต้น ชื่อในเลเจนด์ของแผนภูมิมาจากเนื้อหาในเซลล์เหนือแต่ละคอลัมน์หรือแถวของข้อมูล  

ในตัวอย่างของเรา (รูปตัวอย่าง)  

* คอลัมน์คือ *Series 1, Series 2,* และ *Series 3*;  
* แถวคือ *Category 1, Category 2, Category 3,* และ *Category 4.*  

Aspose.Slides for PHP via Java ให้คุณอัปเดตหรือเปลี่ยนชื่อชุดข้อมูลในข้อมูลแผนภูมิและเลเจนด์ได้  

โค้ด PHP นี้แสดงวิธีเปลี่ยนชื่อชุดข้อมูลในข้อมูลแผนภูมิ `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

โค้ด PHP นี้แสดงวิธีเปลี่ยนชื่อชุดข้อมูลในเลเจนด์ผ่าน `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าสีเติมอัตโนมัติสำหรับชุดข้อมูลแผนภูมิ**

Aspose.Slides for PHP via Java ให้คุณตั้งค่าสีเติมอัตโนมัติสำหรับชุดข้อมูลแผนภูมิภายในพื้นที่แผนภูมิได้ดังนี้  

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. รับอ้างอิงสไลด์ตามดัชนีที่ต้องการ  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างนี้เราใช้ `ChartType::ClusteredColumn`)  
1. เข้าถึงชุดข้อมูลแผนภูมิและตั้งค่าสีเติมเป็น Automatic  
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีตั้งค่าสีเติมอัตโนมัติสำหรับชุดข้อมูลแผนภูมิ:

```php
  $pres = new Presentation();
  try {
    # สร้างแผนภูมิคอลัมน์แบบคลัสเตอร์
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # ตั้งค่ารูปแบบการเติมสีของชุดข้อมูลเป็นอัตโนมัติ
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # เขียนไฟล์งานนำเสนอลงดิสก์
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดข้อมูลแผนภูมิ**

Aspose.Slides ให้คุณตั้งค่าสีเติมกลับด้านสำหรับชุดข้อมูลแผนภูมิภายในพื้นที่แผนภูมิได้ดังนี้  

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. รับอ้างอิงสไลด์ตามดัชนีที่ต้องการ  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างนี้เราใช้ `ChartType::ClusteredColumn`)  
1. เข้าถึงชุดข้อมูลแผนภูมิและตั้งค่าสีเติมเป็น Invert  
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงการดำเนินการ:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # เพิ่มชุดข้อมูลและหมวดหมู่ใหม่
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # ดึงชุดข้อมูลแผนภูมิแรกและเติมข้อมูลชุดข้อมูล
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าชุดข้อมูลให้กลับด้านเมื่อค่าขณะเป็นลบ**

Aspose.Slides ให้คุณกำหนดการกลับด้านผ่านคุณสมบัติ `IChartDataPoint.InvertIfNegative` และ `ChartDataPoint.InvertIfNegative` เมื่อเปิดใช้งานการกลับด้านด้วยคุณสมบัติเหล่านี้ จุดข้อมูลจะเปลี่ยนสีเมื่อได้รับค่าลบ  

โค้ด PHP นี้แสดงการดำเนินการ:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ลบข้อมูลจุดเฉพาะ**

Aspose.Slides for PHP via Java ให้คุณลบข้อมูล `DataPoints` ของชุดข้อมูลแผนภูมิเฉพาะได้ดังนี้  

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ตามดัชนีที่ต้องการ  
3. รับอ้างอิงแผนภูมิตามดัชนีที่ต้องการ  
4. วนลูปผ่าน `DataPoints` ทั้งหมดของแผนภูมิและกำหนด `XValue` และ `YValue` เป็น null  
5. ลบ `DataPoints` ทั้งหมดจากชุดข้อมูลแผนภูมิที่ระบุ  
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงการดำเนินการ:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

Aspose.Slides for PHP via Java ให้คุณตั้งค่า **`GapWidth`** ของชุดข้อมูลได้ดังนี้  

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. เข้าถึงสไลด์แรก  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น  
1. เข้าถึงชุดข้อมูลใด ๆ ของแผนภูมิ  
1. กำหนดคุณสมบัติ `GapWidth`  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX  

โค้ดนี้แสดงวิธีตั้งค่าความกว้างช่องว่างของชุดข้อมูล:

```php
  # สร้างงานนำเสนอเปล่า
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรกของงานนำเสนอ
    $slide = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมพร้อมข้อมูลเริ่มต้น
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # เพิ่มชุดข้อมูล
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # เพิ่มหมวดหมู่
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # ดึงชุดข้อมูลแผนภูมิที่สอง
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # เติมข้อมูลชุดข้อมูล
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # ตั้งค่าค่าความกว้างช่องว่าง
    $series->getParentSeriesGroup()->setGapWidth(50);
    # บันทึกงานนำเสนอลงดิสก์
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **คำถามที่พบบ่อย**

**มีขีดจำกัดจำนวนชุดข้อมูลที่แผนภูมิเดียวสามารถบรรจุได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดคงที่สำหรับจำนวนชุดข้อมูลที่คุณเพิ่ม ขีดจำกัดเชิงปฏิบัติจะแปรตามความสามารถในการอ่านของแผนภูมิและหน่วยความจำที่แอปพลิเคชันของคุณมี  

**ถ้าคอลัมน์ในคลัสเตอร์ห่างกันมากหรือใกล้กันเกินไปจะทำอย่างไร?**

ปรับค่า `GapWidth` สำหรับชุดข้อมูลนั้น (หรือกลุ่มชุดข้อมูลหลักของมัน) การเพิ่มค่าจะเพิ่มระยะห่างระหว่างคอลัมน์ ส่วนการลดค่าจะทำให้คอลัมน์ใกล้กันมากขึ้น  