---
title: แปลง ODP เป็น PPTX ด้วย Python
linktitle: ODP เป็น PPTX
type: docs
weight: 10
url: /th/python-java/convert-odp-to-pptx/
keywords:
- แปลง OpenDocument
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง ODP
- OpenDocument ไปยัง PPTX
- ODP ไปยัง PPTX
- บันทึก ODP เป็น PPTX
- ส่งออก ODP ไปยัง PPTX
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงการนำเสนอ ODP ไปเป็น PPTX ด้วย Aspose.Slides for Python via Java. ใช้ตัวอย่าง Python ครบชุดโดยไม่ต้องติดตั้ง PowerPoint หรือ LibreOffice."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงการนำเสนอ OpenDocument (ODP) ไปเป็นรูปแบบ PowerPoint (PPTX) โดยใช้ Aspose.Slides for Python via Java.

## **แปลง ODP เป็น PPTX**

คลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) สามารถโหลดไฟล์ ODP ได้โดยตรง บันทึกการนำเสนอที่โหลดแล้วเป็นรูปแบบ PPTX โดยใช้ [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/).

ทำตาม [คำแนะนำการติดตั้ง](/slides/th/python-java/installation/) ก่อนเรียกใช้ตัวอย่าง วางไฟล์การนำเสนอ ODP ชื่อ `AccessOpenDoc.odp` ไว้ที่ไดเรกทอรีทำงาน โค้ดต่อไปนี้จะเริ่ม JVM หากจำเป็น, เปิดไฟล์ ODP, และบันทึกเป็น `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # บันทึกการนำเสนอ ODP ในรูปแบบ PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตัวอย่างสด**

ลองใช้แอปเว็บ [การแปลง Aspose.Slides](https://products.aspose.app/slides/th/conversion/) เพื่อดูการแปลง ODP เป็น PPTX ที่ขับเคลื่อนโดย Aspose.Slides.

## **คำถามที่พบบ่อย**

**จำเป็นต้องติดตั้ง Microsoft PowerPoint หรือ LibreOffice เพื่อแปลง ODP เป็น PPTX หรือไม่?**

ไม่. Aspose.Slides for Python via Java สามารถอ่านและเขียนไฟล์นำเสนอได้โดยไม่ต้องใช้แอปพลิเคชันใด ๆ คุณต้องมีแพ็กเกจ Python และ Java runtime ที่เข้ากันได้

**สไลด์แม่แบบ, รูปแบบเลย์เอาต์ และธีมที่ใช้จะคงอยู่ระหว่างการแปลงหรือไม่?**

Aspose.Slides ทำการแมปโครงสร้างและการจัดรูปแบบของการนำเสนอต้นฉบับไปยัง PPTX อย่างไรก็ตาม ODP และ PPTX รองรับคุณลักษณะต่างกัน ดังนั้นบางองค์ประกอบอาจดูแตกต่างหลังการแปลง ให้แน่ใจว่าฟอนต์ที่จำเป็นพร้อมใช้งานและตรวจสอบการนำเสนอที่มีการจัดรูปแบบซับซ้อน ดู [การแปลง OpenDocument](/slides/th/python-java/convert-openoffice-odp/) สำหรับข้อพิจารณาความเข้ากันได้.

**ฉันสามารถแปลงไฟล์ ODP ที่ป้องกันด้วยรหัสผ่านได้หรือไม่?**

ใช้เมื่อคุณระบุรหัสผ่านที่จำเป็นสำหรับเปิดไฟล์ ดู [การนำเสนอที่ป้องกันด้วยรหัสผ่าน](/slides/th/python-java/password-protected-presentation/) สำหรับรายละเอียดเกี่ยวกับการโหลดไฟล์ที่ได้รับการป้องกันก่อนบันทึกเป็นรูปแบบอื่น.

**Aspose.Slides เหมาะสำหรับบริการแปลงบนคลาวด์หรือ REST หรือไม่?**

ใช่ คุณสามารถใช้ Aspose.Slides for Python via Java ในส่วน Backend ของคุณพร้อม Java runtime ที่ต้องการ สำหรับ REST API ดู [Aspose.Slides Cloud](https://products.aspose.cloud/slides/th/family/).