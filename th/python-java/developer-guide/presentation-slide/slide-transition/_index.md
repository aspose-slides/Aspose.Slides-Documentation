---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอด้วย Python ผ่าน Java
linktitle: การเปลี่ยนสไลด์
type: docs
weight: 80
url: /th/python-java/slide-transition/
keywords:
- การเปลี่ยนสไลด์
- เพิ่มการเปลี่ยนสไลด์
- ใช้การเปลี่ยนสไลด์
- การเปลี่ยนสไลด์ขั้นสูง
- การเปลี่ยน Morph
- ประเภทการเปลี่ยน
- เอฟเฟกต์การเปลี่ยน
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ใช้การเปลี่ยนสไลด์ กำหนดการเลื่อนสไลด์อัตโนมัติ และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides for Python via Java."
---
## **ภาพรวม**

การเปลี่ยนภาพสไลด์ควบคุมวิธีการแสดงสไลด์ระหว่างการนำเสนอด้วยสไลด์โชว์ ด้วย Aspose.Slides for Python via Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ กำหนดการเปลี่ยนโดยคลิกเมาส์หรือด้วยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงกับเอฟเฟกต์ได้ บทความนี้ใช้ตัวอย่าง Python เพื่อทำการเปลี่ยนภาพ นับระยะเวลาการเปลี่ยนที่แม่นยำ จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนภาพสไลด์**

เพื่อใช้การเปลี่ยนภาพ โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) แล้วเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getSlideShowTransition) ใช้ [setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setType) พร้อมค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitiontype/) จากนั้นบันทึกงานนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยนแบบ Circle กับสไลด์แรกและการเปลี่ยนแบบ Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle)
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb)

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **เพิ่มการเปลี่ยนภาพสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอและว่าการคลิกเมาส์จะทำให้การนำเสนอเลื่อนไปข้างหน้าไหม วิธีต่อไปนี้ควบคุมพฤติกรรมดังกล่าว:

- [setAdvanceOnClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) อนุญาตให้ผู้ชมเลื่อนไปข้างหน้าด้วยการคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เปิดการเลื่อนไปข้างหน้าอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) กำหนดความหน่วงก่อนการเลื่อนไปข้างหน้าอัตโนมัติ หน่วยเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถกดคลิกเพื่อดำเนินการต่อหรือรอให้ตัวจับเวลาทำงาน หากต้องการใช้เฉพาะตัวจับเวลา ให้ส่ง `False` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ความหน่วงควบคุมเวลาที่การนำเสนอเลื่อนไปข้างหน้า; มันไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่างๆ ให้กับสไลด์สามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลังจาก 3, 5, และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้เช่นกัน ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 3:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Circle)
        first_transition.setAdvanceOnClick(True)
        first_transition.setAdvanceAfter(True)
        first_transition.setAdvanceAfterTime(3000)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Comb)
        second_transition.setAdvanceOnClick(True)
        second_transition.setAdvanceAfter(True)
        second_transition.setAdvanceAfterTime(5000)

        third_transition = presentation.getSlides().get_Item(2).getSlideShowTransition()
        third_transition.setType(TransitionType.Zoom)
        third_transition.setAdvanceOnClick(True)
        third_transition.setAdvanceAfter(True)
        third_transition.setAdvanceAfterTime(7000)

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) ค่าหน่วงที่จัดเก็บเพียงอย่างเดียวไม่ได้บ่งชี้ว่าตัวจับเวลาทำงานหรือไม่

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานตัวจับเวลาที่เปิดใช้งานแต่ละตัว และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความหน่วงมากกว่าสองวินาที แล้วเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าอัปเดต

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("advanced-transitions.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()

        if transition.getAdvanceAfter():
            print(f"Slide {slide.getSlideNumber()}: advance after {transition.getAdvanceAfterTime()} ms.")

            if transition.getAdvanceAfterTime() > 2000:
                transition.setAdvanceAfter(False)
                transition.setAdvanceOnClick(True)

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ควบคุมระยะเวลาการเปลี่ยนภาพอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setDuration) เพื่อกำหนดความยาวของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที เมธอด [getSlideShowTransition](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์เผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/) :

| เมธอด | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setDuration) | กำหนดระยะเวลาของเอฟเฟ็กต์การเปลี่ยนเองเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | กำหนดความหน่วงก่อนสไลด์เลื่อนไปข้างหน้าอัตโนมัติเป็นมิลลิวินาที ส่งค่า `True` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เพื่อเปิดใช้งานตัวจับเวลา |
| [setSpeed](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setSpeed) | เลือกประเภทความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitionspeed/) ได้แก่ Slow, Medium หรือ Fast ใช้เมื่อไม่มีการระบุระยะเวลาที่แน่ชัด |

[setDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setDuration) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; มันไม่ได้กำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอ กำหนดความหน่วงของการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งระยะเวลาชัดเจน Aspose.Slides จะคำนวณระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่าจาก [getSpeed](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#getSpeed)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสม่ำเสมอ ใช้เอฟเฟกต์และระยะเวลาที่แน่นอนเดียวกันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitiontype/) และให้การเปลี่ยนแต่ละรายการใช้ระยะเวลา 750 มิลลิวินาที พร้อมเปิดการเลื่อนอัตโนมัติหลังจาก 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกเป็นไฟล์ PPTX

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Fade)
        transition.setDuration(750)

        # กำหนดการเลื่อนอัตโนมัติโดยแยกจากระยะเวลาเอฟเฟกต์
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **ตั้งระยะเวลาที่แตกต่างสำหรับสไลด์แต่ละรายการ**

สไลด์ต่างๆ สามารถใช้ระยะเวลาของเอฟเฟกต์ที่แตกต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับการแนะนำส่วน ตัวอย่างนี้กำหนด 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType

presentation = Presentation("input.pptx")
try:
    if presentation.getSlides().size() >= 2:
        first_transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
        first_transition.setType(TransitionType.Fade)
        first_transition.setDuration(500)

        second_transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        second_transition.setType(TransitionType.Push)
        second_transition.setDuration(1200)

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx)
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

### **ประสานการเปลี่ยนกับผลลัพธ์แบบเคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/python-java/export-to-html5/), หรือ [video](/slides/th/python-java/convert-powerpoint-to-video/), ให้ตั้งระยะเวลาการเปลี่ยนที่แม่นยำก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การเฟด 600 มิลลิวินาทีระหว่างฉากและปรับความหน่วงของการเลื่อนไปข้างหน้าของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 เปิดใช้งานการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่รองรับของรูปแบบการส่งออกที่เลือกและพรีวิวผลลัพธ์เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#getDuration) ก่อนแก้ไขการเปลี่ยนเพื่อพิจารณาว่ามีค่าที่ระบุไว้หรือไม่ ค่าที่เป็น `-1` หมายถึงไม่มีการตั้งระยะเวลาที่ชัดเจน; ค่าที่เป็นเลขไม่ลบระบุระยะเวลาที่จัดเก็บเป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งไม่ได้เป็นระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่าจาก [getSpeed](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#getSpeed) เพื่อกำหนดระยะเวลานั้น การตั้งประเภทการเปลี่ยนอาจทำให้มีการกำหนดค่าเริ่มต้นไว้ ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        transition = slide.getSlideShowTransition()
        duration = transition.getDuration()

        if duration >= 0:
            print(f"Slide {slide.getSlideNumber()}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.getSlideNumber()}: no explicit duration; timing depends on transition type {transition.getType()} and speed {transition.getSpeed()}.")
finally:
    presentation.dispose()
```

## **การเปลี่ยน Morph**

การเปลี่ยน Morph ทำให้วัตถุระหว่างสไลด์ต่อเนื่องเคลื่อนที่หรือเปลี่ยนแปลงได้ เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้คัดลอกสไลด์หนึ่ง สลับตำแหน่งหรือเปลี่ยนขนาดวัตถุบนสำเนานั้น และใช้การเปลี่ยน Morph กับสไลด์ที่สอง นั่นจะทำให้วัตถุที่สัมพันธ์กันทำการเคลื่อนที่จากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ คัดลอกสไลด์นั้นและเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกไว้ในตัวดูงานนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการนำเสนอ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, ShapeType

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    rectangle = first_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100)
    rectangle.getTextFrame().setText("Morph transition")

    second_slide = presentation.getSlides().addClone(first_slide)
    moved_rectangle = second_slide.getShapes().get_Item(0)
    moved_rectangle.setX(moved_rectangle.getX() + 100)
    moved_rectangle.setY(moved_rectangle.getY() + 50)
    moved_rectangle.setWidth(moved_rectangle.getWidth() - 200)
    moved_rectangle.setHeight(moved_rectangle.getHeight() - 10)

    second_slide.getSlideShowTransition().setType(TransitionType.Morph)

    presentation.save("morph-transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ประเภทการเปลี่ยน Morph**

enumeration [TransitionMorphType](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และเคลื่อนที่เนื้อหา:

- [ByObject](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitionmorphtype/#ByObject) ถือรูปทรงแต่ละรูปเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitionmorphtype/#ByWord) เคลื่อนที่ข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitionmorphtype/#ByChar) เคลื่อนที่ข้อความโดยจับคู่ตัวอักษรเมื่อเป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#getValue) ค่าที่ได้จะเป็นอินสแตนซ์ของคลาส [MorphTransition](https://reference.aspose.com/slides/th/python-java/aspose.slides/morphtransition/) ที่มีเมธอด [setMorphType](https://reference.aspose.com/slides/th/python-java/aspose.slides/morphtransition/#setMorphType) เพื่อเลือกโหมดการจับคู่

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดสไลด์ที่สองให้ใช้การเคลื่อนที่ Morph ตามคำ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, TransitionMorphType, MorphTransition

presentation = Presentation("morph-transition.pptx")
try:
    if presentation.getSlides().size() >= 2:
        transition = presentation.getSlides().get_Item(1).getSlideShowTransition()
        transition.setType(TransitionType.Morph)
        transition_value = transition.getValue()

        if isinstance(transition_value, MorphTransition):
            morph_transition = transition_value
            morph_transition.setMorphType(TransitionMorphType.ByWord)
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
finally:
    presentation.dispose()
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setType) ตั้งค่าประเภทก่อนแล้วใช้คลาสที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#getValue)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` โดยเรียก [setFromBlack](https://reference.aspose.com/slides/th/python-java/aspose.slides/optionalblacktransition/#setFromBlack) ผ่านคลาส [OptionalBlackTransition](https://reference.aspose.com/slides/th/python-java/aspose.slides/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TransitionType, OptionalBlackTransition

presentation = Presentation("input.pptx")
try:
    transition = presentation.getSlides().get_Item(0).getSlideShowTransition()
    transition.setType(TransitionType.Cut)
    transition_value = transition.getValue()

    if isinstance(transition_value, OptionalBlackTransition):
        cut_transition = transition_value
        cut_transition.setFromBlack(True)
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx)
    else:
        print("Cut transition options are unavailable.")
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ให้ใช้ [setDuration](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setDuration) เมื่อคุณต้องการระยะเวลเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้ [setSpeed](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setSpeed) เมื่อต้องการเพียงหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitionspeed/) ได้แก่ Slow, Medium หรือ Fast และไม่มีการตั้งระยะเวลาที่ชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนโดยอิสระจากความหน่วงของการเลื่อนอัตโนมัติ

**ฉันสามารถแนบเสียงกับการเปลี่ยนและให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setSound) ส่งค่า `StartSound` จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setSoundMode) และเปิดใช้งาน [setSoundLoop](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setSoundLoop) ด้วยค่า `True` เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงต่อไปในสไลด์โชว์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getSlides) ของงานนำเสนอและเรียก [setType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#setType) ด้วยค่าที่เดียวกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ใดๆ ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งหมด

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งอยู่บนสไลด์ปัจจุบันได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/th/python-java/aspose.slides/slideshowtransition/#getType) บนผลลัพธ์ของ [getSlideShowTransition](https://reference.aspose.com/slides/th/python-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์นั้น จะส่งค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/th/python-java/aspose.slides/transitiontype/); `None_` หมายความว่าไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ