---
title: จัดการรูปทรงการนำเสนอใน Python ผ่าน Java
linktitle: การจัดการรูปทรง
type: docs
weight: 40
url: /th/python-java/shape-manipulations/
keywords:
- รูปทรง PowerPoint
- รูปทรงการนำเสนอ
- รูปทรงบนสไลด์
- ค้นหารรูปทรง
- คัดลอกรูปทรง
- ลบรูปทรง
- ซ่อนรูปทรง
- เปลี่ยนลำดับรูปทรง
- รับ ID รูปทรง Interop
- ข้อความทางเลือกของรูปทรง
- จุดปรับรูปทรง
- การปรับรูปทรงตั้งล่วงหน้า
- เรขาคณิตของรูปทรง
- รูปแบบเลย์เอาต์ของรูปทรง
- รูปทรงเป็น SVG
- ส่งออกรูปทรงเป็น SVG
- จัดแนวรูปทรง
- พลิกรูปทรง
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีระบุ, ปรับ, คัดลอก, ลบ, ซ่อน, จัดเรียงใหม่, ส่งออก, จัดแนว, และพลิกรูปทรงการนำเสนอด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java แสดงรูปทรงบนสไลด์เป็น [ShapeCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/) ที่จัดลำดับตามลำดับ. คอลเลกชันนี้เป็นทั้งที่คุณค้นหาและแก้ไขรูปทรงและเป็นแหล่งของลำดับการซ้อนกัน: ดัชนี `0` คือรูปทรงที่อยู่ด้านหลังสุด, ส่วนดัชนีสุดท้ายคือรูปทรงที่อยู่ด้านหน้าสุด.

บทความนี้ปฏิบัติตามโมเดลนั้น. มันอธิบายวิธีระบุรูปทรงอย่างแม่นยำและแก้ไขจุดปรับรูปทรงที่ตั้งล่วงหน้า, จากนั้นจะแสดงวิธีคัดลอก, ลบ, ซ่อน, และจัดเรียงรูปทรงใหม่. ส่วนสุดท้ายครอบคลุมการจัดรูปแบบระดับเลย์เอาต์, การส่งออกเป็น SVG, การจัดแนว, และการพลิกรูปทรง. ตัวอย่างแต่ละอันเป็นอิสระ, ดังนั้นคุณสามารถใช้เพียงการดำเนินการที่จำเป็นต่อเวิร์กโฟลว์ของคุณได้.

## **ระบุและค้นหารูปทรง**

ดัชนีของคอลเลกชันสะดวกเมื่อประมวลผลไฟล์ที่รู้จัก, แต่ไม่ใช่ตัวระบุที่คงที่. การเพิ่ม, การลบ, หรือการจัดเรียงรูปทรงใหม่อาจทำให้ดัชนีเปลี่ยนแปลง. เลือกตัวระบุตามวิธีการสร้างและการดูแลสไลด์:

- [Name](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getName) มีประโยชน์สำหรับเทมเพลตที่ควบคุมโดยนักพัฒนาและตรวจสอบได้ง่ายใน **Selection Pane** ของ PowerPoint. ชื่อสามารถแก้ไขได้และไม่รับประกันว่าจะไม่ซ้ำกัน, ดังนั้นควรกำหนดแนวปฏิบัติการตั้งชื่อหากโค้ดพึ่งพา.
- [AlternativeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getAlternativeText) มีประโยชน์เมื่อคำอธิบายการเข้าถึงหรือแท็กที่ผู้เขียนกำหนดไว้แล้วระบุรูปทรง. มันมองเห็นได้โดยผู้ใช้, อาจแปลเป็นหลายภาษา หรือเขียนใหม่เพื่อการเข้าถึง, แต่ก็ไม่รับประกันว่าจะไม่ซ้ำกัน. อย่านำข้อความการเข้าถึงที่มีความหมายไปใช้เป็นคีย์ฐานข้อมูลโดยไม่มีการแจ้งเตือน.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getOfficeInteropShapeId) เป็นตัวระบุแบบอ่านอย่างเดียวที่ไม่ซ้ำกันภายในสไลด์และสอดคล้องกับ Shape ID ที่ PowerPoint ใช้. ใช้เมื่อทำการเชื่อมต่อกับ PowerPoint หรือเมื่อคุณต้องการอ้างอิงที่ไม่คลุมเครือตลอดอายุของรูปทรง. รูปทรงที่คัดลอกหรือสร้างใหม่จะเป็นรูปทรงที่แตกต่างและจะได้รับ ID ของตนเอง.

เมธอด [getUniqueId](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getUniqueId) ที่เกี่ยวข้องคืนค่าตัวระบุระดับการนำเสนอ, แต่ตัวระบุนี้ออกแบบมาสำหรับแอด‑อินและอาจถูกกำหนดใหม่. ไม่ควรถือว่าเป็นคีย์ภายนอกถาวร. หากต้องการอัตลักษณ์ระยะยาว, เก็บการแมปในข้อมูลแอปพลิเคชันและตรวจสอบว่ารูปทรงที่คาดหวังยังคงมีอยู่.

ตัวอย่างต่อไปนี้ค้นหาตามชื่อด้วยการเปรียบเทียบแบบตรงและรายงาน interop ID ระดับสไลด์. เมื่อเทมเพลตไม่มีรูปทรงที่คาดหวัง, โค้ดจะแจ้งผลนั้นแทนที่จะดำเนินการต่อด้วยวัตถุที่ผิดพลาด.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = None
    for shape in slide.getShapes():
        if shape.getName() == "RevenueChart":
            target_shape = shape
            break

    if target_shape is None:
        print("The shape 'RevenueChart' was not found on slide 1.")
    else:
        print(f"Found {target_shape.getName()}; interop ID: {target_shape.getOfficeInteropShapeId()}")
finally:
    presentation.dispose()
```

เมื่อการดำเนินการเฉพาะกับชนิดรูปทรง, ตรวจสอบชนิดก่อนใช้สมาชิกที่เฉพาะเจาะจง. ตัวอย่างนี้อัปเดตข้อความและข้อความทางเลือกเฉพาะเมื่อวัตถุที่ชื่อเป็น [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    candidate = None
    for shape in slide.getShapes():
        if shape.getName() == "StatusLabel":
            candidate = shape
            break

    if isinstance(candidate, AutoShape):
        candidate.getTextFrame().setText("Approved")
        candidate.setAlternativeText("Approval status: approved")
        presentation.save("identified-shape.pptx", SaveFormat.Pptx)
    else:
        print("'StatusLabel' is missing or is not an AutoShape.")
finally:
    presentation.dispose()
```

## **ระบุและแก้ไขการปรับรูปทรงที่ตั้งล่วงหน้า**

รูปทรงเรขาคณิตที่ตั้งล่วงหน้าสามารถเปิดเผยจุดปรับที่ควบคุมคุณลักษณะเช่น ขนาดมุม, อัตราส่วนของลูกศร, หรือมุมโค้ง. เข้าถึงผ่านคอลเลกชันอ่านอย่างเดียว [GeometryShape.getAdjustments](https://reference.aspose.com/slides/th/python-java/aspose.slides/geometryshape/#getAdjustments). คอลเลกชันนี้มาจากรูปทรง, แต่แต่ละ [AdjustValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/) มีค่าที่สามารถเปลี่ยนได้.

อย่าอาศัยดัชนีคอลเลกชันที่คงที่เท่านั้น. วนลูปผ่านการปรับและตรวจสอบเมธอดอ่านอย่างเดียว [getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getType), ซึ่งค่า [ShapeAdjustmentType](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/) บรรยายว่าการปรับควบคุมอะไร. เมธอดอ่านอย่างเดียว [getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getName) ให้ข้อมูลระบุตัวเพิ่มและเป็นประโยชน์พิเศษเมื่อชุดตั้งล่วงหน้ามีการปรับหลายรายการที่มีประเภทเชิงความหมายเดียวกัน.

ใช้เมธอดค่าที่ตรงกับความหมายของการปรับ:

| ประเภทการปรับ | วัตถุประสงค์ | ค่าที่จะเปลี่ยน |
|---|---|---|
| [CornerSize](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#CornerSize) | ขนาดของมุมโค้ง | [setRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowTailThickness](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ArrowTailThickness) | ความหนาของหางลูกศร | [setRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadLength](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadLength) | ความยาวของหัวลูกศร | [setRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [ArrowheadWidth](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#ArrowheadWidth) | ความกว้างของหัวลูกศร | [setRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setRawValue) |
| [StartAngle](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#StartAngle) | มุมเริ่มต้นของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setAngleValue) |
| [EndAngle](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#EndAngle) | มุมสุดท้ายของพายหรือโค้ง | [setAngleValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setAngleValue) |

[getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getType) และ [getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getName) คืนค่าข้อมูลอ่านอย่างเดียว. [getRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getRawValue) และ [setRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setRawValue) ทำงานกับจำนวนเต็มในหน่วยเรขาคณิตดั้งเดิมของชุดตั้งล่วงหน้า, ส่วน [getAngleValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getAngleValue) และ [setAngleValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setAngleValue) ทำงานกับมุมเป็นองศา. จำนวน, ลำดับ, ความหมาย, และช่วงค่าที่ถูกต้องของการปรับขึ้นอยู่กับ [ShapeType](https://reference.aspose.com/slides/th/python-java/aspose.slides/geometryshape/#getShapeType) ของชุดตั้งล่วงหน้า. ค่าที่ใช้ได้กับชุดหนึ่งอาจใช้ไม่ได้หรือให้ผลต่างสำหรับอีกชุดหนึ่ง.

เมื่อ [getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getType) คืนค่า [ShapeAdjustmentType.Custom](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeadjustmenttype/#Custom), API ไม่รู้จักความหมายเชิงมาตรฐาน. ตรวจสอบ [getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getName), ประเภทชุดตั้งล่วงหน้า, และค่าที่มีอยู่, แล้วไม่เปลี่ยนการปรับหากไม่ทราบความหมายและช่วงที่คาดหวัง. แม้สำหรับประเภทที่รู้จัก, ตรวจสอบด้วยว่าชนิดเดียวปรากฏมากกว่าหนึ่งครั้งก่อนเลือกค่า. บทความ [Connector](/slides/th/python-java/connector/) แสดงสถานการณ์นี้กับการปรับการโค้งของ connector.

ตัวอย่างเต็มต่อไปนี้สร้างเวอร์ชันเริ่มต้นและเวอร์ชันที่แก้ไขของชุดรูปทรงตั้งล่วงหน้าสามชุด. มันวนลูปผ่านการปรับทั้งหมด, รายงานชื่อและประเภท, เปลี่ยนค่าที่เกี่ยวกับขนาดผ่าน [setRawValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setRawValue), เปลี่ยนมุมผ่าน [setAngleValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#setAngleValue), และบันทึกผลลัพธ์. คอลัมน์ซ้ายเก็บเรขาคณิตเริ่มต้น; คอลัมน์ขวาแสดงสี่เหลี่ยมมุมโค้ง, ลูกศรสี่ทิศ, และพายที่ปรับแล้ว.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeAdjustmentType, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มหัวข้อสำหรับคอลัมน์รูปทรงเริ่มต้นและรูปทรงที่ปรับค่า
    default_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 20, 250, 30)
    default_column_label.getTextFrame().setText("Default preset geometry")
    adjusted_column_label = slide.getShapes().addAutoShape(ShapeType.Rectangle, 390, 20, 250, 30)
    adjusted_column_label.getTextFrame().setText("Modified adjustment values")

    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70)
    modified_rounded_rectangle = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70)
    modified_rounded_rectangle.setName("ModifiedRoundedRectangle")

    slide.getShapes().addAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110)
    modified_arrow = slide.getShapes().addAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110)
    modified_arrow.setName("ModifiedQuadArrow")

    slide.getShapes().addAutoShape(ShapeType.Pie, 95, 330, 130, 130)
    modified_pie = slide.getShapes().addAutoShape(ShapeType.Pie, 445, 330, 130, 130)
    modified_pie.setName("ModifiedPie")

    shapes_to_adjust = [modified_rounded_rectangle, modified_arrow, modified_pie]

    for shape in shapes_to_adjust:
        for adjustment_index in range(shape.getAdjustments().size()):
            adjustment = shape.getAdjustments().get_Item(adjustment_index)
            print(f"{shape.getName()} / {adjustment.getName()}: {adjustment.getType()}")

            if adjustment.getType() == ShapeAdjustmentType.CornerSize:
                adjustment.setRawValue(5000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowTailThickness:
                adjustment.setRawValue(25000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadLength:
                adjustment.setRawValue(30000)
            elif adjustment.getType() == ShapeAdjustmentType.ArrowheadWidth:
                adjustment.setRawValue(40000)
            elif adjustment.getType() == ShapeAdjustmentType.StartAngle:
                adjustment.setAngleValue(30)
            elif adjustment.getType() == ShapeAdjustmentType.EndAngle:
                adjustment.setAngleValue(300)
            elif adjustment.getType() == ShapeAdjustmentType.Custom:
                print(f"Custom adjustment '{adjustment.getName()}' was not changed.")

    presentation.save("preset-shape-adjustments.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การตรวจสอบประเภทเชิงความหมายก่อนเปลี่ยนค่าทำให้โค้ดชัดเจนในเจตนาและหลีกเลี่ยงการสันนิษฐานว่าดัชนีคอลเลกชันเดียวกันมีความหมายเดียวกันในชุดรูปทรงตั้งล่วงหน้าอื่น.

## **แก้ไข Shape Collection**

เมธอดเพิ่ม, คัดลอก, ลบ, และจัดเรียงทำงานกับคอลเลกชันโดยตรง. หากการดำเนินการเปลี่ยนจำนวนหรือลำดับของรูปทรง, อย่าเพิ่งอ้างอิงดัชนีที่จับไว้ก่อนการดำเนินการนั้น.

### **คัดลอกรูปทรง**

[addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addClone) สร้างสำเนาอิสระและเพิ่มต่อท้ายคอลเลกชันเป้าหมาย. [insertClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#insertClone) ก็สร้างสำเนาเช่นกันแต่วางไว้ที่ดัชนี z‑order ที่ระบุ. การโอเวอร์โหลดที่รับพิกัดจะย้ายคล론โดยไม่เปลี่ยนขนาด; การโอเวอร์โหลดที่รับความกว้างและความสูงสามารถปรับขนาดได้ด้วย.

ตัวอย่างสร้างสไลด์ปลายทาง, คัดลอกสี่เหลี่ยมที่มีป้ายชื่อไปที่ด้านหน้า, และแทรกคล론ที่สองที่ด้านหลัง. การเปลี่ยนแปลงใด ๆ กับคลронใดคลронหนึ่งจะไม่กระทบรูปทรงต้นฉบับ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Presentation, SaveFormat, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    source_slide = presentation.getSlides().get_Item(0)
    source_shape = source_slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60)
    source_shape.setName("SourceLabel")
    source_shape.getTextFrame().setText("Source")

    blank_layout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank)
    destination_slide = presentation.getSlides().addEmptySlide(blank_layout)

    front_clone_shape = destination_slide.getShapes().addClone(source_shape, 80, 80)
    front_clone_shape.setName("FrontClone")
    if isinstance(front_clone_shape, AutoShape):
        front_clone_shape.getTextFrame().setText("Front clone")
    else:
        print("The front clone is not an AutoShape; its text was not changed.")

    back_clone_shape = destination_slide.getShapes().insertClone(0, source_shape, 80, 180)
    back_clone_shape.setName("BackClone")
    if isinstance(back_clone_shape, AutoShape):
        back_clone_shape.getTextFrame().setText("Back clone")
    else:
        print("The back clone is not an AutoShape; its text was not changed.")

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การคัดลอกจะคัดลอกเนื้อหาและการจัดรูปของรูปทรง, รวมถึงชื่อและข้อความทางเลือก. กำหนดตัวระบุตรรกะใหม่ให้กับคลронเมื่อค่าเหล่านั้นต้องไม่ซ้ำกัน. ทรัพยากรที่ใช้โดยรูปทรงที่ซับซ้อนจะถูกจัดการโดยการนำเสนอ, แต่คลронยังคงเป็นรายการใหม่ในคอลเลกชันพร้อมอัตลักษณ์รูปทรงใหม่.

### **ลบรูปทรง**

[remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#remove) ลบอ็อบเจกต์รูปทรงเฉพาะออกจากคอลเลกชัน. เมื่อทำการลบหลายรายการขณะวนลูปตามดัชนี, ควรทำการวนจากท้ายเพื่อให้ดัชนีที่เหลือยังคงถูกต้อง.

ตัวอย่างนี้ลบรูปทรงทั้งหมดที่มีชื่อกำหนด. มันอ่านรูปทรงที่ดัชนีปัจจุบัน, ไม่ใช่รายการคอลเลกชันคงที่, และไม่ทำการแคสต์รูปทรงโดยไม่จำเป็น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    keep_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60)
    keep_shape.setName("Keep")

    first_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80)
    first_temporary_shape.setName("Temporary")

    second_temporary_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80)
    second_temporary_shape.setName("Temporary")

    for i in range(slide.getShapes().size() - 1, -1, -1):
        shape = slide.getShapes().get_Item(i)
        if shape.getName() == "Temporary":
            slide.getShapes().remove(shape)

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

หลังการลบ, จำนวนรูปทรงและดัชนีของรูปทรงที่ตามมาจะเปลี่ยน. การอ้างอิงรูปทรงที่ไม่ได้รับผลกระทบยังคงเชื่อถือได้กว่าการบันทึกดัชนีไว้ล่วงหน้า. ควรพิจารณา connector, animation, และคุณลักษณะการนำเสนออื่น ๆ ที่อาจอ้างอิงถึงออบเจกต์ที่ลบ; การลบรูปทรงที่มองเห็นได้อาจทำให้เปลี่ยนแปลงมากกว่าลักษณะของสไลด์เท่านั้น.

### **ซ่อนรูปทรง**

การตั้งค่า [Hidden](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setHidden) เป็น `True` ทำให้รูปทรงคงอยู่ในคอลเลกชันแต่ไม่แสดงในการนำเสนอปกติ. ดัชนี, การจัดรูป, และเนื้อหายังคงใช้ได้ในโค้ด, ดังนั้นการซ่อนเหมาะกับองค์ประกอบที่เป็นตัวเลือกและอาจต้องการกู้คืนในภายหลัง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    visible_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60)
    visible_shape.setName("VisibleLabel")

    optional_shape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100)
    optional_shape.setName("OptionalDecoration")

    for shape in slide.getShapes():
        if shape.getName() == "OptionalDecoration":
            shape.setHidden(True)

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การซ่อนไม่ใช่การลบหรือความปลอดภัย. อ็อบเจกต์ยังคงสามารถค้นหาและยกเลิกการซ่อนได้โดยผู้ใช้หรือโดยโค้ด, และยังคงเป็นส่วนหนึ่งของไฟล์การนำเสนอ.

### **เปลี่ยน Z‑Order**

รูปทรงที่ทับกันจะถูกวาดตามลำดับคอลเลกชัน. [reorder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#reorder) ย้ายรูปทรงที่มีอยู่ไปยังดัชนีเป้าหมายโดยไม่คัดลอก. ดัชนี `0` คือด้านหลัง; [size](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#size)‑หนึ่งลบหนึ่งคือด้านหน้า.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    blue_rectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120)
    blue_rectangle.setName("BlueRectangle")
    blue_rectangle.getFillFormat().setFillType(FillType.Solid)
    blue_rectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    orange_ellipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120)
    orange_ellipse.setName("OrangeEllipse")
    orange_ellipse.getFillFormat().setFillType(FillType.Solid)
    orange_ellipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE)

    slide.getShapes().reorder(slide.getShapes().size() - 1, blue_rectangle)
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

สี่เหลี่ยมถูกสร้างขึ้นก่อนและโดยเริ่มอยู่ด้านหลังวงรี. การย้ายไปยังดัชนีสุดท้ายทำให้มันอยู่ด้านหน้า. ควรจัดลำดับ z‑order หลังจากเพิ่มหรือคัดลอกรูปทรงที่เกี่ยวข้องทั้งหมด, เนื่องจากการดำเนินการเหล่านั้นจะเพิ่มหรือแทรกรายการใหม่ในคอลเลกชันและอาจเปลี่ยนสแต็กที่ตั้งใจไว้.

## **ตรวจสอบรูปทรงบนสไลด์เลย์เอาต์**

สไลด์ปกติ, สไลด์เลย์เอาต์, และสไลด์มาสเตอร์มีคอลเลกชันรูปทรงแยกกัน. รูปทรงในคอลเลกชันเลย์เอาต์ไม่ใช่อ็อบเจกต์เดียวกับรูปทรงที่อยู่ในตำแหน่งเดียวกันบนสไลด์ปกติ. ตรวจสอบรูปทรงเลย์เอาต์เมื่อคุณต้องการเข้าใจหรือเปลี่ยนการจัดรูปที่มาจากเลย์เอาต์.

ตัวอย่างต่อไปนี้อ่าน [FillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getFillFormat) และ [LineFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getLineFormat) ของแต่ละรูปทรงในเลย์เอาต์โดยไม่สมมติว่าทุกรูปทรงเป็น [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for layout_slide in presentation.getLayoutSlides():
        for shape in layout_slide.getShapes():
            fill_type = shape.getFillFormat().getFillType()
            line_width = shape.getLineFormat().getWidth()
            print(f"{layout_slide.getName()} / {shape.getName()}: fill={fill_type}, line width={line_width}")
finally:
    presentation.dispose()
```

การแก้ไขเลย์เอาต์อาจส่งผลต่อหลายสไลด์ที่ใช้งานเลย์เอาต์นั้น. ก่อนเปลี่ยนรูปทรงในเลย์เอาต์, ตรวจสอบว่าสไลด์ปกติสืบทอดออบเจกต์นั้นหรือมีการตั้งค่าท้องถิ่นที่ทับ, และทดสอบทุกสไลด์ที่ใช้เลย์เอาต์นั้น.

## **ส่งออกรูปทรงเป็น SVG**

เมธอด `writeAsSvg` ของ [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/) จะเขียนเนื้อหาที่เรนเดอร์ของรูปทรงหนึ่งไปยังสตรีม. ผลลัพธ์จะมีเฉพาะรูปทรง, ไม่รวมพื้นหลังสไลด์ทั้งหมดหรือรูปทรงใกล้เคียง.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path
from java.io import ByteArrayOutputStream

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    if slide.getShapes().size() == 0:
        print("Slide 1 does not contain a shape to export.")
    else:
        shape = slide.getShapes().get_Item(0)
        svg_stream = ByteArrayOutputStream()
        try:
            shape.writeAsSvg(svg_stream)
            svg_bytes = bytes(svg_stream.toByteArray())
            Path("shape.svg").write_bytes(svg_bytes)
        except OSError as exception:
            print(f"The SVG file could not be written: {exception}")
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

ควรเปิดการนำเสนอขณะทำการเรนเดอร์. ผลลัพธ์ขึ้นกับการจัดรูปของรูปทรงและทรัพยากรเช่น ฟอนต์และภาพ. หากต้องการภาพขององค์ประกอบทั้งหมด, ควรส่งออกสไลด์แทนการส่งออกรูปทรงเดียว. ผู้เรียกเป็นผู้เป็นเจ้าของสตรีมและต้องปิดสตรีม.

## **จัดแนวรูปทรง**

เมธอด [SlideUtil.alignShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideutil/#alignShapes) มีโอเวอร์โหลดที่จัดแนวทั้งทั้งหมดหรือดัชนีคอลเลกชันที่เลือก. [ShapesAlignmentType](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapesalignmenttype/) ระบุขอบ, เส้นศูนย์กลาง, หรือโหมดกระจาย. ตั้งค่า `align_to_slide` เป็น `True` เพื่อใช้ขอบสไลด์; ตั้งเป็น `False` เพื่อจัดแนวรูปทรงที่เลือกสัมพันธ์กัน.

ตัวอย่างนี้จัดแนวสามรูปทรงไปที่ขอบบนของสไลด์. การอ้างอิงรูปทรงที่คืนค่าจะถูกแปลงเป็นดัชนีปัจจุบันทันทีก่อนการจัดแนว.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, ShapesAlignmentType, SlideUtil

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50)
    third_shape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50)
    first_shape.setName("FirstAlignedShape")
    second_shape.setName("SecondAlignedShape")
    third_shape.setName("ThirdAlignedShape")

    shape_indexes = jpype.JArray(jpype.JInt)([slide.getShapes().indexOf(first_shape), slide.getShapes().indexOf(second_shape), slide.getShapes().indexOf(third_shape)])

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, True, slide, shape_indexes)
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การจัดแนวจะเปลี่ยนตำแหน่ง, ไม่เปลี่ยน z‑order. การจัดแนวสัมพันธ์ทั่วไปต้องมีอย่างน้อยสองรูปทรง, ส่วนการกระจายแนวนอนหรือแนวตั้งต้องมีจำนวนรูปทรงเพียงพอที่จะกำหนดระยะห่าง. คำนวนดัชนีใหม่หากคุณแก้ไขคอลเลกชันก่อนเรียกเมธอด.

## **พลิกรูปทรง**

คลาส [ShapeFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeframe/) เก็บตำแหน่ง, ขนาด, การพลิกแนวนอนและแนวตั้ง, และการหมุน. ค่า [getFlipH](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeframe/#getFlipH) และ [getFlipV](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapeframe/#getFlipV) ใช้ [NullableBool](https://reference.aspose.com/slides/th/python-java/aspose.slides/nullablebool/): `True` เปิดการพลิก, `False` ปิด, และ `NotDefined` คงสถานะที่ไม่ได้กำหนด/ค่าเริ่มต้น.

การนำเสนออินพุตด้านล่างมีรูปทรงหนึ่งรูปที่ไม่ได้พลิก.

![รูปทรงก่อนการพลิก](shape_to_be_flipped.png)

ตัวอย่างนี้คงค่ากรอบอื่นทั้งหมดและเปลี่ยนเฉพาะสองการตั้งค่าพลิก. สิ่งนี้สำคัญเพราะการกำหนด [Frame](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#setFrame) ใหม่จะทับกรอบทั้งหมด.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    frame = shape.getFrame()

    print(f"Horizontal flip before change: {frame.getFlipH()}")
    print(f"Vertical flip before change: {frame.getFlipV()}")

    flipped_frame = ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True_, NullableBool.True_, frame.getRotation())
    shape.setFrame(flipped_frame)

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

รูปทรงที่บันทึกจะถูกสะท้อนในแนวนอนและแนวตั้งพร้อมกับตำแหน่ง, ขนาด, และการหมุนที่คงเดิม.

![รูปทรงหลังการพลิก](flipped_shape.png)

## **คำถามที่พบบ่อย**

**ควรใช้ดัชนีคอลเลกชันเป็นตัวระบุรูปทรงหรือไม่?**

ใช้ได้เฉพาะการประมวลผลสั้น ๆ ที่คอลเลกชันไม่เปลี่ยนแปลงก่อนใช้ดัชนี. แนะนำให้ใช้ [Name](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getName) หรือ [AlternativeText](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getAlternativeText) ที่ผ่านการตรวจสอบสำหรับเทมเพลตที่สร้างโดยผู้เขียน, หรือใช้ [OfficeInteropShapeId](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getOfficeInteropShapeId) สำหรับงานที่ต้องอ้างอิงแบบ interop ระดับสไลด์.

**การซ่อนรูปทรงจะทำให้มันหายจาก z‑order หรือไม่?**

ไม่. รูปทรงที่ซ่อนยังคงอยู่ในคอลเลกชันที่ดัชนีเดิม. สามารถค้นหา, จัดเรียงใหม่, แก้ไข, หรือทำให้มองเห็นได้อีกครั้ง.

**ทำไมรูปทรงที่คัดลอกจึงปรากฏอยู่หน้ารูปทรงอื่น?**

[addClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addClone) เพิ่มคล론ไปที่ท้ายคอลเลกชัน, ซึ่งเป็นด้านหน้าของ z‑order. ใช้ [insertClone](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#insertClone) เพื่อเลือกดัชนีเริ่มต้นหรือใช้ [reorder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#reorder) หลังจากเพิ่มรูปทรงทั้งหมดแล้ว.

**สามารถใช้ดัชนีคงที่เพื่อระบุการปรับรูปทรงตั้งล่วงหน้าได้หรือไม่?**

ได้เฉพาะหลังจากตรวจสอบชุดตั้งล่วงหน้าและโครงสร้างคอลเลกชันอย่างแม่นยำ. แนะนำให้วนลูปผ่าน [GeometryShape.getAdjustments](https://reference.aspose.com/slides/th/python-java/aspose.slides/geometryshape/#getAdjustments) และตรวจสอบ [AdjustValue.getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getType); ใช้ [AdjustValue.getName](https://reference.aspose.com/slides/th/python-java/aspose.slides/adjustvalue/#getName) เป็นข้อมูลเสริมเมื่อประเภทเชิงความหมายเดียวปรากฏหลายครั้ง.