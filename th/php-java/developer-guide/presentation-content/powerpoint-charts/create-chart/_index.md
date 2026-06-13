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
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิเวียน
- แผนภูมิเส้น
- แผนภูมิ Tree Map
- แผนภูมิสต็อก
- แผนภูมิ Box and Whisker
- แผนภูมิ Funnel
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- งานนำเสนอ
- PHP
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java. เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานจริง."
---
## **ภาพรวม**

บทความนี้เป็นคำแนะนำที่ครบถ้วนเกี่ยวกับวิธีสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีเพิ่มแผนภูมิลงในสไลด์โดยใช้โค้ด, เติมข้อมูลให้แผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ทั้งหมดนี้มาพร้อมกับตัวอย่างโค้ดที่ละเอียด แสดงขั้นตอนตั้งแต่การเริ่มต้นพรีเซนเทชันและอ็อบเจกต์แผนภูมิ ไปจนถึงการกำหนดซีรีส์, แกน, และคำอธิบายโดยย่อ การทำตามคำแนะนำนี้จะทำให้คุณเข้าใจวิธีผสานการสร้างแผนภูมิดิจิทัลเข้ากับแอปพลิเคชันของคุณได้อย่างราบรื่น ส่งเสริมกระบวนการสร้างพรีเซนเทชันที่ขับเคลื่อนด้วยข้อมูล

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้รับอินไซต์ที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ด้วยแผนภูมิคุณสามารถ

* รวม, บีบอัด, หรือสรุปข้อมูลจำนวนมากไว้ในสไลด์เดียวของพรีเซนเทชัน
* เปิดเผยรูปแบบและแนวโน้มในข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ
* พบค่าผิดปกติ, การเบี่ยงเบน, ความผิดพลาด, หรือข้อมูลที่ไม่มีความหมาย
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิได้ผ่านฟังก์ชันแทรก ซึ่งให้เทมเพลตสำหรับออกแบบแผนภูมิต่าง ๆ มากมาย ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิที่นิยม) และแผนภูกีกำหนดเองได้

{{% alert color="primary" %}} 
เพื่อให้คุณสร้างแผนภูมิได้ Aspose.Slides มีคลาส [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType) ฟิลด์ในคลาสนี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ 
{{% /alert %}} 

### **สร้างแผนภูมิปกติ**

_ขั้นตอน: สร้างแผนภูมิ_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ PowerPoint </strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Presentation </strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ PowerPoint Presentation </strong></a>

_ขั้นตอนโค้ด:_

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) 
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ 
4. เพิ่มชื่อเรื่องให้แผนภูมิ 
5. เข้าถึงใบงานข้อมูลแผนภูมิ 
6. ล้างซีรีส์และหมวดหมู่เริ่มต้นทั้งหมด 
7. เพิ่มซีรีส์และหมวดหมู่ใหม่ 
8. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ 
9. เพิ่มสีเติมสำหรับซีรีส์ของแผนภูมิ 
10. เพิ่มป้ายกำกับสำหรับซีรีส์ของแผนภูมิ 
11. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX 

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิปกติ:

```php
  # สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $sld->getShapes()->addChart(ChartType::ClusteredColumn, 0, 0, 500, 500);
    # ตั้งค่าชื่อแผนภูมิ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->hasTitle();
    # ตั้งค่าให้ซีรีส์แรกแสดงค่
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ตั้งค่าดัชนีสำหรับแผ่นข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติ
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
    # บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิกระจาย**

แผนภูมิกระจาย (หรือที่รู้จักกันว่า scatter plot / กราฟ x‑y) มักใช้เพื่อหาลักษณะหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

คุณอาจต้องการใช้แผนภูมิกระจายเมื่อ

* มีข้อมูลตัวเลขเป็นคู่
* มีสองตัวแปรที่จับคู่กันได้ดี
* ต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่
* มีตัวแปรอิสระที่มีค่าหลายค่า สำหรับตัวแปรตาม

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจาย </strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจาย PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจาย PowerPoint Presentation </strong></a>

1. โปรดทำตามขั้นตอนที่ระบุในส่วน [สร้างแผนภูมิปกติ](#creating-normal-charts) 
2. สำหรับขั้นตอนที่สาม ให้เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิเป็นหนึ่งในต่อไปนี้  
   1. [ChartType::ScatterWithMarkers](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิกระจายที่มีตัวบ่งชี้_  
   2. [ChartType::ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิกระจายเชื่อมต่อด้วยเส้นโค้งและมีตัวบ่งชี้_  
   3. [ChartType::ScatterWithSmoothLines](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิกระจายเชื่อมต่อด้วยเส้นโค้งโดยไม่มีตัวบ่งชี้_  
   4. [ChartType::ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิกระจายเชื่อมต่อด้วยเส้นตรงและมีตัวบ่งชี้_  
   5. [ChartType::ScatterWithStraightLines](https://reference.aspose.com/slides/th/php-java/aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิกระจายเชื่อมต่อด้วยเส้นตรงโดยไม่มีตัวบ่งชี้_  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิกระจายโดยมีชุดตัวบ่งชี้ต่าง ๆ:

```php
  # สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slide = $pres->getSlides()->get_Item(0);
    # สร้างแผนภูมิตามค่าเริ่มต้น
    $chart = $slide->getShapes()->addChart(ChartType::ScatterWithSmoothLines, 0, 0, 400, 400);
    # ดึงดัชนีของแผ่นงานข้อมูลแผนภูมิเริ่มต้น
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # ลบซีรีส์ตัวอย่าง
    $chart->getChartData()->getSeries()->clear();
    # เพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 1, 3, "Series 2"), $chart->getType());
    # ดึงซีรีส์แผนภูมิเบื้องต้นแรก
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

แผนภูมิเวียน (pie chart) เหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนเต็มของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีหลายส่วนหรือหลายป้าย คุณอาจพิจารณาใช้แผนภูมิแท่งแทน

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิเวียน </strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิเวียน PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิเวียน PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ (ในกรณีนี้คือ [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).Pie)  
4. เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ  
8. เพิ่มจุดใหม่สำหรับแผนภูมิและกำหนดสีที่กำหนดเองสำหรับส่วนของแผนภูมิเวียน  
9. ตั้งค่าป้ายกำกับสำหรับซีรีส์  
10. ตั้งค่าเส้นนำสำหรับป้ายกำกับซีรีส์  
11. ตั้งค่ามุมการหมุนของสไลด์แผนภูมิเวียน  
12. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิเวียน:

```php
  # สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่แทนไฟล์ PPTX
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $slides = $pres->getSlides()->get_Item(0);
    # เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $slides->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # ตั้งค่าชื่อแผนภูมิ
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # ตั้งค่าให้ซีรีส์แรกแสดงค่
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # ตั้งค่าดัชนีสำหรับแผ่นข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลแผนภูมิ
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
    # เพิ่มจุดใหม่และกำหนดสีส่วนของแผนภูมิ
    # series.IsColorVaried = true;
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setColorVaried(true);
    $point = $series->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->CYAN);
    # ตั้งค่าขอบส่วนของแผนภูมิ
    $point->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    $point->getFormat()->getLine()->setWidth(3.0);
    $point->getFormat()->getLine()->setStyle(LineStyle->ThinThick);
    $point->getFormat()->getLine()->setDashStyle(LineDashStyle->DashDot);
    $point1 = $series->getDataPoints()->get_Item(1);
    $point1->getFormat()->getFill()->setFillType(FillType::Solid);
    $point1->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    # ตั้งค่าขอบส่วนของแผนภูมิ
    $point1->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point1->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $point1->getFormat()->getLine()->setWidth(3.0);
    $point1->getFormat()->getLine()->setStyle(LineStyle->Single);
    $point1->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDot);
    $point2 = $series->getDataPoints()->get_Item(2);
    $point2->getFormat()->getFill()->setFillType(FillType::Solid);
    $point2->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # ตั้งค่าขอบส่วนของแผนภูมิ
    $point2->getFormat()->getLine()->getFillFormat()->setFillType(FillType::Solid);
    $point2->getFormat()->getLine()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $point2->getFormat()->getLine()->setWidth(2.0);
    $point2->getFormat()->getLine()->setStyle(LineStyle->ThinThin);
    $point2->getFormat()->getLine()->setDashStyle(LineDashStyle->LargeDashDotDot);
    # สร้างป้ายกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
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
    # ตั้งค่ามุมการหมุนสำหรับส่วนของแผนภูมิเวียน
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setFirstSliceAngle(180);
    # บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    $pres->save("PieChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (line chart) เหมาะสำหรับการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)  
1. ดึงอ้างอิงสไลด์ตามดัชนี  
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ (ในกรณีนี้คือ `ChartType::Line`)  
1. เข้าถึงแผนภูมิข้อมูล IChartDataWorkbook  
1. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
1. เพิ่มซีรีส์และหมวดหมู่ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ  
1. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิเส้น:

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

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นประ คุณสามารถระบุประเภทเส้นประที่ต้องการได้ดังนี้:

```php
  $lineChart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Line, 10, 50, 600, 350);
  foreach($lineChart->getChartData()->getSeries() as $series) {
    $series->getFormat()->getLine()->setDashStyle(LineDashStyle->Dash);
  }
```

### **สร้างแผนภูมิ Tree Map**

แผนภูมิ Tree Map เหมาะสำหรับข้อมูลการขายเมื่อต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและในเวลาเดียวกันดึงความสนใจไปยังรายการที่เป็นผู้สนับสนุนหลักของแต่ละหมวดหมู่

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map </strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ (ในกรณีนี้คือ [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).TreeMap)  
4. เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ  
8. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Tree Map:

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

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Stock </strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Stock PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Stock PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).OpenHighLowClose)  
4. เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ  
8. กำหนดรูปแบบ HiLowLines  
9. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP ตัวอย่างสำหรับสร้างแผนภูมิ Stock:

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
    foreach($chart->getChartData()->getSeries() as $ser) {
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

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker </strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).BoxAndWhisker)  
4. เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ  
8. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Box and Whisker:

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

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel </strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).Funnel)  
4. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Funnel:

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

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst </strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ (ในกรณีนี้คือ [ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).sunburst)  
4. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Sunburst:

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

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram </strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).Histogram)  
4. เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Histogram:

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

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar </strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทที่ต้องการ (`ChartType::Radar` ในกรณีนี้)  
4. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Radar:

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

### **สร้างแผนภูมิ Multi‑Category**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category </strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category PowerPoint Presentation </strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation)   
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/php-java/aspose.slides/ChartType).ClusteredColumn)  
4. เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)  
5. ล้างซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์ของแผนภูมิ  
8. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Multi‑Category:

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
    # บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    $pres->save("AsposeChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **สร้างแผนภูมิ Map**

แผนภูมิแผนที่เป็นการแสดงภาพข้อมูลบนพื้นที่เฉพาะ ใช้เปรียบเทียบข้อมูลหรือค่าต่าง ๆ ระหว่างภูมิภาคทางภูมิศาสตร์

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Map </strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Map PowerPoint </strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Map PowerPoint Presentation </strong></a>

โค้ด PHP นี้แสดงวิธีสร้างแผนภูมิ Map:

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

### **สร้างแผนภูมิ Combination**

แผนภูมิผสม (หรือ combo chart) ผสานประเภทแผนภูมิสองประเภทหรือมากกว่าบนกราฟเดียว ช่วยให้คุณไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุดได้ง่ายขึ้น

![แผนภูมิแบบรวม](combination_chart.png)

โค้ด PHP ต่อไปนี้แสดงวิธีสร้างแผนภูมิกรวมที่แสดงในรูปด้านบนในพรีเซนเทชัน PowerPoint:

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

    // ตั้งค่าชื่อแผนภูมิ.
    $chart->setTitle(true);
    $chart->getChartTitle()->addTextFrameForOverriding("Chart Title");
    $chart->getChartTitle()->setOverlay(false);
    $titleParagraph = $chart->getChartTitle()->getTextFrameForOverriding()->getParagraphs()->get_Item(0);
    $titleFormat = $titleParagraph->getParagraphFormat()->getDefaultPortionFormat();
    $titleFormat->setFontBold(NullableBool::False);
    $titleFormat->setFontHeight(18);
    
    // ตั้งค่าสัญลักษณ์อธิบายแผนภูมิ.
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
    // ตั้งแกนแนวนอน.
    $horizontalAxis = $chart->getAxes()->getHorizontalAxis();
    $horizontalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $horizontalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($horizontalAxis, "X Axis");

    // ตั้งแกนแนวตั้ง.
    $verticalAxis = $chart->getAxes()->getVerticalAxis();
    $verticalAxis->getTextFormat()->getPortionFormat()->setFontHeight(12);
    $verticalAxis->getFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    setAxisTitle($verticalAxis, "Y Axis 1");

    // ตั้งค่าสีของเส้นกริดแนวตั้งหลัก.
    $majorGridLinesFormat = $verticalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat();
    $majorGridLinesFormat->setFillType(FillType::Solid);
    $majorGridLinesFormat->getSolidFillColor()->setColor(new java("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat($chart) {
    // ตั้งแกนแนวนอนรอง.
    $secondaryHorizontalAxis = $chart->getAxes()->getSecondaryHorizontalAxis();
    $secondaryHorizontalAxis->setPosition(AxisPositionType::Bottom);
    $secondaryHorizontalAxis->setCrossType(CrossesType::Maximum);
    $secondaryHorizontalAxis->setVisible(false);
    $secondaryHorizontalAxis->getMajorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);
    $secondaryHorizontalAxis->getMinorGridLinesFormat()->getLine()->getFillFormat()->setFillType(FillType::NoFill);

    // ตั้งแกนแนวตั้งรอง.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ PowerPoint </strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ Presentation </strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ PowerPoint Presentation </strong></a>

1. สร้างอ็อบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่แทนพรีเซนเทชันที่มีแผนภูมิที่ต้องการอัปเดต  
2. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. วนลูปผ่านรูปร่างทั้งหมดเพื่อหากแผนภูมิที่ต้องการ  
4. เข้าถึงแผนภูมิเวิร์กชีทข้อมูล  
5. แก้ไขข้อมูลซีรีส์ของแผนภูมิโดยเปลี่ยนค่าของซีรีส์  
6. เพิ่มซีรีส์ใหม่และเติมข้อมูลลงในนั้น  
7. เขียนพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีอัปเดตแผนภูมิ:

```php
  $pres = new Presentation();
  try {
    # เข้าถึงสไลด์แรก
    $sld = $pres->getSlides()->get_Item(0);
    # ดึงแผนภูมิพร้อมข้อมูลเริ่มต้น
    $chart = $sld->getShapes()->get_Item(0);
    # ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    $defaultWorksheetIndex = 0;
    # ดึงแผ่นงานข้อมูลแผนภูมิ
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # เปลี่ยนชื่อหมวดหมู่ของแผนภูมิ
    $fact->getCell($defaultWorksheetIndex, 1, 0, "Modified Category 1");
    $fact->getCell($defaultWorksheetIndex, 2, 0, "Modified Category 2");
    # ดึงซีรีส์แรกของแผนภูมิ
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    # ตอนนี้กำลังอัปเดตข้อมูลของซีรีส์
    $fact->getCell($defaultWorksheetIndex, 0, 1, "New_Series1");// แก้ไขชื่อซีรีส์

    $series->getDataPoints()->get_Item(0)->getValue()->setData(90);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(123);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(44);
    # ดึงซีรีส์ที่สองของแผนภูมิ
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # ตอนนี้กำลังอัปเดตข้อมูลของซีรีส์
    $fact->getCell($defaultWorksheetIndex, 0, 2, "New_Series2");// แก้ไขชื่อซีรีส์

    $series->getDataPoints()->get_Item(0)->getValue()->setData(23);
    $series->getDataPoints()->get_Item(1)->getValue()->setData(67);
    $series->getDataPoints()->get_Item(2)->getValue()->setData(99);
    # ตอนนี้กำลังเพิ่มซีรีส์ใหม่
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 3, "Series 3"), $chart->getType());
    # ดึงซีรีส์ที่ 3 ของแผนภูมิ
    $series = $chart->getChartData()->getSeries()->get_Item(2);
    # ตอนนี้กำลังเติมข้อมูลให้ซีรีส์
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

## **ตั้งค่าช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอ็อบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/Presentation) ที่แทนพรีเซนเทชันที่มีแผนภูมิ  
2. ดึงอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. วนลูปผ่านรูปร่างทั้งหมดเพื่อหากแผนภูมิที่ต้องการ  
4. เข้าถึงข้อมูลแผนภูมิและตั้งค่าช่วงข้อมูล  
5. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX  

โค้ด PHP นี้แสดงวิธีตั้งค่าช่วงข้อมูลสำหรับแผนภูมิ:

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

## **ใช้เครื่องหมายเริ่มต้นในแผนภูมิ**

เมื่อใช้เครื่องหมายเริ่มต้นในแผนภูมิ แต่ละซีรีส์ของแผนภูมิจะได้รับสัญลักษณ์เครื่องหมายเริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ด PHP นี้แสดงวิธีตั้งค่าเครื่องหมายเริ่มต้นของซีรีส์แผนภูมิโดยอัตโนมัติ:

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

**แผนภูมิประเภทใดบ้างที่ Aspose.Slides รองรับ?**

Aspose.Slides รองรับแผนภูมิด้านหลากหลายประเภทเช่น แถบ, เส้น, วงกลม, พื้นที่, กระจาย, histogram, radar, และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณที่สุด

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/php-java/aspose.slides/presentation/) ดึงสไลด์ที่ต้องการโดยใช้ดัชนี แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิ พร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น การทำเช่นนี้จะทำให้แผนภูมิถูกฝังลงในพรีเซนเทชันของคุณโดยตรง

**ฉันสามารถอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงเวิร์กชีทข้อมูลของมัน ([ChartDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/chartdataworkbook/)) ล้างซีรีส์และหมวดหมู่เริ่มต้น แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ ซึ่งทำให้แผนภูมิสะท้อนข้อมูลล่าสุดได้

**สามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ใช่ Aspose.Slides มีตัวเลือกการปรับแต่งอย่างครอบคลุม คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, คำอธิบาย, และองค์ประกอบการจัดรูปแบบอื่น ๆ [/slides/th/php-java/chart-entities/] เพื่อให้แผนภูมิตรงกับความต้องการออกแบบของคุณอย่างแม่นยำ