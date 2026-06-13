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
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน .NET: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน ใช้เซลล์ของสมุดงานเป็นป้ายข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของ worksheet และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะสาธิตวิธีการสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides มีเมธอดสำหรับอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งบรรจุข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ:** ข้อมูลแผนภูมิต้องจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งที่มานั้น

โค้ด Python ตัวอย่างแสดงการทำงาน:

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

## **ตั้งค่าเซลล์ใน WorkBook เป็นป้ายข้อมูลแผนภูมิ**

บางครั้งคุณต้องการป้ายแผนภูมิที่มาจากเซลล์โดยตรงในสมุดงานข้อมูลฐาน Aspose.Slides อนุญาตให้ผูกป้ายข้อมูลกับเซลล์ของสมุดงานเฉพาะเพื่อให้ข้อความป้ายสะท้อนค่าของเซลล์เสมอ ตัวอย่างด้านล่างแสดงวิธีเปิดใช้ป้ายจากค่าเซลล์และชี้ป้ายที่เลือกไปยังเซลล์ที่กำหนดเองในสมุดงานของแผนภูมิ

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/) .
2. รับอ้างอิงสไลด์ตามดัชนี.
3. เพิ่มแผนภูมิกระจอกพร้อมข้อมูลตัวอย่าง.
4. เข้าถึงชุดข้อมูลของแผนภูมิ.
5. ใช้เซลล์ของสมุดงานเป็นป้ายข้อมูล.
6. บันทึกงานนำเสนอ.

โค้ด Python ที่แสดงวิธีตั้งค่าเซลล์ของสมุดงานเป็นป้ายข้อมูลแผนภูมิ:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์งานนำเสนอ.
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

โค้ด Python ต่อไปนี้สาธิตวิธีใช้สมบัติ`worksheets`เพื่อเข้าถึงคอลเลกชัน worksheet:

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

โค้ด Python ต่อไปนี้แสดงวิธีระบุประเภทแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในแผนภูมิบางประเภท คุณสามารถใช้สมบัติ`embedded_workbook_type`บน[ChartData](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/)ร่วมกับการระบุ[WorkbookType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/workbooktype/)เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

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

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **ตั้งค่าสมุดงานภายนอก**

โดยใช้เมธอด[ChartData.set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถอัปเดตเส้นทางของสมุดงานภายนอกหากมีการย้ายตำแหน่ง

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บบนแหล่งทรัพยากรระยะไกลได้ แต่คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากคุณระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Python แสดงวิธีตั้งค่าสมุดงานภายนอก:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

พารามิเตอร์`update_chart_data`ของเมธอด[set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/)ระบุว่าจะโหลดสมุดงาน Excel หรือไม่

- เมื่อ`update_chart_data`ตั้งค่าเป็น`False`เส้นทางของสมุดงานจะอัปเดตเท่านั้น; ข้อมูลแผนภูมิจะไม่ถูกโหลดหรือรีเฟรชจากสมุดงานเป้าหมาย ใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีหรือไม่พร้อมใช้งาน
- เมื่อ`update_chart_data`ตั้งค่าเป็น`True`ข้อมูลแผนภูมิจะถูกโหลดและอัปเดตจากสมุดงานเป้าหมาย

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด[read_workbook_stream](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/read_workbook_stream/)และ[set_external_workbook](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/set_external_workbook/) คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือแปลงสมุดงานภายในให้เป็นภายนอกได้

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

### **รับเส้นทางของสมุดงานแหล่งข้อมูลภายนอกจากแผนภูมิ**

บางครั้งข้อมูลของแผนภูมิอาจเชื่อมโยงกับสมุดงาน Excel ภายนอกแทนข้อมูลที่ฝังในงานนำเสนอ ด้วย Aspose.Slides คุณสามารถตรวจสอบแหล่งข้อมูลของแผนภูมิและหากเป็นสมุดงานภายนอกก็อ่านเส้นทางเต็มของสมุดงานนั้น

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://docs.aspose.com/slides/th/python-net/api-reference/aspose.slides/presentation/) .
2. รับอ้างอิงสไลด์ตามดัชนีของมัน.
3. รับอ้างอิงรูปทรงแผนภูมิ.
4. รับแหล่งข้อมูล([ChartDataSourceType](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdatasourcetype/))ที่เป็นตัวแทนของแหล่งข้อมูลแผนภูมิ.
5. ตรวจสอบว่าชนิดของแหล่งข้อมูลตรงกับชนิดแหล่งข้อมูลสมุดงานภายนอกหรือไม่.

โค้ด Python ที่สาธิตการดำเนินการ:

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลในสมุดงานภายใน หากไม่สามารถโหลดสมุดงานภายนอกได้จะเกิดข้อยกเว้น

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดว่าผังใดผูกกับสมุดงานภายนอกหรือที่ฝังไว้หรือไม่?**

ได้. ผังมี[ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/)และ[เส้นทางไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/); หากแหล่งเป็นสมุดงานภายนอกคุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่และจัดเก็บอย่างไร?**

ใช่. หากระบุเส้นทางสัมพันธ์ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งช่วยให้โครงการพกพาได้ง่าย; อย่างไรก็ตามงานนำเสนอจะบันทึกเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**

ได้, สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

ไม่. งานนำเสนอจะเก็บ[ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/external_workbook_path/)และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกงานนำเสนอ

**ต้องทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่นโดยใช้[Aspose.Cells](/cells/python-net/))และเชื่อมลิงก์ไปยังสำเนานั้น

**หลายผังสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละผังก็จะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละผังเมื่อต่อไปข้อมูลถูกโหลด