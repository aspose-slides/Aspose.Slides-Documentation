---
title: จัดการซูเปอร์สคริปต์และซับสคริปต์ในงานนำเสนอโดยใช้ Python ผ่าน Java
linktitle: ซูเปอร์สคริปต์และซับสคริปต์
type: docs
weight: 80
url: /th/python-java/superscript-and-subscript/
keywords:
- ซูเปอร์สคริปต์
- ซับสคริปต์
- เพิ่มซูเปอร์สคริปต์
- เพิ่มซับสคริปต์
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "เชี่ยวชาญการใช้ซูเปอร์สคริปต์และซับสคริปต์ใน Aspose.Slides สำหรับ Python ผ่าน Java และยกระดับงานนำเสนอของคุณด้วยการจัดรูปแบบข้อความระดับมืออาชีพเพื่อให้ได้ผลกระทบสูงสุด"
---
## **ภาพรวม**

Aspose.Slides มีฟีเจอร์สำหรับการรวมข้อความซูเปอร์สคริปต์และซับสคริปต์ลงในงานนำเสนอ PowerPoint (PPT, PPTX) และ OpenDocument (ODP) ของคุณ ไม่ว่าคุณจะต้องการเน้นสูตรเคมี สมการคณิตศาสตร์ หรืออธิบายเนื้อหาด้วยเชิงอรรถ ตัวเลือกการจัดรูปแบบพิเศษเหล่านี้ช่วยให้คงความชัดเจนและแม่นยำไว้ได้ ในบทความนี้ คุณจะได้เรียนรู้วิธีการใช้สไตล์ซูเปอร์สคริปต์และซับสคริปต์อย่างราบรื่นและทำให้สไลด์ทุกสไลด์มีผลลัพธ์ระดับมืออาชีพ

## **จัดการข้อความซูเปอร์สคริปต์และซับสคริปต์**

คุณสามารถเพิ่มข้อความซูเปอร์สคริปต์และซับสคริปต์ให้กับส่วนใดส่วนหนึ่งของย่อหน้าได้ เพื่อใช้การจัดรูปแบบนี้ในกรอบข้อความของ Aspose.Slides ให้ใช้เมธอด [setEscapement](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#setEscapement) ของคลาส [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/)  

ค่าการเอสเคปเมนต์อยู่ในช่วง -100% (ซับสคริปต์) ถึง 100% (ซูเปอร์สคริปต์) ตัวอย่างเช่น:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/)  
- ดึงสไลด์ตามดัชนีของมัน  
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ชนิด [ShapeType.Rectangle](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#Rectangle) ไปยังสไลด์  
- เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/) ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/)  
- ล้างย่อหน้าที่มีอยู่  
- สร้างย่อหน้าเพื่อเก็บข้อความซูเปอร์สคริปต์และเพิ่มลงใน [paragraph collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getParagraphs) ของกรอบข้อความ  
- สร้าง Portion  
- ใช้ [setEscapement](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#setEscapement) เพื่อตั้งค่า 0‑100 สำหรับซูเปอร์สคริปต์ (0 หมายถึงไม่มีซูเปอร์สคริปต์)  
- ตั้งค่าข้อความของ [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) แล้วเพิ่มลงใน collection ของ Portion ของย่อหน้า  
- สร้างย่อหน้าเพื่อเก็บข้อความซับสคริปต์และเพิ่มลงใน [paragraph collection](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#getParagraphs) ของกรอบข้อความ  
- สร้าง Portion  
- ใช้ [setEscapement](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/#setEscapement) เพื่อตั้งค่า -100‑0 สำหรับซับสคริปต์ (0 หมายถึงไม่มีซับสคริปต์)  
- ตั้งค่าข้อความของ [Portion](https://reference.aspose.com/slides/th/python-java/aspose.slides/portion/) แล้วเพิ่มลงใน collection ของ Portion ของย่อหน้า  
- บันทึกงานนำเสนอเป็นไฟล์ PPTX  

ตัวอย่างต่อไปนี้แสดงการดำเนินการตามขั้นตอนเหล่านี้:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Paragraph, Portion, Presentation, SaveFormat, ShapeType

# สร้างงานนำเสนอ.
presentation = Presentation()
try:
    # ดึงสไลด์.
    slide = presentation.getSlides().get_Item(0)

    # สร้างกล่องข้อความ.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100)
    text_frame = shape.getTextFrame()
    text_frame.getParagraphs().clear()

    # สร้างย่อหน้าสำหรับข้อความซูเปอร์สคริปต์.
    superscript_paragraph = Paragraph()

    # สร้าง Portion ที่มีข้อความปกติ.
    title_portion = Portion()
    title_portion.setText("SlideTitle")
    superscript_paragraph.getPortions().add(title_portion)

    # สร้าง Portion ที่มีข้อความซูเปอร์สคริปต์.
    superscript_portion = Portion()
    superscript_portion.getPortionFormat().setEscapement(30)
    superscript_portion.setText("TM")
    superscript_paragraph.getPortions().add(superscript_portion)

    # สร้างย่อหน้าสำหรับข้อความซับสคริปต์.
    subscript_paragraph = Paragraph()

    # สร้าง Portion ที่มีข้อความปกติ.
    base_portion = Portion()
    base_portion.setText("a")
    subscript_paragraph.getPortions().add(base_portion)

    # สร้าง Portion ที่มีข้อความซับสคริปต์.
    subscript_portion = Portion()
    subscript_portion.getPortionFormat().setEscapement(-25)
    subscript_portion.setText("i")
    subscript_paragraph.getPortions().add(subscript_portion)

    # เพิ่มย่อหน้าไปยังกล่องข้อความ.
    text_frame.getParagraphs().add(superscript_paragraph)
    text_frame.getParagraphs().add(subscript_paragraph)

    presentation.save("formatText.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **คำถามที่พบบ่อย**

**ซูเปอร์สคริปต์และซับสคริปต์จะยังคงอยู่เมื่อส่งออกเป็น PDF หรือรูปแบบอื่นหรือไม่?**

ใช่, Aspose.Slides จะคงรูปแบบซูเปอร์สคริปต์และซับสคริปต์อย่างถูกต้องเมื่อต้นแบบถูกส่งออกเป็น PDF, PPT/PPTX, ภาพ, และรูปแบบอื่นที่รองรับ รูปแบบพิเศษนี้จะคงสภาพอยู่ในไฟล์ผลลัพธ์ทั้งหมด  

**ซูเปอร์สคริปต์และซับสคริปต์สามารถรวมกับสไตล์การจัดรูปแบบอื่น ๆ เช่น ตัวหนา หรือ ตัวเอียงได้หรือไม่?**

ใช่, Aspose.Slides อนุญาตให้คุณผสมสไตล์ข้อความหลายแบบภายใน Portion เดียว คุณสามารถเปิดใช้งานตัวหนา, ตัวเอียง, ขีดเส้นใต้ และในขณะเดียวกันใช้ซูเปอร์สคริปต์หรือซับสคริปต์โดยกำหนดคุณสมบัติเกี่ยวข้องใน [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/)  

**การจัดรูปแบบซูเปอร์สคริปต์และซับสคริปต์ทำงานกับข้อความภายในตาราง, แผนภูมิ หรือ SmartArt หรือไม่?**

ใช่, Aspose.Slides รองรับการจัดรูปแบบภายในออบเจ็กต์ส่วนใหญ่ รวมถึงตารางและองค์ประกอบแผนภูมิ เมื่อทำงานกับ SmartArt คุณต้องเข้าถึงองค์ประกอบที่เหมาะสม (เช่น [SmartArtNode](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartartnode/)) และคอนเทนเนอร์ข้อความของมัน แล้วกำหนดคุณสมบัติของ [PortionFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/portionformat/) แบบเดียวกัน.