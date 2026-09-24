---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอบน Android
linktitle: ชุดข้อมูล
type: docs
url: /th/androidjava/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีชุดข้อมูล
- ชื่อชุดข้อมูล
- จุดข้อมูล
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุดข้อมูล
- ค่าลบ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าลบในงานนำเสนอบน Android."
---
## **ภาพรวม**

แผนภูมิจัดเก็บข้อมูลที่พล็อตไว้ในเวิร์กบุ๊กข้อมูลแผนภูมิ ชุด [IChartSeries](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/) แสดงถึงหนึ่งชุดของค่าที่เกี่ยวข้อง และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/) ในชุดข้อมูลอ้างอิงถึงเซลล์ในเวิร์กบุ๊กหนึ่งหรือหลายเซลล์ วัตถุ [IChartCategory](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartcategory/) ให้ป้ายกำกับหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ชื่อชุดข้อมูล หมวดหมู่ และค่าจุดจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/) แทนที่จะเก็บเป็นข้อความแสดงผลเท่านั้น

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป เวิร์กบุ๊กเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล คอลัมน์ 0 สำหรับชื่อหมวดหมู่ และเซลล์ที่เหลือสำหรับค่าของชุดข้อมูล ดัชนีของแผ่นงาน แถว และคอลัมน์ที่ส่งให้ [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) เป็นค่าตั้งแต่ศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับงานนำเสนอที่โหลดขึ้นมา ให้ตรวจสอบเซลล์ที่ชุดข้อมูล หมวดหมู่ และจุดข้อมูลอ้างอิงถึงก่อนที่จะเปลี่ยนค่าของเวิร์กบุ๊ก

การตั้งค่าของแผนภูมิมีสามระดับแตกต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getFormat--) ให้รูปลักษณ์เริ่มต้นสำหรับทุกจุดในชุดข้อมูลหนึ่ง
- การตั้งค่าระดับจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะลบล้างรูปลักษณ์ของชุดข้อมูลสำหรับจุดเดียว
- การตั้งค่าระดับกลุ่มใช้กับชุดข้อมูลที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการตั้งค่าการเติมสีจุดหรือชุดข้อมูลโดยชัดเจน รูปแบบและธีมของแผนภูมิจะกำหนดรูปลักษณ์อัตโนมัติ เมื่อทั้งการจัดรูปแบบของชุดข้อมูลและจุดมีอยู่ การจัดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2 มิติ ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดข้อมูลแม่ ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดข้อมูลที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดข้อมูลที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดข้อมูลแรก:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า.
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

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getFormat--) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับชุดข้อมูลทั้งหมด หากจุดใดจุดหนึ่งมีการกำหนดสีเติมโดยชัดเจน การตั้งค่า [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะลบล้างสีเติมของชุดข้อมูลสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมสีน้ำเงินทึบกับชุดข้อมูลแรก:

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

ชื่อชุดข้อมูลถูกเก็บไว้ในเวิร์กบุ๊กข้อมูลแผนภูมิและโดยปกติจะแสดงในเลเจนด์ ในเวิร์กบุ๊กเริ่มต้นสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และมีชื่อของชุดข้อมูลแรก ค่าคงที่ที่ตั้งชื่อไว้ในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่ [IChartSeries.getName](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getName--) อ้างอิงอยู่ วิธีนี้ช่วยหลีกเลี่ยงการสันนิษฐานว่าแถวและคอลัมน์ใดมีอยู่ในแผนภูมิที่มีอยู่แล้ว:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากดัชนีชุดข้อมูลและรูปแบบแผนภูมิเป็นจำนวนเต็มสี ARGB ของ Android นี่คือสีที่ใช้เมื่อสีเติมของชุดข้อมูลไม่ได้กำหนดโดยชัดเจน การเรียกเมธอดนี้จะอ่านสีที่คำนวนได้; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์จำนวนเต็มสีอัตโนมัติของแต่ละชุดข้อมูลเริ่มต้น:

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

ค่าจำนวนเต็มที่ได้ขึ้นอยู่กับรูปแบบและธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดข้อมูลแผนภูมิ**

สำหรับชุดข้อมูลบาร์, คอลัมน์, และบับเบิล, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติให้เป็นสีทึบ, เปิดการกลับด้าน, และกำหนดสีค่าลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ตัวเลขลบจะคงเดิมในเวิร์กบุ๊ก; มีเฉพาะสีที่แสดงเปลี่ยนแปลง

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดข้อมูลหนึ่ง แผ่นงานแถว 0 มีชื่อชุดข้อมูล, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับชุดข้อมูลและเปิดเฉพาะสำหรับจุดที่เลือก จุดนั้นยังได้รับค่าลบเพื่อให้เห็นผล:

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

เพื่อให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์เวิร์กบุ๊กที่สนับสนุนจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเรียกได้ผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลยังคงอยู่ในตำแหน่งหมวดหมู่เดียวกัน แต่แผนภูมิจะแสดงค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดข้อมูลแรก:

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

แผนภูมิแบบกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ล้างเฉพาะเซลล์ที่เป็นค่าที่คุณตั้งใจจะลบ อย่าเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อต้องการเก็บจุดอื่น ๆ เนื่องจากเมธอดนี้จะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์เวิร์กบุ๊กที่ว่างเปล่าแสดงถึงข้อมูลหาย; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่ทราบแล้ว เรียก [IChartDataCell.setValue](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) ด้วย `null` เพื่อทำให้เซลล์ว่างเปล่า `0` ตัวเลขจะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด มันเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่ต้องเติมค่า `0` หรือค่าประมาณลงในเซลล์เวิร์กบุ๊ก

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่ทำงานคนเดียวสร้างแผนภูมิเส้นหนึ่งชุด, ล้างค่าของวัน 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุดข้อมูล ค่าข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ทำให้ Day 3 ว่างเปล่าจริง ๆ โดยคงหมวดหมู่และจุดข้อมูลไว้.
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

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` เพื่อบันทึกเวอร์ชันเดียวให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปทุกโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม ไวท์ 3 จะว่างเปล่าในเวิร์กบุ๊กทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมผ่านหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมได้; คอลัมน์ที่หายไปและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์ไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดข้อมูลแม่ไม่ใช่ของชุดข้อมูลเดียวเรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่กว่าจะสร้างช่องว่างมากขึ้นระหว่างกลุ่ม; ค่าน้อยกว่าจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกงานนำเสนอสุดท้ายเท่านั้น:

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

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่รองรับชุดข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิด้านใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุดข้อมูล ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**ชุดข้อมูลกลุ่ม (series group) คืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนกลุ่มผ่านชุดข้อมูลหนึ่งอาจไม่เปลี่ยนแปลงทุกชุดข้อมูลในแผนภูมิ

**แผนภูมิใหม่ที่สร้างขึ้นมามีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยปกติ [IShapeCollection.addChart](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) จะสร้างชุดข้อมูลตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์คอลเลกชันชุดข้อมูลและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่ overload บางอันยังสามารถสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้นได้อีกด้วย

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์เวิร์กบุ๊กอย่างไร?**

ชื่อชุดข้อมูล, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิกำหนดที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลแบบกำหนดเอง ให้รักษาแถวหมวดหมู่และแถวค่าชุดข้อมูลให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ภายใต้หมวดหมู่ที่ตั้งใจ

**จะล้างจุดเดียวแทนการลบชุดข้อมูลทั้งหมดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อต้องการลบจุดทั้งหมดจากชุดข้อมูลนั้น หากคุณลบหมวดหมู่ด้วย ให้更新ทุกชุดข้อมูลเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือเชื่อมจุดใกล้เคียงเลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดูหัวข้อ [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างสมบูรณ์และการเปรียบเทียบภาพ

**ค่าลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดข้อมูลบาร์, คอลัมน์, และบับเบิลที่รองรับ ให้เรียก [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) และตั้งค่าสีที่คืนจาก [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถลบล้างพฤติกรรมสำหรับจุดเดียวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่เก็บไว้

**การจัดรูปแบบใดชนะเมื่อทั้งชุดข้อมูลและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ ยังคงใช้รูปแบบชุดข้อมูลที่ชัดเจนหรือหากไม่มีการกำหนดรูปแบบชุดข้อมูล ระบบจะใช้รูปแบบและธีมของแผนภูมิโลตัส การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การลบล้างการจัดรูปแบบระดับจุด

**แผนภูมิสามารถมีชุดข้อมูลได้สูงสุดเท่าใด?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนชุดข้อมูลแบบแยก อย่างไรก็ตาม ข้อจำกัดของไฟล์พรีเซนเทชั่น, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่ใช้งานได้จริง

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มชุดข้อมูลแม่ที่เหมาะสม เพิ่มค่เพื่อขยายช่องว่างระหว่างกลุ่ม หรือ ลดค่าเพื่อทำให้กลุ่มใกล้กันขึ้น.