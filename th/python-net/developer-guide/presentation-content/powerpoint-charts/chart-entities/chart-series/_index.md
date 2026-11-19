---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- สีประเภท
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างของชุด
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Python."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่ plotted ในเซลล์ของ workbook หรือโดยตรงเป็น literal ตัวเลขได้ [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) แสดงจุดในชุดนั้น [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุด, ประเภท, และค่าจุดจะใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) จาก workbook ของแผนภูมิ

สำหรับแผนภูมิประเภทเชิงหมวดโดยทั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อประเภท, และเซลล์ที่เหลือสำหรับค่าชุด Worksheet, row, และ column indexes ที่ส่งไปยัง [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) จะเป็นศูนย์‑based Layout นี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้วิธีนี้ สำหรับการนำเสนอที่โหลดแล้ว ตรวจสอบเซลล์ที่อ้างอิงโดยชุด, ประเภท, และจุดข้อมูลก่อนที่จะเปลี่ยนค่าใน workbook

การตั้งค่าแผนภูมิมีสามขอบเขตที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในชุดเดียว
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), ครอบคลุมลักษณะชุดสำหรับจุดเดียว
- การตั้งค่ากลุ่มจะใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่น overlap หรือ gap width

เมื่อไม่มีการกำหนดการเติมจุดหรือชุดอย่างชัดเจน สไตล์และธีมของแผนภูมิกำหนดลักษณะอัตโนมัติ เมื่อมีการจัดรูปแบบทั้งชุดและจุดพร้อมกัน การจัดรูปแบบจุดจะมีความสำคัญต่อจุดนั้น

![แผนภูมิ series PowerPoint](chart-series-powerpoint.png)

สำหรับแผนภูมิลูกกระบอกแบบจัดกลุ่ม ดูว่า [การเปลี่ยนประเภทชุด 3D หรือรูปร่างแถบ](/slides/th/python-net/3d-chart/#change-the-3d-series-type-and-bar-shape) มีผลต่อชุดแรกอย่างไร

## **กำหนดค่าชุดข้อมูลโดยใช้ Literal ตัวเลข**

ใช้ literal ตัวเลขเมื่อค่าชุดมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ worksheet ตั้งค่า [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) เป็น [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) ก่อนกำหนดค่า [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) ของแต่ละจุดผ่าน [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/)

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งที่มาของค่าทุกจุดในชุดนั้น แต่ละจุดมี [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) รายงานประเภทที่เลือก; เปลี่ยนโดยใช้การตั้งค่าคอลเลกชัน หากใช้ `WORKSHEET` ให้ใช้ [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) เพื่อเข้าถึงเซลล์ที่อ้างถึง หากใช้ `DOUBLE_LITERALS` ให้ใช้ `as_literal_double` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและประเภทเริ่มต้น แล้วกำหนดค่าที่คำนวณได้ 10, 20, … ให้กับจุดที่มีอยู่ของชุดแรก มันบันทึกการนำเสนอ, เปิดใหม่, และพิมพ์ค่าที่เก็บไว้

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    series = chart.chart_data.series[0]

    series.data_points.data_source_type_for_values = charts.DataSourceType.DOUBLE_LITERALS
    for i in range(len(series.data_points)):
        series.data_points[i].value.as_literal_double = (i + 1) * 10

    presentation.save("numeric_literals.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("numeric_literals.pptx") as reopened_presentation:
    reopened_slide = reopened_presentation.slides[0]
    reopened_chart = reopened_slide.shapes[0]
    reopened_series = reopened_chart.chart_data.series[0]
    for point in reopened_series.data_points:
        print(point.value.as_literal_double)
```

ประเภทแหล่งที่มาของค่าจุดแยกจาก [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) ซึ่งระบุการกำหนดค่าภายในหรือภายนอกของ workbook การใช้ literal ตัวเลขโดยลำพังไม่ได้ลบ workbook ที่ฝังอยู่ ในตัวอย่างนี้ workbook ยังคงใช้สำหรับป้ายประเภท, ชื่อชุด, และชุดอื่น ๆ ดู [Chart Workbook](/slides/th/python-net/chart-workbook/) สำหรับการจัดการ workbook

สำหรับแผนภูมิ scatter และ bubble, ตั้งค่า [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) และ [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) เพื่อเลือกแหล่งที่มาสำหรับ [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) และ [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/) แผนภูมิ bubble ยังใช้ [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) สำหรับ [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/) ตั้งค่าแหล่งที่มาที่ใช้ได้เป็น `DOUBLE_LITERALS` ก่อนกำหนดตัวเลขผ่านคุณสมบัติ `as_literal_double` ของค่านั้น

## **กำหนดค่า Overlap ของชุดแผนภูมิ**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ทับกันเท่าใดในแผนภูมิ 2D, ระหว่าง -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่าน‑only ของการตั้งค่าในกลุ่มชุดแม่ตั้งค่า [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่า overlap สำหรับกลุ่มที่มีชุดแรกอยู่

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # แผนภูมิใหม่ประกอบด้วยชุดข้อมูลตัวอย่าง, ประเภท, และค่าต่างๆ.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีการเติมชุด**

ใช้ [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) เพื่อตั้งค่าการเติมเริ่มต้นสำหรับทั้งชุด หากจุดมีการเติมที่กำหนดไว้แล้ว การตั้งค่า [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) จะครอบคลุมการเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ทำการเติมสีฟ้าแบบทึบให้กับชุดแรก

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

![สีของชุด](series_color.png)

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกเก็บใน workbook ของแผนภูมิและโดยปกติจะแสดงใน legend ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์จัดกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) วิธีนี้หลีกเลี่ยงการสมมติแถวหรือคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

![ชื่อชุด](series_name.png)

### **สร้างชุดด้วยชื่อจากหลายเซลล์**

ชื่อชุดแบบประกอบมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกเก็บในเซลล์ workbook แยกกัน ตัวอย่างเช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 เป็นชื่อชุดเดียวขณะยังคงเชื่อมโยงทั้งสองส่วนไปยังเซลล์ต้นทาง

ใช้ [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นไปยัง [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/) อาร์กิวเมนต์ `skip_hidden_cells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนอยู่หรือไม่: `True` จะตัดออก, `False` จะรวม ตัวอย่างนี้ใช้ `False` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีชุดเดียวและสองจุดข้อมูล เซลล์ B1:C1 ให้เฉพาะชื่อชุด; A2:A3 ให้ป้ายประเภท, B2:B3 ให้ค่าตัวเลข

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # เซลล์สองเซลล์นี้ให้ชื่อชุด.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # เซลล์แยกต่างหากให้ประเภทและจุดข้อมูลเชิงตัวเลข.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

ชื่อชุดที่ได้คือ `Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์ legend แสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์ ภาพด้านล่างเรนเดอร์จากการบันทึกการนำเสนอ:

![แผนภูมิคอลัมน์พร้อมค่าภาคเหนือและภาคใต้และชื่อชุดประกอบ Product A 2026 ใน legend](composite_series_name.png)

## **รับสีการเติมอัตโนมัติของชุด**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) คืนสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อตัวเติมของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้อ่านสีที่คำนวณ; ไม่ได้กำหนดการเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น

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

ตัวอย่างผลลัพธ์สำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมสลับสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และ bubble, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป ตั้งค่าการเติมปกติเป็นสีทึบ, เปิดการสลับ, และกำหนดสีค่าติดลบผ่าน [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) ตัวเลขติดลบจะคงอยู่ใน workbook; เพียงสีการแสดงผลเปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิมาตรฐานด้วยชุดเดียว Worksheet แถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อประเภท, และคอลัมน์ 1 มีค่าต่าง ๆ

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

![สีเติมทึบสลับ](inverted_solid_fill_color.png)

คุณสามารถเปิดการสลับสำหรับจุดเดียวผ่าน [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) ในตัวอย่างต่อไปนี้ การสลับถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก จุดนั้นยังถูกกำหนดค่าเป็นค่าติดลบเพื่อให้เห็นผล

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

## **ลบค่าของจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ workbook ที่รองรับเป็น `None` สำหรับแผนภูมิคอลัมน์ ค่า plotted สามารถเข้าถึงได้ผ่าน [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) จุดข้อมูลยังคงอยู่ที่ตำแหน่งประเภทเดิม แต่แผนภูมิจะถือค่าว่างตามการตั้งค่าค่า‑blank ของแผนภูมิ

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก

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

แผนภูมิ scatter ใช้เซลล์ X และ Y แยกกัน, แผนภูมิ bubble ยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่น ๆ เพราะเมธอดนั้นจะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่ซึ่งมีค่าเป็นกรณีแยกจากเซลล์ว่าง เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อนอยู่ ดู [Include Data from Hidden Rows and Columns](/slides/th/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างแสดงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แสดงค่าตัวเลขที่ทราบ ตั้งค่า [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) เป็น `None` เพื่อทำให้เซลล์ว่าง ศูนย์ตัวเลขยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิเ�ทั้งหมด มันเปลี่ยนวิธีที่ช่องว่างถูก plot โดยไม่เติมเซลล์ workbook ว่างด้วยศูนย์หรือค่าประมาณ

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดเดียว, ลบค่าใน Day 3, และบันทึกแผนภูมิเดียวกันด้วยแต่ละโหมด ไม่ต้องมีไฟล์อินพุต [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) ใช้งาน worksheet 0, คอลัมน์ 0 สำหรับป้ายประเภท, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

    # ทำให้ Day 3 เป็นค่าว่างจริงๆ ในขณะที่ยังคงประเภทและจุดข้อมูลของมันไว้
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, `empty_cells_Span.pptx` เพื่อบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนรอบทุกโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในสามไฟล์ Day 3 เป็นค่าว่างใน workbook ทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่ Day 3, Zero ทำให้เส้นลงไปศูนย์, และ Span เชื่อม Day 2 ไป Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้สามโหมดเปรียบเทียบได้ง่าย แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมข้ามประเภทที่หายไป ดังนั้น `SPAN` ไม่สามารถสร้างส่วนเชื่อมที่แสดงด้านบนได้; คอลัมน์ที่หายไปและคอลัมน์สูงศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิ scatter ที่มีเฉพาะมาร์คเกอร์เท่านั้นไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่น overlap, มันเป็นของกลุ่มชุดแม่แทนที่จะเป็นของชุดเดียว ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ครั้งเดียวสำหรับกลุ่ม ค่าที่ใหญ่กว่าจะสร้างช่องว่างระหว่างกลุ่มมากขึ้น, ค่าที่เล็กกว่าจะทำให้กลุ่มใกล้กันมากขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกการนำเสนอสุดท้ายเท่านั้น

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

## **แสดงหรือซ่อนเส้นชุด**

เส้นชุดเชื่อมต่อส่วนที่เกี่ยวข้องของแผนภูมิ ใช้ [ChartSeriesGroup.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/has_series_lines/) เพื่อแสดงหรือซ่อนในแผนภูมิ stacked bar และ OfPie ที่รองรับ ในแผนภูมิ stacked bar และคอลัมน์ 2‑มิติ, เส้นเหล่านี้เชื่อมขอบสแตกที่สอดคล้องกันข้ามประเภท ในแผนภูมิ Pie of Pie และ Bar of Pie, เส้นเชื่อมพล็อตหลักกับพล็อตรอง การตั้งค่านี้ไม่ใช่ตัวเชื่อมทั่วไปสำหรับประเภทแผนภูมิอื่น

เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) การตั้งค่านี้ใช้กับทุกชุดในกลุ่มนั้น [ChartSeries.has_series_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/has_series_lines/) เป็นแบบอ่าน‑only และสะท้อนการตั้งค่ากลุ่มแม่; เปลี่ยนคุณสมบัติกลุ่มเพื่ออัปเดต

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [ChartType.PIE_OF_PIE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) หนึ่งรายการด้วยข้อมูลเริ่มต้น มันบันทึกแผนภูมิเดียวกันโดยเปิดใช้เส้นชุดแล้วปิดใช้งาน, ผลลัพธ์เป็นสองการนำเสนอเพื่อเปรียบเทียบ

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 400)
    series = chart.chart_data.series[0]
    series_group = series.parent_series_group

    series_group.has_series_lines = True
    presentation.save("series_lines_enabled.pptx", slides.export.SaveFormat.PPTX)

    series_group.has_series_lines = False
    presentation.save("series_lines_disabled.pptx", slides.export.SaveFormat.PPTX)
```

| เปิดใช้งานเส้นชุด | ปิดใช้งานเส้นชุด |
| --- | --- |
| ![แผนภูมิ Pie of Pie พร้อมเส้นชุดเปิดใช้งาน](series_lines_enabled.png) | ![แผนภูมิ Pie of Pie พร้อมเส้นชุดปิดใช้งาน](series_lines_disabled.png) |
| เส้นสองเส้นเชื่อมพายหลักกับพายรอง | พายทั้งสองยังมองเห็นได้, แต่เส้นเชื่อมถูกซ่อน |

เส้นชุดแตกต่างจากเส้นนำของป้ายข้อมูลที่เชื่อมป้ายกับจุดข้อมูล; เส้นตารางที่ทำเครื่องหมายช่วงบนแกนแผนภูมิ; และเส้นในแผนภูมิเส้นที่แสดงค่าข้อมูล การตั้งค่านี้ไม่ได้ควบคุมองค์ประกอบเหล่านั้น

## **FAQ**

**ประเภทแผนภูมิใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ทั้งหมดมีโครงสร้างค่า或การตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิเพิ่มประเภทใช้ประเภทและค่า, แผนภูมิ scatter ใช้ค่า X และ Y, แผนภูมิ bubble เพิ่มขนาด bubble ใช้ วิธีสร้างจุดข้อมูลที่สอดคล้องกับประเภทชุด ตัวเลือกเช่น overlap และ gap width ใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากัน

**ชุดกลุ่มแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) มีชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการ plot ระดับกลุ่ม แผนภูมิผสมอาจมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มที่เข้าถึงผ่านชุดหนึ่งไม่ได้จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิใหม่ที่สร้างขึ้นมีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) สร้างชุดตัวอย่าง, ประเภท, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันประเภทก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างสมบูรณ์ การโอเวอร์โหลดบางอย่างยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายประเภท, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตามที่สอดคล้อง เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, รักษาแถวประเภทและแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดถูก plot ใต้ประเภทที่ตั้งใจ

**จะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งประเภทของจุดเป็นจุดว่าง ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบประเภทด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันประเภท

**จุดว่างแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่า zero, หรือโดยการเชื่อมจุดที่อยู่ใกล้เคียง เลือกการตั้งค่าที่ตรงกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) เพื่อดูตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และ bubble ที่รองรับ, เปิด [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) และตั้งค่า [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/) คุณสามารถครอบคลุมพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/) คุณสมบัติเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ใช่ค่าตัวเลขที่เก็บไว้

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลโดยชัดเจนได้เปรียบสำหรับจุดนั้น จุดอื่น ๆ จะยังคงใช้การจัดรูปแบบชุดที่ชัดเจนหรือ, หากชุดไม่มีการจัดรูปแบบ, สไตล์และธีมอัตโนมัติของแผนภูมิ คุณสมบัติกลุ่มเช่น overlap และ gap width ควบคุมการจัดวางและไม่ใช่การทับซ้อนการจัดรูปแบบระดับจุด

**มีขีดจำกัดจำนวนชุดในแผนภูมิหรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแยกต่างหาก โดยทั่วไปข้อจำกัดมาจากขนาดไฟล์การนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างเกินไป?**

ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่เพื่อขยายช่องว่างระหว่างกลุ่ม, หรือ ลดค่าเพื่อนำกลุ่มมาใกล้กันขึ้น​