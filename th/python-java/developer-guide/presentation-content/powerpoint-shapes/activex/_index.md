---
title: จัดการ ActiveX Controls ในการนำเสนอด้วย Python
linktitle: ActiveX
type: docs
weight: 80
url: /th/python-java/activex/
keywords:
- ActiveX
- ActiveX control
- จัดการ ActiveX
- เพิ่ม ActiveX
- แก้ไข ActiveX
- เครื่องเล่นสื่อ
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "แก้ไขกล่องข้อความและปุ่ม ActiveX, อัปเดตพรีวิวของการควบคุม, และใช้ซ้ำการควบคุม Windows Media Player ในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **คำนำ**

ActiveX controls ให้สไลด์ PowerPoint มีองค์ประกอบที่โต้ตอบได้ เช่น กล่องข้อความ, ปุ่มคำสั่ง, และเครื่องเล่นสื่อ. Aspose.Slides สำหรับ Python ผ่าน Java เปิดเผยการควบคุมของสไลด์ผ่าน [BaseSlide.getControls](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getControls). ใช้คอลเลกชันนี้เพื่อแก้ไขการควบคุม, ย้ายบนสไลด์, หรือเอาออก.

## **รายการควบคุม ActiveX และคุณสมบัติที่จัดเก็บ**

เพื่อสำรวจเทมเพลตที่ไม่คุ้นเคย ให้เปิดเพื่ออ่านและวนซ้ำผ่านการควบคุมบนแต่ละสไลด์ ตัวอย่างรายงานหมายเลขสไลด์, ชื่อการควบคุม, [getClassId](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getClassId), และแต่ละคู่คีย์‑ค่าใน [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties). โปรแกรมอ่านพรีเซนเทชันโดยไม่เปิดใช้งานการควบคุม, เรียกเหตุการณ์หรือแมโคร, เปลี่ยนค่า, หรือบันทึกไฟล์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("ActiveX.pptm")
try:
    for slide_number, slide in enumerate(presentation.getSlides(), start=1):
        for control in slide.getControls():
            print(f"Slide {slide_number} | {control.getName()} | {control.getClassId()}")
            properties = control.getProperties()
            if properties is None:
                print("  Properties unavailable")
            elif properties.getCount() == 0:
                print("  []")
            else:
                for name in properties.getNamesOfProperties():
                    print(f"  {name} = {properties.get_Item(name)}")
finally:
    presentation.dispose()
```

ผลลัพธ์ที่เลือกจาก `ActiveX.pptm` แสดงกล่องข้อความและปุ่มคำสั่ง.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

คอลเลกชันคุณสมบัติที่ว่างปรากฏเป็น `[]`. สำหรับการควบคุมที่ใช้การจัดเก็บแบบไบนารี, [getProperties](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getProperties) อาจคืนค่า `None`, แสดงเป็น `Properties unavailable`. หากต้องการเพียงชื่อ, ใช้ [getNamesOfProperties](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) หลังจากตรวจสอบว่าคอลเลกชันพร้อมใช้งาน. รายงานแสดงคุณสมบัติที่สามารถดึงจากพรีเซนเทชันได้ การควบคุมอาจสนับสนุนคุณสมบัติเพิ่มเติมในเวลารันไทม์.

## **แก้ไขควบคุม ActiveX**

ตัวอย่างคาดว่าพรีเซนเทชันที่เปิดใช้งานแมโครมีกล่องข้อความชื่อ `TextBox1` และปุ่มคำสั่งชื่อ `CommandButton1` บนสไลด์แรก. ตัวอย่างใช้ [control properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) เพื่อเปลี่ยนค่ากล่องข้อความและคำบรรยายของปุ่ม. แต่ละการควบคุมยังมีภาพพรีวิวแบบคงที่ที่ PowerPoint สามารถแสดงก่อนการเปิดใช้งาน. จัดเตรียมไฟล์ PNG สำหรับแต่ละการควบคุมเพื่อแสดงข้อความและรูปลักษณ์ที่อัปเดต. ตัวอย่างกำหนดรูปภาพเหล่านี้ผ่าน [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/control/#getSubstitutePictureFormat).

ตัวอย่างย้ายการควบคุมทั้งหมดบนสไลด์แรกลง 100 จุดโดยตั้งกรอบผ่าน [Control.setFrame](https://reference.aspose.com/slides/python-java/aspose.slides/control/#setFrame). จากนั้นบันทึกพรีเซนเทชันที่แก้ไขเป็นรูปแบบ PPTM, แล้วใช้ [ControlCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/controlcollection/#clear) เพื่อบันทึกสำเนาที่สองที่ลบการควบคุม ActiveX ทั้งหมดออกจากสไลด์นั้น.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame

presentation = Presentation("ActiveX.pptm")
try:
    controls = presentation.getSlides().get_Item(0).getControls()
    by_name = {str(control.getName()): control for control in controls}
    text_box = by_name.get("TextBox1")
    button = by_name.get("CommandButton1")
    if text_box is None or button is None or text_box.getProperties() is None or button.getProperties() is None:
        print("The first slide must contain both named controls with editable properties.")
    else:
        text_box_bytes = Path("text-box-preview.png").read_bytes()
        button_bytes = Path("button-preview.png").read_bytes()
        text_box_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(text_box_bytes))
        button_preview = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(button_bytes))
        text_box.getProperties().set_Item("Value", "Changed text")
        button.getProperties().set_Item("Caption", "Show message")
        text_box.getSubstitutePictureFormat().getPicture().setImage(text_box_preview)
        button.getSubstitutePictureFormat().getPicture().setImage(button_preview)

        for control in controls:
            frame = control.getFrame()
            moved = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(moved)
        presentation.save("edited-controls.pptm", SaveFormat.Pptm)

        controls.clear()
        presentation.save("removed-controls.pptm", SaveFormat.Pptm)
except OSError as error:
    print(f"Could not read a control preview: {error}")
finally:
    presentation.dispose()
```

## **เพิ่มควบคุม Media Player ActiveX**

เพื่อใช้ซ้ำการควบคุม Windows Media Player ที่กำหนดค่าไว้แล้ว, เริ่มต้นด้วยเทมเพลตที่สไลด์แรกมี player ชื่อ `WindowsMediaPlayer1`. [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) คัดลอกสไลด์ทั้งหมดไปยังพรีเซนเทชันใหม่. ตัวอย่างตั้งค่า `URL` ของ player ใน [properties collection](https://reference.aspose.com/slides/python-java/aspose.slides/controlpropertiescollection/) แล้วบันทึกสไลด์ที่คัดลอกเป็นสไลด์เดียวในผลลัพธ์. วิดีโอยังคงอยู่ภายนอก, ดังนั้นให้เลือกเส้นทางที่ player สามารถเข้าถึงได้ระหว่างการเล่น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

template = Presentation("template.pptx")
try:
    presentation = Presentation()
    try:
        slides = presentation.getSlides()
        slide = slides.addClone(template.getSlides().get_Item(0))
        player = next((control for control in slide.getControls() if control.getName() == "WindowsMediaPlayer1"), None)
        if player is None or player.getProperties() is None:
            print("The template slide must contain a named media player with editable properties.")
        else:
            player.getProperties().set_Item("URL", "Wildlife.mp4")
            slides.removeAt(0)
            presentation.save("linked-video.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    template.dispose()
```

## **คำถามที่พบบ่อย**

**Aspose.Slides สามารถรักษาควบคุม ActiveX ไว้ได้โดยไม่ต้องเรียกใช้หรือไม่?**

Yes. Aspose.Slides สามารถอ่านและบันทึกการควบคุม รวมถึงคุณสมบัติและตำแหน่งของพวกมันได้โดยไม่ต้องเปิดใช้งาน.

**ActiveX controls ต่างจากวัตถุ OLE อย่างไร?**

ActiveX controls ให้ผู้ใช้โต้ตอบกับสไลด์, ตัวอย่างเช่น การพิมพ์ข้อความหรือคลิกปุ่ม. วัตถุ OLE ([OLE object](/slides/th/python-java/manage-ole/)) ทำให้สไลด์สามารถบรรจุหรือเชื่อมโยงไปยังเนื้อหาที่จัดการโดยแอปพลิเคชันอื่น, เช่น แผ่นงาน Excel.

**เหตุการณ์ ActiveX จะยังคงเรียกใช้แมโคร VBA หลังจากที่ฉันบันทึกไฟล์พรีเซนเทชันด้วย Aspose.Slides หรือไม่?**

บันทึกพรีเซนเทชันในรูปแบบที่เปิดใช้งานแมโครเช่น PPTM เพื่อรักษาโปรเจกต์ VBA ไว้. PowerPoint สำหรับ Windows สามารถเรียกใช้ตัวจัดการเหตุการณ์ที่มีอยู่เมื่อการตั้งค่าความปลอดภัยอนุญาตให้ใช้ทั้ง ActiveX controls และแมโคร.