---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ใน Java
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/java/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิแผนที่ต้นไม้
- แผนภูมิสต็อก
- แผนภูมิ Box and Whisker
- แผนภูมิ Funnel
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิหลายประเภท
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Java เพิ่ม แก้ไขรูปแบบและแก้ไขแผนภูมิด้วยตัวอย่างโค้ดเชิงปฏิบัติใน Java."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำแบบครบถ้วนเกี่ยวกับการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม ประมวลผล เติมข้อมูลลงในแผนภูมิ และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการการออกแบบของคุณ ทั้งหมดนี้จะมีตัวอย่างโค้ดที่ละเอียดเพื่ออธิบายแต่ละขั้นตอน ตั้งแต่การเริ่มต้น Presentation และอ็อบเจกต์แผนภูมิ ไปจนถึงการกำหนด Series, Axis, และ Legend โดยการทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีการผสานการสร้างแผนภูมิกระ динамиกในแอปพลิเคชันของคุณ ทำให้การสร้างพรีเซนเทชันที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**
แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อมูลเชิงลึก ซึ่งอาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

การใช้แผนภูมิคุณสามารถ

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากลงในสไลด์เดียวของพรีเซนเทชัน
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยการวัดที่ระบุ
* ชี้จุดที่เป็น outlier, ความผิดปกติ, การเบี่ยงเบน, ข้อผิดพลาด, ข้อมูลที่ไม่มีความหมาย ฯลฯ
* สื่อสารหรือแสดงข้อมูลซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน Insert ซึ่งให้เทมเพลตสำหรับออกแบบแผนภูมิต่างประเภทได้หลายแบบ โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิยอดนิยม) และแผนภูมิแบบกำหนดเองได้

{{% alert color="primary" %}} 
เพื่อให้คุณสร้างแผนภูมิได้ Aspose.Slides มีคลาส [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType) ซึ่งฟิลด์ต่าง ๆ ภายในคลาสนี้สอดคล้องกับประเภทแผนภูมิแตกต่างกัน
{{% /alert %}} 

### **สร้างแผนภูมิปกติ**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ PowerPoint ใน Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Presentation ใน Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ PowerPoint Presentation ใน Java</strong></a>

_Code Steps:_ 

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิที่คุณต้องการ 
4. เพิ่มหัวข้อให้กับแผนภูมิ 
5. เข้าถึง worksheet ของข้อมูลแผนภูมิ 
6. ล้าง Series และ Category เริ่มต้นทั้งหมด 
7. เพิ่ม Series และ Category ใหม่ 
8. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series 
9. เพิ่มสีเติมสำหรับ Series 
10. เพิ่มป้ายกำกับสำหรับ Series 
11. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิปกติ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // ตั้งค่าชื่อแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    
    // ตั้งค่าให้ Series แรกแสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // ตั้งค่าดัชนีสำหรับแผ่นข้อมูลของแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // ดึงแผ่นงานข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบ Series และ Category เริ่มต้นที่สร้างโดยอัตโนมัติ
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // เพิ่ม Series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // เพิ่ม Category ใหม่
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // ดึง Series แผนภูมิแรก
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // ตอนนี้เติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // ตั้งค่าสีเติมสำหรับ Series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // ดึง Series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    
    // เติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ตั้งค่าสีเติมสำหรับ Series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    //สร้างป้ายกำหนดแบบกำหนดเองสำหรับแต่ละ Category ของ Series ใหม่
    // ตั้งค่าป้ายกำหนดแรกให้แสดงชื่อ Category
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // แสดงค่าบนป้ายกำหนดที่สาม
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิกระจาย (Scattered Charts)**
แผนภูมิกระจาย (หรือที่เรียกว่า scatter plot หรือกราฟ x‑y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

คุณอาจต้องการใช้แผนภูมิกระจายเมื่อ

* คุณมีข้อมูลเชิงตัวเลขเป็นคู่
* คุณมีตัวแปร 2 ตัวที่สัมพันธ์กันอย่างดี
* คุณต้องการตรวจสอบว่าตัวแปร 2 ตัวนั้นเกี่ยวข้องกันหรือไม่
* คุณมีตัวแปรอิสระที่มีหลายค่าสำหรับตัวแปรตาม

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจายใน Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจาย PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจาย PowerPoint Presentation ใน Java</strong></a>

1. กรุณาตามขั้นตอนใน [Creating Normal Charts](#creating-normal-charts) 
2. สำหรับขั้นตอนที่สาม ให้เพิ่มแผนภูมิพร้อมข้อมูลและระบุประเภทแผนภูมิเป็นหนึ่งในต่อไปนี้  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิ Scatter พร้อม Marker_  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นโค้ง พร้อม Marker_  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นโค้ง ไม่มี Marker_  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นตรง พร้อม Marker_  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นตรง ไม่มี Marker_  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิกระจายด้วยชุด Marker ที่แตกต่างกัน:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างแผนภูมิเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // ดึงดัชนีของ worksheet ข้อมูลแผนภูมิเริ่มต้น
    int defaultWorksheetIndex = 0;
    
    // ดึง worksheet ของข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบ series ตัวอย่าง
    chart.getChartData().getSeries().clear();
    
    // เพิ่ม series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // ดึง series แผนภูมิแรก
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // เพิ่มจุดใหม่ (1:3) ไปยัง series
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // เพิ่มจุดใหม่ (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // เปลี่ยนประเภทของ series
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // เปลี่ยน Marker ของ series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // ดึง series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    
    // เพิ่มจุดใหม่ (5:2) ที่นั่น
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // เพิ่มจุดใหม่ (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // เพิ่มจุดใหม่ (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // เพิ่มจุดใหม่ (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // เปลี่ยน Marker ของ series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิวงกลม (Pie Charts)**

แผนภูมิวี่เป็นวิธีที่ดีที่สุดในการแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายกำกับเชิงประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือป้ายกำกับจำนวนมาก คุณอาจพิจารณาใช้แผนภูมิแท่งแทน

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิวงกลมใน Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิวี่ PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิวี่ PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ (ในที่นี้คือ [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).Pie) 
4. เข้าถึงข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook) 
5. ล้าง Series และ Category เริ่มต้น 
6. เพิ่ม Series และ Category ใหม่ 
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series 
8. เพิ่มจุดใหม่สำหรับแผนภูมิและกำหนดสีกำหนดเองให้กับเซกเตอร์ของแผนภูมิวี่ 
9. ตั้งค่าป้ายกำกับสำหรับ Series 
10. ตั้งค่ารายการ leader line สำหรับป้ายกำกับ Series 
11. ตั้งค่ามุมการหมุนสำหรับสไลด์แผนภูมิวี่ 
12. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิวี่:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slides = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // ตั้งค่าชื่อแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // ตั้งค่าให้ Series แรกแสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // ดึง worksheet ของข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // เพิ่ม Category ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // เพิ่ม Series ใหม่
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    // เติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // ไม่ทำงานในเวอร์ชันใหม่
    // เพิ่มจุดใหม่และตั้งค่าสีของเซกเตอร์
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // ตั้งค่าขอบของเซกเตอร์
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // ตั้งค่าขอบของเซกเตอร์
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // ตั้งค่าขอบของเซกเตอร์
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // สร้างป้ายกำหนดแบบกำหนดเองสำหรับแต่ละ Category ของ Series ใหม่
    IDataLabel lbl1 = series.getDataPoints().get_Item(0).getLabel();
    
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    
    IDataLabel lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    
    IDataLabel lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    
    // แสดง Leader Lines สำหรับแผนภูมิ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // ตั้งค่าองศาการหมุนสำหรับเซกเตอร์ของแผนภูมิวงกลม
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิเส้น (Line Charts)**

แผนภูมิเส้น (หรือที่เรียกว่า line graph) เหมาะสำหรับการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ด้วยแผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา เน้นจุดผิดปกติใน Series ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ (ในที่นี้คือ `ChartType.Line`) 
1. เข้าถึงข้อมูลแผนภูมิ IChartDataWorkbook 
1. ล้าง Series และ Category เริ่มต้น 
1. เพิ่ม Series และ Category ใหม่ 
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series 
1. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิเส้น:

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

โดยค่าปกติ จุดในแผนภูมิเส้นจะถูกเชื่อมด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมด้วยเส้นประ ให้กำหนดประเภท dash ที่ต้องการดังนี้:

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **สร้างแผนภูมิเพาแผนที่ (Tree Map Charts)**

แผนภูมิเพาแผนที่เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของประเภทข้อมูลและในเวลาเดียวกันดึงความสนใจไปยังรายการที่เป็นผู้สนับสนุนหลักของแต่ละประเภท

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map ใน Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ (ในที่นี้คือ [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).TreeMap) 
4. เข้าถึงข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook) 
5. ล้าง Series และ Category เริ่มต้น 
6. เพิ่ม Series และ Category ใหม่ 
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series 
8. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Tree Map:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // สาขา 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    // สาขา 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    pres.save("Treemap.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิหุ้น (Stock Charts)**

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิหุ้นใน Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิหุ้น PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิหุ้น PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).OpenHighLowClose) 
4. เข้าถึงข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook) 
5. ล้าง Series และ Category เริ่มต้น 
6. เพิ่ม Series และ Category ใหม่ 
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series 
8. ระบุรูปแบบ HiLowLines 
9. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

ตัวอย่างโค้ด Java สำหรับสร้างแผนภูมิสต็อก:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));

    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 1, 72));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 1, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 1, 38));

    series = chart.getChartData().getSeries().get_Item(1);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 2, 172));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 2, 57));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 2, 57));

    series = chart.getChartData().getSeries().get_Item(2);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 3, 12));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 3, 13));

    series = chart.getChartData().getSeries().get_Item(3);
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 1, 4, 25));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 2, 4, 38));
    series.getDataPoints().addDataPointForStockSeries(wb.getCell(0, 3, 4, 50));

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries ser : chart.getChartData().getSeries())
    {
        ser.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิ Box and Whisker**

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker ใน Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).BoxAndWhisker) 
4. เข้าถึงข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook) 
5. ล้าง Series และ Category เริ่มต้น 
6. เพิ่ม Series และ Category ใหม่ 
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series 
8. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Box and Whisker:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B1", 15));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B2", 41));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B3", 16));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B4", 10));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B5", 23));
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(wb.getCell(0, "B6", 16));

    pres.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิ Funnel**

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel ใน Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).Funnel) 
4. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Funnel:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    wb.clear(0);

    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));

    pres.save("Funnel.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิ Sunburst**

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst ใน Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ (ในที่นี้คือ [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).sunburst) 
4. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Sunburst:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    // สาขา 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    // สาขา 2
    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C5", "Leaf5"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C6", "Leaf6"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C7", "Leaf7"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    chart.getChartData().getCategories().add(wb.getCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    
    pres.save("Sunburst.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิ Histogram**

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram ใน Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).Histogram) 
4. เข้าถึงข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook) 
5. ล้าง Series และ Category เริ่มต้น 
6. เพิ่ม Series และ Category ใหม่ 
7. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Histogram:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
    series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic;)

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิ Radar**

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar ใน Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ (`ChartType.Radar` ในที่นี้) 
4. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Radar:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิหลายประเภท (Multi-Category Charts)**

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category ใน Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ChartType).ClusteredColumn) 
4. เข้าถึงข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook) 
5. ล้าง Series และ Category เริ่มต้น 
6. เพิ่ม Series และ Category ใหม่ 
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series 
8. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Multi Category:

```java
Presentation pres = new Presentation();
try {
    IChart ch = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    
    IChartDataWorkbook fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    int defaultWorksheetIndex = 0;

    IChartCategory category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c3", "B"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c4", "C"));
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c5", "D"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c6", "E"));
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c7", "F"));

    category = ch.getChartData().getCategories().add(fact.getCell(0, "c8", "G"));
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    category = ch.getChartData().getCategories().add(fact.getCell(0, "c9", "H"));

    // เพิ่ม Series
    IChartSeries series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"),
            ChartType.ClusteredColumn);

    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    
    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิแผนที่ (Map Charts)**

แผนภูมิแผนที่เป็นการแสดงผลข้อมูลบนพื้นที่ทางภูมิศาสตร์ เหมาะสำหรับการเปรียบเทียบข้อมูลหรือค่าต่าง ๆ ระหว่างภูมิภาค

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิแผนที่ใน Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิแผนที่ PowerPoint ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิแผนที่ PowerPoint Presentation ใน Java</strong></a>

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิแผนที่:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิผสม (Combination Charts)**

แผนภูมิผสม (หรือ combo chart) รวมประเภทแผนภูมิสองประเภทหรือมากกว่าบนกราฟเดียว ช่วยให้คุณเน้น เสียบเปรียบเทียบ หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อระบุความสัมพันธ์ระหว่างกัน

![The combination chart](combination_chart.png)

โค้ด Java ด้านล่างแสดงวิธีสร้างแผนภูมิผสมที่ปรากฏในภาพข้างต้นในพรีเซนเทชัน PowerPoint:

```java
static void createComboChart() {
    Presentation presentation = new Presentation();
    ISlide slide = presentation.getSlides().get_Item(0);
    try {
        IChart chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

static IChart createChartWithFirstSeries(ISlide slide) {
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // ตั้งค่าชื่อแผนภูมิ.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // ตั้งค่า legend ของแผนภูมิ.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // ลบ series และ categories ที่สร้างโดยอัตโนมัติ.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // เพิ่ม categories ใหม่.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // เพิ่ม series แรก.
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

static void addSecondSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap((byte)-25);
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

static void addThirdSeriesToChart(IChart chart) {
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    final int worksheetIndex = 0;

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

static void setPrimaryAxesFormat(IChart chart) {
    // ตั้งค่าแกนแนวนอน.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // ตั้งค่าแกนแนวตั้ง.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // ตั้งค่าสีของเส้นกริดหลักแนวตั้ง.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // ตั้งค่าแกนแนวนอนรอง.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // ตั้งค่าแกนแนวตั้งรอง.
    IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void setAxisTitle(IAxis axis, String axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    IParagraph titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(12f);
}
```

## **Update Charts**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ PowerPoint ใน Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ Presentation ใน Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ PowerPoint Presentation ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่แสดงพรีเซนเทชันที่มีแผนภูมิที่ต้องการอัปเดต 
2. รับอ้างอิงสไลด์โดยใช้ Index ของมัน 
3. วนผ่านรูปทรงทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ 
4. เข้าถึง worksheet ของข้อมูลแผนภูมิ 
5. แก้ไขข้อมูล Series ของแผนภูมิโดยเปลี่ยนค่าของ Series 
6. เพิ่ม Series ใหม่และเติมข้อมูลลงไป 
7. เขียนพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีอัปเดตแผนภูมิ:

```java
Presentation pres = new Presentation();
try {
    // เข้าถึง slideMarker ตัวแรก
    ISlide sld = pres.getSlides().get_Item(0);

    // ดึงแผนภูมิพร้อมข้อมูลเริ่มต้น
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;

    // ดึง worksheet ของข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // เปลี่ยนชื่อ Category ของแผนภูมิ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // ดึง Series แผนภูมิแรก
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // กำลังอัปเดตข้อมูล Series
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// แก้ไขชื่อ Series
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // ดึง Series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);

    // กำลังอัปเดตข้อมูล Series
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// แก้ไขชื่อ Series
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // ตอนนี้กำลังเพิ่ม Series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // ดึง Series แผนภูมิที่สาม
    series = chart.getChartData().getSeries().get_Item(2);

    // กำลังเติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Set Data Range for a Chart**

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) ที่แสดงพรีเซนเทชันที่มีแผนภูมิ 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. วนผ่านรูปทรงทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ 
4. เข้าถึงข้อมูลแผนภูมิและตั้งค่าช่วงข้อมูล 
5. บันทึกพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX 

โค้ด Java นี้แสดงวิธีกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    
    chart.getChartData().setRange("Sheet1!A1:B4");
    
    pres.save("SetDataRange_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Use Default Markers in Charts**

เมื่อใช้ Marker เริ่มต้นในแผนภูมิแต่ละ Series จะได้รับสัญลักษณ์ Marker เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ด Java นี้แสดงวิธีตั้งค่า Marker ของ Series โดยอัตโนมัติ:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));

    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // ดึง Series แผนภูมิที่สอง
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // กำลังเติมข้อมูลให้ Series
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    pres.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่ Aspose.Slides รองรับ?**

Aspose.Slides รองรับประเภท [chart types](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) อย่างหลากหลาย รวมถึง bar, line, pie, area, scatter, histogram, radar และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับการแสดงข้อมูลของคุณ

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

เพื่อเพิ่มแผนภูมิ ก่อนอื่นให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) แล้วดึงสไลด์ที่ต้องการโดยใช้ดัชนี หลังจากนั้นเรียกเมธอดเพื่อเพิ่มแผนภูมิ โดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะทำให้แผนภูมิเชื่อมต่อโดยตรงกับพรีเซนเทชันของคุณ

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/)) ล้าง Series และ Category เริ่มต้น แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ทำให้แผนภูมิแสดงข้อมูลล่าสุดได้เสมอ

**สามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**

ได้ Aspose.Slides มีตัวเลือกการปรับแต่งอย่างครบถ้วน คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, legend และองค์ประกอบ [formatting elements](/slides/th/java/chart-entities/) อื่น ๆ เพื่อให้แผนภูมิตรงกับความต้องการการออกแบบของคุณ