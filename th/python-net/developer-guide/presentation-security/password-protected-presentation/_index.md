---
title: การนำเสนอที่ปลอดภัยด้วยรหัสผ่านโดยใช้ Python
linktitle: การป้องกันด้วยรหัสผ่าน
type: docs
weight: 20
url: /th/python-net/password-protected-presentation/
keywords:
- ล็อก PowerPoint
- ล็อกการนำเสนอ
- ปลดล็อก PowerPoint
- ปลดล็อกการนำเสนอ
- ปกป้อง PowerPoint
- ปกป้องการนำเสนอ
- ตั้งรหัสผ่าน
- เพิ่มรหัสผ่าน
- เข้ารหัส PowerPoint
- เข้ารหัสการนำเสนอ
- ถอดรหัส PowerPoint
- ถอดรหัสการนำเสนอ
- การป้องกันการเขียน
- ความปลอดภัย PowerPoint
- ความปลอดภัยการนำเสนอ
- ลบรหัสผ่าน
- ลบการป้องกัน
- ลบการเข้ารหัส
- ปิดการใช้งานรหัสผ่าน
- ปิดการใช้งานการป้องกัน
- ลบการป้องกันการเขียน
- การนำเสนอ PowerPoint
- Python
- Aspose.Slides
description: "เรียนรู้วิธีล็อกและปลดล็อกการนำเสนอ PowerPoint และ OpenDocument ที่ป้องกันด้วยรหัสผ่านอย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพิ่มประสิทธิภาพการทำงานของคุณและปกป้องการนำเสนอของคุณด้วยคำแนะนำแบบทีละขั้นตอน"
---
## **บทนำ**

เมื่อคุณตั้งรหัสผ่านป้องกันการนำเสนอ หมายความว่าคุณกำหนดรหัสผ่านที่บังคับใช้ข้อจำกัดบางอย่างบนการนำเสนอ เพื่อเอาข้อจำกัดเหล่านั้นออก จำเป็นต้องใส่รหัสผ่าน การนำเสนอที่ป้องกันด้วยรหัสผ่านถือเป็นการนำเสนอที่ล็อกไว้

โดยทั่วไป คุณสามารถตั้งรหัสผ่านเพื่อบังคับใช้ข้อจำกัดเหล่านี้บนการนำเสนอได้:

- **การแก้ไข**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นสามารถแก้ไขการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการแก้ไข ข้อจำกัดนี้จะป้องกันไม่ให้ผู้คนแก้ไข เปลี่ยนแปลง หรือคัดลอกข้อมูลในการนำเสนอของคุณ (หากไม่ได้ให้รหัสผ่าน).

  อย่างไรก็ตาม ในกรณีนี้ แม้ไม่ได้ใส่รหัสผ่าน ผู้ใช้ก็สามารถเข้าถึงและเปิดเอกสารของคุณได้ ในโหมดอ่านอย่างเดียวนี้ ผู้ใช้สามารถดูเนื้อหา หรือสิ่งต่าง ๆ — ลิงก์, การเคลื่อนไหว, เอฟเฟกต์ และอื่น ๆ — ที่อยู่ในการนำเสนอของคุณได้ แต่ไม่สามารถคัดลอกรายการหรือบันทึกการนำเสนอได้.

- **การเปิด**

  หากคุณต้องการให้ผู้ใช้บางคนเท่านั้นสามารถเปิดการนำเสนอของคุณได้ คุณสามารถตั้งข้อจำกัดการเปิด ข้อจำกัดนี้จะป้องกันไม่ให้ผู้คนแม้แต่ดูเนื้อหาของการนำเสนอของคุณ (หากไม่ได้ให้รหัสผ่าน).

  โดยทางเทคนิค ข้อจำกัดการเปิดยังป้องกันผู้ใช้ไม่ให้แก้ไขการนำเสนอของคุณ: เมื่อผู้ใช้ไม่สามารถเปิดการนำเสนอได้ พวกเขาจะไม่สามารถทำการแก้ไขหรือเปลี่ยนแปลงใด ๆ ได้.

  **หมายเหตุ**ว่าเมื่อคุณตั้งรหัสผ่านป้องกันการนำเสนอเพื่อป้องกันการเปิดไฟล์ การนำเสนอจะถูกเข้ารหัส.

## วิธีป้องกันการนำเสนอด้วยรหัสผ่านออนไลน์

1. ไปที่หน้า [**Aspose.Slides Lock**](https://products.aspose.app/slides/th/lock) ของเรา.

   ![todo:image_alt_text](slides-lock.png)

2. คลิก **ลากหรืออัปโหลดไฟล์ของคุณ**.

3. เลือกไฟล์ที่คุณต้องการตั้งรหัสผ่านป้องกันบนคอมพิวเตอร์ของคุณ.

4. ป้อนรหัสผ่านที่คุณต้องการสำหรับการป้องกันการแก้ไข; ป้อนรหัสผ่านที่คุณต้องการสำหรับการป้องกันการดู.

5. หากคุณต้องการให้ผู้ใช้เห็นการนำเสนอของคุณเป็นสำเนาสุดท้าย ให้เลือกช่องทำเครื่องหมาย **Mark as final**.

6. คลิก **PROTECT NOW.**

7. คลิก **DOWNLOAD NOW.**

## **การป้องกันด้วยรหัสผ่านสำหรับการนำเสนอใน Aspose.Slides**
**รูปแบบที่รองรับ**

Aspose.Slides รองรับการป้องกันด้วยรหัสผ่าน การเข้ารหัส และการดำเนินการคล้ายกันสำหรับการนำเสนอในรูปแบบต่อไปนี้:

- PPTX และ PPT - การนำเสนอ Microsoft PowerPoint
- ODP - การนำเสนอ OpenDocument
- OTP - เทมเพลตการนำเสนอ OpenDocument

**การดำเนินการที่รองรับ**

Aspose.Slides อนุญาตให้คุณใช้การป้องกันด้วยรหัสผ่านบนการนำเสนอเพื่อป้องกันการแก้ไขโดยวิธีต่อไปนี้:

- การเข้ารหัสการนำเสนอ
- การตั้งการป้องกันการเขียนให้กับการนำเสนอ

**การดำเนินการอื่น ๆ**

Aspose.Slides อนุญาตให้คุณทำงานอื่น ๆ ที่เกี่ยวกับการป้องกันด้วยรหัสผ่านและการเข้ารหัสได้โดยวิธีต่อไปนี้:

- การถอดรหัสการนำเสนอ; การเปิดการนำเสนอที่เข้ารหัส
- การลบการเข้ารหัส; การปิดการป้องกันด้วยรหัสผ่าน
- การลบการป้องกันการเขียนจากการนำเสนอ
- การดึงคุณสมบัติของการนำเสนอที่เข้ารหัส
- การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่
- การตรวจสอบว่าการนำเสนอได้รับการป้องกันด้วยรหัสผ่านหรือไม่.

## **การเข้ารหัสการนำเสนอ**

คุณสามารถเข้ารหัสการนำเสนอโดยตั้งรหัสผ่านแล้ว เพื่อแก้ไขการนำเสนอที่ล็อกอยู่ ผู้ใช้ต้องใส่รหัสผ่าน

เพื่อเข้ารหัสหรือใส่รหัสผ่านป้องกันการนำเสนอ คุณต้องใช้เมธอด encrypt (จาก [ProtectionManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/)) เพื่อกำหนดรหัสผ่านให้กับการนำเสนอ คุณจะส่งรหัสผ่านให้กับเมธอด encrypt แล้วใช้เมธอด save เพื่อบันทึกการนำเสนอที่ถูกเข้ารหัสแล้ว.

ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสการนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **การตั้งการป้องกันการเขียนให้กับการนำเสนอ**

คุณสามารถเพิ่มเครื่องหมายที่ระบุว่า “ห้ามแก้ไข” ให้กับการนำเสนอได้ ด้วยวิธีนี้ คุณแจ้งผู้ใช้ว่าคุณไม่ต้องการให้พวกเขาเปลี่ยนแปลงการนำเสนอ

**หมายเหตุ** ว่ากระบวนการป้องกันการเขียนไม่ได้เข้ารหัสการนำเสนอ ดังนั้นผู้ใช้—หากต้องการจริง ๆ—สามารถแก้ไขการนำเสนอได้ แต่เพื่อบันทึกการเปลี่ยนแปลง พวกเขาจะต้องสร้างการนำเสนอใหม่ด้วยชื่อที่ต่างออกไป.

เพื่อกำหนดการป้องกันการเขียน คุณต้องใช้เมธอด setWriteProtection ตัวอย่างโค้ดนี้แสดงวิธีการตั้งการป้องกันการเขียนให้กับการนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **การถอดรหัสการนำเสนอ; การเปิดการนำเสนอที่เข้ารหัส**

Aspose.Slides อนุญาตให้คุณโหลดไฟล์ที่เข้ารหัสโดยส่งรหัสผ่านของไฟล์นั้น เพื่อถอดรหัสการนำเสนอ คุณต้องเรียกเมธอด [remove_encryption](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/) โดยไม่มีพารามิเตอร์ แล้วคุณจะต้องใส่รหัสผ่านที่ถูกต้องเพื่อโหลดการนำเสนอ.

ตัวอย่างโค้ดนี้แสดงวิธีการถอดรหัสการนำเสนอ:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **การลบการเข้ารหัส; การปิดการป้องกันด้วยรหัสผ่าน**

คุณสามารถลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่านบนการนำเสนอได้ วิธีนี้ทำให้ผู้ใช้สามารถเข้าถึงหรือแก้ไขการนำเสนอโดยไม่มีข้อจำกัด

เพื่อทำการลบการเข้ารหัสหรือการป้องกันด้วยรหัสผ่าน คุณต้องเรียกเมธอด [remove_encryption](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/) ตัวอย่างโค้ดนี้แสดงวิธีการลบการเข้ารหัสจากการนำเสนอ:

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **การลบการป้องกันการเขียนจากการนำเสนอ**

คุณสามารถใช้ Aspose.Slides เพื่อลบการป้องกันการเขียนที่ใช้กับไฟล์การนำเสนอ วิธีนี้ทำให้ผู้ใช้สามารถแก้ไขได้ตามต้องการ—และจะไม่มีคำเตือนใด ๆ เมื่อพวกเขาทำเช่นนั้น.

คุณสามารถลบการป้องกันการเขียนจากการนำเสนอด้วยการใช้เมธอด [remove_write_protection](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/) ตัวอย่างโค้ดนี้แสดงวิธีการลบการป้องกันการเขียนจากการนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **ดึงคุณสมบัติของการนำเสนอที่เข้ารหัส**

โดยทั่วไป ผู้ใช้มักมีปัญหาในการดึงคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัสหรือป้องกันด้วยรหัสผ่าน อย่างไรก็ตาม Aspose.Slides มีกลไกที่ทำให้คุณสามารถตั้งรหัสผ่านป้องกันการนำเสนอได้โดยยังคงให้ผู้ใช้สามารถเข้าถึงคุณสมบัติเบื้องต้นได้.

**หมายเหตุ:** โดยค่าเริ่มต้น เมื่อ Aspose.Slides ทำการเข้ารหัสการนำเสนอ คุณสมบัติของเอกสารการนำเสนอก็จะถูกป้องกันด้วยรหัสผ่านด้วย หากคุณต้องการให้คุณสมบัติเบื้องต้นเข้าถึงได้แม้หลังจากการเข้ารหัส Aspose.Slides ให้คุณทำเช่นนั้นได้.

หากคุณต้องการให้ผู้ใช้ยังคงเข้าถึงคุณสมบัติของการนำเสนอที่เข้ารหัสได้ ให้ตั้งค่า `encrypt_document_properties` ของ [ProtectionManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/) เป็น `False` ตัวอย่างโค้ดนี้แสดงวิธีการเข้ารหัสการนำเสนอพร้อมให้ผู้ใช้เข้าถึงคุณสมบัติของเอกสารได้:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **โหลดเฉพาะคุณสมบัติของเอกสารจากการนำเสนอที่เข้ารหัส**

เพื่อดูเมตาดาต้าของการนำเสนอที่เข้ารหัสโดยไม่ต้องโหลดสไลด์หรือเนื้อหาอื่น ๆ ให้สร้างอ็อบเจกต์ [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/) และตั้งค่า [only_load_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/only_load_document_properties/) เป็น `True` ในโหมดนี้ Aspose.Slides จะละเว้นรหัสผ่านและโหลดเฉพาะคุณสมบัติของเอกสารที่เปิดให้เข้าถึงได้สาธารณะ

โค้ดตัวอย่างต่อไปนี้อ่านคุณสมบัติเอกสารที่มีมาโดยปริยายและแสดงรายการคุณสมบัติเอกสารที่กำหนดเองผ่าน [Presentation.document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/document_properties/):

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # อ่านคุณสมบัติเอกสารที่มีมาโดยปริยาย.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # แสดงรายการคุณสมบัติเอกสารที่กำหนดเอง.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

ขั้นตอนการทำงานนี้ทำงานได้เฉพาะเมื่อคุณสมบัติของเอกสารถูกทิ้งไว้โดยไม่ได้เข้ารหัส (เป็นสาธารณะ) ตอนที่การนำเสนอถูกเข้ารหัส หากคุณสมบัติของเอกสารถูกเข้ารหัส การตั้งค่า `only_load_document_properties` เป็น `True` จะทำให้เกิดข้อยกเว้นเนื่องจากรหัสผ่านจะถูกละเว้นในโหมดนี้ เพื่อเข้าถึงคุณสมบัติของเอกสารที่เข้ารหัสหรือโหลดการนำเสนอทั้งหมดรวมถึงสไลด์และเนื้อหาอื่น ๆ ให้ใส่ค่ารหัสผ่านที่ถูกต้องใน `password` ของ [LoadOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides/loadoptions/).

## **การตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านหรือไม่ก่อนโหลด**

ก่อนที่คุณจะโหลดการนำเสนอ คุณอาจต้องการตรวจสอบและยืนยันว่าการนำเสนอไม่ได้รับการป้องกันด้วยรหัสผ่าน วิธีนี้จะช่วยหลีกเลี่ยงข้อผิดพลาดและปัญหาอื่น ๆ ที่เกิดขึ้นเมื่อการนำเสนอที่ป้องกันด้วยรหัสผ่านถูกโหลดโดยไม่ได้ใส่รหัสผ่าน.

โค้ด Python นี้แสดงวิธีการตรวจสอบการนำเสนอเพื่อดูว่ามีการป้องกันด้วยรหัสผ่านหรือไม่ (โดยไม่ต้องโหลดการนำเสนอเอง):

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **การตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่ เพื่อทำงานนี้ คุณสามารถใช้คุณสมบัติ [is_encrypted](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/) ซึ่งจะคืนค่า `True` หากการนำเสนอถูกเข้ารหัสหรือ `False` หากไม่ถูกเข้ารหัส.

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **การตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่**

Aspose.Slides ให้คุณตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่ เพื่อทำงานนี้ คุณสามารถใช้คุณสมบัติ [is_write_protected](https://reference.aspose.com/slides/th/python-net/aspose.slides/protectionmanager/) ซึ่งจะคืนค่า `True` หากการนำเสนอถูกเข้ารหัสหรือ `False` หากไม่ถูกเข้ารหัส.

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบว่าการนำเสนอถูกป้องกันการเขียนหรือไม่:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **การตรวจสอบหรือยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันการนำเสนอ**

คุณอาจต้องการตรวจสอบและยืนยันว่ามีการใช้รหัสผ่านเฉพาะเพื่อป้องกันเอกสารการนำเสนอ Aspose.Slides มีวิธีการให้คุณตรวจสอบความถูกต้องของรหัสผ่าน.

ตัวอย่างโค้ดนี้แสดงวิธีการตรวจสอบความถูกต้องของรหัสผ่าน:

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # ตรวจสอบว่า "pass" ตรงกับ
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

มันจะคืนค่า `True` หากการนำเสนอถูกเข้ารหัสด้วยรหัสผ่านที่ระบุ มิฉะนั้นจะคืนค่า `False`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/th/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**วิธีการเข้ารหัสที่ Aspose.Slides รองรับคืออะไร?**

Aspose.Slides รองรับวิธีการเข้ารหัสสมัยใหม่ รวมถึงอัลกอริธึมที่ใช้ AES ซึ่งให้ความปลอดภัยระดับสูงสำหรับข้อมูลของการนำเสนอของคุณ.

**จะเกิดอะไรขึ้นหากใส่รหัสผ่านผิดขณะพยายามเปิดการนำเสนอ?**

จะเกิดข้อยกเว้นเมื่อใช้รหัสผ่านที่ไม่ถูกต้อง เพื่อแจ้งให้คุณทราบว่าการเข้าถึงการนำเสนอถูกปฏิเสธ การกระทำนี้ช่วยป้องกันการเข้าถึงโดยไม่ได้รับอนุญาตและปกป้องเนื้อหาการนำเสนอ.

**มีผลต่อประสิทธิภาพหรือไม่เมื่อทำงานกับการนำเสนอที่ป้องกันด้วยรหัสผ่าน?**

กระบวนการเข้ารหัสและถอดรหัสอาจทำให้เกิดภาระงานเพิ่มเล็กน้อยในระหว่างการเปิดและบันทึก ในส่วนใหญ่ ผลกระทบต่อประสิทธิภาพจะน้อยและไม่ส่งผลอย่างมีนัยสำคัญต่อระยะเวลาการประมวลผลรวมของงานการนำเสนอของคุณ.