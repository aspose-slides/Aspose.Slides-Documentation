---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint ด้วย Python
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/python-java/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ประเภทเค้าโครง
- คุณสมบัติซ่อน
- แผนภูมิองค์กร
- แผนภูมิองค์กรแบบรูปภาพ
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java ด้วยตัวอย่างโค้ดที่ชัดเจนซึ่งช่วยเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ."
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด รูปร่างของโหนด และเค้าโครง ด้วย Aspose.Slides สำหรับ Python ผ่าน Java คุณสามารถสร้าง SmartArt อ่านข้อความจากโหนดของมัน เปลี่ยนเค้าโครง ตรวจสอบโหนดที่ซ่อนอยู่ ตั้งค่าเค้าโครงแผนภูมิองค์กร และสร้างแผนภูมิองค์กรแบบรูปภาพได้

## **ดึงข้อความจากอ็อบเจ็กต์ SmartArt**

โหนด SmartArt สามารถมีรูปทรงหนึ่งหรือหลายรูปทรงได้ เพื่ออ่านข้อความที่มองเห็นได้ ให้วนลูปผ่าน [SmartArt.getAllNodes](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/#getAllNodes) จากนั้นอ่าน [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ที่ได้จาก [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartshape/#getTextFrame)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, SmartArt):
        smart_art = shape

        for node in smart_art.getAllNodes():
            for node_shape in node.getShapes():
                if node_shape.getTextFrame() is not None:
                    print(node_shape.getTextFrame().getText())
finally:
    presentation.dispose()
```

## **เปลี่ยนประเภทเค้าโครงของอ็อบเจ็กต์ SmartArt**

เค้าโครง SmartArt ควบคุมว่าจัดเรียงและเชื่อมต่อโหนดอย่างไร ตัวอย่างต่อไปนี้สร้างอ็อบเจ็กต์ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList` แล้วเปลี่ยนเป็นค่า `BasicProcess` และบันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)

    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจสอบว่าโหนด SmartArt ถูกซ่อนไว้หรือไม่**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#isHidden) ระบุว่าโหนดถูกซ่อนไว้ในโมเดลข้อมูล SmartArt หรือไม่ โหนดที่ซ่อนได้อาจมีอยู่ในโครงสร้างแม้ว่าเค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้

ตัวอย่างต่อไปนี้เพิ่มโหนดให้กับอ็อบเจ็กต์ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)

    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **รับหรือกำหนดเค้าโครงแผนภูมิองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เค้าโครงแผนภูมิองค์กร [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) และ [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) กำหนดวิธีการจัดเรียงโหนดลูกภายใต้โหนดแม่ ตัวอย่างเช่น คุณสามารถตั้งค่าให้โหนดลูกห้อยจากด้านซ้าย ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับ [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/organizationchartlayouttype/) ที่เลือก

ตัวอย่างต่อไปนี้สร้างแผนภูมิองค์กรและตั้งค่าเค้าโครงสำหรับโหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)

    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สร้างแผนภูมิองค์กรแบบรูปภาพ**

แผนภูมิองค์กรแบบรูปภาพเป็นเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนผังลำดับขั้นที่มีช่องว่างสำหรับรูปภาพ ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อต้องการเพิ่มอ็อบเจ็กต์ SmartArt ลงในสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับด้านสำหรับภาษาขวามือซ้าย (RTL) หรือไม่?**  
ใช่ เมธอด [SmartArt.setReversed](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/#setReversed) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย หรือกลับกัน เมื่อเค้าโครง SmartArt ที่เลือกรองรับการกลับทิศ

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังงานนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**  
คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/python-java/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addClone) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/python-java/clone-slides/) ที่มี SmartArt ทั้งหมด วิธีการทั้งสองจะคงขนาด ตำแหน่ง และรูปแบบไว้

**ฉันจะเรนเดอร์ SmartArt เป็นภาพเรสเตอร์สำหรับการพรีวิวหรือส่งออกเว็บได้อย่างไร?**  
[เรนเดอร์สไลด์](/slides/th/python-java/convert-powerpoint-to-png/) หรือการนำเสนอทั้งหมดเป็น PNG หรือ JPEG SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์

**ฉันจะหาวัตถุ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอัน?**  
ตั้งค่าข้อความแทนที่หรือชื่อที่แตกต่างกันโดยใช้ [Shape.getAlternativeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getAlternativeText) หรือ [Shape.getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getName) บนรูปร่าง SmartArt แล้วค้นหาค่าดังกล่าวใน [BaseSlide.getShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getShapes) จากนั้นตรวจสอบว่ารูปร่างที่พบตรงกับ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/)