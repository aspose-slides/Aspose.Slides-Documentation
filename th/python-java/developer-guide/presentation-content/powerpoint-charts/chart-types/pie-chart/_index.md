---
title: ปรับแต่งแผนภูมิกวงในงานนำเสนอโดยใช้ Python ผ่าน Java
linktitle: แผนภูมิกวง
type: docs
url: /th/python-java/pie-chart/
keywords:
- แผนภูมิกวง
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีของสไลซ์
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิกวงใน Python ผ่าน Java ด้วย Aspose.Slides. กำหนดค่าพล็อตรอง, แสดงป้ายกำกับข้อมูล, และใช้สีสไลซ์อัตโนมัติใน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิกวงใน Aspose.Slides. แสดงวิธีกำหนดค่าตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie, และวิธีเปิดใช้งานการทำสีสไลซ์อัตโนมัติสำหรับแผนภูมิกวงมาตรฐาน.

ตัวอย่างเน้นที่งานปรับแต่งแผนภูมิเช่น การเพิ่มแผนภูมิลงสไลด์, การปรับตั้งค่าซีรีส์และป้ายกำกับ, การแทนที่ข้อมูลแผนภูมิดีฟอลต์ด้วยหมวดหมู่และค่าแบบกำหนดเอง, และการบันทึกการนำเสนอที่อัปเดต.

## **ตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for Python via Java รองรับตัวเลือกพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie. ตัวเลือกเหล่านี้ควบคุมขนาดของพล็อตรองและวิธีการแบ่งจุดข้อมูลระหว่างพล็อตทั้งสอง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ Pie of Pie ในการนำเสนอใหม่และแสดงค่าจุดข้อมูลเป็นป้ายกำกับ. วิธี [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) ตั้งค่าขนาดพล็อตรองเป็น 149% ของพล็อตหลัก. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) เลือกการแบ่งตามเปอร์เซ็นต์, และ [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) ตั้งค่าค่ากำหนดเป็น 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # แสดงค่าและกำหนดค่าพล็อตรอง.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **เลือกหมวดหมู่สำหรับพล็อตรอง**

ใช้การแบ่งแบบกำหนดเองเมื่อคุณต้องการจัดกลุ่มหมวดหมู่เฉพาะในพล็อตรองโดยไม่คำนึงถึงค่าเปอร์เซ็นต์ของพวกมัน. ตัวอย่างเช่น รายงานการขายอาจแสดง Online และ Events ร่วมกันเพื่อให้ผู้อ่านเปรียบเทียบสองช่องทางนี้ แม้ว่าพวกมันจะคิดเป็น 35% และ 10% ของยอดขายรวม.

เรียก [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) พร้อมกับ [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) และเลือกจุดผ่าน [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). วิธีของคอลเลคชั่น [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) รับดัชนีเริ่มจากศูนย์ในซีรีส์; ใช้ [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem) เพื่อเพิ่มอ็อบเจกต์จุดข้อมูล. ในตัวอย่างนี้ ดัชนี 1 เลือก Online, และจุดที่ดัชนี 3 เลือก Events. Partners ถูกเพิ่มชั่วคราว, จากนั้นลบออกโดยใช้ [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # แทนที่ข้อมูลเริ่มต้นด้วยยอดขายตามช่องทาง.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # เลือก Online ตามดัชนีเริ่มจากศูนย์และ Events ตามอ็อบเจกต์จุดข้อมูล.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # เว้น Partners ออกจากการเลือกโดยไม่ลบข้อมูลต้นฉบับของมัน.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) และ Events (10) ปรากฏเป็นสไลซ์แยกในพล็อตรอง. ในพล็อตหลัก, พวกมันถูกแทนด้วยสไลซ์รวมค่าที่ 45, ร่วมกับ Retail (40) และ Partners (15). การลบ Partners ออกจากการเลือกแบบกำหนดเองทำให้มันยังคงอยู่ในพล็อตหลัก; ไม่ได้ลบหมวดหมู่หรือค่าของมันจากข้อมูลต้นแหล่งของแผนภูมิ.

ภาพต่อไปนี้แสดงการบันทึกการนำเสนอใน PowerPoint:

![แผนภูมิ Pie of Pie ที่มี Online และ Events ในพล็อตรองและค่ารวมของพวกมันคือ 45 ในพล็อตหลัก](pie_of_pie_custom.png)

## **ตั้งค่าสีสไลซ์อัตโนมัติสำหรับแผนภูมิวงกลม**

Aspose.Slides for Python via Java สามารถกำหนดสีที่แตกต่างให้กับสไลซ์ของแผนภูมิกวงโดยอัตโนมัติ. ตัวอย่างต่อไปนี้สร้างแผนภูมิกวงพร้อมหัวเรื่องอยู่ตรงกลางและแทนที่ข้อมูลเดิมด้วยสามหมวดไตรมาสพร้อมค่าของพวกมัน. วิธี [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) แสดงค่าที่ 20, 50, และ 30 เป็นป้ายกำกับ, ขณะที่ [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) เปิดใช้งานสีที่แตกต่างสำหรับแต่ละสไลซ์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # เพิ่มหัวเรื่องแผนภูมิที่จัดกึ่งกลาง.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # แทนที่ข้อมูลเริ่มต้นโดยใช้แผ่นงานแรก.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # แสดงค่าและกำหนดสีที่แตกต่างให้กับสไลซ์.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**Are the Pie of Pie and Bar of Pie variations supported?**

ใช่, ไลบรารี [supports](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) พล็อตรองสำหรับแผนภูมิกวง, รวมถึงประเภท Pie of Pie และ Bar of Pie.

**Can I export just the chart as an image (for example, PNG)?**

ใช่, คุณสามารถ [export the chart itself as an image](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (เช่น PNG) ได้โดยไม่ต้องส่งออกการนำเสนอทั้งหมด.