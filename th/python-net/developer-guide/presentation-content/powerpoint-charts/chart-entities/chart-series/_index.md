---
title: จัดการชุดข้อมูลซีรีส์ของแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดซีรีส์ข้อมูล
type: docs
url: /th/python-net/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การซ้อนทับของซีรีส์
- สีของซีรีส์
- สีหมวดหมู่
- ชื่อซีรีส์
- จุดข้อมูล
- ช่องว่างของซีรีส์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์ของแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การซ้อนทับ, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Python."
---
## **ภาพรวม**

แผนภูมิจัดเก็บข้อมูลที่พล็อตไว้ใน workbook ข้อมูลแผนภูมิหนึ่งชุด [ChartSeries](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุดและแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/) ในซีรีส์อ้างอิงถึงเซลล์ workbook หนึ่งเซลล์หรือหลายเซลล์ [ChartCategory](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันโดยซีรีส์ ชื่อซีรีส์, หมวดหมู่และค่าจุดจึงเชื่อมต่อกับอ็อบเจ็กต์ [ChartDataCell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatacell/) แทนที่จะเก็บเป็นข้อความที่แสดงเท่านั้น

สำหรับแผนภูมิกลุ่มประเภททั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อซีรีส์, คอลัมน์ 0 สำหรับชื่อหมวดหมู่และเซลล์ที่เหลือสำหรับค่าซีรีส์ ดัชนี worksheet, แถวและคอลัมน์ที่ส่งให้ [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) เป็นแบบ 0‑based การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับงานนำเสนอที่โหลดมาแล้ว ควรตรวจสอบเซลล์ที่ซีรีส์, หมวดหมู่และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าใน workbook

การตั้งค่าแผนภูมิมีสามระดับแตกต่างกัน:

- การตั้งค่าระดับซีรีส์ เช่น [ChartSeries.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/format/) ให้ลักษณะเริ่มต้นสำหรับทุกจุดในซีรีส์หนึ่ง
- การตั้งค่าระดับจุดข้อมูล เช่น [ChartDataPoint.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/format/) จะลบล้างลักษณะของซีรีส์สำหรับจุดนั้น
- การตั้งค่ากลุ่มใช้กับซีรีส์ที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/parent_series_group/) เมื่อคุณต้องการกำหนดตัวเลือกเช่น overlap หรือ gap width

เมื่อไม่มีการกำหนดการเติมสีจุดหรือซีรีส์โดยชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีทั้งการจัดรูปแบบของซีรีส์และจุด การจัดรูปแบบของจุดจะมีความสำคัญต่อจุดนั้น

![แผนภูมิ‑ซีรีส์‑พาวเวอร์พอยต์](chart-series-powerpoint.png)

## **กำหนดการซ้อนทับของซีรีส์แผนภูมิ**

[ChartSeries.overlap](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ซ้อนทับกันมากแค่ไหนในแผนภูมิ 2‑D โดยมีค่าตั้งแต่ ‑100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่าน‑อย่าง‑เดียวของการตั้งค่าบนกลุ่มซีรีส์แม่ตั้งค่า [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/overlap/) เพื่ออัปเดตทุกซีรีส์ที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์แบบกลุ่ม; ไม่ส่งผลต่อกลุ่มซีรีส์ที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการซ้อนทับสำหรับกลุ่มที่มีซีรีส์แรก:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # แผนภูมิใหม่มีซีรีส์ตัวอย่าง, หมวดหมู่, และค่า.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การซ้อนทับซีรีส์](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

ใช้ [ChartSeries.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/format/) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับทั้งซีรีส์ หากจุดมีการกำหนดการเติมสีอย่างชัดเจนแล้ว การตั้งค่า [ChartDataPoint.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/format/) ของจุดนั้นจะลบล้างการเติมสีของซีรีส์สำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีเด้งพุ่มสีฟ้าเป็นสีเดียวกับซีรีส์แรก:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![สีของซีรีส์](series_color.png)

## **เปลี่ยนชื่อซีรีส์**

ชื่อซีรีส์ถูกเก็บใน workbook ข้อมูลแผนภูมิและปกติจะแสดงในคำอธิบายสีใน legend ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของซีรีส์แรก ตัวแปรคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

คุณสามารถอัปเดตเซลล์ที่ [ChartSeries.name](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/name/) อ้างอิงอยู่ได้เช่นกัน วิธีนี้หลีกเลี่ยงการสมมติว่ามีแถวและคอลัมน์ที่แน่นอนในแผนภูมิที่มีอยู่แล้ว:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ชื่อซีรีส์](series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) คืนค่าสีที่คำนวนจากดัชนีซีรีส์และสไตล์แผนภูมิ นี่คือสีที่ใช้เมื่อการเติมสีของซีรีส์ไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้อ่านค่าสีที่คำนวนแล้ว; ไม่ได้กำหนดการเติมสีใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละซีรีส์เริ่มต้น:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้จะขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **กำหนดสีเติมแบบย้อนกลับสำหรับซีรีส์แผนภูมิ**

สำหรับซีรีส์บาร์, คอลัมน์และบับเบิล, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/invert_if_negative/) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป กำหนดการเติมสีของซีรีส์เป็นสีทึบ, เปิดการย้อนกลับและกำหนดสีค่าติดลบผ่าน [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) ตัวเลขติดลบจะคงอยู่ใน workbook; เพียงเปลี่ยนสีที่แสดงเท่านั้น

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยซีรีส์เดียว worksheet แถว 0 มีชื่อซีรีส์, คอลัมน์ 0 มีชื่อหมวดหมู่และคอลัมน์ 1 มีค่าต่าง ๆ:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![สีเติมเด้งกลับแบบทึบ](inverted_solid_fill_color.png)

คุณสามารถเปิดการย้อนกลับสำหรับจุดเดียวผ่าน [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ในตัวอย่างต่อไปนี้ การย้อนกลับถูกปิดสำหรับซีรีส์และเปิดเฉพาะจุดที่เลือก จุดนั้นยังได้รับค่าติดลบเพื่อให้เห็นผล:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น ๆ ให้กำหนดเซลล์ workbook ที่เป็นฐานของจุดนั้นเป็น `None` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงผ่าน [ChartDataPoint.value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/value/) จุดข้อมูลจะยังคงอยู่ในตำแหน่งหมวดหมู่เดียวกัน แต่แผนภูมิจะแTreat ค่าดังกล่าวเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบค่าเฉพาะของจุดที่สองในซีรีส์แรก:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ให้ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ ไม่ควรเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เมื่อต้องการเก็บจุดอื่นไว้ เนื่องจากเมธอดนี้จะลบทุกจุดข้อมูลออกจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ที่ว่าง**

เซลล์ workbook ที่ว่างเปล่าจะแทนข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แทนค่าตัวเลขที่ทราบ กำหนด [ChartDataCell.value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatacell/value/) เป็น `None` เพื่อทำให้เซลล์ว่าง ค่าศูนย์ตัวเลขจะคงเป็นศูนย์ไม่ว่าจะตั้งค่าการแสดงเซลล์ว่างอย่างไร

ใช้ [Chart.display_blanks_as](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/display_blanks_as/) เพื่อเลือกว่าควรแสดงเซลล์ว่างอย่างไร การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด มันเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่ต้องเติมค่า 0 หรือค่าประมาณลงในเซลล์ workbook ที่ว่าง

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่ทำงานอิสระซึ่งสร้างแผนภูมิเส้นหนึ่งซีรีส์, ลบค่าในวัน 3 และบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อซีรีส์ ค่าข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # ปล่อยให้วัน 3 ว่างจริง ๆ แต่ยังคงเก็บหมวดหมู่และจุดข้อมูลไว้
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` และ `empty_cells_Span.pptx` หากต้องการบันทึกเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอเพียงครั้งเดียวแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม ไวัน 3 เป็นเซลล์ว่างใน workbook ทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap แตกเส้นที่วัน 3, Zero ทำเส้นลงไปที่ศูนย์, และ Span เชื่อมวัน 2 ไปวัน 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้สามโหมดเปรียบเทียบได้ง่าย ส่วนแผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมต่อเมื่อมีหมวดหมู่หายไป ดังนั้น `SPAN` จึงสร้างส่วนเชื่อมต่อไม่ได้; คอลัมน์ที่หายไปและคอลัมน์ที่มีความสูงศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิกระจายที่มีเฉพาะมาร์คเกอร์จะไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **กำหนดความกว้างของช่องว่างระหว่างซีรีส์**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับ overlap มันเป็นของกลุ่มซีรีส์แม่ ไม่ใช่ของซีรีส์เดียว ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) เพียงครั้งเดียวสำหรับกลุ่ม ค่าใหญ่จะทำให้ช่องว่างระหว่างกลุ่มเพิ่มขึ้น ค่าเล็กจะทำให้กลุ่มหนาแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกงานนำเสนอขั้นสุดท้ายเท่านั้น:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ความกว้างของช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนซีรีส์ข้อมูล?**

ทุกประเภทแผนภูมิที่ระบุด้วย [ChartType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ แต่ซีรีส์ของแต่ละประเภทไม่ได้มีโครงสร้างหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิกลุ่มใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่สอดคล้องกับประเภทซีรีส์ ตัวเลือกเช่น overlap และ gap width ใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**กลุ่มซีรีส์แผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/) ประกอบด้วยซีรีส์ที่เข้ากันได้ซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่ม งานแผนภูมิกลุ่มอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มที่เข้าถึงผ่านหนึ่งซีรีส์ไม่ได้หมายความว่าจะเปลี่ยนทุกซีรีส์ในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยค่าเริ่มต้น [ShapeCollection.add_chart](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_chart/) จะสร้างซีรีส์, หมวดหมู่และค่าตัวอย่าง คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันซีรีส์และหมวดหมู่ก่อนเพิ่มชุดข้อมูลแบบกำหนดเองได้ ตัวโอเวอร์โหลดบางตัวยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อซีรีส์, ป้ายหมวดหมู่และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลแบบกำหนดเอง ให้รักษาแถวหมวดหมู่และแถวค่าซีรีส์ให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ใต้หมวดหมู่ที่ตั้งใจ

**ทำอย่างไรถึงจะลบจุดเดียวแทนซีรีส์ทั้งหมด?**

กำหนดเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อให้จุดนั้นอยู่ตำแหน่งหมวดหมู่เดียวแต่เป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากซีรีส์นั้น หากคุณลบหมวดหมู่ด้วย ให้ปรับปรุงทุกซีรีส์เพื่อให้ค่าตรงกับคอลเลกชันหมวดหมู่

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [Chart.display_blanks_as](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/display_blanks_as/) แผนภูมิที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่า 0 หรือโดยการเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู [ควบคุมการแสดงผลของเซลล์ที่ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับซีรีส์บาร์, คอลัมน์และบับเบิลที่สนับสนุน ให้เปิด [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/invert_if_negative/) และกำหนด [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) คุณสามารถลบการตั้งค่าสำหรับจุดเดียวด้วย [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) คุณสมบัติเหล่านี้ส่งผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่จัดเก็บ

**การจัดรูปแบบใดชนะเมื่อทั้งซีรีส์และจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลอย่างชัดเจนจะมีความสำคัญต่อจุดนั้น จุดอื่น ๆ ยังคงใช้การจัดรูปแบบของซีรีส์ที่กำหนดไว้หรือหากไม่มีการกำหนดก็ใช้สไตล์และธีมของแผนภูมิงานอัตโนมัติ คุณสมบัติกลุ่มเช่น overlap และ gap width ควบคุมการจัดวางและไม่ได้เป็นการลบการจัดรูปแบบระดับจุด

**แผนภูมิสามารถมีซีรีส์ได้สูงสุดเท่าไหร่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนซีรีส์แยกจากกัน ในทางปฏิบัติ ข้อจำกัดขึ้นอยู่กับข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่ใช้งาน, เวลาเรนเดอร์และความอ่านง่ายของแผนภูมิ

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) บนกลุ่มแม่ที่เหมาะสม เพิ่มค่าที่ตั้งไว้เพื่อขยายช่องว่างระหว่างกลุ่ม หรือ ลดค่าเพื่อให้กลุ่มเข้าใกล้กันมากขึ้น