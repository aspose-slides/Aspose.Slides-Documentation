---
title: "ปรับแต่งแกนของแผนภูมิในงานนำเสนอโดยใช้ Python"
linktitle: "แกนแผนภูมิ"
type: docs
url: /th/python-java/chart-axis/
keywords:
- "แกนแผนภูมิ"
- "แกนแนวตั้ง"
- "แกนแนวนอน"
- "ปรับแต่งแกน"
- "จัดการแกน"
- "ควบคุมแกน"
- "คุณสมบัติของแกน"
- "ค่าสูงสุด"
- "ค่าต่ำสุด"
- "เส้นแกน"
- "รูปแบบวันที่"
- "ชื่อแกน"
- "ตำแหน่งแกน"
- "PowerPoint"
- "งานนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งแกนของแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides สำหรับ Python ผ่าน Java รวมถึงค่าที่คำนวณได้ของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ป้ายชื่อประเภทและระยะห่างของเครื่องหมายติ๊ก วันที่และการจัดรูปแบบ แกนหมุนหัวเรื่อง การกำหนดตำแหน่งแกน หน่วยการแสดงผล และการสเกลแบบลอการิทมิก

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [การนำเสนอ](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่พร้อมข้อมูลเริ่มต้น เรียกใช้ [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้เลย์เอาต์ของแผนภูมิเป็นปัจจุบัน

อ่าน [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) และ [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) เพื่อกำหนดขอบเขตของแกน และ [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) และ [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) เพื่อรับระยะห่างของเครื่องหมายติ๊ก [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) และ [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) ให้สเกลหน่วยเวลา ซึ่งสำคัญกับแกนวันที่ ตัวอย่างจะเก็บค่าต่าง ๆ ไว้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) เพื่อสลับบทบาทของซีรีส์และประเภทในข้อมูลแผนภูมิ ประเภทที่เคยเป็นเดิมจะกลายเป็นซีรีส์ และซีรีส์ที่เคยเป็นเดิมจะกลายเป็นประเภท สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล แต่ไม่สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวเรื่องและคอลัมน์ประเภท ก่อนสลับแถวและคอลัมน์ แล้วบันทึกแผนภูมิที่มีซีรีส์สี่ชุดและประเภทสามชุด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กลับทิศทางการวาดของแกน**

ใช้ [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) เพื่อกลับทิศทางของแกนประเภทหรือค่า ตัวอย่างเช่น แผนภูมิแท่งแนวนอนอาจแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับใน worksheet: Planning, Development, Testing การกลับแกนเปลี่ยนทิศทางการวาด ไม่ได้จัดเรียงหรือย้ายข้อมูลใน workbook การเปรียบเทียบกับ [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) ที่สลับบทบาทของซีรีส์และประเภท

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์ บันทึกงานนำเสนอที่มีสไลด์สามสไลด์: ลำดับปกติ, ประเภทย้อนกลับ, ค่าย้อนกลับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกันและมีการกลับแกนเพียงหนึ่งแกนต่อสำเนา

```python
import jpase
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # สไลด์ 2: แสดงประเภทแรกที่ด้านบน.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # คงแกนค่าตอนแนวนอนไว้ที่ด้านล่าง.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # สไลด์ 3: กลับทิศทางเพียงสเกลเชิงเลขแนวนอน.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การกลับแกนยังสามารถย้ายแกนตั้งฉากไปอีกด้านของพื้นที่แผนภูมิได้ [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) ควบคุมว่าตำแหน่งที่แกนอื่นทำการตัดผ่านแกนที่กำลังกำหนดคือที่ไหน ในสไลด์ที่ 2 การเรียกด้วย [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) บนแกนประเภทที่กลับแล้วทำให้แกนค่าตั้งแนวนอนอยู่ที่ด้านล่าง สำหรับตำแหน่งตัดเฉพาะ ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) ตรวจสอบการตั้งค่าการตัดเมื่อเปลี่ยนทิศทาง โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดกำหนดเองแล้ว เรียก [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) ด้วย `False` เพื่อคืนทิศทางการวาดปกติ การตั้งค่าการตัดเป็นการตั้งค่าแยกต่างหาก

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่ย้อนกลับ (สไลด์ 2) | ค่าย้อนกลับ (สไลด์ 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| ประเภทวิ่งจากล่างขึ้นบน; ค่ามากขึ้นจากซ้ายไปขวา. | Planning, Development, และ Testing วิ่งจากบนลงล่าง. ค่และลำดับแถวใน workbook ไม่เปลี่ยน. | ประเภทคงลำดับปกติ; ค่ามากขึ้นจากขวาไปซ้าย. แกนประเภทตัดที่ศูนย์ทางขวา. |

## **ซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) ด้วย `False` บนแกนแนวตั้งเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นพร้อมข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวตั้งถูกซ่อน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น**

เรียก [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) ด้วย `False` บนแกนแนวนอนเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นพร้อมข้อมูลเริ่มต้นและบันทึกโดยที่แกนแนวนอนถูกซ่อน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แสดงหรือซ่อนเส้นตารางของแผนภูมิ**

ใช้ [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) และ [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) เพื่อตรวจสอบว่าแกนแสดงเส้นตารางใดบ้าง หากต้องการแสดงเส้นตารางย่อย ให้ใช้ [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) และตั้งการเติมเส้นเป็นสีทึบที่มองเห็นได้ หากต้องการซ่อน ให้ตั้งการเติมเป็น [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill) ใช้ [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) เพื่อเปลี่ยนการเติมเส้นสำหรับเส้นตารางหลักในลักษณะเดียวกัน การเปลี่ยนการเติมจะคงการแสดงแกนและเครื่องหมายติ๊กไว้

แกนแนวตั้งของแผนภูมิคอลัมน์แบบกลุ่มนี้เริ่มต้นจะแสดงเส้นตารางหลักเท่านั้น ตัวอย่างแสดงเส้นตารางย่อยเป็นสีส้มเข้ม แล้วซ่อนอีกครั้งก่อนบันทึกงานนำเสนอ และพิมพ์สถานะการแสดงเส้นตารางในแต่ละขั้นตอน

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

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| เส้นตารางย่อยเปิดใช้งาน | เส้นตารางย่อยซ่อน |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **เปลี่ยนแกนประเภท**

ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) เพื่อเลือกแกนประเภทวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` โดยที่แผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเซลล์ประเภทมีค่าที่เป็นวันที่แบบเลขของ Excel จะเปลี่ยนแกนแนวนอนไปเป็นแกนวันที่ การเรียก [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) ด้วย `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) ด้วย `1` และ [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) ด้วย [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) จะวางเครื่องหมายหลักที่ช่วงเดือนละหนึ่ง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **กำหนดประเภทแกนประเภทจากข้อมูล**

หลังจากใส่ค่าประเภทแล้วเรียก [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) แล้วอ่าน [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) เพื่อตรวจสอบการเลือก วิธีนี้มีประโยชน์เมื่อแผนภูมิเ�เดียวกันอาจรับป้ายข้อความหรือค่าที่เป็นวันที่เป็นตัวเลข วิธีการจะกำหนดประเภทเมื่อเรียกใช้ ไม่ได้เปิดโหมดคงที่ที่ประเมินข้อมูลใหม่ในภายหลัง เรียกอีกครั้งหลังจากเปลี่ยนประเภท

ตัวอย่างต่อไปสร้างแผนภูมิที่มีประเภทข้อความและพิมพ์ `True` เมื่อตรวจพบประเภทเป็น [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text) จากนั้นแทนค่าของเซลล์ประเภทด้วยวันที่และเรียกวิธีอีกครั้ง พิมพ์ `True` เมื่อตรวจพบประเภทเป็น [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) วันที่ถูกเก็บเป็นค่าตัวเลข OLE Automation คิดเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 ไม่ใช่ข้อความวันที่ [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) ควบคุมการแสดงค่าดังกล่าว ไม่ได้แปลงข้อความเป็นวันที่ตัวเลข สำหรับรายละเอียดเกี่ยวกับเซลล์ประเภท ดู [Chart Workbook](/slides/th/python-java/chart-workbook/)

ใช้การกำหนดอัตโนมัติเมื่ออินพุตมีป้ายข้อความหรือวันที่ตัวเลขตามตัวอย่าง สำหรับป้ายตัวเลขปกติ, ประเภทผสม, หรือข้อมูลว่าง ให้เรียก [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) อย่างชัดเจนเพื่อให้ตรงกับความหมายที่ต้องการ ค่าตัวเลขเพียงอย่างเดียวไม่ทำให้บ่งชี้ว่าประเภทเป็นวันที่

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # จริง

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # จริง

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ควบคุมระยะห่างของป้ายแกนประเภท**

เมื่อแผนภูมิมีประเภทจำนวนมาก ให้ลดจำนวนป้ายแกนที่มองเห็นได้โดยไม่ลบประเภทหรือจุดข้อมูล เรียก [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) ด้วย `False` แล้วส่งระยะห่างประเภทที่ต้องการไปยัง [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) สำหรับประเภทข้อความในลำดับปกติ การนับเริ่มจากประเภทแรก:

| ระยะห่าง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

ระยะห่าง `3` จะแสดงป้ายทุกสามรายการโดยให้ป้ายสองรายการซ่อนอยู่ระหว่างที่แสดง ไม่ลบคอลัมน์ที่สอดคล้องกัน การจัดระยะห่างอัตโนมัติจะเลือกระยะห่างตามพื้นที่ที่ใช้ไม่ได้หมายความว่าจะต้องแสดงทุกป้าย

เครื่องหมายติ๊กมีการควบคุมแยกกัน เรียก [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) ด้วย `False` และใช้ [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) เพื่อตั้งระยะห่างของเครื่องหมายติ๊ก ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกระยะห่างของประเภท แม้ว่าป้ายจะแสดงเพียงทุกสามประเภท ใช้ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) พร้อมสไตล์ที่มองเห็นได้เพื่อดูผล การตั้งค่าอัตโนมัติด้วย `True` อีกครั้งจะให้แผนภูมิเ�เลือกระยะห่างใหม่

ตัวอย่างต่อไปนี้สร้างประเภท 24 รายการและซีรีส์หนึ่งชุด แล้วบันทึกสไลด์สามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การจัดระยะห่างอัตโนมัติ, การจัดระยะห่างของป้ายแบบกำหนดเองพร้อมเครื่องหมายติ๊กแยกจากกัน, และการคืนค่าอัตโนมัติสำเนาทั้งสองคงข้อมูลแผนภูมิดั้งเดิม ไม่จำเป็นต้องมีงานนำเข้าก่อนหน้า ข้อความป้ายแนวนอนทำให้ความหนาแน่นที่แตกต่างกันง่ายต่อการมองเห็น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpave.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # สไลด์ 2: แสดงทุกป้ายที่สาม แต่คงเครื่องหมายติ๊กไว้สำหรับทุกประเภท.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # สไลด์ 3: ให้แผนภูมเลือกช่วงทั้งสองอีกครั้ง.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**การจัดระยะห่างอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายประเภทที่สองจะแสดงและตัดบรรทัดเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์และตัวเรนเดอร์

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**การจัดระยะห่างกำหนดเอง (สไลด์ 2):** ทุกป้ายที่สามจะแสดงบนบรรทัดเดียว ขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกระยะห่างของประเภท ทั้ง 24 คอลัมน์รวมถึงที่ไม่มีป้ายยังคงมองเห็นได้ด้วยค่าเดียวกัน สไลด์ที่ 3 คืนค่าการแสดงอัตโนมัติตามที่แสดงด้านบน

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **เลือกแกนและระยะห่างที่ถูกต้อง**

ใช้ระยะห่างประเภทนี้กับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอนแกนประเภทเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับแกนที่ได้จาก [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) ระยะห่างของเครื่องหมายติ๊กยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์

ห้ามใช้การจัดระยะห่างของป้ายประเภทเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) ระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้นเมือแกนเริ่มที่ศูนย์ ระยะห่างป้ายประเภท `3` นับตำแหน่งประเภทโดยไม่สนใจค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายในหัวข้อ [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้เปลี่ยนข้อมูลแผนภูมิดั้งเดิมเป็นค่าประจำปีสี่ค่า วันที่ถูกเก็บเป็นเลขซีเรียล OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`) คำนวณเป็นจำนวนวันตั้งแต่ 30 ธันวาคม 1899 ใช้ [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) กับ [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) เรียก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) ด้วย `False` แล้วส่ง `yyyy` ไปยัง [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) เพื่อให้ป้ายประเภทแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบของเซลล์

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่ามุมการหมุนสำหรับหัวเรื่องแกนแผนภูมิ**

เรียก [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) ด้วย `True` บนแกนแนวตั้ง ให้ข้อความหัวเรื่องและตั้งมุมการหมุนในรูปแบบบล็อกข้อความของหัวเรื่อง มุมวัดเป็นอองศา ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวเรื่องแกนค่าถูกหมุน 90 องศา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) เพื่อควบคุมว่าผ่านแกนค่าที่ตำแหน่งระหว่างประเภทหรือที่เครื่องหมายติ๊กของประเภท การตั้งค่านี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `True` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) เพื่อปรับสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วย [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) ตั้งเป็น `Millions` ค่า 60,000,000 จะปรากฏเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และกำหนดหน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดค่าแกนค่าลอการิทมิก**

แกนค่าลอการิทมิกมีประโยชน์เมื่อค่าบวกกระจายหลายระดับตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าช่วง บนสเกลเชิงเส้นค่าต่ำจะอยู่ใกล้ศูนย์ ลอการิทมิกทำให้การเติบโตสัมพัทธ์เปรียบเทียบได้ง่ายขึ้น: ระยะห่างเท่ากันแทนอัตราส่วนที่เท่ากันไม่ใช่ความแตกต่างที่เท่ากัน

เรียก [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) ด้วย `True` บนแกนค่าและใช้ [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) เพื่อเลือกฐาน การทำเช่นนี้เปลี่ยนวิธีการแสดงค่าที่มีอยู่ ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทมิก เส้นแนวโน้มเป็นคุณลักษณะแยกต่างหากที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าถูกคืนจาก [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) สำหรับแผนภูมิแท่งแนวนอน จะได้จาก [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งสองแกน อย่าใช้การสเกลลอการิทมิกกับแกนประเภท

ฐานลอการิทมิกเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX ให้ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมทั้งฐานเศษส่วนเช่น `2.5` ก็รองรับ ด้วยฐาน `10` พลังต่อเนื่องเช่น 10, 100, 1,000, 10,000 จะมีระยะห่างเท่า ๆ กัน

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทมิก**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีการนับคำขอห้าครั้งบนสไลด์แรก จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทมิกฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์คงข้อมูลเดียวกัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # รักษาสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะห่างแนวตั้งที่เท่ากันแทนความแตกต่างของจำนวนคำขอ ค่าใหญ่สุดครอบคลุมแผนภูมิโดยทำให้ค่าต่ำสุดมองเห็นได้ยาก

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**สเกลลอการิทมิก (สไลด์ 2):** ระยะแนวตั้งเท่ากันแทนอัตราส่วน คำขอทุกช่วงมีจำนวนเป็นสิบเท่าของช่วงก่อนหน้า ดังนั้นจุดข้อมูลจะแสดงเป็นเส้นตรงที่ขึ้นบนสเกลฐาน 10 ป้ายแกนยังคงแสดงจำนวนคำขอต้นฉบับ

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทมิกสามารถแสดงค่าบวกอย่างเคร่งครัดเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าติดลบมีความหมาย ให้คงสเกลเชิงเส้นหรือแสดงแยกต่างหาก หากการตัดค่าติดลบออกเป็นทางเลือกที่เหมาะสมสำหรับการวิเคราะห์ ให้อธิบายสาเหตุ ไม่ควรแทนที่ค่าติดลบด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ ๆ เนื่องจากจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทมิกต้องเป็นค่าบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดกับอีกแกนได้อย่างไร (การตัดแกน)?**

ใช้ [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) เพื่อเลือกพฤติกรรมการตัด หากต้องการระบุค่าตัดเชิงตัวเลข ให้ใช้ [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) การตั้งค่าเหล่านี้ช่วยให้คุณย้ายจุดตัดแกนไปยังฐานที่เหมาะสม

**ฉันจะวางตำแหน่งป้ายเครื่องหมายติ๊กสัมพันธ์กับแกนได้อย่างไร?**

เรียก [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) ด้วย [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อควบคุมตำแหน่งป้าย สำหรับการควบคุมเครื่องหมายติ๊กเอง ให้ใช้ [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) หรือ [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) ซึ่งแยกจากการกำหนดตำแหน่งป้าย.