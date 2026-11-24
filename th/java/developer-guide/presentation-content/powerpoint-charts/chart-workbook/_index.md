---
title: จัดการหนังสือเวิร์กชีตของแผนภูมิในงานนำเสนอด้วย Java
linktitle: หนังสือเวิร์กชีตแผนภูมิ
type: docs
weight: 70
url: /th/java/chart-workbook/
keywords:
- หนังสือเวิร์กชีตแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์หนังสือเวิร์กชีต
- ป้ายข้อมูล
- ชีตงาน
- แหล่งข้อมูล
- หนังสือเวิร์กชีตภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนหนังสือเวิร์กชีต
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Java: จัดการหนังสือเวิร์กชีตของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณให้เป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับหนังสือเวิร์กชีตของแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของหนังสือเวิร์กชีต ใช้เซลล์ของหนังสือเวิร์กชีตเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของชีตงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

ยังครอบคลุมการทำงานกับหนังสือเวิร์กชีตภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดหนังสือเวิร์กชีตภายนอก ดึงเส้นทางของหนังสือเวิร์กชีตภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อหนังสือเวิร์กชีตพร้อมใช้งาน

สำหรับเซลล์หนังสือเวิร์กชีตที่แทนค่าที่หายไป ดูที่ [ควบคุมการแสดงเซลล์ที่ว่าง](/slides/th/java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อควบคุมว่แผนภูมิจะแสดงข้อมูลจากแถวและคอลัมน์ของชีตที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อแสดงเฉพาะเซลล์ที่มองเห็น หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและซ่อน การตั้งค่านี้ควบคุมการวาดแผนภูมิ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของชีต

[presentation ตัวอย่าง](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรกของไฟล์ ชีตที่ฝังอยู่ `Sheet1` มีช่วงแหล่งข้อมูล `A1:C4` แถว 3 และคอลัมน์ C ถูกซ่อนไว้ แต่เซลล์ยังคงมีค่า

| แถวของชีต | A: เดือน | B: รายละเอียดการขายปลีก | C: รายละเอียดการขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (แถวที่ซ่อน) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่าน [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) เพื่อสอบถามสถานะการซ่อน วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการวาด: รักษาหนังสือเวิร์กชีตที่ฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อกู้คืนช่วงเต็ม รวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิที่แคชไว้และป้ายกำกับหมวดหมู่ในตัวอย่างนี้

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

            // รีเฟรชข้อมูลแผนภูมิจากหนังสือเวิร์กชีตที่ฝังอยู่.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // กู้คืนช่วงแหล่งข้อมูลเต็มรวมถึงหมวดหมู่ที่ซ่อนอยู่.
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

ตัวอย่างจะบันทึกสองเวอร์ชันของงานนำเสนอ: เวอร์ชันแรกมีเฉพาะค่าปลีกที่มองเห็นได้ (10 และ 20) และอีกเวอร์ชันมีค่าทั้งหก ค่าในภาพต่อไปแสดงสองโหมดการวาด แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองหนังสือเวิร์กชีตที่ฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทั้งหมด (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทั้งหมด: ค่าปลีกและค่าขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมการแสดงค่าที่หายไป; ไม่ได้รวมหรือตัดข้อมูลแหล่งที่มาที่ซ่อนอยู่ ดูที่ [ควบคุมการแสดงเซลล์ที่ว่าง](/slides/th/java/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลหนังสือเวิร์กชีตในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงข้อมูลแหล่งที่มาเพื่อระบุว่าแต่ละแผนภูมิใช้เซลล์ชีตใด [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) คืนค่าช่วงข้อมูลปัจจุบันในรูปแบบสูตรที่อ้างอิงชีต เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อชีต, `!` แยกระหว่างชื่อชีตและช่วงเซลล์, `$A$1:$D$5` ระบุเซลล์จาก A1 ถึง D5 รวมด้วย เครื่องหมายดอลลาร์บ่งชี้การอ้างอิงแบบสัมบูรณ์ของแถวและคอลัมน์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือหนังสือเวิร์กชีต หากแผนภูมิไม่ได้ใช้หนังสือเวิร์กชีตเป็นแหล่งข้อมูล จะโยน `InvalidOperationException` ดูข้อมูลเพิ่มเติมที่ [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อหาว่าเป็นแผนภูมิหรือไม่ พิมพ์ชื่อแผนภูมิและช่วงแหล่งที่มาของแต่ละอัน หากแผนภูมิไม่ได้ใช้หนังสือเวิร์กชีต จะพิมพ์ข้อความและดำเนินการต่อกับแผนภูมิถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจากหนังสือเวิร์กชีต**

Aspose.Slides for Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ที่ช่วยให้คุณอ่านและเขียนหนังสือเวิร์กชีตของข้อมูลแผนภูมิ (ที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งที่มา

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่านหนังสือเวิร์กชีตที่ฝังไว้เป็นอาเรย์ไบต์, ลบซีรีส์และหมวดหมู่เดิม, แล้วเขียนหนังสือเวิร์กชีตเดียวกันกลับไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขหนังสือเวิร์กชีต**

เมื่อคุณแทนที่หนังสือเวิร์กชีตที่ฝังไว้ด้วยเวิร์กชีตที่แก้ไขแล้ว แผนภูมิอาจยังคงเก็บคอลเลกชันซีรีส์และหมวดหมู่เดิม ซึ่งทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) เกิดข้อผิดพลาด “index‑out‑of‑range” ให้ล้างซีรีส์และหมวดหมู่เดิมก่อนเขียนเวิร์กชีตที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์ชี้ที่จุดที่ควรแก้ไขหนังสือเวิร์กชีต; ตัวอย่างที่ทำงานได้เขียนหนังสือเวิร์กชีตเดิมกลับและตรวจสอบโครงสร้างในหน่วยความจำ

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

        // แก้ไขไบต์ของหนังสือเวิร์กชีตที่นี่, ตัวอย่างเช่นโดยใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนที่หนังสือเวิร์กชีตจะถูกเขียนกลับ สร้างแมพปิ้งของซีรีส์และหมวดหมู่ใหม่ตามเวิร์กชีตที่อัปเดตก่อนใช้แผนภูมิ

## **เลือกวิธีการจัดเก็บป้ายกำกับหมวดหมู่**

เรียก [IChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorycollection/#setUseCells-boolean-) บนคอลเลกชันหมวดหมู่ที่ว่างเปล่าก่อนเพิ่มป้ายกำกับ ใช้เซลล์ชีตสำหรับป้ายกำกับที่อ้างอิงข้อมูลจากเวิร์กชีตหรือมีลำดับชั้น เช่น ไตรมาสที่จัดกลุ่มตามปี ใช้สตริงลิเทอรัลสำหรับระดับเดียวที่ไม่ต้องอ้างอิงเซลล์ การตั้งค้านี้ใช้ได้เฉพาะกับหมวดหมู่ ทั้งสองแผนภูมิในตัวอย่างใช้เซลล์ชีตสำหรับค่าซีรีส์เชิงตัวเลข

ตัวอย่างสร้างแผนภูมิคอลัมน์สองอันและพิมพ์โหมดการจัดเก็บตามด้วย `Q1 Q2 Q3 Q4` สำหรับแต่ละอัน สำหรับป้ายกำกับที่อิงชีต, [IChartCategory.getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/#getAsCell--) คืนค่าเซลล์พื้นฐานและ [IChartDataCell.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getValue--) คืนป้ายกำกับ สำหรับป้ายกำกับลิเทอรัล ให้อ่านสตริงโดยตรงด้วย [IChartCategory.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/#getValue--)

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

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์หนังสือเวิร์กชีต**

ใช้ [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) เพื่อควบคุมวิธีแสดงค่าตัวเลขในหนังสือเวิร์กชีตที่ฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง ค่าทั้งสองควรเป็นตัวเลขเพื่อให้ยังคงใช้คำนวณและวาดแผนภูมิได้

รูปแบบตัวเลขเป็นการเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่จัดเก็บ รูปแบบ `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%`; ไม่ได้แทนที่ตัวเลขที่จัดเก็บเป็น `12.5` เช่นเดียวกัน `0.00000` จะทำให้ `0.1234567` แสดงเป็น `0.12346` โดยไม่ปัดเศษค่าที่จัดเก็บ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) ระบบจะใช้รูปแบบที่คืนจาก [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--)

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) บนชีตที่ 0 B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ เซลล์ทั้งสองเป็นแหล่งค่าของแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายค่าที่เชื่อมโยงกับรูปแบบแหล่งข้อมูล

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

รูปแบบเซลล์หนังสือเวิร์กชีตแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้ ป้ายแต่ละอันแสดงค่าจากเซลล์แหล่งที่มาด้วยการตั้ง [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) เป็น `true` และต่อด้วยรูปแบบตัวเลขของแหล่งด้วยการตั้ง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) เป็น `true` หลังจากบันทึกและเปิดไฟล์ใหม่ ป้ายแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้รูปแบบตัวเลขของตัวเอง กำหนดด้วย [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) เป็น `0.00` พร้อมตั้ง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) เป็น `false`

หากต้องการฟอร์แมตป้ายข้อมูลโดยอิสระ ให้ตั้งค่าสถานะเชื่อมต่อแหล่งเป็น `false` และกำหนดรูปแบบด้วย [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) วิธีนี้ไม่ได้เปลี่ยนรูปแบบของเซลล์หนังสือเวิร์กชีต ตัวอย่างเช่น รูปแบบป้ายอิสระ `0.00` จะทำให้ค่าที่หนึ่งแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) เพื่อฟอร์แมตป้ายโดยตรง

ภาพด้านล่างได้จากการเรนเดอร์งานนำเสนอที่บันทึกแล้วหลังจากเปิดไฟล์ใหม่:

![แผนภูมิคอลัมน์ที่มีป้ายเชื่อมกับแหล่งแสดง 12.5000% และ 0.12346 พร้อมแกนตัวเลขที่ฟอร์แมตอิสระ.](custom-cell-formats.png)

## **กำหนดเซลล์หนังสือเวิร์กชีตเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์หนังสือเวิร์กชีตเป็นป้ายข้อมูลแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิฟองน้ำพร้อมข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนชีตที่ 0 เป็นป้ายสามอันแรกของซีรีส์แรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการชีตงาน**

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้เข้าถึงชีตงานในหนังสือเวิร์กชีตของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายพร้อมข้อมูลเริ่มต้นและพิมพ์ชื่อชีตแต่ละอันบนคอนโซล

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

ค่าจุดของซีรีส์สามารถเก็บเป็นลิเทอรัลตัวเลขโดยตรง ดูที่ [Set Series Values Using Numeric Literals](/slides/th/java/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างสมบัติที่บันทึกและอ่านค่า ประเภทแหล่งของค่าจุดแยกจากการตั้งค่าหนังสือเวิร์กชีตภายในหรือภายนอกของแผนภูมิ; การใช้ลิเทอรัลตัวเลขเองไม่ได้ทำให้หนังสือเวิร์กชีตที่ฝังหายไป

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติพร้อมข้อมูลเริ่มต้นและตั้งชื่อซีรีส์สองชื่อด้วยแหล่งข้อมูลต่างกัน ชื่อแรกใช้ลิเทอรัลสตริง; ชื่อที่สองใช้เซลล์ C1 บนชีตที่ 0 ตัวนับ [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) เลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบหนังสือเวิร์กชีตที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบหนังสือเวิร์กชีตไบนารี Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) ร่วมกับตัวเลือก [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่สนับสนุนและข้ามแผนภูมิที่เกี่ยวข้อง ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิและพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีหนังสือเวิร์กชีต .xlsb ฝังอยู่

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

        // อ่านหรือแก้ไขข้อมูลหนังสือเวิร์กชีตของแผนภูมิที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **หนังสือเวิร์กชีตภายนอก**

Aspose.Slides รองรับการใช้หนังสือเวิร์กชีตภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างหนังสือเวิร์กชีตภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออกหนังสือเวิร์กชีตแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิกับหนังสือเวิร์กชีตภายนอก

ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้นและส่งออกหนังสือเวิร์กชีตของมัน เสร็จสิ้นการเขียนไฟล์ก่อนกำหนดหนังสือเวิร์กชีตภายนอกเป็นแหล่งข้อมูลของแผนภูมิแล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

### **กำหนดหนังสือเวิร์กชีตภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนดหนังสือเวิร์กชีตภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยังหนังสือเวิร์กชีตภายนอก (หากไฟล์นั้นถูกย้าย)

แม้คุณจะไม่สามารถแก้ไขข้อมูลในหนังสือเวิร์กชีตที่จัดเก็บในตำแหน่งระยะไกลหรือแหล่งทรัพยากรได้ แต่ยังคงใช้หนังสือเวิร์กชีตเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับหนังสือเวิร์กชีตภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้หนังสือเวิร์กชีตภายนอกที่ชีตชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิพาย, เชื่อมหนังสือเวิร์กชีต, และใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแมพ A1:B4 ไปยังซีรีส์หนึ่งและหมวดหมู่สามรายการ แล้วบันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) ควบคุมว่าหนังสือเวิร์กชีตจะถูกโหลดหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะเส้นทางของหนังสือเวิร์กชีตเท่านั้น แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากหนังสือเวิร์กชีตเป้าหมาย ดังนั้นหนังสือเวิร์กชีตอาจไม่พร้อมใช้งาน
* เมื่อ `updateChartData` เป็น `true` แผนภูมิจะอัปเดตข้อมูลจากหนังสือเวิร์กชีตเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนโดยตั้ง `updateChartData` เป็น `false` จะคงข้อมูลเริ่มต้นของแผนภูมิพายและบันทึกงานนำเสนอโดยไม่โหลดหนังสือเวิร์กชีตที่ไม่มีอยู่

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

### **ดึงเส้นทางของหนังสือเวิร์กชีตแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุหนังสือเวิร์กชีตที่เชื่อมโยงกับแผนภูมิ ตรวจสอบว่แผนภูมิกำลังใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางของหนังสือเวิร์กชีตนั้น

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่เชื่อมกับหนังสือเวิร์กชีตภายนอก หากเป็นแผนภูมิที่เชื่อมกับหนังสือเวิร์กชีตภายนอก ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ไปยังคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในหนังสือเวิร์กชีตภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงข้อมูลในหนังสือเวิร์กชีตภายใน หากไม่สามารถโหลดหนังสือเวิร์กชีตภายนอก ระบบจะโยนข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับหนังสือเวิร์กชีตภายนอกที่สามารถเข้าถึงได้ ตั้งค่าค่าที่อิงเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าจากเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นให้ใช้สำเนา หากต้องการเก็บหนังสือเวิร์กชีตต้นฉบับ

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

### **กู้คืนหนังสือเวิร์กชีตจากแคชของแผนภูมิ**

หากแผนภูมิใช้หนังสือเวิร์กชีตภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างหนังสือเวิร์กชีตของแผนภูมิจากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) และตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Java ด้านล่างกู้คืนข้อมูลหนังสือเวิร์กชีตสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงหนังสือเวิร์กชีตภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // อ่านหรือแก้ไขข้อมูลหนังสือเวิร์กชีตที่กู้คืนที่นี่.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

หากหนังสือเวิร์กชีตภายนอกไม่ได้ใช้งานและการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในหนังสือเวิร์กชีตภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **FAQ**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับหนังสือเวิร์กชีตภายนอกหรือที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) และ [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) หากแหล่งเป็นหนังสือเวิร์กชีตภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่าไฟล์ภายนอกถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยังหนังสือเวิร์กชีตภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ใช่ หากระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายหนังสือเวิร์กชีตอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้หนังสือเวิร์กชีตที่อยู่บนเครือข่าย/แชร์ได้หรือไม่?**

ใช่ หนังสือเวิร์กชีตเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม Aspose.Slides ไม่รองรับการแก้ไขหนังสือเวิร์กชีตระยะไกลโดยตรง – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) การแก้ไขข้อมูลแผนภูมิที่อิงเซลล์สามารถอัปเดตไฟล์ XLSX ภายในเครื่องที่เชื่อมโยงได้ ใช้สำเนาของหนังสือเวิร์กชีตหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ควรทำอย่างไรหากไฟล์ภายนอกได้รับการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ แนะนำให้ลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงหนังสือเวิร์กชีตภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อข้อมูลถูกโหลดครั้งต่อไป