---
title: จัดการแผ่นงานแผนภูมิในการนำเสนอด้วย Python
linktitle: แผ่นงานแผนภูมิ
type: docs
weight: 70
url: /th/python-net/chart-workbook/
keywords:
- แผ่นงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์แผ่นงาน
- ป้ายข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- แผ่นงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนแผ่นงาน
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน .NET: จัดการแผ่นงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ Chart Workbook ใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของ Workbook ใช้เซลล์ของ Workbook เป็นป้ายข้อมูลแผนภูมิ เข้าถึงคอลเลกชัน Worksheet และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับ Workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนด Workbook ภายนอก ดึงเส้นทางของ Workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อ Workbook พร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides มีเมธอดสำหรับอ่านและเขียน Chart Data Workbook (ซึ่งประกอบด้วยข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ:** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูลต้นฉบับ

โค้ด Python ตัวอย่างต่อไปนี้แสดงการทำงานตัวอย่าง:

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

## **กำหนดเซลล์ Workbook เป็นป้ายข้อมูลแผนภูมิ**

บางครั้งคุณต้องการป้ายแผนภูมิที่มาจากเซลล์โดยตรงใน Workbook ของข้อมูลพื้นฐาน Aspose.Slides อนุญาตให้ผูกป้ายข้อมูลกับเซลล์ของ Workbook เฉพาะเพื่อให้ข้อความป้ายสอดคล้องกับค่าของเซลล์ ตัวอย่างด้านล่างแสดงวิธีเปิดใช้งานป้ายที่รับค่าจากเซลล์และชี้ป้ายที่เลือกไปยังเซลล์ที่กำหนดใน Workbook ของแผนภูมิ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนี  
3. เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลตัวอย่าง  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. ใช้เซลล์ของ Workbook เป็นป้ายข้อมูล  
6. บันทึกการพรีเซนเทชัน  

โค้ด Python ด้านล่างแสดงวิธีกำหนดเซลล์ Workbook เป็นป้ายข้อมูลแผนภูมิ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์การนำเสนอ
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

## **จัดการ Worksheet**

โค้ด Python ด้านล่างแสดงวิธีใช้คุณสมบัติ `worksheets` เพื่อเข้าถึงคอลเลกชัน Worksheet:

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

## **ตรวจจับรูปแบบ Workbook ที่ฝังไว้ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ Excel binary workbook (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ `embedded_workbook_type` บน [ChartData](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ๆ

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
            # Workbook ที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue

        # อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่นี่.
```

## **Workbook ภายนอก**

Aspose.Slides รองรับการใช้ Workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **กำหนด Workbook ภายนอก**

โดยใช้เมธอด [ChartData.set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนด Workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลเมธอดนี้ยังสามารถอัปเดตเส้นทางของ Workbook ภายนอกหากมีการย้ายไฟล์

แม้คุณจะไม่สามารถแก้ไขข้อมูลใน Workbook ที่จัดเก็บบนตำแหน่งหรือทรัพยากรระยะไกลได้ แต่คุณยังสามารถใช้ Workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากคุณระบุเส้นทางแบบสัมพัทธ์สำหรับ Workbook ภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Python ด้านล่างแสดงวิธีกำหนด Workbook ภายนอก:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

พารามิเตอร์ `update_chart_data` ของเมธอด [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) ระบุว่า Workbook ของ Excel จะถูกโหลดหรือไม่

- เมื่อ `update_chart_data` ตั้งเป็น `False` จะอัปเดตเฉพาะเส้นทางของ Workbook; ข้อมูลแผนภูมิจะไม่ถูกโหลดหรือรีเฟรชจาก Workbook ปลายทาง ใช้เมื่อนั้น Workbook ปลายทางไม่มีหรือไม่สามารถเข้าถึงได้  
- เมื่อ `update_chart_data` ตั้งเป็น `True` ข้อมูลแผนภูมิจะถูกโหลดและอัปเดตจาก Workbook ปลายทาง  

### **สร้าง Workbook ภายนอก**

โดยใช้เมธอด [read_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) และ [set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถสร้าง Workbook ภายนอกตั้งแต่ต้นหรือแปลง Workbook ภายในเป็น Workbook ภายนอกได้

โค้ด Python ด้านล่างแสดงกระบวนการสร้าง Workbook ภายนอก:

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

### **รับเส้นทาง Workbook แหล่งข้อมูลภายนอกจากแผนภูมิ**

บางครั้งข้อมูลของแผนภูมิเชื่อมโยงกับ Workbook Excel ภายนอกแทนที่ข้อมูลฝังในพรีเซนเทชัน ด้วย Aspose.Slides คุณสามารถตรวจสอบแหล่งข้อมูลของแผนภูมิและหากเป็น Workbook ภายนอกก็สามารถอ่านเส้นทางเต็มของ Workbook นั้นได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/)  
2. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน  
3. รับอ้างอิงไปยังรูปทรงแผนภูมิ  
4. รับแหล่งข้อมูล ([ChartDataSourceType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatasourcetype/)) ที่แสดงแหล่งข้อมูลของแผนภูมิ  
5. ตรวจสอบว่าประเภทแหล่งข้อมูลตรงกับประเภท Workbook ภายนอกหรือไม่  

โค้ด Python ด้านล่างแสดงการทำงาน:

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

คุณสามารถแก้ไขข้อมูลใน Workbook ภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลใน Workbook ภายใน หากไม่สามารถโหลด Workbook ภายนอกได้ จะมีข้อยกเว้นถูกโยนออกมา

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิใช้ Workbook ภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้าง Workbook ของแผนภูมิใหม่จากข้อมูลที่เก็บไว้ในแคชของพรีเซนเทชันได้ สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/) แล้วเปิดใช้งาน [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/th/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) ผ่าน [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/spreadsheet_options/) ก่อนเปิดพรีเซนเทชัน

โค้ด Python ตัวอย่างต่อไปนี้เปิดพรีเซนเทชันที่แผนภูมิเชื่อมโยงกับ Workbook ภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.chart_data](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/chart_data/) และ [ChartData.chart_data_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
```

หาก Workbook ภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้นให้โดยให้เปิดการกู้คืนเฉพาะเมื่อต้องการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกสำรอง เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำใน Workbook ภายนอกหลังจากพรีเซนเทชันถูกอัปเดตครั้งล่าสุด

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับ Workbook ภายนอกหรือที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/) และ [path to an external workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) หากแหล่งข้อมูลเป็น Workbook ภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางแบบสัมพัทธ์ไปยัง Workbook ภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางแบบสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางที่เป็นแบบเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ; อย่างไรก็ตามพรีเซนเทชันจะจัดเก็บเส้นทางเต็มในไฟล์ PPTX

**สามารถใช้ Workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ใช้ได้ Workbook เหล่านั้นสามารถเป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไข Workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**

ไม่ พรีเซนเทชันจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกพรีเซนเทชัน

**ถ้าไฟล์ภายนอกมีรหัสผ่านจะทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีการทั่วไปคือเอาการป้องกันออกล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](/cells/python-net/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง Workbook ภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนผลต่อทุกแผนภูมิในครั้งต่อไปที่โหลดข้อมูล