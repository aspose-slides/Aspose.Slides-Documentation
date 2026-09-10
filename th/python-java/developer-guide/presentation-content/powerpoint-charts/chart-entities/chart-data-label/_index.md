---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอโดยใช้ Python
linktitle: ป้ายข้อมูล
type: docs
url: /th/python-java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งป้าย
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for Python via Java เพื่อสไลด์ที่ดึงดูดมากขึ้น."
---
## **บทนำ**

ป้ายข้อมูลบนแผนภูมิแสดงรายละเอียดของชุดข้อมูลในแผนภูมิหรือจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านสามารถระบุชุดข้อมูลได้อย่างรวดเร็วและทำให้แผนภูมิเข้าใจง่ายขึ้น.

## **กำหนดความแม่นยำของข้อมูลในป้ายข้อมูลของแผนภูมิ**

โค้ด Python นี้แสดงวิธีการตั้งค่าความแม่นยำของข้อมูลในป้ายข้อมูลของแผนภูมิ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

Aspose.Slides for Python via Java ให้คุณสามารถตั้งค่าป้ายเปอร์เซ็นต์บนแผนภูมิที่แสดงได้ โค้ด Python นี้แสดงการทำงาน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)
    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งเครื่องหมายเปอร์เซ็นต์ในป้ายข้อมูลของแผนภูมิ**

โค้ด Python นี้แสดงวิธีการตั้งค่าเครื่องหมายเปอร์เซ็นต์สำหรับป้ายข้อมูลของแผนภูมิ:

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
    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")
    chart.getChartData().getSeries().clear()
    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # เพิ่มซีรีส์สีแดง.
    series_cell = workbook.getCell(worksheet_index, 0, 1, "Reds")
    red_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.30, 0.50, 0.80, 0.65], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 1, jpype.JDouble(value))
        red_series.getDataPoints().addDataPointForBarSeries(data_cell)

    red_series.getFormat().getFill().setFillType(FillType.Solid)
    red_series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    red_label_format = red_series.getLabels().getDefaultDataLabelFormat()
    red_label_format.setShowValue(True)
    red_label_format.setNumberFormatLinkedToSource(False)
    red_label_format.setNumberFormat("0.0%")
    red_portion_format = red_label_format.getTextFormat().getPortionFormat()
    red_portion_format.setFontHeight(10)
    red_portion_format.getFillFormat().setFillType(FillType.Solid)
    red_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    # เพิ่มซีรีส์สีน้ำเงิน.
    series_cell = workbook.getCell(worksheet_index, 0, 2, "Blues")
    blue_series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, value in enumerate([0.70, 0.50, 0.20, 0.35], start=1):
        data_cell = workbook.getCell(worksheet_index, row_index, 2, jpype.JDouble(value))
        blue_series.getDataPoints().addDataPointForBarSeries(data_cell)

    blue_series.getFormat().getFill().setFillType(FillType.Solid)
    blue_series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)
    blue_label_format = blue_series.getLabels().getDefaultDataLabelFormat()
    blue_label_format.setShowValue(True)
    blue_label_format.setNumberFormatLinkedToSource(False)
    blue_label_format.setNumberFormat("0.0%")
    blue_portion_format = blue_label_format.getTextFormat().getPortionFormat()
    blue_portion_format.setFontHeight(10)
    blue_portion_format.getFillFormat().setFillType(FillType.Solid)
    blue_portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดระยะป้ายจากแกน**

โค้ด Python นี้แสดงวิธีการกำหนดระยะห่างของป้ายจากแกนประเภทเมื่อคุณทำงานกับแผนภูมิที่วาดจากแกน:

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
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ปรับตำแหน่งป้าย**

เมื่อคุณสร้างแผนภูมิที่ไม่อิงแกนใด ๆ เช่น แผนภูมิวงกลม ป้ายข้อมูลของแผนภูมิอาจอยู่ใกล้ขอบมากเกินไป ในกรณีเช่นนี้ คุณต้องปรับตำแหน่งของป้ายข้อมูลเพื่อให้เส้นเชื่อมแสดงอย่างชัดเจน.

โค้ด Python นี้แสดงวิธีการปรับตำแหน่งป้ายบนแผนภูมิวงกลม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![ป้ายที่ปรับบนแผนภูมิวงกลม](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ทำอย่างไรจึงจะป้องกันป้ายข้อมูลไม่ให้ทับซ้อนในแผนภูมิที่แออัด?**

ใช้การจัดตำแหน่งป้ายอัตโนมัติ, เส้นเชื่อม, และลดขนาดฟอนต์ร่วมกัน; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะจุดที่สำคัญ/สุดขีดเท่านั้น.

**ทำอย่างไรจึงจะปิดการแสดงป้ายเฉพาะค่าศูนย์, ค่าลบ หรือค่าว่าง?**

กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าลบ หรือค่าที่หายไปตามกฎที่กำหนด.

**ทำอย่างไรจึงจะรักษาสไตล์ป้ายให้สม่ำเสมอเมื่อส่งออกเป็น PDF/รูปภาพ?**

กำหนดฟอนต์โดยชัดเจน (ประเภท, ขนาด) และตรวจสอบว่าฟอนต์นั้นมีอยู่ในฝั่งการแสดงผลเพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง.