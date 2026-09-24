---
title: จัดการสมุดงานแผนภูมิในการนำเสนอโดยใช้ Python ผ่าน Java
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/python-java/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายกำกับข้อมูล
- ชีตงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันชีตงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อตัวสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แทนค่าข้อมูลที่ขาดหาย ให้ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับศูนย์ และเปรียบเทียบโหมดการแสดงผลในแผนภูมิเส้น

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides ให้บริการเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดระเบียบในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

โค้ด Python ตัวอย่างต่อไปนี้สาธิตการทำงานตัวอย่าง:

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

### **ตรวจสอบเค้าโครงแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณเปลี่ยนสมุดงานที่ฝังไว้ด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะยังคงคอลเลกชันซีรีส์และประเภทของหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ขว้าง `ArgumentOutOfRangeException` (parameter: index) เพื่อหลีกเลี่ยงข้อยกเว้น ให้ล้างซีรีส์และหมวดหมู่ที่มีอยู่ **ก่อน** เขียนสมุดงานที่อัปเดตกลับไปที่แผนภูมิ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# อ่านสมุดงานหลังจากแก้ไข (เช่น การใช้ Aspose.Cells).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # ล้างการอ้างอิงข้อมูลที่มีอยู่.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

การล้างคอลเลกชันทำให้โครงสร้างข้อมูลแผนภูมิตรงกับสมุดงานใหม่ ซึ่งทำให้ [validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. เพิ่มแผนภูมิกระจุก (Bubble) พร้อมข้อมูลบางส่วน.
4. เข้าถึงซีรีส์ของแผนภูมิ.
5. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล.
6. บันทึกการนำเสนอ.

โค้ด Python นี้แสดงวิธีตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ:

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

## **จัดการชีตงาน**

โค้ด Python นี้สาธิตการทำงานที่ใช้เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#getWorksheets) เพื่อเข้าถึงคอลเลกชันชีตงาน:

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

## **ระบุประเภทแหล่งข้อมูล**

โค้ด Python นี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบสมุดงานที่ฝังไว้ที่ไม่ได้รับการสนับสนุน**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจถูกฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/) ร่วมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/th/python-java/aspose.slides/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ๆ

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
            # สมุดงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
            continue
        # อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่นี่.
finally:
    presentation.dispose()
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุตงานภายนอก**

โดยใช้เมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถสร้างสมุดงานภายนอกตั้งแต่เริ่มต้นหรือทำให้สมุดงานภายในเป็นภายนอกได้

โค้ด Python นี้สาธิตกระบวนการสร้างสมุดงานภายนอก:

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

### **ตั้งค่าสมุดงานภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากสมุดงานนั้นถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บไว้ในตำแหน่งระยะไกลหรือแหล่งทรัพยากรได้ คุณก็ยังสามารถใช้สมุดงานดังกล่าวเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด Python นี้แสดงวิธีตั้งค่าสมุดงานภายนอก:

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

พารามิเตอร์ที่สอง (`bool`) ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) ใช้เพื่อระบุว่าจะโหลดสมุดงาน Excel หรือไม่  

* เมื่อค่าตั้งเป็น `False` จะอัปเดตเฉพาะเส้นทางของสมุดงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อสมุดงานเป้าหมายไม่มีอยู่หรือไม่สามารถเข้าถึงได้  
* เมื่อค่าตั้งเป็น `True` ข้อมูลแผนภูมิจะถูกอัปเดตจากสมุดงานเป้าหมาย

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

### **รับเส้นทางสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน.
3. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ.
4. สร้างอ็อบเจกต์สำหรับประเภทแหล่งข้อมูล ([ChartDataSourceType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatasourcetype/)) ที่แทนแหล่งข้อมูลของแผนภูมิ.
5. ระบุเงื่อนไขที่เกี่ยวข้องตามประเภทแหล่งข้อมูลที่ตรงกับประเภทแหล่งข้อมูลสมุดงานภายนอก.

โค้ด Python นี้สาธิตการดำเนินการ:

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

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับที่แก้ไขเนื้อหาของสมุดงานภายใน เมื่อตัวสมุดงานภายนอกไม่สามารถโหลดได้ ระบบจะขว้างข้อยกเว้น

โค้ด Python นี้เป็นการนำไปใช้ของกระบวนการที่อธิบายไว้:

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/), ตั้งค่าด้วย [SpreadsheetOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/spreadsheetoptions/), และเรียก [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) ด้วย `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้เปิดงานนำเสนอที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpace.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนได้ที่นี่.
finally:
    presentation.dispose()
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด Aspose.Slides จะขว้างข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นทางเลือกที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากที่งานนำเสนอมีการอัปเดตครั้งสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่?**  
ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getDataSourceType) และ [path to an external workbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอกหรือไม่

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่ และจัดเก็บอย่างไร?**  
ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ อย่างไรก็ตาม โปรดทราบว่างานนำเสนอจะจัดเก็บเส้นทางเต็มในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**  
ได้ สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**  
ไม่ งานนำเสนอจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) และใช้ลิงก์นั้นในการอ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกงานนำเสนอ

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน ฉันควรทำอย่างไร?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ วิธีที่พบบ่อยคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาแบบถอดรหัส (เช่น การใช้ [Aspose.Cells](/cells/python-java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  
ได้ แต่ละแผนภูมจะเก็บลิงก์ของตนเอง หากทั้งหมดเชื่อมไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิครั้งต่อไปที่โหลดข้อมูล**