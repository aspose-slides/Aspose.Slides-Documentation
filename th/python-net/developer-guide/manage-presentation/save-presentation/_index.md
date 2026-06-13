---
title: บันทึกงานนำเสนอใน Python
linktitle: บันทึกงานนำเสนอ
type: docs
weight: 80
url: /th/python-net/save-presentation/
keywords:
- บันทึก PowerPoint
- บันทึก OpenDocument
- บันทึกงานนำเสนอ
- บันทึกสไลด์
- บันทึก PPT
- บันทึก PPTX
- บันทึก ODP
- งานนำเสนอเป็นไฟล์
- งานนำเสนอเป็นสตรีม
- ประเภทมุมมองที่กำหนดล่วงหน้า
- รูปแบบ Strict Office Open XML
- โหมด Zip64
- รีเฟรชรูปย่อ
- ความคืบหน้าในการบันทึก
- Python
- Aspose.Slides
description: "ค้นพบวิธีการบันทึกงานนำเสนอใน Python ด้วย Aspose.Slides—ส่งออกเป็น PowerPoint หรือ OpenDocument ขณะรักษาเค้าโครง ฟอนต์ และเอฟเฟกต์ไว้."
---
## **ภาพรวม**

[เปิดงานนำเสนอใน Python](/slides/th/python-net/open-presentation/) อธิบายวิธีการใช้คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) เพื่อเปิดงานนำเสนอ บทความนี้อธิบายวิธีการสร้างและบันทึกงานนำเสนอ คลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) มีเนื้อหาของงานนำเสนอ ไม่ว่าคุณจะสร้างงานนำเสนอจากศูนย์หรือแก้ไขงานที่มีอยู่ คุณจะต้องบันทึกเมื่อทำเสร็จแล้ว ด้วย Aspose.Slides for Python คุณสามารถบันทึกเป็น **ไฟล์** หรือ **สตรีม** บทความนี้อธิบายวิธีต่าง ๆ ในการบันทึกงานนำเสนอ

## **บันทึกงานนำเสนอเป็นไฟล์**

บันทึกงานนำเสนอเป็นไฟล์โดยเรียกเมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) ส่งชื่อไฟล์และรูปแบบการบันทึกเข้าไปในเมธอด ตัวอย่างต่อไปนี้แสดงวิธีบันทึกงานนำเสนอด้วย Aspose.Slides for Python.

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ
with slides.Presentation() as presentation:
    
    # ทำงานบางอย่างที่นี่...

    # บันทึกงานนำเสนอเป็นไฟล์
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอเป็นสตรีม**

คุณสามารถบันทึกงานนำเสนอเป็นสตรีมโดยส่งสตรีมเอาต์พุตให้เมธอด `save` ของคลาส [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) งานนำเสนอสามารถเขียนลงสตรีมหลายประเภท ในตัวอย่างด้านล่าง เราจะสร้างงานนำเสนอใหม่ เพิ่มข้อความลงในรูปร่างและบันทึกลงสตรีม

```py
import aspose.slides as slides

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # บันทึกงานนำเสนอไปยังสตรีม.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอด้วยประเภทมุมมองที่กำหนดไว้ล่วงหน้า**

Aspose.Slides for Python ให้คุณตั้งค่ามุมมองเริ่มต้นที่ PowerPoint ใช้เมื่อเปิดงานนำเสนอที่สร้างขึ้นผ่านคลาส [ViewProperties](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewproperties/) ตั้งค่าคุณสมบัติ `last_view` ให้เป็นค่าจาก enumeration ของ [ViewType](https://reference.aspose.com/slides/th/python-net/aspose.slides/viewtype/)

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML**

Aspose.Slides ให้คุณบันทึกงานนำเสนอในรูปแบบ Strict Office Open XML ใช้คลาส [PptxOptions](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/) และตั้งค่าคุณสมบัติ conformance เมื่อบันทึก หากคุณตั้งค่า `Conformance.ISO_29500_2008_STRICT` ไฟล์ผลลัพธ์จะถูกบันทึกในรูปแบบ Strict Office Open XML

ตัวอย่างด้านล่างสร้างงานนำเสนอและบันทึกในรูปแบบ Strict Office Open XML

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์งานนำเสนอ.
with slides.Presentation() as presentation:
    # บันทึกงานนำเสนอในรูปแบบ Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **บันทึกงานนำเสนอในรูปแบบ Office Open XML โหมด Zip64**

ไฟล์ Office Open XML เป็นไฟล์ ZIP ที่กำหนดขีดจำกัด 4 GB (2^32 ไบต์) สำหรับขนาดไฟล์ที่ไม่ได้บีบอัดของไฟล์ใดไฟล์หนึ่ง, ขนาดไฟล์ที่บีบอัดของไฟล์ใดไฟล์หนึ่ง, และขนาดรวมของอาร์ไคฟ์ และยังจำกัดจำนวนไฟล์ในอาร์ไคฟ์ไว้ที่ 65,535 (2^16‑1) ไฟล์ ส่วนส่วนขยายรูปแบบ ZIP64 ปรับขีดจำกัดเหล่านี้เป็น 2^64

คุณสมบัติ [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) ให้คุณเลือกใช้ส่วนขยายรูปแบบ ZIP64 เมื่อบันทึกไฟล์ Office Open XML

รูปแบบนี้ให้โหมดต่อไปนี้:

- `IF_NECESSARY` ใช้ส่วนขยาย ZIP64 เฉพาะเมื่องานนำเสนอเกินขีดจำกัดข้างต้น นี่เป็นโหมดเริ่มต้น
- `NEVER` ไม่ใช้ส่วนขยาย ZIP64
- `ALWAYS` ใช้ส่วนขยาย ZIP64 เสมอ

โค้ดต่อไปนี้แสดงวิธีบันทึกงานนำเสนอเป็น PPTX พร้อมเปิดใช้งานส่วนขยายรูปแบบ ZIP64:

```py
pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}
เมื่อคุณบันทึกด้วย `Zip64Mode.NEVER` จะเกิด [PptxException](https://reference.aspose.com/slides/th/python-net/aspose.slides/pptxexception/) หากงานนำเสนอไม่สามารถบันทึกในรูปแบบ ZIP32
{{% /alert %}}

## **บันทึกงานนำเสนอโดยไม่รีเฟรชรูปย่อ**

คุณสมบัติ [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/th/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) ควบคุมการสร้างรูปย่อเมื่อบันทึกงานนำเสนอเป็น PPTX:

- ถ้าตั้งค่าเป็น `True` รูปย่อจะถูกรีเฟรชระหว่างการบันทึก นี่คือค่าเริ่มต้น
- ถ้าตั้งค่าเป็น `False` รูปย่อปัจจุบันจะถูกเก็บไว้ หากงานนำเสนอไม่มีรูปย่อจะไม่มีการสร้าง

ในโค้ดด้านล่าง งานนำเสนอจะถูกบันทึกเป็น PPTX โดยไม่รีเฟรชรูปย่อ

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}
ตัวเลือกนี้ช่วยลดเวลาที่ใช้ในการบันทึกงานนำเสนอในรูปแบบ PPTX
{{% /alert %}}

{{% alert title="Info" color="info" %}}
Aspose ได้พัฒนาแอปพลิเคชัน [ฟรี PowerPoint Splitter app](https://products.aspose.app/slides/th/splitter) ด้วย API ของตนเอง แอปนี้ให้คุณแยกงานนำเสนอเป็นหลายไฟล์โดยบันทึกสไลด์ที่เลือกเป็นไฟล์ PPTX หรือ PPT ใหม่
{{% /alert %}}

## **คำถามที่พบบ่อย**

**รองรับการบันทึกแบบ "เร็ว" (บันทึกแบบเพิ่ม) เพื่อให้เขียนเฉพาะการเปลี่ยนแปลงหรือไม่?**

ไม่ การบันทึกจะสร้างไฟล์ผลลัพธ์เต็มทุกครั้ง; การบันทึกแบบเพิ่ม "เร็ว" ไม่ได้รับการสนับสนุน

**การบันทึกอินสแตนซ์ Presentation เดียวจากหลายเธรดปลอดภัยหรือไม่?**

ไม่ อินสแตนซ์ [Presentation](https://reference.aspose.com/slides/th/python-net/aspose.slides/presentation/) [ไม่ปลอดภัยต่อการทำงานหลายเธรด](/slides/th/python-net/multithreading/); ควรบันทึกจากเธรดเดียว

**อะไรจะเกิดกับลิงก์ไฮเปอร์ลิงก์และไฟล์ที่เชื่อมโยงภายนอกเมื่อบันทึก?**

[Hyperlinks](/slides/th/python-net/manage-hyperlinks/) จะถูกเก็บไว้ ไฟล์ที่เชื่อมโยงจากภายนอก (เช่น วิดีโอที่อ้างอิงด้วยพาธสัมพันธ์) จะไม่ถูกคัดลอกโดยอัตโนมัติ—ควรตรวจสอบให้พาธที่อ้างอิงยังคงเข้าถึงได้

**ฉันสามารถตั้งค่า/บันทึกเมตาดาต้าเอกสาร (ผู้เขียน, ชื่อเรื่อง, บริษัท, วันที่) ได้หรือไม่?**

ได้ คุณสมบัติเอกสารมาตรฐาน [document properties](/slides/th/python-net/presentation-properties/) ได้รับการสนับสนุนและจะถูกเขียนลงในไฟล์เมื่อตอนบันทึก