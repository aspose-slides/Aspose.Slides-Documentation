---
title: บันทึกงานนำเสนอในโหมดอ่านอย่างเดียวโดยใช้ Python
linktitle: งานนำเสนอแบบอ่านอย่างเดียว
type: docs
weight: 30
url: /th/python-net/read-only-presentation/
keywords:
- อ่านอย่างเดียว
- ปกป้องงานนำเสนอ
- ป้องกันการแก้ไข
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "โหลดและบันทึกไฟล์ PowerPoint (PPT, PPTX) ในโหมดอ่านอย่างเดียวด้วย Aspose.Slides for Python via .NET ให้การแสดงตัวอย่างสไลด์ที่แม่นยำโดยไม่เปลี่ยนแปลงงานนำเสนอของคุณ"
---
## **บทนำ**

ใน PowerPoint 2019, Microsoft ได้นำเสนอการตั้งค่า **Always Open Read-Only** เป็นหนึ่งในตัวเลือกที่ผู้ใช้สามารถใช้เพื่อปกป้องงานนำเสนอของตน คุณอาจต้องการใช้การตั้งค่า Read-Only นี้เพื่อปกป้องงานนำเสนอเมื่อ

- คุณต้องการป้องกันการแก้ไขโดยไม่ได้ตั้งใจและรักษาเนื้อหาของงานนำเสนอให้ปลอดภัย  
- คุณต้องการแจ้งให้ผู้คนทราบว่าฉบับที่คุณให้เป็นเวอร์ชันสุดท้าย  

หลังจากที่คุณเลือกตัวเลือก **Always Open Read-Only** สำหรับงานนำเสนอ เมื่อผู้ใช้เปิดงานนำเสนอ พวกเขาจะเห็นคำแนะนำ **Read-Only** และอาจเห็นข้อความในรูปแบบต่อไปนี้: *To prevent accidental changes, the author has set this file to open as read-only.*

คำแนะนำ Read-Only เป็นการเตือนที่ง่ายแต่มีประสิทธิภาพ ซึ่งทำให้ผู้ใช้ต้องทำขั้นตอนเพื่อเอาออกก่อนจึงจะสามารถแก้ไขงานนำเสนอได้ หากคุณไม่ต้องการให้ผู้ใช้ทำการเปลี่ยนแปลงงานนำเสนอและต้องการบอกพวกเขาแบบสุภาพ คำแนะนำ Read-Only อาจเป็นตัวเลือกที่ดีสำหรับคุณ

> หากงานนำเสนอที่มีการป้องกัน **Read-Only** ถูกเปิดในแอปพลิเคชัน Microsoft PowerPoint รุ่นเก่าที่ไม่รองรับฟังก์ชันที่เพิ่งแนะนำ คำแนะนำ **Read-Only** จะถูกละเลย (งานนำเสนอจะเปิดตามปกติ)

## **ใช้โหมด Read-Only**

Aspose.Slides for Python via .NET ช่วยให้คุณตั้งค่างานนำเสนอเป็น **Read-Only** ซึ่งหมายความว่าผู้ใช้ (หลังจากเปิดงานนำเสนอ) จะเห็นคำแนะนำ **Read-Only** ตัวอย่างโค้ดนี้แสดงวิธีตั้งค่างานนำเสนอเป็น **Read-Only** ใน Python โดยใช้ Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**หมายเหตุ**: คำแนะนำ **Read-Only** มีเจตนาเพียงเพื่อไม่ให้แก้ไขหรือป้องกันการเปลี่ยนแปลงโดยไม่ได้ตั้งใจในงานนำเสนอ PowerPoint หากบุคคลที่มีความรู้และตั้งใจแก้ไขงานของคุณ พวกเขายังสามารถลบการตั้งค่า Read-Only ได้อย่างง่ายดาย หากคุณต้องการป้องกันการแก้ไขโดยไม่ได้รับอนุญาตอย่างจริงจัง คุณควรใช้[การป้องกันที่เข้มงวดยิ่งขึ้นที่เกี่ยวข้องกับการเข้ารหัสและรหัสผ่าน](https://docs.aspose.com/slides/th/python-net/password-protected-presentation/)  

{{% /alert %}} 

## **คำถามที่พบบ่อย**

**การแนะนำ ‘Read-Only recommended’ แตกต่างจากการป้องกันด้วยรหัสผ่านเต็มรูปแบบอย่างไร?**

‘Read-Only recommended’ เพียงแสดงคำแนะนำให้เปิดไฟล์ในโหมดอ่านอย่างเดียวและสามารถข้ามได้ง่าย. **การป้องกันด้วยรหัสผ่าน**(/slides/th/python-net/password-protected-presentation/) จำกัดการเปิดหรือแก้ไขและเหมาะเมื่อคุณต้องการการควบคุมความปลอดภัยที่แท้จริง.

**สามารถผสาน ‘Read-Only recommended’ กับลายน้ำเพื่อยับยั้งการแก้ไขเพิ่มเติมได้หรือไม่?**

ได้. คำแนะนำสามารถจับคู่กับ[ลายน้ำ](/slides/th/python-net/watermark/)เป็นการเตือนเชิงภาพ; ทั้งสองเป็นกลไกแยกจากกันและทำงานร่วมกันได้ดี.

**แมโครหรือเครื่องมือนอกระบบยังสามารถแก้ไขไฟล์เมื่อเปิดใช้งานคำแนะนำได้หรือไม่?**

ได้. คำแนะนำไม่ได้บล็อกการเปลี่ยนแปลงโดยโปรแกรม. เพื่อป้องกันการแก้ไขอัตโนมัติให้ใช้[การป้องกันด้วยรหัสผ่านและการเข้ารหัส](/slides/th/python-net/password-protected-presentation/).

**‘Read-Only recommended’ เกี่ยวข้องกับฟลัก ‘is_encrypted’ และ ‘is_write_protected’ อย่างไร?**

พวกมันเป็นสัญญาณที่ต่างกัน. ‘Read-Only recommended’ เป็นการแจ้งเตือนแบบอ่อนนุ่มและเป็นทางเลือก; [is_write_protected](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/is_write_protected/) และ [is_encrypted](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/is_encrypted/) บ่งชี้ข้อจำกัดการเขียนหรือการอ่านจริงที่ขึ้นอยู่กับรหัสผ่านหรือการเข้ารหัส.