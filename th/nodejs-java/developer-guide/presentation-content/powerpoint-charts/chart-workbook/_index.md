---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/nodejs-java/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานของแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน ใช้เซลล์ของสมุดงานเป็นป้ายกำกับข้อมูลของแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และกำหนดประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีการสร้างและกำหนดสมุดงานภายนอก การดึงพาธของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และการแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์ที่แทนค่าขาดหาย ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับศูนย์และเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนไว้**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setplotvisiblecellsonly/) เพื่อควบคุมว่าหนึ่งแผนภูมิจะพลอตข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่หรือไม่ ตั้งค่าเป็น `true` เพื่อพลอตเฉพาะเซลล์ที่แสดงผล หรือ `false` เพื่อรวมทั้งเซลล์ที่แสดงและซ่อน การตั้งค่านี้ควบคุมการพลอตของแผนภูมิ; มันไม่ได้ซ่อนหรือเปิดแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ไฟล์ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปแรกบนสไลด์แรกของไฟล์ แผ่นงานที่ฝังมา `Sheet1` มีช่วงแหล่งข้อมูล `A1:C4` โดยแถว 3 และคอลัมน์ C ถูกซ่อนไว้ แต่ค่าในเซลล์ยังคงอยู่

| แถวของแผ่นงาน | A: เดือน | B: ขายปลีก | C: ขายส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/ishidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะโดยไม่ทำการเปลี่ยนแปลง ในไฟล์นี้ B2 แสดง, B3 อยู่ในแถวที่ซ่อน, C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพลอต: คงสมุดงานที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อกู้คืนช่วงเต็มรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายกำกับหมวดที่แคชไว้ ตัวอย่างแปลงบัฟเฟอร์ Node.js เป็นอาเรย์ไบต์ของ Java ก่อนส่งให้เมธดด์เขียน

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

            // รีเฟรชข้อมูลแผนภูมิจากสมุดงานที่ฝังอยู่.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // กู้คืนช่วงแหล่งข้อมูลครบถ้วน รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: เวอร์ชันหนึ่งมีเฉ่ือค่าขายปลีกที่แสดง (`10` และ `20`) และอีกเวอร์ชันมีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพลอต แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานที่ฝังทั้งสองเวอร์ชัน

| เฉพาะเซลล์ที่แสดง (`true`) | ทั้งหมด (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนพร้อมค่าต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setdisplayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลสมุดงานในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่าแผ่นงานใดที่แต่ละแผนภูมิใช้ วิธี [ChartData.getRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getrange/) จะคืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่ระบุแผ่นงาน เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อแผ่นงาน, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 อย่างรวมทั้งสองด้าน เครื่องหมายดอลลาร์บ่งบอกอ้างอิงแถวและคอลัมน์แบบสัมบูรณ์

เมธดด์นี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือสมุดงาน หากแผนภูมิไม่ได้ใช้สมุดงานเป็นแหล่งข้อมูล จะเกิด `InvalidOperationException` ดูรายละเอียดเพิ่มเติมที่ [ChartData API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดการนำเสนอและตรวจสอบรูปทรงบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อของแต่ละแผนภูมิและช่วงแหล่งข้อมูล หากแผนภูมิไม่ใช้สมุดงานจะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for Node.js via Java มีเมธดด์ [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) และ [writeWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิเป็นรูปแรกบนสไลด์แรก อ่านสมุดงานที่ฝังเป็นอาเรย์ไบต์ ลบชุดข้อมูลและหมวดเดิมออก แล้วเขียนสมุดงานเดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกการนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะยังคงมีชุดข้อมูลและคอลเลกชันหมวดเดิม ซึ่งอาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index‑out‑of‑range ให้ล้างชุดข้อมูลและหมวดเดิมก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่ควรแก้ไขสมุดงาน; ตัวอย่างทำการเขียนสมุดงานเดิมกลับและตรวจสอบโครงสร้างในหน่วยความจำ

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

        // แก้ไขไบต์ของสมุดงานที่นี่, ตัวอย่างเช่น, ใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะทำให้การอ้างอิงข้อมูลที่ล้าสมัยหายไปก่อนที่สมุดงานจะถูกเขียนกลับ สร้างการจับคู่ชุดข้อมูลและหมวดใหม่ตามสมุดงานที่อัปเดตก่อนใช้งานแผนภูมิ

## **เลือกรูปแบบการจัดเก็บป้ายกำกับหมวด**

เรียกใช้ [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategorycollection/setusecells/) บนคอลเลกชันหมวดที่ว่างก่อนเพิ่มป้ายกำกับ ใช้เซลล์ของแผ่นงานสำหรับป้ายกำกับที่อ้างอิงข้อมูลสมุดงานหรือสร้างโครงสร้างลำดับขั้น เช่น ไตรมาสที่จัดกลุ่มตามปี ใช้สตริงลิเทรัลสำหรับป้ายกำกับระดับเดียวที่ไม่ต้องอ้างอิงเซลล์ การตั้งค่านี้ใช้กับหมวดเท่านั้น ทั้งสองแผนภูมิในตัวอย่างใช้เซลล์ของแผ่นงานสำหรับค่าชุดข้อมูลเชิงตัวเลข

ตัวอย่างสร้างแผนภูมิคอลัมน์สองชิ้นและพิมพ์โหมดการจัดเก็บตามด้วย `Q1 Q2 Q3 Q4` สำหรับแต่ละอัน สำหรับป้ายกำกับที่อ้างอิงแผ่นงาน [ChartCategory.getAsCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getascell/) คืนค่าเซลล์พื้นฐานและ [ChartDataCell.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getvalue/) คืนป้ายกำกับ สำหรับป้ายกำกับลิเทรัลให้ใช้ [ChartCategory.getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartcategory/getvalue/) ตัวอย่างบันทึกทั้งสองแผนภูมิใน `category-labels.pptx`

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    for (const useCells of [true, false]) {
        const x = useCells ? 20 : 360;
        const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, x, 20, 320, 250);
        const data = chart.getChartData();
        data.getSeries().clear();
        const categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        const workbook = data.getChartDataWorkbook();
        const seriesName = workbook.getCell(0, 0, 1, "Sales");
        const series = data.getSeries().add(seriesName, chart.getType());
        for (let row = 1; row <= 4; row++) {
            const label = "Q" + row;
            if (useCells) {
                const labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            const valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        const storedInCells = categories.getUseCells();
        const labels = [];
        for (let i = 0; i < categories.size(); i++) {
            const category = categories.get_Item(i);
            labels.push(storedInCells ? category.getAsCell().getValue() : category.getValue());
        }
        console.log("UseCells = " + storedInCells + ": " + labels.join(" "));
    }

    presentation.save("category-labels.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่ารูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์สมุดงาน**

ใช้ [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/setcustomnumberformat/) เพื่อควบคุมรูปแบบการแสดงค่าตัวเลขในสมุดงานที่ฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราแปลงเป็นเปอร์เซ็นต์ 4 ตำแหน่งทศนิยมและค่าสัมประสิทธิ์เป็น 5 ตำแหน่งทศนิยม ให้ค่าทั้งสองเก็บเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและพลอตแผนภูมิได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่เก็บไว้ รูปแบบ `0.0000%` จะแสดง `0.125` เป็น `12.5000%` แต่ไม่เปลี่ยนค่าที่เก็บเป็น `12.5` เช่นเดียวกัน `0.00000` จะแสดง `0.1234567` เป็น `0.12346` โดยไม่ทำการปัดเศษค่าที่เก็บไว้ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้รูปแบบที่คืนจาก [getPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/getpresetnumberformat/) แทน

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/) บนแผ่นงาน 0 เซลล์ B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นแหล่งค่าของแผนภูมิ ตัวอย่างยังเปิดใช้ป้ายค่าที่เชื่อมโยงกับรูปแบบแหล่ง

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

รูปแบบเซลล์ของสมุดงานแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายแสดงค่าที่มาจากเซลล์ต้นฉบับเนื่องจาก [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setshowvalue/) ถูกตั้งเป็น `true` และทำตามรูปแบบตัวเลขของแหล่งข้อมูลเพราะ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformatlinkedtosource/) ตั้งเป็น `true` หลังจากบันทึกและเปิดการนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้รูปแบบตัวเลขของตนเองที่กำหนดด้วย [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformat/) เป็น `0.00` พร้อมกับ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/setnumberformatlinkedtosource/) ตั้งเป็น `false`

หากต้องการจัดรูปแบบป้ายข้อมูลอย่างอิสระ ให้ตั้งค่าสถานะการเชื่อมโยงแหล่งเป็น `false` แล้วกำหนดรูปแบบด้วย [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/setnumberformat/) วิธีนี้ไม่ทำให้รูปแบบของเซลล์สมุดงานเปลี่ยนไป ตัวอย่างเช่น การตั้งรูปแบบป้ายเป็น `0.00` จะทำให้ค่าแรกแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/nodejs-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการจัดรูปแบบป้ายโดยตรง

ภาพต่อไปนี้สร้างจากการนำเสนอที่บันทึกแล้วและเปิดใหม่อีกครั้ง:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับ (bubble) ที่มีข้อมูลเริ่มต้นไปยังสไลด์แรกของการนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายสามอันแรกของชุดข้อมูลแรก เปิดใช้งานป้ายจากเซลล์ และบันทึกการนำเสนอที่อัปเดต

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

## **จัดการแผ่นงาน**

เมธดด์ [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdataworkbook/getworksheets/) ให้เข้าถึงแผ่นงานในสมุดงานของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิเพิ่ม (pie) ที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อของแต่ละแผ่นงานไปยังคอนโซล

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

## **กำหนดประเภทแหล่งข้อมูล**

ค่าจุดของชุดข้อมูลยังสามารถจัดเก็บเป็นลิเทรัลตัวเลขได้ ดูที่ [Set Series Values Using Numeric Literals](/slides/th/nodejs-java/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างครบถ้วนที่บันทึกและอ่านค่าเหล่านี้ ประเภทแหล่งข้อมูลของค่าจุดแยกจากการกำหนดค่าสมุดงานภายในหรือภายนอกของแผนภูมิ; การใช้ลิเทรัลตัวเลขไม่ได้ลบสมุดงานที่ฝังอยู่โดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลเริ่มต้นและกำหนดชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้ลิเทรัลสตริง; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 ตัวเลือก [DataSourceType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datasourcetype/) จะระบุแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกการนำเสนอพร้อมชื่อชุดข้อมูลที่อัปเดต

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังซึ่งไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธดด์ `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของการนำเสนอที่มีอยู่ ข้ามรูปทรงที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่

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

        // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/readworkbookstream/) และ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) เพื่อส่งออกสมุดงานแผนภูมิที่ฝังเป็นไฟล์แล้วเชื่อมโยงแผนภูมิไปยังสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเพิ่ม (pie) ที่มีข้อมูลเริ่มต้นและส่งออกสมุดงานของมัน ทำการเขียนไฟล์ให้เสร็จก่อนกำหนดสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกการนำเสนอที่เชื่อมโยง

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

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธดด์ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธดด์นี้ยังใช้เพื่ออัปเดตพาธของสมุดงานภายนอก (หากสมุดงานนั้นถูกย้าย)

แม้คุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งระยะไกลหรือเป็นทรัพยากรได้ แต่คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอก หากระบุพาธสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้สมุดงานภายนอกที่มีแผ่นงานชื่อ `Sheet1` ซึ่งมีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4 และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเพิ่ม, เชื่อมโยงสมุดงาน, และใช้ [setRange](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setrange/) เพื่อแมป A1:B4 ให้เป็นชุดข้อมูลหนึ่งและหมวดสามรายการ บันทึกการนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/setexternalworkbook/) ควบคุมว่าจะโหลดสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะพาธของสมุดงาน แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่มีอยู่ได้
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปนี้กำหนด URL ตัวแทนพร้อม `updateChartData` เป็น `false` คงข้อมูลเริ่มต้นของแผนภูมิเพิ่มและบันทึกการนำเสนอโดยไม่โหลดสมุดงานที่ไม่มีอยู่

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

### **รับพาธของสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุสมุดงานที่เชื่อมโยงกับแผนภูมิ ให้ตรวจสอบว่าแผนภูมิเชื่อมโยงกับแหล่งข้อมูลภายนอกหรือไม่และดึงพาธของสมุดงานนั้น

ตัวอย่างนี้ตรวจสอบรูปแรกบนสไลด์แรกของการนำเสนอที่มีสมุดงานภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมโยงกับสมุดงานภายนอก ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ไปยังคอนโซล แล้วบันทึกสำเนาการนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลในสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปแรกบนสไลด์แรกและเชื่อมโยงกับสมุดงานภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อิงเซลล์ของจุดข้อมูลแรกในชุดแรกเป็น 100 แล้วบันทึกการนำเสนอที่อัปเดต การแก้ไขค่าที่อิงเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นควรใช้สำเนาหากต้องการเก็บสมุดงานต้นฉบับไว้

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชอยู่ในไฟล์การนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) แล้วเรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/setspreadsheetoptions/) จากนั้นตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/spreadsheetoptions/setrecoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง JavaScript ด้านล่างกู้คืนข้อมูลสมุดงานสำหรับแผนภูมิที่เป็นรูปแรกบนสไลด์แรกและอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งาน ตัวอย่างเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getchartdata/) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getchartdataworkbook/):

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

        // อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนได้ที่นี่.
    } else {
        console.log("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด Aspose.Slides จะโยงข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นการแก้ไขที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากการอัปเดตครั้งล่าสุดของการนำเสนอ

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิกับสมุดงานที่เชื่อมโยงเป็นแบบภายในหรือภายนอก?**

ได้ แอปพลิเคชันแผนภูมิจะมี [data source type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านพาธเต็มเพื่อยืนยันว่ามีไฟล์ภายนอกถูกใช้

**รองรับพาธสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่ และจัดเก็บอย่างไร?**

รองรับ หากระบุพาธสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธสมบูรณ์อัตโนมัติ การนำเสนอจะเก็บพาธสมบูรณ์ในไฟล์ PPTX ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้ สมุดงานเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

การนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) การแก้ไขค่าที่อิงเซลล์ในแผนภูมิอาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยง ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน ฉันควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ มีแนวทางทั่วไปคือถอดการป้องกันไว้ล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัส (เช่น ด้วย [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียว การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิเมื่อต่อไปโหลดข้อมูล**