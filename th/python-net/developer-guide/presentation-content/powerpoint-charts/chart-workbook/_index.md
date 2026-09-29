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
- ป้ายกำกับข้อมูล
- ชีตทำงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python via .NET: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน, ใช้เซลล์ของสมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของชีตทำงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ  

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน  

สำหรับเซลล์ในสมุดงานที่แสดงข้อมูลหายไป ให้ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างกับศูนย์, และเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้เลือก  

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ของชีตทำงานที่ซ่อนหรือไม่ ตั้งค่าเป็น `True` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็น, หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตกราฟ; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของชีตทำงาน  

ดาวน์โหลด [hidden-source-data.pptx](hidden-source-data.pptx) และวางไว้ในไดเรกทอรีทำงาน สไลด์แรกของไฟล์มีแผนภูมิคอลัมน์เป็นรูปแบบแรก ชีตทำงานที่ฝังอยู่, `Sheet1`, มีช่วงแหล่งข้อมูลดังต่อไปนี้, `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ของพวกมันยังคงมีค่าอยู่  

| แถวชีตทำงาน | A: เดือน | B: จำหน่ายปลีก | C: จำหน่ายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [ChartData.chart_data_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) และอ่าน [ChartDataCell.is_hidden](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatacell/is_hidden/) เพื่อสอบถามสถานะการซ่อนของเซลล์ คุณสมบัตินี้เป็นแบบอ่านอย่างเดียว ในไฟล์นี้, B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดง `False`, `True`, และ `True` ตามลำดับ  

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บสมุดงานที่ฝังไว้ด้วย [read_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และโหลดใหม่ด้วย [write_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). เมื่อรวมเซลล์ทั้งหมด ให้ใช้ [set_range](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อคืนช่วงครบถ้วนรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าสถานะเพียงอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแคชของแผนภูมิและป้ายหมวดในตัวอย่างนี้  

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

            # รีเฟรชข้อมูลแผนภูมิจากสมุดงานที่ฝังอยู่.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # คืนช่วงแหล่งข้อมูลเต็มรวมถึงหมวดที่ซ่อนอยู่.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

ตัวอย่างบันทึก `hidden_cells_True.pptx` โดยมีค่า Retail ที่มองเห็นเท่านั้น (10 และ 20), และ `hidden_cells_False.pptx` โดยมีค่าทั้งหกค่า รูปภาพด้านล่างถูกเรนเดอร์จากไฟล์นำเสนอที่บันทึกแล้วและเปิดใหม่; ทั้งสองไฟล์รักษาการตั้งค่าการพล็อตที่กำหนดไว้ไว้ แถวที่ 3 และคอลัมน์ C ยังคงซ่อนในสมุดงานที่ฝังทั้งสอง  

| เฉพาะเซลล์ที่มองเห็น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่า Retail 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่า Retail และ Wholesale สำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ที่ว่างเปล่า [Chart.display_blanks_as](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/display_blanks_as/) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดูตัวอย่างได้ที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/#control-the-display-of-empty-cells).  

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for Python via .NET มีเมธอด [read_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [write_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล  

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปแบบแรกบนสไลด์แรกของไฟล์ อ่านสมุดงานที่ฝังไว้เป็นสตรีม, ลบชุดข้อมูลและหมวดหมู่เดิม, แล้วเขียนสมุดงานเดียวกันกลับไป การเปลี่ยนแปลงจะคงอยู่ในหน่วยความจำ; ตัวอย่างนี้ไม่ได้บันทึกการนำเสนอ  

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

### **ตรวจสอบรูปแบบแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังด้วยสมุดงานที่แก้ไขแล้ว, แผนภูมิจะยังคงชุดข้อมูลและคอลเลกชันหมวดหมู่เดิม การไม่ตรงกันนี้อาจทำให้ [Chart.validate_chart_layout](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/validate_chart_layout/) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ลบชุดข้อมูลและหมวดหมู่เดิมก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ต้องการ `chart.pptx` ที่มีแผนภูมิเป็นรูปแบบแรกบนสไลด์แรกของไฟล์ คอมเมนต์ระบุส่วนที่สมุดงานจะถูกแก้ไข; ตัวอย่างที่สามารถเรียกใช้ได้จะเขียนสมุดงานต้นฉบับกลับและตรวจสอบรูปแบบในหน่วยความจำ  

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # แก้ไขสตรีมสมุดงานที่นี่, ตัวอย่างเช่นโดยใช้ Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

การลบคอลเลกชันจะล้างการอ้างอิงข้อมูลที่ล้าสมัยก่อนสมุดงานจะถูกเขียนกลับ สร้างชุดข้อมูลและการแมพหมวดหมู่ที่จำเป็นสำหรับสมุดงานที่อัปเดตก่อนใช้แผนภูมิ  

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายกำกับข้อมูล แขั้นตอนต่อไปนี้แสดงวิธีเชื่อมป้ายกำกับในแผนภูมิกระจ่างกับเซลล์ในสมุดงานข้อมูลของมัน  

1. สร้างอินสแตนซ์ของคลาสต​ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์  
3. เพิ่มแผนภูมิกระจ่างด้วยข้อมูลค่าเริ่มต้น  
4. เข้าถึงชุดข้อมูลของแผนภูมิ  
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล  
6. บันทึกการนำเสนอ  

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์, แล้วเพิ่มแผนภูมิกระจ่างด้วยข้อมูลค่าเริ่มต้น ใช้เซลล์ A10:A12 บนชีตทำงาน 0 สำหรับป้ายกำกับสามอันแรกในชุดข้อมูลแรก, เปิดใช้ป้ายกำกับจากเซลล์, และบันทึกผลลัพธ์เป็น `resultchart.pptx`  

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

## **จัดการชีตทำงาน**

คุณสมบัติ [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) ให้การเข้าถึงชีตทำงานในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิกรูทวงกลมด้วยข้อมูลค่าเริ่มต้นและพิมพ์ชื่อแต่ละชีตทำงานไปที่คอนโซล  

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลค่าเริ่มต้นและตั้งชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิเทอรัล; ชื่อที่สองใช้เซลล์ C1 บนชีตทำงาน 0. การนับจำนวนใน enumeration [DataSourceType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/datasourcetype/) จะเลือกแหล่งสำหรับแต่ละชื่อ ผลลัพธ์ถูกบันทึกเป็น `pres.pptx`  

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excelแบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [embedded_workbook_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) บน [ChartData](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของ `sample.pptx`, ข้ามรูปทรงที่ไม่ใช่แผนภูมิ, และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่  

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

ใช้ [read_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) เพื่อส่งออกสมุดงานแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิกับสมุดงานภายนอกนั้น  

ตัวอย่างนี้สร้างแผนภูมิกรูทวงกลมด้วยข้อมูลค่าเริ่มต้น, เขียนสมุดงานของมันเป็น `externalWorkbook1.xlsx`, และปิดสตรีมผลลัพธ์ก่อนกำหนดไฟล์เป็นแหล่งข้อมูลแผนภูมิ มันบันทึกการนำเสนอที่เชื่อมต่อเป็น `externalWorkbook.pptx`  

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

### **ตั้งค่าสมุดงานภายนอก**

โดยใช้เมธอด [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์นั้นถูกย้าย)  

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บในตำแหน่งหรือทรัพยากรระยะไกล, คุณยังคงสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ  

ตัวอย่างนี้ต้องการไฟล์ `externalWorkbook.xlsx` ในไดเรกทอรีทำงาน ชีตทำงานที่ชื่อ `Sheet1` ต้องมีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิกรูทวงกลม, เชื่อมสมุดงาน, และใช้ [set_range](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_range/) เพื่อแมพ A1:B4 เป็นหนึ่งชุดข้อมูลและสามหมวด มันบันทึกผลลัพธ์เป็น `Presentation_with_externalWorkbook.pptx`  

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

พารามิเตอร์ `update_chart_data` ของ [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ควบคุมว่าจะแสดงผลการโหลดสมุดงานหรือไม่  

- เมื่อ `update_chart_data` เป็น `False` จะอัปเดตเฉพาะเส้นทางของสมุดงานเท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย, ดังนั้นสมุดงานอาจไม่พร้อมใช้งาน.  
- เมื่อ `update_chart_data` เป็น `True` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย.  

ตัวอย่างต่อไปกำหนด URL ตำแหน่งเก็บชั่วคราวโดยตั้งค่า `update_chart_data` เป็น `False` มันรักษาข้อมูลค่าเริ่มต้นของแผนภูมิกรูทวงกลมและบันทึกการนำเสนอโดยไม่โหลดสมุดงานที่ไม่มี  

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

เพื่อระบุสมุดงานที่เชื่อมกับแผนภูมิ, ขั้นแรกตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่ หากใช่, คุณสามารถดึงเส้นทางสมุดงานได้โดยทำตามขั้นตอนต่อไปนี้  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์  
3. ตรวจสอบว่ารูปแบบแรกเป็นแผนภูมิ  
4. อ่านประเภทแหล่งข้อมูลของแผนภูมิ  
5. หากแหล่งเป็นสมุดงานภายนอก, ดึงเส้นทางของมัน  

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างในตัวอย่างก่อนหน้า, แล้วตรวจสอบรูปแบบแรกบนสไลด์แรก หากเป็นแผนภูมิที่เชื่อมกับสมุดงานภายนอก, ตัวอย่างจะแสดง [external_workbook_path](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) ที่คอนโซล จากนั้นบันทึกสำเนาการนำเสนอเป็น `Result.pptx`  

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้, จะเกิดข้อยกเว้น  

ตัวอย่างนี้ต้องการไฟล์ `presentation.pptx` ที่มีแผนภูมิเป็นรูปแบบแรกบนสไลด์แรกและสมุดงานภายนอกที่เข้าถึงได้ มันตั้งค่าค่าที่อ้างอิงจากเซลล์ของจุดข้อมูลแรกในชุดแรกเป็น 100 และบันทึกการนำเสนอเป็น `presentation_out.pptx` การแก้ไขค่าของเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมต่อ, ดังนั้นควรใช้สำเนาหากต้องการเก็บสมุดงานต้นฉบับ  

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

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน, Aspose.Slides สามารถสร้างสมุดงานแผนภูมิใหม่จากข้อมูลที่แคชในไฟล์นำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/), กำหนดค่า [spreadsheet_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/spreadsheet_options/), และตั้งค่า [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/th/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) เป็น `True` ก่อนเปิดไฟล์นำเสนอ  

ตัวอย่าง Python ต่อไปนี้เปิด `presentation.pptx` ซึ่งรูปแบบแรกบนสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งาน, และเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):  

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

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะขว้างข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากการอัปเดตการนำเสนอล่าสุด  

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่?**  
ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [path to an external workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/); หากแหล่งเป็นสมุดงานภายนอก, คุณสามารถอ่านเส้นทางเต็มได้เพื่อให้แน่ใจว่าไฟล์ภายนอกถูกใช้.  

**เส้นทางสัมพันธ์ไปยังสมุดงานภายนอกรองรับหรือไม่, และมันถูกเก็บอย่างไร?**  
ได้. หากคุณระบุเส้นทางสัมพันธ์, ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ การนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์.  

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**  
ได้, สมุดงานประเภทนั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน - สามารถใช้เป็นแหล่งข้อมูลเท่านั้น.  

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**  
การนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/). การแก้ไขข้อมูลแผนภูมิที่อ้างอิงจากเซลล์สามารถอัปเดตไฟล์ XLSX ภายในเครื่องที่เชื่อมโยงได้ ใช้สำเนาของสมุดงานหากต้องการคงไฟล์ต้นฉบับไม่เปลี่ยนแปลง.  

**ฉันควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น โดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) แล้วเชื่อมโยงไปยังสำเนานั้น.  

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  
ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อข้อมูลถูกโหลดครั้งถัดไป.