---
title: จัดการ Workbook ของแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: Workbook ของแผนภูมิ
type: docs
weight: 70
url: /th/nodejs-java/chart-workbook/
keywords:
- workbook ของแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์ workbook
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- workbook ภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืน workbook
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการ workbook ของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับ workbook ของแผนภูมิใน Aspose.Slides ซึ่งแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมผ่านสตรีมของ workbook, ใช้เซลล์ของ workbook เป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของ worksheet, และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนด workbook ภายนอก, ดึงเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook มีให้ใช้

สำหรับเซลล์ของ workbook ที่แทนค่าข้อมูลที่หายไป ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/) เพื่อทำความเข้าใจความแตกต่างระหว่างเซลล์ว่างกับค่าเป็นศูนย์ และเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) เพื่อควบคุมว่าถูกต้องหรือไม่ว่าแผนภูมิจะพล็อตข้อมูลจากแถวและคอลัมน์ของ worksheet ที่ซ่อนอยู่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและซ่อน การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของ worksheet

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรกของมัน worksheet ที่ฝังอยู่, `Sheet1`, มีช่วงแหล่งข้อมูล `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่า

| แถวของ Worksheet | A: เดือน | B: ปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#isHidden) เพื่อสอบสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: รักษา workbook ที่ฝังอยู่ด้วย [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) เพื่อคืนช่วงทั้งหมด, รวมถึงประเภทเดือนกุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนแค่แฟล็กไม่เพียงพอในการรีเฟรชข้อมูลแผนภูมิที่แคชและป้ายชื่อประเภทของตัวอย่างนี้ ตัวอย่างจะแปลงบัฟเฟอร์ Node.js เป็นอาเรย์ของไบต์ Java ก่อนส่งให้เมธอดเขียน

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
                // คืนค่าช่วงแหล่งข้อมูลทั้งหมด รวมถึงประเภทที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: เวอร์ชันหนึ่งมีค่า Retail ที่มองเห็นได้เท่านั้น (10 และ 20), อีกเวอร์ชันหนึ่งมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการพล็อต แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสอง workbook ที่ฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าปลีกและขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ที่ว่างเปล่า [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือแยกข้อมูลแหล่งที่มาที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูล workbook ในงานนำเสนอที่มีอยู่, ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่า worksheet ใดที่แผนภูมิแต่ละอันใช้ [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getRange) จะคืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่ระบุ worksheet, เช่น `Sheet1!$A$1:$D$5`. ที่นี่ `Sheet1` คือชื่อ worksheet, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมถึงเครื่องหมายดอลลาร์แสดงการอ้างอิงแบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือ workbook ของมัน หากแผนภูมิไม่ใช้ workbook เป็นแหล่งข้อมูล, จะโยน `InvalidOperationException` สำหรับข้อมูลเพิ่มเติมดูที่ [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างโดยตรงบนแต่ละสไลด์เพื่อค้นหาแผนภูมิ พิมพ์ชื่อและช่วงแหล่งข้อมูลของแต่ละแผนภูมิ หากแผนภูมิไม่ใช้ workbook, จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมืถัดไป

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

Aspose.Slides for Node.js via Java ให้เมธอด [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ช่วยให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิจะต้องจัดระเบียบในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นทาง

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่าน workbook ที่ฝังอยู่เป็นอาเรย์ของไบต์, ลบ series และ categories ปัจจุบัน, แล้วเขียน workbook เดิมกลับเข้าไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบการจัดวางแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังด้วยเวอร์ชันที่แก้ไข, แผนภูมิก็จะยังคงเก็บ series และคอลเลกชันประเภทเดิม ความไม่ตรงกันนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#validateChartLayout) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ควรลบ series และ categories ที่มีอยู่ก่อนเขียน workbook ที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์ทำเครื่องหมายตำแหน่งที่การแก้ไข workbook จะเกิดขึ้น; ตัวอย่างที่รันได้เขียน workbook ดั้งเดิมกลับเข้าไปและตรวจสอบการจัดวางในหน่วยความจำ

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

        // แก้ไขไบต์ของ workbook ที่นี่, ตัวอย่างเช่น โดยใช้ Aspose.Cells.

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

การลบคอลเลกชันจะเอาการอ้างอิงข้อมูลที่ล้าสมัยออกก่อนที่ workbook จะถูกเขียนกลับ สร้าง mapping ของ series และ category ที่จำเป็นสำหรับ workbook ที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์ของ Workbook เป็นป้ายกำกับข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ของ workbook เป็นป้ายกำกับข้อมูลแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับที่มีข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บน worksheet 0 เป็นป้ายกำกับสามค่าแรกของ series แรก, เปิดใช้งานป้ายกำกับจากเซลล์, แล้วบันทึกงานนำเสนอที่อัปเดต

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

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) ให้การเข้าถึง worksheets ใน workbook ของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละ worksheet ไปยังคอนโซล

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลเริ่มต้นและตั้งค่า two series name โดยใช้แหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้สตริงตัวอักษร; ชื่อที่สองใช้เซลล์ C1 ใน worksheet 0 การนำเข้า [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) เลือกแหล่งข้อมูลสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อ series ที่อัปเดต

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

## **ตรวจจับรูปแบบ Workbook ที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ workbook Excel ไบเนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) เพื่อตรวจสอบรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่ฝัง workbook .xlsb

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

Aspose.Slides รองรับการใช้ workbook ภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้าง Workbook ภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) เพื่อส่งออก workbook ของแผนภูมิที่ฝังเป็นไฟล์และเชื่อมโยงแผนภูมิไปยัง workbook ภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเส้นพายที่มีข้อมูลเริ่มต้นและส่งออก workbook ของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนด workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ, แล้วบันทึกงานนำเสนอที่ลิงก์ไว้

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

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากไฟล์ถูกย้าย)

แม้คุณจะไม่สามารถแก้ไขข้อมูลใน workbook ที่จัดเก็บบนตำแหน่งระยะไกลหรือทรัพยากรได้, แต่คุณยังสามารถใช้ workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับ workbook ภายนอก, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้ workbook ภายนอกที่ worksheet ชื่อ `Sheet1` มีชื่อ series ใน B1, ชื่อประเภทใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเส้นพาย, ลิงก์ workbook, และใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setRange) เพื่อแมป A1:B4 ไปยัง series หนึ่งและประเภทสามประเภท บันทึกงานนำเสนอพร้อมแผนภูมิลิงก์

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

พารามิเตอร์ `updateChartData` ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) ควบคุมว่าจะโหลด workbook หรือไม่

* เมื่อ `updateChartData` เป็น `false`, จะอัปเดตเฉพาะเส้นทางของ workbook เท่านั้น ข้อมูลแผนภูมิไม่ถูกโหลดหรืออัปเดตจาก workbook ปลายทาง, ดังนั้น workbook สามารถไม่มีอยู่ได้
* เมื่อ `updateChartData` เป็น `true`, ข้อมูลแผนภูมิจะอัปเดตจาก workbook ปลายทาง

ตัวอย่างต่อไปกำหนด URL placeholder โดยตั้งค่า `updateChartData` เป็น `false`. จะรักษาข้อมูลเริ่มต้นของแผนภูมิพายและบันทึกงานนำเสนอโดยไม่ได้โหลด workbook ที่ไม่มีอยู่

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

### **ดึงเส้นทาง Workbook แหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุ workbook ที่เชื่อมโยงกับแผนภูมิ, ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทาง workbook ของมัน

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มี workbook ภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมกับ workbook ภายนอก, ตัวอย่างจะแสดงผล [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) ไปยังคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาใน workbook ภายใน หากไม่สามารถโหลด workbook ภายนอกได้, จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมโยงกับ workbook ภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อิงจากเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 แล้วบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าของเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง, ดังนั้นให้ใช้สำเนาหากต้องการเก็บ workbook ดั้งเดิมไว้

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

หากแผนภูมิใช้ workbook ภายนอกที่หายไปหรือไม่มีให้ใช้งาน, Aspose.Slides สามารถสร้างใหม่ workbook ของแผนภูมิจากข้อมูลที่แคชไว้ในงานนำเสนอ สร้าง [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), แล้วตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง JavaScript ด้านล่างกู้คืนข้อมูล workbook สำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิง workbook ภายนอกที่ไม่มีให้ใช้งาน เข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

หาก workbook ภายนอกไม่มีให้ใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้, เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับ workbook ภายนอกหลังจากที่งานนำเสนออัปเดตครั้งสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับ workbook ภายนอกหรือที่ฝังอยู่?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getDataSourceType) และ [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากแหล่งเป็น workbook ภายนอก, คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยัง workbook ภายนอกหรือไม่, แล้วจัดเก็บอย่างไร?**

ได้. หากคุณระบุเส้นทางสัมพัทธ์, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้าย workbook อาจต้องอัปเดตลิงก์

**ฉันสามารถใช้ workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, workbook เหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม, การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath). การแก้ไขข้อมูลแผนภูมิที่อิงเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องที่เชื่อมโยง ใช้สำเนาของ workbook หากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ถ้าไฟล์ภายนอกถูกตั้งรหัสผ่านควรทำอย่างไร?**

Aspose.Slides ไม่รับพาสเวิร์ดเมื่อทำการลิงก์ วิธีทั่วไปคือถอดรหัสล่วงหน้าหรือเตรียมสำเนาที่ไม่ได้เข้ารหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของมันเอง หากทุกแผนภูมิอ้างอิงไฟล์เดียวกัน, การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล