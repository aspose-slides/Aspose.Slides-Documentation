---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอโดยใช้ Python ผ่าน Java
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/python-java/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายกำกับข้อมูล
- ชีทงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของ Worksheet และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงพาธของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แสดงข้อมูลที่ขาดหาย ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-java/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างและค่า 0 และการเปรียบเทียบกราฟเส้นของโหมดการแสดงผลที่มี

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ของ Worksheet ที่ซ่อนหรือไม่ ตั้งค่าเป็น `True` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของกราฟ; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของ Worksheet

ตัวอย่างงานนำเสนอ [งานนำเสนอ ตัวอย่าง](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรก Worksheet ที่ฝังอยู่ `Sheet1` มีช่วงแหล่งข้อมูลต่อไปนี้ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ยังคงมีค่า

| แถว Worksheet | A: เดือน | B: ร้านค้าปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (แถวที่ซ่อน) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลง ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: คงสมุดงานฝังไว้ด้วย [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อคืนช่วงทั้งหมดรวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิที่แคชและป้ายกำกับหมวดหมู่ของตัวอย่างนี้

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

            # รีเฟรชข้อมูลแผนภูมิจากสมุดงานที่ฝังอยู่.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # คืนช่วงแหล่งข้อมูลเต็มรวมถึงหมวดหมู่ที่ซ่อนอยู่.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: หนึ่งเวอร์ชันที่มีเฉพาะค่าร้านค้าปลีกที่มองเห็นได้ (10 และ 20) และอีกเวอร์ชันที่มีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพล็อต แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานฝังทั้งสอง

| เฉพาะเซลล์ที่มองเห็น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![เซลล์ที่มองเห็นเท่านั้น: ค่าร้านค้าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าร้านค้าปลีกและขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) ควบคุมวิธีการแสดงค่าที่ขาดหาย; มันไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลสมุดงานในงานนำเสนอที่มีอยู่ ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่า Worksheet ใดใช้โดยแต่ละแผนภูมิ [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) คืนค่าช่วงข้อมูลปัจจุบันในรูปแบบสูตรที่ระบุ Worksheet เช่น `Sheet1!$A$1:$D$5` ซึ่ง `Sheet1` คือชื่อ Worksheet, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้ง `$` แสดงการอ้างอิงแบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือสมุดงานของมัน หากแผนภูมิไม่ได้ใช้สมุดงานเป็นแหล่งข้อมูล จะเกิดข้อผิดพลาด `InvalidOperationException` สำหรับข้อมูลเพิ่มเติมดูที่ [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างโดยตรงบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงแหล่งข้อมูล หากแผนภูมิไม่ได้ใช้สมุดงาน จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for Python via Java มีเมธอด [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งถูกแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่านสมุดงานฝังเป็นอาร์เรย์ไบต์, ล้างซีรีส์และหมวดหมู่เดิม, แล้วเขียนสมุดงานเดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่บันทึกงานนำเสนอ

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

### **ตรวจสอบการจัดรูปแบบแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานฝังด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิยังคงมีคอลเลกชันซีรีส์และหมวดหมู่เดิม ความไม่ตรงกันนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) ล้มเหลวด้วยข้อผิดพลาดดัชนีออกนอกช่วง ให้ล้างซีรีส์และหมวดหมู่เดิมก่อนเขียนสมุดงานอัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเม้นท์ระบุจุดที่ทำการแก้ไขสมุดงาน; ตัวอย่างที่รันได้เขียนสมุดงานเดิมกลับและตรวจสอบการจัดรูปแบบในหน่วยความจำ

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

        # แก้ไขไบต์ของสมุดงานที่นี่ ตัวอย่างเช่น ใช้ Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่เก่าออกก่อนที่สมุดงานจะถูกเขียนกลับ สร้างซีรีส์และการแม็ปหมวดหมู่ที่จำเป็นสำหรับสมุดงานที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลเริ่มต้นไปยังสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 ใน Worksheet 0 เป็นป้ายกำกับสามรายการแรกในซีรีส์แรก เปิดใช้งานป้ายกำกับจากเซลล์ และบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการ Worksheet**

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) ให้เข้าถึง Worksheet ในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อ Worksheet แต่ละชื่อไปยังคอนโซล

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

## **ระบุประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3D ที่มีข้อมูลเริ่มต้นและตั้งชื่อซีรีส์สองรายการโดยใช้แหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้สตริงลิเทรัล; ชื่อที่สองใช้เซลล์ C1 ใน Worksheet 0 ตัวเลือกกำหนดประเภทแหล่งข้อมูลคือ [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) ร่วมกับตัวเลือก [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่

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
        # อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่รองรับที่นี่.
finally:
    presentation.dispose()
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) เพื่อส่งออกสมุดงานแผนภูมิที่ฝังเป็นไฟล์และเชื่อมโยงแผนภูมิไปยังสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเสี้ยที่มีข้อมูลเริ่มต้นและส่งออกสมุดงานของมัน ทำการเขียนไฟล์ให้เสร็จก่อนกำหนดสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตพาธไปยังสมุดงานภายนอก (หากสมุดงานดังกล่าวถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ แต่คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุพาธแบบสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้สมุดงานภายนอกที่ Worksheet ชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิพาย, เชื่อมโยงสมุดงาน, และใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อแม็ป A1:B4 เป็นหนึ่งซีรีส์และสามหมวดหมู่ แล้วบันทึกงานนำเสนอที่มีแผนภูมิเชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) ควบคุมว่าต้องโหลดสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `False` จะอัปเดตเฉพาะพาธของสมุดงาน ไม่โหลดหรืออัปเดตข้อมูลแผนภูมิจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `True` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนด้วย `updateChartData` เป็น `False` คงข้อมูลเริ่มต้นของแผนภูมีพายและบันทึกงานนำเสนอโดยไม่โหลดสมุดงานที่ไม่มีอยู่

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

### **รับพาธของสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุสมุดงานที่เชื่อมโยงกับแผนภูมิ ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงพาธของสมุดงานนั้น

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีสมุดงานภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมกับสมุดงานภายนอก ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ไปยังคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของสมุดงานภายใน เมื่อไม่สามารถโหลดสมุดงานภายนอกได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมโยงกับสมุดงานภายนอกที่สามารถเข้าถึงได้ ตั้งค่าค่าแบ็คของเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นควรใช้สำเนาหากต้องการรักษาสมุดงานต้นฉบับไว้

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่มีอยู่ Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), และตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) เป็น `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้กู้คืนข้อมูลสมุดงานสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงถึงสมุดงานภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

หากสมุดงานภายนอกไม่มีอยู่และการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่?**

ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) และ [พาธไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านพาธเต็มเพื่อให้แน่ใจว่าใช้ไฟล์ภายนอก

**รองรับพาธแบบสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่ และพวกมันถูกจัดเก็บอย่างไร?**

ใช่ หากคุณระบุพาธแบบสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธแบบเต็มโดยอัตโนมัติ งานนำเสนอจัดเก็บพาธแบบเต็มในไฟล์ PPTX ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**

ใช้ได้ สมุดงานดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ – สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอจัดเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) การแก้ไขข้อมูลแผนภูมิที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยง ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงที่

**ควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีที่พบบ่อยคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิในครั้งต่อไปที่โหลดข้อมูล**