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
- แผนภูมิแผนที่ต้นไม้
- แผนภูมิสต็อก
- แผนภูมิกล่องและหนวด
- แผนภูมิน้ำพุ
- แผนภูมิระเบิดดวงอาทิตย์
- แผนภูมิฮิสโตแกรม
- แผนภูมิกระจายศูนย์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Android เพิ่ม แก้ไขรูปแบบ และแก้ไขแผนภูมิด้วยตัวอย่างโค้ด Java ที่ใช้งานได้จริง"
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำที่ครอบคลุมเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยเขียนโปรแกรม, เติมข้อมูลให้กับแผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ทั้งหมดนี้จะมีตัวอย่างโค้ดที่แสดงขั้นตอนต่าง ๆ ตั้งแต่การสร้าง Presentation และอ็อบเจ็กต์แผนภูมิ, การกำหนดค่าซีรีส์, แกนอธิบาย, และตำนาน การทำตามคู่มือนี้จะทำให้คุณเข้าใจวิธีรวมการสร้างแผนภูมิกระ动态เข้ากับแอปพลิเคชันของคุณได้อย่างมั่นใจ, ช่วยให้การสร้างงานนำเสนอที่ใช้ข้อมูลเป็นพื้นฐานเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลอย่างรวดเร็วและสรุปข้อมูลเชิงลึกที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

โดยใช้แผนภูมิ คุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากในสไลด์เดียวของงานนำเสนอ
* แสดงรูปแบบและแนวโน้มของข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดที่กำหนด
* ค้นหาค่าผิดปกติ, ความบิดเบือน, ความเบี่ยงเบน, ความผิดพลาด, ข้อมูลที่ไม่มีเหตุผล ฯลฯ
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิได้ผ่านฟังก์ชัน *Insert* ซึ่งให้เทมเพลตสำหรับการออกแบบหลายประเภทของแผนภูมิ โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิทั่วไป (ตามประเภทแผนภูมิยอดนิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="หมายเหตุ" %}}
เพื่อสร้างแผนภูมิ ใช้คลาส [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) ฟิลด์ในคลาสนี้สอดคล้องกับประเภทแผนภูมิที่ต่างกัน
{{% /alert %}}

### **สร้าง Clustered Column Charts**

ส่วนนี้อธิบายวิธีสร้าง clustered column chart ด้วย Aspose.Slides คุณจะได้เรียนรู้การเริ่มต้น Presentation, เพิ่มแผนภูมิ, และปรับแต่งองค์ประกอบต่าง ๆ เช่น ชื่อเรื่อง, ข้อมูล, ซีรีส์, หมวดหมู่, และการจัดรูปแบบ ทำตามขั้นตอนด้านล่างเพื่อดูว่าการสร้าง clustered column chart มาตรฐานทำอย่างไร:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภท `ChartType.ClusteredColumn`
1. เพิ่มชื่อเรื่องให้กับแผนภูมิ
1. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ
1. ลบซีรีส์และหมวดหมู่เริ่มต้นทั้งหมด
1. เพิ่มซีรีส์และหมวดหมู่ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์
1. กำหนดสีเติมให้กับซีรีส์ของแผนภูมิ
1. เพิ่มป้ายชื่อให้กับซีรีส์ของแผนภูมิ
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด C# นี้แสดงวิธีสร้าง clustered column chart:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิกับข้อมูลเริ่มต้นของมัน
    IChart chart = sld.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500);
    
    // กำหนดชื่อเรื่องของแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // กำหนดดัชนีสำหรับแผ่นข้อมูลของแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // ดึง WorkSheet ข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น
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
    
    // ดึงซีรีส์แรกของแผนภูมิ
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // ตอนนี้เติมข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // กำหนดสีเติมสำหรับซีรีส์
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    
    // ดึงซีรีส์ที่สองของแผนภูมิ
    series = chart.getChartData().getSeries().get_Item(1);
    
    // เติมข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // กำหนดสีเติมสำหรับซีรีส์
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN);
    
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
    // กำหนดให้ป้ายแรกแสดงชื่อหมวดหมู่
    IDataLabel lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    
    // แสดงค่าในป้ายที่สาม
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    
    // บันทึกการนำเสนอพร้อมแผนภูมิ
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้าง Scatter Charts**

Scatter chart (หรือ scatter plot, x‑y graph) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

ใช้ scatter chart เมื่อ:

* คุณมีข้อมูลเชิงตัวเลขเป็นคู่
* คุณมีสองตัวแปรที่จับคู่กันได้ดี
* คุณต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่
* คุณมีตัวแปรอิสระที่มีค่าหลายค่าเพื่อเป็นตัวแปรตาม

1. ทำตามขั้นตอนใน [Create Clustered Column Charts](#create-clustered-column-charts)
2. ในขั้นตอนที่สาม ให้เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภทแผนภูมิเป็นหนึ่งในต่อไปนี้:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithMarkers) - _Represents a scatter chart._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Represents a scatter chart connected by curves, with data markers._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithSmoothLines) - _Represents a scatter chart connected by curves, without data markers._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Represents a scatter chart connected by lines, with data markers._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ScatterWithStraightLines) - _Represents a scatter chart connected by lines, without data markers._

โค้ด Java นี้แสดงวิธีสร้าง scatter chart พร้อมเครื่องหมายที่แตกต่างกันสำหรับแต่ละซีรีส์:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // สร้างแผนภูมิเริ่มต้น
    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    
    // ดึงดัชนีของเวิร์กชีตข้อมูลแผนภูมิเริ่มต้น
    int defaultWorksheetIndex = 0;
    
    // ดึงเวิร์กชีตข้อมูลของแผนภูมิ
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
    
    // เปลี่ยนมาร์คเกอร์ของซีรีส์แผนภูมิ
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
    
    // เปลี่ยนมาร์คเกอร์ของซีรีส์แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);
    
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้าง Pie Charts**

Pie chart เหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายชื่อแบบหมวดหมู่พร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือป้ายชื่อจำนวนมาก คุณอาจพิจารณาใช้ bar chart แทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Pie](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#Pie)
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)
5. ลบซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์
8. เพิ่มจุดใหม่สำหรับแผนภูมิและกำหนดสีที่กำหนดเองสำหรับส่วนของ pie chart
9. ตั้งค่าป้ายชื่อสำหรับซีรีส์
10. เปิดใช้งานเส้นนำสำหรับป้ายชื่อของซีรีส์
11. ตั้งค่ามุมการหมุนสำหรับส่วนของ pie chart
12. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง pie chart:

```java
import com.aspose.slides.*;
import java.awt.Color;

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slides = pres.getSlides().get_Item(0);
    
    // เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
    IChart chart = slides.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);
    
    // กำหนดชื่อเรื่องของแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    
    // กำหนดดัชนีสำหรับแผ่นข้อมูลของแผนภูมิ
    int defaultWorksheetIndex = 0;
    
    // ดึงแผ่นงานข้อมูลของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    
    // เพิ่มหมวดหมู่ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    
    // เพิ่มซีรีส์ใหม่
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    
    //เติมข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    
    // ไม่ทำงานในเวอร์ชันใหม่
    // เพิ่มจุดใหม่และตั้งค่าสีของส่วน
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    
    IChartDataPoint point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);
	
    // กำหนดเส้นขอบของส่วน
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot);
    
    IChartDataPoint point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(FillType.Solid);
    point1.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);
    
    // กำหนดเส้นขอบของส่วน
    point1.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);
    
    IChartDataPoint point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(FillType.Solid);
    point2.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW);
    
    // กำหนดเส้นขอบของส่วน
    point2.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);
    
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่
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
    
    // กำหนดมุมการหมุนสำหรับส่วนของแผนภูม้วงกลม
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    
    // บันทึกการนำเสนอพร้อมแผนภูมิ
    pres.save("PieChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้าง Line Charts**

Line chart (หรือ line graph) เหมาะสำหรับสถานการณ์ที่คุณต้องการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ด้วย line chart คุณสามารถเปรียบเทียบข้อมูลจำนวนมากในครั้งเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล, ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Line](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#Line)
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง line chart:

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

โดยค่าเริ่มต้น จุดบน line chart จะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นประ สามารถระบุประเภท dash ที่ต้องการได้ดังนี้:

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

### **สร้าง Tree Map Charts**

Tree map chart เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้สนับสนุนใหญ่ภายในแต่ละหมวดหมู่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Treemap](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#Treemap)
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)
5. ลบซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง tree map chart:

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

### **สร้าง Stock Charts**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#OpenHighLowClose)
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)
5. ลบซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์
8. กำหนดรูปแบบเส้น high‑low
9. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง stock chart:

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

### **สร้าง Box and Whisker Charts**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#BoxAndWhisker)
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)
5. ลบซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง box and whisker chart:

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

### **สร้าง Funnel Charts**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Funnel](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#Funnel)
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง funnel chart:

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

### **สร้าง Sunburst Charts**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Sunburst](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#Sunburst)
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง sunburst chart:

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

### **สร้าง Histogram Charts**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Histogram](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#Histogram)
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)
5. ลบซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง histogram chart:

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

### **สร้าง Radar Charts**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ ([ChartType.Radar](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#Radar) ในกรณีนี้)
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง radar chart:

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

### **สร้าง Multi-Category Charts**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.ClusteredColumn](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/#ClusteredColumn)
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)
5. ลบซีรีส์และหมวดหมู่เริ่มต้น
6. เพิ่มซีรีส์และหมวดหมู่ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับซีรีส์
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีสร้าง multi‑category chart:

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
    
    // บันทึกการนำเสนอพร้อมแผนภูมิ
    pres.save("AsposeChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **สร้าง Map Charts**

Map chart แสดงข้อมูลเชิงภูมิศาสตร์และช่วยเปรียบเทียบค่าต่าง ๆ ระหว่างภูมิภาค

โค้ด Java นี้แสดงวิธีสร้าง map chart:

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

### **สร้าง Combination Charts**

Combination chart (หรือ combo chart) รวมสองประเภทแผนภูมิหรือมากกว่าลงในกราฟเดียว ช่วยให้คุณไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อระบุความสัมพันธ์ระหว่างข้อมูลเหล่านั้น

![แผนภูมิแบบผสม](combination_chart.png)

โค้ด Java ต่อไปนี้แสดงวิธีสร้าง combination chart ที่แสดงในภาพข้างต้นใน PowerPoint presentation:

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

    // ตั้งค่าตำนานของแผนภูมิ.
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น.
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
    // ตั้งค่าแกนนอน.
    IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(horizontalAxis, "X Axis");

    // ตั้งค่าแกนตั้ง.
    IAxis verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    setAxisTitle(verticalAxis, "Y Axis 1");

    // ตั้งค่าสีของเส้นกริดหลักแกนตั้ง.
    ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(FillType.Solid);
    majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
}

static void setSecondaryAxesFormat(IChart chart) {
    // ตั้งค่าแกนนอนรอง.
    IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    // ตั้งค่าแกนตั้งรอง.
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่เป็นงานนำเสนอที่มีแผนภูมิที่ต้องการอัปเดต
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. วนลูปผ่านรูปร่างทั้งหมดเพื่อค้นหาแผนภูมาที่ต้องการ
4. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ
5. แก้ไขซีรีส์ของแผนภูมิโดยเปลี่ยนค่าของซีรีส์
6. เพิ่มซีรีส์ใหม่และเติมข้อมูลให้กับมัน
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีอัปเดตแผนภูมิ:

```java
import com.aspose.slides.*;

// เปิดไฟล์ Presentation ที่มีแผนภูมิต้องการอัปเดต
Presentation pres = new Presentation("ExistingChart.pptx");
try {
    // เข้าถึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // ดึงแผนภูมิจากสไลด์
    IChart chart = (IChart)sld.getShapes().get_Item(0);

    // กำหนดดัชนีของแผ่นข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;

    // ดึง worksheet ของข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // เปลี่ยนชื่อหมวดหมู่ของแผนภูมิ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");

    // ดึงซีรีส์แรกของแผนภูมิ
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // ตอนนี้กำลังอัปเดตข้อมูลซีรีส์
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // แก้ไขชื่อซีรีส์
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);

    // ดึงซีรีส์ที่สองของแผนภูมิ
    series = chart.getChartData().getSeries().get_Item(1);

    // ตอนนี้กำลังอัปเดตข้อมูลซีรีส์
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // แก้ไขชื่อซีรีส์
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);

    // ตอนนี้เพิ่มซีรีส์ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());

    // ดึงซีรีส์ที่สามของแผนภูมิ
    series = chart.getChartData().getSeries().get_Item(2);

    // ตอนนี้กำลังเติมข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));

    chart.setType(ChartType.ClusteredCylinder);

    // บันทึก Presentation พร้อมแผนภูมิ
    pres.save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) ที่เป็นงานนำเสนอที่มีแผนภูมินั้น
2. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. วนลูปผ่านรูปร่างทั้งหมดเพื่อค้นหาแผนภูมาที่ต้องการ
4. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วง
5. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```java
import com.aspose.slides.*;

// เปิดไฟล์ Presentation ที่มีแผนภูมิ
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

## **ใช้ Default Markers ในแผนภูมิ**

เมื่อใช้ default markers ในแผนภูมิแต่ละซีรีส์ของแผนภูมิจะได้รับสัญลักษณ์ marker ที่แตกต่างกันโดยอัตโนมัติ

โค้ด Java นี้แสดงวิธีตั้งค่า marker ของซีรีส์แผนภูมิโดยอัตโนมัติ:

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
    // ดึงซีรีส์ที่สองของแผนภูมิ
    IChartSeries series2 = chart.getChartData().getSeries().get_Item(1);

    // ตอนนี้กำลังเติมข้อมูลให้ซีรีส์
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

Aspose.Slides รองรับประเภท [chart types](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) จำนวนมาก รวมถึง bar, line, pie, area, scatter, histogram, radar และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับการแสดงผลข้อมูลของคุณ

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/), ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, จากนั้นเรียกเมธอดเพื่อเพิ่มแผนภูมิ ระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะฝังแผนภูมิโดยตรงเข้าไปในงานนำเสนอของคุณ

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูลแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/)), ลบซีรีส์และหมวดหมู่เริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ทำให้คุณรีเฟรชแผนภูมิเพื่อสะท้อนข้อมูลล่าสุด

**ฉันสามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides มีตัวเลือกการปรับแต่งหลากหลาย คุณสามารถเปลี่ยนสี, ฟอนต์, ป้ายชื่อ, ตำนาน, และ [องค์ประกอบการจัดรูปแบบ](/slides/th/androidjava/chart-entities/) อื่น ๆ เพื่อให้แผนภูมิสอดคล้องกับความต้องการการออกแบบของคุณ