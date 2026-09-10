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
- ปรับปรุงแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิ Tree Map
- แผนภูมิสต็อก
- แผนภูมิ Box and Whisker
- แผนภูมิ Funnel
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิมัลติ‑Category
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java เพิ่ม แก้ไขรูปแบบ และแก้ไขแผนภูมิกับตัวอย่างโค้ดที่ใช้งานได้จริง."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำโดยละเอียดเกี่ยวกับวิธีสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีเพิ่มแผนภูมิลงในสไลด์โดยอัตโนมัติ เติมข้อมูลลงในแผนภูมิ และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ตัวอย่างโค้ดที่ละเอียดจะอธิบายขั้นตอนแต่ละขั้นตอน ตั้งแต่การเริ่มต้นพรีเซนเทชันและอ็อบเจกต์แผนภูมิ ไปจนถึงการกำหนดค่าซีรีส์, แกน, และคำอธิบาย โดยทำตามแนวทางนี้ คุณจะเข้าใจวิธีผสานการสร้างแผนภูมิแบบไดนามิกเข้ากับแอปพลิเคชันของคุณ ทำให้กระบวนการสร้างพรีเซนเทชันที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิกำหนดให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและสรุปข้อมูลที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

การใช้แผนภูมิช่วยให้คุณทำได้:
* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากบนสไลด์เดียวในพรีเซนเทชัน
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ
* ตรวจพบค่าเบี่ยงเบน, ความผิดปกติ, ความคลาดเคลื่อน, ข้อผิดพลาด หรือข้อมูลที่ไม่มีเหตุผล
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งมีแม่แบบสำหรับออกแบบแผนภูมิหลายประเภท ด้วย Aspose.Slides คุณสามารถสร้างทั้งแผนภูมิปกติ (ตามประเภทแผนภูมิยอดนิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="Note" %}}
เพื่อสร้างแผนภูมิ ใช้คลาส [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) ฟิลด์ในคลาสนี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ส่วนนี้อธิบายวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่มด้วย Aspose.Slides คุณจะได้เรียนรู้การเริ่มต้นพรีเซนเทชัน, การเพิ่มแผนภูมิ, และการปรับแต่งองค์ประกอบต่าง ๆ เช่น ชื่อเรื่อง, ข้อมูล, ซีรีส์, หมวดหมู่, และสไตล์ ทำตามขั้นตอนด้านล่างเพื่อดูวิธีการสร้างแผนภูมิคอลัมน์แบบกลุ่มมาตรฐาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation) 
1. รับอ้างอิงสไลด์โดยใช้ดัชนี
1. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภท `ChartType::ClusteredColumn`
1. เพิ่มชื่อเรื่องให้แผนภูมิ
1. เข้าถึง worksheet ของข้อมูลแผนภูมิ
1. ลบซีรีส์และหมวดหมู่เริ่มต้นทั้งหมด
1. เพิ่มซีรีส์และหมวดหมู่ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์
1. กำหนดสีพื้นหลังให้กับซีรีส์
1. เพิ่มป้ายกำกับให้กับซีรีส์
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด C# นี้แสดงวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่ม:

```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นไฟล์ PPTX
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
    # ตั้งค่าซีรีส์แรกให้แสดงค่า
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ตั้งดัชนีสำหรับชีตข้อมูลของแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึง WorkSheet ของข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์และหมวดหมู่ที่สร้างขึ้นโดยอัตโนมัติ
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
    # ดึงซีรีส์แผนภูมิแรก
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
    # สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
    # ตั้งค่าป้ายกำกับแรกให้แสดงชื่อหมวดหมู่
    $lbl = $series->getDataPoints()->get_Item(0)->getLabel();
    $lbl->getDataLabelFormat()->setShowCategoryName(true);
    $lbl = $series->getDataPoints()->get_Item(1)->getLabel();
    $lbl->getDataLabelFormat()->setShowSeriesName(true);
    # แสดงค่าสำหรับป้ายกำกับที่สาม
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

แผนภูมิกระจาย (หรือ scatter plot, x‑y graph) มักใช้เพื่อตรวจสอบรูปแบบหรือความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิกระจายเมื่อ:
* คุณมีข้อมูลเชิงตัวเลขคู่
* มีสองตัวแปรที่จับคู่กันได้ดี
* คุณต้องการตรวจสอบว่าตัวแปรสองตัวเกี่ยวข้องกันหรือไม่
* มีตัวแปรอิสระที่มีค่าหลายค่าเพื่อตัวแปรตาม

1. ทำตามขั้นตอนใน [Create Clustered Column Charts](#create-clustered-column-charts)  
2. ในขั้นที่สาม ให้เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิโดยเลือกหนึ่งตัวเลือกต่อไปนี้:
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิกระจาย_
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นโค้งพร้อมเครื่องหมายข้อมูล_
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นโค้งโดยไม่มีเครื่องหมายข้อมูล_
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นตรงพร้อมเครื่องหมายข้อมูล_
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นตรงโดยไม่มีเครื่องหมายข้อมูล_

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิกระจายโดยใช้เครื่องหมายที่แตกต่างกันสำหรับแต่ละซีรีส์:

```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # สร้างแผนภูมิเริ่มต้น
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # ดึงดัชนีของ worksheet ข้อมูลแผนภูมิเริ่มต้น
    $defaultWorksheetIndex = 0;
    # ดึง worksheet ของข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์ตัวอย่าง
    $chart->getChartData()->getSeries()->clear();
    # เพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # ดึงซีรีส์แผนภูมิแรก
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # เพิ่มจุดใหม่ (1:3) ให้กับซีรีส์
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 1), $fact->getCell($defaultWorksheetIndex, 2, 2, 3));
    # เพิ่มจุดใหม่ (2:10)
    $series->getDataPoints()->addDataPointForScatterSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 2), $fact->getCell($defaultWorksheetIndex, 3, 2, 10));
    # เปลี่ยนประเภทของซีรีส์
    $series->setType(ChartType::ScatterWithStraightLinesAndMarkers);
    # เปลี่ยนตัวทำเครื่องหมายของซีรีส์แผนภูมิ
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
    # เปลี่ยนตัวทำเครื่องหมายของซีรีส์แผนภูมิ
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

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีฉลากเชิงประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือฉลากจำนวนมาก คุณอาจควรใช้แผนภูมิบาร์แทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท [ChartType::Pie](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#Pie)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
8. เพิ่มจุดใหม่ให้แผนภูมิและกำหนดสีที่กำหนดเองสำหรับส่วนต่าง ๆ ของแผนภูมิวงกลม  
9. ตั้งค่าป้ายกำกับสำหรับซีรีส์  
10. เปิดใช้งานเส้นเชื่อมสำหรับป้ายกำกับซีรีส์  
11. กำหนดมุมการหมุนของส่วนแผนภูมิวงกลม  
12. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิวงกลม:

```php
  # สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นไฟล์ PPTX
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
    # ตั้งดัชนีสำหรับชีตข้อมูลของแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึง worksheet ของข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติ
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
    # เพิ่มจุดใหม่และตั้งค่าสีส่วนของแผนภูมิ
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
    # สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
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
    # ตั้งค่ามุมการหมุนของส่วนในแผนภูมิวงกลม
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

แผนภูมิเส้น (หรือ line graph) เหมาะสำหรับแสดงการเปลี่ยนแปลงค่าตามเวลา ใช้แผนภูมิเส้นเพื่อเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนี  
1. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท [ChartType::Line](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#Line)  
1. เข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/))  
1. ลบซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิเส้น:

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

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยจุดขีดให้กำหนดประเภทเส้นที่ต้องการดังนี้:

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

### **สร้างแผนภูมิเพิ่มต้น (Tree Map) **

แผนภูมิ Tree Map เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้มีส่วนร่วมใหญ่ในแต่ละหมวดหมู่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภท [ChartType::Treemap](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#Treemap)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
8. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Tree Map:

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

### **สร้างแผนภูมิสต็อก**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType::OpenHighLowClose](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#OpenHighLowClose)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
8. กำหนดรูปแบบของเส้น high‑low  
9. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิสต็อก:

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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType::BoxAndWhisker](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#BoxAndWhisker)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
8. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Box and Whisker:

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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType::Funnel](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#Funnel)  
4. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Funnel:

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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType::Sunburst](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#Sunburst)  
4. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Sunburst:

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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType::Histogram](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#Histogram)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Histogram:

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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ ([ChartType::Radar](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#Radar))  
4. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Radar:

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

### **สร้างแผนภูมิหลายหมวดหมู่ (Multi‑Category)**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType::ClusteredColumn](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ClusteredColumn)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์  
8. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิมัลติ‑Category:

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

### **สร้างแผนภูมิแผนที่ (Map Charts)**

แผนภูมิแผนที่ช่วยให้คุณมองเห็นข้อมูลทางภูมิศาสตร์และเปรียบเทียบค่าในแต่ละภูมิภาค

ตัวอย่างโค้ด PHP นี้แสดงวิธีสร้างแผนภูมิแผนที่:

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

### **สร้างแผนภูมิแบบผสม (Combination Charts)**

แผนภูมิแบบผสม (หรือ combo chart) รวมสองประเภทแผนภูมิหรือมากกว่าลงในกราฟเดียว แผนภูมินี้ช่วยให้คุณไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อระบุความสัมพันธ์ระหว่างข้อมูล

![แผนภูมิแบบผสม](combination_chart.png)

โค้ด PHP ต่อไปนี้แสดงวิธีสร้างแผนภูมิแบบผสมตามที่แสดงในภาพด้านบนใน PowerPoint:

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
    
    // ตั้งค่าตำนานแผนภูมิ.
    $chart->getLegend()->setPosition(LegendPositionType::Bottom);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(12);

    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติ.
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

    // ตั้งค่าสีเส้นกริดหลักแนวตั้ง.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // ตั้งค่าแกนแนวนอนสำรอง.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // ตั้งค่าแกนแนวตั้งสำรอง.
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ซึ่งแสดงพรีเซนเทชันที่มีแผนภูมิที่ต้องการอัปเดต  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เดินทางผ่านรูปทรงทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ  
4. เข้าถึง worksheet ของข้อมูลแผนภูมิ  
5. ปรับแก้ซีรีส์ของแผนภูมิโดยเปลี่ยนค่าซีรีส์  
6. เพิ่มซีรีส์ใหม่และเติมข้อมูลลงในซีรีส์นั้น  
7. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีอัปเดตแผนภูมิ:

```php
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # ดึงแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $sld->getShapes()->get_Item(0);
    # ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึง worksheet ของข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # เปลี่ยนชื่อหมวดหมู่ของแผนภูมิ
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # ดึงซีรีส์แผนภูมิแรก
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # กำลังอัปเดตข้อมูลซีรีส์
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// แก้ไขชื่อซีรีส์

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # ดึงซีรีส์แผนภูมิที่สอง
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # กำลังอัปเดตข้อมูลซีรีส์
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// แก้ไขชื่อซีรีส์

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # ขณะนี้กำลังเพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # ดึงซีรีส์แผนภูมิที่สาม
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # กำลังเติมข้อมูลให้ซีรีส์
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 3, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 3, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 3, 30));
    $chart->setType(ChartType::ClusteredCylinder);
    # บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    $pres->save("AsposeChartModified_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **กำหนดช่วงข้อมูลของแผนภูมิ**

เพื่อกำหนดช่วงข้อมูลของแผนภูมิ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ที่เป็นพรีเซนเทชันที่มีแผนภูมิ  
2. รับอ้างอิงสไลด์โดยใช้ดัชนี  
3. เดินทางผ่านรูปทรงทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ  
4. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วง  
5. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างโค้ด PHP นี้แสดงวิธีกำหนดช่วงข้อมูลของแผนภูมิ:

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

## **ใช้ Marker เริ่มต้นในแผนภูมิ**

เมื่อใช้ Marker เริ่มต้นในแผนภูมิแต่ละซีรีส์จะได้รับสัญลักษณ์ Marker ที่แตกต่างโดยอัตโนมัติ

ตัวอย่างโค้ด PHP นี้แสดงวิธีตั้งค่า Marker ของซีรีส์แผนภูมิโดยอัตโนมัติ:

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
    # ดึงซีรีส์แผนภูมิที่สอง
    $series2 = $chart->getChartData()->getSeries()->get_Item(1);
    # กำลังเติมข้อมูลให้ซีรีส์
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

## **คำถามที่พบบ่อย (FAQ)**

**แผนภูมิประเภทใดบ้างที่ Aspose.Slides รองรับ?**

Aspose.Slides รองรับแผนภูมิ [หลายประเภท](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/) เช่น แถบ, เส้น, วงกลม, พื้นที่, กระจาย, ฮิสโตแกรม, เรดาร์ และอื่น ๆ อีกมาก ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณได้อย่างอิสระ

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/), ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิโดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น ขั้นตอนนี้จะผสานแผนภูมิเข้าไปในพรีเซนเทชันของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)), ลบซีรีส์และหมวดหมู่เริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดเองของคุณเอง วิธีนี้ทำให้คุณรีเฟรชแผนภูมิเพื่อแสดงข้อมูลล่าสุดได้เสมอ

**ฉันสามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides มีตัวเลือกการปรับแต่งที่ครอบคลุม คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, คำอธิบาย, และองค์ประกอบการจัดรูปแบบอื่น ๆ [/slides/th/php-java/chart-entities/] เพื่อให้แผนภูมิตรงกับความต้องการออกแบบของคุณอย่างแม่นยำ