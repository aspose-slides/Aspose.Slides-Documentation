---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ด้วย Python
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
- แผนภูมิเสี้ยง
- แผนภูมิเส้น
- แผนภูมิต้นไม้
- แผนภูมิสต็อก
- แผนภูมิ Box and Whisker
- แผนภูมิ Funnel
- แผนภูมิ Sunburst
- แผนภูมิ Histogram
- แผนภูมิ Radar
- แผนภูมิหลายประเภท
- การนำเสนอ PowerPoint
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via .NET ซึ่งครอบคลุมการเพิ่ม, การจัดรูปแบบ, และการแก้ไขแผนภูมิในงานนำเสนอพร้อมตัวอย่างโค้ดที่ใช้งานได้จริงใน Python."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำที่ครอบคลุมเกี่ยวกับวิธีการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for Python via .NET คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์โดยโปรแกรม, เติมข้อมูลลงในแผนภูมิ, และใช้ตัวเลือกรูปแบบต่างๆ เพื่อให้ตรงกับความต้องการออกแบบของคุณ คำอธิบายพร้อมโค้ดตัวอย่างอย่างละเอียดจะแสดงขั้นตอนแต่ละขั้นตอน ตั้งแต่การเริ่มต้น Presentation และอ็อบเจกต์แผนภูมิ ไปจนถึงการกำหนด Series, Axis, และ Legend โดยการทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีการบูรณาการการสร้างแผนภูมิโดยอัตโนมัติในแอปพลิเคชันของคุณ ทำให้การสร้างงานนำเสนอที่ขับเคลื่อนด้วยข้อมูลเป็นเรื่องง่ายขึ้น

## **สร้างแผนภูมิ**

แผนภูมาช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและค้นพบข้อมูลเชิงลึกที่อาจมองไม่เห็นจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

ด้วยแผนภูมคุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากลงในสไลด์เดียวของงานนำเสนอ
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ
* พบค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีเหตุผล
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิโดยใช้ฟังก์ชัน *Insert* ซึ่งมีเทมเพลตสำหรับออกแบบแผนภูมิมากมาย โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิที่นิยม) และแผนภูกิตตามต้องการได้

{{% alert color="primary" %}} 
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/) ใน namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/) ค่าต่างๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิต่าง ๆ
{{% /alert %}} 

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ส่วนนี้อธิบายวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่มด้วย Aspose.Slides for Python via .NET คุณจะได้เรียนรู้การเริ่มต้น Presentation, เพิ่มแผนภูมิ, และปรับแต่งองค์ประกอบต่าง ๆ เช่น ชื่อ, ข้อมูล, Series, Category, และสไตล์ ทำตามขั้นตอนด้านล่างเพื่อดูวิธีการสร้างแผนภูมิคอลัมน์แบบกลุ่มมาตรฐาน:

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิพร้อมข้อมูลบางส่วนและกำหนดประเภท `ChartType.CLUSTERED_COLUMN`
1. เพิ่มหัวข้อให้กับแผนภูมิ
1. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ
1. ล้าง Series และ Category เริ่มต้นทั้งหมด
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. กำหนดสีเติมให้กับ Series
1. เพิ่มป้ายกำกับให้กับ Series
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิคอลัมน์แบบกลุ่ม:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้นของมัน.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # ตั้งค่าชื่อแผนภูมิ.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # ตั้งค่า Series แรกให้แสดงค่า.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ.
    worksheet_index = 0

    # ดึง workbook ของข้อมูลแผนภูมิ.
    workbook = chart.chart_data.chart_data_workbook

    # ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # เพิ่ม Series ใหม่.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # เพิ่ม Category ใหม่.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # ดึง Series แผนภูมแรก.
    series = chart.chart_data.series[0]

    # เติมข้อมูลให้ Series.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # ตั้งค่าสีเติมให้กับ Series.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # ดึง Series แผนภูมิที่สอง.
    series = chart.chart_data.series[1]

    # เติมข้อมูลให้ Series.
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # ตั้งค่าสีเติมให้กับ Series.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # ตั้งค่าป้ายกำกับแรกให้แสดงชื่อ Category.
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # ตั้งค่า Series ให้แสดงค่าบนป้ายกำกับที่สาม.
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # บันทึกการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Clustered Column chart](clustered_column_chart.png)

### **สร้างแผนภูมิกระจาย (Scatter)**

แผนภูมิกระจาย (หรือ Scatter Plot, กราฟ x‑y) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างตัวแปรสองตัว

ใช้แผนภูมิกระจายเมื่อ:

* คุณมีข้อมูลตัวเลขเป็นคู่
* มีสองตัวแปรที่สัมพันธ์กันอย่างดี
* ต้องการตรวจสอบว่าตัวแปรสองตัวเกี่ยวข้องกันหรือไม่
* มีตัวแปรอิสระที่มีค่าหลายค่า สำหรับตัวแปรตาม

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิกระจายพร้อม Series ของเครื่องหมายที่แตกต่างกัน:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # สร้างแผนภูมิ scatter เริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ.
    worksheet_index = 0

    # ดึง workbook ของข้อมูลแผนภูมิ.
    workbook = chart.chart_data.chart_data_workbook

    # ลบ Series เริ่มต้น.
    chart.chart_data.series.clear()

    # เพิ่ม Series ใหม่.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # ดึง Series แผนภูมิแรก.
    series = chart.chart_data.series[0]

    # เพิ่มจุดใหม่ (1:3) ไปยัง Series.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # เพิ่มจุดใหม่ (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # เปลี่ยนประเภทของ Series.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # เปลี่ยนเครื่องหมายของ Series แผนภูมิ.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # ดึง Series แผนภูมิที่สอง.
    series = chart.chart_data.series[1]

    # เพิ่มจุดใหม่ (5:2) ไปยัง Series ของแผนภูมิ.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # เพิ่มจุดใหม่ (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # เพิ่มจุดใหม่ (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # เพิ่มจุดใหม่ (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # เปลี่ยนเครื่องหมายของ Series แผนภูมิ.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Scatter chart](scatter_chart.png)

### **สร้างแผนภูมิเสี้ยง (Pie)**

แผนภูมิเสี้ยงเหมาะสำหรับแสดงความสัมพันธ์ส่วนหนึ่งต่อส่วนทั้งหมดของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีหลายส่วนหรือหลายป้าย คุณอาจอยากใช้แผนภูมิบาร์แทน

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.PIE`
1. เข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/))
1. ล้าง Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. เพิ่มจุดใหม่สำหรับแผนภูมิและกำหนดสีกำหนดเองให้กับเซกเมนต์ของแผนภูมิเสี้ยง
1. ตั้งค่าป้ายกำกับสำหรับ Series
1. เปิดใช้เส้นนำสำหรับป้ายกำกับ Series
1. กำหนดมุมการหมุนของแผนภูมิเสี้ยง
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิเสี้ยง:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นของมัน.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # ตั้งค่าชื่อแผนภูมิ.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # ตั้งค่า Series แรกให้แสดงค่า.
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True

    # ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ.
    worksheet_index = 0

    # ดึง workbook ของข้อมูลแผนภูมิ.
    workbook = chart.chart_data.chart_data_workbook

    # ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # เพิ่ม Category ใหม่.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # เพิ่ม Series ใหม่.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # เติมข้อมูลให้ Series.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # ตั้งค่าสีของส่วนแผนภูมิ.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # ตั้งค่าขอบของส่วนแผนภูมิ.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # ตั้งค่าขอบของส่วนแผนภูมิ.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # ตั้งค่าขอบของส่วนแผนภูมิ.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # สร้างป้ายกำหนดแบบกำหนดเองสำหรับแต่ละ Category ใน Series ใหม่.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # ตั้งค่า Series ให้แสดงเส้นนำสำหรับแผนภูมิ.
    series.labels.default_data_label_format.show_leader_lines = True

    # ตั้งค่ามุมการหมุนสำหรับส่วนของแผนภูมิพาย.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # บันทึกการนำเสนอไปยังดิสก์เป็นไฟล์ PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Pie chart](pie_chart.png)

### **สร้างแผนภูมิเส้น (Line)**

แผนภูมิเส้น (หรือ Line Graph) เหมาะกับสถานการณ์ที่ต้องการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นจุดผิดปกติใน Series, และอื่น ๆ

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.LINE`
1. เข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/))
1. ล้าง Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิเส้น:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากคุณต้องการให้จุดเชื่อมต่อด้วยเส้นประ คุณสามารถกำหนดประเภท Dash ที่ต้องการได้ดังนี้:

```python
line_chart = pres.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

for series in line_chart.chart_data.series:
    series.format.line.dash_style = slides.charts.LineDashStyle.DASH
```

ผลลัพธ์:

![The Line chart](line_chart.png)

### **สร้างแผนภูมิต้นไม้ (Tree Map)**

แผนภูมิต้นไม้เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพันธ์ของประเภทข้อมูลและดึงความสนใจไปยังรายการที่มีส่วนร่วมสูงในแต่ละประเภท

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.TREEMAP`
1. เข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/))
1. ล้าง Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิต้นไม้:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # สาขา 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # สาขา 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Treemap chart](treemap_chart.png)

### **สร้างแผนภูมิสต็อก (Stock)**

แผนภูมิสต็อกใช้เพื่อแสดงข้อมูลการเงิน เช่น ราคาเปิด, สูง, ต่ำ, ปิด ช่วยวิเคราะห์แนวโน้มตลาดและความผันผวน ให้ข้อมูลเชิงลึกที่สำคัญต่อการตัดสินใจของนักลงทุนและนักวิเคราะห์

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.OPEN_HIGH_LOW_CLOSE`
1. เข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/))
1. ล้าง Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. กำหนดรูปแบบ HiLowLines
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิสต็อก:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Stock chart](stock_chart.png)

### **สร้างแผนภูมิ Box and Whisker**

แผนภูมิ Box and Whisker ใช้เพื่อแสดงการกระจายของข้อมูลโดยสรุปค่าทางสถิติหลัก เช่น มัธยฐาน, ควอร์ไทล์, และค่าส่วนเบี่ยงเบน พวกมันมีประโยชน์ในการวิเคราะห์ข้อมูลเชิงสำรวจและการศึกษาเชิงสถิติ เพื่อทำความเข้าใจความแปรปรวนของข้อมูลและพบข้อผิดปกติอย่างรวดเร็ว

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.BOX_AND_WHISKER`
1. เข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/))
1. ล้าง Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิ Box and Whisker:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **สร้างแผนภูมิ Funnel**

แผนภูมิ Funnel ใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยจำนวนข้อมูลจะลดลงเมื่อดำเนินการจากขั้นตอนหนึ่งไปยังขั้นตอนต่อไป เหมาะอย่างยิ่งสำหรับการวิเคราะห์อัตราการเปลี่ยนแปลง, การระบุคอขวด, และการติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.FUNNEL`
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิ Funnel:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Funnel chart](funnel_chart.png)

### **สร้างแผนภูมิ Sunburst**

แผนภูมิ Sunburst ใช้เพื่อแสดงข้อมูลเชิงลำดับขั้น โดยแสดงระดับต่าง ๆ เป็นวงแหวนศูนย์กลาง ช่วยให้มองเห็นความสัมพันธ์ส่วนหนึ่งต่อส่วนทั้งหมดอย่างชัดเจนและเหมาะกับการแสดงหมวดหมู่และประเภทรูปแบบที่ซ้อนกันในรูปแบบกะทัดรัด

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.SUNBURST`
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิ Sunburst:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # สาขา 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # สาขา 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Sunburst chart](sunburst_chart.png)

### **สร้างแผนภูมิ Histogram**

แผนภูมิ Histogram ใช้เพื่อแสดงการกระจายของข้อมูลเชิงตัวเลขโดยจัดกลุ่มค่าเป็นช่วงหรือบิ้น เป็นประโยชน์ในการระบุรูปแบบเช่น ความถี่, ความเอนเอียง, การกระจาย, และการตรวจจับค่าผิดปกติในชุดข้อมูล

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิกับข้อมูลบางส่วนและกำหนดประเภท `ChartType.HISTOGRAM`
1. เข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/))
1. ล้าง Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิ Histogram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Histogram chart](histogram_chart.png)

### **สร้างแผนภูมิ Radar**

แผนภูมิ Radar ใช้เพื่อแสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ ทำให้เปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย เหมาะสำหรับการระบุรูปแบบ, จุดแข็ง, และจุดอ่อนของเมตริกหรือคุณลักษณะหลายประการ

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิกับข้อมูลบางส่วนและกำหนดประเภท `ChartType.RADAR`
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิ Radar:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarСhart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Radar chart](radar_chart.png)

### **สร้างแผนภูมิหลายประเภท (Multi Category)**

แผนภูมิหลายประเภทใช้เพื่อแสดงข้อมูลที่มีการจัดกลุ่มตามหมวดหมู่หลายมิติพร้อมกัน ช่วยให้คุณเปรียบเทียบค่าตามมิติหลายด้านโดยอัตโนมัติ เป็นประโยชน์เมื่อจำเป็นต้องวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลที่ซับซ้อนหลายชั้น

1. สร้างอ็อบเจกต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและกำหนดประเภท `ChartType.CLUSTERED_COLUMN`
1. เข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/))
1. ล้าง Series และ Category เริ่มต้น
1. เพิ่ม Series และ Category ใหม่
1. เพิ่มข้อมูลแผนภูมิใหม่สำหรับ Series
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิหลายประเภท:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # เพิ่ม series.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # บันทึกการนำเสนอพร้อมแผนภูมิ.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The multi category chart](multi_category_chart.png)

### **สร้างแผนภูมิแผนที่ (Map)**

แผนภูมิแผนที่ใช้เพื่อแสดงข้อมูลเชิงภูมิศาสตร์โดยแมปข้อมูลไปยังตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง เหมาะสำหรับการวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

โค้ด Python นี้แสดงวิธีการสร้างแผนภูมิแผนที่:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![The Map chart](map_chart.png)

### **สร้างแผนภูมิแบบผสม (Combination)**

แผนภูมิแบบผสม (Combination chart) ผสานประเภทแผนภูมิสองประเภทหรือมากกว่าบนกราฟเดียว ทำให้คุณสามารถไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างของชุดข้อมูลหลายชุดได้อย่างชัดเจน

![The combination chart](combination_chart.png)

โค้ด Python ด้านล่างแสดงวิธีการสร้างแผนภูมิแบบผสมที่แสดงในภาพด้านบนใน PowerPoint:

```python
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

    # ตั้งค่าชื่อแผนภูมิ.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # ตั้งค่าตำแหน่ง Legend ของแผนภูมิ.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # ลบ Series และ Category ที่สร้างโดยค่าเริ่มต้น.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # เพิ่ม Category ใหม่.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # เพิ่ม Series แรก.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # ตั้งค่าแกนแนวนอน.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # ตั้งค่าแกนแนวตั้ง.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # ตั้งค่าสีของเส้นกริดหลักแนวตั้ง.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # ตั้งค่าแกนแนวนอนรอง.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # ตั้งค่าแกนแนวตั้งรอง.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **อัปเดตแผนภูมิ**

Aspose.Slides for Python via .NET ช่วยให้คุณอัปเดตแผนภูมิ PowerPoint โดยการแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ ทำให้การรักษาให้งานนำเสนอเป็นปัจจุบันกับเนื้อหาแบบไดนามิกง่ายขึ้นและทำให้แผนภูมิมีความสอดคล้องกับข้อมูลและมาตรฐานการแสดงผลล่าสุด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิ
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. ตรวจสอบทุกรูปร่างเพื่อค้นหาแผนภูมิ
1. เข้าถึงแผ่นงานข้อมูลของแผนภูมิ
1. แก้ไข Series ของข้อมูลแผนภูมิโดยเปลี่ยนค่า Series
1. เพิ่ม Series ใหม่และเติมข้อมูลให้กับมัน
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการอัปเดตแผนภูมิ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ.
            worksheet_index = 0

            # ดึง workbook ของข้อมูลแผนภูมิ.
            workbook = chart.chart_data.chart_data_workbook

            # เปลี่ยนชื่อ Category ของแผนภูมิ.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # ดึง Series แรกของแผนภูมิ.
            series = chart.chart_data.series[0]

            # อัปเดตข้อมูลของ Series.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # แก้ไขชื่อ Series.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # ดึง Series ที่สองของแผนภูมิ.
            series = chart.chart_data.series[1]

            # อัปเดตข้อมูลของ Series.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # แก้ไขชื่อ Series.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # เพิ่ม Series ใหม่.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # เติมข้อมูลให้ Series.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # บันทึกการนำเสนอพร้อมแผนภูมิ.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

Aspose.Slides for Python via .NET ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจาก Worksheet เป็นแหล่งข้อมูลของแผนภูมิ หมายความว่าคุณสามารถแมปส่วนหนึ่งของ Worksheet ไปยังแผนภูมิได้โดยตรง ควบคุมว่าเซลล์ใดมีส่วนร่วมใน Series และ Category ของแผนภูมิ ด้วยวิธีนี้คุณสามารถอัปเดตและซิงโครไนซ์แผนภูมิกับการเปลี่ยนแปลงข้อมูลล่าสุดใน Worksheet ได้ง่าย ทำให้งานนำเสนอ PowerPoint ของคุณสื่อสารข้อมูลที่เป็นปัจจุบันและแม่นยำ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่เป็นตัวแทนของงานนำเสนอที่มีแผนภูมิ
1. เรียกอ้างอิงสไลด์โดยใช้ดัชนีของสไลด์นั้น
1. ตรวจสอบทุกรูปร่างเพื่อค้นหาแผนภูมิ
1. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วง
1. บันทึก Presentation ที่ปรับเปลี่ยนเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีการกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้เครื่องหมายเริ่มต้นในแผนภูมิ**

เมื่อคุณใช้เครื่องหมายเริ่มต้นในแผนภูมิแต่ละ Series จะได้รับสัญลักษณ์เครื่องหมายเริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

โค้ด Python นี้แสดงวิธีการตั้งค่าเครื่องหมาย Series ของแผนภูมิโดยอัตโนมัติ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # เติมข้อมูลให้ Series.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย (FAQ)**

**Aspose.Slides for Python via .NET รองรับประเภทแผนภูมิใดบ้าง?**

Aspose.Slides for Python via .NET รองรับแผนภูมิหลายประเภท รวมถึง bar, line, pie, area, scatter, histogram, radar และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะสมที่สุดสำหรับการแสดงผลข้อมูลของคุณ

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/), ดึงสไลด์ที่ต้องการโดยใช้ดัชนี, แล้วเรียกเมธอดเพื่อเพิ่มแผนภูมิ พร้อมระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะฝังแผนภูมิเข้าไปในงานนำเสนอของคุณโดยตรง

**ฉันสามารถอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงหนังสือข้อมูลของแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/)), ล้าง Series และ Category เริ่มต้น, จากนั้นเพิ่มข้อมูลที่คุณกำหนดเอง ทำให้คุณสามารถรีเฟรชแผนภูมิเพื่อสะท้อนข้อมูลล่าสุดได้อย่างอัตโนมัติ

**ฉันสามารถปรับรูปแบบการแสดงผลของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for Python via .NET มีตัวเลือกการปรับแต่งที่กว้างขวาง คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, Legend และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงตามข้อกำหนดการออกแบบของคุณได้อย่างละเอียด