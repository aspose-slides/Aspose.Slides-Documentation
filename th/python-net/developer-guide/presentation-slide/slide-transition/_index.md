---
title: จัดการการเปลี่ยนภาพสไลด์ในการนำเสนอด้วย Python
linktitle: การเปลี่ยนภาพสไลด์
type: docs
weight: 90
url: /th/python-net/slide-transition/
keywords:
- การเปลี่ยนภาพสไลด์
- เพิ่มการเปลี่ยนภาพสไลด์
- ใช้การเปลี่ยนภาพสไลด์
- การเปลี่ยนภาพสไลด์ขั้นสูง
- การเปลี่ยนภาพ Morph
- ประเภทการเปลี่ยนภาพ
- เอฟเฟกต์การเปลี่ยนภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "ใช้การเปลี่ยนภาพสไลด์, กำหนดการเลื่อนสไลด์อัตโนมัติ, และปรับแต่ง Morph และเอฟเฟกต์การเปลี่ยนภาพอื่น ๆ ด้วย Aspose.Slides for Python via .NET."
---
## **ภาพรวม**

การเปลี่ยนภาพสลับควบคุมวิธีการแสดงสไลด์ระหว่างการแสดงสไลด์โชว์ ด้วย Aspose.Slides for Python via .NET คุณสามารถเลือกเอฟเฟกต์การเปลี่ยนภาพสำหรับแต่ละสไลด์ ตั้งค่าการเลื่อนหน้าด้วยการคลิกเมาส์หรือไทม์เมอร์ และปรับตัวเลือกที่เฉพาะเจาะจงต่อเอฟเฟกต์ บทความนี้ใช้ตัวอย่าง Python เพื่อใช้การเปลี่ยนภาพ ตั้งค่าระยะเวลาการเปลี่ยนภาพที่แน่นอน จัดการเวลาแสดงสไลด์ และสร้างการเปลี่ยนภาพ Morph ระหว่างสองสไลด์ ตัวอย่างยังแสดงวิธีการบันทึกการตั้งค่าเป็นไฟล์ PPTX

## **เพิ่มการเปลี่ยนภาพสไลด์**

เพื่อใช้การเปลี่ยนภาพ โหลดการนำเสนอด้วยคลาส [การนำเสนอ](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) และเข้าถึงคุณสมบัติ [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) ของสไลด์ ตั้งค่า [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ให้เป็นค่าจากการอิมพอร์ท [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) แล้วบันทึกการนำเสนอ

ตัวอย่างต่อไปนี้ใช้การเปลี่ยนภาพแบบ Circle กับสไลด์แรกและการเปลี่ยนภาพแบบ Comb กับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

## **การเปลี่ยนภาพแบบ Wheel**

คุณสมบัติ [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) ของ [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) ควบคุมจำนวนส่วนรัศมีที่เปิดเผยสไลด์เป้าหมาย ตั้งค่าการเปลี่ยนภาพของสไลด์ให้เป็น [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) เป็น WHEEL จาก [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) ก่อนเข้าถึง [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) เป็น [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/)

ตัวอย่างนี้สร้างคู่สไลด์ที่เหมือนกันสองคู่: สไลด์สีดำตามด้วยสไลด์ที่มีสี่เหลี่ยมสีทอง สไลด์เป้าหมายใช้จำนวน spoke เป็น 1 และ 8 โดยมี [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) และ [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ตั้งเป็น 8,000 มิลลิวินาที เพื่อให้สังเกตความแตกต่างได้ง่าย

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

เปิดการนำเสนอผลลัพธ์ใน PowerPoint แล้วรันการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 แล้วจากสไลด์ 3 ไปสไลด์ 4 ในการเล่น PowerPoint จำนวน spoke 1 ที่ตรวจสอบแล้วจะแสดงสไลด์ด้วยการสวิงตามเข็มน時計 1 รอบ; จำนวน 8 ที่ตรวจสอบแล้วจะแสดงสไลด์ผ่านส่วนรัศมีแปดส่วนพร้อมกัน เนื้อหาและการตั้งค่าเวลาเปลี่ยนภาพของสไลด์เป้าหมายเหมือนกัน ดังนั้นความแตกต่างจึงเป็นจำนวนส่วนการเปิดเผย

## **Fade Through Black กับการเปลี่ยนภาพ Reveal**

ตั้งค่า [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ของสไลด์เป้าหมายให้เป็น Reveal แล้วตั้งค่า [through_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/through_black/) บนวัตถุ [RevealTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/revealtransition/) ตัวอย่างสร้างสไลด์ต้นแบบสีฟ้าเขียวอ่อนและสไลด์เป้าหมายสีปะการัง จากนั้นทำสำเนาคู่ ทั้งสองคู่ใช้การเปลี่ยนภาพ Reveal ระยะเวลา 2 วินาที คู่ที่สองจะทำการเฟดผ่านสีดำ

```python
import aspose.slides as slides


def style_slide(slide, background_color, label):
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.preset_color = background_color

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 160, 180, 400, 130)
    shape.text_frame.text = label
    shape.text_frame.paragraphs[0].portions[0].portion_format.font_height = 44


with slides.Presentation() as presentation:
    source = presentation.slides[0]
    destination = presentation.slides.add_clone(source)
    style_slide(source, slides.PresetColor.TEAL, "Source")
    style_slide(destination, slides.PresetColor.CORAL, "Destination")
    presentation.slides.add_clone(source)
    presentation.slides.add_clone(destination)

    for index in (1, 3):
        transition = presentation.slides[index].slide_show_transition
        transition.type = slides.slideshow.TransitionType.REVEAL
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 2000
        
        reveal = transition.value
        reveal.direction = slides.slideshow.TransitionLeftRightDirectionType.LEFT
        reveal.through_black = index == 3

    presentation.save("reveal-transitions.pptx", slides.export.SaveFormat.PPTX)
```

เปิด `reveal-transitions.pptx` ใน PowerPoint แล้วเริ่มการแสดงสไลด์ เลื่อนจากสไลด์ 1 ไปสไลด์ 2 เพื่อดูสีฟ้าเขียวอ่อนเฟดตรงไปยังสีปะการัง จากนั้นเลื่อนจากสไลด์ 3 ไปสไลด์ 4 หน้าจอจะมืดลงชั่วคราวใกล้สีดำก่อนที่สไลด์สีปะการังจะปรากฏ สไลด์ทั้งสองคงสีพื้นหลังเดิมของตน

แถวต่อไปนี้แสดงเฟรมจาก PowerPoint ทุกครึ่งวินาที เปรียบเทียบเฟรมกลางในแต่ละแถวเพื่อดูผลของการตั้งค่า

![การเล่น PowerPoint กับ through_black ปิด (ด้านบน) และเปิด (ด้านล่าง). เพียงแถวล่างเท่านั้นที่ผ่านสีดำใกล้เคียง.](reveal-through-black.png)

## **เพิ่มการตั้งค่าการเปลี่ยนภาพขั้นสูง**

คุณสามารถกำหนดระยะเวลาที่สไลด์คงอยู่บนหน้าจอและว่าการคลิกเมาส์จะเลื่อนการแสดงสไลด์หรือไม่ คุณสมบัติดังต่อไปนี้ควบคุมพฤติกรรมนี้:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) อนุญาตให้ผู้ชมเลื่อนด้วยการคลิกเมาส์
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) เปิดให้เลื่อนอัตโนมัติ
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) ระบุความหน่วงก่อนการเลื่อนอัตโนมัติเป็นมิลลิวินาที

เปิดการเลื่อนด้วยคลิกและการเลื่อนตามเวลาพร้อมกันเพื่อให้ผู้ชมสามารถกดคลิกเพื่อดำเนินการต่อหรือรอไทม์เมอร์ หากต้องการใช้เฉพาะไทม์เมอร์ ตั้งค่า [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) เป็น `False` ความหน่วงควบคุมเมื่อการแสดงสไลด์เลื่อนไป; มันไม่ได้กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพ

ตัวอย่างนี้กำหนดเอฟเฟกต์ต่างกันให้กับสามสไลด์แรกและเปิดการเลื่อนอัตโนมัติหลัง 3, 5 และ 7 วินาที ตามลำดับ การคลิกเมาส์ก็สามารถเลื่อนสไลด์เหล่านี้ได้ ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสามสไลด์

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

เพื่อตรวจสอบว่าการเลื่อนตามเวลาถูกเปิดหรือไม่ ให้อ่าน [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) ค่าหน่วงที่บันทึกเพียงอย่างเดียวไม่บ่งบอกว่าไทม์เมอร์ทำงาน

ตัวอย่างต่อไปเปิดไฟล์ที่บันทึกไว้ด้านบน รายงานไทม์เมอร์ที่เปิดใช้งานแต่ละอันและปิดการเลื่อนอัตโนมัติสำหรับสไลด์ที่มีความหน่วงมากกว่าสองวินาที แล้วเปิดการคลิกเมาส์สำหรับสไลด์เหล่านั้นและบันทึกการตั้งค่าอัปเดต

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

## **ควบคุมเวลาเปลี่ยนภาพอย่างแม่นยำ**

ใช้ [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) เพื่อระบุความยาวที่แน่นอนของเอฟเฟกต์การเปลี่ยนภาพในมิลลิวินาที คุณสมบัติ [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) ของสไลด์เปิดเผยการตั้งค่าเหล่านี้ผ่าน [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| คุณสมบัติ | วัตถุประสงค์ |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | กำหนดระยะเวลาของเอฟเฟกต์การเปลี่ยนภาพเองเป็นมิลลิวินาที |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | กำหนดความหน่วงก่อนสไลด์เลื่อนอัตโนมัติเป็นมิลลิวินาที เปิดใช้งาน [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) เพื่อทำให้ไทม์เมอร์นี้ทำงาน |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | เลือกประเภทความเร็วที่กำหนดไว้ล่วงหน้าจาก [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM หรือ FAST ใช้เมื่อไม่ระบุระยะเวลาอย่างชัดแจ้ง |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ควบคุมเฉพาะเอฟเฟกต์การเปลี่ยนภาพ; มันไม่ได้กำหนดเวลาที่สไลด์คงอยู่บนหน้าจอ ปรับความหน่วงการเลื่อนอัตโนมัติแยกกัน เมื่อไม่มีการตั้งค่า duration ชัดเจน Aspose.Slides จะกำหนดระยะเวลาเอฟเฟกต์จากประเภทการเปลี่ยนภาพและค่า [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/)  

<!-- visual-explanation:slide-transition:start -->
[![แถบแยกแสดงระยะเวลาการเปลี่ยนภาพ 750 ms และการเลื่อนอัตโนมัติ 5 000 ms. เพียงแถบล่างเท่านั้นที่ผ่านสีดำใกล้เคียง.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*ตัวอย่างร่วมให้แต่ละสไลด์มีการเปลี่ยนภาพ Fade 750 ms และเปิดการเลื่อนอัตโนมัติที่ 5 000 ms แยกกัน การตั้งค่าเหล่านี้เป็นแผนผัง ไม่ใช่ไทม์ไลน์ที่วัดจริง*
<!-- visual-explanation:slide-transition:end -->

### **กำหนดระยะเวลาเดียวกันให้ทุกสไลด์**

เพื่อรักษาจังหวะที่สอดคล้อง ให้ตั้งค่าเอฟเฟกต์และระยะเวลาเดียวกันให้ทุกสไลด์ ตัวอย่างนี้โหลด `input.pptx` เลือก Fade จาก [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) แล้วกำหนดระยะเวลา 750 มิลลิวินาทีให้แต่ละการเปลี่ยนภาพ แยกเปิดการเลื่อนอัตโนมัติหลัง 5 000 มิลลิวินาทีและปิดการเลื่อนด้วยคลิกเมาส์ แล้วบันทึกผลเป็น PPTX

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # กำหนดการเลื่อนอัตโนมัติแยกจากระยะเวลาเอฟเฟกต์
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **กำหนดระยะเวลาต่างกันสำหรับสไลด์แต่ละอัน**

สไลด์ต่าง ๆ สามารถใช้ระยะเวลาเอฟเฟกต์ที่แตกต่างกันได้ ตัวอย่างเช่น ใช้การเปลี่ยนภาพสั้นสำหรับสไลด์หัวข้อและการเปลี่ยนภาพยาวสำหรับการแนะนำส่วน ตัวอย่างนี้กำหนด 500 มิลลิวินาทีสำหรับสไลด์แรกและ 1 200 มิลลิวินาทีสำหรับสไลด์ที่สอง ใช้ไฟล์ `input.pptx` ที่มีอย่างน้อยสองสไลด์

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

### **ประสานการเปลี่ยนภาพกับผลลัพธ์แบบแอนิเมชัน**

เมื่อเตรียม [animated GIF](/slides/th/python-net/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/th/python-net/export-to-html5/), หรือ [video](/slides/th/python-net/convert-powerpoint-to-video/), ให้ตั้งค่าระยะเวลาเปลี่ยนภาพที่แน่นอนก่อนส่งออกเพื่อให้ตรงกับจังหวะที่ต้องการ ตัวอย่างเช่น ใช้การเฟด 600 มิลลิวินาทีระหว่างฉากและปรับความหน่วงการเลื่อนของแต่ละสไลด์แยกกันเพื่อให้มีเวลาให้การบรรยายหรือเนื้อหา

สำหรับ GIF และวิดีโอ ให้ประสานอัตราเฟรมของผลลัพธ์กับระยะเวลาเอฟเฟกต์: 600 มิลลิวินาทีเท่ากับ 18 เฟรมที่ 30 เฟรมต่อวินาที ใน HTML5 ให้เปิดการเปลี่ยนภาพแอนิเมชันในการตั้งค่าการส่งออก ตรวจสอบเอฟเฟกต์และตัวเลือกเวลาในรูปแบบส่งออกที่เลือกและดูตัวอย่างผลลัพธ์เพื่อยืนยันการซิงโครไนส์

### **อ่านค่าระยะเวลาเปลี่ยนภาพที่มีอยู่**

อ่าน [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) ก่อนแก้ไขการเปลี่ยนภาพเพื่อพิจารณาว่ามีค่าที่ระบุไว้หรือไม่ ค่า `-1` หมายถึงไม่มีการกำหนดระยะเวลาอย่างชัดเจน; ค่าที่เป็นศูนย์หรือบวกหมายถึงระยะเวลาที่บันทึกไว้เป็นมิลลิวินาที ค่าที่ไม่ได้ตั้งค่าไม่ได้เป็นระยะเวลาการเล่นที่คำนวณ: Aspose.Slides ใช้ประเภทการเปลี่ยนภาพและ [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) เพื่อกำหนดระยะเวลานั้น การกำหนดประเภทการเปลี่ยนภาพอาจเริ่มต้นค่า duration ดังนั้นควรตรวจสอบการตั้งค่าเดิมก่อน

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

## **การเปลี่ยนภาพ Morph**

การเปลี่ยนภาพ Morph ทำให้การเปลี่ยนแปลงระหว่างวัตถุบนสไลด์ต่อเนื่องเป็นแอนิเมชัน เพื่อสร้างเอฟเฟกต์ Morph อย่างง่าย ให้ทำสำเนาสไลด์ ย้ายหรือปรับขนาดวัตถุบนสำเนา แล้วใส่การเปลี่ยนภาพ Morph ไปยังสไลด์ที่สอง สิ่งนี้ทำให้วัตถุที่ตรงกันทำการแอนิเมชันระหว่างสถานะเดิมและแก้ไข

ตัวอย่างต่อไปนี้สร้างสไลด์ที่มีสี่เหลี่ยมข้อความ ทำสำเนาสไลด์และเปลี่ยนตำแหน่งและขนาดของสี่เหลี่ยมบนสำเนา จากนั้นเลือก Morph จากการอิมพอร์ท [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) สำหรับสไลด์ที่สอง เปิดไฟล์ที่บันทึกในผู้ดูการนำเสนอที่รองรับ Morph เพื่อดูเอฟเฟกต์ระหว่างการแสดงสไลด์

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

## **ประเภทการเปลี่ยนภาพ Morph**

การอิมพอร์ท [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) ควบคุมวิธีที่ Morph จับคู่และแอนิเมชันเนื้อหา:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) ถือแต่ละรูปร่างเป็นวัตถุทั้งหมด
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) แอนิเมชันข้อความโดยจับคู่คำเมื่อเป็นไปได้
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) แอนิเมชันข้อความโดยจับคู่อักขระเมื่อเป็นไปได้

ตั้งค่า [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ให้เป็น Morph ก่อนเข้าถึง [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) ค่าจะแสดงวัตถุ [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/) ซึ่งคุณสมบัติ [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) เลือกโหมดการจับคู่

ตัวอย่างนี้เปิดการนำเสนอที่สร้างในส่วนก่อนหน้าและตั้งค่าสไลด์ที่สองให้ใช้การแอนิเมชัน Morph แบบจับคู่คำ

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

## **ตั้งค่าเอฟเฟกต์การเปลี่ยนภาพ**

การเปลี่ยนภาพบางประเภทเปิดเผยตัวเลือกเพิ่มเติม เช่น ทิศทางหรือว่าผลเริ่มจากหน้าจอสีดำ ตัวเลือกที่มีอยู่ขึ้นอยู่กับ [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ที่เลือก ตั้งค่าประเภทก่อนแล้วใช้วัตถุการเปลี่ยนภาพที่เหมาะสมจาก [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/)

ตัวอย่างต่อไปนี้ใช้การเปลี่ยนภาพ Cut กับสไลด์แรกของ `input.pptx` ตั้งค่า [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) ผ่าน [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) เพื่อให้การเปลี่ยนภาพเริ่มจากหน้าจอสีดำ

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

**ฉันสามารถควบคุมความเร็วการเล่นของการเปลี่ยนภาพสไลด์ได้หรือไม่?**

ใช่ ควรใช้ [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) เมื่อคุณต้องการระยะเวลาเอฟเฟกต์ที่แน่นอนเป็นมิลลิวินาที ใช้ [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) เมื่อหมวด [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) ที่กำหนดไว้ล่วงหน้า—SLOW, MEDIUM หรือ FAST—เพียงพอและไม่มีการกำหนดระยะเวลาอย่างชัดเจน การตั้งค่าเหล่านี้ควบคุมเอฟเฟกต์การเปลี่ยนภาพโดยแยกจากความหน่วงการเลื่อนอัตโนมัติ

**ฉันสามารถแนบไฟล์เสียงกับการเปลี่ยนภาพและทำให้ลูปได้หรือไม่?**

ใช่ กำหนดเสียงฝังไว้ใน [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) ตั้งค่า [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) เป็น START_SOUND จากการอิมพอร์ท [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) แล้วเปิด [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/) เสียงจะลูปจนกว่าจะมีเหตุการณ์เสียงถัดไปในการแสดงสไลด์

**วิธีที่เร็วที่สุดในการใช้การเปลี่ยนภาพเดียวกันกับทุกสไลด์คืออะไร?**

วนลูปผ่านคอลเลกชัน [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) ของการนำเสนอและตั้งค่า [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) ของการเปลี่ยนภาพของแต่ละสไลด์ให้เป็นค่าซึ่งกันและกัน ตั้งค่าตัวเลือกเวลาและเอฟเฟกต์ใด ๆ ในลูปเดียวกันเพื่อรักษาพฤติกรรมที่สอดคล้องกันทั่วสไลด์ทั้งหมด

**ฉันจะตรวจสอบว่าการเปลี่ยนภาพใดถูกตั้งค่าไว้บนสไลด์ในขณะนี้ได้อย่างไร?**

อ่านคุณสมบัติ [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) จาก [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) ของสไลด์ มันจะคืนค่าจากการอิมพอร์ท [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE หมายถึงไม่มีการใช้เอฟเฟกต์การเปลี่ยนภาพ.