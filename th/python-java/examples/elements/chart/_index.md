---
title: แผนภูมิ
type: docs
weight: 60
url: /th/python-java/examples/elements/chart/
keywords:
- แผนภูมิ
- เพิ่มแผนภูมิ
- เข้าถึงแผนภูมิ
- ลบแผนภูมิ
- อัปเดตแผนภูมิ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้าง, เข้าถึง, ลบ และอัปเดตแผนภูมิในพรีเซนเทชัน PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
บทความนี้สาธิตวิธีการเพิ่ม, เข้าถึง, ลบ และอัปเดตแผนภูมิในพรีเซนเทชันโดยใช้ **Aspose.Slides for Python via Java**.

ติดตั้งแพคเกจตามที่อธิบายใน [Installation](/slides/th/python-java/installation/). ตัวอย่างแต่ละตัวจะเรียกใช้ `asposeslides` ก่อนเริ่ม JVM แล้วจึงเรียกใช้ API หลังจาก JVM ทำงานแล้ว. รันตัวอย่างการเพิ่มก่อนเพื่อสร้างไฟล์ `chart.pptx` สำหรับตัวอย่างที่เหลือ.

## **Add a Chart**
เพิ่มแผนภูมิแบบพื้นที่ลงในสไลด์แรกและบันทึกการพรีเซนเทชัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มแผนภูมิแบบพื้นที่ลงในสไลด์แรก.
    chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300)

    presentation.save("chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Access a Chart**
ค้นหาแผนภูมิแรกในคอลเลกชันรูปร่างบนสไลด์แรก

```python
import jpime
import asposeslides

if not jpime.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # เข้าถึงแผนภูมิแรกบนสไลด์.
    first_chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            first_chart = shape
            break

    if first_chart is None:
        print("The first slide contains no charts.")
finally:
    presentation.dispose()
```

## **Remove a Chart**
ลบแผนภูมิแรกจากสไลด์และบันทึกการพรีเซนเทชันที่แก้ไขแล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # ค้นหาและลบแผนภูมิแรกบนสไลด์.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        slide.getShapes().remove(chart)
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Update Chart Data**
แสดงหัวเรื่องของแผนภูมิ, เปลี่ยนข้อความของมัน, และบันทึกการพรีเซนเทชันที่อัปเดตแล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # ค้นหาแผนภูมิแรกบนสไลด์.
    chart = None
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is not None:
        # แสดงหัวเรื่องของแผนภูมิและเปลี่ยนข้อความของมัน.
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Sales Report")
    else:
        print("The first slide contains no charts.")

    presentation.save("chart_updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```