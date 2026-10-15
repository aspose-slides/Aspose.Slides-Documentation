---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอบน Android
linktitle: แกนแผนภูมิ
type: docs
url: /th/androidjava/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- บริหารแกน
- คุณสมบัติแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลภาพ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนแผนภูมิกับ Aspose.Slides สำหรับ Android ผ่าน Java ซึ่งครอบคลุมค่าที่คำนวณของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ช่วงของป้ายข้อความหมวดหมู่และเครื่องหมายติ๊ก วันที่และการจัดรูปแบบของหมวดหมู่ การหมุนหัวเรื่อง การวางตำแหน่งแกน หน่วยการแสดงผล และการสเกลลอการิธึม

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่ด้วยข้อมูลเริ่มต้น เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิมีความทันสมัย

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) เพื่อรับขีดจำกัดของแกน และ [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) และ [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) เพื่อรับช่วงของเครื่องหมายติ๊ก [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าต่าง ๆ เหล่านี้ในตัวแปรโลคัลและบันทึกแผนภูมิ

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อแลกเปลี่ยนบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ แต่ละหมวดหมู่เดิมจะกลายเป็นซีรีส์และแต่ละซีรีส์เดิมจะกลายเป็นหมวดหมู่ การเปลี่ยนแปลงนี้ทำให้การจัดกลุ่มข้อมูลเปลี่ยนไป; แต่ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อตั้งค่าข้อมูลเริ่มต้นให้กับ `Sheet1!A1:D5` รวมถึงแถวหัวและคอลัมน์หมวดหมู่ ก่อนทำการสลับแถวและคอลัมน์ จะบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่

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

## **กลับลำดับการพล็อตของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setPlotOrderReversed-boolean-) เพื่อกลับลำดับของแกนหมวดหมู่หรือค่า ตัวอย่างเช่น แผนภูมิกระบวนการแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับในแผ่นงาน: Planning, Development, Testing. การกลับลำดับแกนจะเปลี่ยนทิศทางการพล็อต; ไม่ได้เรียงหรือลำดับใหม่ข้อมูลในเวิร์กบุ๊ก เปรียบเทียบกับ [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) ที่แลกเปลี่ยนบทบาทของซีรีส์และหมวดหมู่

ตัวอย่างต่อไปนี้สร้างแผนภูมิกระบวนการแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์ จะบันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดหมู่ที่กลับลำดับ, และค่าที่กลับลำดับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกันและแต่ละสำเนาจะกลับลำดับแกนเพียงหนึ่งแกน

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
    // คงแกนค่าที่แนวนอนไว้ที่ด้านล่าง.
    categoryChart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum);

    // สไลด์ 3: กลับสเกลตัวเลขแนวนอนเท่านั้น.
    ISlide valueSlide = presentation.getSlides().addClone(slide);
    IChart valueChart = (IChart)valueSlide.getShapes().get_Item(0);
    valueChart.getAxes().getHorizontalAxis().setPlotOrderReversed(true);

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

การกลับลำดับแกนอาจทำให้แกนนอนที่ตั้งฉากย้ายไปด้านตรงข้ามของพื้นที่พล็อต [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) ควบคุมว่าตำแหน่งที่แกนอื่นตัดแกนที่กำหนดอยู่ที่ไหน ในสไลด์ 2 การเรียกด้วย `CrossesType.Maximum` บนแกนหมวดหมู่ที่กลับลำดับทำให้แกนค่าคู่ขนานอยู่ที่ด้านล่าง สำหรับจุดตัดที่กำหนดโดยเฉพาะ ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). ตรวจสอบการตั้งค่าการตัดเมื่อเปลี่ยนทิศทางโดยเฉพาะหากแผนภูมิมีจุดตัดที่กำหนดไว้แล้ว เรียก `setPlotOrderReversed` ด้วย `false` เพื่อคืนทิศทางการพล็อตปกติ; การตั้งค่าตัดเป็นเรื่องแยกจากกัน

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่ที่กลับลำดับ (สไลด์ 2) | ค่าที่กลับลำดับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิกระบวนการแนวนอนที่มีลำดับหมวดหมู่และแกนค่าที่เป็นปกติ](axis-order-normal.png) | ![แผนภูมิกระบวนการแนวนอนที่แสดงหมวดหมู่อยู่จากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิกระบวนการแนวนอนที่มีแกนค่ากลับลำดับและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| หมวดหมู่เรียงจากด้านล่างขึ้นบน; ค่าเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing เรียงจากบนลงล่าง ค่าและลำดับแถวของเวิร์กบุ๊กไม่เปลี่ยนแปลง. | หมวดหมู่คงลำดับปกติ; ค่าเพิ่มจากขวาไปซ้าย แกนหมวดหมู่ตัดที่ศูนย์ด้านขวา. |

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียกใช้ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน

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

เรียกใช้ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน

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

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx` โดยที่แผนภูมืเป็นรูปร่างแรกบนสไลด์แรกและเซลล์หมวดหมู่มีค่าตัวเลขของวันที่ใน Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การเรียกใช้ [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วยค่า `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) ด้วยค่า `1` และ [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วยค่า `TimeUnitType.Months` จะวางเครื่องหมายหลักที่ช่วงเวลาเป็นหนึ่งเดือน

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

## **ควบคุมช่วงระยะของป้ายแกนหมวดหมู่**

เมื่อแผนภูมิมีหมวดหมู่จำนวนมาก ให้ลดจำนวนป้ายแกนที่แสดงโดยไม่ต้องลบหมวดหมู่หรือจุดข้อมูล เรียกใช้ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วยค่า `false` จากนั้นส่งช่วงของหมวดหมู่ที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). สำหรับหมวดหมู่ข้อความในลำดับปกติ การนับจะเริ่มจากหมวดหมู่แรก:

| ช่วง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวดหมู่ 1, หมวดหมู่ 2, หมวดหมู่ 3, … หมวดหมู่ 24 |
| `2` | หมวดหมู่ 1, หมวดหมู่ 3, หมวดหมู่ 5, … หมวดหมู่ 23 |
| `3` | หมวดหมู่ 1, หมวดหมู่ 4, หมวดหมู่ 7, … หมวดหมู่ 22 |

ช่วง `3` จะแสดงป้ายทุกสามตำแหน่งและซ่อนสองตำแหน่งระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดช่องว่างอัตโนมัติเลือกช่วงตามพื้นที่ที่มีอยู่; ไม่ได้จำเป็นต้องแสดงทุกป้าย

เครื่องหมายติ๊กมีการควบคุมแยกต่างหาก เรียกใช้ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วยค่า `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) เพื่อกำหนดช่วงของเครื่องหมาย ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกช่วงของหมวดหมู่ในขณะที่ป้ายแสดงเฉพาะทุกสามหมวดหมู่ ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) พร้อมสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าอัตโนมัติใด ๆ อีกครั้งเป็น `true` จะทำให้แผนภูมิเลือกช่วงนั้นใหม่

ตัวอย่างต่อไปนี้เป็นตัวอย่างอิสระสร้างหมวดหมู่ 24 รายการและหนึ่งซีรีส์ จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างป้ายแบบแมนนวลพร้อมเครื่องหมายติ๊กอิสระ, และการคืนค่าการจัดช่องว่างอัตโนมัติ สองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม ไม่จำเป็นต้องมีการนำเสนออินพุต ข้อความป้ายแนวนอนทำให้ความหนาแน่นแตกต่างกันชัดเจน

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

    // สไลด์ 3: ให้แผนภูมิเ�เลือกช่วงทั้งสองใหม่อีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายหมวดหมู่ทุกสองตำแหน่งจะแสดงและตัดบรรทัดเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ ฟอนท์ และเรนเดอร์

![การจัดช่องว่างป้ายหมวดหมู่อัตโนมัติกับคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การจัดช่องว่างแบบแมนนวล (สไลด์ 2):** ป้ายทุกสามตำแหน่งจะแสดงบนบรรทัดเดียวในขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วงของหมวดหมู่ คอลัมน์ทั้งหมด 24 คอลัมน์ รวมถึงคอลัมน์ที่ไม่มีป้าย ยังคงมองเห็นได้พร้อมค่าที่เหมือนกัน สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติตามที่แสดงข้างต้น

![ช่วงป้ายหมวดหมู่มือถือ 3 คอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงการนับหมวดหมู่นี้สำหรับแกนหมวดหมู่แบบข้อความ เช่น แกนหมวดหมู่ของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิกระบวนการแนวนอนแกนหมวดหมู่เป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับแกนที่ส่งคืนจาก [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). การจัดช่องว่างเครื่องหมายติ๊กยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์

ห้ามใช้การจัดช่องว่างป้ายหมวดหมู่เพื่อกำหนดสเกลเชิงจำนวนของแกนค่า บนแกนค่า [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) ระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มจากศูนย์ ช่วงป้ายหมวดหมู่ `3` จะนับตำแหน่งของหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดหมู่แบบข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายใน [เปลี่ยนแกนหมวดหมู่](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยค่าปีสี่ค่า วันที่ถูกเก็บเป็นเลขซีเรียล OLE Automation ในเวิร์กชีตแรก (อินดكس `0`) ซึ่งคำนวณเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้ ปฏิทินทั้งสองใช้ UTC และถูกเคลียร์ก่อนตั้งค่าวันที่เพื่อให้การบันทึกเวลาออมแสงและเวลาปัจจุบันไม่มีผลต่อการคำนวณ ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วย `false`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้ายหมวดหมู่แสดงปีสี่หลักโดยไม่ขึ้นกับการจัดรูปแบบเซลล์

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

## **ตั้งมุมการหมุนสำหรับหัวข้อแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) ด้วยค่า `true` บนแกนแนวตั้ง ให้ข้อความหัวเรื่องและใช้ [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนหัวเรื่อง มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยหมุนหัวข้อแกนค่าตามแนวตั้งเป็น 90 องศา

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

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่าแกนค่าตัดแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่เครื่องหมายติ๊กของหมวดหมู่ การตั้งค่านี้ใช้กับแกนหมวดหมู่ ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

## **ตั้งหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อปรับสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ตั้งเป็น `Millions` ค่าที่ 60 000 000 จะแสดงเป็น 60 ตัวอย่างนี้สร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้ง

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

แกนค่าลอการิทึมเป็นประโยชน์เมื่อค่าบวกกระจายหลายระดับจำนวน ตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1 000, 10 000, และ 100 000 คำขอในห้าช่วง เวลาเชิงเส้นค่าต่ำจะจู่กันอยู่ใกล้ศูนย์ สเกลลอการิทึมทำให้การเติบโตสัมพันธ์ง่ายต่อการเปรียบเทียบ: ระยะเท่ากันแสดงอัตราส่วนเท่ากันไม่ใช่ความแตกต่างเชิงจำนวน

เรียก [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) ด้วยค่า `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) เพื่อเลือกฐาน การทำเช่นนี้เปลี่ยนวิธีที่ค่าที่มีอยู่แสดง ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหาก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าถูกส่งคืนจาก [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--). สำหรับแผนภูมิกระบวนการแนวนอน แกนค่าถูกส่งคืนจาก [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งคู่ ห้ามใช้สเกลลอการิทึมกับแกนหมวดหมู่

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX ใช้ฐานตั้งแต่ `2` ถึง `1000` ทั้งหมด รวมถึงฐานเศษส่วนอย่าง `2.5` ด้วย ฐาน `10` จะทำให้พลังงานต่อเนื่องเช่น 10, 100, 1 000, 10 000 มีระยะห่างเท่าเทียมกัน

### **เปรียบเทียบการสเกลแบบเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้เป็นตัวอย่างอิสระสร้างแผนภูมิเส้นด้วยจำนวนคำขอห้าชุดบนสไลด์แรก จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์รักษาข้อมูลเดียวกัน

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

    // เก็บสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
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

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งเท่ากันแสดงความแตกต่างของจำนวนคำขอที่เท่าเทียมกัน ค่าที่ใหญ่ที่สุดครอบครองพื้นที่แผนภูมิ ทำให้ค่าต่ำกว่าแยกกันได้ยาก

![แผนภูมิเส้นใน PowerPoint แสดงจำนวนคำขอห้าค่าบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งเท่ากันแสดงอัตราส่วนเท่าเทียม ทุกช่วงมีจำนวนคำขอเป็นสิบเท่าของช่วงก่อนหน้า ทำให้จุดสร้างเส้นตรงขึ้นบนสเกลฐาน 10 แกนป้ายยังคงแสดงจำนวนคำขอดั้งเดิม

![จำนวนคำขอห้าค่าที่เดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าลบ**

สเกลลอการิทึมแสดงได้เฉพาะค่าบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าลบมีความหมาย ให้ใช้สเกลเชิงเส้นหรือแสดงแยก หากการยกเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์ ให้อธิบายเหตุผล อย่าแทนที่ค่าด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือค่าสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกเช่นกัน

## **FAQ**

**ฉันจะตั้งค่าสำหรับตำแหน่งที่แกนหนึ่งตัดแกนอื่น (การตัดแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการตัด หากต้องระบุค่าตัดเชิงตัวเลข ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายตำแหน่งการตัดแกนไปยังฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งป้ายเครื่องหมายติ๊กสัมพันธ์กับแกนได้อย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายติ๊กเอง ให้ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งป้าย.