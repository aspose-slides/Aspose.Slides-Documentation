---
title: เรียกคืนและอัปเดตข้อมูลการนำเสนอใน Python
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
- ปรับแต่งคุณสมบัติ
- อัปเดตคุณสมบัติ
- ตรวจสอบ PPTX
- ตรวจสอบ PPT
- ตรวจสอบ ODP
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Aspose.Slides
description: "สำรวจสไลด์, โครงสร้างและเมทาดาต้าในการนำเสนอ PowerPoint และ OpenDocument ด้วย Python เพื่อรับข้อมูลเชิงลึกที่รวดเร็วและการตรวจสอบเนื้อหาที่ฉลาดขึ้น."
---
## **ภาพรวม**

บทความนี้แสดงวิธีตรวจสอบข้อมูลการนำเสนอใน Aspose.Slides โดยอธิบายวิธีกำหนดรูปแบบปัจจุบันของการนำเสนอโดยไม่ต้องโหลดไฟล์เต็ม, อ่านคุณสมบัติของเอกสาร, และอัปเดตคุณสมบัติเหล่านั้นเมื่อจำเป็น

ตัวอย่างอ้างอิงจาก API [PresentationInfo](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/) และ [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/) และแสดงการดำเนินการทั่วไปสำหรับทำงานกับเมทาดาต้าการนำเสนอ

## **ตรวจสอบรูปแบบการนำเสนอ**

ก่อนทำงานกับการนำเสนอ คุณอาจต้องการทราบว่าการนำเสนออยู่ในรูปแบบใด (PPT, PPTX, ODP และอื่น ๆ) ในขณะนี้

คุณสามารถตรวจสอบรูปแบบของการนำเสนอโดยไม่ต้องโหลดการนำเสนอได้ ดูโค้ด Python นี้:

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

โค้ด Python นี้แสดงวิธีรับคุณสมบัติการนำเสนอ (ข้อมูลเกี่ยวกับการนำเสนอ):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

คุณอาจต้องการดูคุณสมบัติภายในคลาส [DocumentProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/documentproperties/#properties)

## **อัปเดตคุณสมบัติการนำเสนอ**

Aspose.Slides มีเมธอด [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) ที่ให้คุณแก้ไขคุณสมบัติการนำเสนอได้

สมมติว่าเรามีการนำเสนอ PowerPoint ที่มีคุณสมบัติของเอกสารแสดงด้านล่าง

![คุณสมบัติเอกสารต้นฉบับของการนำเสนอ PowerPoint](input_properties.png)

โค้ดตัวอย่างนี้แสดงวิธีแก้ไขบางคุณสมบัติของการนำเสนอ:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

ผลลัพธ์ของการเปลี่ยนคุณสมบัติเอกสารถูกแสดงด้านล่าง

![คุณสมบัติเอกสารที่เปลี่ยนแปลงของการนำเสนอ PowerPoint](output_properties.png)

## **ลิงก์ที่เป็นประโยชน์**

เพื่อรับข้อมูลเพิ่มเติมเกี่ยวกับการนำเสนอและแอตริบิวต์ด้านความปลอดภัย คุณอาจพบว่าลิงก์ต่อไปนี้มีประโยชน์:

- [การปกป้องการนำเสนอด้วยรหัสผ่าน](/slides/th/python-net/password-protected-presentation/)
- [การป้องกันการเขียนของการนำเสนอ](/slides/th/python-net/write-protected-presentation/)

## **คำถามที่พบบ่อย**

**ฉันจะตรวจสอบได้อย่างไรว่าฟอนต์ถูกฝังไว้และเป็นฟอนต์ใด?**

ค้นหา [embedded-font information](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) ที่ระดับการนำเสนอ แล้วเปรียบเทียบรายการเหล่านั้นกับชุด [fonts actually used across content](https://reference.aspose.com/slides/th/python-net/aspose.slides/fontsmanager/get_fonts/) เพื่อระบุฟอนต์ที่สำคัญสำหรับการเรนเดอร์

**ฉันจะสามารถบอกได้อย่างรวดเร็วว่าไฟล์มีสไลด์ที่ซ่อนอยู่หรือไม่และจำนวนเท่าไหร่?**

วนรอบผ่าน [slide collection](https://reference.aspose.com/slides/th/python-net/aspose.slides/slidecollection/) และตรวจสอบ [visibility flag](https://reference.aspose.com/slides/th/python-net/aspose.slides/slide/hidden/) ของแต่ละสไลด์

**ฉันสามารถตรวจจับได้หรือไม่ว่ามีการใช้ขนาดและแนวตั้งของสไลด์ที่กำหนดเองหรือไม่ และว่าต่างจากค่าเริ่มต้นหรือไม่?**

ได้. เปรียบเทียบ [slide size](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/slide_size/) และแนวตั้งปัจจุบันกับค่าพรีเซ็ตมาตรฐาน; สิ่งนี้ช่วยคาดการณ์พฤติกรรมสำหรับการพิมพ์และการส่งออก

**มีวิธีรวดเร็วในการดูว่ากราฟอ้างอิงแหล่งข้อมูลภายนอกหรือไม่?**

ได้. เดินทางผ่านทุก [charts](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/) ตรวจสอบ [data source](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chartdata/data_source_type/) ของพวกมัน และบันทึกว่าข้อมูลเป็นภายในหรือเชื่อมโยงจากภายนอก รวมถึงลิงก์ที่เสีย

**ฉันจะประเมินสไลด์ที่ 'หนัก' ที่อาจทำให้การเรนเดอร์หรือการส่งออกเป็น PDF ช้าได้อย่างไร?**

สำหรับแต่ละสไลด์ ให้นับจำนวนวัตถุและมองหาภาพขนาดใหญ่, ความโปร่งแสง, เงา, แอนิเมชัน, และมัลติมีเดีย; กำหนดคะแนนความซับซ้อนโดยประมาณเพื่อระบุจุดบอดที่อาจส่งผลต่อประสิทธิภาพ