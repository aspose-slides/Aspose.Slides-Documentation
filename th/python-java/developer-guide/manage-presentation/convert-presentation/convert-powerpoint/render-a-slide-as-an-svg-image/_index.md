---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน Python ผ่าน Java
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกการส่งออก SVG
- SVG แบบโต้ตอบ
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน Python ผ่าน Java และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้และอ้างอิงจาก XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, โปรแกรมดูสไลด์, ขั้นตอนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกแต่ละไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพ, และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องกะทัดรัด, มีความคาดเดาได้ข้ามเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), เลือกสไลด์, และเขียนลงสตรีมด้วย [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). ตัวอย่างต้องใช้ไฟล์ `presentation.pptx` ที่มีอยู่แล้ว. ตัวอย่างแต่ละตัวจะเริ่ม JVM หากจำเป็นและปิดสตรีมผลลัพธ์ของมัน. ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกแต่ละไฟล์.

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

ชื่อไฟล์ใช้ [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) แทนดัชนีของลูป. คุณยังสามารถส่งออกรูปทรงเฉพาะด้วย [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) เมื่อโปรแกรมดูสไลด์หรือหน้าเว็บต้องการเพียงรูปทรงนั้น.

## **กำหนดค่าเอาต์พุต SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) จัดการการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) รวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) กำหนดว่าจะใช้การหมุนกรอบหรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) เป็น `True` เมื่อข้อความต้องเรนเดอร์โดยไม่มีลิการ์ฟ.

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

## **ควบคุมข้อความและฟอนต์**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมได้ว่าขข้อความจะคงเป็นข้อความหรือเปลี่ยนเป็นกราฟิกเวกเตอร์, และฟอนต์ภายนอกจะถูกรวมหรืออ้างอิงอย่างไร. ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลระหว่างความสอดคล้องทางภาพ, การเลือกข้อความ, และการพึ่งพาฟอนต์ใน SVG ที่ส่งออก.

### **แปลงข้อความทั้งหมดเป็นเวกเตอร์**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) เป็น `True` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์. สิ่งนี้จะกำจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้อีกต่อไป.

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

### **เลือกวิธีการจัดการฟอนต์ภายนอก**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์ฟอนต์แยกต่างหาก, `Embed` เพื่อรวมข้อมูลฟอนต์ใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก. ตรวจสอบสิทธิ์การใช้ฟอนต์ก่อนทำการฝังฟอนต์.

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

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) เพื่อลดความละเอียดของภาพที่ฝังไว้, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) เพื่อละเว้นพื้นที่ภาพที่ถูกตัด, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยเสียคุณภาพหรือข้อมูลภาพที่เก็บไว้.

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

## **ควบคุมความละเอียดการเรโซลูชันของเมตาฟายล์**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการแรสเตอร์เมตาฟายล์ขณะส่งออกเป็น SVG. ใช้เพื่อสมดุลระหว่างรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกแรสเตอร์. มันไม่ได้กำหนดค่า DPI ทั้งหมดสำหรับ SVG หรือบังคับให้วัตถุทุกอย่างบนสไลด์กลายเป็นภาพราสเตอร์.

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx) ซึ่งประกอบด้วยภาพ EMF ที่มีเส้นทแยงมุมใกล้กัน. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์นั้นที่ความละเอียดการแรสเตอร์สามระดับผ่าน [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). การตั้งค่าอื่น ๆ ของการส่งออกทั้งหมดเหมือนเดิมเพื่อให้สามารถเปรียบเทียบผลลัพธ์ได้.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

ในผลลัพธ์, EMF จะกลายเป็น PNG ที่ฝังหนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; มันไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นมิติพิกเซล.

| DPI การแรสเตอร์เมตาฟายล์ | มิติ PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของราสเตอร์ที่ฝังที่ขนาดการแสดงผลขยายเดียวกัน. เส้นทแยงมุมแสดงการเป็นพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงขึ้น, ในขณะที่ไฟล์ SVG เพิ่มขนาด. การเพิ่มค่าดังกล่าวไม่จำเป็นต้องปรับปรุงรายละเอียดทุกส่วนหรือเปลี่ยนภาพที่ส่งออกทั้งหมด.

![รายละเอียดเส้นทแยงมุมที่ขยายที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) ควบคุมการลดความละเอียดของภาพและสามารถปกปิดผลของการเปลี่ยนความละเอียดการแรสเตอร์เมตาฟายล์. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการแรสเตอร์เมตาฟายล์.

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

ใช้คอนโทรลเลอร์การจัดรูปแบบ Python ที่ลงทะเบียนผ่าน `jpype.JProxy` เพื่อกำหนดค่าให้กับ [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) สำหรับรูปร่างและ [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) สำหรับองค์ประกอบข้อความ `tspan`. กำหนดพร็อกซีด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

คอนโทรลเลอร์ต่อไปนี้ใช้ [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับสแปนข้อความของมัน. สิ่งนี้ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อของงานนำเสนอที่ไม่ได้เปลี่ยนแปลง.

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

## **เพิ่มอีเวนต์แฮนด์เลอร์สำหรับ SVG**

ในคอนโทรลเลอร์การจัดรูปแบบ Python, เรียก [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) พร้อมค่าของ [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) เพื่อเพิ่มอีเวนต์แฮนด์เลอร์ JavaScript ให้กับรูปร่างที่ส่งออก. ลงทะเบียนคอนโทรลเลอร์ผ่าน `jpype.JProxy` และกำหนดด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). นิยามฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่เป็นโฮสต์ของผลลัพธ์.

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

หน้าโฮสต์สามารถนิยามฟังก์ชัน JavaScript ที่อ้างอิงโดยแฮนด์เลอร์ได้. การกำหนด ID และแฮนด์เลอร์อีเวนต์ทำให้โปรแกรมดูสไลด์, การเสริมการเข้าถึง, และเวิร์กโฟลว์ SVG แบบโต้ตอบอื่น ๆ ทำงานได้.

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) เมื่อข้อความทั้งหมดต้องไม่ขึ้นกับฟอนต์. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) เมื่อเฉพาะข้อความที่ใช้ฟอนต์ภายนอกควรแปลงเป็นกราฟิก.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มจากการบีบอัดภาพที่ฝังไว้, ลบพื้นที่ภาพที่ตัดออก, และเลือกไฟล์ฟอนต์ที่ลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้นได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่แปลงเป็นเวกเตอร์แต่ละอย่างมีการแลกเปลี่ยนระหว่างคุณภาพและขนาดที่แตกต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกแล้วได้หรือไม่?**

ได้. กำหนด ID ผ่านคอนโทรลเลอร์การจัดรูปแบบ, จากนั้นเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ของเบราว์เซอร์ของคุณ.