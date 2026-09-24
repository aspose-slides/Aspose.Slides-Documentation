---
title: จัดการ Chart Workbook ในงานนำเสนอด้วย JavaScript
linktitle: Chart Workbook
type: docs
weight: 70
url: /th/nodejs-java/chart-workbook/
keywords:
- workbook แผนภูมิ
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
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน JavaScript: จัดการ workbook ของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ workbook ของแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของ workbook ใช้เซลล์ workbook เป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลlection ของแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนด workbook ภายนอก ดึงเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อ workbook พร้อมใช้งาน

สำหรับเซลล์ workbook ที่เป็นข้อมูลหายไป ดูที่ [ควบคุมการแสดงของเซลล์ว่าง](/slides/th/nodejs-java/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างและศูนย์ และการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงที่มีอยู่

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) ที่ให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

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

### **ตรวจสอบเค้าโครงแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังอยู่ด้วยเวอร์ชันที่แก้ไขแล้ว แผนภูมิจะยังคงคอลlection ของ series และ category ดั้งเดิม ความไม่ตรงกันนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Chart#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ล้าง series และ category ที่มีอยู่ก่อนเขียน workbook ที่อัปเดตกลับไปยังแผนภูมิ

```javascript
// หลังจากแก้ไขสตรีมของ workbook (เช่น ใช้ Aspose.Cells)
var updatedWorkbook = chartData.readWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

การล้างคอลlection จะทำให้โครงสร้างข้อมูลแผนภูมิตรงกับ workbook ใหม่ ทำให้ `validateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่า Cell ของ WorkBook เป็น DataLabel ของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลบางส่วน
4. เข้าถึง series ของแผนภูมิ
5. ตั้งค่า cell ของ workbook เป็นป้ายกำกับข้อมูล
6. บันทึกการนำเสนอ

โค้ด JavaScript นี้แสดงวิธีตั้งค่า cell ของ workbook เป็นป้ายกำกับข้อมูลของแผนภูมิ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ
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

## **จัดการแผ่นงาน**

โค้ด JavaScript นี้แสดงการทำงานที่ใช้เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลlection ของแผ่นงาน:

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

โค้ด JavaScript นี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบ Workbook ที่ฝังไว้ซึ่งไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ workbook แบบไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/workbooktype/) เพื่อระบุรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

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
            // Workbook ที่ฝังอยู่ในรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิเบื้องนี้.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook ภายนอก**

Aspose.Slides รองรับ workbook ภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้าง Workbook ภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้าง workbook ภายนอกจากศูนย์หรือทำให้ workbook ภายในเป็นแบบภายนอกได้

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream คืนค่าไบต์ของ workbook เป็น Buffer ของ Node.
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

### **กำหนด Workbook ภายนอก**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากไฟล์นั้นถูกย้ายไปที่อื่น) ด้วย

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลใน workbook ที่จัดเก็บในตำแหน่งหรือทรัพยากรระยะไกลได้ แต่คุณยังคงสามารถใช้ workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้เส้นทางสัมพันธ์สำหรับ workbook ภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

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

พารามิเตอร์ที่สองของเมธอด `setExternalWorkbook` คือ `updateChartData` ระบุว่า workbook ของ Excel จะถูกโหลดหรือไม่

* เมื่อกำหนด `updateChartData` เป็น `false` ระบบจะอัปเดตเฉพาะเส้นทางของ workbook เท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook เป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อตัว workbook เป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
* เมื่อตั้งค่า `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะถูกอัปเดตจาก workbook เป้าหมาย

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

### **รับเส้นทาง Workbook ของแหล่งข้อมูลแผนภูมิภายนอก**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
3. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ
4. สร้างอ็อบเจกต์สำหรับแหล่ง (`ChartDataSourceType`) ที่เป็นประเภทของแหล่งข้อมูลแผนภูมิ
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอ้างอิงจากประเภทแหล่งที่เหมือนกับประเภทแหล่งข้อมูลของ workbook ภายนอก

โค้ด JavaScript นี้แสดงการทำงาน:

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
    // บันทึกงานนำเสนอ
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของ workbook ภายใน เมื่อไม่สามารถโหลด workbook ภายนอกได้ จะเกิดข้อยกเว้น

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

หากแผนภูมิใช้ workbook ภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างใหม่ workbook ของแผนภูมิจากข้อมูลที่แคชไว้ในงานนำเสนอได้ ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/), ตั้งค่าโดยใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/), แล้วเรียก [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ด้วยค่า `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง JavaScript ด้านล่างเปิดงานนำเสนอที่แผนภูมิเชื่อมโยงกับ workbook ภายนอกที่ไม่สามารถใช้ได้และเข้าถึงข้อมูลที่กู้คืนผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

    // อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
} finally {
    presentation.dispose();
}
```

หาก workbook ภายนอกไม่สามารถใช้ได้และการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น ควรเปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับ workbook ภายนอกหลังจากงานนำเสนอถูกอัปเดตล่าสุด

## **FAQ**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับ workbook ภายนอกหรือที่ฝังไว้?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) หากแหล่งเป็น workbook ภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยัง workbook ภายน้อหรือไม่ และมันถูกจัดเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ สิ่งนี้สะดวกสำหรับความพกพาของโครงการ; อย่างไรก็ตาม โปรดทราบว่าการนำเสนอจะบันทึกเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้ workbook ที่อยู่บนเครือข่ายหรือแชร์ไฟล์ได้หรือไม่?**

ได้ workbook เช่นนั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ แต่การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

ไม่ งานนำเสนอจะบันทึก [link to the external file](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) และใช้ในการอ่านข้อมูล ไฟล์ภายนอกเองไม่ถูกแก็ไขเมื่อบันทึกงานนำเสนอ

**ฉันควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือการลบการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/nodejs-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนให้กับแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล