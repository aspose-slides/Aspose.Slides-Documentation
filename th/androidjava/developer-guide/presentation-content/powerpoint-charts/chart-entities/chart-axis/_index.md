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
- บริหารจัดการแกน
- คุณสมบัติของแกน
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
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ Android ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลข้อมูล"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for Android ผ่าน Java ครอบคลุมค่าที่คำนวณของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การมองเห็นแกน ช่วงของป้ายชื่อประเภทและเครื่องหมายติก วันที่และการจัดรูปแบบ การหมุนชื่อเรื่อง การกำหนดตำแหน่งแกน หน่วยการแสดงผล และการสเกลแบบลอการิทึม

## **รับค่ามากที่สุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่พร้อมข้อมูลเริ่มต้น เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิเป็นข้อมูลล่าสุด

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) สำหรับขอบเขตของแกน และ [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) และ [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) สำหรับช่วงของเครื่องหมายติก [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างเก็บค่าต่าง ๆ เหล่านี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อสลับบทบาทของซีรีส์และประเภทในข้อมูลแผนภูมิ แต่ละประเภทเดิมจะกลายเป็นซีรีส์และแต่ละซีรีส์เดิมจะกลายเป็นประเภท สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมแถวหัวและคอลัมน์ประเภท ก่อนสลับแถวและคอลัมน์ จากนั้นบันทึกแผนภูมิที่มีสี่ซีรีส์และสามประเภท

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

## **ทำให้แกนแนวตั้งหายไปสำหรับแผนภูมิรูปเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิรูปเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน

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

## **ทำให้แกนแนวนอนหายไปสำหรับแผนภูมิรูปเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิรูปเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน

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

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนประเภทเป็นวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` ซึ่งมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเซลล์ประเภทมีค่าตัวเลขของวันที่ Excel มันเปลี่ยนแกนแนวนอนให้เป็นแกนวันที่ การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วย `false` , [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) ด้วย `1` และ [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วย `TimeUnitType.Months` จะทำให้เครื่องหมายหลักปรากฏทุกหนึ่งเดือน

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

## **ควบคุมช่วงของป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลายประเภท ให้ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ต้องลบประเภทหรือจุดข้อมูล เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วย `false` จากนั้นส่งช่วงประเภทที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) สำหรับประเภทข้อความตามลำดับปกติ การนับจะเริ่มจากประเภทแรก:

| ช่วง | ป้ายกำกับที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

ช่วง `3` จะแสดงป้ายกำกับทุกสามรายการ โดยมีสองป้ายซ่อนไว้ระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การเว้นช่องอัตโนมัติเ�เลือกช่วงตามพื้นที่ที่มีอยู่; ไม่ได้บังคับให้แสดงทุกป้าย

เครื่องหมายติกมีการควบคุมแยกต่างหาก เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วย `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) เพื่อกำหนดช่วงของมัน ตัวอย่างเช่นค่า `1` จะทำให้มีเครื่องหมายติกทุกช่วงประเภทในขณะที่ป้ายชื่อปรากฏเพียงทุกสามประเภท ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) พร้อมสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าอัตโนมัติใด ๆ อีกครั้งด้วยค่า `true` จะให้แผนภูมิเลือกช่วงนั้นอีกครั้ง

ตัวอย่างอิสระต่อไปนี้สร้างประเภท 24 รายการและซีรีส์หนึ่งรายการ แล้วบันทึกสไลด์สามสไลด์ใน `CategoryAxisIntervals.pptx`: การเว้นช่องอัตโนมัติ, การเว้นช่องป้ายชื่อแบบแมนนวลพร้อมเครื่องหมายติกอิสระ, และการคืนค่าเว้นช่องอัตโนมัติ สองสำเนาจะรักษาข้อมูลแผนภูมิเก่าไว้ ไม่จำเป็นต้องมีการนำเสนอเข้า ป้ายข้อความแนวนอนทำให้เห็นความหนาแน่นแตกต่างได้ง่าย

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

    // Slide 2: แสดงป้ายทุกสามรายการ แต่คงเครื่องหมายติกสำหรับทุกประเภท.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Slide 3: ให้แผนภูมิเ�เลือกช่วงทั้งสองใหม่อีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การเว้นช่องอัตโนมัติ (สไลด์ 1):** ในการเรนเดอร์นี้ ป้ายชื่อประเภทที่แสดงจะเป็นทุก ๆ สองรายการและห่อบรรทัดสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, แบบอักษรและตัวเรนเดอร์

![การจัดช่องว่างป้ายชื่อประเภทอัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การเว้นช่องแบบแมนนวล (สไลด์ 2):** ป้ายชื่อทุกสามรายการจะแสดงบนบรรทัดเดียวในขณะที่เครื่องหมายติกยังคงอยู่ทุกช่วงประเภท คอลัมน์ทั้งหมด 24 คอลัมน์รวมถึงที่ไม่มีป้ายชื่อก็ยังมองเห็นได้ด้วยค่าที่เหมือนกัน สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงข้างบน

![การจัดช่องว่างป้ายชื่อประเภทแบบแมนนวลช่วงสามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนประเภทนี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแถบ ในแผนภูมิคอลัมน์ จะเป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอน แกนประเภทจะเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) ระยะห่างของเครื่องหมายติกยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์

ไม่ควรใช้การเว้นช่องป้ายชื่อประเภทเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) ระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มจากศูนย์ ช่วงป้ายชื่อประเภท `3` จะนับตำแหน่งประเภทโดยไม่สนค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่ามากกว่าแกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลาอย่างที่อธิบายในส่วน [เปลี่ยนแกนประเภท](#change-a-category-axis)

## **กำหนดรูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าประจำปีสี่ค่า วันที่ถูกเก็บเป็นเลขซีเรียล OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`) คำนวนเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้ ทั้งสองปฏิทินใช้ UTC และจะถูกเคลียร์ก่อนตั้งค่าวันที่เพื่อไม่ให้การปรับเวลาแสงอาทิตย์หรือเวลาปัจจุบันมีผลต่อการคำนวน ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date` , เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วย `false` และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้ายชื่อประเภทแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์

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

## **ตั้งค่ามุมการหมุนสำหรับชื่อเรื่องแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) ด้วย `true` บนแกนแนวตั้ง ให้ข้อความชื่อเรื่อง แล้วใช้ [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนชื่อเรื่อง มุมวัดเป็นองศา ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยให้ชื่อแกนค่าหมุน 90 องศา

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

## **กำหนดตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่่าแกนค่าตัดกับแกนประเภทระหว่างประเภทหรือที่เครื่องหมายติกของประเภท การตั้งค่านี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อสเกลป้ายกำกับบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วย [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) ตั้งค่าเป็น `Millions` ค่า 60,000,000 จะปรากฏเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง

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

## **กำหนดค่าการแสดงผลลอการิทึมบนแกนค่า**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายตามหลายลำดับ magnitude ตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000, 100,000 ครั้งในห้าช่วง บนสเกลเชิงเส้น ค่าที่เล็กจะอยู่ใกล้ศูนย์มาก ลำดับลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพัทธ์ง่ายขึ้น: ระยะห่างที่เท่ากันแสดงอัตราส่วนที่เท่ากันแทนความแตกต่างที่เท่าเดิม

เรียก [setLogarithmic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogarithmic-boolean-) ด้วย `true` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setLogBase-double-) เพื่อเลือกฐาน การทำเช่นนี้จะเปลี่ยนวิธีการแสดงค่าที่มีอยู่ ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นคุณลักษณะแยกที่จำลองความสัมพันธ์ที่ฟิตกับข้อมูล

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิรูปเส้นหรือคอลัมน์ แกนค่าจะได้จาก [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) สำหรับแผนภูมิแท่งแนวนอน จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นให้เลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งสองแกน ไม่ควรใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX ให้ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ด้วย ฐาน `10` จะให้พลังเท่ากันเช่น 10, 100, 1,000, 10,000 ที่เว้นระยะเท่ากัน

### **เปรียบเทียบสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างอิสระต่อไปนี้สร้างแผนภูมิรูปเส้นที่มีจำนวนคำขอห้าช่วงบนสไลด์แรก แล้วคลอนสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์รักษาข้อมูลเดียวกัน

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

    // คงให้สไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
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

**สเกลเชิงเส้น (สไลด์ 1):** ระยะทางแนวตั้งที่เท่ากันแสดงความต่างที่เท่ากันของจำนวนคำขอ ค่าใหญ่สุดครอบแผนภูมิ ทำให้ค่าที่เล็กยากต่อการแยก

![แผนภูมิรูปเส้นใน PowerPoint แสดงจำนวนคำขอห้ารายการบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะทางแนวตั้งที่เท่ากันแสดงอัตราส่วนที่เท่าเดิม แต่ละช่วงมีจำนวนคำขอเพิ่มขึ้นสิบเท่า ดังนั้นจุดต่าง ๆ จะอยู่บนเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน 10 แกนป้ายยังคงแสดงจำนวนคำขอเดิม

![จำนวนคำขอห้ารายการเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงค่าได้เฉพาะค่าบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้ หากค่าศูนย์หรือค่าติดลบมีความหมาย ให้ใช้สเกลเชิงเส้นหรือแสดงแยกออก หากการยกเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์ ให้อธิบายเหตุผล อย่าแทนที่ค่าดังกล่าวด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือค่าสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมก็ต้องเป็นค่าบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งข้ามแกนอื่น (การข้ามแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการข้าม หากต้องการระบุค่าตัวเลขสำหรับการข้าม ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) การตั้งค่าเหล่านี้ช่วยให้คุณย้ายตำแหน่งการข้ามแกนไปยังฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งป้ายเครื่องหมายติกสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อควบคุมตำแหน่งป้าย หากต้องการควบคุมเครื่องหมายติกโดยตรง ให้ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-) ซึ่งแยกจากการกำหนดตำแหน่งป้ายได้อย่างอิสระ