---
title: แปลงงานนำเสนอ PowerPoint เป็น HTML ด้วย Python
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/python-net/convert-powerpoint-to-html/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น HTML
- งานนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- บันทึก PowerPoint เป็น HTML
- บันทึกงานนำเสนอเป็น HTML
- บันทึกสไลด์เป็น HTML
- บันทึก PPT เป็น HTML
- บันทึก PPTX เป็น HTML
- ส่งออก PPT เป็น HTML
- ส่งออก PPTX เป็น HTML
- Python
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น HTML ด้วย Python ใช้ Aspose.Slides เพื่อส่งออกไฟล์ PPT และ PPTX, สไลด์ที่เลือก, หมายเหตุ, ฟอนต์, รูปภาพ, SVG และสื่อ."
---
## **ภาพรวม**

Aspose.Slides for Python via .NET สามารถบันทึกงานนำเสนอ PowerPoint เป็น HTML โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือการโหลด [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพียงครั้งเดียวและเรียก `save` ด้วย [SaveFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/). ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/) เมื่อคุณต้องการควบคุมการจัดวางที่ส่งออก, ฟอนต์, รูปภาพ, หมายเหตุ, ความคิดเห็น, ผลลัพธ์ SVG หรือทรัพยากรที่เชื่อมโยง.

คู่มือนี้มุ่งเน้นไปที่สถานการณ์การส่งออก HTML ที่เป็นประโยชน์:

- ส่งออกงานนำเสนอทั้งหมดหรือสไลด์ที่เลือก
- สร้าง HTML แบบจัดวางคงที่, แบบตอบสนอง, หรือแบบใช้ SVG
- รวมบันทึกของผู้พูดและความคิดเห็น
- ควบคุมคุณภาพภาพและข้อมูลส่วนที่ตัดของภาพ
- ฝังฟอนต์หรือบันทึกไฟล์ฟอนต์แยกต่างหาก
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ

โดยค่าเริ่มต้น การส่งออก HTML จะสร้างเอกสาร HTML แบบ self-contained ที่ฝังทรัพยากรส่วนใหญ่ไว้ นี่สะดวกสำหรับการแชร์ไฟล์เดียว แต่ก็อาจทำให้ขนาดผลลัพธ์เพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ ควรพิจารณาใช้ทรัพยากรภายนอก, ลด DPI ของภาพ, และฝังฟอนต์เฉพาะที่ไม่มีในสภาพแวดล้อมเป้าหมายอย่างเชื่อถือได้.

## **แปลงงานนำเสนอเป็น HTML**

เพื่อส่งออกงานนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และบันทึกด้วย [SaveFormat](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/saveformat/).

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.html", slides.export.SaveFormat.HTML)
```

ตัวอย่างนี้จะเขียนไฟล์ HTML หนึ่งไฟล์ คำสั่ง `with` จะทำการปล่อยวัตถุ Presentation และปล่อยตัวจัดการไฟล์และทรัพยากรการเรนเดอร์หลังการส่งออก.

## **ใช้ HtmlOptions**

[HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/) เป็นคลาสการตั้งค่าหลักสำหรับการส่งออก HTML การตั้งค่าทั่วไปรวมถึง:

- `slides_layout_options` : เพิ่มหมายเหตุ, ความคิดเห็น, เอกสารแจก, หรือข้อมูลการจัดวางอื่น
- `html_formatter` : เปลี่ยนโครงสร้างเอกสาร HTML หรือมอบหมายการจัดรูปแบบให้กับคอนโทรลเลอร์
- `slide_image_format` : เปลี่ยนวิธีการแสดงสไลด์ เช่นเป็น SVG
- `pictures_compression` : ควบคุม DPI ของภาพและขนาดผลลัพธ์
- `delete_pictures_cropped_areas` : เก็บหรือเอาข้อมูลส่วนที่ตัดของภาพออก
- `svg_responsive_layout` : ทำให้เนื้อหา SVG ที่ส่งออกปรับตัวตามคอนเทนเนอร์
- `show_hidden_slides` : รวมสไลด์ที่ซ่อนไว้เมื่อจำเป็น

ส่วนต่อไปนี้จะแสดงตัวเลือกที่ใช้บ่อยที่สุดแยกออก เพื่อให้คุณสามารถรวมเฉพาะตัวเลือกที่ workflow ของคุณต้องการ.

## **แปลงสไลด์ที่เลือกเป็น HTML**

ฟังก์ชัน `save` ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์จาก 1 เริ่มต้น ลูปด้านล่างจะบันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide_count = len(presentation.slides)

    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = [slide_number]
        html_file_name = "slide-{}.html".format(slide_number)

        presentation.save(html_file_name, slide_numbers, slides.export.SaveFormat.HTML)
```

ใช้รูปแบบนี้เมื่อเว็บไซต์หรือแอปพลิเคชันต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากสไลด์แต่ละอันควรมีรูปแบบเดียวกัน ให้สร้างอินสแตนซ์ของ [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/) หนึ่งตัวและส่งให้กับการเรียก `save` ทุกครั้ง.

## **สร้าง HTML แบบตอบสนอง**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML ที่ตอบสนองผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmlformatter/). ใช้เมื่อหน้าที่ส่งออกควรปรับตัวให้เข้ากับความกว้างของเบราว์เซอร์ได้ดียิ่งขึ้น.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    controller = slides.export.ResponsiveHtmlController()
    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

สำหรับการจัดวางแบบตอบสนองที่ใช้ SVG ให้ตั้งค่า `svg_responsive_layout` บน [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/). นี้มีประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็น markup SVG ที่ปรับขนาดได้.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.svg_responsive_layout = True

    presentation.save("presentation-svg-responsive.html", slides.export.SaveFormat.HTML, html_options)
```

## **รวมบันทึกของผู้พูดและความคิดเห็น**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) ผ่าน `html_options.slides_layout_options` เพื่อรวมบันทึกของผู้พูดหรือความคิดเห็น หมายเหตุและความคิดเห็นจะถูกซ่อนโดยค่าเริ่มต้นจนกว่าคุณจะเลือกตำแหน่งของพวกมัน.

สมมติว่าไฟล์งานนำเสนอที่ต้นทางมีบันทึกของผู้พูด:

![สไลด์ที่มีบันทึกของผู้พูดใน PowerPoint](slide_with_notes.png)

โค้ดต่อไปนี้จะส่งออกเนื้อหาสไลด์พร้อมบันทึกของผู้พูดอยู่ด้านล่างสไลด์.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    layout_options = slides.export.NotesCommentsLayoutingOptions()
    layout_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL

    html_options = slides.export.HtmlOptions()
    html_options.slides_layout_options = layout_options

    presentation.save("presentation-with-notes.html", slides.export.SaveFormat.HTML, html_options)
```

![ผลลัพธ์ HTML ที่แสดงสไลด์และบันทึกของผู้พูด](HTML_with_notes.png)

เพื่อส่งออกความคิดเห็น ให้ตั้งค่า `comments_position` เช่น `CommentsPositions.RIGHT` หรือ `CommentsPositions.BOTTOM` หากคุณต้องการแค่ความคิดเห็นให้ละ `notes_position` หากต้องการทั้งหมายเหตุและความเห็นให้ตั้งค่าทั้งสองคุณสมบัติ.

## **ควบคุมคุณภาพภาพและพื้นที่ที่ถูกตัด**

การส่งออก HTML สามารถบีบอัดภาพสไลด์เพื่อลดขนาดผลลัพธ์ได้ ตั้งค่า `pictures_compression` เป็นค่าจาก [PicturesCompression](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/picturescompression/) เมื่อคุณต้องการคุณภาพภาพที่สูงขึ้น.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.pictures_compression = slides.export.PicturesCompression.DPI150

    presentation.save("presentation-dpi-150.html", slides.export.SaveFormat.HTML, html_options)
```

โดยค่าเริ่มต้น พื้นที่ที่ถูกตัดของภาพอาจถูกลบออกจากผลลัพธ์ที่ส่งออก ให้เก็บข้อมูลส่วนที่ถูกตัดเฉพาะเมื่อผู้ใช้จำเป็นต้องกู้คืนหรือตรวจสอบส่วนภาพที่ซ่อนอยู่ การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    html_options = slides.export.HtmlOptions()
    html_options.delete_pictures_cropped_areas = False

    presentation.save("presentation-with-cropped-areas.html", slides.export.SaveFormat.HTML, html_options)
```

## **เพิ่ม CSS**

สำหรับการจัดรูปแบบอย่างง่าย ให้ส่งสตริง CSS ไปยัง [HtmlFormatter](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmlformatter/). สิ่งนี้จะเปลี่ยนแปลงเอกสาร HTML รอบๆ ขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = slides.export.HtmlFormatter.create_document_formatter(css_rules, True)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-styled.html", slides.export.SaveFormat.HTML, html_options)
```

สำหรับส่วนหัวเอกสารที่กำหนดเอง, ไฟล์ CSS ที่เชื่อมโยง, หรือ markup ที่กำหนดเองรอบสไลด์และรูปร่าง ใช้คอนโทรลเลอร์การจัดรูปแบบที่กำหนดเองและส่งให้กับ [HtmlFormatter](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmlformatter/) ด้วย `create_custom_formatter`.

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของงานนำเสนอที่ติดตั้งไว้ ให้ฝังฟอนต์ใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/embedallfontshtmlcontroller/). การฝังช่วยปรับปรุงความสมบูรณ์ของภาพ แต่ก็ทำให้ขนาดผลลัพธ์เพิ่มขึ้น.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    font_names_to_exclude = ["Arial"]
    font_controller = slides.export.EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = slides.export.HtmlFormatter.create_custom_formatter(font_controller)

    html_options = slides.export.HtmlOptions()
    html_options.html_formatter = formatter

    presentation.save("presentation-embedded-fonts.html", slides.export.SaveFormat.HTML, html_options)
```

ให้ยกเว้นฟอนต์เฉพาะเมื่อคุณมั่นใจว่าเบราว์เซอร์หรือระบบเป้าหมายมีฟอนต์นั้นอยู่แล้ว สำหรับฟอนต์ของแบรนด์หรือฟอนต์ที่ไม่ทั่วไป การฝังมักจะปลอดภัยกว่า.

## **ลิงก์ไฟล์ฟอนต์แทนการฝัง**

เพื่อ ลดขนาดไฟล์ HTML คุณสามารถเขียนข้อมูลฟอนต์ลงในไฟล์ WOFF แยกต่างหากและเพิ่มกฎ `@font-face` ไปยัง HTML สิ่งนี้ต้องใช้คอนโทรลเลอร์ที่ปรับแต่งวิธีการเขียนข้อมูลฟอนต์ในระหว่างการส่งออก ใน Python ผ่าน .NET ให้ดำเนินการสร้างคอนโทรลเลอร์นั้นในแอสเซมบลี .NET เล็ก ๆ โหลดใน Python แล้วส่งออบเจกต์ช่วยเหลือไปยัง [HtmlFormatter](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmlformatter/) ด้วย `create_custom_formatter`.

เมื่อคุณแยกฟอนต์ออกเป็นภายนอก ให้เลือกสองเส้นทางอย่างตั้งใจ:

- ไดเรกทอรีผลลัพธ์ของระบบไฟล์ที่ไฟล์ WOFF ที่สร้างจะถูกเขียน
- เส้นทาง URL ที่จะปรากฏในเอกสาร HTML และที่เบราว์เซอร์จะใช้ในการโหลดไฟล์ฟอนต์เหล่านั้น

เก็บไฟล์ HTML และไฟล์ฟอนต์ที่สร้างไว้ด้วยกันจนกว่าจะกำหนดเส้นทางการปรับใช้อย่างสุดท้าย หากไฟล์ถูกปรับใช้ไปยังตำแหน่งอื่น ให้ทำให้คำนำหน้า URL ตรงกับเส้นทาง URL ที่ปรับใช้.

## **บันทึกทรัพยากรเป็นภายนอก**

HTML แบบ self-contained ง่ายต่อการย้าย แต่ทรัพยากร Base64 ที่ฝังไว้สามารถทำให้ไฟล์ใหญ่ได้ หากแอปพลิเคชันของคุณต้องการไฟล์รูปภาพ, ฟอนต์, เสียง, หรือวิดีโอภายนอก ใช้คอนโทรลเลอร์การลิงก์/ฝังแบบกำหนดเองและส่งให้กับคอนสตรัคเตอร์ของ [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/).

เมื่อคุณแยกทรัพยากรออกเป็นภายนอก ให้เลือกสองเส้นทางอย่างตั้งใจ:

- เส้นทางผลลัพธ์ของระบบไฟล์ ที่แอปพลิเคชันของคุณเขียนรูปภาพ, ฟอนต์, เสียง หรือวิดีโอที่สร้างขึ้น
- เส้นทาง URL ที่เป็นสิ่งที่เบราว์เซอร์ใช้จากเอกสาร HTML เพื่อโหลดไฟล์เหล่านั้น

สำหรับการสนทนาการลิงก์รูปภาพอย่างครบถ้วน ดู [ส่งออกงานนำเสนอเป็น HTML พร้อมรูปภาพที่เชื่อมโยงภายนอก](/slides/th/python-net/exporting-presentations-to-html-with-externally-linked-images/).

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/videoplayerhtmlcontroller/) ส่งออกไฟล์วิดีโอและออดิโอและเขียน HTML ที่สามารถเล่นไฟล์เหล่านั้นในเบราว์เซอร์ ตัวคอนสตรัคเตอร์ของมันรับ:

- `path` : ไดเรกทอรีที่ไฟล์สื่อที่สร้างจะถูกเขียน
- `file_name` : ชื่อไฟล์ HTML ที่กำลังสร้าง
- `base_uri` : คำนำหน้า URI แบบเต็มที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ

ถ้าไฟล์ HTML คือ `html-output/presentation.html` และไฟล์สื่อถูกบันทึกใน `html-output/media` `path` ควรชี้ไปยังไดเรกทอรีสื่อบนดิสก์ ในขณะที่ `base_uri` ควรชี้ไปยังไดเรกทอรีเดียวกันจากมุมมองของเบราว์เซอร์ สำหรับการพรีวิวแบบโลคัล คุณสามารถสร้าง URI `file:///` จากไดเรกทอรีสื่อได้ สำหรับแอปพลิเคชันที่ปรับใช้แล้ว ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่

```python
import os
from pathlib import Path

import aspose.slides as slides

output_directory = os.path.join(os.getcwd(), "html-output")
media_directory = os.path.join(output_directory, "media")
os.makedirs(output_directory, exist_ok=True)
os.makedirs(media_directory, exist_ok=True)

html_file_name = "presentation.html"
media_base_uri = Path(media_directory).as_uri() + "/"

with slides.Presentation() as presentation:
    with open("intro.mp4", "rb") as video_stream:
        video = presentation.videos.add_video(
            video_stream,
            slides.LoadingStreamBehavior.READ_STREAM_AND_RELEASE)

    slide = presentation.slides[0]
    slide.shapes.add_video_frame(20, 20, 480, 270, video)

    controller = slides.export.VideoPlayerHtmlController(
        media_directory,
        html_file_name,
        media_base_uri)

    formatter = slides.export.HtmlFormatter.create_custom_formatter(controller)
    svg_options = slides.export.SVGOptions(controller)
    slide_image_format = slides.export.SlideImageFormat.svg(svg_options)

    html_options = slides.export.HtmlOptions(controller)
    html_options.html_formatter = formatter
    html_options.slide_image_format = slide_image_format

    html_file_path = os.path.join(output_directory, html_file_name)
    presentation.save(html_file_path, slides.export.SaveFormat.HTML, html_options)
```

ใช้ไดเรกทอรีผลลัพธ์ที่เป็นเอกลักษณ์สำหรับแต่ละงานส่งออก โดยเฉพาะในแอปพลิเคชันเซิร์ฟเวอร์ การใช้เส้นทางผลลัพธ์ที่แชร์กันอาจทำให้ไฟล์จากการแปลงต่าง ๆ เขียนทับกันได้.

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลงเป็น HTML เป็นการดำเนินการเรนเดอร์ ดังนั้นเวลาในการประมวลผลและการใช้หน่วยความจำจะขึ้นอยู่กับจำนวนสไลด์, ความละเอียดของภาพ, ฟอนต์, เอฟเฟกต์, แผนภูมิ, และสื่อที่ฝังอยู่ ค่า DPI ของ `pictures_compression` ที่สูงกว่า, การฝังฟอนต์, ผลลัพธ์ SVG, และการเก็บส่วนที่ถูกตัดของภาพสามารถปรับปรุงความสมบูรณ์ของภาพได้ แต่ส่วนใหญ่จะเพิ่มขนาดผลลัพธ์

สำหรับการแปลงเป็นชุด:

- ปล่อยอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ทุกตัวโดยเร็ว
- ใช้ไดเรกทอรีผลลัพธ์แยกสำหรับแต่ละงาน
- หลีกเลี่ยงการฝังฟอนต์ทั่วไป เว้นแต่จำเป็นต้องการความสมบูรณ์
- ลด DPI ของภาพเมื่อ HTML ใช้สำหรับพรีวิวหรือรูปย่อ
- เก็บงานนำเสนอต้นฉบับ, HTML ที่สร้าง, และทรัพยากรภายนอกไว้ด้วยกันจนกว่าจะกำหนดเส้นทางการปรับใช้สุดท้าย

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์ลิงก์ถูกเก็บไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่. ลิงก์ไฮเปอร์ลิงก์ในงานนำเสนอจะถูกส่งออกเป็น HTML และยังคงคลิกได้เมื่อ URL ปลายทางใช้ได้.

**ฉันสามารถแปลงงานนำเสนอเป็น HTML แบบขนานได้หรือไม่?**

ใช่, แต่ห้ามใช้อินสแตนซ์ของ [Presentation] ตัวเดียวกันข้ามเธรด ควรประมวลผลไฟล์ต่าง ๆ ด้วยอินสแตนซ์ของงานนำเสนอแยกกัน, สตรีมแยก, และไดเรกทอรีผลลัพธ์แยก ดู [คำแนะนำการทำงานหลายเธรด](/slides/th/python-net/multithreading/) สำหรับรายละเอียด.

**ออบเจกต์ Presentation ปลอดภัยต่อการทำงานหลายเธรดหรือไม่?**

ไม่. อินสแตนซ์ของ [Presentation] ควรโหลด, แก้ไข, บันทึก, และปล่อยบนเธรดเดียว สำหรับการทำงานขนาน ควรสร้างอินสแตนซ์แยกสำหรับแต่ละเธรดหรือกระบวนการ.

**ทำไมไฟล์ HTML ที่สร้างจึงมีขนาดใหญ่?**

การส่งออกค่าเริ่มต้นอาจฝังทรัพยากรโดยตรงใน HTML ฟอนต์ที่ฝังไว้, ภาพ DPI สูง, สื่อ, เนื้อหา SVG, และการเก็บส่วนที่ถูกตัดของภาพต่าง ๆ ล้วนทำให้ขนาดเพิ่มขึ้น ใช้ทรัพยากรภายนอก, ยกเว้นฟอนต์ทั่วไปจากการฝัง, และลดค่า `pictures_compression` เมื่อขนาดไฟล์ที่เล็กสำคัญกว่าความสมบูรณ์สูงสุด.

**ทำไมขนาดฟอนต์ใน PowerPoint เช่น 24 pt ถึงแสดงเป็น 17.999819 pt ใน HTML?**

เหตุการณ์นี้อาจเกิดขึ้นเนื่องจาก PowerPoint และ HTML ใช้โมเดล DPI ที่แตกต่างกัน PowerPoint เก็บขนาดข้อความเป็นจุดตัวพิมพ์อิง 72 DPI ในขณะที่การจัดวาง HTML อิงพิกเซล CSS ในโมเดล 96 DPI เมื่อ Aspose.Slides ส่งออกงานนำเสนอเป็น HTML ขนาดฟอนต์จะถูกแปลงระหว่างระบบเหล่านี้และการแปลงอาจทำให้เกิดความแตกต่างของการปัดเศษเล็กน้อย

ค่าดังกล่าวไม่ได้บ่งบอกถึงการเปลี่ยนแปลงขนาดฟอนต์ที่มองเห็นจริง เพียงเป็นผลทางคณิตศาสตร์จากการแปลงเมตริกของข้อความระหว่าง PowerPoint และ HTML.

**ฉันควรเลือก base_uri สำหรับการส่งออกสื่ออย่างไร?**

ให้เลือก `base_uri` จากมุมมองของเบราว์เซอร์และส่งเป็น URI แบบเต็ม สำหรับการพรีวิวแบบโลคัล คุณสามารถสร้างจากไดเรกทอรีผลลัพธ์ด้วย `Path(media_directory).as_uri() + "/"`. สำหรับการปรับใช้ ให้ใช้ URL แบบเต็มของไดเรกทอรีสื่อที่เผยแพร่ เส้นทางไฟล์ `path` และ `base_uri` ของเบราว์เซอร์ไม่จำเป็นต้องเป็นสตริงเดียวกัน แต่ต้องอธิบายตำแหน่งของทรัพยากรเดียวกัน.

**ฉันสามารถรวมสไลด์ที่ซ่อนไว้ได้หรือไม่?**

ได้. ตั้งค่า `show_hidden_slides = True` บน [HtmlOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/htmloptions/) เมื่อจำเป็นต้องส่งออกสไลด์ที่ซ่อนไว้.