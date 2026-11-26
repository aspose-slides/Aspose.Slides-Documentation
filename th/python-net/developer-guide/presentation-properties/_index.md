---
title: จัดการคุณสมบัติงานนำเสนอด้วย Python
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/python-net/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติตัวสร้าง
- คุณสมบัติกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- ปรับแก้คุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการพิสูจน์
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides for Python via .NET และทำให้การค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint ของคุณเป็นเรื่องง่าย"
---
## **คำนำ**

Aspose.Slides for Python via .NET รองรับคุณสมบัติเ�เอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตข้อมูลเมตาของงานนำเสนอ เช่น ผู้เขียน ชื่อเรื่อง และค่าที่ผู้ใช้กำหนดเอง

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเขียนเอกสารผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) ตัวอย่างของคลาสนี้จะได้จาก [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) ตัวอย่างต่อไปจะแสดงวิธีการอ่าน แก้ไข และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}

Aspose.Slides จัดการเมตาดาต้าของแอปพลิเคชันและผู้ผลิตเมื่อตัวบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์

{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติเขียนเอกสารเก็บข้อมูลอธิบายพร้อมกับเนื้อหางานนำเสนอ แบ่งออกเป็นสองประเภท

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง ผู้เขียน และสถิติเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง

Aspose.Slides for Python via .NET ให้เข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อตรวจสอบเมตาดาต้าเอกสาร กล่องโต้ตอบจะจัดข้อมูลเป็นแท็บ เช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้ใช้กำหนด

## **อ่านคุณสมบัตสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดไฟล์มักปกป้องทั้งเนื้อหางานนำเสนอและคุณสมบัติเขียนเอกสาร เมื่องานนำเสนอถูกเข้ารหัสด้วย [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ตั้งค่าเป็น `False` คุณสมบัติเขียนเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันจึงสามารถตั้งค่า [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) เป็น `True` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องให้รหัสผ่านเปิดไฟล์

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ทำการถอดรหัสใด ๆ หากคุณสมบัติเบิลอยู่ในขั้นตอนการเข้ารหัส การโหลดโดยไม่ใช้รหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้เข้ารหัส ตัวเลือกจะถูกละเว้นและงานนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างนี้ต้องการงานนำเสนอที่เข้ารหัสโดยที่คุณสมบัติเขียนเอกสารเปิดไว้สาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) แล้วอ่านคุณสมบัติ built‑in ผ่าน [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

ในโหมดนี้เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์ มาสเตอร์ เค้าโครง รูปร่าง สื่อ และวัตถุอื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) ก่อนทำการใด ๆ ที่ต้องการโมเดลวัตถุของงานนำเสนอเต็มรูปแบบ

{{% alert color="warning" title="Security" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน ชื่อเรื่อง เรื่องย่อย คำสำคัญ ข้อมูลบริษัท คอมเมนต์ และค่าที่กำหนดเอง ให้เข้ารหัสคุณสมบัติเชิงลับพร้อมกับงานนำเสนอ ควรปล่อยให้เป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี การจัดประเภท การค้นหา หรือระบบการจัดการเอกสารมีความต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส งานนำเสนอที่โหลดด้วย [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากอ็อบเจ็กต์ที่โหลดเฉพาะเมตาดาต้าได้ เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและการโหลดแบบครบถ้วน

ตัวอย่างนี้ต้องการงานนำเสนอ PPTX ที่เข้ารหัสพร้อมคุณสมบัติเขียนเอกสารสาธารณะและรหัสผ่านเปิดไฟล์ที่ทราบ มันเปิดงานนำเสนอทั้งหมดด้วย [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) อัปเดตคุณสมบัติ built‑in สาธารณะ แล้วบันทึกผลลัพธ์ จากนั้นใช้ [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่ และเปิดเมตาดาต้าสาธารณะโดยไม่ใช้รหัสผ่านเพื่อยืนยันค่าที่ใหม่ :

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ จะต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึง Built‑in Properties**

คลาส [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) แสดงเมตาดาต้าตัวสร้างผ่านคุณสมบัติที่พิมพ์ชนิดรวมถึง [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), และ [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่เก็บไว้ลงคอนโซล ค่าต่าง ๆ จะขึ้นอยู่กับงานนำเข้าที่ใช้; บางฟิลด์อาจว่าง

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

### **รายงานหมายเลขรุ่นและเวลาการแก้ไข**

เพื่อรายงานหมายเลขรุ่นและเวลาการแก้ไขรวมของแต่ละไฟล์ PPTX ในโฟลเดอร์ `presentations` ให้ใช้ [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) เพื่อดึง [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) โดยไม่ต้องโหลดสไลด์เพื่อแก้ไข Python จะแสดงระยะเวลาเป็น `timedelta` รวมจำนวนวันเมื่อเวลาที่บันทึกครบ 24 ชั่วโมง

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

สำหรับงานนำเสนอที่บันทึกเวลาการแก้ไข 1 วัน 2 ชั่วโมง 5 นาที รายงานจะมีแถวดังต่อไปนี้

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) เป็นเมตาดาต้าที่สามารถเขียนได้ ค่าเดียวของมันไม่สามารถบ่งบอกจำนวนครั้งที่งานนำเสนอถูกบันทึกหรือสร้างประวัติรุ่นได้

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) แสดงระยะเวลาการแก้ไขที่บันทึกในไฟล์ ค่า `0:00:00` หมายถึงระยะเวลาที่บันทึกเป็นศูนย์ แม้จะมีผู้แก้ไขงานนำเสนอก็ตาม

## **แก้ไข Built‑in Properties**

เพื่ออัปเดตเมตาดาต้าตัวสร้าง ให้กำหนดค่าให้กับคุณสมบัติที่เขียนได้ที่เผยโดย [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่ ตั้งค่า [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), และ [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/) แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) PPTX ที่บันทึกจะมีเมตาดาต้าใหม่

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดการ Hyperlink Base**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) เก็บฐานระดับเอกสารสำหรับลิงก์แบบสัมพันธ์ ซึ่งมีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ลิงก์ไปยังตำแหน่งอื่น มันแยกจาก [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) ของลิงก์แต่ละรายการ: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บไว้หรือเปลี่ยนปลายทางแบบสัมบูรณ์

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์สัมพันธ์ เช่น `target.html` และลิงก์สัมบูรณ์ไปยังไฟล์หรือเว็บไซต์ มันอ่านฐานเดิม กำหนดฐานใหม่ แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า จากนั้นล้างฐานด้วย `""` และตรวจสอบค่าว่างในไฟล์ที่บันทึกแยกออกมา แทนที่ฐานตัวอย่างด้วยตำแหน่งไฟล์ลิงก์ของคุณ

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

ข้อความตรวจสอบทั้งสองควรพิมพ์ `True` การล้างฐานจะไม่กระทบที่อยู่ลิงก์แต่ละรายการ

ลิงก์สัมพันธ์ `target.pptx` จะเปิด `old/target.pptx` เมื่อฐานชี้ไปยังโฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new` บันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์สัมบูรณ์จะยังคงเปิดไฟล์เดิม ทดสอบลิงก์สัมพันธ์ใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่ม Custom Presentation Properties**

คุณสมบัติแบบกำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ built‑in ที่สอดคล้องกัน วิธี [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างงานนำเสนอ เพิ่มค่าข้อความสองค่าและค่าตัวเลขเวอร์ชัน แล้วบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) การกำหนดค่าที่ชื่อซ้ำจะทับค่าที่มีอยู่

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงและแก้ไข Custom Properties**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติแบบกำหนดเองและใช้ [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) เพื่อนับและวนลูปผ่านพวกมัน [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) รับอินเด็กซ์จากศูนย์และคืนชื่อที่ใช้โดย [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) ตัวอย่างนี้ต้องการงานนำเสนอที่คุณสมบัติแบบกำหนดเองทั้งหมดเป็นสตริง พิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลข แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติแบบกำหนดเอง ลูปจะไม่มีการเปลี่ยนแปลงใด ๆ

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) คืนค่าผ่านรายการที่มีองค์ประกอบเดียวที่ส่งเป็นอาร์กิวเมนต์ที่สอง ตัวแทนต้องตรงกับชนิดของคุณสมบัติที่เก็บไว้: ใช้ `[""]` สำหรับสตริงหรือ `[0]` สำหรับจำนวนเต็ม การใช้ชนิดไม่ตรงจะทำให้เกิด `InvalidCastException` เลือกตัวแทนตามสคีมาของคุณสมบัติแบบกำหนดเองของคุณ

## **Live Example**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเขียนเอกสารโดยใช้ Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ built‑in ออกจากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาตให้ทำเช่นนั้น

**ถ้าฉันเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

หากเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เพราะ Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติงานนำเสนอโดยไม่โหลดงานนำเสนอทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) แล้วตามด้วย [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) เพื่ออ่านเมตาดาต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ดูตัวอย่างการรายงานเต็มรูปแบบและข้อจำกัดตามฟอร์แมตได้ใน [Build a Lightweight Presentation Inventory](/slides/th/python-net/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสด้วย [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ตั้งค่าเป็น `False` และต้องโหลดด้วย [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ตั้งค่าเป็น `True`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document‑properties‑only ได้หรือไม่?**

ไม่ได้ ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง