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
- ควบคุมแกน
- จัดการแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides for Python via .NET เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint และ OpenDocument สำหรับรายงานและการสร้างภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for Python via .NET ครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ระยะห่างของป้ายชื่อประเภทและติ๊กมาร์ค, ประเภทของวันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การกำหนดตำแหน่งแกน, หน่วยการแสดงผล, และการปรับสเกลลอการิทึม

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [งานนำเสนอ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่พร้อมข้อมูลเริ่มต้น เรียก [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิเฉพาะล่าสุด

อ่าน [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) และ [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) เพื่อรับขีดจำกัดของแกน, และ [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) กับ [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) เพื่อรับระยะห่างของติ๊ก [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) และ [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าต่าง ๆ ลงในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) เพื่อสลับบทบาทของ series และ category ในข้อมูลแผนภูมิ แต่ละ category เดิมจะกลายเป็น series และแต่ละ series เดิมจะกลายเป็น category สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงหัวแถวและคอลัมน์ category ก่อนสลับแถวและคอลัมน์ และบันทึกแผนภูมิที่มีสี่ series และสาม category

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

ตั้งค่า [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) เป็น `False` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกแผนภูมิที่ซ่อนแกนแนวตั้ง

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **ปิดการแสดงแกนแนวนอนสำหรับแผนภูมิเส้น**

ตั้งค่า [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) เป็น `False` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกแผนภูมิที่ซ่อนแกนแนวนอน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **เปลี่ยนแกนประเภท**

ตั้งค่า [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) เพื่อเลือกแกนประเภทเป็นวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx` ซึ่งมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเซลล์ category มีค่าตัวเลขของวันที่ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การตั้งค่า [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) เป็น `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) เป็น `1`, และ [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) เป็น `months` จะทำให้ติ๊กหลักอยู่ที่ช่วงหนึ่งเดือน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ควบคุมระยะห่างของป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลาย category ให้ลดจำนวนป้ายชื่อแกนที่แสดงโดยไม่ต้องลบ category หรือจุดข้อมูล ตั้งค่า [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) เป็น `False` จากนั้นตั้งค่า [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) เป็นช่วง category ที่ต้องการ สำหรับ category แบบข้อความในลำดับปกติ การนับเริ่มจาก category แรก:

| ช่วง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | ประเภท 1, ประเภท 2, ประเภท 3, ... ประเภท 24 |
| `2` | ประเภท 1, ประเภท 3, ประเภท 5, ... ประเภท 23 |
| `3` | ประเภท 1, ประเภท 4, ประเภท 7, ... ประเภท 22 |

ช่วง `3` จะแสดงป้ายทุกสามตำแหน่ง โดยมีสองป้ายที่ซ่อนระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดช่องว่างอัตโนมัติจะเลือกช่วงตามพื้นที่ที่มี; ไม่ได้บังคับให้แสดงทุกป้าย

ติ๊กมาร์คมีการควบคุมแยกต่างหาก ตั้งค่า [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) เป็น `False` และใช้ [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) เพื่อกำหนดช่วงของมัน ตัวอย่างเช่น `1` จะทำให้มีติ๊กมาร์คที่ทุกช่วง category ในขณะที่ป้ายชื่อปรากฏเพียงทุกสาม category ตั้งค่า [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) เป็นสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าคุณสมบัติอัตโนมัติใด ๆ ให้กลับเป็น `True` จะให้แผนภูมิเฝ้าช่วงนั้นใหม่อีกครั้ง

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่สมบูรณ์ซึ่งสร้าง 24 category และ 1 series แล้วบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างป้ายด้วยติ๊กมาร์คอิสระ, และการคืนค่าเป็นอัตโนมัติ สองสำเนาเก็บข้อมูลแผนภูมิดั้งเดิมไว้ ไม่ต้องมีการนำเสนออินพุต ข้อความป้ายแนวนอนทำให้เห็นความแตกต่างของความหนาแน่นได้ง่าย

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # สไลด์ 2: แสดงป้ายทุกสามตำแหน่ง แต่คงให้มีติ๊กมาร์คสำหรับทุก category.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # สไลด์ 3: ให้แผนภูมิกำหนดช่วงทั้งสองใหม่อีกครั้ง.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายชื่อของทุกสอง category จะถูกแสดงและบรรทัดหักสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างกันตามขนาดแผนภูมิ, ฟอนท์, และตัวเรนเดอร์

![การจัดช่องว่างป้ายประเภทอัตโนมัติพร้อมคอลัมน์ 24 คอลัมน์ที่มองเห็นได้ทั้งหมด](category-axis-automatic.png)

**การจัดช่องว่างด้วยตนเอง (สไลด์ 2):** ป้ายทุกสามตำแหน่งจะแสดงในบรรทัดเดียว ในขณะที่ติ๊กมาร์คยังคงอยู่ที่ทุกช่วง category ทั้ง 24 คอลัมน์ รวมถึงคอลัมน์ที่ไม่มีป้าย ยังคงมองเห็นได้ด้วยค่าเดียวกัน สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงข้างต้น

![การจัดช่องว่างป้ายประเภทด้วยตนเองโดยใช้ช่วงสาม พร้อมคอลัมน์ 24 คอลัมน์ที่มองเห็นได้ทั้งหมด](category-axis-manual.png)

### **เลือกแกนและช่วงที่เหมาะสม**

ใช้ช่วงนับ category นี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่, หรือแผนภูมิบาร์ ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิบาร์แนวนอนแกนประเภทเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับ [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). การจัดช่องว่างของติ๊กมาร์คยังใช้กับแกน series ในแผนภูมิที่มีแกนดังกล่าว

ห้ามใช้การจัดช่องว่างของป้ายประเภทเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) กำหนดความแตกต่างของค่า: ตัวอย่างเช่น major unit ของ `10` จะทำให้มีติ๊กที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มจากศูนย์ ส่วนช่วงป้ายประเภท `3` จะนับตำแหน่ง category โดยไม่คำนึงถึงค่าข้อมูล Scatter และ bubble chart ใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้ major unit และสเกลตามเวลาตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **กำหนดรูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยค่าประจำปีสี่ค่า วันที่ถูกเก็บเป็นหมายเลขซีเรียล OLE Automation ในแผ่นงานแรก (index `0`) ตั้งค่า [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) เป็นแกนวันที่ ปิดการเชื่อมโยง [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) และกำหนด `yyyy` ให้กับ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) เพื่อให้ป้ายประเภทแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบของเซลล์

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่ามุมการหมุนสำหรับหัวเรื่องแกนแผนภูมิ**

เปิดใช้ [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) บนแกนแนวตั้ง, ระบุข้อความหัวเรื่อง, และตั้งค่า [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อหมุนหัวเรื่อง มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวเรื่องแกนค่าถูกหมุน 90 องศา

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) เพื่อควบคุมว่าแกนค่าจะตัดกับแกนประเภทระหว่าง category หรือที่ติ๊กมาร์คของ category คุณสมบัตินี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `True` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ตั้งค่า [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) เพื่อสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วย [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ตั้งเป็น `MILLIONS` ค่า 60,000,000 จะปรากฏเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และกำหนดหน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดค่าตารางเชิงลอการิทึมสำหรับแกนค่า**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกครอบคลุมหลายระดับตัวอย่างเช่น บริการอาจรับ 10, 100, 1,000, 10,000, และ 100,000 คำขอในห้าวงระยะ บนสเกลเชิงเส้น ค่าที่เล็กกว่าจะอยู่ใกล้ศูนย์กัน การสเกลลอการิทึมทำให้การเติบโตสัมพัทธ์ง่ายต่อการเปรียบเทียบ ระยะห่างที่เท่ากันแสดงอัตราส่วนที่เท่ากันแทนความแตกต่างที่เท่ากัน

ตั้งค่า [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) เป็น `True` บนแกนค่าและใช้ [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) เพื่อเลือกฐาน การตั้งค่านี้เปลี่ยนการแสดงค่าที่มีอยู่ ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นคุณลักษณะแยกต่างหากที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าคือ [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). สำหรับแผนภูมิบาร์แนวนอนคือ [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Scatter และ bubble chart มีแกนค่าสองแกน ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง อย่าใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5`. ด้วยฐาน `10` ค่าพลังที่ต่อเนื่องเช่น 10, 100, 1,000, 10,000 จะห่างกันเท่าเดิม

### **เปรียบเทียบสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าแบบบนสไลด์แรก, จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง สไลด์ทั้งสองเก็บข้อมูลเดียวกัน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # เก็บสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะห่างแนวตั้งที่เท่ากันหมายถึงความแตกต่างที่เท่ากันของจำนวนคำขอ ค่าที่ใหญ่ที่สุดจะครอบงำแผนภูมิ ทำให้ค่าที่เล็กกว่าจะมองเห็นได้ยาก

![แผนภูมิเส้นใน PowerPoint แสดงห้าจำนวนคำขอบนแกนค่าตามสเกลเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะห่างแนวตั้งที่เท่ากันหมายถึงอัตราส่วนที่เท่าเทียม แต่ละช่วงมีจำนวนคำขอเพิ่มขึ้นสิบเท่า ทำให้จุดต่าง ๆ สร้างเส้นตรงที่ขึ้นสูงบนสเกลฐาน 10 แกนป้ายยังคงแสดงจำนวนคำขอเดิม

![ห้าจำนวนคำขอเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงค่าเป็นบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าติดลบมีความหมาย ให้ใช้สเกลเชิงเส้นหรือแสดงแยกออก หากการยกเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์ ให้อธิบายการละเว้น อย่าทดแทนโดยอัตโนมัติกับค่าบวกเล็ก ๆ เนื่องจากจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะกำหนดค่าที่แกนหนึ่งตัดแกนอีก (การตัดแกน) ได้อย่างไร?**

ใช้ [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) เพื่อเลือกพฤติกรรมการตัด เพื่อระบุค่าตัดเชิงตัวเลข ให้ตั้งค่า [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายตำแหน่งการตัดแกนไปยังแนวฐานที่เหมาะสม

**ฉันสามารถกำหนดตำแหน่งป้ายติ๊กสัมพันธ์กับแกนได้อย่างไร?**

ตั้งค่า [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO`, หรือ `NONE`. เพื่อควบคุมติ๊กมาร์คเอง ใช้ [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) หรือ [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งป้าย.