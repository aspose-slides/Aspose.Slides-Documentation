---
title: แปลงการนำเสนอ PowerPoint เป็น HTML ใน Python ผ่าน Java
linktitle: PowerPoint เป็น HTML
type: docs
weight: 30
url: /th/python-java/convert-powerpoint-to-html/
keywords:
- แปลง PowerPoint
- แปลงการนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- PowerPoint เป็น HTML
- การนำเสนอเป็น HTML
- สไลด์เป็น HTML
- PPT เป็น HTML
- PPTX เป็น HTML
- บันทึก PowerPoint เป็น HTML
- บันทึกการนำเสนอเป็น HTML
- บันทึกสไลด์เป็น HTML
- บันทึก PPT เป็น HTML
- บันทึก PPTX เป็น HTML
- ส่งออก PPT เป็น HTML
- ส่งออก PPTX เป็น HTML
- Python
- Java
- Aspose.Slides
description: "แปลงการนำเสนอ PowerPoint เป็น HTML ใน Python ผ่าน Java. ใช้ Aspose.Slides เพื่อส่งออกไฟล์ PPT และ PPTX, สไลด์ที่เลือก, โน้ต, ฟอนต์, รูปภาพ, SVG และสื่อ."
---
## **ภาพรวม**

Aspose.Slides for Python via Java สามารถบันทึกการนำเสนอ PowerPoint เป็น HTML ได้โดยไม่ต้องใช้ Microsoft PowerPoint การแปลงพื้นฐานคือการโหลด [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) เพียงหนึ่งครั้งและเรียก [save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ด้วย [SaveFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/). ใช้ [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/) เมื่อคุณต้องการควบคุมการจัดรูปแบบที่ส่งออก, ฟอนต์, รูปภาพ, โน้ต, ความคิดเห็น, ผลลัพธ์ SVG หรือทรัพยากรที่เชื่อมโยง

คู่มือนี้มุ่งเน้นที่สถานการณ์การส่งออก HTML อย่างเป็นประโยชน์:

- ส่งออกการนำเสนอทั้งหมดหรือสไลด์ที่เลือก
- สร้าง HTML แบบ layout คงที่, responsive, หรือแบบอิง SVG
- รวมโน้ตผู้บรรยายและความคิดเห็น
- ควบคุมคุณภาพภาพและข้อมูลรูปภาพที่ถูกตัด
- ฝังฟอนต์หรือบันทึกไฟล์ฟอนต์แยกต่างหาก
- เลือกวิธีการเขียนและอ้างอิงทรัพยากรภายนอกและไฟล์สื่อ

โดยค่าเริ่มต้น การส่งออกเป็น HTML จะสร้างเอกสาร HTML ที่มีทุกอย่างรวมอยู่เองโดยส่วนใหญ่ของทรัพยากรถูกฝังอยู่ ซึ่งสะดวกสำหรับการแชร์ไฟล์เดียวแต่ขนาดอาจเพิ่มขึ้น สำหรับการเผยแพร่บนเว็บ ให้พิจารณาใช้ทรัพยากรภายนอก, ลด DPI ของภาพ, และฝังฟอนต์เฉพาะที่ไม่มีในสภาพแวดล้อมเป้าหมายอย่างแน่นอน

## **แปลงการนำเสนอเป็น HTML**

เพื่อส่งออกการนำเสนอเป็น HTML ให้โหลดด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และบันทึกด้วย [SaveFormat.Html](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Html).

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

ตัวอย่างแต่ละอันจะโหลด `presentation.pptx` จากไดเรกทอรีทำงานปัจจุบัน ติดตั้ง Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ก่อนเรียกใช้งาน JVM จะเริ่มต้นเพียงครั้งเดียวต่อกระบวนการ Python

ตัวอย่างนี้เขียนไฟล์ HTML หนึ่งไฟล์ วัตถุ presentation จะถูกทำลายในบล็อก `finally` ซึ่งจะปล่อยไฟล์แฮนด์เดิลและทรัพยากรการเรนเดอร์หลังการส่งออก

## **กำหนดค่าการส่งออก HTML**

[HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/) คือคลาสการกำหนดค่าหลักสำหรับการส่งออก HTML การตั้งค่าที่พบบ่อยรวมถึง:

- [setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions): เพิ่มโน้ต, ความคิดเห็น, เอกสารแจกจ่าย หรือข้อมูลการจัดรูปแบบอื่น
- [setHtmlFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setHtmlFormatter): เปลี่ยนโครงสร้างเอกสาร HTML หรือมอบหมายการจัดรูปแบบให้กับคอนโทรลเลอร์
- [setSlideImageFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSlideImageFormat): เปลี่ยนวิธีการแสดงสไลด์ เช่น เป็น SVG
- [setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setPicturesCompression): ควบคุม DPI ของภาพและขนาดผลลัพธ์
- [setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setDeletePicturesCroppedAreas): เก็บหรือเอาข้อมูลส่วนที่ถูกตัดของภาพออก
- [setSvgResponsiveLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout): ทำให้เนื้อหา SVG ที่ส่งออกปรับให้เข้ากับคอนเทนเนอร์
- [setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setShowHiddenSlides): รวมสไลด์ที่ซ่อนไว้เมื่อจำเป็น

ส่วนต่อไปนี้จะแสดงตัวเลือกที่พบบ่อยที่สุดแยกตามรายการ เพื่อให้คุณสามารถรวมเฉพาะตัวเลือกที่ต้องการในกระบวนการทำงานของคุณ

## **แปลงสไลด์ที่เลือกเป็น HTML**

การ overload ของ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) ที่รับหมายเลขสไลด์ใช้ตำแหน่งสไลด์เริ่มจาก 1 ลูปด้านล่างจะบันทึกแต่ละสไลด์เป็นไฟล์ HTML แยกกัน

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

ใช้รูปแบบนี้เมื่อเว็บไซต์หรือแอปพลิเคชันต้องการหน้า HTML หนึ่งหน้าต่อสไลด์ หากสไลด์แต่ละอันควรมี layout เดิมกัน ให้สร้างอินสแตนซ์ของ [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/) หนึ่งอ็อบเจ็กต์และส่งผ่านให้กับการเรียก [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) แต่ละครั้ง

## **สร้าง HTML แบบ Responsive**

[ResponsiveHtmlController](https://reference.aspose.com/slides/th/python-java/aspose.slides/responsivehtmlcontroller/) ให้ผลลัพธ์ HTML แบบ responsive ผ่าน [HtmlFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/). ใช้เมื่อหน้าที่ส่งออกควรปรับตัวให้เข้ากับความกว้างของเบราว์เซอร์ได้ดีขึ้น

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

สำหรับ layout แบบ responsive ที่ใช้ SVG ให้เรียก [HtmlOptions.setSvgResponsiveLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSvgResponsiveLayout) ด้วยค่า `True` ซึ่งมีประโยชน์เมื่อเนื้อหาสไลด์ถูกส่งออกเป็น markup SVG ที่ขยายได้

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

ใช้ [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/) ผ่าน [HtmlOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setSlidesLayoutOptions) เพื่อรวมโน้ตผู้บรรยายหรือความคิดเห็น โน้ตและความคิดเห็นจะถูกซ่อนไว้เป็นค่าเริ่มต้น เว้นแต่คุณจะกำหนดตำแหน่งของมัน

สมมติว่าการนำเสนอแหล่งมีโน้ตผู้บรรยาย:

![สไลด์พร้อมโน้ตผู้บรรยายใน PowerPoint](slide_with_notes.png)

โค้ดต่อไปนี้ส่งออกเนื้อหาสไลด์พร้อมโน้ตผู้บรรยายที่อยู่ใต้สไลด์

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

![ผลลัพธ์ HTML ที่มีสไลด์และโน้ตผู้บรรยาย](HTML_with_notes.png)

เพื่อส่งออกความคิดเห็น ให้เรียก [NotesCommentsLayoutingOptions.setCommentsPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setCommentsPosition) เช่นกับ [CommentsPositions.Right](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentspositions/#Right) หรือ [CommentsPositions.Bottom](https://reference.aspose.com/slides/th/python-java/aspose.slides/commentspositions/#Bottom) หากคุณต้องการเพียงความคิดเห็นให้ละเว้นการเรียก [NotesCommentsLayoutingOptions.setNotesPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/notescommentslayoutingoptions/#setNotesPosition) หากต้องการทั้งโน้ตและความคิดเห็นให้เรียกทั้งสองเมธอด

## **ควบคุมคุณภาพภาพและพื้นที่ที่ถูกตัด**

การส่งออก HTML สามารถบีบอัดภาพสไลด์เพื่อ ลดขนาดผลลัพธ์ได้ ให้ส่งค่าที่ต้องการไปยัง [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setPicturesCompression) จาก [PicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturescompression/) เมื่อคุณต้องการคุณภาพภาพที่สูงกว่า

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

โดยค่าเริ่มต้น พื้นที่ที่ถูกตัดของภาพอาจถูกลบออกจากผลลัพธ์ที่ส่งออก ให้เก็บข้อมูลที่ถูกตัดไว้เฉพาะเมื่อผู้ใช้ต้องการกู้คืนหรือตรวจสอบส่วนที่ซ่อนของภาพ การเก็บไว้จะทำให้ขนาด HTML เพิ่มขึ้น

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

สำหรับการตกแต่งแบบง่าย ให้ส่งสตริง CSS ไปยัง [HtmlFormatter.createDocumentFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/#createDocumentFormatter) ซึ่งจะเปลี่ยนเอกสาร HTML รอบข้างในขณะที่ Aspose.Slides ยังคงเรนเดอร์เนื้อหาสไลด์ต่อไป

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

หากต้องการส่วนหัวของเอกสารแบบกำหนดเอง, ไฟล์ CSS ที่เชื่อมโยง, หรือ markup แบบกำหนดเองรอบสไลด์และรูปร่าง ใช้คอนโทรลเลอร์การจัดรูปแบบแบบกำหนดเองผ่านพร็อกซิอินเตอร์เฟซ JPype แล้วส่งผ่านให้กับ [HtmlFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/) ด้วย [HtmlFormatter.createCustomFormatter](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmlformatter/#createCustomFormatter)

## **ฝังฟอนต์**

หากสภาพแวดล้อมเป้าหมายอาจไม่มีฟอนต์ของการนำเสนอที่ติดตั้งไว้ ให้ฝังฟอนต์ใน HTML ด้วย [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/th/python-java/aspose.slides/embedallfontshtmlcontroller/). การฝังช่วยรักษาความเที่ยงตรงของภาพ แต่ทำให้ขนาดผลลัพธ์เพิ่มขึ้น

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

ให้ยกเว้นฟอนต์เฉพาะเมื่อคุณมั่นใจว่าบราวเซอร์หรือระบบเป้าหมายมีฟอนต์เหล่านั้นแล้ว สำหรับฟอนต์ของแบรนด์หรือฟอนต์ที่ไม่ทั่วไป การฝังมักจะปลอดภัยกว่า

## **บันทึกทรัพยากรเป็นภายนอก**

HTML ที่เป็นไฟล์เดียวง่ายต่อการย้าย แต่ทรัพยากรที่ฝังในรูปแบบ Base64 สามารถทำให้ไฟล์ใหญ่ หากแอปพลิเคชันของคุณต้องการไฟล์รูปภาพภายนอก ให้ทำการติดตั้งคอนโทรลเลอร์การลิงก์ทรัพยากรผ่านพร็อกซิอินเตอร์เฟซ JPype แล้วส่งผ่านให้กับคอนสตรัคเตอร์ของ [HtmlOptions](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/)

เมื่อคุณทำให้ทรัพยากรเป็นภายนอก ให้เลือกเส้นทางสองเส้นทางอย่างเจตนา:

- เส้นทางการออกไฟล์ระบบ, ที่แอปพลิเคชันของคุณเขียนภาพ, ฟอนต์, เสียง หรือวิดีโอที่สร้างขึ้น
- เส้นทาง URL, ซึ่งเป็นที่เบราว์เซอร์ใช้จากเอกสาร HTML เพื่อโหลดไฟล์เหล่านั้น

## **ส่งออกไฟล์สื่อ**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoplayerhtmlcontroller/) ส่งออกไฟล์วิดีโอและเสียงและเขียน HTML ที่สามารถเล่นไฟล์เหล่านั้นในเบราว์เซอร์ คอนสตรัคเตอร์รับพารามิเตอร์:

- `path`: ไดเรกทอรีที่ไฟล์สื่อที่สร้างจะถูกเขียน
- `fileName`: ชื่อไฟล์ HTML ที่กำลังสร้าง
- `baseUri`: คำต่อหน้าที่เป็น URI แบบสมบูรณ์ที่ใช้ในลิงก์ HTML ไปยังไฟล์สื่อ

ตัวอย่างต่อไปนี้ส่งออกสื่อที่ฝังอยู่ใน `presentation.pptx` HTML ที่สร้างจะอ้างอิงไฟล์สื่อโดยใช้ชื่อไฟล์เท่านั้น ซึ่งสัมพันธ์กับเอกสาร HTML ดังนั้น `path` ต้องเป็นไดเรกทอรีที่รับไฟล์ HTML ด้วย `baseUri` ต้องเป็น URI แบบสมบูรณ์: สำหรับการพรีวิวในเครื่อง สร้าง URI `file:///` จากไดเรกทอรีผลลัพธ์; สำหรับแอปพลิเคชันที่ปรับใช้ให้ใช้ URL แบบสมบูรณ์ของไดเรกทอรีที่เผยแพร่

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

ใช้ไดเรกทอรีผลลัพธ์ที่เป็นเอกลักษณ์ต่อแต่ละงานส่งออกโดยเฉพาะในแอปพลิเคชันเซิร์ฟเวอร์ เส้นทางผลลัพธ์ที่แชร์กันอาจทำให้ไฟล์จากการแปลงต่างๆ ถูกเขียนทับกัน

## **ประสิทธิภาพและการจัดการทรัพยากร**

การแปลงเป็น HTML เป็นการดำเนินการเรนเดอร์ ดังนั้นเวลาในการประมวลผลและการใช้หน่วยความจำขึ้นอยู่กับจำนวนสไลด์, ความละเอียดของภาพ, ฟอนต์, เอฟเฟกต์, แผนภูมิ และสื่อที่ฝังไว้ ค่ DPI ของภาพที่สูงกว่า ที่ส่งผ่านไปยัง [HtmlOptions.setPicturesCompression], ฟอนต์ที่ฝัง, ผลลัพธ์ SVG, และการรักษาพื้นที่ภาพที่ถูกตัดสามารถเพิ่มความเที่ยงตรงได้แต่โดยทั่วไปจะทำให้ขนาดผลลัพธ์เพิ่มขึ้น

สำหรับการแปลงเป็นชุด:

- ทำลายอินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ทุกตัวโดยทันที
- ใช้ไดเรกทอรีผลลัพธ์แยกสำหรับงานแยกต่างหาก
- หลีกเลี่ยงการฝังฟอนต์ทั่วไปเว้นแต่ความเที่ยงตรงจำเป็น
- ลด DPI ของภาพเมื่อ HTML ใช้สำหรับการพรีวิวหรือรูปย่อ
- เก็บการนำเสนอแหล่ง, HTML ที่สร้าง, และทรัพยากรภายนอกไว้ด้วยกันจนกว่าพาธการปรับใช้จะเป็นที่สมบูรณ์

## **คำถามที่พบบ่อย**

**ลิงก์ไฮเปอร์ลิงก์ถูกเก็บไว้ในผลลัพธ์ HTML หรือไม่?**

ใช่. ลิงก์ไฮเปอร์ของการนำเสนอจะถูกส่งออกเป็น HTML และยังคงคลิกได้เมื่อ URL เป้าหมายถูกต้อง

**ฉันสามารถแปลงการนำเสนอเป็น HTML พร้อมกันได้หรือไม่?**

ได้, แต่ห้ามแชร์อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ระหว่างเธรด ให้ประมวลผลไฟล์ต่างกันโดยใช้อินสแตนซ์ของการนำเสนอแยก, สตรีมแยก, และไดเรกทอรีผลลัพธ์แยก ดูที่ [multithreading guidance](/slides/th/python-java/multithreading/) เพื่อรายละเอียด

**อ็อบเจ็กต์การนำเสนอปลอดภัยต่อเธรดหรือไม่?**

ไม่มี. อินสแตนซ์ของ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ควรโหลด, แก้ไข, บันทึก, และทำลายบนเธรดเดียว สำหรับงานแบบขนานให้สร้างอินสแตนซ์แยกสำหรับแต่ละเธรดหรือกระบวนการ

**ทำไมไฟล์ HTML ที่สร้างจึงใหญ่?**

การส่งออกค่าเริ่มต้นอาจฝังทรัพยากรโดยตรงใน HTML ฟอนต์ที่ฝัง, ภาพ DPI สูง, สื่อ, เนื้อหา SVG, และการเก็บพื้นที่ภาพที่ถูกตัดก็ทำให้ขนาดเพิ่ม ใช้ทรัพยากรภายนอก, ยกเว้นฟอนต์ทั่วไปจากการฝัง, และส่งค่ DPI ที่ต่ำกว่าไปยัง [HtmlOptions.setPicturesCompression](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setPicturesCompression) เมื่อขนาดผลลัพธ์ที่เล็กสำคัญกว่าความเที่ยงตรงสูงสุด

**ทำไมค่า font-size ใน HTML ถึงอาจแตกต่างจากค่าใน PowerPoint?**

หน้าที่ส่งออกอาจใช้ระบบพิกัด SVG และการแปลงสเกล ค่าฟอนต์ขนาด CSS หรือ SVG เพียงอย่างเดียวไม่อธิบายขนาดที่แสดงสุดท้าย ให้เปรียบเทียบสไลด์ที่เรนเดอร์ที่ระดับการซูมที่ต้องการ และตรวจสอบความพร้อมของฟอนต์หากข้อความดูแตกต่าง

**ฉันควรเลือก baseUri สำหรับการส่งออกสื่ออย่างไร?**

เลือก `baseUri` จากมุมมองของเบราว์เซอร์และส่งเป็น URI แบบสมบูรณ์ สำหรับการพรีวิวในเครื่องคุณสามารถสร้างจากไดเรกทอรีผลลัพธ์ด้วย `output_directory.as_uri() + "/"` สำหรับการปรับใช้ให้ใช้ URL แบบสมบูรณ์ของไดเรกทอรีที่เผยแพร่ ไฟล์ระบบ `path` และเบราว์เซอร์ `baseUri` ไม่จำเป็นต้องเป็นสตริงเดียวกัน แต่ต้องอธิบายตำแหน่งเดียวกันและตำแหน่งนั้นต้องเป็นไดเรกทอรีที่เก็บไฟล์ HTML ที่สร้าง เนื่องจากลิงก์สื่อถูกเขียนเป็นแบบสัมพันธ์กับมัน

**ฉันสามารถรวมสไลด์ที่ซ่อนได้หรือไม่?**

ได้. เรียก [HtmlOptions.setShowHiddenSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/htmloptions/#setShowHiddenSlides) ด้วยค่า `True` เมื่อจำเป็นต้องส่งออกสไลด์ที่ซ่อนอยู่