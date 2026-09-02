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
- คุณสมบัติมาตรฐาน
- คุณสมบัติที่กำหนดเอง
- คุณสมบัติขั้นสูง
- การจัดการคุณสมบัติ
- แก้ไขคุณสมบัติ
- ข้อมูลเมตาเอกสาร
- แก้ไขเมตาดาต้า
- ภาษาตรวจสอบการพิสูจน์อักษร
- ภาษาตั้งค่าเริ่มต้น
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ควบคุมคุณสมบัติการนำเสนอใน Aspose.Slides for Python via .NET และเพิ่มประสิทธิภาพการค้นหา การสร้างแบรนด์และกระบวนการทำงานในไฟล์ PowerPoint ของคุณ."
---
## **บทนำ**

Aspose.Slides รองรับคุณสมบัติของเอกสารสองประเภท: **Built-in** และ **Custom**. ทั้งสองประเภทนี้สามารถเข้าถึงและจัดการได้อย่างง่ายดายโดยใช้ Aspose.Slides API.

Aspose.Slides อนุญาตให้คุณทำงานกับคุณสมบัติของเอกสารงานนำเสนอผ่านคลาส [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/). ตัวอย่างของคลาสนี้จะถูกส่งคืนโดยคุณสมบัติ [Presentation.document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/document_properties/). ตัวอย่างต่อไปนี้แสดงวิธีการอ่าน, แก้ไข, และจัดการคุณสมบัติเหล่านี้.

{{% alert color="info" title="Note" %}}
โปรดทราบว่าคุณไม่สามารถกำหนดค่าให้กับฟิลด์ **Application** และ **Producer** ได้ เนื่องจาก Aspose Ltd. และ Aspose.Slides for Python via .NET x.x.x จะถูกแสดงในฟิลด์เหล่านี้.
{{% /alert %}} 

## **จัดการคุณสมบัติงานนำเสนอ**

Microsoft PowerPoint มีฟีเจอร์ในการเพิ่มคุณสมบัติบางอย่างลงในไฟล์งานนำเสนอ คุณสมบัติของเอกสารเหล่านี้ช่วยให้สามารถเก็บข้อมูลที่เป็นประโยชน์ร่วมกับเอกสาร (ไฟล์งานนำเสนอ) มีสองประเภทของคุณสมบัติเอกสารดังต่อไปนี้

- คุณสมบัติที่กำหนดโดยระบบ (Built-in)
- คุณสมบัติที่กำหนดโดยผู้ใช้ (Custom)

**Built-in** properties contain general information about the document like document title, author's name, document statistics and so on. **Custom** properties are those ones, which are defined by the users as **Name/Value** pairs, where both name and value are defined by the user. Using Aspose.Slides for Python via .NET, developers can access and modify the values of built-in properties as well as custom properties. Microsoft PowerPoint 2007 allows managing the document properties of the presentation files. All you have to do is to click the Office icon and further **Prepare | Properties | Advanced Properties** menu item of the Microsoft PowerPoint 2007. After you select **Advanced Properties** menu item, a dialog would appear allowing you to manage the document properties of the PowerPoint file. In the **Properties Dialog**, you can see that there are many tab pages like **General, Summary, Statistics, Contents and Custom**. All these tab pages allow configuring different kinds of information related to the PowerPoint files. **Custom** tab is used to manage the custom properties of the PowerPoint files.

## **เข้าถึงคุณสมบัติ Built-in**
These properties as exposed by **IDocumentProperties** object include: **Creator(Author)**, **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** and **Title**
```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงการนำเสนอ
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # สร้างการอ้างอิงไปยังอ็อบเจกต์ที่เชื่อมโยงกับ Presentation
    documentProperties = pres.document_properties

    # แสดงคุณสมบัติ builtin
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

Modifying the built-in properties of presentation files is as easy as that of accessing them. You can simply assign a string value to any desired property and the property value would be modified. In the example given below, we have demonstrated that how we can modify the built-in document properties of the presentation file.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึง Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # สร้างการอ้างอิงไปยังอ็อบเจกต์ที่เชื่อมโยงกับ Presentation
    documentProperties = presentation.document_properties

    # ตั้งค่าคุณสมบัติ builtin
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # บันทึกการนำเสนอของคุณลงในไฟล์
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มคุณสมบัติการนำเสนอแบบกำหนดเอง**

Aspose.Slides for Python via .NET also allows developers to add the custom the values for presentation Document properties. An example is given below that shows how to set the custom properties for a presentation.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation
with slides.Presentation() as presentation:
    # ดึงคุณสมบัติของเอกสาร
    documentProperties = presentation.document_properties

    # เพิ่มคุณสมบัติกำหนดเอง
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # ดึงชื่อคุณสมบัติที่ตำแหน่งดัชนีเฉพาะ
    getPropertyName = documentProperties.get_custom_property_name(2)

    # ลบคุณสมบัติที่เลือก
    documentProperties.remove_custom_property(getPropertyName)

    # บันทึกการนำเสนอ
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง**

Aspose.Slides for Python via .NET also allows developers to access the values of custom properties. An example is given below that shows how can you access and modify all of these custom properties for a presentation.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึง PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # สร้างการอ้างอิงไปยังอ็อบเจกต์ document_properties ที่เชื่อมโยงกับ Presentation
    documentProperties = presentation.document_properties

    # เข้าถึงและแก้ไขคุณสมบัติกำหนดเอง
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # แสดงชื่อและค่าของคุณสมบัติกำหนดเอง
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # แก้ไขค่าของคุณสมบัติกำหนดเอง
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # บันทึกการนำเสนอของคุณลงในไฟล์
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` returns the value through the one-element list passed as its second argument, and the stored value is cast to the type of the element already in that list. The example above uses `[""]`, so it reads string properties; to read a property stored as a number, pass a numeric placeholder such as `[0]`—otherwise the call raises an `InvalidCastException`.

## **ตั้งค่าภาษา Proofing**

Aspose.Slides provides the `Language_Id` property (exposed by the [PortionFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/) class) to allow you to set the proofing language for a PowerPoint document. The proofing language is the language for which spellings and grammar in the PowerPoint are checked.

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # ตั้งค่า Id ของภาษาตรวจสอบการพิสูจน์
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **ตั้งค่าภาษาเริ่มต้น**

This Python code shows you how to set the default language for an entire PowerPoint presentation:

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

Try [**Aspose.Slides Metadata**](https://products.aspose.app/slides/th/metadata) online app to see how to work with document properties via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/th/metadata)

## **คำถามที่พบบ่อย**

**How can I remove a built-in property from a presentation?**

Built-in properties are an integral part of the presentation and cannot be removed entirely. However, you can either change their values or set them to empty if allowed by the specific property.

**What happens if I add a custom property that already exists?**

If you add a custom property that already exists, its existing value will be overwritten with the new one. You do not need to remove or check the property beforehand, as Aspose.Slides automatically updates the property's value.

**Can I access presentation properties without fully loading the presentation?**

Yes. Use [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationfactory/get_presentation_info/) and then [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/read_document_properties/) to read stored document metadata without creating a [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) instance. See [Build a Lightweight Presentation Inventory](/slides/th/python-net/examine-presentation/) for a complete reporting example and format-specific limitations.