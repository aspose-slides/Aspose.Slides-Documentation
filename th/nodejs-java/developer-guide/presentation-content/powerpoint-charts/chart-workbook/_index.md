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
- ป้ายข้อมูล
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
description: "ค้นพบ Aspose.Slides สำหรับ Node.js ผ่าน Java: จัดการ workbook ของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพการจัดการข้อมูลในงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับ workbook ของแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีม workbook, การใช้เซลล์ workbook เป็นป้ายข้อมูลแผนภูมิ, การเข้าถึงคอลเลกชันของ worksheet, และการระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ  

นอกจากนี้ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนด workbook ภายนอก, ดึงพาธของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook สามารถเข้าถึงได้  

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) ซึ่งช่วยให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดรูปแบบในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ  

โค้ด JavaScript ตัวอย่างต่อไปนี้แสดงการดำเนินการ:

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

## **กำหนดเซลล์ WorkBook เป็นป้ายข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)  
1. ดึงอ้างอิงของสไลด์ผ่านหมายเลขดัชนี  
1. เพิ่มแผนภูมิกระจุ (Bubble) พร้อมข้อมูลบางส่วน  
1. เข้าถึงซีรีส์ของแผนภูมิ  
1. ตั้งค่าเซลล์ workbook เป็นป้ายข้อมูล  
1. บันทึกงานนำเสนอ  

โค้ด JavaScript ด้านล่างแสดงวิธีการกำหนดเซลล์ workbook เป็นป้ายข้อมูลแผนภูมิ:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
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

โค้ด JavaScript ตัวอย่างนี้แสดงการใช้เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของ worksheet:

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

## **ระบุประเภทแหล่งข้อมูล**

โค้ด JavaScript นี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบ Workbook ที่ฝังไว้ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ workbook ของ Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในแผนภูมิบางรายการ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [ChartData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้นได้

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
            // Workbook ที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook ภายนอก**

Aspose.Slides รองรับ workbook ภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้าง Workbook ภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้าง workbook ภายนอกตั้งแต่ต้นหรือแปลง workbook ภายในให้เป็นภายนอกได้  

โค้ด JavaScript ตัวอย่างต่อไปนี้แสดงขั้นตอนการสร้าง workbook ภายนอก:

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

### **กำหนด Workbook ภายนอก**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตพาธของ workbook ภายนอก (กรณีที่มีการย้ายไฟล์)  

แม้ว่าจะไม่สามารถแก้ไขข้อมูลใน workbook ที่เก็บไว้ในตำแหน่งระยะไกลหรือทรัพยากรต่างๆ ได้ แต่คุณยังคงใช้ workbook ดังกล่าวเป็นแหล่งข้อมูลภายนอกได้ หากให้พาธสัมพันธ์ของ workbook ภายนอก ระบบจะทำการแปลงเป็นพาธเต็มโดยอัตโนมัติ  

โค้ด JavaScript ด้านล่างแสดงวิธีตั้งค่า workbook ภายนอก:

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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้ระบุว่า workbook ของ Excel จะต้องถูกโหลดหรือไม่  

* เมื่อค่าของ `ChartData` เป็น `false` จะอัปเดตเฉพาะพาธของ workbook — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook เป้าหมาย เหมาะกับกรณีที่ workbook ปลายทางไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
* เมื่อค่าของ `ChartData` เป็น `true` จะอัปเดตข้อมูลแผนภูมิจาก workbook ปลายทาง  

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

### **ดึงพาธ Workbook ของแหล่งข้อมูลแผนภูมิโดยภายนอก**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)  
1. ดึงอ้างอิงของสไลด์ผ่านหมายเลขดัชนี  
1. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ  
1. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แทนแหล่งข้อมูลของแผนภูมิ  
1. ระบุเงื่อนไขที่เกี่ยวข้องตามประเภทแหล่งข้อมูลที่ตรงกับประเภทของ workbook ภายนอก  

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
    // บันทึกงานนำเสนอ
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาใน workbook ภายใน หากไม่สามารถโหลด workbook ภายนอกได้ จะเกิดข้อยกเว้น  

โค้ด JavaScript ด้านล่างเป็นการนำไปใช้ตามที่อธิบาย:

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

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิใช้ workbook ภายนอกที่หายหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้าง workbook ของแผนภูมิใหม่จากข้อมูลที่เก็บไว้ในแคชของงานนำเสนอได้ โดยสร้าง [LoadOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/loadoptions/), ตั้งค่าให้ใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/), แล้วเรียกเมธอด [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ด้วยค่า `true` ก่อนเปิดงานนำเสนอ  

ตัวอย่าง JavaScript ด้านล่างเปิดงานนำเสนอที่แผนภูมิเชื่อมโยงกับ workbook ภายนอกที่ไม่สามารถเข้าถึงได้ และเข้าถึงข้อมูลที่กู้คืนผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook):

```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนได้ที่นี่.
} finally {
    presentation.dispose();
}
```

หาก workbook ภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้น ให้เปิดใช้งานการกู้คืนเฉพาะเมื่อต้องการใช้ข้อมูลแผนภูมิที่เก็บไว้ในแคชเป็นการสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำใน workbook ภายนอกหลังจากที่งานนำเสนอถูกอัปเดตครั้งล่าสุด  

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิบางรายการเชื่อมโยงกับ workbook ภายนอกหรือที่ฝังไว้?**  

ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) และ [พาธไปยัง workbook ภายนอก](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) หากเป็น workbook ภายนอก คุณสามารถอ่านพาธเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกหรือไม่  

**รองรับพาธสัมพันธ์ไปยัง workbook ภายนอกหรือไม่ และพวกมันถูกจัดเก็บอย่างไร?**  

ใช่ หากระบุพาธสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ; อย่างไรก็ตาม งานนำเสนอจะบันทึกพาธเต็มไว้ในไฟล์ PPTX  

**สามารถใช้ workbook ที่อยู่บนเครือข่ายหรือแชร์ไฟล์ได้หรือไม่?**  

ได้ workbook ที่อยู่บนทรัพยากรเครือข่ายสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น  

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**  

ไม่ งานนำเสนอจะบันทึก [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกงานนำเสนอ  

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่านควรทำอย่างไร?**  

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/nodejs-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น  

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**  

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล  