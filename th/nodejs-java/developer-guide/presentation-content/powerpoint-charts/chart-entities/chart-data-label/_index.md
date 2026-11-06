---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอด้วย JavaScript
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
description: "เรียนรู้วิธีการเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลแผนภูมิและจุดข้อมูลแต่ละจุด, ช่วยให้ผู้อ่านระบุค่าต่าง ๆ และเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า, แสดงเปอร์เซ็นต์, อ่านข้อความป้าย, ควบคุมป้ายที่อยู่นอกขีดสุดของแกน, ปรับระยะห่างของป้ายแกนหมวดหมู่, และตำแหน่งของป้ายแผนภูมิเสี้ยว.

## **นับป้ายข้อมูลที่มองเห็นได้**

ใช้ [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getcountofvisibledatalabels/) เพื่อตรวจสอบว่ามีป้ายข้อมูลกี่อันที่เปิดให้แสดงก่อนเผยแพร่นำเสนอ ไม่เหมือนกับ [getCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getcount/), ซึ่งให้จำนวนป้ายทั้งหมดในคอลเลกชัน, มันจะพิจารณาค่าตั้งต้นของชุดข้อมูลและการตั้งค่าป้ายแต่ละอัน

ตัวอย่างนี้สร้างแผนภูมิเสาโดยมีชุดข้อมูลหนึ่งชุดและจุดข้อมูลสามจุด มันเข้าถึงคอลเลกชันป้ายของชุดข้อมูลผ่าน [getLabels](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getlabels/) และพิมพ์จำนวนป้ายที่มองเห็นได้เมื่อการตั้งค่าเปลี่ยน: **0, 3, 2, 3**. จำนวนทั้งหมดยังคงเป็น **3**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const seriesCell = workbook.getCell(0, 0, 1, "Values");
    const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

    for (let i = 0; i < 3; i++) {
        const categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        const valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    const labels = series.getLabels();
    console.log("Total: " + labels.getCount() + "; visible: " + labels.getCountOfVisibleDataLabels()); // ทั้งหมด: 3; มองเห็น: 0

    labels.getDefaultDataLabelFormat().setShowValue(true);
    console.log("Visible: " + labels.getCountOfVisibleDataLabels()); // มองเห็น: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(false);
    console.log("Visible: " + labels.getCountOfVisibleDataLabels()); // มองเห็น: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(true);
    console.log("Visible: " + labels.getCountOfVisibleDataLabels()); // มองเห็น: 3
} finally {
    presentation.dispose();
}
```

เมธอด [getDefaultDataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getdefaultdatalabelformat/) ของชุดข้อมูลจะให้การตั้งค่าเริ่มต้น การส่งค่า `true` ไปยัง [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) ที่นั่นจะแสดงค่าของป้ายทั้งสาม การส่งค่า `false` ผ่าน [getDataLabelFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getdatalabelformat/) ของป้ายหนึ่งจะเขียนทับการตั้งค่าสำหรับป้ายที่เลือก การส่งค่า `true` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowlegendkey/) ทำให้ป้ายดังกล่าวนับเป็นมองเห็นได้อีกครั้ง แม้ว่าค่าของมันจะยังคงถูกซ่อนอยู่.

จำนวนที่มองเห็นสะท้อนการตั้งค่าการมองเห็นเท่านั้น ไม่ได้วัดว่าป้ายทับกัน, ถูกตัด, หรืออ่านได้ในแผนภูมิที่เรนเดอร์แล้ว.

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/setnumberformatofvalues/) เพื่อจัดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น, แสดงตารางข้อมูลของมัน, และเปิดใช้งานป้ายค่าสำหรับชุดข้อมูลแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและสองตำแหน่งทศนิยมโดยไม่เปลี่ยนค่าฐาน.

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

เพื่อจัดรูปแบบเซลล์ตัวเลขในเวิร์กบุ๊กที่ฝังในแผนภูมิ, ดู [ตั้งค่ารูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์เวิร์กบุ๊ก](/slides/th/nodejs-java/chart-workbook/#set-custom-number-formats-for-workbook-cells). ตัวอย่างนั้นยังแสดงให้เห็นว่าป้ายค่าตามรูปแบบของเซลล์ต้นทางโดยคงค่าตัวเลขที่เก็บไว้.

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิเสาสะสม, คำนวณแต่ละค่าเป็นเปอร์เซ็นต์ของยอดรวมของหมวดหมู่นั้นและกำหนดข้อความไปยังกรอบข้อความที่คืนค่าจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/). ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยสองตำแหน่งทศนิยมในฟอนต์ขนาด 8 จุด หมวดหมู่ที่ยอดรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ คำนวณข้อความป้ายแบบกำหนดใหม่หากข้อมูลแผนภูมิเกิดการเปลี่ยนแปลง.

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

เมื่อค่าถูกเก็บเป็นเศษส่วน, ใช้ [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) เพื่อแสดงเป็นเปอร์เซ็นต์ ส่งค่า `false` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นทาง.

ตัวอย่างนี้สร้างแผนภูมิเสาสะสม 100% ด้วยชุดข้อมูลสีแดงและสีน้ำเงินในสี่หมวดหมู่ แต่ละคู่ของค่าได้ผลรวมเป็น 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้สองตำแหน่งทศนิยม ทั้งสองชุดข้อมูลใช้ข้อความป้ายสีขาวขนาด 10 จุด.

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

ใช้ [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล สิ่งนี้มีประโยชน์เมื่อดึงป้ายเพื่อรายงาน, ค้นหาเนื้อหาในงานนำเสนอ, หรือยืนยันความถูกต้องของแผนภูมิที่สร้าง ตัวอย่างด้านล่าง, รูปแบบป้ายข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/) ทำการรวมชื่อหมวดหมู่, ชื่อชุดข้อมูล, และค่า จุดหนึ่งจัดรูปแบบค่าเป็นเปอร์เซ็นต์, อีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/gettextframeforoverriding/).

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

ตัวเลขที่เก็บไว้ในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายของมันจะแสดง `75%` พร้อมกับชื่อหมวดหมู่และชื่อชุดข้อมูล ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/getactuallabeltext/) จะคืนสตริงป้ายที่ได้ในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/isvisible/) แยกต่างหากตามที่แสดงข้างต้นเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้.

## **ควบคุมป้ายข้อมูลที่อยู่นอกขีดสุดของแกน**

เมื่อคุณจำกัดช่วงแกนด้วยตนเอง, จุดข้อมูลบางจุดอาจเกินค่าสูงสุดของมัน ใช้ [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setshowdatalabelsovermaximum/) เพื่อควบคุมว่าป้ายข้อมูลของพวกมันจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้าย; ไม่เปลี่ยนช่วงแกนหรือค่าข้อมูลฐาน.

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม 2 มิติ ด้วยค่าที่ 60 และ 120 มันส่งค่า `false` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setautomaticmaxvalue/) และตั้งค่าสูงสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setmaxvalue/) บนแกนแนวตั้ง สไลด์แรกอนุญาตให้ป้ายอยู่เหนือค่าสูงสุด; สำเนาของสไลด์นั้นปิดใช้งานป้าย ทั้งสองสไลด์ถูกบันทึกใน `DataLabelsOverMaximum.pptx`.

เปิดใช้ป้ายค่าโดยใช้ [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/). การตั้งค่าระดับแผนภูมิไม่ได้เปิดการแสดงค่าด้วยตนเองหรือเขียนทับการปิดการแสดงค่าของป้ายแต่ละอัน ตัวอย่างนี้เปิดใช้ค่าสำหรับชุดข้อมูลทั้งหมดและใช้ [setPosition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setposition/) เพื่อวางป้ายที่ปลายด้านนอกของแต่ละคอลัมน์.

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

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกและเรนเดอร์โดย Microsoft PowerPoint ด้วยค่า `true` ป้าย **120** จะมองเห็นได้ที่ขอบบน; ด้วยค่า `false` จะถูกซ่อน ป้าย **60** ยังคงมองเห็น, ค่าสูงสุดของแกนคงที่ที่ **100**, และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่าที่ 120 พร้อมขีดสุดของแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่าที่ 120 พร้อมขีดสุดของแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2 มิติพร้อมแกนค่าซึ่งแผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิเสี้ยวและโดนัท, จะไม่มีขีดสุดของแกนให้จำกัดในลักษณะนี้.
{{% /alert %}}

## **ตั้งระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setlabeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนหมวดหมู่และแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์จัดกลุ่มและตั้งค่าออฟเซตป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนหมวดหมู่มากกว่าป้ายที่แนบกับจุดข้อมูลแต่ละจุด.

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

## **ปรับตำแหน่งของป้าย**

บนแผนภูมิเสี้ยว, ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มระยะห่างและทำให้มีพื้นที่สำหรับเส้นเชื่อม.

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก, วางป้ายของมันอยู่นอกส่วนของพาย, และปรับออฟเซตแนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/). ออฟเซตเหล่านี้สัมพันธ์กับความกว้างและความสูงของแผนภูมิ ตามลำดับ.

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

![แผนภูมิเสี้ยวที่มีตำแหน่งป้ายข้อมูลที่ปรับแล้ว](pie-chart-adjusted-label.png)

## **จัดรูปแบบเส้นเชื่อม**

เมื่อป้ายแผนภูมิเสี้ยวนั่งอยู่นอกส่วนของพาย, เส้นเชื่อมช่วยให้ผู้อ่านจับคู่แต่ละค่าให้ตรงกับส่วนที่ถูกต้อง สีที่ตัดกันและเส้นที่หนาขึ้นเล็กน้อยทำให้การเชื่อมต่อดูง่ายขึ้น, ในขณะที่ความโปร่งใสและสไตล์ประดับทำให้เส้นดูไม่รบกวนสายตา.

ใช้ [getLeaderLinesFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelcollection/getleaderlinesformat/) เพื่อจัดรูปแบบเส้นเชื่อมระดับคอลเลกชันป้ายข้อมูลของชุดข้อมูล การตั้งค่าใน `series.getLabels().getLeaderLinesFormat().getLine()` จะนำไปใช้กับคอลเลกชัน, ไม่ใช่กับป้ายแต่ละอัน.

ตัวอย่างนี้สร้างแผนภูมิเสี้ยวด้วยข้อมูลเริ่มต้น, แสดงค่าที่อยู่นอกส่วนของพาย, และเปิดใช้ [setShowLeaderLines](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowleaderlines/). มันย้ายป้ายสองอันให้ห่างจากส่วนของพายมากขึ้นโดยใช้การออฟเซต [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/), ซึ่งแสดงเป็นส่วนของความกว้างและความสูงของแผนภูมิ ไม่จำเป็นต้องมีงานนำเสนออินพุต.

รูปแบบ [getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/getfillformat/) ของเส้นตั้งค่าสีฟ้าเข้มที่มีค่าอัลฟา 191 จาก 255, ให้ความโปร่งใสประมาณ 25% [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setwidth/) ตั้งความหนาเป็น 2 จุด, และ [setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/setdashstyle/) ทำให้เส้นเป็นแบบประดับ.

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

    // ย้ายป้ายสองอันให้ห่างออกไปจากส่วนของพายมากขึ้น.
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

การเปิดใช้งานเส้นเชื่อมไม่ได้รับประกันว่าจะมีเส้นแสดงสำหรับทุกป้าย การมองเห็นขึ้นกับตำแหน่งป้ายและพฤติกรรมการจัดวางของแผนภูมิ ในตัวอย่างนี้, ป้ายสองอันที่ย้ายตำแหน่งมีเส้นเชื่อมที่มองเห็นได้; ป้ายที่อยู่ใกล้ส่วนของพายไม่จำเป็นต้องมีเส้นเชื่อม.

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกและเรนเดอร์ด้วย Aspose.Slides:

![แผนภูมิเสี้ยวที่มีเส้นเชื่อมสีฟ้า โปร่งแสงบาง ประดับ เชื่อมสองป้ายนอกกับส่วนของพาย](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่พล็อต ชุดข้อมูล A แสดงคอลัมน์ที่มองเห็น, ในขณะที่ชุดข้อมูล B และ C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกมันถูกซ่อนไปโดยลบการเติมสีและเส้นขอบ วิธี [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setoverlap/) ทำให้ทั้งสามชุดข้อมูลจัดแนวตรงกับศูนย์กลางหมวดหมู่เดียวกัน.

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartplotarea/) จองพื้นที่สำหรับแถวป้าย หลังจากที่ [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) คำนวณตำแหน่งค่าเริ่มต้น, [DataLabel.setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/setx/) และ [DataLabel.setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabel/sety/) รักษาการจัดแนวแนวนอนและใช้การออฟเซตแนวตั้งเพื่อจัดเรียงป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าของชุดข้อมูล; เฉพาะหัวแถวจะเป็นรูปแบบข้อความแยกต่างหาก.

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
            // ซ่อนคอลัมน์ของ B และ C แต่คงป้ายข้อมูลไว้.
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

    // จัดตำแหน่งชุดข้อมูลทั้งสามให้ศูนย์กลางของหมวดหมู่เดียวกัน.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(java.newByte(100));

    // ใช้เส้นกริดน้อยลงสำหรับตัวอย่างแบบกะทัดรัดนี้.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // จองพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายข้อมูล.
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
            // คงตำแหน่งแนวนอนค่าเริ่มต้น. Y เป็นการออฟเซตจาก
            // ตำแหน่งป้ายค่าเริ่มต้น, แสดงเป็นสัดส่วนของความสูงแผนภูมิ.
            dataLabel.setX(0);
            dataLabel.setY(java.newFloat(rowTop - dataLabel.getActualY() / chart.getHeight()));
        }

        // เฉพาะหัวแถวเป็นรูปแบบข้อความแยกต่างหาก.
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

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่พล็อต](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันบนแผนภูมิที่หนาแน่นได้อย่างไร?**  
ใช้การจัดวางป้ายอัตโนมัติ, เส้นเชื่อม, และลดขนาดฟอนต์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น หมวดหมู่) หรือแสดงป้ายเฉพาะค่าที่สุดหรือจุดสำคัญเท่านั้น.

**ฉันจะปิดการแสดงป้ายเฉพาะสำหรับค่าศูนย์, ค่าติดลบ, หรือค่าที่ว่างได้อย่างไร?**  
กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงค่าที่เป็น 0, ค่าติดลบ, หรือค่าที่หายไปตามกฎที่กำหนด.

**ฉันจะทำให้สไตล์ของป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**  
กำหนดฟอนต์และขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้งานฟอนต์สำรอง.