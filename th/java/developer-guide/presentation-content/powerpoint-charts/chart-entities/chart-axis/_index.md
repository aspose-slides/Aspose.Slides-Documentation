---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย Java
linktitle: แกนแผนภูมิ
type: docs
url: /th/java/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- หัวเรื่องแกน
- ตำแหน่งแกน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลข้อมูล"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for Java รวมถึงค่าที่คำนวณได้ของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ป้ายกำกับหมวดหมู่และช่วงของเครื่องหมายติ๊ก การจัดหมวดหมู่ตามวันที่และการจัดรูปแบบ การหมุนหัวเรื่อง การกำหนดตำแหน่งแกน หน่วยแสดงผล และการสเกลแบบลอการิทึม

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่ด้วยข้อมูลเริ่มต้น เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้รูปแบบแผนภูมิเป็นล่าสุด

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) สำหรับขอบเขตของแกน และ [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) และ [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) สำหรับช่วงของเครื่องหมายติ๊ก [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างนี้เก็บค่าต่าง ๆ ไว้ในตัวแปรท้องถิ่นแล้วบันทึกแผนภูมิ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อแลกเปลี่ยนบทบาทของชุดข้อมูลและหมวดหมู่ในข้อมูลแผนภูมิ แต่ละหมวดหมู่เดิมจะกลายเป็นชุดข้อมูล และแต่ละชุดข้อมูลเดิมจะกลายเป็นหมวดหมู่ สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล ไม่ใช่การสลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อตั้งค่าช่วงข้อมูลเริ่มต้นเป็น `Sheet1!A1:D5` รวมแถวหัวและคอลัมน์หมวดหมู่ ก่อนสลับแถวและคอลัมน์ แล้วบันทึกแผนภูมิที่มีสี่ชุดข้อมูลและสามหมวดหมู่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ย้อนกลับลำดับการวางข้อมูลของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) เพื่อย้อนกลับแกนหมวดหมู่หรือค่า ตัวอย่างเช่น แผนภูมิคอลัมน์แนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างตามลำดับเดียวกับแผ่นงาน: Planning, Development, Testing การย้อนกลับแกนจะเปลี่ยนทิศทางการวาด ไม่ได้ทำการจัดเรียงหรือเปลี่ยนแปลงข้อมูลในเวิร์กบุ๊ก เมื่อเปรียบเทียบกับ [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) ที่แลกเปลี่ยนบทบาทของชุดข้อมูลและหมวดหมู่

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์แนวนอนที่มีสามขั้นตอนและหนึ่งชุดข้อมูล แล้วบันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดหมู่ย้อนกลับ, และค่าย้อนกลับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกัน และแต่ละสำเนาจะย้อนกลับเพียงแกนเดียว

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320);
    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredBar);
    String[] stages = { "Planning", "Development", "Testing" };
    int[] values = { 10, 30, 20 };
    for (int i = 0; i < stages.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, stages[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    // สไลด์ 2: แสดงหมวดหมู่แรกที่ด้านบน.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // คงแกนค่าตามแนวนอนไว้ที่ด้านล่าง.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // สไลด์ 3: กลับทิศเฉพาะสเกลตัวเลขแนวนอน.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การย้อนกลับแกนอาจทำให้แกนตั้งฉากย้ายไปยังด้านตรงข้ามของพื้นที่วาดได้ [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) ควบคุมตำแหน่งที่แกนอื่นตัดกับแกนที่กำลังกำหนดค่า ในสไลด์ที่ 2 การเรียกใช้ด้วย `CrossesType.Maximum` บนแกนหมวดหมู่ที่ถูกย้อนกลับทำให้แกนค่าตั้งอยู่ที่ด้านล่างของแกนนอน สำหรับจุดตัดที่กำหนดเอง ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). ตรวจสอบการตั้งค่าตัดเมื่อเปลี่ยนทิศทาง โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดแบบกำหนดเองแล้ว เรียก `setPlotOrderReversed` ด้วย `false` เพื่อคืนทิศทางการวาดปกติ; การตั้งค่าตัดเป็นค่าที่แยกจากกัน

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่ย้อนกลับ (สไลด์ 2) | ค่าย้อนกลับ (สไลด์ 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| หมวดหมู่ไหลจากล่างขึ้นบน; ค่าเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing ไหลจากบนลงล่าง. ค่าและลำดับแถวของเวิร์กบุ๊กไม่เปลี่ยนแปลง. | หมวดหมู่คงลำดับเดิม; ค่าเพิ่มจากขวาไปซ้าย. แกนหมวดหมู่ตัดที่ศูนย์ด้านขวา. |

## **ซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วย `false` บนแกนแนวตั้งเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยซ่อนแกนแนวตั้ง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วย `false` บนแกนแนวนอนเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยซ่อนแกนแนวนอน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แสดงหรือซ่อนเส้นกริดของแผนภูมิ**

เรียก [getShowMajorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMajorGridLines--) และ [getShowMinorGridLines](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getShowMinorGridLines--) เพื่อตรวจสอบว่าแกนแสดงเส้นกริดใดบ้าง วิธีเหล่านี้บันทึกสถานะการมองเห็นปัจจุบัน หากต้องการแสดงเส้นกริดย่อย ให้ใช้ [getMinorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) แล้วตั้งการเติมเส้นเป็นสีทึบที่มองเห็นได้ หากต้องการซ่อน ให้ตั้งการเติมเป็น [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/#NoFill). ใช้ [getMajorGridLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) เพื่อเปลี่ยนการเติมเส้นสำหรับเส้นกริดหลักในลักษณะเดียวกัน การเปลี่ยนการเติมจะคงการมองเห็นของแกนและเครื่องหมายติ๊กไว้

แกนแนวตั้งของแผนภูมิกลุ่มคอลัมน์นี้เริ่มต้นแสดงเฉพาะเส้นกริดหลัก ตัวอย่างแสดงเส้นกริดย่อยเป็นสีส้มเข้ม แล้วซ่อนอีกครั้งก่อนบันทึกการนำเสนอและพิมพ์สถานะการมองเห็นของเส้นกริดในแต่ละขั้นตอน

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(new Color(255, 140, 0));
    System.out.printf("Enabled: minor=%b%n", axis.getShowMinorGridLines());

    minorFill.setFillType(FillType.NoFill);
    System.out.printf("Hidden: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| เส้นกริดย่อยเปิดใช้งาน | เส้นกริดย่อยซ่อน |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` ที่มีแผนภูมิเป็นวัตถุรูปแรกบนสไลด์แรกและเซลล์หมวดหมู่มีค่าเลขวันที่ของ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วย `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) ด้วย `1` และ [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วย `TimeUnitType.Months` จะวางเครื่องหมายหลักทุกหนึ่งเดือน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดประเภทแกนหมวดหมู่จากข้อมูล**

หลังจากใส่ค่าหมวดหมู่แล้วเรียก [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) แล้วอ่านค่า [getCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#getCategoryAxisType--) เพื่อดูการเลือก วิธีนี้มีประโยชน์เมื่อแผนภูมิเดียวกันอาจได้รับป้ายข้อความหรือค่าที่เป็นวันที่แบบตัวเลข วิธีทำงานคือกำหนดประเภทในขณะเรียกใช้ ไม่ได้เปิดโหมดคงที่ที่ทำการประเมินใหม่เมื่อข้อมูลเปลี่ยนแปลง หลังจากเปลี่ยนค่าหมวดหมู่ใหม่ให้เรียกอีกครั้ง

ตัวอย่างต่อไปสร้างแผนภูมิที่มีหมวดหมู่เป็นข้อความและพิมพ์ `true` เมื่อประเภทที่เลือกเป็น `CategoryAxisType.Text` จากนั้นแทนค่าหมวดหมู่ด้วยวันที่และเรียกเมธอดอีกครั้ง พิมพ์ `true` เมื่อประเภทที่เลือกเป็น `CategoryAxisType.Date` วันที่ถูกเก็บเป็นค่าเลข OLE Automation ซึ่งคำนวณจากจำนวนวันตั้งแต่ 30 ธันวาคม 1899 ไม่ใช่สตริงวันที่ การใช้ [setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) ควบคุมการแสดงค่าเหล่านี้; ไม่ได้แปลงข้อความเป็นวันที่เชิงตัวเลข ดูข้อมูลหมวดหมู่อีกที่ [Chart Workbook](/slides/th/java/chart-workbook/)

ใช้การกำหนดอัตโนมัติเมื่ออินพุตเป็นข้อความหรือวันที่เชิงตัวเลขตามตัวอย่าง สำหรับป้ายตัวเลขทั่วไป, หมวดหมู่ผสม หรือข้อมูลว่าง ให้เรียก [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setCategoryAxisType-int-) อย่างชัดเจนเพื่อให้ตรงกับความหมายค่าที่ต้องการ ค่าตัวเลขอย่างเดียวไม่บ่งบอกว่าหมวดหมู่แทนวันที่

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());
    String[] labels = { "First", "Second", "Third" };

    for (int i = 0; i < labels.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, labels[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, (i + 1) * 10);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Text); // จริง

    LocalDate baseDate = LocalDate.of(1899, 12, 30);
    LocalDate[] dates = { LocalDate.of(2026, 1, 1), LocalDate.of(2026, 1, 2), LocalDate.of(2026, 2, 1) };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        categoryCell.setValue((double)(dates[i].toEpochDay() - baseDate.toEpochDay()));
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // จริง

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมช่วงป้ายกำกับแกนหมวดหมู่**

เมื่อแผนภูมิมีหมวดหมู่จำนวนมาก ให้ลดจำนวนป้ายกำกับที่มองเห็นได้โดยไม่ต้องลบหมวดหมู่หรือจุดข้อมูล เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วย `false` แล้วส่งช่วงหมวดหมู่ที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) สำหรับหมวดหมู่ข้อความในลำดับปกติ การนับเริ่มจากหมวดหมู่แรก:

| ช่วง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

ช่วง `3` จะแสดงป้ายทุกสามตำแหน่ง และซ่อนสองตำแหน่งระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดช่องว่างอัตโนมัติเลือกช่วงตามพื้นที่ว่างที่มี ไม่ได้บังคับให้แสดงทุกป้าย

เครื่องหมายติ๊กมีการควบคุมแยกต่างหาก เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วย `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) เพื่อกำหนดช่วงของเครื่องหมายติ๊ก ตัวอย่างเช่น `1` จะวางเครื่องหมายติ๊กที่ทุกช่วงหมวดหมู่ ขณะที่ป้ายแสดงเพียงทุกสามหมวดหมู่ ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) กับสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าการจัดช่องว่างอัตโนมัติเป็น `true` อีกครั้งจะทำให้แผนภูมิกำหนดช่วงนั้นใหม่อีกครั้ง

ตัวอย่างต่อไปสร้าง 24 หมวดหมู่และหนึ่งชุดข้อมูล แล้วบันทึกสามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างด้วยตนเองพร้อมเครื่องหมายติ๊กอิสระ, และการคืนค่าเป็นอัตโนมัติ สองสำเนาคงข้อมูลแผนภูมิก่อนหน้า ไม่ต้องใช้ไฟล์นำเข้าใด ๆ ข้อความป้ายแนวนอนทำให้มองเห็นความแตกต่างของความหนาแน่นได้ง่าย

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // สไลด์ 2: แสดงป้ายทุกสามตำแหน่ง แต่คงเครื่องหมายติ๊กไว้สำหรับทุกหมวดหมู่.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเ�เลือกช่วงทั้งสองครั้งอีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการเรนเดอร์นี้ จะแสดงป้ายหมวดหมู่ทุกสองตำแหน่งและห่อข้อความเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และตัวเรนเดอร์

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**การจัดช่องว่างด้วยตนเอง (สไลด์ 2):** แสดงป้ายทุกสามตำแหน่งในบรรทัดเดียว ส่วนเครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วงหมวดหมู่ ทั้ง 24 คอลัมน์รวมถึงคอลัมน์ที่ไม่มีป้ายก็ยังคงมองเห็นได้ด้วยค่าเดียวกัน สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงด้านบน

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **เลือกแกนและช่วงที่เหมาะสม**

ใช้ช่วงจำนวนหมวดหมู่นี้สำหรับแกนหมวดหมู่แบบข้อความ เช่น แกนหมวดหมู่ของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิคอลัมน์แนวนอนแกนหมวดหมู่เป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับแกนที่คืนค่าโดย [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) รายการช่วงของเครื่องหมายติ๊กยังใช้ได้กับแกนชุดข้อมูลในแผนภูมิที่มีแกนชุดข้อมูล

ห้ามใช้การจัดช่องว่างของป้ายเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) กำหนดความแตกต่างของค่า เช่น หน่วยหลัก `10` จะให้เครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มจากศูนย์ ส่วนช่วงป้ายหมวดหมู่ `3` จะนับตำแหน่งหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดหมู่แบบข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยและสเกลตามเวลาตามที่อธิบายไว้ในหัวข้อ [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลเริ่มต้นของแผนภูมิโดยใช้ค่าปีสี่ค่า วันที่ถูกเก็บเป็นจำนวนซีเรียล OLE Automation ในแผ่นงานแรก (ดัชนี `0`) คำนวณจากจำนวนวันตั้งแต่ 30 ธันวาคม 1899 ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วย `false` แล้วส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้ายหมวดหมู่แสดงปีสี่หลักโดยไม่พิจารณาการจัดรูปแบบของเซลล์

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่ามุมการหมุนสำหรับหัวเรื่องแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) ด้วย `true` บนแกนแนวตั้ง ให้ข้อความหัวเรื่อง แล้วใช้ [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนหัวเรื่อง มุมวัดเป็นองศา ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวเรื่องแกนค่าถูกหมุน 90 องศา

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งตำแหน่งแกนบนแกนหมวดหมู่หรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่าแกนค่าจะตัดแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่เครื่องหมายติ๊กของหมวดหมู่ การตั้งค่านี้ใช้กับแกนหมวดหมู่ ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าหน่วยแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วย [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) ตั้งค่าเป็น `Millions` ค่าที่เป็น 60,000,000 จะปรากฏเป็น 60 ตัวอย่างนี้สร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **กำหนดค่าแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายระดับตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000 และ 100,000 คำขอในห้าช่วงเวลา บนสเกลเชิงเส้นค่าที่เล็กจะอยู่ใกล้ศูนย์มาก ลอการิทึมทำให้การเติบโตสัมพัทธ์ดูง่ายขึ้น: ระยะเท่ากันแสดงอัตราส่วนเท่ากัน ไม่ใช่ความแตกต่างเท่ากัน

เรียก [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) ด้วย `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) เพื่อเลือกฐาน วิธีนี้เปลี่ยนการแสดงค่าที่มีอยู่ ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหาก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). สำหรับแผนภูมิบาร์แนวนอนจะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นให้เลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสองแกน อย่าใช้สเกลลอการิทึมกับแกนหมวดหมู่

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ก็รองรับเช่นกัน เมื่อใช้ฐาน `10` พลังที่ต่อเนื่อง เช่น 10, 100, 1,000, 10,000 จะจัดวางอย่างเท่าเทียมกัน

### **เปรียบเทียบสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปสร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าช่วงบนสไลด์แรก แล้วคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์คงข้อมูลเดียวกัน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งที่เท่ากันแทนความแตกต่างของจำนวนคำขอ ค่าที่ใหญ่ที่สุดครอบคลุมแผนภูมิ ทำให้ค่าที่เล็กยากต่อการมองเห็น

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งที่เท่ากันแทนอัตราส่วน คำขอแต่ละช่วงมากกว่าช่วงก่อนหน้าถึงเท่าตัว ทำให้จุดอยู่บนเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน 10 ป้ายแกนยังคงแสดงจำนวนคำขอเดิม

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าที่เป็นบวกอย่างเคร่งครัด ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าติดลบมีความหมาย ให้คงสเกลเชิงเส้นหรือแสดงแยกออกไม่ต้องใช้ลอการิทึม หากการลบค่าดังกล่าวเหมาะกับการวิเคราะห์ ให้อธิบายเหตุผล อย่าแทนที่ด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน

## **FAQ**

**ฉันจะกำหนดค่าที่แกนหนึ่งตัดแกนอีก (axis crossing) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการตัด หากต้องการระบุค่าตัวเลขให้ตัด ใช้ [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) การตั้งค่าเหล่านี้ช่วยให้คุณย้ายจุดตัดของแกนไปยังฐานที่เหมาะสม

**ฉันจะตำแหน่งป้ายเครื่องหมายติ๊กสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) พร้อมใช้ค่าใน [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อตั้งค่าตำแหน่งของเครื่องหมายติ๊กเอง ให้ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); การตั้งค่าเหล่านี้แยกจากการจัดตำแหน่งป้าย.