---
title: "จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอโดยใช้ Python"
linktitle: "ป้ายข้อมูล"
type: docs
url: /th/python-java/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งของป้าย
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพื่อสร้างสไลด์ที่น่าสนใจมากยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด, ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า, แสดงเปอร์เซ็นต์, อ่านข้อความป้าย, ควบคุมป้ายข้อมูลที่เกินค่าสูงสุดของแกน, ปรับระยะห่างของป้ายแกนประเภท, และกำหนดตำแหน่งป้ายของแผนภูมิวงกลม

## **กำหนดความแม่นยำของข้อมูลในป้ายข้อมูลของแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) เพื่อจัดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น, แสดงตารางข้อมูล, และเปิดใช้งานป้ายค่าสำหรับชุดแรก รูปแบบ `#,##0.00` แสดงตัวคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าพื้นฐาน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แสดงเปอร์เซ็นต์เป็นป้ายข้อมูล**

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน, คำนวณแต่ละค่ามาเป็นเปอร์เซ็นต์ของผลรวมในหมวดหมู่นั้นและกำหนดข้อความให้กับกรอบข้อความที่คืนค่าจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในแบบอักษรขนาด 8 จุด หมวดที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงให้คำนวณข้อความป้ายแบบกำหนดใหม่

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
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลของแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน, ใช้ [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) เพื่อแสดงเป็นเปอร์เซ็นต์ ส่ง `False` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นแบบ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบซ้อน 100% ที่มีซีรีส์สีแดงและสีน้ำเงินครอบคลุมสี่หมวด แต่ละคู่ค่าจะบวกกันได้ 1 รูปแบบป้าย `0.0%` จะทำให้แสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองซีรีส์ใช้ข้อความป้ายสีขาวขนาด 10 จุด

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
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **อ่านข้อความจริงของป้ายข้อมูล**

ใช้ [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าของป้ายข้อมูล ซึ่งมีประโยชน์เมื่อดึงป้ายเพื่อนำไปใช้ในรายงาน, ค้นหาเนื้อหาในงานนำเสนอ, หรือทำการตรวจสอบแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่างรูปแบบ [รูปแบบป้ายข้อมูลเริ่มต้น](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) จะรวมชื่อหมวด, ชื่อซีรีส์, และค่าไว้ด้วยกัน จุดหนึ่งจะแปลงค่าของมันเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

ค่าที่เก็บไว้ในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายของมันจะแสดงเป็น `75%` พร้อมกับชื่อหมวดและชื่อซีรีส์ ข้อความกำหนดเองจะทับข้อความป้ายที่สร้างโดยอัตโนมัติ [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) จะคืนสตริงป้ายที่ได้ไม่ว่ากรณีใดก็ตาม ตรวจสอบ [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) แยกต่างหากตามที่แสดงในด้านบนเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายข้อมูลที่เกินค่าสูงสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุด ใช้ [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) เพื่อตัดสินใจว่าจะแสดงป้ายของจุดที่เกินหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้ายเท่านั้น; มันไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบกลุ่ม 2D ที่มีค่า 60 และ 120 โดยส่ง `False` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) แล้วกำหนดค่าสูงสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) บนแกนแนวตั้ง สไลด์แรกอนุญาตให้แสดงป้ายที่เกินค่าสูงสุด; อีกสไลด์หนึ่งปิดการแสดงผล ปัจจัยทั้งสองถูกบันทึกในไฟล์ `DataLabelsOverMaximum.pptx`

เปิดใช้งานป้ายค่าโดยใช้ [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) การตั้งค่าระดับแผนภูมิไม่ทำให้ค่าถูกแสดงโดยอัตโนมัติหรือเขียนทับการตั้งค่าป้ายแต่ละอัน ตัวอย่างนี้เปิดใช้ค่าให้กับซีรีส์ทั้งหมดและใช้ [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) เพื่อตำแหน่งป้ายที่ปลายด้านนอกของแต่ละคอลัมน์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกโดย Microsoft PowerPoint ด้วย `True` ป้าย **120** จะปรากฏที่ขอบบน; ด้วย `False` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้, ค่าสูงสุดของแกนคงที่ที่ **100**, และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่า 120 กับค่าสูงสุดของแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่า 120 กับค่าสูงสุดของแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D ที่มีแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิวงกลมและโดนัท จะไม่มีค่าสูงสุดของแกนให้จำกัดในลักษณะนี้
{{% /alert %}}

## **กำหนดระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทและแกน ค่านี้เป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและตั้งค่าออฟเซ็ตป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนประเภทมากกว่าป้ายที่แนบกับจุดข้อมูลแต่ละจุด

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

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ปรับตำแหน่งป้าย**

บนแผนภูมิกลม, ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มระยะห่างและทำให้มีพื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก, วางป้ายด้านนอกชิ้นและปรับออฟเซ็ตแนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) ออฟเซ็ตเหล่านี้อิงตามความกว้างและความสูงของแผนภูมิตามลำดับ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![แผนภูมิกลมที่มีตำแหน่งป้ายข้อมูลปรับแล้ว](pie-chart-adjusted-label.png)

## **จัดรูปแบบเส้นนำ**

เมื่อป้ายของแผนภูมิกลมอยู่ด้านนอกชิ้น, เส้นนำช่วยให้ผู้อ่านเชื่อมโยงค่ากับชิ้นที่ถูกต้อง สีตัดกันและเส้นหนาเล็กน้อยทำให้การเชื่อมต่อดูง่ายขึ้น, ในขณะที่ความโปร่งแสงและสไตล์เส้นขีดทำให้เส้นไม่รบกวนสายตา

ใช้ [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) เพื่อจัดรูปแบบเส้นนำระดับคอลเลกชันของป้ายข้อมูลของซีรีส์ การตั้งค่าใน `series.getLabels().getLeaderLinesFormat().getLine()` จะใช้กับคอลเลกชันทั้งหมด แทนที่จะเป็นแต่ละป้าย

ตัวอย่างนี้สร้างแผนภูมิกลมด้วยข้อมูลเริ่มต้น, แสดงค่าอยู่ด้านนอกชิ้น, และเปิดใช้งาน [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) ย้ายป้ายสองอันให้ห่างจากชิ้นมากขึ้นโดยใช้ [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) ที่เป็นส่วนของความกว้างและความสูงของแผนภูมิ ไม่จำเป็นต้องมีงานนำเสนอเข้า

เมธอด [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) ของเส้นกำหนดสีฟ้าเรียบที่มีค่าอัลฟา 191 จาก 255 ซึ่งให้ความโปร่งใสประมาณ 25% [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ตั้งความหนาเป็น 2 จุด, และ [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) ทำให้เส้นเป็นแบบขีด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 80, 50, 560, 400)
    chart.setLegend(False)

    series = chart.getChartData().getSeries().get_Item(0)

    label_format = series.getLabels().getDefaultDataLabelFormat()
    label_format.setShowValue(True)
    label_format.setPosition(LegendDataLabelPosition.OutsideEnd)
    label_format.setShowLeaderLines(True)

    # ย้ายป้ายสองอันให้ห่างจากชิ้นมากขึ้น.
    series.getLabels().get_Item(0).setX(0.10)
    series.getLabels().get_Item(0).setY(-0.05)
    series.getLabels().get_Item(1).setX(-0.10)
    series.getLabels().get_Item(1).setY(0.05)

    line = series.getLabels().getLeaderLinesFormat().getLine()
    line.getFillFormat().setFillType(FillType.Solid)
    color = Color(30, 90, 160, 191)
    line.getFillFormat().getSolidFillColor().setColor(color)
    line.setWidth(2)
    line.setDashStyle(LineDashStyle.Dash)

    presentation.save("FormattedLeaderLines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปิดใช้งานเส้นนำไม่ได้รับประกันว่าจะมีเส้นแสดงสำหรับทุกป้าย ความมองเห็นขึ้นกับตำแหน่งป้ายและพฤติกรรมการจัดเรียงของแผนภูมิ ในตัวอย่างนี้ป้ายสองอันที่กดออกจากชิ้นมีเส้นนำที่มองเห็นได้; ป้ายที่อยู่ใกล้ชิ้นไม่จำเป็นต้องมี

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกแล้วและเรนเดอร์ด้วย Aspose.Slides:

![แผนภูมิกลมที่มีเส้นนำสีฟ้า, กึ่งโปร่งใส, ขีดเชื่อมสองป้ายด้านนอกกับชิ้นของมัน](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิจำนวนคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลอยู่เหนือพื้นที่แผนภูมิ Series A แสดงคอลัมน์ที่มองเห็นได้, ในขณะที่ Series B และ Series C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกเขาถูกซ่อนโดยลบสีเติมและสีขอบ วิธีการ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) ทำให้ทั้งสามซีรีส์จัดตำแหน่งตรงศูนย์กลางของหมวดเดียวกัน

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) จองพื้นที่สำหรับแถวป้าย หลังจากที่ [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) คำนวณตำแหน่งเริ่มต้น, [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) รักษาการจัดแนวนอนและใช้การออฟเซ็ตแนวตั้งเพื่อจัดเรียงป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าของซีรีส์; เฉพาะหัวแถวที่เป็นรูปทรงข้อความแยกออกมา

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # ซ่อนคอลัมน์ของ B และ C แต่คงป้ายข้อมูลไว้.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # จัดตำแหน่งทุกซีรีส์สามชุดให้ตรงกับศูนย์กลางของหมวดเดียวกัน.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กะทัดรัดนี้.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # จองพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายข้อมูล.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # คงตำแหน่งแนวนอนเริ่มต้น. Y คือการออฟเซ็ตจาก
            # ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # เฉพาะหัวแถวเป็นรูปทรงข้อความแยกต่างหาก.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่แผนภูมิ](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิที่หนาแน่นได้อย่างไร?**

รวมการวางตำแหน่งอัตโนมัติของป้าย, เส้นนำ, และการลดขนาดฟอนต์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น หมวด) หรือแสดงป้ายเฉพาะค่าที่สุดโต่งหรือจุดสำคัญ

**ฉันจะปิดการทำงานของป้ายเฉพาะค่าศูนย์, ค่าลบ, หรือค่าว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าลบ, หรือค่าที่ขาดหายตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

ตั้งค่าแบบอักษรและขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์พร้อมใช้งานในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง