---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอบน Android
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
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Android ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมผ่านสตรีมสมุดงาน, ใช้เซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันแผ่นงาน, และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แทนค่าขาดข้อมูล, ดู [Control the Display of Empty Cells](/slides/th/androidjava/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับค่า 0, รวมถึงการเปรียบเทียบแบบเส้นกราฟของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อกำหนดว่าต้องการให้แผนภูมิเส้นข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อวาดเพียงเซลล์ที่มองเห็น, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและซ่อน การตั้งค่านี้ควบคุมการวาดแผนภูมิ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

ดาวน์โหลด [hidden-source-data.pptx](hidden-source-data.pptx) แล้ววางไว้ในไดเรกทอรีทำงาน สไลด์แรกของไฟล์มีแผนภูมิคอลัมน์เป็นรูปร่างแรก แผ่นงานที่ฝังอยู่ `Sheet1` มีช่วงข้อมูลต้นแบบ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่า

| แถวแผ่นงาน | A: เดือน | B: รายการขายปลีก | C: รายการขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นแบบผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่านคุณสมบัติ [IChartDataCell.isHidden](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) เพื่อพิจารณาว่าเซลล์ถูกซ่อนหรือไม่ วิธีนี้รายงานสถานะซ่อนโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็น, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะพิมพ์ `false`, `true`, `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมหลังจากเปลี่ยนการตั้งค่าการวาด: คงสมุดงานที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) แล้วโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อกู้คืนช่วงเต็มรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อนไว้ การเปลี่ยนค่าธงอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายชื่อหมวดที่แคชไว้ในตัวอย่างนี้

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
                // กู้คืนช่วงแหล่งข้อมูลเต็มรวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึก `hidden_cells_true.pptx` โดยมีค่าปลีกที่มองเห็นเพียง 10 และ 20, และ `hidden_cells_false.pptx` มีค่าทั้งหกค่า ภาพด้านล่างแสดงโหมดการวาดสองแบบ แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานที่ฝังทั้งสองไฟล์

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลต้นแบบที่ซ่อน ดู [Control the Display of Empty Cells](/slides/th/androidjava/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for Android via Java ให้เมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งอาจถูกแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดรูปแบบในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับต้นทาง

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปร่างแรกของสไลด์แรก มันอ่านสมุดงานที่ฝังไว้เป็นอาร์เรย์ไบต์, ลบซีรีส์และหมวดที่มีอยู่, แล้วเขียนสมุดงานเดิมกลับคืน การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกการนำเสนอ

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

### **ตรวจสอบเค้าโครงแผนภูมิหลังจากการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังไว้ด้วยสมุดงานที่แก้ไขแล้ว, แผนภูมิมักยังคงรักษาคอลเลกชันซีรีส์และหมวดเดิมไว้ ความไม่ตรงกันนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ให้ลบซีรีส์และหมวดที่มีอยู่ก่อนเขียนสมุดงานอัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ต้องการ `chart.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกของสไลด์แรก คอมเมนต์ส่วนที่จะแก้ไขสมุดงาน; ตัวอย่างทำงานเขียนสมุดงานเดิมกลับและตรวจสอบเค้าโครงในหน่วยความจำ

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

การลบคอลเลกชันจะทำให้การอ้างอิงข้อมูลเก่าๆ หายไปก่อนที่สมุดงานจะถูกเขียนกลับ ให้สร้างซีรีส์และการแมปหมวดใหม่ตามสมุดงานที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิได้ ขั้นตอนต่อไปนี้แสดงวิธีการเชื่อมป้ายในแผนภูมิบับเบิ้ลกับเซลล์ในสมุดข้อมูลของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์
3. เพิ่มแผนภูมิบับเบิ้ลด้วยข้อมูลค่าเริ่มต้น
4. เข้าถึงซีรีส์ของแผนภูมิ
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูล
6. บันทึกการนำเสนอ

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์, แล้วเพิ่มแผนภูมิบับเบิ้ลด้วยข้อมูลค่าเริ่มต้น ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายแรกสามอันของซีรีส์แรก, เปิดใช้งานป้ายจากเซลล์, และบันทึกผลลัพธ์เป็น `resultchart.pptx`

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

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้เข้าถึงแผ่นงานในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลค่าเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละชื่อลงคอนโซล

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

## **ระบุประเภทของแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลค่าเริ่มต้นและตั้งชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิตเตรัล; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 [DataSourceType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/datasourcetype/) ใช้ระบุแหล่งสำหรับแต่ละชื่อ ผลลัพธ์บันทึกเป็น `pres.pptx`

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังไว้ที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจถูกฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/) ร่วมกับ [WorkbookType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของ `sample.pptx`, ข้ามรูปร่างที่ไม่ใช่แผนภูมิ, แล้วพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่

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

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออกสมุดงานแผนภูมิที่ฝังไว้เป็นไฟล์และเชื่อมแผนภูมิกับสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลค่าเริ่มต้น, เขียนสมุดงานของมันเป็น `externalWorkbook1.xlsx`, แล้วทำการเขียนไฟล์ให้เสร็จก่อนกำหนดไฟล์เป็นแหล่งข้อมูลของแผนภูมิ บันทึกการนำเสนอที่เชื่อมโยงเป็น `externalWorkbook.pptx`

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางของสมุดงานภายนอก (หากสมุดงานถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรอื่นได้, คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก มันจะถูกแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ต้องการ `externalWorkbook.xlsx` ในไดเรกทอรีทำงาน แผ่นงานชื่อ `Sheet1` ต้องมีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมีพาย, เชื่อมสมุดงาน, แล้วใช้ [setRange](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแมป A1:B4 เป็นหนึ่งซีรีส์และสามหมวด บันทึกผลลัพธ์เป็น `Presentation_with_externalWorkbook.pptx`

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ควบคุมว่าต้องโหลดสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `false` เพียงแค่ปรับปรุงเส้นทางของสมุดงานเท่านั้น แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากสมุดงานเป้าหมาย, ดังนั้นสมุดงานอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปนี้กำหนด URL ตัวอย่างโดยตั้งค่า `updateChartData` เป็น `false` ซึ่งทำให้แผนภูมีพายคงข้อมูลค่าเริ่มต้นและบันทึกการนำเสนอโดยไม่โหลดสมุดงานที่ไม่มีอยู่

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

### **รับเส้นทางของสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุสมุดงานที่เชื่อมโยงกับแผนภูมิ, ก่อนอื่นตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่ หากเป็นเช่นนั้น คุณสามารถดึงเส้นทางสมุดงานได้โดยทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) 
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์
3. ตรวจสอบว่ารูปร่างแรกเป็นแผนภูมิหรือไม่
4. อ่านประเภทของแหล่งข้อมูลแผนภูมิ
5. หากเป็นสมุดงานภายนอก, อ่านเส้นทางของมัน

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างในตัวอย่างก่อนหน้าและตรวจสอบรูปร่างแรกของสไลด์แรก หากเป็นแผนภูมิที่เชื่อมกับสมุดงานภายนอก ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ไปยังคอนโซล แล้วบันทึกสำเนาการนำเสนอเป็น `Result.pptx`

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดงานภายใน หากสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ต้องการ `presentation.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกของสไลด์แรกและสมุดงานภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่สนับสนุนเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกการนำเสนอเป็น `presentation_out.pptx` การแก้ไขค่าของเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้, ดังนั้นควรใช้สำเนาหากต้องการเก็บสมุดงานต้นฉบับไว้

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

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้, Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชไว้ในการนำเสนอได้ สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/), เรียกเมธอด [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), แล้วตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspos e.com/slides/th/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง Java ด้านล่างเปิด `presentation.pptx` โดยรูปร่างแรกของสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิงสมุดงานภายนอกที่ไม่สามารถเข้าถึงได้, แล้วเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

หากสมุดงานภายนอกไม่สามารถเข้าถึงได้และการกู้คืนถูกปิด, Aspose.Slides จะขว้างข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากการอัปเดตการนำเสนอครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถระบุว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่หรือไม่?**

ใช่. แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ; หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่, และเก็บอย่างไร?**

ใช่. หากคุณระบุเส้นทางสัมพันธ์ มันจะถูกแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ การนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่ตั้งอยู่บนเครือข่ายหรือแชร์ได้หรือไม่?**

ได้, สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

การนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) การแก้ไขข้อมูลแผนภูมิที่อิงเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องได้ ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงสภาพเดิม

**ควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่นโดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงกับสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตัวเอง หากทุกแผนภูมิเชื่อมโยงไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิในการโหลดข้อมูลครั้งต่อไป