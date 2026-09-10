---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-java/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- ชื่อชุด
- จุดข้อมูล
- เซลล์ในสมุดงาน
- ช่องว่างของชุด
- ค่าติดลบ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ในสมุดงาน, การฟอร์แมต, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่ทำการพล็อตไว้ในสมุดงานข้อมูลแผนภูมิ. คอลัมน์ [ChartSeries](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/) ในชุดจะอ้างอิงถึงเซลล์หนึ่งหรือหลายเซลล์ในสมุดงาน. วัตถุ [ChartCategory](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartcategory/) ให้ป้ายชื่อหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุด. ดังนั้นชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/) แทนที่จะบันทึกเป็นข้อความแสดงผลเท่านั้น.

สำหรับแผนภูมิเข้าหมวดหมู่ทั่วไป, สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, và เซลล์ที่เหลือสำหรับค่าชุด. ดัชนี Worksheet, แถว, และคอลัมน์ที่ส่งให้ [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#getCell) จะเริ่มนับจากศูนย์. การจัดเรียงนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่不要假设每个已存在的图表都使用它. สำหรับการนำเสนอที่โหลดแล้ว, ตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวดหมู่, และจุดข้อมูลก่อนทำการเปลี่ยนแปลงค่าในสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getFormat), ให้ลักษณะเริ่มต้นสำหรับทุกจุดในหนึ่งชุด.
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getFormat), จะเหนือกว่าลักษณะของชุดสำหรับจุดเดียว.
- การตั้งค่ากลุ่มนำไปใช้กับชุดที่เข้ากันซึ่งเป็นส่วนหนึ่งของ [ChartSeriesGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/). เข้าถึงกลุ่มผ่าน [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getParentSeriesGroup) เมื่อคุณต้องการกำหนดตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง.

เมื่อไม่มีการกำหนดการเติมสีให้กับจุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. เมื่อทั้งการฟอร์แมตของชุดและจุดมีอยู่, การฟอร์แมตของจุดจะมีสิทธิ์เหนือสำหรับจุดนั้น.

![แผนภูมิซีรีส์ใน PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดแผนภูมิ**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getOverlap) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าไรในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. นี่เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่. ใช้ [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setOverlap) เพื่ออัปเดตทุกชุดที่เข้ากันในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์กลุ่ม; มันจะไม่ส่งผลต่อกลุ่มชุดที่ไม่มีความเกี่ยวข้องในแผนภูมิกลับ.

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่ประกอบด้วยชุดแรก:

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

    # แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [ChartSeries.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getFormat) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับทั้งชุด. หากจุดมีการกำหนดสีเติมอย่างชัดเจนแล้ว, การตั้งค่า [ChartDataPoint.getFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getFormat) จะเหนือกว่าสีเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมแบบโซลิดสีน้ำเงินกับชุดแรก:

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

![สีของชุด](series_color.png)

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกเก็บในสมุดงานข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย. ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก. ตัวแปรที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getName) ได้เช่นกัน. วิธีนี้ช่วยหลีกเลี่ยงการสมมุติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อชุด](series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ. นี้คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดนี้จะอ่านสีที่คำนวณแล้ว; ไม่ได้กำหนดสีเติมใหม่.

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

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

สีที่แม่นยำขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับหัวสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#setInvertIfNegative) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าสีเติมปกติของชุดให้เป็นโซลิด, เปิดใช้งานการกลับหัว, và กำหนดสีค่าติดลบผ่าน [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). ตัวเลขลบจะไม่เปลี่ยนในสมุดงาน; เพียงแต่สีที่แสดงจะเปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยหนึ่งชุด. แถว Worksheet 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, và คอลัมน์ 1 มีค่า:

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

![สีเติมโซลิดกลับหัว](inverted_solid_fill_color.png)

คุณสามารถเปิดใช้งานการกลับหัวสำหรับจุดเดียวผ่าน [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). ในตัวอย่างต่อไปนี้ การกลับหัวถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก. จุดนั้นยังได้รับค่าติดลบเพื่อให้เห็นผล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

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

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์ในสมุดงานที่เป็นฐานของจุดนั้นเป็น `None`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตสามารถเข้าถึงได้ผ่าน [ChartDataPoint.getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#getValue). จุดข้อมูลยังคงอยู่ในตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจะถือค่านั้นเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, và แผนภูมิบับเบิลใช้เซลล์ขนาดด้วย. ให้ลบเฉพาะเซลล์ที่แทนค่าที่ต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapointcollection/#clear) เมื่อคุณต้องการเก็บจุดอื่นไว้, เนื่องจากเมธอดนั้นจะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน.

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มันเป็นของกลุ่มชุดแม่ ไม่ได้เป็นของชุดเดียว. เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setGapWidth) หนึ่งครั้งสำหรับกลุ่ม. ค่าที่ใหญ่กว่าจะสร้างช่องว่างระหว่างกลุ่มเพิ่มขึ้น; ค่าที่เล็กกว่าจะทำให้กลุ่มหนาแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกเฉพาะงานนำเสนอสุดท้าย:

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

![ความกว้างของช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดที่รองรับชุดข้อมูล?**  
ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น, แผนภูมิเข้าหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีสร้างจุดข้อมูลที่ตรงกับประเภทของชุด. ตัวเลือกเช่นการทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากัน.

**กลุ่มชุดแผนภูมิคืออะไร?**  
[ChartSeriesGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/) เป็นกลุ่มของชุดที่เข้ากันซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่มร่วมกัน. แผนภูมิแบบผสมสามารถมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดหนึ่งไม่จำเป็นต้องเปลี่ยนแปลงทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**  
ใช่. โดยค่าเริ่มต้น, [ShapeCollection.addChart](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addChart) สร้างชุดตัวอย่าง, หมวดหมู่, và ค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. มีการ overload ที่สามารถสร้างแผนภูมิไม่มีข้อมูลเริ่มต้นได้เช่นกัน.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ในสมุดงานอย่างไร?**  
ชื่อชุด, ป้ายชื่อหมวดหมู่, và ค่าจุดข้อมูลอ้างอิงถึงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูม้าที่สอดคล้องกัน. เมื่อคุณสร้างข้อมูลกำหนดเอง, ใหรักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ภายใต้หมวดหมู่ที่ตั้งใจ.

**ฉันจะลบจุดเดียวแทนการลบชุดทั้งหมดอย่างไร?**  
ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapointcollection/#clear) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น. หากคุณลบหมวดหมู่ด้วย, ให้ปรับปรุงทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดที่ว่างเปล่าถูกแสดงอย่างไร?**  
ผลลัพธ์ขึ้นกับประเภทแผนภูมิ và ค่าการกำหนดผ่าน [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setDisplayBlanksAs). แผนภูมิที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมต่อจุดใกล้เคียง. เลือกการตั้งค่าที่ตรงกับความหมายของข้อมูลที่ขาดหายไปในงานนำเสนอของคุณ.

**ค่าติดลบถูกฟอร์แมตอย่างไร?**  
สำหรับชุดบาร์, คอลัมน์, và บับเบิลที่สนับสนุน, เรียก [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#setInvertIfNegative) และกำหนดสีที่ได้จาก [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). คุณสามารถลบฟอร์แมตนี้สำหรับจุดเดียวโดยใช้ [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). วิธีเหล่านี้มีผลต่อการฟอร์แมต, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้.

**ฟอร์แมตใดที่จะมีสิทธิ์เหนือเมื่อทั้งชุดและจุดมีการฟอร์แมต?**  
การฟอร์แมตจุดข้อมูลที่กำหนดอย่างชัดเจนจะมีสิทธิ์เหนือสำหรับจุดนั้น. จุดอื่น ๆ จะใช้ฟอร์แมตชุดที่กำหนด หรือเมื่อไม่มีการกำหนดชุดจะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การฟอร์แมตระดับจุด.

**มีขีดจำกัดจำนวนชุดที่แผนภูมิสามารถมีได้หรือไม่?**  
Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแยกต่างหาก. อย่างไรก็ตาม ข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์, và ความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่ใช้ได้จริง.

**ฉันควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**  
เรียก [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartseriesgroup/#setGapWidth) ในกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น.