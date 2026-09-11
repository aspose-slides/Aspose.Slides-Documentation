---
title: รูปร่างการนำเสนอแบบกลุ่มใน Python ผ่าน Java
linktitle: กลุ่มรูปทรง
type: docs
weight: 40
url: /th/python-java/group/
keywords:
- รูปแบบกลุ่ม
- กลุ่มรูปทรง
- เพิ่มกลุ่ม
- ข้อความสำรอง
- PowerPoint
- การนำเสนอ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการจัดกลุ่มและแยกกลุ่มรูปทรงในชุดงาน PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java—คู่มือขั้นตอนต่อขั้นตอนพร้อมโค้ด Python ฟรี."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับรูปแบบกลุ่มใน Aspose.Slides แสดงวิธีการเพิ่มรูปแบบกลุ่มลงในสไลด์ ใส่รูปลงในกลุ่ม และบันทึกการนำเสนอที่อัปเดต นอกจากนี้ยังสาธิตวิธีเข้าถึงรูปที่เก็บอยู่ในกลุ่มและอ่านข้อความสำรองของมันโดยใช้ [getAlternativeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getAlternativeText) นอกจากนี้บทความยังสรุปสั้น ๆ เกี่ยวกับคุณสมบัติเกี่ยวกับรูปแบบกลุ่มเช่น กลุ่มซ้อนกัน การจัดลำดับ z-order และตัวเลือกการล็อก

## **เพิ่มรูปแบบกลุ่ม**

Aspose.Slides รองรับการทำงานกับรูปแบบกลุ่มบนสไลด์ ฟีเจอร์นี้ช่วยให้นักพัฒนาสร้างการนำเสนอที่มีความหลากหลายมากขึ้น Aspose.Slides สำหรับ Python ผ่าน Java รองรับการเพิ่มและเข้าถึงรูปแบบกลุ่ม คุณสามารถเติมเต็มรูปแบบกลุ่มด้วยรูปต่าง ๆ หรือเข้าถึงคุณสมบัติของมัน เพื่อเพิ่มรูปแบบกลุ่มลงในสไลด์โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เพิ่มรูปแบบกลุ่มลงในสไลด์
1. เพิ่มรูปลงในรูปแบบกลุ่ม
1. บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ตัวอย่างด้านล่างเพิ่มรูปแบบกลุ่มลงในสไลด์:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# สร้างอินสแตนซ์ของคลาส Presentation.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เข้าถึงคอลเลกชันรูปร่างของสไลด์.
    slide_shapes = slide.getShapes()

    # เพิ่มรูปแบบกลุ่มลงในสไลด์.
    group_shape = slide_shapes.addGroupShape()

    # เพิ่มรูปภายในรูปแบบกลุ่ม.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # ตั้งค่าเฟรมของรูปแบบกลุ่ม.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # บันทึกไฟล์ PPTX ลงดิสก์.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เข้าถึงข้อความสำรอง**

ส่วนนี้แสดงวิธีการเข้าถึงข้อความสำรองของรูปภายในกลุ่มบนสไลด์ เพื่อเข้าถึงข้อความนี้โดยใช้ Aspose.Slides สำหรับ Python ผ่าน Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) ที่แทนไฟล์ PPTX
1. รับอ้างอิงถึงสไลด์โดยใช้ดัชนีของมัน
1. เข้าถึงคอลเลกชันรูปร่างของสไลด์
1. เข้าถึงรูปแบบกลุ่ม
1. อ่านข้อความสำรองของรูปภายในโดยใช้ [getAlternativeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getAlternativeText).

ตัวอย่างด้านล่างเข้าถึงข้อความสำรองของรูปภายในกลุ่ม:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX.
presentation = Presentation("AltText.pptx")
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # เข้าถึงรูปในคอลเลกชันรูปร่างของสไลด์.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # เข้าถึงรูปภายในกลุ่ม.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # อ่านข้อความสำรอง.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**การจัดกลุ่มซ้อน (กลุ่มภายในกลุ่ม) รองรับหรือไม่?**

ใช่. [GroupShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshape/) มีเมธอด [getParentGroup](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getParentGroup) ซึ่งแสดงการสนับสนุนโครงสร้างชั้นล่าง: กลุ่มสามารถเป็นลูกของกลุ่มอื่นได้.

**ฉันจะควบคุมลำดับ z ของกลุ่มสัมพันธ์กับวัตถุอื่นบนสไลด์ได้อย่างไร?**

ใช้เมธอด [getZOrderPosition](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getZOrderPosition) ของอ็อบเจกต์ [GroupShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshape/) เพื่อตรวจสอบตำแหน่งของมันในลำดับการแสดงผล.

**ฉันสามารถป้องกันการย้าย การแก้ไข หรือการแยกกลุ่มได้หรือไม่?**

ใช่. การล็อกของกลุ่มสามารถเข้าถึงได้ผ่าน [getGroupShapeLock](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshape/#getGroupShapeLock) ที่ให้คุณจำกัดการดำเนินการบนอ็อบเจกต์นี้.