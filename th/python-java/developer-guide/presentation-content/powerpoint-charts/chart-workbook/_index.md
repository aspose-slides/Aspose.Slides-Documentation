---
title: จัดการสมุดงานแผนภูมิในพรีเซนเทชันโดยใช้ Python ผ่าน Java
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/python-java/chart-workbook/
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
- พรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลพรีเซนเทชันของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับ workbook ของแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมผ่านสตรีม workbook, ใช้เซลล์ workbook เป็นป้ายกำกับข้อมูลแผนภูมิ, เข้าถึงคอลเลกชัน worksheet, และกำหนดประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

ยังครอบคลุมการทำงานกับ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนด workbook ภายนอก, เรียกคืนเส้นทางของ workbook ภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อ workbook มีอยู่

สำหรับเซลล์ workbook ที่แทนค่าขาดหาย ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-java/chart-series/) เพื่อทราบความแตกต่างระหว่างเซลล์ว่างกับศูนย์, และดูการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ worksheet ที่ซ่อนหรือไม่ ตั้งเป็น `True` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็น, หรือ `False` เพื่อรวมเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ worksheet

ดาวน์โหลด [hidden-source-data.pptx](hidden-source-data.pptx) และวางไว้ในไดเรกทอรีทำงาน สไลด์แรกมีแผนภูมิคอลัมน์เป็นรูปทรงแรก worksheet ที่ฝังอยู่ `Sheet1` มีช่วงข้อมูลต้นทาง `A1:C4` แถว 3 และคอลัมน์ C ถูกซ่อน, แต่เซลล์ยังคงมีค่า

| แถวแผ่นงาน | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (hidden row) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getChartDataWorkbook) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdatacell/#isHidden) เพื่อตรวจสอบสถานะการซ่อน วิธีนี้รายงานสถานะโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็น, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังเปลี่ยนการตั้งค่าการพล็อต: รักษา workbook ที่ฝังอยู่ด้วย [readWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#readWorkbookStream) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#writeWorkbookStream) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setRange) เพื่อกู้คืนช่วงเต็มรวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนแฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิที่แคชและป้ายชื่อหมวดหมู่ของตัวอย่างนี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # รีเฟรชข้อมูลแผนภูมิจาก workbook ที่ฝังไว้.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # คืนค่าช่วงแหล่งข้อมูลทั้งหมด รวมถึงหมวดหมู่ที่ซ่อนอยู่.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

ตัวอย่างบันทึก `hidden_cells_True.pptx` ที่มีเฉพาะค่าขายปลีกที่มองเห็น (10 และ 20), และ `hidden_cells_False.pptx` ที่มีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพล็อต แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสอง workbook ที่ฝังไว้

| เฉพาะเซลล์ที่มองเห็น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#setDisplayBlanksAs) ควบคุมวิธีแสดงค่าที่ขาดหาย; ไม่ได้รวมหรือ exclude ข้อมูลต้นทางที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **อ่านและเขียนข้อมูลแผนภูมิจาก Workbook**

Aspose.Slides for Python via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ช่วยให้คุณอ่านและเขียน workbook ของข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับต้นทาง

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก อ่าน workbook ที่ฝังไว้เป็นอาเรย์ไบต์, ล้างชุดข้อมูลและหมวดหมู่เดิม, แล้วเขียน workbook เดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่บันทึกพรีเซนเทชั่น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **ตรวจสอบ Layout ของแผนภูมิหลังการแก้ไข Workbook**

เมื่อคุณแทนที่ workbook ที่ฝังไว้ด้วยเวอร์ชันที่แก้ไขแล้ว, แผนภูมิจะคงชุดข้อมูลและคอลเลกชันหมวดหมู่เดิม ความไม่ตรงกันนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#validateChartLayout) ล้มเหลวด้วยข้อผิดพลาด index‑out‑of‑range ให้ล้างชุดข้อมูลและหมวดหมู่เดิมก่อนเขียน workbook ที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างต้องการ `chart.pptx` ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก คอมเม้นท์ระบุจุดที่ทำการแก้ไข workbook; ตัวอย่างรันได้เขียน workbook ดั้งเดิมกลับและตรวจสอบ layout ในหน่วยความจำ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # แก้ไขไบต์ของ workbook ที่นี่, ตัวอย่างเช่น, ใช้ Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่ค้างอยู่ก่อนที่ workbook จะถูกเขียนกลับ สร้างชุดข้อมูลและการแมพหมวดหมู่ใหม่ตามความต้องการของ workbook ที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่า Cell ของ Workbook เป็นป้ายกำกับข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ workbook เป็นป้ายกำกับข้อมูลแผนภูมิ ขั้นตอนต่อไปนี้แสดงวิธีเชื่อมป้ายกำกับในแผนภูมิบับเบิลกับเซลล์ใน workbook ข้อมูลของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์  
3. เพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น  
4. เข้าถึง series ของแผนภูมิ  
5. ตั้งค่า cell ของ workbook เป็นป้ายกำกับข้อมูล  
6. บันทึกพรีเซนเทชั่น

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์, แล้วเพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น ใช้เซลล์ A10:A12 บน worksheet 0 สำหรับป้ายกำกับสามรายการแรกใน series แรก, เปิดใช้งานป้ายกำกับจากเซลล์, และบันทึกผลลัพธ์เป็น `resultchart.pptx`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
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

## **จัดการ Worksheets**

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdataworkbook/#getWorksheets) ให้เข้าถึง worksheets ใน workbook ของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อ worksheet แต่ละชื่อออกที่คอนโซล

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **กำหนดประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3D ด้วยข้อมูลเริ่มต้นและตั้งชื่อ series สองรายการโดยใช้แหล่งข้อมูลต่างกัน รายชื่อแรกใช้สตริงลิเทอรัล; รายชื่อที่สองใช้เซลล์ C1 บน worksheet 0 ตัวเลือก [DataSourceType](https://reference.aspose.com/slides/th/python-java/aspose.slides/datasourcetype/) กำหนดแหล่งสำหรับแต่ละชื่อ ผลลัพธ์บันทึกเป็น `pres.pptx`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจจับรูปแบบ Workbook ที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบ workbook Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/python-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปทรงบนสไลด์แรกของ `sample.pptx`, ข้ามรูปทรงที่ไม่ใช่แผนภูมิ, และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มี workbook .xlsb ฝังอยู่

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

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # อ่านหรือแก้ไขข้อมูล workbook ของแผนภูมิที่รองรับที่นี่.
finally:
    presentation.dispose()
```

## **Workbook ภายนอก**

Aspose.Slides รองรับการใช้ workbook ภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้าง Workbook ภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) เพื่อส่งออก workbook ของแผนภูมิที่ฝังเป็นไฟล์และเชื่อมโยงแผนภูมิกับ workbook ภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเส้นพายด้วยข้อมูลเริ่มต้น, เขียน workbook ไปที่ `externalWorkbook1.xlsx`, และทำการเขียนไฟล์ให้เสร็จก่อนกำหนดไฟล์เป็นแหล่งข้อมูลของแผนภูมิ บันทึกพรีเซนเทชั่นที่เชื่อมโยงเป็น `externalWorkbook.pptx`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **กำหนด Workbook ภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถกำหนด workbook ภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยัง workbook ภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลใน workbook ที่จัดเก็บบนตำแหน่งระยะไกลหรือทรัพยากรอื่นได้, คุณยังสามารถใช้ workbook นั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้เส้นทางแบบสัมพัทธ์สำหรับ workbook ภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ต้องการ `externalWorkbook.xlsx` ในไดเรกทอรีทำงาน Worksheet ชื่อ `Sheet1` ต้องมีชื่อ series ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเส้นพาย, เชื่อมต่อ workbook, และใช้ [setRange](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setRange) เพื่อแมพ A1:B4 เป็น series หนึ่งและสามหมวดหมู่ บันทึกผลลัพธ์เป็น `Presentation_with_externalWorkbook.pptx`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#setExternalWorkbook) ควบคุมว่าจะโหลด workbook หรือไม่

* เมื่อ `updateChartData` เป็น `False` เพียงอัปเดตเส้นทาง workbook เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจาก workbook ปลายทาง, ดังนั้น workbook อาจไม่พร้อมใช้งาน  
* เมื่อ `updateChartData` เป็น `True` ข้อมูลแผนภูมิจะอัปเดตจาก workbook ปลายทาง

ตัวอย่างต่อไปกำหนด URL ตัวแทนด้วย `updateChartData` เท่ากับ `False` จะคงข้อมูลเริ่มต้นของแผนภูมิเส้นพายและบันทึกพรีเซนเทชั่นโดยไม่โหลด workbook ที่ไม่พร้อมใช้งาน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **รับเส้นทาง Workbook ของแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุ workbook ที่เชื่อมกับแผนภูมิ, ก่อนอื่นตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่ หากใช่ คุณสามารถเรียกคืนเส้นทาง workbook ได้ตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์  
3. ตรวจสอบว่ารูปทรงแรกเป็นแผนภูมิหรือไม่  
4. อ่านประเภทแหล่งข้อมูลของแผนภูมิ  
5. หากเป็น workbook ภายนอก, อ่านเส้นทางของมัน

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างในตัวอย่างก่อนหน้า, ตรวจสอบรูปทรงแรกบนสไลด์แรก หากเป็นแผนภูมิที่เชื่อมกับ workbook ภายนอก ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ไปที่คอนโซล จากนั้นบันทึกสำเนาพรีเซนเทชั่นเป็น `Result.pptx`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลใน workbook ภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาใน workbook ภายใน หาก workbook ภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ต้องการ `presentation.pptx` ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและมี workbook ภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่ได้จากเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 และบันทึกพรีเซนเทชั่นเป็น `presentation_out.pptx` การแก้ไขค่าจากเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้, ดังนั้นใช้สำเนาหากต้องการรักษา workbook ดั้งเดิมไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **กู้คืน Workbook จากแคชของแผนภูมิ**

หากแผนภูมิใช้ workbook ภายนอกที่หายไปหรือไม่พร้อมใช้งาน, Aspose.Slides สามารถสร้าง workbook ของแผนภูมิจากข้อมูลที่แคชในพรีเซนเทชั่นได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), และตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) เป็น `True` ก่อนเปิดพรีเซนเทชั่น

ตัวอย่าง Python ด้านล่างเปิด `presentation.pptx` ซึ่งรูปทรงแรกบนสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิง workbook ภายนอกที่ไม่พร้อมใช้งาน, แล้วเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # อ่านหรือแก้ไขข้อมูล workbook ที่กู้คืนที่นี่.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

หาก workbook ภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อต้องการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้, เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำใน workbook ภายนอกหลังจากพรีเซนเทชั่นอัปเดตครั้งล่าสุด

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมกับ workbook ภายนอกหรือที่ฝังอยู่?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getDataSourceType) และ [path to an external workbook](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากแหล่งเป็น workbook ภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกหรือไม่

**รองรับเส้นทางสัมพัทธ์ไปยัง workbook ภายนอกหรือไม่, และจัดเก็บอย่างไร?**

รองรับ. หากระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มอัตโนมัติ พรีเซนเทชั่นจะเก็บเส้นทางเต็มในไฟล์ PPTX, ดังนั้นการย้าย workbook อาจต้องอัปเดตลิงก์

**ฉันสามารถใช้ workbook ที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, workbook ดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไข workbook ระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชั่นหรือไม่?**

พรีเซนเทชั่นจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). การแก้ไขข้อมูลแผนภูมิที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องที่เชื่อมโยง ใช้สำเนาของ workbook หากต้องการให้ไฟล์ต้นฉบับคงที่

**ถ้าไฟล์ภายนอกมีการตั้งรหัสผ่านควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่นโดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิง workbook ภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิจัดเก็บลิงก์ของตัวเอง หากทุกอ้างอิงไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะส่งผลต่อทุกแผนภูมิในการโหลดข้อมูลครั้งถัดไป