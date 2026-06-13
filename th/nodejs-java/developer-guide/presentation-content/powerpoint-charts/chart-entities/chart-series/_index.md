---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: ชุดข้อมูล
type: docs
url: /th/nodejs-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับของซีรีส์
- สีของซีรีส์
- สีของหมวดหมู่
- ชื่อของซีรีส์
- จุดข้อมูล
- ช่องว่างของซีรีส์
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิใน JavaScript สำหรับ PowerPoint (PPT/PPTX) พร้อมตัวอย่างโค้ดที่ใช้งานได้จริงและแนวปฏิบัติที่ดีที่สุดเพื่อยกระดับการนำเสนอข้อมูลของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายบทบาทของ [ChartSeries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/) ใน Aspose.Slides โดยมุ่งเน้นที่วิธีการจัดโครงสร้างและแสดงผลข้อมูลภายในงานนำเสนอ วัตถุเหล่านี้ให้องค์ประกอบพื้นฐานที่กำหนดชุดข้อมูล จุดข้อมูล หมวดหมู่ และพารามิเตอร์การแสดงผลในแผนภูมิ ด้วยการทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/) นักพัฒนาสามารถบูรณาการแหล่งข้อมูลพื้นฐานได้อย่างราบรื่นและควบคุมการแสดงข้อมูลได้อย่างเต็มที่ ส่งผลให้ได้งานนำเสนอที่มีข้อมูลขับเคลื่อนและแสดงผลเชิงวิเคราะห์อย่างชัดเจน

ซีรีส์คือแถวหรือคอลัมน์ของตัวเลขที่ถูกพล็อตในแผนภูมิ

![chart-series-powerpoint](chart-series-powerpoint.png)

## **กำหนดการทับของซีรีส์แผนภูมิ**

ด้วยเมธอด [ChartSeries.getOverlap](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getOverlap) คุณสามารถระบุว่าบาร์และคอลัมน์ควรทับกันเท่าใดในแผนภูมิ 2 มิติ (ช่วง: -100 ถึง 100) คุณสมบัตินี้ใช้กับซีรีส์ทั้งหมดของกลุ่มซีรีส์แม่: เป็นการสืบทอดคุณสมบัติของกลุ่มที่เหมาะสม ดังนั้นคุณสมบัตินี้เป็นแบบอ่านอย่างเดียว

ใช้คุณสมบัติ `ParentSeriesGroup.getOverlap` แบบอ่าน/เขียนเพื่อกำหนดค่าที่คุณต้องการสำหรับ `Overlap`

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์
1. เข้าถึงซีรีส์แรกของแผนภูมิ
1. เข้าถึง `ParentSeriesGroup` ของซีรีส์และกำหนดค่าการทับที่คุณต้องการ
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้แสดงวิธีตั้งค่าการทับสำหรับซีรีส์แผนภูมิ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // เพิ่มแผนภูมิ
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // ตั้งค่าการทับของซีรีส์
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // เขียนไฟล์งานนำเสนอไปยังดิสก์
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เปลี่ยนสีของซีรีส์**

Aspose.Slides สำหรับ Node.js via Java ทำให้คุณสามารถเปลี่ยนสีของซีรีส์ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เพิ่มแผนภูมิบนสไลด์
1. เข้าถึงซีรีส์ที่ต้องการเปลี่ยนสี
1. กำหนดประเภทการเติมและสีการเติมที่คุณต้องการ
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงวิธีเปลี่ยนสีของซีรีส์:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เปลี่ยนสีของหมวดหมู่ซีรีส์**

Aspose.Slides สำหรับ Node.js via Java ทำให้คุณสามารถเปลี่ยนสีของหมวดหมู่ซีรีส์ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เพิ่มแผนภูมิบนสไลด์
1. เข้าถึงหมวดหมู่ของซีรีส์ที่ต้องการเปลี่ยนสี
1. กำหนดประเภทการเติมและสีการเติมที่คุณต้องการ
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงวิธีเปลี่ยนสีของหมวดหมู่ซีรีส์:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เปลี่ยนชื่อของซีรีส์** 

โดยค่าเริ่มต้น ชื่อในตำนานของแผนภูมิจะมาจากเนื้อหาของเซลล์เหนือคอลัมน์หรือแถวของข้อมูล

ในตัวอย่างของเรา (ภาพตัวอย่าง)

* คอลัมน์คือ *Series 1, Series 2,* และ *Series 3*;
* แถวคือ *Category 1, Category 2, Category 3,* และ *Category 4.*

Aspose.Slides สำหรับ Node.js via Java ทำให้คุณสามารถอัปเดตหรือเปลี่ยนชื่อของซีรีส์ในข้อมูลแผนภูมิและตำนานได้

โค้ด JavaScript นี้แสดงวิธีเปลี่ยนชื่อของซีรีส์ในข้อมูลแผนภูมิ `ChartDataWorkbook`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

โค้ด JavaScript นี้แสดงวิธีเปลี่ยนชื่อของซีรีส์ในตำนานผ่าน `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **กำหนดสีเติมอัตโนมัติสำหรับซีรีส์แผนภูมิ**

Aspose.Slides สำหรับ Node.js via Java ทำให้คุณสามารถกำหนดสีเติมอัตโนมัติสำหรับซีรีส์แผนภูมิภายในพื้นที่พล็อตได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์ตามดัชนี
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่าง เราใช้ `ChartType.ClusteredColumn`)
1. เข้าถึงซีรีส์ของแผนภูมิและกำหนดสีเติมเป็น Automatic
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

โค้ด JavaScript นี้แสดงวิธีกำหนดสีเติมอัตโนมัติสำหรับซีรีส์แผนภูมิ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // สร้างแผนภูมิคอลัมน์แบบกลุ่ม
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // ตั้งค่ารูปแบบการเติมของซีรีส์เป็นอัตโนมัติ
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // เขียนไฟล์งานนำเสนอลงดิสก์
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **กำหนดสีเติมกลับด้านสำหรับซีรีส์แผนภูมิ**

Aspose.Slides ทำให้คุณสามารถกำหนดสีเติมกลับด้านสำหรับซีรีส์แผนภูมิภายในพื้นที่พล็อตได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. รับอ้างอิงของสไลด์ตามดัชนี
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่าง เราใช้ `ChartType.ClusteredColumn`)
1. เข้าถึงซีรีส์ของแผนภูมิและกำหนดสีเติมเป็น invert
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

โค้ด JavaScript นี้สาธิตการดำเนินการ:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // เพิ่มซีรีส์และหมวดหมู่ใหม่
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // ดึงซีรีส์แรกของแผนภูมิและใส่ข้อมูลซีรีส์
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **กำหนดให้ซีรีส์กลับด้านเมื่อค่าติดลบ**

Aspose.Slides ทำให้คุณสามารถกำหนดการกลับด้านผ่านเมธอด `ChartDataPoint.setInvertIfNegative` เมื่อกำหนดการกลับด้านโดยใช้คุณสมบัตินี้ จุดข้อมูลจะกลับสีเมื่อค่าติดลบ

โค้ด JavaScript นี้สาธิตการดำเนินการ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบข้อมูลของจุดข้อมูลที่ระบุ**

Aspose.Slides สำหรับ Node.js via Java ทำให้คุณสามารถลบข้อมูล `DataPoints` ของซีรีส์แผนภูมิเฉพาะได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
2. รับอ้างอิงของสไลด์ตามดัชนี
3. รับอ้างอิงของแผนภูมิตามดัชนี
4. วนลูปผ่าน `DataPoints` ทั้งหมดของแผนภูมิและกำหนด `XValue` และ `YValue` เป็น null
5. ลบ `DataPoints` ทั้งหมดสำหรับซีรีส์ที่ระบุ
6. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้สาธิตการดำเนินการ:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **กำหนดช่องว่างของซีรีส์ (Gap Width)**

Aspose.Slides สำหรับ Node.js via Java ทำให้คุณสามารถกำหนดช่องว่างของซีรีส์ผ่านคุณสมบัติ **`GapWidth`** ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
1. เข้าถึงซีรีส์ใด ๆ ของแผนภูมิ
1. กำหนดคุณสมบัติ `GapWidth`
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด JavaScript นี้แสดงวิธีกำหนดช่องว่างของซีรีส์:

```javascript
// สร้างงานนำเสนอเปล่า
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรกของงานนำเสนอ
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
    var defaultWorksheetIndex = 0;
    // รับชีตงานข้อมูลแผนภูมิ
    var fact = chart.getChartData().getChartDataWorkbook();
    // เพิ่มซีรีส์
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // เพิ่มหมวดหมู่
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // ดึงซีรีส์แผนภูมที่สอง
    var series = chart.getChartData().getSeries().get_Item(1);
    // ใส่ข้อมูลให้ซีรีส์
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // ตั้งค่าค่า GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**มีขีดจำกัดจำนวนซีรีส์ที่แผนภูมิเดียวสามารถบรรจุได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดคงที่สำหรับจำนวนซีรีส์ที่คุณเพิ่ม ขีดจำกัดเชิงปฏิบัติมาจากความอ่านง่ายของแผนภูมิและหน่วยความจำที่แอปพลิเคชันของคุณมี

**ถ้าคอลัมน์ภายในกลุ่มใกล้กันเกินไปหรือห่างกันเกินไปต้องทำอย่างไร?**

ปรับค่าการตั้งค่า Gap Width สำหรับซีรีส์นั้น (หรือกลุ่มซีรีส์แม่) การเพิ่มค่าจะขยายช่องว่างระหว่างคอลัมน์ ส่วนการลดค่าจะทำให้คอลัมน์เข้าหากันมากขึ้น.