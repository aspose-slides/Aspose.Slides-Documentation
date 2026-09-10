---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอโดยใช้ Python
linktitle: แกนแผนภูมิ
type: docs
url: /th/python-java/chart-axis/
keywords:
  - แกนแผนภูมิ
  - แกนแนวตั้ง
  - แกนแนวนอน
  - ปรับแต่งแกน
  - จัดการแกน
  - ควบคุมแกน
  - คุณสมบัติของแกน
  - ค่าสูงสุด
  - ค่าต่ำสุด
  - เส้นแกน
  - รูปแบบวันที่
  - ชื่อแกน
  - ตำแหน่งแกน
  - PowerPoint
  - งานนำเสนอ
  - Python
  - Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลข้อมูล."
---
## **Overview**

บทความนี้อธิบายวิธีปรับแต่งแกนของแผนภูมิใน Aspose.Slides แสดงวิธีดึงค่าจริงของแกน, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทของแกนประเภท, ตั้งรูปแบบวันที่สำหรับค่าของแกนประเภท, หมุนชื่อแกน, ตั้งตำแหน่งแกน, และตั้งหน่วยแสดงของแกนค่าที่แทนค่า

## **Get the Maximum Values on the Vertical Axis of a Chart**

Aspose.Slides for Python via Java ช่วยให้คุณสามารถดึงค่าต่ำสุดและสูงสุดบนแกนแนวตั้งได้ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
1. รับค่ามากสุดจริงบนแกน
1. รับค่าต่ำสุดจริงบนแกน
1. รับหน่วยหลักจริงของแกน
1. รับหน่วยย่อยจริงของแกน
1. รับสเกลหน่วยหลักจริงของแกน
1. รับสเกลหน่วยย่อยจริงของแกน

ตัวอย่างโค้ดนี้—การทำตามขั้นตอนข้างต้น—แสดงวิธีดึงค่าที่ต้องการใน Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    # บันทึกงานนำเสนอ
    presentation.save("MaxValuesVerticalAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Swap the Data between Axes**

Aspose.Slides ให้คุณสลับข้อมูลระหว่างแกนได้อย่างรวดเร็ว—ข้อมูลที่แสดงบนแกนแนวตั้ง (y-axis) จะย้ายไปยังแกนแนวนอน (x-axis) และกลับกัน

โค้ด Python นี้แสดงวิธีดำเนินการสลับข้อมูลระหว่างแกนบนแผนภูมิ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)

    # โหลดข้อมูลค่าเริ่มต้นของแผนภูมิลงใน workbook — switchRowColumn จะสลับแถวและคอลัมน์ของ workbook,
    # ดังนั้นจึงต้องเติมข้อมูลก่อน
    workbook = chart.getChartData().getChartDataWorkbook()

    # สลับแถวและคอลัมน์
    chart.getChartData().switchRowColumn()

    # บันทึกงานนำเสนอ
    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Disable the Vertical Axis for Line Charts**

โค้ด Python นี้แสดงวิธีซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Disable the Horizontal Axis for Line Charts**

โค้ดนี้แสดงวิธีซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Change a Category Axis**

โดยใช้เมธอด [setCategoryAxisType](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#setCategoryAxisType) คุณสามารถระบุประเภทแกนประเภทที่ต้องการ (**date** หรือ **text**) โค้ด Python นี้แสดงการทำงาน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
        if isinstance(chart, Chart):
            chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
            chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
            chart.getAxes().getHorizontalAxis().setMajorUnit(1)
            chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)
            presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
        else:
            print("The first shape is not a chart.")
    else:
        print("The presentation has no first shape to update.")
finally:
    presentation.dispose()
```

## **Set the Date Format for Category Axis Values**

Aspose.Slides for Python via Java ช่วยให้คุณตั้งรูปแบบวันที่สำหรับค่าของแกนประเภท การทำงานนี้แสดงในโค้ด Python นี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

from datetime import datetime

def convert_to_oa_date(date):
    base_date = datetime(1899, 12, 30)
    return (date - base_date).total_seconds() / 86400


presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 50, 50, 450, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()
    category_date = datetime(2015, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A2", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2016, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A3", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2017, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A4", category_value)
    chart.getChartData().getCategories().add(category_cell)
    category_date = datetime(2018, 2, 1)
    category_value = convert_to_oa_date(category_date)
    category_cell = workbook.getCell(0, "A5", category_value)
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    value_cell = workbook.getCell(0, "B2", 1.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 2.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 3.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 4.0)
    series.getDataPoints().addDataPointForLineSeries(value_cell)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set a Rotation Angle for a Chart Axis Title**

Aspose.Slides for Python via Java ช่วยให้คุณตั้งมุมการหมุนสำหรับชื่อแกนของแผนภูมิ โค้ด Python นี้แสดงการทำงาน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Axis Position on a Category or Value Axis**

Aspose.Slides for Python via Java ช่วยให้คุณตั้งตำแหน่งแกนบนแกนประเภทหรือแกนค่า โค้ด Python นี้แสดงวิธีทำ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Set the Display Unit on a Chart Value Axis**

Aspose.Slides for Python via Java ช่วยให้คุณตั้งหน่วยแสดงของแกนค่าของแผนภูมิ แล้วแกนจะปรับสเกลป้ายบรรทัดตามหน่วยนั้น: ด้วย [DisplayUnitType.Millions](https://reference.aspose.com/slides/th/python-java/aspose.slides/displayunittype/#Millions) แกนที่ไล่จนถึง 60,000,000 จะถูกระบุเป็น 0 ถึง 60 โค้ด Python นี้แสดงการทำงาน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)

    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**How do I set the value at which one axis crosses the other (axis crossing)?**

แกนมีการตั้งค่า [crossing setting](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#setCrossType) ให้คุณเลือกข้ามที่ศูนย์, ที่ค่าต่ำสุดหรือสูงสุดของประเภท/ค่า, หรือที่ค่าตัวเลขเฉพาะ การตั้งค่านี้มีประโยชน์สำหรับการเลื่อนแกน X ขึ้นหรือลง หรือเพื่อเน้นเส้นฐาน

**How can I position tick marks relative to the axis (crossing, outside, inside)?**

ตั้งค่า [tick mark position](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#setMajorTickMark) เป็น "cross", "outside" หรือ "inside" การตั้งค่านี้มีผลต่อความอ่านง่ายและช่วยประหยัดพื้นที่ โดยเฉพาะบนแผนภูมิขนาดเล็ก