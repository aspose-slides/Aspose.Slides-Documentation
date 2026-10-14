---
title: ปรับแต่งแผนภูมิกวงกลมในงานนำเสนอด้วย JavaScript
linktitle: แผนภูมิกวงกลม
type: docs
url: /th/nodejs-java/pie-chart/
keywords:
- แผนภูมิกวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการแสดงผล
- สีส่วน
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิกวงกลมใน JavaScript ด้วย Aspose.Slides for Node.js via Java กำหนดค่ากราฟรอง แสดงป้ายข้อมูล และใช้สีส่วนอัตโนมัติใน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิกวงกลมใน Aspose.Slides แสดงวิธีการกำหนดค่าตัวเลือกกราฟรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie และวิธีเปิดใช้งานการกำหนดสีส่วนอัตโนมัติสำหรับแผนภูมิกวงกลมมาตรฐาน

ตัวอย่างเน้นที่งานปรับแต่งแผนภูมิเช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับค่าชุดข้อมูลและป้ายกำกับ การแทนที่ข้อมูลแผนภูมิมาตรฐานด้วยหมวดหมู่และค่าแบบกำหนดเอง และการบันทึกงานนำเสนอที่อัปเดต

## **ตัวเลือกกราฟรองสำหรับ Pie of Pie และ Bar of Pie**

Aspose.Slides for Node.js via Java รองรับตัวเลือกกราฟรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie ตัวเลือกเหล่านี้ควบคุมขนาดของกราฟรองและวิธีที่จุดข้อมูลถูกแยกระหว่างสองกราฟ

ตัวอย่างต่อไปนี้สร้างแผนภูมิ Pie of Pie ในงานนำเสนอใหม่และแสดงค่าจุดข้อมูลเป็นป้ายกำกับ วิธี [setSecondPieSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ตั้งขนาดกราฟรองเป็น 149% ของกราฟหลัก [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) เลือกการแยกแบบเปอร์เซ็นต์ และ [setPieSplitPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) ตั้งค่าขีดจำกัดเป็น 53%

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    const series = chart.getChartData().getSeries().get_Item(0);

    // แสดงค่าและกำหนดค่ากราฟรอง.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เลือกหมวดหมู่สำหรับกราฟรอง**

ใช้การแยกแบบกำหนดเองเมื่อคุณต้องการจัดกลุ่มหมวดหมู่เฉพาะในกราฟรองโดยไม่คำนึงถึงค่าร้อยละของมัน ตัวอย่างเช่น รายงานการขายอาจแสดง Online และ Events ร่วมกันเพื่อให้ผู้อ่านเปรียบเทียบสองช่องทางนี้แม้ว่าพวกมันจะทำสัดส่วน 35% และ 10% ของยอดขายรวม

เรียก [setPieSplitBy](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setPieSplitBy) พร้อมกับ [PieSplitType.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplittype/#Custom) แล้วเลือกจุดผ่าน [getPieSplitCustomPoints](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints) วิธี [add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#add) ของคอล렉ชันรับดัชนีเริ่มต้นที่ 0 ในชุดข้อมูล; ใช้ [addItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#addItem) เพื่อเพิ่มอ็อบเจ็กต์จุดข้อมูล ในตัวอย่างนี้ ดัชนี 1 เลือก Online และจุดที่ดัชนี 3 เลือก Events Partners ถูกเพิ่มชั่วคราวแล้วลบออกด้วย [removeItem](https://reference.aspose.com/slides/nodejs-java/aspose.slides/piesplitcustompointcollection/#removeItem)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 200);

    // แทนที่ข้อมูลเริ่มต้นด้วยยอดขายตามช่องทาง.
    const workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "Retail", "Online", "Partners", "Events" ];
    const values = [ 40, 35, 15, 10 ];
    const seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    const seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(aspose.slides.PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // เลือก Online ด้วยดัชนีเริ่มต้นที่ 0 และ Events ด้วยอ็อบเจ็กต์จุดข้อมูล.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // ละเว้น Partners จากการเลือกโดยไม่ลบข้อมูลต้นทางของมัน.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) และ Events (10) ปรากฏเป็นส่วนแยกในกราฟรอง ในกราฟหลักพวกมันจะแสดงเป็นส่วนรวมค่า 45 พร้อมกับ Retail (40) และ Partners (15) การลบ Partners จากการเลือกแบบกำหนดเองทำให้มันยังคงอยู่ในกราฟหลัก; ไม่ได้ลบหมวดหมู่หรือค่าของมันออกจากข้อมูลต้นทางของแผนภูมิ

ภาพต่อไปนี้แสดงงานนำเสนอที่บันทึกใน PowerPoint:

![แผนภูมิ Pie of Pie ที่มี Online และ Events ในกราฟรองและค่ารวมของพวกมันคือ 45 ในกราฟหลัก](pie_of_pie_custom.png)

## **ตั้งค่าสีส่วนของแผนภูมิวงกลมอัตโนมัติ**

Aspose.Slides for Node.js via Java สามารถกำหนดสีที่แตกต่างให้กับส่วนของแผนภูมิกวงกลมโดยอัตโนมัติ ตัวอย่างต่อไปนี้สร้างแผนภูมิกวงกลมพร้อมหัวเรื่องตรงกลางและแทนที่ข้อมูลเริ่มต้นด้วยสามหมวดไตรมาสและค่าของพวกมัน วิธี [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) แสดงค่าตัวเลข 20, 50 และ 30 เป็นป้ายกำกับ ในขณะเดียวกัน [setColorVaried](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/#setColorVaried) เปิดใช้งานสีที่แตกต่างสำหรับแต่ละส่วน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);

    // เพิ่มหัวเรื่องแผนภูมิที่จัดกึ่งกลาง.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(java.newByte(aspose.slides.NullableBool.True));
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // แทนที่ข้อมูลเริ่มต้นด้วยการใช้แผ่นงานแรก.
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    const categoryNames = [ "First Qtr", "2nd Qtr", "3rd Qtr" ];
    const values = [ 20, 50, 30 ];
    const seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    const series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (let i = 0; i < categoryNames.length; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // แสดงค่าและกำหนดสีที่แตกต่างให้กับส่วนต่างๆ.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**รองรับการแปรรูป Pie of Pie และ Bar of Pie หรือไม่?**

ใช่, ไลบรารี [รองรับ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) กราฟรองสำหรับแผนภูมิกวงกลม รวมถึงประเภท Pie of Pie และ Bar of Pie

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ใช่, คุณสามารถ [ส่งออกแผนภูมิเพียละเป็นภาพ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) (เช่น PNG) โดยไม่ต้องส่งออกงานนำเสนอทั้งหมด