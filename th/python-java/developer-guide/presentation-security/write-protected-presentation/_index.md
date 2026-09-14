---
title: ป้องกันการเขียนการนำเสนอใน Python
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/python-java/write-protected-presentation/
keywords:
- การป้องกันการเขียน
- PowerPoint ป้องกันการเขียน
- รหัสผ่านสำหรับแก้ไข
- จำกัดการแก้ไขการนำเสนอ
- ลบการป้องกันการเขียน
- ตรวจสอบรหัสผ่านการแก้ไข
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "กำหนด, ตรวจจับ, ตรวจสอบ, และลบรหัสผ่านการป้องกันการเขียนในการนำเสนอ PowerPoint PPT และ PPTX โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **บทนำ**

รหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขการนำเสนอ แต่ไม่ได้เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูการนำเสนอที่มีการป้องกันการเขียนโดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน พวกเขาอาจสามารถแก้ไขเนื้อหาและบันทึกเป็นชื่ออื่นได้ ดังนั้นการป้องกันการเขียนไม่ควรถือเป็นกลไกความลับ

รหัสผ่านการเปิดทำหน้าที่ต่างกัน: มันเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา เพื่อเข้ารหัสการนำเสนอหรือยืนยันรหัสผ่านการเปิด ดู [Password-Protect Presentations](/slides/th/python-java/password-protected-presentation/)

ขั้นตอนในบทความนี้ใช้ได้กับการนำเสนอทั้งแบบ PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX；เมื่อบันทึกเป็น PPT ใช้นามสกุล `.ppt` และรูปแบบการบันทึก PPT ที่สอดคล้อง

## **กำหนดการป้องกันการเขียนให้กับการนำเสนอ**

ใช้ [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#setWriteProtection) เพื่อกำหนดรหัสผ่านสำหรับแก้ไขการนำเสนอ การบันทึกการนำเสนอจะคงการตั้งค่าการป้องกันไว้

ตัวอย่างต่อไปนี้ตั้งค่าการป้องกันการเขียนให้กับการนำเสนอ PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **โหลดการนำเสนอที่มีการป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่ได้เข้ารหัสเนื้อหา จึงไม่จำเป็นต้องใช้รหัสผ่านเพื่อโหลดการนำเสนอ รหัสผ่านเกี่ยวกับการยืนยันสิทธิ์ในการแก้ไขการนำเสนอที่ได้รับการป้องกันเท่านั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

อย่าเลือกส่งรหัสผ่านการป้องกันการเขียนไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) วิธีนี้รับรหัสผ่านการเปิดสำหรับเนื้อหาที่เข้ารหัส หากการนำเสนอมีทั้งสองประเภทของการป้องกัน ให้ส่งรหัสผ่านการเปิดเพื่อโหลดและจัดการรหัสผ่านการป้องกันการเขียนแยกต่างหาก

## **ลบการป้องกันการเขียนออกจากการนำเสนอ**

ใช้ [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#removeWriteProtection) เพื่อลบข้อจำกัดการแก้ไข แล้วบันทึกการนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

เพื่อสำรวจไฟล์โดยไม่ต้องสร้างออบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) แบบเต็ม ให้เรียก [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) และตรวจสอบ [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#isWriteProtected) วิธีนี้ใช้ [NullableBool](https://reference.aspose.com/slides/th/python-java/aspose.slides/nullablebool/) และคืนค่า `NullableBool.True_` เมื่อพบการป้องกันการเขียน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

รูปแบบ overload ที่รับสตรีมของ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) ให้ข้อมูลเดียวกันสำหรับการนำเสนอที่ส่งเป็นสตรีม

## **ตรวจสอบรหัสผ่านการป้องกันการเขียน**

ใช้ [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#checkWriteProtection) เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดการนำเสนอเต็ม ตรวจสอบ [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#isWriteProtected) ก่อน เพื่อให้แอปขอหรือยืนยันรหัสผ่านเมื่อมีการป้องกันการเขียน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#checkWriteProtection) ตรวจสอบเฉพาะรหัสผ่านการป้องกันการเขียน ไม่ตรวจสอบรหัสผ่านการเปิดหรือกำหนดว่าข้อมูลที่เข้ารหัสสามารถโหลดได้หรือไม่ ในทางกลับกัน [PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#checkPassword) ตรวจสอบเฉพาะรหัสผ่านการเปิด หากการนำเสนอเต็มได้โหลดแล้ว [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#checkWriteProtection) ให้การตรวจสอบการป้องกันการเขียนแบบเทียบเท่าผ่านผู้จัดการการป้องกัน

ในแอปพลิเคชันจริง ห้ามบันทึกรหัสผ่านในบันทึกหรือรวมไว้ในข้อความการวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำที่ไม่จำเป็น และเก็บรหัสผ่านในหน่วยความจำเฉพาะระยะเวลาที่ต้องการเท่านั้น

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [Password-Protect Presentations](/slides/th/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/th/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/th/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนทำให้การนำเข้าถูกเข้ารหัสหรือไม่?**

ไม่ การป้องกันการเขียนจำกัดการแก้ไขแต่ทำให้เนื้อหาการนำเสนอสามารถโหลดและดูได้

**รหัสผ่านการป้องกันการเขียนจำเป็นต้องใช้เพื่อเปิดการนำเสนอหรือไม่?**

ไม่ จำเป็นต้องใช้เพียงรหัสผ่านการเปิดเพื่อโหลดเนื้อหาที่เข้ารหัสเท่านั้น

**การนำเสนอสามารถมีทั้งรหัสผ่านการเปิดและรหัสผ่านการป้องกันการเขียนได้หรือไม่?**

ได้ ให้ใส่รหัสผ่านการเปิดผ่านตัวเลือกการโหลดเพื่อเปิดการนำเสนอที่เข้ารหัส และตรวจสอบรหัสผ่านการป้องกันการเขียนแยกต่างหากเมื่อจำเป็นต้องได้รับสิทธิ์การแก้ไข