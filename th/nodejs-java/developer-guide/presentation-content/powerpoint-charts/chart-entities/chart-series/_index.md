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
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย JavaScript."
---
## **ภาพรวม**

แผนภูมิสามารถจัดเก็บค่าที่พล็อตไว้ในเซลล์ของเวิร์กบุ๊กหรือโดยตรงเป็นค่าตัวเลขลิเทอรัล. [ChartSeries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/) แทนจุดหนึ่งในชุดนั้น. วัตถุ [ChartCategory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/) ให้ป้ายกำกับหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล. ในแผนภูมิที่สร้างด้วยข้อมูลค่าเริ่มต้น, ชื่อชุดข้อมูล, หมวดหมู่, และค่าจุดใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/) จากเวิร์กบุ๊กของแผนภูมิ.

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป, เวิร์กบุ๊กค่าเริ่มต้นใช้แถว 0 สำหรับชื่อซีรีส์, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าซีรีส์. ดัชนี Worksheet, row, และ column ที่ส่งไปยัง [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcell/) มีค่าเริ่มต้นจากศูนย์. การจัดวางนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลค่าเริ่มต้น, แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้แบบนี้. สำหรับพรีเซนเทชันที่โหลดมา, ตรวจสอบเซลล์ที่อ้างอิงโดยซีรีส์, หมวดหมู่, และจุดข้อมูลก่อนที่จะแก้ไขค่าของเวิร์กบุ๊ก.

การตั้งค่าแผนภูมิมีสามขอบเขตที่แตกต่างกัน:

- การตั้งค่าระดับซีรีส์, เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/), กำหนดลักษณะเริ่มต้นสำหรับทุกจุดในซีรีส์เดียว.
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/), จะทับลักษณะของซีรีส์สำหรับจุดหนึ่ง.
- การตั้งค่ากลุ่มใช้กับซีรีส์ที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/). เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง.

เมื่อไม่มีการกำหนดการเติมจุดหรือซีรีส์โดยชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. เมื่อทั้งการจัดรูปแบบของซีรีส์และจุดมีอยู่, การจัดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![แผนภูมิ-ซีรีส์-พาวเวอร์พอยท์](chart-series-powerpoint.png)

## **ตั้งค่าค่าซีรีส์โดยใช้ค่าตัวเลขลิเทอรัล**

ใช้ค่าตัวเลขลิเทอรัลเมื่อค่าซีรีส์มาจากข้อมูลหรือการคำนวนของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ใน Worksheet. เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforvalues/) พร้อมกับ [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) ก่อนกำหนดผลลัพธ์ของ [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/) ของแต่ละจุดผ่าน [setAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/setasliteraldouble/).

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งที่มาของค่าทุกจุดในซีรีส์นั้น. วิธีการ [getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/basechartvalue/) ของค่าจุดแต่ละค่ารายงานประเภทที่เลือก; เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน. เมื่อใช้ `Worksheet`, ใช้ [getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getascell/) เพื่อเข้าถึงเซลล์ที่อ้างอิง. เมื่อใช้ `DoubleLiterals`, ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/nodejs-java/aspose.slides/doublechartvalue/getasliteraldouble/) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยซีรีส์และหมวดหมู่ค่าเริ่มต้น, แล้วกำหนดค่าที่คำนวนได้ของ 10, 20, เป็นต้นให้กับจุดที่มีอยู่ของซีรีส์แรก. จากนั้นบันทึกพรีเซนเทชัน, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่ถูกเก็บไว้.

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

ประเภทแหล่งที่มาของค่าจุดแยกจาก [ChartData.getDataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), ซึ่งบ่งบอกการกำหนดค่าเวิร์กบุ๊กภายในหรือภายนอกของแผนภูมิ. การใช้ค่าตัวเลขลิเทอรัลโดยตัวมันเองไม่ได้ลบเวิร์กบุ๊กที่ฝังอยู่. ในตัวอย่างนี้, เวิร์กบุ๊กยังคงใช้ได้สำหรับป้ายกำกับหมวดหมู่, ชื่อซีรีส์, และซีรีส์อื่น ๆ. ดูที่ [Chart Workbook](/slides/th/nodejs-java/chart-workbook/) สำหรับการจัดการเวิร์กบุ๊ก.

สำหรับแผนภูมิกระจายและบับเบิล, ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforxvalues/) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforyvalues/) เพื่อเลือกแหล่งที่มาสำหรับ [getXValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getxvalue/) และ [getYValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getyvalue/). แผนภูมิบับเบิลยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/setdatasourcetypeforbubblesizes/) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getbubblesize/). ตั้งค่าแหล่งที่มาที่เกี่ยวข้องเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่าที่เลือก.

## **ตั้งค่าการทับซ้อนของซีรีส์แผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getoverlap/) รายงานว่าคอลัมน์หรือแถบทับซ้อนกันเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. นี่คือการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มซีรีส์แม่. ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) เพื่ออัปเดตทุกซีรีส์ที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงแถบหรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มซีรีส์ที่ไม่เกี่ยวข้องในแผนภูมิกระบวนการรวม.

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีซีรีส์แรก:

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

    // แผนภูมิใหม่ประกอบด้วยซีรีส์ตัวอย่าง, หมวดหมู่, และค่า.
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 200);

    const series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การทับซ้อนของซีรีส์](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getformat/) เพื่อกำหนดสีเติมเริ่มต้นสำหรับทั้งซีรีส์. หากจุดหนึ่งมีการกำหนดสีเติมโดยชัดเจนแล้ว, การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getformat/) ของจุดนั้นจะทับซ้อนสีเติมของซีรีส์สำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมสีน้ำเงินทึบกับซีรีส์แรก:

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

![สีของซีรีส์](series_color.png)

## **เปลี่ยนชื่อซีรีส์**

ชื่อซีรีส์ถูกเก็บไว้ในเวิร์กบุ๊กข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย. ในเวิร์กบุ๊กค่าเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของซีรีส์แรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getname/) ได้. วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อของซีรีส์](series_name.png)

### **สร้างซีรีส์ด้วยชื่อจากหลายเซลล์**

ชื่อซีรีส์แบบผสมเป็นประโยชน์เมื่อชื่อสินค้าและช่วงเวลาการรายงานถูกเก็บในเซลล์เวิร์กบุ๊กแยกกัน. ตัวอย่างเช่น, คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อซีรีส์เดียวในขณะที่ยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทางของมัน.

ใช้ [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getcellcollection/) เพื่อดึงช่วงชื่อ, แล้วส่งคอลเลกชันนั้นไปยัง [ChartSeriesCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriescollection/add/). พารามิเตอร์ `skipHiddenCells` ควบคุมว่ารวมเซลล์ซ่อนอยู่หรือไม่: `true` จะไม่รวม, `false` จะรวม. ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ.

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่มีซีรีส์หนึ่งและจุดข้อมูลสองจุด. เซลล์ B1:C1 มีเฉพาะชื่อซีรีส์; A2:A3 มีป้ายกำกับหมวดหมู่, และ B2:B3 มีค่าตัวเลข.

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

    // เซลล์สองนี้เป็นตัวกำหนดชื่อซีรีส์.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    const nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    const series = chart.getChartData().getSeries().add(nameCells, aspose.slides.ChartType.ClusteredColumn);

    // เซลล์แยกต่างหากเป็นตัวกำหนดหมวดหมู่และจุดข้อมูลเชิงตัวเลข.
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

ชื่อซีรีส์ที่ได้คือ `Product A 2026`, โดยมีช่องว่างระหว่างค่าจากสองเซลล์. คำอธิบายจะแสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์. ภาพด้านล่างแสดงผลลัพธ์:

![แผนภูมิคอลัมน์ที่มีค่าตะวันเหนือและใต้พร้อมชื่อซีรีส์แบบรวม Product A 2026 ในคำอธิบาย](composite_series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีซีรีส์และสไตล์ของแผนภูมิ. นี่คือสีที่ใช้เมื่อสีเติมของซีรีส์ไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดนี้อ่านสีที่คำนวณแล้ว; ไม่ได้กำหนดสีเติมใหม่.

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละซีรีส์ค่าเริ่มต้น:

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

ตัวอย่างผลลัพธ์สำหรับสไตล์แผนภูมิค่าเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แท้จริงขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับสำหรับซีรีส์แผนภูมิ**

สำหรับซีรีส์แท่ง, คอลัมน์, และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าสีเติมปกติของซีรีส์เป็นสีทึบ, เปิดการกลับสี, แล้วกำหนดสีค่าติดลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). ตัวเลขติดลบยังคงไม่เปลี่ยนแปลงในเวิร์กบุ๊ก; มีเพียงสีการแสดงผลที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิค่าเริ่มต้นด้วยซีรีส์หนึ่ง. แถว 0 ของ Worksheet มีชื่อซีรีส์, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![สีเติมกลับแบบทึบ](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับสีสำหรับจุดเดียวโดยใช้ [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). ในตัวอย่างต่อไปนี้, การกลับสีถูกปิดสำหรับซีรีส์และเปิดเฉพาะจุดที่เลือก. จุดนั้นยังถูกกำหนดค่าเป็นค่าติดลบเพื่อให้เห็นผล:

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

## **ลบค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าเปล่าโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์แบคอัพของเวิร์กบุ๊กเป็น `null`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้สามารถเข้าถึงผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getvalue/). จุดข้อมูลจะคงอยู่ในตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจะถือค่าของมันว่าเป็นค่าว่างตามการตั้งค่าแบบค่าว่างของแผนภูมิ.

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาด. ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่นไว้, เพราะเมธอดนั้นจะลบทุกจุดข้อมูลจากคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนไว้ซึ่งมีค่าเป็นกรณีที่แยกจากเซลล์ว่าง. เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ใน Worksheet, ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/nodejs-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์เวิร์กบุ๊กที่ว่างเปล่าเป็นตัวแทนของข้อมูลที่ขาดหาย; เซลล์ที่มีค่า `0` แทนค่าตัวเลขที่ทราบ. เรียก [ChartDataCell.setValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setvalue/) ด้วย `null` เพื่อทำให้เซลล์เป็นค่าว่าง. ตัวเลขศูนย์ยังคงเป็นศูนย์ไม่ว่าการตั้งค่าค่าว่างจะเป็นอย่างไร.

ใช้ [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) เพื่อเลือกว่ากราฟจะแสดงเซลล์ว่างอย่างไร. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีการพล็อตค่าว่าง, โดยไม่เติมค่า `0` หรือค่าที่ประมาณในเซลล์เวิร์กบุ๊กที่ว่าง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีซีรีส์หนึ่ง, ลบค่าของ Day 3, แล้วบันทึกแผนภูมินั้นในแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/) ใช้ Worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 มีชื่อซีรีส์. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

    // ปล่อยให้วัน 3 เป็นค่าว่างจริงๆ โดยยังคงรักษาหมวดหมู่และจุดข้อมูลของมันไว้.
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

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดไว้ก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, กำหนดโหมดที่ต้องการและบันทึกพรีเซนเทชันครั้งเดียวแทนการวนลูปตามโหมดหลายครั้ง.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม. Day 3 เป็นค่าว่างในเวิร์กบุ๊กทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่ Day 3, Zero ทำให้เส้นตกลงเป็นศูนย์, และ Span เชื่อม Day 2 ไปยัง Day 4](display_blanks_as.png)

ผลที่มองเห็นขึ้นกับประเภทแผนภูมิ. แผนภูมิเส้นทำให้สามโหมดง่ายต่อการเปรียบเทียบ. แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมข้ามหมวดหมู่ที่หายไป, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมที่แสดงข้างต้น; คอลัมน์ที่หายไปและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกันเช่นกัน. ในทำนองเดียวกัน, แผนภูมิกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อม. อย่าคาดหวังผลลัพธ์สามแบบที่แตกต่างกันสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างของช่องว่างระหว่างซีรีส์**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มแถบหรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างแถบหรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มาจากกลุ่มซีรีส์แม่ ไม่ได้เป็นของซีรีส์เดียว. เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) ครั้งเดียวสำหรับกลุ่ม. ค่าที่ใหญ่กว่าจะสร้างช่องว่างระหว่างกลุ่มมากขึ้น; ค่าที่เล็กกว่าจะทำให้กลุ่มหนาแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกพรีเซนเทชันสุดท้ายเท่านั้น:

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

![ความกว้างของช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับข้อมูลซีรีส์?**  
ทุกประเภทแผนภูมิที่แสดงโดยการนับจาก enumeration [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ซีรีส์ของแต่ละประเภทอาจมีโครงสร้างค่าหรือการตั้งค่าที่แตกต่างกัน. ตัวอย่างเช่น, แผนภูมิปเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทซีรีส์. ตัวเลือกเช่นการทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มแท่งหรือคอลัมน์ที่เข้ากันได้.

**กลุ่มซีรีส์แผนภูมิคืออะไร?**  
[ChartSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/) ประกอบด้วยซีรีส์ที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิแบบรวมอาจมีหลายกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านซีรีส์หนึ่งอาจไม่เปลี่ยนแปลงทุกซีรีส์ในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลค่าเริ่มต้นหรือไม่?**  
ใช่. โดยค่าเริ่มต้น, [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) จะสร้างซีรีส์, หมวดหมู่, และค่าตัวอย่าง. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งคอลเลกชันซีรีส์และหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองทั้งหมด. มี overload ที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลค่าเริ่มต้นได้เช่นกัน.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ในเวิร์กบุ๊กอย่างไร?**  
ชื่อซีรีส์, ป้ายกำกับหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/). การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิเกี่ยวข้อง. เมื่อคุณสร้างข้อมูลกำหนดเอง, ให้จัดเรียงแถวหมวดหมู่และแถวค่าซีรีส์ให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ตั้งใจ.

**ฉันจะลบจุดเดียวแทนที่จะลบทั้งชุดข้อมูลได้อย่างไร?**  
ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดเปล่า. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากซีรีส์นั้น. หากคุณลบหมวดหมู่ออกด้วย, ให้อัปเดตทุกซีรีส์เพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดว่างจะแสดงอย่างไร?**  
ผลลัพธ์ขึ้นกับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/). แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมจุดใกล้เคียงกัน. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในพรีเซนเทชันของคุณ. ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างฉบับสมบูรณ์และการเปรียบเทียบภาพ.

**ค่าติดลบจะจัดรูปแบบอย่างไร?**  
สำหรับซีรีส์แท่ง, คอลัมน์, และบับเบิลที่รองรับ, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setinvertifnegative/) แล้วกำหนดสีที่กลับโดยใช้ [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getinvertedsolidfillcolor/). คุณสามารถทับการทำงานสำหรับจุดเดียวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/setinvertifnegative/). วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบเท่านั้น, ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ.

**การจัดรูปแบบใดมีผลเหนือเมื่อทั้งซีรีส์และจุดถูกจัดรูปแบบ?**  
การจัดรูปแบบจุดข้อมูลโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ จะใช้การจัดรูปแบบซีรีส์โดยตรงหรือ, หากไม่มีการกำหนดรูปแบบซีรีส์, จะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การทับซ้อนระดับจุด.

**มีขีดจำกัดของจำนวนซีรีส์ที่แผนภูมิสามารถมีได้หรือไม่?**  
Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนซีรีส์แบบแยกต่างหาก. อย่างไรก็ตามข้อจำกัดของไฟล์พรีเซนเทชัน, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่เป็นประโยชน์ในทางปฏิบัติ.

**ควรแก้ไขอะไรเมื่อคอลัมน์อยู่ใกล้กันเกินหรือต่างกันเกินไป?**  
เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) บนกลุ่มซีรีส์แม่ที่เกี่ยวข้อง. เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น.