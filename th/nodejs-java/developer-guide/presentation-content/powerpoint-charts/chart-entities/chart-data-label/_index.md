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
- ตำแหน่งของป้าย
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อสร้างสไลด์ที่น่าสนใจมากยิ่งขึ้น"
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีการจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย ควบคุมป้ายที่อยู่นอกค่าสูงสุดของแกน ปรับระยะห่างของป้ายแกนประเภท และการกำหนดตำแหน่งของป้ายแผนภูมิบาย

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลของแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายค่าของชุดแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและสองตำแหน่งทศนิยมโดยไม่เปลี่ยนค่าที่เก็บไว้

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

เพื่อจัดรูปแบบเซลล์ตัวเลขในสมุดงานที่ฝังอยู่ในแผนภูมิ ให้ดูที่ [Set Custom Number Formats for Workbook Cells](/slides/th/nodejs-java/chart-workbook/#set-custom-number-formats-for-workbook-cells) ตัวอย่างนั้นยังแสดงป้ายค่าให้สอดคล้องกับรูปแบบของเซลล์ต้นฉบับในขณะที่ยังคงค่าตัวเลขที่จัดเก็บไว้

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิคอลัมน์สแต็ก ให้คำนวณแต่ละค่าเป็นเปอร์เซ็นต์ของผลรวมประเภทนั้นแล้วกำหนดข้อความให้กับกรอบข้อความที่คืนค่าจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยสองตำแหน่งทศนิยมในแบบอักษรขนาด 8 จุด ประเภทที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงให้คำนวณข้อความป้ายแบบกำหนดใหม่

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

## **ตั้งค่าสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลแผนภูมิ**

เมื่อค่าเก็บในรูปแบบเศษส่วน ให้ใช้ [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) เพื่อแสดงเปอร์เซ็นต์ ส่งค่า `false` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นฉบับ

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

ใช้ [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าของป้ายข้อมูล ซึ่งเป็นประโยชน์เมื่อดึงป้ายสำหรับรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบ [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) เริ่มต้นรวมชื่อประเภท ชื่อชุดข้อมูลและค่า จุดหนึ่งจัดรูปแบบค่าเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)

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

ค่าที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ป้ายจะแสดงเป็น `75%` พร้อมกับชื่อประเภทและชุดข้อมูล ข้อความกำหนดเองจะครอบข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) จะคืนสตริงป้ายในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายข้อมูลที่อยู่นอกค่าสูงสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุดของแกน ใช้ [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) เพื่อควบคุมว่าจะให้แสดงป้ายข้อมูลของพวกเขาหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้าย แต่ไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลที่เก็บอยู่

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์คลัสเตอร์ 2‑มิติด้วยค่าที่ 60 และ 120 โดยส่งค่า `false` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) และกำหนดค่าสูงสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) บนแกนแนวดิ่ง สไลด์แรกอนุญาตให้แสดงป้ายที่เกินค่าสูงสุด; สำเนาของสไลด์นั้นปิดการแสดงป้าย ทั้งสองสไลด์ถูกบันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดใช้งานป้ายค่าโดยใช้ [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) การตั้งค่าระดับแผนภูมิไม่ได้ทำให้แสดงค่าตามลำพังหรือเขียนทับการปิดแสดงค่าบนป้ายแต่ละรายการ ตัวอย่างนี้เปิดค่าทั้งชุดและใช้ [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) เพื่อตำแหน่งป้ายที่ปลายนอกของแต่ละคอลัมน์

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();

    const firstCategory = workbook.getCell(0, 1, 0, "Within range");
    const secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    const seriesName = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    const firstValue = workbook.getCell(0, 1, 1, 60);
    const secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    const secondSlide = presentation.getSlides().addClone(slide);
    const secondChart = secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกและเรนเดอร์โดย Microsoft PowerPoint เมื่อใช้ `true` ป้าย **120** ปรากฏที่ขอบบน; เมื่อใช้ `false` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ ค่าสูงสุดของแกนคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2‑มิติที่มีแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิเผือกและโดนัท จะไม่มีค่าสูงสุดของแกนที่สามารถจำกัดได้ในลักษณะนี้
{{% /alert %}}

## **ตั้งค่าระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทกับแกน ค่าที่กำหนดเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์คลัสเตอร์และตั้งค่าออฟเซ็ตของป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้มีผลต่อป้ายแกนประเภท มากกว่าป้ายที่ผูกกับจุดข้อมูลแต่ละจุด

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

บนแผนภูมิเผือก ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มช่องว่างและให้พื้นที่สำหรับเส้นเชื่อม

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายไว้ด้านนอกสไลซ์ และปรับออฟเซ็ตแนวนอนและแนวดิ่งโดยใช้ [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) ออฟเซ็ตรุ่นนี้สัมพันธ์กับความกว้างและความสูงของแผนภูมิ ตามลำดับ

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **จัดรูปแบบเส้นเชื่อม**

เมื่อป้ายแผนภูมิเผือกอยู่ด้านนอกสไลซ์ เส้นเชื่อมช่วยผู้อ่านจับคู่ค่ากับสไลซ์ที่ถูกต้อง สีที่ตัดกันและเส้นที่หนาขึ้นเล็กน้อยทำให้การเชื่อมต่ออ่านง่ายขึ้น ในขณะเดียวกันความโปร่งใสและสไตล์เป็นเส้นประทำให้เส้นดูไม่เป็นที่สนใจมาก

ใช้ [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) เพื่อจัดรูปแบบเส้นเชื่อมในระดับคอลเลกชันป้ายข้อมูลของชุด ตัวตั้งค่าใน `series.getLabels().getLeaderLinesFormat().getLine()` จะใช้กับคอลเลกชันทั้งหมด ไม่ใช่กับป้ายเดี่ยว

ตัวอย่างนี้สร้างแผนภูมิเผือกด้วยข้อมูลเริ่มต้น แสดงค่าออกนอกสไลซ์และเปิดใช้งาน [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/) โดยย้ายสองป้ายให้ห่างจากสไลซ์มากขึ้นด้วยออฟเซ็ต [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) ทั้งสองออฟเซ็ตแสดงเป็นสัดส่วนของความกว้างและความสูงของแผนภูมิ ไม่จำเป็นต้องมีงานนำเสนอเข้า

เส้นของ [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) ตั้งเป็นสีฟ้าเข้มทึบโดยมีค่าอัลฟา 191 จาก 255 ให้ความโปร่งใสประมาณ 25% [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) ตั้งความหนาเป็น 2 จุด และ [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) ทำให้เส้นเป็นเส้นประ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 80, 50, 560, 400);
    chart.setLegend(false);

    const series = chart.getChartData().getSeries().get_Item(0);

    const labelFormat = series.getLabels().getDefaultDataLabelFormat();
    labelFormat.setShowValue(true);
    labelFormat.setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    labelFormat.setShowLeaderLines(true);

    // ย้ายป้ายสองอันให้ห่างออกจากสไลซ์ของมันมากขึ้น
    series.getLabels().get_Item(0).setX(java.newFloat(0.10));
    series.getLabels().get_Item(0).setY(java.newFloat(-0.05));
    series.getLabels().get_Item(1).setX(java.newFloat(-0.10));
    series.getLabels().get_Item(1).setY(java.newFloat(0.05));

    const line = series.getLabels().getLeaderLinesFormat().getLine();
    line.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const lineColor = java.newInstanceSync("java.awt.Color", 30, 90, 160, 191);
    line.getFillFormat().getSolidFillColor().setColor(lineColor);
    line.setWidth(2);
    line.setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    presentation.save("FormattedLeaderLines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การเปิดใช้งานเส้นเชื่อมไม่ได้รับประกันว่าจะมีเส้นปรากฏสำหรับทุกป้าย ความมองเห็นขึ้นกับตำแหน่งป้ายและพฤติกรรมการจัดวางของแผนภูมิ ในตัวอย่างนี้สองป้ายที่ย้ายออกจะมีเส้นเชื่อมที่มองเห็นได้; ป้ายที่อยู่ใกล้สไลซ์จึงไม่จำเป็นต้องมีเส้นเชื่อม

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกและเรนเดอร์ด้วย Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลเหนือพื้นที่พล็อต Series A แสดงคอลัมน์ที่มองเห็นได้ ส่วน Series B และ Series C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกเขาถูกซ่อนไว้โดยลบการเติมสีและเส้นขอบ วิธีการ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) ทำให้ชุดทั้งสามจัดแนวศูนย์กลางประเภทเดียวกัน

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) จองพื้นที่สำหรับแถวป้าย หลังจากที่ [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) คำนวณตำแหน่งเริ่มต้นแล้ว [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) จะรักษาการจัดแนวนอนและใช้การออฟเซ็ตแนวดิ่งเพื่อจัดเรียงป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าชุดข้อมูล; ส่วนหัวแถวเป็นรูปทรงข้อความแยกต่างหาก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categories = ["North", "South", "East", "West"];
    const seriesNames = ["Series A", "Series B", "Series C"];
    const seriesValues = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]];

    for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        const categoryCell = workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        const seriesCell = workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
        const series = chart.getChartData().getSeries().add(seriesCell, aspose.slides.ChartType.ClusteredColumn);

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const valueCell = workbook.getCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        if (seriesIndex > 0) {
            // ซ่อนคอลัมน์ของ B และ C แต่คงป้ายข้อมูลไว้
            series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(12);
            const labelFill = series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(java.newByte(aspose.slides.FillType.Solid));
            labelFill.getSolidFillColor().setColor(black);
            series.getLabels().getDefaultDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.InsideBase);
        }
    }

    // จัดตำแหน่งสามชุดข้อมูลให้ตรงกับศูนย์กลางประเภทเดียวกัน
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // ใช้เส้นตารางน้อยลงสำหรับตัวอย่างที่กระชับนี้
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // จองพื้นที่เหนือพื้นที่แผนภูมิเพื่อสองแถวของป้ายข้อมูล
    chart.getPlotArea().setLayoutTargetType(aspose.slides.LayoutTargetType.Inner);
    chart.getPlotArea().setX(java.newFloat(0.15));
    chart.getPlotArea().setY(java.newFloat(0.32));
    chart.getPlotArea().setWidth(java.newFloat(0.80));
    chart.getPlotArea().setHeight(java.newFloat(0.48));
    chart.validateChartLayout();

    for (let seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const rowTop = seriesIndex == 1 ? 0.15 : 0.03;

        for (let categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            const dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // คงตำแหน่งแนวนอนเริ่มต้นไว้. Y เป็นออฟเซ็ตจาก
            // ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // เฉพาะหัวแถวเป็นรูปทรงข้อความแยกต่างหาก
        const rowHeading = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, chart.getX(), chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        const headingFormat = rowHeading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        headingFormat.getFillFormat().getSolidFillColor().setColor(black);
    }

    presentation.save("multiple-rows-of-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**How can I prevent data labels from overlapping on dense charts?**  
ผสานการวางป้ายโดยอัตโนมัติ, เส้นเชื่อม, และลดขนาดฟอนต์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะค่าที่สุดหรือจุดสำคัญ

**How can I disable labels only for zero, negative, or empty values?**  
กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าติดลบ หรือค่าที่ขาดหายตามกฎที่กำหนด

**How can I ensure a consistent label style when exporting to PDF/images?**  
กำหนดฟอนต์และขนาดฟอนต์อย่างชัดเจน และตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง