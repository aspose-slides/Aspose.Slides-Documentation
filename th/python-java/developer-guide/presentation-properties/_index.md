---
title: จัดการคุณสมบัตินำเสนอใน Python
linktitle: คุณสมบัตินำเสนอ
type: docs
weight: 70
url: /th/python-java/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติ built-in
- คุณสมบัติ custom
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- เมตาดาต้าเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบ
- ภาษาตั้งต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมคุณสมบัตินำเสนอใน Aspose.Slides สำหรับ Python ผ่าน Java และเพิ่มประสิทธิภาพการค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint และ OpenDocument ของคุณ."
---
## **บทนำ**

Aspose.Slides รองรับสองประเภทของคุณสมบัติเอกสาร: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติเ�เอกสารการนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/) ตัวอย่างของคลาสนี้จะถูกคืนโดย [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDocumentProperties) ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้

{{% alert color="info" title="หมายเหตุ" %}}
โปรดทราบว่าฟิลด์ **Application** และ **AppVersion** ไม่สามารถแก้ไขได้ Aspose.Slides จะเขียนทับฟิลด์เหล่านี้ทุกครั้งที่บันทึก ดังนั้นการนำเสนอที่บันทึกแล้วจะรายงานเป็น "Aspose.Slides for Java" พร้อมเวอร์ชันของไลบรารีที่สร้างมัน ค่าที่ส่งไปยัง [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#setNameOfApplication) จะถูกละทิ้งเมื่อเขียนไฟล์นำเสนอ
{{% /alert %}}

## **คุณสมบัติเอกสารใน PowerPoint**

Microsoft PowerPoint 2007 อนุญาตให้คุณจัดการคุณสมบัติเอกสารของไฟล์การนำเสนอ คลิกไอคอน Office แล้วเลือก **Prepare | Properties | Advanced Properties** ตามที่แสดงด้านล่าง:

|**การเลือกเมนู Advanced Properties**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|

หลังจากคุณเลือก **Advanced Properties** จะปรากฏกล่องโต้ตอบที่คุณสามารถจัดการคุณสมบัติเอกสารของไฟล์ PowerPoint:

|**กล่องโต้ตอบ Properties**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|

**กล่องโต้ตอบ Properties** มีแท็บต่าง ๆ เช่น **General**, **Summary**, **Statistics**, **Contents**, และ **Custom** แท็บเหล่านี้ช่วยให้คุณกำหนดค่าประเภทข้อมูลต่าง ๆ ของไฟล์ PowerPoint ใช้แท็บ **Custom** เพื่อจัดการคุณสมบัติแบบกำหนดเอง

## **ทำงานกับคุณสมบัติเอกสารโดยใช้ Aspose.Slides for Python via Java**

ดังที่ได้อธิบายไว้ก่อนหน้านี้ Aspose.Slides for Python via Java รองรับทั้งคุณสมบัติ **Built-in** และ **Custom** คลาส [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/) แสดงคุณสมบัติเอกสารที่เชื่อมโยงกับไฟล์การนำเสนอ

ใช้ [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDocumentProperties) เพื่อเข้าถึงคุณสมบัติเหล่านี้ตามที่อธิบายด้านล่าง

## **อ่านคุณสมบัติสาธารณะจากการนำเสนอที่เข้ารหัส**

รหัสผ่านเปิดไฟล์ปกติจะปกป้องทั้งเนื้อหาและคุณสมบัติเอกสารของการนำเสนอ เมื่อการนำเสนอถูกเข้ารหัสโดยส่งค่า `false` ไปยัง [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) คุณสมบัติเอกสารจะยังคงเป็นสาธารณะ แอปพลิเคชันสามารถส่งค่า `true` ไปยัง [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) และอ่านเมตาดาต้าสาธารณะโดยไม่ต้องให้รหัสผ่านเปิดไฟล์

ตัวเลือก “document‑properties‑only” ควบคุมสิ่งที่ Aspose.Slides โหลด; มันไม่ได้ถอดรหัสอะไรเลย หากคุณสมบัติกำหนดให้เข้ารหัส การโหลดโดยไม่มีรหัสผ่านจะล้มเหลว หากการนำเสนอไม่ได้เข้ารหัส ตัวเลือกจะถูกละเลยและการนำเสนอทั้งหมดจะถูกโหลด

ตัวอย่างต่อไปนี้ตรวจสอบโหมดการโหลดผ่าน [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) แล้วอ่านคุณสมบัติ built‑in ผ่าน [Presentation.getDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getDocumentProperties):

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

ในโหมดนี้ เนื้อหาแถบสไลด์จะไม่ถูกโหลด สไลด์, มาสเตอร์, เลย์เอาต์, รูปร่าง, สื่อ, และวัตถุต่าง ๆ ของการนำเสนอจะไม่พร้อมใช้งาน แอปพลิเคชันควรตรวจสอบ [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/th/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) เสมอก่อนทำการดำเนินการที่ต้องการโมเดลวัตถุของการนำเสนอทั้งหมด

{{% alert color="warning" title="คำเตือน" %}}
เมตาดาต้าสาธารณะอาจเปิดเผยชื่อผู้เขียน, ชื่อเรื่อง, หัวข้อ, คำสำคัญ, ข้อมูลบริษัท, ความคิดเห็น, และค่าที่กำหนดเอง ควรเข้ารหัสคุณสมบัติที่เป็นความลับพร้อมกับการนำเสนอ ให้เป็นสาธารณะเฉพาะเมื่อระบบการทำดัชนี, การจัดประเภท, ค้นหา หรือระบบการจัดการเอกสารมีความต้องการเฉพาะที่จะเข้าถึงโดยไม่ต้องใช้รหัสผ่าน
{{% /alert %}}

## **อัปเดตคุณสมบัติของการนำเสนอที่เข้ารหัส**

สำหรับไฟล์ PPTX ที่เข้ารหัส การนำเสนอที่โหลดในโหมด “document‑properties‑only” มีจุดประสงค์เพื่ออ่านเมตาดาต้าสาธารณะ Aspose.Slides ไม่สามารถบันทึกการเปลี่ยนแปลงคุณสมบัติต่าง ๆ จากออบเจกต์ที่มีเฉพาะเมตาดาต้าได้ เนื่องจากคุณสมบัติสาธารณะต้องสอดคล้องกับข้อมูลที่อยู่ภายในการนำเสนอที่เข้ารหัส การอัปเดตจึงต้องใช้รหัสผ่านเปิดไฟล์ที่ถูกต้องและทำการโหลดแบบสมบูรณ์

ตัวอย่างต่อไปนี้เปิดการนำเสนอด้วย [LoadOptions.setPassword](https://reference.aspose.com/slides/th/python-java/aspose.slides/loadoptions/#setPassword), อัปเดตคุณสมบัติ built‑in สาธารณะ, และบันทึกผลลัพธ์ แล้วใช้ [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#isEncrypted) เพื่อตรวจสอบว่าการเข้ารหัสยังคงอยู่และเปิดเมตาดาต้าสาธารณะโดยไม่มีรหัสผ่านเพื่อยืนยันค่าที่ใหม่:

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

หากแอปพลิเคชันไม่ได้รับอนุญาตให้ถอดรหัสหรือโหลดเนื้อหาการนำเสนอ จะต้องถือคุณสมบัติสาธารณะของไฟล์ PPTX ที่เข้ารหัสเป็นแบบอ่าน‑อย่างเดียว

## **เข้าถึงคุณสมบัติ Built‑in**

คุณสมบัติ built‑in ที่เปิดให้เข้าถึงโดย [DocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/) มีดังนี้: **Creator** (ผู้เขียน), **Description**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ครั้งสุดท้าย), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตคนอื่นหรือไม่?), **PresentationFormat**, **Subject**, และ **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของการนำเสนอ
presentation = Presentation("Presentation.pptx")
try:
    # สร้างการอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    properties = presentation.getDocumentProperties()

    # แสดงคุณสมบัติ built-in
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **แก้ไขคุณสมบัติ Built‑in**

การแก้ไขคุณสมบัติ built‑in ทำได้ง่ายเหมือนการเข้าถึง ใช้ตัวตั้งค่า (setter) ที่สอดคล้องกันเพื่อกำหนดค่าที่ใหม่ ตัวอย่างต่อไปนี้แก้ไขคุณสมบัติเอกสาร built‑in ด้วย Aspose.Slides for Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # สร้างการอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    properties = presentation.getDocumentProperties()

    # ตั้งค่าคุณสมบัติ built-in
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # บันทึกการนำเสนอของคุณลงไฟล์
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตัวอย่างนี้แก้ไขคุณสมบัติ built‑in ของการนำเสนอซึ่งแสดงผลดังแสดงด้านล่าง:

|**คุณสมบัติเอกสาร Built‑in หลังการแก้ไข**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **เพิ่มคุณสมบัติเอกสารแบบกำหนดเอง**

Aspose.Slides for Python via Java ยังอนุญาตให้ผู้พัฒนาสร้างคุณสมบัติเอกสารแบบกำหนดเองให้กับการนำเสนอ ตัวอย่างด้านล่างเพิ่มคุณสมบัติแบบกำหนดเองสามรายการ แล้วค้นหาชื่อที่เก็บไว้ที่ดัชนี 2 และลบคุณสมบัตินั้น ดังนั้นการนำเสนอที่บันทึกไว้จะเหลือสองรายการ คุณสมบัติแบบกำหนดเองจะเรียงลำดับตามตัวอักษร ไม่ใช่ตามลำดับที่เพิ่ม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ดึงคุณสมบัติเอกสาร
    properties = presentation.getDocumentProperties()

    # เพิ่มคุณสมบัติแบบกำหนดเอง
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # ดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    property_name = properties.getCustomPropertyName(2)

    # ลบคุณสมบัติที่เลือก
    properties.removeCustomProperty(property_name)

    # บันทึกการนำเสนอ
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**คุณสมบัติเอกสารแบบกำหนดเองที่เพิ่ม**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง**

Aspose.Slides for Python via Java ยังอนุญาตให้ผู้พัฒนาดึงค่าของคุณสมบัติแบบกำหนดเอง ตัวอย่างต่อไปนี้แสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเองทั้งหมดในการนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # สร้างการอ้างอิงถึงอ็อบเจ็กต์ DocumentProperties ที่เชื่อมโยงกับ Presentation
    properties = presentation.getDocumentProperties()

    # เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # แก้ไขค่าของคุณสมบัติแบบกำหนดเอง
        properties.set_Item(property_name, f"New Value {i + 1}")

    # บันทึกการนำเสนอของคุณลงไฟล์
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตัวอย่างนี้แก้ไขคุณสมบัติแบบกำหนดเองของการนำเสนอ [PPTX](https://docs.fileformat.com/presentation/pptx/) รูปภาพต่อไปนี้แสดงคุณสมบัติแบบกำหนดเองของการนำเสนอก่อนและหลังการแก้ไข:

|**คุณสมบัติแบบกำหนดก่อนการแก้ไข**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**คุณสมบัติแบบกำหนดหลังการแก้ไข**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **คุณสมบัติเอกสารขั้นสูง**

{{% alert color="info" title="หมายเหตุ" %}}
เมธอดใหม่ [readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), และ [writeBindedPresentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) ถูกเพิ่มเข้าสู่คลาส [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/), และพฤติกรรมของเมธอด [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#setLastSavedTime) ได้เปลี่ยนแปลง
{{% /alert %}}

เมธอดใหม่สองตัว [readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) และ [updateDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) ถูกเพิ่มเข้าสู่คลาส [PresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/) พวกมันให้การเข้าถึงคุณสมบัติโดกุment อย่างรวดเร็วและอนุญาตให้คุณเปลี่ยนแปลงและอัปเดตคุณสมบัติโดยไม่ต้องโหลดการนำเสนอทั้งหมด

กระบวนการทำงานทั่วไปของการโหลดคุณสมบัติ, เปลี่ยนค่า, และอัปเดตเอกสารสามารถทำได้ดังนี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# อ่านข้อมูลการนำเสนอ
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# ดึงคุณสมบัติปัจจุบัน
properties = presentation_info.readDocumentProperties()

# ตั้งค่าค่าตัวใหม่ของฟิลด์ Author และ Title
properties.setAuthor("New Author")
properties.setTitle("New Title")

# อัปเดตการนำเสนอด้วยค่าตัวใหม่
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

มีวิธีอีกแบบหนึ่งที่ใช้คุณสมบัติของการนำเสนอหนึ่งเป็นแม่แบบเพื่ออัปเดตคุณสมบัติในการนำเสนออื่น ๆ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

สามารถสร้างแม่แบบใหม่จากศูนย์แล้วใช้เพื่ออัปเดตหลายการนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มีเมธอด [PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#setLanguageId) ให้คุณตั้งค่าภาษา proofing สำหรับเอกสาร PowerPoint ภาษา proofing คือภาษาที่ใช้ตรวจสอบการสะกดและไวยากรณ์ของการนำเสนอ

โค้ด Python นี้แสดงวิธีการตั้งค่าภาษา proofing สำหรับ PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # ตั้งค่า Id ของภาษาตรวจสอบ

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด Python นี้แสดงวิธีการตั้งค่าภาษาเริ่มต้นสำหรับการนำเสนอ PowerPoint ทั้งหมด:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # เพิ่มรูปสี่เหลี่ยมผืนผ้าพร้อมข้อความ
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # ตรวจสอบภาษาของ portion แรก
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติเอกสารผ่าน Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built‑in จากการนำเสนอได้อย่างไร?**

คุณสมบัติ built‑in เป็นส่วนที่ไม่แยกจากการนำเสนอและไม่สามารถลบออกได้โดยสมบูรณ์ อย่างไรก็ตาม คุณสามารถเปลี่ยนค่า หรือกำหนดเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต

**จะเกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว?**

หากคุณเพิ่มคุณสมบัติแบบกำหนดเองที่มีอยู่แล้ว ค่าเดิมจะถูกเขียนทับด้วยค่าที่ใหม่ ไม่จำเป็นต้องลบหรือเช็คคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าโดยอัตโนมัติ

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอทั้งหมดได้หรือไม่?**

ได้ ใช้ [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/#getPresentationInfo) แล้วตามด้วย [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationinfo/#readDocumentProperties) เพื่ออ่านเมตาดาต้าเอกสารที่จัดเก็บไว้โดยไม่ต้องสร้างอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ดูตัวอย่างการรายงานทั้งหมดและข้อจำกัดตามรูปแบบได้ใน [Build a Lightweight Presentation Inventory](/slides/th/python-java/examine-presentation/)

**ฉันสามารถอ่านคุณสมบัติสาธารณะของการนำเสนอที่เข้ารหัสโดยไม่ต้องใช้รหัสผ่านเปิดไฟล์ได้หรือไม่?**

ได้ การเข้ารหัสคุณสมบัติเอกสารต้องถูกปิดไว้ก่อนที่การนำเสนอจะถูกเข้ารหัส และการนำเสนอจะต้องถูกโหลดในโหมด “document‑properties‑only”

**ฉันสามารถอัปเดตไฟล์ PPTX ที่เข้ารหัสในโหมด “document‑properties‑only” ได้หรือไม่?**

ไม่ได้ คุณสมบัติสาธารณะและคุณสมบัติที่เข้ารหัสต้องคงความสอดคล้องกัน ดังนั้นการอัปเดตไฟล์ PPTX ที่เข้ารหัสต้องโหลดการนำเสนอเต็มรูปแบบพร้อมรหัสผ่านเปิดไฟล์ที่ถูกต้อง