---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอบน Android
linktitle: ชุดข้อมูล
type: docs
url: /th/androidjava/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์ workbook
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอบน Android."
---
## **ภาพรวม**

แผนภูมิสามารถจัดเก็บค่าที่พล็อตไว้ในเซลล์ของ workbook หรือโดยตรงเป็นค่าตัวเลขลิเทรัลได้ [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) แสดงชุดค่าที่สัมพันธ์กันหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) แสดงจุดข้อมูลในชุดนั้น [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) ให้ป้ายชื่อหรือค่ากลุ่มที่ใช้ร่วมกันระหว่างชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุดข้อมูล ประเภท และค่าจุดข้อมูลจะใช้วัตถุ [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) จาก workbook ของแผนภูมิ

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล คอลัมน์ 0 สำหรับชื่อประเภท และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนีของ worksheet, แถวและคอลัมน์ที่ส่งให้ [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) จะเป็นแบบนับตั้งแต่ศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับการนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุดข้อมูล ประเภท และจุดข้อมูล ก่อนที่จะเปลี่ยนค่าใน workbook

การตั้งค่าแผนภูมิมีสามระดับขอบเขตที่แตกต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในชุดข้อมูลหนึ่ง
- การตั้งค่าระดับจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะเขียนทับลักษณะของชุดข้อมูลสำหรับจุดนั้นหนึ่งจุด
- การตั้งค่ากลุ่มใช้กับชุดข้อมูลที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการกำหนดตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดข้อมูลโดยชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งชุดและจุด การกำหนดรูปแบบจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

สำหรับแผนภูมิทรงกระบอกแบบรวมกลุ่ม ให้ดูว่า [changing the 3D series type or bar shape](/slides/th/androidjava/3d-chart/#change-the-3d-series-type-and-bar-shape) มีผลต่อชุดแรกอย่างไร

## **ตั้งค่าค่าชุดข้อมูลโดยใช้ตัวเลขลิเทรัล**

ใช้ค่าตัวเลขลิเทรัลเมื่อค่าชุดข้อมูลมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ของ worksheet เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) พร้อมกับ [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) ก่อนกำหนดผลลัพธ์ของแต่ละจุดผ่าน [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) ด้วย [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งข้อมูลของค่าทุกจุดในชุดนั้น เมธอด [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) ของค่าจุดแต่ละจุดจะรายงานประเภทที่เลือก; เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน ด้วย `Worksheet` ใช้ [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) เพื่อเข้าถึงเซลล์ที่อ้างอิง ด้วย `DoubleLiterals` ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและประเภทเริ่มต้น แล้วกำหนดค่าที่คำนวณได้ 10, 20 ฯลฯ ให้กับจุดที่มีอยู่ของชุดแรก สุดท้ายบันทึกการนำเสนอแล้วเปิดใหม่และพิมพ์ค่าที่จัดเก็บไว้

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

ประเภทแหล่งข้อมูลของค่าจุดแยกจาก [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) ซึ่งบ่งชี้การกำหนดค่า workbook ภายในหรือภายนอกของแผนภูมิ การใช้ค่าตัวเลขลิเทรัลไม่ได้โดยอัตโนมัติเอา workbook ที่ฝังอยู่ออก ในตัวอย่างนี้ workbook ยังใช้งานได้สำหรับป้ายชื่อประเภท, ชื่อชุดข้อมูลและชุดอื่น ๆ ดู [Chart Workbook](/slides/th/androidjava/chart-workbook/) เพื่อเรียนรู้การจัดการ workbook

สำหรับแผนภูมิกระจายและฟองอากาศ ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) เพื่อเลือกแหล่งสำหรับ [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) และ [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--) แผนภูมิบับอากาศยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--) ตั้งค่าแหล่งที่ใช้แต่ละอย่างเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่าที่เกี่ยวข้อง

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2 มิติ ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่ ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; จะไม่ส่งผลต่อชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่ประกอบด้วยชุดแรก

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

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดหนึ่งมีการกำหนดสีเติมอย่างชัดเจน การตั้งค่า [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะเขียนทับสีเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมแบบทึบสีฟ้าให้กับชุดแรก

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

ชื่อชุดข้อมูลถูกจัดเก็บใน workbook ของแผนภูมิและปกติจะแสดงในคำอธิบาย ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบจัดกลุ่ม เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้เป็นที่ชัดเจน

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

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) ได้เช่นกัน วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

ชื่อชุดข้อมูลเชิงประกอบมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกเก็บในเซลล์ workbook แยกกัน ตัวอย่างเช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวขณะยังคงเชื่อมโยงส่วนทั้งสองกับเซลล์ต้นทาง

ใช้ [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นให้กับ [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-) พารามิเตอร์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนอยู่หรือไม่: `true` จะไม่รวม, `false` จะรวม ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีชุดเดียวและจุดข้อมูลสองจุด เซลล์ B1:C1 มีเพียงชื่อชุด; A2:A3 มีป้ายชื่อประเภท; B2:B3 มีค่าตัวเลข

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

    // เซลล์แยกกันใช้เป็นประเภทและจุดข้อมูลเชิงตัวเลข.
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

ชื่อชุดที่ได้คือ `Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์ คำอธิบายจะแสดงเป็นรายการเดียวสำหรับคอลัมน์ทั้งสอง ภาพด้านล่างแสดงผลลัพธ์:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุดข้อมูล**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิเป็นค่าเต็มแบบ Android ARGB นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดจะอ่านค่าสีที่คำนวณได้; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์ค่าจำนวนเต็มของสีอัตโนมัติสำหรับแต่ละชุดเริ่มต้น

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

ค่าจำนวนเต็มที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดข้อมูลแผนภูมิ**

สำหรับชุดข้อมูลบาร์, คอลัมน์ และบับเบิล สามารถใช้ [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) เพื่อแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติเป็นแบบทึบ เปิดใช้งานการกลับด้าน และกำหนดสีค่าติดลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) ตัวเลขติดลบจะยังคงอยู่ใน workbook; เพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิดั้งเดิมด้วยชุดข้อมูลหนึ่ง Worksheet แถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อประเภท, คอลัมน์ 1 มีค่า

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

คุณสามารถเปิดใช้งานการกลับด้านสำหรับจุดเดียวผ่าน [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก จุดนั้นยังได้รับการกำหนดค่าติดลบเพื่อให้เห็นผล

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

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ให้กำหนดค่าเซลล์ workbook ของจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) จุดข้อมูลจะคงตำแหน่งประเภทเดิม แต่แผนภูมิจะถือค่าของมันว่าเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, แผนภูมิบับอากาศยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่เป็นค่าที่ต้องการลบ อย่าเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เมื่อต้องการคงจุดอื่นไว้ เนื่องจากเมธอดนั้นจะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่ซึ่งมีค่าเป็นกรณีแยกต่างหากจากเซลล์ว่าง เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ ดู [Include Data from Hidden Rows and Columns](/slides/th/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างเปล่าแสดงถึงข้อมูลที่ขาดหาย; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่รู้จัก เรียก [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) ด้วย `null` เพื่อทำให้เซลล์ว่าง ศูนย์ตัวเลขยังคงเป็นศูนย์ไม่ว่า setting ของเซลล์ว่างจะเป็นอย่างไร

ใช้ [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) เพื่อเลือกว่ามีการแสดงเซลล์ว่างอย่างไร การตั้งค่านี้ใช้กับแผนภูมิตทั้งหมดยังเปลี่ยนวิธีที่ช่องว่างถูกพล็อตโดยไม่ต้องเติมค่า 0 หรือค่าประมาณลงในเซลล์ workbook ที่ว่าง

ตัวอย่างต่อไปนี้เป็นตัวอย่างอิสระที่สร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าในวันที่ 3, แล้วบันทึกแผนภูมิเดียวกันด้วยแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายชื่อประเภท, คอลัมน์ 1 สำหรับค่า; แถว 0 มีชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ทำให้วัน 3 ว่างเปล่าอย่างแท้จริง ในขณะที่ยังคงรักษาประเภทและจุดข้อมูลของมันไว้.
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

แต่ละไฟล์เอาต์พุตจะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` และ `empty_cells_Span.pptx` เพื่อบันทึกเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการแล้วบันทึกการนำเสนอเพียงครั้งเดียวแทนการวนลูปผ่านโหมดต่าง ๆ

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม วันที่ 3 จะว่างเปล่าใน workbook ทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นได้ขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบทั้งสามโหมดได้ง่าย แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมต่อข้ามประเภทที่หายไป จึงทำให้ `Span` ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงในภาพได้; คอลัมน์ที่หายไปและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิกระจายที่มีแต่เครื่องหมายก็ไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์สามแบบแยกกันสำหรับทุกประเภทแผนภูมิ; ควรตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือพื้นที่ระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดแม่ ไม่ใช่ของชุดเดียว เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) หนึ่งครั้งสำหรับกลุ่ม ค่าเพิ่มจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น ค่าเล็กลงจะทำให้กลุ่มกระชับขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกการนำเสนอที่ได้สุดท้ายเท่านั้น

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

## **แสดงหรือซ่อนเส้นเชื่อมชุดข้อมูล**

เส้นเชื่อมชุดข้อมูลเชื่อมต่อส่วนที่เกี่ยวข้องของแผนภูมิ ใช้ [IChartSeriesGroup.setSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setSeriesLines-boolean-) เพื่อแสดงหรือซ่อนเส้นเหล่านี้ในแผนภูมิบาร์และ OfPie ที่รองรับ ในแผนภูมิบาร์และคอลัมน์แบบซ้อนสองมิติ เส้นเหล่านี้เชื่อมขอบสแตกที่สอดคล้องกันข้ามประเภท ในแผนภูมิ Pie of Pie และ Bar of Pie เส้นเชื่อมส่วนหลักกับส่วนรอง การตั้งค่านี้ไม่ใช้เป็นตัวเชื่อมทั่วไปสำหรับประเภทแผนภูมิอื่น

เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) การตั้งค่านี้ใช้กับทุกชุดในกลุ่มนั้น [IChartSeries.hasSeriesLines](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#hasSeriesLines--) เป็นแบบอ่านอย่างเดียวและสะท้อนการตั้งค่าของกลุ่มแม่; เรียกตัวตั้งค่าของกลุ่มเพื่ออัปเดต

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [PieOfPie](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/#PieOfPie) หนึ่งรายการด้วยข้อมูลเริ่มต้น บันทึกแผนภูมิเดียวกันโดยเปิดใช้งานเส้นเชื่อมชุดและปิดใช้งานสองครั้ง เพื่อเปรียบเทียบ

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
| สองเส้นเชื่อมพายหลักกับพายรอง | พายทั้งสองยังคงมองเห็นได้ แต่เส้นเชื่อมถูกซ่อน |

เส้นเชื่อมชุดต่างจากเส้นนำทางของป้ายข้อมูลซึ่งเชื่อมป้ายกับจุดข้อมูล; เส้นกริดที่ทำเครื่องหมายช่วงตามแกน; และเส้นในแผนภูมิเส้นซึ่งแสดงค่าข้อมูล การตั้งค่านี้ไม่ได้ควบคุมองค์ประกอบเหล่านั้น

## **ข้อถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของแต่ละประเภทอาจมีโครงสร้างค่าและการตั้งค่าที่แตกต่างกัน ตัวอย่างเช่น แผนภูมิประเภทหมวดหมู่ใช้ประเภทและค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิบับอากาศเพิ่มขนาดบับเบิล ใช้วิธีสร้างจุดข้อมูลที่ตรงกับประเภทชุดข้อมูล การตั้งค่าเช่นการทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากัน

**กลุ่มชุดข้อมูลแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันได้ซึ่งแชร์การตั้งค่าการวาดระดับกลุ่ม แผนภูมิผสมสามารถมีหลายกลุ่มได้ ดังนั้นการเปลี่ยนกลุ่มผ่านชุดข้อมูลหนึ่งไม่จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยค่าเริ่มต้น [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) จะสร้างชุดข้อมูล ตัวประเภท และค่า ตัวอย่าง คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและประเภทก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่ การโอเวอร์โหลดบางอย่างยังสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อชุดข้อมูล, ป้ายชื่อประเภท, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลกำหนดเอง ให้จัดแถวประเภทและแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดถูกพล็อตภายใต้ประเภทที่ตั้งใจ

**จะลบจุดเดียวแทนที่จะลบชุดทั้งหมดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อคงตำแหน่งประเภทของจุดเป็นจุดว่าง ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบประเภทด้วย ต้องอัปเดตทุกชุดเพื่อให้ค่าคงสอดคล้องกับคอลเลกชันประเภท

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่า 0, หรือเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) เพื่อดูตัวอย่างเต็มรูปแบบและเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ ให้เรียก [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) แล้วตั้งค่าสีที่คืนจาก [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่จัดเก็บ

**การจัดรูปแบบไหนชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลโดยชัดเจนมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ ยังคงใช้การจัดรูปแบบชุดที่ชัดเจน หรือเมื่อชุดไม่มีการกำหนดรูปแบบ จะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการวางรูปแบบและไม่ใช่การเขียนทับระดับจุด

**มีขีดจำกัดจำนวนชุดข้อมูลที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดข้อมูลแยกออกมา ในทางปฏิบัติ ขนาดไฟล์การนำเสนอ, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์, และความสามารถในการอ่านของแผนภูมิเป็นปัจจัยที่กำหนดขีดจำกัดที่มีประโยชน์

**ควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มชุดแม่ที่เหมาะสม ค่าเพิ่มจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือค่าเล็กลงจะทำให้กลุ่มเข้าใกล้กันมากขึ้น