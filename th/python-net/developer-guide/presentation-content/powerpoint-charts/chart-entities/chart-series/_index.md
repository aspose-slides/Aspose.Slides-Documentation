---
title: จัดการซีรีส์ข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ซีรีส์ข้อมูล
type: docs
url: /th/python-net/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การทับของซีรีส์
- สีของซีรีส์
- สีของหมวด
- ชื่อซีรีส์
- จุดข้อมูล
- ช่องว่างของซีรีส์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์แผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การทับ, ความกว้างช่องว่าง, และค่าลบในงานนำเสนอด้วย Python."
---
## **ภาพรวม**

แผนภูมิจัดเก็บข้อมูลที่พล็อตไว้ในสมุดงานข้อมูลแผนภูมิ. [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) ในชุดอ้างอิงถึงหนึ่งหรือหลายเซลล์ของสมุดงาน. วัตถุ [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุด. ชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/) แทนที่จะเก็บเป็นข้อความที่แสดงเท่านั้น.

สำหรับแผนภูมิเชิงหมวดทั่วไป, สมุดงานเริ่มต้นใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวด, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนี Worksheet, แถว, และคอลัมน์ที่ส่งให้ [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) เป็นศูนย์ฐาน. รูปแบบนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้. สำหรับงานนำเสนอที่โหลดมาแล้ว, ตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวด, และจุดข้อมูลก่อนเปลี่ยนค่าในสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับขอบเขตต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในชุดหนึ่ง.
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), จะครอบคลุมลักษณะชุดสำหรับจุดเดียว.
- การตั้งค่ากลุ่มจะใช้กับชุดที่เข้ากันได้ที่อยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับหรือความกว้างช่องว่าง.

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดโดยชัดเจน, รูปแบบและธีมของแผนภูมิกำหนดลักษณะอัตโนมัติ. เมื่อมีการกำหนดทั้งรูปแบบชุดและรูปแบบจุด, การกำหนดรูปแบบจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![ซีรีส์แผนภูมิ PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับของซีรีส์แผนภูมิ**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ทับกันเท่าใดในแผนภูมิ 2 มิติ, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มชุดแม่. ตั้งค่า [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; มันจะไม่กระทบต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิกลาง.

ตัวอย่างต่อไปนี้ตั้งค่าการทับสำหรับกลุ่มที่มีชุดแรก:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่, และค่า.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การทับของซีรีส์](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

ใช้ [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) เพื่อกำหนดสีเติมเริ่มต้นสำหรับทั้งชุด. หากจุดมีการกำหนดสีเติมโดยชัดเจน, การตั้งค่า [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) จะครอบคลุมสีเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมแบบโซลิดสีฟ้าสำหรับชุดแรก:

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

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกเก็บไว้ในสมุดงานข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย. ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/) ได้. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อของซีรีส์](series_name.png)

### **สร้างซีรีส์โดยใช้ชื่อจากหลายเซลล์**

ชื่อซีรีส์แบบผสมเป็นประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกเก็บในเซลล์สมุดงานแยกกัน. ตัวอย่างเช่น, คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อซีรีส์เดียวขณะยังคงเชื่อมโยงแต่ละส่วนกับเซลล์ต้นทางของพวกมัน.

ใช้ [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) เพื่อดึงช่วงชื่อ, แล้วส่งคอลเลกชันนั้นไปที่ [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). พารามิเตอร์ `skip_hidden_cells` ควบคุมว่าควรรวมเซลล์ที่ซ่อนอยู่หรือไม่: `True` จะไม่รวม, `False` จะรวม. ตัวอย่างนี้ใช้ `False` เพื่อรวมทุกเซลล์ในช่วงชื่อ.

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีหนึ่งชุดและสองจุดข้อมูล. เซลล์ B1:C1 มีเพียงชื่อซีรีส์; A2:A3 มีป้ายหมวด, และ B2:B3 มีค่าตัวเลข.

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

    # สองเซลล์นี้ให้ชื่อซีรีส์.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # เซลล์แยกต่างหากให้ค่าหมวดและจุดข้อมูลตัวเลข.
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

ชื่อซีรีส์ที่ได้คือ `Product A 2026`, มีช่องว่างระหว่างค่าจากสองเซลล์. คำอธิบายแสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์. ภาพด้านล่างถูกเรนเดอร์จากงานนำเสนอที่บันทึกไว้:

![แผนภูมิคอลัมน์ที่มีค่าตะวันเหนือและใต้และชื่อซีรีส์แบบผสม Product A 2026 ในคำอธิบาย](composite_series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) คืนค่าสีที่คำนวณจากดัชนีชุดและรูปแบบแผนภูมิ. นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดโดยชัดเจน. การเรียกเมธอดจะอ่านสีที่คำนวณ; ไม่ได้กำหนดสีเติมใหม่.

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

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

ผลลัพธ์ตัวอย่างสำหรับรูปแบบแผนภูมิเริ่มต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่แท้จริงขึ้นอยู่กับรูปแบบแผนภูมิและธีม.

## **ตั้งค่าสีเติมกลับรายการสำหรับซีรีส์แผนภูมิ**

สำหรับซีรีส์บาร์, คอลัมน์, และบับเบิล, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าสีเติมปกติเป็นโซลิด, เปิดการกลับรายการ, และกำหนดสีค่าลบผ่าน [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). ตัวเลขลบจะไม่เปลี่ยนในสมุดงาน; มีเพียงสีแสดงที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนค่าข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว. แถว Worksheet 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวด, และคอลัมน์ 1 มีค่า:

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

![สีเติมโซลิดที่กลับรายการ](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับรายการสำหรับจุดเดียวผ่าน [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). ในตัวอย่างต่อไปนี้, การกลับรายการถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก. จุดนั้นยังได้รับค่าลบเพื่อให้เห็นผล:

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

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์สมุดงานที่สนับสนุนเป็น `None`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้สามารถเข้าถึงผ่าน [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). จุดข้อมูลจะคงอยู่ที่ตำแหน่งหมวดเดียวกัน, แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาด. ให้ล้างเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่นไว้, เพราะเมธอดนั้นจะลบทุกจุดในคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่ที่มีค่าเป็นกรณีแยกต่างหากจากเซลล์ว่าง. เพื่อตั้งค่าให้รวมหรือไม่รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่, ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์สมุดงานว่างแสดงถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่ทราบ. ตั้งค่า [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) เป็น `None` เพื่อทำให้เซลล์เป็นว่าง. ศูนย์ตัวเลขจะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร.

ใช้ [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีการพล็อตค่าว่าง, โดยไม่ต้องเติมเซลล์สมุดงานว่างด้วยศูนย์หรือค่าที่ประมวลผล.

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบเต็มที่สร้างแผนภูมิเส้นที่มีหนึ่งชุด, ลบค่าของวันที่ 3, และบันทึกแผนภูมิเดียวกันโดยแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) ใช้ Worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวด, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

    # ปล่อยให้วัน 3 เป็นค่าว่างจริง ๆ ในขณะที่ยังคงหมวดและจุดข้อมูลของมันไว้.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, กำหนดโหมดที่ต้องการและบันทึกงานนำเสนอครั้งเดียวแทนการวนลูปผ่านโหมดต่างๆ.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์. วันที่ 3 เป็นว่างในสมุดงานในทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นหยุดที่วันที่ 3, Zero ทำให้เส้นลดลงเป็นศูนย์, และ Span เชื่อมวันที่ 2 ไปยังวันที่ 4.](display_blanks_as.png)

ผลกระทบที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย. แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมข้ามหมวดที่หายไป, ดังนั้น `SPAN` ไม่สามารถสร้างส่วนเชื่อมที่แสดงข้างต้น; คอลัมน์ที่หายไปและคอลัมน์ศูนย์สูงอาจดูคล้ายกัน. เช่นเดียวกับแผนภูมิกระจายที่มีเครื่องหมายเท่านั้นไม่มีเส้นเชื่อม. อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างช่องว่างของซีรีส์**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เหมือนกับการทับ, มันเป็นของกลุ่มชุดแม่ไม่ใช่ของชุดเดียว. ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ครั้งเดียวสำหรับกลุ่ม. ค่ามากกว่าจะเพิ่มช่องว่างระหว่างกลุ่ม; ค่าน้อยกว่าจะทำให้กลุ่มแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกงานนำเสนอสุดท้ายเท่านั้น:

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

![ความกว้างช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดรองรับข้อมูลซีรีส์?**

ทุกแผนภูมิที่ระบุใน enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ซีรีส์ของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น, แผนภูมิเชิงหมวดใช้หมวดและค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทซีรีส์. ตัวเลือกเช่นการทับและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มซีรีส์ของแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) ประกอบด้วยซีรีส์ที่เข้ากันได้ที่แชร์การตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิกลางสามารถมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งไม่จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) สร้างซีรีส์ตัวอย่าง, หมวด, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งคอลเลกชันซีรีส์และหมวดก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างสมบูรณ์. มี overload ที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้ด้วย.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อซีรีส์, ป้ายหมวด, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิเกี่ยวข้อง. เมื่อคุณสร้างข้อมูลกำหนดเอง, รักษาแถวหมวดและแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดที่ต้องการ.

**จะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งหมวดของจุดเป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น. หากคุณลบหมวดด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวด.

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมจุดใกล้เคียง. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ. ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างครบถ้วนและเปรียบเทียบภาพ.

**ค่าลบถูกจัดรูปแบบอย่างไร?**

สำหรับซีรีส์บาร์, คอลัมน์, และบับเบิลที่รองรับ, เปิดใช้ [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) และตั้งค่า [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). คุณสามารถครอบคลุมพฤติกรรมสำหรับจุดเดี่ยวด้วย [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). คุณสมบัติเหล่านี้มีผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ.

**รูปแบบใดชนะเมื่อทั้งชุดและจุดได้รับการจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลอย่างชัดเจนมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่นจะใช้รูปแบบชุดที่ชัดเจนหรือ, เมื่อไม่มีการกำหนดรูปแบบชุด, จะใช้รูปแบบแผนภูมิและธีมอัตโนมัติ. คุณสมบัติของกลุ่มเช่นการทับและความกว้างช่องว่างควบคุมการจัดวางและไม่ได้เป็นการครอบคลุมการจัดรูปแบบระดับจุด.

**แผนภูมิสามารถมีซีรีส์ได้มากเท่าใด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนซีรีส์คงที่. อย่างไรก็ตาม, ข้อจำกัดของไฟล์การนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่ทำให้ใช้งานได้จริง.

**ควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) บนกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มใกล้กันมากขึ้น.