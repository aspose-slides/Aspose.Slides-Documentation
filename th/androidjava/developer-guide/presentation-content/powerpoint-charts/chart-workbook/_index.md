---
title: จัดการเวิร์กบุ๊กชาร์ตในงานนำเสนอบน Android
linktitle: เวิร์กบุ๊กชาร์ต
type: docs
weight: 70
url: /th/androidjava/chart-workbook/
keywords:
- เวิร์กบุ๊กชาร์ต
- ข้อมูลชาร์ต
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- ชีตงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชชาร์ต
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Android ผ่าน Java: จัดการเวิร์กบุ๊กชาร์ตในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับชาร์ตเวิร์กบุ๊กใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลชาร์ตผ่านสตรีมของเวิร์กบุ๊ก, ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายข้อมูลของชาร์ต, เข้าถึงคอลเลกชันของชีต, และระบุประเภทแหล่งข้อมูลสำหรับค่าชาร์ต

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก, ดึงพาธของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับชาร์ต, และแก้ไขข้อมูลชาร์ตเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่แทนค่าที่หายไป โปรดดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/androidjava/chart-series/) เพื่อเปรียบเทียบระหว่างเซลล์ว่างและศูนย์, รวมถึงการเปรียบเทียบแบบกราฟเส้นของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) เพื่อควบคุมว่าชาร์ตจะพล็อตข้อมูลจากแถวและคอลัมน์ของชีตที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้, หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้มีผลต่อการพล็อตของชาร์ต; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของชีต

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปแบบแรกบนสไลด์แรกของมัน ชีตฝังอยู่ `Sheet1` มีช่วงแหล่งข้อมูล `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ยังคงมีค่าภายใน

| แถวของชีต | A: เดือน | B: รายละเอียดการขายปลีก | C: รายละเอียดการขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) และอ่าน [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) เพื่อตรวจสอบสถานะการซ่อน วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 แสดงเป็นมองเห็น, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดง `false`, `true`, และ `true` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลชาร์ตหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บเวิร์กบุ๊กฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) เมื่อรวมทุกเซลล์, ใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อคืนค่าช่วงที่สมบูรณ์รวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนแค่แฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลชาร์ตที่แคชและป้ายหมวดของตัวอย่างนี้

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

            // รีเฟรชข้อมูลชาร์ตจากเวิร์กบุ๊กที่ฝังไว้.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // กู้คืนช่วงต้นทางทั้งหมดรวมถึงหมวดหมู่ที่ซ่อนอยู่.
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

ตัวอย่างจะบันทึกสองเวอร์ชันของงานนำเสนอ: เวอร์ชันที่มีเพียงค่าการขายปลีกที่มองเห็น (`true`) ได้แก่ 10 และ 20, และอีกเวอร์ชันที่มีค่าทั้งหมดหกค่า รูปภาพด้านล่างแสดงสองโหมดการพล็อต แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊กฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าการขายปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าการขายปลีกและการขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือกำจัดข้อมูลต้นทางที่ซ่อน ดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/androidjava/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของชาร์ต**

ก่อนที่จะอัปเดตข้อมูลเวิร์กบุ๊กในงานนำเสนอที่มีอยู่, ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่าแต่ละชาร์ตใช้เซลล์ของชีตใด [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) จะคืนค่าช่วงข้อมูลปัจจุบันในรูปแบบสูตรที่อ้างอิงชีต เช่น `Sheet1!$A$1:$D$5`. ที่นี่ `Sheet1` คือชื่อชีต, `!` คั่นระหว่างชื่อและช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองค่า เครื่องหมายดอลลาร์บ่งบอกการอ้างอิงคงที่ของแถวและคอลัมน์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงชาร์ตหรือเวิร์กบุ๊กของมัน หากชาร์ตไม่ได้ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูล จะเกิดข้อผิดพลาด `InvalidOperationException` สำหรับข้อมูลเพิ่มเติม ดู [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปแบบบนแต่ละสไลด์เพื่อค้นหาแผนภูมิ แสดงชื่อชาร์ตและช่วงต้นทาง หากชาร์ตไม่ได้ใช้เวิร์กบุ๊ก จะพิมพ์ข้อความและดำเนินการต่อไปยังชาร์ตถัดไป

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

## **อ่านและเขียนข้อมูลชาร์ตจากเวิร์กบุ๊ก**

Aspose.Slides for Android via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลชาร์ต (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลชาร์ตต้องถูกจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับต้นฉบับ

ตัวอย่างนี้ใช้งานนำเสนอที่มีชาร์ตเป็นรูปแบบแรกบนสไลด์แรก โดยอ่านเวิร์กบุ๊กฝังเป็นอาร์เรย์ไบต์, ล้างซีรีส์และหมวดหมู่เดิม, แล้วเขียนเวิร์กบุ๊กเดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบการจัดวางชาร์ตหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อคุณแทนที่เวิร์กบุ๊กฝังด้วยเวิร์กบุ๊กที่แก้ไขแล้ว, ชาร์ตจะยังคงรักษาคอลเลกชันซีรีส์และหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ให้ล้างซีรีส์และหมวดหมู่เดิมก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไปยังชาร์ต ตัวอย่างใช้ชาร์ตที่เป็นรูปแบบแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่การแก้ไขเวิร์กบุ๊กจะเกิดขึ้น; ตัวอย่างรันไทม์เขียนเวิร์กบุ๊กต้นฉบับกลับและตรวจสอบการจัดวางในหน่วยความจำ

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

        // แก้ไขไบต์ของเวิร์กบุ๊กที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ สร้างซีรีส์และการแมพหมวดหมู่ใหม่ตามที่ต้องการสำหรับเวิร์กบุ๊กที่อัปเดตก่อนใช้ชาร์ต

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์เวิร์กบุ๊ก**

ใช้ [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) เพื่อควบคุมรูปแบบการแสดงค่าตัวเลขในเวิร์กบุ๊กฝังของชาร์ต ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราการแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง ให้ค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและพล็อตชาร์ตได้

รูปแบบตัวเลขจะเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่จัดเก็บ รูปแบบ `0.0000%` จะแสดง `0.125` เป็น `12.5000%`; ไม่ได้แทนที่ค่าที่จัดเก็บด้วย `12.5` เช่นกัน `0.00000` จะแสดง `0.1234567` เป็น `0.12346` โดยไม่ทำการปัดค่า หากรูปแบบที่กำหนดเป็นสตริงว่าง (`""`) จะใช้รูปแบบที่คืนจาก [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) แทน

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) บนชีตที่ 0, B2 มีอัตราการแปลงและ C2 มีสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าชาร์ต ตัวอย่างยังเปิดใช้งานป้ายค่าที่เชื่อมโยงกับรูปแบบต้นทาง

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

รูปแบบเซลล์เวิร์กบุ๊กแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้ ป้ายแต่ละอันแสดงค่าจากเซลล์ต้นทางเพราะ [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ถูกตั้งเป็น `true` และติดตามรูปแบบตัวเลขต้นทางเพราะ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) เป็น `true` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้รูปแบบตัวเลขของตนเองโดยตั้งค่า [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) เป็น `0.00` พร้อมกับ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) เป็น `false`

หากต้องการฟอร์แมตป้ายข้อมูลแยกจากเซลล์ต้นทาง ให้ตั้งค่าสถานะเชื่อมโยงเป็น `false` และกำหนดรูปแบบด้วย [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) การทำเช่นนี้จะไม่เปลี่ยนรูปแบบของเซลล์เวิร์กบุ๊ก ตัวอย่างเช่น รูปแบบป้ายอิสระ `0.00` จะแสดงค่าแรกเป็น `0.13` ขณะที่ B2 ยังคงแสดง `12.5000%` ดู [ป้ายข้อมูลชาร์ต](/slides/th/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) สำหรับวิธีฟอร์แมตป้ายโดยตรง

รูปภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกแล้วและเปิดใหม่:

![แผนภูมิคอลัมน์ที่มีป้ายเชื่อมโยงกับแหล่งข้อมูลแสดง 12.5000% และ 0.12346 พร้อมแกนตัวเลขที่ฟอร์แมตแยก.](custom-cell-formats.png)

## **ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลชาร์ต**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลของชาร์ตได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลค่าเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนชีตที่ 0 สำหรับป้ายสามค่าตัวแรกของซีรีส์แรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการชีต**

เมธอด [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) ให้เข้าถึงชีตในเวิร์กบุ๊กของชาร์ต ตัวอย่างนี้สร้างแผนภูมิวงกลมด้วยข้อมูลค่าเริ่มต้นและพิมพ์ชื่อชีตแต่ละอันลงคอนโซล

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

ค่าจุดของซีรีส์สามารถจัดเก็บเป็นค่าตัวเลขโดยตรงได้ ดู [ตั้งค่าค่าซีรีส์โดยใช้ค่าลิเทรัลตัวเลข](/slides/th/androidjava/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างเต็มที่บันทึกและอ่านค่าเหล่านั้น ประเภทของแหล่งข้อมูลค่าจุดแยกจากการกำหนดค่าเวิร์กบุ๊กภายในหรือภายนอกของชาร์ต; การใช้ค่าลิเทรัลตัวเลขไม่ได้ทำให้เวิร์กบุ๊กฝังหายไปโดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลค่าเริ่มต้นและตั้งชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิเทรัล; ชื่อที่สองใช้เซลล์ C1 บนชีตที่ 0 ตัวอาเรย์ [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) กำหนดแหล่งข้อมูลสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางชาร์ต คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) บน [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) ร่วมกับตัวอาเรย์ [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามชาร์ตเหล่านั้น ตัวอย่างตรวจสอบรูปแบบบนสไลด์แรกของงานนำเสนอที่มีอยู่, ข้ามรูปแบบที่ไม่ใช่ชาร์ต, และพิมพ์ข้อความวินิจฉัยสำหรับชาร์ตที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

        // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กชาร์ตที่รองรับที่นี่.
    }
} finally {
    presentation.dispose();
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) และ [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) เพื่อส่งออกเวิร์กบุ๊กชาร์ตที่ฝังเป็นไฟล์และเชื่อมชาร์ตกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวงกลมด้วยข้อมูลค่าเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน ทำการเขียนไฟล์เสร็จแล้วจึงกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับชาร์ตเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้ในการอัปเดตพาธไปยังเวิร์กบุ๊กภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่เก็บอยู่ในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังคงใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุพาธสัมพันธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่ชีตชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิวงกลม, เชื่อมโยงเวิร์กบุ๊ก, และใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อแมพ A1:B4 เป็นหนึ่งซีรีส์และสามหมวด แล้วบันทึกงานนำเสนอพร้อมชาร์ตที่เชื่อมโยง

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

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะพาธของเวิร์กบุ๊ก ชาร์ตจะไม่โหลดหรืออัปเดตข้อมูลจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `true` ข้อมูลชาร์ตจะถูกอัปเดตจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปนี้กำหนด URL ตัวอย่างโดยตั้งค่า `updateChartData` เป็น `false` งานนำเสนอจะแสดงข้อมูลเริ่มต้นของแผนภูมิวงกลมและบันทึกโดยไม่มีการโหลดเวิร์กบุ๊กที่ไม่พร้อมใช้งาน

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

### **ดึงพาธเวิร์กบุ๊กแหล่งข้อมูลภายนอกของชาร์ต**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมโยงกับชาร์ต, ตรวจสอบว่าชาร์ตใช้แหล่งข้อมูลภายนอกหรือไม่และดึงพาธเวิร์กบุ๊กของมัน

ตัวอย่างตรวจสอบรูปแบบแรกบนสไลด์แรกของงานนำเสนอที่เชื่อมกับเวิร์กบุ๊กภายนอก หากเป็นชาร์ตที่เชื่อมกับเวิร์กบุ๊กภายนอก ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) ลงคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

### **แก้ไขข้อมูลชาร์ต**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงข้อมูลในเวิร์กบุ๊กภายใน หากเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้ชาร์ตที่เป็นรูปแบบแรกบนสไลด์แรกและเชื่อมกับเวิร์กบุ๊กภายนอกที่สามารถเข้าถึงได้ ตั้งค่าค่าที่สนับสนุนเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าจากเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ดังนั้นควรใช้สำเนาหากต้องการเก็บเวิร์กบุ๊กต้นฉบับไว้

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

### **กู้คืนเวิร์กบุ๊กจากแคชของชาร์ต**

หากชาร์ตใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่มีอยู่, Aspose.Slides สามารถสร้างเวิร์กบุ๊กของชาร์ตจากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), และตั้งค่า [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Java ต่อไปนี้กู้คืนข้อมูลเวิร์กบุ๊กสำหรับชาร์ตที่เป็นรูปแบบแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) และ [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

หากเวิร์กบุ๊กภายนอกไม่มีและการกู้คืนถูกปิด, Aspose.Slides จะขว้างข้อยกเว้น เปิดใช้การกู้คืนเฉพาะเมื่อการใช้ข้อมูลชาร์ตที่แคชเป็นวิธีสำรองที่ยอมรับได้, เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับเวิร์กบุ๊กภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถระบุได้หรือไม่ว่าชาร์ตใดเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กฝังอยู่?**

ได้. ชาร์ตมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) และ [พาธไปยังเวิร์กบุ๊กภายนอก](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); หากแหล่งข้อมูลเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านพาธเต็มเพื่อให้แน่ใจว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับพาธสัมพันธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่, และเก็บไว้แบบใด?**

รองรับ. หากคุณระบุพาธสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ งานนำเสนอเก็บพาธเต็มในไฟล์ PPTX, ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) การแก้ไขข้อมูลชาร์ตที่อิงจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยง ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับคงอยู่โดยไม่เปลี่ยนแปลง

**ถ้าไฟล์ภายนอกถูกตั้งรหัสผ่านควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ แนะนำให้ลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายชาร์ตสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละชาร์ตเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละชาร์ตครั้งต่อไปที่โหลดข้อมูล**