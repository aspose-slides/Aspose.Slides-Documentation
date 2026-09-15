---
title: สร้างโปรแกรมดูงานนำเสนอใน Python ผ่าน Java
linktitle: โปรแกรมดูงานนำเสนอ
type: docs
weight: 50
url: /th/python-java/presentation-viewer/
keywords:
- ดูงานนำเสนอ
- โปรแกรมดูงานนำเสนอ
- สร้างโปรแกรมดูงานนำเสนอ
- ดู PPT
- ดู PPTX
- ดู ODP
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างโปรแกรมดูงานนำเสนอแบบกำหนดเองใน Python ผ่าน Java ด้วย Aspose.Slides. แสดงไฟล์ PowerPoint และ OpenDocument ได้อย่างง่ายดายโดยไม่ต้องใช้ Microsoft PowerPoint."
---
## **คำนำ**

Aspose.Slides for Python via Java ใช้สำหรับสร้างไฟล์งานนำเสนอที่มีสไลด์ สไลด์เหล่านี้สามารถเปิดดูได้โดยเปิดงานนำเสนอใน Microsoft PowerPoint เป็นต้น อย่างไรก็ตาม บางครั้งนักพัฒนาอาจต้องการดูสไลด์เป็นภาพในโปรแกรมดูภาพที่ชื่นชอบหรือสร้างโปรแกรมดูงานนำเสนอของตนเอง ในกรณีดังกล่าว Aspose.Slides ให้คุณส่งออกสไลด์เดี่ยวเป็นภาพได้ บทความนี้อธิบายวิธีทำ

## **สร้างภาพ SVG จากสไลด์**

เพื่อสร้างภาพ SVG จากสไลด์งานนำเสนอด้วย Aspose.Slides โปรดทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนีของมัน  
3. เปิดสตรีมไบต์  
4. บันทึกสไลด์เป็นภาพ SVG ไปยังสตรีมและเขียนลงไฟล์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **สร้าง SVG พร้อม ID รูปทรงที่กำหนดเอง**

Aspose.Slides สามารถใช้เพื่อสร้าง[SVG](https://docs.fileformat.com/page-description-language/svg/)จากสไลด์ด้วย ID รูปทรงที่กำหนดเอง ได้โดยใช้เมธอด[SvgShape.setId](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgshape/#setId)จาก[SvgShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgshape/) `CustomSvgShapeFormattingController` สามารถใช้ตั้งค่า ID รูปทรงได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **สร้างภาพย่อสไลด์**

Aspose.Slides ช่วยคุณสร้างภาพย่อของสไลด์ เพื่อสร้างภาพย่อของสไลด์ด้วย Aspose.Slides โปรดทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนีของมัน  
3. รับภาพย่อของสไลด์ที่อ้างอิงด้วยสเกลที่กำหนด  
4. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **สร้างภาพย่อสไลด์พร้อมขนาดที่กำหนดโดยผู้ใช้**

เพื่อสร้างภาพย่อสไลด์พร้อมขนาดที่กำหนดโดยผู้ใช้ โปรดทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
2. รับอ้างอิงสไลด์ตามดัชนีของมัน  
3. รับภาพย่อของสไลด์ที่อ้างอิงด้วยขนาดที่กำหนด  
4. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **สร้างภาพย่อสไลด์พร้อมบันทึกสำหรับผู้บรรยาย**

เพื่อสร้างภาพย่อของสไลด์พร้อมบันทึกสำหรับผู้บรรยายด้วย Aspose.Slides โปรดทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส[RenderingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/)  
2. ใช้เมธอด[RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) เพื่อตั้งค่าตำแหน่งของบันทึกสำหรับผู้บรรยาย  
3. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
4. รับอ้างอิงสไลด์ตามดัชนีของมัน  
5. รับภาพย่อของสไลด์ที่อ้างอิงด้วยการตั้งค่า RenderingOptions  
6. บันทึกภาพย่อในรูปแบบภาพที่ต้องการใดก็ได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **ตัวอย่างสด**

คุณสามารถลองใช้แอปฟรี[**Aspose.Slides Viewer**](https://products.aspose.app/slides/th/viewer/) เพื่อดูสิ่งที่คุณสามารถทำได้ด้วย Aspose.Slides API:

![ตัวชม PowerPoint ออนไลน์](online-PowerPoint-viewer.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถฝังโปรแกรมดูงานนำเสนอในเว็บแอปพลิเคชันได้หรือไม่?**

ได้ คุณสามารถใช้ Aspose.Slides ฝั่งเซิร์ฟเวอร์เพื่อเรนเดอร์สไลด์เป็นภาพหรือ HTML แล้วแสดงผลในเบราว์เซอร์ คุณลักษณะการนำทางและการซูมสามารถทำด้วย JavaScript เพื่อสร้างประสบการณ์เชิงโต้ตอบ

**วิธีที่ดีที่สุดในการแสดงสไลด์ภายในโปรแกรมดูแบบกำหนดเองคืออะไร?**

วิธีที่แนะนำคือเรนเดอร์แต่ละสไลด์เป็นภาพ (เช่น PNG หรือ SVG) หรือแปลงเป็น HTML ด้วย Aspose.Slides จากนั้นแสดงผลลัพธ์ใน picture box (สำหรับแอปเดสก์ท็อป) หรือ container ของ HTML (สำหรับเว็บ)

**ฉันจะจัดการกับงานนำเสนอขนาดใหญ่ที่มีสไลด์จำนวนมากอย่างไร?**

สำหรับเด็คขนาดใหญ่ ควรใช้การโหลดแบบ lazy หรือการเรนเดอร์ตามความต้องการของสไลด์ ซึ่งหมายถึงการสร้างเนื้อหาสไลด์เฉพาะเมื่อผู้ใช้เลื่อนไปยังสไลด์นั้น ลดการใช้หน่วยความจำและเวลาโหลด