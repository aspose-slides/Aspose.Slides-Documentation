---
title: จัดการข้อมูลซีรีส์แผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: ซีรีส์ข้อมูล
type: docs
url: /th/nodejs-java/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การทับซ้อนของซีรีส์
- สีของซีรีส์
- ชื่อซีรีส์
- จุดข้อมูล
- เซลล์ workbook
- ช่องว่างของซีรีส์
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์แผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย JavaScript."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่ถูกพล็อตไว้ใน workbook ของข้อมูลแผนภูมิ ช่วงข้อมูล [ChartSeries](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/) ในชุดข้อมูลจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ของ workbook วัตถุ [ChartCategory](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartcategory/) ให้ป้ายหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยซีรีส์ ชื่อของซีรีส์, หมวดหมู่และค่าของจุดจึงถูกเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/) แทนที่จะเก็บไว้เป็นข้อความแสดงผลอย่างเดียว

สำหรับแผนภูมิตามประเภทหมวดหมู่ทั่วไป workbook เริ่มต้นจะใช้แถวที่ 0 สำหรับชื่อซีรีส์, คอลัมน์ที่ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าของซีรีส์ ดัชนี worksheet, แถวและคอลัมน์ที่ส่งให้เมธอด [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#getCell) มีค่าเริ่มต้นเป็นศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิพร้อมข้อมูลเริ่มต้น แต่ไม่ได้หมายความว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้ สำหรับงานนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่อ้างอิงโดยซีรีส์, หมวดหมู่และจุดข้อมูลก่อนทำการเปลี่ยนแปลงค่าของ workbook

การตั้งค่าแผนภูมิมีสามระดับความครอบคลุม:

- การตั้งค่าระดับซีรีส์ เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getFormat) ให้ลักษณะเริ่มต้นสำหรับจุดทั้งหมดในซีรีส์หนึ่ง
- การตั้งค่าจุดข้อมูล เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getFormat) ทำให้ลักษณะของซีรีส์ถูกแทนที่สำหรับจุดเดียว
- การตั้งค่ากลุ่มจะใช้กับซีรีส์ที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือซีรีส์อย่างชัดเจน สไตล์และธีมของแผนภูมิกำหนดลักษณะที่แสดงโดยอัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งของซีรีส์และจุดอยู่พร้อมกัน การกำหนดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของซีรีส์แผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getOverlap) รายงานระดับการทับซ้อนของแท่งหรือคอลัมน์ในแผนภูมิ 2 มิติ ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการแสดงผลแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มซีรีส์แม่ ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกซีรีส์ที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับแผนภูมิที่แสดงแท่งหรือคอลัมน์แบบจัดกลุ่ม; ไม่ส่งผลต่อกลุ่มซีรีส์ที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่ประกอบด้วยซีรีส์แรก:

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

    // แผนภูมิใหม่มีซีรีส์ตัวอย่าง, หมวดหมู่, และค่า.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getFormat) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับซีรีส์ทั้งหมด หากจุดหนึ่งมีการกำหนดสีเติมไว้แล้ว การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getFormat) ของจุดนั้นจะทับการเติมสีของซีรีส์สำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใส่สีเติมเต็มสีน้ำเงินเข้มให้กับซีรีส์แรก:

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

![The color of the series](series_color.png)

## **เปลี่ยนชื่อซีรีส์**

ชื่อซีรีส์ถูกเก็บใน workbook ของข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย (legend) ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของซีรีส์แรก ค่าคงที่ที่ตั้งชื่อตัวแปรในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getName) วิธีนี้ช่วยหลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![The series name](series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีซีรีส์และสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมสีของซีรีส์ไม่ได้กำหนดไว้โดยชัดเจน การเรียกเมธอดนี้จะอ่านสีที่คำนวณได้; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละซีรีส์เริ่มต้น:

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

ตัวอย่างผลลัพธ์สำหรับสไตล์แผนภูมิเบื้องต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้จะขึ้นกับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับด้านสำหรับซีรีส์แผนภูมิ**

สำหรับซีรีส์แท่ง, คอลัมน์และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าลบด้วยสีเติมที่แตกต่างกัน ตั้งค่าสีเติมของซีรีส์เป็นสีทึบ, เปิดการกลับด้าน, และกำหนดสีค่าลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ตัวเลขลบจะยังคงอยู่ใน workbook; เพียงสีที่แสดงที่เปลี่ยนแปลง

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยซีรีส์หนึ่งซีรีส์ แถว worksheet 0 มีชื่อซีรีส์, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ตัวอย่างต่อไปนี้ปิดการกลับด้านสำหรับซีรีส์และเปิดเฉพาะสำหรับจุดที่เลือก จุดนั้นยังถูกกำหนดให้มีค่าเป็นลบเพื่อให้เห็นผล:

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

## **ลบค่าของจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ workbook ที่เป็นฐานของจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตสามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#getValue) จุดข้อมูลจะคงอยู่ที่ตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจะถือค่านั้นเป็นค่าว่างตามการตั้งค่าแสดงค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในซีรีส์แรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดเพิ่มเติม ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapointcollection/#clear) เวลาต้องการคงจุดอื่นไว้ เพราะเมธอดนี้จะลบทุกจุดข้อมูลจากคอลเลกชัน

## **ตั้งค่าความกว้างช่องว่างของซีรีส์**

ความกว้างช่องว่างคือระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน แทนเป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มซีรีส์แม่ ไม่ใช่ของซีรีส์เดียว ใช้ [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) เพียงครั้งเดียวสำหรับกลุ่ม ค่าที่ใหญ่ขึ้นจะทำให้ช่องว่างระหว่างกลุ่มมากขึ้น; ค่าที่เล็กลงจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกเพียงงานนำเสนอสุดท้าย:

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

![The gap width](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่สนับสนุนซีรีส์ข้อมูล?**

ทุกประเภทแผนภูมิที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ซีรีส์ของพวกมันไม่ได้มีโครงสร้างหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทของซีรีส์ ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มแท่งหรือคอลัมน์ที่เข้ากันได้

**กลุ่มซีรีส์แผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/) ประกอบด้วยซีรีส์ที่เข้ากันได้และแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านซีรีส์หนึ่งอาจไม่ได้เปลี่ยนแปลงทุกซีรีส์ในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยค่าเริ่มต้น [ShapeCollection.addChart](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addChart) จะสร้างซีรีส์, หมวดหมู่และค่าตัวอย่าง คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งคอลเลกชันซีรีส์และหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองแบบเต็ม ๆ อีกทางเลือกหนึ่งคือการใช้ overload ที่สร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**วัตถุแผนภูมิเชื่อมโยงกับเซลล์ workbook อย่างไร?**

ชื่อซีรีส์, ป้ายหมวดหมู่และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิเกี่ยวข้อง เมื่อต้องสร้างข้อมูลแบบกำหนดเอง ใหักำหนดแถวหมวดหมู่และแถวค่าของซีรีส์ให้สอดคล้องกันเพื่อให้แต่ละจุดถูกพล็อตภายใต้หมวดหมู่ที่ต้องการ

**ฉันจะลบจุดเดียวโดยไม่ลบทั้งซีรีส์ได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อคงตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากซีรีส์นั้น หากคุณลบหมวดหมู่ด้วย ให้ปรับปรุงทุกซีรีส์เพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างจะแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) แผนภูมิที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่า 0, หรือโดยการเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลหายในงานนำเสนอของคุณ

**ค่าลบจะถูกฟอร์แมตอย่างไร?**

สำหรับซีรีส์แท่ง, คอลัมน์และบับเบิลที่สนับสนุน ให้เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#setInvertIfNegative) และตั้งค่าสีที่คืนจาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/#getInvertedSolidFillColor) คุณสามารถแทนที่พฤติกรรมสำหรับจุดเดียวโดยใช้ [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatapoint/#setInvertIfNegative) วิธีเหล่านี้ส่งผลต่อการฟอร์แมต ไม่กระทบต่อค่าตัวเลขที่จัดเก็บ

**รูปแบบใดชนะเมื่อทั้งซีรีส์และจุดถูกฟอร์แมต?**

การฟอร์แมตจุดข้อมูลอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ จะใช้รูปแบบของซีรีส์ที่กำหนดไว้หรือหากไม่ได้กำหนดรูปแบบซีรีส์ ระบบจะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การแทนที่ระดับจุด

**แผนภูมิสามารถมีซีรีส์ได้มากเท่าใด?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนซีรีส์แบบคงที่ อย่างไรก็ตาม ข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่เหมาะสมในทางปฏิบัติ

**ควรเปลี่ยนอะไรเมื่อคอลัมน์อยู่ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มซีรีส์แม่ที่เหมาะสม เพิ่มค่ากว่าเพื่อขยายช่องว่างระหว่างกลุ่ม หรือ ลดค่าเพื่อทำให้กลุ่มเข้าหากันมากขึ้น