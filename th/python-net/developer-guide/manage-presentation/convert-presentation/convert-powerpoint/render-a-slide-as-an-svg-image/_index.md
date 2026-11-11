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
- ตัวเลือกการส่งออก SVG
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน Python และควบคุมฟอนต์, ข้อความและรูปภาพด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG คือรูปแบบภาพที่ใช้ XML แบบขยายได้ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวดูสไลด์, กระบวนการทำให้เข้าถึงได้, และการประมวลผลอัตโนมัติหลังการสร้าง. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพ, และองค์ประกอบ SVG.

ใช้ [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, ทำนายได้ในหลายเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), เลือกสไลด์, แล้วเขียนลงสตรีม. ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

ชื่อไฟล์ใช้ [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) แทนดัชนีของลูป. คุณยังสามารถส่งออกรูปร่างเดี่ยวด้วย [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) เมื่อโปรแกรมดูสไลด์หรือหน้าเว็บต้องการเพียงรูปร่างนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) จะรวมกรอบข้อความในบริเวณการเรนเดอร์, และ [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) กำหนดว่าการหมุนกรอบจะถูกนำไปใช้หรือไม่. ตั้งค่า [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) เป็น `True` เมื่อข้อความต้องเรนเดอร์โดยไม่มีลิการเจอร์.

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

## **ควบคุมการตัดส่วนท้ายของเส้นที่หัวลูกศร**

SVG 1.1 ไม่มีการตั้งค่า marker inset เพื่อระบุตำแหน่งที่เส้นควรหยุดใต้หัวลูกศร. โดยค่าเริ่มต้น, Aspose.Slides จะทำให้เส้นที่ส่งออกสั้นลงเพื่อให้เส้นขอบไม่ยื่นผ่าน marker. ตั้งค่า [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) เป็น `True` เพื่อวาดเส้นขอบจนถึงจุดสิ้นสุดเดิมของเส้น. การตั้งค่านี้มีผลต่อการส่งออกเป็น SVG เท่านั้น. เส้นยังคงตำแหน่งและความยาวบนสไลด์.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

การเปรียบเทียบแสดงหัวลูกศรรูปสามเหลี่ยมบนเส้นความหนา 10 จุด. เมื่อเปิดการตัดส่วนท้าย, ปลายจะคม. เมื่อปิดการตัดส่วนท้าย, เส้นขอบจะยื่นผ่านด้านเอียงของ marker และทิ้งปลายแบน.

![สามเหลี่ยม 10 จุดขยายใหญ่พร้อมปลายคมเมื่อเปิดการตัดส่วนท้ายและปลายแบนเมื่อปิดการตัดส่วนท้าย](line-end-cropping.png)

ในเส้นอื่นจากตัวอย่าง, เส้นขอบที่ยื่นจะมองเห็นได้น้อยบนสามเหลี่ยม 2 จุด. รูปเพชรที่เต็มจะครอบส่วนท้ายของเส้นขอบในความกว้างทั้งสอง.

## **ควบคุมข้อความและฟอนต์**

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมว่าข้อความจะคงเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงฟอนต์ภายนอก. ตัวเลือกต่อไปนี้ช่วยให้คุณปรับสมดุลระหว่างความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาฟอนต์ใน SVG ที่ส่งออก.

### **แปลงข้อความทั้งหมดเป็นเวกเตอร์**

ตั้งค่า [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) เป็น `True` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์. นี้จะขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในหลายเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้อีกต่อไป.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **เลือกวิธีจัดการฟอนต์ภายนอก**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) ใช้ค่า [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก. เลือก `ADD_LINKS_TO_FONT_FILES` เพื่ออ้างอิงไฟล์ฟอนต์แยก, `EMBED` เพื่อรวมข้อมูลฟอนต์ใน SVG, หรือ `VECTORIZE` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก. ตรวจสอบสิทธิ์การใช้ฟอนต์ก่อนทำการฝังฟอนต์.

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

## **ลดขนาดรูปภาพที่ฝังไว้**

ใช้ [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) เพื่อตัดส่วนที่ถูกตัดของแหล่งภาพ, และ [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) เพื่อตั้งค่าคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้จะลดขนาดไฟล์โดยเสียคุณภาพหรือข้อมูลรูปภาพที่คงอยู่.

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

## **ควบคุมความละเอียดการเรซาร์เซอร์เมตาฟไฟล์**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการเรซาร์เซอร์เมตาฟไฟล์ระหว่างการส่งออก SVG. ใช้เพื่อปรับสมดุลระหว่างรายละเอียดและขนาดไฟล์เมื่อมีภาพ EMF หรือ WMF ถูกเรซาร์เซอร์. มันไม่ได้กำหนด DPI ทั้งหมดสำหรับ SVG หรือบังคับให้ทุกวัตถุบนสไลด์กลายเป็นภาพเรซเซอร์.

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx), ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมห่างกันใกล้เคียง. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์ที่สามความละเอียดการเรซาร์เซอร์ผ่าน [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). การตั้งค่าอื่น ๆ ของการส่งออกยังคงเหมือนเดิมเพื่อให้เปรียบเทียบผลลัพธ์ได้.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

ในผลลัพธ์, EMF จะกลายเป็น PNG ฝังหนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้เป็นสำหรับงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นขนาดพิกเซล.

| ความละเอียดการเรซาร์เซอร์เมตาฟไฟล์ DPI | ขนาด PNG ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพเรซเซอร์ที่ฝังในขนาดการแสดงผลที่ขยายเท่าเดิม. เส้นทแยงมุมแสดงการพิเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบลงที่ความละเอียดสูงขึ้น, ในขณะที่ไฟล์ SVG เติบโต. การเพิ่มค่านี้ไม่ได้จำเป็นต้องปรับปรุงรายละเอียดทุกส่วนหรือเปลี่ยนภาพที่ส่งออกทั้งหมด.

![รายละเอียดเส้นทแยงมุมขยายใหญ่ที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) ควบคุมการลดความละเอียดของภาพและอาจปกปิดผลของการเปลี่ยนความละเอียดการเรซาร์เซอร์เมตาฟไฟล์. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการเรซาร์เซอร์เมตาฟไฟล์.

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) แทน [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) เมื่อข้อความทั้งหมดต้องเป็นอิสระจากฟอนต์. ใช้ [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) เมื่อเฉพาะข้อความที่ใช้ฟอนต์ภายนอกควรแปลงเป็นกราฟิก.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝังไว้, ลบพื้นที่รูปภาพที่ถูกตัด, และเลือกไฟล์ฟอนต์แบบลิงก์เมื่อสภาพแวดล้อมปลายทางสามารถให้บริการได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำลง, คุณภาพ JPEG ที่ต่ำลง, และข้อความที่แปลงเป็นเวกเตอร์มีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน.