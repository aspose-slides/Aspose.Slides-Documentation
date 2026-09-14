---
title: ป้องกันการนำเสนอด้วยรหัสผ่านใน Python
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/python-java/password-protected-presentation/
keywords:
- การนำเสนอที่ป้องกันด้วยรหัสผ่าน
- รหัสผ่านเปิดใช้งาน
- เข้ารหัส PowerPoint
- ถอดรหัส PowerPoint
- ตรวจสอบรหัสผ่านการนำเสนอ
- ตรวจสอบรหัสผ่านการนำเสนอ
- เปิดการนำเสนอที่เข้ารหัส
- ลบการเข้ารหัส
- PowerPoint
- PPT
- PPTX
- การนำเสนอ
- Python
- Aspose.Slides
description: "เข้ารหัส, ตรวจจับ, ตรวจสอบ, เปิดและถอดรหัสการนำเสนอ PowerPoint PPT และ PPTX ที่ป้องกันด้วยรหัสผ่านด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

รหัสผ่านเปิดใช้งานจะเข้ารหัสการนำเสนอ จำเป็นต้องใช้รหัสผ่านที่ถูกต้องเพื่อโหลดและดูเนื้อหาการนำเสนอ ดังนั้นการป้องกันนี้ให้ความลับ

รหัสผ่านเปิดใช้งานแตกต่างจากรหัสผ่านการป้องกันการเขียน การป้องกันการเขียนจำกัดการแก้ไขแต่ไม่ได้เข้ารหัสเนื้อหา หรือป้องกันไม่ให้โหลดการนำเสนอ เพื่อจัดการรหัสผ่านสำหรับการแก้ไขการนำเสนอ ดู [Write-Protect Presentations](/slides/th/python-java/write-protected-presentation/).

ขั้นตอนการทำงานด้านล่างใช้ได้กับการนำเสนอทั้งแบบ PPT และ PPTX ตัวอย่างใช้ทั้งสองรูปแบบเมื่อพฤติกรรมแบบไฟล์และสตรีมมีความสำคัญ

## **เข้ารหัสการนำเสนอด้วยรหัสผ่านเปิดใช้งาน**

ใช้ [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#encrypt) เพื่อกำหนดรหัสผ่านเปิดใช้งาน จากนั้นใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) เพื่อบันทึกการนำเสนอที่เข้ารหัส

ตัวอย่างต่อไปนี้ทำการเข้ารหัสการนำเสนอ PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ทำให้คุณสมบัติเอกสารเป็นสาธารณะ**

โดยค่าเริ่มต้น Aspose.Slides จะรวมคุณสมบัติเอกสารในการเข้ารหัสการนำเสนอ วิธีการ [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ควบคุมพฤติกรรมนี้อย่างอิสระจากการเข้ารหัสเนื้อหาสไลด์ ให้ส่งค่า `False` ก่อนเรียก [ProtectionManager.encrypt](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#encrypt) เมื่อต้องการให้ระบบจัดทำดัชนี การจำแนก การค้นหา หรือการจัดการเอกสารอ่านข้อมูลเมตาโดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน

ตัวอย่างต่อไปนี้สร้างการนำเสนอ PPTX ที่เข้ารหัสโดยคงคุณสมบัติเอกสารในตัวให้เป็นสาธารณะ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การส่งค่า `False` ไปยัง [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) จะไม่ทำให้สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ หรือเนื้อหาการนำเสนออื่น ๆ เป็นสาธารณะ มันมีผลเฉพาะคุณสมบัติเอกสารเท่านั้น เพื่ออ่านคุณสมบัติเหล่านั้นโดยไม่โหลดเนื้อหาที่เข้ารหัส ให้ดู [Manage Presentation Properties](/slides/th/python-java/presentation-properties/).

## **โหลดการนำเสนอที่เข้ารหัส**

ตั้งค่า [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) ให้เป็นรหัสผ่านเปิดใช้งานและส่งออพชันไปยัง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ขณะโหลดไฟล์ การโหลดจะล้มเหลือเมื่อจำเป็นต้องใช้รหัสผ่านเปิดใช้งานแต่รหัสผ่านที่ให้มาขาดหายหรือไม่ถูกต้อง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # ทำงานกับการนำเสนอที่ถอดรหัสแล้ว.
    pass
finally:
    presentation.dispose()
```

## **ลบการเข้ารหัสจากการนำเสนอ**

โหลดการนำเสนอพร้อมรหัสผ่านเปิดใช้งาน เรียกใช้ [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#removeEncryption) แล้วบันทึกผลลัพธ์ การนำเสนอที่บันทึกแล้วจะสามารถโหลดโดยไม่ต้องใช้รหัสผ่านได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจสอบรหัสผ่านเปิดใช้งานก่อนการโหลด**

ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) เพื่อรับ [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/) โดยไม่ต้องสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ ตรวจสอบ [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#isPasswordProtected) ก่อนขอหรือยืนยันรหัสผ่าน เมื่อมีการป้องกัน ให้ตรวจสอบค่าที่ให้มาด้วย [PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#checkPassword)

### **ขั้นตอนทำงานแบบไฟล์พาธ**

ตัวอย่างต่อไปนี้ตรวจสอบรหัสผ่านเปิดใช้งานสำหรับไฟล์ PPTX ส่งค่าที่ตรวจสอบแล้วไปยัง [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword) แล้วโหลดการนำเสนอเต็มรูปแบบ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **ขั้นตอนทำงานแบบสตรีม**

The stream overload of [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) provides the same workflow. Reset the position of a seekable stream before loading the complete presentation from that stream.

ตัวอย่างต่อไปนี้ใช้ไฟล์ PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **ค่าที่ส่งกลับของ checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#checkPassword) จะคืนค่า `True` เฉพาะเมื่อการนำเสนอมีรหัสผ่านเปิดใช้งานและรหัสผ่านที่ให้มาถูกต้อง จะคืนค่า `False` ในแต่ละกรณีต่อไปนี้:
- รหัสผ่านไม่ถูกต้อง.
- การนำเสนอไม่มีรหัสผ่านเปิดใช้งาน.
- รหัสผ่านที่ให้เป็น `None` หรือว่างเปล่า.

พฤติกรรมนี้เหมือนกันสำหรับการนำเสนอ PPT และ PPTX.

## **ตรวจสอบว่าการนำเสนอที่โหลดแล้วถูกเข้ารหัสหรือไม่**

หลังจากโหลดการนำเสนอด้วยรหัสผ่านที่ถูกต้อง ให้ตรวจสอบ [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#isEncrypted) เพื่อยืนยันว่าการนำชมต้นทางถูกเข้ารหัส เพื่อค้นหาการป้องกันด้วยรหัสผ่านเปิดใช้งานก่อนการโหลด ใช้ [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#isPasswordProtected) ตามที่แสดงข้างต้น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **ข้อแนะนำด้านความปลอดภัย**

{{% alert color="warning" title="Security" %}}
ห้ามบันทึกรหัสผ่านเปิดใช้งานหรือรวมไว้ในข้อความวินิจฉัย หลีกเลี่ยงการตรวจสอบซ้ำโดยไม่จำเป็น เก็บรหัสผ่านในหน่วยความจำเฉพาะช่วงเวลาที่ต้องการเท่านั้น และใช้ผลการตรวจสอบที่สำเร็จซ้ำเมื่อต้องการโหลดการนำเสนอโดยตรง

คุณสมบัติเขียนเอกสารสาธารณะอาจเปิดเผยชื่อผู้เขียน ชื่อเรื่อง หัวข้อ คำสำคัญ ข้อมูลบริษัท ความคิดเห็น และค่าที่กำหนดเอง แม้ว่าการนำเสนอจะถูกเข้ารหัสก็ตาม ควรเข้ารหัสเมตาดาทาที่ละเอียดอ่อนพร้อมกับการนำเสนอ การทำให้คุณสมบัติเสียวสาธารณะควรเป็นการตัดสินใจอย่างชัดเจนโดยทำเฉพาะเมื่อระบบต้องทำการจัดทำดัชนี จำแนก ค้นหา หรือจัดการไฟล์โดยไม่ต้องใช้รหัสผ่านเปิดใช้งาน
{{% /alert %}}

## **ป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์**

1. เปิดแอปพลิเคชัน [Aspose.Slides Lock](https://products.aspose.app/slides/th/lock)
1. เลือกหรืออัปโหลดการนำเสนอ
1. ป้อนรหัสผ่านสำหรับการป้องกันการดู
1. หากต้องการสามารถป้อนรหัสผ่านแยกต่างหากสำหรับการป้องกันการแก้ไข
1. ใช้การป้องกันและดาวน์โหลดไฟล์ที่ได้

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/th/python-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/th/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**รหัสผ่านเปิดใช้งานกับรหัสผ่านการป้องกันการเขียนแตกต่างกันอย่างไร?**

รหัสผ่านเปิดใช้งานจะเข้ารหัสการนำเสนอและจำเป็นต้องใช้เพื่อโหลดเนื้อหา ส่วนรหัสผ่านการป้องกันการเขียนจะจำกัดการแก้ไขโดยไม่ทำการเข้ารหัสเนื้อหา

**ฉันสามารถตรวจสอบรหัสผ่านเปิดใช้งานโดยไม่โหลดสไลด์ทั้งหมดได้หรือไม่?**

ได้ สามารถรับข้อมูลการนำเสนอ ตรวจสอบว่ามีการป้องกันด้วยรหัสผ่านเปิดใช้งานหรือไม่ และตรวจสอบรหัสผ่านก่อนสร้างอินสแตนซ์การนำเสนอเต็มรูปแบบ

**แอปพลิเคชันสามารถอ่านเมตาดาทาโดยไม่ต้องใช้รหัสผ่านเปิดใช้งานได้หรือไม่?**

ได้ แต่เฉพาะเมื่อการนำเสนอถูกเข้ารหัสโดยปิดการเข้ารหัสคุณสมบัติเอกสาร แอปพลิเคชันต้องใช้โหมดการโหลดเฉพาะคุณสมบัติเอกสารที่อธิบายไว้ใน [Manage Presentation Properties](/slides/th/python-java/presentation-properties/).

**ขั้นตอนการตรวจสอบรหัสผ่านสนับสนุนทั้ง PPT และ PPTX หรือไม่?**

รองรับ การตรวจจับและตรวจสอบรหัสผ่านแบบไฟล์พาธและสตรีมทำงานเช่นเดียวกันสำหรับการนำเสนอ PPT และ PPTX.