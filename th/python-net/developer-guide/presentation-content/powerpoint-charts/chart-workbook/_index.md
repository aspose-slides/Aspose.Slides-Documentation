---
title: จัดการเวิร์กบุ๊กชาร์ตในงานนำเสนอด้วย Python
linktitle: เวิร์กบุ๊กชาร์ต
type: docs
weight: 70
url: /th/python-net/chart-workbook/
keywords:
- เวิร์กบุ๊กชาร์ต
- ข้อมูลชาร์ต
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- ชีตงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชชาร์ต
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน .NET: จัดการเวิร์กบุ๊กชาร์ตในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับชาร์ตเวิร์กบุ๊กใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลชาร์ตผ่านสตรีมเวิร์กบุ๊ก ใช้เซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลของชาร์ต เข้าถึงคอลเลกชันของชีตงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าชาร์ต

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต ตัวอย่างจะแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับชาร์ต และแก้ไขข้อมูลชาร์ตเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่แสดงค่าที่หายไป ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/) เพื่อเปรียบเทียบระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนไว้**

ใช้ [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) เพื่อควบคุมว่าชาร์ตจะวาดข้อมูลจากแถวและคอลัมน์ที่ซ่อนไว้หรือไม่ ตั้งเป็น `True` เพื่อวาดเฉพาะเซลล์ที่มองเห็นได้ หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อนอยู่ การตั้งค่านี้ควบคุมการวาดชาร์ตเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ในชีตงาน

[sample presentation](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปแบบแรกบนสไลด์แรกของไฟล์ ชีตงานที่ถูกฝัง `Sheet1` มีช่วงข้อมูลต้นฉบับ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อนไว้ แต่เซลล์ของพวกมันยังคงมีค่าอยู่

| แถว Worksheet | A: เดือน | B: ค้าปลีก | C: ขายส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นฉบับผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) และอ่านค่า [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ คุณสมบัตินี้เป็นแบบอ่าน‑อย่างเท่านั้น ในไฟล์นี้ B2 มองเห็นได้ B3 อยู่ในแถวที่ซ่อน และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดงผล `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลชาร์ตหลังจากเปลี่ยนการตั้งค่าแบบวาด: เก็บเวิร์กบุ๊กที่ฝังไว้ด้วย [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) แล้วโหลดใหม่ด้วย [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) เมื่อรวมทุกเซลล์ให้ใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อคืนช่วงเต็มรวมถึงประเภทเดือน February ที่ซ่อนอยู่ การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแคชของชาร์ตและป้ายประเภทในตัวอย่างนี้

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # รีเฟรชข้อมูลชาร์ตจากเวิร์กบุ๊กที่ฝังไว้.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # คืนค่าช่วงข้อมูลต้นฉบับทั้งหมดรวมถึงประเภทที่ซ่อนอยู่.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: เวอร์ชันแรกมีเฉพาะค่าค้าปลีกที่มองเห็นได้ (10 และ 20) อีกเวอร์ชันมีค่าทั้งหกค่า รูปภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกแล้วและเปิดใหม่; ทั้งสองไฟล์คงการตั้งค่าการวาดไว้ตามเดิม แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในเวิร์กบุ๊กที่ฝังทั้งสอง

| เซลล์ที่มองเห็นเท่านั้น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![เซลล์ที่มองเห็นเท่านั้น: ค่าค้าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าค้าปลีกและขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลต้นฉบับที่ซ่อนอยู่ ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **ดึงช่วงข้อมูลของชาร์ต**

ก่อนที่จะอัปเดตข้อมูลเวิร์กบุ๊กในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงข้อมูลต้นฉบับเพื่อระบุว่าแต่ละชาร์ตใช้เซลล์ชีตงานใด [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) คืนค่าช่วงข้อมูลปัจจุบันในรูปสูตรที่อ้างอิงชีตงาน เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` เป็นชื่อชีต, `!` แยกจากช่วงเซลล์, `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองสัญลักษณ์ `$` แสดงการอ้างอิงแบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงชาร์ตหรือเวิร์กบุ๊ก หากชาร์ตไม่ได้ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูลจะเกิดข้อยกเว้น ดูรายละเอียดเพิ่มเติมใน [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปบนแต่ละสไลด์เพื่อค้นหาแชาร์ต พิมพ์ชื่อและช่วงข้อมูลของแต่ละชาร์ต หากไม่สามารถดึงช่วงได้ จะพิมพ์ข้อความวินิจฉัยและดำเนินการต่อไปยังชาร์ตถัดไป

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **อ่านและเขียนข้อมูลชาร์ตจากเวิร์กบุ๊ก**

Aspose.Slides for Python via .NET มีเมธอด [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลชาร์ต (เวิร์กบุ๊กที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลชาร์ตต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้งานนำเสนอที่มีชาร์ตเป็นรูปแบบแรกบนสไลด์แรก อ่านเวิร์กบุ๊กที่ฝังไว้เป็นสตรีม ลบซีรีส์และประเภทเดิมทั้งหมด แล้วเขียนเวิร์กบุ๊กเดียวกันกลับไป การเปลี่ยนแปลงจะคงอยู่ในหน่วยความจำ ตัวอย่างไม่ได้บันทึกงานนำเสนอ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **ตรวจสอบเค้าโครงชาร์ตหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อตัวเวิร์กบุ๊กที่ฝังไว้ถูกแทนที่ด้วยเวิร์กบุ๊กที่แก้ไขแล้ว ชาร์ตจะยังคงคอลเลกชันซีรีส์และประเภทเดิม การไม่ตรงกันนี้อาจทำให้ [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) ล้มเหลวด้วยข้อผิดพลาด index‑out‑of‑range ให้ลบซีรีส์และประเภทเดิมก่อนเขียนเวิร์กบุ๊กอัปเดตกลับไปที่ชาร์ต ตัวอย่างนี้ใช้ชาร์ตที่เป็นรูปแบบแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่การแก้ไขเวิร์กบุ๊กจะเกิดขึ้น; ตัวอย่างที่ทำงานได้เขียนเวิร์กบุ๊กต้นฉบับกลับและตรวจสอบเค้าโครงในหน่วยความจำ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # แก้ไขสตรีมเวิร์กบุ๊กที่นี่, ตัวอย่างเช่นโดยใช้ Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

การลบคอลเลกชันจะทำให้การอ้างอิงข้อมูลที่ล้าสมัยหายไปก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ สร้างซีรีส์และการแม็พประเภทใหม่ตามเวิร์กบุ๊กที่อัปเดตก่อนใช้ชาร์ต

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์เวิร์กบุ๊ค**

ใช้ [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) เพื่อควบคุมรูปแบบการแสดงค่าตัวเลขในเวิร์กบุ๊กที่ฝังอยู่ของชาร์ต ตัวอย่างเช่น รายงานอาจต้องแสดงอัตราแปลงเป็นเปอร์เซ็นต์ 4 ตำแหน่งทศนิยมและค่าสัมประสิทธิ์ 5 ตำแหน่งทศนิยม ให้ค่าเหล่านี้ยังคงเป็นตัวเลขเพื่อให้สามารถคำนวณและวาดชาร์ตต่อไปได้

รูปแบบตัวเลขเปลี่ยนการแสดงผลไม่ใช่ค่าที่เก็บไว้ `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%` แต่ไม่ได้แทนที่ค่าที่เก็บเป็น `12.5` เช่นเดียวกัน `0.00000` จะทำให้ `0.1234567` แสดงเป็น `0.12346` โดยไม่ปัดเศษค่าที่เก็บไว้ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้ [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) บนชีต 0 เซลล์ B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าชาร์ต ตัวอย่างยังเปิดใช้งานป้ายค่าที่เชื่อมโยงกับรูปแบบต้นฉบับ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

รูปแบบของเซลล์เวิร์กบุ๊กแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายจะแสดงค่าจากเซลล์ต้นทางเพราะ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) ถูกเปิดและตามรูปแบบตัวเลขของเซลล์ต้นทางเพราะ [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) เป็น `True` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามด้านล่าง แกนแนวตั้งใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) ของตัวเอง `0.00` โดยที่ [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) ตั้งเป็น `False`

หากต้องการฟอร์แมตป้ายข้อมูลอย่างอิสระ ให้ตั้งค่าสถานะเชื่อมโยงกับแหล่งเป็น `False` แล้วกำหนด [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) ของป้ายเอง ซึ่งจะไม่เปลี่ยนรูปแบบของเซลล์เวิร์กบุ๊ก ตัวอย่างเช่น ฟอร์แมตป้ายอิสระ `0.00` จะทำให้ค่าตัวแรกแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) เพื่อเรียนรู้การฟอร์แมตป้ายโดยตรง

รูปภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกแล้วและเปิดใหม่:

![แผนภูมิคอลัมน์พร้อมป้ายที่เชื่อมโยงกับแหล่งแสดง 12.5000% และ 0.12346 พร้อมแกนจำนวนที่ฟอร์แมตอิสระ.](custom-cell-formats.png)

## **กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลของชาร์ต**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ็คเป็นป้ายข้อมูลของชาร์ตได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลค่าเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนชีต 0 สำหรับป้ายสามอันแรกของซีรีส์แรก เปิดใช้ป้ายจากเซลล์ แล้วบันทึกงานนำเสนอที่อัปเดต

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการชีตงาน**

คุณสมบัติ [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) ให้เข้าถึงชีตงานในเวิร์กบุ๊กของชาร์ต ตัวอย่างนี้สร้างแผนภูมิโดนัทที่มีข้อมูลค่าเริ่มต้นและพิมพ์ชื่อชีตแต่ละอันลงคอนโซล

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **ระบุประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลค่าเริ่มต้นและตั้งชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้สตริงลิตัล; ชื่อที่สองใช้เซลล์ C1 บนชีต 0 ค่ำ enumerations [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) จะเลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางชาร์ต คุณสามารถใช้คุณสมบัติ [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) บน [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) ร่วมกับ enumerations [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามชาร์ตเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่ชาร์ต และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละชาร์ตที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กชาร์ตที่รองรับที่นี่.
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) เพื่อส่งออกเวิร์กบุ๊กชาร์ตที่ฝังเป็นไฟล์และเชื่อมชาร์ตกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิโดนัทที่มีข้อมูลค่าเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน ปิดสตรีมออกก่อนกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของชาร์ต แล้วบันทึกงานนำเสนอที่เชื่อมโยง

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **ตั้งค่าเวิร์กบุ๊กภายนอก**

ด้วยเมธอด [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้เป็นแหล่งข้อมูลของชาร์ตได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยังเวิร์กบุ๊กภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่เก็บไว้ในตำแหน่งระยะไกลหรือทรัพยากรได้ แต่ยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอก หากระบุเส้นทางเชิงสัมพัทธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่ชีตชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อประเภทใน A2:A4 และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิโดนัท, เชื่อมเวิร์กบุ๊ก, และใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อแม็พ A1:B4 เป็นซีรีส์หนึ่งและสามประเภท แล้วบันทึกงานนำเสนอที่เชื่อมชาร์ต

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

พารามิเตอร์ `update_chart_data` ของ [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ควบคุมว่าเวิร์กบุ๊กจะถูกโหลดหรือไม่

* เมื่อ `update_chart_data` เป็น `False` จะอัปเดตเฉพาะเส้นทางเวิร์กบุ๊ก ชาร์ตจะไม่โหลดหรืออัปเดตข้อมูลจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่พร้อมใช้งาน
* เมื่อ `update_chart_data` เป็น `True` ชาร์ตจะอัปเดตข้อมูลจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวอย่างโดยตั้ง `update_chart_data` เป็น `False` งานนำเสนอยังคงใช้ข้อมูลค่าเริ่มต้นของแผนภูมิโดนัทและบันทึกโดยไม่โหลดเวิร์กบุ๊กที่ไม่พร้อมใช้งาน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **รับเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกของชาร์ต**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมกับชาร์ต ให้ตรวจสอบว่าชาร์ตใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางเวิร์กบุ๊กของมัน

ตัวอย่างนี้ตรวจสอบรูปแรกบนสไลด์แรกของงานนำเสนอที่เชื่อมเวิร์กบุ๊กภายนอก หากเป็นชาร์ตที่เชื่อมเวิร์กบุ๊กภายนอก ตัวอย่างจะพิมพ์ [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ลงคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **แก้ไขข้อมูลชาร์ต**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงในเวิร์กบุ๊กภายใน หากเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะมีการโยนข้อยกเว้น

ตัวอย่างนี้ใช้ชาร์ตที่เป็นรูปแรกบนสไลด์แรกและเชื่อมกับเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อยู่ในเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าจากเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อม จึงควรใช้สำเนาหากต้องการรักษาเวิร์กบุ๊กต้นฉบับ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **กู้คืนเวิร์กบุ๊กจากแคชของชาร์ต**

หากชาร์ตใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊กชาร์ตใหม่จากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) ตั้งค่า [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) และเปิดใช้งาน [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) เป็น `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้กู้คืนข้อมูลเวิร์กบุ๊กสำหรับชาร์ตที่เป็นรูปแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่พร้อมใช้งาน ตัวอย่างเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนที่นี่.
    else:
        print("The first shape is not a chart.")
```

หากเวิร์กบุ๊กภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนก็ต่อเมื่อการใช้ข้อมูลแคชของชาร์ตเป็นทางเลือกที่รับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับเวิร์กบุ๊กภายนอกหลังจากการอัปเดตงานนำเสนอครั้งล่าสุด

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าชาร์ตเฉพาะเจาะจงเชื่อมกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝัง?**

ใช่ ชาร์ตมี [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) หากแหล่งเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีไฟล์ภายนอกถูกใช้

**รองรับเส้นทางเชิงสัมพัทธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่ และจัดเก็บอย่างไร?**

รองรับ หากระบุเส้นทางเชิงสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มอัตโนมัติ งานนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**

ได้ เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) การแก้ไขค่าชาร์ตที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องที่เชื่อมต่อ ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อตั้งลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายชาร์ตสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละชาร์ตเก็บลิงก์ของตัวเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกชาร์ตเมื่อโหลดข้อมูลครั้งต่อไป