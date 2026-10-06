---
title: จัดการ SmartArt ในงานนำเสนอ PowerPoint ด้วย Python
linktitle: จัดการ SmartArt
type: docs
weight: 10
url: /th/python-java/manage-smartart/
keywords:
- SmartArt
- ข้อความ SmartArt
- ชนิดเค้าโครง
- คุณสมบัติเช่นซ่อน
- แผนผังองค์กร
- แผนผังองค์กรแบบภาพ
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้การสร้างและแก้ไข SmartArt ของ PowerPoint ด้วย Aspose.Slides สำหรับ Python via Java ด้วยตัวอย่างโค้ดที่ชัดเจนซึ่งเร่งการออกแบบสไลด์และการทำงานอัตโนมัติ"
---
## **ภาพรวม**

SmartArt คือแผนภาพ PowerPoint ที่สร้างจากโหนด, รูปร่างของโหนด, และเค้าโครง. ด้วย Aspose.Slides for Python via Java, คุณสามารถสร้าง SmartArt, อ่านข้อความจากโหนดของมัน, เปลี่ยนเค้าโครง, ตรวจสอบโหนดที่ซ่อน, กำหนดค่าเค้าโครงแผนผังองค์กร, และสร้างแผนผังองค์กรแบบภาพได้.

## **รับข้อความจากวัตถุ SmartArt**

โหนด SmartArt สามารถประกอบด้วยรูปร่างหนึ่งหรือหลายรูปร่างได้. เพื่ออ่านข้อความจากรูปร่างของโหนด, ให้วนลูปผ่าน [SmartArt.getAllNodes](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#getAllNodes), จากนั้นอ่าน [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) ที่ส่งกลับโดย [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/smartartshape/#getTextFrame).

ตัวอย่างต้องการการนำเสนอที่มีอย่างน้อยหนึ่งสไลด์และวัตถุ SmartArt เป็นรูปร่างแรกบนสไลด์นั้น. ตัวอย่างจะพิมพ์แต่ละ TextFrame ที่มีอยู่ไปยังคอนโซล.

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

## **เปลี่ยนประเภทเค้าโครงของวัตถุ SmartArt**

เค้าโครง SmartArt กำหนดว่าค่าโหนดจะจัดเรียงและเชื่อมต่ออย่างไร. ตัวอย่างต่อไปนี้สร้างวัตถุ SmartArt ด้วยค่า [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, เปลี่ยนเป็นค่า `BasicProcess`, และบันทึกการนำเสนอ. ตำแหน่งและขนาดที่ส่งให้กับ [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSmartArt) จะวัดเป็นจุด. ใช้ [SmartArt.setLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setLayout) เพื่อเปลี่ยนเค้าโครง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList)
    smart_art.setLayout(SmartArtLayoutType.BasicProcess)

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ตรวจสอบว่ามีโหนด SmartArt ถูกซ่อนหรือไม่**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#isHidden) ระบุว่าโหนดถูกซ่อนในโมเดลข้อมูลของ SmartArt หรือไม่. โหนดที่ซ่อนสามารถอยู่ในโครงสร้างได้แม้ว่าเค้าโครงที่เลือกจะไม่แสดงเป็นองค์ประกอบแผนภาพที่มองเห็นได้.

ตัวอย่างต่อไปนี้เพิ่มโหนดลงในวัตถุ SmartArt ที่ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `RadialCycle` และตรวจสอบสถานะการซ่อนของโหนดที่เพิ่ม. จะพิมพ์ข้อความหากโหนดถูกซ่อนและบันทึกแผนภาพ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle)
    node = smart_art.getAllNodes().addNode()
    is_hidden = node.isHidden()

    if is_hidden:
        print("The node is hidden in the SmartArt data model.")

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **รับหรือกำหนดเค้าโครงแผนผังองค์กร**

สำหรับแผนภาพ SmartArt ที่ใช้เค้าโครงแผนผังองค์กร, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#getOrganizationChartLayout) และ [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/smartartnode/#setOrganizationChartLayout) กำหนดว่าตัวลูกจะจัดเรียงภายใต้โหนดแม่อย่างไร. ตัวอย่างเช่น คุณสามารถกำหนดให้ตัวลูกห้อยจากด้านซ้าย, ด้านขวา หรือทั้งสองด้าน ขึ้นอยู่กับค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) ที่เลือก.

ตัวอย่างต่อไปนี้สร้างแผนผังองค์กรและกำหนดเค้าโครงให้โหนดแรกเป็นค่า [OrganizationChartLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. ดัชนีเริ่มต้นจากศูนย์ `0` เลือกโหนดระดับบนแรก; ตัวลูกของมันจะใช้การจัดเรียงที่เลือก. จากนั้นบันทึกการนำเสนอที่แก้ไขแล้ว.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OrganizationChartLayoutType, Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart)
    root_node = smart_art.getNodes().get_Item(0)
    root_node.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging)

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **สร้างแผนผังองค์กรแบบภาพ**

แผนผังองค์กรแบบภาพคือเค้าโครง SmartArt ที่ออกแบบมาสำหรับแผนผังลำดับชั้นที่มีตำแหน่งตัวรองรับรูปภาพ. ใช้ค่า [SmartArtLayoutType](https://reference.aspose.com/slides/python-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` เมื่อเพิ่มวัตถุ SmartArt ลงในสไลด์. ตัวอย่างนี้บันทึกแผนภาพที่มีตำแหน่งตัวรองรับรูปภาพ; แต่ไม่ได้ใส่ภาพลงในตำแหน่งเหล่านั้น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart)

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **แปลงแผนภาพเก่าเป็นกลุ่มของรูปร่าง**

เมื่อทำให้การนำเสนอที่มีอยู่เป็นสมัยใหม่, คุณอาจต้องอัปเดตแผนผังองค์กรที่สร้างใน PowerPoint 97–2003. Aspose.Slides แทนที่แผนภาพเก่าเหล่านี้เป็นอ็อบเจกต์ [LegacyDiagram](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/). ใช้ [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/#convertToGroupShape) เพื่อแปลงแผนภาพเป็นกลุ่มของรูปร่างเพื่อให้คุณสามารถแก้ไของค์ประกอบภาพแยกแต่ละส่วนได้. ดู [LegacyDiagram API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/legacydiagram/) สำหรับรายละเอียด.

การแปลงจะเพิ่มกลุ่มใหม่เข้าในคอลเล็กชันของรูปร่างโดยไม่ลบแผนภาพเดิม. หลังจากแปลงสำเร็จ, ให้ลบแผนภาพต้นฉบับด้วย [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) เพื่อหลีกเลี่ยงเนื้อหาซ้ำ. รวบรวมแผนภาพเก่าไว้ในรายการก่อนแปลงเพื่อให้การเพิ่มและลบรูปร่างไม่ทำให้การวนลูปขัดข้อง.

ตัวอย่างต่อไปนี้เปิดการนำเสนอ, ค้นหาทุกสไลด์, แปลงแผนภาพเป็นกลุ่มของรูปร่าง, และบันทึกการนำเสนอที่อัปเดตเป็น PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LegacyDiagram, Presentation, SaveFormat

presentation = Presentation("legacy-diagrams.ppt")
try:
    for slide in presentation.getSlides():
        legacy_diagrams = []
        for shape in slide.getShapes():
            if isinstance(shape, LegacyDiagram):
                legacy_diagrams.append(shape)

        for legacy_diagram in legacy_diagrams:
            group_shape = legacy_diagram.convertToGroupShape()

            if group_shape is not None:
                slide.getShapes().remove(legacy_diagram)

    presentation.save("modernized.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การนำเสนอที่บันทึกไว้จะมีกลุ่มของรูปร่างที่แก้ไขได้แทนแผนภาพเก่าที่แปลงแล้ว, โดยไม่มีแผนภาพต้นฉบับเหลืออยู่ข้างเคียง. เปิดไฟล์ PPTX ใน PowerPoint เพื่อแก้ไของค์ประกอบแยกแต่ละรายการภายในแต่ละกลุ่ม, เช่น ข้อความ, การเติมสี, หรือตำแหน่ง.

## **คำถามที่พบบ่อย**

**SmartArt รองรับการสะท้อนหรือการกลับทิศสำหรับภาษาขวาไปซ้าย (RTL) หรือไม่?**

ใช่. วิธีการ [SmartArt.setReversed](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/#setReversed) จะสลับทิศทางของแผนภาพจากซ้ายไปขวาเป็นขวาไปซ้าย, หรือกลับกัน, เมื่อเค้าโครง SmartArt ที่เลือกสนับสนุนการกลับทิศ.

**ฉันจะคัดลอก SmartArt ไปยังสไลด์เดียวกันหรือไปยังการนำเสนออื่นโดยคงรูปแบบไว้ได้อย่างไร?**

คุณสามารถ [คัดลอกรูปร่าง SmartArt](/slides/th/python-java/shape-manipulations/) ด้วย [ShapeCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addClone) หรือ [คัดลอกสไลด์ทั้งหมด](/slides/th/python-java/clone-slides/) ที่มี SmartArt. ทั้งสองวิธีจะคงขนาด, ตำแหน่ง, และรูปแบบไว้.

**ฉันจะแสดงผล SmartArt เป็นภาพแรสเตอร์เพื่อการแสดงตัวอย่างหรือส่งออกเว็บได้อย่างไร?**

[เรนเดอร์สไลด์](/slides/th/python-java/convert-powerpoint-to-png/) หรือการนำเสนอทั้งหมดเป็น PNG หรือ JPEG. SmartArt จะถูกเรนเดอร์เป็นส่วนหนึ่งของสไลด์.

**ฉันจะค้นหาอ็อบเจกต์ SmartArt เฉพาะบนสไลด์ได้อย่างไรหากมีหลายอ็อบเจกต์?**

ใช้ [Shape.setAlternativeText](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setAlternativeText) หรือ [Shape.setName](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#setName) เพื่อกำหนดข้อความแทนหรือชื่อที่แสดงถึงรูปร่าง SmartArt, ค้นหาค่านั้นใน [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes), แล้วตรวจสอบว่ารูปร่างที่ตรงกันเป็น [SmartArt](https://reference.aspose.com/slides/python-java/aspose.slides/smartart/).