---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอด้วย Java
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/java/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายกำกับข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของเวิร์กชีต และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ข้อมูลแผนภูมิต้องจัดระเบียบในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

โค้ด Java นี้แสดงการทำงานตัวอย่าง:

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

### **ตรวจสอบการจัดวางแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังอยู่ด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูลและคอลเลกชันหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#validateChartLayout--) ขว้าง `ArgumentOutOfRangeException` (parameter: index) เพื่อหลีกเลี่ยงข้อยกเว้น ให้ล้างชุดข้อมูลและหมวดหมู่ที่มีอยู่ **before** ก่อนที่จะเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ

```java
// หลังจากแก้ไขสตรีมสมุดงาน (เช่น ใช้ Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

การล้างคอลเลกชันทำให้โครงสร้างข้อมูลแผนภูมิสอดคล้องกับสมุดงานใหม่ ทำให้ `validateChartLayout` สามารถทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **กำหนดเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
4. เข้าถึงชุดข้อมูลของแผนภูมิ
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล
6. บันทึกการนำเสนอ

โค้ด Java นี้แสดงวิธีตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// สร้างอ็อบเจกต์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
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

## **จัดการเวิร์กชีต**

โค้ด Java นี้แสดงการใช้เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของเวิร์กชีต:

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

โค้ด Java นี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังซึ่งไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่สามารถฝังอยู่ในแผนภูมิบางประเภท คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData) ร่วมกับการอิมพอร์ต [WorkbookType](https://reference.aspose.com/slides/th/java/com.aspose.slides/WorkbookType) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น

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

{{% alert color="info" %}} 
ใน [Aspose.Slides 19.4](https://docs.aspose.com/slides/th/java/aspose-slides-for-java-19-4-release-notes/) เราได้เพิ่มการสนับสนุนสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกจากจุดเริ่มต้นหรือทำให้สมุดงานภายในกลายเป็นภายนอกได้

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

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางของสมุดงานภายนอก (หากไฟล์นั้นถูกย้ายไป)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งหรือแหล่งข้อมูลระยะไกลได้ แต่คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Java นี้แสดงวิธีกำหนดสมุดงานภายนอก:

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

พารามิเตอร์ที่สอง (`boolean`) ของเมธอด `setExternalWorkbook` ถูกใช้เพื่อระบุว่าจะโหลดสมุดงาน Excel หรือไม่
* เมื่อค่าตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดงานเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีหรือไม่พร้อมใช้งาน
* เมื่อค่าตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

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

### **ดึงเส้นทางสมุดงานแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
3. สร้างอ็อบเจกต์สำหรับรูปทรงแผนภูมิ
4. สร้างอ็อบเจกต์สำหรับประเภทแหล่ง (`ChartDataSourceType`) ที่เป็นตัวแทนของแหล่งข้อมูลของแผนภูมิ
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งที่เหมือนกับประเภทแหล่งข้อมูลสมุดงานภายนอก

โค้ด Java นี้แสดงการดำเนินการ:

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

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

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานของแผนภูมิจากข้อมูลที่แคชไว้ในไฟล์นำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/), ตั้งค่าด้วย [SpreadsheetOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/spreadsheetoptions/), แล้วเรียก [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ด้วยค่า `true` ก่อนเปิดไฟล์นำเสนอ

ตัวอย่าง Java ด้านล่างเปิดไฟล์นำเสนอที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
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

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะขว้างข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิค้างเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากไฟล์นำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังไว้?**

ได้เลย แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับเส้นทางแบบสัมพันธ์สำหรับสมุดงานภายนอกหรือไม่ และเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางแบบสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ สิ่งนี้สะดวกสำหรับการพกพาโครงการ อย่างไรก็ตาม โปรดทราบว่าไฟล์นำเสนอจะบันทึกเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้ สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

ไม่ การนำเสนอจะบันทึก [link to the external file](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) แล้วใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกการนำเสนอ

**ฉันควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล