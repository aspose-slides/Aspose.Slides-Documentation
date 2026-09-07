---
title: แปลงงานนำเสนอ PowerPoint เป็น HTML ด้วย Python ผ่าน Java
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/python-java/convert-powerpoint-to-html/
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
- ส่งออก PPT ไปเป็น HTML
- ส่งออก PPTX ไปเป็น HTML
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint เป็น HTML ด้วย Python ผ่าน Java. ใช้ Aspose.Slides เพื่อส่งออกไฟล์ PPT และ PPTX, สไลด์ที่เลือก, โน้ต, ฟอนต์, รูปภาพ, SVG และสื่อ."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถบันทึกงานนำเสนอ PowerPoint เป็น HTML ได้โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือการโหลด [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพียงครั้งเดียวและทำการ [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ด้วย [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/). ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/) เมื่อคุณต้องการควบคุมการจัดรูปแบบที่ส่งออก, ฟอนต์, ภาพ, โน้ต, ความคิดเห็น, การส่งออก SVG, หรือทรัพยากรที่เชื่อมโยง

คู่มือนี้มุ่งเน้นที่สถานการณ์การส่งออก HTML อย่างเป็นรูปธรรม:

- ส่งออกงานนำเสนอทั้งหมดหรือสไลด์ที่เลือก
- สร้าง HTML แบบ fixed‑layout, responsive หรือแบบใช้ SVG
- รวมโน้ตผู้บรรยายและความคิดเห็น
- ควบคุมคุณภาพภาพและข้อมูลส่วนที่ถูกครอบของภาพ
- ฝังฟอนต์หรือบันทึกไฟล์ฟอนต์แยกต่างหาก
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ

โดยค่าเริ่มต้น การส่งออก HTML จะสร้างเอกสาร HTML ที่เป็นอันหนึ่งอันเดียวซึ่งส่วนใหญ่ของทรัพยากรถูกฝังอยู่ นั่นสะดวกสำหรับการแชร์ไฟล์เดียว แต่จะทำให้ขนาดผลลัพธ์เพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ ควรพิจารณาใช้ทรัพยากรภายนอก, ลด DPI ของภาพ, และฝังฟอนต์เฉพาะที่ไม่มีในสภาพแวดล้อมเป้าหมายเท่านั้น

## **แปลงงานนำเสนอเป็น HTML**

เพื่อส่งออกงานนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และบันทึกด้วย [SaveFormat.Html](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Html)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.html", SaveFormat.Html)
finally:
    presentation.dispose()
```

แต่ละตัวอย่างโหลด `presentation.pptx` จากไดเร็กทอรีทำงานปัจจุบัน ติดตั้ง Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ก่อนรัน โครงสร้าง JVM จะเริ่มต้นเพียงครั้งเดียวต่อกระบวนการ Python

ตัวอย่างนี้เขียนไฟล์ HTML หนึ่งไฟล์ วัตถุ Presentation จะถูกทำลายในบล็อก `finally` ซึ่งจะปล่อยตัวจัดการไฟล์และทรัพยากรการเรนเดอร์หลังการส่งออก

## **กำหนดค่าการส่งออก HTML**

[HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/) คือคลาสการกำหนดค่าหลักสำหรับการส่งออก HTML การตั้งค่าทั่วไปรวมถึง:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): เพิ่มโน้ต, ความคิดเห็น, เอกสารแจก หรือข้อมูลการจัดรูปแบบอื่น
- [setHtmlFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setHtmlFormatter): เปลี่ยนโครงสร้างเอกสาร HTML หรือมอบหมายการจัดรูปแบบให้กับคอนโทรลเลอร์
- [setSlideImageFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSlideImageFormat): เปลี่ยนวิธีการแสดงสไลด์ เช่น เป็น SVG
- [setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setPicturesCompression): ควบคุม DPI ของภาพและขนาดผลลัพธ์
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): เก็บหรือเอาข้อมูลภาพที่ถูกครอบออก
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): ทำให้เนื้อหา SVG ที่ส่งออกตอบสนองต่อคอนเทนเนอร์ของมัน
- [setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): รวมสไลด์ที่ซ่อนเมื่อต้องการ

ส่วนต่อไปนี้แสดงตัวเลือกที่พบบ่อยที่สุดแยกกันเพื่อให้คุณสามารถผสานเฉพาะที่ต้องการในกระแสงานของคุณ

## **แปลงสไลด์ที่เลือกเป็น HTML**

เมธอด overload ของ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์ตั้งแต่ 1 ตัวอย่างต่อไปนี้บันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide_number = slide_index + 1
        slide_numbers = jpype.JArray(jpype.JInt)([slide_number])
        html_file_name = f"slide-{slide_number}.html"
        presentation.save(html_file_name, slide_numbers, SaveFormat.Html)
finally:
    presentation.dispose()
```

ใช้รูปแบบนี้เมื่อเว็บไซต์หรือแอปพลิเคชันต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากสไลด์ทั้งหมดต้องการรูปแบบเดียวกัน ให้สร้างอ็อบเจ็กต์ [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/) เพียงหนึ่งตัวและส่งต่อให้กับการเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ทุกครั้ง

## **สร้าง HTML แบบ Responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/python-java/aspose.slides/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML แบบ responsive ผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/) ใช้เมื่อหน้าที่ส่งออกควรปรับตัวให้เข้ากับความกว้างของเบราว์เซอร์ได้ดีขึ้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, ResponsiveHtmlController, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    controller = ResponsiveHtmlController()
    formatter = HtmlFormatter.createCustomFormatter(controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

สำหรับการจัดรูปแบบ responsive แบบใช้ SVG ให้เรียก [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) ด้วยค่า `True` สิ่งนี้เป็นประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็น markup SVG ที่ปรับขนาดได้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setSvgResponsiveLayout(True)

    presentation.save("presentation-svg-responsive.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **รวมโน้ตผู้บรรยายและความคิดเห็น**

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) ผ่าน [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) เพื่อรวมโน้ตผู้บรรยายหรือความคิดเห็น โน้ตและความคิดเห็นจะถูกซ่อนโดยค่าเริ่มต้น เว้นแต่ว่าคุณจะกำหนดตำแหน่งของมัน

สมมติว่าตัวงานนำเสนอมีโน้ตผู้บรรยาย:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

โค้ดต่อไปนี้ส่งออกเนื้อหาสไลด์พร้อมโน้ตผู้บรรยายอยู่ใต้สไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomFull)

    html_options = HtmlOptions()
    html_options.setSlidesLayoutOptions(layout_options)

    presentation.save("presentation-with-notes.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

HTML ที่ส่งออกจะรวมพื้นที่โน้ต:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

เพื่อส่งออกความคิดเห็น ให้เรียก [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) เช่นกับ [CommentsPositions.Right](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentspositions/#Right) หรือ [CommentsPositions.Bottom](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentspositions/#Bottom) หากต้องการเฉพาะความคิดเห็นเท่านั้น ให้ละเว้นการเรียก [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) หากต้องการทั้งโน้ตและความคิดเห็นให้เรียกทั้งสองเมธอด

## **ควบคุมคุณภาพภาพและพื้นที่ที่ถูกครอบ**

การส่งออก HTML สามารถบีบอัดภาพสไลด์เพื่อลดขนาดผลลัพธ์ ให้ค่าที่ต้องการกับ [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setPicturesCompression) จาก [PicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturescompression/) เมื่อคุณต้องการคุณภาพภาพที่สูงขึ้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, PicturesCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setPicturesCompression(PicturesCompression.Dpi150)

    presentation.save("presentation-dpi-150.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

โดยค่าเริ่มต้น พื้นที่ที่ถูกครอบของภาพอาจถูกลบออกจากผลลัพธ์ที่ส่งออก ให้เก็บข้อมูลที่ถูกครอบไว้เฉพาะเมื่อผู้ใช้ต้องการกู้คืนหรือตรวจสอบส่วนที่ถูกซ่อนของภาพ การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    html_options = HtmlOptions()
    html_options.setDeletePicturesCroppedAreas(False)

    presentation.save("presentation-with-cropped-areas.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

## **เพิ่ม CSS**

สำหรับการสไตล์อย่างง่าย ให้ส่งสตริง CSS ไปยัง [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) วิธีนี้จะเปลี่ยนเอกสาร HTML รอบข้างขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์ต่อไป

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    css_rules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }"
    formatter = HtmlFormatter.createDocumentFormatter(css_rules, True)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-styled.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

สำหรับส่วนหัวเอกสารแบบกำหนดเอง, ไฟล์ CSS ที่ลิงก์, หรือ markup แบบกำหนดเองรอบสไลด์และรูปร่าง ให้ใช้คอนโทรลเลอร์การจัดรูปแบบที่กำหนดเองผ่านพร็อกซีอินเทอร์เฟซ JPype แล้วส่งต่อให้กับ [HtmlFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/) ด้วย [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/#createCustomFormatter)

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของงานนำเสนอที่ติดตั้งไว้ ให้ฝังฟอนต์ใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/python-java/aspose.slides/embedallfontshtmlcontroller/) การฝังฟอนต์ช่วยให้ความคมชัดของการแสดงผลดีขึ้น แต่ขนาดไฟล์จะเพิ่มขึ้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedAllFontsHtmlController, HtmlFormatter, HtmlOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    font_names_to_exclude = jpype.JArray(jpype.JString)(["Arial"])
    font_controller = EmbedAllFontsHtmlController(font_names_to_exclude)
    formatter = HtmlFormatter.createCustomFormatter(font_controller)

    html_options = HtmlOptions()
    html_options.setHtmlFormatter(formatter)

    presentation.save("presentation-embedded-fonts.html", SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

อย่าเอาฟอนต์ออกเว้นแต่คุณมั่นใจว่าเบราว์เซอร์หรือระบบเป้าหมายมีฟอนต์เหล่านั้นแล้ว สำหรับฟอนต์ของแบรนด์หรือฟอนต์ที่หาได้ยาก การฝังฟอนต์มักจะปลอดภัยกว่า

## **บันทึกทรัพยากรเป็นไฟล์ภายนอก**

HTML ที่เป็นอันหนึ่งอันเดียวสะดวกต่อการเคลื่อนย้าย แต่ทรัพยากร Base64 ที่ฝังอยู่ทำให้ไฟล์ใหญ่ หากแอปของคุณต้องการไฟล์รูปภาพภายนอก ให้สร้างคอนโทรลเลอร์การลิงก์ทรัพยากรผ่านพร็อกซีอินเทอร์เฟซ JPype แล้วส่งต่อให้กับคอนสตรัคเตอร์ของ [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/)

เมื่อคุณแยกทรัพยากรออก ให้เลือกสองเส้นทางอย่างระมัดระวัง:

- เส้นทางของระบบไฟล์ที่แอปของคุณเขียนไฟล์รูปภาพ, ฟอนต์, เสียง หรือวิดีโอที่สร้างขึ้น
- เส้นทาง URL ที่เบราว์เซอร์ใช้จากเอกสาร HTML เพื่อโหลดไฟล์เหล่านั้น

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoplayerhtmlcontroller/) ส่งออกไฟล์วิดีโอและเสียงแล้วเขียน HTML ที่สามารถเล่นสื่อเหล่านั้นในเบราว์เซอร์ ตัวสร้างรับพารามิเตอร์:

- `path`: ไดเร็กทอรีที่ไฟล์สื่อที่สร้างขึ้นจะถูกเขียนลง
- `fileName`: ชื่อไฟล์ HTML ที่กำลังสร้าง
- `baseUri`: คำนำหน้า URI แบบสมบูรณ์ที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ

ตัวอย่างต่อไปนี้ส่งออกสื่อที่ฝังอยู่ใน `presentation.pptx` HTML ที่สร้างจะอ้างอิงไฟล์สื่อด้วยชื่อไฟล์เท่านั้น โดยสัมพันธ์กับเอกสาร HTML ดังนั้น `path` ต้องเป็นไดเร็กทอรีเดียวกับที่รับไฟล์ HTML ด้วย `baseUri` ต้องเป็น URI แบบสมบูรณ์: สำหรับการดูตัวอย่างในเครื่อง ให้สร้าง URI `file:///` จากไดเร็กทอรีผลลัพธ์; สำหรับแอปที่เผยแพร่ ให้ใช้ URL สมบูรณ์ของไดเร็กทอรีที่เผยแพร่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, Presentation, SVGOptions, SaveFormat, SlideImageFormat, VideoPlayerHtmlController

from pathlib import Path

output_directory = Path("html-output").resolve()
output_directory.mkdir(parents=True, exist_ok=True)
html_file_name = "presentation.html"
media_base_uri = output_directory.as_uri() + "/"

presentation = Presentation("presentation.pptx")
try:
    controller = VideoPlayerHtmlController(str(output_directory), html_file_name, media_base_uri)
    formatter = HtmlFormatter.createCustomFormatter(controller)
    svg_options = SVGOptions(controller)
    slide_image_format = SlideImageFormat.svg(svg_options)

    html_options = HtmlOptions(controller)
    html_options.setHtmlFormatter(formatter)
    html_options.setSlideImageFormat(slide_image_format)

    html_file_path = output_directory / html_file_name
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

ใช้ไดเร็กทอรีผลลัพธ์ที่เป็นเอกลักษณ์ต่อแต่ละงานแปลง โดยเฉพาะในแอปเซิร์ฟเวอร์ หากใช้เส้นทางร่วมกันอาจทำให้ไฟล์จากการแปลงต่าง ๆ เขียนทับกันได้

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลงเป็น HTML เป็นการดำเนินการเรนเดอร์ ดังนั้นเวลาในการประมวลผลและการใช้หน่วยความจำจะขึ้นอยู่กับจำนวนสไลด์, ความละเอียดภาพ, ฟอนต์, เอฟเฟกต์, แชตและสื่อที่ฝังอยู่ ค่า DPI ของภาพที่สูงขึ้นที่ส่งต่อให้กับ [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setPicturesCompression), ฟอนต์ที่ฝัง, การส่งออก SVG และการเก็บพื้นที่ภาพที่ถูกครอบไว้ สามารถเพิ่มความคมชัดได้แต่โดยทั่วไปจะทำให้ขนาดผลลัพธ์เพิ่มขึ้น

สำหรับการแปลงเป็นชุด:

- ทำลายอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ทุกครั้งโดยเร็ว
- ใช้ไดเร็กทอรีผลลัพธ์แยกสำหรับงานแยกต่างหาก
- อย่าฝังฟอนต์ทั่วไปเว้นแต่ความคมชัดจำเป็นต้องใช้
- ลด DPI ของภาพเมื่อ HTML ใช้เพื่อดูตัวอย่างหรือเป็นรูปย่อ
- เก็บไฟล์งานนำเสนอต้นฉบับ, HTML ที่สร้างและทรัพยากรภายนอกไว้ด้วยกันจนกว่าจะกำหนดเส้นทางการเผยแพร่ขั้นสุดท้าย

## **FAQ**

**ไฮเปอร์ลิงก์จะถูกเก็บไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่ ไฮเปอร์ลิงก์ของงานนำเสนอจะถูกส่งออกเป็น HTML และยังคงคลิกได้เมื่อ URL ปลายทางใช้งานได้

**ฉันสามารถแปลงงานนำเสนอเป็น HTML พร้อมกันหลายกระบวนการได้หรือไม่?**

ใช่ แต่ห้ามแชร์อ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ระหว่างเธรด ประมวลผลไฟล์ต่าง ๆ ด้วยอ็อบเจ็กต์ Presentation แยกกัน, สตรีมแยกกันและไดเร็กทอรีผลลัพธ์แยกกัน ดูคำแนะนำเกี่ยวกับ [multithreading guidance](/slides/th/python-java/multithreading/) เพื่อรายละเอียดเพิ่มเติม

**อ็อบเจ็กต์ Presentation ปลอดภัยต่อการใช้หลายเธรดหรือไม่?**

ไม่ ควรโหลด, แก้ไข, บันทึกและทำลายอ็อบเจ็กต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพียงหนึ่งเธรด หากต้องทำงานแบบขนาน ให้สร้างอินสแตนซ์อิสระต่อเธรดหรือกระบวนการ

**ทำไมไฟล์ HTML ที่สร้างขึ้นจึงมีขนาดใหญ่?**

การส่งออกค่าเริ่มต้นอาจฝังทรัพยากรโดยตรงใน HTML ฟอนต์ที่ฝัง, ภาพ DPI สูง, สื่อ, เนื้อหา SVG และการเก็บพื้นที่ภาพที่ถูกครอบทั้งหมดล้วนเพิ่มขนาดไฟล์ ใช้ทรัพยากรภายนอก, ไม่ฝังฟอนต์ทั่วไปและส่งค่าต่ำลงให้กับ [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setPicturesCompression) เมื่อขนาดผลลัพธ์ที่เล็กลงสำคัญกว่าความคมชัดสูงสุด

**ทำไมค่าขนาดฟอนต์ใน HTML ถึงแตกต่างจากค่าใน PowerPoint?**

หน้าที่ส่งออกอาจใช้ระบบพิกัด SVG และการแปลงสเกล ค่า CSS หรือ SVG font-size เพียงอย่างเดียวไม่อธิบายขนาดที่แสดงจริง เปรียบเทียบสไลด์ที่เรนเดอร์ที่ระดับการซูมที่ต้องการและตรวจสอบความพร้อมของฟอนต์หากข้อความดูแตกต่าง

**ควรเลือก baseUri สำหรับการส่งออกสื่ออย่างไร?**

เลือก `baseUri` จากมุมมองของเบราว์เซอร์และส่งเป็น URI แบบสมบูรณ์ สำหรับการดูตัวอย่างในเครื่อง คุณอาจสร้างจากไดเร็กทอรีผลลัพธ์โดยใช้ `output_directory.as_uri() + "/"` สำหรับการเผยแพร่ให้ใช้ URL สมบูรณ์ของไดเร็กทอรีที่เผยแพร่ `path` ของระบบไฟล์และ `baseUri` ของเบราว์เซอร์ไม่จำเป็นต้องเป็นสตริงเดียวกัน แต่ต้องอธิบายตำแหน่งเดียวกันและตำแหน่งนั้นต้องเป็นไดเร็กทอรีที่มีไฟล์ HTML ที่สร้างไว้ เนื่องจากลิงก์สื่อถูกเขียนเป็นแบบสัมพันธ์กับไฟล์นั้น

**ฉันสามารถรวมสไลด์ที่ซ่อนได้หรือไม่?**

ใช่ เรียก [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) ด้วยค่า `True` เมื่อสไลด์ที่ซ่อนต้องถูกส่งออก