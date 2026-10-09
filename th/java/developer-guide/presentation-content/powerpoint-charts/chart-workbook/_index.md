---
title: จัดการเวิร์กชีตแผนภูมิในการนำเสนอโดยใช้ Java
linktitle: เวิร์กชีตแผนภูมิ
type: docs
weight: 70
url: /th/java/chart-workbook/
keywords:
- เวิร์กชีตแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กชีต
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กชีตภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กชีต
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Java: จัดการเวิร์กชีตแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับหนังสือเวิร์กชีตของแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กชีต, ใช้เซลล์ของเวิร์กชีตเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความนี้ยังครอบคลุมการทำงานกับเวิร์กชีตภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กชีตภายนอก, ดึงเส้นทางของเวิร์กชีตภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อมีเวิร์กชีตพร้อมใช้งาน

สำหรับเซลล์เวิร์กชีตที่เป็นตัวแทนของข้อมูลที่ขาดหาย ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างและค่า ศูนย์, รวมถึงการเปรียบเทียบแบบเส้นกราฟของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อควบคุมว่าชาร์ตจะพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนอยู่หรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อนอยู่ การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปทรงแรกในสไลด์แรก แผ่นงานฝังตัว `Sheet1` มีช่วงแหล่งข้อมูล `A1:C4` โดยแถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่า

| แถวของแผ่นงาน | A: เดือน | B: รายละเอียดการขายปลีก | C: การขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่าน [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) เพื่อสืบตรวจสถานะการซ่อน วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 มองเห็นได้, B3 属於แถวที่ซ่อน, และ C2 属於คอลัมน์ที่ซ่อน; ตัวอย่างจะพิมพ์ค่า `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้, รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บเวิร์กชีตฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อกู้คืนช่วงทั้งหมดรวมถึงหมวดเดือน กุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอสำหรับการรีเฟรชข้อมูลแผนภูมิและป้ายกำกับหมวดของตัวอย่างนี้

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

            // รีเฟรชข้อมูลแผนภูมิจากเวิร์กชีตที่ฝังอยู่.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // คืนค่าช่วงแหล่งข้อมูลทั้งหมด รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: เวอร์ชันหนึ่งมีเฉพาะค่าการขายปลีกที่มองเห็น (`10` และ `20`), อีกเวอร์ชันหนึ่งมีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพล็อต แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กชีตฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทั้งหมด (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมวิธีการแสดงค่าที่ขาดหาย; ไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลเวิร์กชีตในการนำเสนอที่มีอยู่, ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่าแผ่นงานใดบ้างที่แต่ละแผนภูมิใช้ วิธี [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) จะคืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่อ้างอิงแผ่นงาน, เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อแผ่นงาน, `!` แยกจากช่วงเซลล์, `$A$1:$D$5` ระบุเซลล์ตั้งแต่ A1 ถึง D5 รวมทั้งสองค่า เครื่องหมายดอลลาร์บ่งบอกการอ้างอิงแถวและคอลัมน์แบบสัมบูรณ์

วิธีนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือเวิร์กชีตของมัน หากแผนภูมิไม่ได้ใช้เวิร์กชีตเป็นแหล่งข้อมูล, จะเกิดข้อผิดพลาด `InvalidOperationException` ดูรายละเอียดเพิ่มเติมใน [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)

ตัวอย่างนี้เปิดการนำเสนอและตรวจสอบรูปทรงบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อและช่วงแหล่งข้อมูลของแต่ละแผนภูมิ หากแผนภูมิไม่ได้ใช้เวิร์กชีต, จะพิมพ์ข้อความและดำเนินต่อไปยังแผนภูมถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กชีต**

Aspose.Slides for Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ที่ให้คุณอ่านและเขียนเวิร์กชีตข้อมูลแผนภูมิ (ซึ่งประกอบด้วยข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก มันทอดเวิร์กชีตฝังเข้าเป็นอาเรย์ไบต์, ลบชุดข้อมูลและหมวดหมู่เดิม, จากนั้นเขียนเวิร์กชีตเดิมกลับเข้าไป การเปลี่ยนแปลงจะอยู่ในหน่วยความจำ; ตัวอย่างจะไม่บันทึกการนำเสนอ

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

### **ตรวจสอบการจัดวางของแผนภูมิหลังการแก้ไขเวิร์กชีต**

เมื่อคุณแทนที่เวิร์กชีตฝังด้วยเวิร์กชีตที่ถูกแก้ไข, แผนภูมิจะยังคงเก็บคอลเลกชันชุดข้อมูลและหมวดหมู่เดิมไว้ ความไม่ตรงกันนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาดดัชนีเกินช่วง ก่อนเขียนเวิร์กชีตที่อัปเดตกลับไปให้ล้างชุดข้อมูลและหมวดหมู่เดิม ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่การแก้ไขเวิร์กชีตจะเกิดขึ้น; ตัวอย่างที่รันได้จะเขียนเวิร์กชีตเดิมกลับและตรวจสอบการจัดวางในหน่วยความจำ

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

การล้างคอลเลกชันจะเอาการอ้างอิงข้อมูลที่เก่าออกก่อนที่เวิร์กชีตจะถูกเขียนกลับ สร้างชุดข้อมูลและการแม็ปหมวดหมู่ใหม่ตามที่ต้องการสำหรับเวิร์กชีตที่อัปเดตก่อนใช้แผนภูมิ

## **กำหนดเซลล์เวิร์กชีตเป็นป้ายกำกับข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กชีตเป็นป้ายกำกับข้อมูลของแผนภูมิ

ตัวอย่างนี้เพิ่มแผนภูมิบับอากาศ (bubble chart) ที่มีข้อมูลเริ่มต้นบนสไลด์แรกของการนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 ในแผ่นงาน 0 เป็นป้ายกำกับสามค่าแรกของชุดแรก, เปิดใช้งานป้ายกำกับจากเซลล์, แล้วบันทึกการนำเสนอที่อัปเดต

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

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้การเข้าถึงแผ่นงานในเวิร์กชีตของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิเสี้ยวงกลม (pie chart) ที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละชื่อไปยังคอนโซล

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลเริ่มต้นและตั้งชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิเทรัล; ชื่อที่สองใช้เซลล์ C1 ในแผ่นงาน 0 ตัวเลือกจาก enumeration [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) จะกำหนดแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกการนำเสนอพร้อมชื่อชุดข้อมูลที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กชีตฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กชีตไบเนอรี Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของการนำเสนอที่มีอยู่, ข้ามรูปทรงที่ไม่ใช่แผนภูมิ, แล้วพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีเวิร์กชีต .xlsb ฝังอยู่

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

        // อ่านหรือปรับแก้ข้อมูลเวิร์กชีตแผนภูมิที่สนับสนุนที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **เวิร์กชีตภายนอก**

Aspose.Slides รองรับการใช้เวิร์กชีตภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างเวิร์กชีตภายนอก**

ใช้เมธอด [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออกเวิร์กชีตแผนภูมิฝังเป็นไฟล์และเชื่อมแผนภูมิกับเวิร์กชีตภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเสี้ยวงกลมที่มีข้อมูลเริ่มต้นและส่งออกเวิร์กชีตของมัน ตัวอย่างทำการเขียนไฟล์ให้เสร็จก่อนกำหนดเวิร์กชีตภายนอกเป็นแหล่งข้อมูลของแผนภูมิ, จากนั้นบันทึกการนำเสนอที่เชื่อมต่อ

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


### **กำหนดเวิร์กชีตภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนดเวิร์กชีตภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยังเวิร์กชีตภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กชีตที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรอื่นได้, คุณยังคงใช้เวิร์กชีตเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากกำหนดเส้นทางแบบสัมพัทธ์สำหรับเวิร์กชีตภายนอก, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กชีตภายนอกที่มีแผ่นงานชื่อ `Sheet1` ซึ่งมีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเสี้ยวงกลม, เชื่อมต่อเวิร์กชีต, และใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแม็ป A1:B4 เป็นชุดข้อมูลหนึ่งและสามหมวดหมู่ แล้วบันทึกการนำเสนอที่เชื่อมแผนภูมิ

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

พารามิเตอร์ `updateChartData` ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ควบคุมว่าจะโหลดเวิร์กชีตหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเพียงเส้นทางของเวิร์กชีตเท่านั้น แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากเวิร์กชีตเป้าหมาย, ดังนั้นเวิร์กชีตอาจไม่สามารถเข้าถึงได้
* เมื่อ `updateChartData` เป็น `true` แผนภูมิจะอัปเดตข้อมูลจากเวิร์กชีตเป้าหมาย

ตัวอย่างต่อไปนี้กำหนด URL ตัวอย่างพร้อม `updateChartData` เป็น `false` จะรักษาข้อมูลเริ่มต้นของแผนภูมิเสี้ยวงกลมและบันทึกการนำเสนอโดยไม่โหลดเวิร์กชีตที่ไม่ได้อยู่

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

### **ดึงเส้นทางของเวิร์กชีตแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุเวิร์กชีตที่เชื่อมกับแผนภูมิ, ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางเวิร์กชีตของมัน

ตัวอย่างนี้ตรวจสอบรูปทรงแรกบนสไลด์แรกของการนำเสนอที่มีเวิร์กชีตภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมกับเวิร์กชีตภายนอก, ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ไปยังคอนโซล แล้วบันทึกสำเนาการนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในเวิร์กชีตภายนอกได้เช่นเดียวกับที่ทำกับเวิร์กชีตภายใน หากเวิร์กชีตภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและเชื่อมกับเวิร์กชีตภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่มาจากเซลล์ของจุดข้อมูลแรกในชุดแรกเป็น `100` แล้วบันทึกการนำเสนอที่อัปเดต การแก้ไขค่าเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมได้, ดังนั้นควรใช้สำเนาหากต้องการรักษาเวิร์กชีตดั้งเดิม

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

### **กู้คืนเวิร์กชีตจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กชีตภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้, Aspose.Slides สามารถสร้างเวิร์กชีตแผนภูมิกลับจากข้อมูลที่แคชไว้ในไฟล์การนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), และตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง Java ด้านล่างกู้คืนข้อมูลเวิร์กชีตสำหรับแผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและอ้างอิงเวิร์กชีตภายนอกที่ไม่พร้อมใช้งาน เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

หากเวิร์กชีตภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับเวิร์กชีตภายนอกหลังจากการนำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิกำหนดลิงก์ไปยังเวิร์กชีตภายนอกหรือเวิร์กชีตฝัง?**

ได้. แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) และ [เส้นทางไปยังเวิร์กชีตภายนอก](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); หากแหล่งเป็นเวิร์กชีตภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยังเวิร์กชีตภายนอกหรือไม่, และจัดเก็บอย่างไร?**

รองรับ. หากระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ การนำเสนอจะจัดเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้ายเวิร์กชีตอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กชีตที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, เวิร์กชีตเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไขเวิร์กชีตระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

การนำเสนอจะจัดเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). การแก้ไขข้อมูลแผนภูมิที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องที่เชื่อมต่อ ใช้สำเนาเวิร์กชีตหากต้องการให้ไฟล์ต้นฉบับคงที่

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน จะทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือจัดเตรียมสำเนาที่ถอดรหัส (เช่น โดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กชีตภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อโหลดข้อมูลใหม่ครั้งต่อไป