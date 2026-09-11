---
title: ใช้การเคลื่อนไหวของรูปร่างในงานนำเสนอด้วย Python ผ่าน Java
linktitle: การเคลื่อนไหวของรูปร่าง
type: docs
weight: 60
url: /th/python-java/shape-animation/
keywords:
- รูปร่าง
- การเคลื่อนที่
- เอฟเฟกต์
- รูปร่างเคลื่อนไหว
- ข้อความเคลื่อนไหว
- เพิ่มการเคลื่อนที่
- รับการเคลื่อนที่
- สกัดการเคลื่อนที่
- เพิ่มเอฟเฟกต์
- รับเอฟเฟกต์
- สกัดเอฟเฟกต์
- เสียงเอฟเฟกต์
- ใช้การเคลื่อนที่
- PowerPoint
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่ม, ตรวจสอบ, และปรับแต่งการเคลื่อนไหวของรูปร่าง, เวลา, เสียง, พฤติกรรมหลังการเคลื่อนไหว, และข้อความเคลื่อนไหวด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Python via Java แสดงการเคลื่อนที่ของสไลด์เป็นเอฟเฟกต์ในไทม์ไลน์ของสไลด์. เอฟเฟกต์หนึ่งมีรูปทรงเป้าหมาย, ประเภทและชนิดย่อยของการเคลื่อนที่, ตัวกระตุ้น, การตั้งค่าเวลา, และคุณสมบัติเสริมเช่น เสียงหรือพฤติกรรมหลังการเคลื่อนที่.

ไทม์ไลน์มีสองประเภทของลำดับ:

- **ลำดับหลัก** เล่นเมื่อสไลด์ดำเนินไป.
- **ลำดับเชิงโต้ตอบ** เริ่มเมื่อคลิกที่รูปทรงตัวกระตุ้น.

เนื่องจากกล่องข้อความ, รูปภาพ, แผนภูมิ, ตารางและวัตถุสไลด์อื่น ๆ สืบทอดจาก [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/), คุณใช้เมธอด [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) เดียวกันสำหรับเนื้อหาสไลด์ส่วนใหญ่. เอฟเฟกต์ที่มีให้ดูได้ในคลาส [EffectType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttype/).

## **เพิ่มการเคลื่อนที่ของรูปทรง**

เพื่อเพิ่มการเคลื่อนที่, รับลำดับหลักของสไลด์และเรียก [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) พร้อมรูปทรงเป้าหมาย, ประเภทเอฟเฟกต์, ชนิดย่อยและตัวกระตุ้น. สำหรับเอฟเฟกต์ที่เริ่มเมื่อคลิกรูปทรงอื่น, สร้างลำดับเชิงโต้ตอบที่ตัวกระตุ้นคือรูปทรงนั้น.

ตัวอย่างต่อไปนี้สร้างการเคลื่อนที่ทั้งสองประเภทและบันทึกผลลัพธ์เป็น `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ตัวกระตุ้นกำหนดว่าเอฟเฟกต์เริ่มเมื่อใด:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttriggertype/#OnClick) รอการคลิกในลำดับหลัก, หรือการคลิกบนรูปทรงตัวกระตุ้นในลำดับเชิงโต้ตอบ.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttriggertype/#WithPrevious) เริ่มพร้อมกับเอฟเฟกต์ก่อนหน้า.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/th/python-java/aspose.slides/effecttriggertype/#AfterPrevious) เริ่มเมื่อเอฟเฟกต์ก่อนหน้าสิ้นสุด.

เพื่อเคลื่อนที่รูปภาพ, แผนภูมิ หรือรูปทรงประเภทอื่น, ส่งออบเจ็กต์นั้นไปยัง [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) แทน `target_shape`. สำหรับตัวเลือกการจัดกลุ่มเฉพาะแผนภูมิ, ดู [Animated Charts](/slides/th/python-java/animated-charts/).

## **อ่านการเคลื่อนที่ของรูปทรง**

ใช้ [Sequence.getEffectsByShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#getEffectsByShape) เมื่อคุณทราบรูปทรงเป้าหมาย. หากต้องตรวจสอบทุกเอฟเฟกต์, ให้ทำการวนซ้ำลำดับหลักและลำดับเชิงโต้ตอบทุกลำดับ. การวนซ้ำช่วยหลีกเลี่ยงการสันนิษฐานว่าลำดับมีเอฟเฟกต์ที่ดัชนี `0`.

ตัวอย่างต่อไปนี้สร้างรูปทรงที่มีเอฟเฟกต์ลำดับหลักและเชิงโต้ตอบ, ดึงเอฟเฟกต์ที่เป้าหมายเป็นรูปทรงนั้น, แล้ววนซ้ำทุกลำดับบนสไลด์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

หากคุณต้องการเอฟเฟกต์สำหรับรูปทรงเดียว, ให้ระบุตัวรูปทรงโดยชื่อ, ประเภท placeholder, หรือคุณสมบัติที่คงที่อื่น ๆ; จากนั้นเรียก [Sequence.getEffectsByShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#getEffectsByShape). อย่าสันนิษฐานว่า [ShapeCollection.get_Item](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#get_Item) ที่ดัชนี `0` เป็นออบเจ็กต์ที่ต้องการเสมอ.

## **ทำงานกับเอฟเฟกต์ Placeholder ที่สืบทอด**

Placeholder บนสไลด์ปกติสามารถสืบทอดพฤติกรรมการเคลื่อนที่จาก placeholder ที่สอดคล้องบนสไลด์เลเอาต์และสไลด์มาสเตอร์. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getBasePlaceholder) จะคืนค่า placeholder พาเรนต์นั้น, หรือ `None` หากไม่มีพาเรนต์.

ในตัวอย่างงานนำเสนอต่อไปนี้, ส่วนท้าย (footer) มี **Random Bars** บนสไลด์ปกติ, **Split** บนสไลด์เลเอาต์, และ **Fly In** บนสไลด์มาสเตอร์.

![เอฟเฟกต์การเคลื่อนที่ของ Footer บนสไลด์ปกติ](slide-shape-animation.png)

![เอฟเฟกต์การเคลื่อนที่ของ Footer Placeholder บนสไลด์เลเอาต์](layout-shape-animation.png)

![เอฟเฟกต์การเคลื่อนที่ของ Footer Placeholder บนสไลด์มาสเตอร์](master-shape-animation.png)

ตัวอย่างต่อไปใช้โครงสร้าง hierarchy ของ placeholder จากงานนำเสนอโฉมใหม่. มันเพิ่มเอฟเฟกต์ให้กับ placeholder ของมาสเตอร์, placeholder ของเลเอาต์, และ placeholder ที่สอดคล้องบนสไลด์ปกติ. ทุกการเรียก [Shape.getBasePlaceholder](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getBasePlaceholder) จะตรวจสอบก่อนนำรูปทรงที่คืนค่าไปใช้.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **เปลี่ยนแปลงเวลาการเคลื่อนที่**

กล่องโต้ตอบ **Timing** ของ PowerPoint สอดคล้องกับคุณสมบัติของ [Timing](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/).

![กล่องโต้ตอบ Timing ของ PowerPoint สำหรับเอฟเฟกต์การเคลื่อนที่](shape-animation.png)

- **Start** สอดคล้องกับ [Timing.getTriggerType](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getTriggerType).
- **Duration** สอดคล้องกับ [Timing.getDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getDuration) (เป็นวินาที).
- **Delay** สอดคล้องกับ [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getTriggerDelayTime) (เป็นวินาที).
- **Repeat** สอดคล้องกับ [Timing.getRepeatCount](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getRepeatUntilNextClick) หรือ [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** สอดคล้องกับ [Timing.getRewind](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#getRewind).

ตัวอย่างอิสระนี้เพิ่มเอฟเฟกต์, เปลี่ยนแปลงเวลาผ่านออบเจ็กต์ที่คืนจาก [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect), แล้วบันทึกผลลัพธ์. การเก็บอ้างอิงของ [Effect](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/) ที่คืนช่วยหลีกเลี่ยงการอ้างอิงดัชนีคอลเล็กชั่นที่ไม่จำเป็น.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ใช้โหมดการทำซ้ำแบบใดแบบหนึ่งเท่านั้น. การผสานจำนวนครั้งกับฟลัก “until” อาจทำให้ผลลัพธ์สับสนในโปรแกรมดูต่าง ๆ. เมื่อเปลี่ยนโหมดการทำซ้ำ, ให้ตั้งค่า [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#setRepeatUntilNextClick) และ [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) ก่อน [Timing.setRepeatCount](https://reference.aspose.com/slides/th/python-java/aspose.slides/timing/#setRepeatCount), เพราะการตั้งค่าใดฟลักหนึ่งจะเปลี่ยนโหมดการทำซ้ำที่ใช้งานอยู่ด้วย.

## **เพิ่มและดึงเสียงของการเคลื่อนที่**

เอฟเฟกต์การเคลื่อนที่สามารถอ้างอิงไฟล์เสียงฝังอยู่ผ่าน [Effect.getSound](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#setStopPreviousSound) บอกให้เอฟเฟกต์หยุดเสียงที่เริ่มโดยเอฟเฟกต์ก่อนหน้า.

### **เพิ่มเสียงให้กับเอฟเฟกต์**

ตัวอย่างต่อไปนี้คาดว่าจะมีไฟล์เสียงท้องถิ่นชื่อ `animation-sound.wav`. มันสร้างเอฟเฟกต์สองรายการ, ฝังไฟล์นั้นเป็นเสียงสำหรับเอฟเฟกต์แรก, และตั้งค่าให้เอฟเฟกต์ที่สองหยุดเสียง. ตัวอย่างใช้ออบเจ็กต์ที่คืนจาก [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect), ดังนั้นไม่ต้องระบุดัชนีลำดับ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ดึงเสียงเอฟเฟกต์ที่ฝังอยู่**

ตัวอย่างต่อไปนี้คาดว่าจะมีงานนำเสนอท้องถิ่นชื่อ `presentation-with-animation-sounds.pptx`. มันสแกนลำดับหลักและเชิงโต้ตอบ ทั้งหมดและเขียนเสียงเอฟเฟกต์ที่ฝังอยู่ทุกไฟล์ลงในไดเรกทอรี `extracted-animation-sounds`. นามสกุลไฟล์เลือกจาก MIME type ของเสียงที่ส่งกลับโดย [Audio.getContentType](https://reference.aspose.com/slides/th/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

สำหรับออบเจ็กต์เสียงขนาดใหญ่, ใช้ [Audio.getStream](https://reference.aspose.com/slides/th/python-java/aspose.slides/audio/#getStream) แล้วคัดลอกสตรีมไปยังไฟล์แทนการโหลดออบเจ็กต์ทั้งหมดเข้าสู่ array ของไบต์.

## **ตั้งค่าพฤติกรรมหลังการเคลื่อนที่**

ตัวเลือก **After animation** ควบคุมสิ่งที่จะเกิดขึ้นกับรูปทรงหลังจากเอฟเฟกต์สิ้นสุด.

![หน้าต่าง Options ของ PowerPoint แสดงการตั้งค่า After animation](shape-after-animation.png)

คลาส [AfterAnimationType](https://reference.aspose.com/slides/th/python-java/aspose.slides/afteranimationtype/) รองรับการปล่อยให้รูปทรงคงสภาพ, เปลี่ยนสี, ซ่อนหลังการเคลื่อนที่, หรือซ่อนเมื่อคลิกครั้งต่อไป. เมื่อประเภทเป็น [AfterAnimationType.Color](https://reference.aspose.com/slides/th/python-java/aspose.slides/afteranimationtype/#Color), ให้ตั้งค่า [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getAfterAnimationColor) ด้วย.

ตัวอย่างอิสระนี้สร้างเอฟเฟกต์, ตั้งค่าพฤติกรรมหลังการเคลื่อนที่ผ่านออบเจ็กต์เอฟเฟกต์ที่คืน, แล้วบันทึกผลลัพธ์.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

การเปลี่ยนประเภทจาก [AfterAnimationType.Color](https://reference.aspose.com/slides/th/python-java/aspose.slides/afteranimationtype/#Color) จะล้างการตั้งค่าสีหลังการเคลื่อนที่.

## **เคลื่อนที่ข้อความ**

การเคลื่อนที่ของข้อความมีการควบคุมสองอย่างที่เกี่ยวข้อง:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/th/python-java/aspose.slides/textanimation/#getBuildType) ควบคุมว่าข้อความย่อยปรากฏพร้อมกันหรือระดับย่อหน้า.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getAnimateTextType) ควบคุมว่าข้อความปรากฏทั้งหมดพร้อมกัน, ตามคำ, หรือตามตัวอักษร. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/th/python-java/aspose.slides/effect/#getDelayBetweenTextParts) ตั้งค่าความล่าช้าระหว่างคำหรืออักษร. ค่าเป็นบวกหมายถึงเปอร์เซ็นต์ของระยะเวลาของเอฟเฟกต์; ค่าเป็นลบหมายถึงความล่าช้าทีี่เป็นวินาที.

ตัวอย่างอิสระต่อไปนี้เคลื่อนที่คำในกล่องข้อความ. [BuildType.AsOneObject](https://reference.aspose.com/slides/th/python-java/aspose.slides/buildtype/#AsOneObject) ปิดการสร้างแบบย่อหน้าตามย่อหน้าเพื่อให้การตั้งค่าคำใช้กับเฟรมข้อความทั้งหมด.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เพื่อสร้างกล่องข้อความโดยย่อหน้า, ตั้งค่า [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/th/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (หรือระดับย่อหน้าอื่น). เพื่อกำหนดเอฟเฟกต์ให้กับย่อหน้าเดี่ยวที่มีเอฟเฟกต์ของตัวเอง, ใช้ overload ของ [Sequence.addEffect](https://reference.aspose.com/slides/th/python-java/aspose.slides/sequence/#addEffect) ที่รับ [Paragraph](https://reference.aspose.com/slides/th/python-java/aspose.slides/paragraph/). ดู [Animated Text](/slides/th/python-java/animated-text/) สำหรับตัวอย่างระดับย่อหน้า.

## **การส่งออกและบันทึกย่อข้อควรระวัง**

- การบันทึกเป็น PPT หรือ PPTX จะรักษาโมเดลการเคลื่อนที่, แต่การเล่นสุดท้ายขึ้นอยู่กับโปรแกรมดูงานนำเสนอ.
- PDF และภาพนิ่งจะไม่เล่นการเคลื่อนที่. ใช้ [HTML5 export](/slides/th/python-java/export-to-html5/), GIF เคลื่อนที่, หรือ [video conversion](/slides/th/python-java/convert-powerpoint-to-video/) เมื่อผลลัพธ์ต้องแสดงการเคลื่อนที่.
- สำหรับ HTML5, เปิดใช้งาน [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setAnimateShapes) และเมื่อจำเป็น, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/th/python-java/aspose.slides/html5options/#setAnimateTransitions).
- การเรนเดอร์วิดีโอสนับสนุนเอฟเฟกต์การเข้าสู่, เน้น, ออกจาก, และเส้นทางการเคลื่อนที่หลายแบบทั่วไป, แต่ไม่ได้สนับสนุนทุกเอฟเฟกต์ของ PowerPoint. ตรวจสอบ [supported animations and effects](/slides/th/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) ปัจจุบันและทดสอบงานนำเสนอที่สำคัญกับเวอร์ชัน Aspose.Slides ที่คุณใช้.
- เอฟเฟกต์แบบกำหนดเองขั้นสูงและเอฟเฟกต์ที่นำเข้าจากรูปแบบงานนำเสนออื่นอาจถูกเก็บในไฟล์แต่แสดงผลต่างกันใน PowerPoint, HTML5 หรือวิดีโอ. ตรวจสอบผลลัพธ์การส่งออกแทนการอิงแค่ชื่อเอฟเฟกต์.

## **FAQ**

**ทำไมการเคลื่อนที่จึงปรากฏใน PowerPoint แต่ไม่แสดงใน PDF?**

PDF เป็นรูปแบบนิ่ง, ดังนั้นการเคลื่อนที่และการเปลี่ยนสไลด์จะไม่เล่น. ส่งออกเป็น HTML5, GIF เคลื่อนที่, หรือวิดีโอเมื่อจำเป็นต้องรักษาการเคลื่อนที่.

**ทำไมเอฟเฟกต์จึงแสดงผลแตกต่างในวิดีโอ?**

การส่งออกวิดีโอเรนเดอร์การเคลื่อนที่แทนการเก็บพฤติกรรมดั้งเดิมของ PowerPoint. เอฟเฟกต์ขั้นสูงบางอย่างอาจไม่รองรับหรือถูกประมาณค่า. ตรวจสอบตารางเอฟเฟกต์ที่รองรับและทดสอบงานนำเสนอจริงก่อนใช้งานจริง.

**การย้ายรูปทรงไปข้างหน้าหรือข้างหลังจะเปลี่ยนลำดับการเคลื่อนที่หรือไม่?**

ไม่. การจัดลำดับ z-order ของรูปทรงควบคุมการซ้อนกัน, ส่วนลำดับของลำดับและตัวกระตุ้นควบคุมการเล่นการเคลื่อนที่. ปรับไทม์ไลน์หากต้องการลำดับการเล่นที่แตกต่าง.