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
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลในแผนภูมิและจุดข้อมูลเดี่ยว ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย ควบคุมป้ายที่อยู่นอกขีดสุดของแกน ปรับระยะห่างของป้ายแกนประเภท และกำหนดตำแหน่งป้ายของแผนภูมิพาย

## **กำหนดความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายค่าของชุดข้อมูลแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและสองตำแหน่งทศนิยมโดยไม่เปลี่ยนแปลงค่าที่อยู่เบื้องหลัง

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

สำหรับแผนภูมิคอลัมน์ซ้อนกัน คำนวณค่าทุกค่าเป็นเปอร์เซ็นต์ของผลรวมประเภทแล้วกำหนดข้อความให้กับกรอบข้อความที่ได้จาก [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิปริยายและแสดงเปอร์เซ็นต์ด้วยสองตำแหน่งทศนิยมในฟอนต์ขนาด 8 จุด ประเภทที่มีผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงให้คำนวณข้อความป้ายแบบกำหนดใหม่

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

## **กำหนดสัญลักษณ์เปอร์เซ็นต์ในป้ายแผนภูมิ**

เมื่อค่าถูกเก็บไว้ในรูปส่วน ให้ใช้ [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) เพื่อแสดงเปอร์เซ็นต์ ส่งค่า `false` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นทาง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% ด้วยชุดสีแดงและสีน้ำเงินในสี่ประเภท แต่ละคู่ค่ารวมกันเท่ากับ 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้สองตำแหน่งทศนิยม ทั้งสองชุดใช้ข้อความป้ายสีขาวขนาด 10 จุด

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

ใช้ [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล สิ่งนี้มีประโยชน์เมื่อดึงป้ายสำหรับรายงาน ค้นหาเนื้อหาในการนำเสนอ หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่างรูปแบบ [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) เริ่มต้นรวมชื่อประเภท ชื่อชุดข้อมูลและค่า จุดหนึ่งจัดรูปแบบค่าเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/)

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

ค่าที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายจะแสดง `75%` พร้อมชื่อประเภทและชุดข้อมูล ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) จะคืนสตริงป้ายผลลัพธ์ในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) แยกต่างหากตามตัวอย่างข้างต้นเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายข้อมูลที่อยู่นอกขีดสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินขีดสุดของมัน ใช้ [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) เพื่อควบคุมว่าป้ายของพวกมันจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้าย ไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม 2D ด้วยค่า 60 และ 120 ส่งค่า `false` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) แล้วตั้งค่าสูงสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) บนแกนแนวตั้ง สไลด์แรกอนุญาตให้ป้ายอยู่เหนือขีดสุด; สไลด์ที่คัดลอกจะปิดการทำงานนี้ ทั้งสองสไลด์ถูกบันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดใช้ป้ายค่าโดยใช้ [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). การตั้งค่าระดับแผนภูมิไม่ทำให้แสดงค่าตามตัวเองหรือเขียนทับการปิดการแสดงค่าสำหรับป้ายเดี่ยว ตัวอย่างนี้เปิดค่าทั้งชุดและใช้ [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) วางป้ายที่ปลายนอกของแต่ละคอลัมน์

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

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกแล้วโดย Microsoft PowerPoint เมื่อ `true` ป้าย **120** จะมองเห็นได้ที่ขอบบน; เมื่อ `false` จะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ ขีดสุดแกนคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่า 120 พร้อมขีดสุดแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่า 120 พร้อมขีดสุดแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}

ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น พายและโดนัท จะไม่มีขีดสุดแกนให้จำกัดวิธีนี้

{{% /alert %}}

## **กำหนดระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทและแกนเอง ค่าจะเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบจัดกลุ่มและตั้งค่า offset ของป้ายแกนแนวนอนได้เป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนประเภท ไม่ใช่ป้ายที่แนบกับจุดข้อมูลเดี่ยว

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

บนแผนภูมิปาย ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มระยะห่างและให้พื้นที่สำหรับเส้นเชื่อม

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายไว้ด้านนอกชิ้นส่วน และปรับ offset แนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) offset เหล่านี้เป็นค่าที่สัมพันธ์กับความกว้างและความสูงของแผนภูมิ

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

![แผนภูมิปายพร้อมตำแหน่งป้ายที่ปรับแล้ว](pie-chart-adjusted-label.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลเหนือพื้นที่วาด ชุด A แสดงคอลัมน์ที่มองเห็นได้ ส่วนชุด B และชุด C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกมันถูกซ่อนโดยลบการเติมสีและโครงร่าง วิธีการ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) ทำให้ชุดทั้งหมดสามชุดสอดคล้องกับศูนย์กลางประเภทเดียวกัน

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) จัดสรรพื้นที่สำหรับแถวป้าย หลังจากที่ [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) คำนวณตำแหน่งเริ่มต้นแล้ว [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) คงการจัดแนวแนวนอนและใช้ offset แนวตั้งเพื่อจัดเรียงป้ายในสองแถว ตัวเลขยังคงเป็นป้ายที่เชื่อมโยงกับค่าชุดข้อมูล; เฉพาะหัวแถวที่เป็นรูปร่างข้อความแยกต่างหาก

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
            // ซ่อนคอลัมน์ของ B และ C แต่ยังคงแสดงป้ายข้อมูลของพวกมัน
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

    // จัดแนวชุดข้อมูลทั้งสามให้ตรงศูนย์กลางของประเภทเดียวกัน
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กระชับนี้
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // สำรองพื้นที่เหนือพื้นที่วางแผนภูมิสำหรับสองแถวของป้ายข้อมูล
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
            // คงตำแหน่งแนวนอนค่าเริ่มต้น. Y เป็นการเลื่อนจาก
            // ตำแหน่งป้ายค่าเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // เฉพาะหัวแถวเป็นรูปร่างข้อความแยกต่างหาก
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

![แผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลเหนือพื้นที่วาด](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับกันบนแผนภูมิที่แน่นได้อย่างไร?**

ผสานการวางป้ายโดยอัตโนมัติ เส้นเชื่อม และลดขนาดฟอนต์ หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะค่าขอบหรือจุดสำคัญ

**ฉันจะปิดการแสดงป้ายเฉพาะค่าศูนย์ ค่าลบ หรือค่าว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงสำหรับค่า 0, ค่าลบ หรือค่าที่ขาดตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ป้ายคงที่เมื่อส่งออกเป็น PDF/ภาพได้อย่างไร?**

กำหนดฟอนต์และขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง