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
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Android via Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของ worksheet และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แทนค่าข้อมูลที่หายไป ดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/androidjava/chart-series/) เพื่อ了解ความแตกต่างระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแบบเส้นกราฟของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่หรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อนอยู่ การตั้งค่านี้ควบคุมการพล็อตของกราฟ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของ worksheet

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปทรงแรกบนสไลด์แรกของมัน Worksheet ที่ฝังอยู่, `Sheet1`, มีช่วงแหล่งข้อมูลดังต่อไปนี้ `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อนอยู่ แต่เซลล์เหล่านั้นยังคงมีค่า

| แถว Worksheet | A: เดือน | B: ค้าปลีก | C: ค้าส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่าน [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บสมุดงานที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) เมื่อรวมเซลล์ทั้งหมด ให้ใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อคืนช่วงที่สมบูรณ์รวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนแค่แฟล็กไม่เพียงพอที่จะรีเฟรชข้อมูลแคชของตัวอย่างนี้และป้ายกำกับหมวด

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
                // คืนช่วงแหล่งข้อมูลเต็มรวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: หนึ่งเวอร์ชันที่มีเฉพาะค่าค้าปลีกที่มองเห็นได้ (10 และ 20) อีกหนึ่งเวอร์ชันที่มีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพล็อต แถว 3 และคอลัมน์ C ยังคงถูกซ่อนในสมุดงานที่ฝังทั้งสองเวอร์ชัน

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทั้งหมด (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าค้าปลีก 10 และ 20 สำหรับเดือนมกราคมและเดือนมีนาคม.](hidden_cells_True.png) | ![ทั้งหมด: ค่าค้าปลีกและค้าส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนโดยมีค่าแตกต่างจากเซลล์ว่าง [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อนอยู่ ดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/androidjava/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลสมุดงานในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่า worksheet ใดบ้างที่แผนภูมิใช้ วิธี [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) จะคืนค่าช่วงข้อมูลปัจจุบันในรูปสูตรที่อ้างอิง worksheet เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อ worksheet, `!` แยกออกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองเครื่องหมายดอลลาร์บ่งบอกการอ้างอิงแถวและคอลัมน์แบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือสมุดงานของมัน หากแผนภูมิไม่ได้ใช้สมุดงานเป็นแหล่งข้อมูล จะขว้าง `InvalidOperationException` สำหรับข้อมูลเพิ่มเติม ดู [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปทรงโดยตรงในแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อและช่วงแหล่งข้อมูลของแต่ละแผนภูมิ หากแผนภูมิไม่ได้ใช้สมุดงาน จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for Android via Java ให้เมธอด [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) เพื่ออ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งต้นฉบับ

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกของมัน อ่านสมุดงานที่ฝังไว้เข้าสู่ byte array, ลบ series และ categories ที่มีอยู่, แล้วเขียนสมุดงานเดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบเค้าโครงแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังไว้ด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะคง series และ collections ของหมวดไว้ตามเดิม สิ่งไม่ตรงนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ล้าง series และ categories ที่มีอยู่ก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่การแก้ไขสมุดงานจะเกิดขึ้น; ตัวอย่างที่ทำงานได้เขียนสมุดงานเดิมกลับและตรวจสอบเค้าโครงในหน่วยความจำ

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

        // แก้ไขไบต์ของสมุดงานที่นี่, ตัวอย่างเช่น ด้วยการใช้ Aspose.Cells.

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

การล้าง collections จะลบการอ้างอิงข้อมูลเก่าก่อนที่สมุดงานจะถูกเขียนกลับ สร้าง series และการแมปหมวดที่จำเป็นสำหรับสมุดงานที่อัปเดตก่อนใช้แผนภูมิ

## **เลือกวิธีการจัดเก็บป้ายกำกับประเภท**

เรียก [IChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorycollection/#setUseCells-boolean-) บน collection ของหมวดที่ว่างก่อนเพิ่มป้ายกำกับ ใช้เซลล์ worksheet สำหรับป้ายกำกับที่อ้างอิงข้อมูลสมุดงานหรือรูปแบบลำดับขั้น เช่น ไตรมาสที่จัดกลุ่มตามปี ใช้สตริงลิเทอรัลสำหรับป้ายกำกับระดับเดียวที่ไม่ต้องอ้างอิงเซลล์ การตั้งค่านี้ใช้เพียงกับหมวดเท่านั้น แผนภูมิทั้งสองในตัวอย่างใช้เซลล์ worksheet สำหรับค่าตัวเลขของ series

ตัวอย่างสร้างแผนภูมิคอลัมน์สองอันและพิมพ์โหมดการเก็บข้อมูลตามด้วย `Q1 Q2 Q3 Q4` สำหรับแต่ละอัน สำหรับป้ายกำกับที่อ้างอิง worksheet, [IChartCategory.getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getAsCell--) คืนเซลล์พื้นฐานและ [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--) คืนป้ายกำกับนั้น สำหรับป้ายกำกับลิเทอรัล อ่านสตริงโดยตรงด้วย [IChartCategory.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getValue--)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    for (boolean useCells : new boolean[] {true, false}) {
        int x = useCells ? 20 : 360;
        IChart chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250);
        IChartData data = chart.getChartData();
        data.getSeries().clear();
        IChartCategoryCollection categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        IChartDataWorkbook workbook = data.getChartDataWorkbook();
        IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
        IChartSeries series = data.getSeries().add(seriesName, chart.getType());
        for (int row = 1; row <= 4; row++) {
            String label = "Q" + row;
            if (useCells) {
                IChartDataCell labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            IChartDataCell valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        System.out.print("UseCells = " + categories.getUseCells() + ":");
        for (IChartCategory category : categories) {
            Object label = categories.getUseCells() ? category.getAsCell().getValue() : category.getValue();
            System.out.print(" " + label);
        }
        System.out.println();
    }

    presentation.save("category-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กำหนดรูปแบบตัวเลขที่กำหนดเองสำหรับเซลล์สมุดงาน**

ใช้ [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) เพื่อควบคุมวิธีการแสดงค่าตัวเลขในสมุดงานที่ฝังของแผนภูมิ เช่น รายงานอาจต้องการแสดงอัตราแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง เก็บทั้งสองค่าเป็นตัวเลขเพื่อให้ยังคงใช้คำนวณและพล็อตแผนภูมิได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่จัดเก็บ รูปแบบ `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%`; ไม่ได้แทนที่เลขที่จัดเก็บด้วย `12.5` เช่นเดียวกัน `0.00000` จะแสดง `0.1234567` เป็น `0.12346` โดยไม่ปัดเลขที่จัดเก็บ หากรูปแบบที่กำหนดเป็นสตริงว่าง (`""`) จะใช้รูปแบบที่คืนจาก [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) บน worksheet 0, B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าของแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายค่าที่เชื่อมกับรูปแบบแหล่งต้น

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

รูปแบบเซลล์สมุดงานแยกจากรูปแบบที่กำหนดโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายแสดงค่าจากเซลล์แหล่งต้นเพราะ [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ถูกตั้งเป็น `true` และตามรูปแบบตัวเลขของแหล่งต้นเพราะ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) ถูกตั้งเป็น `true` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้รูปแบบตัวเลขของตนเอง กำหนดด้วย [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) เป็น `0.00` พร้อมกับ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) ตั้งเป็น `false`

หากต้องการกำหนดรูปแบบป้ายข้อมูลแยกจากแหล่งต้น ให้ตั้งค่าป้ายให้ไม่เชื่อมกับแหล่ง (`false`) และกำหนดรูปแบบด้วย [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) สิ่งนี้จะไม่เปลี่ยนรูปแบบของเซลล์สมุดงาน ตัวอย่างเช่น รูปแบบป้ายแยก `0.00` จะแสดงค่าแรกเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดู [Chart Data Labels](/slides/th/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) สำหรับการฟอร์แมตป้ายโดยตรง

ภาพต่อไปนี้เร็นเดอร์จากงานนำเสนอที่บันทึกแล้วหลังจากเปิดใหม่:

![แผนภูมิคอลัมน์ที่แสดงป้ายเชื่อมกับแหล่งต้นแสดง 12.5000% และ 0.12346 พร้อมแกนนิ่งที่ฟอร์แมตแยก.](custom-cell-formats.png)

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลเริ่มต้นเป็นรูปทรงแรกบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บน worksheet 0 เป็นป้ายสามรายการแรกของ series แรก, เปิดใช้ป้ายจากเซลล์, แล้วบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการ Worksheet**

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้เข้าถึง worksheet ทั้งหมดในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิเส้นวงกลมที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละ worksheet ไปที่คอนโซล

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

ค่าจุดของ series สามารถเก็บเป็นลิเทอรัลตัวเลขโดยตรงได้ ดู [Set Series Values Using Numeric Literals](/slides/th/androidjava/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างครบถ้วนที่บันทึกและอ่านค่าดังกล่าว ประเภทแหล่งข้อมูลของค่าจุดแยกจากการกำหนดสมุดงานภายในหรือภายนอกของแผนภูมิ; การใช้ลิเทอรัลตัวเลขเองไม่ได้ทำให้สมุดงานที่ฝังหายไป

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3D ที่มีข้อมูลเริ่มต้นและตั้งชื่อ series สองอันโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้ลิเทอรัลสตริง; ชื่อที่สองใช้เซลล์ C1 บน worksheet 0. การตั้งค่า [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) เลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อ series ที่อัปเดต

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังซึ่งไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) เพื่อตรวจพบรูปแบบที่ไม่รองรับและข้ามแผนภูมิที่เกี่ยวข้อง ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปทรงที่ไม่ใช่แผนภูมิและพิมพ์ข้อความตรวจสอบสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่

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

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออกสมุดงานแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิกับสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเส้นวงกลมที่มีข้อมูลเริ่มต้นและส่งออกสมุดงานของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนดสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

### **ตั้งค่าสมุดงานภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเพื่อเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์นั้นย้ายตำแหน่ง)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากกำหนดเส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้สมุดงานภายนอกที่ worksheet ชื่อ `Sheet1` มีชื่อ series ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเส้นวงกลม, เชื่อมสมุดงาน, และใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแมป A1:B4 ไปเป็น series หนึ่งและสามหมวด แล้วบันทึกงานนำเสนอที่มีแผนภูมิเชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ควบคุมว่าจะแบ่งการโหลดสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `false`, จะอัปเดตเฉพาะเส้นทางสมุดงานเท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `true`, ข้อมูลแผนภูมิจะถูกอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้ง `updateChartData` เป็น `false` รักษาข้อมูลเริ่มต้นของแผนภูมิเส้นวงกลมและบันทึกงานนำเสนอโดยไม่โหลดสมุดงานที่ไม่สามารถเข้าถึงได้

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

เพื่อระบุสมุดงานที่เชื่อมกับแผนภูมิ ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางสมุดงานของมัน

ตัวอย่างนี้ตรวจสอบรูปทรงแรกบนสไลด์แรกของงานนำเสนอที่มีสมุดงานภายนอกเชื่อมอยู่ หากเป็นแผนภูมิเชื่อมกับสมุดงานภายนอก ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ไปที่คอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดงานภายใน หากไม่สามารถโหลดสมุดงานภายนอก จะขว้างข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและเชื่อมกับสมุดงานภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อ้างอิงเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 แล้วบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าจากเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมได้ ดังนั้นควรใช้สำเนาหากต้องการเก็บสมุดงานต้นฉบับ

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

หากแผนภูมิเชื่อมกับสมุดงานภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างสมุดงานแผนภูมิใหม่จากข้อมูลที่แคชไว้ในงานนำเสนอ สร้าง [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), แล้วตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Java ต่อไปนี้กู้คืนข้อมูลสมุดงานสำหรับแผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและอ้างอิงสมุดงานภายนอกที่ไม่สามารถเข้าถึงได้ เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

หากสมุดงานภายนอกไม่สามารถเข้าถึงได้และการกู้คืนถูกปิดไว้ Aspose.Slides จะขว้างข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากการอัปเดตงานนำครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่?**

ใช่. แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [เส้นทางไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**เส้นทางสัมพันธ์ไปยังสมุดงานภายนอกได้รับการสนับสนุนหรือไม่, และมันถูกจัดเก็บอย่างไร?**

ใช่. หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอบันทึกเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ใช่, สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอบันทึก [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) การแก้ไขข้อมูลแผนภูมิที่อ้างอิงเซลล์อาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมไว้ ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ถ้าไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่านควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิครั้งต่อไปที่โหลดข้อมูล**