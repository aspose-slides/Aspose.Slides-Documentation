---
title: ปรับแต่งแกนแผนภูมิในการนำเสนอบน Android
linktitle: แกนแผนภูมิ
type: docs
url: /th/androidjava/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- บริหารจัดการแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- หัวข้อแกน
- ตำแหน่งแกน
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิกับ Aspose.Slides for Android ผ่าน Java. มันครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ช่วงเวลาของป้ายชื่อหมวดหมู่และเครื่องหมายกากบาท, หมวดหมู่วันและการฟอร์แมต, การหมุนหัวเรื่อง, การจัดตำแหน่งแกน, หน่วยการแสดงผล, และการสเกลแบบลอการิทึม.

## **รับค่ามากสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่พร้อมข้อมูลเริ่มต้น. เรียก [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมืเป็นปัจจุบัน.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) เพื่อรับขอบเขตของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) และ [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) เพื่อรับช่วงเวลาของเครื่องหมาย. [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างนี้เก็บค่าต่างๆ ไว้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ.

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อสลับบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ. หมวดหมู่เดิมแต่ละรายการจะกลายเป็นซีรีส์, และซีรีส์เดิมแต่ละรายการจะกลายเป็นหมวดหมู่. สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5`, รวมแถวหัวและคอลัมน์หมวดหมู่, ก่อนสลับแถวและคอลัมน์. มันบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่.

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

## **ย้อนลำดับการวาดของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) เพื่อย้อนลำดับของแกนหมวดหมู่หรือค่า. ตัวอย่างเช่น, แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับแผ่นงาน: Planning, Development, Testing. การย้อนแกนเปลี่ยนทิศทางการวาด; ไม่ได้เรียงหรือจัดเรียงข้อมูลในเวิร์กบุ๊กใหม่. โดยเปรียบเทียบ, [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) สลับบทบาทของซีรีส์และหมวดหมู่.

ตัวอย่างต่อไปสร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์. มันบันทึกงานนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดหมู่ย้อนกลับ, และค่าถอยกลับ. แต่ละสำเนาใช้ชุดข้อมูลเดียวกัน, และเพียงแกนเดียวที่ถูกย้อนกลับในแต่ละสำเนา.

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
    // รักษาแกนค่าตามแนวนอนไว้ที่ด้านล่าง.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // สไลด์ 3: กลับทิศทางสเกลเชิงตัวเลขตามแนวนอนเท่านั้น.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การย้อนแกนยังสามารถย้ายแกนที่ตั้งฉากไปยังด้านตรงข้ามของพื้นที่วาดได้. [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) ควบคุมว่าตรงแกนอื่นตัดกันที่ไหนบนแกนที่กำหนดค่า. ในสไลด์ 2, เรียกโดยใช้ `CrossesType.Maximum` บนแกนหมวดหมู่ที่ย้อนกลับจะทำให้แกนค่ารูปแนวนอนอยู่ที่ด้านล่าง. สำหรับจุดตัดที่เฉพาะเจาะจง, ใช้ [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). ตรวจสอบการตั้งค่าตัดเมื่อเปลี่ยนทิศทาง, โดยเฉพาะหากแผนภูมิมีจุดตัดที่กำหนดเองแล้ว. เรียก `setPlotOrderReversed` ด้วย `false` เพื่อคืนทิศทางการวาดปกติ; การตั้งค่าตัดเป็นสิ่งแยกต่างหาก.

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่ย้อนกลับ (สไลด์ 2) | ค่าถอยกลับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับปกติของแกนหมวดหมู่และค่า](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงหมวดหมู่จากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่าถูกย้อนกลับและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| หมวดหมู่เรียงจากล่างขึ้นบน; ค่าจะเพิ่มจากซ้ายไปขวา. | ขั้นตอนการวางแผน, การพัฒนา, และการทดสอบเรียงจากบนลงล่าง. ค่และลำดับแถวของเวิร์กบุ๊กคงเดิม. | หมวดหมู่คงลำดับปกติ; ค่าจะเพิ่มจากขวาไปซ้าย. แกนหมวดหมู่ตัดที่ศูนย์ด้านขวา. |

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วย `false` บนแกนแนวตั้งเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน.

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

## **ปิดการแสดงแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วย `false` บนแกนแนวนอนเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน.

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

เรียก [getShowMajorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMajorGridLines--) และ [getShowMinorGridLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getShowMinorGridLines--) เพื่อตรวจสอบว่าแกนแสดงเส้นกริดใด. วิธีเหล่านี้รายงานสถานะการแสดงผลปัจจุบัน. เพื่อแสดงเส้นกริดย่อย, ใช้ [getMinorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMinorGridLinesFormat--) แล้วตั้งค่าการเติมเส้นให้เป็นสีทึบที่มองเห็นได้. เพื่อซ่อน, ตั้งค่าการเติมเป็น [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/#NoFill). ใช้ [getMajorGridLinesFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getMajorGridLinesFormat--) เพื่อเปลี่ยนการเติมเส้นสำหรับกริดหลักในลักษณะเดียวกัน. การเปลี่ยนการเติมจะคงการแสดงผลของแกนและเครื่องหมายกากบาทไว้.

แกนแนวตั้งของแผนภูมิคอลัมน์แบบกลุ่มนี้เริ่มต้นแสดงเพียงกริดหลัก. ตัวอย่างแสดงกริดย่อยเป็นสีส้มเข้ม, แล้วซ่อนอีกครั้งก่อนบันทึกงานนำเสนอ. มันพิมพ์สถานะการแสดงกริดในแต่ละขั้นตอน.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
    IAxis axis = chart.getAxes().getVerticalAxis();
    System.out.printf("Initial: major=%b, minor=%b%n", axis.getShowMajorGridLines(), axis.getShowMinorGridLines());

    ILineFillFormat minorFill = axis.getMinorGridLinesFormat().getLine().getFillFormat();
    minorFill.setFillType(FillType.Solid);
    minorFill.getSolidFillColor().setColor(Color.rgb(255, 140, 0));
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
| ![เส้นกริดย่อยสีส้มระหว่างเส้นกริดหลักบนแกนแนวตั้ง](minor-gridlines-enabled.png) | ![แผนภูมิคอลัมน์เดียวกันที่แสดงเฉพาะเส้นกริดหลัก](minor-gridlines-hidden.png) |

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ. ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx`, โดยมีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์หมวดหมู่มีค่าตัวเลขของวันที่ใน Excel. มันเปลี่ยนแกนแนวนอนเป็นแกนวันที่. เรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วย `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) ด้วย `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วย `TimeUnitType.Months` เพื่อวางเครื่องหมายหลักที่ช่วงเดือนละหนึ่งครั้ง.

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

หลังจากเติมหมวดหมู่แล้วเรียก [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisTypeAutomatically--) แล้วอ่าน [getCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#getCategoryAxisType--) เพื่อพิจารณาการเลือก. วิธีนี้มีประโยชน์เมื่อแผนภูมิเช่นเดียวกันอาจได้รับป้ายข้อความหรือค่าตัวเลขของวันที่. วิธีจะกำหนดประเภทเมื่อถูกเรียก; ไม่ได้เปิดโหมดคงที่ที่ประเมินข้อมูลใหม่ในภายหลัง. เรียกอีกครั้งหลังจากเปลี่ยนหมวดหมู่.

ตัวอย่างต่อไปสร้างแผนภูมิที่มีหมวดหมู่ข้อความและพิมพ์ `true` เมื่อประเภทที่เลือกคือ `CategoryAxisType.Text`. จากนั้นแทนที่ค่าของเซลล์หมวดหมู่ด้วยวันที่และเรียกวิธีนั้นอีกครั้ง, พิมพ์ `true` เมื่อประเภทที่เลือกคือ `CategoryAxisType.Date`. วันที่ถูกเก็บเป็นค่าเชิงตัวเลขของ OLE Automation, คำนวณเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899, ไม่ใช่สตริงวันที่. ปฏิทินทั้งสองใช้ UTC และจะถูกล้างก่อนตั้งค่าวันที่เพื่อให้การเปลี่ยนแปลงเวลาออมแสงหรือเวลาปัจจุบันไม่ส่งผลต่อการคำนวณ. [setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) ควบคุมวิธีการแสดงค่าดังกล่าว; ไม่ได้แปลงข้อความเป็นวันที่เชิงตัวเลข. สำหรับข้อมูลเพิ่มเติมเกี่ยวกับเซลล์หมวดหมู่, ดู [Chart Workbook](/slides/th/androidjava/chart-workbook/).

ใช้การกำหนดอัตโนมัติเมื่ออินพุตเป็นที่ทราบว่ามีหมวดหมู่ข้อความหรือวันที่เชิงตัวเลข, เช่นในตัวอย่างนี้. สำหรับป้ายตัวเลขธรรมดา, หมวดหมู่ผสม, หรือข้อมูลว่าง, เรียก [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setCategoryAxisType-int-) อย่างชัดเจนเพื่อให้สอดคล้องกับความหมายที่ต้องการ. ค่าตัวเลขเพียงอย่างเดียวไม่บ่งบอกว่าหมวดหมู่แสดงถึงวันได้.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

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

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);
    int[][] dates = { { 2026, Calendar.JANUARY, 1 }, { 2026, Calendar.JANUARY, 2 }, { 2026, Calendar.FEBRUARY, 1 } };

    for (int i = 0; i < dates.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0);
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(dates[i][0], dates[i][1], dates[i][2]);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        categoryCell.setValue(serialDate);
        categoryCell.setCustomNumberFormat("yyyy-mm-dd");
    }

    axis.setCategoryAxisTypeAutomatically();
    System.out.println(axis.getCategoryAxisType() == CategoryAxisType.Date); // จริง

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมช่วงเวลาป้ายชื่อแกนหมวดหมู่**

เมื่อแผนภูมิมีหลายหมวดหมู่, ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหมู่หรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วย `false`, แล้วส่งช่วงเวลาที่ต้องการให้กับ [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). สำหรับหมวดหมู่ข้อความในลำดับปกติ, การนับเริ่มจากหมวดหมู่แรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวดหมู่ 1, หมวดหมู่ 2, หมวดหมู่ 3, ... หมวดหมู่ 24 |
| `2` | หมวดหมู่ 1, หมวดหมู่ 3, หมวดหมู่ 5, ... หมวดหมู่ 23 |
| `3` | หมวดหมู่ 1, หมวดหมู่ 4, หมวดหมู่ 7, ... หมวดหมู่ 22 |

ช่วง `3` จะแสดงป้ายชื่อทุกสามรายการ, ทำให้มีสองป้ายชื่อซ่อนอยู่ระหว่างที่แสดง. มันไม่ได้ลบคอลัมน์ที่สอดคล้องกัน. การจัดช่องว่างอัตโนมัติเลือกช่วงตามพื้นที่ที่มี; ไม่ได้จำเป็นต้องแสดงทุกป้ายชื่อ.

เครื่องหมายกากบาทมีการควบคุมแยกกัน. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วย `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) เพื่อกำหนดช่วงของเครื่องหมาย. ตัวอย่างเช่น, `1` จะทำให้มีเครื่องหมายกากบาทที่ทุกช่วงของหมวดหมู่ขณะที่ป้ายชื่อปรากฎเพียงทุกสามหมวดหมู่. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) ด้วยสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์. การตั้งค่าอัตโนมัติใดๆ อีกครั้งด้วย `true` จะให้แผนภูมิเพื่อเลือกช่วงนั้นใหม่.

ตัวอย่างต่อไปนี้เป็นแบบอิสระที่สร้าง 24 หมวดหมู่และหนึ่งซีรีส์, แล้วบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างแบบแมนนวลพร้อมเครื่องหมายกากบาทอิสระ, และการคืนค่าการจัดช่องว่างอัตโนมัติ. สองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม. ไม่จำเป็นต้องมีงานนำเสนอเข้า. ข้อความป้ายแนวนอนทำให้เห็นความหนาแน่นได้ง่าย.

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

    // สไลด์ 2: แสดงป้ายชื่อทุกลำดับที่สาม, แต่คงเครื่องหมายกากบาทไว้สำหรับทุกหมวดหมู่.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเ�เลือกช่วงเวลาทั้งสองใหม่อีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการเรนเดอร์นี้, ป้ายชื่อของทุกสองหมวดหมู่จะแสดงและจะตัดบรรทัดเป็นสองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, แบบอักษร, และตัวเรนเดรอร์.

![ระยะห่างป้ายชื่อหมวดหมู่อัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์แสดง](category-axis-automatic.png)

**การจัดช่องว่างแบบแมนนวล (สไลด์ 2):** ป้ายชื่อทุกสามรายการจะแสดงบนบรรทัดเดียว, ขณะที่เครื่องหมายกากบาทยังคงอยู่ทุกช่วงของหมวดหมู่. ทั้ง 24 คอลัมน์, รวมถึงคอลัมน์ที่ไม่มีป้ายชื่อ, ยังคงปรากฏพร้อมค่าตามเดิม. สไลด์ 3 คืนค่าการจัดช่องว่างอัตโนมัติเช่นที่แสดงข้างบน.

![ช่วงเวลาป้ายชื่อหมวดหมู่แบบแมนนวลที่เป็นสามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์แสดง](category-axis-manual.png)

### **เลือกแกนและช่วงเวลาที่ถูกต้อง**

ใช้ช่วงเวลานับหมวดหมู่นี้กับแกนหมวดหมู่แบบข้อความ, เช่นแกนหมวดหมู่ของแผนภูมิคอลัมน์, เส้น, พื้นที่, หรือแท่ง. ในแผนภูมิคอลัมน์, มันคือแกนแนวนอน. ในแผนภูมิแท่งแนวนอน, แกนหมวดหมู่ใต้วิธีตั้งค่าเป็นแนวตั้ง, ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). การจัดช่องว่างของเครื่องหมายกากบาทยังใช้กับแกนซีรีส์ในแผนภูมิที่มีแกนนี้.

ห้ามใช้การจัดช่องว่างของป้ายชื่อหมวดหมู่เพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) กำหนดความแตกต่างของค่า: ตัวอย่างเช่น, หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20, ... เมื่อแกนเริ่มที่ศูนย์. ช่วงเวลาป้ายชื่อหมวดหมู่ `3` นับตำแหน่งของหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล. แผนภูมิกระจายและฟองใช้แกนค่ามากกว่าการใช้แกนหมวดหมู่แบบข้อความ. สำหรับแกนวันที่, ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายใน [เปลี่ยนแกนหมวดหมู่](#change-a-category-axis).

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าประจำปีสี่ค่า. วันที่ถูกเก็บเป็นหมายเลขเชิงซีรีส์ของ OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`), คำนวณเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้. ปฏิทินทั้งสองใช้ UTC และจะถูกล้างก่อนตั้งค่าวันที่เพื่อให้การปรับเวลาออมแสงหรือเวลาปัจจุบันไม่ส่งผลต่อการคำนวณ. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วย `false`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้ายชื่อหมวดหมู่แสดงปีสี่หลักโดยอิสระจากการฟอร์แมตของเซลล์.

```java
import com.aspose.slides.*;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.TimeZone;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    TimeZone timeZone = TimeZone.getTimeZone("UTC");
    Calendar baseDate = new GregorianCalendar(timeZone);
    baseDate.clear();
    baseDate.set(1899, Calendar.DECEMBER, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        Calendar date = new GregorianCalendar(timeZone);
        date.clear();
        date.set(2015 + i, Calendar.JANUARY, 1);
        double serialDate = (date.getTimeInMillis() - baseDate.getTimeInMillis()) / 86400000.0;
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, serialDate);
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

เรียก [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) ด้วย `true` บนแกนแนวตั้ง, ให้ข้อความหัวเรื่อง, และใช้ [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนหัวเรื่อง. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่มีหัวเรื่องแกนค่าถูกหมุน 90 องศา.

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

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่าแกนค่าจะตัดผ่านแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่เครื่องหมายกากบาทของหมวดหมู่. การตั้งค่านี้ใช้กับแกนหมวดหมู่. ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์.

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

## **ตั้งค่าหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อสเกลป้ายกำกับบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. กับ [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ตั้งเป็น `Millions`, ค่าที่เป็น 60 000 000 จะแสดงเป็น 60. ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้งของมัน.

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

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกขยายหลายระดับขนาด. ตัวอย่างเช่น, บริการอาจรับคำขอ 10, 100, 1 000, 10 000, และ 100 000 ครั้งในห้าช่วงเวลา. บนสเกลเชิงเส้น, ค่าตัวเล็กจะอยู่ใกล้ศูนย์กัน. สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพัทธ์ง่ายขึ้น: ระยะห่างที่เท่ากันแสดงอัตราส่วนที่เท่ากัน แทนความแตกต่างที่เท่าเดิม.

เรียก [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) ด้วย `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) เพื่อเลือกฐาน. สิ่งนี้เปลี่ยนวิธีที่ค่าที่มีอยู่แสดงผล; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มเป็นคุณลักษณะแยกที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล.

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). สำหรับแผนภูมิแท่งแนวนอน, จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). แผนภูมิกระจายและฟองมีสองแกนค่า, ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง. อย่าใช้การสเกลลอการิทึมกับแกนหมวดหมู่.

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX, สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมทั้งฐานเศษส่วนเช่น `2.5`. ด้วยฐาน `10`, พลังที่ต่อเนื่องเช่น 10, 100, 1 000, และ 10 000 จะถูกจัดระยะห่างเท่ากัน.

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้เป็นแบบอิสระที่สร้างแผนภูมิเส้นพร้อมจำนวนคำขอห้าครั้งบนสไลด์แรก, แล้วคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง. ทั้งสองสไลด์คงข้อมูลเดิมไว้.

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

**สเกลเชิงเส้น (สไลด์ 1):** ระยะห่างแนวตั้งที่เท่าเดิมแสดงความแตกต่างของจำนวนคำขอที่เท่าเทียมกัน. ค่าที่ใหญ่สุดครอบงำแผนภูมิ, ทำให้ค่าตัวเล็กยากต่อการแยกเห็น.

![แผนภูมิเส้นใน PowerPoint แสดงจำนวนคำขอห้าครั้งบนแกนค่เชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะห่างแนวตั้งที่เท่าเดิมแสดงอัตราส่วนที่เท่าเทียมกัน. แต่ละช่วงมีคำขอเพิ่มสิบเท่าตรงจากช่วงก่อนหน้า, ดังนั้นจุดเหล่านั้นจะสร้างเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน 10. ป้ายแกนยังคงแสดงจำนวนคำขอเดิม.

![จำนวนคำขอห้าเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกอย่างเคร่งครัด. ตรวจสอบข้อมูลก่อนเปิดใช้. หากค่าศูนย์หรือค่าติดลบมีความหมาย, ให้ใช้สเกลเชิงเส้นหรือแสดงแยกออก. หากการยกเว้นค่าดังกล่าวเหมาะสมต่อการวิเคราะห์, ให้อธิบายเหตุผล. อย่าทดแทนค่าด้วยตัวเลขบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล. ค่าต่ำสุดหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน.

## **คำถามที่พบบ่อย**

**ฉันจะกำหนดค่าที่แกนหนึ่งตัดผ่านอีกแกน (การตัดแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการตัด. เพื่อระบุค่าตัดเชิงตัวเลข, ใช้ [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายจุดตัดแกนไปยังฐานที่เหมาะสมได้.

**ฉันจะจัดตำแหน่งป้ายเครื่องหมายกากบาทสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายกากบาทเอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); สิ่งเหล่านี้แยกจากการจัดตำแหน่งป้าย.