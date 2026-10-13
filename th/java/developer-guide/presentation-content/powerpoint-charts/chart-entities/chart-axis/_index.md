---
title: กำหนดค่าแกนแผนภูมิในงานนำเสนอด้วย Java
linktitle: แกนแผนภูมิ
type: docs
url: /th/java/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- กำหนดค่าแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- หัวข้อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ Java เพื่อกำหนดค่าแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิด้วย Aspose.Slides for Java. มันครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ช่วงเวลาของป้ายกำกับประเภทและเครื่องหมายแบ่งช่อง, ประเภทและการจัดรูปแบบวันที่, การหมุนหัวเรื่อง, การกำหนดตำแหน่งแกน, หน่วยการแสดงผล, และการปรับสเกลลอการิทึม.

## **รับค่ามากที่สุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเพิ่ม area chart ด้วยข้อมูลเริ่มต้น. เรียก [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) เพื่อกำหนดขอบเขตของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) และ [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) เพื่อช่วงของเครื่องหมายแบ่งช่อง. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--)และ [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) ให้สเกลหน่วยเวลา, ซึ่งมีความสำคัญต่อแกนวันที่. ตัวอย่างนี้เก็บค่าเหล่านี้ไว้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ.

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อสลับบทบาทของ series และ category ในข้อมูลแผนภูมิ. แต่ละ category เดิมจะกลายเป็น series, และแต่ละ series เดิมจะกลายเป็น category. การทำเช่นนี้เปลี่ยนการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5`, รวมทั้งแถวหัวตารางและคอลัมน์ category, ก่อนสลับแถวและคอลัมน์. มันบันทึกแผนภูมิที่มีสี่ series และสาม category.

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

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน.

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

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน.

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

## **เปลี่ยนแกน Category**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนประเภทวันที่หรือข้อความ. ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx`, ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ประเภทมีค่าตวันที่เป็นตัวเลข Excel. มันเปลี่ยนแกนแนวนอนเป็นแกนวันที่. เรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วยค่า `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) ด้วยค่า `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วย `TimeUnitType.Months` เพื่อวางเครื่องหมายหลักที่ช่วงเดือนละหนึ่งครั้ง.

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

## **ควบคุมช่วงเวลาของป้ายกำกับแกน Category**

เมื่อแผนภูมิมีหลาย category, ลดจำนวนป้ายกำกับแกนที่แสดงโดยไม่ต้องลบ category หรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วยค่า `false`, แล้วส่งค่าช่วง category ที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-). สำหรับ category แบบข้อความในลำดับปกติ, การนับเริ่มจาก category แรก:

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

ช่วง `3` จะแสดงป้ายทุกสามรายการ, ปล่อยให้สองป้ายระหว่างที่แสดงอยู่ถูกซ่อน. มันไม่ลบคอลัมน์ที่สอดคล้องกัน. การเว้นระยะอัตโนมัติเลือกช่วงตามพื้นที่ที่มี; ไม่ได้บังคับให้แสดงทุกป้าย.

เครื่องหมายแบ่งช่องมีการควบคุมแยกกัน. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วยค่า `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) เพื่อกำหนดช่วง. ตัวอย่างเช่น, `1` จะรักษาเครื่องหมายแบ่งช่องที่ทุกช่วง category แม้ว่าป้ายจะปรากฏเฉพาะทุกสาม category. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) ด้วยสไตล์ที่มองเห็นได้เพื่อดูผล. การตั้งค่าใดๆ ที่เป็นอัตโนมัติเป็น `true` อีกครั้งจะทำให้แผนภูมิกำหนดช่วงนั้นใหม่อีกครั้ง.

ตัวอย่างที่เป็นอิสระต่อกันนี้สร้าง 24 category และ series หนึ่ง, แล้วบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การเว้นระยะอัตโนมัติ, การเว้นระยะด้วยมือพร้อมเครื่องหมายแบ่งช่องแยกจากกัน, และการคืนค่าเว้นระยะอัตโนมัติ. สองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม. ไม่จำเป็นต้องมีไฟล์นำเข้าตัวอย่าง. ข้อความป้ายแนวนอนทำให้ความหนาแน่นแตกต่างกันเห็นได้ชัด.

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

    // สไลด์ 2: แสดงป้ายทุกสามรายการ, แต่ยังคงมีเครื่องหมายแบ่งช่องสำหรับแต่ละประเภท.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมเลือกช่วงเวลาทั้งสองใหม่อีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การเว้นระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้, ป้ายชื่อ category ทุกสองรายการจะแสดงและขึ้นบรรทัดใหม่สองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และตัวเรนเดอร์.

![การเว้นระยะป้ายกำกับประเภทโดยอัตโนมัติที่แสดงคอลัมน์ทั้งหมด 24 คอลัมน์](category-axis-automatic.png)

**การเว้นระยะด้วยมือ (สไลด์ 2):** ป้ายทุกสามรายการจะแสดงบนหนึ่งบรรทัด, ในขณะที่เครื่องหมายแบ่งช่องยังคงอยู่ทุกช่วง category. คอลัมน์ทั้งหมด 24 คอลัมน์, รวมถึงที่ไม่มีป้าย, ยังคงแสดงด้วยค่าที่เหมือนกัน. สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงข้างบน.

![การเว้นระยะป้ายกำกับประเภทด้วยมือที่สามกับคอลัมน์ทั้งหมด 24 คอลัมน์ที่แสดง](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวน category นี้สำหรับแกนประเภทข้อความ, เช่น แกน category ของแผนภูมิคอลัมน์, เส้น, พื้นที่, หรือแถบ. ในแผนภูมิคอลัมน์, นั่นคือแกนแนวนอน. ในแผนภูมิแถวนอน, แกน category อยู่ในแนวตั้ง, ดังนั้นให้ใช้การตั้งค่านี้กับแกนที่คืนค่าจาก [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). การเว้นระยะเครื่องหมายแบ่งช่องยังใช้ได้กับแกน series ในแผนภูมิที่มีแกนดังกล่าว.

อย่าใช้การเว้นระยะป้าย category เพื่อกำหนดสเกลเชิงตัวเลขของแกนค่. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) กำหนดความแตกต่างของค่า: เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มที่ศูนย์. ช่วงป้าย category `3` จะนับตำแหน่ง category ไม่คำนึงถึงค่าข้อมูล. แผนภูมิกระจายและฟองใช้แกนค่าแทนแกน category ข้อความ. สำหรับแกนวันที่, ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis).

## **ตั้งค่ารูปแบบวันที่สำหรับค่ากับแกน Category**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเบี่ยมต้นด้วยค่ารายปีสี่ค่า. วันที่ถูกเก็บเป็นเลขฐาน OLE Automation ใน worksheet แรก (ดัชนี `0`), คิดเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วยค่า `false`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้าย category แสดงปีสี่หลักโดยอิสระจากรูปแบบเซลล์.

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

## **ตั้งค่ามุมการหมุนสำหรับหัวข้อแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) ด้วยค่า `true` บนแกนแนวตั้ง, ใส่ข้อความหัวเรื่อง, และใช้ [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนหัวเรื่อง. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวแกนค่าถูกหมุน 90 องศา.

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

## **ตั้งตำแหน่งแกนบนแกน Category หรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่าแกนค่าตัดแกน category ระหว่าง category หรือที่เครื่องหมายแบ่งช่องของ category. การตั้งค่านี้ใช้กับแกน category. ตัวอย่างตั้งค่าเป็น `true` บนแกน category แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์.

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

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อปรับสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) ตั้งเป็น `Millions`, ค่า 60,000,000 จะปรากฏเป็น 60. ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลล้านบนแกนแนวตั้ง.

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

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายระดับลำดับ. ตัวอย่างเช่น บริการอาจได้รับ 10, 100, 1,000, 10,000 และ 100,000 คำขอในห้าช่วงเวลา. บนสเกลเชิงเส้น, ค่าที่เล็กกว่าจะอยู่ใกล้ศูนย์กัน. สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพันธ์ง่ายขึ้น: ระยะห่างที่เท่ากันแทนสัดส่วนที่เท่ากันแทนความต่างที่เท่าเดิม.

เรียก [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) ด้วยค่า `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) เพื่อเลือกฐาน. การทำเช่นนี้เปลี่ยนวิธีแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหากที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล.

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าถูกคืนค่าจาก [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). สำหรับแผนภูมิแถวนอน, แกนค่าถูกคืนค่าจาก [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--). แผนภูมิกระจายและฟองมีสองแกนค่า, จึงเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง. อย่าใช้สเกลลอการิทึมกับแกน category.

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX, สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5`. ด้วยฐาน `10`, พลังยกกำลังต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะมีระยะห่างเท่าเทียมกัน.

### **เปรียบเทียบสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าครั้งบนสไลด์แรก, แล้วคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง. สไลด์ทั้งสองรักษาข้อมูลเดิมไว้.

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

    // คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนเฉพาะสเกลแกนค่าของสำเนา.
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

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งที่เท่ากันแทนความแตกต่างที่เท่าเดิมของจำนวนคำขอ. ค่าที่ใหญ่ที่สุดครอบงำแผนภูมิทำให้ค่าที่เล็กกว่าดูแยกยาก.

![แผนภูมิเส้นใน PowerPoint แสดงจำนวนคำขอห้าครั้งบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งที่เท่ากันแทนอัตราส่วนที่เท่าเดิม. แต่ละช่วงมีจำนวนคำขอเพิ่มขึ้นเท่าตัวสิบเท่าของช่วงก่อนหน้า, จึงทำให้จุดสร้างเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน 10. ป้ายแกนยังคงแสดงจำนวนคำขอเดิม.

![จำนวนคำขอห้าครั้งเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าเป็นศูนย์และค่าลบ**

สเกลลอการิทึมสามารถแสดงค่าเป็นบวกอย่างเคร่งครัดเท่านั้น. ตรวจสอบข้อมูลก่อนเปิดใช้งาน. หากค่าศูนย์หรือค่าลบมีความหมาย, ควรใช้สเกลเชิงเส้นหรือแสดงแยกต่างหาก. หากการละเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์, ให้ชี้แจงเหตุผล. อย่าแทนที่ค่าเหล่านั้นด้วยตัวเลขบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล. ค่าต่ำสุดหรือค่าสูงสุดใด ๆ ที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกเช่นกัน.

## **FAQ**

**ฉันจะตั้งค่าตำแหน่งที่แกนหนึ่งตัดกันกับอีกแกน (axis crossing) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการตัดกัน. หากต้องการระบุค่าตัวเลขของการตัดกัน, ใช้ [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). การตั้งค่าเหล่านี้ทำให้คุณย้ายจุดตัดแกนไปยังพื้นฐานที่เหมาะสม.

**ฉันจะกำหนดตำแหน่งป้ายแบ่งช่องสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายแบ่งช่องเอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งป้าย.