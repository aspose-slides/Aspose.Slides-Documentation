---
title: จัดการ OLE ในพรีเซนเทชันโดยใช้ Python
linktitle: จัดการ OLE
type: docs
weight: 40
url: /th/python-net/manage-ole/
keywords:
- วัตถุ OLE
- การเชื่อมโยงและฝังวัตถุ
- เพิ่ม OLE
- ฝัง OLE
- เพิ่มวัตถุ
- ฝังวัตถุ
- เพิ่มไฟล์
- ฝังไฟล์
- วัตถุลิงก์
- ไฟล์ลิงก์
- เปลี่ยน OLE
- ไอคอน OLE
- ชื่อ OLE
- สกัด OLE
- สกัดวัตถุ
- สกัดไฟล์
- PowerPoint 
- พรีเซนเทชัน
- Python
- Aspose.Slides
description: "เพิ่มประสิทธิภาพการจัดการวัตถุ OLE ในไฟล์ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET. ฝัง, อัปเดต, และส่งออกเนื้อหา OLE อย่างราบรื่น."
---
## **บทนำ**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** เป็นเทคโนโลยีของ Microsoft ที่ช่วยให้ข้อมูลและวัตถุที่สร้างในแอปพลิเคชันหนึ่งสามารถลิงก์หรือฝังในแอปพลิเคชันอื่นได้

{{% /alert %}}

เช่น ตัวอย่างเช่น แผนภูมิที่สร้างใน Microsoft Excel แล้ววางบนสไลด์ PowerPoint คือวัตถุ OLE

- OLE object อาจปรากฏเป็นไอคอน การคลิกสองครั้งที่ไอคอนจะเปิดวัตถุในแอปพลิเคชันที่เชื่อมโยง (เช่น Excel) หรือให้คุณเลือกแอปเพื่อเปิดหรือแก้ไขมัน
- OLE object อาจแสดงเนื้อหา (เช่น แผนภูมิ) ในกรณีนี้ PowerPoint จะทำให้วัตถุที่ฝังทำงาน โหลดอินเทอร์เฟซแผนภูมิ และอนุญาตให้คุณแก้ไขข้อมูลของแผนภูมิภายใน PowerPoint

Aspose.Slides for Python ช่วยให้คุณแทรก OLE objects ลงในสไลด์เป็น OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/))

## **เพิ่มวัตถุ OLE ลงในสไลด์**

หากคุณได้สร้างแผนภูมิใน Microsoft Excel แล้วต้องการฝังมันในสไลด์เป็น OLE object frame โดยใช้ Aspose.Slides for Python ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) 
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. อ่านไฟล์ Excel เป็นอาเรย์ไบต์
1. เพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) ลงในสไลด์ โดยส่งอาเรย์ไบต์และรายละเอียดอื่นๆ ของวัตถุ OLE
1. บันทึกพรีเซนเทชันที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง แผนภูมิจากไฟล์ Excel ถูกฝังในสไลด์เป็น [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/)

**หมายเหตุ:** ตัวสร้าง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) รับส่วนขยายไฟล์ของวัตถุที่ฝังเป็นพารามิเตอร์ที่สอง PowerPoint ใช้ส่วนขยายนี้เพื่อระบุประเภทไฟล์และเลือกแอปพลิเคชันที่เหมาะสมในการเปิด OLE object

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # เตรียมข้อมูลสำหรับวัตถุ OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # เพิ่มกรอบวัตถุ OLE ลงในสไลด์.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **เพิ่มวัตถุ OLE เชื่อมโยง**

Aspose.Slides for Python ช่วยให้คุณเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) ที่ลิงก์ไปยังไฟล์แทนการฝังข้อมูลของมัน

ตัวอย่าง Python ต่อไปนี้แสดงวิธีเพิ่ม [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) ที่ลิงก์ไปยังไฟล์ Excel บนสไลด์:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มกรอบวัตถุ OLE พร้อมไฟล์ Excel ที่เชื่อมโยง.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงวัตถุ OLE**

หากวัตถุ OLE ได้ถูกฝังไว้ในสไลด์แล้ว คุณสามารถเข้าถึงได้ตามขั้นตอนต่อไปนี้:

1. โหลดพรีเซนเทชันที่มีวัตถุ OLE ฝังอยู่โดยสร้างอินสแตนซ์ของคลาส Presentation
1. รับอ้างอิงไปยังสไลด์ตามดัชนีของมัน
1. เข้าถึงรูปร่าง OleObjectFrame
1. เมื่อคุณมีกรอบวัตถุ OLE แล้วให้ดำเนินการที่ต้องการกับมัน

ตัวอย่างด้านล่างเข้าถึง OLE object frame — แผนภูมิ Excel ที่ฝังอยู่ — และดึงข้อมูลไฟล์ของมัน ในตัวอย่างนี้เราใช้ PPTX ที่มีรูปร่างเดียวบนสไลด์แรก

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # รับข้อมูลไฟล์ที่ฝังไว้.
        file_data = ole_frame.embedded_data.embedded_file_data

        # รับส่วนขยายของไฟล์ที่ฝัง.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **เข้าถึงคุณสมบัติวัตถุ OLE เชื่อมโยง**

Aspose.Slides ให้คุณเข้าถึงคุณสมบัติของกรอบวัตถุ OLE เชื่อมโยง

ตัวอย่าง Python ด้านล่างตรวจสอบว่าวัตถุ OLE ถูกลิงก์หรือไม่ และหากใช่จะดึงเส้นทางไปยังไฟล์ที่ลิงก์ไว้:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # ตรวจสอบว่าวัตถุ OLE ถูกลิงก์หรือไม่.
        if ole_frame.is_object_link:
            # พิมพ์เส้นทางเต็มของไฟล์ที่ลิงก์.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # พิมพ์เส้นทางสัมพันธ์ของไฟล์ที่ลิงก์ หากมี.
            # เฉพาะพรีเซนเทชัน .ppt เท่านั้นที่สามารถมีเส้นทางสัมพันธ์ได้.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **เปลี่ยนข้อมูลวัตถุ OLE**

{{% alert color="primary" %}}

ในส่วนนี้ ตัวอย่างโค้ดด้านล่างใช้ [Aspose.Cells for Python via .NET](/cells/python-net/)

{{% /alert %}}

หากวัตถุ OLE ได้ถูกฝังอยู่ในสไลด์แล้ว คุณสามารถเข้าถึงและแก้ไขข้อมูลของมันได้ตามขั้นตอนต่อไปนี้:

1. โหลดพรีเซนเทชันโดยสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
1. รับสไลด์เป้าหมายตามดัชนีของมัน
1. เข้าถึงรูปร่าง [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/)
1. เมื่อคุณมีกรอบวัตถุ OLE แล้วให้ดำเนินการที่จำเป็นกับมัน
1. สร้างอ็อบเจกต์ `Workbook` แล้วอ่านข้อมูล OLE
1. เปิด `Worksheet` ที่ต้องการและแก้ไขข้อมูล
1. บันทึก `Workbook` ที่อัปเดตลงสตรีม
1. แทนที่ข้อมูลของวัตถุ OLE ด้วยสตรีมนั้น

ในตัวอย่างด้านล่างกรอบวัตถุ OLE (แผนภูมิ Excel ที่ฝัง) ถูกเข้าถึงและข้อมูลไฟล์ของมันถูกแก้ไขเพื่ออัปเดตแผนภูมิ ตัวอย่างใช้ PPTX ที่สร้างไว้ก่อนหน้านี้ซึ่งมีรูปร่างเดียวบนสไลด์แรก

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
            # อ่านข้อมูลวัตถุ OLE เป็นออบเจ็กต์ Workbook.
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

นอกจากแผนภูมิ Excel แล้ว Aspose.Slides for Python ยังให้คุณฝังไฟล์ประเภทอื่นในสไลด์ได้ เช่น คุณสามารถแทรกไฟล์ HTML, PDF และ ZIP เป็นวัตถุได้ เมื่อผู้ใช้คลิกสองครั้งที่วัตถุที่แทรกเข้ามา ระบบจะเปิดโดยอัตโนมัติในแอปพลิเคชันที่เชื่อมโยง หรือจะแจ้งให้ผู้ใช้เลือกโปรแกรมที่เหมาะสม

โค้ด Python นี้แสดงวิธีฝังไฟล์ HTML และ ZIP ลงในสไลด์:

```py
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

## **กำหนดประเภทไฟล์สำหรับวัตถุที่ฝัง**

เมื่อต้องทำงานกับพรีเซนเทชัน คุณอาจต้องการแทนที่วัตถุ OLE เก่าด้วยวัตถุใหม่ หรือสลับวัตถุ OLE ที่ไม่รองรับเป็นวัตถุที่รองรับ Aspose.Slides for Python ให้คุณกำหนดประเภทไฟล์ของวัตถุที่ฝัง เพื่ออัปเดตข้อมูลเฟรม OLE หรือส่วนขยายไฟล์ของมันได้

โค้ด Python นี้แสดงวิธีกำหนดประเภทไฟล์ของวัตถุ OLE ที่ฝังเป็น `zip`:

```py
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

## **ตั้งค่าภาพไอคอนและชื่อสำหรับวัตถุที่ฝัง**

หลังจากที่คุณฝังวัตถุ OLE แล้ว ระบบจะเพิ่มตัวอย่างภาพไอคอนโดยอัตโนมัติ ตัวอย่างภาพนี้คือสิ่งที่ผู้ใช้เห็นก่อนเข้าถึงหรือเปิดวัตถุ OLE หากคุณต้องการใช้ภาพและข้อความเฉพาะในตัวอย่างภาพ คุณสามารถตั้งค่าภาพไอคอนและชื่อได้โดยใช้ Aspose.Slides for Python

โค้ด Python นี้แสดงวิธีตั้งค่าภาพไอคอนและชื่อสำหรับวัตถุที่ฝัง:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # เพิ่มภาพไปยังทรัพยากรพรีเซนเทชัน.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # ตั้งค่าชื่อและภาพสำหรับตัวอย่าง OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ป้องกันไม่ให้กรอบวัตถุ OLE ถูกปรับขนาดและย้ายตำแหน่ง**

หลังจากที่คุณเพิ่มวัตถุ OLE เชื่อมโยงลงในสไลด์ PowerPoint อาจแจ้งให้คุณอัปเดตลิงก์เมื่อเปิดพรีเซนเทชัน การเลือก “Update Links” สามารถทำให้ขนาดและตำแหน่งของกรอบวัตถุ OLE เปลี่ยนแปลงได้ เนื่องจาก PowerPoint รีเฟรชตัวอย่างด้วยข้อมูลจากวัตถุที่ลิงก์ เพื่อป้องกันไม่ให้ PowerPoint แจ้งให้คุณอัปเดตข้อมูลของวัตถุ ให้ตั้งค่า `update_automatic` ของคลาส [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) เป็น `False`:

```py
ole_frame.update_automatic = False
```

## **สกัดไฟล์ที่ฝังไว้**

Aspose.Slides for Python ให้คุณสกัดไฟล์ที่ฝังในสไลด์เป็น OLE objects ได้ตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ที่มี OLE objects ที่คุณต้องการสกัด
1. วนลูปผ่านรูปร่างทั้งหมดในพรีเซนเทชันและค้นหารูปร่าง OLEObjectFrame
1. ดึงข้อมูลไฟล์ที่ฝังจากแต่ละ [OLEObjectFrame] แล้วเขียนลงดิสก์

โค้ด Python ต่อไปนี้แสดงวิธีสกัดไฟล์ที่ฝังในสไลด์เป็น OLE objects:

```py
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

## **FAQ**

**จะมีการเรนเดอร์เนื้อหา OLE เมื่อส่งออกสไลด์เป็น PDF/ภาพหรือไม่?**

สิ่งที่มองเห็นได้บนสไลด์จะถูกเรนเดอร์ — ไอคอน/ภาพแทน (preview) เนื้อหา OLE “สด” จะไม่ถูกประมวลผลระหว่างการเรนเดอร์ หากต้องการ ให้ตั้งค่าภาพตัวอย่างของคุณเองเพื่อให้แน่ใจว่าปรากฏอย่างที่คาดหวังใน PDF ที่ส่งออก

**ฉันจะล็อกวัตถุ OLE บนสไลด์เพื่อให้ผู้ใช้ไม่สามารถย้าย/แก้ไขได้ใน PowerPoint อย่างไร?**

ล็อกรูปทรง: Aspose.Slides มี [shape-level locks](/slides/th/python-net/applying-protection-to-presentation/) ซึ่งไม่ใช่การเข้ารหัส แต่ช่วยป้องกันการแก้ไขหรือการย้ายโดยบังเอิญได้อย่างมีประสิทธิภาพ

**ทำไมวัตถุ Excel ที่เชื่อมโยง “กระโดด” หรือเปลี่ยนขนาดเมื่อฉันเปิดพรีเซนเทชัน?**

PowerPoint อาจรีเฟรชตัวอย่างของ OLE ที่เชื่อมโยง เพื่อให้การแสดงผลคงที่ให้ทำตามแนวทางของ [Working Solution for Worksheet Resizing](/slides/th/python-net/working-solution-for-worksheet-resizing/) — ปรับกรอบให้พอดีกับช่วงข้อมูล หรือปรับสเกลช่วงให้พอดีกับกรอบคงที่และตั้งค่าภาพแทนที่เหมาะสม

**เส้นทางสัมพันธ์สำหรับวัตถุ OLE ที่เชื่อมโยงจะถูกเก็บไว้ในรูปแบบ PPTX หรือไม่?**

ใน PPTX ข้อมูล “relative path” ไม่พร้อมใช้งาน — มีเพียงเส้นทางเต็มเท่านั้น เส้นทางสัมพันธ์พบได้ในรูปแบบ PPT เก่า เพื่อความพกพา ให้ใช้เส้นทางแบบเต็มที่เชื่อถือได้/URI ที่เข้าถึงได้หรือฝังไฟล์แทน