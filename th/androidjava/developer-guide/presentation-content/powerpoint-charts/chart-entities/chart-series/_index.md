---
title: จัดการชุดข้อมูลกราฟในงานนำเสนอบน Android
linktitle: ชุดข้อมูล
type: docs
url: /th/androidjava/chart-series/
keywords:
- ชุดข้อมูลกราฟ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- ชื่อชุดข้อมูล
- จุดข้อมูล
- เซลล์เวิร์กบุ๊ก
- ช่องว่างของชุดข้อมูล
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลกราฟ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอบน Android."
---
## **ภาพรวม**

กราฟสามารถบันทึกค่าที่พลอตลงในเซลล์ของ workbook หรือเป็นค่าตัวเลขโดยตรงได้  [IChartSeries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/) แสดงจุดหนึ่งในชุดนั้น  [IChartCategory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/) ให้ฉลากหรือค่ากลุ่มที่ใช้ร่วมกันระหว่างซีรีส์  ในกราฟที่สร้างด้วยข้อมูลเริ่มต้น ชื่อซีรีส์, หมวดหมู่ และค่าจุดข้อมูลจะใช้วัตถุ [IChartDataCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/) จากแผ่นงานกราฟ

สำหรับกราฟประเภทหมวดหมู่ทั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อซีรีส์, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าซีรีส์  ดัชนี worksheet, แถว และคอลัมน์ที่ส่งไปยัง [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-) มีค่าเริ่มต้นจากศูนย์  โครงสร้างนี้มีประโยชน์เมื่อคุณสร้างกราฟด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าทุกกราฟที่มีอยู่ใช้โครงสร้างนี้  สำหรับงานนำเสนอที่โหลดแล้วให้ตรวจสอบเซลล์ที่ซีรีส์, หมวดหมู่, และจุดข้อมูลอ้างอิง ก่อนทำการเปลี่ยนค่าใน workbook

การตั้งค่ากราฟมีสามระดับต่างกัน:

- การตั้งค่าระดับซีรีส์ เช่น [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในซีรีส์หนึ่ง
- การตั้งค่าจุดข้อมูล เช่น [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะทับลักษณะของซีรีส์สำหรับจุดเดียว
- การตั้งค่ากลุ่มใช้กับซีรีส์ที่เข้ากันได้และอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) เดียวกัน  เข้าถึงกลุ่มผ่าน [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่น การทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีจุดหรือซีรีส์โดยชัดเจน สไตล์และธีมของกราฟจะกำหนดลักษณะอัตโนมัติ  หากมีการฟอร์แมตทั้งซีรีส์และจุดพร้อมกัน การฟอร์แมตจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าค่าซีรีส์โดยใช้ตัวเลขลิเทอรัล**

ใช้ตัวเลขลิเทอรัลเมื่อค่าซีรีส์มาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่จำเป็นต้องอ้างอิงเซลล์ใน worksheet เรียก [setDataSourceTypeForValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForValues-int-) ด้วย [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/#DoubleLiterals) ก่อนกำหนดผลลัพธ์ของแต่ละจุดด้วย [getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) ผ่าน [setAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#setAsLiteralDouble-double-)

การตั้งค่าคอลเลกชันจะควบคุมประเภทแหล่งข้อมูลของค่าจุดทั้งหมดในซีรีส์นั้น  วิธีการ [getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibasechartvalue/#getDataSourceType--) ของแต่ละจุดจะแจ้งประเภทที่เลือกไว้; เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน  หากใช้ `Worksheet` ให้ใช้ [getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isinglecellchartvalue/#getAsCell--) เพื่อเข้าถึงเซลล์ที่อ้างอิง  หากใช้ `DoubleLiterals` ให้ใช้ [getAsLiteralDouble](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idoublechartvalue/#getAsLiteralDouble--) หรือ `setAsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างกราฟคอลัมน์ด้วยซีรีส์และหมวดหมู่เริ่มต้น แล้วกำหนดค่าที่คำนวณได้ 10, 20 ฯลฯ ให้กับจุดที่มีอยู่ของซีรีส์แรก  จากนั้นบันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่บันทึกไว้

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

ประเภทแหล่งข้อมูลของค่าจุดจะแยกจาก [IChartData.getDataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getDataSourceType--) ซึ่งบ่งบอกการกำหนดค่า workbook ภายในหรือภายนอกของกราฟ  การใช้ตัวเลขลิเทอรัลเองไม่ทำให้ workbook ที่ฝังอยู่ถูกลบออก  ในตัวอย่างนี้ workbook ยังคงใช้ได้สำหรับฉลากหมวดหมู่, ชื่อซีรีส์, และซีรีส์อื่น ๆ  ดู [Chart Workbook](/slides/th/androidjava/chart-workbook/) เพื่อเรียนรู้การจัดการ workbook

สำหรับกราฟกระจายและฟองอากาศ ให้ใช้ [setDataSourceTypeForXValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForXValues-int-) และ [setDataSourceTypeForYValues](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForYValues-int-) เพื่อเลือกแหล่งข้อมูลสำหรับ [getXValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getXValue--) และ [getYValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getYValue--)  กราฟฟองอากาศยังใช้ [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#setDataSourceTypeForBubbleSizes-int-) สำหรับ [getBubbleSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getBubbleSize--)  ตั้งค่าแต่ละแหล่งที่เกี่ยวข้องเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านเมธอด `setAsLiteralDouble` ของค่าดังกล่าว

## **ตั้งค่าการทับซ้อนของซีรีส์กราฟ**

[IChartSeries.getOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getOverlap--) รายงานเปอร์เซ็นต์การทับซ้อนของแถบหรือคอลัมน์ในกราฟ 2 มิติ ตั้งแต่ -100 ถึง 100  เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มซีรีส์แม่  ใช้ [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) เพื่ออัปเดตทุกซีรีส์ที่เข้ากันได้ในกลุ่มนั้น  ตัวเลือกนี้ใช้กับประเภทกราฟที่แสดงแถบหรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มซีรีส์ที่ไม่เกี่ยวข้องในกราฟแบบรวม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่ประกอบด้วยซีรีส์แรก:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // กราฟใหม่มีซีรีส์ตัวอย่าง, หมวดหมู่, และค่า.
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

## **เปลี่ยนสีการเติมของซีรีส์**

ใช้ [IChartSeries.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getFormat--) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับซีรีส์ทั้งหมด  หากจุดมีการเติมสีโดยชัดเจนแล้ว การตั้งค่า [IChartDataPoint.getFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) จะทับการเติมสีของซีรีส์สำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีฟอร์มแบบทึบสีฟ้าแก่ซีรีส์แรก:

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

## **เปลี่ยนชื่อซีรีส์**

ชื่อซีรีส์ถูกจัดเก็บในแผ่นงานข้อมูลของกราฟและโดยปกติจะแสดงในคำอธิบายตาราง  ใน workbook เริ่มต้นที่สร้างสำหรับกราฟคอลัมน์แบบกลุ่ม เซลล์ B1 มีตำแหน่งแถว 0 คอลัมน์ 1 และบรรจุชื่อของซีรีส์แรก  ค่าคงที่ที่ตั้งชื่อไว้ในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getName--) ได้เช่นกัน  วิธีนี้หลีกเลี่ยงการสมมติว่ามีแถวหรือคอลัมน์ที่เจาะจงในกราฟที่มีอยู่:

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

### **สร้างซีรีส์ที่มีชื่อจากหลายเซลล์**

ชื่อซีรีส์แบบประกอบมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกเก็บในเซลล์ workbook แยกกัน  ตัวอย่างเช่น สามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อซีรีส์เดียวโดยยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทาง

ใช้ [IChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getCellCollection-java.lang.String-boolean-) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นไปยัง [IChartSeriesCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriescollection/#add-com.aspose.slides.IChartCellCollection-int-)  พารามิเตอร์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนหรือไม่: `true` จะละเว้น, `false` จะรวม  ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีซีรีส์หนึ่งและจุดข้อมูลสองจุด  เซลล์ B1:C1 มีเพียงชื่อซีรีส์; A2:A3 มีฉลากหมวดหมู่, และ B2:B3 มีค่าตัวเลข

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

    // เซลล์สองเซลล์นี้เป็นแหล่งชื่อซีรีส์.
    workbook.getCell(0, 0, 1, "Product A");
    workbook.getCell(0, 0, 2, "2026");
    IChartCellCollection nameCells = workbook.getCellCollection("Sheet1!$B$1:$C$1", false);
    IChartSeries series = chart.getChartData().getSeries().add(nameCells, ChartType.ClusteredColumn);

    // เซลล์แยกต่างหากให้ข้อมูลหมวดหมู่และจุดข้อมูลเชิงตัวเลข.
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

ชื่อซีรีส์ที่ได้คือ `Product A 2026` โดยมีช่องว่างคั่นระหว่างค่าจากสองเซลล์  คำอธิบายจะแสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์  ภาพด้านล่างแสดงผลลัพธ์:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีการเติมซีรีส์อัตโนมัติ**

[IChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) คืนค่าสีที่คำนวณจากดัชนีซีรีส์และสไตล์กราฟในรูปแบบจำนวนเต็ม Android ARGB  นี่คือสีที่ใช้เมื่อการเติมสีของซีรีส์ไม่ได้กำหนดอย่างชัดเจน  การเรียกเมธอดนี้อ่านสีที่คำนวณแล้ว; ไม่ได้กำหนดการเติมสีใหม่

ตัวอย่างต่อไปนี้พิมพ์จำนวนเต็มสีอัตโนมัติของแต่ละซีรีส์เริ่มต้น:

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

ค่าจำนวนเต็มที่ได้จะแตกต่างตามสไตล์และธีมของกราฟ

## **ตั้งค่าสีการเติมแบบกลับหัวสำหรับซีรีส์กราฟ**

สำหรับซีรีส์ประเภทแถบ, คอลัมน์, และฟองอากาศ, [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป  ตั้งค่าการเติมสีของซีรีส์เป็นสีทึบ, เปิดใช้งานการกลับหัว, และกำหนดสีค่าติดลบผ่าน [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)  ค่าติดลบจะยังคงอยู่ใน workbook; เพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลกราฟเริ่มต้นด้วยซีรีส์หนึ่ง  แถว worksheet 0 มีชื่อซีรีส์, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่า:

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

คุณสามารถเปิดใช้งานการกลับหัวสำหรับจุดเดียวผ่าน [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)  ในตัวอย่างต่อไปนี้ การกลับหัวถูกปิดสำหรับซีรีส์และเปิดเฉพาะจุดที่เลือก  จุดนั้นยังถูกกำหนดค่าเป็นค่าติดลบเพื่อให้เห็นผล:

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

## **ลบค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้กำหนดค่าเซลล์ workbook ที่สนับสนุนเป็น `null`  สำหรับกราฟคอลัมน์ ค่าที่พลอตได้สามารถเข้าถึงได้ผ่าน [IChartDataPoint.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#getValue--)  จุดข้อมูลจะคงอยู่ที่ตำแหน่งหมวดหมู่เดียวกัน แต่กราฟจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของกราฟ

ตัวอย่างต่อไปนี้ลบค่าเฉพาะจุดที่สองของซีรีส์แรก:

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

กราฟกระจายใช้เซลล์ X และ Y แยกกัน, กราฟฟองอากาศยังใช้เซลล์ขนาดด้วย  ให้ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ  อย่าเรียก [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) หากต้องการคงจุดอื่นไว้ เพราะเมธอดนี้จะลบทุกจุดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนซึ่งมีค่าเป็นกรณีแยกจากเซลล์ว่าง  หากต้องการรวมหรือแยกข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อน ให้ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/androidjava/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างแสดงถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่รู้จัก  เรียก [IChartDataCell.setValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setValue-java.lang.Object-) ด้วย `null` เพื่อทำให้เซลล์เป็นค่าว่าง  ตัวเลขศูนย์จะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) เพื่อเลือกวิธีที่กราฟแสดงเซลล์ว่าง  การตั้งค่านี้ใช้กับกราฟทั้งหมด  จะเปลี่ยนวิธีที่ค่าว่างถูกพลอตโดยไม่ต้องเติมค่า 0 หรือค่าประมาณลงในเซลล์ workbook ที่ว่าง

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่สมบูรณ์ สร้างกราฟเส้นที่มีซีรีส์หนึ่ง, ลบค่าของ Day 3, และบันทึกกราฟเดียวกันในแต่ละโหมด  ไม่จำเป็นต้องมีไฟล์อินพุต  [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับฉลากหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อซีรีส์  ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    // ปล่อยให้วัน 3 ว่างจริง ๆ แต่ยังคงหมวดหมู่และจุดข้อมูลไว้
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

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดไว้ก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`  หากต้องการบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในสามไฟล์  Day 3 จะเป็นค่าว่างใน workbook ทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทกราฟ  กราฟเส้นทำให้สามโหมดนี้ง่ายต่อการเปรียบเทียบ  กราฟแถบและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงข้างต้น; คอลัมน์ที่หายไปและคอลัมน์ความสูงศูนย์อาจดูคล้ายกันเช่นกัน  เช่นเดียวกับกราฟกระจายที่มีเฉพาะเครื่องหมายก็ไม่มีเส้นเชื่อมต่อ  อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทกราฟ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของซีรีส์**

ความกว้างช่องว่างคือระยะห่างระหว่างกลุ่มแถบหรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างแถบหรือคอลัมน์  เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มซีรีส์พาเรนต์ ไม่ได้เป็นของแต่ละซีรีส์  เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) ครั้งเดียวสำหรับกลุ่ม  ค่าที่มากขึ้นจะสร้างช่องว่างมากขึ้นระหว่างกลุ่ม; ค่าที่น้อยลงจะทำให้กลุ่มชิดกันมากขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนค่าความกว้างช่องว่างและบันทึกงานนำเสนอครั้งสุดท้ายเท่านั้น:

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

**กราฟประเภทใดสนับสนุนข้อมูลซีรีส์?**

ทุกประเภทกราฟที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) ใช้ข้อมูลกราฟ, แต่ซีรีส์ของแต่ละประเภทอาจมีโครงสร้างค่าและการตั้งค่าที่แตกต่างกัน  ตัวอย่างเช่น กราฟประเภทหมวดหมู่ใช้หมวดหมู่และค่า, กราฟกระจายใช้ค่า X และ Y, และกราฟฟองอากาศเพิ่มขนาดฟอง  ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทซีรีส์  ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้กับกลุ่มแถบหรือคอลัมน์ที่เข้ากันได้เท่านั้น

**กลุ่มซีรีส์กราฟคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/) มีซีรีส์ที่เข้ากันได้ซึ่งใช้การตั้งค่าการพลอตระดับกลุ่ม  กราฟแบบผสมอาจมีหลายกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านซีรีส์หนึ่งอาจไม่ส่งผลต่อทุกซีรีส์ในกราฟ

**กราฟที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่  โดยค่าเริ่มต้น [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) จะสร้างซีรีส์, หมวดหมู่, และค่าตัวอย่าง  คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันซีรีส์และหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองโดยสมบูรณ์  มี overload ที่สามารถสร้างกราฟโดยไม่มีข้อมูลเริ่มต้นได้ด้วย

**กราฟอธิบายความสัมพันธ์กับเซลล์ workbook อย่างไร?**

ชื่อซีรีส์, ฉลากหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/)  การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบกราฟที่สอดคล้องกัน  เมื่อคุณสร้างข้อมูลแบบกำหนดเอง ให้รักษาแถวหมวดหมู่และแถวค่าซีรีส์ให้สอดคล้องกันเพื่อให้แต่ละจุดถูกพลอตภายใต้หมวดหมู่ที่ตั้งใจไว้

**จะลบจุดเดียวโดยไม่ลบซีรีส์ทั้งหมดได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง  ใช้ [IChartDataPointCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) เฉพาะเมื่อคุณต้องการลบทุกจุดจากซีรีส์นั้น  หากคุณลบหมวดหมู่ด้วย, ให้ปรับซีรีส์ทุกตัวให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทกราฟและค่าที่กำหนดผ่าน [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)  กราฟที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมต่อจุดข้างเคียง  เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ  ดูที่ [Control the Display of Empty Cells](#control-the-display-of-empty-cells) เพื่อดูตัวอย่างเต็มและเปรียบเทียบภาพ

**ค่าติดลบถูกฟอร์แมตอย่างไร?**

สำหรับซีรีส์แถบ, คอลัมน์, และฟองอากาศที่สนับสนุน, ให้เรียก [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) แล้วตั้งค่าสีที่ได้จาก [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--)  คุณสามารถทับการทำงานสำหรับจุดเดียวด้วย [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-)  วิธีเหล่านี้ส่งผลต่อการฟอร์แมต, ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ

**เมื่อตั้งค่าทั้งซีรีส์และจุดพร้อมกัน ตัวฟอร์แมตใดชนะ?**

การฟอร์แมตจุดข้อมูลโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น  จุดอื่น ๆ จะใช้ฟอร์แมตซีรีส์ที่กำหนดไว้หรือหากไม่ได้กำหนดจะใช้สไตล์และธีมของกราฟโดยอัตโนมัติ  การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การฟอร์แมตระดับจุด

**กราฟสามารถมีซีรีส์ได้มากแค่ไหน?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนซีรีส์อย่างแยกจากกัน  อย่างไรก็ตาม ขนาดไฟล์งานนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของกราฟเป็นปัจจัยที่กำหนดขีดจำกัดที่ใช้ได้จริง

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) บนกลุ่มซีรีส์แม่ที่เหมาะสม  เพิ่มค่าเพื่อเพิ่มช่องว่างระหว่างกลุ่ม, หรือ ลดค่าเพื่อทำให้กลุ่มเข้าหากันมากขึ้น.