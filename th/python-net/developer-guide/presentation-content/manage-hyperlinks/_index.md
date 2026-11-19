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
- กำหนดรูปแบบไฮเปอร์ลิงก์
- ลบไฮเปอร์ลิงก์
- อัปเดตไฮเปอร์ลิงก์
- ไฮเปอร์ลิงก์ข้อความ
- ไฮเปอร์ลิงก์สไลด์
- ไฮเปอร์ลิงก์รูปร่าง
- ไฮเปอร์ลิงก์รูปภาพ
- ไฮเปอร์ลิงก์วิดีโอ
- ไฮเปอร์ลิงก์ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "เพิ่ม กำหนดรูปแบบ อัปเดต และลบไฮเปอร์ลิงก์ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET โดยใช้ตัวอย่าง Python."
---
## **บทนำ**

ไฮเปอร์ลิงก์เชื่อมต่อเนื้อหาการนำเสนอไปยังเว็บไซต์หรือที่ตั้งภายในการนำเสนอ ใน PowerPoint ไฮเปอร์ลิงก์มักใช้เพื่อสองวัตถุประสงค์หลัก:

* เปิดเว็บไซต์จากข้อความ, รูปร่าง, หรือกรอบสื่อ.
* ไปยังสไลด์อื่น, ตัวอย่างเช่นจากสารบัญ.

Aspose.Slides for Python via .NET ช่วยให้คุณเพิ่มลิงก์เหล่านี้, ควบคุมลักษณะและเสียง, ปรับปรุงคุณสมบัติ, และลบออก ตัวอย่างด้านล่างแสดงวิธีทำงานกับไฮเปอร์ลิงก์บนองค์ประกอบแต่ละรายการและวิธีเข้าถึงไฮเปอร์ลิงก์ในระดับการนำเสนอ, สไลด์, หรือกรอบข้อความ.

{{% alert color="info" title="Note" %}}
คุณยังสามารถแก้ไขการนำเสนอด้วย [ตัวแก้ไข PowerPoint ออนไลน์ฟรีของ Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **เพิ่มไฮเปอร์ลิงก์ URL**

คุณสามารถกำหนด URL ของเว็บไซต์ให้กับข้อความ, รูปร่าง, หรือกรอบสื่อได้ ส่วนที่คุณกำหนดไฮเปอร์ลิงก์จะเป็นตัวกำหนดพื้นที่ที่คลิกได้: ส่วนของข้อความจะลิงก์ข้อความที่เลือก, ขณะที่รูปหรือกรอบจะลิงก์วัตถุสไลด์.

สำหรับการนำเสนอที่มีไฮเปอร์ลิงก์แบบสัมพันธ์ ให้ดูที่ [Manage the Hyperlink Base](/slides/th/python-net/presentation-properties/#manage-the-hyperlink-base) เพื่ออ่าน, แก้ไข หรือเคลียร์ฐานระดับเอกสาร.

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับข้อความ**

เพื่อทำให้ข้อความลิงก์ไปยังเว็บไซต์ ให้กำหนด [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) ให้กับคุณสมบัติ [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) ของส่วนข้อความตามที่แสดงด้านล่าง เฉพาะส่วนของข้อความนั้นจะสามารถคลิกได้.

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

### **เพิ่มไฮเปอร์ลิงก์ URL ให้กับรูปและกรอบสื่อ**

กำหนด URL ให้กับคุณสมบัติ [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) ของสี่เหลี่ยมเพื่อทำให้พื้นที่ทั้งหมดของมันคลิกได้ [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) จะให้ผู้อ่านคำแนะนำเกี่ยวกับจุดหมายเมื่อเมาส์อยู่เหนือสี่เหลี่ยม คุณสมบัติเหมือนกันใช้ได้กับภาพ, เสียง, และกรอบวิดีโอ.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **ใช้ไฮเปอร์ลิงก์สร้างสารบัญ**

ไฮเปอร์ลิงก์ภายในทำให้ผู้อ่านกระโดดจากสารบัญไปยังสไลด์เฉพาะ ตัวอย่างต่อไปนี้ใช้ [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) เพื่อลิงก์ข้อความ “Page 2” บนสไลด์แรกไปยังสไลด์ที่สอง.

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

คุณสามารถเปลี่ยนสีของข้อความที่ลิงก์, เล่นหรือหยุดเสียงเมื่อผู้อ่านเปิดลิงก์, และตั้ง tooltip ที่แสดงเมื่อเมาส์วาง.

### **สี**

คุณสมบัติ [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) ของ [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) กำหนดว่าไฮเปอร์ลิงก์จะใช้สีไฮเปอร์ลิงก์ของการนำเสนอหรือรูปแบบของส่วนข้อความหรือไม่ เพื่อกำหนดสีข้อความกำหนดเอง ให้เลือก [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) แล้วตั้งค่าสีเติมของส่วนนี้ ฟีเจอร์นี้ถูกแนะนำใน PowerPoint 2019; เวอร์ชันเก่าจะไม่ใช้การตั้งค่านี้.

ในตัวอย่างนี้ การตั้งค่า [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) บนลิงก์แรกทำให้ข้อความของมันเป็นสีแดง ลิงก์ที่สองยังคงใช้สีไฮเปอร์ลิงก์ของการนำเสนอ.

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

ไฮเปอร์ลิงก์สามารถเล่นเสียงเมื่อเปิดใช้งานหรือหยุดเสียงที่กำลังเล่นอยู่ ใช้คุณสมบัติดังต่อไปนี้เพื่อกำหนดพฤติกรรมเหล่านี้:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) ระบุไฟล์เสียงที่เชื่อมกับไฮเปอร์ลิงก์.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) ควบคุมว่าเมื่อเปิดไฮเปอร์ลิงก์จะหยุดเสียงก่อนหน้า หรือไม่.

#### **เพิ่มเสียงไฮเปอร์ลิงก์**

ปุ่มบนสไลด์แรกใช้ [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) เพื่อเล่นเสียงจากไฟล์ WAV เมื่อผู้อ่านคลิกเพื่อเดินหน้า ในสไลด์ที่สอง ปุ่มแยกต่างหากใช้ [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) เพื่อหยุดการเล่นและคงผู้อ่านอยู่บนสไลด์นั้น.

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

ตัวอย่างต่อไปนี้เปิดการนำเสนอที่สร้างข้างต้นและอ่านเสียงไฮเปอร์ลิงก์ของรูปร่างแรกเข้าไปในหน่วยความจำผ่าน [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) และ [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/).

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

### **การตั้งค่า Tooltip และการโต้ตอบ**

คุณสามารถอัปเดตคุณสมบัติ [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) ต่อไปนี้หลังจากกำหนดไฮเปอร์ลิงก์ให้กับข้อความหรือรูปร่าง:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) ตั้งข้อความที่ผู้ชมสามารถแสดงเป็นคำแนะนำสำหรับลิงก์.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) ระบุเฟรมเป้าหมายภายในชุดเฟรม HTML พาเรนต์ เมื่อมีการใช้.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) ควบคุมว่าการเปิดลิงก์จะเพิ่มจุดหมายของมันในรายการไฮเปอร์ลิงก์ที่ดูแล้วหรือไม่.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) ควบคุมว่าไฮเปอร์ลิงก์จะไฮไลท์เมื่อคลิกหรือไม่.

## **ลบไฮเปอร์ลิงก์จากการนำเสนอ**

ใช้ [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) เพื่อรวบรวมคอนเทนเนอร์ของไฮเปอร์ลิงก์, รวมถึงลิงก์ส่วนข้อความ, ก่อนทำการเปลี่ยนแปลง ตัวอย่างต่อไปนี้ลบทั้งสองประเภทการกระทำจากสไลด์แรก หากต้องการลบเฉพาะประเภทหนึ่ง ให้เรียกใช้เฉพาะ [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) หรือ [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/); การลบการคลิกจะไม่ลบการเมาส์โอเวอร์ที่สอดคล้องกัน.

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

สำหรับการลบโดยไม่มีเงื่อนไข, [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) จะลบทั้งสองประเภทการกระทำในสโคปที่เลือกในหนึ่งคำสั่ง สำหรับการทำความสะอาดแบบเลือกและการครอบคลุมของมาสเตอร์, เลย์เอาต์, และโน้ต, ดูที่ [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

### **ล้างไฮเปอร์ลิงก์ก่อนแทนที่ข้อความ SmartArt**

เมื่อคุณแทนที่ย่อหน้าภายในโหนด SmartArt ที่มีอยู่ การล้างส่วนข้อความของมันอาจทำให้ไฮเปอร์ลิงก์เก่ายังคงอยู่ ดึงย่อหน้าผ่าน [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/). ก่อนการล้างส่วนข้อความ ให้เรียก [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) ผ่าน [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) บนกรอบข้อความของรูปร่างโหนดที่แสดงย่อหน้านั้น ซึ่งจะลบทุกไฮเปอร์ลิงก์ในกรอบนั้นรวมถึงลิงก์ในย่อหน้าอื่นๆ

ใน `SmartArtHyperlink.pptx` รูปร่างที่สามบนสไลด์แรกเป็นกราฟิก SmartArt ตัวอย่างนี้แทนที่ย่อหน้าแรกของโหนดที่สี่ของมัน ในการนำเสนอนี้ รูปร่างแรกของโหนดจะแสดงย่อดัั้น.

หลังจากเพิ่มทั้งสองส่วน ตัวอย่างนี้อ่านการจัดรูปแบบที่มีผลของพวกมันด้วย [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/). คุณสมบัติ [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) ที่มีผลจะคืนค่าไฮเปอร์ลิงก์ใหม่สำหรับส่วนแรกและ `None` สำหรับส่วนที่สอง.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **สร้างรายการไฮเปอร์ลิงก์ครบถ้วน**

ก่อนเผยแพร่การนำเสนอ ควรทำรายการการกระทำเชิงโต้ตอบและลิงก์เว็บของมัน [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) จะคืนอ็อบเจ็กต์ [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) ไม่ใช่รายการแบนของสตริง URL ตรวจสอบทั้ง [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) และ [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) ในแต่ละคอนเทนเนอร์ พวกมันเป็นอิสระ: คอนเทนเนอร์เดียวกันอาจเปิดเผยทั้งสองการกระทำ ดังนั้นรายงานครบถ้วนอาจต้องการสูงสุดสองแถวต่อคอนเทนเนอร์.

การสแกนเฉพาะไฮเปอร์ลิงก์ระดับรูปร่างอาจพลาดลิงก์ที่แนบกับส่วนข้อความ ให้สอบถามสโคปที่เหมาะแทน และเก็บคอนเทนเนอร์ที่คืนมาเพื่อให้คุณสามารถอัปเดตหรือเอาการกระทำของมันออกในภายหลัง.

### **สอบถามสโคปการนำเสนอ, สไลด์, และกรอบข้อความ**

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) มีให้ใช้งานผ่าน [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) และ [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/). แต่ละสโคปสนับสนุนคำสอบถามเดียวกัน:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) คืนคอนเทนเนอร์ที่มีการกระทำคลิก.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) คืนคอนเทนเนอร์ที่มีการกระทำเมาส์โอเวอร์.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) คืนคอนเทนเนอร์ที่มีหนึ่งหรือทั้งสองการกระทำ.

ตัวอย่างนี้กำหนดการกระทำคลิกและเมาส์โอเวอร์ให้กับรูปร่างและข้อความของมัน, และการกระทำแมโครให้กับปุ่มแยกต่างหาก มันเปรียบเทียบคอนเทนเนอร์ที่คืนโดย [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) กับจำนวนของแต่ละประเภทการกระทำ คำสอบถามกรอบข้อความจะนับเฉพาะลิงก์ในข้อความ การกระทำของรูปร่างที่หุ้มอยู่จะปรากฏในคำสอบถามสไลด์และการนำเสนอ.

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

สำหรับตัวอย่างนี้ คำสอบถามระดับการนำเสนอและสไลด์แต่ละอันรายงานคอนเทนเนอร์คลิกสามอัน, คอนเทนเนอร์เมาส์โอเวอร์สองอัน, และคอนเทนเนอร์ที่มีหนึ่งในสองการกระทำสามอัน คำสอบถามกรอบข้อความรายงานคอนเทนเนอร์หนึ่งอันในแต่ละประเภท.

### **จำแนกการกระทำและจุดหมาย**

ใช้ [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) เพื่อแปลความหมายของการกระทำก่อนแปลความหมายของจุดหมายค่า [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) มีค่ามากกว่าเพียงการนำทางเว็บ:

| ค่า | ความหมายสำหรับการตรวจสอบ |
| --- | --- |
| `HYPERLINK` | ไฮเปอร์ลิงก์ภายนอก; ตรวจสอบ URL และสคีมของมัน. |
| `JUMP_SPECIFIC_SLIDE` | การนำทางภายในไปยังสไลด์เฉพาะ. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | การนำทางสไลด์โชว์ในตัว, แก้ไขตามบริบทของสไลด์โชว์. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | สิ้นสุดการแสดงปัจจุบันหรือเริ่มการแสดงแบบกำหนดเอง. |
| `START_MACRO` | เรียกใช้แมโคร. |
| `START_PROGRAM` | เปิดโปรแกรม. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | เปิดไฟล์หรือการนำเสนออื่น; ตรวจสอบแยกจาก URL เว็บ. |
| `START_STOP_MEDIA` | เริ่มหรือหยุดการเล่นสื่อ. |
| `NO_ACTION`, `UNKNOWN` | ไม่มีการกระทำนำทาง, หรือการกระทำที่ไม่รู้จักซึ่งต้องตรวจสอบ. |

อ่านจุดหมายภายนอกจาก [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) และจุดหมายภายในเฉพาะจาก [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/). การกระทำภายในและคำสั่งในตัวอาจไม่มี URL ภายนอก; URL ว่างไม่ได้หมายความว่าคอนเทนเนอร์ไม่มีการกระทำ ให้เก็บ [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) ไว้เมื่อแตกต่างจาก URL ที่ทำให้เป็นมาตรฐาน, และรวม [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) หากมี.

### **รายงาน, ทำความสะอาด, และตรวจสอบไฮเปอร์ลิงก์**

ตัวอย่างนี้เปิดการนำเสนอจากตัวอย่างก่อนหน้าและเขียนบันทึก JSON หนึ่งรายการต่อการกระทำ ใช้ [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) เพื่อรวบรวมคอนเทนเนอร์บนสไลด์ปกติ, มาสเตอร์, เลย์เอาต์, และโน้ต รวมถึงมาสเตอร์โน้ตและหัวกระดาษเมื่อมีอยู่ มันสอบถามแต่ละสโคปครั้งเดียวเพื่อหลีกเลี่ยงการประมวลผลซ้ำ, ใช้นโยบายที่อธิบายด้านล่าง, และเปิดการนำเสนอที่บันทึกใหม่เพื่อตรวจสอบการกระทำคลิกและเมาส์โอเวอร์.

รายงานบันทึกดัชนีสไลด์ที่เริ่มจากหนึ่งและ [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/) หากมี คอลเลกเตอร์เก็บสไลด์เจ้าของและสโคปพร้อมกับแต่ละคอนเทนเนอร์ที่คืน มาสเตอร์, เลย์เอาต์, และโน้ตไม่มีดัชนีสไลด์ปกติและระบุด้วยสโคปของพวกเขา คอนเทนเนอร์รูปร่างและคอนเทนเนอร์การจัดรูปแบบส่วนข้อความจะมีป้ายชื่อแยกกัน; ประเภทคอนเทนเนอร์อื่นๆ จะคงชื่อประเภทในเวลารัน ทุกคอนเทนเนอร์จะได้รับ ID ภายในรายงานเพื่อให้สามารถเชื่อมโยงการกระทำสองอย่างได้.

นโยบายแอปพลิเคชันที่เข้มงวดนี้อนุญาตเฉพาะ URL HTTPS แบบเต็มและเป้าหมายสไลด์ภายในที่ถูกต้อง จะปฏิเสธแมโคร, โปรแกรม, การกระทำไฟล์, การกระทำสไลด์โชว์อื่นๆ, การกระทำที่ไม่รู้จัก, และสคีม URL อื่นๆ การปฏิเสธเหล่านี้เป็นการตัดสินใจของนโยบาย ไม่ใช่การตัดสินความปลอดภัยของ Aspose.Slides HTTPS อย่างเดียวไม่สร้างความน่าเชื่อถือ: เพิ่มรายการให้อนุญาตโฮสต์และการตรวจสอบอื่นๆ สำหรับแอปของคุณ ทั้ง URL ภายนอกเดิมและที่ทำให้เป็นมาตรฐานจะถูกตรวจสอบ ตัวอย่างตรวจสอบเมตาดาท้าโดยไม่ติดตามลิงก์หรือรันการกระทำ.

สำหรับการแก้ไข, [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) ของคอนเทนเนอร์สนับสนุน [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) และ [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/). ในที่นี้ ลิงก์คลิกภายนอกที่ไม่อนุญาตจะถูกแทนที่ด้วยหน้าแลนดิ้ง HTTPS คงที่; คลิกที่ไม่อนุญาตอื่นๆ และการกระทำเมาส์โอเวอร์ที่ไม่อนุญาตจะถูกลบแยกกัน ตั้งค่า `replace_external_clicks` เป็น `False` เพื่อทำการลบการละเมิดนโยบายทั้งหมด เลือกหน้าทดแทนที่เป็นของแอปพลิเคชันก่อนการปรับใช้.

แฟล็กการส่งออกของรายงานใช้แนวนโยบายการตรวจสอบ PDF อย่างระมัดระวัง: ทำเครื่องหมายการกระทำเมาส์โอเวอร์และสิ่งอื่นใดที่ไม่ใช่ลิงก์ภายนอกหรือการกระโดดสไลด์เฉพาะว่าอาจไม่รองรับ นี่เป็นคำแนะนำการตรวจสอบ ไม่ใช่การทดสอบความสามารถหรือการรับรองว่าลิงก์ที่ไม่ได้ทำเครื่องหมายจะคงอยู่หลังการส่งออก การส่งออก PDF และ HTML ที่รองรับ ([PDF](/slides/th/python-net/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/python-net/convert-powerpoint-to-html/)) อาจรักษาไฮเปอร์ลิงก์ไว้ขึ้นอยู่กับการกระทำ, ตัวเลือกการส่งออก, และโปรแกรมอ่าน ส่วนภาพ [images](/slides/th/python-net/convert-powerpoint-to-png/) และ [video](/slides/th/python-net/convert-powerpoint-to-video/) แบบเรสเตอร์ไม่สามารถรักษาไฮเปอร์ลิงก์เชิงโต้ตอบได้; ทำเครื่องหมายทุกการกระทำเมื่อทำการตรวจสอบสำหรับผลลัพธ์เหล่านั้น.

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
    # สอบถามสโคปของสไลด์แต่ละอันเพียงครั้งเดียว, เก็บเจ้าของไว้กับแต่ละคอนเทนเนอร์.
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

ด้วยอินพุตที่สร้างด้านบน รายงานมีแถวการกระทำห้าแถว ลิงก์เมาส์โอเวอร์ไฟล์และคลิกแมโครถูกลบ, ในขณะที่ลิงก์ HTTPS และการนำทางสไลด์ภายในยังคงอยู่ การตรวจสอบพิมพ์การกระทำที่ไม่อนุญาตศูนย์ อินพุตที่มี URL คลิกภายนอกที่ไม่อนุญาตก็ทดสอบสาขาการแทนที่ คอนเทนเนอร์ที่มีการคลิกที่อนุญาตและเมาส์โอเวอร์ที่ไม่อนุญาตจะคงการกระทำคลิกไว้.

การทำความสะอาดแบบเลือกนี้แตกต่างจาก [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) ที่ลบทั้งสองประเภทการกระทำในสโคปที่เลือกโดยไม่คำนึงถึงนโยบาย การตรวจสอบที่นี่ตรวจสอบเฉพาะการกระทำของไฮเปอร์ลิงก์; ไม่ได้ลบโปรเจกต์ VBA ที่ฝังอยู่, วัตถุ OLE, หรือเนื้อหาเชิงโต้ตอบอื่นๆ และไม่ตรวจสอบความถูกต้องของไฟล์ PDF หรือ HTML ที่ส่งออก.

## **คำถามที่พบบ่อย**

**ฉันจะลิงก์ไปยังส่วนหรือสไลด์แรกของมันได้อย่างไร?**

ส่วนใน PowerPoint จัดกลุ่มสไลด์, แต่ไฮเปอร์ลิงก์ภายในจะชี้ไปยังสไลด์เดี่ยว เพื่อสร้างการนำทางไปยังส่วน ให้ลิงก์ไปยังสไลด์แรกของส่วนนั้น.

**ฉันสามารถแนบไฮเปอร์ลิงก์ให้กับองค์ประกอบมาสเตอร์สไลด์เพื่อให้ทำงานบนทุกสไลด์ได้หรือไม่?**

ได้. องค์ประกอบมาสเตอร์สไลด์และเลย์เอาต์รองรับไฮเปอร์ลิงก์ ลิงก์บนองค์ประกอบเหล่านี้จะพร้อมใช้งานในระหว่างการแสดงสไลด์บนสไลด์ที่ใช้มาสเตอร์หรือเลย์เอาต์ที่สอดคล้องกัน.

**ไฮเปอร์ลิงก์จะถูกเก็บไว้เมื่อส่งออกเป็น PDF, HTML, ภาพ, หรือวิดีโอหรือไม่?**

การส่งออก PDF และ HTML ที่รองรับอาจรักษาไฮเปอร์ลิงก์ไว้; ภาพเรสเตอร์และวิดีโอไม่สามารถทำได้ ดูรายละเอียดการส่งออกใน [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).