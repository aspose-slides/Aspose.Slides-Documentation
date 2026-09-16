---
title: จัดการไฮเปอร์ลิงก์ของงานนำเสนอใน Python
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/python-net/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- กำหนดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์ภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่แก้ไขได้
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม, กำหนดรูปแบบ, อัปเดต และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET โดยใช้ตัวอย่าง Python."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาในงานนำเสนอกับเว็บไซต์หรือที่อยู่ภายในงานนำเสนอ สำหรับ PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อจุดประสงค์สองประการ:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง หรือกรอบสื่อ
* ไปยังสไลด์อื่น เช่น จากสารบัญ

Aspose.Slides for Python via .NET ช่วยให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, ปรับปรุงคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์ในแต่ละองค์ประกอบและวิธีเข้าถึงไฮเปอร์ลิงก์ระดับงานนำเสนอ, สไลด์, หรือกรอบข้อความ

{{% alert color="info" title="หมายเหตุ" %}}
คุณยังสามารถแก้ไขงานนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/th/editor)
{{% /alert %}}

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง หรือกรอบสื่อได้ พื้นที่ที่สามารถคลิกได้ขึ้นอยู่กับองค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์: ส่วนของข้อความจะลิงก์เฉพาะข้อความที่เลือก, ส่วนของรูปร่างหรือกรอบจะลิงก์ออบเจ็กต์สไลด์

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อทำให้ข้อความลิงก์ไปยังเว็บไซต์ ให้กำหนด [Hyperlink](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/) ให้กับคุณสมบัติ [hyperlink_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/portionformat/hyperlink_click/) ของส่วนข้อความตามตัวอย่างด้านล่าง เพียงส่วนข้อความนั้นเท่านั้นที่สามารถคลิกได้

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปร่างและกรอบสื่อ**

เพื่อทำให้รูปร่างหรือกรอบสามารถคลิกได้ ให้ตั้งค่าคุณสมบัติ [hyperlink_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/hyperlink_click/) ไว้ ไฮเปอร์ลิงก์จะเป็นของออบเจ็กต์เอง ไม่ใช่ของส่วนข้อความภายใน

วิธีเดียวกันใช้ได้กับกรอบรูปภาพ, เสียง, และวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบและตั้งค่า [tooltip](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/tooltip/) หากต้องการ

ตัวอย่างต่อไปทำให้สี่เหลี่ยมคลิกได้:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้ไฮเปอร์ลิงก์สร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปใช้ [set_internal_hyperlink_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **รูปแบบไฮเปอร์ลิงก์**

### **สี**

คุณสมบัติ [color_source](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/color_source/) ของ [Hyperlink](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของงานนำเสนอหรือการจัดรูปแบบของส่วนข้อความเพื่อกำหนดสีข้อความที่กำหนดเอง ให้เลือก [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนี้ ฟีเจอร์นี้ถูกแนะนำใน PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองรายการในสไลด์เดียว รายการแรกใช้สีเติมข้อความสีแดง, ส่วนที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **เสียง**

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อทำการคลิกหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้คุณสมบัติดังต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านี้:

- [Hyperlink.sound](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/sound/) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/stop_sound_on_click/) ควบคุมว่าการคลิกจะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้กับไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` และเชื่อมกับปุ่มบนสไลด์แรก การคลิกปุ่มจะเล่นเสียงและไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์เดียวกันจะหยุดเสียงก่อนหน้าเมื่อคลิก โดยไม่ทำการนำทาง

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **แยกเสียงจากไฮเปอร์ลิงก์**

ตัวอย่างต่อไปเปิดงานนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียงไฮเปอร์ลิงก์ของรูปร่างแรกเข้าสหน่วยความจำผ่าน [sound](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/sound/) และ [binary_data](https://reference.aspose.com/slides/th/python-net/aspose.slides/audio/binary_data/)

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Tooltip และการตั้งค่าปฏิสัมพันธ์**

คุณสามารถปรับปรุงคุณสมบัติของ [Hyperlink](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/) หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่างได้ดังนี้:

- [tooltip](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/tooltip/) ตั้งข้อความที่ผู้ดูอาจเห็นเป็นคำแนะนำสำหรับลิงก์
- [target_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/target_frame/) ระบุตำแหน่งกรอบเป้าหมายภายในชุดกรอบ HTML ของพาเรนต์ (หากใช้)
- [history](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/history/) ควบคุมว่าการคลิกจะเพิ่มปลายทางลงในรายการไฮเปอร์ลิงก์ที่เคยดูหรือไม่
- [highlight_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/highlight_click/) ควบคุมว่าลิงก์จะถูกไฮไลต์เมื่อคลิกหรือไม่

## **ลบไฮเปอร์ลิงก์จากงานนำเสนอ**

ใช้ [get_any_hyperlinks](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์ รวมถึงลิงก์ส่วนข้อความ ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบทั้งสองประเภทการกระทำจากสไลด์แรก หากต้องการลบเฉพาะประเภทหนึ่งให้เรียกใช้เฉพาะ [remove_hyperlink_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) หรือ [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) การลบการคลิกจะไม่ลบการวางเมาส์

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

สำหรับการลบโดยไม่มีเงื่อนไข, [remove_all_hyperlinks](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) จะลบทั้งสองประเภทการกระทำในสโคปที่เลือกในคำสั่งเดียว สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์, และโน๊ต ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการตรวจสอบไฮเปอร์ลิงก์ทั้งหมด**

ก่อนเผยแพร่งานนำเสนอ ควรตรวจสอบการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [get_any_hyperlinks](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) จะคืนค่าออบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/th/python-net/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [hyperlink_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) และ [hyperlink_mouse_over](https://reference.aspose.com/slides/th/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระกัน: คอนเทนเนอร์เดียวกันอาจเปิดเผยทั้งสองการกระทำ ดังนั้นรายงานครบต้องมีแถวสูงสุดสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามสโคปที่เหมาะสมและเก็บคอนเทนเนอร์ที่คืนค่าไว้เพื่อที่จะอัปเดตหรือเอาการกระทำออกในภายหลัง

### **สอบถามสโคป Presentation, Slide, และ Text‑Frame**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/) มีให้ผ่าน [Presentation.hyperlink_queries](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/hyperlink_queries/), และ [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/hyperlink_queries/). แต่ละสโคปรองรับคำสอบถามเดียวกัน:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) คืนคอนเทนเนอร์ที่มีการกระทำวางเมาส์
- [get_any_hyperlinks](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) คืนคอนเทนเนอร์ที่มีหรือทั้งสองการกระทำ

ตัวอย่างต่อไปสร้างไฟล์ `hyperlink-audit-input.pptx` ที่มีลิงก์คลิกภายนอก, ลิงก์วางเมาส์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์วางเมาส์ข้อความ, และการกระทำแมโคร ตัวอย่างจะไม่ดำเนินการใด ๆ ของลิงก์เหล่านี้ คำสอบถามเดียวกันสามคำทำงานในทุกสโคป; จำนวนที่แสดงเป็นคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำ ทั้งสโคป Text‑Frame จะไม่รวมลิงก์ของรูปร่างที่หุ้มมัน

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

สำหรับตัวอย่างนี้ คำสอบถามระดับงานนำเสนอและสไลด์แสดงคอนเทนเนอร์คลิกสามรายการ, คอนเทนเนอร์วางเมาส์สองรายการ, และคอนเทนเนอร์ที่มีอย่างใดอย่างหนึ่งสามรายการ สโคป Text‑Frame แสดงคอนเทนเนอร์หนึ่งรายการในแต่ละประเภท

### **จำแนกการกระทำและปลายทาง**

ใช้ [Hyperlink.action_type](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/action_type/) เพื่อแปลผลการกระทำก่อนตรวจสอบปลายทาง [HyperlinkActionType](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkactiontype/) มีค่ามากกว่าการนำทางเว็บเท่านั้น:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `HYPERLINK` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีม |
| `JUMP_SPECIFIC_SLIDE` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | การนำทางสไลด์โชว์ในตัว, แก้ไขตามบริบทสไลด์โชว์ |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | จบการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `START_MACRO` | เรียกใช้แมโคร |
| `START_PROGRAM` | เปิดโปรแกรม |
| `OPEN_FILE`, `OPEN_PRESENTATION` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `START_STOP_MEDIA` | เริ่มหรือหยุดการเล่นสื่อ |
| `NO_ACTION`, `UNKNOWN` | ไม่มีการนำทางหรือการกระทำที่ไม่ระบุ ต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [external_url](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/external_url/) และปลายทางภายในเฉพาะจาก [target_slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/target_slide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ เก็บ [external_url_original](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/external_url_original/) ไว้เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน และรวม [tooltip](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/tooltip/) เมื่อมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง Python ด้านล่างอ่านงานนำเสนอที่สร้างไว้ (ใช้ไฟล์จากขั้นตอนก่อนหน้า), เขียน `hyperlink-audit.json`, ใช้นโยบาย, บันทึก `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบทั้งสองประเภทการกระทำอีกครั้ง มันรวบรวมคอนเทนเนอร์ก่อนเปลี่ยนแปลงและสอบถามสโคปสไลด์หนึ่งครั้งเพื่อหลีกเลี่ยงการประมวลผลซ้ำ คำสอบถามระดับงานนำเสนอครอบคลุมสไลด์ปกติ; สำหรับรายการครอบคลุมแพ็คเกจ ตัวอย่างสอบถามสไลด์ปกติ, มาสเตอร์, เลย์เอาต์, โน๊ต, และมาสเตอร์โน๊ต/แฮนด์เอาท์เมื่อมี

รายงานบันทึกดัชนีสไลด์ที่เริ่มจาก 1 และ [slide_id](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/slide_id/) หากมี คอลเลกเตอร์เก็บสไลด์เจ้าของและสโคปพร้อมกับคอนเทนเนอร์ที่คืนค่า มาสเตอร์, เลย์เอาต์, และโน๊ตไม่มีดัชนีสไลด์ปกติและระบุด้วยสโคปของตน คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะมีป้ายชื่อแยกกัน; ประเภทคอนเทนเนอร์อื่นจะคงชื่อประเภทรันไทม์ของมัน แต่ละคอนเทนเนอร์จะได้รับ ID รายงาน-ท้องถิ่นเพื่อให้สามารถเชื่อมโยงสองการกระทำเข้าด้วยกัน

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง จะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น ๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่น ๆ การปฏิเสธเป็นการตัดสินใจตามนโยบาย ไม่ได้เป็นการตัดสินความปลอดภัยของ Aspose.Slides HTTPS เพียงอย่างเดียวไม่ได้รับประกันความน่าเชื่อถือ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกดั้งเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างทำการตรวจสอบเมตาดาต้าโดยไม่ตามลิงก์หรือเรียกการกระทำ

สำหรับการแก้ไข, [hyperlink_manager](https://reference.aspose.com/slides/th/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) ของคอนเทนเนอร์สนับสนุน [set_external_hyperlink_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/), และ [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). ที่นี่ลิงก์คลิกภายนอกที่ห้ามจะถูกแทนที่ด้วยหน้าแลนดิ้ง HTTPS คงที่; คลิกและวางเมาส์ที่ห้ามอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replace_external_clicks` เป็น `False` เพื่อให้ลบการละเมิดนโยบายทั้งหมด เลือกหน้าทดแทนที่เป็นของแอปก่อนการปรับใช้

ธงการส่งออกของรายงานใช้แนวนโยบายรีวิว PDF แบบระมัดระวัง: ทำเครื่องหมายการกระทำวางเมาส์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ เป็นเคล็ดลับรีวิว ไม่ได้เป็นการทดสอบความสามารถหรือการรับประกันว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่ในการส่งออก PDF และ HTML ที่สนับสนุนอาจเก็บไฮเปอร์ลิงก์ไว้ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และโปรแกรมดู ส่วนรูปภาพ [images](/slides/th/python-net/convert-powerpoint-to-png/) และวิดีโอ [video](/slides/th/python-net/convert-powerpoint-to-video/) ไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบ; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Query each slide scope once, retaining its owner with each container.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

ด้วยอินพุตที่สร้างข้างต้น รายงานมีห้าแถวการกระทำ ลิงก์วางเมาส์ไฟล์และแมโครคลิกถูกลบ ส่วนลิงก์ HTTPS และการนำทางสไลด์ภายในคงเหลือ การตรวจสอบพิมพ์ศูนย์การกระทำที่ห้าม อินพุตที่มี URL คลิกภายนอกที่ห้ามก็จะทดสอบสาขาการแทนที่ คอนเทนเนอร์ที่มีคลิกที่อนุญาตและวางเมาส์ที่ห้ามจะเก็บการกระทำคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [remove_all_hyperlinks](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) ที่ลบการกระทำทั้งสองประเภทในสโคปที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาแอคทีฟอื่น ๆ และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดียว หากต้องการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

สามารถทำได้ มาสเตอร์สไลด์และองค์ประกอบเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะใช้ได้ระหว่างการนำเสนอบนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่เกี่ยวข้อง

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อต้องส่งออกเป็น PDF, HTML, รูปภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่สนับสนุนอาจเก็บไฮเปอร์ลิงก์ไว้; รูปภาพแบบเรสเตอร์และวิดีโอไม่สามารถเก็บไฮเปอร์ลิงก์เชิงโต้ตอบได้ ดูข้อควรพิจารณาการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)