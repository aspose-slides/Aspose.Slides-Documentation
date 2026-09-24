---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Java
linktitle: ชุดข้อมูล
type: docs
url: /th/java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุด
- ค่าลบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าลบในงานนำเสนอด้วย Java."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่ถูกพล็อตไว้ในเวิร์กบุ๊กข้อมูลแผนภูมิ หนึ่ง [IChartSeries](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/) ในชุดจะอ้างอิงถึงเซลล์ในเวิร์กบุ๊กหนึ่งหรือหลายเซลล์ [IChartCategory](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartcategory/) จะให้ค่าเลเบลหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุด Series ชื่อชุด, ประเภท, และค่าจุดจึงถูกเชื่อมต่อกับอ็อบเจ็กต์ [IChartDataCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/) แทนที่จะเก็บเป็นข้อความที่แสดงเท่านั้น

สำหรับแผนภูมิแบบประเภทหมวดโดยทั่วไป เวิร์กบุ๊กเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวด, และเซลล์ที่เหลือสำหรับค่าในชุด Series ดัชนีแผ่นงาน, แถว, และคอลัมน์ที่ส่งให้ [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) เป็นดัชนีเริ่มจากศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้แนวทางนี้ สำหรับการนำเสนอที่โหลดขึ้นมา ให้ตรวจสอบเซลล์ที่ชุด Series, หมวด, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของเวิร์กบุ๊ก

การตั้งค่าแผนภูมิมี 3 ระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุด Series เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getFormat--) ให้ลักษณะเริ่มต้นสำหรับทุกจุดในชุดเดียว
- การตั้งค่าระดับจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะทำให้รูปแบบของชุด Series ถูกแทนที่สำหรับจุดหนึ่งจุด
- การตั้งค่าระดับกลุ่มจะใช้กับชุด Series ที่เข้ากันและอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่น การทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุด Series อย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีการฟอร์แมตทั้งชุด Series และจุดข้อมูลพร้อมกัน การฟอร์แมตจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุด Series ในแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันมากแค่ไหนในแผนภูมิ 2 มิติ จาก -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าที่กลุ่มชุดแม่ ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดที่เข้ากันในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น:

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

## **เปลี่ยนสีการเติมของชุด Series**

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getFormat--) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับชุดทั้งหมด หากจุดหนึ่งมีการเติมสีที่กำหนดไว้แล้ว การตั้งค่า [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะทับซ้อนการเติมสีของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าแบบทึบกับชุดแรก:

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

## **เปลี่ยนชื่อชุด Series**

ชื่อชุดจะถูกเก็บในเวิร์กบุ๊กข้อมูลแผนภูมิและปกติจะแสดงในคำอธิบาย legenda ในเวิร์กบุ๊กเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getName--) ได้เช่นกัน วิธีนี้จะทำให้ไม่ต้องสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

## **รับสีการเติมอัตโนมัติของชุด Series**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนสีที่คำนวณจากดัชนีชุด Series และสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมสีของชุดยังไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้เพียงอ่านสีที่คำนวณ; ไม่ได้กำหนดการเติมสีใหม่

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

ตัวอย่างผลลัพธ์สำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แน่นอนจะขึ้นกับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีการเติมกลับด้านสำหรับชุด Series**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าลบด้วยสีการเติมที่ต่างออกไป ให้ตั้งค่าการเติมสีปกติของชุดเป็นสีทึบ, เปิดการกลับด้าน, แล้วกำหนดสีค่าลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ตัวเลขลบจะยังคงไม่เปลี่ยนในเวิร์กบุ๊ก; มีแค่สีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดหนึ่ง แผ่นงานแถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวด, คอลัมน์ 1 มีค่า:

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

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก จุดนั้นยังได้รับการกำหนดค่าเป็นค่าลบเพื่อให้เห็นผล:

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

## **ล้างค่าของจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์เวิร์กบุ๊กที่สนับสนุนจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าแสดงผลสามารถเข้าถึงได้ผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลจะอยู่ตำแหน่งหมวดเดียวกัน แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองของชุดแรก:

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

แผนภูมิแบบกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิ้ลยังใช้เซลล์ขนาดด้วย ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อคุณต้องการคงจุดอื่นไว้ เพราะเมธอดนั้นจะลบทุกจุดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์เวิร์กบุ๊กที่ว่างเปล่าหมายถึงข้อมูลที่หายไป; เซลล์ที่มี `0` หมายถึงค่าตัวเลขที่ทราบอยู่ เรียก [IChartDataCell.setValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) ด้วย `null` เพื่อทำให้เซลล์ว่าง ค่าตัวเลขศูนย์จะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด เปลี่ยนวิธีการพล็อตค่าว่างโดยไม่ต้องเติมศูนย์หรือค่าประมาณลงในเซลล์เวิร์กบุ๊ก

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบครบวงจรที่สร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าของวันที่ 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับเลเบลหมวด, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ทำให้วันที่ 3 ว่างจริง ๆ แต่ยังคงหมวดและจุดข้อมูลไว้
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

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` เพื่อบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนลูปผ่านโหมดต่าง ๆ

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์ วันที่ 3 จะเป็นค่าว่างในเวิร์กบุ๊กในทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบทั้งสามโหมดได้ง่าย แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมผ่านหมวดที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงในภาพด้านบน; คอลัมน์ที่หายไปและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกันเช่นกัน อีกเช่นเดียวกัน แผนภูมิกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์สามแบบที่แตกต่างกันสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด Series**

ความกว้างของช่องว่างหมายถึงพื้นที่ระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดแม่ ไม่ได้เป็นของชุดเดียว เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่จะทำให้มีพื้นที่ระหว่างกลุ่มมากขึ้น; ค่าเล็กจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกการนำเสนอสุดท้ายเท่านั้น:

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

**ประเภทแผนภูมิใดบ้างที่รองรับชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิจำนวนหมวดใช้หมวดและค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิ้ลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่สอดคล้องกับประเภทชุด ค่าตัวเลือกเช่น การทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากัน

**กลุ่มชุดแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/) ประกอบด้วยชุดที่เข้ากันและใช้การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดหนึ่งไม่ได้หมายความว่าจะเปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี โดยค่าเริ่มต้น [IShapeCollection.addChart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) จะสร้างชุดตัวอย่าง, หมวด, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดทั้งชุดและคอลเลกชันหมวดก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่ การ overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้อีกด้วย

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์เวิร์กบุ๊กอย่างไร?**

ชื่อชุด, เลเบลหมวด, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตามที่สอดคล้อง เมื่อคุณสร้างข้อมูลกำหนดเอง ให้รักษาแถวหมวดและแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดถูกพล็อตภายใต้หมวดที่ต้องการ

**ฉันจะลบจุดเดียวแทนการลบชุดทั้งหมดได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อคงตำแหน่งหมวดของจุดนั้นเป็นจุดว่าง ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapointcollection/#clear--) เท่านั้นเมื่อคุณต้องการลบทุกจุดจากชุดนั้น หากคุณลบหมวดด้วย ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวด

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, ค่าเป็นศูนย์, หรือเชื่อมจุดใกล้เคียงกัน เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดูที่หัวข้อ [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าลบถูกฟอร์แมตอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ ให้เรียก [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) และกำหนดสีที่คืนโดย [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถแทนที่พฤติกรรมสำหรับจุดเดี่ยวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีการเหล่านี้ส่งผลต่อการฟอร์แมต, ไม่ใช่ค่าตัวเลขที่เก็บไว้

**ฟอร์แมตใดชนะเมื่อทั้งชุดและจุดถูกฟอร์แมต?**

การฟอร์แมตจุดข้อมูลที่กำหนดอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ ยังคงใช้ฟอร์แมตชุดที่กำหนดหรือหากไม่มีการกำหนดฟอร์แมตชุดจะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ การตั้งค่ากลุ่มเช่น การทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การฟอร์แมตระดับจุด

**แผนภูมิสามารถมีจำนวนชุดได้สูงสุดเท่าไหร่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแบบแยกต่างหาก ในทางปฏิบัติ ขนาดไฟล์การนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะเป็นตัวกำหนดขีดจำกัดที่ใช้งานได้

**ฉันควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น