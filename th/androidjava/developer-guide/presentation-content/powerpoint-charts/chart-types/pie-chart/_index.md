---
title: ปรับแต่งแผนภูมิงวงกลมในงานนำเสนอบน Android
linktitle: แผนภูมิงวงกลม
type: docs
url: /th/androidjava/pie-chart/
keywords:
- แผนภูมิงวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีของสไลซ์
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิงวงกลมใน Java ด้วย Aspose.Slides สำหรับ Android สามารถส่งออกเป็น PowerPoint ช่วยเพิ่มการเล่าเรื่องข้อมูลของคุณในไม่กี่วินาที"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลมใน Aspose.Slides โดยแสดงวิธีการตั้งค่าตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีเปิดใช้งานการกำหนดสีสไลซ์อัตโนมัติสำหรับแผนภูมิงวงกลมมาตฐาน

ตัวอย่างมุ่งเน้นที่ขั้นตอนการปรับแต่งแผนภูมิอย่างเป็นจริง เช่น การเพิ่มแผนภูมิเข้าสไลด์ การปรับค่าซีรีส์และการตั้งค่าป้ายกำกับ การแทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยหมวดหมู่และค่าแบบกำหนดเอง และการบันทึกการนำเสนอที่อัปเดต

## **ตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for Android via Java ตอนนี้รองรับตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie หรือ Bar of Pie ในหัวข้อนี้ เราจะสาธิตวิธีระบุตัวเลือกเหล่านั้นโดยใช้ Aspose.Slides เพื่อระบุคุณสมบัติ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอ็อบเจ็กต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เพิ่มแผนภูมิในสไลด์
1. ระบุตัวเลือกพล็อตรองของแผนภูมิ
1. บันทึกการนำเสนอลงดิสก์

ในตัวอย่างที่ให้ด้านล่าง เราได้ตั้งค่าต่าง ๆ ของแผนภูมิ Pie of Pie

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เพิ่มแผนภูมิลงในสไลด์
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // ตั้งค่าคุณลักษณะที่แตกต่างกัน
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // บันทึกการนำเสนอลงดิสก์
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตั้งค่าสีสไลซ์อัตโนมัติในแผนภูมิงวงกลม**

Aspose.Slides for Android via Java มี API ที่ง่ายสำหรับการตั้งค่าสีสไลซ์อัตโนมัติของแผนภูมิงวงกลม ตัวอย่างโค้ดจะใช้การตั้งค่าที่กล่าวถึงข้างต้น

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
1. ตั้งค่าชื่อหัวเรื่องของแผนภูมิ
1. ตั้งค่าซีรีส์แรกให้แสดงค่า
1. ตั้งดัชนีของชีตข้อมูลแผนภูมิ
1. ดึง worksheet ของข้อมูลแผนภูมิ
1. ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติเบื้องต้น
1. เพิ่มหมวดหมู่ใหม่
1. เพิ่มซีรีส์ใหม่

บันทึกการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```java
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation();
try {
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // ตั้งค่าชื่อหัวเรื่องแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // ตั้งค่าซีรีส์แรกให้แสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
    int defaultWorksheetIndex = 0;

    // ดึง worksheet ของข้อมูลแผนภูมิ
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติเบื้องต้น
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // เพิ่มหมวดหมู่ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // เพิ่มซีรีส์ใหม่
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // กำลังเติมข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**รองรับรูปแบบ 'Pie of Pie' และ 'Bar of Pie' หรือไม่?**

ใช่, ไลบรารีนี้ [รองรับ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) พล็อตรองสำหรับแผนภูมิงวงกลม รวมถึงประเภท 'Pie of Pie' และ 'Bar of Pie'

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ได้, คุณสามารถ [ส่งออกแผนภูมิเป็นภาพ](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) (เช่น PNG) โดยไม่ต้องรวมการนำเสนอทั้งหมด