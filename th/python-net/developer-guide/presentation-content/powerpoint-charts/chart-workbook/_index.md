---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอด้วย Python
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/python-net/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน .NET: จัดการสมุดงานแผนภูมิใน PowerPoint และรูปแบบ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แสดงข้อมูลที่ขาดหายไป ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/) เพื่อเข้าใจความแตกต่างระหว่างเซลล์ว่างและค่าศูนย์ และเปรียบเทียบการแสดงผลของกราฟเส้นในโหมดที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนอยู่หรือไม่ ตั้งค่าเป็น `True` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อนอยู่ การตั้งค่านี้ควบคุมการพล็อตกราฟ; ไม่ได้ทำให้แถวหรือคอลัมน์ของแผ่นงานซ่อนหรือแสดง

ไฟล์นำเสนอ [sample presentation](hidden-source-data.pptx) มีกราฟคอลัมน์เป็นรูปร่างแรกบนสไลด์แรก แผ่นงานฝังอยู่ `Sheet1` มีช่วงแหล่งข้อมูลต่อไปนี้ `A1:C4` แถว 3 และคอลัมน์ C ถูกซ่อนไว้ แต่เซลล์ของพวกมันยังคงมีค่า

| แถวของแผ่นงาน | A: เดือน | B: รายละเอียดการขายปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) และอ่านค่า [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ นี่เป็นคุณสมบัติแบบอ่านอย่างเดียว ในไฟล์นี้ B2 เป็นเซลล์ที่มองเห็นได้ B3 อยู่ในแถวที่ซ่อน และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะพิมพ์ค่า `False`, `True` และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บสมุดงานฝังไว้โดยใช้ [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และโหลดใหม่ด้วย [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). เมื่อรวมทุกเซลล์ ให้ใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อคืนช่วงข้อมูลทั้งหมดรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนค่าธิสัญญาอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายหมวดที่แคชในตัวอย่างนี้

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

            # รีเฟรชข้อมูลแผนภูมิจากสมุดงานที่ฝังไว้.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # คืนช่วงแหล่งข้อมูลทั้งหมดรวมถึงหมวดที่ซ่อนอยู่.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

ตัวอย่างบันทึกเวอร์ชันของงานนำเสนอสองเวอร์ชัน: เวอร์ชันแรกมีเฉพาะค่าการขายปลีกที่มองเห็น (10 และ 20) และเวอร์ชันที่สองมีค่าทั้งหกค่า รูปภาพด้านล่างถูกเรนเดอร์จากงานนำเสนอที่บันทึกแล้วเมื่อเปิดใหม่; ทั้งสองไฟล์คงการตั้งค่าการพล็อตที่กำหนดไว้ แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานฝังทั้งสอง

| เฉพาะเซลล์ที่มองเห็น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าการขายปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าการขายปลีกและขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อนอยู่ ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/#control-the-display-of-empty-cells) เป็นตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนที่จะอัปเดตข้อมูลสมุดงานในงานนำเสนอที่มีอยู่แล้ว ให้ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่าแผนภูมิแต่ละอันใช้เซลล์แผ่นงานใด วิธีการ [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) จะคืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่ระบุแผ่นงาน เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อแผ่นงาน, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ตั้งแต่ A1 ถึง D5 รวม ทั้งสัญลักษณ์ `$` แสดงการอ้างอิงแบบคงที่ของแถวและคอลัมน์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่ทำการเปลี่ยนแปลงแผนภูมิหรือสมุดงานของมัน หากแผนภูมิไม่ได้ใช้สมุดงานเป็นแหล่งข้อมูล จะเกิดข้อยกเว้น สำหรับข้อมูลเพิ่มเติม ดูที่ [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อหาแผนภูมิ จะพิมพ์ชื่อและช่วงแหล่งข้อมูลของแต่ละแผนภูมิ หากไม่สามารถดึงช่วงได้ จะพิมพ์ข้อความวินิจฉัยและดำเนินการต่อไปยังแผนภูมิถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for Python via .NET มีเมธอด [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก โดยอ่านสมุดงานฝังไว้เป็นสตรีม, ล้างซีรีส์และหมวดหมู่ที่มีอยู่, แล้วเขียนสมุดงานเดิมกลับไป การเปลี่ยนแปลงจะคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ทำการบันทึกงานนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขสมุดงาน**

โดยใช้เมธอด [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) คุณสามารถตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขสมุดงานได้ การแทนที่สมุดงานฝังด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะคงการจัดเก็บซีรีส์และหมวดหมู่เดิม การไม่สอดคล้องกันนี้อาจทำให้เมธอดดังกล่าวล้มเหลวด้วยข้อผิดพลาด “index-out-of-range” ให้ล้างซีรีส์และหมวดหมู่เดิมก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คำอธิบายแสดงตำแหน่งที่ควรแก้ไขสมุดงาน; ตัวอย่างที่สามารถทำงานได้จะเขียนสมุดงานต้นฉบับกลับและตรวจสอบโครงสร้างในหน่วยความจำ

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # แก้ไขสตรีมของสมุดงานที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลเก่าก่อนที่สมุดงานจะถูกเขียนกลับ สร้างซีรีส์และการแมปหมวดหมู่ที่จำเป็นใหม่สำหรับสมุดงานที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลเริ่มต้นไปยังสไลด์แรกของงานนำเสนอที่มีอยู่ โดยใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายสามป้ายแรกในซีรีส์แรก เปิดใช้งานป้ายจากเซลล์ และบันทึกงานนำเสนอที่อัปเดต

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

คุณสมบัติ [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) ให้การเข้าถึงแผ่นงานในสมุดงานของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิโดนที่พร้อมข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละแผ่นงานออกทางคอนโซล

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติพร้อมข้อมูลเริ่มต้นและตั้งชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้การระบุสตริงโดยตรง; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 การนับประเภท [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) เลือกแหล่งข้อมูลสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) บน [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) ร่วมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่ฝังสมุดงาน .xlsb

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

        # อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่รองรับที่นี่.
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) เพื่อส่งออกสมุดงานแผนภูมิฝังเป็นไฟล์และเชื่อมโยงแผนภูมิกับสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิโดนที่พร้อมข้อมูลเริ่มต้นและส่งออกสมุดงานของมัน ปิดสตรีมผลลัพธ์ก่อนกำหนดสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์ถูกย้าย) ด้วย

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บในตำแหน่งหรือทรัพยากรระยะไกลได้ แต่ยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอก หากระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้สมุดงานภายนอกที่แผ่นงานชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิโดนที่, เชื่อมโยงสมุดงาน, และใช้ [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อแมป A1:B4 ไปยังหนึ่งซีรีส์และสามหมวด แล้วบันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `update_chart_data` ของ [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ควบคุมว่าจะโหลดสมุดงานหรือไม่

* เมื่อ `update_chart_data` เป็น `False` จะอัปเดตเฉพาะเส้นทางของสมุดงานเท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่สามารถใช้งานได้
* เมื่อ `update_chart_data` เป็น `True` ข้อมูลแผนภูมิจะถูกอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปนี้กำหนด URL ตัวแทนโดยตั้งค่า `update_chart_data` เป็น `False` จะคงข้อมูลเริ่มต้นของแผนภูมิโดนที่และบันทึกงานนำเสนอโดยไม่โหลดสมุดงานที่ไม่พร้อมใช้งาน

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **รับเส้นทางสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุสมุดงานที่เชื่อมโยงกับแผนภูมิ ให้ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางสมุดงานของมัน

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีสมุดงานภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมโยงกับสมุดงานภายนอก ตัวอย่างจะพิมพ์ [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ไปยังคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาของสมุดงานภายใน หากสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมโยงกับสมุดงานภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อ้างอิงจากเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าของเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นให้ใช้สำเนาหากต้องการเก็บสมุดงานต้นฉบับไว้

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานของแผนภูมิใหม่จากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), ตั้งค่า [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) ของมันและกำหนด [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) เป็น `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้กู้คืนข้อมูลสมุดงานสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งาน โดยเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
    else:
        print("The first shape is not a chart.")
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะเกิดข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากที่งานนำเสนออัปเดตครั้งสุดท้าย

## **FAQ**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝัง?**  
ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); หากแหล่งข้อมูลเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับการใช้เส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่ และเก็บไว้ในรูปแบบใด?**  
ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางแบบเต็มโดยอัตโนมัติ งานนำเสนอจะจัดเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นเมื่ยกสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่อยู่บนแหล่งข้อมูลหรือแชร์ในเครือข่ายได้หรือไม่?**  
ใช่ สามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**  
งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) การแก้ไขข้อมูลแผนภูมิที่อ้างอิงจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยงได้ ใช้สำเนของสมุดงานหากต้องการให้ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

**ฉันควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  
ใช่ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อโหลดข้อมูลครั้งต่อไป