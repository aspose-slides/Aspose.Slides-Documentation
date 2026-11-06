---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ป้ายข้อมูล
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
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าต่างๆและเข้าใจแผนภูมิ บทความนี้อธิบายวิธีการจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย ควบคุมป้ายที่อยู่นอกขีดสุดของแกนอกรอบ ปรับระยะห่างของป้ายแกนประเภท และกำหนดตำแหน่งของป้ายบนแผนภูมิพาย

## **นับป้ายข้อมูลที่แสดง**

ใช้ [getCountOfVisibleDataLabels](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCountOfVisibleDataLabels) เพื่อตรวจสอบว่ามีป้ายข้อมูลที่เปิดให้แสดงกี่รายการก่อนเผยแพร่การนำเสนอ แตกต่างจาก [getCount](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getCount) ที่ให้จำนวนป้ายทั้งหมดในคอลเลกชัน มันจะคำนึงถึงค่าเริ่มต้นของชุดข้อมูลและการตั้งค่าป้ายแต่ละรายการ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีหนึ่งชุดข้อมูลและสามจุดข้อมูล เข้าถึงคอลเลกชันของป้ายของชุดข้อมูลผ่าน [getLabels](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getLabels) และพิมพ์จำนวนป้ายที่มองเห็นเมื่อการตั้งค่ามีการเปลี่ยนแปลง: **0, 3, 2, 3** จำนวนทั้งหมดยังคงเป็น **3**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    series_cell = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    for i in range(3):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JDouble((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    labels = series.getLabels()
    print(f"Total: {labels.getCount()}; visible: {labels.getCountOfVisibleDataLabels()}")  # ทั้งหมด: 3; ที่มองเห็น: 0

    labels.getDefaultDataLabelFormat().setShowValue(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # มองเห็น: 3

    labels.get_Item(1).getDataLabelFormat().setShowValue(False)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # มองเห็น: 2

    labels.get_Item(1).getDataLabelFormat().setShowLegendKey(True)
    print(f"Visible: {labels.getCountOfVisibleDataLabels()}")  # มองเห็น: 3
finally:
    presentation.dispose()
```

เมธอด [getDefaultDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getDefaultDataLabelFormat) ของชุดข้อมูลจะให้การตั้งค่าเริ่มต้น การส่งค่า `True` ไปยัง [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) จะทำให้แสดงค่าของป้ายทั้งหมดสามป้าย การส่งค่า `False` ผ่าน [getDataLabelFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getDataLabelFormat) ของป้ายหนึ่งจะครอบคลุมการตั้งค่านั้นสำหรับป้ายที่เลือก การส่งค่า `True` ไปยัง [setShowLegendKey](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLegendKey) ทำให้ป้ายดังกล่าวนับเป็นที่มองเห็นอีกครั้ง แม้ว่าค่าของมันจะยังคงซ่อนอยู่

จำนวนที่มองเห็นสะท้อนการตั้งค่าการมองเห็น ไม่ได้วัดว่าป้ายทับกัน ถูกตัด หรืออ่านได้ในแผนภูมิที่เรนเดอร์

## **กำหนดความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) เพื่อจัดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลและเปิดใช้งานป้ายค่าสำหรับชุดข้อมูลแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและสองตำแหน่งทศนิยมโดยไม่เปลี่ยนค่าจริง

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

หากต้องการจัดรูปแบบเซลล์ตัวเลขในเวิร์กบุ๊กที่ฝังในแผนภูมิ ดูที่ [Set Custom Number Formats for Workbook Cells](/slides/th/python-java/chart-workbook/#set-custom-number-formats-for-workbook-cells) ตัวอย่างนั้นแสดงให้เห็นว่าป้ายค่าตามรูปแบบเซลล์ต้นฉบับในขณะที่ยังคงรักษาค่าตัวเลขที่จัดเก็บไว้

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิคอลัมน์แบบซ้อนยอด ให้คำนวณแต่ละค่าเป็นเปอร์เซ็นต์ของผลรวมในหมวดหมู่และกำหนดข้อความไปยังกรอบข้อความที่ได้จาก [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิตั้งต้นและแสดงเปอร์เซ็นต์ด้วยสองตำแหน่งทศนิยมในแบบอักษรขนาด 8 จุด หมวดหมู่ที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ คำนวณข้อความป้ายแบบกำหนดเองใหม่หากข้อมูลแผนภูมิมีการเปลี่ยนแปลง

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

## **กำหนดสัญลักษณ์เปอร์เซ็นต์ในป้ายแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน ให้ใช้ [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) เพื่อแสดงเป็นเปอร์เซ็นต์ ส่งค่า `False` ไปยัง [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) เพื่อใช้รูปแบบป้ายแยกจากเซลล์ต้นฉบับ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% ที่มีชุดสีแดงและสีน้ำเงินในสี่หมวดหมู่ แต่ละคู่ค่ามีผลรวมเท่ากับ 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ขณะที่แกนแนวตั้งใช้สองตำแหน่งทศนิยม ทั้งสองชุดใช้ข้อความป้ายสีขาวขนาด 10 จุด

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

ใช้ [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) เพื่อดึงข้อความที่สร้างจากการตั้งค่าป้ายข้อมูล ซึ่งมีประโยชน์เมื่อสกัดป้ายสำหรับรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบป้ายข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) รวมชื่อหมวดหมู่ ชื่อชุดข้อมูล และค่าไว้ด้วยกัน จุดหนึ่งจัดรูปแบบค่าของมันเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding)

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

ค่าที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายของมันจะแสดง `75%` พร้อมกับชื่อหมวดและชื่อชุดข้อมูล ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) จะคืนสตริงป้ายที่ได้ในทั้งสองกรณี ตรวจสอบ [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) แยกต่างหากตามที่แสดงข้างต้นเมื่อคุณต้องการสกัดป้ายที่มองเห็นเท่านั้น

## **ควบคุมป้ายข้อมูลที่อยู่นอกขีดสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าขีดสุดของแกน ใช้ [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) เพื่อควบคุมว่าป้ายข้อมูลของมันจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้ายเท่านั้น ไม่เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์จัดกลุ่ม 2 มิติที่มีค่าดังนี้ 60 และ 120 ส่งค่า `False` ไปยัง [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) และตั้งค่าขีดสุดเป็น 100 ด้วย [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) บนแกนแนวตั้ง สไลด์แรกอนุญาตให้ป้ายแสดงเกินขีดสุด; สไลด์สำเนาของสไลด์นั้นปิดการแสดง ปัจจุบันทั้งสองสไลด์บันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดใช้งานป้ายค่าโดยใช้ [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) การตั้งค่าระดับแผนภูมิไม่เปิดการแสดงค่าตัวเองหรือเขียนทับการปิดการแสดงค่าของป้ายแต่ละอัน ตัวอย่างนี้เปิดค่าระดับชุดข้อมูลทั้งหมดและใช้ [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) เพื่อวางป้ายที่ปลายด้านนอกของแต่ละคอลัมน์

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

รูปภาพต่อไปนี้แสดงสไลด์ที่บันทึกแล้วและเรนเดอร์ด้วย Microsoft PowerPoint เมื่อใช้ `True` ป้าย **120** จะมองเห็นได้ที่ขอบบน; เมื่อใช้ `False` ป้ายจะถูกซ่อนไว้ ป้าย **60** ยังคงมองเห็น ได้แกนขีดสุดคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ทั้งสองกรณี

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่า 120 พร้อมขีดสุดแกน 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่า 120 พร้อมขีดสุดแกน 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="ประเภทแผนภูมิ" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิบายและแผนภูมาดองกัท จะไม่มีขีดสุดแกนที่สามารถจำกัดได้ในลักษณะนี้
{{% /alert %}}

## **กำหนดระยะห่างป้ายจากแกน**

ใช้ [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) เพื่อควบคุมระยะห่างระหว่างป้ายของแกนประเภทกับแกน ค่าเป็นเปอร์เซ็นต์ของขนาดตัวอักษรสูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์จัดกลุ่มและตั้งค่าการเยื้องของป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้มีผลต่อป้ายแกนประเภทแทนที่จะเป็นป้ายที่แนบกับจุดข้อมูลแต่ละจุด

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

บนแผนภูมิพาย ปรับตำแหน่งป้ายข้อมูลเพื่อปรับระยะห่างและสร้างพื้นที่ให้กับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายของมันอยู่นอกส่วนของพาย และปรับการเยื้องแนวนอนและแนวตั้งด้วย [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). การเยื้องเหล่านี้เป็นอัตราส่วนของความกว้างและความสูงของแผนภูมิ ตามลำดับ

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

![แผนภูมิพายที่มีตำแหน่งป้ายข้อมูลปรับแล้ว](pie-chart-adjusted-label.png)

## **จัดรูปแบบเส้นนำ**

เมื่อป้ายแผนภูมิพายนั่งอยู่นอกส่วนของพาย เส้นนำช่วยให้ผู้อ่านจับคู่ค่ากับส่วนที่ถูกต้อง สีที่ตัดกันและเส้นที่หนาเล็กน้อยช่วยให้การเชื่อมต่อเหล่านี้ตามได้ง่ายขึ้น ในขณะที่ความโปร่งแสงและสไตล์เส้นขีดทำให้เส้นดูไม่รบกวนสายตา

ใช้ [getLeaderLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelcollection/#getLeaderLinesFormat) เพื่อจัดรูปแบบเส้นนำในระดับคอลเลกชันของป้ายข้อมูลของชุดข้อมูล การตั้งค่าใน `series.getLabels().getLeaderLinesFormat().getLine()` จะใช้กับคอลเลกชันทั้งหมด ไม่ได้ใช้กับป้ายแต่ละอัน

ตัวอย่างนี้สร้างแผนภูมพายด้วยข้อมูลเริ่มต้น แสดงค่านอกส่วนของพายและเปิดใช้งาน [setShowLeaderLines](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowLeaderLines) โดยย้ายป้ายสองอันให้ห่างจากส่วนของพายมากขึ้นโดยใช้การเยื้อง [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) ซึ่งระบุเป็นส่วนของความกว้างและความสูงของแผนภูมิ ไม่จำเป็นต้องมีงานนำเข้าตัวอย่าง

เมธอด [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) ของเส้นตั้งค่าสีฟ้าแบบทึบพร้อมค่าอัลฟา 191 จาก 255 ให้ความโปร่งใสประมาณ 25% [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) ตั้งความหนาเป็น 2 จุด และ [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) ทำให้เส้นเป็นเส้นขีด

```python
import jpide
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

    # ย้ายป้ายสองอันให้ไกลออกจากส่วนของพายมากขึ้น.
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

การเปิดใช้งานเส้นนำไม่รับประกันว่าจะมีเส้นสำหรับทุกป้าย การมองเห็นขึ้นอยู่กับตำแหน่งของป้ายและพฤติกรรมการจัดวางของแผนภูมิ ในตัวอย่างนี้ ป้ายสองอันที่ย้ายออกมามีเส้นนำที่มองเห็นได้ ส่วนป้ายที่ยังคงอยู่ใกล้ส่วนของพายไม่จำเป็นต้องมีเส้นนำ

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกแล้วและเรนเดอร์ด้วย Aspose.Slides:

![แผนภูมพายที่มีเส้นนำสีฟ้า แบบกึ่งโปร่งใสและเส้นขีดเชื่อมสองป้ายด้านนอกกับส่วนของพายของมัน](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลอยู่เหนือพื้นที่พล็อต ชุดข้อมูล A แสดงคอลัมน์ที่มองเห็นได้ ในขณะที่ชุดข้อมูล B และ C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกเขาถูกซ่อนโดยการลบการเติมและขอบ สี [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) ทำให้ทั้งสามชุดข้อมูลเรียงศูนย์กลางหมวดหมู่เดียวกัน

การตั้งค่า [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) จองพื้นที่สำหรับแถวป้าย หลังจากที่ [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) คำนวณตำแหน่งเริ่มต้น [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) และ [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) จะรักษาการจัดแนวนอนและใช้การเยื้องแนวตั้งเพื่อจัดเรียงป้ายในสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมกับค่าชุดข้อมูล; เพียงหัวแถวที่เป็นรูปทรงข้อความแยกต่างหาก

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
            # ซ่อนคอลัมน์ของ B และ C แต่ยังคงป้ายข้อมูลของพวกมันไว้.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # จัดตำแหน่งชุดข้อมูลทั้งสามให้ตรงกับศูนย์กลางหมวดหมู่เดียวกัน.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กะทัดรัดนี้.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # สงวนพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายข้อมูล.
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
            # รักษาตำแหน่งแนวนอนเริ่มต้น. ค่าของ Y เป็นการเยื้องจาก
            # ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # เฉพาะหัวแถวเท่านั้นที่เป็นรูปทรงข้อความแยก.
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

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลอยู่นเหนือพื้นที่พล็อต](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิที่หนาแน่นได้อย่างไร?**  
ผสานการวางป้ายอัตโนมัติ, เส้นนำ, และลดขนาดตัวอักษร; หากจำเป็นใหซ่อนฟิลด์บางส่วน (เช่น หมวดหมู่) หรือแสดงป้ายเฉพาะค่าที่สุดขีดหรือจุดสำคัญเท่านั้น

**ฉันจะปิดการใช้ป้ายเฉพาะสำหรับค่าศูนย์, ค่าลบ หรือค่าว่างได้อย่างไร?**  
กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าลบ หรือค่าที่หายไปตามกฎที่กำหนดไว้

**ฉันจะทำให้สไตล์ป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**  
กำหนดแบบอักษรและขนาดอย่างชัดเจน และตรวจสอบว่าฟอนต์นั้นมีในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการเปลี่ยนฟอนต์อัตโนมัติ