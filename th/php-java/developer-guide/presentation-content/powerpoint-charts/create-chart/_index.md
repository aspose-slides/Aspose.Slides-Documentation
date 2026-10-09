---
title: สร้างหรืออัปเดตแผนภูมิในงานนำเสนอ PowerPoint ด้วย PHP
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
- แผนภูมิ Tree Map
- แผนภูมิหุ้น
- แผนภูมิ Box and Whisker
- แผนภูมิ Funnel
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ PHP ผ่าน Java เพิ่ม แก้ไข และจัดรูปแบบแผนภูมิโดยใช้ตัวอย่างโค้ดเชิงปฏิบัติ"
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม, ใส่ข้อมูลลงไป, และใช้ตัวเลือกรูปแบบต่าง ๆ เพื่อให้ตรงกับข้อกำหนดการออกแบบของคุณ ตลอดทั้งบทความ ตัวอย่างโค้ดที่ละเอียดจะแสดงแต่ละขั้นตอนตั้งแต่การเริ่มต้น Presentation และอ็อบเจกต์แผนภูมิ ไปจนถึงการตั้งค่าซีรีส์, แกน, และคำอธิบาย ด้วยการทำตามคำแนะนำนี้ คุณจะได้ความเข้าใจที่มั่นคงเกี่ยวกับการผสานการสร้างแผนภูมิแบบไดนามิกเข้ากับแอปพลิเคชันของคุณ ทำให้กระบวนการสร้างการนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้คนมองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อมูลเชิงลึกที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากลงในสไลด์เดียวของการนำเสนอ
* เปิดเผยรูปแบบและแนวโน้มในข้อมูล
* สรุปทิศทางและแรงผลักดันของข้อมูลตามเวลา หรือเปรียบเทียบกับหน่วยการวัดเฉพาะ
* ตรวจพบค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, ข้อมูลที่ไม่มีความหมาย ฯลฯ
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งให้เทมเพลตสำหรับออกแบบแผนภูมิต่าง ๆ ได้มากมาย โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิเก็บเป็นแบบปกติ (อิงจากประเภทแผนภูมิที่นิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="หมายเหตุ" %}}
เพื่อสร้างแผนภูมิ ให้ใช้คลาส [ChartType](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) ฟิลด์ในคลาสนี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ส่วนนี้อธิบายวิธีการสร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ Aspose.Slides คุณจะได้เรียนรู้การเริ่มต้น Presentation, เพิ่มแผนภูมิ, และปรับแต่งองค์ประกอบต่าง ๆ เช่น ชื่อเรื่อง, ข้อมูล, ซีรีส์, หมวดหมู่, และรูปแบบ ปฏิบัติตามขั้นตอนด้านล่างเพื่อดูว่าแผนภูมิคอลัมน์แบบกลุ่มมาตรฐานถูกสร้างอย่างไร:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทเป็น `ChartType::ClusteredColumn`
4. เพิ่มชื่อเรื่องให้กับแผนภูมิ
5. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ
6. ล้างซีรีส์และหมวดหมู่เริ่มต้นทั้งหมด
7. เพิ่มซีรีส์และหมวดหมู่ใหม่
8. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ
9. กำหนดสีเติมให้กับซีรีส์ของแผนภูมิ
10. เพิ่มป้ายกำกับให้กับซีรีส์ของแผนภูมิ
11. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของคลาส presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # ตั้งค่าชื่อเรื่องของแผนภูมิ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # ตั้งค่าซีรีส์แรกให้แสดงค่
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ตั้งดัชนีสำหรับแผ่นงานข้อมูลของแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลของแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $s = $chart->getChartData()->getSeries()->size();
    $s = $chart->getChartData()->getCategories()->size();
    # เพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # เพิ่มหมวดหมู่ใหม่
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # ดึงซีรีส์แผนภูมิเชิงแรก
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # ตอนนี้เติมข้อมูลให้ซีรีส์
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # ตั้งค่าสีเติมสำหรับซีรีส์
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    # ดึงซีรีส์แผนภูมิที่สอง
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # เติมข้อมูลให้ซีรีส์
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # ตั้งค่าสีเติมสำหรับซีรีส์
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # สร้างป้ายกำกับกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
    # ตั้งค่าป้ายกำกับแรกให้แสดงชื่อหมวดหมู่
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # แสดงค่าให้กับป้ายกำกับที่สาม
    $lbl = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl->getDataLabelFormat()->setShowValue(true);
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    $lbl->getDataLabelFormat()->setSeparator("/");
    # บันทึกการนำเสนอพร้อมแผนภูมิ
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิกระจาย**

แผนภูมิกระจาย (หรือที่เรียกว่ากราฟจุดหรือกราฟ x‑y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิกระจายเมื่อ:

* คุณมีข้อมูลตัวเลขเป็นคู่
* คุณมีตัวแปรสองตัวที่จับคู่กันได้ดี
* คุณต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์กันหรือไม่
* คุณมีตัวแปรอิสระที่มีหลายค่าให้กับตัวแปรตาม

1. ทำตามขั้นตอนใน [สร้างแผนภูมิคอลัมน์แบบกลุ่ม](#create-clustered-column-charts).
2. สำหรับขั้นตอนที่สาม ให้เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิเป็นหนึ่งในตัวเลือกต่อไปนี้:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิกระจาย._
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นโค้ง พร้อมตัวบ่งชี้ข้อมูล._
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นโค้ง แต่ไม่มีตัวบ่งชี้ข้อมูล._
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นตรง พร้อมตัวบ่งชี้ข้อมูล._
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นตรง แต่ไม่มีตัวบ่งชี้ข้อมูล._

```php
  # สร้างอินสแตนซ์ของคลาส presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # สร้างแผนภูมิปริยาย
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # ดึงดัชนีแผ่นงานข้อมูลแผนภูมิดีฟอลท์
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลของแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์ตัวอย่าง
    $chart->getChartData()->getSeries()->clear();
    # เพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # ดึงซีรีส์แผนภูมิเชิงแรก
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # เพิ่มจุดใหม่ (1:3) ให้กับซีรีส์
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # เพิ่มจุดใหม่ (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # เปลี่ยนประเภทของซีรีส์
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Star);
    # ดึงซีรีส์แผนภูมิที่สอง
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # เพิ่มจุดใหม่ (5:2) ที่นั่น
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 5), $fact->getCell($defaultWorksheetIndex, 2, 4, 2));
    # เพิ่มจุดใหม่ (3:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 3), $fact->getCell($defaultWorksheetIndex, 3, 4, 1));
    # เพิ่มจุดใหม่ (2:2)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 4, 3, 2), $fact->getCell($defaultWorksheetIndex, 4, 4, 2));
    # เพิ่มจุดใหม่ (5:1)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 5, 3, 5), $fact->getCell($defaultWorksheetIndex, 5, 4, 1));
    # เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ
    $series->getMarker()->setSize(10);
    $series->getMarker()->setSymbol(MarkerStyleType::Circle);
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิวงกลม**

แผนภูมวงกลมเหมาะที่สุดสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายกำกับเชิงประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม ถ้าข้อมูลของคุณมีหลายส่วนหรือหลายป้ายกำกับ คุณอาจพิจารณาใช้แผนภูมิกลางแทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::Pie](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Pie) 
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ
8. เพิ่มจุดใหม่สำหรับแผนภูมิและกำหนดสีแบบกำหนดเองสำหรับส่วนของแผนภูมวงกลม
9. ตั้งค่าป้ายกำกับสำหรับซีรีส์
10. เปิดใช้เส้นนำสำหรับป้ายกำกับซีรีส์
11. ตั้งค่ามุมการหมุนสำหรับส่วนของแผนภูมวงกลม
12. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  # สร้างอินสแตนซ์ของคลาส presentation ที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slides = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # ตั้งค่าชื่อเรื่องของแผนภูมิ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # ตั้งค่าซีรีส์แรกให้แสดงค่า
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ตั้งค่าดัชนีสำหรับแผ่นงานข้อมูลของแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลของแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # เพิ่มหมวดหมู่ใหม่
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # เพิ่มซีรีส์ใหม่
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # เติมข้อมูลให้ซีรีส์
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    # ไม่ทำงานในเวอร์ชันใหม่
    # เพิ่มจุดใหม่และตั้งค่าสีของส่วน
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # ตั้งค่าขอบของส่วน
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # ตั้งค่าขอบของส่วน
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # ตั้งค่าขอบของส่วน
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # สร้างป้ายกำกับกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
    $lbl1 = $series->getDataPoints()->get_Item(0)->getLabel();
    # lbl.ShowCategoryName = true;
    $lbl1->getDataLabelFormat()->setShowValue(true);
    $lbl2 = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl2->getDataLabelFormat()->setShowValue(true);
    $lbl2->getDataLabelFormat()->setShowLegendKey(true);
    $lbl2->getDataLabelFormat()->setShowPercentage(true);
    $lbl3 = $series->getDataPoints()->get_Item(2)->getLabel();
    $lbl3->getDataLabelFormat()->setShowSeriesName(true);
    $lbl3->getDataLabelFormat()->setShowPercentage(true);
    # แสดงเส้นนำสำหรับแผนภูมิ
    $series->getLabels()->getDefaultDataLabelFormat()->setShowLeaderLines(true);
    # ตั้งค่ามุมการหมุนสำหรับส่วนของแผนภูมิวงกลม
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # บันทึกการนำเสนอพร้อมแผนภูมิ
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือที่เรียกว่ากราฟเส้น) เหมาะสมที่สุดในกรณีที่คุณต้องการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาเปลี่ยนไป โดยใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล, และอื่น ๆ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::Line](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Line) 
1. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/))
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น
1. เพิ่มซีรีส์และหมวดหมู่ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากคุณต้องการให้จุดเชื่อมต่อด้วยเส้นขีด สามารถระบุประเภทเส้นขีดที่ต้องการได้ดังนี้:

```php
  $pres = new Presentation();
  try {
    $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
    $seriesCollection = $lineChart->getChartData()->getSeries();
    foreach ($seriesCollection as $series) {
      $series->getFormat()->getLine()->setDashStyle(LineDashStyle::Dash);
    }
    $pres->save("lineChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิ Tree Map**

แผนภูมิ Tree Map เหมาะที่สุดสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้ทำ贡献ใหญ่ในแต่ละหมวดหมู่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::Treemap](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Treemap) 
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Treemap, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # สาขา 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # สาขา 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Treemap);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForTreemapSeries($wb->getCell(0, "D8", 3));
    $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
    $pres->save("Treemap.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิ Stock**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#OpenHighLowClose) 
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ
8. ระบุรูปแบบเส้นสูง‑ต่ำ
9. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::OpenHighLowClose, 50, 50, 600, 400, false);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 1, 0, "A"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 2, 0, "B"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, 3, 0, "C"));
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 1, "Open"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 2, "High"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 3, "Low"), $chart->getType());
    $chart->getChartData()->getSeries()->add($wb->getCell(0, 0, 4, "Close"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 1, 72));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 1, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 1, 38));
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 2, 172));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 2, 57));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 2, 57));
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 3, 12));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 3, 13));
    $series = $chart->getChartData()->getSeries()->get_Item(3);
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 1, 4, 25));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 2, 4, 38));
    $series->getDataPoints()->addDataPointForStockSeries($wb->getCell(0, 3, 4, 50));
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getUpDownBars()->setUpDownBars(true);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->getHiLowLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $seriesCollection = $chart->getChartData()->getSeries();
    foreach ($seriesCollection as $ser) {
      $ser->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    }
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิ Box and Whisker**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#BoxAndWhisker) 
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::BoxAndWhisker, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 1"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::BoxAndWhisker);
    $series->setQuartileMethod(QuartileMethodType::Exclusive);
    $series->setShowMeanLine(true);
    $series->setShowMeanMarkers(true);
    $series->setShowInnerPoints(true);
    $series->setShowOutlierPoints(true);
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B1", 15));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B2", 41));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B3", 16));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B4", 10));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B5", 23));
    $series->getDataPoints()->addDataPointForBoxAndWhiskerSeries($wb->getCell(0, "B6", 16));
    $pres->save("BoxAndWhisker.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิ Funnel**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::Funnel](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Funnel) 
4. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Funnel, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A1", "Category 1"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A2", "Category 2"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A3", "Category 3"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A4", "Category 4"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A5", "Category 5"));
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "A6", "Category 6"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Funnel);
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B1", 50));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B2", 100));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B3", 200));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B4", 300));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B5", 400));
    $series->getDataPoints()->addDataPointForFunnelSeries($wb->getCell(0, "B6", 500));
    $pres->save("Funnel.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิ Sunburst**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::Sunburst](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Sunburst) 
4. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Sunburst, 50, 50, 500, 400);
    $chart->getChartData()->getCategories()->clear();
    $chart->getChartData()->getSeries()->clear();
    $wb = $chart->getChartData()->getChartDataWorkbook();
    $wb->clear(0);
    # สาขา 1
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C1", "Leaf1"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem1");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch1");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C2", "Leaf2"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C3", "Leaf3"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C4", "Leaf4"));
    # สาขา 2
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C5", "Leaf5"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem3");
    $leaf->getGroupingLevels()->setGroupingItem(2, "Branch2");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C6", "Leaf6"));
    $leaf = $chart->getChartData()->getCategories()->add($wb->getCell(0, "C7", "Leaf7"));
    $leaf->getGroupingLevels()->setGroupingItem(1, "Stem4");
    $chart->getChartData()->getCategories()->add($wb->getCell(0, "C8", "Leaf8"));
    $series = $chart->getChartData()->getSeries()->add(ChartType::Sunburst);
    $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D1", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D2", 5));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D3", 3));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D4", 6));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D5", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D6", 9));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D7", 4));
    $series->getDataPoints()->addDataPointForSunburstSeries($wb->getCell(0, "D8", 3));
    $pres->save("Sunburst.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิ Histogram**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::Histogram](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Histogram) 
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Histogram, 50, 50, 500, 400);
  $chart->getChartData()->getCategories()->clear();
  $chart->getChartData()->getSeries()->clear();
  $wb = $chart->getChartData()->getChartDataWorkbook();
  $wb->clear(0);
  $series = $chart->getChartData()->getSeries()->add(ChartType::Histogram);
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A1", 15));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A2", -41));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A3", 16));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A4", 10));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A5", -23));
  $series->getDataPoints()->addDataPointForHistogramSeries($wb->getCell(0, "A6", 16));
  $chart->getAxes()->getHorizontalAxis()->setAggregationType(AxisAggregationType::Automatic);
```

### **สร้างแผนภูมิ Radar**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ ([ChartType::Radar](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#Radar) ในกรณีนี้)
4. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Radar, 20, 20, 400, 300);
    $pres->save("Radar-chart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิหลายหมวด**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทเป็น [ChartType::ClusteredColumn](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/#ClusteredColumn) 
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ
8. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $ch = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 600, 450);
    $ch->getChartData()->getSeries()->clear();
    $ch->getChartData()->getCategories()->clear();
    $fact = $ch->getChartData()->getChartDataWorkbook();
    $fact->clear(0);
    $defaultWorksheetIndex = 0;
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c2", "A"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group1");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c3", "B"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c4", "C"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group2");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c5", "D"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c6", "E"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group3");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c7", "F"));
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c8", "G"));
    $category->getGroupingLevels()->setGroupingItem(1, "Group4");
    $category = $ch->getChartData()->getCategories()->add($fact->getCell(0, "c9", "H"));
    # เพิ่มซีรีส์
    $series = $ch->getChartData()->getSeries()->add($fact->getCell(0, "D1", "Series 1"), ChartType::ClusteredColumn);
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D2", 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D3", 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D4", 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D5", 40));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D6", 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D7", 60));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D8", 70));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, "D9", 80));
    # บันทึกการนำเสนอพร้อมแผนภูมิ
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิแผนที่**

แผนภูมิแผนที่ช่วยให้คุณมองเห็นข้อมูลภูมิศาสตร์และเปรียบเทียบค่าต่าง ๆ ระหว่างภูมิภาค

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Map, 50, 50, 500, 400);
    $pres->save("mapChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิแบบผสม**

แผนภูมิแบบผสม (หรือ combo chart) รวมสองหรือมากกว่าประเภทแผนภูมิในกราฟเดียว ทำให้คุณสามารถไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุดได้ ช่วยให้คุณระบุความสัมพันธ์ระหว่างข้อมูลได้ชัดเจนขึ้น

![The combination chart](combination_chart.png)

โค้ด PHP ด้านล่างแสดงวิธีสร้างแผนภูมิแบบผสมที่แสดงในภาพข้างต้นใน PowerPoint:

```php
function createComboChart() {
    $presentation = new Presentation();
    $slide = $presentation->getSlides()->get_Item(0);
    try {
        $chart = createChartWithFirstSeries($slide);

        addSecondSeriesToChart($chart);
        addThirdSeriesToChart($chart);

        setPrimaryAxesFormat($chart);
        setSecondaryAxesFormat($chart);

        $presentation->save("combo-chart.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}

function createChartWithFirstSeries($slide) {
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

    // ตั้งค่าชื่อเรื่องของแผนภูมิ.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // ตั้งค่าคำอธิบายของแผนภูมิ.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น.
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();

    $worksheetIndex = 0;
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    // เพิ่มหมวดหมู่ใหม่.
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 3, 0, "Category 3"));
    $chart->getChartData()->getCategories()->add($workbook->getCell($worksheetIndex, 4, 0, "Category 4"));

    // เพิ่มซีรีส์แรก.
    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 1, "Series 1");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, $chart->getType());

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 1, 4.3));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 1, 2.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 1, 3.5));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 1, 4.5));

    return $chart;
}

function addSecondSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 2, "Series 2");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::ClusteredColumn);

    $series->getParentSeriesGroup()->setOverlap(-25);
    $series->getParentSeriesGroup()->setGapWidth(220);

    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 1, 2, 2.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 2, 2, 4.4));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 3, 2, 1.8));
    $series->getDataPoints()->addDataPointForBarSeries($workbook->getCell($worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart($chart) {
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Series 3");
    $series = $chart->getChartData()->getSeries()->add($seriesNameCell, ChartType::Line);

    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 1, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 2, 3, 2.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 3, 3, 3.0));
    $series->getDataPoints()->addDataPointForLineSeries($workbook->getCell($worksheetIndex, 4, 3, 5.0));

    $series->setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat($chart) {
    // ตั้งค่าแกนแนวนอน.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // ตั้งค่าแกนแนวตั้ง.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // ตั้งค่าสีของเส้นตารางหลักแนวตั้ง.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // ตั้งค่าแกนแนวนอนรอง.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // ตั้งค่าแกนแนวตั้งรอง.
    $secondaryVerticalAxis = $chart->getAxes()->getSecondaryVerticalAxis();
    $secondaryVerticalAxis->setPosition(AxisPositionType::Right);
    $secondaryVerticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $secondaryVerticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryVerticalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle($axis, $axisTitle) {
    $axis->setTitle(true);
    $axis->getTitle()->setOverlay(false);
    $titleParagraph = $axis->getTitle()->addTextFrameForOverriding($axisTitle)->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(12);
}
```

## **อัปเดตแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ที่แสดงถึงการนำเสนอที่มีแผนภูมิที่ต้องการอัปเดต
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. ไล่ตรวจสอบรูปร่างทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ
5. แก้ไขซีรีส์ของแผนภูมิโดยเปลี่ยนค่าของซีรีส์
6. เพิ่มซีรีส์ใหม่และใส่ข้อมูลของมัน
7. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # ดึงแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $sld->getShapes()->get_Item(0);
    # ตั้งค่าดัชนีของแผ่นงานข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลของแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # เปลี่ยนชื่อหมวดหมู่ของแผนภูมิ
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # ดึงซีรีส์แรกของแผนภูมิ
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # ตอนนี้กำลังอัปเดตข้อมูลซีรีส์
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// แก้ไขชื่อซีรีส์

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # ดึงซีรีส์ที่สองของแผนภูมิ
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # ตอนนี้กำลังอัปเดตข้อมูลซีรีส์
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// แก้ไขชื่อซีรีส์

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # ตอนนี้, เพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # ดึงซีรีส์ที่สามของแผนภูมิ
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # ตอนนี้กำลังเติมข้อมูลให้ซีรีส์
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # บันทึกการนำเสนอพร้อมแผนภูมิ
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ตั้งค่าช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงที่ใช้แล้วโดยแผนภูมิที่มีอยู่แล้ว ให้ดูที่ [ตรวจสอบช่วงข้อมูลของแผนภูมิ](/slides/th/php-java/chart-workbook/#retrieve-a-charts-data-range).

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) ที่แสดงถึงการนำเสนอที่มีแผนภูมิ
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. ไล่ตรวจสอบรูปร่างทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ
4. เข้าถึงข้อมูลของแผนภูมิและตั้งค่าช่วง
5. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->get_Item(0);
    $chart->getChartData()->setRange("Sheet1!A1:B4");
    $pres->save("SetDataRange_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ใช้ตัวบ่งชี้เริ่มต้นในแผนภูมิ**

เมื่อคุณใช้ตัวบ่งชี้เริ่มต้นในแผนภูมิแต่ละซีรีส์ของแผนภูมิจะได้รับสัญลักษณ์ตัวบ่งชี้ที่แตกต่างกันโดยอัตโนมัติ

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::LineWithMarkers, 10, 10, 400, 400);
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $fact = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "C1"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 1, 24));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "C2"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 1, 23));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "C3"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 1, -10));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 4, 0, "C4"));
    $series->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 1, null));
    $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 2, "Series 2"), $chart->getType());
    # ดึงซีรีส์ที่สองของแผนภูมิ
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # ตอนนี้กำลังเติมข้อมูลให้ซีรีส์
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 1, 2, 30));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 2, 2, 10));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 3, 2, 60));
    $series2->getDataPoints()->addDataPointForLineSeries($fact->getCell(0, 4, 2, 40));
    $chart->setLegend(true);
    $chart->getLegend()->setOverlay(false);
    $pres->save("DefaultMarkersInChart.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Aspose.Slides รองรับประเภทแผนภูมิใดบ้าง?**

Aspose.Slides รองรับช่วงกว้างของ [ประเภทแผนภูมิ](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/), รวมถึงแผนภูมิกลาง, เส้น, วงกลม, พื้นที่, กระจาย, ไฮสโตแกรม, เรดาร์, และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับการแสดงข้อมูลของคุณ

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิพร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะฝังแผนภูมิเข้ากับการนำเสนอของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงแผ่นงานข้อมูลของมัน ([ChartDataWorkbook](https://reference.aspose.com/slides/php-java/aspose.slides/chartdataworkbook/)), ล้างซีรีส์และหมวดหมู่เริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ นี่ช่วยให้คุณรีเฟรชแผนภูมิเพื่อแสดงข้อมูลล่าสุดได้

**ฉันสามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides ให้ตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, คำอธิบาย, และ [องค์ประกอบการจัดรูปแบบ](/slides/th/php-java/chart-entities/) อื่น ๆ เพื่อให้ลักษณะของแผนภูมิตรงกับความต้องการการออกแบบของคุณอย่างเฉพาะเจาะจง