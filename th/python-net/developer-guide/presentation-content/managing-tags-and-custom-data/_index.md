---
title: จัดการแท็กและข้อมูลกำหนดเองในงานนำเสนอด้วย Python
linktitle: แท็กและข้อมูลกำหนดเอง
type: docs
weight: 300
url: /th/python-net/managing-tags-and-custom-data/
keywords:
- คุณสมบัติของเอกสาร
- แท็ก
- ข้อมูลกำหนดเอง
- เพิ่มแท็ก
- ค่าแบบคู่
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่ม, อ่าน, ปรับปรุงและลบแท็กและข้อมูลกำหนดเองใน Aspose.Slides สำหรับ Python ผ่าน .NET พร้อมตัวอย่างสำหรับงานนำเสนอ PowerPoint และ OpenDocument"
---
## **ภาพรวม**

บทความนี้อธิบายว่า Aspose.Slides ทำงานกับแท็กและข้อมูลกำหนดเองในงานนำเสนอ PowerPoint อย่างไร โดยสรุปสั้น ๆ ว่าข้อมูลถูกจัดเก็บในไฟล์ PPTX อย่างไร และบันทึกว่าข้อมูลเฉพาะงานนำเสนอสามารถอยู่ในรูปแบบของแท็กและส่วน XML กำหนดเอง และอธิบายว่าแท็กเป็นคู่ค่าแบบคีย์‑ค่าเป็นสตริง

บทความยังแสดงวิธีการอ่านค่าของแท็กและวิธีการเพิ่มแท็กให้กับงานนำเสนอ สไลด์เดี่ยว หรือรูปร่าง นอกจากนี้ยังครอบคลุมงานจัดการแท็กทั่วไป เช่น การล้างแท็กทั้งหมด การลบแท็กตามชื่อ และการดึงรายการชื่อแท็ก

## **การจัดเก็บข้อมูลในไฟล์งานนำเสนอ**

ไฟล์ PPTX — ไฟล์ที่มีนามสกุล .pptx — ถูกจัดเก็บในรูปแบบ PresentationML ซึ่งเป็นส่วนหนึ่งของสเปค Office Open XML สเปค Office Open XML กำหนดโครงสร้างของข้อมูลที่อยู่ในงานนำเสนอ

กับ *slide* ซึ่งเป็นหนึ่งในส่วนประกอบของงานนำเสนอ *slide part* จะบรรจุเนื้อหาของสไลด์เดียว สไลด์พาร์ทสามารถมีความสัมพันธ์อย่างชัดเจนกับหลายส่วน — เช่น User Defined Tags — ตามที่กำหนดโดย ISO/IEC 29500

ข้อมูลกำหนดเอง (ที่เฉพาะเจาะจงต่อการนำเสนอ) หรือผู้ใช้สามารถอยู่ในรูปแบบของแท็ก ([ITagCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/itagcollection/)) และ CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/icustomxmlpartcollection/))

{{% alert color="primary" %}} 

แท็กโดยพื้นฐานเป็นค่าแบบคู่คีย์‑สตริง 

{{% /alert %}} 

## **รับค่าของแท็ก**

ใน slides แท็กสอดคล้องกับคุณสมบัติ IDocumentProperties.Keywords ตัวอย่างโค้ดนี้แสดงวิธีการดึงค่าของแท็กโดยใช้ Aspose.Slides for Python via .NET สำหรับ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **เพิ่มแท็กให้กับงานนำเสนอ**

Aspose.Slides อนุญาตให้คุณเพิ่มแท็กให้กับงานนำเสนอ แท็กทั่วไปประกอบด้วยสองส่วน:

- ชื่อของคุณสมบัติกำหนดเอง - `MyTag`
- ค่าของคุณสมบัติกำหนดเอง - `My Tag Value`

หากคุณต้องการจัดประเภทงานนำเสนอบางส่วนตามกฎหรือคุณสมบัติเฉพาะ คุณอาจได้รับประโยชน์จากการเพิ่มแท็กให้กับงานนำเสนนั้น ๆ ตัวอย่างเช่น หากต้องการจัดกลุ่มหรือนำงานนำเสนอจากประเทศในอเมริกาเหนือมารวมกัน คุณสามารถสร้างแท็ก “North American” แล้วกำหนดค่าของประเทศที่เกี่ยวข้อง (สหรัฐอเมริกา, เม็กซิโก และแคนาดา) เป็นค่า

ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มแท็กให้กับ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) โดยใช้ Aspose.Slides for Python via .NET :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

แท็กยังสามารถตั้งค่าสำหรับ [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

หรือสำหรับ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ใด ๆ :

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **ข้อจำกัด**

แท็กที่เพิ่มผ่านคอลเลกชัน `custom_data.tags` จะถูกเก็บไว้เฉพาะภายในไฟล์ PowerPoint เท่านั้น พวกมัน **ไม่** ถูกโอนย้ายไปยังโครงสร้างแท็กของ PDF เมื่อทำการส่งออกงานนำเสนอเป็น PDF ดังนั้นตัวระบุกำหนดเองที่กำหนดเป็นแท็กจะไม่สามารถดึงคืนจาก PDF ที่มีแท็กได้

**Workaround**: คุณสามารถเก็บตัวระบุกำหนดเองไว้ใน **Alt Text** ของวัตถุ (เช่น `shape.alternative_text = "MyId"`). หลังจากส่งออกเป็น PDF, Alt Text อาจปรากฏในโครงสร้างแท็กของ PDF

## **คำถามที่พบบ่อย**

**ฉันสามารถลบแท็กทั้งหมดจากงานนำเสนอ สไลด์ หรือรูปร่างพร้อมกันในหนึ่งการทำงานได้หรือไม่?**

ได้. คอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/)) รองรับการทำงาน [clear](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/clear/) ที่ลบคู่คีย์‑ค่าทั้งหมดในครั้งเดียว

**ฉันจะลบแท็กเดียวโดยใช้ชื่อของมันโดยไม่ต้องวนลูปคอลเลกชันทั้งหมดอย่างไร?**

ใช้การทำงาน [remove(name)](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/remove/) บน [TagCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/) เพื่อทำการลบแท็กตามคีย์ของมัน

**ฉันจะดึงรายการชื่อแท็กทั้งหมดเพื่อวิเคราะห์หรือกรองอย่างไร?**

ใช้ [get_names_of_tags](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/get_names_of_tags/) บนคอลเลกชันแท็ก ([tag collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/tagcollection/)); มันจะคืนค่าอาเรย์ของชื่อแท็กทั้งหมด