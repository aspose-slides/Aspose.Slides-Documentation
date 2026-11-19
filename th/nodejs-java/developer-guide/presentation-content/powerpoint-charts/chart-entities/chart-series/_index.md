---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: ชุดข้อมูล
type: docs
url: /th/nodejs-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์สมุดงาน
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย JavaScript."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่พล็อตไว้ในเซลล์ของสมุดงานหรือโดยตรงเป็นค่าตัวเลขลิตเตอรัลได้ A [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) แสดงจุดในชุดนั้น. วัตถุ [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) ให้ป้ายชื่อหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล. ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น, ชื่อชุด, หมวดหมู่, และค่าจุดใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) จากสมุดงานของแผนภูมิ.

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป, สมุดงานเริ่มต้นใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนี Worksheet, แถว, และคอลัมน์ที่ส่งให้ [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) นับจากศูนย์. การจัดวางนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสมมติว่าทุกแผนภูมิที่มีอยู่ใช้แบบนี้. สำหรับงานนำเสนอที่โหลดแล้ว, ตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนเปลี่ยนค่าของสมุดงาน.

การตั้งค่าแผนภูมิมีสามขอบเขตที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), ให้รูปลักษณ์เริ่มต้นสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), จะเขียนทับรูปลักษณ์ของชุดสำหรับจุดเดียว.
- การตั้งค่ากลุ่มใช้กับชุดที่เข้ากันได้ซึ่งเป็นสมาชิกของ [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างช่องว่าง.

เมื่อไม่มีการกำหนดการเติมจุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิกำหนดรูปลักษณ์อัตโนมัติ. เมื่อมีการจัดรูปแบบชุดและจุดพร้อมกัน, การจัดรูปแบบจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![แผนภูมิซีรีส์ PowerPoint](chart-series-powerpoint.png)

สำหรับแผนภูมิลูกบาศก์แบบจัดกลุ่ม, ดูว่า [การเปลี่ยนประเภทชุด 3D หรือรูปทรงแถบ](/slides/th/nodejs-java/3d-chart/#change-the-3d-series-type-and-bar-shape) มีผลต่อชุดแรกอย่างไร.

## **ตั้งค่าค่าชุดโดยใช้ค่าตัวเลขลิตเตอรัล**

ใช้ค่าตัวเลขลิตเตอรัลเมื่อค่าชุดมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ของ worksheet. เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) พร้อมกับ [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) ก่อนกำหนดผลลัพธ์ของ [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) ของแต่ละจุดผ่าน [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งข้อมูลของค่าจุดทั้งหมดในชุดนั้น. วิธีการ [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) ของค่าจุดแต่ละค่าแสดงประเภทที่เลือก; เปลี่ยนผ่านการตั้งค่าคอลเลกชัน. ด้วย `Worksheet`, ใช้ [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) เพื่อเข้าถึงเซลล์ที่อ้างอิง. ด้วย `DoubleLiterals`, ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนจำนวนโดยตรง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและหมวดหมู่เริ่มต้น, จากนั้นกำหนดค่าที่คำนวณได้ 10, 20, ฯลฯ ให้กับจุดที่มีอยู่ของชุดแรก. มันบันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่จัดเก็บไว้.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(aspose.slides.DataSourceType.DoubleLiterals);
    for (let i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("numeric_literals.pptx");
try {
    const reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    const reopenedChart = reopenedSlide.getShapes().get_Item(0);
    const reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (let i = 0; i < reopenedSeries.getDataPoints().size(); i++) {
        const point = reopenedSeries.getDataPoints().get_Item(i);
        console.log(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

ประเภทแหล่งข้อมูลของค่าจุดแยกจาก [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), ซึ่งระบุการกำหนดค่า workbook ภายในหรือภายนอกของแผนภูมิ. การใช้ค่าตัวเลขลิตเตอรัลไม่ได้ลบ workbook ที่ฝังอยู่โดยอัตโนมัติ. ในตัวอย่างนี้, workbook ยังคงใช้ได้สำหรับป้ายชื่อหมวดหมู่, ชื่อชุด, และชุดอื่น ๆ. ดู [Chart Workbook](/slides/th/nodejs-java/chart-workbook/) สำหรับการจัดการ workbook.

สำหรับแผนภูมิกระจายและฟองอากาศ, ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) เพื่อเลือกแหล่งสำหรับ [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) และ [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). แผนภูมิบับอากาศยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). ตั้งค่าแหล่งที่เกี่ยวข้องแต่ละอันเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่าดังกล่าว.

## **ตั้งค่าการทับของชุดแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) รายงานว่าบาร์หรือคอลัมน์ทับกันเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. นี่เป็นการฉายแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มชุดแม่. ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่กระทบกับกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิกำลังผสม.

ตัวอย่างต่อไปนี้ตั้งค่าการทับสำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น:

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

    // แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่และค่า.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) เพื่อกำหนดการเติมเริ่มต้นสำหรับชุดทั้งหมด. หากจุดใดมีการเติมอย่างชัดเจนแล้ว, การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) ของจุดนั้นจะเขียนทับการเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าเข้มแบบทึบกับชุดแรก:

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

![สีของชุด](series_color.png)

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกจัดเก็บในสมุดงานข้อมูลแผนภูมิและโดยทั่วไปจะแสดงในคำอธิบาย. ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบจัดกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่ [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) อ้างอิงอยู่ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อชุด](series_name.png)

### **สร้างชุดด้วยชื่อจากหลายเซลล์**

ชื่อชุดเชิงผสมมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานเก็บไว้ในเซลล์สมุดงานแยกกัน. ตัวอย่างเช่น, คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวขณะยังคงเชื่อมต่อทั้งสองส่วนกับเซลล์ต้นทางของพวกมัน.

ใช้ [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) เพื่อดึงช่วงชื่อ, จากนั้นส่งคอลเลกชันนั้นให้กับ [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). อาร์กิวเมนต์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนหรือไม่: `true` ไม่รวม, `false` รวม. ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ.

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีชุดหนึ่งและจุดข้อมูลสองจุด. เซลล์ B1:C1 ใช้เพื่อใส่ชื่อชุดเท่านั้น; A2:A3 ใช้สำหรับป้ายชื่อหมวดหมู่, และ B2:B3 ใช้สำหรับค่าตัวเลข.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // เซลล์สองเซลล์นี้ใช้สำหรับชื่อชุด.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // เซลล์แยกกันใช้สำหรับหมวดหมู่และจุดข้อมูลตัวเลข.
    const northCategory = workbook.getCell(0, 1, 0, "North");
    const southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    const northValue = workbook.getCell(0, 1, 1, 120);
    const southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ชื่อชุดที่ได้คือ `Product A 2026`, มีช่องว่างระหว่างค่าจากสองเซลล์. คำอธิบายแสดงผลเป็นรายการเดียวสำหรับทั้งสองคอลัมน์. ภาพด้านล่างแสดงผลลัพธ์:

![แผนภูมิคอลัมน์ที่มีค่าภาคเหนือและภาคใต้และชื่อชุดเชิงผสม Product A 2026 ในคำอธิบาย](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ. นี่คือสีที่ใช้เมื่การเติมชุดไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดนี้อ่านสีที่คำนวณได้; ไม่ได้กำหนดการเติมใหม่.

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แม่นยำขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และฟองอากาศ, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) สามารถแสดงค่าติดลบด้วยการเติมที่ต่างออกไป. ตั้งค่าการเติมของชุดเป็นแบบทึบ, เปิดการกลับสี, และกำหนดสีค่าติดลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). ตัวเลขลบจะคงอยู่ใน workbook อย่างไม่มีการเปลี่ยนแปลง; มีเพียงสีการแสดงที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดหนึ่ง. แถว 0 ของ Worksheet มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![สีเติมแข็งกลับทิศ](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับสีสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). ในตัวอย่างต่อไปนี้, การกลับสีถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก. จุดนั้นยังถูกกำหนดค่าติดลบเพื่อให้เห็นผล:

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

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์ workbook ที่เป็นฐานของจุดนั้นเป็น `null`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตสามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). จุดข้อมูลจะอยู่ที่ตำแหน่งหมวดหมู่เดิม, แต่แผนภูมิจะถือค่าของมันเป็นค่าว่างตามการตั้งค่าค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับอากาศยังใช้เซลล์ขนาด. ให้ลบเฉพาะเซลล์ที่แสดงค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่น ๆ, เพราะเมธอดนั้นจะลบทุกจุดข้อมูลจากคอลเลกชัน.

## **ควบคุมการแสดงเซลล์ว่าง**

เซลล์ที่ซ่อนซึ่งมีค่าเป็นกรณีแยกจากเซลล์ว่าง. เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ของ worksheet ที่ซ่อน, ดู [Include Data from Hidden Rows and Columns](/slides/th/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์ workbook ว่างแสดงถึงข้อมูลที่หายไป; เซลล์ที่มี `0` แสดงถึงค่าตัวเลขที่ทราบ. เรียก [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) พร้อม `null` เพื่อทำให้เซลล์ว่าง. ศูนย์ตัวเลขจะยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นแบบใด.

ใช้ [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) เพื่อเลือกว่ากราฟจะแสดงเซลล์ว่างอย่างไร. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่ต้องเติมค่า `0` หรือค่าประมาณในเซลล์ workbook ที่ว่าง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดเดียว, ลบค่าของ Day 3, และบันทึกแผนภูมิกับแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายชื่อหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 มีชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

    // ทำให้วัน 3 ว่างจริง ๆ แต่ยังคงรักษาหมวดหมู่และจุดข้อมูลของมันไว้.
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

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, ให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปตามโหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม. Day 3 ว่างใน workbook ทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap แบ่งเส้นที่วัน 3, Zero ลดเส้นลงเป็นศูนย์, และ Span เชื่อมวัน 2 กับวัน 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้สามโหมดทั้งหมดเปรียบเทียบได้ง่าย. แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมข้ามหมวดหมู่ที่หายไป, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมที่แสดงข้างต้น; คอลัมน์ที่หายไปและคอลัมน์สูงศูนย์อาจดูคล้ายกัน. เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์, ไม่มีเส้นเชื่อม. อย่าคาดหวังผลลัพธ์สามแบบที่แตกต่างกันสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือพื้นที่ระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มันเป็นของกลุ่มชุดแม่ ไม่ใช่ของชุดเดียว. เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) หนึ่งครั้งสำหรับกลุ่ม. ค่าที่ใหญ่ขึ้นจะสร้างพื้นที่ระหว่างกลุ่มมากขึ้น; ค่าที่เล็กลงจะทำให้กลุ่มหนาแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกงานนำเสนอขั้นสุดท้ายเท่านั้น:

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

## **แสดงหรือซ่อนเส้นชุด**

เส้นชุดเชื่อมต่อส่วนที่เกี่ยวข้องของแผนภูมิให้มองเห็นได้. ใช้ [ChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setserieslines/) เพื่อแสดงหรือซ่อนเส้นเหล่านี้ในแผนภูมิแถบซ้อนและ OfPie ที่รองรับ. ในแผนภูมิแถบและคอลัมน์ซ้อนสองมิติ, เส้นเหล่านี้เชื่อมขอบสแต็คที่สอดคล้องกันข้ามหมวดหมู่. ในแผนภูมิ Pie of Pie และ Bar of Pie, เส้นเชื่อมพล็อตหลักกับพล็อตรอง. การตั้งค่านี้ไม่ใช่ตัวเชื่อมแบบทั่วไปสำหรับประเภทแผนภูมิอื่น ๆ.

เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). การตั้งค่านี้ใช้กับทุกชุดในกลุ่มนั้น. [ChartSeries.hasSeriesLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/hasserieslines/) เป็นแบบอ่านอย่างเดียวและสะท้อนการตั้งค่ากลุ่มแม่; เรียกตัวตั้งค่ากลุ่มเพื่ออัปเดต.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [PieOfPie](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) หนึ่งอันด้วยข้อมูลเริ่มต้น. มันบันทึกแผนภูมิเดียวกันโดยเปิดใช้งานเส้นชุดแล้วปิดเส้นชุด, ผลลัพธ์เป็นงานนำเสนอสองไฟล์สำหรับเปรียบเทียบ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 600, 400);
    const series = chart.getChartData().getSeries().get_Item(0);
    const seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", aspose.slides.SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| เส้นชุดเปิดใช้งาน | เส้นชุดปิดใช้งาน |
| --- | --- |
| ![แผนภูมิ Pie of Pie ที่เปิดใช้งานเส้นชุด](series_lines_enabled.png) | ![แผนภูมิ Pie of Pie ที่ปิดใช้งานเส้นชุด](series_lines_disabled.png) |
| สองเส้นเชื่อมพายหลักกับพายรอง. | พายทั้งสองยังคงมองเห็นได้ แต่เส้นเชื่อมถูกซ่อน. |

เส้นชุดแตกต่างจากเส้นนำของป้ายข้อมูล, ซึ่งเชื่อมป้ายกับจุดข้อมูล; เส้นกริด, ซึ่งทำเครื่องหมายช่วงบนแกนของแผนภูมิ; และเส้นในแผนภูมิเส้น, ซึ่งแสดงค่าข้อมูล. การตั้งค่านี้ไม่ควบคุมองค์ประกอบเหล่านั้น.

## **FAQ**

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงในenumeration [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น, แผนภูมิประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับอากาศเพิ่มขนาดฟอง. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด. ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มชุดแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้ซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่มร่วมกัน. แผนภูมิกำลังผสมสามารถมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มที่เข้าถึงผ่านชุดหนึ่งไม่ได้จำเป็นต้องเปลี่ยนแปลงทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. ตามค่าเริ่มต้น, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) สร้างชุด, หมวดหมู่, และค่าแบบตัวอย่าง. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองโดยสมบูรณ์. มี overload ที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้เช่นกัน.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ของ workbook อย่างไร?**

ชื่อชุด, ป้ายชื่อหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงอัปเดตองค์ประกอบแผนภูมิตรงนั้น. เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, รักษาแถวของหมวดหมู่และแถวของค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ต้องการ.

**ทำอย่างไรจึงจะลบจุดเดียวแทนการลบชุดทั้งหมด?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น. หากคุณลบหมวดหมู่พร้อมกัน, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่า 0, หรือโดยการเชื่อมจุดใกล้เคียงกัน. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ. ดู [ควบคุมการแสดงเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบแบบภาพ.

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และฟองอากาศที่รองรับ, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) และกำหนดสีที่คืนจาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). คุณสามารถเขียนทับพฤติกรรมสำหรับจุดหนึ่งได้ด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). วิธีเหล่านี้มีผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ.

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ จะใช้รูปแบบชุดที่กำหนดหรือ, หากไม่มีการกำหนดรูปแบบชุด, จะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การเขียนทับระดับจุด.

**มีขีดจำกัดจำนวนชุดที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนชุดแยกจากไฟล์งานนำเสนอ, หน่วยความจำที่ใช้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิเป็นปัจจัยที่กำหนดขีดจำกัดที่เป็นประโยชน์ในทางปฏิบัติ.

**ควรปรับอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) บนกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, หรือลดค่าเพื่อทำให้กลุ่มใกล้เคียงกันมากขึ้น.