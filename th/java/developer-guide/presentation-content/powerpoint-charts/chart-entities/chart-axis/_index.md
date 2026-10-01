---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอโดยใช้ Java
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
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides for Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลข้อมูล."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for Java. เนื้อหาครอบคลุมค่าของแกนที่คำนวณ, การสลับแถวและคอลัมน์ของแผนภูมิ, การมองเห็นแกน, ระยะห่างของป้ายชื่อหมวดและติ๊กมาร์ค, หมวดวันที่และการจัดรูปแบบ, การหมุนหัวข้อ, การกำหนดตำแหน่งแกน, และหน่วยแสดงผล.

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [การนำเสนอ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่ด้วยข้อมูลเริ่มต้น. เรียก [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าของแกนที่คำนวณเพื่อให้การจัดวางแผนภูมิมีการอัปเดตล่าสุด.

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) สำหรับขอบเขตของแกน, และ [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) และ [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) สำหรับระยะห่างของติ๊กมาร์ค. [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างนี้เก็บค่าเหล่านี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ.

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อสลับบทบาทของซีรีส์และหมวดในข้อมูลแผนภูมิ. แต่ละหมวดเดิมจะกลายเป็นซีรีส์, และแต่ละซีรีส์เดิมจะกลายเป็นหมวด. สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5`, รวมถึงแถวหัวเรื่องและคอลัมน์หมวด, ก่อนการสลับแถวและคอลัมน์. ตัวอย่างบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวด.

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

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน.

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

## **ปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน. ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน.

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

## **เปลี่ยนแกนหมวด**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนหมวดประเภทวันที่หรือข้อความ. ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx`, ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเซลล์หมวดมีค่าตัวเลขวันที่จาก Excel. มันเปลี่ยนแกนแนวนอนเป็นแกนวันที่. การเรียกใช้ [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วยค่า `false`, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) ด้วยค่า `1`, และ [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วย `TimeUnitType.Months` จะวางติ๊กหลักในระยะห่างหนึ่งเดือน.

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

## **ควบคุมช่วงป้ายชื่อแกนหมวด**

เมื่อแผนภูมิมีหลายหมวด, ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหรือจุดข้อมูล. เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วยค่า `false`, จากนั้นส่งช่วงหมวดที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-int-). สำหรับหมวดข้อความในลำดับปกติ, การนับจะเริ่มจากหมวดแรก:

| ช่วง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวด 1, หมวด 2, หมวด 3, ... หมวด 24 |
| `2` | หมวด 1, หมวด 3, หมวด 5, ... หมวด 23 |
| `3` | หมวด 1, หมวด 4, หมวด 7, ... หมวด 22 |

ช่วง `3` จะแสดงป้ายที่สามต่อหนึ่ง, ทำให้มีสองป้ายถูกซ่อนไประหว่างป้ายที่แสดง. มันไม่ได้ลบคอลัมน์ที่สอดคล้องกัน. การจัดช่องว่างอัตโนมัติกำหนดช่วงตามพื้นที่ที่มี; ไม่ได้จำเป็นต้องแสดงทุกป้าย.

ติ๊กมาร์คมีการควบคุมแยกกัน. เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วยค่า `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-int-) เพื่อกำหนดช่วงของมัน. ตัวอย่างเช่น, `1` จะเก็บติ๊กมาร์คที่ทุกช่วงหมวดขณะที่ป้ายแสดงเพียงทุกสามหมวด. ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) พร้อมสไตล์ที่มองเห็นได้เพื่อเห็นผลลัพธ์. การเรียกตัวตั้งค่าอัตโนมัติใด ๆ ด้วยค่า `true` อีกครั้งจะทำให้แผนภูมิเลือกช่วงนั้นอีกครั้ง.

ตัวอย่างอิสระต่อไปนี้สร้าง 24 หมวดและหนึ่งซีรีส์, จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างป้ายแบบแมนนวลพร้อมติ๊กมาร์คอิสระ, และการคืนค่าการจัดช่องว่างอัตโนมัติ. สองสำเนาจะเก็บข้อมูลแผนภูดิดั้งเดิม. ไม่ต้องการไฟล์พรีเซนเทชันเข้ามา. ข้อความป้ายแนวนอนทำให้ความหนาแน่นแตกต่างเห็นได้ง่าย.

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

    // สไลด์ 2: แสดงป้ายทุกสามรายการ แต่คงติ๊กมาร์คสำหรับทุกหมวด.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเ�เลือกช่วงทั้งสองอีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการเรนเดอร์นี้, ป้ายหมวดที่สองจะแสดงและห่อเป็นสองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และเรนเดอร์.

![การจัดช่องว่างป้ายหมวดอัตโนมัติกับคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็น](category-axis-automatic.png)

**การจัดช่องว่างแบบแมนนวล (สไลด์ 2):** ป้ายที่สามแสดงในบรรทัดเดียว, ในขณะที่ติ๊กมาร์คยังคงอยู่ที่ทุกช่วงหมวด. คอลัมน์ทั้งหมด 24 คอลัมน์รวมถึงที่ไม่มีป้ายยังคงมองเห็นด้วยค่าที่เหมือนกัน. สไลด์ 3 คืนสภาพการแสดงผลแบบอัตโนมัติที่แสดงด้านบน.

![ช่วงป้ายหมวดแบบแมนนวลที่สามกับคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็น](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงการนับหมวดนี้สำหรับแกนหมวดประเภทข้อความ, เช่น แกนหมวดของแผนภูมิคอลัมน์, เส้น, พื้นที่, หรือแท่ง. ในแผนภูมิคอลัมน์, มันคือแกนแนวนอน. ในแผนภูมิบาร์แนวนอน, แกนหมวดอยู่แนวตั้ง, ดังนั้นให้ปรับตั้งค่านี้กับแกนที่คืนโดย [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--). การจัดช่องว่างติ๊กมาร์คยังใช้กับแกนซีรีส์ในแผนภูมิที่มี.

อย่าใช้การจัดช่องว่างป้ายหมวดเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า. บนแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) ระบุความแตกต่างของค่า: ตัวอย่างเช่น, หน่วยหลัก `10` จะสร้างติ๊กที่ 0, 10, 20, เป็นต้นเมื่อแกนเริ่มจากศูนย์. ช่วงป้ายหมวด `3` จะนับตำแหน่งหมวด, ไม่คำนึงถึงค่าข้อมูลของมัน. แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดข้อความ. สำหรับแกนวันที่, ใช้หน่วยหลักและสเกลตามเวลาเช่นอธิบายใน [เปลี่ยนแกนหมวด](#change-a-category-axis).

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวด**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าสี่ปีต่อปี. วันที่ถูกเก็บเป็นหมายเลขอนุกรม OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`), คำนวณเป็นจำนวนวันตั้งแต่วันที่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้. ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วยค่า `false`, และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้ายหมวดแสดงปีสี่หลักอย่างอิสระจากการจัดรูปแบบเซลล์.

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

## **ตั้งมุมการหมุนสำหรับหัวข้อแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) ด้วยค่า `true` บนแกนแนวตั้ง, ระบุข้อความหัวข้อ, และใช้ [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่หมุนหัวข้อ. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวข้อแกนค่าถูกหมุน 90 องศา.

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

## **ตั้งตำแหน่งแกนบนแกนหมวดหรือแกนค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่แกนค่าจะข้ามแกนหมวดระหว่างหมวดหรือที่ติ๊กมาร์คของหมวด. การตั้งค่านี้ใช้กับแกนหมวด. ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์.

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

## **ตั้งหน่วยแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อปรับสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) ตั้งเป็น `Millions`, ค่า 60,000,000 จะแสดงเป็น 60. ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลล้านกับแกนแนวตั้งของมัน.

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

## **FAQ**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งข้ามแกนอื่น (การข้ามแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการข้าม. เพื่อระบุค่าการข้ามเป็นตัวเลข, ใช้ [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-). การตั้งค่าเหล่านี้ทำให้คุณย้ายจุดข้ามของแกนไปยังฐานที่เหมาะสม.

**ฉันจะกำหนดตำแหน่งป้ายติ๊กสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) ด้วยการใช้ [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมติ๊กมาร์คเอง, ใช้ [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-); สิ่งเหล่านี้แยกจากการจัดตำแหน่งป้าย.