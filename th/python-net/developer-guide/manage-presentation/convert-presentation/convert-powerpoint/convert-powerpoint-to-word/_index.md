---
title: แปลงงานนำเสนอ PowerPoint เป็นเอกสาร Word ด้วย Python
linktitle: PowerPoint ไป Word
type: docs
weight: 110
url: /th/python-net/convert-powerpoint-to-word/
keywords:
- PowerPoint เป็น DOCX
- OpenDocument เป็น DOCX
- งานนำเสนอเป็น DOCX
- สไลด์เป็น DOCX
- PPT เป็น DOCX
- PPTX เป็น DOCX
- ODP เป็น DOCX
- PowerPoint เป็น DOC
- OpenDocument เป็น DOC
- งานนำเสนอเป็น DOC
- สไลด์เป็น DOC
- PPT เป็น DOC
- PPTX เป็น DOC
- ODP เป็น DOC
- PowerPoint ไป Word
- OpenDocument ไป Word
- งานนำเสนอไป Word
- สไลด์ไป Word
- PPT ไป Word
- PPTX ไป Word
- ODP ไป Word
- แปลง PowerPoint
- แปลง OpenDocument
- แปลงงานนำเสนอ
- แปลงสไลด์
- แปลง PPT
- แปลง PPTX
- แปลง ODP
- Python
- Aspose.Slides
description: "เรียนรู้วิธีแปลงงานนำเสนอ PowerPoint และ OpenDocument ให้เป็นเอกสาร Word อย่างง่ายดายด้วย Aspose.Slides for Python via .NET คู่มือแบบขั้นตอนพร้อมโค้ดตัวอย่าง Python ให้โซลูชันสำหรับนักพัฒนาที่ต้องการปรับปรุงกระบวนการทำงานเอกสารของตน"
---
## **ภาพรวม**

บทความนี้ให้แนวทางแก่นักพัฒนาสำหรับการแปลงงานนำเสนอ PowerPoint และ OpenDocument ให้เป็นเอกสาร Word โดยใช้ Aspose.Slides for Python via .NET และ Aspose.Words for Python via .NET คู่มือแบบขั้นตอนช่วยคุณผ่านทุกขั้นตอนของกระบวนการแปลง

## **แปลงงานนำเสนอเป็นเอกสาร Word**

ทำตามคำแนะนำด้านล่างเพื่อแปลงงานนำเสนอ PowerPoint หรือ OpenDocument ให้เป็นเอกสาร Word:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) และโหลดไฟล์งานนำเสนอ
2. สร้างอินสแตนซ์ของคลาส [Document](https://reference.aspose.com/words/python-net/aspose.words/document/) และ [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/) เพื่อสร้างเอกสาร Word
3. ตั้งค่าขนาดหน้าเอกสาร Word ให้ตรงกับขนาดของงานนำเสนอโดยใช้คุณสมบัติ [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/)
4. ตั้งค่าขอบในเอกสาร Word โดยใช้คุณสมบัติ [DocumentBuilder.page_setup](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/page_setup/)
5. วนผ่านสไลด์ทั้งหมดของงานนำเสนอโดยใช้คุณสมบัติ [Presentation.slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/)
    - สร้างภาพสไลด์โดยใช้เมธอด `get_image` จากคลาส [Slide](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/) และบันทึกลงในสตรีมหน่วยความจำ
    - เพิ่มภาพสไลด์ลงในเอกสาร Word โดยใช้เมธอด `insert_image` จากคลาส [DocumentBuilder](https://reference.aspose.com/words/python-net/aspose.words/documentbuilder/)
6. บันทึกเอกสาร Word เป็นไฟล์

สมมติว่าเรามีงานนำเสนอ "sample.pptx" ที่มีลักษณะแบบนี้:

![งานนำเสนอ PowerPoint](PowerPoint.png)

ตัวอย่างโค้ด Python ด้านล่างแสดงวิธีการแปลงงานนำเสนอ PowerPoint ให้เป็นเอกสาร Word:

```py
import aspose.slides as slides
import aspose.words as words

# โหลดไฟล์งานนำเสนอ
with slides.Presentation("sample.pptx") as presentation:

    # สร้างอ็อบเจ็กต์ Document และ DocumentBuilder
    document = words.Document()
    builder = words.DocumentBuilder(document)

    # ตั้งค่าขนาดหน้าของเอกสาร Word
    slide_size = presentation.slide_size.size
    builder.page_setup.page_width = slide_size.width
    builder.page_setup.page_height = slide_size.height

    # ตั้งค่าขอบในเอกสาร Word
    builder.page_setup.left_margin = 0
    builder.page_setup.right_margin = 0
    builder.page_setup.top_margin = 0
    builder.page_setup.bottom_margin = 0

    scale_x = 2
    scale_y = 2

    # วนผ่านสไลด์ทั้งหมดของงานนำเสนอ
    for slide in presentation.slides:

        # สร้างภาพสไลด์และบันทึกลงในสตรีมหน่วยความจำ
        with slide.get_image(scale_x, scale_y) as image:
            image_stream = BytesIO()
            image.save(image_stream, slides.ImageFormat.PNG)

        # เพิ่มภาพสไลด์ลงในเอกสาร Word
        image_stream.seek(0)
        image_width = builder.page_setup.page_width
        image_height = builder.page_setup.page_height
        builder.insert_image(image_stream.read(), image_width, image_height)

        builder.insert_break(words.BreakType.PAGE_BREAK)

    # บันทึกเอกสาร Word ลงไฟล์
    document.save("output.docx")
```

ผลลัพธ์:

![เอกสาร Word](Word.png)

{{% alert color="primary" %}} 

ลองใช้ [**Online PPT to Word Converter**](https://products.aspose.app/slides/th/conversion/ppt-to-word) ของเราเพื่อดูว่าคุณจะได้ประโยชน์อะไรจากการแปลงงานนำเสนอ PowerPoint และ OpenDocument ให้เป็นเอกสาร Word. 

{{% /alert %}}

## **คำถามที่พบบ่อย**

**ต้องติดตั้งคอมโพเนนต์อะไรบ้างเพื่อแปลงงานนำเสนอ PowerPoint และ OpenDocument ให้เป็นเอกสาร Word?**

คุณเพียงแค่ต้องเพิ่มแพ็กเกจที่เกี่ยวข้องสำหรับ [Aspose.Slides for Python via .NET](https://pypi.org/project/Aspose.Slides/) และ [Aspose.Words for Python .NET](https://pypi.org/project/aspose-words/) ลงในโครงการ Python ของคุณ แพ็กเกจทั้งสองทำงานเป็น API แยกส่วนและไม่จำเป็นต้องติดตั้ง Microsoft Office

**รองรับรูปแบบงานนำเสนอ PowerPoint และ OpenDocument ทั้งหมดหรือไม่?**

Aspose.Slides for Python .NET [รองรับรูปแบบงานนำเสนอทั้งหมด](/slides/th/python-net/supported-file-formats/) รวมถึง PPT, PPTX, ODP และประเภทไฟล์ทั่วไปอื่น ๆ สิ่งนี้ทำให้คุณสามารถทำงานกับงานนำเสนอที่สร้างด้วยหลายเวอร์ชันของ Microsoft PowerPoint