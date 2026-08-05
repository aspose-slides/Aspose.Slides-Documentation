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
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน, ใช้เซลล์ของสมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่ให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องถูกจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

```java
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

## **กำหนดเซลล์ WorkBook เป็นป้ายข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation)  
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. เพิ่มแผนภูมิแบบบับเบิลพร้อมข้อมูลบางส่วน  
1. เข้าถึงซีรีส์ของแผนภูมิ  
1. ตั้งค่าเซลล์ของสมุดงานเป็นป้ายข้อมูล  
1. บันทึกการนำเสนอ  

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ
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

โค้ด Java ด้านล่างสาธิตการดำเนินการที่ใช้เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของแผ่นงาน:

```java
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

## **ตรวจจับรูปแบบ Workbook ฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่สามารถฝังในบางแผนภูมิได้ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData) พร้อมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/java/com.aspose.slides/WorkbookType) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```java
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

{{% alert color="primary" %}} 
ใน [Aspose.Slides 19.4](https://docs.aspose.com/slides/th/java/aspose-slides-for-java-19-4-release-notes/) เราได้เพิ่มการสนับสนุนสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือทำให้สมุดงานภายในกลายเป็นภายนอกได้

```java
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

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากสมุดงานนั้นถูกย้าย)

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บอยู่ในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังคงสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพันธ์สำหรับสมุดงานภายนอก, มันจะถูกแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

```java
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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้กำหนดว่าจะโหลดสมุดงาน Excel หรือไม่  

* เมื่อค่าของ `ChartData` ตั้งค่าเป็น `false` เส้นทางของสมุดงานจะถูกอัปเดตเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
* เมื่อค่าของ `ChartData` ตั้งค่าเป็น `true` ข้อมูลแผนภูมิจะถูกอัปเดตจากสมุดงานเป้าหมาย  

```java
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

### **รับเส้นทางสมุดงานแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation)  
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ  
1. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ  
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่เป็นเช่นเดียวกับประเภทแหล่งข้อมูลสมุดงานภายนอก  

```java
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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของสมุดงานภายใน เมื่อไม่สามารถโหลดสมุดงานภายนอกได้ จะเกิดข้อยกเว้น

```java
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

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้, Aspose.Slides สามารถสร้างสมุดงานแผนภูมิใหม่จากข้อมูลที่แคชไว้ในไฟล์นำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/), กำหนดค่าโดยใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/spreadsheetoptions/), และเรียก [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ด้วยค่า `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง Java ด้านล่างเปิดการนำเสนอที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่สามารถเข้าถึงได้และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

หากสมุดงานภายนอกไม่สามารถเข้าถึงได้และการกู้คืนถูกปิด, Aspose.Slides จะโยงข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชไว้เป็นแนวทางสำรองที่ยอมรับได้ เพราะแคชอาจไม่ได้บันทึกการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากการนำเสนอครั้งล่าสุดถูกอัปเดต

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝัง?**  
ใช่  แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) หากแหล่งข้อมูลเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกหรือไม่

**เส้นทางแบบสัมพันธ์ไปยังสมุดงานภายนอกรองรับหรือไม่ และเก็บอย่างไร?**  
ใช่ หากคุณระบุเส้นทางแบบสัมพันธ์ มันจะถูกแปลงอัตโนมัติเป็นเส้นทางเต็ม ซึ่งสะดวกต่อการพกพาโปรเจกต์; อย่างไรก็ตาม การนำเสนอจะเก็บเส้นทางเต็มไว้ในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่ตั้งอยู่บนทรัพยากร/แชร์ของเครือข่ายได้หรือไม่?**  
ใช่ สมุดงานเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**  
ไม่ การนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกการนำเสนอ

**ฉันควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัส (เช่นโดยใช้ [Aspose.Cells](/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  
ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดอ้างอิงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล