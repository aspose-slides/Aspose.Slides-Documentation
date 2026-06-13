---
title: สร้างหรืออัปเดตแผนภูมืองานนำเสนอ PowerPoint บน Android
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/androidjava/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิกล่อง
- แผนภูมิเส้น
- แผนภูมิแผนที่ต้นไม้
- แผนภูมิสต็อก
- แผนภูมิกล่องและหนวดยาว
- แผนภูมิกรวย
- แผนภูมิดอกลอย
- แผนภูมิฮิสโตแกรม
- แผนภูมิกว้าง
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android เพิ่มรูปแบบและแก้ไขแผนภูมิด้วยตัวอย่างโค้ด Java ที่ใช้งานจริง"
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างละเอียดเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์แบบโปรแกรมมิง เติมข้อมูลลงในแผนภูมิ และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ทั้งหมดนี้มีตัวอย่างโค้ดที่อธิบายขั้นตอนตั้งแต่การเริ่มต้นอ็อบเจกต์ Presentation และ Chart ไปจนถึงการกำหนด Series, Axis และ Legend ด้วยการทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีการผสานการสร้างแผนภูมิแบบไดนามิกเข้ากับแอปพลิเคชันของคุณ ทำให้การสร้างงานนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**
แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อสรุปที่อาจมองไม่เห็นจากตารางหรือสเปรดชีต  

**ทำไมต้องสร้างแผนภูมิ?**

ด้วยแผนภูมิคุณสามารถ  

* รวม ย่อหรือสรุปข้อมูลจำนวนมากในสไลด์เดียวของงานนำเสนอ  
* แสดงรูปแบบและแนวโน้มของข้อมูล  
* วิเคราะห์ทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ  
* ระบุค่าผิดปกติ ค่าที่บิดเบือน ความเบี่ยงเบน ความผิดพลาด หรือข้อมูลที่ไม่มีความหมาย  
* สื่อหรือแสดงข้อมูลที่ซับซ้อนได้อย่างชัดเจน  

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านเมนู Insert ซึ่งให้เท็มเพลตสำหรับออกแบบแผนภูมิหลายประเภท ใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิที่นิยม) และแผนภูมิแบบกำหนดเองได้  

{{% alert color="primary" %}}  

เพื่อให้คุณสามารถสร้างแผนภูมิได้ Aspose.Slides มีคลาส [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType) ฟิลด์ต่าง ๆ ภายในคลาสนี้สอดคล้องกับประเภทแผนภูมิแต่ละแบบ  

{{% /alert %}}  

### **สร้างแผนภูมิปกติ**

_ขั้นตอน: Create Chart_  
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>Steps:</em> Create PowerPoint Chart in Java</strong></a>  
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>Steps:</em> Create Presentation Chart in Java</strong></a>  
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Chart in Java</strong></a>  

_Code Steps:_  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและกำหนดประเภทแผนภูมิตามที่ต้องการ  
4. เพิ่มหัวเรื่องให้กับแผนภูมิ  
5. เข้าถึง Worksheet ของข้อมูลแผนภูมิ  
6. ลบ Series และ Category เริ่มต้นทั้งหมด  
7. เพิ่ม Series และ Category ใหม่  
8. เพิ่มข้อมูลใหม่ให้กับ Series ของแผนภูมิ  
9. เพิ่มสีเติมสำหรับ Series ของแผนภูมิ  
10. เพิ่มป้ายกำกับสำหรับ Series ของแผนภูมิ  
11. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีการสร้างแผนภูมิปกติ:  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
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
    
    // ตั้งค่า Series แรกให้แสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // ตั้งค่าดัชนีของแผ่นงานข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // รับแผ่นงานข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น
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
    
    // ตอนนี้กำลังใส่ข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // ตั้งค่าสีเติมสำหรับ Series
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // ดึง Series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    
    // ใส่ข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ตั้งค่าสีเติมสำหรับ Series นี้
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละ Category ของ Series ใหม่
    // ตั้งค่าป้ายแรกให้แสดงชื่อ Category
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // แสดงค่าในป้ายที่สาม
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิแบบกระจาย (Scatter)**  
แผนภูมิแบบกระจาย (หรือ scatter plot, x‑y graph) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร  

คุณอาจต้องการใช้แผนภูมิแบบกระจายเมื่อ  

* มีข้อมูลตัวเลขเป็นคู่  
* มีสองตัวแปรที่สัมพันธ์กันดี  
* ต้องการตรวจสอบว่าตัวแปรสองตัวเกี่ยวข้องกันหรือไม่  
* มีตัวแปรอิสระที่มีค่าหลายค่าเพื่ออ้างอิงตัวแปรตาม  

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>Steps:</em> Create Scattered Chart in Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Scattered Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Scattered Chart in Java</strong></a>  

1. โปรดทำตามขั้นตอนในส่วน [Creating Normal Charts](#creating-normal-charts)  
2. สำหรับขั้นตอนที่สาม ให้เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและกำหนดประเภทแผนภูมิเป็นหนึ่งในต่อไปนี้  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิกระจายพร้อมเครื่องหมาย_  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิกระจายเชื่อมด้วยเส้นโค้งพร้อมเครื่องหมาย_  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิกระจายเชื่อมด้วยเส้นโค้งโดยไม่มีเครื่องหมาย_  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิกระจายเชื่อมด้วยเส้นตรงพร้อมเครื่องหมาย_  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิกระจายเชื่อมด้วยเส้นตรงโดยไม่มีเครื่องหมาย_  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิกระจายด้วยชุดเครื่องหมายต่าง ๆ:  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างแผนภูมิดีฟอลต์
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // รับดัชนีของ worksheet ข้อมูลแผนภูมิดีฟอลต์
    int defaultWorksheetIndex = 0;
    
    // รับ worksheet ข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบ Series ตัวอย่าง
    chart.getChartData().getSeries().clear();
    
    // เพิ่ม Series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // ดึง Series แผนภูมิเก็บตัวแรก
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // เพิ่มจุดใหม่ (1:3) ให้กับ Series
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // เพิ่มจุดใหม่ (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // เปลี่ยนประเภท Series
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // เปลี่ยน Marker ของ Series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // ดึง Series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    
    // เพิ่มจุดใหม่ (5:2) ที่นั่น
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // เพิ่มจุดใหม่ (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // เพิ่มจุดใหม่ (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // เพิ่มจุดใหม่ (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // เปลี่ยน Marker ของ Series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิวงกลม (Pie)**  

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนทั้งหมดของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายแบบหมวดหมู่และค่าตัวเลข หากข้อมูลของคุณมีหลายส่วนหรือหลายป้าย คุณอาจพิจารณาใช้แผนภูมิบาร์แทน  

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>Steps:</em> Create Pie Chart in Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>Steps:</em> Create PowerPoint Pie Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Pie Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมประเภทที่ต้องการ (ในกรณีนี้คือ [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).Pie)  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบ Series และ Category เริ่มต้น  
6. เพิ่ม Series และ Category ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับ Series ของแผนภูมิ  
8. เพิ่มจุดข้อมูลใหม่และกำหนดสีกำหนดเองให้กับส่วนของแผนภูมิกล้าบับ  
9. ตั้งค่าป้ายกำกับสำหรับ Series  
10. ตั้งค่าเส้นนำสำหรับป้ายกำกับ Series  
11. ตั้งค่ามุมการหมุนของสไลด์แผนภูมิกล้อ  
12. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีการสร้างแผนภูมิกล้อ:  

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slides = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // ตั้งค่าชื่อแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // ตั้งค่า Series แรกให้แสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    // ตั้งค่าดัชนีของแผ่นงานข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // รับแผ่นงานข้อมูลแผนภูมิ
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
    
    // ใส่ข้อมูลให้ Series
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // ไม่ทำงานในเวอร์ชันใหม่
    // เพิ่มจุดใหม่และกำหนดสีของส่วน
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // ตั้งค่าขอบของ Sector
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // ตั้งค่าขอบของ Sector
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // ตั้งค่าขอบของ Sector
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละ Category ของ Series ใหม่
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
    
    // ตั้งค่ามุมการหมุนของส่วนแผนภูมิกล้อ
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิเส้น (Line)**  

แผนภูมิเส้น (หรือ line graph) เหมาะสำหรับแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาเปลี่ยนไป ด้วยแผนภูมิเส้น คุณสามารถเปรียบเทียบข้อมูลหลายชุดได้พร้อมกัน ติดตามแนวโน้มและการเปลี่ยนแปลงตามเวลา ไฮไลท์ความผิดปกติในชุดข้อมูล ฯลฯ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น `ChartType.Line`  
1. เข้าถึงข้อมูลแผนภูมิ IChartDataWorkbook  
1. ลบ Series และ Category เริ่มต้น  
1. เพิ่ม Series และ Category ใหม่  
1. เพิ่มข้อมูลใหม่ให้กับ Series ของแผนภูมิ  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีการสร้างแผนภูมิเส้น:  

```java
Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นประ สามารถกำหนดประเภทเส้นประได้ดังนี้:  

```java
IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

for (IChartSeries series : lineChart.getChartData().getSeries())
{
    series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
}
```

### **สร้างแผนภูมิโครงสร้างต้นไม้ (Tree Map)**  

แผนภูมิโครงสร้างต้นไม้เหมาะกับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและในเวลาเดียวกันดึงความสนใจไปยังรายการที่เป็นผู้ร่วมให้ข้อมูลจำนวนมากในแต่ละหมวดหมู่  

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>Steps:</em> Create Tree Map Chart in Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Tree Map Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Tree Map Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).TreeMap  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบ Series และ Category เริ่มต้น  
6. เพิ่ม Series และ Category ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับ Series ของแผนภูมิ  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิโครงสร้างต้นไม้:  

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //สาขา 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //สาขา 2
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

### **สร้างแผนภูมิหุ้น (Stock)**  

<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>Steps:</em> Create Stock Chart in Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>Steps:</em> Create PowerPoint Stock Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Stock Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).OpenHighLowClose  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบ Series และ Category เริ่มต้น  
6. เพิ่ม Series และ Category ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับ Series ของแผนภูมิ  
8. กำหนดรูปแบบ HiLowLines  
9. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java ตัวอย่างสำหรับสร้างแผนภูมิเหมือนหุ้น:  

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

### **สร้างแผนภูมิกล่องและหนวดยาว (Box and Whisker)**  

<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>Steps:</em> Create Box and Whisker Chart in Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Box and Whisker Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Box and Whisker Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).BoxAndWhisker  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบ Series และ Category เริ่มต้น  
6. เพิ่ม Series และ Category ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับ Series ของแผนภูมิ  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิกล่องและหนวดยาว:  

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

### **สร้างแผนภูมิกรวย (Funnel)**  

<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>Steps:</em> Create Funnel Chart in Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Funnel Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Funnel Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).Funnel  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิกรวย:  

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

### **สร้างแผนภูมิดอกลอย (Sunburst)**  

<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>Steps:</em> Create Sunburst Chart in Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Sunburst Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Sunburst Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).sunburst  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิดอกลอย:  

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);

    //สาขา 1
    IChartCategory leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    chart.getChartData().getCategories().add(wb.getCell(0, "C2", "Leaf2"));

    leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C3", "Leaf3"));
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    chart.getChartData().getCategories().add(wb.getCell(0, "C4", "Leaf4"));

    //สาขา 2
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

### **สร้างแผนภูมิฮิสโตแกรม (Histogram)**  

<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>Steps:</em> Create Histogram Chart in Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Histogram Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Histogram Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).Histogram  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบ Series และ Category เริ่มต้น  
6. เพิ่ม Series และ Category ใหม่  
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิบางส่วนแบบฮิสโตแกรม:  

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

### **สร้างแผนภูมิกว้าง (Radar)**  

<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>Steps:</em> Create Radar Chart in Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>Steps:</em> Create PowerPoint Radar Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Radar Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลบางส่วนและกำหนดประเภทเป็น `ChartType.Radar`  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิกว้าง:  

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิหลายหมวดหมู่ (Multi‑Category)**  

<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>Steps:</em> Create Multi Category Chart in Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Multi Category Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Multi Category Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทเป็น [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).ClusteredColumn  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบ Series และ Category เริ่มต้น  
6. เพิ่ม Series และ Category ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับ Series ของแผนภูมิ  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิหลายหมวดหมู่:  

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
    
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิจัดแผนที่ (Map)**  

แผนภูมิจัดแผนที่เป็นการแสดงภาพของพื้นที่พร้อมข้อมูล แผนภูมินี้เหมาะกับการเปรียบเทียบข้อมูลหรือค่าต่าง ๆ ระหว่างภูมิภาค  

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>Steps:</em> Create Map Chart in Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>Steps:</em> Create PowerPoint Map Chart in Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>Steps:</em> Create PowerPoint Presentation Map Chart in Java</strong></a>  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิจัดแผนที่:  

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิผสม (Combination)**  

แผนภูมิผสม (หรือ combo chart) นำสองหรือหลายประเภทแผนภูมิมารวมกันในกราฟเดียว ช่วยให้คุณเน้นเปรียบเทียบ หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุดได้ง่ายขึ้น  

![The combination chart](combination_chart.png)

โค้ด Java ด้านล่างแสดงวิธีสร้างแผนภูมิผสมตามภาพด้านบนใน PowerPoint:  

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

    // ตั้งค่าตัวอักษรอธิบายของแผนภูมิ.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // เพิ่ม Category ใหม่.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // เพิ่ม Series แรก.
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

## **อัปเดตแผนภูมิ**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>Steps:</em> Update PowerPoint Chart in Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>Steps:</em> Update Presentation Chart in Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>Steps:</em> Update PowerPoint Presentation Chart in Java</strong></a>  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิที่ต้องการอัปเดต  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. วนลูปตรวจสอบทุก Shape เพื่อค้นหาแผนภูมิที่ต้องการ  
4. เข้าถึง Worksheet ของข้อมูลแผนภูมิ  
5. แก้ไขข้อมูล Series ของแผนภูมิโดยเปลี่ยนค่าของ Series  
6. เพิ่ม Series ใหม่และใส่ข้อมูลลงในนั้น  
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีอัปเดตแผนภูมิ:  

```java
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // ดึงแผนภูมิกับข้อมูลเริ่มต้น
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;

    // ดึง Worksheet ของข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // เปลี่ยนชื่อ Category ของแผนภูมิ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // ดึง Series แผนภูมันดับแรก
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // ตอนนี้กำลังอัปเดตข้อมูล Series
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// แก้ไขชื่อตัว Series
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // ดึง Series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);

    // ตอนนี้กำลังอัปเดตข้อมูล Series
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// แก้ไขชื่อตัว Series
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // ตอนนี้กำลังเพิ่ม Series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // ดึง Series แผนภูมิที่สาม
    series = chart.getChartData().getSeries().get_Item(2);

    // ตอนนี้กำลังใส่ข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดช่วงข้อมูลให้กับแผนภูมิ**

ขั้นตอนการกำหนดช่วงข้อมูลให้กับแผนภูมิ:  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิ  
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน  
3. วนลูปตรวจสอบทุก Shape เพื่อค้นหาแผนภูมิที่ต้องการ  
4. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วงข้อมูล  
5. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีกำหนดช่วงข้อมูลให้กับแผนภูมิ:  

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

## **ใช้เครื่องหมายเริ่มต้นในแผนภูมิ**
เมื่อใช้เครื่องหมายเริ่มต้นในแผนภูมิ แต่ละ Series จะได้รับสัญลักษณ์เครื่องหมายเริ่มต้นที่แตกต่างกันโดยอัตโนมัติ  

โค้ด Java นี้แสดงวิธีตั้งค่าเครื่องหมาย Series ของแผนภูมิโดยอัตโนมัติ:  

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

    // ตอนนี้กำลังใส่ข้อมูลให้ Series
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

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับประเภทแผนภูมิใดบ้าง?**  

Aspose.Slides รองรับประเภทแผนภูมิหลากหลายประเภทที่ระบุใน [chart types](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) เช่น bar, line, pie, area, scatter, histogram, radar และอื่น ๆ อีกมาก ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณได้ง่าย

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**  

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ดึงสไลด์ที่ต้องการโดยใช้ดัชนี แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิโดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น วิธีนี้จะผสานแผนภูมิเข้าไปในงานนำเสนอโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**  

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง Workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)) ลบ Series และ Category เริ่มต้น แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ ซึ่งจะทำให้แผนภูมิแสดงข้อมูลล่าสุดได้

**สามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**  

ได้ Aspose.Slides มีตัวเลือกการปรับแต่งที่ครอบคลุม คุณสามารถแก้ไขสี ฟอนต์ ป้ายกำกับ Legend และองค์ประกอบการจัดรูปแบบอื่น ๆ (/slides/th/androidjava/chart-entities/) เพื่อให้แผนภูมิตรงตามข้อกำหนดการออกแบบของคุณ.