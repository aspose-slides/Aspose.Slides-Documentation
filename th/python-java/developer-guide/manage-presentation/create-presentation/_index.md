---
title: สร้างงานนำเสนอใน Python ผ่าน Java
linktitle: สร้างงานนำเสนอ
type: docs
weight: 10
url: /th/python-java/create-presentation/
keywords:
- สร้างงานนำเสนอ
- งานนำเสนอใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Java
- Aspose.Slides
description: "สร้างงานนำเสนอใน Python ผ่าน Java ด้วย Aspose.Slides—สร้างไฟล์ PPT, PPTX, และ ODP, รับประโยชน์จากการสนับสนุน OpenDocument, และบันทึกโดยโปรแกรมเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีสร้างงานนำเสนอด้วย Aspose.Slides for Python via Java, เพิ่มรูปร่างพร้อมข้อความลงในสไลด์แรก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX. ส่วน FAQ ครอบคลุมรูปแบบผลลัพธ์, แม่แบบ, ขนาดสไลด์, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้สิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA.

ก่อนเริ่มต้น, ติดตั้ง Python, JDK, JPype, และ Aspose.Slides for Python via Java. ดู [Installation](/slides/th/python-java/installation/) สำหรับขั้นตอนบน Windows, Linux, และ macOS.

## **สร้างงานนำเสนอ**

การสร้างไฟล์ PowerPoint ตั้งแต่ต้นใน Aspose.Slides for Python via Java ทำได้ง่ายโดยการสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/). ตัวสร้างจะให้สำเนาว่างที่มีสไลด์เดียว, ทำให้คุณมีผืนแคนวาสพร้อมสำหรับรูปร่าง, ข้อความ, แผนภูมิ, หรือเนื้อหาอื่น ๆ ที่แอปพลิเคชันของคุณต้องการ. หลังจากที่คุณปรับแต่งสไลด์นั้นหรือเพิ่มสไลด์ใหม่, คุณสามารถบันทึกผลลัพธ์เป็น PPTX, PPT รุ่นเก่า, หรือแม้กระทั่งรูปแบบ OpenDocument. ตัวอย่างโค้ดสั้นด้านล่างแสดงขั้นตอนทำงานนี้โดยการเพิ่มรูปร่างง่าย ๆ ลงบนสไลด์แรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/).
1. รับสไลด์แรกโดยใช้ดัชนี 0.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) ประเภท [ShapeType.Cloud](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapetype/#Cloud) ด้วย [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shapecollection/#addAutoShape).
1. กำหนดข้อความของรูปร่างโดยใช้ [TextFrame.setText](https://reference.aspose.com/slides/th/python-java/aspose.slides/textframe/#setText).
1. บันทึกงานนำเสนอโดยใช้ [Presentation.save](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#save) พร้อม [SaveFormat.Pptx](https://reference.aspose.com/slides/th/python-java/aspose.slides/saveformat/#Pptx).

ตัวอย่างต่อไปนี้จะเริ่มเครื่องเสมือน Java (JVM) หากยังไม่ได้ทำงาน, เพิ่มรูปร่างเมฆพร้อมข้อความลงในสไลด์แรก, และบันทึกงานนำเสนอ. บันทึกเป็น *create_presentation.py*:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# สร้างงานนำเสนอที่มีสไลด์เปล่าเดียว.
presentation = Presentation()
try:
    # รับสไลด์แรก.
    slide = presentation.getSlides().get_Item(0)

    # เพิ่มรูปร่างเมฆและกำหนดข้อความ.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # บันทึกงานนำเสนอเป็นไฟล์ PPTX.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

เรียกใช้สคริปต์ในสภาพแวดล้อมที่คุณได้ติดตั้งแพคเกจไว้:

```sh
python create_presentation.py
```

มุมซ้ายบนของเมฆห่างจากขอบซ้ายและขอบบนของสไลด์ 20 พอยต์, และเมฆมีความกว้าง 200 พอยต์และความสูง 80 พอยต์. สคริปต์บันทึก *new_presentation.pptx* ไว้ในไดเร็กทอรีทำงานปัจจุบัน, มีสไลด์เดียวที่บรรจุเมฆและข้อความของมัน. JVM จะทำงานต่อจนกระทั่งกระบวนการ Python สิ้นสุด; ดู [Limitations and API Differences](/slides/th/python-java/limitations-and-api-differences/#import-the-library). หากไม่มีใบอนุญาต, Aspose.Slides จะเพิ่มกล่องข้อความลายน้ำการประเมินผลในทุกสไลด์ที่บันทึก; ดู [Licensing](/slides/th/python-java/licensing/).

ผลลัพธ์:

![งานนำเสนอใหม่](new_presentation.png)

## **คำถามที่พบบ่อย**

**ฉันสามารถบันทึกงานนำเสนอใหม่เป็นรูปแบบใดได้บ้าง?**

คุณสามารถบันทึกเป็น [PPTX, PPT, and ODP](/slides/th/python-java/save-presentation/), และส่งออกเป็น [PDF](/slides/th/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/th/python-java/convert-powerpoint-to-xps/), [HTML](/slides/th/python-java/convert-powerpoint-to-html/), [SVG](/slides/th/python-java/render-a-slide-as-an-svg-image/), และ [images](/slides/th/python-java/convert-powerpoint-to-png/), เป็นต้น.

**ฉันสามารถเริ่มจากแม่แบบ (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?**

ได้. โหลดแม่แบบและบันทึกเป็นรูปแบบที่ต้องการ; POTX/POTM/PPTM และรูปแบบคล้ายกัน [are supported](/slides/th/python-java/supported-file-formats/).

**ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์อย่างไรเมื่อตั้งค่าการสร้างงานนำเสนอ?**

ตั้งค่า [slide size](/slides/th/python-java/slide-size/) (รวมถึงค่าเตรียมใช้เช่น 4:3 และ 16:9 หรือขนาดกำหนดเอง) และเลือกวิธีการปรับขนาดเนื้อหา.

**ขนาดและพิกัดวัดเป็นหน่วยใด?**

เป็นพอยต์: 1 นิ้วเท่ากับ 72 หน่วย.

**ฉันจะจัดการงานนำเสนอขนาดใหญ่มาก (มีไฟล์สื่อจำนวนมาก) เพื่อ ลดการใช้หน่วยความจำอย่างไร?**

ใช้ [BLOB management strategies](/slides/th/python-java/manage-blob/), จำกัดการเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และเลือกกระบวนการทำงานบนไฟล์แทนสตรีมในหน่วยความจำทั้งหมด.

**ฉันสามารถสร้าง/บันทึกงานนำเสนอพร้อมกันได้หรือไม่?**

คุณไม่สามารถทำงานกับอินสแตนซ์ [Presentation]เดียวจากหลาย [threads](/slides/th/python-java/multithreading/) ได้. ให้รันอินสแตนซ์แยกจากกันต่อแต่ละเธรดหรือโปรเซส.

**ฉันจะลบลายน้ำทดลองและข้อจำกัดต่าง ๆ ได้อย่างไร?**

[Apply a license](/slides/th/python-java/licensing/) หนึ่งครั้งต่อโปรเซส. ไฟล์ XML ของใบอนุญาตต้องไม่ถูกแก้ไข, และการตั้งค่าใบอนุญาตควรทำให้สอดคล้องกันหากมีหลายเธรด.

**ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?**

ได้. [Digital signatures](/slides/th/python-java/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) รองรับงานนำเสนอ.

**แมโคร (VBA) ได้รับการสนับสนุนในงานนำเสนอที่สร้างหรือไม่?**

ได้. คุณสามารถ [create/edit VBA projects](/slides/th/python-java/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้แมโคร เช่น PPTM/PPSM.