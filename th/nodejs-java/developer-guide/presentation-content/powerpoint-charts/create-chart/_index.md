---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ด้วย JavaScript
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/nodejs-java/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิต้นไม้แผนที่
- แผนภูมิตลาดหุ้น
- แผนภูมิกล่องและวิสเกอร์
- แผนภูมิน้ำพุ
- แผนภูมิดาวระเบิด
- แผนภูมหิสโตแกรม
- แผนภูมิเรดาร์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides สำหรับ Node.js เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดเชิงปฏิบัติใน JavaScript."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างครอบคลุมเกี่ยวกับการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม, เติมข้อมูลลงในแผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่างๆ เพื่อให้ตรงกับความต้องการการออกแบบของคุณ ในบทความนี้ ตัวอย่างโค้ดโดยละเอียดจะอธิบายแต่ละขั้นตอน ตั้งแต่การเริ่มต้นพรีเซนเทชันและออบเจ็กต์แผนภูมิ ไปจนถึงการกำหนดค่า series, axes, และ legends โดยการทำตามคู่มือนี้ คุณจะได้เข้าใจอย่างลึกซึ้งเกี่ยวกับการบูรณาการการสร้างแผนภูมิแบบไดนามิกเข้าสู่แอปพลิเคชันของคุณ ทำให้กระบวนการสร้างพรีเซนเทชันที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้คนมองเห็นข้อมูลอย่างรวดเร็วและได้รับข้อมูลเชิงลึกที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

- รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากลงในสไลด์เดียวของพรีเซนเทชัน
- เปิดเผยรูปแบบและแนวโน้มของข้อมูล
- สรุปทิศทางและแรงผลักดันของข้อมูลตามเวลา หรือเทียบกับหน่วยการวัดเฉพาะ
- ระบุค่าผิดปกติ, ความบกพร่อง, ความเบี่ยงเบน, ข้อผิดพลาด, ข้อมูลที่ไม่มีความหมาย ฯลฯ
- สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งให้แม่แบบสำหรับการออกแบบแผนภูมิหลายประเภท ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิทั่วไป (อิงตามประเภทแผนภูมิยอดนิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="Note" %}}
เพื่อสร้างแผนภูมิ ใช้คลาส [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/) ฟิลด์ในคลาสนี้สอดคล้องกับประเภทแผนภูมิต่างๆ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ส่วนนี้อธิบายวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่มโดยใช้ Aspose.Slides คุณจะได้เรียนรู้การเริ่มต้นพรีเซนเทชัน, เพิ่มแผนภูมิ, และปรับแต่งองค์ประกอบต่างๆ เช่น ชื่อ, ข้อมูล, series, categories, และการจัดรูปแบบ ติดตามขั้นตอนด้านล่างเพื่อดูวิธีการสร้างแผนภูมิคอลัมน์แบบกลุ่มมาตรฐาน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภท `ChartType.ClusteredColumn`
4. เพิ่มชื่อให้กับแผนภูมิ
5. เข้าถึงเวิร์กชีตข้อมูลของแผนภูมิ
6. ล้าง series และ categories เริ่มต้นทั้งหมด
7. เพิ่ม series และ categories ใหม่
8. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ series ของแผนภูมิ
9. กำหนดสีเติมให้กับ series ของแผนภูมิ
10. เพิ่มป้ายกำกับให้กับ series ของแผนภูมิ
11. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นของมัน
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // ตั้งค่าชื่อแผนภูมิ
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    // ตั้งค่า series แรกให้แสดงค่
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // ตั้งดัชนีสำหรับแผ่นข้อมูลของแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึง WorkSheet ข้อมูลของแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบ series และ categories ที่สร้างขึ้นโดยอัตโนมัติเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // เพิ่ม series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // เพิ่ม categories ใหม่
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // รับ series แผนภูมิแรก
    var series = chart.getChartData().getSeries().get_Item(0);
    // จากนี้เติมข้อมูลให้ series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // ตั้งค่าสีเติมสำหรับ series
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // รับ series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    // เติมข้อมูลให้ series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // ตั้งค่าสีเติมสำหรับ series
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละ category ของ series ใหม่
    // ตั้งค่าป้ายกำกับแรกให้แสดงชื่อ Category
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // แสดงค่าบนป้ายกำกับที่สาม
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิกระจาย**

แผนภูมิกระจาย (หรือที่เรียกว่ากราฟกระจายหรือกราฟ x‑y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

ใช้แผนภูมิกระจายเมื่อ:

- คุณมีข้อมูลเชิงตัวเลขเป็นคู่
- คุณมีสองตัวแปรที่จับคู่กันได้ดี
- คุณต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่
- คุณมีตัวแปรอิสระที่มีค่าหลายค่าสำหรับตัวแปรตาม

1. ทำตามขั้นตอนใน [Create Clustered Column Charts](#create-clustered-column-charts)
2. สำหรับขั้นตอนที่สาม เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิตามรายการต่อไปนี้:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิกระจาย._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นโค้ง, พร้อมเครื่องหมายข้อมูล._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นโค้ง, ไม่มีเครื่องหมายข้อมูล._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นตรง, พร้อมเครื่องหมายข้อมูล._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิกระจายที่เชื่อมต่อด้วยเส้นตรง, ไม่มีเครื่องหมายข้อมูล._

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // สร้างแผนภูมิเริ่มต้น
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // ดึงดัชนีเวิร์กชีตข้อมูลแผนภูมิเริ่มต้น
    var defaultWorksheetIndex = 0;
    // ดึงเวิร์กชีตข้อมูลของแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบ series ตัวอย่าง
    chart.getChartData().getSeries().clear();
    // เพิ่ม series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // รับ series แผนภูมิแรก
    var series = chart.getChartData().getSeries().get_Item(0);
    // เพิ่มจุดใหม่ (1:3) ให้กับ series
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // เพิ่มจุดใหม่ (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // เปลี่ยนประเภทของ series
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // เปลี่ยนเครื่องหมายของ series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
    // รับ series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    // เพิ่มจุดใหม่ (5:2) ที่นั่น
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 5), fact.getCell(defaultWorksheetIndex, 2, 4, 2));
    // เพิ่มจุดใหม่ (3:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 3), fact.getCell(defaultWorksheetIndex, 3, 4, 1));
    // เพิ่มจุดใหม่ (2:2)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 4, 3, 2), fact.getCell(defaultWorksheetIndex, 4, 4, 2));
    // เพิ่มจุดใหม่ (5:1)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 5, 3, 5), fact.getCell(defaultWorksheetIndex, 5, 4, 1));
    // เปลี่ยนเครื่องหมายของ series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิวงกลม**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนทั้งหมดของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายหมวดหมู่แบบเชิงตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือป้ายหลายส่วน คุณอาจพิจารณาใช้แผนภูมิกแท่งแทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและระบุประเภท [ChartType.Pie](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#Pie)
4. เข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)
5. ล้าง series และ categories เริ่มต้น
6. เพิ่ม series และ categories ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ series ของแผนภูมิ
8. เพิ่มจุดใหม่สำหรับแผนภูมิและกำหนดสีที่กำหนดเองสำหรับส่วนของแผนภูมิวงกลม
9. ตั้งค่าป้ายกำกับสำหรับ series
10. เปิดใช้เส้นนำสำหรับป้ายกำกับ series
11. ตั้งค่ามุมการหมุนสำหรับส่วนของแผนภูมิวงกลม
12. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slides = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // ตั้งค่าชื่อแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // ตั้งค่า series แรกให้แสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // ตั้งดัชนีสำหรับแผ่นข้อมูลของแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึงเวิร์กชีตข้อมูลของแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบ series และ categories ที่สร้างโดยอัตโนมัติเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // เพิ่ม categories ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // เพิ่ม series ใหม่
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // เติมข้อมูลให้ series
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // ไม่ทำงานในเวอร์ชันใหม่
    // เพิ่มจุดใหม่และตั้งค่าสีส่วน
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // ตั้งค่าขอบขอบของส่วน
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThick));
    point.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // ตั้งค่าขอบขอบของส่วน
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    point1.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDot));
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // ตั้งค่าขอบขอบของส่วน
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(java.newByte(aspose.slides.LineStyle.ThinThin));
    point2.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.LargeDashDotDot));
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละ category ของ series ใหม่
    var lbl1 = series.getDataPoints().get_Item(0).getLabel();
    // lbl.ShowCategoryName = true;
    lbl1.getDataLabelFormat().setShowValue(true);
    var lbl2 = series.getDataPoints().get_Item(1).getLabel();
    lbl2.getDataLabelFormat().setShowValue(true);
    lbl2.getDataLabelFormat().setShowLegendKey(true);
    lbl2.getDataLabelFormat().setShowPercentage(true);
    var lbl3 = series.getDataPoints().get_Item(2).getLabel();
    lbl3.getDataLabelFormat().setShowSeriesName(true);
    lbl3.getDataLabelFormat().setShowPercentage(true);
    // แสดงเส้นนำสำหรับแผนภูมิ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // ตั้งค่ามุมการหมุนสำหรับส่วนของแผนภูมิวงกลม
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือที่เรียกว่ากราฟเส้น) เหมาะสำหรับสภาวะที่คุณต้องการแสดงการเปลี่ยนแปลงค่าเมื่อเวลาผ่านไป ด้วยแผนภูมิเส้น คุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, ไฮไลท์ความผิดปกติใน series ของข้อมูล, และอื่นๆ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและระบุประเภท [ChartType.Line](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#Line)
4. เข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/))
5. ล้าง series และ categories เริ่มต้น
6. เพิ่ม series และ categories ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ series ของแผนภูมิ
8. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากคุณต้องการให้จุดเชื่อมต่อด้วยเส้นประแทนที่ คุณสามารถระบุประเภทเส้นประที่ต้องการได้ดังนี้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
    for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
        let series = lineChart.getChartData().getSeries().get_Item(i);
        series.getFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    }
    pres.save("lineChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิต้นไม้แผนที่**

แผนภูมิต้นไม้แผนที่เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้ร่วมให้ข้อมูลมากในแต่ละหมวดหมู่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Treemap](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#Treemap)
4. เข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)
5. ล้าง series และ categories เริ่มต้น
6. เพิ่ม series และ categories ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ series ของแผนภูมิ
8. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Treemap, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // สาขา 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForTreemapSeries(wb.getCell(0, "D8", 3));
    series.setParentLabelLayout(aspose.slides.ParentLabelLayoutType.Overlapping);
    pres.save("Treemap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิตลาดหุ้น**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#OpenHighLowClose)
4. เข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)
5. ล้าง series และ categories เริ่มต้น
6. เพิ่ม series และ categories ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ series ของแผนภูมิ
8. ระบุรูปแบบเส้น high‑low
9. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, 1, 0, "A"));
    chart.getChartData().getCategories().add(wb.getCell(0, 2, 0, "B"));
    chart.getChartData().getCategories().add(wb.getCell(0, 3, 0, "C"));
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 1, "Open"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 2, "High"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 3, "Low"), chart.getType());
    chart.getChartData().getSeries().add(wb.getCell(0, 0, 4, "Close"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
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
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        let ser = chart.getChartData().getSeries().get_Item(i);
        ser.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิกล่องและวิสเกอร์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#BoxAndWhisker)
4. เข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)
5. ล้าง series และ categories เริ่มต้น
6. เพิ่ม series และ categories ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ series ของแผนภูมิ
8. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.BoxAndWhisker, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 1"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.BoxAndWhisker);
    series.setQuartileMethod(aspose.slides.QuartileMethodType.Exclusive);
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
    pres.save("BoxAndWhisker.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมน้ำพุ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Funnel](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#Funnel)
4. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Funnel, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    chart.getChartData().getCategories().add(wb.getCell(0, "A1", "Category 1"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A2", "Category 2"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A3", "Category 3"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A4", "Category 4"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A5", "Category 5"));
    chart.getChartData().getCategories().add(wb.getCell(0, "A6", "Category 6"));
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Funnel);
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B1", 50));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B2", 100));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B3", 200));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B4", 300));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B5", 400));
    series.getDataPoints().addDataPointForFunnelSeries(wb.getCell(0, "B6", 500));
    pres.save("Funnel.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิดาวระเบิด**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Sunburst](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#Sunburst)
4. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Sunburst, 50, 50, 500, 400);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();
    var wb = chart.getChartData().getChartDataWorkbook();
    wb.clear(0);
    // สาขา 1
    var leaf = chart.getChartData().getCategories().add(wb.getCell(0, "C1", "Leaf1"));
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
    var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D1", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D2", 5));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D3", 3));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D4", 6));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D5", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D6", 9));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D7", 4));
    series.getDataPoints().addDataPointForSunburstSeries(wb.getCell(0, "D8", 3));
    pres.save("Sunburst.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิฮิสโตแกรม**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Histogram](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#Histogram)
4. เข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)
5. ล้าง series และ categories เริ่มต้น
6. เพิ่ม series และ categories ใหม่
7. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Histogram, 50, 50, 500, 400);
chart.getChartData().getCategories().clear();
chart.getChartData().getSeries().clear();
var wb = chart.getChartData().getChartDataWorkbook();
wb.clear(0);
var series = chart.getChartData().getSeries().add(aspose.slides.ChartType.Histogram);
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A1", 15));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A2", -41));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A3", 16));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A4", 10));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A5", -23));
series.getDataPoints().addDataPointForHistogramSeries(wb.getCell(0, "A6", 16));
chart.getAxes().getHorizontalAxis().setAggregationType(aspose.slides.AxisAggregationType.Automatic);
```

### **สร้างแผนภูมิเรดาร์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ ([ChartType.Radar](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#Radar) ในกรณีนี้)
4. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Radar, 20, 20, 400, 300);
    pres.save("Radar-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิมัลติเพอร์เคเทอรี่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.ClusteredColumn](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ClusteredColumn)
4. เข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)
5. ล้าง series และ categories เริ่มต้น
6. เพิ่ม series และ categories ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ series ของแผนภูมิ
8. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var ch = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 600, 450);
    ch.getChartData().getSeries().clear();
    ch.getChartData().getCategories().clear();
    var fact = ch.getChartData().getChartDataWorkbook();
    fact.clear(0);
    var defaultWorksheetIndex = 0;
    var category = ch.getChartData().getCategories().add(fact.getCell(0, "c2", "A"));
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
    var series = ch.getChartData().getSeries().add(fact.getCell(0, "D1", "Series 1"), aspose.slides.ChartType.ClusteredColumn);
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D2", 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D3", 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D4", 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D5", 40));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D6", 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D7", 60));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D8", 70));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, "D9", 80));
    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิแผนที่**

แผนภูมิเพื่อแสดงข้อมูลเชิงภูมิศาสตร์และช่วยเปรียบเทียบค่าตามภูมิภาค

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pres = new aspose.slides.Presentation();
try {
    let chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Map, 50, 50, 500, 400);
    pres.save("mapChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **สร้างแผนภูมิผสม**

แผนภูมิผสม (หรือ combo chart) ทำให้คุณสามารถรวมสองประเภทแผนภูมิหรือมากกว่าภายในกราฟเดียวกัน แผนภูมินี้ช่วยให้คุณเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด ช่วยระบุความสัมพันธ์ระหว่างข้อมูล

![แผนภูมิผสม](combination_chart.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีสร้างแผนภูมิผสมที่แสดงด้านบนในพรีเซนเทชัน PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createComboChart() {
    let presentation = new aspose.slides.Presentation();
    let slide = presentation.getSlides().get_Item(0);
    try {
        let chart = createChartWithFirstSeries(slide);

        addSecondSeriesToChart(chart);
        addThirdSeriesToChart(chart);

        setPrimaryAxesFormat(chart);
        setSecondaryAxesFormat(chart);

        presentation.save("combo-chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}

function createChartWithFirstSeries(slide) {
    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    // ตั้งค่าชื่อแผนภูมิ.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // ตั้งค่าตัวอธิบายแผนภูมิ.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // ลบ series และ categories ที่สร้างโดยอัตโนมัติเริ่มต้น.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // เพิ่ม categories ใหม่.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // เพิ่ม series แรก.
    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    let series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 1, 4.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 1, 2.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 1, 3.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

function addSecondSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.ClusteredColumn);

    series.getParentSeriesGroup().setOverlap(java.newByte(-25));
    series.getParentSeriesGroup().setGapWidth(220);

    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 1, 2, 2.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 2, 2, 4.4));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 3, 2, 1.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(worksheetIndex, 4, 2, 2.8));
}

function addThirdSeriesToChart(chart) {
    let workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    let seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
    let series = chart.getChartData().getSeries().add(seriesNameCell, aspose.slides.ChartType.Line);

    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 1, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 2, 3, 2.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 3, 3, 3.0));
    series.getDataPoints().addDataPointForLineSeries(workbook.getCell(worksheetIndex, 4, 3, 5.0));

    series.setPlotOnSecondAxis(true);
}

function setPrimaryAxesFormat(chart) {
    // ตั้งค่าแกนแนวนอน.
    let horizontalAxis = chart.getAxes().getHorizontalAxis();
    horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    horizontalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(horizontalAxis, "X Axis");

    // ตั้งค่าแกนแนวตั้ง.
    let verticalAxis = chart.getAxes().getVerticalAxis();
    verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    verticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(verticalAxis, "Y Axis 1");

    // กำหนดสีของเส้นกริดหลักแนวตั้ง.
    let majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
    majorGridLinesFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    majorGridLinesFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 217, 217, 217));
}

function setSecondaryAxesFormat(chart) {
    // ตั้งค่าแกนแนวนอนรอง.
    let secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
    secondaryHorizontalAxis.setPosition(aspose.slides.AxisPositionType.Bottom);
    secondaryHorizontalAxis.setCrossType(aspose.slides.CrossesType.Maximum);
    secondaryHorizontalAxis.setVisible(false);
    secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // ตั้งค่าแกนแนวตั้งรอง.
    let secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
    secondaryVerticalAxis.setPosition(aspose.slides.AxisPositionType.Right);
    secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12);
    secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

function setAxisTitle(axis, axisTitle) {
    axis.setTitle(true);
    axis.getTitle().setOverlay(false);
    let titleParagraph = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(12);
}
```

## **อัปเดตแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่เป็นพรีเซนเทชันที่มีแผนภูมิที่ต้องการอัปเดต
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เดินผ่านรูปทรงทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ
4. เข้าถึงเวิร์กชีตข้อมูลของแผนภูมิ
5. แก้ไข series ของแผนภูมิโดยเปลี่ยนค่าของ series
6. เพิ่ม series ใหม่และเติมข้อมูลให้กับมัน
7. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    // เข้าถึง slide แรก
    var sld = pres.getSlides().get_Item(0);
    // ดึงแผนภูมิพร้อมข้อมูลเริ่มต้น
    var chart = sld.getShapes().get_Item(0);
    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึงเวิร์กชีตข้อมูลของแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // เปลี่ยนชื่อ Category ของแผนภูมิ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // ดึง series แผนภูมแรก
    var series = chart.getChartData().getSeries().get_Item(0);
    // ตอนนี้อัปเดตข้อมูลของ series
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1"); // แก้ไขชื่อ series
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // ดึง series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    // ตอนนี้อัปเดตข้อมูลของ series
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2"); // แก้ไขชื่อ series
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // ตอนนี้เพิ่ม series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // ดึง series แผนภูมิที่สาม
    series = chart.getChartData().getSeries().get_Item(2);
    // ตอนนี้เติมข้อมูลให้ series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // บันทึกพรีเซนเทชันพร้อมแผนภูมิ
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) ที่เป็นพรีเซนเทชันที่มีแผนภูมิ
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เดินผ่านรูปทรงทั้งหมดเพื่อค้นหาแผนภูมิที่ต้องการ
4. เข้าถึงข้อมูลของแผนภูมิและกำหนดช่วง
5. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("ExistingChart.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().get_Item(0);
    chart.getChartData().setRange("Sheet1!A1:B4");
    pres.save("SetDataRange_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ใช้เครื่องหมายเริ่มต้นในแผนภูมิ**

เมื่อคุณใช้เครื่องหมายเริ่มต้นในแผนภูมิ แต่ละ series ของแผนภูมิจะได้รับสัญลักษณ์เครื่องหมายที่แตกต่างโดยอัตโนมัติ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 10, 10, 400, 400);
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var fact = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    var series = chart.getChartData().getSeries().get_Item(0);
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "C1"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 1, 24));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "C2"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 1, 23));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "C3"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 1, -10));
    chart.getChartData().getCategories().add(fact.getCell(0, 4, 0, "C4"));
    series.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 1, null));
    chart.getChartData().getSeries().add(fact.getCell(0, 0, 2, "Series 2"), chart.getType());
    // ดึง series แผนภูมิที่สอง
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // กำลังเติมข้อมูลให้ series
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 1, 2, 30));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 2, 2, 10));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 3, 2, 60));
    series2.getDataPoints().addDataPointForLineSeries(fact.getCell(0, 4, 2, 40));
    chart.setLegend(true);
    chart.getLegend().setOverlay(false);
    pres.save("DefaultMarkersInChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่ Aspose.Slides รองรับ?**

Aspose.Slides รองรับช่วงกว้างของ [chart types](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/), รวมถึงบาร์, เส้น, วงกลม, พื้นที่, กระจาย, ฮิสโตแกรม, เรดาร์, และอื่นๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับความต้องการการแสดงผลข้อมูลของคุณ

**ทำอย่างไรจึงจะเพิ่มแผนภูมิใหม่ลงในสไลด์?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/), ดึงสไลด์ที่ต้องการโดยใช้ดัชนีของมัน, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิโดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้ทำให้แผนภูมถูกรวมเข้ากับพรีเซนเทชันของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)), ล้าง series และ categories เริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดของคุณเอง วิธีนี้ช่วยให้คุณรีเฟรชแผนภูมิโดยโปรแกรมเพื่อแสดงข้อมูลล่าสุด

**สามารถปรับแต่งรูปแบบของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides มีตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, เลเจนด์, และ [formatting elements](/slides/th/nodejs-java/chart-entities/) อื่นๆ เพื่อให้แผนภูมิของคุณสอดคล้องกับความต้องการการออกแบบเฉพาะของคุณ