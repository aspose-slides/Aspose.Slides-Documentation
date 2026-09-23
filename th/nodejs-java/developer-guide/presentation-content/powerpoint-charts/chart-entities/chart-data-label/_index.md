---
title: จัดการป้ายข้อมูลแผนภูมิในการนำเสนอด้วย JavaScript
linktitle: ป้ายข้อมูล
type: docs
url: /th/nodejs-java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างป้าย
- ตำแหน่งป้าย
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น"
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับซีรีส์ของแผนภูมิและจุดข้อมูลแต่ละจุด, ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีการจัดรูปแบบค่า, แสดงเปอร์เซ็นต์, อ่านข้อความป้าย, ปรับระยะห่างของป้ายแกนหมวดหมู่, และกำหนดตำแหน่งป้ายของแผนภูมิวงกลม.

## **กำหนดความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) เพื่อจัดรูปแบบค่าในซีรีส์ ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น, แสดงตารางข้อมูลของมัน, และเปิดใช้งานป้ายค่สำหรับซีรีส์แรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าต่ำสุด.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    const series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิคอลัมน์แบบซ้อน, คำนวณค่าทุกค่เป็นเปอร์เซ็นต์ของผลรวมหมวดหมู่และกำหนดข้อความให้กับเฟรมข้อความที่ส่งกลับโดย [getTextFrameForOverriding](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเริ่มต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด หมวดหมู่ที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงให้คำนวณข้อความป้ายแบบกำหนดใหม่.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);

    const categoryTotals = new Array(chart.getChartData().getCategories().size()).fill(0);
    for (let k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
            const series = chart.getChartData().getSeries().get_Item(i);
            const pointValue = series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += Number(pointValue);
        }
    }

    for (let x = 0; x < chart.getChartData().getSeries().size(); x++) {
        const series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            const pointValue = series.getDataPoints().get_Item(j).getValue().getData();
            const dataPointPercent = (Number(pointValue) / categoryTotals[j]) * 100;

            const portion = new aspose.slides.Portion();
            portion.setText(dataPointPercent.toFixed(2) + " %");
            portion.getPortionFormat().setFontHeight(8);

            label.getTextFrameForOverriding().setText("");
            const paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน, ให้ใช้ [setNumberFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) เพื่อแสดงเป็นเปอร์เซ็นต์ ส่งค่า `false` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) เพื่อใช้รูปแบบป้ายแยกจากเซลล์ต้นทาง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% พร้อมซีรีส์สีแดงและสีน้ำเงินในสี่หมวด หมวดแต่ละคู่ของค่าเพิ่มขึ้นถึง 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองซีรีส์ใช้ข้อความป้ายสีขาว ขนาด 10 จุด.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;
    for (let i = 0; i < 4; i++) {
        const categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    const seriesNames = ["Reds", "Blues"];
    const white = java.getStaticFieldValue("java.awt.Color", "WHITE");
    const seriesColors = [java.getStaticFieldValue("java.awt.Color", "RED"), java.getStaticFieldValue("java.awt.Color", "BLUE")];
    const values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]];

    for (let i = 0; i < seriesNames.length; i++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (let j = 0; j < 4; j++) {
            const valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        const labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(white);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **อ่านข้อความจริงของป้ายข้อมูล**

ใช้ [getActualLabelText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าของป้ายข้อมูล นี่เป็นประโยชน์เมื่อดึงป้ายสำหรับรายงาน, ค้นหาข้อมูลในงานนำเสนอ, หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบป้ายข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabelformat/) รวมชื่อหมวด, ชื่อซีรีส์, และค่า จุดหนึ่งกำหนดค่าของมันเป็นเปอร์เซ็นต์, และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    const secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    const northSeriesCell = workbook.getCell(0, 0, 1, "North");
    const north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    const northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    const northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    const southSeriesCell = workbook.getCell(0, 0, 2, "South");
    const south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    const southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    const southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        const format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (let i = 0; i < chart.getChartData().getSeries().size(); i++) {
        const series = chart.getChartData().getSeries().get_Item(i);
        for (let j = 0; j < series.getDataPoints().size(); j++) {
            const point = series.getDataPoints().get_Item(j);
            const label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            console.log("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

ตัวเลขที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ป้ายของมันจะแสดง `75%` พร้อมกับชื่อหมวดและชื่อซีรีส์ ข้อความกำหนดเองจะทับข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) จะคืนสตริงป้ายที่ได้ในกรณีใดก็ได้ ตรวจสอบ [isVisible](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/isvisible/) แยกต่างหากตามที่แสดงข้างต้นเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้.

## **กำหนดระยะห่างป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/axis/setlabeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนหมวดหมู่และแกน ค่าที่กำหนดเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและตั้งค่าการเว้นระยะป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนหมวดหมู่แทนป้ายที่แนบกับจุดข้อมูลแต่ละจุด.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ปรับตำแหน่งป้าย**

บนแผนภูมวงกลม, ให้ปรับตำแหน่งป้ายข้อมูลเพื่อปรับระยะห่างและให้มีพื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก, วางป้ายของมันนอกส่วนของชิ้น, และปรับการเยื้องแนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/setx/) และ [setY](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datalabel/sety/) การเยื้องเหล่านี้สัมพันธ์กับความกว้างและความสูงของแผนภูมิ ตามลำดับ.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    const series = chart.getChartData().getSeries();

    const label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(java.newFloat(0.71));
    label.setY(java.newFloat(0.04));

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![แผนภูมวงกลมที่มีตำแหน่งป้ายข้อมูลปรับแล้ว](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิที่แน่นได้อย่างไร?**  
ผสานการวางป้ายอัตโนมัติ, เส้นนำ, และลดขนาดฟอนต์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น หมวด) หรือแสดงป้ายเฉพาะค่าที่สุดขีดหรือจุดสำคัญ

**ฉันจะปิดการใช้งานป้ายเฉพาะค่าศูนย์, ค่าเป็นลบ, หรือค่าว่างได้อย่างไร?**  
กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าลบ, หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายสอดคล้องกันเมื่อส่งออกเป็น PDF/ภาพได้อย่างไร?**  
กำหนดแบบอักษรและขนาดอย่างชัดเจนและตรวจสอบว่าฟอนท์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนท์สำรอง