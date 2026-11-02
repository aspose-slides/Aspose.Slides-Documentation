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
description: "เพิ่ม, จัดรูปแบบ, อัปเดตและลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java พร้อมตัวอย่าง Python."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือไปยังตำแหน่งภายในงานนำเสนอ. ใน PowerPoint, ไฮเปอร์ลิงก์มักมีจุดประสงค์สองอย่างคือ:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ.
* ไปยังสไลด์อื่น, ตัวอย่างเช่น จากสารบัญ.

Aspose.Slides for Python ผ่าน Java ช่วยให้คุณสามารถเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียงของมัน, ปรับปรุงคุณสมบัติ, และลบออกได้ ตัวอย่างต่อไปนี้แสดงวิธีการทำงานกับไฮเปอร์ลิงก์บนแต่ละองค์ประกอบและวิธีการเข้าถึงไฮเปอร์ลิงก์ในระดับการนำเสนอ, สไลด์ หรือกรอบข้อความ.

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขงานนำเสนอด้วย [ตัวแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **เพิ่ม URL Hyperlinks**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อได้ ส่วนประกอบที่คุณกำหนดไฮเปอร์ลิงก์จะเป็นตัวกำหนดพื้นที่ที่คลิกได้: ส่วนข้อความจะลิงก์กับข้อความที่เลือก, ส่วนรูปหรือกรอบจะลิงก์กับวัตถุสไลด์.

สำหรับงานนำเสนอที่มีไฮเปอร์ลิงก์แบบ relative, ดูที่ [จัดการฐานไฮเปอร์ลิงก์](/slides/th/python-java/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยน, หรือเคลียร์ฐานระดับเอกสาร.

### **เพิ่ม URL Hyperlinks ไปยังข้อความ**

เพื่อเชื่อมข้อความกับเว็บไซต์, ส่ง [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) ไปยังเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#setHyperlinkClick) ของส่วนข้อความ ตามตัวอย่างด้านล่าง. เฉพาะส่วนของข้อความนั้นจะกลายเป็นคลิกได้.

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

### **เพิ่ม URL Hyperlinks ไปยังรูปและกรอบสื่อ**

เพื่อทำให้รูปหรือกรอบสามารถคลิกได้, เรียกเมธอด [setHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setHyperlinkClick) ของมัน. ไฮเปอร์ลิงก์เป็นของวัตถุเอง ไม่ใช่ของส่วนข้อความภายใน.

วิธีเดียวกันใช้ได้กับกรอบรูป, เสียง, และวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบและเรียกเมธอด [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) หากต้องการ.

ตัวอย่างต่อไปนี้ทำให้สี่เหลี่ยมคลิกได้:
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
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs")

    presentation.save("presentation-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ใช้ไฮเปอร์ลิงก์เพื่อสร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในช่วยให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [setInternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setInternalHyperlinkClick) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง.

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

## **จัดรูปแบบไฮเปอร์ลิงก์**

### **สี**

เมธอด [setColorSource](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setColorSource) ของ [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการจัดรูปแบบของส่วนข้อความหรือไม่. เพื่อกำหนดสีข้อความแบบกำหนดเอง, เลือก [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkcolorsource/) และตั้งค่าสีเติมของส่วนนั้น. ฟีเจอร์นี้ถูกนำมาใน PowerPoint 2019; รุ่นที่เก่ากว่าไม่รองรับการตั้งค่านี้.

ตัวอย่างต่อไปนี้เพิ่มไฮเปอร์ลิงก์ข้อความสองรายการในสไลด์เดียว แรกใช้สีข้อความสีแดง, ส่วนที่สองคงสีไฮเปอร์ลิงก์เริ่มต้น.

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
### **เสียง**

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้เมธอดต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านั้น:

- [Hyperlink.setSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setSound) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setStopSoundOnClick) ควบคุมว่าการเปิดไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่.

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้โหลด `sampleaudio.wav` และเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและนำไปสไลด์ถัดไป รูปร่างที่สองบนสไลด์นั้นจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่ทำการนำทางใดๆ.

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

#### **ดึงเสียงจากไฮเปอร์ลิงก์**

ตัวอย่างต่อไปนี้เปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านไฟล์เสียงไฮเปอร์ลิงก์ของรูปแรกเข้าสู่หน่วยความจำโดยใช้ [getSound](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getSound) และ [getBinaryData](https://reference.aspose.com/slides/python-java/aspose.slides/audio/#getBinaryData).

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

### **เค้าโครง Tooltip และการโต้ตอบ**

คุณสามารถเรียกเมธอด [Hyperlink](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง:

- [setTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTooltip) ตั้งข้อความที่ผู้ชมจะเห็นเป็นคำแนะนำสำหรับลิงก์.
- [setTargetFrame](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setTargetFrame) ระบุกรอบเป้าหมายภายในชุดเฟรม HTML ของพาเรนต์, เมื่อใช้ได้.
- [setHistory](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHistory) ควบคุมว่าการเปิดลิงก์จะเพิ่มปลายทางของมันลงในรายการไฮเปอร์ลิงก์ที่ดูแล้วหรือไม่.
- [setHighlightClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#setHighlightClick) ควบคุมว่าไฮเปอร์ลิงก์จะไฮไลท์เมื่อคลิกหรือไม่.

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

ใช้ [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปนี้ลบทั้งสองประเภทการกระทำจากสไลด์แรก หากต้องการลบเพียงประเภทหนึ่ง, เรียกเฉพาะ [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick) หรือ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver); การลบการคลิกจะไม่ลบการกระทำเมาส์โอเวอร์ที่สอดคล้อง.

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

สำหรับการลบโดยไม่มีเงื่อนไข, [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks) จะลบทั้งสองประเภทการกระทำในขอบเขตที่เลือกในหนึ่งคำสั่ง. สำหรับการทำความสะอาดแบบเลือกและการครอบคลุมของมาสเตอร์, เลย์เอาต์, และโน้ต, ดู [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **สร้างรายการไฮเปอร์ลิงก์ที่สมบูรณ์**

ก่อนกระจายงานนำเสนอ, ควรทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน. [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) คืนค่าคอนเทนเนอร์ของไฮเปอร์ลิงก์, เช่นวัตถุ [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) และ [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) ไม่ใช่รายการแบนของสตริง URL. ตรวจสอบทั้ง [getHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkClick) และ [getHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkMouseOver) ในแต่ละคอนเทนเนอร์. พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันอาจเปิดเผยทั้งสองการกระทำ, ดังนั้นรายงานครบต้องมีสูงสุดสองแถวต่อคอนเทนเนอร์.

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปอาจพลาดลิงก์ที่แนบกับส่วนข้อความ. ให้สืบค้นขอบเขตที่เหมาะสมแทน, แล้วเก็บคอนเทนเนอร์ที่ส่งคืนเพื่อให้คุณสามารถอัปเดตหรือลบการกระทำของมันในภายหลัง.

### **สืบค้นขอบเขต Presentation, Slide, และ Text-Frame**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/) มีให้ใช้ผ่าน [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getHyperlinkQueries), และ [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#getHyperlinkQueries). แต่ละขอบเขตรองรับการสืบค้นเดียวกัน:

- [getHyperlinkClicks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkClicks) คืนค่าคอนเทนเนอร์ที่มีการกระทำคลิก.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getHyperlinkMouseOvers) คืนค่าคอนเทนเนอร์ที่มีการกระทำเมาส์โอเวอร์.
- [getAnyHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#getAnyHyperlinks) คืนค่าคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำ.

ตัวอย่างต่อไปนี้สร้างไฟล์ `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์เมาส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เมาส์โอเวอร์ของข้อความ, และการกระทำแมโคร. ตัวอย่างนี้ไม่ได้ดำเนินการใดๆ ของลิงก์เหล่านี้. การสืบค้นสามอย่างเดียวกันทำงานในทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำทั้งหมด. ขอบเขต text-frame จะไม่รวมลิงก์ของรูปร่างที่ล้อมรอบ.

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

สำหรับตัวอย่างนี้, การสืบค้นระดับ presentation และ slide แต่ละรายการรายงานคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์เมาส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งสามรายการ. การสืบค้นระดับ text-frame รายงานหนึ่งคอนเทนเนอร์ในแต่ละประเภท.

### **จำแนกการกระทำและปลายทาง**

ใช้ [Hyperlink.getActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getActionType) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของปลายทาง. ค่าใน [HyperlinkActionType](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkactiontype/) ครอบคลุมมากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `Hyperlink` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน. |
| `JumpSpecificSlide` | การนำทางภายในไปยังสไลด์เฉพาะ. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทสไลด์โชว์. |
| `JumpEndShow`, `StartCustomSlideShow` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง. |
| `StartMacro` | เรียกใช้แมโคร. |
| `StartProgram` | เปิดโปรแกรม. |
| `OpenFile`, `OpenPresentation` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ. |
| `StartStopMedia` | เริ่มหรือหยุดการเล่นสื่อ. |
| `NoAction`, `Unknown` | ไม่มีการกระทำการนำทาง, หรือการกระทำที่ไม่รู้จักที่ต้องตรวจสอบ. |

อ่านปลายทางภายนอกจาก [getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) และปลายทางภายในเฉพาะจาก [getTargetSlide](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTargetSlide). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ. ให้คงค่าที่ส่งคืนโดย [getExternalUrlOriginal](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrlOriginal) เมื่อต่างจาก URL ที่ทำให้เป็นรูปแบบมาตรฐาน, และรวม tooltip ที่ส่งคืนโดย [getTooltip](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getTooltip) หากมี.

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง Python ต่อไปนี้อ่านงานนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างต้น), เขียนไฟล์ `hyperlink-audit.json`, ใช้นโยบาย, บันทึกเป็น `hyperlink-sanitized.pptx`, และเปิดใหม่เพื่อเช็คทั้งสองประเภทการกระทำอีกครั้ง. ตัวอย่างนี้รวบรวมคอนเทนเนอร์ก่อนทำการเปลี่ยนแปลงและใช้การเทียบอ้างอิงเพื่อหลีกเลี่ยงการประมวลผลคอนเทนเนอร์เดียวกันสองครั้ง. การสืบค้นระดับ presentation ครอบคลุมสไลด์ทั่วไป; สำหรับการทำรายการทั่วทั้งแพคเกจ, ยังสืบค้นมาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ตและมือแจกเมื่อมี.

รายงานบันทึกดัชนีสไลด์เริ่มจาก 1 และ [getSlideId](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideId) เมื่อมี. [getSlide](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getSlide) ให้สไลด์เจ้าของสำหรับคอนเทนเนอร์ที่รองรับ. มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ทั่วไปและจะระบุด้วยขอบเขตของมัน. คอนเทนเนอร์รูปและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะถูกตั้งชื่อแยกกัน; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทระยะเวลารันไทม์. คอนเทนเนอร์แต่ละอันจะได้รับ ID ระดับรายงานเพื่อให้สองการกระทำของมันสามารถเชื่อมโยงกันได้. รายงานจะเก็บประเภทการกระทำเป็นค่าคงที่จำนวนเต็มที่กำหนดโดย enumeration ของ Java.

นโยบายการใช้งานที่จำกัดโดยเจตนานี้อนุญาตให้ใช้เฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง. มันจะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น. การปฏิเสธเหล่านี้เป็นการตัดสินใจตามนโยบาย, ไม่ได้เป็นการตัดสินความปลอดภัยของ Aspose.Slides. HTTPS เพียงอย่างเดียวไม่เป็นการสร้างความไว้วางใจ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่นๆ สำหรับแอปของคุณ. ทั้ง URL ภายนอกต้นฉบับและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ. ตัวอย่างนี้ตรวจสอบ metadata โดยไม่ตามลิงก์หรือเรียกการกระทำใดๆ.

สำหรับการแก้ไข, คอนเทนเนอร์ของ [getHyperlinkManager](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getHyperlinkManager) รองรับ [setExternalHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkClick), และ [removeHyperlinkMouseOver](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkmanager/#removeHyperlinkMouseOver). ที่นี่, ลิงก์คลิกภายนอกที่ห้ามจะถูกแทนที่ด้วยหน้า landing page HTTPS คงที่; คลิกที่ห้ามอื่นและการกระทำเมาส์โอเวอร์ที่ห้ามจะถูกลบอย่างอิสระ. ตั้งค่า `replace_external_clicks` เป็น `False` เพื่อทำการลบการละเมิดนโยบายทั้งหมดแทน. เลือกหน้าทดแทนที่เป็นของแอปพลิเคชันก่อนการปรับใช้งาน.

แฟล็กการส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเมาส์โอเวอร์และสิ่งใดๆ ที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ. นี่เป็นคำแนะนำการตรวจสอบ, ไม่ใช่การทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่หลังส่งออก. การส่งออก [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/python-java/convert-powerpoint-to-html/) ที่รองรับอาจคงไฮเปอร์ลิงก์ไว้, ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และผู้ดู. ภาพ [images](/slides/th/python-java/convert-powerpoint-to-png/) แบบราสเตอร์และ [video](/slides/th/python-java/convert-powerpoint-to-video/) ไม่สามารถคงไฮเปอร์ลิงก์เชิงโต้ตอบ; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น.

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

ด้วยอินพุตที่สร้างข้างต้น, รายงานมีห้าแถวของการกระทำ. ลิงก์เมาส์โอเวอร์ของไฟล์และการคลิกแมโครถูกลบ, ในขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในคงอยู่. การตรวจสอบพิมพ์จำนวนการกระทำที่ห้ามเป็นศูนย์. อินพุตที่มี URL คลิกภายนอกห้ามก็ทำให้สาขาการแทนที่ทำงาน. คอนเทนเนอร์ที่มีการคลิกที่อนุญาตและเมาส์โอเวอร์ที่ห้ามยังคงการกระทำคลิก.

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [removeAllHyperlinks](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlinkqueries/#removeAllHyperlinks), ซึ่งลบทั้งสองประเภทการกระทำในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย. การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบโปรเจกต์ VBA ที่ฝังอยู่, OLE objects, หรือเนื้อหาเชิงโต้ตอบอื่น, และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก.

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนนั้นได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปที่สไลด์เดี่ยว. เพื่อสร้างการนำทางไปยังส่วน, ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น.

**ฉันสามารถแนบไฮเปอร์ลิงก์ให้กับองค์ประกอบของมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์. ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานในระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่เกี่ยวข้อง.

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจคงไฮเปอร์ลิงก์ไว้; ภาพราสเตอร์และวิดีโอไม่สามารถทำได้. ดูข้อควรพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).