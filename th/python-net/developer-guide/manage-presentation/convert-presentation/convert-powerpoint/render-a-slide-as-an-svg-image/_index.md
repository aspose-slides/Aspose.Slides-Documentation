---
title: "เรนเดอร์สไลด์การนำเสนอเป็นภาพ SVG ใน Python"
linktitle: "สไลด์เป็น SVG"
type: docs
weight: 50
url: /th/python-net/render-a-slide-as-an-svg-image/
keywords:
- "PowerPoint เป็น SVG"
- "การนำเสนอเป็น SVG"
- "สไลด์เป็น SVG"
- "PPT เป็น SVG"
- "PPTX เป็น SVG"
- "ตัวเลือกการส่งออก SVG"
- "PowerPoint"
- "การนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "ส่งออกสไลด์ PowerPoint เป็นภาพ SVG ใน Python และควบคุมฟอนต์, ข้อความ, และรูปภาพด้วย Aspose.Slides."
---
## **ภาพรวม**

SVG คือรูปแบบภาพแบบ XML ที่ปรับขนาดได้ ซึ่งทำงานได้ดีสำหรับการเผยแพร่บนเว็บ, ตัวชมสไลด์, กระบวนการทำงานเพื่อการเข้าถึง, และการประมวลผลหลังอัตโนมัติ. Aspose.Slides ส่งออกแต่ละสไลด์เป็นไฟล์ SVG แยกไฟล์และให้คุณควบคุมวิธีการเขียนข้อความ, ฟอนต์, รูปภาพและองค์ประกอบ SVG.

ใช้ [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) เมื่อ SVG ที่ส่งออกต้องมีขนาดกะทัดรัด, คาดเดาได้ในทุกเบราว์เซอร์, หรือพร้อมสำหรับการใช้งานแบบโต้ตอบ.

## **ส่งออกสไลด์เป็น SVG**

สร้าง [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), เลือกสไลด์, และเขียนไปยังสตรีม. ตัวอย่างต่อไปนี้ส่งออกทุกสไลด์ในงานนำเสนอเป็นไฟล์ SVG แยกไฟล์.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

ชื่อไฟล์ใช้ [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) แทนการใช้ดัชนีของลูป. คุณยังสามารถส่งออกรูปร่างเดี่ยวโดยใช้ [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) เมื่อผู้ชมสไลด์หรือหน้าเว็บต้องการเฉพาะรูปร่างนั้น.

## **กำหนดค่าการส่งออก SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) ควบคุมการเรนเดอร์ SVG. สำหรับกรอบข้อความ, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) รวมกรอบข้อความในพื้นที่เรนเดอร์, และ [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) กำหนดว่าการหมุนกรอบจะถูกนำไปใช้หรือไม่. ตั้งค่า [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) เป็น `True` เมื่อข้อความต้องเรนเดอร์โดยไม่มีลิแกเจอร์.

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

เมื่อส่งออกสไลด์เป็น SVG, คุณสามารถควบคุมว่าข้อความจะคงเหลือเป็นข้อความหรือแปลงเป็นกราฟิกเวกเตอร์, และวิธีการรวมหรืออ้างอิงฟอนต์ภายนอก. ตัวเลือกต่อไปนี้ช่วยให้คุณปรับสมดุลระหว่างความสอดคล้องของภาพ, การเลือกข้อความ, และการพึ่งพาฟอนต์ใน SVG ที่ส่งออก.

### **เวกเตอร์ข้อความทั้งหมด**

ตั้งค่า [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) เป็น `True` เพื่อเขียนข้อความทั้งหมดของสไลด์เป็นกราฟิกเวกเตอร์. วิธีนี้ขจัดการพึ่งพาฟอนต์และทำให้ผลลัพธ์ภาพสอดคล้องกันมากขึ้นในทุกเบราว์เซอร์, แต่ข้อความจะไม่สามารถเลือกหรือค้นหาเป็นข้อความ SVG ได้อีกต่อไป.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **เลือกวิธีการจัดการฟอนต์ภายนอก**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) ใช้ค่าของ [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) สำหรับฟอนต์ที่โหลดจากภายนอก. เลือก `ADD_LINKS_TO_FONT_FILES` เพื่ออ้างอิงไฟล์ฟอนต์แยกไฟล์, `EMBED` เพื่อรวมข้อมูลฟอนต์ใน SVG, หรือ `VECTORIZE` เพื่อเรนเดอร์เฉพาะข้อความที่ใช้ฟอนต์ภายนอกเป็นกราฟิก. ตรวจสอบใบอนุญาตฟอนต์ก่อนทำการฝังฟอนต์.

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

## **ลดขนาดภาพที่ฝัง**

ใช้ [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) เพื่อลดความละเอียดของรูปภาพที่ฝัง, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) เพื่อละเว้นพื้นที่ภาพที่ถูกครอบ, และ [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) เพื่อควบคุมคุณภาพการเข้ารหัส JPEG. การตั้งค่าเหล่านี้ลดขนาดไฟล์โดยอาจสูญเสียความละเอียดหรือข้อมูลภาพที่เก็บไว้.

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

## **ควบคุมความละเอียดการแรสเตอร์ของเมตาฟายล์**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) กำหนดขีดจำกัดความละเอียดต่ำสุดสำหรับการเรซอร์เซอร์เมตาฟายล์ระหว่างการส่งออก SVG. ใช้เพื่อปรับสมดุลระหว่างรายละเอียดและขนาดไฟล์เมื่อภาพ EMF หรือ WMF ถูกเรซอร์เซอร์. มันไม่ได้กำหนด DPI สากลสำหรับ SVG หรือบังคับให้วัตถุทุกอย่างบนสไลด์กลายเป็นภาพแรสเตอร์.

ดาวน์โหลด [metafile-rasterization.pptx](metafile-rasterization.pptx), ซึ่งมีภาพ EMF ที่มีเส้นทแยงมุมแน่น. ตัวอย่างต่อไปนี้ส่งออกสไลด์แรกของไฟล์ด้วยความละเอียดการเรซอร์เซอร์สามระดับผ่าน [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). การตั้งค่าอื่น ๆ ของการส่งออกคงเดิมเพื่อให้เปรียบเทียบผลลัพธ์ได้.

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

ในผลลัพธ์, EMF จะกลายเป็น PNG ฝังหนึ่งไฟล์ในแต่ละ SVG. การวัดต่อไปนี้คือสำหรับงานนำเสนอที่ให้มา; ไม่ใช่สูตรทั่วไปสำหรับการแปลง DPI เป็นขนาดพิกเซล.

| DPI การเรซอร์เซอร์เมตาฟายล์ | ขนาด PNG ที่ฝัง | ขนาดไฟล์ SVG (ไบต์) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

การเปรียบเทียบด้านล่างแสดงพื้นที่เดียวกันของภาพแรสเตอร์ที่ฝังด้วยขนาดการแสดงผลที่ขยายเท่าเดิม. เส้นทแยงมุมแสดงการพิกเซลที่มองเห็นได้ที่ 72 DPI และขอบที่เรียบขึ้นที่ความละเอียดสูงกว่า, ขณะเดียวกันไฟล์ SVG จะใหญ่ขึ้น. การเพิ่มค่าดังกล่าวไม่ได้จำเป็นต้องปรับปรุงรายละเอียดทุกอย่างหรือเปลี่ยนภาพที่ส่งออกทุกภาพ.

![รายละเอียดเส้นทแยงมุมที่ขยายที่ 72, 150, และ 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) ควบคุมการลดความละเอียดของภาพและอาจปกปิดผลของการเปลี่ยนความละเอียดการเรซอร์เซอร์เมตาฟายล์. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) ควบคุมคุณภาพการเข้ารหัส JPEG, ไม่ใช่ความละเอียดการเรซอร์เซอร์เมตาฟายล์.

## **คำถามที่พบบ่อย**

**เมื่อใดควรใช้ [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) แทน [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

ใช้ [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) เมื่อข้อความทั้งหมดต้องไม่ขึ้นกับฟอนต์. ใช้ [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) เมื่อต้องการแปลงเป็นกราฟิกเฉพาะข้อความที่ใช้ฟอนต์ภายนอก.

**วิธีที่ดีที่สุดในการทำให้ SVG มีขนาดเล็กลงคืออะไร?**

เริ่มต้นด้วยการบีบอัดรูปภาพที่ฝัง, ลบพื้นที่ภาพที่ถูกครอบ, และเลือกไฟล์ฟอนต์แบบลิงก์เมื่อสภาพแวดล้อมเป้าหมายสามารถให้บริการได้. ทดสอบผลลัพธ์เนื่องจากความละเอียดภาพที่ต่ำกว่า, คุณภาพ JPEG ที่ต่ำกว่า, และข้อความที่เวกเตอร์ล้วน ๆ มีการแลกเปลี่ยนคุณภาพและขนาดที่แตกต่างกัน.