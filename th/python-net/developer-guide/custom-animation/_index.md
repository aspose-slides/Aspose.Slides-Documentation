---
title: สร้างและแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองใน Python
linktitle: แอนิเมชันแบบกำหนดเอง
type: docs
weight: 151
url: /th/python-net/custom-animation/
keywords:
- แอนิเมชันแบบกำหนดเอง
- พฤติกรรมแอนิเมชัน
- เส้นทางการเคลื่อนที่
- PowerPoint
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สร้าง, ตรวจสอบ, และแก้ไขพฤติกรรมแอนิเมชันแบบกำหนดเองและเส้นทางการเคลื่อนที่ที่แก้ไขได้ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

พฤติกรรมแอนิเมชันแบบกำหนดเองช่วยให้คุณควบคุมการดำเนินการแต่ละอย่างภายในเอฟเฟกต์แอนิเมชัน เช่น การเปลี่ยนสี การหมุนรูปทรง หรือการตามเส้นทางการเคลื่อนที่ที่แก้ไขได้ คู่มือนี้แสดงวิธีสร้างและรวมพฤติกรรม กำหนดการตั้งค่าเวลา ตรวจสอบและแก้ไขแอนิเมชันที่มีอยู่ และตรวจสอบว่าคุณสมบัติเก็บไว้หลังการบันทึกและเปิดงานนำเสนออีกครั้ง

สำหรับเอฟเฟกต์ที่กำหนดไว้ล่วงหน้าและการเรียกใช้ด้วยคลิก ดูที่ [Shape Animation](/slides/th/python-net/shape-animation/).

## **ทำความเข้าใจโมเดลแอนิเมชัน**

แอนิเมชันจัดโครงสร้างเป็น **Timeline → Sequence → Effect → Behaviors**:

- ไทม์ไลน์ของสไลด์ [timeline](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/timeline/) มีลำดับหลักและลำดับเชิงโต้ตอบ
- ลำดับ [Sequence](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/sequence/) ประกอบด้วยเอฟเฟกต์ ซึ่งอาจทำเป้าหมายกับรูปร่างต่างๆ
- เอฟเฟกต์ [Effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effect/) ระบุรูปร่างเป้าหมาย พรีเซ็ต ชนิดย่อย และเวลาของเอฟเฟกต์
- [Effect.behaviors](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effect/behaviors/) มีการดำเนินการที่นำเอฟเฟกต์ไปใช้: การเปลี่ยนสี การเคลื่อนย้าย การหมุน การตั้งค่าคุณสมบัติ ฯลฯ

## **สร้างพฤติกรรมแต่ละรายการ**

เรียกใช้ [Sequence.add_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/sequence/add_effect/) เพื่อสร้างเอฟเฟกต์และเข้าถึงคอลเลกชัน [behaviors](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effect/behaviors/) ของมัน พรีเซ็ตสามารถเติมคอลเลกชันนี้อัตโนมัติ อย่าลบการดำเนินการของพรีเซ็ตเมื่อขยายหรือใช้ [clear](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorcollection/clear/) หากต้องการแทนที่อย่างตั้งใจ

[BehaviorFactory](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/) สร้างพฤติกรรมแปดประเภทที่แสดงด้านล่าง การเคลื่อนที่จะอธิบายในส่วน [Build a Motion Path](#build-a-motion-path) ตัวอย่างการสร้างแต่ละอย่างเป็นโปรแกรมเต็ม; ตัวอย่างการแก้ไขต่อมาระบุไฟล์ผลลัพธ์ที่ใช้

### **การหมุน**

ใช้ [create_rotation_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) เพื่อสร้างการหมุน [by](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/rotationeffect/by/) ระบุมุมเชิงสัมพันธ์เป็นองศา; [from_address](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/rotationeffect/from_address/) และ [to](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/rotationeffect/to/) ระบุจุดเริ่มและสิ้นสุด

ตัวอย่างเริ่มด้วยเอฟเฟกต์ Spin แล้วแทนที่การดำเนินการของพรีเซ็ตด้วยพฤติกรรมการหมุนหนึ่งรายการ และกำหนดระยะเวลาการดำเนินการเป็นสองวินาที มุมเชิงสัมพันธ์ 90 องศาแสดงการหมุนหนึ่งในสี่จากการวางแนวเริ่มต้นของรูปทรง ดังนั้นไม่ต้องระบุมุมเริ่มต้นอย่างชัดเจน

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` มีรูปทรงหนึ่งรูปและพฤติกรรมการหมุนหนึ่งรายการ คอลเลกชัน เวลา และตัวอย่างการแก้ไขการหมุนด้านล่างใช้ไฟล์นี้

### **การปรับขนาด**

ใช้ [create_scale_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) พร้อมเปอร์เซ็นต์ X/Y: [from_address](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/scaleeffect/from_address/) และ [to](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/scaleeffect/to/) บรรยายขนาดเริ่มต้นและสิ้นสุด ส่วน [by](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/scaleeffect/by/) เป็นการเปลี่ยนแปลงเชิงสัมพันธ์ ที่นี่ค่า 100 หมายถึงขนาดดั้งเดิม

ตัวอย่างขยายทั้งสองมิติจาก 100% ไปเป็น 125% ภายในสองวินาที การใช้เปอร์เซ็นต์แนวนอนและแนวตั้งเท่ากันจะรักษาสัดส่วนของรูปทรง; เปอร์เซ็นต์ที่แตกต่างกันจะทำให้หนึ่งมิติลากยาวกว่ามิติอื่น

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **สี**

ใช้ [create_color_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) เพื่อเปลี่ยนสีเติมจากสีน้ำเงินเป็นสีส้ม [from_address](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/coloreffect/from_address/) และ [to](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/coloreffect/to/) เป็นสี; [by](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/coloreffect/by/) เป็นการเลื่อนสี [Behavior.properties](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behavior/properties/) ระบุแอตทริบิวต์ที่กำลังทำแอนิเมชัน

รูปร่างมีสีเติมแบบทึบตั้งค่าเป็นสีน้ำเงิน ซึ่งตรงกับสีเริ่มต้นของแอนิเมชัน การเลือกแอตทริบิวต์สีเติมบอกพฤติกรรมว่าต้องเปลี่ยนส่วนใดของรูปทรง; จุดสีเริ่มและสิ้นสุดเพียงอย่างเดียวไม่ได้ระบุแอตทริบิวต์นั้น เอฟเฟกต์ที่บันทึกบรรยายการเปลี่ยนเป็นสีส้มในระยะเวลาสองวินาที

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **ฟิลเตอร์**

ใช้ [create_filter_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) เพื่อเลือก wipe [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/filtereffect/subtype/), และ [reveal](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/filtereffect/reveal/) ระบุฟิลเตอร์ ทิศทาง และว่าจะเปิดเผยหรือซ่อนรูปทรงหรือไม่

ตัวอย่างนี้ตั้งค่า wipe ระยะเวลาสองวินาทีที่เปิดเผยรูปทรงโดยใช้ subtype ทิศทางขวา การตั้งค่าฟิลเตอร์เป็นของพฤติกรรมภายในเอฟเฟกต์ ดังนั้นจึงทำการตั้งค่าหลังจากลบการดำเนินการเดิมของพรีเซ็ตออกแล้ว

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **คุณสมบัติ**

ใช้ [create_property_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) เพื่อทำแอนิเมชันความทึบแสง [from_address](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/propertyeffect/to/), และ [by](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/propertyeffect/by/) เป็นสตริงที่ตีความด้วย [value_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/propertyeffect/value_type/) และ [calc_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/propertyeffect/calc_mode/) เลือกจุดสิ้นสุดหรือการเลื่อนเชิงสัมพันธ์แทนการตั้งค่าทั้งสามโดยไม่คำนึงถึงความเหมาะสม

ที่นี่แอตทริบิวต์ที่เลือกคือความทึบแสง และสตริงตัวเลขแทนการเปลี่ยนจากความทึบแสง 25% ไปเป็นความทึบแสงเต็ม การสอดคล้องเชิงเส้นอธิบายการเปลี่ยนแปลงอย่างค่อยเป็นค่อยไประหว่างค่าดังกล่าว เมื่อนำตัวอย่างนี้ไปใช้กับแอตทริบิวต์อื่น ให้เลือกค่า value_type และค่าจุดสิ้นสุดที่เหมาะสมกับแอตทริบิวต์นั้น

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **ตั้งค่า**

ใช้ [create_set_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) เพื่อกำหนดการมองเห็นผ่าน [to](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/seteffect/to/) พฤติกรรม set จะไม่ทำการสอดคล้องระหว่างจุดสิ้นสุด

ตัวอย่างเลือกแอตทริบิวต์การมองเห็นและกำหนดสตริง `visible` เมื่อพฤติกรรมทำงาน สี่เหลี่ยมรูปแบบนี้มองเห็นได้อยู่แล้วในงานนำเสนอที่เหลือนี้ ดังนั้นการกำหนดอาจไม่สร้างการเปลี่ยนแปลงที่เห็นได้ชัดเจนโดยลำพัง การดำเนินการเช่นนี้มีประโยชน์เมื่อนำเป็นส่วนหนึ่งของเอฟเฟกต์ที่ใหญ่ขึ้นซึ่งควบคุมว่ารูปร่างจะถูกซ่อนหรือแสดงเมื่อใด

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **คำสั่ง**

ใช้ [create_command_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) และกำหนด [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/commandeffect/command_string/), และ [shape_target](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/commandeffect/shape_target/). วางไฟล์บันทึกเสียง WAV ชื่อ `sample.wav` ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้ฝังไฟล์ด้วย [add_audio_frame_embedded](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) และแนบคำสั่งเล่นไปยัง audio frame

audio frame ทำหน้าที่เป็นเป้าหมายของเอฟเฟกต์และของคำสั่งด้วยกัน เชื่อมคำขอเล่นกับการบันทึกที่ฝังไว้; คำสั่งแบบสตริงอย่างเดียวไม่บ่งบอกว่าออบเจกต์สื่อใดควรถูกควบคุม เอฟเฟกต์ถูกกำหนดให้เริ่มเมื่อคลิกระหว่างการสไลด์โชว์

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

การบันทึกจะเก็บคำสั่งใน `command.pptx` แต่จะไม่เล่นการบันทึก การเล่นต้องใช้โปรแกรมสไลด์โชว์ที่รองรับคำสั่งและออบเจกต์สื่อที่กำหนด

## **จัดการคอลเลกชันพฤติกรรม**

[BehaviorCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorcollection/) รองรับ [add](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorcollection/remove/), และ [remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorcollection/remove_at/). ตัวอย่างนี้เปิด `rotation.pptx` เพิ่มการย่อขนาด ย้ายมันก่อนการหมุน และลบการหมุน การลบและแทรกออบเจกต์เดียวกันทำให้ตำแหน่งที่เก็บเปลี่ยนโดยไม่สร้างสำเนา

ลำดับการแก้ไขเปลี่ยนคอลเลกชันจาก rotation–scale เป็น scale–rotation แล้วเป็น scale เท่านั้น ดัชนีอ้างอิงคอลเลกชันปัจจุบัน ดังนั้นการลบใช้ดัชนีใหม่ของการหมุนหลังการจัดเรียงใหม่ การนับสุดท้ายยืนยันว่าพฤติกรรมใดจะถูกบันทึก

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

ผลลัพธ์คือ `ScaleEffect` : มีเพียงการย่อขนาดเหลืออยู่ คอลเลกชันไม่ได้โดยตัวมันเองกำหนดให้พฤติกรรมทำงานติดต่อกัน ให้ทำความสะอาดคอลเลกชันเฉพาะเมื่อแทนที่การดำเนินการทั้งหมด

## **กำหนดการตั้งค่าเวลาพฤติกรรม**

[Behavior.timing](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behavior/timing/) แสดง [Timing](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/) แยกจาก [Effect.timing](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effect/timing/). เวลาเอฟเฟกต์กำหนดการดำเนินของเอฟเฟกต์โดยรวม; เวลาพฤติกรรมบรรยายการดำเนินการภายในเอฟเฟกต์นั้น

### **กำหนดระยะเวลา, ความล่าช้า, การทำซ้ำ และความเร่ง**

เปิด `rotation.pptx` และกำหนด [duration](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/duration/) และ [trigger_delay_time](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/trigger_delay_time/) เป็นวินาที จากนั้นกำหนด [repeat_count](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/accelerate/) และ [decelerate](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/decelerate/) เป็นส่วนของระยะเวลา; รักษาผลรวมไม่เกิน 1

ไฟล์อินพุตคือไฟล์ที่สร้างในตัวอย่างการหมุน โดยพฤติกรรมแรกเป็นการหมุน ตัวอย่างนี้เปลี่ยนเฉพาะเวลาของพฤติกรรมนั้น; มุม 90 องศายังคงอยู่ การแยกมุมและเวลาออกจากกันทำให้ปรับจังหวะได้ง่ายโดยไม่ต้องสร้างแอนิเมชันใหม่

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

พฤติกรรมใช้ระยะเวลาสองวินาที หน่วงครึ่งวินาที และทำซ้ำ 3 ครั้ง 20% แรกและท้ายของระยะเวลาใช้สำหรับความเร่งและความชะลอตามลำดับ

นโยบายการทำซ้ำอื่นรวมถึง [repeat_duration](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/repeat_until_end_slide/), และ [repeat_until_next_click](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/repeat_until_next_click/); เลือกหนึ่งนโยบายแทนการเปิดใช้ทั้งหมดพร้อมกัน [auto_reverse](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/timing/auto_reverse/) จะเล่นแอนิเมชันย้อนหลังจากผ่านไปข้างหน้า การเร่งและการชะลอใช้กับการเปลี่ยนแปลงต่อเนื่อง ไม่ใช่การกำหนดค่าตัดหรือคำสั่ง

## **สร้างเส้นทางการเคลื่อนที่**

ใช้ [create_motion_effect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) เพื่อสร้างการเคลื่อนที่ [from_address](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/to/), และ [by](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/by/) อธิบายพิกัดหรือการเลื่อนตามเปอร์เซ็นต์ สำหรับเส้นทางที่แก้ไขได้ ให้สร้าง [MotionPath](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motionpath/) แล้วกำหนดให้กับ [MotionEffect.path](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motionpath/) เก็บคำสั่งเส้นทาง

[MotionCommandPathType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioncommandpathtype/) เลือกการดำเนิน:

| คำสั่ง | จุด | ความหมาย |
| --- | --- | --- |
| MOVE_TO | หนึ่ง | ตั้งตำแหน่งเริ่มต้น |
| LINE_TO | หนึ่ง | ย้ายตามเส้นตรงไปยังจุดสิ้นสุด |
| CURVE_TO | สาม | ตามเส้นโค้งคิวบิกที่กำหนดด้วยจุดควบคุมสองจุดและจุดสิ้นสุด |
| CLOSE_LOOP | ไม่มี | กลับสู่ตำแหน่งเริ่มต้น |
| END | ไม่มี | สิ้นสุดเส้นทาง |

[MotionPathPointsType](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motionpathpointstype/) อธิบายลักษณะการแก้ไขจุด เช่น จุดมุมหรือจุดเรียบ ไม่ได้แทนที่ประเภทคำสั่ง ใช้ประเภทจุดโค้งสำหรับตัวอย่างโค้งด้านล่าง และประเภทจุดมุมสำหรับส่วนตรง

พิกัดเส้นทางนิรภัยตามมิติของสไลด์: การเคลื่อนที่ X 0.25 หมายถึงหนึ่งในสี่ของความกว้างสไลด์ ไม่ใช่ 0.25 จุด Y บวกลงด้านล่าง คำสั่งแน่นอนระบุตำแหน่งในระบบพิกัดของเส้นทาง; คำสั่งเชิงสัมพันธ์ระบุการเลื่อนจากตำแหน่งปัจจุบัน ซึ่งแยกจาก [origin](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/origin/) ที่เลือกกรอบอ้างอิงของเส้นทางและ [path_edit_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioneffect/path_edit_mode/) ที่ควบคุมการเคลื่อนที่ของเส้นทางเมื่อรูปทรงเคลื่อนที่

### **สร้างเส้นตรง**

สร้างพฤติกรรมการเคลื่อนที่ด้วยจุดเริ่มต้น หนึ่งส่วนตรง และคำสั่งจบ [MotionPath.add](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motionpath/add/) รับประเภทคำสั่ง จุดที่เกี่ยวข้อง ประเภทจุด และค่าสถานะพิกัดเชิงสัมพันธ์

คำสั่งเริ่มต้นกำหนด (0, 0) และเส้นตรงจบที่ (0.25, 0) ให้เส้นทางมีการเคลื่อนที่แนวนอนหนึ่งในสี่ของความกว้างสไลด์ คำสั่งจบไม่มีจุดพิกัด เมื่อกำหนดเส้นทางแล้ว การเพิ่มพฤติกรรมการเคลื่อนที่ไปยังเอฟเฟกต์จะเชื่อมเส้นทางนั้นกับสี่เหลี่ยม

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` มีพฤติกรรมการเคลื่อนที่หนึ่งรายการและสามคำสั่งเส้นทาง ตัวอย่างการแก้ไขไฟล์ต่อไปนี้ใช้โครงสร้างที่รู้จักนี้

### **เปรียบเทียบพิกัดแน่นอนและเชิงสัมพันธ์**

สองวัตถุเส้นทางนี้อธิบายเส้นทางเดียวกัน คำสั่งแน่นอนจบที่ (0.3, 0.1) คำสั่งเชิงสัมพันธ์เพิ่ม (0.1, 0.1) ไปยังตำแหน่งปัจจุบัน (0.2, 0)

ทั้งสองเส้นเริ่มที่ตำแหน่งเดียวกัน สำหรับเส้นเชิงสัมพันธ์ให้บวกค่า X และ Y offset กับตำแหน่งปัจจุบันเพื่อให้ได้จุดสิ้นสุด; สำหรับเส้นแน่นอนให้ใช้จุดสิ้นสุดโดยตรง การสลับค่าสถานะโดยไม่แปลงพิกัดจะทำให้เส้นทางต่างกัน

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

กำหนดเส้นทางใดเส้นทางหนึ่งให้กับพฤติกรรมการเคลื่อนที่เพื่อใช้ในงานนำเสนอ อาร์กิวเมนต์ Boolean สุดท้ายเลือกพิกัดเชิงสัมพันธ์สำหรับคำสั่งนั้น

### **แทนที่เส้นด้วยโค้ง**

เปิด `motion.pptx` แล้วแทนที่คำสั่งเส้นด้วยโค้งคิวบิก ให้ใส่จุดควบคุมสองจุดก่อน แล้วตามด้วยจุดสิ้นสุด

ตำแหน่งเริ่มต้นถูกกำหนดโดยคำสั่งก่อนหน้า จุดสองจุดแรกสร้างรูปร่างโค้ง ส่วนจุดที่สามเป็นจุดปลาย; พวกมันไม่ได้เป็นจุดปลายต่อเนื่องสามจุด การอัพเดตประเภทคำสั่ง, ประเภทจุดแก้ไข, และอาเรย์จุดพร้อมกันทำให้ส่วนโค้งสอดคล้องกับเรขาคณิตใหม่

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

เส้นทางใน `curve.pptx` ยังมีสามคำสั่ง แต่คำสั่งกลางตอนนี้กำหนดเป็นโค้ง

## **ตรวจสอบและแก้ไขเส้นทางที่บันทึกไว้**

แต่ละ [MotionCmdPath](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioncmdpath/) เปิดเผย [points](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioncmdpath/points_type/), และ [is_relative](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motioncmdpath/is_relative/). ตัวอย่างต่อไปนี้ใช้เส้นทางที่มีสามคำสั่งใน `motion.pptx`. สำหรับอินพุตใด ๆ ให้ค้นหาเอฟเฟกต์ที่ต้องการและตรวจสอบประเภทคำสั่งและจำนวนจุดก่อนแก้ไขโดยดัชนี

### **อ่านคำสั่งและพิกัด**

อ่านเส้นทางโดยไม่เปลี่ยนแปลง คำสั่ง End และ Close‑Loop ไม่ต้องการจุด จึงต้องรองรับอาเรย์จุด `None`

ผลลัพธ์จะจับคู่แต่ละคำสั่งกับค่าสถานะพิกัดเชิงสัมพันธ์ก่อนแสดงจุดของมัน ทำให้คุณแยกจุดสิ้นสุดจากออฟเซ็ตก่อนแก้ไขเส้นทาง โค้งจะมีสามจุด ส่วนเส้นตรงในไฟล์นี้มีเพียงหนึ่งจุด

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

รายการประกอบด้วยจุดเริ่มต้น, เส้นตรงแน่นอนที่จบที่ (0.25, 0), และคำสั่ง End

### **เปลี่ยนจุดสิ้นสุด**

เปิด `motion.pptx` แล้วแทนที่อาเรย์จุดของเส้นเพื่อย้ายจุดสิ้นสุด

ในไฟล์อินพุต ดัชนี 0 คือคำสั่งเริ่มต้น ดัชนี 1 คือเส้น การแทนที่อาเรย์จุดเดียวของเส้นจะเปลี่ยนตำแหน่งปลายโดยไม่เปลี่ยนประเภทคำสั่ง เวลา หรือดัชนีในคอลเลกชัน เนื่องจากคำสั่งใช้พิกัดแน่นอน คู่ใหม่จึงระบุตำแหน่งแทนการเพิ่มออฟเซ็ต

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

เส้นใน `motion-endpoint.pptx` จบที่ (0.4, 0.1); ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

### **แทนที่ส่วน**

ใช้ [insert](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motionpath/insert/) และ [remove_at](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/motionpath/remove_at/) เพื่อแทนที่เส้นใน `motion.pptx`. การแทรกทำให้เส้นเดิมย้ายไปยังดัชนี 2

นี่แสดงการแทนที่ออบเจกต์คำสั่งแทนการแก้ไขพิกัดเดิม หลังการแทรกคอลเลกชันชั่วคราวจะมีคำสั่งเริ่มต้น, เส้นใหม่, เส้นเก่า, และคำสั่ง End การลบดัชนี 2 จะทิ้งเส้นเก่าและเหลือเส้นใหม่เป็นเส้นทาง

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

เส้นทางที่บันทึกยังคงมีสามคำสั่ง โดยเส้นใหม่จบที่ (0.2, 0.1) และคำสั่ง End อยู่ท้ายสุด

## **แก้ไขและตรวจสอบพฤติกรรมที่มีอยู่**

เมื่อไม่ทราบดัชนีพฤติกรรม ให้เลือกโดยประเภท ตัวอย่างนี้เปิด `rotation.pptx` ค้นหา [RotationEffect](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/rotationeffect/), เปลี่ยนมุม และตรวจสอบค่าที่บันทึกหลังการเปิดใหม่

การตรวจสอบประเภททำให้ลูปข้ามพฤติกรรมที่ไม่ใช่การหมุน โหลดครั้งที่สองอ่านไฟล์ที่บันทึกลงในออบเจกต์การนำเสนอแยกต่างหาก จึงตรวจสอบข้อมูลที่คงอยู่แทนค่าที่ยังอยู่ในหน่วยความจำ ตัวอย่างนี้ยังคงสมมติว่าเอฟเฟกต์ที่รู้จักอยู่เป็นรายการแรกในลำดับหลัก; การเลือกพฤติกรรมโดยประเภทไม่ได้ค้นหาเอฟเฟกต์ที่ถูกต้องในงานนำเสนอใด ๆ

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

ผลลัพธ์คือ `Rotation preserved: True`. ใช้รูปแบบการตรวจสอบประเภทเดียวกันกับพฤติกรรมอื่น ๆ สำหรับการตรวจสอบการคงอยู่ครบถ้วน ให้เปรียบเทียบรูปร่างเป้าหมาย, เอฟเฟกต์, ประเภทและลำดับพฤติกรรม, เวลา, และคำสั่งเส้นทาง ใช้ความทนทานเชิงตัวเลขสำหรับค่าจุดทศนิยม สำหรับงานนำเสนอที่มีโครงสร้างแอนิเมชันไม่ทราบ ให้ดูที่ [Read Shape Animations](/slides/th/python-net/shape-animation/#read-shape-animations) เพื่อท่องลำดับหลักและลำดับเชิงโต้ตอบ

## **ลำดับพฤติกรรม, พรีเซ็ต, และการเล่น**

ลำดับใน [BehaviorCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behaviorcollection/) คือลำดับที่เก็บของการดำเนินงานเอฟเฟกต์ ไม่ใช่เพลย์ลิสต์ที่พฤติกรรมทุกอย่างรอคอยการทำงานของก่อนหน้า เวลาและเอฟเฟกต์ที่ล้อมรอบกำหนดตารางเวลา พฤติกรรมอาจทับซ้อนกัน และการดำเนินการบนคุณสมบัติเช่นเดียวกันอาจโต้ตอบผ่าน [additive](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behavior/additive/) และ [accumulate](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/behavior/accumulate/) อย่าใช้การจัดเรียงคอลเลกชันอย่างเดียวเพื่อกำหนด “ย้ายแล้วหมุน”; ใช้เวลาอย่างชัดเจนหรือเอฟเฟกต์แยกตามอธิบายใน [Shape Animation](/slides/th/python-net/shape-animation/)

ประเภท [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effect/type/) และ [subtype](https://reference.aspose.com/slides/th/python-net/aspose.slides.animation/effect/subtype/) ของเอฟเฟกต์บรรยายพรีเซ็ต ไม่ได้เป็นคำอธิบายสมบูรณ์ของต้นไม้พฤติกรรมที่แก้ไข ให้เลือกพรีเซ็ตและชนิดย่อยก่อนปรับแต่งพฤติกรรม: การเปลี่ยนพรีเซ็ตอาจสร้างคอลเลกชันใหม่และลบการดำเนินการที่คุณกำหนดเอง ตัวอย่างเช่น การเปลี่ยนเอฟเฟกต์ Spin ที่ปรับแต่งเป็น Fade อาจแทนที่พฤติกรรมการหมุนด้วยพฤติกรรม set และ filter ตรวจสอบคอลเลกชันอีกครั้งหลังจากเปลี่ยนพรีเซ็ตหรือ subtype การล้างพฤติกรรมพรีเซ็ตอาจลบการดำเนินการการมองเห็นหรือการเริ่มต้นที่พรีเซ็ตต้องการ ตัวอย่างใช้รูปทรงที่มองเห็นและแทนที่พฤติกรรม ไม่ได้สร้างการทำงานของพรีเซ็ตทั้งหมดใหม่

## **ความเข้ากันได้ของรูปแบบ**

ต้นไม้พฤติกรรมที่คงไว้ไม่รับประกันการเล่นที่เหมือนกันในทุกตัวอ่านหรือเรนเดอร์ออกเป็นรูปแบบ ตรวจสอบข้อมูลที่บันทึกและผลลัพธ์ที่เรนเดอร์แยกกัน

| รูปแบบหรือผลลัพธ์ | สิ่งที่ควรตรวจสอบ |
| --- | --- |
| PPTX | ใช้เป็นรูปแบบหลักสำหรับตัวอย่างเหล่านี้ เปิดใหม่เพื่อตรวจสอบต้นไม้พฤติกรรมที่แก้ไขได้ แล้วตรวจสอบการเล่นในเวอร์ชัน PowerPoint ที่ต้องการ |
| PPT | รูปแบบไบนารีเก่าอาจแตกต่างจาก PPTX ทดลองบันทึก‑เปิด‑เล่นแยกกัน อย่าเชื่อว่าทุกการผสมแบบกำหนดเองทำงานจากผลลัพธ์ PPTX เพียงอย่างเดียว |
| PDF, PNG, JPEG, และรูปภาพสไลด์คงที่อื่น ๆ | มีเฉพาะการแสดงสไลด์แบบคงที่ ไม่ได้มีไทม์ไลน์พฤติกรรมที่เล่นได้หรือเฟรมแอนิเมชันสุดท้ายที่รับประกัน |
| [HTML5](/slides/th/python-net/export-to-html5/) | สามารถเล่นแอนิเมชันที่รองรับได้เมื่อเปิดใช้งาน Shape Animation ในตัวเลือกการส่งออก ทดสอบการผสมแบบกำหนดเองในเบราว์เซอร์ |
| [Animated GIF](/slides/th/python-net/convert-powerpoint-to-animated-gif/) | เก็บเฟรมที่เรนเดอร์ ไม่ได้มีพฤติกรรมที่แก้ไขได้หรือการโต้ตอบเมื่อคลิก ตรวจสอบการเคลื่อนที่ที่เรนเดอร์จริง |
| [Video](/slides/th/python-net/convert-powerpoint-to-video/) | เรนเดอร์เฟรมแอนิเมชันและเข้ารหัสเป็นวิดีโอ การสนับสนุนจำกัดอยู่ที่ [supported animations and effects](/slides/th/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) ของเรนเดอร์; คำสั่งและเหตุการณ์เชิงโต้ตอบไม่กลายเป็นไทม์ไลน์ที่แก้ไขได้ |

## **คำถามที่พบบ่อย**

**ทำไมเอฟเฟกต์ของฉันถึงมีพฤติกรรมก่อนที่ฉันจะเพิ่มอะไรเข้าไป?**

การสร้างเอฟเฟกต์ที่กำหนดไว้ล่วงหน้าสามารถสร้างการดำเนินการพื้นฐานของมัน ตรวจสอบก่อนตัดสินใจว่าจะแก้ไขพรีเซ็ตหรือแทนที่พฤติกรรม

**การย้ายพฤติกรรมไปยังจุดเริ่มต้นทำให้มันเล่นก่อนหรือไม่?**

ไม่จำเป็น คอลเลกชันไม่ได้เป็นตัวแทนการกำหนดเวลา ตรวจสอบความล่าช้า, ระยะเวลา, และการโต้ตอบระหว่างการดำเนินการบนคุณสมบัติเช่นเดียวกัน

**ทำไมคำสั่ง End จึงไม่มีจุด?**

มันเป็นเครื่องหมายจบเส้นทางและไม่ต้องการพิกัด ตรวจสอบอาเรย์จุด `None` เมื่ออ่านเส้นทางจากไฟล์

**การทำรอบครบวงจรถือว่าเพียงพอเพื่อยืนยันการเล่นหรือไม่?**

ไม่ การเปิดใหม่เพียงยืนยันว่าคุณสมบัติที่ตรวจสอบยังคงอยู่ ต้องทดสอบตัวเล่นสไลด์โชว์หรือการส่งออกแบบแอนิเมชันแยกต่างหากเพื่อยืนยันพฤติกรรมภาพอย่างแท้จริง