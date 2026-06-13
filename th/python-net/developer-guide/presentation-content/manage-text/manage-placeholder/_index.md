---
title: จัดการ Placeholder ในงานนำเสนอด้วย Python
linktitle: จัดการ Placeholder
type: docs
weight: 10
url: /th/python-net/manage-placeholder/
keywords:
- ตัวพัก
- ตัวพักข้อความ
- ตัวพักรูปภาพ
- ตัวพักแผนภูมิ
- ข้อความพร้อมใช้
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการตัวพักใน Aspose.Slides สำหรับ Python ผ่าน .NET อย่างง่ายดาย: แทนที่ข้อความ, ปรับแต่งข้อความพร้อมใช้ และตั้งค่าความโปร่งแสงของรูปภาพใน PowerPoint และ OpenDocument."
---
## **ภาพรวม**

Aspose.Slides ให้คุณจัดการตัวพัก (placeholder) ของงานนำเสนอโดยโปรแกรมได้ บทความนี้อธิบายวิธีค้นหา placeholder บนสไลด์และเปลี่ยนข้อความของมัน ตั้งค่าข้อความพร้อมใช้แบบกำหนดเองสำหรับการจัดวาง placeholder และปรับความโปร่งแสงของรูปภาพที่ใช้เป็นพื้นหลังของ placeholder นอกจากนี้ยังมี FAQ สั้น ๆ ที่ชี้แจงความแตกต่างระหว่าง base placeholder กับ local shape, อธิบายว่าการเปลี่ยนแปลง placeholder สามารถใช้ผ่าน layout หรือ master อย่างไร และแนะนำการจัดการ placeholder ของส่วนหัวและส่วนท้าย

## **เปลี่ยนข้อความใน Placeholder**

ด้วย Aspose.Slides for Python คุณสามารถค้นหาและแก้ไข placeholder บนสไลด์ในงานนำเสนอได้ Aspose.Slides อนุญาตให้คุณแก้ไขข้อความใน placeholder

**Prerequisite:** คุณต้องมีงานนำเสนอที่มี placeholder คุณสามารถสร้างงานนำเสนอเช่นนั้นใน Microsoft PowerPoint

นี่คือตัวอย่างการใช้ Aspose.Slides เพื่อแทนที่ข้อความใน placeholder:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) แล้วส่งงานนำเสนอเป็นอาร์กิวเมนต์
1. รับอ้างอิงถึงสไลด์ตามดัชนีของมัน
1. วนลูปผ่าน shapes เพื่อค้นหา placeholder
1. เปลี่ยนข้อความโดยใช้ [TextFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/) ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/)
1. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Python นี้แสดงวิธีเปลี่ยนข้อความใน placeholder:

```python
import aspose.slides as slides

    # สร้างอินสแตนซ์ของคลาส Presentation.
    with slides.Presentation("ReplacingText.pptx") as presentation:
        # เข้าถึงสไลด์แรก.
        slide = presentation.slides[0]

        # วนลูปผ่าน shapes เพื่อค้นหา placeholder.
        for shape in slide.shapes:
            if shape.placeholder is not None:
                # เปลี่ยนข้อความในแต่ละ placeholder.
                shape.text_frame.text = "This is Placeholder"

        # บันทึกงานนำเสนอไปยังดิสก์.
        presentation.save("ReplacingText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าข้อความพร้อมใช้สำหรับ Placeholder**

เลย์เอาต์มาตรฐานและเลย์เอาต์ที่เตรียมไว้ล่วงหน้ามีข้อความพร้อมใช้ของ placeholder เช่น **Click to add a title** หรือ **Click to add a subtitle** ด้วย Aspose.Slides คุณสามารถแทนที่ข้อความเหล่านี้ด้วยข้อความของคุณเองในเลย์เอาต์ของ placeholder

ตัวอย่าง Python ด้านล่างแสดงวิธีตั้งค่าข้อความพร้อมใช้สำหรับ placeholder:

```python
import aspose.slides as slides

with slides.Presentation("PromptText.pptx") as presentation:
    slide = presentation.slides[0]

    # วนลูปผ่าน shapes เพื่อค้นหา placeholder.
    for shape in slide.slide.shapes:
        if shape.placeholder is not None and type(shape) is slides.AutoShape:
            if shape.placeholder.type == slides.PlaceholderType.CENTERED_TITLE:
                text = "Add Title"
            elif shape.placeholder.type == slides.PlaceholderType.SUBTITLE:
                text = "Add Subtitle"

            shape.text_frame.text = text
            print(f"Placeholder with text: {text}")

    presentation.save("PromptText_out.pptx", slides.export.SaveFormat.PPTX)
```

## **ตั้งค่าความโปร่งแสงของรูปภาพใน Placeholder**

Aspose.Slides ให้คุณตั้งค่าความโปร่งแสงของรูปภาพพื้นหลังใน placeholder ของข้อความ ด้วยการปรับความโปร่งแสงของรูปภาพในเฟรมนั้น คุณสามารถทำให้ข้อความหรือรูปภาพเด่นออกมาขึ้นขึ้นอยู่กับสีของพวกมัน

ตัวอย่าง Python ด้านล่างแสดงวิธีตั้งค่าความโปร่งแสงของรูปภาพพื้นหลังภายใน shape:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 100)
    auto_shape.fill_format.fill_type = slides.FillType.PICTURE

    with open("image.png", "rb") as image_stream:
        auto_shape.fill_format.picture_fill_format.picture.image = presentation.images.add_image(image_stream)
        auto_shape.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
        auto_shape.fill_format.picture_fill_format.picture.image_transform.add_alpha_modulate_fixed_effect(75)
```

## **FAQ**

**Base placeholder คืออะไรและต่างจาก local shape บนสไลด์อย่างไร?**

Base placeholder คือ shape ดั้งเดิมบน layout หรือ master ที่ shape ของสไลด์สืบทอดคุณสมบัติมา—ประเภท ตำแหน่ง และการจัดรูปแบบบางส่วนมาจากมัน ส่วน local shape คือ shape ที่ทำงานอย่างอิสระ; หากไม่มี base placeholder การสืบทอดจะไม่เกิดขึ้น

**ฉันจะอัปเดตหัวเรื่องหรือคำอธิบายทั้งหมดในงานนำเสนอโดยไม่ต้องวนลูปทุกสไลด์ได้อย่างไร?**

แก้ไข placeholder ที่สอดคล้องบน layout หรือ master สไลด์ที่อิงจาก layout/ master นั้นจะสืบทอดการเปลี่ยนแปลงโดยอัตโนมัติ

**ฉันจะควบคุม placeholder ของส่วนหัว/ส่วนท้ายนามมาตรฐาน—วันที่และเวลา, หมายเลขสไลด์, และข้อความส่วนท้ายได้อย่างไร?**

ใช้ผู้จัดการ HeaderFooter ในระดับที่เหมาะสม (สไลด์ทั่วไป, layout, master, notes/handouts) เพื่อเปิดหรือปิด placeholder เหล่านั้นและตั้งค่าข้อความของมัน