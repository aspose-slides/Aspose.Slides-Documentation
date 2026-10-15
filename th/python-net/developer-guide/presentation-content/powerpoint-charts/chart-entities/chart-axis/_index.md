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
- ค่าสูงสุด
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
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint และ OpenDocument สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for Python via .NET รวมถึงค่าที่คำนวณได้ของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ช่วงเวลาของป้ายชื่อประเภทและเครื่องหมายบรรทัด วันที่ของประเภทและการจัดรูปแบบ การหมุนหัวข้อ การวางตำแหน่งแกน หน่วยการแสดงผล และการสเกลแบบลอการิทึม

## **รับค่ามากสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่กับข้อมูลค่าเริ่มต้น เรียกใช้ [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน

อ่าน [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) และ [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) เพื่อกำหนดขอบเขตของแกน, และ [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) กับ [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) เพื่อกำหนดช่วงของเครื่องหมายบรรทัด [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) และ [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าดังกล่าวในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) เพื่อแลกเปลี่ยนบทบาทของชุดข้อมูลและประเภทในข้อมูลแผนภูมิ แต่ละประเภทก่อนหน้าจะกลายเป็นชุดข้อมูลและแต่ละชุดข้อมูลก่อนหน้าจะกลายเป็นประเภท สิ่งนี้เปลี่ยนการจัดกลุ่มข้อมูล แต่ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อผูกข้อมูลค่าเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวตารางและคอลัมน์ประเภทก่อนสลับแถวและคอลัมน์ จะบันทึกแผนภูมิที่มีสี่ชุดข้อมูลและสามประเภท

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

## **กลับลำดับการพล็อตของแกน**

ใช้ [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) เพื่อกลับลำดับของแกนประเภทหรือค่า ตัวอย่างเช่น แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโปรเจกต์จากบนลงล่างในลำดับเดียวกับแผ่นงาน: Planning, Development, Testing การกลับแกนจะเปลี่ยนทิศทางการพล็อต; ไม่ได้เรียงลำดับหรือจัดเรียงข้อมูลในเวิร์กบุ๊ก โดยเปรียบเทียบกับ [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) ที่แลกเปลี่ยนบทบาทของชุดข้อมูลและประเภท

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งชุดข้อมูล จะบันทึกงานนำเสนอที่มีสามสไลด์: ลำดับปกติ, ประเภทกลับลำดับ, และค่ากลับลำดับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกัน และเพียงแกนหนึ่งที่ถูกกลับลำดับในแต่ละสำเนา

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # สไลด์ 2: แสดงหมวดหมู่แรกที่ด้านบน.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # คงแกนค่าตามแนวนอนไว้ที่ด้านล่าง.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # สไลด์ 3: กลับสเกลตัวเลขแนวนอนเท่านั้น.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

การกลับแกนยังสามารถย้ายแกนตั้งฉากไปยังด้านตรงข้ามของพล็อตได้ [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) ควบคุมว่ากลไกแกนอื่นจะตัดกับแกนที่กำลังกำหนดไว้ที่ตำแหน่งใด ในสไลด์ 2 การตั้งค่าเป็น `MAXIMUM` บนแกนประเภทที่กลับลำดับทำให้แกนค่าตั้งแนวนอนอยู่ที่ด้านล่าง สำหรับจุดตัดที่เฉพาะเจาะจง ให้ใช้ [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) ตรวจสอบการตั้งค่าการตัดเมื่อเปลี่ยนทิศทาง, โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดที่กำหนดเองแล้ว ตั้งค่า `is_plot_order_reversed` กลับเป็น `False` เพื่อคืนทิศทางการพล็อตปกติ; การตั้งค่าการตัดเป็นค่าแยกต่างหาก

| ลำดับปกติ (สไลด์ 1) | ประเภทกลับลำดับ (สไลด์ 2) | ค่ากลับลำดับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับประเภทและค่าตามปกติ](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงประเภทจากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่ากลับลำดับและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| ประเภทวิ่งจากล่างขึ้นบน; ค่ามาเพิ่มจากซ้ายไปขวา | Planning, Development, และ Testing วิ่งจากบนลงล่าง ค่และลำดับแถวของเวิร์กบุ๊กไม่เปลี่ยน | ประเภทคงลำดับปกติ; ค่ามาเพิ่มจากขวาไปซ้าย แกนประเภทตัดที่ศูนย์ด้านขวา |

## **ซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น**

ตั้งค่า [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) เป็น `False` บนแกนแนวตั้งเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยซ่อนแกนแนวตั้ง

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **ซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น**

ตั้งค่า [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) เป็น `False` บนแกนแนวนอนเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยซ่อนแกนแนวนอน

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

ตั้งค่า [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) เพื่อเลือกแกนประเภทเป็นวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx` โดยที่แผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ประเภทมีค่าที่เป็นเลขวันที่แบบ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การตั้งค่า [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) เป็น `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) เป็น `1`, และ [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) เป็น months จะวางเครื่องหมายหลักที่ช่วงหนึ่งเดือน

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

## **ควบคุมช่วงป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลายประเภท ให้ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ลบประเภทหรือจุดข้อมูล ตั้งค่า [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) เป็น `False` แล้วตั้งค่า [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) เป็นช่วงประเภทที่ต้องการ สำหรับประเภทข้อความในลำดับปกติ การนับเริ่มจากประเภทแรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

ช่วง `3` จะทำให้แสดงทุกป้ายชื่อที่สาม โดยค้างป้ายชื่อสองอันระหว่างที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดช่องว่างอัตโนมัติโดยระบบจะเลือกช่วงตามพื้นที่ที่มีอยู่; ไม่จำเป็นต้องแสดงทุกป้ายชื่อ

เครื่องหมายบรรทัดมีการควบคุมแยกกัน ตั้งค่า [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) เป็น `False` และใช้ [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) เพื่อตั้งช่วงของมัน ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายบรรทัดทุกช่วงประเภทแม้ป้ายชื่อจะปรากฏเพียงทุกประเภทที่สาม ตั้งค่า [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) เป็นสไตล์ที่มองเห็นได้เพื่อให้เห็นผล การตั้งค่า either automatic‑spacing property กลับเป็น `True` จะให้แผนภูมิกำหนดช่วงนั้นใหม่อีกครั้ง

ตัวอย่างต่อไปนี้สร้าง 24 ประเภทและหนึ่งชุดข้อมูล จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างป้ายชื่อด้วยเครื่องหมายบรรทัดอิสระ, และการคืนค่าการจัดช่องว่างอัตโนมัติ ทั้งสองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม ไม่ต้องใช้งานนำเข้าก่อน หน้าแสดงป้ายชื่อแนวนอนทำให้ความหนาแน่นดูแตกต่างได้ง่าย

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

    # สไลด์ 2: แสดงทุกป้ายชื่อที่สาม แต่คงเครื่องหมายบรรทัดสำหรับทุกประเภท.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # สไลด์ 3: ให้แผนภูมเลือกช่วงทั้งสองอย่างใหม่.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการเรนเดอร์นี้ จะแสดงป้ายชื่อประเภททุกสองอันและบรรทัดตัดกันสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และเครื่องเรนเดอร์

![การจัดช่องว่างป้ายชื่อประเภทอัตโนมัติที่มีคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การจัดช่องว่างด้วยตนเอง (สไลด์ 2):** แสดงป้ายชื่อทุกสามอันในบรรทัดเดียว ขณะที่เครื่องหมายบรรทัดยังคงอยู่ทุกช่วงประเภท คอลัมน์ทั้งหมด 24 คอลัมน์รวมถึงคอลัมน์ที่ไม่มีป้ายชื่อยังคงมองเห็นได้ด้วยค่าเดียวกัน สไลด์ 3 คืนสภาพการแสดงผลอัตโนมัติที่แสดงข้างต้น

![การจัดช่องว่างป้ายชื่อประเภทเป็นสามที่มีคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนประเภทนี้กับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์จะเป็นแกนแนวนอน ส่วนในแผนภูมิแท่งแนวนอนแกนประเภทจะอยู่แนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับ [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) ระยะห่างของเครื่องหมายบรรทัดยังใช้ได้กับแกนชุดข้อมูลในแผนภูมิที่มีแกนชุดข้อมูล

อย่าจัดช่องว่างป้ายชื่อประเภทเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) ระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะทำให้มีเครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มที่ศูนย์ ส่วนช่วงป้ายชื่อประเภท `3` จะนับตำแหน่งประเภทโดยไม่สนใจค่าข้อมูล แผนภูมิกระจายและฟองอากาศใช้แกนค่ามากกว่าการใช้แกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยและสเกลเชิงเวลาตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างแทนที่ข้อมูลแผนภูมิค่าเริ่มต้นด้วยค่าปีสี่ค่า วันที่ถูกบันทึกเป็นหมายเลขอนุกรม OLE Automation ในแผ่นงานแรก (ดัชนี `0`) ตั้งค่า [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) เป็นแกนวันที่ ปิดการเชื่อมโยงรูปแบบตัวเลขกับแหล่งข้อมูลด้วย [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) แล้วกำหนด `yyyy` ให้กับ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) เพื่อให้ป้ายชื่อประเภทแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์

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

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**

เปิดใช้งาน [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) บนแกนแนวตั้ง, ใส่ข้อความชื่อ, และตั้งค่า [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) เพื่อหมุนชื่อ มุมวัดเป็นองศา ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่ชื่อแกนค่าถูกหมุน 90 องศา

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

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) เพื่อควบคุมว่าแกนค่าตัดกับแกนประเภทระหว่างประเภทหรือที่เครื่องหมายบรรทัดของประเภท คุณสมบัตินี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `True` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผล

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ตั้งค่า [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) เพื่อสเกลป้ายกำกับบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) ตั้งเป็น `MILLIONS` ค่าที่ 60,000,000 จะถูกแสดงเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใส่หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้ง

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดค่าแกนค่าลอการิทึม**

แกนค่าลอการิทึมเป็นประโยชน์เมื่อค่าบวกมีหลายระดับขนาดตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000, และ 100,000 รายการในห้าช่วงเวลา บนสเกลเชิงเส้น ค่าที่เล็กจะอยู่ใกล้ศูนย์กันมาก การสเกลลอการิทึมทำให้การเติบโตสัมพัทธ์ของพวกมันเปรียบเทียบนักง่ายขึ้น: ระยะห่างที่เท่ากันแทนอัตราส่วนที่เท่ากันแทนความต่างที่เท่ากัน

ตั้งค่า [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) เป็น `True` บนแกนค่าและใช้ [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) เพื่อเลือกฐาน การทำเช่นนี้จะเปลี่ยนวิธีที่ค่าที่มีอยู่แสดงผล; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นคุณลักษณะแยกต่างหาก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าคือ [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) สำหรับแผนภูมิแท่งแนวนอนคือ [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) แผนภูมิกระจายและฟองอากาศมีแกนค่าสองแกน ดังนั้นให้เลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งสอง ไม่ควรใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX ให้ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ด้วยฐาน `10` ค่ากำลังต่อเนื่องเช่น 10, 100, 1,000, 10,000 จะถูกจัดระยะห่างเท่ากัน

### **เปรียบเทียบสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าช่วงบนสไลด์แรก แล้วคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์รักษาข้อมูลเดียวกัน

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

    # คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะห่างแนวตั้งที่เท่ากันแสดงถึงความแตกต่างของจำนวนคำขอที่เท่ากัน ค่าที่ใหญ่ที่สุดครอบงำแผนภูมิ ทำให้ค่าที่เล็กดูยากต่อการแยกแยะ

![แผนภูมิเส้นใน PowerPoint ที่แสดงจำนวนคำขอห้าช่วงบนแกนค่เชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะห่างแนวตั้งที่เท่ากันแสดงถึงอัตราส่วนที่เท่ากัน แต่ละช่วงมีจำนวนคำขอเพิ่มขึ้นเท่ากับสิบเท่าจากช่วงก่อนหน้า ดังนั้นจุดจะสร้างเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน‑10 เลเบลแกนยังคงแสดงจำนวนคำขอเดิม

![จำนวนคำขอห้าช่วงเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน‑10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าลบ**

สเกลลอการิทึมสามารถแสดงค่าเชิงบวกอย่างเคร่งครัดเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าลบมีความหมาย ควรใช้สเกลเชิงเส้นหรือแยกแสดงออก ไม่ควรลบค่าดังกล่าวโดยไม่มีคำอธิบาย อย่าแทนที่ด้วยค่าบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าอย่างต่ำหรือสูงสุดที่ตั้งค่าด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะกำหนดค่าที่แกนหนึ่งตัดผ่านอีกแกนหนึ่งได้อย่างไร (การตัดแกน)?**

ใช้ [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) เพื่อเลือกพฤติกรรมการตัด หากต้องการระบุค่าตัดเชิงตัวเลข ให้ตั้งค่า [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) การตั้งค่าเหล่านี้ช่วยให้คุณย้ายการตัดแกนไปยังตำแหน่งฐานที่เหมาะสม

**ฉันจะจัดตำแหน่งป้ายกำกับเครื่องหมายบรรทัดสัมพันธ์กับแกนอย่างไร?**

ตั้งค่า [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO`, หรือ `NONE` เพื่อควบคุมตำแหน่งป้ายกำกับ เพื่อควบคุมเครื่องหมายบรรทัดเอง ใช้ [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) หรือ [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) ซึ่งแยกจากการจัดตำแหน่งป้ายกำกับ