---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ใน Java
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
- แผนภูมิพาย
- แผนภูมิเส้น
- แผนภูมิตรีแมป
- แผนภูมิสต็อก
- แผนภูมิกล่องและวิสเกอร์
- แผนภูมิกระบอก
- แผนภูมิดวงอาทิตย์
- แผนภูมิฮิสโทแกรม
- แผนภูมเรดาร์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Java. เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดจริงใน Java."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำที่ครอบคลุมเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for Java คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม, เติมข้อมูลลงในแผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้สอดคล้องกับความต้องการการออกแบบของคุณ รายละเอียดโค้ดตัวอย่างจะอธิบายแต่ละขั้นตอน ตั้งแต่การเริ่มต้น Presentation และวัตถุ Chart ไปจนถึงการกำหนด Series, Axis และ Legend โดยการทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีการรวมการสร้างแผนภูมิกระ动态ลงในแอปพลิเคชัน Java ของคุณ, ทำให้กระบวนการสร้างงานนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อมูลเชิงลึกที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

* รวม, บีบอัด หรือสรุปข้อมูลจำนวนมากบนสไลด์เดียวในงานนำเสนอ;
* เปิดเผยรูปแบบและแนวโน้มในข้อมูล;
* สรุปทิศทางและแรงขับของข้อมูลตามเวลา หรือเทียบกับหน่วยการวัดเฉพาะ;
* ระบุค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีเหตุผล;
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ที่มาพร้อมกับเทมเพลตสำหรับออกแบบแผนภูมิจำนวนหลายประเภท โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (อิงจากประเภทแผนภูมิที่นิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้การ enumerate [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ในแพ็กเกจ [com.aspose.slides](https://reference.aspose.com/slides/java/com.aspose.slides/) ค่าต่าง ๆ ในการ enumerate นี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิคอลัมน์แบบกลุ่มที่เปรียบเทียบสอง Series ข้ามสาม Category Series ใช้สีเติมแดงและเขียว, และป้ายกำกับแต่ละรายการแสดงชื่อ Category, ชื่อ Series และค่า Worksheet index 0 หมายถึงแผ่นงานแรกใน workbook ของแผนภูมิที่ฝังไว้

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

![แผนภูมิคอลัมน์แบบกลุ่ม](clustered_column_chart.png)

### **สร้างแผนภูมิ Scatter**

แผนภูมิ Scatter (หรือที่เรียกว่ากราฟกระจาย) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิ Scatter เมื่อ:

* คุณมีข้อมูลตัวเลขเป็นคู่
* คุณมีสองตัวแปรที่จับคู่กันได้ดี
* คุณต้องการตรวจสอบว่าตัวแปรสองตัวสัมพันธ์กันหรือไม่
* คุณมีตัวแปรอิสระที่มีหลายค่าสำหรับตัวแปรตาม

ตัวอย่างนี้พล็อตค่าชุด x‑y สองชุด Series แรกใช้เส้นตรงกับเครื่องหมายดาว, ส่วนที่สองใช้เส้นโค้งพร้อมเครื่องหมายวงกลม; ทั้งสองใช้ขนาดเครื่องหมาย 10 ซึ่งกำหนดด้วย [setSize](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSize-int-). วิธี [setSymbol](https://reference.aspose.com/slides/java/com.aspose.slides/imarker/#setSymbol-int-) ควบคุมรูปแบบเครื่องหมาย

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

![แผนภูมิ Scatter](scatter_chart.png)

### **สร้างแผนภูมิ Pie**

แผนภูมิ Pie เหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล, โดยเฉพาะเมื่อข้อมูลมีป้ายประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีหลายส่วนหรือหลายป้าย อาจพิจารณาใช้แผนภูมิแท่งแทน

ตัวอย่างนี้สร้างแผนภูมิ Pie ที่มีค่าฤดูไตรมาสสามค่า แต่ละชิ้นมีการเติมสีและเส้นขอบที่กำหนดเอง, และป้ายกำกับแสดงการผสมค่าต่าง ๆ, เปอร์เซ็นต์, และข้อมูล Series วิธี [setFirstSliceAngle](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setFirstSliceAngle-int-) กำหนดให้ชิ้นแรกเริ่มที่ 180 องศา

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
    thirdSlice.getFormat().setFill().setFillType(FillType.Solid);
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

![แผนภูมิ Pie](pie_chart.png)

เพื่อปรับปรุงความอ่านง่ายของป้ายกำกับด้านนอก Pie, ดู [Format Leader Lines](/slides/th/java/chart-data-label/#format-leader-lines) สำหรับตัวอย่างที่กำหนดตำแหน่งป้ายและปรับสี, ความกว้าง, ความโปร่งแสง, และสไตล์ของเส้น

### **สร้างแผนภูมิ Line**

แผนภูมิ Line (หรือกราฟเส้น) เหมาะกับสถานการณ์ที่ต้องแสดงการเปลี่ยนแปลงค่าตามเวลา โดยใช้แผนภูมิ Line คุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, ไฮไลท์ความผิดปกติใน Series และอื่น ๆ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิ Line ด้วย Series และ Category เริ่มต้น, จากนั้นบันทึกเป็น PPTX

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

โดยปกติจุดบนแผนภูมิ Line จะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นประ ให้เรียก [setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) พร้อมค่าจาก [LineDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/):

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

![แผนภูมิ Line](line_chart.png)

### **สร้างแผนภูมิ Tree Map**

แผนภูมิ Tree Map เหมาะสำหรับข้อมูลการขายเมื่อต้องแสดงขนาดสัมพัทธ์ของ Category และดึงดูดความสนใจไปที่รายการที่เป็นผู้ร่วมสนับสนุนใหญ่ภายในแต่ละ Category

ตัวอย่างนี้สร้าง Tree Map ที่มีใบแปดใบจัดกลุ่มเป็นสี่ก้านและสองแขนง วิธี [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) กำหนดสี่ก้านที่ระดับ grouping 1 และแขนงที่ระดับ 2 ค่าแสดงขนาดสี่เหลี่ยมสัมพัทธ์, ส่วนป้าย Category และป้ายพาเรนท์ที่ซ้อนทับบ่งบอกลำดับชั้น

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

![แผนภูมิ Treemap](treemap_chart.png)

### **สร้างแผนภูมิ Waterfall**

แผนภูมิ Waterfall แสดงการเปลี่ยนแปลงบวกและลบที่ส่งผลต่อค่าขั้นสุดท้าย ตัวอย่างเช่น การแสดงผลกำไรอาจเริ่มจากรายได้, หักค่าใช้จ่าย, แล้วบวกรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงลอยระหว่างค่าก่อนหน้าและค่าปัจจุบัน, ส่วนคอลัมน์รวมขยายจากศูนย์ถึงค่าที่สะสม

ตัวอย่างต่อไปใช้จำนวนเป็นพันดอลลาร์สหรัฐ:

| Category | Workbook value | Column type |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

เพื่อทำเครื่องหมายจุดเป็นยอดรวมกลางหรือสุดท้าย ให้เรียก [setSetAsTotal](https://reference.aspose.com/slides/java/com.aspose.slides/chartdatapoint/#setSetAsTotal-boolean-) ของจุดนั้นด้วย `true`. ระบุจำนวนที่สะสมจริงในเซลล์ workbook ของจุดนั้น: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`). วิธีนี้ทำเครื่องหมายคอลัมน์ว่าเป็นยอดรวม; ไม่ได้คำนวณหรือเติมค่าในเซลล์ อย่าใช้ศูนย์เป็นตัวแทนหรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดยอดรวม คอลัมน์ยอดรวมจะแสดงค่าที่สะสมโดยไม่เพิ่มซ้ำค่าในค่ารันนิ่ง

ตัวอย่าง Java ฉบับเต็มนี้สร้างแผนภูมิโดยใช้สมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/), ล้างข้อมูลเริ่มต้น, แล้วเติม workbook ที่ฝังอยู่ Worksheet index `0` เลือกแผ่นงานแรก; คอลัมน์ A มีชื่อ Category, คอลัมน์ B มีค่า แต่ละเซลล์ค่าถูกเพิ่มด้วย [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapointcollection/#addDataPointForWaterfallSeries-com.aspose.slides.IChartDataCell-). ดัชนีจุด 0‑based `2` และ `5` ระบุตำแหน่งยอดกลางและสุดท้าย การเรียก [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) ด้วย `true` แสดงจำนวนบนคอลัมน์ ไม่ต้องมีการนำเสนอหรือ workbook เข้า

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

    // จุดที่สามและหกเป็นยอดรวม, ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
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

เรียกวิธีระดับ Series [setShowConnectorLines](https://reference.aspose.com/slides/java/com.aspose.slides/chartseries/#setShowConnectorLines-boolean-) ด้วย `true` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่อง ทำให้ค่ารันนิ่งตามง่ายขึ้น หากต้องการซ่อนเส้นเหล่านี้ให้แทนที่การเรียกด้วย `series.setShowConnectorLines(false);` ก่อนบันทึก การเปลี่ยนแปลงนี้มีผลเพียงการแสดงเส้นเท่านั้น ไม่กระทบต่อข้อมูลหรือยอดรวม

งานนำเสนอที่บันทึกแสดงกำไรขั้นต้น 600 และกำไรสุทธิ 450, ทั้งสองยอดรวมเริ่มจากศูนย์:

![แผนภูมิ Waterfall แสดงรายได้, ค่าใช้จ่าย, กำไรขั้นต้น 600, และกำไรสุทธิ 450 พร้อมป้ายค่าและเส้นเชื่อม](waterfall_chart.png)

### **สร้างแผนภูมิ Stock**

แผนภูมิ Stock ใช้แสดงข้อมูลการเงินเช่น ราคาเปิด, สูง, ต่ำ, ปิด, ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลเชิงลึกสำคัญต่อประสิทธิภาพหุ้นช่วยนักลงทุนและนักวิเคราะห์ตัดสินใจ

ตัวอย่างนี้สร้างแผนภูมิ Open‑High‑Low‑Close ที่มีสี่ Series ตามลำดับและสาม Category วิธี [setUpDownBars](https://reference.aspose.com/slides/java/com.aspose.slides/iupdownbarsmanager/#setUpDownBars-boolean-) เปิดใช้งานแถบขึ้น/ลง, และ [getHiLowLinesFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getHiLowLinesFormat--) ควบคุมเส้น High‑Low ที่แสดงช่วงราคา, ในขณะที่เส้น Series แยกและเส้นกริดแนวนอนย่อยถูกซ่อน

ผู้จัดการที่คืนค่าจาก [getUpDownBars](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getUpDownBars--) เปิดเผยอ็อบเจกต์ฟอร์แมตแยกผ่าน [getUpBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iupdownbarsmanager/#getUpBarsFormat--) และ [getDownBarsFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iupdownbarsmanager/#getDownBarsFormat--). ใช้แต่ละอ็อบเจกต์กับ [getFill](https://reference.aspose.com/slides/java/com.aspose.slides/iformat/#getFill--) และ [getLine](https://reference.aspose.com/slides/java/com.aspose.slides/iformat/#getLine--) เพื่อตั้งค่าสีเติมและขอบอย่างอิสระ ตัวอย่างนี้ใช้แถบสีเขียวพร้อมขอบเขียวเข้มสำหรับช่วงขึ้นและแถบสีส้ม‑แดงพร้อมขอบแดงเข้มสำหรับช่วงลง

กำหนดค่าตัวเลขให้ทั้งสี่ Series ในแต่ละ Category, โดย High และ Low ครอบคลุม Open และ Close. แถบเปรียบเทียบ Close กับ Open **ภายใน Category เดียวกัน**, ไม่ใช่กับ Category ก่อนหน้า: A ลดจาก 72 เป็น 25, ในขณะที่ B เพิ่มจาก 25 เป็น 38 และ C เพิ่มจาก 38 เป็น 50. ค่า Open และ Close เท่ากันจะไม่มีช่วงสีเต็ม. แถบขึ้น/ลงครอบคลุม Open‑Close; เส้น High‑Low ครอบคลุม Low‑High. แถบเหล่านี้เป็นส่วนของ Series Group ไม่ใช่ Series แถบปกติ

การจัดรูปแบบนี้ยังทำงานกับแผนภูมิ [Line and LineWithMarkers](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) ที่มีอย่างน้อยสอง Series ในกลุ่มเดียวกันและค่าตัวเลขสำหรับแต่ละ Category. สำหรับแผนภูมิ Line ที่ไม่ stacked, แถบขึ้น/ลงเปรียบเทียบ Series แรกและสุดท้าย: ค่าสุดท้ายสูงกว่าจะได้แถบขึ้น, ต่ำกว่าจะได้แถบลง การสลับ Series จะสลับการจัดประเภท ตัวอย่างด้านล่างใช้ [OpenHighLowClose](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/); อย่าสมมติว่า stock, stacked‑line หรือ variant 3D อื่น ๆ ใช้การจัดเรียงข้อมูลหรือการตีความช่วงเดียวกัน

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try
{
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

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

    IUpDownBarsManager upDownBars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars();
    upDownBars.setUpDownBars(true);

    upDownBars.getUpBarsFormat().getFill().setFillType(FillType.Solid);
    upDownBars.getUpBarsFormat().getFill().getSolidFillColor().setColor(new Color(50, 205, 50));
    upDownBars.getUpBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    upDownBars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 100, 0));
    upDownBars.getUpBarsFormat().getLine().setWidth(2);

    upDownBars.getDownBarsFormat().getFill().setFillType(FillType.Solid);
    upDownBars.getDownBarsFormat().getFill().getSolidFillColor().setColor(new Color(255, 69, 0));
    upDownBars.getDownBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    upDownBars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
    upDownBars.getDownBarsFormat().getLine().setWidth(2);
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

ผลลัพธ์ที่ส่งออกจาก PowerPoint:

![แผนภูมิ Stock พร้อมช่วงสีส้ม‑แดงลดลงสำหรับ A และช่วงสีเขียวเพิ่มขึ้นสำหรับ B และ C](stock_chart.png)

### **สร้างแผนภูมิ Box and Whisker**

แผนภูมิ Box and Whisker ใช้แสดงการกระจายข้อมูลโดยสรุปมาตรการสถิติหลัก เช่น มัธยฐาน, ควอไทล์, และค่าตัวแปรนอก (outliers) มีประโยชน์ในการวิเคราะห์สำรวจและการศึกษาสถิติ เพื่อทำความเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติอย่างรวดเร็ว

ตัวอย่างนี้สร้างแผนภูมิ Box and Whisker จากห้าค่า วิธี [setQuartileMethod](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setQuartileMethod-int-) เลือกการคำนวณควอไทล์แบบ exclusive ตัวอย่างยังเปิดใช้งานเส้นค่าเฉลี่ย, เครื่องหมายค่าเฉลี่ย, จุดใน, และจุดนอก

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

### **สร้างแผนภูมิ Funnel**

แผนภูมิ Funnel ใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง, ที่ปริมาณข้อมูลจะลดลงเมื่อดำเนินจากขั้นตอนหนึ่งไปยังขั้นตอนต่อไป มีประโยชน์ในการวิเคราะห์อัตราการเปลี่ยนแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อเพิ่มแผนภูมิ Funnel ไปยังสไลด์แรกของการนำเสนอที่มีอยู่, แทนที่ข้อมูลเริ่มต้นด้วยห้าหมวดและค่าตั้งแต่ 50 ถึง 500, จากนั้นบันทึกการนำเสนอที่อัปเดต การนำเข้าต้องมีอย่างน้อยหนึ่งสไลด์

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

![แผนภูมิ Funnel](funnel_chart.png)

### **สร้างแผนภูมิ Sunburst**

แผนภูมิ Sunburst ใช้เพื่อแสดงข้อมูลเชิงลำดับขั้น, โดยแสดงระดับต่าง ๆ เป็นวงแหวนศูนย์กลาง ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะสำหรับแสดง Category ย่อยที่ซ้อนกันในรูปแบบที่ชัดเจนและกะทัดรัด

ตัวอย่างนี้สร้างแผนภูมิ Sunburst ที่มีใบแปดใบจัดกลุ่มเป็นสี่ก้านและสองแขนง วิธี [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) กำหนดก้านที่ระดับ 1 และแขนงที่ระดับ 2 ป้าย Category ระบุส่วน, ค่าตัดสินขนาดสัมพัทธ์

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

![แผนภูมิ Sunburst](sunburst_chart.png)

### **สร้างแผนภูมิ Histogram**

แผนภูมิ Histogram แสดงการกระจายค่าตัวเลขตามช่วง (bins). สำหรับรายงานประจำเดือนของเวลาในการประมวลผลคำสั่ง, ใช้ความกว้างบินเดียวกันและเกณฑ์เดียวกันเพื่อให้ช่วงสอดคล้องและทำให้การเปรียบเทียบกระจายง่ายขึ้น

เรียก [setAggregationType](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAggregationType-int-) บนแกนแนวนอนด้วยโหมดจาก [AxisAggregationType](https://reference.aspose.com/slides/java/com.aspose.slides/axisaggregationtype/). วิธี [setBinWidth](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setBinWidth-double-) ใช้ได้เฉพาะกับ `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberOfBins-long-) ใช้ได้เฉพาะกับ `ByNumberOfBins`. ใช้ `Automatic` เพื่อให้แผนภูมิกำหนดบินเอง

#### **ใช้ความกว้าง Bin คงที่**

ตัวอย่างนี้จัดกลุ่มเวลาในการประมวลผลเป็นช่วง 10 นาที, พร้อมบินแยกสำหรับเวลาน้อยกว่าหรือเท่ากับ 10 นาทีและเวลามากกว่า 40 นาที เปิดบินเหล่านี้ด้วย [setUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setUnderflowBin-boolean-) และ [setOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setOverflowBin-boolean-). เมื่อกำหนดเกณฑ์โดยตรงผ่าน [setUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setUnderflowBin-double-) และ [setOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setOverflowBin-double-), เรียก [setAutomaticUnderflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticUnderflowBin-boolean-) และ [setAutomaticOverflowBin](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticOverflowBin-boolean-) ด้วย `false`

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

งานนำเสนอใน PowerPoint แสดงจำนวนบิน **3, 4, 4, 4, และ 2**. บิน underflow รวมค่า `5, 10, 10`, ดังนั้นเกณฑ์เป็น inclusive. บิน overflow มีค่า `41, 50` เท่านั้น, ดังนั้นเกณฑ์เป็น exclusive; ค่า `40` จะอยู่ในช่วงก่อนหน้า. บินภายในมีค่ามากกว่าขอบล่างและน้อยกว่าหรือเท่ากับขอบบน

![Histogram ด้วยบิน 10‑นาทีและเกณฑ์ underflow/overflow ชัดเจน](histogram_bin_width.png)

#### **ระบุจำนวน Bin**

สำหรับระดับรายละเอียดคงที่แทนที่จะกำหนดช่วงคงที่, ขอ five bins สำหรับข้อมูลเดียวกัน ตัวอย่างนี้ปิดบิน underflow และ overflow. แผนภูมิกำหนดความกว้างจากช่วงข้อมูล, ดังนั้นขอบเขตอาจเปลี่ยนระหว่างรายงาน

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

ห้าบินมีจำนวน **4, 4, 4, 4, และ 1**. เปรียบเทียบการกระจายนี้กับผลของความกว้างคงที่ข้างต้น: ค่าข้อมูลเดียวกัน, แต่ขอบเขตแตกต่างกัน

![Histogram ด้วยห้าบินคำนวณจากข้อมูลเดียวกัน](histogram_bin_count.png)

### **สร้างแผนภูมิ Radar**

แผนภูมิ Radar ใช้แสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ, ช่วยเปรียบเทียบหลายตัวแปรพร้อมกัน, มีประโยชน์ในการระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิ Radar ด้วย Series และ Category เริ่มต้น, จากนั้นบันทึกเป็น PPTX

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

![แผนภูมิ Radar](radar_chart.png)

### **สร้างแผนภูมิ Multi-Category**

แผนภูมิ Multi-Category ใช้แสดงข้อมูลที่มีการจัดกลุ่มประเภทหลายระดับ, ช่วยเปรียบเทียบค่าข้ามหลายมิติพร้อมกัน, เหมาะเมื่อวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลหลายชั้น

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีแปด Category จัดเรียงเป็นสี่คู่ วิธี [setGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#setGroupingItem-int-java.lang.Object-) ให้แต่ละคู่มีป้ายร่วมที่ระดับ grouping 1, สร้างแกน Category ที่มีป้ายแยกและป้ายกลุ่ม

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

![แผนภูมิ multi category](multi_category_chart.png)

#### **ลบป้ายไตรมาส**

ดาวน์โหลด [quarters.pptx](quarters.pptx) และวางไว้ในไดเรกทอรีทำงาน. แผนภูมิของไฟล์นี้แสดงเดือนเก้เดือนและ Series ขายหนึ่งชุดค่าตั้งแต่ 10 ถึง 18. บนแกน Category, Q1 ครอบคลุมมกราคม‑มีนาคม, Q2 ครอบคลุมเมษายน‑มิถุนายน, Q3 ครอบคลุมกรกฎาคม‑กันยายน.

เดือนเมษายนคือ Category ที่สี่ (index 3) และถือป้าย Q2. ใช้ [getGroupingLevels](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/#getGroupingLevels--) เพื่อเข้าถึงระดับ grouping ของเมษายน, แล้วเรียก [deleteGroupingItem](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorylevelsmanager/#deleteGroupingItem-int-) ด้วยระดับ 1 เพื่อลบป้ายไตรมาสนั้น. ระดับ 0 แทนเดือนเองและไม่สามารถลบได้ด้วยวิธีนี้

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

Presentation presentation = new Presentation("quarters.pptx");
try {
    IChart chart = (IChart) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartCategory april = chart.getChartData().getCategories().get_Item(3);
    april.getGroupingLevels().deleteGroupingItem(1);

    presentation.save("quarters-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopened = new Presentation("quarters-updated.pptx");
try {
    IChart updatedChart = (IChart) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = updatedChart.getChartData();
    
    StringJoiner months = new StringJoiner(", ");
    for (IChartCategory month : data.getCategories()) {
        months.add(String.valueOf(month.getAsCell().getValue()));
    }
    StringJoiner sales = new StringJoiner(", ");
    for (IChartDataPoint point : data.getSeries().get_Item(0).getDataPoints()) {
        sales.add(String.valueOf(point.getValue().getData()));
    }
    System.out.println(months);
    System.out.println(sales);
} finally {
    reopened.dispose();
}
```

หลังเปิดแผนภูมิเค้าใหม่ ตัวอย่างพิมพ์เดือนเดิม (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) และค่าการขาย (`10, 11, 12, 13, 14, 15, 16, 17, 18`) ตามลำดับเดียวกัน เปิดไฟล์ `quarters-updated.pptx` ใน PowerPoint เพื่อเปรียบเทียบป้ายแกน. ป้าย Q2 และขอบกลุ่มก่อนเมษายนจะหายไป, ดังนั้น Q1 ครอบคลุมมกราคม‑มิถุนายน. Q3 ยังคงเริ่มเดือนกรกฎาคม

![ป้ายไตรมาสก่อนและหลังการลบ. ด้านซ้าย Q2 ครอบคลุมเมษายน‑มิถุนายน. ด้านขวา Q1 ครอบคลุมมกราคม‑มิถุนายน.](quarter-label-comparison.png)

### **สร้างแผนภูมิ Map**

แผนภูมิ Map ใช้แสดงข้อมูลเชิงภูมิศาสตร์โดยเชื่อมข้อมูลกับตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง มีประโยชน์ในการวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่เห็นภาพชัดเจน

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิ Map ด้วยข้อมูลภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

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

![แผนภูมิ Map](map_chart.png)

{{% alert color="info" title="Note" %}}
ภาพด้านบนแสดงงานนำเสนอที่บันทึกแล้วเปิดใน PowerPoint. Aspose.Slides เขียนแผนภูมิ Map และข้อมูลของมันได้ถูกต้อง, แต่ไม่ได้วาดแผนภูมิ Map เอง: เมื่อสไลด์ที่มีแผนภูมิ Map ถูกเรนเดอร์เป็นภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะเป็นสีขาว. รูปทรงอื่นบนสไลด์เดียวกันไม่มีผลกระทบ
{{% /alert %}}

### **สร้างแผนภูมิ Combination**

แผนภูมิ Combination (หรือ combo chart) รวมสองหรือมากกว่าชนิดแผนภูมิในกราฟเดียว, ช่วยไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด, ทำให้ระบุความสัมพันธ์ระหว่างข้อมูลได้ง่ายขึ้น

![แผนภูมิ Combination](combination_chart.png)

ตัวอย่างนี้รวมสอง Series คอลัมน์แบบกลุ่มกับ Series เส้นหนึ่งชุดในสี่ Category. คอลัมน์ใช้แกนแนวตั้งหลัก, ในขณะที่ [setPlotOnSecondAxis](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setPlotOnSecondAxis-boolean-) วางเส้นบนแกนแนวตั้งรองด้านขวา. ฟังก์ชันช่วยตั้งค่าชื่อเรื่อง, เลเจนด์, ป้ายแกน, และเส้นตาราง

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

Aspose.Slides for Java ช่วยให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ การทำเช่นนี้ทำให้การรักษาเนื้อหาให้เป็นปัจจุบันกับข้อมูลไดนามิกง่ายขึ้นและทำให้แผนภูมิสะท้อนข้อมูลและมาตรฐานภาพที่ถูกต้อง

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ "My chart" บนสไลด์แรกของงานนำเสนอที่มีอยู่. ต้องการสอง Series คอลัมน์ที่มีแต่ละ Series สามจุดข้อมูล, โดยป้าย Category อยู่ในคอลัมน์ A และชื่อ Series อยู่ในแถวแรกของแผ่นงานแรก ตัวอย่างใช้ [getCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-java.lang.Object-) เพื่อเปลี่ยนเซลล์ workbook, อัปเดตค่าของ Series, เพิ่ม Series ที่สาม, และเปลี่ยนแผนภูมิเป็นรูปทรงกระบอกแบบกลุ่มโดยใช้ [setType](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setType-int-)

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

เพื่อดูช่วงที่ใช้งานโดยแผนภูมิที่มีอยู่แล้ว, ดู [Retrieve a Chart's Data Range](/slides/th/java/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides for Java ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจากแผ่นงานเป็นแหล่งข้อมูลสำหรับแผนภูมิของคุณ ซึ่งหมายความว่าคุณสามารถแมปส่วนของแผ่นงานไปยังแผนภูมิได้โดยตรง, ควบคุมว่าเซลล์ใดมีส่วนร่วมใน Series และ Category ของแผนภูมิ ผลที่ได้คือคุณสามารถอัปเดตและซิงโครไนซ์แผนภูมิของคุณกับการเปลี่ยนแปลงข้อมูลล่าสุดในแผ่นงาน, ทำให้งานนำเสนอ PowerPoint ของคุณสะท้อนข้อมูลที่เป็นปัจจุบันและแม่นยำ

ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) เพื่อตั้งค่าแหล่งข้อมูลของแผนภูมิชื่อ "My chart" บนสไลด์แรกของงานนำเข้าเป็น `Sheet1!A1:B4`. Workbook ของแผนภูมิต้องมีแผ่นงานนั้นและช่วงที่เติมค่าพร้อมหัว Series ในแถวแรก, ป้าย Category ในคอลัมน์ A, และสามค่าที่คอลัมน์ B

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

## **ใช้ Marker เริ่มต้นในแผนภูมิ**

เมื่อใช้ Marker เริ่มต้นในแผนภูมิ, แต่ละ Series จะได้รับสัญลักษณ์ Marker เริ่มต้นที่แตกต่างอัตโนมัติ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) เพื่อสร้างแผนภูมิที่มีสอง Series เส้นและเลเจนด์ การตั้งค่า Marker ที่เข้าถึงได้ผ่าน [getMarker](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getMarker--) เก็บสัญลักษณ์ Marker ที่กำหนดโดยอัตโนมัติ Series แรกมีค่าลบและค่าที่หายไป (`null`), ส่วนที่สองมีค่าทุก Category

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

**What chart types are supported by Aspose.Slides for Java?**

Aspose.Slides for Java รองรับประเภทแผนภูมิหลายประเภท รวมถึง แถบ, เส้น, พาย, พื้นที่, กระจาย, ไฮสโตแกรม, เรดาร์, และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับการแสดงผลข้อมูลของคุณ

**How do I add a new chart to a slide?**

เพื่อเพิ่มแผนภูมิ, ก่อนอื่นสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) รับสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิ, ระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้ทำให้แผนภูมิฝังลงในงานนำเสนอของคุณโดยตรง

**How can I update the data displayed in a chart?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูล ([IChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/)), ลบ Series และ Category เริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ทำให้คุณรีเฟรชแผนภูมิโดยอัตโนมัติตามข้อมูลล่าสุด

**Is it possible to customize the appearance of the chart?**

ใช่, Aspose.Slides for Java ให้ตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้าย, เลเจนด์, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิเข้ากับความต้องการการออกแบบของคุณ

Related feature: [Create editable charts](/slides/th/features/create-charts/).