---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย Python
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/python-net/managing-tags-and-custom-data/
keywords:
- คุณสมบัติเอกสาร
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
description: "เรียนรู้วิธีจัดการแท็กและข้อมูล XML กำหนดเองในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET รวมถึงการเพิ่ม, การอ่าน, การอัปเดต, การตรวจสอบ, และการลบส่วน XML กำหนดเอง."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีที่ Aspose.Slides ทำงานกับแท็กและข้อมูลที่กำหนดเองในงานนำเสนอ PowerPoint ข้อมูลเฉพาะของงานนำเสนอสามารถจัดเก็บเป็นแท็กหรือส่วน XML กำหนดเองได้ แท็กเป็นคู่คีย์‑ค่าแบบสตริงที่ง่าย ในขณะที่ส่วน XML กำหนดเองสามารถเก็บเมตาดาต้าแบบมีโครงสร้างและข้อมูล XML เฉพาะแอปพลิเคชันได้

Aspose.Slides มี API สำหรับการเพิ่ม, อ่าน, ปรับปรุง, ตรวจสอบและลบส่วน XML กำหนดเองในระดับงานนำเสนอ, สไลด์และรูปร่าง ส่วน XML กำหนดเองมีประโยชน์สำหรับการรวมที่ต้องจัดเก็บข้อมูลเช่น ตัวระบุการจัดการเอกสาร, สถานะเวิร์กโฟลว์, เมตาดาต้าตามข้อกำหนด, ข้อมูลการผูกเทมเพลต หรือข้อมูลแอปพลิเคชันที่มีโครงสร้างอื่น ๆ ภายในงานนำเสนอ

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล `.pptx` — จะถูกเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML Office Open XML กำหนดโครงสร้างแพ็กเกจและความสัมพันธ์ที่ใช้เก็บเนื้อหางานนำเสนอและข้อมูลที่เกี่ยวข้อง

งานนำเสนอประกอบด้วยหลายส่วนที่เชื่อมต่อกันด้วยความสัมพันธ์ ตัวอย่างเช่น ส่วนสไลด์จะบรรจุเนื้อหาของสไลด์เดียวและอาจมีความสัมพันธ์อย่างชัดเจนกับส่วนอื่น ๆ ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเองสามารถจัดเก็บเป็นแท็ก ([TagCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/)) หรือส่วน XML กำหนดเอง ([CustomXmlPartCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpartcollection/)) ทั้งสองแบบใช้ได้ผ่านคลาส [`CustomData`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customdata/)

{{% alert color="primary" %}}
แท็กจัดเก็บคู่คีย์‑ค่าแบบสตริงง่าย ๆ ส่วน XML กำหนดเองจัดเก็บข้อมูล XML ที่มีโครงสร้างและสามารถเชื่อมโยงกับงานนำเสนอ, สไลด์ หรือรูปร่างได้
{{% /alert %}}

## **ทำงานกับส่วน XML กำหนดเอง**

คุณสมบัติ [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customdata/custom_xml_parts/) คืนค่าคอลเลกชันของส่วน XML กำหนดเองที่เชื่อมโยงกับวัตถุงานนำเสนอเฉพาะ ตัวอย่างเช่น:

- `presentation.custom_data.custom_xml_parts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับงานนำเสนอเอง
- `slide.custom_data.custom_xml_parts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับสไลด์เฉพาะ
- `shape.custom_data.custom_xml_parts` มีส่วน XML กำหนดเองที่เชื่อมโยงกับรูปร่างเฉพาะ

ใช้ [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/all_custom_xml_parts/) เมื่อต้องการตรวจสอบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอโดยไม่คำนึงว่ามันเชื่อมโยงกับวัตถุใด

### **เพิ่มส่วน XML กำหนดเองไปยังงานนำเสนอ**

ใช้ [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpartcollection/add/) เพื่อเพิ่มข้อมูล XML ไปยังคอลเลกชันส่วน XML กำหนดเอง XML ต้องเป็นที่ถูกต้องและไม่ว่างเปล่า

ตัวอย่างต่อไปนี้เพิ่มเมตาดาต้าแบบมีโครงสร้างไปยังคอลเลกชันข้อมูลกำหนดเองระดับงานนำเสนอ:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # การเพิ่มจะกำหนดตัวระบุโดยอัตโนมัติ ตั้งค่า GUID เฉพาะเมื่อต้องการเท่านั้น.
    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

เมธอด `add` ยังรับ XML ในรูปแบบอาเรย์ไบต์หรือสตรีมได้ ซึ่งมีประโยชน์เมื่อเนื้อหา XML มีอยู่แล้วในรูปไบต์

### **เพิ่มส่วน XML กำหนดเองไปยังสไลด์หรือรูปร่าง**

ข้อมูล XML กำหนดเองสามารถเชื่อมโยงกับสไลด์หรือรูปร่างเฉพาะแทนการเชื่อมโยงกับงานนำเสนอทั้งหมด ซึ่งมีประโยชน์เมื่อเมตาดาต้าอธิบายเพียงอ็อบเจ็กต์เดียว เช่น คีย์เทมเพลต, ตัวระบุบันทึกภายนอก หรือข้อมูลการผูก

ตัวอย่างต่อไปนี้เพิ่มส่วน XML กำหนดเองหนึ่งส่วนไปยังสไลด์และอีกส่วนหนึ่งไปยังรูปร่าง:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

ระดับที่ส่วนถูกเพิ่มจะกำหนดว่าคอลเลกชัน `custom_data.custom_xml_parts` ของอ็อบเจ็กต์ใดบรรจุความสัมพันธ์กับส่วนนั้น ข้อมูลระดับงานนำเสนอเหมาะสำหรับเมตาดาต้าทั่วเอกสาร, ข้อมูลระดับสไลด์สำหรับข้อมูลที่เป็นของสไลด์นั้น ๆ, และข้อมูลระดับรูปร่างสำหรับเมตาดาต้าที่เชื่อมโยงกับรูปร่างเฉพาะ

### **แสดงรายการและตรวจสอบส่วน XML กำหนดเองทั้งหมด**

ใช้ [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/all_custom_xml_parts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดจากงานนำเสนอ แต่ละ [`CustomXmlPart`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpart/) จะเปิดเผยตัวระบุ, เนื้อหา XML และสคีมเนมสเปซที่เชื่อมโยง

ตัวอย่างต่อไปนี้แสดงรายการส่วน XML กำหนดเองทั้งหมดพร้อมสคีมเนมสเปซ:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpart/namespace_schemas/) คืนค่าสคีม XML ที่เชื่อมโยงกับส่วน XML กำหนดเอง ข้อมูลนี้อาจมีประโยชน์เมื่อตรวจสอบงานนำเสนอที่มี XML มาจากระบบภายนอก

### **อ่านและอัปเดตเนื้อหา XML และ ItemId**

ใช้ [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpart/xml_as_string/) เพื่อทำงานกับ XML เป็นสตริง UTF‑8 หรือใช้ [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpart/xml_data/) เพื่อทำงานกับไบต์ XML ดิบ ทั้งสองคุณสมบัติเสนอการอ่านและอัปเดตได้

คุณสมบัติ [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpart/item_id/) มี GUID ที่ระบุส่วน XML กำหนดเองในเอกสาร Office Open XML สามารถเปลี่ยนได้เมื่อการบูรณาการต้องการตัวระบุใหม่

ตัวอย่างต่อไปนี้อัปเดตเนื้อหา XML และตัวระบุ:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # อ่าน XML ปัจจุบันเป็นข้อความ.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # อัปเดต XML เป็นสตริง UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data ให้เนื้อหา XML เดียวกันเป็นไบต์ดิบ.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # แทนที่ตัวระบุเมื่อต้องการโดยการบูรณาการ.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

เมื่อกำหนด `xml_as_string` หรือ `xml_data` ให้ใช้ XML ที่ถูกต้องและไม่ว่างเปล่า ใช้แบบใดแบบหนึ่งตามว่าการประมวลผลของแอปพลิเคชันทำงานกับสตริงหรือไบต์เป็นหลัก

### **ลบส่วน XML กำหนดเอง**

Aspose.Slides มีวิธีลบข้อมูล XML กำหนดเองหลายวิธี:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpart/remove/) ลบส่วน XML กำหนดเองจากงานนำเสนอ
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpartcollection/remove/) ลบส่วนเฉพาะจากคอลเลกชันส่วน XML กำหนดเอง
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpartcollection/remove_at/) ลบส่วนที่ตำแหน่งดัชนีที่กำหนดในคอลเลกชัน
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/th/python-net/aspose.slides/customxmlpartcollection/clear/) ลบทุกส่วนจากคอลเลกชันที่ระบุ

ตัวอย่างต่อไปนี้ลบส่วน XML กำหนดเองระดับงานนำเสนอหนึ่งส่วนโดยอ้างอิง:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

หากคุณมี `CustomXmlPart` อยู่แล้วและต้องการลบส่วนนั้นจากงานนำเสนอแทนการอ้างอิงคอลเลกชันใด ๆ ให้เรียก `custom_xml_part.remove()`  

คุณยังสามารถลบรายการโดยดัชนีได้:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **ลบส่วน XML กำหนดเองทั้งหมดจากคอลเลกชัน**

ใช้ `clear` เมื่อส่วน XML กำหนดเองทั้งหมดที่เชื่อมโยงกับอ็อบเจ็กต์งานนำเสนอใดงานนำเสนอหนึ่งควรถูกลบ

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` มีผลต่อคอลเลกชันที่เลือกเท่านั้น ตัวอย่างเช่น การล้างคอลเลกชันของสไลด์ไม่ทำให้คอลเลกชันระดับงานนำเสนอหรือระดับรูปร่างถูกล้าง

เพื่อลบส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ ให้วนลูปผ่าน `all_custom_xml_parts` แล้วลบแต่ละส่วน:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **จัดการส่วน XML กำหนดเองที่เชื่อมโยงหรือใช้ร่วมกัน**

ในงานนำเสนอ Office Open XML ส่วน XML กำหนดเองเดียวกันอาจถูกอ้างอิงจากอ็อบเจ็กต์งานนำเสนอหลายตัว ตัวอย่างเช่น ไฟล์ที่มีอยู่แล้วอาจมีความสัมพันธ์จากหลายสไลด์หรือรูปร่างไปยังส่วน XML กำหนดเองเดียวกัน

ส่วนที่ใช้ร่วมควรถือเป็นอ็อบเจ็กต์ข้อมูลเดียวกับการอ้างอิงหลายครั้ง:

- การอัปเดต `xml_as_string`, `xml_data` หรือ `item_id` จะเปลี่ยนส่วน XML กำหนดเองพื้นฐาน ดังนั้นการเปลี่ยนแปลงจะส่งผลทุกที่ที่ส่วนนั้นถูกอ้างอิง
- `item_id` สามารถใช้ระบุส่วน XML กำหนดเองเดียวกันขณะตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์
- การลบส่วนจากคอลเลกชัน `custom_xml_parts` เฉพาะจะลบออกจากคอลเลกชันนั้น ใช้ `CustomXmlPart.remove()` เมื่อส่วนนั้นควรถูกลบจากงานนำเสนอทั้งหมด
- ก่อนลบหรือแทนที่ส่วนที่ใช้ร่วม ควรตรวจสอบคอลเลกชันระดับอ็อบเจ็กต์เพื่อดูว่ายังมีสไลด์หรือรูปร่างอื่นอ้างอิงอยู่หรือไม่

โอเวอร์โหลด `add` สร้างส่วน XML กำหนดเองใหม่จากเนื้อหา XML ไม่รับ `CustomXmlPart` ที่มีอยู่ ดังนั้นความสัมพันธ์ที่ใช้ร่วมมักพบเมื่อลดโหลดงานนำเสนอที่มีส่วนเหล่านั้นแล้ว

ตัวอย่างต่อไปนี้ตรวจสอบคอลเลกชันระดับงานนำเสนอ, สไลด์, และรูปร่างโดย `item_id` และรายงานส่วนที่อ้างอิงจากตำแหน่งมากกว่าหนึ่งแห่ง:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

การตรวจสอบแบบนี้มีประโยชน์ก่อนทำการแก้ไขหรือลบข้อมูล XML กำหนดเองในงานนำเสนอที่สร้างโดยระบบภายนอก เนื่องจากส่วนเมตาดาต้าเดียวกันอาจมีส่วนร่วมในหลายความสัมพันธ์

## **รับค่าของแท็ก**

ใน Slides แท็กสอดคล้องกับคุณสมบัติ `DocumentProperties.keywords` ตัวอย่างโค้ดนี้แสดงวิธีรับค่าของแท็กด้วย Aspose.Slides for Python via .NET สำหรับ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **เพิ่มแท็กลงในงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กลงในงานนำเสนอ แท็กทั่วไปประกอบด้วยสองรายการ:

- ชื่อของคุณสมบัติกำหนดเอง ตัวอย่าง `MyTag`
- ค่า ของคุณสมบัติกำหนดเอง ตัวอย่าง `My Tag Value`

หากต้องการจัดประเภทงานนำเสนอตามกฎหรือคุณสมบัติเฉพาะ คุณสามารถเพิ่มแท็กเพื่อจุดประสงค์นั้นได้ ตัวอย่างเช่น หากต้องการแบ่งประเภทงานนำเสนอจากประเทศในอเมริกาเหนือ คุณสามารถสร้างแท็ก North American แล้วกำหนดค่าประเทศที่เกี่ยวข้องเป็นค่าแท็ก

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่มแท็กไปยัง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ด้วย Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

สามารถตั้งค่าแท็กสำหรับ [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) ได้เช่นกัน:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) แยกแต่ละออบเจ็กต์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `custom_data.tags` จะถูกจัดเก็บเฉพาะในไฟล์ PowerPoint เท่านั้น **ไม่** ถูกโอนย้ายไปยังโครงสร้างแท็ก PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**วิธีแก้**: คุณสามารถเก็บตัวระบุกำหนดเองใน **Alt Text** ของออบเจ็กต์ (เช่น `shape.alternative_text = "MyId"`) หลังจากส่งออกเป็น PDF Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ, สไลด์ หรือรูปร่างในการดำเนินการหนึ่งได้หรือไม่?**

ได้. คอลเลกชัน [tag collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/) รองรับการทำงาน [clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/clear/) ที่ลบคีย์‑ค่าทั้งหมดพร้อมกัน

**ฉันจะลบแท็กเดียวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปผ่านคอลเลกชันทั้งหมดได้อย่างไร?**

ใช้ [remove(name)](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/) เพื่อลบแท็กตามคีย์

**ฉันจะดึงรายการชื่อแท็กทั้งหมดสำหรับการวิเคราะห์หรือการกรองได้อย่างไร?**

ใช้ [get_names_of_tags](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/get_names_of_tags/) บน [tag collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/) จะส่งกลับอาร์เรย์ของชื่อแท็กทั้งหมด

**ฉันจะค้นหาส่วน XML กำหนดเองทั้งหมดโดยไม่คำนึงว่ามันถูกจัดเก็บที่ไหน?**

ใช้ [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/all_custom_xml_parts/) เพื่อดึงส่วน XML กำหนดเองทั้งหมดในงานนำเสนอ

**ควรใช้ `xml_as_string` หรือ `xml_data` เพื่ออัปเดตส่วน XML กำหนดเอง?**

ใช้ `xml_as_string` เมื่อแอปพลิเคชันทำงานกับข้อความ XML UTF‑8 ใช้ `xml_data` เมื่อ XML มีอยู่แล้วในรูปอาเรย์ไบต์หรือการประมวลผลแบบไบต์สะดวกกว่า ทั้งสองคุณสมบัติเชิงอธิบายเนื้อหา XML ของส่วน XML กำหนดเองเดียวกัน