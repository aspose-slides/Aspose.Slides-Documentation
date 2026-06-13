---
title: จัดการคุณสมบัติการนำเสนอด้วย Python
linktitle: คุณสมบัติการนำเสนอ
type: docs
weight: 70
url: /th/python-net/presentation-properties/
keywords:
- คุณสมบัติ PowerPoint
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- คุณสมบัติในตัว
- คุณสมบัติแบบกำหนดเอง
- คุณสมบัติขั้นสูง
- จัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- ข้อมูลเมตาเอกสาร
- แก้ไขข้อมูลเมตา
- ภาษาการตรวจสอบ
- ภาษาพื้นฐาน
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides สำหรับ Python ผ่าน .NET และทำให้การค้นหา การสร้างแบรนด์ และกระบวนการทำงานในไฟล์ PowerPoint ของคุณเป็นระเบียบและมีประสิทธิภาพ"
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทของคุณสมบัตินี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides ให้คุณทำงานกับคุณสมบัติของเอกสารการนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/) คลาสนี้จะคืนค่าอินสแตนซ์โดยคุณสมบัติ [Presentation.document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/document_properties/). ตัวอย่างต่อไปนี้แสดงวิธีอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="primary" %}} 
โปรดทราบว่าคุณไม่สามารถตั้งค่าต่าง ๆ ให้กับฟิลด์ **Application** และ **Producer** ได้ เนื่องจาก Aspose Ltd. และ Aspose.Slides for Python via .NET x.x.x จะถูกแสดงในฟิลด์เหล่านี้.
{{% /alert %}} 

## **จัดการคุณสมบัติการนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์เพื่อเพิ่มคุณสมบัติบางอย่างลงในไฟล์การนำเสนอ คุณสมบัติเเหล่านี้ทำให้สามารถจัดเก็บข้อมูลที่มีประโยชน์ไว้พร้อมกับเอกสาร (ไฟล์การนำเสนอ) มีคุณสมบัติของเอกสารสองประเภทดังต่อไปนี้

- คุณสมบัติที่กำหนดโดยระบบ (Built-in) คุณสมบัติ
- คุณสมบัติที่ผู้ใช้กำหนด (Custom) คุณสมบัติ

**Built-in** properties มีข้อมูลทั่วไปเกี่ยวกับเอกสาร เช่น ชื่อเอกสาร, ชื่อผู้เขียน, สถิติของเอกสาร เป็นต้น. **Custom** properties คือคุณสมบัติที่ผู้ใช้กำหนดเป็นคู่ **Name/Value**, โดยทั้งชื่อและค่าจะถูกกำหนดโดยผู้ใช้. โดยใช้ Aspose.Slides for Python via .NET นักพัฒนาสามารถเข้าถึงและแก้ไขค่าของคุณสมบัติ built-in รวมถึง custom ได้. Microsoft PowerPoint 2007 ให้คุณจัดการคุณสมบัติของไฟล์การนำเสนอได้ เพียงคลิกไอคอน Office แล้วเลือกเมนู **Prepare | Properties | Advanced Properties** ของ Microsoft PowerPoint 2007. หลังจากคุณเลือกเมนู **Advanced Properties** จะปรากฏหน้าต่างที่ให้คุณจัดการคุณสมบัติของไฟล์ PowerPoint. ใน **Properties Dialog** คุณจะเห็นหลายแท็บเช่น **General, Summary, Statistics, Contents and Custom**. แท็บเหล่านี้ทั้งหมดช่วยให้กำหนดค่าข้อมูลที่แตกต่างกันที่เกี่ยวกับไฟล์ PowerPoint. แท็บ **Custom** ใช้สำหรับจัดการคุณสมบัติ custom ของไฟล์ PowerPoint.

## **เข้าถึงคุณสมบัติ Built-in**

คุณสมบัติเหล่านี้ที่เปิดเผยโดยอ็อบเจกต์ **IDocumentProperties** ประกอบด้วย: **Creator(Author)**, **Description**, **Keywords**, **Created** (วันที่สร้าง), **Modified** (วันที่แก้ไข), **Printed** (วันที่พิมพ์ครั้งล่าสุด), **LastModifiedBy**, **Keywords**, **SharedDoc** (แชร์ระหว่างผู้ผลิตต่าง ๆ?), **PresentationFormat**, **Subject** และ **Title**  
```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงการนำเสนอ
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # สร้างการอ้างอิงถึงอ็อบเจกต์ที่เชื่อมโยงกับ Presentation
    documentProperties = pres.document_properties

    # แสดงคุณสมบัติในตัว
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **แก้ไขคุณสมบัติ Built-in**

การแก้ไขคุณสมบัติ built-in ของไฟล์การนำเสนอเป็นเรื่องง่ายเทียบเท่ากับการเข้าถึงคุณสมบัตินั้น คุณสามารถกำหนดค่าเป็นสตริงให้กับคุณสมบัติใดก็ได้ที่ต้องการและค่าจะถูกแก้ไข... ในตัวอย่างด้านล่าง เราได้สาธิตวิธีการแก้ไขคุณสมบัติเบื้องต้นของเอกสารในไฟล์การนำเสนอ.  
```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึง Presentation
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # สร้างการอ้างอิงถึงอ็อบเจกต์ที่เชื่อมโยงกับ Presentation
    documentProperties = presentation.document_properties

    # ตั้งค่าคุณสมบัติในตัว
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # บันทึกการนำเสนอของคุณลงไฟล์
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มคุณสมบัติ Custom ของการนำเสนอ**

Aspose.Slides for Python via .NET ยังอนุญาตให้ผู้พัฒนาสามารถเพิ่มค่าที่กำหนดเองสำหรับคุณสมบัติของเอกสารการนำเสนอ ตัวอย่างด้านล่างแสดงวิธีตั้งค่าคุณสมบัติ custom สำหรับการนำเสนอ.  
```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:
    # ดึงคุณสมบัติเอกสาร
    documentProperties = presentation.document_properties

    # เพิ่มคุณสมบัติแบบกำหนดเอง
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # ดึงชื่อคุณสมบัติที่ตำแหน่งเฉพาะ
    getPropertyName = documentProperties.get_custom_property_name(2)

    # ลบคุณสมบัติที่เลือก
    documentProperties.remove_custom_property(getPropertyName)

    # บันทึกการนำเสนอ
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงและแก้ไขคุณสมบัติ Custom**

Aspose.Slides for Python via .NET ยังอนุญาตให้ผู้พัฒนาสามารถเข้าถึงค่าของคุณสมบัติ custom ตัวอย่างด้านล่างแสดงวิธีการเข้าถึงและแก้ไขคุณสมบัติ custom ทั้งหมดสำหรับการนำเสนอ.  
```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # สร้างการอ้างอิงไปยังอ็อบเจกต์ document_properties ที่เชื่อมโยงกับ Presentation
    documentProperties = presentation.document_properties

    # เข้าถึงและแก้ไขคุณสมบัติแบบกำหนดเอง
    for i in range(documentProperties.count_of_custom_properties):
        # แสดงชื่อและค่าของคุณสมบัติแบบกำหนดเอง
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # แก้ไขค่าของคุณสมบัติแบบกำหนดเอง
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # บันทึกการนำเสนอของคุณลงไฟล์
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าภาษา Proofing**

Aspose.Slides มีคุณสมบัติ `Language_Id` (เปิดเผยโดยคลาส [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/)) เพื่อให้คุณตั้งค่าภาษา Proofing สำหรับเอกสาร PowerPoint ภาษา Proofing คือภาษาที่จะทำการตรวจสอบการสะกดและไวยากรณ์ใน PowerPoint.  

โค้ด Python นี้แสดงวิธีตั้งค่าภาษา Proofing สำหรับ PowerPoint:  
```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # ตั้งค่า Id ของภาษาตรวจสอบ
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **ตั้งค่าภาษาเริ่มต้น**

โค้ด Python นี้แสดงวิธีตั้งค่าภาษาเริ่มต้นสำหรับการนำเสนอ PowerPoint ทั้งหมด:  
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **ตัวอย่างสด**

ลองใช้แอปออนไลน์ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) เพื่อดูวิธีทำงานกับคุณสมบัติของเอกสารผ่าน Aspose.Slides API:  

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **คำถามที่พบบ่อย**

**ฉันจะลบคุณสมบัติ built-in จากการนำเสนอได้อย่างไร?**  
คุณสมบัติ built-in เป็นส่วนสำคัญของการนำเสนอและไม่สามารถลบออกได้ทั้งหมด อย่างไรก็ตามคุณสามารถเปลี่ยนค่าเหล่านั้นหรือกำหนดเป็นค่าว่างได้หากคุณสมบัตินั้นอนุญาต.

**เกิดอะไรขึ้นหากฉันเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว?**  
หากคุณเพิ่มคุณสมบัติ custom ที่มีอยู่แล้ว ค่าที่มีอยู่จะถูกเขียนทับด้วยค่าที่ใหม่ คุณไม่จำเป็นต้องลบหรือเช็กคุณสมบัติก่อน เนื่องจาก Aspose.Slides จะอัปเดตค่าของคุณสมบัติโดยอัตโนมัติ.

**ฉันสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดการนำเสนอเต็มรูปแบบได้หรือไม่?**  
ใช่, คุณสามารถเข้าถึงคุณสมบัติการนำเสนอโดยไม่ต้องโหลดเต็มรูปแบบโดยใช้เมธอด [get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) จากคลาส [PresentationFactory](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/) จากนั้นใช้เมธอด [read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) ของคลาส [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) เพื่ออ่านคุณสมบัติอย่างมีประสิทธิภาพ ประหยัดหน่วยความจำและเพิ่มประสิทธิภาพ.