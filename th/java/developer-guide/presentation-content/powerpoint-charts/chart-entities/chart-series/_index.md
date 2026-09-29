---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Java
linktitle: ชุดข้อมูล
type: docs
url: /th/java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์สมุดงาน
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การทับ, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Java."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่พล็อตไว้ในสมุดงานข้อมูลของแผนภูมิ ตัว[IChartSeries](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ[IChartDataPoint](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/) ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ของสมุดงาน วัตถุ[IChartCategory](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันระหว่างชุด ชื่อชุด, หมวดหมู่ และค่าจุดจึงเชื่อมต่อกับวัตถุ[IChartDataCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/) แทนที่จะเก็บเป็นข้อความแสดงผลเท่านั้น

สำหรับแผนภูมิเกรดประเภททั่วไป สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด ดัชนีของแผ่นงาน, แถว, และคอลัมน์ที่ส่งให้[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) เป็นศูนย์ (0‑based) รูปแบบนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับการนำเสนอก่อนหน้า ให้ตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิง ก่อนที่จะเปลี่ยนค่าในสมุดงาน

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุด เช่น[IChartSeries.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getFormat--) ให้ลักษณะเริ่มต้นสำหรับทุกจุดในชุดเดียว
- การตั้งค่าระดับจุดข้อมูล เช่น[IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะลบล้างลักษณะของชุดสำหรับจุดเดียว
- การตั้งค่าระดับกลุ่มจะใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน[IChartSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/) เดียวกัน ให้เข้าถึงกลุ่มผ่าน[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดสีเติมจุดหรือชุดอย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะที่ปรากฏอัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งชุดและจุดพร้อมกัน รูปแบบจุดจะมีความสำคัญเหนือรูปแบบชุดสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับของชุดแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ทับกันเท่าใดในแผนภูมิ 2D ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการอ่านค่าแบบอ่าน‑อย่างของการตั้งค่าในกลุ่มชุดแม่ ใช้[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; จะไม่มีผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับสำหรับกลุ่มที่มีชุดแรก:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า
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

## **เปลี่ยนสีเติมของชุด**

ใช้[IChartSeries.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getFormat--) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดหนึ่งมีการกำหนดสีเติมโดยชัดเจน การตั้งค่า[IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getFormat--) ของจุดนั้นจะลบล้างสีเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมสีน้ำเงินทึบกับชุดแรก:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกเก็บไว้ในสมุดงานข้อมูลของแผนภูมิและโดยปกติจะแสดงในคำอธิบาย (legend) ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่[IChartSeries.getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getName--) อ้างอิงอยู่ วิธีนี้ช่วยหลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

## **รับสีเติมอัตโนมัติของชุด**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้จะอ่านสีที่คำนวณเท่านั้น; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        Color automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้ขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติให้เป็นสีทึบ, เปิดใช้งานการกลับด้าน, และกำหนดสีค่าลบผ่าน[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ค่าตัวเลขลบจะไม่ถูกเปลี่ยนในสมุดงาน; เพียงแค่สีที่แสดงจะเปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว แถว 0 ของแผ่นงานมีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ตัวอย่างต่อไปนี้ปิดการกลับด้านสำหรับชุดและเปิดใช้เฉพาะจุดที่เลือก จุดนั้นยังถูกกำหนดค่าเป็นค่าลบเพื่อให้เห็นผล:

```java
import com.aspose.slides.*;
import java.awt.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    Color automaticSeriesColor = series.getAutomaticSeriesColor();
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

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ให้ตั้งค่าเซลล์สมุดงานที่สนับสนุนจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน[IChartDataPoint.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลจะคงตำแหน่งหมวดหมู่เดิมอยู่ แต่แผนภูมิจะถือค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

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

แผนภูมิกระจาย (scatter) ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ให้ล้างเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก[IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อต้องการคงจุดอื่นไว้ เพราะเมธอดนี้จะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่ซึ่งมีค่าเป็นกรณีแยกจากเซลล์ว่างเปล่า เพื่อรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ของแผ่นงาน โปรดดู[Include Data from Hidden Rows and Columns](/slides/th/java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์สมุดงานที่ว่างเปล่าจะแทนข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แทนค่าตัวเลขที่ทราบแล้ว เรียก[IChartDataCell.setValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) ด้วย `null` เพื่อทำให้เซลล์ว่าง ค่าศูนย์ยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิกทั้งหมดและจะเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่ต้องเติมศูนย์หรือค่าประมาณในเซลล์ว่าง

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดเดียว, ล้างค่าของ Day 3, แล้วบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต[IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, คอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Measurements");
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chart.getType());
    int[] values = { 10, 20, 25, 30, 40 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Day " + (i + 1));
        chartData.getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // ปล่อยให้วัน 3 เป็นค่าว่างจริง ๆ ขณะยังคงหมวดหมู่และจุดข้อมูลไว้
    workbook.getCell(0, 3, 1).setValue(null);

    int[] modes = { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
    String[] modeNames = { "Gap", "Zero", "Span" };
    for (int i = 0; i < modes.length; i++) {
        chart.setDisplayBlanksAs(modes[i]);
        presentation.save("empty_cells_" + modeNames[i] + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการแล้วบันทึกงานนำเสนอหนึ่งครั้งแทนการวนลูปผ่านโหมดทั้งหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์ Day 3 จะว่างเปล่าในสมุดงานในทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบทั้งสามโหมดได้ง่าย ส่วนแผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อข้ามหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมตามที่แสดงได้; คอลัมน์ที่หายไปและคอลัมน์สูงศูนย์อาจดูเหมือนกันได้เช่นกัน เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์จะไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ควรตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับ มันเป็นของกลุ่มชุดแม่ ไม่ใช่ของชุดเดียว เรียก[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่จะทำให้มีช่องว่างระหว่างกลุ่มมากขึ้น; ค่าเล็กจะทำให้กลุ่มแน่นขึ้น

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

ทุกประเภทแผนภูมิที่แสดงในตัวนับ[ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) จะใช้ข้อมูลแผนภูมิ แต่ชุดของแต่ละประเภทไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิเกรดใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด การตั้งค่าเช่นการทับและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**กลุ่มชุดแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/) มีชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งอาจไม่เปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิใหม่ที่สร้างขึ้นมามีข้อมูลเริ่มต้นหรือไม่?**

มี ทั้ง[IShapeCollection.addChart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) โดยค่าเริ่มต้นจะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองได้ อีกทางหนึ่งอาจใช้โอเวอร์โหลดเพื่อสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้น

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงถึงเซลล์ใน[IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิกที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลแบบกำหนดเอง ให้รักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้จุดแต่ละจุดพล็อตใต้หมวดหมู่ที่ต้องการ

**จะล้างจุดเดียวแทนที่จะล้างทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อให้ตำแหน่งหมวดหมู่ของจุดคงอยู่เป็นจุดว่าง ใช้[IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย ต้องอัปเดตทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยเชื่อมจุดข้างเคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู[Control the Display of Empty Cells](#control-the-display-of-empty-cells) เพื่อดูตัวอย่างสมบูรณ์และการเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ ให้เรียก[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) และตั้งค่าสีที่ได้จาก[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถลบล้างพฤติกรรมสำหรับจุดเดี่ยวด้วย[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีเหล่านี้มีผลต่อการจัดรูปแบบ ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ

**เมื่อทั้งชุดและจุดถูกจัดรูปแบบแล้ว รูปแบบใดชนะ?**

รูปแบบจุดข้อมูลที่ระบุอย่างชัดเจนจะมีลำดับความสำคัญเหนือรูปแบบชุดสำหรับจุดนั้น จุดอื่น ๆ จะใช้รูปแบบชุดที่ระบุ หรือหากไม่มีการกำหนดรูปแบบชุด จะใช้สไตล์และธีมของแผนภูมิกอัตโนมัติ การตั้งค่ากลุ่มเช่นการทับและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การลบล้างรูปแบบระดับจุด

**แผนภูมิสามารถมีชุดได้กี่ชุดสูงสุด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแบบคงที่ อย่างไรก็ตาม ขีดจำกัดจริงจะขึ้นอยู่กับข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มเข้ากันใกล้ขึ้น