---
title: จัดการ Workbook ของแผนภูมิในงานนำเสนอโดยใช้ JavaScript
linktitle: Workbook ของแผนภูมิ
type: docs
weight: 70
url: /th/nodejs-java/chart-workbook/
keywords:
- Workbook ของแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์ของ Workbook
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- Workbook ภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืน Workbook
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการ Workbook ของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ workbook ของแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่าน stream ของ workbook, ใช้เซลล์ของ workbook เป็นป้ายข้อมูลของแผนภูมิ, เข้าถึงคอลเลกชันของ worksheet, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนด workbook ภายนอก, ดึงพาธของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook มีพร้อมใช้งาน

สำหรับเซลล์ของ workbook ที่เป็นข้อมูลที่หายไป ดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างและศูนย์, รวมถึงการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ของ worksheet ที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของกราฟ; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของ worksheet

ไฟล์ [sample presentation](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรกของมัน Worksheet ที่ฝังไว้, `Sheet1`, มีช่วงข้อมูลต้นทางดังต่อไปนี้, `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่าอยู่

| แถวของ Worksheet | A: เดือน | B: ขายปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (แถวที่ซ่อน) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) เพื่อดูสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะพิมพ์ `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บ workbook ที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/). เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อคืนช่วงเต็มรวมถึงหมวดหมู่เดือน February ที่ซ่อน การเปลี่ยนค่า flag อย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิที่แคชไว้และป้ายหมวดหมู่ ตัวอย่างแปลงบัฟเฟอร์ Node.js ที่คืนค่าเป็นอาร์เรย์ไบต์ของ Java ก่อนส่งให้เมธอดเขียน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("hidden-source-data.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const workbook = chart.getChartData().getChartDataWorkbook();
        console.log("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        console.log("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        console.log("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        const workbookBuffer = chart.getChartData().readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);
        for (const visibleOnly of [true, false]) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // รีเฟรชข้อมูลแผนภูมิจาก workbook ที่ฝังอยู่.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // คืนค่าช่วงต้นฉบับทั้งหมดรวมถึงหมวดที่ซ่อนอยู่.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", aspose.slides.SaveFormat.Pptx);
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: หนึ่งเวอร์ชันมีเฉพาะค่าการขายปลีกที่มองเห็นได้ (10 และ 20), อีกเวอร์ชันมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการพล็อต แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ใน workbook ที่ฝังทั้งสองเวอร์ชัน

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทั้งหมด (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าการขายปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทั้งหมด: ค่าการขายปลีกและขายส่งสำหรับเดือนมกราคม, February, และ March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) ควบคุมการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลต้นทางที่ซ่อนดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูล workbook ในการนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่า worksheet ใดใช้โดยแผนภูมิแต่ละอัน เมธอด [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) จะคืนช่วงข้อมูลปัจจุบันในรูปสูตรที่มีการระบุ worksheet เช่น `Sheet1!$A$1:$D$5`. ที่นี่ `Sheet1` คือชื่อ worksheet, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองค่า `$` แสดงการอ้างอิงแบบ absolute

เมธอดอ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือ workbook หากแผนภูมิไม่ได้ใช้ workbook เป็นแหล่งข้อมูล จะโยน `InvalidOperationException` ดูข้อมูลเพิ่มเติมได้ที่ [อ้างอิง API ของ ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดการนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อค้นหาแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงต้นทาง หากแผนภูมิไม่ใช้ workbook จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมิถัดไป

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                const chart = shape;
                try {
                    const range = chart.getChartData().getRange();
                    console.log(chart.getName() + ": " + range);
                } catch (exception) {
                    if (exception.cause && java.instanceOf(exception.cause, "com.aspose.slides.exceptions.InvalidOperationException")) {
                        console.log(chart.getName() + ": The chart does not use a workbook as its data source.");
                    } else {
                        console.log(chart.getName() + ": Could not retrieve the data range: " + exception.message);
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides for Node.js via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) และ [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับต้นฉบับ

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่าน workbook ที่ฝังเป็นอาร์เรย์ไบต์, ลบ series และ categories เดิม, แล้วเขียน workbook เดิมกลับเข้าไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกการนำเสนอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **ตรวจสอบเค้าโครงแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังไว้ด้วยเวอร์ชันที่แก้ไขแล้ว, แผนภูมิจะยังคงมี series และ collection ของ category เดิม สิ่งนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ลบ series และ categories เดิมก่อนเขียน workbook ที่อัปเดตกลับเข้าไปในแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิเป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์บ่งชี้ที่ที่การแก้ไข workbook จะเกิดขึ้น; ตัวอย่างที่รันได้เขียน workbook ดั้งเดิมกลับเข้าไปและตรวจสอบเค้าโครงในหน่วยความจำ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        const workbookBuffer = chartData.readWorkbookStream();
        const workbookBytes = Array.from(workbookBuffer);
        const workbookData = java.newArray("byte", workbookBytes);

        // แก้ไขไบต์ของ workbook ที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

## **ตั้งรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์ของ Workbook**

ใช้ [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) เพื่อควบคุมวิธีการแสดงค่าตัวเลขใน workbook ที่ฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง ให้ค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและพล็อตแผนภูมิได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่เก็บ `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%` แต่ไม่เปลี่ยนค่าเก็บเป็น `12.5` เช่นเดียวกัน `0.00000` จะทำให้ `0.1234567` แสดงเป็น `0.12346` โดยไม่ปัดค่าเก็บ หากรูปแบบกำหนดเองเป็นสตริงเปล่า (`""`) จะใช้รูปแบบที่ได้จาก [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). ใน worksheet 0, B2 มีอัตราแปลงและ C2 มีสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าของแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายค่าเชื่อมโยงกับรูปแบบต้นทาง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    const categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    const percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    const percentageName = workbook.getCell(0, "B1", "Conversion rate");
    const percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    const precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    const precisionName = workbook.getCell(0, "C1", "Coefficient");
    const precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (let seriesIndex = 0; seriesIndex < chart.getChartData().getSeries().size(); seriesIndex++) {
        const series = chart.getChartData().getSeries().get_Item(seriesIndex);
        const labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปแบบเซลล์ของ workbook แยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายแสดงค่าจากเซลล์ต้นทางเนื่องจาก [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) ถูกตั้งเป็น `true` และตามรูปแบบตัวเลขต้นทางเนื่องจาก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) ถูกตั้งเป็น `true` หลังจากบันทึกและเปิดการนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามด้านล่าง แกนแนวตั้งใช้รูปแบบตัวเลขของตนเอง ตั้งค่าด้วย [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) เป็น `0.00` และ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) ตั้งเป็น `false`

หากต้องการฟอร์แมตป้ายข้อมูลแยกจากแหล่ง ให้ตั้งค่า flag เชื่อมโยงต้นทางเป็น `false` แล้วกำหนดรูปแบบด้วย [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/). วิธีนี้จะไม่เปลี่ยนรูปแบบของเซลล์ workbook ตัวอย่างเช่น รูปแบบป้ายแยก `0.00` จะทำให้ค่าแรกแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%`. ดู [Chart Data Labels](/slides/th/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการฟอร์แมตป้ายโดยตรง

ภาพด้านล่างถูกเรนเดอร์จากการนำเสนอที่บันทึกแล้วหลังจากเปิดใหม่:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ตั้งค่าเซลล์ของ Workbook เป็นป้ายข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ของ workbook เป็นป้ายข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลเริ่มต้นเป็นรูปร่างแรกบนสไลด์แรกของการนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บน worksheet 0 สำหรับป้ายสามรายการแรกของ series แรก, เปิดใช้งานป้ายจากเซลล์, และบันทึกการนำเสนอที่อัปเดต

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("chart2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    const series = chart.getChartData().getSeries().get_Item(0);
    const workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **จัดการ Worksheet**

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) ให้เข้าถึง worksheet ต่าง ๆ ใน workbook ของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิวงกลมที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อ worksheet แต่ละอันลงคอนโซล

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    const workbook = chart.getChartData().getChartDataWorkbook();

    for (let i = 0; i < workbook.getWorksheets().size(); i++) {
        console.log(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **ระบุประเภทแหล่งข้อมูล**

ค่าจุดของ series สามารถจัดเก็บเป็น literal ตัวเลขได้โดยตรง ดู [ตั้งค่าค่าชุดข้อมูลโดยใช้ตัวเลขลิตะรัล](/slides/th/nodejs-java/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างเต็มที่บันทึกและอ่านค่าดังกล่าว ประเภทแหล่งข้อมูลของค่าจุดแยกจากการตั้งค่า workbook ภายในหรือภายนอกของแผนภูมิ; การใช้ literal ตัวเลขไม่ทำให้ workbook ที่ฝังหายไปโดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3D ที่มีข้อมูลเริ่มต้นและตั้งชื่อ series สองชื่อโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้ string literal; ชื่อที่สองใช้เซลล์ C1 บน worksheet 0. ตัวเลือก [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) กำหนดแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกการนำเสนอพร้อมชื่อ series ที่อัปเดต

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    const literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    const cellName = chart.getChartData().getSeries().get_Item(1).getName();
    const nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(aspose.slides.DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจจับรูปแบบ Workbook ฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ workbook ไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของการนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ, และพิมพ์ข้อความวินิจฉัยสำหรับแผนภูมิที่มี workbook .xlsb ฝัง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (!(java.instanceOf(shape, "com.aspose.slides.IChart"))) {
            continue;
        }

        const chart = shape;
        const chartData = chart.getChartData();
        const isInternalWorkbook = chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook;
        const isBinaryMacro = chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            console.log("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook ภายนอก**

Aspose.Slides รองรับการใช้ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้าง Workbook ภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) และ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) เพื่อส่งออก workbook ของแผนภูมิที่ฝังเป็นไฟล์และเชื่อมลิงก์แผนภูมิกับ workbook ภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวงกลมที่มีข้อมูลเริ่มต้นและส่งออก workbook ของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนด workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ, จากนั้นบันทึกการนำเสนอที่เชื่อมลิงก์

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");
const fileSystem = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    const workbookPath = path.resolve("externalWorkbook1.xlsx");
    const workbookData = chart.getChartData().readWorkbookStream();
    try {
        fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
        chart.getChartData().setExternalWorkbook(workbookPath);
        
        presentation.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
    } catch (exception) {
        console.log("Could not write the external workbook: " + exception.message);
    }
} finally {
    presentation.dispose();
}
```

### **ตั้งค่า Workbook ภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตพาธของ workbook ภายนอก (หากมีการย้ายตำแหน่ง)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลใน workbook ที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังสามารถใช้ workbook ดังกล่าวเป็นแหล่งข้อมูลภายนอกได้ หากให้พาธแบบสัมพันธ์สำหรับ workbook ภายนอก ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้ workbook ภายนอกที่ worksheet ชื่อ `Sheet1` มีชื่อ series ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิวงกลม, เชื่อมต่อ workbook, และใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อแมป A1:B4 เป็น series เดียวและสามหมวด, จากนั้นบันทึกการนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    const chartData = chart.getChartData();
    const workbookPath = path.resolve("externalWorkbook.xlsx");

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) ควบคุมว่า workbook จะถูกโหลดหรือไม่

* เมื่อ `updateChartData` เป็น `false`, จะอัปเดตเฉพาะพาธของ workbook เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook ปลายทาง, ดังนั้น workbook สามารถไม่มีได้
* เมื่อ `updateChartData` เป็น `true`, ข้อมูลแผนภูมิจะอัปเดตจาก workbook ปลายทาง

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้ง `updateChartData` เป็น `false`. มันยังคงใช้ข้อมูลเริ่มต้นของแผนภูมิวงกลมและบันทึกการนำเสนอโดยไม่มีการโหลด workbook ที่ไม่มีอยู่

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **รับพาธของ Workbook แหล่งข้อมูลภายนอกจากแผนภูมิ**

เพื่อระบุว่าแผนภูมิมี workbook ที่เชื่อมโยงหรือไม่, ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกและดึงพาธของ workbook นั้นออกมา

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของการนำเสนอที่เชื่อมกับ workbook ภายนอก หากเป็นแผนภูมิที่เชื่อมกับ workbook ภายนอก จะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ไปที่คอนโซล แล้วบันทึกสำเนาการนำเสนอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("externalWorkbook.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const chartData = chart.getChartData();
        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
            console.log(chartData.getExternalWorkbookPath());
        } else {
            console.log("The chart does not use an external workbook.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาใน workbook ภายใน หากไม่สามารถโหลด workbook ภายนอกได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับ workbook ภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่รองรับเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 และบันทึกการนำเสนอที่อัปเดต การแก้ไขค่าเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้, ดังนั้นควรใช้สำเนาหากต้องการเก็บ workbook ต้นฉบับไว้

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            const valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
            } else {
                console.log("The first data point is not linked to a workbook cell.");
            }
        } else {
            console.log("The chart has no data points to edit.");
        }
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิกำหนด workbook ภายนอกที่หายหรือไม่สามารถเข้าถึงได้, Aspose.Slides สามารถสร้างใหม่จากข้อมูลที่แคชในไฟล์การนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/), และตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง JavaScript ด้านล่างกู้คืนข้อมูล workbook สำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิง workbook ภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && java.instanceOf(slide.getShapes().get_Item(0), "com.aspose.slides.IChart")) {
        const chart = slide.getShapes().get_Item(0);
        const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนได้ที่นี่.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หาก workbook ภายนอกไม่มีอยู่และการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับ workbook ภายนอกหลังจากที่การนำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันจะกำหนดได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับ workbook ภายนอกหรือที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); หากแหล่งเป็น workbook ภายนอก คุณสามารถอ่านพาธเต็มเพื่อยืนยันว่ามีไฟล์ภายนอกถูกใช้

**รองรับพาธแบบสัมพันธ์ไปยัง workbook ภายนอกหรือไม่, และจัดเก็บอย่างไร?**

ใช่ หากคุณระบุพาธแบบสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธแบบเต็มโดยอัตโนมัติ การนำเสนอเก็บพาธแบบเต็มในไฟล์ PPTX, ดังนั้นการย้าย workbook อาจต้องอัปเดตลิงก์

**สามารถใช้ workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, workbook ดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

การนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) การแก้ไขค่าที่มาจากเซลล์ของแผนภูมิอาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ใช้สำเนาของ workbook หากต้องการให้ไฟล์ต้นฉบับคงสภาพเดิม

**ควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ไม่มีการเข้ารหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้ ทุกแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล**