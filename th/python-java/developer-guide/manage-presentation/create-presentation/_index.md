---
title: สร้างงานนำเสนอใน Python ผ่าน Java
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/python-java/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างงานนำเสนอใน Python ผ่าน Java ด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument, และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอด้วย Aspose.Slides for Python via Java เพิ่มรูปทรงพร้อมข้อความลงในสไลด์แรก และบันทึกผลลัพธ์เป็นไฟล์ PPTX คำถามที่พบบ่อยครอบคลุมรูปแบบการส่งออก เท็มเพลต ขนาดสไลด์ การใช้หน่วยความจำ การทำงานหลายเธรด การให้ลิขสิทธิ์ ลายเซ็นดิจิทัล และการสนับสนุน VBA

## **สร้างงานนำเสนอ**

การสร้างไฟล์ PowerPoint ตั้งแต่ต้นใน Aspose.Slides for Python via Java ทำได้ง่ายเช่นการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ตัวคอนสตรัคเตอร์จะสร้างสไลด์เปล่าแบบหนึ่งสไลด์ให้โดยอัตโนมัติ ทำให้คุณมีผืนผ้าใบพร้อมสำหรับวางรูปทรง ข้อความ แผนภูมิ หรือเนื้อหาอื่น ๆ ที่แอปพลิเคชันของคุณต้องการ เมื่อตั้งค่าหรือเพิ่มสไลด์ใหม่แล้ว คุณสามารถบันทึกผลลัพธ์เป็น PPTX, PPT แบบเก่า หรือแม้กระทั่งรูปแบบ OpenDocument ตัวอย่างโค้ดสั้นด้านล่างแสดงกระบวนการนี้โดยการเพิ่มรูปทรงง่าย ๆ ลงในสไลด์แรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. ดึงสไลด์แรกตามตำแหน่งดัชนี  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ชนิด [ShapeType.Cloud](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#Cloud) ด้วยเมธอด [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape)  
4. ตั้งค่าข้อความของรูปทรงด้วยเมธอด [TextFrame.setText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#setText)  
5. บันทึกงานนำเสนอด้วยเมธอด [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อมระบุ [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx)

ตัวอย่างต่อไปนี้ต้องใช้ Aspose.Slides for Python via Java และรันไทม์ Java ที่เข้ากันได้ จะทำการเริ่ม JVM หากยังไม่ได้เปิดใช้งาน เพิ่มรูปทรงเมฆลงในสไลด์แรก และบันทึกงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างงานนำเสนอพร้อมสไลด์เปล่า 1 แผ่น
presentation = Presentation()
try:
    # ดึงสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปทรงเมฆและตั้งค่าข้อความของมัน.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์:

![การนำเสนอใหม่](new_presentation.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT และ ODP](/slides/th/python-java/save-presentation/) และส่งออกเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/python-java/convert-powerpoint-to-xps/), [HTML](/slides/th/python-java/convert-powerpoint-to-html/), [SVG](/slides/th/python-java/render-slide-as-svg/) และ [ภาพ](/slides/th/python-java/convert-powerpoint-to-png/) เป็นต้น

**ฉันสามารถเริ่มจากเท็มเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ธรรมดาได้หรือไม่?**

ได้ โหลดเท็มเพลตแล้วบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM และรูปแบบคล้ายกัน [ได้รับการสนับสนุน](/slides/th/python-java/supported-file-formats/)

**ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานนำเสนออย่างไร?**

ตั้งค่า [ขนาดสไลด์](/slides/th/python-java/slide-size/) (รวมถึงค่าเตรียมไว้ล่วงหน้าเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการสเกลเนื้อหา

**หน่วยที่ใช้วัดขนาดและพิกัดคืออะไร?**

ใช้หน่วยจุด: 1 นิ้วเท่ากับ 72 หน่วย

**ฉันจะจัดการงานนำเสนอขนาดใหญ่ (มีไฟล์สื่อจำนวนมาก) เพื่อลดการใช้หน่วยความจำอย่างไร?**

ใช้ [กลยุทธ์การจัดการ BLOB](/slides/th/python-java/manage-blob/), จำกัดการเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว และเลือกเวิร์กโฟลว์แบบไฟล์เป็นหลักแทนการสตรีมในหน่วยความจำเต็มรูปแบบ

**ฉันสามารถสร้าง/บันทึกงานนำเสนอแบบขนานได้หรือไม่?**

คุณไม่สามารถทำงานกับอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เดียวจาก [หลายเธรด](/slides/th/python-java/multithreading/) ได้ ควรเรียกใช้อินสแตนซ์แยกกันสำหรับแต่ละเธรดหรือโพรเซส

**ฉันจะลบลายน้ำทดลองและข้อจำกัดต่าง ๆ ได้อย่างไร?**

[ใช้ใบอนุญาต](/slides/th/python-java/licensing/) หนึ่งครั้งต่อโปรเซส ไฟล์ XML ใบอนุญาตต้องไม่ถูกแก้ไข และการตั้งค่าใบอนุญาตควรทำให้สอดคล้องกันหากใช้หลายเธรด

**ฉันสามารถเซ็นดิจิทัลไฟล์ PPTX ที่สร้างได้หรือไม่?**

ได้ การ [เซ็นดิจิทัล](/slides/th/python-java/digital-signature-in-powerpoint/) (การเพิ่มและตรวจสอบ) ได้รับการสนับสนุนสำหรับงานนำเสนอ

**แมโคร (VBA) ได้รับการสนับสนุนในงานนำเสนอที่สร้างหรือไม่?**

ได้ คุณสามารถ [สร้าง/แก้ไขโครงการ VBA](/slides/th/python-java/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานแมโคร เช่น PPTM/PPSM