---
title: จัดการไฮเปอร์ลิงก์การนำเสนอใน Python
linktitle: จัดการไฮเปอร์ลิงก์
type: docs
weight: 20
url: /th/python-net/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่มไฮเปอร์ลิงก์
- สร้างไฮเปอร์ลิงก์
- จัดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์แก้ไขได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม, จัดรูปแบบ, อัปเดต และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET โดยใช้ตัวอย่าง Python"
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือสถานที่ภายในการนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักมีวัตถุประสงค์สองประการ:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง หรือกรอบสื่อ
* ไปยังสไลด์อื่น, ตัวอย่างเช่นจากสารบัญ

Aspose.Slides for Python via .NET ให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, อัปเดตคุณสมบัติและลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละรายการและวิธีเข้าถึงไฮเปอร์ลิงก์ระดับการนำเสนอ, สไลด์ หรือกรอบข้อความ

{{% alert color="info" title="Note" %}}

คุณสามารถแก้ไขการนำเสนอด้วย [เครื่องมือแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor)

{{% /alert %}}

## **เพิ่ม URL ไฮเปอร์ลิงก์**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง หรือกรอบสื่อได้ พื้นที่ที่คลิกได้จะกำหนดโดยองค์ประกอบที่คุณกำหนดไฮเปอร์ลิงก์: ส่วนของข้อความที่ลิงก์จะคลิกได้เฉพาะข้อความที่เลือก, ส่วนของรูปร่างหรือกรอบจะลิงก์กับอ็อบเจ็กต์สไลด์ทั้งหมด

สำหรับการนำเสนอที่มีไฮเปอร์ลิงก์แบบสัมพันธ์, ดูที่ [จัดการ Hyperlink Base](/slides/th/python-net/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, เปลี่ยนหรือเคลียร์ฐานระดับเอกสาร

### **เพิ่ม URL ไฮเปอร์ลิงก์ให้กับข้อความ**

เพื่อทำให้ข้อความลิงก์ไปยังเว็บไซต์, กำหนด [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) ให้กับคุณสมบัติ [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) ของส่วนข้อความ, ตามตัวอย่างด้านล่าง ส่วนของข้อความนั้นเท่านั้นที่กลายเป็นคลิกได้

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

### **เพิ่ม URL ไฮเปอร์ลิงก์ให้กับรูปร่างและกรอบสื่อ**

เพื่อทำให้รูปร่างหรือกรอบคลิกได้, ตั้งค่าคุณสมบัติ [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) ของมัน ไฮเปอร์ลิงก์จะเป็นของอ็อบเจ็กต์เอง ไม่ใช่ของส่วนข้อความภายใน

วิธีเดียวกันนี้ใช้กับกรอบรูปภาพ, เสียงและวิดีโอ: กำหนดไฮเปอร์ลิงก์ให้กับกรอบและตั้งค่า [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) หากต้องการ

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

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์ที่ต้องการ ตัวอย่างต่อไปใช้ [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) เพื่อเชื่อมข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง

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

คุณสมบัติ [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) ของ [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีของไฮเปอร์ลิงก์ในงานนำเสนอหรือการฟอร์แมตของส่วนข้อความ หากต้องการสีข้อความกำหนดเอง ให้เลือก [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนั้น ฟีเจอร์นี้เปิดตัวใน PowerPoint 2019; เวอร์ชันเก่าจะไม่รองรับการตั้งค่านี้

ตัวอย่างต่อไปเพิ่มไฮเปอร์ลิงก์ข้อความสองรายการบนสไลด์เดียว รายการแรกใช้สีเติมข้อความสีแดง, รายการที่สองใช้สีไฮเปอร์ลิงก์เริ่มต้น

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้คุณสมบัติด้านล่างเพื่อกำหนดพฤติกรรมเหล่านี้:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) ควบคุมว่าการคลิกไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้าหรือไม่

#### **เพิ่มเสียงให้กับไฮเปอร์ลิงก์**

ตัวอย่างต่อไปโหลด `sampleaudio.wav` แล้วเชื่อมกับปุ่มบนสไลด์แรก เมื่อคลิกปุ่มเสียงจะเล่นและไปยังสไลด์ถัดไป รูปร่างที่สองบนสไลด์นั้นจะหยุดเสียงก่อนหน้าเมื่อคลิกโดยไม่ทำการนำทาง

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

#### **ดึงเสียงจากไฮเปอร์ลิงก์**

ตัวอย่างต่อไปเปิดการนำเสนอที่สร้างไว้ข้างต้นและอ่านเสียงของไฮเปอร์ลิงก์ของรูปร่างแรกเข้าสู่หน่วยความจำผ่าน [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) และ [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/)

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

คุณสามารถอัปเดตคุณสมบัติ [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำสำหรับลิงก์
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) ระบุเฟรมเป้าหมายภายในชุดเฟรม HTML ของพาเรนท์, หากมี
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) ควบคุมว่าการเปิดลิงก์จะเพิ่มปลายทางไปยังรายการไฮเปอร์ลิงก์ที่ดูแล้วหรือไม่
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) ควบคุมว่าการคลิกจะทำให้ไฮเปอร์ลิงก์ถูกเน้นสีหรือไม่

## **ลบไฮเปอร์ลิงก์จากการนำเสนอ**

ใช้ [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปลบทั้งสองประเภทการเปิดใช้งานจากสไลด์แรก หากต้องการลบเพียงประเภทเดียว ให้เรียกเฉพาะ [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) หรือ [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); การลบการคลิกจะไม่ลบการเมาส์โอเวอร์ที่สัมพันธ์

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

สำหรับการลบโดยไม่มีเงื่อนไข, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) จะลบทั้งสองประเภทการเปิดใช้งานในขอบเขตที่เลือกในครั้งเดียว สำหรับการทำความสะอาดแบบเลือกและครอบคลุมมาสเตอร์, เลย์เอาต์และโน้ต, ดูที่ [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)

## **สร้างรายการตรวจสอบไฮเปอร์ลิงก์ครบวงจร**

ก่อนแจกจ่ายการนำเสนอ, ควรรวบรวมการกระทำเชิงโต้ตอบและลิงก์เว็บทั้งหมด [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) จะคืนอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) และ [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) ในแต่ละคอนเทนเนอร์ พวกมันทำงานแยกจากกัน: คอนเทนเนอร์เดียวอาจเปิดให้ทำทั้งสองการกระทำได้ ดังนั้นรายงานที่ครบถ้วนอาจต้องมีสองแถวต่อคอนเทนเนอร์

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ควรสอบถามขอบเขตที่เหมาะสมแทนและเก็บคอนเทนเนอร์ที่คืนค่ามาเพื่อสามารถอัปเดตหรือลบการกระทำในภายหลังได้

### **สอบถามขอบเขตการนำเสนอ, สไลด์, และกรอบข้อความ**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) มีให้ใช้ผ่าน [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/), และ [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). แต่ละขอบเขตสนับสนุนคำสอบถามเดียวกัน:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) คืนคอนเทนเนอร์ที่มีการกระทำคลิก
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) คืนคอนเทนเนอร์ที่มีการกระทำเมาส์โอเวอร์
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) คืนคอนเทนเนอร์ที่มีการกระทำหนึ่งหรือทั้งสอง

ตัวอย่างต่อไปสร้าง `hyperlink-audit-input.pptx` พร้อมลิงก์คลิกภายนอก, ลิงก์เมาส์โอเวอร์ไฟล์, การนำทางสไลด์ภายใน, ลิงก์เมาส์โอเวอร์ข้อความ, และการกระทำมาโคร โดยไม่ได้ทำการเรียกใช้ใด ๆ คำสอบถามสามแบบทำงานที่ทุกขอบเขต; จำนวนที่แสดงเป็นจำนวนคอนเทนเนอร์ ไม่ใช่จำนวนการกระทำ ขอบเขตกรอบข้อความจะแยกลิงก์ของรูปร่างที่ล้อมรอบออก

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

ในตัวอย่างนี้, การสอบถามระดับการนำเสนอและสไลด์แต่ละรายการรายงานคอนเทนเนอร์คลิกสามรายการ, เมาส์โอเวอร์สองรายการ, และคอนเทนเนอร์ที่มีหนึ่งในสองการกระทำสามรายการ ขอบเขตกรอบข้อความรายงานหนึ่งคอนเทนเนอร์ในแต่ละหมวด

### **จัดประเภทการกระทำและปลายทาง**

ใช้ [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) เพื่อวิเคราะห์การกระทำก่อนวิเคราะห์ปลายทาง [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) มีค่ามากกว่าการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `HYPERLINK` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสเคม่า |
| `JUMP_SPECIFIC_SLIDE` | การนำทางภายในไปยังสไลด์เฉพาะ |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | การนำทางสไลด์โชว์ในตัว, แก้ไขในบริบทสไลด์โชว์ |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | จบการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง |
| `START_MACRO` | เรียกใช้มาโคร |
| `START_PROGRAM` | เปิดโปรแกรม |
| `OPEN_FILE`, `OPEN_PRESENTATION` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ |
| `START_STOP_MEDIA` | เริ่มหรือหยุดการเล่นสื่อ |
| `NO_ACTION`, `UNKNOWN` | ไม่มีการนำทางหรือการกระทำที่ไม่รู้จักต้องตรวจสอบ |

อ่านปลายทางภายนอกจาก [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) และปลายทางภายในจาก [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ เก็บ [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) ไว้เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน, และรวม [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) หากมี

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่าง Python ต่อไปอ่านการนำเสนอที่มีอยู่ (ใช้ไฟล์ที่สร้างข้างต้น), เขียน `hyperlink-audit.json`, ใช้นโยบาย, บันทึก `hyperlink-sanitized.pptx`, แล้วเปิดใหม่เพื่อตรวจสอบทั้งสองการกระทำอีกครั้ง ตัวอย่างเก็บคอนเทนเนอร์ก่อนเปลี่ยนและสอบถามแต่ละขอบเขตสไลด์หนึ่งครั้งเพื่อหลีกเลี่ยงการทำซ้ำ การสอบถามระดับการนำเสนอครอบคลุมสไลด์ทั่วไป; เพื่อทำรายการระดับแพคเกจ, ตัวอย่างสอบถามสไลด์ทั่วไป, มาสเตอร์, เลย์เอาต์, โน้ต, และมาสเตอร์โน้ตและแฮนด์เอาท์เมื่อมี

รายงานบันทึกดัชนีสไลด์เริ่มจากหนึ่งและ [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) หากมี ตัวเก็บรักษาข้อมูลสไลด์และขอบเขตของคอนเทนเนอร์แต่ละรายการ มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและระบุด้วยขอบเขตของมันเอง คอนเทนเนอร์รูปร่างและคอนเทนเนอร์ฟอร์แมตส่วนข้อความถูกตั้งชื่อแยกจากกัน; ประเภทคอนเทนเนอร์อื่นคงชื่อประเภทรันไทม์ของมัน แต่ละคอนเทนเนอร์ได้รับ ID รายงานภายในเพื่อให้การกระทำสองอย่างสามารถเชื่อมโยงกันได้

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตให้ใช้เฉพาะ URL HTTPS แบบเต็มรูปแบบและเป้าหมายสไลด์ภายในที่ถูกต้อง มันปฏิเสธมาโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่น, การกระทำที่ไม่รู้จัก, และสเคม่า URL อื่น ๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย, ไม่ได้เป็นการตัดสินความปลอดภัยของ Aspose.Slides URL HTTPS เพียงอย่างเดียวไม่ได้ให้ความเชื่อถือ: เพิ่มรายการอนุญาตโฮสต์และการตรวจสอบอื่น ๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกดั้งเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาต้าโดยไม่เปิดลิงก์หรือเรียกการกระทำ

สำหรับการแก้ไข, [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) ของคอนเทนเนอร์รองรับ [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/), และ [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). ที่นี่, ลิงก์คลิกภายนอกที่ห้ามจะถูกแทนที่ด้วยหน้า HTTPS คงที่; การคลิกและเมาส์โอเวอร์ที่ห้ามอื่น ๆ จะถูกลบแยกกัน ตั้งค่า `replace_external_clicks` เป็น `False` เพื่อเอาการละเมิดทั้งหมดออก เลือกหน้าทดแทนที่เป็นของแอปก่อนใช้งาน

แฟล็กการส่งออกของรายงานใช้แนวนโยบายรีวิว PDF อย่างระมัดระวัง: ทำแฟล็กการเมาส์โอเวอร์และทุกอย่างที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นคำแนะนำรีวิว ไม่ได้เป็นการทดสอบความสามารถหรือการรับรองว่าลิงก์ที่ไม่มีแฟล็กจะคงอยู่ในการส่งออก PDF และ HTML ที่สนับสนุน ([PDF](/slides/th/python-net/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/python-net/convert-powerpoint-to-html/)) อาจรักษาไฮเปอร์ลิงก์ได้ ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และผู้ชม ภาพ [images](/slides/th/python-net/convert-powerpoint-to-png/) และ [video](/slides/th/python-net/convert-powerpoint-to-video/) แบบราสเตอร์ไม่สามารถรักษาไฮเปอร์ลิงก์เชิงโต้ตอบได้; ควรทำแฟล็กทุกการกระทำเมื่อทำการตรวจสอบสำหรับเอาต์พุตเหล่านั้น

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
    # สืบค้นขอบเขตสไลด์แต่ละอันหนึ่งครั้ง, คงเจ้าของไว้กับแต่ละคอนเทนเนอร์
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

ด้วยข้อมูลที่สร้างข้างต้น, รายงานมีห้าข้อแถวการกระทำ ลิงก์เมาส์โอเวอร์ไฟล์และคลิกมาโครถูกลบ, ขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์การกระทำที่ห้ามเป็นศูนย์ อินพุตที่มี URL คลิกภายนอกที่ห้ามก็จะทดสอบสาขาการแทนที่ คอนเทนเนอร์ที่มีการคลิกที่อนุญาตและเมาส์โอเวอร์ที่ห้ามจะเก็บการคลิกไว้

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) ที่ลบทั้งสองการกระทำในขอบเขตที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบโครงการ VBA ฝัง, วัตถุ OLE, หรือเนื้อหาเชิงกระทำอื่น ๆ, และไม่ได้ตรวจสอบไฟล์ PDF หรือ HTML ที่ส่งออก

## **FAQ**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของส่วนได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน, ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น

**ฉันสามารถแนบไฮเปอร์ลิงก์กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานในทุกสไลด์ได้หรือไม่?**

ได้ มาสเตอร์สไลด์และองค์ประกอบเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานในระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์นั้น

**ไฮเปอร์ลิงก์จะคงอยู่เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่สนับสนุนอาจคงไว้ซึ่งไฮเปอร์ลิงก์; ภาพราสเตอร์และวิดีโอไม่สามารถทำได้ ดูข้อควรพิจารณาการส่งออกใน [รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์](#report-sanitize-and-verify-hyperlinks)