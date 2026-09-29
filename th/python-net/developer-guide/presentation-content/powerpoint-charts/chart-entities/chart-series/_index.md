---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- สีหมวดหมู่
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างของชุด
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าลบในงานนำเสนอด้วย Python."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่วาดไว้ใน workbook ข้อมูลแผนภูมิ. A [ChartSeries](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/) แทนค่าชุดหนึ่งที่เกี่ยวข้องกัน, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/) ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ใน workbook. วัตถุ [ChartCategory](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุด. ดังนั้นชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatacell/) แทนที่จะเก็บเป็นข้อความแสดงผลเท่านั้น.

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป, workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนี worksheet, แถว, และคอลัมน์ที่ส่งให้ [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) เป็นค่าตั้งต้นที่เริ่มจากศูนย์. การจัดเรียงนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรถือว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้. สำหรับพรีเซนเทชันที่โหลดเข้ามา, ตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของ workbook.

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/format/), ให้ลักษณะการแสดงผลเริ่มต้นสำหรับทุกจุดในชุดหนึ่ง.
- การตั้งค่าจุดข้อมูล, เช่น [ChartDataPoint.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/format/), จะเขียนทับลักษณะชุดสำหรับจุดเดียว.
- การตั้งค่ากลุ่มใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/). เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/parent_series_group/) เมื่อคุณต้องการกำหนดตัวเลือกเช่น overlap หรือ gap width.

เมื่อไม่มีการกำหนดการเติมสีจุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. หากมีการกำหนดรูปแบบทั้งชุดและจุด, การกำหนดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่า Overlap ของชุดแผนภูมิ**

[ChartSeries.overlap](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ทับกันมากเพียงใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มชุดพาเรนท์. ตั้งค่า [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดที่ไม่มีความเกี่ยวข้องในแผนภูมิแบบผสม.

ตัวอย่างต่อไปนี้ตั้งค่า overlap สำหรับกลุ่มที่มีชุดแรก:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [ChartSeries.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/format/) เพื่อกำหนดการเติมสีเริ่มต้นสำหรับชุดทั้งหมด. หากจุดหนึ่งมีการเติมสีอย่างชัดเจน, การตั้งค่า [ChartDataPoint.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/format/) ของจุดนั้นจะเขียนทับการเติมสีของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าแบบทึบกับชุดแรก:

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

ชื่อชุดถูกเก็บใน workbook ข้อมูลแผนภูมิและปกติจะแสดงใน legend. ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบ clustered, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [ChartSeries.name](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/name/) ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

## **รับสีเติมอัตโนมัติของชุด**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) คืนสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ. นี้คือสีที่ใช้เมื่อการเติมสีของชุดไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดจะอ่านสีที่คำนวณได้; ไม่ได้กำหนดการเติมสีใหม่.

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเ�เริ่มต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้ขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าการเติมสีกลับ (Invert) สำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/invert_if_negative/) สามารถแสดงค่าลบด้วยสีเติมที่แตกต่างกัน. ตั้งค่าการเติมสีของชุดเป็นแบบทึบ, เปิดการกลับค่า, และกำหนดสีค่าลบผ่าน [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). ตัวเลขลบจะยังคงอยู่ใน workbook; เพียงสีการแสดงผลที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว. แถว worksheet 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่า:

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

![สีเติมแบบกลับของชุด](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับค่าสำหรับจุดเดียวผ่าน [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). ในตัวอย่างต่อไปนี้ การกลับค่าสำหรับชุดถูกปิดและเปิดเฉพาะจุดที่เลือก. จุดนั้นยังได้รับค่าลบเพื่อให้เอฟเฟกต์ปรากฏ:

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

## **ลบค่าข้อมูลจุดเฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์ workbook ที่สนับสนุนเป็น `None`. สำหรับแผนภูมิคอลัมน์, ค่าที่แสดงผลสามารถเข้าถึงได้ผ่าน [ChartDataPoint.value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/value/). จุดข้อมูลจะยืดอยู่ในตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจะถือค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก:

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

แผนภูมิสเกลอร์ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาด. ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointcollection/clear/) หากต้องการเก็บจุดอื่นไว้, เพราะเมธอดนั้นจะลบทุกจุดจากคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนไว้ซึ่งมีค่าเป็นกรณีที่ต่างจากเซลล์ว่าง. เพื่อรวมหรือไม่รวมข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อน, ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์ workbook ที่ว่างแสดงถึงข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่ทราบ. ตั้งค่า [ChartDataCell.value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatacell/value/) เป็น `None` เพื่อทำให้เซลล์เป็นค่าว่าง. ตัวเลขศูนย์จะยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร.

ใช้ [Chart.display_blanks_as](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/display_blanks_as/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง. การตั้งค้านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีการวาดค่าว่าง, โดยไม่ต้องเติมค่า `0` หรือค่าประมาณในเซลล์ workbook ที่ว่าง.

ตัวอย่างต่อไปนี้เป็นตัวอย่างครบวงจรที่สร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าของ Day 3, และบันทึกแผนภูมิเดียวกันในแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 มีชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

    # ทำให้ Day 3 ว่างจริง ๆ ในขณะที่คงหมวดหมู่และจุดข้อมูลไว้
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

แต่ละไฟล์เอาต์พุตจะเก็บโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, ให้กำหนดโหมดที่ต้องการและบันทึกพรีเซนเทชันครั้งเดียวแทนที่จะวนลูปผ่านโหมดทั้งหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม. Day 3 เป็นค่าว่างใน workbook ทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นหยุดที่ Day 3, Zero ทำให้เส้นลดลงเป็นศูนย์, และ Span เชื่อม Day 2 ไป Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย. แผนภูมิบาร์และคอลัมน์ไม่มีเส้นเชื่อมข้ามหมวดหมู่ที่หายไป, ดังนั้น `SPAN` ไม่สามารถสร้างส่วนเชื่อมที่แสดงข้างต้น; คอลัมน์ที่หายไปและคอลัมน์สูงศูนย์อาจดูคล้ายกัน. เช่นกัน, แผนภูมิสเก็ตเตอร์ที่มีเพียงมาร์กเกอร์ก็ไม่มีเส้นเชื่อม. อย่าสร้างความคาดหวังว่าจะได้ผลลัพธ์ที่แตกต่างสามแบบในทุกประเภทแผนภูมิ; ตรวจสอบเอาต์พุตสำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด (Gap Width)**

Gap width คือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับ overlap, มันเป็นของกลุ่มชุดพาเรนท์ ไม่ได้เป็นของชุดเดียว. ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ครั้งเดียวสำหรับกลุ่ม. ค่ามากจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น; ค่าน้อยจะทำให้กลุ่มใกล้กันขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกพรีเซนเทชันขั้นสุดท้ายเท่านั้น:

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

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่รองรับชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น แผนภูมิประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิสเก็ตเตอร์ใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด. ตัวเลือกเช่น overlap และ gap width ใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**ชุดแผนภูมิกลุ่ม (Chart Series Group) คืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้ซึ่งแบ่งปันการตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิแบบผสมสามารถมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งไม่จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิใหม่ที่สร้างขึ้นมามีข้อมูลเริ่มต้นหรือไม่?**

มี. โดยค่าเริ่มต้น, [ShapeCollection.add_chart](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_chart/) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลัมน์ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. การ overload ยังสามารถสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้นได้.

**วัตถุแผนภูมิเกี่ยวข้องกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/). การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตรงนั้น. เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, ให้รักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดวางภายใต้หมวดหมู่ที่ตั้งใจ.

**ฉันจะลบจุดเดียวแทนที่จะลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อให้จุดยังคงตำแหน่งหมวดหมู่เป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น. หากคุณลบหมวดหมู่อีกด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [Chart.display_blanks_as](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/display_blanks_as/). แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็น Gap, เป็นค่า Zero, หรือโดยการเชื่อมจุดใกล้เคียงกัน. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในพรีเซนเทชันของคุณ. ดูที่ [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างครบและการเปรียบเทียบภาพ.

**ค่าลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ, เปิด [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/invert_if_negative/) และตั้งค่า [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดียวโดยใช้ [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). คุณสมบัติเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ใช่ค่าตัวเลขที่จัดเก็บ.

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่นๆ จะใช้การจัดรูปแบบชุดที่กำหนดหรือ, หากชุดไม่ได้กำหนด, สไตล์และธีมของแผนภูมิโดยอัตโนมัติ. คุณสมบัติกลุ่มเช่น overlap และ gap width ควบคุมการจัดวางและไม่ใช่การเขียนทับการจัดรูปแบบระดับจุด.

**มีขีดจำกัดจำนวนชุดที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดอย่างแยกต่างหาก. อย่างไรก็ตาม ข้อจำกัดของไฟล์พรีเซนเทชัน, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่เหมาะสมในทางปฏิบัติ.

**ควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) บนกลุ่มชุดพาเรนท์ที่เหมาะสม. เพิ่มค่าสำหรับขยายช่องว่างระหว่างกลุ่ม, หรือ ลดค่าเพื่อทำให้กลุ่มใกล้กันมากขึ้น.