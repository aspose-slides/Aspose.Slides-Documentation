---
title: แปลงงานนำเสนอ PowerPoint เป็นเอกสาร Word ใน Python ผ่าน Java
linktitle: PowerPoint ไป Word
type: docs
weight: 110
url: /th/python-java/convert-powerpoint-to-word/
keywords:
- แปลง PowerPoint
- แปลงงานนำเสนอ
- PowerPoint ไป Word
- งานนำเสนอเป็น Word
- PPT ไป Word
- PPTX ไป Word
- ODP ไป Word
- PowerPoint ไป DOCX
- PPT ไป DOCX
- PPTX ไป DOCX
- PowerPoint ไป DOC
- บันทึก PPT เป็น DOCX
- บันทึก PPTX เป็น DOCX
- ส่งออก PPT ไป DOCX
- ส่งออก PPTX ไป DOCX
- Python
- Java
- Aspose.Slides
description: "แปลงงานนำเสนอ PowerPoint และ OpenDocument เป็น Word ใน Python ผ่าน Java ด้วย Aspose.Slides และ Aspose.Words โดยผสานรูปภาพสไลด์กับข้อความที่สามารถแก้ไขได้"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีแปลงงานนำเสนอ PowerPoint และ OpenDocument เป็นเอกสาร Word ด้วย Aspose.Slides for Python via Java ร่วมกับ Aspose.Words for Java โดย Aspose.Slides จะเรนเดอร์แต่ละสไลด์และอ่านข้อความของมัน ส่วน Aspose.Words จะสร้างเอกสาร Word ผ่าน JPype ไม่จำเป็นต้องมี Microsoft Office

เอกสารที่ได้จะประกอบด้วยรูปภาพของสไลด์ตามด้วยข้อความที่สามารถแก้ไขได้ซึ่งถูกดึงจากรูปร่างอัตโนมัติระดับบนของสไลด์นั้น รูปภาพจะคงลักษณะภาพของสไลด์ไว้; รูปทรง, แผนภูมิ, และตารางแต่ละรายการจะไม่ถูกแปลงเป็นวัตถุ Word ที่สามารถแก้ไขได้ ข้อความที่ดึงออกมาจะไม่คงรูปแบบหรือการจัดตำแหน่งของข้อความต้นฉบับ

## **แปลง PowerPoint เป็น Word**

1. ติดตั้ง [Aspose.Slides for Python via Java](/slides/th/python-java/installation/) และ Java runtime ที่เข้ากันได้
2. ดาวน์โหลด [Aspose.Words for Java](https://releases.aspose.com/words/java/). วางไฟล์ JAR หลักของมันในไดเรกทอรี `lib` ข้างสคริปต์ของคุณและเปลี่ยนชื่อเป็น `aspose-words.jar` หรือปรับเส้นทางในตัวอย่างให้ตรงกับไฟล์ที่คุณดาวน์โหลด
3. วางไฟล์งานนำเสนออินพุต `sample.pptx` ไว้ในไดเรกทอรีทำงาน เส้นทาง `lib/aspose-words.jar` ก็เป็นเส้นทางสัมพัทธ์ต่อไดเรกทอรีนั้นเช่นกัน
4. รันโค้ด Python ด้านล่างเพื่อสร้าง `output.docx`

ตัวอย่างนี้โหลดแหล่งข้อมูลด้วย [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/) และเรนเดอร์สไลด์ด้วย [Slide.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/slide/#getImage). ใช้ [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) จาก Aspose.Words เพื่อแทรกรูปภาพและข้อความลงในเอกสาร Word

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # ปรับภาพสไลด์ให้พอดีกับความกว้างของพื้นที่ข้อความโดยคงอัตราส่วนไว้
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # ต่อข้อความธรรมดาจากรูปร่างอัตโนมัติระดับบน รวมถึงกล่องข้อความ
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

แต่ละสไลด์จะเริ่มบนหน้ใหม่ ข้อความที่ดึงออกมายาวหรือรูปภาพสไลด์ที่สูงผิดปกติอาจทำให้ต้องมีหน้ามากขึ้น โค้ดจะเพิ่มการหยุดหน้าก็ต่อระหว่างสไลด์เท่านั้นและจะปล่อยงานนำเสนอและรูปภาพที่เรนเดอร์ในบล็อก `finally`. JVM จะยังคงพร้อมใช้งานสำหรับการแปลงต่อไปในกระบวนการ Python เดียวกัน

## **คำถามที่พบบ่อย**

**ต้องใช้ไลบรารีใดบ้าง?**

ใช้ Aspose.Slides for Python via Java, JPype, Java runtime ที่เข้ากันได้, และ Aspose.Words for Java ทั้งสองไลบรารีทำงานใน JVM เดียวกัน Aspose.Slides จัดการงานนำเสนอ; Aspose.Words เขียนเอกสาร Word

**ฉันสามารถแปลงไฟล์ PPT และ ODP รวมถึง PPTX ได้หรือไม่?**

ได้. แทนที่ `sample.pptx` ด้วยไฟล์ PPT หรือ ODP. ดู [Supported File Formats](/slides/th/python-java/supported-file-formats/) เพื่อดูรูปแบบไฟล์นำเข้าที่สนับสนุน

**เนื้อหาของสไลด์ทั้งหมดสามารถแก้ไขใน Word ได้หรือไม่?**

ไม่. แต่ละสไลด์จะถูกแทรกเป็นภาพคงที่พร้อมกับข้อความธรรมดาจากรูปร่างอัตโนมัติระดับบนที่เพิ่มอยู่ด้านล่าง ข้อความภายในกลุ่ม, ตาราง, SmartArt, และแผนภูมิ รวมถึงบันทึกการพูดของผู้บรรยาย จะไม่ถูกดึงโดยตัวอย่างนี้ การเคลื่อนไหวและการเปลี่ยนสไลด์จะไม่ปรากฏในเอกสาร Word

**ฉันสามารถบันทึกเป็น DOC แทน DOCX ได้หรือไม่?**

ได้. เปลี่ยนชื่อไฟล์ผลลัพธ์เป็น `output.doc`. Aspose.Words จะเลือกรูปแบบการบันทึกตามนามสกุลไฟล์เมื่อใช้ overload การบันทึกนี้