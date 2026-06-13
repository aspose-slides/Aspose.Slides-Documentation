---
title: ActiveX
type: docs
weight: 200
url: /th/python-net/examples/elements/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- เพิ่ม ActiveX
- เข้าถึง ActiveX
- ลบ ActiveX
- คุณสมบัติของ ActiveX
- ตัวอย่างโค้ด
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีค้นหา, แก้ไขและลบคอนโทรล ActiveX ใน Python ด้วย Aspose.Slides รวมถึงการอัปเดตคุณสมบัติเพื่อการนำเสนอ PowerPoint"
---
สาธิตวิธีการเพิ่ม, เข้าถึง, ลบ และกำหนดค่าคอนโทรล ActiveX ในงานนำเสนอโดยใช้ **Aspose.Slides for Python via .NET**.

## **เพิ่มคอนโทรล ActiveX**

แทรกคอนโทรล ActiveX ใหม่.

```py
def add_activex():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # เพิ่มคอนโทรล ActiveX ใหม่ (TextBox).
        control = slide.controls.add_control(slides.ControlType.WINDOWS_MEDIA_PLAYER, 50, 50, 100, 50)

        presentation.save("activex.pptm", slides.export.SaveFormat.PPTM)
```

## **เข้าถึงคอนโทรล ActiveX**

อ่านข้อมูลจากคอนโทรล ActiveX แรกบนสไลด์.

```py
def access_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # เข้าถึงคอนโทรล ActiveX ตัวแรก.
        control = slide.controls[0] if slide.controls else None
        if control is not None:
            # พิมพ์ชื่อคอนโทรล.
            print(f"Control Name: {control.name}")
```

## **ลบคอนโทรล ActiveX**

ลบคอนโทรล ActiveX ที่มีอยู่จากสไลด์.

```py
def remove_activex():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        if len(slide.controls) > 0:
            # ลบคอนโทรล ActiveX ตัวแรก.
            slide.controls.remove_at(0)

        presentation.save("activex_removed.pptm", slides.export.SaveFormat.PPTM)
```

## **ตั้งค่าคุณสมบัติของ ActiveX**

กำหนดค่าคุณสมบัติ ActiveX หลายรายการ.

```py
def set_activex_properties():
    with slides.Presentation("activex.pptm") as presentation:
        slide = presentation.slides[0]

        # สมมติว่าคอลเลกชันของ Control มีอย่างน้อยหนึ่ง Control.
        control = slide.controls[0]

        control.properties.add("Caption", "Click Me")
        control.properties.add("Enabled", "true")

        presentation.save("activex_properties.pptm", slides.export.SaveFormat.PPTM)
```