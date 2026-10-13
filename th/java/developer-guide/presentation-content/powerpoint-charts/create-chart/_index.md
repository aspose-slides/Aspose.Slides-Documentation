---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอสไลด์ PowerPoint ใน Java
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/java/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิต้นไม้
- แผนภูมิสต็อก
- แผนภูมิกล่องและคีบ
- แผนภูมิกรวย
- แผนภูมิดาว
- แผนภูมิฮิสโตแกรม
- แผนภูมิโรดาร์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Java เพิ่ม แก้ไขรูปแบบและปรับปรุงแผนภูมิกับตัวอย่างโค้ดที่ใช้ได้จริงใน Java."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างครอบคลุมเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for Java คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิเข้าสไลด์โดยโปรแกรม, เติมข้อมูลลงในแผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ตลอดบทความ ตัวอย่างโค้ดโดยละเอียดจะอธิบายแต่ละขั้นตอน ตั้งแต่การเริ่มต้นพรีเซนเทชันและวัตถุแผนภูมิจนถึงการกำหนดค่าซีรีส์, แกน, และคำอธิบาย โดยการทำตามคำแนะนำนี้ คุณจะได้รับความเข้าใจที่มั่นคงเกี่ยวกับวิธีการผสานการสร้างแผนภูมิกระ动态เข้าในแอปพลิเคชัน Java ของคุณ ทำให้กระบวนการสร้างงานนำเสนอที่ใช้ข้อมูลเป็นฐานเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้คนมองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อมูลเชิงลึกที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ใช้แผนภูมิคุณสามารถ:

* รวม, ยุบ, หรือสรุปข้อมูลจำนวนมากลงในสไลด์เดียวของการนำเสนอ;
* เผยรูปแบบและแนวโน้มของข้อมูล;
* สรุปทิศทางและความเคลื่อนที่ของข้อมูลตามเวลา หรือเทียบกับหน่วยการวัดเฉพาะ;
* ตรวจจับค่าที่เบี่ยงเบน, ความผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีความหมาย;
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน.

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งมีแม่แบบสำหรับออกแบบแผนภูมิมากมาย การใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (อิงจากประเภทแผนภูมิที่ได้รับความนิยม) และแผนภูมิแบบกำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ในแพ็กเกจ [com.aspose.slides](https://reference.aspose.com/slides/java/com.aspose.slides/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิที่แตกต่างกัน
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม**

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิคอลัมน์แบบจัดกลุ่มที่เปรียบเทียบสองซีรีส์ในสามหมวดหมู่ ซีรีส์ใช้สีเติมแดงและสีเขียว และป้ายกำกับแต่ละรายการแสดงชื่อหมวดหมู่, ชื่อซีรีส์, และค่า ดัชนี Worksheet 0 หมายถึงแผ่นแรกในเวิร์กบุ๊กแผนภูมิที่ฝังอยู่

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    series = chart.getChartData().getSeries().get_Item(1);

    valueCell = workbook.getCell(worksheetIndex, 1, 2, 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 2, 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 2, 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(new Color(0, 128, 0));

    IDataLabel label = series.getDataPoints().get_Item(0).getLabel();
    label.getDataLabelFormat().setShowCategoryName(true);

    label = series.getDataPoints().get_Item(1).getLabel();
    label.getDataLabelFormat().setShowSeriesName(true);

    label = series.getDataPoints().get_Item(2).getLabel();
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setShowSeriesName(true);
    label.getDataLabelFormat().setSeparator("/");

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิคอลัมน์แบบจัดกลุ่ม](clustered_column_chart.png)

### **สร้างแผนภูมิกระจาย**

แผนภูมิกระจาย (หรือที่เรียกว่ากราฟกระจายหรือกราฟ x-y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

ใช้แผนภูมิกระจายเมื่อ:

* คุณมีข้อมูลตัวเลขแบบคู่.
* คุณมีตัวแปรสองตัวที่จับคู่กันได้ดี.
* คุณต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่.
* คุณมีตัวแปรอิสระที่มีค่าหลายค่า สำหรับตัวแปรขึ้นอยู่.

ตัวอย่างนี้วางค่าชุด x‑y สองชุด ซีรีส์แรกใช้เส้นตรงพร้อมเครื่องหมายดาว, ส่วนซีรีส์ที่สองใช้เส้นโค้งพร้อมเครื่องหมายวงกลม; ทั้งสองใช้ขนาดเครื่องหมายเป็น 10, กำหนดด้วย [setSize](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSize-int-). วิธีการ [setSymbol](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSymbol-int-) ควบคุมรูปแบบเครื่องหมาย

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 1, 1, "Series 1");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());
    seriesNameCell = workbook.getCell(worksheetIndex, 1, 3, "Series 2");
    chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IChartDataCell xValueCell = workbook.getCell(worksheetIndex, 2, 1, 1);
    IChartDataCell yValueCell = workbook.getCell(worksheetIndex, 2, 2, 3);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 1, 2);
    yValueCell = workbook.getCell(worksheetIndex, 3, 2, 10);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Star);

    series = chart.getChartData().getSeries().get_Item(1);

    xValueCell = workbook.getCell(worksheetIndex, 2, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 2, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 3, 3, 3);
    yValueCell = workbook.getCell(worksheetIndex, 3, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 4, 3, 2);
    yValueCell = workbook.getCell(worksheetIndex, 4, 4, 2);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    xValueCell = workbook.getCell(worksheetIndex, 5, 3, 5);
    yValueCell = workbook.getCell(worksheetIndex, 5, 4, 1);
    series.getDataPoints().addDataPointForScatterSeries(xValueCell, yValueCell);

    series.getMarker().setSize(10);
    series.getMarker().setSymbol(MarkerStyleType.Circle);

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิกระจาย](scatter_chart.png)

### **สร้างแผนภูมิวงกลม**

แผนภูมิวงกลมเหมาะที่สุดสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล, โดยเฉพาะเมื่อข้อมูลมีป้ายหมวดหมู่พร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีหลายส่วนหรือหลายป้ายคุณอาจพิจารณาใช้แผนภูมิจรก็ได้

ตัวอย่างนี้สร้างแผนภูมิเวียนที่มีค่าไตรมาสสามค่า แต่ละส่วนมีการเติมสีและขอบแบบกำหนดเอง, และป้ายแสดงการรวมค่าต่าง ๆ, เปอร์เซ็นต์, และข้อมูลซีรีส์ วิธีการ [setFirstSliceAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setFirstSliceAngle-int-) ตั้งให้ส่วนแรกเริ่มที่ 180 องศา

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300);

    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "1st Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "2nd Qtr");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "3rd Qtr");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 20);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 2, 1, 50);
    series.getDataPoints().addDataPointForPieSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, 3, 1, 30);
    series.getDataPoints().addDataPointForPieSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(true);

    IChartDataPoint firstSlice = series.getDataPoints().get_Item(0);
    firstSlice.getFormat().getFill().setFillType(FillType.Solid);
    firstSlice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN);

    firstSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    firstSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    firstSlice.getFormat().getLine().setWidth(3.0);
    firstSlice.getFormat().getLine().setStyle(LineStyle.ThinThick);
    firstSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash);

    IChartDataPoint secondSlice = series.getDataPoints().get_Item(1);
    secondSlice.getFormat().getFill().setFillType(FillType.Solid);
    secondSlice.getFormat().getFill().getSolidFillColor().setColor(new Color(165, 42, 42));

    secondSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    secondSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    secondSlice.getFormat().getLine().setWidth(3.0);
    secondSlice.getFormat().getLine().setStyle(LineStyle.Single);
    secondSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot);

    IChartDataPoint thirdSlice = series.getDataPoints().get_Item(2);
    thirdSlice.getFormat().getFill().setFillType(FillType.Solid);
    thirdSlice.getFormat().getFill().getSolidFillColor().setColor(new Color(255, 127, 80));

    thirdSlice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    thirdSlice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    thirdSlice.getFormat().getLine().setWidth(2.0);
    thirdSlice.getFormat().getLine().setStyle(LineStyle.ThinThin);
    thirdSlice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot);

    IDataLabel firstLabel = series.getDataPoints().get_Item(0).getLabel();
    firstLabel.getDataLabelFormat().setShowValue(true);

    IDataLabel secondLabel = series.getDataPoints().get_Item(1).getLabel();
    secondLabel.getDataLabelFormat().setShowValue(true);
    secondLabel.getDataLabelFormat().setShowLegendKey(true);
    secondLabel.getDataLabelFormat().setShowPercentage(true);

    IDataLabel thirdLabel = series.getDataPoints().get_Item(2).getLabel();
    thirdLabel.getDataLabelFormat().setShowSeriesName(true);
    thirdLabel.getDataLabelFormat().setShowPercentage(true);

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(true);

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180);

    presentation.save("PieChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิเวียน](pie_chart.png)

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือที่เรียกว่ากราฟเส้น) เหมาะสำหรับแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป โดยใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล, และอื่น ๆ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิเส้นที่มีซีรีส์และหมวดหมู่เริ่มต้น, แล้วบันทึกเป็น PPTX

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart lineChart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300);

    presentation.save("lineChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

โดยค่าเริ่มต้นจุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมด้วยเส้นประ ให้เรียก [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) ด้วยค่าจาก [LineDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart lineChart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300);

    for (IChartSeries series : lineChart.getChartData().getSeries())
    {
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash);
    }
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิเส้น](line_chart.png)

### **สร้างแผนภูมิต้นไม้**

แผนภูมิต้นไม้เหมาะสำหรับข้อมูลยอดขายเมื่อคุณต้องการแสดงขนาดสัมพันธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้สนับสนุนหลักในแต่ละหมวดหมู่

ตัวอย่างนี้สร้างแผนภูมิต้นไม้ที่มีใบแปดใบจัดเป็นสี่กิ่งและสองสาขา วิธีการ [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) กำหนดกิ่งที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ค่าใช้กำหนดขนาดสี่เหลี่ยมสัมพัทธ์, ป้ายหมวดหมู่และป้ายผู้ปกครองซ้อนทับเพื่อระบุลำดับชั้น

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // สาขา 1
    IChartDataCell categoryCell = workbook.getCell(0, "C1", "Leaf1");
    IChartCategory leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // สาขา 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Treemap);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    IChartDataCell valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForTreemapSeries(valueCell);

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping);

    presentation.save("Treemap.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิต้นไม้](treemap_chart.png)

### **สร้างแผนภูมิขั้นร่วง**

แผนภูมิขั้นร่วงแสดงว่าการเปลี่ยนแปลงบวกและลบมีส่วนทำให้ค่าสุดท้ายเป็นเช่นไร ตัวอย่างเช่น การสรุปกำไรอาจเริ่มจากรายได้, ลบต้นทุน, แล้วบวกรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงลอยระหว่างค่าเก่าและค่าใหม่, ส่วนคอลัมน์รวมจะเริ่มจากศูนย์ไปจนถึงค่าที่สะสม

ตารางตัวอย่างใช้หน่วยพันดอลลาร์สหรัฐ:

| หมวดหมู่ | ค่าจากเวิร์กบุ๊ก | ประเภทคอลัมน์ |
| --- | ---: | --- |
| รายได้ | 1000 | เพิ่ม |
| ต้นทุนการขาย | -400 | ลด |
| กำไรขั้นต้น | 600 | รวมย่อย |
| ค่าใช้จ่ายในการดำเนินงาน | -200 | ลด |
| รายได้อื่น | 50 | เพิ่ม |
| กำไรสุทธิ | 450 | รวมสุดท้าย |

เพื่อทำเครื่องหมายจุดเป็นรวมย่อยหรือรวมสุดท้าย ให้เรียกวิธี [setSetAsTotal](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatapoint/#setSetAsTotal-boolean-) ของจุดนั้นด้วย `true`. ใส่จำนวนที่สะสมจริงในเซลล์เวิร์กบุ๊กของจุดนั้น: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`). วิธีนี้ทำเครื่องหมายคอลัมน์ว่าเป็นรวม; ไม่ได้คำนวณหรือเติมค่าลงในเซลล์ อย่าใช้ศูนย์เป็นตัวแทนหรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดรวม คอลัมน์รวมจะแสดงค่าที่สะสมโดยไม่เพิ่มอีกครั้งกับค่าที่รันอยู่

ตัวอย่าง Java เต็มรูปแบบนี้สร้างแผนภูมิด้วยสมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/), ลบข้อมูลเริ่มต้น, แล้วเติมเวิร์กบุ๊กฝังอยู่ ดัชนี Worksheet `0` เลือกแผ่นแรก; คอลัมน์ A มีชื่อหมวดหมู่และคอลัมน์ B มีค่า แต่ละเซลล์ค่าถูกเพิ่มด้วย [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#addDataPointForWaterfallSeries-com.aspose.slides.IChartDataCell-). ดัชนีจุดศูนย์ฐาน `2` และ `5` ระบุรวมย่อยและรวมสุดท้าย การเรียก [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ด้วย `true` แสดงจำนวนบนคอลัมน์ ไม่ต้องมีพรีเซนเทชันหรือเวิร์กบุ๊กอินพุต

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)");
    chart.getChartTitle().setOverlay(false);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    workbook.clear(worksheetIndex);

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Profit");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Waterfall);
    String[] categories = new String[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
    double[] values = new double[] { 1000, -400, 600, -200, 50, 450 };

    for (int i = 0; i < categories.length; i++)
    {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categories[i]);
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForWaterfallSeries(valueCell);
    }

    // จุดที่สามและหกเป็นการสรุปผลรวม, ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
    series.getDataPoints().get_Item(2).setSetAsTotal(true);
    series.getDataPoints().get_Item(5).setSetAsTotal(true);
    series.setShowConnectorLines(true);
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

เรียกวิธีระดับซีรีส์ [setShowConnectorLines](https://reference.aspose.com/slides/java/com.aspose.slides/chartseries/#setShowConnectorLines-boolean-) ด้วย `true` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่องและทำให้ค่าเดินต่อได้ง่ายขึ้น หากต้องการซ่อนเส้นเหล่านี้ ให้แทนที่การเรียกเมธอดในตัวอย่างด้วย `series.setShowConnectorLines(false);` ก่อนบันทึก วิธีนี้เปลี่ยนเพียงการมองเห็นเส้น, ไม่กระทบต่อข้อมูลหรือรวม

พรีเซนเทชันที่บันทึกแสดงกำไรขั้นต้น 600 และกำไรสุทธิ 450, ทั้งสองรวมเริ่มจากศูนย์:

![แผนภูมิขั้นร่วงแสดงรายได้, ต้นทุน, กำไรขั้นต้น 600, และกำไรสุทธิ 450 พร้อมป้ายค่าและเส้นเชื่อม](waterfall_chart.png)

### **สร้างแผนภูมิหุ้น**

แผนภูมิหุ้นใช้แสดงข้อมูลการเงินเช่น ราคาเปิด, สูง, ต่ำ, และปิด, ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลเชิงลึกสำคัญเกี่ยวกับการดำเนินงานของหุ้น, ช่วยนักลงทุนและนักวิเคราะห์ตัดสินใจอย่างมีข้อมูล

ตัวอย่างนี้สร้างแผนภูมิ open‑high‑low‑close ที่มีสี่ซีรีส์ตามลำดับและสามหมวดหมู่ วิธีการ [setUpDownBars](https://reference.aspose.com/slides/java/com.aspose.slides/iupdownbarsmanager/#setUpDownBars-boolean-) เปิดใช้งานแถบขึ้น/ลง, และ [getHiLowLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getHiLowLinesFormat--) ควบคุมเส้นสูง‑ต่ำที่แสดงช่วงราคา, ขณะเดียวกันเส้นซีรีส์แยกและเส้นกริดแนวนอนเล็กถูกซ่อนไว้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "A");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 2, 0, "B");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, 3, 0, "C");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Open");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 2, "High");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 3, "Low");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);
    seriesNameCell = workbook.getCell(0, 0, 4, "Close");
    chart.getChartData().getSeries().add(seriesNameCell, ChartType.OpenHighLowClose);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataCell valueCell = workbook.getCell(0, 1, 1, 72);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 1, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 1, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(1);
    valueCell = workbook.getCell(0, 1, 2, 172);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 57);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(2);
    valueCell = workbook.getCell(0, 1, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 3, 12);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 3, 13);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    series = chart.getChartData().getSeries().get_Item(3);
    valueCell = workbook.getCell(0, 1, 4, 25);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 4, 38);
    series.getDataPoints().addDataPointForStockSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 4, 50);
    series.getDataPoints().addDataPointForStockSeries(valueCell);

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(true);
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);

    for (IChartSeries stockSeries : chart.getChartData().getSeries())
    {
        stockSeries.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
    }

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิหุ้น](stock_chart.png)

### **สร้างแผนภูมิกล่องและคีบ**

แผนภูมิกล่องและคีบใช้แสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติสำคัญ เช่น มัธยฐาน, ควอตไทล์, และค่าผิดปกติ เหมาะกับการวิเคราะห์สำรวจข้อมูลและการศึกษาเชิงสถิติ เพื่อเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติได้อย่างรวดเร็ว

ตัวอย่างนี้สร้างแผนภูมิกล่องและคีบจากห้าค่า วิธีการ [setQuartileMethod](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setQuartileMethod-int-) เลือกการคำนวณควอตไทล์แบบ exclusive ตัวอย่างยังเปิดใช้เส้นค่าเฉลี่ย, ตัวทำเครื่องหมายค่าเฉลี่ย, จุดภายใน, และจุดผิดปกติ

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker);

    series.setQuartileMethod(QuartileMethodType.Exclusive);
    series.setShowMeanLine(true);
    series.setShowMeanMarkers(true);
    series.setShowInnerPoints(true);
    series.setShowOutlierPoints(true);

    IChartDataCell valueCell = workbook.getCell(0, "B1", 15);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 41);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 10);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 23);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 16);
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(valueCell);

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

### **สร้างแผนภูมิกรวย**

แผนภูมิกรวยใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง, โดยปริมาณข้อมูลจะลดลงเมื่อผ่านขั้นตอนต่อไป เป็นประโยชน์สำหรับการวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพิ่มแผนภูมิกรวยในสไลด์แรกของพรีเซนเทชันที่มีอยู่ แทนข้อมูลเริ่มต้นด้วยห้าหมวดหมู่และค่าตั้งแต่ 50 ถึง 500, แล้วบันทึกพรีเซนเทชันที่อัปเดต พรีเซนเทชันอินพุตต้องมีอย่างน้อยหนึ่งสไลด์

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A1", "Category 1");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A2", "Category 2");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A3", "Category 3");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A4", "Category 4");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A5", "Category 5");
    chart.getChartData().getCategories().add(categoryCell);
    categoryCell = workbook.getCell(0, "A6", "Category 6");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Funnel);

    IChartDataCell valueCell = workbook.getCell(0, "B1", 50);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B2", 100);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B3", 200);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B4", 300);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B5", 400);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);
    valueCell = workbook.getCell(0, "B6", 500);
    series.getDataPoints().addDataPointForFunnelSeries(valueCell);

    presentation.save("Funnel.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิกรวย](funnel_chart.png)

### **สร้างแผนภูมิดาว**

แผนภูมิดาวใช้เพื่อแสดงข้อมูลเชิงลำดับชั้น, แสดงระดับเป็นวงรอบศูนย์ ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะสำหรับแสดงหมวดหมู่และหมวดย่อยที่ซ้อนกันในรูปแบบกระชับและชัดเจน

ตัวอย่างนี้สร้างแผนภูมิดาวที่มีใบแปดใบจัดเป็นสี่กิ่งและสองสาขา วิธีการ [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) กำหนดกิ่งที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ป้ายหมวดหมู่ระบุส่วนต่าง ๆ, ค่ากำหนดขนาดสัมพัทธ์ของแต่ละส่วน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    // สาขา 1
    IChartDataCell categoryCell = workbook.getCell(0, "C1", "Leaf1");
    IChartCategory leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1");

    categoryCell = workbook.getCell(0, "C2", "Leaf2");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C3", "Leaf3");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2");

    categoryCell = workbook.getCell(0, "C4", "Leaf4");
    chart.getChartData().getCategories().add(categoryCell);

    // สาขา 2
    categoryCell = workbook.getCell(0, "C5", "Leaf5");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3");
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2");

    categoryCell = workbook.getCell(0, "C6", "Leaf6");
    chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "C7", "Leaf7");
    leaf = chart.getChartData().getCategories().add(categoryCell);
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4");

    categoryCell = workbook.getCell(0, "C8", "Leaf8");
    chart.getChartData().getCategories().add(categoryCell);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Sunburst);
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(true);
    IChartDataCell valueCell = workbook.getCell(0, "D1", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D2", 5);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D3", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D4", 6);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D5", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D6", 9);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D7", 4);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);
    valueCell = workbook.getCell(0, "D8", 3);
    series.getDataPoints().addDataPointForSunburstSeries(valueCell);

    presentation.save("Sunburst.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิดาว](sunburst_chart.png)

### **สร้างแผนภูมิฮิสโตแกรม**

แผนภูมิฮิสโตแกรมใช้เพื่อแสดงการกระจายของข้อมูลตัวเลขโดยจัดค่าลงในช่วงหรือบักซ์ เหมาะสำหรับการระบุรูปแบบเช่น ความถี่, ความเอียง, การกระจาย, และการตรวจพบค่าผิดปกติในชุดข้อมูล

ตัวอย่างนี้สร้างฮิสโตแกรมจากห้าค่าตัวเลขรวมถึงค่าติดลบ การเรียก [setAggregationType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAggregationType-int-) ด้วยประเภทการรวมอัตโนมัติทำให้แผนภูมิตัดสินใจบักซ์ที่ใช้เพื่อแสดงการกระจาย

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 500, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    IChartDataCell valueCell = workbook.getCell(0, "A1", 15);
    series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    valueCell = workbook.getCell(0, "A2", -41);
    series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    valueCell = workbook.getCell(0, "A3", 16);
    series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    valueCell = workbook.getCell(0, "A4", 10);
    series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    valueCell = workbook.getCell(0, "A5", -23);
    series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    valueCell = workbook.getCell(0, "A6", 16);
    series.getDataPoints().addDataPointForHistogramSeries(valueCell);

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic);

    presentation.save("Histogram.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิฮิสโตแกรม](histogram_chart.png)

### **สร้างแผนภูมิเ�Radar**

แผนภูมิเ� Radar ใช้เพื่อแสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ, ทำให้สามารถเปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย เหมาะสำหรับการระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิเรดาร์ที่มีซีรีส์และหมวดหมู่เริ่มต้น, แล้วบันทึกเป็น PPTX

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300);

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิเ� Radar](radar_chart.png)

### **สร้างแผนภูมิหลายหมวดหมู่**

แผนภูมิหลายหมวดหมู่ใช้เพื่อแสดงข้อมูลที่มีการจัดกลุ่มหมวดหมู่มากกว่าหนึ่ง, ช่วยให้เปรียบเทียบค่าข้ามมิติหลายมิติพร้อมกัน เหมาะเมื่อจำเป็นต้องวิเคราะห์แนวโน้มและความสัมพันธ์ภายในชุดข้อมูลหลายชั้นที่ซับซ้อน

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบจัดกลุ่มที่มีแปะหมวดหมู่อแปดหมวดจัดเป็นสี่คู่ วิธีการ [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) ให้แต่ละคู่มีป้ายร่วมที่ระดับการจัดกลุ่ม 1, ทำให้แกนหมวดหมู่มีทั้งป้ายบุคคลและกลุ่ม

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    int worksheetIndex = 0;

    IChartDataCell categoryCell = workbook.getCell(0, "c2", "A");
    IChartCategory category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group1");
    categoryCell = workbook.getCell(0, "c3", "B");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c4", "C");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group2");
    categoryCell = workbook.getCell(0, "c5", "D");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c6", "E");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group3");
    categoryCell = workbook.getCell(0, "c7", "F");
    category = chart.getChartData().getCategories().add(categoryCell);

    categoryCell = workbook.getCell(0, "c8", "G");
    category = chart.getChartData().getCategories().add(categoryCell);
    category.getGroupingLevels().setGroupingItem(1, "Group4");
    categoryCell = workbook.getCell(0, "c9", "H");
    category = chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell seriesNameCell = workbook.getCell(0, "D1", "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

    IChartDataCell valueCell = workbook.getCell(worksheetIndex, "D2", 10);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D3", 20);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D4", 30);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D5", 40);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D6", 50);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D7", 60);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D8", 70);
    series.getDataPoints().addDataPointForBarSeries(valueCell);
    valueCell = workbook.getCell(worksheetIndex, "D9", 80);
    series.getDataPoints().addDataPointForBarSeries(valueCell);

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิหลายหมวดหมู่](multi_category_chart.png)

### **สร้างแผนภูมิแผนที่**

แผนภูมิการ์ตใช้เพื่อแสดงข้อมูลภูมิศาสตร์โดยแมปข้อมูลกับสถานที่เฉพาะเช่น ประเทศ, รัฐ, หรือเมือง เหมาะสำหรับการวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิแผนที่ที่มีข้อมูลภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300);

    presentation.save("mapChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ผลลัพธ์:

![แผนภูมิแผนที่](map_chart.png)

{{% alert color="info" title="Note" %}}
รูปภาพด้านบนแสดงพรีเซนเทชันที่บันทึกแล้วเปิดใน PowerPoint. Aspose.Slides เขียนแผนภูมิแผนที่และข้อมูลได้อย่างถูกต้อง, แต่ไม่วาดแผนภูมิแผนที่เอง: เมื่อสไลด์ที่มีแผนภูมินี้ถูกแปลงเป็นรูปภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะแสดงเป็นสีขาว. รูปทรงอื่น ๆ บนสไลด์เดียวกันไม่ได้รับผลกระทบ.
{{% /alert %}}

### **สร้างแผนภูมิผสม**

แผนภูมิผสม (หรือ combo chart) รวมประเภทแผนภูมิสองประเภทหรือมากกว่าภายในกราฟเดียว ทำให้คุณสามารถเน้น, เปรียบเทียบ, หรือตรวจสอบความแตกต่างระหว่างชุดข้อมูลหลายชุด, ช่วยให้ระบุความสัมพันธ์ระหว่างข้อมูลได้ง่ายขึ้น

![แผนภูมิผสม](combination_chart.png)

ตัวอย่างนี้รวมสองซีรีส์คอลัมน์แบบจัดกลุ่มกับซีรีส์เส้นหนึ่งซีรีส์ในสี่หมวดหมู่ คอลัมน์ใช้แกนแนวตั้งหลัก, ในขณะที่ [setPlotOnSecondAxis](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setPlotOnSecondAxis-boolean-) วางเส้นบนแกนแนวตั้งรองทางขวา ฟังก์ชันช่วยกำหนดหัวเรื่อง, คำอธิบาย, ป้ายแกน, และเส้นกริด

```java
import com.aspose.slides.*;
import java.awt.Color;

class ComboChartExample
{
    void createComboChart()
    {
        Presentation presentation = new Presentation();
        try
        {
            IChart chart = createChartWithFirstSeries(presentation.getSlides().get_Item(0));

            addSecondSeriesToChart(chart);
            addThirdSeriesToChart(chart);

            setPrimaryAxesFormat(chart);
            setSecondaryAxesFormat(chart);

            presentation.save("combo-chart.pptx", SaveFormat.Pptx);
        }
        finally
        {
            presentation.dispose();
        }
    }

    IChart createChartWithFirstSeries(ISlide slide)
    {
        IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

        chart.setTitle(true);
        chart.getChartTitle().addTextFrameForOverriding("Chart Title");
        chart.getChartTitle().setOverlay(false);
        IPortionFormat portionFormat = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
        portionFormat.setFontBold(NullableBool.False);
        portionFormat.setFontHeight(18f);

        chart.getLegend().setPosition(LegendPositionType.Bottom);
        chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12f);

        chart.getChartData().getSeries().clear();
        chart.getChartData().getCategories().clear();

        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        int worksheetIndex = 0;

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, 1, 0, "Category 1");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 2, 0, "Category 2");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 3, 0, "Category 3");
        chart.getChartData().getCategories().add(categoryCell);
        categoryCell = workbook.getCell(worksheetIndex, 4, 0, "Category 4");
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

        series.getParentSeriesGroup().setOverlap((byte) -25);
        series.getParentSeriesGroup().setGapWidth(220);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 1, 4.3);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 1, 2.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 1, 3.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 1, 4.5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);

        return chart;
    }

    void addSecondSeriesToChart(IChart chart)
    {
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        final int worksheetIndex = 0;

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 2, "Series 2");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.ClusteredColumn);

        series.getParentSeriesGroup().setOverlap((byte) -25);
        series.getParentSeriesGroup().setGapWidth(220);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 2, 2.4);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 2, 4.4);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 2, 1.8);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 2, 2.8);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    void addThirdSeriesToChart(IChart chart)
    {
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        final int worksheetIndex = 0;

        IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
        IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, ChartType.Line);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 3, 2.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 2, 3, 2.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 3, 3, 3.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
        valueCell = workbook.getCell(worksheetIndex, 4, 3, 5.0);
        series.getDataPoints().addDataPointForLineSeries(valueCell);

        series.setPlotOnSecondAxis(true);
    }

    void setPrimaryAxesFormat(IChart chart)
    {
        IAxis horizontalAxis = chart.getAxes().getHorizontalAxis();
        horizontalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        horizontalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(horizontalAxis, "X Axis");

        IAxis verticalAxis = chart.getAxes().getVerticalAxis();
        verticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        verticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(verticalAxis, "Y Axis 1");

        ILineFillFormat majorGridLinesFormat = verticalAxis.getMajorGridLinesFormat().getLine().getFillFormat();
        majorGridLinesFormat.setFillType(FillType.Solid);
        majorGridLinesFormat.getSolidFillColor().setColor(new Color(217, 217, 217));
    }

    void setSecondaryAxesFormat(IChart chart)
    {
        IAxis secondaryHorizontalAxis = chart.getAxes().getSecondaryHorizontalAxis();
        secondaryHorizontalAxis.setPosition(AxisPositionType.Bottom);
        secondaryHorizontalAxis.setCrossType(CrossesType.Maximum);
        secondaryHorizontalAxis.setVisible(false);
        secondaryHorizontalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryHorizontalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        IAxis secondaryVerticalAxis = chart.getAxes().getSecondaryVerticalAxis();
        secondaryVerticalAxis.setPosition(AxisPositionType.Right);
        secondaryVerticalAxis.getTextFormat().getPortionFormat().setFontHeight(12f);
        secondaryVerticalAxis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill);

        setAxisTitle(secondaryVerticalAxis, "Y Axis 2");
    }

    void setAxisTitle(IAxis axis, String axisTitle)
    {
        axis.setTitle(true);
        axis.getTitle().setOverlay(false);
        IPortionFormat titlePortionFormat = axis.getTitle().addTextFrameForOverriding(axisTitle).getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
        titlePortionFormat.setFontBold(NullableBool.False);
        titlePortionFormat.setFontHeight(12f);
    }
}

ComboChartExample example = new ComboChartExample();
example.createComboChart();
```

## **อัปเดตแผนภูมิ**

Aspose.Slides for Java ให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และการออกแบบ สิ่งนี้ทำให้การทำให้พรีเซนเทชันทันสมัยด้วยเนื้อหาแบบไดนามิกเป็นเรื่องง่ายและทำให้แผนภูมิสะท้อนข้อมูลและมาตรฐานภาพล่าสุดได้อย่างแม่นยำ

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ “My chart” บนสไลด์แรกของพรีเซนเทชันที่มีอยู่ ต้องมีสองซีรีส์คอลัมน์ที่มีจุดข้อมูลสามจุดแต่ละจุด, ป้ายหมวดหมู่ในคอลัมน์ A และชื่อซีรีส์ในแถวแรกของแผ่นงานแรก ตัวอย่างใช้ [getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-java.lang.Object-) เพื่อเปลี่ยนค่าเซลล์เวิร์กบุ๊ก, อัปเดตค่าซีรีส์, เพิ่มซีรีส์ที่สาม, และเปลี่ยนแผนภูมิเป็นรูปทรงกระบอกจัดกลุ่มโดยใช้ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setType-int-)

```java
import com.aspose.slides.*;

final String chartName = "My chart";

Presentation presentation = new Presentation("ExistingChart.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes())
    {
        if (shape instanceof IChart && chartName.equals(shape.getName()))
        {
            IChart chart = (IChart) shape;
            int worksheetIndex = 0;

            IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

            workbook.getCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.getCell(worksheetIndex, 2, 0, "Modified Category 2");

            IChartSeries series = chart.getChartData().getSeries().get_Item(0);

            workbook.getCell(worksheetIndex, 0, 1, "New_Series 1");
            series.getDataPoints().get_Item(0).getValue().setData(90);
            series.getDataPoints().get_Item(1).getValue().setData(123);
            series.getDataPoints().get_Item(2).getValue().setData(44);

            series = chart.getChartData().getSeries().get_Item(1);

            workbook.getCell(worksheetIndex, 0, 2, "New_Series 2");
            series.getDataPoints().get_Item(0).getValue().setData(23);
            series.getDataPoints().get_Item(1).getValue().setData(67);
            series.getDataPoints().get_Item(2).getValue().setData(99);

            IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 3, "Series 3");
            series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

            IChartDataCell valueCell = workbook.getCell(worksheetIndex, 1, 3, 20);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 2, 3, 50);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
            valueCell = workbook.getCell(worksheetIndex, 3, 3, 30);
            series.getDataPoints().addDataPointForBarSeries(valueCell);

            chart.setType(ChartType.ClusteredCylinder);
        }
    }

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงที่แผนภูมิที่มีอยู่ใช้แล้ว, ดูที่ [Retrieve a Chart's Data Range](/slides/th/java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides for Java ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจาก Worksheet เป็นแหล่งข้อมูลสำหรับแผนภูมิของคุณ หมายความว่าคุณสามารถแมปส่วนของ Worksheet ไปยังแผนภูมิได้โดยตรง, ควบคุมว่าเซลล์ใดมีส่วนร่วมในซีรีส์และหมวดหมู่ของแผนภูมิ ผลคือคุณสามารถอัปเดตและซิงโครไนซ์แผนภูมิของคุณกับการเปลี่ยนแปลงข้อมูลล่าสุดใน Worksheet ได้ง่าย, ทำให้พรีเซนเทชัน PowerPoint ของคุณสะท้อนข้อมูลที่เป็นปัจจุบันและแม่นยำ

ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อตั้งแหล่งข้อมูลของแผนภูมิชื่อ “My chart” บนสไลด์แรกของพรีเซนเทชันที่มีอยู่เป็น `Sheet1!A1:B4`. เวิร์กบุ๊กแผนภูมิต้องมี Worksheet นั้นและช่วงที่มีหัวเรื่องซีรีส์ในแถวแรก, ป้ายหมวดหมู่ในคอลัมน์ A, และสามค่ในคอลัมน์ B

```java
import com.aspose.slides.*;

final String chartName = "My chart";

Presentation presentation = new Presentation("ExistingChart.pptx");
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes())
    {
        if (shape instanceof IChart && chartName.equals(shape.getName()))
        {
            IChart chart = (IChart) shape;
            chart.getChartData().setRange("Sheet1!A1:B4");
        }
    }

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **ใช้ตัวทำเครื่องหมายเริ่มต้นในแผนภูมิ**

เมื่อคุณใช้ตัวทำเครื่องหมายเริ่มต้นในแผนภูมิ, แต่ละซีรีส์ของแผนภูมิจะได้รับสัญลักษณ์เครื่องหมายเริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิที่มีสองซีรีส์เส้นและคำอธิบาย การตั้งค่าตัวทำเครื่องหมายที่เข้าถึงผ่าน [getMarker](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getMarker--) รักษาสัญลักษณ์เครื่องหมายที่กำหนดโดยอัตโนมัติ ซีรีส์แรกมีค่าลบและค่าที่หายไป (`null`), ส่วนซีรีส์ที่สองมีค่าในทุกหมวดหมู่

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    IChartDataCell categoryCell = workbook.getCell(0, 1, 0, "C1");
    chart.getChartData().getCategories().add(categoryCell);
    IChartDataCell valueCell = workbook.getCell(0, 1, 1, 24);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 2, 0, "C2");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 2, 1, 23);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 3, 0, "C3");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 3, 1, -10);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    categoryCell = workbook.getCell(0, 4, 0, "C4");
    chart.getChartData().getCategories().add(categoryCell);
    valueCell = workbook.getCell(0, 4, 1, null);
    series.getDataPoints().addDataPointForLineSeries(valueCell);

    seriesNameCell = workbook.getCell(0, 0, 2, "Series 2");
    IChartSeries secondSeries = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    valueCell = workbook.getCell(0, 1, 2, 30);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 2, 2, 10);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 3, 2, 60);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);
    valueCell = workbook.getCell(0, 4, 2, 40);
    secondSeries.getDataPoints().addDataPointForLineSeries(valueCell);

    chart.setLegend(true);
    chart.getLegend().setOverlay(false);

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**Aspose.Slides for Java รองรับประเภทแผนภูมิอะไรบ้าง?**

Aspose.Slides for Java รองรับประเภทแผนภูมิมากมาย รวมถึงแผนภูมิบาร์, เส้น, วงกลม, พื้นที่, กระจาย, ฮิสโตแกรม, เรดาร์, และอื่น ๆ อีกมาก การสนับสนุนนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงข้อมูลของคุณได้ง่าย

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ, คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) ก่อน, ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิ, ระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะฝังแผนภูมิเข้าสู่พรีเซนเทชันของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงเวิร์กบุ๊กข้อมูลของแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)), ลบซีรีส์และหมวดหมู่เริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ทำให้คุณรีเฟรชแผนภูมิเพื่อแสดงข้อมูลล่าสุดได้อย่างโปรแกรมเมติก

**สามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**

ใช่, Aspose.Slides for Java มีตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้าย, คำอธิบาย, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงกับความต้องการออกแบบของคุณได้อย่างเต็มที่