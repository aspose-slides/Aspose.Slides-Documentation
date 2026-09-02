---
title: เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน Python
linktitle: สไลด์เป็น SVG
type: docs
weight: 50
url: /th/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint เป็น SVG
- การนำเสนอเป็น SVG
- สไลด์เป็น SVG
- PPT เป็น SVG
- PPTX เป็น SVG
- ตัวเลือกรายการส่งออก SVG
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน Python และควบคุมฟอนต์, ข้อความ, และภาพด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG คือรูปแบบภาพแบบ XML ที่สามารถปรับขนาดได้ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, โปรแกรมดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides จะส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกต่างหากและให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพ, และองค์ประกอบ SVG

ใช้ [SVGOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, คาดเดาได้ข้ามเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/), เลือกสไลด์, และเขียนลงสตรีม ตัวอย่างต่อไปนี้ส่งออกแต่ละสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกต่างหาก

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

ชื่อไฟล์ใช้ [Slide.slide_number](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/slide_number/) แทนการใช้ดัชนีของลูป คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [Shape.write_as_svg](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/write_as_svg/) เมื่อโปรแกรมดูสไลด์หรือเว็บเพจต้องการเพียงรูปร่างนั้นเท่านั้น

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ SVG สำหรับกรอบข้อความ, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/use_frame_size/) จะรวมกรอบข้อความในพื้นที่การเรนเดอร์, และ [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) กำหนดว่าจะใช้การหมุนกรอบหรือไม่ ตั้งค่า [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) เป็น `True` เมื่อต้องการให้ข้อความแสดงโดยไม่มีลิการเจอร์

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **ควบคุมข้อความและฟอนต์**

### **แปลงข้อความทั้งหมดเป็นเวกเตอร์**

ตั้งค่า [SVGOptions.vectorize_text](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/vectorize_text/) เป็น `True` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์ สิ่งนี้จะกำจัดการขึ้นอยู่กับฟอนต์และทำให้ผลลัพธ์ภาพดูสม่ำเสมอข้ามเบราว์เซอร์มากขึ้น, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้แล้ว

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **เลือกวิธีการจัดการฟอนต์ภายนอก**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก เลือก `ADD_LINKS_TO_FONT_FILES` เพื่ออ้างอิงไฟล์ฟอนต์แยกต่างหาก, `EMBED` เพื่อฝังข้อมูลฟอนต์ใน SVG, หรือ `VECTORIZE` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก ตรวจสอบลิขสิทธิ์ฟอนต์ก่อนฝังฟอนต์

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **ลดขนาดภาพที่ฝังไว้**

ใช้ [SVGOptions.pictures_compression](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/pictures_compression/) เพื่อลดความละเอียดของภาพที่ฝังไว้, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) เพื่อตัดส่วนที่ครอบตัดของแหล่งภาพ, และ [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/jpeg_quality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยอาจสูญเสียความแม่นยำของภาพหรือข้อมูลภาพที่เก็บไว้

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.vectorize_text](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/vectorize_text/) แทน [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions.vectorize_text](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgoptions/vectorize_text/) เมื่อข้อความทั้งหมดต้องไม่พึ่งพาฟอนต์ ใช้ [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้ฟอนต์ภายนอกเท่านั้น

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดภาพที่ฝังไว้, ลบส่วนภาพที่ถูกครอบตัด, และเลือกไฟล์ฟอนต์แบบลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้ ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำกว่า, คุณภาพ JPEG ที่ต่ำกว่า, และข้อความที่แปลงเป็นเวกเตอร์มีการแลกเปลี่ยนระหว่างคุณภาพและขนาดที่ต่างกัน