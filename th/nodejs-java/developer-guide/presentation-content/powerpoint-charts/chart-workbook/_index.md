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
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิโดยใช้สตรีมของสมุดงาน ใช้เซลล์ในสมุดงานเป็นป้ายกำกับข้อมูลของแผนภูมิ เข้าถึงคอลเลกชันของ Worksheet และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างสาธิตวิธีการสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides ให้บริการเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) ที่อนุญาตให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งอาจมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิจะต้องถูกจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายคลึงกับแหล่งข้อมูล

โค้ด JavaScript นี้แสดงการดำเนินการตัวอย่าง:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ตรวจสอบการจัดวางแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อนำสมุดงานฝังที่แก้ไขแล้วแทนที่สมุดงานเดิม แผนภูมิจะยังคงรักษาคอลเลกชันซีรีส์และหมวดหมู่เดิมไว้ ความไม่ตรงกันนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้เคลียร์ซีรีส์และหมวดหมู่ที่มีอยู่ก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ

```javascript
// หลังจากแก้ไขสตรีมของสมุดงาน (เช่น ใช้ Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

การเคลียร์คอลเลกชันจะทำให้โครงสร้างข้อมูลแผนภูมิตรงกับสมุดงานใหม่ ทำให้ `validateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์ใน WorkBook เป็น DataLabel ของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
2. ดึงอ้างอิงของสไลด์โดยใช้ดัชนี
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
4. เข้าถึงซีรีส์ของแผนภูมิ
5. ตั้งค่าเซลล์ในสมุดงานให้เป็นป้ายกำกับข้อมูล
6. บันทึกไฟล์พรีเซนเทชัน

โค้ด JavaScript นี้แสดงวิธีการตั้งค่าเซลล์ในสมุดงานเป็นป้ายกำกับข้อมูลของแผนภูมิ:

```javascript
// สร้างอินสแตนซ์ของคลาสพรีเซนเทชันที่แทนไฟล์พรีเซนเทชัน
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **จัดการ Worksheet**

โค้ด JavaScript นี้สาธิตการดำเนินการที่ใช้เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของ Worksheet:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ระบุประเภทแหล่งข้อมูล**

โค้ด JavaScript นี้แสดงวิธีการระบุประเภทสำหรับแหล่งข้อมูล:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตรวจจับรูปแบบ Workbook ฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ซึ่งอาจถูกฝังในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // สมุดงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook ภายนอก**

Aspose.Slides รองรับสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้าง External Workbook**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกตั้งแต่ต้นหรือทำให้สมุดงานภายในเป็นภายนอกได้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream คืนค่าไบต์ของสมุดงานเป็น Buffer ของ Node.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **ตั้งค่า External Workbook**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางของสมุดงานภายนอก (หากมีการย้ายตำแหน่ง)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งหรือทรัพยากรระยะไกลได้ คุณก็ยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางเชิงสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มอัตโนมัติ

โค้ด JavaScript นี้แสดงวิธีการตั้งค่า External Workbook:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

พารามิเตอร์ที่สองของเมธอด `setExternalWorkbook` คือ `updateChartData` ซึ่งระบุว่าจะโหลดสมุดงาน Excel หรือไม่

* เมื่อ `updateChartData` ตั้งค่าเป็น `false` จะอัปเดตเพียงเส้นทางของสมุดงานเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีอยู่หรือไม่พร้อมใช้งาน
* เมื่อ `updateChartData` ตั้งค่าเป็น `true` ข้อมูลแผนภูมิจะถูกอัปเดตจากสมุดงานเป้าหมาย

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **รับเส้นทาง Workbook แหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
2. ดึงอ้างอิงของสไลด์โดยใช้ดัชนี
3. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ
4. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่เป็นตัวแทนของแหล่งข้อมูลของแผนภูมิ
5. ระบุเงื่อนไขที่เกี่ยวข้องตามประเภทแหล่งข้อมูลที่ตรงกับประเภทของสมุดงานภายนอก

โค้ด JavaScript นี้สาธิตการดำเนินการ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // บันทึกพรีเซนเทชัน
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของสมุดงานภายใน เมื่อไม่สามารถโหลดสมุดงานภายนอกได้ จะเกิดข้อยกเว้นขึ้น

โค้ด JavaScript นี้เป็นการนำไปใช้ตามที่อธิบาย:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิใหม่จากข้อมูลที่แคชไว้ในพรีเซนเทชันได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/), ตั้งค่าด้วย [SpreadsheetOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/), แล้วเรียก [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ด้วยค่า `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง JavaScript ต่อไปนี้เปิดพรีเซนเทชันที่แผนภูมิเชื่อมโยงกับสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
} finally {
    presentation.dispose();
}
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้น ให้เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชไว้เป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากพรีเซนเทชันอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดได้หรือไม่ว่าตารางแผนภูมิเฉพาะเชื่อมโยงกับ Workbook ภายนอกหรือที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) หากเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกหรือไม่

**รองรับเส้นทางเชิงสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่ และจะถูกจัดเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางเชิงสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ อย่างไรก็ตาม พรีเซนเทชันจะจัดเก็บเส้นทางเต็มไว้ในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนเครือข่ายหรือแชร์ได้หรือไม่?**

ได้ สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**

ไม่ พรีเซนเทชันจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกจะไม่ถูกแก้ไขเมื่อบันทึกพรีเซนเทชัน

**ถ้าไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน ควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำลิงก์ วิธีที่พบบ่อยคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/nodejs-java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียว การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล