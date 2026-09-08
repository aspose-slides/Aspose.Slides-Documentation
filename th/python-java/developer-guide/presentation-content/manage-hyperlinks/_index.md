---
title: จัดการ Hyperlink ของการนำเสนอใน Python ผ่าน Java
linktitle: จัดการ Hyperlink
type: docs
weight: 20
url: /th/python-java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่ม Hyperlink
- สร้าง Hyperlink
- จัดรูปแบบ Hyperlink
- ลบ Hyperlink
- อัปเดต Hyperlink
- Hyperlink ข้อความ
- Hyperlink สไลด์
- Hyperlink รูปร่าง
- Hyperlink รูปภาพ
- Hyperlink วิดีโอ
- Hyperlink ที่แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "จัดการ Hyperlink ในการนำเสนอ PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน Java—เพิ่มความโต้ตอบและประสิทธิภาพการทำงานในเวลาไม่กี่นาที"
---
## **คำนำ**

Hyperlink คือการอ้างอิงไปยังออบเจกต์หรือข้อมูลหรือสถานที่ในบางอย่าง ซึ่งเป็น Hyperlink ที่พบบ่อยในงานนำเสนอ PowerPoint:

* ลิงก์ไปยังเว็บไซต์ภายในข้อความ, รูปร่าง, หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides for Python via Java ช่วยคุณทำงานหลายอย่างที่เกี่ยวกับ Hyperlink ในการนำเสนอ

{{% alert color="info" title="หมายเหตุ" %}} 

คุณอาจอยากลองใช้ Aspose อย่างง่าย, [ฟรีออนไลน์ PowerPoint editor.](https://products.aspose.app/slides/th/editor)

{{% /alert %}} 

## **เพิ่ม URL Hyperlink**

### **เพิ่ม URL Hyperlink ไปยังข้อความ**

โค้ด Python นี้แสดงวิธีเพิ่ม Hyperlink เว็บไซต์ไปยังข้อความ:

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

### **เพิ่ม URL Hyperlink ไปยังรูปร่างหรือเฟรม**

ตัวอย่างโค้ดใน Python via Java นี้แสดงวิธีเพิ่ม Hyperlink เว็บไซต์ไปยังรูปร่าง:

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

### **เพิ่ม URL Hyperlink ไปยังสื่อ**

Aspose.Slides ให้คุณเพิ่ม Hyperlink ไปยังรูปภาพ, ไฟล์เสียง, และไฟล์วิดีโอ

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **รูปภาพ**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    # เพิ่มรูปภาพลงในการนำเสนอ
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    # สร้างกรอบรูปภาพบนสไลด์ที่ 1 โดยอิงจากรูปภาพที่เพิ่มไว้ก่อนหน้า
    picture_frame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    picture_frame.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    picture_frame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs")

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **ไฟล์เสียง**:

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

ตัวอย่างโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยัง **วิดีโอ**:

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

{{% alert color="success" title="เคล็ดลับ" %}} 

คุณอาจอยากดู *[Manage OLE](/slides/th/python-java/manage-ole/)*.

{{% /alert %}}

## **ใช้ Hyperlink เพื่อสร้างสารบัญ**

เนื่องจาก Hyperlink ช่วยให้คุณเพิ่มการอ้างอิงไปยังออบเจกต์หรือสถานที่ คุณสามารถใช้มันสร้างสารบัญได้

ตัวอย่างโค้ดนี้แสดงวิธีสร้างสารบัญที่มี Hyperlink:

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

## **จัดรูปแบบ Hyperlink**

### **สี**

ด้วยคุณสมบัติ [Hyperlink.setColorSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setColorSource) ในคลาส [Hyperlink](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/) คุณสามารถกำหนดสีของ Hyperlink และยังสามารถดึงข้อมูลสีจาก Hyperlink ได้ คุณลักษณะนี้ถูกแนะนำครั้งแรกใน PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงที่เกี่ยวกับคุณสมบัตินี้จะไม่ทำงานกับเวอร์ชัน PowerPoint ที่เก่ากว่า

ตัวอย่างโค้ดนี้สาธิตการเพิ่ม Hyperlink ที่มีสีต่างกันลงในสไลด์เดียวกัน:

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

## **ลบ Hyperlink ออกจากการนำเสนอ**

### **ลบ Hyperlink จากข้อความ**

โค้ด Python นี้แสดงวิธีลบ Hyperlink จากข้อความในสไลด์การนำเสนอ:

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

### **ลบ Hyperlink จากรูปร่างหรือเฟรม**

โค้ด Python นี้แสดงวิธีลบ Hyperlink จากรูปร่างในสไลด์การนำเสนอ:

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

## **Hyperlink แบบเปลี่ยนแปลงได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/) สามารถเปลี่ยนแปลงค่าได้ ด้วยคลาสนี้คุณสามารถแก้ไขค่าของคุณสมบัติเหล่านี้:

- [setTargetFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setTargetFrame)
- [setTooltip](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setTooltip)
- [setHistory](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setHistory)
- [setHighlightClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setHighlightClick)
- [setStopSoundOnClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setStopSoundOnClick)

ส่วนของโค้ดนี้แสดงวิธีเพิ่ม Hyperlink ไปยังสไลด์และแก้ไข Tooltip ของมันภายหลัง:

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

    # เปลี่ยน tooltip ของ hyperlink ที่ได้เพิ่มไว้แล้ว
    portion_format.getHyperlinkClick().setTooltip("Aspose: the File Format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คุณสมบัติที่รองรับใน HyperlinkQueries**

คุณสามารถเข้าถึง [HyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/) จากการนำเสนอ, สไลด์, หรือข้อความที่กำหนด Hyperlink ไว้ได้

- [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getHyperlinkQueries)
- [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getHyperlinkQueries)
- [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getHyperlinkQueries)

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/) รองรับเมธอดและคุณสมบัติดังนี้:

- [getHyperlinkClicks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks)
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers)
- [getAnyHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks)
- [removeAllHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks)

## **คำถามที่พบบ่อย**

**ฉันจะสร้างการนำทางภายในที่ไม่ใช่แค่สไลด์เดียว แต่ไปยัง “ส่วน” หรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint คือการจัดกลุ่มสไลด์; การนำทางทางเทคนิคจะชี้ไปยังสไลด์เฉพาะ เพื่อ “ไปยังส่วน” คุณมักจะลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบ Hyperlink ไปยังองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**

ได้ มาสเตอร์สไลด์และเลเอาต์อิลิเมนต์รองรับ Hyperlink ลิงก์เหล่านี้จะแสดงบนสไลด์ลูกและสามารถคลิกได้ระหว่างการพรีเซ็นต์

**Hyperlink จะถูกเก็บไว้เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

ใน [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/python-java/convert-powerpoint-to-html/) ใช่—ลิงก์ส่วนใหญ่จะถูกเก็บไว้ แต่เมื่อส่งออกเป็น [ภาพ](/slides/th/python-java/convert-powerpoint-to-png/) และ [วิดีโอ](/slides/th/python-java/convert-powerpoint-to-video/) ความสามารถในการคลิกจะไม่ถ่ายทอดต่อเนื่องเนื่องจากลักษณะของฟอร์แมตเหล่านั้น (เฟรมภาพ/วิดีโอแบบแรสเตอร์ไม่รองรับ Hyperlink)