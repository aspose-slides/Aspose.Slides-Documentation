---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอโดยใช้ JavaScript
linktitle: ชุดข้อมูล
type: docs
url: /th/nodejs-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุด
- ค่าลบ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การซ้อน, ความกว้างช่องว่าง, และค่าลบในงานนำเสนอด้วย JavaScript."
---
## **ภาพรวม**

แผนภูมิเก็บข้อมูลที่พล็อตไว้ในหนังสือข้อมูลแผนภูมิ (Chart Data Workbook)  [ChartSeries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/) ในชุดนั้นอ้างอิงถึงเซลล์ใน workbook หนึ่งหรือหลายเซลล์  [ChartCategory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันระหว่างชุดข้อมูล ชื่อชุดข้อมูล, ประเภท, และค่าจุดจึงเชื่อมโยงกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/) แทนที่จะเก็บเป็นข้อความแสดงผลอย่างเดียว

สำหรับแผนภูมิกลุ่มประเภททั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อประเภท, และเซลล์ที่เหลือสำหรับค่าของชุด ดัชนีแถว, คอลัมน์, และแผ่นงานที่ส่งให้ [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#getCell) นับจากศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับงานนำเสนอที่โหลดมาแล้ว ให้ตรวจสอบเซลล์ที่ชุดข้อมูล, ประเภท, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของ workbook

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getFormat) ให้ลักษณะการแสดงผลเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าจุดข้อมูล เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getFormat) จะเขียนทับลักษณะของชุดสำหรับจุดเดียว
- การตั้งค่าแบบกลุ่มใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการกำหนดตัวเลือกเช่นการซ้อนกันหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดอย่างชัดเจน รูปแบบและธีมของแผนภูมิกำหนดลักษณะอัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งชุดและจุดพร้อมกัน การกำหนดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![แผนภูมิซีรีส์ PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่าการซ้อนของชุดแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ซ้อนกันมากแค่ไหนในแผนภูมิ 2 มิติ ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการอ่านค่าจากการตั้งค่ากลุ่มชุดพาเรนท์ ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิโปรดักต์

ตัวอย่างต่อไปนี้ตั้งค่าการซ้อนสำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const overlapPercent = java.newByte(30);

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    // แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่, และค่า.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การซ้อนของชุดข้อมูล](series_overlap.png)

## **เปลี่ยนสีเติมของชุดแผนภูมิ**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getFormat) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับชุดทั้งหมด หากจุดหนึ่งมีการกำหนดการเติมสีไว้แล้ว การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getFormat) จะเขียนทับการเติมสีของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีทึบสีน้ำเงินกับชุดแรก:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const blueColor = java.getStaticFieldValue("java.awt.Color", "BLUE");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(blueColor);

    presentation.save("series_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สีของชุดข้อมูล](series_color.png)

## **เปลี่ยนชื่อชุดแผนภูมิ**

ชื่อชุดถูกเก็บในหนังสือข้อมูลแผนภูมิและมักจะแสดงในคำอธิบาย (legend) ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 คือแถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก ตัวแปรคงที่ในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const seriesNameRowIndex = 0;
const firstSeriesColumnIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getName) วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const firstNameCellIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ชื่อชุดข้อมูล](series_name.png)

## **รับสีเติมอัตโนมัติของชุดแผนภูมิ**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีชุดและรูปแบบแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมสีของชุดไม่ได้กำหนดโดยชัดแจ้ง การเรียกเมธอดจะอ่านสีที่คำนวณได้; ไม่ได้กำหนดการเติมสีใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const seriesCount = chart.getChartData().getSeries().size();
    for (let seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const automaticColor = series.getAutomaticSeriesColor();
        const automaticColorText = automaticColor.toString();
        console.log("Series " + seriesIndex + ": " + automaticColorText);
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ตัวอย่างสำหรับรูปแบบแผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แน่นอนขึ้นอยู่กับรูปแบบและธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าการเติมสีของชุดเป็นแบบทึบ, เปิดการกลับสี, แล้วกำหนดสีค่าลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ตัวเลขลบจะยังคงอยู่ใน workbook; เพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยชุดเดียว แผ่นงานแถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อประเภท, และคอลัมน์ 1 มีค่าต่าง ๆ:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const worksheetIndex = 0;
const headerRowIndex = 0;
const categoryColumnIndex = 0;
const firstSeriesColumnIndex = 1;
const firstDataRowIndex = 1;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const categoryNames = ["Category 1", "Category 2", "Category 3"];
const seriesValues = [-20, 50, -30];

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    const chartType = chart.getType();
    const series = chartData.getSeries().add(seriesNameCell, chartType);

    for (let categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        const dataRowIndex = firstDataRowIndex + categoryIndex;
        const categoryName = categoryNames[categoryIndex];
        const seriesValue = seriesValues[categoryIndex];

        const categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        const valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(redColor);

    presentation.save("inverted_solid_fill_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สีเติมทึบกลับด้าน](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับสีสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ในตัวอย่างต่อไปนี้ การกลับสีจะถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก พร้อมกำหนดค่าติดลบเพื่อให้เห็นผล:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 2;
const negativeValue = -30;
const solidFillType = java.newByte(aspose.slides.FillType.Solid);
const redColor = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(solidFillType);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(redColor);
    series.setInvertIfNegative(false);

    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ล้างค่าเฉพาะของจุดข้อมูล**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ workbook ที่รองรับเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getValue) จุดข้อมูลจะคงอยู่ที่ตำแหน่งประเภทเดียวกัน แต่แผนภูมิจะถือค่าของมันเป็นค่าว่างตามการตั้งค่าการแสดงค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองของชุดแรก:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const targetDataPointIndex = 1;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    const dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

แผนภูมิกระจกใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapointcollection/#clear) เมื่อคุณต้องการเก็บจุดอื่นไว้ เพราะเมธอดนั้นจะลบทุกจุดในคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่แต่มีค่าเป็นกรณีที่แยกจากเซลล์ว่าง หากต้องการรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างเปล่าหมายถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` หมายถึงตัวเลขที่ทราบอยู่ เรียก [ChartDataCell.setValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#setValue) ด้วย `null` เพื่อทำให้เซลล์ว่าง ค่าศูนย์ตัวเลขจะคงเป็นศูนย์ไม่ว่าจะตั้งค่าว่างอย่างไร

ใช้ [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด เปลี่ยนวิธีที่จุดว่างถูกพล็อตโดยไม่ต้องเติมค่า `0` หรือค่าประมาณในเซลล์ workbook

ตัวอย่างต่อไปนี้เป็นโค้ดเดียวสร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าของวัน 3, แล้วบันทึกแผนภูมิในแต่ละโหมด ไม่ต้องมีไฟล์อินพุต [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายประเภท, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 40, 40, 640, 400);
    const chartData = chart.getChartData();
    const workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    const seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    const series = chartData.getSeries().add(seriesNameCell, chart.getType());
    const values = [10, 20, 25, 30, 40];

    for (let i = 0; i < values.length; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // ปล่อยให้วัน 3 ว่างจริง ๆ ในขณะที่ยังคงประเภทและจุดข้อมูลของมันไว้.
    workbook.getCell(0, 3, 1).setValue(null);

    const modes = [aspose.slides.DisplayBlanksAsType.Gap, aspose.slides.DisplayBlanksAsType.Zero, aspose.slides.DisplayBlanksAsType.Span];
    const modeNames = ["Gap", "Zero", "Span"];
    for (let i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเวอร์ชันเดียวให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอเพียงครั้งเดียวแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในสามไฟล์ วัน 3 ว่างใน workbook ในทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่วัน 3, Zero ทำให้เส้นลงเป็นศูนย์, และ Span เชื่อมวัน 2 ไปวัน 4.](display_blanks_as.png)

ผลที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้สามโหมดเปรียบเทียบได้ง่าย แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมระหว่างประเภทที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมได้; คอลัมน์ที่หายไปและคอลัมน์ศูนย์อาจดูคล้ายกัน ด้านเดียวกัน แผนภูมิกระจกที่มีแค่เครื่องหมายก็ไม่มีเส้นเชื่อม ไม่ควรคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุด**

ช่องว่าง (Gap width) คือระยะระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการซ้อน มันเป็นของกลุ่มชุดพาเรนท์ ไม่ใช่ของชุดเดียว เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) ครั้งเดียวสำหรับกลุ่ม ค่าที่ใหญ่ขึ้นทำให้ช่องว่างระหว่างกลุ่มเพิ่มขึ้น; ค่าที่เล็กลงทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกเฉพาะงานนำเสนอสุดท้าย:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const firstSlideIndex = 0;
const firstSeriesIndex = 0;
const gapWidthPercent = 30;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(firstSlideIndex);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ความกว้างช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดสนับสนุนชุดข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่ระบุโดย [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของแต่ละประเภทอาจมีโครงสร้างค่าและการตั้งค่าต่างกัน ตัวอย่างเช่น แผนภูมิกลุ่มใช้ประเภทและค่า, แผนภูมิกระจกใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่สอดคล้องกับประเภทของชุด ตัวเลือกเช่นการซ้อนและความกว้างช่องว่างใช้ได้กับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้เท่านั้น

**กลุ่มชุดแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีหลายกลุ่ม ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งไม่ได้หมายความว่าจะเปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี โดยค่าเริ่มต้น [ShapeCollection.addChart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addChart) จะสร้างชุดตัวอย่าง, ประเภท, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดและประเภทก่อนเพิ่มชุดข้อมูลแบบกำหนดเองได้ คำสั่ง overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**แผนภูมิต่อเชื่อมกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายประเภท, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/) การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อสร้างข้อมูลกำหนดเอง ควรรักษาแถวประเภทและแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้ประเภทที่ต้องการ

**จะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อเก็บตำแหน่งประเภทของจุดเป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อต้องการลบทุกจุดในชุดนั้น หากคุณลบประเภทด้วย ควรอัปเดตทุกชุดเพื่อให้ค่าตรงกับคอลเลกชันประเภท

**จุดว่างแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, ค่าเป็นศูนย์, หรือเชื่อมจุดใกล้เคียงกัน เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอ ดูที่ [ควบคุมการแสดงเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าลบจะถูกฟอร์แมตอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ ให้เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) และตั้งค่าสีที่ได้จาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) วิธีเหล่านี้ส่งผลต่อการฟอร์แมต ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ

**การฟอร์แมตใดชนะเมื่อทั้งชุดและจุดถูกฟอร์แมต?**

การฟอร์แมตจุดข้อมูลโดยตรงมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ ยังคงใช้ฟอร์แมตชุดที่กำหนดไว้หรือหากไม่มีการกำหนดชุด จะใช้รูปแบบและธีมของแผนภูมิโดยอัตโนมัติ การตั้งค่ากลุ่มเช่นการซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การฟอร์แมตระดับจุด

**แผนภูมิสามารถมีชุดได้สูงสุดเท่าไหร่?**

Aspose.Slides ไม่จำกัดจำนวนชุดโดยตรง ขีดจำกัดจริงขึ้นอยู่กับข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่ใช้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มชุดพาเรนท์ที่เกี่ยวข้อง เพิ่มค่าที่กำหนดเพื่อขยายช่องว่างระหว่างกลุ่ม หรือ ลดค่าเพื่อทำให้กลุ่มใกล้กันมากขึ้น