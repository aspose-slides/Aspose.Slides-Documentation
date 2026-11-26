---
title: จัดการ ActiveX Controls ในงานนำเสนอด้วย Python
linktitle: ActiveX
type: docs
weight: 80
url: /th/python-net/activex/
keywords:
- ActiveX
- คอนโทรล ActiveX
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "แก้ไขกล่องข้อความและปุ่ม ActiveX, ปรับปรุงภาพตัวอย่างของคอนโทรล, และใช้ซ้ำคอนโทรล Windows Media Player ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **บทนำ**

ActiveX controls ให้สไลด์ PowerPoint มีองค์ประกอบโต้ตอบ เช่น กล่องข้อความ ปุ่มคำสั่ง และเครื่องเล่นสื่อ Aspose.Slides for Python via .NET เปิดเผยการควบคุมของสไลด์ผ่าน [Slide.controls](https://reference.aspose.com/slides/python-net/aspose.slides/slide/controls/). ใช้คอลเลกชันนี้เพื่อแก้ไขการควบคุม ย้ายบนสไลด์ หรือเอาออก

## **รายการ ActiveX Controls และคุณสมบัติที่เก็บไว้**

เพื่อสำรวจเทมเพลตที่ไม่คุ้นเคย ให้เปิดเพื่ออ่านและวนซ้ำการควบคุมในแต่ละสไลด์ ตัวอย่างแสดงหมายเลขสไลด์ ชื่อการควบคุม [class_id](https://reference.aspose.com/slides/python-net/aspose.slides/control/class_id/) และแต่ละคู่คีย์‑ค่าใน [properties](https://reference.aspose.com/slides/python-net/aspose.slides/control/#properties). โปรแกรมจะอ่านงานนำเสนอโดยไม่ทำการเปิดใช้งานการควบคุม การเรียกเหตุการณ์หรือมาโคร การเปลี่ยนค่า หรือการบันทึกไฟล์

```python
import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        for control in slide.controls:
            print(f"Slide {slide_number} | {control.name} | {control.class_id}")
            properties = control.properties
            if properties is None:
                print("  Properties unavailable")
                continue

            if properties.count == 0:
                print("  []")
            for entry in properties:
                print(f"  {entry.key} = {entry.value}")
```

ผลลัพธ์ที่เลือกจาก `ActiveX.pptm` แสดงกล่องข้อความและปุ่มคำสั่ง

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

คอลเลกชันคุณสมบัติที่ว่างปรากฏเป็น `[]`. สำหรับการควบคุมที่ใช้การจัดเก็บแบบไบนารี `properties` สามารถคืนค่า `None` ซึ่งจะแสดงเป็น `Properties unavailable`. หากคุณต้องการเฉพาะชื่อ ให้ใช้ [names_of_properties](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/names_of_properties/) หลังจากตรวจสอบว่าเป็น `None`. รายงานแสดงคุณสมบัติที่มีในงานนำเสนอ การควบคุมอาจสนับสนุนคุณสมบัติเพิ่มเติมขณะทำงาน

## **ปรับแต่ง ActiveX Controls**

ตัวอย่างคาดหวังงานนำเสนอที่เปิดใช้งานมาโครโดยมีกล่องข้อความชื่อ `TextBox1` และปุ่มคำสั่งชื่อ `CommandButton1` บนสไลด์แรก ใช้ [control properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำบรรยายปุ่ม แต่ละการควบคุมยังมีภาพตัวอย่างแบบคงที่ที่ PowerPoint สามารถแสดงก่อนการเปิดใช้งาน จัดเตรียม PNG สำหรับแต่ละการควบคุมเพื่อแสดงข้อความและลักษณะที่อัปเดต ตัวอย่างกำหนดภาพเหล่านี้ผ่าน [Control.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/control/substitute_picture_format/)

ตัวอย่างย้ายการควบคุมทั้งหมดบนสไลด์แรกลง 100 พอยต์โดยการเปลี่ยน [frame](https://reference.aspose.com/slides/python-net/aspose.slides/control/frame/). บันทึกงานนำเสนอที่แก้ไขในรูปแบบ PPTM จากนั้นใช้ [ControlCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides/controlcollection/clear/) เพื่อบันทึกสำเนาที่สองโดยลบ ActiveX controls ทั้งหมดออกจากสไลด์นั้น

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation("ActiveX.pptm") as presentation:
    controls = presentation.slides[0].controls
    text_box = next((control for control in controls if control.name == "TextBox1"), None)
    button = next((control for control in controls if control.name == "CommandButton1"), None)
    text_box_preview = Path("text-box-preview.png")
    button_preview = Path("button-preview.png")

    if text_box is None or button is None or text_box.properties is None or button.properties is None:
        print("The first slide must contain both named controls with editable properties.")
    elif not text_box_preview.is_file() or not button_preview.is_file():
        print("Supply both preview images before updating the controls.")
    else:
        text_box.properties.remove("Value")
        text_box.properties.add("Value", "Changed text")
        button.properties.remove("Caption")
        button.properties.add("Caption", "Show message")

        for control, preview in [(text_box, text_box_preview), (button, button_preview)]:
            image_data = preview.read_bytes()
            control.substitute_picture_format.picture.image = presentation.images.add_image(image_data)

        for control in controls:
            frame = control.frame
            control.frame = slides.ShapeFrame(frame.x, frame.y + 100, frame.width, frame.height, frame.flip_h, frame.flip_v, frame.rotation)

        presentation.save("edited-controls.pptm", slides.export.SaveFormat.PPTM)
        controls.clear()
        presentation.save("removed-controls.pptm", slides.export.SaveFormat.PPTM)
```

## **เพิ่มการควบคุม Media Player ของ ActiveX**

เพื่อใช้ประโยชน์จาก Windows Media Player ที่ตั้งค่าแล้ว เริ่มด้วยเทมเพลตที่สไลด์แรกมีผู้เล่นชื่อ `WindowsMediaPlayer1`. [SlideCollection.add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) คัดลอกสไลด์ทั้งหมดไปยังงานนำเสนอใหม่ ตัวอย่างกำหนด `URL` ของผู้เล่นใน [properties collection](https://reference.aspose.com/slides/python-net/aspose.slides/controlpropertiescollection/) และบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์ วิดีโอจะคงเป็นไฟล์ภายนอก ดังนั้นให้เลือกเส้นทางที่ผู้เล่นสามารถเข้าถึงระหว่างการเล่น

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as template, slides.Presentation() as presentation:
    slide = presentation.slides.add_clone(template.slides[0])
    player = next((control for control in slide.controls if control.name == "WindowsMediaPlayer1"), None)

    if player is None or player.properties is None:
        print("The template slide must contain a named media player with editable properties.")
    else:
        player.properties.remove("URL")
        player.properties.add("URL", "Wildlife.mp4")
        presentation.slides.remove_at(0)
        presentation.save("linked-video.pptx", slides.export.SaveFormat.PPTX)
```

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถรักษา ActiveX controls ไว้โดยไม่ต้องทำงานหรือไม่?**

ใช่. Aspose.Slides สามารถอ่านและบันทึกการควบคุม รวมถึงคุณสมบัติและตำแหน่งของมัน โดยไม่ต้องเปิดใช้งาน

**ActiveX controls แตกต่างจากวัตถุ OLE อย่างไร?**

ActiveX controls ให้ผู้ใช้โต้ตอบกับสไลด์ เช่น การป้อนข้อความหรือคลิกปุ่ม ส่วน [OLE object](/slides/th/python-net/manage-ole/) ทำให้สไลด์สามารถมีหรือเชื่อมโยงกับเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น เช่น แผ่นงาน Excel

**เหตุการณ์ของ ActiveX จะยังคงเรียกใช้มาโคร VBA หลังจากที่ฉันบันทึกงานนำเสนอด้วย Aspose.Slides หรือไม่?**

บันทึกงานนำเสนอในรูปแบบที่เปิดใช้งานมาโครเช่น PPTM เพื่อรักษาโครงการ VBA ไว้ PowerPoint สำหรับ Windows สามารถเรียกใช้ตัวจัดการเหตุการณ์ที่มีอยู่เมื่อการตั้งค่าความปลอดภัยอนุญาตให้ทั้ง ActiveX controls และมาโครทำงานได้