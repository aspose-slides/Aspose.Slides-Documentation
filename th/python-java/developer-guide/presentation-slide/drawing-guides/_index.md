---
title: จัดการ Drawing Guides ในการนำเสนอด้วย Python
linktitle: แนวทางการวาด
type: docs
weight: 85
url: /th/python-java/drawing-guides/
keywords:
- แนวทางการวาด
- แนวทางแนวนอน
- แนวทางแนวตั้ง
- แนวทางการจัดตำแหน่ง
- มุมมองสไลด์
- มาสเตอร์สไลด์
- เลย์เอาต์สไลด์
- โน้ตมาสเตอร์
- มาสเตอร์เอกสารแจก
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม, เข้าถึง และลบแนวทางการวาดแนวนอนและแนวตั้งในพรีเซนเทชัน PowerPoint โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Drawing guides คือเส้นแนวนอนและแนวตั้งที่ปรับได้ซึ่งช่วยให้ผู้ใช้จัดตำแหน่งรูปร่างได้อย่างสม่ำเสมอขณะแก้ไขพรีเซนเทชันใน PowerPoint ซึ่งเป็นประโยชน์อย่างยิ่งเมื่อแอปพลิเคชันสร้างพรีเซนเทชันแล้วต้องการปรับแต่งด้วยตนเองต่อไป: แอปพลิเคชันสามารถบันทึกเครื่องมือช่วยจัดตำแหน่งเดียวกันที่ผู้เขียนควรปฏิบัติตามเมื่อเพิ่มหรือย้ายเนื้อหา

Drawing guides เป็นเครื่องมือช่วยแก้ไข ไม่ใช่เนื้อหาของสไลด์ พวกมันไม่ปรากฏในการนำเสนอหรือผลลัพธ์ที่เรนเดอร์ Aspose.Slides for Python via Java ทำให้เข้าถึงได้ผ่านคลาส [DrawingGuidesCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguidescollection/) Guide หนึ่งตัวแทนโดย [DrawingGuide](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguide/) และมีการกำหนดทิศทาง ตำแหน่ง และสี

ตำแหน่งจะวัดเป็นพอยต์จากมุมซ้าย‑บนของสไลด์หรือมาสเตอร์ที่เกี่ยวข้อง Guide แนวตั้งใช้ค่าพิกัดแนวนอน ซึ่งโดยทั่วไปอยู่ระหว่างศูนย์ถึงความกว้างของสไลด์ Guide แนวนอนใช้ค่าพิกัดแนวตั้ง ซึ่งโดยทั่วไปอยู่ระหว่างศูนย์ถึงความสูงของสไลด์

## **เพิ่ม Guide ไปยังมุมมองสไลด์**

ใช้ [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/th/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) เพื่อจัดการ Guide ที่แสดงขณะแก้ไขสไลด์ปกติ เรียก [DrawingGuidesCollection.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguidescollection/#add) พร้อมค่าของ [Orientation](https://reference.aspose.com/slides/th/python-java/aspose.slides/orientation/) และตำแหน่งเป็นพอยต์

ตัวอย่างต่อไปนี้เพิ่ม Guide แนวตั้งหนึ่งเส้นทางขวาของศูนย์สไลด์และ Guide แนวนอนหนึ่งเส้นด้านล่างศูนย์สไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึง Drawing Guides**

เมธอด [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguidescollection/#getCount) และ [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguidescollection/#get_Item) ให้เข้าถึง Guide ที่มีอยู่ เมธอด [DrawingGuide.getOrientation](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguide/#getPosition), และ [DrawingGuide.getColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguide/#getColor) คืนค่าที่สามารถเปลี่ยนได้ผ่านเมธอด setter ที่สอดคล้องกัน

ตัวอย่างต่อไปนี้อ่าน Guide ของมุมมองสไลด์จากพรีเซนเทชันที่สร้างไว้ข้างต้น:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **เพิ่ม Guide ไปยัง Master และ Layout Slides**

มาสเตอร์สไลด์และแต่ละ Layout Slide สามารถมีคอลเลกชัน Drawing‑guide ของตนเอง ใช้ [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterslide/#getDrawingGuides) สำหรับมาสเตอร์สไลด์และ [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/python-java/aspose.slides/layoutslide/#getDrawingGuides) สำหรับ Layout Slide

ตัวอย่างต่อไปนี้เพิ่ม Guide แนวตั้งหนึ่งเส้นในมาสเตอร์สไลด์แรกและ Guide แนวนอนหนึ่งเส้นใน Layout Slide แรก:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่ม Guide ไปยัง Notes และ Handout Masters**

Notes Master และ Handout Master ก็รองรับ Drawing Guides ให้ใช้ [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/th/python-java/aspose.slides/masternotesslide/#getDrawingGuides) และ [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/th/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) เพื่อเข้าถึงคอลเลกชันของพวกเขา หากพรีเซนเทชันไม่มีมาสเตอร์เหล่านี้ `MasterNotesSlideManager.setDefaultMasterNotesSlide` หรือ `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` จะสร้างมาสเตอร์เริ่มต้นและคืนค่าให้

ตัวอย่างต่อไปนี้เพิ่ม Guide แนวนอนหนึ่งเส้นใน Notes Master และ Guide แนวตั้งหนึ่งเส้นใน Handout Master:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบ Drawing Guides**

เรียก [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguidescollection/#clear) เพื่อลบ Guide ทุกเส้นจากคอลเลกชันที่ระบุ การลบจากคอลเลกชันหนึ่งไม่ได้ส่งผลต่อ Guide ที่เก็บอยู่ในสโคปอื่น

ตัวอย่างต่อไปนี้ลบ Guide ของมุมมองสไลด์และ Guide ทั้งหมดบน Slide Masters, Layout Slides, Notes Master, และ Handout Master โดยไม่สร้างมาสเตอร์ที่ขาดหาย:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**Drawing guides ปรากฏในการนำเสนอหรือภาพที่ส่งออกหรือไม่?**

ไม่ปรากฏ Drawing guides เป็นเครื่องมือช่วยจัดตำแหน่งสำหรับการแก้ไขและไม่ถูกเรนเดอร์เป็นเนื้อหาของพรีเซนเทชัน

**สามารถเพิ่ม Drawing guide ลงในสไลด์ปกติแต่ละสไลด์ได้โดยตรงหรือไม่?**

Guide สำหรับการแก้ไขสไลด์ปกติถูกเก็บในคุณสมบัติของมุมมองสไลด์ของพรีเซนเทชัน คอลเลกชัน Guide แยกต่างหากมีให้สำหรับ Slide Masters, Layout Slides, Notes Masters, และ Handout Masters

**หน่วยใดใช้สำหรับตำแหน่งของ Guide?**

ตำแหน่งระบุเป็นพอยต์ ซึ่ง 72 พอยต์เท่ากับหนึ่งนิ้ว ตำแหน่งแนวตั้งวัดจากขอบซ้าย และตำแหน่งแนวนอนวัดจากขอบบน

**การลบ Drawing guides จะลบรูปร่างหรือเปลี่ยนแปลงเนื้อหาสไลด์หรือไม่?**

ไม่ การเรียกใช้เมธอด [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/drawingguidescollection/#clear) จะลบเฉพาะ Guide ในคอลเลกชันที่เลือก รูปร่างและเนื้อหาอื่น ๆ ของสไลด์ยังคงไม่เปลี่ยนแปลง