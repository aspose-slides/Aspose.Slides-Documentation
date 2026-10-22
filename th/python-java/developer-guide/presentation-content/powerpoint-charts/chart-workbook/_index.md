---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอด้วย Python via Java
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/python-java/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายกำกับข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides for Python via Java: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายเพื่อปรับปรุงข้อมูลในงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิโดยใช้สตรีมของสมุดงาน ใช้เซลล์ของสมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของเวิร์กชีต และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิโดยที่สมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แทนค่าข้อมูลที่หายไป ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-java/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) เพื่อควบคุมว่าการวาดแผนภูมิจะใช้ข้อมูลจากแถวและคอลัมน์ที่ซ่อนหรือไม่ ตั้งค่าเป็น `True` เพื่อวาดเฉพาะเซลล์ที่มองเห็นได้ หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการวาดแผนภูมิเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของเวิร์กชีต

[ไฟล์ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีแผนภูมิกอลัมน์เป็นรูปร่างแรกบนสไลด์แรก เวิร์กชีตฝังอยู่ชื่อ `Sheet1` มีช่วงข้อมูลต้นทาง `A1:C4` แถว 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ของพวกมันยังคงมีค่า

| แถวเวิร์กชีต | A: เดือน | B: การขายปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) เพื่อสอบสอบสถานะการซ่อน วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 มองเห็นได้ B3 อยู่ในแถวที่ซ่อนและ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ `False`, `True`, และ `True` ตามลำดับ

ในตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการวาด: เก็บสมุดงานฝังด้วย [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และโหลดกลับด้วย [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) เมื่อรวมทุกเซลล์ ให้ใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อกู้ช่วงเต็มรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายหมวดที่เก็บไว้ในตัวอย่างนี้

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

            # รีเฟรชข้อมูลแผนภูมิจากสมุดงานฝัง.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # คืนช่วงต้นทางทั้งหมด รวมถึงหมวดที่ซ่อน.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: เวอร์ชันหนึ่งมีค่า Retail ที่มองเห็นได้เท่านั้น (10 และ 20) และอีกหนึ่งมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการวาด แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานฝังทั้งสอง

| เฉพาะเซลล์ที่มองเห็น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนแต่มีค่าแตกต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลต้นทางที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/python-java/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลสมุดงานในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่าแผนภูมิใช้เซลล์เวิร์กชีตใดบ้าง วิธี [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) คืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่ระบุเวิร์กชีต เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อเวิร์กชีต `!` แยกจากช่วงเซลล์และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองค่า เครื่องหมายดอลลาร์เซ็นต์บ่งชี้อ้างอิงแถวและคอลัมน์แบบคงที่

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือสมุดงาน หากแผนภูมิไม่ได้ใช้สมุดงานเป็นแหล่งข้อมูล จะโยก `InvalidOperationException` สำหรับข้อมูลเพิ่มเติม ดูที่ [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงต้นทาง หากแผนภูมิไม่ได้ใช้สมุดงาน จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

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

Aspose.Slides for Python via Java ให้เมธอด [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ทำให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับต้นทาง

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่านสมุดงานฝังเป็นอาเรย์ไบต์ ล้างซีรีส์และหมวดหมู่เดิม แล้วเขียนสมุดงานเดียวกันกลับไป การเปลี่ยนแปลงค้างอยู่ในหน่วยความจำ ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานฝังด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะคงซีรีส์และคอลเลกชันหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) ล้มเหลวด้วยข้อผิดพลาดดัชนีออกนอกช่วง ลบซีรีส์และหมวดหมู่เดิมก่อนเขียนสมุดงานอัปเดตกลับไปยังแผนภูมิ ตัวอย่างใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์บ่งชี้จุดที่ต้องแก้ไขสมุดงาน; ตัวอย่างที่ทำงานเขียนสมุดงานต้นกลับและตรวจสอบโครงสร้างในหน่วยความจำ

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

        # แก้ไขไบต์ของสมุดงานที่นี่, ตัวอย่างเช่นโดยใช้ Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

การลบคอลเลกชันช่วยลบการอ้างอิงข้อมูลที่เก่าออกก่อนเขียนสมุดงานกลับ สร้างแม็พซีรีส์และหมวดหมู่ใหม่สำหรับสมุดงานอัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าฟอร์แมตตัวเลขแบบกำหนดเองสำหรับเซลล์สมุดงาน**

ใช้ [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) เพื่อควบคุมการแสดงค่าตัวเลขในสมุดงานฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการอัตราการแปลงแสดงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง ให้ค่าสองค่าดังกล่าวเป็นตัวเลขเพื่อให้ยังคงใช้คำนวณและวาดแผนภูมิได้

ฟอร์แมตตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่เก็บไว้ ฟอร์แมต `0.0000%` จะแสดง `0.125` เป็น `12.5000%` แต่ไม่ได้แทนที่ตัวเลขที่เก็บเป็น `12.5` เช่นเดียวกัน `0.00000` แสดง `0.1234567` เป็น `0.12346` โดยไม่ปัดเศษค่าที่เก็บ หากฟอร์แมตกำหนดเป็นสตริงว่าง (`""`) จะใช้ฟอร์แมตที่คืนจาก [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) แทน

ตัวอย่างต่อไปสร้างแผนภูมิกอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) บนเวิร์กชีต 0 เซลล์ B2 มีอัตราการแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าของแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายกำกับค่าที่เชื่อมโยงกับฟอร์แมตต้นทาง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ฟอร์แมตเซลล์สมุดงานแยกจากฟอร์แมตที่ตั้งโดยตรงบนแกนแผนภูมิหรือป้ายกำกับข้อมูล ในตัวอย่างนี้แต่ละป้ายกำกับแสดงค่าจากเซลล์ต้นทางเนื่องจาก [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) ตั้งเป็น `True` และตามฟอร์แมตตัวเลขต้นทางเนื่องจาก [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) ตั้งเป็น `True` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายกำกับจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนตั้งใช้ฟอร์แมตของตัวเองตั้งด้วย [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) เป็น `0.00` และ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) ตั้งเป็น `False`

หากต้องการฟอร์แมตป้ายกำกับข้อมูลแยกต่างหาก ให้อตั้งค่าสถานะเชื่อมต่อกับต้นทางเป็น `False` แล้วกำหนดฟอร์แมตด้วย [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) วิธีนี้ไม่ได้เปลี่ยนฟอร์แมตของเซลล์สมุดงาน ตัวอย่างเช่น ฟอร์แมตป้ายกำกับอิสระ `0.00` จะแสดงค่แรกเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการกำหนดฟอร์แมตโดยตรง

รูปภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกและเปิดใหม่แล้ว:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายกำกับข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลค่าเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนเวิร์กชีต 0 เป็นสามป้ายแรกของซีรีส์แรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

## **จัดการเวิร์กชีต**

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) ให้เข้าถึงเวิร์กชีตในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิเส้นพายด้วยข้อมูลค่าเริ่มต้นและพิมพ์ชื่อแต่ละเวิร์กชีตไปยังคอนโซล

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

ค่าจุดของซีรีส์สามารถจัดเก็บเป็นลิเทรัลตัวเลขโดยตรงได้ ดูที่ [Set Series Values Using Numeric Literals](/slides/th/python-java/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างสมบูรณ์ที่บันทึกและอ่านค่าเหล่านี้ ประเภทแหล่งข้อมูลของค่าจุดแยกจากการกำหนดสมุดงานภายในหรือภายนอกของแผนภูมิ; การใช้ลิเทรัลตัวเลขไม่ทำให้สมุดงานฝังหายไปโดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิกอลัมน์ 3 มิติด้วยข้อมูลค่าเริ่มต้นและตั้งชื่อซีรีส์สองชื่อด้วยแหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้ลิเทรัลสตริง; ชื่อที่สองใช้เซลล์ C1 บนเวิร์กชีต 0 [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) ระบุแหล่งข้อมูลสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) ร่วมกับ enum [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่ฝังสมุดงาน .xlsb

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

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) เพื่อส่งออกสมุดงานแผนภูมิกฝังเป็นไฟล์และเชื่อมแผนภูมิกับสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเส้นพายด้วยข้อมูลค่าเริ่มต้นและส่งออกสมุดงานของมัน ทำการเขียนไฟล์ให้เสร็จก่อนกำหนดสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่ลิงก์ไว้

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

### **ตั้งค่าสมุดงานภายนอก**

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถกำหนดสมุดงานภายนอกให้เป็นแหล่งข้อมูลของแผนภูมิได้ วิธีนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังสมุดงานภายนอก (หากย้ายตำแหน่ง)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บไว้ในตำแหน่งระยะไกลหรือทรัพยากรได้ คุณก็ยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มอัตโนมัติ

ตัวอย่างนี้ใช้สมุดงานภายนอกที่เวิร์กชีตชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4 และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเส้นพาย, เชื่อมสมุดงาน, และใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อแมพ A1:B4 เป็นหนึ่งซีรีส์และสามหมวด แล้วบันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) ควบคุมว่าจะโหลดสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `False` จะอัปเดตเฉพาะเส้นทางสมุดงาน เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `True` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนด้วย `updateChartData` เท่ากับ `False` คงข้อมูลค่าเริ่มต้นของแผนภูมิเส้นพายและบันทึกงานนำเสนอโดยไม่ได้โหลดสมุดงานที่ไม่มีอยู่

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

### **รับเส้นทางของสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุสมุดงานที่เชื่อมโยงกับแผนภูมิ ตรวจสอบว่าแผนภูมิโใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางสมุดงานของมัน

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่เชื่อมสมุดงานภายนอก หากเป็นแผนภูมิที่เชื่อมสมุดงานภายนอก ตัวอย่างพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ไปยังคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกเช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับสมุดงานภายนอกที่เข้าถึงได้ ตั้งค่าค่าแบ็คของเซลล์สำหรับจุดข้อมูลแรกในซีรีส์แรกเป็น 100 แล้วบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าของเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อม ดังนั้นใช้สำเนาหากต้องการรักษาสมุดงานต้นฉบับไว้

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

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิกจากข้อมูลที่แคชอยู่ในงานนำเสนอ สร้าง [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), แล้วตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) เป็น `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ต่อไปนี้กู้คืนข้อมูลสมุดงานสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงสมุดงานภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนได้ที่นี่.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยกข้อยกเว้น เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิคือทางเลือกที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากครั้งสุดท้ายที่อัปเดตงานนำเสนอ

## **คำถามที่พบบ่อย**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิบางตัวเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝัง?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) และ [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากแหล่งคือสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อให้แน่ใจว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่ และเก็บอย่างไร?**

ใช่ หากระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางแบบสมบูรณ์โดยอัตโนมัติ งานนำเสนอเก็บเส้นทางสมบูรณ์ในไฟล์ PPTX ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรหรือแชร์เครือข่ายได้หรือไม่?**

ได้ สมุดงานเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม Aspose.Slides ไม่สนับสนุนการแก้ไขสมุดงานระยะไกลโดยตรง – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) การแก้ไขค่าที่มาจากเซลล์ของแผนภูมิอาจอัปเดตไฟล์ XLSX ภายในโลคัลที่เชื่อม ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ต้องทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่นโดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล**