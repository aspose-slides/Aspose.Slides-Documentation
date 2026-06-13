---
title: จัดการ Hyperlink ในพรีเซนเทชันด้วย Python
linktitle: จัดการ Hyperlink
type: docs
weight: 20
url: /th/python-net/manage-hyperlinks/
keywords:
- เพิ่ม URL
- เพิ่ม hyperlink
- สร้าง hyperlink
- จัดรูปแบบ hyperlink
- ลบ hyperlink
- อัปเดต hyperlink
- hyperlink ข้อความ
- hyperlink สไลด์
- hyperlink รูปร่าง
- hyperlink รูปภาพ
- hyperlink วิดีโอ
- hyperlink ที่เปลี่ยนแปลงได้
- PowerPoint
- OpenDocument
- พรีเซนเทชัน
- Python
description: "จัดการ hyperlink ในพรีเซนเทชัน PowerPoint และ OpenDocument อย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET—เพิ่มความโต้ตอบและกระบวนการทำงานในไม่กี่นาที."
---
## **บทนำ**

Hyperlink คือการอ้างอิงไปยังแหล่งภายนอก วัตถุ หรือรายการข้อมูล หรือสถานที่เฉพาะภายในไฟล์ ชนิดของ hyperlink ที่พบบ่อยในงานพรีเซนเทชัน PowerPoint ได้แก่:

* ลิงก์ไปยังเว็บไซต์ที่ฝังในข้อความ รูปร่าง หรือสื่อ
* ลิงก์ไปยังสไลด์

Aspose.Slides สำหรับ Python ผ่าน .NET เปิดใช้งานการดำเนินการที่เกี่ยวกับ hyperlink อย่างหลากหลายในพรีเซนเทชัน

## **เพิ่ม URL Hyperlink**

ส่วนนี้อธิบายวิธีเพิ่ม URL hyperlink ไปยังองค์ประกอบของสไลด์เมื่อทำงานกับ Aspose.Slides รวมถึงการกำหนดที่อยู่ลิงก์ให้กับข้อความ รูปร่าง และรูปภาพเพื่อให้การนำทางในพรีเซนเทชันเป็นไปอย่างราบรื่น

### **เพิ่ม URL Hyperlink ไปยังข้อความ**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่ม hyperlink เว็บไซต์ไปยังข้อความ:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")
    
    text_portion = shape.text_frame.paragraphs[0].portions[0]

    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **เพิ่ม URL Hyperlink ไปยังรูปทรงหรือเฟรม**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่ม hyperlink เว็บไซต์ไปยังรูปทรง:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)

    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **เพิ่ม URL Hyperlink ไปยังสื่อ**

Aspose.Slides ให้คุณเพิ่ม hyperlink ไปยังรูปภาพ, ไฟล์เสียง และไฟล์วิดีโอ

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่ม hyperlink ไปยัง **รูปภาพ**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # เพิ่มรูปภาพไปยังพรีเซนเทชัน.
    with open("image.jpeg", "rb") as image_stream:
        image_data = image_stream.read()
        image = presentation.images.add_image(image_data)

    # สร้างเฟรมรูปภาพบนสไลด์ที่ 1 โดยใช้รูปภาพที่เพิ่มไว้ก่อนหน้า.
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    picture_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    picture_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่ม hyperlink ไปยัง **ไฟล์เสียง**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()
        audio = presentation.audios.add_audio(audio_data)
        
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 100, 100, audio)

    audio_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    audio_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีเพิ่ม hyperlink ไปยัง **วิดีโอ**:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("video.avi", "rb") as video_stream:
        video_data = video_stream.read()
        video = presentation.videos.add_video(video_data)
        
    video_frame = slide.shapes.add_video_frame(10, 10, 100, 100, video)

    video_frame.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    video_frame.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Tip" color="primary" %}}
คุณอาจต้องการดู [จัดการ OLE ในพรีเซนเทชันโดยใช้ Python](/slides/th/python-net/manage-ole/).
{{% /alert %}}

## **ใช้ Hyperlink เพื่อสร้างสารบัญ**

เนื่องจาก hyperlink ทำให้คุณอ้างอิงถึงวัตถุหรือสถานที่ได้ คุณจึงสามารถใช้มันเพื่อสร้างสารบัญได้

ตัวอย่างโค้ดด้านล่างแสดงวิธีสร้างสารบัญที่มี hyperlink:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)

    content_table = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    content_table.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    content_table.text_frame.paragraphs.clear()

    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "

    link_text_portion = slides.Portion()
    link_text_portion.text = "Page 2"
    link_text_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)

    paragraph.portions.add(link_text_portion)
    content_table.text_frame.paragraphs.add(paragraph)

    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **จัดรูปแบบ Hyperlink**

ส่วนนี้แสดงวิธีจัดรูปแบบการแสดงผลของ hyperlink ใน Aspose.Slides คุณจะได้เรียนรู้การควบคุมสีและตัวเลือกสไตล์อื่น ๆ เพื่อให้การจัดรูปแบบ hyperlink สม่ำเสมอในข้อความ รูปร่าง และรูปภาพ

### **สี Hyperlink**

โดยใช้คุณสมบัติ [color_source](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/color_source/) ของคลาส [Hyperlink](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/) คุณสามารถตั้งค่าสีของ hyperlink และอ่านข้อมูลสีได้ คุณสมบัตินี้เริ่มใช้ตั้งแต่ PowerPoint 2019 ดังนั้นการเปลี่ยนแปลงผ่านคุณสมบัตินี้จะไม่ส่งผลต่อเวอร์ชัน PowerPoint ที่เก่ากว่า

ตัวอย่างต่อไปนี้สาธิตวิธีเพิ่ม hyperlink ที่มีสีต่างกันไปยังสไลด์เดียวกัน:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape1.add_text_frame("This is a sample of a colored hyperlink.")

    text_portion1 = shape1.text_frame.paragraphs[0].portions[0]
    text_portion1.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion1.portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    text_portion1.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_portion1.portion_format.fill_format.solid_fill_color.color = draw.Color.red

    shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    shape2.add_text_frame("This is a sample of a regular hyperlink.")

    text_portion2 = shape2.text_frame.paragraphs[0].portions[0]
    text_portion2.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")

    presentation.save("hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **ลบ Hyperlink จากพรีเซนเทชัน**

ส่วนนี้อธิบายวิธีลบ hyperlink จากพรีเซนเทชันเมื่อทำงานกับ Aspose.Slides คุณจะได้เรียนรู้วิธีทำความสะอาดเป้าหมายลิงก์จากข้อความ รูปร่าง และรูปภาพพร้อมคงเนื้อหาและการจัดรูปแบบเดิมไว้

### **ลบ Hyperlink จากข้อความ**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบ hyperlink จากข้อความในสไลด์พรีเซนเทชัน:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if type(shape) is slides.AutoShape:
            for paragraph in shape.text_frame.paragraphs:
                for text_portion in paragraph.portions:
                    text_portion.portion_format.hyperlink_manager.remove_hyperlink_click()

    presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

### **ลบ Hyperlink จากรูปทรงหรือเฟรม**

ตัวอย่างโค้ดต่อไปนี้แสดงวิธีลบ hyperlink จากรูปทรงในสไลด์พรีเซนเทชัน: 

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
   slide = presentation.slides[0]

   for shape in slide.shapes:
       shape.hyperlink_manager.remove_hyperlink_click()

   presentation.save("removed_hyperlinks.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlink ที่เปลี่ยนแปลงได้**

คลาส [Hyperlink](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/) สามารถแก้ไขได้ โดยใช้คลาสนี้คุณสามารถเปลี่ยนค่าในคุณสมบัติเหล่านี้ได้:

- [target_frame](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/target_frame/)
- [tooltip](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/tooltip/)
- [history](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/history/)
- [highlight_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/highlight_click/)
- [stop_sound_on_click](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlink/stop_sound_on_click/)

โค้ดตัวอย่างต่อไปนี้แสดงวิธีเพิ่ม hyperlink ไปยังสไลด์แล้วแก้ไข tooltip ของมัน:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    shape.add_text_frame("Aspose: File Format APIs")

    text_portion = shape.text_frame.paragraphs[0].portions[0]
    text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    text_portion.portion_format.hyperlink_click.tooltip = "More than 70% of Fortune 100 companies trust Aspose APIs."

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **คุณสมบัติที่สนับสนุนใน IHyperlinkQueries**

คุณสามารถเข้าถึง [HyperlinkQueries](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/) จากพรีเซนเทชัน สไลด์ หรือข้อความที่มี hyperlink อยู่ได้

- [Presentation.hyperlink_queries](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/hyperlink_queries/)
- [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/th/python-net/aspose.slides/baseslide/hyperlink_queries/)
- [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/hyperlink_queries/)

คลาส [HyperlinkQueries](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/) รองรับวิธีการต่อไปนี้:

- [get_hyperlink_clicks()](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/)
- [get_hyperlink_mouse_overs()](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/)
- [get_any_hyperlinks()](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/)
- [remove_all_hyperlinks()](https://reference.aspose.com/slides/th/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinkss/)

{{% alert color="primary" %}}
คุณอาจต้องการลองใช้ [PowerPoint editor](https://products.aspose.app/slides/th/editor) ออนไลน์ฟรีและใช้งานง่ายของ Aspose
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันจะสร้างการนำทางภายในไม่เพียงแค่สไลด์เท่านั้น แต่ถึง “section” หรือสไลด์แรกของ section ได้อย่างไร?**

ใน PowerPoint sections คือการจัดกลุ่มของสไลด์; การนำทางโดยเทคนิคจะชี้ไปยังสไลด์เฉพาะ เพื่อ “นำทางไปยัง section” คุณมักจะลิงก์ไปยังสไลด์แรกของ section นั้น

**ฉันสามารถแนบ hyperlink ให้กับองค์ประกอบของ master slide เพื่อให้ทำงานบนสไลด์ทั้งหมดได้หรือไม่?**

ได้ รายการและองค์ประกอบของ master slide และ layout รองรับ hyperlink ลิงก์เหล่านี้จะปรากฏบนสไลด์ลูกและสามารถคลิกได้ในระหว่างการแสดงสไลด์

**Hyperlink จะยังคงอยู่เมื่อส่งออกเป็น PDF, HTML, ภาพ หรือวิดีโอหรือไม่?**

ใน [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/) และ [HTML](/slides/th/python-net/convert-powerpoint-to-html/) จะคงลิงก์ไว้โดยส่วนใหญ่ ส่วนการส่งออกเป็น [images](/slides/th/python-net/convert-powerpoint-to-png/) และ [video](/slides/th/python-net/convert-powerpoint-to-video/) จะไม่สามารถคลิกได้ เนื่องจากรูปแบบเหล่านั้นเป็นกรอบภาพ/วิดีโอที่ไม่สนับสนุน hyperlink