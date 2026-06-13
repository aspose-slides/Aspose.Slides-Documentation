---
title: สร้างหรืออัปเดตแผนภูมิ PowerPoint Presentation ด้วย JavaScript
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
- แผนภูมิแผนที่ต้นไม้
- แผนภูมิเจ้อ
- แผนภูมิ Box and Whisker
- แผนภูมิ Funnel
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js. เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้ได้จริงใน JavaScript."
---
## **ภาพรวม**

บทความนี้ให้คู่มือแบบครบถ้วนเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์แบบโปรแกรมเมติก เติมข้อมูลให้แผนภูมิ และใช้ตัวเลือกการจัดรูปแบบต่างๆ เพื่อให้ตรงกับความต้องการในการออกแบบของคุณ ตลอดบทความ ตัวอย่างโค้ดโดยละเอียดจะแสดงขั้นตอนแต่ละขั้นตอน ตั้งแต่การเริ่มต้น Presentation และอ็อบเจ็กต์แผนภูมิ ไปจนถึงการกำหนด Series, Axis และ Legend โดยทำตามคู่มือนี้ คุณจะเข้าใจวิธีการผสานการสร้างแผนภูมิแบบไดนามิกเข้าสู่แอปพลิเคชันของคุณ ทำให้การสร้างงานนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**
แผนภูมิช่วยให้ผู้ใช้เห็นข้อมูลได้อย่างรวดเร็วและได้มุมมองใหม่ๆ ที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ด้วยแผนภูมิ คุณสามารถ

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากในสไลด์เดียวของงานนำเสนอ
* เปิดเผยรูปแบบและแนวโน้มในข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรืออ้างอิงต่อหน่วยวัดที่กำหนด
* ตรวจจับค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, ข้อมูลที่ไม่มีเหตุผล ฯลฯ
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิได้ผ่านฟังก์ชัน Insert ซึ่งมีเทมเพลตให้เลือกใช้หลายประเภท การใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิทั่วไป (ตามประเภทแผนภูมิยอดนิยม) และแผนภูมิกำหนดเองได้

{{% alert color="primary" %}} 
เพื่อให้คุณสร้างแผนภูมิได้ Aspose.Slides มีคลาส [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType) ซึ่งฟิลด์ต่างๆ ภายใต้คลาสนี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}} 

### **การสร้างแผนภูมิปกติ**

_Steps: Create Chart_
- <a name="java-create-powerpoint-chart" id="java-create-powerpoint-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ PowerPoint ด้วย JavaScript</strong></a>
- <a name="java-create-presentation-chart" id="java-create-presentation-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมืองานนำเสนอด้วย JavaScript</strong></a>
- <a name="java-create-powerpoint-presentation-chart" id="java-create-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ PowerPoint Presentation ด้วย JavaScript</strong></a>

_Code Steps:_

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนีของมัน
3. เพิ่มแผนภูมพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ
4. เพิ่มชื่อเรื่องให้กับแผนภูมิ
5. เข้าถึงแผ่นงานข้อมูลแผนภูมิ
6. ลบ Series และ Category เริ่มต้นทั้งหมด
7. เพิ่ม Series และ Category ใหม่
8. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
9. ตั้งค่าสีเติมสำหรับ Series
10. เพิ่มป้ายกำกับสำหรับ Series
11. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิปกติ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    var chart = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 0, 0, 500, 500);
    // ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.hasTitle();
    // ตั้งค่าให้ Series แรกแสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // ตั้งดัชนีสำหรับแผ่นงานข้อมูลแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึงแผ่นงานข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    var s = chart.getChartData().getSeries().size();
    s = chart.getChartData().getCategories().size();
    // เพิ่ม Series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // เพิ่ม Category ใหม่
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // ดึง Series แผนภูมิแรก
    var series = chart.getChartData().getSeries().get_Item(0);
    // ตอนนี้กำลังเติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // ตั้งค่าสีเติมสำหรับ Series
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // ดึง Series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    // เติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // ตั้งค่าสีเติมสำหรับ Series
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละ Category ของ Series ใหม่
    // ตั้งค่าป้ายกำกับแรกให้แสดงชื่อ Category
    var lbl = series.getDataPoints().get_Item(0).getLabel();
    lbl.getDataLabelFormat().setShowCategoryName(true);
    lbl = series.getDataPoints().get_Item(1).getLabel();
    lbl.getDataLabelFormat().setShowSeriesName(true);
    // แสดงค่าในป้ายกำกับที่สาม
    lbl = series.getDataPoints().get_Item(2).getLabel();
    lbl.getDataLabelFormat().setShowValue(true);
    lbl.getDataLabelFormat().setShowSeriesName(true);
    lbl.getDataLabelFormat().setSeparator("/");
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **การสร้างแผนภูมิแบบกระจาย (Scatter)**
แผนภูมิแบบกระจาย (หรือที่เรียกว่ากราฟ x‑y) มักใช้เพื่อตรวจหารูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

คุณอาจต้องการใช้แผนภูมิกระจายในกรณีที่

* มีข้อมูลตัวเลขคู่
* มีตัวแปรสองตัวที่สัมพันธ์กันดี
* ต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่
* มีตัวแปรอิสระที่มีค่าหลายค่าในการพึ่งพาตัวแปรหนึ่ง

<a name="java-create-scattered-chart" id="java-create-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจายใน JavaScript</strong></a> |
<a name="java-create-powerpoint-scattered-chart" id="java-create-powerpoint-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจาย PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-scattered-chart" id="java-create-powerpoint-presentation-scattered-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิกระจาย PowerPoint Presentation ใน JavaScript</strong></a>

1. โปรดทำตามขั้นตอนที่อธิบายไว้ใน [Creating Normal Charts](#creating-normal-charts)
2. ในขั้นตอนที่สาม ให้เพิ่มแผนภูมพร้อมข้อมูลบางส่วนและระบุประเภทแผนภูมิเป็นหนึ่งในต่อไปนี้
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithMarkers) - _แสดงแผนภูมิ Scatter พร้อมเครื่องหมาย._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นโค้ง พร้อมเครื่องหมายข้อมูล._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นโค้ง ไม่มีกระบอกเครื่องหมาย._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นตรง พร้อมเครื่องหมายข้อมูล._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/#ScatterWithStraightLines) - _แสดงแผนภูมิ Scatter เชื่อมด้วยเส้นตรง ไม่มีกระบอกเครื่องหมาย._

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิกระจายด้วยชุดเครื่องหมายต่าง ๆ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // สร้างแผนภูมิโดยค่าเริ่มต้น
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);
    // ดึงดัชนีแผ่นงานข้อมูลแผนภูมิโดยค่าเริ่มต้น
    var defaultWorksheetIndex = 0;
    // ดึงแผ่นงานข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบ Series ตัวอย่าง
    chart.getChartData().getSeries().clear();
    // เพิ่ม Series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.getType());
    // ดึง Series แผนภูมิแรก
    var series = chart.getChartData().getSeries().get_Item(0);
    // เพิ่มจุดใหม่ (1:3) ให้กับ Series
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 1), fact.getCell(defaultWorksheetIndex, 2, 2, 3));
    // เพิ่มจุดใหม่ (2:10)
    series.getDataPoints().addDataPointForScatterSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 2), fact.getCell(defaultWorksheetIndex, 3, 2, 10));
    // เปลี่ยนประเภทของ Series
    series.setType(aspose.slides.ChartType.ScatterWithStraightLinesAndMarkers);
    // เปลี่ยนเครื่องหมายของ Series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Star);
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
    // เปลี่ยนเครื่องหมายของ Series แผนภูมิ
    series.getMarker().setSize(10);
    series.getMarker().setSymbol(aspose.slides.MarkerStyleType.Circle);
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **การสร้างแผนภูมิวงกลม (Pie)**
แผนภูมิวงกลมเหมาะที่สุดสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนโดยรวมของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือป้ายหลายส่วน ควรพิจารณาใช้แผนภูมิแท่งแทน

<a name="java-create-pie-chart" id="java-create-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิวงกลมใน JavaScript</strong></a> |
<a name="java-create-powerpoint-pie-chart" id="java-create-powerpoint-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิวงกลม PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-pie-chart" id="java-create-powerpoint-presentation-pie-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิวงกลม PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. ดึงอ้างอิงสไลด์โดยใช้ดัชนี
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ (ในที่นี้คือ [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).Pie)
4. เข้าถึงข้อมูลแผนภูมิผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook)
5. ลบ Series และ Category เริ่มต้น
6. เพิ่ม Series และ Category ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
8. เพิ่มจุดข้อมูลใหม่และกำหนดสีกำหนดเองให้กับส่วนของแผนภูมิวงกลม
9. ตั้งค่าป้ายกำกับสำหรับ Series
10. ตั้งค่าเส้นเชื่อม (leader lines) สำหรับป้ายกำกับ Series
11. ตั้งค่ามุมการหมุนสำหรับสไลด์แผนภูมิวงกลม
12. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิวงกลม:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slides = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    var chart = slides.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // ตั้งค่าให้ Series แรกแสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // ตั้งดัชนีสำหรับแผ่นงานข้อมูลแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึงแผ่นงานข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // เพิ่ม Category ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // เพิ่ม Series ใหม่
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // เติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    // ไม่ทำงานในเวอร์ชันใหม่
    // Adding new points and setting sector color
    // series.IsColorVaried = true;
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);
    var point = series.getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "CYAN"));
    // ตั้งค่าขอบของเซ็กเตอร์
    point.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    point.getFormat().getLine().setWidth(3.0);
    point.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThick);
    point.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    var point1 = series.getDataPoints().get_Item(1);
    point1.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    // ตั้งค่าขอบของเซ็กเตอร์
    point1.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point1.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    point1.getFormat().getLine().setWidth(3.0);
    point1.getFormat().getLine().setStyle(aspose.slides.LineStyle.Single);
    point1.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDot);
    var point2 = series.getDataPoints().get_Item(2);
    point2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    // ตั้งค่าขอบของเซ็กเตอร์
    point2.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point2.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    point2.getFormat().getLine().setWidth(2.0);
    point2.getFormat().getLine().setStyle(aspose.slides.LineStyle.ThinThin);
    point2.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.LargeDashDotDot);
    // สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละ Category ของ Series ใหม่
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
    // แสดงเส้นเชื่อม (Leader Lines) สำหรับแผนภูมิ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);
    // ตั้งค่ามุมการหมุนสำหรับเซ็กเตอร์ของแผนภูม่วงกลม
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("PieChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **การสร้างแผนภูมิเส้น (Line)**
แผนภูมิเส้น (หรือกราฟเส้น) เหมาะสำหรับแสดงการเปลี่ยนแปลงค่าตามเวลา ใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลหลายชุดพร้อมกัน ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา เน้นความผิดปกติในชุดข้อมูล ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. รับอ้างอิงสไลด์โดยใช้ดัชนี
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นพร้อมกำหนดประเภทที่ต้องการ (ในที่นี้คือ `ChartType.Line`)
1. เข้าถึงข้อมูลแผนภูมิ IChartDataWorkbook
1. ลบ Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิเส้น:

```javascript
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

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมด้วยเส้นประ ให้ระบุประเภทเส้นประตามนี้:

```javascript
var lineChart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 10, 50, 600, 350);
for (let i = 0; i < lineChart.getChartData().getSeries().size(); i++) {
    let series = lineChart.getChartData().getSeries().get_Item(i);
    series.getFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.Dash);
});
```

### **การสร้างแผนภูมิแผนที่ต้นไม้ (Tree Map)**
แผนภูมิแผนที่ต้นไม้เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและพร้อมกันนี้ดึงความสนใจไปยังรายการที่เป็นส่วนสำคัญของแต่ละหมวดหมู่

<a name="java-create-tree-map-chart" id="java-create-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-tree-map-chart" id="java-create-powerpoint-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-tree-map-chart" id="java-create-powerpoint-presentation-tree-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Tree Map PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์โดยใช้ดัชนี
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ (ในที่นี้คือ [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).TreeMap)
4. เข้าถึงข้อมูลแผนภูมิผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook)
5. ลบ Series และ Category เริ่มต้น
6. เพิ่ม Series และ Category ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
8. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Tree Map:

```javascript
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

### **การสร้างแผนภูมิเจ้อ (Stock)**
<a name="java-create-stock-chart" id="java-create-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิเจ้อใน JavaScript</strong></a> |
<a name="java-create-powerpoint-stock-chart" id="java-powerpoint-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิเจ้อ PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-stock-chart" id="java-create-powerpoint-presentation-stock-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิเจ้อ PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. ดึงอ้างอิงสไลด์ตามดัชนี
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).OpenHighLowClose)
4. เข้าถึงข้อมูลแผนภูมิผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook)
5. ลบ Series และ Category เริ่มต้น
6. เพิ่ม Series และ Category ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
8. กำหนดรูปแบบ HiLowLines
9. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

ตัวอย่างโค้ด JavaScript ที่ใช้สร้างแผนภูมิเจ้อ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.OpenHighLowClose, 50, 50, 600, 400);
  
    var wb = chart.getChartData().getChartDataWorkbook();
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

### **การสร้างแผนภูมิกล่องและวิสเกอร์ (Box and Whisker)**
<a name="java-create-box-and-whisker-chart" id="java-create-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-box-and-whisker-chart" id="java-powerpoint-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-box-and-whisker-chart" id="java-create-powerpoint-presentation-box-and-whisker-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Box and Whisker PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ตามดัชนี
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).BoxAndWhisker)
4. เข้าถึงข้อมูลแผนภูมิผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook)
5. ลบ Series และ Category เริ่มต้น
6. เพิ่ม Series และ Category ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
8. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Box and Whisker:

```javascript
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

### **การสร้างแผนภูมิกมหล (Funnel)**
<a name="java-create-funnel-chart" id="java-create-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-funnel-chart" id="java-create-powerpoint-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-funnel-chart" id="java-create-powerpoint-presentation-funnel-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Funnel PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ตามดัชนี
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).Funnel)
4. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Funnel:

```javascript
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

### **การสร้างแผนภูมิแสงสว่าง (Sunburst)**
<a name="java-create-sunburst-chart" id="java-create-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-sunburst-chart" id="java-create-powerpoint-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-sunburst-chart" id="java-create-powerpoint-presentation-sunburst-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Sunburst PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ตามดัชนี
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ (ในที่นี้คือ [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).sunburst)
4. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Sunburst:

```javascript
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

### **การสร้างแผนภูมิฮิสโตแกรม (Histogram)**
<a name="java-create-histogram-chart" id="java-create-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-histogram-chart" id="java-create-powerpoint-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-histogram-chart" id="java-create-powerpoint-presentation-histogram-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Histogram PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ตามดัชนี
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).Histogram)
4. เข้าถึงข้อมูลแผนภูมิผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook)
5. ลบ Series และ Category เริ่มต้น
6. เพิ่ม Series และ Category ใหม่
7. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Histogram:

```javascript
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

### **การสร้างแผนภูมิเรดาห์ (Radar)**
<a name="java-create-radar-chart" id="java-create-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-radar-chart" id="java-create-powerpoint-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-radar-chart" id="java-create-powerpoint-presentation-radar-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Radar PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ตามดัชนี 
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและกำหนดประเภทแผนภูมิที่ต้องการ (`ChartType.Radar` ในที่นี้)
4. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Radar:

```javascript
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

### **การสร้างแผนภูมิมัลติแคทกอรี (Multi Category)**
<a name="java-create-multi-category-chart" id="java-create-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-multi-category-chart" id="java-create-powerpoint-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-multi-category-chart" id="java-create-powerpoint-presentation-multi-category-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Multi Category PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ตามดัชนี 
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและกำหนดประเภทที่ต้องการ ([ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartType).ClusteredColumn)
4. เข้าถึงข้อมูลแผนภูมิผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook)
5. ลบ Series และ Category เริ่มต้น
6. เพิ่ม Series และ Category ใหม่
7. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
8. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Multi Category:

```javascript
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
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("AsposeChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **การสร้างแผนภูมิแมพ (Map)**
แผนภูมิมาpเป็นการแสดงภาพของพื้นที่พร้อมข้อมูล แผนภูมิมาpเหมาะสำหรับการเปรียบเทียบข้อมูลหรือค่าในแต่ละภูมิภาค

<a name="java-create-map-chart" id="java-create-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Map ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-map-chart" id="java-create-powerpoint-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Map PowerPoint ใน JavaScript</strong></a> |
<a name="java-create-powerpoint-presentation-map-chart" id="java-create-powerpoint-presentation-map-chart"><strong><em>ขั้นตอน:</em> สร้างแผนภูมิ Map PowerPoint Presentation ใน JavaScript</strong></a>

โค้ด JavaScript นี้จะแสดงวิธีสร้างแผนภูมิ Map:

```javascript
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

### **การสร้างแผนภูมิรวม (Combination)**
แผนภูมิคอมบิเนชัน (หรือ combo chart) รวมประเภทแผนภูมิสองประเภทหรือมากกว่าไว้ในกราฟเดียวกัน ช่วยให้คุณไฮไลท์, เปรียบเทียบ หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อระบุความสัมพันธ์ระหว่างพวกมัน

![The combination chart](combination_chart.png)

โค้ด JavaScript ด้านล่างแสดงวิธีสร้างแผนภูมิคอมบิเนชันดังกล่าวใน PowerPoint Presentation:

```js
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

    // ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Chart Title");
    chart.getChartTitle().setOverlay(false);
    let titleParagraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0);
    let titleFormat = titleParagraph.getParagraphFormat().getDefaultPortionFormat();
    titleFormat.setFontBold(java.newByte(aspose.slides.NullableBool.False));
    titleFormat.setFontHeight(18);

    // ตั้งค่าคำอธิบายของแผนภูมิ.
    chart.getLegend().setPosition(aspose.slides.LegendPositionType.Bottom);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12);

    // ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น.
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const worksheetIndex = 0;
    let workbook = chart.getChartData().getChartDataWorkbook();

    // เพิ่ม Category ใหม่.
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 3, 0, "Category 3"));
    chart.getChartData().getCategories().add(workbook.getCell(worksheetIndex, 4, 0, "Category 4"));

    // เพิ่ม Series แรก.
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

    // ตั้งค่าสีของเส้นตารางแนวตั้งหลัก.
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

## **การอัปเดตแผนภูมิ**

<a name="java-update-powerpoint-chart" id="java-update-powerpoint-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ PowerPoint ใน JavaScript</strong></a> |
<a name="java-update-presentation-chart" id="java-update-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมืองานนำเสนอใน JavaScript</strong></a> |
<a name="java-update-powerpoint-presentation-chart" id="java-update-powerpoint-presentation-chart"><strong><em>ขั้นตอน:</em> อัปเดตแผนภูมิ PowerPoint Presentation ใน JavaScript</strong></a>

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่แทนงานนำเสนอที่มีแผนภูมิที่ต้องการอัปเดต
2. ดึงอ้างอิงสไลด์โดยใช้ Index
3. ท่องผ่านรูปทรงทั้งหมดเพื่อหาแผนภูมิที่ต้องการ
4. เข้าถึงแผ่นงานข้อมูลแผนภูมิ
5. แก้ไขข้อมูล Series ของแผนภูมิโดยเปลี่ยนค่าของ Series
6. เพิ่ม Series ใหม่และเติมข้อมูลในนั้น
7. เขียน Presentation ที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีอัปเดตแผนภูมิ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // ดึงแผนภูมิพร้อมข้อมูลเริ่มต้น
    var chart = sld.getShapes().get_Item(0);
    // ตั้งค่าดัชนีของแผ่นงานข้อมูลแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึงแผ่นงานข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // เปลี่ยนชื่อ Category ของแผนภูมิ
    fact.getCell(defaultWorksheetIndex, 1, 0, "Modified Category 1");
    fact.getCell(defaultWorksheetIndex, 2, 0, "Modified Category 2");
    // ดึง Series แผนภูมิเพรก
    var series = chart.getChartData().getSeries().get_Item(0);
    // ตอนนี้กำลังอัปเดตข้อมูล Series
    fact.getCell(defaultWorksheetIndex, 0, 1, "New_Series1");// แก้ไขชื่อ Series
    series.getDataPoints().get_Item(0).getValue().setData(90);
    series.getDataPoints().get_Item(1).getValue().setData(123);
    series.getDataPoints().get_Item(2).getValue().setData(44);
    // ดึง Series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1);
    // ตอนนี้กำลังอัปเดตข้อมูล Series
    fact.getCell(defaultWorksheetIndex, 0, 2, "New_Series2");// แก้ไขชื่อ Series
    series.getDataPoints().get_Item(0).getValue().setData(23);
    series.getDataPoints().get_Item(1).getValue().setData(67);
    series.getDataPoints().get_Item(2).getValue().setData(99);
    // ตอนนี้กำลังเพิ่ม Series ใหม่
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 3, "Series 3"), chart.getType());
    // ดึง Series แผนภูมิที่สาม
    series = chart.getChartData().getSeries().get_Item(2);
    // ตอนนี้กำลังเติมข้อมูลให้ Series
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 3, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 3, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 3, 30));
    chart.setType(aspose.slides.ChartType.ClusteredCylinder);
    // บันทึกงานนำเสนอพร้อมแผนภูมิ
    pres.save("AsposeChartModified_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การตั้งค่าช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) ที่แทนงานนำเสนอที่มีแผนภูมิ
2. รับอ้างอิงสไลด์โดยใช้ดัชนี
3. ท่องผ่านรูปทรงทั้งหมดเพื่อหาแผนภูมิที่ต้องการ
4. เข้าถึงข้อมูลแผนภูมิและตั้งค่าช่วงข้อมูล
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด JavaScript นี้จะแสดงวิธีตั้งค่าช่วงข้อมูลสำหรับแผนภูมิ:

```javascript
var pres = new aspose.slides.Presentation();
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

## **การใช้เครื่องหมายเริ่มต้นในแผนภูมิ**
เมื่อใช้เครื่องหมายเริ่มต้นในแผนภูมิแต่ละ Series จะได้รับสัญลักษณ์เครื่องหมายเริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ด JavaScript นี้จะแสดงวิธีตั้งค่าเครื่องหมาย Series อัตโนมัติ:

```javascript
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
    // ดึง Series ที่สองของแผนภูมิ
    var series2 = chart.getChartData().getSeries().get_Item(1);
    // ตอนนี้กำลังเติมข้อมูลให้ Series
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

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดบ้างที่ Aspose.Slides รองรับ?**

Aspose.Slides รองรับแผนภูมิหลายประเภท เช่น แถบ, เส้น, วงกลม, พื้นที่, กระจาย, ฮิสโตแกรม, เรดาห์ และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณที่สุด

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วดึงสไลด์ที่ต้องการโดยใช้ดัชนี จากนั้นเรียกเมธอดเพื่อเพิ่มแผนภูมิ พร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะผสานแผนภูมิเข้าไปในงานนำเสนอของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงแผ่นงานข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/)) ลบ Series และ Category เริ่มต้นที่ไม่ต้องการ แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ช่วยให้คุณรีเฟรชแผนภูมิโดยโปรแกรมให้แสดงข้อมูลล่าสุด

**สามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides มีตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, คำอธิบาย, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงกับความต้องการออกแบบของคุณอย่างเฉพาะเจาะจง