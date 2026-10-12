---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอด้วย Python
linktitle: ป้ายข้อมูล
type: docs
url: /th/python-net/chart-data-label/
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
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น"
---
## **บทนำ**

ป้ายข้อมูลแสดงข้อมูลเกี่ยวกับชุดของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย การควบคุมป้ายเหนือค่าสูงสุดของแกน การปรับระยะห่างของป้ายแกนประเภท และการกำหนดตำแหน่งของป้ายแผนภูมิพาย

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายค่าสำหรับชุดแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าตัวพื้นฐาน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิคอลัมน์ซ้อนกัน ใหคำนวณแต่ละค่เป็นเปอร์เซ็นต์ของผลรวมของหมวดหมู่และกำหนดข้อความไปยัง [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเพียมค่าเริ่มต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด หมวดหมู่ที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ คำนวณข้อความป้ายแบบกำหนดใหม่หากข้อมูลแผนภูมิเปลี่ยนแปลง

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งเครื่องหมายเปอร์เซ็นต์ในป้ายข้อมูลแผนภูมิ**

เมื่อค่าถูกจัดเก็บเป็นเศษส่วน ให้ใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) เพื่อแสดงเปอร์เซ็นต์ ตั้งค่า [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) เป็น `False` เพื่อใช้รูปแบบป้ายแยกจากเซลล์ต้นฉบับ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% พร้อมชุดสีแดงและสีน้ำเงินในสี่หมวดหมู่ แต่ละคู่ของค่ารวมกันได้ 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาว ขนาด 10 จุด

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **อ่านข้อความจริงของป้ายข้อมูล**

ใช้ [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล วิธีนี้มีประโยชน์เมื่อต้องดึงป้ายสำหรับรายงาน ค้นหาข้อมูลในงานพรีเซนเทชัน หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบ [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) เริ่มต้นจะผสานชื่อหมวดหมู่ ชื่อชุดข้อมูล และค่าไว้ด้วยกัน จุดหนึ่งจัดรูปแบบค่าของมันเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

ค่าที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ป้ายจะแสดง `75%` ร่วมกับชื่อหมวดหมู่และชุดข้อมูล ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) จะคืนสตริงป้ายที่ได้ในทั้งสองกรณี ตรวจสอบ [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการดึงป้ายที่มองเห็นได้เท่านั้น

## **ควบคุมป้ายข้อมูลเหนือค่าสูงสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุดของมัน ใช้ [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) เพื่อควบคุมว่าป้ายข้อมูลของพวกเขาจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้าย; ไม่ทำการเปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์กระจุก 2D ด้วยค่าที่ 60 และ 120 ตั้งค่า [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) เป็น `False` และ [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) เป็น 100 บนแกนแนวตั้ง สไลด์แรกอนุญาตให้ป้ายเกินค่าสูงสุด; สำเนาของสไลด์นั้นปิดการทำงานของป้าย ทั้งสองสไลด์ถูกบันทึกใน `DataLabelsOverMaximum.pptx`

เปิดใช้งานป้ายค่าโดยใช้ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). การตั้งค่าที่ระดับแผนภูมิไม่ทำให้แสดงค่าด้วยตนเองหรือแทนที่การปิดการแสดงค่าของป้ายเดี่ยว ตัวอย่างนี้เปิดค่าสำหรับชุดทั้งหมดและใช้ [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) เพื่อวางป้ายที่ปลายนอกของแต่ละคอลัมน์

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกซึ่งเรนเดอร์โดย Microsoft PowerPoint เมื่อ `True` ป้าย **120** จะปรากฏที่ขอบบน; เมื่อ `False` ป้ายจะซ่อนอยู่ ป้าย **60** ยังคงมองเห็นได้ ค่าสูงสุดของแกนคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![แผนภูมิ PowerPoint ที่แสดงป้ายค่ 120 พร้อมค่าสูงสุดของแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ที่ซ่อนป้ายค่ 120 พร้อมค่าสูงสุดของแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิวงและโดนัท จะไม่มีค่าสูงสุดของแกนที่จะจำกัดในลักษณะนี้
{{% /alert %}}

## **ตั้งระยะห่างของป้ายจากแกน**

ใช้ [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทกับแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์กระจุกและตั้งค่า offset ของป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนประเภท ไม่ใช่ป้ายที่แนบกับจุดข้อมูลแต่ละจุด

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ปรับตำแหน่งป้าย**

บนแผนภูมิวง ให้ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มระยะห่างและทำให้มีพื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายของมันนอกส่วนของสไลซ์ และปรับ offset ของ [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) offset เหล่านี้เป็นค่าตามความกว้างและความสูงของแผนภูมิตามลำดับ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![แผนภูมิวงที่ปรับตำแหน่งป้ายข้อมูล](pie-chart-adjusted-label.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลเหนือพื้นที่พล็อต ชุด A แสดงคอลัมน์ที่มองเห็นได้ ในขณะที่ชุด B และชุด C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกเขาถูกซ่อนโดยการลบการเติมสีและเส้นขอบ คุณสมบัติ [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ทำให้ทั้งสามชุดจัดแนวตรงกับศูนย์กลางหมวดหมู่เดียวกัน

การตั้งค่า [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) สงวนพื้นที่สำหรับแถวของป้าย หลังจากที่ [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) คำนวณตำแหน่งเริ่มต้นแล้ว [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) จะรักษาการจัดแนวนอนและใช้ offset แนวตั้งเพื่อจัดเรียงป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าชุด แต่หัวแถวเป็นรูปร่างข้อความแยกต่างหาก

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # ซ่อนคอลัมน์ของ B และ C แต่คงป้ายข้อมูลไว้
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # จัดแนวสามชุดข้อมูลให้ตรงกับศูนย์กลางของหมวดหมู่เดียวกัน
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # ใช้เส้นตารางน้อยลงสำหรับตัวอย่างที่กระชับนี้
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # จองพื้นที่เหนือพล็อตสำหรับสองแถวของป้ายข้อมูล
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # คงตำแหน่งแนวนอนเริ่มต้น. Y เป็นการชดเชยจาก
            # ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # เพียงหัวแถวเท่านั้นที่เป็นรูปข้อความแยกต่างหาก
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![แผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลเหนือพื้นที่พล็อต](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันการทับซ้อนของป้ายข้อมูลบนแผนภูมิที่แน่นได้อย่างไร?**  
ผสานการวางป้ายอัตโนมัติ, เส้นนำ, และขนาดฟอนต์ที่ลดลง; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น หมวดหมู่) หรือแสดงป้ายเฉพาะค่าที่สุดยอดหรือจุดสำคัญ

**ฉันจะปิดการทำงานของป้ายสำหรับค่าเป็นศูนย์, ลบ, หรือว่างได้อย่างไร?**  
กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าลบ, หรือค่าที่ขาดหายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**  
ตั้งค่าครอบครัวฟอนต์และขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์พร้อมใช้งานในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง