---
title: จัดการ Workbook ของแผนภูมิในงานนำเสนอโดยใช้ JavaScript
linktitle: Workbook ของแผนภูมิ
type: docs
weight: 70
url: /th/nodejs-java/chart-workbook/
keywords:
- Workbook ของแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์ Workbook
- ป้ายข้อมูล
- Worksheet
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
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการ Workbook ของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ workbook ของแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิโดยใช้สตรีมของ workbook ใช้เซลล์ของ workbook เป็นป้ายข้อมูลของแผนภูมิ เข้าถึงคอลเลกชันของ worksheet และระบุประเภทของแหล่งข้อมูลสำหรับค่าแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนด workbook ภายนอก ดึงเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อ workbook พร้อมใช้งาน

สำหรับเซลล์ workbook ที่เป็นข้อมูลที่หายไป ให้ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับศูนย์ และดูการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) เพื่อควบคุมว่าระบบวาดแผนภูมิจะแสดงข้อมูลจากแถวและคอลัมน์ของ worksheet ที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อวาดเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมเซลล์ที่มองเห็นและซ่อน ทั้งสองค่าเป็นการกำหนดพฤติกรรมการวาดแผนภูมิ ไม่ได้ทำให้แถวหรือคอลัมน์ของ worksheet ซ่อนหรือแสดง

[ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีแผนภูมิแท่งเป็นวัตถุปแรกบนสไลด์แรก Worksheet ที่ฝังอยู่คือ `Sheet1` มีช่วงข้อมูลต้นทาง `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์เหล่านั้นยังคงมีค่าอยู่

| แถวใน Worksheet | A: เดือน | B: การค้าปลีก | C: การค้าส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) เพื่อตรวจสอบสถานะการซ่อน วิธีนี้รายงานสถานะโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการวาด: รักษา workbook ที่ฝังอยู่ด้วย [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อคืนช่วงข้อมูลเต็มรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนแค่ค่าธงไม่เพียงพอเพื่อรีเฟรชข้อมูลและป้ายหมวดที่แคชไว้ในตัวอย่างนี้ ตัวอย่างแปลงบัฟเฟอร์ Node.js ที่คืนค่าเป็นอาร์เรย์ไบต์ของ Java ก่อนส่งต่อให้เมธอดเขียน

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
                // คืนช่วงแหล่งข้อมูลทั้งหมด รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: เวอร์ชันหนึ่งมีเฉพาะค่าการค้าปลีกที่มองเห็นได้ (10 และ 20) และอีกเวอร์ชันหนึ่งมีค่าทั้งหกค่า รูปด้านล่างแสดงสองโหมดการวาด แถวที่ 3 และคอลัมน์ C ยังคงซ่อนในทั้งสอง workbook ที่ฝังอยู่

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่า Retail 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่า Retail และ Wholesale สำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนไว้ซึ่งมีค่า แตกต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูล workbook ในการนำเสนอที่มีอยู่ ตรวจสอบช่วงข้อมูลต้นทางเพื่อระบุว่า worksheet ใดที่แผนภูมิใช้ วิธี [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) คืนค่าช่วงข้อมูลปัจจุบันในรูปสูตรที่ระบุ worksheet เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อ worksheet, `!` คั่นกับช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมสัญลักษณ์ `$` แสดงการอ้างอิงคงที่ของแถวและคอลัมน์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือ workbook หากแผนภูมิไม่ใช้ workbook เป็นแหล่งข้อมูล จะโยน `InvalidOperationException` สำหรับข้อมูลเพิ่มเติม ดูที่ [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดการนำเสนอและตรวจสอบรูปทรงบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงต้นทาง หากแผนภูมิไม่ใช้ workbook จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมิถัดไป

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

Aspose.Slides for Node.js via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) และ [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **Note** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิเป็นวัตถุปแรกบนสไลด์แรก อ่าน workbook ที่ฝังอยู่เป็นอาร์เรย์ไบต์ ล้างชุดข้อมูลและหมวดหมู่เดิม แล้วเขียน workbook เดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่บันทึกการนำเสนอ

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

### **ตรวจสอบ Layout ของแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังไว้ด้วย workbook ที่แก้ไขแล้ว แผนภูมิจะยังคงมีชุดข้อมูลและคอลเลกชันหมวดเดิม ความไม่ตรงนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ล้างชุดข้อมูลและหมวดเดิมก่อนเขียน workbook ที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างใช้แผนภูมิที่เป็นวัตถุปแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่ควรแก้ไข workbook; ตัวอย่างที่ทำงานได้เขียน workbook ดั้งเดิมกลับและตรวจสอบ Layout ในหน่วยความจำ

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลค้างก่อนที่ workbook จะถูกเขียนกลับ สร้างชุดข้อมูลและการแมปหมวดใหม่ตามที่จำเป็นสำหรับ workbook ที่อัปเดตก่อนใช้แผนภูมิ

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์ Workbook**

ใช้ [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) เพื่อควบคุมวิธีแสดงค่าตัวเลขใน workbook ที่ฝังอยู่ของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องแสดงอัตราแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง ควรรักษาค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและวาดแผนภูมิได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่เก็บไว้ รูปแบบ `0.0000%` แสดง `0.125` เป็น `12.5000%`; ไม่ได้แทนที่ตัวเลขที่เก็บเป็น `12.5` เช่นเดียวกัน `0.00000` แสดง `0.1234567` เป็น `0.12346` โดยไม่ปัดเศษค่าที่เก็บไว้ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้รูปแบบที่ได้จาก [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิแท่งและเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/). บน worksheet 0, B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าแผนภูมิ ตัวอย่างยังเปิดใช้ป้ายค่าที่เชื่อมกับรูปแบบต้นทาง

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

รูปแบบของเซลล์ workbook แยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายจะแสดงค่าจากเซลล์ต้นทางเพราะ [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) ตั้งเป็น `true` และเชื่อมรูปแบบตัวเลขกับแหล่งที่มาด้วย [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) ตั้งเป็น `true` หลังจากบันทึกและเปิดการนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามด้านล่าง แกนแนวตั้งใช้รูปแบบตัวเลขของตนเอง ตั้งด้วย [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) เป็น `0.00` และตั้ง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) เป็น `false`

หากต้องการกำหนดรูปแบบป้ายข้อมูลแยกจากแหล่ง ให้ตั้งค่าสถานะเชื่อมกับแหล่งเป็น `false` แล้วกำหนดรูปแบบด้วย [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) วิธีนี้ไม่ทำให้รูปแบบของเซลล์ workbook เปลี่ยน ตัวอย่างเช่น ป้ายที่มีรูปแบบอิสระ `0.00` จะทำให้ค่าแรกแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการกำหนดรูปแบบป้ายโดยตรง

![แผนภูมิแท่งพร้อมป้ายที่เชื่อมกับแหล่งแสดง 12.5000% และ 0.12346 พร้อมแกนตัวเลขที่กำหนดรูปแบบแยกกัน.](custom-cell-formats.png)

## **กำหนดเซลล์ Workbook เป็นป้ายข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ workbook เป็นป้ายข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลเริ่มต้นบนสไลด์แรกของการนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บน worksheet 0 สำหรับสามป้ายแรกของชุดข้อมูลแรก เปิดใช้ป้ายจากเซลล์และบันทึกการนำเสนอที่อัปเดต

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

## **จัดการ Worksheets**

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) ให้การเข้าถึง worksheets ใน workbook ของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อ worksheet แต่ละรายการลงคอนโซล

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

## **ระบุประเภทของแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิแท่ง 3 มิติด้วยข้อมูลเริ่มต้นและตั้งค่าชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้สตริงลิตเตรัล; ชื่อที่สองใช้เซลล์ C1 บน worksheet 0 รุ่น [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) ระบุแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกการนำเสนอพร้อมชื่อชุดข้อมูลที่อัปเดต

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

Aspose.Slides ไม่รองรับรูปแบบ workbook ไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) ร่วมกับรุ่น [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปทรงบนสไลด์แรกของการนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิและพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มี workbook .xlsb ฝังอยู่

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

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) และ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) เพื่อส่งออก workbook ของแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิกับ workbook ภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้นและส่งออก workbook ของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนด workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกการนำเสนอที่เชื่อมโยง

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

### **กำหนด Workbook ภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลใน workbook ที่จัดเก็บในตำแหน่งระยะไกลหรือแหล่งทรัพยากรได้ คุณยังคงใช้ workbook ดังกล่าวเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางเชิงสัมพันธ์สำหรับ workbook ภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้ workbook ภายนอกที่ worksheet ชื่อ `Sheet1` มีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4 และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิพาย เชื่อม workbook แล้วใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อแมป A1:B4 ไปยังชุดข้อมูลหนึ่งชุดและสามหมวด บันทึกการนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) ควบคุมว่าจะโหลด workbook หรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะเส้นทางของ workbook เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook เป้าหมาย ดังนั้น workbook สามารถไม่มีอยู่ได้
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะได้รับการอัปเดตจาก workbook เป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้ง `updateChartData` เป็น `false` การนำเสนอยังคงมีข้อมูลพายเริ่มต้นและบันทึกโดยไม่โหลด workbook ที่ไม่มีอยู่

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

### **ดึงเส้นทาง Workbook ของแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุ workbook ที่เชื่อมกับแผนภูมิ ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทาง workbook ของมัน

ตัวอย่างนี้ตรวจสอบวัตถุปแรกบนสไลด์แรกของการนำเสนอที่มี workbook ภายนอกเชื่อมอยู่ หากเป็นแผนภูมิที่เชื่อมกับ workbook ภายนอก ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ลงคอนโซล แล้วบันทึกสำเนาของการนำเสนอ

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

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับที่ทำการเปลี่ยนแปลงใน workbook ภายใน เมื่อไม่สามารถโหลด workbook ภายนอกได้ ระบบจะโยนข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นวัตถุปแรกบนสไลด์แรกและเชื่อมกับ workbook ภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่สนับสนุนโดยเซลล์ของจุดข้อมูลแรกในชุดข้อมูลแรกเป็น 100 แล้วบันทึกการนำเสนอที่อัปเดต การแก้ไขค่าจากเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมไว้ ดังนั้นควรใช้สำเนาหากต้องการรักษา workbook ดั้งเดิม

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

หากแผนภูมิใช้ workbook ภายนอกที่หายไปหรือไม่มีอยู่ Aspose.Slides สามารถสร้าง workbook ของแผนภูมิจากข้อมูลที่แคชไว้ในไฟล์การนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/), และตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง JavaScript ด้านล่างกู้คืนข้อมูล workbook สำหรับแผนภูมิที่เป็นวัตถุปแรกบนสไลด์แรกและอ้างอิง workbook ภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หาก workbook ภายนอกไม่มีอยู่และการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเพื่อเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับ workbook ภายนอกหลังจากการนำเสนออัปเดตครั้งสุดท้าย

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมกับ workbook ภายนอกหรือที่ฝังไว้?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); หากแหล่งเป็น workbook ภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกหรือไม่

**รองรับเส้นทางเชิงสัมพันธ์ไปยัง workbook ภายนอกหรือไม่และเก็บอย่างไร?**

รองรับ. หากระบุเส้นทางเชิงสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ การนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้าย workbook อาจต้องอัปเดตลิงก์

**ฉันสามารถใช้ workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, workbook ดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

การนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). การแก้ไขค่าที่สนับสนุนโดยเซลล์ของแผนภูมิอาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมอยู่ ใช้สำเนาของ workbook หากต้องการให้ไฟล์ต้นฉบับคงที่

**จะทำอย่างไรหากไฟล์ภายนอกถูกตั้งรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือเอาการป้องกันออกล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่นโดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่่อโหลดข้อมูลใหม่อีกครั้ง