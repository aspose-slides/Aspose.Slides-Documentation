---
title: การป้องกันการนำเสนอด้วยรหัสผ่านใน Python
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/python-net/password-protected-presentation/
keywords:
- การนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิด
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบความถูกต้องของรหัสผ่านการนำเสนอ
- ตรวจสอบรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- Python
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิดและถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านใน Python ด้วย Aspose.Slides."
---
## **ภาพรวม**

รหัสผ่านเปิดจะเข้ารหัสการนำเสนอ ต้องใช้รหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้จึงให้ความลับ

รหัสผ่านเปิดแตกต่างจากรหัสผ่านการป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไข แต่ไม่เข้ารหัสเนื้อหา หรือป้องกันไม่ให้โหลดการนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ให้ดูที่ [Write-Protect Presentations](/slides/th/python-net/write-protected-presentation/)

ขั้นตอนการทำงานด้านล่างใช้ได้กับการนำเสนอทั้งแบบ PPTและ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมแบบไฟล์และแบบสตรีมมีความสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิด**

ใช้ [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/encrypt/) เพื่อกำหนดรหัสผ่านเปิด จากนั้นใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/) เพื่อบันทึกการนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้เข้ารหัสการนำเสนอ PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **เก็บคุณสมบัติลูกเอกสารเป็นสาธารณะ**

โดยค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติลูกเอกสารในการเข้ารหัสการนำเสนอ คุณสมบัติ [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ควบคุมพฤติกรรมนี้แยกจากการเข้ารหัสเนื้อหาสไลด์ ตั้งค่าเป็น `False` ก่อนเรียกใช้ [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/encrypt/) เมื่อต้องการให้ระบบการทำดัชนี การจัดประเภท การค้นหา หรือการจัดการเอกสารอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิด

ตัวอย่างต่อไปนี้สร้างการนำเสนอ PPTX ที่เข้ารหัสโดยที่คุณสมบัติลูกเอกสารในตัวยังคงเป็นสาธารณะ:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

การตั้งค่า `encrypt_document_properties` เป็น `False` ไม่ได้ทำให้สไลด์ มาสเตอร์ เค้าโครง รูปร่าง สื่อ หรือเนื้อหาอื่น ๆ ของการนำเสนอเป็นสาธารณะ มันมีผลเพียงคุณสมบัติลูกเอกสารเท่านั้น หากต้องการอ่านคุณสมบัติเหล่านั้นโดยไม่โหลดเนื้อหาที่เข้ารหัส ให้ดูที่ [Manage Presentation Properties](/slides/th/python-net/presentation-properties/)

## **โหลดการนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/) ให้เป็นรหัสผ่านเปิดและส่งตัวเลือกเหล่านั้นไปยัง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ตอนโหลดไฟล์ การโหลดจะล้มเหลือเมื่อต้องการรหัสผ่านเปิดแต่ไม่ได้ระบุรหัสผ่านหรือรหัสผ่านไม่ถูกต้อง

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
    pass
```

## **ลบการเข้ารหัสออกจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิด เรียกใช้ [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/remove_encryption/) แล้วบันทึกผลลัพธ์ การบันทึกการนำเสนอที่ได้สามารถโหลดได้โดยไม่ต้องใช้รหัสผ่าน

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบรหัสผ่านเปิดก่อนโหลด**

ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) เพื่อรับ [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/is_password_protected/) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อพบการป้องกัน ให้ยืนยันค่าที่ระบุด้วย [PresentationInfo.check_password](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/check_password/)

### **ขั้นตอนการทำงานแบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions.password](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/password/) แล้วโหลดการนำเสนอเต็มรูปแบบ:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **ขั้นตอนการทำงานแบบสตรีม**

ออร์แลงโหลดของ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) ให้ workflow เดียวกัน รีเซ็ตตำแหน่งของสตรีมที่สามารถเลื่อนได้ก่อนโหลดการนำเสนอเต็มรูปแบบจากสตรีมนั้น

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **ค่าที่ส่งกลับของ CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/check_password/) จะคืนค่า `True` ก็ต่อเมื่อการนำเสนอมีรหัสผ่านเปิดและรหัสผ่านที่ให้ถูกต้องเท่านั้น จะคืนค่า `False` ในทุกกรณีต่อไปนี้:

- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิด.
- รหัสผ่านที่ให้เป็น `None` หรือว่างเปล่า.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/is_encrypted/) เพื่อยืนยันว่าการนำเสนอแหล่งต้นทางถูกเข้ารหัส หากต้องการตรวจจับการป้องกันด้วยรหัสผ่านเปิดก่อนโหลด ให้ใช้ `PresentationInfo.is_password_protected` ตามที่แสดงด้านบน

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **คำแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
อย่าบันทึกรหัสผ่านเปิดหรือใส่ในข้อความวินิจฉัย หลีกเลี่ยงการพยายามตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเพียงเท่าที่จำเป็น และใช้ผลการตรวจสอบที่สำเร็จแล้วซ้ำเมื่อโหลดการนำเสนอโดยทันที

คุณสมบัติลูกเอกสารสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, เรื่อง, คำหลัก, ข้อมูลบริษัท, ความคิดเห็น และค่าที่กำหนดเอง แม้ว่าข้อมูลการนำเสนอจะถูกเข้ารหัสก็ตาม ควรเข้ารหัสเมตาดาต้าที่สำคัญพร้อมกับการนำเสนอ การทำให้คุณสมบัติสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนโดยทำเฉพาะเมื่อระบบต้องทำดัชนี จัดประเภท ค้นหา หรือจัดการไฟล์โดยไม่ต้องใช้รหัสผ่านเปิด
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
2. เลือกหรืออัปโหลดการนำเสนอ
3. ป้อนรหัสผ่านสำหรับการป้องกันการดู
4. หากต้องการ ป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข
5. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **คำถามที่พบบ่อย**

**อะไรคือความแตกต่างระหว่างรหัสผ่านเปิดและรหัสผ่านการป้องกันการเขียน?**

รหัสผ่านเปิดจะเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา ส่วนรหัสผ่านการป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่เข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดโดยไม่ต้องโหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ ให้รับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดหรือไม่ และยืนยันรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**แอปพลิเคชันสามารถอ่านเมตาดาต้าโดยไม่ต้องใช้รหัสผ่านเปิดได้หรือไม่?**

ได้ แต่เฉพาะเมื่อการนำเสนอถูกเข้ารหัสด้วยการตั้งค่า `encrypt_document_properties` เป็น `False` แอปพลิเคชันต้องใช้โหมดโหลดเฉพาะคุณสมบัติลูกเอกสารตามที่อธิบายใน [Manage Presentation Properties](/slides/th/python-net/presentation-properties/)

**ขั้นตอนการตรวจสอบรหัสผ่านสนับสนุนทั้ง PPT และ PPTX หรือไม่?**

สนับสนุน ทั้งขั้นตอนการตรวจจับและตรวจสอบรหัสผ่านแบบไฟล์พาธและแบบสตรีมทำงานเดียวกันสำหรับการนำเสนอ PPT และ PPTX