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
- สีสไลซ์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมวงกลมใน Python ด้วย Aspose.Slides พร้อมส่งออกไปยัง PowerPoint และ OpenDocument ช่วยเร่งกระบวนการบอกรายละเอียดข้อมูลของคุณในไม่กี่วินาที."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลมใน Aspose.Slides โดยแสดงวิธีการกำหนดค่าตัวเลือกการวางแผนรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีเปิดใช้งานการระบายสีสไลซ์อัตโนมัติสำหรับแผนภูมิวงกลมมาตรฐาน

ตัวอย่างมุ่งเน้นที่ขั้นตอนการปรับแต่งแผนภูมิอย่างเป็นประโยชน์ เช่น การเพิ่มแผนภูมิลงบนสไลด์ การปรับตั้งค่าซีรีส์และป้ายกำกับ การแทนที่ข้อมูลแผนภูมิปริยายด้วยหมวดหมู่และค่าแบบกำหนดเอง และการบันทึกการนำเสนอที่อัปเดต

## **ตัวเลือกการวางแผนรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for Python ผ่าน .NET ตอนนี้รองรับตัวเลือกการวางแผนรองสำหรับแผนภูมิ Pie of Pie หรือ Bar of Pie แล้ว ในหัวข้อนี้ เราจะดูตัวอย่างวิธีการระบุตัวเลือกเหล่านี้โดยใช้ Aspose.Slides เพื่อระบุคุณสมบัติต่าง ๆ กรุณาตามขั้นตอนด้านล่าง:

1. สร้างอ็อบเจ็กต์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เพิ่มแผนภูมิลงบนสไลด์
3. ระบุตัวเลือกการวางแผนรองของแผนภูมิ
4. บันทึกการนำเสนอลงดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าคุณสมบัติต่าง ๆ ของแผนภูมิ Pie of Pie

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:
    # เพิ่มแผนภูมิลงบนสไลด์
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # ตั้งค่าคุณสมบัติต่าง ๆ
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # บันทึกการนำเสนอลงดิสก์
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าสีสไลซ์อัตโนมัติสำหรับแผนภูมิวงกลม**

Aspose.Slides for Python ผ่าน .NET มี API ที่ง่ายต่อการตั้งค่าสีสไลซ์อัตโนมัติของแผนภูมิวงกลม ตัวอย่างโค้ดนี้ใช้การตั้งค่าคุณสมบัติดังกล่าว

1. สร้างอินสแตนซ์ของคลาส Presentation
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิด้วยข้อมูลค่าปริยาย
4. ตั้งค่าชื่อแผนภูมิ
5. ตั้งค่าซีรีส์แรกให้แสดงค่า
6. ตั้งดัชนีของแผ่นข้อมูลแผนภูมิ
7. ดึงเวิร์กชีตข้อมูลแผนภูมิ
8. ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติ
9. เพิ่มหมวดหมู่ใหม่
10. เพิ่มซีรีส์ใหม่

บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
with slides.Presentation() as presentation:
	# เข้าถึงสไลด์แรก
	slide = presentation.slides[0]

	# เพิ่มแผนภูมิด้วยข้อมูลค่าปริยาย
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# ตั้งค่าชื่อแผนภูมิ
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# ตั้งค่าซีรีส์แรกให้แสดงค่า
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# ตั้งดัชนีของแผ่นข้อมูลแผนภูมิ
	defaultWorksheetIndex = 0

	# ดึงเวิร์กชีตข้อมูลแผนภูมิ
	fact = chart.chart_data.chart_data_workbook

	# ลบซีรีส์และหมวดหมู่ที่สร้างโดยอัตโนมัติ
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# เพิ่มหมวดหมู่ใหม่
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# เพิ่มซีรีส์ใหม่
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# ตอนนี้กำลังใส่ข้อมูลให้ซีรีส์
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**รองรับรูปแบบ 'Pie of Pie' และ 'Bar of Pie' หรือไม่?**

ใช่, ไลบรารีนี้ [รองรับ](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/charttype/) การวางแผนรองสำหรับแผนภูมิวงกลม รวมถึงประเภท 'Pie of Pie' และ 'Bar of Pie'

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ได้, คุณสามารถ [ส่งออกแผนภูมิเองเป็นภาพ](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/get_image/) (เช่น PNG) โดยไม่ต้องส่งออกการนำเสนอทั้งหมด