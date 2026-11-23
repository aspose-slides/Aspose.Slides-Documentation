---
title: จัดการการเปลี่ยนสไลด์ในงานนำเสนอโดยใช้ Python ผ่าน Java
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
description: "ใช้การเปลี่ยนสไลด์, ตั้งค่าการดำเนินการสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Python ผ่าน Java."
---
## **ภาพรวม**

การเปลี่ยนสไลด์ควบคุมวิธีที่สไลด์ปรากฏระหว่างการแสดงสไลด์ ด้วย Aspose.Slides for Python via Java คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการดำเนินการต่อด้วยการคลิกเมาส์หรือไทม์เมอร์ และปรับตัวเลือกเฉพาะของเอฟเฟกต์ได้ บทความนี้ใช้ตัวอย่าง Python เพื่อใช้การเปลี่ยน ตั้งค่าขนาดระยะเวลาอันทันทีกของการเปลี่ยน จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยนภาพ, โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) และเข้าถึงการตั้งค่าการเปลี่ยนของสไลด์ผ่าน [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) ใช้ [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) กับค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) แล้วบันทึกการนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle กับสไลด์แรกและการเปลี่ยน Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

## **การเปลี่ยนแบบ Wheel**

ใช้ [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Wheel จาก [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) แล้วเรียก [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) เพื่อเข้าถึงการตั้งค่า [WheelTransition](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/) วิธี [setSpokes](https://reference.aspose.com/slides/python-java/aspose.slides/wheeltransition/#setSpokes) ควบคุมจำนวนเซกเตอร์รัศมีที่เปิดเผยสไลด์ปลายทาง

ตัวอย่างสร้างคู่สไลด์ที่เหมือนกันสองคู่ แต่ละคู่เริ่มด้วยสไลด์สีดำและจบด้วยสี่เหลี่ยมทองเต็มสไลด์ ทั้งสไลด์ปลายทางใช้ความเร็วช้าเดียวกันที่ตั้งด้วย [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) และระยะเวลา 8,000 มิลลิวินาทีที่ตั้งด้วย [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) เพียงจำนวนเส้นศูนย์เปลี่ยนเท่านั้น

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionSpeed, TransitionType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())
    height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())

    slides = presentation.getSlides()
    black_slide = slides.get_Item(0)
    black_slide.getShapes().clear()
    background = black_slide.getBackground()
    background.setType(BackgroundType.OwnBackground)
    background.getFillFormat().setFillType(FillType.Solid)
    background.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    destination_slide = slides.addClone(black_slide)
    rectangle = destination_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, width, height)
    rectangle.getFillFormat().setFillType(FillType.Solid)
    rectangle.getFillFormat().getSolidFillColor().setColor(Color(255, 215, 0))
    rectangle.getTextFrame().setText("Wheel transition")

    slides.addClone(black_slide)
    slides.addClone(destination_slide)
    for slide_index, spokes in ((1, 1), (3, 8)):
        transition = slides.get_Item(slide_index).getSlideShowTransition()
        transition.setType(TransitionType.Wheel)
        wheel_transition = transition.getValue()
        wheel_transition.setSpokes(spokes)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(8000)

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เปิด `wheel-transitions.pptx` ใน PowerPoint แล้วเริ่มการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 เพื่อดูการสแกนตามเข็มนาฬิกาที่เปิดเผยสี่เหลี่ยมทอง จากนั้นเลื่อนจากสไลด์ 3 ไปสไลด์ 4 เพื่อดูแปดเซกเตอร์รัศมีเปิดเผยสี่เหลี่ยมเดียวกันพร้อมกัน

## **Fade Through Black with the Reveal Transition**

ตั้งค่าประเภทการเปลี่ยนของสไลด์ปลายทางเป็น Reveal แล้วเรียก [setThroughBlack](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/#setThroughBlack) บนการตั้งค่า [RevealTransition](https://reference.aspose.com/slides/python-java/aspose.slides/revealtransition/) ตัวอย่างสร้างสไลด์แหล่งสีเทาและสไลด์ปลายทางสีโครล แล้วทำสำเนาทั้งสอง คู่แต่ละคู่ใช้การเปลี่ยน Reveal 2 วินาที คู่ที่สองจะค่อย ๆ จางผ่านสีดำ

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, PresetColor, Presentation, SaveFormat, ShapeType
from asposeslides.api import TransitionLeftRightDirectionType, TransitionSpeed, TransitionType


def style_slide(slide, background_color, label):
    slide.getBackground().setType(BackgroundType.OwnBackground)
    fill = slide.getBackground().getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setPresetColor(background_color)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130)
    shape.getTextFrame().setText(label)
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.getPortionFormat().setFontHeight(44)


presentation = Presentation()
try:
    source = presentation.getSlides().get_Item(0)
    destination = presentation.getSlides().addClone(source)
    style_slide(source, PresetColor.Teal, "Source")
    style_slide(destination, PresetColor.Coral, "Destination")

    presentation.getSlides().addClone(source)
    cloned_destination = presentation.getSlides().addClone(destination)
    for slide in (destination, cloned_destination):
        transition = slide.getSlideShowTransition()
        transition.setType(TransitionType.Reveal)
        transition.setSpeed(TransitionSpeed.Slow)
        transition.setDuration(2000)

        reveal = transition.getValue()
        reveal.setDirection(TransitionLeftRightDirectionType.Left)
        reveal.setThroughBlack(slide is cloned_destination)

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เปิด `reveal-transitions.pptx` ใน PowerPoint แล้วเริ่มการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 เพื่อดูสีเทาจางตรงเข้าสู่สีโครล จากนั้นเลื่อนจากสไลด์ 3 ไปสไลด์ 4 หน้าจอจะมืดลงเป็นสีดำใกล้เคียงก่อนที่สไลด์โครลจะปรากฏ สไลด์ทั้งสองยังคงสีพื้นหลังเดิม

แถวด้านล่างแสดงเฟรมจาก PowerPoint ทีละครึ่งวินาที เปรียบเทียบเฟรมกลางในแต่ละแถวเพื่อดูเอฟเฟกต์

![PowerPoint playback with fade through black disabled (top) and enabled (bottom). Only the bottom row passes through near black.](reveal-through-black.png)

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดว่าภาพสไลด์อยู่บนหน้าจอนานเท่าใดและว่าการคลิกเมาส์จะดำเนินการต่อหรือไม่ วิธีต่อไปนี้ควบคุมพฤติกรรมนี้:

- [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) อนุญาตให้ผู้ชมดำเนินการต่อโดยคลิกเมาส์
- [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เปิดใช้งานการดำเนินการอัตโนมัติ
- [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) ระบุความล่าช้าก่อนการดำเนินการอัตโนมัติ, หน่วยเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการดำเนินการตามเวลาเพื่อให้ผู้ชมสามารถดำเนินการต่อด้วยการคลิกหรือรอไทม์เมอร์ หากต้องการใช้เฉพาะไทม์เมอร์ ให้ส่งค่า `False` ไปยัง [setAdvanceOnClick](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) ความล่าช้ากำหนดเวลาเมื่อการแสดงสไลด์ดำเนินการต่อ; มันไม่กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่างกันให้กับสไลด์สามอันแรกและเปิดการดำเนินการอัตโนมัติหลัง 3, 5 และ 7 วินาทีตามลำดับ การคลิกเมาส์ยังสามารถดำเนินการต่อสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อเช็คว่าการดำเนินการตามเวลาถูกเปิดหรือไม่ ให้เรียก [getAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getAdvanceAfter) ค่าความล่าช้าที่เก็บไว้เพียงอย่างเดียวไม่บ่งบอกว่าไทม์เมอร์กำลังทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ข้างต้น รายงานไทม์เมอร์ที่เปิดใช้แต่ละอัน และปิดการดำเนินการอัตโนมัติสำหรับสไลด์ที่มีความล่าชุมากกว่าสองวินาที แล้วเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าใหม่

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

## **ควบคุมเวลาการเปลี่ยนอย่างแม่นยำ**

ใช้ [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนเป็นมิลลิวินาที เมธอด [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/):

| เมธอด | วัตถุประสงค์ |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนเอง, หน่วยเป็นมิลลิวินาที |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | กำหนดความล่าช้าก่อนสไลด์ดำเนินการต่ออัตโนมัติ, หน่วยเป็นมิลลิวินาที ส่งค่า `True` ไปยัง [setAdvanceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setAdvanceAfter) เพื่อเปิดใช้งานไทม์เมอร์นี้ |
| [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) | เลือกหมวดความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/): Slow, Medium หรือ Fast ใช้เมื่อไม่ได้ระบุระยะเวลาอย่างชัดเจน |

[setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; มันไม่ได้กำหนดระยะเวลาที่สไลด์คงอยู่บนจอ ตั้งค่าความล่าช้าการดำเนินการอัตโนมัติแยกต่างหาก เมื่อไม่มีการระบุระยะเวลาอย่างชัดเจน Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่าที่ได้จาก [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed)

<!-- visual-explanation:slide-transition:start -->
[![Separate bars identify the 750-ms transition duration and 5,000-ms automatic advancement setting.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างร่วมให้แต่ละสไลด์มีการเปลี่ยน Fade 750 ms และเปิดการดำเนินการอัตโนมัติที่ 5,000 ms แยกกัน ระยะเวลาการเปลี่ยนควบคุมเอฟเฟกต์; การดำเนินการควบคุมเมื่อออกจากสไลด์ แถบเหล่านี้เป็นการตั้งค่าเชิงสเกม ไม่ใช่ไทม์ไลน์ที่วัดได้จริง*
<!-- visual-explanation:slide-transition:end -->

### **ใช้ระยะเวลาเดียวกับทุกสไลด์**

เพื่อความเร็วที่สม่ำเสมอ ใช้เอฟเฟกต์และระยะเวลาที่เท่ากันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) และกำหนดระยะเวลา 750 ms ให้แต่ละการเปลี่ยน อีกทั้งเปิดการดำเนินการอัตโนมัติหลัง 5,000 ms และปิดการดำเนินการด้วยการคลิกเมาส์ แล้วบันทึกเป็นไฟล์ PPTX

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

        # กำหนดการเลื่อนอัตโนมัติโดยแยกจากระยะเวลาเอฟเฟกต์.
        transition.setAdvanceAfter(True)
        transition.setAdvanceAfterTime(5000)
        transition.setAdvanceOnClick(False)

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **กำหนดระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่างกันสามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับสไลด์บทนำ ตัวอย่างตั้งค่า 500 ms ให้สไลด์แรกและ 1,200 ms ให้สไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ปรับการเปลี่ยนให้สอดคล้องกับเอาต์พุตแบบแอนิเมชัน**

เมื่อเตรียม [animated GIF](/slides/th/python-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/python-java/export-to-html5/), หรือ [video](/slides/th/python-java/convert-powerpoint-to-video/), ตั้งค่าระยะเวลาการเปลี่ยนอย่างแม่นยำก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 ms ระหว่างฉาก และปรับความล่าช้าการดำเนินการของแต่ละสไลด์แยกต่างหากเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของเอาต์พุตกับระยะเวลาเอฟเฟกต์: 600 ms เท่ากับ 18 เฟรมที่ 30 fps ใน HTML5 ให้เปิดการเปลี่ยนแบบแอนิเมชันในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาในการส่งออกที่รองรับของรูปแบบที่เลือกและทำการพรีวิวเพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาการเปลี่ยนที่มีอยู่**

เรียก [getDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getDuration) ก่อนแก้ไขการเปลี่ยนเพื่อดูว่ามีค่าระยะเวลาที่กำหนดไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการตั้งค่าระยะเวลาอย่างชัดเจน; ค่าที่ไม่เป็นลบระบุระยะเวลาที่เก็บไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งไม่ได้หมายถึงระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่า [getSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getSpeed) เพื่อกำหนดระยะเวลานั้น การตั้งค่าประเภทการเปลี่ยนอาจเริ่มต้นค่าระยะเวลา ดังนั้นตรวจสอบการตั้งค่าเดิมก่อน

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

## **Morph Transition**

การเปลี่ยน Morph ทำให้วัตถุเปลี่ยนแปลงระหว่างสไลด์ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph ง่าย ๆ ให้ทำสำเนาสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง จะทำให้วัตถุที่สอดคล้องกันแอนิเมตจากสภาพเดิมไปสภาพที่แก้ไข

ตัวอย่างต่อไปสร้างสไลด์ที่มีสี่เหลี่ยมข้อความ ทำสำเนาสไลด์ และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จาก enumeration [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมแสดงสไลด์ที่รองรับ Morph เพื่อดูเอฟเฟกต์ขณะแสดงสไลด์

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

## **ประเภท Morph Transition**

enumeration [TransitionMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และแอนิเมตเนื้อหา:

- [ByObject](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByObject) จัดการแต่ละรูปร่างเป็นวัตถุทั้งหมด
- [ByWord](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByWord) แอนิเมตข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [ByChar](https://reference.aspose.com/slides/python-java/aspose.slides/transitionmorphtype/#ByChar) แอนิเมตข้อความโดยจับคู่ตัวอักษรเมื่อเป็นไปได้

ใช้ [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) เพื่อเลือก Morph ก่อนเข้าถึง [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue) ค่าที่ได้จะเป็นอินสแตนซ์ของคลาส [MorphTransition](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/) ซึ่งเมธอด [setMorphType](https://reference.aspose.com/slides/python-java/aspose.slides/morphtransition/#setMorphType) จะเลือกโหมดการจับคู่นั้น

ตัวอย่างนี้เปิดงานนำเสนอที่สร้างในส่วนก่อนหน้านี้และตั้งค่าสไลด์ที่สองให้ใช้การแอนิเมต Morph ตามคำ

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

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าเอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่ใช้ได้ขึ้นอยู่กับการเปลี่ยนที่เลือกด้วย [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) ตั้งค่าประเภทก่อน แล้วใช้คลาสที่เหมาะสมจาก [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getValue)

ตัวอย่างต่อไปใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx` เรียก [setFromBlack](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/#setFromBlack) ผ่าน [OptionalBlackTransition](https://reference.aspose.com/slides/python-java/aspose.slides/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

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

ได้. ควรใช้ [setDuration](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setDuration) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที หรือใช้ [setSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSpeed) เมื่อหมวดความเร็วที่กำหนดไว้ล่วงหน้าใน [TransitionSpeed](https://reference.aspose.com/slides/python-java/aspose.slides/transitionspeed/) (Slow, Medium, Fast) เพียงพอและไม่มีการกำหนดระยะเวลาชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนแยกจากความล่าช้าการดำเนินการอัตโนมัติ

**ฉันสามารถแนบเสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงฝังด้วย [setSound](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSound) ส่งค่า StartSound จาก enumeration [TransitionSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/transitionsoundmode/) ไปยัง [setSoundMode](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundMode) และเปิดใช้งาน [setSoundLoop](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setSoundLoop) ด้วย `True` เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงต่อไปในการแสดงสไลด์

**วิธีที่เร็วที่สุดในการใส่การเปลี่ยนเดียวกันให้กับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) ของงานนำเสนอและเรียก [setType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#setType) ด้วยค่าที่เหมือนกันสำหรับการเปลี่ยนของแต่ละสไลด์ ตั้งค่าการเวลาและตัวเลือกเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสอดคล้องกันทั่วทั้งสไลด์

**ฉันจะตรวจสอบว่าตอนนี้สไลด์ใช้การเปลี่ยนอะไรอยู่ได้อย่างไร?**

เรียก [getType](https://reference.aspose.com/slides/python-java/aspose.slides/slideshowtransition/#getType) บนผลลัพธ์ของเมธอด [getSlideShowTransition](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getSlideShowTransition) ของสไลด์ จะได้ค่าจาก enumeration [TransitionType](https://reference.aspose.com/slides/python-java/aspose.slides/transitiontype/) ค่าที่เป็น None_ หมายถึงไม่มีการใช้เอฟเฟกต์การเปลี่ยนใด ๆ