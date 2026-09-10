---
title: จัดการ Workbook ของแผนภูมิในงานนำเสนอด้วย Python ผ่าน Java
linktitle: Workbook ของแผนภูมิ
type: docs
weight: 70
url: /th/python-java/chart-workbook/
keywords:
- Workbook ของแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์ของ workbook
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- Workbook ภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืน Workbook
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน Java: จัดการ workbook ของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระบบระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับ workbook ของแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่าน stream ของ workbook, ใช้เซลล์ของ workbook เป็นป้ายข้อมูลของแผนภูมิ, เข้าถึงคอลเลกชันของ worksheet, และกำหนดประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนด workbook ภายนอก, ดึงเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook มีพร้อมใช้งาน

## **Read and Write Chart Data from a Workbook**
Aspose.Slides มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดรูปแบบในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ

โค้ด Python ตัวอย่างต่อไปนี้แสดงการดำเนินการตัวอย่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Validate Chart Layout After Workbook Modification**

เมื่อคุณแทนที่ workbook ที่ฝังอยู่ด้วย workbook ที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูล Series และ Category เดิมไว้ ความไม่สอดคล้องนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ขว้าง `ArgumentOutOfRangeException` (parameter: index) เพื่อหลีกเลี่ยงข้อยกเว้นนี้ ให้ล้าง Series และ Category ที่มีอยู่ **ก่อน** เขียน workbook ที่อัปเดตกลับไปยังแผนภูมิ

```python
import jpype
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# อ่าน workbook หลังจากแก้ไข (เช่น ใช้ Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # ลบการอ้างอิงข้อมูลที่มีอยู่.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

การล้างคอลเลกชันเหล่านี้ทำให้โครงสร้างข้อมูลแผนภูมิตรงกับ workbook ใหม่ ทำให้ [validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ทำงานสำเร็จโดยไม่เกิดข้อผิดพลาด

## **Set a Workbook Cell as a Chart Data Label**

1. สร้างอ็อบเจ็กต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
2. ดึงอ้างอิงสไลด์โดยใช้ดัชนี
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
4. เข้าถึง Series ของแผนภูมิ
5. ตั้งค่าเซลล์ของ workbook เป็นป้ายข้อมูล
6. บันทึกงานนำเสนอ

โค้ด Python ตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าเซลล์ของ workbook เป็นป้ายข้อมูลของแผนภูมิ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)
    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Manage Worksheets**

โค้ด Python ตัวอย่างต่อไปนี้ใช้เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#getWorksheets) เพื่อเข้าถึงคอลเลกชันของ worksheet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Specify the Data Source Type**

โค้ด Python ตัวอย่างต่อไปนี้แสดงวิธีกำหนดประเภทของแหล่งข้อมูล:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detect Unsupported Embedded Workbook Formats**

Aspose.Slides ไม่รองรับรูปแบบ workbook แบบไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/python-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue
        chart_data = shape.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # workbook ที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue
        # อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่นี่.
finally:
    presentation.dispose()
```

### **Create an External Workbook**

โดยใช้เมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถสร้าง workbook ภายนอกจากศูนย์หรือเปลี่ยน workbook ภายในให้เป็นภายนอกได้

โค้ด Python ตัวอย่างต่อไปนี้แสดงขั้นตอนการสร้าง workbook ภายนอก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Set an External Workbook**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลใน workbook ที่เก็บอยู่ในตำแหน่งระยะไกลหรือเป็นทรัพยากรได้ แต่ยังสามารถใช้ workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากกำหนดเส้นทางแบบสัมพันธ์สำหรับ workbook ภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Python ตัวอย่างต่อไปนี้แสดงวิธีตั้งค่า workbook ภายนอก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

พารามิเตอร์ที่สอง (`bool`) ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) ใช้กำหนดว่าจะโหลด workbook ของ Excel หรือไม่  

* หากตั้งค่าเป็น `False` จะอัปเดตเฉพาะเส้นทางของ workbook เท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook เป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อ workbook เป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
* หากตั้งค่าเป็น `True` ข้อมูลแผนภูมิจะถูกอัปเดตจาก workbook เป้าหมาย  

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Get the External Data Source Workbook Path of a Chart**

1. สร้างอ็อบเจ็กต์จากคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) 
2. ดึงอ้างอิงสไลด์โดยใช้ดัชนี
3. สร้างอ็อบเจ็กต์สำหรับรูปร่างแผนภูมิ
4. สร้างอ็อบเจ็กต์สำหรับแหล่งข้อมูล ([ChartDataSourceType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatasourcetype/)) ที่แทนประเภทแหล่งข้อมูลของแผนภูมิ
5. กำหนดเงื่อนไขที่เกี่ยวข้องตามประเภทแหล่งข้อมูลที่เป็น workbook ภายนอกเดียวกัน

โค้ด Python ตัวอย่างต่อไปนี้แสดงการดำเนินการ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Edit Chart Data**

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาใน workbook ภายใน เมื่อตัว workbook ภายนอกไม่สามารถโหลดได้ ระบบจะขว้างข้อยกเว้น

โค้ด Python ตัวอย่างต่อไปนี้เป็นการดำเนินการตามที่อธิบายไว้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Recover a Workbook from the Chart Cache**

หากแผนภูมิโดยใช้ workbook ภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถกู้คืน workbook ของแผนภูมิจากข้อมูลที่แคชอยู่ในงานนำเสนอได้ สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/) ตั้งค่าโดยใช้ [SpreadsheetOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/spreadsheetoptions/) แล้วเรียก [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ด้วยค่า `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ด้านล่างเปิดงานนำเสนอที่แผนภูมิอ้างอิง workbook ภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
finally:
    presentation.dispose()
```

ถ้า workbook ภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะขว้างข้อยกเว้น ให้เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำใน workbook ภายนอกหลังจากที่งานนำเสนอถูกอัปเดตครั้งล่าสุด

## **FAQ**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิใดเชื่อต่อกับ workbook ภายนอกหรือ workbook ที่ฝังอยู่?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getDataSourceType) และ [path to an external workbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากเป็น workbook ภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกหรือไม่

**รองรับเส้นทางแบบสัมพันธ์ไปยัง workbook ภายนอกหรือไม่ และเก็บอย่างไร?**

รองรับ หากคุณระบุเส้นทางแบบสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางแบบเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ; อย่างไรก็ตาม งานนำเสนอจะเก็บเส้นทางแบบเต็มในไฟล์ PPTX

**ฉันสามารถใช้ workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้ สามารถใช้ workbook เหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

ไม่ งานนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกจะไม่ถูกแก้ไขเมื่อบันทึกงานนำเสนอ

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน ฉันควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีที่พบบ่อยคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](/cells/python-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**แผนภูมิต่าง ๆ สามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล**