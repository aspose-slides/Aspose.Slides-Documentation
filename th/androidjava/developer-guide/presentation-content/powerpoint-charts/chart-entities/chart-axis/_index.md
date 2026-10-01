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
- ควบคุมแกน
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

บทความนี้อธิบายวิธีกำหนดค่าแกนของแผนภูมิด้วย Aspose.Slides สำหรับ Android ผ่าน Java โดยครอบคลุมค่าที่คำนวณของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ช่วงเวลาของป้ายชื่อหมวดหมู่และเครื่องหมายหลัก หน่วยวันที่และการจัดรูปแบบ การหมุนชื่อเรื่อง การกำหนดตำแหน่งแกน และหน่วยการแสดงผล

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่พร้อมข้อมูลเริ่มต้น เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#validateChartLayout--) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้โครงร่างแผนภูมิมีความเป็นปัจจุบัน

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMaxValue--) และ [getActualMinValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinValue--) เพื่อรับขอบเขตของแกน และ [getActualMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnit--) กับ [getActualMinorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnit--) เพื่อรับช่วงของเครื่องหมายหลัก [getActualMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMajorUnitScale--) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#getActualMinorUnitScale--) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างนี้เก็บค่าดังกล่าวในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [switchRowColumn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#switchRowColumn--) เพื่อสลับบทบาทของ series และ category ในข้อมูลแผนภูมิ แต่ละ category เดิมจะกลายเป็น series และแต่ละ series เดิมจะกลายเป็น category ซึ่งจะเปลี่ยนวิธีการจัดกลุ่มข้อมูล แต่ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#setRange-java.lang.String-) เพื่อเชื่อมข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมทั้งแถวหัวตารางและคอลัมน์ category ก่อนทำการสลับแถวและคอลัมน์ แล้วบันทึกแผนภูมิที่มีสี่ series และสาม category

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

เรียกใช้ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวตั้งซ่อนอยู่

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

เรียกใช้ [setVisible](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setVisible-boolean-) ด้วยค่า `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวนอนซ่อนอยู่

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

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) เพื่อเลือกแกนประเภทแบบวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ไฟล์ `ExistingChart.pptx` โดยมีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ category มีค่าที่เป็นวันของ Excel แบบตัวเลข จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การเรียกใช้ [setAutomaticMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) ด้วยค่า `false`, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnit-double-) ด้วยค่า `1` และ [setMajorUnitScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorUnitScale-int-) ด้วยค่า `TimeUnitType.Months` จะทำให้เครื่องหมายหลักวางที่ช่วงหนึ่งเดือน

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

## **ควบคุมช่วงเวลาของป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลาย category ให้ลดจำนวนป้ายชื่อแกนที่แสดงโดยไม่ต้องลบ category หรือจุดข้อมูล เรียกใช้ [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) ด้วยค่า `false` แล้วส่งช่วง category ที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickLabelSpacing-int-) สำหรับ category แบบข้อความตามลำดับปกติ การนับเริ่มจาก category แรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวดหมู่ 1, หมวดหมู่ 2, หมวดหมู่ 3, ... หมวดหมู่ 24 |
| `2` | หมวดหมู่ 1, หมวดหมู่ 3, หมวดหมู่ 5, ... หมวดหมู่ 23 |
| `3` | หมวดหมู่ 1, หมวดหมู่ 4, หมวดหมู่ 7, ... หมวดหมู่ 22 |

ช่วง `3` จะทำให้แสดงป้ายชื่อทุกสามรายการ ทำให้มีสองป้ายซ่อนอยู่ระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดช่องอัตโนมัติจะเลือกช่วงตามพื้นที่ที่ใช้ได้; ไม่ได้จำเป็นต้องแสดงทุกป้าย

เครื่องหมายติ๊กมีการควบคุมแยกต่างหาก เรียกใช้ [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) ด้วยค่า `false` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setTickMarksSpacing-int-) เพื่อตั้งค่าช่วงของมัน ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกช่วงของ category ในขณะที่ป้ายชื่อจะปรากฏเพียงทุกสาม category ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorTickMark-int-) พร้อมสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การเรียกใช้ตัวตั้งค่าอัตโนมัติกับค่า `true` อีกครั้งจะทำให้แผนภูมิเลือกช่วงนั้นอีกครั้ง

ตัวอย่างอิสระต่อไปนี้สร้าง 24 category และหนึ่ง series แล้วบันทึกสามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การจัดช่องอัตโนมัติ, การจัดช่องป้ายชื่อด้วยมือพร้อมเครื่องหมายติ๊กแยกกัน, และการคืนค่าการจัดช่องอัตโนมัติ สองสำเนาเก็บข้อมูลแผนภูดิดั้งเดิม ไม่จำเป็นต้องมีพรีเซนเทชันเข้า ข้อความป้ายแนวนอนทำให้เห็นความแตกต่างของความหนาแน่นได้ง่าย

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

    // สไลด์ 2: แสดงป้ายชื่อทุกสามรายการ แต่รักษาเครื่องหมายติ๊กสำหรับทุกหมวดหมู่.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // สไลด์ 3: ให้แผนภูมิเบอร์เลือกช่วงเวลาทั้งสองใหม่อีกครั้ง.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**การจัดช่องอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายชื่อของทุก category ที่สองจะแสดงและตัดบรรทัดเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างกันขึ้นกับขนาดแผนภูมิ, ฟอนต์และเรนเดอร์

![การจัดช่องป้ายชื่อประเภทอัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การจัดช่องด้วยมือ (สไลด์ 2):** ป้ายชื่อทุกสามรายการจะแสดงบนหนึ่งบรรทัด ในขณะที่เครื่องหมายติ๊กคงอยู่ที่ทุกช่วงของ category คอลัมน์ทั้งหมด 24 คอลัมน์รวมถึงที่ไม่มีป้ายชื่อยังคงมองเห็นได้ด้วยค่าเดียวกัน สไลด์ 3 คืนสภาพการแสดงอัตโนมัติที่แสดงข้างบน

![ช่วงป้ายชื่อประเภทแบบมือสามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวน category นี้กับแกนประเภทแบบข้อความ เช่น แกน category ของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอนแกน category จะเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับแกนที่คืนโดย [getVerticalAxis](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxesmanager/#getVerticalAxis--) การจัดช่องของเครื่องหมายติ๊กยังใช้กับแกน series ในแผนภูมิที่มี

ห้ามใช้การจัดช่องป้ายชื่อ category เพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า ในแกนค่า, [setMajorUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setMajorUnit-double-) ระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มที่ศูนย์ ช่วงป้ายชื่อ category `3` จะนับตำแหน่งของ category โดยไม่คำนึงถึงค่าข้อมูล แผนภูมิ scatter และ bubble ใช้แกนค่าแทนแกน category แบบข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลา ตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **ตั้งรูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยค่าประจำปีสี่ค่า วันที่ถูกเก็บเป็นเลขอนุกรม OLE Automation ในแผ่นงานแรก (ดัชนี `0`) คำนวณเป็นจำนวนวันตั้งแต่วันที่ 30 ธันวาคม 1899 สำหรับวันที่เหล่านี้ ทั้งสองปฏิทินใช้ UTC และถูกเคลียร์ก่อนตั้งค่าวันที่เพื่อไม่ให้เวลาออมแสงและเวลาปัจจุบันส่งผลต่อการคำนวณ ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCategoryAxisType-int-) กับ `CategoryAxisType.Date`, เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) ด้วยค่า `false` และส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) เพื่อให้ป้ายชื่อ category แสดงปีสี่หลักโดยอิสระจากรูปแบบเซลล์

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

## **ตั้งมุมการหมุนสำหรับชื่อแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTitle-boolean-) ด้วยค่า `true` บนแกนแนวตั้ง ใส่ข้อความชื่อและใช้ [setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) เพื่อหมุนชื่อ ช่วงมุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยหัวข้อแกนค่าถูกหมุน 90 องศา

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

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) เพื่อควบคุมว่าทำให้แกนค่เดินข้ามแกนประเภทระหว่าง category หรือที่เครื่องหมายติ๊กของ category การตั้งค่านี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

## **ตั้งหน่วยการแสดงผลบนแกนค่าแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setDisplayUnit-int-) เพื่อปรับสเกลป้ายของแกนค่าที่ไม่เปลี่ยนแปลงข้อมูลพื้นฐาน เมื่อกำหนด [DisplayUnitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/displayunittype/) เป็น `Millions` ค่าที่ 60,000,000 จะถูกแสดงเป็น 60 ตัวอย่างนี้สร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลล้านบนแกนแนวตั้งของมัน

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

**ฉันจะตั้งค่าค่าที่แกนหนึ่งข้ามแกนอีก (การข้ามแกน) อย่างไร?**

ใช้ [setCrossType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossType-int-) เพื่อเลือกพฤติกรรมการข้าม ใช้ [setCrossAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setCrossAt-float-) เพื่อตั้งค่าตัวเลขของจุดข้าม การตั้งค่าเหล่านี้ทำให้คุณย้ายจุดข้ามของแกนไปยังระดับฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งป้ายเครื่องหมายติ๊กสัมพันธ์กับแกนอย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setTickLabelPosition-int-) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมเครื่องหมายติ๊กเอง ให้ใช้ [setMajorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMajorTickMark-int-) หรือ [setMinorTickMark](https://reference.aspose.com/slides/androidjava/com.aspose.slides/axis/#setMinorTickMark-int-); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งของป้าย