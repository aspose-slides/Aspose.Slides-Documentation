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
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การทับ, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Java."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่พล็อตไว้ในเซลล์ของเวิร์กบุ๊กหรือเป็นค่าตัวเลขโดยตรงได้ [IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) แทนชุดค่าที่สัมพันธ์กันหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) แทนจุดหนึ่งในชุดนั้น [IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดค่าในแผนภูมิ สำหรับแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุด, หมวดหมู่, และค่าจุดใช้วัตถุ [IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) จากเวิร์กบุ๊กของแผนภูมิ

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป เวิร์กบุ๊กเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด ดัชนีของแผ่นงาน, แถว, และคอลัมน์ที่ส่งผ่านไปยัง [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) เป็นดัชนีฐานศูนย์ รูปแบบนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมืที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับการนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวดหมู่, และจุดข้อมูลก่อนที่จะเปลี่ยนค่าในเวิร์กบุ๊ก

การตั้งค่าแผนภูมิมี 3 ระดับขอบเขตที่แตกต่างกัน:

- การตั้งค่าระดับชุด เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) ให้การปรากฏเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าระดับจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะทับการแสดงผลของชุดสำหรับจุดเดียวนั้น
- การตั้งค่ากลุ่มจะใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่น การทับหรือความกว้างช่องว่าง

เมื่อไม่มีการตั้งค่าสีเติมจุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดการแสดงผลอัตโนมัติ เมื่อมีการตั้งค่าสีเติมทั้งของชุดและของจุด, การตั้งค่าสีเติมของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

สำหรับแผนภูมิทรงกระบอกแบบจัดกลุ่ม ให้ดูว่า **[การเปลี่ยนประเภทชุด 3D หรือรูปแบบแท่ง](/slides/th/java/3d-chart/#change-the-3d-series-type-and-bar-shape)** มีผลต่อชุดแรกอย่างไร

## **ตั้งค่าค่าชุดโดยใช้ค่าตัวเลขโดยตรง**

ใช้ค่าตัวเลขโดยตรงเมื่อค่าชุดมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องอ้างอิงเซลล์ในแผ่นงาน เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) พร้อมกับ [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) ก่อนกำหนดผลลัพธ์ของ [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) ของแต่ละจุดโดยใช้ [setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)

การตั้งค่าที่คอลเลกชันจะควบคุมประเภทแหล่งข้อมูลของค่าทั้งหมดในชุดนั้น เมธอด [getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) ของค่าจุดแต่ละค่าแจ้งประเภทที่เลือก; เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน เมื่อใช้ `Worksheet` ให้เรียก [getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) เพื่อเข้าถึงเซลล์ที่อ้างอิง เมื่อใช้ `DoubleLiterals` ให้เรียก [getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนค่าตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและหมวดหมู่เริ่มต้น, แล้วกำหนดค่าที่คำนวณได้ 10, 20, ฯลฯ ให้กับจุดที่มีอยู่ของชุดแรก บันทึกการนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่เก็บไว้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals);
    for (int i = 0; i < series.getDataPoints().size(); i++) {
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10);
    }

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("numeric_literals.pptx");
try {
    ISlide reopenedSlide = reopenedPresentation.getSlides().get_Item(0);
    IChart reopenedChart = (IChart) reopenedSlide.getShapes().get_Item(0);
    IChartSeries reopenedSeries = reopenedChart.getChartData().getSeries().get_Item(0);
    for (IChartDataPoint point : reopenedSeries.getDataPoints()) {
        System.out.println(point.getValue().getAsLiteralDouble());
    }
} finally {
    reopenedPresentation.dispose();
}
```

ประเภทแหล่งข้อมูลของค่าจุดแยกจาก [IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--) ซึ่งบ่งบอกการกำหนดค่าเวิร์กบุ๊กภายในหรือภายนอกของแผนภูมิ การใช้ค่าตัวเลขโดยตรงไม่ได้ลบเวิร์กบุ๊กที่ฝังอยู่โดยอัตโนมัติ ในตัวอย่างนี้ เวิร์กบุ๊กยังคงใช้สำหรับป้ายกำกับหมวดหมู่, ชื่อชุด, และชุดอื่น ๆ ดู [Chart Workbook](/slides/th/java/chart-workbook/) สำหรับการจัดการเวิร์กบุ๊ก

สำหรับแผนภูมิกระจายและฟองน้ำ ให้ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) เพื่อเลือกแหล่งสำหรับ [getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--) และ [getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) แผนภูมิกระจายแบบฟองน้ำยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--) ตั้งแหล่งที่เกี่ยวข้องทุกอันเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่านั้น

## **ตั้งค่าการทับของชุดแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าคอลัมน์หรือแท่งทับกันเท่าใดในแผนภูมิ 2 มิติ, จาก ‑100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่ ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงแท่งหรือคอลัมน์เป็นกลุ่ม; ไม่กระทบกับกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิเข้าร่วม

ตัวอย่างต่อไปนี้ตั้งค่าการทับสำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น

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

## **เปลี่ยนสีเติมของชุด**

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับชุดทั้งหมด ถ้าจุดมีการกำหนดสีเติมโดยชัดเจนแล้ว, การตั้งค่า [IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะทับสีเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมสีน้ำเงินทึบกับชุดแรก

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

ชื่อชุดจัดเก็บในเวิร์กบุ๊กของแผนภูมิและโดยปกติจะแสดงในคำอธิบาย ในเวิร์กบุ๊กเริ่มต้นสำหรับแผนภูมิคอลัมน์จัดกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) ได้ วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

### **สร้างชุดด้วยชื่อจากหลายเซลล์**

ชื่อชุดแบบประกอบมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานเก็บแยกกันในเซลล์ของเวิร์กบุ๊ก เช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวโดยยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทาง

ใช้ [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) เพื่อดึงช่วงชื่อ, แล้วส่งคอลเลกชันนั้นไปยัง [IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) อาร์กิวเมนต์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนหรือไม่: `true` จะละเว้น, `false` จะรวม ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีชุดหนึ่งและจุดข้อมูลสองจุด เซลล์ B1:C1 มีเพียงชื่อชุด, A2:A3 มีป้ายกำกับหมวดหมู่, และ B2:B3 มีค่าตัวเลข

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

    // เซลล์สองนี้ใช้เป็นชื่อชุด.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // เซลล์แยกกันใช้เป็นหมวดหมู่และจุดข้อมูลตัวเลข.
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

ชื่อชุดที่ได้คือ `Product A 2026`, มีช่องว่างคั่นระหว่างค่าจากสองเซลล์ คำอธิบายจะแสดงเป็นรายการเดียวสำหรับสองคอลัมน์ รูปภาพด้านล่างแสดงผลลัพธ์

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้อ่านค่าสีที่คำนวณแล้ว; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิดีฟอลต์

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้อาจแตกต่างกันตามสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมแบบกลับด้านสำหรับชุดแผนภูมิ**

สำหรับชุดประเภทแท่ง, คอลัมน์, และฟองน้ำ, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมของชุดเป็นสีทึบ, เปิดการกลับด้าน, แล้วกำหนดสีของค่าติดลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ตัวเลขติดลบจะคงอยู่ในเวิร์กบุ๊ก; เพียงเปลี่ยนสีการแสดงผลเท่านั้น

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว แถว 0 ของแผ่นงานบรรจุชื่อชุด, คอลัมน์ 0 บรรจุชื่อหมวดหมู่, และคอลัมน์ 1 บรรจุค่าต่าง ๆ

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

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวโดยใช้ [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ในตัวอย่างต่อไปนี้การกลับด้านถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก จุดนั้นยังถูกกำหนดค่าเป็นค่าติดลบเพื่อให้เห็นผล

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

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์เวิร์กบุ๊กของจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลยังคงอยู่ที่ตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจัดการค่าเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบค่าเพียงจุดที่สองในชุดแรก

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิกระจายฟองน้ำยังใช้เซลล์ขนาดฟองน้ำ ลบเฉพาะเซลล์ที่แทนค่าที่ต้องการลบเท่านั้น ห้ามเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) หากต้องการเก็บจุดอื่นไว้, เพราะเมธอดนี้จะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่แต่มีค่าเป็นกรณีแยกจากเซลล์ว่าง เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ในแผ่นงาน, ดู [Include Data from Hidden Rows and Columns](/slides/th/java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์เวิร์กบุ๊กที่ว่างเปล่าแสดงถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่ทราบ เรียก [IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) โดยให้ค่า `null` เพื่อทำให้เซลล์ว่าง ค่าตัวเลขศูนย์จะคงเป็นศูนย์ไม่ว่าจะตั้งค่าเซลล์ว่างอย่างไร

ใช้ [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) เพื่อเลือกวิธีที่แผนภูมิจัดการเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมดและเปลี่ยนวิธีการพล็อตช่องว่างโดยไม่ต้องเติมค่าเซลล์ว่างด้วยศูนย์หรือค่าประมาณ

ตัวอย่างต่อไปนี้เป็นโค้ดตัวอย่างแบบสแตนด์อโลนที่สร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าในวันที่ 3, แล้วบันทึกแผนภูมิเดียวกันสามโหมด ไม่มีไฟล์อินพุตจำเป็น [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายกำกับหมวดหมู่, คอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ปล่อยให้วัน 3 ว่างเปล่าจริง ๆ ในขณะยังคงรักษาหมวดหมู่และจุดข้อมูลของมันไว้.
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

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเพียงเวอร์ชันเดียว, กำหนดโหมดที่ต้องการแล้วบันทึกการนำเสนอครั้งเดียวแทนการวนลูปหลายโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์ วันที่ 3 จะว่างเปล่าในเวิร์กบุ๊กในทุกกรณี

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลกระทบที่มองเห็นได้ขึ้นกับประเภทแผนภูมิ แผนภูมิเส้นทำให้สามโหมดเปรียบเทียบได้ง่าย แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อเมื่อมีหมวดหมู่หายไป, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมต่อได้; คอลัมน์หายและคอลัมน์ศูนย์อาจดูคล้ายกัน เช่นเดียวกัน, แผนภูมิกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ใกล้เคียง, expressed as a percentage of the bar or column width. เช่นเดียวกับการทับ, มันเป็นคุณสมบัติของกลุ่มชุดแม่ ไม่ใช่ของชุดเดียว เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) หนึ่งครั้งต่อกลุ่ม ค่ามากจะสร้างช่องว่างมากขึ้นระหว่างกลุ่ม, ค่าน้อยจะทำให้กลุ่มใกล้เคียงกันมากขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกการนำเสนอสุดท้ายเท่านั้น

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

## **แสดงหรือซ่อนเส้นเชื่อมชุด**

เส้นเชื่อมชุดทำหน้าที่เชื่อมส่วนที่เกี่ยวข้องของแผนภูมิ ใช้ [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) เพื่อแสดงหรือซ่อนเส้นเหล่านี้ในแผนภูมิ stacked bar และ OfPie ที่รองรับ ในแผนภูมิ stacked bar และ column สองมิติ, เส้นเหล่านี้เชื่อมขอบของสแตกที่สอดคล้องกันข้ามหมวดหมู่ ในแผนภูมิ Pie of Pie และ Bar of Pie, เส้นเชื่อมส่วนหลักกับส่วนรอง การตั้งค่านี้ไม่ได้ทำหน้าที่เป็นตัวเชื่อมทั่วไปสำหรับประเภทแผนภูมิอื่น ๆ

เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) การตั้งค่านี้ใช้กับทุกชุดในกลุ่มนั้น [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#hasSeriesLines--) เป็นแบบอ่านอย่างเดียวและสะท้อนการตั้งค่าของกลุ่มแม่; เรียก setter ของกลุ่มเพื่ออัปเดต

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [PieOfPie](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/#PieOfPie) หนึ่งชุดด้วยข้อมูลเริ่มต้น บันทึกแผนภูมิเดียวกันสองครั้ง, ครั้งแรกเปิดใช้งานเส้นเชื่อมชุด, ครั้งที่สองปิดใช้งาน, เพื่อเปรียบเทียบผลลัพธ์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();

    seriesGroup.setSeriesLines(true);
    presentation.save("series_lines_enabled.pptx", SaveFormat.Pptx);

    seriesGroup.setSeriesLines(false);
    presentation.save("series_lines_disabled.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| เส้นเชื่อมชุดเปิด | เส้นเชื่อมชุดปิด |
| --- | --- |
| ![Pie of Pie chart with series lines enabled](series_lines_enabled.png) | ![Pie of Pie chart with series lines disabled](series_lines_disabled.png) |
| เส้นสองเส้นเชื่อมพายหลักกับพายรอง | พายทั้งสองยังคงมองเห็นได้, แต่เส้นเชื่อมถูกซ่อน |

เส้นเชื่อมชุดต่างจากเส้นนำของป้ายข้อมูล (เชื่อมป้ายกับจุดข้อมูล), เส้นกริด (ทำเครื่องหมายช่วงบนแกน), และเส้นในแผนภูมิเส้น (แสดงค่าข้อมูล) การตั้งค่านี้ไม่ได้ควบคุมองค์ประกอบเหล่านั้น

## **FAQ**

**แผนภูมิประเภทใดบ้างที่สนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่อยู่ใน enumeration [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่อาจมีโครงสร้างค่าหรือการตั้งค่าชุดที่ต่างกัน เช่น แผนภูมิดึงหมวดใช้หมวดและค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิกระจายฟองน้ำเพิ่มขนาดฟอง ให้ใช้เมธอดสร้างจุดข้อมูลที่ตรงกับประเภทชุด ตัวเลือกเช่น การทับและความกว้างช่องว่างใช้เฉพาะกับกลุ่มแท่งหรือคอลัมน์ที่เข้ากันได้

**กลุ่มชุดแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) จะบรรจุชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิรวมอาจมีหลายกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งอาจไม่ส่งผลต่อทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยค่าเริ่มต้น, [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) สร้างชุดตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองทั้งหมด มีโอเวอร์โหลดที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้เช่นกัน

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์เวิร์กบุ๊กอย่างไร?**

ชื่อชุด, ป้ายกำกับหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตส่วนที่สอดคล้องของแผนภูมิ เมื่อคุณสร้างข้อมูลกำหนดเอง, ให้รักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้จุดแต่ละจุดพล็อตภายใต้หมวดหมู่ที่ต้องการ

**จะลบจุดเดียวโดยไม่ลบทั้งชุดได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อเก็บตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดที่ว่างเปล่าจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นศูนย์, หรือเชื่อมจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าติดลบจะแสดงผลอย่างไร?**

สำหรับชุดแท่ง, คอลัมน์, และฟองน้ำที่รองรับ, ให้เรียก [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) และตั้งค่าสีที่คืนโดย [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถเปลี่ยนพฤติกรรมสำหรับจุดเดี่ยวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ใช่ค่าตัวเลขที่เก็บ

**เมื่อตั้งค่าทั้งชุดและจุด, การจัดรูปแบบใดชนะ?**

การจัดรูปแบบจุดโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ จะใช้การจัดรูปแบบชุดที่กำหนดหรือ, หากชุดไม่มีการจัดรูปแบบ, จะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ การตั้งค่ากลุ่มเช่น การทับและความกว้างช่องว่างควบคุมการจัดวางและไม่ได้เป็นการทับระดับจุด

**มีขีดจำกัดจำนวนชุดในแผนภูมิหรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแยกต่างหาก ในทางปฏิบัติ ข้อจำกัดมาจากข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรปรับอะไรเมื่อตัวคอลัมน์หรือแท่งใกล้กันเกินไปหรือห่างเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่าจะเพิ่มช่องว่างระหว่างกลุ่ม, ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น