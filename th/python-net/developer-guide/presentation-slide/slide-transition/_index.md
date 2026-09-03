---
title: "จัดการการเปลี่ยนสไลด์ในการนำเสนอด้วย Python"
linktitle: "การเปลี่ยนสไลด์"
type: docs
weight: 90
url: /th/python-net/slide-transition/
keywords:
- "การเปลี่ยนสไลด์"
- "เพิ่มการเปลี่ยนสไลด์"
- "ใช้การเปลี่ยนสไลด์"
- "การเปลี่ยนสไลด์ขั้นสูง"
- "การเปลี่ยน Morph"
- "ประเภทการเปลี่ยน"
- "เอฟเฟกต์การเปลี่ยน"
- "PowerPoint"
- "OpenDocument"
- "การนำเสนอ"
- "Python"
- "Aspose.Slides"
description: "ใช้การเปลี่ยนสไลด์, กำหนดค่าการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนอื่น ๆ ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET."
---
## **ภาพรวม**

การเปลี่ยนสไลด์กำหนดวิธีการแสดงสไลด์ระหว่างการนำเสนอ ด้วย Aspose.Slides for Python via .NET คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนสำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนหน้าโดยการคลิกเมาส์หรือโดยตัวจับเวลา และปรับตัวเลือกที่เฉพาะเจาะจงต่อเอฟเฟกต์ นี้เป็นบทความที่ใช้ตัวอย่าง Python เพื่อใช้การเปลี่ยน, กำหนดระยะเวลาเปลี่ยนที่แน่นอน, จัดการเวลาสไลด์, และสร้างการเปลี่ยน Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนสไลด์**

เพื่อใช้การเปลี่ยน, โหลดการนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และเข้าถึงคุณสมบัติ [slide_show_transition](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/slide_show_transition/) ของสไลด์ ตั้งค่า [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/type/) ให้เป็นค่าหนึ่งจากการนับจำนวน [TransitionType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitiontype/) แล้วบันทึกการนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Circle สำหรับสไลด์แรกและการเปลี่ยน Comb สำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **เพิ่มการเปลี่ยนสไลด์ขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์ค้างบนหน้าจอและว่าการคลิกเมาส์จะเลื่อนการนำเสนอหรือไม่ คุณสมบัติดังต่อไปนี้ควบคุมพฤติกรรมนี้:

- [advance_on_click](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) ให้ผู้ชมเลื่อนโดยการคลิกเมาส์
- [advance_after](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) เปิดการเลื่อนอัตโนมัติ
- [advance_after_time](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) ระบุการหน่วงก่อนการเลื่อนอัตโนมัติ, หน่วยเป็นมิลลิวินาที

เปิดใช้งานทั้งการคลิกและการเลื่อนตามเวลาเพื่อให้ผู้ชมสามารถเลื่อนด้วยคลิกหรือรอจนตัวจับเวลา ตัวเลือกนี้กำหนดการหน่วงเพื่อการเลื่อนของสไลด์ ไม่ได้ตั้งระยะเวลาของเอฟเฟกต์การเปลี่ยนเอง

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่าง ๆ ให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลัง 3, 5, และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้เช่นกัน ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

เพื่อเช็คว่าการเลื่อนตามเวลาถูกเปิดหรือไม่, อ่านค่า [advance_after](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) ค่าหน่วงที่เก็บไว้เพียงอย่างเดียวไม่แสดงว่าตัวจับเวลาใช้งานอยู่

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ด้านบน, รายงานตัวจับเวลาที่เปิดใช้งานแต่ละอัน, และปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีค่าหน่วงมากกว่าสองวินาที พร้อมเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าอัปเดต

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **ควบคุมระยะเวลาเปลี่ยนอย่างแม่นยำ**

ใช้ [duration](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/duration/) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนในหน่วยมิลลิวินาที คุณสมบัติ [slide_show_transition](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/slide_show_transition/) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/) :

| Property | Purpose |
| --- | --- |
| [duration](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | ตั้งระยะเวลาของเอฟเฟกต์การเปลี่ยนเอง, หน่วยเป็นมิลลิวินาที |
| [advance_after_time](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | ตั้งค่าหน่วงก่อนสไลด์เลื่อนอัตโนมัติ, หน่วยเป็นมิลลิวินาที. เปิดใช้งาน [advance_after](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) เพื่อให้ตัวจับเวลานี้ทำงาน |
| [speed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | เลือกประเภทความเร็วที่กำหนดไว้จาก [TransitionSpeed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM หรือ FAST. ใช้เมื่อไม่ได้กำหนดระยะเวลาอย่างแม่นยำ |

[duration](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยน; ไม่ได้กำหนดว่สไลด์จะคงอยู่บนหน้าจอนานเท่าใด ให้กำหนดการหน่วงการเลื่อนอัตโนมัติแยกต่างหาก เมื่อไม่มีการตั้งค่า duration ชัดเจน Aspose.Slides จะคำนวณระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนและค่า [speed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/speed/)

### **ใช้ระยะเวลาเดียวกันกับทุกสไลด์**

เพื่อให้จังหวะสม่ำเสมอ, ใช้เอฟเฟกต์และระยะเวลาที่เท่ากันกับทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx`, เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitiontype/), ตั้งระยะเวลาให้ทุกการเปลี่ยนเป็น 750 มิลลิวินาที พร้อมเปิดการเลื่อนอัตโนมัติหลัง 5,000 มิลลิวินาทีและปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # กำหนดการเลื่อนอัตโนมัติอย่างอิสระจากระยะเวลาเอฟเฟกต์.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **ตั้งระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่ต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนสั้นสำหรับสไลด์หัวเรื่องและการเปลี่ยนยาวสำหรับการแนะนำส่วน ตัวอย่างนี้ตั้ง 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1,200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **ประสานการเปลี่ยนกับ Output แบบเคลื่อนไหว**

เมื่อเตรียม [animated GIF](/slides/th/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/python-net/export-to-html5/), หรือ [video](/slides/th/python-net/convert-powerpoint-to-video/), ตั้งระยะเวลาเปลี่ยนที่แน่นอนก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การจาง 600 มิลลิวินาทีระหว่างฉาก และปรับหน่วงการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาสำหรับการบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ, ประสานอัตราเฟรมของ output กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5, เปิดการเปลี่ยนแบบเคลื่อนไหวในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาที่รองรับของรูปแบบการส่งออกที่เลือก และดูตัวอย่าง output เพื่อยืนยันการซิงโครไนซ์

### **อ่านระยะเวลาเปลี่ยนที่มีอยู่**

อ่านค่า [duration](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ก่อนแก้ไขการเปลี่ยนเพื่อพิจารณาว่ามีค่าที่กำหนดไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการตั้งค่า duration อย่างชัดเจน; ค่าที่เป็นจำนวนเต็มบวกหรือศูนย์คือระยะเวลาที่เก็บไว้ในหน่วยมิลลิวินาที ค่าที่ไม่ได้ตั้งไม่ใช่ระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนและค่า [speed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/speed/) เพื่อคำนวณระยะเวลานั้น การตั้งค่าชนิดการเปลี่ยนอาจทำให้มีการกำหนดค่า duration เริ่มต้น ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **การเปลี่ยน Morph**

การเปลี่ยน Morph ทำให้วัตถุเปลี่ยนแปลงระหว่างสไลด์ต่อเนื่อง เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย, คัดลอกสไลด์, ย้ายหรือปรับขนาดวัตถุบนสไลด์สำเนา, แล้วใช้การเปลี่ยน Morph กับสไลด์ที่สอง นี้ทำให้วัตถุที่เกี่ยวข้องถูกทำแอนิเมชันจากสถานะเดิมไปยังสถานะที่แก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ, คัดลอกสไลด์, แล้วเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จากการนับจำนวน [TransitionType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในโปรแกรมแสดงผลที่รองรับ Morph เพื่อดูเอฟเฟกต์ขณะนำเสนอ

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **ประเภทการเปลี่ยน Morph**

การนับจำนวน [TransitionMorphType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และทำแอนิเมชันเนื้อหา:

- [BY_OBJECT](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionmorphtype/) ปฏิบัติต่อแต่ละรูปร่างเป็นวัตถุทั้งหมด
- [BY_WORD](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionmorphtype/) ทำแอนิเมชันข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [BY_CHAR](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionmorphtype/) ทำแอนิเมชันข้อความโดยจับคู่อักขระเมื่อเป็นไปได้

ตั้งค่า [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/type/) ของการเปลี่ยนเป็น Morph ก่อนเข้าถึง [value](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/value/). ค่าที่ได้จะให้วัตถุ [MorphTransition](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/morphtransition/), โดยคุณสมบัติ [morph_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/morphtransition/morph_type/) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดการนำเสนอที่สร้างในส่วนก่อนหน้าและกำหนดให้สไลด์ที่สองใช้การแอนิเมชัน Morph ตามคำ

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **ตั้งค่าเอฟเฟกต์การเปลี่ยน**

บางการเปลี่ยนเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่เอฟเฟกต์เริ่มจากหน้าจอสีดำ ตัวเลือกที่มีขึ้นอยู่กับ [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/type/) ที่เลือก ตั้งค่า type ก่อน, จากนั้นใช้วัตถุการเปลี่ยนที่เหมาะสมจาก [value](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/value/)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยน Cut กับสไลด์แรกของ `input.pptx`. มันตั้งค่า [from_black](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) ผ่าน [OptionalBlackTransition](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/optionalblacktransition/) เพื่อให้การเปลี่ยนเริ่มจากหน้าจอสีดำ

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนสไลด์ได้หรือไม่?**

ได้. ให้ใช้ [duration](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/duration/) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้ [speed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/speed/) เมื่อประเภท [TransitionSpeed](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionspeed/) ที่กำหนดไว้—SLOW, MEDIUM หรือ FAST—เพียงพอและไม่มีการตั้งค่า duration แบบชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนแยกจากการหน่วงเวลาการเลื่อนอัตโนมัติ

**ฉันสามารถใส่เสียงเข้ากับการเปลี่ยนและทำให้วนซ้ำได้หรือไม่?**

ได้. กำหนดเสียงที่ฝังไว้ให้กับ [sound](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound/), ตั้งค่า [sound_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) เป็น START_SOUND จากการนับจำนวน [TransitionSoundMode](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitionsoundmode/), และเปิดใช้งาน [sound_loop](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). เสียงจะวนซ้ำจนกว่าจะมีเหตุการณ์เสียงถัดไปในการนำเสนอ

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเล็กชัน [slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) ของการนำเสนอและตั้งค่า [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/type/) ของการเปลี่ยนของแต่ละสไลด์ให้เป็นค่าที่เดียวกัน ตั้งค่าการจับเวลาและตัวเลือกเอฟเฟกต์ในลูปเดียวกันเพื่อให้พฤติกรรมสม่ำเสมอระหว่างสไลด์

**ฉันจะตรวจสอบว่าการเปลี่ยนใดถูกตั้งค่าในสไลด์ปัจจุบันได้อย่างไร?**

อ่านคุณสมบัติ [type](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/slideshowtransition/type/) จาก [slide_show_transition](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/slide_show_transition/) ของสไลด์ มันจะคืนค่าจากการนับจำนวน [TransitionType](https://reference.aspose.com/slides/th/python-net/aspose.slides.slideshow/transitiontype/); NONE หมายถึงไม่มีเอฟเฟกต์การเปลี่ยนใดถูกนำมาใช้