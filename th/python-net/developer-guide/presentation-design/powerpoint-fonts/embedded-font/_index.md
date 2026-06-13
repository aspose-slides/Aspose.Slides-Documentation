---
title: ฝังฟอนต์ในงานนำเสนอด้วย Python
linktitle: การฝังฟอนต์
type: docs
weight: 40
url: /th/python-net/embedded-font/
keywords:
- เพิ่มฟอนต์
- ฝังฟอนต์
- การฝังฟอนต์
- รับฟอนต์ที่ฝัง
- เพิ่มฟอนต์ที่ฝัง
- ลบฟอนต์ที่ฝัง
- บีบอัดฟอนต์ที่ฝัง
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "ฝังฟอนต์ TrueType ในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET เพื่อให้การเรนเดอร์ที่แม่นยำบนทุกแพลตฟอร์ม"
---
## **บทนำ**

**การฝังฟอนต์ใน PowerPoint** ทำให้การนำเสนอของคุณคงรูปลักษณ์ตามที่ตั้งใจไว้บนระบบต่างๆ ไม่ว่าจะใช้ฟอนต์ที่เป็นเอกลักษณ์เพื่อความสร้างสรรค์หรือฟอนต์มาตรฐาน การฝังฟอนต์ช่วยป้องกันการรบกวนของข้อความและการจัดวาง

หากคุณใช้ฟอนต์จากบุคคลภายนอกหรือฟอนต์ที่ไม่เป็นมาตรฐานเพื่อความสร้างสรรค์ในงานของคุณ คุณก็มีเหตุผลเพิ่มเติมในการฝังฟอนต์ของคุณ ส่วนหากไม่ได้ฝังฟอนต์ (ไม่มีการฝัง) ข้อความหรือเลขบนสไลด์ การจัดวาง การออกแบบ ฯลฯ อาจเปลี่ยนแปลงหรือกลายเป็นสี่เหลี่ยมสับสน

ใช้คลาส [FontsManager](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontdata/), และ [Compress](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/) เพื่อจัดการฟอนต์ที่ฝัง

## **รับและลบฟอนต์ที่ฝัง**

ดึงหรือเอาฟอนต์ที่ฝังออกจากการนำเสนอได้อย่างง่ายดายด้วยเมธอด [get_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) และ [remove_embedded_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/remove_embedded_font/)

โค้ด Python นี้จะแสดงวิธีการดึงและลบฟอนต์ที่ฝังออกจากการนำเสนอ:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # เรนเดอร์สไลด์ที่มีกรอบข้อความซึ่งใช้ฟอนต์ 'FunSized' ที่ฝังไว้
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # ดึงฟอนต์ที่ฝังทั้งหมด
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # ค้นหาฟอนต์ 'Calibri'
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # ลบฟอนต์ 'Calibri'
    fonts_manager.remove_embedded_font(font_data)

    # เรนเดอร์สไลด์; ฟอนต์ 'Calibri' จะถูกแทนที่ด้วยฟอนต์ที่มีอยู่
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # บันทึกงานนำเสนอโดยไม่มีฟอนต์ 'Calibri' ที่ฝังลงดิสก์
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **เพิ่มฟอนต์ที่ฝัง**

โดยใช้ enum [EmbedFontCharacters](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/embedfontcharacters/) และสอง overload ของเมธอด [add_embedded_font](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/add_embedded_font/) คุณสามารถเลือกกฎการฝังที่ต้องการเพื่อฝังฟอนต์ในงานนำเสนอ โค้ด Python นี้จะแสดงวิธีการฝังและเพิ่มฟอนต์ให้กับการนำเสนอ:

```python
import aspose.slides as slides

# โหลดงานนำเสนอ.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # บันทึกงานนำเสนอลงดิสก์.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **บีบอัดฟอนต์ที่ฝัง**

ปรับขนาดไฟล์ให้เล็กลงโดยการบีบอัดฟอนต์ที่ฝังด้วยเมธอด [compress_embedded_fonts](https://reference.aspose.com/slides/th/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/)

ตัวอย่างโค้ดสำหรับการบีบอัด:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **ถามบ่อย**

**ฉันจะรู้ได้อย่างไรว่าฟอนต์เฉพาะในงานนำเสนอจะยังคงถูกแทนที่ระหว่างการเรนเดอร์แม้จะฝังแล้ว?**

ตรวจสอบข้อมูลการแทนที่ในตัวจัดการฟอนต์และกฎการสำรอง/การแทนที่: หากฟอนต์ไม่พร้อมใช้งานหรือถูกจำกัด ระบบจะใช้ฟอนต์สำรอง

**การฝังฟอนต์ "ระบบ" เช่น Arial/Calibri มีประโยชน์หรือไม่?**

โดยทั่วไปไม่-โดยส่วนใหญ่ฟอนต์เหล่านี้พร้อมใช้งานเสมอ อย่างไรก็ตามเพื่อความพกพาเต็มรูปแบบในสภาพแวดล้อม "thin" (Docker, เซิร์ฟเวอร์ Linux ที่ไม่มีฟอนต์ติดตั้งไว้ล่วงหน้า) การฝังฟอนต์ระบบสามารถขจัดความเสี่ยงจากการแทนที่ที่ไม่คาดคิดได้