---
title: แปลงสไลด์ PowerPoint ให้เป็นภาพใน Python
linktitle: สไลด์เป็นภาพ
type: docs
weight: 41
url: /th/python-net/convert-slide/
keywords:
- แปลงสไลด์
- แปลงสไลด์เป็นภาพ
- ส่งออกสไลด์เป็นภาพ
- บันทึกสไลด์เป็นภาพ
- สไลด์เป็นภาพ
- สไลด์เป็น PNG
- สไลด์เป็น JPEG
- สไลด์เป็นบิตแมป
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการแปลงสไลด์ PowerPoint และ OpenDocument ไปเป็นรูปแบบต่าง ๆ ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET ส่งออกสไลด์ PPTX และ ODP ไปเป็น BMP, PNG, JPEG, TIFF และอื่น ๆ ได้อย่างง่ายดายพร้อมผลลัพธ์คุณภาพสูง"
---
## **บทนำ**

Aspose.Slides for Python via .NET ทำให้คุณสามารถแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่าง ๆ ได้แก่ BMP, PNG, JPG (JPEG), GIF และอื่น ๆ ได้อย่างง่ายดาย

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - คลาส [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) หรือ
    - คลาส [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/)
2. สร้างภาพสไลด์โดยเรียกเมธอด `get_image` จากคลาส [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/)

ใน Aspose.Slides for Python via .NET, คลาส [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) ช่วยให้คุณทำงานกับภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้อินสแตนซ์ของคลาสนี้เพื่อบันทึกภาพในรูปแบบต่าง ๆ อย่างกว้างขวาง (BMP, JPG, PNG เป็นต้น)

## **แปลงสไลด์เป็นบิตแมพและบันทึกรูปภาพใน PNG**

คุณสามารถแปลงสไลด์เป็นออบเจกต์บิตแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณอาจแปลงสไลด์เป็นบิตแมพแล้วบันทึกภาพในรูปแบบ JPEG หรือรูปแบบอื่นตามต้องการ

โค้ด Python นี้แสดงวิธีแปลงสไลด์แรกของการนำเสนอเป็นออบเจกต์บิตแมพและบันทึกภาพเป็นรูปแบบ PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # แปลงสไลด์แรกในพรีเซนเทชันเป็นบิตแมป.
    with presentation.slides[0].get_image() as image:
        # บันทึกภาพในรูปแบบ PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

คุณอาจต้องการภาพขนาดเฉพาะ โดยใช้การอีเวอร์โหลดจากเมธอด [get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) คุณสามารถแปลงสไลด์เป็นภาพที่มีความกว้างและความสูงที่กำหนดได้

โค้ดตัวอย่างนี้แสดงวิธีทำเช่นนั้น:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # แปลงสไลด์แรกในพรีเซนเทชันเป็นบิตแมปด้วยขนาดที่ระบุ.
    with presentation.slides[0].get_image(image_size) as image:
        # บันทึกภาพในรูปแบบ JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **แปลงสไลด์พร้อมโน้ตและคอมเมนต์เป็นภาพ**

บางสไลด์อาจมีโน้ตและคอมเมนต์

Aspose.Slides มีคลาสสองตัว—[TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) และ [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/)—ที่ให้คุณควบคุมการเรนเดอร์สไลด์เป็นภาพ ทั้งสองคลาสมีพร็อพเพอร์ตี้ `slides_layout_options` ที่ช่วยให้คุณกำหนดการเรนเดอร์ของโน้ตและคอมเมนต์บนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับโน้ตและคอมเมนต์ในภาพที่ได้

โค้ด Python นี้แสดงวิธีแปลงสไลด์พร้อมโน้ตและคอมเมนต์:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # กำหนดตำแหน่งของโน้ต.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # กำหนดตำแหน่งของคอมเมนต์.
    notes_comments_options.comments_area_width = 500                                       # กำหนดความกว้างของพื้นที่คอมเมนต์.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # กำหนดสีสำหรับพื้นที่คอมเมนต์.

    # สร้างตัวเลือกการเรนเดอร์.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # แปลงสไลด์แรกของพรีเซนเทชันเป็นภาพ.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # บันทึกภาพในรูปแบบ GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 

ในกระบวนการแปลงสไลด์เป็นภาพใด ๆ ไม่สามารถตั้งค่าพร็อพเพอร์ตี้ [notes_position](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) ให้เป็น `BOTTOM_FULL` (เพื่อระบุตำแหน่งของโน้ต) ได้ เนื่องจากข้อความของโน้ตอาจมีขนาดใหญ่เกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่ระบุได้

{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ TIFF Options**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) ให้การควบคุมที่ละเอียดขึ้นสำหรับภาพ TIFF ที่ได้ โดยคุณสามารถระบุพารามิเตอร์เช่น ขนาด, ความละเอียด, พาเลตสี และอื่น ๆ

โค้ด Python นี้แสดงกระบวนการแปลงโดยใช้ TIFF Options เพื่อสร้างภาพสีขาว-ดำที่ความละเอียด 300 DPI และขนาด 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# โหลดไฟล์พรีเซนเทชัน.
with slides.Presentation("sample.pptx") as presentation:
    # ดึงสไลด์แรกจากพรีเซนเทชัน.
    slide = presentation.slides[0]

    # กำหนดค่าการตั้งค่าของภาพ TIFF ผลลัพธ์.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # กำหนดขนาดภาพ.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # กำหนดรูปแบบพิกเซล (ขาวดำ).
    options.dpi_x = 300                                                        # กำหนดความละเอียดแนวนอน.
    options.dpi_y = 300                                                        # กำหนดความละเอียดแนวตั้ง.

    # แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
    with slide.get_image(options) as image:
        # บันทึกภาพในรูปแบบ TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides ให้คุณแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพ ทำให้การนำเสนอทั้งหมดกลายเป็นชุดของภาพ

โค้ดตัวอย่างนี้แสดงวิธีแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพด้วย Python:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # เรนเดอร์พรีเซนเทชันเป็นภาพสไลด์ต่อสไลด์.
    for i, slide in enumerate(presentation.slides):
        # ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่เรนเดอร์สไลด์ที่ซ่อน).
        if slide.hidden:
            continue

        # แปลงสไลด์เป็นภาพ.
        with slide.get_image(scale_x, scale_y) as image:
            # บันทึกภาพในรูปแบบ JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **ถามบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่, เมธอด `get_image` จะบันทึกเฉพาะภาพนิ่งของสไลด์โดยไม่มีแอนิเมชัน

**สไลด์ที่ซ่อนอยู่สามารถส่งออกเป็นภาพได้หรือไม่?**

ได้, สไลด์ที่ซ่อนสามารถประมวลผลได้เช่นเดียวกับสไลด์ทั่วไป เพียงตรวจสอบให้แน่ใจว่าได้รวมสไลด์เหล่านั้นในลูปการประมวลผล

**สามารถบันทึกรูปภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่น ๆ เมื่อบันทึกสไลด์เป็นภาพ