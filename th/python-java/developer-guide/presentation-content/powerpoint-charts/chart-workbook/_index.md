---
title: จัดการสมุดงานชาร์ตในงานนำเสนอด้วย Python ผ่าน Java
linktitle: สมุดงานชาร์ต
type: docs
weight: 70
url: /th/python-java/chart-workbook/
keywords:
- สมุดงานชาร์ต
- ข้อมูลชาร์ต
- เซลล์สมุดงาน
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชชาร์ต
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ Python ผ่าน Java: จัดการสมุดงานชาร์ตในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานชาร์ตใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลชาร์ตผ่านสตรีมของสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายข้อมูลชาร์ต เข้าถึงคอลเล็กชันของแผ่นงาน และกำหนดประเภทแหล่งข้อมูลสำหรับค่าชาร์ต

บทความยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของชาร์ต ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมต่อกับชาร์ต และแก้ไขข้อมูลชาร์ตเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แสดงข้อมูลที่หายไป ดูที่ [ควบคุมการแสดงผลของเซลล์ที่ว่าง](/slides/th/python-java/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับศูนย์ และการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) เพื่อควบคุมว่าชาร์ตจะทำการพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนหรือไม่ ตั้งค่าเป็น `True` เพื่อพล็อตเฉพเซลล์ที่มองเห็นได้เท่านั้น หรือ `False` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของชาร์ต; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

งานนำเสนอตัวอย่าง [sample presentation](hidden-source-data.pptx) มีชาร์ตคอลัมน์เป็นรูปร่างแรกบนสไลด์แรกของมัน ตารางที่ฝังไว้ `Sheet1` มีช่วงแหล่งข้อมูลต่อไปนี้ `A1:C4`. แถว 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ของพวกมันยังคงมีค่า

| แถวของแผ่นงาน | A: เดือน | B: รายปลีก | C: การขายส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) และอ่าน [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ วิธีนี้รายงานสถานะการซ่อนโดยไม่เปลี่ยนแปลงค่า ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ `False`, `True` และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลชาร์ตหลังจากเปลี่ยนการตั้งค่าการพล็อต: เก็บสมุดงานฝังด้วย [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) แล้วโหลดใหม่ด้วย [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) เมื่อรวมทุกเซลล์ให้ใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อคืนช่วงครบรวมรวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนแค่ค่าสถานะไม่เพียงพอที่จะรีเฟรชข้อมูลชาร์ตที่แคชและป้ายหมวดหมู่ของตัวอย่างนี้

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

            # รีเฟรชข้อมูลชาร์ตจากสมุดงานที่ฝังไว้.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # คืนช่วงแหล่งข้อมูลทั้งหมด รวมถึงหมวดหมู่ที่ซ่อนไว้.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

ตัวอย่างบันทึกเวอร์ชันของงานนำเสนอสองเวอร์ชัน: เวอร์ชันหนึ่งมีเฉพาะค่าการขายปลีกที่มองเห็นได้ (10 และ 20) และอีกเวอร์ชันหนึ่งมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงโหมดการพล็อตสองแบบ แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานฝังทั้งสอง

| เซลล์ที่มองเห็นได้เท่านั้น (`True`) | ทุกเซลล์ (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) ควบคุมวิธีที่ค่าที่หายไปถูกแสดง; มันไม่รวมหรือยกเว้นข้อมูลแหล่งซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ที่ว่าง](/slides/th/python-java/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **ดึงช่วงข้อมูลของชาร์ต**

ก่อนอัพเดตข้อมูลสมุดงานในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่าแผ่นงานใดบ้างที่แต่ละชาร์ตใช้ วิธี [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) จะคืนช่วงข้อมูลปัจจุบันในรูปแบบสูตรที่ระบุแผ่นงาน เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อแผ่นงาน, `!` แยกจากช่วงเซลล์, `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมถึงเครื่องหมาย `$` แสดงการอ้างอิงแบบคงที่

วิธีนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงชาร์ตหรือสมุดงาน หากชาร์ตไม่ใช้สมุดงานเป็นแหล่งข้อมูล จะทำให้เกิด `InvalidOperationException` สำหรับข้อมูลเพิ่มเติมดูที่ [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อหา ชาร์ต พิมพ์ชื่อชาร์ตและช่วงแหล่งข้อมูล หากชาร์ตไม่ใช้สมุดงานจะพิมพ์ข้อความและดำเนินการต่อไปยังชาร์ตถัดไป

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

## **อ่านและเขียนข้อมูลชาร์ตจากสมุดงาน**

Aspose.Slides for Python via Java ให้บริการเมธอด [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลชาร์ต (ซึ่งบรรจุข้อมูลชาร์ตที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลชาร์ตต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้งานนำเสนอที่มีชาร์ตเป็นรูปร่างแรกบนสไลด์แรก อ่านสมุดงานฝังไปยังอาร์เรย์ไบต์, ล้างซีรีส์และหมวดหมู่ที่มีอยู่, แล้วเขียนสมุดงานเดิมกลับไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างไม่บันทึกงานนำเสนอ

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

### **ตรวจสอบเค้าโครงชาร์ตหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานฝังด้วยสมุดงานที่แก้ไขแล้ว ชาร์ตจะยังคงคอลเล็กชันซีรีส์และหมวดหมู่เดิม ความไม่สอดคล้องนี้อาจทำให้ [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ล้างซีรีส์และหมวดหมู่ที่มีอยู่ก่อนเขียนสมุดงานที่อัพเดทกลับไปยังชาร์ต ตัวอย่างใช้ชาร์ตที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์บ่งชี้จุดที่จะแก้ไขสมุดงาน; ตัวอย่างที่ทำงานได้เขียนสมุดงานเดิมกลับและตรวจสอบเค้าโครงในหน่วยความจำ

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

การล้างคอลเล็กชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนสมุดงานถูกเขียนกลับ สร้างการแมปซีรีส์และหมวดหมู่ใหม่ตามสมุดงานที่อัพเดทก่อนใช้ชาร์ต

## **ตั้งค่าฟอร์แมตตัวเลขแบบกำหนดเองสำหรับเซลล์สมุดงาน**

ใช้ [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) เพื่อควบคุมรูปแบบการแสดงค่าตัวเลขในสมุดงานฝังของชาร์ต ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราการแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง ค่าทั้งสองควรเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและการพล็อตชาร์ตได้

ฟอร์แมตตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่จัดเก็บ ฟอร์แมต `0.0000%` จะแสดง `0.125` เป็น `12.5000%`; มันไม่แทนที่ตัวเลขที่จัดเก็บด้วย `12.5` เช่นเดียวกัน `0.00000` จะทำให้ `0.1234567` แสดงเป็น `0.12346` โดยไม่ปัดค่าที่จัดเก็บ หากฟอร์แมตที่กำหนดเป็นสตริงว่าง (`""`) ระบบจะใช้ฟอร์แมตที่ได้จาก [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) แทน

ตัวอย่างต่อไปนี้สร้างชาร์ตคอลัมน์และเข้าถึงเซลล์ผ่าน [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) บนแผ่นงาน 0, B2 มีอัตราการแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์ให้ค่าแก่ชาร์ต ตัวอย่างยังเปิดใช้ป้ายค่าเชื่อมโยงกับฟอร์แมตแหล่งข้อมูล

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

ฟอร์แมตเซลล์สมุดงานแยกจากฟอร์แมตที่กำหนดโดยตรงบนแกนชาร์ตหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายจะแสดงค่าจากเซลล์แหล่งที่มาด้วยเหตุผลที่ [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) ตั้งเป็น `True` และฟอร์แมตตัวเลขเชื่อมโยงกับแหล่งที่มาด้วย [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) ตั้งเป็น `True` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้ฟอร์แมตตัวเลขของมันเอง กำหนดด้วย [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) เป็น `0.00` และ [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) ตั้งเป็น `False`

หากต้องการฟอร์แมตป้ายข้อมูลแยกจากแหล่ง ให้ตั้งค่าแฟล็กเชื่อมโยงแหล่งเป็น `False` แล้วกำหนดฟอร์แมตด้วย [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) วิธีนี้จะไม่เปลี่ยนฟอร์แมตของเซลล์สมุดงาน ตัวอย่างเช่น ฟอร์แมตป้ายอิสระ `0.00` จะแสดงค่าตัวแรกเป็น `0.13` ในขณะที่ B2 ยังแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) เพื่อทำการฟอร์แมตป้ายโดยตรง

ภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกแล้วและเปิดใหม่อีกครั้ง:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายข้อมูลของชาร์ต**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายข้อมูลของชาร์ตได้

ตัวอย่างนี้เพิ่มชาร์ตฟองจากข้อมูลเริ่มต้นไปยังสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายสามค่าแรกในซีรีส์แรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัพเดทแล้ว

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

## **จัดการแผ่นงาน**

เมธอด [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) ให้การเข้าถึงแผ่นงานในสมุดงานชาร์ต ตัวอย่างนี้สร้างชาร์ตพายด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละแผ่นงานลงคอนโซล

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

ตัวอย่างนี้สร้างชาร์ตคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและกำหนดชื่อซีรีส์สองชื่อโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้สตริงลิตเตรัล; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 ตัวเลือก [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) ระบุแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัพเดท

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

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางชาร์ต คุณสามารถใช้เมธอด [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) บน [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามชาร์ตเหล่านั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่ชาร์ต และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละชาร์ตที่มีสมุดงาน .xlsb ฝังอยู่

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
        # อ่านหรือแก้ไขข้อมูลสมุดงานชาร์ตที่รองรับที่นี่.
finally:
    presentation.dispose()
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลของชาร์ต

### **สร้างสมุดงานภายนอก**

ใช้ [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) และ [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) เพื่อส่งออกสมุดงานชาร์ตฝังเป็นไฟล์และเชื่อมชาร์ตกับสมุดงานภายนอกร่วมกัน

ตัวอย่างนี้สร้างชาร์ตพายด้วยข้อมูลเริ่มต้นและส่งออกสมุดงานของมัน ทำการเขียนไฟล์ให้เสร็จก่อนกำหนดสมุดงานภายนอกเป็นแหล่งข้อมูลของชาร์ต จากนั้นบันทึกงานนำเสนอที่เชื่อมโยงแล้ว

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

โดยใช้เมธอด [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) คุณสามารถกำหนดสมุดงานภายนอกให้กับชาร์ตเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางของสมุดงานภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ แต่ยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากให้เส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้สมุดงานภายนอกที่มีแผ่นงานชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างชาร์ตพาย, เชื่อมสมุดงาน, และใช้ [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) เพื่อแมป A1:B4 ไปยังซีรีส์เดียวและสามหมวดหมู่ จากนั้นบันทึกงานนำเสนอพร้อมชาร์ตที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของเมธอด [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) ควบคุมว่ากรณีสมุดงานจะถูกโหลดหรือไม่

* เมื่อ `updateChartData` เป็น `False` จะอัปเดตเพียงเส้นทางของสมุดงานเท่านั้น ชาร์ตข้อมูลจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `True` ชาร์ตข้อมูลจะอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปนี้กำหนด URL ตัวแทนด้วย `updateChartData` ตั้งเป็น `False` งานนำเสนอจะคงข้อมูลเริ่มต้นของชาร์ตพายและบันทึกโดยไม่โหลดสมุดงานที่ไม่มีอยู่

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

### **รับเส้นทางของสมุดงานแหล่งข้อมูลภายนอกของชาร์ต**

เพื่อระบุสมุดงานที่เชื่อมต่อกับชาร์ต ให้ตรวจสอบว่าชาร์ตใช้แหล่งข้อมูลภายนอกหรือไม่ และดึงเส้นทางสมุดงานของมัน

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีสมุดงานภายนอกที่เชื่อมโยง หากเป็นชาร์ตที่เชื่อมกับสมุดงานภายนอก ตัวอย่างจะพิมพ์ [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) ลงคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอ

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

### **แก้ไขข้อมูลชาร์ต**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการทำการเปลี่ยนแปลงในสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้ชาร์ตที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับสมุดงานภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่สนับสนุนโดยเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 แล้วบันทึกงานนำเสนอที่อัพเดท การแก้ไขค่าเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมต่อได้ ดังนั้นควรใช้สำเนาหากต้องการเก็บสมุดงานต้นฉบับไว้

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

### **กู้คืนสมุดงานจากแคชของชาร์ต**

หากชาร์ตใช้สมุดงานภายนอกที่หายไปหรือไม่มีอยู่ Aspose.Slides สามารถสร้างสมุดงานชาร์ตจากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), เรียก [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions), แล้วตั้งค่า [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) เป็น `True` ก่อนเปิดงานนำเสนอ

ตัวอย่าง Python ด้านล่างกู้คืนข้อมูลสมุดงานสำหรับชาร์ตที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงถึงสมุดงานภายนอกที่ไม่มีอยู่ จากนั้นเข้าถึงข้อมูลที่กู้คืนผ่าน [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) และ [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

หากสมุดงานภายนอกไม่มีอยู่และการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยนข้อยกเว้น ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลชาร์ตที่แคชเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากที่งานนำเสนออัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้หรือไม่ว่าชาร์ตเฉพาะเชื่อมกับสมุดงานภายนอกหรือฝังอยู่?**

ใช่. ชาร์ตมี [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) และ [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); หากแหล่งเป็นสมุดงานภายนอกคุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกกำลังใช้หรือไม่

**รองรับการใช้เส้นทางสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ใช่. หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางแบบเต็มโดยอัตโนมัติ งานนำเสนอบันทึกเส้นทางแบบเต็มในไฟล์ PPTX ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่ตั้งอยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้, สมุดงานเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตามการแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอบันทึก [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) การแก้ไขค่าชาร์ตที่อิงกับเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**หากไฟล์ภายนอกถูกตั้งรหัสผ่านควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีที่พบบ่อยคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่นโดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายชาร์ตสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละชาร์ตบันทึกลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกชาร์ตเมื่อโหลดข้อมูลใหม่ครั้งต่อไป