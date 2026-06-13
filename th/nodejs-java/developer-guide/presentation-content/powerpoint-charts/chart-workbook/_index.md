---
title: จัดการสมุดทำงานแผนภูมิในงานนำเสนอด้วย JavaScript
linktitle: สมุดทำงานแผนภูมิ
type: docs
weight: 70
url: /th/nodejs-java/chart-workbook/
keywords:
- สมุดทำงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดทำงาน
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดทำงานภายนอก
- ข้อมูลภายนอก
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการสมุดทำงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดทำงานของแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดทำงาน, ใช้เซลล์ของสมุดทำงานเป็นป้ายข้อมูลของแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับสมุดทำงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีการสร้างและกำหนดสมุดทำงานภายนอก, ดึงเส้นทางของสมุดทำงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดทำงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดทำงาน**

Aspose.Slides มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) ที่อนุญาตให้คุณอ่านและเขียนสมุดทำงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดระเบียบในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

โค้ด JavaScript นี้แสดงการดำเนินการตัวอย่าง:

```javascript
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

## **ตั้งค่าเซลล์ WorkBook เป็น DataLabel ของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) .
1. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน.
1. เพิ่มแผนภูมิ Bubble chart กับข้อมูลบางส่วน.
1. เข้าถึงชุดข้อมูลของแผนภูมิ.
1. ตั้งค่าเซลล์ของสมุดทำงานเป็นป้ายข้อมูล.
1. บันทึกการนำเสนอ.

โค้ด JavaScript นี้แสดงวิธีการตั้งค่าเซลล์สมุดทำงานเป็นป้ายข้อมูลของแผนภูมิ:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์การนำเสนอ
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

## **จัดการ Worksheets**

โค้ด JavaScript นี้แสดงการดำเนินการที่ใช้เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของ worksheet:

```javascript
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

## **ระบุประเภทของแหล่งข้อมูล**

โค้ด JavaScript นี้แสดงวิธีการระบุประเภทสำหรับแหล่งข้อมูล:

```javascript
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

## **ตรวจจับรูปแบบ Workbook ที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ Excel binary workbook (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```js
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
            // สมุดทำงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดทำงานของแผนภูมิเพิ่มเติมที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **สมุดทำงานภายนอก**

Aspose.Slides รองรับสมุดทำงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดทำงานภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดทำงานภายนอกตั้งแต่ต้นหรือทำให้สมุดทำงานภายในเป็นภายนอกได้

โค้ด JavaScript นี้แสดงกระบวนการสร้างสมุดทำงานภายนอก:

```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **กำหนดสมุดทำงานภายนอก**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดทำงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังสมุดทำงานภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดทำงานที่เก็บไว้ในตำแหน่งระยะไกลหรือทรัพยากรต่างๆ ได้ แต่คุณยังสามารถใช้สมุดทำงานดังกล่าวเป็นแหล่งข้อมูลภายนอกได้ หากกำหนดเส้นทางสัมพันธ์สำหรับสมุดทำงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด JavaScript นี้แสดงวิธีการกำหนดสมุดทำงานภายนอก:

```javascript
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

`ChartData` parameter (ใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดสมุดทำงาน Excel หรือไม่

* เมื่อค่ของ `ChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดทำงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดทำงานเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อสมุดทำงานเป้าหมายไม่มีหรือไม่สามารถเข้าถึงได้
* เมื่อค่ของ `ChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะได้รับการอัปเดตจากสมุดทำงานเป้าหมาย

```javascript
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) .
1. รับการอ้างอิงของสไลด์ผ่านดัชนีของมัน.
1. สร้างอ็อบเจกต์สำหรับรูปทรงแผนภูมิ.
1. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่เป็นตัวแทนของแหล่งข้อมูลของแผนภูมิ.
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทของแหล่งข้อมูลที่ตรงกับประเภทแหล่งข้อมูลสมุดทำงานภายนอก.

โค้ด JavaScript นี้แสดงการดำเนินการ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // บันทึกการนำเสนอ
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดทำงานภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาของสมุดทำงานภายใน เมื่อไม่สามารถโหลดสมุดทำงานภายนอกได้ จะเกิดข้อยกเว้นขึ้น

โค้ด JavaScript นี้เป็นการทำตามกระบวนการที่อธิบายไว้:

```javascript
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

## **คำถามที่พบบ่อย**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิใด ๆ เชื่อมโยงกับสมุดทำงานภายนอกหรือสมุดทำงานที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) ; หากแหล่งเป็นสมุดทำงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอก

**สนับสนุนเส้นทางสัมพันธ์ไปยังสมุดทำงานภายนอกหรือไม่ และเก็บไว้อย่างไร?**

ใช่ หากคุณระบุเส้นทางสัมพันธ์，它จะถูกแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ สิ่งนี้สะดวกต่อการพกพาโครงการ; อย่างไรก็ตาม โปรดทราบว่าการนำเสนอจะเก็บเส้นทางเต็มไว้ในไฟล์ PPTX

**ฉันสามารถใช้สมุดทำงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้ สมุดทำงานเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดทำงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

ไม่ การนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) และใช้เพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกการนำเสนอ

**ฉันควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือการลบการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่นโดยใช้ [Aspose.Cells](/cells/nodejs-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดทำงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล