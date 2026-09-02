---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- สีของหมวดหมู่
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างของชุด
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย Python."
---
## **ภาพรวม**

แผนภูมิเก็บข้อมูลที่พล็อตไว้ในสมุดงานข้อมูลแผนภูมิ. [ChartSeries](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [ChartDataPoint](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/) ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ของสมุดงาน. วัตถุ [ChartCategory](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartcategory/) ให้ป้ายหรือค่าการจัดกลุ่มที่ใช้ร่วมกันระหว่างชุด. ดังนั้นชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ [ChartDataCell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatacell/) แทนที่จะถูกเก็บเป็นข้อความแสดงผลเท่านั้น.

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป, สมุดงานเริ่มต้นจะใช้แถวที่ 0 สำหรับชื่อชุด, คอลัมน์ที่ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนีแผ่นงาน, แถว, และคอลัมน์ที่ส่งไปยัง [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) เป็นดัชนีเริ่มจากศูนย์. การจัดเรียงนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้. สำหรับการนำเสนอที่โหลดเข้ามา, ตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับต่างกัน:

- การตั้งค่าระดับชุด, เช่น [ChartSeries.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/format/), ให้ลักษณะเริ่มต้นสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าระดับจุดข้อมูล, เช่น [ChartDataPoint.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/format/), เข้ามาแทนที่ลักษณะของชุดสำหรับจุดเดียว.
- การตั้งค่าระดับกลุ่มใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [ChartSeriesGroup](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [ChartSeries.parent_series_group](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/parent_series_group/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่น การทับซ้อนหรือความกว้างของช่องว่าง.

เมื่อไม่ได้ตั้งค่าการเติมแบบจุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. เมื่อมีการฟอร์แมตของชุดและจุดพร้อมกัน, การฟอร์แมตของจุดจะมีลำดับความสำคัญสูงกว่า.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลในแผนภูมิ**

[ChartSeries.overlap](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าไรในแผนภูมิ 2D, จาก -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่. ตั้งค่า [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์แบบกลุ่ม; จะไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม.

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่ประกอบด้วยชุดแรก:

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

![การทับซ้อนของชุดข้อมูล](series_overlap.png)

## **เปลี่ยนสีการเติมของชุดข้อมูล**

ใช้ [ChartSeries.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/format/) เพื่อตั้งค่าการเติมเริ่มต้นสำหรับชุดทั้งหมด. หากจุดมีการเติมที่ระบุไว้แล้ว, การตั้งค่า [ChartDataPoint.format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/format/) จะทับการเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้การเติมสีน้ำเงินทึบกับชุดแรก:

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

![สีของชุดข้อมูล](series_color.png)

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดจะถูกเก็บในสมุดงานข้อมูลแผนภูมิและโดยปกติจะแสดงในตำนาน. ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่ [ChartSeries.name](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/name/) อ้างอิงอยู่ได้. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อชุดข้อมูล](series_name.png)

## **รับสีการเติมอัตโนมัติของชุดข้อมูล**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ. นี่คือสีที่ใช้เมื่อการเติมชุดไม่ได้ถูกกำหนดอย่างชัดเจน. การเรียกเมธอดจะอ่านสีที่คำนวณเท่านั้น; จะไม่กำหนดการเติมใหม่.

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

ตัวอย่างผลลัพธ์สำหรับสไตล์แผนภูมิมาตรฐาน:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีการเติมกลับด้านสำหรับชุดข้อมูลในแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/invert_if_negative/) สามารถแสดงค่าติดลบด้วยสีที่ต่างออกไป. ตั้งการเติมของชุดเป็นสีทึบ, เปิดการกลับด้าน, และกำหนดสีค่าติดลบผ่าน [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). ตัวเลขติดลบจะคงเดิมในสมุดงาน; เพียงแต่สีที่แสดงจะเปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว. แถว 0 ของแผ่นงานมีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่างๆ:

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

![สีการเติมทึบกลับด้าน](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก. จุดนั้นยังได้รับค่าติดลบเพื่อให้เห็นผลกระทบ:

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

เพื่อลบจุดหนึ่งให้ว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์สมุดงานที่สนับสนุนจุดนั้นเป็น `None`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [ChartDataPoint.value](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/value/). จุดข้อมูลจะยังคงอยู่ที่ตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าเรื่องค่าที่ว่างของแผนภูมิ.

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย. ให้ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ. อย่าเรียก [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เมื่อคุณต้องการคงจุดอื่นไว้, เพราะเมธอดนั้นจะลบทุกจุดในคอลเลกชัน.

## **ตั้งค่าความกว้างของช่องว่างระหว่างชุด**

ความกว้างของช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มันเป็นคุณสมบัติของกลุ่มชุดแม่ไม่ใช่ของชุดเดียว. ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) ครั้งเดียวสำหรับกลุ่ม. ค่าที่ใหญ่กว่าจะสร้างช่องว่างมากขึ้นระหว่างกลุ่ม; ค่าที่เล็กกว่าจะทำให้กลุ่มแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกเพียงการนำเสนอสุดท้าย:

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

**ประเภทแผนภูมิใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ใช่ทั้งหมดที่มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น แผนภูมิหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด. ตัวเลือกเช่นการทับซ้อนและความกว้างของช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มชุดข้อมูลในแผนภูมิคืออะไร?**

[ChartSeriesGroup](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/) มีชุดที่เข้ากันได้ซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่มร่วมกัน. แผนภูมิแบบผสมสามารถมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มที่เข้าถึงผ่านชุดหนึ่งไม่ได้หมายความว่าจะเปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, [ShapeCollection.add_chart](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_chart/) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. การ overload ยังสามารถสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้นได้.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน. เมื่อคุณสร้างข้อมูลกำหนดเอง, ให้รักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ภายใต้หมวดหมู่ที่ตั้งใจ.

**จะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `None` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง. ใช้ [ChartDataPointCollection.clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดในชุดนั้น. หากคุณลบหมวดหมู่อีกด้วย, ให้ปรับปรุงทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดที่ว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [Chart.display_blanks_as](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/display_blanks_as/). แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมต่อจุดใกล้เคียง. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่ขาดหายในงานนำเสนอของคุณ.

**ค่าติดลบถูกฟอร์แมตอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ, เปิดใช้งาน [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/invert_if_negative/) และตั้งค่า [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). คุณสามารถเขียนทับพฤติกรรมสำหรับจุดเดียวด้วย [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). คุณสมบัติเหล่านี้ส่งผลต่อการฟอร์แมต, ไม่ใช่ค่าตัวเลขที่เก็บไว้.

**การฟอร์แมตใดชนะเมื่อทั้งชุดและจุดถูกฟอร์แมต?**

การฟอร์แมตระดับจุดข้อมูลโดยตรงจะมีลำดับความสำคัญสูงสุดสำหรับจุดนั้น. จุดอื่น ๆ จะยังคงใช้ฟอร์แมตชุดที่กำหนดไว้หรือ, เมื่อชุดไม่มีการฟอร์แมต, จะใช้สไตล์และธีมของแผนภูมิกำหนดโดยอัตโนมัติ. คุณสมบัติระดับกลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การแทนที่การฟอร์แมตระดับจุด.

**แผนภูมิจำกัดจำนวนชุดได้มากแค่ไหน?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดคงที่แยกต่างหาก. จริง ๆ แล้วข้อจำกัดมาจากข้อจำกัดของไฟล์การนำเสนอ, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ.

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) บนกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าจะเพิ่มช่องว่างระหว่างกลุ่ม, ลดค่าจะทำให้กลุ่มเข้าหากันมากขึ้น.