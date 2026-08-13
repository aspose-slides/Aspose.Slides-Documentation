---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint บน Android
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
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิต้นไม้
- แผนภูมิสต็อค
- แผนภูมิ box and whisker
- แผนภูมิโฟนล
- แผนภูมิ sunburst
- แผนภูมิ histogram
- แผนภูมิเรดาร์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android เพิ่มรูปแบบและแก้ไขแผนภูมิด้วยตัวอย่างโค้ด Java ที่เป็นประโยชน์"
---
## **ภาพรวม**

บทความนี้นำเสนอคำแนะนำอย่างละเอียดเกี่ยวกับการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิเข้าสไลด์โดยอัตโนมัติ เติมข้อมูลลงในแผนภูมิ และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ตัวอย่างโค้ดที่ละเอียดจะอธิบายขั้นตอนแต่ละขั้นจากการเริ่มต้น Presentation และอ็อบเจกต์แผนภูมิ ไปจนถึงการกำหนดซีรีส์, แกน, และตำนาน การทำตามคำแนะนำนี้จะช่วยให้คุณเข้าใจการรวมการสร้างแผนภูมิแบบไดนามิกเข้าไปในแอปพลิเคชันของคุณได้อย่างมั่นคงและทำให้การสร้างงานนำเสนอที่อิงข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**
แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลและได้มุมมองเชิงลึกอย่างรวดเร็ว ซึ่งอาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

การใช้แผนภูมิทำให้คุณสามารถ

* รวมรวม, ย่อ, หรือสรุปข้อมูลจำนวนมากบนสไลด์เดียวในงานนำเสนอ
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ
* ระบุค่าผิดปกติ, ความเบี่ยงเบน, ความคลาดเคลื่อน, ข้อมูลที่ไม่มีเหตุผล ฯลฯ
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อนได้อย่างชัดเจน

ใน PowerPoint คุณสามารถสร้างแผนภูมิได้ผ่านเมนู Insert ซึ่งมีเทมเพลตสำหรับออกแบบแผนภูมิต่าง ๆ ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิมาตรฐาน (จากประเภทแผนภูมิที่นิยม) และแผนภูมิแบบกำหนดเอง

{{% alert color="info" %}} 
เพื่อให้คุณสร้างแผนภูมิได้ Aspose.Slides มีคลาส [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType) ที่กำหนดฟิลด์ต่าง ๆ ตามประเภทแผนภูมิแต่ละแบบ
{{% /alert %}} 

### **สร้างแผนภูมิมาตรฐาน**

_ขั้นตอน: สร้างแผนภูมิ_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Chart ใน Java</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>ขั้นตอน:</em> สร้าง Presentation Chart ใน Java</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Chart ใน Java</strong></a>

_ขั้นตอนโค้ด:_

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใส่ข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ  
4. เพิ่มชื่อเรื่องให้กับแผนภูมิ  
5. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ  
6. ลบซีรีส์และหมวดหมู่เริ่มต้นทั้งหมด  
7. เพิ่มซีรีส์และหมวดหมู่ใหม่  
8. เพิ่มข้อมูลใหม่ให้กับซีรีส์ของแผนภูมิ  
9. กำหนดสีเติมให้กับซีรีส์ของแผนภูมิ  
10. เพิ่มป้ายกำกับให้กับซีรีส์ของแผนภูมิ  
11. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิมาตรฐาน:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้น
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // ตั้งดัชนีสำหรับแผ่นงานข้อมูลของแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // รับแผ่นงานข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    int s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    
    // เพิ่มซีรีส์ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"),chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"),chart.getType());
    
    // เพิ่มหมวดหมู่ใหม่
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // รับซีรีส์แรกของแผนภูมิ
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // ตอนนี้กำลังใส่ข้อมูลให้กับซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // ตั้งค่าสีเติมสำหรับซีรีส์
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // รับซีรีส์ที่สองของแผนภูมิ
    series = chart.getChartData().getSeries().get_Item(1);
    
    // ใส่ข้อมูลให้กับซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // ตั้งค่าสีเติมสำหรับซีรีส์
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
    // ตั้งค่าป้ายกำกับแรกให้แสดงชื่อหัวเรื่อง
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // แสดงค่าในป้ายกำกับที่สาม
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
แผนภูมิแบบกระจาย (หรือ Scatter Plot / X‑Y Graph) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

คุณอาจต้องการใช้แผนภูมิแบบกระจายเมื่อ

* มีข้อมูลเชิงตัวเลขเป็นคู่  
* มีสองตัวแปรที่สัมพันธ์กันอย่างดี  
* ต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่  
* มีตัวแปรอิสระที่มีหลายค่าเชื่อมต่อกับตัวแปรตาม

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>ขั้นตอน:</em> สร้าง Scattered Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Scattered Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Scattered Chart ใน Java</strong></a>

1. ทำตามขั้นตอนใน [Creating Normal Charts](#creating-normal-charts)  
2. ในขั้นตอนที่สาม ให้เพิ่มแผนภูมิโดยใส่ข้อมูลบางส่วนและระบุประเภทแผนภูมิตามต่อไปนี้  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิ Scatter พร้อมเครื่องหมาย_  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นโค้งพร้อมเครื่องหมายข้อมูล_  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นโค้งโดยไม่มีเครื่องหมาย_  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นตรงพร้อมเครื่องหมายข้อมูล_  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นตรงโดยไม่มีเครื่องหมาย_

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิแบบกระจายโดยใช้เครื่องหมายแบบต่าง ๆ:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างแผนภูมิดีฟอลต์
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // รับดัชนีของแผ่นงานข้อมูลแผนภูมิดีฟอลต์
    int defaultWorksheetIndex = 0;
    
    // รับแผ่นงานข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบซีรีส์ตัวอย่าง
    chart.getChartData().getSeries().clear();
    
    // เพิ่มซีรีส์ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    
    // ดึงซีรีส์แรกของแผนภูมิ
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // เพิ่มจุดใหม่ (1:3) ให้กับซีรีส์
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    
    // เพิ่มจุดใหม่ (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    
    // เปลี่ยนประเภทของซีรีส์
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);
    
    // เปลี่ยนสัญลักษณ์ของซีรีส์ในแผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);
    
    // ดึงซีรีส์ที่สองของแผนภูมิ
    series = chart.getChartData().getSeries().get_Item(1);
    
    // เพิ่มจุดใหม่ (5:2) ที่นั่น
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    
    // เพิ่มจุดใหม่ (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    
    // เพิ่มจุดใหม่ (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    
    // เพิ่มจุดใหม่ (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    
    // เปลี่ยนสัญลักษณ์ของซีรีส์ในแผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิวงกลม (Pie)**
แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนรวมของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายกำกับเชิงประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีส่วนหรือป้ายกำกับจำนวนมาก คุณอาจต้องพิจารณาใช้แผนภูมิแท่งแทน

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>ขั้นตอน:</em> สร้าง Pie Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Pie Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Pie Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).Pie)  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับซีรีส์ของแผนภูมิ  
8. เพิ่มจุดข้อมูลใหม่และกำหนดสีเฉพาะสำหรับส่วนต่าง ๆ ของแผนภูมิวงกลม  
9. ตั้งค่าป้ายกำกับให้กับซีรีส์  
10. ตั้งค่าเส้นนำสำหรับป้ายกำกับซีรีส์  
11. ตั้งค่ามุมการหมุนของสไลด์แผนภูมิวงกลม  
12. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิวงกลม:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slides = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้น
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // ตั้งดัชนีสำหรับแผ่นงานข้อมูลของแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // รับแผ่นงานข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // เพิ่มหมวดหมู่ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // เพิ่มซีรีส์ใหม่
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //ใส่ข้อมูลให้กับซีรีส์
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // ไม่ทำงานในเวอร์ชันใหม่
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // ตั้งค่าขอบเขตของเซกเตอร์
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // ตั้งค่าขอบเขตของเซกเตอร์
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // ตั้งค่าขอบเขตของเซกเตอร์
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // สร้างป้ายกำกับกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
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
    
    // แสดงเส้นนำสำหรับแผนภูมิ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    
    // ตั้งค่ามุมการหมุนของเซกเตอร์ในแผนภูมิวงกลม
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิเส้น (Line)**
แผนภูมิเส้น (หรือ Line Graph) เหมาะสำหรับการแสดงการเปลี่ยนแปลงค่าตามเวลา โดยใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากได้พร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, ไฮไลท์ความผิดปกติในซีรีส์ข้อมูล ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
1. ดึงสไลด์โดยอ้างอิงจากดัชนี  
1. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท `ChartType.Line`  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิเส้น:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    pres.save("lineChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

โดยปริยาย จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นขีด คุณสามารถกำหนดประเภทขีดตามนี้ได้:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart lineChart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิต้นไม้ (Tree Map)**
แผนภูมิต้นไม้เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของประเภทข้อมูลและในขณะเดียวกันดึงความสนใจไปยังรายการที่เป็นผู้ร่วมให้ข้อมูลมากที่สุดในแต่ละประเภท

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้าง Tree Map Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Tree Map Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Tree Map Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).TreeMap  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับซีรีส์ของแผนภูมิ  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิต้นไม้:

```java
import com.aspose.slides.*;

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
<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>ขั้นตอน:</em> สร้าง Stock Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Stock Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Stock Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท ([ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).OpenHighLowClose)  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับซีรีส์ของแผนภูมิ  
8. กำหนดรูปแบบ HiLowLines  
9. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

ตัวอย่างโค้ด Java สำหรับสร้างแผนภูมิหุ้น:

```java
import com.aspose.slides.*;

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

### **สร้างแผนภูมิ Box‑and‑Whisker**
<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้าง Box and Whisker Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Box and Whisker Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Box and Whisker Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท ([ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).BoxAndWhisker)  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับซีรีส์ของแผนภูมิ  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Box‑and‑Whisker:

```java
import com.aspose.slides.*;

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
<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>ขั้นตอน:</em> สร้าง Funnel Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Funnel Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Funnel Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท ([ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).Funnel)  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Funnel:

```java
import com.aspose.slides.*;

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
<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้าง Sunburst Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Sunburst Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Sunburst Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท ([ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).sunburst)  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Sunburst:

```java
import com.aspose.slides.*;

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

### **สร้างแผนภูมิ Histogram**
<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>ขั้นตอน:</em> สร้าง Histogram Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Histogram Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Histogram Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท ([ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).Histogram)  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Histogram:

```java
import com.aspose.slides.*;

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

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    pres.save("Histogram.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิ Radar**
<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>ขั้นตอน:</em> สร้าง Radar Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Radar Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Radar Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโด​งใส่ข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ (`ChartType.Radar`)  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิ Radar:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิหลายหมวดหมู่ (Multi‑Category)**
<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้าง Multi Category Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Multi Category Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Multi Category Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. เพิ่มแผนภูมิโดยใช้ข้อมูลเริ่มต้นและระบุประเภท ([ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ChartType).ClusteredColumn)  
4. เข้าถึงข้อมูลแผนภูมิผ่าน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook)  
5. ลบซีรีส์และหมวดหมู่เริ่มต้น  
6. เพิ่มซีรีส์และหมวดหมู่ใหม่  
7. เพิ่มข้อมูลใหม่ให้กับซีรีส์ของแผนภูมิ  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิหลายหมวดหมู่:

```java
import com.aspose.slides.*;

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

    // เพิ่มซีรีส์
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

### **สร้างแผนภูมิแผนที่ (Map)**
แผนภูมิแผนที่เป็นการแสดงผลข้อมูลบนพื้นที่ทางภูมิศาสตร์ เหมาะสำหรับเปรียบเทียบข้อมูลหรือค่าต่าง ๆ ระหว่างเขตพื้นที่

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>ขั้นตอน:</em> สร้าง Map Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Map Chart ใน Java</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>ขั้นตอน:</em> สร้าง PowerPoint Presentation Map Chart ใน Java</strong></a>

โค้ด Java นี้แสดงวิธีสร้างแผนภูมิแผนที่:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้างแผนภูมิแบบผสม (Combination)**
แผนภูมิแบบผสม (หรือ Combo Chart) รวมประเภทแผนภูมิสองประเภทหรือมากกว่าบนกราฟเดียว ช่วยให้คุณเน้น, เปรียบเทียบ หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อค้นหาความสัมพันธ์ระหว่างข้อมูล

![แผนภูมิแบบผสม](combination_chart.png)

โค้ด Java ด้านล่างแสดงวิธีสร้างแผนภูมิแบบผสมตามที่แสดงในรูปข้างต้นใน PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    IParagraph titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    IPortionFormat titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(NullableBool.False);
    titleFormat.setFontHeight(18f);

    // ตั้งค่าตำนานแผนภูมิ.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติเริ่มต้น.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // เพิ่มหมวดหมู่ใหม่.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // เพิ่มซีรีส์แรก.
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

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>ขั้นตอน:</em> อัปเดต PowerPoint Chart ใน Java</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดต Presentation Chart ใน Java</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดต PowerPoint Presentation Chart ใน Java</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิที่ต้องการอัปเดต  
2. ดึงอ้างอิงสไลด์โดยใช้ Index  
3. วนลูปผ่านรูปร่างทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ  
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ  
5. แก้ไขข้อมูลซีรีส์ของแผนภูมิโดยเปลี่ยนค่าซีรีส์  
6. เพิ่มซีรีส์ใหม่และใส่ข้อมูลในนั้น  
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีอัปเดตแผนภูมิ:

```java
import com.aspose.slides.*;

// เปิด presentation ที่มีแผนภูมิต้องการอัปเดต
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // ดึงแผนภูมิจากสไลด์
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // กำหนดดัชนีของแผ่นข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;

    // รับแผ่นงานข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // เปลี่ยนชื่อหมวดหมู่ของแผนภูมิ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // ดึงซีรีส์แรกของแผนภูมิ
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // อัปเดตข้อมูลซีรีส์ในขณะนี้
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// กำลังแก้ไขชื่อซีรีส์
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // ดึงซีรีส์ที่สองของแผนภูมิ
    series = chart.getChartData().getSeries().get_Item(1);

    // อัปเดตข้อมูลซีรีส์ในขณะนี้
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// กำลังแก้ไขชื่อซีรีส์
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // กำลังเพิ่มซีรีส์ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // ดึงซีรีส์ที่สามของแผนภูมิ
    series = chart.getChartData().getSeries().get_Item(2);

    // กำลังใส่ข้อมูลให้กับซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // บันทึก presentation พร้อมแผนภูมิ
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิ  
2. ดึงสไลด์โดยอ้างอิงจากดัชนี  
3. วนลูปผ่านรูปร่างทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ  
4. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วงข้อมูล  
5. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Java นี้แสดงวิธีกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```java
import com.aspose.slides.*;

// เปิด presentation ที่มีแผนภูมิ
Presentation pres = new Presentation("ExistingChart.pptx");
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
เมื่อใช้เครื่องหมายเริ่มต้นในแผนภูมิแต่ละซีรีส์จะได้รับสัญลักษณ์เครื่องหมายเริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ด Java นี้แสดงวิธีตั้งค่าเครื่องหมายซีรีส์ของแผนภูมิโดยอัตโนมัติ:

```java
import com.aspose.slides.*;

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
    //ดึงซีรีส์ที่สองของแผนภูมิ
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    //กำลังใส่ข้อมูลให้กับซีรีส์
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

## **คำถามที่พบบ่อย (FAQ)**

### Aspose.Slides รองรับประเภทแผนภูมิใดบ้าง?

Aspose.Slides รองรับประเภทแผนภูมิจำนวนมาก [chart types](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) รวมถึงแผนภูมิบาร์, เส้น, วงกลม, พื้นที่, กระจาย, histogram, radar และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับการแสดงผลข้อมูลของคุณ

### วิธีการเพิ่มแผนภูมิใหม่ลงในสไลด์คืออะไร?

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) จากนั้นเรียกใช้สไลด์ที่ต้องการโดยอ้างอิงจากดัชนี และเรียกเมธอดเพื่อเพิ่มแผนภูมิ พร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะฝังแผนภูมิโดยตรงเข้าสู่งานนำเสนอของคุณ

### วิธีการอัปเดตข้อมูลที่แสดงในแผนภูมิทำได้อย่างไร?

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)) ลบซีรีส์และหมวดหมู่เริ่มต้น แล้วเพิ่มข้อมูลที่กำหนดเองของคุณเอง วิธีนี้ช่วยให้คุณรีเฟรชแผนภูมิให้สอดคล้องกับข้อมูลล่าสุด

### สามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?

ใช่ Aspose.Slides มีตัวเลือกการปรับแต่งที่ครอบคลุม คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, ตำนาน, และองค์ประกอบการจัดรูปแบบอื่น ๆ [/slides/th/androidjava/chart-entities/] เพื่อให้แผนภูมิของคุณตรงกับความต้องการการออกแบบเฉพาะของคุณ