---
title: "จัดการป้ายกำกับข้อมูลแผนภูมิในงานนำเสนอด้วย Python"
linktitle: "ป้ายกำกับข้อมูล"
type: docs
url: /th/python-net/chart-data-label/
keywords:
- "แผนภูมิ"
- "ป้ายกำกับข้อมูล"
- "ความแม่นยำของข้อมูล"
- "เปอร์เซ็นต์"
- "ระยะห่างของป้าย"
- "ตำแหน่งของป้าย"
- "PowerPoint"
- "การนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "เรียนรู้วิธีเพิ่มและกำหนดรูปแบบป้ายกำกับข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อทำสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **เกริ่นนำ**

ป้ายกำกับข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิ บทความนี้อธิบายวิธีกำหนดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้ายกำกับ การควบคุมป้ายกำกับเกินค่าสูงสุดของแกน การปรับระยะห่างของป้ายกำกับแกนประเภท และการจัดตำแหน่งป้ายกำกับของแผนภูมิเสี้ยว

## **นับป้ายกำกับข้อมูลที่มองเห็นได้**

ใช้ [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) เพื่อตรวจสอบจำนวนป้ายกำกับข้อมูลที่เปิดให้แสดงก่อนเผยแพร่การนำเสนอ ต่างจาก `len(labels)` ที่คืนจำนวนป้ายทั้งหมดในคอลเลกชัน คำสั่งนี้จะคำนึงถึงค่าตั้งต้นของชุดข้อมูลและการตั้งค่าป้ายแต่ละอัน

ตัวอย่างนี้สร้างแผนภูมิแท่งที่มีหนึ่งชุดและสามจุดข้อมูล เข้าถึงคอลเลกชัน [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) ของชุดข้อมูลและพิมพ์จำนวนที่มองเห็นได้เมื่อการตั้งค่าเปลี่ยน: **0, 3, 2, 3**. จำนวนรวมยังคงเป็น **3**.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    series_cell = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_cell, chart.type)

    for i in range(3):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    labels = series.labels
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # ทั้งหมด: 3; มองเห็น: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # มองเห็น: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # มองเห็น: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # มองเห็น: 3
```

รูปแบบป้ายกำกับข้อมูลเริ่มต้นของชุดข้อมูล [default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) ให้การตั้งค่าเริ่มต้น การเปิดใช้งาน [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) จะทำให้แสดงค่าของทั้งสามป้าย การตั้งค่าเป็น `False` ผ่าน [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) ของป้ายหนึ่งจะแทนที่การตั้งค่านั้นสำหรับป้ายที่เลือก การเปิดใช้งาน [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) จะทำให้ป้ายดังกล่าวนับเป็นมองเห็นได้อีกครั้ง แม้ว่าค่าจะยังคงถูกซ่อนอยู่

จำนวนที่มองเห็นได้สะท้อนการตั้งค่าการมองเห็นเท่านั้น ไม่ได้วัดว่าป้ายทับซ้อน ถูกคลิป หรืออ่านได้ในแผนภูมิที่แสดงผล

## **ตั้งความแม่นยำของข้อมูลในป้ายกำกับแผนภูมิ**

ใช้ [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) เพื่อกำหนดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของมันและเปิดป้ายแสดงค่าให้กับชุดแรก รูปแบบ `#,##0.00` แสดงเครื่องหมายคั่นพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าตามพื้นฐาน

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

หากต้องการกำหนดรูปแบบเซลล์ตัวเลขในสมุดงานที่ฝังอยู่ของแผนภูมิ ดูที่ [กำหนดรูปแบบตัวเลขที่กำหนดเองสำหรับเซลล์ในสมุดงาน](/slides/th/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells) ตัวอย่างนั้นยังแสดงป้ายค่าให้สอดคล้องกับรูปแบบเซลล์ต้นทางพร้อมคงค่าตัวเลขที่จัดเก็บไว้

## **แสดงเปอร์เซ็นต์เป็นป้ายกำกับ**

สำหรับแผนภูมิแท่งซ้อน ให้คำนวณแต่ละค่าเป็นเปอร์เซ็นต์ของผลรวมประเภทและกำหนดข้อความให้กับ [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/). ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเริ่มต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด ประเภทที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อลดการหารด้วยศูนย์ หากข้อมูลแผนภูมิเปลี่ยน ให้คำนวณข้อความป้ายกำกับแบบกำหนดเองใหม่

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

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายกำกับแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน ให้ใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) เพื่อแสดงเปอร์เซ็นต์ ตั้งค่า [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) เป็น `False` เพื่อใช้รูปแบบป้ายกำกับแยกจากเซลล์ต้นทาง

ตัวอย่างนี้สร้างแผนภูมิแท่งซ้อน 100% ด้วยชุดสีแดงและสีน้ำเงินในสี่ประเภท แต่ละคู่ค่ามารวมกันเป็น 1 รูปแบบป้ายกำกับ `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาว ขนาด 10 จุด

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

## **อ่านข้อความจริงของป้ายกำกับข้อมูล**

ใช้ [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายกำกับข้อมูล ซึ่งเป็นประโยชน์เมื่อต้องสกัดป้ายสำหรับรายงาน การค้นหาเนื้อหาในงานนำเสนอ หรือการตรวจสอบความถูกต้องของแผนภูมิที่สร้าง ตัวอย่างด้านล่างนี้ รูปแบบป้ายกำกับข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) ผสมผสานชื่อประเภท ชื่อชุดข้อมูลและค่า จุดหนึ่งกำหนดค่าของมันเป็นเปอร์เซ็นต์และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)

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

ค่าที่เก็บในจุดข้อมูลคงเป็น `0.75` แม้ว่าป้ายของมันจะแสดงเป็น `75%` พร้อมกับชื่อประเภทและชื่อชุดข้อมูล ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) จะคืนสตริงป้ายผลลัพธ์ในทั้งสองกรณี ตรวจสอบ [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการสกัดเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายกำกับข้อมูลเกินค่าสูงสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุดของแกน ใช้ [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) เพื่อควบคุมว่าป้ายกำกับข้อมูลของพวกมันจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้าย แต่ไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิแท่งแบบจัดกลุ่ม 2 มิติที่มีค่า 60 และ 120 ตั้งค่า [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) เป็น `False` และ [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) เป็น 100 บนแกนแนวตั้ง สไลด์แรกอนุญาตให้ป้ายแสดงเกินค่าสูงสุด; สำเนาของสไลด์นั้นปิดการแสดง ปัจจัยทั้งสองจะบันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดป้ายค่าโดยใช้ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/). การตั้งค่าระดับแผนภูมิไม่ทำให้ค่าถูกแสดงโดยอัตโนมัติหรือแทนที่การปิดการแสดงค่าของป้ายแต่ละอัน ตัวอย่างนี้เปิดค่าให้กับชุดทั้งหมดและใช้ [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) เพื่อตำแหน่งป้ายที่ด้านนอกของแต่ละคอลัมน์

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

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกแล้วโดย Microsoft PowerPoint เมื่อกำหนดเป็น `True` ป้าย **120** จะมองเห็นได้ที่ขอบบน; เมื่อเป็น `False` จะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ ค่าสูงสุดของแกนคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่าที่ 120 กับค่าสูงสุดของแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่าที่ 120 กับค่าสูงสุดของแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D ที่มีแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิวงกลมและโดนัท ไม่มีกำหนดค่าสูงสุดของแกนในลักษณะนี้
{{% /alert %}}

## **ตั้งระยะห่างป้ายจากแกน**

ใช้ [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทและแกน ค่าที่กำหนดเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิแท่งแบบจัดกลุ่มและตั้งค่า offset ของป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้มีผลต่อป้ายแกนประเภทมากกว่าป้ายที่แนบกับจุดข้อมูลแต่ละจุด

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

บนแผนภูมิกระบอก ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มช่องว่างและทำให้มีพื้นที่สำหรับเส้นเชื่อม

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายของมันด้านนอกส่วนของชิ้น และปรับ offset ของ [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) offset เหล่านี้เป็นค่าที่สัมพันธ์กับความกว้างและความสูงของแผนภูมิ ตามลำดับ

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

![แผนภูมิวงกลมที่มีตำแหน่งป้ายข้อมูลปรับแล้ว](pie-chart-adjusted-label.png)

## **จัดรูปแบบเส้นเชื่อม**

เมื่อป้ายของแผนภูมิกระบอกอยู่ด้านนอกส่วนของชิ้น เส้นเชื่อมช่วยให้ผู้อ่านจับคู่ค่ากับชิ้นที่ถูกต้อง สีที่ต่างกันและเส้นที่หนาขึ้นเล็กน้อยทำให้การเชื่อมต่อเหล่านี้ง่ายต่อการตามติด ในขณะที่ความโปร่งแสงและสไตล์เส้นประทำให้เส้นดูไม่แทรกแซงสายตา

ใช้ [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) เพื่อจัดรูปแบบเส้นเชื่อมระดับคอลเลกชันป้ายกำกับข้อมูลของชุด การตั้งค่าใน `series.labels.leader_lines_format.line` จะใช้กับคอลเลกชันทั้งหมด ไม่ใช่กับป้ายเดี่ยว

ตัวอย่างนี้สร้างแผนภูมิกระบอกด้วยข้อมูลเริ่มต้น แสดงค่าอยู่ด้านนอกชิ้น และเปิด [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/). ย้ายป้ายสองอันให้ห่างจากชิ้นมากขึ้นโดยใช้ offset ของ [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) ซึ่งระบุเป็นส่วนของความกว้างและความสูงของแผนภูมิ ไม่จำเป็นต้องมีงานนำเข้าที่กำหนด

รูปแบบ [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) ของเส้นกำหนดสีฟ้าแบบทึบโดยมีค่าอัลฟา 191 ใน 255 ซึ่งให้ความโปร่งแสงประมาณ 25% [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) ตั้งความหนาเป็น 2 จุด และ [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) ทำให้เส้นเป็นเส้นประ

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

    # ย้ายป้ายสองอันให้ห่างออกจากชิ้นของมัน
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

การเปิดเส้นเชื่อมไม่ได้รับประกันว่าจะมีเส้นปรากฏสำหรับทุกป้าย การมองเห็นขึ้นอยู่กับตำแหน่งของป้ายและพฤติกรรมการจัดวางของแผนภูมิ ในตัวอย่างนี้ ป้ายสองอันที่ย้ายออกมามีเส้นเชื่อมที่มองเห็นได้ ส่วนป้ายที่ยังคงอยู่ใกล้ชิ้นจึงไม่ต้องการ

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกแล้วและแสดงผลด้วย Aspose.Slides:

![แผนภูมิกระบอกที่มีเส้นเชื่อมสีฟ้า โปร่งแสงประมาณครึ่ง เส้นประ เชื่อมสองป้ายด้านนอกกับชิ้นของมัน](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายกำกับข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายกำกับข้อมูลอยู่เหนือพื้นที่แผนภูมิ ชุดข้อมูล A แสดงคอลัมน์ที่มองเห็นได้ ในขณะที่ชุด B และ C ให้ป้ายเพิ่มขึ้น คอลัมน์ของพวกมันจะถูกซ่อนโดยลบการเติมและเส้นขอบ คุณสมบัติ [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) จัดตำแหน่งชุดทั้งสามให้อยู่ตรงศูนย์กลางประเภทเดียวกัน

การตั้งค่า [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) สงวนพื้นที่สำหรับแถวป้าย หลังจาก [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) คำนวณตำแหน่งเริ่มต้นแล้ว [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) และ [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) จะคงการจัดแนวนอนและใช้ offset แนวตั้งเพื่อจัดป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายกำกับข้อมูลที่เชื่อมกับค่าชุด; ส่วนหัวแถวเป็นรูปข้อความแยกต่างหาก

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
            # ซ่อนคอลัมน์ของ B และ C แต่ยังคงป้ายกำกับข้อมูลของพวกมันไว้
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # จัดแนวชุดข้อมูลทั้งสามให้ตรงกับศูนย์กลางประเภทเดียวกัน
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กระชับนี้
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # สำรองพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายกำกับข้อมูล
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
            # คงตำแหน่งแนวนอนเริ่มต้น Y เป็นการเลื่อนจาก
            # ตำแหน่งป้ายกำกับเริ่มต้น แสดงเป็นส่วนของความสูงแผนภูมิ
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # เฉพาะหัวแถวเป็นรูปข้อความแยกต่างหาก
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

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายกำกับข้อมูลเหนือพื้นที่แผนภูมิ](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายกำกับข้อมูลทับซ้อนบนแผนภูมิที่แน่นหนาได้อย่างไร?**

ผสมการวางป้ายโดยอัตโนมัติ, เส้นเชื่อม, และลดขนาดฟอนต์; หากจำเป็นให้ซ่อนไฟล์บางส่วน (เช่น ประเภท) หรือแสดงป้ายเฉพาะสำหรับค่าที่สุดท้ายหรือจุดสำคัญ

**ฉันจะปิดการใช้งานป้ายเฉพาะค่าศูนย์, ค่าน้ำลบ หรือค่าที่ว่างเปล่าได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าน้ำลบ หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้แน่ใจว่ารูปแบบป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

กำหนดฟอนต์และขนาดอย่างเจาะจงและตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการแสดงผลเพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง