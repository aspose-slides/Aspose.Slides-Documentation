---
title: จัดการ OLE ในพรีเซนเทชันด้วย Python
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/python-net/manage-ole/
keywords:
- ออบเจ็กต์ OLE
- Object Linking & Embedding
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มออบเจ็กต์
- ฝังออบเจ็กต์
- เพิ่มไฟล์
- ฝังไฟล์
- ออบเจ็กต์ที่เชื่อมโยง
- ไฟล์ที่เชื่อมโยง
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อ OLE
- ดึง OLE
- ดึงออบเจ็กต์
- ดึงไฟล์
- PowerPoint 
- พรีเซนเทชัน
- Python
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการออบเจ็กต์ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Python ผ่าน .NET ฝัง ปรับปรุง และส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert color="info" title="Note" %}}
**OLE (Object Linking & Embedding)** คือเทคโนโลยีของ Microsoft ที่ทำให้ข้อมูลและออบเจ็กต์ที่สร้างในแอปพลิเคชันหนึ่งสามารถเชื่อมโยงหรือฝังลงในแอปพลิเคชันอื่นได้.
{{% /alert %}}

ตัวอย่างเช่น แผนภูมิที่สร้างใน Microsoft Excel และวางบนสไลด์ PowerPoint เป็นออบเจ็กต์ OLE.

- ออบเจ็กต์ OLE อาจปรากฏเป็นไอคอน การคลิกสองครั้งที่ไอคอนจะเปิดออบเจ็กต์ในแอปพลิเคชันที่เชื่อมโยง (เช่น Excel) หรือให้คุณเลือกแอปเพื่อเปิดหรือแก้ไข
- ออบเจ็กต์ OLE อาจแสดงเนื้อหาของมัน (เช่น แผนภูมิ) ในกรณีนี้ PowerPoint จะทำการเปิดออบเจ็กต์ที่ฝังไว้ โหลดอินเทอร์เฟซของแผนภูมิ และให้คุณแก้ไขข้อมูลของแผนภูมิภายใน PowerPoint

Aspose.Slides for Python ให้คุณแทรกออบเจ็กต์ OLE ลงในสไลด์เป็นกรอบออบเจ็กต์ OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **เพิ่มออบเจ็กต์ OLE ลงในสไลด์**

หากคุณได้สร้างแผนภูมิใน Microsoft Excel แล้วและต้องการฝังมันลงในสไลด์เป็นกรอบออบเจ็กต์ OLE ด้วย Aspose.Slides for Python ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน.
3. อ่านไฟล์ Excel เป็นอาร์เรย์ไบต์.
4. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) ลงในสไลด์ โดยระบุอาร์เรย์ไบต์และรายละเอียดอื่นๆ ของออบเจ็กต์ OLE.
5. บันทึกพรีเซนเทชันที่แก้ไขแล้วเป็นไฟล์ PPTX.

ตัวอย่างด้านล่างนี้ แผนภูมิจากไฟล์ Excel ถูกฝังลงในสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**หมายเหตุ:** ตัวสร้าง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) รับนามสกุลไฟล์ของออบเจ็กต์ที่สามารถฝังได้เป็นพารามิเตอร์ที่สอง PowerPoint ใช้นามสกุลนี้เพื่อระบุประเภทไฟล์และเลือกแอปพลิเคชันที่เหมาะสมเพื่อเปิดออบเจ็กต์ OLE.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # เตรียมข้อมูลสำหรับออบเจ็กต์ OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # เพิ่มกรอบออบเจ็กต์ OLE ลงบนสไลด์.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **เพิ่มออบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides for Python ให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) ที่เชื่อมโยงไปยังไฟล์แทนการฝังข้อมูลของมัน.

ตัวอย่าง Python ด้านล่างแสดงวิธีเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) ที่เชื่อมโยงกับไฟล์ Excel บนสไลด์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มกรอบออบเจ็กต์ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงออบเจ็กต์ OLE**

หากออบเจ็กต์ OLE ถูกฝังอยู่แล้วในสไลด์ คุณสามารถเข้าถึงได้ดังต่อไปนี้:

1. โหลดพรีเซนเทชันที่มีออบเจ็กต์ OLE ที่ฝังอยู่โดยการสร้างอินสแตนซ์ของคลาส Presentation
2. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
3. เข้าถึงรูปร่าง OleObjectFrame
4. เมื่อคุณมีกรอบออบเจ็กต์ OLE แล้ว ให้ดำเนินการใดๆ ที่ต้องการกับมัน

ตัวอย่างด้านล่างเข้าถึงกรอบออบเจ็กต์ OLE —แผนภูมิ Excel ที่ฝังไว้—และดึงข้อมูลไฟล์ของมัน ในตัวอย่างนี้ เราใช้ PPTX ที่มีรูปร่างเดียวบนสไลด์แรก.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # รับข้อมูลไฟล์ที่ฝังไว้.
        file_data = ole_frame.embedded_data.embedded_file_data

        # รับนามสกุลไฟล์ที่ฝังไว้.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **เข้าถึงคุณสมบัติของออบเจ็กต์ OLE ที่เชื่อมโยง**

Aspose.Slides ให้คุณเข้าถึงคุณสมบัติของกรอบออบเจ็กต์ OLE ที่เชื่อมโยง

ตัวอย่าง Python ด้านล่างตรวจสอบว่าออบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่ และหากเป็นเชื่อมโยง จะดึงเส้นทางของไฟล์ที่เชื่อมโยงมา:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # ตรวจสอบว่าออบเจ็กต์ OLE ถูกเชื่อมโยงหรือไม่.
        if ole_frame.is_object_link:
            # พิมพ์เส้นทางเต็มไปยังไฟล์ที่เชื่อมโยง.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # พิมพ์เส้นทางสัมพันธ์ไปยังไฟล์ที่เชื่อมโยง หากมี.
            # ไฟล์พรีเซนเทชัน .ppt เท่านั้นที่สามารถมีเส้นทางสัมพันธ์ได้.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **เปลี่ยนข้อมูลออบเจ็กต์ OLE**

{{% alert color="info" title="Note" %}}
ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).
{{% /alert %}}

หากออบเจ็กต์ OLE ถูกฝังอยู่แล้วในสไลด์ คุณสามารถเข้าถึงและแก้ไขข้อมูลของมันได้ดังต่อไปนี้:

1. โหลดพรีเซนเทชันโดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
2. รับสไลด์เป้าหมายตามดัชนีของมัน
3. เข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)
4. เมื่อคุณมีกรอบออบเจ็กต์ OLE แล้ว ทำการดำเนินการที่จำเป็นกับมัน
5. สร้างออบเจ็กต์ `Workbook` และอ่านข้อมูล OLE
6. เปิด `Worksheet` ที่ต้องการและแก้ไขข้อมูล
7. บันทึก `Workbook` ที่อัปเดตเป็นสตรีม
8. แทนที่ข้อมูลของออบเจ็กต์ OLE ด้วยสตรีมนั้น

ในตัวอย่างด้านล่าง กรอบออบเจ็กต์ OLE (แผนภูมิ Excel ที่ฝังไว้) ถูกเข้าถึงและข้อมูลไฟล์ของมันถูกแก้ไขเพื่ออัปเดตแผนภูมิ ตัวอย่างใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมีรูปร่างเดียวบนสไลด์แรก.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # อ่านข้อมูลออบเจ็กต์ OLE เป็นอ็อบเจ็กต์ Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # แก้ไขข้อมูล workbook.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # เปลี่ยนข้อมูลออบเจ็กต์ของกรอบ OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ฝังไฟล์ในสไลด์**

นอกเหนือจากแผนภูมิ Excel แล้ว Aspose.Slides for Python ยังให้คุณฝังไฟล์ชนิดอื่นในสไลด์ได้ ตัวอย่างเช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นออบเจ็กต์ เมื่อผู้ใช้คลิกสองครั้งที่ออบเจ็กต์ที่แทรกไว้ มันจะเปิดอัตโนมัติในแอปพลิเคชันที่เชื่อมโยง หรือผู้ใช้จะได้รับการแจ้งให้เลือกโปรแกรมที่เหมาะสม

ตัวอย่างโค้ด Python นี้แสดงวิธีฝังไฟล์ HTML และ ZIP ลงในสไลด์:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดประเภทไฟล์สำหรับออบเจ็กต์ที่ฝังไว้**

เมื่อทำงานกับพรีเซนเทชัน คุณอาจต้องการเปลี่ยนออบเจ็กต์ OLE เก่าเป็นออบเจ็กต์ใหม่หรือเปลี่ยนออบเจ็กต์ OLE ที่ไม่รองรับเป็นออบเจ็กต์ที่รองรับ Aspose.Slides for Python ให้คุณกำหนดประเภทไฟล์ของออบเจ็กต์ที่ฝังไว้ ทำให้คุณสามารถอัปเดตข้อมูลกรอบ OLE หรือส่วนต่อท้ายไฟล์ของมันได้

ตัวอย่างโค้ด Python นี้แสดงวิธีกำหนดประเภทไฟล์ของออบเจ็กต์ OLE ที่ฝังไว้เป็น `zip`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # เปลี่ยนประเภทไฟล์เป็น ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **กำหนดรูปไอคอนและชื่อเรื่องสำหรับออบเจ็กต์ที่ฝังไว้**

หลังจากที่คุณฝังออบเจ็กต์ OLE แล้ว พรีวิวแบบไอคอนจะถูกเพิ่มอัตโนมัติ พรีวิวนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดออบเจ็กต์ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะในพรีวิว คุณสามารถกำหนดรูปไอคอนและชื่อเรื่องโดยใช้ Aspose.Slides for Python

ตัวอย่างโค้ด Python นี้แสดงวิธีกำหนดรูปไอคอนและชื่อเรื่องสำหรับออบเจ็กต์ที่ฝังไว้:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # เพิ่มภาพไปยังแหล่งข้อมูลพรีเซนเทชัน.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # ตั้งชื่อและภาพสำหรับพรีวิว OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ป้องกันไม่ให้กรอบออบเจ็กต์ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากที่คุณเพิ่มออบเจ็กต์ OLE ที่เชื่อมโยงลงในสไลด์ PowerPoint อาจแจ้งให้คุณอัปเดตลิงก์เมื่อเปิดพรีเซนเทชัน การเลือก “Update Links” สามารถเปลี่ยนขนาดและตำแหน่งของกรอบออบเจ็กต์ OLE ได้เนื่องจาก PowerPoint รีเฟรชพรีวิวด้วยข้อมูลจากออบเจ็กต์ที่เชื่อมโยง เพื่อป้องกันไม่ให้ PowerPoint แจ้งให้คุณอัปเดตข้อมูลของออบเจ็กต์ ให้ตั้งค่าคุณสมบัติ `update_automatic` ของคลาส [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) เป็น `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **สกัดไฟล์ที่ฝังไว้**

Aspose.Slides for Python ให้คุณสกัดไฟล์ที่ฝังอยู่ในสไลด์เป็นออบเจ็กต์ OLE ได้ดังต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) ที่มีออบเจ็กต์ OLE ที่คุณต้องการสกัด
2. วนผ่านรูปร่างทั้งหมดในพรีเซนเทชันและค้นหารูปร่าง OLEObjectFrame
3. ดึงข้อมูลไฟล์ที่ฝังจากแต่ละ [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) แล้วเขียนลงดิสก์

ตัวอย่างโค้ด Python ด้านล่างแสดงวิธีสกัดไฟล์ที่ฝังในสไลด์เป็นออบเจ็กต์ OLE:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **คำถามที่พบบ่อย**

**เนื้อหา OLE จะถูกเรนเดอร์เมื่อส่งออกสไลด์เป็น PDF/รูปภาพหรือไม่?**

สิ่งที่มองเห็นบนสไลด์คือที่ถูกเรนเดอร์ — ไอคอน/ภาพทดแทน (พรีวิว) เนื้อหา OLE แบบ “สด” จะไม่ถูกประมวลผลระหว่างการเรนเดอร์ หากต้องการ สามารถตั้งค่าภาพพรีวิวของคุณเองเพื่อให้แน่ใจว่าการแสดงผลใน PDF ที่ส่งออกตรงตามที่คาดหวัง  

เพื่อรักษาไฟล์ที่ฝังไว้เป็นไฟล์แนบ PDF ด้วย ให้ตั้งค่า [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) เป็น `True` ตัวเลือกนี้ปิดการใช้งานโดยค่าเริ่มต้น สำหรับตัวอย่างและวิธีการตรวจสอบไฟล์แนบ ดูที่ [Preserve Embedded OLE Files as PDF Attachments](/slides/th/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)

**ฉันจะล็อกออบเจ็กต์ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint อย่างไร?**

ล็อกรูปร่าง: Aspose.Slides มี [shape-level locks](/slides/th/python-net/applying-protection-to-presentation/) นี่ไม่ใช่การเข้ารหัส แต่จะป้องกันการแก้ไขหรือการย้ายโดยไม่ได้ตั้งใจได้อย่างมีประสิทธิภาพ

**ทำไมออบเจ็กต์ Excel ที่เชื่อมโยงถึง “กระโดด” หรือเปลี่ยนขนาดเมื่อฉันเปิดพรีเซนเทชัน?**

PowerPoint อาจรีเฟรชพรีวิวของ OLE ที่เชื่อมโยง เพื่อให้ลักษณะคงที่ ให้ทำตามแนวปฏิบัติของ [Working Solution for Worksheet Resizing](/slides/th/python-net/working-solution-for-worksheet-resizing/) — ปรับกรอบให้พอดีกับช่วงข้อมูล หรือสเกลช่วงให้เข้ากับกรอบคงที่และตั้งภาพทดแทนที่เหมาะสม

**เส้นทางแบบสัมพัทธ์สำหรับออบเจ็กต์ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ไม่มีข้อมูล “เส้นทางสัมพันธ์” — มีเฉพาะเส้นทางเต็มเท่านั้น เส้นทางสัมพันธ์พบได้ในรูปแบบ PPT เก่า สำหรับความพกพา ควรใช้เส้นทางเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือการฝังไฟล์