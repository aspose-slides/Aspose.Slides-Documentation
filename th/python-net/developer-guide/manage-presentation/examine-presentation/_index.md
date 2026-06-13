---
title: ดึงและอัปเดตข้อมูลการนำเสนอใน Python
linktitle: ข้อมูลการนำเสนอ
type: docs
weight: 30
url: /th/python-net/examine-presentation/
keywords:
- รูปแบบการนำเสนอ
- คุณสมบัติการนำเสนอ
- คุณสมบัติเอกสาร
- รับคุณสมบัติ
- อ่านคุณสมบัติ
- เปลี่ยนคุณสมบัติ
- แก้ไขคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "สำรวจสไลด์ โครงสร้าง และเมตาดาต้าในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อให้ได้ข้อมูลเชิงลึกที่เร็วขึ้นและการตรวจสอบเนื้อหาที่ชาญฉลาดยิ่งขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม อ่านคุณสมบัติเ�เอกสารของมัน และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/) เพื่อแสดงการดำเนินการทั่วไปสำหรับการทำงานกับข้อมูลเมตาของการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนที่จะทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่นๆ) ขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอโดยไม่ต้องโหลดการนำเสนอ ดูโค้ด Python นี้ได้:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **รับคุณสมบัติการนำเสนอ**

โค้ด Python นี้จะแสดงวิธีรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

คุณอาจต้องการดู [properties under the DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/#properties) class

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) ที่ให้คุณเปลี่ยนแปลงคุณสมบัติการนำเสนอได้

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติเข้าเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

ตัวอย่างโค้ดนี้แสดงวิธีแก้ไขคุณสมบัติบางอย่างของการนำเสนอ:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

ผลลัพธ์ของการเปลี่ยนแปลงคุณสมบัติเข้าเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อขอข้อมูลเพิ่มเกี่ยวกับการนำเสนอและคุณลักษณะความปลอดภัย คุณอาจพอใจกับลิงก์ต่อไปนี้:

- [ตรวจสอบว่าการนำเสนอถูกเข้ารหัสหรือไม่](https://docs.aspose.com/slides/th/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันการเขียน (อ่านเท่านั้น) หรือไม่](https://docs.aspose.com/slides/th/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [ตรวจสอบว่าการนำเสนอถูกป้องกันด้วยรหัสผ่านก่อนโหลดหรือไม่](https://docs.aspose.com/slides/th/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [ยืนยันรหัสผ่านที่ใช้ปกป้องการนำเสนอ](https://docs.aspose.com/slides/th/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบว่าแบบอักษรถูกฝังอยู่หรือไม่และเป็นแบบใด?**

ตรวจสอบข้อมูล [embedded-font information](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ที่ระดับการนำเสนอ แล้วเปรียบเทียบรายการนั้นกับชุด [fonts actually used across content](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_fonts/) เพื่อระบุว่าแบบอักษรใดจำเป็นต่อการแสดงผล

**ฉันจะบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ซ่อนอยู่หรือไม่และจำนวนเท่าใด?**

วนผ่าน [slide collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/hidden/) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและการกำหนดทิศทางสไลด์ที่กำหนดเองและว่ามันแตกต่างจากค่าเริ่มต้นหรือไม่?**

ได้ – เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slide_size/) และการกำหนดทิศทางปัจจุบันกับค่าตั้งต้นมาตรฐาน; จะช่วยคาดการณ์พฤติกรรมเมื่อพิมพ์และส่งออก

**มีวิธีเร็วๆ ที่จะดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้ – ท่องทุก [charts](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/) ตรวจสอบ [data source](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/) ของพวกมัน และบันทึกว่าข้อมูลเป็นภายในหรือเชื่อมโยง พร้อมระบุลิงก์ที่เสียหายหากมี

**ฉันจะประเมินสไลด์ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์นับจำนวนอ็อบเจ็กต์และมองหาภาพขนาดใหญ่, ความโปร่งแสง, เงา, แอนิเมชันและสื่อมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อชี้ให้เห็นจุดรบกวนด้านประสิทธิภาพที่อาจเกิดขึ้น