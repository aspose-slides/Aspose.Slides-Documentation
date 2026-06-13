---
title: จัดการสมุดงานแผนภูมิในการนำเสนอบน Android
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/androidjava/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Android ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยจะแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน, ใช้เซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และกำหนดประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) ที่ให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

โค้ด Java นี้แสดงตัวอย่างการทำงาน:

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

## **ตั้งค่าเซลล์ WorkBook เป็นป้ายข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
1. เข้าถึงซีรีส์ของแผนภูมิ
1. ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูล
1. บันทึกการนำเสนอ

โค้ด Java นี้แสดงวิธีการตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// สร้างอินสแตนซ์ของคลาสการนำเสนอที่เป็นตัวแทนของไฟล์การนำเสนอ
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

โค้ด Java นี้แสดงการดำเนินการที่ใช้เมธอด [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) เพื่อเข้าถึงคอลเลกชันของ Worksheet:

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

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในแผนภูมิบางรายการ คุณสามารถใช้เมธอด `getEmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IChartData) พร้อมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/WorkbookType) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเห่านั้น

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
            // สมุดงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดงานของแผนภูมิที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`readWorkbookStream`** และ **`setExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือทำให้สมุดงานภายในเป็นภายนอกได้

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

### **ตั้งค่าสมุดงานภายนอก**

โดยใช้เมธอด **`setExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางของสมุดงานภายนอก (หากสมุดงานนั้นถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งหรือทรัพยากรระยะไกลได้ คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะปรับเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Java นี้แสดงวิธีการตั้งค่าสมุดงานภายนอก:

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

* เมื่อค่าของ `ChartData` ถูกตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้ในกรณีที่สมุดงานเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้
* เมื่อค่าของ `ChartData` ถูกตั้งเป็น `true` ข้อมูลแผนภูมิจะถูกอัปเดตจากสมุดงานเป้าหมาย

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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://apireference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
1. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน
1. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ
1. สร้างอ็อบเจกต์สำหรับประเภทแหล่งที่มา (`ChartDataSourceType`) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งที่มาตรงกับประเภทแหล่งข้อมูลของสมุดงานภายนอก

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกรูแบบเดียวกับที่ทำการเปลี่ยนแปลงเนื้อหาในสมุดงานภายในได้ เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

โค้ด Java นี้เป็นการนำกระบวนการที่อธิบายไปใช้:

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

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับสมุดงานภายนอกจากหรือสมุดงานฝังอยู่?**

ใช่. แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [เส้นทางไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); หากแหล่งที่มาคือสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ใช่. หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ สิ่งนี้สะดวกสำหรับการพกพาโครงการ; อย่างไรก็ตาม โปรดทราบว่าการนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่ตั้งอยู่บนเครือข่าย/แชร์ได้หรือไม่?**

ได้, สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — พวกมันสามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

ไม่. การนำเสนอจะเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) และใช้เพื่ออ่านข้อมูลไฟล์ภายนอกนั้น จะไม่มีการแก้ไขไฟล์ภายนอกเมื่อบันทึกการนำเสนอ

**ควรทำอย่างไรหากไฟล์ภายนอกรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีที่พบบ่อยคือการลบการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/androidjava/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทุกแผนภูมิอ้างถึงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งถัดไปที่โหลดข้อมูล