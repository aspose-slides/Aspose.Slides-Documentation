---
title: "สร้างหรืออัปเดตแผนภูมิ PowerPoint ใน Python"
linktitle: "สร้างหรืออัปเดตแผนภูมิ"
type: docs
weight: 10
url: /th/python-java/create-chart/
keywords:
- "เพิ่มแผนภูมิ"
- "สร้างแผนภูมิ"
- "แก้ไขแผนภูมิ"
- "เปลี่ยนแปลงแผนภูมิ"
- "อัปเดตแผนภูมิ"
- "แผนภูมิกระจาย"
- "แผนภูมิวงกลม"
- "แผนภูมิเส้น"
- "แผนภูมิโทรไม้"
- "แผนภูมิสต็อก"
- "แผนภูมิกล่องและวิสเกอร์"
- "แผนภูมิกระบวนการ"
- "แผนภูมิดวงซันเบิร์สท์"
- "แผนภูมิเฮิสโตแกรม"
- "แผนภูมิโรบิน"
- "แผนภูมิหลายหมวด"
- "PowerPoint"
- "การนำเสนอ"
- "Python"
- "Java"
- "Aspose.Slides"
description: "สร้างและปรับแต่งแผนภูมิในพรีเซนเทชัน PowerPoint ด้วย Aspose.Slides for Python via Java เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานได้จริงใน Python."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำครบถ้วนเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for Python via Java คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยอัตโนมัติ เติมข้อมูลลงในแผนภูมิ และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ Throughout the article, detailed code examples illustrate each step, from initializing the presentation and chart object to configuring series, axes, and legends. By following this guide, you'll gain a solid understanding of how to integrate dynamic chart generation into your Python applications, streamlining the process of creating data‑driven presentations.

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้รับแนวคิดที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

โดยใช้แผนภูมิ คุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากบนสไลด์เดียวในงานนำเสนอ;
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล;
* สรุปแนวทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ;
* พบค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีความหมาย;
* สื่อสารหรือแสดงข้อมูลซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งให้เทมเพลตสำหรับออกแบบแผนภูมิต่าง ๆ ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (อิงตามประเภทแผนภูมิยอดนิยม) และแผนภูมิกำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ในแพ็กเกจ [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพื่อสร้างแผนภูมิคอลัมน์แบบกลุ่มที่เปรียบเทียบสองชุดข้อมูลในสามหมวดหมู่ ชุดข้อมูลใช้สีเติมแดงและสีเขียว และป้ายกำกับแต่ละรายการแสดงชื่อหมวด, ชื่อชุดข้อมูล, และค่า ดัชนี worksheet 0 หมายถึงแผ่นแรกใน workbook ของแผนภูมิที่ฝังอยู่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().get_Item(0)

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    series = chart.getChartData().getSeries().get_Item(1)

    value_cell = workbook.getCell(worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    series.getFormat().getFill().getSolidFillColor().setColor(color)

    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิคอลัมน์แบบกลุ่ม](clustered_column_chart.png)

### **สร้างแผนภูมิกระจาย**

แผนภูมิกระจาย (หรือ scatter plot, x‑y graph) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิกระจายเมื่อ:

* คุณมีข้อมูลตัวเลขเป็นคู่
* มีสองตัวแปรที่จับคู่กันได้ดี
* ต้องการตรวจสอบว่าตัวแปรทั้งสองมีความสัมพันธ์หรือไม่
* มีตัวแปรอิสระที่มีค่าหลายค่าเพื่อกำหนดค่าให้กับตัวแปรตาม

ตัวอย่างนี้พล็อตค่าคู่ x‑y สองชุด ชุดแรกใช้เส้นตรงพร้อมสัญลักษณ์ดาว, ชุดที่สองใช้เส้นโค้งพร้อมสัญลักษณ์วงกลม; ทั้งสองใช้ขนาดสัญลักษณ์ 10, กำหนดด้วย [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize). วิธี [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol) ควบคุมรูปแบบสัญลักษณ์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()

    series_name_cell = workbook.getCell(worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    x_value_cell = workbook.getCell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.getCell(worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.getCell(worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    series = chart.getChartData().getSeries().get_Item(1)

    x_value_cell = workbook.getCell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.getCell(worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.getCell(worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิกระจาย](scatter_chart.png)

### **สร้างแผนภูมิวงกลม**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูลโดยเฉพาะเมื่อข้อมูลมีป้ายหมวดพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีส่วนหรือป้ายจำนวนมาก ควรพิจารณาใช้แผนภูมิแท่งแทน

ตัวอย่างนี้สร้างแผนภูมิวงกลมที่มีค่าครึ่งปีสามค่า แต่ละสไลซ์มีสีเติมและเส้นขอบกำหนดเอง และป้ายแสดงการผสมค่าต่าง ๆ, เปอร์เซ็นต์, และข้อมูลชุด การเรียกใช้ [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle) ตั้งให้สไลซ์แรกเริ่มที่ 180 องศา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    category_cell = workbook.getCell(0, 1, 0, "1st Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    first_slice = series.getDataPoints().get_Item(0)
    first_slice.getFormat().getFill().setFillType(FillType.Solid)
    first_slice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    first_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    first_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    first_slice.getFormat().getLine().setWidth(3.0)
    first_slice.getFormat().getLine().setStyle(LineStyle.ThinThick)
    first_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash)

    second_slice = series.getDataPoints().get_Item(1)
    second_slice.getFormat().setFillType(FillType.Solid)
    color = Color(165, 42, 42)
    second_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    second_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_slice.getFormat().getLine().setWidth(3.0)
    second_slice.getFormat().getLine().setStyle(LineStyle.Single)
    second_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_slice = series.getDataPoints().get_Item(2)
    third_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(255, 127, 80)
    third_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    third_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_slice.getFormat().getLine().setWidth(2.0)
    third_slice.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    presentation.save("PieChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิวงกลม](pie_chart.png)

เพื่อปรับปรุงความอ่านได้ของป้ายที่อยู่ด้านนอกวงกลม ดูตัวอย่าง [Format Leader Lines](/slides/th/python-java/chart-data-label/#format-leader-lines) ที่แสดงวิธีจัดตำแหน่งป้ายและปรับสี, ความกว้าง, ความโปร่งใส, และสไตล์ของเส้นเชื่อม

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือ line graph) เหมาะสำหรับแสดงการเปลี่ยนแปลงของค่าตามเวลา ด้วยแผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในชุดข้อมูล, ฯลฯ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพื่อสร้างแผนภูมิเส้นด้วยชุดข้อมูลและหมวดหมู่เริ่มต้น แล้วบันทึกเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยจุดประสาน (dash) ให้เรียก [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) พร้อมค่าจาก [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิเส้น](line_chart.png)

### **สร้างแผนภูมิโทรไม้**

แผนภูมิโทรไม้เหมาะกับข้อมูลยอดขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้มีส่วนร่วมใหญ่ในแต่ละหมวด

ตัวอย่างนี้สร้างแผนภูมิโทรไม้ที่มีใบแปดใบจัดเป็นสี่กิ่งและสองกิ่งย่อย วิธี [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) กำหนดสเต็มที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ค่าใช้กำหนดขนาดสี่เหลี่ยมสัมพัทธ์, ป้ายหมวดและป้ายพาเรนต์ที่ซ้อนกันระบุโครงสร้างชั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # สาขา 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # สาขา 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิโทรไม้](treemap_chart.png)

### **สร้างแผนภูมิน้ำตก**

แผนภูมิน้ำตกแสดงว่าการเปลี่ยนแปลงบวกและลบมีส่วนทำให้ค่าท้ายสุดเป็นเช่นไร ตัวอย่างเช่น การสรุปกำไรอาจเริ่มจากรายได้, ลบต้นทุน, แล้วบวกรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงลอยระหว่างค่าก่อนหน้าและค่าที่ใหม่, ส่วนคอลัมน์รวมขยายจากศูนย์ถึงค่าที่สะสม

ตัวอย่างต่อไปนี้ใช้จำนวนหน่วยเป็นพันดอลลาร์สหรัฐ:

| หมวดหมู่ | ค่าหนังสือทำงาน | ประเภทคอลัมน์ |
| --- | ---: | --- |
| รายได้ | 1000 | เพิ่ม |
| ต้นทุนการขาย | -400 | ลด |
| กำไรขั้นต้น | 600 | ผลรวมชั่วคราว |
| ค่าใช้จ่ายดำเนินการ | -200 | ลด |
| รายได้อื่น | 50 | เพิ่ม |
| กำไรสุทธิ | 450 | ผลรวมสุดท้าย |

เพื่อทำเครื่องหมายจุดว่าเป็นผลรวมชั่วคราวหรือผลรวมสุดท้าย ให้เรียกวิธี [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal) ของจุดนั้นด้วย `True`. ใส่จำนวนที่สะสมจริงในเซลล์ workbook ของจุดนั้น: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`). วิธีนี้ทำเครื่องหมายคอลัมน์ว่าเป็นผลรวม; มันไม่คำนวณหรือเติมค่าในเซลล์ อย่าใช้ศูนย์เป็นตัวแทนหรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดผลรวม คอลัมน์ผลรวมแสดงค่าที่สะสมโดยไม่เพิ่มค่าดังกล่าวอีกครั้ง

ตัวอย่าง Python ฉบับเต็มนี้สร้างแผนภูมิโดยใช้สมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/), ลบข้อมูลเริ่มต้น, แล้วเติม workbook ที่ฝังอยู่ ดัชนี worksheet `0` เลือก worksheet แรก; คอลัมน์ A มีชื่อหมวด, คอลัมน์ B มีค่า แต่ละเซลล์ค่าถูกเพิ่มด้วย [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries). ดัชนีจุดที่เริ่มจากศูนย์ `2` และ `5` ระบุผลรวมชั่วคราวและผลรวมสุดท้าย การเรียก [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) ด้วย `True` แสดงจำนวนบนคอลัมน์ ไม่ต้องมี presentation หรือ workbook เข้าใจ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)")
    chart.getChartTitle().setOverlay(False)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Profit")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Waterfall)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, categories[i])
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(worksheet_index, i + 1, 1, values[i])
        series.getDataPoints().addDataPointForWaterfallSeries(value_cell)

    # จุดที่สามและหกเป็นผลรวม, ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
    series.getDataPoints().get_Item(2).setSetAsTotal(True)
    series.getDataPoints().get_Item(5).setSetAsTotal(True)
    series.setShowConnectorLines(True)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เรียกวิธีระดับชุดข้อมูล [setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines) ด้วย `True` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่องและทำให้ค่าที่สะสมตามลำดับง่ายต่อการติดตาม หากต้องการซ่อนเส้นเหล่านี้ ให้แทนที่การเรียกวิธีในตัวอย่างด้วย `series.setShowConnectorLines(False)` ก่อนบันทึก วิธีนี้จะเปลี่ยนการมองเห็นของเส้นเท่านั้น ไม่กระทบต่อข้อมูลหรือผลรวม

presentation ที่บันทึกแสดงกำไรขั้นต้น 600 และกำไรสุทธิ 450, ทั้งสองผลรวมเริ่มจากศูนย์:

![แผนภูมิน้ำตกที่แสดงรายได้, ค่าใช้จ่าย, กำไรขั้นต้น 600, และกำไรสุทธิ 450, พร้อมป้ายค่าและเส้นเชื่อม](waterfall_chart.png)

### **สร้างแผนภูมิเชียร์**

แผนภูมิเชียร์ใช้เพื่อแสดงข้อมูลการเงินเช่น ราคาเปิด, สูงสุด, ต่ำสุด, ปิด, ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลเชิงลึกสำคัญต่อการแสดงผลหุ้น ช่วยนักลงทุนและนักวิเคราะห์ตัดสินใจอย่างมีข้อมูล

ตัวอย่างนี้สร้างแผนภูมิเปิด‑สูง‑ต่ำ‑ปิดที่มีสี่ชุดข้อมูลตามลำดับและสามหมวด วิธี [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars) เปิดใช้งานแถบขึ้น/ลง, และ [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) ควบคุมเส้นสูง‑ต่ำที่แสดงช่วงราคา, ส่วนเส้นและเส้นกริดแนวนอนย่อยของชุดข้อมูลแต่ละชุดถูกซ่อน

ผู้จัดการที่ได้จาก [getUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getUpDownBars) เปิดเผยออบเจกต์การจัดรูปแบบแยกด้วย [getUpBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getUpBarsFormat) และ [getDownBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getDownBarsFormat). ใช้ [getFill](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getFill) และ [getLine](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getLine) ของแต่ละออบเจกต์เพื่อกำหนดสีเติมและขอบแยกกัน ตัวอย่างนี้ใช้แถบสีเขียวพร้อมขอบสีเขียวเข้มสำหรับช่วงที่ขึ้น, และแถบสีส้ม‑แดงพร้อมขอบสีแดงเข้มสำหรับช่วงที่ลง

กำหนดค่าตัวเลขให้ทุกชุดสี่ชุดที่แต่ละหมวด, โดยสูง‑ต่ำรวมเปิด‑ปิด ชุดข้อมูลเปรียบเทียบปิดกับเปิด **ภายในหมวดเดียวกัน**, ไม่ใช่กับหมวดก่อนหน้า: A ลดจาก 72 เป็น 25, ขณะที่ B เพิ่มจาก 25 เป็น 38 และ C เพิ่มจาก 38 เป็น 50. ค่าเปิด‑ปิดเท่ากันไม่มีช่วงที่เติมสีแสดงขึ้น แถบขึ้น/ลงครอบคลุมช่วงเปิด‑ปิด; เส้นสูง‑ต่ำครอบคลุมช่วงต่ำ‑สูง. แถบเหล่านี้เป็นส่วนของกลุ่มชุดข้อมูลและไม่ใช่ชุดข้อมูลแผนภูมิแท่งปกติ

การจัดรูปแบบนี้ยังใช้ได้กับแผนภูมิ [Line and LineWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ที่มีอย่างน้อยสองชุดในกลุ่มเดียวกันและค่าตัวเลขที่สอดคล้องกันสำหรับแต่ละหมวด สำหรับแผนภูมิเส้นที่ไม่ซ้อนกัน, แถบขึ้น/ลงจะเปรียบเทียบชุดแรกและชุดสุดท้าย: ค่าที่สูงกว่าในชุดสุดท้ายทำให้เกิดแถบขึ้น, ค่าที่ต่ำกว่าในชุดสุดท้ายทำให้เกิดแถบลง การสลับชุดเหล่านี้จะสลับการจัดประเภท ตัวอย่างด้านล่างใช้ [OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/); อย่าสมมติว่าชนิดหุ้น, เส้น‑ซ้อน‑เส้น, หรือ 3D อื่น ๆ ใช้การจัดเรียงข้อมูลหรือการตีความช่วงเดียวกัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, False)

    workbook = chart.getChartData().getChartDataWorkbook()

    category_cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)

    series = chart.getChartData().getSeries().get_Item(0)
    value_cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(1)
    value_cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(2)
    value_cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(3)
    value_cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    up_down_bars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars()
    up_down_bars.setUpDownBars(True)

    up_down_bars.getUpBarsFormat().getFill().setFillType(FillType.Solid)
    up_fill_color = Color(50, 205, 50)
    up_down_bars.getUpBarsFormat().getFill().getSolidFillColor().setColor(up_fill_color)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    up_line_color = Color(0, 100, 0)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(up_line_color)
    up_down_bars.getUpBarsFormat().getLine().setWidth(2)

    up_down_bars.getDownBarsFormat().getFill().setFillType(FillType.Solid)
    down_fill_color = Color(255, 69, 0)
    up_down_bars.getDownBarsFormat().getFill().getSolidFillColor().setColor(down_fill_color)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    down_line_color = Color(139, 0, 0)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(down_line_color)
    up_down_bars.getDownBarsFormat().getLine().setWidth(2)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์ที่ส่งออกจาก PowerPoint:

![แผนภูมิหุ้นที่มีช่วงสีส้ม‑แดงลงสำหรับ A และช่วงสีเขียวขึ้นสำหรับ B และ C](stock_chart.png)

### **สร้างแผนภูมิกล่องและวิสเกอร์**

แผนภูมิกล่องและวิสเกอร์ใช้เพื่อแสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติหลัก เช่น ค่ากลาง, ควอร์ไทล์, และค่าผิดปกติ เหมาะกับการวิเคราะห์ข้อมูลเชิงสำรวจและการศึกษาเชิงสถิติเพื่อเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติได้อย่างรวดเร็ว

ตัวอย่างนี้สร้างแผนภูมิกล่องและวิสเกอร์จากหกค่า วิธี [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod) เลือกการคำนวณควอร์ไทล์แบบ exclusive ตัวอย่างยังเปิดใช้งานเส้นค่าเฉเฉ, สัญลักษณ์ค่าเฉเฉ, จุดภายใน, และจุดผิดปกติ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    value_cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิฟันเนล**

แผนภูมิกระบวนการใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยปริมาณข้อมูลลดลงเมื่อดำเนินการจากขั้นตอนหนึ่งไปยังขั้นตอนต่อไป เหมาะกับการวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพิ่มแผนภูมิกระบวนการลงในสไลด์แรกของพรีเซนเทชันที่มีอยู่ แทนที่ข้อมูลเริ่มต้นด้วยหกหมวดและค่าตั้งแต่ 50 ถึง 500 แล้วบันทึกพรีเซนเทชันที่อัปเดต พรีเซนเทชันต้นฉบับต้องมีสไลด์อย่างน้อยหนึ่งสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    value_cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิกระบวนการ](funnel_chart.png)

### **สร้างแผนภูมิซันเบิร์สท์**

แผนภูมซันเบิร์สท์ใช้เพื่อแสดงข้อมูลเชิงลำดับชั้น โดยระดับต่าง ๆ แสดงเป็นวงกลมรุ่นซ้อน ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะกับการแสดงหมวดหมู่และหมวดย่อยที่ซ้อนกันในรูปแบบกระชับและชัดเจน

ตัวอย่างนี้สร้างแผนภูมิดวงซันเบิร์สท์ที่มีแปดใบจัดเป็นสี่กิ่งและสองกิ่งย่อย วิธี [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) กำหนดสเต็มที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ป้ายหมวดระบุส่วนต่าง ๆ, ค่ากำหนดขนาดสัมพัทธ์ของแต่ละส่วน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # สาขา 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # สาขา 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิดวงซันเบิร์สท์](sunburst_chart.png)

### **สร้างแผนภูมิเฮิสโตแกรม**

แผนภูมิฮิสโตแกรมแสดงการกระจายของค่าเชิงตัวเลขตามช่วง (bins) สำหรับรายงานเดือนเกี่ยวกับระยะเวลาการประมวลผลคำสั่ง ให้ใช้ความกว้าง bin และเกณฑ์เดียวกันเพื่อให้ช่วงสม่ำเสมอและทำให้การเปรียบเทียบการกระจายง่ายขึ้น

เรียก [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) บนแกนแนวนอนด้วยโหมดจาก [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) ใช้ได้เฉพาะกับ `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) ใช้ได้เฉพาะกับ `ByNumberOfBins`. ใช้ `Automatic` เพื่อให้แผนภูมิตัดสินใจเลือก bin เอง

#### **ใช้ความกว้าง Bin คงที่**

ตัวอย่างนี้จัดกลุ่มระยะเวลาการประมวลผลเป็นช่วง 10 นาที, โดยมี bin แยกสำหรับเวลาน้อยกว่าหรือเท่ากับ 10 นาทีและช่วงที่มากกว่า 40 นาที เปิดใช้งาน bin เหล่านี้ด้วย [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) และ [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin). เมื่อกำหนดเกณฑ์ชัดเจนผ่าน [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) และ [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin), เรียก [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) และ [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) ด้วย `False`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByBinWidth)
    axis.setBinWidth(10.0)
    axis.setUnderflowBin(True)
    axis.setAutomaticUnderflowBin(False)
    axis.setUnderflowBin(10.0)
    axis.setOverflowBin(True)
    axis.setAutomaticOverflowBin(False)
    axis.setOverflowBin(40.0)

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

พรีเซนเทชันที่แสดงใน PowerPoint มีจำนวน bin **3, 4, 4, 4, และ 2**. bin underflow มีค่า `5, 10, 10` ดังนั้นเกณฑ์เป็น inclusive. bin overflow มีค่า `41, 50` ดังนั้นเกณฑ์เป็น exclusive; ค่าที่เท่ากับ `40` อยู่ในช่วงก่อนหน้า. bin ภายในมีค่ามากกว่าขอบล่างและไม่เกินขอบบน

![ฮิสโตแกรมที่มี bin 10‑นาทีและเกณฑ์ underflow/overflow ชัดเจน](histogram_bin_width.png)

#### **ระบุจำนวน Bin**

สำหรับระดับรายละเอียดคงที่แทนการกำหนดช่วงคงที่ ให้ขอ 5 bin สำหรับข้อมูลเดียวกัน ตัวอย่างนี้ปิด bin underflow และ overflow แผนภูมิคำนวณความกว้างจากช่วงข้อมูล ดังนั้นขอบอาจเปลี่ยนระหว่างรายงาน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins)
    axis.setNumberOfBins(5)

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ห้ bin มีจำนวน **4, 4, 4, 4, และ 1**. เปรียบเทียบการกระจายนี้กับผลลัพธ์ความกว้างคงที่ด้านบน: ค่าอินพุตเหมือนกันแต่ขอบแตกต่างกัน

![ฮิสโตแกรมที่คำนวณจากข้อมูลเดียวกันเป็น 5 bin](histogram_bin_count.png)

### **สร้างแผนภูมิโรบิน**

แผนภูมิโรบินใช้เพื่อแสดงข้อมูลหลายมิติในรูปแบบสองมิติ ช่วยเปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย เหมาะกับการระบุรูปแบบ, จุดแข็ง, จุดอ่อนในเมตริกหรือคุณลักษณะประสิทธิภาพหลาย ๆ อย่าง

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพื่อสร้างแผนภูมิโรบินด้วยชุดและหมวดเริ่มต้น แล้วบันทึกเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    slide.getShapes().addChart(ChartType.Radar, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิโรบิน](radar_chart.png)

### **สร้างแผนภูมิหลายหมวด**

แผนภูมิมัลติเค็กคาตอรีใช้เพื่อแสดงข้อมูลที่มีการจัดกลุ่มหลายระดับ ช่วยเปรียบเทียบค่าในหลายมิติพร้อมกัน เหมาะกับการวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลหลายชั้น

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีแปดหมวดจัดเป็นสี่คู่ วิธี [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) ให้แต่ละคู่มีป้ายชื่อร่วมที่ระดับการจัดกลุ่ม 1 ผลที่ได้คือแกนหมวดที่มีทั้งป้ายรายบุคคลและป้ายกลุ่ม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    category_cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    category_cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    category_cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    category_cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    value_cell = workbook.getCell(worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิหลายหมวด](multi_category_chart.png)

#### **ลบป้ายไตรมาส**

ดาวน์โหลด [quarters.pptx](quarters.pptx) และวางไว้ในโฟลเดอร์ทำงาน แผนภูมิในไฟล์นี้แสดงเก้เดือนและชุดขายหนึ่งชุดค่าตั้งแต่ 10 ถึง 18 บนแกนหมวด Q1 ครอบคลุมเดือนมกราคม‑มีนาคม, Q2 ครอบคลุมเดือนเมษายน‑มิถุนายน, Q3 ครอบคลุมเดือนกรกฎาคม‑กันยายน

เดือนเมษายนคือหมวดที่สี่ (ดัชนี 3) และมีป้าย Q2 ใช้วิธี [getGroupingLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getGroupingLevels) เพื่อเข้าถึงระดับการจัดกลุ่มของเมษายน, จากนั้นเรียก [deleteGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#deleteGroupingItem) ด้วยระดับ 1 เพื่อลบป้ายไตรมาส ระดับ 0 แสดงเดือนเองและไม่สามารถลบได้ด้วยวิธีนี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("quarters.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    april = chart.getChartData().getCategories().get_Item(3)
    april.getGroupingLevels().deleteGroupingItem(1)

    presentation.save("quarters-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened = Presentation("quarters-updated.pptx")
try:
    chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
    data = chart.getChartData()
    
    points = data.getSeries().get_Item(0).getDataPoints()
    print(", ".join(str(month.getAsCell().getValue()) for month in data.getCategories()))
    print(", ".join(str(point.getValue().getData()) for point in points))
finally:
    reopened.dispose()
```

หลังเปิดแผนภูมิใหม่ ตัวอย่างจะแสดงเดือนเดิม (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) และค่าขาย (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) ตามลำดับเดียวกัน เปิดไฟล์ `quarters-updated.pptx` ใน PowerPoint เพื่อตรวจสอบป้ายแกน ป้าย Q2 และขอบกลุ่มก่อนเมษายนหายไป ดังนั้น Q1 ครอบคลุมเดือนมกราคม‑มิถุนายน Q3 ยังคงเริ่มในเดือนกรกฎาคม

![เปรียบเทียบป้ายไตรมาสก่อนและหลังการลบ. ด้านซ้าย Q2 ครอบคลุมเดือนเมษายน‑มิถุนายน. ด้านขวา Q1 ครอบคลุมเดือนมกราคม‑มิถุนายน.](quarter-label-comparison.png)

### **สร้างแผนภูมิเพิ่มแผนที่**

แผนภูมิเพิ่มแผนที่ใช้เพื่อแสดงข้อมูลเชิงภูมิศาสตร์โดยแมปข้อมูลไปยังตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง เหมาะกับการวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพื่อสร้างแผนภูมิเพิ่มแผนที่ด้วยข้อมูลภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![แผนภูมิเพิ่มแผนที่](map_chart.png)

{{% alert color="info" title="Note" %}}
รูปด้านบนแสดงพรีเซนเทชันที่บันทึกแล้วเปิดใน PowerPoint. Aspose.Slides เขียนข้อมูลแผนภูมิแผนที่และข้อมูลได้อย่างถูกต้อง, แต่ไม่วาดแผนภูมิแผนที่เอง: เมื่อสไลด์ที่มีแผนภูมิดังกล่าวเรนเดอร์เป็นรูปภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะว่างเปล่า รูปร่างอื่นบนสไลด์เดียวกันไม่มีผลกระทบ
{{% /alert %}}

### **สร้างแผนภูมิคอมบิเนชั่น**

แผนภูมิคอมบิเนชั่น (หรือ combo chart) ผสมสองหรือหลายประเภทแผนภูมิในกราฟเดียว แผนภูมินี้ช่วยให้คุณไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลสองชุดหรือมากกว่า, ช่วยระบุความสัมพันธ์ระหว่างข้อมูลเหล่านั้น

![แผนภูมิคอมบิเนชั่น](combination_chart.png)

ตัวอย่างนี้ผสมสองชุดคอลัมน์แบบกลุ่มกับชุดเส้นหนึ่งชุดในสี่หมวด คอลัมน์ใช้แกนแนวตั้งหลัก, ส่วน [setPlotOnSecondAxis](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setPlotOnSecondAxis) วางเส้นบนแกนแนวตั้งรองด้านขวา ฟังก์ชันช่วยตั้งค่าชื่อ, ตำนาน, ป้ายแกน, และเส้นตาราง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # ตั้งชื่อหัวเรื่องแผนภูมิ.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # ตั้งค่าตำนานแผนภูมิ.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # ลบชุดข้อมูลและหมวดหมู่ที่สร้างโดยอัตโนมัติ.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # เพิ่มหมวดหมู่ใหม่.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # เพิ่มชุดข้อมูลแรก.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # ตั้งค่ากราฟแกนแนวนอน.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # ตั้งค่ากราฟแกนแนวดิ่ง.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # ตั้งค่าสีเส้นกริดหลักของแกนแนวดิ่ง.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # ตั้งค่าแกนแนวนอนรอง.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # ตั้งค่าแกนแนวดิ่งรอง.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **อัปเดตแผนภูมิ**

Aspose.Slides for Python via Java ช่วยให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ สิ่งนี้ทำให้การรักษาพรีเซนเทชันให้ทันสมัยด้วยเนื้อหาไดนามิกและทำให้แผนภูมิสะท้อนข้อมูลและมาตรฐานภาพลักษณ์ในปัจจุบันได้อย่างง่ายดาย

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ "My chart" บนสไลด์แรกของพรีเซนเทชันที่มีอยู่ ต้องมีสองชุดคอลัมน์แต่ละชุดมีสามจุดข้อมูล, ป้ายหมวดอยู่ในคอลัมน์ A และชื่อชุดอยู่ในแถวแรกของ worksheet แรก ตัวอย่างใช้ [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) เพื่อเปลี่ยนเซลล์ workbook, อัปเดตค่าชุดข้อมูล, เพิ่มชุดที่สาม, และเปลี่ยนประเภทแผนภูมิเป็น cylinder แบบกลุ่มผ่าน [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartType, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            worksheet_index = 0

            workbook = chart.getChartData().getChartDataWorkbook()

            workbook.getCell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.getCell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.getChartData().getSeries().get_Item(0)

            workbook.getCell(worksheet_index, 0, 1, "New_Series 1")
            series.getDataPoints().get_Item(0).getValue().setData(90)
            series.getDataPoints().get_Item(1).getValue().setData(123)
            series.getDataPoints().get_Item(2).getValue().setData(44)

            series = chart.getChartData().getSeries().get_Item(1)

            workbook.getCell(worksheet_index, 0, 2, "New_Series 2")
            series.getDataPoints().get_Item(0).getValue().setData(23)
            series.getDataPoints().get_Item(1).getValue().setData(67)
            series.getDataPoints().get_Item(2).getValue().setData(99)

            series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
            series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

            value_cell = workbook.getCell(worksheet_index, 1, 3, 20)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 2, 3, 50)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 3, 3, 30)
            series.getDataPoints().addDataPointForBarSeries(value_cell)

            chart.setType(ChartType.ClusteredCylinder)

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงที่แผนภูมิที่มีอยู่ใช้แล้ว, ดู [Retrieve a Chart's Data Range](/slides/th/python-java/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides for Python via Java ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจาก worksheet เป็นแหล่งข้อมูลของแผนภูมิของคุณ ซึ่งหมายความว่าคุณสามารถแมปส่วนของ worksheet ไปยังแผนภูมิได้โดยตรง, ควบคุมเซลล์ใดบ้างที่เข้าสู่ชุดและหมวดของแผนภูมิ ผลลัพธ์คือคุณสามารถอัปเดตและซิงค์แผนภูมิของคุณกับการเปลี่ยนแปลงข้อมูลล่าสุดใน worksheet ได้อย่างง่ายดาย, ทำให้พรีเซนเทชัน PowerPoint ของคุณแสดงข้อมูลที่เป็นปัจจุบันและแม่นยำ

ตัวอย่างนี้ใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อกำหนดแหล่งข้อมูลของแผนภูมิชื่อ "My chart" บนสไลด์แรกของพรีเซนเทชันที่มีอยู่เป็น `Sheet1!A1:B4`. workbook ของแผนภูมิจะต้องมี worksheet ดังกล่าวและช่วงที่เต็มด้วยหัวข้อชุดในแถวแรก, ป้ายหมวดในคอลัมน์ A, และสามค่าในคอลัมน์ B

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้มาร์คเกอร์เริ่มต้นในแผนภูมิ**

เมื่อใช้มาร์คเกอร์เริ่มต้นในแผนภูมิ, แต่ละชุดข้อมูลจะได้รับสัญลักษณ์มาร์คเกอร์เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) เพื่อสร้างแผนภูมิกับสองชุดเส้นและตำนาน การตั้งค่ามาร์คเกอร์ที่เข้าถึงผ่าน [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) รักษาสัญลักษณ์มาร์คเกอร์ที่กำหนดอัตโนมัติ ชุดแรกมีค่าลบและค่าหาย (`None`), ชุดที่สองมีค่าตลอดทุกหมวด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    series_name_cell = workbook.getCell(0, 0, 2, "Series 2")
    second_series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่ Aspose.Slides for Python via Java รองรับ?**

Aspose.Slides for Python via Java รองรับแผนภูมิหลายประเภท รวมถึง bar, line, pie, area, scatter, histogram, radar, และอื่น ๆ มากมาย ความยืดหยุ่นนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงผลข้อมูลของคุณได้

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ, คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ก่อน, ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, จากนั้นเรียกเมธอดเพื่อเพิ่มแผนภูมิ, ระบุประเภทแผนภูมิและข้อมูลเริ่มต้น วิธีนี้ทำให้แผนภูมิเข้าร่วมในพรีเซนเทชันของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)), ลบชุดและหมวดเริ่มต้นทั้งหมด, แล้วเพิ่มข้อมูลที่กำหนดเอง วิธีนี้ช่วยให้คุณรีเฟรชแผนภูมิโดยโปรแกรมให้แสดงข้อมูลล่าสุดได้

**สามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for Python via Java ให้ตัวเลือกการปรับแต่งที่หลากหลาย คุณสามารถเปลี่ยนสี, ฟอนต์, ป้าย, ตำนาน, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงตามข้อกำหนดการออกแบบของคุณได้อย่างเต็มที่.