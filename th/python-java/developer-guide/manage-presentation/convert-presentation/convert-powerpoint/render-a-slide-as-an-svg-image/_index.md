---
title: แสดงสไลด์การนำเสนอเป็นภาพ SVG ใน Python ผ่าน Java
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/python-java/render-a-slide-as-an-svg-image/
keywords:
  - PowerPoint ไปเป็น SVG
  - การนำเสนอไปเป็น SVG
  - สไลด์ไปเป็น SVG
  - PPT ไปเป็น SVG
  - PPTX ไปเป็น SVG
  - ตัวเลือกการส่งออก SVG
  - SVG เชิงโต้ตอบ
  - PowerPoint
  - การนำเสนอ
  - Python
  - Java
  - Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน Python ผ่าน Java และควบคุมฟอนต์, ข้อความ, รูปภาพ, ID, และเหตุการณ์ด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG เป็นรูปแบบภาพที่ขยายได้โดยอิง XML ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพ, และองค์ประกอบ SVG.  
ใช้ [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, คาดเดาได้ในทุกเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), เลือกสไลด์, และเขียนลงในสตรีมด้วย [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). ตัวอย่างต้องการไฟล์ `presentation.pptx` ที่มีอยู่แล้ว. ตัวอย่างแต่ละอันจะเริ่ม JVM หากจำเป็นและปิดสตรีมผลลัพธ์ของมัน. ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์.

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

ชื่อไฟล์ใช้ [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) เมื่อตัวดูสไลด์หรือหน้าเว็บต้องการเฉพาะรูปร่างนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) จะรวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) กำหนดว่าควรใช้การหมุนกรอบหรือไม่. ตั้งค่า [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) เป็น `True` เมื่อข้อความต้องการเรนเดอร์โดยไม่มีลิการเจอร์.

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

## **ควบคุมการตัดส่วนปลายเส้นที่หัวลูกศร**

SVG 1.1 ไม่มีการตั้งค่า marker inset เพื่อระบุว่าควรหยุดเส้นที่ตำแหน่งใดใต้หัวลูกศร. โดยค่าเริ่มต้น, Aspose.Slides จะทำให้เส้นที่ส่งออกสั้นลงเพื่อให้เส้นขอบไม่ยื่นผ่านเครื่องหมาย. เรียก [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) พร้อมค่า `True` เพื่อวาดเส้นขอบไปจนถึงจุดสิ้นสุดเดิมของเส้น. การตั้งค่านี้มีผลต่อการส่งออก SVG เท่านั้น. เส้นยังคงตำแหน่งและความยาวบนสไลด์.

ตัวอย่างวาดหัวลูกศรรูปสามเหลี่ยมและรูปเพชรบนเส้นที่กว้าง 2 และ 10 จุด. มันส่งออกสไลด์เดียวกันสองครั้ง, โดยเปลี่ยนเฉพาะตัวเลือกการตัดส่วนปลาย.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

การเปรียบเทียบแสดงหัวลูกศรรูปสามเหลี่ยมบนเส้น 10 จุด. เมื่อเปิดการตัดส่วนปลาย, ปลายจะคม. เมื่อปิดการตัดส่วนปลาย, เส้นขอบจะยื่นผ่านด้านเอียงของเครื่องหมายและทำให้ปลายแบน.

![สามเหลี่ยมขนาด 10 จุดที่ขยายขึ้นพร้อมปลายคมเมื่อเปิดการตัดส่วนปลายและปลายแบนเมื่อปิดการตัดส่วนปลาย](line-end-cropping.png)

ในเส้นอื่นจากตัวอย่าง, เส้นขอบที่ยื่นออกมานั้นมองเห็นได้น้อยลงบนสามเหลี่ยม 2 จุด. เพชรที่เติมสีจะปกคลุมส่วนปลายของเส้นขอบในทั้งสองความกว้าง.

## **ควบคุมข้อความและฟอนต์**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมได้ว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงฟอนต์ภายนอก. ตัวเลือกต่อไปนี้ช่วยให้คุณสมดุลความสอดคล้องทางภาพ, การเลือกข้อความ, และการพึ่งพาฟอนต์ใน SVG ที่ส่งออก.

### **แปลงข้อความทั้งหมดเป็นเวกเตอร์**

ตั้งค่า [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) เป็น `True` เพื่อเขียนข้อความบนสไลด์ทั้งหมดเป็นกราฟิกเวกเตอร์. วิธีนี้กำจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในทุกเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้อีกต่อไป.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก. เลือก `AddLinksToFontFiles` เพื่ออ้างอิงไฟล์ฟอนต์แยก, `Embed` เพื่อรวมข้อมูลฟอนต์ไว้ใน SVG, หรือ `Vectorize` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก. ตรวจสอบสิทธิการใช้งานฟอนต์ก่อนทำการฝังฟอนต์.

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

## **ลดขนาดภาพที่ฝังอยู่**

ใช้ [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) เพื่อลดความละเอียดของรูปภาพที่ฝังอยู่, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) เพื่อตัดส่วนที่ถูกครอปของแหล่งภาพ, และ [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) เพื่อตั้งค่าคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้ลดขนาดไฟล์โดยเสียความละเอียดหรือข้อมูลของภาพที่เก็บไว้.

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

## **ควบคุมความละเอียดการเรสเตอร์เมต้าไฟล์**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการเรเซอร์เมต้าไฟล์ในระหว่างการส่งออก SVG. ใช้เพื่อสมดุลรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกทำให้เป็นราสเตอร์. ค่านี้ไม่ได้กำหนด DPI ทั่วโลกสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพราสเตอร์.

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx), ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมห่างกันใกล้กัน. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์ที่กล่าวถึงในสามระดับความละเอียดการเรเซอร์ผ่าน [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). การตั้งค่าการส่งออกอื่น ๆ เหมือนเดิมเพื่อให้เปรียบเทียบผลลัพธ์ได้.

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

ในผลลัพธ์, EMF จะกลายเป็น PNG ที่ฝังอยู่หนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้เป็นของงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นขนาดพิกเซล.

| DPI การเรเซอร์เมต้าไฟล์ | ขนาด PNG ที่ฝังอยู่ | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพราสเตอร์ที่ฝังไว้ในขนาดการแสดงผลที่ขยายเท่าเดิม. เส้นทแยงมุมแสดงการเป็นพิกเซลที่เห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงกว่า, ในขณะที่ไฟล์ SVG เพิ่มขนาด. การเพิ่มค่านี้ไม่ได้หมายความว่าจะปรับปรุงรายละเอียดทั้งหมดหรือเปลี่ยนภาพที่ส่งออกทั้งหมด.

![รายละเอียดเส้นทแยงมุมที่ขยายใน 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) ควบคุมการลดความละเอียดของภาพและสามารถปิดบังผลของการเปลี่ยนความละเอียดการเรเซอร์เมต้าไฟล์. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการเรเซอร์เมต้าไฟล์.

## **กำหนด ID คงที่ให้กับรูปร่างและข้อความ**

ใช้คอนโทรลเลอร์ฟอร์แมต Python ที่ลงทะเบียนผ่าน `jpype.JProxy` เพื่อกำหนดค่า [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) ให้กับรูปร่างและ [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) ให้กับองค์ประกอบ `tspan` ของข้อความ. กำหนดพร็อกซีด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

คอนโทรลเลอร์ต่อไปนี้ใช้ [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), ซึ่งคงที่ตลอดอายุของรูปร่าง, และตัวนับที่ทำซ้ำได้สำหรับสโปนข้อความของมัน. วิธีนี้ทำให้ ID ที่สร้างขึ้นเหมาะสำหรับการประมวลผลต่อจากงานนำเสนอที่ไม่เปลี่ยนแปลง.

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

ในคอนโทรลเลอร์ฟอร์แมต Python, เรียก [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) พร้อมค่า [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) เพื่อเพิ่มตัวจัดการเหตุการณ์ JavaScript ให้กับรูปร่างที่ส่งออก. ลงทะเบียนคอนโทรลเลอร์ผ่าน `jpype.JProxy` และกำหนดด้วย [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). กำหนดฟังก์ชัน JavaScript ในหน้าเว็บหรือเอกสาร SVG ที่เป็นโฮสต์ของผลลัพธ์.

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

หน้าโฮสต์สามารถกำหนดฟังก์ชัน JavaScript ที่อ้างอิงโดยตัวจัดการได้. การกำหนด ID และตัวจัดการเหตุการณ์ทำให้ตัวดูสไลด์, การเพิ่มการเข้าถึง, และกระบวนการทำงานแบบโต้ตอบของ SVG อื่น ๆ ทำงานได้.

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) แทน [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

ใช้ [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) เมื่อข้อความทั้งหมดต้องไม่พึ่งพาฟอนต์. ใช้ [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้ฟอนต์ภายนอกเท่านั้น.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝัง, ลบพื้นที่ภาพที่ถูกครอป, และเลือกไฟล์ฟอนต์ที่เชื่อมโยงเมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการไฟล์เหล่านั้นได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่แปลงเป็นเวกเตอร์ มีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน.

**ฉันสามารถแก้ไของค์ประกอบ SVG ที่ส่งออกหลังจากการส่งออกได้หรือไม่?**

ได้. กำหนด ID ผ่านคอนโทรลเลอร์ฟอร์แมต, แล้วเลือกองค์ประกอบ SVG ที่ตรงกันในเครื่องมือประมวลผลต่อหรือสคริปต์ของเบราว์เซอร์ของคุณ.