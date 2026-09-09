---
title: จัดการไฮเปอร์ลิงก์การนำเสนอใน Python ผ่าน Java
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/python-java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ได้อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน Java—เพิ่มการโต้ตอบและกระบวนการทำงานในไม่กี่นาที"
---
## **บทนำ**

Hyperlink คือการอ้างอิงถึงวัตถุ ข้อมูล หรือสถานที่ ใบลิงก์ทั่วไปในงานนำเสนอ PowerPoint ประกอบด้วย:

* ลิงก์ไปยังเว็บไซต์ในข้อความ รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for Python via Java ช่วยให้คุณทำงานหลายอย่างที่เกี่ยวกับไฮเปอร์ลิงก์ในงานนำเสนอได้

{{% alert color="info" title="Note" %}} 
คุณอาจต้องการตรวจสอบ [โปรแกรมแก้ไข PowerPoint ออนไลน์ฟรี](https://products.aspose.app/slides/th/editor) ของ Aspose
{{% /alert %}} 

## **เพิ่มไฮเปอร์ลิงก์ URL**

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

โค้ด Python นี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์เว็บไซต์ให้กับข้อความ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปร่างหรือเฟรม**

ตัวอย่างโค้ดนี้ใน Python via Java แสดงวิธีการเพิ่มไฮเปอร์ลิงก์เว็บไซต์ให้กับรูปร่าง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับสื่อ**

Aspose.Slides อนุญาตให้คุณเพิ่มไฮเปอร์ลิงก์ไปยังไฟล์รูปภาพ เสียง และวิดีโอ

ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ให้กับ **ภาพ**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # เพิ่มรูปภาพลงในงานนำเสนอ
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # สร้างกรอบรูปบนสไลด์ที่ 1 โดยอ้างอิงจากรูปภาพที่เพิ่มไว้ก่อนหน้า
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ให้กับ **ไฟล์เสียง**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    audio_data = Path("audio.mp3").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(java_audio_data)
    audio_frame = presentation.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio)

    audio_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    audio_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ให้กับ **วิดีโอ**:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat

presentation = Presentation()
try:
    video_data = Path("video.avi").read_bytes()
    java_video_data = jpype.JArray(jpype.JByte)(video_data)
    video = presentation.getVideos().addVideo(java_video_data)
    video_frame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video)

    video_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    video_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}} 
คุณอาจต้องการดู *[จัดการ OLE](/slides/th/python-java/manage-ole/)*.
{{% /alert %}}

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

เนื่องจากไฮเปอร์ลิงก์ทำให้คุณเพิ่มการอ้างอิงถึงวัตถุหรือสถานที่ได้ คุณสามารถใช้มันเพื่อสร้างสารบัญได้

ตัวอย่างโค้ดนี้แสดงวิธีการสร้างสารบัญที่มีไฮเปอร์ลิงก์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())

    content_table = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    content_table.getFillFormat().setFillType(FillType.NoFill)
    content_table.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    content_table.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    content_table.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

ด้วยคุณสมบัติ [Hyperlink.setColorSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setColorSource) ในคลาส [Hyperlink](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/) คุณสามารถตั้งค่าสีสำหรับไฮเปอร์ลิงก์และยังสามารถดึงข้อมูลสีจากไฮเปอร์ลิงก์ได้ คุณลักษณะนี้เริ่มต้นแนะนำใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวข้องกับคุณสมบัตินี้จะไม่ได้ใช้กับ PowerPoint เวอร์ชันเก่า

ตัวอย่างโค้ดนี้แสดงการดำเนินการที่เพิ่มไฮเปอร์ลิงก์ที่มีสีต่างกันลงในสไลด์เดียวกัน:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Hyperlink, HyperlinkColorSource, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    colored_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, False)
    colored_link_shape.addTextFrame("This is a sample of colored hyperlink.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This is a sample of usual hyperlink.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

### **ลบไฮเปอร์ลิงก์จากข้อความ**

โค้ด Python นี้แสดงวิธีการลบไฮเปอร์ลิงก์ออกจากข้อความบนสไลด์ของงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, AutoShape

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None:
                for paragraph in text_frame.getParagraphs():
                    for portion in paragraph.getPortions():
                        portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick()

    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ลบไฮเปอร์ลิงก์จากรูปร่างหรือเฟรม**

โค้ด Python นี้แสดงวิธีการลบไฮเปอร์ลิงก์ออกจากรูปร่างบนสไลด์ของงานนำเสนอ:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        shape.getHyperlinkManager().removeHyperlinkClick()
    presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hyperlink ที่สามารถแก้ไขได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/) สามารถแก้ไขได้ ด้วยคลาสนี้คุณสามารถเปลี่ยนค่าให้กับคุณสมบัติเหล่านี้ได้:

- [setTargetFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

ตัวอย่างโค้ดนี้แสดงวิธีการเพิ่มไฮเปอร์ลิงก์ลงในสไลด์และแก้ไข tooltip ของมันภายหลัง:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpime.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, False)
    shape.addTextFrame("Aspose: File Format APIs")

    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")
    portion_format.setFontHeight(32)

    # เปลี่ยน tooltip ของไฮเปอร์ลิงก์ที่ได้เพิ่มไว้แล้ว
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คุณสมบัติที่รองรับใน HyperlinkQueries**

คุณสามารถเข้าถึง [HyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/) จากงานนำเสนอ สไลด์ หรือข้อความที่กำหนดไฮเปอร์ลิงก์ไว้ได้.

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getHyperlinkQueries)

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/) รองรับเมธอดและคุณสมบัติเหล่านี้:

- [getHyperlinkClicks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **FAQ**

**ฉันจะสร้างการนำทางภายในไม่ใช่แค่สไลด์เท่านั้น แต่ถึง "section" หรือสไลด์แรกของ section ได้อย่างไร?**

Section ใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางโดยเทคนิคจะชี้ไปที่สไลด์เฉพาะ การ "นำทางไปยัง section" มักทำได้โดยลิงก์ไปยังสไลด์แรกของมัน

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**

ได้. องค์ประกอบของมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์เหล่านี้จะแสดงบนสไลด์ลูกและสามารถคลิกได้ระหว่างการนำเสนอ

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

ใน [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/python-java/convert-powerpoint-to-html/) ใช่ — ลิงก์โดยทั่วไปจะคงไว้เมื่อส่งออก แต่เมื่อส่งออกเป็น [images](/slides/th/python-java/convert-powerpoint-to-png/) และ [video](/slides/th/python-java/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถูกส่งต่อเนื่องจากลักษณะของรูปแบบเหล่านั้น (เฟรมภาพราสเตอร์/วิดีโอไม่รองรับไฮเปอร์ลิงก์)