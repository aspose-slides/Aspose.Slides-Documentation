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
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน .NET: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน, ใช้เซลล์ในสมุดงานเป็นป้ายข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของ worksheets, และกำหนดประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดสมุดงานภายนอก, ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอดสำหรับอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ:** ข้อมูลแผนภูมิต้องจัดระเบียบในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ

โค้ด Python ต่อไปนี้แสดงการดำเนินการตัวอย่าง:

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

### **ตรวจสอบเลเอาต์ของแผนภูมิหลังจากการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังอยู่ด้วยสมุดงานที่แก้ไขแล้ว, แผนภูมิจะคงซีรีส์และคอลเลกชันประเภทเดิม การไม่ตรงกันนี้อาจทำให้[IChart.validate_chart_layout](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/ichart/validate_chart_layout/) ล้มเหลวด้วยข้อผิดพลาด index‑out‑of‑range ให้ลบซีรีส์และประเภทที่มีอยู่ก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ

```python
# หลังจากแก้ไขสตรีมของสมุดงาน (เช่น ใช้ Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# ล้างการอ้างอิงข้อมูลที่มีอยู่.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

การล้างคอลเลกชันเหล่านี้ทำให้โครงสร้างข้อมูลแผนภูมิสอดคล้องกับสมุดงานใหม่, ทำให้ `validate_chart_layout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์ WorkBook เป็นป้ายข้อมูลแผนภูมิ**

บางครั้งคุณต้องการป้ายแผนภูมิที่มาจากเซลล์ในสมุดงานข้อมูลพื้นฐาน Aspose.Slides อนุญาตให้ผูกป้ายข้อมูลกับเซลล์สมุดงานเฉพาะเพื่อให้ข้อความป้ายแสดงค่าของเซลล์เสมอ ตัวอย่างด้านล่างแสดงวิธีเปิดใช้ป้ายที่ดึงค่าจากเซลล์และกำหนดป้ายที่เลือกให้กับเซลล์ที่กำหนดเองในสมุดงานของแผนภูมิ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิเบบเบิลพร้อมข้อมูลตัวอย่าง  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. ใช้เซลล์สมุดงานเป็นป้ายข้อมูล  
6. บันทึกงานนำเสนอ  

โค้ด Python ต่อไปนี้แสดงวิธีตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลแผนภูมิ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
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

## **จัดการ Worksheets**

โค้ด Python ต่อไปนี้แสดงวิธีใช้คุณสมบัติ `worksheets` เพื่อเข้าถึงคอลเลกชันของ worksheet:

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

## **กำหนดประเภทแหล่งข้อมูล**

โค้ด Python ต่อไปนี้แสดงวิธีกำหนดประเภทแหล่งข้อมูล:

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

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ `embedded_workbook_type` บน [ChartData](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

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

        # อ่านหรือแก้ไขข้อมูลสมุดงานของแผนภูมิที่นี่.
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **ตั้งค่าสมุดงานภายนอก**

โดยใช้เมธอด [ChartData.set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลเมธอดนี้ยังสามารถอัปเดตเส้นทางไปยังสมุดงานภายนอกได้หากถูกย้าย

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บบนตำแหน่งหรือทรัพยากรระยะไกลได้, คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากคุณระบุเส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Python ต่อไปนี้แสดงวิธีตั้งค่าสมุดงานภายนอก:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # ส่งค่า False เพื่อให้บันทึกเพียงเส้นทางเท่านั้น: สมุดงานเป้าหมายไม่จำเป็นต้องมีอยู่แล้ว.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

พารามิเตอร์ `update_chart_data` ของเมธอด [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ระบุว่าจะแสดงการโหลดสมุดงาน Excel หรือไม่

- เมื่อ `update_chart_data` ถูกตั้งค่าเป็น `False` จะอัปเดตเฉพาะเส้นทางสมุดงาน; ข้อมูลแผนภูมิจะไม่ถูกโหลดหรือรีเฟรชจากสมุดงานเป้าหมาย ใช้เมื่อตัวสมุดงานเป้าหมายไม่มีอยู่หรือไม่พร้อมใช้งาน  
- เมื่อ `update_chart_data` ถูกตั้งค่าเป็น `True` (ค่าเริ่มต้น) ข้อมูลแผนภูมิจะถูกโหลดและอัปเดตจากสมุดงานเป้าหมาย หากไม่สามารถเปิดสมุดงานนั้นได้ จะเกิดข้อยกเว้นพร้อมข้อความ "External workbook is not available"

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด [read_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือแปลงสมุดงานภายในให้เป็นสมุดงานภายนอกได้

โค้ด Python นี้แสดงกระบวนการสร้างสมุดงานภายนอก:

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

### **ดึงเส้นทางสมุดงานแหล่งข้อมูลภายนอกสำหรับแผนภูมิ**

บางครั้งข้อมูลของแผนภูมิอาจเชื่อมโยงกับสมุดงาน Excel ภายนอกแทนข้อมูลฝังในงานนำเสนอ ด้วย Aspose.Slides คุณสามารถตรวจสอบแหล่งข้อมูลของแผนภูมิและหากเป็นสมุดงานภายนอกก็อ่านเส้นทางเต็มของสมุดงานนั้นได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนีของมัน  
3. รับอ้างอิงรูปทรงแผนภูมิ  
4. รับแหล่งข้อมูล ([ChartDataSourceType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatasourcetype/)) ที่แสดงแหล่งข้อมูลของแผนภูมิ  
5. ตรวจสอบว่าประเภทแหล่งข้อมูลตรงกับประเภทสมุดงานภายนอกหรือไม่  

โค้ด Python ต่อไปนี้แสดงการดำเนินการ:

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลในสมุดงานภายใน หากสมุดงานภายนอกไม่สามารถโหลดได้ จะถูกโยนข้อยกเว้น

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่เก็บไว้ในแคชของงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/) แล้วเปิดใช้งาน [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/th/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) ผ่าน [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/spreadsheet_options/) ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้เปิดงานนำเสนอที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อยอมรับการใช้ข้อมูลแผนภูมิจากแคชเป็นวิธีสำรอง เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากที่งานนำเสนออัปเดตครั้งสุดท้าย

## **FAQ**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [path to an external workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) หากแหล่งเป็นสมุดงานภายนอกคุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ได้ หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ สิ่งนี้สะดวกสำหรับการพกพาโครงการ แต่ต้องทราบว่าการนำเสนอจะจัดเก็บเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้ สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

จะทำก็ต่อเมื่อคุณแก้ไขข้อมูลแผนภูมิ งานนำเสนอจะจัดเก็บ [link to the external file](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) และใช้ในการอ่านข้อมูล ดังนั้นการเปิดและบันทึกงานนำเสนอจะไม่กระทบต่อสมุดงาน อย่างไรก็ตาม ค่าที่คุณเปลี่ยนผ่านข้อมูลแผนภูมิ (ดูที่ **Edit Chart Data** ด้านบน) จะถูกเขียนกลับไปยังสมุดงานภายนอกเมื่อบันทึกงานนำเสนอ – ควรทำงานบนสำเนาหากต้องการให้ไฟล์ต้นฉบับคงสภาพเดิม

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน ฉันควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](/cells/python-net/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง ถ้าทั้งหมดชี้ไปที่ไฟล์เดียว การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อโหลดข้อมูลครั้งต่อไป