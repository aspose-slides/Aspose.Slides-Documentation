---
title: แสดงสไลด์งานนำเสนอเป็นภาพ SVG ใน Python ผ่าน Java
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- งานนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG เชิงโต้ตอบ
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน Python ผ่าน Java และควบคุมแบบอักษร, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้โดยอาศัย XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, แบบอักษร, รูปภาพ, และองค์ประกอบ SVG.

ใช้ [SVGOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, ทำนายได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/), เลือกสไลด์, และเขียนลงสตรีมด้วย [Slide.writeAsSvg](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/). ตัวอย่างต้องการไฟล์ `presentation.pptx` ที่มีอยู่แล้ว. ตัวอย่างแต่ละตัวจะเริ่ม JVM ถ้าจำเป็นและปิดสตรีมเอาต์พุตของมัน. ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

ชื่อไฟล์ใช้ [Slide.getSlideNumber](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getSlideNumber) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปแบบเดี่ยวด้วย [Shape.writeAsSvg](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) เมื่อผู้ดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปแบบนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setUseFrameSize) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setUseFrameRotation) กำหนดว่าจะใช้การหมุนของกรอบหรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) เป็น `True` เมื่อต้องการให้ข้อความแสดงโดยไม่มีลิการเจอร์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **ควบคุมข้อความและแบบอักษร**

### **แปลงข้อความทั้งหมดเป็นเวกเตอร์**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setVectorizeText) เป็น `True` เพื่อเขียนข้อความสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์. วิธีนี้จะขจัดการพึ่งพาแบบอักษรและทำให้ผลลัพธ์ภาพเดียวกันในหลายเบราว์เซอร์สม่ำเสมอขึ้น, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาได้ในรูปแบบข้อความของ SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **เลือกวิธีการจัดการแบบอักษรภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) ใช้ค่าจาก [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgexternalfontshandling/) สำหรับแบบอักษรที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์แบบอักษรแยก, `Embed` เพื่อฝังข้อมูลแบบอักษรใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้แบบอักษรภายนอกเป็นกราฟิก. ตรวจสอบสิทธิ์การใช้แบบอักษรก่อนฝัง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **ลดขนาดภาพที่ฝังไว้**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setPicturesCompression) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) เพื่อตัดส่วนของแหล่งที่มาที่ถูกครอบ, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setJpegQuality) เพื่อตั้งค่าคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยเสียคุณภาพหรือข้อมูลของภาพบางส่วน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **กำหนด ID ที่คงที่ให้กับรูปร่างและข้อความ**

ใช้คอนโทรลเลอร์การจัดรูปแบบ Python ที่ลงทะเบียนผ่าน `jpype.JProxy` เพื่อกำหนดค่าให้กับ [SvgShape.setId](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgshape/#setId) ของรูปร่างและ [SvgTSpan.setId](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgtspan/#setId) ขององค์ประกอบข้อความ `tspan`. กำหนดพร็อกซีด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

คอนโทรลเลอร์ต่อไปนี้ใช้ [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getOfficeInteropShapeId) ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับสเปนข้อความของมัน. วิธีนี้ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อไปของงานนำเสนอที่ไม่ได้เปลี่ยนแปลง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **เพิ่มตัวจัดการเหตุการณ์ SVG**

ในคอนโทรลเลอร์การจัดรูปแบบ Python, เรียก [SvgShape.setEventHandler](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgshape/#setEventHandler) พร้อมค่าจาก [SvgEvent](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก. ลงทะเบียนคอนโทรลเลอร์ผ่าน `jpype.JProxy` และกำหนดด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setShapeFormattingController). นิยามฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่โฮสต์ผลลัพธ์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

หน้าโฮสต์สามารถนิยามฟังก์ชัน JavaScript ที่ตัวจัดการอ้างอิงได้. การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ผู้ดูสไลด์, การปรับปรุงการเข้าถึง, และเวิร์กโฟลว์ SVG แบบโต้ตอบอื่นๆ ทำงานได้.

## **คำถามที่พบบ่อย**

**เมื่อไหร่ควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setVectorizeText) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgoptions/#setVectorizeText) เมื่อต้องการให้ข้อความทั้งหมดไม่ได้พึ่งพาแบบอักษร. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/th/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้แบบอักษรภายนอกเท่านั้น.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝัง, ลบพื้นที่ภาพที่ถูกครอบ, และเลือกใช้ไฟล์แบบอักษรที่เชื่อมโยงเมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้. ทดสอบผลลัพธ์เนื่องจากการลดความละเอียดของภาพ, การลดคุณภาพ JPEG, และการแปลงเป็นเวกเตอร์มีผลต่อคุณภาพและขนาดที่ต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังการส่งออกได้หรือไม่?**

ได้. กำหนด ID ผ่านคอนโทรลเลอร์การจัดรูปแบบ, จากนั้นเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์เบราว์เซอร์ของคุณ.