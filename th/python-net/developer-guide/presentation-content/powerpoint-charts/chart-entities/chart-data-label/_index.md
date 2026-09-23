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
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลในแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย การปรับช่องว่างของป้ายแกนหมวดหมู่ และการกำหนดตำแหน่งป้ายบนแผนภูมิแบบพาย

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้[ฟอร์แมตจำนวนของค่า](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/number_format_of_values/)เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของแผนภูมิ และเปิดใช้งานป้ายค่าให้กับชุดข้อมูลแรก ฟอร์แมต `#,##0.00` จะแสดงตัวคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าตามฐาน

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

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน ให้คำนวณแต่ละค่าตามเปอร์เซ็นต์ของผลรวมในหมวดหมู่และกำหนดข้อความให้กับ[text_frame_for_overriding](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด หมวดหมู่ที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ คำนวณข้อความป้ายใหม่หากข้อมูลแผนภูมิมีการเปลี่ยนแปลง

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

## **ตั้งค่าเครื่องหมายเปอร์เซ็นต์ในป้ายแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน ให้ใช้[number_format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabelformat/number_format/)เพื่อแสดงเปอร์เซ็นต์ ตั้งค่า[is_number_format_linked_to_source](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/)เป็น `False` เพื่อใช้ฟอร์แมตป้ายโดยอิสระจากเซลล์ต้นฉบับ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% ด้วยชุดข้อมูลสีแดงและสีน้ำเงินในสี่หมวด หมู่ละค่าคู่รวมกันเป็น 1 ฟอร์แมตป้าย `0.0%` จะแสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาว ขนาด 10 จุด

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

ใช้[get_actual_label_text](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/get_actual_label_text/)เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล มีประโยชน์เมื่อดึงป้ายเพื่อทำรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือทำการตรวจสอบแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง ฟอร์แมตป้ายข้อมูลเริ่มต้น[data label format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabelformat/) รวมชื่อหมวด ชื่อชุดข้อมูลและค่า จุดหนึ่งจัดรูปแบบค่าเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก[text_frame_for_overriding](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/)

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

ตัวเลขที่เก็บในจุดข้อมูลคงเป็น `0.75` แม้ว่าป้ายจะแสดง `75%` พร้อมกับชื่อหมวดและชุดข้อมูล ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [get_actual_label_text](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) จะคืนสตริงป้ายในทั้งสองกรณี ตรวจสอบ[is_visible](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/is_visible/) แยกต่างหากตามที่แสดงข้างต้นเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้

## **ตั้งค่าระยะห่างของป้ายจากแกน**

ใช้[label_offset](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/axis/label_offset/)เพื่อควบคุมระยะห่างระหว่างป้ายแกนหมวดกับแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและตั้งค่าoffsetป้ายแกนนอนเป็น 500 การตั้งค่านี้มีผลต่อป้ายแกนหมวดมากกว่าป้ายที่แนบกับจุดข้อมูลแต่ละจุด

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

บนแผนภูมิพาย ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มช่องว่างและให้พื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายนอกส่วนของพาย และปรับoffset[x](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/x/)และ[y](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datalabel/y/) ของมัน offset เหล่านี้เป็นค่าอิสระจากความกว้างและความสูงของแผนภูมิ

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **FAQ**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิที่หนาแน่นได้อย่างไร?**

ผสานการจัดวางป้ายอัตโนมัติ เส้นนำ และขนาดฟอนต์ที่ลดลง หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น หมวด) หรือแสดงป้ายเฉพาะค่าขัลหรือจุดสำคัญเท่านั้น

**ฉันจะปิดการแสดงป้ายสำหรับค่าเป็นศูนย์ ลบล้าง หรือว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าเชิงลบ หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ป้ายคงที่เมื่อนำออกเป็น PDF/ภาพได้อย่างไร?**

กำหนดฟอนต์ตระกูลและขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง