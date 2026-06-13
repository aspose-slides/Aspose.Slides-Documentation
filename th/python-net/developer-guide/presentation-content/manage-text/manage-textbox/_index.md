---
title: จัดการกล่องข้อความในงานนำเสนอด้วย Python
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/python-net/manage-textbox/
keywords:
- กล่องข้อความ
- กรอบข้อความ
- เพิ่มข้อความ
- อัปเดตข้อความ
- สร้างกล่องข้อความ
- ตรวจสอบกล่องข้อความ
- เพิ่มคอลัมน์ข้อความ
- เพิ่มไฮเปอร์ลิงก์
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "Aspose.Slides สำหรับ Python ผ่าน .NET ทำให้การสร้าง แก้ไข และคัดลอกกล่องข้อความในไฟล์ PowerPoint และ OpenDocument เป็นเรื่องง่าย ช่วยปรับปรุงการทำงานอัตโนมัติของงานนำเสนอของคุณ."
---
## **บทนำ**

ข้อความบนสไลด์โดยทั่วไปอยู่ในกล่องข้อความหรือรูปร่าง ดังนั้น เพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความแล้วใส่ข้อความลงในกล่องนั้น Aspose.Slides for Python มีคลาส [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่อนุญาตให้คุณเพิ่มรูปร่างที่มีข้อความ

{{% alert title="Info" color="info" %}}
Aspose.Slides ยังมีคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) อีกด้วย อย่างไรก็ตาม รูปร่างทั้งหมดไม่สามารถเก็บข้อความได้
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
ดังนั้นเมื่อทำงานกับรูปร่างที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ารูปร่างนั้นถูกแคสต์ผ่านคลาส [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) เท่านั้นที่คุณจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ซึ่งเป็นคุณสมบัติของ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ดูส่วน [Update Text](/slides/th/python-net/manage-textbox/#update-text) ในหน้านี้
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

เพื่อสร้างกล่องข้อความบนสไลด์:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงถึงสไลด์แรก
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ด้วย `ShapeType.RECTANGLE` ที่ตำแหน่งที่ต้องการบนสไลด์
4. ตั้งค่าข้อความใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง
5. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ตัวอย่าง Python ต่อไปนี้ดำเนินการตามขั้นตอนเหล่านี้:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรกในงานนำเสนอ.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape ชนิด RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    shape.text_frame.text = "Aspose TextBox"

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("TextBox.pptx", slides.export.SaveFormat.PPTX)
```

## **ตรวจสอบว่ารูปร่างเป็นกล่องข้อความหรือไม่**

Aspose.Slides มีคุณสมบัติ [is_text_box](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/is_text_box/) บนคลาส [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ซึ่งช่วยให้คุณตรวจจับได้ว่ารูปร่างเป็นกล่องข้อความหรือไม่

![กล่องข้อความและรูปร่าง](istextbox.png)

ตัวอย่าง Python นี้แสดงวิธีตรวจสอบว่ารูปร่างถูกสร้างเป็นกล่องข้อความหรือไม่:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

โปรดทราบว่าถ้าคุณเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) โดยใช้คลาส [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/) คุณสมบัติ `is_text_box` ของรูปร่างจะคืนค่า `False` อย่างไรก็ตาม หลังจากที่คุณเพิ่มข้อความ—ไม่ว่าจะด้วยเมธอด `add_text_frame` หรือโดยการตั้งค่าคุณสมบัติ `text`— `is_text_box` จะคืนค่า `True`

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 40)
    # shape1.is_text_box เป็น false
    shape1.add_text_frame("shape 1")
    # shape1.is_text_box เป็น true

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 110, 100, 40)
    # shape2.is_text_box เป็น false
    shape2.text_frame.text = "shape 2"
    # shape2.is_text_box เป็น true

    shape3 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 210, 100, 40)
    # shape3.is_text_box เป็น false
    shape3.add_text_frame("")
    # shape3.is_text_box เป็น false

    shape4 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 310, 100, 40)
    # shape4.is_text_box เป็น false
    shape4.text_frame.text = ""
    # shape4.is_text_box เป็น false
```

## **เพิ่มคอลัมน์ในกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [column_count](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/column_count/) และ [column_spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/column_spacing/) บนคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/) เพื่อเพิ่มคอลัมน์ในกล่องข้อความ คุณสามารถระบุจำนวนคอลัมน์และตั้งค่าระยะห่าง (เป็นพอยต์) ระหว่างคอลัมน์

โค้ด Python ต่อไปนี้แสดงการทำงานนี้:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# ดึงสไลด์แรกในงานนำเสนอ.
	slide = presentation.slides[0]

	# เพิ่ม AutoShape ชนิด RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# เพิ่ม TextFrame ไปยังสี่เหลี่ยม.
	shape.add_text_frame("All of these columns are confined to a single text container—" +
	"you can add or delete text, and any new or remaining text automatically reflows " +
	"within the container. You cannot have text flow from one container to another, " +
	"though—PowerPoint’s column options for text are limited!")

	# ดึงรูปแบบข้อความของ TextFrame.
	format = shape.text_frame.text_frame_format

	# ระบุจำนวนคอลัมน์ใน TextFrame.
	format.column_count = 3

	# ระบุระยะห่างระหว่างคอลัมน์.
	format.column_spacing = 10

	# บันทึกงานนำเสนอ.
	presentation.save("ColumnCount.pptx", slides.export.SaveFormat.PPTX)
```

## **อัปเดตข้อความ**

Aspose.Slides อนุญาตให้คุณอัปเดตข้อความในกล่องข้อความเดียวหรือทั่วงานนำเสนอทั้งหมด

ตัวอย่าง Python ต่อไปนี้แสดงวิธีอัปเดตข้อความทั้งหมดในงานนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = 1
  
    # บันทึกงานนำเสนอที่แก้ไขแล้ว.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มกล่องข้อความพร้อมไฮเพอร์ลิงค์**

คุณสามารถใส่ลิงค์ในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความ ลิงค์จะเปิด

เพื่อเพิ่มกล่องข้อความที่มีไฮเพอร์ลิงค์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงถึงสไลด์แรก
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ด้วย `ShapeType.RECTANGLE` ที่ตำแหน่งที่ต้องการบนสไลด์
4. ตั้งค่าข้อความใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปร่าง
5. รับอ้างอิงถึง [HyperlinkManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/)
6. ใช้คุณสมบัติ `hyperlink_manager` เพื่อกำหนดไฮเพอร์ลิงค์คลิกแบบภายนอก
7. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ตัวอย่าง Python นี้แสดงวิธีเพิ่มกล่องข้อความพร้อมไฮเพอร์ลิงค์ลงในสไลด์:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรกในงานนำเสนอ.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape ชนิด RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # เพิ่มข้อความลงในกรอบ.
    text_portion.text = "Aspose.Slides"

    # ตั้งค่าไฮเปอร์ลิงก์สำหรับข้อความส่วน.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความและตัวยึดข้อความเมื่อทำงานกับสไลด์แม่คืออะไร?**

[placeholder](/slides/th/python-net/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) และสามารถถูกแก้ไขได้บน [layouts](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/) ขณะที่กล่องข้อความธรรมดาเป็นอ็อบเจกต์อิสระบนสไลด์เฉพาะและจะไม่เปลี่ยนแปลงเมื่อคุณสลับเลย์เอาต์

**ฉันจะทำการแทนที่ข้อความเป็นกลุ่มทั่วงานนำเสนอโดยไม่กระทบข้อความภายในแผนภูมิ ตาราง และ SmartArt ได้อย่างไร?**

จำกัดการวนรอบของคุณให้ทำกับออโต-ชป์ที่มีกรอบข้อความเท่านั้นและละเว้นอ็อบเจกต์ที่ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/)) โดย traversing คอลเลกชันของพวกมันแยกกันหรือข้ามประเภทอ็อบเจกต์เหล่านั้น.