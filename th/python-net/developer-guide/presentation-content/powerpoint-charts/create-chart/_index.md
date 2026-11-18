---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ใน Python
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/python-net/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิต้นไม้
- แผนภูมหุ้น
- แผนภูมิกล่องและเส้นวิสเกอร์
- แผนภูมิกรวย
- แผนภูมิ Sunburst
- แผนภูมหิสโตแกรม
- แผนภูมิเรดาร์
- แผนภูมิหลายหมวดหมู่
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for Python via .NET เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานได้จริงใน Python."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำโดยละเอียดเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for Python via .NET คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม, เติมข้อมูลให้กับแผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการด้านการออกแบบของคุณ ตลอดบทความ ตัวอย่างโค้ดที่ละเอียดจะแสดงแต่ละขั้นตอน ตั้งแต่การเริ่มต้น Presentation และออบเจ็กต์แผนภูมิ ไปจนถึงการกำหนดซีรีส์, แกน, และคำอธิบาย ด้วยการทำตามคำแนะนำนี้ คุณจะเข้าใจอย่างลึกซึ้งว่าต้องผนวกการสร้างแผนภูมิกระ动态เข้ากับแอปพลิเคชัน Python ของคุณอย่างไร เพื่อให้การสร้างงานนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้เห็นข้อมูลได้อย่างรวดเร็วและสังเกตข้อมูลเชิงลึกที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ใช้แผนภูมิคุณสามารถ:

* สรุป, ย่อ, หรือสังเคราะห์ข้อมูลจำนวนมากในสไลด์เดียวของการนำเสนอ;
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล;
* สรุปแนวทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดที่กำหนด;
* ระบุค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีความหมาย;
* สื่อสารหรือแสดงข้อมูลซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งมีแม่แบบสำหรับการออกแบบแผนภูมิต่าง ๆ มากมาย ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิดั้งเดิม) และแผนภูมิแบบกำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้การนับจำนวน [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ภายใต้โมดูล [aspose.slides.charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) ค่าต่างๆใน enumeration นี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม**

ตัวอย่างนี้ใช้ [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อสร้างแผนภูมิคอลัมน์แบบจัดกลุ่มที่เปรียบเทียบสองซีรีส์ในสามประเภท ซีรีส์ใช้สีเติมสีแดงและสีเขียว, และป้ายชื่อแต่ละรายการแสดงชื่อประเภท, ชื่อซีรีส์, และค่าต่าง ๆ ดัชนีแผ่นงาน 0 หมายถึงแผ่นแรกในสมุดงานแผนภูมิที่ฝังอยู่

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series[0]

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    series = chart.chart_data.series[1]

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 60)
    series.data_points.add_data_point_for_bar_series(value_cell)

    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิคอลัมน์แบบจัดกลุ่ม](clustered_column_chart.png)

### **สร้างแผนภูมิกระจาย**

แผนภูมิกระจาย (หรือที่เรียกว่ากราฟกระจายหรือกราฟ x‑y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิกระจายเมื่อ:

* คุณมีข้อมูลตัวเลขเป็นคู่;
* คุณมีสองตัวแปรที่จับคู่กันได้ดี;
* คุณต้องการกำหนดว่าตัวแปรทั้งสองมีความสัมพันธ์หรือไม่;
* คุณมีตัวแปรอิสระที่มีค่าได้หลายค่าสำหรับตัวแปรตาม

ตัวอย่างนี้พล็อตสองชุดของค่าตำแหน่ง x‑y ชุดแรกใช้เส้นตรงพร้อมสัญลักษณ์ดาว, ส่วนชุดที่สองใช้เส้นโค้งพร้อมสัญลักษณ์วงกลม; ทั้งสองใช้ [ขนาด](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/size/) 10 พิกเซล คุณสมบัติ [สัญลักษณ์](https://reference.aspose.com/slides/python-net/aspose.slides.charts/marker/symbol/) ควบคุมรูปทรงของสัญลักษณ์

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()

    series_name_cell = workbook.get_cell(worksheet_index, 1, 1, "Series 1")
    chart.chart_data.series.add(series_name_cell, chart.type)
    series_name_cell = workbook.get_cell(worksheet_index, 1, 3, "Series 2")
    chart.chart_data.series.add(series_name_cell, chart.type)

    series = chart.chart_data.series[0]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 2, 3)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 2, 10)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    series = chart.chart_data.series[1]

    x_value_cell = workbook.get_cell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 2, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.get_cell(worksheet_index, 3, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.get_cell(worksheet_index, 4, 4, 2)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    x_value_cell = workbook.get_cell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.get_cell(worksheet_index, 5, 4, 1)
    series.data_points.add_data_point_for_scatter_series(x_value_cell, y_value_cell)

    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิกระจาย](scatter_chart.png)

### **สร้างแผนภูมิวงกลม**

แผนภูมิวงกลมเหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายชื่อประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีหลายส่วนหรือหลายป้ายชื่อ คุณอาจพิจารณาใช้แผนภูมิจุดแทน

ตัวอย่างนี้สร้างแผนภูมิวงกลมที่มีค่าตามไตรมาสสามค่า แต่ละส่วนมีการเติมสีและขอบที่กำหนดเอง, และป้ายชื่อแสดงการผสมของค่า, ร้อยละ, และข้อมูลซีรีส์ คุณสมบัติ [first_slice_angle](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/first_slice_angle/) กำหนดให้ส่วนแรกเริ่มที่ 180 องศา

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    category_cell = workbook.get_cell(0, 1, 0, "1st Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "2nd Qtr")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "3rd Qtr")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 20)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 50)
    series.data_points.add_data_point_for_pie_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 30)
    series.data_points.add_data_point_for_pie_series(value_cell)

    chart.chart_data.series_groups[0].is_color_varied = True

    first_slice = series.data_points[0]
    first_slice.format.fill.fill_type = slides.FillType.SOLID
    first_slice.format.fill.solid_fill_color.color = draw.Color.cyan

    first_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    first_slice.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    first_slice.format.line.width = 3.0
    first_slice.format.line.style = slides.LineStyle.THIN_THICK
    first_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH

    second_slice = series.data_points[1]
    second_slice.format.fill.fill_type = slides.FillType.SOLID
    second_slice.format.fill.solid_fill_color.color = draw.Color.brown

    second_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    second_slice.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    second_slice.format.line.width = 3.0
    second_slice.format.line.style = slides.LineStyle.SINGLE
    second_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    third_slice = series.data_points[2]
    third_slice.format.fill.fill_type = slides.FillType.SOLID
    third_slice.format.fill.solid_fill_color.color = draw.Color.coral

    third_slice.format.line.fill_format.fill_type = slides.FillType.SOLID
    third_slice.format.line.fill_format.solid_fill_color.color = draw.Color.red
    third_slice.format.line.width = 2.0
    third_slice.format.line.style = slides.LineStyle.THIN_THIN
    third_slice.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    first_label = series.data_points[0].label
    first_label.data_label_format.show_value = True

    second_label = series.data_points[1].label
    second_label.data_label_format.show_value = True
    second_label.data_label_format.show_legend_key = True
    second_label.data_label_format.show_percentage = True

    third_label = series.data_points[2].label
    third_label.data_label_format.show_series_name = True
    third_label.data_label_format.show_percentage = True

    series.labels.default_data_label_format.show_leader_lines = True

    chart.chart_data.series_groups[0].first_slice_angle = 180

    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมวงกลม](pie_chart.png)

เพื่อปรับปรุงความอ่านง่ายของป้ายชื่อที่อยู่นอกวงกลม ดูที่ [Format Leader Lines](/slides/th/python-net/chart-data-label/#format-leader-lines) สำหรับตัวอย่างที่จัดตำแหน่งป้ายชื่อและปรับสี, ความกว้าง, ความโปร่งใส, และรูปแบบขีดของเส้น

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือที่เรียกว่ากราฟเส้น) เหมาะเมื่อคุณต้องการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาไหลไป ด้วยแผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติในซีรีส์ข้อมูล, และอื่น ๆ

ตัวอย่างนี้ใช้ [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อสร้างแผนภูมิเส้นพร้อมซีรีส์และประเภทเริ่มต้น, จากนั้นบันทึก Presentation เป็น PPTX

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    presentation.save("lineChart.pptx", slides.export.SaveFormat.PPTX)
```

โดยค่าเริ่มต้นจุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นประ ให้ตั้งค่า [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) จาก [LineDashStyle](https://reference.aspose.com/slides/python-net/aspose.slides/linedashstyle/)

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    line_chart = slide.shapes.add_chart(charts.ChartType.LINE, 20, 20, 500, 300)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH
```

ผลลัพธ์:

![แผนภูมิเส้น](line_chart.png)

### **สร้างแผนภูมิต้นไม้**

แผนภูมิต้นไม้เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของประเภทข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้สนับสนุนหลักในแต่ละประเภทอย่างรวดเร็ว

ตัวอย่างนี้สร้างแผนภูมิต้นไม้ที่มีแปกรายการแปดรายการจัดเป็นสี่ต้นและสองกิ่ง การเรียกใช้เมธอด [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) จะกำหนดต้นขั้นที่ 1 และกิ่งขั้นที่ 2 ค่าแต่ละค่าเป็นตัวกำหนดขนาดสี่เหลี่ยมสัมพัทธ์, ป้ายชื่อประเภทและป้ายชื่อพาเรนท์ที่ซ้อนกันบ่งบอกลำดับขั้น

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # สาขา 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # สาขา 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_treemap_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_treemap_series(value_cell)

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("Treemap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิต้นไม้](treemap_chart.png)

### **สร้างแผนภูมือน้ำตก**

แผนภูมือน้ำตกแสดงว่าการเปลี่ยนแปลงบวกและลบมีส่วนทำให้ค่ารวมสุดท้ายเป็นเท่าใด ตัวอย่างเช่น การสรุปกำไรอาจเริ่มจากรายได้, ลบต้นทุน, แล้วบวกรายได้อื่น ๆ คอลัมน์เปลี่ยนแปลงลอยระหว่างค่ารันก่อนหน้าและค่ารันใหม่, ส่วนคอลัมน์ผลรวมขยายจากศูนย์ถึงค่าที่สะสม

ตัวอย่างต่อไปนี้ใช้จำนวนเงินเป็นหน่วยพันดอลลาร์สหรัฐ

| หมวดหมู่ | ค่าจากสมุดงาน | ประเภทคอลัมน์ |
| --- | ---: | --- |
| Revenue | 1000 | เพิ่ม |
| Cost of sales | -400 | ลด |
| Gross profit | 600 | ผลรวมระหว่าง |
| Operating expenses | -200 | ลด |
| Other income | 50 | เพิ่ม |
| Net profit | 450 | ผลรวมสุดท้าย |

เพื่อทำเครื่องหมายจุดเป็นผลรวมระหว่างหรือผลรวมสุดท้าย ให้ตั้งค่าคุณสมบัติ [set_as_total](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/set_as_total/) ของจุดนั้นเป็น `True` จากนั้นใส่มูลค่าที่สะสมจริงในเซลล์สมุดงานของจุดนั้น: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`) คุณสมบัตินี้ทำเครื่องหมายคอลัมน์ว่าเป็นผลรวม; ไม่ได้คำนวณหรือเติมค่าในเซลล์ อย่าใช้ศูนย์เป็นค่าตัวแทนหรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดผลรวม คอลัมน์ผลรวมจะแสดงค่าที่สะสมโดยไม่เพิ่มอีกครั้งต่อค่ารัน

ตัวอย่าง C# นี้สร้างแผนภูมือน้ำตกโดยใช้สมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/), ล้างข้อมูลเริ่มต้น, แล้วเติมข้อมูลในสมุดงานที่ฝังอยู่ ดัชนีแผ่นงาน `0` เลือกแผ่นแรก; คอลัมน์ A มีชื่อประเภทและคอลัมน์ B มีค่า แต่ละเซลล์ค่าถูกเพิ่มด้วย [add_data_point_for_waterfall_series](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/add_data_point_for_waterfall_series/) ดัชนะจุดศูนย์ฐาน `2` และ `5` ระบุผลรวมระหว่างและผลรวมสุดท้าย การเปิดใช้ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) ทำให้ค่าปรากฏบนคอลัมน์ ไม่ต้องมี Presentation หรือสมุดงานอินพุต

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.WATERFALL, 20, 20, 680, 200)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Profit breakdown (USD thousands)")
    chart.chart_title.overlay = False
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Profit")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.WATERFALL)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, categories[i])
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_waterfall_series(value_cell)

    # จุดที่สามและหกเป็นผลรวม, ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
    series.data_points[2].set_as_total = True
    series.data_points[5].set_as_total = True
    series.show_connector_lines = True
    series.labels.default_data_label_format.show_value = True

    presentation.save("WaterfallChart.pptx", slides.export.SaveFormat.PPTX)
```

ตั้งค่าคุณสมบัติระดับซีรีส์ [show_connector_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/show_connector_lines/) เป็น `True` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่องและทำให้ค่ารันตามติดง่ายขึ้น หากต้องการซ่อนเส้นเหล่านี้ ให้เปลี่ยนการกำหนดในตัวอย่างเป็น `series.show_connector_lines = False` ก่อนบันทึก การเปลี่ยนแปลงนี้ส่งผลต่อการมองเห็นเส้นเท่านั้น ไม่กระทบต่อข้อมูลหรือผลรวม

Presentation ที่บันทึกแสดงกำไรขั้นต้น 600 และกำไรสุทธิ 450, ทั้งสองผลรวมเริ่มจากศูนย์:

![แผนภูมือน้ำตกที่แสดงรายได้, ต้นทุน, กำไรขั้นต้น 600, และกำไรสุทธิ 450, พร้อมป้ายค่าและเส้นเชื่อม](waterfall_chart.png)

### **สร้างแผนภูมิหุ้น**

แผนภูมิหุ้นใช้แสดงข้อมูลการเงิน เช่น ราคาเปิด, สูง, ต่ำ, และปิด, ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลเชิงลึกสำคัญเกี่ยวกับประสิทธิภาพของหุ้น เพื่อช่วยนักลงทุนและนักวิเคราะห์ในการตัดสินใจ

ตัวอย่างนี้สร้างแผนภูมิเปิด‑สูง‑ต่ำ‑ปิดที่มีสี่ซีรีส์ตามลำดับและสามประเภท คุณสมบัติ [has_up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/has_up_down_bars/) เปิดใช้งานแท่งขึ้น‑ลง, และ [hi_low_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/hi_low_lines_format/) ควบคุมเส้นสูง‑ต่ำที่แสดงช่วงราคา, ส่วนเส้นซีรีส์แยกและเส้นกริดแนวนอนย่อยจะถูกซ่อน

ผู้จัดการ [up_down_bars](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/up_down_bars/) เปิดเผย [up_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/up_bars_format/) และ [down_bars_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/updownbarsmanager/down_bars_format/) ที่แยกกัน ใช้คุณสมบัติ [fill](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/fill/) และ [line](https://reference.aspose.com/slides/python-net/aspose.slides.charts/format/line/) ของแต่ละออบเจ็กต์เพื่อกำหนดการเติมสีและโครงร่างอย่างอิสระ ตัวอย่างนี้ใช้แท่งสีเขียวกับโครงสีเขียวเข้มสำหรับช่วงที่ขึ้นและแท่งสีส้ม‑แดงกับโครงสีแดงเข้มสำหรับช่วงที่ลง

ให้ค่าตัวเลขสำหรับสี่ซีรีส์ทุกหมวดหมู่, โดย High และ Low ครอบคลุม Open และ Close แท่งเปรียบเทียบ Close กับ Open **ภายในประเภทเดียวกัน**, ไม่ใช่กับประเภทก่อนหน้า: A ลดจาก 72 เป็น 25, ในขณะที่ B เพิ่มจาก 25 เป็น 38 และ C เพิ่มจาก 38 เป็น 50 ค่า Open และ Close ที่เท่ากันจะไม่มีช่วงสีปรากฏ แท่งขึ้น‑ลงครอบคลุม Open‑Close; เส้นสูง‑ต่ำครอบคลุม Low‑High แท่งเหล่านี้เป็นส่วนของกลุ่มซีรีส์และไม่ใช่ซีรีส์แผนภูมิบาร์ปกติ

การจัดรูปแบบนี้ยังทำงานกับแผนภูมิ [LINE and LINE_WITH_MARKERS](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ที่มีอย่างน้อยสองซีรีส์ในกลุ่มเดียวกันและค่าตัวเลขที่สอดคล้องกันสำหรับแต่ละประเภท สำหรับแผนภูมิเส้นไม่ซับซ้อนเหล่านี้, แท่งขึ้น‑ลงเปรียบเทียบซีรีส์แรกและซีรีส์สุดท้าย: ค่าที่สูงกว่าจะสร้างแท่งขึ้น, ค่าที่ต่ำกว่าจะสร้างแท่งลง การสลับตำแหน่งซีรีส์จะสลับการจัดประเภท ตัวอย่างด้านล่างใช้ [OPEN_HIGH_LOW_CLOSE](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/); อย่าสมมติว่าชนิดหุ้น, เส้นซับซ้อน หรือ 3D รูปแบบอื่นใช้การจัดรูปแบบหรือการตีความช่วงเดียวกัน

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 150, False)

    workbook = chart.chart_data.chart_data_workbook

    category_cell = workbook.get_cell(0, 1, 0, "A")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 2, 0, "B")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, 3, 0, "C")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, 0, 1, "Open")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 2, "High")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 3, "Low")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)
    series_name_cell = workbook.get_cell(0, 0, 4, "Close")
    chart.chart_data.series.add(series_name_cell, charts.ChartType.OPEN_HIGH_LOW_CLOSE)

    series = chart.chart_data.series[0]
    value_cell = workbook.get_cell(0, 1, 1, 72)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 1, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 1, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[1]
    value_cell = workbook.get_cell(0, 1, 2, 172)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 57)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[2]
    value_cell = workbook.get_cell(0, 1, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 3, 12)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 3, 13)
    series.data_points.add_data_point_for_stock_series(value_cell)

    series = chart.chart_data.series[3]
    value_cell = workbook.get_cell(0, 1, 4, 25)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 4, 38)
    series.data_points.add_data_point_for_stock_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 4, 50)
    series.data_points.add_data_point_for_stock_series(value_cell)

    up_down_bars = chart.chart_data.series_groups[0].up_down_bars
    up_down_bars.has_up_down_bars = True

    up_down_bars.up_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.fill.solid_fill_color.color = draw.Color.lime_green
    up_down_bars.up_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.up_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_green
    up_down_bars.up_bars_format.line.width = 2

    up_down_bars.down_bars_format.fill.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.fill.solid_fill_color.color = draw.Color.orange_red
    up_down_bars.down_bars_format.line.fill_format.fill_type = slides.FillType.SOLID
    up_down_bars.down_bars_format.line.fill_format.solid_fill_color.color = draw.Color.dark_red
    up_down_bars.down_bars_format.line.width = 2
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for stock_series in chart.chart_data.series:
        stock_series.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    chart.axes.vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("Stock-chart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์ที่ส่งออกจาก PowerPoint:

![แผนภูมิหุ้นที่มีช่วงสีส้ม‑แดงลงสำหรับ A และช่วงสีเขียวขึ้นสำหรับ B และ C](stock_chart.png)

### **สร้างแผนภูมิกล่องและเส้นวิสเกอร์**

แผนภูมิกล่องและเส้นวิสเกอร์ใช้แสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติหลัก เช่น มัธยฐาน, ควอไทล์, และค่าผิดปกติ เหมาะสำหรับการวิเคราะห์ข้อมูลเชิงสำรวจและการศึกษาเชิงสถิติ เพื่อทำความเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติอย่างรวดเร็ว

ตัวอย่างนี้สร้างแผนภูมิกล่องและเส้นวิสเกอร์จากหกค่า คุณสมบัติ [quartile_method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/quartile_method/) เลือกการคำนวณควอไทล์แบบ exclusive ตัวอย่างยังเปิดใช้งานเส้นค่าเฉลี่ย, ตัวบ่งชี้ค่าเฉลี่ย, จุดภายใน, และจุดผิดปกติ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    value_cell = workbook.get_cell(0, "B1", 15)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 41)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 10)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 23)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 16)
    series.data_points.add_data_point_for_box_and_whisker_series(value_cell)

    presentation.save("BoxAndWhisker.pptx", slides.export.SaveFormat.PPTX)
```

### **สร้างแผนภูมิกรวย**

แผนภูมิกรวยใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยปริมาณข้อมูลจะลดลงเมื่อดำเนินการจากขั้นตอนหนึ่งไปยังขั้นตอนถัดไป เหมาะสำหรับวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อเพิ่มแผนภูมิกรวยลงในสไลด์แรกของ Presentation มีอยู่แล้ว แทนที่ข้อมูลเริ่มต้นด้วยหกประเภทและค่าที่อยู่ในช่วง 50‑500 แล้วบันทึก Presentation ที่อัปเดต ไฟล์ Presentation อินพุตต้องมีอย่างน้อยหนึ่งสไลด์

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A1", "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A2", "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A3", "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A4", "Category 4")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A5", "Category 5")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(0, "A6", "Category 6")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    value_cell = workbook.get_cell(0, "B1", 50)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B2", 100)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B3", 200)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B4", 300)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B5", 400)
    series.data_points.add_data_point_for_funnel_series(value_cell)
    value_cell = workbook.get_cell(0, "B6", 500)
    series.data_points.add_data_point_for_funnel_series(value_cell)

    presentation.save("Funnel.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิกรวย](funnel_chart.png)

### **สร้างแผนภูมิ Sunburst**

แผนภูมิ Sunburst ใช้เพื่อแสดงข้อมูลเชิงลำดับชั้นโดยแสดงระดับต่าง ๆ เป็นวงแหวนศูนย์กลาง ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะสำหรับการแสดงประเภทและหมวดหมู่ย่อยแบบซ้อนกันในรูปแบบที่กระชับและชัดเจน

ตัวอย่างนี้สร้างแผนภูมิ Sunburst ที่มีแปกรายการแปดรายการจัดเป็นสี่ต้นและสองกิ่ง เมธอด [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) กำหนดต้นระดับที่ 1 และกิ่งระดับที่ 2 ป้ายชื่อประเภทบ่งบอกส่วนต่าง ๆ และค่าเป็นตัวกำหนดขนาดสัมพัทธ์

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # สาขา 1
    category_cell = workbook.get_cell(0, "C1", "Leaf1")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    category_cell = workbook.get_cell(0, "C2", "Leaf2")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C3", "Leaf3")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    category_cell = workbook.get_cell(0, "C4", "Leaf4")
    chart.chart_data.categories.add(category_cell)

    # สาขา 2
    category_cell = workbook.get_cell(0, "C5", "Leaf5")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    category_cell = workbook.get_cell(0, "C6", "Leaf6")
    chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "C7", "Leaf7")
    leaf = chart.chart_data.categories.add(category_cell)
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    category_cell = workbook.get_cell(0, "C8", "Leaf8")
    chart.chart_data.categories.add(category_cell)

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    value_cell = workbook.get_cell(0, "D1", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D2", 5)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D3", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D4", 6)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D5", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D6", 9)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D7", 4)
    series.data_points.add_data_point_for_sunburst_series(value_cell)
    value_cell = workbook.get_cell(0, "D8", 3)
    series.data_points.add_data_point_for_sunburst_series(value_cell)

    presentation.save("Sunburst.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิ Sunburst](sunburst_chart.png)

### **สร้างแผนภูมิฮิสโตแกรม**

แผนภูมิฮิสโตแกรมแสดงการกระจายของค่าตัวเลขตามช่วง (bins) สำหรับรายงานรายเดือนเกี่ยวกับระยะเวลาการประมวลผลคำสั่งซื้อ ใช้ความกว้างบิ้นและเกณฑ์เดียวกันเพื่อให้ช่วงสอดคล้องและทำให้การเปรียบเทียบการกระจายง่ายขึ้น

กำหนด [aggregation_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/aggregation_type/) ของแกนแนวนอนเป็นโหมดจาก [AxisAggregationType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axisaggregationtype/). [bin_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/bin_width/) ใช้ได้เฉพาะกับ `BY_BIN_WIDTH`; [number_of_bins](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_of_bins/) ใช้ได้เฉพาะกับ `BY_NUMBER_OF_BINS`. ใช้ `AUTOMATIC` เพื่อให้แผนภูมิตัดสินใจเลือกบิ้นโดยอัตโนมัติ

#### **ใช้ความกว้างบิ้นคงที่**

ตัวอย่างนี้จัดกลุ่มระยะเวลาประมวลผลเป็นช่วง 10 นาที, มีบิ้นแยกสำหรับค่าที่ ≤ 10 นาทีและค่าที่ > 40 นาที เปิดใช้งานบิ้นเหล่านี้ด้วย [is_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_underflow_bin/) และ [is_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_overflow_bin/). เมื่อระบุค่าขอบ [underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/underflow_bin/) และ [overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/overflow_bin/) อย่างชัดเจน ให้ตั้งค่า [is_automatic_underflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_underflow_bin/) และ [is_automatic_overflow_bin](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_overflow_bin/) เป็น `False`

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_BIN_WIDTH
    axis.bin_width = 10
    axis.is_underflow_bin = True
    axis.is_automatic_underflow_bin = False
    axis.underflow_bin = 10
    axis.is_overflow_bin = True
    axis.is_automatic_overflow_bin = False
    axis.overflow_bin = 40

    presentation.save("Histogram-bin-width.pptx", slides.export.SaveFormat.PPTX)
```

Presentation ที่แสดงใน PowerPoint มีจำนวนบิ้น **3, 4, 4, 4, และ 2**. บิ้นขอบล่างรวม `5, 10, 10` ดังนั้นเกณฑ์ขอบล่างเป็น inclusive. บิ้นขอบบนรวมเฉพาะ `41, 50` ดังนั้นเกณฑ์ขอบบนเป็น exclusive; ค่าที่เท่ากับ `40` จะอยู่ในช่วงก่อนหน้า บิ้นภายในรวมค่าที่มากกว่าขอบล่างและน้อยกว่าหรือเท่ากับขอบบน

![ฮิสโตแกรมด้วยบิ้น 10 นาทีและเกณฑ์ขอบล่าง/ขอบบนที่ระบุชัดเจน](histogram_bin_width.png)

#### **ระบุจำนวนบิ้น**

สำหรับระดับรายละเอียดคงที่แทนช่วงคงที่ ให้ขอบิ้นห้าตัวสำหรับข้อมูลเดียวกัน ตัวอย่างนี้ปิดบิ้นขอบล่างและขอบบน แผนภูมิคำนวณความกว้างจากช่วงข้อมูล ดังนั้นขอบอาจเปลี่ยนระหว่างรายงาน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 680, 200)

    chart.has_legend = False
    chart.has_title = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.get_cell(0, i, 0, value)
        series.data_points.add_data_point_for_histogram_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.aggregation_type = charts.AxisAggregationType.BY_NUMBER_OF_BINS
    axis.number_of_bins = 5

    presentation.save("Histogram-bin-count.pptx", slides.export.SaveFormat.PPTX)
```

บิ้นห้าตัวมีจำนวน **4, 4, 4, 4, และ 1**. เปรียบเทียบการกระจายนี้กับผลลัพธ์ความกว้างคงที่ด้านบน: ค่าข้อมูลเท่าเดิม แต่ขอบต่างกัน

![ฮิสโตแกรมด้วยบิ้นห้าตัวที่คำนวณจากข้อมูลเดียวกัน](histogram_bin_count.png)

### **สร้างแผนภูมิ Radar**

แผนภูมิ Radar ใช้เพื่อแสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ, ช่วยเปรียบเทียบหลายตัวแปรพร้อมกันได้อย่างง่ายดาย เหมาะสำหรับระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะของประสิทธิภาพ

ตัวอย่างนี้ใช้ [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อสร้างแผนภูมิ Radar พร้อมซีรีส์และประเภทเริ่มต้น, แล้วบันทึก Presentation เป็น PPTX

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.shapes.add_chart(charts.ChartType.RADAR, 20, 20, 500, 300)

    presentation.save("Radar-chart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิ Radar](radar_chart.png)

### **สร้างแผนภูมิหลายหมวดหมู่**

แผนภูมิหลายหมวดหมู่ใช้เพื่อแสดงข้อมูลที่มีการจัดกลุ่มตามประเภทหลายระดับ, ช่วยให้คุณเปรียบเทียบค่าผ่านหลายมิติเพื่อพร้อมกัน เหมาะเมื่อคุณต้องวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลหลายชั้นที่ซับซ้อน

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบจัดกลุ่มที่มีแปดประเภทจัดเป็นสี่คู่ เมธอด [set_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/set_grouping_item/) ให้แต่ละคู่มีป้ายชื่อร่วมที่ระดับการจัดกลุ่ม 1, ส่งผลให้แกนประเภทมีทั้งป้ายชื่อแต่ละรายการและป้ายชื่อกลุ่ม

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.get_cell(0, "c2", "A")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group1")
    category_cell = workbook.get_cell(0, "c3", "B")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c4", "C")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group2")
    category_cell = workbook.get_cell(0, "c5", "D")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c6", "E")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group3")
    category_cell = workbook.get_cell(0, "c7", "F")
    category = chart.chart_data.categories.add(category_cell)

    category_cell = workbook.get_cell(0, "c8", "G")
    category = chart.chart_data.categories.add(category_cell)
    category.grouping_levels.set_grouping_item(1, "Group4")
    category_cell = workbook.get_cell(0, "c9", "H")
    category = chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(0, "D1", "Series 1")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    value_cell = workbook.get_cell(worksheet_index, "D2", 10)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D3", 20)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D4", 30)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D5", 40)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D6", 50)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D7", 60)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D8", 70)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, "D9", 80)
    series.data_points.add_data_point_for_bar_series(value_cell)

    presentation.save("AsposeChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิหลายหมวดหมู่](multi_category_chart.png)

#### **ลบป้ายไตรมาส**

ดาวน์โหลดไฟล์ [quarters.pptx](quarters.pptx) แล้ววางไว้ในไดเรกทอรีทำงาน แผนภูมิในไฟล์แสดงเดือนเก้เดือนและซีรีส์การขายเดียวที่มีค่าตั้งแต่ 10 ถึง 18 แกนประเภทมีป้ายไตรมาสสาม: Q1 ครอบคลุมม.ค.–มี.ค., Q2 ครอบคลุมเม.ย.–มิ.ย., Q3 ครอบคลุมก.ค.–ก.ย.

เมษายนเป็นประเภทที่สี่และเป็นที่ที่ตั้งค่า Q2 ไว้อย่างชัดเจน เรียกเมธอด [delete_grouping_item](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorylevelsmanager/delete_grouping_item/) บนคอลเลกชัน [grouping_levels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/grouping_levels/) ของเดือนเมษายน ระดับอ้างอิงจากเมษายน: ระดับ 1 คือไตรมาส, ระดับ 0 คือเดือนเอง เมธอดไม่สามารถลบประเภทใบ (leaf) ที่ระดับ 0 ได้

```python
import aspose.slides as slides

with slides.Presentation("quarters.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    april = chart.chart_data.categories[3]
    april.grouping_levels.delete_grouping_item(1)
    
    presentation.save("quarters-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("quarters-updated.pptx") as reopened:
    data = reopened.slides[0].shapes[0].chart_data
    print(", ".join(str(month.as_cell.value) for month in data.categories))
    print(", ".join(str(point.value.data) for point in data.series[0].data_points))
```

แผนภูมิที่เปิดใหม่พิมพ์เดือนเดิม (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) และค่าการขาย (`10, 11, 12, 13, 14, 15, 16, 17, 18`) ตามลำดับ เปิดไฟล์ `quarters-updated.pptx` ใน PowerPoint เพื่อตรวจสอบป้ายแกน Q2 และขอบกลุ่มก่อนเดือนเมษายนหายไป, ดังนั้น Q1 ครอบคลุมมกราคมถึงมิถุนายน Q3 ยังคงเริ่มในเดือนกรกฎาคม

![ป้ายไตรมาสก่อนและหลังการลบ ด้านซ้าย Q2 ครอบคลุมเมษายนถึงมิถุนายน ด้านขวา Q1 ครอบคลุมมกราคมถึงมิถุนายน](quarter-label-comparison.png)

### **สร้างแผนภูมิแผนที่**

แผนภูมิแผนที่ใช้เพื่อแสดงข้อมูลทางภูมิศาสตร์โดยแมพข้อมูลไปยังตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง มีประโยชน์สำหรับวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

ตัวอย่างนี้ใช้ [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อสร้างแผนภูมิแผนที่พร้อมข้อมูลภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.MAP, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิแผนที่](map_chart.png)

{{% alert color="info" title="Note" %}}
รูปภาพด้านบนแสดง Presentation ที่บันทึกแล้วเปิดใน PowerPoint Aspose.Slides เขียนข้อมูลแผนภูมิแผนที่และข้อมูลอย่างถูกต้อง, แต่ไม่ได้วาดแผนภูมิแผนที่เอง: เมื่อสไลด์ที่มีแผนภูมินั้นถูกเรนเดอร์เป็นภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะเป็นสีเปล่า รูปร่างอื่น ๆ บนสไลด์เดียวกันไม่ได้รับผลกระทบ
{{% /alert %}}

### **สร้างแผนภูมิแบบผสม**

แผนภูมิแบบผสม (หรือ combo chart) รวมสองหรือหลายประเภทแผนภูมิในกราฟเดียว แผนภูมินี้ให้คุณเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลสองชุดหรือมากกว่า, ช่วยระบุความสัมพันธ์ระหว่างชุดข้อมูลเหล่านั้น

![แผนภูมิแบบผสม](combination_chart.png)

ตัวอย่างนี้รวมสองซีรีส์คอลัมน์แบบจัดกลุ่มกับซีรีส์เส้นในสี่ประเภท คอลัมน์ใช้แกนแนวตั้งหลัก, ขณะที่ [plot_on_second_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/plot_on_second_axis/) วางเส้นบนแกนแนวตั้งรองด้านขวา ฟังก์ชันช่วยตั้งค่าชื่อเรื่อง, คำอธิบาย, ป้ายแกน, และเส้นกริด

```python
import aspose.pydrawing as draw
import aspose.slides as slides
import aspose.slides.charts as charts

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)

def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    portion_format = chart.chart_title.text_frame_for_overriding.paragraphs[0].paragraph_format.default_portion_format
    portion_format.font_bold = slides.NullableBool.FALSE
    portion_format.font_height = 18

    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    category_cell = workbook.get_cell(worksheet_index, 1, 0, "Category 1")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 2, 0, "Category 2")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 3, 0, "Category 3")
    chart.chart_data.categories.add(category_cell)
    category_cell = workbook.get_cell(worksheet_index, 4, 0, "Category 4")
    chart.chart_data.categories.add(category_cell)

    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 1, 4.3)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 1, 2.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 1, 3.5)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 1, 4.5)
    series.data_points.add_data_point_for_bar_series(value_cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    value_cell = workbook.get_cell(worksheet_index, 1, 2, 2.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 2, 4.4)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 2, 1.8)
    series.data_points.add_data_point_for_bar_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 2, 2.8)
    series.data_points.add_data_point_for_bar_series(value_cell)

def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    value_cell = workbook.get_cell(worksheet_index, 1, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 2, 3, 2.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 3, 3, 3.0)
    series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(worksheet_index, 4, 3, 5.0)
    series.data_points.add_data_point_for_line_series(value_cell)

    series.plot_on_second_axis = True

def set_primary_axes_format(chart):
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)

def set_secondary_axes_format(chart):
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12


create_combo_chart()
```

## **อัปเดตแผนภูมิ**

Aspose.Slides for Python via .NET ทำให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ ฟังก์ชันนี้ช่วยให้การอัปเดต Presentation ให้สอดคล้องกับเนื้อหาไดนามิกง่ายขึ้นและทำให้แผนภูมิสะท้อนข้อมูลและมาตรฐานภาพที่เป็นปัจจุบัน

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ “My chart” บนสไลด์แรกของ Presentation ที่มีอยู่ ต้องการสองซีรีส์คอลัมน์แต่ละซีรีส์มีจุดข้อมูลสามค่า, ป้ายประเภทในคอลัมน์ A และชื่อซีรีส์ในแถวแรกของแผ่นงานแรก ตัวอย่างใช้ [get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) เพื่อเปลี่ยนค่าเซลล์สมุดงาน, อัปเดตค่าซีรีส์, เพิ่มซีรีส์ที่สาม, และเปลี่ยนประเภทแผนภูมิเป็น “clustered cylinders” ผ่าน [type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/type/)

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            worksheet_index = 0

            workbook = chart.chart_data.chart_data_workbook

            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.chart_data.series[0]

            workbook.get_cell(worksheet_index, 0, 1, "New_Series 1")
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            series = chart.chart_data.series[1]

            workbook.get_cell(worksheet_index, 0, 2, "New_Series 2")
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
            series = chart.chart_data.series.add(series_name_cell, chart.type)

            value_cell = workbook.get_cell(worksheet_index, 1, 3, 20)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 2, 3, 50)
            series.data_points.add_data_point_for_bar_series(value_cell)
            value_cell = workbook.get_cell(worksheet_index, 3, 3, 30)
            series.data_points.add_data_point_for_bar_series(value_cell)

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

    presentation.save("AsposeChartModified.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงที่ใช้โดยแผนภูมิมีอยู่แล้ว, ดูที่ [Retrieve a Chart's Data Range](/slides/th/python-net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides for Python via .NET ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจากแผ่นงานเป็นแหล่งข้อมูลสำหรับแผนภูมิของคุณ หมายความว่าคุณสามารถแมพส่วนของแผ่นงานโดยตรงไปยังแผนภูมิ, ควบคุมเซลล์ใดบ้างที่เป็นส่วนของซีรีส์และประเภทของแผนภูมิ ผลลัพธ์คือคุณสามารถอัปเดตและซิงโครไนซ์แผนภูมิของคุณกับการเปลี่ยนแปลงข้อมูลล่าสุดในแผ่นงานได้อย่างง่ายดาย, ทำให้ Presentation ของคุณแสดงข้อมูลที่เป็นปัจจุบันและแม่นยำ

ตัวอย่างนี้ใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อกำหนดแหล่งข้อมูลของแผนภูมิชื่อ “My chart” บนสไลด์แรกของ Presentation ที่มีอยู่เป็น `Sheet1!A1:B4`. สมุดงานแผนภูมิต้องมีแผ่นงานนั้นและช่วงที่เติมข้อมูลพร้อมหัวเรื่องซีรีส์ในแถวแรก, ป้ายประเภทในคอลัมน์ A, และค่าสามค่าในคอลัมน์ B

```python
import aspose.slides as slides
import aspose.slides.charts as charts

chart_name = "My chart"

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้ตัวบ่งชี้เริ่มต้นในแผนภูมิ**

เมื่อใช้ตัวบ่งชี้เริ่มต้นในแผนภูมิ, แต่ละซีรีส์แผนภูมิจะได้รับสัญลักษณ์บ่งชี้เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) เพื่อสร้างแผนภูมิที่มีสองซีรีส์เส้นและคำอธิบาย การตั้งค่า [marker](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/marker/) คงสัญลักษณ์บ่งชี้ที่กำหนดโดยอัตโนมัติ ซีรีส์แรกมีค่าลบและค่าที่หายไป (แสดงด้วย `None`), ส่วนซีรีส์ที่สองมีค่าทุกประเภท

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series_name_cell = workbook.get_cell(0, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    category_cell = workbook.get_cell(0, 1, 0, "C1")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 1, 1, 24)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 2, 0, "C2")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 2, 1, 23)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 3, 0, "C3")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 3, 1, -10)
    series.data_points.add_data_point_for_line_series(value_cell)

    category_cell = workbook.get_cell(0, 4, 0, "C4")
    chart.chart_data.categories.add(category_cell)
    value_cell = workbook.get_cell(0, 4, 1, None)
    series.data_points.add_data_point_for_line_series(value_cell)

    series_name_cell = workbook.get_cell(0, 0, 2, "Series 2")
    second_series = chart.chart_data.series.add(series_name_cell, chart.type)

    value_cell = workbook.get_cell(0, 1, 2, 30)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 2, 2, 10)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 3, 2, 60)
    second_series.data_points.add_data_point_for_line_series(value_cell)
    value_cell = workbook.get_cell(0, 4, 2, 40)
    second_series.data_points.add_data_point_for_line_series(value_cell)

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Aspose.Slides for Python via .NET รองรับประเภทแผนภูมิใดบ้าง?**

Aspose.Slides for Python via .NET รองรับประเภทแผนภูมิมากมาย รวมถึงแผนภูมิแท่ง, เส้น, วงกลม, พื้นที่, กระจาย, ฮิสโตแกรม, Radar, และอื่น ๆ อีกหลายประเภท ความยืดหยุ่นนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงข้อมูลได้ดีที่สุด

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ, ให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิโดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น ขั้นตอนนี้จะผนวกแผนภูมิโดยตรงเข้าไปใน Presentation ของคุณ

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิอย่างไร?**

คุณสามารถอัปเดตข้อมูลแผนภูมิได้โดยเข้าถึงสมุดงานข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)), ลบซีรีส์และประเภทเริ่มต้นใด ๆ, แล้วเพิ่มข้อมูลแบบกำหนดเองของคุณ วิธีนี้ช่วยให้คุณรีเฟรชแผนภูมิด้วยข้อมูลล่าสุดได้โดยอัตโนมัติ

**ฉันสามารถปรับรูปแบบการแสดงของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for Python via .NET มีตัวเลือกการปรับแต่งอย่างกว้างขวาง คุณสามารถเปลี่ยนสี, ฟอนต์, ป้ายชื่อ, คำอธิบาย, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงตามความต้องการออกแบบของคุณ

Related feature: [Create editable charts](/slides/th/features/create-charts/).