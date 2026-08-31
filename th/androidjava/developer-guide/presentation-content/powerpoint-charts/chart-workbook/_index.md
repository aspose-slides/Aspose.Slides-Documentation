---
title: จัดการเวิร์กชีทแผนภูมิในงานนำเสนอบน Android
linktitle: เวิร์กชีทแผนภูมิ
type: docs
weight: 70
url: /th/androidjava/chart-workbook/
keywords:
- เวิร์กชีทแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กชีท
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กชีทรายการภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กชีท
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Android ผ่าน Java: จัดการเวิร์กชีทแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับหนังสือเวิร์กชีทของแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิโดยใช้สตรีมของเวิร์กชีท ใช้เซลล์ของเวิร์กชีทเป็นป้ายข้อมูลของแผนภูมิ เข้าถึงคอลเลกชันของเวิร์กชีท และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กชีทรายการภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดเวิร์กชีทรายการภายนอก เรียกคืนเส้นทางของเวิร์กชีทรายการภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กชีทพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กชีท**
Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่ช่วยให้คุณอ่านและเขียนเวิร์กชีทของข้อมูลแผนภูมิ (ซึ่งประกอบด้วยข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งต้นทาง

โค้ด Java ตัวอย่างนี้แสดงการทำงานตัวอย่าง:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **ตรวจสอบรูปแบบแผนภูมิหลังการแก้ไขเวิร์กชีท**

เมื่อคุณแทนที่เวิร์กชีทที่ฝังอยู่ด้วยเวิร์กชีทที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดซีรีส์และประเภทของหมวดหมู่เดิมไว้ ความไม่ตรงกันนี้อาจทำให้เมธอด [IChart.validateChartLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ทำการล้างซีรีส์และประเภทที่มีอยู่ก่อนเขียนเวิร์กชีทที่อัปเดตกลับไปยังแผนภูมิ

```java
// หลังจากแก้ไขสตรีมของเวิร์กชีท (เช่น ใช้ Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

การล้างคอลเลกชันช่วยให้โครงสร้างข้อมูลแผนภูมิตรงกับเวิร์กชีทใหม่ ทำให้ `validateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **กำหนดเซลล์เวิร์กชีทเป็นป้ายข้อมูลของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
1. ดึงอ้างอิงของสไลด์ผ่านดัชนี
1. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
1. เข้าถึงซีรีส์ของแผนภูมิ
1. กำหนดเซลล์เวิร์กชีทเป็นป้ายข้อมูล
1. บันทึกพรีเซนเทชัน

โค้ด Java ตัวอย่างต่อไปนี้แสดงการกำหนดเซลล์เวิร์กชีทเป็นป้ายข้อมูลของแผนภูมิ:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์พรีเซนเทชัน
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการ Worksheet**

โค้ด Java ตัวอย่างนี้แสดงการทำงานที่ใช้เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของ Worksheet:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **ระบุประเภทของแหล่งข้อมูล**

โค้ด Java ตัวอย่างนี้แสดงวิธีระบุประเภทของแหล่งข้อมูล:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ตรวจจับรูปแบบเวิร์กชีทฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กชีท Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในแผนภูมิบางประเภท คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData) ร่วมกับการอ้างอิง [WorkbookType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/WorkbookType) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // เวิร์กชีทที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลเวิร์กชีทของแผนภูมิที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **เวิร์กชีทรายการภายนอก**

Aspose.Slides รองรับเวิร์กชีทรายการภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างเวิร์กชีทรายการภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างเวิร์กชีทรายการภายนอกตั้งแต่ต้น หรือทำให้เวิร์กชีทภายในกลายเป็นภายนอกได้

โค้ด Java ตัวอย่างต่อไปนี้แสดงกระบวนการสร้างเวิร์กชีทรายการภายนอก:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **กำหนดเวิร์กชีทรายการภายนอก**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดเวิร์กชีทรายการภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางของเวิร์กชีทรายการภายนอก (หากไฟล์ดังกล่าวถูกย้ายตำแหน่ง)

แม้คุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กชีทที่จัดเก็บในตำแหน่งจากระยะไกลหรือทรัพยากรได้ แต่คุณยังสามารถใช้เวิร์กชีทเหล่านี้เป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับเวิร์กชีทรายการภายนอก มันจะถูกแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Java ตัวอย่างต่อไปนี้แสดงวิธีกำหนดเวิร์กชีทรายการภายนอก:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

พารามิเตอร์ `updateChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดเวิร์กชีท Excel หรือไม่

* เมื่อค่า `updateChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของเวิร์กชีท — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กชีทเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อเวิร์กชีทเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้
* เมื่อค่า `updateChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะถูกอัปเดตจากเวิร์กชีทเป้าหมาย

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **รับเส้นทางของเวิร์กชีทรายการภายนอกที่ใช้เป็นแหล่งข้อมูลของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
1. ดึงอ้างอิงของสไลด์ผ่านดัชนี
1. สร้างออบเจ็กต์สำหรับรูปร่างแผนภูมิ
1. สร้างออบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงตามประเภทแหล่งข้อมูลที่ตรงกับประเภทแหล่งข้อมูลของเวิร์กชีทรายการภายนอก

โค้ด Java ตัวอย่างนี้แสดงการทำงาน:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// บันทึกพรีเซนเทชัน
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กชีทรายการภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาในเวิร์กชีทภายใน เมื่อเวิร์กชีทรายการภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

โค้ด Java ตัวอย่างต่อไปนี้เป็นการนำเสนอขั้นตอนที่อธิบายไว้:

```java
import com.aspose.slides.*;

// สร้างอินสแตนซ์ของคลาส Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **กู้คืนเวิร์กชีทจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กชีทรายการภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กชีทของแผนภูมิใหม่จากข้อมูลที่แคชไว้ในพรีเซนเทชันได้ สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/) กำหนดค่าโดยใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/spreadsheetoptions/) แล้วเรียกเมธอด [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ให้เป็น `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง Java ด้านล่างเปิดพรีเซนเทชันที่แผนภูมิเชื่อมโยงกับเวิร์กชีทรายการภายนอกที่ไม่สามารถเข้าถึงได้ และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // อ่านหรือแก้ไขข้อมูลเวิร์กชีทรายการที่กู้คืนได้ที่นี่.
} finally {
    presentation.dispose();
}
```

หากเวิร์กชีทรายการภายนอกไม่พร้อมใช้งานและปิดการกู้คืน Aspose.Slides จะโยนข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กชีทรายการภายนอกหลังจากพรีเซนเทชันอัปเดตครั้งสุดท้าย

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่ากราฟใดเชื่อมโยงกับเวิร์กชีทรายการภายนอกหรือเวิร์กชีทที่ฝังอยู่?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) หากแหล่งข้อมูลเป็นเวิร์กชีทรายการภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยังเวิร์กชีทรายการภายนอกหรือไม่ และเก็บอย่างไร?**

รองรับ หากคุณระบุเส้นทางสัมพันธ์ มันจะถูกแปลงเป็นเส้นทางแบบเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโปรเจกต์ อย่างไรก็ตามพรีเซนเทชันจะเก็บเส้นทางแบบเต็มในไฟล์ PPTX

**ฉันสามารถใช้เวิร์กชีทที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้ เวิร์กชีทเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ แต่การแก้ไขเวิร์กชีทระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**

ไม่ พรีเซนเทชันเก็บ [link to the external file](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกจะไม่ถูกแก้ไขเมื่อบันทึกพรีเซนเทชัน

**ถ้าไฟล์ภายนอกถูกตั้งรหัสผ่านควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีทั่วไปคือถอดรหัสป้องกันล่วงหน้าหรือเตรียมสำเนาที่ไม่มีการเข้ารหัส (เช่น ใช้ [Aspose.Cells](/cells/androidjava/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กชีทรายการภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมีลิงก์ของตนเอง หากทุกแผนภูมอ้างอิงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล**