---
title: ปรับแต่งตารางข้อมูลของแผนภูมิในงานนำเสนอโดยใช้ Python
linktitle: ตารางข้อมูล
type: docs
url: /th/python-java/chart-data-table/
keywords:
- ข้อมูลแผนภูมิ
- ตารางข้อมูล
- คุณสมบัติฟอนต์
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ปรับแต่งตารางข้อมูลของแผนภูมิใน Python สำหรับไฟล์ PPT และ PPTX ด้วย Aspose.Slides for Python via Java เพื่อเพิ่มประสิทธิภาพและความน่าสนใจในงานนำเสนอ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับตารางข้อมูลของแผนภูมิใน Aspose.Slides แสดงวิธีการแสดงตารางข้อมูลสำหรับแผนภูมิและปรับรูปแบบข้อความโดยตั้งค่าคุณสมบัติของฟอนต์ เช่น รูปแบบตัวหนาและความสูงของฟอนต์ ตัวอย่างนี้สาธิตการสร้างงานนำเสนอ, เพิ่มแผนภูมิ, เปิดใช้งานตารางข้อมูลของแผนภูมิ, ใช้การตั้งค่าฟอนต์, และบันทึกงานนำเสนอที่อัปเดต

นอกจากนี้ยังมีคำตอบสั้น ๆ สำหรับคำถามทั่วไปเกี่ยวกับการแสดงคีย์คำอธิบายในตารางข้อมูลของแผนภูมิ, การรักษาตารางข้อมูลระหว่างการส่งออก, การทำงานกับแผนภูมิที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่แล้ว, และการระบุแผนภูมิที่เปิดใช้งานตารางข้อมูล

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับตารางข้อมูลของแผนภูมิ**

Aspose.Slides for Python via Java ให้คุณแสดงตารางข้อมูลของแผนภูมิและเปลี่ยนคุณสมบัติฟอนต์ของข้อความได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. เพิ่มแผนภูมิลงในสไลด์
1. แสดงตารางข้อมูลของแผนภูมิ
1. ตั้งค่ารูปแบบตัวหนาและความสูงของฟอนต์สำหรับข้อความในตารางข้อมูล
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่างต่อไปนี้สาธิตขั้นตอนเหล่านี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# สร้างงานนำเสนอเปล่า.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถแสดงคีย์คำอธิบายขนาดเล็กข้างค่าต่าง ๆ ในตารางข้อมูลของแผนภูมิได้หรือไม่?**

ใช่ ตารางข้อมูลรองรับ [คีย์คำอธิบาย](https://reference.aspose.com/slides/th/python-java/aspose.slides/datatable/#setShowLegendKey) และคุณสามารถเปิดหรือปิดได้

**ตารางข้อมูลจะถูกเก็บรักษาไว้เมื่อส่งออกงานนำเสนอเป็น PDF, HTML หรือรูปภาพหรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์แผนภูมิเป็นส่วนหนึ่งของสไลด์ ดังนั้นไฟล์ที่ส่งออกรูปแบบ [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/)/[HTML](/slides/th/python-java/convert-powerpoint-to-html/)/[image](/slides/th/python-java/convert-powerpoint-to-png/) จะรวมแผนภูมิพร้อมตารางข้อมูลด้วย

**ตารางข้อมูลรองรับสำหรับแผนภูมิที่มาจากไฟล์เทมเพลตหรือไม่?**

ใช่ สำหรับแผนภูมิใดก็ได้ที่โหลดจากงานนำเสนอหรือเทมเพลตที่มีอยู่แล้ว คุณสามารถตรวจสอบและเปลี่ยนแปลงว่าตารางข้อมูล [ถูกแสดง](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#hasDataTable) หรือไม่โดยใช้คุณสมบัติของแผนภูมิ

**ฉันจะค้นหาอย่างรวดเร็วว่าแผนภูมิใดในไฟล์มีตารางข้อมูลเปิดใช้งานอยู่บ้าง?**

ตรวจสอบคุณสมบัติของแต่ละแผนภูมิที่บ่งบอกว่าตารางข้อมูล [ถูกแสดง](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/#hasDataTable) หรือไม่ และวนซ้ำผ่านสไลด์เพื่อระบุแผนภูมิที่เปิดใช้งานตารางข้อมูล