---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอบน Android
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/androidjava/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Android ผ่าน Java: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊กแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิโดยใช้สตรีมของเวิร์กบุ๊ก, ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และกำหนดประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก, ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อมีเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่แสดงข้อมูลที่ขาดหายไป ดูที่ [ควบคุมการแสดงของเซลล์ว่าง](/slides/th/androidjava/chart-series/) เพื่อเปรียบเทียบระหว่างเซลล์ว่างและค่าศูนย์, รวมถึงการเปรียบเทียบรูปแบบการแสดงของเส้นกราฟ

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของกราฟเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีกราฟคอลัมน์เป็นรูปทรงแรกบนสไลด์แรก แผ่นงานที่ฝังอยู่ `Sheet1` มีช่วงข้อมูลต้นฉบับ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ของมันยังคงมีค่าที่อยู่

| แถวของแผ่นงาน | A: เดือน | B: ขายปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์ต้นฉบับผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่านสถานะซ่อนของเซลล์ด้วย [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) วิธีนี้รายงานสถานะซ่อนโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลกราฟหลังจากเปลี่ยนการตั้งค่าการพล็อต: รักษาเวิร์กบุ๊กที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) เมื่อรวมเซลล์ทั้งหมดให้ใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อกู้คืนช่วงเต็มรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าแฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแคชของกราฟและป้ายกำกับหมวดในตัวอย่างนี้

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

            // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊กที่ฝังไว้.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // กู้คืนช่วงต้นฉบับเต็ม รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: หนึ่งเวอร์ชันมีเฉพาะค่าขายปลีกที่มองเห็น (10 และ 20) อีกเวอร์ชันมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการพล็อต แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊กที่ฝังไว้

| เซลล์ที่มองเห็นเท่านั้น (`true`) | ทั้งหมด (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนแต่มีค่าแตกต่างจากเซลล์ว่าง [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นแหล่งข้อมูลที่ซ่อน ดูที่ [ควบคุมการแสดงของเซลล์ว่าง](/slides/th/androidjava/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลเวิร์กบุ๊กในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นฉบับเพื่อระบุว่าแผ่นงานเซลล์ใดที่แต่ละกราฟใช้ วิธี [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) คืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่อ้างอิงถึงแผ่นงาน เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อแผ่นงาน, `!` คั่นกับช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมถึงสัญลักษณ์ `$` บ่งบอกการอ้างอิงแน่นอน

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงกราฟหรือเวิร์กบุ๊ก หากกราฟไม่ได้ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูล จะเกิด `InvalidOperationException` ดูข้อมูลเพิ่มเติมที่ [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปทรงบนแต่ละสไลด์เพื่อหากราฟ พิมพ์ชื่อกราฟและช่วงต้นฉบับ หากกราฟไม่ได้ใช้เวิร์กบุ๊กจะพิมพ์ข้อความแล้วดำเนินการต่อไปยังกราฟถัดไป

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ก**

Aspose.Slides for Android via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูลต้นฉบับ

ตัวอย่างนี้ใช้งานนำเสนอที่มีกราฟเป็นรูปทรงแรกบนสไลด์แรก อ่านเวิร์กบุ๊กที่ฝังไว้เป็นอาเรย์ไบต์, ล้างซีรีส์และหมวดหมู่ที่มีอยู่, แล้วเขียนเวิร์กบุ๊กเดิมกลับไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบเค้าโครงกราฟหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อคุณแทนที่เวิร์กบุ๊กที่ฝังด้วยเวิร์กบุ๊กที่แก้ไขแล้ว, กราฟจะยังคงมีซีรีส์และคอลเลกชันหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาด out-of-range ให้ล้างซีรีส์และหมวดหมู่เดิมก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไป ตัวอย่างใช้กราฟที่เป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์บ่งบอกตำแหน่งที่จะแก้ไขเวิร์กบุ๊ก; ตัวอย่างทำงานเขียนเวิร์กบุ๊กเดิมกลับและตรวจสอบเค้าโครงในหน่วยความจำ

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

        // แก้ไขไบต์ของเวิร์กบุ๊กที่นี่, ตัวอย่างเช่นโดยใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ ให้สร้างซีรีส์และการแมปหมวดหมู่ใหม่ตามเวิร์กบุ๊กที่อัปเดตก่อนใช้กราฟ

## **กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ

ตัวอย่างนี้เพิ่มกราฟบับเบิลพร้อมข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายกำกับสามค่าแรกในซีรีส์แรก เปิดใช้งานป้ายกำกับจากเซลล์ และบันทึกงานนำเสนอที่อัปเดต

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

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้เข้าถึงแผ่นงานในเวิร์กบุ๊กแผนภูมิ ตัวอย่างนี้สร้างกราฟพายพร้อมข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละชื่อลงคอนโซล

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

ตัวอย่างนี้สร้างกราฟคอลัมน์ 3 มิติพร้อมข้อมูลเริ่มต้นและกำหนดชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้สตริงลิตเรัล; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 ตัวนับประเภทแหล่งข้อมูล [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) ระบุแหล่งที่มาสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางกราฟ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) ร่วมกับ枚举 [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามกราฟนั้น ตัวอย่างตรวจสอบรูปทรงบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปทรงที่ไม่ใช่กราฟและพิมพ์ข้อความวินิจฉัยสำหรับแต่ละกราฟที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กแผนภูมิที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลสำหรับกราฟ

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออกเวิร์กบุ๊กแผนภูมิที่ฝังเป็นไฟล์และเชื่อมโยงกราฟกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างกราฟพายพร้อมข้อมูลเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของกราฟ จากนั้นบันทึกงานนำเสนอที่เชื่อมโยง

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

### **กำหนดเวิร์กบุ๊กภายนอก**

ใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับกราฟเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัพเดตเส้นทางของเวิร์กบุ๊กภายนอก (หากมีการย้ายไฟล์)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากกำหนดเส้นทางแบบสัมพันธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่แผ่นงานชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างกราฟพาย, เชื่อมโยงเวิร์กบุ๊ก, และใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแมป A1:B4 ให้เป็นซีรีส์หนึ่งและสามหมวด แล้วบันทึกงานนำเสนอที่มีกราฟเชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ควบคุมว่าจะโหลดเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเพียงเส้นทางเวิร์กบุ๊กเท่านั้น ข้อมูลกราฟจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `true` ข้อมูลกราฟจะอัปเดตจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้งค่า `updateChartData` เป็น `false` คงข้อมูลเริ่มต้นของกราฟพายและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่มีอยู่

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

### **รับเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกของกราฟ**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมโยงกับกราฟ ให้ตรวจสอบว่ากราฟใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางเวิร์กบุ๊กของมัน

ตัวอย่างนี้ตรวจสอบรูปทรงแรกบนสไลด์แรกของงานนำเสนอที่มีเวิร์กบุ๊กภายนอกเชื่อมโยง หากเป็นกราฟที่เชื่อมโยงกับเวิร์กบุ๊กภายนอก ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ไปยังคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

### **แก้ไขข้อมูลกราฟ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของเวิร์กบุ๊กภายใน หากไม่สามารถโหลดเวิร์กบุ๊กภายนอกได้จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้กราฟที่เป็นรูปทรงแรกบนสไลด์แรกและเชื่อมโยงกับเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าแบ็คของเซลล์สำหรับจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าเซลล์อาจอัปเดตไฟล์ XLSX ภายนอก ดังนั้นหากต้องการรักษาเวิร์กบุ๊กต้นฉบับควรใช้สำเนา

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

### **กู้คืนเวิร์กบุ๊กจากแคชของกราฟ**

หากกราฟใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊กกราฟใหม่จากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), และตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Java ต่อไปนี้กู้คืนข้อมูลเวิร์กบุ๊กสำหรับกราฟที่เป็นรูปทรงแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) :

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนที่นี่.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หากเวิร์กบุ๊กภายนอกไม่มีอยู่และการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลกราฟที่แคชเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากการอัปเดตครั้งล่าสุดของงานนำเสนอ

## **FAQ**

**ฉันสามารถกำหนดได้หรือไม่ว่ากราฟเฉพาะเจาะจงเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังอยู่?**

ได้. กราฟมี [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) ; หากเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่ และเก็บอย่างไร?**

รองรับ. หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) การแก้ไขข้อมูลแผนภูมิที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องได้ ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ฉันควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงกับสำเนานั้น

**หลายกราฟสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละกราฟเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียว การอัปเดตไฟล์นั้นจะสะท้อนในทุกกราฟเมื่อลองโหลดข้อมูลครั้งต่อไป