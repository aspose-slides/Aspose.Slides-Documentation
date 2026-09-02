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
- เซลล์สมุดงาน
- ช่องว่างของชุด
- ค่าลบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าลบในงานนำเสนอด้วย Java."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่แสดงผลในสมุดงานข้อมูลแผนภูมิ หนึ่ง [IChartSeries](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/) ในชุดนั้นอ้างอิงถึงหนึ่งหรือหลายเซลล์ในสมุดงาน วัตถุ [IChartCategory](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartcategory/) ให้ป้ายชื่อหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatacell/) แทนที่จะเก็บเป็นเพียงข้อความที่แสดงเท่านั้น.

สำหรับแผนภูมิประเภทที่ใช้บ่อย สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด ข้อมูลแถว, คอลัมน์, และดัชนีที่ส่งผ่านไปยัง [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) จะเริ่มจากศูนย์ การจัดวางนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทั้งหมดใช้แบบนี้ สำหรับงานนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getFormat--) ให้ลักษณะเดิมสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าระดับจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะทับลักษณะของชุดสำหรับจุดหนึ่ง.
- การตั้งค่ากลุ่มใช้กับชุดที่เข้ากันได้และอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างช่องว่าง.

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดอย่างชัดเจน รูปแบบและธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีการจัดรูปแบบทั้งชุดและจุดพร้อมกัน การจัดรูปแบบจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าไรในแผนภูมิ 2D ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการแสดงผลแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่ ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์ที่จัดกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม.

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดแรกอยู่:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // แผนภูมิใหม่ประกอบด้วยชุดข้อมูลตัวอย่าง, หมวดหมู่, และค่า.
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

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getFormat--) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับทั้งชุด หากจุดมีการกำหนดสีเติมไว้แล้ว การตั้งค่า [IChartDataPoint.getFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getFormat--) ของจุดนั้นจะทับสีเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมแบบสีฟ้าเข้มต่อชุดแรก:

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

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดถูกเก็บไว้ในสมุดงานข้อมูลแผนภูมิและมักจะแสดงในคำอธิบาย ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และมีชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่ [IChartSeries.getName](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getName--) อ้างอิงอยู่แล้ว วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวหรือคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่ากลับสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้ถูกกำหนดอย่างชัดเจน การเรียกเมธอดจะอ่านสีที่คำนวณได้; ไม่ได้กำหนดสีเติมใหม่.

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

สีที่แน่นอนจะขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติของชุดเป็นสีทึบ, เปิดการกลับสี, และกำหนดสีค่าลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). ตัวเลขลบจะไม่เปลี่ยนในสมุดงาน; มีเพียงสีการแสดงผลที่เปลี่ยน.

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

คุณสามารถเปิดการกลับสีสำหรับจุดเดียวผ่าน [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). ในตัวอย่างต่อไปนี้ การกลับสีถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก จุดนั้นยังถูกกำหนดค่าเป็นค่าลบเพื่อให้เห็นผล

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

## **ลบค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ในสมุดงานที่สนับสนุนจุดนั้นเป็น `null`. สำหรับแผนภูมิคอลัมน์ ค่าที่ plotted สามารถเข้าถึงได้ผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#getValue--). จุดข้อมูลจะอยู่ตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก:

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

แผนภูกิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย. ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อคุณต้องการเก็บจุดอื่น ๆ เพราะเมธอดนั้นจะลบทุกจุดข้อมูลจากคอลเลกชัน

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

ความกว้างช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มันเป็นของกลุ่มชุดแม่ไม่ใช่ของชุดเดียว. เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) ครั้งเดียวสำหรับกลุ่ม. ค่าใหญ่จะเพิ่มระยะห่างระหว่างกลุ่ม, ค่าเล็กจะทำให้กลุ่มแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกเฉพาะงานนำเสนอสุดท้าย:

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

**ประเภทแผนภูมิใดที่รองรับชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงใน enumeration [ChartType](https://reference.aspose.com/slides/th/java/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดข้อมูลของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น แผนภูมิประเภทใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่าจาก X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทของชุด. ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มชุดข้อมูลแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิแบบผสมสามารถมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านชุดใดชุดหนึ่งอาจไม่ได้เปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, [IShapeCollection.addChart](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) สร้างชุดตัวอย่าง, หมวดหมู่, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. การ overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ในสมุดงานอย่างไร?**

ชื่อชุด, ป้ายชื่อหมวดหมู่, และค่าจุดข้อมูลอ้างอิงถึงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิเกี่ยวข้อง. เมื่อนำเข้าข้อมูลที่กำหนดเอง, ควรรักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุด plotted ภายใต้หมวดหมู่ที่ต้องการ.

**ฉันจะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง. ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น. หากคุณลบหมวดหมู่อีกด้วย, ให้ปรับปรุงทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-). แผนภูมิที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, ค่าศูนย์, หรือโดยเชื่อมต่อกับจุดข้างเคียง. เลือกการตั้งค่าที่ตรงกับความหมายของข้อมูลหายในงานนำเสนอของคุณ.

**ค่าลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับบาร์, คอลัมน์, และบับเบิลที่รองรับ, เรียก [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) และตั้งค่าสีที่ได้จาก [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--). คุณสามารถลบล้างพฤติกรรมสำหรับจุดเดียวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-). วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้.

**การจัดรูปแบบใดได้เปรียบเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ ยังคงใช้รูปแบบชุดที่กำหนดไว้หรือ, ถ้าชุดไม่มีการกำหนดรูปแบบ, จะใช้สไตล์และธีมแผนภูมิอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ได้เป็นการแทนที่การจัดรูปแบบระดับจุด.

**มีขีดจำกัดจำนวนชุดที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนชุดแยกเป็นคงที่. ในการปฏิบัติ, ข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจึงกำหนดขีดจำกัดที่ใช้ได้จริง.

**ควรปรับอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าที่ทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าเพื่อทำให้กลุ่มใกล้กันมากขึ้น.