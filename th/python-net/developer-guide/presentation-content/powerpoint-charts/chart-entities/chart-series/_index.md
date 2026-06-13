---
title: จัดการชุดข้อมูลแผนภูมิใน Python
linktitle: ชุดข้อมูล
type: docs
url: /th/python-net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของซีรีส์
- สีของซีรีส์
- สีประเภท
- ชื่อซีรีส์
- จุดข้อมูล
- ช่องว่างของซีรีส์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิใน Python สำหรับ PowerPoint (PPT/PPTX) ด้วยตัวอย่างโค้ดที่ใช้งานได้จริงและแนวทางปฏิบัติที่ดีที่สุดเพื่อเพิ่มประสิทธิภาพการนำเสนอข้อมูลของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายหน้าที่ของ [ChartSeries](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/) ใน Aspose.Slides for Python โดยมุ่งเน้นที่วิธีการจัดโครงสร้างและการแสดงผลข้อมูลภายในงานนำเสนอ สิ่งเหล่านี้เป็นวัตถุที่ให้พื้นฐานในการกำหนดชุดจุดข้อมูล, ประเภท, และพารามิเตอร์การแสดงผลในแผนภูมิ การทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/) ทำให้ผู้พัฒนาสามารถรวมแหล่งข้อมูลพื้นฐานได้อย่างราบรื่นและควบคุมการแสดงข้อมูลอย่างเต็มที่ ส่งผลให้งานนำเสนอแบบไดนามิกและขับเคลื่อนด้วยข้อมูลที่สื่อสารข้อมูลเชิงลึกและการวิเคราะห์ได้อย่างชัดเจน

ซีรีส์คือแถวหรือคอลัมน์ของตัวเลขที่ถูกพล็อตในแผนภูมิ

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของซีรีส์**

คุณสมบัติ [ChartSeries.overlap](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/overlap/) ควบคุมวิธีที่แท่งและคอลัมน์ทับซ้อนกันในแผนภูมิ 2 มิติโดยระบุช่วงจาก -100 ถึง 100 เนื่องจากคุณสมบัตินี้เชื่อมโยงกับกลุ่มซีรีส์โดยรวมไม่ใช่กับซีรีส์เดี่ยว จึงเป็นแบบอ่านอย่างเดียวระดับซีรีส์ หากต้องการกำหนดค่าการทับซ้อน ให้ใช้คุณสมบัติ `parent_series_group.overlap` ที่อ่าน/เขียนได้ ซึ่งจะนำค่าการทับซ้อนที่ระบุไปใช้กับซีรีส์ทั้งหมดในกลุ่มนั้น

ด้านล่างเป็นตัวอย่าง Python ที่แสดงวิธีสร้างงานนำเสนอ, เพิ่มแผนภูมิคอลัมน์แบบกลุ่ม, เข้าถึงซีรีส์แผนภูมิกลุ่มแรก, ตั้งค่าการทับซ้อน, แล้วบันทึกผลเป็นไฟล์ PPTX:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_overlap = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[0]
    if series.overlap == 0:
        # ตั้งค่าการทับซ้อนของซีรีส์.
        series.parent_series_group.overlap = series_overlap

    # บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![การทับซ้อนของซีรีส์](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

Aspose.Slides ทำให้การปรับสีเติมของซีรีส์ในแผนภูมิเป็นเรื่องง่าย ช่วยให้คุณไฮไลท์จุดข้อมูลเฉพาะและสร้างแผนภูมิที่ดูน่าสนใจ ผ่านอ็อบเจ็กต์ [Format](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/format/) ที่รองรับรูปแบบการเติมหลายแบบ, การกำหนดสี, และตัวเลือกสไตล์ขั้นสูงอื่น ๆ หลังจากเพิ่มแผนภูมิลงในสไลด์และเข้าถึงซีรีส์ที่ต้องการ เพียงรับซีรีส์และกำหนดสีเติมที่เหมาะสม นอกจากการเติมสีทึบแล้ว คุณยังสามารถใช้การเติมแบบไล่สีหรือแบบลวดลายเพื่อเพิ่มความยืดหยุ่นในการออกแบบ เมื่อตั้งค่าสีตามที่ต้องการแล้ว ให้บันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

โค้ด Python ด้านล่างแสดงวิธีเปลี่ยนสีของซีรีส์แรก:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

series_color = draw.Color.blue

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    # ตั้งค่าสีของซีรีส์แรก.
    series = chart.chart_data.series[0]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color

    # บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![สีของซีรีส์](series_color.png)

## **เปลี่ยนชื่อซีรีส์** 

Aspose.Slides มีวิธีง่ายๆ ในการแก้ไขชื่อของซีรีส์ในแผนภูมิ ทำให้การตั้งป้ายข้อมูลเป็นเรื่องชัดเจนและมีความหมายมากขึ้น โดยการเข้าถึงเซลล์ worksheet ที่เกี่ยวข้องในข้อมูลแผนภูมิ ผู้พัฒนาสามารถปรับแต่งการแสดงผลของข้อมูลได้ การแก้ไขนี้เป็นประโยชน์เมื่อต้องอัปเดตหรือชี้แจงชื่อซีรีส์ตามบริบทของข้อมูล หลังจากเปลี่ยนชื่อซีรีส์แล้ว สามารถบันทึกงานนำเสนอเพื่อบันทึกการเปลี่ยนแปลง

ด้านล่างเป็นโค้ด Python ที่แสดงกระบวนการนี้:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    
    # ตั้งชื่อของซีรีส์แรก.
    series_cell = chart.chart_data.chart_data_workbook.get_cell(0, 0, 1)
    series_cell.value = series_name
    
    # บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

โค้ด Python ต่อไปนี้แสดงวิธีทางเลือกในการเปลี่ยนชื่อซีรีส์:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

series_name = "New name"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    series = chart.chart_data.series[0]
    
    # ตั้งชื่อของซีรีส์แรก.
    series.name.as_cells[0].value = series_name

    # บันทึกไฟล์งานนำเสนอลงดิสก์.
    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX) 
```

ผลลัพธ์:

![ชื่อของซีรีส์](series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

Aspose.Slides for Python ให้คุณรับสีเติมอัตโนมัติสำหรับซีรีส์ในพื้นที่พล็อต หลังจากสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) คุณสามารถอ้างอิงสไลด์ที่ต้องการโดยใช้ดัชนี แล้วเพิ่มแผนภูมิตามประเภทที่ต้องการ (เช่น `ChartType.CLUSTERED_COLUMN`) โดยการเข้าถึงซีรีส์ในแผนภูมิ คุณสามารถรับสีเติมอัตโนมัติได้

โค้ด Python ด้านล่างอธิบายขั้นตอนนี้อย่างละเอียด

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มแผนภูคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    for i in range(len(chart.chart_data.series)):
        # รับสีเติมของซีรีส์.
        color = chart.chart_data.series[i].get_automatic_series_color()
        print(f"Series {i} color: {color.name}")
```

ผลลัพธ์ตัวอย่าง:

```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **ตั้งค่าสีเติมกลับค่าให้กับซีรีส์**

เมื่อซีรีส์ของคุณมีค่าบวกและลบ การเติมสีเดียวกันให้ทุกคอลัมน์หรือแท่งอาจทำให้แผนภูมิอ่านยาก Aspose.Slides for Python ให้คุณกำหนดสีเติมกลับค่า—การเติมสีแยกที่ถูกนำไปใช้โดยอัตโนมัติกับจุดข้อมูลที่อยู่ต่ำกว่าศูนย์—เพื่อให้ค่าลบโดดเด่นในชั่ววินาที ในส่วนนี้คุณจะได้เรียนรู้วิธีเปิดใช้งานตัวเลือกนั้น, เลือกสีที่เหมาะสม, และบันทึกงานนำเสนอที่อัปเดต

ตัวอย่างโค้ดต่อไปนี้แสดงการทำงาน:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

invert_color = draw.Color.red

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    workBook = chart.chart_data.chart_data_workbook

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # เพิ่มหมวดหมู่ใหม่.
    chart.chart_data.categories.add(workBook.get_cell(0, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workBook.get_cell(0, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workBook.get_cell(0, 3, 0, "Category 3"))

    # เพิ่มซีรีส์ใหม่.
    series = chart.chart_data.series.add(workBook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # เติมข้อมูลให้ซีรีส์.
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 1, 1, -20))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(workBook.get_cell(0, 3, 1, -30))

    # ตั้งค่าการสีสำหรับซีรีส์.
    series_color = series.get_automatic_series_color()
    series.invert_if_negative = True
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = series_color
    series.inverted_solid_fill_color.color = invert_color
    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![สีเติมแน-solid ที่กลับค่า](inverted_solid_fill_color.png)

คุณสามารถกลับสีเติมสำหรับจุดข้อมูลเดียวแทนที่จะเป็นทั้งซีรีส์ได้ เพียงเข้าถึง `ChartDataPoint` ที่ต้องการและตั้งค่า `invert_if_negative` เป็น `True`

โค้ดต่อไปนี้แสดงวิธีทำ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200, True)
	chart.chart_data.series.clear()

	series = series.add(chart.chart_data.chart_data_workbook.get_cell(0, "B1"), chart.type)

	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B2", -5))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B3", 3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B4", -3))
	series.data_points.add_data_point_for_bar_series(chart.chart_data.chart_data_workbook.get_cell(0, "B5", 1))

	series.invert_if_negative = False
	series.data_points[2].invert_if_negative = True

	presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **ล้างข้อมูลสำหรับจุดข้อมูลเฉพาะ**

บางครั้งแผนภูมิมีค่าทดสอบ, ค่าขยาย, หรือรายการล้าสมัยที่ต้องการลบโดยไม่ต้องสร้างซีรีส์ใหม่ทั้งหมด Aspose.Slides for Python ให้คุณเลือกจุดข้อมูลใดก็ได้โดยใช้ดัชนี, ล้างเนื้อหา, และรีเฟรชพล็อตทันที ทำให้จุดที่เหลือเลื่อนตำแหน่งและแกนปรับขนาดอัตโนมัติ

ตัวอย่างโค้ดต่อไปนี้แสดงการทำงาน:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test_chart.pptx") as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes[0]
    series = chart.chart_data.series[0]

    for data_point in series.data_points:
        data_point.x_value.as_cell.value = None
        data_point.y_value.as_cell.value = None

    series.data_points.clear()

    presentation.save("clear_data_points.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าความกว้างของช่องว่างระหว่างซีรีส์**

ความกว้างของช่องว่างควบคุมปริมาณพื้นที่ว่างระหว่างคอลัมน์หรือแท่งที่อยู่ติดกัน—ช่องว่างกว้างทำให้แต่ละประเภทเด่นชัดขึ้น, ส่วนช่องว่างแคบทำให้แสดงผลกระชับและหนาแน่น มากยิ่งขึ้น ผ่าน Aspose.Slides for Python คุณสามารถปรับพารามิเตอร์นี้สำหรับซีรีส์ทั้งหมด เพื่อให้ได้สมดุลภาพที่ต้องการโดยไม่ต้องเปลี่ยนแปลงข้อมูลพื้นฐาน

โค้ดต่อไปนี้แสดงวิธีตั้งค่าความกว้างของช่องว่างสำหรับซีรีส์:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

gap_width = 30

# สร้างงานนำเสนอเปล่า.
with slides.Presentation() as presentation:

    # เข้าถึงสไลด์แรก.
    slide = presentation.slides[0]

    # เพิ่มแผนภูมด้วยข้อมูลเริ่มต้น.
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("default_gap_width.pptx", slides.export.SaveFormat.PPTX)

    # ตั้งค่าความกว้างช่องว่าง gap_width.
    series = chart.chart_data.series[0]
    series.parent_series_group.gap_width = gap_width

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์:

![ความกว้างของช่องว่าง](gap_width.png)

## **FAQ**

**มีขีดจำกัดจำนวนซีรีส์ที่แผนภูมิหนึ่งสามารถมีได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดคงที่สำหรับจำนวนซีรีส์ที่คุณเพิ่ม ขีดจำกัดเชิงปฏิบัติจะแตกต่างตามความสามารถในการอ่านแผนภูมิและหน่วยความจำที่แอปพลิเคชันของคุณมี

**ถ้าคอลัมน์ในกลุ่มใกล้กันเกินไปหรือห่างกันเกินไปควรทำอย่างไร?**

ปรับค่าการตั้งค่า [gap_width](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartseries/gap_width/) สำหรับซีรีส์นั้น (หรือกลุ่มซีรีส์แม่) การเพิ่มค่าจะทำให้คอลัมน์ห่างกันมากขึ้น, การลดค่าจะทำให้คอลัมน์ใกล้กันมากขึ้น