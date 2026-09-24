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
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพข้อมูลในงานนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายข้อมูลของแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แสดงข้อมูลขาดหาย ดูที่ [Control the Display of Empty Cells](/slides/th/java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับศูนย์ และการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้เลือก

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่ให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ที่มีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ

โค้ด Java นี้แสดงตัวอย่างการดำเนินการ:

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

เมื่อคุณแทนที่สมุดงานที่ฝังอยู่ด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะยังคงคอลเลกชันซีรีส์และหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#validateChartLayout--) โยน `ArgumentOutOfRangeException` (parameter: index) เพื่อหลีกเลี่ยงข้อยกเว้น ให้ลบซีรีส์และหมวดหมู่ที่มีอยู่ **before** ก่อนจะเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ

```java
// หลังจากแก้ไขสตรีมสมุดงาน (เช่น ใช้ Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

การลบคอลเลกชันทำให้โครงสร้างข้อมูลแผนภูมิตรงกับสมุดงานใหม่ ทำให้ `validateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation) .
2. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน.
3. เพิ่มแผนภูมิกระจุ๊บ (Bubble) พร้อมข้อมูลบางส่วน.
4. เข้าถึงซีรีส์ของแผนภูมิ.
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูล.
6. บันทึกการพรีเซนเทชัน.

โค้ด Java นี้แสดงวิธีตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
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

โค้ด Java นี้แสดงการดำเนินการที่ใช้เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของแผ่นงาน:

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

## **ระบุประเภทแหล่งข้อมูล**

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

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` ของ [IChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData) ร่วมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/th/java/com.aspose.slides/WorkbookType) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิที่เกี่ยวข้อง

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
            // สมุดงานฝังอยู่ในรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกตั้งแต่ต้น หรือแปลงสมุดงานภายในให้เป็นภายนอกได้

โค้ด Java นี้แสดงกระบวนการสร้างสมุดงานภายนอก:

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

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์ถูกย้ายตำแหน่ง)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บบนตำแหน่งหรือทรัพยากรระยะไกลได้ แต่คุณ ยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

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

พารามิเตอร์ที่สอง (`boolean`) ของเมธอด `setExternalWorkbook` ใช้ระบุว่าจะโหลดสมุดงาน Excel หรือไม่

* เมื่อค่าตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีอยู่หรือไม่พร้อมใช้งาน
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

### **ดึงเส้นทางสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation) .
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ.
4. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แทนแหล่งข้อมูลของแผนภูมิ.
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่เหมือนกับประเภทแหล่งข้อมูลสมุดงานภายนอก.

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
	
	// บันทึกงานนำเสนอ
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดงานภายใน เมื่อไม่สามารถโหลดสมุดงานภายนอก ระบบจะโยนข้อยกเว้น

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

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิใหม่จากข้อมูลที่เก็บไว้ในแคชของงานพรีเซนเทชันได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/), ตั้งค่าโดยใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/spreadsheetoptions/), แล้วเรียก [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ด้วยค่า `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง Java ต่อไปนี้เปิดพรีเซนเทชันที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

หากสมุดงานภายนอกไม่พร้อมใช้และการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น ให้เปิดใช้การกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิจากแคชเป็นวิธีสำรองที่รับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากที่พรีเซนเทชันอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**Can I determine whether a specific chart is linked to an external or an embedded workbook?**  
ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกถูกใช้

**Are relative paths to external workbooks supported, and how are they stored?**  
ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ แต่ต้องทราบว่าพรีเซนเทชันจะเก็บเส้นทางเต็มไว้ในไฟล์ PPTX

**Can I use workbooks located on network resources/shares?**  
ใช่ สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Does Aspose.Slides overwrite the external XLSX when saving the presentation?**  
ไม่ พรีเซนเทชันเก็บ [link to the external file](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) เพื่อใช้ในการอ่านข้อมูล ไฟล์ภายนอกจะไม่ได้รับการแก้ไขเมื่อบันทึกพรีเซนเทชัน

**What should I do if the external file is password-protected?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาไม่ได้เข้ารหัส (เช่น ใช้ [Aspose.Cells](/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**Can multiple charts reference the same external workbook?**  
ใช่ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อโหลดข้อมูลครั้งถัดไป