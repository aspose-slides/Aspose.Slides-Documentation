---
title: จัดการ Workbook ของแผนภูมิในการนำเสนอด้วย Python
linktitle: Workbook ของแผนภูมิ
type: docs
weight: 70
url: /th/python-net/chart-workbook/
keywords:
- workbook ของแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์ workbook
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- workbook ภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืน workbook
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน .NET: จัดการ chart workbook ในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ chart workbook ใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของ workbook, ใช้เซลล์ของ workbook เป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของ worksheet, และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความนี้ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนด workbook ภายนอก, ดึงเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook มีอยู่

สำหรับเซลล์ของ workbook ที่แทนค่าข้อมูลที่หายไป ให้ดูที่ [Control the Display of Empty Cells](/slides/th/python-net/chart-series/) เพื่อเปรียบเทียบระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแบบเส้นกราฟของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ถูกซ่อน**

ใช้ [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) เพื่อควบคุมว่าระดับแผนภูมิจะพล็อตข้อมูลจากแถวและคอลัมน์ของ worksheet ที่ซ่อนอยู่หรือไม่ ตั้งค่าเป็น `True` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อนอยู่ การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของ worksheet

[ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปทรงแรกบนสไลด์แรกของไฟล์นั้น Worksheet ที่ฝังมาร่วม `Sheet1` มีช่วงแหล่งข้อมูล `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อนอยู่ แต่เซลล์ของพวกมันยังคงมีค่า

| แถวของ Worksheet | A: เดือน | B: รายละเอียดขายปลีก | C: รายละเอียดขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (แถวที่ซ่อน) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) และอ่านค่า [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ คุณสมบัตินี้เป็นแบบอ่านเท่านั้น ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะพิมพ์ `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บ workbook ที่ฝังไว้ด้วย [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และโหลดใหม่ด้วย [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) เมื่อรวมทุกเซลล์ ให้ใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อคืนช่วงเต็มรวมถึงหมวด “February” ที่ซ่อนอยู่ การเปลี่ยนแฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายกำกับหมวดที่แคชไว้ในตัวอย่างนี้

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

            # รีเฟรชข้อมูลแผนภูมิจาก workbook ที่ฝังอยู่.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # คืนช่วงแหล่งข้อมูลเต็มรวมถึงหมวดที่ซ่อนอยู่.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: หนึ่งเวอร์ชันที่มีเฉพาะค่าปลีกที่มองเห็นได้ (10 และ 20) และอีกเวอร์ชันที่มีค่าทั้งหกค่า ภาพด้านล่างถูกเรนเดอร์จากไฟล์การนำเสนอที่บันทึกแล้วและเปิดใหม่; ทั้งสองไฟล์เก็บการตั้งค่าการพล็อตที่กำหนดไว้ แถวที่ 3 และคอลัมน์ C ยังอยู่ในสถานะซ่อนในทั้งสอง workbook ที่ฝังอยู่

| เฉพาะเซลล์ที่มองเห็น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลต้นทางที่ซ่อนอยู่ ดูที่ [Control the Display of Empty Cells](/slides/th/python-net/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนที่จะอัปเดตข้อมูล workbook ในการนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่า worksheet ใดที่แผนภูมิเชื่อมโยงอยู่ วิธี [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) จะคืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่ระบุ worksheet, เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อ worksheet, `!` คั่นกับช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ตั้งแต่ A1 ถึง D5 รวมถึงสัญลักษณ์ `$` ที่บ่งบอกการอ้างอิงแบบ absolute

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือ workbook หากแผนภูมิไม่ได้ใช้ workbook เป็นแหล่งข้อมูล จะเกิดข้อยกเว้น สำหรับข้อมูลเพิ่มเติมดูที่ [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดไฟล์การนำเสนอและตรวจสอบรูปทรงบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อและช่วงต้นทางของแต่ละแผนภูมิ หากไม่สามารถดึงช่วงได้ จะพิมพ์ข้อความวินิจฉัยและดำเนินการต่อไปยังแผนภูมิถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides for Python via .NET ให้เมธอด [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ที่ช่วยให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งอาจถูกแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าโครงสร้างข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับต้นทาง

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก อ่าน workbook ที่ฝังไว้เป็นสตรีม, ลบ series และ categories เดิม, แล้วเขียน workbook เดิมกลับเข้าไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างนี้ไม่ได้บันทึกการนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังด้วย workbook ที่แก้ไขแล้ว แผนภูมิจะยังคงรักษา series และ collection ของหมวดหมู่เดิมไว้ ความไม่ตรงนี้อาจทำให้ [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ลบ series และ categories เก่าก่อนเขียน workbook ที่อัปเดตกลับเข้าแผนภูมิ ตัวอย่างใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์บ่งบอกตำแหน่งที่ควรแก้ไข workbook; ตัวอย่างที่ทำงานได้เขียน workbook ดั้งเดิมกลับเข้าไปและตรวจสอบโครงสร้างในหน่วยความจำ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # แก้ไขสตรีม workbook ที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

การลบ collection จะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนที่ workbook จะถูกเขียนกลับมา สร้าง series และ mapping ของหมวดหมู่ใหม่ตามความต้องการของ workbook ที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าฟอร์แมตตัวเลขแบบกำหนดเองสำหรับเซลล์ของ Workbook**

ใช้ [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) เพื่อควบคุมวิธีแสดงค่าตัวเลขใน workbook ที่ฝังอยู่ของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราแปลงเป็นเปอร์เซ็นต์ที่มีทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ที่มีทศนิยมห้าตำแหน่ง เก็บค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและพล็อตแผนภูมิได้

ฟอร์แมตตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่เก็บไว้ ฟอร์แมต `0.0000%` จะทำให้แสดง `0.125` เป็น `12.5000%` แต่ค่าที่เก็บยังคงเป็น `0.125` เช่นเดียวกัน `0.00000` จะทำให้แสดง `0.1234567` เป็น `0.12346` โดยไม่ได้ปัดค่าเก็บไว้ หากฟอร์แมตกำหนดเป็นสตริงว่าง (`""`) จะใช้ [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) บน worksheet 0 เซลล์ B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์ให้ค่ากับแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายกำกับค่าที่เชื่อมต่อกับฟอร์แมตต้นทาง

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

ฟอร์แมตของเซลล์ workbook แยกจากฟอร์แมตที่ตั้งโดยตรงบนแกนหรือป้ายกำกับข้อมูล ในตัวอย่างนี้แต่ละป้ายกำกับจะแสดงค่าจากเซลล์ต้นทางเพราะ [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) ถูกเปิดและ [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) เป็น `True` หลังจากบันทึกและเปิดการนำเสนอใหม่ ป้ายกำกับจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้ [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) ของตัวเองเป็น `0.00` กับ [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) ตั้งเป็น `False`

หากต้องการฟอร์แมตป้ายกำกับโดยอิสระ ให้ตั้งค่าเชื่อมโยงกับต้นทางเป็น `False` และกำหนด [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) ของป้ายกำกับนั้น ฟอร์แมตนี้จะไม่ส่งผลต่อฟอร์แมตของเซลล์ใน workbook ตัวอย่างเช่น ฟอร์แมตอิสระ `0.00` จะทำให้ค่าตัวแรกแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) เพื่อดูการฟอร์แมตป้ายกำกับโดยตรง

ภาพด้านล่างได้มาจากการเรนเดอร์การนำเสนอที่บันทึกแล้วและเปิดใหม่:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ตั้งค่าเซลล์ Workbook เป็นป้ายกำกับข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ของ workbook เป็นป้ายกำกับข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลเริ่มต้นบนสไลด์แรกของการนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บน worksheet 0 เป็นป้ายกำกับสามค่าตัวแรกของ series แรก เปิดใช้งานป้ายกำกับจากเซลล์และบันทึกการนำเสนอที่อัปเดต

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

## **จัดการ Worksheets**

คุณสมบัติ [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) ให้เข้าถึง worksheets ใน chart workbook ตัวอย่างนี้สร้างแผนภูมิโดนัทที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อของแต่ละ worksheet ไปยังคอนโซล

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

## **ระบุประเภทของแหล่งข้อมูล**

ค่าจุดของ series สามารถจัดเก็บเป็นค่าตัวเลขโดยตรง ดูที่ [Set Series Values Using Numeric Literals](/slides/th/python-net/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างครบถ้วนที่บันทึกและอ่านค่าเหล่านั้น ประเภทของแหล่งข้อมูลของค่าจุดแยกจากการกำหนดค่า workbook ภายในหรือภายนอกของแผนภูมิ; การใช้ค่าตัวเลขโดยตรงไม่ได้ทำให้ workbook ที่ฝังอยู่หายไปโดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลเริ่มต้นและตั้งชื่อ series สองชื่อโดยใช้แหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้สตริงลิเทอร์ัล; ชื่อที่สองใช้เซลล์ C1 บน worksheet 0 ค่าคงที่ [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) กำหนดแหล่งข้อมูลสำหรับแต่ละชื่อ ตัวอย่างบันทึกการนำเสนอพร้อมชื่อ series ที่อัปเดต

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

## **ตรวจจับรูปแบบ Workbook ที่ฝังและไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ workbook ของ Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) บน [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเช่นนั้น ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของการนำเสนอที่มีอยู่ ข้ามรูปทรงที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มี workbook .xlsb ฝังอยู่

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

        # อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่รองรับที่นี่.
```

## **Workbook ภายนอก**

Aspose.Slides รองรับการใช้ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้าง Workbook ภายนอก**

ใช้ [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) เพื่อส่งออก workbook ของแผนภูมิที่ฝังอยู่เป็นไฟล์และลิงก์แผนภูมิกับ workbook ภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิโดนัทที่มีข้อมูลเริ่มต้นและส่งออก workbook ของมัน ปิดสตรีมผลลัพธ์ก่อนกำหนด workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกการนำเสนอที่ลิงก์แล้ว

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

### **กำหนด Workbook ภายนอก**

โดยใช้เมธอด [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลใน workbook ที่จัดเก็บบนตำแหน่งที่อยู่ระยะไกลหรือทรัพยากรอื่นได้ แต่คุณยังคงสามารถใช้ workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอก หากให้เส้นทางสัมพัทธ์แก่ workbook ภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้ workbook ภายนอกที่ worksheet ชื่อ `Sheet1` มีชื่อ series อยู่ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิโดนัท, ลิงก์ workbook, และใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อแมป A1:B4 เป็น series หนึ่งและสามหมวด แล้วบันทึกการนำเสนอที่มีแผนภูมิลิงก์

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

พารามิเตอร์ `update_chart_data` ของเมธอด [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ควบคุมว่าจะแสดงข้อมูล workbook หรือไม่

* เมื่อ `update_chart_data` เป็น `False` จะอัปเดตเฉพาะเส้นทางของ workbook เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook ปลายทาง ดังนั้น workbook สามารถไม่มีอยู่ได้
* เมื่อ `update_chart_data` เป็น `True` ข้อมูลแผนภูมิจะอัปเดตจาก workbook ปลายทาง

ตัวอย่างต่อไปกำหนด URL ตัวอย่างเป็น placeholder พร้อม `update_chart_data` ตั้งเป็น `False` การนำเสนอจะคงข้อมูลเริ่มต้นของแผนภูมิโดนัทและบันทึกโดยไม่โหลด workbook ที่ไม่มีอยู่

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **ดึงเส้นทาง Workbook ของแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุ workbook ที่ลิงก์กับแผนภูมิ ให้ตรวจสอบว่าแผนภูมิมีแหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางของ workbook นั้น

ตัวอย่างนี้ตรวจสอบรูปทรงแรกบนสไลด์แรกของการนำเสนอที่มี workbook ภายนอกที่ลิงก์ หากเป็นแผนภูมิลิงก์กับ workbook ภายนอก ตัวอย่างจะพิมพ์ [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ไปยังคอนโซล แล้วบันทึกสำเนาของการนำเสนอ

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

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกเช่นเดียวกับที่ทำการเปลี่ยนแปลงใน workbook ภายใน หากไม่สามารถโหลด workbook ภายนอก จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและลิงก์กับ workbook ภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่มาจากเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 แล้วบันทึกการนำเสนอที่อัปเดต การแก้ไขค่าที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่ลิงก์ไว้ ดังนั้นหากต้องการรักษาไฟล์ต้นฉบับไว้ ควรใช้สำเนา

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

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิใช้ workbook ภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างใหม่จากข้อมูลที่แคชไว้ในไฟล์การนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), กำหนดค่า [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), แล้วตั้งค่า [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) เป็น `True` ก่อนเปิดการนำเสนอ

ตัวอย่าง Python ที่ต่อไปนี้กู้คืนข้อมูล workbook สำหรับแผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและอ้างอิง workbook ภายนอกที่ไม่สามารถเข้าถึงได้ ตัวอย่างเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
    else:
        print("The first shape is not a chart.")
```

หาก workbook ภายนอกไม่สามารถเข้าถึงได้และการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยงข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อต้องการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกสำรอง เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับ workbook ภายนอกหลังจากการอัปเดตครั้งล่าสุดของการนำเสนอ

## **FAQ**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิใดเชื่อมต่อกับ workbook ภายนอกหรือที่ฝังอยู่?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) หากเป็น workbook ภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีไฟล์ภายนอกถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยัง workbook ภายนอกหรือไม่ และเก็บไว้ในรูปแบบใด?**

ได้ หากกำหนดเส้นทางเป็นสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ การนำเก็บเส้นทางเต็มไว้ในไฟล์ PPTX ดังนั้นการย้าย workbook อาจต้องอัปเดตลิงก์

**ฉันสามารถใช้ workbook ที่อยู่บนเครือข่าย/แชร์ได้หรือไม่?**

ได้ workbook เหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเข้าหรือไม่?**

การนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) การแก้ไขค่าที่มาจากเซลล์ของแผนภูมิอาจอัปเดตไฟล์ XLSX ภายในเครื่องที่ลิงก์ไว้ ใช้สำเนาของ workbook หากต้องการให้ไฟล์ต้นฉบับคงอยู่โดยไม่มีการเปลี่ยนแปลง

**ถ้าไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน ควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมจะเก็บลิงก์ของตนเอง หากทั้งหมดลิงก์ไปยังไฟล์เดียว การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิครั้งต่อไปที่โหลดข้อมูล**