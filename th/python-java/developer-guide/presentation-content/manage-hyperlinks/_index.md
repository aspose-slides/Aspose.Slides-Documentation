---
title: จัดการ Hyperlink การนำเสนอใน Python ผ่าน Java
linktitle: จัดการ Hyperlink
type: docs
weight: 20
url: /th/python-java/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่ม hyperlink
- สร้าง hyperlink
- จัดรูปแบบ hyperlink
- ลบ hyperlink
- อัปเดต hyperlink
- hyperlink ข้อความ
- hyperlink สไลด์
- hyperlink รูปร่าง
- hyperlink ภาพ
- hyperlink วิดีโอ
- hyperlink ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต และลบ hyperlink ในการนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java โดยใช้ตัวอย่าง Python."
---
## **Introduction**

Hyperlink เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือที่ตั้งภายในการนำเสนอ ใน PowerPoint, hyperlink มักมีจุดประสงค์สองอย่าง:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือเฟรมสื่อ
* นำทางไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ

Aspose.Slides for Python via Java ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, อัปเดตคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับ hyperlink บนแต่ละองค์ประกอบและวิธีเข้าถึง hyperlink ในระดับการนำเสนอ, สไลด์, หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}

You can also edit presentations with the [free online Aspose PowerPoint editor](https://products.aspose.app/slides/th/editor).

{{% /alert %}} 

## **Add URL Hyperlinks**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือเฟรมสื่อได้ องค์ประกอบที่คุณกำหนด hyperlink จะเป็นตัวกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์เฉพาะข้อความที่เลือก, ในขณะที่รูปหรืเฟรมจะลิงก์กับอ็อบเจกต์สไลด์

### **Add URL Hyperlinks to Text**

เพื่อเชื่อมข้อความไปยังเว็บไซต์, ส่ง [Hyperlink](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#setHyperlinkClick) ของส่วนข้อความตามที่แสดงด้านล่าง ส่วนข้อความนั้นเท่านั้นจะกลายเป็นคลิกได้

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
    portion_format.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")
    portion_format.setFontHeight(32)

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Add URL Hyperlinks to Shapes and Media Frames**

เพื่อทำให้รูปหรือเฟรมสามารถคลิกได้, เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setHyperlinkClick) ของมัน hyperlink จะเป็นของอ็อบเจกต์เอง ไม่ใช่ของส่วนข้อความภายใน

แนวทางเดียวกันใช้กับเฟรมรูปภาพ, เสียง, และวิดีโอ: กำหนด hyperlink ให้กับเฟรมและเรียก [setTooltip](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setTooltip) หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมคลิกได้:

```python
import jpile
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50)

    shape.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Use Hyperlinks to Create a Table of Contents**

Hyperlink ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

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

    table_of_contents = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100)
    table_of_contents.getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    table_of_contents.getTextFrame().getParagraphs().clear()

    paragraph = Paragraph()
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText("Title of slide 2 .......... ")

    link_portion = Portion()
    link_portion.setText("Page 2")
    link_portion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(second_slide)

    paragraph.getPortions().add(link_portion)
    table_of_contents.getTextFrame().getParagraphs().add(paragraph)

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Format Hyperlinks**

### **Color**

เมธอด [setColorSource](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setColorSource) ของ [Hyperlink](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/) กำหนดว่าจะใช้สี hyperlink ของการนำเสนอหรือใช้การจัดรูปแบบของส่วนข้อความ เพื่อกำหนดสีข้อความแบบกำหนดเอง, เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkcolorsource/) และตั้งค่าสีเติมของส่วนนี้ ฟีเจอร์นี้ถูกเพิ่มใน PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปเพิ่ม hyperlink ข้อความสองรายการในสไลด์เดียว รายการแรกใช้สีเติมข้อความสีแดง, ส่วนที่สองคงสี hyperlink เริ่มต้น

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
    colored_link_shape.addTextFrame("This hyperlink uses a custom color.")
    portion_format = colored_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.setHyperlinkClick(Hyperlink("https://www.aspose.com/"))
    portion_format.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.RED)

    default_link_shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, False)
    default_link_shape.addTextFrame("This hyperlink uses the default color.")
    default_link_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(Hyperlink("https://www.aspose.com/"))

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Sound**

Hyperlink สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้วิธีต่อไปนี้เพื่อกำหนดพฤติกรรม:

- [Hyperlink.setSound](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setSound) ระบุไฟล์เสียงที่เชื่อมกับ hyperlink
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) ควบคุมว่าการเปิด hyperlink จะหยุดเสียงก่อนหน้าไหม

#### **Add a Hyperlink Sound**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` และเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์นั้นจะหยุดเสียงก่อนหน้าเมื่อคลิก โดยไม่ทำการนำทางใด ๆ

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Hyperlink, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    audio_data = Path("sampleaudio.wav").read_bytes()
    java_audio_data = jpype.JArray(jpype.JByte)(audio_data)
    hyperlink_sound = presentation.getAudios().addAudio(java_audio_data)
    first_slide = presentation.getSlides().get_Item(0)
    play_button = first_slide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50)
    play_button.setHyperlinkClick(Hyperlink.getNextSlide())
    if not play_button.getHyperlinkClick().getStopSoundOnClick() and play_button.getHyperlinkClick().getSound() is None:
        play_button.getHyperlinkClick().setSound(hyperlink_sound)
    second_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    stop_button = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50)
    stop_button.setHyperlinkClick(Hyperlink.getNoAction())
    stop_button.getHyperlinkClick().setStopSoundOnClick(True)
    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx)
except OSError as exception:
    print(f"Unable to read the audio file: {exception}")
finally:
    presentation.dispose()
```

#### **Extract a Hyperlink Sound**

ตัวอย่างต่อไปเปิดการนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียง hyperlink ของรูปแรกเข้าสู่หน่วยความจำผ่าน [getSound](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#getSound) และ [getBinaryData](https://reference.aspose.com/slides/th/python-java/aspose.slides/audio/#getBinaryData)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("hyperlink-sound.pptx")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getShapes().size() > 0:
        hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick()
        sound = hyperlink.getSound() if hyperlink is not None else None
        if sound is not None:
            audio_data = bytes(sound.getBinaryData())
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
finally:
    presentation.dispose()
```

### **Tooltip and Interaction Settings**

คุณสามารถเรียกเมธอดของ [Hyperlink](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/) ดังต่อไปนี้หลังจากกำหนด hyperlink ให้กับข้อความหรือรูป:

- [setTooltip](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setTooltip) ตั้งข้อความที่ผู้ดูสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [setTargetFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setTargetFrame) ระบุตำแหน่งเฟรมเป้าหมายในชุดเฟรม HTML ของพาเรนท์, เมื่อใช้ได้
- [setHistory](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setHistory) ควบคุมว่าการเปิดลิงก์จะเพิ่มจุดหมายลงในรายการ hyperlink ที่ดูแล้วหรือไม่
- [setHighlightClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#setHighlightClick) ควบคุมว่าลิงก์จะถูกเน้นเมื่อคลิกหรือไม่

## **Remove Hyperlinks from Presentations**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) เพื่อรวบรวมคอนเทนเนอร์ของ hyperlink, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบเพียงประเภทเดียว, ให้เรียกเพียง [removeHyperlinkClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); การลบการคลิกจะไม่ลบการวางเมาส์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        containers = list(presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks())
        for container in containers:
            container.getHyperlinkManager().removeHyperlinkClick()
            container.getHyperlinkManager().removeHyperlinkMouseOver()
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx)
    else:
        print("The presentation has no slides to process.")
finally:
    presentation.dispose()
```

สำหรับการลบโดยไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) จะลบทั้งสองประเภทการเปิดใช้งานในขอบเขตที่เลือกในหนึ่งครั้ง เพื่อทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน้ต, ดูหัวข้อ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **Build a Complete Hyperlink Inventory**

ก่อนแจกจ่ายการนำเสนอ, ควรสำรวจการกระทำแบบโต้ตอบและลิงก์เว็บทั้งหมด [getAnyHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) คืนคอนเทนเนอร์ของ hyperlink เช่น อ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) และ [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getHyperlinkClick) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getHyperlinkMouseOver) บนแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันอาจเปิดให้ทำทั้งสองการกระทำ, ดังนั้นรายงานครบต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะ hyperlink ระดับรูปอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามขอบเขตที่เหมาะสมแทน, แล้วเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อที่คุณจะได้อัปเดตหรือทำลายการกระทำต่อไป

### **Query Presentation, Slide, and Text-Frame Scopes**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/) มีให้ผ่าน [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getHyperlinkQueries), และ [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getHyperlinkQueries). ทุกขอบเขตรองรับการสอบถามเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) คืนคอนเทนเนอร์ที่มีการคลิก
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) คืนคอนเทนเนอร์ที่มีการวางเมาส์
- [getAnyHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) คืนคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำ

ตัวอย่างต่อไปสร้าง `hyperlink-audit-input.pptx` โดยมีลิงก์คลิกภายนอก, ลิงก์วางเมาส์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์วางเมาส์ข้อความ, และการกระทำแมโคร ไม่ได้ดำเนินการใด ๆ เหล่านี้ การสอบถามทั้งสามทำงานในทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์, ไม่ใช่จำนวนการกระทำทั้งหมด ขอบเขตกรอบข้อความจะยกเว้นลิงก์ของรูปที่หุ้มมัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType


def print_counts(scope, queries):
    click_count = queries.getHyperlinkClicks().size()
    mouse_over_count = queries.getHyperlinkMouseOvers().size()
    any_count = queries.getAnyHyperlinks().size()
    print(f"{scope}: click={click_count}, mouse-over={mouse_over_count}, any={any_count}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide())
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Click the text to go to slide 2")
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/")
    shape.getHyperlinkClick().setTooltip("Public website")
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx")
    portion_format = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
    portion_format.getHyperlinkManager().setInternalHyperlinkClick(destination)
    portion_format.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help")
    macro_button = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60)
    macro_button.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation")
    print_counts("Presentation", presentation.getHyperlinkQueries())
    print_counts("Slide 1", slide.getHyperlinkQueries())
    print_counts("Text frame", shape.getTextFrame().getHyperlinkQueries())
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ในตัวอย่างนี้, การสอบถามการนำเสนอและสไลด์แต่ละรายการรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์วางเมาส์สองรายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งสามรายการ. การสอบถามกรอบข้อความรายงานคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **Classify Actions and Destinations**

ใช้ [Hyperlink.getActionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#getActionType) เพื่อแยกความหมายของการกระทำก่อนแยกปลายทาง [HyperlinkActionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkactiontype/) มีค่ามากกว่าการนำทางเว็บ:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | ลิงก์ภายนอก; ตรวจสอบ URL และสคีม |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขตามบริบทสไลด์โชว์ |
| `JumpEndShow`, `StartCustomSlideShow` | จบการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `StartMacro` | เรียกทำงานแมโคร |
| `StartProgram` | เปิดโปรแกรม |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ |
| `NoAction`, `Unknown` | ไม่มีการนำทาง, หรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#getExternalUrl) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#getTargetSlide) การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บค่าที่คืนจาก [getExternalUrlOriginal](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) เมื่อแตกต่างจาก URL ปกติ, และรวม tooltip จาก [getTooltip](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlink/#getTooltip) เมื่อมี

### **Report, Sanitize, and Verify Hyperlinks**

ตัวอย่าง Python ต่อไปอ่านการนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างต้น), เขียน `hyperlink-audit.json`, ใช้นโยบาย, เก็บ `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อเช็คการกระทำทั้งสองประเภทอีกครั้ง มันรวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การเทียบเท่าการอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวซ้ำ การสอบถามการนำเสนอครอบคลุมสไลด์ทั่วไป; สำหรับการสำรวจทั่วแพคเกจ จะสอบถามมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ตและแฮนด์เอาต์เมื่อตัวนั้นมีอยู่

รายงานบันทึกดัชนีสไลด์ตั้งแต่หนึ่งและ [getSlideId](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getSlideId) หากมี [getSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getSlide) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและจะแจ้งด้วยขอบเขตของมัน คอนเทนเนอร์รูปและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะมีป้ายแยก; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทรันไทม์ของมัน แต่ละคอนเทนเนอร์จะได้รับ ID รายงานเพื่อให้สามารถเชื่อมโยงการกระทำสองอย่างได้ รายงานบันทึกประเภทการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enumeration ของ Java

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง มันจะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย, ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides HTTPS อย่างเดียวไม่สามารถสร้างความไว้วางใจได้: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ URL ภายนอกดั้งเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาต้าโดยไม่เปิดลิงก์หรือทำการกระทำ

สำหรับการแก้ไข, [getHyperlinkManager](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getHyperlinkManager) ของคอนเทนเนอร์สนับสนุน [setExternalHyperlinkClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). ที่นี่, ลิงก์คลิกภายนอกที่ไม่ได้รับอนุญาตจะถูกแทนที่ด้วยหน้า landing HTTPS คงที่; ลิงก์คลิกและลิงก์วางเมาส์ที่ไม่ได้รับอนุญาตอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replace_external_clicks` เป็น `False` เพื่อเอาการละเมิดนโยบายทั้งหมดออก เลือกหน้าแทนที่ที่เป็นของแอปก่อนการใช้งาน

Flag การส่งออกของรายงานใช้แนวทางรีวิว PDF เชิงรัดกุม: ทำเครื่องหมายการวางเมาส์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดไปยังสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นคำแนะนำรีวิว ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่ การส่งออก PDF และ HTML ที่รองรับอาจรักษา hyperlink ไว้, ขึ้นกับการกระทำ, ตัวเลือกการส่งออก, และโปรแกรมอ่านภาพแรสเตอร์ [images](/slides/th/python-java/convert-powerpoint-to-png/) และ [video](/slides/th/python-java/convert-powerpoint-to-video/) ไม่สามารถเก็บ hyperlink เชิงโต้ตอบ; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น

```python
import json
from pathlib import Path
from urllib.parse import urlsplit

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HyperlinkActionType, PortionFormat, Presentation, SaveFormat, Shape

IdentityHashMap = jpype.JClass("java.util.IdentityHashMap")


def slide_index(presentation, slide):
    for index, candidate in enumerate(presentation.getSlides(), start=1):
        if candidate == slide:
            return index
    return None


def is_https(value):
    if not value:
        return False
    value = str(value)
    if any(character.isspace() or ord(character) < 32 for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.getActionType() == HyperlinkActionType.JumpSpecificSlide:
        return "Missing target slide" if link.getTargetSlide() is None else None
    if link.getActionType() != HyperlinkActionType.Hyperlink:
        return "Action is not allowed"
    if not is_https(link.getExternalUrl()):
        return "Normalized URL is not absolute HTTPS"
    original = link.getExternalUrlOriginal()
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def collect_containers(presentation):
    found = list(presentation.getHyperlinkQueries().getAnyHyperlinks())
    scopes = list(presentation.getMasters()) + list(presentation.getLayoutSlides())
    for slide in presentation.getSlides():
        scopes.append(slide.getNotesSlideManager().getNotesSlide())
    scopes.append(presentation.getMasterNotesSlideManager().getMasterNotesSlide())
    scopes.append(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide())
    for scope in scopes:
        if scope is not None:
            found.extend(scope.getHyperlinkQueries().getAnyHyperlinks())
    seen = IdentityHashMap()
    unique = []
    for container in found:
        if not seen.containsKey(container):
            seen.put(container, True)
            unique.append(container)
    return unique


def text_or_none(value):
    return str(value) if value is not None else None


def add_row(rows, presentation, link, activation, container, container_id):
    if link is None:
        return
    owner_slide = container.getSlide() if hasattr(container, "getSlide") else None
    target_slide = link.getTargetSlide()
    violation = policy_violation(link)
    if isinstance(container, Shape):
        owner_type = "Shape"
    elif isinstance(container, PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = str(container.getClass().getSimpleName())
    ordinary_action = link.getActionType() in (HyperlinkActionType.Hyperlink, HyperlinkActionType.JumpSpecificSlide)
    original = link.getExternalUrlOriginal()
    rows.append({
        "ContainerId": container_id,
        "SlideIndex": slide_index(presentation, owner_slide),
        "SlideId": int(owner_slide.getSlideId()) if owner_slide is not None else None,
        "Scope": str(owner_slide.getClass().getSimpleName()) if owner_slide is not None else None,
        "OwnerType": owner_type,
        "Activation": activation,
        "ActionType": int(link.getActionType()),
        "ExternalUrl": text_or_none(link.getExternalUrl()),
        "TargetSlideIndex": slide_index(presentation, target_slide),
        "TargetSlideId": int(target_slide.getSlideId()) if target_slide is not None else None,
        "Tooltip": text_or_none(link.getTooltip()),
        "OriginalExternalUrl": text_or_none(original) if original != link.getExternalUrl() else None,
        "PotentiallyUnsafe": violation is not None,
        "PolicyViolation": violation,
        "TargetExport": "PDF",
        "PotentiallyUnsupportedByExport": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"
presentation = Presentation("hyperlink-audit-input.pptx")
try:
    containers = collect_containers(presentation)
    rows = []
    for container_id, container in enumerate(containers, start=1):
        add_row(rows, presentation, container.getHyperlinkClick(), "click", container, container_id)
        add_row(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, container_id)
    report = json.dumps(rows, indent=2)
    Path("hyperlink-audit.json").write_text(report, encoding="utf-8")

    for container in containers:
        click = container.getHyperlinkClick()
        if policy_violation(click) is not None:
            if replace_external_clicks and click.getActionType() == HyperlinkActionType.Hyperlink:
                container.getHyperlinkManager().setExternalHyperlinkClick(replacement_url)
            else:
                container.getHyperlinkManager().removeHyperlinkClick()
        if policy_violation(container.getHyperlinkMouseOver()) is not None:
            container.getHyperlinkManager().removeHyperlinkMouseOver()
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx)

    reopened = Presentation("hyperlink-sanitized.pptx")
    try:
        remaining_containers = collect_containers(reopened)
        violations = 0
        for container in remaining_containers:
            if policy_violation(container.getHyperlinkClick()) is not None:
                violations += 1
            if policy_violation(container.getHyperlinkMouseOver()) is not None:
                violations += 1
        print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
        if violations != 0:
            print("Verification failed: do not distribute the saved presentation.")
    finally:
        reopened.dispose()
except OSError as exception:
    print(f"Unable to write the audit report: {exception}")
finally:
    presentation.dispose()
```

ด้วยข้อมูลข้างต้น, รายงานมีห้ารายการการกระทำ ลิงก์วางเมาส์ไฟล์และแมโครคลิกถูกลบ, ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในคงอยู่ การตรวจสอบพิมพ์จำนวนการกระทำที่ไม่ได้รับอนุญาตเป็นศูนย์ ข้อมูลที่มี URL คลิกภายนอกที่ไม่ได้รับอนุญาตก็จะเข้าสู่สาขาการแทนที่ คอนเทนเนอร์ที่มีคลิกที่ได้รับอนุญาตและวางเมาส์ที่ไม่ได้รับอนุญาตจะเก็บคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/th/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) ที่ลบทั้งสองการกระทำในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบการกระทำของ hyperlink เท่านั้น; มันไม่ลบ VBA project ฝัง, วัตถุ OLE, หรือเนื้อหาเชิงโต้ตอบอื่น, และไม่ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**How can I link to a section or its first slide?**

**ฉันจะเชื่อมโยงไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

Sections in PowerPoint group slides, but an internal hyperlink targets an individual slide. To create navigation to a section, link to the first slide in that section.

ส่วนใน PowerPoint จะจัดกลุ่มสไลด์, แต่ hyperlink ภายในจะชี้ไปที่สไลด์เดียว เลือกนำทางไปยังส่วนโดยลิงก์ไปยังสไลด์แรกของส่วนนั้น

**Can I attach a hyperlink to master slide elements so it works on all slides?**

**ฉันสามารถแนบ hyperlink ไปยังองค์ประกอบสไลด์มาสเตอร์เพื่อให้ทำงานบนทุกสไลด์ได้ไหม?**

Yes. Master slide and layout elements support hyperlinks. Links on these elements are available during the slide show on slides that use the corresponding master or layout.

**Will hyperlinks be preserved when exporting to PDF, HTML, images, or video?**

**ลิงก์จะยังคงอยู่เมื่อส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

Supported PDF and HTML exports may preserve hyperlinks; raster images and video cannot. See the export considerations in [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).