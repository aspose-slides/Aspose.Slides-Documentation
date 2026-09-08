---
title: การสกัดข้อความขั้นสูงจากพรีเซนเทชันใน Python ผ่าน Java
linktitle: สกัดข้อความ
type: docs
weight: 90
url: /th/python-java/extract-text-from-presentation/
keywords:
- สกัดข้อความ
- สกัดข้อความจากสไลด์
- สกัดข้อความจากพรีเซนเทชัน
- สกัดข้อความจาก PowerPoint
- สกัดข้อความจาก OpenDocument
- สกัดข้อความจาก PPT
- สกัดข้อความจาก PPTX
- สกัดข้อความจาก ODP
- ดึงข้อความ
- ดึงข้อความจากสไลด์
- ดึงข้อความจากพรีเซนเทชัน
- ดึงข้อความจาก PowerPoint
- ดึงข้อความจาก OpenDocument
- ดึงข้อความจาก PPT
- ดึงข้อความจาก PPTX
- ดึงข้อความจาก ODP
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
- Java
- Aspose.Slides
description: "สกัดข้อความจากพรีเซนเทชัน PowerPoint และ OpenDocument อย่างรวดเร็วด้วย Aspose.Slides สำหรับ Python ผ่าน Java. ปฏิบัติตามคู่มือขั้นตอนง่ายของเราเพื่อประหยัดเวลา."
---
## **ภาพรวม**

การสกัดข้อความจากพรีเซนเทชันเป็นงานทั่วไปแต่สำคัญสำหรับนักพัฒนาที่ทำงานกับเนื้อหาแบบสไลด์ ไม่ว่าคุณจะทำงานกับไฟล์ Microsoft PowerPoint ในรูปแบบ PPT หรือ PPTX หรือพรีเซนเทชัน OpenDocument (ODP) การเข้าถึงและดึงข้อมูลข้อความอาจเป็นสิ่งที่จำเป็นสำหรับการวิเคราะห์, การทำอัตโนมัติ, การทำดัชนี, หรือการย้ายเนื้อหา

บทความนี้ให้คำแนะนำอย่างเต็มที่เกี่ยวกับวิธีสกัดข้อความจากรูปแบบพรีเซนเทชันต่าง ๆ ได้แก่ PPT, PPTX, และ ODP โดยใช้ Aspose.Slides for Python via Java คุณจะได้เรียนรู้วิธีวนผ่านองค์ประกอบของพรีเซนเทชันอย่างเป็นระบบเพื่อดึงข้อความที่ต้องการอย่างแม่นยำ

## **สกัดข้อความจากสไลด์**

Aspose.Slides for Python via Java มีคลาส [SlideUtil](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/) คลาสนี้เปิดเผยเมธอดสแตติกหลายรูปแบบสำหรับสกัดข้อความทั้งหมดจากพรีเซนเทชันหรือสไลด์ เพื่อสกัดข้อความจากสไลด์ในพรีเซนเทชัน ให้ใช้เมธอด [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#getAllTextBoxes) เมธอดนี้รับอ็อบเจกต์ชนิด [BaseSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/) เป็นพารามิเตอร์ เมื่อทำงาน เมธอดจะสแกนสไลด์ทั้งหมดเพื่อค้นหาข้อความและคืนค่าเป็นอาร์เรย์ของอ็อบเจกต์ชนิด [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) โดยคงรูปแบบข้อความไว้

ส่วนโค้ดต่อไปนี้สกัดข้อความทั้งหมดจากสไลด์แรกของพรีเซนเทชัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **สกัดข้อความจากพรีเซนเทชัน**

เพื่อสแกนข้อความจากพรีเซนเทชันทั้งหมด ให้ใช้เมธอดสแตติก [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#getAllTextFrames) ของคลาส [SlideUtil](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/) เมธอดนี้รับพารามิเตอร์สองค่า:

1. ครั้งแรก เป็นอ็อบเจกต์ [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ซึ่งแทนพรีเซนเทชัน PowerPoint หรือ OpenDocument ที่ต้องการสกัดข้อความ
1. ครั้งที่สอง เป็นค่า `bool` ที่บ่งชี้ว่าจะรวมสไลด์มาสเตอร์ในการสแกนข้อความจากพรีเซนเทชันหรือไม่

เมธอดจะคืนค่าเป็นอาร์เรย์ของอ็อบเจกต์ชนิด [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) พร้อมข้อมูลการจัดรูปแบบข้อความ โค้ดตัวอย่างด้านล่างสแกนข้อความและรายละเอียดการจัดรูปแบบจากพรีเซนเทชันรวมถึงสไลด์มาสเตอร์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **การสกัดข้อความแบบจัดประเภทและรวดเร็ว**

คลาส [PresentationFactory](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationfactory/) ยังมีเมธอดสำหรับสกัดข้อความทั้งหมดจากพรีเซนเทชัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# สกัดข้อความจากไฟล์.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# สกัดข้อความจากสตรีม.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# สกัดข้อความจากสตรีมโดยใช้ตัวเลือกการโหลด.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

อาร์กิวเมนต์ enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/textextractionarrangingmode/) ระบุโหมดการจัดผลลัพธ์การสกัดข้อความและสามารถตั้งค่าเป็นค่าต่อไปนี้:

- [Unarranged](https://reference.aspose.com/slides/th/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) - ข้อความดิบโดยไม่คำนึงถึงตำแหน่งบนสไลด์
- [Arranged](https://reference.aspose.com/slides/th/python-java/aspose.slides/textextractionarrangingmode/#Arranged) - ข้อความจัดเรียงตามลำดับเดียวกับบนสไลด์

โหมด Unarranged สามารถใช้เมื่อความเร็วเป็นสิ่งสำคัญ; จะเร็วกว่าโหมด Arranged

[PresentationText](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationtext/) แทนข้อความดิบที่สกัดจากพรีเซนเทชัน เมธอด [getSlidesText](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentationtext/#getSlidesText) จะคืนค่าเป็นอาร์เรย์ของอ็อบเจกต์ชนิด `SlideText` แต่ละอ็อบเจกต์แทนข้อความบนสไลด์ที่สอดคล้อง มีเมธอดต่อไปนี้:

- `getText` - ข้อความภายในรูปร่างของสไลด์
- `getMasterText` - ข้อความภายในรูปร่างของสไลด์มาสเตอร์ที่เชื่อมกับสไลด์นี้
- `getLayoutText` - ข้อความภายในรูปร่างของสไลด์เลย์เอาต์ที่เชื่อมกับสไลด์นี้
- `getNotesText` - ข้อความภายในรูปร่างของสไลด์โน้ตที่เชื่อมกับสไลด์นี้
- `getCommentsText` - ข้อความภายในคอมเมนต์ที่เชื่อมกับสไลด์นี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **คำถามที่พบบ่อย**

**Aspose.Slides ทำการสกัดข้อความจากพรีเซนเทชันขนาดใหญ่ได้เร็วแค่ไหน?**

Aspose.Slides ถูกปรับให้ทำงานประสิทธิภาพสูงและสามารถประมวลผลแม้ [พรีเซนเทชันขนาดใหญ่](/slides/th/python-java/open-presentation/) ทำให้เหมาะสำหรับสถานการณ์ที่ต้องการการประมวลผลแบบเรียลไทม์หรือแบบกลุ่ม

**Aspose.Slides สามารถสกัดข้อความจากตารางและแผนภูมิภายในพรีเซนเทชันได้หรือไม่?**

ได้ Aspose.Slides สามารถสกัดข้อความจากหลายองค์ประกอบของสไลด์ รวมถึงตารางและออบเจกต์ที่เกี่ยวกับแผนภูมิ ทำให้คุณสามารถเข้าถึงและวิเคราะห์เนื้อหาข้อความในโครงสร้างพรีเซนเทชันทั่วไปได้

**ต้องมีใบอนุญาต Aspose.Slides พิเศษเพื่อสกัดข้อความจากพรีเซนเทชันหรือไม่?**

คุณสามารถสกัดข้อความโดยใช้เวอร์ชันทดลองฟรีของ Aspose.Slides แม้ว่าจะมี [ข้อจำกัดบางประการ](/slides/th/python-java/licensing/) เช่น การประมวลผลจำนวนสไลด์ที่จำกัด สำหรับการใช้งานโดยไม่จำกัดและเพื่อจัดการพรีเซนเทชันขนาดใหญ่ ควรซื้อใบอนุญาตเต็มรูปแบบ