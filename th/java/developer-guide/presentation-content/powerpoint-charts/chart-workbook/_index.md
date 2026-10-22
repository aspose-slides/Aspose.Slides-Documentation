---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอด้วย Java
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/java/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Java: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับ workbook ของแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีม workbook, ใช้เซลล์ของ workbook เป็นป้ายข้อมูลของแผนภูมิ, เข้าถึงคอลเลกชันของ worksheet, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีการสร้างและกำหนด workbook ภายนอก, ดึงเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook สามารถใช้ได้

สำหรับเซลล์ workbook ที่เป็นตัวแทนของข้อมูลที่หายไป ดูที่ [ควบคุมการแสดงเซลล์ที่ว่าง](/slides/th/java/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างและศูนย์, รวมถึงการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงที่มีให้

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อควบคุมว่าตารางแผนภูมิจะแสดงข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อแสดงเฉพาะเซลล์ที่มองเห็น, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการวาดแผนภูมิ; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของ worksheet

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรก worksheet ที่ฝังอยู่, `Sheet1`, มีช่วงข้อมูลต้นฉบับดังต่อไปนี้ `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ยังคงมีค่าอยู่

| แถว Worksheet | A: เดือน | B: ขายปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นฉบับผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่าน [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) เพื่อพิจารณาสถานะการซ่อนของพวกมัน วิธีนี้รายงานสถานะโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็น, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดงผล `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้, รีเฟรชข้อมูลแผนภูมหลังจากเปลี่ยนการตั้งค่าการวาด: เก็บ workbook ที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) แล้วโหลดกลับด้วย [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อคืนช่วงเต็มรวมถึงหมวดฟีบรรีเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าธงเพียงอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิที่แคชและป้ายกำกับหมวดของตัวอย่างนี้

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
                // คืนช่วงต้นฉบับทั้งหมด รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกเวอร์ชันสองแบบของงานนำเสนอ: หนึ่งแบบมีเฉพาะค่าขายปลีกที่มองเห็น (10 และ 20) และอีกแบบมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการวาด แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ใน workbook ที่ฝังทั้งสอง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าขายปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าขายปลีกและขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าเป็นสิ่งต่างจากเซลล์ว่าง [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดูที่ [ควบคุมการแสดงเซลล์ที่ว่าง](/slides/th/java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูล workbook ในงานนำเสนอที่มีอยู่, ตรวจสอบช่วงต้นฉบับเพื่อระบุว่า worksheet ใดที่แต่ละแผนภูมิใช้ วิธี [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) จะคืนช่วงข้อมูลปัจจุบันในรูปแบบสูตรที่ระบุ worksheet, เช่น `Sheet1!$A$1:$D$5`. ที่นี่ `Sheet1` คือชื่อ worksheet, `!` คั่นจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวม เครื่องหมายดอลลาร์บ่งบอกอ้างอิงแถวและคอลัมน์แบบคงที่

วิธีนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือ workbook ของมัน หากแผนภูมิไม่ได้ใช้ workbook เป็นแหล่งข้อมูล, จะโยน `InvalidOperationException` สำหรับข้อมูลเพิ่มเติม ดูที่ [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างโดยตรงบนแต่ละสไลด์สำหรับแผนภูมิ แสดงชื่อแต่ละแผนภูมิและช่วงต้นฉบับ หากแผนภูมิไม่ได้ใช้ workbook, จะแสดงข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides for Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ที่ทำให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **Note** ข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับต้นฉบับ

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่าน workbook ที่ฝังเป็นอาร์เรย์ไบต์, ลบ series และ category ที่มีอยู่, แล้วเขียน workbook เดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังด้วยเวอร์ชันที่แก้ไข, แผนภูมิจะยังคง series และ collection ของ category เดิม ความไม่ตรงกันนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาดดัชนีเกินช่วง ลบ series และ category ที่มีอยู่ก่อนเขียน workbook ที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์บ่งชี้ตำแหน่งที่การแก้ไข workbook จะเกิดขึ้น; ตัวอย่างที่ทำงานได้เขียน workbook ดั้งเดิมกลับไปและตรวจสอบโครงสร้างในหน่วยความจำ

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

        // แก้ไขไบต์ของเวิร์กบุ๊กที่นี่, ตัวอย่างเช่น, ใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะเอาการอ้างอิงข้อมูลที่ล้าสมัยออกก่อนที่ workbook จะถูกเขียนกลับ สร้าง series และการแมป category ที่จำเป็นสำหรับ workbook ที่อัปเดตก่อนใช้แผนภูมิ

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์ Workbook**

ใช้ [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) เพื่อควบคุมวิธีการแสดงค่าตัวเลขใน workbook ที่ฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราการแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง เก็บค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและการวาดแผนภูมิได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ใช่ค่าที่เก็บไว้ รูปแบบ `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%`; มันไม่แทนที่ตัวเลขที่เก็บด้วย `12.5` เช่นเดียวกัน `0.00000` จะทำให้ `0.1234567` แสดงเป็น `0.12346` โดยไม่ทำการปัดเศษค่าที่เก็บไว้ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้รูปแบบที่คืนจาก [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) บน worksheet 0, B2 มีอัตราการแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าแผนภูมิ ตัวอย่างยังเปิดใช้ป้ายค่าที่เชื่อมโยงกับรูปแบบต้นทาง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

รูปแบบเซลล์ workbook แยกจากรูปแบบที่ตั้งโดยตรงบนแกนแผนภูมิหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายจะแสดงค่าจากเซลล์ต้นทางเพราะ [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ตั้งเป็น `true` และตามรูปแบบตัวเลขต้นทางเพราะ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) ตั้งเป็น `true` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้รูปแบบตัวเลขของตนเองที่กำหนดด้วย [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) เป็น `0.00` และ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) ตั้งเป็น `false`

หากต้องการฟอร์แมตป้ายข้อมูลโดยอิสระ ตั้งค่าธงเชื่อมต่อกับต้นทางเป็น `false` แล้วกำหนดรูปแบบด้วย [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) วิธีนี้ไม่ได้เปลี่ยนรูปแบบของเซลล์ workbook ตัวอย่างเช่นรูปแบบป้ายอิสระ `0.00` จะแสดงค่าตัวแรกเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการฟอร์แมตป้ายโดยตรง

ภาพด้านล่างเรนเดอร์จากงานนำเสนอที่บันทึกแล้วและเปิดใหม่:

![แผนภูมิคอลัมน์พร้อมป้ายที่เชื่อมโยงกับต้นทางแสดง 12.5000% และ 0.12346 พร้อมแกนจำนวนที่ฟอร์แมตโดยอิสระ.](custom-cell-formats.png)

## **ตั้งค่า Workbook Cell เป็นป้ายข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ workbook เป็นป้ายข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับกับข้อมูลเริ่มต้นเป็นรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บน worksheet 0 สำหรับป้ายสามอันแรกใน series แรก เปิดใช้ป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการ Worksheets**

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้เข้าถึง worksheets ใน workbook ของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิวงกลมด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละ worksheet ไปยังคอนโซล

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

ค่าจุดของ series สามารถเก็บเป็นตัวเลขโดยตรงได้ ดูที่ [Set Series Values Using Numeric Literals](/slides/th/java/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างครบถ้วนที่บันทึกและอ่านค่าเหล่านั้น ประเภทแหล่งข้อมูลของค่าจุดแยกจากการกำหนด workbook ภายในหรือภายนอกของแผนภูมิ; การใช้ตัวเลขโดยตรงไม่ได้ลบ workbook ที่ฝังอยู่โดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและตั้งชื่อ series สองอันโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้สตริงลิเทรัล; ชื่อที่สองใช้เซลล์ C1 บน worksheet 0 นิพจน์ [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) กำหนดแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อ series ที่อัปเดต

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

## **ตรวจจับรูปแบบ Workbook ที่ฝังไม่ได้รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ workbook Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) ร่วมกับ enum [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิที่เกี่ยวข้อง ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่, ข้ามรูปร่างที่ไม่ใช่แผนภูมิ, และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มี workbook .xlsb ฝังอยู่

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

        // อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **Workbook ภายนอก**

Aspose.Slides รองรับการใช้ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้าง Workbook ภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออก workbook ของแผนภูมิที่ฝังไปเป็นไฟล์และเชื่อมแผนภูมิกับ workbook ภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวลีด้วยข้อมูลเริ่มต้นและส่งออก workbook ของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนด workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

### **กำหนด Workbook ภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลใน workbook ที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังคงใช้ workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้เส้นทางสัมพันธ์สำหรับ workbook ภายนอก, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้ workbook ภายนอกที่ worksheet ชื่อ `Sheet1` มีชื่อ series ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิวลี, เชื่อม workbook, และใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแมพ A1:B4 ไปยัง series หนึ่งและสามหมวด แล้วบันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ควบคุมว่าจะแสดงข้อมูลจาก workbook หรือไม่

* เมื่อ `updateChartData` เป็น `false`, จะอัปเดตเฉพาะเส้นทางของ workbook เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook ปลายทาง, ดังนั้น workbook สามารถไม่พร้อมใช้งานได้
* عندما `updateChartData` เป็น `true`, ข้อมูลแผนภูมิจะอัปเดตจาก workbook ปลายทาง

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม `updateChartData` เป็น `false` คงข้อมูลเริ่มต้นของแผนภูมิวลีและบันทึกงานนำเสนอโดยไม่โหลด workbook ที่ไม่พร้อมใช้งาน

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

### **รับเส้นทาง Workbook ของแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุ workbook ที่เชื่อมกับแผนภูมิ, ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางของ workbook นั้น

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มี workbook ภายนอกเชื่อม หากเป็นแผนภูมิที่เชื่อมกับ workbook ภายนอก, ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ไปยังคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาใน workbook ภายใน เมื่อ workbook ภายนอกไม่สามารถโหลดได้, จะขว้างข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับ workbook ภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่รองรับเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นควรใช้สำเนาหากต้องการเก็บ workbook ดั้งเดิมไว้

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

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิใช้ workbook ภายนอกที่หายไปหรือไม่พร้อมใช้งาน, Aspose.Slides สามารถสร้าง workbook ของแผนภูมิจากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), และตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Java ต่อไปกู้คืนข้อมูล workbook สำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิง workbook ภายนอกที่ไม่พร้อมใช้งาน เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หาก workbook ภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะขว้างข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับ workbook ภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **FAQ**

**ฉันจะระบุได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับ workbook ภายนอกหรือที่ฝังอยู่?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); หากแหล่งเป็น workbook ภายนอก, คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่าใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยัง workbook ภายนอกหรือไม่, และเก็บอย่างไร?**

ได้. หากคุณระบุเส้นทางสัมพันธ์, ระบบจะเปลี่ยนเป็นเส้นทางแบบเต็มโดยอัตโนมัติ งานนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้าย workbook อาจต้องอัปเดตลิงก์

**ฉันสามารถใช้ workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, workbook เหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม, การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) การแก้ไขข้อมูลแผนภูมิกับเซลล์อาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยง ใช้สำเนาของ workbook หากต้องการให้ไฟล์ต้นฉบับคงอยู่โดยไม่มีการเปลี่ยนแปลง

**จะทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถูกถอดรหัส (เช่นโดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงกับสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน, การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิเมื่อต่อไปเมื่อโหลดข้อมูล**