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
description: "สร้างงานนำเสนอใน Python ผ่าน Java ด้วย Aspose.Slides—ผลิตไฟล์ PPT, PPTX และ ODP, ใช้ประโยชน์จากการสนับสนุน OpenDocument, และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอด้วย Aspose.Slides for Python via Java, เพิ่มรูปร่างพร้อมข้อความลงในสไลด์แรก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX. คำถามที่พบบ่อยครอบคลุมรูปแบบผลลัพธ์, แม่แบบ, ขนาดสไลด์, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้ลิขสิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA.

## **สร้างงานนำเสนอ**

การสร้างไฟล์ PowerPoint จากศูนย์ใน Aspose.Slides for Python via Java ทำได้ง่ายเหมือนการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) . ตัวสร้างจะให้ชุดสไลด์เปล่าที่มีสไลด์เดียวโดยอัตโนมัติ, ให้คุณมีผืนทำงานทันทีสำหรับรูปร่าง, ข้อความ, แผนภูมิ, หรือเนื้อหาอื่น ๆ ที่แอปพลิเคชันของคุณต้องการ. หลังจากที่คุณแก้ไขสไลด์นั้น—หรือเพิ่มสไลด์ใหม่—คุณสามารถบันทึกผลลัพธ์เป็น PPTX, PPT รุ่นเก่า, หรือแม้แต่รูปแบบ OpenDocument. ตัวอย่างโค้ดสั้นด้านล่างแสดงขั้นตอนการทำงานนี้โดยการเพิ่มรูปร่างง่าย ๆ ลงบนสไลด์แรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) .
1. รับสไลด์แรกโดยอ้างอิงดัชนีของมัน .
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ชนิด [ShapeType.Cloud](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#Cloud) โดยใช้ [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape) .
1. ตั้งค่าข้อความของรูปร่างโดยใช้ [TextFrame.setText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#setText) .
1. บันทึกงานนำเสนอโดยใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx) .

ตัวอย่างต่อไปนี้ต้องการ Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้. จะเริ่ม JVM หากยังไม่ได้ทำงาน, เพิ่มรูปร่างเมฆลงบนสไลด์แรก, และบันทึกงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างงานนำเสนอด้วยสไลด์เปล่า 1 แผ่น.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างเมฆและตั้งค่าข้อความ.
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
คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/python-java/save-presentation/), และส่งออกเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/python-java/convert-powerpoint-to-xps/), [HTML](/slides/th/python-java/convert-powerpoint-to-html/), [SVG](/slides/th/python-java/render-slide-as-svg/), และ [images](/slides/th/python-java/convert-powerpoint-to-png/), และอื่น ๆ.

**ฉันสามารถเริ่มจากแม่แบบ (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**  
ใช่. โหลดแม่แบบและบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบที่คล้ายกัน [are supported](/slides/th/python-java/supported-file-formats/).

**ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างงานนำเสนอได้อย่างไร?**  
ตั้งค่า [slide size](/slides/th/python-java/slide-size/) (รวมถึงพรีเซ็ตเช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีที่เนื้อหาควรสเกล.

**หน่วยที่ใช้วัดขนาดและพิกัดคืออะไร?**  
เป็นหน่วยจุด: 1 นิ้วเท่ากับ 72 หน่วย.

**ฉันจะจัดการงานนำเสนอขนาดใหญ่ (ที่มีไฟล์สื่อหลายไฟล์) เพื่อลดการใช้หน่วยความจำได้อย่างไร?**  
ใช้ [BLOB management strategies](/slides/th/python-java/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และควรเลือกเวิร์กโฟลว์แบบไฟล์เป็นหลักแทนการสตรีมทั้งหมดในหน่วยความจำ.

**ฉันสามารถสร้าง/บันทึกงานนำเสนอได้แบบขนานหรือไม่?**  
คุณไม่สามารถทำงานกับอินสแตนซ์ [Presentation]เดียวกันจาก [multiple threads](/slides/th/python-java/multithreading/) ได้. ให้รันอินสแตนซ์แยกจากกันสำหรับแต่ละเธรดหรือกระบวนการ.

**ฉันจะลบลายน้ำและข้อจำกัดของรุ่นทดลองได้อย่างไร?**  
[Apply a license](/slides/th/python-java/licensing/) ครั้งเดียวต่อกระบวนการ. XML ของลิขสิทธิ์ต้องไม่ถูกแก้ไข, และการตั้งค่าลิขสิทธิ์ควรทำให้สอดคล้องกันหากมีหลายเธรด.

**ฉันสามารถลงลายเซ็นดิจิทัลใน PPTX ที่สร้างได้หรือไม่?**  
ใช่. [Digital signatures](/slides/th/python-java/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) ได้รับการสนับสนุนสำหรับงานนำเสนอ.

**การแมโคร (VBA) สนับสนุนในงานนำเสนอที่สร้างหรือไม่?**  
ใช่. คุณสามารถ [create/edit VBA projects](/slides/th/python-java/presentation-via-vba/) และบันทึกไฟล์ที่มีแมโครเช่น PPTM/PPSM.