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
description: "สำรวจ Aspose.Slides สำหรับ Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก การดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และการแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แทนค่าขาดหาย ดู [ควบคุมการแสดงเซลล์ว่าง](/slides/th/java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแบบเส้นของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อควบคุมว่าการวาดแผนภูมิจะใช้ข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อวาดเฉพาะเซลล์ที่มองเห็น หรือ `false` เพื่อรวมเซลล์ที่มองเห็นและซ่อน การตั้งค่านี้ควบคุมการวาดแผนภูมิเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

ดาวน์โหลด [hidden-source-data.pptx](hidden-source-data.pptx) และวางไว้ในไดเรกทอรีทำงาน สไลด์แรกมีแผนภูมิคอลัมน์เป็นรูปร่างแรก แผ่นงานฝัง `Sheet1` มีช่วงข้อมูลต้นฉบับ `A1:C4` โดยแถว 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ยังคงมีค่า

| แถวแผ่นงาน | A: เดือน | B: ปลีก | C: สินค้าส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นฉบับผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่าน [IChartDataCell.isHidden](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#isHidden--) เพื่อตรวจสอบสถานะซ่อนของเซลล์ วิธีนี้รายงานสถานะโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ `false`, `true`, `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังเปลี่ยนการตั้งค่าวาด: คงสมุดงานฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#readWorkbookStream--) แล้วโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อคืนช่วงเต็มรวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายชื่อหมวดหมู่ที่เก็บไว้ในตัวอย่างนี้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // รีเฟรชข้อมูลแผนภูมิจากสมุดงานที่ฝังอยู่.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // คืนช่วงแหล่งข้อมูลทั้งหมด รวมถึงหมวดหมู่ที่ซ่อนอยู่.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

ตัวอย่างบันทึก `hidden_cells_true.pptx` ด้วยค่าปลีกที่มองเห็นเท่านั้น (10 และ 20) และบันทึก `hidden_cells_false.pptx` ด้วยค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการวาด แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานฝังทั้งสอง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าปลีก 10 และ 20 สำหรับ มกราคมและ มีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าปลีกและสินค้าส่งสำหรับ มกราคม, กุมภาพันธ์, และ มีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ที่ว่างเปล่า [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้เพิ่มหรือเอาแหล่งข้อมูลที่ซ่อนออก ดู [ควบคุมการแสดงเซลล์ว่าง](/slides/th/java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) ที่ให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลแผนภูมิจะต้องจัดระเบียบในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก มันอ่านสมุดงานฝังเป็นอาเรย์ไบต์ ทำความสะอาดซีรีส์และหมวดหมู่เดิม แล้วเขียนสมุดงานเดียวกันกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ ตัวอย่างไม่บันทึกการนำเสนอ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **ตรวจสอบการจัดวางแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณทดแทนสมุดงานฝังด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะยังคงเก็บคอลเลกชันซีรีส์และหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาดดัชนีเกินช่วง ทำความสะอาดซีรีส์และหมวดหมู่เดิมก่อนเขียนสมุดงานอัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ต้องการ `chart.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์บ่งชี้ตำแหน่งที่การแก้ไขสมุดงานจะเกิดขึ้น; ตัวอย่างทำงานเขียนสมุดงานต้นฉบับกลับและตรวจสอบการจัดวางในหน่วยความจำ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // แก้ไขไบต์ของสมุดงานที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

การทำความสะอาดคอลเลกชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนสมุดงานถูกเขียนกลับ สร้างแมปปิ้งซีรีส์และหมวดหมู่ที่ต้องการใหม่สำหรับสมุดงานที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายกำกับข้อมูลของแผนภูมิ ขั้นตอนต่อไปนี้แสดงวิธีเชื่อมป้ายกำกับในแผนภูมิบับเบิลกับเซลล์ในสมุดงานข้อมูลของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกด้วยดัชนีเริ่มจากศูนย์  
3. เพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล  
6. บันทึกการนำเสนอ

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ และเพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น ใช้เซลล์ A10:A12 ในแผ่นงาน 0 เป็นป้ายชื่อสามรายการแรกของซีรีส์แรก เปิดใช้งานป้ายชื่อจากเซลล์ และบันทึกผลลัพธ์เป็น `resultchart.pptx`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **จัดการแผ่นงาน**

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้เข้าถึงแผ่นงานในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละชื่อลงคอนโซล

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **ระบุประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและตั้งชื่อซีรีส์สองรายการโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิติดัล; ชื่อที่สองใช้เซลล์ C1 ในแผ่นงาน 0 [DataSourceType](https://reference.aspose.com/slides/th/java/com.aspose.slides/datasourcetype/) กำหนดแหล่งที่มาให้แต่ละชื่อ ผลลัพธ์บันทึกเป็น `pres.pptx`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในแผนภูมิบางประเภท คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/java/com.aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของ `sample.pptx` ข้ามรูปร่างที่ไม่ใช่แผนภูมิและพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออกสมุดงานแผนภูมิฝังไปยังไฟล์และเชื่อมแผนภูมิกับสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้น เขียนสมุดงานไปยัง `externalWorkbook1.xlsx` และทำการเขียนไฟล์ให้เสร็จก่อนกำหนดไฟล์เป็นแหล่งข้อมูลของแผนภูมิ บันทึกการนำเสนอที่เชื่อมโยงเป็น `externalWorkbook.pptx`

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **ตั้งสมุดงานภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังใช้สำหรับอัปเดตเส้นทางไปยังสมุดงานภายนอก (หากย้ายไฟล์)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บไว้ในตำแหน่งระยะไกลหรือทรัพยากรได้ คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้เส้นทางสัมพัทธ์กับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ต้องการไฟล์ `externalWorkbook.xlsx` ในไดเรกทอรีทำงาน แผ่นงาน `Sheet1` ต้องมีชื่อซีรีส์ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมีพาย เชื่อมสมุดงาน และใช้ [setRange](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแมป A1:B4 เป็นซีรีส์หนึ่งและสามหมวดหมู่ บันทึกผลเป็น `Presentation_with_externalWorkbook.pptx`

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ควบคุมว่าการโหลดสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเพียงเส้นทางสมุดงานเท่านั้น ไม่โหลดหรืออัปเดตข้อมูลแผนภูมิจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่พร้อมใช้งาน  
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้ง `updateChartData` เป็น `false` แสดงแผนภูมิพายด้วยข้อมูลเริ่มต้นและบันทึกการนำเสนอโดยไม่โหลดสมุดงานที่ไม่พร้อมใช้งาน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **รับเส้นทางสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุสมุดงานที่เชื่อมโยงกับแผนภูมิ ให้ตรวจสอบก่อนว่าแผนภูมินั้นใช้แหล่งข้อมูลภายนอกหรือไม่ หากใช้ให้ดึงเส้นทางสมุดงานตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกด้วยดัชนีเริ่มจากศูนย์  
3. ตรวจสอบว่ารูปร่างแรกเป็นแผนภูมิหรือไม่  
4. อ่านประเภทแหล่งข้อมูลของแผนภูมิ  
5. หากแหล่งเป็นสมุดงานภายนอก ให้อ่านเส้นทางของมัน

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างในตัวอย่างก่อนหน้าและตรวจสอบรูปร่างแรกบนสไลด์แรก หากเป็นแผนภูมิเชื่อมกับสมุดงานภายนอก ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ไปยังคอนโซล แล้วบันทึกสำเนาการนำเสนอเป็น `Result.pptx`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลในสมุดงานภายใน หากสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ต้องการ `presentation.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและมีสมุดงานภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อิงเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 แล้วบันทึกการนำเสนอเป็น `presentation_out.pptx` การแก้ไขค่าจากเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ จึงควรใช้สำเนาหากต้องการรักษาสมุดงานต้นฉบับไว้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิกลับจากข้อมูลที่แคชไว้ในไฟล์การนำเสนอได้ สร้างอ็อบเจกต์ [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), และตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง Java ด้านล่างเปิด `presentation.pptx` ซึ่งรูปร่างแรกบนสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งาน และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชไว้เป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากการอัปเดตการนำเสนอครั้งล่าสุด

## **FAQ**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝัง?**

ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล]((https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getDataSourceType--)) และ [เส้นทางไปยังสมุดงานภายนอก]((https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีไฟล์ภายนอกถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่ และจัดเก็บอย่างไร?**

รองรับ หากระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนอัตโนมัติเป็นเส้นทางเต็ม การนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายสมุดงานอาจจำเป็นต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้ สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่สนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

การนำเสนอเก็บ [ลิงก์ไปยังไฟล์ภายนอก]((https://reference.aspose.com/slides/th/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)) การแก้ไขข้อมูลแผนภูมิตามเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ใช้สำเนาของสมุดงานหากต้องการให้ต้นฉบับไม่เปลี่ยนแปลง

**ควรทำอย่างไรหากไฟล์ภายนอกถูกตั้งรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดรหัสล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิเมื่อโหลดข้อมูลใหม่