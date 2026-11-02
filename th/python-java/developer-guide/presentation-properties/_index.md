---
title: จัดการคุณสมบัติงานนำเสนอใน Python
linktitle: คุณสมบัติงานนำเสนอ
type: docs
weight: 70
url: /th/python-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติงานนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติมาตรฐาน
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาการตรวจสอบ
- ภาษาตั้งค่าเริ่มต้น
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมคุณสมบัติงานนำเสนอใน Aspose.Slides for Python via Java และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณเป็นไปอย่างราบรื่น"
---
## **คำนำ**

Aspose.Slides for Python via Java รองรับ **built-in** และ **custom** property ของเอกสาร ใช้ property เหล่านี้เพื่ออ่านและอัปเดตเมตาดาตาของงานนำเสนอ เช่น ผู้เขียน, ชื่อเรื่อง, และค่าที่ผู้ใช้กำหนด

Aspose.Slides ให้คุณทำงานกับ property ของเอกสารงานนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) ตัวอย่างของคลาสนี้จะถูกส่งคืนโดย [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการกับ property เหล่านี้

{{% alert color="info" title="Note" %}}

Aspose.Slides จัดการเมตาดาต้าแอปพลิเคชันและผู้ผลิตเมื่อบันทึกงานนำเสนอ; ฟิลด์เหล่านี้ระบุซอฟต์แวร์ที่สร้างผลลัพธ์

{{% /alert %}}

## **จัดการ Property ของงานนำเสนอ**

Property ของเอกสารเก็บข้อมูลเชิงบรรยายควบคู่กับเนื้อหาของงานนำเสนอ พวกมันแบ่งเป็นสองประเภท:

- **Built-in properties** มีเมตาดาต้ามาตรฐาน เช่น ชื่อเรื่อง, ผู้เขียน, และสถิติของเอกสาร
- **Custom properties** เก็บคู่ชื่อ/ค่า ที่ผู้ใช้กำหนดเอง

Aspose.Slides for Python via Java ให้เข้าถึงทั้งสองประเภท ใน PowerPoint ให้เลือก **File → Info → Properties → Advanced Properties** เพื่อดูเมตาดาต้าเอกสาร กล่องโต้ตอบจะแบ่งข้อมูลเป็นแท็บเช่น **Summary**, **Statistics**, **Contents**, และ **Custom** ใช้แท็บ **Custom** เพื่อจัดการ property ที่ผู้ใช้กำหนดเอง

## **อ่าน Property สาธารณะจากงานนำเสนอที่ถูกเข้ารหัส**

รหัสผ่านเปิดไฟล์ทั่วไปจะปกป้องทั้งเนื้อหาและ property ของเอกสาร เมื่อทำการเข้ารหัสงานนำเสนอหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ด้วยค่า `False` property ของเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันจึงสามารถเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วยค่า `True` และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องใส่รหัสผ่านเปิดไฟล์

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ทำการถอดรหัสใด ๆ หาก property ถูกเข้ารหัสไว้ การโหลดโดยไม่ใช้รหัสผ่านจะล้มเหลว หากงานนำเสนอไม่ได้ถูกเข้ารหัส ตัวเลือกนี้จะถูกละเว้นและโหลดงานนำเสนอทั้งหมด

ตัวอย่างนี้ต้องการงานนำเสนอที่ถูกเข้ารหัสโดยมี property ของเอกสารเป็นสาธารณะ มันตรวจสอบโหมดการโหลดผ่าน [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) แล้วอ่าน built-in properties ผ่าน [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

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

ในโหมดนี้ เนื้อหาสไลด์จะไม่ถูกโหลด ทั้งสไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และวัตถุอื่น ๆ ของงานนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) เสมอก่อนทำการดำเนินการที่ต้องใช้โมเดลวัตถุของงานนำเสนอทั้งหมด

{{% alert color="warning" title="Warning" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวเรื่อง, คีย์เวิร์ด, ข้อมูลบริษัท, ความคิดเห็น, และค่า custom รหัสผ่าน property ที่สำคัญร่วมกับงานนำเสนอหรือปล่อยให้เป็นสาธารณะเฉพาะเมื่อต้องการจัดทำดัชนี, การจัดประเภท, การค้นหา, หรือระบบจัดการเอกสารที่ต้องการเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดต Property ของงานนำเสนอที่ถูกเข้ารหัส**

สำหรับไฟล์ PPTX ที่ถูกเข้ารหัส งานนำเสนอที่โหลดหลังจากเรียก [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `True` มีจุดมุ่งหมายเพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลง property จากอ็อบเจ็กต์แบบเมตาดาต้า‑เพียงอย่างเดียวได้ เพราะ property สาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในงานนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและการโหลดเต็มรูปแบบ

ตัวอย่างนี้ต้องการไฟล์ PPTX ที่เข้ารหัสพร้อม property ของเอกสารเป็นสาธารณะและมีรหัสผ่านเปิดไฟล์ที่รู้จัก มันเปิดงานนำเสนอเต็มรูปแบบด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), อัปเดต built-in properties สาธารณะ, แล้วบันทึกผลลัพธ์ จากนั้นใช้ [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่ต้องใช้รหัสผ่านเพื่อยืนยันค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหางานนำเสนอ จะต้องถือว่า property สาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึง Built-in Properties**

คลาส [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) เปิดเผยเมตาดาต้ารุ่น built‑in ผ่านเมธอด getter รวมถึง [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle), และ [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่และพิมพ์เมตาดาต้าที่บันทึกไว้ลงคอนโซล ค่าต่าง ๆ ขึ้นกับงานนำเข้าที่ใช้; บางฟิลด์อาจเป็นค่าว่าง

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

## **แก้ไข Built-in Properties**

เพื่ออัปเดตเมตาดาต้า built‑in ให้ใช้เมธอด setter บนวัตถุที่ส่งคืนจาก [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างนี้เปิดงานนำเสนอที่มีอยู่, เรียก [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments), และ [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager), แล้วบันทึกงานนำเสนอที่อัปเดตด้วย [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) PPTX ที่บันทึกไว้จะมีเมตาดาต้าใหม่

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

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) คืนค่าฐานระดับเอกสารสำหรับลิงก์แบบ relative ใช้ [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) เพื่อเปลี่ยนหรือเคลียร์ค่า นี้มีประโยชน์เมื่อย้ายงานนำเสนอและไฟล์ที่ลิงก์ไปยังตำแหน่งใหม่ แยกจาก [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) ของลิงก์เดี่ยว: การเปลี่ยนฐานไม่ทำการเขียนทับที่อยู่ลิงก์ที่บันทึกไว้หรือเปลี่ยนปลายทางแบบ absolute

ตัวอย่างนี้ต้องการงานนำเสนอที่มีลิงก์ relative เช่น `target.html` และลิงก์ absolute เช่น `https://example.org/absolute.html` มันอ่านฐานที่มีอยู่, กำหนดฐานใหม่, แล้วบันทึกและเปิดงานนำเสนอใหม่เพื่อตรวจสอบค่า จากนั้นเคลียร์ฐานด้วยสตริงว่างและตรวจสอบค่าว่างในไฟล์ที่บันทึกแยกกัน แทนที่ฐานตัวอย่างด้วยตำแหน่งไฟล์ที่ลิงก์ของคุณ

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

ข้อความตรวจสอบสองข้อความควรพิมพ์ `True` การเคลียร์ฐานจะไม่กระทบที่อยู่ลิงก์เดี่ยว

ลิงก์ relative ไปยัง `target.pptx` จะเปิด `old/target.pptx` เมื่อฐานชี้ไปที่โฟลเดอร์ `old` หลังจากเปลี่ยนฐานเป็นโฟลเดอร์ `new` แล้วบันทึกและเปิดงานนำเสนอใหม่ ลิงก์เดียวกันจะเปิด `new/target.pptx` ลิงก์ absolute ยังคงเปิดไฟล์เดียวกัน ทดสอบลิงก์ relative ของคุณใน PowerPoint ก่อนและหลังย้ายงานนำเสนอหรือเปลี่ยนฐาน

## **เพิ่ม Custom Presentation Properties**

Custom properties เก็บเมตาดาต้าที่ไม่มีฟิลด์ built‑in ตรงกัน วิธี [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) ให้คุณกำหนดค่าโดยใช้ชื่อ property ตัวอย่างนี้สร้างงานนำเสนอ, เพิ่มค่า text สองค่าและค่าเวอร์ชั่นแบบจำนวนเต็ม (โดยใช้ `jpype.JInt` เพื่อส่งค่าจำนวนเต็ม Java) แล้วบันทึกงานนำเสนอด้วย [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) การกำหนดค่าให้กับชื่อที่มีอยู่แล้วจะแทนที่ค่าของ property นั้น

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

## **เข้าถึงและแก้ไข Custom Properties**

ตัวอย่างนี้เปิดงานนำเสนอที่มี custom properties และใช้ [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) เพื่อนับจำนวน จากนั้นใช้ [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) รับชื่อโดยอ้างอิงตามดัชนีเริ่มจากศูนย์และคืนชื่อที่ใช้ใน [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) ตัวอย่างพิมพ์ชื่อและค่าต้นฉบับแต่ละรายการ, แทนที่ค่าทั้งหมดด้วยสตริงลำดับเลขโดยไม่คำนึงถึงชนิดดั้งเดิม, แล้วบันทึกการเปลี่ยนแปลง หากไม่มี custom properties ลูปจะไม่ทำการเปลี่ยนใด ๆ

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

## **Live Example**

ลองใช้แอปออนไลน์ [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) เพื่อดูวิธีทำงานกับ property ของเอกสารโดยใช้ Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**ฉันจะลบ built‑in property ออกจากงานนำเสนอได้อย่างไร?**

Built‑in properties เป็นส่วนสำคัญของงานนำเสนอและไม่สามารถลบออกได้โดยสมบูรณ์ อย่างไรก็ตามคุณสามารถเปลี่ยนค่า หรือกำหนดให้เป็นค่าว่างได้หาก property นั้นอนุญาตให้ทำเช่นนั้น

**ถ้าฉันเพิ่ม custom property ที่มีอยู่แล้ว จะเกิดอะไรขึ้น?**

หากคุณเพิ่ม custom property ที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่ใหม่ ไม่จำเป็นต้องลบหรือเช็คก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าให้โดยอัตโนมัติ

**ฉันสามารถเข้าถึง property ของงานนำเสนอโดยไม่โหลดงานนำเสนอทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) แล้วตามด้วย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาต้าเอกสารที่บันทึกไว้โดยไม่ต้องสร้างอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) ดูตัวอย่างการสร้างรายงานแบบเบาใน [Build a Lightweight Presentation Inventory](/slides/th/python-java/examine-presentation/) สำหรับข้อจำกัดตามรูปแบบไฟล์

**ฉันสามารถอ่าน property สาธารณะของงานนำเสนอที่ถูกเข้ารหัสโดยไม่มีรหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ งานนำเสนอจะต้องถูกเข้ารหัสหลังจากเรียก [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ด้วย `False` และต้องโหลดด้วย [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) ด้วย `True`

**ฉันสามารถอัปเดตไฟล์ PPTX ที่ถูกเข้ารหัสในโหมด document‑properties‑only ได้หรือไม่?**

ไม่ได้ Property สาธารณะและที่เข้ารหัสต้องสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่ถูกเข้ารหัสต้องโหลดงานนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง