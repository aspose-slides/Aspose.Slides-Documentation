---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- ชื่อชุดข้อมูล
- จุดข้อมูล
- เซลล์สมุดงาน
- ช่องว่างของชุดข้อมูล
- ค่าติดลบ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

แผนภูมิเก็บข้อมูลที่พล็อตไว้ในสมุดงานข้อมูลแผนภูมิ A [ChartSeries](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/) ในชุดข้อมูลอ้างอิงถึงหนึ่งหรือหลายเซลล์ของสมุดงาน [ChartCategory](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ชื่อชุดข้อมูล หมวดหมู่ และค่าจุดจึงเชื่อมโยงกับออบเจกต์ [ChartDataCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/) แทนที่จะถูกเก็บเป็นข้อความแสดงผลเท่านั้น

สำหรับแผนภูมิเพิ่มประเภทที่พบบ่อย สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล คอลัมน์ 0 สำหรับชื่อหมวดหมู่ และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนีของแผ่นงาน แถว และคอลัมน์ที่ส่งผ่านไปยัง [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#getCell) เป็นดัชนีเริ่มจากศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้วิธีนี้ สำหรับการนำเสนอที่โหลดมาแล้ว ให้ตรวจสอบเซลล์ที่ชุดข้อมูล, หมวดหมู่ และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของสมุดงาน

การตั้งค่าแผนภูมิมีสามระดับการทำงานที่แตกต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getFormat) ให้รูปลักษณ์เริ่มต้นสำหรับทุกจุดในชุดข้อมูลหนึ่งชุด
- การตั้งค่าระดับจุดข้อมูล เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getFormat) จะเขียนทับรูปลักษณ์ของชุดข้อมูลสำหรับจุดเดียว
- การตั้งค่าระดับกลุ่มใช้กับชุดข้อมูลที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีของจุดหรือชุดข้อมูลโดยชัดเจน รูปแบบและธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติของการแสดงผล หากมีการกำหนดรูปแบบทั้งของชุดข้อมูลและของจุดอยู่ การกำหนดรูปแบบของจุดจะมีความสำคัญเหนือสำหรับจุดนั้น

![แผนภูมิซีรีส์พาวเวอร์พอยท์](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getOverlap) รายงานว่าความกว้างของแท่งหรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2 มิติ ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการสอดแทรกแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดข้อมูลแม่ ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดข้อมูลที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับชนิดแผนภูมิที่แสดงแท่งหรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดข้อมูลที่ไม่เกี่ยวข้องในแผนภูมิกำหนดร่วม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดข้อมูลแรกอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # แผนภูมิใหม่ประกอบด้วยชุดข้อมูลตัวอย่าง, หมวดหมู่ และค่า.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การทับซ้อนของชุดข้อมูล](series_overlap.png)

## **เปลี่ยนสีการเติมของชุดข้อมูล**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getFormat) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับชุดข้อมูลทั้งหมด หากจุดใดจุดหนึ่งมีการกำหนดการเติมสีไว้อย่างชัดเจน การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getFormat) ของจุดนั้นจะเขียนทับการเติมสีของชุดข้อมูลสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าเข้มอย่างเดียวกับชุดข้อมูลแรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![สีของชุดข้อมูล](series_color.png)

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดข้อมูลถูกเก็บไว้ในสมุดงานข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย Legend ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบจัดกลุ่ม เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และมีชื่อของชุดข้อมูลแรก ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getName) ได้ด้วยเช่นกัน วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ชื่อชุดข้อมูล](series_name.png)

## **รับสีการเติมอัตโนมัติของชุดข้อมูล**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีของชุดข้อมูลและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมสีของชุดข้อมูลไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้เพียงอ่านสีที่คำนวณได้; ไม่ได้กำหนดการเติมสีใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดข้อมูลเริ่มต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

สีที่ได้อย่างแน่นอนขึ้นกับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีการเติมกลับหัวสำหรับชุดข้อมูลแผนภูมิ**

สำหรับชุดข้อมูลแท่ง, คอลัมน์และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าติดลบด้วยการเติมสีที่ต่างออกไป ตั้งค่าการเติมสีของชุดข้อมูลเป็นสีทึบ, เปิดการกลับหัว, และกำหนดสีค่าติดลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) ตัวเลขลบจะคงอยู่ในสมุดงาน; เฉพาะสีการแสดงผลที่เปลี่ยนเท่านั้น

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยชุดข้อมูลหนึ่ง ช่วงแถวของแผ่นงาน 0 มีชื่อชุดข้อมูล, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![สีการเติมกลับหัวแบบทึบ](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับหัวสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) ในตัวอย่างต่อไปนี้ การกลับหัวถูกปิดสำหรับชุดข้อมูลและเปิดเฉพาะจุดที่เลือก จุดนั้นยังถูกกำหนดค่าติดลบเพื่อให้เห็นผลลัพธ์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์สมุดงานที่รองรับจุดนั้นเป็น `None` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถดึงผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getValue) จุดข้อมูลยังคงอยู่ที่ตำแหน่งหมวดหมู่เดียวกัน แต่แผนภูมิจัดการค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดข้อมูลแรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapointcollection/#clear) เมื่อคุณต้องการเก็บจุดอื่น ๆ เพราะเมธอดนั้นจะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์สมุดงานว่างแทนข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แทนค่าตัวเลขที่ทราบอยู่ เรียก [ChartDataCell.setValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#setValue) ด้วย `None` เพื่อทำให้เซลล์ว่าง ค่าตัวเลขศูนย์จะยังคงเป็นศูนย์ไม่ว่าจะตั้งค่าการแสดงเซลล์ว่างอย่างไร

ใช้ [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setDisplayBlanksAs) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด มันเปลี่ยนวิธีที่จุดว่างถูกพล็อตโดยไม่ต้องเติมค่า 0 หรือค่าประมาณลงในเซลล์ว่างของสมุดงาน

ตัวอย่างต่อไปนี้เป็นแอปพลิเคชันแบบอิสระที่สร้างแผนภูมิเส้นด้วยชุดข้อมูลหนึ่ง, ลบค่าของวันที่ 3, แล้วบันทึกแผนภูมิเดียวกันพร้อมแต่ละโหมด ไม่ต้องมีไฟล์อินพุต [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุดข้อมูล ค่าขั้นสุดท้ายคือ `10, 20, empty, 30, 40`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # ปล่อยให้วัน 3 ว่างจริงๆ โดยคงหมวดหมู่และจุดข้อมูลไว้
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนลูปหลายโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสามไฟล์ วันที่ 3 เป็นค่าว่างในสมุดงานทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่วัน 3, Zero ทำให้เส้นตกลงไปที่ศูนย์, และ Span เชื่อมวัน 2 ไปจนถึงวัน 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นกับประเภทของแผนภูมิ แผนภูมิเส้นทำให้สามโหมดเปรียบเทียบง่าย แผนภูมิเบ้าและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมได้เหมือนในตัวอย่าง; คอลัมน์ที่หายไปและคอลัมน์ความสูงศูนย์อาจดูคล้ายกันเช่นกัน แผนภูมิกระจายที่มีเพียงตัวชี้ตำแหน่งก็ไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบในทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์ของประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

ความกว้างช่องว่างคือระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่ใกล้เคียงกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดข้อมูลแม่ ไม่ใช่ของชุดข้อมูลเดียว เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setGapWidth) หนึ่งครั้งสำหรับกลุ่ม ค่าใหญ่กว่าจะเพิ่มระยะห่างระหว่างกลุ่ม; ค่าเล็กกว่าจะทำให้กลุ่มใกล้กันมากขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกเพียงการนำเสนอสุดท้าย:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![ความกว้างช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

ทั้งหมดของประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของแต่ละประเภทไม่ได้มีโครงสร้างค่าและการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิเพิ่มประเภทใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทของชุดข้อมูล ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มแท่งหรือคอลัมน์ที่เข้ากันได้

**กลุ่มชุดข้อมูลแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันได้และใช้การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิกำหนดร่วมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนกลุ่มที่เข้าถึงผ่านชุดข้อมูลหนึ่งไม่จำเป็นต้องเปลี่ยนชุดข้อมูลทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี โดยค่าเริ่มต้น [ShapeCollection.addChart](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addChart) จะสร้างชุดข้อมูลตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดข้อมูลและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มรูปแบบ เมธอด overload ยังสามารถสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้นได้อีกด้วย

**แผนภูมิต่อเชื่อมกับเซลล์สมุดงานอย่างไร?**

ชื่อชุดข้อมูล, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/) การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลกำหนดเอง ให้คงแถวหมวดหมู่และแถวค่าชุดข้อมูลให้สอดคล้องกัน เพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ตั้งใจ

**ทำอย่างไรจึงลบจุดเดียวแทนการลบชุดข้อมูลทั้งหมด?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดข้อมูลนั้น หากคุณลบหมวดหมู่ด้วย จะต้องอัปเดตทุกชุดข้อมูลให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดที่ว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและค่าที่กำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setDisplayBlanksAs) แผนภูมิที่สนับสนุนสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่า 0, หรือโดยการเชื่อมต่อจุดใกล้เคียงเลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดูส่วน **ควบคุมการแสดงผลของเซลล์ว่าง** สำหรับตัวอย่างเต็มรูปแบบและการเปรียบเทียบภาพ

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดข้อมูลแท่ง, คอลัมน์, และบับเบิลที่สนับสนุน ให้เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#setInvertIfNegative) แล้วกำหนดสีที่คืนค่าจาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor) คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดียวด้วย [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative) วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่เก็บไว้

**การจัดรูปแบบใดชนะเมื่อทั้งชุดข้อมูลและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดที่ระบุอย่างชัดเจนจะมีความสำคัญเหนือสำหรับจุดนั้น จุดอื่น ๆ จะยังคงใช้การจัดรูปแบบของชุดข้อมูลที่ระบุหรือเมื่อไม่มีการกำหนดชุดข้อมูล จะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ได้เป็นการเขียนทับการจัดรูปแบบระดับจุด

**แผนภูมิสามารถมีชุดข้อมูลได้กี่ชุด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดข้อมูลแบบคงที่ อย่างไรก็ตามข้อจำกัดของไฟล์พรีเซนเทชัน, หน่วยความจำที่มี, เวลาเรนเดอร์, และการอ่านเข้าใจของแผนภูมิจะแสดงถึงขีดจำกัดที่เป็นประโยชน์ในทางปฏิบัติ

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setGapWidth) บนกลุ่มชุดข้อมูลแม่ที่เหมาะสม เพิ่มค่าขึ้นเพื่อเพิ่มระยะห่างระหว่างกลุ่ม หรือ ลดค่าลงเพื่อทำให้กลุ่มใกล้กันมากขึ้น