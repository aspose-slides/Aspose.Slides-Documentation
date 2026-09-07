---
title: แปลงการนำเสนอ PowerPoint เป็น GIF เคลื่อนไหวใน Python
linktitle: PowerPoint เป็น GIF
type: docs
weight: 65
url: /th/python-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF เคลื่อนไหว
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น GIF
- การนำเสนอเป็น GIF
- สไลด์เป็น GIF
- PPT เป็น GIF
- PPTX เป็น GIF
- บันทึก PPT เป็น GIF
- บันทึก PPTX เป็น GIF
- ส่งออก PPT เป็น GIF
- ส่งออก PPTX เป็น GIF
- การตั้งค่าเริ่มต้น
- การตั้งค่าที่กำหนดเอง
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint (PPT, PPTX) เป็น GIF เคลื่อนไห
วได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน Java ผลลัพธ์เร็วและคุณภาพสูง"
---
## **ภาพรวม**

Aspose.Slides for Python via Java ช่วยให้คุณแปลงการนำเสนอ PowerPoint เป็นไฟล์ GIF เคลื่อนไหวได้ด้วยเพียงไม่กี่บรรทัดของโค้ด สิ่งนี้เป็นประโยชน์สำหรับการแชร์เนื้อหาสไลด์ในหน้าเว็บ, โปรแกรมส่งข้อความ, หรือเอกสาร บทความนี้อธิบายวิธีส่งออกการนำเสนอโดยใช้การตั้งค่าเริ่มต้นและวิธีการปรับขนาดเฟรม, ความล่าช้าของสไลด์, และอัตราเฟรมการเปลี่ยนผ่านผ่าน [GifOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/gifoptions/).

## **แปลงการนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่าเริ่มต้น**

ตัวอย่าง Python ด้านล่างโหลด `pres.pptx` และบันทึกเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่ามาตรฐาน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
เพื่อปรับแต่งผลลัพธ์ของ GIF ให้ส่งอ็อบเจกต์ [GifOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/gifoptions/) ขณะบันทึกตามที่แสดงด้านล่าง.
{{% /alert %}}

## **แปลงการนำเสนอเป็น GIF เคลื่อนไหวโดยใช้การตั้งค่าแบบกำหนดเอง**

ใช้ [setFrameSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/gifoptions/#setFrameSize) เพื่อระบุขนาดมิติล่วงออกเป็นพิกเซล, [setDefaultDelay](https://reference.aspose.com/slides/th/python-java/aspose.slides/gifoptions/#setDefaultDelay) เพื่อตั้งค่าความล่าช้าของสไลด์เริ่มต้นเป็นมิลลิวินาที, และ [setTransitionFps](https://reference.aspose.com/slides/th/python-java/aspose.slides/gifoptions/#setTransitionFps) เพื่อควบคุมอัตราเฟรมการเปลี่ยนผ่าน.

ตัวอย่างต่อไปนี้ส่งออก GIF ขนาด 960 × 720 พร้อมความล่าช้าของสไลด์เริ่มต้นสองวินาทีและ 35 เฟรมต่อวินาทีสำหรับการเปลี่ยนผ่าน ค่าเริ่มต้นของความล่าช้าจะใช้เมื่อไม่ได้กำหนดเวลา advance-after ของสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
คุณยังสามารถลองตัวแปลงฟรี [Text to GIF](https://products.aspose.app/slides/th/text-to-gif) ของ Aspose ได้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ถ้าแบบอักษรที่ใช้ในการนำเสนอไม่ได้ติดตั้งในระบบจะทำอย่างไร?**

ให้ติดตั้งแบบอักษรที่ขาดหายไปหรือ[กำหนดค่าแบบอักษรสำรอง](/slides/th/python-java/powerpoint-fonts/). การแทนที่แบบอักษรอาจทำให้ลักษณะของ GIF ที่ส่งออกเปลี่ยนไป การทำให้แบบอักษรเดิมพร้อมใช้งานเป็นสิ่งสำคัญเมื่อจำเป็นต้องรักษาแนวการออกแบบของการนำเสนอ

**ฉันสามารถวางลายน้ำบนเฟรมของ GIF ได้หรือไม่?**

ได้. [เพิ่มวัตถุหรือโลโก้กึ่งโปร่งแสง](/slides/th/python-java/watermark/) ไปยังสไลด์แม่ที่เกี่ยวข้องหรือสไลด์แต่ละอันก่อนทำการส่งออก ลายน้ำจะกลายเป็นส่วนหนึ่งของเนื้อหาสไลด์ที่เรนเดอร์