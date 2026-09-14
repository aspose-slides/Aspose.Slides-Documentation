---
title: บันทึกงานนำเสนอในโหมดอ่านอย่างเดียวโดยใช้ Python
linktitle: งานนำเสนอแบบอ่านอย่างเดียว
type: docs
weight: 30
url: /th/python-java/read-only-presentation/
keywords:
- อ่านอย่างเดียว
- ปกป้องงานนำเสนอ
- ป้องกันการแก้ไข
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "โหลดและบันทึกไฟล์ PowerPoint (PPT, PPTX) ในโหมดอ่านอย่างเดียวด้วย Aspose.Slides สำหรับ Python ผ่าน Java โดยให้การพรีวิวสไลด์ที่แม่นยำโดยไม่ทำการเปลี่ยนแปลงงานนำเสนอของคุณ"
---
## **บทนำ**

ใน PowerPoint 2019, Microsoft ได้นำเสนอการตั้งค่า **Always Open Read-Only** เป็นหนึ่งในตัวเลือกที่ผู้ใช้สามารถใช้เพื่อปกป้องงานนำเสนอของตน คุณอาจต้องการใช้การตั้งค่า Read-Only นี้เพื่อปกป้องงานนำเสนอเมื่อ:
- คุณต้องการป้องกันการแก้ไขโดยบังเอิญและเก็บรักษาเนื้อหาของงานนำเสนอให้ปลอดภัย
- คุณต้องการแจ้งให้ผู้รับรู้ว่างานนำเสนอที่คุณให้เป็นเวอร์ชันสุดท้าย

หลังจากที่คุณเลือกตัวเลือก **Always Open Read-Only** สำหรับงานนำเสนอ เมื่อผู้ใช้เปิดงานนำเสนอ พวกเขาจะเห็นคำแนะนำ **Read-Only** และอาจเห็นข้อความในรูปแบบนี้: *เพื่อป้องกันการเปลี่ยนแปลงโดยบังเอิญ ผู้เขียนได้ตั้งค่าไฟล์นี้ให้เปิดเป็น read-only.*

คำแนะนำ Read-Only เป็นการขับถ่ายที่เรียบง่ายแต่มีประสิทธิภาพ ซึ่งทำให้ผู้ใช้ไม่อยากแก้ไขเพราะต้องทำขั้นตอนเพื่อเอาออกก่อนจึงจะสามารถแก้ไขงานนำเสนอได้ หากคุณไม่ต้องการให้ผู้ใช้ทำการเปลี่ยนแปลงงานนำเสนอและต้องการแจ้งให้พวกเขาทราบอย่างสุภาพ คำแนะนำ Read-Only อาจเป็นตัวเลือกที่ดีสำหรับคุณ

> หากงานนำเสนอที่มีการป้องกัน **Read-Only** ถูกเปิดในแอปพลิเคชัน Microsoft PowerPoint รุ่นเก่าที่ไม่ได้รองรับฟังก์ชันที่เพิ่งแนะนำนี้ คำแนะนำ **Read-Only** จะถูกละเลย (งานนำเสนอจะเปิดตามปกติ)

## **ใช้โหมดอ่านอย่างเดียว**

Aspose.Slides สำหรับ Python ผ่าน Java ให้คุณตั้งค่างานนำเสนอเป็น **Read-Only** ซึ่งหมายความว่าผู้ใช้ (หลังจากเปิดงานนำเสนอ) จะเห็นคำแนะนำ **Read-Only** โค้ดตัวอย่างนี้แสดงวิธีตั้งค่างานนำเสนอเป็น **Read-Only** ใน Python ด้วย Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
คำแนะนำ **Read-Only** มีจุดประสงค์เพื่อไม่ให้ผู้ใช้แก้ไขหรือป้องกันการเปลี่ยนแปลงโดยบังเอิญในงานนำเสนอ PowerPoint หากบุคคลที่มีความมุ่งมั่น—ซึ่งรู้ว่ากำลังทำอะไร—ตัดสินใจจะแก้งานนำเสนอของคุณ พวกเขาสามารถเอาการตั้งค่า Read-Only ออกได้อย่างง่ายดาย หากคุณต้องการป้องกันการแก้ไขโดยไม่ได้รับอนุญาตอย่างจริงจัง คุณควรใช้ [more stringent protections that involve encryption and passwords](/slides/th/python-java/password-protected-presentation/) 
{{% /alert %}} 

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่าง 'Read-Only recommended' กับการป้องกันด้วยรหัสผ่านเต็มคืออะไร?**  
'Read-Only recommended' จะเพียงแสดงคำแนะนำให้เปิดไฟล์ในโหมดอ่านอย่างเดียวและง่ายต่อการข้ามผ่าน. [Password protection](/slides/th/python-java/password-protected-presentation/) จะจำกัดการเปิดหรือการแก้ไขอย่างแท้จริงและเหมาะเมื่อคุณต้องการการควบคุมความปลอดภัยที่แท้จริง.

**สามารถใช้ 'Read-Only recommended' ร่วมกับ watermark เพื่อยับยั้งการแก้ไขเพิ่มเติมได้หรือไม่?**  
ใช่. คำแนะนำนี้สามารถจับคู่กับ [watermarks](/slides/th/python-java/watermark/) เพื่อเป็นการขับถ่ายด้วยภาพ; พวกมันเป็นกลไกแยกต่างหากและทำงานร่วมกันได้ดี.

**แมโครหรือเครื่องมือภายนอกยังสามารถแก้ไขไฟล์ได้เมื่อเปิดใช้งานคำแนะนำหรือไม่?**  
ใช่. คำแนะนำนี้ไม่บล็อกการเปลี่ยนแปลงโดยโปรแกรม. เพื่อป้องกันการแก้ไขอัตโนมัติ ใช้ [passwords and encryption](/slides/th/python-java/password-protected-presentation/).

**คำแนะนำ 'Read-Only recommended' มีความสัมพันธ์อย่างไรกับเมธอด [isEncrypted](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#isEncrypted) และ [isWriteProtected](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**  
พวกมันเป็นสัญญาณที่แตกต่างกัน. 'Read-Only recommended' เป็นการแจ้งเตือนที่อ่อนและเป็นออปชัน; [isWriteProtected](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#isWriteProtected) และ [isEncrypted](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#isEncrypted) แสดงข้อจำกัดการเขียนหรือการอ่านจริงที่ขึ้นกับรหัสผ่านหรือการเข้ารหัส.