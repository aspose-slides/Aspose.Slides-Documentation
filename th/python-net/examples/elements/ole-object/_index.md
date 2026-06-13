---
title: วัตถุ OLE
type: docs
weight: 210
url: /th/python-net/examples/elements/ole-object/
keywords:
- วัตถุ OLE
- เพิ่มวัตถุ OLE
- เข้าถึงวัตถุ OLE
- ลบวัตถุ OLE
- อัปเดตวัตถุ OLE
- ตัวอย่างโค้ด
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ทำงานกับวัตถุ OLE ใน Python ด้วย Aspose.Slides: แทรกหรืออัปเดตไฟล์ที่ฝังไว้ ตั้งค่ารูปไอคอนหรือลิงก์ ดึงเนื้อหา ควบคุมพฤติกรรมสำหรับ PPT, PPTX และ ODP."
---
สาธิตการฝังไฟล์เป็นอ็อบเจ็กต์ OLE และอัปเดตข้อมูลของมันโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มอ็อบเจ็กต์ OLE**

ฝังไฟล์ PDF ลงในพรีเซนเทชัน.

```py
def add_ole_object():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # โหลดข้อมูล PDF เพื่อฝัง.
        with open("doc.pdf", "rb") as file_stream:
            data_info = slides.dom.ole.OleEmbeddedDataInfo(file_stream.read(), "pdf")

        # เพิ่มเฟรมอ็อบเจ็กต์ OLE ไปยังสไลด์.
        ole_frame = slide.shapes.add_ole_object_frame(20, 20, 50, 50, data_info)

        presentation.save("ole_frame.pptx", slides.export.SaveFormat.PPTX)
```

## **เข้าถึงอ็อบเจ็กต์ OLE**

ดึงเฟรมอ็อบเจ็กต์ OLE ตัวแรกบนสไลด์.

```py
def access_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # ดึงเฟรมอ็อบเจ็กต์ OLE ตัวแรกบนสไลด์.
        first_ole = next(shape for shape in slide.shapes if isinstance(shape, slides.OleObjectFrame))
```

## **ลบอ็อบเจ็กต์ OLE**

ลบอ็อบเจ็กต์ OLE ที่ฝังไว้จากสไลด์.

```py
def remove_ole_object():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นวัตถุ OleObjectFrame.
        ole_frame = slide.shapes[0]

        slide.shapes.remove(ole_frame)

        presentation.save("ole_frame_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **อัปเดตข้อมูลอ็อบเจ็กต์ OLE**

แทนที่ข้อมูลที่ฝังอยู่ในอ็อบเจ็กต์ OLE ที่มีอยู่แล้ว.

```py
def update_ole_object_data():
    with slides.Presentation("ole_frame.pptx") as presentation:
        slide = presentation.slides[0]

        # สมมติว่า shape แรกเป็นวัตถุ OleObjectFrame.
        ole_frame = slide.shapes[0]

        with open("Picture.png", "rb") as picture_stream:
            new_data = slides.dom.ole.OleEmbeddedDataInfo(picture_stream.read(), "png")

        # อัปเดตวัตถุ OLE ด้วยข้อมูลที่ฝังใหม่.
        ole_frame.set_embedded_data(new_data)

        presentation.save("ole_frame_updated.pptx", slides.export.SaveFormat.PPTX)
```