---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ด้วย Python
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/python-java/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิกลม
- แผนภูมิเส้น
- แผนภูมิต้นไม้
- แผนภูมิสต็อก
- แผนภูมิกล่องและวิสเกอร์
- แผนภูมน้ำพุ
- แผนภูมิดวงอาทิตย์
- แผนภูมิฮิสโตแกรม
- แผนภูมิเรดาร์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานได้จริงใน Python."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม, เติมข้อมูลเข้าไป, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ ให้ตรงกับความต้องการออกแบบของคุณ ตลอดบทความจะมีตัวอย่างโค้ดที่ละเอียดแสดงขั้นตอนแต่ละขั้น ตั้งแต่การเริ่มต้นวัตถุ Presentation และแผนภูมิ ไปจนถึงการกำหนด series, axes, และ legends ด้วยการทำตามคู่มือนี้ คุณจะเข้าใจการผสานการสร้างแผนภูมิกระจายแบบไดนามิกเข้าในแอปพลิเคชันของคุณ, ทำให้การสร้างงานนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและได้ข้อสรุปที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ด้วยแผนภูมิ คุณสามารถ:

* รวม, ยุบ, หรือสรุปข้อมูลจำนวนมากในสไลด์เดียวของการนำเสนอ
* เปิดเผยรูปแบบและแนวโน้มในข้อมูล
* สังเกตทิศทางและแรงผลักดันของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ
* พบค่าที่อยู่นอกกรอบ, ความผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, ข้อมูลที่ไม่มีเหตุผล ฯลฯ
* ถ่ายทอดหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านเมนู *Insert* ซึ่งมีเทมเพลตให้ออกแบบหลายประเภทของแผนภูมิได้โดยง่าย โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิที่นิยม) หรือแผนภูมิกำหนดเองได้

{{% alert color="info" title="Note" %}}
เพื่อสร้างแผนภูมิ ให้ใช้คลาส [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) ฟิลด์ในคลาสนี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ส่วนนี้อธิบายวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่มด้วย Aspose.Slides คุณจะได้เรียนรู้การเริ่มต้น Presentation, เพิ่มแผนภูมิ, และปรับแต่งส่วนต่าง ๆ เช่น ชื่อ, ข้อมูล, series, categories, และสไตล์ ทำตามขั้นตอนด้านล่างเพื่อดูวิธีที่แผนภูมิคอลัมน์แบบกลุ่มมาตรฐานถูกสร้างขึ้น:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation)  
1. ดึงอ้างอิงสไลด์ตามดัชนี  
1. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและระบุประเภท `ChartType.ClusteredColumn`  
1. เพิ่มชื่อให้กับแผนภูมิ  
1. เข้าถึง worksheet ของข้อมูลแผนภูมิ  
1. ลบ series และ categories เริ่มต้นทั้งหมด  
1. เพิ่ม series และ categories ใหม่  
1. เพิ่มข้อมูลแผนภูมิใหม่ให้กับ series  
1. ตั้งค่าสีเติมให้กับ series  
1. เพิ่มป้ายกำกับให้กับ series  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด C# นี้สาธิตวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่ม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# สร้างอินสแตนซ์ของคลาส presentation ที่แสดงไฟล์ PPTX
presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # ตั้งค่าชื่อแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # ตั้งค่าดัชนีสำหรับชีตข้อมูลของแผนภูมิ
    default_worksheet_index = 0

    # ดึง WorkSheet ข้อมูลแผนภูมิ
    workbook = chart.getChartData().getChartDataWorkbook()

    # ลบ series และ categories ที่สร้างโดยอัตโนมัติ
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # เพิ่ม series ใหม่
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # เพิ่ม categories ใหม่
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # ดึง series แผนภูมิแรก
    series = chart.getChartData().getSeries().get_Item(0)

    # ตอนนี้เติมข้อมูลให้ series
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # ตั้งค่าสีเติมสำหรับ series
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # ดึง series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1)

    # เติมข้อมูลให้ series
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # ตั้งค่าสีเติมสำหรับ series
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Create custom labels for each categories for the new series
    # ตั้งค่าป้ายแรกให้แสดงชื่อหมวดหมู่
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # แสดงค่าให้กับป้ายที่สาม
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # บันทึกการนำเสนอพร้อมแผนภูมิ
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิการกระจาย**

แผนภูมิการกระจาย (หรือ scatter plot, กราฟ x‑y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิการกระจายเมื่อ:

* มีข้อมูลเชิงตัวเลขเป็นคู่  
* มีสองตัวแปรที่สัมพันธ์กันดี  
* ต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่  
* มีตัวแปรอิสระที่มีค่าหลายค่าต่อหนึ่งตัวแปรตาม  

1. ทำตามขั้นตอนใน [Create Clustered Column Charts](#create-clustered-column-charts)  
2. สำหรับขั้นตอนที่สาม ให้เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภทแผนภูมิตามรายการต่อไปนี้:  
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Represents a scatter chart._  
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Represents a scatter chart connected by curves, with data markers._  
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Represents a scatter chart connected by curves, without data markers._  
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Represents a scatter chart connected by lines, with data markers._  
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Represents a scatter chart connected by lines, without data markers._

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิการกระจายที่มีมาร์คเกอร์ต่าง ๆ สำหรับแต่ละ series:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส presentation ที่เป็นไฟล์ PPTX
presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # สร้างแผนภูมิโดฟอลต์
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # ดึงดัชนีของ worksheet ข้อมูลแผนภูมิโดฟอลต์
    default_worksheet_index = 0

    # ดึง worksheet ข้อมูลแผนภูมิ
    workbook = chart.getChartData().getChartDataWorkbook()

    # ลบ series ตัวอย่าง
    chart.getChartData().getSeries().clear()

    # เพิ่ม series ใหม่
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # ดึง series แผนภูมิเฉพาะแรก
    series = chart.getChartData().getSeries().get_Item(0)

    # เพิ่มจุดใหม่ (1:3) ให้กับ series
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # เพิ่มจุดใหม่ (2:10)
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # เปลี่ยนประเภทของ series
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # เปลี่ยนมาร์คเกอร์ของ series ในแผนภูมิ
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # ดึง series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1)

    # เพิ่มจุดใหม่ (5:2) ที่นั่น
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # เพิ่มจุดใหม่ (3:1)
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # เพิ่มจุดใหม่ (2:2)
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # เพิ่มจุดใหม่ (5:1)
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # เปลี่ยนมาร์คเกอร์ของ series ในแผนภูมิ
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิวงกลม**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายหมวดหมู่พร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีส่วนหรือป้ายหลายส่วน คุณอาจพิจารณาใช้แผนภูมิแท่งแทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและระบุประเภท [ChartType.Pie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Pie)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)  
5. ลบ series และ categories เริ่มต้น  
6. เพิ่ม series และ categories ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่ให้กับ series  
8. เพิ่มจุดใหม่ให้กับแผนภูมิและกำหนดสีที่กำหนดเองให้กับเซกเมนต์ของแผนภูมิกลม  
9. ตั้งค่าป้ายกำกับสำหรับ series  
10. เปิดใช้งาน leader lines สำหรับป้ายกำกับ series  
11. ตั้งมุมการหมุนสำหรับเซกเมนต์ของแผนภูมิกลม  
12. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิกลม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# สร้างอินสแตนซ์ของคลาส presentation ที่เป็นไฟล์ PPTX
presentation = Presentation()
try:
    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # ตั้งชื่อแผนภูมิ
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # ตั้งค่าดัชนีสำหรับชีตข้อมูลของแผนภูมิ
    default_worksheet_index = 0

    # ดึง worksheet ของข้อมูลแผนภูมิ
    workbook = chart.getChartData().getChartDataWorkbook()

    # ลบ series และ categories ที่สร้างโดยอัตโนมัติ
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # เพิ่ม categories ใหม่
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # เพิ่ม series ใหม่
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    # เติมข้อมูลให้ series
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # เพิ่มจุดใหม่และตั้งค่าสีของเซกเมนต์
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # ตั้งค่าขอบเซกเมนต์
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # ตั้งค่าขอบเซกเมนต์
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # ตั้งค่าขอบเซกเมนต์
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # สร้างป้ายกำหนดเองสำหรับแต่ละหมวดหมู่ของ series ใหม่
    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # แสดง Leader Lines สำหรับแผนภูมิ
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # ตั้งค่ามุมการหมุนสำหรับเซกเมนต์ของแผนภูมิกลม
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # บันทึกการนำเสนอพร้อมแผนภูมิ
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือ line graph) เหมาะกับการแสดงการเปลี่ยนค่าตามเวลา ด้วยแผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติใน series ฯลฯ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
1. ดึงอ้างอิงสไลด์ตามดัชนี  
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและระบุประเภท [ChartType.Line](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Line)  
1. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิเส้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

โดยปกติ จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากคุณต้องการให้จุดเชื่อมต่อด้วยเส้นประ สามารถระบุประเภท dash ที่ต้องการได้ดังนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิต้นไม้ (Tree Map)**

แผนภูมิต้นไม้เหมาะกับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้สนับสนุนหลักในแต่ละหมวด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Treemap](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Treemap)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)  
5. ลบ series และ categories เริ่มต้น  
6. เพิ่ม series และ categories ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่ให้กับ series  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิต้นไม้:

```python
import jpway
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #สาขา 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #สาขา 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิสต็อก**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#OpenHighLowClose)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)  
5. ลบ series และ categories เริ่มต้น  
6. เพิ่ม series และ categories ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่ให้กับ series  
8. ระบุรูปแบบของเส้น high‑low  
9. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิสต็อก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิกล่องกล่อง (Box and Whisker)**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#BoxAndWhisker)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)  
5. ลบ series และ categories เริ่มต้น  
6. เพิ่ม series และ categories ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่ให้กับ series  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิกล่องกล่อง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิน้ำพุ (Funnel)**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Funnel](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Funnel)  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิน้ำพุ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิรัศมี (Sunburst)**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Sunburst](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Sunburst)  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิดวงอาทิตย์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #สาขา 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #สาขา 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิฮิสโตแกรม (Histogram)**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.Histogram](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Histogram)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)  
5. ลบ series และ categories เริ่มต้น  
6. เพิ่ม series และ categories ใหม่  
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิโฮสโตแกรม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมาราดาร์ (Radar)**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภทแผนภูมิที่ต้องการ ([ChartType.Radar](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Radar))  
4. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูม radar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิมัลติเกตเกอรี่ (Multi-Category)**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท [ChartType.ClusteredColumn](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ClusteredColumn)  
4. เข้าถึง workbook ของข้อมูลแผนภูมิ [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)  
5. ลบ series และ categories เริ่มต้น  
6. เพิ่ม series และ categories ใหม่  
7. เพิ่มข้อมูลแผนภูมิใหม่ให้กับ series  
8. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิมัลติเกตเกอรี่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # เพิ่ม Series
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # บันทึกการนำเสนอพร้อมแผนภูมิ
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิแผนที่ (Map)**

แผนภูมิแผนที่ช่วยให้เห็นข้อมูลเชิงภูมิศาสตร์และเปรียบเทียบค่าในแต่ละภูมิภาค

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิแผนที่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างแผนภูมิผสม (Combination)**

แผนภูมิผสม (หรือ combo chart) รวมสองประเภทแผนภูมิหรือมากกว่าลงในกราฟเดียว ทำให้คุณสามารถเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุดได้ง่ายขึ้น

![แผนภูมิผสม](combination_chart.png)

โค้ด Python ด้านล่างแสดงวิธีสร้างแผนภูมผสมตามที่แสดงในรูปด้านบนใน PowerPoint:

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

    # ตั้งชื่อแผนภูมิ.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # ตั้งคำอธิบายแผนภูมิ.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # ลบ series และ categories ที่สร้างโดยอัตโนมัติ.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # เพิ่ม categories ใหม่.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # เพิ่ม series แรก.
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
    # ตั้งแกนแนวนอน.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # ตั้งแกนแนวตั้ง.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # ตั้งค่าสีของเส้นกริดหลักแนวตั้ง.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # ตั้งแกนแนวนอนรอง.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # ตั้งแกนแนวตั้งรอง.
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

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ที่ประกอบด้วยแผนภูมิที่ต้องการอัปเดต  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. วนผ่านรูปทรงทั้งหมดเพื่อหาแผนภูมิที่ต้องการ  
4. เข้าถึง worksheet ของข้อมูลแผนภูมิ  
5. แก้ไข series ของแผนภูมิโดยเปลี่ยนค่าของ series  
6. เพิ่ม series ใหม่และเติมข้อมูลของมัน  
7. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีอัปเดตแผนภูมิ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# เปิดไฟล์ Presentation ที่มีแผนภูมิเพื่อทำการอัปเดต
presentation = Presentation("ExistingChart.pptx")
try:
    # เข้าถึงสไลด์แรก
    slide = presentation.getSlides().get_Item(0)

    # ดึงแผนภูมิจากสไลด์
    chart = slide.getShapes().get_Item(0)

    # ตั้งค่าดัชนีของชีทข้อมูลแผนภูมิ
    default_worksheet_index = 0

    # ดึง worksheet ของข้อมูลแผนภูมิ
    workbook = chart.getChartData().getChartDataWorkbook()

    # เปลี่ยนชื่อ Category ของแผนภูมิ
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # ดึง series แผนภูมิก่อนหน้า
    series = chart.getChartData().getSeries().get_Item(0)

    # ปรับปรุงข้อมูลของ series ในขณะนี้
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# แก้ไขชื่อ series
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # ดึง series แผนภูมิที่สอง
    series = chart.getChartData().getSeries().get_Item(1)

    # ปรับปรุงข้อมูลของ series ในขณะนี้
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# แก้ไขชื่อ series
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # ตอนนี้เพิ่ม series ใหม่
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # ดึง series แผนภูมิที่สาม
    series = chart.getChartData().getSeries().get_Item(2)

    # ตอนนี้เติมข้อมูลให้ series
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # บันทึก Presentation พร้อมแผนภูมิ
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงที่แผนภูมิที่มีอยู่ใช้แล้ว ให้ดูที่ [Retrieve a Chart's Data Range](/slides/th/python-java/chart-workbook/#retrieve-a-charts-data-range)

เพื่อกำหนดช่วงข้อมูลสำหรับแผนภูมิ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ที่เป็น Presentation ที่มีแผนภูมิ  
2. ดึงอ้างอิงสไลด์ตามดัชนี  
3. วนผ่านรูปทรงทั้งหมดเพื่อหาแผนภูมิที่ต้องการ  
4. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วง  
5. บันทึก Presentation ที่แก้ไขเป็นไฟล์ PPTX  

โค้ด Python นี้แสดงวิธีกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# เปิดไฟล์ Presentation ที่มีแผนภูมิ
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้มาร์คเกอร์ค่าเริ่มต้นในแผนภูมิ**

เมื่อใช้มาร์คเกอร์ค่าเริ่มต้นในแผนภูมิ แต่ละ series จะได้สัญลักษณ์มาร์คเกอร์ที่แตกต่างกันโดยอัตโนมัติ

โค้ด Python นี้แสดงวิธีตั้งค่ามาร์คเกอร์ series ของแผนภูมิโดยอัตโนมัติ:

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
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #ดึง series แผนภูมิที่สอง
    second_series = chart.getChartData().getSeries().get_Item(1)

    #กำลังเติมข้อมูลให้ series
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับประเภทแผนภูมิอะไรบ้าง?**

Aspose.Slides รองรับประเภท [chart types](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) จำนวนมาก รวมถึง bar, line, pie, area, scatter, histogram, radar และอื่น ๆ อีกหลายประเภท ความยืดหยุ่นนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับการแสดงข้อมูลของคุณ

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) แล้วดึงสไลด์ที่ต้องการตามดัชนี และเรียกเมธอดเพื่อเพิ่มแผนภูมิ พร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น วิธีนี้จะทำให้แผนภูมิเชื่อมต่อโดยตรงกับ Presentation ของคุณ

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูล ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)) ลบ series และ categories เริ่มต้นที่มีอยู่แล้ว แล้วเพิ่มข้อมูลแบบกำหนดเองของคุณ การทำเช่นนี้จะทำให้แผนภูม reflecting ข้อมูลล่าสุดได้

**สามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides มีตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, legends และส่วนอื่น ๆ ของ [formatting elements](/slides/th/python-java/chart-entities/) เพื่อให้แผนภูมิตรงกับความต้องการออกแบบของคุณ