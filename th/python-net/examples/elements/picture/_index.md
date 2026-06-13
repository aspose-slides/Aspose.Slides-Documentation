---
title: รูปภาพ
type: docs
weight: 50
url: /th/python-net/examples/elements/picture/
keywords:
- รูปภาพ
- กรอบรูปภาพ
- เพิ่มรูปภาพ
- เข้าถึงรูปภาพ
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ทำงานกับรูปภาพใน Python ด้วย Aspose.Slides: แทรก, แทนที่, การตัด, การบีบอัด, ปรับความโปร่งแสงและเอฟเฟกต์, เติมรูปร่าง, และส่งออกสำหรับ PPT, PPTX และ ODP."
---
แสดงวิธีการแทรกและเข้าถึงรูปภาพจากรูปในหน่วยความจำโดยใช้ **Aspose.Slides for Python via .NET** ตัวอย่างด้านล่างนี้สร้างรูปภาพในหน่วยความจำ วางลงบนสไลด์ และจากนั้นดึงคืนออกมา

## **เพิ่มรูปภาพ**

โค้ดนี้โหลดรูปภาพจากไฟล์และแทรกเป็นกรอบรูปบนสไลด์แรก

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # โหลดรูปภาพจากไฟล์.
        with open("image.png", "rb") as image_stream:
            # เพิ่มรูปภาพไปยังทรัพยากรของการนำเสนอ.
            image = presentation.images.add_image(image_stream)

        # แทรกกรอบรูปภาพที่แสดงรูปบนสไลด์แรก.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงรูปภาพ**

ตัวอย่างนี้ตรวจสอบให้แน่ใจว่าสไลด์มีกรอบรูปและจากนั้นเข้าถึงกรอบรูปแรกที่พบ

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงกรอบรูปภาพแรกบนสไลด์.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```