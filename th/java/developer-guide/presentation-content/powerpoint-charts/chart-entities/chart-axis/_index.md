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
- ดูแลแกน
- คุณสมบัติเ�แกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพประกอบ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิด้วย Aspose.Slides for Java ซึ่งครอบคลุมค่าของแกนที่คำนวณ, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ช่วงเวลาของป้ายชื่อประเภทและตำแหน่งเครื่องหมายบรรทัด, ประเภทวันที่และการจัดรูปแบบ, การหมุนชื่อเรื่อง, การกำหนดตำแหน่งแกน, หน่วยแสดงผล, และการสเกลแบบลอการิทึม

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่ด้วยข้อมูลค่าเริ่มต้น. เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าของแกนที่คำนวณเพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) เพื่อรับขอบเขตของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) และ [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) เพื่อรับช่วงของเครื่องหมายบรรทัด. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) จะให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างนี้เก็บค่าต่างๆ เข้าไปในตัวแปรท้องถิ่นและบันทึกแผนภูมิ.

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อสลับบทบาทของซีรีส์และประเภทในข้อมูลแผนภูมิ. แต่ละประเภทเดิมจะกลายเป็นซีรีส์, และแต่ละซีรีส์เดิมจะกลายเป็นประเภท. สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อผูกข้อมูลค่าเริ่มต้นกับ `Sheet1!A1:D5`, รวมถึงแถวหัวเรื่องและคอลัมน์ประเภท, ก่อนสลับแถวและคอลัมน์. ตัวอย่างบันทึกแผนภูมิที่มีสี่ซีรีส์และสามประเภท.

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

## **ย้อนลำดับการวางกราฟของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) เพื่อย้อนลำดับของแกนประเภทหรือค่า. ตัวอย่างเช่น, แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับในแผ่นงาน: Planning, Development, Testing. การย้อนแกนจะเปลี่ยนทิศทางการวางกราฟ; ไม่ได้ทำการจัดเรียงหรือเปลี่ยนแปลงข้อมูลในเวิร์กบุ๊ก. ในการเปรียบเทียบ, [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) จะสลับบทบาทของซีรีส์และประเภท.

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์. มันบันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, ประเภทที่ย้อนกลับ, และค่าที่ย้อนกลับ. ทุกสำเนาใช้ชุดข้อมูลเดียวกัน, และแต่ละสำเนาจะย้อนกลับเฉพาะหนึ่งแกน.

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

    // สไลด์ 2: แสดงประเภทแรกที่ด้านบน.
    ISlide categorySlide = presentation.getSlides().addClone(slide);
    IChart categoryChart = (IChart)categorySlide.getShapes().get_Item(0);
    categoryChart.getAxes().getVerticalAxis().setPlotOrderReversed(true);
    // คงแกนค่าตามแนวนอนไว้ที่ด้านล่าง.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // สไลด์ 3: ย้อนไปด้านละกลับสเกลตัวเลขแนวนอนเท่านั้น.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การย้อนแกนอาจย้ายแกนตั้งฉากไปยังด้านตรงข้ามของพล็อต. [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) ควบคุมตำแหน่งที่แกนอื่นตัดกับแกนที่กำลังตั้งค่า. ในสไลด์ที่ 2, การเรียกด้วย `CrossesType.Maximum` บนแกนประเภทที่ย้อนกลับจะทำให้แกนค่าที่แนวนอนอยู่ที่ด้านล่าง. หากต้องการจุดตัดที่เฉพาะเจาะจง, ใช้ [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). ตรวจสอบการตั้งค่าตัดเมื่อเปลี่ยนทิศทาง, โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดที่กำหนดเองอยู่แล้ว. เรียก `setPlotOrderReversed` ด้วย `false` เพื่อคืนทิศทางการวางกราฟปกติ; การตั้งค่าตัดเป็นสิ่งแยกจากกัน.

| ลำดับปกติ (สไลด์ 1) | ประเภทที่ย้อนกลับ (สไลด์ 2) | ค่าที่ย้อนกลับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับประเภทและแกนค่าตามปกติ](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงประเภทจากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่าย้อนกลับและศูนย์อยู่ทางขวา](axis-order-values-reversed.png) |
| ประเภทวิ่งจากล่างขึ้นบน; ค่ามีการเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing วิ่งจากบนลงล่าง. ค่และลำดับแถวของเวิร์กบุ๊กไม่ได้เปลี่ยนแปลง. | ประเภทคงลำดับปกติ; ค่ามีการเพิ่มจากขวาไปซ้าย. แกนประเภทตัดที่ศูนย์ด้านขวา. |

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยมีแกนแนวตั้งซ่อนอยู่.

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

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยมีแกนแนวนอนซ่อนอยู่.

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

## **เปลี่ยนแกนประเภท**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนประเภทเป็นวันที่หรือข้อความ. ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx`, ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ประเภทมีค่าตัวเลขของวันที่ Excel. มันจะเปลี่ยนแกนแนวนอนเป็นแกนวันที่. การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วย `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) ด้วย `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วย `TimeUnitType.Months` จะวางเครื่องหมายหลักที่ช่วงหนึ่งเดือน.

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

## **ควบคุมช่วงป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลายประเภท, ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ลบประเภทหรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วย `false`, จากนั้นส่งช่วงประเภทที่ต้องการไปที่ [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). สำหรับประเภทข้อความในลำดับปกติ, การนับเริ่มจากประเภทแรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | ประเภท 1, ประเภท 2, ประเภท 3, ... ประเภท 24 |
| `2` | ประเภท 1, ประเภท 3, ประเภท 5, ... ประเภท 23 |
| `3` | ประเภท 1, ประเภท 4, ประเภท 7, ... ประเภท 22 |

ช่วง `3` จะทำให้แสดงทุกป้ายที่สาม, ป้ายสองอันระหว่างป้ายที่แสดงจะถูกซ่อนไว้. มันไม่ลบคอลัมน์ที่สอดคล้อง. การเว้นวรรคอัตโนมัติจะเลือกช่วงตามพื้นที่ที่มี; ไม่ได้จำเป็นต้องแสดงทุกป้าย.

เครื่องหมายบรรทัดมีการควบคุมแยกต่างหาก. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วย `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) เพื่อกำหนดช่วงของพวกมัน. ตัวอย่างเช่น, `1` จะทำให้มีเครื่องหมายบรรทัดที่ทุกช่วงประเภทในขณะที่ป้ายชื่อปรากฏเฉพาะทุกประเภทที่สาม. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) กับสไตล์ที่มองเห็นเพื่อให้เห็นผล. การเรียกตั้งค่าการเว้นวรรคอัตโนมัติใด‑ ๆ ด้วย `true` อีกครั้งจะทำให้แผนภูมิเกิดการเลือกช่วงนั้นใหม่.

ตัวอย่างที่สมบูรณ์ต่อไปนี้สร้าง 24 ประเภทและหนึ่งซีรีส์, จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การเว้นวรรคอัตโนมัติ, การเว้นวรรคป้ายชื่อด้วยตนเองพร้อมเครื่องหมายบรรทัดอิสระ, และการคืนค่าเป็นการเว้นวรรคอัตโนมัติ. สำเนาสองฉบับคงข้อมูลแผนภูมิเบื้องต้นไว้. ไม่จำเป็นต้องมีการนำเสนอเข้า. ข้อความป้ายแนวนอนทำให้เห็นความแตกต่างของความหนาแน่นได้ง่าย.

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

    // สไลด์ 2: แสดงป้ายชื่อทุกสามรายการ แต่คงเครื่องหมายบรรทัดไว้สำหรับทุกประเภท.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมเลือกช่วงทั้งสองใหม่อีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การเว้นวรรคอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้, ทุกป้ายชื่อประเภทที่สองจะแสดงและห่อเป็นสองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และตัวเรนเดอร์.

![การเว้นวรรคป้ายชื่อประเภทอัตโนมัติโดยมองเห็นคอลัมน์ทั้งหมด 24 คอลัมน์](category-axis-automatic.png)

**การเว้นวรรคด้วยตนเอง (สไลด์ 2):** ทุกป้ายที่สามจะแสดงบนหนึ่งบรรทัด, ในขณะที่เครื่องหมายบรรทัดยังคงอยู่ที่ทุกช่วงประเภท. ทั้ง 24 คอลัมน์, รวมถึงคอลัมน์ที่ไม่มีป้าย, ยังคงมองเห็นด้วยค่าที่เดียวกัน. สไลด์ 3 คืนค่าเป็นการแสดงผลอัตโนมัติที่แสดงด้านบน.

![ช่วงป้ายชื่อประเภทแบบมือของสามโดยมองเห็นคอลัมน์ทั้งหมด 24 คอลัมน์](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนประเภทนี้สำหรับแกนประเภทข้อความ, เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง. ในแผนภูมิคอลัมน์, มันเป็นแกนแนวนอน. ในแผนภูมิแท่งแนวนอน, แกนประเภทอยู่แนวตั้ง, ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับแกนที่คืนค่าจาก [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). การเว้นวรรคเครื่องหมายบรรทัดยังใช้กับแกนซีรีส์ในแผนภูมิที่มี.

ห้ามใช้การเว้นวรรคป้ายชื่อประเภทเพื่อกำหนดสเกลตัวเลขของแกนค่า. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) ระบุความแตกต่างของค่า: ตัวอย่างเช่น, หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มจากศูนย์. ช่วงป้ายชื่อประเภท `3` จะนับตำแหน่งประเภท, โดยไม่คำนึงถึงค่าข้อมูลของพวกมัน. แผนภูกิกระจายและฟองใช้แกนค่าแทนแกนประเภทข้อความ. สำหรับแกนวันที่, ใช้หน่วยหลักและสเกลตามเวลาเช่นอธิบายใน [Change a Category Axis](#change-a-category-axis).

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิค่าเริ่มต้นด้วยสี่ค่าปี. วันที่ถูกเก็บเป็นเลขอนุกรม OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`), คำนวณเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วย `false`, และส่ง `yyyy` ไปที่ [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้ายชื่อประเภทแสดงปีสี่หลักโดยอิสระจากการฟอร์แมตของเซลล์.

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

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) ด้วย `true` บนแกนแนวตั้ง, ให้ข้อความชื่อ, และใช้ [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนชื่อ. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่ชื่อแกนค่าถูกหมุน 90 องศา.

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

## **ตั้งค่าตำแหน่งแกนบนแกนประเภทหรือแกนค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่าด้านแกนค่าจะตัดผ่านแกนประเภทระหว่างประเภทหรือที่เครื่องหมายบรรทัดของประเภท. การตั้งค่านี้ใช้กับแกนประเภท. ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์.

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

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) ตั้งเป็น `Millions`, ค่า 60,000,000 จะแสดงเป็น 60. ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้งของมัน.

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

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกมีขนาดหลายลำดับของกำลัง. ตัวอย่างเช่น, บริการอาจรับ 10, 100, 1,000, 10,000, และ 100,000 คำขอในห้าวระยะ. บนสเกลเชิงเส้น, ค่าที่เล็กกว่าจะอยู่ใกล้ศูนย์กัน. สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพัทธ์ง่ายขึ้น: ระยะเท่ากันแสดงอัตราส่วนที่เท่ากันแทนความแตกต่างที่เท่ากัน.

เรียก [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) ด้วยค่า `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) เพื่อเลือกฐาน. การทำเช่นนี้เปลี่ยนวิธีการแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มเป็นการแสดงความสัมพันธ์ที่ฟิตกับข้อมูลและเป็นฟีเจอร์แยกออก.

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าถูกคืนค่าจาก [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). สำหรับแผนภูมิแท่งแนวนอน, จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). แผนภูมิกระจายและฟองมีแกนค่าสองแกน, ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง. อย่าใช้สเกลลอการิทึมกับแกนประเภท.

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX, ใช้ฐานตั้งแต่ `2` ถึง `1000` รวม; รองรับฐานเศษส่วนเช่น `2.5`. ด้วยฐาน `10`, พลังต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะมีระยะห่างเท่ากัน.

### **เปรียบเทียบสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างที่สมบูรณ์ต่อไปนี้สร้างแผนภูมิเส้นที่มีห้าจำนวนคำขอบนสไลด์แรก, จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง. ทั้งสองสไลด์คงข้อมูลเดิม.

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

    // คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลของแกนค่าของสำเนาเท่านั้น.
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

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งเท่ากันแสดงความแตกต่างของจำนวนคำขอ. ค่าที่ใหญ่ที่สุดครอบงำแผนภูมิ, ทำให้ค่าที่เล็กกว่าแยกแยะได้ยาก.

![แผนภูมิเส้นใน PowerPoint แสดงห้าจำนวนคำขอบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งเท่ากันแสดงอัตราส่วนที่เท่าเทียม. แต่ละช่วงมีจำนวนคำขอเพิ่มสิบเท่าจากช่วงก่อนหน้า, ดังนั้นจุดต่าง ๆ จะเป็นเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน 10. ป้ายแกนยังคงแสดงจำนวนคำขอเดิม.

![ห้าจำนวนคำขอเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกอย่างเคร่งครัด. ตรวจสอบข้อมูลก่อนเปิดใช้งาน. หากค่าศูนย์หรือค่าติดลบมีความหมาย, ให้รักษาสเกลเชิงเส้นหรือแสดงแยกต่างหาก. หากการละเว้นค่าดังกล่าวเหมาะกับการวิเคราะห์, ให้อธิบายสาเหตุ. อย่าแทนที่ค่าดังกล่าวด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ, เนื่องจากทำให้ข้อมูลเปลี่ยนความหมาย. ค่าเริ่มต้นหรือค่าสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน.

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดกับอีกแกน (การตัดแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการตัด. หากต้องการระบุค่าตัดเชิงตัวเลข, ใช้ [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายการตัดแกนไปยังเส้นฐานที่เหมาะสม.

**ฉันจะตำแหน่งป้ายเครื่องหมายบรรทัดสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายบรรทัดเอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); สิ่งเหล่านี้แยกจากการตำแหน่งป้ายชื่อ.