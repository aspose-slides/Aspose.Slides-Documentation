---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Java
linktitle: ชุดข้อมูล
type: docs
url: /th/java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- ชื่อชุดข้อมูล
- จุดข้อมูล
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุดข้อมูล
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Java."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่พล็อตไว้ในเซลล์ของเวิร์กบุ๊กหรือโดยตรงเป็นค่าตัวเลขแบบลิเทอรัลได้[IChartSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ[IChartDataPoint](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/) แทนจุดหนึ่งในชุดนั้น[IChartCategory](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/) ให้ป้ายชื่อหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุดข้อมูล หมวดหมู่ และค่าจุด จะใช้[IChartDataCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/) จากเวิร์กบุ๊กของแผนภูมิ

สำหรับแผนภูมิแบบหมวดหมู่ทั่วไป เวิร์กบุ๊กเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล คอลัมน์ 0 สำหรับชื่อหมวดหมู่ และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนีแผ่นทำงาน แถว และคอลัมน์ที่ส่งผ่านไปยัง[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) นับจากศูนย์ การจัดเรียงนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าทุกแผนภูมิที่มีอยู่ใช้วิธีนี้ สำหรับการนำเสนอที่โหลดมา ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุดข้อมูล หมวดหมู่ และจุดข้อมูลก่อนที่จะเปลี่ยนค่าในเวิร์กบุ๊ก

การตั้งค่าแผนภูมิมีสามระดับที่ต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--) ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในชุดข้อมูลหนึ่ง
- การตั้งค่าจุดข้อมูล เช่น[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะเขียนทับลักษณะของชุดข้อมูลสำหรับจุดเดียว
- การตั้งค่ากลุ่มใช้กับชุดข้อมูลที่เข้ากันได้ซึ่งอยู่ใน[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน[IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการกำหนดตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง

หากไม่มีการกำหนดการเติมจุดหรือชุดข้อมูลโดยเฉพาะ สไตล์และธีมของแผนภูมิจะกำหนดลักษณะที่อัตโนมัติ เมื่อมีการจัดรูปแบบทั้งชุดข้อมูลและจุดพร้อมกัน การจัดรูปแบบจุดจะมีอำนาจเหนือจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าค่าชุดข้อมูลโดยใช้ค่าตัวเลขแบบลิเทอรัล**

ใช้ค่าตัวเลขแบบลิเทอรัลเมื่อค่าชุดข้อมูลมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องอ้างอิงเซลล์ของแผ่นทำงาน เรียก[setDataSourceTypeForValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-)พร้อมกับ[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/#DoubleLiterals) ก่อนกำหนดผลลัพธ์ของ[getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) ของแต่ละจุดผ่าน[setAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งที่มาของค่าจุดทั้งหมดในชุดข้อมูลนั้น ค่าการเรียก[getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ibasechartvalue/#getDataSourceType--) ของแต่ละจุดจะแสดงประเภทที่เลือก; ให้เปลี่ยนผ่านการตั้งค่าคอลเลกชัน ด้วย`Worksheet` ใช้[getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/isinglecellchartvalue/#getAsCell--) เพื่อเข้าถึงเซลล์ที่อ้างอิง ด้วย`DoubleLiterals` ใช้[getAsLiteralDouble](https://reference.aspose.com/slides/java/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) หรือ`setAsLiteralDouble`เพื่ออ่านหรือเขียนจำนวนโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดข้อมูลและหมวดหมู่เริ่มต้น แล้วกำหนดค่าที่คำนวณได้เป็น 10, 20, … ให้กับจุดที่มีอยู่ของชุดแรก บันทึกการนำเสนอ เปิดใหม่อีกครั้ง และพิมพ์ค่าที่เก็บไว้

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

ประเภทแหล่งที่มาของค่าจุดแยกจาก[IChartData.getDataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getDataSourceType--) ซึ่งระบุการกำหนดค่าเวิร์กบุ๊กภายในหรือภายนอกของแผนภูมิ การใช้ค่าตัวเลขแบบลิเทอรัลโดยตัวเองไม่ได้ลบเวิร์กบุ๊กที่ฝังอยู่ ในตัวอย่างนี้ เวิร์กบุ๊กยังคงใช้สำหรับป้ายชื่อหมวดหมู่ ชื่อชุดข้อมูล และชุดอื่น ๆ ดู[Chart Workbook](/slides/th/java/chart-workbook/)สำหรับการจัดการเวิร์กบุ๊ก

สำหรับแผนภูมิกระจายและฟองอากาศ ใช้[setDataSourceTypeForXValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-)และ[setDataSourceTypeForYValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-)เพื่อกำหนดแหล่งที่มาสำหรับ[getXValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getXValue--)และ[getYValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getYValue--) แผนภูมิฟองอากาศยังใช้[setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-)สำหรับ[getBubbleSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getBubbleSize--) ตั้งค่าแหล่งที่มาที่เกี่ยวข้องแต่ละอันเป็น`DoubleLiterals`ก่อนกำหนดตัวเลขผ่านเมธอด`setAsLiteralDouble`ของค่านั้น

## **ตั้งค่าการทับซ้อนของชุดข้อมูลในแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2 มิติ ค่าอยู่ระหว่าง ‑100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่าน‑อย่าง‑เดียวนของการตั้งค่าในกลุ่มชุดข้อมูลแม่ ใช้[IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-)เพื่ออัปเดตทุกชุดข้อมูลที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดข้อมูลที่ไม่เกี่ยวข้องในแผนภูมิผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดแรกอยู่

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // แผนภูมิใหม่มีชุดข้อมูลตัวอย่าง, หมวดหมู่, และค่า.
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

## **เปลี่ยนสีการเติมของชุดข้อมูล**

ใช้[IChartSeries.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getFormat--)เพื่อกำหนดการเติมแบบเริ่มต้นสำหรับชุดข้อมูลทั้งหมด หากจุดมีการเติมที่กำหนดโดยเฉพาะ การตั้งค่า[IChartDataPoint.getFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getFormat--) จะเขียนทับการเติมของชุดข้อมูลสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าแบบทึบกับชุดแรก

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

ชื่อชุดข้อมูลถูกจัดเก็บในเวิร์กบุ๊กของแผนภูมิและโดยปกติจะแสดงในคำอธิบาย legend ในเวิร์กบุ๊กเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบจัดกลุ่ม เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปทำให้โครงสร้างนี้ชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่[IChartSeries.getName](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getName--) อ้างอิงอยู่ วิธีนี้ช่วยหลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

### **สร้างชุดข้อมูลด้วยชื่อจากหลายเซลล์**

ชื่อชุดข้อมูลผสมเป็นประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานเก็บในเซลล์เวิร์กบุ๊กแยกกัน ตัวอย่างเช่น สามารถรวม`Product A`ใน B1และ`2026`ใน C1เป็นชื่อชุดเดียวขณะที่ยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทาง

ใช้[IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-)เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นไปยัง[IChartSeriesCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) พารามิเตอร์`skipHiddenCells`ควบคุมว่าจะรวมเซลล์ที่ซ่อนอยู่หรือไม่: `true` จะไม่รวม, `false` จะรวม ตัวอย่างนี้ใช้`false`เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีชุดข้อมูลหนึ่งชุดและจุดข้อมูลสองจุด เซลล์ B1:C1 ใช้เฉพาะชื่อชุด; A2:A3 ใช้ป้ายหมวดหมู่, B2:B3 ใช้ค่าตัวเลข

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

    // เซลล์สองเซลล์นี้ให้ชื่อชุดข้อมูล.
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

ชื่อชุดที่ได้คือ`Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์ legend จะแสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์ ภาพด้านล่างแสดงผลลัพธ์

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีการเติมอัตโนมัติของชุดข้อมูล**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากดัชนีของชุดข้อมูลและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมของชุดข้อมูลไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดจะอ่านสีที่คำนวณได้; ไม่ได้กำหนดการเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดข้อมูลเริ่มต้น

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเบื้องต้น

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีการเติมกลับด้านสำหรับชุดข้อมูลในแผนภูมิ**

สำหรับชุดข้อมูลบาร์, คอลัมน์และฟองอากาศ[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)สามารถแสดงค่าลบด้วยสีการเติมต่างออกไป ตั้งค่าการเติมของชุดข้อมูลเป็นสีทึบ เปิดการกลับด้าน และกำหนดสีค่าลบผ่าน[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ตัวเลขลบจะยังคงอยู่ในเวิร์กบุ๊ก; มีเพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดข้อมูลหนึ่ง แผ่นทำงานแถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, คอลัมน์ 1 มีค่า

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

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ในตัวอย่างต่อไป การกลับด้านถูกปิดสำหรับชุดข้อมูลและเปิดเฉพาะจุดที่เลือก จุดดังกล่าวยังถูกกำหนดให้มีค่าเป็นลบเพื่อให้เห็นผล

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

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์เวิร์กบุ๊กที่แบ็คอัพเป็น`null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน[IChartDataPoint.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลจะคงตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือค่าของมันว่าเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, แผนภูมิฟองอากาศยังใช้เซลล์ขนาด ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อคุณต้องการรักษาจุดอื่นไว้ เพราะเมธอดนั้นจะลบทุกจุดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่ซึ่งมีค่าเป็นกรณีแยกจากเซลล์ว่าง เพื่อรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ ดู[Include Data from Hidden Rows and Columns](/slides/th/java/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์เวิร์กบุ๊กที่ว่างเปล่าหมายถึงข้อมูลที่หายไป; เซลล์ที่มีค่า`0`หมายถึงค่าตัวเลขที่ทราบ เรียก[IChartDataCell.setValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-)ด้วย`null`เพื่อทำให้เซลล์ว่าง ค่าศูนย์ตัวเลขจะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด จะเปลี่ยนวิธีที่ค่าว่างถูกพล็อตโดยไม่เติมเซลล์เวิร์กบุ๊กที่ว่างด้วยศูนย์หรือค่าประมาณ

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดข้อมูลหนึ่งชุด ลบค่าของวัน 3 และบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) ใช้แผ่นทำงาน 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, คอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ`10, 20, empty, 30, 40`

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

    // ทิ้งให้วัน 3 เป็นค่าว่างจริง ๆ โดยรักษาหมวดหมู่และจุดข้อมูลไว้
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

แต่ละไฟล์ผลลัพธ์จะเก็บโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` เพื่อลบไฟล์อื่นให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนลูปโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม วัน 3 จะว่างเปล่าในเวิร์กบุ๊กทุกกรณี

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดหมู่ที่หายไป ดังนั้น`Span`จึงไม่สามารถสร้างส่วนเชื่อมที่แสดงด้านบน; คอลัมน์ที่หายและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิกระจายที่มีเครื่องหมายเท่านั้นไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุดข้อมูล**

ความกว้างของช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน คิดเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดข้อมูลแม่ ไม่ใช่ของชุดข้อมูลเดียว เรียก[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่จะสร้างช่องว่างมากขึ้นระหว่างกลุ่ม; ค่าเล็กจะทำให้กลุ่มหนาแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกการนำเสนอสุดท้ายเท่านั้น

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

**แผนภูมิประเภทใดบ้างที่สนับสนุนชุดข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่แสดงโดยการนับจำนวน[ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของแต่ละประเภทไม่จำเป็นต้องมีโครงสร้างหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิฟองอากาศเพิ่มขนาดฟอง ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทของชุดข้อมูล ตัวเลือกเช่นการทับซ้อนและความกว้างของช่องว่างใช้กับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้เท่านั้น

**กลุ่มชุดข้อมูลในแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/) มีชุดข้อมูลที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิผสมสามารถมีหลายกลุ่ม ดังนั้นการเปลี่ยนกลุ่มผ่านชุดข้อมูลหนึ่งอาจไม่เปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี โดยปกติ[IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) จะสร้างชุดข้อมูล, หมวดหมู่ และค่าแบบตัวอย่าง คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดข้อมูลและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองทั้งหมด การ overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์เวิร์กบุ๊กอย่างไร?**

ชื่อชุดข้อมูล, ป้ายชื่อหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน[IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตามนั้น เมื่อคุณสร้างข้อมูลกำหนดเอง ให้จัดแถวหมวดหมู่และแถวค่าชุดข้อมูลให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตใต้หมวดหมู่ที่ต้องการ

**ฉันจะลบจุดเดียวแทนการลบชุดข้อมูลทั้งหมดได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น`null`เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้[IChartDataPointCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#clear--)เฉพาะเมื่อต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย ควรอัปเดตทุกชุดให้ค่าตรงกับคอลเลกชันหมวดหมู่

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน[IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยเชื่อมจุดที่อยู่ใกล้กัน เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู[Control the Display of Empty Cells](#control-the-display-of-empty-cells)สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดข้อมูลบาร์, คอลัมน์และฟองอากาศที่รองรับ ให้เรียก[IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-)และตั้งค่าสีที่[IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดี่ยวด้วย[IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีเหล่านี้มีผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่เก็บ

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดโดยเฉพาะจะมีอำนาจเหนือจุดนั้น จุดอื่น ๆ จะใช้การจัดรูปแบบชุดที่กำหนดไว้หรือหากชุดไม่ได้กำหนด การจัดรูปแบบอัตโนมัติตามสไตล์และธีมของแผนภูมิ การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดเรียงและไม่ใช่การเขียนทับระดับจุด

**มีขีดจำกัดจำนวนชุดข้อมูลที่แผนภูมิอาจมีหรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนชุดข้อมูลแยกออกมา ในทางปฏิบัติ ข้อจำกัดขึ้นกับขนาดไฟล์การนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก[IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-)บนกลุ่มชุดข้อมูลแม่ที่เหมาะสม เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าจะทำให้กลุ่มเข้ามาใกล้กันมากขึ้น.