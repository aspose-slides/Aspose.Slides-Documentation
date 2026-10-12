---
title: จัดการป้ายข้อมูลแผนภูมิในงานพรีเซนเทชันโดยใช้ Python
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
- การพรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานพรีเซนเทชัน PowerPoint โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java เพื่อสร้างสไลด์ที่ดึงดูดมากยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลและจุดข้อมูลแต่ละจุด เพื่อช่วยให้ผู้อ่านระบุค่าต่าง ๆ และเข้าใจแผนภูมิได้ดีขึ้น บทความนี้อธิบายวิธีการจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย การควบคุมป้ายข้อมูลที่เกินค่ามากสุดของแกน การปรับระยะห่างของป้ายแกนประเภท และการจัดตำแหน่งป้ายของแผนภูมิเส้นพาย

## **กำหนดความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) เพื่อจัดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นที่ใช้ข้อมูลเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายค่าของชุดแรก รูปแบบ `#,##0.00` แสดงตัวคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนแปลงค่าพื้นฐาน

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

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน คำนวณค่าต่าง ๆ เป็นเปอร์เซ็นต์ของรวมประเภทของแต่ละค่า แล้วกำหนดข้อความไปยังกรอบข้อความที่ส่งคืนโดย [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิดีฟอลต์และแสดงเปอร์เซ็นต์พร้อมทศนิยมสองตำแหน่งในแบบอักษรขนาด 8 จุด ประเภทที่รวมศูนย์เป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงต้องคำนวณข้อความป้ายแบบกำหนดเองใหม่

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

## **กำหนดสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลแผนภูมิ**

เมื่อค่าถูกเก็บเป็นส่วนทศนิยม ใช้ [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) เพื่อแสดงเปอร์เซ็นต์ ส่งค่า `False` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นฉบับ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% ที่มีชุดสีแดงและสีน้ำเงินครอบคลุมสี่ประเภท ค่าคู่ละคู่รวมกันเป็น 1 รูปแบบป้าย `0.0%` จะทำให้ 0.30 แสดงเป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาวขนาด 10 จุด

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

ใช้ [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล ซึ่งเป็นประโยชน์เมื่อดึงป้ายสำหรับรายงาน ค้นหาเนื้อหาในพรีเซนเทชัน หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง ฟอร์แมตป้ายข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) จะรวมชื่อประเภท ชื่อชุดข้อมูล และค่า จุดหนึ่งจัดรูปแบบค่าเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)

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

ค่าที่เก็บไว้ในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายจะแสดง `75%` พร้อมชื่อประเภทและชื่อชุดข้อมูล ข้อความกำหนดเองจะทดแทนข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) จะคืนสตริงป้ายที่ได้ในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) แยกต่างหากตามที่แสดงข้างต้นเมื่อคุณต้องการดึงป้ายที่มองเห็นได้เท่านั้น

## **ควบคุมป้ายข้อมูลที่เกินค่ามากสุดของแกน**

เมื่อคุณจำกัดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุด Use [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) เพื่อควบคุมว่าป้ายข้อมูลของพวกมันจะแสดงหรือไม่ การตั้งค่านี้จะเปลี่ยนการมองเห็นของป้ายเท่านั้น ไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์ 2‑มิติที่มีค่า 60 และ 120 มันส่งค่า `False` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) และตั้งค่าสูงสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) บนแกนแนวตั้ง สไลด์แรกเปิดให้แสดงป้ายที่เกินค่าสูงสุด; การคัดลอกสไลด์นั้นจะปิดการแสดงป้าย ทั้งสองสไลด์ถูกบันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดใช้ป้ายค่าโดยใช้ [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) การตั้งค่าที่ระดับแผนภูมิไม่ได้เปิดการแสดงค่าด้วยตนเองหรือเขียนทับการปิดการแสดงค่าของป้ายแต่ละรายการ ตัวอย่างนี้เปิดใช้ค่าจากชุดทั้งหมดและใช้ [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) เพื่อตำแหน่งป้ายที่ด้านนอกของแต่ละคอลัมน์

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

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกแล้วโดย Microsoft PowerPoint เมื่อใช้ `True` ป้าย **120** จะมองเห็นได้ที่ขอบบน; เมื่อใช้ `False` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ แกนสูงสุดคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่า 120 โดยมีค่ามากสุดของแกนเป็น 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่า 120 โดยมีค่ามากสุดของแกนเป็น 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="ประเภทแผนภูมิ" %}}

ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2‑มิติที่มีแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิเส้นพายและโดนัท จะไม่มีค่ามากสุดของแกนให้จำกัดในลักษณะนี้

{{% /alert %}}

## **กำหนดระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทกับแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบคลัสเตอร์และตั้งค่าการเยื้องป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้มีผลต่อป้ายแกนประเภท ไม่ใช่ป้ายที่แนบกับจุดข้อมูลแต่ละจุด

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

บนแผนภูมิเส้นพาย ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มช่องว่างและทำให้มีพื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายออกจากชิ้นส่วน และปรับการเยื้องแนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) การเยื้องเหล่านี้สัมพันธ์กับความกว้างและความสูงของแผนภูมิ

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

![แผนภูมิเส้นพายที่ปรับตำแหน่งป้ายข้อมูล](pie-chart-adjusted-label.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่กราฟ ชุด A แสดงคอลัมน์ที่มองเห็นได้ ในขณะที่ชุด B และชุด C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกมันถูกซ่อนไว้โดยลบการเติมและขอบ เส้นวิธี [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) ทำให้ทั้งสามชุดเชื่อมศูนย์กลางประเภทเดียวกัน

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) จะสงวนพื้นที่สำหรับแถวป้าย หลังจาก [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) คำนวณตำแหน่งค่าเริ่มต้นแล้ว [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) จะรักษาการจัดแนวนอนและใช้การเยื้องแนวตั้งเพื่อจัดเรียงป้ายในสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าชุดข้อมูล; เฉพาะหัวเรื่องแถวเป็นรูปทรงข้อความแยกต่างหาก

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

    # จัดตำแหน่งทุกชุดให้ตรงกับจุดศูนย์กลางประเภทเดียวกัน.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กระชับนี้.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # สำรองพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายข้อมูล.
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
            # คงตำแหน่งแนวนอนเริ่มต้นไว้. Y เป็นการเยื้องจาก
            # ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # เฉพาะหัวแถวเท่านั้นที่เป็นรูปทรงข้อความแยกต่างหาก.
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

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่กราฟ](multiple-rows-of-labels.png)

## **FAQ**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิความหนาแน่นสูงได้อย่างไร?**

ผสานการวางป้ายอัตโนมัติ เส้นนำ และขนาดฟอนต์ที่ลดลง; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะค่าขอบหรือจุดสำคัญเท่านั้น

**ฉันจะปิดการแสดงป้ายสำหรับค่าศูนย์ ลบ หรือค่าลบได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าลบ หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ป้ายคงที่เมื่อส่งออกเป็น PDF/ภาพได้อย่างไร?**

ตั้งค่าครอบครัวและขนาดฟอนต์อย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นพร้อมใช้งานในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง