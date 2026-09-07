---
title: แปลง PPTX เป็น PPT ใน Python
linktitle: PPTX เป็น PPT
type: docs
weight: 21
url: /th/python-java/convert-pptx-to-ppt/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPTX
- PPTX เป็น PPT
- บันทึก PPTX เป็น PPT
- ส่งออก PPTX ไปเป็น PPT
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลง PPTX เป็นรูปแบบ PPT แบบเก่าใน Python ด้วย Aspose.Slides for Python via Java. รวมตัวอย่างโค้ดและหมายเหตุเกี่ยวกับความเข้ากันได้และไฟล์ที่ป้องกัน."
---
## **ภาพรวม**

Aspose.Slides for Python via Java ช่วยให้คุณแปลงงานนำเสนอ PPTX ไปเป็นรูปแบบ PPT แบบเก่าที่ใช้โดย PowerPoint 97–2003 โดยไม่ต้องติดตั้ง Microsoft PowerPoint โหลดไฟล์ PPTX แล้วบันทึกด้วยรูปแบบเอาต์พุต PPT ตามที่แสดงด้านล่าง

## **แปลง PPTX เป็น PPT**

โหลดไฟล์ต้นทางด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) จากนั้นเรียกใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อมเส้นทางเอาต์พุตและ [SaveFormat.Ppt](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Ppt).

ตัวอย่างต่อไปนี้จะเริ่มเครื่องเสมือน Java หากจำเป็นและแปลง `template.pptx` เป็น `output.ppt` โดยใช้ตัวเลือกค่าเริ่มต้น เปลี่ยนเส้นทางเป็นชื่อไฟล์ของคุณเอง บล็อก `finally` จะปล่อยทรัพยากรของการนำเสนอแม้การบันทึกจะล้มเหลว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# โหลดการนำเสนอ PPTX.
presentation = Presentation("template.pptx")
try:
    # บันทึกการนำเสนอในรูปแบบ PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

อาร์กิวเมนต์ [SaveFormat.Ppt](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Ppt) จะเลือกรูปแบบเอาต์พุต; การเปลี่ยนนามสกุลไฟล์เพียงอย่างเดียวไม่ทำให้การนำเสนอแปลงเป็นรูปแบบอื่น จงเก็บไฟล์ PPTX ต้นฉบับไว้เพื่อให้คุณสามารถกลับไปใช้ได้ หากคุณลักษณะใหม่ไม่มีเทียบเท่าใน PPT

## **แปลง PPTX เป็นรูปแบบอื่น**

Aspose.Slides ยังสนับสนุนรูปแบบเอาต์พุตอื่น ๆ ดูบทความที่เกี่ยวข้องสำหรับตัวเลือกและตัวอย่างเฉพาะรูปแบบ:

- [Convert PowerPoint to PDF in Python](/slides/th/python-java/convert-powerpoint-to-pdf/)
- [Convert PowerPoint to XPS in Python](/slides/th/python-java/convert-powerpoint-to-xps/)
- [Convert PowerPoint to HTML in Python](/slides/th/python-java/convert-powerpoint-to-html/)
- [Save Presentations as ODP in Python](/slides/th/python-java/save-presentation/)
- [Convert PowerPoint to PNG in Python](/slides/th/python-java/convert-powerpoint-to-png/)

## **คำถามที่พบบ่อย**

**เอฟเฟกต์และคุณลักษณะทั้งหมดของ PPTX จะคงอยู่หลังการแปลงเป็น PPT หรือไม่?**

ไม่เสมอไป รูปแบบ PPT แบบเก่าไม่รองรับคุณลักษณะทุกอย่างที่มีใน PPTX บางเอฟเฟกต์ วัตถุ หรือพฤติกรรมอาจถูกเรียบง่ายลงหรือแสดงต่างออกไป ตรวจสอบการนำเสนอที่แปลงแล้วในโปรแกรมดูที่ต้องการ โดยเฉพาะเมื่อมีคุณลักษณะ PowerPoint รุ่นใหม่

**ฉันสามารถแปลงเฉพาะสไลด์ที่เลือกเป็น PPT ได้หรือไม่?**

การบันทึกเป็น PPT จะเขียนทั้งการนำเสนอทั้งหมด เพื่อแปลงสไลด์ที่เลือก ให้สร้างการนำเสนอใหม่ ลบสไลด์เปล่าแรกออก โคลนสไลด์ที่ต้องการเข้าไป แล้วบันทึกเป็น PPT ดูที่ [Clone Slides in Python](/slides/th/python-java/clone-slides/).

**ฉันสามารถแปลงไฟล์ PPTX ที่มีการป้องกันด้วยรหัสผ่านได้หรือไม่?**

ได้ ถ้าคุณระบุรหัสผ่านที่ถูกต้องเมื่อโหลดการนำเสนอต้นทาง คุณยังสามารถกำหนดการป้องกันสำหรับไฟล์เอาต์พุตได้ ดูที่ [Password-Protected Presentations](/slides/th/python-java/password-protected-presentation/).