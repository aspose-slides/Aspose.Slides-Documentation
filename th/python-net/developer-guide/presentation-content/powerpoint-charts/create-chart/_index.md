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
- เปลี่ยนแปลงแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิต้นไม้แผนที่
- แผนภูมิตลาดหุ้น
- แผนภูมิกล่องและหนวดยาว
- แผนภูมิกรวย
- แผนภูมิดาว
- แผนภูมิฮิสโตแกรม
- แผนภูมิเรดาร์
- แผนภูมิหลายหมวด
- การนำเสนอ PowerPoint
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python via .NET. พื้นที่ครอบคลุมการเพิ่ม, การจัดรูปแบบ, และการแก้ไขแผนภูมิในงานนำเสนอพร้อมตัวอย่างโค้ดที่ใช้งานจริงใน Python."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for Python via .NET คุณจะได้เรียนรู้วิธีเพิ่มแผนภูมิในสไลด์, เติมข้อมูลให้แผนภูมิ, และจัดรูปแบบให้ตรงกับความต้องการออกแบบของคุณ ตัวอย่างโค้ดครอบคลุมการสร้างงานนำเสนอและแผนภูมิ, การกำหนดค่า series, แกน, และ legend, รวมถึงการผสานการสร้างแผนภูมิกับแอปพลิเคชันของคุณ

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและสังเกตข้อมูลเชิงลึกที่อาจไม่เห็นได้จากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

เมื่อใช้แผนภูมิคุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากในสไลด์เดียวของงานนำเสนอ
* แสดงรูปแบบและแนวโน้มของข้อมูล
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือเทียบกับหน่วยวัดเฉพาะ
* พบค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีความหมาย
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อนได้

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งมีแม่แบบสำหรับออกแบบแผนภูมิต่าง ๆ ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (จากประเภทแผนภูมิที่นิยม) และแผนภูกำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) ภายในเนมสเปซ [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิแต่ละแบบ
{{% /alert %}}

### **สร้างแผนภูมิคอลัมน์แบบกลุ่ม**

ส่วนนี้อธิบายวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่มด้วย Aspose.Slides for Python via .NET คุณจะเรียนรู้การเริ่มต้นงานนำเสนอ, เพิ่มแผนภูมิ, และปรับแต่งองค์ประกอบต่าง ๆ เช่น ชื่อเรื่อง, ข้อมูล, series, หมวดหมู่, และสไตล์ ทำตามขั้นตอนด้านล่างเพื่อดูว่าการสร้างแผนภูมิคอลัมน์แบบกลุ่มมาตรฐานทำอย่างไร:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภท `ChartType.CLUSTERED_COLUMN`
4. เพิ่มชื่อเรื่องให้แผนภูมิ
5. เข้าถึง worksheet ของข้อมูลแผนภูมิ
6. ลบ series และ category เริ่มต้นทั้งหมด
7. เพิ่ม series และ category ใหม่
8. เพิ่มข้อมูลใหม่ให้ series ของแผนภูมิ
9. กำหนดสีเติมให้ series ของแผนภูมิ
10. เพิ่มป้ายกำกับให้ series ของแผนภูมิ
11. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิคอลัมน์แบบกลุ่ม:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลเริ่มต้น
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # ตั้งค่าชื่อเรื่องของแผนภูมิ
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ
    worksheet_index = 0

    # ดึง workbook ของข้อมูลแผนภูมิ
    workbook = chart.chart_data.chart_data_workbook

    # ลบ series และ category ที่สร้างโดยอัตโนมัติ
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # เพิ่ม series ใหม่
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

    # เพิ่ม category ใหม่
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

    # ดึง series แผนภูมิแรก
    series = chart.chart_data.series[0]

    # เติมข้อมูลให้ series
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # ตั้งค่าสีเติมสำหรับ series
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # ดึง series แผนภูมิที่สอง
    series = chart.chart_data.series[1]

    # เติมข้อมูลให้ series
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

    # ตั้งค่าสีเติมสำหรับ series
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.green

    # ตั้งค่าป้ายแรกให้แสดงชื่อ category
    label = series.data_points[0].label
    label.data_label_format.show_category_name = True

    label = series.data_points[1].label
    label.data_label_format.show_series_name = True

    # ตั้งค่า series ให้แสดงค่าในป้ายที่สาม
    label = series.data_points[2].label
    label.data_label_format.show_value = True
    label.data_label_format.show_series_name = True
    label.data_label_format.separator = "/"
                
    # บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX
    presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิคอลัมน์แบบกลุ่ม](clustered_column_chart.png)

### **สร้างแผนภูมิกระจาย**

แผนภูมิกระจาย (หรือ scatter plot, x‑y graph) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิกระจายเมื่อ:

* มีข้อมูลเชิงตัวเลขเป็นคู่
* มีสองตัวแปรที่สัมพันธ์กันดี
* ต้องการตรวจสอบว่าตัวแปรสองตัวนั้นเกี่ยวข้องกันหรือไม่
* มีตัวแปรอิสระที่มีค่าหลายค่าเป็นตัวแปรตาม

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิกระจายโดยใช้เครื่องหมายแบบต่าง ๆ สำหรับแต่ละ series:

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

    # ลบ series เริ่มต้น.
    chart.chart_data.series.clear()

    # เพิ่ม series ใหม่.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # ดึง series แผนภูมิแรก.
    series = chart.chart_data.series[0]

    # เพิ่มจุดใหม่ (1:3) ให้ series.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # เพิ่มจุดใหม่ (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # เปลี่ยนประเภทของ series.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # เปลี่ยนเครื่องหมายของ series ในแผนภูมิ.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # ดึง series แผนภูมิที่สอง.
    series = chart.chart_data.series[1]

    # เพิ่มจุดใหม่ (5:2) ให้ series ของแผนภูมิ.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # เพิ่มจุดใหม่ (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # เพิ่มจุดใหม่ (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # เพิ่มจุดใหม่ (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # เปลี่ยนเครื่องหมายของ series ในแผนภูมิ.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิกระจาย](scatter_chart.png)

### **สร้างแผนภูมิพิซซ่า**

แผนภูมิเพียน (pie chart) เหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายชื่อแบบหมวดหมู่พร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีส่วนหรือป้ายชื่อจำนวนมาก คุณอาจพิจารณาใช้แผนภูมิแท่งแทน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.PIE`
4. เข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))
5. ลบ series และ category เริ่มต้น
6. เพิ่ม series และ category ใหม่
7. เพิ่มข้อมูลใหม่ให้ series ของแผนภูมิ
8. เพิ่มจุดใหม่ให้แผนภูมิและกำหนดสีแบบกำหนดเองให้กับส่วนของแผนภูมิพิซซ่า
9. ตั้งค่าป้ายกำกับสำหรับ series
10. เปิดใช้งาน leader lines สำหรับป้ายกำกับของ series
11. กำหนดมุมการหมุนของแผนภูมิพิซซ่า
12. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิพิซซ่า:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # ตั้งค่าดัชนีของชีตข้อมูลแผนภูมิ.
    worksheet_index = 0

    # ดึง workbook ของข้อมูลแผนภูมิ.
    workbook = chart.chart_data.chart_data_workbook

    # ลบ series และ category ที่สร้างโดยอัตโนมัติ.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # เพิ่ม category ใหม่.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # เพิ่ม series ใหม่.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # เติมข้อมูลให้ series.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # ตั้งค่าสีของส่วน.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # ตั้งค่าขอบของส่วน.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # ตั้งค่าขอบของส่วน.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # ตั้งค่าขอบของส่วน.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละ category ใน series ใหม่.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # ตั้งค่า series ให้แสดงเส้นนำสำหรับแผนภูมิ.
    series.labels.default_data_label_format.show_leader_lines = True

    # ตั้งค่ามุมการหมุนของส่วนแผนภูมิพาย.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # บันทึกการนำเสนอลงดิสก์เป็นไฟล์ PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิพิซซ่า](pie_chart.png)

### **สร้างแผนภูมิเส้น**

แผนภูมิเส้น (หรือ line graph) เหมาะสำหรับแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ด้วยแผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้มตามเวลา, เน้นความผิดปกติใน series ของข้อมูล, และอื่น ๆ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.LINE`
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิเส้น:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้จุดเชื่อมต่อด้วยเส้นประ สามารถระบุรูปแบบ dash ที่ต้องการได้ดังนี้:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมิเส้น](line_chart.png)

### **สร้างแผนภูมิต้นไม้แผนที่ (Tree Map)**

แผนภูมิต้นไม้แผนที่เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่มีส่วนร่วมสูงในแต่ละหมวดหมู่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.TREEMAP`
4. เข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))
5. ลบ series และ category เริ่มต้น
6. เพิ่ม series และ category ใหม่
7. เพิ่มข้อมูลใหม่ให้ series ของแผนภูมิ
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิต้นไม้แผนที่:

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

![แผนภูมิต้นไม้แผนที่](treemap_chart.png)

### **สร้างแผนภูมิหุ้น (Stock Chart)**

แผนภูมิหุ้นใช้แสดงข้อมูลการเงินเช่น ราคาที่เปิด, สูงสุด, ต่ำสุด, และปิด ช่วยวิเคราะห์แนวโน้มและความผันผวนของตลาด ให้ข้อมูลเชิงลึกสำคัญเกี่ยวกับประสิทธิภาพของหุ้นสำหรับนักลงทุนและนักวิเคราะห์

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.OPEN_HIGH_LOW_CLOSE`
4. เข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))
5. ลบ series และ category เริ่มต้น
6. เพิ่ม series และ category ใหม่
7. เพิ่มข้อมูลใหม่ให้ series ของแผนภูมิ
8. กำหนดรูปแบบของเส้น high‑low
9. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิหุ้น:

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

![แผนภูมิหุ้น](stock_chart.png)

### **สร้างแผนภูมิกล่องและหนวดยาว (Box and Whisker)**

แผนภูมิกล่องและหนวดยาวใช้แสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติสำคัญ เช่น ค่ามัธยฐาน, ควอร์ไทล์, และค่า outlier เป็นเครื่องมือที่มีประโยชน์ในงานวิเคราะห์ข้อมูลสำรวจและการศึกษาเชิงสถิติ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.BOX_AND_WHISKER`
4. เข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))
5. ลบ series และ category เริ่มต้น
6. เพิ่ม series และ category ใหม่
7. เพิ่มข้อมูลใหม่ให้ series ของแผนภูมิ
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิกล่องและหนวดยาว:

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

### **สร้างแผนภูมิกรวย (Funnel Chart)**

แผนภูมิกรวยใช้เพื่อแสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยปริมาณข้อมูลจะลดลงเมื่อเคลื่อนผ่านจากขั้นตอนหนึ่งไปยังขั้นตอนต่อไป เหมาะสำหรับวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.FUNNEL`
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิกรวย:

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

![แผนภูมิกรวย](funnel_chart.png)

### **สร้างแผนภูมิดาว (Sunburst Chart)**

แผนภูมิดาวใช้เพื่อแสดงข้อมูลเชิงลำดับชั้น โดยแสดงระดับต่าง ๆ เป็นวงแหวนชั้นใน ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนและเหมาะสำหรับแสดงหมวดหมู่และหมวดย่อยที่ซ้อนกันในรูปแบบที่กระชับ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.SUNBURST`
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิดาว:

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

![แผนภูมิดาว](sunburst_chart.png)

### **สร้างแผนภูมิฮิสโตแกรม (Histogram Chart)**

แผนภูมิฮิสโตแกรมใช้แสดงการกระจายของข้อมูลเชิงตัวเลขโดยจัดกลุ่มค่าเป็นช่วงหรือ bin ซึ่งช่วยระบุรูปแบบเช่น ความถี่, ความเอียง, การแพร่กระจาย, และการตรวจจับค่า outlier

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภท `ChartType.HISTOGRAM`
4. เข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))
5. ลบ series และ category เริ่มต้น
6. เพิ่ม series ใหม่และเติมข้อมูลจุดต่าง ๆ (ฮิสโตแกรมไม่มี category; bin ถูกคำนวณจากค่า)
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิฮิสโตแกรม:

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

![แผนภูมิฮิสโตแกรม](histogram_chart.png)

### **สร้างแผนภูมาราดาร์ (Radar Chart)**

แผนภูมาราดาร์ใช้แสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ ทำให้เปรียบเทียบตัวแปรหลาย ๆ ตัวพร้อมกันได้ง่าย เป็นประโยชน์ในการระบุรูปแบบ, จุดแข็ง, และจุดอ่อนของเมตริกหรือคุณลักษณะหลายตัว

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลบางส่วนและระบุประเภท `ChartType.RADAR`
4. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมาราดาร์:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมาราดาร์](radar_chart.png)

### **สร้างแผนภูมิหลายหมวด (Multi‑Category Chart)**

แผนภูมิหลายหมวดใช้แสดงข้อมูลที่มีการจัดกลุ่มตามหมวดหมู่หลายระดับพร้อมกัน ช่วยให้เปรียบเทียบค่าตามหลายมิติเพื่อวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลที่ซับซ้อน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เพิ่มแผนภูมิกับข้อมูลเริ่มต้นและระบุประเภท `ChartType.CLUSTERED_COLUMN`
4. เข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/))
5. ลบ series และ category เริ่มต้น
6. เพิ่ม series และ category ใหม่
7. เพิ่มข้อมูลใหม่ให้ series ของแผนภูมิ
8. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีสร้างแผนภูมิหลายหมวด:

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

![แผนภูมิหลายหมวด](multi_category_chart.png)

### **สร้างแผนภูมาผัง (Map Chart)**

แผนภูมาผังใช้เพื่อแสดงข้อมูลทางภูมิศาสตร์โดยแมปข้อมูลไปยังตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง มีประโยชน์สำหรับวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและน่าสนใจ

โค้ด Python นี้แสดงวิธีสร้างแผนภูมาผัง:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![แผนภูมาผัง](map_chart.png)

### **สร้างแผนภูมาผสม (Combination Chart)**

แผนภูมผสม (หรือ combo chart) ผสานประเภทแผนภูมิสองประเภทขึ้นไปในกราฟเดียว ช่วยให้คุณเน้น, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุดได้ง่ายขึ้น

![แผนภูมาผสม](combination_chart.png)

โค้ด Python ต่อไปนี้แสดงวิธีสร้างแผนภูมผสมที่แสดงด้านบนในงานนำเสนอ PowerPoint:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

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

    # ตั้งค่าชื่อเรื่องของแผนภูมิ.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # ตั้งค่าตำแหน่ง legend ของแผนภูมิ.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # ลบ series และ category ที่สร้างโดยอัตโนมัติ.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # เพิ่ม category ใหม่.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # เพิ่ม series แรก.
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

    # ตั้งค่าสีเส้นกริดหลักของแกนแนวตั้ง.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # ตั้งค่าแกนนอนรอง.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # ตั้งค่าแกนตั้งรอง.
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

Aspose.Slides for Python via .NET ให้คุณอัปเดตข้อมูล, การจัดรูปแบบ, และสไตล์ของแผนภูมิ เพื่อให้งานนำเสนอ PowerPoint ของคุณเป็นปัจจุบัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอที่มีแผนภูมิ
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เดินทางผ่าน shape ทั้งหมดเพื่อค้นหาแผนภูมิ
4. เข้าถึง worksheet ของข้อมูลแผนภูมิ
5. แก้ไข series ของข้อมูลแผนภูมิโดยเปลี่ยนค่า series
6. เพิ่ม series ใหม่และเติมข้อมูลของมัน
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีอัปเดตแผนภูมิ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
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

            # เปลี่ยนชื่อ category ของแผนภูมิ.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # ดึง series แผนภูมิแรก.
            series = chart.chart_data.series[0]

            # อัปเดตข้อมูลของ series.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # กำลังแก้ไขชื่อ series.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # ดึง series แผนภูมิที่สอง.
            series = chart.chart_data.series[1]

            # อัปเดตข้อมูลของ series.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # กำลังแก้ไขชื่อ series.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # เพิ่ม series ใหม่.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # เติมข้อมูลให้ series.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # บันทึกการนำเสนอพร้อมแผนภูมิ.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงข้อมูลที่แผนภูมิที่มีอยู่ใช้แล้ว ให้ดูที่ [Retrieve a Chart's Data Range](/slides/th/python-net/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides for Python via .NET ให้คุณใช้ช่วง worksheet เฉพาะเป็นแหล่งข้อมูลสำหรับแผนภูมิ ซึ่งกำหนดว่าช่องใดจะเป็น series และ category ของแผนภูมิและช่วยให้คุณอัปเดตแผนภูมิเพื่อสะท้อนการเปลี่ยนแปลงใน worksheet

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอที่มีแผนภูมิ
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของสไลด์
3. เดินทางผ่าน shape ทั้งหมดเพื่อค้นหาแผนภูมิ
4. เข้าถึงข้อมูลแผนภูมิและกำหนดช่วง
5. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Python นี้แสดงวิธีกำหนดช่วงข้อมูลสำหรับแผนภูมิ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้ตัวทำเครื่องหมายเริ่มต้นในแผนภูมิ**

เมื่อใช้ตัวทำเครื่องหมายเริ่มต้นในแผนภูมิแต่ละ series จะได้รับสัญลักษณ์ตัวทำเครื่องหมายที่แตกต่างโดยอัตโนมัติ

โค้ด Python นี้แสดงวิธีตั้งค่าตัวทำเครื่องหมายของ series ในแผนภูมิโดยอัตโนมัติ:

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

    # เติมข้อมูลให้ series.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**แผนภูมิประเภทใดบ้างที่ Aspose.Slides for Python via .NET รองรับ?**

Aspose.Slides for Python via .NET รองรับแผนภูมิมากมาย รวมถึง bar, line, pie, area, scatter, histogram, radar และอื่น ๆ ซึ่งทำให้คุณสามารถเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงข้อมูลของคุณได้

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

เพื่อเพิ่มแผนภูมิ คุณต้องสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) แล้วดึงสไลด์ที่ต้องการโดยใช้ดัชนี จากนั้นเรียกเมธอดเพื่อเพิ่มแผนภูมิโดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้จะฝังแผนภูมิเข้าไปในงานนำเสนอของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิอย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูลแผนภูมิ ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)) ลบ series และ category เริ่มต้น แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ทำให้คุณรีเฟรชแผนภูมิโดยโปรแกรมเมติกให้แสดงข้อมูลล่าสุด

**สามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for Python via .NET มีตัวเลือกการปรับแต่งมากมาย คุณสามารถแก้ไขสี, ฟอนต์, ป้ายกำกับ, legend, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงกับความต้องการด้านการออกแบบของคุณ