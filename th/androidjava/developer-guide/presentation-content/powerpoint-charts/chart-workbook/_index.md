---
title: จัดการสมุดทำงานแผนภูมิในงานนำเสนอบน Android
linktitle: สมุดทำงานแผนภูมิ
type: docs
weight: 70
url: /th/androidjava/chart-workbook/
keywords:
- สมุดทำงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดทำงาน
- ป้ายกำกับข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- สมุดทำงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดทำงาน
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Android ผ่าน Java: จัดการสมุดทำงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดาย เพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดทำงานของแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดทำงาน ใช้เซลล์ของสมุดทำงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของเวิร์กชีต และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดทำงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะสาธิตวิธีการสร้างและกำหนดสมุดทำงานภายนอก ดึงเส้นทางของสมุดทำงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดทำงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดทำงาน**
Aspose.Slides ให้บริการเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่ช่วยให้คุณอ่านและเขียนสมุดทำงานของข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูลต้นฉบับ

โค้ด Java นี้สาธิตการดำเนินการตัวอย่าง:

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

## **ตั้งค่าเซลล์ WorkBook เป็นป้ายกำกับข้อมูลแผนภูมิ**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. เพิ่มแผนภูมิแบบบับเบิลพร้อมข้อมูลบางส่วน
4. เข้าถึงซีรีส์ของแผนภูมิ
5. ตั้งค่าเซลล์ของสมุดทำงานเป็นป้ายกำกับข้อมูล
6. บันทึกการนำเสนอ

โค้ด Java นี้แสดงวิธีการตั้งค่าเซลล์ของสมุดทำงานเป็นป้ายกำกับข้อมูลแผนภูมิ:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาสการนำเสนอที่แสดงถึงไฟล์การนำเสนอ
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
โค้ด Java นี้สาธิตการดำเนินการที่ใช้เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของเวิร์กชีต:

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
โค้ด Java นี้แสดงวิธีการระบุประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบสมุดทำงานฝังที่ไม่รองรับ**
Aspose.Slides ไม่รองรับรูปแบบสมุดทำงาน Excel ไบนารี (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/WorkbookType) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมินั้นได้

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
            // สมุดทำงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดทำงานของแผนภูมิที่นี่
    }
} finally {
    presentation.dispose();
}
```

## **สมุดทำงานภายนอก**
Aspose.Slides รองรับสมุดทำงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างสมุดทำงานภายนอก**
โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดทำงานภายนอกจากศูนย์หรือทำให้สมุดทำงานภายในเป็นภายนอกได้

โค้ด Java นี้สาธิตกระบวนการสร้างสมุดทำงานภายนอก:

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

### **กำหนดสมุดทำงานภายนอก**
โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดทำงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ วิธีนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางของสมุดทำงานภายนอก (หากไฟล์ดังกล่าวถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดทำงานที่จัดเก็บในตำแหน่งห่างไกลหรือทรัพยากรได้ แต่คุณยังสามารถใช้สมุดทำงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับสมุดทำงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Java นี้แสดงวิธีการกำหนดสมุดทำงานภายนอก:

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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดสมุดทำงาน Excel หรือไม่

* เมื่อค่าของ `ChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดทำงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดทำงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อสมุดทำงานเป้าหมายไม่มีอยู่หรือไม่พร้อมใช้งาน
* เมื่อค่าของ `ChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดทำงานเป้าหมาย

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

### **ดึงเส้นทางของสมุดทำงานแหล่งข้อมูลภายนอกจากแผนภูมิ**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. สร้างอ็อบเจ็กต์สำหรับรูปร่างแผนภูมิ
4. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่เป็นตัวแทนของแหล่งข้อมูลของแผนภูมิ
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่ตรงกับประเภทแหล่งข้อมูลของสมุดทำงานภายนอก

โค้ด Java นี้สาธิตการดำเนินการ:

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
คุณสามารถแก้ไขข้อมูลในสมุดทำงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดทำงานภายใน เมื่อสมุดทำงานภายนอกไม่สามารถโหลดได้ ระบบจะขว้างข้อยกเว้น

โค้ด Java นี้เป็นการนำเสนอขั้นตอนที่อธิบายไว้:

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

### **กู้คืนสมุดทำงานจากแคชของแผนภูมิ**
หากแผนภูมิใช้สมุดทำงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดทำงานของแผนภูมิใหม่จากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/), ตั้งค่าโดยใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/spreadsheetoptions/), และเรียก [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) ด้วยค่า `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Java ต่อไปนี้เปิดงานนำเสนอที่แผนภูมิเชื่อมโยงกับสมุดทำงานภายนอกที่ไม่สามารถเข้าถึงได้และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // อ่านหรือแก้ไขข้อมูลสมุดทำงานที่กู้คืนที่นี่
} finally {
    presentation.dispose();
}
```

หากสมุดทำงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะขว้างข้อยกเว้น เปิดใช้การกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่รวมการเปลี่ยนแปลงที่ทำกับสมุดทำงานภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **FAQ**
**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับสมุดทำงานภายนอกหรือฝังอยู่?**  
ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [เส้นทางไปยังสมุดทำงานภายนอก](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) หากแหล่งเป็นสมุดทำงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกถูกใช้งานอยู่

**รองรับเส้นทางสัมพันธ์ไปยังสมุดทำงานภายนอกหรือไม่ และถูกจัดเก็บอย่างไร?**  
ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโปรเจกต์; อย่างไรก็ตาม ให้ทราบว่างานนำเสนอจะจัดเก็บเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้สมุดทำงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**  
ใช่ สามารถใช้สมุดทำงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ แต่การแก้ไขสมุดทำงานระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อตั้งค่าบันทึกงานนำเสนอหรือไม่?**  
ไม่ งานนำเสนอจะเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกงานนำเสนอ

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่านควรทำอย่างไร?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีที่ใช้บ่อยคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/androidjava/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดทำงานภายนอกเดียวกันได้หรือไม่?**  
ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล