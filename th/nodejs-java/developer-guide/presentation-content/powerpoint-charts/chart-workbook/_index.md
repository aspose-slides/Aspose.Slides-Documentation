---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/nodejs-java/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊กแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิโดยใช้สตรีมเวิร์กบุ๊ก ใช้เซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลของแผนภูมิ เข้าถึงคอลเลกชันเวิร์กชีต และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

เนื้อหายังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก ดึงพาธของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่เป็นข้อมูลที่หายไป ให้ดู [ควบคุมการแสดงของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างกับศูนย์และเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/#setPlotVisibleCellsOnly) เพื่อควบคุมว่าภาพแผนภูมิจะพล็อตข้อมูลจากแถวและคอลัมน์ของเวิร์กชีตที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิ; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของเวิร์กชีต

ดาวน์โหลด [hidden-source-data.pptx](hidden-source-data.pptx) แล้ววางไว้ในไดเรกทอรีทำงาน สไลด์แรกของไฟล์มีแผนภูมิคอลัมน์เป็นรูปทรงแรก เวิร์กชีตที่ฝังไว้ `Sheet1` มีช่วงข้อมูลต้นแบบต่อไปนี้ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ของพวกมันยังคงมีค่าอยู่

| แถวของเวิร์กชีต | A: เดือน | B: ปลีก | C: ส่งขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdatacell/#isHidden) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: คงเวิร์กบุ๊กที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) แล้วโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#setRange) เพื่อเรียกคืนช่วงเต็มรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าธงอย่างเดียวไม่เพียงพอในการรีเฟรชข้อมูลแผนภูมิที่แคชและป้ายหมวดของตัวอย่างนี้ ตัวอย่างจะแปลงบัฟเฟอร์ Node.js ที่คืนค่าเป็นอาร์เรย์ไบต์ของ Java ก่อนส่งให้เมธอดเขียน

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

            // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊กที่ฝังอยู่.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // กู้คืนช่วงต้นทางทั้งหมด รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึก `hidden_cells_true.pptx` ที่มีเฉพาะค่าปลีกที่มองเห็นได้ (10 และ 20) และ `hidden_cells_false.pptx` ที่มีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพล็อต แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊กที่ฝังไว้

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าปลีกและค่าขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนที่มีค่าแตกต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/#setDisplayBlanksAs) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลต้นทางที่ซ่อน ดู [ควบคุมการแสดงของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/#control-the-display-of-empty-cells) เป็นตัวอย่าง

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ก**

Aspose.Slides for Node.js via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ที่มีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิจำต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับต้นฉบับ

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกของมัน มันอ่านเวิร์กบุ๊กที่ฝังไว้เป็นอาเรย์ไบต์, ล้างซีรีส์และหมวดหมู่ที่มีอยู่, แล้วเขียนเวิร์กบุ๊กเดียวกันกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบการจัดวางแผนภูมิหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อคุณแทนที่เวิร์กบุ๊กที่ฝังด้วยเวิร์กบุ๊กที่แก้ไขแล้ว แผนภูมิจะยังคงมีซีรีส์และคอลเลกชันหมวดหมู่ดั้งเดิม ความไม่ตรงกันนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/#validateChartLayout) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ล้างซีรีส์และหมวดหมู่ที่มีอยู่ก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ต้องการ `chart.pptx` ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกของมัน ความคิดเห็นระบุจุดที่การแก้ไขเวิร์กบุ๊กจะเกิดขึ้น; ตัวอย่างที่สามารถเรียกใช้ได้เขียนเวิร์กบุ๊กดั้งเดิมกลับและตรวจสอบการจัดวางในหน่วยความจำ

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

        // แก้ไขบิตของเวิร์กบุ๊กที่นี่, ตัวอย่างเช่นโดยใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ สร้างซีรีส์และการแมปหมวดหมู่ที่จำเป็นสำหรับเวิร์กบุ๊กที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลของแผนภูมิได้ ขั้นตอนต่อไปนี้แสดงวิธีเชื่อมโยงป้ายในแผนภูมิบับเบิลกับเซลล์ในเวิร์กบุ๊กข้อมูลของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มที่ศูนย์.
3. เพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น.
4. เข้าถึงซีรีส์ของแผนภูมิ.
5. ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูล.
6. บันทึกงานนำเสนอ.

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์และเพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น ใช้เซลล์ A10:A12 บนเวิร์กชีต 0 สำหรับสามป้ายแรกในซีรีส์แรก เปิดใช้งานป้ายจากเซลล์ และบันทึกผลลัพธ์เป็น `resultchart.pptx`

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

## **จัดการเวิร์กชีต**

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdataworkbook/#getWorksheets) ให้การเข้าถึงเวิร์กชีตในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อเวิร์กชีตแต่ละอันไปที่คอนโซล

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3D ด้วยข้อมูลเริ่มต้นและตั้งชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิเทอรัล; ชื่อที่สองใช้เซลล์ C1 บนเวิร์กชีต 0. การนับประเภท [DataSourceType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/datasourcetype/) เลือกแหล่งสำหรับแต่ละชื่อ ผลลัพธ์จะบันทึกเป็น `pres.pptx`

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังซึ่งไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊กไบนารีของ Excel (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/) พร้อมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมิที่เกี่ยวข้อง ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของ `sample.pptx`, ข้ามรูปทรงที่ไม่ใช่แผนภูมิ, และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กแผนภูมิที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) เพื่อส่งออกเวิร์กบุ๊กแผนภูมิที่ฝังเป็นไฟล์และเชื่อมโยงแผนภูมิกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้น, เขียนเวิร์กบุ๊กของมันไปยัง `externalWorkbook1.xlsx`, และทำการเขียนไฟล์ให้เสร็จก่อนกำหนดไฟล์เป็นแหล่งข้อมูลแผนภูมิ มันบันทึกงานนำเสนอที่เชื่อมโยงเป็น `externalWorkbook.pptx`

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

### **กำหนดเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook), คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตพาธไปยังเวิร์กบุ๊กภายนอก (หากไฟล์นั้นถูกย้ายไป)

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่เก็บไว้ในตำแหน่งหรือทรัพยากรระยะไกลได้ คุณก็ยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้พาธสัมพันธ์ของเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ

ตัวอย่างนี้ต้องมี `externalWorkbook.xlsx` ในไดเรกทอรีทำงาน เวิร์กชีตชื่อ `Sheet1` ต้องมีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมีพาย, เชื่อมโยงเวิร์กบุ๊ก, และใช้ [setRange](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#setRange) เพื่อแมป A1:B4 เป็นหนึ่งซีรีส์และสามหมวด มันบันทึกผลลัพธ์เป็น `Presentation_with_externalWorkbook.pptx`

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#setExternalWorkbook) ควบคุมว่ามีการโหลดเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะพาธของเวิร์กบุ๊กเท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะถูกอัปเดตจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อมตั้งค่า `updateChartData` เป็น `false` มันคงข้อมูลเริ่มต้นของแผนภูมีพายและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่มีอยู่

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

### **รับพาธของเวิร์กบุ๊กแหล่งข้อมูลภายนอกจากแผนภูมิ**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมโยงกับแผนภูมิ ให้ตรวจสอบก่อนว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่ หากใช้ คุณสามารถดึงพาธของเวิร์กบุ๊กได้โดยทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) .
2. เขาถึงสไลด์แรกโดยใช้ดัชนีเริ่มที่ศูนย์.
3. ตรวจสอบว่ารูปทรงแรกเป็นแผนภูมิ.
4. อ่านประเภทแหล่งข้อมูลของแผนภูมิ.
5. ถ้าแหล่งเป็นเวิร์กบุ๊กภายนอก ให้อ่านพาธของมัน.

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างจากตัวอย่างก่อนหน้าและตรวจสอบรูปทรงแรกบนสไลด์แรก หากมันเป็นแผนภูมิที่เชื่อมโยงกับเวิร์กบุ๊กภายนอก ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) ไปที่คอนโซล แล้วบันทึกสำเนาของงานนำเสนอเป็น `Result.pptx`

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

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของเวิร์กบุ๊กภายใน หากเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ต้องการ `presentation.pptx` ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเวิร์กบุ๊กภายนอกที่เข้าถึงได้ มันตั้งค่าค่าที่อิงจากเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอเป็น `presentation_out.pptx` การแก้ไขค่าของเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นควรใช้สำเนาหากต้องการเก็บเวิร์กบุ๊กต้นฉบับไว้

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

### **กู้คืนเวิร์กบุ๊กจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊กของแผนภูมิใหม่จากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions), และตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง JavaScript ต่อไปนี้เปิด `presentation.pptx` ซึ่งรูปทรงแรกบนสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิงเวิร์กบุ๊กภายนอกที่ไม่พร้อมใช้งาน และเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนที่นี่.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หากเวิร์กบุ๊กภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับเวิร์กบุ๊กภายนอกจากครั้งที่อัปเดตงานนำเสนอครั้งล่าสุด

## **FAQ**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังอยู่?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getDataSourceType) และ [path to an external workbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากแหล่งเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านพาธเต็มเพื่อให้แน่ใจว่ามีไฟล์ภายนอกถูกใช้

**รองรับพาธสัมพันธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่และจัดเก็บอย่างไร?**

ได้. หากคุณระบุพาธสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ งานนำเสนอจะเก็บพาธเต็มในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – พวกมันสามารถใช้เป็นแหล่งเท่านั้น

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getExternalWorkbookPath) การแก้ไขข้อมูลแผนภูมิที่อิงจากเซลล์สามารถอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยงได้ ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

**ฉันควรทำอย่างไรถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีที่พบบ่อยคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนไปยังแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล