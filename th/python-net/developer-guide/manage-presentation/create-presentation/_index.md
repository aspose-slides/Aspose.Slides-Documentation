---
title: สร้างพรีเซนเทชันใน Python
linktitle: สร้างพรีเซนเทชัน
type: docs
weight: 10
url: /th/python-net/create-presentation/
keywords:
- สร้างพรีเซนเทชัน
- พรีเซนเทชันใหม่
- สร้าง PPT
- PPT ใหม่
- สร้าง PPTX
- PPTX ใหม่
- สร้าง ODP
- ODP ใหม่
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "สร้างพรีเซนเทชัน PowerPoint ด้วย Python และ Aspose.Slides—ผลิตไฟล์ PPT, PPTX และ ODP, รับประโยชน์จากการสนับสนุน OpenDocument, และบันทึกอย่างโปรแกรมเมติกเพื่อผลลัพธ์ที่เชื่อถือได้."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการสร้างพรีเซนเทชันด้วย Aspose.Slides สำหรับ Python ผ่าน .NET, เพิ่มรูปทรงที่มีข้อความไปยังสไลด์แรก, และบันทึกผลลัพธ์เป็นไฟล์ PPTX. API เดียวกันยังสามารถบันทึกพรีเซนเทชันเป็น PPT และ ODP, ดังนั้นคุณสามารถรองรับทั้งรูปแบบ PowerPoint และ OpenDocument จากฐานโค้ดเดียวโดยไม่ต้องใช้ Microsoft Office. ส่วน FAQ สั้น ๆ ที่ท้ายบทความครอบคลุมคำถามทั่วไปเกี่ยวกับรูปแบบ, แม่แบบ, ขนาดสไลด์, หน่วยวัด, การใช้หน่วยความจำ, การทำงานหลายเธรด, การให้ลิขสิทธิ์, ลายเซ็นดิจิทัล, และการสนับสนุน VBA.

ก่อนเริ่ม, ให้ติดตั้งแพ็กเกจจาก PyPI ด้วย `pip install aspose.slides`. ดูที่ [การติดตั้ง](/slides/th/python-net/installation/) สำหรับไลบรารีที่ Linux และ macOS ต้องการ, และสำหรับสภาพแวดล้อมเสมือนที่ Python ของระบบบน Debian และ Ubuntu ต้องการ.

## **สร้างพรีเซนเทชัน**

เพื่อสร้างพรีเซนเทชันและวางรูปทรงที่มีข้อความบนสไลด์แรก, ปฏิบัติตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/). พรีเซนเทชันใหม่จะมีสไลด์ว่างหนึ่งสไลด์อยู่แล้ว.
2. ดึงสไลด์นั้นจากคอลเลกชัน [slides](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slides/th/) โดยใช้ดัชนี 0.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) รูปร่างเมฆโดยใช้เมธอด [add_auto_shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shapecollection/add_auto_shape/) ของคอลเลกชัน [shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/shapes/) ของสไลด์, และตั้งค่า [text](https://reference.aspose.com/slides/th/python-net/aspose.slides/textframe/text/).
4. บันทึกพรีเซนเทชันเป็นไฟล์ PPTX ด้วยเมธอด [save](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์พรีเซนเทชัน
with slides.Presentation() as presentation:
    # ดึงสไลด์แรก
    slide = presentation.slides[0]

    # เพิ่ม auto-shape ประเภท CLOUD
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # บันทึกพรีเซนเทชันเป็นไฟล์ PPTX
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

มุมซ้ายบนของเมฆห่างจากขอบซ้ายของสไลด์ 20 จุด และห่างจากขอบบนของสไลด์ 20 จุด, และเมฆมีความกว้าง 200 จุด และความสูง 80 จุด. คำสั่ง `with` จะปล่อยทรัพยากรของพรีเซนเทชันเมื่อบล็อกสิ้นสุด. สคริปต์บันทึก *new_presentation.pptx* ไปยังโฟลเดอร์ปัจจุบัน, โดยมีสไลด์หนึ่งสไลด์ที่บรรจุเมฆและข้อความของมัน. หากไม่มีลิขสิทธิ์, Aspose.Slides จะเพิ่มลายน้ำการประเมินผลในทุกสไลด์ที่บันทึก; ดูที่ [การให้ลิขสิทธิ์](/slides/th/python-net/licensing/).

ผลลัพธ์:

![การนำเสนอใหม่](new_presentation.png)

## **คำถามที่พบบ่อย**

### รูปแบบใดบ้างที่ฉันสามารถบันทึกพรีเซนเทชันใหม่เป็นได้?

คุณสามารถบันทึกเป็น [PPTX, PPT, และ ODP](/slides/th/python-net/save-presentation/) และส่งออกเป็น [PDF](/slides/th/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/th/python-net/convert-powerpoint-to-xps/), [HTML](/slides/th/python-net/convert-powerpoint-to-html/), [SVG](/slides/th/python-net/render-a-slide-as-an-svg-image/), และ [images](/slides/th/python-net/convert-powerpoint-to-png/) เป็นต้น.

### ฉันสามารถเริ่มจากเทมเพลต (POTX/POTM) แล้วบันทึกเป็น PPTX ปกติได้หรือไม่?

ได้. โหลดเทมเพลตแล้วบันทึกเป็นรูปแบบที่ต้องการ; รูปแบบ POTX/POTM/PPTM และรูปแบบคล้ายกัน [ได้รับการสนับสนุน](/slides/th/python-net/supported-file-formats/).

### ฉันจะควบคุมขนาด/อัตราส่วนของสไลด์เมื่อสร้างพรีเซนเทชันได้อย่างไร?

ตั้งค่า [slide size](/slides/th/python-net/slide-size/) (รวมถึงค่าที่กำหนดล่วงหน้าเช่น 4:3 และ 16:9 หรือขนาดที่กำหนดเอง) และเลือกวิธีการสเกลเนื้อหา.

### ขนาดและพิกัดวัดเป็นหน่วยอะไร?

เป็นหน่วยจุด: 1 นิ้วเท่ากับ 72 หน่วย.

### ฉันจะจัดการพรีเซนเทชันขนาดใหญ่มาก (ที่มีไฟล์สื่อหลายไฟล์) เพื่อลดการใช้หน่วยความจำได้อย่างไร?

ใช้ [BLOB management strategies](/slides/th/python-net/manage-blob/), จำกัดการจัดเก็บในหน่วยความจำโดยใช้ไฟล์ชั่วคราว, และเลือกใช้กระบวนการทำงานแบบไฟล์แทนสตรีมในหน่วยความจำเท่านั้น.

### ฉันสามารถสร้าง/บันทึกพรีเซนเทชันแบบขนานได้หรือไม่?

คุณไม่สามารถทำงานกับอินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เดียวกันจาก [multiple threads](/slides/th/python-net/multithreading/) ได้. ให้เรียกใช้อินสแตนซ์แยกจากกันต่อแต่ละเธรดหรือโพรเซส.

### ฉันจะลบลายน้ำทดลองและข้อจำกัดออกได้อย่างไร?

[Apply a license](/slides/th/python-net/licensing/) ครั้งหนึ่งต่อกระบวนการ. ไฟล์ XML ของลิขสิทธิ์ต้องไม่ถูกแก้ไข, และการตั้งค่าลิขสิทธิ์ควรทำให้สอดคล้องกันหากมีหลายเธรดที่เกี่ยวข้อง.

### ฉันสามารถลงลายเซ็นดิจิทัลให้กับ PPTX ที่สร้างได้หรือไม่?

ได้. [Digital signatures](/slides/th/python-net/digital-signature-in-powerpoint/) (การเพิ่มและการตรวจสอบ) ได้รับการสนับสนุนสำหรับพรีเซนเทชัน.

### แมโคร (VBA) ถูกสนับสนุนในพรีเซนเทชันที่สร้างหรือไม่?

ได้. คุณสามารถ [create/edit VBA projects](/slides/th/python-net/presentation-via-vba/) และบันทึกไฟล์ที่เปิดใช้งานแมโครเช่น PPTM/PPSM.