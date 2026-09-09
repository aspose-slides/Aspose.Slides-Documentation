---
title: จัดการการแสดงสไลด์ใน Python ผ่าน Java
linktitle: การแสดงสไลด์
type: docs
weight: 90
url: /th/python-java/manage-slide-show/
keywords:
- ประเภทการแสดง
- นำเสนอโดยผู้พูด
- เรียกดูโดยบุคคล
- เรียกดูที่คีออส
- ตัวเลือกการแสดง
- วนซ้ำอย่างต่อเนื่อง
- แสดงโดยไม่มีคำบรรยาย
- แสดงโดยไม่มีแอนิเมชัน
- สีปากกา
- แสดงสไลด์
- การแสดงที่กำหนดเอง
- เลื่อนสไลด์
- ด้วยตนเอง
- ใช้เวลา
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีจัดการการแสดงสไลด์ใน Aspose.Slides สำหรับ Python ผ่าน Java. ควบคุมการเปลี่ยนสไลด์, เวลาและอื่น ๆ อีกมากในรูปแบบ PPT, PPTX และ ODP อย่างง่ายดาย."
---
## **บทนำ**

ตัวเลือก **Set Up Show** ของ Microsoft PowerPoint ให้คุณเลือกประเภทการแสดง, เปิดการวนซ้ำ, เลือกสไลด์, และควบคุมการเปลี่ยนสไลด์. ด้วย Aspose.Slides for Python via Java คุณสามารถกำหนดค่าตัวเลือกเหล่านี้ด้วยโปรแกรมและบันทึกลงในไฟล์งานนำเสนอ.

เมธอด [Presentation.getSlideShowSettings](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlideShowSettings) จะคืนค่าอ็อบเจกต์ [SlideShowSettings](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/) ที่ควบคุมตัวเลือกเหล่านี้ ตัวอย่างด้านล่างต้องใช้ Aspose.Slides for Python via Java และ Runtime ของ Java ที่เข้ากันได้ แต่ละตัวอย่างจะเริ่ม JVM หากจำเป็นและจะปล่อยการใช้งานงานนำเสนอเมื่อเสร็จสิ้น.

## **เลือกประเภทการแสดง**

[SlideShowSettings.setSlideShowType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setSlideShowType) กำหนดประเภทของการแสดงสไลด์ ซึ่งอาจเป็นอินสแตนซ์ของคลาสต่อไปนี้: [PresentedBySpeaker](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentedbyspeaker/), [BrowsedByIndividual](https://reference.aspose.com/slides/th/python-java/aspose.slides/browsedbyindividual/), หรือ [BrowsedAtKiosk](https://reference.aspose.com/slides/th/python-java/aspose.slides/browsedatkiosk/). การใช้เมธอดนี้ช่วยให้คุณปรับงานนำเสนอให้เหมาะกับสถานการณ์การใช้งานต่าง ๆ เช่น คีออสอัตโนมัติหรือการนำเสนอด้วยมือ.

ตัวอย่างโค้ดด้านล่างสร้างงานนำเสนอใหม่และตั้งประเภทการแสดงเป็น “Browsed by an individual” โดยไม่แสดงแถบเลื่อน.

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

## **เปิดใช้งานตัวเลือกการแสดง**

[SlideShowSettings.setLoop](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setLoop) กำหนดว่าการแสดงสไลด์จะทำซ้ำในลูปจนกว่าจะหยุดด้วยตนเองหรือไม่ สิ่งนี้เป็นประโยชน์สำหรับการนำเสนออัตโนมัติที่ต้องทำงานต่อเนื่อง. [SlideShowSettings.setShowNarration](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setShowNarration) กำหนดว่าจะเล่นคำบรรยายเสียงระหว่างการแสดงสไลด์หรือไม่ ซึ่งมีประโยชน์สำหรับการนำเสนออัตโนมัติที่มีคำแนะนำเสียงสำหรับผู้ชม. [SlideShowSettings.setShowAnimation](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setShowAnimation) กำหนดว่าจะเล่นแอนิเมชันที่เพิ่มลงในวัตถุสไลด์หรือไม่ ซึ่งช่วยให้ได้เอฟเฟกต์ภาพเต็มรูปแบบของการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างงานนำเสนอใหม่และทำให้การแสดงสไลด์วนซ้ำ.

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

เมธอด [SlideShowSettings.setSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setSlides) ช่วยให้คุณเลือกช่วงของสไลด์ที่จะนำเสนอในระหว่างการนำเสนอ ซึ่งเป็นประโยชน์เมื่อคุณต้องการแสดงเฉพาะบางส่วนของการนำเสนอแทนที่จะแสดงทุกสไลด์ ตัวอย่างโค้ดต่อไปนี้สร้างงานนำเสนอที่มีสไลด์จำนวน 9 แผ่นและเลือกสไลด์ที่ 2 ถึง 9 โดยใช้เลขสไลด์เริ่มจาก 1.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlidesRange

presentation = Presentation()
try:
    # สร้างสไลด์จำนวนเก้าแผ่นเพื่อให้ช่วงที่เลือกมีอยู่
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

## **ควบคุมการเปลี่ยนสไลด์**

เมธอด [SlideShowSettings.setUseTimings](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setUseTimings) ให้คุณเปิดหรือปิดการใช้เวลา preset สำหรับแต่ละสไลด์ ซึ่งเป็นประโยชน์สำหรับการแสดงสไลด์โดยอัตโนมัติที่มีระยะเวลาการแสดงที่กำหนดไว้ล่วงหน้า ตัวอย่างโค้ดด้านล่างสร้างงานนำเสนอใหม่และปิดการใช้เวลา.

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

เมธอด [SlideShowSettings.setShowMediaControls](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowsettings/#setShowMediaControls) กำหนดว่าการควบคุมสื่อ (เช่น เล่น, หยุดชั่วคราว, และหยุด) ควรแสดงในระหว่างการแสดงสไลด์เมื่อมีการเล่นเนื้อหามัลติมีเดีย (เช่น วิดีโอหรือเสียง) หรือไม่ ซึ่งเป็นประโยชน์เมื่อคุณต้องการให้ผู้พรีเซนเทเตอร์ควบคุมการเล่นสื่อระหว่างการนำเสนอ.

ตัวอย่างโค้ดต่อไปนี้สร้างงานนำเสนอใหม่และเปิดการแสดงการควบคุมสื่อ.

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

**ฉันสามารถบันทึกงานนำเสนอให้เปิดโดยตรงในโหมดการแสดงสไลด์ได้ไหม?**

ได้. บันทึกไฟล์เป็นรูปแบบ PPSX หรือ PPSM; รูปแบบเหล่านี้จะเปิดโดยตรงในโหมดการแสดงสไลด์เมื่อเปิดใน PowerPoint. ใน Aspose.Slides ให้เลือกรูปแบบการบันทึกที่สอดคล้องกัน [ระหว่างการส่งออก](/slides/th/python-java/save-presentation/).

**ฉันสามารถยกเว้นสไลด์เดี่ยวจากการแสดงโดยไม่ลบออกจากไฟล์ได้ไหม?**

ได้. ทำเครื่องหมายสไลด์ว่าเป็น [hidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#setHidden). สไลด์ที่ซ่อนไว้จะยังคงอยู่ในงานนำเสนอแต่จะไม่แสดงในระหว่างการแสดงสไลด์.

**Aspose.Slides สามารถเล่นการแสดงสไลด์หรือควบคุมการนำเสนอสดบนหน้าจอได้ไหม?**

ไม่ได้. Aspose.Slides ทำการแก้ไข, วิเคราะห์, และแปลงไฟล์งานนำเสนอ; การเล่นจริงจะถูกจัดการโดยแอปพลิเคชันดูไฟล์เช่น PowerPoint.