---
title: การป้องกันการเขียนพรีเซนเทชันใน Python
linktitle: การป้องกันการเขียน
type: docs
weight: 25
url: /th/python-net/write-protected-presentation/
keywords:
- การป้องกันการเขียน
- PowerPoint ป้องกันการเขียน
- รหัสผ่านสำหรับแก้ไข
- จำกัดการแก้ไขพรีเซนเทชัน
- ลบการป้องกันการเขียน
- ตรวจสอบรหัสผ่านการแก้ไข
- PowerPoint
- พรีเซนเทชัน
- Python
- Aspose.Slides
description: "ตั้งค่า, ตรวจจับ, ตรวจสอบและลบรหัสผ่านการป้องกันการเขียนในพรีเซนเทชัน PowerPoint PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python."
---
## **บทนำ**

รหัสผ่านการป้องกันการเขียนจำกัดการแก้ไขพรีเซนเทชันแต่ไม่ได้เข้ารหัสเนื้อหา ผู้ใช้สามารถโหลดและดูพรีเซนเทชันที่ถูกป้องกันการเขียนได้โดยไม่ต้องใช้รหัสผ่าน ขึ้นอยู่กับแอปพลิเคชัน พวกเขาอาจสามารถแก้ไขเนื้อหาและบันทึกเป็นชื่ออื่นได้ ดังนั้นการป้องกันการเขียนจึงไม่ควรถือเป็นกลไกการรักษาความลับ

รหัสผ่านการเปิดทำหน้าที่แตกต่าง: มันเข้ารหัสพรีเซนเทชันและจำเป็นต้องใช้เพื่อโหลดเนื้อหา เพื่อเข้ารหัสพรีเซนเทชันหรือยืนยันรหัสผ่านการเปิด ดู [Password-Protect Presentations](/slides/th/python-net/password-protected-presentation/).

ขั้นตอนการทำงานในบทความนี้ใช้ได้กับพรีเซนเทชันทั้งรูปแบบ PPT และ PPTX ตัวอย่างใช้ไฟล์ PPTX; เมื่อบันทึกเป็น PPT ให้ใช้ส่วนขยาย `.ppt` และรูปแบบการบันทึก PPT ที่สอดคล้องกัน

## **ตั้งค่าการป้องกันการเขียนบนพรีเซนเทชัน**

ใช้ [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/set_write_protection/) เพื่อกำหนดรหัสผ่านสำหรับการแก้ไขพรีเซนเทชัน การบันทึกพรีเซนเทชันจะบันทึกการตั้งค่าการป้องกันไว้

ตัวอย่างต่อไปนี้ตั้งค่าการป้องกันการเขียนบนพรีเซนเทชัน PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **โหลดพรีเซนเทชันที่มีการป้องกันการเขียน**

เนื่องจากการป้องกันการเขียนไม่ได้เข้ารหัสเนื้อหาพรีเซนเทชัน จึงไม่จำเป็นต้องใช้รหัสผ่านเพื่อโหลดพรีเซนเทชัน รหัสผ่านมีความสำคัญเฉพาะเมื่อทำการตรวจสอบสิทธิ์การแก้ไขพรีเซนเทชันที่ถูกป้องกัน

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

อย่าใส่รหัสผ่านการป้องกันการเขียนให้กับ [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/). คุณสมบัตินี้รับรหัสผ่านการเปิดสำหรับเนื้อหาที่เข้ารหัส หากพรีเซนเทชันมีทั้งสองประเภทของการป้องกัน ให้ใส่รหัสผ่านการเปิดเพื่อโหลดพรีเซนเทชันและจัดการรหัสผ่านการป้องกันการเขียนแยกกัน

## **ลบการป้องกันการเขียนจากพรีเซนเทชัน**

ใช้ [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/remove_write_protection/) เพื่อลบข้อจำกัดการแก้ไข แล้วบันทึกพรีเซนเทชัน

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบว่าพรีเซนเทชันถูกป้องกันการเขียนหรือไม่**

เพื่อตรวจสอบไฟล์โดยไม่ต้องสร้างอินสแต่นซ์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เต็มรูปแบบ ให้เรียก [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) และตรวจสอบ [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/is_write_protected/). คุณสมบัตินี้ใช้ [NullableBool](https://reference.aspose.com/slides/th/python-net/aspose.slides/nullablebool/) และคืนค่า `NullableBool.TRUE` เมื่อพบการป้องกันการเขียน

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

รูปแบบ overload ที่รับสตรีมของ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) ให้ข้อมูลเดียวกันสำหรับพรีเซนเทชันที่ส่งเป็นสตรีม

## **ตรวจสอบรหัสผ่านการป้องกันการเขียน**

ใช้ [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/check_write_protection/) เพื่อตรวจสอบรหัสผ่านการแก้ไขโดยไม่ต้องโหลดพรีเซนเทชันเต็มรูปแบบ ตรวจสอบ [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/is_write_protected/) ก่อนเพื่อให้แอปพลิเคชันขอหรือยืนยันรหัสผ่านเฉพาะเมื่อมีการป้องกันการเขียน

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/check_write_protection/) ตรวจสอบเฉพาะรหัสผ่านการป้องกันการเขียนเท่านั้น ไม่ได้ตรวจสอบรหัสผ่านการเปิดหรือกำหนดว่าข้อมูลที่เข้ารหัสสามารถโหลดได้หรือไม่ อีกด้านหนึ่ง [PresentationInfo.check_password](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/check_password/) ตรวจสอบเฉพาะรหัสผ่านการเปิด หากพรีเซนเทชันเต็มรูปแบบได้โหลดแล้ว [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/check_write_protection/) ให้การตรวจสอบการป้องกันการเขียนที่เทียบเคียงผ่านผู้จัดการการป้องกันของมัน

ในแอปพลิเคชันที่นำไปใช้จริง อย่าบันทึกรหัสผ่านหรือรวมไว้ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็นและเก็บรหัสผ่านในหน่วยความจำเฉพาะระยะเวลาที่จำเป็นเท่านั้น

{{% alert color="info" title="ดูเพิ่มเติม" %}}
- [Password-Protect Presentations](/slides/th/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/th/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/th/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**การป้องกันการเขียนเข้ารหัสพรีเซนเทชันหรือไม่?**

ไม่. มันจำกัดการแก้ไขแต่ให้เนื้อหาพรีเซนเทชันยังสามารถโหลดและดูได้

**จำเป็นต้องใช้รหัสผ่านการป้องกันการเขียนเพื่อเปิดพรีเซนเทชันหรือไม่?**

ไม่. มีเพียงรหัสผ่านการเปิดเท่านั้นที่จำเป็นเพื่อโหลดเนื้อหาพรีเซนเทชันที่เข้ารหัส

**พรีเซนเทชันสามารถมีทั้งรหัสผ่านการเปิดและรหัสผ่านการป้องกันการเขียนได้หรือไม่?**

ได้. ให้ใส่รหัสผ่านการเปิดผ่านตัวเลือกการโหลดเพื่อเปิดพรีเซนเทชันที่เข้ารหัส และตรวจสอบรหัสผ่านการป้องกันการเขียนแยกต่างหากเมื่อจำเป็นต้องได้รับสิทธิ์การแก้ไข