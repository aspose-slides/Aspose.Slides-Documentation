---
title: "จัดการสมุดงานแผนภูมิในการนำเสนอบน Android"
linktitle: "สมุดงานแผนภูมิ"
type: docs
weight: 70
url: /th/androidjava/chart-workbook/
keywords:
- "สมุดงานแผนภูมิ"
- "ข้อมูลแผนภูมิ"
- "เซลล์สมุดงาน"
- "ป้ายกำกับข้อมูล"
- "แผ่นงาน"
- "แหล่งข้อมูล"
- "สมุดงานภายนอก"
- "ข้อมูลภายนอก"
- "แคชแผนภูมิ"
- "การกู้คืนสมุดงาน"
- "PowerPoint"
- "การนำเสนอ"
- "Android"
- "Java"
- "Aspose.Slides"
description: "ค้นพบ Aspose.Slides สำหรับ Android ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน, ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และกำหนดประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แทนค่าข้อมูลที่หายไป ดูที่ [Control the Display of Empty Cells](/slides/th/androidjava/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**
Aspose.Slides ให้บริการเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่อนุญาตให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งประกอบด้วยข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ

ตัวอย่างโค้ด Java นี้แสดงการทำงานตัวอย่าง:

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

### **ตรวจสอบเค้าโครงแผนภูมิหลังจากการแก้ไขสมุดงาน**
เมื่อคุณแทนที่สมุดงานที่ฝังไว้ด้วยสมุดงานที่ได้รับการแก้ไข แผนภูมิจะยังคงคอลเลกชันซีรีส์และหมวดหมู่เดิม การไม่ตรงกันนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChart#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ทำการล้างซีรีส์และหมวดหมู่เดิมก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ

```java
// หลังจากแก้ไขสตรีมสมุดงาน (เช่น ใช้ Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

การล้างคอลเลกชันทำให้โครงสร้างข้อมูลแผนภูมิเข้ากันกับสมุดงานใหม่ ส่งผลให้ `validateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
4. เข้าถึงซีรีส์ของแผนภูมิ
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล
6. บันทึกงานนำเสนอ

ตัวอย่างโค้ด Java ที่แสดงการตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แสดงไฟล์การนำเสนอ
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

## **จัดการแผ่นงาน**
ตัวอย่างโค้ด Java นี้แสดงการดำเนินการที่ใช้เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันแผ่นงาน:

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

## **กำหนดประเภทของแหล่งข้อมูล**
ตัวอย่างโค้ด Java นี้แสดงวิธีการกำหนดประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังไว้ที่ไม่รองรับ**
Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในแผนภูมิบางประเภท คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData) ร่วมกับการอัปเดตประเภท [WorkbookType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/WorkbookType) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเฉพาะเหล่านั้น

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
            // สมุดงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **สมุดงานภายนอก**
Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างสมุดงานภายนอก**
โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือทำให้สมุดงานภายในกลายเป็นภายนอกได้

ตัวอย่างโค้ด Java ที่แสดงกระบวนการสร้างสมุดงานภายนอก:

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

### **กำหนดสมุดงานภายนอก**
โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังสมุดงานภายนอก (หากสมุดงานถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บไว้ในตำแหน่งหรือแหล่งทรัพยากรระยะไกลได้ แต่คุณยังคงใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

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

พารามิเตอร์ `updateChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าควรโหลดสมุดงาน Excel หรือไม่

* เมื่อกำหนดค่า `updateChartData` เป็น `false` จะอัปเดตเพียงเส้นทางของสมุดงานเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้
* เมื่อกำหนดค่า `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะได้รับการอัปเดตจากสมุดงานเป้าหมาย

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

### **รับเส้นทางของสมุดงานแหล่งข้อมูลภายนอกจากแผนภูมิ**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. สร้างอ็อบเจ็กต์สำหรับรูปร่างแผนภูมิ
4. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่เป็นตัวแทนของแหล่งข้อมูลของแผนภูมิ
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงตามประเภทแหล่งข้อมูลที่ตรงกับประเภทแหล่งข้อมูลสมุดงานภายนอก

ตัวอย่างโค้ด Java แสดงการดำเนินการ:

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
	
	// บันทึกการนำเสนอ
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **แก้ไขข้อมูลแผนภูมิ**
คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาในสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**
หากแผนภูมิเกี่ยวข้องกับสมุดงานภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างสมุดงานแผนภูมิใหม่จากข้อมูลที่แคชไว้ในงานนำเสนอได้ ให้สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/), ตั้งค่าให้ใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/spreadsheetoptions/), แล้วเรียก [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ด้วยค่า `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Java ด้านล่างเปิดงานนำเสนอที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนได้ผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

    // อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
} finally {
    presentation.dispose();
}
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชไว้เป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากงานนำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังไว้?**  
ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อตรวจสอบว่ามีการใช้ไฟล์ภายนอกหรือไม่

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่และถูกจัดเก็บอย่างไร?**  
ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ อย่างไรก็ตาม งานนำเสนอจะบันทึกเส้นทางเต็มไว้ในไฟล์ PPTX

**สามารถใช้สมุดงานที่อยู่บนแหล่งเครือข่าย/แชร์ได้หรือไม่?**  
ใช่ สามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**  
ไม่ งานนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกจะไม่ถูกเปลี่ยนแปลงเมื่อบันทึกงานนำเสนอ

**ควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](/cells/androidjava/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  
ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดอ้างอิงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิเมื่อโหลดข้อมูลครั้งถัดไป