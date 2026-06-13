---
title: ปรับแต่งแผนภูมิวงกลมในงานนำเสนอด้วย Java
linktitle: แผนภูมิวงกลม
type: docs
url: /th/java/pie-chart/
keywords:
- แผนภูมิวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีส่วน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิวงกลมใน Java ด้วย Aspose.Slides ที่สามารถส่งออกไปยัง PowerPoint เพื่อเพิ่มประสิทธิภาพการเล่าเรื่องข้อมูลของคุณในไม่กี่วินาที"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับแผนภูมิวงกลมใน Aspose.Slides โดยแสดงวิธีกำหนดค่าตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีเปิดใช้งานการระบายสีส่วนแบบอัตโนมัติสำหรับแผนภูมิวงกลมมาตรฐาน

ตัวอย่างเน้นขั้นตอนการปรับแต่งแผนภูมิอย่างเป็นรูปธรรม เช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับการตั้งค่าชุดข้อมูลและป้ายกำกับ การแทนที่ข้อมูลแผนภูมิมาตรฐานด้วยหมวดหมู่และค่าแบบกำหนดเอง และการบันทึกการนำเสนอที่อัปเดต

## **ตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for Java ตอนนี้รองรับตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie หรือ Bar of Pie  ในหัวข้อนี้เราจะแสดงวิธีระบุตัวเลือกเหล่านั้นโดยใช้ Aspose.Slides เพื่อตั้งค่าคุณสมบัติตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. เพิ่มแผนภูมิบนสไลด์
3. ระบุตัวเลือกพล็อตที่สองของแผนภูมิ
4. เขียนการนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าคุณสมบัติต่าง ๆ ของแผนภูมิ Pie of Pie

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เพิ่มแผนภูมิบนสไลด์
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // ตั้งค่าคุณสมบัติต่าง ๆ
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // เขียนการนำเสนอลงดิสก์
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าสีส่วนของแผนภูมิวงกลมอัตโนมัติ**

Aspose.Slides for Java มี API อย่างง่ายสำหรับการตั้งค่าสีส่วนของแผนภูมิวงกลมแบบอัตโนมัติ ตัวอย่างโค้ดแสดงการตั้งค่าคุณสมบัติที่กล่าวถึงข้างต้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/Presentation) 
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
4. ตั้งค่าชื่อเรื่องของแผนภูมิ
5. ตั้งค่าชุดข้อมูลแรกให้แสดงค่า
6. ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
7. ดึงข้อมูลแผ่นงานของแผนภูมิ
8. ลบชุดข้อมูลและหมวดหมู่ที่สร้างโดยอัตโนมัติ
9. เพิ่มหมวดหมู่ใหม่
10. เพิ่มชุดข้อมูลใหม่

เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // ตั้งค่าชุดข้อมูลแรกให้แสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;

    // ดึงข้อมูลแผ่นงานของแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // ลบชุดข้อมูลและหมวดหมู่ที่สร้างโดยอัตโนมัติ
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // เพิ่มหมวดหมู่ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // เพิ่มชุดข้อมูลใหม่
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // ตอนนี้กำลังเติมข้อมูลให้ชุดข้อมูล
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Are the 'Pie of Pie' and 'Bar of Pie' variations supported?**  
ใช่ ไลบรารี [supports](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) พล็อตที่สองสำหรับแผนภูมิกับประเภท 'Pie of Pie' และ 'Bar of Pie'

**Can I export just the chart as an image (for example, PNG)?**  
ใช่ คุณสามารถ [ส่งออกรูปภาพของแผนภูมิเองเป็นภาพ](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-) (เช่น PNG) โดยไม่ต้องส่งออกรายการนำเสนอทั้งหมด