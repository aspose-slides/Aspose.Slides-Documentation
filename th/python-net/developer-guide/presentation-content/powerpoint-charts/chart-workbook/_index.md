---
title: จัดการหนังสือเวิร์กชีตของแผนภูมิในงานนำเสนอด้วย Python
linktitle: หนังสือเวิร์กชีตแผนภูมิ
type: docs
weight: 70
url: /th/python-net/chart-workbook/
keywords:
- หนังสือเวิร์กชีตของแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์หนังสือเวิร์กชีต
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- หนังสือเวิร์กชีตภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืนหนังสือเวิร์กชีต
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides for Python via .NET: จัดการหนังสือเวิร์กชีตของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับหนังสือเวิร์กชีตของแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของหนังสือเวิร์กชีต, ใช้เซลล์ของหนังสือเวิร์กชีตเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับหนังสือเวิร์กชีตภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดหนังสือเวิร์กชีตภายนอก, ดึงเส้นทางของหนังสือเวิร์กชีตภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อหนังสือเวิร์กชีตพร้อมใช้งาน

สำหรับเซลล์ของหนังสือเวิร์กชีตที่เป็นตัวแทนของข้อมูลที่หายไป ให้ดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/) เพื่อความแตกต่างระหว่างเซลล์ว่างและศูนย์, และการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนไว้หรือไม่ ตั้งเป็น `True` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้, หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อนอยู่ การตั้งค่านี้ควบคุมการพล็อตของกราฟ; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปทรงแรกในสไลด์แรกของมัน แผ่นงานฝังตัว `Sheet1` มีช่วงข้อมูลต้นแบบต่อไปนี้ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อนอยู่ แต่เซลล์ของมันยังคงมีค่าอยู่

| แถวของแผ่นงาน | A: เดือน | B: ค้าปลีก | C: ค้าส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) และอ่าน [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์นั้น คุณสมบัตินี้เป็นแบบอ่าน‑อย่างเดียว ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดงผล `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนค่าการพล็อต: คงหนังสือเวิร์กชีตฝังไว้ด้วย [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และโหลดใหม่ด้วย [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). เมื่อรวมทุกเซลล์ให้ใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อคืนช่วงที่สมบูรณ์รวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนค่าเพียงอย่างเดียวไม่เพียงพอที่จะรีเฟรชแคชข้อมูลและป้ายกำกับของตัวอย่างนี้

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

            # รีเฟรชข้อมูลแผนภูมิจากหนังสือเวิร์กชีตที่ฝังอยู่.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # คืนช่วงแหล่งข้อมูลเต็มรูปแบบ, รวมถึงหมวดหมู่ที่ซ่อนอยู่.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: เวอร์ชันหนึ่งมีค่า Retail ที่มองเห็นได้เท่านั้น (10 และ 20), อีกเวอร์ชันมีค่าทั้งหกค่า ภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกแล้วหลังเปิดใหม่; ทั้งสองไฟล์รักษาการตั้งค่าการพล็อตที่กำหนดไว้ แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในหนังสือเวิร์กชีตฝังทั้งสอง

| เฉพาะเซลล์ที่มองเห็น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าค้าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าค้าปลีกและค้าส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนอยู่และมีค่าแตกต่างจากเซลล์ว่าง [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือแยกข้อมูลต้นทางที่ซ่อนอยู่ ดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลหนังสือเวิร์กชีตในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่าแผ่นงานใดบ้างที่แผนภูมิใช้เมธอด [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) จะคืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่ระบุแผ่นงาน เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อแผ่นงาน, `!` คั่นกับช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมถึงเครื่องหมาย `$` ที่บ่งบอกการอ้างอิงแบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือหนังสือเวิร์กชีต หากแผนภูมิไม่ได้ใช้หนังสือเวิร์กชีตเป็นแหล่งข้อมูล จะเกิดข้อยกเว้น สำหรับข้อมูลเพิ่มเติม ดู [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปทรงโดยตรงบนแต่ละสไลด์เพื่อค้นหาแผนภูมิ จะแสดงชื่อแผนภูมิและช่วงต้นทาง หากไม่สามารถดึงช่วงได้ จะพิมพ์ข้อความวินิจฉัยและดำเนินการต่อไปยังแผนภูมถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจากหนังสือเวิร์กชีต**

Aspose.Slides for Python via .NET ให้เมธอด [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ที่ช่วยให้คุณอ่านและเขียนหนังสือเวิร์กชีตของข้อมูลแผนภูมิ (ซึ่งอาจถูกแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก อ่านหนังสือเวิร์กชีตฝังเป็นสตรีม, ล้างซีรีส์และหมวดหมู่ที่มีอยู่, แล้วเขียนหนังสือเวิร์กชีตเดิมกลับเข้าไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างจะไม่บันทึกงานนำเสนอ

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

### **ตรวจสอบโครงร่างแผนภูมิหลังการแก้ไขหนังสือเวิร์กชีต**

เมื่อคุณแทนที่หนังสือเวิร์กชีตฝังด้วยเวิร์กชีตที่แก้ไขแล้ว, แผนภูมิจะยังคงมีซีรีส์และคอลเลกชันหมวดหมู่เดิม ความไม่ตรงกันนี้อาจทำให้ [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) ล้มเหลวด้วยข้อผิดพลาด index‑out‑of‑range ให้ล้างซีรีส์และหมวดหมู่เดิมก่อนเขียนเวิร์กชีตที่อัปเดตกลับเข้าไปในแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรก ส่วนคอมเมนต์ระบุจุดที่ควรแก้ไขเวิร์กชีต; ตัวอย่างทำงานจะเขียนเวิร์กชีตเดิมกลับและตรวจสอบโครงร่างในหน่วยความจำ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # แก้ไขสตรีมของหนังสือเวิร์กชีตที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลเก่าก่อนที่เวิร์กชีตจะถูกเขียนกลับ สร้างซีรีส์และการแมปหมวดหมู่ใหม่ตามความจำเป็นสำหรับเวิร์กชีตที่อัปเดตก่อนใช้แผนภูมิ

## **เลือกวิธีการจัดเก็บป้ายกำกับประเภท**

กำหนดค่า [ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) ในขณะที่คอลเลกชันประเภทว่างอยู่ ตั้งค่าเป็น `True` สำหรับป้ายกำกับที่อ้างอิงเซลล์ของแผ่นงานหรือสร้างโครงสร้างชั้นตอน เช่น ไตรมาสที่จัดกลุ่มตามปี ตั้งค่าเป็น `False` สำหรับระดับเดียวของป้ายกำกับที่ให้เป็นสตริง การตั้งค่านี้ใช้กับประเภทเท่านั้น ทั้งสองแผนภูมิในตัวอย่างใช้เซลล์ของแผ่นงานเป็นค่าตัวเลขของซีรีส์

ตัวอย่างสร้างแผนภูมิคอลัมน์สองแบบและพิมพ์โหมดการจัดเก็บพร้อมป้ายกำกับ `Q1 Q2 Q3 Q4` สำหรับแต่ละแผนภูมิ สำหรับป้ายกำกับที่อ้างอิงเซลล์, [ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) จะคืนเซลล์ของแผ่นงาน, และ [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) จะคืนค่าป้ายกำกับที่เก็บไว้ ในกรณีป้ายกำกับเชิงอักขระ ให้อ่านสตริงโดยตรงจาก [ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/)

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่ารูปแบบตัวเลขที่กำหนดเองสำหรับเซลล์ของหนังสือเวิร์กชีต**

ใช้ [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) เพื่อควบคุมรูปแบบการแสดงค่าตัวเลขในหนังสือเวิร์กชีตฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการอัตราการแปลงที่แสดงเป็นเปอร์เซ็นต์พร้อมทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ที่แสดงด้วยทศนิยมห้าตำแหน่ง ค่าทั้งสองควรเก็บเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและพล็อตแผนภูมิได้

รูปแบบตัวเลขจะเปลี่ยนการแสดงผลเท่านั้น ไม่ได้เปลี่ยนค่าที่เก็บไว้ รูปแบบ `0.0000%` จะแสดง `0.125` เป็น `12.5000%`; มันไม่แทนที่จำนวนที่เก็บเป็น `12.5` เช่นเดียวกัน `0.00000` จะแสดง `0.1234567` เป็น `0.12346` โดยไม่ปัดเศษค่าที่เก็บ หากรูปแบบที่กำหนดเป็นสตริงว่าง (`""`) จะใช้ [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ของมันผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). ในแผ่นงาน 0, B2 มีอัตราการแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าที่ใช้ในแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายค่าเชื่อมโยงกับรูปแบบต้นทาง

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

รูปแบบของเซลล์หนังสือเวิร์กชีตแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายจะแสดงค่าจากเซลล์ต้นทางเนื่องจาก [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) ถูกเปิด, และสืบทอดรูปแบบตัวเลขจากแหล่งที่มาเพราะ [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) เป็น `True` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) ของตัวเองเป็น `0.00` พร้อมกับ [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) ตั้งเป็น `False`

หากต้องการจัดรูปแบบป้ายข้อมูลอย่างอิสระ ให้ตั้งค่าธงเชื่อมโยงแหล่งเป็น `False` แล้วกำหนด [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) ของป้ายเอง สิ่งนี้จะไม่เปลี่ยนรูปแบบของเซลล์หนังสือเวิร์กชีต ตัวอย่าง ป้ายรูปแบบอิสระ `0.00` จะแสดงค่าตัวแรกเป็น `0.13` ขณะที่ B2 ยังคงแสดง `12.5000%` ดู [Chart Data Labels](/slides/th/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการจัดรูปแบบป้ายโดยตรง

![แผนภูมิคอลัมน์ที่มีป้ายกำกับเชื่อมโยงกับแหล่งแสดง 12.5000% และ 0.12346 และแกนตัวเลขที่จัดรูปแบบแยกจากกัน.](custom-cell-formats.png)

## **ตั้งค่าเซลล์ของหนังสือเวิร์กชีตเป็นป้ายกำกับข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ของหนังสือเวิร์กชีตเป็นป้ายกำกับข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิกระจายฟองพร้อมข้อมูลเริ่มต้นในสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 สำหรับสามป้ายแรกของซีรีส์แรก, เปิดใช้ป้ายจากเซลล์, แล้วบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการแผ่นงาน**

คุณสมบัติ [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) ให้ความสามารถในการเข้าถึงแผ่นงานในหนังสือเวิร์กชีตของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิวงกลมพร้อมข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละแผ่นงานไปยังคอนโซล

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

ค่าจุดของซีรีส์สามารถเก็บเป็นค่าตัวเลขโดยตรงได้ ดู [Set Series Values Using Numeric Literals](/slides/th/python-net/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างครบถ้วนที่บันทึกและอ่านค่าเหล่านั้น ประเภทแหล่งข้อมูลของค่าจุดแยกจากการกำหนดค่าเวิร์กชีตภายในหรือภายนอกของแผนภูมิ; การใช้ค่าตัวเลขโดยตรงไม่ได้ทำให้หนังสือเวิร์กชีตฝังหายไปโดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติพร้อมข้อมูลเริ่มต้นและตั้งชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงแบบลiteral; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 ค่าตัวแปร [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) จะเลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบหนังสือเวิร์กชีตฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบหนังสือเวิร์กชีตไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) บน [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) ร่วมกับการนับ [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของงานนำเสนอที่มีอยู่, ข้ามรูปทรงที่ไม่ใช่แผนภูมิ, แล้วพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีหนังสือเวิร์กชีต .xlsb ฝังอยู่

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

        # อ่านหรือแก้ไขข้อมูลหนังสือเวิร์กชีตของแผนภูมิที่รองรับที่นี่.
```

## **หนังสือเวิร์กชีตภายนอก**

Aspose.Slides รองรับการใช้หนังสือเวิร์กชีตภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างหนังสือเวิร์กชีตภายนอก**

ใช้ [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) เพื่อส่งออกหนังสือเวิร์กชีตของแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิกับหนังสือเวิร์กชีตภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวงกลมพร้อมข้อมูลเริ่มต้นและส่งออกหนังสือเวิร์กชีตของมัน ปิดสตรีมผลลัพธ์ก่อนกำหนดหนังสือเวิร์กชีตภายนอกเป็นแหล่งข้อมูลของแผนภูมิ, แล้วบันทึกงานนำเสนอที่เชื่อมต่อแล้ว

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

### **ตั้งค่าหนังสือเวิร์กชีตภายนอก**

โดยใช้เมธอด [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนดหนังสือเวิร์กชีตภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยังหนังสือเวิร์กชีตภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในหนังสือเวิร์กชีตที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้, คุณยังสามารถใช้หนังสือเวิร์กชีตเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้เส้นทางสัมพันธ์สำหรับหนังสือเวิร์กชีตภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มอัตโนมัติ

ตัวอย่างนี้ใช้หนังสือเวิร์กชีตภายนอกที่แผ่นงานชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิวงกลม, เชื่อมต่อหนังสือเวิร์กชีต, และใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อแมป A1:B4 ไปยังซีรีส์หนึ่งและสามหมวด แล้วบันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อมต่อ

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

พารามิเตอร์ `update_chart_data` ของ [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ควบคุมว่าจะโหลดหนังสือเวิร์กชีตหรือไม่

* เมื่อ `update_chart_data` เป็น `False` จะอัปเดตเฉพาะเส้นทางของหนังสือเวิร์กชีต เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากหนังสือเวิร์กชีตเป้าหมาย, ดังนั้นหนังสือเวิร์กชีตอาจไม่มีอยู่
* เมื่อ `update_chart_data` เป็น `True` ข้อมูลแผนภูมิจะอัปเดตจากหนังสือเวิร์กชีตเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม `update_chart_data` เป็น `False` จะคงข้อมูลเริ่มต้นของแผนภูมิวงกลมและบันทึกงานนำเสนอโดยไม่โหลดหนังสือเวิร์กชีตที่ไม่มีอยู่

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **รับเส้นทางของหนังสือเวิร์กชีตแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุหนังสือเวิร์กชีตที่เชื่อมต่อกับแผนภูมิ, ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางหนังสือเวิร์กชีตของมัน

ตัวอย่างนี้ตรวจสอบรูปทรงแรกบนสไลด์แรกของงานนำเสนอที่เชื่อมต่อกับหนังสือเวิร์กชีตภายนอก หากเป็นแผนภูมิที่เชื่อมต่อกับหนังสือเวิร์กชีตภายนอก ตัวอย่างจะพิมพ์ [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ไปยังคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในหนังสือเวิร์กชีตภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในหนังสือเวิร์กชีตภายใน หากหนังสือเวิร์กชีตภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและเชื่อมต่อกับหนังสือเวิร์กชีตภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อ้างอิงเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 แล้วบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าของเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมต่อได้, ดังนั้นควรใช้สำเนา หากต้องการรักษาหนังสือเวิร์กชีตต้นฉบับไว้

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

### **กู้คืนหนังสือเวิร์กชีตจากแคชของแผนภูมิ**

หากแผนภูมิใช้หนังสือเวิร์กชีตภายนอกที่หายไปหรือไม่พร้อมใช้งาน, Aspose.Slides สามารถสร้างหนังสือเวิร์กชีตของแผนภูมิจากข้อมูลที่แคชในงานนำเสนอได้ ให้สร้าง [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), ตั้งค่า [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), และกำหนด [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) เป็น `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ด้านล่างกู้คืนข้อมูลหนังสือเวิร์กชีตสำหรับแผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและอ้างอิงหนังสือเวิร์กชีตภายนอกที่ไม่มีอยู่ ตัวอย่างเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # อ่านหรือแก้ไขข้อมูลหนังสือเวิร์กชีตที่กู้คืนที่นี่.
    else:
        print("The first shape is not a chart.")
```

หากหนังสือเวิร์กชีตภายนอกไม่มีอยู่และการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในหนังสือเวิร์กชีตภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**สามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับหนังสือเวิร์กชีตภายนอกหรือฝังอยู่?**

ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [เส้นทางไปยังหนังสือเวิร์กชีตภายนอก](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) หากแหล่งเป็นหนังสือเวิร์กชีตภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีไฟล์ภายนอกถูกใช้

**รองรับการใช้เส้นทางสัมพันธ์กับหนังสือเวิร์กชีตภายนอกหรือไม่, และเก็บอย่างไร?**

รองรับ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายหนังสือเวิร์กชีตอาจต้องอัปเดตลิงก์

**สามารถใช้หนังสือเวิร์กชีตที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

สามารถใช้หนังสือเวิร์กชีตเหล่านี้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขหนังสือเวิร์กชีตระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอจะเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) การแก้ไขค่าที่อ้างอิงเซลล์ในแผนภูมิสามารถอัปเดตไฟล์ XLSX ภายในเครื่องที่เชื่อมโยงได้ ให้ใช้สำเนาของหนังสือเวิร์กชีตหากต้องการให้ไฟล์ต้นฉบับคงที่

**ควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงหนังสือเวิร์กชีตภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิครั้งต่อไปที่โหลดข้อมูล