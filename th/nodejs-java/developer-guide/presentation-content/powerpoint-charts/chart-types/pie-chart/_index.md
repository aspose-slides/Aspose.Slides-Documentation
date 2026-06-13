---
title: กำหนดรูปแบบแผนภูมวงกลมในการนำเสนอโดยใช้ JavaScript
linktitle: แผนภูมวงกลม
type: docs
url: /th/nodejs-java/pie-chart/
keywords:
- แผนภูมวงกลม
- จัดการแผนภูมิ
- กำหนดแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีชิ้นส่วน
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและกำหนดรูปแบบแผนภูมวงกลมใน JavaScript ด้วย Aspose.Slides สำหรับ Node.js ที่สามารถส่งออกเป็น PowerPoint ได้ ช่วยให้การเล่าเรื่องข้อมูลของคุณเร็วขึ้นในไม่กี่วินาที"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิเสี้ยงใน Aspose.Slides โดยแสดงวิธีการกำหนดค่าตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีการเปิดใช้งานการทำสีอัตโนมัติสำหรับชิ้นส่วนของแผนภูมิวงกลมมาตรฐาน

ตัวอย่างมุ่งเน้นไปที่ขั้นตอนการปรับแต่งแผนภูมิอย่างเป็นรูปธรรม เช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับค่าซีรีส์และการตั้งค่าป้าย การแทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยหมวดหมู่และค่าแบบกำหนดเอง และการบันทึกงานนำเสนอที่อัปเดต

## **ตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**
Aspose.Slides สำหรับ Node.js ผ่าน Java ตอนนี้สนับสนุนตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie หรือ Bar of Pie ในหัวข้อนี้ เราจะสาธิตวิธีระบุตัวเลือกเหล่านั้นโดยใช้ Aspose.Slides เพื่อระบุคุณสมบัติ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
1. เพิ่มแผนภูมิลงในสไลด์
1. ระบุตัวเลือกพล็อตรองของแผนภูมิ
1. บันทึกงานนำเสนอลงดิสก์

ในตัวอย่างที่ให้ไว้ด้านล่าง เราได้ตั้งค่าคุณสมบัติต่าง ๆ ของแผนภูมิ Pie of Pie

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // เพิ่มแผนภูมิลงในสไลด์
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // ตั้งค่าต่างๆ
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าสีชิ้นส่วนแผนภูมิวงกลมอัตโนมัติ**
Aspose.Slides สำหรับ Node.js ผ่าน Java มี API ที่ง่ายสำหรับการตั้งค่าสีอัตโนมัติของชิ้นส่วนแผนภูมิวงกลม ตัวอย่างโค้ดด้านล่างแสดงการตั้งค่าคุณสมบัติดังกล่าว

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
1. ตั้งค่าชื่อแผนภูมิ
1. ตั้งค่าซีรีส์แรกให้แสดงค่า
1. ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
1. ดึงเวิร์กชีตข้อมูลของแผนภูมิ
1. ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติ
1. เพิ่มหมวดหมู่ใหม่
1. เพิ่มซีรีส์ใหม่

บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // ตั้งค่าชื่อแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // ตั้งค่าซีรีส์แรกให้แสดงค่า
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
    var defaultWorksheetIndex = 0;
    // ดึงแผ่นงานข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติ
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // เพิ่มหมวดหมู่ใหม่
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // เพิ่มซีรีส์ใหม่
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Now populating series data
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**การแปรผัน 'Pie of Pie' และ 'Bar of Pie' ได้รับการสนับสนุนหรือไม่?**

ใช่, ไลบรารี [supports](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/) พล็อตรองสำหรับแผนภูมิเสี้ยง รวมถึงประเภท 'Pie of Pie' และ 'Bar of Pie'

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ใช่, คุณสามารถ [export the chart itself as an image](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) (เช่น PNG) ได้โดยไม่ต้องส่งออกงานนำเสนอทั้งหมด