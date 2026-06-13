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
- ตำแหน่งป้าย
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python ผ่าน .NET เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **ภาพรวม**

ป้ายข้อมูลบนแผนภูมิแสดงรายละเอียดเกี่ยวกับชุดข้อมูลของแผนภูมิหรือจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุชุดข้อมูลได้อย่างรวดเร็วและทำให้แผนภูมิอ่านง่ายยิ่งขึ้น ใน Aspose.Slides for Python คุณสามารถเปิดใช้งาน ปรับแต่ง และจัดรูปแบบป้ายข้อมูลสำหรับแผนภูมิใดก็ได้ — เลือกสิ่งที่จะแสดง (ค่า, เปอร์เซ็นต์, ชื่อชุดข้อมูลหรือชื่อประเภท) ตำแหน่งของป้ายและลักษณะการแสดงผล (แบบอักษร, รูปแบบตัวเลข, ตัวคั่น, เส้นนำและอื่น ๆ) บทความนี้สรุป API ที่สำคัญและตัวอย่างที่คุณต้องการเพื่อเพิ่มป้ายที่ชัดเจนและให้ข้อมูลกับแผนภูมิของคุณ.

## **ตั้งค่าความแม่นยำของป้ายข้อมูล**

ป้ายข้อมูลของแผนภูมิมักแสดงค่าตัวเลขที่ต้องการความแม่นยำสม่ำเสมอ ส่วนนี้แสดงวิธีควบคุมจำนวนตำแหน่งทศนิยมสำหรับป้ายข้อมูลใน Aspose.Slides โดยใช้รูปแบบตัวเลขที่เหมาะสม

ตัวอย่าง Python ด้านล่างแสดงวิธีตั้งค่าความแม่นยำของตัวเลขสำหรับป้ายข้อมูลแผนภูมิ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

ด้วย Aspose.Slides คุณสามารถแสดงเปอร์เซ็นต์เป็นป้ายข้อมูลบนแผนภูมิได้ ตัวอย่างด้านล่างคำนวณสัดส่วนของแต่ละจุดในหมวดหมู่ของมันและจัดรูปแบบป้ายให้แสดงเปอร์เซ็นต์

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # บันทึกงานนำเสนอที่มีแผนภูมิ.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **แสดงเครื่องหมายเปอร์เซ็นต์กับป้ายข้อมูลของแผนภูมิ**

ส่วนนี้แสดงวิธีแสดงเปอร์เซ็นต์ในป้ายข้อมูลของแผนภูมิและรวมเครื่องหมายเปอร์เซ็นต์โดยใช้ Aspose.Slides คุณจะได้เรียนรู้วิธีเปิดใช้งานค่าร้อยละสำหรับชุดทั้งหมดหรือจุดเฉพาะ (เหมาะสำหรับแผนภูมิปาย, ดอนัท และแผนภูมิ 100% stacked) และวิธีควบคุมการจัดรูปแบบผ่านตัวเลือกของป้ายหรือรูปแบบตัวเลขที่กำหนดเอง

ตัวอย่าง Python ด้านล่างแสดงวิธีเพิ่มเครื่องหมายเปอร์เซ็นต์ให้กับป้ายข้อมูลของแผนภูมิ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # รับอ้างอิงสไลด์ตามดัชนี.
    slide = presentation.slides[0]

    # สร้างแผนภูมิ PercentsStackedColumn บนสไลด์.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # รับ workbook ของข้อมูลแผนภูมิ.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # เพิ่มชุดข้อมูลใหม่.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # ตั้งค่าสีเติมของชุดข้อมูล.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # ตั้งค่าคุณสมบัติรูปแบบป้ายข้อมูล.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # เพิ่มชุดข้อมูลใหม่.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # ตั้งค่าชนิดการเติมและสี.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # บันทึกงานนำเสนอ.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าระยะห่างของป้ายจากแกน**

ส่วนนี้แสดงวิธีควบคุมระยะห่างระหว่างป้ายข้อมูลและแกนของแผนภูมิใน Aspose.Slides การปรับค่าออฟเซ็ตนี้ช่วยป้องกันการทับซ้อนและเพิ่มความอ่านง่ายในภาพที่มีความหนาแน่นสูง

โค้ด Python ด้านล่างแสดงวิธีตั้งค่าระยะห่างของป้ายจากแกนประเภทเมื่อทำงานกับแผนภูมิที่ใช้แกน:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:
    # รับอ้างอิงสไลด์.
    slide = presentation.slides[0]

    # สร้างแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # ตั้งค่าระยะห่างของป้ายจากแกนหมวดหมู่ (แนวนอน).
    chart.axes.horizontal_axis.label_offset = 500

    # บันทึกงานนำเสนอ.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **ปรับตำแหน่งป้าย**

เมื่อคุณสร้างแผนภูมิที่ไม่ได้ใช้แกน เช่น แผนภูมิปาย, ป้ายข้อมูลอาจอยู่ใกล้ขอบเกินไป ในกรณีนั้นให้ปรับตำแหน่งป้ายเพื่อให้เส้นนำแสดงอย่างชัดเจน

โค้ด Python ด้านล่างแสดงวิธีปรับตำแหน่งป้ายบนแผนภูมิปาย:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![ตำแหน่งป้ายที่เปลี่ยนแปลง](changed_label_position.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลทับซ้อนกันในแผนภูมิที่หนาแน่นได้อย่างไร?**

รวมการวางป้ายอัตโนมัติ, เส้นนำ, และลดขนาดตัวอักษร; หากจำเป็นให้ซ่อนฟิลด์บางส่วน (เช่น ประเภท) หรือแสดงป้ายเฉพาะจุดสุดยอด/สำคัญเท่านั้น

**ฉันจะปิดการใช้งานป้ายสำหรับค่าเป็นศูนย์, ค่าเป็นลบ, หรือค่าว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้งานป้ายและปิดการแสดงสำหรับค่าที่เป็น 0, ค่าเป็นลบ, หรือค่าว่างตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายคงที่เมื่อส่งออกเป็น PDF/ภาพได้อย่างไร?**

กำหนดแบบอักษร (ครอบครัว, ขนาด) อย่างชัดเจนและตรวจสอบว่าแบบอักษรนั้นมีอยู่บนเครื่องเรนเดอร์เพื่อหลีกเลี่ยงการใช้แบบอักษรสำรอง