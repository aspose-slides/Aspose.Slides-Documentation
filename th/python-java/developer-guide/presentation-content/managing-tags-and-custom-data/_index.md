---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย Python
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/python-java/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- XML กำหนดเอง
- ส่วน XML กำหนดเอง
- เมตาดาต้า XML
- ItemId
- เพิ่มแท็ก
- ค่าคู่
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java รวมถึงการเพิ่ม, การอ่าน, การอัปเดต, การตรวจสอบ, และการลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร ข้อมูลเฉพาะของงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML กำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วนส่วน XML กำหนดเองสามารถเก็บเมทาดาต้าแบบมีโครงสร้างและข้อมูล XML ที่เฉพาะต่อแอปพลิเคชัน

Aspose.Slides มี API สำหรับการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบ, และลบส่วน XML กำหนดเองในระดับงานนำเสนอ, สไลด์, และรูปร่าง ส่วน XML กำหนดเองมีประโยชน์สำหรับการรวมระบบที่จัดเก็บข้อมูล เช่น ตัวระบุการจัดการเอกสาร, สถานะของกระบวนการทำงาน, เมทาดาต้าการปฏิบัติตาม, ข้อมูลการผูกเทมเพลต, หรือข้อมูลแอปพลิเคชันแบบมีโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีส่วนขยาย `.pptx` — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML. Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้เก็บเนื้อหาของงานนำเสนอและข้อมูลที่เกี่ยวข้อง

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์ถือเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์ที่ชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเองสามารถจัดเก็บเป็นแท็ก ([TagCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/tagcollection/)) หรือส่วน XML กำหนดเอง ([CustomXmlPartCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/)) ทั้งสองแบบสามารถเข้าถึงได้ผ่านคลาส [CustomData](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/)

{{% alert color="info" title="Note" %}}
แท็กจัดเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วน XML กำหนดเองจัดเก็บข้อมูล XML แบบมีโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์, หรือรูปร่าง
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

เมธอด [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/#getCustomXmlParts) จะคืนค่าคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอเฉพาะ ตัวอย่างเช่น:

- คอลเลกชัน [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/#getCustomXmlParts) ของงานนำเสนอจะมีส่วน XML กำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- คอลเลกชัน [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/#getCustomXmlParts) ของสไลด์จะมีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์นั้น
- คอลเลกชัน [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/#getCustomXmlParts) ของรูปร่างจะมีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปร่างนั้น

ใช้ [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getAllCustomXmlParts) เมื่อคุณต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่าถูกเชื่อมโยงที่ไหน

### **เพิ่มส่วน XML กำหนดเองไปยังงานนำเสนอ**

ใช้ [CustomXmlPartCollection.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#add) เพื่อเพิ่มข้อมูล XML ไปยังคอลเลกชันส่วน XML กำหนดเอง XML ต้องเป็น XML ที่สมบูรณ์และไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมทาดาต้าแบบมีโครงสร้างไปยังคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # การเพิ่มจะกำหนดตัวระบุโดยอัตโนมัติ ตั้งค่า UUID เฉพาะเมื่อจำเป็นเท่านั้น.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เมธอด [add](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#add) สามารถรับ XML เป็นอาร์เรย์ของไบต์หรือสตรีมอินพุตได้ ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปแบบไบนารี

### **เพิ่มส่วน XML กำหนดเองไปยังสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปร่างเฉพาะแทนที่จะเป็นงานนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อเมทาดาต้าอธิบายเพียงอ็อบเจ็กต์เดียว เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก, หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนไปยังสไลด์และอีกส่วนหนึ่งไปยังรูปร่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/#getCustomXmlParts) ของอ็อบเจ็กต์ใดจะมีความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะกับเมทาดาต้าทั่วเอกสาร, ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์นั้น, และข้อมูลระดับรูปร่างสำหรับเมทาดาต้าที่เชื่อมโยงกับรูปร่างแต่ละรูป

### **รายการและตรวจสอบส่วน XML กำหนดเองทั้งหมด**

ใช้ [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getAllCustomXmlParts) เพื่อดึงส่วน XML กำหนดเองทั้งหมดจากงานนำเสนอ แต่ละ [CustomXmlPart](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/) จะเปิดเผยตัวระบุ, เนื้อหา XML, และสคีมาเนมสเปซที่สัมพันธ์

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดเองทั้งหมดและสคีมาเนมสเปซของพวกมัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) คืนค่าสกีม่า XML ที่สัมพันธ์กับส่วน XML กำหนดเอง ข้อมูลนี้มีประโยชน์เมื่อทำการตรวจสอบงานนำเสนอที่มี XML ที่สร้างโดยระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#getXmlAsString) และ [setXmlAsString](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setXmlAsString) เพื่อทำงานกับ XML เป็นสตริง UTF‑8 หรือใช้ [getXmlData](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#getXmlData) และ [setXmlData](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setXmlData) เพื่อทำงานกับไบต์ XML ดิบ

เมธอด [CustomXmlPart.getItemId](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#getItemId) คืนค่า UUID ที่ระบุส่วน XML กำหนดเองในเอกสาร Office Open XML ใช้ [setItemId](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setItemId) เมื่อการรวมระบบต้องการตัวระบุใหม่

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # อ่าน XML ปัจจุบันเป็นข้อความ.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # อัปเดต XML เป็นสตริง UTF-8.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData ให้เนื้อหา XML เดียวกันเป็นไบต์ดิบ.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # แทนที่ตัวระบุเมื่อการรวมระบบต้องการ.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

เมื่อเรียกใช้ [setXmlAsString](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setXmlAsString) หรือ [setXmlData](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setXmlData), ให้ส่ง XML ที่ถูกต้องและไม่ว่างเปล่า ใช้รูปแบบใดรูปแบบหนึ่งตามที่แอปพลิเคชันทำงานหลักกับสตริงหรือข้อมูลไบต์

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides มีวิธีหลายอย่างในการลบข้อมูล XML กำหนดเอง:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#remove) ลบส่วน XML กำหนดเองออกจากงานนำเสนอ
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#remove) ลบส่วนที่ระบุออกจากคอลเลกชันส่วน XML กำหนดเอง
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#removeAt) ลบส่วนที่ตำแหน่งดัชนีที่ระบุในคอลเลกชัน
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#clear) ลบส่วนทั้งหมดออกจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML กำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หากคุณมี [CustomXmlPart](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/) อยู่แล้วและต้องการลบส่วนนั้นจากงานนำเสนอแทนการอ้างอิงคอลเลกชันเฉพาะ ให้เรียก [CustomXmlPart.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#remove)

คุณยังสามารถลบรายการโดยใช้ดัชนีได้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **ล้างส่วน XML กำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ [clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#clear) เมื่อส่วน XML กำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอที่ระบุควรถูกลบ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#clear) มีผลเฉพาะต่อคอลเลกชันที่เลือก ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์จะไม่ล้างคอลเลกชันระดับงานนำเสนอหรือระดับรูปร่าง

เพื่อที่จะลบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ ให้วนลูปผ่าน [getAllCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getAllCustomXmlParts) และลบแต่ละส่วน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **จัดการส่วน XML กำหนดเองที่เชื่อมโยงหรือแชร์**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเองเดียวกันอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอมากกว่าหนึ่งอัน ตัวอย่างเช่น ไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML กำหนดเองพื้นฐานเดียวกัน

ส่วนที่แชร์ควรถือเป็นอ็อบเจ็กต์ข้อมูลหนึ่งเดียวที่มีการอ้างอิงหลายครั้ง:

- การอัปเดตด้วย [setXmlAsString](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setXmlData) หรือ [setItemId](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#setItemId) จะเปลี่ยนส่วน XML กำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะปรากฏทุกที่ที่ส่วนนั้นถูกอ้างอิง
- สามารถใช้ [getItemId](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#getItemId) เพื่อระบุส่วน XML กำหนดเองเดียวกันขณะตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน [getCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/#getCustomXmlParts) เฉพาะจะลบออกจากคอลเลกชันนั้น ใช้ [CustomXmlPart.remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpart/#remove) เมื่อส่วนควรถูกลบออกจากงานนำเสนอทั้งหมด
- ก่อนที่จะลบหรือแทนที่ส่วนที่แชร์ ควรตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่าสไลด์หรือรูปร่างอื่นยังอ้างอิงมันอยู่หรือไม่

เมธอด [add](https://reference.aspose.com/slides/th/python-java/aspose.slides/customxmlpartcollection/#add) overload จะสร้างส่วน XML กำหนดใหม่จากเนื้อหา XML; ไม่รับ [CustomXmlPart] ที่มีอยู่ ดังนั้นความสัมพันธ์ที่แชร์มักพบเมื่อโหลดงานนำเสนอที่มีอยู่แล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์, และรูปร่างโดยใช้ `ItemId` และรายงานส่วนที่ถูกอ้างอิงจากหลายตำแหน่ง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

การตรวจสอบแบบนี้มีประโยชน์ก่อนการแก้ไขหรือการลบข้อมูล XML กำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมทาดาต้าเดียวกันอาจมีส่วนร่วมในความสัมพันธ์หลายรายการ

## **รับค่าของแท็ก**

ในสไลด์ แท็กสอดคล้องกับเมธอด [DocumentProperties.getKeywords](https://reference.aspose.com/slides/th/python-java/aspose.slides/documentproperties/#getKeywords). ตัวอย่างโค้ดนี้แสดงวิธีดึงค่าของแท็กด้วย Aspose.Slides for Python via Java สำหรับ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **เพิ่มแท็กไปยังงานนำเสนอ**

Aspose.Slides ให้คุณเพิ่มแท็กไปยังงานนำเสนอ แท็กทั่วไปประกอบด้วยสองส่วน:
- ชื่อของคุณสมบัติที่กำหนดเอง เช่น `MyTag`;
- ค่าของคุณสมบัตินั้น เช่น `My Tag Value`.

หากคุณต้องการจัดประเภทงานนำเสนอโดยอิงกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อจุดประสงค์นั้น ตัวอย่างเช่น หากต้องการจัดประเภทงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็กอเมริกาเหนือและกำหนดค่าประเทศที่เกี่ยวข้องเป็นค่าแท็ก

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กไปยัง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) โดยใช้ Aspose.Slides for Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

แท็กสามารถตั้งค่าให้กับ [Slide](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/) ได้เช่นกัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) แต่ละอัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน [CustomData.getTags](https://reference.aspose.com/slides/th/python-java/aspose.slides/customdata/#getTags) จะถูกจัดเก็บไว้ในไฟล์ PowerPoint เท่านั้น ไม่ได้ **ถูก** ย้ายไปยังโครงสร้างแท็กของ PDF เมื่อส่งออกงานนำเสนอเป็น PDF ดังนั้น ตัวระบุกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองใน **Alt Text** ของอ็อบเจ็กต์ (เช่น [Shape.setAlternativeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setAlternativeText) ด้วยค่า `"MyId"`). หลังจากส่งออกเป็น PDF, Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในหนึ่งการดำเนินการได้หรือไม่?**

ได้. คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/tagcollection/) รองรับการดำเนินการ [clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/tagcollection/#clear) ซึ่งจะลบคู่คีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดี่ยวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปผ่านคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้ [remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/tagcollection/#remove) บน [tag collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/tagcollection/) เพื่อ删除แท็กโดยใช้คีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้ [getNamesOfTags](https://reference.aspose.com/slides/th/python-java/aspose.slides/tagcollection/#getNamesOfTags) บน [tag collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/tagcollection/); จะคืนค่าอาเรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML กำหนดเองทั้งหมดโดยไม่คำนึงว่าถูกเก็บที่ไหนได้อย่างไร?**

ใช้ [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getAllCustomXmlParts) เพื่อดึงส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ

**ฉันควรใช้ [getXmlAsString]/[setXmlAsString] หรือ [getXmlData]/[setXmlData] เพื่ออัปเดตส่วน XML กำหนดเองหรือไม่?**

ใช้ [getXmlAsString] และ [setXmlAsString] เมื่อแอปพลิเคชันทำงานกับข้อความ XML แบบ UTF‑8 ใช้ [getXmlData] และ [setXmlData] เมื่อ XML มีอยู่แล้วในรูปแบบอาร์เรย์ของไบต์ หรือเมื่อการประมวลผลแบบไบนารีสะดวกกว่าผลลัพธ์ ทั้งสองรูปแบบอ้างถึงเนื้อหา XML ของส่วน XML กำหนดเดียวกัน