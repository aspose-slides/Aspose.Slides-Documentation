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
- คุณสมบัติมาตรฐาน
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติชั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการพิสูจน์อักษร
- ภาษาปริยาย
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides สำหรับ Python via .NET และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint ของคุณเป็นระบบระเบียบมากขึ้น"
---
## **บทนำ**

Aspose.Slides for Python via .NET รองรับคุณสมบัติเอกสาร **built-in** และ **custom**. ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมตาดาต้าของงานนำเสนอ เช่น ผู้เขียน ชื่อเรื่อง และค่าที่ผู้ใช้กำหนด.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติของเอกสารงานนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . อินสแตนซ์ของคลาสนี้จะถูกส่งคืนโดย [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน แก้ไข และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุตัวซอฟต์แวร์ที่สร้างผลลัพธ์.
{{% /alert %}}

## **จัดการคุณสมบัติงานนำเสนอ**

คุณสมบัติของเอกสารเก็บข้อมูลเชิงบรรยายควบคู่กับเนื้อหางานนำเสนอ แบ่งเป็นสองประเภท:

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง ผู้เขียน และสถิติเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้กำหนดเอง

Aspose.Slides for Python via .NET ให้การเข้าถึงทั้งสองประเภท ใน PowerPoint เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร กล่องโต้ตอบจะจัดกลุ่มข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้กำหนดเอง.

## **อ่านคุณสมบัติสาธารณะจากงานนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดไฟล์โดยปกติจะปกป้องเนื้อหางานนำเสนอและคุณสมบัติของเอกสารทั้งสอง. เมื่อการเข้ารหัสงานนำเสนอใช้ [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ตั้งค่าเป็น `False` คุณสมบัติของเอกสารจะเปิดเป็นสาธารณะ. แอปพลิเคชันสามารถตั้งค่า [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) เป็น `True` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องระบุรหัสผ่านเปิดไฟล์. 

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่มีการถอดรหัสใดๆ. หากคุณสมบัตถูกรวมเข้ากับการเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว. หากงานนำเสนอไม่ได้เข้ารหัส ตัวเลือกจะถูกละเลยและจะโหลดงานนำเสนอเต็มรูปแบบ.

ตัวอย่างนี้ต้องการงานนำเสนอที่เข้ารหัสซึ่งคุณสมบัติของเอกสารถูกปล่อยให้เป็นสาธารณะ. มันตรวจสอบโหมดการโหลดผ่าน [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) และจากนั้นอ่านคุณสมบัติ built-in ผ่าน [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

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

ในโหมดนี้ เนื้อหาแผ่นสไลด์จะไม่ถูกโหลด. สไลด์, มาสเตอร์, เค้าโครง, รูปร่าง, สื่อ และอ็อบเจกต์ของงานนำเสนออื่นๆ จะไม่พร้อมใช้งาน. แอปพลิเคชันควรตรวจสอบ [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) เสมอก่อนทำการดำเนินการที่ต้องการโมเดลอ็อบเจกต์ของงานนำเสนอเต็มรูปแบบ.

{{% alert color="warning" title="Security" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง. ควรเข้ารหัสคุณสมบัติที่สำคัญพร้อมกับงานนำเสนอ. ให้เปิดเป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบจัดการเอกสารต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน.
{{% /alert %}}

## **อัปเดตคุณสมบัติของงานนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส การโหลดงานนำเสนอด้วย [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ. Aspose.Slides ไม่สามารถบันทึกคุณสมบัติที่เปลี่ยนแปลงจากอ็อบเจกต์ที่มีเมตาดาต้าเท่านั้นได้ เพราะคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส. การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและการโหลดเต็ม.

ตัวอย่างนี้ต้องการงานนำเสนอ PPTX ที่เข้ารหัสซึ่งมีคุณสมบัติของเอกสารเป็นสาธารณะและรหัสผ่านเปิดไฟล์ที่ทราบ. มันเปิดงานนำเสนอเต็มด้วย [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), อัปเดตคุณสมบัติ built-in สาธารณะ, และบันทึกผลลัพธ์. จากนั้นใช้ [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะอีกครั้งโดยไม่ใช้รหัสผ่านเพื่อยืนยันค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ มันต้องถือว่าคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่านอย่างเดียว.

## **เข้าถึงคุณสมบัติ Built-in**

คลาส [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) เปิดเผยเมตาดาต้า built-in ผ่านคุณสมบัติแบบกำหนดประเภท รวมถึง [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), และ [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่จัดเก็บไว้บนคอนโซล. ค่าต่างๆ ขึ้นอยู่กับงานนำเข้าที่ใช้; บางฟิลด์อาจว่างเปล่า.

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

## **แก้ไขคุณสมบัติ Built-in**

เพื่ออัปเดตเมตาดาต้า built-in ให้กำหนดค่าต่างๆ ให้กับคุณสมบัติที่เขียนได้ที่เปิดเผยโดย [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่, ตั้งค่า [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), และ [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), จากนั้นบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). PPTX ที่บันทึกจะมีเมตาดาต้าใหม่.

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

## **จัดการฐานไฮเปอร์ลิงก์**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) เก็บฐานระดับเอกสารสำหรับไฮเปอร์ลิงก์แบบ relative. สิ่งนี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่เชื่อมโยงไปยังตำแหน่งอื่น. มันแยกจาก [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่จัดเก็บหรือเปลี่ยนปลายทางแบบ absolute.

ตัวอย่างนี้ต้องการงานนำเสนอที่มีทั้งลิงก์ relative เช่น `target.html` และลิงก์ absolute ไปยังไฟล์หรือเว็บไซต์. มันอ่านฐานที่มีอยู่, กำหนดฐานใหม่, แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า. จากนั้นล้างฐานด้วย `""` และยืนยันค่าที่ว่างในไฟล์ที่บันทึกแยกต่างหาก. แทนที่ที่อยู่ฐานตัวอย่างด้วยตำแหน่งของไฟล์ที่เชื่อมโยงของคุณ.

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

ข้อความตรวจสอบสองข้อความควรพิมพ์ `True`. การล้างฐานจะไม่กระทบที่อยู่ไฮเปอร์ลิงก์แต่ละรายการ.

ลิงก์ relative ไปยัง `target.pptx` เปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old`. หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new`, บันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx`. ลิงก์ absolute ยังคงเปิดไฟล์เดียวกัน. ทดสอบลิงก์ relative ของคุณใน PowerPoint ก่อนและหลังการย้ายงานนำเสนอหรือเปลี่ยนฐาน.

## **เพิ่มคุณสมบัติที่กำหนดเองของงานนำเสนอ**

คุณสมบัติที่กำหนดเองเก็บเมตาดาต้าที่ไม่มีฟิลด์ built-in ที่สอดคล้อง. วิธี [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) ให้คุณกำหนดค่าตามชื่อคุณสมบัติ. ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่าเท็กซ์สองค่าและค่าเวอร์ชันแบบจำนวนเต็ม, แล้วบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). การกำหนดค่าที่ชื่อที่มีอยู่แล้วจะแทนที่ค่าของคุณสมบัตินั้น.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงและแก้ไขคุณสมบัติที่กำหนดเอง**

ตัวอย่างนี้เปิดงานนำเสนอที่มีคุณสมบัติที่กำหนดเองและใช้ [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) เพื่อวนลูปผ่านมัน. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) รับดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้โดย [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). ตัวอย่างต้องการงานนำเสนอที่คุณสมบัติที่กำหนดเองทั้งหมดเป็นสตริง. มันพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทุกค่าเป็นสตริงที่มีหมายเลข, และบันทึกการเปลี่ยนแปลง. หากไม่มีคุณสมบัติที่กำหนดเอง, ลูปจะไม่ทำการเปลี่ยนแปลงใดๆ.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) คืนค่าผ่านรายการหนึ่งองค์ประกอบที่ส่งเป็นอาร์กิวเมนต์ที่สอง. ตัวแทนต้องตรงกับประเภทของคุณสมบัติที่จัดเก็บ: ใช้ `[""]` สำหรับสตริงหรือ `[0]` สำหรับจำนวนเต็ม. ประเภทที่ไม่ตรงกันจะทำให้เกิด `InvalidCastException`; เลือกตัวแทนให้ตรงกับสคีมาของคุณสมบัติที่กำหนดเองของคุณ.

## **ตัวอย่างสด**

ลองแอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารโดยใช้ Aspose.Slides API:

[![ดูและแก้ไขเมตาดาต้า PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in จากงานนำเสนอได้อย่างไร?**

คุณสมบัติ built-in เป็นส่วนหนึ่งของงานนำเสนอและไม่สามารถลบออกทั้งหมดได้. อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้ หากคุณสมบัตินั้นอนุญาต.

**ถ้าฉันเพิ่มคุณสมบัติที่กำหนดเองที่มีอยู่แล้ว จะเกิดอะไรขึ้น?**

หากคุณเพิ่มคุณสมบัติที่กำหนดเองที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่ใหม่. คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน, เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ.

**ฉันสามารถเข้าถึงคุณสมบัติของงานนำเสนอโดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบได้หรือไม่?**

ใช่. ใช้ [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) แล้วตามด้วย [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) เพื่ออ่านเมตาดาต้าเอกสารที่จัดเก็บโดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). ดู [Build a Lightweight Presentation Inventory](/slides/th/python-net/examine-presentation/) สำหรับตัวอย่างการรายงานครบถ้วนและข้อจำกัดตามรูปแบบไฟล์.

**ฉันสามารถอ่านคุณสมบัติสาธารณะของงานนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ใช่. งานนำเสนอจะต้องถูกเข้ารหัสด้วย [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) ตั้งค่าเป็น `False`, และต้องโหลดด้วย [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) ตั้งค่าเป็น `True`.

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document-properties-only ได้หรือไม่?**

ไม่. ข้อมูลคุณสมบัติสาธารณะและที่เข้ารหัสต้องสอดคล้องกัน, ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง.