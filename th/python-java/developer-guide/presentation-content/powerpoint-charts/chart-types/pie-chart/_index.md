---
title: ปรับแต่งแผนภูมิวงกลมในการนำเสนอด้วย Python ผ่าน Java
linktitle: แผนภูมิวงกลม
type: docs
url: /th/python-java/pie-chart/
keywords:
- แผนภูมิวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีชิ้นส่วน
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิวงกลมใน Python ผ่าน Java ด้วย Aspose.Slides ที่สามารถส่งออกเป็น PowerPoint เพื่อเสริมสร้างการเล่าเรื่องข้อมูลของคุณในไม่กี่วินาที"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลม (pie chart) ใน Aspose.Slides โดยแสดงวิธีการกำหนดตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีการเปิดใช้งานการกำหนดสีอัตโนมัติสำหรับชิ้นส่วนของแผนภูมิวงกลมมาตรฐาน

ตัวอย่างมุ่งเน้นขั้นตอนการปรับแต่งแผนภูมิในเชิงปฏิบัติเช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับค่า series และ label การแทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยประเภทและค่าแบบกำหนดเอง และการบันทึกงานนำเสนอที่อัปเดต

## **ตัวเลือกการพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for Python via Java รองรับตัวเลือกการพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie ส่วนนี้แสดงวิธีระบุตัวเลือกเหล่านั้นด้วย Aspose.Slides ให้ทำตามขั้นตอนต่อไปนี้

1. สร้างอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)​
2. เพิ่มแผนภูมิลงในสไลด์​
3. ระบุตัวเลือกการพล็อตที่สองของแผนภูมิ​
4. เขียนงานนำเสนอออกไปยังดิสก์​

ตัวอย่างต่อไปนี้ตั้งค่าคุณสมบัติต่าง ๆ ของแผนภูมิ Pie of Pie

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    # เพิ่มแผนภูมิลงในสไลด์.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # ตั้งค่าคุณสมบัติต่าง ๆ.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **กำหนดสีอัตโนมัติให้กับชิ้นส่วนของแผนภูมิวงกลม**

Aspose.Slides for Python via Java มี API อย่างง่ายสำหรับการตั้งค่าสีอัตโนมัติให้กับชิ้นส่วนของแผนภูมิวงกลม ตัวอย่างต่อไปนี้แสดงวิธีนำการตั้งค่าเหล่านี้ไปใช้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)​
2. เข้าถึงสไลด์แรก​
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น​
4. ตั้งชื่อแผนภูมิ​
5. ตั้งดัชนีของแผนภูมิใน Worksheet ของข้อมูล​
6. รับ Workbook ของข้อมูลแผนภูมิ​
7. ลบ series และ categories เริ่มต้น​
8. เพิ่ม categories ใหม่​
9. เพิ่ม series ใหม่​
10. ตั้งค่า series ใหม่ให้แสดงค่า​

เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    # เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # ตั้งค่าชื่อแผนภูมิ.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # ตั้งดัชนีของ worksheet ข้อมูลแผนภูมิ.
    default_worksheet_index = 0

    # รับ workbook ของข้อมูลแผนภูมิ.
    workbook = chart.getChartData().getChartDataWorkbook()

    # ลบ series และ categories เริ่มต้น.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # เพิ่ม categories ใหม่.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # เพิ่ม series ใหม่.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # เติมข้อมูลให้ series.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # ตั้งค่า series ใหม่ให้แสดงค่า.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**รูปแบบ 'Pie of Pie' และ 'Bar of Pie' ได้รับการสนับสนุนหรือไม่?**

ใช่ ไลบรารีนี้ [รองรับ](https://reference.aspose.com/slides/th/python-java/aspose.slides/charttype/) การพล็อตที่สองสำหรับแผนภูมิวงกลม รวมถึงประเภท 'Pie of Pie' และ 'Bar of Pie' ด้วย

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ใช่ คุณสามารถ [ส่งออกแผนภูมิเป็นภาพ](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) (เช่น PNG) ได้โดยไม่ต้องส่งออกงานนำเสนอทั้งหมด