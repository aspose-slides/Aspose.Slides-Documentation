---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ด้วย Java
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
- แผนภูมิเส้นหุ้น
- แผนภูมิกล่องและหนวด
- แผนภูมุกระบอก
- แผนภูมิดวงอาทิตย์
- แผนภูมิฮิสโตแกรม
- แผนภูมิโรบิน
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Java เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานได้จริงใน Java."
---
## **ภาพรวม**

บทความนี้เป็นคู่มือครบถ้วนเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for Java คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิกับสไลด์แบบโปรแกรม, เติมข้อมูลให้แผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ ตัวอย่างโค้ดที่ละเอียดในบทความจะแสดงขั้นตอนต่าง ๆ ตั้งแต่การเริ่มต้น Presentation และวัตถุแผนภูมิ ไปจนถึงการกำหนด Series, Axis, และ Legend โดยทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีรวมการสร้างแผนภูมิแบบไดนามิกเข้าสู่แอปพลิเคชัน Java ของคุณ ช่วยให้การสร้างงานนำเสนอที่อิงข้อมูลเป็นเรื่องง่ายยิ่งขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อสรุปที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ด้วยแผนภูมิคุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากลงในสไลด์เดียวของงานนำเสนอ;
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล;
* พิจารณาทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดที่กำหนด;
* พบค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีความหมาย;
* นำเสนอหรืออธิบายข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งมีแม่แบบสำหรับการออกแบบหลายประเภทของแผนภูมิ ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิทั่วไป (อิงประเภทแผนภูมิที่เป็นที่นิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ในแพคเกจ [com.aspose.slides](https://reference.aspose.com/slides/java/com.aspose.slides/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิที่แตกต่างกัน
{{% /alert %}}

### **สร้าง Clustered Column Charts**

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้าง clustered column chart ที่เปรียบเทียบสอง series ระหว่างสามหมวดหมู่ Series ใช้สีเติมสีแดงและสีเขียว และป้ายกำกับแต่ละรายการแสดงชื่อหมวด, ชื่อ series, และค่า Worksheet index 0 หมายถึงชีตแรกใน workbook ของแผนภูมิที่ฝังอยู่

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

![The Clustered Column chart](clustered_column_chart.png)

### **สร้าง Scatter Charts**

Scatter chart (หรือ scatter plot, x‑y graph) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

ใช้ scatter chart เมื่อ:

* คุณมีข้อมูลเชิงตัวเลขเป็นคู่
* ตัวแปรสองตัวทำงานร่วมกันได้ดี
* คุณต้องการตรวจสอบว่าตัวแปรทั้งสองมีความสัมพันธ์หรือไม่
* คุณมีตัวแปรอิสระที่มีค่าหลายค่าเพื่ออธิบายตัวแปรตาม

ตัวอย่างนี้พล็อตค่า x‑y สองชุด Series แรกใช้เส้นตรงกับเครื่องหมายดาว, ส่วนที่สองใช้เส้นโค้งกับเครื่องหมายวงกลม; ทั้งสองใช้ขนาดเครื่องหมาย 10 โดยกำหนดผ่าน [setSize](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSize-int-). วิธี [setSymbol](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSymbol-int-) ควบคุมรูปร่างของเครื่องหมาย

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

![The Scatter chart](scatter_chart.png)

### **สร้าง Pie Charts**

Pie chart เหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายหมวดพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีหลายส่วนหรือหลายป้าย คุณอาจพิจารณาใช้ bar chart แทน

ตัวอย่างนี้สร้าง pie chart ที่มีค่าครึ่งไตรมาสสามค่า แต่ละส่วนมีการเติมสีและเส้นขอบที่กำหนดเอง, ป้ายแสดงค่าต่าง ๆ, เปอร์เซ็นต์ และข้อมูล series. วิธี [setFirstSliceAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setFirstSliceAngle-int-) กำหนดให้ส่วนแรกเริ่มที่ 180 องศา

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
    thirdSlice.getFormat().setFillType(FillType.Solid);
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

![The Pie chart](pie_chart.png)

เพื่อปรับปรุงความอ่านง่ายของป้ายที่อยู่นอก pie ดูตัวอย่าง [Format Leader Lines](/slides/th/java/chart-data-label/#format-leader-lines) ที่อธิบายวิธีจัดตำแหน่งป้ายและตั้งค่าสี, ความกว้าง, ความโปร่งแสง, และสไตล์ของเส้น

### **สร้าง Line Charts**

Line chart (หรือ line graph) เหมาะสำหรับแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ด้วย line chart คุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นข้อแปรปรวนใน series, และอื่น ๆ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) สร้าง line chart ด้วย series และ category เริ่มต้น, จากนั้นบันทึกเป็น PPTX

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

ค่าเริ่มต้น, จุดบน line chart จะถูกเชื่อมด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมด้วยเส้นประ ให้เรียก [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) พร้อมค่าจาก [LineDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/)

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

![The Line chart](line_chart.png)

### **สร้าง Tree Map Charts**

Tree map chart เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพันธ์ของหมวดข้อมูลและดึงความสนใจไปยังรายการที่เป็นส่วนสำคัญในแต่ละหมวด

ตัวอย่างนี้สร้าง tree map ที่มีใบแปดใบจัดเป็นสเตมสี่ใบและสาขาสองสาขา วิธี [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) กำหนดสเตมที่ระดับกลุ่ม 1 และสาขาที่ระดับ 2 ค่าแต่ละค่าใช้กำหนดขนาดสี่เหลี่ยมสัมพันธ์, ป้ายหมวดและป้ายพาเรนท์ที่ซ้อนกันบ่งบอกลำดับชั้น

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

![The Treemap chart](treemap_chart.png)

### **สร้าง Waterfall Charts**

Waterfall chart แสดงว่าการเปลี่ยนแปลงบวกและลบส่งผลต่อค่าตัวสุดท้ายอย่างไร เช่น การสรุปกำไรอาจเริ่มจากรายได้, ลดด้วยต้นทุน, แล้วเพิ่มด้วยรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงจะลอยระหว่างค่าที่คำนวณไว้ก่อนหน้าและค่าที่ใหม่, ส่วนคอลัมน์รวมจะเริ่มจากศูนย์ถึงค่าที่สะสม

ตัวอย่างต่อไปใช้จำนวนเป็นพันดอลลาร์สหรัฐ:

| หมวด | ค่าใน Workbook | ประเภทคอลัมน์ |
| --- | ---: | --- |
| รายได้ | 1000 | เพิ่ม |
| ต้นทุนการขาย | -400 | ลด |
| กำไรขั้นต้น | 600 | รวมย่อย |
| ค่าใช้จ่ายดำเนินการ | -200 | ลด |
| รายได้อื่น | 50 | เพิ่ม |
| กำไรสุทธิ | 450 | รวมสุดท้าย |

เพื่อทำเครื่องหมายจุดเป็นรวมย่อยหรือรวมสุดท้าย ให้เรียกวิธี [setSetAsTotal](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatapoint/#setSetAsTotal-boolean-) ของจุดนั้นด้วย `true` พร้อมระบุจำนวนที่สะสมจริงในเซลล์ของ workbook: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`). วิธีนี้เพียงทำเครื่องหมายคอลัมน์ว่าเป็นรวม, ไม่ได้คำนวณหรือเติมค่าในเซลล์ ไม่ควรใช้ศูนย์เป็นตัวแทนหรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดรวม คอลัมน์รวมจะแสดงค่าที่สะสมโดยไม่เพิ่มอีกครั้งต่อค่าที่กำลังดำเนินอยู่

ตัวอย่าง Java สมบูรณ์ต่อไปนี้สร้างแผนภูมิโดยใช้สมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/), ลบข้อมูลเริ่มต้น, แล้วเติม workbook ที่ฝังอยู่ Worksheet index `0` เลือกชีตแรก; คอลัมน์ A มีชื่อหมวด, คอลัมน์ B มีค่า. เพิ่มแต่ละค่าโดยใช้ [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#addDataPointForWaterfallSeries-com.aspose.slides.IChartDataCell-). ดัชนีจุดฐานศูนย์ `2` และ `5` ระบุรวมย่อยและรวมสุดท้าย. เรียก [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ด้วย `true` เพื่อแสดงจำนวนบนคอลัมน์. ไม่ต้องใช้ presentation หรือ workbook เป็นอินพุต

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

    // จุดที่สามและหกเป็นค่ารวม ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
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

เรียกวิธีระดับ series [setShowConnectorLines](https://reference.aspose.com/slides/java/com.aspose.slides/chartseries/#setShowConnectorLines-boolean-) ด้วย `true` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่องและทำให้ค่าที่ดำเนินอยู่ตามง่ายขึ้น. หากต้องการซ่อนเส้นเหล่านี้ ให้เปลี่ยนการเรียกเมธอดในตัวอย่างเป็น `series.setShowConnectorLines(false);` ก่อนบันทึก วิธีนี้เปลี่ยนแค่การมองเห็นเส้น ไม่กระทบข้อมูลหรือค่ารวม

Presentation ที่บันทึกแสดงกำไรขั้นต้น 600 และกำไรสุทธิ 450, ทั้งสองรวมจากศูนย์:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **สร้าง Stock Charts**

Stock chart ใช้แสดงข้อมูลการเงินเช่น ราคาเปิด, สูงสุด, ต่ำสุด, และปิด, ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลเชิงลึกที่สำคัญต่อประสิทธิภาพของหุ้นสำหรับนักลงทุนและนักวิเคราะห์

ตัวอย่างนี้สร้าง chart ประเภท open‑high‑low‑close ด้วยสี่ series ตามลำดับและสามหมวด. วิธี [setUpDownBars](https://reference.aspose.com/slides/java/com.aspose.slides/iupdownbarsmanager/#setUpDownBars-boolean-) เปิดใช้งานแถบขึ้น/ลง, และ [getHiLowLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getHiLowLinesFormat--) ควบคุมเส้น high‑low ที่แสดงช่วงราคา, ในขณะที่เส้น series ส่วนบุคคลและเส้นกริดแนวนอนรองถูกซ่อน

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

![The Stock chart](stock_chart.png)

### **สร้าง Box and Whisker Charts**

Box and whisker chart ใช้แสดงการกระจายของข้อมูลโดยสรุปสถิติหลัก เช่น มัธยฐาน, ควอไทล์, และค่า outlier เหมาะสำหรับการวิเคราะห์ข้อมูลเชิงสำรวจและการศึกษาทางสถิติ เพื่อทำความเข้าใจความแปรผันของข้อมูลและระบุความผิดปกติได้อย่างรวดเร็ว

ตัวอย่างนี้สร้าง box and whisker chart จากหกค่า วิธี [setQuartileMethod](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setQuartileMethod-int-) เลือกการคำนวณ quartile แบบ exclusive. ตัวอย่างยังเปิดใช้งาน mean lines, mean markers, inner points, และ outlier points

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

### **สร้าง Funnel Charts**

Funnel chart ใช้แสดงกระบวนการที่มีหลายขั้นตอนโดยปริมาณข้อมูลจะลดลงตามลำดับขั้น บริการนี้ช่วยวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพิ่ม funnel chart ไปยังสไลด์แรกของ presentation ที่มีอยู่ แล้วแทนที่ข้อมูลเริ่มต้นด้วยหกหมวดและค่าตั้งแต่ 50 ถึง 500 แล้วบันทึก presentation ที่อัปเดต. presentation อินพุตต้องมีสไลด์อย่างน้อยหนึ่งสไลด์

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

![The Funnel chart](funnel_chart.png)

### **สร้าง Sunburst Charts**

Sunburst chart ใช้แสดงข้อมูลเชิงลำดับขั้นโดยแสดงระดับต่าง ๆ เป็นวงแหวนศูนย์กลาง ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะกับการแสดงหมวดหมู่ที่ซ้อนกันในรูปแบบที่กระชับและชัดเจน

ตัวอย่างนี้สร้าง sunburst chart ที่มีใบแปดใบจัดเป็นสเตมสี่ใบและสาขาสองสาขา วิธี [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) กำหนดสเตมที่ระดับ 1 และสาขาที่ระดับ 2 ป้ายหมวดระบุส่วนต่าง ๆ, ค่ากำหนดขนาดสัมพัทธ์ของแต่ละส่วน

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

![The Sunburst chart](sunburst_chart.png)

### **สร้าง Histogram Charts**

Histogram แสดงการกระจายของค่าตัวเลขในช่วง (bins). สำหรับรายงานรายเดือนเกี่ยวกับระยะเวลาการประมวลผลคำสั่งซื้อ ควรใช้ความกว้าง bin และค่าเกณฑ์เดียวกันเพื่อให้ช่วงสอดคล้องและทำให้การเปรียบเทียบการกระจายทำได้ง่าย

เรียก [setAggregationType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAggregationType-int-) บนแกนแนวนอนด้วยโหมดจาก [AxisAggregationType](https://reference.aspose.com/slides/java/com.aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setBinWidth-double-) ใช้กับ `ByBinWidth` เท่านั้น; [setNumberOfBins](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberOfBins-long-) ใช้กับ `ByNumberOfBins` เท่านั้น. ใช้ `Automatic` ให้แผนภูมิกำหนด bin เอง

#### **ใช้ความกว้าง Bin คงที่**

ตัวอย่างนี้จัดกลุ่มระยะเวลาประมวลผลเป็นช่วง 10 นาที, มี bin พิเศษสำหรับค่าที่ ≤ 10 นาทีและ > 40 นาที เปิดใช้งาน bin เหล่านี้ด้วย [setUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setUnderflowBin-boolean-) และ [setOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setOverflowBin-boolean-). เมื่อกำหนด threshold อย่างชัดเจนผ่าน [setUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setUnderflowBin-double-) และ [setOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setOverflowBin-double-), เรียก [setAutomaticUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticUnderflowBin-boolean-) และ [setAutomaticOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticOverflowBin-boolean-) ด้วย `false`

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
    for (int i = 0; i < values.length; i++)
    {
        IChartDataCell valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(AxisAggregationType.ByBinWidth);
    axis.setBinWidth(10);
    axis.setUnderflowBin(true);
    axis.setAutomaticUnderflowBin(false);
    axis.setUnderflowBin(10);
    axis.setOverflowBin(true);
    axis.setAutomaticOverflowBin(false);
    axis.setOverflowBin(40);

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

การแสดงผลใน PowerPoint มีจำนวน bin **3, 4, 4, 4, และ 2**. Bin underflow มี `5, 10, 10` (threshold รวม), bin overflow มี `41, 50` (threshold ไม่รวม); ค่า `40` อยู่ในช่วงก่อนหน้า. Bin ภายในมีค่า > lower boundary และ ≤ upper boundary

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **ระบุจำนวน Bin**

หากต้องการระดับรายละเอียดคงที่แทนช่วงคงที่ ให้กำหนด five bins สำหรับข้อมูลเดียวกัน ตัวอย่างนี้ปิดการใช้งาน bin underflow และ overflow. แผนภูมิคำนวณความกว้างจากช่วงข้อมูล, ดังนั้นขอบเขตอาจเปลี่ยนระหว่างรายงาน

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200);

    chart.setLegend(false);
    chart.setTitle(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Histogram);
    double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
    for (int i = 0; i < values.length; i++)
    {
        IChartDataCell valueCell = workbook.getCell(0, i, 0, values[i]);
        series.getDataPoints().addDataPointForHistogramSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins);
    axis.setNumberOfBins(5);

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.dispose();
}
```

ห้า bin มีจำนวน **4, 4, 4, 4, และ 1**. เปรียบเทียบกับผลลัพธ์ความกว้างคงที่ด้านบน: ค่าข้อมูลเท่าเดิม แต่ขอบเขตต่างกัน

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **สร้าง Radar Charts**

Radar chart ใช้แสดงข้อมูลหลายตัวแปรบนรูปแบบสองมิติ ทำให้เปรียบเทียบหลายตัวแปรพร้อมกันง่าย เหมาะสำหรับระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) สร้าง radar chart ด้วย series และ category เริ่มต้น, แล้วบันทึกเป็น PPTX

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

![The Radar chart](radar_chart.png)

### **สร้าง Multi‑Category Charts**

Multi‑category chart ใช้แสดงข้อมูลที่มีการจัดกลุ่มหมวดหลายระดับพร้อมกัน ช่วยให้เปรียบเทียบค่าในหลายมิติได้พร้อมกัน เหมาะเมื่อคุณต้องวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลหลายชั้น

ตัวอย่างนี้สร้าง clustered column chart ที่มีแปดหมวดจัดเป็นสี่คู่ วิธี [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) ให้แต่ละคู่มีป้ายร่วมที่ระดับกลุ่ม 1 ทำให้แกนหมวดมีทั้งป้ายเดี่ยวและป้ายกลุ่ม

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

![The multi category chart](multi_category_chart.png)

### **สร้าง Map Charts**

Map chart ใช้แสดงข้อมูลเชิงภูมิศาสตร์โดยแมพข้อมูลไปยังตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง เหมาะสำหรับวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและน่าสนใจ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) สร้าง map chart ด้วยข้อมูลทางภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 5 00, 300);

    presentation.save("mapChart.pptx", SaveFormat.Pptx);
}
finally
{
    presentation.save(0);
}
```

ผลลัพธ์:

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}
รูปภาพด้านบนแสดง presentation ที่บันทึกแล้วเปิดใน PowerPoint. Aspose.Slides เขียน map chart และข้อมูลได้อย่างถูกต้อง, แต่ไม่ได้วาด map chart เอง: เมื่อสไลด์ที่มี map chart ถูกแปลงเป็นภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะว่างเปล่า. รูปทรงอื่นในสไลด์เดียวกันไม่ถูกกระทบ
{{% /alert %}}

### **สร้าง Combination Charts**

Combination chart (หรือ combo chart) ผสานประเภทแผนภูมิสองประเภทหรือมากกว่าในกราฟเดียว ช่วยให้คุณเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อระบุความสัมพันธ์ระหว่างกัน

![The combination chart](combination_chart.png)

ตัวอย่างนี้รวมสอง series ของ clustered column กับ series ของ line ไว้ในสี่หมวด. คอลัมน์ใช้แกนแนวตั้งหลัก, ส่วน line ใช้ [setPlotOnSecondAxis](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setPlotOnSecondAxis-boolean-) วางบนแกนแนวตั้งรองด้านขวา. ฟังก์ชันช่วยเหลือกำหนดหัวเรื่อง, legend, ป้ายแกน, และเส้นกริด

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
        verticalAxis.getFormat().getLine().setFillType(FillType.NoFill);

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
        secondaryVerticalAxis.getFormat().getLine().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMajorGridLinesFormat().getLine().setFillType(FillType.NoFill);
        secondaryVerticalAxis.getMinorGridLinesFormat().getLine().setFillType(FillType.NoFill);

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

Aspose.Slides for Java ให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ ฟังก์ชันนี้ทำให้การอัปเดตงานนำเสนอด้วยเนื้อหาไดนามิกเป็นเรื่องง่ายและทำให้แผนภูมิสะท้อนข้อมูลและมาตรฐานการออกแบบล่าสุดได้อย่างแม่นยำ

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ “My chart” บนสไลด์แรกของ presentation ที่มีอยู่. ต้องมีสอง series ของคอลัมน์ที่มีจุดข้อมูลสามจุดแต่ละจุด, ป้ายหมวดอยู่ในคอลัมน์ A และชื่อ series อยู่ในแถวแรกของ worksheet แรก. ตัวอย่างใช้ [getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-java.lang.Object-) เพื่อเปลี่ยนค่าใน workbook, อัปเดตค่าของ series, เพิ่ม series ที่สาม, และเปลี่ยนประเภทแผนภูมิเป็น clustered cylinders ผ่าน [setType](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setType-int-)

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

เพื่อดูช่วงที่แผนภูมิใช้อยู่แล้ว ให้ดูที่ [Retrieve a Chart's Data Range](/slides/th/java/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides for Java ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจาก worksheet เป็นแหล่งข้อมูลของแผนภูมิของคุณ หมายความว่าคุณสามารถแมพส่วนของ worksheet ไปยังแผนภูมิได้โดยตรง ควบคุมว่าเซลล์ใดมีส่วนร่วมใน series และ category ของแผนภูมิ. ด้วยวิธีนี้คุณสามารถอัปเดตและซิงโครไนซ์แผนภูมิของคุณกับการเปลี่ยนแปลงข้อมูลล่าสุดใน worksheet ได้อย่างง่ายดาย ทำให้งานนำเสนอ PowerPoint ของคุณแสดงข้อมูลที่เป็นปัจจุบันและแม่นยำ

ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อตั้งค่า data source ของแผนภูมิชื่อ “My chart” บนสไลด์แรกของ presentation ที่มีอยู่เป็น `Sheet1!A1:B4`. Workbook ของแผนภูมิต้องมี worksheet ดังกล่าวและช่วงที่เต็มด้วยหัวเรื่อง series ในแถวแรก, ป้ายหมวดในคอลัมน์ A, และค่าสามค่าในคอลัมน์ B

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

## **ใช้ Default Markers ในแผนภูมิ**

เมื่อใช้ default markers ในแผนภูมิ, แต่ละ series จะได้รับสัญลักษณ์ marker เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) สร้างแผนภูมิที่มีสอง series แบบ line และ legend. การตั้งค่า marker ที่เข้าถึงผ่าน [getMarker](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getMarker--) เก็บสัญลักษณ์ marker ที่กำหนดอัตโนมัติ. Series แรกมีค่าลบและค่าที่หายไป (`null`), ส่วนที่สองมีค่าทุกหมวด

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

## **FAQ**

**Aspose.Slides for Java รองรับประเภทแผนภูมิอะไรบ้าง?**

Aspose.Slides for Java รองรับแผนภูมิหลายประเภท รวมถึง bar, line, pie, area, scatter, histogram, radar และอื่น ๆ อีกมาก ซึ่งทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณได้

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ, คุณต้องสร้างออบเจกต์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิพร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น วิธีนี้จะผสานแผนภูมิเข้ากับ presentation ของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง data workbook ของแผนภูมิ ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)), ลบ series และ category เริ่มต้น, จากนั้นเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ช่วยให้คุณรีเฟรชแผนภูมิโปรแกรมเมติกเพื่อสะท้อนข้อมูลล่าสุดได้

**สามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for Java มีตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้าย, legend, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงตามความต้องการออกแบบของคุณได้อย่างเต็มที่