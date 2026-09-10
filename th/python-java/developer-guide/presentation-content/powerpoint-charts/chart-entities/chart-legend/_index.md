---
title: ปรับแต่งคำอธิบายกราฟในงานนำเสนอด้วย Python
linktitle: คำอธิบายกราฟ
type: docs
url: /th/python-java/chart-legend/
keywords:
- คำอธิบายกราฟ
- ตำแหน่งคำอธิบาย
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ปรับแต่งคำอธิบายกราฟด้วย Aspose.Slides for Python via Java เพื่อปรับปรุงงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำอธิบายที่กำหนดเอง"
---
## **ภาพรวม**

Aspose.Slides มีตัวเลือกสำหรับการปรับแต่งคำอธิบายกราฟในงานนำเสนอ PowerPoint บทความนี้แสดงวิธีการกำหนดตำแหน่งและขนาดของคำอธิบาย, ตั้งขนาดฟอนต์สำหรับคำอธิบายทั้งหมด, และใช้การจัดรูปแบบกับรายการคำอธิบายเดี่ยว.

มันยังครอบคลุมพฤติกรรมที่เกี่ยวข้องหลายอย่างใน FAQ รวมถึงการใช้โหมดไม่ซ้อนทับเพื่อให้พื้นที่แผนภูมิทำให้มีที่ว่างสำหรับคำอธิบาย, การอนุญาตให้ป้ายคำอธิบายยาวห่อหุ้มหรือใช้การขึ้นบรรทัดใหม่, และการให้การจัดรูปแบบของคำอธิบายสืบทอดจากธีมของงานนำเสนอเมื่อไม่ได้กำหนดค่าข้อความและการเติมสีอย่างชัดเจน.

## **การกำหนดตำแหน่งคำอธิบาย**

เพื่อกำหนดคุณสมบัติของคำอธิบาย, ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. รับอ้างอิงไปยังสไลด์
1. เพิ่มชาร์ตลงในสไลด์
1. ตั้งค่าคุณสมบัติของคำอธิบาย
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ตัวอย่างต่อไปนี้ตั้งค่าตำแหน่งและขนาดของคำอธิบายชาร์ต.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# สร้างงานนำเสนอเปล่า.
presentation = Presentation()
try:
    # รับอ้างอิงถึงสไลด์.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มแผนภูมิคอลัมน์แบบกลุ่มลงในสไลด์.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # ตั้งค่าคุณสมบัติของคำอธิบาย.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าขนาดฟอนต์ของคำอธิบาย**

Aspose.Slides for Python via Java ให้คุณตั้งค่าขนาดฟอนต์ของคำอธิบาย ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. สร้างชาร์ตค่าเริ่มต้น
1. ตั้งค่าขนาดฟอนต์
1. ตั้งค่าค่าต่ำสุดของแกน
1. ตั้งค่าสูงสุดของแกน
1. บันทึกงานนำเสนอลงดิสก์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# สร้างงานนำเสนอเปล่า.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าขนาดฟอนต์ของรายการคำอธิบายเดี่ยว**

Aspose.Slides for Python via Java ให้คุณตั้งค่าขนาดฟอนต์ของรายการคำอธิบายแต่ละรายการ ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. สร้างชาร์ตค่าเริ่มต้น
1. เข้าถึงรายการคำอธิบาย
1. ตั้งค่าขนาดฟอนต์
1. บันทึกงานนำเสนอลงดิสก์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# สร้างงานนำเสนอเปล่า.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถเปิดใช้คำอธิบายเพื่อให้แผนภูมืจัดสรรพื้นที่ให้โดยอัตโนมัติแทนการซ้อนทับหรือไม่?**

ใช่ ใช้ [setOverlay](https://reference.aspose.com/slides/th/python-java/aspose.slides/legend/#setOverlay) พร้อมค่า `False` เพื่อเปิดโหมดไม่ซ้อนทับ; ในกรณีนี้พื้นที่แผนภูมิจะหดตัวเพื่อรองรับคำอธิบาย.

**ฉันสามารถทำให้ป้ายคำอธิบายหลายบรรทัดได้หรือไม่?**

ใช่ ป้ายชื่อที่ยาวจะห่ออัตโนมัติเมื่อพื้นที่ไม่พอ; การขึ้นบรรทัดใหม่โดยบังคับรองรับผ่านอักขระ newline ในชื่อซีรีส์.

**ฉันจะทำให้คำอธิบายใช้โทนสีของธีมงานนำเสนออย่างไร?**

ไม่กำหนดสี, การเติม, หรือฟอนต์อย่างชัดเจนสำหรับคำอธิบายหรือข้อความของมัน พวกมันจะสืบทอดจากธีมและอัปเดตอย่างถูกต้องเมื่อการออกแบบเปลี่ยนแปลง.