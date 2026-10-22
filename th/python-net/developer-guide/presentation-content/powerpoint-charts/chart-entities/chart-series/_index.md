---
title: จัดการซีรีส์ข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ซีรีส์ข้อมูล
type: docs
url: /th/python-net/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การซ้อนทับของซีรีส์
- สีของซีรีส์
- สีของประเภท
- ชื่อซีรีส์
- จุดข้อมูล
- ระยะห่างของซีรีส์
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์แผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การฟอร์แมต, การซ้อนทับ, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Python."
---
## **ภาพรวม**

แผนภูมิสามารถจัดเก็บค่าที่ plotted ไว้ในเซลล์ของ workbook หรือโดยตรงเป็นค่าตัวเลขลิตเตอรัลได้. [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) ประมาณค่าชุดหนึ่งของค่าที่เกี่ยวข้อง, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) แสดงจุดหนึ่งในชุดนั้น. วัตถุ [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) ให้ค่าวางชื่อหรือค่ากลุ่มที่ใช้ร่วมกันโดยซีรีส์. ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น, ชื่อซีรีส์, ประเภท, และค่าจุดใช้วัตถุ [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) จากสมุดงานของแผนภูมิ.

สำหรับแผนภูมิเข้าประเภทแผนภูมิเชิงประเภท, สมุดงานเริ่มต้นใช้แถว 0 สำหรับชื่อซีรีส์, คอลัมน์ 0 สำหรับชื่อประเภท, และเซลล์ที่เหลือสำหรับค่าซีรีส์. ดัชนี worksheet, แถว, และคอลัมน์ที่ส่งให้ [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) เป็นค่าเริ่มต้นที่นับตั้งจากศูนย์. รูปแบบนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ห้ามสมมติว่าแผนภูมิที่มีอยู่ทุกอันใช้รูปแบบนี้. สำหรับงานนำเสนอที่โหลดมา, ตรวจสอบเซลล์ที่อ้างอิงโดยซีรีส์, ประเภท, และจุดข้อมูลก่อนที่จะเปลี่ยนค่าในสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับซีรีส์, เช่น [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในหนึ่งซีรีส์.
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), เขียนทับลักษณะของซีรีส์สำหรับจุดเดียว.
- การตั้งค่ากลุ่มใช้กับซีรีส์ที่เข้ากันได้และอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการซ้อนทับหรือความกว้างของช่องว่าง.

เมื่อไม่มีการกำหนดการเติมจุดหรือซีรีส์อย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. เมื่อมีการฟอร์แมตทั้งซีรีส์และจุด, การฟอร์แมตจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าค่าซีรีส์โดยใช้ลิตเตอรัลตัวเลข**

ใช้ลิตเตอรัลตัวเลขเมื่อค่าซีรีส์มาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องการอ้างอิงเซลล์ worksheet. ตั้งค่า [data_source_type_for_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_values/) เป็น [DataSourceType.DOUBLE_LITERALS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) ก่อนกำหนดค่าของแต่ละจุดผ่าน [value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/) ด้วย [as_literal_double](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_literal_double/).

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งที่มาของค่าจุดทั้งหมดในซีรีส์นั้น. [value.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/basechartvalue/data_source_type/) ของแต่ละจุดรายงานประเภทที่เลือก; เปลี่ยนได้ผ่านการตั้งค่าคอลเลกชัน. หากใช้ `WORKSHEET`, ใช้ [as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/doublechartvalue/as_cell/) เพื่อเข้าถึงเซลล์ที่อ้างอิง. หากใช้ `DOUBLE_LITERALS`, ใช้ `as_literal_double` เพื่ออ่านหรือเขียนตัวเลขโดยตรง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยซีรีส์และประเภทเริ่มต้น, แล้วกำหนดค่าที่คำนวนได้ 10, 20, ฯลฯ ให้กับจุดที่มีอยู่ของซีรีส์แรก. จากนั้นบันทึกงานนำเสนอ, เปิดใหม่อีกครั้ง, และพิมพ์ค่าที่จัดเก็บไว้.

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

ประเภทแหล่งที่มาของค่าจุดแยกจาก [ChartData.data_source_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/), ซึ่งระบุการกำหนดค่าหนังสือทำงานภายในหรือภายนอกของแผนภูมิ. การใช้ลิตเตอรัลตัวเลขไม่ได้ลบสมุดงานฝังอยู่โดยอัตโนมัติ. ในตัวอย่างนี้, สมุดงานยังคงใช้สำหรับป้ายประเภท, ชื่อซีรีส์, และซีรีส์อื่น ๆ. ดู [สมุดงานแผนภูมิ](/slides/th/python-net/chart-workbook/) สำหรับการจัดการสมุดงาน.

สำหรับแผนภูมิกระจายและฟองอากาศ, ตั้งค่า [data_source_type_for_x_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_x_values/) และ [data_source_type_for_y_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_y_values/) เพื่อเลือกแหล่งที่มาสำหรับ [x_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/x_value/) และ [y_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/y_value/). แผนภูมิฟองอากาศยังใช้ [data_source_type_for_bubble_sizes](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/data_source_type_for_bubble_sizes/) สำหรับ [bubble_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/bubble_size/). ตั้งค่าแต่ละแหล่งที่เหมาะสมเป็น `DOUBLE_LITERALS` ก่อนกำหนดตัวเลขผ่าน property `as_literal_double` ของค่าดังกล่าว.

## **ตั้งค่าการซ้อนทับของซีรีส์แผนภูมิ**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ซ้อนทับกันเท่าไรในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มซีรีส์แม่. ตั้งค่า [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) เพื่ออัปเดตทุกซีรีส์ที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่กระทบกับกลุ่มซีรีส์ที่ไม่เกี่ยวข้องในแผนภูมิกำหนดค่าแบบผสม.

ตัวอย่างต่อไปนี้ตั้งค่าการซ้อนทับสำหรับกลุ่มที่มีซีรีส์แรก:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # แผนภูมิใหม่มีซีรีส์ตัวอย่าง, ประเภท, และค่า.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **เปลี่ยนสีการเติมของซีรีส์**

ใช้ [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) เพื่อกำหนดการเติมเริ่มต้นสำหรับทั้งซีรีส์. หากจุดมีการเติมอย่างชัดเจน, การตั้งค่า [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) จะเขียนทับการเติมของซีรีส์สำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใส่การเติมสีฟ้าโทนเดียวให้กับซีรีส์แรก:

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

![The color of the series](series_color.png)

## **เปลี่ยนชื่อซีรีส์**

ชื่อซีรีส์ถูกจัดเก็บในสมุดงานข้อมูลของแผนภูมิและโดยปกติแสดงใน legend. ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์จัดกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของซีรีส์แรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) ได้. วิธีนี้หลีกเลี่ยงการสันนิษฐานว่าแถวและคอลัมน์ใดในแผนภูมิที่มีอยู่:

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

![The series name](series_name.png)

### **สร้างซีรีส์ด้วยชื่อจากหลายเซลล์**

ชื่อซีรีส์แบบคอมโพสท์มีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานเก็บอยู่ในเซลล์สมุดงานแยกกัน. ตัวอย่างเช่น, คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อซีรีส์เดียวโดยยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทางของมัน.

ใช้ [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) เพื่อดึงช่วงชื่อ, แล้วส่งคอลเลกชันนั้นไปที่ [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). อาร์กิวเมนต์ `skip_hidden_cells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนไว้หรือไม่: `True` จะไม่รวม, `False` จะรวม. ตัวอย่างนี้ใช้ `False` เพื่อรวมทุกเซลล์ในช่วงชื่อ.

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีหนึ่งซีรีส์และสองจุดข้อมูล. เซลล์ B1:C1 มีเฉพาะชื่อซีรีส์; A2:A3 มีป้ายประเภท, และ B2:B3 มีค่าตัวเลข.

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

    # เซลล์สองเซลล์นี้ให้ชื่อซีรีส์.
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

ชื่อซีรีส์ที่ได้คือ `Product A 2026`, โดยมีช่องว่างระหว่างค่าจากสองเซลล์. Legend แสดงเป็นรายการเดียวสำหรับสองคอลัมน์. ภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกแล้ว:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีการเติมอัตโนมัติของซีรีส์**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) คืนค่าสีที่คำนวนจากดัชนีซีรีส์และสไตล์ของแผนภูมิ. นี่คือสีที่ใช้เมื่อการเติมซีรีส์ไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดนี้อ่านค่าสีที่คำนวนไว้; ไม่ได้กำหนดการเติมใหม่.

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

สีที่ได้ขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีการเติมกลับด้านสำหรับซีรีส์แผนภูมิ**

สำหรับซีรีส์บาร์, คอลัมน์, และฟองอากาศ, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) สามารถแสดงค่าลบด้วยสีเติมที่แตกต่าง. ตั้งค่าการเติมซีรีส์แบบสีทึบ, เปิดใช้งานการกลับด้าน, และกำหนดสีค่าลบผ่าน [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). ค่าตัวเลขลบจะไม่เปลี่ยนแปลงในสมุดงาน; มีเพียงสีการแสดงผลที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยหนึ่งซีรีส์. แถว worksheet 0 มีชื่อซีรีส์, คอลัมน์ 0 มีชื่อประเภท, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

คุณสามารถเปิดใช้งานการกลับด้านสำหรับจุดเดียวผ่าน [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). ในตัวอย่างต่อไปนี้, การกลับด้านถูกปิดสำหรับซีรีส์และเปิดใช้งานเฉพาะจุดที่เลือก. จุดนั้นยังถูกกำหนดค่าเป็นค่าลบเพื่อให้เห็นผล:

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

เพื่อทำให้จุดหนึ่งว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์สมุดงานที่สนับสนุนเป็น `None`. สำหรับแผนภูมิคอลัมน์, ค่าที่ plotted สามารถเข้าถึงได้ผ่าน [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). จุดข้อมูลจะคงตำแหน่งประเภทเดิม, แต่แผนภูมิจัดการค่าเป็นช่องว่างตามการตั้งค่าช่องว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ล้างค่าเฉพาะจุดที่สองในซีรีส์แรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิฟองอากาศยังใช้เซลล์ขนาด. ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่น ๆ, เพราะเมธอดนั้นจะลบทุกจุดข้อมูลจากคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่แต่มีค่าถือเป็นกรณีแยกจากเซลล์ว่าง. เพื่อรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อนอยู่, ดู [Include Data from Hidden Rows and Columns](/slides/th/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์สมุดงานที่ว่างแสดงว่าข้อมูลหายไป; เซลล์ที่มีค่า `0` แสดงค่าตัวเลขที่ทราบ. ตั้งค่า [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) เป็น `None` เพื่อทำให้เซลล์ว่าง. ศูนย์เชิงตัวเลขจะยังคงเป็นศูนย์โดยไม่คำนึงถึงการตั้งค่าเซลล์ว่าง.

ใช้ [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีการ plot ช่องว่างโดยไม่เติมเซลล์สมุดงานว่างด้วยศูนย์หรือค่าที่ประมาณ.

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีหนึ่งซีรีส์, ล้างค่าของ Day 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด. ไม่จำเป็นต้องมีไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายประเภท, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อซีรีส์. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

    # ปล่อยให้ Day 3 ว่างจริง ๆ ขณะที่ยังคงประเภทและจุดข้อมูลของมัน.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดไว้ก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปโหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์. Day 3 จะเป็นค่าว่างในสมุดงานในทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย. แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อเมื่อประเภทหาย, ดังนั้น `SPAN` ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงด้านบน; คอลัมน์หายและคอลัมน์ที่มีความสูงเป็นศูนย์อาจดูคล้ายกัน. เช่นเดียวกัน, แผนภูมิกระจายที่มีเพียง marker ก็ไม่มีเส้นเชื่อมต่อ. อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างช่องว่างของซีรีส์**

ความกว้างช่องว่างคือพื้นที่ระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการซ้อนทับ, มันเป็นของกลุ่มซีรีส์แม่แทนที่จะเป็นของซีรีส์เดียว. ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ครั้งเดียวสำหรับกลุ่ม. ค่าที่ใหญ่กว่าจะทำให้ช่องว่างระหว่างกลุ่มมากขึ้น; ค่าที่เล็กกว่าจะทำให้กลุ่มแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกเฉพาะงานนำเสนอสุดท้าย:

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

![The gap width](gap_width.png)

## **FAQ**

**ประเภทแผนภูมิใดสนับสนุนข้อมูลซีรีส์?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ซีรีส์ของพวกมันไม่ได้มีโครงสร้างหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น แผนภูมิเข้าประเภทใช้ประเภทและค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิฟองอากาศเพิ่มขนาดฟอง. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทซีรีส์. ตัวเลือกเช่นการซ้อนทับและความกว้างช่องว่างใช้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มซีรีส์ของแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) ประกอบด้วยซีรีส์ที่เข้ากันได้และแชร์การตั้งค่าการ plot ระดับกลุ่ม. แผนภูมิกำหนดค่าผสมสามารถมีได้มากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มที่เข้าถึงผ่านหนึ่งซีรีส์ไม่ได้จำเป็นต้องเปลี่ยนทุกซีรีส์ในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) สร้างซีรีส์ตัวอย่าง, ประเภท, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดทั้งคอลเลกชันซีรีส์และประเภทก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างสมบูรณ์. มี overload ที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้เช่นกัน.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อซีรีส์, ป้ายประเภท, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้อง. เมื่อคุณสร้างข้อมูลกำหนดเอง, รักษาแถวประเภทและแถวค่าซีรีส์ให้สอดคล้องกันเพื่อให้แต่ละจุดถูก plot ภายใต้ประเภทที่ต้องการ.

**จะลบจุดเดียวแทนการลบทั้งซีรีส์ได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งประเภทของจุดเป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบทุกจุดจากซีรีส์นั้น. หากคุณลบประเภทด้วย, ให้อัปเดตทุกซีรีส์เพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันประเภท.

**จุดว่างแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่าเป็นศูนย์, หรือโดยการเชื่อมต่อจุดใกล้เคียง. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ. ดู [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างสมบูรณ์และเปรียบเทียบภาพ.

**ค่าลบจัดรูปอย่างไร?**

สำหรับซีรีส์บาร์, คอลัมน์, และฟองอากาศที่รองรับ, เปิดใช้งาน [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) และตั้งค่า [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดียวด้วย [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). คุณสมบัติเหล่านี้ส่งผลต่อการฟอร์แมต, ไม่ใช่ค่าตัวเลขที่จัดเก็บ.

**การฟอร์แมตใดชนะเมื่อซีรีส์และจุดทั้งสองถูกฟอร์แมต?**

การฟอร์แมตจุดข้อมูลอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ ยังคงใช้ฟอร์แมตซีรีส์ที่ชัดเจนหรือเมื่อไม่มีการกำหนดฟอร์แมตซีรีส์, จะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ. คุณสมบัติกลุ่มเช่นการซ้อนทับและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การเขียนทับฟอร์แมตระดับจุด.

**มีขีดจำกัดจำนวนซีรีส์ที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนซีรีส์คงที่. อย่างไรก็ตาม, ข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจัดเป็นขีดจำกัดที่ใช้ได้จริง.

**ควรปรับอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ในกลุ่มซีรีส์แม่ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น.