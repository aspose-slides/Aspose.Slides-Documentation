---
title: จัดการการซูมการนำเสนอใน Python ผ่าน Java
linktitle: จัดการซูม
type: docs
weight: 60
url: /th/python-java/manage-zoom/
keywords:
- ซูม
- กรอบซูม
- ซูมสไลด์
- ซูมส่วน
- ซูมสรุป
- เพิ่มซูม
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างและปรับแต่งซูมด้วย Aspose.Slides สำหรับ Python ผ่าน Java — กระโดดระหว่างส่วน, เพิ่มภาพย่อและการเปลี่ยนภาพในการนำเสนอ PowerPoint."
---
## **บทนำ**

PowerPoint zooms ให้คุณนำทางระหว่างสไลด์และส่วนที่เจาะจงระหว่างการนำเสนอแบบสไลด์โชว์ ด้วย Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถสร้างซูมสไลด์, ซูมส่วน, และซูมสรุป พร้อมปรับแต่งการแสดงตัวอย่าง, เส้นขอบและการเปลี่ยนภาพได้

![ภาพรวม Zoom ของ PowerPoint](overview.png)

* เพื่อสรุปการนำเสนอทั้งหมดบนสไลด์เดียว ให้ใช้ [สรุป Zoom](#summary-zoom)
* เพื่อแสดงสไลด์ที่เลือกเท่านั้น ให้ใช้ [ซูมสไลด์](#slide-zoom)
* เพื่อแสดงส่วนเดียวเท่านั้น ให้ใช้ [ซูมส่วน](#section-zoom)

## **ซูมสไลด์**

ซูมสไลด์สามารถทำให้การนำเสนอของคุณมีความไดนามิกมากขึ้น โดยอนุญาตให้คุณนำทางอย่างอิสระระหว่างสไลด์ในลำดับใดก็ได้โดยไม่ต้องหยุดการไหลของการนำเสนอ ซูมสไลด์เหมาะสำหรับการนำเสนอสั้น ๆ ที่ไม่มีหลายส่วนมาก แต่คุณยังสามารถใช้ในสถานการณ์การนำเสนอที่หลากหลายได้

ซูมสไลด์ช่วยให้คุณสำรวจข้อมูลที่เกี่ยวข้องจากสไลด์ภาพรวมเดียว

![การเลือกสไลด์สำหรับซูมสไลด์](slidezoomsel.png)

สำหรับออบเจ็กต์ซูมสไลด์ Aspose.Slides มีการนับจำนวน [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) , คลาส [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) และเมธอดบนคลาส [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/)

### **สร้างกรอบซูม**

ใช้ [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) เพื่อวางลิงก์ไปยังสไลด์แต่ละสไลด์บนสไลด์ภาพรวม ตัวอย่างนี้สร้างสไลด์เป้าหมายสองสไลด์ที่มีพื้นหลังและป้ายกำกับที่แตกต่างกัน แล้วเพิ่มการแสดงตัวอย่างของแต่ละสไลด์ลงในสไลด์แรกและบันทึกการนำเสนอเป็น PPTX ตำแหน่งและขนาดของกรอบระบุเป็นพอยต์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างกรอบซูมด้วยรูปภาพแบบกำหนดเอง**

ส่งรูปภาพที่กำหนดเองไปยัง [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) เพื่อแทนที่การแสดงตัวอย่างเริ่มต้นของสไลด์เป้าหมาย ตัวอย่างนี้ต้องการรูปภาพในเครื่อง โหลดด้วย [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) และเพิ่มลงในการนำเสนอด้วย [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) กรอบที่ได้จะแสดงรูปภาพนั้นพร้อมกับลิงก์ไปยังสไลด์ที่สอง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **จัดรูปแบบกรอบซูม**

ตัวอย่างนี้ปรับแต่งกรอบซูมสไลด์สองกรอบ มอบรูปภาพในเครื่องให้กับกรอบแรกผ่าน [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) และให้กรอบที่สองมีเส้นขอบสีชมพูแบบ dash‑dot หนา 5 พอยต์ผ่าน [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) การส่งค่า `False` ไปยัง [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) จะซ่อนพื้นหลังของกรอบที่สอง รูปภาพในเครื่องจำเป็นสำหรับการแสดงตัวอย่างแบบกำหนดเอง; ทั้งสองกรอบยังคงรักษาเป้าหมายสไลด์ไว้ในไฟล์ PPTX ที่บันทึก

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ซูมส่วน**

ซูมส่วนเชื่อมโยงไปยังส่วนในการนำเสนอของคุณ ใช้เพื่อกลับมาที่หัวข้อเดิมหรือแสดงว่าตรงส่วนต่าง ๆ ของการนำเสนอเชื่อมต่อกันอย่างไร

![การเลือกส่วนสำหรับซูมส่วน](seczoomsel.png)

สำหรับออบเจ็กต์ซูมส่วน Aspose.Slides มีคลาส [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) และเมธอดบนคลาส [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/)

### **สร้างกรอบซูมส่วน**

สร้างส่วนด้วย [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection) แล้วส่งส่วนที่ได้ให้กับ [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) ตัวอย่างนี้วางซูมส่วนบนสไลด์แรกและลิงก์ไปยังส่วนที่เริ่มด้วยสไลด์สี การกำหนดตำแหน่งและขนาดของกรอบระบุเป็นพอยต์ และบันทึกการนำเสนอเป็น PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สร้างกรอบซูมส่วนด้วยรูปภาพแบบกำหนดเอง**

โอเวอร์โหลดรูปภาพของ [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) ให้คุณแสดงตัวอย่างแบบกำหนดเองโดยไม่เปลี่ยนส่วนปลายทาง ตัวอย่างนี้ต้องการรูปภาพในเครื่อง ซึ่งโหลดด้วย [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) และเพิ่มผ่าน [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) การบันทึกการนำเสนอจะมีซูมส่วนบนสไลด์แรกที่เชื่อมโยงกับส่วนที่สร้างใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **เปลี่ยนส่วนเป้าหมายของซูมส่วน**

ใช้ [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) เพื่อเปลี่ยนเส้นทางของซูมส่วนที่มีอยู่โดยไม่ต้องสร้างใหม่ เลือกส่วนที่เต็มจากคอลเลกชัน [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) ของการนำเสนอเดียวกัน การกำหนดส่วนเปล่าไว้จะไม่เปลี่ยนเป้าหมายปัจจุบัน ดังนั้นควรตรวจสอบ [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) ก่อนกำหนด ดูเพิ่มเติมใน [Manage Slide Sections](/slides/th/python-java/slide-section/)

ตัวอย่างต่อไปโหลดไฟล์การนำเสนอซึ่งต้องมีหลายส่วนที่เต็ม, มีซูมส่วนชื่อ `Section navigation` และมีส่วนที่ชื่อเฉพาะ `Results` มองหาซูมในทุกสไลด์และหาระดับปลายทางตามชื่อไม่ใช่ตามดัชนีคอลเลกชันที่อาจเปลี่ยนเมื่อส่วนถูกจัดลำดับใหม่ หากชื่อไม่เป็นเอกลักษณ์ ให้ใช้ [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) เพื่อระบุปลายทางแทน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **จัดรูปแบบกรอบซูมส่วน**

ตัวอย่างนี้ย้ายและปรับขนาดซูมส่วนเป็น 100 × 75 พอยต์ มอบรูปภาพในเครื่องผ่าน [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) และใช้เส้นขอบสีน้ำตาลแบบ dash‑dot หนา 2.5 พอยต์ เปิดใช้งาน [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) ให้กลับไปสไลด์ต้นฉบับหลังจากส่วนเสร็จ, ปิด [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) และตั้งค่า [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) เป็น 1.5 วินาที รูปภาพในเครื่องจำเป็นสำหรับการแสดงตัวอย่างแบบกำหนดเอง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ซูมสรุป**

ซูมสรุปให้ภาพรวมของส่วนการนำเสนอในระหว่างการสไลด์โชว์ คุณสามารถใช้เพื่อกระโดดไปยังส่วน, ข้ามหน้าต่อไป, หรือกลับมาที่หัวข้อโดยไม่ต้องตามลำดับสไลด์

![การเลือกส่วนสำหรับซูมสรุป](sumzoomsel.png)

สำหรับออบเจ็กต์ซูมสรุป Aspose.Slides มีคลาส [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/), และ [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) รวมถึงเมธอดบนคลาส [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/)

### **สร้างซูมสรุป**

ใช้ [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) เพื่อสร้างภาพรวมของส่วนการนำเสนอ ตัวอย่างนี้สร้างสี่ส่วนที่มีพื้นหลังสไลด์แตกต่างกันและเพิ่มซูมสรุปลงในสไลด์แรก ตำแหน่งและขนาดของกรอบระบุเป็นพอยต์ และบันทึกภาพรวมในไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **เพิ่มและลบส่วนของซูมสรุป**

ซูมสรุปเก็บออบเจ็กต์ [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) ใน [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) ตัวอย่างนี้สร้างภาพรวมของสองส่วน, เพิ่มส่วนที่สามด้วย [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection) และลบรายการของส่วนแรกด้วย [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection) การลบรายการจะทำให้ส่วนการนำเสนอและสไลด์ของมันคงอยู่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **จัดรูปแบบส่วนของซูมสรุป**

ตัวอย่างนี้จัดรูปแบบรายการแรกใน [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection) โดยใช้ดัชนีเริ่มที่ศูนย์ `0` จำเป็นต้องมีรูปภาพในเครื่องสำหรับ [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage) ใช้เส้นขอบสีดำแบบ dash‑dot หนา 1.5 พอยต์ และตั้งค่า [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) เป็น 1.5 วินาที การส่งค่า `False` ไปยัง [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) จะปิดการกลับอัตโนมัติไปยังสไลด์สรุปสำหรับรายการนี้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมการกลับไปสไลด์ 'แม่' หลังจากแสดงเป้าหมายได้ไหม?**

ใช่. เรียกใช้ [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) พร้อมค่า `True` เพื่อกลับไปสไลด์ต้นฉบับหลังจากแสดงเนื้อหาเป้าหมาย

**ฉันสามารถปรับ 'ความเร็ว' หรือระยะเวลาของการเปลี่ยนซูมได้ไหม?**

ใช่. ใช้ [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) เพื่อควบคุมระยะเวลาการเปลี่ยนภาพเป็นวินาที

**มีขีดจำกัดจำนวนออบเจ็กต์ซูมที่การนำเสนอสามารถมีได้หรือไม่?**

ไม่มีขีดจำกัด API ที่ระบุไว้อย่างชัดเจน ขีดจำกัดเชิงปฏิบัติจะแตกต่างไปตามความซับซ้อนของการนำเสนอและประสิทธิภาพของอุปกรณ์ผู้ชม คุณสามารถเพิ่มกรอบซูมได้จำนวนมาก แต่ควรพิจารณาขนาดไฟล์และเวลาในการเรนเดอร์