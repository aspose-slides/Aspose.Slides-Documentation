---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอบน Android
linktitle: ชุดข้อมูล
type: docs
url: /th/androidjava/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การซ้อนทับของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์สมุดงาน
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การซ้อนทับ, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอบน Android."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่วางไว้ในสมุดงานข้อมูลของแผนภูมิ [IChartSeries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุดและแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/) ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ของสมุดงาน วัตถุ [IChartCategory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ชื่อชุด, หมวดหมู่ และค่าจุดจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/) แทนที่จะเก็บเป็นเพียงข้อความที่แสดงผลเท่านั้น

สำหรับแผนภูมิกลุ่มประเภททั่วไป สมุดงานเริ่มต้นใช้แถว 0 สำหรับชื่อชุด ค่าในคอลัมน์ 0 สำหรับชื่อหมวดหมู่ และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนีแผ่นงาน, แถว และคอลัมน์ที่ส่งให้กับ [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) เป็นเลขฐานศูนย์ การจัดวางนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทุกแผนภูมิใช้วิธีนี้ สำหรับการนำเสนอที่โหลดเข้ามา ให้ตรวจสอบเซลล์ที่ชุด, หมวดหมู่ และจุดข้อมูลอ้างอิงก่อนทำการเปลี่ยนค่าของสมุดงาน

การตั้งค่าแผนภูมิมีขอบเขตสามระดับ:

- การตั้งค่าระดับชุด เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getFormat--) ให้รูปลักษณ์เริ่มต้นสำหรับทุกจุดในชุดหนึ่ง
- การตั้งค่าจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) ครอบคลุมรูปลักษณ์ของชุดสำหรับจุดเดียว
- การตั้งค่ากลุ่มนำไปใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการซ้อนทับหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดอย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดรูปลักษณ์อัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งชุดและจุดพร้อมกัน การกำหนดรูปแบบของจุดจะมีความสำคัญเหนือสุดสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการซ้อนทับของชุดข้อมูลแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ซ้อนทับกันเท่าไหร่ในแผนภูมิ 2D โดยค่าตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มชุดพาเรนต์ ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; มันจะไม่กระทบต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการซ้อนทับสำหรับกลุ่มที่มีชุดแรก:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่, และค่า.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **เปลี่ยนสีเติมของชุดข้อมูล**

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getFormat--) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดใดจุดหนึ่งมีการกำหนดสีเติมอย่างชัดเจน การตั้งค่า [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะครอบคลุมการเติมสีของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมของแข็งสีฟ้ากับชุดแรก:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The color of the series](series_color.png)

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดถูกเก็บในสมุดงานข้อมูลของแผนภูมิและโดยปกติจะแสดงในตำนาน ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบจัดกลุ่ม เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.getName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getName--) ได้เช่นกัน วิธีนี้ช่วยหลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The series name](series_name.png)

## **รับสีเติมอัตโนมัติของชุดข้อมูล**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากลำดับของชุดและสไตล์ของแผนภูมิในรูปแบบจำนวนเต็ม ARGB ของ Android นี่คือสีที่ใช้เมื่อการเติมสีของชุดไม่ได้ถูกกำหนดอย่างเจาะจง การเรียกเมธอดนี้จะอ่านสีที่คำนวณเท่านั้น; มันไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์จำนวนเต็มสีอัตโนมัติของแต่ละชุดเริ่มต้น:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

ค่าจำนวนเต็มที่แน่นอนจะขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับสำหรับชุดข้อมูลแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์ และบับเบิล, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าติดลบด้วยสีเติมที่แตกต่างกัน ตั้งค่าสีเติมของชุดปกติให้เป็นแบบทึบ, เปิดการกลับค่า, แล้วกำหนดสีค่าติดลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ตัวเลขติดลบจะยังคงอยู่ในสมุดงานโดยไม่เปลี่ยน; เพียงแต่สีการแสดงผลจะเปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว แผ่นงานแถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่า:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The inverted solid fill color](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับค่าสำหรับจุดเดียวผ่าน [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ในตัวอย่างต่อไปนี้ การกลับค่าสำหรับชุดถูกปิดและเปิดใช้งานเฉพาะสำหรับจุดที่เลือก จุดนั้นยังถูกกำหนดค่าติดลบเพื่อให้เห็นผล:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์สมุดงานที่สนับสนุนเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่วาดแสดงผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลจะอยู่ในตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือว่าค่านั้นเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

แผนภูมิกระจายจะแยกเซลล์ X และ Y, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อคุณต้องการเก็บจุดอื่น ๆ เนื่องจากเมธอดนั้นจะลบทุกจุดในคอลเลกชัน

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

ความกว้างช่องว่างเป็นช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการซ้อนทับ มันเป็นของกลุ่มชุดพาเรนต์ ไม่ได้เป็นของชุดเดียวเรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) หนึ่งครั้งสำหรับกลุ่ม ค่าที่ใหญ่กว่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น; ค่าที่เล็กกว่าจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกเพียงงานนำเสนอสุดท้าย:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![The gap width](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่สนับสนุนชุดข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิแบบบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทของชุดข้อมูล ตัวเลือกเช่นการซ้อนทับและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**ชุดข้อมูลแผนภูมิกลุ่มคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการวางระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งไม่จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช้. โดยค่าเริ่มต้น [IShapeCollection.addChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างสมบูรณ์ การ overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมินั้น ๆ เมื่อคุณสร้างข้อมูลแบบกำหนดเอง ให้รักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกัน เพื่อให้แต่ละจุดถูกพล็อตภายใต้หมวดหมู่ที่ตั้งใจ

**จะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย ให้ปรับทุกชุดให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่สนับสนุนสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่าเป็นศูนย์, หรือโดยการเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่สนับสนุน ให้เรียก [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) แล้วตั้งค่าสีที่คืนจาก [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถครอบคลุมพฤติกรรมของจุดเดี่ยวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่เก็บไว้

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลอย่างชัดเจนจะมีความสำคัญเหนือสำหรับจุดนั้น จุดอื่น ๆ จะยังคงใช้รูปแบบชุดที่ชัดเจนหรือเมื่อไม่มีการกำหนดรูปแบบชุด จะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ การตั้งค่ากลุ่มเช่นการซ้อนทับและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การแทนที่การจัดรูปแบบระดับจุด

**แผนภูมิสามารถมีชุดได้สูงสุดเท่าไหร่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแบบคงที่ ในทางปฏิบัติ ข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความสามารถในการอ่านของแผนภูมิจะกำหนดขีดจำกัดที่ใช้งานได้

**ควรปรับอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มชุดพาเรนต์ที่เหมาะสม เพิ่มค่าด้วยการกว้างช่องว่างระหว่างกลุ่ม หรือ ลดค่าลดระยะห่างระหว่างกลุ่มให้ใกล้กันมากขึ้น