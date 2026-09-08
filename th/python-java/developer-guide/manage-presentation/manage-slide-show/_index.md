---
title: จัดการการแสดงสไลด์ใน Python ผ่าน Java
linktitle: สไลด์โชว์
type: docs
weight: 90
url: /th/python-java/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยผู้พูด
- เรียกดูโดยบุคคล
- เรียกดูที่คีออส
- ตัวเลือกการแสดง
- วนลูปต่อเนื่อง
- แสดงโดยไม่มีคำบรรยาย
- แสดงโดยไม่มีแอนิเมชัน
- สีปากกา
- แสดงสไลด์
- การแสดงที่กำหนดเอง
- เลื่อนสไลด์ต่อไป
- ด้วยตนเอง
- ใช้การกำหนดเวลา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน Java. ควบคุมการเปลี่ยนสไลด์, การกำหนดเวลาและอื่น ๆ ทั่วรูปแบบ PPT, PPTX และ ODP อย่างง่ายดาย."
---
## **บทนำ**

ตัวเลือก **Set Up Show** ของ Microsoft PowerPoint ให้คุณเลือกประเภทการแสดง, เปิดการวนลูป, เลือกสไลด์, และควบคุมการเลื่อนสไลด์ต่อไป. ด้วย Aspose.Slides for Python via Java, คุณสามารถกำหนดค่าตัวเลือกเหล่านี้โดยโปรแกรมและบันทึกลงในไฟล์การนำเสนอได้.

เมธอด [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideShowSettings) จะคืนค่าออบเจ็กต์ [SlideShowSettings](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/) ที่ควบคุมตัวเลือกเหล่านี้ ตัวอย่างด้านล่างต้องใช้ Aspose.Slides for Python via Java และ Java runtime ที่เข้ากันได้ แต่ละตัวอย่างจะเริ่ม JVM หากจำเป็นและจะปล่อยการนำเสนอเมื่อเสร็จสิ้น.

## **เลือกประเภทการแสดง**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setSlideShowType) กำหนดประเภทของการแสดงสไลด์ ซึ่งอาจเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/python-java/aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/python-java/aspose.slides/browsedatkiosk/). การใช้เมธอดนี้ช่วยให้คุณปรับการนำเสนอให้เหมาะกับสถานการณ์การใช้งานต่าง ๆ เช่น คีออสอัตโนมัติหรือการนำเสนอด้วยมือ.

ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และตั้งค่าประเภทการแสดงเป็น “Browsed by an individual” โดยไม่แสดงแถบเลื่อน.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, BrowsedByIndividual

presentation = Presentation()
try:
    show_type = BrowsedByIndividual()
    show_type.setShowScrollbar(False)
    presentation.getSlideShowSettings().setSlideShowType(show_type)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปิดตัวเลือกการแสดง**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setLoop) กำหนดว่าการแสดงสไลด์ควรทำซ้ำเป็นลูปจนกว่าจะหยุดด้วยมือหรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setShowNarration) กำหนดว่าจะเล่นการบรรยายเสียงระหว่างการแสดงสไลด์หรือไม่ ซึ่งเป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่มีแนวทางเสียงสำหรับผู้ชม. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setShowAnimation) กำหนดว่าจะเล่นแอนิเมชั่นที่เพิ่มในวัตถุสไลด์หรือไม่ ซึ่งช่วยให้แสดงผลภาพครบถ้วนของการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และทำให้การแสดงสไลด์วนลูป.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setLoop(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เลือกสไลด์ที่จะแสดง**

เมธอด [SlideShowSettings.setSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setSlides) ช่วยให้คุณเลือกช่วงของสไลด์ที่จะถูกแสดงในระหว่างการนำเสนอ ซึ่งเป็นประโยชน์เมื่อคุณต้องการแสดงเฉพาะส่วนของการนำเสนอแทนที่จะเป็นสไลด์ทั้งหมด ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอที่มีสไลด์ 9 แผ่นและเลือกสไลด์ที่ 2 ถึง 9 โดยใช้หมายเลขสไลด์แบบเริ่มจาก 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # สร้างสไลด์จำนวนเก้าแผ่นเพื่อให้ช่วงที่เลือกมีอยู่.
    first_slide = presentation.getSlides().get_Item(0)
    for _ in range(8):
        presentation.getSlides().addClone(first_slide)

    slide_range = SlidesRange()
    slide_range.setStart(2)
    slide_range.setEnd(9)
    presentation.getSlideShowSettings().setSlides(slide_range)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ควบคุมการเลื่อนสไลด์**

เมธอด [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setUseTimings) ช่วยให้คุณเปิดหรือปิดการใช้การกำหนดเวลาที่ตั้งล่วงหน้าสำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติที่มีระยะเวลาแสดงที่กำหนดไว้ ตัวอย่างโค้ดด้านล่างสร้างการนำเสนอใหม่และปิดการใช้การกำหนดเวลา.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setUseTimings(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แสดงการควบคุมสื่อ**

เมธอด [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) กำหนดว่าจะต้องแสดงการควบคุมสื่อ (เช่น เล่น, หยุด, หยุดชั่วคราว) ระหว่างการแสดงสไลด์เมื่อมีการเล่นเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) หรือไม่ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้นำเสนอควบคุมการเล่นสื่อระหว่างการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างการนำเสนอใหม่และเปิดการแสดงการควบคุมสื่อ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlideShowSettings().setShowMediaControls(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกการนำเสนอให้เปิดโดยตรงในโหมดการแสดงสไลด์ได้หรือไม่?**

ได้. บันทึกไฟล์เป็นรูปแบบ PPSX หรือ PPSM; รูปแบบเหล่านี้จะเปิดโดยตรงในโหมดการแสดงสไลด์เมื่อเปิดใน PowerPoint. ใน Aspose.Slides ให้เลือกรูปแบบการบันทึกที่สอดคล้องกัน [ระหว่างการส่งออก](/slides/th/python-java/save-presentation/).

**ฉันสามารถยกเว้นสไลด์แต่ละอันจากการแสดงโดยไม่ลบออกจากไฟล์ได้หรือไม่?**

ได้. ทำเครื่องหมายสไลด์เป็น [hidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#setHidden). สไลด์ที่ซ่อนอยู่จะยังคงอยู่ในการนำเสนอแต่จะไม่แสดงระหว่างการแสดงสไลด์.

**Aspose.Slides สามารถเล่นการแสดงสไลด์หรือควบคุมการนำเสนอแบบสดบนหน้าจอได้หรือไม่?**

ไม่ได้. Aspose.Slides ทำการแก้ไข วิเคราะห์ และแปลงไฟล์การนำเสนอ; การเล่นจริงจะดำเนินการโดยแอปพลิเคชันผู้ชมเช่น PowerPoint.