---
title: จัดการกล่องข้อความในงานนำเสนอด้วย Python
linktitle: จัดการกล่องข้อความ
type: docs
weight: 20
url: /th/python-net/manage-textbox/
keywords:
- กล่องข้อความ
- เฟรมข้อความ
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
description: "Aspose.Slides สำหรับ Python ผ่าน .NET ทำให้การสร้าง แก้ไข และทำซ้ำกล่องข้อความในไฟล์ PowerPoint และ OpenDocument ง่ายขึ้น ช่วยปรับปรุงการทำงานอัตโนมัติของงานนำเสนอของคุณ."
---
## **บทนำ**

ข้อความบนสไลด์มักจะอยู่ในกล่องข้อความหรือรูปทรง ดังนั้นเพื่อเพิ่มข้อความลงในสไลด์ คุณต้องเพิ่มกล่องข้อความแล้วใส่ข้อความลงในกล่องนั้น Aspose.Slides สำหรับ Python มีคลาส [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่อนุญาตให้คุณเพิ่มรูปทรงที่มีข้อความ

{{% alert title="Info" color="info" %}}
Aspose.Slides ยังมีคลาส [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) อีกด้วย อย่างไรก็ตาม ไม่ใช่รูปทรงทั้งหมดที่สามารถบรรจุข้อความได้
{{% /alert %}}

{{% alert title="Note" color="warning" %}}
ดังนั้นเมื่อทำงานกับรูปทรงที่คุณต้องการเพิ่มข้อความ คุณอาจต้องตรวจสอบและยืนยันว่ามันถูกแคสต์ผ่านคลาส [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) เพียงเท่านั้นคุณจึงจะสามารถทำงานกับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/), ซึ่งเป็นคุณสมบัติของ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ดูส่วน [Update Text](/slides/th/python-net/manage-textbox/#update-text) ในหน้านี้
{{% /alert %}}

## **สร้างกล่องข้อความบนสไลด์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์แรก
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่มี `ShapeType.RECTANGLE` ในตำแหน่งที่ต้องการบนสไลด์
4. ตั้งค่าข้อความใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ของรูปทรง
5. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ตัวอย่าง Python ด้านล่างนี้ทำตามขั้นตอนเหล่านี้:

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

## **ตรวจสอบว่ารูปทรงเป็นกล่องข้อความหรือไม่**

Aspose.Slides มีคุณสมบัติ [is_text_box](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/is_text_box/) บนคลาส [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ซึ่งช่วยให้คุณตรวจสอบว่ารูปทรงเป็นกล่องข้อความหรือไม่

![กล่องข้อความและรูปทรง](istextbox.png)

ตัวอย่าง Python นี้แสดงวิธีตรวจสอบว่ารูปทรงถูกสร้างเป็นกล่องข้อความหรือไม่:

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                print("shape is a text box" if shape.is_text_box else "shape is not a text box")
```

โปรดทราบว่าหากคุณเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) โดยใช้คลาส [ShapeCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/) คุณสมบัติ `is_text_box` ของรูปทรงจะคืนค่า `False` อย่างไรก็ตาม หลังจากคุณเพิ่มข้อความ—ไม่ว่าจะด้วยเมธอด `add_text_frame` หรือการตั้งค่า `text`—`is_text_box` จะคืนค่า `True`

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

## **ค้นหารูปทรงที่เป็นเจ้าของ TextFrame**

ในโค้ดประมวลผลข้อความทั่วไป คุณอาจได้รับ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) โดยไม่ทราบล่วงหน้าว่างานนำเสนอใดเป็นเจ้าของ ใช้คุณสมบัติ [TextFrame.parent_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/parent_shape/) เพื่อนำทางกลับไปยัง [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/) ที่เป็นเจ้าของ

สำหรับ TextFrame ที่เป็นส่วนของ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) หรือรูปทรงที่บรรจุข้อความอื่น ๆ, `TextFrame.parent_shape` จะถูกตั้งค่าและ `TextFrame.parent_cell` จะเป็น `None` ทั้งสองคุณสมบัตินี้เป็นคุณสมบัติการนำทางแบบอ่านอย่างเดียว ดังนั้นการอ่านจะไม่เปลี่ยนแปลงความเป็นเจ้าของ ตรวจสอบค่า returned ให้เป็น `None` ก่อนเข้าถึงรูปทรงเสมอ

สำหรับตัวอย่างเต็มที่ระบุเจ้าของรูปทรงและเซลล์ตาราง รวมถึงรูปทรงที่เชื่อมต่อกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/python-net/search-and-replace-text/)

## **เพิ่มคอลัมน์ให้กับกล่องข้อความ**

Aspose.Slides มีคุณสมบัติ [column_count](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/column_count/) และ [column_spacing](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/column_spacing/) บนคลาส [TextFrameFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframeformat/) เพื่อเพิ่มคอลัมน์ให้กับกล่องข้อความ คุณสามารถกำหนดจำนวนคอลัมน์และตั้งค่าระยะห่าง (เป็นจุด) ระหว่างคอลัมน์ได้

ตัวอย่าง Python ด้านล่างนี้แสดงการทำงานนี้:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:

	# ดึงสไลด์แรกในงานนำเสนอ.
	slide = presentation.slides[0]

	# เพิ่ม AutoShape ชนิด RECTANGLE.
	shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 300, 300)

	# เพิ่ม TextFrame ให้กับสี่เหลี่ยม.
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

Aspose.Slides อนุญาตให้คุณอัปเดตข้อความในกล่องข้อความเดียวหรือทั่วทั้งงานนำเสนอ

ตัวอย่าง Python ด้านล่างนี้แสดงวิธีอัปเดตข้อความทั้งหมดในงานนำเสนอ:

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                for paragraph in shape.text_frame.paragraphs:
                    for portion in paragraph.portions:
                        portion.text = portion.text.replace("years", "months")
                        portion.portion_format.font_bold = slides.NullableBool.TRUE
  
    # บันทึกงานนำเสนอที่แก้ไขแล้ว.
    presentation.save("TextChanged.pptx", slides.export.SaveFormat.PPTX)
```

## **เพิ่มกล่องข้อความที่มีไฮเปอร์ลิงก์**

คุณสามารถแทรกลิงก์ในกล่องข้อความได้ เมื่อคลิกที่กล่องข้อความลิงก์จะเปิด

เพื่อเพิ่มกล่องข้อความที่มีไฮเปอร์ลิงก์ ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงไปยังสไลด์แรก
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) ที่มี `ShapeType.RECTANGLE` ในตำแหน่งที่ต้องการบนสไลด์
4. ตั้งค่าข้อความใน [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/)
5. รับอ้างอิงไปยัง [HyperlinkManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/)
6. ใช้คุณสมบัติ `hyperlink_manager` เพื่อตั้งค่าลิงก์คลิกภายนอก
7. บันทึกงานนำเสนอเป็นไฟล์ PPTX

ตัวอย่าง Python นี้แสดงวิธีเพิ่มกล่องข้อความพร้อมไฮเปอร์ลิงก์ลงในสไลด์:

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation.
with slides.Presentation() as presentation:

    # ดึงสไลด์แรกในงานนำเสนอ.
    slide = presentation.slides[0]

    # เพิ่ม AutoShape ชนิด RECTANGLE.
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 150, 50)

    text_portion = shape.text_frame.paragraphs[0].portions[0]

    # เพิ่มข้อความลงในเฟรม.
    text_portion.text = "Aspose.Slides"

    # ตั้งค่าไฮเปอร์ลิงก์สำหรับข้อความส่วน.
    hyperlink_manager = text_portion.portion_format.hyperlink_manager
    hyperlink_manager.set_external_hyperlink_click("http://www.aspose.com")

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("Hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**ความแตกต่างระหว่างกล่องข้อความและตัวแทนที่ข้อความเมื่อทำงานกับสไลด์มาสเตอร์คืออะไร?**

[placeholder](/slides/th/python-net/manage-placeholder/) สืบทอดสไตล์/ตำแหน่งจาก [master](https://reference.aspose.com/slides/th/python-net/aspose.slides/masterslide/) และสามารถถูกแทนที่ได้บน [layouts](https://reference.aspose.com/slides/th/python-net/aspose.slides/layoutslide/) ในขณะที่กล่องข้อความธรรมดาเป็นอ็อบเจกต์อิสระบนสไลด์เฉพาะและไม่เปลี่ยนแปลงเมื่อคุณสลับเลย์เอาต์

**ฉันจะทำการแทนที่ข้อความหลายรายการทั่วทั้งงานนำเสนอโดยไม่แก้ไขข้อความภายในแผนภูมิ ตาราง และ SmartArt อย่างไร?**

จำกัดการวนลูปของคุณให้กับ auto‑shapes ที่มี TextFrame และไม่รวมอ็อบเจกต์ฝังอยู่ ([charts](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/)) โดยทำการ traversal ของคอลเลกชันเหล่านั้นแยกกันหรือข้ามประเภทอ็อบเจกต์เหล่านั้น.