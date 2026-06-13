---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอโดยใช้ JavaScript
linktitle: ป้ายข้อมูล
type: docs
url: /th/nodejs-java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งป้าย
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides for Node.js via Java เพื่อให้สไลด์น่าสนใจยิ่งขึ้น."
---
## **คำแนะนำ**

ป้ายข้อมูลบนแผนภูมิแสดงรายละเอียดเกี่ยวกับชุดข้อมูลของแผนภูมิหรือจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุชุดข้อมูลได้อย่างรวดเร็วและทำให้แผนภูมิเข้าใจง่ายขึ้น

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ**

โค้ด JavaScript นี้แสดงวิธีการตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

Aspose.Slides for Node.js via Java ช่วยให้คุณตั้งค่าป้ายเปอร์เซ็นต์บนแผนภูมิที่แสดงได้ โค้ด JavaScript นี้สาธิตการทำงาน:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // บันทึกงานนำเสนอที่มีแผนภูมิ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งสัญลักษณ์เปอร์เซ็นต์ในป้ายข้อมูลแผนภูมิ**

โค้ด JavaScript นี้แสดงวิธีตั้งสัญลักษณ์เปอร์เซ็นต์สำหรับป้ายข้อมูลของแผนภูมิ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน
    var slide = pres.getSlides().get_Item(0);
    // สร้างแผนภูมิ PercentsStackedColumn บนสไลด์
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // ตั้งค่า NumberFormatLinkedToSource เป็น false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // ดึง Worksheet ของข้อมูลแผนภูมิ
    var workbook = chart.getChartData().getChartDataWorkbook();
    // เพิ่มชุดข้อมูลใหม่
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // ตั้งค่าสีเติมของชุดข้อมูล
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // ตั้งค่าคุณสมบัติของ LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // เพิ่มชุดข้อมูลใหม่
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // ตั้งค่าชนิดและสีของการเติม
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งระยะห่างของป้ายจากแกน**

โค้ด JavaScript นี้แสดงวิธีตั้งระยะห่างของป้ายจากแกนประเภทเมื่อคุณทำงานกับแผนภูมิที่วาดจากแกน:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // ดึงอ้างอิงของสไลด์
    var sld = pres.getSlides().get_Item(0);
    // สร้างแผนภูมิบนสไลด์
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // ตั้งค่าระยะห่างของป้ายจากแกน
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ปรับตำแหน่งป้าย**

เมื่อคุณสร้างแผนภูมิที่ไม่พึ่งพาแกนใด ๆ เช่น แผนภูมิวงกลม ป้ายข้อมูลของแผนภูมิอาจอยู่ใกล้ขอบมากเกินไป ในกรณีเช่นนั้น คุณต้องปรับตำแหน่งของป้ายข้อมูลเพื่อให้เส้นนำแสดงได้ชัดเจน

โค้ด JavaScript นี้แสดงวิธีปรับตำแหน่งป้ายบนแผนภูมิวงกลม:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนบนแผนภูมิที่หนาแน่นได้อย่างไร?**

ผสานการจัดวางป้ายอัตโนมัติ, เส้นนำ, และขนาดฟอนต์ที่ลดลง; หากจำเป็นให้ซ่อนฟิลด์บางส่วน (เช่น หมวดหมู่) หรือแสดงป้ายเฉพาะจุดสุดขีด/สำคัญเท่านั้น

**ฉันจะปิดการใช้งานป้ายเฉพาะค่าศูนย์, ค่าติดลบ หรือค่าที่ว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงผลสำหรับค่าศูนย์, ค่าติดลบ, หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายสม่ำเสมอเมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

กำหนดฟอนต์อย่างชัดเจน (ประเภท, ขนาด) และตรวจสอบว่าฟอนต์พร้อมใช้บนฝั่งการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง