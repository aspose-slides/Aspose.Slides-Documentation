---
title: แปลงสไลด์ PowerPoint เป็นภาพใน Python
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
- สไลด์เป็นบิตแมพ
- Python
- Aspose.Slides
description: "เรียนรู้วิธีแปลงสไลด์ PowerPoint และ OpenDocument ให้เป็นรูปแบบต่างๆ โดยใช้ Aspose.Slides สำหรับ Python ผ่าน .NET. ส่งออกสไลด์ PPTX และ ODP ไปเป็น BMP, PNG, JPEG, TIFF และอื่นๆ อย่างง่ายดายด้วยผลลัพธ์คุณภาพสูง."
---
## **บทนำ**

Aspose.Slides for Python via .NET ช่วยให้คุณสามารถแปลงสไลด์การนำเสนอ PowerPoint และ OpenDocument ไปเป็นรูปแบบภาพต่างๆ ได้อย่างง่ายดาย รวมถึง BMP, PNG, JPG (JPEG), GIF และอื่นๆ

เพื่อแปลงสไลด์เป็นภาพ ให้ทำตามขั้นตอนต่อไปนี้:

1. กำหนดการตั้งค่าการแปลงที่ต้องการและเลือกสไลด์ที่ต้องการส่งออกโดยใช้:
    - คลาส [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) หรือ
    - คลาส [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/)
2. สร้างภาพสไลด์โดยเรียกเมธอด `get_image` จากคลาส [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/)

ใน Aspose.Slides for Python via .NET, คลาส [IImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/iimage/) เป็นคลาสที่ช่วยให้คุณทำงานกับภาพที่กำหนดโดยข้อมูลพิกเซล คุณสามารถใช้อินสแตนซ์ของคลาสนี้เพื่อบันทึกภาพในรูปแบบต่างๆ มากมาย (BMP, JPG, PNG ฯลฯ)

## **แปลงสไลด์เป็นบิตแมพและบันทึกภาพในรูปแบบ PNG**

คุณสามารถแปลงสไลด์เป็นอ็อบเจกต์บิตแมพและใช้โดยตรงในแอปพลิเคชันของคุณ หรือคุณอาจแปลงสไลด์เป็นบิตแมพแล้วบันทึกภาพเป็น JPEG หรือรูปแบบอื่นที่ต้องการ

โค้ด Python นี้สาธิตวิธีแปลงสไลด์แรกของการนำเสนอเป็นอ็อบเจกต์บิตแมพและบันทึกรูปภาพเป็นรูปแบบ PNG:

```py 
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    # แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพ.
    with presentation.slides[0].get_image() as image:
        # บันทึกภาพในรูปแบบ PNG.
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **แปลงสไลด์เป็นภาพด้วยขนาดที่กำหนดเอง**

คุณอาจต้องการรับภาพที่มีขนาดเฉพาะ โดยใช้ overload จากเมธอด [get_image](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) คุณสามารถแปลงสไลด์เป็นภาพด้วยความกว้างและความสูงที่กำหนดได้

โค้ดตัวอย่างนี้สาธิตวิธีทำเช่นนั้น:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    # แปลงสไลด์แรกในงานนำเสนอเป็นบิตแมพด้วยขนาดที่ระบุ.
    with presentation.slides[0].get_image(image_size) as image:
        # บันทึกภาพในรูปแบบ JPEG.
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **แปลงสไลด์ที่มีบันทึกและความคิดเห็นเป็นภาพ**

บางสไลด์อาจมีบันทึกและความคิดเห็น

Aspose.Slides ให้คลาสสองคลาส—[TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) และ [RenderingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/renderingoptions/)—ที่ช่วยให้คุณควบคุมการเรนเดอร์สไลด์การนำเสนอเป็นภาพ ทั้งสองคลาสมีคุณสมบัติ `slides_layout_options` ซึ่งช่วยให้คุณกำหนดการเรนเดอร์บันทึกและความคิดเห็นบนสไลด์เมื่อแปลงเป็นภาพ

ด้วยคลาส [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/) คุณสามารถระบุตำแหน่งที่ต้องการสำหรับบันทึกและความคิดเห็นในภาพที่ได้

โค้ด Python นี้สาธิตวิธีแปลงสไลด์ที่มีบันทึกและความคิดเห็น:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    notes_comments_options = slides.export.NotesCommentsLayoutingOptions()
    notes_comments_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED  # ตั้งตำแหน่งของบันทึก.
    notes_comments_options.comments_position = slides.export.CommentsPositions.RIGHT       # ตั้งตำแหน่งของความคิดเห็น.
    notes_comments_options.comments_area_width = 500                                       # ตั้งความกว้างของพื้นที่ความคิดเห็น.
    notes_comments_options.comments_area_color = draw.Color.antique_white                  # ตั้งสีสำหรับพื้นที่ความคิดเห็น.

    # สร้างตัวเลือกการเรนเดอร์.
    options = slides.export.RenderingOptions()
    options.slides_layout_options = notes_comments_options

    # แปลงสไลด์แรกของงานนำเสนอเป็นภาพ.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as image:
        # บันทึกภาพในรูปแบบ GIF.
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Note" color="warning" %}} 
ในกระบวนการแปลงสไลด์เป็นภาพใดๆ คุณสมบัติ [notes_position](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) ไม่สามารถตั้งค่าเป็น `BOTTOM_FULL` (เพื่อระบุตำแหน่งของบันทึก) ได้ เนื่องจากข้อความของบันทึกอาจมีขนาดใหญ่เกินไป ทำให้ไม่สามารถใส่ลงในขนาดภาพที่กำหนดได้.
{{% /alert %}} 

## **แปลงสไลด์เป็นภาพโดยใช้ TIFF Options**

คลาส [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) ให้การควบคุมที่มากขึ้นต่อภาพ TIFF ที่ได้โดยอนุญาตให้ระบุพารามิเตอร์เช่น ขนาด, ความละเอียด, พาเลตสี ฯลฯ

โค้ด Python นี้สาธิตกระบวนการแปลงที่ใช้ตัวเลือก TIFF เพื่อออกภาพขาว-ดำที่มีความละเอียด 300 DPI และขนาด 2160 × 2800:

```py 
import aspose.pydrawing as draw
import aspose.slides as slides

# โหลดไฟล์งานนำเสนอ.
with slides.Presentation("sample.pptx") as presentation:
    # ดึงสไลด์แรกจากงานนำเสนอ.
    slide = presentation.slides[0]

    # กำหนดค่าการตั้งค่าของภาพ TIFF ที่จะส่งออก.
    options = slides.export.TiffOptions()
    options.image_size = draw.Size(2160, 2880)                                 # ตั้งขนาดภาพ.
    options.pixel_format = slides.export.ImagePixelFormat.FORMAT_1BPP_INDEXED  # ตั้งรูปแบบพิกเซล (ขาว-ดำ).
    options.dpi_x = 300                                                        # ตั้งความละเอียดแนวนอน.
    options.dpi_y = 300                                                        # ตั้งความละเอียดแนวตั้ง.

    # แปลงสไลด์เป็นภาพด้วยตัวเลือกที่ระบุ.
    with slide.get_image(options) as image:
        # บันทึกภาพในรูปแบบ TIFF.
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **แปลงสไลด์ทั้งหมดเป็นภาพ**

Aspose.Slides อนุญาตให้คุณแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพ ทำให้การนำเสนอทั้งหมดกลายเป็นชุดของภาพ

โค้ดตัวอย่างนี้สาธิตวิธีแปลงสไลด์ทั้งหมดในการนำเสนอเป็นภาพใน Python:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    # เรนเดอร์งานนำเสนอเป็นภาพสไลด์ต่อสไลด์.
    for i, slide in enumerate(presentation.slides):
        # ควบคุมสไลด์ที่ซ่อนอยู่ (ไม่เรนเดอร์สไลด์ที่ซ่อน).
        if slide.hidden:
            continue

        # แปลงสไลด์เป็นภาพ.
        with slide.get_image(scale_x, scale_y) as image:
            # บันทึกภาพในรูปแบบ JPEG.
            image.save("Slide_{0}.jpg".format(i), slides.ImageFormat.JPEG)
```

## **การแสดงผลสีอีโมจิ**

{{% alert title="Note" color="warning" %}} 
เพื่อให้การเรนเดอร์สีอีโมจิทำงานอย่างถูกต้องเมื่อแปลงสไลด์การนำเสนอเป็นภาพ ฟอนท์อีโมจิที่ใช้ในการนำเสนอต้องถูกติดตั้งและพร้อมใช้งานบนระบบที่ทำการแปลง ตัวอย่างเช่น หากการนำเสนอใช้ **Segoe UI Emoji** แล้วฟอนท์นี้หายไป อีโมจิอาจปรากฏเป็นแบบสีเดียวในภาพที่ได้
{{% /alert %}}

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับการเรนเดอร์สไลด์พร้อมแอนิเมชันหรือไม่?**

ไม่, เมธอด `get_image` จะบันทึกเฉพาะภาพนิ่งของสไลด์เท่านั้น ไม่รวมแอนิเมชัน

**สามารถส่งออกสไลด์ที่ซ่อนได้เป็นภาพหรือไม่?**

ได้, สไลด์ที่ซ่อนได้รับการประมวลผลเช่นเดียวกับสไลด์ปกติ เพียงตรวจสอบให้แน่ใจว่ามีการรวมสไลด์เหล่านั้นในลูปการประมวลผล

**สามารถบันทึกภาพพร้อมเงาและเอฟเฟกต์ได้หรือไม่?**

ได้, Aspose.Slides รองรับการเรนเดอร์เงา, ความโปร่งใส, และเอฟเฟกต์กราฟิกอื่นๆ เมื่อบันทึกสไลด์เป็นภาพ