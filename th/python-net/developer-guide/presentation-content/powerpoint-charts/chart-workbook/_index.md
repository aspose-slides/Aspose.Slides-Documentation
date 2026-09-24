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
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน .NET: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน, ใช้เซลล์ของสมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อมีสมุดงานพร้อมใช้งาน

สำหรับเซลล์ของสมุดงานที่แสดงข้อมูลที่หายไป ให้ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-net/chart-series/) เพื่อทำความเข้าใจความแตกต่างระหว่างเซลล์ว่างและค่าเป็นศูนย์, รวมถึงการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอดสำหรับอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งประกอบด้วยข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ:** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

โค้ด Python ด้านล่างเป็นตัวอย่างการดำเนินการ:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **ตรวจสอบเค้าโครงแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังอยู่ด้วยสมุดงานที่แก้ไขแล้ว, แผนภูมิจะยังคงรักษาคอลเลกชันซีรีส์และประเภทของหมวดหมู่เดิมไว้ ความไม่ตรงกันนี้อาจทำให้ [IChart.validate_chart_layout](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichart/validate_chart_layout/) ล้มเหลวด้วยข้อผิดพลาด out‑of‑range ให้ล้างซีรีส์และประเภทที่มีอยู่ก่อนเขียนสมุดงานที่อัปเดตกลับเข้าไปในแผนภูมิ

```python
# หลังจากแก้ไขสตรีมสมุดงาน (เช่น ใช้ Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# ลบการอ้างอิงข้อมูลที่มีอยู่.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

การล้างคอลเลกชันทำให้โครงสร้างข้อมูลแผนภูมิสอดคล้องกับสมุดงานใหม่, ทำให้ `validate_chart_layout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **กำหนดเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

บางครั้งคุณต้องการป้ายกำกับแผนภูมิที่มาจากเซลล์โดยตรงในสมุดงานข้อมูลพื้นฐาน Aspose.Slides อนุญาตให้คุณผูกป้ายกำกับกับเซลล์สมุดงานเฉพาะเพื่อให้ข้อความป้ายกำกับสะท้อนค่าของเซลล์เสมอ ตัวอย่างด้านล่างแสดงวิธีเปิดใช้งานป้ายกำกับจากค่าเซลล์และชี้ป้ายกำกับที่เลือกไปยังเซลล์กำหนดเองในสมุดงานของแผนภูมิ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ด้วยดัชนี  
3. เพิ่มแผนภูมิบับเบิ้ลพร้อมข้อมูลตัวอย่าง  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูล  
6. บันทึกการนำเสนอ

โค้ด Python ด้านล่างแสดงวิธีกำหนดเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการแผ่นงาน**

โค้ด Python ด้านล่างแสดงวิธีใช้คุณสมบัติ `worksheets` เพื่อเข้าถึงคอลเลกชันแผ่นงาน:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **ระบุประเภทแหล่งข้อมูล**

โค้ด Python ด้านล่างแสดงวิธีระบุประเภทแหล่งข้อมูล:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในแผนภูมิบางประเภท คุณสามารถใช้คุณสมบัติ `embedded_workbook_type` บน [ChartData](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ๆ

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # สมุดงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue

        # อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่นี่.
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด [ChartData.set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้เมธอดนี้ยังสามารถอัปเดตเส้นทางของสมุดงานภายนอกหากมีการย้ายตำแหน่ง

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บบนตำแหน่งหรือตัวแหล่งทรัพยากรระยะไกลได้, แต่คุณยังคงใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากคุณระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Python ด้านล่างแสดงวิธีกำหนดสมุดงานภายนอก:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # ส่งค่า False เพื่อให้บันทึกเฉพาะเส้นทาง: สมุดงานเป้าหมายไม่จำเป็นต้องมีอยู่แล้ว.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

พารามิเตอร์ `update_chart_data` ของเมธอด [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ระบุว่าจะโหลดสมุดงาน Excel หรือไม่

- เมื่อ `update_chart_data` ตั้งเป็น `False` จะอัปเดตเฉพาะเส้นทางของสมุดงาน; ข้อมูลแผนภูมิจะไม่ถูกโหลดหรือรีเฟรชจากสมุดงานเป้าหมาย ใช้เมื่อสมุดงานเป้าหมายไม่มีหรือไม่สามารถเข้าถึงได้  
- เมื่อ `update_chart_data` ตั้งเป็น `True` (ค่าเริ่มต้น) ข้อมูลแผนภูมิจะถูกโหลดและอัปเดตจากสมุดงานเป้าหมาย หากไม่สามารถเปิดสมุดงานนั้น จะเกิดข้อยกเว้นพร้อมข้อความ “External workbook is not available”

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด [read_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือแปลงสมุดงานภายในให้เป็นสมุดงานภายนอกได้

โค้ด Python นี้สาธิตกระบวนการสร้างสมุดงานภายนอก:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **ดึงเส้นทางของสมุดงานแหล่งข้อมูลภายนอกสำหรับแผนภูมิ**

บางครั้งข้อมูลของแผนภูมิเชื่อมโยงกับสมุดงาน Excel ภายนอกแทนที่จะเป็นข้อมูลฝังในพรีเซนเทชั่น ด้วย Aspose.Slides คุณสามารถตรวจสอบแหล่งข้อมูลของแผนภูมิและหากเป็นสมุดงานภายนอกก็สามารถอ่านเส้นทางเต็มของสมุดงานได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)  
2. ดึงอ้างอิงสไลด์ด้วยดัชนีของมัน  
3. ดึงอ้างอิงรูปทรงแผนภูมิ  
4. รับแหล่งข้อมูล ([ChartDataSourceType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatasourcetype/)) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ  
5. ตรวจสอบว่าประเภทแหล่งข้อมูลตรงกับประเภทสมุดงานภายนอกหรือไม่

โค้ด Python ด้านล่างสาธิตการดำเนินการ:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลในสมุดงานภายใน หากสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้, Aspose.Slides สามารถสร้างสมุดงานของแผนภูมิใหม่จากข้อมูลที่แคชไว้ในพรีเซนเทชั่นได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/), จากนั้นเปิดใช้งาน [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/th/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) ผ่าน [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/spreadsheet_options/) ก่อนเปิดพรีเซนเทชั่น

ตัวอย่าง Python ด้านล่างเปิดพรีเซนเทชั่นที่แผนภูมิเชื่อมโยงกับสมุดงานภายนอกที่ไม่สามารถใช้ได้และเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อต้องการ fallback ด้วยข้อมูลแคชของแผนภูมิเท่านั้น เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากพรีเซนเทชั่นอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝังอยู่?**

ได้. แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [เส้นทางไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่และเก็บอย่างไร?**

รองรับ. หากคุณระบุเส้นทางสัมพันธ์ ระบบจะทำการแปลงเป็นเส้นทาง абсолютโดยอัตโนมัติ สิ่งนี้ช่วยให้โครงการพกพาได้ง่าย; อย่างไรก็ตาม พรีเซนเทชั่นจะเก็บเส้นทาง абсолют ในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้, สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ แต่การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชั่นหรือไม่?**

จะเขียนทับเฉพาะเมื่อคุณแก้ไขข้อมูลแผนภูมิ พรีเซนเทชั่นเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) และใช้ลิงก์นั้นในการอ่านข้อมูล ดังนั้นการเปิดและบันทึกพรีเซนเทชั่นจะไม่ส่งผลกับสมุดงาน อย่างไรก็ตาม ค่าที่คุณเปลี่ยนผ่านข้อมูลแผนภูมิ (ดูที่ [แก้ไขข้อมูลแผนภูมิ](#edit-chart-data) ข้างต้น) จะถูกเขียนกลับไปยังสมุดงานภายนอกเมื่อบันทึกพรีเซนเทชั่น – ควรทำงานกับสำเนาหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รองรับการใส่รหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/python-net/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะแสดงผลในแต่ละแผนภูมิเมื่อนำเข้าข้อมูลครั้งต่อไป