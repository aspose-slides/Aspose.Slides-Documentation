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
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้การเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพื่อสไลด์ที่น่าสนใจยิ่งขึ้น"
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย การปรับระยะห่างของป้ายแกนประเภท และการกำหนดตำแหน่งป้ายของแผนภูมิกระจาย

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายค่าสำหรับชุดแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและจุดทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าที่อยู่ภายใน

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

สำหรับแผนภูมิคอลัมน์ซ้อนกัน คำนวณแต่ละค่าเป็นเปอร์เซ็นต์ของผลรวมในหมวดของมันและกำหนดข้อความให้กับกรอบข้อความที่คืนค่าจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยจุดทศนิยมสองตำแหน่งในฟอนต์ขนาด 8pt หมวดที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ คำนวณข้อความป้ายแบบกำหนดเองใหม่หากข้อมูลแผนภูมิมีการเปลี่ยนแปลง

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

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายแผนภูมิ**

เมื่อตัวเลขถูกเก็บเป็นเศษส่วน ใช้ [setNumberFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/#setNumberFormat) เพื่อแสดงเปอร์เซ็นต์ ส่งค่า `False` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นฉบับ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% ด้วยชุดสีแดงและสีน้ำเงินสี่หมวดแต่ละคู่ค่ารวมเป็น 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนตั้งใช้จุดทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาวขนาด 10pt

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

ใช้ [getActualLabelText](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabel/#getActualLabelText) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล เหมาะสำหรับการสกัดป้ายเพื่อรายงาน การค้นหาเนื้อหาในพรีเซนเทชัน หรือการตรวจสอบแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบป้ายข้อมูลเริ่มต้น ([data label format](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabelformat/)) รวมชื่อหมวด ชื่อชุด และค่า ชุดหนึ่งจัดรูปแบบค่าของมันเป็นเปอร์เซ็นต์ และอีกชุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)

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

ค่าที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายของมันจะแสดง `75%` พร้อมกับชื่อหมวดและชื่อชุด ข้อความกำหนดเองจะทับข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabel/#getActualLabelText) จะคืนสตริงป้ายที่ได้ไม่ว่ากรณีใด ตรวจสอบ [isVisible](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabel/#isVisible) แยกต่างหากตามที่แสดงข้างต้น หากต้องการสกัดป้ายที่มองเห็นได้เท่านั้น

## **ตั้งระยะห่างของป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/th/python-java/aspose.slides/axis/#setLabelOffset) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทและแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์กลุ่มและตั้งระยะห่างป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนประเภท แทนที่จะเป็นป้ายที่ผูกกับจุดข้อมูลแต่ละจุด

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

ในแผนภูมิกระจาย ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มระยะห่างและให้พื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายนอกชิ้นส่วน และปรับค่าออฟเซ็ตแนวนอนและแนวตั้งโดยใช้ [setX](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabel/#setX) และ [setY](https://reference.aspose.com/slides/th/python-java/aspose.slides/datalabel/#setY) ค่าออฟเซ็ตเหล่านี้เป็นอัตราส่วนของความกว้างและความสูงของแผนภูมาตามลำดับ

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลซ้อนทับกันในแผนภูมิที่แน่นได้อย่างไร?**

รวมการวางป้ายอัตโนมัติ เส้นนำ และการลดขนาดฟอนต์ หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น หมวด) หรือแสดงป้ายเฉพาะค่าที่สุดขีดหรือจุดสำคัญ

**ฉันจะปิดการแสดงป้ายสำหรับค่าศูนย์ ค่าติดลบ หรือค่าที่ว่างเปล่าได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงสำหรับค่าที่เป็น 0 ค่าติดลบ หรือค่าที่ขาดหายตามกฎที่กำหนด

**ฉันจะทำให้รูปแบบป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

กำหนดฟอนต์และขนาดฟอนต์อย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการแสดงผลเพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง