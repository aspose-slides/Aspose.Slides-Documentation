---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย Python
linktitle: แกนแผนภูมิ
type: docs
url: /th/python-net/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ดูแลแกน
- คุณสมบัติของแกน
- ค่ามากสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นหาวิธีใช้ Aspose.Slides for Python via .NET เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint และ OpenDocument สำหรับรายงานและการแสดงผลข้อมูล."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิใน Aspose.Slides โดยแสดงวิธีการดึงค่าจริงของแกน, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทแกนประเภท, ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท, หมุนชื่อแกน, ตั้งตำแหน่งแกน, และแสดงหน่วยบนแกนค่าค่า

## **การรับค่ามากสุดบนแกนแนวตั้งของแผนภูมิ**
Aspose.Slides for Python via .NET ให้คุณรับค่าต่ำสุดและค่าสูงสุดบนแกนแนวตั้ง ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลค่าเริ่มต้น
4. รับค่ามากสุดจริงบนแกน
5. รับค่าต่ำสุดจริงบนแกน
6. รับหน่วยหลักจริงของแกน
7. รับหน่วยย่อยจริงของแกน
8. รับสเกลหน่วยหลักจริงของแกน
9. รับสเกลหน่วยย่อยจริงของแกน

โค้ดตัวอย่าง—การดำเนินการตามขั้นตอนข้างต้น—แสดงวิธีการรับค่าที่ต้องการใน Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# บันทึกงานนำเสนอ
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **การสลับข้อมูลระหว่างแกน**
Aspose.Slides ให้คุณสลับข้อมูลระหว่างแกนอย่างรวดเร็ว—ข้อมูลที่แสดงบนแกนแนวตั้ง (y‑axis) จะย้ายไปยังแกนแนวนอน (x‑axis) และในทางกลับกัน

โค้ด Python นี้แสดงวิธีการทำการสลับข้อมูลระหว่างแกนบนแผนภูมิ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# สร้างงานนำเสนอเปล่า
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #สลับแถวและคอลัมน์
            
    # บันทึกงานนำเสนอ
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **การปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

โค้ด Python นี้แสดงวิธีการซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **การปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

โค้ดนี้แสดงวิธีการซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **การเปลี่ยนแกนประเภท**

โดยใช้คุณสมบัติ**CategoryAxisType** คุณสามารถระบุประเภทแกนประเภทที่ต้องการ (**date** หรือ **text**) โค้ด Python ต่อไปนี้แสดงการทำงาน:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **การตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**
Aspose.Slides for Python via .NET ให้คุณตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท การดำเนินการนี้แสดงในโค้ด Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **การตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**
Aspose.Slides for Python via .NET ให้คุณตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ โค้ด Python นี้แสดงการดำเนินการ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **การตั้งตำแหน่งแกนในแกนประเภทหรือแกนค่า**
Aspose.Slides for Python via .NET ให้คุณตั้งตำแหน่งแกนในแกนประเภทหรือแกนค่า โค้ด Python นี้แสดงวิธีการทำ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **การเปิดใช้งานการแสดงหน่วยบนแกนค่าของแผนภูมิ**
Aspose.Slides for Python via .NET ให้คุณกำหนดค่าให้แผนภูมิมีการแสดงหน่วยบนแกนค่า โค้ด Python นี้แสดงการดำเนินการ:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**ฉันจะตั้งค่าตำแหน่งที่แกนหนึ่งตัดกันกับอีกแกน (axis crossing) อย่างไร?**

แกนมี[การตั้งค่า crossing](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/axis/cross_type/) คุณสามารถเลือกให้ตัดที่ศูนย์, ที่ค่าประเภท/ค่า มากสุด, หรือที่ค่าตัวเลขเฉพาะ ซึ่งเป็นประโยชน์สำหรับการเลื่อนแกน X ขึ้นหรือลงหรือเพื่อเน้นเส้นฐาน

**ฉันจะวางตำแหน่งป้ายบอกระดับ (tick labels) เทียบกับแกน (ข้างเคียง, นอก, ใน) อย่างไร?**

ตั้งค่า[ตำแหน่งป้าย](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/axis/major_tick_mark/)เป็น "cross", "outside", หรือ "inside" การตั้งค่านี้ส่งผลต่อการอ่านและช่วยประหยัดพื้นที่ โดยเฉพาะกับแผนภูมิขนาดเล็ก