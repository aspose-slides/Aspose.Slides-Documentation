---
title: แปลงงานนำเสนอ PowerPoint เป็น TIFF ด้วย Python
titlelink: PowerPoint เป็น TIFF
type: docs
weight: 90
url: /th/python-net/convert-powerpoint-to-tiff/
keywords:
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- PowerPoint เป็น TIFF
- OpenDocument เป็น TIFF
- งานนำเสนอเป็น TIFF
- สไลด์เป็น TIFF
- PPT เป็น TIFF
- PPTX เป็น TIFF
- ODP เป็น TIFF
- Python
- Aspose.Slides
description: "เรียนรู้วิธีการแปลงงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) เป็นภาพ TIFF คุณภาพสูงอย่างง่ายดายด้วย Aspose.Slides สำหรับ Python ผ่าน .NET พร้อมคู่มือทีละขั้นตอนและตัวอย่างโค้ดที่รวมอยู่"
---
## **Introduction**

TIFF (**Tagged Image File Format**) เป็นรูปแบบภาพเรสเตอร์แบบไม่สูญเสียข้อมูลที่ได้รับความนิยมอย่างกว้างขวาง โดยรู้จักจากคุณภาพที่ยอดเยี่ยมและการรักษารายละเอียดของกราฟิกอย่างแม่นยำ นักออกแบบ, ช่างภาพ, และผู้จัดพิมพ์บนเดสก์ท็อปมักเลือกใช้ TIFF เพื่อรักษาชั้น, ความแม่นยำของสี, และการตั้งค่าเดิมของภาพ

ใช้ Aspose.Slides, คุณสามารถแปลงสไลด์ PowerPoint (PPT, PPTX) และสไลด์ OpenDocument (ODP) ของคุณเป็นภาพ TIFF คุณภาพสูงได้อย่างง่ายดาย เพื่อให้การนำเสนอของคุณคงไว้ซึ่งความแม่นยำของภาพสูงสุด

## **Convert a Presentation to TIFF**

โดยใช้เมธอด [save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/#methods) ที่มาจากคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) คุณสามารถแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้อย่างรวดเร็ว ภาพ TIFF ที่สร้างขึ้นจะสอดคล้องกับขนาดสไลด์เริ่มต้น

This Python code demonstrates how to convert a PowerPoint presentation to TIFF:

```py
import aspose.slides as slides

# สร้างอ็อบเจ็กต์คลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
with slides.Presentation("presentation.pptx") as presentation:
    # บันทึกงานนำเสนอเป็น TIFF.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **Convert a Presentation to Black-and-White TIFF**

คุณสมบัติ [bw_conversion_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) ในคลาส [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) ให้คุณระบุอัลกอริธึมที่ใช้เมื่อต้องแปลงสไลด์หรือภาพสีเป็น TIFF ขาว-ดำ โปรดทราบว่าการตั้งค้านี้จะใช้ได้เฉพาะเมื่อคุณสมบัติ [compression_type](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/compression_type/) ตั้งค่าเป็น `CCITT4` หรือ `CCITT3`.

สมมติว่าเรามีไฟล์ "sample.pptx" ที่มีสไลด์ต่อไปนี้:

![สไลด์การนำเสนอ](slide_black_and_white.png)

โค้ด Python นี้แสดงวิธีการแปลงสไลด์สีเป็น TIFF ขาว-ดำ:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

ผลลัพธ์:

![TIFF ขาว-ดำ](TIFF_black_and_white.png)

## **Convert a Presentation to TIFF with Custom Size**

หากคุณต้องการภาพ TIFF ที่มีขนาดเฉพาะ คุณสามารถกำหนดค่าที่ต้องการโดยใช้คุณสมบัติที่มีใน [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) ตัวอย่างเช่น คุณสมบัติ [image_size](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/image_size/) ให้คุณกำหนดขนาดของภาพที่ได้

This Python code demonstrates how to convert a PowerPoint presentation to TIFF images with a custom size:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# สร้างอ็อบเจ็กต์คลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # ตั้งค่าชนิดการบีบอัด.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # ตั้งค่า DPI ของภาพ.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # ตั้งค่าขนาดของภาพ.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # บันทึกงานนำเสนอเป็น TIFF พร้อมขนาดที่ระบุ.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **Convert a Presentation to TIFF with Custom Image Pixel Format**

โดยใช้คุณสมบัติ [pixel_format](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/pixel_format/) จากคลาส [TiffOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/tiffoptions/) คุณสามารถระบุรูปแบบพิกเซลที่ต้องการสำหรับภาพ TIFF ที่ได้

This Python code demonstrates how to convert a PowerPoint presentation to a TIFF image with a custom pixel format:

```py
import aspose.slides as slides

# สร้างอ็อบเจ็กต์คลาส Presentation ที่แทนไฟล์งานนำเสนอ (PPT, PPTX, ODP ฯลฯ).
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # บันทึกงานนำเสนอเป็น TIFF พร้อมขนาดภาพที่ระบุ.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="primary" %}}
ลองดู [ตัวแปลง PowerPoint เป็นโปสเตอร์ฟรีของ Aspose](https://products.aspose.app/slides/th/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**ฉันสามารถแปลงสไลด์เดี่ยวแทนการแปลงการนำเสนอ PowerPoint ทั้งหมดเป็น TIFF ได้หรือไม่?**

ได้ครับ. Aspose.Slides อนุญาตให้คุณแปลงสไลด์เดี่ยวจากการนำเสนอ PowerPoint และ OpenDocument เป็นภาพ TIFF ได้แยกกัน.

**มีข้อจำกัดใดเกี่ยวกับจำนวนสไลด์เมื่อแปลงการนำเสนอเป็น TIFF หรือไม่?**

ไม่ครับ, Aspose.Slides ไม่กำหนดข้อจำกัดใดเกี่ยวกับจำนวนสไลด์ คุณสามารถแปลงการนำเสนอใด ๆ ไม่ว่าจะมีขนาดเท่าใดก็ได้เป็นรูปแบบ TIFF.

**การเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนของ PowerPoint จะได้รับการคงไว้เมื่อตัดแปลงสไลด์เป็น TIFF หรือไม่?**

ไม่ครับ, TIFF เป็นรูปแบบภาพคงที่ ดังนั้นการเคลื่อนไหวและเอฟเฟกต์การเปลี่ยนจะไม่คงอยู่; มีเพียงสแนปช็อตคงที่ของสไลด์เท่านั้นที่ถูกส่งออก.