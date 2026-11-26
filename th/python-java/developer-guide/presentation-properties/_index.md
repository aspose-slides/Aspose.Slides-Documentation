---
title: จัดการคุณสมบัติการนำเสนอใน Python
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/python-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติกำหนดเอง
- คุณสมบัติเพิ่มเติม
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมทาดาต้าเอกสาร
- แก้ไขเมทาดาต้า
- ภาษาตรวจสอบ
- ภาษาตั้งค่าเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides for Python via Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นเรื่องง่ายและรวดเร็ว"
---
## **บทนำ**

Aspose.Slides for Python via Java รองรับคุณสมบัติเอกสาร **built-in** และ **custom** ใช้คุณสมบัติเหล่านี้เพื่ออ่านและอัปเดตเมทาดาต้าของงานพรีเซนเทชัน เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่กำหนดโดยผู้ใช้

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเอกสารของพรีเซนเทชันผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) อินสแตนซ์ของคลาสนี้จะถูกส่งคืนโดย [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="Note" %}}
Aspose.Slides จัดการเมทาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกพรีเซนเทชัน; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์
{{% /alert %}}

## **จัดการคุณสมบัติการนำเสนอ**

คุณสมบัติเอกสารเก็บข้อมูลเชิงบรรยายควบคู่กับเนื้อหาการนำเสนอ แบ่งออกเป็นสองประเภท

- **Built-in properties** มีเมทาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติของเอกสาร
- **Custom properties** เก็บคู่ค่า ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง

Aspose.Slides for Python via Java ให้เข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมทาดาต้าเอกสาร ไดอะล็อกจะจัดกลุ่มข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติที่ผู้ใช้กำหนดเอง

## **อ่านคุณสมบัติสาธารณะจากพรีเซนเทชันที่เข้ารหัส**

รหัสผ่านเปิดไฟล์โดยปกติคุ้มครองทั้งเนื้อหาและคุณสมบัติเอกสาร เมื่อพรีเซนเทชันถูกเข้ารหัสหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ด้วย `False` คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `True` แล้วอ่านเมทาดาต้าสาธารณะโดยไม่ต้องใส่รหัสผ่านเปิดไฟล์

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ควบคุมสิ่งที่ Aspose.Slides โหลด; ไม่ทำการถอดรหัสใด ๆ หากคุณสมบัติเฉพาะถูกเข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากพรีเซนเทชันไม่ถูกเข้ารหัส ตัวเลือกจะถูกละเว้นและพรีเซนเทชันทั้งหมดจะถูกโหลด

ตัวอย่างนี้ต้องการพรีเซนเทชันที่เข้ารหัสโดยที่คุณสมบัติเอกสารถูกปล่อยให้เป็นสาธารณะ ตรวจสอบโหมดการโหลดผ่าน [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) แล้วอ่านคุณสมบัติ built‑in ผ่าน [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และอ็อบเจ็กต์อื่น ๆ ของพรีเซนเทชันจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) ก่อนทำการปฏิบัติการที่ต้องการโมเดลอ็อบเจ็กต์พรีเซนเทชันเต็มรูปแบบ

{{% alert color="warning" title="Warning" %}}
เมทาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวเรื่อง, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง ควรเข้ารหัสคุณสมบัติที่ละเอียดอ่อนพร้อมกับพรีเซนเทชัน ให้ปล่อยเป็นสาธารณะเฉพาะเมื่อระบบจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบจัดการเอกสารมีความต้องการเฉพาะในการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของพรีเซนเทชันที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส พรีเซนเทชันที่โหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `True` มีจุดประสงค์เพื่ออ่านเมทาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติจากอ็อบเจ็กต์ที่โหลดเฉพาะเมทาดาต้านี้ได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในพรีเซนเทชันที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและการโหลดเต็มรูปแบบ

ตัวอย่างนี้ต้องการพรีเซนเทชัน PPTX ที่เข้ารหัสพร้อมคุณสมบัติเอกสารสาธารณะและรหัสผ่านเปิดไฟล์ที่รู้จัก เปิดพรีเซนเทชันทั้งหมดด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword) แล้วอัปเดตคุณสมบัติ built‑in สาธารณะ จากนั้นบันทึกผลลัพธ์ ใช้ [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมทาดาต้าสาธารณะโดยไม่ใช้รหัสผ่านเพื่อตรวจสอบค่าที่อัปเดต:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาพรีเซนเทชัน จะต้องถือว่าคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึงคุณสมบัติ Built‑in**

คลาส [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) เปิดเผยเมทาดาต้า built‑in ผ่านเมธอด getter เช่น [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle), และ [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) ตัวอย่างนี้เปิดพรีเซนเทชันที่มีอยู่และพิมพ์เมทาดาต้าที่เก็บไว้ในคอนโซล ค่าต่าง ๆ จะขึ้นอยู่กับพรีเซนเทชันที่ป้อน; บางฟิลด์อาจว่างเปล่า

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

### **รายงานหมายเลขรุ่นและเวลาแก้ไข**

เพื่อรายงานหนึ่งแถวต่อไฟล์ PPTX ในโฟลเดอร์ `presentations` ให้ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) และ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่าน [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) โดยไม่โหลดสไลด์สำหรับการแก้ไข API Python via Java จะคืนค่าระยะเวลาแก้ไขเป็นมิลลิวินาที ตัวอย่างจัดรูปแบบเป็นชั่วโมง, นาที, และวินาที พร้อมจำนวนวันสำหรับช่วงเวลาที่มากกว่า 24 ชั่วโมง

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

สำหรับพรีเซนเทชันที่บันทึกเวลาแก้ไขเป็น 1 วัน, 2 ชั่วโมง, และ 5 นาที รายงานจะแสดงผลลัพธ์ดังนี้

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) อ่านค่าที่แอปพลิเคชันสามารถเปลี่ยนแปลงได้ด้วย [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber) หมายเลขรุ่นเพียงอย่างเดียวไม่สามารถบ่งบอกว่าพรีเซนเทชันถูกบันทึกกี่ครั้งหรือกู้ประวัติโดยละเอียดได้

[getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) อ่านระยะเวลาแก้ไขที่บันทึกในไฟล์ ค่า `00:00:00` หมายถึงระยะเวลาที่เก็บเป็นศูนย์ แม้ว่าจะมีการแก้ไขพรีเซนเทชันก็ตาม

## **แก้ไขคุณสมบัติ Built‑in**

เพื่ออัปเดตเมทาดาต้า built‑in ให้ใช้เมธอด setter บนวัตถุที่คืนจาก [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างนี้เปิดพรีเซนเทชันที่มีอยู่, เรียก [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments), และ [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) แล้วบันทึกพรีเซนเทชันที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) PPTX ที่บันทึกจะมีเมทาดาต้าใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **จัดการ Hyperlink Base**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) คืนค่าฐานระดับเอกสารสำหรับลิงก์แบบสัมพันธ์ ใช้ [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) เพื่อเปลี่ยนหรือเคลียร์ค่า ซึ่งมีประโยชน์เมื่อย้ายพรีเซนเทชันและไฟล์ที่ลิงก์ไปยังตำแหน่งอื่น มันแยกจาก [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) ของลิงก์แต่ละอัน: การเปลี่ยนฐานจะไม่เขียนทับที่อยู่ลิงก์ที่เก็บไว้หรือเปลี่ยนปลายทางแบบคงที่

ตัวอย่างนี้ต้องการพรีเซนเทชันที่มีลิงก์สัมพันธ์ เช่น `target.html` และลิงก์คงที่ เช่น `https://example.org/absolute.html` อ่านฐานที่มีอยู่, ตั้งค่าฐานใหม่, แล้วบันทึกและเปิดพรีเซนเทชันเพื่อตรวจสอบค่า จากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าที่ว่างในไฟล์ที่บันทึกแยกต่างหาก แทนที่ฐานตัวอย่างด้วยตำแหน่งของไฟล์ลิงก์ของคุณ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

ข้อความตรวจสอบสองข้อความควรพิมพ์ `True` การเคลียร์ฐานจะไม่กระทบที่อยู่ลิงก์แต่ละอัน

ลิงก์สัมพันธ์ `target.pptx` จะเปิด `old/target.pptx` เมื่อฐานชี้ไปยังโฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new`, บันทึกและเปิดพรีเซนเทชันใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์คงที่จะยังคงเปิดไฟล์เดิม ตรวจสอบลิงก์สัมพันธ์ของคุณใน PowerPoint ก่อนและหลังการย้ายพรีเซนเทชันหรือเปลี่ยนฐาน

## **เพิ่มคุณสมบัติ Presentation แบบกำหนดเอง**

คุณสมบัติแบบกำหนดเองเก็บเมทาดาต้าที่ไม่มีฟิลด์ built‑in ที่สอดคล้องกัน เมธอด [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) ให้คุณกำหนดค่าโดยใช้ชื่อคุณสมบัติ ตัวอย่างนี้สร้างพรีเซนเทชัน, เพิ่มค่าข้อความสองค่าและค่ารุ่นแบบจำนวนเต็ม (ใช้ `jpype.JInt` เพื่อส่งผ่านจำนวนเต็ม Java) แล้วบันทึกพรีเซนเทชันด้วย [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) การกำหนดค่าชื่อที่มีอยู่แล้วจะทำให้ค่าที่เก่าถูกแทนที่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง**

ตัวอย่างนี้เปิดพรีเซนเทชันที่มีคุณสมบัติแบบกำหนดเองและใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) เพื่อวนซ้ำผ่านแต่ละคุณสมบัติ [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) รับอินเด็กซ์เริ่มจากศูนย์และคืนชื่อที่ใช้โดย [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทั้งหมดด้วยสตริงลำดับตัวเลขโดยไม่คำนึงถึงประเภทเดิม, แล้วบันทึกการเปลี่ยนแปลง หากไม่มีคุณสมบัติกำหนดเอง ลูปจะไม่ทำการเปลี่ยนแปลงใด ๆ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารโดยใช้ API ของ Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**ฉันจะลบคุณสมบัติ built‑in ออกจากพรีเซนเทชันได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนหนึ่งของพรีเซนเทชันและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**ถ้าฉันเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้วจะเกิดอะไรขึ้น?**

ถ้าคุณเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดพรีเซนเทชันเต็มรูปแบบได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) แล้วตามด้วย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมทาดาต้าเอกสารที่เก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ดูตัวอย่างการรายงานเต็มรูปแบบและข้อจำกัดของฟอร์แมตในบทความ [Build a Lightweight Presentation Inventory](/slides/th/python-java/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของพรีเซนเทชันที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ พรีเซนเทชันต้องถูกเข้ารหัสหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ด้วย `False` และต้องโหลดโดยเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `True`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด document‑properties‑only ได้หรือไม่?**

ไม่ได้ ข้อมูลคุณสมบัติสาธารณะและเข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดพรีเซนเทชันเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง