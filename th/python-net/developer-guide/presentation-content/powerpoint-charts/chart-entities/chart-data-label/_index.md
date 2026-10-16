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
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย ควบคุมป้ายนอกเหนือค่ามากสุดของแกน การปรับระยะห่างของป้ายแกนประเภท และการจัดตำแหน่งป้ายของแผนภูมิพาย

## **กำหนดความแม่นยำของข้อมูลในป้ายข้อมูลแผนภูมิ**

ใช้ [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายค่าสำหรับชุดข้อมูลแรก รูปแบบ `#,##0.00` จะแสดงตัวคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนแปลงค่าที่อยู่ด้านล่าง

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

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน คำนวณแต่ละค่าตามเปอร์เซ็นต์ของผลรวมประเภทของมันและกำหนดข้อความให้กับ [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด ประเภทที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ คำนวณข้อความป้ายแบบกำหนดเองใหม่หากข้อมูลแผนภูมิมีการเปลี่ยนแปลง

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

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน ใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) เพื่อแสดงเปอร์เซ็นต์ ตั้งค่า [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) เป็น `False` เพื่อใช้รูปแบบป้ายอย่างอิสระจากเซลล์ต้นฉบับ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบซ้อน 100% ที่มีชุดสีแดงและสีน้ำเงินในสี่ประเภท แต่ละคู่ของค่ารวมกันเป็น 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาว ขนาด 10 จุด

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

ใช้ [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล ซึ่งมีประโยชน์เมื่อต้องสกัดป้ายสำหรับรายงาน ค้นหาเนื้อหาในการนำเสนอ หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบป้ายข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) จะรวมชื่อประเภท ชื่อชุดข้อมูล และค่าเข้าด้วยกัน จุดหนึ่งจัดรูปแบบค่าของมันเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)

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

ค่าที่เก็บไว้ในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายของมันจะแสดง `75%` พร้อมกับชื่อประเภทและชื่อชุดข้อมูล ข้อความกำหนดเองแทนที่ข้อความป้ายที่สร้างขึ้น [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) จะคืนสตริงป้ายที่ได้ในกรณีใดกรณีหนึ่ง ตรวจสอบ [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการสกัดเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายข้อมูลเกินค่ามากสุดของแกน**

เมื่อคุณจำกัดช่วงแกนด้วยตนเอง จุดข้อมูลบางจุดอาจเกินค่ามากสุดของมัน ใช้ [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) เพื่อควบคุมว่าจะให้แสดงป้ายข้อมูลของมันหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้าย แต่ไม่เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบกลุ่ม 2D ที่มีค่า 60 และ 120 มันตั้งค่า [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) เป็น `False` และ [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) เป็น 100 บนแกนแนวตั้ง สไลด์แรกอนุญาตให้ป้ายเกินค่ามากสุด; สำเนาของสไลด์นั้นปิดการใช้งานป้าย ทั้งสองสไลด์ถูกบันทึกเป็น `DataLabelsOverMaximum.pptx`.

เปิดป้ายค่าโดยใช้ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). การตั้งค่าระดับแผนภูมิไม่ได้เปิดการแสดงค่าด้วยตัวเองหรือเขียนทับการปิดการแสดงค่าของป้ายแต่ละอัน ตัวอย่างนี้เปิดค่าสำหรับชุดข้อมูลทั้งหมดและใช้ [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) เพื่อตำแหน่งป้ายที่ส่วนปลายนอกของแต่ละคอลัมน์。

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

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกแล้วซึ่งเรนเดอร์โดย Microsoft PowerPoint เมื่อเป็น `True` ป้าย **120** จะมองเห็นได้ที่ขอบบน; เมื่อเป็น `False` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ ค่ามากสุดของแกนยังคงเป็น **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่าที่ 120 พร้อมค่ามากสุดของแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่าที่ 120 พร้อมค่ามากสุดของแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมกับแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิปายและโดนัท จะไม่มีค่ามากสุดของแกนที่จะจำกัดในลักษณะนี้
{{% /alert %}}

## **ตั้งระยะห่างของป้ายจากแกน**

ใช้ [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทและแกน ค่าจะเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและตั้งค่าออฟเซ็ตป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้มีผลต่อป้ายแกนประเภท มากกว่าป้ายที่แนบกับจุดข้อมูลแต่ละจุด。

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

บนแผนภูมิปาย ปรับตำแหน่งป้ายข้อมูลเพื่อปรับปรุงการเว้นระยะและเพิ่มพื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายของมันนอกชิ้นส่วน และปรับออฟเซ็ต [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) ของมัน ออฟเซ็ตเหล่านี้สัมพันธ์กับความกว้างและความสูงของแผนภูมิตามลำดับ

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

![แผนภูมิปายกับตำแหน่งป้ายข้อมูลที่ปรับแล้ว](pie-chart-adjusted-label.png)

## **จัดรูปแบบเส้นนำ**

เมื่อป้ายแผนภูมิปายอยู่ด้านนอกชิ้นส่วน เส้นนำช่วยให้ผู้อ่านจับคู่ค่ากับชิ้นส่วนที่ถูกต้อง สีที่ตัดกันและเส้นที่หนาขึ้นเล็กน้อยสามารถทำให้การเชื่อมต่อเหล่านี้ง่ายต่อการตามได้ ขณะที่ความโปร่งใสและสไตล์เส้นประทำให้เส้นดูไม่รบกวนสายตา

ใช้ [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) เพื่อจัดรูปแบบเส้นนำระดับคอลเลกชันป้ายข้อมูลของชุดข้อมูล การตั้งค่าใน `series.labels.leader_lines_format.line` จะใช้กับคอลเลกชัน ไม่ใช่กับป้ายเดี่ยว

ตัวอย่างนี้สร้างแผนภูมิปายด้วยข้อมูลเริ่มต้น แสดงค่านอกชิ้นส่วน และเปิดใช้งาน [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). มันย้ายป้ายสองอันให้ห่างจากชิ้นส่วนมากขึ้นโดยใช้ [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) ออฟเซ็ต ซึ่งแสดงเป็นเศษส่วนของความกว้างและความสูงของแผนภูมิ ไม่จำเป็นต้องมีพรีเซนเทชันเข้า

เส้นที่มี [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) ตั้งค่าสีฟ้าแบบทึบโดยมีค่าอัลฟ่า 191 จาก 255 ทำให้มีความโปร่งใสประมาณ 25% [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ตั้งความหนาเป็น 2 จุด และ [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) ทำให้เส้นเป็นแบบประหยัด

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # ย้ายป้ายสองอันให้ห่างจากชิ้นส่วนของมันมากขึ้น.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

การเปิดใช้เส้นนำไม่ได้รับประกันว่าจะมีเส้นสำหรับทุกป้าย การมองเห็นขึ้นอยู่กับการวางป้ายและพฤติกรรมการจัดรูปแบบของแผนภูมิ ในตัวอย่างนี้ ป้ายที่ย้ายออกสองอันมีเส้นนำที่มองเห็นได้ ป้ายที่ยังคงอยู่ใกล้ชิ้นส่วนไม่ต้องการเส้นนำ

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกแล้วและเรนเดอร์ด้วย Aspose.Slides:

![แผนภูมิปายกับเส้นนำสีฟ้าแบบประหยัด กึ่งโปร่งใส ที่เชื่อมต่อป้ายสองอันด้านนอกกับชิ้นส่วนของมัน](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลอยู่เหนือพื้นที่พล็อต คุณลักษณะของชุดข้อมูล A แสดงคอลัมน์ที่มองเห็นได้ ในขณะที่ชุดข้อมูล B และ C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกมันถูกซ่อนโดยการลบสีเติมและเส้นขอบ คุณลักษณะ [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) ทำให้ชุดข้อมูลทั้งสามจัดตำแหน่งศูนย์กลางประเภทเดียวกัน

การตั้งค่า [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) จองพื้นที่สำหรับแถวป้าย หลังจากที่ [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) คำนวณตำแหน่งเริ่มต้นแล้ว [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) จะรักษาการจัดแนวนอนและใช้การออฟเซ็ตแนวตั้งเพื่อจัดเรียงป้ายในสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าชุดข้อมูล; เฉพาะหัวแถวเป็นรูปแบบข้อความแยก

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
            # ซ่อนคอลัมน์ของ B และ C แต่ยังคงป้ายข้อมูลไว้.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # จัดตำแหน่งชุดข้อมูลทั้งสามให้ตรงกับศูนย์กลางประเภทเดียวกัน.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # ใช้เส้นตารางน้อยลงสำหรับตัวอย่างแบบกะทัดรัดนี้.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # จองพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายข้อมูล.
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
            # รักษาตำแหน่งแนวนอนเริ่มต้นไว้ Y เป็นการชดเชยจาก
            # ตำแหน่งป้ายเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # เฉพาะหัวแถวเท่านั้นที่เป็นรูปร่างข้อความแยก.
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

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่พล็อต](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลซ้อนทับกันบนแผนภูมิที่แน่นหนาได้อย่างไร?**  
ผสานการวางป้ายอัตโนมัติ, เส้นนำ, และลดขนาดฟอนต์; หากจำเป็น ให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะค่าสูงสุดหรือจุดสำคัญเท่านั้น

**ฉันจะปิดการใช้งานป้ายเฉพาะค่าศูนย์, ค่าเป็นลบ, หรือค่าว่างได้อย่างไร?**  
กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงผลสำหรับค่าที่เป็น 0, ค่าเป็นลบ, หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายคงที่เมื่อตีออกเป็น PDF/รูปภาพได้อย่างไร?**  
ตั้งค่าครอบครัวฟอนต์และขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง