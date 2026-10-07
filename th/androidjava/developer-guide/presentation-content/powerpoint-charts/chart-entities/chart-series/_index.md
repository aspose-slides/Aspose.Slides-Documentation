---
title: จัดการ Series ข้อมูลแผนภูมิในงานนำเสนอบน Android
linktitle: Series ข้อมูล
type: docs
url: /th/androidjava/chart-series/
keywords:
- Series แผนภูมิ
- การทับซ้อนของ Series
- สีของ Series
- ชื่อ Series
- จุดข้อมูล
- เซลล์ Workbook
- ช่องว่างของ Series
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการ Series ของแผนภูมิ, จุดข้อมูล, เซลล์ Workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอบน Android."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่พล็อตไว้ใน workbook ข้อมูลแผนภูมิ [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุดและแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) ในชุดจะอ้างอิงถึงเซลล์ workbook หนึ่งหรือหลายเซลล์ [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) ให้ป้ายกำกับหรือค่าการจัดกลุ่มที่ใช้ร่วมกันระหว่างชุด ค่า ชื่อชุด, หมวดหมู่และค่าจุดจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) แทนที่จะถูกเก็บเป็นข้อความแสดงผลอย่างเดียว

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่และเซลล์ที่เหลือสำหรับค่าชุด [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) รับพารามิเตอร์ดัชนี worksheet, แถวและคอลัมน์ที่เริ่มต้นจากศูนย์ รูปแบบนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับการพรีเซนเทชันที่โหลดมาแล้ว ควรตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวดหมู่และจุดข้อมูลก่อนทำการเปลี่ยนค่า workbook

การตั้งค่าแผนภูมิมีขอบเขตสามแบบ:

- การตั้งค่าระดับชุด เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) กำหนดลักษณะเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) เขียนทับลักษณะของชุดสำหรับจุดเดียว
- การตั้งค่ากลุ่มใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อต้องการตั้งค่าตัวเลือกเช่น การทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนด fill จุดหรือชุดแบบชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อทั้งการจัดรูปแบบของชุดและจุดมีอยู่ การจัดรูปแบบของจุดจะมีลำดับความสำคัญเหนือชุดสำหรับจุดนั้น

![แผนภูมิซีรีส์พาวเวอร์พอยต์](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของ Series ในแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าไรในแผนภูมิ 2 มิติ ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการอ่านค่าแบบอ่านอย่างเดียวจากการตั้งค่าบนกลุ่ม series พ่อแม่ ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่กระทบกับกลุ่ม series ที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่บรรจุชุดแรก:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // แผนภูมิใหม่ประกอบด้วย series ตัวอย่าง, หมวดหมู่, และค่า.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การทับซ้อนของซีรีส์](series_overlap.png)

## **เปลี่ยนสี Fill ของ Series**

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) เพื่อตั้งค่า fill เริ่มต้นสำหรับชุดทั้งหมด หากจุดมีการกำหนด fill ชัดเจน [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะเขียนทับ fill ของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีฟ้าแบบด้านเดียวกับชุดแรก:

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

![สีของซีรีส์](series_color.png)

## **เปลี่ยนชื่อ Series**

ชื่อชุดจะถูกเก็บใน workbook ของข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย (legend) ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบคลัสเตอร์ เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) ได้ วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อของซีรีส์](series_name.png)

### **สร้าง Series ด้วยชื่อจากหลายเซลล์**

ชื่อ series แบบรวมเป็นประโยชน์เมื่อชื่อสินค้าและช่วงเวลารายงานถูกเก็บไว้ในเซลล์ workbook แยกกัน ตัวอย่างเช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 เป็นชื่อ series เดียวขณะยังคงให้ทั้งสองส่วนเชื่อมต่อกับเซลล์ต้นฉบับ

ใช้ [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) เพื่อดึงช่วงชื่อแล้วส่งคอลเลกชันนั้นไปยัง [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) อาร์กิวเมนต์ skipHiddenCells ควบคุมว่าควรรวมเซลล์ที่ซ่อนอยู่หรือไม่: true ยกเว้น, false รวม ตัวอย่างนี้ใช้ false เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่มีหนึ่ง series และสองจุดข้อมูล เซลล์ B1:C1 ให้ชื่อ series เท่านั้น; A2:A3 ให้ป้ายกำกับหมวดหมู่; B2:B3 ให้ค่าตัวเลข

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    chart.setLegend(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // เซลล์สองนี้ให้ชื่อ series.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // เซลล์แยกต่างหากให้หมวดหมู่และจุดข้อมูลเชิงตัวเลข.
    IChartDataCell northCategory = workbook.getCell(0, 1, 0, "North");
    IChartDataCell southCategory = workbook.getCell(0, 2, 0, "South");
    chart.getChartData().getCategories().add(northCategory);
    chart.getChartData().getCategories().add(southCategory);
    IChartDataCell northValue = workbook.getCell(0, 1, 1, 120);
    IChartDataCell southValue = workbook.getCell(0, 2, 1, 150);
    series.getDataPoints().addDataPointForBarSeries(northValue);
    series.getDataPoints().addDataPointForBarSeries(southValue);

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ชื่อ series ที่ได้คือ `Product A 2026` โดยมีช่องว่างคั่นระหว่างค่าจากสองเซลล์ legend แสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์ ภาพด้านล่างแสดงผลลัพธ์:

![แผนภูมิคอลัมน์ที่มีค่าทางเหนือและใต้และชื่อ series รวม Product A 2026 ใน legend](composite_series_name.png)

## **รับสี Fill อัตโนมัติของ Series**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากดัชนี series และสไตล์แผนภูมิในรูปแบบจำนวนเต็ม ARGB ของ Android นี่คือสีที่ใช้เมื่อไม่ได้กำหนด fill ของ series อย่างชัดเจน การเรียกเมธอดนี้จะอ่านค่าสีที่คำนวณได้; ไม่ได้กำหนด fill ใหม่

ตัวอย่างต่อไปนี้พิมพ์จำนวนเต็มสีอัตโนมัติของแต่ละ series เริ่มต้น:

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

ค่าจำนวนเต็มที่ได้ขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสี Fill สลับกลับสำหรับ Series**

สำหรับ series แบบบาร์, คอลัมน์และบับเบิล [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าติดลบด้วยสี fill ที่ต่างออกไป ตั้งค่า fill ปกติของ series เป็นแบบด้านเดียว, เปิดการสลับสี, แล้วกำหนดสีค่าติดลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ตัวเลขติดลบจะไม่เปลี่ยนใน workbook; มีเพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยหนึ่ง series worksheet แถว 0 มีชื่อ series, คอลัมน์ 0 มีชื่อหมวดหมู่, คอลัมน์ 1 มีค่า:

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

![สี Fill ด้านเดียวที่สลับกลับ](inverted_solid_fill_color.png)

คุณสามารถเปิดการสลับสีสำหรับจุดเดียวผ่าน [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ในตัวอย่างต่อไปนี้ การสลับสีถูกปิดสำหรับ series และเปิดเฉพาะจุดที่เลือก จุดนั้นยังได้รับค่าติดลบเพื่อให้เอฟเฟกต์ปรากฏ:

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

## **ล้างค่าของ Data Point เฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ workbook ที่เป็นพื้นหลังของจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลจะอยู่ที่ตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือค่านั้นเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองใน series แรก:

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

แผนภูมิกระจาย (scatter) ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่เป็นค่าที่ต้องการลบ อย่าเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อต้องการเก็บจุดอื่น ๆ เพราะเมธอดนี้จะลบจุดทั้งหมดในคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่แต่มีค่าเป็นกรณีที่ต่างจากเซลล์ว่าง เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ ให้ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างแสดงว่าขาดข้อมูล; เซลล์ที่มีค่า `0` แสดงค่าตัวเลขที่รู้จัก เรียก [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) ด้วย `null` เพื่อทำให้เซลล์เป็นค่าว่าง ศูนย์ตัวเลขยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด เปลี่ยนวิธีที่ช่องว่างถูกพล็อตโดยไม่เติมค่า 0 หรือค่าที่คำนวณจากการประมาณค่า

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีหนึ่ง series, ลบค่าของ Day 3 และบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายกำกับหมวดหมู่, คอลัมน์ 1 สำหรับค่าต่าง ๆ; แถว 0 บรรจุชื่อ series ค่าสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ให้ Day 3 เป็นค่าว่างจริง ๆ ในขณะที่ยังคงหมวดหมู่และจุดข้อมูลของมันไว้
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

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกพรีเซนเทชันครั้งเดียวแทนการวนลูปผ่านโหมดต่าง ๆ

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์ Day 3 เป็นค่าว่างใน workbook ทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap จะตัดเส้นที่ Day 3, Zero จะลดเส้นลงเป็นศูนย์, และ Span จะเชื่อม Day 2 ไปยัง Day 4.](display_blanks_as.png)

ผลที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบโหมดทั้งสามได้ง่าย แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อข้ามหมวดหมู่ที่หายไป ดังนั้น Span ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงในภาพได้; คอลัมน์หายและคอลัมน์ความสูงศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์และไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างของช่องว่างระหว่าง Series**

ความกว้างของช่องว่างเป็นช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่ม series พ่อแม่ ไม่ใช่ของชุดเดียว เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่จะเพิ่มช่องว่างระหว่างกลุ่ม, ค่าเล็กจะทำให้กลุ่มหนาแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกพรีเซนเทชันสุดท้ายเท่านั้น:

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

![ความกว้างของช่องว่าง](gap_width.png)

## **FAQ**

**แผนภูมิประเภทใดสนับสนุน series ข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ series ของแต่ละประเภทอาจมีโครงสร้างค่าและการตั้งค่าที่แตกต่างกัน ตัวอย่างเช่น แผนภูมิก่า​​หมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีสร้างจุดข้อมูลที่ตรงกับประเภท series การตั้งค่าเช่นการทับซ้อนและความกว้างช่องว่างใช้กับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้เท่านั้น

**What is a chart series group?** (keep original English term as identifier)

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) ประกอบด้วย series ที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านหนึ่ง series ไม่ได้หมายความว่าจะเปลี่ยนแปลงทุก series ในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี. โดยค่าเริ่มต้น [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) สร้าง series, หมวดหมู่และค่าตัวอย่าง คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดทั้งคอลเลกชัน series และหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่ การ overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อ series, ป้ายกำกับหมวดหมู่และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อตามข้อมูลแบบกำหนดเอง ควรรักษาแถวหมวดหมู่และแถวค่าของ series ให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ต้องการ

**ฉันจะลบจุดเดียวแทนการลบทั้ง series อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจาก series นั้น หากคุณลบหมวดหมู่อีกด้วย ควรอัปเดตทุก series เพื่อให้ค่าของพวกเขาอยู่ในแนวกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่า 0 หรือโดยเชื่อมจุดใกล้เคียงกัน เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในพรีเซนเทชันของคุณ ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างสมบูรณ์และการเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับ series บาร์, คอลัมน์และบับเบิลที่รองรับ ใช้ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) และตั้งค่าสีที่ได้จาก [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีเหล่านี้มีผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่จัดเก็บ

**การจัดรูปแบบใดชนะเมื่อทั้ง series และ point ถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลที่ชัดเจนจะมีลำดับความสำคัญเหนือ series สำหรับจุดนั้น Series อื่น ๆ ยังคงใช้การจัดรูปแบบ series ที่ชัดเจนหรือ หากไม่มีการกำหนด series จะใช้สไตล์และธีมของแผนภูมิเชิงอัตโนมัติ การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การเขียนทับการจัดรูปแบบระดับจุด

**แผนภูมิสามารถมี series ได้สูงสุดเท่าไหร่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวน series แยกออกมา อย่างไรก็ตาม ข้อจำกัดของไฟล์พรีเซนเทชัน, หน่วยความจำที่มี, เวลาเรนเดอร์และความเข้าใจง่ายของแผนภูมิจะกำหนดขีดจำกัดที่ใช้ได้จริง

**ฉันควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่ม series พ่อแม่ที่เหมาะสม เพิ่มค่าที่จะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าเพื่อทำให้กลุ่มใกล้ขึ้น

