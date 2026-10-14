---
title: ปรับแต่งแผนภูมวงกลมในงานนำเสนอด้วย Python
linktitle: แผนภูมวงกลม
type: docs
url: /th/python-net/pie-chart/
keywords:
- แผนภูมวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีส่วนของแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมวงกลมใน Python ด้วย Aspose.Slides. กำหนดค่าพล็อตรอง, แสดงป้ายข้อมูล, และใช้สีส่วนอัตโนมัติใน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลมใน Aspose.Slides. มันแสดงวิธีกำหนดค่าตัวเลือกการพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie, และวิธีเปิดใช้งานการระบายสีส่วนของแผนภูมิวงกลมอัตโนมัติสำหรับแผนภูมิวงกลมมาตรฐาน.

ตัวอย่างมุ่งเน้นที่งานปรับแต่งแผนภูมิ เช่น การเพิ่มแผนภูมิลงในสไลด์, การปรับการตั้งค่าชุดข้อมูลและป้ายกำกับ, การแทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยหมวดหมู่และค่าแบบกำหนดเอง, และการบันทึกการนำเสนอที่อัปเดต.

## **ตัวเลือกการพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for Python ผ่าน .NET รองรับตัวเลือกการพล็อตรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie. ตัวเลือกเหล่านี้ควบคุมขนาดของพล็อตรองและวิธีการแบ่งจุดข้อมูลระหว่างพล็อตทั้งสอง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ Pie of Pie ในงานนำเสนอใหม่และแสดงค่าจุดข้อมูลเป็นป้ายกำกับ. [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) property ตั้งค่าขนาดพล็อตรองเป็น 149% ของพล็อตหลัก. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) เลือกการแบ่งตามเปอร์เซ็นต์, และ [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) ตั้งค่าขีดจำกัดเป็น 53%.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # แสดงค่าและกำหนดค่าพล็อตรอง.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **เลือกหมวดหมู่สำหรับพล็อตรอง**

ใช้การแบ่งแบบกำหนดเองเมื่อคุณต้องการจัดกลุ่มหมวดหมู่เฉพาะในพล็อตรองโดยไม่คำนึงถึงค่าร้อยละของพวกมัน. ตัวอย่างเช่น รายงานการขายอาจแสดง Online และ Events ร่วมกันเพื่อให้ผู้อ่านเปรียบเทียบสองช่องทางนี้, แม้ว่าพวกมันจะคิดเป็น 35% และ 10% ของยอดขายรวม.

ตั้งค่า [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) เป็น [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) และเลือกจุดผ่าน [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). เมธอด [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) ของคอลเลกชันรับดัชนีที่เริ่มจากศูนย์ในชุดข้อมูลหรืออ็อบเจ็กต์จุดข้อมูล. ในตัวอย่างนี้, ดัชนี 1 เลือก Online, และจุดที่ดัชนี 3 เลือก Events. Partners ยังถูกเพิ่มชั่วคราว, จากนั้นถูกลบออกโดยใช้ [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # แทนที่ข้อมูลเริ่มต้นด้วยยอดขายตามช่องทาง.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # เลือก Online ตามดัชนีเริ่มจากศูนย์และ Events ตามอ็อบเจ็กต์จุดข้อมูล.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # ยกเว้น Partners จากการเลือกโดยไม่ลบข้อมูลต้นทางของมัน.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) และ Events (10) ปรากฏเป็นส่วนแยกในพล็อตรอง. ในพล็อตหลัก, พวกมันจะรวมเป็นส่วนเดียวที่มีค่า 45, พร้อมกับ Retail (40) และ Partners (15). การลบ Partners จากการเลือกแบบกำหนดเองทำให้มันยังคงอยู่ในพล็อตหลัก; มันไม่ได้ลบหมวดหมู่หรือค่าของมันจากข้อมูลต้นทางของแผนภูมิ.

ภาพต่อไปนี้แสดงงานนำเสนอที่บันทึกใน PowerPoint:

![แผนภูมิ Pie of Pie ที่มี Online และ Events ในพล็อตรองและค่ารวมของพวกมันเป็น 45 ในพล็อตหลัก](pie_of_pie_custom.png)

## **ตั้งค่าสีส่วนของแผนภูมิวงกลมอัตโนมัติ**

Aspose.Slides for Python ผ่าน .NET สามารถกำหนดสีที่แตกต่างให้กับส่วนของแผนภูมิวงกลมอัตโนมัติ. ตัวอย่างต่อไปนี้สร้างแผนภูมิวงกลมที่มีหัวเรื่องอยู่กึ่งกลางและแทนที่ข้อมูลเริ่มต้นด้วยสามหมวดหมู่ไตรมาสและค่าของพวกมัน. [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) property แสดงค่าตัวเลข 20, 50, และ 30 เป็นป้ายกำกับ, ในขณะที่ [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) เปิดใช้งานสีที่แตกต่างสำหรับแต่ละส่วน.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # เพิ่มหัวเรื่องแผนภูมิที่อยู่กึ่งกลาง.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # แทนที่ข้อมูลเริ่มต้นโดยใช้เวิร์กชีตแรก.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # แสดงค่าและกำหนดสีที่แตกต่างให้กับส่วนต่างๆ.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**รูปแบบ Pie of Pie และ Bar of Pie รองรับหรือไม่?**

ใช่, ไลบรารี [รองรับ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ตัวเลือกพล็อตรองสำหรับแผนภูมิวงกลม, รวมถึงประเภท Pie of Pie และ Bar of Pie.

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ใช่, คุณสามารถ [ส่งออกแผนภูมิเป็นภาพ](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (เช่น PNG) โดยไม่ต้องส่งออกงานนำเสนอทั้งหมด.