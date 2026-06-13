---
title: สร้างตัวดูงานนำเสนอใน Python
linktitle: ตัวดูงานนำเสนอ
type: docs
weight: 50
url: /th/python-net/presentation-viewer/
keywords:
- ดูงานนำเสนอ
- ตัวดูงานนำเสนอ
- สร้างตัวดูงานนำเสนอ
- ดู PPT
- ดู PPTX
- ดู ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "เรียนรู้วิธีสร้างตัวดูงานนำเสนอแบบกำหนดเองใน Python ด้วย Aspose.Slides แสดงไฟล์ PowerPoint (PPTX, PPT) และ OpenDocument (ODP) ได้อย่างง่ายดายโดยไม่ต้องใช้ Microsoft PowerPoint หรือซอฟต์แวร์สำนักงานอื่น"
---
## **บทนำ**

Aspose.Slides for Python ใช้เพื่อสร้างไฟล์งานนำเสนอที่มีสไลด์ สไลด์เหล่านี้สามารถดูได้โดยการเปิดงานนำเสนอใน Microsoft PowerPoint ตัวอย่างเช่น อย่างไรก็ตาม นักพัฒนาอาจบางครั้งต้องการดูสไลด์เป็นภาพในโปรแกรมดูภาพที่ต้องการหรือใช้ในตัวดูงานนำเสนอแบบกำหนดเอง ในกรณีเช่นนั้น Aspose.Slides อนุญาตให้คุณส่งออกสไลด์แต่ละสไลด์เป็นภาพ บทความนี้อธิบายวิธีทำ

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์ของงานนำเสนอด้วย Aspose.Slides ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์ตามดัชนีของมัน
3. เปิดสตรีมไฟล์
4. บันทึกสไลด์เป็นภาพ SVG ไปยังสตรีมไฟล์

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **สร้างภาพย่อของสไลด์**

Aspose.Slides ช่วยให้คุณสร้างภาพย่อของสไลด์ได้ เพื่อสร้างภาพย่อของสไลด์โดยใช้ Aspose.Slides ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์ตามดัชนีของมัน
3. สร้างภาพย่อของสไลด์ที่อ้างอิงโดยใช้สเกลที่ต้องการ
4. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **สร้างภาพย่อของสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อของสไลด์ด้วยมิติที่กำหนดโดยผู้ใช้ ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
2. รับอ้างอิงของสไลด์ตามดัชนีของมัน
3. สร้างภาพย่อของสไลด์ที่อ้างอิงโดยใช้มิติที่ระบุ
4. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **สร้างภาพย่อของสไลด์พร้อมบันทึกผู้บรรยาย**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกผู้บรรยายโดยใช้ Aspose.Slides ให้ทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/)
2. ใช้คุณสมบัติ `RenderingOptions.slides_layout_options` เพื่อตั้งค่าตำแหน่งของบันทึกผู้บรรยาย
3. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/)
4. รับอ้างอิงของสไลด์ตามดัชนีของมัน
5. สร้างภาพย่อของสไลด์ที่อ้างอิงโดยใช้ตัวเลือกการเรนเดอร์
6. บันทึกภาพย่อในรูปแบบภาพที่คุณต้องการ

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **ตัวอย่างสด**

ลองแอปฟรี [**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูสิ่งที่คุณสามารถทำได้ด้วย Aspose.Slides API:

[![ตัวดู PowerPoint ออนไลน์](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/th/viewer/)

## **คำถามที่พบบ่อย**

**ฉันสามารถฝังตัวดูงานนำเสนอในเว็บแอปพลิเคชัน ASP.NET ได้หรือไม่?**

ใช่ คุณสามารถใช้ Aspose.Slides บนเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็น [ภาพ](/slides/th/python-net/convert-powerpoint-to-png/) หรือ [HTML](/slides/th/python-net/convert-powerpoint-to-html/) แล้วแสดงในเบราว์เซอร์ ฟีเจอร์การนำทางและการซูมสามารถทำได้ด้วย JavaScript เพื่อประสบการณ์แบบโต้ตอบ

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในตัวดู .NET ที่กำหนดเองคืออะไร?**

วิธีที่แนะนำคือเรนเดอร์สไลด์แต่ละสไลด์เป็น [ภาพ](/slides/th/python-net/convert-powerpoint-to-png/) (เช่น PNG หรือ SVG) หรือแปลงเป็น [HTML](/slides/th/python-net/convert-powerpoint-to-html/) ด้วย Aspose.Slides แล้วแสดงผลลัพธ์ภายใน picture box (สำหรับเดสก์ท็อป) หรือคอนเทนเนอร์ HTML (สำหรับเว็บ)

**ฉันจะจัดการกับงานนำเสนอขนาดใหญ่ที่มีสไลด์จำนวนมากอย่างไร?**

สำหรับเด็คขนาดใหญ่ ควรพิจารณาการโหลดแบบ lazy-loading หรือการเรนเดอร์ตามต้องการของสไลด์ ซึ่งหมายถึงการสร้างเนื้อหาของสไลด์เฉพาะเมื่อผู้ใช้นำทางไปยังสไลด์นั้นเท่านั้น เพื่อประหยัดหน่วยความจำและเวลาโหลด