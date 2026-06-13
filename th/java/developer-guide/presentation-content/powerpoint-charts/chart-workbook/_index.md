---
title: "จัดการสมุดงานแผนภูมิในงานนำเสนอด้วย Java"
linktitle: "สมุดงานแผนภูมิ"
type: docs
weight: 70
url: /th/java/chart-workbook/
keywords:
- "สมุดงานแผนภูมิ"
- "ข้อมูลแผนภูมิ"
- "เซลล์สมุดงาน"
- "ป้ายกำกับข้อมูล"
- "แผ่นงาน"
- "แหล่งข้อมูล"
- "สมุดงานภายนอก"
- "ข้อมูลภายนอก"
- "PowerPoint"
- "การนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "ค้นพบ Aspose.Slides สำหรับ Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานของแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน, ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลคชันของแผ่นงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ. นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานนั้นพร้อมใช้งาน.

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่อนุญาตให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งประกอบด้วยข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องถูกจัดระเบียบในลักษณะเดียวกันหรือจะต้องมีโครงสร้างคล้ายกับต้นทาง.  

โค้ด Java นี้แสดงตัวอย่างการดำเนินการ:

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

## **ตั้งค่าเซลล์WorkBookเป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน.
4. เข้าถึงชุดข้อมูลของแผนภูมิ.
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล.
6. บันทึกการนำเสนอ.

โค้ด Java นี้แสดงวิธีตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ:

```java
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

## **จัดการ Worksheets**

โค้ด Java นี้แสดงการดำเนินการที่เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) ถูกใช้เพื่อเข้าถึงคอลเลคชันของ worksheet:

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

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/IChartData) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/java/com.aspose.slides/WorkbookType) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิที่เกี่ยวข้อง.

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
ใน [Aspose.Slides 19.4](https://docs.aspose.com/slides/th/java/aspose-slides-for-java-19-4-release-notes/) เราได้เพิ่มการสนับสนุนสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ. 
{{% /alert %}} 

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกตั้งแต่ต้นหรือเปลี่ยนสมุดงานภายในให้เป็นภายนอกได้.  

โค้ด Java นี้แสดงกระบวนการสร้างสมุดงานภายนอก:

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

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์นั้นถูกย้ายไปแล้ว).  

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บอยู่ในตำแหน่งหรือทรัพยากรระยะไกลได้ คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากกำหนดเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ.  

โค้ด Java นี้แสดงวิธีกำหนดสมุดงานภายนอก:

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

พารามิเตอร์ `ChartData` (ภายใต้เมธอด `setExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดสมุดงาน Excel หรือไม่  

* เมื่อค่า `ChartData` ถูกตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดงานเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีอยู่หรือไม่พร้อมใช้งาน.  
* เมื่อค่า `ChartData` ถูกตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย.  

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

### **รับเส้นทางสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/java/com.aspose.slides/presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. สร้างอ็อบเจ็กต์สำหรับรูปแบบแผนภูมิ.
4. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แทนแหล่งข้อมูลของแผนภูมิ.
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่ตรงกับประเภทแหล่งข้อมูลสมุดงานภายนอก.

โค้ด Java นี้แสดงการดำเนินการ:

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของสมุดงานภายใน หากไม่สามารถโหลดสมุดงานภายนอกได้ ระบบจะโยนข้อยกเว้น.  

โค้ด Java นี้เป็นการนำกระบวนการที่อธิบายไปใช้งาน:

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

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝัง?**  

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอก.

**รองรับเส้นทางสัมพันธ์สำหรับสมุดงานภายนอกหรือไม่และจัดเก็บอย่างไร?**  

ใช่ หากคุณกำหนดเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ สิ่งนี้ทำให้โครงการพกพาง่ายขึ้น; อย่างไรก็ตามการนำเสนอตัวจะเก็บเส้นทางเต็มไว้ในไฟล์ PPTX.

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**  

ใช่ สมุดงานเช่นนี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น.

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**  

ไม่ การนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) และใช้เพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกการนำเสนอ.

**ควรทำอย่างไรหากไฟล์ภายนอกถูกตั้งรหัสผ่าน?**  

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น.

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตัวเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล.