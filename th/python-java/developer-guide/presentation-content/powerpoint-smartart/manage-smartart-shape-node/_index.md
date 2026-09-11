---
title: จัดการโหนดรูปทรง SmartArt ในงานนำเสนอด้วย Python
linktitle: โหนดรูปทรง SmartArt
type: docs
weight: 30
url: /th/python-java/manage-smartart-shape-node/
keywords:
- โหนด SmartArt
- โหนดลูก
- เพิ่มโหนด
- ตำแหน่งโหนด
- เข้าถึงโหนด
- ลบโหนด
- ตำแหน่งกำหนดเอง
- โหนดผู้ช่วย
- รูปแบบการเติม
- เรนเดอร์โหนด
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "จัดการโหนดรูปทรง SmartArt ในไฟล์ PPT และ PPTX ด้วย Aspose.Slides สำหรับ Python via Java. รับตัวอย่างโค้ดที่ชัดเจนและคำแนะนำเพื่อทำให้งานนำเสนอของคุณเป็นระเบียบง่ายขึ้น."
---
## **ภาพรวม**

กราฟิก SmartArt ในงานนำเสนอ PowerPoint จะถูกจัดระเบียบผ่านโหนดที่มีข้อความและกำหนดโครงสร้างของไดอะแกรม Aspose.Slides ให้คุณทำงานกับโหนด SmartArt นี้ได้โดยโปรแกรม: เพิ่มโหนดและโหนดลูกใหม่, แทรกโหนดลูกในตำแหน่งที่ระบุ, เข้าถึงโหนดที่มีอยู่, และอ่านข้อความ, ระดับ, และตำแหน่งของโหนด

บทความนี้อธิบายวิธีจัดการโหนดรูปทรง SmartArt จะแสดงวิธีการลบโหนด, ทำงานกับโหนดลูกโดยดัชนีหรือสถานที่, เปลี่ยนโหนดผู้ช่วยเป็นโหนดปกติ, ปรับตำแหน่ง, ขนาด, และการหมุนของโหนด SmartArt, ตั้งค่ารูปแบบการเติมของโหนด, และสร้างภาพย่อสำหรับโหนดลูกของ SmartArt

## **เพิ่มโหนด SmartArt**
Aspose.Slides for Python via Java มี API สำหรับจัดการรูปทรง SmartArt ตัวอย่างต่อไปนี้เพิ่มโหนดและโหนดลูกลงในรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. ดึงสไลด์แรกตามดัชนี
1. วนซ้ำผ่านรูปทรงทั้งหมดบนสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่
1. [Add a new node](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnodecollection/#addNode) ไปยัง [node collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/#getAllNodes) ของรูปทรง SmartArt และกำหนดข้อความผ่าน [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/)
1. [Add](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnodecollection/#addNode) [child node](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#getChildNodes) ไปยังโหนดใหม่และกำหนดข้อความผ่าน [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/)
1. บันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("SimpleSmartArt.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            node = smart_art.getAllNodes().addNode()
            node.getTextFrame().setText("Test")
            child_node = node.getChildNodes().addNode()
            child_node.getTextFrame().setText("New Node Added")
    presentation.save("AddSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เพิ่มโหนด SmartArt ที่ตำแหน่งเฉพาะ**
ตัวอย่างต่อไปนี้เพิ่มโหนดลูกที่ตำแหน่งเฉพาะในโหนด SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. ดึงสไลด์แรกตามดัชนี
1. เพิ่มรูปทรง [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) ด้วยเค้าโครง [StackedList](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartlayouttype/#StackedList) ลงบนสไลด์
1. เข้าถึงโหนดแรกในรูปทรง SmartArt ที่เพิ่มไว้
1. เพิ่มโหนดลูกที่ตำแหน่ง 2 โดยใช้ [addNodeByPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnodecollection/#addNodeByPosition) และกำหนดข้อความ
1. บันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    child_node = node.getChildNodes().addNodeByPosition(2)
    child_node.getTextFrame().setText("Sample Text Added")
    presentation.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึงโหนด SmartArt**
ตัวอย่างต่อไปนี้เข้าถึงโหนดในรูปทรง SmartArt รูปแบบที่คืนค่าจาก [getLayout](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/#getLayout) คือแบบอ่านอย่างเดียวและถูกกำหนดเมื่อเพิ่มรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. ดึงสไลด์แรกตามดัชนี
1. วนซ้ำผ่านรูปทรงทั้งหมดบนสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่
1. วนซ้ำผ่าน [nodes](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/#getAllNodes) ทั้งหมดในรูปทรง SmartArt
1. อ่านและแสดงตำแหน่ง, ระดับ, และข้อความของแต่ละโหนด SmartArt

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("SmartArtShape.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                print(node.getTextFrame().getText(), " ", node.getLevel(), " ", node.getPosition())
finally:
    presentation.dispose()
```

## **เข้าถึงโหนดลูกของ SmartArt**
ตัวอย่างต่อไปนี้เข้าถึงโหนดลูกของแต่ละโหนดในรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. ดึงสไลด์แรกตามดัชนี
1. วนซ้ำผ่านรูปทรงทั้งหมดบนสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่
1. วนซ้ำผ่าน [nodes](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/#getAllNodes) ทั้งหมดในรูปทรง SmartArt
1. สำหรับแต่ละโหนด, วนซ้ำผ่าน [child nodes](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#getChildNodes)
1. อ่านและแสดงตำแหน่ง, ระดับ, และข้อความของ [child node](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#getChildNodes)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessChildNodes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                parent_node = smart_art.getAllNodes().get_Item(i)
                for j in range(parent_node.getChildNodes().size()):
                    node = parent_node.getChildNodes().get_Item(j)
                    print("j = ", j, ", Text = ", node.getTextFrame().getText(), ",  Level = ", node.getLevel(), ", Position = ", node.getPosition())
finally:
    presentation.dispose()
```

## **เข้าถึงโหนดลูกของ SmartArt ที่ตำแหน่งเฉพาะ**
ตัวอย่างต่อไปนี้เข้าถึงโหนดลูกที่ดัชนีเฉพาะในคอลเลกชันของโหนดแม่

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. ดึงสไลด์แรกตามดัชนี
1. เพิ่มรูปทรง SmartArt ด้วยเค้าโครง [StackedList](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartlayouttype/#StackedList)
1. เข้าถึงรูปทรง SmartArt ที่เพิ่มไว้
1. เข้าถึงโหนดที่ดัชนี 0 ในรูปทรง SmartArt
1. เข้าถึงโหนดลูกที่ดัชนี 1 โดยใช้ [get_Item](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnodecollection/#get_Item)
1. อ่านและแสดงตำแหน่ง, ระดับ, และข้อความของ [child node](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#getChildNodes)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList)
    node = smart_art.getAllNodes().get_Item(0)
    position = 1
    child_node = node.getChildNodes().get_Item(position)
    print("Text = ", child_node.getTextFrame().getText(), ",  Level = ", child_node.getLevel(), ", Position = ", child_node.getPosition())
finally:
    presentation.dispose()
```

## **ลบโหนด SmartArt**
ตัวอย่างต่อไปนี้ลบโหนดจากรูปทรง SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. ดึงสไลด์แรกตามดัชนี
1. วนซ้ำผ่านรูปทรงทั้งหมดบนสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่
1. ตรวจสอบว่ารูปทรง [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) มีอย่างน้อยหนึ่งโหนด
1. เลือกโหนด SmartArt ที่จะลบ
1. ลบโหนดที่เลือกโดยใช้ [removeNode](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnodecollection/#removeNode)
1. บันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                smart_art.getAllNodes().removeNode(node)
    presentation.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ลบโหนด SmartArt จากตำแหน่งเฉพาะ**
ตัวอย่างต่อไปนี้ลบโหนดลูกที่ดัชนีเฉพาะในคอลเลกชันของโหนด SmartArt

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. ดึงสไลด์แรกตามดัชนี
1. วนซ้ำผ่านรูปทรงทั้งหมดบนสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่
1. เข้าถึงโหนด SmartArt ที่ดัชนี 0 หากมี
1. ตรวจสอบว่าโหนด SmartArt ที่เลือกมีอย่างน้อยสองโหนดลูก
1. ลบโหนดลูกที่ดัชนี 1 โดยใช้ [removeNode](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnodecollection/#removeNode)
1. บันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddSmartArtNode.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            if smart_art.getAllNodes().size() > 0:
                node = smart_art.getAllNodes().get_Item(0)
                if node.getChildNodes().size() >= 2:
                    node.getChildNodes().removeNode(1)
    presentation.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตั้งค่าตำแหน่งกำหนดเองสำหรับโหนดลูกในวัตถุ SmartArt**
Aspose.Slides for Python via Java รองรับการตั้งค่าตำแหน่งของ [SmartArtShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartshape/) ด้วย [setX](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setX) และ [setY](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setY) ตัวอย่างต่อไปนี้ตั้งค่าตำแหน่ง, ขนาด, และการหมุนที่กำหนดเองสำหรับรูปร่างโหนด SmartArt การเพิ่มโหนดใหม่จะคำนวณตำแหน่งและขนาดของโหนดทั้งหมดใหม่ การกำหนดตำแหน่งแบบกำหนดเองช่วยให้คุณจัดเรียงโหนดตามที่ต้องการ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart)
    node = smart_art.getAllNodes().get_Item(1)
    shape = node.getShapes().get_Item(1)
    shape.setX(shape.getX() + shape.getWidth() * 2)
    shape.setY(shape.getY() - shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(2)
    shape = node.getShapes().get_Item(1)
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2)
    node = smart_art.getAllNodes().get_Item(3)
    shape = node.getShapes().get_Item(1)
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2)
    node = smart_art.getAllNodes().get_Item(4)
    shape = node.getShapes().get_Item(1)
    shape.setRotation(90)
    presentation.save("SmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจสอบโหนดผู้ช่วย**
{{% alert color="info" title="Note" %}} 

ส่วนนี้สำรวจรูปทรง SmartArt ที่เพิ่มลงในสไลด์งานนำเสนอโดยโปรแกรมด้วย Aspose.Slides for Python via Java.

{{% /alert %}} 

รูปทรง SmartArt ต้นแบบต่อไปนี้ใช้ในตัวอย่าง

|![SmartArt shape](https://i.imgur.com/FItwczY.png)|
| :- |
|**รูปภาพ: รูปทรง SmartArt ต้นแบบบนสไลด์**|

ตัวอย่างต่อไปนี้ระบุโหนดผู้ช่วยในคอลเลกชันโหนด SmartArt และเปลี่ยนเป็นโหนดปกติ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และโหลดงานนำเสนอที่มีรูปทรง SmartArt
1. ดึงสไลด์แรกตามดัชนี
1. วนซ้ำผ่านรูปทรงทั้งหมดบนสไลด์แรก
1. ตรวจสอบว่ารูปทรงเป็นอินสแตนซ์ของ [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) หรือไม่
1. วนซ้ำผ่านโหนดทั้งหมดในรูปทรง SmartArt และตรวจสอบว่าเป็น [Assistant Nodes](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/#isAssistant) หรือไม่
1. เปลี่ยนแต่ละโหนดผู้ช่วยให้เป็นโหนดปกติ
1. บันทึกงานนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt

presentation = Presentation("AddNodes.pptx")
try:
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            for i in range(smart_art.getAllNodes().size()):
                node = smart_art.getAllNodes().get_Item(i)
                if node.isAssistant():
                    node.setAssistant(False)
    presentation.save("ChangeAssistantNode.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**รูปภาพ: โหนดผู้ช่วยที่เปลี่ยนในรูปทรง SmartArt บนสไลด์**|

## **ตั้งค่ารูปแบบการเติมของโหนด**
Aspose.Slides for Python via Java ทำให้สามารถเพิ่มรูปทรง SmartArt ที่กำหนดเองและตั้งค่ารูปแบบการเติมของมันได้ บทความนี้อธิบายวิธีสร้างและเข้าถึงรูปทรง SmartArt และตั้งค่ารูปแบบการเติมโดยใช้ Aspose.Slides for Python via Java

โปรดทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. ดึงสไลด์ตามดัชนี
1. เพิ่มรูปทรง [SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) ด้วยเค้าโครง [ClosedChevronProcess](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartlayouttype/#ClosedChevronProcess)
1. ตั้งค่า [FillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getFillFormat) สำหรับโหนดรูปทรง SmartArt
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess)
    node = chevron.getAllNodes().addNode()
    node.getTextFrame().setText("Some text")
    for item in node.getShapes():
        item.getFillFormat().setFillType(FillType.Solid)
        item.getFillFormat().getSolidFillColor().setColor(Color.RED)
    presentation.save("TestSmart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สร้างภาพย่อของโหนดลูก SmartArt**
เพื่อสร้างภาพย่อของโหนดลูก SmartArt ให้ทำตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. [Add a SmartArt shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addSmartArt)
1. ดึงโหนดตามดัชนี
1. ดึงภาพย่อ
1. บันทึกภาพย่อในรูปแบบภาพใด ๆ ที่ต้องการ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArtLayoutType, ImageFormat

presentation = Presentation()
try:
    smart_art = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle)
    node = smart_art.getNodes().get_Item(1)
    image = node.getShapes().get_Item(0).getImage()
    try:
        image.save("SmartArt_ChildNode_Thumbnail.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**SmartArt animation รองรับหรือไม่?**

ใช่ SmartArt ถูกพิจารณาเป็นรูปทรงทั่วไป ดังนั้นคุณสามารถ [apply standard animations](/slides/th/python-java/shape-animation/) (การเข้ามา, การออก, การเน้น, เส้นทางการเคลื่อนที่) และปรับเวลาได้ คุณยังสามารถทำแอนิเมชันให้กับรูปทรงภายในโหนด SmartArt เมื่อจำเป็น

**ฉันจะค้นหา SmartArt ที่เฉพาะเจาะจงบนสไลด์ได้อย่างไรหากไม่รู้ค่า ID ภายใน?**

กำหนดและค้นหาโดยใช้ [alternative text](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getAlternativeText) การตั้งค่าข้อความแทนที่โดดเด่นบน SmartArt จะทำให้คุณหามันได้โดยโปรแกรมโดยไม่ต้องพึ่งพาตัวระบุภายใน

**ลักษณะของ SmartArt จะคงเดิมเมื่อแปลงงานนำเสนอเป็น PDF หรือไม่?**

ใช่ Aspose.Slides จะเรนเดอร์ SmartArt ด้วยความแม่นยำสูงระหว่างการ [PDF export](/slides/th/python-java/convert-powerpoint-to-pdf/) คงรูปแบบ, สี, และเอฟเฟกต์

**ฉันสามารถดึงภาพของ SmartArt ทั้งหมด (สำหรับตัวอย่างหรือรายงาน) ได้หรือไม่?**

ใช่ คุณสามารถเรนเดอร์รูปทรง SmartArt เป็น [raster formats](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getImage) หรือเป็น [SVG](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#writeAsSvgToBytes) สำหรับเอาต์พุตเวกเตอร์ที่ปรับขนาดได้ ทำให้เหมาะสำหรับภาพย่อ, รายงาน, หรือการใช้งานบนเว็บ