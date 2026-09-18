---
title: สร้างและแก้ไขพฤติกรรมการเคลื่อนไหวแบบกำหนดเองใน Python ผ่าน Java
linktitle: การเคลื่อนไหวแบบกำหนดเอง
type: docs
weight: 151
url: /th/python-java/custom-animation/
keywords:
- การเคลื่อนไหวแบบกำหนดเอง
- พฤติกรรมการเคลื่อนไหว
- เส้นทางการเคลื่อนที่
- PowerPoint
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้าง, ตรวจสอบและแก้ไขพฤติกรรมการเคลื่อนไหวแบบกำหนดเองและเส้นทางการเคลื่อนที่ที่แก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

พฤติกรรมการเคลื่อนไหวแบบกำหนดเองช่วยให้คุณควบคุมการดำเนินการแต่ละอย่างภายในเอฟเฟกต์การเคลื่อนไหว เช่น การเปลี่ยนสี การหมุนรูปทรง หรือการตามเส้นทางการเคลื่อนที่ที่แก้ไขได้ คู่มือนี้แสดงวิธีสร้างและรวมพฤติกรรม การกำหนดเวลาของพฤติกรรม ตรวจสอบและแก้ไขการเคลื่อนไหวที่มีอยู่ และยืนยันว่าคุณสมบัติเหล่านั้นยังคงอยู่หลังการบันทึกและเปิดการนำเสนอใหม่

สำหรับเอฟเฟกต์ที่กำหนดไว้ล่วงหน้าและการเรียกใช้เมื่อคลิก ดูที่[การเคลื่อนไหวของรูปทรง](/slides/th/python-java/shape-animation/)

## **ทำความเข้าใจโมเดลการเคลื่อนไหว**

การเคลื่อนไหวจะถูกจัดระเบียบเป็น **Timeline → Sequence → Effect → Behaviors**:

- เมธอด [getTimeline](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getTimeline) คืนค่า timeline ของสไลด์ซึ่งประกอบด้วย sequence หลักและ sequence แบบโต้ตอบ
- Sequence ([Sequence](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/)) ประกอบด้วยเอฟเฟกต์ซึ่งอาจทำเป้าหมายไปยังรูปทรงต่างๆ
- Effect ([Effect](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/)) ระบุรูปทรงเป้าหมาย, preset, subtype, และกำหนดเวลาเอฟเฟกต์
- คอลเลกชันที่ได้จาก [Effect.getBehaviors](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getBehaviors) มีการดำเนินการที่ทำให้เอฟเฟกต์ทำงาน: การเปลี่ยนสี, การย้าย, การหมุน, การตั้งค่าคุณสมบัติ ฯลฯ

## **สร้างพฤติกรรมแต่ละรายการ**

ใช้เมธอด [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) เพื่อสร้างเอฟเฟกต์และเข้าถึงคอลเลกชัน [getBehaviors](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getBehaviors) preset สามารถเติมคอลเลกชันนี้โดยอัตโนมัติ ควรรักษาการดำเนินการนั้นเมื่อขยาย preset หรือใช้ [clear](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorcollection/#clear) เมื่อต้องการแทนที่โดยเจตนา

[BehaviorFactory](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/) สร้างประเภทพฤติกรรมแปดประเภทตามที่แสดงด้านล่าง การเคลื่อนที่จะอธิบายใน[สร้างเส้นทางการเคลื่อนที่]('#build-a-motion-path') แต่ละตัวอย่างรวมการนำเข้าและเริ่ม JVM หากจำเป็น วัตถุจุดและอาเรย์ของ Java สร้างผ่าน JPype ตามที่ API ต้องการ ตัวอย่างการแก้ไขภายหลังจะระบุไฟล์ผลลัพธ์ที่ใช้

### **การหมุน**

ใช้ [createRotationEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createRotationEffect) เพื่อสร้างการหมุน [getBy](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotationeffect/#getBy) ระบุมุมเชิงสัมพันธ์เป็นองศา; [getFrom](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotationeffect/#getFrom) และ [getTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotationeffect/#getTo) ระบุจุดสิ้นสุด

ตัวอย่างเริ่มด้วยเอฟเฟกต์ Spin แทนที่การดำเนินการของ preset ด้วยพฤติกรรมการหมุนหนึ่งตัวและกำหนดระยะเวลาให้สองวินาที มุมเชิงสัมพันธ์ 90 องศาแสดงถึงการหมุนหนึ่งในสี่จากการวางตำแหน่งเริ่มต้นของรูปทรง ดังนั้นจึงไม่จำเป็นต้องระบุมุมเริ่มต้นอย่างชัดเจน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` มีรูปทรงหนึ่งรูปและพฤติกรรมการหมุนหนึ่งตัว คอลเลกชัน, การกำหนดเวลา, และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **การปรับขนาด**

ใช้ [createScaleEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createScaleEffect) กับเปอร์เซ็นต์ X/Y: [getFrom](https://reference.aspose.com/slides/th/python-java/aspose.slides/scaleeffect/#getFrom) และ [getTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/scaleeffect/#getTo) อธิบายขนาดเริ่มต้นและสุดท้าย ส่วน [getBy](https://reference.aspose.com/slides/th/python-java/aspose.slides/scaleeffect/#getBy) อธิบายการเปลี่ยนแปลงเชิงสัมพันธ์ ที่นี่ 100 หมายถึงขนาดดั้งเดิม

ตัวอย่างขยายทั้งสองมิติจาก 100% ไปเป็น 125% ภายในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันรักษาสัดส่วนของรูป; เปอร์เซ็นต์ที่แตกต่างจะยืดมิติหนึ่งมากกว่ากลาง

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **สี**

ใช้ [createColorEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createColorEffect) เพื่อเปลี่ยนสีเติมจากน้ำเงินเป็นสีส้ม [getFrom](https://reference.aspose.com/slides/th/python-java/aspose.slides/coloreffect/#getFrom) และ [getTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/coloreffect/#getTo) เป็นสี; [getBy](https://reference.aspose.com/slides/th/python-java/aspose.slides/coloreffect/#getBy) เป็นออฟเซ็ตสี [Behavior.getProperties](https://reference.aspose.com/slides/th/python-java/aspose.slides/behavior/#getProperties) ระบุแอตทริบิวต์ที่กำลังทำแอนิเมชัน

การเติมเต็มของรูปทรงถูกตั้งค่าเป็นสีฟ้าเริ่มต้นตรงกับสีเริ่มต้นของแอนิเมชัน การเลือกแอตทริบิวต์สีเติมบอกพฤติกรรมว่าต้องเปลี่ยนส่วนใดของรูป; จุดสีเริ่มและสุดท้ายเพียงอย่างเดียวไม่บ่งบอกแอตทริบิวต์นั้น เอฟเฟกต์ที่บันทึกบ่งบอกการเปลี่ยนเป็นสีส้มในสองวินาที

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ฟิลเตอร์**

ใช้ [createFilterEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createFilterEffect) เพื่อเลือกการลบรอย [getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/th/python-java/aspose.slides/filtereffect/#getSubtype), และ [getReveal](https://reference.aspose.com/slides/th/python-java/aspose.slides/filtereffect/#getReveal) ระบุฟิลเตอร์, ทิศทาง, และว่าจะเปิดเผยหรือซ่อนรูป

ตัวอย่างกำหนดการลบแบบสองวินาทีที่เปิดเผยรูปด้วย subtype ทิศทางขวา การตั้งค่าฟิลเตอร์เป็นของพฤติกรรมภายในเอฟเฟกต์ ดังนั้นจึงตั้งค่าหลังจากลบการดำเนินการเดิมของ preset แล้ว

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **คุณสมบัติ**

ใช้ [createPropertyEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) เพื่อทำแอนิเมชันความทึบ [getFrom](https://reference.aspose.com/slides/th/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/propertyeffect/#getTo), และ [getBy](https://reference.aspose.com/slides/th/python-java/aspose.slides/propertyeffect/#getBy) เป็นสตริงที่ตีความด้วย [getValueType](https://reference.aspose.com/slides/th/python-java/aspose.slides/propertyeffect/#getValueType) และ [getCalcMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/propertyeffect/#getCalcMode) เลือกจุดสิ้นสุดหรือออฟเซ็ตเชิงสัมพันธ์แทนการตั้งค่าสามค่าโดยไม่คัดกรอง

ที่นี่แอตทริบิวต์ที่เลือกคือความทึบ และสตริงตัวเลขแทนการเปลี่ยนจากความทึบ 25% ไปเป็นเต็ม ความทึบ การเชื่อมต่อเชิงเส้นอธิบายการเปลี่ยนแปลงอย่างค่อยเป็นค่อยไประหว่างค่าดังกล่าว เมื่อนำตัวอย่างนี้ไปใช้กับแอตทริบิวต์อื่น ให้เลือกประเภทค่าและค่าจุดสิ้นสุดที่เหมาะสมกับแอตทริบิวต์นั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **กำหนด**

ใช้ [createSetEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createSetEffect) เพื่อกำหนดการมองเห็นผ่าน [getTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/seteffect/#getTo) พฤติกรรม set ไม่ทำการเชื่อมต่อระหว่างจุดสิ้นสุด

ตัวอย่างเลือกแอตทริบิวต์การมองเห็นและกำหนดสตริง `visible` เมื่อตัวพฤติกรรมทำงาน สี่เหลี่ยมตรงนี้มองเห็นอยู่แล้วในงานนำเสนอพื้นฐาน ดังนั้นการกำหนดอาจไม่แสดงการเปลี่ยนแปลงที่ชัดเจน การดำเนินการเช่นนี้มีประโยชน์เมื่อเป็นส่วนหนึ่งของเอฟเฟกต์ที่ใหญ่กว่าซึ่งควบคุมการซ่อนหรือแสดงรูปด้วย

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **คำสั่ง**

ใช้ [createCommandEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createCommandEffect) และกำหนด [getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/th/python-java/aspose.slides/commandeffect/#getCommandString), และ [getShapeTarget](https://reference.aspose.com/slides/th/python-java/aspose.slides/commandeffect/#getShapeTarget) วางไฟล์เสียง WAV ชื่อ `sample.wav` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์เสียงด้วย [addAudioFrameEmbedded](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) และแนบคำสั่งเล่นให้กับเฟรมเสียง

เฟรมเสียงเป็นทั้งเป้าหมายของเอฟเฟกต์และของคำสั่ง นี่เชื่อมคำขอเล่นกับการบันทึกที่ฝังอยู่; สตริงคำสั่งโดยลำพังไม่บ่งบอกว่าจะควบคุมออบเจกต์สื่อใด เอฟเฟกต์ตั้งค่าให้เริ่มเมื่อคลิกระหว่างการพรีเซนเทชัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การบันทึกเก็บคำสั่งใน `command.pptx`; มันจะไม่เล่นไฟล์เสียง การเล่นต้องใช้ผู้เล่นสไลด์โชว์ที่สนับสนุนคำสั่งและเป้าหมายสื่อของมัน

## **จัดการคอลเลกชันพฤติกรรม**

[BehaviorCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorcollection/) รองรับ [add](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorcollection/#remove), และ [removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorcollection/#removeAt) ตัวอย่างนี้เปิด `rotation.pptx`, เพิ่มการสเกล, ย้ายมันก่อนการหมุน, และลบการหมุน การลบและใส่ซ้ำวัตถุเดียวกันจะเปลี่ยนตำแหน่งที่จัดเก็บโดยไม่สร้างสำเนา

ลำดับการแก้ไขเปลี่ยนคอลเลกชันจาก rotation–scale เป็น scale–rotation แล้วเป็น scale เพียงอย่างเดียว ดัชนีอ้างอิงคอลเลกชันปัจจุบัน ดังนั้นการลบใช้ดัชนีใหม่ของการหมุนหลังจากการจัดเรียงใหม่ การนับสุดท้ายยืนยันพฤติกรรมใดบันทึกไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ผลลัพธ์คือ `ScaleEffect`: เหลือการสเกลเท่านั้น ลำดับของคอลเลกชันโดยตัวมันเองไม่ได้กำหนดให้พฤติกรรมเล่นต่อเนื่องกัน ควรล้างคอลเลกชันเฉพาะเมื่อแทนที่การดำเนินการทั้งหมด

## **กำหนดค่าการกำหนดเวลาพฤติกรรม**

[Behavior.getTiming](https://reference.aspose.com/slides/th/python-java/aspose.slides/behavior/#getTiming) เปิดเผย [Timing](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/), แยกจาก [Effect.getTiming](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getTiming) การกำหนดเวลาเอฟเฟกต์กำหนดเวลาให้กับเอฟเฟกต์โดยรวม; การกำหนดเวลาพฤติกรรมอธิบายการดำเนินการภายในเอฟเฟกต์นั้น

### **ตั้งค่า ระยะเวลา, การหน่วงเวลา, การทำซ้ำ, และการเร่งความเร็ว**

เปิด `rotation.pptx` และตั้งระยะเวลา ([getDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getDuration)) และการหน่วงเวลาการทริกเกอร์ ([getTriggerDelayTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getTriggerDelayTime)) เป็นวินาที จากนั้นกำหนดจำนวนการทำซ้ำด้วย [setRepeatCount](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#setRepeatCount) [getAccelerate](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getAccelerate) และ [getDecelerate](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getDecelerate) เป็นส่วนของระยะเวลา; รักษาผลรวมไม่เกิน 1

ไฟล์อินพุตคือไฟล์ที่สร้างในตัวอย่างการหมุน ที่พฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนแค่การกำหนดเวลาของพฤติกรรมนั้น; มุม 90 องศายังคงเดิม การแยกมุมและการกำหนดเวลาออกจากกันทำให้ปรับความเร็วได้ง่ายโดยไม่ต้องสร้างแอนิเมชันใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

พฤติกรรมใช้ระยะเวลาสองวินาที หน่วงเวลาครึ่งวินาที และทำซ้ำ 3 ครั้ง 20% แรกและสุดท้ายของระยะเวลาถูกใช้สำหรับการเร่งและการชะลอ

นโยบายการทำซ้ำอื่น ๆ ได้แก่ [getRepeatDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getRepeatUntilEndSlide), และ [getRepeatUntilNextClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getRepeatUntilNextClick); เลือกนโยบายแทนการเปิดใช้งานทั้งหมดพร้อมกัน [getAutoReverse](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getAutoReverse) เล่นแอนิเมชันย้อนกลับหลังจากรอบแรก การเร่งและการชะลอใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าแยกหรือคำสั่ง

## **สร้างเส้นทางการเคลื่อนที่**

ใช้ [createMotionEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorfactory/#createMotionEffect) เพื่อสร้างการเคลื่อนที่ [getFrom](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/#getTo), และ [getBy](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/#getBy) อธิบายพิกัดหรือออฟเซ็ตแบบเปอร์เซ็นต์ สำหรับเส้นทางแก้ไขได้ สร้าง [MotionPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/motionpath/) และกำหนดด้วย [MotionEffect.setPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/#setPath) [MotionPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/motionpath/) เก็บคำสั่งของเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioncommandpathtype/) เลือกการดำเนินการ:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MoveTo | One | กำหนดตำแหน่งเริ่มต้น |
| LineTo | One | เคลื่อนตามส่วนตรงไปยังจุดสิ้นสุด |
| CurveTo | Three | ตามเส้นโค้ง cubic ที่กำหนดโดยจุดควบคุมสองจุดและจุดสิ้นสุด |
| CloseLoop | None | กลับไปที่ตำแหน่งเริ่มต้น |
| End | None | จบเส้นทาง |

[MotionPathPointsType](https://reference.aspose.com/slides/th/python-java/aspose.slides/motionpathpointstype/) อธิบายลักษณะการแก้ไขจุด เช่น จุดมุมหรือจุดเรียบ ไม่ได้แทนที่ประเภทคำสั่ง ใช้ประเภทจุดโค้งสำหรับตัวอย่างโค้งด้านล่าง และประเภทจุดมุมสำหรับส่วนตรง

พิกัดของเส้นทางทำให้เป็นเป็นสัดส่วนต่อขนาดสไลด์: การเคลื่อนที่ X 0.25 หมายถึงหนึ่งในสี่ของความกว้างสไลด์ ไม่ใช่ 0.25 จุด Y บวกลงด้านล่าง คำสั่งคงที่ระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่งเชิงสัมพันธ์ระบุตำแหน่งออฟเซ็ตจากตำแหน่งปัจจุบัน นี้แยกจาก [getOrigin](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/#getOrigin) ที่เลือกกรอบอ้างอิงของเส้นทางและ [getPathEditMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioneffect/#getPathEditMode) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อรูปถูกย้าย

### **สร้างเส้นทางตรง**

สร้างพฤติกรรมการเคลื่อนที่ด้วยจุดเริ่มต้น หนึ่งส่วนตรง และคำสั่งจบ [MotionPath.add](https://reference.aspose.com/slides/th/python-java/aspose.slides/motionpath/#add) รับประเภทคำสั่ง จุดของมัน ประเภทจุด และแฟล็กพิกัดสัมพันธ์

คำสั่งเริ่มต้นตั้งค่า (0, 0) และเส้นตรงจบที่ (0.25, 0) ให้เส้นทางเคลื่อนที่แนวนอนหนึ่งในสี่ของความกว้างสไลด์ คำสั่งจบไม่มีจุดพิกัด เมื่อกำหนดเส้นทางแล้ว การเพิ่มพฤติกรรมการเคลื่อนที่ลงในเอฟเฟกต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยม

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งตัวพร้อมสามคำสั่งเส้นทาง ตัวอย่างการแก้ไขไฟล์ต่อไปนี้ใช้โครงสร้างที่ทราบนี้

### **เปรียบเทียบพิกัดคงที่และพิกัดสัมพันธ์**

สองอ็อบเจกต์เส้นทางนี้อธิบายเส้นทางเดียวกัน คำสั่งคงที่จบที่ (0.3, 0.1); คำสั่งสัมพันธ์เพิ่ม (0.1, 0.1) ให้กับตำแหน่งปัจจุบัน (0.2, 0)

เส้นทางทั้งสองเริ่มที่ตำแหน่งเดียวกัน สำหรับเส้นสัมพันธ์ให้บวกออฟเซ็ต X และ Y กับตำแหน่งปัจจุบันเพื่อให้ได้จุดสิ้นสุด; สำหรับเส้นคงที่อ่านจุดสิ้นสุดโดยตรง การสลับแฟล็กโดยไม่แปลงพิกัดจะทำให้เส้นทางต่างกัน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

กำหนดเส้นทางใดเส้นทางหนึ่งให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในงานนำเสนอ อาร์กิวเมนต์ Boolean สุดท้ายเลือกพิกัดสัมพันธ์สำหรับคำสั่งนั้น

### **แทนที่เส้นตรงด้วยเส้นโค้ง**

เปิด `motion.pptx` และแทนที่คำสั่งเส้นตรงด้วยเส้นโค้ง cubic ให้ระบุจุดควบคุมสองจุดก่อน แล้วตามด้วยจุดสิ้นสุด

ตำแหน่งเริ่มต้นถูกกำหนดโดยคำสั่งก่อนหน้า จุดสองจุดแรกกำหนดรูปร่างของเส้นโค้ง ส่วนจุดที่สามเป็นจุดปลาย; ไม่ใช่จุดปลายต่อเนื่องสามจุด การอัพเดตประเภทคำสั่ง, ประเภทการแก้ไขจุด, และอาเรย์จุดพร้อมกันทำให้ส่วนเส้นสอดคล้องกับเรขาคณิตใหม่

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เส้นทางใน `curve.pptx` ยังคงมีสามคำสั่ง; คำสั่งกลางตอนนี้กำหนดเป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [MotionCmdPath](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioncmdpath/) เปิดเผย [getPoints](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioncmdpath/#getPointsType), และ [isRelative](https://reference.aspose.com/slides/th/python-java/aspose.slides/motioncmdpath/#isRelative) ตัวอย่างต่อไปนี้ใช้เส้นทางสามคำสั่งที่รู้จักใน `motion.pptx` สำหรับอินพุตใด ๆ ให้ค้นหาเอฟเฟกต์ที่ต้องการและตรวจสอบประเภทคำสั่งและจำนวนจุดก่อนแก้ไขตามดัชนี

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง End และ CloseLoop ไม่ต้องการจุด จึงต้องรองรับอาเรย์จุดเป็น null

ผลลัพธ์จับคู่แต่ละประเภทคำสั่งตัวเลขกับแฟล็กพิกัดสัมพันธ์ก่อนแสดงจุดของมัน ทำให้คุณแยกจุดสิ้นสุดจากออฟเซ็ตก่อนแก้ไขเส้นทาง คำสั่งโค้งจะแสดงสามจุด ส่วนเส้นตรงในไฟล์นี้แสดงแค่หนึ่งจุด

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

รายการนี้มีจุดเริ่มต้น, เส้นตรงคงที่ที่จบที่ (0.25, 0), และคำสั่ง End

### **เปลี่ยนจุดสิ้นสุด**

เปิด `motion.pptx` และแทนที่อาเรย์จุดของเส้นเพื่อย้ายจุดสิ้นสุด

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้นและดัชนี 1 คือเส้น การแทนที่จุดเดียวของเส้นจะเปลี่ยนปลายทางโดยไม่เปลี่ยนประเภทคำสั่ง, การกำหนดเวลา, หรือตำแหน่งในคอลเลกชัน เนื่องจากคำสั่งใช้พิกัดคงที่ คู่ใหม่จึงระบุตำแหน่งแทนการเพิ่มออฟเซ็ต

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เส้นใน `motion-endpoint.pptx` จบที่ (0.4, 0.1); ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

### **แทนที่ส่วน**

ใช้ [insert](https://reference.aspose.com/slides/th/python-java/aspose.slides/motionpath/#insert) และ [removeAt](https://reference.aspose.com/slides/th/python-java/aspose.slides/motionpath/#removeAt) เพื่อแทนที่เส้นใน `motion.pptx` การแทรกเลื่อนเส้นเดิมไปที่ดัชนี 2

นี่แสดงการแทนที่อ็อบเจกต์คำสั่ง แทนการแก้ไขพิกัดที่มีอยู่ หลังการแทรก คอลเลกชันชั่วคราวจะมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเก่า, และคำสั่ง End การลบดัชนี 2 จะทิ้งเส้นเก่าและเหลือเส้นทางใหม่ไว้

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เส้นที่บันทึกยังคงมีสามคำสั่ง โดยเส้นใหม่จบที่ (0.2, 0.1) และคำสั่ง End อยู่สุดท้าย

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีของพฤติกรรม ให้เลือกโดยประเภท ตัวอย่างนี้เปิด `rotation.pptx`, ค้นหา [RotationEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/rotationeffect/) เปลี่ยนมุม และตรวจสอบค่าที่บันทึกหลังเปิดใหม่

การตรวจสอบประเภททำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน การโหลดครั้งที่สองอ่านไฟล์ที่บันทึกลงในออบเจกต์การนำเสนอแยกกัน ดังนั้นการเปรียบเทียบตรวจสอบข้อมูลที่คงอยู่จริง ไม่ใช่ค่าที่ยังอยู่ในหน่วยความจำ ตัวอย่างนี้ยังสมมติว่าเอฟเฟกต์ที่รู้จักเป็นอันแรกใน sequence หลัก; การเลือกพฤติกรรมตามประเภทไม่ได้ระบุตำแหน่งเอฟเฟกต์ที่ถูกต้องในงานนำเสนอใด ๆ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

ผลลัพธ์คือ `Rotation preserved: True` ใช้รูปแบบการตรวจสอบประเภทเดียวกันกับพฤติกรรมอื่น ๆ สำหรับการตรวจสอบการคงสภาพอย่างสมบูรณ์ ให้เปรียบเทียบรูปทรงเป้าหมาย, เอฟเฟกต์, ชนิดและลำดับพฤติกรรม, การกำหนดเวลา, และคำสั่งเส้นทาง ใช้ความคลาดเคลื่อนเชิงตัวเลขสำหรับค่าจุดทศนิยม สำหรับการนำเสนอที่มีรูปแบบแอนิเมชันไม่ทราบ ให้ดูที่ [อ่านการเคลื่อนไหวของรูปทรง](/slides/th/python-java/shape-animation/#read-shape-animations) เพื่อท่อง sequence หลักและ interactive sequences

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [BehaviorCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/behaviorcollection/) คือลำดับที่จัดเก็บของการดำเนินการในเอฟเฟกต์ ไม่ใช่รายการเล่นที่พฤติกรรมแต่ละตัวรอให้ก่อนหน้าเสร็จ การกำหนดเวลาและเอฟเฟกต์ที่ห่อหุ้มกำหนดการจัดตาราง พฤติกรรมอาจทับซ้อนกัน และการดำเนินการบนแอตทริบิวต์เดียวกันอาจมีปฏิสัมพันธ์ผ่าน [getAdditive](https://reference.aspose.com/slides/th/python-java/aspose.slides/behavior/#getAdditive) และ [getAccumulate](https://reference.aspose.com/slides/th/python-java/aspose.slides/behavior/#getAccumulate) อย่าใช้การจัดลำดับคอลเลกชันอย่างเดียวเพื่อจัดตาราง “ย้ายแล้วหมุน” ให้ใช้การกำหนดเวลาชัดเจนหรือเอฟเฟกต์แยกตามที่อธิบายใน[การเคลื่อนไหวของรูปทรง](/slides/th/python-java/shape-animation/)

ประเภทและ subtype ของเอฟเฟกต์ ([getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getType) และ [getSubtype](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getSubtype)) บรรยายพรีเซ็ตของมัน ไม่ใช่คำอธิบายเต็มของต้นไม้พฤติกรรมที่แก้ไขแล้ว เลือกพรีเซ็ตและ subtype ก่อนปรับพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และลบการดำเนินการที่กำหนดเองของคุณ ตัวอย่างเช่น การเปลี่ยนเอฟเฟกต์ Spin ที่กำหนดเองเป็น Fade อาจแทนที่พฤติกรรมการหมุนด้วยพฤติกรรม set และ filter ตรวจสอบคอลเลกชันหลังจากเปลี่ยนพรีเซ็ตหรือ subtype การล้างพฤติกรรมพรีเซ็ตอาจลบการดำเนินการการมองเห็นหรือการเริ่มต้นที่พรีเซ็ตต้องการ ตัวอย่างใช้รูปที่มองเห็นได้และแทนที่พฤติกรรม; พวกมันไม่ได้สร้างต้นแบบของพรีเซ็ตทั้งหมดใหม่

## **ความเข้ากันได้ของรูปแบบ**

ต้นไม้พฤติกรรมที่คงไว้ไม่รับประกันการเล่นที่เหมือนกันในทุกโปรแกรมดูหรือเรนเดอร์เมอร์ ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| รูปแบบหรือผลลัพธ์ | สิ่งที่ต้องตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นรูปแบบหลักสำหรับตัวอย่างนี้ เปิดใหม่เพื่อยืนยันต้นไม้พฤติกรรมที่แก้ไขได้ แล้วตรวจสอบการเล่นในเวอร์ชัน PowerPoint ที่ต้องการ |
| PPT | ตัวแทนไบนารีแบบเก่าอาจแตกต่างจาก PPTX ทดสอบรอบบันทึก‑เปิดใหม่และการเล่น; อย่าอ้างอิงการสนับสนุนทุกการผสมผสานจากผลลัพธ์ PPTX เพียงอย่างเดียว |
| PDF, PNG, JPEG, และภาพสไลด์สแตติกอื่น ๆ | มีการแสดงสไลด์แบบสแตติก ไม่ใช่ไทม์ไลน์พฤติกรรมที่เล่นได้หรือกรอบแอนิเมชันสุดท้ายที่รับประกัน |
| [HTML5](/slides/th/python-java/export-to-html5/) | สามารถเล่นแอนิเมชันที่สนับสนุนเมื่อเปิดใช้การเคลื่อนไหวของรูปทรงในตัวเลือกการส่งออก ทดสอบการผสมผสานแบบกำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/python-java/convert-powerpoint-to-animated-gif/) | เก็บเฟรมที่เรนเดอร์ ไม่ใช่พฤติกรรมที่แก้ไขได้หรือการโต้ตอบที่เปิดโดยคลิก ตรวจสอบการเคลื่อนที่ที่เรนเดอร์จริง |
| [Video](/slides/th/python-java/convert-powerpoint-to-video/) | เรนเดอร์เฟรมนิเมชันและเข้ารหัสเป็นวิดีโอ การสนับสนุนจำกัดอยู่ที่ [แอนิเมชันและเอฟเฟกต์ที่สนับสนุน](/slides/th/python-java/convert-powerpoint-to-video/#supported-animations-and-effects); คำสั่งและเหตุการณ์โต้ตอบไม่กลายเป็นไทม์ไลน์ที่แก้ไขได้ |

## **คำถามที่พบบ่อย**

**ทำไมเอฟเฟกต์ของฉันจึงมีพฤติกรรมอยู่ก่อนที่ฉันจะเพิ่มอะไรเลย?**

การสร้างเอฟเฟ็กต์ที่กำหนดล่วงหน้าอาจสร้างการดำเนินการพื้นฐานของมัน ตรวจสอบก่อนตัดสินใจว่าจะขยายพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปยังตำแหน่งเริ่มต้นทำให้มันเล่นก่อนหรือไม่?**

ไม่จำเป็น ลำดับคอลเลกชันไม่ใช่ตัวแทนของการกำหนดเวลา ตรวจสอบการหน่วงเวลา, ระยะเวลา, และปฏิสัมพันธ์ระหว่างการดำเนินการบนแอตทริบิวต์เดียวกัน

**ทำไมคำสั่ง End ถึงไม่มีจุด?**

มันเป็นเครื่องหมายจบเส้นทางและไม่ต้องการพิกัด ตรวจสอบอาเรย์จุดเป็น null เมื่ออ่านเส้นทางจากไฟล์

**การทำรอบครบวงจรสำเร็จถือว่าเพียงพอที่จะยืนยันการเล่นหรือไม่?**

ไม่ การเปิดใหม่ยืนยันการคงสภาพของคุณสมบัติที่คุณตรวจสอบ ทดสอบโปรแกรมผู้เล่นสไลด์โชว์หรือการส่งออกแบบแอนิเมชันแยกต่างหลาดเพื่อยืนยันพฤติกรรมเชิงภาพของมัน